---
title: Konversi PPT dan PPTX ke PDF dalam PHP [Fitur Lanjutan Disertakan]
linktitle: PowerPoint ke PDF
type: docs
weight: 40
url: /id/php-java/convert-powerpoint-to-pdf/
keywords:
- konversi PowerPoint
- konversi presentasi
- PowerPoint ke PDF
- presentasi ke PDF
- PPT ke PDF
- konversi PPT ke PDF
- PPTX ke PDF
- konversi PPTX ke PDF
- simpan PowerPoint sebagai PDF
- simpan PPT sebagai PDF
- simpan PPTX sebagai PDF
- ekspor PPT ke PDF
- ekspor PPTX ke PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- PHP
- Aspose.Slides
description: "Konversi PowerPoint PPT/PPTX ke PDF berkualitas tinggi dan dapat dicari dalam PHP menggunakan Aspose.Slides, dengan contoh kode cepat dan opsi konversi lanjutan."
---
## **Gambaran Umum**

Mengonversi presentasi PowerPoint (PPT, PPTX, ODP, dll.) ke format PDF dalam PHP menawarkan beberapa keuntungan, termasuk kompatibilitas di berbagai perangkat dan menjaga tata letak serta pemformatan presentasi Anda. Panduan ini menunjukkan cara mengonversi presentasi ke dokumen PDF, menggunakan berbagai opsi untuk mengontrol kualitas gambar, menyertakan slide tersembunyi, melindungi file PDF dengan kata sandi, mendeteksi penggantian font, memilih slide tertentu untuk konversi, dan menerapkan standar kepatuhan pada dokumen output.

## **Konversi PowerPoint ke PDF**

Menggunakan Aspose.Slides, Anda dapat mengonversi presentasi dalam format berikut ke PDF:

* **PPT**
* **PPTX**
* **ODP**

Untuk mengonversi presentasi ke PDF, berikan nama file sebagai argumen ke kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation) dan kemudian simpan presentasi sebagai PDF menggunakan metode `save`. Kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation) menyediakan metode `save` yang biasanya digunakan untuk mengonversi presentasi ke PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides untuk PHP via Java menyisipkan informasi API dan nomor versinya ke dalam dokumen output. Misalnya, saat mengonversi presentasi ke PDF, Aspose.Slides mengisi bidang Application dengan "*Aspose.Slides*" dan bidang PDF Producer dengan nilai dalam format "*Aspose.Slides v XX.XX*". **Catatan** bahwa Anda tidak dapat menginstruksikan Aspose.Slides untuk mengubah atau menghapus informasi ini dari dokumen output.

{{% /alert %}}

Aspose.Slides memungkinkan Anda mengonversi:

* Seluruh presentasi ke PDF
* Slide tertentu dari presentasi ke PDF

Aspose.Slides mengekspor presentasi ke PDF, memastikan PDF hasilnya sangat mirip dengan presentasi asli. Elemen dan atribut dirender secara akurat dalam konversi, termasuk:

* Gambar
* Kotak teks dan bentuk
* Pemformatan teks
* Pemformatan paragraf
* Hyperlink
* Header dan footer
* Bullet
* Tabel

## **Konversi PowerPoint ke PDF**

Proses konversi standar PowerPoint ke PDF menggunakan opsi default. Dalam hal ini, Aspose.Slides berusaha mengonversi presentasi yang diberikan ke PDF menggunakan pengaturan optimal pada tingkat kualitas maksimum.

```php
# Membuat instance kelas Presentation yang mewakili file PowerPoint atau OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Simpan presentasi sebagai PDF.
    $presentation->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

{{%  alert  color="primary"  %}} 

Aspose menawarkan konverter **PowerPoint to PDF** online gratis [**PowerPoint to PDF converter**](https://products.aspose.app/slides/id/conversion/ppt-to-pdf) yang menampilkan proses konversi presentasi ke PDF. Anda dapat melakukan pengujian dengan konverter ini untuk implementasi langsung prosedur yang dijelaskan di sini.

{{% /alert %}}

## **Konversi PowerPoint ke PDF dengan Opsi**

Aspose.Slides menyediakan opsi khusus—properti di kelas [PdfOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/PdfOptions)—yang memungkinkan Anda menyesuaikan PDF yang dihasilkan, mengunci PDF dengan kata sandi, atau menentukan bagaimana proses konversi harus dijalankan.

### **Konversi PowerPoint ke PDF dengan Opsi Kustom**

Dengan opsi konversi kustom, Anda dapat menentukan pengaturan kualitas gambar raster yang diinginkan, menentukan cara penanganan metafile, mengatur tingkat kompresi teks, mengkonfigurasi DPI untuk gambar, dan lainnya.

Contoh kode di bawah ini menunjukkan cara mengonversi presentasi PowerPoint ke PDF dengan beberapa opsi kustom.

```php
# Membuat instance kelas PdfOptions.
$pdfOptions = new PdfOptions();

