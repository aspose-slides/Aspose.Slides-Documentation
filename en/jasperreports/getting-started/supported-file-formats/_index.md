---
title: Supported File Formats
type: docs
weight: 20
url: /jasperreports/supported-file-formats/
description: "See what Aspose.Slides for JasperReports takes as input and which file formats it exports reports to."
---

## **Input**

Aspose.Slides for JasperReports exports reports; it does not convert existing presentations. Its exporters take a filled JasperReports report (`JasperPrint`), such as the result of `JasperFillManager` or a filled report loaded from a *.jrprint* file.

## **Output Formats**

The following table lists the formats that Aspose.Slides for JasperReports exports a report to, and the exporter class that writes each one.

|**Format**|**Description**|**Exporter**|
| :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint 97–2003 presentation; one slide per report page|`ASPptExporter`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint presentation (Office Open XML); one slide per report page|`ASPptxExporter`|
|[PDF](https://docs.fileformat.com/pdf/)|Portable Document Format; one PDF page per report page|`ASPdfExporter`|
|[HTML](https://docs.fileformat.com/web/html/)|A single HTML file with one SVG image per report page|`ASHtmlExporter`|

There is no exporter for the PPS and PPSX slide show formats. Giving a PPTX export a *.ppsx* file name still produces a PPTX presentation, not a slide show. To see how each exporter is used, see [PPT, PPTX, PDF and HTML Export](/slides/jasperreports/ppt-pptx-pdf-and-html-export/).
