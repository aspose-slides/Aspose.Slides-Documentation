---
title: Konvertera OpenDocument-presentationer i C++
linktitle: Konvertera OpenDocument
type: docs
weight: 10
url: /sv/cpp/convert-openoffice-odp/
keywords:
- konvertera ODP
- ODP till bild
- ODP till GIF
- ODP till HTML
- ODP till JPG
- ODP till MD
- ODP till PDF
- ODP till PNG
- ODP till PPT
- ODP till PPTX
- ODP till TIFF
- ODP till video
- ODP till Word
- ODP till XPS
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Aspose.Slides för C++ låter dig konvertera ODP till PDF, HTML och bildformat med lätthet. Förbättra dina C++-appar med snabb och exakt presentationskonvertering."
---
[**Aspose.Slides API**](https://products.aspose.com/slides/sv/cpp/) låter dig konvertera OpenDocument (ODP)-presentationer till många format (HTML, PDF, TIFF, SWF, XPS etc.). API:et som används för att konvertera ODP-filer till andra dokumentformat är detsamma som det som används för konverteringsoperationer för PowerPoint (PPT och PPTX).

Till exempel, om du behöver konvertera en ODP-presentation till PDF, kan du göra det på följande sätt:

```cpp
auto pres = MakeObject<Presentation>(u"pres.odp");
pres->Save(u"pres.pdf", SaveFormat::Pdf);
pres->Dispose();
```