---
title: Konversi Presentasi PowerPoint ke Markdown dalam JavaScript
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
- PowerPoint
- presentasi
- Markdown
- Node.js
- JavaScript
- Aspose.Slides
description: "Konversi slide PowerPoint dalam JavaScript—PPT, PPTX—menjadi Markdown bersih dengan Aspose.Slides untuk Node.js via Java, otomatisasi dokumentasi dan mempertahankan format."
---
## **Pendahuluan**

Aspose.Slides memungkinkan Anda mengonversi presentasi PowerPoint ke Markdown, yang dapat berguna untuk alur kerja dokumentasi, pembuatan situs statis, migrasi konten, dan penerbitan teks yang dikontrol versi. API mendukung ekspor langsung dari presentasi PPT dan PPTX ke file MD dan menyediakan opsi tambahan untuk mengontrol bagaimana konten slide direpresentasikan dalam dokumen Markdown yang dihasilkan.

Anda dapat mengekspor presentasi sebagai Markdown biasa, memilih dari berbagai varian Markdown seperti CommonMark dan GitHub Flavored Markdown, serta mengonfigurasi cara gambar ditangani selama ekspor. Untuk presentasi yang berisi konten visual, Aspose.Slides juga memungkinkan Anda menyimpan gambar ke folder terpisah dan merujuknya dari file Markdown yang dihasilkan.

{{% alert color="warning" %}} 

Ekspor PowerPoint ke markdown **tanpa gambar** secara default. Jika Anda ingin mengekspor dokumen PowerPoint yang berisi gambar, Anda perlu memanggil `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` dan juga mengatur `BasePath` tempat gambar yang dirujuk dalam dokumen markdown akan disimpan.

{{% /alert %}} 

## **Konversi PowerPoint ke Markdown**

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) untuk mewakili objek presentasi.
2. Gunakan metode [save](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#save-aspose.slides.IXamlOptions-) untuk menyimpan objek sebagai file markdown.

Kode JavaScript ini menunjukkan cara mengonversi PowerPoint ke markdown:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.md", aspose.slides.SaveFormat.Md);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Konversi PowerPoint ke Varian Markdown**

Aspose.Slides memungkinkan Anda mengonversi PowerPoint ke markdown (yang berisi sintaks dasar), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab, dan 17 varian markdown lainnya.

Kode JavaScript ini menunjukkan cara mengonversi PowerPoint ke CommonMark:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setFlavor(aspose.slides.Flavor.CommonMark);
    pres.save("pres.md", aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

23 varian markdown yang didukung [didaftar di bawah enumeration Flavor](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/flavor/) dari kelas [MarkdownSaveOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/markdownsaveoptions/).

## **Konversi Presentasi yang Mengandung Gambar ke Markdown**

Kelas [MarkdownSaveOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/markdownsaveoptions/) menyediakan properti dan enumerasi yang memungkinkan Anda menggunakan opsi atau pengaturan tertentu untuk file markdown yang dihasilkan. Enum [MarkdownExportType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/markdownexporttype/), misalnya, dapat diatur ke nilai yang menentukan bagaimana gambar dirender atau ditangani: `Sequential`, `TextOnly`, `Visual`.

### **Konversi Gambar Secara Berurutan**

Jika Anda ingin gambar muncul secara individual satu demi satu dalam markdown yang dihasilkan, Anda harus memilih opsi sequential. Kode JavaScript ini menunjukkan cara mengonversi presentasi yang berisi gambar ke markdown:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setShowHiddenSlides(true);
    markdownSaveOptions.setShowSlideNumber(true);
    markdownSaveOptions.setFlavor(aspose.slides.Flavor.Github);
    markdownSaveOptions.setExportType(aspose.slides.MarkdownExportType.Sequential);
    markdownSaveOptions.setNewLineType(aspose.slides.NewLineType.Windows);
    pres.save("doc.md", java.newArray("int", [1, 2, 3, 4, 5, 6, 7, 8, 9]), aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Konversi Gambar Secara Visual**

Jika Anda ingin gambar muncul bersama dalam markdown yang dihasilkan, Anda harus memilih opsi visual. Dalam hal ini, gambar akan disimpan ke direktori saat ini dari aplikasi (dan jalur relatif akan dibuat untuknya dalam dokumen markdown), atau Anda dapat menentukan jalur dan nama folder yang Anda inginkan.

Kode JavaScript ini mendemonstrasikan operasinya:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    final var outPath = "c:/documents";
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setExportType(aspose.slides.MarkdownExportType.Visual);
    markdownSaveOptions.setImagesSaveFolderName("md-images");
    markdownSaveOptions.setBasePath(outPath);
    pres.save("pres.md", aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Do hyperlinks survive the export to Markdown?**

Ya. Teks [hyperlinks](/slides/id/nodejs-java/manage-hyperlinks/) dipertahankan sebagai tautan Markdown standar. Slide [transitions](/slides/id/nodejs-java/slide-transition/) dan [animations](/slides/id/nodejs-java/powerpoint-animation/) tidak dikonversi.

**Can I speed up conversion by running it in multiple threads?**

Anda dapat memparalelkan antar file, tetapi [don’t share](/slides/id/nodejs-java/multithreading/) instance [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) yang sama di antara utas. Gunakan instance/proses terpisah per file untuk menghindari kontensi.

**What happens to images—where are they saved, and are the paths relative?**

[Images](/slides/id/nodejs-java/image/) diekspor ke folder khusus, dan file Markdown merujuknya dengan jalur relatif secara default. Anda dapat mengonfigurasi jalur output dasar dan nama folder aset untuk menjaga struktur repositori yang dapat diprediksi.