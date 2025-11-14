---
title: OpenOffice ODP konvertieren
type: docs
weight: 10
url: /de/python-net/convert-openoffice-odp/
keywords: "ODP zu PDF konvertieren, ODP zu PPT, ODP zu PPTX, ODP zu XPS, ODP zu HTML, ODP zu TIFF"
description: "Konvertieren Sie ODP in PDF, ODP in PPT, ODP in PPTX, ODP in HTML und andere Formate mit Aspose.Slides."
---

[**Aspose.Slides API**](https://products.aspose.com/slides/python-net/) ermöglicht es Ihnen, OpenOffice ODP-Präsentationen in viele Formate zu konvertieren. Die API, die verwendet wird, um ODP-Dateien in andere Dokumentformate zu konvertieren, ist dieselbe, die für PowerPoint (PPT und PPTX) Konvertierungsoperationen verwendet wird.

Diese Beispiele zeigen Ihnen, wie Sie ODP-Dokumente in andere Formate konvertieren können (ändern Sie einfach die Quell-ODP-Datei):

- [ODP in HTML konvertieren](/slides/de/python-net/convert-powerpoint-ppt-and-pptx-to-html/)
- [ODP in PDF konvertieren](/slides/de/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [ODP in TIFF konvertieren](/slides/de/python-net/convert-powerpoint-to-tiff/)
- [ODP in SWF Flash konvertieren](/slides/de/python-net/convert-powerpoint-ppt-and-pptx-to-swf-flash/)
- [ODP in XPS konvertieren](/slides/de/python-net/convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document/)
- [ODP in PDF mit Notizen konvertieren](/slides/de/python-net/convert-powerpoint-ppt-and-pptx-to-pdf-with-notes/)
- [ODP in TIFF mit Notizen konvertieren](/slides/de/python-net/convert-powerpoint-ppt-and-pptx-to-tiff-with-notes/)

Wenn Sie beispielsweise eine ODP-Präsentation in PDF konvertieren müssen, kann dies folgendermaßen durchgeführt werden:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.odp")
pres.save("pres.pdf", slides.export.SaveFormat.PDF)
```