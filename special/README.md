# Лаборатораная работа по ТРПО №2
07.08.2020

Пресет алиасов:
```bash
git config --global alias.st status
git config --global alias.br branch
git config --global alias.hist "log --pretty=format:'%h %ad | %s%d [%an]' --graph --date=short"
```

---

Возможный старт лабораторной с нуля:
```bash
mkdir -p BCIT/special && cd BCIT
git init
echo "TEST 1" >> special/file1.txt
echo "TEST 2" >> special/file2.txt
git add special/ && git commit -m "Init repo with special dir"
```

```
(base) MacBook-Pro-Mihail:BCIT snipghost$ echo "TEST 1" >> special/file1.txt
(base) MacBook-Pro-Mihail:BCIT snipghost$ echo "TEST 2" >> special/file2.txt
(base) MacBook-Pro-Mihail:BCIT snipghost$ git add special/ && git commit -m "Init repo with special dir"
[master 4752f38] Init repo with special dir
 2 files changed, 2 insertions(+)
 create mode 100644 special/file1.txt
 create mode 100644 special/file2.txt
(base) MacBook-Pro-Mihail:BCIT snipghost$ git st
On branch master
Your branch is ahead of 'origin/master' by 1 commit.
  (use "git push" to publish your local commits)

nothing to commit, working tree clean
(base) MacBook-Pro-Mihail:BCIT snipghost$ git hist
* 4752f38 - (HEAD -> master) Init repo with special dir (10 seconds ago) <Mikhail Kucherenko>
* 0f75f26 - (origin/master, origin/HEAD) Fix main README.md (35 minutes ago) <Mikhail Kucherenko>
* 91ecffe - Add new Doxygen for BCIT-Lab2 (39 minutes ago) <Mikhail Kucherenko>
* 1693f4a - Change Doxygen generation (47 minutes ago) <Mikhail Kucherenko>
* dc8a307 - Hand-remaked README for Lab2 with images (3 years, 2 months ago) <SnipGhost>
* 172c19b - Update README.md (3 years, 2 months ago) <SnipGhost>
```

---

Т.о. на данном шагу имеем некоторый репозиторий. Начинаем работу:
```bash
git checkout -b special
touch special/new_file.txt
echo "special branch changes" >> special/file1.txt
sed -i -e 's/TEST/TESTING/g' special/*.txt
cat special/file1.txt
cat special/file2.txt
git add special/ && git commit -m "Add special branch changes"
```


```
(base) MacBook-Pro-Mihail:BCIT snipghost$ git checkout -b special
touch special/new_file.txt
echo "special branch changes" >> special/file1.txt
sed -i -e 's/TEST/TESTING/g' special/*.txtSwitched to a new branch 'special'
(base) MacBook-Pro-Mihail:BCIT snipghost$ touch special/new_file.txt
(base) MacBook-Pro-Mihail:BCIT snipghost$ echo "special branch changes" >> special/file1.txt
(base) MacBook-Pro-Mihail:BCIT snipghost$ sed -i -e 's/TEST/TESTING/g' special/*.txt
(base) MacBook-Pro-Mihail:BCIT snipghost$ 
(base) MacBook-Pro-Mihail:BCIT snipghost$ 
(base) MacBook-Pro-Mihail:BCIT snipghost$ cat special/file1.txt
TESTING 1
special branch changes
(base) MacBook-Pro-Mihail:BCIT snipghost$ cat special/file2.txt
TESTING 2
(base) MacBook-Pro-Mihail:BCIT snipghost$ git add special/ && git commit -m "Add special branch changes"
[special 58feb91] Add special branch changes
 6 files changed, 6 insertions(+), 2 deletions(-)
 create mode 100644 special/file1.txt-e
 create mode 100644 special/file2.txt-e
 create mode 100644 special/new_file.txt
 create mode 100644 special/new_file.txt-e
 ```

---

А потом ваш коллега делает что-то в мастер-ветке (господи, коммитить в мастер...). Эмулируем это:
```bash
git checkout master
echo "NEW TEST" >> special/file1.txt
sed -i -e 's/TEST \([0-9]\)/TEST 0\1/g' special/file1.txt
cat special/file1.txt
git add special/ && git commit -m "Add new test"
```


