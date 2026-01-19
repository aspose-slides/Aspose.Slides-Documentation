---
title: Преобразование презентаций OpenDocument в Python
linktitle: Преобразование OpenDocument
type: docs
weight: 10
url: /ru/python-net/convert-openoffice-odp/
keywords:
- преобразовать OpenDocument
- преобразовать ODP
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
description: "Преобразуйте OpenDocument ODP в PDF, PPT, PPTX, XPS, HTML, TIFF или SWF в Python с Aspose.Slides: примеры кода, высокое качество, пакетное преобразование и настройка."
---

## **Конвертировать ODP файлы**

[**Aspose.Slides API**](https://products.aspose.com/slides/python-net/) позволяет вам конвертировать презентации OpenOffice ODP в множество форматов. API, используемое для конвертации ODP‑файлов в другие форматы документов, такое же, как и для операций конвертации PowerPoint (PPT и PPTX).

Эти примеры показывают, как конвертировать ODP‑документы в другие форматы (просто замените исходный ODP‑файл):

- [Конвертировать ODP в HTML](/slides/ru/python-net/convert-powerpoint-to-html/)
- [Конвертировать ODP в PDF](/slides/ru/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [Конвертировать ODP в TIFF](/slides/ru/python-net/convert-powerpoint-to-tiff/)
- [Конвертировать ODP в SWF Flash](/slides/ru/python-net/convert-powerpoint-to-swf-flash/)
- [Конвертировать ODP в XPS](/slides/ru/python-net/convert-powerpoint-to-xps/)
- [Конвертировать ODP в PDF с заметками](/slides/ru/python-net/convert-powerpoint-to-pdf-with-notes/)
- [Конвертировать ODP в TIFF с заметками](/slides/ru/python-net/convert-powerpoint-to-tiff-with-notes/)

Например, если вам нужно конвертировать презентацию ODP в PDF, это можно сделать следующим образом:
```py
import aspose.slides as slides

pres = slides.Presentation("pres.odp")
pres.save("pres.pdf", slides.export.SaveFormat.PDF)
```


## **FAQ**

**Могу ли я конвертировать ODP в PPTX без установки LibreOffice или OpenOffice?**

Да. Aspose.Slides — полностью автономная библиотека, которая обрабатывает как форматы PowerPoint, так и OpenOffice без необходимости в сторонних приложениях.

**Открывает ли Aspose.Slides и сохраняет ли пароль‑защищённые ODP/OTP файлы?**

Да. Он может [загружать зашифрованные презентации](/slides/ru/python-net/password-protected-presentation/) когда вы предоставляете пароль и также может сохранять презентации с настройками шифрования и защиты.

**Могу ли я извлечь встроенные медиафайлы (audio/video) из ODP перед конвертацией?**

Да. Aspose.Slides позволяет вам получать доступ и извлекать встроенное [аудио](/slides/ru/python-net/audio-frame/) и [видео](/slides/ru/python-net/video-frame/) из презентаций, что полезно для предварительной обработки перед конвертацией или отдельного повторного использования.

**Могу ли я сохранить конвертированный ODP как Strict Office Open XML?**

Да. При сохранении в PPTX вы можете включить Strict OOXML через [параметры сохранения](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/) для соответствия более строгим требованиям совместимости.