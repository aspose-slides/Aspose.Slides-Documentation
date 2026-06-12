---
title: Hoe voorbeelden uitvoeren
type: docs
weight: 140
url: /nl/java/how-to-run-the-examples/
keywords:
- voorbeelden
- softwarevereisten
- GitHub
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Voer Aspose.Slides for Java-voorbeelden snel uit: kloon de repo, herstel de pakketten en bouw en test functies voor PPT, PPTX en ODP."
---
## **Download Aspose.Slides van GitHub**
Alle voorbeelden van Aspose.Slides voor Java worden gehost op [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java). U kunt de repository klonen met uw favoriete Github‑client of het ZIP‑bestand downloaden vanaf [here](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master).

Pak de inhoud van het ZIP‑bestand uit naar een willekeurige map op uw computer. Alle voorbeelden bevinden zich in de **Examples** map.

![todo:image_alt_text](examples_directory.png)

## **Voorbeelden importeren in de IDE**
Het project maakt gebruik van het Maven‑buildsysteem. Elke moderne IDE kan het project en zijn afhankelijkheden eenvoudig openen of importeren. Hieronder laten we zien hoe u populaire IDE’s kunt gebruiken om de voorbeelden te bouwen en uit te voeren.

### **IntelliJ IDEA**
Klik op het menu **File** en kies **Open**. Navigeer naar de projectmap en selecteer het bestand **pom.xml**.

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

Het project wordt geopend en de afhankelijkheden automatisch gedownload. In het tabblad **Project** kunt u de voorbeelden in de map **src/main/java** bekijken. Om een voorbeeld uit te voeren klikt u met de rechtermuisknop op het bestand en kiest u "Run ..", het voorbeeld wordt uitgevoerd en de uitvoer wordt getoond in het ingebouwde console‑outputvenster.

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
Klik op het menu **File** en kies **Import**. Selecteer **Maven** - Existing Maven Projects.

![todo:image_alt_text](eclipse_import.png)

Navigeer naar de map die u van GitHub hebt gekloond of gedownload en selecteer het bestand **pom.xml**. Het project wordt geopend en de afhankelijkheden automatisch gedownload. In het tabblad **Package Explorer** kunt u de voorbeelden in de map **src/main/java** bekijken. Om een voorbeeld uit te voeren klikt u met de rechtermuisknop op het bestand en kiest u **Run As** - **Java Application**, het voorbeeld wordt uitgevoerd en de uitvoer wordt getoond in het ingebouwde console‑outputvenster.

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
Klik op het menu **File** en kies **Open Project**. Navigeer naar de map die u van GitHub hebt gekloond of gedownload. Het pictogram van de map **Examples** geeft aan dat het een Maven‑project is. Selecteer **Examples** en open het.

![todo:image_alt_text](netbeans_openproject.png)

Het project wordt geopend en de afhankelijkheden automatisch gedownload. In het tabblad **Projects** kunt u de voorbeelden in **source packages** bekijken. Om een voorbeeld uit te voeren klikt u met de rechtermuisknop op het bestand en kiest u **Run File**, het voorbeeld wordt uitgevoerd en de uitvoer wordt getoond in het ingebouwde console‑outputvenster.

![todo:image_alt_text](netbeans_run_example.png)

## **Aspose.Slides‑bibliotheek toevoegen aan de Maven‑lokale repository**
Wanneer u het project **Aspose.Slides Examples** in de IDE importeert, downloadt Maven automatisch het aspose.slides‑JAR‑bestand van de [Aspose Maven Repository](https://releases.aspose.com/java/repo/com/aspose/). Als u geen internettoegang heeft, kunt u het JAR‑bestand handmatig toevoegen aan uw lokale repository.

### **mvn install**
Download de [aspose.slides](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/), pak deze uit en kopieer het bestand aspose.slides‑versie.jar naar een andere locatie, bijvoorbeeld de C‑schijf. Voer de volgende opdracht uit:

```
mvn install:install-file
    - Dfile=c:\aspose.slides-version.jar
    - DgroupId=com.aspose
    - DartifactId=aspose-slides
    - Dversion={version}
    - Dpackaging=jar
```

Nu is het **aspose.slides**‑JAR gekopieerd naar uw Maven‑lokale repository.

### **pom.xml**
Na installatie declareert u simpelweg de **aspose.slides**‑coördinaat in pom.xml. Voeg de volgende repository toe op het tabblad repositories en de afhankelijkheid op het tabblad dependencies.

``` xml
<repository>
    <id>AsposeJavaAPI</id>
    <name>Aspose Java API</name>
    <url>https://releases.aspose.com/java/repo/</url>
</repository>

<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides</artifactId>
    <version>25.12</version>
    <classifier>jdk16</classifier>
</dependency>
```

### **Gereed**
Bouw het, nu kan het **aspose.slides**‑JAR worden opgehaald uit uw Maven‑lokale repository.

## **Bijdragen**
Als u een voorbeeld wilt toevoegen of verbeteren, moedigen wij u aan bij te dragen aan het project. Alle voorbeelden en showcase‑projecten in deze repository zijn open source en kunnen vrij worden gebruikt in uw eigen applicaties.

Om bij te dragen kunt u de repository forken, de broncode bewerken en een Pull Request indienen. Wij zullen de wijzigingen beoordelen en opnemen in de repository als ze nuttig zijn.