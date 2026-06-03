---
title: Descripción del producto
type: docs
weight: 10
url: /es/jasperreports/product-overview/
---
![Aspose.Slides para JasperReports](product-overview_1.png)

## **¡Bienvenido a Aspose.Slides para JasperReports!**

Aspose.Slides para JasperReports es una biblioteca diseñada y desarrollada especialmente para desarrolladores que necesitan exportar fácilmente informes de JasperReports a formatos Microsoft PowerPoint Presentation (PPT) y Microsoft PowerPoint Show (PPS) en sus aplicaciones Java. Todas las funcionalidades del informe se convierten con el mayor grado de precisión a presentaciones de Microsoft PowerPoint. Aspose.Slides para JasperReports incluye soporte para JasperReports 5+.

## **Descripción del producto**
JasperReports y JasperServer no disponen de capacidades integradas para exportar informes como presentaciones de Microsoft PowerPoint, pero Aspose.Slides para JasperReports le brinda acceso a dos formatos de exportación adicionales:

- PPT – PowerPoint Presentation mediante Aspose.Slides
- PPS – PowerPoint Show mediante Aspose.Slides
- PPTX – PowerPoint Presentation mediante Aspose.Slides
- PPSX – PowerPoint Show mediante Aspose.Slides

Aspose.Slides para JasperReports utiliza internamente nuestras bibliotecas 100 % puras Java Aspose.Slides for Java y Aspose.Metafiles for Java, bibliotecas de clase mundial para el procesamiento de presentaciones y metafiles del lado del servidor.

Aspose.Slides para JasperReports hace posible exportar cualquier informe en formato PPT o PPS.

### **Ejemplo de salida**
La clase ASPptExporter amplía la clase ASAbstractExporter, por lo que puede usarse de la misma forma que cualquier otro exportador estándar. Este breve ejemplo muestra el código típico y una captura de pantalla de un informe visualizado en MS PowerPoint. Se pueden encontrar ejemplos detallados en los informes de demostración proporcionados.

``` java
File sourceFile = new File(fileName); 
JasperPrint jasperPrint = (JasperPrint)JRLoader.loadObject(sourceFile);
File destFile = new File(sourceFile.getParent(), jasperPrint.getName() + ".ppt");
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, destFile.toString());
exporter.exportReport();
```

**Presentación generada con la demo xmldatasource de JasperReports** 

![Presentación generada con JasperReports](product-overview_2.png)