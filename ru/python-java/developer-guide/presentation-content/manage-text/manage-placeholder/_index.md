---
title: Управление плейсхолдерами презентации в Python
linktitle: Управление плейсхолдерами
type: docs
weight: 10
url: /ru/python-java/manage-placeholder/
keywords:
- плейсхолдер
- текстовый плейсхолдер
- плейсхолдер изображения
- плейсхолдер диаграммы
- плейсхолдер контента
- подсказочный текст
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Узнайте, как просматривать и редактировать текстовые, графические, диаграммные и контентные плейсхолдеры, а также понять наследование плейсхолдеров с помощью Aspose.Slides для Python через Java."
---
## **Обзор**

Плейсхолдер — это фигура, резервирующая позицию для определённого типа контента в шаблоне презентации. Распространённые примеры — заголовок, основной текст, изображение, диаграмма и универсальные плейсхолдеры контента. В отличие от обычной фигуры, плейсхолдер может наследовать свою позицию, размер, форматирование и другие параметры от слайда‑макета или слайда‑шаблона.

Aspose.Slides предоставляет информацию о плейсхолдерах через метод [Shape.getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder). Метод возвращает объект [Placeholder](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/) или `None` для обычной фигуры. Используйте [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType), чтобы определить, какой тип контента предполагается в плейсхолдере.

Тип фигуры всё равно важен после того, как известен тип плейсхолдера:

- Пустой текстовый, графический, диаграммный или контентный плейсхолдер обычно представляется [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/).
- Заполненный графический плейсхолдер может быть представлен [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/).
- Заполненный диаграммный плейсхолдер может быть представлен [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/).
- Контентный плейсхолдер может содержать несколько видов контента. Проверяйте одновременно [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) и тип фигуры во время выполнения, а не предполагая, что каждый плейсхолдер — это [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) описывает роль плейсхолдера; он не гарантирует тип фигуры во время выполнения. Всегда проверяйте тип перед обращением к членам, специфичным для текста, изображения, диаграммы, таблицы или медиа.
{{% /alert %}}

## **Понимание наследования плейсхолдеров**

Плейсхолдеры образуют иерархию:

1. Слайд‑шаблон определяет переиспользуемые стили и, в некоторых случаях, плейсхолдеры уровня шаблона.
2. Слайд‑макет определяет расположение, используемое одним или несколькими обычными слайдами, и может наследоваться от шаблона.
3. Обычный слайд содержит плейсхолдеры данного слайда и может наследоваться от своего макета.

Вызовите [Shape.getBasePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getBasePlaceholder), чтобы перейти на один уровень выше в этой иерархии. Плейсхолдер слайда обычно возвращает свой плейсхолдер макета; плейсхолдер макета может вернуть свой плейсхолдер шаблона. Метод возвращает `None`, если у фигуры нет базового плейсхолдера.

Следующий пример перечисляет плейсхолдеры на первом слайде и выводит их базовые плейсхолдеры:

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

Редактирование плейсхолдера на обычном слайде создаёт или изменяет локальное переопределение для этого слайда. Редактирование соответствующего макета или шаблона может повлиять на все слайды, которые всё ещё наследуют эту настройку. Обычная локальная фигура не имеет базового плейсхолдера и не начинает наследоваться только потому, что занимает те же координаты.

## **Удаление статуса плейсхолдера**

