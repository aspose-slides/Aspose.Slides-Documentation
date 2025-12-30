---
title: Как запустить примеры
type: docs
weight: 140
url: /ru/php-java/how-to-run-the-examples/
keywords:
- примеры
- требования к программному обеспечению
- GitHub
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Запустите примеры Aspose.Slides для PHP через Java быстро: клонируйте репозиторий, восстановите пакеты, затем соберите и протестируйте функции для PPT, PPTX и ODP."
---

## **Скачать с GitHub**
Все примеры Aspose.Slides для PHP через Java размещены на [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java). Вы можете либо клонировать репозиторий с помощью вашего любимого клиента Github, либо скачать ZIP‑файл по [здесь](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master).

Извлеките содержимое ZIP‑файла в любую папку на вашем компьютере. Все примеры находятся в папке **Examples**.

![todo:image_alt_text](examples_directory.png)

## **Импорт примеров в IDE**
Проект использует систему сборки Maven. Любая современная IDE может легко открыть или импортировать проект и его зависимости. Ниже показано, как с помощью популярных IDE собрать и запустить примеры.

### **IntelliJ IDEA**
Щелкните меню **File** и выберите **Open**. Перейдите к папке проекта и выберите файл **pom.xml**.

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

IDE откроет проект и автоматически загрузит зависимости. На вкладке Project перейдите к примерам в папке **src/main/java**. Чтобы запустить пример, щелкните правой кнопкой мыши по файлу и выберите «Run ..», пример будет выполнен, и вывод появится во встроенном окне консоли.

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
Щелкните меню **File** и выберите **Import**. Выберите **Maven** — Existing Maven Projects.

![todo:image_alt_text](eclipse_import.png)

Перейдите к папке, которую вы склонировали или скачали с GitHub, и выберите файл **pom.xml**. IDE откроет проект и автоматически загрузит зависимости. На вкладке Package Explorer перейдите к примерам в папке **src/main/java**. Чтобы запустить пример, щелкните правой кнопкой мыши по файлу и выберите **Run As** — **Java Application**, пример будет выполнен, и вывод появится во встроенном окне консоли.

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
Щелкните меню **File** и выберите **Open Project**. Перейдите к папке, которую вы склонировали или скачали с GitHub. Значок папки **Examples** укажет, что это Maven‑проект. Выберите **Examples** и откройте его.

![todo:image_alt_text](netbeans_openproject.png)

IDE откроет проект и автоматически загрузит зависимости. На вкладке Projects перейдите к примерам в **source packages**. Чтобы запустить пример, щелкните правой кнопкой мыши по файлу и выберите **Run File**, пример будет выполнен, и вывод появится во встроенном окне консоли.

![todo:image_alt_text](netbeans_run_example.png)

## **Добавить библиотеку Aspose.Slides в локальный репозиторий Maven**
Когда вы импортируете проект **Aspose.Slides Examples** в IDE, Maven автоматически загружает JAR‑файл aspose.slides из [Aspose Maven Repository](https://releases.aspose.com/php-java/repo/com/aspose/). Если у вас нет доступа к Интернету, вы можете вручную добавить JAR в ваш локальный репозиторий.

### **mvn install**
Скачайте [aspose.slides](https://releases.aspose.com/php-java/repo/com/aspose/aspose-slides/), распакуйте его и скопируйте файл aspose.slides-version.jar в любое место, например, на диск C. Выполните следующую команду:
```php

```

mvn install:install-file
    -Dfile=c:\aspose.slides-version.jar
    -DgroupId=com.aspose
    -DartifactId=aspose-slides
    -Dversion={version}
    -Dpackaging=jar
```php

```


Теперь JAR‑файл **aspose.slides** скопирован в ваш локальный репозиторий Maven.

### **pom.xml**
После установки просто объявите координаты **aspose.slides** в pom.xml. Добавьте следующий репозиторий во вкладку repositories и зависимость во вкладку dependencies.
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
```php

```


### **Done**
Соберите проект, и теперь JAR‑файл **aspose.slides** будет доступен из вашего локального репозитория Maven.

## **Содействовать**
Если вы хотите добавить или улучшить пример, мы призываем вас внести свой вклад в проект. Все примеры и демонстрационные проекты в этом репозитории являются открытым исходным кодом и могут свободно использоваться в ваших приложениях.

Для вклада вы можете создать форк репозитория, отредактировать исходный код и отправить Pull Request. Мы рассмотрим изменения и включим их в репозиторий, если они окажутся полезными.