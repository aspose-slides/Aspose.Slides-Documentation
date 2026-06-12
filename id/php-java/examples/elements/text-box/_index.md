---
title: Kotak Teks
type: docs
weight: 40
url: /id/php-java/examples/elements/text-box/
keywords:
- kotak teks
- menambahkan kotak teks
- mengakses kotak teks
- menghapus kotak teks
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Buat dan format kotak teks di PHP dengan Aspose.Slides: atur font, perataan, pembungkus, autofit, dan tautan untuk memoles slide untuk PowerPoint dan OpenDocument."
---
Di Aspose.Slides, **text box** direpresentasikan oleh sebuah `AutoShape`. Hampir semua bentuk dapat berisi teks, tetapi kotak teks tipikal tidak memiliki isian atau batas dan hanya menampilkan teks.

Panduan ini menjelaskan cara menambahkan, mengakses, dan menghapus kotak teks secara programatik.

## **Menambahkan Kotak Teks**

Kotak teks hanyalah `AutoShape` tanpa isian atau batas dan dengan beberapa teks yang diformat. Berikut cara membuatnya:

```php
function addTextBox() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Buat bentuk persegi panjang (default terisi dengan border dan tidak ada teks).
        // Hapus isian dan border agar terlihat seperti kotak teks tipikal.
        // Atur format teks.
        // Tetapkan konten teks yang sebenarnya.
        $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 75, 150, 100);

        // Remove fill and border to make it look like a typical text box.
        $textBox->getFillFormat()->setFillType(FillType::NoFill);
        $textBox->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        // Set text formatting.
        $paragraph = $textBox->getTextFrame()->getParagraphs()->get_Item(0);
        $portionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
        $portionFormat->getFillFormat()->setFillType(FillType::Solid);
        $portionFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

        // Assign the actual text content.
        $textBox->getTextFrame()->setText("Some text...");

        $presentation->save("text_box.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Catatan:** Setiap `AutoShape` yang berisi `TextFrame` tidak kosong dapat berfungsi sebagai kotak teks.

## **Mengakses Kotak Teks Berdasarkan Konten**

Untuk menemukan semua kotak teks yang berisi kata kunci tertentu (mis. "Slide"), iterasi melalui bentuk-bentuk dan periksa teksnya:

```php
function accessTextBox() {
    $presentation = new Presentation("text_box.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Akses kotak teks pertama pada slide.
        $firstTextBox = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $firstTextBox = $shape;
                if (strpos($firstTextBox->getTextFrame()->getText(), "Slide") !== false) {
                    // Lakukan sesuatu dengan kotak teks yang cocok.
                }
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Menghapus Kotak Teks Berdasarkan Konten**

Contoh ini menemukan dan menghapus semua kotak teks pada slide pertama yang berisi kata kunci tertentu:

```php
function removeTextBoxes() {
    $presentation = new Presentation("text_box.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shapesToRemove = [];

        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $autoShape = $shape;
                if (strpos($autoShape->getTextFrame()->getText(), "Slide") !== false) {
                    $shapesToRemove[] = $shape;
                }
            }
        }

        foreach ($shapesToRemove as $shape) {
            $slide->getShapes()->remove($shape);
        }

        $presentation->save("text_boxes_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Tip:** Selalu buat salinan koleksi bentuk sebelum memodifikasinya selama iterasi untuk menghindari kesalahan modifikasi koleksi.