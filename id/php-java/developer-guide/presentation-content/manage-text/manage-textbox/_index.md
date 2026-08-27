---
title: Kelola Kotak Teks dalam Presentasi Menggunakan PHP
linktitle: Kelola Kotak Teks
type: docs
weight: 20
url: /id/php-java/manage-textbox/
keywords:
- kotak teks
- frame teks
- tambahkan teks
- perbarui teks
- buat kotak teks
- periksa kotak teks
- tambahkan kolom teks
- tambahkan hyperlink
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Aspose.Slides untuk PHP memudahkan pembuatan, penyuntingan, dan penyalinan kotak teks dalam file PowerPoint dan OpenDocument, meningkatkan otomatisasi presentasi Anda."
---
## **Pengantar**

Teks pada slide biasanya berada di dalam kotak teks atau bentuk. Oleh karena itu, untuk menambahkan teks ke sebuah slide, Anda harus menambahkan kotak teks dan kemudian menempatkan beberapa teks di dalam kotak teks tersebut. Aspose.Slides for PHP via Java menyediakan kelas [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) yang memungkinkan Anda menambahkan bentuk yang berisi teks.

{{% alert title="Info" color="info" %}}

Aspose.Slides juga menyediakan kelas [Shape](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/) yang memungkinkan Anda menambahkan bentuk ke slide. Namun, tidak semua bentuk yang ditambahkan melalui kelas `Shape` dapat menampung teks. Tetapi bentuk yang ditambahkan melalui kelas [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) dapat berisi teks.

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Karena itu, ketika berurusan dengan bentuk yang ingin Anda tambahkan teks, Anda mungkin perlu memeriksa dan memastikan bahwa bentuk tersebut di‑cast melalui kelas `AutoShape`. Hanya dengan begitu Anda akan dapat bekerja dengan [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/), yang merupakan properti pada `AutoShape`. Lihat bagian [Update Text](/slides/id/php-java/manage-textbox/#update-text) pada halaman ini.

{{% /alert %}}

## **Buat Kotak Teks pada Slide**

Untuk membuat kotak teks pada slide, ikuti langkah‑langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/).
2. Dapatkan referensi untuk slide pertama dalam presentasi yang baru dibuat. 
3. Tambahkan objek [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) dengan jenis bentuk diatur sebagai [Rectangle](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapetype/#Rectangle) pada posisi yang ditentukan di slide dan dapatkan referensi untuk objek `AutoShape` yang baru ditambahkan.
4. Tambahkan `TextFrame` ke objek `AutoShape` yang akan berisi teks. Pada contoh di bawah, kami menambahkan teks berikut: *Aspose TextBox*
5. Akhirnya, tulis file PPTX melalui objek `Presentation`. 

Kode PHP ini—implementasi dari langkah‑langkah di atas—menunjukkan cara menambahkan teks ke slide:

```php
  # Membuat instance Presentation
  $pres = new Presentation();
  try {
    # Mendapatkan slide pertama dalam presentasi
    $sld = $pres->getSlides()->get_Item(0);
    # Menambahkan AutoShape dengan tipe diatur sebagai Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Menambahkan TextFrame ke Rectangle
    $ashp->addTextFrame(" ");
    # Mengakses text frame
    $txtFrame = $ashp->getTextFrame();
    # Membuat objek Paragraph untuk text frame
    $para = $txtFrame->getParagraphs()->get_Item(0);
    # Membuat objek Portion untuk paragraph
    $portion = $para->getPortions()->get_Item(0);
    # Mengatur Teks
    $portion->setText("Aspose TextBox");
    # Menyimpan presentasi ke disk
    $pres->save("TextBox_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Periksa Bentuk Kotak Teks**

Aspose.Slides menyediakan metode [isTextBox](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/istextbox/) dari kelas [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) yang memungkinkan Anda memeriksa bentuk dan mengidentifikasi kotak teks.

![Text box and shape](istextbox.png)

Kode PHP ini menunjukkan cara memeriksa apakah sebuah bentuk dibuat sebagai kotak teks:

```php
class ShapeCallback {
    function invoke($shape, $slide, $index) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
            $autoShape = $shape;
            echo(java_is_true($autoShape->isTextBox()) ? "shape is a text box" : "shape is not a text box");
        }
    }
}