# Atur kualitas untuk gambar JPG.
$pdfOptions->setJpegQuality(90);

# Atur DPI untuk gambar.
$pdfOptions->setSufficientResolution(300);

# Atur perilaku untuk metafile.
$pdfOptions->setSaveMetafilesAsPng(true);

# Atur tingkat kompresi teks untuk konten tekstual.
$pdfOptions->setTextCompression(PdfTextCompression::Flate);

# Definisikan mode kepatuhan PDF.
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

# Membuat instance kelas Presentation yang mewakili file PowerPoint atau OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Simpan presentasi sebagai dokumen PDF.
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Konversi PowerPoint ke PDF dengan Slide Tersembunyi**

Jika sebuah presentasi berisi slide tersembunyi, Anda dapat menggunakan metode [setShowHiddenSlides](https://reference.aspose.com/slides/id/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) dari kelas [PdfOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/PdfOptions) untuk menyertakan slide tersembunyi sebagai halaman dalam PDF yang dihasilkan.

Kode ini menunjukkan cara mengonversi presentasi PowerPoint ke PDF dengan slide tersembunyi disertakan:

```php
# Membuat instance kelas Presentation yang mewakili file PowerPoint atau OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Membuat instance kelas PdfOptions.
    $pdfOptions = new PdfOptions();

    # Menambahkan slide tersembunyi.
    $pdfOptions->setShowHiddenSlides(true);

    # Simpan presentasi sebagai PDF.
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Konversi PowerPoint ke PDF yang Dilindungi Kata Sandi**

Kode ini menunjukkan cara mengonversi presentasi PowerPoint menjadi PDF yang dilindungi kata sandi menggunakan parameter perlindungan dari kelas [PdfOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/pdfoptions/):

```php
# Membuat instance kelas Presentation yang mewakili file PowerPoint atau OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Membuat instance kelas PdfOptions.
    $pdfOptions = new PdfOptions();

    # Atur kata sandi PDF dan izin akses.
    $pdfOptions->setPassword("password");
    $pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

    # Simpan presentasi sebagai PDF.
    $presentation->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Mendeteksi Penggantian Font**

Aspose.Slides menyediakan metode [setWarningCallback](https://reference.aspose.com/slides/id/php-java/aspose.slides/saveoptions/#setWarningCallback) pada kelas [PdfOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/pdfoptions/), yang memungkinkan Anda mendeteksi penggantian font selama proses konversi presentasi ke PDF.

Kode ini menunjukkan cara mendeteksi penggantian font:

```php
class FontSubstitutionHandler {
    function warning($warning)
    {
        if (java_values($warning->getWarningType()) == WarningType::DataLoss &&
        $warning->getDescription()->startsWith("Font will be substituted")) {
            echo("Font substitution warning: " . $warning->getDescription());
        }

        return ReturnAction::Continue;
    }
}

// Atur callback peringatan pada opsi PDF.
$pdfOptions = new PdfOptions();
$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));
$pdfOptions->setWarningCallback($warningCallback);

// Buat instance kelas Presentation yang mewakili file PowerPoint atau OpenDocument.
$presentation = new Presentation("sample.pptx");
try {
    // Simpan presentasi sebagai PDF.
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{%  alert color="primary"  %}} 

Untuk informasi lebih lanjut tentang penggantian font, lihat artikel [Font Substitution](/slides/id/php-java/font-substitution/).

{{% /alert %}} 

## **Konversi Slide Terpilih dalam PowerPoint ke PDF**

Kode ini menunjukkan cara mengonversi hanya slide tertentu dari presentasi PowerPoint ke PDF:

```php
# Membuat instance kelas Presentation yang mewakili file PowerPoint atau OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Atur array nomor slide.
    $slides = array(1, 3);

    # Simpan presentasi sebagai PDF.
    $presentation->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

## **Konversi PowerPoint ke PDF dengan Ukuran Slide Kustom**

Kode ini menunjukkan cara mengonversi presentasi PowerPoint ke PDF dengan ukuran slide yang ditentukan:

```php
$slideWidth = 612.0;
$slideHeight = 792.0;

# Membuat instance kelas Presentation yang mewakili file PowerPoint atau OpenDocument.
$presentation = new Presentation("SelectedSlides.pptx");

# Membuat presentasi baru dengan ukuran slide yang disesuaikan.
$resizedPresentation = new Presentation();

try {
    # Atur ukuran slide kustom.
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);

    # Gandakan slide pertama dari presentasi asli.
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    # Simpan presentasi yang diubah ukurannya ke PDF dengan catatan.
    $resizedPresentation->save("PDFnotes_out.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **Konversi PowerPoint ke PDF dalam Tampilan Slide Catatan**

Kode ini menunjukkan cara mengonversi presentasi PowerPoint ke PDF yang menyertakan catatan:

```php
# Membuat instance kelas Presentation yang mewakili file PowerPoint atau OpenDocument.
$presentation = new Presentation("SelectedSlides.pptx");
try {
    # Mengonfigurasi opsi PDF dengan Tata Letak Catatan.
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($notesOptions);

    # Simpan presentasi ke PDF dengan catatan.
    $presentation->save("PDF_with_notes.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

## **Standar Aksesibilitas dan Kepatuhan untuk PDF**

Aspose.Slides memungkinkan Anda menggunakan prosedur konversi yang mematuhi [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Anda dapat mengekspor dokumen PowerPoint ke PDF menggunakan salah satu standar kepatuhan berikut: **PDF/A1a**, **PDF/A1b**, dan **PDF/UA**.

Kode ini menunjukkan proses konversi PowerPoint ke PDF yang menghasilkan beberapa PDF berdasarkan standar kepatuhan yang berbeda:

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

{{% alert title="Note" color="warning" %}} 

Aspose.Slides mendukung operasi konversi PDF, memungkinkan Anda mengonversi file PDF ke format file populer. Anda dapat melakukan konversi [PDF ke HTML](https://products.aspose.com/slides/id/php-java/conversion/pdf-to-html/), [PDF ke gambar](https://products.aspose.com/slides/id/php-java/conversion/pdf-to-image/), [PDF ke JPG](https://products.aspose.com/slides/id/php-java/conversion/pdf-to-jpg/), dan [PDF ke PNG](https://products.aspose.com/slides/id/php-java/conversion/pdf-to-png/). Operasi konversi PDF ke format khusus lainnya—[PDF ke SVG](https://products.aspose.com/slides/id/php-java/conversion/pdf-to-svg/), [PDF ke TIFF](https://products.aspose.com/slides/id/php-java/conversion/pdf-to-tiff/), dan [PDF ke XML](https://products.aspose.com/slides/id/php-java/conversion/pdf-to-xml/)—juga didukung.

{{% /alert %}}

> **Catatan:** Saat mengekspor ke PDF/UA, Aspose.Slides memperlakukan grafik kompleks seperti SmartArt, diagram, dan formula sebagai satu gambar. Elemen jalur individual tidak dipertahankan sebagai konten terpisah dan dapat ditandai sebagai artefak; teks alternatif hanya disediakan untuk seluruh gambar.

## **FAQ**

**Apakah saya dapat mengonversi banyak file PowerPoint ke PDF secara massal?**

Ya, Aspose.Slides mendukung konversi batch banyak file PPT atau PPTX ke PDF. Anda dapat mengiterasi file Anda dan menerapkan proses konversi secara programatis.

**Tentu saja. Gunakan kelas [PdfOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/pdfoptions/) untuk mengatur kata sandi dan mendefinisikan izin akses selama proses konversi.**

**Bagaimana cara menyertakan slide tersembunyi dalam PDF?**

Gunakan metode `setShowHiddenSlides` di kelas [PdfOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/pdfoptions/) untuk menyertakan slide tersembunyi dalam PDF yang dihasilkan.

**Apakah Aspose.Slides dapat mempertahankan kualitas gambar tinggi dalam PDF?**

Ya, Anda dapat mengontrol kualitas gambar dengan menggunakan metode seperti `setJpegQuality` dan `setSufficientResolution` di kelas [PdfOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/pdfoptions/) untuk memastikan gambar berkualitas tinggi dalam PDF Anda.

**Apakah Aspose.Slides mendukung standar kepatuhan PDF/A?**

Ya, Aspose.Slides memungkinkan Anda mengekspor PDF yang mematuhi berbagai standar, termasuk PDF/A1a, PDF/A1b, dan PDF/UA, memastikan dokumen Anda memenuhi persyaratan aksesibilitas dan arsip.

## **Sumber Daya Tambahan**

- [Dokumentasi Aspose.Slides untuk PHP via Java](/slides/id/php-java/)
- [Referensi API Aspose.Slides untuk PHP via Java](https://reference.aspose.com/slides/id/php-java/)
- [Konverter Online Gratis Aspose]https://products.aspose.app/slides/id/conversion