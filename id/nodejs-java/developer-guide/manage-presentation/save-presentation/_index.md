---
title: Simpan Presentasi dalam JavaScript
linktitle: Simpan Presentasi
type: docs
weight: 80
url: /id/nodejs-java/save-presentation/
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
- menyimpan progres
- Node.js
- JavaScript
- Aspose.Slides
description: Temukan cara menyimpan presentasi menggunakan Aspose.Slides untuk Node.js melalui Java—ekspor ke PowerPoint atau OpenDocument sambil mempertahankan tata letak, font, dan efek.
---
## **Gambaran Umum**

[Buka Presentasi dalam JavaScript](/slides/id/nodejs-java/open-presentation/) menjelaskan cara menggunakan kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) untuk membuka sebuah presentasi. Artikel ini menjelaskan cara membuat dan menyimpan presentasi. Kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) berisi konten presentasi. Baik Anda membuat presentasi dari awal maupun memodifikasi yang sudah ada, Anda akan ingin menyimpannya setelah selesai. Dengan Aspose.Slides untuk Node.js, Anda dapat menyimpan ke **file** atau **stream**. Artikel ini menjelaskan berbagai cara menyimpan sebuah presentasi.

## **Simpan Presentasi ke File**

Simpan sebuah presentasi ke file dengan memanggil metode `save` milik kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/). Berikan nama file dan format penyimpanan ke metode tersebut. Contoh berikut menunjukkan cara menyimpan sebuah presentasi dengan Aspose.Slides.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Buat instance kelas Presentation yang merepresentasikan file presentasi.
let presentation = new aspose.slides.Presentation();
try {
    // Lakukan beberapa pekerjaan di sini...

    // Simpan presentasi ke sebuah file.
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Simpan Presentasi ke Stream**

Anda dapat menyimpan sebuah presentasi ke stream dengan memberikan output stream ke metode `save` milik kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/). Sebuah presentasi dapat ditulis ke banyak jenis stream. Pada contoh di bawah, kami membuat presentasi baru dan menyimpannya ke file stream.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Buat instance kelas Presentation yang merepresentasikan file presentasi.
let presentation = new aspose.slides.Presentation();
try {
    let fileStream = java.newInstanceSync("java.io.FileOutputStream", "Output.pptx");
    try {
        // Simpan presentasi ke stream.
        presentation.save(fileStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Simpan Presentasi dengan Tipe Tampilan yang Ditetapkan**

Aspose.Slides memungkinkan Anda menetapkan tampilan awal yang digunakan PowerPoint ketika presentasi yang dihasilkan dibuka melalui kelas [ViewProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/viewproperties/). Gunakan metode [setLastView](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/viewproperties/#setLastView) dengan nilai dari enumerasi [ViewType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/viewtype/).

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Simpan Presentasi dalam Format Strict Office Open XML**

Aspose.Slides memungkinkan Anda menyimpan presentasi dalam format Strict Office Open XML. Gunakan kelas [PptxOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pptxoptions/) dan atur properti conformance-nya saat menyimpan. Jika Anda mengatur [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict), file output akan disimpan dalam format Strict Office Open XML.

Contoh di bawah membuat sebuah presentasi dan menyimpannya dalam format Strict Office Open XML.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

// Buat instance kelas Presentation yang merepresentasikan file presentasi.
let presentation = new aspose.slides.Presentation();
try {
    // Simpan presentasi dalam format Strict Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Simpan Presentasi dalam Format Office Open XML dengan Mode Zip64**

File Office Open XML adalah arsip ZIP yang menerapkan batas 4 GB (2^32 byte) pada ukuran tidak terkompresi dari setiap file, ukuran terkompresi dari setiap file, dan ukuran total arsip, serta membatasi arsip hingga 65 535 (2^16‑1) file. Ekstensi format ZIP64 menaikkan batas ini menjadi 2^64.

Metode [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pptxoptions/#getZip64Mode) memungkinkan Anda memilih kapan menggunakan ekstensi format ZIP64 saat menyimpan file Office Open XML.

Metode ini dapat digunakan dengan mode berikut:

- [IfNecessary](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/zip64mode/#IfNecessary) menggunakan ekstensi format ZIP64 hanya jika presentasi melampaui batasan di atas. Ini adalah mode default.
- [Never](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/zip64mode/#Never) tidak pernah menggunakan ekstensi format ZIP64.
- [Always](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/zip64mode/#Always) selalu menggunakan ekstensi format ZIP64.

Kode berikut menunjukkan cara menyimpan sebuah presentasi sebagai file PPTX dengan ekstensi format ZIP64 diaktifkan:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setZip64Mode(aspose.slides.Zip64Mode.Always);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}}

Saat Anda menyimpan dengan [Zip64Mode.Never](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/zip64mode/#Never), sebuah [PptxException](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pptxexception/) dilemparkan jika presentasi tidak dapat disimpan dalam format ZIP32.

{{% /alert %}}

## **Simpan Presentasi dalam Format Office Open XML dengan Tingkat Kompresi**

Saat bekerja dengan presentasi berukuran besar, Anda dapat menyesuaikan tingkat kompresi untuk menyeimbangkan ukuran file dan waktu pemrosesan. Bergantung pada kebutuhan Anda, Anda mungkin lebih memilih pemrosesan yang lebih cepat atau file output yang lebih kecil.

Aspose.Slides menyediakan metode [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pptxoptions/#setCompressionLevel), yang memungkinkan Anda menentukan tingkat kompresi yang digunakan saat menyimpan sebuah presentasi dalam format Office Open XML.

Tingkat kompresi berikut tersedia:

- [**None**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/compressionlevel/#None): Tidak ada kompresi yang diterapkan. File disimpan apa adanya.
- [**Level1**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/compressionlevel/#Level1): Kompresi tercepat dengan rasio kompresi terendah.
- [**Level2**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/compressionlevel/#Level2): Kompresi lebih cepat dengan rasio kompresi sedikit lebih baik daripada **Level1**.
- [**Level3**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/compressionlevel/#Level3): Menyediakan kompresi yang lebih baik daripada **Level2** dengan dampak sedang pada waktu pemrosesan.
- [**Level4**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/compressionlevel/#Level4): Menyediakan kompresi yang lebih baik daripada **Level3**.
- [**Level5**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/compressionlevel/#Level5): Menyediakan kompresi yang lebih baik daripada **Level4** dengan tambahan waktu pemrosesan.
- [**Level6**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/compressionlevel/#Level6): Kompresi standar yang menawarkan keseimbangan yang baik antara kecepatan pemrosesan dan ukuran file. Ini adalah *tingkat kompresi default*.
- [**Level7**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/compressionlevel/#Level7): Menyediakan kompresi yang lebih baik daripada **Level6** dengan pemrosesan yang lebih lambat.
- [**Level8**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/compressionlevel/#Level8): Menyediakan kompresi yang lebih baik daripada **Level7**.
- [**Level9**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/compressionlevel/#Level9): Kompresi maksimum. Menghasilkan ukuran file terkecil dengan biaya waktu pemrosesan terlama.

Contoh berikut menunjukkan cara menyimpan sebuah presentasi sebagai file PPTX *tanpa kompresi*:

```js
const aspose = { slides: require("aspose.slides.via.java") };

const pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setCompressionLevel(aspose.slides.CompressionLevel.None);

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Sample-out.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

Contoh ini menunjukkan cara menyimpan sebuah presentasi sebagai file PPTX dengan *kompresi maksimum*:

```js
const aspose = { slides: require("aspose.slides.via.java") };

const pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setCompressionLevel(aspose.slides.CompressionLevel.Level9);

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Sample-level9.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

## **Simpan Presentasi tanpa Memperbarui Thumbnail**

Metode [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) mengontrol pembuatan thumbnail saat menyimpan sebuah presentasi ke PPTX:

- Jika diatur ke `true`, thumbnail disegarkan selama penyimpanan. Ini adalah nilai default.
- Jika diatur ke `false`, thumbnail saat ini dipertahankan. Jika presentasi tidak memiliki thumbnail, tidak ada yang dihasilkan.

Pada kode di bawah, presentasi disimpan ke PPTX tanpa memperbarui thumbnail-nya.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setRefreshThumbnail(false);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

Opsi ini membantu mengurangi waktu yang dibutuhkan untuk menyimpan sebuah presentasi dalam format PPTX.

{{% /alert %}}

## **Simpan Pembaruan Progres dalam Persentase**

Pelaporan kemajuan penyimpanan dikonfigurasi melalui metode [setProgressCallback](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) pada [SaveOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/saveoptions/) dan subclass-nya. Berikan proxy Java yang mengimplementasikan antarmuka [IProgressCallback](https://reference.aspose.com/slides/id/java/com.aspose.slides/iprogresscallback/); selama ekspor, callback menerima pembaruan persentase secara periodik.

Potongan kode berikut menunjukkan cara menggunakan `IProgressCallback`.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const ExportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        // Gunakan nilai persentase kemajuan di sini.
        const progress = Math.floor(progressValue);
        console.log(`${progress}% of the file has been converted.`);
    }
});

let saveOptions = new aspose.slides.PdfOptions();
saveOptions.setProgressCallback(ExportProgressHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", aspose.slides.SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

Aspose telah mengembangkan aplikasi [PowerPoint Splitter gratis](https://products.aspose.app/slides/id/splitter) menggunakan API miliknya. Aplikasi ini memungkinkan Anda memecah sebuah presentasi menjadi beberapa file dengan menyimpan slide terpilih sebagai file PPTX atau PPT baru.

{{% /alert %}}

## **FAQ**

**Apakah "penyimpanan cepat" (penyimpanan inkremental) didukung sehingga hanya perubahan yang ditulis?**

Tidak. Penyimpanan membuat file target lengkap setiap kali; penyimpanan cepat inkremental tidak didukung.

**Apakah aman untuk thread menyimpan instance Presentation yang sama dari banyak thread?**

Tidak. Sebuah [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) tidak thread‑safe; simpanlah dari satu thread saja.

**Apa yang terjadi pada tautan hiperteks dan file yang ditautkan secara eksternal saat menyimpan?**

[Hyperlink](/slides/id/nodejs-java/manage-hyperlinks/) dipertahankan. File yang ditautkan secara eksternal (misalnya video melalui jalur relatif) tidak disalin secara otomatis—pastikan jalur yang dirujuk tetap dapat diakses.

**Bisakah saya mengatur/menyimpan metadata dokumen (Penulis, Judul, Perusahaan, Tanggal)?**

Ya. Properti dokumen standar didukung dan akan ditulis ke file saat disimpan.