$presentation = new Presentation("sample.pptx");
try {
    $forEachShapeCallback = java_closure(new ShapeCallback(), null, java("com.aspose.slides.ForEachShapeCallback"));
    ForEach_::shape($presentation, $forEachShapeCallback);
} finally {
    $presentation->dispose();
}
```

Perhatikan bahwa jika Anda hanya menambahkan sebuah autoshape menggunakan metode `addAutoShape` dari kelas [ShapeCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/), metode `isTextBox` pada autoshape akan mengembalikan `false`. Namun, setelah Anda menambahkan teks ke autoshape menggunakan metode `addTextFrame` atau metode `setText`, properti `isTextBox` akan mengembalikan `true`.

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->isTextBox() mengembalikan false
$shape1->addTextFrame("shape 1");
// shape1->isTextBox() mengembalikan true

$shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->isTextBox() mengembalikan false
$shape2->getTextFrame()->setText("shape 2");
// shape2->isTextBox() mengembalikan true

$shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->isTextBox() mengembalikan false
$shape3->addTextFrame("");
// shape3->isTextBox() mengembalikan false

$shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->isTextBox() mengembalikan false
$shape4->getTextFrame()->setText("");
// shape4->isTextBox() mengembalikan false
```

## **Temukan Bentuk yang Memiliki TextFrame**

