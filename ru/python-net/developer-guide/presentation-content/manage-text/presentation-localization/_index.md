---
title: Автоматизировать локализацию презентаций с помощью Python
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
description: "Автоматизировать локализацию слайдов PowerPoint и OpenDocument в Python с помощью Aspose.Slides, используя практические примеры кода и советы для более быстрого глобального развертывания."
---

## **Изменение языка для текста в презентации и фигуре**
- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- Получите ссылку на слайд, используя его индекс.
- Добавьте AutoShape типа Rectangle на слайд.
- Добавьте некоторый текст в TextFrame.
- Установите идентификатор языка для текста.
- Сохраните презентацию в файл PPTX.

Реализация вышеуказанных шагов продемонстрирована ниже в примере.
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)
    shape.add_text_frame("Text to apply spellcheck language")
    shape.text_frame.paragraphs[0].portions[0].portion_format.language_id = "en-EN"

    pres.save("test1.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Включает ли идентификатор языка автоматический перевод текста?**

Нет. [language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) в Aspose.Slides хранит язык для проверки орфографии и грамматики, но не переводит и не изменяет содержимое текста. Это метаданные, которые PowerPoint понимает для корректуры.

**Влияет ли идентификатор языка на переносы и разрывы строк при рендеринге?**

В Aspose.Slides [language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) используется для корректуры. Качество переноса слов и переносов строк в первую очередь зависит от наличия [proper fonts](/slides/ru/python-net/powerpoint-fonts/) и настроек раскладки/переноса для системы письма. Чтобы обеспечить правильный рендеринг, сделайте необходимые шрифты доступными, настройте [font substitution rules](/slides/ru/python-net/font-substitution/), и/или [embed fonts](/slides/ru/python-net/embedded-font/) в презентацию.

**Можно ли установить разные языки в одном абзаце?**

Да. [language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) применяется на уровне части текста, поэтому один абзац может содержать несколько языков с разными настройками корректуры.