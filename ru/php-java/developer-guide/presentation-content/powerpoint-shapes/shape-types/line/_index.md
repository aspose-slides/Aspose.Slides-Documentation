---
title: Линия
type: docs
weight: 50
url: /ru/php-java/Line/
---


{{% alert color="primary" %}} 

Aspose.Slides для PHP через Java поддерживает добавление различных видов фигур на слайды. В этой теме мы начнем работу с фигурами, добавляя линии на слайды. С помощью Aspose.Slides для PHP через Java разработчики могут не только создавать простые линии, но и рисовать некоторые замысловатые линии на слайде.

{{% /alert %}} 

## **Создание простой линии**

Чтобы добавить простую линию на выбранный слайд презентации, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте фигуру типа линия с помощью метода [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) объекта [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).
- Запишите изменённую презентацию в файл PPTX.

В приведенном ниже примере мы добавили линию на первый слайд презентации.

```php
  # Создание экземпляра класса PresentationEx, представляющего файл PPTX
  $pres = new Presentation();
  try {
    # Получить первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Добавить фигуру типа линия
    $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Записать PPTX на диск
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Создание линии в форме стрелки**

Aspose.Slides для PHP через Java также позволяет разработчикам настраивать некоторые свойства линии, чтобы сделать её более привлекательной. Попробуем настроить несколько свойств линии, чтобы она выглядела как стрелка. Пожалуйста, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- Получите ссылку на слайд, используя его индекс.
- Добавьте фигуру типа линия с помощью метода [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) объекта [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection).
- Установите [Стиль линии](https://reference.aspose.com/slides/php-java/aspose.slides/LineStyle) на один из стилей, предоставляемых Aspose.Slides для PHP через Java.
- Установите ширину линии.
- Установите [Стиль штриха](https://reference.aspose.com/slides/php-java/aspose.slides/LineDashStyle) линии на один из стилей, предлагаемых Aspose.Slides для PHP через Java.
- Установите [Стиль наконечника стрелки](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadStyle) и [Длину](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadLength) начальной точки линии.
- Установите [Стиль наконечника стрелки](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadStyle) и [Длину](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadLength) конечной точки линии.
- Запишите изменённую презентацию в файл PPTX.

```php
  # Создание экземпляра класса PresentationEx, представляющего файл PPTX
  $pres = new Presentation();
  try {
    # Получить первый слайд
    $sld = $pres->getSlides()->get_Item(0);
    # Добавить фигуру типа линия
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Применить форматирование к линии
    $shp->getLineFormat()->setStyle(LineStyle->ThickBetweenThin);
    $shp->getLineFormat()->setWidth(10);
    $shp->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $shp->getLineFormat()->setBeginArrowheadLength(LineArrowheadLength->Short);
    $shp->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle->Oval);
    $shp->getLineFormat()->setEndArrowheadLength(LineArrowheadLength->Long);
    $shp->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Maroon));
    # Записать PPTX на диск
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```