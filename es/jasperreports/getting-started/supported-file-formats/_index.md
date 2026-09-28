---
title: Formatos de archivo compatibles
type: docs
weight: 20
url: /es/jasperreports/supported-file-formats/
description: "Vea qué entradas acepta Aspose.Slides for JasperReports y a qué formatos de archivo exporta los informes."
---
## **Entrada**

Aspose.Slides for JasperReports exporta informes; no convierte presentaciones existentes. Sus exportadores toman un informe JasperReports rellenado (`JasperPrint`), como el resultado de `JasperFillManager` o un informe rellenado cargado desde un archivo *.jrprint*.

## **Formatos de salida**

La tabla siguiente enumera los formatos a los que Aspose.Slides for JasperReports exporta un informe, y la clase exportadora que escribe cada uno.

|**Formato**|**Descripción**|**Exportador**|
| :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|Presentación PowerPoint 97–2003; una diapositiva por página del informe|`ASPptExporter`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|Presentación PowerPoint (Office Open XML); una diapositiva por página del informe|`ASPptxExporter`|
|[PDF](https://docs.fileformat.com/pdf/)|Formato de documento portátil; una página PDF por página del informe|`ASPdfExporter`|
|[HTML](https://docs.fileformat.com/web/html/)|Un único archivo HTML con una imagen SVG por página del informe|`ASHtmlExporter`|

No hay exportador para los formatos de presentación PPS y PPSX. Asignar a una exportación PPTX un nombre de archivo *.ppsx* sigue produciendo una presentación PPTX, no una presentación de diapositivas. Para ver cómo se utiliza cada exportador, consulte [Exportación PPT, PPTX, PDF y HTML](/slides/es/jasperreports/ppt-pptx-pdf-and-html-export/).