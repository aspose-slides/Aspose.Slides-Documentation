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
- presentasi ke aliran
- tipe tampilan yang ditentukan
- Format Office Open XML Strict
- mode Zip64
- menyegarkan thumbnail
- menyimpan progres
- Node.js
- JavaScript
- Aspose.Slides
description: "Simpan presentasi PowerPoint dan OpenDocument ke file atau aliran dalam JavaScript dengan Aspose.Slides, dan konfigurasikan output PPTX serta pelaporan progres."
---
## **Ikhtisar**

Setelah Anda membuat presentasi atau [membuka yang sudah ada](/slides/id/nodejs-java/open-presentation/), gunakan metode [Presentation.save](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#save) untuk menulis hasilnya. Aspose.Slides untuk Node.js melalui Java dapat menyimpan presentasi ke file atau aliran dalam format PowerPoint, OpenDocument, PDF, dan format lainnya. Bagian berikut mencakup operasi penyimpanan standar dan opsi yang tersedia untuk output PPTX.

## **Simpan Presentasi ke File**

Untuk menyimpan presentasi ke file, berikan jalur output dan nilai [SaveFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/saveformat/) ke metode [Presentation.save](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#save). Nilai format menentukan jenis file yang dibuat oleh Aspose.Slides.

Contoh berikut membuat presentasi dan menyimpannya sebagai file PPTX:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    // Tambahkan atau modifikasi konten presentasi di sini.

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Simpan Presentasi dalam Format Asli Mereka**

Untuk contoh deteksi file dan aliran, perilaku presentasi yang baru dibuat, dan perbedaan antara format sumber dan output, lihat [Tentukan Format Presentasi Asli](/slides/id/nodejs-java/detect-presentation-source-format/).

Dalam aplikasi pemrosesan batch, format input mungkin tidak diketahui sebelumnya. Setelah memuat file, baca format aslinya dari metode [Presentation.getSourceFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#getSourceFormat). Kirim nilai [SourceFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sourceformat/) yang dihasilkan ke [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slideutil/#toSaveFormat) untuk memperoleh nilai [SaveFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/saveformat/) yang sesuai, lalu gunakan [Presentation.save](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#save) untuk menulis presentasi yang telah dimodifikasi.

Contoh lengkap berikut memproses setiap file dalam direktori input, memperbarui judulnya, dan menyimpannya ke direktori output dalam format asal file tersebut:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const fs = require("fs");
const path = require("path");

const inputDirectory = "Input";
const outputDirectory = "Output";

if (!fs.existsSync(inputDirectory)) {
    console.error("The input directory does not exist.");
} else {
    fs.mkdirSync(outputDirectory, { recursive: true });

    const inputFiles = fs.readdirSync(inputDirectory, { withFileTypes: true })
        .filter((entry) => entry.isFile());

    for (const inputFile of inputFiles) {
        const inputPath = path.join(inputDirectory, inputFile.name);
        try {
            const presentation = new aspose.slides.Presentation(inputPath);
            try {
                const saveFormat = aspose.slides.SlideUtil.toSaveFormat(presentation.getSourceFormat());
                presentation.getDocumentProperties().setTitle("Processed by the batch application");

                const outputPath = path.join(outputDirectory, inputFile.name);
                presentation.save(outputPath, saveFormat);
            } finally {
                presentation.dispose();
            }
        } catch (error) {
            console.error(`Cannot process '${inputPath}': ${error.message}`);
        }
    }
}
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slideutil/#toSaveFormat) memetakan PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP, dan PowerPoint XML ke format penyimpanan presentasi yang sesuai. Itu hanya memetakan format sumber presentasi; tidak dimaksudkan untuk memilih format ekspor seperti PDF, HTML, TIFF, atau gambar. Mengirimkan nilai [SourceFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sourceformat/) yang tidak didukung atau tidak valid akan menghasilkan kesalahan.

File PPT, PPS, dan POT lama menggunakan wadah biner yang sama. Ketika presentasi semacam itu dimuat dari aliran tanpa ekstensi file, file PPS atau POT dapat diidentifikasi sebagai PPT. Jika diperlukan mempertahankan subtipe lama ini, simpan nama file atau metadata format asal secara terpisah dan gunakan saat memilih nama file dan format output.

## **Simpan Presentasi ke Aliran**

Untuk menulis presentasi tanpa bergantung pada jalur file akhir, berikan aliran yang dapat ditulis dan nilai [SaveFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/saveformat/) ke metode [Presentation.save](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#save). Pendekatan ini berguna ketika output harus dikembalikan dari layanan web, disimpan dalam basis data, atau diproses dalam memori.

Contoh berikut menyimpan presentasi baru ke aliran file:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const outputStream = java.newInstanceSync("java.io.FileOutputStream", "output.pptx");
    try {
        presentation.save(outputStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Simpan Presentasi dengan Tipe Tampilan yang Ditentukan**

Anda dapat menentukan tampilan di mana PowerPoint membuka presentasi yang disimpan secara awal. Gunakan metode [ViewProperties.setLastView](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/viewproperties/#setLastView) dengan nilai [ViewType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/viewtype/) sebelum menyimpan.

Contoh berikut mengatur tampilan Slide Master sebagai tampilan awal:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("slide-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Simpan Presentasi dalam Format Office Open XML Strict**

Untuk membuat file PPTX yang mematuhi profil Strict dari Office Open XML, buat instance [PptxOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pptxoptions/) dan gunakan metode [setConformance](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pptxoptions/#setConformance) dengan [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict). Kemudian berikan opsi tersebut ke metode [Presentation.save](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#save).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

const presentation = new aspose.slides.Presentation();
try {
    presentation.save("strict-office-open-xml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Simpan Presentasi dalam Format Office Open XML dalam Mode Zip64**

Arsip ZIP standar membatasi ukuran terkompresi dan tidak terkompresi setiap entri, ukuran total arsip, dan jumlah entri. Karena file PPTX adalah arsip ZIP, presentasi yang sangat besar dapat melebihi batas tersebut. Ekstensi ZIP64 meningkatkan batas ukuran dan jumlah entri yang berlaku.

Gunakan metode [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pptxoptions/#setZip64Mode) untuk mengontrol apakah Aspose.Slides menulis ekstensi ZIP64:

- [IfNecessary](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/zip64mode/#IfNecessary) menggunakan ZIP64 hanya ketika presentasi melebihi batas ZIP standar. Ini adalah mode default.
- [Never](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/zip64mode/#Never) menonaktifkan ekstensi ZIP64.
- [Always](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/zip64mode/#Always) selalu menulis ekstensi ZIP64.

Contoh berikut selalu mengaktifkan ekstensi ZIP64 untuk presentasi output:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setZip64Mode(aspose.slides.Zip64Mode.Always);

    presentation.save("output-zip64.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Jika [Zip64Mode.Never](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/zip64mode/#Never) digunakan dan presentasi tidak dapat muat dalam batas ZIP standar, operasi penyimpanan akan melempar [PptxException](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **Simpan Presentasi dalam Format Office Open XML dengan Tingkat Kompresi**

Untuk output PPTX, Anda dapat menyeimbangkan kecepatan penyimpanan dengan ukuran file dengan menggunakan metode [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pptxoptions/#setCompressionLevel). Kelas [CompressionLevel](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/compressionlevel/) menyediakan nilai-nilai berikut:

- [None](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/compressionlevel/#None) menyimpan data tanpa kompresi.
- [Level1](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/compressionlevel/#Level1) memberikan kompresi tercepat dan output terkompresi terbesar.
- [Level2](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/compressionlevel/#Level2) sampai [Level5](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/compressionlevel/#Level5) secara progresif lebih mengutamakan output lebih kecil daripada kecepatan penyimpanan.
- [Level6](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/compressionlevel/#Level6) menyeimbangkan kecepatan penyimpanan dan ukuran file. Ini adalah tingkat default.
- [Level7](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/compressionlevel/#Level7) dan [Level8](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/compressionlevel/#Level8) lebih mengutamakan output lebih kecil daripada kecepatan penyimpanan.
- [Level9](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/compressionlevel/#Level9) memberikan kompresi terkuat dan memerlukan waktu pemrosesan paling lama.

Contoh berikut menyimpan presentasi tanpa kompresi:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setCompressionLevel(aspose.slides.CompressionLevel.None);

    presentation.save("output-no-compression.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

Contoh berikut menggunakan tingkat kompresi maksimum:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setCompressionLevel(aspose.slides.CompressionLevel.Level9);

    presentation.save("output-maximum-compression.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Simpan Presentasi tanpa Menyegarkan Thumbnail**

Ketika presentasi disimpan sebagai PPTX, metode [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) mengontrol thumbnail dokumennya:

- `true` menghasilkan ulang thumbnail selama operasi penyimpanan. Ini adalah nilai default.
- `false` mempertahankan thumbnail yang ada. Jika presentasi tidak memiliki thumbnail, Aspose.Slides tidak membuatnya.

Contoh berikut menyimpan presentasi tanpa menyegarkan thumbnailnya:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setRefreshThumbnail(false);

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Menonaktifkan penyegaran thumbnail dapat mengurangi waktu yang diperlukan untuk menyimpan file PPTX.
{{% /alert %}}

## **Simpan Pembaruan Progres dalam Persentase**

Untuk memantau operasi penyimpanan, implementasikan antarmuka [IProgressCallback](https://reference.aspose.com/slides/id/java/com.aspose.slides/iprogresscallback/) dengan proxy Java dan kirim implementasinya ke metode [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/saveoptions/#setProgressCallback). Aspose.Slides kemudian memanggil metode [IProgressCallback.reporting](https://reference.aspose.com/slides/id/java/com.aspose.slides/iprogresscallback/#reporting-double-) dengan nilai progres selama ekspor.

Contoh berikut melaporkan progres ekspor PDF ke konsol:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const exportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        const progress = Math.floor(progressValue);
        console.log(`${progress}% of the file has been converted.`);
    }
});

const options = new aspose.slides.PdfOptions();
options.setProgressCallback(exportProgressHandler);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose menyediakan [PowerPoint Splitter](https://products.aspose.app/slides/id/splitter) gratis yang dibangun dengan API Aspose.Slides. Alat ini menyimpan slide terpilih dari sebuah presentasi sebagai file PPT atau PPTX terpisah.
{{% /alert %}}

## **FAQ**

**Apakah Aspose.Slides mendukung penyimpanan inkremental atau “fast save”?**

**Tidak.** Setiap operasi penyimpanan menulis file output lengkap alih‑alih memperbarui hanya bagian yang berubah.

**Dapatkah beberapa thread menyimpan instance Presentation yang sama?**

**Tidak.** Instance [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) tidak thread‑safe. Akses dan simpan setiap instance hanya dari satu thread pada satu waktu.

**Apa yang terjadi pada hyperlink dan file yang terhubung secara eksternal ketika saya menyimpan presentasi?**

[Hyperlinks](/slides/id/nodejs-java/manage-hyperlinks/) tetap ada dalam presentasi. Aspose.Slides tidak menyalin file yang terhubung secara eksternal, sehingga presentasi yang disimpan tetap harus dapat mengakses lokasi file tersebut.

**Bisakah saya menyimpan metadata dokumen seperti penulis, judul, perusahaan, dan tanggal pembuatan?**

**Ya.** Atur [document properties](/slides/id/nodejs-java/presentation-properties/) yang sesuai sebelum menyimpan, dan Aspose.Slides akan menulisnya ke file output.