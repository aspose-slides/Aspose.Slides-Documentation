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
description: "Легко добавляйте слайды в ваши презентации PowerPoint и OpenDocument с помощью Aspose.Slides для Python через .NET — бесшовное, эффективное вставление слайдов за секунды."
---

## **Обзор**

Прежде чем добавлять слайды в презентацию, полезно понять, как PowerPoint их организует. Каждая презентация содержит главный слайд‑шаблон, необязательные шаблоны раскладки и один или несколько обычных слайдов. Каждый слайд имеет уникальный идентификатор, а обычные слайды упорядочены по нулевому индексу. В этой статье показано, как использовать Aspose.Slides для Python, чтобы создавать слайды и выбирать подходящие раскладки.

## **Добавление слайдов в презентацию**

Aspose.Slides позволяет добавлять новые слайды на основе существующих шаблонов раскладки. В примере ниже происходит перебор каждой раскладки в презентации, добавляется слайд, использующий эту раскладку, и затем файл сохраняется.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите доступ к [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/).
3. Для каждого элемента в `presentation.layout_slides` вызовите `add_empty_slide`, чтобы добавить слайд, использующий этот макет.
4. При необходимости измените только что добавленные слайды.
5. Сохраните презентацию в файл PPTX.

```py
import aspose.slides as slides

# Создать объект класса Presentation.
with slides.Presentation() as presentation:
    # Получить доступ к коллекции слайдов.
    slides = presentation.slides

    for layout_slide in presentation.layout_slides:
        # Добавить пустой слайд в коллекцию слайдов.
        slides.add_empty_slide(layout_slide)

    # Выполнить работу с только что добавленными слайдами.

    # Сохранить презентацию на диск.
    presentation.save("empty_slides.pptx", slides.export.SaveFormat.PPTX)
```

## **Часто задаваемые вопросы**

**Могу ли я вставить новый слайд в определённую позицию, а не только в конец?**

Да. Библиотека поддерживает коллекции слайдов и операции [insert](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_empty_slide/)/[clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_clone/), поэтому вы можете добавить слайд в нужный индекс, а не только в конец.

**Сохраняются ли темы/стили при добавлении слайда на основе макета?**

Да. Макет наследует форматирование от своего мастера, а новый слайд наследует от выбранного макета и связанного с ним мастера.

**Какой слайд присутствует в новой «пустой» презентации до добавления слайдов?**

В новой созданной презентации уже содержится один пустой слайд с индексом 0. Это важно учитывать при расчёте индексов вставки.

**Как выбрать «правильный» макет для нового слайда, если у мастера много вариантов?**

Обычно выбирают [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/), который соответствует требуемой структуре ([Title and Content, Two Content и т.д.](https://reference.aspose.com/slides/python-net/aspose.slides/slidelayouttype/)). Если такой макет отсутствует, его можно [add it to the master](/slides/ru/python-net/slide-layout/) и затем использовать.