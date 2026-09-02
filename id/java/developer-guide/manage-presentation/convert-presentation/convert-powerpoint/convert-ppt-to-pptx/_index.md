---
title: Mengonversi PPT ke PPTX di Java
linktitle: PPT ke PPTX
type: docs
weight: 20
url: /id/java/convert-ppt-to-pptx/
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
- Java
- Aspose.Slides
description: "Mengonversi file PPT warisan ke PPTX di Java dengan Aspose.Slides. Menyertakan contoh Java untuk konversi satu file dan batch, penanganan kesalahan, serta catatan kesetiaan."
---
## **Gambaran Umum**

PPT adalah format biner warisan PowerPoint, sementara PPTX adalah format Open XML yang lebih baru. Aspose.Slides for Java dapat memuat file PPT dan menyimpannya sebagai PPTX tanpa Microsoft PowerPoint. Artikel ini menunjukkan cara mengonversi satu file atau sebuah direktori file dan menjelaskan apa yang perlu diverifikasi setelah konversi.

## **Konversi File PPT ke PPTX**

Muat file sumber dengan kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) , lalu panggil [Presentation.save](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#save-java.lang.String-int-) dengan [SaveFormat.Pptx](https://reference.aspose.com/slides/id/java/com.aspose.slides/saveformat/#Pptx) . Blok `finally` membuang presentasi dan melepaskan sumber dayanya.

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

Ekstensi file tidak memilih format output secara otomatis; argumen [SaveFormat.Pptx](https://reference.aspose.com/slides/id/java/com.aspose.slides/saveformat/#Pptx) yang melakukannya. Jaga agar jalur input dan output berbeda jika Anda perlu mempertahankan file PPT asli.

## **Konversi Beberapa File PPT**

Contoh berikut mengonversi setiap file `.ppt` dalam satu direktori. Setiap file diproses secara independen, sehingga satu konversi yang gagal tidak menghentikan batch yang lainnya.

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

Untuk beban kerja produksi, catat pengecualian secara lengkap, tentukan apakah file output yang ada dapat ditimpa, dan tulis nama file yang gagal ke antrean retry atau review. File yang rusak, file yang dilindungi kata sandi yang dibuka tanpa kata sandi yang diperlukan, jalur yang tidak dapat diakses, dan konten yang tidak didukung semuanya dapat menyebabkan konversi gagal. Lihat [Presentasi yang Dilindungi Kata Sandi](/slides/id/java/password-protected-presentation/) untuk memuat file terenkripsi.

## **Kesetiaan dan Fitur Warisan**

Konversi biasanya mempertahankan slide, master, tata letak, teks, bentuk, gambar, tabel, dan diagram. Namun, PPT dan PPTX tidak mewakili setiap fitur dengan cara yang persis sama. Fitur warisan yang tidak memiliki padanan PPTX, atau tidak didukung oleh perpustakaan, dapat dinormalisasi, dihilangkan, atau ditampilkan secara berbeda.

Periksa file yang dikonversi ketika mengandung animasi, transisi, objek OLE yang disematkan atau ditautkan, kontrol ActiveX, media yang disematkan, font yang tidak umum, atau makro VBA. File PPTX biasa bukan format yang mendukung makro, jadi gunakan alur kerja yang mendukung makro bila VBA harus tetap tersedia. Juga pastikan font yang diperlukan dan sumber daya eksternal ada di lingkungan tempat presentasi yang dikonversi akan dibuka atau dirender.

Untuk dokumen penting, buka kembali PPTX yang dihasilkan secara programatis dan periksa jumlah slide utama serta kontennya, kemudian bandingkan penampilannya dan perilaku slide‑show di penampil yang dimaksud. Jangan anggap panggilan [Presentation.save](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#save-java.lang.String-int-) yang berhasil sebagai bukti bahwa setiap fitur warisan memiliki representasi PPTX yang persis.

## **Kapan Menggunakan PPTX**

Gunakan PPTX ketika presentasi akan diedit di versi PowerPoint terkini, dipertukarkan dengan sistem yang bekerja dengan paket Open XML, atau disimpan dalam format yang lebih mudah diperiksa dan dipulihkan dibandingkan PPT biner warisan. Simpan PPT asli sebagai salinan arsip atau rollback sampai presentasi yang dikonversi lulus pemeriksaan kesetiaan Anda.

Jika Anda memerlukan PDF, HTML, gambar, XPS, atau tipe output lain, gunakan panduan khusus format di [Convert Presentations to Multiple Formats](/slides/id/java/convert-presentation/) alih-alih mengasumsikan semua target mempertahankan fitur PowerPoint yang dapat diedit.

## **Konverter Daring**

Untuk file sesekali atau perbandingan cepat, Anda dapat menggunakan [online PPT to PPTX converter](https://products.aspose.app/slides/id/conversion/ppt-to-pptx) . Untuk konversi yang dapat diulang, pemrosesan batch, atau penanganan error tingkat aplikasi, gunakan Java API.

## **Artikel Terkait**

- [PPT vs PPTX](/slides/id/java/ppt-vs-pptx/)
- [Simpan Presentasi di Java](/slides/id/java/save-presentation/)
- [Format File yang Didukung](/slides/id/java/supported-file-formats/)
- [Buka Presentasi di Java](/slides/id/java/open-presentation/)

## **FAQ**

**Bisakah saya mengonversi PPT ke PPTX tanpa Microsoft PowerPoint terpasang?**

Ya. Aspose.Slides for Java memuat dan menyimpan file presentasi tanpa memerlukan Microsoft PowerPoint.

**Apakah konversi PPT ke PPTX akan mempertahankan semua konten secara tepat?**

Ini mempertahankan konten presentasi umum, tetapi kesetiaan yang persis tidak dijamin untuk setiap fitur warisan atau yang tidak didukung. Tinjau file yang dihasilkan ketika mengandung makro, objek OLE atau ActiveX, media, animasi khusus, atau font yang tidak umum.

**Bisakah saya mengonversi file PPT yang dilindungi kata sandi?**

Ya, jika Anda memasukkan kata sandi yang benar saat memuat file. Kata sandi yang hilang atau salah akan menyebabkan operasi pemuatan gagal.

**Haruskah saya menghapus file PPT setelah konversi?**

Simpan yang asli hingga Anda memverifikasi PPTX di penampil dan alur kerja yang penting bagi Anda. Ini menyediakan salinan rollback jika fitur warisan terkonversi secara berbeda.