---
title: Converter apresentações OpenDocument em C++
linktitle: Converter OpenDocument
type: docs
weight: 10
url: /pt/cpp/convert-openoffice-odp/
keywords:
- converter ODP
- ODP para imagem
- ODP para GIF
- ODP para HTML
- ODP para JPG
- ODP para MD
- ODP para PDF
- ODP para PNG
- ODP para PPT
- ODP para PPTX
- ODP para TIFF
- ODP para vídeo
- ODP para Word
- ODP para XPS
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ permite converter ODP para PDF, HTML e formatos de imagem com facilidade. Impulsione seus aplicativos C++ com conversão de apresentações rápida e precisa."
---
[**Aspose.Slides API**](https://products.aspose.com/slides/pt/cpp/) permite converter apresentações OpenDocument (ODP) para muitos formatos (HTML, PDF, TIFF, SWF, XPS, etc.). A API usada para converter arquivos ODP para outros formatos de documento é a mesma utilizada nas operações de conversão do PowerPoint (PPT e PPTX).

Por exemplo, se você precisar converter uma apresentação ODP para PDF, pode fazê‑lo da seguinte maneira:

```cpp
auto pres = MakeObject<Presentation>(u"pres.odp");
pres->Save(u"pres.pdf", SaveFormat::Pdf);
pres->Dispose();
```