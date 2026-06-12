---
title: Kelola Baris dan Kolom dalam Tabel PowerPoint Menggunakan PHP
linktitle: Baris dan Kolom
type: docs
weight: 20
url: /id/php-java/manage-rows-and-columns/
keywords:
- baris tabel
- kolom tabel
- baris pertama
- header tabel
- klon baris
- klon kolom
- salin baris
- salin kolom
- hapus baris
- hapus kolom
- pemformatan teks baris
- pemformatan teks kolom
- gaya tabel
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Kelola baris dan kolom tabel di PowerPoint dengan Aspose.Slides untuk PHP via Java dan percepat penyuntingan presentasi serta pembaruan data."
---
## **Pengantar**

Untuk memungkinkan Anda mengelola baris dan kolom tabel dalam presentasi PowerPoint, Aspose.Slides menyediakan kelas [Table](https://reference.aspose.com/slides/id/php-java/aspose.slides/table/) dan banyak tipe lainnya.

## **Set Baris Pertama sebagai Header**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) dan muat presentasi.  
2. Dapatkan referensi slide melalui indeksnya.  
3. Buat objek [Table](https://reference.aspose.com/slides/id/php-java/aspose.slides/Table) dan setel ke null.  
4. Iterasikan semua objek [Shape](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/) untuk menemukan tabel yang relevan.  
5. Setel baris pertama tabel sebagai header.  

Kode PHP ini menunjukkan cara menyiapkan baris pertama tabel sebagai header:

```php
  # Membuat instance kelas Presentation
  $pres = new Presentation("table.pptx");
  try {
    # Mengakses slide pertama
    $sld = $pres->getSlides()->get_Item(0);
    # Menginisialisasi TableEx null
    $tbl = null;
    # Meloop melalui shapes dan menetapkan referensi ke tabel
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # Menetapkan baris pertama tabel sebagai header
        $tbl->setFirstRow(true);
      }
    }
    # Menyimpan presentasi ke disk
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Mengkloning Baris atau Kolom Tabel**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) dan muat presentasi,  
2. Dapatkan referensi slide melalui indeksnya.  
3. Definisikan sebuah array `columnWidth`.  
4. Definisikan sebuah array `rowHeight`.  
5. Tambahkan objek [Table](https://reference.aspose.com/slides/id/php-java/aspose.slides/Table) ke slide melalui metode [addTable](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/addtable/).  
6. Klon baris tabel.  
7. Klon kolom tabel.  
8. Simpan presentasi yang telah dimodifikasi.  

Kode PHP ini menunjukkan cara mengkloning baris atau kolom tabel PowerPoint:

```php
  # Membuat instance kelas Presentation
  $pres = new Presentation("Test.pptx");
  try {
    # Mengakses slide pertama
    $sld = $pres->getSlides()->get_Item(0);
    # Mendefinisikan kolom dengan lebar dan baris dengan tinggi
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # Menambahkan shape tabel ke slide
    $table = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # Menambahkan teks ke baris 1 sel 1
    $table->get_Item(0, 0)->getTextFrame()->setText("Row 1 Cell 1");
    # Menambahkan teks ke baris 1 sel 2
    $table->get_Item(1, 0)->getTextFrame()->setText("Row 1 Cell 2");
    # Mengkloning Baris 1 di akhir tabel
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);
    # Menambahkan teks ke baris 2 sel 1
    $table->get_Item(0, 1)->getTextFrame()->setText("Row 2 Cell 1");
    # Menambahkan teks ke baris 2 sel 2
    $table->get_Item(1, 1)->getTextFrame()->setText("Row 2 Cell 2");
    # Mengkloning Baris 2 sebagai baris ke-4 tabel
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);
    # Mengkloning kolom pertama di akhir
    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    # Mengkloning kolom ke-2 pada indeks kolom ke-4
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);
    # Menyimpan presentasi ke disk
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Menghapus Baris atau Kolom dari Tabel**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) dan muat presentasi,  
2. Dapatkan referensi slide melalui indeksnya.  
3. Definisikan sebuah array `columnWidth`.  
4. Definisikan sebuah array `rowHeight`.  
5. Tambahkan objek [Table](https://reference.aspose.com/slides/id/php-java/aspose.slides/Table) ke slide melalui metode [addTable](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/addtable/).  
6. Hapus baris tabel.  
7. Hapus kolom tabel.  
8. Simpan presentasi yang telah dimodifikasi.  

Kode PHP ini menunjukkan cara menghapus baris atau kolom dari tabel:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $colWidth = array(100, 50, 30 );
    $rowHeight = array(30, 50, 30 );
    $table = $slide->getShapes()->addTable(100, 100, $colWidth, $rowHeight);
    $table->getRows()->removeAt(1, false);
    $table->getColumns()->removeAt(1, false);
    $pres->save("TestTable_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Mengatur Pemformatan Teks pada Tingkat Baris Tabel**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) dan muat presentasi,  
2. Dapatkan referensi slide melalui indeksnya.  
3. Akses objek [Table](https://reference.aspose.com/slides/id/php-java/aspose.slides/Table) yang relevan dari slide.  
4. Setel sel baris pertama dengan [setFontHeight(float value)](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseportionformat/#setFontHeight).  
5. Setel sel baris pertama dengan [setAlignment(int value)](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/setalignment/) dan [setMarginRight(float value)](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/setmarginright/).  
6. Setel sel baris kedua dengan [setTextVerticalType(byte value)](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframeformat/settextverticaltype/).  
7. Simpan presentasi yang telah dimodifikasi.  

Kode PHP ini mendemonstrasikan operasi tersebut.

```php
  # Membuat instance kelas Presentation
  $pres = new Presentation();
  try {
    # Asumsikan bahwa shape pertama pada slide pertama adalah tabel
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Menetapkan tinggi font sel baris pertama
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getRows()->get_Item(0)->setTextFormat($portionFormat);
    # Menetapkan perataan teks sel baris pertama dan margin kanan
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getRows()->get_Item(0)->setTextFormat($paragraphFormat);
    # Menetapkan tipe vertikal teks sel baris kedua
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->getRows()->get_Item(1)->setTextFormat($textFrameFormat);
    # Menyimpan presentasi ke disk
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Mengatur Pemformatan Teks pada Tingkat Kolom Tabel**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) dan muat presentasi,  
2. Dapatkan referensi slide melalui indeksnya.  
3. Akses objek [Table](https://reference.aspose.com/slides/id/php-java/aspose.slides/Table) yang relevan dari slide.  
4. Setel sel kolom pertama dengan [setFontHeight(float value)](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseportionformat/#setFontHeight).  
5. Setel sel kolom pertama dengan [setAlignment(int value)](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/setalignment/) dan [setMarginRight(float value)](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/setmarginright/).  
6. Setel sel kolom kedua dengan [setTextVerticalType(byte value)](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframeformat/settextverticaltype/).  
7. Simpan presentasi yang telah dimodifikasi.  

Kode PHP ini mendemonstrasikan operasi tersebut:

```php
  # Membuat instance kelas Presentation
  $pres = new Presentation();
  try {
    # Asumsikan bahwa shape pertama pada slide pertama adalah tabel
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Menetapkan tinggi font sel kolom pertama
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getColumns()->get_Item(0)->setTextFormat($portionFormat);
    # Menetapkan perataan teks dan margin kanan sel kolom pertama dalam satu pemanggilan
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);
    # Menetapkan tipe vertikal teks sel kolom kedua
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->getColumns()->get_Item(1)->setTextFormat($textFrameFormat);
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Mendapatkan Properti Gaya Tabel**

Aspose.Slides memungkinkan Anda mengambil properti gaya untuk sebuah tabel sehingga Anda dapat menggunakan detail tersebut untuk tabel lain atau di tempat lain. Kode PHP ini menunjukkan cara mendapatkan properti gaya dari gaya tabel preset:

```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// ubah tema preset gaya default

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Apakah saya dapat menerapkan tema/gaya PowerPoint ke tabel yang sudah dibuat?**

Ya. Tabel mewarisi tema slide/layout/master, dan Anda masih dapat menimpa isian, batas, dan warna teks di atas tema tersebut.

**Apakah saya dapat mengurutkan baris tabel seperti di Excel?**

Tidak, tabel Aspose.Slides tidak memiliki fungsi penyortiran atau filter bawaan. Urutkan data Anda di memori terlebih dahulu, kemudian isi kembali baris tabel sesuai urutan tersebut.

**Apakah saya dapat memiliki kolom berbanding (striped) sambil mempertahankan warna khusus pada sel tertentu?**

Ya. Aktifkan kolom berbanding, lalu timpa sel tertentu dengan format lokal; format pada level sel memiliki prioritas lebih tinggi daripada gaya tabel.