---
title: Конвертируйте презентации OpenDocument в Python
linktitle: Конвертирование OpenDocument
type: docs
weight: 10
url: /ru/python-net/convert-openoffice-odp/
keywords:
- конвертировать OpenDocument
- конвертировать ODP
- ODP в PDF
- ODP в PPT
- ODP в PPTX
- ODP в XPS
- ODP в HTML
- ODP в TIFF
- ODP в SWF
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Конвертировать OpenDocument ODP в PDF, PPT, PPTX, XPS, HTML, TIFF или SWF в Python с помощью Aspose.Slides: примеры кода, высокая точность, пакетное преобразование и настройка."
---

[**Aspose.Slides API**](https://products.aspose.com/slides/python-net/) позволяет вам конвертировать презентации OpenOffice ODP в множество форматов. API, используемый для конвертации ODP файлов в другие форматы документов, такой же, как и для операций конвертации PowerPoint (PPT и PPTX).

Эти примеры показывают, как конвертировать документы ODP в другие форматы (просто измените исходный файл ODP):

- [Конвертация ODP в HTML](/slides/ru/python-net/convert-powerpoint-ppt-and-pptx-to-html/)
- [Конвертация ODP в PDF](/slides/ru/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [Конвертация ODP в TIFF](/slides/ru/python-net/convert-powerpoint-to-tiff/)
- [Конвертация ODP в SWF Flash](/slides/ru/python-net/convert-powerpoint-ppt-and-pptx-to-swf-flash/)
- [Конвертация ODP в XPS](/slides/ru/python-net/convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document/)
- [Конвертация ODP в PDF с заметками](/slides/ru/python-net/convert-powerpoint-ppt-and-pptx-to-pdf-with-notes/)
- [Конвертация ODP в TIFF с заметками](/slides/ru/python-net/convert-powerpoint-ppt-and-pptx-to-tiff-with-notes/)

Например, если вам нужно конвертировать презентацию ODP в PDF, это можно сделать следующим образом:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.odp")
pres.save("pres.pdf", slides.export.SaveFormat.PDF)
```