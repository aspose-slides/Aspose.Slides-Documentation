---
title: Добавить эллипсы в презентации на PHP
linktitle: Эллипс
type: docs
weight: 30
url: /ru/php-java/ellipse/
keywords:
- эллипс
- форма
- добавить эллипс
- создать эллипс
- нарисовать эллипс
- отформатированный эллипс
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Узнайте, как создавать, форматировать и управлять формами эллипсов в Aspose.Slides for PHP via Java в презентациях PPT и PPTX — примеры кода включены."
---

{{% alert color="primary" %}} 

В этой статье мы познакомим разработчиков с добавлением эллипсов на слайды с помощью Aspose.Slides for PHP via Java. Aspose.Slides for PHP via Java предоставляет упрощённый набор API для рисования различных фигур всего в несколько строк кода.

{{% /alert %}} 

## **Создать эллипс**
Чтобы добавить простой эллипс на выбранный слайд презентации, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте AutoShape типа Ellipse с помощью метода [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) объекта [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).
- Сохраните изменённую презентацию в файл PPTX.

В примере ниже мы добавили эллипс на первый слайд
```php
  # Создать объект класса Presentation, представляющий PPTX
  $pres = new Presentation();
  try {
    # Получить первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Добавить AutoShape типа Ellipse
    $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # Сохранить файл PPTX на диск
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Создать отформатированный эллипс**
Чтобы добавить более оформленный эллипс на слайд, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте AutoShape типа Ellipse с помощью метода [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) объекта [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).
- Установите тип заливки эллипса как Solid.
- Установите цвет эллипса через свойство SolidFillColor.Color объекта [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IFillFormat), связанного с объектом [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape).
- Установите цвет линий эллипса.
- Установите ширину линий эллипса.
- Сохраните изменённую презентацию в файл PPTX.

В примере ниже мы добавили отформатированный эллипс на первый слайд презентации.
```php
  # Создать объект класса Presentation, представляющий PPTX
  $pres = new Presentation();
  try {
    # Получить первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Добавить AutoShape типа Ellipse
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # Применить некоторое форматирование к фигуре эллипса
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Chocolate));
    # Применить некоторое форматирование к линии эллипса
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # Сохранить файл PPTX на диск
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Как задать точное положение и размер эллипса относительно единиц измерения слайда?**

Координаты и размеры обычно указываются **in points**. Для предсказуемых результатов рассчитывайте их исходя из размеров слайда и преобразуйте необходимые миллиметры или дюймы в пункты перед присвоением значений.

**Как разместить эллипс выше или ниже других объектов (управление порядком наложения)?**

Отрегулируйте порядок отрисовки объекта, переместив его на передний план или отправив назад. Это позволяет эллипсу перекрывать другие объекты или раскрывать те, что находятся под ним.

**Как анимировать появление или акцентирование эллипса?**

[Apply](/slides/ru/php-java/shape-animation/) входные, акцентирующие или выходные эффекты к фигуре, настройте триггеры и тайминг, чтобы определить, когда и как будет воспроизводиться анимация.