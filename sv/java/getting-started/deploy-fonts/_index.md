---
title: Distribuera typsnitt för Aspose.Slides för Java på Linux och i Docker
linktitle: Distribuera typsnitt
type: docs
weight: 155
url: /sv/java/deploy-fonts/
keywords:
- distribuera typsnitt
- installera typsnitt
- typsnitt i Docker
- typsnitt på Linux
- saknade typsnitt
- typsnittsersättning
- Microsoft grundtypsnitt
- ttf-mscorefonts-installer
- anpassade typsnitt
- standardtypsnitt
- server
- behållare
- PDF-konvertering
- presentation
- Java
- Aspose.Slides
description: "Distribuera typsnitt för Aspose.Slides för Java på Linux-servrar och i Docker-behållare: kontrollera vilka typsnitt som ersätts, installera typsnittspaket på Debian, Ubuntu och Alpine, lägg till egna typsnittsfiler och ange ett standardtypsnitt."
---
## **Översikt**

Aspose.Slides ritar text med de typsnitt som är tillgängliga när den renderar en presentation, till exempel när den konverterar bildspel till PDF eller till bilder. En Windows‑desktop har vanligtvis de typsnitt som presentationer använder. Linux‑servrar och containrar har vanligtvis få typsnitt, så Aspose.Slides ritar texten med ett ersättningstypsnitt. Ett ersättningstypsnitt har olika bokstavsformer och bredd, så rader kan radbrytas annorlunda och text kan flöda över sin form, och tecken som ersättningstypsnittet saknar ritas inte korrekt. Om inget typsnitt är installerat alls kan Javas typsnittsstöd inte starta, och Aspose.Slides avbryts med ett fel.

Denna artikel visar hur du kontrollerar vilka typsnitt Aspose.Slides ersätter, hur du installerar typsnitt på Debian, Ubuntu och Alpine Linux, hur du lägger till egna typsnittsfiler och hur du anger vilket typsnitt som ska användas när ett typsnitt saknas. Exemplen körs i Docker på de officiella Eclipse Temurin‑bilderna, som i [Kör Aspose.Slides för Java i Docker](/slides/sv/java/how-to-run-aspose-slides-in-docker/). Paketkommandona är Dockerfile‑instruktioner; på en Linux‑server kör du samma kommandon som root.

För själva typsnitts‑API:et, såsom inbäddning av typsnitt i en presentation samt reserv- och ersättningsregler, se [PowerPoint‑typsnitt](/slides/sv/java/powerpoint-fonts/).

## **Kontrollera vilka typsnitt som ersätts**

Följande Maven‑projekt rapporterar vilka typsnitt Aspose.Slides ersätter i den aktuella miljön. Skapa en mapp med namnet *font-check* och lägg till filerna nedan i den.

