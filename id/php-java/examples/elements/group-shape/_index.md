---
title: Bentuk Grup
type: docs
weight: 170
url: /id/php-java/examples/elements/group-shape/
keywords:
- grup
- tambah bentuk grup
- akses bentuk grup
- hapus bentuk grup
- bongkar bentuk
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Bekerja dengan bentuk grup di PHP menggunakan Aspose.Slides: membuat dan membongkar, mengatur ulang bentuk anak, mengatur transformasi dan batas di PowerPoint dan OpenDocument."
---
Contoh untuk membuat grup bentuk, mengaksesnya, membongkar grup, dan menghapusnya menggunakan **Aspose.Slides for PHP via Java**.

## **Add a Group Shape**

Buat grup yang berisi dua bentuk dasar.

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

## **Access a Group Shape**

Ambil bentuk grup pertama dari slide.

```php
function accessGroupShape() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Akses bentuk grup pertama pada slide.
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

## **Remove a Group Shape**

Hapus bentuk grup dari slide.

```php
function removeGroupShape() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        
        // Mengasumsikan bentuk pertama pada slide adalah bentuk grup.
        $group = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($group);

        $presentation->save("group_shape_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Ungroup Shapes**

Pindahkan bentuk keluar dari kontainer grup.

```php
function ungroupShapes() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Mengasumsikan bentuk pertama pada slide adalah bentuk grup.
        $group = $slide->getShapes()->get_Item(0);

        // Menggandakan setiap bentuk dari grup dan menambahkannya ke slide.
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