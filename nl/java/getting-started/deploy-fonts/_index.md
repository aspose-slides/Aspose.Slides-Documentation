---
title: Lettertypen implementeren voor Aspose.Slides for Java op Linux en in Docker
linktitle: Lettertypen implementeren
type: docs
weight: 155
url: /nl/java/deploy-fonts/
keywords:
- lettertypen implementeren
- lettertypen installeren
- lettertypen in Docker
- lettertypen op Linux
- ontbrekende lettertypen
- lettertypevervanging
- Microsoft core-lettertypen
- ttf-mscorefonts-installer
- aangepaste lettertypen
- standaardlettertype
- server
- container
- PDF-conversie
- presentatie
- Java
- Aspose.Slides
description: "Lettertypen implementeren voor Aspose.Slides for Java op Linux-servers en in Docker-containers: controleer welke lettertypen worden vervangen, installeer lettertype-pakketten op Debian, Ubuntu en Alpine, voeg uw eigen lettertypebestanden toe en stel een standaardlettertype in."
---
## **Overzicht**

Aspose.Slides tekent tekst met de lettertypen die beschikbaar zijn wanneer een presentatie wordt gerenderd, bijvoorbeeld bij het omzetten van dia’s naar PDF of naar afbeeldingen. Een Windows‑desktop heeft doorgaans de lettertypen die presentaties gebruiken. Linux‑servers en containers hebben meestal weinig lettertypen, waardoor Aspose.Slides de tekst tekent met een substitutie‑lettertype. Een substitutie heeft andere teken­vormen en breedtes, waardoor regels anders kunnen aflopen en tekst buiten de vorm kan overlopen, en tekens die het substitutie‑lettertype mist, worden niet correct getekend. Als er helemaal geen lettertype is geïnstalleerd, kan de lettertype‑ondersteuning van Java niet starten en stopt Aspose.Slides met een fout.

Dit artikel toont hoe je kunt controleren welke lettertypen Aspose.Slides vervangt, hoe je lettertypen installeert op Debian, Ubuntu en Alpine Linux, hoe je je eigen lettertypebestanden toevoegt, en hoe je het lettertype instelt dat wordt gebruikt wanneer een lettertype ontbreekt. De voorbeelden draaien in Docker op de officiële Eclipse Temurin‑images, zoals in [Run Aspose.Slides for Java in Docker](/slides/nl/java/how-to-run-aspose-slides-in-docker/). De pakket‑opdrachten zijn Dockerfile‑instructies; op een Linux‑server voer je dezelfde opdrachten uit als root.

Voor de font‑API zelf, zoals het insluiten van lettertypen in een presentatie en fallback‑ en vervangingsregels, zie [PowerPoint Fonts](/slides/nl/java/powerpoint-fonts/).

## **Controleren welke lettertypen worden vervangen**

Het volgende Maven‑project meldt de lettertypen die Aspose.Slides in de huidige omgeving vervangt. Maak een map met de naam *font-check* en voeg de onderstaande bestanden toe.

