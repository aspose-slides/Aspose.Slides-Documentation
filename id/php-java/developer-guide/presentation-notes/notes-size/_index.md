---
title: Ubah Ukuran dan Orientasi Halaman Catatan di PHP
linktitle: Ukuran Halaman Catatan
type: docs
weight: 10
url: /id/php-java/notes-size/
keywords:
- ukuran halaman catatan
- orientasi catatan
- catatan lanskap
- catatan potret
- ukuran handout
- PowerPoint
- presentasi
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Baca dan ubah dimensi halaman catatan di Aspose.Slides untuk PHP via Java, ubah orientasi, verifikasi ukuran yang disimpan, dan ekspor catatan atau handout ke PDF dan gambar."
---
## **Gambaran Umum**

Gunakan [Presentation::getNotesSize](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/getnotessize/) untuk mengakses pengaturan halaman catatan presentasi. Metode ini mengembalikan objek [NotesSize](https://reference.aspose.com/slides/id/php-java/aspose.slides/notessize/) yang memiliki metode [setSize](https://reference.aspose.com/slides/id/php-java/aspose.slides/notessize/setsize/) untuk mengatur dimensi halaman. Meskipun objek pengaturan tidak dapat diganti, Anda dapat menetapkan dimensi baru melalui metode ini.

Lebar dan tinggi ditentukan dalam **points**, dengan 72 points per inch. Misalnya, 900 × 600 points adalah 12.5 × 8⅓ inches. Pengaturan ini berlaku untuk seluruh presentasi, bukan untuk catatan slide individu.

| Pengaturan | Tujuan |
| --- | --- |
| [Presentation::getNotesSize](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/getnotessize/) | Mengontrol dimensi halaman catatan dan dimensi halaman yang digunakan untuk ekspor handout. |
| [Presentation::getSlideSize](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/getslidesize/) | Mengontrol dimensi slide presentasi biasa melalui [SlideSize](https://reference.aspose.com/slides/id/php-java/aspose.slides/slidesize/). |

Mengubah salah satu pengaturan tidak secara otomatis mengubah yang lain. Mengubah orientasi halaman catatan juga tidak memutar slide biasa. Lihat [Slide Size](/slides/id/php-java/slide-size/) untuk mengubah ukuran slide biasa.

Contoh di bawah menggunakan `sample.pptx` yang sudah ada. Untuk contoh ekspor, gunakan presentasi dengan setidaknya satu slide yang berisi catatan pembicara. Setiap contoh dapat dijalankan secara terpisah setelah memuat PHP/Java Bridge dan pembungkus Aspose.Slides PHP. Nilai numerik yang dikembalikan oleh Java dikonversi ke nilai PHP dengan `java_values` sebelum perbandingan atau perhitungan.

## **Baca Ukuran dan Orientasi Halaman Catatan**

Baca lebar dan tinggi lalu bandingkan untuk menentukan orientasi: halaman yang lebih lebar adalah lanskap, halaman yang lebih tinggi adalah potret, dan dimensi yang sama menggambarkan halaman berbentuk kotak. Contoh ini mencetak dimensi aktual dalam points, tanpa mengasumsikan ukuran kertas standar.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $size = $presentation->getNotesSize()->getSize();
    $orientation = "Square";

    if (java_values($size->getWidth()) > java_values($size->getHeight())) {
        $orientation = "Landscape";
    } else if (java_values($size->getWidth()) < java_values($size->getHeight())) {
        $orientation = "Portrait";
    }

    echo "Notes page: " . java_values($size->getWidth()) . " x " . java_values($size->getHeight()) . " points" . PHP_EOL;
    echo "Orientation: " . $orientation . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Beralih ke Lanskap Tanpa Mengubah Ukuran Kertas**

Untuk mengubah hanya orientasi, tukar lebar dan tinggi yang ada. Ini mempertahankan panjang kedua sisi, termasuk ukuran kertas khusus. Kondisi di bawah mencegah halaman yang sudah dalam lanskap diubah kembali menjadi potret dan membiarkan halaman berbentuk kotak tidak berubah.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $size = $presentation->getNotesSize()->getSize();

    if (java_values($size->getWidth()) < java_values($size->getHeight())) {
        $width = java_values($size->getWidth());
        $size->setSize(java_values($size->getHeight()), $width);
        $presentation->getNotesSize()->setSize($size);
    }

    $presentation->save("landscape-notes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Untuk orientasi potret, gunakan penugasan yang sama ketika `java_values($size->getWidth()) > java_values($size->getHeight())`. Jangan mengganti dimensi A4 atau Letter kecuali Anda juga ingin mengubah ukuran kertas.

## **Atur dan Verifikasi Ukuran Halaman Catatan Khusus**

Tetapkan kedua dimensi secara bersamaan, lalu gunakan [Presentation::save](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/save/) untuk menulis presentasi. Contoh ini mengatur halaman lanskap 900 × 600-point, menyimpannya sebagai PPTX, dan membuka kembali file yang disimpan untuk memeriksa nilai yang dipertahankan. Perbandingan memperbolehkan toleransi 0.01-point untuk nilai floating‑point; ini bukan jaminan presisi untuk setiap format file.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $expectedSize = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($expectedSize);

    $presentation->save("custom-notes.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("custom-notes.pptx");
    try {
        $actualSize = $reopened->getNotesSize()->getSize();
        $widthMatches = abs(java_values($actualSize->getWidth()) - java_values($expectedSize->getWidth())) < 0.01;
        $heightMatches = abs(java_values($actualSize->getHeight()) - java_values($expectedSize->getHeight())) < 0.01;
        $preserved = $widthMatches && $heightMatches;

        echo "Stored notes page: " . java_values($actualSize->getWidth()) . " x " . java_values($actualSize->getHeight()) . " points" . PHP_EOL;
        echo "Size preserved: " . ($preserved ? "true" : "false") . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Hasil yang diharapkan adalah `900 x 600 points` dan `Size preserved: true`. Memeriksa presentasi yang baru dibuka memverifikasi file yang disimpan, bukan hanya pengaturan dalam memori.

## **Ekspor Catatan dan Handout**

Dimensi halaman menentukan area yang tersedia untuk tata letak catatan atau handout. Dimensi ini tidak mengaktifkan tata letak tersebut sendiri: konfigurasikan opsi ekspor juga. Ekspor slide biasa tetap menggunakan dimensi slide.

### **Ekspor Catatan ke PDF dan PNG**

Tetapkan [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/notescommentslayoutingoptions/) ke [PdfOptions::setSlidesLayoutOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) untuk menyertakan catatan dalam PDF. Contoh ini juga merender slide pertama dengan catatan ke PNG menggunakan [Slide::getImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/slide/#getImage) dan [RenderingOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/renderingoptions/).

Mode [BottomTruncated](https://reference.aspose.com/slides/id/php-java/aspose.slides/notespositions/) menjaga catatan tetap pada satu halaman; catatan yang tidak muat dapat dipotong. PDF menggunakan halaman 900 × 600-point. Pada skala gambar 1 × 1 yang digunakan di bawah, PNG berukuran 900 × 600 piksel. Points menggambarkan geometri halaman; piksel menggambarkan output raster, yang dimensinya juga tergantung pada skala rendering.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\PdfOptions;
use aspose\slides\RenderingOptions;
use aspose\slides\ImageFormat;

$presentation = new Presentation("sample.pptx");
try {
    $size = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($size);

    $layout = new NotesCommentsLayoutingOptions();
    $layout->setNotesPosition(NotesPositions::BottomTruncated);

    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($layout);

    $presentation->save("notes.pdf", SaveFormat::Pdf, $pdfOptions);

    $renderingOptions = new RenderingOptions();
    $renderingOptions->setSlidesLayoutOptions($layout);

    $image = $presentation->getSlides()->get_Item(0)->getImage($renderingOptions, 1, 1);
    try {
        $image->save("first-slide-notes.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Untuk ekspor PDF dengan catatan panjang, [BottomFull](https://reference.aspose.com/slides/id/php-java/aspose.slides/notespositions/) memungkinkan halaman tambahan sesuai kebutuhan. Jangan gunakan mode itu dengan pemanggilan gambar satu slide di atas, yang tidak mendukungnya. Setelah mengubah ukuran, periksa output untuk catatan yang terpotong dan penempatan objek notes‑master yang ada; mengubah dimensi halaman saja tidak menjamin semua konten akan muat. Lihat [Convert PowerPoint to PDF with Notes](/slides/id/php-java/convert-powerpoint-to-pdf-with-notes/) untuk informasi lebih lanjut tentang ekspor catatan.

### **Ekspor Handout ke PDF**

Gunakan [HandoutLayoutingOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/handoutlayoutingoptions/) untuk menampilkan beberapa thumbnail slide pada satu halaman. Contoh berikut mengatur halaman 900 × 600-point dan menggunakan [HandoutType::Handouts4Horizontal](https://reference.aspose.com/slides/id/php-java/aspose.slides/handouttype/) untuk menata hingga empat slide per halaman. Preset horizontal mengontrol urutan slide; orientasi halaman berasal dari lebar dan tingginya.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PdfOptions;
use aspose\slides\HandoutLayoutingOptions;
use aspose\slides\HandoutType;

$presentation = new Presentation("sample.pptx");
try {
    $size = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($size);

    $layout = new HandoutLayoutingOptions();
    $layout->setHandout(HandoutType::Handouts4Horizontal);

    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($layout);

    $presentation->save("handouts.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Mengubah ukuran halaman mengubah area yang tersedia untuk grid handout tanpa mengubah dimensi slide sumber. Untuk gambar handout, gunakan [Presentation::getImages](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/getimages/) dengan tata letak handout, bukan metode gambar slide individu. Di Aspose.Slides, rendering handout tingkat presentasi menggunakan dimensi halaman catatan, sementara pemanggilan gambar slide individu tidak menghasilkan halaman handout. Lihat [Handout Mode](/slides/id/php-java/convert-powerpoint-in-handout-mode/) untuk opsi tata letak.

## **Ukuran Halaman di Penampil, Ekspor, dan Pencetakan**

Jaga agar ukuran presentasi yang disimpan, ukuran halaman yang diekspor, dan ukuran kertas yang dicetak tetap berbeda:

- **Presentation viewers:** Penampil dapat menampilkan atau mencetak catatan menggunakan aturan tata letak sendiri. Jika aplikasi lain menyimpan file, buka kembali dan periksa dimensinya lagi; konversi format aplikasi tersebut dapat menormalkannya.
- **Export formats:** Contoh PDF catatan dan handout di atas menggunakan dimensi halaman yang dikonfigurasi. Gambar raster menggunakan dimensi piksel integer dan skala rendering, sehingga nilai point pecahan dapat dibulatkan dalam output gambar. Ekspor slide biasa tidak menerapkan ukuran halaman catatan.
- **Printer drivers:** Pemilihan kertas, rotasi otomatis, dan pengaturan fit‑to‑page dapat mengubah output fisik tanpa mengubah dimensi yang disimpan dalam presentasi atau PDF. Untuk ukuran kertas tertentu, sesuaikan pengaturan printer dan periksa pratinjau cetak.

## **FAQ**

**Apakah saya dapat mengatur ukuran catatan hanya untuk satu slide?**

Ukuran halaman catatan adalah pengaturan tingkat presentasi. Slide individu dapat memiliki konten catatan yang berbeda, tetapi properti ini tidak menyediakan ukuran halaman terpisah untuk setiap slide.

**Mengapa mengubah orientasi catatan tidak mengubah slide saya?**

Halaman catatan dan slide biasa memiliki dimensi yang independen. Gunakan pengaturan ukuran slide reguler ketika Anda ingin mengubah ukuran slide itu sendiri.

**Mengapa hasil yang disimpan atau dicetak memiliki ukuran yang berbeda?**

Pertama, buka kembali presentasi yang disimpan dan bandingkan dimensi catatannya. Jika berubah, periksa apakah penyimpanan atau konversi file di aplikasi lain mengubah pengaturan halaman. Jika tidak, periksa tata letak ekspor, skala gambar, pengaturan penampil, dan pemilihan kertas printer.