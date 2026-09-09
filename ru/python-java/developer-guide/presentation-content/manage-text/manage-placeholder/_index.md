---
title: Управление заполнителями презентации в Python
linktitle: Управление заполнителями
type: docs
weight: 10
url: /ru/python-java/manage-placeholder/
keywords:
- заполнитель
- текстовый заполнитель
- заполнитель изображения
- заполнитель диаграммы
- заполнитель содержимого
- текст подсказки
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Узнайте, как просматривать и изменять текстовые, графические, диаграммные и содержательные заполнители, а также понять наследование заполнителей с помощью Aspose.Slides для Python через Java."
---
## **Обзор**

Заполнитель – это фигура, которая резервирует позицию для определенного типа содержимого в шаблоне презентации. Распространенные примеры включают заголовок, основное содержание, изображение, диаграмму и универсальные заполнители содержимого. В отличие от обычной фигуры, заполнитель может наследовать свою позицию, размер, форматирование и другие параметры от слайда‑макета или слайда‑шаблона.

Aspose.Slides предоставляет информацию о заполнителях через метод [Shape.getPlaceholder](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getPlaceholder). Метод возвращает объект [Placeholder](https://reference.aspose.com/slides/ru/python-java/aspose.slides/placeholder/) или `None` для обычной фигуры. Используйте [Placeholder.getType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/placeholder/#getType), чтобы определить, какое содержимое предназначено для заполнителя.

Тип фигуры все равно важен после того, как вы узнали тип заполнителя:

- Пустой текстовый, изображенный, диаграммный или содержательный заполнитель обычно представлен объектом [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/).
- Заполненный заполнитель изображения может быть представлен объектом [PictureFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pictureframe/).
- Заполненный заполнитель диаграммы может быть представлен объектом [Chart](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chart/).
- Заполнитель содержимого может содержать несколько видов контента. Проверьте как [Placeholder.getType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/placeholder/#getType), так и тип фигуры во время выполнения, вместо предположения, что каждый заполнитель является [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/placeholder/#getType) описывает роль заполнителя; он не гарантирует тип фигуры во время выполнения. Всегда проверяйте тип перед доступом к тексту, изображению, диаграмме, таблице или медиа‑специфическим членам.
{{% /alert %}}

## **Понимание наследования заполнителей**

Заполнители образуют иерархию:

1. Слайд‑шаблон определяет переиспользуемые стили и, в некоторых случаях, заполнители уровня шаблона.
2. Слайд‑макет определяет расположение, используемое одним или несколькими обычными слайдами, и может наследовать от шаблона.
3. Обычный слайд содержит заполнители для этого слайда и может наследовать от его макета.

Вызовите [Shape.getBasePlaceholder](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getBasePlaceholder), чтобы перейти на один уровень выше в этой иерархии. Заполнитель слайда обычно возвращает свой заполнитель макета; заполнитель макета может вернуть свой заполнитель шаблона. Метод возвращает `None`, когда у фигуры нет базового заполнителя.

Следующий пример выводит список заполнителей на первом слайде и показывает их базовые заполнители:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        type_name = shape.getClass().getSimpleName()
        print(f"Slide placeholder: {placeholder_type}; shape type: {type_name}")

        layout_placeholder = shape.getBasePlaceholder()
        if layout_placeholder is not None:
            layout_placeholder_info = layout_placeholder.getPlaceholder()
            layout_placeholder_type = None if layout_placeholder_info is None else layout_placeholder_info.getType()
            print(f"  Layout placeholder: {layout_placeholder_type}")

            master_placeholder = layout_placeholder.getBasePlaceholder()
            if master_placeholder is not None:
                master_placeholder_info = master_placeholder.getPlaceholder()
                master_placeholder_type = None if master_placeholder_info is None else master_placeholder_info.getType()
                print(f"  Master placeholder: {master_placeholder_type}")
finally:
    presentation.dispose()
```

Редактирование заполнителя на обычном слайде создаёт или изменяет локальное переопределение для этого слайда. Редактирование связанного макета или шаблона может повлиять на все слайды, которые всё ещё наследуют эту настройку. Обычная локальная фигура не имеет базового заполнителя и не начинает наследовать просто потому, что занимает те же координаты.

## **Изменение текста в заполнителе**

Заполнители заголовка, центрированного заголовка, подзаголовка, основного текста и текста обычно поддерживают текст. Проверьте, является ли фигура [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/) перед тем как использовать её метод [getTextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/#getTextFrame).

Этот пример обновляет первый заполнитель заголовка на первом слайде и сохраняет результат:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PlaceholderType, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    title_shape = None

    for shape in slide.getShapes():
        if not isinstance(shape, AutoShape):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle):
            title_shape = shape
            break

    if title_shape is None:
        print("The first slide does not contain a title placeholder.")
    else:
        title_shape.getTextFrame().setText("Quarterly Business Review")
        presentation.save("title-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Этот шаблон позволяет избежать обработки заполнителей изображений, диаграмм, таблиц или медиа как [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/). Он также определяет заполнитель по назначению, а не полагается на хрупкий индекс фигуры.

## **Установка текста подсказки в макете**

Текст подсказки — это инструкция, отображаемая в пустом заполнителе в режиме дизайна, например *Click to add title*. Установите пользовательский текст подсказки в заполнителе макета, а не пытайтесь получить его через коллекцию фигур обычного слайда. Доступ к макету осуществляется через [Slide.getLayoutSlide](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slide/#getLayoutSlide), а затем перебирается коллекция, возвращаемая [BaseSlide.getShapes](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseslide/#getShapes).

Следующий пример меняет подсказки заголовка и подзаголовка в макете, используемом первым слайдом:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PlaceholderType, SaveFormat

presentation = Presentation("template.pptx")
try:
    layout_slide = presentation.getSlides().get_Item(0).getLayoutSlide()

    for shape in layout_slide.getShapes():
        if not isinstance(shape, AutoShape):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle):
            shape.getTextFrame().setText("Enter a concise slide title")
        elif placeholder_type == PlaceholderType.Subtitle:
            shape.getTextFrame().setText("Enter a subtitle or reporting period")

    presentation.save("custom-placeholder-prompts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Текст подсказки не является обычным содержимым слайда. Он предназначен для пустых заполнителей в приложениях редактирования, таких как PowerPoint. Как только пользователь или программа предоставляют реальное содержимое, подсказка более не отображается. Изменение подсказки также не заменяет существующий текст на слайдах, использующих этот макет.

## **Обновление заполнителя изображения**

Существует два случая, которые нужно обработать:

- Если заполнитель изображения уже заполнен и представлен объектом [PictureFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pictureframe/), замените изображение через [PictureFillFormat.getPicture](https://reference.aspose.com/slides/ru/python-java/aspose.slides/picturefillformat/#getPicture) и [Picture.setImage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/picture/#setImage).
- Если он всё ещё пустой, добавьте рамку изображения в координатах заполнителя с помощью [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/#addPictureFrame) и удалите пустой заполнитель.

Следующий пример поддерживает оба случая и сохраняет презентацию:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PictureFrame, PlaceholderType, ShapeType, SaveFormat

presentation = Presentation("picture-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_placeholder = None

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is not None and placeholder.getType() == PlaceholderType.Picture:
            picture_placeholder = shape
            break

    if picture_placeholder is None:
        print("The first slide does not contain a picture placeholder.")
    else:
        image_bytes = Path("replacement.png").read_bytes()
        java_image_bytes = jpype.JArray(jpype.JByte)(image_bytes)
        image = presentation.getImages().addImage(java_image_bytes)

        if isinstance(picture_placeholder, PictureFrame):
            picture_placeholder.getPictureFormat().getPicture().setImage(image)
        else:
            slide.getShapes().addPictureFrame(ShapeType.Rectangle, picture_placeholder.getX(), picture_placeholder.getY(), picture_placeholder.getWidth(), picture_placeholder.getHeight(), image)
            slide.getShapes().remove(picture_placeholder)

        presentation.save("picture-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Замена, созданная для пустого заполнителя, представляет собой локальную рамку изображения, а не новый заполнитель, потому что [Shape.getPlaceholder](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getPlaceholder) не предоставляет сеттера. Она сохраняет зарезервированную позицию, но более не наследует поведение, специфичное для заполнителя. Если сохранение отношения заполнителя критично, подготовьте и заполните заполнитель в PowerPoint сначала, а затем обновите полученный [PictureFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pictureframe/) с помощью Aspose.Slides.

Для прозрачности изображения, обрезки и других эффектов, специфичных для изображений, см. [Manage Picture Frames](/slides/ru/python-java/picture-frame/). Эти операции относятся к рамке изображения или заливке изображения, а не к метаданным заполнителя.

## **Работа с заполнителями диаграмм и содержимого**

Заполненный заполнитель диаграммы может быть представлен объектом [Chart](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chart/). Этот пример находит такую диаграмму по типу заполнителя и типу фигуры во время выполнения, меняет её заголовок и сохраняет файл:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Chart, PlaceholderType, SaveFormat

presentation = Presentation("chart-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    placeholder_chart = None

    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is not None and placeholder.getType() == PlaceholderType.Chart:
            placeholder_chart = shape
            break

    if placeholder_chart is None:
        print("The first slide does not contain a populated chart placeholder.")
    else:
        placeholder_chart.setTitle(True)
        placeholder_chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue")
        presentation.save("chart-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Общий заполнитель содержимого обычно имеет тип [PlaceholderType.Object](https://reference.aspose.com/slides/ru/python-java/aspose.slides/placeholdertype/#Object). В PowerPoint он служит запускателем для нескольких типов содержимого, включая диаграммы, таблицы, схемы, изображения и медиа. После заполнения проверьте фактический тип фигуры, чтобы узнать, что она содержит. Специализированные макеты также могут раскрывать типы [PlaceholderType.Chart](https://reference.aspose.com/slides/ru/python-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/ru/python-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/ru/python-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/ru/python-java/aspose.slides/placeholdertype/#Media) или [PlaceholderType.Diagram](https://reference.aspose.com/slides/ru/python-java/aspose.slides/placeholdertype/#Diagram).

Aspose.Slides не преобразует пустой заполнитель [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/) в [Chart](https://reference.aspose.com/slides/ru/python-java/aspose.slides/chart/) простым изменением [Placeholder.getType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/placeholder/#getType); тип нельзя изменить через API. Чтобы программно заполнить пустую диаграмму или область содержимого, добавьте требуемый объект в координаты заполнителя, а затем удалите пустой заполнитель. Следующий пример делает это для диаграммы:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PlaceholderType, ChartType, SaveFormat

presentation = Presentation("content-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    target_placeholder = None

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Chart, PlaceholderType.Object):
            target_placeholder = shape
            break

    if target_placeholder is None:
        print("The first slide does not contain a chart or content placeholder.")
    else:
        chart = slide.getShapes().addChart(ChartType.ClusteredColumn, target_placeholder.getX(), target_placeholder.getY(), target_placeholder.getWidth(), target_placeholder.getHeight())
        chart.setTitle(True)
        chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue")
        slide.getShapes().remove(target_placeholder)
        presentation.save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Добавленная диаграмма — обычная локальная диаграмма. Она занимает область заполнителя, но не наследует свойства от заполнителя макета. Используйте специальные статьи по управлению диаграммами [chart management articles](/slides/ru/python-java/powerpoint-charts/), когда необходимо заменить её категории, серии или данные рабочей книги.

## **Полный пример: обновление текста или изображения**

Следующий сквозной пример открывает шаблон, ищет на первом слайде заполнитель заголовка или изображения, проверяет типы заполнителя и фигуры, обновляет соответствующее содержимое и сохраняет результат. Пример сознательно избегает предположения о индексе фигуры и обращения к каждому заполнителю как к одному типу:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PictureFrame, PlaceholderType, ShapeType, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    updated = False

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle) and isinstance(shape, AutoShape):
            shape.getTextFrame().setText("Quarterly Business Review")
            updated = True
            break

        if placeholder_type == PlaceholderType.Picture:
            image_bytes = Path("replacement.png").read_bytes()
            java_image_bytes = jpype.JArray(jpype.JByte)(image_bytes)
            image = presentation.getImages().addImage(java_image_bytes)

            if isinstance(shape, PictureFrame):
                shape.getPictureFormat().getPicture().setImage(image)
            else:
                slide.getShapes().addPictureFrame(ShapeType.Rectangle, shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), image)
                slide.getShapes().remove(shape)

            updated = True
            break

    if updated:
        presentation.save("placeholder-content-updated.pptx", SaveFormat.Pptx)
    else:
        print("No supported title or picture placeholder was found on the first slide.")
finally:
    presentation.dispose()
```

## **FAQ**

**Что такое базовый заполнитель?**

Базовый заполнитель — это соответствующая фигура на макете или шаблоне, от которой наследуется другой заполнитель. Используйте [Shape.getBasePlaceholder](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getBasePlaceholder), чтобы получить его. Обычная локальная фигура возвращает `None`, потому что она не является частью иерархии заполнителей.

**Могу ли я изменить все заголовки слайдов, отредактировав заполнитель макета?**

Вы можете изменить наследуемое форматирование или текст подсказки через макет, но фактическое содержимое заголовков хранится на обычных слайдах. Чтобы заменить реальный текст заголовка во всей презентации, пройдитесь по слайдам и обновите каждый заполнитель заголовка.

**Как управлять заполнителями даты, номера слайда, заголовка и нижнего колонтитула?**

Используйте менеджеры заголовков и нижних колонтитулов в соответствующей области: слайд, макет, шаблон, заметки или раздаточный материал. Смотрите [Manage Presentation Header and Footer](/slides/ru/python-java/presentation-header-and-footer/) для полных примеров.