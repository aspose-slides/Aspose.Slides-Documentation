---
title: Mengonversi Presentasi PowerPoint ke Markdown dalam JavaScript
linktitle: PowerPoint ke Markdown
type: docs
weight: 140
url: /id/nodejs-java/convert-powerpoint-to-markdown/
keywords:
  - konversi PowerPoint
  - konversi presentasi
  - konversi slide
  - konversi PPT
  - konversi PPTX
  - PowerPoint ke MD
  - presentasi ke MD
  - slide ke MD
  - PPT ke MD
  - PPTX ke MD
  - simpan PowerPoint sebagai Markdown
  - simpan presentasi sebagai Markdown
  - simpan slide sebagai Markdown
  - simpan PPT sebagai MD
  - simpan PPTX sebagai MD
  - ekspor PPT ke MD
  - ekspor PPTX ke MD
  - ekspor gambar Markdown
  - tautan gambar CDN
  - PowerPoint
  - presentasi
  - Markdown
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Konversi presentasi PPT dan PPTX ke Markdown dalam JavaScript serta mengontrol tempat penyimpanan dan referensi gambar bitmap, metafile, dan SVG yang diekspor."
---
## **Gambaran Umum**

Aspose.Slides for Node.js via Java dapat mengonversi presentasi PPT dan PPTX ke Markdown untuk dokumentasi, situs statis, migrasi konten, dan alur kerja kontrol versi. Anda dapat memilih varian Markdown, mengontrol cara konten slide dirender, serta menentukan di mana gambar yang diekspor disimpan dan bagaimana Markdown yang dihasilkan merujuknya.

Secara bawaan, ekspor Markdown menggunakan output hanya teks. Untuk mengekspor konten visual, atur tipe ekspor dengan metode [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/markdownsaveoptions/) menjadi nilai `Sequential` atau `Visual` dari enumerasi [MarkdownExportType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/markdownexporttype/). `Sequential` merender item slide secara terpisah dan berurutan, sedangkan `Visual` menjaga item yang dikelompokkan bersama agar hubungan visualnya tetap terjaga. Nilai `TextOnly` tidak menghasilkan sumber daya gambar, sehingga callback penyimpanan gambar tidak dipanggil dalam mode tersebut.

## **Mengonversi Presentasi ke Markdown**

