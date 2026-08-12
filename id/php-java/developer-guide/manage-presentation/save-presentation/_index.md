---
title: Menyimpan Presentasi di PHP
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
- tipe tampilan yang telah ditentukan
- Format Strict Office Open XML
- mode Zip64
- memperbarui thumbnail
- progres penyimpanan
- PHP
- Aspose.Slides
description: "Temukan cara menyimpan presentasi menggunakan Aspose.Slides untuk PHP melalui Java — mengekspor ke PowerPoint atau OpenDocument sambil mempertahankan tata letak, font, dan efek."
---
## **Ringkasan**

[Open Presentations in PHP](/slides/id/php-java/open-presentation/) menjelaskan cara menggunakan kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) untuk membuka presentasi. Artikel ini menjelaskan cara membuat dan menyimpan presentasi. Kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) berisi isi presentasi. Baik Anda membuat presentasi dari awal atau memodifikasi yang sudah ada, Anda perlu menyimpannya setelah selesai. Dengan Aspose.Slides for PHP, Anda dapat menyimpan ke **file** atau **stream**. Artikel ini menjelaskan berbagai cara menyimpan presentasi.

## **Menyimpan Presentasi ke File**

Simpan presentasi ke file dengan memanggil metode `save` pada kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/). Berikan nama file dan format penyimpanan ke metode tersebut. Contoh berikut menunjukkan cara menyimpan presentasi dengan Aspose.Slides.

```php
// Instansiasi kelas Presentation yang mewakili file presentasi.
$presentation = new Presentation();
try {
    // Lakukan beberapa pekerjaan di sini...

    // Simpan presentasi ke file.
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Menyimpan Presentasi ke Stream**

Anda dapat menyimpan presentasi ke stream dengan melewatkan output stream ke metode `save` pada kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/). Presentasi dapat ditulis ke banyak jenis stream. Pada contoh di bawah, kami membuat presentasi baru dan menyimpannya ke file stream.

```php
// Instansiasi kelas Presentation yang mewakili file presentasi.
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

## **Menyimpan Presentasi dengan Tipe Tampilan yang Sudah Ditetapkan**

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

## **Menyimpan Presentasi dalam Format Strict Office Open XML**

