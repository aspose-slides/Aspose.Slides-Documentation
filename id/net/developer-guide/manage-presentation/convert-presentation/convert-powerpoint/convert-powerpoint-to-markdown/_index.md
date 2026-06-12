---
title: Konversi Presentasi PowerPoint ke Markdown di .NET
linktitle: PowerPoint ke Markdown
type: docs
weight: 140
url: /id/net/convert-powerpoint-to-markdown/
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
- .NET
- C#
- Aspose.Slides
description: "Konversi slide PowerPoint—PPT, PPTX—ke Markdown bersih dengan Aspose.Slides untuk .NET, otomatisasi dokumentasi dan menjaga format."
---
## **Pendahuluan**

Aspose.Slides memungkinkan Anda mengonversi presentasi PowerPoint ke Markdown, yang dapat berguna untuk alur kerja dokumentasi, pembuatan situs statis, migrasi konten, dan penerbitan teks yang dikontrol versi. API mendukung ekspor langsung dari presentasi PPT dan PPTX ke file MD serta menyediakan opsi tambahan untuk mengendalikan bagaimana konten slide direpresentasikan dalam dokumen Markdown yang dihasilkan.

Anda dapat mengekspor presentasi sebagai Markdown polos, memilih dari berbagai varian Markdown seperti CommonMark dan GitHub Flavored Markdown, serta mengonfigurasi cara penanganan gambar selama ekspor. Untuk presentasi yang berisi konten visual, Aspose.Slides juga memungkinkan Anda menyimpan gambar ke folder terpisah dan merujuknya dari file Markdown yang dihasilkan.

{{% alert color="warning" %}}
Ekspor PowerPoint ke Markdown **tanpa gambar** secara default. Jika Anda ingin mengekspor dokumen PowerPoint yang berisi gambar, Anda perlu mengatur `ExportType = MarkdownExportType.Visual` dan menentukan `BasePath`, tempat gambar yang dirujuk dalam dokumen Markdown akan disimpan.
{{% /alert %}}

## **Konversi PowerPoint ke Markdown**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) untuk merepresentasikan objek presentasi.  
2. Gunakan [Save ](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/methods/save)method untuk menyimpan objek sebagai file markdown.

Contoh kode C# berikut menunjukkan cara mengonversi PowerPoint ke markdown:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md);
}
```

## **Konversi PowerPoint ke Varian Markdown**

Aspose.Slides memungkinkan Anda mengonversi PowerPoint ke markdown (mengandung sintaks dasar), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab, dan 17 varian markdown lainnya.

Contoh kode C# berikut menunjukkan cara mengonversi PowerPoint ke CommonMark:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md, new MarkdownSaveOptions
    {
        Flavor = Flavor.CommonMark
    });
}
```

23 varian markdown yang didukung **terdaftar** pada [enumerasi Flavor](https://reference.aspose.com/slides/id/net/aspose.slides.dom.export.markdown.saveoptions/flavor/) dari kelas [MarkdownSaveOptions](https://reference.aspose.com/slides/id/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/).

## **Konversi Presentasi yang Mengandung Gambar ke Markdown**

Kelas [MarkdownSaveOptions](https://reference.aspose.com/slides/id/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) menyediakan properti dan enumerasi yang memungkinkan Anda mengatur opsi tertentu untuk file markdown yang dihasilkan. Enum [MarkdownExportType](https://reference.aspose.com/slides/id/net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) misalnya, dapat diatur ke nilai yang menentukan bagaimana gambar dirender atau ditangani: `Sequential`, `TextOnly`, `Visual`.

### **Konversi Gambar Secara Berurutan**

Jika Anda ingin gambar muncul satu per satu secara berurutan dalam markdown yang dihasilkan, pilih opsi sequential. Contoh kode C# berikut menunjukkan cara mengonversi presentasi yang berisi gambar ke markdown:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions
    {
        ShowHiddenSlides = true,
        ShowSlideNumber = true,
        Flavor = Flavor.Github,
        ExportType = MarkdownExportType.Sequential,
        NewLineType = NewLineType.Windows
    };
    
    pres.Save("doc.md", new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, SaveFormat.Md, markdownSaveOptions);
}
```

### **Konversi Gambar Secara Visual**

Jika Anda ingin gambar muncul bersama-sama dalam markdown yang dihasilkan, pilih opsi visual. Dalam kasus ini, gambar akan disimpan ke direktori kerja aplikasi (dan jalur relatif akan dibangun untuknya dalam dokumen markdown), atau Anda dapat menentukan jalur dan nama folder yang diinginkan.

Contoh kode C# berikut memperlihatkan operasinya:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    const string outPath = "c:\\documents";
    pres.Save(Path.Combine(outPath, "pres.md"), SaveFormat.Md, new MarkdownSaveOptions
    { 
        ExportType = MarkdownExportType.Visual,
        ImagesSaveFolderName = "md-images",
        BasePath = outPath
    });
}
```

## **FAQ**

**Apakah hyperlink tetap ada setelah diekspor ke Markdown?**

Ya. Teks [hyperlinks](/slides/id/net/manage-hyperlinks/) dipertahankan sebagai tautan Markdown standar. Slide [transitions](/slides/id/net/slide-transition/) dan [animations](/slides/id/net/powerpoint-animation/) tidak dikonversi.

**Bisakah saya mempercepat konversi dengan menjalankannya dalam beberapa thread?**

Anda dapat memparalelkan antar file, namun [don’t share](/slides/id/net/multithreading/) instance [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) yang sama antar thread. Gunakan instance atau proses terpisah per file untuk menghindari kontensi.

**Apa yang terjadi pada gambar—di mana mereka disimpan, dan apakah jalurnya relatif?**

[Images](/slides/id/net/image/) diekspor ke folder khusus, dan file Markdown merujuknya dengan jalur relatif secara default. Anda dapat mengonfigurasi jalur output dasar dan nama folder aset untuk menjaga struktur repositori yang dapat diprediksi.