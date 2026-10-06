---
title: Kör Aspose.Slides för Java i Docker
linktitle: Docker
type: docs
weight: 150
url: /sv/java/how-to-run-aspose-slides-in-docker/
keywords:
- Docker
- Dockerfile
- Docker-behållare
- flerstegsbyggnad
- container-image
- Eclipse Temurin
- Maven
- Linux
- Ubuntu
- Alpine
- Debian
- fontconfig
- teckensnitt
- PDF-konvertering
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Bygg och kör en Aspose.Slides för Java-applikation i Docker: en flerstegs‑Dockerfile på de officiella Maven‑ och Eclipse‑Temurin‑bilderna, Linux‑biblioteken och teckensnitten som Aspose.Slides behöver, samt hur du kopierar de genererade filerna till din maskin."
---
## **Översikt**

Denna artikel visar hur du kör Aspose.Slides for Java i en Docker‑behållare. Du bygger ett litet Maven‑projekt som skapar en presentation med en textruta och konverterar den till PDF, paketerar den med en flerstegs‑Dockerfile på de officiella Maven‑ och Eclipse‑Temurin‑bilderna, kör den och kopierar de genererade filerna till din maskin. Artikeln förklarar också vad Aspose.Slides behöver i en Linux‑image förutom Java, och avslutas med varianter för Alpine Linux samt för bilder som installerar Java från distributionens paket.

