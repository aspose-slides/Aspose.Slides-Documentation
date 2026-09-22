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
- Format Office Open XML Strict
- mode Zip64
- menyegarkan thumbnail
- progres penyimpanan
- PHP
- Aspose.Slides
description: "Simpan presentasi PowerPoint dan OpenDocument ke file atau stream di PHP dengan Aspose.Slides, serta konfigurasikan output PPTX dan pelaporan progres."
---
## **Gambaran Umum**

Setelah Anda membuat presentasi atau [membuka presentasi yang ada](/slides/id/php-java/open-presentation/), gunakan metode [Presentation::save](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#save) untuk menulis hasilnya. Aspose.Slides untuk PHP via Java dapat menyimpan presentasi ke file atau stream dalam format PowerPoint, OpenDocument, PDF, dan format lainnya. Bagian berikut mencakup operasi penyimpanan standar dan opsi yang tersedia untuk output PPTX.

## **Menyimpan Presentasi ke File**

Untuk menyimpan presentasi ke file, berikan jalur output dan nilai [SaveFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/saveformat/) ke metode [Presentation::save](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#save). Nilai format menentukan jenis file yang dibuat oleh Aspose.Slides.

Contoh berikut membuat presentasi dan menyimpannya sebagai file PPTX:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    // Tambahkan atau ubah konten presentasi di sini.

    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Menyimpan Presentasi dalam Format Aslinya**

Untuk contoh deteksi file dan stream, perilaku presentasi yang baru dibuat, serta perbedaan antara format sumber dan output, lihat [Determine the Original Presentation Format](/slides/id/php-java/detect-presentation-source-format/).

Dalam aplikasi pemrosesan batch, format input mungkin tidak diketahui sebelumnya. Setelah memuat file, baca format aslinya dari metode [Presentation::getSourceFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#getSourceFormat). Berikan nilai [SourceFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/sourceformat/) yang dihasilkan ke [SlideUtil::toSaveFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/slideutil/#toSaveFormat) untuk memperoleh nilai [SaveFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/saveformat/) yang sesuai, kemudian gunakan [Presentation::save](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#save) untuk menulis presentasi yang telah dimodifikasi.

Contoh lengkap berikut memproses setiap file dalam direktori masukan, memperbarui judulnya, dan menyimpannya ke direktori keluaran dalam format yang sama dengan file yang dimuat:

```php
use aspose\slides\Presentation;
use aspose\slides\SlideUtil;

$inputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "Input";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "Output";

if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    echo("Cannot create the output directory." . PHP_EOL);
}

$inputFiles = is_dir($inputDirectory) ? scandir($inputDirectory) : false;
if ($inputFiles !== false && is_dir($outputDirectory)) {
    foreach ($inputFiles as $fileName) {
        $inputPath = $inputDirectory . DIRECTORY_SEPARATOR . $fileName;
        if (!is_file($inputPath)) {
            continue;
        }

        $presentation = null;
        $presentationLoaded = false;
        try {
            $presentation = new Presentation($inputPath);
            $presentationLoaded = true;
            $saveFormat = SlideUtil::toSaveFormat($presentation->getSourceFormat());
            $presentation->getDocumentProperties()->setTitle("Processed by the batch application");

            $outputPath = $outputDirectory . DIRECTORY_SEPARATOR . $fileName;
            $presentation->save($outputPath, $saveFormat);
        } catch (\Throwable $exception) {
            echo("Cannot process '" . $inputPath . "': " . $exception->getMessage() . PHP_EOL);
        } finally {
            if ($presentationLoaded) {
                $presentation->dispose();
            }
        }
    }
}
```

[SlideUtil::toSaveFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/slideutil/#toSaveFormat) memetakan PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP, dan PowerPoint XML ke format penyimpanan presentasi yang bersesuaian. Ia memetakan hanya format sumber presentasi; tidak dimaksudkan untuk memilih format ekspor seperti PDF, HTML, TIFF, atau gambar. Memberikan nilai [SourceFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/sourceformat/) yang tidak didukung atau tidak valid akan menghasilkan [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html).

File legacy PPT, PPS, dan POT menggunakan kontainer biner yang sama. Ketika presentasi semacam itu dimuat dari stream tanpa ekstensi file, file PPS atau POT dapat diidentifikasi sebagai PPT. Jika diperlukan mempertahankan subtipe legacy ini, simpan nama file atau metadata format asli secara terpisah dan gunakan saat menentukan nama file dan format keluaran.

## **Menyimpan Presentasi ke Stream**

Untuk menulis presentasi tanpa bergantung pada jalur file akhir, berikan stream yang dapat ditulis dan nilai [SaveFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/saveformat/) ke metode [Presentation::save](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#save). Pendekatan ini berguna ketika output harus dikembalikan dari layanan web, disimpan di basis data, atau diproses dalam memori.

Contoh berikut menyimpan presentasi baru ke stream file:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $outputStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        $presentation->save($outputStream, SaveFormat::Pptx);
    } finally {
        $outputStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **Menyimpan Presentasi dengan Tipe Tampilan yang Telah Ditentukan**

Anda dapat menentukan tampilan yang akan dibuka PowerPoint secara awal saat membuka presentasi yang disimpan. Gunakan metode [ViewProperties::setLastView](https://reference.aspose.com/slides/id/php-java/aspose.slides/viewproperties/#setLastView) dengan nilai [ViewType](https://reference.aspose.com/slides/id/php-java/aspose.slides/viewtype/) sebelum menyimpan.

Contoh berikut mengonfigurasi tampilan Slide Master sebagai tampilan awal:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Menyimpan Presentasi dalam Format Strict Office Open XML**

Untuk membuat file PPTX yang mematuhi profil Strict dari Office Open XML, buat instance [PptxOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/pptxoptions/) dan gunakan metode [PptxOptions::setConformance](https://reference.aspose.com/slides/id/php-java/aspose.slides/pptxoptions/#setConformance) dengan nilai [Conformance::Iso29500_2008_Strict](https://reference.aspose.com/slides/id/php-java/aspose.slides/conformance/#Iso29500-2008-Strict). Kemudian berikan opsi tersebut ke metode [Presentation::save](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#save).

```php
use aspose\slides\Conformance;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

$presentation = new Presentation();
try {
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Menyimpan Presentasi dalam Format Office Open XML dalam Mode Zip64**

Arsip ZIP standar membatasi ukuran terkompresi dan tidak terkompresi setiap entri, ukuran total arsip, serta jumlah entri. Karena file PPTX adalah arsip ZIP, presentasi yang sangat besar dapat melampaui batas tersebut. Ekstensi ZIP64 memperbesar batas ukuran dan jumlah entri yang berlaku.

Gunakan metode [PptxOptions::setZip64Mode](https://reference.aspose.com/slides/id/php-java/aspose.slides/pptxoptions/#setZip64Mode) untuk mengontrol apakah Aspose.Slides menulis ekstensi ZIP64:

- [IfNecessary](https://reference.aspose.com/slides/id/php-java/aspose.slides/zip64mode/#IfNecessary) menggunakan ZIP64 hanya ketika presentasi melampaui batas ZIP standar. Ini adalah mode default.
- [Never](https://reference.aspose.com/slides/id/php-java/aspose.slides/zip64mode/#Never) menonaktifkan ekstensi ZIP64.
- [Always](https://reference.aspose.com/slides/id/php-java/aspose.slides/zip64mode/#Always) selalu menulis ekstensi ZIP64.

Contoh berikut selalu mengaktifkan ekstensi ZIP64 untuk presentasi keluaran:

```php
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\Zip64Mode;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setZip64Mode(Zip64Mode::Always);

    $presentation->save("OutputZip64.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="warning" title="Peringatan" %}}
Jika [Zip64Mode::Never](https://reference.aspose.com/slides/id/php-java/aspose.slides/zip64mode/#Never) digunakan dan presentasi tidak dapat muat dalam batas ZIP standar, operasi penyimpanan akan melempar [PptxException](https://reference.aspose.com/slides/id/php-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **Menyimpan Presentasi dalam Format Office Open XML dengan Tingkat Kompresi**

Untuk output PPTX, Anda dapat menyeimbangkan kecepatan penyimpanan dengan ukuran file menggunakan metode [PptxOptions::setCompressionLevel](https://reference.aspose.com/slides/id/php-java/aspose.slides/pptxoptions/#setCompressionLevel). Kelas [CompressionLevel](https://reference.aspose.com/slides/id/php-java/aspose.slides/compressionlevel/) menyediakan nilai-nilai berikut:

- [None](https://reference.aspose.com/slides/id/php-java/aspose.slides/compressionlevel/#None) menyimpan data tanpa kompresi.
- [Level1](https://reference.aspose.com/slides/id/php-java/aspose.slides/compressionlevel/#Level1) memberikan kompresi tercepat dan output terkompresi terbesar.
- [Level2](https://reference.aspose.com/slides/id/php-java/aspose.slides/compressionlevel/#Level2) hingga [Level5](https://reference.aspose.com/slides/id/php-java/aspose.slides/compressionlevel/#Level5) secara progresif memberi prioritas pada output yang lebih kecil dibandingkan kecepatan penyimpanan.
- [Level6](https://reference.aspose.com/slides/id/php-java/aspose.slides/compressionlevel/#Level6) menyeimbangkan kecepatan penyimpanan dan ukuran file. Ini adalah tingkat default.
- [Level7](https://reference.aspose.com/slides/id/php-java/aspose.slides/compressionlevel/#Level7) dan [Level8](https://reference.aspose.com/slides/id/php-java/aspose.slides/compressionlevel/#Level8) lebih memprioritaskan output kecil dibandingkan kecepatan penyimpanan.
- [Level9](https://reference.aspose.com/slides/id/php-java/aspose.slides/compressionlevel/#Level9) memberikan kompresi terkuat dan memerlukan waktu pemrosesan paling lama.

Contoh berikut menyimpan presentasi tanpa kompresi:

```php
use aspose\slides\CompressionLevel;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setCompressionLevel(CompressionLevel::None);

    $presentation->save("OutputNoCompression.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

Contoh berikut menggunakan tingkat kompresi maksimum:

```php
use aspose\slides\CompressionLevel;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setCompressionLevel(CompressionLevel::Level9);

    $presentation->save("OutputMaximumCompression.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

## **Menyimpan Presentasi tanpa Menyegarkan Thumbnail**

Saat presentasi disimpan sebagai PPTX, metode [PptxOptions::setRefreshThumbnail](https://reference.aspose.com/slides/id/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) mengontrol thumbnail dokumen:

- `true` menghasilkan kembali thumbnail selama operasi penyimpanan. Ini adalah nilai default.
- `false` mempertahankan thumbnail yang ada. Jika presentasi tidak memiliki thumbnail, Aspose.Slides tidak akan membuatnya.

Contoh berikut menyimpan presentasi tanpa menyegarkan thumbnailnya:

```php
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    $options = new PptxOptions();
    $options->setRefreshThumbnail(false);

    $presentation->save("Output.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Catatan" %}}
Menonaktifkan penyegaran thumbnail dapat mengurangi waktu yang diperlukan untuk menyimpan file PPTX.
{{% /alert %}}

## **Pembaruan Progres Penyimpanan dalam Persentase**

Untuk memantau operasi penyimpanan, sediakan proxy Java yang mengimplementasikan antarmuka [IProgressCallback](https://reference.aspose.com/slides/id/java/com.aspose.slides/iprogresscallback/) dan berikan proxy tersebut ke metode [SaveOptions::setProgressCallback](https://reference.aspose.com/slides/id/php-java/aspose.slides/saveoptions/#setProgressCallback). Aspose.Slides kemudian akan memanggil metode [IProgressCallback::reporting](https://reference.aspose.com/slides/id/java/com.aspose.slides/iprogresscallback/#reporting-double-) dengan nilai progres selama ekspor.

Contoh berikut melaporkan progres ekspor PDF ke konsol:

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

class ExportProgressHandler {
    function reporting($progressValue) {
        $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
        echo($progress . "% of the file has been converted." . PHP_EOL);
    }
}

$progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));

$options = new PdfOptions();
$options->setProgressCallback($progressHandler);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pdf", SaveFormat::Pdf, $options);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Catatan" %}}
Aspose menyediakan [PowerPoint Splitter](https://products.aspose.app/slides/id/splitter) gratis yang dibangun dengan API Aspose.Slides. Alat ini menyimpan slide terpilih dari sebuah presentasi sebagai file PPT atau PPTX terpisah.
{{% /alert %}}

## **FAQ**

**Apakah Aspose.Slides mendukung penyimpanan inkremental atau “fast save”?**

Tidak. Setiap operasi penyimpanan menulis file output lengkap bukan hanya bagian yang berubah.

**Dapatkah beberapa thread menyimpan instance Presentation yang sama?**

Tidak. Sebuah instance [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) [tidak thread‑safe](/slides/id/php-java/multithreading/). Akses dan simpan setiap instance hanya dari satu thread pada satu waktu.

**Apa yang terjadi pada hyperlink dan file yang ditautkan secara eksternal ketika saya menyimpan presentasi?**

[Hyperlink](/slides/id/php-java/manage-hyperlinks/) tetap berada dalam presentasi. Aspose.Slides tidak menyalin file yang ditautkan secara eksternal, sehingga presentasi yang disimpan tetap harus dapat mengakses lokasi file tersebut.

**Bisakah saya menyimpan metadata dokumen seperti penulis, judul, perusahaan, dan tanggal pembuatan?**

Ya. Atur [properti dokumen](/slides/id/php-java/presentation-properties/) yang sesuai sebelum menyimpan, dan Aspose.Slides akan menuliskannya ke file output.