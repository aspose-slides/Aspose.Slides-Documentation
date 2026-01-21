---
title: Конвертировать презентации OpenDocument в C++
linktitle: Конвертировать OpenDocument
type: docs
weight: 10
url: /ru/cpp/convert-openoffice-odp/
keywords:
- конвертировать ODP
- ODP в изображение
- ODP в GIF
- ODP в HTML
- ODP в JPG
- ODP в MD
- ODP в PDF
- ODP в PNG
- ODP в PPT
- ODP в PPTX
- ODP в TIFF
- ODP в видео
- ODP в Word
- ODP в XPS
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Aspose.Slides для C++ позволяет легко конвертировать ODP в PDF, HTML и графические форматы. Ускорьте свои C++ приложения с быстрой и точной конвертацией презентаций."
---

[**Aspose.Slides API**](https://products.aspose.com/slides/cpp/) позволяет конвертировать презентации OpenDocument (ODP) во многие форматы (HTML, PDF, TIFF, SWF, XPS и т.д.). API, используемое для преобразования файлов ODP в другие форматы документов, такое же, как и для операций конвертации PowerPoint (PPT и PPTX).

Например, если вам нужно преобразовать презентацию ODP в PDF, вы можете сделать это следующим образом:
```cpp
auto pres = MakeObject<Presentation>(u"pres.odp");
pres->Save(u"pres.pdf", SaveFormat::Pdf);
pres->Dispose();
```
