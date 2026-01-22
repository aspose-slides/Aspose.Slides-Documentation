---
title: Управление объектами чернил презентации в JavaScript
linktitle: Управление чернилами
type: docs
weight: 95
url: /ru/nodejs-java/manage-ink/
keywords:
- чернила
- объект чернил
- трасса чернил
- управление чернилами
- рисовать чернила
- рисование
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Управляйте объектами чернил PowerPoint — создавайте, редактируйте и оформляйте цифровые чернила с помощью Aspose.Slides для Node.js. Получите примеры кода JavaScript для трасс, цвета и размера кисти."
---

PowerPoint предоставляет функцию «чернила», позволяя рисовать нестандартные фигуры, которые можно использовать для выделения других объектов, отображения связей и процессов, а также привлечения внимания к определённым элементам на слайде. 

Aspose.Slides предоставляет все типы Ink (например, класс [Ink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ink/)) — необходимые для создания и управления объектами чернил.

## **Различия между обычным объектом и объектами Ink**

Объекты на слайде PowerPoint обычно представлены объектами формы. Объект формы в своей простой форме — это контейнер, определяющий область самого объекта (его кадр) вместе со своими свойствами. Последние включают размер области контейнера, форму контейнера, фон контейнера и т.д. Для справки см. [Формат расположения формы](https://docs.aspose.com/slides/nodejs-java/shape-manipulations/#access-layout-formats-for-shape).

Однако когда PowerPoint работает с объектом Ink, он игнорирует все свойства кадра объекта (контейнера), кроме его размера. Размер области контейнера определяется стандартными значениями `width` и `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Отпечатки Inkshape**

Отпечаток — базовый элемент или стандарт, используемый для записи траектории пера, когда пользователь пишет цифровыми чернилами. Отпечатки — это записи, описывающие последовательности соединённых точек. 

Самая простая форма кодирования указывает координаты X и Y каждой точки выборки. Когда все соединённые точки отрисовываются, они образуют изображение, похожее на это:

![ink_powerpoint2](ink_powerpoint2.png)

## Свойства кисти для рисования 

Можно использовать кисть для рисования линий, соединяющих точки элементов отпечатков. Кисть имеет собственный цвет и размер, соответствующие методам `Brush.setColor` и `Brush.setSize`. 

### **Установить цвет кисти Ink**

Этот JavaScript‑код показывает, как установить цвет кисти:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var ink = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var traces = ink.getTraces();
    var brush = traces[0].getBrush();
    var brushColor = brush.getColor();
    brush.setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Установить размер кисти Ink** 

Этот JavaScript‑код показывает, как установить размер кисти:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var ink = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var traces = ink.getTraces();
    var brush = traces[0].getBrush();
    var brushSize = brush.getSize();
    brush.setSize(java.newInstanceSync("java.awt.Dimension", 5, 10));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Обычно ширина и высота кисти не совпадают, поэтому PowerPoint не отображает размер кисти (раздел данных серый). Но когда ширина и высота кисти совпадают, PowerPoint отображает её размер так:

![ink_powerpoint3](ink_powerpoint3.png)

Для наглядности увеличим высоту объекта Ink и рассмотрим важные размеры: 

![ink_powerpoint4](ink_powerpoint4.png)

Контейнер (кадр) не учитывает размер кистей — он всегда предполагает, что толщина линии равна нулю (см. последнюю картинку). 

Следовательно, чтобы определить видимую область всего объекта Ink, необходимо учитывать размер кисти объектов отпечатков. Здесь целевой объект (отпечаток рукописного текста) масштабирован до размера контейнера (кадра). Когда размер контейнера (кадра) меняется, размер кисти остаётся постоянным и наоборот. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint демонстрирует аналогичное поведение при работе с текстом:

![ink_powerpoint6](ink_powerpoint6.png)

**См. также**

* Чтобы узнать о формах в целом, см. раздел [Формы PowerPoint](https://docs.aspose.com/slides/nodejs-java/powerpoint-shapes/).
* Для дополнительной информации об эффективных значениях см. [Эффективные свойства формы](https://docs.aspose.com/slides/nodejs-java/shape-effective-properties/#getting-effective-font-height-value).