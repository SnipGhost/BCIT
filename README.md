#### Московский государственный технический университет имени Н.Э. Баумана (МГТУ им. Н.Э. Баумана)

## Лабораторные работы по курсу БКИТ

Репозиторий с материалами и отчетами лабораторных работ   
по дисциплине "Базовые компоненты интернет-технологий (БКИТ/BCIT)".  

#### Выполнил: студент группы ИУ5-34, МГТУ им. Н.Э. Баумана, Кучеренко Михаил

#### Москва, 2017

<br><br>

### Структура репозитория

```
BCIT
│
├─── BCIT-Lab1        // Лабораторная работа №1
│    ├─── Program.cs  // Главный файл с лабораторной
│    ├─── ...
│    ├─── docs        // Документация (из DoxyGen) в виде HTML
│    │    └─── ...
│    ├─── latex       // Документация (из DoxyGen) в виде LaTeX
│    │    └─── ...
│    ├─── README.md   // Краткий отчет по лабораторной работе (Markdown)
│    ├─── README.docx // Краткий отчет по лабораторной работе (MS Word)
│    └─── ...
│
├─── BCIT-LabX        // Лабораторная работа №Х
│    └─── ...
│
└─── ...
```

### DOCGEN

Все отчеты к лабораторным работам сгенерированы с помощью утилиты DOCGEN.  

Для работы требует:
- [Pandoc](https://pandoc.org/installing.html)
- [Mono](http://www.mono-project.com/download/)
- [Coreutils](https://www.topbug.net/blog/2013/04/14/install-and-use-gnu-command-line-tools-in-mac-os-x/)

Пример использования:  

```bash
cd BCIT-Lab1/
../docgen.sh 1 Program.cs README.md tests.txt description.txt
```

Или с вводом на ходу (пусто - по умолчанию):
```bash
cd BCIT-Lab1/
../docgen.sh
# Input number of Lab: 1
# Input source file (.cs): 
# Input output file (.md): 
# Input tests file: 
# Input description file: 
# TEST[0]: 1\n-2\n1\ny\n
# TEST[1]: 1\n7\n10\ny\n
# TEST[2]: 2\n4\n3\ny\n
# TEST[3]: 1\n5\n2\ny\n
```

### <p align="right"> Автор: [Михаил Кучеренко "SnipGhost"](https://vk.com/snipghost), 04.10.2017 </p>
