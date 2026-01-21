---
title: OpenDocument-Präsentationen in C++ konvertieren
linktitle: OpenDocument konvertieren
type: docs
weight: 10
url: /de/cpp/convert-openoffice-odp/
keywords:
- ODP konvertieren
- ODP zu Bild
- ODP zu GIF
- ODP zu HTML
- ODP zu JPG
- ODP zu MD
- ODP zu PDF
- ODP zu PNG
- ODP zu PPT
- ODP zu PPTX
- ODP zu TIFF
- ODP zu Video
- ODP zu Word
- ODP zu XPS
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Aspose.Slides für C++ ermöglicht Ihnen, ODP mühelos in PDF, HTML und Bildformate zu konvertieren. Steigern Sie Ihre C++-Anwendungen mit schneller und präziser Präsentationskonvertierung."
---

[**Aspose.Slides API**](https://products.aspose.com/slides/cpp/) ermöglicht das Konvertieren von OpenDocument (ODP)-Präsentationen in viele Formate (HTML, PDF, TIFF, SWF, XPS usw.). Die API, die zum Konvertieren von ODP-Dateien in andere Dokumentformate verwendet wird, ist dieselbe wie die für PowerPoint‑ (PPT und PPTX) Konvertierungs‑Operationen.

Beispielsweise können Sie eine ODP‑Präsentation in PDF konvertieren, indem Sie wie folgt vorgehen:
```cpp
auto pres = MakeObject<Presentation>(u"pres.odp");
pres->Save(u"pres.pdf", SaveFormat::Pdf);
pres->Dispose();
```
