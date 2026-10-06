---
title: Управление SmartArt в презентациях PowerPoint с помощью Python
linktitle: Управление SmartArt
type: docs
weight: 10
url: /ru/python-java/manage-smartart/
keywords:
- SmartArt
- Текст SmartArt
- тип макета
- скрытое свойство
- организационная диаграмма
- организационная диаграмма с изображениями
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как создавать и редактировать SmartArt в PowerPoint с помощью Aspose.Slides для Python через Java, используя понятные примеры кода, ускоряющие разработку слайдов и автоматизацию."
---
## **Обзор**

SmartArt — это диаграмма PowerPoint, состоящая из узлов, форм узлов и макета. С помощью Aspose.Slides for Python via Java вы можете создавать SmartArt, считывать текст из его узлов, изменять его макет, проверять скрытые узлы, настраивать макеты организационных диаграмм и создавать организационные диаграммы с изображениями.

## **Получить текст из объекта SmartArt**

Узел SmartArt может содержать одну или несколько форм. Чтобы прочитать текст из форм узла, пройдите итерацию по [SmartArt.getAllNodes](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#getAllNodes), затем прочитайте [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/), возвращаемый [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/smartartshape/#getTextFrame).

Для примера требуется презентация, содержащая как минимум один слайд, и объект SmartArt в качестве первой формы на этом слайде. Пример выводит каждый найденный текстовый кадр в консоль.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, SmartArt):
        smart_art = shape
        for node in smart_art.getAllNodes():
            for node_shape in node.getShapes():
                if node_shape.getTextFrame() is not None:
                    print(node_shape.getTextFrame().getText())
finally:
    presentation.dispose()
```

## **Изменить тип макета объекта SmartArt**

Макет SmartArt определяет, как узлы располагаются и соединяются. В следующем примере создаётся объект SmartArt с типом макета [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `BasicBlockList`, затем он меняется на значение `BasicProcess` и сохраняется презентация. Позиция и размер, передаваемые в [ShapeCollection.addSmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSmartArt), измеряются в пунктах. Для изменения макета используйте [SmartArt.setLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#setLayout).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList)
    smart_art.setLayout(SmartArtLayoutType.BasicProcess)

    presentation.save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Проверить, скрыт ли узел SmartArt**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#isHidden) указывает, скрыт ли узел в модели данных SmartArt. Скрытые узлы могут присутствовать в структуре, даже если выбранный макет не отображает их как видимые элементы диаграммы.

В следующем примере к объекту SmartArt, использующему тип макета [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `RadialCycle`, добавляется узел, после чего проверяется его состояние скрытости. При обнаружении скрытого узла выводится сообщение, а диаграмма сохраняется.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle)
    node = smart_art.getAllNodes().addNode()
    is_hidden = node.isHidden()

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Получить или задать макет организационной диаграммы**

Для диаграмм SmartArt, использующих макет организационной диаграммы, методы [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#getOrganizationChartLayout) и [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#setOrganizationChartLayout) определяют, как дочерние узлы располагаются под родительским узлом. Например, можно задать расположение дочерних узлов слева, справа или с обеих сторон, в зависимости от выбранного [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/organizationchartlayouttype/).

В следующем примере создаётся организационная диаграмма, и для первого узла задаётся макет [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`. Индекс `0` выбирает первый узел верхнего уровня; его дочерние узлы используют выбранную схему расположения. Затем изменённая презентация сохраняется.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OrganizationChartLayoutType, Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart)
    root_node = smart_art.getNodes().get_Item(0)
    root_node.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging)

    presentation.save("OrganizationChartLayout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Создать организационную диаграмму с изображениями**

Организационная диаграмма с изображениями — это макет SmartArt, предназначенный для иерархических схем, включающих места для изображений. При добавлении объекта SmartArt на слайд используйте значение [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart`. В этом примере сохраняется диаграмма с заполнителями изображений; сами изображения в заполнители не вставляются.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart)

    presentation.save("PictureOrganizationChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Преобразовать устаревшие диаграммы в группы форм**

При модернизации существующей презентации может потребоваться обновить организационную диаграмму, созданную в PowerPoint 97–2003. Aspose.Slides представляет такие устаревшие диаграммы объектами [LegacyDiagram](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/). Для преобразования диаграммы в группу форм используйте [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/#convertToGroupShape), чтобы можно было редактировать отдельные визуальные элементы. Смотрите [LegacyDiagram API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/) для подробностей.

Преобразование добавляет новую группу в коллекцию форм, не удаляя оригинальную диаграмму. После успешного преобразования удалите оригинал с помощью [ShapeCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#remove), чтобы избежать дублирования содержимого. Сначала соберите устаревшие диаграммы в список, а затем преобразуйте их, чтобы добавление и удаление форм не нарушало процесс итерации.

В следующем примере открывается презентация, последовательно просматриваются все слайды, диаграммы преобразуются в группы форм, после чего обновлённая презентация сохраняется в формате PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LegacyDiagram, Presentation, SaveFormat

presentation = Presentation("legacy-diagrams.ppt")
try:
    for slide in presentation.getSlides():
        legacy_diagrams = []
        for shape in slide.getShapes():
            if isinstance(shape, LegacyDiagram):
                legacy_diagrams.append(shape)

        for legacy_diagram in legacy_diagrams:
            group_shape = legacy_diagram.convertToGroupShape()

            if group_shape is not None:
                slide.getShapes().remove(legacy_diagram)

    presentation.save("modernized.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Сохранённая презентация содержит редактируемые группы форм вместо преобразованных устаревших диаграмм, без оставшихся оригиналов. Откройте файл PPTX в PowerPoint, чтобы редактировать отдельные элементы внутри каждой группы, такие как текст, заливка или позиция.

## **FAQ**

**Поддерживает ли SmartArt зеркальное отображение или обратный порядок для RTL-языков?**

Да. Метод [SmartArt.setReversed](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#setReversed) переключает направление диаграммы слева направо на справа налево и обратно, если выбранный макет SmartArt поддерживает обратный порядок.

**Как скопировать SmartArt на тот же слайд или в другую презентацию, сохранив форматирование?**

Вы можете [клонировать форму SmartArt](/slides/ru/python-java/shape-manipulations/) с помощью [ShapeCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addClone) или [клонировать весь слайд](/slides/ru/python-java/clone-slides/), содержащий SmartArt. Оба подхода сохраняют размер, позицию и форматирование.

**Как отобразить SmartArt как растровое изображение для предварительного просмотра или веб‑экспорта?**

[Отрендерите слайд](/slides/ru/python-java/convert-powerpoint-to-png/) или всю презентацию в PNG или JPEG. SmartArt будет отрисован как часть слайда.

**Как найти конкретный объект SmartArt на слайде, если их несколько?**

Используйте [Shape.setAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setAlternativeText) или [Shape.setName](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setName), чтобы назначить уникальный альтернативный текст или имя форме SmartArt, затем выполните поиск этого значения через [BaseSlide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes) и проверьте, является ли найденная форма объектом [SmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/).