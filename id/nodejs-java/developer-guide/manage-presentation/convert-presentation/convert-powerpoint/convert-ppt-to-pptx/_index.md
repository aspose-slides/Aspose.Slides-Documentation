---
title: Mengonversi PPT ke PPTX di Node.js
linktitle: PPT ke PPTX
type: docs
weight: 20
url: /id/nodejs-java/convert-ppt-to-pptx/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Mengonversi file PPT warisan ke PPTX di Node.js dengan Aspose.Slides. Menyertakan contoh JavaScript untuk konversi satu file dan batch, penanganan kesalahan, serta catatan kecocokan."
---
## **Gambaran Umum**

PPT adalah format PowerPoint biner warisan, sementara PPTX adalah format Open XML yang lebih baru. Aspose.Slides for Node.js via Java dapat memuat file PPT dan menyimpannya sebagai PPTX tanpa Microsoft PowerPoint. Artikel ini menunjukkan cara mengonversi satu file atau seluruh direktori file serta menjelaskan apa yang perlu diverifikasi setelah konversi.

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

Ekstensi file tidak menentukan format keluaran secara otomatis; argumen [SaveFormat.Pptx](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/saveformat/) yang melakukannya. Jaga agar jalur masukan dan keluaran berbeda jika Anda harus mempertahankan file PPT asli.

## **Mengonversi Beberapa File PPT**

Contoh berikut mengonversi setiap file `.ppt` dalam satu direktori. Setiap file diproses secara independen, sehingga satu konversi yang gagal tidak menghentikan sisanya.

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

Untuk beban kerja produksi, catat seluruh kesalahan, tentukan apakah file keluaran yang ada dapat ditimpa, dan tulis nama file yang gagal ke antrean ulang atau tinjauan. File rusak, file yang dilindungi kata sandi yang dibuka tanpa kata sandi yang diperlukan, jalur yang tidak dapat diakses, dan konten yang tidak didukung semuanya dapat menyebabkan konversi gagal. Lihat [Password‑Protected Presentations](/nodejs-java/password-protected-presentation/) untuk memuat file terenkripsi.

## **Kecocokan dan Fitur Warisan**

Konversi biasanya mempertahankan slide, master, tata letak, teks, bentuk, gambar, tabel, dan diagram. Namun, PPT dan PPTX tidak mewakili setiap fitur dengan cara yang persis sama. Fitur warisan yang tidak memiliki padanan PPTX, atau tidak didukung oleh pustaka, mungkin dinormalisasi, dihilangkan, atau ditampilkan secara berbeda.

Periksa file yang telah dikonversi ketika berisi animasi, transisi, objek OLE yang disematkan atau ditautkan, kontrol ActiveX, media yang disematkan, font yang tidak umum, atau makro VBA. File PPTX biasa bukan format yang mendukung makro, jadi gunakan alur kerja yang mendukung makro bila VBA harus tetap tersedia. Juga verifikasi bahwa font yang dibutuhkan dan sumber daya eksternal ada di lingkungan tempat presentasi yang dikonversi akan dibuka atau dirender.

Untuk dokumen penting, buka kembali PPTX yang dihasilkan secara programatik dan periksa jumlah slide serta kontennya, kemudian bandingkan tampilannya dan perilaku tayang slide di penampil yang dimaksud. Jangan menganggap pemanggilan [Presentation.save](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#save) yang berhasil sebagai bukti bahwa setiap fitur warisan memiliki representasi PPTX yang tepat.

## **Kapan Menggunakan PPTX**

Gunakan PPTX ketika presentasi akan diedit dengan versi PowerPoint terkini, ditukarkan dengan sistem yang bekerja dengan paket Open XML, atau disimpan dalam format yang lebih mudah diperiksa dan dipulihkan dibandingkan PPT biner warisan. Simpan PPT asli sebagai arsip atau salinan rollback hingga presentasi yang dikonversi lolos pemeriksaan kecocokan Anda.

Jika Anda membutuhkan PDF, HTML, gambar, XPS, atau tipe keluaran lain, gunakan panduan khusus format dalam [Convert Presentations to Multiple Formats](/nodejs-java/convert-presentation/) alih-alih mengasumsikan semua target mempertahankan fitur PowerPoint yang dapat diedit.

## **Konverter Online**

Untuk file sesekali atau perbandingan cepat, Anda dapat menggunakan [online PPT to PPTX converter](https://products.aspose.app/slides/id/conversion/ppt-to-pptx). Untuk konversi berulang, pemrosesan batch, atau penanganan kesalahan tingkat aplikasi, gunakan API Node.js via Java.

## **Artikel Terkait**

- [PPT vs PPTX](/nodejs-java/ppt-vs-pptx/)
- [Save Presentations in Node.js](/nodejs-java/save-presentation/)
- [Supported File Formats](/nodejs-java/supported-file-formats/)
- [Open Presentations in Node.js](/nodejs-java/open-presentation/)

## **FAQ**

**Apakah saya dapat mengonversi PPT ke PPTX tanpa Microsoft PowerPoint terinstal?**

Ya. Aspose.Slides for Node.js via Java memuat dan menyimpan file presentasi tanpa memerlukan Microsoft PowerPoint.

**Apakah konversi PPT ke PPTX akan mempertahankan semua konten secara persis?**

Ia mempertahankan konten presentasi umum, tetapi kecocokan sempurna tidak dijamin untuk setiap fitur warisan atau yang tidak didukung. Tinjau file yang dihasilkan ketika berisi makro, objek OLE atau ActiveX, media, animasi khusus, atau font yang tidak umum.

**Apakah saya dapat mengonversi file PPT yang dilindungi kata sandi?**

Ya, bila Anda menyediakan kata sandi yang benar saat memuat file. Kata sandi yang hilang atau salah akan menyebabkan operasi pemuatan gagal.

**Haruskah saya menghapus file PPT setelah konversi?**

Simpan file asli sampai Anda memverifikasi PPTX di penampil dan alur kerja yang penting bagi Anda. Ini memberikan salinan rollback jika fitur warisan dikonversi dengan cara yang berbeda.