---
title: Управление узлом SmartArt
type: docs
weight: 30
url: /ru/python-net/manage-smartart-shape-node/
keywords: "Узел SmartArt, дочерний узел SmartArt, презентация PowerPoint, Python, Aspose.Slides для Python via .NET"
description: "Умный узел и дочерний узел в презентациях PowerPoint на Python"
---


## **Добавить узел SmartArt**
Aspose.Slides для Python via .NET предоставил самый простой API для управления формами SmartArt самым простым способом. Следующий пример кода поможет добавить узел и дочерний узел внутри формы SmartArt.

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и загрузите презентацию с формой SmartArt.
- Получите ссылку на первый слайд, используя его индекс.
- Пройдите через каждую форму на первом слайде.
- Проверьте, является ли форма типом SmartArt, и приведите выбранную форму к типу SmartArt, если это SmartArt.
- Добавьте новый узел в коллекцию узлов формы SmartArt и установите текст в TextFrame.
- Теперь добавьте дочерний узел в только что добавленный узел SmartArt и установите текст в TextFrame.
- Сохраните презентацию.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Загрузите нужную презентацию
with slides.Presentation(path + "AddNodes.pptx") as pres:
    # Пройдите через каждую форму на первом слайде
    for shape in pres.slides[0].shapes:

        # Проверьте, является ли форма типом SmartArt
        if type(shape) is art.SmartArt:
            # Добавление нового узла SmartArt
            node1 = shape.all_nodes.add_node()
            # Добавление текста
            node1.text_frame.text = "Тест"

            # Добавление нового дочернего узла в родительский узел. Он будет добавлен в конец коллекции
            new_node = node1.child_nodes.add_node()

            # Добавление текста
            new_node.text_frame.text = "Новый узел добавлен"

    # Сохранение презентации
    pres.save("AddSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Добавить узел SmartArt в заданной позиции**
В следующем примере кода мы объяснили, как добавить дочерние узлы, принадлежащие соответствующим узлам формы SmartArt, в определенной позиции.

- Создайте экземпляр класса `Presentation`.
- Получите ссылку на первый слайд, используя его индекс.
- Добавьте форму SmartArt типа StackedList в доступный слайд.
- Получите первый узел в добавленной форме SmartArt.
- Теперь добавьте дочерний узел для выбранного узла на позиции 2 и установите его текст.
- Сохраните презентацию.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Создание экземпляра презентации
with slides.Presentation() as pres:
    # Доступ к слайду презентации
    slide = pres.slides[0]

    # Добавьте SmartArt IShape
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)

    # Доступ к узлу SmartArt по индексу 0
    node = smart.all_nodes[0]

    # Добавление нового дочернего узла на позиции 2 в родительском узле
    chNode = node.child_nodes.add_node_by_position(2)

    # Добавьте текст
    chNode.text_frame.text = "Добавлен образец текста"

    # сохраните презентацию
    pres.save("AddSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```




## **Доступ к узлу SmartArt**
Следующий пример кода поможет получить доступ к узлам внутри формы SmartArt. Обратите внимание, что вы не можете изменить LayoutType SmartArt, так как он является только для чтения и устанавливается только при добавлении формы SmartArt.

- Создайте экземпляр класса `Presentation` и загрузите презентацию с формой SmartArt.

- Получите ссылку на первый слайд, используя его индекс.

- Пройдите через каждую форму на первом слайде.

- Проверьте, является ли форма типом SmartArt, и приведите выбранную форму к типу SmartArt, если это SmartArt.

- Пройдите через все узлы внутри формы SmartArt.

- Получите и отобразите информацию, такую как позиция узла SmartArt, уровень и текст.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Загрузите нужную презентацию
with slides.Presentation(path + "AccessSmartArt.pptx") as pres:
    # Пройдите через каждую форму на первом слайде
    for shape in pres.slides[0].shapes:
        # Проверьте, является ли форма типом SmartArt
        if type(shape) is art.SmartArt:
            # Пройдите через все узлы внутри SmartArt
            for i in range(len(shape.all_nodes)):
                # Получение узла SmartArt по индексу i
                node = shape.all_nodes[i]

                # Печать параметров узла SmartArt
                print("i = {0}, text = {1}, level = {2}, position = {3}".format(i, node.text_frame.text, node.level, node.position))
```



## **Доступ к дочернему узлу SmartArt**
Следующий пример кода поможет получить доступ к дочерним узлам, принадлежащим соответствующим узлам формы SmartArt.

- Создайте экземпляр класса PresentationEx и загрузите презентацию с формой SmartArt.
- Получите ссылку на первый слайд, используя его индекс.
- Пройдите через каждую форму на первом слайде.
- Проверьте, является ли форма типом SmartArt, и приведите выбранную форму к типу SmartArtEx, если это SmartArt.
- Пройдите через все узлы внутри формы SmartArt.
- Для каждого выбранного узла SmartArt пройдите через все дочерние узлы внутри конкретного узла.
- Получите и отобразите информацию, такую как позиция дочернего узла, уровень и текст.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Загрузите нужную презентацию
with slides.Presentation(path + "AccessChildNodes.pptx") as pres:
    # Пройдите через каждую форму на первом слайде
    for shape in pres.slides[0].shapes:
        # Проверьте, является ли форма типом SmartArt
        if type(shape) is art.SmartArt:
            # Пройдите через все узлы внутри SmartArt
            for node0 in shape.all_nodes:
                # Пройдите через дочерние узлы
                for j in range(len(node0.child_nodes)):
                    # Получение дочернего узла в узле SmartArt
                    node = node0.child_nodes[j]

                    # Печать параметров дочернего узла SmartArt
                    print("j = {0}, text = {1}, level = {2}, position = {3}".format(j, node.text_frame.text, node.level, node.position))

```



## **Доступ к дочернему узлу SmartArt в заданной позиции**
В этом примере мы научимся получать доступ к дочерним узлам в конкретной позиции, принадлежащим соответствующим узлам формы SmartArt.

- Создайте экземпляр класса `Presentation`.
- Получите ссылку на первый слайд, используя его индекс.
- Добавьте форму SmartArt типа StackedList.
- Доступ к добавленной форме SmartArt.
- Доступ к узлу по индексу 0 для доступа к форме SmartArt.
- Теперь получите доступ к дочернему узлу на позиции 1 для доступа к узлу SmartArt, используя метод GetNodeByPosition().
- Получите и отобразите информацию, такую как позиция дочернего узла, уровень и текст.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Создайте экземпляр презентации
with slides.Presentation() as pres:
    # Доступ к первому слайду
    slide = pres.slides[0]
    # Добавление формы SmartArt на первом слайде
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)
    # Доступ к узлу SmartArt по индексу 0
    node = smart.all_nodes[0]
    # Доступ к дочернему узлу на позиции 1 в родительском узле
    position = 1
    chNode = node.child_nodes[position] 
    # Печать параметров дочернего узла SmartArt
    print("j = {0}, text = {1}, level = {2}, position = {3}".format(position, chNode.text_frame.text, chNode.level, chNode.position))

