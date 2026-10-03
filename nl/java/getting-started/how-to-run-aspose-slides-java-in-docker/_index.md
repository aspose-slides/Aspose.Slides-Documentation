---
title: Run Aspose.Slides for Java in Docker
linktitle: Docker
type: docs
weight: 150
url: /nl/java/how-to-run-aspose-slides-in-docker/
keywords:
- Docker
- Dockerfile
- Docker‑container
- multi‑stage‑build
- container‑image
- Eclipse Temurin
- Maven
- Linux
- Ubuntu
- Alpine
- Debian
- fontconfig
- lettertypen
- PDF‑conversie
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Bouw en voer een Aspose.Slides voor Java‑applicatie uit in Docker: een multi‑stage Dockerfile op de officiële Maven‑ en Eclipse Temurin‑images, de Linux‑bibliotheken en lettertypen die Aspose.Slides nodig heeft, en hoe u de gegenereerde bestanden naar uw machine kopieert."
---
## **Overzicht**

Dit artikel laat zien hoe u Aspose.Slides voor Java in een Docker‑container kunt uitvoeren. U bouwt een klein Maven‑project dat een presentatie maakt met een tekstvak en deze converteert naar PDF, verpakt het met een multi‑stage Dockerfile op de officiële Maven‑ en Eclipse Temurin‑images, voert het uit en kopieert de gegenereerde bestanden naar uw machine. Het artikel legt ook uit wat Aspose.Slides nodig heeft in een Linux‑image naast Java, en eindigt met varianten voor Alpine Linux en voor images die Java installeren vanuit de pakketten van de distributie.

