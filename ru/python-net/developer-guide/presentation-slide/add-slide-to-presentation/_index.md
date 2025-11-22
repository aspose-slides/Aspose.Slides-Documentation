---
title: Добавление слайдов в презентации с Python
linktitle: Добавить слайд
type: docs
weight: 10
url: /ru/python-net/add-slide-to-presentation/
keywords:
- добавить слайд
- создать слайд
- пустой слайд
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Легко добавляйте слайды в свои презентации PowerPoint и OpenDocument с помощью Aspose.Slides for Python через .NET — бесшовное, эффективное вставление слайдов за секунды."
---

## **Overview**

Прежде чем добавлять слайды в презентацию, полезно понять, как PowerPoint организует их. Каждая презентация содержит мастер‑слайд, необязательные слайды‑макеты и один или несколько обычных слайдов. Каждый слайд имеет уникальный идентификатор, а обычные слайды упорядочены по нулевому индексу. В этой статье показано, как использовать Aspose.Slides for Python для создания слайдов и выбора подходящих макетов.

## **Add Slides to Presentations**

Aspose.Slides позволяет добавлять новые слайды на основе существующих слайдов‑макетов. Приведённый ниже пример проходит по каждому макету в презентации, добавляет слайд, использующий этот макет, и затем сохраняет файл.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите доступ к [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/).
3. Для каждого элемента в `presentation.layout_slides` вызовите `add_empty_slide`, чтобы добавить слайд, использующий этот макет.
4. При необходимости измените только что добавленные слайды.
5. Сохраните презентацию в файл PPTX.
```py
import aspose.slides as slides

# Создать экземпляр класса Presentation.
with slides.Presentation() as presentation:
    # Получить доступ к коллекции слайдов.
    slides = presentation.slides

    for layout_slide in presentation.layout_slides:
        # Добавить пустой слайд в коллекцию слайдов.
        slides.add_empty_slide(layout_slide)

    # Выполнить некоторые действия с только что добавленными слайдами.

    # Сохранить презентацию на диск.
    presentation.save("empty_slides.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Can I insert a new slide at a specific position, not just at the end?**

Да. Библиотека поддерживает операции над коллекциями слайдов и [insert](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_empty_slide/)/[clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_clone/), поэтому вы можете добавить слайд по необходимому индексу, а не только в конец.

**Are the theme/styles preserved when adding a slide based on a layout?**

Да. Макет наследует форматирование от своего мастера, а новый слайд наследует его от выбранного макета и связанного с ним мастера.

**Which slide is present in a new "empty" presentation before adding slides?**

Новая созданная презентация уже содержит один пустой слайд с индексом ноль. Это важно учитывать при вычислении индексов вставки.

**How do I choose the "right" layout for a new slide if the master has many options?**

Обычно выбирают [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/), соответствующий требуемой структуре ([Title and Content, Two Content и др.](https://reference.aspose.com/slides/python-net/aspose.slides/slidelayouttype/)). Если такой макет отсутствует, вы можете [добавить его в мастер](/slides/ru/python-net/slide-layout/) и затем использовать его.