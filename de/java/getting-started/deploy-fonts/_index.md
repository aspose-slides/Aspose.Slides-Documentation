---
title: Schriftarten für Aspose.Slides für Java auf Linux und in Docker bereitstellen
linktitle: Schriftarten bereitstellen
type: docs
weight: 155
url: /de/java/deploy-fonts/
keywords:
- Schriftarten bereitstellen
- Schriftarten installieren
- Schriftarten in Docker
- Schriftarten unter Linux
- fehlende Schriftarten
- Schriftart-Ersetzung
- Microsoft‑Kernschriftarten
- ttf‑mscorefonts‑installer
- benutzerdefinierte Schriftarten
- Standardschriftart
- Server
- Container
- PDF‑Konvertierung
- Präsentation
- Java
- Aspose.Slides
description: "Schriftarten für Aspose.Slides für Java auf Linux-Servern und in Docker-Containern bereitstellen: prüfen, welche Schriftarten ersetzt werden, Schriftpakete auf Debian, Ubuntu und Alpine installieren, eigene Schriftdateien hinzufügen und eine Standardschriftart festlegen."
---
## **Übersicht**

Aspose.Slides zeichnet Text mit den Schriftarten, die ihm beim Rendern einer Präsentation zur Verfügung stehen, zum Beispiel beim Konvertieren von Folien in PDF oder Bilder. Ein Windows Desktop hat normalerweise die Schriftarten, die Präsentationen verwenden. Linux-Server und Container verfügen in der Regel über wenige Schriftarten, sodass Aspose.Slides den Text mit einer Ersatzschriftart zeichnet. Eine Ersatzschriftart hat andere Buchstabenformen und -breiten, sodass Zeilen anders umbrochen werden können und Text seine Form überschreiten kann, und Zeichen, die der Ersatz nicht enthält, werden nicht korrekt dargestellt. Wenn überhaupt keine Schriftart installiert ist, kann die Font-Unterstützung von Java nicht starten und Aspose.Slides beendet sich mit einem Fehler.

Dieser Artikel zeigt, wie man prüft, welche Schriftarten Aspose.Slides ersetzt, wie man Schriftarten auf Debian, Ubuntu und Alpine Linux installiert, wie man eigene Schriftdateien hinzufügt und wie man die Schriftart festlegt, die verwendet wird, wenn eine Schriftart fehlt. Die Beispiele werden in Docker auf den offiziellen Eclipse Temurin Images ausgeführt, wie in [Aspose.Slides für Java in Docker ausführen](/slides/de/java/how-to-run-aspose-slides-in-docker/). Die Paketbefehle sind Dockerfile-Anweisungen; auf einem Linux-Server führen Sie dieselben Befehle als root aus.

Für die Font-API selbst, z. B. das Einbetten von Schriftarten in eine Präsentation sowie Fallback- und Ersetzungsregeln, siehe [PowerPoint Schriftarten](/slides/de/java/powerpoint-fonts/).

## **Prüfen, welche Schriftarten ersetzt werden**

Das folgende Maven-Projekt meldet die Schriftarten, die Aspose.Slides in der aktuellen Umgebung ersetzt. Erstellen Sie einen Ordner mit dem Namen *font-check* und fügen Sie die nachstehenden Dateien hinzu.

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

