---
title: Product Overview
type: docs
weight: 10
url: /jasperreports/product-overview/
description: "Learn what Aspose.Slides for JasperReports does, which JasperReports versions and output formats it supports, and what its two jars are for."
---

![Aspose.Slides for JasperReports](product-overview_1.png)

## **Product Description**

Aspose.Slides for JasperReports exports reports from JasperReports to PowerPoint presentations, in Java applications and in JasperReports Server, without Microsoft PowerPoint. It supports JasperReports 3.7.2 to 6.16.0, with a separate jar for each range of versions — see [Installing Aspose.Slides for JasperReports](/slides/jasperreports/installing-aspose-slides-for-jasperreports/).

It exports a filled report to four formats, one slide or page per report page:

- PPT – PowerPoint 97–2003 presentation
- PPTX – PowerPoint presentation (Office Open XML)
- PDF
- HTML

The product has two parts:

- The library jar adds the exporters `ASPptExporter`, `ASPptxExporter`, `ASPdfExporter` and `ASHtmlExporter` to JasperReports Library.
- The server jar provides export actions for the same four formats, which you register in JasperReports Server — see [Integration with JasperServer](/slides/jasperreports/integration-with-jasperserver/).

### **Output Example**

The exporters extend JasperReports' own exporter classes and are used the same way: pass them the filled report and the output file, then call `exportReport`. For a complete program that fills a report and exports it to PPTX, see [Your first export](/slides/jasperreports/#your-first-export); for all four formats, see [PPT, PPTX, PDF and HTML Export](/slides/jasperreports/ppt-pptx-pdf-and-html-export/).

![A report exported to a presentation without a license, with the evaluation watermark at the center of the slide](product-overview_2.png)
