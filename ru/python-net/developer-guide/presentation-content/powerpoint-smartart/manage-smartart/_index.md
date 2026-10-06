---
title: Управление SmartArt в презентациях PowerPoint с использованием Python
linktitle: Управление SmartArt
type: docs
weight: 10
url: /ru/python-net/manage-smartart/
keywords:
- SmartArt
- Текст SmartArt
- Тип макета
- Скрытое свойство
- Организационная диаграмма
- Организационная диаграмма с изображением
- PowerPoint
- Презентация
- Python
- Aspose.Slides
description: "Узнайте, как создавать и редактировать SmartArt в PowerPoint с помощью Aspose.Slides for Python via .NET, используя понятные примеры кода, ускоряющие дизайн слайдов и автоматизацию."
---
## **Обзор**

SmartArt — это диаграмма PowerPoint, состоящая из узлов, форм узлов и макета. С помощью Aspose.Slides for Python via .NET вы можете создавать SmartArt, читать текст из его узлов, менять его макет, просматривать скрытые узлы, настраивать макеты организационных диаграмм и создавать организационные диаграммы с изображениями.

## **Получить текст из объекта SmartArt**

Узел SmartArt может содержать одну или несколько форм. Чтобы прочитать текст из форм узла, пройдите по [SmartArt.all_nodes](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/all_nodes/), затем прочитайте [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), возвращаемый [SmartArtShape.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartshape/text_frame/).

Для примера требуется презентация как минимум с одним слайдом и объектом SmartArt в качестве первой формы на этом слайде. Он выводит каждый доступный текстовый фрейм в консоль.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, smartart.SmartArt):
        for node in shape.all_nodes:
            for node_shape in node.shapes:
                if node_shape.text_frame is not None:
                    print(node_shape.text_frame.text)
```
## **Изменить тип макета объекта SmartArt**

Макет SmartArt управляет расположением и соединением узлов. В следующем примере создаётся объект SmartArt с типом [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `BASIC_BLOCK_LIST`, затем он меняется на значение `BASIC_PROCESS` и презентация сохраняется. Позиция и размер, передаваемые в [ShapeCollection.add_smart_art](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_smart_art/), измеряются в пунктах. Установите [SmartArt.layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/layout/), чтобы изменить макет.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    smart_art.layout = smartart.SmartArtLayoutType.BASIC_PROCESS

    presentation.save("ChangeSmartArtLayout.pptx", slides.export.SaveFormat.PPTX)
```
## **Проверить, скрыт ли узел SmartArt**

[SmartArtNode.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/is_hidden/) указывает, скрыт ли узел в модели данных SmartArt. Скрытые узлы могут присутствовать в структуре, даже если выбранный макет не отображает их как видимые элементы диаграммы.

В следующем примере добавляется узел к объекту SmartArt, использующему тип [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `RADIAL_CYCLE`, и проверяется состояние скрытости добавленного узла. Если узел скрыт, выводится сообщение, после чего диаграмма сохраняется.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.RADIAL_CYCLE)
    node = smart_art.all_nodes.add_node()
    is_hidden = node.is_hidden

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty.pptx", slides.export.SaveFormat.PPTX)
```
## **Получить или задать макет организационной диаграммы**

Для диаграмм SmartArt, использующих макет организационной диаграммы, [SmartArtNode.organization_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/organization_chart_layout/) определяет, как дочерние узлы располагаются под родительским узлом. Например, вы можете установить расположение дочерних узлов слева, справа или с обеих сторон в зависимости от выбранного [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/).

В следующем примере создаётся организационная диаграмма и задаётся макет для первого узла со значением [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/organizationchartlayouttype/) `LEFT_HANGING`. Индекс `0` выбирает первый узел верхнего уровня; его дочерние узлы используют выбранную схему размещения. Затем изменённая презентация сохраняется.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(10, 10, 400, 300, smartart.SmartArtLayoutType.ORGANIZATION_CHART)
    root_node = smart_art.nodes[0]
    root_node.organization_chart_layout = smartart.OrganizationChartLayoutType.LEFT_HANGING

    presentation.save("OrganizationChartLayout.pptx", slides.export.SaveFormat.PPTX)
```
## **Создать организационную диаграмму с изображениями**

