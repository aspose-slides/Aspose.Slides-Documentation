---
title: Simpan Presentasi di PHP
linktitle: Simpan Presentasi
type: docs
weight: 80
url: /id/php-java/save-presentation/
keywords:
- simpan PowerPoint
- simpan OpenDocument
- simpan presentasi
- simpan slide
- simpan PPT
- simpan PPTX
- simpan ODP
- presentasi ke file
- presentasi ke stream
- jenis tampilan pradefinisi
- Format Strict Office Open XML
- mode Zip64
- menyegarkan thumbnail
- progres penyimpanan
- PHP
- Aspose.Slides
description: "Temukan cara menyimpan presentasi menggunakan Aspose.Slides untuk PHP via Java — mengekspor ke PowerPoint atau OpenDocument sambil mempertahankan tata letak, font, dan efek."
---
## **Gambaran Umum**

[Open Presentations in PHP](/slides/id/php-java/open-presentation/) menjelaskan cara menggunakan kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) untuk membuka sebuah presentasi. Artikel ini menjelaskan cara membuat dan menyimpan presentasi. Kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) berisi konten sebuah presentasi. Baik Anda membuat presentasi dari awal maupun memodifikasi yang sudah ada, Anda perlu menyimpannya setelah selesai. Dengan Aspose.Slides untuk PHP, Anda dapat menyimpan ke **file** atau **stream**. Artikel ini menjelaskan berbagai cara menyimpan sebuah presentasi.

## **Simpan Presentasi ke File**

Simpan sebuah presentasi ke file dengan memanggil metode `save` milik kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/). Berikan nama file dan format penyimpanan ke metode tersebut. Contoh berikut menunjukkan cara menyimpan sebuah presentasi dengan Aspose.Slides.

