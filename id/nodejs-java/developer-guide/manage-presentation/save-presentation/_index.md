---
title: Menyimpan Presentasi dalam JavaScript
linktitle: Menyimpan Presentasi
type: docs
weight: 80
url: /id/nodejs-java/save-presentation/
keywords:
  - menyimpan PowerPoint
  - menyimpan OpenDocument
  - menyimpan presentasi
  - menyimpan slide
  - menyimpan PPT
  - menyimpan PPTX
  - menyimpan ODP
  - presentasi ke file
  - presentasi ke stream
  - tipe tampilan yang telah ditentukan
  - Format Strict Office Open XML
  - mode Zip64
  - menyegarkan thumbnail
  - menyimpan progres
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Temukan cara menyimpan presentasi menggunakan Aspose.Slides untuk Node.js melalui Java—ekspor ke PowerPoint atau OpenDocument sambil mempertahankan tata letak, font, dan efek."
---
## **Ikhtisar**

[Open Presentations in JavaScript](/slides/id/nodejs-java/open-presentation/) menjelaskan cara menggunakan kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) untuk membuka presentasi. Artikel ini menjelaskan cara membuat dan menyimpan presentasi. Kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) berisi konten sebuah presentasi. Baik Anda membuat presentasi dari awal maupun memodifikasi yang sudah ada, Anda harus menyimpannya setelah selesai. Dengan Aspose.Slides untuk Node.js, Anda dapat menyimpan ke **file** atau **stream**. Artikel ini menjelaskan berbagai cara menyimpan sebuah presentasi.

## **Simpan Presentasi ke File**

Simpan sebuah presentasi ke file dengan memanggil metode `save` dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/). Berikan nama file dan format penyimpanan ke metode tersebut. Contoh berikut menunjukkan cara menyimpan presentasi dengan Aspose.Slides.

```js
// Membuat instance kelas Presentation yang mewakili file presentasi.
let presentation = new aspose.slides.Presentation();
try {
    // Lakukan beberapa pekerjaan di sini...

    // Simpan presentasi ke file.
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Simpan Presentasi ke Stream**

Anda dapat menyimpan sebuah presentasi ke stream dengan memberikan output stream ke metode `save` pada kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/). Sebuah presentasi dapat ditulis ke berbagai jenis stream. Pada contoh di bawah, kami membuat presentasi baru dan menyimpannya ke file stream.

```js
// Membuat instance kelas Presentation yang mewakili file presentasi.
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

Aspose.Slides memungkinkan Anda mengatur tampilan awal yang digunakan PowerPoint saat presentasi yang dihasilkan dibuka melalui kelas [ViewProperties](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/viewproperties/). Gunakan metode [setLastView](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/viewproperties/#setLastView) dengan nilai dari enumerasi [ViewType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/viewtype/).

```js
let presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Simpan Presentasi dalam Format Strict Office Open XML**

Aspose.Slides memungkinkan Anda menyimpan presentasi dalam format Strict Office Open XML. Gunakan kelas [PptxOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pptxoptions/) dan atur properti conformance‑nya saat menyimpan. Jika Anda menetapkan [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict), file output akan disimpan dalam format Strict Office Open XML.

Contoh di bawah membuat sebuah presentasi dan menyimpannya dalam format Strict Office Open XML.

```js
let options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

// Membuat instance kelas Presentation yang mewakili file presentasi.
let presentation = new aspose.slides.Presentation();
try {
    // Simpan presentasi dalam format Strict Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Simpan Presentasi dalam Format Office Open XML dalam Mode Zip64**

File Office Open XML adalah arsip ZIP yang menerapkan batas 4 GB (2^32 byte) pada ukuran tidak terkompresi sebuah file, ukuran terkompresi sebuah file, dan total ukuran arsip, serta membatasi arsip hingga 65.535 (2^16‑1) file. Ekstensi format ZIP64 mengangkat batas tersebut menjadi 2^64.

Metode [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pptxoptions/#getZip64Mode) memungkinkan Anda memilih kapan menggunakan ekstensi format ZIP64 saat menyimpan file Office Open XML.

Metode ini dapat digunakan dengan mode berikut:

- [IfNecessary](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/zip64mode/#IfNecessary) menggunakan ekstensi format ZIP64 hanya jika presentasi melebihi batasan di atas. Ini adalah mode default.
- [Never](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/zip64mode/#Never) tidak pernah menggunakan ekstensi format ZIP64.
- [Always](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/zip64mode/#Always) selalu menggunakan ekstensi format ZIP64.

Kode berikut menunjukkan cara menyimpan presentasi sebagai PPTX dengan ekstensi format ZIP64 diaktifkan:

```js
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
Saat Anda menyimpan dengan [Zip64Mode.Never](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/zip64mode/#Never), sebuah [PptxException](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pptxexception/) akan dilempar jika presentasi tidak dapat disimpan dalam format ZIP32.
{{% /alert %}}

## **Simpan Presentasi tanpa Menyegarkan Thumbnail**

Metode [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) mengontrol pembuatan thumbnail saat menyimpan presentasi ke PPTX:

- Jika diatur ke `true`, thumbnail akan disegarkan selama penyimpanan. Ini adalah default.
- Jika diatur ke `false`, thumbnail saat ini dipertahankan. Jika presentasi tidak memiliki thumbnail, tidak ada yang dihasilkan.

Pada kode di bawah, presentasi disimpan ke PPTX tanpa menyegarkan thumbnailnya.

```js
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
Opsi ini membantu mengurangi waktu yang diperlukan untuk menyimpan presentasi dalam format PPTX.
{{% /alert %}}

## **Simpan Pembaruan Progres dalam Persentase**

Pelaporan kemajuan penyimpanan dikonfigurasi melalui metode [setProgressCallback](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) pada [SaveOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/saveoptions/) dan subclass‑nya. Sediakan proxy Java yang mengimplementasikan antarmuka [IProgressCallback](https://reference.aspose.com/slides/id/java/com.aspose.slides/iprogresscallback/); selama ekspor, callback akan menerima pembaruan persentase secara periodik.

Potongan kode berikut menunjukkan cara menggunakan `IProgressCallback`.

```javascript
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
Aspose telah mengembangkan sebuah [aplikasi PowerPoint Splitter gratis](https://products.aspose.app/slides/id/splitter) menggunakan API miliknya. Aplikasi ini memungkinkan Anda membagi sebuah presentasi menjadi beberapa file dengan menyimpan slide yang dipilih sebagai file PPTX atau PPT baru.
{{% /alert %}}

## **FAQ**

**Apakah "fast save" (penyimpanan inkremental) didukung sehingga hanya perubahan yang ditulis?**

Tidak. Penyimpanan selalu membuat file target lengkap setiap kali; “fast save” inkremental tidak didukung.

**Apakah aman untuk thread menyimpan instance Presentation yang sama dari beberapa thread?**

Tidak. Sebuah instance [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) [tidak thread‑safe](/slides/id/nodejs-java/multithreading/); simpanlah dari satu thread.

**Apa yang terjadi pada hyperlink dan file yang ditautkan secara eksternal saat menyimpan?**

[Hyperlink](/slides/id/nodejs-java/manage-hyperlinks/) dipertahankan. File yang ditautkan secara eksternal (misalnya video melalui jalur relatif) tidak disalin secara otomatis — pastikan jalur yang dirujuk tetap dapat diakses.

**Bisakah saya mengatur/menyimpan metadata dokumen (Penulis, Judul, Perusahaan, Tanggal)?**

Ya. [Properti dokumen](/slides/id/nodejs-java/presentation-properties/) standar didukung dan akan ditulis ke file saat disimpan.