Организационная диаграмма с изображениями — это макет SmartArt, предназначенный для иерархических диаграмм с заполнителями изображений. При добавлении объекта SmartArt на слайд используйте тип [SmartArtLayoutType](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartlayouttype/) `PICTURE_ORGANIZATION_CHART`. Этот пример сохраняет диаграмму с заполнителями изображений; он не заполняет заполнители изображениями.

```python
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)

    presentation.save("PictureOrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```
## **Преобразовать устаревшие диаграммы в группы фигур**

При модернизации существующей презентации может потребоваться обновить организационную диаграмму, изначально созданную в PowerPoint 97–2003. Aspose.Slides представляет такие устаревшие диаграммы как объекты [LegacyDiagram](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/). Используйте [LegacyDiagram.convert_to_group_shape](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/convert_to_group_shape/), чтобы преобразовать диаграмму в группу фигур, позволяя редактировать отдельные визуальные элементы. Смотрите [LegacyDiagram API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/legacydiagram/) для подробностей.

Преобразование добавляет новую группу в коллекцию фигур без удаления исходной диаграммы. После успешного преобразования удалите оригинал с помощью [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/), чтобы избежать дублирования содержимого. Сначала соберите устаревшие диаграммы в список, а затем преобразуйте их, чтобы добавление и удаление фигур не нарушало итерацию.

В следующем примере открывается презентация, обходятся все слайды, диаграммы преобразуются в группы фигур, и обновлённая презентация сохраняется в формате PPTX.

```python
import aspose.slides as slides

with slides.Presentation("legacy-diagrams.ppt") as presentation:
    for slide in presentation.slides:
        legacy_diagrams = [shape for shape in slide.shapes if isinstance(shape, slides.LegacyDiagram)]
        for legacy_diagram in legacy_diagrams:
            group_shape = legacy_diagram.convert_to_group_shape()

            if group_shape is not None:
                slide.shapes.remove(legacy_diagram)

    presentation.save("modernized.pptx", slides.export.SaveFormat.PPTX)
```
Сохранённая презентация содержит редактируемые группы фигур вместо преобразованных устаревших диаграмм, без оставшихся оригинальных диаграмм. Откройте файл PPTX в PowerPoint, чтобы редактировать отдельные элементы внутри каждой группы, такие как текст, заливка или позиция.

## **Вопросы и ответы**

**Поддерживает ли SmartArt зеркальное отображение или обратное направление для RTL‑языков?**  
Да. Свойство [SmartArt.is_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/is_reversed/) переключает направление диаграммы с слева направо на справа налево и обратно, если выбранный макет SmartArt поддерживает обратное направление.

**Как скопировать SmartArt на тот же слайд или в другую презентацию, сохранив форматирование?**  
Вы можете [clone the SmartArt shape](/slides/ru/python-net/shape-manipulations/) с помощью [ShapeCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_clone/) или [clone the whole slide](/slides/ru/python-net/clone-slides/), содержащий SmartArt. Оба подхода сохраняют размер, позицию и форматирование.

**Как отрисовать SmartArt в растровое изображение для предварительного просмотра или веб‑экспорта?**  
[Render the slide](/slides/ru/python-net/convert-powerpoint-to-png/) или всю презентацию в PNG или JPEG. SmartArt отрисовывается как часть слайда.

**Как найти определённый объект SmartArt на слайде, если их несколько?**  
Установите отличительное значение в [Shape.alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/) или [Shape.name](https://reference.aspose.com/slides/python-net/aspose.slides/shape/name/) у формы SmartArt, выполните поиск этого значения в [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/), затем проверьте, что найденная форма является [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/).