Muat file sumber dengan kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/), lalu panggil metode [Presentation.save](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) dengan nilai `Md` dari enumerasi [SaveFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/saveformat/).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.md", aspose.slides.SaveFormat.Md);
} finally {
    presentation.dispose();
}
```

## **Pilih Varian Markdown**

Metode [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/markdownsaveoptions/) mengatur spesifikasi Markdown yang digunakan untuk output. Enumerasi [Flavor](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/flavor/) mencakup CommonMark, GitHub Flavored Markdown, dan varian lain yang didukung.

Contoh berikut mengekspor presentasi sebagai CommonMark:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setFlavor(aspose.slides.Flavor.CommonMark);

    presentation.save("presentation.md", aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

## **Ekspor Gambar Menggunakan Perilaku Penyimpanan Lokal Default**

Kelas [MarkdownSaveOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/markdownsaveoptions/) menyediakan dua metode untuk mengonfigurasi penyimpanan gambar secara lokal:

- [setBasePath](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/markdownsaveoptions/) menentukan direktori dasar untuk dokumen Markdown dan sumber dayanya.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/markdownsaveoptions/) menentukan subdirektori gambar. Nilai bakunya adalah `Images`.

Contoh berikut merender konten visual, menulis gambar ke `output/assets`, dan membuat referensi gambar relatif dalam dokumen Markdown:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");

const outputDirectory = "output";
fs.mkdirSync(outputDirectory, { recursive: true });

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setExportType(aspose.slides.MarkdownExportType.Visual);
    options.setBasePath(outputDirectory);
    options.setImagesSaveFolderName("assets");

    const markdownPath = path.join(outputDirectory, "presentation.md");
    presentation.save(markdownPath, aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

Perilaku ini juga berfungsi sebagai cadangan ketika penangani penyimpanan gambar khusus mengembalikan `false`.

## **Sesuaikan Penyimpanan Gambar dan Tautan Markdown**

Gunakan metode [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/markdownsaveoptions/) untuk mendaftarkan callback bagi sumber daya bitmap dan metafile non‑SVG yang dihasilkan selama ekspor Markdown. Callback `MarkdownImageSavingHandler` menerima objek [IImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/iimage/), nilai [ImageFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/imageformat/), dan tautan Markdown yang dihasilkan sebagai array string satu elemen. Simpan atau unggah gambar dengan format yang diberikan, lalu ganti `link[0]` dengan referensi yang harus muncul dalam output Markdown.

Sumber daya yang dihasilkan dalam format SVG ditangani secara terpisah. Daftarkan callback dengan metode [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/markdownsaveoptions/). Callback `MarkdownSvgImageSavingHandler` menerima objek `ISvgImage` dan array `link` satu elemen. SVG tidak memiliki argumen `ImageFormat`; tulis atau unggah data XMLnya melalui metode `ISvgImage.getSvgData`. Bergantung pada mode ekspor dan pengelompokan visual, SVG dalam presentasi sumber dapat dirasterisasi atau digabungkan dengan konten lain; sumber daya non‑SVG yang dihasilkan kemudian diteruskan ke callback penyimpanan gambar. Daftarkan kedua callback ketika setiap sumber daya visual yang diekspor memerlukan pemrosesan khusus.

Di Node.js, buat implementasi antarmuka callback ini dengan `java.newProxy`.

Nilai kembali handler menentukan siapa yang memproses gambar:

- Kembalikan `true` setelah handler menyimpan, mengunggah, mengubah, atau memproses gambar dan menetapkan nilai valid ke `link[0]`. Aspose.Slides menulis nilai tersebut ke dokumen Markdown dan tidak melakukan penyimpanan lokal bawaan.
- Kembalikan `false` untuk membiarkan Aspose.Slides menyimpan gambar secara lokal dan menghasilkan tautannya sesuai nilai yang ditetapkan oleh [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/markdownsaveoptions/) dan [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="Important" %}}

Handler yang mengembalikan `true` mengambil tanggung jawab atas gambar. Jika mengembalikan `true` tanpa menetapkan tautan yang valid dan tidak kosong, ekspor akan gagal dengan `InvalidOperationException`.

{{% /alert %}}

### **Simpan Gambar ke Direktori Asal CDN dan Gunakan URL Eksternal**

Contoh berikut memperlakukan `cdn-origin/presentations/quarterly-report` sebagai direktori asal CDN yang dipasang atau disinkronkan. Setiap handler mengekstrak nama file yang dihasilkan, menyimpan gambar ke direktori khusus tersebut, dan mengganti referensi lokal yang dihasilkan dengan URL CDN publik. Contoh tersebut tidak melakukan unggahan jaringan: URL menjadi valid hanya setelah direktori dipasang sebagai asal CDN atau file‑filenya dipublikasikan ke CDN. Untuk penyimpanan objek, ganti penulisan sistem berkas dengan operasi unggah SDK penyimpanan dan tetapkan `link[0]` hanya setelah unggahan berhasil.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");
const path = require("path");

const outputDirectory = "output";
const publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
const storageDirectory = path.join("cdn-origin", "presentations", "quarterly-report");
fs.mkdirSync(outputDirectory, { recursive: true });
fs.mkdirSync(storageDirectory, { recursive: true });

const getFileNameFromLink = generatedLink => {
    const urlCompatibleLink = String(generatedLink).replace(/\\/g, "/");
    return path.posix.basename(urlCompatibleLink);
};
const buildPublicUrl = fileName => publicBaseUrl + "/" + encodeURIComponent(fileName);

const imageSavingHandler = java.newProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler", {
    invoke: function(image, format, link) {
        if (image.getWidth() < 128 || image.getHeight() < 128) {
            return false;
        }

        const fileName = getFileNameFromLink(link[0]);
        const storagePath = path.join(storageDirectory, fileName);
        image.save(storagePath, format);
        link[0] = buildPublicUrl(fileName);
        return true;
    }
});

const svgImageSavingHandler = java.newProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler", {
    invoke: function(svgImage, link) {
        const fileName = getFileNameFromLink(link[0]);
        const storagePath = path.join(storageDirectory, fileName);
        fs.writeFileSync(storagePath, svgImage.getSvgData());
        link[0] = buildPublicUrl(fileName);
        return true;
    }
});

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setExportType(aspose.slides.MarkdownExportType.Visual);
    options.setBasePath(outputDirectory);
    options.setImagesSaveFolderName("fallback-images");
    options.setImageSaving(imageSavingHandler);
    options.setSvgImageSaving(svgImageSavingHandler);

    const markdownPath = path.join(outputDirectory, "presentation.md");
    presentation.save(markdownPath, aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

Handler bitmap sengaja mengembalikan `false` untuk gambar yang lebih kecil dari 128 × 128 piksel, sehingga Aspose.Slides menyimpan gambar tersebut ke `output/fallback-images` menggunakan perilaku default. Sumber daya bitmap dan metafile yang lebih besar, serta sumber daya SVG, ditangani oleh kode khusus. Misalnya, referensi lokal yang dihasilkan seperti `fallback-images/image1.png` menjadi `https://cdn.example.com/presentations/quarterly-report/image1.png`. Handler hanya menggunakan jalur sistem operasi saat menulis file; tautan yang ditulis ke Markdown menggunakan garis miring maju dan nama file yang di‑URL‑escape. Terapkan aturan yang sama saat membangun tautan relatif: gunakan `/`, bukan pemisah direktori khusus platform.

