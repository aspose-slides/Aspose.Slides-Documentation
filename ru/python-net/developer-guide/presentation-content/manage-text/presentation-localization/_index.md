---
title: "Автоматизация локализации презентаций с помощью Python"
linktitle: "Локализация презентаций"
type: docs
weight: 100
url: /ru/python-net/presentation-localization/
keywords:
- "смена языка"
- "проверка орфографии"
- "идентификатор языка"
- "PowerPoint"
- "презентация"
- "Python"
- "Aspose.Slides"
description: "Автоматизируйте локализацию слайдов PowerPoint и OpenDocument в Python с Aspose.Slides, используя практические примеры кода и советы для более быстрого глобального развертывания."
---

## **Изменение языка презентации и текста фигур**
- Создайте экземпляр класса [Презентация](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- Получите ссылку на слайд, используя его индекс.
- Добавьте AutoShape прямоугольного типа на слайд.
- Добавьте текст в TextFrame.
- Установите Language Id для текста.
- Сохраните презентацию как файл PPTX.

Реализация указанных шагов продемонстрирована ниже в примере.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)
    shape.add_text_frame("Text to apply spellcheck language")
    shape.text_frame.paragraphs[0].portions[0].portion_format.language_id = "en-EN"

    pres.save("test1.pptx", slides.export.SaveFormat.PPTX)
```

## **Вопросы и ответы**

**Вызывает ли language_id автоматический перевод текста?**

No. [language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) в Aspose.Slides хранит язык для проверки правописания и грамматики, но не переводит и не изменяет содержимое текста. Это метаданные, которые PowerPoint использует для проверки.

**Влияет ли language_id на переносы и расстановку дефисов при рендеринге?**

In Aspose.Slides, [language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) предназначен для проверки. Качество переноса и расстановки дефисов в первую очередь зависит от наличия [соответствующих шрифтов](/slides/ru/python-net/powerpoint-fonts/) и настроек разметки/переносов строк для системы письма. Чтобы обеспечить корректный рендеринг, сделайте необходимые шрифты доступными, настройте [правила замены шрифтов](/slides/ru/python-net/font-substitution/), и/или [встраивание шрифтов](/slides/ru/python-net/embedded-font/) в презентацию.

**Можно ли задать разные языки внутри одного абзаца?**

Yes. [language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) применяется на уровне части текста, поэтому один абзац может содержать несколько языков с различными настройками проверки.