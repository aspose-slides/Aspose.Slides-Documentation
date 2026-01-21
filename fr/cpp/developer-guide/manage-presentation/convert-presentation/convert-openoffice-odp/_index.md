---
title: Convertir des présentations OpenDocument en C++
linktitle: Convertir OpenDocument
type: docs
weight: 10
url: /fr/cpp/convert-openoffice-odp/
keywords:
- convertir ODP
- ODP en image
- ODP en GIF
- ODP en HTML
- ODP en JPG
- ODP en MD
- ODP en PDF
- ODP en PNG
- ODP en PPT
- ODP en PPTX
- ODP en TIFF
- ODP en vidéo
- ODP en Word
- ODP en XPS
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Aspose.Slides pour C++ vous permet de convertir ODP en PDF, HTML et formats d'image en toute simplicité. Dynamisez vos applications C++ avec une conversion de présentations rapide et précise."
---

[**Aspose.Slides API**](https://products.aspose.com/slides/cpp/) vous permet de convertir des présentations OpenDocument (ODP) en de nombreux formats (HTML, PDF, TIFF, SWF, XPS, etc.). L'API utilisée pour convertir les fichiers ODP en d'autres formats de documents est la même que celle utilisée pour les opérations de conversion de PowerPoint (PPT et PPTX).

Par exemple, si vous devez convertir une présentation ODP en PDF, vous pouvez le faire comme suit :
```cpp
auto pres = MakeObject<Presentation>(u"pres.odp");
pres->Save(u"pres.pdf", SaveFormat::Pdf);
pres->Dispose();
```
