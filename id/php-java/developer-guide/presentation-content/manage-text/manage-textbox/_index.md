---
title: Kelola Kotak Teks dalam Presentasi Menggunakan PHP
linktitle: Kelola Kotak Teks
type: docs
weight: 20
url: /id/php-java/manage-textbox/
keywords:
- kotak teks
- bingkai teks
- menambahkan teks
- memperbarui teks
- buat kotak teks
- periksa kotak teks
- tambahkan kolom teks
- tambahkan tautan hiper
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Buat, identifikasi, format, dan perbarui kotak teks dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk PHP via Java."
---
## **Pendahuluan**

Dalam Aspose.Slides untuk PHP via Java, teks slide disimpan dalam bingkai teks yang menjadi bagian dari bentuk. Kelas [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) mewakili bentuk paling umum yang berisi teks dan mengekspose teksnya melalui metode [AutoShape::getTextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/#getTextFrame).

{{% alert color="info" title="Note" %}}

Setiap auto shape diturunkan dari [Shape](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/), tetapi tidak setiap shape adalah auto shape atau mendukung bingkai teks. Saat memproses presentasi yang sudah ada, gunakan `java_instanceof` untuk memeriksa bahwa sebuah shape merupakan [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) sebelum mengakses teksnya.

{{% /alert %}}

## **Buat Kotak Teks pada Slide**

Untuk membuat kotak teks, tambahkan auto shape ke slide, tambahkan teks ke bingkai teksnya, dan simpan presentasi. Contoh berikut membuat kotak teks berbentuk persegi panjang:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 300, 50);
    $textBox->addTextFrame("Aspose TextBox");

    $presentation->save("TextBox.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Koordinat dan dimensi yang diberikan ke [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/#addAutoShape) diukur dalam poin. [AutoShape::addTextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/#addTextFrame) menginisialisasi bingkai teks dengan teks yang diberikan.

## **Periksa apakah Bentuk adalah Kotak Teks**

Gunakan metode [AutoShape::isTextBox](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/#isTextBox) untuk menentukan apakah sebuah auto shape diperlakukan sebagai kotak teks. Hal ini berguna ketika sebuah presentasi berisi baik auto shape yang berisi teks maupun yang hanya grafis.

![Kotak teks dan sebuah bentuk](istextbox.png)

Contoh berikut memeriksa setiap auto shape dalam sebuah presentasi:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 120, 40);
    $textBox->addTextFrame("Text box");
    $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 150, 10, 40, 40);

    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $currentSlide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($currentSlide->getShapes()->size()); $shapeIndex++) {
            $shape = $currentSlide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, $autoShapeClass)) {
                echo (java_is_true($shape->isTextBox()) ? "The shape is a text box." : "The shape is not a text box.") . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Sebuah auto shape yang baru ditambahkan tidak dianggap sebagai kotak teks sampai ia berisi teks yang tidak kosong. Anda dapat menyediakan teks tersebut melalui [AutoShape::addTextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/#addTextFrame) atau [TextFrame::setText](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/#setText). Menambahkan atau menetapkan string kosong membuat [AutoShape::isTextBox](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/#isTextBox) mengembalikan `false`:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
    $shape1->addTextFrame("Shape 1");
    echo (java_is_true($shape1->isTextBox()) ? "true" : "false") . PHP_EOL;

    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 100, 40);
    $shape2->getTextFrame()->setText("Shape 2");
    echo (java_is_true($shape2->isTextBox()) ? "true" : "false") . PHP_EOL;

    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 100, 40);
    $shape3->addTextFrame("");
    echo (java_is_true($shape3->isTextBox()) ? "true" : "false") . PHP_EOL;

    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 100, 40);
    $shape4->getTextFrame()->setText("");
    echo (java_is_true($shape4->isTextBox()) ? "true" : "false") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Dua pemanggilan pertama mencetak `true`; dua pemanggilan terakhir mencetak `false`.

## **Temukan Bentuk yang Memiliki Bingkai Teks**