Du behöver bara Docker på din maskin. JDK och Maven ingår i bygg‑imagen, så du behöver inte installera dem. För att installera Docker, se [Get Docker](https://docs.docker.com/get-started/get-docker/).

## **Välj basimage**

Dockerfilen i den här artikeln använder två officiella images från Docker Hub:

- [maven](https://hub.docker.com/_/maven) med taggen `3.9-eclipse-temurin-21` bygger applikationen. Den innehåller Apache Maven 3.9 och Eclipse Temurin JDK 21.
- [eclipse-temurin](https://hub.docker.com/_/eclipse-temurin) med taggen `21-jre` kör den. Den innehåller Eclipse Temurin Java 21‑runtime på Ubuntu, utan JDK och Maven.

Aspose.Slides for Java ritar text med Javas teckensnittsstöd, vilket på Linux kräver biblioteken fontconfig och FreeType samt minst ett installerat teckensnitt. Eclipse Temurin‑bilderna innehåller redan fontconfig, FreeType och DejaVu‑teckensnitten, så Dockerfilen i den här artikeln installerar inga paket. I en image utan några teckensnitt stoppas sparandet av en presentation med felmeddelandet "Fontconfig head is null, check your fonts or fonts configuration". Om du bygger på en annan basimage, se [Use Another Base Image](#use-another-base-image).

## **Skapa projektet**

Skapa en mapp med namnet *hello-slides-docker* och lägg till följande filer i den.

*pom.xml* deklarerar Asposes Maven‑repository och Aspose.Slides for Java‑beroendet, som beskrivs i [Installation](/slides/sv/java/installation/); Aspose.Slides for Java publiceras inte i Maven Central, så repository‑posten krävs. `finalName`‑elementet ger applikationens JAR‑fil namn *hello-slides.jar*, och [maven-dependency-plugin](https://maven.apache.org/plugins/maven-dependency-plugin/) kopierar applikationens beroenden till *target/lib* när Maven paketerar den. Ställ in Aspose.Slides‑versionen till den senaste som listas i [repository](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/).

```xml
<project xmlns="http://maven.apache.org/POM/4.0.0">
    <modelVersion>4.0.0</modelVersion>
    <groupId>com.example</groupId>
    <artifactId>hello-slides</artifactId>
    <version>1.0</version>

    <properties>
        <maven.compiler.release>11</maven.compiler.release>
        <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
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
        <finalName>hello-slides</finalName>
        <plugins>
            <plugin>
                <groupId>org.apache.maven.plugins</groupId>
                <artifactId>maven-compiler-plugin</artifactId>
                <version>3.15.0</version>
            </plugin>
            <plugin>
                <groupId>org.apache.maven.plugins</groupId>
                <artifactId>maven-dependency-plugin</artifactId>
                <version>3.11.0</version>
                <executions>
                    <execution>
                        <phase>package</phase>
                        <goals>
                            <goal>copy-dependencies</goal>
                        </goals>
                        <configuration>
                            <outputDirectory>${project.build.directory}/lib</outputDirectory>
                        </configuration>
                    </execution>
                </executions>
            </plugin>
        </plugins>
    </build>
</project>
```

*src/main/java/HelloSlides.java* skapar en [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/), lägger till en rektangel med text på den första bilden, och sparar presentationen två gånger med [save](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#save-java.lang.String-int-)‑metoden: som PPTX och som PDF. Båda filerna placeras i *output*-mappen under arbetskatalogen. Programmet listar sedan de teckensnitt som Aspose.Slides ersätter när den renderar presentationen, med hjälp av [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ifontsmanager/#getSubstitutions--), så du kan se om containern har de teckensnitt som presentationen använder.

```java
import com.aspose.slides.*;
import java.io.File;

public class HelloSlides {
    public static void main(String[] args) {
        File outputFolder = new File("output");
        outputFolder.mkdirs();

        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            shape.getTextFrame().setText("Hello from a Docker container!");

            String pptxPath = new File(outputFolder, "hello.pptx").getPath();
            String pdfPath = new File(outputFolder, "hello.pdf").getPath();
            presentation.save(pptxPath, SaveFormat.Pptx);
            presentation.save(pdfPath, SaveFormat.Pdf);

            for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions()) {
                System.out.println("Font substitution: " + substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
            }

            System.out.println("Saved " + pptxPath + " and " + pdfPath);
        } finally {
            presentation.dispose();
        }
    }
}
```

*.dockerignore* håller *target*-mappen från en lokal bygning och utdata från tidigare körningar utanför Docker‑byggkontexten, så att imagen byggs endast från källfilerna.

```text
target/
output/
```

## **Skriv Dockerfilen**

Lägg till en fil med namnet *Dockerfile* i *hello-slides-docker*-mappen:

```dockerfile
FROM maven:3.9-eclipse-temurin-21 AS build
WORKDIR /src
COPY pom.xml .
RUN mvn -B dependency:go-offline
COPY src ./src
RUN mvn -B package

FROM eclipse-temurin:21-jre
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN mkdir output && chown ubuntu output
USER ubuntu
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

Filen har två steg:

- **Byggsteget** startar från Maven‑imagen. Det kopierar först *pom.xml* och kör `mvn dependency:go-offline`, vilket hämtar Aspose.Slides for Java och Maven‑plugins, så Docker återanvänder det lagret så länge *pom.xml* inte ändras. Därefter kopieras källkoden och `mvn package` körs, vilket kompilerar programmet till *target/hello-slides.jar* och kopierar Aspose.Slides‑JAR‑filen till *target/lib*. `-B`‑alternativet kör Maven i icke‑interaktivt (batch) läge.
- **Körningssteget** startar från den mindre Java‑runtime‑imagen och kopierar endast applikations‑JAR‑filen och *lib*-mappen. Det skapar *output*-mappen, ger den till `ubuntu`, den icke‑root‑användare som Ubuntu‑baserade imagen definierar, och kör applikationen som den användaren. Klassvägen `hello-slides.jar:lib/*` innehåller applikationen och varje JAR‑fil i *lib*; Java expanderar `*` själv.

Projektet kompileras för Java 11 (`maven.compiler.release`‑egenskapen), så körningssteget kan använda en nyare Java‑version. Till exempel, för att köra applikationen på Java 25, ändra imagen för körningssteget till `eclipse-temurin:25-jre`.

## **Bygg och kör containern**

Öppna en terminal i *hello-slides-docker*-mappen. Bygg imagen, och kör sedan en container från den:

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

Den första bygget laddar ned basbilderna, Maven‑plugins och Aspose.Slides for Java, så det tar flera minuter; senare byggen återanvänder dem. Containern kör applikationen och stoppas. Den skriver ut:

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

Den första raden visar att texten använder Calibri, standardteckensnittet för en ny presentation, och att Calibri inte är installerat i imagen, så Aspose.Slides ritade texten med DejaVu Sans. Texten i PDF‑filen är äkta, markerbar text i det teckensnittet. Utan licens lägger Aspose.Slides även till ett utvärderings‑vattenstämpel på varje bild den sparar; se [Licensing](/slides/sv/java/licensing/).

## **Kopiera utdata till din maskin**

Filerna finns i */app/output*-mappen i den stoppade containern. Kopiera dem till en *output*-mapp på din maskin, och ta sedan bort containern:

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

Dessa två kommandon fungerar på samma sätt i Bash, PowerShell och Windows Command Prompt.

På Linux kan du istället montera en mapp från din maskin i containern, så att applikationen skriver sina filer där direkt:

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

`--user`‑alternativet kör applikationen med ditt användar‑ och grupp‑ID, så den kan skriva till mappen du skapade och filerna tillhör dig. `--rm` tar bort containern när den stoppas.

## **Kör på Alpine Linux**

Eclipse Temurin finns också som en image baserad på Alpine Linux, som är mindre. Den innehåller också fontconfig, FreeType och DejaVu‑teckensnitten, så applikationen behöver inga ytterligare paket där heller. För att använda den, ersätt körningssteget i *Dockerfile* (allt från den andra `FROM`‑raden) med:

```dockerfile
FROM eclipse-temurin:21-jre-alpine
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN adduser -D app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

Alpine‑imagen har ingen `ubuntu`‑användare, så detta steg skapar en användare som heter `app` med `adduser` och kör applikationen som den användaren. Bygg, kör och kopiera utdata med samma kommandon som ovan. Applikationen skriver ut samma två rader.

## **Använd en annan basimage**

Om din image installerar Java från distributionens paket istället, installera Javas teckensnittsbibliotek och ett teckensnitt tillsammans med dem. På Debian och Ubuntu listas `openjdk-21-jre-headless`‑paketet fontconfig, FreeType och HarfBuzz endast som rekommenderade paket, så `apt-get install --no-install-recommends` utesluter dem, och applikationen stoppas med ett `UnsatisfiedLinkError` för `libfontmanager.so`. Detta körningssteg installerar Java 21, biblioteken och DejaVu‑teckensnitten på Debian 13, och skapar en icke‑root‑användare som heter `app`:

```dockerfile
FROM debian:trixie
RUN apt-get update \
    && apt-get install -y --no-install-recommends openjdk-21-jre-headless libfontconfig1 libfreetype6 libharfbuzz0b fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN useradd --create-home app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

Samma steg fungerar på Ubuntu 26.04 med `FROM ubuntu:26.04`.

## **FAQ**

**Sparandet av presentationen stoppas med "Fontconfig head is null, check your fonts or fonts configuration". Vad saknas?**

Ett teckensnitt. Javas teckensnittsstöd hittade inget installerat teckensnitt i imagen. Installera ett teckensnittspaket, till exempel `fonts-dejavu-core` på Debian och Ubuntu, enligt [Use Another Base Image](#use-another-base-image). [Deploy Fonts](/slides/sv/java/deploy-fonts/) listar andra teckensnittspaket.

**Applikationen stoppas med ett UnsatisfiedLinkError för libfontmanager.so. Vad saknas?**

Ett native‑bibliotek för Javas teckensnittsstöd; meddelandet nämner filen som inte kunde laddas, till exempel `libharfbuzz.so.0`. Detta händer när Java installeras från distributionens paket utan deras rekommenderade paket. Installera biblioteken som listas i [Use Another Base Image](#use-another-base-image).

**Varför är texten i PDF‑filen i ett annat teckensnitt än i PowerPoint?**

Teckensnitten som presentationen använder är inte installerade i imagen, så Aspose.Slides ritar texten med ett ersättnings­teckensnitt. Applikationens utdata listar varje ersatt teckensnitt. [Deploy Fonts](/slides/sv/java/deploy-fonts/) förklarar hur du installerar teckensnitt i imagen eller laddar dem från applikationsmappen.

**Hur mycket minne kan applikationen använda i containern?**

Som standard begränsar Java sin heap till en fjärdedel av det minne som är tillgängligt för containern, till exempel till cirka 250 MB när du startar containern med `docker run -m 1g`. För att bearbeta stora presentationer, höj andelen med `MaxRAMPercentage`‑alternativet, till exempel `docker run --rm -m 1g -e JAVA_TOOL_OPTIONS=-XX:MaxRAMPercentage=75 hello-slides`. Java skriver då ut en rad "Picked up JAVA_TOOL_OPTIONS" innan applikationens utdata.

**Behöver jag ett JDK eller Maven på min maskin?**

Nej. Byggsteget kompilerar applikationen inne i Maven‑imagen. Du behöver ett JDK och Maven endast om du också vill bygga och köra applikationen utanför Docker; se [Installation](/slides/sv/java/installation/).