Aspose.Slides memungkinkan Anda menyimpan presentasi dalam format Strict Office Open XML. Gunakan kelas [PptxOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/pptxoptions/) dan atur properti conformance saat menyimpan. Jika Anda mengatur [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/id/php-java/aspose.slides/conformance/#Iso29500_2008_Strict), file output disimpan dalam format Strict Office Open XML.

Contoh di bawah membuat presentasi dan menyimpannya dalam format Strict Office Open XML.

```php
$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

// Instansiasi kelas Presentation yang mewakili file presentasi.
$presentation = new Presentation();
try {
    // Simpan presentasi dalam format Strict Office Open XML.
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Menyimpan Presentasi dalam Format Office Open XML dengan Mode Zip64**

File Office Open XML adalah arsip ZIP yang membatasi ukuran tidak terkompresi, ukuran terkompresi, dan total ukuran arsip masing‑masing sampai 4 GB (2^32 byte), serta membatasi jumlah file dalam arsip sampai 65 535 (2^16‑1). Ekstensi format ZIP64 menaikkan batas‑batas ini menjadi 2^64.

Metode [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/id/php-java/aspose.slides/pptxoptions/#setZip64Mode) memungkinkan Anda memilih kapan menggunakan ekstensi format ZIP64 saat menyimpan file Office Open XML.

Metode ini dapat dipakai dengan mode berikut:

- [IfNecessary](https://reference.aspose.com/slides/id/php-java/aspose.slides/zip64mode/#IfNecessary) menggunakan ekstensi ZIP64 hanya bila presentasi melebihi batas di atas. Ini adalah mode default.
- [Never](https://reference.aspose.com/slides/id/php-java/aspose.slides/zip64mode/#Never) tidak pernah menggunakan ekstensi ZIP64.
- [Always](https://reference.aspose.com/slides/id/php-java/aspose.slides/zip64mode/#Always) selalu menggunakan ekstensi ZIP64.

Kode berikut memperlihatkan cara menyimpan presentasi sebagai file PPTX dengan ekstensi format ZIP64 diaktifkan:

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
When you save with [Zip64Mode.Never](https://reference.aspose.com/slides/id/php-java/aspose.slides/zip64mode/#Never), a [PptxException](https://reference.aspose.com/slides/id/php-java/aspose.slides/pptxexception/) is thrown if the presentation cannot be saved in ZIP32 format.
{{% /alert %}}

## **Menyimpan Presentasi dalam Format Office Open XML dengan Tingkat Kompresi**

Saat bekerja dengan presentasi berukuran besar, Anda dapat menyesuaikan tingkat kompresi untuk menyeimbangkan ukuran file dan waktu proses. Bergantung pada kebutuhan, Anda mungkin lebih memilih proses yang lebih cepat atau file output yang lebih kecil.

Aspose.Slides menyediakan metode [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/id/php-java/aspose.slides/pptxoptions/#setCompressionLevel) yang memungkinkan Anda menentukan tingkat kompresi yang digunakan saat menyimpan presentasi dalam format Office Open XML.

Tingkat kompresi yang tersedia:

- [**None**](https://reference.aspose.com/slides/id/php-java/aspose.slides/compressionlevel/#None): Tidak ada kompresi. File disimpan apa adanya.
- [**Level1**](https://reference.aspose.com/slides/id/php-java/aspose.slides/compressionlevel/#Level1): Kompresi tercepat dengan rasio kompresi terendah.
- [**Level2**](https://reference.aspose.com/slides/id/php-java/aspose.slides/compressionlevel/#Level2): Kompresi lebih cepat dengan rasio sedikit lebih baik daripada **Level1**.
- [**Level3**](https://reference.aspose.com/slides/id/php-java/aspose.slides/compressionlevel/#Level3): Memberikan kompresi lebih baik daripada **Level2** dengan dampak sedang pada waktu proses.
- [**Level4**](https://reference.aspose.com/slides/id/php-java/aspose.slides/compressionlevel/#Level4): Memberikan kompresi lebih baik daripada **Level3**.
- [**Level5**](https://reference.aspose.com/slides/id/php-java/aspose.slides/compressionlevel/#Level5): Memperbaiki kompresi dibanding **Level4** dengan waktu proses tambahan.
- [**Level6**](https://reference.aspose.com/slides/id/php-java/aspose.slides/compressionlevel/#Level6): Kompresi standar yang menawarkan keseimbangan baik antara kecepatan proses dan ukuran file. Ini adalah *tingkat kompresi default*.
- [**Level7**](https://reference.aspose.com/slides/id/php-java/aspose.slides/compressionlevel/#Level7): Memberikan kompresi lebih baik daripada **Level6** dengan proses yang lebih lambat.
- [**Level8**](https://reference.aspose.com/slides/id/php-java/aspose.slides/compressionlevel/#Level8): Memberikan kompresi lebih baik daripada **Level7**.
- [**Level9**](https://reference.aspose.com/slides/id/php-java/aspose.slides/compressionlevel/#Level9): Kompresi maksimum. Menghasilkan ukuran file terkecil dengan biaya waktu proses terpanjang.

Contoh berikut memperlihatkan cara menyimpan presentasi sebagai file PPTX *tanpa kompresi*:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setCompressionLevel(CompressionLevel::None);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Sample-out.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

Contoh ini menunjukkan cara menyimpan presentasi sebagai file PPTX dengan *kompresi maksimum*:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setCompressionLevel(CompressionLevel::Level9);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Sample-level9.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

## **Menyimpan Presentasi tanpa Memperbarui Thumbnail**

Metode [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/id/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) mengendalikan pembuatan thumbnail saat menyimpan presentasi ke PPTX:

- Jika disetel ke `true`, thumbnail diperbarui selama penyimpanan. Ini adalah nilai default.
- Jika disetel ke `false`, thumbnail yang ada dipertahankan. Jika presentasi tidak memiliki thumbnail, tidak ada yang akan dibuat.

Pada kode di bawah, presentasi disimpan ke PPTX tanpa memperbarui thumbnailnya.

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
This option helps reduce the time required to save a presentation in PPTX format.
{{% /alert %}}

## **Menyimpan Pembaruan Progres dalam Persentase**

Pelaporan progres penyimpanan dikonfigurasi melalui metode [setProgressCallback](https://reference.aspose.com/slides/id/php-java/aspose.slides/saveoptions/#setProgressCallback) pada [SaveOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/saveoptions/) dan subclass‑nya. Sediakan proxy Java yang mengimplementasikan antarmuka [IProgressCallback](https://reference.aspose.com/slides/id/java/com.aspose.slides/iprogresscallback/); selama ekspor, callback menerima pembaruan persentase secara periodik.

Cuplikan kode berikut menunjukkan cara menggunakan `IProgressCallback`.

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
Aspose has developed a [free PowerPoint Splitter app](https://products.aspose.app/slides/id/splitter) using its own API. The app lets you split a presentation into multiple files by saving selected slides as new PPTX or PPT files.
{{% /alert %}}

## **FAQ**

**Apakah \"fast save\" (penyimpanan incremental) didukung sehingga hanya perubahan yang ditulis?**

Tidak. Setiap penyimpanan membuat file target lengkap; \"fast save\" incremental tidak didukung.

**Apakah aman untuk menyimpan instance Presentation yang sama dari beberapa thread?**

Tidak. Sebuah [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) **tidak thread‑safe** (/slides/id/php-java/multithreading/); simpanlah dari satu thread saja.

**Apa yang terjadi pada hyperlink dan file yang ditautkan secara eksternal saat menyimpan?**

[Hyperlink](/slides/id/php-java/manage-hyperlinks/) dipertahankan. File yang ditautkan secara eksternal (misalnya video dengan jalur relatif) tidak disalin secara otomatis—pastikan jalur yang direferensikan masih dapat diakses.

**Bisakah saya mengatur/menyimpan metadata dokumen (Penulis, Judul, Perusahaan, Tanggal)?**

Ya. Properti [document](/slides/id/php-java/presentation-properties/) standar didukung dan akan ditulis ke file saat disimpan.