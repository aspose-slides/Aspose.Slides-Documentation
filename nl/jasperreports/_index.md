---
title: Aspose.Slides for JasperReports
second_title: Aspose.Slides for JasperReports
type: docs
weight: 70
url: /nl/jasperreports/
keywords:
- documentatie
- JasperReports
- JasperReports Server
- rapportexport
- PowerPoint
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Begin hier: Installeer Aspose.Slides for JasperReports, exporteer een eerste rapport naar PowerPoint, en vind de handleidingen voor export, integratie met JasperReports Server en ondersteuning."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for JasperReports" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for JasperReports voegt PowerPoint-exporteurs toe aan JasperReports Library en JasperReports Server, zodat Java-toepassingen en rapportservers ingevulde rapporten kunnen opslaan als presentaties zonder Microsoft PowerPoint.

Het exporteert een ingevuld rapport naar PPT en PPTX, één dia per rapportpagina, en ook naar PDF en HTML.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Aan de slag</b></p>
<hr>
<p>BEGINNEN</p>
<ul>
<li><a href="/slides/nl/jasperreports/installing-aspose-slides-for-jasperreports/">Installatie</a></li>
<li><a href="/slides/nl/jasperreports/product-overview/">Productoverzicht</a></li>
<li><a href="/slides/nl/jasperreports/system-requirements/">Systeemvereisten</a></li>
<li><a href="/slides/nl/jasperreports/getting-started/">Handleiding voor aan de slag</a></li>
</ul>
<p>EVALUEREN</p>
<ul>
<li><a href="/slides/nl/jasperreports/supported-file-formats/">Ondersteunde bestandsformaten</a></li>
<li><a href="/slides/nl/jasperreports/evaluate-aspose-slides/">Beperkingen van de proefversie</a></li>
<li><a href="/slides/nl/jasperreports/licensing/">Licensering</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Bouw met Slides</b></p>
<hr>
<p>EXPORTEREN</p>
<ul>
<li><a href="/slides/nl/jasperreports/ppt-pptx-pdf-and-html-export/">Exporteren naar PPT, PPTX, PDF en HTML</a></li>
<li><a href="/slides/nl/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts">Lettertypen in kaart brengen</a></li>
<li><a href="/slides/nl/jasperreports/integration-with-jasperserver/">Integratie met JasperReports Server</a></li>
</ul>
<p>VOORBEELDEN</p>
<ul>
<li><a href="/slides/nl/jasperreports/demos-setup/">Demo-projecten</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referentie &amp; Ondersteuning</b></p>
<hr>
<p>REFERENTIE</p>
<ul>
<li><a href="https://releases.aspose.com/slides/nl/jasperreport/release-notes/">Release-opmerkingen</a></li>
<li><a href="https://releases.aspose.com/slides/nl/jasperreport/">Downloaden</a></li>
</ul>
<p>ONDERSTEUNING</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/nl/11">Gratis ondersteuningsforum</a></li>
<li><a href="https://helpdesk.aspose.com/">Betaalde ondersteuningshelpdesk</a></li>
</ul>
</div>
</div>

------

## **Uw eerste export**

Deze stappen compileren een één-regel‑rapport, vullen het, en exporteren het naar PPTX met JasperReports 6.16.0 vanaf Maven Central. U heeft JDK 11 of hoger en Apache Maven nodig.

1. Download het ZIP‑bestand van de [downloadpagina](https://releases.aspose.com/slides/nl/jasperreport/) en pak het uit. De *lib*-map bevat één submap per reeks JasperReports‑versies, en elke map bevat de jar voor die reeks. Voor JasperReports 6.16.0, kopieer *lib/JasperReports 6.5.0 - 6.16.0 (JDK 1.6)/aspose.slides.jasperreports.library-26.6.jar* naar een lege projectmap.

2. De jar zit in het ZIP‑bestand in plaats van in een Maven‑repository, dus installeer hem in uw lokale Maven‑repository. Voer dit commando uit in de projectmap:

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

3. Sla dit *pom.xml* op in de projectmap. Het voegt JasperReports 6.16.0 en de geïnstalleerde jar toe, en geeft de uit te voeren klasse op. JasperReports 6.16.0 verklaart een gepatchte iText‑versie die niet op Maven Central staat, dus wordt die uit het bestand weggelaten; de Aspose‑exporteurs hebben deze niet nodig.

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

4. Sla dit rapportontwerp op als *hello.jrxml* in de projectmap. Het drukt één regel tekst af in de titelband:

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

5. Sla deze code op als *src/main/java/HelloExport.java*. Het compileert het ontwerp, vult het met één lege record, en exporteert het resultaat met `ASPptxExporter`:

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
        // Compileer het rapportontwerp en vul het met één leeg record.
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // Exporteer het ingevulde rapport naar PPTX.
        ASPptxExporter exporter = new ASPptxExporter();
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "hello.pptx");
        exporter.exportReport();
    }
}
```

6. Voer dit commando uit in de projectmap:

```bash
mvn compile exec:java
```

Het programma slaat *hello.pptx* op in de projectmap, met één dia die de tekst van het rapport bevat. De compiler geeft aan dat de code een verouderde API gebruikt: de exporteurs nemen hun invoer en uitvoer via `JRExporterParameter`, en accepteren de nieuwere configuratie `setExporterInput` en `setExporterOutput` niet. Op Linux moet fontconfig en ten minste één lettertype geïnstalleerd zijn, anders mislukt het vullen van het rapport. Zonder licentie bevat elke dia een evaluatiewatermerk in het midden — zie [Licensering](/slides/nl/jasperreports/licensing/). Om te exporteren naar PPT, PDF of HTML, zie [Export PPT, PPTX, PDF en HTML](/slides/nl/jasperreports/ppt-pptx-pdf-and-html-export/).