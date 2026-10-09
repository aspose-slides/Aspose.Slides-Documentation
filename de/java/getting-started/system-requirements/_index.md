---
title: Systemanforderungen
type: docs
weight: 60
url: /de/java/system-requirements/
keywords:
- Systemanforderungen
- unterstützte Plattformen
- Java-Versionen
- JDK
- JRE
- fontconfig
- Schriften
- Docker
- Alpine
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Prüfen Sie, was Aspose.Slides for Java vor der Installation benötigt: die unterstützten Java-Versionen und Betriebssysteme sowie die Schriftbibliothek und Schriften, die Linux erfordert."
---
## **Einführung**

Aspose.Slides for Java ist eine eigenständige Bibliothek: Sie benötigt weder Microsoft PowerPoint noch Microsoft Office. Es handelt sich um eine einzelne JAR‑Datei, die im Maven‑Repository von Aspose veröffentlicht wird. Die JAR‑Datei enthält nur Java‑Klassen und Ressourcen, ohne native Bibliotheken, und deklariert keine Abhängigkeiten von anderen Bibliotheken. Die gleiche Datei läuft daher auf jedem Betriebssystem und Prozessor, für den eine unterstützte Java‑Runtime verfügbar ist.

Dieser Artikel listet die unterstützten Java‑Versionen und Betriebssysteme sowie die Schriftbibliothek und Schriften, die Linux benötigt, und endet mit einem kurzen Programm, das Ihre Umgebung überprüft. Zum Hinzufügen der Bibliothek zu einem Projekt siehe [Installation](/slides/de/java/installation/).

## **Unterstützte Java‑Versionen**

Aspose.Slides for Java läuft auf Java 8 oder höher, mit einem JDK oder einer JRE. Dies umfasst die langfristig unterstützten Releases Java 8, 11, 17, 21 und 25 sowie spätere Releases wie Java 26 und Java 27. Die Java‑Runtime kann von jedem Anbieter stammen, zum Beispiel Eclipse Temurin, Amazon Corretto, Oracle oder den OpenJDK‑Paketen einer Linux‑Distribution.

Aspose.Slides benötigt keine JVM‑Optionen, wie `--add-opens`, in irgendeiner dieser Versionen. Unter Java 11 gibt die JVM eine Warnung aus, die mit „WARNING: An illegal reflective access operation has occurred“ beginnt; die Warnung beeinträchtigt das Ergebnis nicht.

{{% alert color="warning" title="Warning" %}}
Java 6 und Java 7 sind veraltet. Aspose.Slides for Java 26.9 läuft noch darauf, gibt aber eine Deprecation‑Warnung aus. Ab Version 26.10 ist Java 8 das Minimum, und Java 6 sowie Java 7 werden nicht mehr unterstützt.
{{% /alert %}}

