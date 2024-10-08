---
title: Управление чернилами
type: docs
weight: 95
url: /ru/php-java/manage-ink/
keywords: "Чернила в PowerPoint, инструменты чернил, Java Ink, рисовать в PowerPoint, презентация PowerPoint, Java, Aspose.Slides для PHP через Java"
description: "Используйте инструменты чернил для рисования объектов в PowerPoint на Java"
---

PowerPoint предоставляет функцию чернил, которая позволяет вам рисовать нестандартные фигуры, которые могут использоваться для выделения других объектов, демонстрации связей и процессов, а также привлечение внимания к конкретным элементам на слайде.

Aspose.Slides предоставляет все виды чернил (например, [класс Ink](https://reference.aspose.com/slides/php-java/aspose.slides/ink/)), которые вам нужны для создания и управления объектами чернил.

## **Различия между обычными объектами и объектами чернил**

Объекты на слайде PowerPoint обычно представлены объектами формы. Объект формы в своей самой простой форме представляет собой контейнер, который определяет область самого объекта (его рамки) вместе с его свойствами. К последним относятся размер области контейнера, форма контейнера, фон контейнера и т.д. Для получения информации см. [Формат макета формы](https://docs.aspose.com/slides/php-java/shape-manipulations/#access-layout-formats-for-shape).

Однако, когда PowerPoint работает с объектом чернил, он игнорирует все свойства рамки объекта (контейнера), кроме его размера. Размер области контейнера определяется стандартными значениями `width` и `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Следы чернил**

След - это основной элемент или стандарт, используемый для записи траектории пера, когда пользователь пишет цифровые чернила. Следы - это записи, которые описывают последовательности связанных точек.

Самая простая форма кодирования указывает X и Y координаты каждой выборки. Когда все связанные точки отображаются, они создают изображение, подобное этому:

![ink_powerpoint2](ink_powerpoint2.png)

## Свойства кисти для рисования

Вы можете использовать кисть для рисования линий, соединяющих точки элементов следов. У кисти есть свой цвет и размер, соответствующие свойствам `Brush.Color` и `Brush.Size`.

### **Установка цвета кисти чернил**

Этот PHP код показывает, как установить цвет для кисти:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $ink = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $traces = $ink->getTraces();
    $brush = $traces[0]->getBrush();
    $brushColor = $brush->getColor();
    $brush->setColor(java("java.awt.Color")->RED);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Установка размера кисти чернил** 

Этот PHP код показывает, как установить размер для кисти:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $ink = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $traces = $ink->getTraces();
    $brush = $traces[0]->getBrush();
    $brushSize = $brush->getSize();
    $brush->setSize(new Java("java.awt.Dimension", 5, 10));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

В целом, ширина и высота кисти не совпадают, поэтому PowerPoint не отображает размер кисти (раздел данных серый). Но когда ширина и высота кисти совпадают, PowerPoint отображает ее размер следующим образом:

![ink_powerpoint3](ink_powerpoint3.png)

Для ясности давайте увеличим высоту объекта чернил и рассмотрим важные размеры:

![ink_powerpoint4](ink_powerpoint4.png)

Контейнер (рамка) не учитывает размер кистей - он всегда предполагает, что толщина линии равна нулю (см. последнее изображение).

Поэтому, чтобы определить видимую область всего объекта чернил, мы должны учитывать размер кисти объектов следов. Здесь целевой объект (объект следа рукописного текста) был масштабирован до размера контейнера (рамки). Когда размер контейнера (рамки) изменяется, размер кисти остается постоянным и наоборот.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint демонстрирует такое же поведение, когда работает с текстами:

![ink_powerpoint6](ink_powerpoint6.png)

**Дополнительное чтение**

* Чтобы узнать о формах в целом, см. раздел [Формы PowerPoint](https://docs.aspose.com/slides/php-java/powerpoint-shapes/).
* Для получения дополнительной информации о эффективных значениях см. [Эффективные свойства формы](https://docs.aspose.com/slides/php-java/shape-effective-properties/#getting-effective-font-height-value).