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
- lampiran
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "Konversi PowerPoint PPT/PPTX ke PDF berkualitas tinggi dan dapat dicari di .NET menggunakan Aspose.Slides, dengan contoh kode C# yang cepat dan opsi konversi lanjutan."
---
## **Gambaran Umum**

Mengonversi presentasi PowerPoint (PPT, PPTX, ODP, dll.) ke format PDF dalam C# menawarkan beberapa kelebihan, termasuk kompatibilitas pada berbagai perangkat dan mempertahankan tata letak serta pemformatan presentasi Anda. Panduan ini menunjukkan cara mengonversi presentasi ke dokumen PDF, menggunakan berbagai opsi untuk mengontrol kualitas gambar, menyertakan slide tersembunyi, melindungi PDF dengan kata sandi, mendeteksi substitusi font, memilih slide tertentu untuk konversi, dan menerapkan standar kepatuhan pada dokumen keluaran.

## **Konversi PowerPoint ke PDF**

Dengan Aspose.Slides, Anda dapat mengonversi presentasi dalam format berikut ke PDF:

* **PPT**
* **PPTX**
* **ODP**

Untuk mengonversi sebuah presentasi ke PDF, berikan nama file sebagai argumen ke kelas [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) lalu simpan presentasi sebagai PDF menggunakan metode [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Kelas [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) menyediakan metode [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) yang biasanya digunakan untuk mengonversi presentasi ke PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides untuk .NET menyisipkan informasi API dan nomor versinya ke dalam dokumen keluaran. Misalnya, saat mengonversi presentasi ke PDF, Aspose.Slides mengisi bidang Application dengan "*Aspose.Slides*" dan bidang PDF Producer dengan nilai dalam format "*Aspose.Slides v XX.XX*". **Catatan** bahwa Anda tidak dapat menginstruksikan Aspose.Slides untuk mengubah atau menghapus informasi ini dari dokumen keluaran.
{{% /alert %}}

Aspose.Slides memungkinkan Anda mengonversi:

* Seluruh presentasi ke PDF
* Slide tertentu dari presentasi ke PDF

Aspose.Slides mengekspor presentasi ke PDF, memastikan PDF yang dihasilkan sangat mirip dengan presentasi asli. Elemen dan atribut dirender secara akurat dalam konversi, termasuk:

* Gambar
* Kotak teks dan bentuk
* Pemformatan teks
* Pemformatan paragraf
* Tautan hiper
* Header dan footer
* Bulatan
* Tabel

## **Konversi PowerPoint ke PDF**

Proses konversi standar PowerPoint‑ke‑PDF menggunakan opsi default. Dalam hal ini, Aspose.Slides berusaha mengonversi presentasi yang diberikan ke PDF dengan pengaturan optimal pada tingkat kualitas maksimum.

Contoh berikut memuat sebuah presentasi dan menyimpan semua slide yang terlihat ke PDF menggunakan pengaturan ekspor default.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}
Aspose menawarkan **PowerPoint to PDF converter** gratis secara daring [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) yang mendemonstrasikan proses konversi presentasi ke PDF. Anda dapat menjalankan tes dengan konverter ini untuk implementasi langsung prosedur yang dijelaskan di sini.
{{% /alert %}}

## **Konversi PowerPoint ke PDF dengan Opsi**

Aspose.Slides menyediakan opsi kustom—properti di bawah kelas [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)—yang memungkinkan Anda menyesuaikan PDF yang dihasilkan, mengunci PDF dengan kata sandi, atau menentukan cara proses konversi harus berlangsung.

### **Konversi PowerPoint ke PDF dengan Opsi Kustom**

Dengan opsi konversi kustom, Anda dapat menentukan pengaturan kualitas gambar raster yang diinginkan, menentukan cara penanganan metafile, mengatur tingkat kompresi untuk teks, mengonfigurasi DPI untuk gambar, dan lain‑lain.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    JpegQuality = 90,
    SufficientResolution = 300,
    SaveMetafilesAsPng = true,
    TextCompression = PdfTextCompression.Flate,
    Compliance = PdfCompliance.Pdf15
};

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Pertahankan File OLE yang Disematkan sebagai Lampiran PDF**

