---
title: Aspose.Slides per JasperReports
second_title: Aspose.Slides per JasperReports
type: docs
weight: 70
url: /it/jasperreports/
keywords:
- documentazione
- JasperReports
- JasperReports Server
- esportazione report
- PowerPoint
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Inizia qui: installa Aspose.Slides per JasperReports, esporta il primo report in PowerPoint e trova le guide per l'esportazione, l'integrazione con JasperReports Server e il supporto."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for JasperReports" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for JasperReports aggiunge esportatori PowerPoint a JasperReports Library e JasperReports Server, in modo che le applicazioni Java e i server di report possano salvare i report compilati come presentazioni senza Microsoft PowerPoint.

Esporta un report compilato in PPT e PPTX, una diapositiva per pagina di report, e anche in PDF e HTML.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Inizia</b></p>
<hr>
<p>INIZIO</p>
<ul>
<li><a href="/slides/it/jasperreports/installing-aspose-slides-for-jasperreports/">Installazione</a></li>
<li><a href="/slides/it/jasperreports/product-overview/">Panoramica del prodotto</a></li>
<li><a href="/slides/it/jasperreports/system-requirements/">Requisiti di sistema</a></li>
<li><a href="/slides/it/jasperreports/getting-started/">Guida introduttiva</a></li>
</ul>
<p>VALUTAZIONE</p>
<ul>
<li><a href="/slides/it/jasperreports/supported-file-formats/">Formati di file supportati</a></li>
<li><a href="/slides/it/jasperreports/evaluate-aspose-slides/">Limitazioni della versione di prova</a></li>
<li><a href="/slides/it/jasperreports/licensing/">Licenza</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Crea con Slides</b></p>
<hr>
<p>ESPORTA</p>
<ul>
<li><a href="/slides/it/jasperreports/ppt-pptx-pdf-and-html-export/">Esporta in PPT, PPTX, PDF e HTML</a></li>
<li><a href="/slides/it/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts">Mappa i caratteri</a></li>
<li><a href="/slides/it/jasperreports/integration-with-jasperserver/">Integrazione con JasperReports Server</a></li>
</ul>
<p>ESEMPI</p>
<ul>
<li><a href="/slides/it/jasperreports/demos-setup/">Progetti demo</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Riferimenti e supporto</b></p>
<hr>
<p>RIFERIMENTO</p>
<ul>
<li><a href="https://releases.aspose.com/slides/jasperreport/release-notes/">Note di rilascio</a></li>
<li><a href="https://releases.aspose.com/slides/jasperreport/">Download</a></li>
</ul>
<p>SUPPORTO</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Forum di supporto gratuito</a></li>
<li><a href="https://helpdesk.aspose.com/">Helpdesk di supporto a pagamento</a></li>
</ul>
</div>
</div>

------

## **La tua prima esportazione**

Questi passaggi compilano un report di una riga, lo compilano e lo esportano in PPTX con JasperReports 6.16.0 da Maven Central. È necessario JDK 11 o superiore e Apache Maven.

1. Scarica il file ZIP dalla [pagina di download](https://releases.aspose.com/slides/jasperreport/) e decomprimilo. La sua cartella *lib* contiene una sottocartella per ciascuna gamma di versioni di JasperReports, e ognuna contiene il jar per quella gamma. Per JasperReports 6.16.0, copia *lib/JasperReports 6.5.0 - 6.16.0 (JDK 1.6)/aspose.slides.jasperreports.library-26.6.jar* in una cartella di progetto vuota.

2. Il jar è incluso nel ZIP anziché provenire da un repository Maven, quindi installalo nel tuo repository Maven locale. Esegui questo comando nella cartella del progetto:

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

3. Salva questo *pom.xml* nella cartella del progetto. Aggiunge JasperReports 6.16.0 e il jar che hai installato, e specifica la classe da eseguire. JasperReports 6.16.0 dichiara una build iText patchata che non è su Maven Central, quindi il file la esclude; gli esportatori Aspose non ne hanno bisogno.

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

4. Salva questo design del report come *hello.jrxml* nella cartella del progetto. Stampa una riga di testo nella banda del titolo:

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

5. Salva questo codice come *src/main/java/HelloExport.java*. Compila il design, lo riempie con un record vuoto e esporta il risultato con `ASPptxExporter`:

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
        // Compila il design del report e lo riempie con un record vuoto.
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // Esporta il report compilato in PPTX.
        ASPptxExporter exporter = new ASPptxExporter();
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "hello.pptx");
        exporter.exportReport();
    }
}
```

6. Esegui questo comando nella cartella del progetto:

```bash
mvn compile exec:java
```

Il programma salva *hello.pptx* nella cartella del progetto, con una diapositiva che contiene il testo del report. Il compilatore segnala che il codice utilizza un'API deprecata: gli esportatori ricevono input e output tramite `JRExporterParameter` e non accettano la più recente configurazione `setExporterInput` e `setExporterOutput`. Su Linux, fontconfig e almeno un font devono essere installati, altrimenti il popolamento del report fallisce. Senza licenza, ogni diapositiva presenta una filigrana di valutazione al centro — vedi [Licenza](/slides/it/jasperreports/licensing/). Per esportare in PPT, PDF o HTML, vedi [Esporta PPT, PPTX, PDF e HTML](/slides/it/jasperreports/ppt-pptx-pdf-and-html-export/).