*pom.xml* is het bestand uit [Run Aspose.Slides for Java in Docker](/slides/nl/java/how-to-run-aspose-slides-in-docker/#create-the-project), met de artifact‑ID en de JAR‑bestandsnaam gewijzigd naar *font-check*:

```xml
<project xmlns="http://maven.apache.org/POM/4.0.0">
    <modelVersion>4.0.0</modelVersion>
    <groupId>com.example</groupId>
    <artifactId>font-check</artifactId>
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
        <finalName>font-check</finalName>
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

*src/main/java/FontCheck.java* voegt één tekstvak per lettertype‑naam toe aan een dia en kent het lettertype toe met de [setLatinFont](https://reference.aspose.com/slides/nl/java/com.aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-) methode. De lettertype‑namen komen van de opdrachtregel; zonder argumenten controleert het programma Calibri, Arial en Times New Roman. Het drukt de mappen af waarin Aspose.Slides naar lettertypen zoekt ([FontsLoader.getFontFolders](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsloader/#getFontFolders--)), rendert de dia naar *output/fonts.pdf* en geeft de vervangingen weer die [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) rapporteert. De twee optionele stappen aan het begin, het laden van een *fonts* map en het lezen van een `DEFAULT_FONT`‑variabele, worden later in dit artikel uitgelegd.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.LinkedHashSet;
import java.util.List;
import java.util.Set;

public class FontCheck {
    public static void main(String[] args) {
        // De lettertypen die moeten worden gecontroleerd: de commandoregelargumenten, of drie veelvoorkomende Office-lettertypen.
        String[] fontNames = args.length > 0 ? args : new String[] { "Calibri", "Arial", "Times New Roman" };

        // Laad de lettertypebestanden uit de map fonts in de werkmap, indien aanwezig.
        File appFontFolder = new File("fonts");
        if (appFontFolder.isDirectory()) {
            FontsLoader.loadExternalFonts(new String[] { appFontFolder.getAbsolutePath() });
        }

        // Gebruik het lettertype dat is opgegeven in de omgevingsvariabele DEFAULT_FONT, indien ingesteld, voor tekst waarvan het lettertype ontbreekt.
        LoadOptions loadOptions = new LoadOptions();
        String defaultFont = System.getenv("DEFAULT_FONT");
        if (defaultFont != null && !defaultFont.isEmpty()) {
            loadOptions.setDefaultRegularFont(defaultFont);
        }

        Set<String> fontFolders = new LinkedHashSet<>(Arrays.asList(FontsLoader.getFontFolders()));
        System.out.println("Font folders: " + String.join(", ", fontFolders));

        Presentation presentation = new Presentation(loadOptions);
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            for (int i = 0; i < fontNames.length; i++) {
                IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50 + i * 80, 600, 60);
                shape.getTextFrame().setText("This text is set in " + fontNames[i] + ".");
                shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData(fontNames[i]));
            }

            File outputFolder = new File("output");
            outputFolder.mkdirs();
            presentation.save(new File(outputFolder, "fonts.pdf").getPath(), SaveFormat.Pdf);

            List<FontSubstitutionInfo> substitutions = new ArrayList<>();
            for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions()) {
                substitutions.add(substitution);
            }

            if (substitutions.isEmpty()) {
                System.out.println("No font substitutions.");
            } else {
                System.out.println("Font substitutions:");
                for (FontSubstitutionInfo substitution : substitutions) {
                    System.out.println("  " + substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
                }
            }
        } finally {
            presentation.dispose();
        }
    }
}
```

`getFontFolders` kan een map meer dan één keer retourneren, dus verzamelt het programma de mappen in een set voordat ze worden afgedrukt.

*.dockerignore* houdt lokale bouwresultaten buiten de build‑context:

```text
target/
output/
```

*Dockerfile* bouwt het programma met de Maven‑image en voert het uit op de Eclipse Temurin Java‑runtime‑image, die al fontconfig en de DejaVu‑lettertypen bevat. [Run Aspose.Slides for Java in Docker](/slides/nl/java/how-to-run-aspose-slides-in-docker/) legt elke instructie uit.

```dockerfile
FROM maven:3.9-eclipse-temurin-21 AS build
WORKDIR /src
COPY pom.xml .
RUN mvn -B dependency:go-offline
COPY src ./src
RUN mvn -B package

FROM eclipse-temurin:21-jre
WORKDIR /app
COPY --from=build /src/target/font-check.jar .
COPY --from=build /src/target/lib ./lib
RUN mkdir output && chown ubuntu output
USER ubuntu
ENTRYPOINT ["java", "-cp", "font-check.jar:lib/*", "FontCheck"]
```

Bouw de image en voer de controle uit:

```bash
docker build -t font-check .
docker run --rm font-check
```

De image bevat alleen de DejaVu‑lettertypen, dus alle drie de lettertypen worden vervangen door DejaVu Sans:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

Om de lettertypen van je eigen presentaties te controleren, geef hun namen als argumenten mee, bijvoorbeeld `docker run --rm font-check "Segoe UI" Consolas`. Om *output/fonts.pdf* uit de container te kopiëren, gebruik je de commando’s in [Copy the Output to Your Machine](/slides/nl/java/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine).

## **Lettertypen installeren op Debian en Ubuntu**

### **Microsoft Core Fonts**

Het pakket `ttf-mscorefonts-installer` downloadt en installeert Microsoft’s core fonts for the web, waaronder Arial, Times New Roman, Courier New, Verdana, Georgia en Trebuchet MS. De lettertypen worden geleverd onder de Microsoft‑eindgebruikerslicentie (EULA), en het pakket installeert ze alleen nadat de EULA is geaccepteerd. Een Docker‑build kan de prompt niet beantwoorden, waardoor de installer de EULA weigert en geen lettertypen installeert, terwijl `apt-get install` toch succes meldt. Accepteer de EULA met `debconf-set-selections` **voordat** het pakket wordt geïnstalleerd. Accepteren later in een andere instructie helpt niet: het pakket is dan al geïnstalleerd en apt voert de installer niet opnieuw uit.

Voeg deze instructie toe aan de runtime‑stage van de *Dockerfile*, direct na de `FROM`‑regel, zodat hij als root draait, vóór de `USER`‑instructie:

```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

Bouw de image en voer de controle opnieuw uit met dezelfde twee commando’s. Arial en Times New Roman zijn nu geïnstalleerd:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

Calibri, het standaard‑lettertype van een presentatie die Aspose.Slides maakt, behoort niet tot de core fonts, dus wordt hij nog steeds vervangen. Zie [Set a Default Font for Missing Fonts](#set-a-default-font-for-missing-fonts).

De op Ubuntu gebaseerde Eclipse Temurin‑images activeren `multiverse`, het Ubuntu‑component dat het pakket bevat. Op Debian zit het pakket in het `contrib`‑component, dat de Debian‑images niet activeren. In een Debian‑gebaseerde runtime‑stage, zoals die in [Use Another Base Image](/slides/nl/java/how-to-run-aspose-slides-in-docker/#use-another-base-image), activeer `contrib` in dezelfde instructie:

```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

### **Andere lettertype‑pakketten**

Debian en Ubuntu verpakken bovendien vrij beschikbare lettertypen, bijvoorbeeld:

| Pakket | Lettertypen |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans, DejaVu Serif, DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans, Serif en Mono, met dezelfde metriek als Arial, Times New Roman en Courier New |
| `fonts-crosextra-carlito` | Carlito, met dezelfde metriek als Calibri |
| `fonts-crosextra-caladea` | Caladea, met dezelfde metriek als Cambria |

Installeer ze met `apt-get install` in een `RUN`‑instructie van de runtime‑stage, op dezelfde manier als de Microsoft core fonts. Aspose.Slides for Java maakt geen gebruik van de font‑aliassen van de Linux‑fontconfiguratie: zelfs met `fonts-liberation` geïnstalleerd, wordt tekst in Arial nog steeds getekend met het algemene substitutie‑lettertype, niet met Liberation Sans. Om een metrisch compatibel lettertype in te zetten ter vervanging van een ontbrekend lettertype, stel je het in als [standaard‑lettertype](#set-a-default-font-for-missing-fonts) of voeg je een [lettertype‑vervangingsregel](/slides/nl/java/font-substitution/) toe.

## **Je eigen lettertypebestanden toevoegen**

Lettertypen die de distributies niet leveren, zoals de lettertypen van je organisatie of andere lettertypen waarvoor je een licentie hebt op de server, kun je toevoegen als lettertypebestanden. Plaats de lettertypebestanden, bijvoorbeeld *.ttf*‑bestanden, in een map met de naam *fonts* binnen de *font-check* map. De voorbeelden hieronder gebruiken de bestanden van Carlito, een lettertype met dezelfde metriek als Calibri, die je kunt downloaden via [Google Fonts](https://fonts.google.com/specimen/Carlito).

### **Lettertypen installeren in een systeem‑lettertypemap**

Aspose.Slides leest de lettertypen in de mappen die op de regel `Font folders` worden afgedrukt. Om je lettertypen voor elke applicatie in de image te installeren, kopieer je ze naar */usr/local/share/fonts*, de map voor lokaal geïnstalleerde lettertypen. Voeg deze instructie toe aan de runtime‑stage van de *Dockerfile*, na de `RUN`‑instructie die de Microsoft core fonts installeert:

```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

Herbouw de image en controleer daarna Calibri en Carlito:

```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

Carlito wordt niet langer vervangen:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

### **Lettertypen laden vanuit de toepassingsmap**

In plaats van de lettertypen in een systeemmap te installeren, kun je ze met de applicatie meeleveren en laden met [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---). De lettertypen zijn dan alleen beschikbaar voor Aspose.Slides en worden samen met de applicatie gedeployed. *FontCheck* doet dit: wanneer zijn werkmap, */app* in de container, een *fonts* map bevat, geeft het programma die map door aan `loadExternalFonts` voordat het de presentatie aanmaakt. [Custom Font](/slides/nl/java/custom-font/) beschrijft de andere manieren om lettertypen te leveren, zoals laden vanuit het geheugen.

Verwijder in de *Dockerfile* de `COPY fonts/ /usr/local/share/fonts/` instructie en voeg deze toe na de instructie die de *lib* map kopieert:

```dockerfile
COPY fonts/ ./fonts/
```

Herbouw de image en voer de controle uit met dezelfde twee commando’s. De toepassingsmap verschijnt nu tussen de lettertype‑mappen, en Carlito wordt nog steeds niet vervangen:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

`loadExternalFonts` voegt lettertypen toe aan de geïnstalleerde, maar Java‑lettertypeondersteuning heeft nog steeds minimaal één geïnstalleerd lettertype nodig. In een image zonder enige, stopt `loadExternalFonts` met de fout “Fontconfig head is null, check your fonts or fonts configuration”.

## **Standaard‑lettertype instellen voor ontbrekende lettertypen**

Wanneer een lettertype ontbreekt, gebruikt Aspose.Slides een substitutie die hij zelf kiest. Om zelf te kiezen, geef je de lettertype‑naam door aan de [setDefaultRegularFont](https://reference.aspose.com/slides/nl/java/com.aspose.slides/loadoptions/#setDefaultRegularFont-java.lang.String-) methode van [LoadOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/loadoptions/) en geef je de opties door aan de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) constructor. *FontCheck* leest de lettertype‑naam uit de omgevingsvariabele `DEFAULT_FONT`. Met Carlito geladen, gebruik je het voor ontbrekende lettertypen:

```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

Calibri wordt nu getekend met Carlito, waarvan de tekens dezelfde breedtes hebben als die van Calibri, zodat de tekst zijn regeleinden behoudt:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Carlito
```

Het standaard‑lettertype vervangt elk ontbrekend lettertype. Om individuele lettertypen te koppelen, bijvoorbeeld Arial naar Liberation Sans en Calibri naar Carlito, gebruik je [lettertype‑vervangingsregels](/slides/nl/java/font-substitution/). Regels veranderen de gerenderde output, maar `getSubstitutions` geeft ze niet weer, dus controleer de lettertypen in het uitvoerbestand. Voor Aziatische tekst, roep ook [setDefaultAsianFont](https://reference.aspose.com/slides/nl/java/com.aspose.slides/loadoptions/#setDefaultAsianFont-java.lang.String-) aan; zie [Default Font](/slides/nl/java/default-font/).

## **Lettertypen installeren op Alpine Linux**

De Alpine‑gebaseerde Eclipse Temurin‑image bevat ook de DejaVu‑lettertypen; [Run on Alpine Linux](/slides/nl/java/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux) beschrijft de runtime‑stage. Om ook de Microsoft core fonts op Alpine te installeren, vervang je de runtime‑stage van de *font-check* Dockerfile door deze:

```dockerfile
FROM eclipse-temurin:21-jre-alpine
RUN apk add --no-cache msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -f
WORKDIR /app
COPY --from=build /src/target/font-check.jar .
COPY --from=build /src/target/lib ./lib
RUN adduser -D app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "font-check.jar:lib/*", "FontCheck"]
```

`update-ms-fonts` downloadt en installeert dezelfde Microsoft core fonts als het Debian‑ en Ubuntu‑pakket, en hun EULA geldt op dezelfde manier. `fc-cache` werkt de font‑cache van fontconfig bij. Bouw de image en voer de controle uit met de twee commando’s uit [Check Which Fonts Are Substituted](#check-which-fonts-are-substituted). Het geeft weer:

```text
Font folders: /usr/share/fonts, /home/app/.local/share/fonts, /home/app/.fonts
Font substitutions:
  Calibri -> Arial
```

De overige stappen op deze pagina werken hetzelfde op Alpine: kopieer de *fonts* map naar */usr/local/share/fonts* of naar de toepassingsmap, en zet `DEFAULT_FONT` om het standaard‑lettertype te kiezen. De Alpine‑image heeft geen */usr/local/share/fonts* map, dus die map verschijnt pas in de regel `Font folders` nadat een `COPY`‑instructie hem heeft aangemaakt.

## **FAQ**

**Waarom ziet een presentatie er anders uit wanneer deze op een server wordt geconverteerd?**

De server heeft de lettertypen die de presentatie gebruikt niet, waardoor Aspose.Slides de tekst tekent met een substitutie‑lettertype waarvan de tekens andere breedtes hebben. Voer *FontCheck* uit met de lettertype‑namen van de presentatie om te zien welke lettertypen worden vervangen, en installeer die lettertypen of laad ze vanuit de toepassingsmap.

**Het build‑proces heeft ttf‑mscorefonts‑installer geïnstalleerd, maar Arial wordt nog steeds vervangen. Waarom?**

De EULA werd niet geaccepteerd vóór de installatie van het pakket, waardoor de installer de lettertypen overhing, terwijl `apt-get install` toch succes rapporteerde. Plaats het `debconf-set-selections` commando vóór `apt-get install` in de instructie die het pakket installeert, zoals weergegeven in [Microsoft Core Fonts](#microsoft-core-fonts), en bouw de image opnieuw.

**Moet de computer die de PDF opent de lettertypen hebben?**

Nee. In deze voorbeelden bevat de PDF de lettertypen die zijn gebruikt om de tekst te tekenen, dus ziet hij er op elke computer hetzelfde uit. De lettertypen zijn alleen nodig op de plaats waar Aspose.Slides de presentatie rendert.