Jika sebuah presentasi berisi buku kerja Excel yang disematkan, Anda mungkin ingin penerima PDF dapat mengakses data buku kerja tersebut serta melihat slide. Atur [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) ke `true` untuk mempertahankan file OLE yang disematkan sebagai lampiran dalam PDF yang dihasilkan.

Nilai defaultnya adalah `false`: gambar pratinjau atau ikon objek OLE dirender pada halaman PDF, tetapi file yang disematkan tidak termasuk sebagai lampiran. Menetapkan opsi ke `true` juga menyertakan data file. Pratinjau tetap menjadi representasi visual; lampiran memungkinkan penerima membuka atau menyimpan file yang disematkan secara terpisah. Objek OLE tidak menjadi lembar kerja Excel interaktif pada halaman PDF.

Contoh berikut memuat sebuah presentasi yang sudah berisi buku kerja Excel yang disematkan dan mengekspornya ke PDF dengan buku kerja terlampir.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

Untuk memeriksa hasilnya:

1. Buka PDF yang diekspor di penampil yang mendukung lampiran file, seperti Adobe Acrobat Reader.
2. Buka panel **Attachments** penampil dan temukan buku kerja yang disematkan.
3. Simpan lampiran dan buka di Excel untuk memeriksa datanya, atau buka langsung jika penampil mengizinkannya. Pratinjau pada halaman PDF terpisah dari lampiran.

{{% alert color="info" title="Note" %}}
Standar PDF/A memberlakukan pembatasan pada lampiran: PDF/A‑1 melarang file yang disematkan, PDF/A‑2 hanya mengizinkan lampiran PDF/A, dan PDF/A‑3 mengizinkan tipe file lain, termasuk buku kerja Excel. Ini merupakan persyaratan standar, bukan pembatasan khusus Aspose.Slides. Contoh ini menggunakan pengaturan kepatuhan PDF default dan tidak mendemonstrasikan ekspor PDF/A.
{{% /alert %}}

### **Konversi PowerPoint ke PDF dengan Slide Tersembunyi**

Jika sebuah presentasi berisi slide tersembunyi, Anda dapat menggunakan properti [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) dari kelas [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) untuk menyertakan slide tersembunyi sebagai halaman dalam PDF yang dihasilkan.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Konversi PowerPoint ke PDF yang Dilindungi Kata Sandi**

Contoh berikut mengekspor sebuah presentasi ke PDF yang memerlukan kata sandi `password` untuk dibuka. Izin akses memungkinkan pencetakan, termasuk pencetakan berkualitas tinggi.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Deteksi Substitusi Font**

Aspose.Slides menyediakan properti [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) di bawah kelas [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) yang memungkinkan Anda mendeteksi substitusi font selama proses konversi presentasi ke PDF.

Contoh berikut mengekspor sebuah presentasi ke PDF dan mencetak peringatan substitusi font ke konsol. Peringatan dicetak hanya ketika font yang tidak tersedia disubstitusi selama ekspor.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;
using System;

var pdfOptions = new PdfOptions();
pdfOptions.WarningCallback = new FontSubstitutionHandler();

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);

class FontSubstitutionHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss && warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"Font substitution warning: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

{{% alert color="info" title="Note" %}}
Untuk informasi lebih lanjut tentang substitusi font, lihat artikel [Font Substitution](/slides/id/net/font-substitution/).
{{% /alert %}} 

## **Konversi Slide Pilihan dari PowerPoint ke PDF**

Contoh berikut mengekspor slide 1 dan 3 dari sebuah presentasi ke PDF. Nomor slide dalam array ini berbasis satu, dan presentasi masukan harus berisi setidaknya tiga slide.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **Konversi PowerPoint ke PDF dengan Ukuran Slide Kustom**

