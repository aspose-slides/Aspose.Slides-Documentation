---
title: Tinta
type: docs
weight: 180
url: /id/php-java/examples/elements/ink/
keywords:
- tinta
- akses tinta
- hapus tinta
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Kelola tinta digital pada slide di PHP dengan Aspose.Slides: tambahkan goresan pena, edit jalur, atur warna dan lebar, serta ekspor hasil untuk PowerPoint dan OpenDocument."
---
Menyediakan contoh cara mengakses bentuk tinta yang ada dan menghapusnya menggunakan **Aspose.Slides for PHP via Java**.

> ❗ **Catatan:** Bentuk tinta mewakili input pengguna dari perangkat khusus. Aspose.Slides tidak dapat membuat goresan tinta baru secara programatis, tetapi Anda dapat membaca dan memodifikasi tinta yang ada.

## **Akses Tinta**

Dapatkan bentuk tinta pertama pada slide.

```php
function accessInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Akses bentuk tinta pertama pada slide.
        $firstInk = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Ink"))) {
                $firstInk = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Hapus Tinta**

Hapus sebuah bentuk tinta dari slide.

```php
function removeInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Asumsikan bahwa bentuk pertama pada slide adalah bentuk tinta.
        $ink = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($ink);

        $presentation->save("ink_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```