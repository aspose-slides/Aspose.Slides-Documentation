---
title: Добавление эллипсов в презентации на PHP
linktitle: Эллипс
type: docs
weight: 30
url: /ru/php-java/ellipse/
keywords:
- эллипс
- фигура
- добавить эллипс
- создать эллипс
- нарисовать эллипс
- форматированный эллипс
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как создавать, форматировать и управлять фигурами‑эллипсами в Aspose.Slides for PHP via Java для презентаций PPT и PPTX — включены примеры кода."
---

{{% alert color="primary" %}} 

В этой теме мы расскажем разработчикам о добавлении эллипсов на их слайды с помощью Aspose.Slides for PHP via Java. Aspose.Slides for PHP via Java предоставляет упрощённый набор API для рисования различных фигур всего несколькими строками кода.

{{% /alert %}} 

## **Создать эллипс**
Чтобы добавить простой эллипс на выбранный слайд презентации, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте AutoShape типа Ellipse с помощью метода [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addAutoShape), доступного в объекте [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/).
- Запишите изменённую презентацию в файл PPTX.

В приведённом ниже примере мы добавили эллипс на первый слайд
```php
  # Создайте объект класса Presentation, представляющий PPTX
  $pres = new Presentation();
  try {
    # Получите первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Добавьте AutoShape типа эллипс
    $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # Запишите файл PPTX на диск
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Создать форматированный эллипс**
Чтобы добавить более форматированный эллипс на слайд, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте AutoShape типа Ellipse с помощью метода [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addAutoShape), доступного в объекте [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/).
- Установите тип заливки эллипса в Solid.
- Установите цвет эллипса с помощью метода `SolidFillColor::setColor`, доступного в объекте [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/), связанном с объектом [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/).
- Установите цвет линий эллипса.
- Установите ширину линий эллипса.
- Запишите изменённую презентацию в файл PPTX.

В приведённом ниже примере мы добавили форматированный эллипс на первый слайд презентации.
```php
  # Создать объект класса Presentation, представляющий PPTX
  $pres = new Presentation();
  try {
    # Получить первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Добавить AutoShape типа эллипса
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # Применить некоторое форматирование к фигуре эллипса
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Chocolate));
    # Применить некоторое форматирование к линии эллипса
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # Записать файл PPTX на диск
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Как задать точное положение и размер эллипса относительно единиц измерения слайда?**

Координаты и размеры обычно указываются **в пунктах**. Чтобы получить предсказуемый результат, рассчитывайте на основе размеров слайда и преобразуйте требуемые миллиметры или дюймы в пункты перед присвоением значений.

**Как разместить эллипс выше или ниже других объектов (управление порядком наложения)?**

Измените порядок отрисовки объекта, переместив его на передний план или отправив назад. Это позволяет эллипсу перекрывать другие объекты или показывать находящиеся под ним.

**Как анимировать появление или выделение эллипса?**

[Применить](/slides/ru/php-java/shape-animation/) эффекты появления, акцентирования или исчезновения к фигуре и настройте триггеры и тайминги, чтобы определить, когда и как будет воспроизводиться анимация.