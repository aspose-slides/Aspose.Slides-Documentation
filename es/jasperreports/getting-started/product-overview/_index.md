---
title: "Visión general del producto"
type: docs
weight: 10
url: /es/jasperreports/product-overview/
description: "Aprenda qué hace Aspose.Slides for JasperReports, qué versiones de JasperReports y formatos de salida soporta, y para qué sirven sus dos archivos jar."
---
![Aspose.Slides para JasperReports](product-overview_1.png)

## **Descripción del producto**

Aspose.Slides for JasperReports exporta informes de JasperReports a presentaciones PowerPoint, en aplicaciones Java y en JasperReports Server, sin necesidad de Microsoft PowerPoint. Es compatible con JasperReports 3.7.2 hasta 6.16.0, con un archivo jar separado para cada rango de versiones — vea [Instalación de Aspose.Slides for JasperReports](/slides/es/jasperreports/installing-aspose-slides-for-jasperreports/).

Exporta un informe completado a cuatro formatos, una diapositiva o página por página del informe:

- PPT – presentación PowerPoint 97–2003
- PPTX – presentación PowerPoint (Office Open XML)
- PDF
- HTML

El producto consta de dos partes:

- El jar de la biblioteca agrega los exportadores `ASPptExporter`, `ASPptxExporter`, `ASPdfExporter` y `ASHtmlExporter` a JasperReports Library.
- El jar del servidor proporciona acciones de exportación para los mismos cuatro formatos, que se registran en JasperReports Server — vea [Integración con JasperServer](/slides/es/jasperreports/integration-with-jasperserver/).

### **Ejemplo de salida**

Los exportadores amplían las propias clases exportadoras de JasperReports y se usan de la misma forma: se les pasa el informe completado y el archivo de salida, y luego se llama a `exportReport`. Para un programa completo que rellena un informe y lo exporta a PPTX, vea [Su primera exportación](/slides/es/jasperreports/#your-first-export); para los cuatro formatos, vea [Exportación PPT, PPTX, PDF y HTML](/slides/es/jasperreports/ppt-pptx-pdf-and-html-export/).

![Un informe exportado a una presentación sin licencia, con la marca de agua de evaluación en el centro de la diapositiva](product-overview_2.png)