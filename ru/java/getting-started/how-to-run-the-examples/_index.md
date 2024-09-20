---
title: Как запустить примеры
type: docs
weight: 140
url: /java/how-to-run-the-examples/
---

## **Скачать с GitHub**
Все примеры Aspose.Slides для Java размещены на [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java). Вы можете либо клонировать репозиторий, используя свой любимый клиент GitHub, либо загрузить ZIP-файл отсюда [здесь](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master).

Извлеките содержимое ZIP-файла в любую папку на вашем компьютере. Все примеры находятся в папке **Examples**.

![todo:image_alt_text](examples_directory.png)

## **Импорт примеров в IDE**
Проект использует систему сборки Maven. Любая современная IDE может легко открыть или импортировать проект и его зависимости. Ниже мы покажем вам, как использовать популярные IDE для сборки и запуска примеров.

### **IntelliJ IDEA**
Нажмите на меню **File** и выберите **Open**. Перейдите в папку проекта и выберите файл **pom.xml**.

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

Проект откроется, и зависимости будут загружены автоматически. На вкладке Project просмотрите примеры в папке **src/main/java**. Чтобы запустить пример, просто щелкните правой кнопкой мыши на файле и выберите "Run ..", пример будет выполнен, и вывод будет показан в встроенном окне консольного вывода.

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
Нажмите на меню **File** и выберите **Import**. Выберите **Maven** - Existing Maven Projects.

![todo:image_alt_text](eclipse_import.png)

Перейдите в папку, которую вы клонировали или загрузили с GitHub, и выберите файл **pom.xml**. Проект откроется, и зависимости будут загружены автоматически. На вкладке Package Explorer просмотрите примеры в папке **src/main/java**. Чтобы запустить пример, просто щелкните правой кнопкой мыши на файле и выберите **Run As** - **Java Application**, пример будет выполнен, и вывод будет показан в встроенном окне консольного вывода.

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
Нажмите на меню **File** и выберите **Open Project**. Перейдите в папку, которую вы клонировали или загрузили с GitHub. Значок папки **Examples** покажет, что это проект Maven. Выберите Examples и откройте его.

![todo:image_alt_text](netbeans_openproject.png)

Проект откроется, и зависимости будут загружены автоматически. На вкладке Projects просмотрите примеры в **source packages**. Чтобы запустить пример, просто щелкните правой кнопкой мыши на файле и выберите **Run File**, пример будет выполнен, и вывод будет показан в встроенном окне консольного вывода.

![todo:image_alt_text](netbeans_run_example.png)

## **Добавление библиотеки Aspose.Slides в локальный репозиторий Maven**
Когда вы импортируете проект **Aspose.Slides Examples** в IDE, Maven автоматически загружает файл JAR aspose.slides из [Aspose Maven Repository](https://releases.aspose.com/java/repo/com/aspose/). В случае, если у вас нет доступа в интернет, вы можете вручную добавить JAR в свой локальный репозиторий.

### **mvn install**
Скачайте [aspose.slides](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/), извлеките его и скопируйте aspose.slides-version.jar куда-то, например, на диск c. Выполните следующую команду:

```
mvn install:install-file
    -Dfile=c:\aspose.slides-version.jar
    -DgroupId=com.aspose
    -DartifactId=aspose-slides
    -Dversion={version}
    -Dpackaging=jar
```

Теперь JAR **aspose.slides** скопирован в ваш локальный репозиторий Maven.

### **pom.xml**
После установки просто укажите координаты **aspose.slides** в pom.xml. Добавьте следующий репозиторий на вкладку repositories и зависимость на вкладку dependencies.

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

### **Готово**
Соберите его, теперь JAR **aspose.slides** можно извлечь из вашего локального репозитория Maven.

## **Внести вклад**
Если вы хотите добавить или улучшить пример, мы призываем вас внести вклад в проект. Все примеры и демонстрационные проекты в этом репозитории являются открытым исходным кодом и могут свободно использованы в ваших собственных приложениях.

Чтобы внести вклад, вы можете форкнуть репозиторий, отредактировать исходный код и отправить Pull Request. Мы рассмотрим изменения и включим их в репозиторий, если они окажутся полезными.