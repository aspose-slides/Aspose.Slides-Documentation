---
title: Grup Şekli
type: docs
weight: 170
url: /tr/php-java/examples/elements/group-shape/
keywords:
- grup
- grup şekli ekle
- grup şekline eriş
- grup şeklini kaldır
- şekilleri gruptan çıkar
- kod örnekleri
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides kullanarak PHP'de grup şekilleriyle çalışın: oluşturun ve gruplamayı kaldırın, alt şekilleri yeniden sıralayın, PowerPoint ve OpenDocument'te dönüşümler ve sınırları ayarlayın."
---
Aspose.Slides for PHP via Java kullanarak şekil grupları oluşturma, bu gruplara erişme, gruplamayı kaldırma ve silme örnekleri.

## **Grup Şekli Ekle**

İki temel şekil içeren bir grup oluşturun.

```php
function addGroupShape() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $group = $slide->getShapes()->addGroupShape();
        $group->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);
        $group->getShapes()->addAutoShape(ShapeType::Ellipse, 60, 0, 50, 50);

        $presentation->save("group_shape.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Grup Şekline Erişim**

Bir slayttan ilk grup şeklini alın.

```php
function accessGroupShape() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Slayttaki ilk grup şekline eriş.
        $firstGroup = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $firstGroup = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Grup Şeklini Kaldır**

Grup şeklini slayttan silin.

```php
function removeGroupShape() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        
        // Slayd üzerindeki ilk şeklin bir grup şekli olduğunu varsayarak.
        $group = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($group);

        $presentation->save("group_shape_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Şekilleri Gruplamadan Çıkar**

Şekilleri grup kapsayıcısından dışarı taşıyın.

```php
function ungroupShapes() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Slayd üzerindeki ilk şeklin bir grup şekli olduğunu varsayarak.
        $group = $slide->getShapes()->get_Item(0);

        // Gruptan her şekli kopyalayıp slayta ekleyin.
        $shapeCount = java_values($group->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $group->getShapes()->get_Item($index);
            $slide->getShapes()->addClone($shape);
        }

        $slide->getShapes()->remove($group);

        $presentation->save("ungrouped_shapes.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```