U heeft alleen Docker op uw machine nodig. De JDK en Maven maken deel uit van de build‑image, zodat u ze niet hoeft te installeren. Om Docker te installeren, zie [Get Docker](https://docs.docker.com/get-started/get-docker/).

## **Kies de basis‑images**

De Dockerfile in dit artikel gebruikt twee officiële images van Docker Hub:

- [maven](https://hub.docker.com/_/maven) met de tag `3.9-eclipse-temurin-21` bouwt de applicatie. Het bevat Apache Maven 3.9 en de Eclipse Temurin JDK 21.
- [eclipse-temurin](https://hub.docker.com/_/eclipse-temurin) met de tag `21-jre` voert deze uit. Het bevat de Eclipse Temurin Java 21 runtime op Ubuntu, zonder de JDK en Maven.

Aspose.Slides voor Java tekent tekst met de fontondersteuning van Java, die op Linux de fontconfig‑ en FreeType‑bibliotheken en minstens één geïnstalleerd lettertype nodig heeft. De Eclipse Temurin‑images bevatten al fontconfig, FreeType en de DejaVu‑fonts, dus de Dockerfile in dit artikel installeert geen extra pakketten. In een image zonder fonts stopt het opslaan van een presentatie met de fout “Fontconfig head is null, check your fonts or fonts configuration”. Als u op een andere basis‑image bouwt, zie [Use Another Base Image](#use-another-base-image).

## **Maak het project**

Maak een map met de naam *hello-slides-docker* en voeg de volgende bestanden toe.

*pom.xml* declareert Aspose’s Maven‑repository en de Aspose.Slides voor Java‑dependency, zoals beschreven in [Installation](/slides/nl/java/installation/); Aspose.Slides voor Java wordt niet gepubliceerd in Maven Central, dus het repository‑item is vereist. Het `finalName`‑element noemt het applicatie‑JAR‑bestand *hello-slides.jar*, en de [maven-dependency-plugin](https://maven.apache.org/plugins/maven-dependency-plugin/) kopieert de afhankelijkheden van de applicatie naar *target/lib* wanneer Maven het verpakt. Stel de Aspose.Slides‑versie in op de nieuwste die in de [repository](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) staat.

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

*src/main/java/HelloSlides.java* maakt een [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/), voegt een rechthoek met tekst toe aan de eerste dia, en slaat de presentatie twee keer op met de [save](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#save-java.lang.String-int-)‑methode: als PPTX en als PDF. Beide bestanden worden geplaatst in de *output*‑map onder de werkmap. Het programma somt vervolgens de fonts op die Aspose.Slides vervangt bij het renderen van de presentatie, met behulp van [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifontsmanager/#getSubstitutions--), zodat u kunt zien of de container de fonts bevat die de presentatie gebruikt.

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

*.dockerignore* houdt de *target*‑map van een lokale build, en de output van eerdere runs, buiten de Docker‑build‑context, zodat de image alleen van de bronbestanden wordt gebouwd.

```text
target/
output/
```

## **Schrijf de Dockerfile**

Voeg een bestand met de naam *Dockerfile* toe aan de *hello-slides-docker*‑map:

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

Het bestand heeft twee stadia:

- **Het build‑stadium** start vanaf de Maven‑image. Het kopieert eerst *pom.xml* en voert `mvn dependency:go-offline` uit, waardoor Aspose.Slides voor Java en de Maven‑plugins worden gedownload, zodat Docker die laag hergebruikt zolang *pom.xml* niet verandert. Vervolgens kopieert het de broncode en voert `mvn package` uit, waardoor het programma wordt gecompileerd naar *target/hello-slides.jar* en het Aspose.Slides‑JAR‑bestand naar *target/lib* wordt gekopieerd. De `-B`‑optie draait Maven in niet‑interactieve (batch) modus.
- **Het runtime‑stadium** start vanaf de kleinere Java‑runtime‑image en kopieert alleen het applicatie‑JAR‑bestand en de *lib*‑map. Het maakt de *output*‑map aan, geeft deze aan `ubuntu`, de niet‑rootgebruiker die de Ubuntu‑gebaseerde image definieert, en draait de applicatie als die gebruiker. Het class‑path `hello-slides.jar:lib/*` bevat de applicatie en elk JAR‑bestand in *lib*; Java breidt het `*` zelf uit.

Het project wordt gecompileerd voor Java 11 (de `maven.compiler.release`‑property), zodat het runtime‑stadium een nieuwere Java‑versie kan gebruiken. Bijvoorbeeld, om de applicatie op Java 25 uit te voeren, wijzig de image van het runtime‑stadium naar `eclipse-temurin:25-jre`.

## **Bouw en voer de container uit**

Open een terminal in de *hello-slides-docker*‑map. Bouw de image en start daarna een container ervan:

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

De eerste build downloadt de basis‑images, de Maven‑plugins en Aspose.Slides voor Java, dus dit duurt enkele minuten; latere builds hergebruiken ze. De container draait de applicatie en stopt. Hij print:

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

De eerste regel laat zien dat de tekst Calibri gebruikt, het standaardfont van een nieuwe presentatie, en dat Calibri niet is geïnstalleerd in de image, zodat Aspose.Slides de tekst tekende met DejaVu Sans. De tekst in de PDF is echte, selecteerbare tekst in dat font. Zonder licentie voegt Aspose.Slides ook een evaluatiewatermerk toe aan elke dia die hij opslaat; zie [Licensing](/slides/nl/java/licensing/).

## **Kopieer de output naar uw machine**

De bestanden staan in de */app/output*‑map van de gestopte container. Kopieer ze naar een *output*‑map op uw machine en verwijder daarna de container:

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

Deze twee commando’s werken hetzelfde in Bash, PowerShell en de Windows Command Prompt.

Op Linux kunt u in plaats daarvan een map van uw machine in de container mounten, zodat de applicatie direct daarheen schrijft:

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

De `--user`‑optie draait de applicatie met uw user‑ en group‑ID’s, zodat hij naar de map kan schrijven die u hebt aangemaakt en de bestanden van u zijn. `--rm` verwijdert de container wanneer hij stopt.

## **Uitvoeren op Alpine Linux**

Eclipse Temurin is ook beschikbaar als een image gebaseerd op Alpine Linux, die kleiner is. Deze bevat ook fontconfig, FreeType en de DejaVu‑fonts, dus de applicatie heeft daar geen extra pakketten nodig. Om hem te gebruiken, vervangt u het runtime‑stadium in *Dockerfile* (alles vanaf de tweede `FROM`‑regel) door:

```dockerfile
FROM eclipse-temurin:21-jre-alpine
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN adduser -D app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

De Alpine‑image heeft geen `ubuntu`‑gebruiker, dus dit stadium maakt een gebruiker genaamd `app` aan met `adduser` en draait de applicatie als die gebruiker. Bouw, voer uit en kopieer de output met dezelfde commando’s als hierboven. De applicatie print dezelfde twee regels.

## **Gebruik een andere basis‑image**

Installeert uw image Java vanuit de pakketten van de Linux‑distributie, installeer dan de font‑bibliotheken van Java en een font tegelijk. Op Debian en Ubuntu vermeldt het pakket `openjdk-21-jre-headless` alleen fontconfig, FreeType en HarfBuzz als aanbevolen pakketten, dus `apt-get install --no-install-recommends` laat ze weg, en de applicatie stopt met een `UnsatisfiedLinkError` voor `libfontmanager.so`. Dit runtime‑stadium installeert Java 21, de bibliotheken en de DejaVu‑fonts op Debian 13, en maakt een niet‑rootgebruiker genaamd `app` aan:

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

Hetzelfde stadium werkt op Ubuntu 26.04 met `FROM ubuntu:26.04`.

## **FAQ**

**Het opslaan van de presentatie stopt met “Fontconfig head is null, check your fonts or fonts configuration”. Wat ontbreekt er?**

Een font. De fontondersteuning van Java heeft geen geïnstalleerd font in de image gevonden. Installeer een font‑pakket, bijvoorbeeld `fonts-dejavu-core` op Debian en Ubuntu, zoals in [Use Another Base Image](#use-another-base-image). [Deploy Fonts](/slides/nl/java/deploy-fonts/) somt andere font‑pakketten op.

**De applicatie stopt met een UnsatisfiedLinkError voor libfontmanager.so. Wat ontbreekt er?**

Een native bibliotheek van Java’s fontondersteuning; het bericht noemt het bestand dat niet kon worden geladen, bijvoorbeeld `libharfbuzz.so.0`. Dit gebeurt wanneer Java wordt geïnstalleerd vanuit de distributiepakketten zonder de aanbevolen pakketten. Installeer de bibliotheken die genoemd worden in [Use Another Base Image](#use-another-base-image).

**Waarom is de tekst in de PDF in een ander font dan in PowerPoint?**

De fonts die de presentatie gebruikt, zijn niet geïnstalleerd in de image, dus Aspose.Slides tekent de tekst met een vervangend font. De output van de applicatie benoemt elk vervangen font. [Deploy Fonts](/slides/nl/java/deploy-fonts/) legt uit hoe u fonts in de image installeert of laadt vanuit de applicatiemap.

**Hoeveel geheugen mag de applicatie gebruiken in de container?**

Standaard beperkt Java de heap tot een kwart van het beschikbare geheugen van de container, bijvoorbeeld tot ongeveer 250 MB wanneer u de container start met `docker run -m 1g`. Om grote presentaties te verwerken, verhoogt u het aandeel met de `MaxRAMPercentage`‑optie, bijvoorbeeld `docker run --rm -m 1g -e JAVA_TOOL_OPTIONS=-XX:MaxRAMPercentage=75 hello-slides`. Java print dan een “Picked up JAVA_TOOL_OPTIONS”‑regel vóór de output van de applicatie.

**Heb ik een JDK of Maven nodig op mijn machine?**

Nee. Het build‑stadium compileert de applicatie binnen de Maven‑image. U heeft een JDK en Maven alleen nodig als u de applicatie ook buiten Docker wilt bouwen en uitvoeren; zie [Installation](/slides/nl/java/installation/).