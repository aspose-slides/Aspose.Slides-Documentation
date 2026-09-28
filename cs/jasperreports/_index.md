---
title: Aspose.Slides for JasperReports
second_title: Aspose.Slides for JasperReports
type: docs
weight: 70
url: /cs/jasperreports/
keywords:
- dokumentace
- JasperReports
- JasperReports Server
- export reportu
- PowerPoint
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Začněte zde: nainstalujte Aspose.Slides for JasperReports, exportujte první report do PowerPointu a najděte návody pro export, integraci se serverem JasperReports a podporu."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for JasperReports" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for JasperReports přidává exportéry PowerPoint do knihovny JasperReports a serveru JasperReports, takže Java aplikace a servery s reporty mohou uložit vyplněné reporty jako prezentace bez Microsoft PowerPoint.

Exportuje vyplněný report do PPT a PPTX, jeden snímek na stránku reportu, a také do PDF a HTML.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Začínáme</b></p>
<hr>
<p>ZAČÁTEK</p>
<ul>
<li><a href="/slides/cs/jasperreports/installing-aspose-slides-for-jasperreports/">Instalace</a></li>
<li><a href="/slides/cs/jasperreports/product-overview/">Přehled produktu</a></li>
<li><a href="/slides/cs/jasperreports/system-requirements/">Systémové požadavky</a></li>
<li><a href="/slides/cs/jasperreports/getting-started/">Průvodce začátkem</a></li>
</ul>
<p>HODNOCENÍ</p>
<ul>
<li><a href="/slides/cs/jasperreports/supported-file-formats/">Podporované formáty souborů</a></li>
<li><a href="/slides/cs/jasperreports/evaluate-aspose-slides/">Omezení zkušební verze</a></li>
<li><a href="/slides/cs/jasperreports/licensing/">Licencování</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Vytvořit pomocí Slides</b></p>
<hr>
<p>EXPORT</p>
<ul>
<li><a href="/slides/cs/jasperreports/ppt-pptx-pdf-and-html-export/">Export do PPT, PPTX, PDF a HTML</a></li>
<li><a href="/slides/cs/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts">Mapování fontů</a></li>
<li><a href="/slides/cs/jasperreports/integration-with-jasperserver/">Integrace se serverem JasperReports</a></li>
</ul>
<p>PŘÍKLADY</p>
<ul>
<li><a href="/slides/cs/jasperreports/demos-setup/">Demo projekty</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Reference &amp; Podpora</b></p>
<hr>
<p>REFERENCE</p>
<ul>
<li><a href="https://releases.aspose.com/slides/cs/jasperreport/release-notes/">Poznámky k vydání</a></li>
<li><a href="https://releases.aspose.com/slides/cs/jasperreport/">Stáhnout</a></li>
</ul>
<p>PODPORA</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/cs/11">Bezplatné fórum podpory</a></li>
<li><a href="https://helpdesk.aspose.com/">Placená podpora helpdesk</a></li>
</ul>
</div>
</div>

------

## **Váš první export**

Tyto kroky zkompilují jednorozdělový report, vyplní jej a exportují do PPTX pomocí JasperReports 6.16.0 z Maven Central. Potřebujete JDK 11 nebo novější a Apache Maven.

1. Stáhněte ZIP ze [stránky ke stažení](https://releases.aspose.com/slides/cs/jasperreport/) a rozbalte jej. Jeho složka *lib* má podsložku pro každé rozmezí verzí JasperReports a každá obsahuje JAR pro dané rozmezí. Pro JasperReports 6.16.0 zkopírujte *lib/JasperReports 6.5.0 - 6.16.0 (JDK 1.6)/aspose.slides.jasperreports.library-26.6.jar* do prázdné složky projektu.

2. JAR je součástí ZIPu, nikoliv Maven repozitáře, takže jej nainstalujte do svého lokálního Maven repozitáře. Spusťte tento příkaz ve složce projektu:

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

3. Uložte tento *pom.xml* do složky projektu. Přidá JasperReports 6.16.0 a nainstalovaný JAR a určí třídu ke spuštění. JasperReports 6.16.0 uvádí upravenou verzi iText, která není na Maven Central, takže soubor ji vylučuje; exportéry Aspose ji nepotřebují.

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

4. Uložte tento návrh reportu jako *hello.jrxml* do složky projektu. Vypíše jeden řádek textu v titulkové pásce:

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

5. Uložte tento kód jako *src/main/java/HelloExport.java*. Zkompiluje návrh, vyplní jej jedním prázdným záznamem a exportuje výsledek pomocí `ASPptxExporter`:

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
        // Zkompilujte návrh reportu a vyplňte jej jedním prázdným záznamem.
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // Exportujte vyplněný report do PPTX.
        ASPptxExporter exporter = new ASPptxExporter();
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "hello.pptx");
        exporter.exportReport();
    }
}
```

6. Spusťte tento příkaz ve složce projektu:

```bash
mvn compile exec:java
```

Program uloží *hello.pptx* do složky projektu, s jedním snímkem, který obsahuje text reportu. Překladač upozorňuje, že kód používá zastaralé API: exportéry přijímají vstup a výstup přes `JRExporterParameter` a nepodporují novější konfiguraci `setExporterInput` a `setExporterOutput`. Na Linuxu musí být nainstalován fontconfig a alespoň jedno písmo, jinak selže vyplnění reportu. Bez licence nese každý snímek vodotisk s hodnocením uprostřed – viz [Licencování](/slides/cs/jasperreports/licensing/). Pro export do PPT, PDF nebo HTML viz [Export do PPT, PPTX, PDF a HTML](/slides/cs/jasperreports/ppt-pptx-pdf-and-html-export/).