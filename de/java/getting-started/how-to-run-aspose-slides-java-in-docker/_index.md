---
title: Aspose.Slides für Java in Docker ausführen
linktitle: Docker
type: docs
weight: 150
url: /de/java/how-to-run-aspose-slides-in-docker/
keywords:
- Docker
- Dockerfile
- Docker-Container
- Mehrstufiger Build
- Container-Image
- Eclipse Temurin
- Maven
- Linux
- Ubuntu
- Alpine
- Debian
- fontconfig
- Schriftarten
- PDF-Konvertierung
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erstellen und Ausführen einer Aspose.Slides‑Anwendung für Java in Docker: ein mehrstufiges Dockerfile auf den offiziellen Maven‑ und Eclipse‑Temurin‑Images, die Linux‑Bibliotheken und Schriftarten, die Aspose.Slides benötigt, und wie die erzeugten Dateien auf Ihren Rechner kopiert werden."
---
## **Übersicht**

Dieser Artikel zeigt, wie man Aspose.Slides for Java in einem Docker‑Container ausführt. Sie erstellen ein kleines Maven‑Projekt, das eine Präsentation mit einem Textfeld erzeugt und in PDF konvertiert, packen es mit einem mehrstufigen Dockerfile auf den offiziellen Maven‑ und Eclipse‑Temurin‑Images, führen es aus und kopieren die erzeugten Dateien auf Ihren Rechner. Der Artikel erklärt außerdem, was Aspose.Slides in einem Linux‑Image zusätzlich zu Java benötigt, und endet mit Varianten für Alpine Linux und für Images, die Java aus den Paketen der Distribution installieren.

