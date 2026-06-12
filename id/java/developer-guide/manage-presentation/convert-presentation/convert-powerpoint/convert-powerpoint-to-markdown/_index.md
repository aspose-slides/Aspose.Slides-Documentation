---
title: Konversi Presentasi PowerPoint ke Markdown dalam Java
linktitle: PowerPoint ke Markdown
type: docs
weight: 140
url: /id/java/convert-powerpoint-to-markdown/
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
- Java
- Aspose.Slides
description: "Konversi slide PowerPoint—PPT, PPTX—ke Markdown bersih dengan Aspose.Slides untuk Java, otomatisasi dokumentasi dan pertahankan format."
---
## **Pendahuluan**

Aspose.Slides memungkinkan Anda mengonversi presentasi PowerPoint ke Markdown, yang dapat berguna untuk alur kerja dokumentasi, pembuatan situs statis, migrasi konten, dan penerbitan teks yang dikontrol versi. API mendukung ekspor langsung dari presentasi PPT dan PPTX ke file MD serta menyediakan opsi tambahan untuk mengontrol bagaimana konten slide direpresentasikan dalam dokumen Markdown yang dihasilkan.

Anda dapat mengekspor presentasi sebagai Markdown biasa, memilih dari berbagai varian Markdown seperti CommonMark dan GitHub Flavored Markdown, serta mengonfigurasi cara penanganan gambar selama ekspor. Untuk presentasi yang berisi konten visual, Aspose.Slides juga memungkinkan Anda menyimpan gambar ke folder terpisah dan merujuknya dari file Markdown yang dihasilkan.

{{% alert color="warning" %}}
Ekspor PowerPoint ke markdown secara **tanpa gambar** secara default. Jika Anda ingin mengekspor dokumen PowerPoint yang berisi gambar, Anda harus menggunakan `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` dan juga menggunakan `setBasePath` tempat gambar yang dirujuk dalam dokumen markdown akan disimpan.
{{% /alert %}}

## **Konversi PowerPoint ke Markdown**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) untuk merepresentasikan objek presentasi.
2. Gunakan metode [Save ](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) untuk menyimpan objek sebagai file markdown.

Kode Java ini menunjukkan cara mengonversi PowerPoint ke markdown:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Konversi PowerPoint ke Varian Markdown**

Aspose.Slides memungkinkan Anda mengonversi PowerPoint ke markdown (mengandung sintaks dasar), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab, dan 17 varian markdown lainnya.

Kode Java ini menunjukkan cara mengonversi PowerPoint ke CommonMark:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setFlavor(Flavor.CommonMark);
    pres.save("pres.md", SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

23 varian markdown yang didukung [terdaftar di bawah enumerasi Flavor](https://reference.aspose.com/slides/id/java/com.aspose.slides/flavor/) dari kelas [MarkdownSaveOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/markdownsaveoptions/).

## **Konversi Presentasi yang Mengandung Gambar ke Markdown**

Kelas [MarkdownSaveOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/markdownsaveoptions/) menyediakan properti dan enumerasi yang memungkinkan Anda menggunakan opsi atau pengaturan tertentu untuk file markdown yang dihasilkan. Enum [MarkdownExportType](https://reference.aspose.com/slides/id/java/com.aspose.slides/markdownexporttype/), misalnya, dapat diatur ke nilai yang menentukan bagaimana gambar ditampilkan atau ditangani: `Sequential`, `TextOnly`, `Visual`.

### **Konversi Gambar Secara Berurutan**

Jika Anda ingin gambar muncul secara individual satu demi satu dalam markdown yang dihasilkan, Anda harus memilih opsi sequential. Kode Java ini menunjukkan cara mengonversi presentasi yang berisi gambar ke markdown:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setShowHiddenSlides(true);
    markdownSaveOptions.setShowSlideNumber(true);
    markdownSaveOptions.setFlavor(Flavor.Github);
    markdownSaveOptions.setExportType(MarkdownExportType.Sequential);
    markdownSaveOptions.setNewLineType(NewLineType.Windows);
    pres.save("doc.md", new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Konversi Gambar Secara Visual**

Jika Anda ingin gambar muncul bersama dalam markdown yang dihasilkan, Anda harus memilih opsi visual. Dalam kasus ini, gambar akan disimpan ke direktori saat ini dari aplikasi (dan jalur relatif akan dibuat untuk mereka dalam dokumen markdown), atau Anda dapat menentukan jalur dan nama folder yang diinginkan.

Kode Java ini mendemonstrasikan operasi tersebut:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    final String outPath = "c:/documents";
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setExportType(MarkdownExportType.Visual);
    markdownSaveOptions.setImagesSaveFolderName("md-images");
    markdownSaveOptions.setBasePath(outPath);
    pres.save("pres.md", SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Apakah tautan hiperteks tetap ada setelah ekspor ke Markdown?**

Ya. Teks [tautan](/slides/id/java/manage-hyperlinks/) dipertahankan sebagai tautan Markdown standar. Slide [transisi](/slides/id/java/slide-transition/) dan [animasi](/slides/id/java/powerpoint-animation/) tidak dikonversi.

**Bisakah saya mempercepat konversi dengan menjalankannya di beberapa thread?**

Anda dapat memparalelkan antar file, tetapi [jangan bagikan](/slides/id/java/multithreading/) instance [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) yang sama antar thread. Gunakan instance/proses terpisah per file untuk menghindari kontensi.

**Apa yang terjadi pada gambar—di mana mereka disimpan, dan apakah jalurnya relatif?**

[Gambar](/slides/id/java/image/) diekspor ke folder khusus, dan file Markdown merujuknya dengan jalur relatif secara default. Anda dapat mengonfigurasi jalur output dasar dan nama folder aset untuk menjaga struktur repositori yang dapat diprediksi.