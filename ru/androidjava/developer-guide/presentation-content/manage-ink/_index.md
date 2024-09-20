---
title: Управление чернилами
type: docs
weight: 95
url: /androidjava/manage-ink/
keywords: "Чернила в PowerPoint, инструменты для черчения, Java Ink, рисовать в PowerPoint, презентации PowerPoint, Java, Aspose.Slides для Android через Java"
description: "Используйте инструменты для черчения для рисования объектов в PowerPoint Java"
---

PowerPoint предоставляет функцию чернил, позволяющую вам рисовать нестандартные фигуры, которые можно использовать для выделения других объектов, отображения связей и процессов, а также для привлечения внимания к конкретным элементам на слайде.

Aspose.Slides предоставляет все типы чернил (например, [класс Ink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ink/)), необходимые для создания и управления объектами чернил.

## **Различия между обычными объектами и объектами чернил**

Объекты на слайде PowerPoint обычно представлены объектами форм. Объект формы в его простейшей форме является контейнером, который определяет область самого объекта (его рамки) наряду с его свойствами. К последним относятся размер контейнерной области, форма контейнера, фон контейнера и т. д. Для информации см. [Формат компоновки формы](https://docs.aspose.com/slides/androidjava/shape-manipulations/#access-layout-formats-for-shape).

Однако, когда PowerPoint работает с объектом чернил, он игнорирует все свойства рамки объекта (контейнера), за исключением его размера. Размер контейнерной области определяется стандартными значениями `width` и `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Следы Inkshape**

След — это основной элемент или стандарт, используемый для записи траектории пера, когда пользователь пишет цифровые чернила. Следы — это записи, которые описывают последовательности связанных точек.

Простейшая форма кодирования указывает координаты X и Y каждой контрольной точки. Когда все связанные точки отображаются, они создают изображение, подобное этому:

![ink_powerpoint2](ink_powerpoint2.png)

## Свойства кисти для рисования

Вы можете использовать кисть для рисования линий, соединяющих точки элементов следа. Кисть имеет свой собственный цвет и размер, соответствующие свойствам `Brush.Color` и `Brush.Size`.

### **Установить цвет кисти Ink**

Этот код на Java показывает, как установить цвет для кисти:

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

Этот код на Java показывает, как установить размер для кисти:

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

В общем, ширина и высота кисти не совпадают, поэтому PowerPoint не отображает размер кисти (раздел данных серый). Но когда ширина и высота кисти совпадают, PowerPoint отображает ее размер следующим образом:

![ink_powerpoint3](ink_powerpoint3.png)

Для наглядности давайте увеличим высоту объекта чернил и рассмотрим важные размеры:

![ink_powerpoint4](ink_powerpoint4.png)

Контейнер (рамка) не учитывает размер кистей — он всегда предполагает, что толщина линии равна нулю (см. последнее изображение).

Следовательно, для определения видимой области всего объекта чернил мы должны учитывать размер кисти объектов следа. Здесь целевой объект (объект следа с рукописным текстом) был масштабирован до размера контейнера (рамки). Когда размер контейнера (рамки) изменяется, размер кисти остается постоянным, и наоборот.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint проявляет такое же поведение при работе с текстами:

![ink_powerpoint6](ink_powerpoint6.png)

**Дополнительное чтение**

* Чтобы узнать о формах в общем, смотрите раздел [Фигуры PowerPoint](https://docs.aspose.com/slides/androidjava/powerpoint-shapes/).
* Для получения дополнительной информации об эффективных значениях см. [Эффективные свойства формы](https://docs.aspose.com/slides/androidjava/shape-effective-properties/#getting-effective-font-height-value).