```
(base) MacBook-Pro-Mihail:BCIT snipghost$ git checkout master
Switched to branch 'master'
Your branch is ahead of 'origin/master' by 1 commit.
  (use "git push" to publish your local commits)
(base) MacBook-Pro-Mihail:BCIT snipghost$ echo "NEW TEST 1" >> special/file1.txt
(base) MacBook-Pro-Mihail:BCIT snipghost$ sed -i -e 's/TEST \([0-9]\)/TEST 0\1/g' special/file1.txt
(base) MacBook-Pro-Mihail:BCIT snipghost$ cat special/file1.txt
TEST 01
NEW TEST 01
(base) MacBook-Pro-Mihail:BCIT snipghost$ git add special/ && git commit -m "Add new test"
[master e3cf67d] Add new test
 2 files changed, 4 insertions(+), 1 deletion(-)
 create mode 100644 special/file1.txt-e
```

---

Пытаемся слить изменения из ветки special
```bash
git br
git merge special
cat special/file1.txt
nano special/file1.txt
cat special/file1.txt
git add . && git commit -m "Merge special to master"
git hist
```


```
(base) MacBook-Pro-Mihail:BCIT snipghost$ git br
* master
  special
(base) MacBook-Pro-Mihail:BCIT snipghost$ git merge special
CONFLICT (add/add): Merge conflict in special/file1.txt-e
Auto-merging special/file1.txt-e
Auto-merging special/file1.txt
CONFLICT (content): Merge conflict in special/file1.txt
Automatic merge failed; fix conflicts and then commit the result.
(base) MacBook-Pro-Mihail:BCIT snipghost$ cat special/file1.txt
<<<<<<< HEAD
TEST 01
NEW TEST 01
=======
TESTING 1
special branch changes
>>>>>>> special
(base) MacBook-Pro-Mihail:BCIT snipghost$ nano special/file1.txt
(base) MacBook-Pro-Mihail:BCIT snipghost$ cat special/file1.txt
TESTING 01
NEW TESTING 01
special branch changes

(base) MacBook-Pro-Mihail:BCIT snipghost$ git hist
*   2c05965 - (HEAD -> master) Merge special to master (22 seconds ago) <Mikhail Kucherenko>
|\  
| * 58feb91 - (special) Add special branch changes (17 minutes ago) <Mikhail Kucherenko>
* | e3cf67d - Add new test (6 minutes ago) <Mikhail Kucherenko>
|/  
* 4752f38 - Init repo with special dir (20 minutes ago) <Mikhail Kucherenko>
* 0f75f26 - (origin/master, origin/HEAD) Fix main README.md (55 minutes ago) <Mikhail Kucherenko>
* 91ecffe - Add new Doxygen for BCIT-Lab2 (59 minutes ago) <Mikhail Kucherenko>
* 1693f4a - Change Doxygen generation (66 minutes ago) <Mikhail Kucherenko>
* dc8a307 - Hand-remaked README for Lab2 with images (3 years, 2 months ago) <SnipGhost>
* 172c19b - Update README.md (3 years, 2 months ago) <SnipGhost>
```

---

Откатываем изменения на ветке special

```bash
git checkout special
git hist -n2
git reset --hard HEAD^
git hist -n2
```

```
(base) MacBook-Pro-Mihail:BCIT snipghost$ git checkout special
Switched to branch 'special'
(base) MacBook-Pro-Mihail:BCIT snipghost$ git hist -n2
* 58feb91 - (HEAD -> special) Add special branch changes (18 minutes ago) <Mikhail Kucherenko>
* 4752f38 - Init repo with special dir (21 minutes ago) <Mikhail Kucherenko>
(base) MacBook-Pro-Mihail:BCIT snipghost$ git reset --hard HEAD^
HEAD is now at 4752f38 Init repo with special dir
(base) MacBook-Pro-Mihail:BCIT snipghost$ git hist -n2
* 4752f38 - (HEAD -> special) Init repo with special dir (21 minutes ago) <Mikhail Kucherenko>
* 0f75f26 - (origin/master, origin/HEAD) Fix main README.md (56 minutes ago) <Mikhail Kucherenko>
```

