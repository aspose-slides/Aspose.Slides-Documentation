---
title: Descripción del Producto
type: docs
weight: 10
url: /jasperreports/product-overview/
---

{{% alert color="primary" %}} 

![todo:image_alt_text](product-overview_1.png)

## **¡Bienvenido a la documentación de Aspose.Slides para JasperReports!**
Aspose.Slides para JasperReports es una biblioteca diseñada y desarrollada especialmente para desarrolladores que necesitan exportar informes de JasperReports a formatos de Presentación de Microsoft PowerPoint (PPT) y Show de Microsoft PowerPoint (PPS) en sus aplicaciones Java. Todas las características del informe se convierten con el más alto grado de precisión a presentaciones de Microsoft PowerPoint. Aspose.Slides para JasperReports incluye soporte para JasperReports 5+.

{{% /alert %}} 

## **Descripción del Producto**
JasperReports y JasperServer no tienen capacidades integradas para exportar informes como presentaciones de Microsoft PowerPoint, pero Aspose.Slides para JasperReports te brinda acceso a dos formatos de exportación adicionales:

- PPT – Presentación de PowerPoint a través de Aspose.Slides
- PPS - Show de PowerPoint a través de Aspose.Slides
- PPTX – Presentación de PowerPoint a través de Aspose.Slides
- PPSX - Show de PowerPoint a través de Aspose.Slides

Aspose.Slides para JasperReports utiliza internamente nuestras bibliotecas de Java 100% puras Aspose.Slides para Java y Aspose.Metafiles para Java, bibliotecas de clase mundial para presentaciones del lado del servidor y procesamiento de metafiles.

Aspose.Slides para JasperReports hace posible exportar cualquier informe en formato PPT o PPS.

### **Ejemplo de Salida**
La clase ASPptExporter extiende la clase ASAbstractExporter, por lo que puede ser utilizada de la misma manera que cualquier otro exportador estándar. Este breve ejemplo muestra código típico y una captura de pantalla de un informe visto en MS PowerPoint. Ejemplos detallados se pueden encontrar en los informes demo proporcionados.

``` java
File sourceFile = new File(fileName); 
JasperPrint jasperPrint = (JasperPrint)JRLoader.loadObject(sourceFile);
File destFile = new File(sourceFile.getParent(), jasperPrint.getName() + ".ppt");
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, destFile.toString());
exporter.exportReport();
```

**Presentación generada con la demo de fuente de datos xml de JasperReports** 

![todo:image_alt_text](product-overview_2.png)