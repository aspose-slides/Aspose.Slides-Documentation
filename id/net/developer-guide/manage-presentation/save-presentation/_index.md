---
title: Simpan Presentasi di .NET
linktitle: Simpan Presentasi
type: docs
weight: 80
url: /id/net/save-presentation/
keywords:
- simpan PowerPoint
- simpan OpenDocument
- simpan presentasi
- simpan slide
- simpan PPT
- simpan PPTX
- simpan ODP
- presentasi ke file
- presentasi ke stream
- jenis tampilan yang telah ditentukan
- Format Office Open XML yang Ketat
- mode Zip64
- menyegarkan thumbnail
- progres penyimpanan
- .NET
- C#
- Aspose.Slides
description: "Simpan presentasi PowerPoint dan OpenDocument ke file atau stream dalam C# dengan Aspose.Slides untuk .NET, serta mengonfigurasi output PPTX dan pelaporan progres."
---
## **Gambaran Umum**

Setelah Anda membuat presentasi atau [buka presentasi yang ada](/slides/id/net/open-presentation/), gunakan metode [Presentation.Save](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/save/) untuk menulis hasilnya. Aspose.Slides untuk .NET dapat menyimpan presentasi ke file atau stream dalam format PowerPoint, OpenDocument, PDF, dan format lainnya. Bagian berikut mencakup operasi penyimpanan standar dan opsi yang tersedia untuk output PPTX.

## **Simpan Presentasi ke File**

