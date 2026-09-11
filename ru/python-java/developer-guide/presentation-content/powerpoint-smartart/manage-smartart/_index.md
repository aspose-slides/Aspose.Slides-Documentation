---
title: Управление SmartArt в презентациях PowerPoint с использованием Python
linktitle: Управление SmartArt
type: docs
weight: 10
url: /ru/python-java/manage-smartart/
keywords:
- SmartArt
- Текст SmartArt
- Тип макета
- Скрытое свойство
- Организационная диаграмма
- Диаграмма организации с изображением
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как создавать и редактировать SmartArt в PowerPoint с помощью Aspose.Slides for Python via Java, используя понятные примеры кода, которые ускоряют разработку слайдов и автоматизацию."
---
## **Обзор**

SmartArt — это диаграмма PowerPoint, состоящая из узлов, форм узлов и макета. С помощью Aspose.Slides for Python via Java вы можете создавать SmartArt, читать текст из его узлов, изменять его макет, просматривать скрытые узлы, настраивать макеты организационных диаграмм и создавать диаграммы организации с изображениями.

## **Получить текст из объекта SmartArt**

Узел SmartArt может содержать одну или несколько форм. Чтобы прочитать видимый текст, пройдитесь по [SmartArt.getAllNodes](https://reference.aspose.com/slides/ru/python-java/aspose.slides/smartart/#getAllNodes), затем прочитайте [TextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/), возвращаемый [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/smartartshape/#getTextFrame).

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

Макет SmartArt определяет, как узлы располагаются и соединяются. В следующем примере создаётся объект SmartArt с типом [SmartArtLayoutType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/smartartlayouttype/) `BasicBlockList`, затем он меняется на значение `BasicProcess` и сохраняется презентация.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList)

    smart_art.setLayout(SmartArtLayoutType.BasicProcess)

    presentation.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Проверить, скрыт ли узел SmartArt**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/ru/python-java/aspose.slides/smartartnode/#isHidden) указывает, скрыт ли узел в модели данных SmartArt. Скрытые узлы могут присутствовать в структуре, даже если выбранный макет не отображает их как видимые элементы диаграммы.

В следующем примере добавляется узел к объекту SmartArt, использующему тип [SmartArtLayoutType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/smartartlayouttype/) `RadialCycle`, и проверяется состояние скрытости узла.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle)

    node = smart_art.getAllNodes().addNode()
    is_hidden = node.isHidden()

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Получить или установить макет организационной диаграммы**

Для диаграмм SmartArt, использующих макет организационной диаграммы, [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/ru/python-java/aspose.slides/smartartnode/#getOrganizationChartLayout) и [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/ru/python-java/aspose.slides/smartartnode/#setOrganizationChartLayout) определяют, как дочерние узлы располагаются под родительским узлом. Например, можно задать размещение дочерних узлов слева, справа или с обеих сторон в зависимости от выбранного [OrganizationChartLayoutType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/organizationchartlayouttype/).

В следующем примере создаётся организационная диаграмма и для первого узла задаётся макет [OrganizationChartLayoutType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OrganizationChartLayoutType, Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart)

    root_node = smart_art.getNodes().get_Item(0)
    root_node.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging)

    presentation.save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Создать организационную диаграмму с изображением**

Диаграмма организации с изображением — это макет SmartArt, предназначенный для иерархических диаграмм, включающих заполнители изображений. При добавлении объекта SmartArt на слайд используйте значение [SmartArtLayoutType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart)

    presentation.save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Поддерживает ли SmartArt зеркалирование или разворот для RTL‑языков?**

Да. Метод [SmartArt.setReversed](https://reference.aspose.com/slides/ru/python-java/aspose.slides/smartart/#setReversed) переключает направление диаграммы с слева направо на справа налево и обратно, если выбранный макет SmartArt поддерживает разворот.

**Как скопировать SmartArt на тот же слайд или в другую презентацию, сохраняя форматирование?**

Вы можете [clone the SmartArt shape](/slides/ru/python-java/shape-manipulations/) с помощью [ShapeCollection.addClone](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/#addClone) или [clone the whole slide](/slides/ru/python-java/clone-slides/) содержащий SmartArt. Оба подхода сохраняют размер, позицию и форматирование.

**Как отобразить SmartArt в растровое изображение для предварительного просмотра или веб‑экспорта?**

[Render the slide](/slides/ru/python-java/convert-powerpoint-to-png/) или всю презентацию в PNG или JPEG. SmartArt рендерится как часть слайда.

**Как найти конкретный объект SmartArt на слайде, если их несколько?**

Задайте отличительное значение [Shape.getAlternativeText](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getAlternativeText) или [Shape.getName](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getName) у формы SmartArt, выполните поиск этого значения в [BaseSlide.getShapes](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseslide/#getShapes) и затем проверьте, что найденная форма является [SmartArt](https://reference.aspose.com/slides/ru/python-java/aspose.slides/smartart/).