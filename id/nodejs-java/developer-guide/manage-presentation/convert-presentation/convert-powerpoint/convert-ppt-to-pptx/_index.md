---
title: Mengonversi PPT ke PPTX di Node.js
linktitle: PPT ke PPTX
type: docs
weight: 20
url: /id/nodejs-java/convert-ppt-to-pptx/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Mengonversi file PPT warisan ke PPTX di Node.js dengan Aspose.Slides. Menyertakan contoh JavaScript untuk konversi satu file dan batch, penanganan kesalahan, serta catatan kesetiaan."
---
## **Gambaran Umum**

PPT adalah format PowerPoint biner warisan, sementara PPTX adalah format Open XML yang lebih baru. Aspose.Slides untuk Node.js melalui Java dapat memuat file PPT dan menyimpannya sebagai PPTX tanpa Microsoft PowerPoint. Artikel ini menunjukkan cara mengonversi satu file atau direktori file dan menjelaskan hal yang harus diverifikasi setelah konversi.

## **Mengonversi File PPT ke PPTX**

Muat file sumber dengan kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/), kemudian panggil [Presentation.save](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#save) dengan [SaveFormat.Pptx](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/saveformat/). Blok `finally` membuang presentasi dan melepaskan sumber dayanya.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Muat presentasi PPT warisan.
let presentation = new aspose.slides.Presentation("presentation.ppt");
try {
    // Simpan presentasi dalam format PPTX.
    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ekstensi file tidak memilih format output secara otomatis; argumen [SaveFormat.Pptx](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/saveformat/) yang melakukannya. Jaga agar jalur input dan output berbeda jika Anda perlu mempertahankan file PPT asli.

## **Mengonversi Beberapa File PPT**

Contoh berikut mengonversi setiap file `.ppt` dalam satu direktori. Setiap file diproses secara independen, sehingga satu konversi yang gagal tidak menghentikan batch lainnya.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");

const inputDirectory = "input";
const outputDirectory = "output";
fs.mkdirSync(outputDirectory, { recursive: true });

const inputFiles = fs.readdirSync(inputDirectory, { withFileTypes: true })
    .filter(entry => entry.isFile() && path.extname(entry.name).toLowerCase() === ".ppt")
    .map(entry => entry.name);

for (const fileName of inputFiles) {
    const inputPath = path.join(inputDirectory, fileName);
    const outputFileName = path.basename(fileName, path.extname(fileName)) + ".pptx";
    const outputPath = path.join(outputDirectory, outputFileName);
    let presentation = null;

    try {
        presentation = new aspose.slides.Presentation(inputPath);
        presentation.save(outputPath, aspose.slides.SaveFormat.Pptx);
        console.log("Converted: " + inputPath);
    } catch (error) {
        console.error("Failed: " + inputPath + " (" + error.message + ")");
    } finally {
        if (presentation !== null) {
            presentation.dispose();
        }
    }
}
```

Untuk beban kerja produksi, catat seluruh kesalahan, putuskan apakah file output yang ada dapat ditimpa, dan tulis nama file yang gagal ke antrean coba kembali atau tinjauan. File yang rusak, file yang dilindungi kata sandi yang dibuka tanpa kata sandi yang diperlukan, jalur yang tidak dapat diakses, dan konten yang tidak didukung dapat menyebabkan konversi gagal. Lihat [Password-Protected Presentations](/slides/id/nodejs-java/password-protected-presentation/) untuk memuat file terenkripsi.

## **Kesetiaan dan Fitur Warisan**

Konversi biasanya mempertahankan slide, master, tata letak, teks, bentuk, gambar, tabel, dan diagram. Namun, PPT dan PPTX tidak merepresentasikan setiap fitur dengan cara yang persis sama. Fitur warisan yang tidak memiliki padanan PPTX, atau tidak didukung oleh perpustakaan, dapat dinormalisasi, dihilangkan, atau ditampilkan secara berbeda.

Periksa file yang dikonversi bila mengandung animasi, transisi, objek OLE yang disematkan atau ditautkan, kontrol ActiveX, media yang disematkan, font yang tidak umum, atau makro VBA. File PPTX biasa bukan format yang mendukung makro, sehingga gunakan alur kerja yang mendukung makro bila VBA harus tetap tersedia. Juga pastikan font yang diperlukan dan sumber daya eksternal ada di lingkungan tempat presentasi yang dikonversi akan dibuka atau dirender.

Untuk dokumen penting, buka kembali PPTX yang dihasilkan secara programatik dan periksa jumlah slide serta konten utama, kemudian bandingkan tampilannya dan perilaku slide-show di penampil yang dimaksud. Jangan menganggap panggilan [Presentation.save](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#save) yang berhasil sebagai bukti bahwa setiap fitur warisan memiliki representasi PPTX yang tepat.

## **Kapan Menggunakan PPTX**

Gunakan PPTX ketika presentasi akan diedit di versi PowerPoint saat ini, ditukar dengan sistem yang bekerja dengan paket Open XML, atau disimpan dalam format yang lebih mudah diperiksa dan dipulihkan dibandingkan PPT biner warisan. Simpan PPT asli sebagai salinan arsip atau rollback hingga presentasi yang dikonversi melewati pemeriksaan kesetiaan Anda.

Jika Anda memerlukan PDF, HTML, gambar, XPS, atau tipe output lain sebagai gantinya, gunakan panduan khusus format dalam [Convert Presentations to Multiple Formats](/slides/id/nodejs-java/convert-presentation/) daripada mengasumsikan semua target mempertahankan fitur PowerPoint yang dapat diedit.

## **Konverter Daring**

Untuk file sesekali atau perbandingan cepat, Anda dapat menggunakan [online PPT to PPTX converter](https://products.aspose.app/slides/id/conversion/ppt-to-pptx). Untuk konversi yang dapat diulang, pemrosesan batch, atau penanganan kesalahan tingkat aplikasi, gunakan API Node.js melalui Java.

## **Artikel Terkait**

- [PPT vs PPTX](/slides/id/nodejs-java/ppt-vs-pptx/)
- [Menyimpan Presentasi di Node.js](/slides/id/nodejs-java/save-presentation/)
- [Format File yang Didukung](/slides/id/nodejs-java/supported-file-formats/)
- [Membuka Presentasi di Node.js](/slides/id/nodejs-java/open-presentation/)

## **FAQ**

**Apakah saya dapat mengonversi PPT ke PPTX tanpa Microsoft PowerPoint terpasang?**

Ya. Aspose.Slides untuk Node.js melalui Java memuat dan menyimpan file presentasi tanpa memerlukan Microsoft PowerPoint.

**Apakah konversi PPT ke PPTX akan mempertahankan semua konten dengan tepat?**

Ia mempertahankan konten presentasi umum, tetapi kesetiaan yang tepat tidak dijamin untuk setiap fitur warisan atau yang tidak didukung. Tinjau file yang dihasilkan bila mengandung makro, objek OLE atau ActiveX, media, animasi khusus, atau font yang tidak umum.

**Apakah saya dapat mengonversi file PPT yang dilindungi kata sandi?**

Ya, jika Anda memberikan kata sandi yang benar saat memuat file. Kata sandi yang hilang atau salah menyebabkan operasi pemuatan gagal.

**Haruskah saya menghapus file PPT setelah konversi?**

Simpan file asli sampai Anda memverifikasi PPTX di penampil dan alur kerja yang penting bagi Anda. Ini menyediakan salinan rollback bila suatu fitur warisan dikonversi secara berbeda.