Sie benötigen nur Docker auf Ihrem Rechner. JDK und Maven sind Teil des Build‑Images, sodass Sie sie nicht installieren müssen. Zum Installieren von Docker siehe [Get Docker](https://docs.docker.com/get-started/get-docker/).

## **Basis‑Images auswählen**

Das Dockerfile in diesem Artikel verwendet zwei offizielle Images von Docker Hub:

- [maven](https://hub.docker.com/_/maven) mit dem Tag `3.9-eclipse-temurin-21` baut die Anwendung. Es enthält Apache Maven 3.9 und das Eclipse Temurin JDK 21.
- [eclipse-temurin](https://hub.docker.com/_/eclipse-temurin) mit dem Tag `21-jre` führt sie aus. Es enthält die Eclipse Temurin Java 21‑Runtime auf Ubuntu, ohne JDK und Maven.

Aspose.Slides for Java zeichnet Text mit der Font‑Unterstützung von Java, die unter Linux die Bibliotheken fontconfig und FreeType sowie mindestens eine installierte Schriftart benötigt. Die Eclipse‑Temurin‑Images enthalten bereits fontconfig, FreeType und die DejaVu‑Schriften, sodass das Dockerfile in diesem Artikel keine Pakete installiert. In einem Image ohne Schriftarten bricht das Speichern einer Präsentation mit dem Fehler „Fontconfig head is null, check your fonts or fonts configuration“ ab. Wenn Sie auf einem anderen Basis‑Image bauen, siehe [Use Another Base Image](#use-another-base-image).

## **Projekt erstellen**

Erstellen Sie einen Ordner namens *hello-slides-docker* und fügen Sie die folgenden Dateien hinzu.

*pom.xml* deklariert das Maven‑Repository von Aspose und die Aspose.Slides‑for‑Java‑Abhängigkeit, wie in [Installation](/slides/de/java/installation/) beschrieben; Aspose.Slides for Java ist nicht im Maven Central veröffentlicht, daher ist der Repository‑Eintrag erforderlich. Das Element `finalName` benennt die Anwendungs‑JAR‑Datei *hello-slides.jar*, und das [maven-dependency-plugin](https://maven.apache.org/plugins/maven-dependency-plugin/) kopiert die Abhängigkeiten der Anwendung nach *target/lib*, wenn Maven das Paket erstellt. Setzen Sie die Aspose.Slides‑Version auf die neueste, die im [Repository](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) aufgeführt ist.

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

*src/main/java/HelloSlides.java* erstellt eine [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/), fügt ihrer ersten Folie ein Rechteck mit Text hinzu und speichert die Präsentation zweimal mit der [save](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#save-java.lang.String-int-)‑Methode: als PPTX und als PDF. Beide Dateien werden im Ordner *output* im Arbeitsverzeichnis abgelegt. Das Programm listet anschließend die Schriftarten auf, die Aspose.Slides beim Rendern der Präsentation ersetzt, mittels [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifontsmanager/#getSubstitutions--), sodass Sie sehen können, ob der Container die für die Präsentation benötigten Schriftarten enthält.

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

*.dockerignore* hält den *target*-Ordner eines lokalen Builds und die Ausgaben früherer Durchläufe außerhalb des Docker‑Build‑Kontexts, sodass das Image nur aus den Quell‑Dateien erstellt wird.

```text
target/
output/
```

## **Dockerfile schreiben**

Fügen Sie dem Ordner *hello-slides-docker* eine Datei namens *Dockerfile* hinzu:

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

Die Datei hat zwei Stufen:

- **Die Build‑Stufe** startet vom Maven‑Image. Sie kopiert zuerst *pom.xml* und führt `mvn dependency:go-offline` aus, wodurch Aspose.Slides for Java und die Maven‑Plugins heruntergeladen werden, sodass Docker diese Schicht wiederverwendet, solange sich *pom.xml* nicht ändert. Anschließend kopiert sie den Quellcode und führt `mvn package` aus, das das Programm in *target/hello-slides.jar* kompiliert und die Aspose.Slides‑JAR‑Datei nach *target/lib* kopiert. Die Option `-B` lässt Maven im nicht‑interaktiven (Batch‑)Modus laufen.
- **Die Runtime‑Stufe** startet vom kleineren Java‑Runtime‑Image und kopiert nur die Anwendungs‑JAR‑Datei und den *lib*-Ordner hinein. Sie erstellt den *output*-Ordner, gibt ihn an `ubuntu`, den nicht‑root‑Benutzer, den das Ubuntu‑basierte Image definiert, und führt die Anwendung als dieser Benutzer aus. Der Klassenpfad `hello-slides.jar:lib/*` enthält die Anwendung und jede JAR‑Datei in *lib*; Java expandiert das `*` selbst.

Das Projekt wird für Java 11 kompiliert (die Eigenschaft `maven.compiler.release`), sodass die Runtime‑Stufe eine neuere Java‑Version verwenden kann. Beispielweise ändern Sie das Image der Runtime‑Stufe zu `eclipse-temurin:25-jre`, um die Anwendung unter Java 25 auszuführen.

## **Container bauen und ausführen**

Öffnen Sie ein Terminal im Ordner *hello-slides-docker*. Bauen Sie das Image und führen Sie anschließend einen Container daraus aus:

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

Der erste Build lädt die Basis‑Images, die Maven‑Plugins und Aspose.Slides for Java herunter, sodass er mehrere Minuten dauert; spätere Builds verwenden diese wieder. Der Container führt die Anwendung aus und beendet sich. Er gibt folgendes aus:

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

Die erste Zeile zeigt, dass der Text Calibri verwendet, die Standardschrift einer neuen Präsentation, und dass Calibri nicht im Image installiert ist, sodass Aspose.Slides den Text mit DejaVu Sans gezeichnet hat. Der Text im PDF ist echter, auswählbarer Text in dieser Schrift. Ohne Lizenz fügt Aspose.Slides jedem gespeicherten Folie außerdem ein Evaluations‑Wasserzeichen hinzu; siehe [Licensing](/slides/de/java/licensing/).

## **Ausgabe auf Ihren Rechner kopieren**

Die Dateien befinden sich im */app/output*-Ordner des gestoppten Containers. Kopieren Sie sie in einen *output*-Ordner auf Ihrem Rechner und entfernen Sie anschließend den Container:

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

Diese beiden Befehle funktionieren in Bash, PowerShell und der Windows‑Eingabeaufforderung gleich.

Unter Linux können Sie stattdessen einen Ordner Ihres Rechners in den Container einbinden, sodass die Anwendung ihre Dateien dort direkt schreibt:

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

Die Option `--user` führt die Anwendung mit Ihren Benutzer‑ und Gruppen‑IDs aus, sodass sie in den von Ihnen erstellten Ordner schreiben kann und die Dateien Ihnen gehören. `--rm` entfernt den Container, wenn er beendet wird.

## **Unter Alpine Linux ausführen**

Eclipse Temurin ist auch als Image auf Basis von Alpine Linux verfügbar, das kleiner ist. Es enthält ebenfalls fontconfig, FreeType und die DejaVu‑Schriften, sodass die Anwendung dort keine zusätzlichen Pakete benötigt. Um es zu verwenden, ersetzen Sie die Runtime‑Stufe in *Dockerfile* (alles ab der zweiten `FROM`‑Zeile) durch:

```dockerfile
FROM eclipse-temurin:21-jre-alpine
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN adduser -D app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

Das Alpine‑Image hat keinen `ubuntu`‑Benutzer, daher erzeugt diese Stufe einen Benutzer namens `app` mit `adduser` und führt die Anwendung als dieser Benutzer aus. Bauen, führen und kopieren Sie die Ausgabe mit denselben Befehlen wie oben. Die Anwendung gibt dieselben zwei Zeilen aus.

## **Ein anderes Basis‑Image verwenden**

Wenn Ihr Image Java stattdessen aus den Paketen der Linux‑Distribution installiert, installieren Sie die Font‑Bibliotheken von Java und eine Schriftart dazu. Auf Debian und Ubuntu führt das Paket `openjdk-21-jre-headless` fontconfig, FreeType und HarfBuzz nur als empfohlene Pakete auf, sodass `apt-get install --no-install-recommends` sie weglässt und die Anwendung mit einem `UnsatisfiedLinkError` für `libfontmanager.so` stoppt. Diese Runtime‑Stufe installiert Java 21, die Bibliotheken und die DejaVu‑Schriften auf Debian 13 und erzeugt einen nicht‑root‑Benutzer namens `app`:

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

Die gleiche Stufe funktioniert auf Ubuntu 26.04 mit `FROM ubuntu:26.04`.

## **FAQ**

**Das Speichern der Präsentation stoppt mit „Fontconfig head is null, check your fonts or fonts configuration“. Was fehlt?**

Eine Schriftart. Die Font‑Unterstützung von Java hat im Image keine installierte Schriftart gefunden. Installieren Sie ein Schrift‑Paket, z. B. `fonts-dejavu-core` auf Debian und Ubuntu, wie in [Use Another Base Image](#use-another-base-image) beschrieben. [Deploy Fonts](/slides/de/java/deploy-fonts/) listet weitere Schrift‑Pakete auf.

**Die Anwendung stoppt mit einem UnsatisfiedLinkError für libfontmanager.so. Was fehlt?**

Eine native Bibliothek der Font‑Unterstützung von Java; die Meldung nennt die Datei, die nicht geladen werden konnte, z. B. `libharfbuzz.so.0`. Das passiert, wenn Java aus den Paketen der Distribution ohne deren empfohlene Pakete installiert wird. Installieren Sie die in [Use Another Base Image](#use-another-base-image) aufgeführten Bibliotheken.

**Warum ist der Text im PDF in einer anderen Schriftart als in PowerPoint?**

Die in der Präsentation verwendeten Schriftarten sind im Image nicht installiert, daher zeichnet Aspose.Slides den Text mit einer Ersatzschrift. Die Ausgabe der Anwendung nennt jede ersetzte Schriftart. [Deploy Fonts](/slides/de/java/deploy-fonts/) erklärt, wie man Schriftarten im Image installiert oder sie aus dem Anwendungs‑Ordner lädt.

**Wie viel Speicher kann die Anwendung im Container nutzen?**

Standardmäßig begrenzt Java den Heap auf ein Viertel des dem Container zur Verfügung stehenden Speichers, zum Beispiel auf etwa 250 MB, wenn Sie den Container mit `docker run -m 1g` starten. Um große Präsentationen zu verarbeiten, erhöhen Sie den Anteil mit der Option `MaxRAMPercentage`, z. B. `docker run --rm -m 1g -e JAVA_TOOL_OPTIONS=-XX:MaxRAMPercentage=75 hello-slides`. Java gibt dann vor der Programmausgabe eine Zeile „Picked up JAVA_TOOL_OPTIONS“ aus.

**Brauche ich ein JDK oder Maven auf meinem Rechner?**

Nein. Die Build‑Stufe kompiliert die Anwendung innerhalb des Maven‑Images. Sie benötigen ein JDK und Maven nur, wenn Sie die Anwendung auch außerhalb von Docker bauen und ausführen möchten; siehe [Installation](/slides/de/java/installation/).