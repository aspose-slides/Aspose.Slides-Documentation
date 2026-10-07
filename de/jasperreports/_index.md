---
title: Aspose.Slides für JasperReports
second_title: Aspose.Slides für JasperReports
type: docs
weight: 70
url: /de/jasperreports/
keywords:
- Dokumentation
- JasperReports
- JasperReports Server
- Berichtsexport
- PowerPoint
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Starten Sie hier: Installieren Sie Aspose.Slides für JasperReports, exportieren Sie einen ersten Bericht nach PowerPoint und finden Sie die Anleitungen für den Export, die Integration in JasperReports Server und den Support."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for JasperReports" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for JasperReports fügt der JasperReports Library und dem JasperReports Server PowerPoint‑Exporter hinzu, sodass Java‑Anwendungen und Reporting‑Server ausgefüllte Berichte als Präsentationen ohne Microsoft PowerPoint speichern können.

Es exportiert einen ausgefüllten Bericht in PPT und PPTX, eine Folie pro Berichtseite, sowie nach PDF und HTML.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Erste Schritte</b></p>
<hr>
<p>ERSTE SCHRITTE</p>
<ul>
<li><a href="/slides/de/jasperreports/installing-aspose-slides-for-jasperreports/">Installation</a></li>
<li><a href="/slides/de/jasperreports/product-overview/">Produktübersicht</a></li>
<li><a href="/slides/de/jasperreports/system-requirements/">Systemanforderungen</a></li>
<li><a href="/slides/de/jasperreports/getting-started/">Leitfaden für den Einstieg</a></li>
</ul>
<p>EVALUIEREN</p>
<ul>
<li><a href="/slides/de/jasperreports/supported-file-formats/">Unterstützte Dateiformate</a></li>
<li><a href="/slides/de/jasperreports/evaluate-aspose-slides/">Einschränkungen der Testversion</a></li>
<li><a href="/slides/de/jasperreports/licensing/">Lizenzierung</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Erstellen mit Slides</b></p>
<hr>
<p>EXPORT</p>
<ul>
<li><a href="/slides/de/jasperreports/ppt-pptx-pdf-and-html-export/">Export nach PPT, PPTX, PDF und HTML</a></li>
<li><a href="/slides/de/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts">Schriftarten zuordnen</a></li>
<li><a href="/slides/de/jasperreports/integration-with-jasperserver/">Integration in JasperReports Server</a></li>
</ul>
<p>BEISPIELE</p>
<ul>
<li><a href="/slides/de/jasperreports/demos-setup/">Demo‑Projekte</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referenz &amp; Support</b></p>
<hr>
<p>REFERENZ</p>
<ul>
<li><a href="https://releases.aspose.com/slides/jasperreport/release-notes/">Versionshinweise</a></li>
<li><a href="https://products.aspose.com/slides/jasperreports/">Produktseite</a></li>
<li><a href="https://releases.aspose.com/slides/jasperreport/">Herunterladen</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Kostenloses Support‑Forum</a></li>
<li><a href="https://helpdesk.aspose.com/">Kostenpflichtiger Support‑Helpdesk</a></li>
</ul>
</div>
</div>

------

## **Ihr erster Export**

Diese Schritte kompilieren einen Ein‑Zeilen‑Bericht, füllen ihn und exportieren ihn mit JasperReports 6.16.0 aus Maven Central zu PPTX. Sie benötigen JDK 11 oder höher und Apache Maven.