Kode pemrosesan teks generik mungkin menerima sebuah [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/) tanpa mengetahui objek presentasi mana yang memuatnya. Gunakan metode read-only [TextFrame::getParentShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/#getParentShape) untuk menavigasi kembali ke [Shape](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/) pemiliknya.

Untuk bingkai teks yang dimiliki oleh sebuah auto shape atau bentuk lain yang berisi teks, [TextFrame::getParentShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/#getParentShape) mengembalikan pemiliknya dan [TextFrame::getParentCell](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/#getParentCell) mengembalikan `null`. Periksa nilai yang dikembalikan dengan `java_is_null` sebelum mengaksesnya. Untuk mengidentifikasi baik pemilik bentuk maupun sel tabel, termasuk bentuk yang terkait dengan node SmartArt, lihat [Search and Replace Text](/slides/id/php-java/search-and-replace-text/).

## **Tambahkan Kolom ke Kotak Teks**

Metode [TextFrameFormat::setColumnCount](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframeformat/#setColumnCount) membagi bingkai teks menjadi beberapa kolom, sementara [TextFrameFormat::setColumnSpacing](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframeformat/#setColumnSpacing) mengatur jarak antar kolom dalam poin. Kedua pengaturan ini merupakan bagian dari [TextFrameFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframeformat/) dan dapat diubah melalui bingkai teks dari kotak teks yang sudah ada. Teks akan mengalir kembali di antara kolom dalam bentuk yang sama; teks tidak akan berlanjut ke bentuk lain.

Contoh berikut membuat kotak teks tiga kolom dengan jarak 10 poin antar kolom, menyimpan presentasi, dan membaca kembali pengaturan yang disimpan dari file output:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 200);
    $textBox->addTextFrame("This text is distributed automatically across all columns in the text box.");

    $textFrameFormat = $textBox->getTextFrame()->getTextFrameFormat();
    $textFrameFormat->setColumnCount(3);
    $textFrameFormat->setColumnSpacing(10);

    $presentation->save("TextBoxColumns.pptx", SaveFormat::Pptx);

    $savedPresentation = new Presentation("TextBoxColumns.pptx");
    try {
        $savedTextBox = $savedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedFormat = $savedTextBox->getTextFrame()->getTextFrameFormat();
        echo "Columns: " . java_values($savedFormat->getColumnCount()) . "; spacing: " . java_values($savedFormat->getColumnSpacing()) . " points" . PHP_EOL;
    } finally {
        $savedPresentation->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Ekstrak Teks dari Kolom Individu**

Gunakan [TextFrame::splitTextByColumns](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/#splitTextByColumns) untuk mengambil teks yang ditetapkan pada tiap kolom visual dalam bingkai teks yang ada. Metode ini mengembalikan satu string untuk setiap kolom, dalam urutan baca berbasis kolom. Bingkai teks satu kolom menghasilkan array dengan satu elemen, dan kolom kosong direpresentasikan dengan string kosong. String yang dikembalikan hanya berisi teks biasa; format tingkat bagian tidak dipertahankan.

Hal ini berguna ketika Anda perlu:

- Mengekstrak teks sambil mempertahankan urutan baca berbasis kolom.
- Mengindeks atau membandingkan konten slide multi‑kolom.
- Mengekspor tiap kolom ke file terpisah, field basis data, atau tujuan lainnya.
- Memeriksa bagaimana teks didistribusikan kembali setelah mengubah jumlah kolom dengan [TextFrameFormat::setColumnCount](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframeformat/#setColumnCount), jarak dengan [TextFrameFormat::setColumnSpacing](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframeformat/#setColumnSpacing), font, atau ukuran bingkai teks.

Metode ini melaporkan teks yang didistribusikan dalam [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/) saat ini; ia tidak secara otomatis mengalirkan teks antar bentuk atau kotak teks terpisah. Distribusi kolom dapat dipengaruhi oleh font yang tersedia dan pengaturan tata letak teks lainnya, jadi pastikan font yang diperlukan tersedia ketika konsistensi hasil penting.

Contoh berikut memuat sebuah presentasi, menemukan auto shape multi‑kolom pertama dengan bingkai teks, membaca jumlah kolom yang dikonfigurasi, dan menulis teks dari tiap kolom ke file terpisah. Bentuk yang tidak menyediakan bingkai teks dilewati.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("MultiColumnText.pptx");
try {
    $textBox = null;
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (java_instanceof($shape, $autoShapeClass)) {
            $textFrame = $shape->getTextFrame();
            if (!java_is_null($textFrame)) {
                $columnCount = java_values($textFrame->getTextFrameFormat()->getColumnCount());
                if ($columnCount > 1) {
                    $textBox = $shape;
                    break;
                }
            }
        }
    }

    if ($textBox === null) {
        echo "No multi-column text frame was found." . PHP_EOL;
    } else {
        $textFrame = $textBox->getTextFrame();
        $configuredColumnCount = java_values($textFrame->getTextFrameFormat()->getColumnCount());
        $columnTexts = java_values($textFrame->splitTextByColumns());

        echo "Configured columns: " . $configuredColumnCount . PHP_EOL;

        foreach ($columnTexts as $columnIndex => $columnText) {
            $columnNumber = $columnIndex + 1;
            echo "Column " . $columnNumber . ": " . $columnText . PHP_EOL;
            $outputPath = "Column-" . $columnNumber . ".txt";
            $bytesWritten = file_put_contents($outputPath, $columnText);
            if ($bytesWritten === false) {
                echo "Could not write column " . $columnNumber . " to " . $outputPath . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Perbarui Teks**

Untuk memperbarui teks di seluruh presentasi, iterasikan melalui slide dan bentuk, pilih auto shape, kemudian edit bagian teksnya. Bekerja pada tingkat bagian memungkinkan Anda mengubah baik teks maupun format karakter.

Contoh berikut menggantikan setiap kemunculan `years` dengan `months` dalam teks auto‑shape dan membuat setiap bagian yang terpengaruh menjadi tebal:

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Text.pptx");
try {
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }

            $textFrame = $shape->getTextFrame();
            if (java_is_null($textFrame)) {
                continue;
            }

            for ($paragraphIndex = 0; $paragraphIndex < java_values($textFrame->getParagraphs()->getCount()); $paragraphIndex++) {
                $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                for ($portionIndex = 0; $portionIndex < java_values($paragraph->getPortions()->getCount()); $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    $text = java_values($portion->getText());
                    if ($text !== null && strpos($text, "years") !== false) {
                        $updatedText = str_replace("years", "months", $text);
                        $portion->setText($updatedText);
                        $portion->getPortionFormat()->setFontBold(NullableBool::True);
                    }
                }
            }
        }
    }

    $presentation->save("TextChanged.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Traversing ini memperbarui teks hanya pada auto shape. Teks yang disimpan dalam tabel, diagram, SmartArt, atau bentuk yang dikelompokkan memerlukan traversing koleksi masing‑masing objek tersebut.

## **Tambahkan Kotak Teks dengan Tautan Hiper**

Sebuah tautan hiper dapat ditetapkan ke bagian teks tertentu, sehingga hanya teks tersebut yang bertindak sebagai tautan yang dapat diklik. Gunakan [HyperlinkManager::setExternalHyperlinkClick](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick) untuk mengaitkan bagian tersebut dengan URL eksternal.

Contoh berikut membuat teks bertautan dan menyimpannya ke dalam presentasi:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 200, 50);
    $textBox->addTextFrame("Aspose.Slides");

    $textPortion = $textBox->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $textPortion->getPortionFormat()->getHyperlinkManager()->setExternalHyperlinkClick("https://www.aspose.com/");

    $presentation->save("Hyperlink.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Apa perbedaan antara kotak teks dan placeholder teks pada slide master atau layout?**

Sebuah [placeholder](/slides/id/php-java/manage-placeholder/) dapat mewarisi posisi dan formatnya dari sebuah [master slide](https://reference.aspose.com/slides/id/php-java/aspose.slides/masterslide/) atau [layout slide](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutslide/). Kotak teks biasa merupakan bentuk independen pada slide tempat ia dibuat dan tidak memperoleh perilaku placeholder ketika tata letak berubah.

**Bagaimana cara mengganti teks tanpa mengubah teks dalam diagram, tabel, atau SmartArt?**

Batasi traversing hanya pada objek [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) seperti yang ditunjukkan pada contoh Perbarui Teks. Diagram, tabel, dan SmartArt menyimpan teks dalam model objek masing‑masing, sehingga tidak akan dimodifikasi oleh loop tersebut.