---
title: Konversi PPT ke PPTX di .NET
linktitle: PPT ke PPTX
type: docs
weight: 20
url: /id/net/convert-ppt-to-pptx/
keywords:
- konversi PowerPoint
- konversi presentasi
- konversi slide
- konversi PPT
- PPT ke PPTX
- simpan PPT sebagai PPTX
- ekspor PPT ke PPTX
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Konversi file PPT warisan ke PPTX di .NET dengan Aspose.Slides. Menyertakan contoh C# untuk konversi satu file dan batch, penanganan kesalahan, serta catatan kesetiaan."
---
## **Gambaran Umum**

PPT adalah format biner warisan PowerPoint, sedangkan PPTX adalah format Open XML yang lebih baru. Aspose.Slides untuk .NET dapat memuat file PPT dan menyimpannya sebagai PPTX tanpa Microsoft PowerPoint. Artikel ini menunjukkan cara mengonversi satu file atau direktori file dan menjelaskan apa yang perlu diverifikasi setelah konversi.

## **Konversi File PPT ke PPTX**

Muat file sumber dengan kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) , kemudian panggil [IPresentation.Save](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentation/save/) dengan [SaveFormat.Pptx](https://reference.aspose.com/slides/id/net/aspose.slides.export/saveformat/). Deklarasi `using` membuang presentasi dan melepaskan sumber dayanya ketika ruang lingkup selesai.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

// Muat presentasi PPT warisan.
using var presentation = new Presentation("presentation.ppt");

// Simpan presentasi dalam format PPTX.
presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

Ekstensi file tidak menentukan format keluaran secara otomatis; argumen [SaveFormat.Pptx](https://reference.aspose.com/slides/id/net/aspose.slides.export/saveformat/) yang melakukannya. Jaga jalur input dan output berbeda jika Anda perlu mempertahankan file PPT asli.

## **Konversi Beberapa File PPT**

Contoh berikut mengonversi setiap file `.ppt` dalam satu direktori. Setiap file diproses secara independen, sehingga satu konversi yang gagal tidak menghentikan sisanya.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var inputDirectory = "input";
var outputDirectory = "output";
Directory.CreateDirectory(outputDirectory);

foreach (var inputPath in Directory.EnumerateFiles(inputDirectory, "*.ppt", SearchOption.TopDirectoryOnly))
{
    var outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pptx";
    var outputPath = Path.Combine(outputDirectory, outputFileName);

    try
    {
        using var presentation = new Presentation(inputPath);
        presentation.Save(outputPath, SaveFormat.Pptx);
        Console.WriteLine($"Converted: {inputPath}");
    }
    catch (Exception exception)
    {
        Console.Error.WriteLine($"Failed: {inputPath} ({exception.Message})");
    }
}
```

Untuk beban kerja produksi, catat pengecualian lengkap, tentukan apakah file keluaran yang ada dapat ditimpa, dan tulis nama file yang gagal ke antrean retry atau review. File rusak, file yang dilindungi password yang dibuka tanpa password yang diperlukan, jalur yang tidak dapat diakses, dan konten yang tidak didukung semuanya dapat menyebabkan konversi gagal. Lihat [Password-Protected Presentations](/slides/id/net/password-protected-presentation/) untuk memuat file terenkripsi.

## **Kesetiaan dan Fitur Warisan**

Konversi biasanya mempertahankan slide, master, layout, teks, bentuk, gambar, tabel, dan diagram. Namun, PPT dan PPTX tidak mewakili setiap fitur dengan cara yang persis sama. Fitur warisan yang tidak memiliki padanan PPTX, atau tidak didukung oleh pustaka, mungkin dinormalisasi, dihilangkan, atau ditampilkan secara berbeda.

Periksa file yang telah dikonversi bila berisi animasi, transisi, objek OLE yang disematkan atau ditautkan, kontrol ActiveX, media yang disematkan, font yang tidak umum, atau makro VBA. File PPTX biasa bukan format yang mendukung makro, jadi gunakan alur kerja yang mendukung makro bila VBA harus tetap tersedia. Juga pastikan font yang diperlukan dan sumber daya eksternal ada di lingkungan tempat presentasi yang dikonversi akan dibuka atau dirender.

Untuk dokumen penting, buka kembali PPTX yang dihasilkan secara programatis dan inspeksi jumlah slide utama serta kontennya, kemudian bandingkan tampilannya dan perilaku slide‑show di penampil yang dituju. Jangan anggap panggilan [IPresentation.Save](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentation/save/) yang berhasil sebagai bukti bahwa setiap fitur warisan memiliki representasi PPTX yang persis.

## **Kapan Menggunakan PPTX**

Gunakan PPTX bila presentasi akan diedit di versi PowerPoint terkini, dipertukarkan dengan sistem yang bekerja dengan paket Open XML, atau disimpan dalam format yang lebih mudah diperiksa dan dipulihkan dibandingkan PPT biner warisan. Simpan PPT asli sebagai salinan arsip atau rollback sampai presentasi yang dikonversi telah melewati pemeriksaan kesetiaan Anda.

Jika Anda memerlukan PDF, HTML, gambar, XPS, atau tipe keluaran lain sebagai gantinya, gunakan panduan khusus format di [Convert Presentations to Multiple Formats](/slides/id/net/convert-presentation/) daripada menganggap semua target mempertahankan fitur PowerPoint yang dapat diedit.

## **Konverter Online**

Untuk file sesekali atau perbandingan cepat, Anda dapat menggunakan [online PPT to PPTX converter](https://products.aspose.app/slides/id/conversion/ppt-to-pptx). Untuk konversi berulang, pemrosesan batch, atau penanganan kesalahan tingkat aplikasi, gunakan API .NET.

## **Artikel Terkait**

- [PPT vs PPTX](/slides/id/net/ppt-vs-pptx/)
- [Simpan Presentasi di .NET](/slides/id/net/save-presentation/)
- [Format File yang Didukung](/slides/id/net/supported-file-formats/)
- [Buka Presentasi di .NET](/slides/id/net/open-presentation/)

## **FAQ**

**Apakah saya dapat mengonversi PPT ke PPTX tanpa Microsoft PowerPoint terpasang?**

Ya. Aspose.Slides untuk .NET memuat dan menyimpan file presentasi tanpa memerlukan Microsoft PowerPoint.

**Apakah konversi PPT ke PPTX akan mempertahankan semua konten secara tepat?**

Ini mempertahankan konten presentasi umum, tetapi kesetiaan penuh tidak dijamin untuk setiap fitur warisan atau yang tidak didukung. Tinjau file yang dihasilkan bila berisi makro, objek OLE atau ActiveX, media, animasi khusus, atau font yang tidak umum.

**Apakah saya dapat mengonversi file PPT yang dilindungi password?**

Ya, bila Anda menyediakan password yang benar saat memuat file. Password yang hilang atau salah menyebabkan operasi pemuatan gagal.

**Haruskah saya menghapus file PPT setelah konversi?**

Simpan file asli sampai Anda memverifikasi PPTX di penampil dan alur kerja yang penting bagi Anda. Ini menyediakan salinan rollback bila fitur warisan dikonversi secara berbeda.