*pom.xml* är den från [Kör Aspose.Slides för Java i Docker](/slides/sv/java/how-to-run-aspose-slides-in-docker/#create-the-project), med artefakt‑ID och JAR‑filnamn ändrade till *font-check*:

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

*src/main/java/FontCheck.java* lägger till en textruta per typsnittsnamn på en bild och tilldelar typsnittet med metoden [setLatinFont](https://reference.aspose.com/slides/sv/java/com.aspose.slides.baseportionformat/#setLatinFont-com.aspose.slides.IFontData-). Typsnittsnamnen kommer från kommandoraden; utan argument kontrollerar programmet Calibri, Arial och Times New Roman. Det skriver ut mapparna som Aspose.Slides söker efter typsnitt i ([FontsLoader.getFontFolders](https://reference.aspose.com/slides/sv/java/com.aspose.slides.fontsloader/#getFontFolders--)), renderar bilden till *output/fonts.pdf* och skriver ut ersättningarna som rapporteras av [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/sv/java/com.aspose.slides.ifontsmanager/#getSubstitutions--). De två valfria stegen i början, att ladda en *fonts*-mapp och läsa en `DEFAULT_FONT`‑variabel, förklaras senare i denna artikel.

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
        // Typsnitten att kontrollera: kommandoradsargumenten, eller tre vanliga Office-typsnitt.
        String[] fontNames = args.length > 0 ? args : new String[] { "Calibri", "Arial", "Times New Roman" };

        // Läs in typsnittsfilerna från fonts-mappen i arbetskatalogen, om den finns.
        File appFontFolder = new File("fonts");
        if (appFontFolder.isDirectory()) {
            FontsLoader.loadExternalFonts(new String[] { appFontFolder.getAbsolutePath() });
        }

        // Använd typsnittet som anges i miljövariabeln DEFAULT_FONT, om den är satt, för text vars typsnitt saknas.
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

`getFontFolders` kan returnera en mapp mer än en gång, så programmet samlar mapparna i en mängd innan de skrivs ut.

*.dockerignore* håller lokala byggresultat utanför byggkontexten:

```text
target/
output/
```

*Dockerfile* bygger programmet med Maven‑imagen och kör det på Eclipse Temurin‑Java‑runtime‑imagen, som redan innehåller fontconfig och DejaVu‑typsnitten. [Kör Aspose.Slides för Java i Docker](/slides/sv/java/how-to-run-aspose-slides-in-docker/) förklarar varje instruktion.

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

Bygg bilden och kör kontrollen:

```bash
docker build -t font-check .
docker run --rm font-check
```

Bilden har bara DejaVu‑typsnitten, så alla tre typsnitten ersätts med DejaVu Sans:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

För att kontrollera typsnitten i dina egna presentationer, skicka deras namn som argument, till exempel `docker run --rm font-check "Segoe UI" Consolas`. För att kopiera *output/fonts.pdf* ur containern, använd kommandona i [Kopiera utdata till din maskin](/slides/sv/java/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine).

## **Installera typsnitt på Debian och Ubuntu**

### **Microsoft Core Fonts**

`ttf-mscorefonts-installer`‑paketet hämtar och installerar Microsofts grundtypsnitt för webb, bland dem Arial, Times New Roman, Courier New, Verdana, Georgia och Trebuchet MS. Typsnitten är licensierade under Microsofts slut‑användarlicensavtal (EULA), och paketet installerar dem endast efter att EULA har accepterats. En Docker‑byggnad kan inte svara på prompten, så installationsprogrammet avvisar EULA och installerar inga typsnitt, medan `apt-get install` ändå rapporterar framgång. Acceptera EULA med `debconf-set-selections` **innan** paketet installeras. Att acceptera den i ett senare steg hjälper inte: paketet är då redan installerat, och apt kör inte installationsprogrammet igen.

Lägg till denna instruktion i runtime‑stadiet av *Dockerfile*, direkt efter dess `FROM`‑rad, så att den körs som root, innan `USER`‑instruktionen:

```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

Bygg bilden och kör kontrollen igen med samma två kommandon. Arial och Times New Roman är nu installerade:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

Calibri, standardtypsnittet för en presentation som Aspose.Slides skapar, är inte ett av grundtypsnitten, så det ersätts fortfarande. Se [Ange ett standardtypsnitt för saknade typsnitt](#set-a-default-font-for-missing-fonts).

De Ubuntu‑baserade Eclipse Temurin‑bilderna aktiverar `multiverse`, Ubuntu‑komponenten som innehåller paketet. På Debian finns paketet i `contrib`‑komponenten, som Debian‑bilderna inte aktiverar. I ett Debian‑baserat runtime‑stadium, såsom det i [Använd en annan basimage](/slides/sv/java/how-to-run-aspose-slides-in-docker/#use-another-base-image), aktivera `contrib` i samma instruktion:

```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

### **Andra typsnittspaket**

Debian och Ubuntu paketar också fritt licensierade typsnitt, till exempel:

| Paket | Typsnitt |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans, DejaVu Serif, DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans, Serif och Mono, med samma mått som Arial, Times New Roman och Courier New |
| `fonts-crosextra-carlito` | Carlito, med samma mått som Calibri |
| `fonts-crosextra-caladea` | Caladea, med samma mått som Cambria |

Installera dem med `apt-get install` i en `RUN`‑instruktion i runtime‑stadiet, på samma sätt som Microsoft‑grundtypsnitten. Aspose.Slides för Java använder inte typsnitts‑aliasen i Linux‑typsnittskonfigurationen: med `fonts-liberation` installerat ritas text i Arial fortfarande med det generella ersättningstypsnittet, inte med Liberation Sans. För att använda ett mått‑kompatibelt typsnitt i stället för ett saknat, ange det som [standardtypsnitt](#set-a-default-font-for-missing-fonts) eller lägg till en [typsnitts‑ersättningsregel](/slides/sv/java/font-substitution/).

## **Lägg till egna typsnittsfiler**

Typsnitt som distributionerna inte paketar, såsom din organisations typsnitt eller andra typsnitt som du har licens att använda på servern, kan läggas till som typsnittsfiler. Placera typsnittsfilerna, till exempel *.ttf*-filer, i en mapp med namnet *fonts* inuti *font-check*-mappen. Exemplen nedan använder filerna för Carlito, ett typsnitt med samma mått som Calibri, som du kan ladda ner från [Google Fonts](https://fonts.google.com/specimen/Carlito).

### **Installera typsnitten i en systemtypsnittsmapp**

Aspose.Slides läser typsnitten i de mappar som skrivs ut på raden `Font folders`. För att installera dina typsnitt för alla applikationer i bilden, kopiera dem till */usr/local/share/fonts*, mappen för lokalt installerade typsnitt. Lägg till denna instruktion i runtime‑stadiet av *Dockerfile*, efter `RUN`‑instruktionen som installerar Microsoft‑grundtypsnitten:

```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

Bygg om bilden och kontrollera sedan Calibri och Carlito:

```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

Carlito ersätts inte längre:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

### **Läs in typsnitt från applikationsmappen**

Istället för att installera typsnitten i en systemmapp kan du paketera dem med applikationen och ladda dem med [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/sv/java/com.aspose.slides.fontsloader/#loadExternalFonts-java.lang.String---). Typsnitten blir då endast tillgängliga för Aspose.Slides och distribueras tillsammans med applikationen. *FontCheck* gör så här: när dess arbetskatalog, */app* i containern, innehåller en *fonts*-mapp, skickar programmet den mappen till `loadExternalFonts` innan det skapar presentationen. [Anpassat typsnitt](/slides/sv/java/custom-font/) beskriver de andra sätten att tillhandahålla typsnitt, till exempel att läsa in dem från minne.

I *Dockerfile*, ta bort instruktionen `COPY fonts/ /usr/local/share/fonts/` och lägg till denna efter instruktionen som kopierar *lib*-mappen:

```dockerfile
COPY fonts/ ./fonts/
```

Bygg om bilden och kör kontrollen med samma två kommandon. Applikationsmappen visas nu bland typsnittsm mapparna, och Carlito ersätts fortfarande inte:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

`loadExternalFonts` lägger till typsnitt till de installerade, men Javas typsnittsstöd behöver fortfarande minst ett installerat typsnitt. I en bild utan några, stoppas `loadExternalFonts` med felet "Fontconfig head is null, check your fonts or fonts configuration".

## **Ange ett standardtypsnitt för saknade typsnitt**

När ett typsnitt saknas använder Aspose.Slides ett ersättningstypsnitt som den väljer själv. För att välja det själv, skicka typsnittsnamnet till metoden [setDefaultRegularFont](https://reference.aspose.com/slides/sv/java/com.aspose.slides.loadoptions/#setDefaultRegularFont-java.lang.String-) i [LoadOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides.loadoptions/) och skicka alternativen till [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides.presentation/)-konstruktorn. *FontCheck* läser typsnittsnamnet från `DEFAULT_FONT`‑miljövariabeln. Med Carlito laddat, använd det för saknade typsnitt:

```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

Calibri ritas nu med Carlito, vars tecken har samma bredd som Calibri, så texten behåller sina radbrytningar:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Carlito
```

Standardtypsnittet ersätter varje saknat typsnitt. För att mappa enskilda typsnitt, till exempel Arial till Liberation Sans och Calibri till Carlito, använd [typsnitts‑ersättningsregler](/slides/sv/java/font-substitution/). Reglerna förändrar den renderade utskriften, men `getSubstitutions` visar dem inte, så kontrollera typsnitten i utskriftsfilen istället. För asiatisk text, anropa även [setDefaultAsianFont](https://reference.aspose.com/slides/sv/java/com.aspose.slides.loadoptions/#setDefaultAsianFont-java.lang.String-); se [Standardtypsnitt](/slides/sv/java/default-font/).

## **Installera typsnitt på Alpine Linux**

Den Alpine‑baserade Eclipse Temurin‑imagen innehåller också DejaVu‑typsnitten; [Kör på Alpine Linux](/slides/sv/java/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux) beskriver dess runtime‑stadium. För att också installera Microsoft‑grundtypsnitten på den, ersätt runtime‑stadiet i *font-check*-Dockerfile med detta:

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

`update-ms-fonts` hämtar och installerar samma Microsoft‑grundtypsnitt som Debian‑ och Ubuntu‑paketet, och deras EULA tillämpas på samma sätt. `fc-cache` uppdaterar teckensnitts‑cachen i fontconfig. Bygg bilden och kör kontrollen med de två kommandona från [Kontrollera vilka typsnitt som ersätts](#check-which-fonts-are-substituted). Den skriver ut:

```text
Font folders: /usr/share/fonts, /home/app/.local/share/fonts, /home/app/.fonts
Font substitutions:
  Calibri -> Arial
```

De andra stegen på den här sidan fungerar på samma sätt på Alpine: kopiera *fonts*-mappen till */usr/local/share/fonts* eller till applikationsmappen, och ange `DEFAULT_FONT` för att välja standardtypsnittet. Alpine‑imagen har ingen */usr/local/share/fonts*-mapp, så den mappen visas på raden `Font folders` först efter att en `COPY`‑instruktion har skapat den.

## **FAQ**

**Varför ser en presentation annorlunda ut när den konverteras på en server?**

Servern har inte de typsnitt som presentationen använder, så Aspose.Slides ritar texten med ett ersättningstypsnitt vars bokstäver har andra bredd. Kör *FontCheck* med presentationens typsnittnamn för att se vilka typsnitt som ersätts, installera sedan dessa typsnitt eller läs in dem från applikationsmappen.

**Byggprocessen installerade ttf‑mscorefonts‑installer, men Arial ersätts fortfarande. Varför?**

EULA accepterades inte innan paketet installerades, så installationsprogrammet hoppade över typsnitten. Placera kommandot `debconf-set-selections` före `apt-get install` i instruktionen som installerar paketet, som visas i [Microsoft Core Fonts](#microsoft-core-fonts), och bygg om bilden.

**Behöver datorn som öppnar PDF‑filen typsnitten?**

Nej. I dessa exempel innehåller PDF‑filen de typsnitt som användes för att rita texten, så den ser likadan ut på alla datorer. Typsnitten behövs endast där Aspose.Slides renderar presentationen.