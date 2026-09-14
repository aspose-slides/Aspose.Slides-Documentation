---
title: Клонирование слайдов презентации в Python
linktitle: Клонирование слайдов
type: docs
weight: 35
url: /ru/python-java/clone-slides/
keywords:
- клонировать слайд
- копировать слайд
- сохранить слайд
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Быстро дублируйте слайды PowerPoint с помощью Aspose.Slides for Python via Java. Следуйте нашим понятным примерам кода, чтобы за секунды автоматизировать создание PPT и избавиться от ручной работы."
---
## **Введение**

Клонирование – это процесс создания точной копии или реплики чего‑либо. Aspose.Slides for Python via Java также позволяет сделать копию или клон любого слайда и затем вставить этот склонированный слайд в текущую презентацию или любую другую открытую презентацию. Процесс клонирования слайда создаёт новый слайд, который разработчики могут изменять, не изменяя оригинальный слайд. Существует несколько возможных способов клонирования слайда:

- Клонировать в конец текущей презентации.
- Клонировать в другое место текущей презентации.
- Клонировать в конец другой презентации.
- Клонировать в другое место другой презентации.
- Клонировать вместе с её мастер‑слайдом в другую презентацию.

В Aspose.Slides for Python via Java коллекция слайдов (коллекция объектов [Slide](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slide/)) , доступная через объект [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/), предоставляет методы [addClone](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slidecollection/#addClone) и [insertClone](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slidecollection/#insertClone) для выполнения перечисленных вариантов клонирования слайда.

## **Клонирование слайда в конец презентации**

Если нужно клонировать слайд и затем использовать его в том же файле презентации в конце существующих слайдов, используйте метод [addClone](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slidecollection/#addClone) согласно шагам ниже:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
1. Получите объект [SlideCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slidecollection/) , обратившись к коллекции Slides, предоставляемой объектом [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
1. Вызовите метод [addClone](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slidecollection/#addClone), предоставляемый объектом [SlideCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slidecollection/), передав в него слайд, который нужно клонировать.
1. Запишите изменённый файл презентации.

В примере ниже мы клонировали слайд (находящийся в первой позиции – ноль‑индекс – презентации) в конец презентации.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Создайте экземпляр класса Presentation, представляющего файл презентации
presentation = Presentation("CloneWithinSamePresentationToEnd.pptx")
try:
    # Клонируйте выбранный слайд в конец коллекции слайдов той же презентации
    slides = presentation.getSlides()

    slides.addClone(presentation.getSlides().get_Item(0))

    # Запишите изменённую презентацию на диск
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Клонирование слайда в другое положение внутри презентации**

Если нужно клонировать слайд и затем использовать его в том же файле презентации, но в другом месте, используйте метод [insertClone](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slidecollection/#insertClone):

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
1. Получите ссылку на коллекцию слайдов, возвращаемую методом [getSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getSlides) объекта [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).
1. Вызовите метод [insertClone](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slidecollection/#insertClone), предоставляемый объектом [SlideCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slidecollection/), передав в него слайд, который нужно клонировать, и индекс нового положения.
1. Запишите изменённую презентацию в файл PPTX.

В примере ниже мы клонировали слайд (находящийся в индексе 1 – позиция 2 – презентации) в индекс 2 – позицию 3 – презентации.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Создайте экземпляр класса Presentation, представляющего файл презентации
presentation = Presentation("CloneWithInSamePresentation.pptx")
try:
    # Получите коллекцию слайдов в презентации
    slides = presentation.getSlides()

    # Клонируйте выбранный слайд в указанный индекс в той же презентации
    slides.insertClone(2, presentation.getSlides().get_Item(1))

    # Запишите изменённую презентацию на диск
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Клонирование слайда в конец другой презентации**

Если требуется клонировать слайд из одной презентации и использовать его в другой презентации, в конце существующих слайдов:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/), содержащий презентацию, из которой будет клонирован слайд.
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/), содержащий целевую презентацию, в которую будет добавлен слайд.
1. Получите объект [SlideCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slidecollection/) , обратившись к коллекции слайдов, возвращаемой методом [getSlides](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#getSlides) объекта [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) целевой презентации.
1. Вызовите метод [addClone](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slidecollection/#addClone), предоставляемый объектом [SlideCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slidecollection/), передав в него слайд из исходной презентации.
1. Запишите изменённый файл целевой презентации.

В примере ниже мы клонировали слайд (из индекса 0 исходной презентации) в конец целевой презентации.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Создайте экземпляр класса Presentation для загрузки исходного файла презентации
source_presentation = Presentation("CloneAtEndOfAnother.pptx")
try:
    # Создайте экземпляр класса Presentation для целевой PPTX (куда будет клонирован слайд)
    destination_presentation = Presentation()
    try:
        # Клонируйте выбранный слайд из исходной презентации в конец коллекции слайдов целевой презентации
        slides = destination_presentation.getSlides()

        slides.addClone(source_presentation.getSlides().get_Item(0))

        # Запишите целевую презентацию на диск
        destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Клонирование слайда в другое положение в другой презентации**

Если необходимо клонировать слайд из одной презентации и использовать его в другой презентации в конкретном месте:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/), содержащий исходную презентацию, из которой будет клонирован слайд.
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/), содержащий презентацию, в которую будет добавлен слайд.
1. Получите объект [SlideCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slidecollection/) , обратившись к коллекции Slides, предоставляемой объектом [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) целевой презентации.
1. Вызовите метод [insertClone](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slidecollection/#insertClone), предоставляемый объектом [SlideCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slidecollection/), передав в него слайд из исходной презентации и желаемую позицию.
1. Запишите изменённый файл целевой презентации.

В примере ниже мы клонировали слайд (из ноль‑индекса исходной презентации) в индекс 1 (позиция 2) целевой презентации.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Создайте экземпляр класса Presentation для загрузки исходного файла презентации
source_presentation = Presentation("CloneAtEndOfAnother.pptx")
try:
    # Создайте экземпляр класса Presentation для целевого PPTX (куда будет клонирован слайд)
    destination_presentation = Presentation()
    try:
        # Клонируйте выбранный слайд из исходной презентации в указанный индекс целевой презентации
        slides = destination_presentation.getSlides()

        slides.insertClone(1, source_presentation.getSlides().get_Item(0))

        # Запишите целевую презентацию на диск
        destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Клонирование слайда с его мастер‑слайдом в другую презентацию**

Если необходимо клонировать слайд вместе с мастер‑слайдом из одной презентации и использовать его в другой презентации, сначала нужно клонировать нужный мастер‑слайд из исходной презентации в целевую презентацию. Затем при клонировании слайда использовать склонированный мастер‑слайд. Метод [addClone](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slidecollection/#addClone) ожидает мастер‑слайд из целевой презентации, а не из исходной. Чтобы клонировать слайд с мастером, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/), содержащий исходную презентацию, из которой будет клонирован слайд.
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/), содержащий целевую презентацию, в которую будет клонирован слайд.
1. Получите доступ к слайду, который будет клонирован, вместе с его мастер‑слайдом.
1. Получите объект [MasterSlideCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masterslidecollection/) , обратившись к коллекции Masters, предоставляемой объектом [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) целевой презентации.
1. Вызовите метод [addClone](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masterslidecollection/#addClone), предоставляемый объектом [MasterSlideCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/masterslidecollection/), передав в него мастер‑слайд из исходного PPTX.
1. Получите объект [SlideCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slidecollection/) , обратившись к коллекции Slides, предоставляемой объектом [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) целевой презентации.
1. Вызовите метод [addClone](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slidecollection/#addClone), предоставляемый объектом [SlideCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slidecollection/), передав в него слайд из исходной презентации и мастер‑слайд.
1. Запишите изменённый файл целевой презентации.

В примере ниже мы клонировали слайд с мастером (находящийся в ноль‑индексе исходной презентации) в конец целевой презентации, используя мастер‑слайд исходного слайда.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

    # Создайте экземпляр класса Presentation для загрузки исходного файла презентации
source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    # Создайте экземпляр класса Presentation для целевой презентации (куда будет клонирован слайд)
    destination_presentation = Presentation()
    try:
        # Создайте объект Slide из коллекции слайдов в исходной презентации вместе с
        # Мастер‑слайдом
        source_slide = source_presentation.getSlides().get_Item(0)
        source_master = source_slide.getLayoutSlide().getMasterSlide()

        # Клонируйте нужный мастер‑слайд из исходной презентации в коллекцию мастеров в
        # целевой презентации
        masters = destination_presentation.getMasters()
        destination_master = masters.addClone(source_master)

        # Клонируйте нужный слайд из исходной презентации с нужным мастером в конец
        # коллекции слайдов в целевой презентации
        slides = destination_presentation.getSlides()
        slides.addClone(source_slide, destination_master, True)

        # Сохраните целевую презентацию на диск
        destination_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Клонирование слайда в конец указанного раздела**

Если нужно клонировать слайд и затем использовать его в той же презентации, но в другом разделе, используйте метод [**addClone**](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slidecollection/#addClone), предоставляемый классом [**SlideCollection**](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slidecollection/). Aspose.Slides for Python via Java позволяет клонировать слайд из первого раздела и вставить его в второй раздел той же презентации.

Следующий фрагмент кода показывает, как клонировать слайд и вставить его в указанный раздел.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100)
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0))

    destination_section = presentation.getSections().appendEmptySection("Section 2")
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), destination_section)

    # Сохраните целевую презентацию на диск
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Обеспечение совпадения размера слайда**

При клонировании слайдов в другую презентацию убедитесь, что у целевой презентации такой же размер слайда, как у исходной. Если размеры отличаются, Aspose.Slides не масштабирует автоматически склонированные фигуры — их исходные координаты и размеры сохраняются, что может привести к смещению содержимого или выходу его за границы слайда.

Вы можете установить размер слайда целевой презентации, соответствующий размеру исходной, перед клонированием мастера и слайда:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType

source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    target_presentation = Presentation()
    try:
        source_size = source_presentation.getSlideSize().getSize()
        target_presentation.getSlideSize().setSize(jpype.JFloat(source_size.getWidth()), jpype.JFloat(source_size.getHeight()), SlideSizeScaleType.DoNotScale)
    finally:
        target_presentation.dispose()
finally:
    source_presentation.dispose()
```

Сделайте это до клонирования мастера и слайда.

## **FAQ**

**Клонируются ли заметки докладчика и комментарии рецензента?**

Да. Страницы заметок и комментарии рецензента включаются в клон. Если они вам не нужны, [удалите их](/slides/ru/python-java/presentation-notes/) после вставки.

**Как обрабатываются диаграммы и их источники данных?**

Объект диаграммы, её форматирование и встроенные данные копируются. Если диаграмма была связана с внешним источником (например, книгой OLE), эта связь сохраняется как [OLE‑объект](/slides/ru/python-java/manage-ole/). После перемещения между файлами проверьте доступность данных и поведение обновления.

**Можно ли управлять позицией вставки и разделами для клона?**

Да. Вы можете вставить клон в определённый индекс слайда и поместить его в выбранный [раздел](/slides/ru/python-java/slide-section/). Если целевой раздел не существует, создайте его сначала, а затем переместите в него слайд.