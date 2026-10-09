---
title: Installation
type: docs
weight: 70
url: /sv/java/installation/
keywords:
- installera Aspose.Slides
- ladda ner Aspose.Slides
- använd Aspose.Slides
- installation av Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Installera Aspose.Slides för Java från Asposes Maven-arkiv eller som en JAR-fil, installera Linux-förutsättningarna och kontrollera installationen med ett första program."
---
## **Översikt**

Denna artikel förklarar hur man lägger till Aspose.Slides for Java i ett projekt. Aspose.Slides for Java publiceras i Asposes eget Maven‑arkiv, inte i Maven Central, så ett Maven‑projekt måste deklarera det arkivet. Du kan också ladda ner JAR‑filen och lägga den på klassökvägen själv. Båda vägarna avslutas med ett kort program som bekräftar att biblioteket fungerar.

Aspose.Slides for Java kräver inte Microsoft PowerPoint. Det genererar programatiskt de nödvändiga presentationsfilerna. För att visa de genererade presentationerna kan du dock behöva Microsoft PowerPoint eller en annan presentationsvisare.

## **Förutsättningar**

- Ett Java Development Kit (JDK). Projektet och kommandona i den här artikeln kräver JDK 11 eller senare. På JDK 11 skriver programmet som kontrollerar installationen ut en varning som börjar med "WARNING: An illegal reflective access operation has occurred"; den påverkar inte resultatet och kan ignoreras.
- [Apache Maven](https://maven.apache.org/install.html), om du använder Maven‑vägen.
- På Linux krävs fontconfig‑biblioteket och minst ett installerat teckensnitt. Se [Linux](#linux).

## **Installera från Maven‑arkivet**

Aspose är värd för sina Java‑bibliotek i sitt eget [Maven‑arkiv](https://releases.aspose.com/java/repo/com/aspose/). För att använda [Aspose.Slides for Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) i ett Maven‑project, lägg till två poster i din *pom.xml*.

1. **Deklarera Aspose Maven‑arkivet.**

   ```xml
   <repositories>
       <repository>
           <id>AsposeJavaAPI</id>
           <name>Aspose Java API</name>
           <url>https://releases.aspose.com/java/repo/</url>
       </repository>
   </repositories>
   ```

2. **Lägg till Aspose.Slides for Java‑beroendet.**

   ```xml
   <dependencies>
       <dependency>
           <groupId>com.aspose</groupId>
           <artifactId>aspose-slides</artifactId>
           <version>26.10</version>
           <classifier>jdk8</classifier>
       </dependency>
   </dependencies>
   ```

`jdk8`‑klassificeraren är obligatorisk: den väljer Java SE‑byggnaden av biblioteket. Ersätt `26.10` med den senaste version som listas i [arkivet](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). Arkivet publicerar en SHA‑1‑kontrollsummefil bredvid varje JAR, som Maven kontrollerar när det laddar ner biblioteket.

### **Kontrollera installationen**

För att kontrollera konfigurationen med ett nytt projekt:

1. Skapa en mapp för projektet och spara denna *pom.xml* i den:

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
               <version>26.10</version>
               <classifier>jdk8</classifier>
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

   Förutom arkivet och beroendet anger denna *pom.xml* vilken Java‑version som ska kompileras för, namnger klassen som `mvn exec:java` kör, och låser kompilator‑pluginet, eftersom det äldre pluginet som vissa Maven‑installationer använder som standard ignorerar inställningen `maven.compiler.release`.

2. Spara det första exemplet i [Skapa presentationer](/slides/sv/java/create-presentation/) som *src/main/java/HelloSlides.java*.

3. Kör i projektmappen:

   ```bash
   mvn compile exec:java
   ```

Maven laddar ner Aspose.Slides for Java, kompilerar programmet och kör det. Programmet sparar *new_presentation.pptx* i projektmappen.

## **Använd JAR‑filen utan Maven**

1. Ladda ner *aspose-slides-26.10-jdk8.jar* från [versionsmappen](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/26.10/) i arkivet. För en annan version, öppna dess mapp i [arkivet](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) och ladda ner filen som slutar på *-jdk8.jar*.
2. Spara det första exemplet i [Skapa presentationer](/slides/sv/java/create-presentation/) som *HelloSlides.java* i samma mapp som JAR‑filen.
3. Kör i den mappen:

   ```bash
   java -cp aspose-slides-26.10-jdk8.jar HelloSlides.java
   ```

JDK kompilerar och kör den enkla källkodsfilen, och programmet sparar *new_presentation.pptx* i mappen. I ditt eget program, lägg till JAR‑filen på klassökvägen i ditt byggverktyg eller IDE.

## **Linux**

Aspose.Slides for Java använder Javas teckensnittsstöd, vilket på Linux kräver fontconfig‑biblioteket och minst ett installerat teckensnitt. Utan dem misslyckas sparandet av en presentation med felet "Fontconfig head is null, check your fonts or fonts configuration". Minimala server‑ och container‑avbildningar kan sakna båda; den officiella Ubuntu‑containeravbildningen har till exempel ingen av dem.

På Debian och Ubuntu installerar detta kommando ett JDK, Maven, fontconfig och DejaVu‑teckensnitten:

```bash
sudo apt-get update && sudo apt-get install -y default-jdk maven fontconfig fonts-dejavu-core
```

Teckensnitten som används i dina presentationer, eller lämpliga ersättningar, måste också vara installerade för att texten ska renderas korrekt.

## **FAQ**

### Hur kan jag verifiera att Aspose.Slides är korrekt integrerat?

Bygg ditt projekt, skapa en tom [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) och spara den under ett nytt namn. Om filen skapas utan att kasta undantag har biblioteket integrerats framgångsrikt.

### Hur kan jag begränsa minnesanvändning när jag behandlar stora presentationer?

Höj JVM‑minnesgränserna bara så högt som behövs, och anropa [dispose](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#dispose--) på varje [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)‑instans i ett `finally`‑block för att frigöra cachen omedelbart. Detta förhindrar out‑of‑memory‑fel och håller den totala minnesanvändningen förutsägbar under batch‑operationer.

### Kan jag utesluta oönskade exportformat för att minska den slutgiltiga JAR‑storleken?

Aktuella Aspose.Slides‑utgåvor levereras som ett enda monolitiskt bibliotek, så du kan inte inaktivera specifika exportörer som PDF eller SVG vid bygget.