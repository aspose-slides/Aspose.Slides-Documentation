---
title: Convert PPT dan PPTX ke PDF dalam PHP [Fitur Lanjutan Termasuk]
linktitle: PowerPoint ke PDF
type: docs
weight: 40
url: /id/php-java/convert-powerpoint-to-pdf/
keywords:
- mengonversi PowerPoint
- mengonversi presentasi
- PowerPoint ke PDF
- presentasi ke PDF
- PPT ke PDF
- mengonversi PPT ke PDF
- PPTX ke PDF
- mengonversi PPTX ke PDF
- menyimpan PowerPoint sebagai PDF
- menyimpan PPT sebagai PDF
- menyimpan PPTX sebagai PDF
- mengekspor PPT ke PDF
- mengekspor PPTX ke PDF
- lampiran
- PDF/A1a
- PDF/A1b
- PDF/UA
- PHP
- Aspose.Slides
description: "Ubah PowerPoint PPT/PPTX menjadi PDF berkualitas tinggi dan dapat dicari dalam PHP menggunakan Aspose.Slides, dengan contoh kode cepat dan opsi konversi lanjutan."
---
## **Ikhtisar**

Mengonversi presentasi PowerPoint (PPT, PPTX, ODP, dll.) ke format PDF dalam PHP menawarkan beberapa keuntungan, termasuk kompatibilitas lintas perangkat dan mempertahankan tata letak serta pemformatan presentasi Anda. Panduan ini menunjukkan cara mengonversi presentasi ke dokumen PDF, menggunakan berbagai opsi untuk mengontrol kualitas gambar, menyertakan slide tersembunyi, melindungi PDF dengan kata sandi, mendeteksi substitusi font, memilih slide tertentu untuk konversi, dan menerapkan standar kepatuhan pada dokumen keluaran.

## **Konversi PowerPoint ke PDF**

Dengan Aspose.Slides, Anda dapat mengonversi presentasi dalam format berikut ke PDF:

* **PPT**
* **PPTX**
* **ODP**

Untuk mengonversi presentasi ke PDF, berikan nama file sebagai argumen ke kelas [Presentasi](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) dan kemudian simpan presentasi sebagai PDF menggunakan metode [simpan](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/). Kelas [Presentasi](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) menyediakan metode [simpan](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) yang biasanya digunakan untuk mengonversi presentasi ke PDF.

{{% alert color="info" title="Note" %}}

Aspose.Slides untuk PHP via Java menyisipkan informasi API dan nomor versi ke dalam dokumen keluaran. Misalnya, saat mengonversi presentasi ke PDF, Aspose.Slides mengisi bidang Aplikasi dengan "*Aspose.Slides*" dan bidang Produsen PDF dengan nilai dalam format "*Aspose.Slides v XX.XX*". **Catatan** bahwa Anda tidak dapat menginstruksikan Aspose.Slides untuk mengubah atau menghapus informasi ini dari dokumen keluaran.

{{% /alert %}}

Aspose.Slides memungkinkan Anda mengonversi:

* Seluruh presentasi ke PDF
* Slide tertentu dari presentasi ke PDF

Aspose.Slides mengekspor presentasi ke PDF, memastikan PDF yang dihasilkan sangat mirip dengan presentasi asli. Elemen dan atribut dirender secara akurat dalam konversi, termasuk:

* Gambar
* Kotak teks dan bentuk
* Pemformatan teks
* Pemformatan paragraf
* Tautan hiperteks
* Header dan footer
* Bullet
* Tabel

## **Mengonversi PowerPoint ke PDF**

Proses konversi standar PowerPoint-ke-PDF menggunakan opsi default. Dalam hal ini, Aspose.Slides berusaha mengonversi presentasi yang diberikan ke PDF menggunakan pengaturan optimal pada tingkat kualitas maksimum.

Contoh berikut memuat presentasi dan menyimpan semua slide yang terlihat ke PDF menggunakan pengaturan ekspor default.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}

Aspose menawarkan konverter online gratis [**konverter PowerPoint ke PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) yang memperlihatkan proses konversi presentasi ke PDF. Anda dapat menjalankan pengujian dengan konverter ini untuk melihat implementasi prosedur yang dijelaskan di sini.

