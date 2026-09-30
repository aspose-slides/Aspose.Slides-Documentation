---
title: Mengelola Baris dan Kolom dalam Tabel PowerPoint Menggunakan PHP
linktitle: Baris dan Kolom
type: docs
weight: 20
url: /id/php-java/manage-rows-and-columns/
keywords:
- baris tabel
- kolom tabel
- baris pertama
- header tabel
- gandakan baris
- gandakan kolom
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
description: "Kelola baris dan kolom tabel dalam PowerPoint dengan Aspose.Slides for PHP via Java dan percepat penyuntingan presentasi serta pembaruan data."
---
## **Pendahuluan**

Aspose.Slides for PHP via Java memungkinkan Anda mengelola struktur tabel dan pemformatan dalam presentasi PowerPoint melalui kelas [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) . Anda dapat menandai baris header, menggandakan atau menghapus baris dan kolom, serta menerapkan pemformatan teks pada seluruh baris atau kolom.

Artikel ini menjelaskan operasi tersebut dengan contoh PHP. Artikel ini juga menunjukkan cara mengambil preset gaya tabel sehingga Anda dapat menggunakannya kembali. Indeks baris dan kolom tabel berbasis nol.

## **Mengontrol Tinggi Baris**

Gunakan [Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/) untuk mengatur tinggi minimum baris dalam poin. Itu merupakan batas bawah, bukan tinggi tetap. [Row::getHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/getheight/) mengembalikan tinggi sebenarnya. Akses baris melalui [Table::getRows](https://reference.aspose.com/slides/php-java/aspose.slides/table/getrows/).

Contoh memuat [row-height-input.pptx](row-height-input.pptx), yang memiliki tabel sebagai bentuk pertama pada slide pertama. Baris pertama dimulai pada 70 poin. Sel-selnya menggunakan teks Arial 18 poin, dengan pembungkus, dan margin atas serta bawah 6 poin; teks yang lebih panjang di kolom kedua dibungkus menjadi beberapa baris. Contoh meningkatkan nilai minimum menjadi 100 poin, kemudian menurunkannya menjadi 20 poin, mencetak tinggi sebenarnya setelah setiap perubahan, dan menyimpan kedua hasil.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("row-height-input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $row = $table->getRows()->get_Item(0);

    $row->setMinimalHeight(100);
    printf("Increased: minimum = %.1f, actual = %.1f pt\n", java_values($row->getMinimalHeight()), java_values($row->getHeight()));
    $presentation->save("row-height-increased.pptx", SaveFormat::Pptx);

    $row->setMinimalHeight(20);
    printf("Decreased: minimum = %.1f, actual = %.1f pt\n", java_values($row->getMinimalHeight()), java_values($row->getHeight()));
    $presentation->save("row-height-decreased.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Dengan presentasi yang disediakan, meningkatkan nilai minimum menambah ruang pada baris. Menurunkannya menghapus ruang ekstra tersebut, tetapi tinggi sebenarnya tetap lebih besar dari 20 poin karena teks dan margin sel membutuhkan lebih banyak ruang. Mengurangi minimum saja tidak dapat memaksa baris berada di bawah ruang yang dibutuhkan oleh kontennya.

Beberapa faktor memengaruhi tinggi sebenarnya:

- **Teks dan ukuran font:** teks yang lebih panjang, jeda baris eksplisit, atau font yang lebih besar dapat membutuhkan lebih banyak ruang vertikal.
- **Pembungkus dan lebar kolom:** dengan pembungkus diaktifkan, mengurangi lebar kolom menggunakan [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) dapat menghasilkan lebih banyak baris. Kolom yang lebih lebar dapat mengurangi ruang yang diperlukan secara vertikal.
- **Margin sel:** [Cell::setMarginTop](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmargintop/) dan [Cell::setMarginBottom](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginbottom/) menambah ruang vertikal. [Cell::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginleft/) dan [Cell::setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginright/) mengurangi lebar yang tersedia untuk teks dan dapat menyebabkan pembungkus tambahan.

Untuk tabel ini tanpa sel yang digabung, sel yang membutuhkan ruang vertikal paling banyak menentukan batas bawah yang dipengaruhi konten untuk seluruh baris. Untuk membuat baris lebih pendek, Anda mungkin juga perlu memendekkan teks, mengurangi ukuran font atau margin, atau memperlebar kolom.

Gambar di bawah menunjukkan tabel yang sama dengan skala yang sama. Dalam hasil yang diilustrasikan, tinggi sebenarnya adalah 70, 100, dan 55.2 poin: baris terakhir tetap lebih tinggi daripada minimum 20 poin. Pengukuran teks yang tepat dapat bervariasi dengan font yang tersedia di lingkungan Anda. Unduh hasil yang disimpan: [increased minimum](row-height-increased.pptx) dan [decreased minimum](row-height-decreased.pptx).

| Asli: minimum 70 pt, aktual 70 pt | Ditingkatkan: minimum 100 pt, aktual 100 pt | Diturunkan: minimum 20 pt, aktual 55.2 pt |
| --- | --- | --- |
| ![Tabel asli dengan baris pertama 70 poin.](row-height-before.png) | ![Tabel setelah meningkatkan minimum baris pertama menjadi 100 poin.](row-height-increased.png) | ![Tabel setelah menurunkan minimum baris pertama menjadi 20 poin; teks yang dibungkus membuat baris tetap lebih tinggi daripada minimum.](row-height-decreased.png) |

## **Menetapkan Baris Pertama sebagai Header**

Gunakan metode [setFirstRow](https://reference.aspose.com/slides/php-java/aspose.slides/table/setfirstrow/) untuk menandai baris pertama sebagai format header. Penampilannya tergantung pada gaya tabel yang diterapkan pada tabel.

1. Muat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Akses slide pertama.
3. Akses tabel yang disimpan sebagai bentuk pertama pada slide.
4. Aktifkan pemformatan header untuk baris pertamanya.
5. Simpan presentasi yang telah dimodifikasi.

Contoh memerlukan `table.pptx` dengan tabel sebagai bentuk pertama pada slide pertama. Contoh mengaktifkan pemformatan header untuk baris pertama dan menyimpan `First_row_header.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $table->setFirstRow(true);

    $presentation->save("First_row_header.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Menggandakan Baris atau Kolom Tabel**

Gandakan baris atau kolom untuk menggunakan kembali konten dan pemformatannya. Anda dapat menambahkan salinan ke akhir tabel atau menyisipkannya pada posisi tertentu.

1. Muat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Akses slide pertama.
3. Tentukan lebar kolom dan tinggi baris.
4. Tambahkan tabel dengan metode [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) .
5. Gandakan baris yang diperlukan.
6. Gandakan kolom yang diperlukan.
7. Simpan presentasi yang telah dimodifikasi.

Contoh memerlukan `Test.pptx` dengan setidaknya satu slide. Contoh membuat tabel dengan tiga kolom dan lima baris, dengan dimensi yang ditentukan dalam poin. Contoh menambahkan salinan baris pertama dan kolom pertama, lalu menyisipkan salinan baris kedua dan kolom kedua pada indeks 3 (posisi keempat). Tabel hasil memiliki tujuh baris dan lima kolom. Argumen `false` menonaktifkan penggandaan ke baris atau kolom yang digabung berdekatan; tabel ini tidak memiliki sel yang digabung.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [50, 50, 50];
    $rowHeights = [50, 30, 30, 30, 30];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(0, 0)->getTextFrame()->setText("Row 1 Cell 1");
    $table->get_Item(1, 0)->getTextFrame()->setText("Row 1 Cell 2");
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);

    $table->get_Item(0, 1)->getTextFrame()->setText("Row 2 Cell 1");
    $table->get_Item(1, 1)->getTextFrame()->setText("Row 2 Cell 2");
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);

    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);

    $presentation->save("table_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Menghapus Baris atau Kolom dari Tabel**

Hapus baris atau kolom yang tidak lagi diperlukan dalam tabel. Menghapus sebuah item menggeser indeks baris atau kolom yang mengikutinya.

1. Buat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Akses slide pertama.
3. Tentukan lebar kolom dan tinggi baris.
4. Tambahkan tabel dengan metode [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) .
5. Hapus baris kedua dan kolom kedua.
6. Simpan presentasi yang telah dimodifikasi.

Contoh ini membuat tabel tiga kali tiga dan menghapus baris serta kolom pada indeks 1, menyisakan tabel dua kali dua di `TestTable_out.pptx`. Dimensi dalam poin. Argumen `false` menonaktifkan penghapusan baris atau kolom yang digabung berdekatan; tabel ini tidak memiliki sel yang digabung.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [100, 50, 30];
    $rowHeights = [30, 50, 30];
    $table = $slide->getShapes()->addTable(100, 100, $columnWidths, $rowHeights);

    $table->getRows()->removeAt(1, false);
    $table->getColumns()->removeAt(1, false);

    $presentation->save("TestTable_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Menerapkan Pemformatan Teks pada Tingkat Baris Tabel**

Terapkan pemformatan teks pada seluruh baris untuk menjaga konsistensi sel-selnya. Anda dapat mengatur properti font, pemformatan paragraf, dan arah teks tanpa harus memformat setiap sel secara terpisah.

1. Muat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Akses tabel pada slide pertama.
3. Gunakan [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) untuk baris pertama.
4. Gunakan [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) dan [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) untuk baris pertama.
5. Gunakan [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) untuk baris kedua.
6. Simpan presentasi yang telah dimodifikasi.

Contoh memerlukan `table.pptx` dengan tabel sebagai bentuk pertama pada slide pertama dan setidaknya dua baris. Contoh menerapkan teks 25 poin, perataan kanan, dan margin paragraf kanan 20 poin pada baris pertama, kemudian mengatur teks vertikal pada baris kedua.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PortionFormat;
use aspose\slides\ParagraphFormat;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->getRows()->get_Item(0)->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->getRows()->get_Item(0)->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->getRows()->get_Item(1)->setTextFormat($textFrameFormat);

    $presentation->save("row_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Menerapkan Pemformatan Teks pada Tingkat Kolom Tabel**

Terapkan pemformatan teks pada seluruh kolom untuk menjaga konsistensi sel-selnya. Anda dapat mengatur properti font, pemformatan paragraf, dan arah teks tanpa harus memformat setiap sel secara terpisah.

1. Muat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Akses tabel pada slide pertama.
3. Gunakan [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) untuk kolom pertama.
4. Gunakan [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) dan [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) untuk kolom pertama.
5. Gunakan [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) untuk kolom kedua.
6. Simpan presentasi yang telah dimodifikasi.

Contoh memerlukan `table.pptx` dengan tabel sebagai bentuk pertama pada slide pertama dan setidaknya dua kolom. Contoh menerapkan teks 25 poin, perataan kanan, dan margin paragraf kanan 20 poin pada kolom pertama, kemudian mengatur teks vertikal pada kolom kedua.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PortionFormat;
use aspose\slides\ParagraphFormat;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->getColumns()->get_Item(0)->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->getColumns()->get_Item(1)->setTextFormat($textFrameFormat);

    $presentation->save("column_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Mendapatkan Properti Gaya Tabel**

Gunakan metode [getStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/getstylepreset/) untuk mengambil preset yang diterapkan pada sebuah tabel dan menggunakannya kembali pada tabel lain. Ini mengidentifikasi preset daripada penimpaan format sel individu.

Contoh membuat sebuah tabel, menerapkan [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/php-java/aspose.slides/tablestylepreset/#DarkStyle1), dan membaca kembali preset tersebut. Contoh mencetak nilai integer yang sesuai dengan `DarkStyle1` dan menyimpan tabel dalam `table.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TableStylePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [100, 150];
    $rowHeights = [5, 5, 5];
    $table = $slide->getShapes()->addTable(10, 10, $columnWidths, $rowHeights);
    $table->setStylePreset(TableStylePreset::DarkStyle1);

    $stylePreset = $table->getStylePreset();
    echo java_values($stylePreset) . PHP_EOL;

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Apakah saya dapat menerapkan tema/gaya PowerPoint ke tabel yang sudah dibuat?**

Ya. Tabel mewarisi tema slide/layout/master, dan Anda masih dapat menimpa isian, batas, dan warna teks di atas tema tersebut.

**Apakah saya dapat menyortir baris tabel seperti di Excel?**

Tidak, tabel Aspose.Slides tidak memiliki penyortiran atau filter bawaan. Urutkan data Anda di memori terlebih dahulu, kemudian isi kembali baris tabel sesuai urutan tersebut.

**Apakah saya dapat memiliki kolom berbingkai (striped) sambil mempertahankan warna khusus pada sel tertentu?**

Ya. Aktifkan kolom berbingkai, kemudian timpa sel tertentu dengan format lokal; format tingkat sel memiliki prioritas lebih tinggi daripada gaya tabel.