```php
// Membuat instance kelas Presentation yang mewakili file presentasi.
$presentation = new Presentation();
try {
    // Lakukan beberapa pekerjaan di sini...

    // Simpan presentasi ke file.
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Simpan Presentasi ke Stream**

Anda dapat menyimpan sebuah presentasi ke stream dengan memberikan sebuah output stream ke metode `save` milik kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/). Sebuah presentasi dapat ditulis ke banyak jenis stream. Pada contoh di bawah, kami membuat sebuah presentasi baru dan menyimpannya ke sebuah file stream.

```php
// Membuat instance kelas Presentation yang mewakili file presentasi.
$presentation = new Presentation();
try {
    $fileStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        // Simpan presentasi ke stream.
        $presentation->save($fileStream, SaveFormat::Pptx);
    } finally {
        $fileStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **Simpan Presentasi dengan Jenis Tampilan Pradefinisi**

Aspose.Slides memungkinkan Anda mengatur tampilan awal yang digunakan PowerPoint ketika presentasi yang dihasilkan dibuka melalui kelas [ViewProperties](https://reference.aspose.com/slides/id/php-java/aspose.slides/viewproperties/). Gunakan metode [setLastView](https://reference.aspose.com/slides/id/php-java/aspose.slides/viewproperties/#setLastView) dengan nilai dari enumerasi [ViewType](https://reference.aspose.com/slides/id/php-java/aspose.slides/viewtype/).

```php
$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Simpan Presentasi dalam Format Strict Office Open XML**

Aspose.Slides memungkinkan Anda menyimpan sebuah presentasi dalam format Strict Office Open XML. Gunakan kelas [PptxOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/pptxoptions/) dan atur properti conformance-nya saat menyimpan. Jika Anda mengatur [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/id/php-java/aspose.slides/conformance/#Iso29500_2008_Strict), file output akan disimpan dalam format Strict Office Open XML.

Contoh di bawah membuat sebuah presentasi dan menyimpannya dalam format Strict Office Open XML.

```php
$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

// Membuat instance kelas Presentation yang mewakili file presentasi.
$presentation = new Presentation();
try {
    // Simpan presentasi dalam format Strict Office Open XML.
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Simpan Presentasi dalam Format Office Open XML dengan Mode Zip64**

File Office Open XML adalah arsip ZIP yang memberlakukan batas 4 GB (2^32 byte) pada ukuran tak terkompresi suatu file, ukuran terkompresi suatu file, dan total ukuran arsip, serta membatasi arsip hingga 65 535 (2^16‑1) file. Ekstensi format ZIP64 mengangkat batas‑batas ini menjadi 2^64.

Metode [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/id/php-java/aspose.slides/pptxoptions/#setZip64Mode) memungkinkan Anda memilih kapan menggunakan ekstensi format ZIP64 saat menyimpan file Office Open XML.

Metode ini dapat digunakan dengan mode berikut:

- [IfNecessary](https://reference.aspose.com/slides/id/php-java/aspose.slides/zip64mode/#IfNecessary) menggunakan ekstensi format ZIP64 hanya bila presentasi melampaui batas di atas. Ini adalah mode default.
- [Never](https://reference.aspose.com/slides/id/php-java/aspose.slides/zip64mode/#Never) tidak pernah menggunakan ekstensi format ZIP64.
- [Always](https://reference.aspose.com/slides/id/php-java/aspose.slides/zip64mode/#Always) selalu menggunakan ekstensi format ZIP64.

Kode berikut menunjukkan cara menyimpan sebuah presentasi sebagai PPTX dengan ekstensi format ZIP64 diaktifkan:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setZip64Mode(Zip64Mode::Always);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("OutputZip64.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
Saat Anda menyimpan dengan [Zip64Mode.Never](https://reference.aspose.com/slides/id/php-java/aspose.slides/zip64mode/#Never), sebuah [PptxException](https://reference.aspose.com/slides/id/php-java/aspose.slides/pptxexception/) dilemparkan bila presentasi tidak dapat disimpan dalam format ZIP32.
{{% /alert %}}

## **Simpan Presentasi tanpa Menyegarkan Thumbnail**

Metode [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/id/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) mengontrol pembuatan thumbnail saat menyimpan presentasi ke PPTX:

- Jika diatur ke `true`, thumbnail disegarkan selama penyimpanan. Ini adalah nilai default.
- Jika diatur ke `false`, thumbnail saat ini dipertahankan. Jika presentasi tidak memiliki thumbnail, tidak ada yang dibuat.

Pada kode di bawah, presentasi disimpan ke PPTX tanpa menyegarkan thumbnail-nya.

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setRefreshThumbnail(false);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pptx", SaveFormat::Pptx, $pptxOptions);
}
finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}
Opsi ini membantu mengurangi waktu yang diperlukan untuk menyimpan sebuah presentasi dalam format PPTX.
{{% /alert %}}

## **Laporan Progres Penyimpanan dalam Persentase**

Pelaporan progres penyimpanan dikonfigurasi melalui metode [setProgressCallback](https://reference.aspose.com/slides/id/php-java/aspose.slides/saveoptions/#setProgressCallback) pada [SaveOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/saveoptions/) dan subclass‑nya. Berikan sebuah proxy Java yang mengimplementasikan antarmuka [IProgressCallback](https://reference.aspose.com/slides/id/java/com.aspose.slides/iprogresscallback/); selama ekspor, callback menerima pembaruan persentase secara periodik.

Potongan kode berikut menunjukkan cara menggunakan `IProgressCallback`.

```php
class ExportProgressHandler {
    function reporting($progressValue) {
        // Gunakan nilai persentase kemajuan di sini.
        $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
        echo($progress . "% of the file has been converted.");
    }
}

$progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));

$saveOptions = new PdfOptions();
$saveOptions->setProgressCallback($progressHandler);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pdf", SaveFormat::Pdf, $saveOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}
Aspose telah mengembangkan sebuah aplikasi [PowerPoint Splitter gratis](https://products.aspose.app/slides/id/splitter) menggunakan API‑nya sendiri. Aplikasi ini memungkinkan Anda membagi sebuah presentasi menjadi beberapa file dengan menyimpan slide terpilih sebagai file PPTX atau PPT baru.
{{% /alert %}}

## **FAQ**

**Apakah "fast save" (penyimpanan inkremental) didukung sehingga hanya perubahan yang ditulis?**

Tidak. Penyimpanan selalu membuat file target lengkap setiap kali; "fast save" inkremental tidak didukung.

**Apakah aman untuk menyimpan instance Presentation yang sama dari banyak thread?**

Tidak. Sebuah [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) tidak bersifat thread‑safe; simpanlah dari satu thread saja.

**Apa yang terjadi pada hyperlink dan file yang ditautkan secara eksternal saat menyimpan?**

[Hyperlink](/slides/id/php-java/manage-hyperlinks/) dipertahankan. File yang ditautkan secara eksternal (misalnya video dengan jalur relatif) tidak disalin secara otomatis—pastikan jalur yang dirujuk tetap dapat diakses.

**Bisakah saya mengatur/menyimpan metadata dokumen (Penulis, Judul, Perusahaan, Tanggal)?**

Ya. properti dokumen standar [/slides/id/php-java/presentation-properties/] didukung dan akan ditulis ke file saat disimpan.