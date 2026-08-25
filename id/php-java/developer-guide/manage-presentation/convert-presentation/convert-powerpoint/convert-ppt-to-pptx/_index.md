---
title: Mengonversi PPT ke PPTX dalam PHP
linktitle: PPT ke PPTX
type: docs
weight: 20
url: /id/php-java/convert-ppt-to-pptx/
keywords:
- konversi PowerPoint
- konversi presentasi
- konversi slide
- konversi PPT
- PPT ke PPTX
- simpan PPT sebagai PPTX
- ekspor PPT ke PPTX
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Konversi file PPT lama ke PPTX dalam PHP dengan Aspose.Slides. Menyertakan contoh PHP untuk konversi satu file dan batch, penanganan kesalahan, serta catatan akurasi."
---
## **Gambaran Umum**

PPT adalah format biner lama PowerPoint, sedangkan PPTX adalah format Open XML yang lebih baru. Aspose.Slides for PHP via Java dapat memuat file PPT dan menyimpannya sebagai PPTX tanpa Microsoft PowerPoint. Artikel ini menunjukkan cara mengonversi satu file atau satu direktori file dan menjelaskan apa yang harus diverifikasi setelah konversi.

## **Mengonversi File PPT ke PPTX**

Muat file sumber dengan kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/), kemudian panggil [Presentation::save](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#save) dengan [SaveFormat::Pptx](https://reference.aspose.com/slides/id/php-java/aspose.slides/saveformat/#Pptx). Blok `finally` membuang presentasi dan melepaskan sumber dayanya.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

// Muat presentasi PPT lama.
$presentation = new Presentation("presentation.ppt");
try {
    // Simpan presentasi dalam format PPTX.
    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ekstensi file tidak memilih format output secara otomatis; argumen [SaveFormat::Pptx](https://reference.aspose.com/slides/id/php-java/aspose.slides/saveformat/#Pptx) yang melakukannya. Jaga agar jalur input dan output berbeda jika Anda perlu mempertahankan file PPT asli.

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

Untuk beban kerja produksi, catat seluruh pengecualian, tentukan apakah file output yang ada boleh ditimpa, dan tulis nama file yang gagal ke antrian ulang atau peninjauan. File yang korup, file yang dilindungi kata sandi yang dibuka tanpa kata sandi yang diperlukan, jalur yang tidak dapat diakses, dan konten yang tidak didukung semuanya dapat menyebabkan konversi gagal. Lihat [Password-Protected Presentations](/slides/id/php-java/password-protected-presentation/) untuk memuat file terenkripsi.

## **Akurasi dan Fitur Legacy**

Konversi biasanya mempertahankan slide, master, tata letak, teks, bentuk, gambar, tabel, dan diagram. Namun, PPT dan PPTX tidak merepresentasikan setiap fitur dengan cara yang persis sama. Fitur legacy yang tidak memiliki padanan PPTX, atau tidak didukung oleh perpustakaan, dapat dinormalisasi, dihilangkan, atau ditampilkan secara berbeda.

Periksa file yang telah dikonversi bila berisi animasi, transisi, objek OLE yang disematkan atau ditautkan, kontrol ActiveX, media yang disematkan, font yang tidak umum, atau makro VBA. File PPTX biasa bukan format yang mendukung makro, jadi gunakan alur kerja yang mendukung makro bila VBA harus tetap tersedia. Juga pastikan font yang diperlukan dan sumber daya eksternal ada di lingkungan tempat presentasi yang dikonversi akan dibuka atau dirender.

Untuk dokumen penting, buka kembali PPTX yang dihasilkan secara programatik dan periksa jumlah slide serta kontennya, lalu bandingkan tampilan dan perilaku tayangan slide di penampil yang dimaksud. Jangan anggap panggilan [Presentation::save](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#save) yang berhasil sebagai bukti bahwa setiap fitur legacy memiliki representasi PPTX yang persis.

## **Kapan Menggunakan PPTX**

Gunakan PPTX ketika presentasi akan diedit di versi PowerPoint terkini, dipertukarkan dengan sistem yang bekerja dengan paket Open XML, atau disimpan dalam format yang lebih mudah diperiksa dan dipulihkan dibandingkan PPT biner lama. Simpan PPT asli sebagai salinan arsip atau rollback sampai presentasi yang dikonversi melewati pemeriksaan akurasi Anda.

Jika Anda memerlukan PDF, HTML, gambar, XPS, atau tipe output lain sebagai gantinya, gunakan panduan format-spesifik di [Convert Presentations to Multiple Formats](/slides/id/php-java/convert-presentation/) alih-alih mengasumsikan bahwa semua target mempertahankan fitur PowerPoint yang dapat diedit.

## **Konverter Online**

Untuk file sesekali atau perbandingan cepat, Anda dapat menggunakan [online PPT to PPTX converter](https://products.aspose.app/slides/id/conversion/ppt-to-pptx). Untuk konversi berulang, pemrosesan batch, atau penanganan kesalahan tingkat aplikasi, gunakan API PHP.

## **Artikel Terkait**

- [PPT vs PPTX](/slides/id/php-java/ppt-vs-pptx/)
- [Menyimpan Presentasi di PHP](/slides/id/php-java/save-presentation/)
- [Format File yang Didukung](/slides/id/php-java/supported-file-formats/)
- [Membuka Presentasi di PHP](/slides/id/php-java/open-presentation/)

## **FAQ**

**Apakah saya dapat mengonversi PPT ke PPTX tanpa Microsoft PowerPoint terpasang?**

Ya. Aspose.Slides for PHP via Java memuat dan menyimpan file presentasi tanpa memerlukan Microsoft PowerPoint.

**Apakah konversi PPT ke PPTX akan mempertahankan semua konten secara tepat?**

Ini mempertahankan konten presentasi umum, tetapi akurasi persis tidak dijamin untuk setiap fitur legacy atau yang tidak didukung. Tinjau file yang dihasilkan bila berisi makro, objek OLE atau ActiveX, media, animasi khusus, atau font yang tidak umum.

**Apakah saya dapat mengonversi file PPT yang dilindungi kata sandi?**

Ya, jika Anda menyediakan kata sandi yang benar saat memuat file. Kata sandi yang hilang atau salah menyebabkan operasi pemuatan gagal.

**Haruskah saya menghapus file PPT setelah konversi?**

Simpan yang asli sampai Anda memverifikasi PPTX di penampil dan alur kerja yang penting bagi Anda. Ini memberikan salinan rollback jika fitur legacy terkonversi secara berbeda.