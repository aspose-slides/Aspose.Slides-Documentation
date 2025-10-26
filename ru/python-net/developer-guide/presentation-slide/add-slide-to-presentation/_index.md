---
title: Добавление слайдов в презентации с помощью Python
linktitle: Добавить слайд
type: docs
weight: 10
url: /ru/python-net/developer-guide/presentation-slide/add-slide-to-presentation/
keywords:
- добавить слайд
- создать слайд
- пустой слайд
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Легко добавляйте слайды в ваши презентации PowerPoint и OpenDocument с помощью Aspose.Slides для Python через .NET — бесшовное, эффективное вставление слайдов за секунды."
---

## **Обзор**

Прежде чем добавлять слайды в презентацию, полезно понять, как PowerPoint структурирует их. Каждая презентация содержит главный слайд‑шаблон, необязательные макетные слайды и один или несколько обычных слайдов. Каждый слайд имеет уникальный идентификатор, а обычные слайды упорядочены по нулевому индексу. В этой статье показано, как с помощью Aspose.Slides для Python создавать слайды и выбирать подходящие макеты.

## **Добавление слайдов в презентацию**

Aspose.Slides позволяет добавлять новые слайды на основе существующих макетных слайдов. Пример ниже перебирает каждый макет в презентации, добавляет слайд, использующий этот макет, и затем сохраняет файл.

1. Создайте объект класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите доступ к [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/).
1. Для каждого элемента в `presentation.layout_slides` вызовите `add_empty_slide`, чтобы добавить слайд, использующий данный макет.
1. При необходимости измените только что добавленные слайды.
1. Сохраните презентацию в формате PPTX.

```py
import aspose.slides as slides

# Создаём объект класса Presentation.
with slides.Presentation() as presentation:
    # Получаем коллекцию слайдов.
    slides = presentation.slides

    for layout_slide in presentation.layout_slides:
        # Добавляем пустой слайд в коллекцию слайдов.
        slides.add_empty_slide(layout_slide)

    # Выполняем необходимые действия с только что добавленными слайдами.

    # Сохраняем презентацию на диск.
    presentation.save("empty_slides.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Можно ли вставить новый слайд в определённую позицию, а не только в конец?**

Да. Библиотека поддерживает операции над коллекцией слайдов и методы [insert](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_empty_slide/)/[clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/insert_clone/), поэтому вы можете добавить слайд в требуемый индекс, а не только в конец.

**Сохраняются ли темы/стили при добавлении слайда на основе макета?**

Да. Макет наследует форматирование от своего мастера, а новый слайд наследует форматирование от выбранного макета и связанного с ним мастера.

**Какой слайд присутствует в новой «пустой» презентации до добавления слайдов?**

В недавно созданной презентации уже содержится один пустой слайд с индексом ноль. Это важно учитывать при расчёте индексов вставки.

**Как выбрать «правильный» макет для нового слайда, если у мастера много вариантов?**

Обычно выбирают [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/), соответствующий требуемой структуре ([Заголовок и содержание, Два содержания и т.д.](https://reference.aspose.com/slides/python-net/aspose.slides/slidelayouttype/)). Если такой макет отсутствует, его можно [добавить в мастер](/slides/ru/python-net/slide-layout/) и затем использовать.