---
title: Jak uruchomić przykłady
type: docs
weight: 140
url: /pl/php-java/how-to-run-the-examples/
keywords:
- przykłady
- wymagania oprogramowania
- GitHub
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Szybko uruchom przykłady Aspose.Slides for PHP via Java: sklonuj repozytorium, przywróć pakiety, a następnie zbuduj i przetestuj funkcje dla PPT, PPTX i ODP."
---
## **Pobierz z GitHub**
Wszystkie przykłady Aspose.Slides for PHP via Java są hostowane na [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java). Możesz sklonować repozytorium przy użyciu ulubionego klienta Github lub pobrać plik ZIP z [tutaj](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master).

Rozpakuj zawartość pliku ZIP do dowolnego folderu na swoim komputerze. Wszystkie przykłady znajdują się w folderze **Examples**.

![todo:image_alt_text](examples_directory.png)

## **Importuj przykłady do IDE**
Projekt korzysta z systemu budowania Maven. Każde nowoczesne IDE może łatwo otworzyć lub zaimportować projekt oraz jego zależności. Poniżej pokazujemy, jak używać popularnych IDE do budowania i uruchamiania przykładów.

### **IntelliJ IDEA**
Kliknij menu **File** i wybierz **Open**. Przejdź do folderu projektu i wybierz plik **pom.xml**.

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

Projekt zostanie otwarty i zależności zostaną pobrane automatycznie. W zakładce Project przeglądaj przykłady w folderze **src/main/java**. Aby uruchomić przykład, kliknij prawym przyciskiem myszy na plik i wybierz „Run ..”, przykład zostanie wykonany, a wynik zostanie wyświetlony w wbudowanym oknie konsoli.

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
Kliknij menu **File** i wybierz **Import**. Wybierz **Maven** – Existing Maven Projects.

![todo:image_alt_text](eclipse_import.png)

Przejdź do folderu, który sklonowałeś lub pobrałeś z GitHub i wybierz plik **pom.xml**. Projekt zostanie otwarty i zależności zostaną pobrane automatycznie. W zakładce Package Explorer przeglądaj przykłady w folderze **src/main/java**. Aby uruchomić przykład, kliknij prawym przyciskiem myszy na plik i wybierz **Run As** – **Java Application**, przykład zostanie wykonany, a wynik wyświetlony w wbudowanym oknie konsoli.

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
Kliknij menu **File** i wybierz **Open Project**. Przejdź do folderu, który sklonowałeś lub pobrałeś z GitHub. Ikona folderu **Examples** pokaże, że jest to projekt Maven. Wybierz Examples i otwórz go.

![todo:image_alt_text](netbeans_openproject.png)

Projekt zostanie otwarty i zależności zostaną pobrane automatycznie. W zakładce Projects przeglądaj przykłady w **source packages**. Aby uruchomić przykład, kliknij prawym przyciskiem myszy na plik i wybierz **Run File**, przykład zostanie wykonany, a wynik wyświetlony w wbudowanym oknie konsoli.

![todo:image_alt_text](netbeans_run_example.png)

## **Dodaj bibliotekę Aspose.Slides do lokalnego repozytorium Maven**
Gdy importujesz projekt **Aspose.Slides Examples** do IDE, Maven automatycznie pobiera plik JAR aspose.slides z [Aspose Maven Repository](https://releases.aspose.com/php-java/repo/com/aspose/). Jeśli nie masz dostępu do internetu, możesz ręcznie dodać JAR do swojego lokalnego repozytorium.

### **mvn install**
Pobierz [aspose.slides](https://releases.aspose.com/php-java/repo/com/aspose/aspose-slides/), rozpakuj go i skopiuj plik aspose.slides-version.jar w inne miejsce, np. na dysk C. Uruchom następujące polecenie:

```php

```
mvn install:install-file
    - Dfile=c:\aspose.slides-version.jar
    - DgroupId=com.aspose
    - DartifactId=aspose-slides
    - Dversion={version}
    - Dpackaging=jar
```php

```

Teraz plik JAR **aspose.slides** jest skopiowany do twojego lokalnego repozytorium Maven.

### **pom.xml**
Po instalacji po prostu zadeklaruj koordynaty **aspose.slides** w pliku pom.xml. Dodaj następujące repozytorium w zakładce repositories oraz zależność w zakładce dependencies.

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


### **Gotowe**
Zbuduj go, teraz plik JAR **aspose.slides** może być pobrany z twojego lokalnego repozytorium Maven.

## **Współtwórz**
Jeśli chcesz dodać lub ulepszyć przykład, zachęcamy do współpracy przy projekcie. Wszystkie przykłady i projekty demonstracyjne w tym repozytorium są otwartoźródłowe i mogą być swobodnie używane w twoich własnych aplikacjach.

Aby współtworzyć, możesz forknąć repozytorium, edytować kod źródłowy i przesłać Pull Request. Przejrzymy zmiany i włączymy je do repozytorium, jeśli będą przydatne.