---
title: Как запустить примеры
type: docs
weight: 140
url: /ru/java/how-to-run-the-examples/
keywords:
- примеры
- требования к программному обеспечению
- GitHub
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Запустите примеры Aspose.Slides для Java быстро: клонируйте репозиторий, восстановите пакеты, затем соберите и протестируйте функции для PPT, PPTX и ODP."
---
## **Скачать Aspose.Slides с GitHub**
Все примеры Aspose.Slides для Java размещены на [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java). Вы можете либо клонировать репозиторий с помощью вашего любимого клиента Github, либо загрузить ZIP‑файл из [здесь](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master).

Извлеките содержимое ZIP‑файла в любую папку на вашем компьютере. Все примеры находятся в папке **Examples**.

![todo:image_alt_text](examples_directory.png)

## **Импортировать примеры в IDE**
Проект использует систему сборки Maven. Любая современная IDE может без труда открыть или импортировать проект и его зависимости. Ниже показано, как с помощью популярных IDE собрать и запустить примеры.

### **IntelliJ IDEA**
Нажмите меню **File** и выберите **Open**. Перейдите к папке проекта и выберите файл **pom.xml**.

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

Он откроет проект и автоматически загрузит зависимости. На вкладке Project перейдите к примерам в папке **src/main/java**. Чтобы запустить пример, просто щёлкните правой кнопкой мыши по файлу и выберите "Run ..", пример будет выполнен, а вывод будет показан во встроенном окне консоли.

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
Нажмите меню **File** и выберите **Import**. Выберите **Maven** — Existing Maven Projects.

![todo:image_alt_text](eclipse_import.png)

Перейдите к папке, которую вы клонировали или загрузили с GitHub, и выберите файл **pom.xml**. Он откроет проект и автоматически загрузит зависимости. На вкладке Package Explorer перейдите к примерам в папке **src/main/java**. Чтобы запустить пример, просто щёлкните правой кнопкой мыши по файлу и выберите **Run As** - **Java Application**, пример будет выполнен, а вывод будет показан во встроенном окне консоли.

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
Нажмите меню **File** и выберите **Open Project**. Перейдите к папке, которую вы клонировали или загрузили с GitHub. Значок папки **Examples** покажет, что это Maven‑проект. Выберите **Examples** и откройте её.

![todo:image_alt_text](netbeans_openproject.png)

Он откроет проект и автоматически загрузит зависимости. На вкладке Projects перейдите к примерам в **source packages**. Чтобы запустить пример, просто щёлкните правой кнопкой мыши по файлу и выберите **Run File**, пример будет выполнен, а вывод будет показан во встроенном окне консоли.

![todo:image_alt_text](netbeans_run_example.png)

## **Добавить библиотеку Aspose.Slides в локальный репозиторий Maven**
При импорте проекта **Aspose.Slides Examples** в IDE Maven автоматически загружает JAR‑файл aspose.slides из [Aspose Maven Repository](https://releases.aspose.com/java/repo/com/aspose/). Если у вас нет доступа к интернету, JAR можно добавить вручную в локальный репозиторий.

### **mvn install**
Скачайте [aspose.slides](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/), распакуйте его и скопируйте aspose.slides‑version.jar в любое место, например, на диск C. Выполните следующую команду:

```
mvn install:install-file
    - Dfile=c:\aspose.slides-version.jar
    - DgroupId=com.aspose
    - DartifactId=aspose-slides
    - Dversion={version}
    - Dpackaging=jar
```

Теперь JAR **aspose.slides** скопирован в ваш локальный репозиторий Maven.

### **pom.xml**
После установки просто объявите координату **aspose.slides** в pom.xml. Добавьте следующий репозиторий во вкладку repositories и зависимость во вкладку dependencies.

``` xml
<repository>
    <id>AsposeJavaAPI</id>
    <name>Aspose Java API</name>
    <url>https://releases.aspose.com/java/repo/</url>
</repository>

<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides</artifactId>
    <version>26.10</version>
    <classifier>jdk8</classifier>
</dependency>
```

### **Готово**
Соберите проект, теперь JAR **aspose.slides** будет извлекаться из вашего локального репозитория Maven.

## **Содействовать**
Если вы хотите добавить или улучшить пример, мы поощряем ваш вклад в проект. Все примеры и демонстрационные проекты в этом репозитории являются открытым исходным кодом и могут свободно использоваться в ваших собственных приложениях.

Чтобы внести вклад, вы можете создать форк репозитория, отредактировать исходный код и отправить Pull Request. Мы рассмотрим изменения и включим их в репозиторий, если они окажутся полезными.