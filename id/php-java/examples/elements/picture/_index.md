---
title: Gambar
type: docs
weight: 50
url: /id/php-java/examples/elements/picture/
keywords:
- gambar
- bingkai gambar
- menambahkan gambar
- mengakses gambar
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Bekerja dengan gambar di PHP menggunakan Aspose.Slides: menyisipkan, mengganti, memotong, mengompres, menyesuaikan transparansi dan efek, mengisi bentuk, serta mengekspor ke PPT, PPTX, dan ODP."
---
Menunjukkan cara menyisipkan dan mengakses gambar menggunakan **Aspose.Slides for PHP via Java**. Contoh di bawah menempatkan gambar pada slide, lalu mengambilnya.

## **Menambahkan Gambar**

Kode ini menyisipkan gambar sebagai bingkai gambar pada slide pertama.

```php
function addPicture() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $image = $presentation->getImages()->addImage(
            new Java("java.io.FileInputStream", new Java("java.io.File", "image.jpg")));

        // Tambahkan gambar ke sumber daya presentasi.
        $ppImage = $presentation->getImages()->addImage($image);

        // Sisipkan bingkai gambar yang menampilkan gambar pada slide pertama.
        $slide->getShapes()->addPictureFrame(
            ShapeType::Rectangle, 50, 50, $ppImage->getWidth(), $ppImage->getHeight(), $ppImage);

        $presentation->save("picture.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Mengakses Gambar**

Contoh ini memastikan slide berisi bingkai gambar dan kemudian mengakses yang pertama ditemukan.

```php
function accessPicture() {
    $presentation = new Presentation("picture.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Akses PictureFrame pertama pada slide.
        $firstPictureFrame = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $firstPictureFrame = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```