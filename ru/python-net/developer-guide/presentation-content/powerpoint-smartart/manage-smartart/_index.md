---
title: Управление SmartArt в презентациях PowerPoint с использованием Python
linktitle: Управление SmartArt
type: docs
weight: 10
url: /ru/python-net/manage-smartart/
keywords:
- SmartArt
- текст из SmartArt
- тип макета
- свойство hidden
- организационная диаграмма
- организационная диаграмма с изображением
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Научитесь создавать и редактировать SmartArt в PowerPoint с помощью Aspose.Slides for Python via .NET, используя понятные примеры кода, которые ускоряют разработку слайдов и автоматизацию."
---
## **Обзор**

SmartArt — это диаграмма PowerPoint, состоящая из узлов, форм узлов и макета. С помощью Aspose.Slides for Python via .NET вы можете создавать SmartArt, считывать текст из его узлов, менять макет, проверять скрытые узлы, настраивать макеты организационных диаграмм и создавать диаграммы организации с изображениями.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, smartart.SmartArt):
        smart_art = shape

        for smart_art_node in smart_art.all_nodes:
            for smart_art_shape in smart_art_node.shapes:
                if smart_art_shape.text_frame is not None:
                    print(smart_art_shape.text_frame.text)
```
## **Получить текст из объекта SmartArt**

Узел SmartArt может содержать одну или несколько форм. Чтобы прочитать видимый текст, пройдитесь по [SmartArt.all_nodes](https://reference.aspose.com/slides/ru/python-net/aspose.slides.smartart/smartart/all_nodes/), затем прочитайте [TextFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/), возвращаемый [SmartArtShape.text_frame](https://reference.aspose.com/slides/ru/python-net/aspose.slides.smartart/smartartshape/text_frame/).

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)

    smart_art.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    presentation.save("ChangeSmartArtLayout_out.pptx", slides.export.SaveFormat.PPTX)
```
## **Изменить тип макета объекта SmartArt**

Макет SmartArt определяет, как узлы размещаются и соединяются. В следующем примере создаётся объект SmartArt с типом макета [SmartArtLayoutType](https://reference.aspose.com/slides/ru/python-net/aspose.slides.smartart/smartartlayouttype/) `BASIC_BLOCK_LIST`, затем он меняется на значение `BASIC_PROCESS` и сохраняется презентация.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)

    smart_art_node = smart_art.all_nodes.add_node()
    is_hidden = smart_art_node.is_hidden

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", slides.export.SaveFormat.PPTX)
```
## **Проверить, скрыт ли узел SmartArt**

[SmartArtNode.is_hidden](https://reference.aspose.com/slides/ru/python-net/aspose.slides.smartart/smartartnode/is_hidden/) указывает, скрыт ли узел в модели данных SmartArt. Скрытые узлы могут существовать в структуре, даже если выбранный макет не отображает их как видимые элементы диаграммы.

В следующем примере добавляется узел к объекту SmartArt, использующему тип макета [SmartArtLayoutType](https://reference.aspose.com/slides/ru/python-net/aspose.slides.smartart/smartartlayouttype/) `RADIAL_CYCLE`, и проверяется состояние скрытости узла.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)

    root_node = smart_art.nodes[0]
    root_node.organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    presentation.save("OrganizationChartLayout_out.pptx", slides.export.SaveFormat.PPTX)
```
## **Получить или установить макет организационной диаграммы**

Для диаграмм SmartArt, использующих макет организационной диаграммы, [SmartArtNode.organization_chart_layout](https://reference.aspose.com/slides/ru/python-net/aspose.slides.smartart/smartartnode/organization_chart_layout/) определяет, как дочерние узлы располагаются под родительским узлом. Например, вы можете установить расположение дочерних узлов слева, справа или с обеих сторон в зависимости от выбранного [OrganizationChartLayoutType](https://reference.aspose.com/slides/ru/python-net/aspose.slides.smartart/organizationchartlayouttype/).

В следующем примере создаётся организационная диаграмма и для первого узла устанавливается макет [OrganizationChartLayoutType](https://reference.aspose.com/slides/ru/python-net/aspose.slides.smartart/organizationchartlayouttype/) `LEFT_HANGING`.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    smart_art = presentation.slides[0].shapes.add_smart_art(
        0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)

    presentation.save("PictureOrganizationChart_out.pptx", slides.export.SaveFormat.PPTX)
```
## **Создать организационную диаграмму с изображением**

Организационная диаграмма с изображением — это макет SmartArt, предназначенный для иерархических диаграмм, включающих места для изображений. При добавлении объекта SmartArt на слайд используйте тип макета [SmartArtLayoutType](https://reference.aspose.com/slides/ru/python-net/aspose.slides.smartart/smartartlayouttype/) `PICTURE_ORGANIZATION_CHART`.

## **FAQ**

**Поддерживает ли SmartArt зеркальное отображение или обратный порядок для RTL‑языков?**

Да. Свойство [SmartArt.is_reversed](https://reference.aspose.com/slides/ru/python-net/aspose.slides.smartart/smartart/is_reversed/) переключает направление диаграммы слева направо на справа налево и обратно, если выбранный макет SmartArt поддерживает обратный порядок.

**Как скопировать SmartArt на тот же слайд или в другую презентацию, сохранив форматирование?**

Вы можете [клонировать форму SmartArt](/slides/ru/python-net/shape-manipulations/) с помощью [ShapeCollection.add_clone](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shapecollection/add_clone/) либо [клонировать весь слайд](/slides/ru/python-net/clone-slides/), содержащий SmartArt. Оба подхода сохраняют размер, положение и форматирование.

**Как отобразить SmartArt в растре изображения для предварительного просмотра или экспорта в веб?**

[Отрендерите слайд](/slides/ru/python-net/convert-powerpoint-to-png/) или всю презентацию в PNG или JPEG. SmartArt отрисовывается как часть слайда.

**Как найти конкретный объект SmartArt на слайде, если их несколько?**

Установите отличительное значение [Shape.alternative_text](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/alternative_text/) или [Shape.name](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/name/) для формы SmartArt, выполните поиск этого значения в [Slide.shapes](https://reference.aspose.com/slides/ru/python-net/aspose.slides/slide/shapes/), затем убедитесь, что найденная форма является [SmartArt](https://reference.aspose.com/slides/ru/python-net/aspose.slides.smartart/smartart/).