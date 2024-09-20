---
title: Конвертация OpenOffice ODP
type: docs
weight: 10
url: /cpp/convert-openoffice-odp/
keywords: "Конвертация ODP в PDF, ODP в HTML, ODP в TIFF"
description: "Конвертируйте ODP в PDF, ODP в PPT, ODP в PPTX, ODP в HTML и другие форматы с Aspose.Slides."
---

[**Aspose.Slides API**](https://products.aspose.com/slides/cpp/) позволяет конвертировать презентации OpenOffice ODP в множество форматов. API, используемый для конвертации файлов ODP в другие форматы документов, такой же, как и для операций конвертации PowerPoint (PPT и PPTX).

Эти примеры показывают, как конвертировать документы ODP в другие форматы (просто измените исходный файл ODP):

- [Конвертация ODP в HTML](/slides/cpp/convert-powerpoint-ppt-and-pptx-to-html/)
- [Конвертация ODP в PDF](/slides/cpp/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [Конвертация ODP в TIFF](/slides/cpp/convert-powerpoint-ppt-and-pptx-to-tiff/)
- [Конвертация ODP в SWF Flash](/slides/cpp/convert-powerpoint-ppt-and-pptx-to-swf-flash/)
- [Конвертация ODP в XPS](/slides/cpp/convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document/)
- [Конвертация ODP в PDF с заметками](/slides/cpp/convert-powerpoint-ppt-and-pptx-to-pdf-with-notes/)
- [Конвертация ODP в TIFF с заметками](/slides/cpp/convert-powerpoint-ppt-and-pptx-to-tiff-with-notes/)

Например, если вам нужно конвертировать презентацию ODP в PDF, это можно сделать следующим образом:

``` cpp
SharedPtr<Presentation> pres = MakeObject<Presentation>(u"pres.odp");
pres->Save(u"pres.pdf", SaveFormat::Pdf);
```