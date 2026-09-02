---
title: Mengonversi PPT ke PPTX di PHP
linktitle: PPT ke PPTX
type: docs
weight: 20
url: /id/php-java/convert-ppt-to-pptx/
keywords:
- mengonversi PowerPoint
- mengonversi presentasi
- mengonversi slide
- mengonversi PPT
- PPT ke PPTX
- menyimpan PPT sebagai PPTX
- mengekspor PPT ke PPTX
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Mengonversi file PPT warisan ke PPTX di PHP dengan Aspose.Slides. Menyertakan contoh PHP untuk konversi satu file dan batch, penanganan error, serta catatan keakuratan."
---
## **Ringkasan**

PPT adalah format PowerPoint biner warisan, sedangkan PPTX adalah format Open XML yang lebih baru. Aspose.Slides for PHP via Java dapat memuat file PPT dan menyimpannya sebagai PPTX tanpa Microsoft PowerPoint. Artikel ini menunjukkan cara mengonversi satu file atau direktori file dan menjelaskan hal yang perlu diverifikasi setelah konversi.

## **Mengonversi File PPT ke PPTX**

Muatan file sumber dengan kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/), lalu panggil [Presentation::save](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#save) dengan [SaveFormat::Pptx](https://reference.aspose.com/slides/id/php-java/aspose.slides/saveformat/#Pptx). Blok `finally` membuang presentasi dan melepaskan sumber dayanya.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

// Muat presentasi PPT warisan.
$presentation = new Presentation("presentation.ppt");
try {
    // Simpan presentasi dalam format PPTX.
    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ekstensi file tidak memilih format output sendiri; argumen [SaveFormat::Pptx](https://reference.aspose.com/slides/id/php-java/aspose.slides/saveformat/#Pptx) melakukannya. Jaga agar jalur masuk dan keluar berbeda jika Anda perlu mempertahankan file PPT asli.

## **Mengonversi Beberapa File PPT**

Contoh berikut mengonversi setiap file `.ppt` dalam satu direktori. Setiap file diproses secara independen, sehingga satu konversi yang gagal tidak menghentikan sisanya dalam batch.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputDirectory = "input";
$outputDirectory = "output";
if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    throw new RuntimeException("Cannot create the output directory: " . $outputDirectory);
}

$inputFiles = [];
foreach (new DirectoryIterator($inputDirectory) as $fileInfo) {
    if ($fileInfo->isFile() && strtolower($fileInfo->getExtension()) === "ppt") {
        $inputFiles[] = $fileInfo->getPathname();
    }
}

foreach ($inputFiles as $inputPath) {
    $outputFileName = pathinfo($inputPath, PATHINFO_FILENAME) . ".pptx";
    $outputPath = $outputDirectory . DIRECTORY_SEPARATOR . $outputFileName;
    $presentation = null;

    try {
        $presentation = new Presentation($inputPath);
        $presentation->save($outputPath, SaveFormat::Pptx);
        echo "Converted: " . $inputPath . PHP_EOL;
    } catch (Throwable $exception) {
        fwrite(STDERR, "Failed: " . $inputPath . " (" . $exception->getMessage() . ")" . PHP_EOL);
    } finally {
        if ($presentation !== null) {
            $presentation->dispose();
        }
    }
}
```

Untuk beban kerja produksi, catat pengecualian lengkap, tentukan apakah file output yang ada dapat ditimpa, dan tulis nama file yang gagal ke antrean peninjauan atau percobaan ulang. File rusak, file yang dilindungi password yang dibuka tanpa password yang diperlukan, jalur yang tidak dapat diakses, dan konten yang tidak didukung semuanya dapat menyebabkan konversi gagal. Lihat [Password-Protected Presentations](/php-java/password-protected-presentation/) untuk memuat file terenkripsi.

## **Kejelasan dan Fitur Warisan**

Konversi biasanya mempertahankan slide, master, tata letak, teks, bentuk, gambar, tabel, dan diagram. Namun, PPT dan PPTX tidak mewakili setiap fitur dengan cara yang persis sama. Fitur warisan yang tidak memiliki padanan PPTX, atau tidak didukung oleh perpustakaan, dapat dinormalisasi, dihilangkan, atau ditampilkan secara berbeda.

Periksa file yang telah dikonversi ketika berisi animasi, transisi, objek OLE yang disematkan atau ditautkan, kontrol ActiveX, media yang disematkan, font yang tidak umum, atau makro VBA. File PPTX biasa bukan format yang mendukung makro, jadi gunakan alur kerja yang mendukung makro ketika VBA harus tetap tersedia. Juga pastikan bahwa font yang diperlukan dan sumber daya eksternal ada di lingkungan tempat presentasi yang dikonversi akan dibuka atau dirender.

Untuk dokumen penting, buka kembali PPTX yang dihasilkan secara programatis dan periksa jumlah slide utama serta kontennya, kemudian bandingkan tampilannya dan perilaku tayang slide di penampil yang dimaksud. Jangan menganggap pemanggilan [Presentation::save](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#save) yang berhasil sebagai bukti bahwa setiap fitur warisan memiliki representasi PPTX yang tepat.

## **Kapan Menggunakan PPTX**

Gunakan PPTX ketika presentasi akan diedit di versi PowerPoint terkini, dipertukarkan dengan sistem yang bekerja dengan paket Open XML, atau disimpan dalam format yang lebih mudah diperiksa dan dipulihkan dibandingkan PPT biner warisan. Simpan PPT asli sebagai salinan arsip atau cadangan hingga presentasi yang dikonversi lulus pemeriksaan kepresisiannya.

Jika Anda memerlukan PDF, HTML, gambar, XPS, atau tipe output lain, gunakan panduan khusus format di [Convert Presentations to Multiple Formats](/php-java/convert-presentation/) alih-alih mengasumsikan semua target mempertahankan fitur PowerPoint yang dapat diedit.

## **Konverter Online**

Untuk file sesekali atau perbandingan cepat, Anda dapat menggunakan [online PPT to PPTX converter](https://products.aspose.app/slides/id/conversion/ppt-to-pptx). Untuk konversi yang dapat diulang, pemrosesan batch, atau penanganan kesalahan tingkat aplikasi, gunakan API PHP.

## **Artikel Terkait**

- [PPT vs PPTX](/php-java/ppt-vs-pptx/)
- [Menyimpan Presentasi di PHP](/php-java/save-presentation/)
- [Format File yang Didukung](/php-java/supported-file-formats/)
- [Membuka Presentasi di PHP](/php-java/open-presentation/)

## **FAQ**

**Apakah saya dapat mengonversi PPT ke PPTX tanpa menginstal Microsoft PowerPoint?**

Ya. Aspose.Slides for PHP via Java memuat dan menyimpan file presentasi tanpa memerlukan Microsoft PowerPoint.

**Apakah konversi PPT ke PPTX akan mempertahankan semua konten secara tepat?**

Ia mempertahankan konten presentasi umum, tetapi kepresisian yang tepat tidak dijamin untuk setiap fitur warisan atau yang tidak didukung. Tinjau file yang dihasilkan ketika berisi makro, objek OLE atau ActiveX, media, animasi khusus, atau font yang tidak umum.

**Apakah saya dapat mengonversi file PPT yang dilindungi kata sandi?**

Ya, jika Anda memberikan kata sandi yang benar saat memuat file. Kata sandi yang hilang atau salah menyebabkan operasi pemuatan gagal.

**Haruskah saya menghapus file PPT setelah konversi?**

Simpan file asli sampai Anda memverifikasi PPTX di penampil dan alur kerja yang penting bagi Anda. Ini menyediakan salinan cadangan jika fitur warisan dikonversi secara berbeda.