Das Maven‑Projekt und die Befehle in [Installation](/slides/de/java/installation/) benötigen JDK 11 oder höher. Mit Java 8 kompilieren und führen Sie Ihr Programm wie in [Check Your Setup](#check-your-setup) gezeigt aus.

## **Unterstützte Betriebssysteme**

Da die JAR‑Datei keinen nativen Code enthält, läuft Aspose.Slides for Java auf Windows, Linux und macOS, auf jeder Prozessorarchitektur, die die Java‑Runtime unterstützt, wie x64 und ARM64. Die Java‑Runtime ist die einzige Anforderung unter Windows. Unter Linux benötigt die Schriftunterstützung der Java‑Runtime zudem die in [Linux](#linux) beschriebene Schriftbibliothek und Schriften.

## **Linux**

Aspose.Slides for Java legt Text an und zeichnet ihn mit der Schriftunterstützung der Java‑Runtime. Unter Linux erfordert diese Unterstützung die fontconfig‑Bibliothek und mindestens eine installierte Schrift. Offizielle Container‑Images von Linux‑Distributionen enthalten oft beides nicht. Ohne sie schlägt das erste Beispiel in [Create Presentations](/slides/de/java/create-presentation/) beim Speichern der Präsentation fehl, erzeugt eine leere Datei und meldet folgenden Fehler:

```text
java.lang.RuntimeException: Fontconfig head is null, check your fonts or fonts configuration
```

Die offiziellen `eclipse-temurin`‑Container‑Images für Ubuntu und Alpine Linux enthalten bereits fontconfig und die DejaVu‑Schriften, sodass dort nichts installiert werden muss. Auf anderen Systemen installieren Sie die unten aufgeführten Pakete. Die Debian‑, Ubuntu‑ und Red‑Hat‑Befehle verwenden `sudo`; in einem Dockerfile führen Sie sie in einer `RUN`‑Anweisung ohne `sudo` aus. Die DejaVu‑Schriften reichen aus, damit Aspose.Slides läuft; die Schriften, die Ihre Präsentationen verwenden, werden in [Fonts](#fonts) behandelt.

### **Debian und Ubuntu**

Wenn Sie Java aus den Debian‑ oder Ubuntu‑Paketen mit den Standard‑`apt-get`‑Einstellungen installieren, wie es der Befehl in [Installation](/slides/de/java/installation/#linux) tut, installieren die Java‑Pakete auch die fontconfig‑Bibliothek, die DejaVu‑Schriften und die HarfBuzz‑Bibliothek, die diese Java‑Pakete benötigen, und es ist sonst nichts weiter nötig.

Bei einer Java‑Runtime aus einer anderen Quelle, etwa einem Eclipse Temurin‑Archiv, installieren Sie fontconfig und die DejaVu‑Schriften:

```bash
sudo apt-get update && sudo apt-get install -y fontconfig fonts-dejavu-core
```

Ein Dockerfile installiert häufig die Debian‑ oder Ubuntu‑Java‑Pakete, z. B. `openjdk-21-jdk-headless` oder `default-jdk-headless`, mit der Option `--no-install-recommends`, wodurch alle drei Komponenten übersprungen werden. Installieren Sie fontconfig und die DejaVu‑Schriften mit dem obigen Befehl und zusätzlich HarfBuzz:

```bash
sudo apt-get install -y libharfbuzz0b
```

Ohne HarfBuzz geben diese Java‑Pakete die Meldung `Please install the openjdk-*-jre package or recommended packages for openjdk-*-jre-headless` aus, und das Speichern schlägt mit einem `UnsatisfiedLinkError` fehl, der berichtet, dass `libharfbuzz.so.0` nicht geöffnet werden kann.

### **Red Hat Enterprise Linux**

Die Pakete `java-<version>-openjdk-headless` von Red Hat Enterprise Linux installieren die fontconfig‑Bibliothek nicht. Installieren Sie sie zusammen mit den DejaVu‑Schriften:

```bash
sudo dnf install -y fontconfig dejavu-sans-fonts
```

Die vollständigen Pakete `java-<version>-openjdk` installieren fontconfig und Schriften als Abhängigkeiten, ebenso die Amazon Corretto‑Pakete von Amazon Linux 2023, z. B. `java-21-amazon-corretto-headless`.

### **Alpine Linux**

In einem Dockerfile auf Basis von Alpine Linux installieren Sie fontconfig und die DejaVu‑Schriften:

```dockerfile
RUN apk add --no-cache fontconfig ttf-dejavu
```

In aktuellen Alpine‑Releases installiert `ttf-dejavu` das Paket `font-dejavu`. Installieren Sie Java mit dem Paket `openjdk<version>-jre` oder `openjdk<version>-jdk`, z. B. `openjdk25-jdk`. Die Pakete `openjdk<version>-jre-headless` von Alpine Linux enthalten die Schriftbibliothek von Java nicht, sodass das Programm mit `UnsatisfiedLinkError: no fontmanager in system library path` fehlschlägt, selbst wenn Schriften installiert sind.

### **Schriften**

Damit Text mit den richtigen Schriften und Metriken dargestellt wird, müssen die in Ihren Präsentationen verwendeten Schriften oder geeignete Ersatzschriften auf dem System installiert oder von Ihrer Anwendung geladen werden. Siehe [Deploy Fonts](/slides/de/java/deploy-fonts/), [Font Substitution](/slides/de/java/font-substitution/) und [Custom Fonts](/slides/de/java/custom-font/).

## **Check Your Setup**

Um zu prüfen, ob die Bibliothek und ihre Voraussetzungen vorhanden sind, führen Sie ein Programm aus, das eine Präsentation speichert und eine Folie zu einem Bild rendert. Speichern und Rendern verwenden die Schriftunterstützung der Java‑Runtime, die durch die oben genannten Linux‑Anforderungen bereitgestellt wird.

Speichern Sie den nachfolgenden Code als *CheckSetup.java* in dem Ordner, der die Aspose.Slides‑JAR‑Datei enthält. Zum Herunterladen der JAR‑Datei siehe [Use the JAR File without Maven](/slides/de/java/installation/#use-the-jar-file-without-maven).

```java
import com.aspose.slides.*;

public class CheckSetup {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            // Füge ein Rechteck mit Text zur ersten Folie hinzu und speichere die Präsentation.
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            shape.getTextFrame().setText("Hello, Aspose.Slides!");
            presentation.save("hello.pptx", SaveFormat.Pptx);

            // Render die Folie mit einem Pixel pro Punkt und speichere das Bild.
            IImage image = slide.getImage(1f, 1f);
            try {
                image.save("hello.png", ImageFormat.Png);
            } finally {
                image.dispose();
            }
        } finally {
            presentation.dispose();
        }
    }
}
```

Mit JDK 11 oder höher führen Sie das Programm in diesem Ordner mit dem untenstehenden Befehl aus. Hat Ihre JAR‑Datei einen anderen Namen, passen Sie den Namen in den Befehlen an.

```bash
java -cp aspose-slides-26.10-jdk8.jar CheckSetup.java
```

Mit Java 8 oder auf einem System, das nur eine JRE hat, kompilieren Sie das Programm mit `javac` aus einem JDK und führen dann die kompilierte Klasse aus. Unter Linux und macOS führen Sie aus:

```bash
javac -cp aspose-slides-26.10-jdk8.jar CheckSetup.java
java -cp aspose-slides-26.10-jdk8.jar:. CheckSetup
```

Unter Windows führen Sie denselben `javac`‑Befehl aus und starten anschließend die Klasse mit einem Semikolon als Klassenpfad‑Trennzeichen. Behalten Sie die Anführungszeichen bei, damit PowerShell das Semikolon nicht als Befehlsende interpretiert: `java -cp "aspose-slides-26.10-jdk8.jar;." CheckSetup`.

Das Programm fügt der ersten Folie ein Rechteck mit Text hinzu und speichert die Präsentation als *hello.pptx* mit der [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-)‑Methode. Anschließend rendert es die Folie mit [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#getImage-float-float-) und speichert das Ergebnis als *hello.png* mit [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) im [ImageFormat.Png](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/)-Format. Die Skalierungsfaktoren von 1 erzeugen einen Pixel pro Punkt, sodass die Standard‑720 × 540‑Punkt‑Foliengröße zu einem 720 × 540‑Pixel‑Bild wird, wobei der Text im Rechteck sichtbar ist. Ohne Lizenz enthalten beide Dateien ein Evaluations‑Wasserzeichen; siehe [Licensing](/slides/de/java/licensing/). Fehlt eine Voraussetzung, bricht das Programm mit einem der in [Linux](#linux) beschriebenen Fehler ab.

## **Entwicklungstools**

Sie können Anwendungen, die Aspose.Slides verwenden, mit jedem JDK einer unterstützten Java‑Version erstellen. Verwenden Sie Apache Maven mit Asposes Maven‑Repository, wie in [Installation](/slides/de/java/installation/) beschrieben, oder ein beliebiges andere Build‑Tool, das ein Maven‑Repository nutzen kann. Sie können die JAR‑Datei auch selbst zum Klassenpfad Ihrer IDE oder Ihres Build‑Tools hinzufügen.

## **FAQ**

**Benötige ich Microsoft PowerPoint für Konvertierungen und Rendern?**

Nein, PowerPoint ist nicht erforderlich. Aspose.Slides ist eine eigenständige Engine zum [Erstellen](/slides/de/java/create-presentation/), Ändern, [Konvertieren](/slides/de/java/convert-presentation/) und [Rendern](/slides/de/java/convert-powerpoint-to-png/) von Präsentationen.

**Benötigt Aspose.Slides for Java auf einem Linux‑Server ein Display oder eine Desktop‑Umgebung?**

Nein. Aspose.Slides benötigt keinen X‑Server oder ein Display und läuft daher auf Servern und in Containern. Unter Linux benötigt es nur die in [Linux](#linux) beschriebene Schriftbibliothek und Schriften.

**Welche Schriften werden für eine korrekte Darstellung benötigt?**

Die in der Präsentation verwendeten Schriften oder geeignete [Ersatzschriften](/slides/de/java/font-substitution/) müssen verfügbar sein. Unter Linux und macOS installieren Sie die Schriftpakete, die Ihre Präsentationen benötigen, um ein konsistentes Rendering zu gewährleisten.

**Warum wird eine benutzerdefinierte Schrift unter Linux als Ersatz‑ oder Fehltext dargestellt?**

Wenn die Schriftdatei inkonsistente oder beschädigte Name‑Table‑Einträge besitzt, kann der Linux‑Font‑Matching‑Stack (FreeType/fontconfig) einen ungültigen Eintrag auswählen, wodurch die Schrift nicht aufgelöst wird. Die Verwendung einer Schriftversion mit korrigierten Name‑Table‑Einträgen oder das Installieren eines konsistenten Ersatzes löst das Problem.