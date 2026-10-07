---
title: Aspose.Slides a JasperReports-hez
second_title: Aspose.Slides a JasperReports-hez
type: docs
weight: 70
url: /hu/jasperreports/
keywords:
- dokumentáció
- JasperReports
- JasperReports Server
- jelentés exportálás
- PowerPoint
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Kezdje itt: telepítse az Aspose.Slides for JasperReports‑t, exportálja az első jelentést PowerPoint‑ba, és találja meg az exportálásra, a JasperReports Server integrációra és a támogatásra vonatkozó útmutatókat."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for JasperReports" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Az Aspose.Slides for JasperReports PowerPoint exportálókat ad hozzá a JasperReports Library-hez és a JasperReports Server-hez, így a Java‑alkalmazások és a jelentésszerverek a kitöltött jelentéseket prezentációként menthetik a Microsoft PowerPoint nélkül.

Egy kitöltött jelentést PPT‑re és PPTX‑re exportál, egy diát egy jelentésoldalra, valamint PDF‑re és HTML‑re.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Első lépések</b></p>
<hr>
<p>Kezdés</p>
<ul>
<li><a href="/slides/hu/jasperreports/installing-aspose-slides-for-jasperreports/">Telepítés</a></li>
<li><a href="/slides/hu/jasperreports/product-overview/">Termék áttekintés</a></li>
<li><a href="/slides/hu/jasperreports/system-requirements/">Rendszerkövetelmények</a></li>
<li><a href="/slides/hu/jasperreports/getting-started/">Első lépések útmutató</a></li>
</ul>
<p>ÉRTÉKELÉS</p>
<ul>
<li><a href="/slides/hu/jasperreports/supported-file-formats/">Támogatott fájlformátumok</a></li>
<li><a href="/slides/hu/jasperreports/evaluate-aspose-slides/">Kipróbálási korlátozások</a></li>
<li><a href="/slides/hu/jasperreports/licensing/">Licencelés</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Diák használatával</b></p>
<hr>
<p>EXPORTÁLÁS</p>
<ul>
<li><a href="/slides/hu/jasperreports/ppt-pptx-pdf-and-html-export/">Exportálás PPT, PPTX, PDF és HTML formátumokba</a></li>
<li><a href="/slides/hu/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts">Betűkészletek feltérképezése</a></li>
<li><a href="/slides/hu/jasperreports/integration-with-jasperserver/">JasperReports Server integráció</a></li>
</ul>
<p>PELDÁK</p>
<ul>
<li><a href="/slides/hu/jasperreports/demos-setup/">Demo projektek</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referencia &amp; Támogatás</b></p>
<hr>
<p>REFERENCIA</p>
<ul>
<li><a href="https://releases.aspose.com/slides/jasperreport/release-notes/">Kiadási jegyzetek</a></li>
<li><a href="https://products.aspose.com/slides/jasperreports/">Termékoldal</a></li>
<li><a href="https://releases.aspose.com/slides/jasperreport/">Letöltés</a></li>
</ul>
<p>TÁMOGATÁS</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Ingyenes támogatási fórum</a></li>
<li><a href="https://helpdesk.aspose.com/">Fizetett támogatási helpdesk</a></li>
</ul>
</div>
</div>

------

## **Az első exportálásod**

Ezek a lépések egy egyvonalas jelentést fordítanak le, töltik ki, és exportálják PPTX formátumba a JasperReports 6.16.0 verzióval a Maven Centralból. JDK 11 vagy újabb, valamint Apache Maven szükséges.

1. Töltse le a ZIP‑fájlt a [letöltési oldal](https://releases.aspose.com/slides/jasperreport/)-ról, és csomagolja ki. A *lib* mappában minden JasperReports verziótartományhoz egy almappa van, és mindegyik a megfelelő jar‑t tartalmazza. A JasperReports 6.16.0 esetén másolja a *lib/JasperReports 6.5.0 - 6.16.0 (JDK 1.6)/aspose.slides.jasperreports.library-26.6.jar* fájlt egy üres projektmappába.

2. A jar a ZIP‑ben van, nem Maven tárolóból, ezért telepítse a helyi Maven tárolójába. Futtassa ezt a parancsot a projektmappában:

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

3. Mentse el ezt a *pom.xml* fájlt a projektmappába. Hozzáadja a JasperReports 6.16.0‑t és a telepített jar‑t, valamint megadja a futtatandó osztályt. A JasperReports 6.16.0 egy javított iText‑verziót deklarál, amely nincs a Maven Centralon, ezért a fájl kihagyja azt; az Aspose exportálók nem igénylik.

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

4. Mentse el ezt a jelentésdizájnt *hello.jrxml* néven a projektmappába. Egy sor szöveget nyomtat a címsávban:

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

5. Mentse el ezt a kódot *src/main/java/HelloExport.java* néven. Lefordítja a dizájnt, egy üres rekorddal tölti ki, és exportálja az eredményt az `ASPptxExporter`‑rel:

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
        // A jelentésdizájn lefordítása és kitöltése egy üres rekorddal.
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // A kitöltött jelentés exportálása PPTX-be.
        ASPptxExporter exporter = new ASPptxExporter();
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "hello.pptx");
        exporter.exportReport();
    }
}
```

6. Futtassa ezt a parancsot a projektmappában:

```bash
mvn compile exec:java
```

A program a *hello.pptx* fájlt a projektmappába menti, egyetlen diával, amely a jelentés szövegét tartalmazza. A fordító megjegyzi, hogy a kód elavult API‑t használ: az exportálók a bemenetet és kimenetet a `JRExporterParameter`‑en keresztül kapják, és nem fogadják el a új `setExporterInput` és `setExporterOutput` konfigurációt. Linuxon a fontconfig‑nek és legalább egy betűkészletnek telepítve kell lennie, különben a jelentés kitöltése hibát eredményez. Licenc nélkül minden dia közepén egy értékelési vízjel jelenik meg – lásd a [Licencelés](/slides/hu/jasperreports/licensing/) oldalt. PPT, PDF vagy HTML exportálásához lásd a [PPT, PPTX, PDF és HTML exportálás](/slides/hu/jasperreports/ppt-pptx-pdf-and-html-export/) oldalt.