---
title: Instalación de Aspose.Slides para JasperReports
type: docs
weight: 40
url: /es/jasperreports/installing-aspose-slides-for-jasperreports/
description: "Elija los jars de Aspose.Slides para JasperReports que coincidan con su versión de JasperReports y añádalos a JasperReports, a un proyecto Maven o a JasperReports Server."
---
## **Elija los jars para su versión de JasperReports**

Aspose.Slides for JasperReports se distribuye como un archivo ZIP en la [página de descarga](https://releases.aspose.com/slides/jasperreport/). Su carpeta *lib* tiene una subcarpeta por cada rango de versiones de JasperReports. Tome los jars de la subcarpeta que cubre la versión de JasperReports que utiliza:

| Versión de JasperReports | Subcarpeta de *lib* |
| :- | :- |
| 3.7.2 to 5.5.1 | *JasperReports 3.7.2 - 5.5.1 (JDK 1.6)* |
| 5.5.2 to 6.4.0 | *JasperReports 5.5.2 - 6.4.0 (JDK 1.6)* |
| 6.5.0 to 6.16.0 | *JasperReports 6.5.0 - 6.16.0 (JDK 1.6)* |

No existe una subcarpeta para JasperReports 6.17.0 o versiones posteriores, incluido JasperReports 7. La subcarpeta *JasperReports 2.0.3 - 3.7.1 (JDK 1.4)* no contiene jars, sólo una nota que indica que el soporte para esas versiones finalizó en Aspose.Slides for JasperReports 17.6.

Cada subcarpeta contiene dos jars; *xx.x* en sus nombres corresponde a la versión del producto:

- *aspose.slides.jasperreports.library-xx.x.jar* contiene los exportadores para JasperReports Library (`ASPptExporter`, `ASPptxExporter`, `ASPdfExporter` y `ASHtmlExporter`) y la clase `License`.
- *aspose.slides.jasperreports.server-xx.x.jar* contiene las acciones de exportación para JasperReports Server. Se basa en el jar de la biblioteca, por lo que el servidor siempre necesita ambos jars de la misma subcarpeta.

## **Agregar el jar de la biblioteca a JasperReports o a su aplicación**

Copie *aspose.slides.jasperreports.library-xx.x.jar* de la subcarpeta correspondiente a la carpeta *lib* de JasperReports o al classpath de su aplicación. Así, su aplicación podrá crear los exportadores en código.

{{% alert color="info" title="Note" %}}
En Linux, JasperReports necesita fontconfig y al menos una fuente instalada para rellenar un informe. Sin fuentes, el relleno falla con el error "Error initializing graphic environment".
{{% /alert %}}

## **Agregar el jar de la biblioteca a un proyecto Maven**

El jar se incluye en el ZIP y no proviene de un repositorio Maven. Para usarlo en una compilación Maven, instálelo en su repositorio Maven local. Para la versión 26.6, ejecute este comando en la carpeta que contiene el jar:

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

Luego agréguelo a las dependencias en *pom.xml*, junto con una versión de JasperReports que cubra la subcarpeta del jar:

```xml
<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides-jasperreports</artifactId>
    <version>26.6</version>
</dependency>
```

Los IDs de grupo y artefacto son los que elija en el comando de instalación; sólo tienen que coincidir. Un proyecto completo que usa JasperReports 6.16.0 se encuentra en [Su primera exportación](/slides/es/jasperreports/#your-first-export).

## **Agregar los jars a JasperReports Server**

Copie ambos jars de la subcarpeta correspondiente a la carpeta *WEB-INF/lib* de la aplicación web JasperReports Server, y luego registre los exportadores como se describe en [Integración con JasperServer](/slides/es/jasperreports/integration-with-jasperserver/).