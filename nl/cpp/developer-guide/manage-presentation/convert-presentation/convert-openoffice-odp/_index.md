---
title: OpenDocument-presentaties converteren in C++
linktitle: OpenDocument converteren
type: docs
weight: 10
url: /nl/cpp/convert-openoffice-odp/
keywords:
- ODP converteren
- ODP naar afbeelding
- ODP naar GIF
- ODP naar HTML
- ODP naar JPG
- ODP naar MD
- ODP naar PDF
- ODP naar PNG
- ODP naar PPT
- ODP naar PPTX
- ODP naar TIFF
- ODP naar video
- ODP naar Word
- ODP naar XPS
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Aspose.Slides voor C++ stelt u in staat om ODP eenvoudig te converteren naar PDF, HTML en afbeeldingsformaten. Verhoog de prestaties van uw C++-toepassingen met snelle en nauwkeurige presentatieconversie."
---
[**Aspose.Slides API**](https://products.aspose.com/slides/nl/cpp/) maakt het mogelijk om OpenDocument (ODP)-presentaties te converteren naar verschillende formaten (HTML, PDF, TIFF, SWF, XPS, enz.). De API die wordt gebruikt om ODP-bestanden naar andere documentformaten te converteren, is dezelfde als die wordt gebruikt voor PowerPoint (PPT en PPTX) conversie-operaties.

Bijvoorbeeld, als u een ODP-presentatie naar PDF moet converteren, kunt u dat als volgt doen:

```cpp
auto pres = MakeObject<Presentation>(u"pres.odp");
pres->Save(u"pres.pdf", SaveFormat::Pdf);
pres->Dispose();
```