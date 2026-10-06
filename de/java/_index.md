---
title: Aspose.Slides für Java
second_title: Aspose.Slides für Java
type: docs
weight: 20
url: /de/java/
keywords:
- Dokumentation
- Präsentationsverarbeitung
- Präsentationskonvertierung
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "Starten Sie hier: Installieren Sie Aspose.Slides für Java, erstellen Sie eine erste Präsentation und finden Sie die Anleitungen für gängige Aufgaben, Bereitstellung und die API-Referenz."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Java ist eine Klassenbibliothek zum Erstellen, Lesen, Bearbeiten und Konvertieren von PowerPoint- und OpenDocument-Präsentationen in Java-Anwendungen, ohne Microsoft PowerPoint.

Sie lädt und speichert PPT, PPTX, PPS, POT und ODP, einschließlich makroaktivierter und Vorlagenvarianten, und exportiert in PDF, XPS, HTML, SVG, TIFF, Markdown und Bilder.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Erste Schritte</b></p>
<hr>
<p>GETTING STARTED</p>
<ul>
<li><a href="/slides/de/java/installation/">Installation</a></li>
<li><a href="/slides/de/java/create-presentation/">Erste Präsentation erstellen</a></li>
<li><a href="/slides/de/java/system-requirements/">Systemanforderungen</a></li>
<li><a href="/slides/de/java/getting-started/">Leitfaden für den Einstieg</a></li>
</ul>
<p>EVALUIEREN</p>
<ul>
<li><a href="/slides/de/java/supported-file-formats/">Unterstützte Dateiformate</a></li>
<li><a href="/slides/de/java/features-overview/">Übersicht der Funktionen</a></li>
<li><a href="/slides/de/java/evaluate-aspose-slides/">Einschränkungen der Testversion</a></li>
<li><a href="/slides/de/java/licensing/">Lizenzierung</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Mit Slides entwickeln</b></p>
<hr>
<p>ALLGEMEINE AUFGABEN</p>
<ul>
<li><a href="/slides/de/java/open-presentation/">Eine Präsentation öffnen</a></li>
<li><a href="/slides/de/java/save-presentation/">Eine Präsentation speichern</a></li>
<li><a href="/slides/de/java/convert-powerpoint-to-pdf/">In PDF konvertieren</a></li>
<li><a href="/slides/de/java/convert-slide/">Folien als Bilder rendern</a></li>
<li><a href="/slides/de/java/manage-text/">Text und Formen bearbeiten</a></li>
</ul>
<p>SLIDES-ARBEITSABLAUFE</p>
<ul>
<li><a href="/slides/de/java/powerpoint-charts/">Diagramme</a></li>
<li><a href="/slides/de/java/powerpoint-animation/">Animationen</a></li>
<li><a href="/slides/de/java/manage-media-files/">Audio und Video</a></li>
<li><a href="/slides/de/java/presentation-design/">Folien-Design</a></li>
<li><a href="/slides/de/java/merge-presentation/">Präsentationen zusammenführen</a></li>
</ul>
<p>BEISPIELE</p>
<ul>
<li><a href="/slides/de/java/examples/">Beispiele nach Folienelement</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Java">Beispiele auf GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Bereitstellung &amp; Support</b></p>
<hr>
<p>DEPLOY</p>
<ul>
<li><a href="/slides/de/java/system-requirements/#linux">Linux-Voraussetzungen</a></li>
<li><a href="/slides/de/java/how-to-run-aspose-slides-in-docker/">In Docker ausführen</a></li>
<li><a href="/slides/de/java/deploy-fonts/">Schriftarten</a></li>
<li><a href="/slides/de/java/security/">Sicherheit</a></li>
</ul>
<p>REFERENZ</p>
<ul>
<li><a href="https://reference.aspose.com/slides/de/java/">API-Referenz</a></li>
<li><a href="https://releases.aspose.com/slides/de/java/release-notes/">Versionshinweise</a></li>
<li><a href="/slides/de/java/known-issues/">Bekannte Probleme</a></li>
<li><a href="/slides/de/java/api-limitations/">Einschränkungen der Ausgabemetadaten</a></li>
<li><a href="https://releases.aspose.com/slides/de/java/">Download</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/de/11">Kostenloses Support-Forum</a></li>
<li><a href="https://helpdesk.aspose.com/">Kostenpflichtiger Support-Helpdesk</a></li>
</ul>
</div>
</div>

------

<a name="your-first-presentation"></a>

## **Ihre erste Präsentation**

Aspose.Slides for Java wird im eigenen Maven-Repository von Aspose veröffentlicht, nicht im Maven Central. Erstellen Sie einen Ordner für ein Maven-Projekt und speichern Sie diese *pom.xml* darin. Sie deklariert das Repository, fügt die Bibliothek hinzu und nennt die auszuführende Klasse:

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

Speichern Sie diesen Code als *src/main/java/HelloSlides.java*:

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // Erstelle eine Präsentation. Sie enthält bereits eine leere Folie.
        Presentation presentation = new Presentation();
        try {
            // Hole die erste Folie.
            ISlide slide = presentation.getSlides().get_Item(0);

            // Füge eine Wolkenform hinzu und setze Text hinein.
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // Speichere die Präsentation als PPTX-Datei.
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Führen Sie anschließend, mit installiertem JDK 11 oder höher und Apache Maven, diesen Befehl im Projektordner aus:

```bash
mvn compile exec:java
```

Das Programm speichert *new_presentation.pptx* im Projektordner, mit einer Folie, die eine Wolkenform mit Text enthält. Unter Linux müssen fontconfig und mindestens eine Schriftart installiert sein; siehe [Installation](/slides/de/java/installation/#linux). Ohne Lizenz enthält die gespeicherte Datei ein Evaluationswasserzeichen — siehe [Lizenzierung](/slides/de/java/licensing/). Weitere Möglichkeiten zum Erstellen und Befüllen einer Präsentation finden Sie unter [Präsentationen erstellen](/slides/de/java/create-presentation/).