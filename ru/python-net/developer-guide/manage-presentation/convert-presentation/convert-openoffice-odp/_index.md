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
description: "Конвертировать OpenDocument ODP в PDF, PPT, PPTX, XPS, HTML, TIFF или SWF в Python с помощью Aspose.Slides: примеры кода, высокое качество, пакетное преобразование и настройка."
---

## **Конвертировать ODP файлы**

[**Aspose.Slides API**](https://products.aspose.com/slides/python-net/) позволяет конвертировать презентации OpenDocument (ODP) во многие форматы (HTML, PDF, TIFF, SWF, XPS и др.). API, используемое для конвертации ODP‑файлов в другие форматы документов, такое же, как и для операций конвертации PowerPoint (PPT и PPTX).

Например, если вам нужно конвертировать презентацию ODP в PDF, вы можете сделать это следующим образом:
```py
import aspose.slides as slides

with slides.Presentation("pres.odp") as presentation:
    presentation.save("pres.pdf", slides.export.SaveFormat.PDF)
```


## **Вопросы и ответы**

**Могу ли я конвертировать ODP в PPTX без установки LibreOffice или OpenOffice?**

Да. Aspose.Slides — полностью автономная библиотека, которая обрабатывает форматы PowerPoint и OpenOffice без необходимости внешних приложений.

**Открывает ли Aspose.Slides и сохраняет ли защищённые паролем ODP/OTP файлы?**

Да. Она может [загрузить зашифрованные презентации](/slides/ru/python-net/password-protected-presentation/), когда вы указываете пароль, и также может сохранять презентации с настройками шифрования и защиты.

**Могу ли я извлечь встроенные медиафайлы (аудио/видео) из ODP перед конвертацией?**

Да. Aspose.Slides позволяет получать доступ и извлекать встроенные [аудио](/slides/ru/python-net/audio-frame/) и [видео](/slides/ru/python-net/video-frame/) из презентаций, что удобно для предварительной обработки или отдельного повторного использования.

**Могу ли я сохранить конвертированный ODP в Strict Office Open XML?**

Да. При сохранении в PPTX вы можете включить Strict OOXML через [параметры сохранения](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/), чтобы соответствовать более строгим требованиям совместимости.