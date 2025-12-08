---
title: Управление узлами SmartArt в презентациях с помощью Python
linktitle: Узел SmartArt
type: docs
weight: 30
url: /ru/python-net/manage-smartart-shape-node/
keywords:
- Узел SmartArt
- дочерний узел
- добавить узел
- позиция узла
- доступ к узлу
- удалить узел
- пользовательская позиция
- узел‑ассистент
- формат заливки
- визуализировать узел
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Управляйте узлами SmartArt в файлах PPT, PPTX и ODP с помощью Aspose.Slides for Python via .NET. Получите понятные примеры кода и советы по оптимизации ваших презентаций."
---

## **Добавить узел SmartArt**
Aspose.Slides для Python через .NET предоставляет самый простой API для управления фигурой SmartArt самым простым способом. Ниже приведён пример кода, который поможет добавить узел и дочерний узел внутри фигуры SmartArt.

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и загрузите презентацию с фигурой SmartArt.
- Получите ссылку на первый слайд, используя его индекс.
- Пройдитесь по всем фигурам на первом слайде.
- Проверьте, является ли фигура типом SmartArt, и выполните приведение выбранной фигуры к SmartArt, если это SmartArt.
- Добавьте новый узел в коллекцию NodeCollection фигуры SmartArt и задайте текст в TextFrame.
- Затем добавьте дочерний узел в только что добавленный узел SmartArt и задайте текст в TextFrame.
- Сохраните презентацию.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Загрузите нужную презентацию
with slides.Presentation(path + "AddNodes.pptx") as pres:
    # Пройдитесь по всем фигурам на первом слайде
    for shape in pres.slides[0].shapes:

        # Проверьте, является ли фигура типом SmartArt
        if type(shape) is art.SmartArt:
            # Добавление нового узла SmartArt
            node1 = shape.all_nodes.add_node()
            # Добавление текста
            node1.text_frame.text = "Test"

            # Добавление нового дочернего узла в родительский узел. Он будет добавлен в конец коллекции
            new_node = node1.child_nodes.add_node()

            # Добавление текста
            new_node.text_frame.text = "New Node Added"

    # Сохранение презентации
    pres.save("AddSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Добавить узел SmartArt в определённой позиции**
В следующем примере кода объясняется, как добавить дочерние узлы, принадлежащие соответствующим узлам фигуры SmartArt, в определённую позицию.

- Создайте экземпляр класса `Presentation`.
- Получите ссылку на первый слайд, используя его индекс.
- Добавьте в выбранный слайд фигуру SmartArt типа StackedList.
- Получите доступ к первому узлу в добавленной фигуре SmartArt.
- Затем добавьте дочерний узел для выбранного узла на позицию 2 и задайте его текст.
- Сохраните презентацию.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Создание экземпляра презентации
with slides.Presentation() as pres:
    # Доступ к слайду презентации
    slide = pres.slides[0]

    # Добавление Smart Art IShape
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)

    # Получение узла SmartArt по индексу 0
    node = smart.all_nodes[0]

    # Добавление нового дочернего узла на позицию 2 в родительском узле
    chNode = node.child_nodes.add_node_by_position(2)

    # Добавление текста
    chNode.text_frame.text = "Sample text Added"

    # Сохранение презентации
    pres.save("AddSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Доступ к узлу SmartArt**
Ниже приведён пример кода, который поможет получить доступ к узлам внутри фигуры SmartArt. Обратите внимание, что изменить LayoutType SmartArt невозможно, так как он доступен только для чтения и задаётся только при добавлении фигуры SmartArt.

- Создайте экземпляр класса `Presentation` и загрузите презентацию с фигурой SmartArt.
- Получите ссылку на первый слайд, используя его индекс.
- Пройдитесь по всем фигурам на первом слайде.
- Проверьте, является ли фигура типом SmartArt, и выполните приведение выбранной фигуры к SmartArt, если это SmartArt.
- Пройдитесь по всем узлам внутри фигуры SmartArt.
- Получите и отобразите информацию, такую как позиция узла SmartArt, уровень и текст.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Загрузите нужную презентацию
with slides.Presentation(path + "AccessSmartArt.pptx") as pres:
    # Пройдитесь по всем фигурам на первом слайде
    for shape in pres.slides[0].shapes:
        # Проверьте, является ли фигура типом SmartArt
        if type(shape) is art.SmartArt:
            # Пройдитесь по всем узлам внутри SmartArt
            for i in range(len(shape.all_nodes)):
                # Получение узла SmartArt по индексу i
                node = shape.all_nodes[i]

                # Вывод параметров узла SmartArt
                print("i = {0}, text = {1},  level = {2}, position = {3}".format(i, node.text_frame.text, node.level, node.position))
```


## **Доступ к дочернему узлу SmartArt**
Ниже приведён пример кода, который поможет получить доступ к дочерним узлам, принадлежащим соответствующим узлам фигуры SmartArt.

- Создайте экземпляр класса PresentationEx и загрузите презентацию с фигурой SmartArt.
- Получите ссылку на первый слайд, используя его индекс.
- Пройдитесь по всем фигурам на первом слайде.
- Проверьте, является ли фигура типом SmartArt, и выполните приведение выбранной фигуры к SmartArtEx, если это SmartArt.
- Пройдитесь по всем узлам внутри фигуры SmartArt.
- Для каждого выбранного узла фигуры SmartArt пройдитесь по всем дочерним узлам внутри конкретного узла.
- Получите и отобразите информацию, такую как позиция дочернего узла, уровень и текст.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Загрузите нужную презентацию
with slides.Presentation(path + "AccessChildNodes.pptx") as pres:
    # Пройдитесь по всем фигурам на первом слайде
    for shape in pres.slides[0].shapes:
        # Проверьте, является ли фигура типом SmartArt
        if type(shape) is art.SmartArt:
            # Пройдитесь по всем узлам внутри SmartArt
            for node0 in shape.all_nodes:
                # Проходим по дочерним узлам
                for j in range(len(node0.child_nodes)):
                    # Получаем дочерний узел в узле SmartArt
                    node = node0.child_nodes[j]

                    # Вывод параметров дочернего узла SmartArt
                    print("j = {0}, text = {1},  level = {2}, position = {3}".format(j, node.text_frame.text, node.level, node.position))
```


## **Доступ к дочернему узлу SmartArt в определённой позиции**
В этом примере мы узнаем, как получить доступ к дочерним узлам в определённой позиции, принадлежащим соответствующим узлам фигуры SmartArt.

- Создайте экземпляр класса `Presentation`.
- Получите ссылку на первый слайд, используя его индекс.
- Добавьте фигуру SmartArt типа StackedList.
- Получите доступ к добавленной фигуре SmartArt.
- Получите узел с индексом 0 в выбранной фигуре SmartArt.
- Затем получите дочерний узел на позиции 1 для выбранного узла SmartArt, используя метод GetNodeByPosition().
- Получите и отобразите информацию, такую как позиция дочернего узла, уровень и текст.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Создание экземпляра презентации
with slides.Presentation() as pres:
    # Получение первого слайда
    slide = pres.slides[0]
    # Добавление SmartArt фигуры на первый слайд
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)
    # Доступ к узлу SmartArt с индексом 0
    node = smart.all_nodes[0]
    # Получение дочернего узла на позиции 1 в родительском узле
    position = 1
    chNode = node.child_nodes[position] 
    # Вывод параметров дочернего узла SmartArt
    print("j = {0}, text = {1},  level = {2}, position = {3}".format(position, chNode.text_frame.text, chNode.level, chNode.position))
