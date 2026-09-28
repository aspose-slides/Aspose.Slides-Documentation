---
title: Aspose.Slides for JasperReports
second_title: Aspose.Slides for JasperReports
type: docs
weight: 70
url: /es/jasperreports/
keywords:
- documentación
- JasperReports
- JasperReports Server
- exportación de informes
- PowerPoint
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Comience aquí: instale Aspose.Slides for JasperReports, exporte un primer informe a PowerPoint y encuentre las guías para la exportación, la integración con JasperReports Server y el soporte."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for JasperReports" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for JasperReports añade exportadores de PowerPoint a JasperReports Library y JasperReports Server, de modo que las aplicaciones Java y los servidores de informes puedan guardar los informes completados como presentaciones sin Microsoft PowerPoint.

Exporta un informe completado a PPT y PPTX, una diapositiva por página de informe, y también a PDF y HTML.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Comenzar</b></p>
<hr>
<p>COMENZANDO</p>
<ul>
<li><a href="/slides/es/jasperreports/installing-aspose-slides-for-jasperreports/">Instalación</a></li>
<li><a href="/slides/es/jasperreports/product-overview/">Visión general del producto</a></li>
<li><a href="/slides/es/jasperreports/system-requirements/">Requisitos del sistema</a></li>
<li><a href="/slides/es/jasperreports/getting-started/">Guía de inicio</a></li>
</ul>
<p>EVALUAR</p>
<ul>
<li><a href="/slides/es/jasperreports/supported-file-formats/">Formatos de archivo compatibles</a></li>
<li><a href="/slides/es/jasperreports/evaluate-aspose-slides/">Limitaciones de la prueba</a></li>
<li><a href="/slides/es/jasperreports/licensing/">Licenciamiento</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Crear con Slides</b></p>
<hr>
<p>EXPORTAR</p>
<ul>
<li><a href="/slides/es/jasperreports/ppt-pptx-pdf-and-html-export/">Exportar a PPT, PPTX, PDF y HTML</a></li>
<li><a href="/slides/es/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts">Mapear fuentes</a></li>
<li><a href="/slides/es/jasperreports/integration-with-jasperserver/">Integración con JasperReports Server</a></li>
</ul>
<p>EJEMPLOS</p>
<ul>
<li><a href="/slides/es/jasperreports/demos-setup/">Proyectos de demostración</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referencia &amp; Soporte</b></p>
<hr>
<p>REFERENCIA</p>
<ul>
<li><a href="https://releases.aspose.com/slides/jasperreport/release-notes/">Notas de la versión</a></li>
<li><a href="https://releases.aspose.com/slides/jasperreport/">Descarga</a></li>
</ul>
<p>SOPORTE</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Foro de soporte gratuito</a></li>
<li><a href="https://helpdesk.aspose.com/">Mesa de ayuda de soporte pago</a></li>
</ul>
</div>
</div>

------

## **Su primera exportación**

Estos pasos compilan un informe de una sola línea, lo rellenan y lo exportan a PPTX con JasperReports 6.16.0 desde Maven Central. Necesita JDK 11 o posterior y Apache Maven.

1. Descargue el ZIP desde la [página de descarga](https://releases.aspose.com/slides/jasperreport/) y descomprímalo. Su carpeta *lib* tiene una subcarpeta por cada rango de versiones de JasperReports, y cada una contiene el jar correspondiente a ese rango. Para JasperReports 6.16.0, copie *lib/JasperReports 6.5.0 - 6.16.0 (JDK 1.6)/aspose.slides.jasperreports.library-26.6.jar* en una carpeta de proyecto vacía.

2. El jar viene dentro del ZIP en lugar de un repositorio Maven, por lo que debe instalarlo en su repositorio Maven local. Ejecute este comando en la carpeta del proyecto:

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

3. Guarde este *pom.xml* en la carpeta del proyecto. Añade JasperReports 6.16.0 y el jar que instaló, y define la clase a ejecutar. JasperReports 6.16.0 declara una compilación de iText parcheada que no está en Maven Central, por lo que el archivo la excluye; los exportadores de Aspose no la necesitan.

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

4. Guarde este diseño de informe como *hello.jrxml* en la carpeta del proyecto. Imprime una línea de texto en la banda de título:

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

5. Guarde este código como *src/main/java/HelloExport.java*. Compila el diseño, lo rellena con un registro vacío y exporta el resultado con `ASPptxExporter`:

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
        // Compila el diseño del informe y lo rellena con un registro vacío.
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // Exporta el informe rellenado a PPTX.
        ASPptxExporter exporter = new ASPptxExporter();
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "hello.pptx");
        exporter.exportReport();
    }
}
```

6. Ejecute este comando en la carpeta del proyecto:

```bash
mvn compile exec:java
```

El programa guarda *hello.pptx* en la carpeta del proyecto, con una diapositiva que contiene el texto del informe. El compilador indica que el código utiliza una API obsoleta: los exportadores toman su entrada y salida a través de `JRExporterParameter`, y no aceptan la configuración más reciente `setExporterInput` y `setExporterOutput`. En Linux, se debe instalar fontconfig y al menos una fuente, o el rellenado del informe fallará. Sin una licencia, cada diapositiva lleva una marca de agua de evaluación en su centro — vea [Licenciamiento](/slides/es/jasperreports/licensing/). Para exportar a PPT, PDF o HTML, consulte [Exportar a PPT, PPTX, PDF y HTML](/slides/es/jasperreports/ppt-pptx-pdf-and-html-export/).