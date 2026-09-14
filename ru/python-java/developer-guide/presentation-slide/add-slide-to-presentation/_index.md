---
title: Добавление слайдов в презентации на Python
linktitle: Добавить слайд
type: docs
weight: 10
url: /ru/python-java/add-slide-to-presentation/
keywords:
- добавить слайд
- создать слайд
- пустой слайд
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Легко добавляйте слайды в ваши презентации PowerPoint и OpenDocument с помощью Aspose.Slides for Python via Java — бесшовное, эффективное вставление слайдов за считанные секунды."
---
## **Обзор**

Aspose.Slides позволяет программно добавлять слайды в презентации PowerPoint. Презентация содержит слайды‑мастера/макета и обычные слайды, и обычные слайды упорядочены по нулевому индексу. Каждый слайд имеет уникальный идентификатор, а файлы презентаций без слайдов не поддерживаются.

В этой статье объясняется, как создать объект [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) , получить его коллекцию слайдов, добавить пустой слайд, работать с только что добавленным слайдом и сохранить обновлённую презентацию. Также рассматриваются связанные вопросы, такие как вставка слайдов в определённую позицию, использование макетов и понимание пустого слайда, который существует в только что созданной презентации.

## **Добавление слайда в презентацию**

Прежде чем обсуждать, как добавлять слайды в файлы презентаций, рассмотрим некоторые факты о слайдах. Каждый файл презентации PowerPoint содержит **мастер/макет**‑слайды и **обычные** слайды. Файл презентации содержит как минимум один слайд. Файлы презентаций без слайдов не поддерживаются Aspose.Slides for Python via Java. Каждый слайд имеет уникальный идентификатор, и все обычные слайды упорядочены в порядке, задаваемом нулевым индексом.

Aspose.Slides for Python via Java позволяет разработчикам добавлять пустые слайды в свои презентации. Чтобы добавить пустой слайд в презентацию, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) .
- Получите ссылку на объект [SlideCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slidecollection/) с помощью метода [getSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getSlides) , предоставляемого объектом [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) .
- Добавьте пустой слайд в конец коллекции слайдов презентации, вызвав метод [addEmptySlide](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slidecollection/#addEmptySlide) , предоставляемый объектом [SlideCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slidecollection/) .
- Выполните необходимые действия с только что добавленным пустым слайдом.
- Наконец, запишите файл презентации, используя объект [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) .

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Создайте экземпляр класса Presentation, представляющего файл презентации.
presentation = Presentation()
try:
    # Получить коллекцию слайдов.
    slides = presentation.getSlides()

    for i in range(presentation.getLayoutSlides().size()):
        # Добавить пустой слайд в коллекцию слайдов.
        slides.addEmptySlide(presentation.getLayoutSlides().get_Item(i))

    # Выполнить некоторые действия с только что добавленным слайдом.

    # Сохранить файл PPTX на диск.
    presentation.save("EmptySlide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Могу ли я вставить новый слайд в определённую позицию, а не только в конец?**

Да. Библиотека поддерживает операции над коллекциями слайдов и [insert](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slidecollection/#insertEmptySlide)/[clone](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slidecollection/#insertClone) , поэтому можно добавить слайд по требуемому индексу, а не только в конец.

**Сохраняются ли темы/стили при добавлении слайда на основе макета?**

Да. Макет наследует форматирование от своего мастера, а новый слайд наследует его от выбранного макета и связанного с ним мастера.

**Какой слайд присутствует в новой «пустой» презентации до добавления слайдов?**

В только что созданной презентации уже есть один пустой слайд с индексом ноль. Это важно учитывать при расчёте индексов вставки.

**Как выбрать «правильный» макет для нового слайда, если у мастера много вариантов?**

Обычно выбирают [LayoutSlide](https://reference.aspose.com/slides/ru/python-java/aspose.slides/layoutslide/) , который соответствует требуемой структуре ([Title and Content, Two Content и т.д.](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slidelayouttype/)). Если такой макет отсутствует, его можно [add it to the master](/slides/ru/python-java/slide-layout/) и затем использовать.