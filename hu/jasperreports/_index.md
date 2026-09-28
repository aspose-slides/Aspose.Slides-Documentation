---
title: Aspose.Slides for JasperReports
second_title: Aspose.Slides for JasperReports
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
description: "Kezdje itt: telepítse az Aspose.Slides for JasperReports terméket, exportálja első jelentését PowerPointba, és találja meg az export, a JasperReports Server integráció és a támogatás útmutatóit."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for JasperReports" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Az Aspose.Slides for JasperReports PowerPoint exportálókat ad a JasperReports Library-hez és a JasperReports Server-hez, így a Java alkalmazások és jelentéskiszolgálók a kitöltött jelentéseket prezentációként menthetik anélkül, hogy a Microsoft PowerPointra lenne szükség.

Ez a kitöltött jelentést PPT és PPTX formátumba exportálja, oldalanként egy diát, valamint PDF és HTML formátumba is.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Első lépések</b></p>
<hr>
<p>ELKEZDÉS</p>
<ul>
<li><a href="/slides/hu/jasperreports/installing-aspose-slides-for-jasperreports/">Telepítés</a></li>
<li><a href="/slides/hu/jasperreports/product-overview/">Termék áttekintés</a></li>
<li><a href="/slides/hu/jasperreports/system-requirements/">Rendszerkövetelmények</a></li>
<li><a href="/slides/hu/jasperreports/getting-started/">Első lépések útmutatója</a></li>
</ul>
<p>ÉRTÉKELÉS</p>
<ul>
<li><a href="/slides/hu/jasperreports/supported-file-formats/">Támogatott fájlformátumok</a></li>
<li><a href="/slides/hu/jasperreports/evaluate-aspose-slides/">Próbaidő korlátai</a></li>
<li><a href="/slides/hu/jasperreports/licensing/">Licencelés</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Készítés Slides-szel</b></p>
<hr>
<p>EXPORTÁLÁS</p>
<ul>
<li><a href="/slides/hu/jasperreports/ppt-pptx-pdf-and-html-export/">Exportálás PPT, PPTX, PDF és HTML formátumba</a></li>
<li><a href="/slides/hu/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts">Betűtípusok leképezése</a></li>
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
<li><a href="https://releases.aspose.com/slides/hu/jasperreport/release-notes/">Kiadási megjegyzések</a></li>
<li><a href="https://releases.aspose.com/slides/hu/jasperreport/">Letöltés</a></li>
</ul>
<p>TÁMOGATÁS</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/hu/11">Ingyenes támogatási fórum</a></li>
<li><a href="https://helpdesk.aspose.com/">Fizetett támogatási helpdesk</a></li>
</ul>
</div>
</div>

------

## **Első exportja**

Ezek a lépések egy egyvonalas jelentést fordítanak le, töltik ki, és PPTX-be exportálják a JasperReports 6.16.0 verzióval a Maven Centralról. Szüksége van JDK 11 vagy újabb, valamint az Apache Maven-re.

1. Töltse le a ZIP fájlt a [letöltési oldalról](https://releases.aspose.com/slides/hu/jasperreport/) és csomagolja ki. A *lib* mappája minden JasperReports verziótartományhoz egy almappát tartalmaz, és mindegyikben a tartományhoz tartozó jar fájl van. A JasperReports 6.16.0-hoz másolja a *lib/JasperReports 6.5.0 - 6.16.0 (JDK 1.6)/aspose.slides.jasperreports.library-26.6.jar* fájlt egy üres projekt mappába.

2. Az jar a ZIP-ben van, nem Maven tárolóból, ezért telepíteni kell a helyi Maven tárolóba. Futassa ezt a parancsot a projekt mappában:

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

3. Mentse el ezt a *pom.xml*-t a projekt mappába. Ez hozzáadja a JasperReports 6.16.0-t és a telepített jar-t, valamint megadja a futtatandó osztályt. A JasperReports 6.16.0 egy javított iText buildet deklarál, amely nem érhető el a Maven Centralban, ezért a fájl kizárja azt; az Aspose exportálók nem igénylik.

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

4. Mentse el ezt a jelentés-tervet *hello.jrxml*-ként a projekt mappába. Egy szövegsort nyomtat a cím szalagra:

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

5. Mentse el ezt a kódot *src/main/java/HelloExport.java*-ként. Lefordítja a tervet, egy üres rekorddal tölti ki, és az eredményt az `ASPptxExporter` segítségével exportálja:

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
        // Fordítsa le a jelentéstervet, és töltse ki egy üres rekorddal.
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // Exportálja a kitöltött jelentést PPTX formátumba.
        ASPptxExporter exporter = new ASPptxExporter();
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "hello.pptx");
        exporter.exportReport();
    }
}
```

6. Futassa ezt a parancsot a projekt mappában:

```bash
mvn compile exec:java
```

A program a *hello.pptx* fájlt menti a projekt mappába, egy diával, amely a jelentés szövegét tartalmazza. A fordító megjegyzi, hogy a kód elavult API-t használ: az exportálók a bemenetüket és kimenetüket a `JRExporterParameter`-en keresztül kapják, és nem fogadják el az újabb `setExporterInput` és `setExporterOutput` beállítást. Linuxon a fontconfig és legalább egy betűtípus telepítése szükséges, különben a jelentés kitöltése meghiúsul. Licenc nélkül minden dián egy értékelési vízjel jelenik meg a közepén – lásd a [Licencelés](/slides/hu/jasperreports/licensing/) oldalt. PPT, PDF vagy HTML exportálásához lásd a [PPT, PPTX, PDF és HTML Export](/slides/hu/jasperreports/ppt-pptx-pdf-and-html-export/) oldalt.