---
title: Как запустить примеры
type: docs
weight: 140
url: /ru/java/how-to-run-the-examples/
keywords:
- примеры
- программные требования
- GitHub
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Быстро запустите примеры Aspose.Slides for Java: клонируйте репозиторий, восстановите пакеты, затем соберите и протестируйте функции для PPT, PPTX и ODP."
---

## **Скачать Aspose.Slides с GitHub**
Все примеры Aspose.Slides для Java размещены на [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java). Вы можете либо клонировать репозиторий с помощью вашего любимого клиента Github, либо скачать ZIP‑файл [здесь](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master).

Распакуйте содержимое ZIP‑файла в любую папку на вашем компьютере. Все примеры находятся в папке **Examples**.

![todo:image_alt_text](examples_directory.png)

## **Импортировать примеры в IDE**
Проект использует систему сборки Maven. Любая современная IDE может легко открыть или импортировать проект и его зависимости. Ниже мы покажем, как использовать популярные IDE для сборки и выполнения примеров.

### **IntelliJ IDEA**
Щелкните меню **File** и выберите **Open**. Найдите папку проекта и выберите файл **pom.xml**.

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

IDE откроет проект и автоматически загрузит зависимости. На вкладке Project найдите примеры в папке **src/main/java**. Чтобы выполнить пример, просто щёлкните правой кнопкой по файлу и выберите "Run ..", пример будет выполнен, а вывод появится во встроенном окне консоли.

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
Щелкните меню **File** и выберите **Import**. Выберите **Maven** - Existing Maven Projects.

![todo:image_alt_text](eclipse_import.png)

Найдите папку, которую вы клонировали или скачали с GitHub, и выберите файл **pom.xml**. IDE откроет проект и автоматически загрузит зависимости. Во вкладке Package Explorer найдите примеры в папке **src/main/java**. Чтобы выполнить пример, щёлкните правой кнопкой по файлу и выберите **Run As** - **Java Application**, пример будет выполнен, а вывод появится во встроенном окне консоли.

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
Щелкните меню **File** и выберите **Open Project**. Найдите папку, которую вы клонировали или скачали с GitHub. Значок папки **Examples** покажет, что это Maven‑проект. Выберите Examples и откройте её.

![todo:image_alt_text](netbeans_openproject.png)

IDE откроет проект и автоматически загрузит зависимости. На вкладке Projects найдите примеры в **source packages**. Чтобы выполнить пример, щёлкните правой кнопкой по файлу и выберите **Run File**, пример будет выполнен, а вывод появится во встроенном окне консоли.

![todo:image_alt_text](netbeans_run_example.png)

## **Добавить библиотеку Aspose.Slides в локальный репозиторий Maven**
При импорте проекта **Aspose.Slides Examples** в IDE Maven автоматически загружает JAR‑файл aspose.slides из [Aspose Maven Repository](https://releases.aspose.com/java/repo/com/aspose/). Если у вас нет доступа к интернету, вы можете вручную добавить JAR в ваш локальный репозиторий.

### **mvn install**
Скачайте [aspose.slides](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/), распакуйте его и скопируйте файл aspose.slides-version.jar в любое место, например, на диск C. Выполните следующую команду:
```
mvn install:install-file
    -Dfile=c:\aspose.slides-version.jar
    -DgroupId=com.aspose
    -DartifactId=aspose-slides
    -Dversion={version}
    -Dpackaging=jar
```


Теперь JAR‑файл **aspose.slides** скопирован в ваш локальный репозиторий Maven.

### **pom.xml**
После установки просто объявите координаты **aspose.slides** в pom.xml. Добавьте следующий репозиторий в раздел repositories и зависимость в раздел dependencies.
``` xml
<repository>
    <id>aspose-maven-repository</id>
    <url>http://repository.aspose.com/repo/</url>
</repository>

<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides</artifactId>
    <version>18.6</version>
    <classifier>jdk16</classifier>
</dependency>
```


### **Done**
Соберите проект, теперь JAR‑файл **aspose.slides** будет извлекаться из вашего локального репозитория Maven.

## **Сделать вклад**
Если вы хотите добавить или улучшить пример, мы приглашаем вас сделать вклад в проект. Все примеры и демонстрационные проекты в этом репозитории являются открытым исходным кодом и могут свободно использоваться в ваших собственных приложениях.

Чтобы внести вклад, вы можете форкнуть репозиторий, отредактировать исходный код и отправить Pull Request. Мы рассмотрим изменения и включим их в репозиторий, если они окажутся полезными.