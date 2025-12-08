---
title: Конвертация презентаций OpenDocument в Python
linktitle: Конвертация OpenDocument
type: docs
weight: 10
url: /ru/python-net/convert-openoffice-odp/
keywords:
- конвертация OpenDocument
- конвертация ODP
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
description: "Конвертировать OpenDocument ODP в PDF, PPT, PPTX, XPS, HTML, TIFF или SWF в Python с помощью Aspose.Slides: примеры кода, высокая точность, пакетная конвертация и настройка."
---

## **Конвертация файлов ODP**

[**Aspose.Slides API**](https://products.aspose.com/slides/python-net/) позволяет конвертировать презентации OpenOffice ODP во множество форматов. API, используемое для конвертации файлов ODP в другие форматы документов, такое же, как и для операций конвертации PowerPoint (PPT и PPTX). 

Эти примеры показывают, как конвертировать документы ODP в другие форматы (достаточно изменить исходный файл ODP):

- [Конвертировать ODP в HTML](/slides/ru/python-net/convert-powerpoint-ppt-and-pptx-to-html/)
- [Конвертировать ODP в PDF](/slides/ru/python-net/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [Конвертировать ODP в TIFF](/slides/ru/python-net/convert-powerpoint-to-tiff/)
- [Конвертировать ODP в SWF Flash](/slides/ru/python-net/convert-powerpoint-ppt-and-pptx-to-swf-flash/)
- [Конвертировать ODP в XPS](/slides/ru/python-net/convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document/)
- [Конвертировать ODP в PDF с примечаниями](/slides/ru/python-net/convert-powerpoint-ppt-and-pptx-to-pdf-with-notes/)
- [Конвертировать ODP в TIFF с примечаниями](/slides/ru/python-net/convert-powerpoint-ppt-and-pptx-to-tiff-with-notes/)

Например, если вам нужно конвертировать презентацию ODP в PDF, это можно сделать так:
```py
import aspose.slides as slides

pres = slides.Presentation("pres.odp")
pres.save("pres.pdf", slides.export.SaveFormat.PDF)
```


## **Часто задаваемые вопросы**

**Могу ли я конвертировать ODP в PPTX без установки LibreOffice или OpenOffice?**

Да. Aspose.Slides — полностью автономная библиотека, которая работает с форматами PowerPoint и OpenOffice без необходимости установки сторонних приложений.

**Открывает и сохраняет ли Aspose.Slides файлы ODP/OTP, защищённые паролем?**

Да. Она может [загружать зашифрованные презентации](/slides/ru/python-net/password-protected-presentation/) при указании пароля, а также сохранять презентации с настройками шифрования и защиты.

**Могу ли я извлечь встроенные медиафайлы (аудио/видео) из ODP перед конвертацией?**

Да. Aspose.Slides позволяет получить доступ к встроенным [аудио](/slides/ru/python-net/audio-frame/) и [видео](/slides/ru/python-net/video-frame/) файлам в презентациях и извлекать их, что полезно для предварительной обработки перед конвертацией или отдельного повторного использования.

**Могу ли я сохранить конвертированный ODP в формате Strict Office Open XML?**

Да. При сохранении в PPTX вы можете включить Strict OOXML через [параметры сохранения](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/), чтобы соответствовать более строгим требованиям к совместимости.