{{% /alert %}}

## **Mengonversi PowerPoint ke PDF dengan Opsi**

Aspose.Slides menyediakan opsi khusus—properti pada kelas [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/)—yang memungkinkan Anda menyesuaikan PDF yang dihasilkan, mengunci PDF dengan kata sandi, atau menentukan bagaimana proses konversi harus berjalan.

### **Mengonversi PowerPoint ke PDF dengan Opsi Kustom**

Dengan opsi konversi khusus, Anda dapat menentukan pengaturan kualitas gambar raster yang diinginkan, menentukan cara penanganan metafile, mengatur tingkat kompresi untuk teks, mengonfigurasi DPI untuk gambar, dan lainnya.

Contoh berikut mengekspor presentasi ke PDF 1.5 dengan kualitas JPEG 90, resolusi gambar 300 DPI, metafile disimpan sebagai PNG, dan kompresi teks Flate.

```php
use aspose\slides\PdfCompliance;
use aspose\slides\PdfOptions;
use aspose\slides\PdfTextCompression;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setJpegQuality(90);
$pdfOptions->setSufficientResolution(300);
$pdfOptions->setSaveMetafilesAsPng(true);
$pdfOptions->setTextCompression(PdfTextCompression::Flate);
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Mempertahankan File OLE yang Disematkan sebagai Lampiran PDF**

Jika presentasi berisi buku kerja Excel yang disematkan, Anda mungkin ingin penerima PDF dapat mengakses data buku kerja tersebut serta melihat slide. Panggil [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) dengan `true` untuk mempertahankan file OLE yang disematkan sebagai lampiran dalam PDF yang dihasilkan.

Nilai default adalah `false`: gambar pratinjau atau ikon objek OLE dirender pada halaman PDF, tetapi file yang disematkan tidak disertakan sebagai lampiran. Mengatur opsi ke `true` juga menyertakan data file. Pratinjau tetap menjadi representasi visual; lampiran memungkinkan penerima membuka atau menyimpan file yang disematkan secara terpisah. Objek OLE tidak menjadi lembar kerja Excel interaktif pada halaman PDF.

Contoh berikut memuat presentasi yang sudah berisi buku kerja Excel yang disematkan dan mengekspornya ke PDF dengan buku kerja terlampir.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setIncludeOleData(true);

$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Untuk memeriksa hasilnya:

1. Buka PDF yang diekspor dalam penampil yang mendukung lampiran file, seperti Adobe Acrobat Reader.
2. Buka panel **Attachments** penampil dan temukan buku kerja yang disematkan.
3. Simpan lampiran dan buka di Excel untuk memeriksa datanya, atau buka langsung jika penampil mengizinkannya. Pratinjau pada halaman PDF terpisah dari lampiran.

{{% alert color="info" title="Note" %}}

Standar PDF/A memberlakukan pembatasan pada lampiran: PDF/A-1 melarang file yang disematkan, PDF/A-2 mengizinkan hanya lampiran PDF/A, dan PDF/A-3 mengizinkan tipe file lain, termasuk buku kerja Excel. Ini adalah persyaratan standar, bukan pembatasan khusus Aspose.Slides. Contoh ini menggunakan pengaturan kepatuhan PDF default dan tidak memperlihatkan ekspor PDF/A.

{{% /alert %}}

### **Mengonversi PowerPoint ke PDF dengan Slide Tersembunyi**

Jika presentasi berisi slide tersembunyi, Anda dapat menggunakan metode [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) dari kelas [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) untuk menyertakan slide tersembunyi sebagai halaman dalam PDF yang dihasilkan.

Contoh berikut mengekspor presentasi ke PDF, termasuk semua slide tersembunyi.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setShowHiddenSlides(true);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Mengonversi PowerPoint ke PDF yang Dilindungi Kata Sandi**

Contoh berikut mengekspor presentasi ke PDF yang memerlukan kata sandi `password` untuk dibuka. Izin akses mengizinkan pencetakan, termasuk pencetakan berkualitas tinggi.

```php
use aspose\slides\PdfAccessPermissions;
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setPassword("password");
$pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Mendeteksi Substitusi Font**

