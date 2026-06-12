---
title: Hoe de voorbeelden uit te voeren
type: docs
weight: 140
url: /nl/php-java/how-to-run-the-examples/
keywords:
- voorbeelden
- softwarevereisten
- GitHub
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Voer Aspose.Slides voor PHP via Java-voorbeelden snel uit: kloon de repo, herstel pakketten, en bouw en test functies voor PPT, PPTX en ODP."
---
## **Downloaden van GitHub**
Alle voorbeelden van Aspose.Slides voor PHP via Java worden gehost op [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java). Je kunt de repository klonen met je favoriete Github‑client of het ZIP‑bestand downloaden van [hier](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master).

Pak de inhoud van het ZIP‑bestand uit naar een willekeurige map op je computer. Alle voorbeelden staan in de **Examples** map.

![todo:image_alt_text](examples_directory.png)

## **Importeer voorbeelden in de IDE**
Het project maakt gebruik van het Maven‑buildsysteem. Elke moderne IDE kan het project en de afhankelijkheden eenvoudig openen of importeren. Hieronder laten we zien hoe je populaire IDE's kunt gebruiken om de voorbeelden te bouwen en uit te voeren.

### **IntelliJ IDEA**
Klik op het **File**‑menu en kies **Open**. Navigeer naar de projectmap en selecteer het **pom.xml**‑bestand.

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

Het project wordt geopend en de afhankelijkheden worden automatisch gedownload. In het tabblad Project kun je de voorbeelden in de map **src/main/java** bekijken. Om een voorbeeld uit te voeren, klik je met de rechtermuisknop op het bestand en kies je "Run .."; het voorbeeld wordt uitgevoerd en de uitvoer wordt getoond in het ingebouwde console‑uitvoervenster.

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
Klik op het **File**‑menu en kies **Import**. Selecteer **Maven** – Existing Maven Projects.

![todo:image_alt_text](eclipse_import.png)

Navigeer naar de map die je van GitHub hebt gekloond of gedownload en selecteer het **pom.xml**‑bestand. Het project wordt geopend en de afhankelijkheden worden automatisch gedownload. In het tabblad Package Explorer kun je de voorbeelden in de map **src/main/java** bekijken. Om een voorbeeld uit te voeren, klik je met de rechtermuisknop op het bestand en kies je **Run As** - **Java Application**; het voorbeeld wordt uitgevoerd en de uitvoer wordt getoond in het ingebouwde console‑uitvoervenster.

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
Klik op het **File**‑menu en kies **Open Project**. Navigeer naar de map die je van GitHub hebt gekloond of gedownload. Het pictogram van de **Examples**‑map geeft aan dat het een Maven‑project is. Selecteer **Examples** en open het.

![todo:image_alt_text](netbeans_openproject.png)

Het project wordt geopend en de afhankelijkheden worden automatisch gedownload. In het tabblad Projects kun je de voorbeelden in **source packages** bekijken. Om een voorbeeld uit te voeren, klik je met de rechtermuisknop op het bestand en kies je **Run File**; het voorbeeld wordt uitgevoerd en de uitvoer wordt getoond in het ingebouwde console‑uitvoervenster.

![todo:image_alt_text](netbeans_run_example.png)

## **Voeg Aspose.Slides‑bibliotheek toe aan lokale Maven‑repository**
Wanneer je het project **Aspose.Slides Examples** in de IDE importeert, downloadt Maven automatisch het aspose.slides‑JAR‑bestand van de [Aspose Maven Repository](https://releases.aspose.com/php-java/repo/com/aspose/). Als je geen internettoegang hebt, kun je het JAR‑bestand handmatig toevoegen aan je lokale repository.

### **mvn install**
Download de [aspose.slides](https://releases.aspose.com/php-java/repo/com/aspose/aspose-slides/), pak het uit en kopieer het bestand aspose.slides-version.jar naar een andere locatie, bijvoorbeeld de C‑schijf. Voer het volgende commando uit:

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

Nu is de **aspose.slides**‑jar gekopieerd naar je lokale Maven‑repository.

### **pom.xml**
Na installatie declareer je simpelweg de **aspose.slides**‑coördinaat in pom.xml. Voeg de volgende repository toe in het tabblad repositories en de afhankelijkheid in het tabblad dependencies.

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


### **Done**
Bouw het; nu kan de **aspose.slides**‑jar worden opgehaald uit je lokale Maven‑repository.

## **Bijdragen**
Als je een voorbeeld wilt toevoegen of verbeteren, moedigen we je aan bij te dragen aan het project. Alle voorbeelden en showcase‑projecten in deze repository zijn open source en kunnen vrij worden gebruikt in je eigen toepassingen.

Om bij te dragen, kun je de repository forken, de broncode bewerken en een Pull Request indienen. Wij beoordelen de wijzigingen en nemen ze op in de repository als ze nuttig blijken te zijn.