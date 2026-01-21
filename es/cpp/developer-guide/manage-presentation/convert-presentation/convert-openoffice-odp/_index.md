---
title: Convertir presentaciones OpenDocument en C++
linktitle: Convertir OpenDocument
type: docs
weight: 10
url: /es/cpp/convert-openoffice-odp/
keywords:
- convertir ODP
- ODP a imagen
- ODP a GIF
- ODP a HTML
- ODP a JPG
- ODP a MD
- ODP a PDF
- ODP a PNG
- ODP a PPT
- ODP a PPTX
- ODP a TIFF
- ODP a video
- ODP a Word
- ODP a XPS
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Aspose.Slides para C++ le permite convertir ODP a PDF, HTML y formatos de imagen con facilidad. Potencie sus aplicaciones C++ con una conversión de presentaciones rápida y precisa."
---

[**Aspose.Slides API**](https://products.aspose.com/slides/cpp/) le permite convertir presentaciones OpenDocument (ODP) a muchos formatos (HTML, PDF, TIFF, SWF, XPS, etc.). La API utilizada para convertir archivos ODP a otros formatos de documento es la misma que se usa para las operaciones de conversión de PowerPoint (PPT y PPTX).

Por ejemplo, si necesita convertir una presentación ODP a PDF, puede hacerlo de la siguiente manera:
```cpp
auto pres = MakeObject<Presentation>(u"pres.odp");
pres->Save(u"pres.pdf", SaveFormat::Pdf);
pres->Dispose();
```