При адаптации шаблона используйте [Shape.removePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#removePlaceholder), чтобы сохранить существующий объект как обычную фигуру. Его метод [getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder) возвращает `None`, но фигура остаётся в коллекции слайда. В отличие от этого, [ShapeCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#remove) удаляет фигуру из этой коллекции.

Следующий пример требует файл `template.pptx` с по крайней мере одним слайдом и непустым текстовым плейсхолдером на первом слайде. Используйте плейсхолдер с форматированием, унаследованным от его макета или шаблона, чтобы увидеть эффект удаления этой связи. Пример проверяет, что та же фигура остаётся, снова вызывает метод для теперь уже обычной фигуры и сохраняет результат.

{{% alert color="warning" title="Warning" %}}
Удаление статуса плейсхолдера не сохраняет автоматически унаследованные параметры отображения. В примере ниже эти параметры намеренно оставлены без изменений, поэтому результат может выглядеть иначе. Фигура, чья позиция и размер полностью унаследованы, может после вызова иметь координаты и размеры, равные нулю, и стать невидимой, хотя останется в коллекции.
{{% /alert %}}

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    found = False

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if not isinstance(shape, AutoShape):
            continue

        text_frame = shape.getTextFrame()
        if shape.getPlaceholder() is None or text_frame is None:
            continue
        text = text_frame.getText()
        if text is None or len(text) == 0:
            continue

        shape_count = slide.getShapes().size()
        shape.removePlaceholder()

        print(f"Placeholder removed: {shape.getPlaceholder() is None}")
        print(f"Same shape retained: {slide.getShapes().get_Item(index) == shape}")
        print(f"Shape count unchanged: {slide.getShapes().size() == shape_count}")

        # Вызов метода для обычной фигуры не оказывает влияния.
        shape.removePlaceholder()
        found = True
        break

    if found:
        presentation.save("placeholder-status-removed.pptx", SaveFormat.Pptx)
    else:
        print("No nonempty text placeholder was found on the first slide.")
finally:
    presentation.dispose()
```

Для соответствующего плейсхолдера все три проверки выводят `True`. Текст сохраняется, но унаследованные позиция, размер, поворот, шрифт, выравнивание абзаца, отступы текстового кадра, вертикальное привязывание, параметры заливки и линий могут измениться после удаления связи. Например, унаследованное форматирование заголовка может вернуться к обычному текстовому форматированию. См. [Slide Layout](/slides/ru/python-java/slide-layout/) для подробностей о макетах.

Чтобы сохранить желаемый внешний вид, зафиксируйте разрешённые позицию, размер и поворот до вызова и скопируйте необходимые эффективные значения форматирования в отдельные переменные. Получите эти значения через [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective), [ParagraphFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getEffective), [TextFrameFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getEffective), [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective) и [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective). Не полагайтесь только на объекты эффективного форматирования, так как их значения могут измениться после удаления связи. Явно применяйте зафиксированные значения к обычной фигуре позже, включая семейство шрифта, размер, стиль, цвет, параметры абзаца, настройки текстового кадра, заливку и линию, используемые в вашем шаблоне.

Унаследованную геометрию фигуры также может потребоваться задать явно через [GeometryShape.setShapeType](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setShapeType). Для прямоугольного текстового плейсхолдера это означает присвоение [ShapeType.Rectangle](https://reference.aspose.com/slides/python-java/aspose.slides/shapetype/#Rectangle); восстановление только заливки и линии может не восстановить видимый прямоугольник. Шаблоны с дополнительными эффектами или более сложным форматированием требуют обработки и этих параметров.

## **Изменение текста в плейсхолдере**

Заголовок, центрированный заголовок, подзаголовок, основной текст и текстовые плейсхолдеры обычно поддерживают текст. Проверяйте наличие [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) перед использованием его метода [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#getTextFrame).

Этот пример обновляет первый заголовочный плейсхолдер на первом слайде и сохраняет результат:

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

Такой подход избегает обработки графических, диаграммных, табличных или медиа‑плейсхолдеров как [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/). Он также идентифицирует плейсхолдер по назначению, а не полагается на хрупкий индекс фигуры.

## **Установка подсказочного текста в макете**

Подсказочный текст — это инструктивное сообщение, отображаемое в пустом плейсхолдере во время разработки, например *Click to add title*. Устанавливайте собственный подсказочный текст в плейсхолдере макета, а не пробуйте получить его через обычную коллекцию фигур слайда. Доступ к макету осуществляется через [Slide.getLayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getLayoutSlide) и перебор коллекции, возвращаемой [BaseSlide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes).

Следующий пример изменяет подсказки заголовка и подзаголовка в макете, используемом первым слайдом:

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

Подсказочный текст — это не обычный контент слайда. Он предназначен для пустых плейсхолдеров в редакторах, таких как PowerPoint. После того как пользователь или программа вставит реальный контент, подсказка перестаёт отображаться. Изменение подсказки также не заменяет существующий текст на слайдах, использующих данный макет.

## **Обновление графического плейсхолдера**

Есть два сценария:

- Если графический плейсхолдер уже заполнен и представлен [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/), замените изображение через [PictureFillFormat.getPicture](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#getPicture) и [Picture.setImage](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#setImage).
- Если это всё ещё пустой плейсхолдер, добавьте графический кадр в координаты плейсхолдера с помощью [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addPictureFrame) и удалите пустой плейсхолдер.

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

Замена, созданная для пустого плейсхолдера, — это локальный графический кадр, а не новый плейсхолдер, потому что [Shape.getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder) не предоставляет сеттер. Он сохраняет зарезервированную позицию, но более не наследует поведение, специфичное для плейсхолдера. Если сохранение связи плейсхолдера критично, подготовьте и заполните плейсхолдер в PowerPoint заранее, а затем обновите полученный [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) через Aspose.Slides.

Для прозрачности изображения, обрезки и других эффектов, специфичных для графики, см. [Manage Picture Frames](/slides/ru/python-java/picture-frame/). Эти операции относятся к графическому кадру или заполнению изображения, а не к метаданным плейсхолдера.

## **Работа с диаграммами и контентными плейсхолдерами**

Заполненный диаграммный плейсхолдер может быть представлен [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/). Этот пример находит такую диаграмму по типу плейсхолдера и типу фигуры во время выполнения, меняет её заголовок и сохраняет файл:

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

Общий контентный плейсхолдер обычно имеет [PlaceholderType.Object](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Object). В PowerPoint он служит запускателем для нескольких типов контента, включая диаграммы, таблицы, схемы, изображения и медиа. После заполнения проанализируйте фактический тип фигуры, чтобы узнать, что она содержит. Специализированные макеты могут также раскрывать [PlaceholderType.Chart](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Media) или [PlaceholderType.Diagram](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Diagram).

Aspose.Slides не преобразует пустой [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) плейсхолдер в [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) лишь изменением [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType); тип нельзя изменить через API. Чтобы программно заполнить пустую диаграмму или область контента, добавьте требуемый объект в координаты плейсхолдера, а затем удалите пустой плейсхолдер. Следующий пример делает это для диаграммы:

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

Добавленная диаграмма — обычная локальная диаграмма. Она занимает область плейсхолдера, но не наследует свойства от макетного плейсхолдера. Используйте специализированные [chart management articles](/slides/ru/python-java/powerpoint-charts/) при необходимости заменить категории, серии или данные книги.

## **Полный пример: обновление текста или изображения**

Следующий сквозной пример открывает шаблон, ищет на первом слайде либо заголовочный, либо графический плейсхолдер, проверяет типы плейсхолдера и фигуры, обновляет соответствующий контент и сохраняет результат. Пример намеренно избегает предположений о индексе фигуры или о том, что каждый плейсхолдер имеет одинаковый тип.

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

**Что такое базовый плейсхолдер?**

Базовый плейсхолдер — это соответствующая фигура на макете или шаблоне, от которой наследуется другой плейсхолдер. Используйте [Shape.getBasePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getBasePlaceholder), чтобы получить его. Обычная локальная фигура возвращает `None`, потому что она не является частью иерархии плейсхолдеров.

**Могу ли я изменить все заголовки слайдов, редактируя плейсхолдер макета?**

Вы можете изменить унаследованное форматирование или подсказочный текст через макет, но существующее содержимое заголовков хранится на обычных слайдах. Чтобы заменить реальный текст заголовков во всей презентации, пройдите по всем слайдам и обновите каждый заголовочный плейсхолдер.

**Как управлять плейсхолдерами даты, номера слайда, верхнего и нижнего колонтитулов?**

Используйте менеджеры верхних и нижних колонтитулов в соответствующей области — слайде, макете, шаблоне, нотах или раздаточных листах. См. [Manage Presentation Header and Footer](/slides/ru/python-java/presentation-header-and-footer/) для полных примеров.