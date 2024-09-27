---
title: Прямоугольник
type: docs
weight: 80
url: /ru/php-java/rectangle/
---

{{% alert color="primary" %}} 

Как и в предыдущих темах, эта тема также посвящена добавлению фигуры, и на этот раз мы обсудим фигуру **Прямоугольник**. В этой теме мы описали, как разработчики могут добавлять простые или оформленные прямоугольники на свои слайды с помощью Aspose.Slides для PHP через Java.

{{% /alert %}} 

## **Добавить Прямоугольник на Слайд**
Чтобы добавить простой прямоугольник на выбранный слайд презентации, пожалуйста, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) типа Прямоугольник с помощью метода [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) объекта [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).
- Запишите измененную презентацию в файл PPTX.

В приведенном ниже примере мы добавили простой прямоугольник на первый слайд презентации.

```php
  # Экземпляр класса Presentation, представляющего PPTX
  $pres = new Presentation();
  try {
    # Получите первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Добавьте AutoShape типа прямоугольник
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # Запишите файл PPTX на диск
    $pres->save("RecShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Добавить Оформленный Прямоугольник на Слайд**
Чтобы добавить оформленный прямоугольник на слайд, пожалуйста, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) типа Прямоугольник с помощью метода [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) объекта [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).
- Установите [Тип Заливки](https://reference.aspose.com/slides/php-java/aspose.slides/FillType) Прямоугольника в Сплошной.
- Установите Цвет Прямоугольника с помощью метода [SolidFillColor.setColor](https://reference.aspose.com/slides/php-java/aspose.slides/IColorFormat#setColor-java.awt.Color-) объекта [IFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IFillFormat), связанного с объектом [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape).
- Установите Цвет линий Прямоугольника.
- Установите Ширину линий Прямоугольника.
- Запишите измененную презентацию в файл PPTX.

Вышеуказанные шаги реализованы в приведенном ниже примере.

```php
  # Экземпляр класса Presentation, представляющего PPTX
  $pres = new Presentation();
  try {
    # Получите первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Добавьте AutoShape типа прямоугольник
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # Примените некоторые форматы к фигуре прямоугольника
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    # Примените некоторые форматы к линиям Прямоугольника
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # Запишите файл PPTX на диск
    $pres->save("RecShp2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```