Dalam kode pemrosesan teks umum, Anda mungkin menerima sebuah [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/) tanpa mengetahui sebelumnya objek presentasi mana yang menampungnya. Gunakan metode [TextFrame::getParentShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/#getParentShape) untuk menavigasi kembali ke [Shape](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/) pemiliknya.

Untuk sebuah text frame yang tergabung dalam sebuah [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) atau bentuk lain yang berisi teks, [TextFrame::getParentShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/#getParentShape) mengembalikan pemiliknya dan [TextFrame::getParentCell](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/#getParentCell) mengembalikan `null`. Kedua metode menyediakan navigasi read‑only, sehingga pemanggilannya tidak mengubah kepemilikan. Selalu periksa nilai yang dikembalikan dengan `java_is_null` sebelum mengakses bentuk.

Untuk contoh lengkap yang mengidentifikasi pemilik bentuk dan sel‑tabel, termasuk bentuk yang terkait dengan node SmartArt, lihat [Search and Replace Text](/slides/id/php-java/search-and-replace-text/).

## **Tambahkan Kolom ke Kotak Teks**

Aspose.Slides menyediakan metode [setColumnCount](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframeformat/setcolumncount/) dan [setColumnSpacing](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframeformat/setcolumnspacing/) dari kelas [TextFrameFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframeformat/) yang memungkinkan Anda menambahkan kolom ke kotak teks. Anda dapat menentukan jumlah kolom dalam kotak teks dan mengatur jarak spasi dalam poin antar kolom.

Kode berikut memperlihatkan operasi yang dijelaskan:

```php
  $pres = new Presentation();
  try {
    # Mendapatkan slide pertama dalam presentasi
    $slide = $pres->getSlides()->get_Item(0);
    # Menambahkan AutoShape dengan tipe diatur sebagai Rectangle
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Menambahkan TextFrame ke Rectangle
    $aShape->addTextFrame("All these columns are limited to be within a single text container -- " . "you can add or delete text and the new or remaining text automatically adjusts " . "itself to flow within the container. You cannot have text flow from one container " . "to other though -- we told you PowerPoint's column options for text are limited!");
    # Mendapatkan format teks dari TextFrame
    $format = $aShape->getTextFrame()->getTextFrameFormat();
    # Menentukan jumlah kolom dalam TextFrame
    $format->setColumnCount(3);
    # Menentukan jarak spasi antar kolom
    $format->setColumnSpacing(10);
    # Menyimpan presentasi
    $pres->save("ColumnCount.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Tambahkan Kolom ke TextFrame**

Aspose.Slides for PHP via Java menyediakan metode [setColumnCount](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframeformat/setcolumncount/) dari kelas [TextFrameFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframeformat/) yang memungkinkan Anda menambahkan kolom dalam text frame. Melalui properti ini, Anda dapat menentukan jumlah kolom yang diinginkan dalam sebuah text frame.

Kode PHP ini menunjukkan cara menambahkan kolom di dalam text frame:

```php
  $outPptxFileName = "ColumnsTest.pptx";
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    $format = $shape1->getTextFrame()->getTextFrameFormat();
    $format->setColumnCount(2);
    $shape1->getTextFrame()->setText("All these columns are forced to stay within a single text container -- " . "you can add or delete text - and the new or remaining text automatically adjusts " . "itself to stay within the container. You cannot have text spill over from one container " . "to other, though -- because PowerPoint's column options for text are limited!");
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test = new Presentation($outPptxFileName);
    try {
      $autoShape = $test->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(2 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(Double->NaN == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test)) {
        $test->dispose();
      }
    }
    $format->setColumnSpacing(20);
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test1 = new Presentation($outPptxFileName);
    try {
      $autoShape = $test1->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(2 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(20 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test1)) {
        $test1->dispose();
      }
    }
    $format->setColumnCount(3);
    $format->setColumnSpacing(15);
    $pres->save($outPptxFileName, SaveFormat::Pptx);
    $test2 = new Presentation($outPptxFileName);
    try {
      $autoShape = $test2->getSlides()->get_Item(0)->getShapes()->get_Item(0);
      Assert->assertTrue(3 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnCount());
      Assert->assertTrue(15 == $autoShape->getTextFrame()->getTextFrameFormat()->getColumnSpacing());
    } finally {
      if (!java_is_null($test2)) {
        $test2->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Perbarui Teks**

Aspose.Slides memungkinkan Anda mengubah atau memperbarui teks yang terdapat dalam kotak teks atau semua teks yang terdapat dalam sebuah presentasi. 

Kode PHP ini memperlihatkan operasi di mana semua teks dalam presentasi diperbarui atau diubah:

```php
  $pres = new Presentation("text.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        # Memeriksa apakah shape mendukung text frame (IAutoShape).
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $autoShape = $shape;
          # Mengiterasi paragraf dalam text frame
          foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
            # Mengiterasi setiap portion dalam paragraf
            foreach($paragraph->getPortions() as $portion) {
              $portion->setText($portion->getText()->replace("years", "months"));// Mengubah teks

              $portion->getPortionFormat()->setFontBold(NullableBool::True);// Mengubah format

            }
          }
        }
      }
    }
    # Menyimpan presentasi yang telah diubah
    $pres->save("text-changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Tambahkan Kotak Teks dengan Hyperlink** 

Anda dapat menyisipkan tautan di dalam kotak teks. Ketika kotak teks diklik, pengguna akan diarahkan untuk membuka tautan tersebut. 

Untuk menambahkan kotak teks yang berisi tautan, ikuti langkah‑langkah berikut:

1. Buat instance kelas `Presentation`. 
2. Dapatkan referensi untuk slide pertama dalam presentasi yang baru dibuat. 
3. Tambahkan objek `AutoShape` dengan `ShapeType` diatur sebagai `Rectangle` pada posisi yang ditentukan di slide dan dapatkan referensi objek `AutoShape` yang baru ditambahkan.
4. Tambahkan `TextFrame` ke objek `AutoShape` yang berisi *Aspose TextBox* sebagai teks defaultnya. 
5. Instansiasi kelas `HyperlinkManager`. 
6. Tetapkan hyperlink menggunakan metode [setExternalHyperlinkClick](https://reference.aspose.com/slides/id/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/) yang terkait dengan bagian `TextFrame` yang Anda inginkan. 
7. Akhirnya, tulis file PPTX melalui objek `Presentation`. 

Kode PHP ini—implementasi dari langkah‑langkah di atas—menunjukkan cara menambahkan kotak teks dengan hyperlink ke slide:

```php
  # Membuat instance kelas Presentation yang merepresentasikan PPTX
  $pres = new Presentation();
  try {
    # Mendapatkan slide pertama dalam presentasi
    $slide = $pres->getSlides()->get_Item(0);
    # Menambahkan objek AutoShape dengan tipe diatur sebagai Rectangle
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 150, 50);
    # Meng-cast shape menjadi AutoShape
    $pptxAutoShape = $shape;
    # Mengakses properti ITextFrame yang terkait dengan AutoShape
    $pptxAutoShape->addTextFrame("");
    $textFrame = $pptxAutoShape->getTextFrame();
    # Menambahkan teks ke dalam frame
    $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->setText("Aspose.Slides");
    # Menetapkan Hyperlink untuk teks portion
    $hyperlinkManager = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getHyperlinkManager();
    $hyperlinkManager->setExternalHyperlinkClick("http://www.aspose.com");
    # Menyimpan Presentasi PPTX
    $pres->save("hLink_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Apa perbedaan antara kotak teks dan placeholder teks saat bekerja dengan slide master?**

Sebuah [placeholder](/slides/id/php-java/manage-placeholder/) mewarisi gaya/posisi dari [master](https://reference.aspose.com/slides/id/php-java/aspose.slides/masterslide/) dan dapat ditimpa pada [layout](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutslide/), sedangkan kotak teks biasa merupakan objek independen pada slide tertentu dan tidak berubah ketika Anda beralih layout.

**Bagaimana cara melakukan penggantian teks massal di seluruh presentasi tanpa menyentuh teks di dalam bagan, tabel, dan SmartArt?**

Batasi iterasi Anda hanya pada auto‑shape yang memiliki text frame dan kecualikan objek tertanam (bagan, tabel, SmartArt) dengan menelusuri koleksi mereka secara terpisah atau melewatkan tipe objek tersebut.