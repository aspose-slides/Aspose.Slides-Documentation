---
title: Автоматизация локализации презентаций с Python
linktitle: Локализация презентаций
type: docs
weight: 100
url: /ru/python-net/presentation-localization/
keywords:
- смена языка
- проверка орфографии
- идентификатор языка
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Автоматизируйте локализацию слайдов PowerPoint и OpenDocument в Python с помощью Aspose.Slides, используя практические примеры кода и советы для более быстрого глобального развертывания."
---

## **Изменение языка для презентации и текста фигур**
- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
- Получите ссылку на слайд, используя его Index.
- Добавьте AutoShape типа Rectangle на слайд.
- Добавьте некоторый текст в TextFrame.
- Установите Language Id для текста.
- Сохраните презентацию в файл PPTX.

Реализация вышеуказанных шагов показана ниже в примере.
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)
    shape.add_text_frame("Text to apply spellcheck language")
    shape.text_frame.paragraphs[0].portions[0].portion_format.language_id = "en-EN"

    pres.save("test1.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Вызывает ли language_id автоматический перевод текста?**

No. [language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) в Aspose.Slides хранит язык для проверки орфографии и грамматики, но не переводит и не изменяет содержание текста. Это метаданные, которые PowerPoint понимает для проверки.

**Влияет ли language_id на переносы слов и разрывы строк при рендеринге?**

В Aspose.Slides [language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) используется для проверки. Качество переноса и перенос строк в основном зависит от наличия [соответствующих шрифтов](/slides/ru/python-net/powerpoint-fonts/) и настроек макета/переноса строк для системы письма. Чтобы обеспечить правильный рендеринг, сделайте необходимые шрифты доступными, настройте [правила замены шрифтов](/slides/ru/python-net/font-substitution/) и/или [встраивание шрифтов](/slides/ru/python-net/embedded-font/) в презентацию.

**Могу ли я установить разные языки в одном абзаце?**

Yes. [language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) применяется на уровне части текста, поэтому один абзац может смешивать несколько языков с отдельными настройками проверки.