Aspose.Slides menyediakan metode [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/) di bawah kelas [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/), memungkinkan Anda mendeteksi substitusi font selama proses konversi presentasi ke PDF.

Contoh berikut mengekspor presentasi ke PDF dan mencetak peringatan substitusi font ke konsol. Peringatan dicetak hanya ketika font yang tidak tersedia diganti selama ekspor.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\ReturnAction;
use aspose\slides\SaveFormat;
use aspose\slides\WarningType;

class FontSubstitutionHandler {
    function warning($warning)
    {
        if (java_values($warning->getWarningType()) == WarningType::DataLoss && $warning->getDescription()->startsWith("Font will be substituted")) {
            echo("Font substitution warning: " . $warning->getDescription());
        }

        return ReturnAction::Continue;
    }
}

$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));

$pdfOptions = new PdfOptions();
$pdfOptions->setWarningCallback($warningCallback);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}

Untuk informasi lebih lanjut tentang substitusi font, lihat artikel [Font Substitution](/slides/id/php-java/font-substitution/).

{{% /alert %}} 

### **Menangani Font Tanpa Gaya Tebal Khusus**

Sebuah presentasi dapat menerapkan format tebal pada teks meskipun fontnya tidak memiliki gaya tebal khusus. Teks tersebut masih dapat terlihat tebal melalui penebalan sintetis, yang secara artifisial menebalkan glif standar. Ketika teks tersebut tampak terlalu berat atau berbeda dari tampilan yang diinginkan dalam PDF, coba panggil [PdfOptions::setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) dengan `true`. Opsi ini merender teks yang terkena sebagai bitmap selama ekspor PDF dan dapat meningkatkan penampilannya untuk font tertentu. Nilai defaultnya adalah `false`.

Presentasi contoh berisi dua kotak teks: satu dengan teks biasa dan satu dengan format tebal pada font yang sama, yang tidak memiliki gaya tebal khusus. Contoh berikut memuat presentasi, mengaktifkan rasterisasi gaya font yang tidak didukung, dan mengekspornya ke PDF:

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setRasterizeUnsupportedFontStyles(true);

