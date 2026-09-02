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
- ekspor gambar Markdown
- tautan gambar CDN
- PowerPoint
- presentasi
- Markdown
- .NET
- C#
- Aspose.Slides
description: "Konversi presentasi PPT dan PPTX ke Markdown di .NET serta mengontrol lokasi penyimpanan dan referensi gambar bitmap, metafile, dan SVG yang diekspor."
---
## **Gambaran Umum**

Aspose.Slides for .NET dapat mengonversi presentasi PPT dan PPTX ke Markdown untuk dokumentasi, situs statis, migrasi konten, dan alur kerja kontrol versi. Anda dapat memilih varian Markdown, mengontrol cara konten slide dirender, dan menentukan di mana gambar yang diekspor disimpan serta bagaimana Markdown yang dihasilkan merujuknya.

Secara default, ekspor Markdown menggunakan output teks‑saja. Untuk mengekspor konten visual, atur properti [MarkdownSaveOptions.ExportType](https://reference.aspose.com/slides/id/net/aspose.slides.export/markdownsaveoptions/exporttype/) menjadi nilai `Sequential` atau `Visual` dari enumerasi [MarkdownExportType](https://reference.aspose.com/slides/id/net/aspose.slides.export/markdownexporttype/). `Sequential` merender item slide secara terpisah dan berurutan, sedangkan `Visual` menjaga item yang dikelompokkan bersama untuk mempertahankan hubungan visual mereka. Nilai `TextOnly` tidak menghasilkan sumber daya gambar, sehingga peristiwa penyimpanan gambar tidak dipanggil dalam mode tersebut.

## **Konversi Presentasi ke Markdown**

Muat file sumber dengan kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/), lalu panggil metode [Presentation.Save](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/save/) dengan nilai `Md` dari enumerasi [SaveFormat](https://reference.aspose.com/slides/id/net/aspose.slides.export/saveformat/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.md", SaveFormat.Md);
```

## **Pilih Varian Markdown**

Properti [MarkdownSaveOptions.Flavor](https://reference.aspose.com/slides/id/net/aspose.slides.export/markdownsaveoptions/flavor/) mengontrol spesifikasi Markdown yang digunakan untuk output. Enumerasi [Flavor](https://reference.aspose.com/slides/id/net/aspose.slides.export/flavor/) mencakup CommonMark, GitHub Flavored Markdown, dan varian lain yang didukung.

Contoh berikut mengekspor presentasi sebagai CommonMark:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    Flavor = Flavor.CommonMark
};

presentation.Save("presentation.md", SaveFormat.Md, options);
```

## **Ekspor Gambar dengan Perilaku Penyimpanan Lokal Bawaan**

Kelas [MarkdownSaveOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/markdownsaveoptions/) menyediakan dua properti untuk gambar yang disimpan secara lokal:

- [BasePath](https://reference.aspose.com/slides/id/net/aspose.slides.export/markdownsaveoptions/basepath/) menentukan direktori dasar untuk dokumen Markdown dan sumber dayanya.
- [ImagesSaveFolderName](https://reference.aspose.com/slides/id/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/) menentukan subdirektori gambar. Nilai defaultnya adalah `Images`.

Contoh berikut merender konten visual, menulis gambar ke `output/assets`, dan membuat referensi gambar relatif dalam dokumen Markdown:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputDirectory = "output";
Directory.CreateDirectory(outputDirectory);

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    ExportType = MarkdownExportType.Visual,
    BasePath = outputDirectory,
    ImagesSaveFolderName = "assets"
};

var markdownPath = Path.Combine(outputDirectory, "presentation.md");
presentation.Save(markdownPath, SaveFormat.Md, options);
```

Perilaku ini juga berfungsi sebagai cadangan ketika penangan gambar khusus mengembalikan `false`.

## **Sesuaikan Penyimpanan Gambar dan Tautan Markdown**

Gunakan peristiwa [MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/id/net/aspose.slides.export/markdownsaveoptions/imagesaving/) untuk sumber daya bitmap dan metafile non‑SVG yang dihasilkan selama ekspor Markdown. Delegasi [MarkdownImageSavingHandler](https://reference.aspose.com/slides/id/net/aspose.slides.export/markdownsaveoptions.markdownimagesavinghandler/) menerima objek [IImage](https://reference.aspose.com/slides/id/net/aspose.slides/iimage/), [ImageFormat](https://reference.aspose.com/slides/id/net/aspose.slides/imageformat/), dan tautan Markdown yang dihasilkan sebagai parameter `ref string`. Simpan atau unggah gambar dengan format yang diberikan, dan ganti `link` dengan referensi yang harus muncul dalam output Markdown.

Sumber daya yang dihasilkan dalam format SVG ditangani secara terpisah. Langganan peristiwa [MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/id/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/), yang delegasinya [MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/id/net/aspose.slides.export/markdownsaveoptions.markdownsvgimagesavinghandler/) menerima objek [ISvgImage](https://reference.aspose.com/slides/id/net/aspose.slides/isvgimage/) dan parameter `ref string link`. SVG tidak memiliki argumen `ImageFormat`; tulis atau unggah data XML‑nya dari properti [ISvgImage.SvgData](https://reference.aspose.com/slides/id/net/aspose.slides/isvgimage/svgdata/) sebagai gantinya. Bergantung pada mode ekspor dan pengelompokan visual, SVG dalam presentasi sumber dapat dirasterisasi atau digabungkan dengan konten lain; sumber daya non‑SVG yang dihasilkan kemudian diteruskan ke `ImageSaving`. Langganan kedua peristiwa ketika setiap sumber daya visual yang diekspor memerlukan pemrosesan khusus.

Nilai kembali penangan menentukan siapa yang memproses gambar:

- Kembalikan `true` setelah penangan menyimpan, mengunggah, mengubah, atau memproses gambar dan menetapkan nilai yang valid ke `link`. Aspose.Slides menulis nilai tersebut ke dokumen Markdown dan tidak melakukan penyimpanan lokal bawaan.
- Kembalikan `false` untuk membiarkan Aspose.Slides menyimpan gambar secara lokal dan menghasilkan tautannya menurut [MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/id/net/aspose.slides.export/markdownsaveoptions/basepath/) dan [MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/id/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/).

{{% alert color="warning" title="Penting" %}}

Penangan yang mengembalikan `true` bertanggung jawab atas gambar. Jika mengembalikan `true` tanpa menetapkan tautan yang valid dan tidak kosong, ekspor akan gagal dengan `InvalidOperationException`.

{{% /alert %}}

### **Simpan Gambar ke Direktori Asal CDN dan Gunakan URL Eksternal**

Contoh berikut memperlakukan `cdn-origin/presentations/quarterly-report` sebagai direktori asal CDN yang dipasang atau disinkronkan. Setiap penangan mengekstrak nama file yang dihasilkan, menyimpan gambar ke direktori khusus tersebut, dan mengganti referensi lokal yang dihasilkan dengan URL CDN publik. Contoh ini tidak melakukan unggahan jaringan: URL menjadi valid hanya setelah direktori dipasang sebagai asal CDN atau file‑filenya dipublikasikan ke CDN. Untuk penyimpanan objek, gantikan penulisan sistem berkas dengan operasi unggah SDK penyimpanan dan tetapkan `link` hanya setelah unggahan berhasil.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputDirectory = "output";
const string publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
var storageDirectory = Path.Combine("cdn-origin", "presentations", "quarterly-report");
Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(storageDirectory);

static string GetFileNameFromLink(string generatedLink)
{
    var urlCompatibleLink = generatedLink.Replace('\\', '/');
    return urlCompatibleLink[(urlCompatibleLink.LastIndexOf('/') + 1)..];
}

static string BuildPublicUrl(string baseUrl, string fileName)
{
    return $"{baseUrl}/{Uri.EscapeDataString(fileName)}";
}

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    ExportType = MarkdownExportType.Visual,
    BasePath = outputDirectory,
    ImagesSaveFolderName = "fallback-images"
};

options.ImageSaving += (IImage image, ImageFormat format, ref string link) =>
{
    if (image.Width < 128 || image.Height < 128)
    {
        return false;
    }

    var fileName = GetFileNameFromLink(link);
    var storagePath = Path.Combine(storageDirectory, fileName);
    image.Save(storagePath, format);
    link = BuildPublicUrl(publicBaseUrl, fileName);
    return true;
};

options.SvgImageSaving += (ISvgImage svgImage, ref string link) =>
{
    var fileName = GetFileNameFromLink(link);
    var storagePath = Path.Combine(storageDirectory, fileName);
    File.WriteAllBytes(storagePath, svgImage.SvgData);
    link = BuildPublicUrl(publicBaseUrl, fileName);
    return true;
};

var markdownPath = Path.Combine(outputDirectory, "presentation.md");
presentation.Save(markdownPath, SaveFormat.Md, options);
```

Penangan bitmap sengaja mengembalikan `false` untuk gambar yang lebih kecil dari 128 × 128 piksel, sehingga Aspose.Slides menyimpan gambar tersebut ke `output/fallback-images` menggunakan perilaku default. Sumber daya bitmap dan metafile yang lebih besar, serta sumber daya SVG, ditangani oleh kode khusus. Misalnya, referensi lokal yang dihasilkan seperti `fallback-images/image1.png` menjadi `https://cdn.example.com/presentations/quarterly-report/image1.png`. Penangan menggunakan jalur sistem operasi hanya saat menulis file; tautan yang ditulis ke Markdown menggunakan garis miring maju dan nama file yang di‑escape untuk URL. Terapkan aturan yang sama saat membangun tautan relatif: gunakan `/`, bukan pemisah direktori spesifik platform.

## **FAQ**

**Apakah satu penangan dapat memproses gambar raster dan gambar SVG?**

Tidak. Gunakan [MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/id/net/aspose.slides.export/markdownsaveoptions/imagesaving/) untuk sumber daya bitmap dan metafile yang dihasilkan serta [MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/id/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/) untuk sumber daya yang dihasilkan sebagai SVG. Yang pertama menyediakan objek [IImage](https://reference.aspose.com/slides/id/net/aspose.slides/iimage/) dan [ImageFormat](https://reference.aspose.com/slides/id/net/aspose.slides/imageformat/); yang kedua menyediakan objek [ISvgImage](https://reference.aspose.com/slides/id/net/aspose.slides/isvgimage/) yang data SVG‑nya dapat dibaca dari [ISvgImage.SvgData](https://reference.aspose.com/slides/id/net/aspose.slides/isvgimage/svgdata/). SVG sumber yang dirasterisasi selama ekspor diproses oleh `ImageSaving` alih‑alih.

**Apa yang terjadi ketika penangan penyimpanan gambar mengembalikan `false`?**

Aspose.Slides menggunakan perilaku penyimpanan lokal defaultnya. Lokasi gambar dan referensi yang dihasilkan dikontrol oleh [MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/id/net/aspose.slides.export/markdownsaveoptions/basepath/) dan [MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/id/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/).

**Apakah penangan dapat memberikan URL tanpa menyimpan gambar secara lokal?**

Ya. Penangan dapat mengunggah gambar ke penyimpanan objek atau meneruskannya ke layanan lain, menetapkan URL yang dihasilkan ke `link`, dan mengembalikan `true`. Penangan harus menyelesaikan pemrosesan sendiri; mengembalikan `true` mencegah penyimpanan lokal default.

**Mengapa ekspor Markdown melempar `InvalidOperationException` dari penangan?**

Pengecualian ini terjadi ketika penangan mengembalikan `true` namun tidak menyediakan tautan yang valid. Tetapkan jalur relatif atau URL eksternal yang harus ditulis ke Markdown sebelum mengembalikan `true`.

**Pemilih pemisah jalur mana yang harus digunakan untuk tautan gambar?**

Gunakan garis miring maju dalam tautan Markdown dan URL. Gunakan `Path.Combine` hanya untuk jalur sistem berkas, lalu buat atau normalisasi referensi Markdown secara terpisah.

**Apakah hyperlink dipertahankan selama ekspor Markdown?**

Ya. Teks [hyperlinks](/slides/id/net/manage-hyperlinks/) dipertahankan sebagai tautan Markdown standar. [Transitions](/slides/id/net/slide-transition/) dan [animations](/slides/id/net/powerpoint-animation/) slide tidak dikonversi.

**Apakah presentasi dapat dikonversi ke Markdown secara paralel?**

Anda dapat memproses berkas presentasi yang berbeda secara paralel, tetapi jangan berbagi instance [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) yang sama antar‑thread. Ikuti [multithreading guidelines](/slides/id/net/multithreading/) dan gunakan instance terpisah untuk tiap berkas.