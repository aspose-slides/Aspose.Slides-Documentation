---
title: Bağlayıcı
type: docs
weight: 190
url: /tr/php-java/examples/elements/connector/
keywords:
- bağlayıcı
- bağlayıcı ekle
- bağlayıcıya erişim
- bağlayıcı kaldır
- şekilleri yeniden bağla
- kod örnekleri
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "PHP'de Aspose.Slides ile bağlayıcıları çizin ve kontrol edin: bağlayıcı ekleme, yönlendirme, yeniden yönlendirme, bağlantı noktalarını, okları ve stilleri ayarlayarak şekilleri PPT, PPTX ve ODP'de bağlayın."
---
Bağlayıcılarla şekilleri nasıl bağlayacağınızı ve hedeflerini **Aspose.Slides for PHP via Java** kullanarak nasıl değiştireceğinizi gösterir.

## **Bağlayıcı Ekle**

Slayttaki iki nokta arasına bir bağlayıcı şekli ekleyin.

```php
function addConnector() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $connector = $slide->Shapes->addConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

        $presentation->save("connector.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Bağlayıcıya Erişim**

Bir slayta eklenen ilk bağlayıcı şeklini alın.

```php
function accessConnector() {
    $presentation = new Presentation("connector.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Slayttaki ilk bağlayıcıya eriş.
        $firstConnector = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $firstConnector = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Bağlayıcıyı Kaldır**

Bağlayıcıyı slayttan silin.

```php
function removeConnector() {
    $presentation = new Presentation("connector.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Slayttaki ilk şeklin bir bağlayıcı olduğu varsayılıyor.
        $connector = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($connector);

        $presentation->save("connector_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Şekilleri Yeniden Bağla**

Başlangıç ve bitiş hedeflerini atayarak bir bağlayıcıyı iki şekle bağlayın.

```php
function reconnectShapes() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);
        $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 50, 50);
        $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

        $connector->setStartShapeConnectedTo($shape1);
        $connector->setEndShapeConnectedTo($shape2);

        $presentation->save("shapes_reconnected.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```