---
title: Kelola Font dalam Presentasi Menggunakan PHP
linktitle: Kelola Font
type: docs
weight: 10
url: /id/php-java/manage-fonts/
keywords:
- kelola font
- properti font
- paragraf
- pemformatan teks
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Kontrol font dalam PHP dengan Aspose.Slides: sematkan, gantikan, dan muat font khusus untuk menjaga presentasi PPT, PPTX, dan ODP tetap jelas, aman merek, dan konsisten."
---
## **Manage Font Related Properties**
{{% alert color="primary" %}} 

Presentasi biasanya berisi teks dan gambar. Teks dapat diformat dengan berbagai cara, baik untuk menyoroti bagian dan kata tertentu atau agar sesuai dengan gaya perusahaan. Pemformatan teks membantu pengguna mengubah tampilan dan nuansa konten presentasi. Artikel ini menunjukkan cara menggunakan Aspose.Slides for PHP via Java untuk mengonfigurasi properti font paragraf teks pada slide.

{{% /alert %}} 

Untuk mengelola properti font paragraf menggunakan Aspose.Slides for PHP via Java:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation).
1. Dapatkan referensi slide dengan menggunakan indeksnya.
1. Akses bentuk [Placeholder](https://reference.aspose.com/slides/id/php-java/aspose.slides/placeholder/) pada slide dan lakukan typecast ke [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/).
1. Dapatkan [Paragraph](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraph/) dari [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/) yang disediakan oleh [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/).
1. Justify paragraf.
1. Akses [Portion](https://reference.aspose.com/slides/id/php-java/aspose.slides/portion/) teks milik sebuah [Paragraph](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraph/).
1. Definisikan font menggunakan [FontData](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontdata/) dan atur **Font** dari [Portion](https://reference.aspose.com/slides/id/php-java/aspose.slides/portion/) secara sesuai.
   1. Atur font menjadi tebal (bold).
   1. Atur font menjadi miring (italic).
1. Atur warna font menggunakan [FillFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/fillformat/) yang disediakan oleh objek [Portion](https://reference.aspose.com/slides/id/php-java/aspose.slides/portion/).
1. Simpan presentasi yang telah dimodifikasi ke file PPTX.

Implementasi langkah‑langkah di atas diberikan di bawah ini. Contoh ini mengambil presentasi standar dan memformat font pada salah satu slide. Tangkapan layar berikut memperlihatkan file input serta cara cuplikan kode mengubahnya. Kode mengubah font, warna, dan gaya font.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figure: Teks dalam file input**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figure: Teks yang sama dengan pemformatan yang diperbarui**|

```php
  # Membuat objek Presentation yang mewakili file PPTX
  $pres = new Presentation("FontProperties.pptx");
  try {
    # Mengakses slide menggunakan posisinya
    $slide = $pres->getSlides()->get_Item(0);
    # Mengakses placeholder pertama dan kedua dalam slide dan melakukan typecast menjadi AutoShape
    $tf1 = $slide->getShapes()->get_Item(0)->getTextFrame();
    $tf2 = $slide->getShapes()->get_Item(1)->getTextFrame();
    # Mengakses Paragraph pertama
    $para1 = $tf1->getParagraphs()->get_Item(0);
    $para2 = $tf2->getParagraphs()->get_Item(0);
    # Menjustifikasi paragraf
    $para2->getParagraphFormat()->setAlignment(TextAlignment->JustifyLow);
    # Mengakses portion pertama
    $port1 = $para1->getPortions()->get_Item(0);
    $port2 = $para2->getPortions()->get_Item(0);
    # Mendefinisikan font baru
    $fd1 = new FontData("Elephant");
    $fd2 = new FontData("Castellar");
    # Menetapkan font baru ke portion
    $port1->getPortionFormat()->setLatinFont($fd1);
    $port2->getPortionFormat()->setLatinFont($fd2);
    # Mengatur font menjadi Bold
    $port1->getPortionFormat()->setFontBold(NullableBool::True);
    $port2->getPortionFormat()->setFontBold(NullableBool::True);
    # Mengatur font menjadi Italic
    $port1->getPortionFormat()->setFontItalic(NullableBool::True);
    $port2->getPortionFormat()->setFontItalic(NullableBool::True);
    # Mengatur warna font
    $port1->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port1->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $port2->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port2->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # Menyimpan PPTX ke disk
    $pres->save("WelcomeFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Set Text Font Properties**
{{% alert color="primary" %}} 

Seperti disebutkan dalam **Managing Font Related Properties**, sebuah [Portion](https://reference.aspose.com/slides/id/php-java/aspose.slides/portion/) digunakan untuk menyimpan teks dengan gaya pemformatan serupa dalam sebuah paragraf. Artikel ini menunjukkan cara menggunakan Aspose.Slides for PHP via Java untuk membuat kotak teks dengan beberapa teks dan kemudian menentukan font tertentu, serta berbagai properti lain dari kategori keluarga font.

{{% /alert %}} 

Untuk membuat kotak teks dan mengatur properti font teks di dalamnya:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation).
1. Dapatkan referensi slide dengan menggunakan indeksnya.
1. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) berjenis **Rectangle** ke slide.
1. Hapus gaya isi yang terkait dengan [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/).
1. Akses [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/) milik [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/).
1. Tambahkan beberapa teks ke [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/).
1. Akses objek [Portion](https://reference.aspose.com/slides/id/php-java/aspose.slides/portion/) yang terkait dengan [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/).
1. Definisikan font yang akan digunakan untuk [Portion](https://reference.aspose.com/slides/id/php-java/aspose.slides/portion/).
1. Atur properti font lain seperti bold, italic, underline, warna, dan tinggi menggunakan properti yang relevan yang disediakan oleh objek [Portion](https://reference.aspose.com/slides/id/php-java/aspose.slides/portion/).
1. Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Implementasi langkah‑langkah di atas diberikan di bawah ini.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figure: Teks dengan beberapa properti font yang diatur oleh Aspose.Slides for PHP via Java**|

```php
  # Membuat objek Presentation yang mewakili file PPTX
  $pres = new Presentation();
  try {
    # Dapatkan slide pertama
    $sld = $pres->getSlides()->get_Item(0);
    # Tambahkan AutoShape bertipe Rectangle
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    # Hapus semua gaya isi yang terkait dengan AutoShape
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Akses TextFrame yang terkait dengan AutoShape
    $tf = $ashp->getTextFrame();
    $tf->setText("Aspose TextBox");
    # Akses Portion yang terkait dengan TextFrame
    $port = $tf->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    # Atur Font untuk Portion
    $port->getPortionFormat()->setLatinFont(new FontData("Times New Roman"));
    # Atur properti Bold pada Font
    $port->getPortionFormat()->setFontBold(NullableBool::True);
    # Atur properti Italic pada Font
    $port->getPortionFormat()->setFontItalic(NullableBool::True);
    # Atur properti Underline pada Font
    $port->getPortionFormat()->setFontUnderline(TextUnderlineType::Single);
    # Atur Tinggi Font
    $port->getPortionFormat()->setFontHeight(25);
    # Atur warna Font
    $port->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $port->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # Simpan presentasi ke disk
    $pres->save("pptxFont.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```