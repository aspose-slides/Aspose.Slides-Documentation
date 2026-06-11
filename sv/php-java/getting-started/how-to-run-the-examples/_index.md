---
title: Hur man kör exemplen
type: docs
weight: 140
url: /sv/php-java/how-to-run-the-examples/
keywords:
- exempel
- mjukvarukrav
- GitHub
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Kör Aspose.Slides för PHP via Java-exempel snabbt: klona repoet, återställ paketen och bygg sedan samt testa funktioner för PPT, PPTX och ODP."
---
## **Ladda ner från GitHub**
Alla exempel på Aspose.Slides för PHP via Java finns på [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java). Du kan antingen klona repositoriet med din föredragna Github-klient eller ladda ner ZIP-filen från [here](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master).

Extrahera innehållet i ZIP-filen till vilken mapp som helst på din dator. Alla exempel finns i mappen **Examples**.

![todo:image_alt_text](examples_directory.png)

## **Importera exempel till IDE:n**
Projektet använder Maven-byggsystem. Alla moderna IDE:n kan enkelt öppna eller importera projektet och dess beroenden. Nedan visar vi hur du använder populära IDE:n för att bygga och köra exemplen.

### **IntelliJ IDEA**
Klicka på menyn **File** och välj **Open**. Bläddra till projektmappen och välj filen **pom.xml**.

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

Den kommer att öppna projektet och ladda ner beroendena automatiskt. Från fliken Project bläddrar du igenom exemplen i mappen **src/main/java**. För att köra ett exempel, högerklicka på filen och välj "Run ..", så körs exemplet och utskriften visas i den inbyggda konsolutdata-fönstret.

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
Klicka på menyn **File** och välj **Import**. Välj **Maven** - Existing Maven Projects.

![todo:image_alt_text](eclipse_import.png)

Bläddra till mappen som du klonade eller laddade ner från GitHub och välj filen **pom.xml**. Den kommer att öppna projektet och ladda ner beroendena automatiskt. Från fliken Package Explorer bläddrar du igenom exemplen i mappen **src/main/java**. För att köra ett exempel, högerklicka på filen och välj **Run As** - **Java Application**, så körs exemplet och utskriften visas i den inbyggda konsolutdata-fönstret.

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
Klicka på menyn **File** och välj **Open Project**. Bläddra till mappen som du klonade eller laddade ner från GitHub. Ikonen för mappen **Examples** visar att det är ett Maven-projekt. Välj Examples och öppna den.

![todo:image_alt_text](netbeans_openproject.png)

Den kommer att öppna projektet och ladda ner beroendena automatiskt. Från fliken Projects bläddrar du igenom exemplen i **source packages**. För att köra ett exempel, högerklicka på filen och välj **Run File**, så körs exemplet och utskriften visas i den inbyggda konsolutdata-fönstret.

![todo:image_alt_text](netbeans_run_example.png)

## **Lägg till Aspose.Slides-biblioteket i Maven lokala förråd**
När du importerar projektet **Aspose.Slides Examples** till IDE:n laddar Maven automatiskt ner aspose.slides JAR-filen från [Aspose Maven Repository](https://releases.aspose.com/php-java/repo/com/aspose/). Om du inte har internetåtkomst kan du manuellt lägga till JAR-filen i ditt lokala förråd.

### **mvn install**
Ladda ner [aspose.slides](https://releases.aspose.com/php-java/repo/com/aspose/aspose-slides/), extrahera den och kopiera aspose.slides-version.jar till någon annanstans, till exempel C‑enheten. Kör följande kommando:

```php

```
mvn install:install-file
    - Dfile=c:\aspose.slides-version.jar
    - DgroupId=com.aspose
    - DartifactId=aspose-slides
    - Dversion={version}
    - Dpacking=jar
```php

```

Nu har **aspose.slides**‑jar‑filen kopierats till ditt Maven‑lokala förråd.

### **pom.xml**
Efter installationen deklarerar du bara **aspose.slides**‑koordinaten i pom.xml. Lägg till följande förråd i fliken repositories och beroendet i fliken dependencies.

```xml
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


### **Klart**
Bygg projektet, nu kan **aspose.slides**‑jar‑filen hämtas från ditt Maven‑lokala förråd.

## **Bidra**
Om du vill lägga till eller förbättra ett exempel uppmuntrar vi dig att bidra till projektet. Alla exempel och showcase‑projekt i detta förråd är öppen källkod och kan fritt användas i dina egna applikationer.

För att bidra kan du göra en fork av förrådet, redigera källkoden och skicka in en Pull Request. Vi kommer att granska förändringarna och inkludera dem i förrådet om de är hjälpsamma.