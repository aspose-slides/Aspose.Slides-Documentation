---
title: Управление объектами чернил в презентации на Android
linktitle: Управление чернилами
type: docs
weight: 95
url: /ru/androidjava/manage-ink/
keywords:
- чернила
- объект чернил
- трасса чернил
- управление чернилами
- рисовать чернила
- рисование
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Управляйте объектами чернил PowerPoint — создавайте, редактируйте и оформляйте цифровые чернила с помощью Aspose.Slides для Android. Получайте образцы кода Java для трасс, цвета и размера кисти."
---

PowerPoint предоставляет функцию чернила, позволяющую рисовать нестандартные фигуры, которые можно использовать для выделения других объектов, отображения связей и процессов, а также привлечения внимания к определённым элементам на слайде. 

Aspose.Slides предоставляет все типы Ink (например, класс [Ink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ink/) ), необходимые для создания и управления объектами чернил.

## **Различия между обычными объектами и объектами Ink**

Объекты на слайде PowerPoint обычно представлены объектами формы. Объект формы, в своей простейшей форме, представляет собой контейнер, определяющий область самого объекта (его рамку) вместе со своими свойствами. Последние включают размер области контейнера, форму контейнера, фон контейнера и т.д. Для получения информации см. [Shape Layout Format](https://docs.aspose.com/slides/androidjava/shape-manipulations/#access-layout-formats-for-shape).

Однако когда PowerPoint работает с объектом Ink, он игнорирует все свойства рамки объекта (контейнера), за исключением его размера. Размер области контейнера определяется стандартными значениями `width` и `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Трассы Inkshape**

Трасса — базовый элемент или стандарт, используемый для записи траектории пера, когда пользователь пишет цифровыми чернилами. Трассы — это записи, описывающие последовательности связанных точек. 

Наиболее простая форма кодирования указывает координаты X и Y каждой точки выборки. Когда все связанные точки визуализируются, они образуют изображение, подобное этому:

![ink_powerpoint2](ink_powerpoint2.png)

## **Свойства кисти для рисования**

Вы можете использовать кисть для рисования линий, соединяющих точки элементов трассы. Кисть имеет свой собственный цвет и размер, соответствующие свойствам `Brush.Color` и `Brush.Size`. 

### **Установить цвет кисти Ink**

Этот Java‑код показывает, как задать цвет кисти:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    IInk ink = (IInk)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IInkTrace[] traces = ink.getTraces();
    IInkBrush brush = traces[0].getBrush();
    Color brushColor = brush.getColor();
    brush.setColor(Color.RED);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Установить размер кисти Ink** 

Этот Java‑код показывает, как задать размер кисти:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    IInk ink = (IInk)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IInkTrace[] traces = ink.getTraces();
    IInkBrush brush = traces[0].getBrush();
    Dimension2D brushSize = brush.getSize();
    brush.setSize(new Dimension(5, 10));
} finally {
    if (pres != null) pres.dispose();
}
```


Обычно ширина и высота кисти не совпадают, поэтому PowerPoint не отображает размер кисти (раздел данных серый). Но когда ширина и высота кисти совпадают, PowerPoint отображает её размер следующим образом:

![ink_powerpoint3](ink_powerpoint3.png)

Для наглядности увеличим высоту объекта Ink и рассмотрим важные размеры: 

![ink_powerpoint4](ink_powerpoint4.png)

Контейнер (рамка) не учитывает размер кистей — он всегда предполагает, что толщина линии равна нулю (см. последнее изображение). 

Следовательно, чтобы определить видимую область всего объекта Ink, необходимо учитывать размер кисти объектов трассы. Здесь целевой объект (объект трассы рукописного текста) масштабирован до размера контейнера (рамки). При изменении размера контейнера (рамки) размер кисти остаётся постоянным и наоборот. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint проявляет аналогичное поведение при работе с текстами:

![ink_powerpoint6](ink_powerpoint6.png)

**Дополнительное чтение**

* Чтобы узнать о формах в целом, см. раздел [PowerPoint Shapes](https://docs.aspose.com/slides/androidjava/powerpoint-shapes/).
* Для получения более подробной информации об эффективных значениях см. [Shape Effective Properties](https://docs.aspose.com/slides/androidjava/shape-effective-properties/#getting-effective-font-height-value).