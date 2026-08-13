---
title: Konversi PPT dan PPTX ke PDF di .NET [Fitur Lanjutan Disertakan]
linktitle: PowerPoint ke PDF
type: docs
weight: 40
url: /id/net/convert-powerpoint-to-pdf/
keywords:
- konversi PowerPoint
- konversi presentasi
- PowerPoint ke PDF
- presentasi ke PDF
- PPT ke PDF
- konversi PPT ke PDF
- PPTX ke PDF
- konversi PPTX ke PDF
- simpan PowerPoint sebagai PDF
- simpan PPT sebagai PDF
- simpan PPTX sebagai PDF
- ekspor PPT ke PDF
- ekspor PPTX ke PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "Konversi PowerPoint PPT/PPTX ke PDF berkualitas tinggi dan dapat dicari di .NET menggunakan Aspose.Slides, dengan contoh kode C# cepat dan opsi konversi lanjutan."
---
## **Gambaran Umum**

Mengonversi presentasi PowerPoint (PPT, PPTX, ODP, dll.) ke format PDF dalam C# menawarkan beberapa keuntungan, termasuk kompatibilitas di berbagai perangkat dan menjaga tata letak serta format presentasi Anda. Panduan ini menunjukkan cara mengonversi presentasi ke dokumen PDF, menggunakan berbagai opsi untuk mengontrol kualitas gambar, menyertakan slide tersembunyi, melindungi file PDF dengan kata sandi, mendeteksi substitusi font, memilih slide tertentu untuk konversi, dan menerapkan standar kepatuhan pada dokumen output.

## **Konversi PowerPoint ke PDF**

Dengan Aspose.Slides, Anda dapat mengonversi presentasi dalam format berikut ke PDF:

* **PPT**
* **PPTX**
* **ODP**

Untuk mengonversi presentasi ke PDF, berikan nama file sebagai argumen ke kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) dan kemudian simpan presentasi sebagai PDF menggunakan metode [Save](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/save/). Kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) menyediakan metode [Save](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/save/) yang biasanya digunakan untuk mengonversi presentasi ke PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for .NET menyisipkan informasi API dan nomor versinya ke dalam dokumen output. Misalnya, ketika mengonversi presentasi ke PDF, Aspose.Slides mengisi bidang Application dengan "*Aspose.Slides*" dan bidang PDF Producer dengan nilai dalam bentuk "*Aspose.Slides v XX.XX*". **Catatan** bahwa Anda tidak dapat menginstruksikan Aspose.Slides untuk mengubah atau menghapus informasi ini dari dokumen output.

{{% /alert %}}

Aspose.Slides memungkinkan Anda untuk mengonversi:

* Seluruh presentasi ke PDF
* Slide tertentu dari sebuah presentasi ke PDF

Aspose.Slides mengekspor presentasi ke PDF, memastikan PDF yang dihasilkan sangat mirip dengan presentasi asli. Elemen dan atribut dirender dengan akurat dalam konversi, termasuk:

* Gambar
* Kotak teks dan bentuk
* Pemformatan teks
* Pemformatan paragraf
* Tautan hiper
* Header dan footer
* Bullet
* Tabel

## **Mengonversi PowerPoint ke PDF**

Proses konversi standar PowerPoint-ke-PDF menggunakan opsi default. Dalam hal ini, Aspose.Slides berusaha mengonversi presentasi yang diberikan ke PDF dengan pengaturan optimal pada tingkat kualitas maksimum.

Kode C# berikut menunjukkan cara mengonversi presentasi (PPT, PPTX, ODP, dll.) ke PDF:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiasi kelas Presentation yang merepresentasikan file PowerPoint atau OpenDocument.
using var presentation = new Presentation("PowerPoint.ppt");

// Simpan presentasi sebagai PDF.
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{%  alert  color="info"  %}} 

