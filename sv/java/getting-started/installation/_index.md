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
description: "Installera Aspose.Slides för Java från Asposes Maven-förråd eller som en JAR-fil, installera Linux-förutsättningarna och kontrollera installationen med ett första program."
---
## **Översikt**

Denna artikel förklarar hur du lägger till Aspose.Slides for Java i ett projekt. Aspose.Slides for Java publiceras i Asposes egna Maven-repo, inte i Maven Central, så ett Maven-projekt måste deklarera det repositoriet. Du kan också ladda ner JAR-filen och lägga den på klass-sökvägen själv. Båda vägarna avslutas med ett litet program som bekräftar att biblioteket fungerar.

Aspose.Slides for Java kräver inte Microsoft PowerPoint. Det genererar programatiskt de nödvändiga presentationsfilerna. För att visa de genererade presentationerna kan du dock behöva Microsoft PowerPoint eller en annan presentationsvisare.

## **Förutsättningar**

- Ett Java Development Kit (JDK). Projektet och kommandona i den här artikeln kräver JDK 11 eller senare. På JDK 11 skriver programmet som kontrollerar installationen ut en varning som börjar med "WARNING: An illegal reflective access operation has occurred"; den påverkar inte resultatet och kan ignoreras.
- [Apache Maven](https://maven.apache.org/install.html), om du använder Maven-vägen.
- På Linux krävs fontconfig-biblioteket och minst ett installerat teckensnitt. Se [Linux](#linux).

## **Installera från Maven-förrådet**

Aspose lagrar sina Java-bibliotek i sitt eget [Maven-förråd](https://releases.aspose.com/java/repo/com/aspose/). För att använda [Aspose.Slides for Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) i ett Maven-projekt, lägg till två poster i din *pom.xml*.

1. **Deklarera Aspose Maven-repo.**

   ```xml
   <repositories>
       <repository>
           <id>AsposeJavaAPI</id>
           <name>Aspose Java API</name>
           <url>https://releases.aspose.com/java/repo/</url>
       </repository>
   </repositories>
   ```

2. **Lägg till Aspose.Slides for Java-beroendet.**

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

`jdk16`-klassificeraren krävs: den väljer Java-SE-bygget av biblioteket. Ersätt `26.9` med den senaste versionen som listas i [förrådet](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). Förrådet publicerar en SHA-1-kontrollsummefil bredvid varje JAR, som Maven kontrollerar när det laddar ner biblioteket.

### **Kontrollera installationen**

För att kontrollera installationen med ett nytt projekt:

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

   Förutom repositoriet och beroendet anger denna *pom.xml* vilken Java-version som ska kompileras för, namnger klassen som `mvn exec:java` kör, och låser kompilator-pluginet, eftersom det äldre pluginet som vissa Maven-installationer använder som standard ignorerar inställningen `maven.compiler.release`.

2. Spara det första exemplet i [Create Presentations](/slides/sv/java/create-presentation/) som *src/main/java/HelloSlides.java*.

3. I projektmappen, kör:

   ```bash
   mvn compile exec:java
   ```

Maven laddar ner Aspose.Slides for Java, kompilerar programmet och kör det. Programmet sparar *new_presentation.pptx* i projektmappen.

## **Använd JAR-filen utan Maven**

1. Ladda ner *aspose-slides-26.9-jdk16.jar* från [versionsmappen](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/26.9/) i förrådet. För en annan version, öppna dess mapp i [förrådet](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) och ladda ner filen som slutar på *-jdk16.jar*.

2. Spara det första exemplet i [Create Presentations](/slides/sv/java/create-presentation/) som *HelloSlides.java* i samma mapp som JAR-filen.

3. I den mappen, kör:

   ```bash
   java -cp aspose-slides-26.9-jdk16.jar HelloSlides.java
   ```

JDK:n kompilerar och kör den enda källfilen, och programmet sparar *new_presentation.pptx* i mappen. I ditt eget program, lägg till JAR-filen på klass-sökvägen i ditt byggverktyg eller IDE.

## **Linux**

Aspose.Slides for Java använder Javas typsnittsstöd, vilket på Linux kräver fontconfig-biblioteket och minst ett installerat teckensnitt. Utan dem misslyckas sparandet av en presentation med felet "Fontconfig head is null, check your fonts or fonts configuration". Minimala server- och container-bilder kan sakna båda; den officiella Ubuntu-container-bilden har t.ex. ingen av dem.

På Debian och Ubuntu installerar detta kommando ett JDK, Maven, fontconfig och DejaVu-teckensnitten:

```bash
   sudo apt-get update && sudo apt-get install -y default-jdk maven fontconfig fonts-dejavu-core
```

Teckensnitten som används i dina presentationer, eller lämpliga ersättningar, måste också vara installerade för att texten ska renderas korrekt.

## **FAQ**

### Hur kan jag verifiera att Aspose.Slides är korrekt integrerat?

Bygg ditt projekt, skapa en tom [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/) och spara den under ett nytt namn. Om filen skapas utan att kasta undantag har biblioteket integrerats framgångsrikt.

### Hur kan jag begränsa minnesförbrukningen när jag bearbetar stora presentationer?

Höj JVM-minnesgränserna bara så högt som behövs, och anropa [dispose](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#dispose--) på varje [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/)-instans i ett `finally`-block för att frigöra cachen omedelbart. Detta förhindrar out-of-memory-fel och håller det totala minnesbruket förutsägbart under batch-operationer.

### Kan jag exkludera oönskade exportformat för att minska den slutliga JAR-storleken?

Nuvarande Aspose.Slides-utgåvor levereras som ett enda monolitiskt bibliotek, så du kan inte inaktivera specifika exportörer såsom PDF eller SVG vid kompilering.