```


## **Удалить узел SmartArt**
В этом примере мы узнаем, как удалить узлы внутри фигуры SmartArt.

- Создайте экземпляр класса `Presentation` и загрузите презентацию с фигурой SmartArt.
- Получите ссылку на первый слайд, используя его индекс.
- Пройдитесь по всем фигурам на первом слайде.
- Проверьте, является ли фигура типом SmartArt, и выполните приведение выбранной фигуры к SmartArt, если это SmartArt.
- Проверьте, содержит ли SmartArt более 0 узлов.
- Выберите узел SmartArt, который нужно удалить.
- Затем удалите выбранный узел, используя метод RemoveNode(), и сохраните презентацию.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Загрузите нужную презентацию
with slides.Presentation(path + "RemoveNode.pptx") as pres:
    # Пройдитесь по всем фигурам на первом слайде
    for shape in pres.slides[0].shapes:
        # Проверьте, является ли фигура типом SmartArt
        if type(shape) is art.SmartArt:
            # Приведение фигуры к SmartArtEx
            if len(shape.all_nodes) > 0:
                # Доступ к узлу SmartArt по индексу 0
                node = shape.all_nodes[0]

                # Удаление выбранного узла
                shape.all_nodes.remove_node(node)

    # Сохранение презентации
    pres.save("RemoveSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Удалить узел SmartArt в определённой позиции**
В этом примере мы узнаем, как удалить узлы внутри фигуры SmartArt в определённой позиции.

- Создайте экземпляр класса `Presentation` и загрузите презентацию с фигурой SmartArt.
- Получите ссылку на первый слайд, используя его индекс.
- Пройдитесь по всем фигурам на первом слайде.
- Проверьте, является ли фигура типом SmartArt, и выполните приведение выбранной фигуры к SmartArt, если это SmartArt.
- Выберите узел фигуры SmartArt с индексом 0.
- Затем проверьте, содержит ли выбранный узел SmartArt более 2 дочерних узлов.
- Затем удалите узел на позиции 1, используя метод RemoveNodeByPosition().
- Сохраните презентацию.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Загрузите нужную презентацию
with slides.Presentation(path + "RemoveNodeSpecificPosition.pptx") as pres:             
    # Пройдитесь по всем фигурам на первом слайде
    for shape in pres.slides[0].shapes:
        # Проверьте, является ли фигура типом SmartArt
        if type(shape) is art.SmartArt:
            # Приведение фигуры к SmartArt
            if len(shape.all_nodes) > 0:
                # Доступ к узлу SmartArt по индексу 0
                node = shape.all_nodes[0]
                if len(node.child_nodes) >= 2:
                    # Удаление дочернего узла на позиции 1
                    node.child_nodes.remove_node(1)

    # Сохранение презентации
    pres.save("RemoveSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Установить пользовательскую позицию для дочернего узла в SmartArt**
Теперь Aspose.Slides для Python через .NET поддерживает установку свойств X и Y для SmartArtShape. Ниже приведён фрагмент кода, показывающий, как установить пользовательскую позицию, размер и вращение SmartArtShape; также обратите внимание, что добавление новых узлов вызывает пересчёт позиций и размеров всех узлов.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Загрузите нужную презентацию
with slides.Presentation(path + "AccessChildNodes.pptx") as pres: 
	smart = pres.slides[0].shapes.add_smart_art(20, 20, 600, 500, art.SmartArtLayoutType.ORGANIZATION_CHART)

	# Переместить форму SmartArt в новую позицию
	node = smart.all_nodes[1]
	shape = node.shapes[1]
	shape.x += (shape.width * 2)
	shape.y -= (shape.height / 2)

	# Изменить ширину формы SmartArt
	node = smart.all_nodes[2]
	shape = node.shapes[1]
	shape.width += (shape.width / 2)

	# Изменить высоту формы SmartArt
	node = smart.all_nodes[3]
	shape = node.shapes[1]
	shape.height += (shape.height / 2)

	# Изменить вращение формы SmartArt
	node = smart.all_nodes[4]
	shape = node.shapes[1]
	shape.rotation = 90

	pres.save("SmartArt.pptx", slides.export.SaveFormat.PPTX)
```


