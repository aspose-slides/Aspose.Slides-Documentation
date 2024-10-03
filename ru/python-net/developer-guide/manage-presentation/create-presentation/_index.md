---
title: Создать презентацию
type: docs
weight: 10
url: /ru/python-net/create-presentation/
keywords: "Создать PowerPoint, PPTX, PPT, Создать презентацию, Инициализировать презентацию, Python, .NET"
description: "Открыть презентацию PowerPoint в Python"
---

## **Создать презентацию PowerPoint**
Чтобы добавить простую линию на выбранный слайд презентации, выполните следующие шаги:

1. Создайте экземпляр класса Presentation.
1. Получите ссылку на слайд, используя его индекс.
1. Добавьте автофигуру типа `LINE`, используя метод `add_auto_shape`, предоставленный объектом `shapes`.
1. Сохраните измененную презентацию в файл PPTX.

В примере ниже мы добавили линию на первый слайд презентации.

```py
import aspose.slides as slides

# Создайте объект Presentation, представляющий файл презентации
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)
    presentation.save("NewPresentation_out.pptx", slides.export.SaveFormat.PPTX)
```