Untuk menyimpan presentasi ke file, berikan jalur output dan nilai [SaveFormat](https://reference.aspose.com/slides/id/net/aspose.slides.export/saveformat/) ke metode [Presentation.Save](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/save/). Nilai format menentukan jenis file yang dibuat oleh Aspose.Slides.

Contoh berikut membuat presentasi dan menyimpannya sebagai file PPTX:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

// Add or modify presentation content here.

presentation.Save("Output.pptx", SaveFormat.Pptx);
```

## **Simpan Presentasi dalam Format Aslinya**

Untuk contoh deteksi file dan stream, perilaku presentasi yang baru dibuat, serta perbedaan antara format sumber dan output, lihat [Determine the Original Presentation Format](/slides/id/net/detect-presentation-source-format/).

Dalam aplikasi pemrosesan batch, format masukan mungkin tidak diketahui sebelumnya. Setelah memuat file, baca format aslinya dari properti [IPresentation.SourceFormat](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentation/sourceformat/). Berikan nilai [SourceFormat](https://reference.aspose.com/slides/id/net/aspose.slides/sourceformat/) yang dihasilkan ke [SlideUtil.ToSaveFormat](https://reference.aspose.com/slides/id/net/aspose.slides.util/slideutil/tosaveformat/) untuk memperoleh nilai [SaveFormat](https://reference.aspose.com/slides/id/net/aspose.slides.export/saveformat/) yang sesuai, lalu gunakan [Presentation.Save](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/save/) untuk menulis presentasi yang telah dimodifikasi.

Contoh lengkap berikut memproses setiap file dalam direktori masukan, memperbarui judulnya, dan menyimpannya ke direktori keluaran dalam format yang dari mana file tersebut dimuat:

```cs
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Util;

var inputDirectory = "Input";
var outputDirectory = "Output";

Directory.CreateDirectory(outputDirectory);

foreach (var inputPath in Directory.EnumerateFiles(inputDirectory))
{
    try
    {
        using var presentation = new Presentation(inputPath);

        var sourceFormat = presentation.SourceFormat;
        var saveFormat = SlideUtil.ToSaveFormat(sourceFormat);

        presentation.DocumentProperties.Title = "Processed by the batch application";

        var outputPath = Path.Combine(outputDirectory, Path.GetFileName(inputPath));
        presentation.Save(outputPath, saveFormat);
    }
    catch (ArgumentException exception)
    {
        Console.Error.WriteLine($"Cannot map the source format of '{inputPath}': {exception.Message}");
    }
    catch (Exception exception)
    {
        Console.Error.WriteLine($"Cannot process '{inputPath}': {exception.Message}");
    }
}
```

[SlideUtil.ToSaveFormat](https://reference.aspose.com/slides/id/net/aspose.slides.util/slideutil/tosaveformat/) memetakan PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP, dan PowerPoint XML ke format penyimpanan presentasi yang bersesuaian. Ia hanya memetakan format sumber presentasi; tidak dimaksudkan untuk memilih format ekspor seperti PDF, HTML, TIFF, atau gambar. Memberikan nilai [SourceFormat](https://reference.aspose.com/slides/id/net/aspose.slides/sourceformat/) yang tidak didukung atau tidak valid menghasilkan [ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception).

File legacy PPT, PPS, dan POT menggunakan kontainer biner yang sama. Ketika presentasi semacam itu dimuat dari stream tanpa ekstensi file, file PPS atau POT dapat diidentifikasi sebagai PPT. Jika perlu mempertahankan subtipe legacy ini, simpan nama file atau metadata format asli secara terpisah dan gunakan saat memilih nama file dan format keluaran.

## **Simpan Presentasi ke Stream**

Untuk menulis presentasi tanpa bergantung pada jalur file akhir, berikan sebuah [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream) yang dapat ditulisi dan nilai [SaveFormat](https://reference.aspose.com/slides/id/net/aspose.slides.export/saveformat/) ke metode [Presentation.Save](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/save/). Pendekatan ini berguna ketika output harus dikembalikan dari layanan web, disimpan dalam basis data, atau diproses di memori.

Contoh berikut menyimpan presentasi baru ke stream file:

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
using var outputStream = new FileStream("Output.pptx", FileMode.Create);

presentation.Save(outputStream, SaveFormat.Pptx);
```

## **Simpan Presentasi dengan Jenis Tampilan yang Ditetapkan**

Anda dapat menentukan tampilan di mana PowerPoint pertama kali membuka presentasi yang disimpan. Atur properti [ViewProperties.LastView](https://reference.aspose.com/slides/id/net/aspose.slides/viewproperties/lastview/) ke nilai [ViewType](https://reference.aspose.com/slides/id/net/aspose.slides/viewtype/) sebelum menyimpan.

Contoh berikut mengonfigurasi tampilan Slide Master sebagai tampilan awal:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
```

## **Simpan Presentasi dalam Format Office Open XML yang Ketat**

Untuk membuat file PPTX yang mematuhi profil Strict dari Office Open XML, buat sebuah instance [PptxOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/pptxoptions/) dan atur properti [Conformance](https://reference.aspose.com/slides/id/net/aspose.slides.export/pptxoptions/conformance/) ke `Conformance.Iso29500_2008_Strict`. Kemudian berikan opsi tersebut ke metode [Presentation.Save](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/save/).

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var options = new PptxOptions
{
    Conformance = Conformance.Iso29500_2008_Strict
};

using var presentation = new Presentation();

presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
```

## **Simpan Presentasi dalam Format Office Open XML dalam Mode Zip64**

Arsip ZIP standar membatasi ukuran terkompresi dan tidak terkompresi tiap entri, total ukuran arsip, serta jumlah entri. Karena file PPTX adalah arsip ZIP, presentasi yang sangat besar dapat melampaui batas tersebut. Ekstensi ZIP64 meningkatkan batas ukuran dan jumlah entri yang berlaku.

Gunakan properti [PptxOptions.Zip64Mode](https://reference.aspose.com/slides/id/net/aspose.slides.export/pptxoptions/zip64mode/) untuk mengontrol apakah Aspose.Slides menulis ekstensi ZIP64:

- `IfNecessary` menggunakan ZIP64 hanya ketika presentasi melampaui batas ZIP standar. Ini adalah mode default.
- `Never` menonaktifkan ekstensi ZIP64.
- `Always` selalu menulis ekstensi ZIP64.

Contoh berikut selalu mengaktifkan ekstensi ZIP64 untuk presentasi keluaran:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    Zip64Mode = Zip64Mode.Always
};

presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, options);
```

{{% alert color="warning" title="Warning" %}}
Jika `Zip64Mode` diatur ke `Never` dan presentasi tidak dapat muat dalam batas ZIP standar, operasi penyimpanan akan melempar [PptxException](https://reference.aspose.com/slides/id/net/aspose.slides/pptxexception/).
{{% /alert %}}

## **Simpan Presentasi dalam Format Office Open XML dengan Tingkat Kompresi**

Untuk output PPTX, Anda dapat menyeimbangkan kecepatan penyimpanan dengan ukuran file dengan mengatur properti [PptxOptions.CompressionLevel](https://reference.aspose.com/slides/id/net/aspose.slides.export/pptxoptions/compressionlevel/). Enumerasi [CompressionLevel](https://reference.aspose.com/slides/id/net/aspose.slides.export/compressionlevel/) menyediakan nilai berikut:

- `None` menyimpan data tanpa kompresi.
- `Level1` memberikan kompresi tercepat dan output terkompresi terbesar.
- `Level2` hingga `Level5` secara progresif lebih mengutamakan ukuran output yang lebih kecil daripada kecepatan penyimpanan.
- `Level6` menyeimbangkan kecepatan penyimpanan dan ukuran file. Ini adalah level default.
- `Level7` dan `Level8` lebih mengutamakan ukuran output yang lebih kecil daripada kecepatan penyimpanan.
- `Level9` memberikan kompresi terkuat dan memerlukan waktu pemrosesan paling lama.

Contoh berikut menyimpan presentasi tanpa kompresi:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    CompressionLevel = CompressionLevel.None
};

presentation.Save("OutputNoCompression.pptx", SaveFormat.Pptx, options);
```

Contoh berikut menggunakan tingkat kompresi maksimum:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    CompressionLevel = CompressionLevel.Level9
};

