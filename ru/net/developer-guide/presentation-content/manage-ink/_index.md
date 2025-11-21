---
title: Управление объектами Ink в презентациях на .NET
linktitle: Управление Ink
type: docs
weight: 95
url: /ru/net/manage-ink/
keywords:
- инк
- объект инк
- трасса инк
- управление инк
- рисование инк
- рисование
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Управляйте объектами Ink в PowerPoint — создавайте, редактируйте и оформляйте цифровые чернила с помощью Aspose.Slides для .NET. Получите примеры кода для трасс, цвета и размера кисти."
---

PowerPoint предоставляет функцию рукописного ввода, позволяющую рисовать нестандартные фигуры, которые можно использовать для выделения других объектов, отображения связей и процессов, а также привлечения внимания к конкретным элементам на слайде. 

Aspose.Slides предоставляет интерфейс [Aspose.Slides.Ink](https://reference.aspose.com/slides/net/aspose.slides.ink/), содержащий типы, необходимые для создания и управления объектами Ink. 

## **Различия между обычными объектами и объектами Ink**

Объекты на слайде PowerPoint обычно представлены объектами Shape. Объект Shape в своей простейшей форме представляет собой контейнер, определяющий область самого объекта (его кадр) вместе с его свойствами. Последние включают размер области контейнера, форму контейнера, фон контейнера и т.д. Для справки см. [Shape Layout Format](https://docs.aspose.com/slides/net/shape-manipulations/#access-layout-formats-for-shape).

Однако когда PowerPoint работает с объектом Ink, он игнорирует все свойства кадра объекта (контейнера), кроме его размера. Размер области контейнера определяется стандартными значениями `width` и `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Inkshape Traces**

Trace – базовый элемент или стандарт, используемый для записи траектории пера, когда пользователь пишет цифровую рукопись. Traces представляют собой записи, описывающие последовательности связанных точек. 

Простейшая форма кодирования задаёт координаты X и Y каждой образцовой точки. Когда все связанные точки отрисованы, они образуют изображение, подобное этому:

![ink_powerpoint2](ink_powerpoint2.png)

## Свойства кисти для рисования 

Для рисования линий, соединяющих точки элементов trace, можно использовать кисть. Кисть имеет свой собственный цвет и размер, соответствующие свойствам `Brush.Color` и `Brush.Size`. 

### **Установить цвет кисти Ink**

Этот код C# показывает, как задать цвет кисти:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    IInk ink = (IInk)pres.Slides[0].Shapes[0];
    IInkTrace[] traces = ink.Traces;
    IInkBrush brush = traces[0].Brush;
    Color brushColor = brush.Color;
    brush.Color = Color.Red;
}
```


### **Установить размер кисти Ink** 

Этот код C# показывает, как задать размер кисти:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    IInk ink = (IInk)pres.Slides[0].Shapes[0];
    IInkTrace[] traces = ink.Traces;
    IInkBrush brush = traces[0].Brush;
    SizeF brushSize = brush.Size;
    brush.Size = new SizeF(5f, 10f);
}
```


Как правило, ширина и высота кисти не совпадают, поэтому PowerPoint не отображает размер кисти (раздел данных серый). Но когда ширина и высота кисти совпадают, PowerPoint отображает её размер так:

![ink_powerpoint3](ink_powerpoint3.png)

Для наглядности увеличим высоту объекта Ink и рассмотрим важные размеры: 

![ink_powerpoint4](ink_powerpoint4.png)

Контейнер (кадр) не учитывает размер кистей — он всегда подразумевает, что толщина линии равна нулю (см. последнее изображение). 

Поэтому, чтобы определить видимую область всего объекта Ink, необходимо учитывать размер кисти объектов trace. Здесь целевой объект (объект trace рукописного текста) масштабирован до размеров контейнера (кадра). При изменении размера контейнера (кадра) размер кисти остаётся постоянным и наоборот. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint демонстрирует аналогичное поведение при работе с текстом:

![ink_powerpoint6](ink_powerpoint6.png)

**Дополнительные материалы**

* Чтобы ознакомиться с формами в целом, см. раздел [PowerPoint Shapes](https://docs.aspose.com/slides/net/powerpoint-shapes/). 
* Для получения более подробной информации об эффективных значениях см. [Shape Effective Properties](https://docs.aspose.com/slides/net/shape-effective-properties/#get-effective-font-height-value).