Aspose menyediakan **[Konverter PowerPoint ke PDF](https://products.aspose.app/slides/id/conversion/ppt-to-pdf)** online gratis yang menunjukkan proses konversi presentasi ke PDF. Anda dapat melakukan tes dengan konverter ini untuk implementasi langsung dari prosedur yang dijelaskan di sini.

{{% /alert %}}

## **Mengonversi PowerPoint ke PDF dengan Opsi**

Aspose.Slides menyediakan opsi khusus—properti di bawah kelas [PdfOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/pdfoptions/)—yang memungkinkan Anda menyesuaikan PDF yang dihasilkan, mengunci PDF dengan kata sandi, atau menentukan bagaimana proses konversi harus dijalankan.

### **Mengonversi PowerPoint ke PDF dengan Opsi Kustom**

Dengan opsi konversi kustom, Anda dapat menentukan pengaturan kualitas yang diinginkan untuk gambar raster, menentukan cara penanganan metafile, mengatur tingkat kompresi untuk teks, mengonfigurasi DPI untuk gambar, dan lainnya.

Contoh kode di bawah ini menunjukkan cara mengonversi presentasi PowerPoint ke PDF dengan beberapa opsi kustom.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiasi kelas PdfOptions.
var pdfOptions = new PdfOptions
{
    // Setel kualitas untuk gambar JPG.
    JpegQuality = 90,

    // Setel DPI untuk gambar.
    SufficientResolution = 300,

    // Setel perilaku untuk metafile.
    SaveMetafilesAsPng = true,

    // Setel tingkat kompresi teks untuk konten tekstual.
    TextCompression = PdfTextCompression.Flate,

    // Definisikan mode kepatuhan PDF.
    Compliance = PdfCompliance.Pdf15
};

// Instansiasi kelas Presentation yang merepresentasikan file PowerPoint atau OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Simpan presentasi sebagai dokumen PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Mengonversi PowerPoint ke PDF dengan Slide Tersembunyi**

Jika sebuah presentasi berisi slide tersembunyi, Anda dapat menggunakan properti [ShowHiddenSlides](https://reference.aspose.com/slides/id/net/aspose.slides.export/pdfoptions/showhiddenslides/) dari kelas [PdfOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/pdfoptions/) untuk menyertakan slide tersembunyi sebagai halaman dalam PDF yang dihasilkan.

Kode C# berikut menunjukkan cara mengonversi presentasi PowerPoint ke PDF dengan menyertakan slide tersembunyi:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiasi kelas Presentation yang merepresentasikan file PowerPoint atau OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Instansiasi kelas PdfOptions.
var pdfOptions = new PdfOptions();

// Tambahkan slide tersembunyi.
pdfOptions.ShowHiddenSlides = true;

// Simpan presentasi sebagai PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Mengonversi PowerPoint ke PDF yang Dilindungi Kata Sandi**

Kode C# berikut menunjukkan cara mengonversi presentasi PowerPoint menjadi PDF yang dilindungi kata sandi menggunakan parameter perlindungan dari kelas [PdfOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/pdfoptions/):

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiasi kelas Presentation yang merepresentasikan file PowerPoint atau OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Instansiasi kelas PdfOptions.
var pdfOptions = new PdfOptions();

// Setel kata sandi PDF dan izin akses.
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// Simpan presentasi sebagai PDF.
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Mendeteksi Substitusi Font**

Aspose.Slides menyediakan properti [WarningCallback](https://reference.aspose.com/slides/id/net/aspose.slides.export/saveoptions/warningcallback/) di bawah kelas [PdfOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/pdfoptions/), yang memungkinkan Anda mendeteksi substitusi font selama proses konversi presentasi ke PDF.

Kode C# berikut menunjukkan cara mendeteksi substitusi font:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;

public static void Main()
{
    // Instansiasi kelas Presentation yang merepresentasikan file PowerPoint atau OpenDocument file. 
    using var presentation = new Presentation("sample.pptx");

    // Setel callback peringatan di opsi PDF.
    var pdfOptions = new PdfOptions();
    pdfOptions.WarningCallback = new FontSubstitutionHandler();

    // Simpan presentasi sebagai PDF.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// Implementasi callback peringatan.
private class FontSubstitutionHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss &&
            warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"Font substitution warning: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="info"  %}} 

Untuk informasi lebih lanjut tentang menerima callback untuk substitusi font selama proses rendering, lihat [Mendapatkan Callback Peringatan untuk Substitusi Font](/slides/id/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Untuk informasi lebih lanjut tentang substitusi font, lihat artikel [Substitusi Font](/slides/id/net/font-substitution/).

{{% /alert %}} 

## **Mengonversi Slide Terpilih dari PowerPoint ke PDF**

Kode C# berikut menunjukkan cara mengonversi hanya slide tertentu dari presentasi PowerPoint ke PDF:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiasi kelas Presentation yang merepresentasikan file PowerPoint atau OpenDocument file.
using var presentation = new Presentation("PowerPoint.pptx");

// Setel array nomor slide.
int[] slides = { 1, 3 };

// Simpan presentasi sebagai PDF.
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **Mengonversi PowerPoint ke PDF dengan Ukuran Slide Kustom**

Kode C# berikut menunjukkan cara mengonversi presentasi PowerPoint ke PDF dengan ukuran slide yang ditentukan:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

var slideWidth = 612;
var slideHeight = 792;

// Muat presentasi PowerPoint.
using var presentation = new Presentation("SelectedSlides.pptx");

// Buat presentasi baru dengan ukuran slide yang disesuaikan.
using var resizedPresentation = new Presentation();

// Setel ukuran slide khusus.
resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

// Klon slide pertama dari presentasi asli.
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Hapus slide kosong yang dibuat bersama presentasi baru.
resizedPresentation.Slides.RemoveAt(1);

// Simpan presentasi yang diubah ukurannya sebagai PDF.
resizedPresentation.Save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
```

## **Mengonversi PowerPoint ke PDF dalam Tampilan Catatan Slide**

Kode C# berikut menunjukkan cara mengonversi presentasi PowerPoint ke PDF yang menyertakan catatan:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Muat presentasi PowerPoint.
using var presentation = new Presentation("NotesFile.pptx");

// Konfigurasikan opsi PDF dengan Tata Letak Catatan.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

// Simpan presentasi ke PDF dengan catatan.
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **Standar Aksesibilitas dan Kepatuhan untuk PDF**

Aspose.Slides memungkinkan Anda menggunakan prosedur konversi yang mematuhi [Pedoman Aksesibilitas Konten Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Anda dapat mengekspor dokumen PowerPoint ke PDF menggunakan salah satu standar kepatuhan berikut: **PDF/A1a**, **PDF/A1b**, dan **PDF/UA**.

Kode C# berikut menunjukkan proses konversi PowerPoint-ke-PDF yang menghasilkan beberapa PDF berdasarkan standar kepatuhan yang berbeda:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.Save("pres-a1a-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfA1a
});

presentation.Save("pres-a1b-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfA1b
});

presentation.Save("pres-ua-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfUa
});
```

{{% alert title="Note" color="warning" %}} 

Aspose.Slides mendukung operasi konversi PDF, memungkinkan Anda mengonversi file PDF ke format file populer. Anda dapat melakukan konversi [PDF ke HTML](https://products.aspose.com/slides/id/net/conversion/pdf-to-html/), [PDF ke gambar](https://products.aspose.com/slides/id/net/conversion/pdf-to-image/), [PDF ke JPG](https://products.aspose.com/slides/id/net/conversion/pdf-to-jpg/), dan [PDF ke PNG](https://products.aspose.com/slides/id/net/conversion/pdf-to-png/) . Operasi konversi PDF ke format khusus lainnya—[PDF ke SVG](https://products.aspose.com/slides/id/net/conversion/pdf-to-svg/), [PDF ke TIFF](https://products.aspose.com/slides/id/net/conversion/pdf-to-tiff/), dan [PDF ke XML](https://products.aspose.com/slides/id/net/conversion/pdf-to-xml/)—juga didukung.

{{% /alert %}}

> **Catatan:** Saat mengekspor ke PDF/UA, Aspose.Slides memperlakukan grafik kompleks seperti SmartArt, diagram, dan rumus sebagai satu gambar tunggal. Elemen jalur individual tidak dipertahankan sebagai konten terpisah dan mungkin ditandai sebagai artefak; teks alternatif hanya disediakan untuk seluruh gambar.

## **FAQ**

### Bisakah saya mengonversi beberapa file PowerPoint ke PDF secara massal?

Ya, Aspose.Slides mendukung konversi batch dari banyak file PPT atau PPTX ke PDF. Anda dapat mengiterasi file-file Anda dan menerapkan proses konversi secara programatis.

### Apakah memungkinkan untuk melindungi PDF yang dikonversi dengan kata sandi?

Tentu saja. Gunakan kelas [PdfOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/pdfoptions/) untuk menetapkan kata sandi dan menentukan izin akses selama proses konversi.

### Bagaimana cara menyertakan slide tersembunyi dalam PDF?

Setel properti `ShowHiddenSlides` pada kelas [PdfOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/pdfoptions/) menjadi `true` untuk menyertakan slide tersembunyi dalam PDF yang dihasilkan.

### Bisakah Aspose.Slides menjaga kualitas gambar tinggi dalam PDF?

Ya, Anda dapat mengontrol kualitas gambar dengan mengatur properti seperti `JpegQuality` dan `SufficientResolution` pada kelas [PdfOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/pdfoptions/) untuk memastikan gambar berkualitas tinggi dalam PDF Anda.

### Apakah Aspose.Slides mendukung standar kepatuhan PDF/A?

Ya, Aspose.Slides memungkinkan Anda mengekspor PDF yang mematuhi berbagai standar, termasuk PDF/A1a, PDF/A1b, dan PDF/UA, memastikan dokumen Anda memenuhi persyaratan aksesibilitas dan arsip.

## **Sumber Daya Tambahan**

- [Dokumentasi Aspose.Slides untuk .NET](/slides/id/net/)
- [Referensi API Aspose.Slides untuk .NET](https://reference.aspose.com/slides/id/net/)
- [Konverter Online Gratis Aspose](https://products.aspose.app/slides/id/conversion)