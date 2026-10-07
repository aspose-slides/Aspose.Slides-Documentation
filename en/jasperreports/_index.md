---
title: Aspose.Slides for JasperReports
second_title: Aspose.Slides for JasperReports
type: docs
weight: 70
url: /jasperreports/
keywords:
- documentation
- JasperReports
- JasperReports Server
- report export
- PowerPoint
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Start here: install Aspose.Slides for JasperReports, export a first report to PowerPoint, and find the guides for export, JasperReports Server integration and support."
is_root: true
---

<img src="home_1.png" alt="Aspose.Slides for JasperReports" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for JasperReports adds PowerPoint exporters to JasperReports Library and JasperReports Server, so that Java applications and report servers can save filled reports as presentations without Microsoft PowerPoint.

It exports a filled report to PPT and PPTX, one slide per report page, and also to PDF and HTML.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Get Started</b></p>
<hr>
<p>GETTING STARTED</p>
<ul>
<li><a href="/slides/jasperreports/installing-aspose-slides-for-jasperreports/">Installation</a></li>
<li><a href="/slides/jasperreports/product-overview/">Product overview</a></li>
<li><a href="/slides/jasperreports/system-requirements/">System requirements</a></li>
<li><a href="/slides/jasperreports/getting-started/">Getting started guide</a></li>
</ul>
<p>EVALUATE</p>
<ul>
<li><a href="/slides/jasperreports/supported-file-formats/">Supported file formats</a></li>
<li><a href="/slides/jasperreports/evaluate-aspose-slides/">Trial limitations</a></li>
<li><a href="/slides/jasperreports/licensing/">Licensing</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Build with Slides</b></p>
<hr>
<p>EXPORT</p>
<ul>
<li><a href="/slides/jasperreports/ppt-pptx-pdf-and-html-export/">Export to PPT, PPTX, PDF and HTML</a></li>
<li><a href="/slides/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts">Map fonts</a></li>
<li><a href="/slides/jasperreports/integration-with-jasperserver/">JasperReports Server integration</a></li>
</ul>
<p>EXAMPLES</p>
<ul>
<li><a href="/slides/jasperreports/demos-setup/">Demo projects</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Reference &amp; Support</b></p>
<hr>
<p>REFERENCE</p>
<ul>
<li><a href="https://releases.aspose.com/slides/jasperreport/release-notes/">Release notes</a></li>
<li><a href="https://products.aspose.com/slides/jasperreports/">Product page</a></li>
<li><a href="https://releases.aspose.com/slides/jasperreport/">Download</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Free support forum</a></li>
<li><a href="https://helpdesk.aspose.com/">Paid support helpdesk</a></li>
</ul>
</div>
</div>

------

## **Your first export**

These steps compile a one-line report, fill it, and export it to PPTX with JasperReports 6.16.0 from Maven Central. You need JDK 11 or later and Apache Maven.

1. Download the ZIP from the [download page](https://releases.aspose.com/slides/jasperreport/) and unpack it. Its *lib* folder has one subfolder per range of JasperReports versions, and each holds the jar for that range. For JasperReports 6.16.0, copy *lib/JasperReports 6.5.0 - 6.16.0 (JDK 1.6)/aspose.slides.jasperreports.library-26.6.jar* into an empty project folder.

2. The jar comes in the ZIP rather than from a Maven repository, so install it into your local Maven repository. Run this command in the project folder:

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

3. Save this *pom.xml* in the project folder. It adds JasperReports 6.16.0 and the jar you installed, and names the class to run. JasperReports 6.16.0 declares a patched iText build that is not on Maven Central, so the file excludes it; the Aspose exporters do not need it.

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

4. Save this report design as *hello.jrxml* in the project folder. It prints one line of text in the title band:

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

5. Save this code as *src/main/java/HelloExport.java*. It compiles the design, fills it with one empty record, and exports the result with `ASPptxExporter`:

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
        // Compile the report design and fill it with one empty record.
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // Export the filled report to PPTX.
        ASPptxExporter exporter = new ASPptxExporter();
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "hello.pptx");
        exporter.exportReport();
    }
}
```

6. Run this command in the project folder:

```bash
mvn compile exec:java
```

The program saves *hello.pptx* in the project folder, with one slide that holds the report's text. The compiler notes that the code uses a deprecated API: the exporters take their input and output through `JRExporterParameter`, and they do not accept the newer `setExporterInput` and `setExporterOutput` configuration. On Linux, fontconfig and at least one font must be installed, or filling the report fails. Without a license, each slide carries an evaluation watermark at its center — see [Licensing](/slides/jasperreports/licensing/). To export to PPT, PDF or HTML, see [PPT, PPTX, PDF and HTML Export](/slides/jasperreports/ppt-pptx-pdf-and-html-export/).