## **FAQ**

**Apakah satu handler dapat memproses gambar raster dan gambar SVG?**

Tidak. Gunakan [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/markdownsaveoptions/) untuk sumber daya bitmap dan metafile yang dihasilkan serta [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/markdownsaveoptions/) untuk sumber daya yang dihasilkan sebagai SVG. Yang pertama menyediakan objek [IImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/iimage/) dan nilai [ImageFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/imageformat/); yang kedua menyediakan objek `ISvgImage` yang data SVG‑nya dapat dibaca dengan `ISvgImage.getSvgData`. SVG sumber yang dirasterisasi selama ekspor diproses oleh callback penyimpanan gambar.

**Apa yang terjadi ketika handler penyimpanan gambar mengembalikan `false`?**

Aspose.Slides menggunakan perilaku penyimpanan lokal bawaan. Lokasi gambar dan referensi yang dihasilkan diatur oleh nilai yang ditetapkan dengan [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/markdownsaveoptions/) dan [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/markdownsaveoptions/).

**Apakah handler dapat memberikan URL tanpa menyimpan gambar secara lokal?**

Ya. Handler dapat mengunggah gambar ke penyimpanan objek atau menyerahkannya ke layanan lain, menetapkan URL yang dihasilkan ke `link[0]`, dan mengembalikan `true`. Handler harus menyelesaikan pemrosesan sendiri; mengembalikan `true` menghentikan penyimpanan lokal bawaan.

**Mengapa ekspor Markdown melempar `InvalidOperationException` dari handler?**

Pengecualian ini terjadi ketika handler mengembalikan `true` tetapi tidak menyediakan tautan yang valid. Tetapkan jalur relatif atau URL eksternal yang harus ditulis ke Markdown sebelum mengembalikan `true`.

**Pemilih pemisah jalur mana yang harus digunakan pada tautan gambar?**

Gunakan garis miring maju dalam tautan Markdown dan URL. Gunakan `path.join` hanya untuk jalur sistem berkas, kemudian susun atau normalisasi referensi Markdown secara terpisah.

**Apakah tautan hiperteks dipertahankan selama ekspor Markdown?**

Ya. Teks [tautan](/slides/id/nodejs-java/manage-hyperlinks/) dipertahankan sebagai tautan Markdown standar. [Transisi](/slides/id/nodejs-java/slide-transition/) slide dan [animasi](/slides/id/nodejs-java/powerpoint-animation/) tidak dikonversi.

**Bisakah presentasi dikonversi ke Markdown secara paralel?**

Anda dapat memproses file presentasi yang berbeda secara paralel, tetapi jangan bagikan instance [Presentation](/slides/id/nodejs-java/aspose.slides/presentation/) yang sama antar utas. Ikuti [panduan multithreading](/slides/id/nodejs-java/multithreading/) dan gunakan instance terpisah untuk setiap file.