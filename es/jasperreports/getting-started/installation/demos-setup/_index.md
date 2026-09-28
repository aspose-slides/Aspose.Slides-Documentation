---
title: Configuración de Demos
type: docs
weight: 70
url: /es/jasperreports/demos-setup/
description: "Configura los proyectos de demostración de la descarga de Aspose.Slides para JasperReports, cambia la clase exportadora que utilizan y compílalos con Ant."
---
## **Qué son las demos**

La carpeta *samples* de la descarga de Aspose.Slides para JasperReports contiene ocho proyectos de demostración: *charts*, *fonts*, *images*, *landscape*, *shapes*, *subreport*, *text* y *xmldatasource*. Son demostraciones estándar de JasperReports, modificadas para añadir un objetivo de compilación `ppt` que exporta el informe completado a PPT. La descarga no incluye presentaciones exportadas; las crea compilando una demo.

## **Cambiar la clase exportadora antes de compilar**

Tal como se entrega, el código Java de las demos usa `com.aspose.slides.jasperreports.JRPptExporter`, una clase que los JAR actuales no contienen, por lo que las demos no compilan. En la clase de aplicación de la demo (por ejemplo, *ShapesApp.java* en la demo *shapes*), reemplace `JRPptExporter` por `ASPptExporter`, el exportador PPT del mismo paquete. La demo *fonts* importa todo el paquete, por lo que solo cambia el nombre de la clase en su código.

Las demos también utilizan clases de JasperReports que versiones posteriores eliminaron, como `JExcelApiExporter` y `JRExporterParameter.FONT_MAP`. Con el cambio anterior, las demos compilan de la siguiente manera:

| Versión de JasperReports | Demos que compilan |
| :- | :- |
| 5.5.1 | todas las ocho |
| 5.5.2 and 6.4.0 | *charts*, *images*, *landscape*, *shapes* y *xmldatasource* |
| 6.16.0 | *charts* |

## **Compilar una demo**

Cada *build.xml* de una demo espera la estructura de carpetas de un proyecto JasperReports: compila contra *../../../build/classes* y los JAR en *../../../lib*, relativos a la carpeta de la demo.

1. Copie la carpeta de la demo a *demo/samples* en la carpeta de su proyecto JasperReports.
2. Copie *aspose.slides.jasperreports.library-xx.x.jar* desde la subcarpeta *lib* de la descarga que corresponde a su versión de JasperReports al directorio *lib* del proyecto JasperReports. Vea [Installing Aspose.Slides for JasperReports](/slides/es/jasperreports/installing-aspose-slides-for-jasperreports/).
3. Coloque el JAR de su versión de JasperReports y los JAR de los que depende en la misma carpeta *lib*. Además de los archivos de la demo, *build.xml* añade solo *build/classes* y los JAR bajo *lib* al classpath, y *build/classes* contiene clases de JasperReports únicamente después de compilar JasperReports desde el código fuente.
4. Las demos *charts*, *subreport* y *text* leen la base de datos de ejemplo HSQLDB de JasperReports (`jdbc:hsqldb:hsql://localhost`), por lo que debe iniciar su servidor primero, según se describe en *samples/Readme.txt* de la descarga. Las demás demos no necesitan base de datos.
5. En la carpeta de la demo, compile la aplicación, compile el diseño del informe, complételo y expórtelo a PPT:

```bash
ant javac
ant compile
ant fill
ant ppt
```

El objetivo `ppt` escribe la presentación junto al informe completado, con el mismo nombre que el informe (por ejemplo, *LandscapeReport.ppt*).

Dos demos requieren más que los pasos anteriores:

- La demo *images* carga una imagen desde `http://jasperreports.sourceforge.net/jasperreports.png` al exportar. Esa dirección ahora redirige a HTTPS, por lo que el paso `ppt` no genera ninguna presentación hasta que cambie la dirección a `https://` en *ImagesReport.jrxml*. Con JasperReports 6.4.0, la exportación de esa imagen falla incluso con HTTPS.
- El informe *xmldatasource* utiliza la fuente Arial. En un sistema sin Arial, `ant fill` muestra que la fuente "is not available to the JVM" y no genera ningún informe completado, por lo que `ant ppt` no tiene nada que exportar. La compilación sigue indicando éxito, así que revise la salida de cada paso.