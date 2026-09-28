---
title: Aspose.Slides for JasperReports
second_title: Aspose.Slides for JasperReports
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
description: "Starten Sie hier: Installieren Sie Aspose.Slides for JasperReports, exportieren Sie einen ersten Bericht nach PowerPoint und finden Sie die Anleitungen für den Export, die Integration von JasperReports Server und den Support."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for JasperReports" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for JasperReports fügt PowerPoint‑Exportierer zu JasperReports Library und JasperReports Server hinzu, sodass Java‑Anwendungen und Berichtserver ausgefüllte Berichte als Präsentationen speichern können, ohne Microsoft PowerPoint.

Es exportiert einen ausgefüllten Bericht nach PPT und PPTX, eine Folie pro Berichtseite, und außerdem nach PDF und HTML.

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
<li><a href="/slides/de/jasperreports/getting-started/">Einsteiger‑Leitfaden</a></li>
</ul>
<p>EVALUATE</p>
<ul>
<li><a href="/slides/de/jasperreports/supported-file-formats/">Unterstützte Dateiformate</a></li>
<li><a href="/slides/de/jasperreports/evaluate-aspose-slides/">Testversion‑Einschränkungen</a></li>
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
<p><b>Reference &amp; Support</b></p>
<hr>
<p>REFERENCE</p>
<ul>
<li><a href="https://releases.aspose.com/slides/de/jasperreport/release-notes/">Versionshinweise</a></li>
<li><a href="https://releases.aspose.com/slides/de/jasperreport/">Download</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/de/11">Kostenloses Support‑Forum</a></li>
<li><a href="https://helpdesk.aspose.com/">Kostenpflichtiger Support‑Helpdesk</a></li>
</ul>
</div>
</div>

------

## **Ihr erster Export**

Diese Schritte erstellen einen einzeiligen Bericht, füllen ihn und exportieren ihn nach PPTX mit JasperReports 6.16.0 aus dem Maven‑Central. Sie benötigen JDK 11 oder höher sowie Apache Maven.

1. Laden Sie das ZIP von der [Download‑Seite](https://releases.aspose.com/slides/de/jasperreport/) herunter und entpacken Sie es. Sein *lib*-Ordner enthält je nach JasperReports‑Version einen Unterordner, und jeder enthält die entsprechende JAR‑Datei. Für JasperReports 6.16.0 kopieren Sie *lib/JasperReports 6.5.0 - 6.16.0 (JDK 1.6)/aspose.slides.jasperreports.library-26.6.jar* in einen leeren Projektordner.

2. Die JAR‑Datei befindet sich im ZIP und nicht in einem Maven‑Repository, daher installieren Sie sie in Ihr lokales Maven‑Repository. Führen Sie diesen Befehl im Projektordner aus:

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

3. Speichern Sie diese *pom.xml* im Projektordner. Sie fügt JasperReports 6.16.0 und die installierte JAR‑Datei hinzu und gibt die auszuführende Klasse an. JasperReports 6.16.0 deklariert einen gepatchten iText‑Build, der nicht im Maven‑Central verfügbar ist, daher wird er aus der Datei ausgeschlossen; die Aspose‑Exporter benötigen ihn nicht.

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

4. Speichern Sie dieses Bericht‑Design als *hello.jrxml* im Projektordner. Es gibt eine Textzeile im Titel‑Band aus:

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
        // Kompiliere das Berichtdesign und fülle es mit einem leeren Datensatz.
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

Das Programm speichert *hello.pptx* im Projektordner, mit einer Folie, die den Text des Berichts enthält. Der Compiler weist darauf hin, dass der Code eine veraltete API verwendet: Die Exporter übernehmen Eingabe und Ausgabe über `JRExporterParameter` und unterstützen nicht die neuere Konfiguration `setExporterInput` und `setExporterOutput`. Unter Linux müssen fontconfig und mindestens eine Schriftart installiert sein, sonst schlägt das Befüllen des Berichts fehl. Ohne Lizenz enthält jede Folie ein Evaluations‑Wasserzeichen in der Mitte — siehe [Lizenzierung](/slides/de/jasperreports/licensing/). Zum Export nach PPT, PDF oder HTML siehe [Export nach PPT, PPTX, PDF und HTML](/slides/de/jasperreports/ppt-pptx-pdf-and-html-export/).