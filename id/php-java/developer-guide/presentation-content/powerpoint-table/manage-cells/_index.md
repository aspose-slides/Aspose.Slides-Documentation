---
title: Mengelola Sel Tabel dalam Presentasi Menggunakan PHP
linktitle: Kelola Sel
type: docs
weight: 30
url: /id/php-java/manage-cells/
keywords:
- sel tabel
- menggabungkan sel
- menghapus batas
- memisahkan sel
- gambar dalam sel
- warna latar belakang
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Kelola sel tabel dalam PowerPoint dengan mudah menggunakan Aspose.Slides untuk PHP. Kuasai cara mengakses, memodifikasi, dan menata sel secara cepat untuk otomatisasi slide yang mulus."
---
## **Ringkasan**

Aspose.Slides memungkinkan Anda mengakses dan memodifikasi sel tabel dalam presentasi PowerPoint. Artikel ini menjelaskan cara mengidentifikasi sel tabel yang digabungkan, menghapus batas sel, bekerja dengan penomoran sel setelah menggabungkan atau memisahkan sel, mengubah warna latar belakang sel, dan menambahkan gambar di dalam sel tabel. Contoh-contohnya menunjukkan cara membuat atau membuka presentasi, mendapatkan tabel dari slide, memperbarui format sel melalui properti sel, dan menyimpan presentasi yang telah dimodifikasi sebagai file PPTX.

## **Mengidentifikasi Sel Tabel yang Digabungkan**
1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation).
2. Dapatkan tabel dari slide pertama.
3. Iterasi baris dan kolom tabel untuk menemukan sel yang digabungkan.
4. Cetak pesan ketika sel yang digabungkan ditemukan.

Kode PHP ini menunjukkan cara mengidentifikasi sel tabel yang digabungkan dalam sebuah presentasi:

```php
  $pres = new Presentation("SomePresentationWithTable.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);// mengasumsikan bahwa Slide#0.Shape#0 adalah sebuah tabel

    for($i = 0; $i < java_values($table->getRows()->size()) ; $i++) {
      for($j = 0; $j < java_values($table->getColumns()->size()) ; $j++) {
        $currentCell = $table->getRows()->get_Item($i)->get_Item($j);
        if ($currentCell->isMergedCell()) {
          echo(sprintf("Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.", $i, $j, $currentCell->getRowSpan(), $currentCell->getColSpan(), $currentCell->getFirstRowIndex(), $currentCell->getFirstColumnIndex()));
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Menghapus Batas Sel Tabel**
1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya.
3. Tentukan array kolom dengan lebar.
4. Tentukan array baris dengan tinggi.
5. Tambahkan tabel ke slide melalui metode [addTable](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/#addTable).
6. Iterasi setiap sel untuk menghapus batas atas, bawah, kanan, dan kiri.
7. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Kode PHP ini menunjukkan cara menghapus batas dari sel tabel:

```php
  # Membuat instance kelas Presentation yang mewakili file PPTX
  $pres = new Presentation();
  try {
    # Mengakses slide pertama
    $sld = $pres->getSlides()->get_Item(0);
    # Mendefinisikan kolom dengan lebar dan baris dengan tinggi
    $dblCols = array(50, 50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Menambahkan bentuk tabel ke slide
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Mengatur format batas untuk setiap sel
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::NoFill);
      }
    }
    # Menulis PPTX ke disk
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Penomoran pada Sel yang Digabungkan**
Jika kita menggabungkan 2 pasang sel (1, 1) x (2, 1) dan (1, 2) x (2, 2), tabel yang dihasilkan akan bernomor. Kode PHP ini mendemonstrasikan prosesnya:

