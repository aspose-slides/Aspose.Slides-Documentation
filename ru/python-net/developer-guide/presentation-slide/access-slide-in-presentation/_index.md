---
title: Доступ к слайду в презентации
type: docs
weight: 20
url: /ru/python-net/access-slide-in-presentation/
keywords: "Доступ к презентации PowerPoint, Доступ к слайду, Изменение свойств слайда, Изменение позиции слайда, Установка номера слайда, индекса, ID, позиции Python, Aspose.Slides"
description: "Доступ к слайду PowerPoint по индексу, ID или позиции на Python. Изменение свойств слайда"
---

Aspose.Slides позволяет вам получать доступ к слайдам двумя способами: по индексу и по ID.

## **Доступ к слайду по индексу**

Все слайды в презентации расположены в числовом порядке, начиная с позиции 0. Первый слайд доступен через индекс 0; второй слайд доступен через индекс 1; и так далее.

Класс Presentation, представляющий файл презентации, предоставляет все слайды в виде коллекции [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) (коллекция объектов [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/)). Этот код на Python показывает, как получить доступ к слайду через его индекс:

```python
import aspose.slides as slides

# Создает объект Presentation, представляющий файл презентации
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Получает ссылку на слайд через его индекс
    slide = presentation.slides[0]
```

## **Доступ к слайду по ID**

Каждый слайд в презентации имеет уникальный ID, связанный с ним. Вы можете использовать метод `get_slide_by_id(id)` (предоставленный классом [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)) для доступа к этому ID. Этот код на Python показывает, как предоставить действительный ID слайда и получить доступ к этому слайду через метод `get_slide_by_id(id)`:

```python
import aspose.slides as slides

# Создает объект Presentation, представляющий файл презентации
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Получает ID слайда
    id = presentation.slides[0].slide_id
    # Получает доступ к слайду через его ID
    slide = presentation.get_slide_by_id(id)
```

## **Изменение позиции слайда**

Aspose.Slides позволяет изменять позицию слайда. Например, вы можете указать, что первый слайд должен стать вторым слайдом.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд (позицию которого вы хотите изменить) через его индекс.
1. Установите новую позицию для слайда через свойство `slide_number`.
1. Сохраните измененную презентацию.

Этот код на Python демонстрирует операцию, в которой слайд на позиции 1 перемещается на позицию 2:

```python
import aspose.slides as slides

# Создает объект Presentation, представляющий файл презентации
with slides.Presentation(path + "ChangePosition.pptx") as pres:
    # Получает слайд, позиция которого будет изменена
    sld = pres.slides[0]
    # Устанавливает новую позицию для слайда
    sld.slide_number = 2
    # Сохраняет измененную презентацию
    pres.save("Aspose_out.pptx", slides.export.SaveFormat.PPTX)
```

Первый слайд стал вторым; второй слайд стал первым. Когда вы изменяете позицию слайда, другие слайды автоматически настраиваются.

## **Установка номера слайда**

С помощью свойства `first_slide_number` (предоставленного классом [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)) вы можете указать новый номер для первого слайда в презентации. Эта операция приводит к перерасчету номеров других слайдов.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите номер слайда.
1. Установите номер слайда.
1. Сохраните измененную презентацию.

Этот код на Python демонстрирует операцию, где номер первого слайда устанавливается на 10:

```python
import aspose.slides as slides

# Создает объект Presentation, представляющий файл презентации
with slides.Presentation(path + "HelloWorld.pptx") as presentation:
    # Получает номер слайда
    firstSlideNumber = presentation.first_slide_number
    # Устанавливает номер слайда
    presentation.first_slide_number = 10
    # Сохраняет измененную презентацию
    presentation.save("Set_Slide_Number_out.pptx", slides.export.SaveFormat.PPTX)
```

Если вы предпочитаете пропустить первый слайд, вы можете начать нумерацию со второго слайда (и скрыть нумерацию для первого слайда) следующим образом:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)
    presentation.slides.add_empty_slide(layout_slide)

    # Устанавливает номер для первого слайда презентации
    presentation.first_slide_number = 0

    # Показывает номера слайдов для всех слайдов
    presentation.header_footer_manager.set_all_slide_numbers_visibility(True)

    # Скрывает номер слайда для первого слайда
    presentation.slides[0].header_footer_manager.set_slide_number_visibility(False)

    # Сохраняет измененную презентацию
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```