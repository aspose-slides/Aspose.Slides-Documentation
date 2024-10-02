---
title: Элипс
type: docs
weight: 30
url: /ru/php-java/ellipse/
---


{{% alert color="primary" %}} 

В этой теме мы ознакомим разработчиков с добавлением форм эллипса на их слайды с помощью Aspose.Slides для PHP через Java. Aspose.Slides для PHP через Java предоставляет более простой набор API для рисования различных видов фигур всего за несколько строк кода.

{{% /alert %}} 

## **Создание Элипса**
Чтобы добавить простой эллипс на выбранный слайд презентации, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте AutoShape типа Элипс, используя метод [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) объекта [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).
- Запишите измененную презентацию как файл PPTX.

В приведенном ниже примере мы добавили эллипс на первый слайд

```php
  # Создайте экземпляр класса Presentation, который представляет PPTX
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

## **Создание Форматированного Элипса**
Чтобы добавить лучше форматированный эллипс на слайд, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте AutoShape типа Элипс, используя метод [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) объекта [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).
- Установите тип заливки эллипса на Сплошной.
- Установите цвет эллипса, используя свойство SolidFillColor.Color, как это показано объектом [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IFillFormat), связанным с объектом [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape).
- Установите цвет линий эллипса.
- Установите ширину линий эллипса.
- Запишите измененную презентацию как файл PPTX.

В приведенном ниже примере мы добавили форматированный эллипс на первый слайд презентации.

```php
  # Создайте экземпляр класса Presentation, который представляет PPTX
  $pres = new Presentation();
  try {
    # Получите первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Добавьте AutoShape типа эллипс
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # Примените некоторые настройки к фигуре эллипса
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Chocolate));
    # Примените некоторые настройки к линии эллипса
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # Запишите файл PPTX на диск
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```