```



## **Удалить узел SmartArt**
В этом примере мы научимся удалять узлы внутри формы SmartArt.

- Создайте экземпляр класса `Presentation` и загрузите презентацию с формой SmartArt.
- Получите ссылку на первый слайд, используя его индекс.
- Пройдите через каждую форму на первом слайде.
- Проверьте, является ли форма типом SmartArt, и приведите выбранную форму к типу SmartArt, если это SmartArt.
- Проверьте, есть ли у SmartArt более 0 узлов.
- Выберите узел SmartArt, который нужно удалить.
- Теперь удалите выбранный узел, используя метод RemoveNode() и сохраните презентацию.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Загрузите нужную презентацию
with slides.Presentation(path + "RemoveNode.pptx") as pres:
    # Пройдите через каждую форму на первом слайде
    for shape in pres.slides[0].shapes:
        # Проверьте, является ли форма типом SmartArt
        if type(shape) is art.SmartArt:
            # Приведение формы к типу SmartArtEx
            if len(shape.all_nodes) > 0:
                # Получение узла SmartArt по индексу 0
                node = shape.all_nodes[0]

                # Удаление выбранного узла
                shape.all_nodes.remove_node(node)

    # Сохранение презентации
    pres.save("RemoveSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Удалить узел SmartArt в заданной позиции**
В этом примере мы научимся удалять узлы внутри формы SmartArt в заданной позиции.

- Создайте экземпляр класса `Presentation` и загрузите презентацию с формой SmartArt.
- Получите ссылку на первый слайд, используя его индекс.
- Пройдите через каждую форму на первом слайде.
- Проверьте, является ли форма типом SmartArt, и приведите выбранную форму к типу SmartArt, если это SmartArt.
- Выберите узел формы SmartArt по индексу 0.
- Теперь проверьте, есть ли у выбранного узла SmartArt более 2 дочерних узлов.
- Теперь удалите узел на позиции 1, используя метод RemoveNodeByPosition().
- Сохраните презентацию.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Загрузите нужную презентацию
with slides.Presentation(path + "RemoveNodeSpecificPosition.pptx") as pres:             
    # Пройдите через каждую форму на первом слайде
    for shape in pres.slides[0].shapes:
        # Проверьте, является ли форма типом SmartArt
        if type(shape) is art.SmartArt:
            # Приведение формы к типу SmartArt
            if len(shape.all_nodes) > 0:
                # Получение узла SmartArt по индексу 0
                node = shape.all_nodes[0]
                if len(node.child_nodes) >= 2:
                    # Удаление дочернего узла на позиции 1
                    node.child_nodes.remove_node(1)

    # Сохранение презентации
    pres.save("RemoveSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Установить пользовательскую позицию для дочернего узла в SmartArt**
Теперь Aspose.Slides для Python via .NET поддерживает установку свойств X и Y для SmartArtShape. Код ниже показывает, как установить пользовательскую позицию, размер и поворот SmartArtShape. Обратите внимание, что добавление новых узлов вызывает перерасчет позиций и размеров всех узлов.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Загрузите нужную презентацию
with slides.Presentation(path + "AccessChildNodes.pptx") as pres: 
    smart = pres.slides[0].shapes.add_smart_art(20, 20, 600, 500, art.SmartArtLayoutType.ORGANIZATION_CHART)

    # Перемещение SmartArt в новую позицию
    node = smart.all_nodes[1]
    shape = node.shapes[1]
    shape.x += (shape.width * 2)
    shape.y -= (shape.height / 2)

    # Изменение ширины формы SmartArt
    node = smart.all_nodes[2]
    shape = node.shapes[1]
    shape.width += (shape.width / 2)

    # Изменение высоты формы SmartArt
    node = smart.all_nodes[3]
    shape = node.shapes[1]
    shape.height += (shape.height / 2)

    # Изменение поворота формы SmartArt
    node = smart.all_nodes[4]
    shape = node.shapes[1]
    shape.rotation = 90

    pres.save("SmartArt.pptx", slides.export.SaveFormat.PPTX)
```