1. Laden Sie das ZIP von der [Download-Seite](https://releases.aspose.com/slides/jasperreport/) herunter und entpacken Sie es. Sein *lib*-Ordner enthält für jede JasperReports‑Versionen‑Spanne einen Unterordner, der das jeweilige JAR enthält. Für JasperReports 6.16.0 kopieren Sie *lib/JasperReports 6.5.0 - 6.16.0 (JDK 1.6)/aspose.slides.jasperreports.library-26.6.jar* in einen leeren Projektordner.

2. Das JAR befindet sich im ZIP und nicht in einem Maven‑Repository, daher installieren Sie es in Ihr lokales Maven‑Repository. Führen Sie diesen Befehl im Projektordner aus:

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

3. Speichern Sie diese *pom.xml* im Projektordner. Sie fügt JasperReports 6.16.0 und das von Ihnen installierte JAR hinzu und benennt die auszuführende Klasse. JasperReports 6.16.0 deklariert einen gepatchten iText‑Build, der nicht in Maven Central verfügbar ist, daher wird er in der Datei ausgeschlossen; die Aspose‑Exporter benötigen ihn nicht.

```xml
<project xmlns="http://maven.apache.org/POM/4.0.0">
    <modelVersion>4.0.0</modelVersion>
    <groupId>com.example</groupId>
    <artifactId>hello-jasper-export</artifactId>
    <version>1.0</version>

    <properties>
        <maven.compiler.release>11</maven.compiler.release>
        <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
        <exec.mainClass>HelloExport</exec.mainClass>
    </properties>

    <dependencies>
        <dependency>
            <groupId>net.sf.jasperreports</groupId>
            <artifactId>jasperreports</artifactId>
            <version>6.16.0</version>
            <exclusions>
                <exclusion>
                    <groupId>com.lowagie</groupId>
                    <artifactId>itext</artifactId>
                </exclusion>
            </exclusions>
        </dependency>
        <dependency>
            <groupId>com.aspose</groupId>
            <artifactId>aspose-slides-jasperreports</artifactId>
            <version>26.6</version>
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

4. Speichern Sie dieses Report‑Design als *hello.jrxml* im Projektordner. Es gibt eine Textzeile im Titelband aus:

```xml
<?xml version="1.0" encoding="UTF-8"?>
<jasperReport xmlns="http://jasperreports.sourceforge.net/jasperreports"
        xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
        xsi:schemaLocation="http://jasperreports.sourceforge.net/jasperreports http://jasperreports.sourceforge.net/xsd/jasperreport.xsd"
        name="Hello" pageWidth="595" pageHeight="842" columnWidth="555"
        leftMargin="20" rightMargin="20" topMargin="20" bottomMargin="20">
    <title>
        <band height="50">
            <staticText>
                <reportElement x="0" y="0" width="555" height="40"/>
                <textElement>
                    <font size="24"/>
                </textElement>
                <text><![CDATA[Hello from JasperReports!]]></text>
            </staticText>
        </band>
    </title>
</jasperReport>
```

5. Speichern Sie diesen Code als *src/main/java/HelloExport.java*. Er kompiliert das Design, füllt es mit einem leeren Datensatz und exportiert das Ergebnis mit `ASPptxExporter`:

```java
import java.util.HashMap;

import com.aspose.slides.jasperreports.ASPptxExporter;
import net.sf.jasperreports.engine.JREmptyDataSource;
import net.sf.jasperreports.engine.JRExporterParameter;
import net.sf.jasperreports.engine.JasperCompileManager;
import net.sf.jasperreports.engine.JasperFillManager;
import net.sf.jasperreports.engine.JasperPrint;
import net.sf.jasperreports.engine.JasperReport;

public class HelloExport {
    public static void main(String[] args) throws Exception {
        // Kompiliere das Berichtslayout und fülle es mit einem leeren Datensatz.
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // Exportiere den ausgefüllten Bericht nach PPTX.
        ASPptxExporter exporter = new ASPptxExporter();
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "hello.pptx");
        exporter.exportReport();
    }
}
```

6. Führen Sie diesen Befehl im Projektordner aus:

```bash
mvn compile exec:java
```

Das Programm speichert *hello.pptx* im Projektordner, mit einer Folie, die den Text des Berichts enthält. Der Compiler weist darauf hin, dass der Code eine veraltete API verwendet: Die Exporter erhalten ihre Eingabe und Ausgabe über `JRExporterParameter` und akzeptieren nicht die neuere Konfiguration `setExporterInput` und `setExporterOutput`. Unter Linux müssen fontconfig und mindestens eine Schriftart installiert sein, sonst schlägt das Füllen des Berichts fehl. Ohne Lizenz trägt jede Folie ein Evaluations‑Wasserzeichen in der Mitte — siehe [Lizenzierung](/slides/de/jasperreports/licensing/). Zum Exportieren nach PPT, PDF oder HTML, siehe [PPT, PPTX, PDF und HTML Export](/slides/de/jasperreports/ppt-pptx-pdf-and-html-export/).