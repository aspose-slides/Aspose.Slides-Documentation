---
title: Installatie
type: docs
weight: 70
url: /nl/java/installation/
keywords:
- installeer Aspose.Slides
- download Aspose.Slides
- gebruik Aspose.Slides
- Aspose.Slides installatie
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Installeer Aspose.Slides for Java vanuit de Maven-repository van Aspose of als JAR-bestand, stel de Linux-vooraadstellingen in en controleer de installatie met een eerste programma."
---
## **Overzicht**

Dit artikel legt uit hoe u Aspose.Slides for Java aan een project kunt toevoegen. Aspose.Slides for Java wordt gepubliceerd in de eigen Maven‑repository van Aspose, niet in Maven Central, dus een Maven‑project moet die repository declareren. U kunt ook het JAR‑bestand downloaden en zelf aan het class‑path toevoegen. Beide routes eindigen met een klein programma dat bevestigt dat de bibliotheek werkt.

Aspose.Slides for Java vereist geen Microsoft PowerPoint. Het genereert programmatisch de benodigde presentatie‑bestanden. Om de gegenereerde presentaties te bekijken, heeft u echter Microsoft PowerPoint of een andere presentatie‑viewer nodig.

## **Vereisten**

- Een Java Development Kit (JDK). Het project en de commando's in dit artikel hebben JDK 11 of hoger nodig. Met JDK 11 geeft het programma dat de installatie controleert een waarschuwing die begint met “WARNING: An illegal reflective access operation has occurred”; dit heeft geen invloed op het resultaat en kan genegeerd worden.
- [Apache Maven](https://maven.apache.org/install.html), als u de Maven‑route gebruikt.
- Op Linux is de fontconfig‑bibliotheek en minstens één geïnstalleerd lettertype nodig. Zie [Linux](#linux).

## **Installeren vanuit de Maven‑repository**

Aspose host zijn Java‑bibliotheken in zijn eigen [Maven-repository](https://releases.aspose.com/java/repo/com/aspose/). Om [Aspose.Slides for Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) in een Maven‑project te gebruiken, voegt u twee items toe aan uw *pom.xml*.

1. **Declareer de Aspose Maven-repository.**

   ```xml
   <repositories>
       <repository>
           <id>AsposeJavaAPI</id>
           <name>Aspose Java API</name>
           <url>https://releases.aspose.com/java/repo/</url>
       </repository>
   </repositories>
   ```

2. **Voeg de Aspose.Slides for Java‑dependency toe.**

   ```xml
   <dependencies>
       <dependency>
           <groupId>com.aspose</groupId>
           <artifactId>aspose-slides</artifactId>
           <version>26.9</version>
           <classifier>jdk16</classifier>
       </dependency>
   </dependencies>
   ```

De `jdk16`‑classifier is vereist: hij selecteert de Java SE‑build van de bibliotheek. Vervang `26.9` door de meest recente versie die in de [repository](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) wordt vermeld. De repository publiceert een SHA‑1‑controlesom‑bestand naast elke JAR, die Maven controleert bij het downloaden van de bibliotheek.

### **Controleer de installatie**

Om de configuratie met een nieuw project te controleren:

1. Maak een map voor het project en sla dit *pom.xml* daarin op:

   ```xml
   <project xmlns="http://maven.apache.org/POM/4.0.0">
       <modelVersion>4.0.0</modelVersion>
       <groupId>com.example</groupId>
       <artifactId>hello-slides</artifactId>
       <version>1.0</version>

       <properties>
           <maven.compiler.release>11</maven.compiler.release>
           <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
           <exec.mainClass>HelloSlides</exec.mainClass>
       </properties>

       <repositories>
           <repository>
               <id>AsposeJavaAPI</id>
               <name>Aspose Java API</name>
               <url>https://releases.aspose.com/java/repo/</url>
           </repository>
       </repositories>

       <dependencies>
           <dependency>
               <groupId>com.aspose</groupId>
               <artifactId>aspose-slides</artifactId>
               <version>26.9</version>
               <classifier>jdk16</classifier>
           </dependency>
       </dependencies>

       <build>
           <plugins>
               <plugin>
                   <groupId>org.apache.maven.plugins</groupId>
                   <artifactId>maven-compiler-plugin</artifactId>
                   <version>3.15.0</version>
               </plugin>
           </plugins>
       </build>
   </project>
   ```

   Naast de repository en de dependency stelt dit *pom.xml* de Java‑release in waarop gecompileerd moet worden, geeft de klasse op die `mvn exec:java` uitvoert, en fixeert de compiler‑plugin, omdat de oudere plugin die sommige Maven‑installaties standaard gebruiken de instelling `maven.compiler.release` negeert.

2. Sla het eerste voorbeeld uit [Create Presentations](/slides/nl/java/create-presentation/) op als *src/main/java/HelloSlides.java*.

3. Voer in de projectmap uit:

   ```bash
   mvn compile exec:java
   ```

Maven download Aspose.Slides for Java, compileert het programma en voert het uit. Het programma slaat *new_presentation.pptx* op in de projectmap.

## **Gebruik het JAR‑bestand zonder Maven**

1. Download *aspose-slides-26.9-jdk16.jar* uit de [versiemap](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/26.9/) in de repository. Voor een andere versie opent u de map in de [repository](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) en downloadt u het bestand dat eindigt op *-jdk16.jar*.
2. Sla het eerste voorbeeld uit [Create Presentations](/slides/nl/java/create-presentation/) op als *HelloSlides.java* in dezelfde map als het JAR‑bestand.
3. Voer in die map uit:

   ```bash
   java -cp aspose-slides-26.9-jdk16.jar HelloSlides.java
   ```

De JDK compileert en voert het enkele bronbestand uit, en het programma slaat *new_presentation.pptx* op in de map. Voeg in uw eigen toepassing het JAR‑bestand toe aan het class‑path in uw build‑tool of IDE.

## **Linux**

Aspose.Slides for Java maakt gebruik van de lettertype‑ondersteuning van Java, die op Linux de fontconfig‑bibliotheek en minimaal één geïnstalleerd lettertype vereist. Zonder deze mislukt het opslaan van een presentatie met de fout “Fontconfig head is null, check your fonts or fonts configuration”. Minimale server‑ en container‑images kunnen beide missen; de officiële Ubuntu‑container‑image heeft bijvoorbeeld geen van beide.

Op Debian en Ubuntu installeert dit commando een JDK, Maven, fontconfig en de DejaVu‑lettertypen:

```bash
sudo apt-get update && sudo apt-get install -y default-jdk maven fontconfig fonts-dejavu-core
```

De lettertypen die in uw presentaties worden gebruikt, of geschikte vervangers, moeten eveneens geïnstalleerd zijn zodat tekst correct wordt weergegeven.

## **FAQ**

### Hoe kan ik verifiëren dat Aspose.Slides correct is geïntegreerd?

Bouw uw project, maak een lege [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) aan en sla deze op onder een nieuwe naam. Als het bestand wordt aangemaakt zonder uitzonderingen, is de bibliotheek succesvol geïntegreerd.

### Hoe kan ik het geheugenverbruik beperken bij het verwerken van grote presentaties?

Verhoog de JVM‑geheugenlimieten alleen zoveel als nodig is, en roep [dispose](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#dispose--) aan op elke [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)‑instantie in een `finally`‑blok om de cache onmiddellijk vrij te geven. Dit voorkomt out‑of‑memory‑fouten en houdt het algehele geheugenverbruik voorspelbaar tijdens batch‑operaties.

### Kan ik ongewenste exportformaten uitsluiten om de uiteindelijke JAR‑grootte te verkleinen?

Huidige Aspose.Slides‑releases worden geleverd als één monolithische bibliotheek, dus u kunt specifieke exporteurs zoals PDF of SVG niet uitschakelen tijdens het bouwen.