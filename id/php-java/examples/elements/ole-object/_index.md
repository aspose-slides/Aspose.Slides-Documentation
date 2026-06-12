---
title: Objek OLE
type: docs
weight: 210
url: /id/php-java/examples/elements/ole-object/
keywords:
- objek OLE
- tambahkan objek OLE
- akses objek OLE
- hapus objek OLE
- perbarui objek OLE
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Bekerja dengan objek OLE di PHP menggunakan Aspose.Slides: sisipkan atau perbarui file yang disematkan, atur ikon atau tautan, ekstrak konten, kontrol perilaku untuk PPT, PPTX, dan ODP."
---
Menunjukkan cara menyisipkan file sebagai objek OLE dan memperbarui datanya menggunakan **Aspose.Slides for PHP via Java**.

## **Tambahkan Objek OLE**

Sematkan file PDF ke dalam presentasi.

```php
function addOleObject() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $pdfData = new OleEmbeddedDataInfo(file_get_contents("doc.pdf"), "pdf");
        $oleFrame = $slide->getShapes()->addOleObjectFrame(20, 20, 50, 50, $pdfData);

        $presentation->save("ole_object.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Akses Objek OLE**

Ambil frame objek OLE pertama pada slide.

```php
function accessOleObject() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Akses frame OLE pertama pada slide.
        $firstOleFrame = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
                $firstOleFrame = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Hapus Objek OLE**

Hapus objek OLE yang disematkan dari slide.

```php
function removeOleObject() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Mengasumsikan bahwa shape pertama pada slide adalah frame OLE.
        $oleFrame = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($oleFrame);

        $presentation->save("ole_object_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Perbarui Data Objek OLE**

Ganti data yang disematkan dalam objek OLE yang ada.

```php
function updateOleObjectData() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Mengasumsikan bahwa shape pertama pada slide adalah frame OLE.
        $oleFrame = $slide->getShapes()->get_Item(0);

        $newData = new OleEmbeddedDataInfo(file_get_contents("picture.png"), "png");
        $oleFrame->setEmbeddedData($newData);

        $presentation->save("ole_object_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```