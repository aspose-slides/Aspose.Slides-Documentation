---
title: Управление объектами чернил в презентациях на Android
linktitle: Управление чернилами
type: docs
weight: 95
url: /ru/androidjava/manage-ink/
keywords:
- чернила
- объект чернил
- след чернила
- управление чернилами
- рисование чернил
- рисование
- PowerPoint
- презентация
- Android
- Java
- Aspose.Slides
description: "Управляйте объектами чернил PowerPoint — создавайте, редактируйте и стилизуйте цифровые чернила с помощью Aspose.Slides для Android. Получите примеры кода Java для следов, цвета и размера кисти."
---

PowerPoint предоставляет функцию «инк», позволяющую рисовать нестандартные фигуры, которые можно использовать для выделения других объектов, отображения связей и процессов, а также привлечения внимания к определённым элементам на слайде. 

Aspose.Slides предоставляет все типы Ink (например, класс [Ink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ink/)), необходимые для создания и управления объектами ink.

## **Различия между обычными объектами и объектами Ink**

Объекты на слайде PowerPoint обычно представляются объектами формы. Объект формы в своей простейшей форме — это контейнер, определяющий область самого объекта (его кадр) вместе с его свойствами. Последние включают размер области контейнера, форму контейнера, фон контейнера и т.д. Смотрите раздел [Shape Layout Format](https://docs.aspose.com/slides/androidjava/shape-manipulations/#access-layout-formats-for-shape) для получения дополнительной информации.

Однако когда PowerPoint работает с объектом ink, он игнорирует все свойства кадра объекта (контейнера), за исключением его размера. Размер области контейнера определяется стандартными значениями `width` и `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Следы Inkshape**

След — это базовый элемент или стандарт, используемый для записи траектории пера, когда пользователь пишет цифровой ink. Следы — это записи, описывающие последовательности связанных точек. 

Самая простая форма кодировки указывает координаты X и Y каждой точки выборки. Когда все связанные точки отрисованы, они образуют изображение, подобное этому:

![ink_powerpoint2](ink_powerpoint2.png)

## **Свойства кисти для рисования**

Для рисования линий, соединяющих точки элементов следа, можно использовать кисть. У кисти есть свой собственный цвет и размер, соответствующие свойствам `Brush.Color` и `Brush.Size`. 

### **Установка цвета кисти Ink**

Этот код Java показывает, как задать цвет кисти:
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


### **Установка размера кисти Ink** 

Этот код Java показывает, как задать размер кисти:
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


Как правило, ширина и высота кисти не совпадают, поэтому PowerPoint не отображает размер кисти (раздел данных серый). Но когда ширина и высота кисти совпадают, PowerPoint отображает её размер так:

![ink_powerpoint3](ink_powerpoint3.png)

Для наглядности увеличим высоту объекта ink и рассмотрим важные размеры: 

![ink_powerpoint4](ink_powerpoint4.png)

Контейнер (кадр) не учитывает размер кистей — он всегда предполагает, что толщина линии равна нулю (см. последнее изображение). 

Следовательно, чтобы определить видимую область всего объекта ink, необходимо учитывать размер кисти объектов следа. Здесь целевой объект (след рукописного текста) был масштабирован до размера контейнера (кадра). Когда размер контейнера (кадра) меняется, размер кисти остаётся постоянным и наоборот. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint демонстрирует аналогичное поведение при работе с текстом:

![ink_powerpoint6](ink_powerpoint6.png)

**Дополнительные материалы**

* Чтобы узнать о формах в целом, смотрите раздел [PowerPoint Shapes](https://docs.aspose.com/slides/androidjava/powerpoint-shapes/).
* Для получения дополнительной информации об эффективных значениях см. [Shape Effective Properties](https://docs.aspose.com/slides/androidjava/shape-effective-properties/#getting-effective-font-height-value).