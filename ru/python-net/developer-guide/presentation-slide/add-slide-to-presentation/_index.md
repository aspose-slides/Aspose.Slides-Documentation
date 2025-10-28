---
title: Добавление слайдов в презентации с помощью Python
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
description: "Легко добавляйте слайды в ваши презентации PowerPoint и OpenDocument с помощью Aspose.Slides для Python через .NET — бесшовное, эффективное вставление слайдов за считанные секунды."
---

## **Обзор**

Прежде чем добавлять слайды в презентацию, полезно понять, как PowerPoint их организует. Каждая презентация содержит главный слайд‑шаблон, необязательные слайды‑макеты и один или несколько обычных слайдов. Каждый слайд имеет уникальный идентификатор, а обычные слайды упорядочены по индексу, начинающемуся с нуля. В этой статье показано, как использовать Aspose.Slides для Python, чтобы создавать слайды и выбирать подходящие макеты.

## **Добавление слайдов в презентации**

Aspose.Slides позволяет добавлять новые слайды на основе существующих слайдов‑макетов. Приведённый ниже пример проходит по каждому макету в презентации, добавляет слайд, использующий этот макет, и затем сохраняет файл.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите доступ к [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/).
1. Для каждого элемента в `presentation.layout_slides` вызовите `add_empty_slide`, чтобы добавить слайд, использующий этот макет.
1. При необходимости измените только что добавленные слайды.
1. Сохраните презентацию как файл PPTX.

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

Да. Библиотека поддерживает операции над коллекциями слайдов и [insert](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_empty_slide/)/[clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_clone/), поэтому вы можете добавить слайд в требуемый индекс, а не только в конец.

**Сохраняются ли темы/стили при добавлении слайда на основе макета?**

Да. Макет наследует форматирование от своего главного шаблона, а новый слайд наследует его от выбранного макета и связанного с ним главного шаблона.

**Какой слайд присутствует в новой «пустой» презентации перед добавлением слайдов?**

Новосозданная презентация уже содержит один пустой слайд с индексом ноль. Это важно учитывать при расчёте индексов вставки.

**Как выбрать «правильный» макет для нового слайда, если у главного шаблона много вариантов?**

Обычно выбирают [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/), который соответствует требуемой структуре ([Title and Content, Two Content и т.д.](https://reference.aspose.com/slides/python-net/aspose.slides/slidelayouttype/)). Если такой макет отсутствует, вы можете [add it to the master](/slides/ru/python-net/slide-layout/) и затем использовать его.