presentation.Save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options);
```

## **Simpan Presentasi tanpa Menyegarkan Thumbnail**

Ketika presentasi disimpan sebagai PPTX, properti [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/id/net/aspose.slides.export/pptxoptions/refreshthumbnail/) mengontrol thumbnail dokumen:

- `true` menghasilkan kembali thumbnail selama operasi penyimpanan. Ini adalah nilai default.
- `false` mempertahankan thumbnail yang ada. Jika presentasi tidak memiliki thumbnail, Aspose.Slides tidak akan menghasilkan satu thumbnail.

Contoh berikut menyimpan presentasi tanpa menyegarkan thumbnail-nya:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    RefreshThumbnail = false
};

presentation.Save("Output.pptx", SaveFormat.Pptx, options);
```

{{% alert color="info" title="Note" %}}
Menonaktifkan penyegaran thumbnail dapat mengurangi waktu yang diperlukan untuk menyimpan file PPTX.
{{% /alert %}}

## **Simpan Pembaruan Progres dalam Persentase**

Untuk memantau operasi penyimpanan, implementasikan antarmuka [IProgressCallback](https://reference.aspose.com/slides/id/net/aspose.slides/iprogresscallback/) dan tetapkan implementasinya ke properti [ISaveOptions.ProgressCallback](https://reference.aspose.com/slides/id/net/aspose.slides.export/isaveoptions/progresscallback/). Aspose.Slides kemudian memanggil metode [IProgressCallback.Reporting](https://reference.aspose.com/slides/id/net/aspose.slides/iprogresscallback/reporting/) dengan nilai progres selama ekspor.

Contoh berikut melaporkan progres ekspor PDF ke konsol:

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

var options = new PdfOptions
{
    ProgressCallback = new ExportProgressHandler()
};

using var presentation = new Presentation("Sample.pptx");

presentation.Save("Output.pdf", SaveFormat.Pdf, options);

class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        var progress = Convert.ToInt32(progressValue);
        Console.WriteLine($"{progress}% of the file has been converted.");
    }
}
```

{{% alert color="info" title="Note" %}}
Aspose menyediakan **PowerPoint Splitter** gratis ([https://products.aspose.app/slides/id/splitter](https://products.aspose.app/slides/id/splitter)) yang dibangun dengan API Aspose.Slides. Alat ini menyimpan slide terpilih dari suatu presentasi sebagai file PPT atau PPTX terpisah.
{{% /alert %}}

## **FAQ**

**Apakah Aspose.Slides mendukung penyimpanan incremental atau “fast save”?**

Tidak. Setiap operasi penyimpanan menulis file output lengkap alih-alih memperbarui hanya bagian yang berubah.

**Dapatkah beberapa thread menyimpan instance Presentation yang sama?**

Tidak. Sebuah instance [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) **tidak thread‑safe** (/slides/id/net/multithreading/). Akses dan simpan setiap instance hanya dari satu thread pada satu waktu.

**Apa yang terjadi pada hyperlink dan file yang ditautkan secara eksternal saat saya menyimpan presentasi?**

[Hyperlink](/slides/id/net/manage-hyperlinks/) tetap berada dalam presentasi. Aspose.Slides tidak menyalin file yang ditautkan secara eksternal, sehingga presentasi yang disimpan tetap harus dapat mengakses lokasi file tersebut.

**Bisakah saya menyimpan metadata dokumen seperti penulis, judul, perusahaan, dan tanggal pembuatan?**

Ya. Tetapkan [properti dokumen](/slides/id/net/presentation-properties/) yang sesuai sebelum menyimpan, dan Aspose.Slides akan menuliskannya ke file output.