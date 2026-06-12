---
title: SmartArt
type: docs
weight: 140
url: /id/php-java/examples/elements/smartart/
keywords:
- SmartArt
- tambahkan SmartArt
- akses SmartArt
- hapus SmartArt
- tata letak SmartArt
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Buat dan edit SmartArt di PHP dengan Aspose.Slides: tambahkan node, ubah tata letak dan gaya, konversi menjadi bentuk dengan presisi, dan ekspor ke PPT, PPTX, dan ODP."
---
Menampilkan cara menambahkan grafik SmartArt, mengaksesnya, menghapusnya, dan mengubah tata letak menggunakan **Aspose.Slides for PHP via Java**.

## **Tambah SmartArt**

Menyisipkan grafik SmartArt menggunakan salah satu tata letak bawaan.

```php
function addSmartArt() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $smart = $slide->getShapes()->addSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

        $presentation->save("smart_art.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Akses SmartArt**

Mengambil objek SmartArt pertama pada slide.

```php
function accessSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Akses SmartArt pertama pada slide.
        $firstSmartArt = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
                $firstSmartArt = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Hapus SmartArt**

Menghapus shape SmartArt dari slide.

```php
function removeSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Mengasumsikan bahwa shape pertama pada slide adalah SmartArt.
        $smartArt = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($smartArt);

        $presentation->save("smart_art_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Ubah Tata Letak SmartArt**

Memperbarui jenis tata letak grafik SmartArt yang ada.

```php
function changeSmartArtLayout() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Mengasumsikan bahwa shape pertama pada slide adalah SmartArt.
        $smartArt = $slide->getShapes()->get_Item(0);

        // Ubah tata letak SmartArt.
        $smartArt->setLayout(SmartArtLayoutType::VerticalPictureList);

        $presentation->save("smart_art_layout_changed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```