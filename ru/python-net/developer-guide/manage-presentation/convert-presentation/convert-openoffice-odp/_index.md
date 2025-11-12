---
title: Конвертировать презентации OpenDocument в Python
linktitle: Конвертировать OpenDocument
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
description: Конвертировать OpenDocument ODP в PDF, PPT, PPTX, XPS, HTML, TIFF или SWF в Python с помощью Aspose.Slides: примеры кода, высокая точность, пакетное преобразование и настройка.
---

## **Конвертировать ODP файлы**

[**Aspose.Slides API**](https://products.aspose.com/slides/python-net/) позволяет конвертировать презентации OpenOffice ODP во множество форматов. API, используемое для конвертации файлов ODP в другие форматы документов, то же самое, что и для операций конвертации PowerPoint (PPT и PPTX).

Эти примеры показывают, как конвертировать документы ODP в другие форматы (просто измените исходный файл ODP):

- [Конвертировать ODP в HTML](/slides/ru/python-net/convert-powerpoint-ppt-and-pptx-to-html/)
- [Конвертировать ODP в PDF](/slides/ru/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [Конвертировать ODP в TIFF](/slides/ru/python-net/convert-powerpoint-to-tiff/)
- [Конвертировать ODP в SWF Flash](/slides/ru/python-net/convert-powerpoint-ppt-and-pptx-to-swf-flash/)
- [Конвертировать ODP в XPS](/slides/ru/python-net/convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document/)
- [Конвертировать ODP в PDF с заметками](/slides/ru/python-net/convert-powerpoint-ppt-and-pptx-to-pdf-with-notes/)
- [Конвертировать ODP в TIFF с заметками](/slides/ru/python-net/convert-powerpoint-ppt-and-pptx-to-tiff-with-notes/)

Например, если вам нужно конвертировать презентацию ODP в PDF, это можно сделать так:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.odp")
pres.save("pres.pdf", slides.export.SaveFormat.PDF)
```

## **Часто задаваемые вопросы**

**Можно ли конвертировать ODP в PPTX без установки LibreOffice или OpenOffice?**

Да. Aspose.Slides — полностью автономная библиотека, которая обрабатывает форматы PowerPoint и OpenOffice без необходимости в сторонних приложениях.

**Aspose.Slides открывает и сохраняет файлы ODP/OTP, защищённые паролем?**

Да. Она может [загружать зашифрованные презентации](/slides/ru/python-net/password-protected-presentation/), когда вы предоставляете пароль, а также сохранять презентации с настройками шифрования и защиты.

**Можно ли извлечь встроенные медиафайлы (аудио/видео) из ODP перед конвертацией?**

Да. Aspose.Slides позволяет получать доступ и извлекать встроенные [аудио](/slides/ru/python-net/audio-frame/) и [видео](/slides/ru/python-net/video-frame/) из презентаций, что полезно для предобработки перед конвертацией или отдельного повторного использования.

**Можно ли сохранить конвертированный ODP как Strict Office Open XML?**

Да. При сохранении в PPTX можно включить Strict OOXML через [параметры сохранения](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/), чтобы соответствовать более строгим требованиям совместимости.