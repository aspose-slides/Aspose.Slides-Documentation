---
title: Kelola Tabel Presentasi di PHP
linktitle: Kelola Tabel
type: docs
weight: 10
url: /id/php-java/manage-table/
keywords:
- tambahkan tabel
- buat tabel
- akses tabel
- rasio aspek
- menyelaraskan teks
- pemformatan teks
- gaya tabel
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Buat & edit tabel dalam slide PowerPoint dengan Aspose.Slides untuk PHP via Java. Temukan contoh kode sederhana untuk mempermudah alur kerja tabel Anda."
---
## **Pendahuluan**

Tabel dalam PowerPoint adalah cara yang efisien untuk menampilkan dan menggambarkan informasi. Informasi dalam kisi sel (yang diatur dalam baris dan kolom) bersifat langsung dan mudah dipahami.

Aspose.Slides menyediakan kelas [Table](https://reference.aspose.com/slides/id/php-java/aspose.slides/Table), kelas [Cell](https://reference.aspose.com/slides/id/php-java/aspose.slides/cell/), dan tipe lainnya untuk memungkinkan Anda membuat, memperbarui, dan mengelola tabel dalam semua jenis presentasi.

## **Membuat Tabel dari Awal**

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya. 
3. Tentukan array `columnWidth`.
4. Tentukan array `rowHeight`.
5. Tambahkan objek [Table](https://reference.aspose.com/slides/id/php-java/aspose.slides/table/) ke slide melalui metode [addTable](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/addtable/).
6. Iterasikan setiap [Cell](https://reference.aspose.com/slides/id/php-java/aspose.slides/cell/) untuk menerapkan format pada batas atas, bawah, kanan, dan kiri.
7. Gabungkan dua sel pertama pada baris pertama tabel. 
8. Akses [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/) milik sebuah [Cell](https://reference.aspose.com/slides/id/php-java/aspose.slides/cell/).
9. Tambahkan teks ke [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/).
10. Simpan presentasi yang telah dimodifikasi.

Kode PHP ini menunjukkan cara membuat tabel dalam presentasi:

```php
  # Menginstansiasi kelas Presentation yang mewakili file PPTX
  $pres = new Presentation();
  try {
    # Mengakses slide pertama
    $sld = $pres->getSlides()->get_Item(0);
    # Mendefinisikan kolom dengan lebar dan baris dengan tinggi
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Menambahkan shape tabel ke slide
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Menetapkan format border untuk setiap sel
    for($row = 0; $row < java_values($tbl->getRows()->size()) ; $row++) {
      for($cell = 0; $cell < java_values($tbl->getRows()->get_Item($row)->size()) ; $cell++) {
        $cellFormat = $tbl->getRows()->get_Item($row)->get_Item($cell)->getCellFormat();
        $cellFormat::getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderTop()->setWidth(5);
        $cellFormat::getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderBottom()->setWidth(5);
        $cellFormat::getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderLeft()->setWidth(5);
        $cellFormat::getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderRight()->setWidth(5);
      }
    }
    # Menggabungkan sel 1 & 2 pada baris 1
    $tbl->mergeCells($tbl->getRows()->get_Item(0)->get_Item(0), $tbl->getRows()->get_Item(1)->get_Item(1), false);
    # Menambahkan teks ke sel yang digabung
    $tbl->getRows()->get_Item(0)->get_Item(0)->getTextFrame()->setText("Merged Cells");
    # Menyimpan presentasi ke Disk
    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Penomoran dalam Tabel Standar**

Dalam tabel standar, penomoran sel bersifat langsung dan berawal dari nol. Sel pertama dalam tabel memiliki indeks 0,0 (kolom 0, baris 0). 

Sebagai contoh, sel dalam tabel dengan 4 kolom dan 4 baris diberi nomor sebagai berikut:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Kode PHP ini menunjukkan cara menentukan penomoran untuk sel dalam tabel:

```php
  # Menginstansiasi kelas Presentation yang mewakili file PPTX
  $pres = new Presentation();
  try {
    # Mengakses slide pertama
    $sld = $pres->getSlides()->get_Item(0);
    # Mendefinisikan kolom dengan lebar dan baris dengan tinggi
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Menambahkan shape tabel ke slide
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Menetapkan format border untuk setiap sel
    $rows = $tbl->getRows();
    foreach($rows as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderTop()->setWidth(5);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderBottom()->setWidth(5);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderLeft()->setWidth(5);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderRight()->setWidth(5);
      }
    }
    # Menyimpan presentasi ke disk
    $pres->save("StandardTables_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Mengakses Tabel yang Ada**

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation).
2. Dapatkan referensi ke slide yang berisi tabel melalui indeksnya. 
3. Buat objek [Table](https://reference.aspose.com/slides/id/php-java/aspose.slides/Table) dan setel ke null.
4. Iterasikan semua objek [Shape](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/) sampai tabel ditemukan.

   Jika Anda menduga slide yang Anda tangani berisi satu tabel, Anda dapat cukup memeriksa semua shape yang ada di dalamnya. Ketika sebuah shape diidentifikasi sebagai tabel, Anda dapat melakukan typecast menjadi objek [Table](https://reference.aspose.com/slides/id/php-java/aspose.slides/Table). Namun jika slide yang Anda tangani berisi beberapa tabel, lebih baik mencari tabel yang Anda butuhkan melalui [setAlternativeText(String value)](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/setalternativetext/).

5. Gunakan objek [Table](https://reference.aspose.com/slides/id/php-java/aspose.slides/Table) untuk bekerja dengan tabel. Pada contoh di bawah, kami menambahkan baris baru ke tabel.
6. Simpan presentasi yang telah dimodifikasi.

Kode PHP ini menunjukkan cara mengakses dan bekerja dengan tabel yang ada:

```php
  # Menginstansiasi kelas Presentation yang mewakili file PPTX
  $pres = new Presentation("UpdateExistingTable.pptx");
  try {
    # Mengakses slide pertama
    $sld = $pres->getSlides()->get_Item(0);
    # Menginisialisasi TableEx null
    $tbl = null;
    # Mengiterasi shape dan menetapkan referensi ke tabel yang ditemukan
    $shapes = $sld->getShapes();
    foreach($shapes as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # Menetapkan teks untuk kolom pertama baris kedua
        $tbl->get_Item(0, 1)->getTextFrame()->setText("New");
      }
    }
    # Menyimpan presentasi yang dimodifikasi ke disk
    $pres->save("table1_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Temukan Sel yang Memiliki Text Frame**

Ketika kode pemrosesan teks umum menerima sebuah [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/) dari tabel, gunakan metode [TextFrame::getParentCell](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/#getParentCell) untuk mengambil [Cell](https://reference.aspose.com/slides/id/php-java/aspose.slides/cell/) yang memilikinya. Untuk text frame sel tabel, [TextFrame::getParentCell](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/#getParentCell) mengembalikan pemiliknya dan [TextFrame::getParentShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/#getParentShape) mengembalikan `null`, meskipun tabel itu sendiri adalah sebuah shape.

Koordinat sel tersedia melalui metode read-only [Cell::getFirstColumnIndex](https://reference.aspose.com/slides/id/php-java/aspose.slides/cell/#getFirstColumnIndex) dan [Cell::getFirstRowIndex](https://reference.aspose.com/slides/id/php-java/aspose.slides/cell/#getFirstRowIndex). [TextFrame::getParentCell](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/#getParentCell) juga menyediakan navigasi read-only: ia mengembalikan pemilik tetapi tidak mengubah kepemilikan. Selalu periksa sel yang dikembalikan dengan `java_is_null` sebelum menggunakannya.

Untuk contoh lengkap yang mengidentifikasi pemilik sel tabel dan shape, termasuk shape yang terkait dengan node SmartArt, lihat [Search and Replace Text](/slides/id/php-java/search-and-replace-text/).

## **Menyelaraskan Teks dalam Tabel**

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya. 
3. Tambahkan objek [Table](https://reference.aspose.com/slides/id/php-java/aspose.slides/Table) ke slide.
4. Akses objek [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/) dari tabel.
5. Akses [Paragraph](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraph/).
6. Selaraskan teks secara vertikal.
7. Simpan presentasi yang telah dimodifikasi.

Kode PHP ini menunjukkan cara menyelaraskan teks dalam tabel:

```php
  # Membuat instance dari kelas Presentation
  $pres = new Presentation();
  try {
    # Mendapatkan slide pertama
    $slide = $pres->getSlides()->get_Item(0);
    # Mendefinisikan kolom dengan lebar dan baris dengan tinggi
    $dblCols = array(120, 120, 120, 120 );
    $dblRows = array(100, 100, 100, 100 );
    # Menambahkan shape tabel ke slide
    $tbl = $slide->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    $tbl->get_Item(1, 0)->getTextFrame()->setText("10");
    $tbl->get_Item(2, 0)->getTextFrame()->setText("20");
    $tbl->get_Item(3, 0)->getTextFrame()->setText("30");
    # Mengakses text frame
    $txtFrame = $tbl->get_Item(0, 0)->getTextFrame();
    # Membuat objek Paragraph untuk text frame
    $paragraph = $txtFrame->getParagraphs()->get_Item(0);
    # Membuat objek Portion untuk paragraf
    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Menyelaraskan teks secara vertikal
    $cell = $tbl->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);
    # Menyimpan presentasi ke disk
    $pres->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Mengatur Pemformatan Teks pada Tingkat Tabel**

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya. 
3. Akses objek [Table](https://reference.aspose.com/slides/id/php-java/aspose.slides/Table) dari Slide.
4. Setel [setFontHeight(float value)](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseportionformat/#setFontHeight) untuk teks.
5. Setel [setAlignment(int value)](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/setalignment/) dan [setMarginRight(float value)](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/setmarginright/).
6. Setel [setTextVerticalType(byte value)](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframeformat/settextverticaltype/).
7. Simpan presentasi yang telah dimodifikasi. 

Kode PHP ini menunjukkan cara menerapkan opsi pemformatan pilihan Anda pada teks dalam tabel:

```php
  # Membuat instance dari kelas Presentation
  $pres = new Presentation("simpletable.pptx");
  try {
    # Anggap bahwa shape pertama pada slide pertama adalah tabel
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Menetapkan tinggi font sel tabel
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->setTextFormat($portionFormat);
    # Menetapkan perataan teks sel tabel dan margin kanan dalam satu panggilan
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->setTextFormat($paragraphFormat);
    # Menetapkan jenis teks vertikal sel tabel
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->setTextFormat($textFrameFormat);
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Mendapatkan Properti Gaya Tabel**

Aspose.Slides memungkinkan Anda mengambil properti gaya untuk sebuah tabel sehingga Anda dapat menggunakan detail tersebut pada tabel lain atau di tempat lain. Kode PHP ini menunjukkan cara mendapatkan properti gaya dari gaya preset tabel:

```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// ubah preset gaya default
    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Mengunci Rasio Aspek Tabel**

Rasio aspek sebuah shape geometris adalah perbandingan ukuran dalam dimensi yang berbeda. Aspose.Slides menyediakan metode [setAspectRatioLocked](https://reference.aspose.com/slides/id/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) untuk memungkinkan Anda mengunci pengaturan rasio aspek bagi tabel dan shape lainnya.

Kode PHP ini menunjukkan cara mengunci rasio aspek untuk sebuah tabel:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $table->getGraphicalObjectLock()->setAspectRatioLocked(!$table->getGraphicalObjectLock()->getAspectRatioLocked());// balikkan

    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Apakah saya dapat mengaktifkan arah baca kanan-ke-kiri (RTL) untuk seluruh tabel dan teks di sel-selnya?**

Ya. Tabel menyediakan metode [setRightToLeft](https://reference.aspose.com/slides/id/php-java/aspose.slides/table/setrighttoleft/), dan paragraf memiliki [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/setrighttoleft/). Menggunakan keduanya memastikan urutan RTL yang benar dan rendering di dalam sel.

**Bagaimana saya dapat mencegah pengguna memindahkan atau mengubah ukuran tabel dalam file akhir?**

Gunakan kunci shape untuk menonaktifkan pemindahan, perubahan ukuran, pemilihan, dll. Kunci ini juga berlaku pada tabel.

**Apakah penyisipan gambar di dalam sel sebagai latar belakang didukung?**

Ya. Anda dapat mengatur [picture fill](https://reference.aspose.com/slides/id/php-java/aspose.slides/picturefillformat/) untuk sebuah sel; gambar akan menutupi area sel sesuai mode yang dipilih (stretch atau tile).