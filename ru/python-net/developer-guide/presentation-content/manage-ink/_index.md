---
title: Управление чернилами
type: docs
weight: 95
url: /ru/python-net/manage-ink/
keywords: "чернила в PowerPoint, инструменты для рисования, Python Ink, рисовать в PowerPoint, презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Используйте инструменты для рисования, чтобы рисовать объекты в PowerPoint на Python"
---

PowerPoint предоставляет функцию чернил, позволяющую рисовать нестандартные фигуры, которые можно использовать для выделения других объектов, отображения связей и процессов, а также для привлечения внимания к определенным элементам на слайде.

Aspose.Slides предоставляет интерфейс [Aspose.Slides.Ink](https://reference.aspose.com/slides/python-net/aspose.slides.ink/), который содержит необходимые типы для создания и управления чернильными объектами.

## **Различия между обычными объектами и чернильными объектами**

Объекты на слайде PowerPoint обычно представлены объектами формы. Объект формы в своей простой версии является контейнером, который определяет область самого объекта (его рамка) наряду с его свойствами. Последние включают размер области контейнера, форму контейнера, фон контейнера и т.д. Для получения информации см. [Формат компоновки формы](https://docs.aspose.com/slides/python-net/shape-manipulations/#access-layout-formats-for-shape).

Однако, когда PowerPoint имеет дело с чернильным объектом, он игнорирует все свойства рамки объекта (контейнера), кроме его размера. Размер области контейнера определяют стандартные значения `width` и `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Треки чернила**

Трек — это основной элемент или стандарт, используемый для записи траектории пера, когда пользователь пишет цифровые чернила. Треки — это записи, которые описывают последовательности связанных точек.

Простейшая форма кодирования указывает координаты X и Y каждой контрольной точки. Когда все связанные точки отображаются, они создают изображение, подобное этому:

![ink_powerpoint2](ink_powerpoint2.png)

## Свойства кисти для рисования

Вы можете использовать кисть для рисования линий, соединяющих точки элементов трека. Кисть имеет свой собственный цвет и размер, соответствующие свойствам `Brush.Color` и `Brush.Size`.

### **Установить цвет кисти для чернил**

Этот код на Python показывает, как установить цвет для кисти:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as pres:
    ink = pres.slides[0].shapes[0]
    traces = ink.traces
    brush = traces[0].brush
    brush_color = brush.color
    brush.color = draw.Color.red
```

### **Установить размер кисти для чернил**

Этот код на Python показывает, как установить размер для кисти:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as pres:
    ink = pres.slides[0].shapes[0]
    traces = ink.traces
    brush = traces[0].brush
    brush_size = brush.size
    brush.size = draw.SizeF(5.0, 10.0)
```

В целом, ширина и высота кисти не совпадают, поэтому PowerPoint не отображает размер кисти (раздел данных серый). Но когда ширина и высота кисти совпадают, PowerPoint отображает ее размер следующим образом:

![ink_powerpoint3](ink_powerpoint3.png)

Для ясности давайте увеличим высоту чернильного объекта и рассмотрим важные размеры:

![ink_powerpoint4](ink_powerpoint4.png)

Контейнер (рамка) не учитывает размер кистей — он всегда предполагает, что толщина линии равна нулю (см. последнее изображение).

Таким образом, чтобы определить видимую область всего чернильного объекта, мы должны учитывать размер кисти объектов треков. Здесь целевой объект (объект ручной записи текста) масштабируется до размера контейнера (рамки). Когда размер контейнера (рамки) изменяется, размер кисти остается постоянным и наоборот.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint демонстрирует такое же поведение при работе с текстами:

![ink_powerpoint6](ink_powerpoint6.png)

**Дополнительное чтение**

* Чтобы прочитать об объектах формы в общем, смотрите раздел [Формы PowerPoint](https://docs.aspose.com/slides/python-net/powerpoint-shapes/).
* Для получения дополнительной информации об эффективных значениях см. [Эффективные свойства формы](https://docs.aspose.com/slides/python-net/shape-effective-properties/#get-effective-font-height-value).