---
title: Aspose.Slides for JasperReports
second_title: Aspose.Slides for JasperReports
type: docs
weight: 70
url: /pl/jasperreports/
keywords:
- dokumentacja
- JasperReports
- JasperReports Server
- eksport raportu
- PowerPoint
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Zacznij tutaj: zainstaluj Aspose.Slides for JasperReports, wyeksportuj pierwszy raport do PowerPoint oraz znajdź przewodniki dotyczące eksportu, integracji z JasperReports Server i wsparcia."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for JasperReports" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for JasperReports dodaje eksportery PowerPoint do JasperReports Library i JasperReports Server, dzięki czemu aplikacje Java i serwery raportów mogą zapisywać wypełnione raporty jako prezentacje bez Microsoft PowerPoint.

Eksportuje wypełniony raport do PPT i PPTX, po jeden slajd na stronę raportu, a także do PDF i HTML.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Rozpocznij</b></p>
<hr>
<p>ROZPOCZĘCIE</p>
<ul>
<li><a href="/slides/pl/jasperreports/installing-aspose-slides-for-jasperreports/">Instalacja</a></li>
<li><a href="/slides/pl/jasperreports/product-overview/">Przegląd produktu</a></li>
<li><a href="/slides/pl/jasperreports/system-requirements/">Wymagania systemowe</a></li>
<li><a href="/slides/pl/jasperreports/getting-started/">Poradnik wprowadzający</a></li>
</ul>
<p>EWALUACJA</p>
<ul>
<li><a href="/slides/pl/jasperreports/supported-file-formats/">Obsługiwane formaty plików</a></li>
<li><a href="/slides/pl/jasperreports/evaluate-aspose-slides/">Ograniczenia wersji próbnej</a></li>
<li><a href="/slides/pl/jasperreports/licensing/">Licencjonowanie</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Twórz przy użyciu Slides</b></p>
<hr>
<p>EKSPORT</p>
<ul>
<li><a href="/slides/pl/jasperreports/ppt-pptx-pdf-and-html-export/">Eksport do PPT, PPTX, PDF i HTML</a></li>
<li><a href="/slides/pl/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts">Mapowanie czcionek</a></li>
<li><a href="/slides/pl/jasperreports/integration-with-jasperserver/">Integracja z JasperReports Server</a></li>
</ul>
<p>PRZYKŁADY</p>
<ul>
<li><a href="/slides/pl/jasperreports/demos-setup/">Projekty demonstracyjne</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Dokumentacja i wsparcie</b></p>
<hr>
<p>DOKUMENTACJA</p>
<ul>
<li><a href="https://releases.aspose.com/slides/jasperreport/release-notes/">Informacje o wydaniu</a></li>
<li><a href="https://products.aspose.com/slides/jasperreports/">Strona produktu</a></li>
<li><a href="https://releases.aspose.com/slides/jasperreport/">Pobierz</a></li>
</ul>
<p>WSPARCIE</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Forum wsparcia (bezpłatne)</a></li>
<li><a href="https://helpdesk.aspose.com/">Płatna pomoc techniczna</a></li>
</ul>
</div>
</div>

------

## **Twój pierwszy eksport**

Te kroki kompilują raport jednowierszowy, wypełniają go i eksportują do PPTX przy użyciu JasperReports 6.16.0 z Maven Central. Potrzebujesz JDK 11 lub nowszego oraz Apache Maven.

1. Pobierz plik ZIP ze [strony pobierania](https://releases.aspose.com/slides/jasperreport/) i rozpakuj go. Folder *lib* zawiera podfolder dla każdego zakresu wersji JasperReports, a każdy z nich przechowuje plik JAR dla tego zakresu. Dla JasperReports 6.16.0 skopiuj *lib/JasperReports 6.5.0 - 6.16.0 (JDK 1.6)/aspose.slides.jasperreports.library-26.6.jar* do pustego folderu projektu.

2. Plik JAR znajduje się w ZIP, a nie w repozytorium Maven, więc zainstaluj go w lokalnym repozytorium Maven. Uruchom to polecenie w folderze projektu:

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

3. Zapisz ten plik *pom.xml* w folderze projektu. Dodaje on JasperReports 6.16.0 oraz zainstalowany plik JAR i określa klasę do uruchomienia. JasperReports 6.16.0 deklaruje zmodyfikowaną wersję iText, która nie znajduje się w Maven Central, więc plik ją pomija; eksportery Aspose nie potrzebują jej.

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

4. Zapisz ten projekt raportu jako *hello.jrxml* w folderze projektu. Drukuje on jedną linię tekstu w pasku tytułu:

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

5. Zapisz ten kod jako *src/main/java/HelloExport.java*. Kompiluje on projekt, wypełnia go jednym pustym rekordem i eksportuje wynik przy użyciu `ASPptxExporter`:

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
        // Skompiluj projekt raportu i wypełnij go jednym pustym rekordem.
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // Eksportuj wypełniony raport do PPTX.
        ASPptxExporter exporter = new ASPptxExporter();
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "hello.pptx");
        exporter.exportReport();
    }
}
```

6. Uruchom to polecenie w folderze projektu:

```bash
mvn compile exec:java
```

Program zapisuje *hello.pptx* w folderze projektu, z jednym slajdem zawierającym tekst raportu. Kompilator informuje, że kod używa przestarzałego API: eksportery przyjmują wejście i wyjście poprzez `JRExporterParameter` i nie obsługują nowszej konfiguracji `setExporterInput` oraz `setExporterOutput`. W systemie Linux należy zainstalować fontconfig i przynajmniej jedną czcionkę, w przeciwnym razie wypełnianie raportu nie powiedzie się. Bez licencji każdy slajd otrzymuje znak wodny oceny w centrum — zobacz [Licencjonowanie](/slides/pl/jasperreports/licensing/). Aby eksportować do PPT, PDF lub HTML, zobacz [Eksport do PPT, PPTX, PDF i HTML](/slides/pl/jasperreports/ppt-pptx-pdf-and-html-export/).