$presentation = new Presentation("unsupported-bold.pptx");
try {
    $presentation->save("rasterized.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Pratinjau berikut menunjukkan output dengan opsi dinonaktifkan dan diaktifkan. Dalam contoh ini, teks tebal memiliki goresan lebih berat dengan opsi dinonaktifkan. Dengan opsi diaktifkan, goresannya lebih ringan; teks biasa tidak berubah. Bandingkan hasilnya sebelum memilih pengaturan untuk presentasi Anda.

| Opsi dinonaktifkan (`false`, default) | Opsi diaktifkan (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

Dalam contoh ini, mengaktifkan opsi mengubah hanya teks tebal menjadi bitmap: tidak dapat dipilih, disalin, atau dicari sebagai teks tanpa OCR, dan tepinya tampak lebih lembut pada pembesaran 800%. Teks biasa tetap dapat dicari. Dengan opsi dinonaktifkan, kedua string tetap teks.

Opsi ini meraster teks yang diformat tebal ketika fontnya tidak memiliki gaya tebal khusus. [Font substitution](/slides/id/php-java/font-substitution/) justru memilih font lain ketika font asli tidak tersedia.

## **Mengonversi Slide Terpilih dari PowerPoint ke PDF**

Contoh berikut mengekspor slide 1 dan 3 dari sebuah presentasi ke PDF. Nomor slide dalam array ini berbasis satu, dan presentasi input harus berisi setidaknya tiga slide.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("PowerPoint.pptx");
try {
    $slides = array(1, 3);
    $presentation->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

## **Mengonversi PowerPoint ke PDF dengan Ukuran Slide Kustom**

Contoh berikut menyalin slide pertama dari sebuah presentasi ke presentasi baru dengan ukuran slide 612 × 792 poin (8,5 × 11 inci). Ia menskalakan konten slide agar cocok dan mengekspor satu slide tersebut ke PDF.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$slideWidth = 612.0;
$slideHeight = 792.0;

$presentation = new Presentation("SelectedSlides.pptx");
$resizedPresentation = new Presentation();

try {
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    // Hapus slide kosong yang dibuat saat presentasi baru dibuat.
    $resizedPresentation->getSlides()->removeAt(1);

    $resizedPresentation->save("PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **Mengonversi PowerPoint ke PDF dalam Tampilan Slide Catatan**

Contoh berikut mengekspor presentasi ke PDF, menempatkan catatan pembicara setiap slide di bawah slide. Gunakan presentasi yang berisi catatan pembicara untuk melihat hasilnya.

```php
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull);

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

$presentation = new Presentation("SelectedSlides.pptx");
try {
    $presentation->save("PDF_with_notes.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

## **Aksesibilitas dan Standar Kepatuhan untuk PDF**

Aspose.Slides memungkinkan Anda menggunakan prosedur konversi yang mematuhi [Pedoman Aksesibilitas Konten Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Anda dapat mengekspor dokumen PowerPoint ke PDF menggunakan salah satu standar kepatuhan berikut: **PDF/A1a**, **PDF/A1b**, dan **PDF/UA**.

Kode ini menunjukkan proses konversi PowerPoint-ke-PDF yang menghasilkan beberapa PDF berdasarkan standar kepatuhan yang berbeda:

```php
$presentation = new Presentation("pres.pptx");
try {
    $pdfOptions = new PdfOptions();

    $pdfOptions->setCompliance(PdfCompliance::PdfA1a);
    $presentation->save("pres-a1a-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfA1b);
    $presentation->save("pres-a1b-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfUa);
    $presentation->save("pres-ua-compliance.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}

Aspose.Slides mendukung operasi konversi PDF, memungkinkan Anda mengonversi file PDF ke format file populer. Anda dapat melakukan konversi [PDF ke HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/), [PDF ke gambar](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/), [PDF ke JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/), dan [PDF ke PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/). Operasi konversi PDF ke format khusus—[PDF ke SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/), [PDF ke TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/), dan [PDF ke XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/)—juga didukung.

{{% /alert %}}

> **Catatan:** Saat mengekspor ke PDF/UA, Aspose.Slides memperlakukan grafik kompleks seperti SmartArt, diagram, dan rumus sebagai satu gambar tunggal. Elemen jalur individual tidak dipertahankan sebagai konten terpisah dan dapat ditandai sebagai artefak; teks alternatif hanya disediakan untuk seluruh gambar.

## **FAQ**

**Apakah saya dapat mengonversi beberapa file PowerPoint ke PDF secara massal?**

Ya, Aspose.Slides mendukung konversi batch banyak file PPT atau PPTX ke PDF. Anda dapat mengiterasi file Anda dan menerapkan proses konversi secara programatik.

**Apakah memungkinkan melindungi PDF yang dikonversi dengan kata sandi?**

Ya. Gunakan kelas [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) untuk menetapkan kata sandi dan mendefinisikan izin akses selama proses konversi.

**Bagaimana cara menyertakan slide tersembunyi dalam PDF?**

Panggil [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) dengan `true` pada kelas [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) untuk menyertakan slide tersembunyi dalam PDF yang dihasilkan.

**Apakah Aspose.Slides dapat mempertahankan kualitas gambar tinggi dalam PDF?**

Ya, Anda dapat mengontrol kualitas gambar dengan menggunakan metode seperti [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/) dan [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/) pada kelas [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) untuk memastikan gambar berkualitas tinggi dalam PDF Anda.

**Apakah Aspose.Slides mendukung standar kepatuhan PDF/A?**

Ya, Aspose.Slides memungkinkan Anda mengekspor PDF yang mematuhi [berbagai standar](https://reference.aspose.com/slides/php-java/aspose.slides/pdfcompliance/), termasuk PDF/A1a, PDF/A1b, dan PDF/UA, memastikan dokumen Anda memenuhi persyaratan aksesibilitas dan arsip.

## **Sumber Daya Tambahan**

- [Aspose.Slides for PHP via Java Documentation](/slides/id/php-java/)
- [Aspose.Slides for PHP via Java API Reference](https://reference.aspose.com/slides/php-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)