---
title: Konversi Presentasi PowerPoint ke Markdown dalam PHP
linktitle: PowerPoint ke Markdown
type: docs
weight: 140
url: /id/php-java/convert-powerpoint-to-markdown/
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
- eksporPPTX ke MD
- PowerPoint
- presentasi
- Markdown
- PHP
- Aspose.Slides
description: "Konversi slide PowerPoint — PPT, PPTX — menjadi Markdown bersih dengan Aspose.Slides untuk PHP via Java, otomatisasi dokumentasi dan pertahankan format."
---
## **Pendahuluan**

Aspose.Slides memungkinkan Anda mengonversi presentasi PowerPoint ke Markdown, yang dapat berguna untuk alur kerja dokumentasi, pembuatan situs statis, migrasi konten, dan penerbitan teks yang dikontrol versi. API mendukung ekspor langsung dari presentasi PPT dan PPTX ke file MD serta menyediakan opsi tambahan untuk mengendalikan bagaimana konten slide direpresentasikan dalam dokumen Markdown yang dihasilkan.

Anda dapat mengekspor presentasi sebagai Markdown biasa, memilih dari berbagai varian Markdown seperti CommonMark dan GitHub Flavored Markdown, serta mengonfigurasi cara penanganan gambar selama ekspor. Untuk presentasi yang berisi konten visual, Aspose.Slides juga memungkinkan Anda menyimpan gambar ke folder terpisah dan merujuknya dari file Markdown yang dihasilkan.

{{% alert color="warning" %}}

Ekspor PowerPoint-ke-Markdown secara default **tanpa gambar**. Jika Anda ingin mengekspor dokumen PowerPoint yang berisi gambar, Anda perlu mengatur `ExportType = MarkdownExportType::Visual` dan menentukan `BasePath`, tempat gambar yang dirujuk dalam dokumen Markdown akan disimpan.

{{% /alert %}}

## **Mengonversi Presentasi ke Markdown**

Bagian ini menjelaskan bagaimana Aspose.Slides mengonversi presentasi PowerPoint dan OpenDocument (PPT, PPTX, ODP) menjadi Markdown bersih, mempertahankan hierarki slide, teks, dan format inti sehingga Anda dapat menggunakan kembali konten dalam dokumentasi atau alur kerja yang dikontrol versi tanpa upaya manual tambahan.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) untuk mewakili presentasi.
1. Gunakan metode [save](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#save) untuk mengekspornya sebagai file Markdown.

Kode PHP berikut menunjukkan cara mengonversi presentasi PowerPoint ke Markdown:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.md", SaveFormat::Md);
} finally {
    $presentation->dispose();
}
```

## **Mengonversi Presentasi ke Varian Markdown**

Aspose.Slides memungkinkan Anda mengonversi presentasi PowerPoint ke Markdown dengan sintaks dasar, serta ke CommonMark, GitHub‑flavored Markdown, Trello, XWiki, GitLab, dan tujuh belas varian Markdown lainnya.

Kode PHP berikut mendemonstrasikan cara mengonversi presentasi PowerPoint ke CommonMark:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setFlavor(Flavor->CommonMark);

    $presentation->save("presentation.md", SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

23 varian Markdown yang didukung tercantum dalam [enumerasi Flavor](https://reference.aspose.com/slides/id/php-java/aspose.slides/flavor/).

## **Mengonversi Presentasi yang Mengandung Gambar ke Markdown**

Kelas [MarkdownSaveOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/markdownsaveoptions/) menyediakan properti dan enumerasi yang memungkinkan Anda mengonfigurasi file Markdown yang dihasilkan. Misalnya, enumerasi [MarkdownExportType](https://reference.aspose.com/slides/id/php-java/aspose.slides/markdownexporttype/) menentukan cara penanganan gambar: `Sequential`, `TextOnly`, atau `Visual`.

{{% alert color="warning" %}}

Secara default, ekspor PowerPoint‑ke‑Markdown **tidak menyertakan gambar**. Untuk menyisipkan gambar, panggil `markdownSaveOptions.setExportType(MarkdownExportType::Visual)` dan atur `BasePath` yang menentukan tempat gambar yang dirujuk dalam file Markdown akan disimpan.

{{% /alert %}}

### **Mengonversi Gambar Secara Berurutan**

Jika Anda ingin gambar muncul secara individual, satu per satu, dalam Markdown yang dihasilkan, pilih opsi `Sequential`. Kode PHP berikut menunjukkan cara mengonversi presentasi yang berisi gambar ke Markdown:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setShowHiddenSlides(true);
    $saveOptions->setShowSlideNumber(true);
    $saveOptions->setFlavor(Flavor->Github);
    $saveOptions->setExportType(MarkdownExportType::Sequential);
    $saveOptions->setNewLineType(NewLineType::Windows);

    $slideIndices = array(1, 2, 3, 4);
    $presentation->save("presentation.md", $slideIndices, SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

### **Mengonversi Gambar Secara Visual**

Jika Anda ingin gambar muncul bersama dalam Markdown yang dihasilkan, pilih opsi `Visual`. Dalam kasus ini, gambar disimpan ke direktori kerja aplikasi (dan jalur relatif dihasilkan untuknya dalam dokumen Markdown), atau Anda dapat menentukan direktori dan nama folder pilihan Anda.

Kode PHP berikut mendemonstrasikan operasi tersebut:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $outPath = "c:/documents";

    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setExportType(MarkdownExportType::Visual);
    $saveOptions->setImagesSaveFolderName("md-images");
    $saveOptions->setBasePath($outPath);

    $presentation->save("presentation.md", SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Apakah tautan tetap ada setelah diekspor ke Markdown?**

Ya. Teks [hyperlinks](/slides/id/php-java/manage-hyperlinks/) dipertahankan sebagai tautan Markdown standar. Slide [transitions](/slides/id/php-java/slide-transition/) dan [animations](/slides/id/php-java/powerpoint-animation/) tidak dikonversi.

**Apakah saya dapat mempercepat konversi dengan menjalankannya di beberapa utas?**

Anda dapat memparallelkan per file, tetapi [don’t share](/slides/id/php-java/multithreading/) instance [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) yang sama di antara utas. Gunakan instance/proses terpisah per file untuk menghindari kontensi.

**Bagaimana dengan gambar—di mana disimpan, dan apakah jalurnya relatif?**

[Gambar](/slides/id/php-java/image/) diekspor ke folder khusus, dan file Markdown merujuknya dengan jalur relatif secara default. Anda dapat mengonfigurasi jalur output dasar dan nama folder aset untuk menjaga struktur repositori yang dapat diprediksi.