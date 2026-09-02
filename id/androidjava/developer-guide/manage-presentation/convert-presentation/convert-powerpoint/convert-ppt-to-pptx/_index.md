---
title: Konversi PPT ke PPTX di Android
linktitle: PPT ke PPTX
type: docs
weight: 20
url: /id/androidjava/convert-ppt-to-pptx/
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
- Android
- Java
- Aspose.Slides
description: "Konversi file PPT lama ke PPTX di Android dengan Aspose.Slides. Termasuk contoh Java untuk konversi satu file dan batch, penanganan kesalahan, serta catatan akurasi."
---
## **Gambaran Umum**

PPT adalah format biner PowerPoint lama, sementara PPTX adalah format Open XML yang lebih baru. Aspose.Slides untuk Android via Java dapat memuat file PPT dan menyimpannya sebagai PPTX tanpa Microsoft PowerPoint. Artikel ini menunjukkan cara mengonversi satu file atau satu direktori file dan menjelaskan apa yang perlu diverifikasi setelah konversi.

## **Mengonversi File PPT ke PPTX**

Muat file sumber dengan kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/), kemudian panggil [Presentation.save](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) dengan [SaveFormat.Pptx](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/saveformat/#Pptx). Blok `finally` membuang presentasi dan melepaskan sumber dayanya.

```java
// Muat presentasi PPT warisan.
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // Simpan presentasi dalam format PPTX.
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ekstensi file tidak menentukan format output sendiri; argumen [SaveFormat.Pptx](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/saveformat/#Pptx) yang melakukannya. Jaga agar jalur input dan output berbeda jika Anda perlu mempertahankan file PPT asli.

## **Mengonversi Beberapa File PPT**

Contoh berikut mengonversi setiap file `.ppt` dalam satu direktori. Setiap file diproses secara independen, sehingga satu konversi yang gagal tidak menghentikan sisanya.

```java
java.io.File inputDirectory = new java.io.File("input");
java.io.File outputDirectory = new java.io.File("output");
if (!outputDirectory.exists() && !outputDirectory.mkdirs()) {
    throw new IllegalStateException("Cannot create the output directory: " + outputDirectory);
}

java.io.File[] inputFiles = inputDirectory.listFiles((directory, name) -> name.toLowerCase(java.util.Locale.ROOT).endsWith(".ppt"));
if (inputFiles == null) {
    throw new IllegalStateException("Cannot read the input directory: " + inputDirectory);
}

for (java.io.File inputFile : inputFiles) {
    String inputPath = inputFile.getPath();
    String fileName = inputFile.getName();
    String outputFileName = fileName.substring(0, fileName.length() - 4) + ".pptx";
    String outputPath = new java.io.File(outputDirectory, outputFileName).getPath();
    com.aspose.slides.Presentation presentation = null;

    try {
        presentation = new com.aspose.slides.Presentation(inputPath);
        presentation.save(outputPath, com.aspose.slides.SaveFormat.Pptx);
        System.out.println("Converted: " + inputPath);
    } catch (Exception exception) {
        System.err.println("Failed: " + inputPath + " (" + exception.getMessage() + ")");
    } finally {
        if (presentation != null) {
            presentation.dispose();
        }
    }
}
```

Untuk beban kerja produksi, log seluruh pengecualian, tentukan apakah file output yang ada boleh ditimpa, dan tulis nama file yang gagal ke antrean retry atau review. File yang rusak, file yang dilindungi kata sandi yang dibuka tanpa kata sandi yang diperlukan, jalur yang tidak dapat diakses, dan konten yang tidak didukung semuanya dapat menyebabkan konversi gagal. Lihat [Password-Protected Presentations](/androidjava/password-protected-presentation/) untuk memuat file terenkripsi.

## **Akurasi dan Fitur Warisan**

Konversi biasanya mempertahankan slide, master, tata letak, teks, bentuk, gambar, tabel, dan diagram. Namun, PPT dan PPTX tidak merepresentasikan setiap fitur dengan cara yang persis sama. Fitur warisan yang tidak memiliki padanan PPTX, atau tidak didukung oleh pustaka, dapat dinormalisasi, dihilangkan, atau ditampilkan secara berbeda.

Periksa file hasil konversi ketika berisi animasi, transisi, objek OLE yang disematkan atau ditautkan, kontrol ActiveX, media yang disematkan, font yang tidak umum, atau makro VBA. File PPTX biasa bukan format yang mendukung makro, jadi gunakan alur kerja yang mendukung makro bila VBA harus tetap tersedia. Juga pastikan font yang diperlukan dan sumber daya eksternal ada di lingkungan tempat presentasi yang dikonversi akan dibuka atau dirender.

Untuk dokumen penting, buka kembali PPTX yang dihasilkan secara programatis dan inspeksi jumlah slide serta kontennya, kemudian bandingkan tampilannya dan perilaku slide-show di penampil yang dimaksud. Jangan menganggap pemanggilan [Presentation.save](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) yang berhasil sebagai bukti bahwa setiap fitur warisan memiliki representasi PPTX yang tepat.

## **Kapan Menggunakan PPTX**

Gunakan PPTX ketika presentasi akan diedit di versi PowerPoint terkini, dipertukarkan dengan sistem yang bekerja dengan paket Open XML, atau disimpan dalam format yang lebih mudah diperiksa dan dipulihkan dibandingkan PPT biner lama. Simpan PPT asli sebagai salinan arsip atau rollback sampai presentasi yang dikonversi telah lulus pemeriksaan akurasi Anda.

Jika Anda memerlukan PDF, HTML, gambar, XPS, atau tipe output lain, gunakan panduan format‑spesifik di [Convert Presentations to Multiple Formats](/androidjava/convert-presentation/) alih-alih mengasumsikan semua target mempertahankan fitur PowerPoint yang dapat diedit.

## **Konverter Daring**

Untuk file sesekali atau perbandingan cepat, Anda dapat menggunakan [online PPT to PPTX converter](https://products.aspose.app/slides/id/conversion/ppt-to-pptx). Untuk konversi berulang, pemrosesan batch, atau penanganan kesalahan tingkat aplikasi, gunakan API Android via Java.

## **Artikel Terkait**

- [PPT vs PPTX](/androidjava/ppt-vs-pptx/)
- [Save Presentations on Android](/androidjava/save-presentation/)
- [Supported File Formats](/androidjava/supported-file-formats/)
- [Open Presentations on Android](/androidjava/open-presentation/)

## **Tanya Jawab**

**Apakah saya dapat mengonversi PPT ke PPTX tanpa Microsoft PowerPoint terinstal?**

Ya. Aspose.Slides untuk Android via Java memuat dan menyimpan file presentasi tanpa memerlukan Microsoft PowerPoint.

**Apakah konversi PPT ke PPTX akan mempertahankan semua konten secara tepat?**

Ia mempertahankan konten presentasi umum, tetapi akurasi penuh tidak dijamin untuk setiap fitur warisan atau yang tidak didukung. Tinjau file yang dihasilkan ketika berisi makro, objek OLE atau ActiveX, media, animasi khusus, atau font yang tidak umum.

**Apakah saya dapat mengonversi file PPT yang dilindungi kata sandi?**

Ya, bila Anda menyediakan kata sandi yang benar saat memuat file. Kata sandi yang hilang atau salah menyebabkan operasi pemuatan gagal.

**Haruskah saya menghapus file PPT setelah konversi?**

Simpan file asli hingga Anda memverifikasi PPTX di penampil dan alur kerja yang penting bagi Anda. Ini memberikan salinan rollback jika fitur warisan dikonversi secara berbeda.