*src/main/java/FontCheck.java* fügt einer Folie pro Schriftartnamen ein Textfeld hinzu und weist die Schriftart mit der [setLatinFont](https://reference.aspose.com/slides/de/java/com.aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-) Methode zu. Die Schriftartnamen werden über die Befehlszeile übergeben; ohne Argumente prüft das Programm Calibri, Arial und Times New Roman. Es gibt die Ordner aus, in denen Aspose.Slides nach Schriftarten sucht ([FontsLoader.getFontFolders](https://reference.aspose.com/slides/de/java/com.aspose.slides/fontsloader/#getFontFolders--)), rendert die Folie nach *output/fonts.pdf* und gibt die von [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) gemeldeten Ersetzungen aus. Die beiden optionalen Schritte zu Beginn, das Laden eines *fonts*-Ordners und das Auslesen der `DEFAULT_FONT`-Variablen, werden später in diesem Artikel erklärt.

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
        // Die zu prüfenden Schriftarten: die Befehlszeilenargumente oder drei gängige Office‑Schriftarten.
        String[] fontNames = args.length > 0 ? args : new String[] { "Calibri", "Arial", "Times New Roman" };

        // Lade die Schriftdateien aus dem fonts‑Ordner im Arbeitsverzeichnis, falls vorhanden.
        File appFontFolder = new File("fonts");
        if (appFontFolder.isDirectory()) {
            FontsLoader.loadExternalFonts(new String[] { appFontFolder.getAbsolutePath() });
        }

        // Verwende die in der Umgebungsvariablen DEFAULT_FONT benannte Schriftart, falls gesetzt, für Text, dessen Schriftart fehlt.
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

`getFontFolders` kann einen Ordner mehr als einmal zurückgeben, sodass das Programm die Ordner in einer Menge sammelt, bevor es sie ausgibt.

```text
target/
output/
```

*Dockerfile* erstellt das Programm mit dem Maven-Image und führt es auf dem Eclipse Temurin Java-Runtime-Image aus, das bereits fontconfig und die DejaVu-Schriftarten enthält. [Aspose.Slides für Java in Docker ausführen](/slides/de/java/how-to-run-aspose-slides-in-docker/) erläutert jede Anweisung.

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

Bauen Sie das Image und führen Sie die Prüfung aus:

```bash
docker build -t font-check .
docker run --rm font-check
```

Das Image enthält nur die DejaVu-Schriftarten, sodass alle drei Schriftarten durch DejaVu Sans ersetzt werden:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

Um die Schriftarten Ihrer eigenen Präsentationen zu prüfen, übergeben Sie deren Namen als Argumente, zum Beispiel `docker run --rm font-check "Segoe UI" Consolas`. Um *output/fonts.pdf* aus dem Container zu kopieren, verwenden Sie die Befehle in [Ausgabe auf Ihren Rechner kopieren](/slides/de/java/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine).

## **Schriftarten auf Debian und Ubuntu installieren**

### **Microsoft Core Fonts**

Das Paket `ttf-mscorefonts-installer` lädt Microsofts Kernschriftarten für das Web herunter und installiert sie, darunter Arial, Times New Roman, Courier New, Verdana, Georgia und Trebuchet MS. Die Schriftarten sind unter Microsofts Endbenutzer-Lizenzvereinbarung (EULA) lizenziert, und das Paket installiert sie erst, nachdem die EULA akzeptiert wurde. Ein Docker-Build kann die Eingabeaufforderung nicht beantworten, sodass der Installer die EULA ablehnt und keine Schriftarten installiert, während `apt-get install` dennoch Erfolg meldet. Akzeptieren Sie die EULA mit `debconf-set-selections` **vor** der Installation des Pakets. Die spätere Akzeptanz in einer späteren Anweisung hilft nicht: das Paket ist dann bereits installiert und apt führt den Installer nicht erneut aus.

```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

Bauen Sie das Image und führen Sie die Prüfung erneut mit denselben zwei Befehlen aus. Arial und Times New Roman sind nun installiert:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

Calibri, die Standardschriftart einer von Aspose.Slides erstellten Präsentation, gehört nicht zu den Kernschriftarten und wird daher weiterhin ersetzt. Siehe [Standardschriftart für fehlende Schriftarten festlegen](#set-a-default-font-for-missing-fonts).

Die auf Ubuntu basierenden Eclipse Temurin-Images aktivieren `multiverse`, die Ubuntu-Komponente, die das Paket enthält. Auf Debian befindet sich das Paket in der `contrib`-Komponente, die in den Debian-Images nicht aktiviert ist. In einer Debian-basierten Runtime-Stage, wie in [Anderes Basis-Image verwenden](/slides/de/java/how-to-run-aspose-slides-in-docker/#use-another-base-image), aktivieren Sie `contrib` in derselben Anweisung:

```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

### **Other Font Packages**

Debian und Ubuntu stellen ebenfalls frei lizenzierte Schriftarten bereit, zum Beispiel:

| Paket | Schriftarten |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans, DejaVu Serif, DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans, Serif und Mono, mit den gleichen Metriken wie Arial, Times New Roman und Courier New |
| `fonts-crosextra-carlito` | Carlito, mit den gleichen Metriken wie Calibri |
| `fonts-crosextra-caladea` | Caladea, mit den gleichen Metriken wie Cambria |

Installieren Sie sie mit `apt-get install` in einer `RUN`‑Anweisung der Runtime-Stage, analog zu den Microsoft-Core-Fonts. Aspose.Slides für Java wendet die Schriftarten-Aliase der Linux-Schriftkonfiguration nicht an: Mit installiertem `fonts-liberation` wird Text in Arial weiterhin mit der allgemeinen Ersatzschriftart gezeichnet, nicht mit Liberation Sans. Um eine metrisch kompatible Schriftart anstelle einer fehlenden zu verwenden, setzen Sie sie als [Standardschriftart](#set-a-default-font-for-missing-fonts) oder fügen Sie eine [Schriftart‑Ersetzungsregel](/slides/de/java/font-substitution/) hinzu.

## **Eigene Schriftdateien hinzufügen**

Schriftarten, die von den Distributionen nicht bereitgestellt werden, wie beispielsweise die Schriftarten Ihrer Organisation oder andere Schriftarten, für die Sie eine Lizenz zur Nutzung auf dem Server besitzen, können als Schriftdateien hinzugefügt werden. Legen Sie die Schriftdateien, zum Beispiel *.ttf*-Dateien, in einen Ordner namens *fonts* innerhalb des *font-check*-Ordners. Die nachstehenden Beispiele verwenden die Dateien von Carlito, einer Schriftart mit denselben Metriken wie Calibri, die Sie von [Google Fonts](https://fonts.google.com/specimen/Carlito) herunterladen können.

### **Schriftarten in einem System‑Schriftordner installieren**

Aspose.Slides liest die Schriftarten in den im `Font folders`-Eintrag ausgegebenen Ordnern. Um Ihre Schriftarten für jede Anwendung im Image zu installieren, kopieren Sie sie nach */usr/local/share/fonts*, dem Ordner für lokal installierte Schriftarten. Fügen Sie diese Anweisung zur Runtime-Stage des *Dockerfile* hinzu, nach der `RUN`‑Anweisung, die die Microsoft-Core-Fonts installiert:

```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

Bauen Sie das Image erneut, und prüfen Sie dann Calibri und Carlito:

```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

Carlito wird nicht mehr ersetzt:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

### **Schriftarten aus dem Anwendungsordner laden**

Anstatt die Schriftarten in einem System-Ordner zu installieren, können Sie sie mit der Anwendung mitliefern und mit [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/de/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) laden. Die Schriftarten stehen dann nur Aspose.Slides zur Verfügung und werden zusammen mit der Anwendung bereitgestellt. *FontCheck* tut dies: Wenn sein Arbeitsverzeichnis, */app* im Container, einen *fonts*-Ordner enthält, übergibt das Programm diesen Ordner an `loadExternalFonts`, bevor es die Präsentation erstellt. [Custom Font](/slides/de/java/custom-font/) beschreibt weitere Möglichkeiten, Schriftarten bereitzustellen, z. B. das Laden aus dem Speicher.

Im *Dockerfile* entfernen Sie die Anweisung `COPY fonts/ /usr/local/share/fonts/` und fügen Sie diese nach der Anweisung hinzu, die den *lib*-Ordner kopiert:

```dockerfile
COPY fonts/ ./fonts/
```

Bauen Sie das Image erneut und führen Sie die Prüfung mit denselben zwei Befehlen aus. Der Anwendungsordner erscheint jetzt unter den Schriftordnern, und Carlito wird weiterhin nicht ersetzt:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

`loadExternalFonts` fügt Schriftarten zu den installierten hinzu, aber die Font-Unterstützung von Java benötigt nach wie vor mindestens eine installierte Schriftart. In einem Image ohne irgendeine beendet `loadExternalFonts` mit dem Fehler "Fontconfig head is null, check your fonts or fonts configuration".

## **Standardschriftart für fehlende Schriftarten festlegen**

Wenn eine Schriftart fehlt, verwendet Aspose.Slides eine Ersatzschriftart, die es selbst auswählt. Um diese selbst zu wählen, übergeben Sie den Schriftartnamen an die [setDefaultRegularFont](https://reference.aspose.com/slides/de/java/com.aspose.slides/loadoptions/#setDefaultRegularFont-java.lang.String-) Methode von [LoadOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/loadoptions/) und geben Sie die Optionen an den [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/) Konstruktor weiter. *FontCheck* liest den Schriftartnamen aus der Umgebungsvariablen `DEFAULT_FONT`. Mit geladenem Carlito verwenden Sie es für fehlende Schriftarten:

```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

Calibri wird jetzt mit Carlito gezeichnet, dessen Zeichen dieselben Breiten wie die von Calibri haben, sodass der Text seine Zeilenumbrüche beibehält:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Carlito
```

Die Standardschriftart ersetzt jede fehlende Schriftart. Um einzelne Schriftarten abzubilden, zum Beispiel Arial zu Liberation Sans und Calibri zu Carlito, verwenden Sie [Schriftart‑Ersetzungsregeln](/slides/de/java/font-substitution/). Regeln ändern die gerenderte Ausgabe, aber `getSubstitutions` spiegelt sie nicht wider, prüfen Sie also stattdessen die Schriftarten in der Ausgabedatei. Für asiatischen Text rufen Sie zudem [setDefaultAsianFont](https://reference.aspose.com/slides/de/java/com.aspose.slides/loadoptions/#setDefaultAsianFont-java.lang.String-) auf; siehe [Default Font](/slides/de/java/default-font/).

## **Schriftarten auf Alpine Linux installieren**

Das auf Alpine basierende Eclipse Temurin-Image enthält ebenfalls die DejaVu-Schriftarten; [Ausführung auf Alpine Linux](/slides/de/java/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux) beschreibt dessen Runtime-Stage. Um die Microsoft-Core-Fonts ebenfalls darauf zu installieren, ersetzen Sie die Runtime-Stage des *font-check* Dockerfile durch diese:

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

`update-ms-fonts` lädt dieselben Microsoft-Core-Fonts wie das Debian- und Ubuntu-Paket herunter und installiert sie, und deren EULA gilt auf dieselbe Weise. `fc-cache` aktualisiert den Schriftarten-Cache von fontconfig. Bauen Sie das Image und führen Sie die Prüfung mit den beiden Befehlen aus [Prüfen, welche Schriftarten ersetzt werden](#check-which-fonts-are-substituted). Es gibt aus:

```text
Font folders: /usr/share/fonts, /home/app/.local/share/fonts, /home/app/.fonts
Font substitutions:
  Calibri -> Arial
```

Die anderen Schritte auf dieser Seite funktionieren auf Alpine auf dieselbe Weise: Kopieren Sie den *fonts*-Ordner nach */usr/local/share/fonts* oder in den Anwendungsordner und setzen Sie `DEFAULT_FONT`, um die Standardschriftart zu wählen. Das Alpine-Image besitzt keinen */usr/local/share/fonts*-Ordner, sodass dieser Ordner erst nach einer `COPY`‑Anweisung in der Zeile `Font folders` erscheint.

## **FAQ**

**Warum sieht eine Präsentation anders aus, wenn sie auf einem Server konvertiert wird?**

Der Server verfügt nicht über die Schriftarten, die die Präsentation verwendet, sodass Aspose.Slides den Text mit einer Ersatzschriftart zeichnet, deren Buchstaben andere Breiten haben. Führen Sie *FontCheck* mit den Schriftartnamen der Präsentation aus, um zu sehen, welche Schriftarten ersetzt werden, und installieren Sie dann diese Schriftarten oder laden Sie sie aus dem Anwendungsordner.

**Das Build hat ttf‑mscorefonts‑installer installiert, aber Arial wird immer noch ersetzt. Warum?**

Die EULA wurde nicht vor der Installation des Pakets akzeptiert, sodass der Installer die Schriftarten übersprang. Platzieren Sie den Befehl `debconf-set-selections` vor `apt-get install` in der Anweisung, die das Paket installiert, wie in [Microsoft Core Fonts](#microsoft-core-fonts) gezeigt, und bauen Sie das Image erneut.

**Braucht der Computer, der das PDF öffnet, die Schriftarten?**

Nein. In diesen Beispielen enthält das PDF die Schriftarten, die zum Zeichnen des Textes verwendet wurden, sodass es auf jedem Computer gleich aussieht. Die Schriftarten werden nur dort benötigt, wo Aspose.Slides die Präsentation rendert.