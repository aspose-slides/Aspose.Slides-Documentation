---
title: OpenOffice ODP konvertieren
type: docs
weight: 10
url: /cpp/convert-openoffice-odp/
keywords: "ODP in PDF konvertieren, ODP in HTML, ODP in TIFF"
description: "Konvertieren Sie ODP in PDF, ODP in PPT, ODP in PPTX, ODP in HTML und andere Formate mit Aspose.Slides."
---

[**Aspose.Slides API**](https://products.aspose.com/slides/cpp/) ermöglicht es Ihnen, OpenOffice ODP-Präsentationen in viele Formate zu konvertieren. Die API, die verwendet wird, um ODP-Dateien in andere Dokumentformate zu konvertieren, ist dieselbe, die für PowerPoint (PPT und PPTX) Konvertierungsoperationen verwendet wird.

Diese Beispiele zeigen Ihnen, wie Sie ODP-Dokumente in andere Formate konvertieren können (ändern Sie einfach die Quell-ODP-Datei):

- [ODP in HTML konvertieren](/slides/cpp/convert-powerpoint-ppt-and-pptx-to-html/)
- [ODP in PDF konvertieren](/slides/cpp/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [ODP in TIFF konvertieren](/slides/cpp/convert-powerpoint-ppt-and-pptx-to-tiff/)
- [ODP in SWF Flash konvertieren](/slides/cpp/convert-powerpoint-ppt-and-pptx-to-swf-flash/)
- [ODP in XPS konvertieren](/slides/cpp/convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document/)
- [ODP in PDF mit Notizen konvertieren](/slides/cpp/convert-powerpoint-ppt-and-pptx-to-pdf-with-notes/)
- [ODP in TIFF mit Notizen konvertieren](/slides/cpp/convert-powerpoint-ppt-and-pptx-to-tiff-with-notes/)

Wenn Sie beispielsweise eine ODP-Präsentation in PDF konvertieren müssen, kann dies folgendermaßen durchgeführt werden:

``` cpp
SharedPtr<Presentation> pres = MakeObject<Presentation>(u"pres.odp");
pres->Save(u"pres.pdf", SaveFormat::Pdf);
```