Contoh berikut menyalin slide pertama dari sebuah presentasi ke dalam presentasi baru dengan ukuran slide 612 × 792 poin (8,5 × 11 inci). Ia menskala konten slide agar pas dan mengekspor slide tunggal ke PDF.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var slideWidth = 612;
var slideHeight = 792;

using var presentation = new Presentation("SelectedSlides.pptx");
using var resizedPresentation = new Presentation();

resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation.Slides.RemoveAt(1);
resizedPresentation.Save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
```

## **Konversi PowerPoint ke PDF dalam Tampilan Slide Catatan**

Contoh berikut mengekspor sebuah presentasi ke PDF, menempatkan catatan pembicara setiap slide di bawah slide. Gunakan presentasi yang berisi catatan pembicara untuk melihat hasilnya.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

using var presentation = new Presentation("NotesFile.pptx");
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **Standar Aksesibilitas dan Kepatuhan untuk PDF**

Aspose.Slides memungkinkan Anda menggunakan prosedur konversi yang mematuhi [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Anda dapat mengekspor dokumen PowerPoint ke PDF menggunakan salah satu standar kepatuhan ini: **PDF/A1a**, **PDF/A1b**, dan **PDF/UA**.

Kode C# ini mendemonstrasikan proses konversi PowerPoint‑ke‑PDF yang menghasilkan beberapa PDF berdasarkan standar kepatuhan yang berbeda:

```csharp
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

{{% alert color="info" title="Note" %}}
Aspose.Slides mendukung operasi konversi PDF, memungkinkan Anda mengonversi file PDF ke format file populer. Anda dapat melakukan konversi [PDF to HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/), dan [PDF to PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/). Operasi konversi PDF ke format khusus lainnya—[PDF to SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), dan [PDF to XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/)—juga didukung.
{{% /alert %}}

> **Catatan:** Saat mengekspor ke PDF/UA, Aspose.Slides memperlakukan grafik kompleks seperti SmartArt, diagram, dan formula sebagai satu gambar tunggal. Elemen jalur individu tidak dipertahankan sebagai konten terpisah dan dapat ditandai sebagai artefak; teks alternatif hanya disediakan untuk seluruh gambar.

## **FAQ**

**Apakah saya dapat mengonversi banyak file PowerPoint ke PDF secara massal?**

Ya, Aspose.Slides mendukung konversi batch banyak file PPT atau PPTX ke PDF. Anda dapat mengiterasi file Anda dan menerapkan proses konversi secara programatis.

**Apakah memungkinkan melindungi PDF yang telah dikonversi dengan kata sandi?**

Ya. Gunakan kelas [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) untuk mengatur kata sandi dan mendefinisikan izin akses selama proses konversi.

**Bagaimana cara menyertakan slide tersembunyi dalam PDF?**

Atur properti [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) dalam kelas [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) ke `true` untuk menyertakan slide tersembunyi dalam PDF yang dihasilkan.

**Apakah Aspose.Slides dapat mempertahankan kualitas gambar tinggi dalam PDF?**

Ya, Anda dapat mengontrol kualitas gambar dengan mengatur properti seperti [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) dan [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) dalam kelas [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) untuk memastikan gambar berkualitas tinggi dalam PDF Anda.

**Apakah Aspose.Slides mendukung standar kepatuhan PDF/A?**

Ya, Aspose.Slides memungkinkan Anda mengekspor PDF yang mematuhi berbagai standar, termasuk PDF/A1a, PDF/A1b, dan PDF/UA, memastikan dokumen Anda memenuhi persyaratan aksesibilitas dan arsip.

## **Sumber Daya Tambahan**

- [Aspose.Slides for .NET Documentation](/slides/id/net/)
- [Aspose.Slides for .NET API Reference](https://reference.aspose.com/slides/net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)