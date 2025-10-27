---
title: Access Slides in Presentations with Python
linktitle: Access Slide
type: docs
weight: 20
url: /ru/python-net/developer-guide/presentation-slide/access-slide-in-presentation/
keywords:
- access slide
- slide index
- slide id
- slide position
- change position
- slide properties
- slide number
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Learn how to access and manage slides in PowerPoint and OpenDocument presentations with Aspose.Slides for Python via .NET. Boost productivity with code examples."
---

## **Обзор**

В этой статье объясняется, как получить доступ к конкретным слайдам в презентации PowerPoint с помощью Aspose.Slides for Python. Показано, как открыть презентацию, обратиться к слайдам по индексу или уникальному идентификатору и прочитать базовую информацию о слайде, необходимую для навигации внутри файла. С помощью этих техник вы надёжно найдете нужный слайд для просмотра или обработки.

## **Получение слайда по индексу**

Слайды в презентации индексируются по позиции, начиная с 0. Первый слайд имеет индекс 0, второй — индекс 1 и так далее.

Класс [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) (который представляет файл презентации) предоставляет доступ к слайдам через [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) объектов [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/).

Следующий код на Python показывает, как получить слайд по его индексу:

```python
import aspose.slides as slides

# Create a Presentation that represents a presentation file.
with slides.Presentation("sample.pptx") as presentation:
    # Get a slide by its index.
    slide = presentation.slides[0]
```

## **Получение слайда по ID**

Каждый слайд в презентации имеет уникальный ID. Вы можете использовать метод [get_slide_by_id](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_slide_by_id/) (предоставляемый классом [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)) для доступа к слайду по этому ID.

Следующий код на Python демонстрирует, как задать действительный ID слайда и получить слайд через метод [get_slide_by_id](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/get_slide_by_id/):

```python
import aspose.slides as slides

# Create a Presentation that represents a presentation file.
with slides.Presentation("sample.pptx") as presentation:
    # Get a slide ID.
    id = presentation.slides[0].slide_id
    # Access the slide by its ID.
    slide = presentation.get_slide_by_id(id)
```

## **Изменение позиции слайда**

Aspose.Slides позволяет изменить позицию слайда. Например, можно сделать первый слайд вторым.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд, позицию которого нужно изменить, по его индексу.
3. Установите новую позицию для слайда через свойство [slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/).
4. Сохраните изменённую презентацию.

Следующий код на Python перемещает слайд с позиции 1 на позицию 2:

```python
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file.
with slides.Presentation("sample.pptx") as presentation:
    # Get the slide whose position will be changed.
    slide = presentation.slides[0]
    # Set the new position for the slide.
    slide.slide_number = 2
    # Save the modified presentation.
    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)
```

Первый слайд становится вторым; второй слайд становится первым. При изменении позиции слайда остальные слайды корректируются автоматически.

## **Установка номера слайда**

С помощью свойства [first_slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) (предоставляемого классом [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)) можно задавать новый номер для первого слайда в презентации. Эта операция приводит к перерасчёту номеров остальных слайдов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Установите номер слайда.
3. Сохраните изменённую презентацию.

Следующий код на Python демонстрирует задавание номера первого слайда равным 10:

```python
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file.
with slides.Presentation("sample.pptx") as presentation:
    # Set the slide number.
    presentation.first_slide_number = 10
    # Save the modified presentation.
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```

Если вы хотите пропустить первый слайд, можно начать нумерацию со второго слайда (и скрыть номер на первом) следующим образом:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)

    # Set the number for the first slide in the presentation.
    presentation.first_slide_number = 0

    # Show slide numbers for all slides.
    presentation.header_footer_manager.set_all_slide_numbers_visibility(True)

    # Hide the slide number on the first slide.
    presentation.slides[0].header_footer_manager.set_slide_number_visibility(False)

    # Save the modified presentation.
    presentation.save("first_slide_number.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Совпадает ли номер слайда, видимый пользователем, с нулевым индексом коллекции?**

Номер, отображаемый на слайде, может начинаться с произвольного значения (например, 10) и не обязан совпадать с индексом; взаимосвязь управляется параметром [first slide number](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) презентации.

**Влияют ли скрытые слайды на индексацию?**

Да. Скрытый слайд остаётся в коллекции и учитывается при индексации; «скрытый» относится к отображению, а не к его положению в коллекции.

**Изменяется ли индекс слайда при добавлении или удалении других слайдов?**

Да. Индексы всегда отражают текущий порядок слайдов и пересчитываются при вставке, удалении и перемещении.