## **Проверить узел-ассистент**
В следующем примере кода мы исследуем, как идентифицировать узлы-ассистенты в коллекции узлов SmartArt и изменять их.

- Создайте экземпляр класса PresentationEx и загрузите презентацию с формой SmartArt.
- Получите ссылку на второй слайд, используя его индекс.
- Пройдите через каждую форму на первом слайде.
- Проверьте, является ли форма типом SmartArt, и приведите выбранную форму к типу SmartArtEx, если это SmartArt.
- Пройдите через все узлы внутри формы SmartArt и проверьте, являются ли они узлами-ассистентами.
- Измените статус узла-ассистента на обычный узел.
- Сохраните презентацию.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Создание экземпляра презентации
with slides.Presentation(path + "AssistantNode.pptx") as pres: 
    # Пройдите через каждую форму на первом слайде
    for shape in pres.slides[0].shapes:
        # Проверьте, является ли форма типом SmartArt
        if type(shape) is art.SmartArt:
            # Пройдите через все узлы формы SmartArt
            for node in shape.all_nodes:
                tc = node.text_frame.text
                # Проверьте, является ли узел узлом-ассистентом
                if node.is_assistant:
                    # Установите узел-ассистент на false и сделайте его обычным узлом
                    node.is_assistant = False
    # Сохранение презентации
    pres.save("ChangeAssitantNode_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Установить формат заливки узла**
Aspose.Slides для Python via .NET позволяет добавлять пользовательские формы SmartArt и устанавливать их форматы заливки. Эта статья объясняет, как создать и получить доступ к формам SmartArt и установить их формат заливки с использованием Aspose.Slides для Python via .NET.

Пожалуйста, следуйте этим шагам:

- Создайте экземпляр класса `Presentation`.
- Получите ссылку на слайд, используя его индекс.
- Добавьте форму SmartArt, установив его LayoutType.
- Установите FillFormat для узлов формы SmartArt.
- Запишите измененную презентацию в файл PPTX.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation: 
    # Доступ к слайду
    slide = presentation.slides[0]

    # Добавление формы SmartArt и узлов
    chevron = slide.shapes.add_smart_art(10, 10, 800, 60, art.SmartArtLayoutType.CLOSED_CHEVRON_PROCESS)
    node = chevron.all_nodes.add_node()
    node.text_frame.text = "Некоторый текст"

    # Установка цвета заливки узла
    for item in node.shapes:
        item.fill_format.fill_type = slides.FillType.SOLID
        item.fill_format.solid_fill_color.color = draw.Color.red

    # Сохранение презентации
    presentation.save("FillFormat_SmartArt_ShapeNode_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Генерация миниатюры дочернего узла SmartArt**
Разработчики могут создавать миниатюру дочернего узла SmartArt, следуя приведенным ниже шагам:

1. Создайте экземпляр класса `Presentation`, представляющий файл PPTX.
1. Добавьте SmartArt.
1. Получите ссылку на узел, используя его индекс.
1. Получите изображение миниатюры.
1. Сохраните изображение миниатюры в любом желаемом формате изображения.

Пример ниже показывает, как создать миниатюру дочернего узла SmartArt.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

# Создайте экземпляр класса Presentation, представляющего файл PPTX
with slides.Presentation() as presentation: 
    # Добавьте SmartArt
    smart = pres.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.BASIC_CYCLE)

    # Получите ссылку на узел, используя его индекс  
    node = smart.nodes[1]

    # Получите миниатюру
    with node.shapes[0].get_image() as bmp:
        # сохраните миниатюру
        bmp.save("SmartArt_ChildNote_Thumbnail_out.jpeg", slides.ImageFormat.JPEG)
```