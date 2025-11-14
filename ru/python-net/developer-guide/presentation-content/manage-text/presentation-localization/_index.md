---
title: Автоматизируйте локализацию презентаций с помощью Python
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
description: "Автоматизируйте локализацию презентаций PowerPoint и OpenDocument с помощью Aspose.Slides for Python via .NET, используя практические примеры кода и рекомендации для быстрого глобального развертывания."
---

## **Изменение языка для презентации и текста фигуры**
- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- Получите ссылку на слайд, используя его индекс.
- Добавьте фигурную автоформу типа Прямоугольник на слайд.
- Добавьте некоторый текст в TextFrame.
- Установите идентификатор языка для текста.
- Сохраните презентацию в файл PPTX.

Реализация вышеуказанных шагов продемонстрирована ниже в примере.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)
    shape.add_text_frame("Текст для применения языка проверки орфографии")
    shape.text_frame.paragraphs[0].portions[0].portion_format.language_id = "en-EN"

    pres.save("test1.pptx", slides.export.SaveFormat.PPTX)
```