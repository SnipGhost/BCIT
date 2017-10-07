#!/bin/bash

LANG="cs"
COMPILER="mcs"
FLAGS="-define:AUTOTEST -out:"
RUNTEST="mono"
OUTPUTEXE="bin/a.exe"

UNAME=$(uname)
DATE=`date +%d.%m.%Y`
EL="<p><br></p>\n"

if [ -z $1 ]; then
    read -p "Input number of Lab: " NUMBER
    if [ "$NUMBER" = "" ]; then
        NUMBER="X"
    fi
else
    NUMBER=$1
fi

if [ -z $2 ]; then
    read -p "Input source file (.${LANG}): " SOURCE
    if [ "$SOURCE" = "" ]; then
        SOURCE="Program.cs"
    fi
else
    SOURCE=$2
fi

if [ -z $3 ]; then
    read -p "Input output file (.md): " FILE
    if [ "$FILE" = "" ]; then
        FILE="README.md"
    fi
else
    FILE=$3
fi

if [ -z $4 ]; then
    read -p "Input tests file: " TESTSFILE
    if [ "$TESTSFILE" = "" ]; then
        TESTSFILE="tests.txt"
    fi
else
    TESTSFILE=$4
fi

if [ -z $5 ]; then
    read -p "Input description file: " DESCRIPTIONFILE
    if [ "$DESCRIPTIONFILE" = "" ]; then
        DESCRIPTIONFILE="description.txt"
    fi
else
    DESCRIPTIONFILE=$5
fi

INDEX=0
while read -r LINE; do
    TEST[$INDEX]="$LINE"
    INDEX=$(($INDEX+1))
done < $TESTSFILE

for ((INDEX=0; INDEX < ${#TEST[*]}; INDEX++))
do
    echo "TEST[$INDEX]: ${TEST[$INDEX]}"
done

if [ "$UNAME" = "Darwin" ]; then
    TIMEOUTCMD="gtimeout"
else
    TIMEOUTCMD="timeout"
fi

echo -e "#### Московский государственный технический университет имени Н.Э. Баумана  \n" > $FILE
echo -e "## Лабораторная работа по дисциплине БКИТ №${NUMBER}  \n" >> $FILE

echo -e "<p align=\"right\">\nВыполнил: <a href=\"$USEREMAIL\">$USERSIGNATURE</a>, $DATE\n</p>\n${EL}" >> $FILE

echo -e "### I. Описание задания  \n" >> $FILE
DESCRIPTION=$(cat $DESCRIPTIONFILE)
echo -e "${DESCRIPTION}\n${EL}" >> $FILE

echo -e "### II. Код программы  \n" >> $FILE
echo -e "\`\`\`${LANG}\n" >> $FILE
cat $SOURCE >> $FILE
echo -e "\n\`\`\`\n" >> $FILE
echo -e "[Исходный код](Program.cs)\n${EL}" >> $FILE

echo -e "### III. Примеры работы  \n${EL}" >> $FILE

$COMPILER $FLAGS$OUTPUTEXE $SOURCE
for ((INDEX=0; INDEX < ${#TEST[*]}; INDEX++))
do
    OUTPUT=$(echo -e ${TEST[INDEX]} | $TIMEOUTCMD -s 9 1 $RUNTEST $OUTPUTEXE)
    echo -e "\`\`\`\n${OUTPUT}\n\`\`\`\n${EL}" >> $FILE
done

pandoc $FILE -o $(echo $FILE | cut -f 1 -d '.').docx
#pandoc $FILE -o $(echo $FILE | cut -f 1 -d '.').pdf --latex-engine=xelatex -V mainfont=Arial
