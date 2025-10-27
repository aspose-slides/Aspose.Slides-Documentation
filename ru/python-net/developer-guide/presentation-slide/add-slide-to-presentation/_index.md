---
title: Добавление слайдов в презентации с помощью Python
linktitle: Добавить слайд
type: docs
weight: 10
url: /ru/python-net/add-slide-to-presentation/
keywords:
- add slide
- create slide
- empty slide
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Легко добавляйте слайды в презентации PowerPoint и OpenDocument с помощью Aspose.Slides for Python via .NET — бесшовное и эффективное вставление слайдов за секунды."
---

## **Обзор**

Прежде чем добавлять слайды в презентацию, полезно понять, как PowerPoint организует их. Каждая презентация содержит мастер‑слайд, необязательные слайды‑макеты и один или несколько обычных слайдов. У каждого слайда есть уникальный идентификатор, а обычные слайды упорядочены по нулевому индексу. Эта статья показывает, как использовать Aspose.Slides for Python для создания слайдов и выбора подходящих макетов.

## **Добавление слайдов в презентации**

Aspose.Slides позволяет добавлять новые слайды на основе существующих макетов. Пример ниже проходит по каждому макету в презентации, добавляет слайд, использующий этот макет, и затем сохраняет файл.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите доступ к [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/).
3. Для каждого элемента в `presentation.layout_slides` вызовите `add_empty_slide`, чтобы добавить слайд, использующий этот макет.
4. При необходимости измените только что добавленные слайды.
5. Сохраните презентацию в файл PPTX.

```py
import aspose.slides as slides

# Instantiate the Presentation class.
with slides.Presentation() as presentation:
    # Access the slide collection.
    slides = presentation.slides

    for layout_slide in presentation.layout_slides:
        # Add an empty slide to the slide collection.
        slides.add_empty_slide(layout_slide)

    # Do some work on the newly added slides.

    # Save the presentation to disk.
    presentation.save("empty_slides.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Можно ли вставить новый слайд в определённую позицию, а не только в конец?**

Да. Библиотека поддерживает операции над коллекциями слайдов и [insert](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_empty_slide/)/[clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_clone/) , поэтому вы можете добавить слайд в нужный индекс, а не только в конец.

**Сохраняются ли тема/стили при добавлении слайда на основе макета?**

Да. Макет наследует форматирование от своего мастера, а новый слайд наследует от выбранного макета и связанного с ним мастера.

**Какой слайд присутствует в новой «пустой» презентации до добавления слайдов?**

Новая созданная презентация уже содержит один пустой слайд с индексом ноль. Это важно учитывать при расчёте индексов вставки.

**Как выбрать «правильный» макет для нового слайда, если у мастера много вариантов?**

Обычно выбирают [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/), соответствующий требуемой структуре ([Title and Content, Two Content и т.д.](https://reference.aspose.com/slides/python-net/aspose.slides/slidelayouttype/)). Если такой макет отсутствует, вы можете [добавить его в мастер](/slides/ru/python-net/slide-layout/) и затем использовать его.