## **Проверить узел‑ассистент**
В следующем примере кода мы исследуем, как определить узлы‑ассистенты в коллекции узлов SmartArt и изменить их.

- Создайте экземпляр класса PresentationEx и загрузите презентацию с фигурой SmartArt.
- Получите ссылку на второй слайд, используя его индекс.
- Пройдитесь по всем фигурам на первом слайде.
- Проверьте, является ли фигура типом SmartArt, и выполните приведение выбранной фигуры к SmartArtEx, если это SmartArt.
- Пройдитесь по всем узлам внутри фигуры SmartArt и проверьте, являются ли они узлами‑ассистентами.
- Измените статус узла‑ассистента на обычный узел.
- Сохраните презентацию.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Создание экземпляра презентации
with slides.Presentation(path + "AssistantNode.pptx") as pres: 
    # Обход всех фигур на первом слайде
    for shape in pres.slides[0].shapes:
        # Проверка, является ли фигура типом SmartArt
        if type(shape) is art.SmartArt:
            # Обход всех узлов фигуры SmartArt
            for node in shape.all_nodes:
                tc = node.text_frame.text
                # Проверка, является ли узел узлом‑ассистентом
                if node.is_assistant:
                    # Установка свойства узла‑ассистента в false и преобразование в обычный узел
                    node.is_assistant = False
    # Сохранение презентации
    pres.save("ChangeAssitantNode_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Установить формат заливки узла**
Aspose.Slides для Python через .NET позволяет добавлять пользовательские фигуры SmartArt и задавать их форматы заливки. Эта статья объясняет, как создавать и получать доступ к фигурам SmartArt и задавать их формат заливки с помощью Aspose.Slides для Python через .NET.

- Создайте экземпляр класса `Presentation`.
- Получите ссылку на слайд, используя его индекс.
- Добавьте фигуру SmartArt, задав её LayoutType.
- Задайте FillFormat для узлов фигуры SmartArt.
- Запишите изменённую презентацию в файл PPTX.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation: 
    # Доступ к слайду
    slide = presentation.slides[0]

    # Добавление SmartArt фигуры и узлов
    chevron = slide.shapes.add_smart_art(10, 10, 800, 60, art.SmartArtLayoutType.CLOSED_CHEVRON_PROCESS)
    node = chevron.all_nodes.add_node()
    node.text_frame.text = "Some text"

    # Установка цвета заливки узла
    for item in node.shapes:
        item.fill_format.fill_type = slides.FillType.SOLID
        item.fill_format.solid_fill_color.color = draw.Color.red

    # Сохранение презентации
    presentation.save("FillFormat_SmartArt_ShapeNode_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Создать миниатюру дочернего узла SmartArt**
Разработчики могут создать миниатюру дочернего узла SmartArt, следуя нижеприведённым шагам:

1. Создайте экземпляр класса `Presentation`, представляющего файл PPTX.
2. Добавьте SmartArt.
3. Получите ссылку на узел, используя его индекс.
4. Получите изображение миниатюры.
5. Сохраните изображение миниатюры в любом нужном формате изображения.

Пример ниже генерирует миниатюру дочернего узла SmartArt
```py
import aspose.slides as slides
import aspose.slides.smartart as art

# Создать экземпляр класса Presentation, представляющего файл PPTX 
with slides.Presentation() as presentation: 
    # Добавить SmartArt 
    smart = pres.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.BASIC_CYCLE)

    # Получить ссылку на узел, используя его индекс  
    node = smart.nodes[1]

    # Получить миниатюру
    with node.shapes[0].get_image() as bmp:
        # Сохранить миниатюру
        bmp.save("SmartArt_ChildNote_Thumbnail_out.jpeg", slides.ImageFormat.JPEG)
```


## **FAQ**

**Поддерживается ли анимация SmartArt?**

Да. SmartArt рассматривается как обычная фигура, поэтому вы можете [применять стандартные анимации](/slides/ru/python-net/shape-animation/) (вход, выход, акцент, траектории движения) и настраивать тайминг. При необходимости можно также анимировать фигуры внутри узлов SmartArt.

**Как надёжно найти определённый SmartArt на слайде, если его внутренний идентификатор неизвестен?**

Назначьте и ищите по [альтернативному тексту](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/alternative_text/). Установка отличительного AltText для SmartArt позволяет находить его программно без обращения к внутренним идентификаторам.

**Сохранится ли внешний вид SmartArt при конвертации презентации в PDF?**

Да. Aspose.Slides отображает SmartArt с высокой визуальной точностью при [экспорте в PDF](/slides/ru/python-net/convert-powerpoint-to-pdf/), сохраняя макет, цвета и эффекты.

**Могу ли я извлечь изображение всего SmartArt (для превью или отчётов)?**

Да. Вы можете отобразить фигуру SmartArt в [растровые форматы](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/get_image/) или в [SVG](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/write_as_svg/) для масштабируемого векторного вывода, что делает её подходящей для миниатюр, отчётов или использования в вебе.