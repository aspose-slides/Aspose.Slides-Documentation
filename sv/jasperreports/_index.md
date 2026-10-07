---
title: Aspose.Slides för JasperReports
second_title: Aspose.Slides för JasperReports
type: docs
weight: 70
url: /sv/jasperreports/
keywords:
- dokumentation
- JasperReports
- JasperReports Server
- rapportexport
- PowerPoint
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Börja här: installera Aspose.Slides för JasperReports, exportera en första rapport till PowerPoint, och hitta guiderna för export, JasperReports Server‑integration och support."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for JasperReports" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for JasperReports lägger till PowerPoint‑exportörer till JasperReports Library och JasperReports Server, så att Java‑applikationer och rapportservrar kan spara ifyllda rapporter som presentationer utan Microsoft PowerPoint.

Den exporterar en ifylld rapport till PPT och PPTX, en bild per rapportsida, samt till PDF och HTML.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Kom igång</b></p>
<hr>
<p>GETTING STARTED</p>
<ul>
<li><a href="/slides/sv/jasperreports/installing-aspose-slides-for-jasperreports/">Installation</a></li>
<li><a href="/slides/sv/jasperreports/product-overview/">Produktöversikt</a></li>
<li><a href="/slides/sv/jasperreports/system-requirements/">Systemkrav</a></li>
<li><a href="/slides/sv/jasperreports/getting-started/">Kom igång‑guide</a></li>
</ul>
<p>UTVÄRDERA</p>
<ul>
<li><a href="/slides/sv/jasperreports/supported-file-formats/">Stödda filformat</a></li>
<li><a href="/slides/sv/jasperreports/evaluate-aspose-slides/">Begränsningar för provversion</a></li>
<li><a href="/slides/sv/jasperreports/licensing/">Licensiering</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Bygg med Slides</b></p>
<hr>
<p>EXPORTERA</p>
<ul>
<li><a href="/slides/sv/jasperreports/ppt-pptx-pdf-and-html-export/">Exportera till PPT, PPTX, PDF och HTML</a></li>
<li><a href="/slides/sv/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts">Mappa teckensnitt</a></li>
<li><a href="/slides/sv/jasperreports/integration-with-jasperserver/">JasperReports Server‑integration</a></li>
</ul>
<p>EXEMPEL</p>
<ul>
<li><a href="/slides/sv/jasperreports/demos-setup/">Demo‑projekt</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referens &amp; support</b></p>
<hr>
<p>REFERENS</p>
<ul>
<li><a href="https://releases.aspose.com/slides/jasperreport/release-notes/">Versionsanteckningar</a></li>
<li><a href="https://products.aspose.com/slides/jasperreports/">Produktsida</a></li>
<li><a href="https://releases.aspose.com/slides/jasperreport/">Nedladdning</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Gratis supportforum</a></li>
<li><a href="https://helpdesk.aspose.com/">Betald supporthelpdesk</a></li>
</ul>
</div>
</div>

------

## **Din första export**

Dessa steg kompilerar en enradig rapport, fyller den och exporterar den till PPTX med JasperReports 6.16.0 från Maven Central. Du behöver JDK 11 eller senare samt Apache Maven.

1. Ladda ner ZIP‑filen från [download page](https://releases.aspose.com/slides/jasperreport/) och packa upp den. Dess *lib*-mapp har en undermapp per intervall av JasperReports‑versioner, och varje mapp innehåller JAR‑filen för det intervallet. För JasperReports 6.16.0, kopiera *lib/JasperReports 6.5.0 - 6.16.0 (JDK 1.6)/aspose.slides.jasperreports.library-26.6.jar* till en tom projektmapp.

2. JAR‑filen finns i ZIP‑filen snarare än i ett Maven‑förråd, så installera den i ditt lokala Maven‑förråd. Kör detta kommando i projektmappen:

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

3. Spara denna *pom.xml* i projektmappen. Den lägger till JasperReports 6.16.0 och den JAR‑fil du installerade, samt anger klassen som ska köras. JasperReports 6.16.0 deklarerar en patchad iText‑build som inte finns på Maven Central, så filen exkluderar den; Aspose‑exportörerna behöver den inte.

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

4. Spara denna rapportdesign som *hello.jrxml* i projektmappen. Den skriver ut en rad text i titelfältet:

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

5. Spara denna kod som *src/main/java/HelloExport.java*. Den kompilerar designen, fyller den med en tom post och exporterar resultatet med `ASPptxExporter`:

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
        // Kompilera rapportdesignen och fyll den med en tom post.
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // Exportera den ifyllda rapporten till PPTX.
        ASPptxExporter exporter = new ASPptxExporter();
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "hello.pptx");
        exporter.exportReport();
    }
}
```

6. Kör detta kommando i projektmappen:

```bash
mvn compile exec:java
```

Programmet sparar *hello.pptx* i projektmappen, med en bild som innehåller rapportens text. Kompilatorn påpekar att koden använder ett föråldrat API: exportörerna tar sin in‑ och utdata via `JRExporterParameter`, och de accepterar inte den nyare konfigurationen `setExporterInput` och `setExporterOutput`. På Linux måste fontconfig och minst ett teckensnitt vara installerade, annars misslyckas ifyllningen av rapporten. Utan licens får varje bild ett evalueringsvattenmärke i mitten — se [Licensiering](/slides/sv/jasperreports/licensing/). För att exportera till PPT, PDF eller HTML, se [PPT, PPTX, PDF och HTML‑export](/slides/sv/jasperreports/ppt-pptx-pdf-and-html-export/).