```php
  # Membuat instance kelas Presentation yang mewakili file PPTX
  $pres = new Presentation();
  try {
    # Mengakses slide pertama
    $sld = $pres->getSlides()->get_Item(0);
    # Mendefinisikan kolom dengan lebar dan baris dengan tinggi
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Menambahkan bentuk tabel ke slide
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Mengatur format batas untuk setiap sel
    foreach($tbl->getRows() as $row) {
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
    # Menggabungkan sel (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Menggabungkan sel (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Kemudian kami menggabungkan sel lebih lanjut dengan menggabungkan (1, 1) dan (1, 2). Hasilnya adalah tabel yang berisi sel besar yang digabungkan di tengahnya:

```php
  # Membuat instance kelas Presentation yang mewakili file PPTX
  $pres = new Presentation();
  try {
    # Mengakses slide pertama
    $sld = $pres->getSlides()->get_Item(0);
    # Mendefinisikan kolom dengan lebar dan baris dengan tinggi
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Menambahkan bentuk tabel ke slide
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Mengatur format batas untuk setiap sel
    foreach($tbl->getRows() as $row) {
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
    # Menggabungkan sel (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Menggabungkan sel (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # Menggabungkan sel (1, 1) x (1, 2)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(1, 2), true);
    # Menulis file PPTX ke disk
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Penomoran pada Sel yang Dipisah**
Dalam contoh sebelumnya, ketika sel tabel digabungkan, sistem penomoran atau angka pada sel lain tidak berubah.

Kali ini, kami mengambil tabel biasa (tabel tanpa sel yang digabungkan) dan kemudian mencoba memisahkan sel (1,1) untuk mendapatkan tabel khusus. Anda mungkin harus memperhatikan penomoran tabel ini, yang mungkin terlihat aneh. Namun, itu adalah cara Microsoft PowerPoint menomori sel tabel dan Aspose.Slides melakukan hal yang sama.

Kode PHP ini mendemonstrasikan proses yang kami jelaskan:

```php
  # Membuat instance kelas Presentation yang mewakili file PPTX
  $pres = new Presentation();
  try {
    # Mengakses slide pertama
    $sld = $pres->getSlides()->get_Item(0);
    # Mendefinisikan kolom dengan lebar dan baris dengan tinggi
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # Menambahkan bentuk tabel ke slide
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Mengatur format batas untuk setiap sel
    foreach($tbl->getRows() as $row) {
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
    # Menggabungkan sel (1, 1) x (2, 1)
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # Menggabungkan sel (1, 2) x (2, 2)
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # Memisahkan sel (1, 1)
    $tbl->get_Item(1, 1)->splitByWidth($tbl->get_Item(2, 1)->getWidth() / 2);
    # Menulis file PPTX ke disk
    $pres->save("SplitCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Mengubah Warna Latar Belakang Sel Tabel**

Kode PHP ini menunjukkan cara mengubah warna latar belakang sel tabel:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(50, 50, 50, 50, 50 );
    # buat tabel baru
    $table = $slide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # atur warna latar belakang sel
    $cell = $table->get_Item(2, 3);
    $cell->getCellFormat()->getFillFormat()->setFillType(FillType::Solid);
    $cell->getCellFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $presentation->save("cell_background_color.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Menambahkan Gambar di Dalam Sel Tabel**
1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya.
3. Tentukan array kolom dengan lebar.
4. Tentukan array baris dengan tinggi.
5. Tambahkan tabel ke slide melalui metode [AddTable](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/#addTable).
6. Buat objek `Images` untuk menampung file gambar.
7. Tambahkan gambar `IImage` ke objek `IPPImage`.
8. Atur `FillFormat` untuk Sel Tabel menjadi `Picture`.
9. Tambahkan gambar ke sel pertama tabel.
10. Simpan presentasi yang dimodifikasi sebagai file PPTX

Kode PHP ini menunjukkan cara menempatkan gambar di dalam sel tabel saat membuat tabel:

```php
  # Membuat instance kelas Presentation yang mewakili file PPTX
  $pres = new Presentation();
  try {
    # Mengakses slide pertama
    $islide = $pres->getSlides()->get_Item(0);
    # Mendefinisikan kolom dengan lebar dan baris dengan tinggi
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(100, 100, 100, 100, 90 );
    # Menambahkan bentuk tabel ke slide
    $tbl = $islide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # Membuat objek IPPImage menggunakan file gambar
    $picture;
    $image = Images->fromFile("image.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Menambahkan gambar ke sel tabel pertama
    $cellFormat = $tbl->get_Item(0, 0)->getCellFormat();
    $cellFormat::getFillFormat()->setFillType(FillType::Picture);
    $cellFormat::getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    $cellFormat::getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # Menyimpan file PPTX ke disk
    $pres->save("Image_In_TableCell_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Bisakah saya mengatur ketebalan garis dan gaya yang berbeda untuk sisi yang berbeda dari satu sel?**

Ya. Batas [top](https://reference.aspose.com/slides/id/php-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/id/php-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/id/php-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/id/php-java/aspose.slides/cellformat/getborderright/) memiliki properti terpisah, sehingga ketebalan dan gaya masing-masing sisi dapat berbeda. Ini secara logis mengikuti kontrol batas per sisi untuk sebuah sel yang ditunjukkan dalam artikel.

**Apa yang terjadi pada gambar jika saya mengubah ukuran kolom/baris setelah menyetel gambar sebagai latar belakang sel?**

Perilaku tergantung pada [fill mode](https://reference.aspose.com/slides/id/php-java/aspose.slides/picturefillmode/) (stretch/tile). Dengan stretching, gambar menyesuaikan diri dengan sel baru; dengan tiling, ubin-ubin gambar dihitung ulang. Artikel menyebutkan mode tampilan gambar dalam sel.

**Bisakah saya menetapkan hyperlink ke seluruh konten sel?**

[Hyperlinks](/slides/id/php-java/manage-hyperlinks/) diatur pada tingkat teks (portion) di dalam kerangka teks sel atau pada tingkat seluruh tabel/bentuk. Pada praktiknya, Anda menetapkan tautan ke bagian tertentu atau ke seluruh teks dalam sel.

**Bisakah saya mengatur font yang berbeda dalam satu sel?**

Ya. Kerangka teks sel mendukung [portions](https://reference.aspose.com/slides/id/php-java/aspose.slides/portion/) (run) dengan pemformatan independen—jenis font, gaya, ukuran, dan warna.