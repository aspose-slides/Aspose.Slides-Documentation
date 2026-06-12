---
title: Menyimpan Presentasi di .NET
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
- tipe tampilan yang ditentukan
- Format Strict Office Open XML
- mode Zip64
- menyegarkan thumbnail
- progres penyimpanan
- .NET
- C#
- Aspose.Slides
description: "Temukan cara menyimpan presentasi di .NET menggunakan Aspose.Slides—ekspor ke PowerPoint atau OpenDocument sambil mempertahankan tata letak, font, dan efek."
---
## **Gambaran Umum**

[Open Presentations in C#](/slides/id/net/open-presentation/) menjelaskan cara menggunakan kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) untuk membuka sebuah presentasi. Artikel ini menjelaskan cara membuat dan menyimpan presentasi. Kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) berisi konten sebuah presentasi. Baik Anda membuat presentasi dari nol maupun memodifikasi yang sudah ada, Anda akan ingin menyimpannya setelah selesai. Dengan Aspose.Slides untuk .NET, Anda dapat menyimpan ke **file** atau **stream**. Artikel ini menjelaskan berbagai cara menyimpan sebuah presentasi.

## **Menyimpan Presentasi ke File**

Simpan sebuah presentasi ke file dengan memanggil metode `Save` pada kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/). Berikan nama file dan format penyimpanan ke metode tersebut. Contoh berikut menunjukkan cara menyimpan sebuah presentasi dengan Aspose.Slides.

```cs
// Membuat instance kelas Presentation yang mewakili file presentasi.
using (Presentation presentation = new Presentation())
{
    // Lakukan beberapa pekerjaan di sini...

    // Simpan presentasi ke file.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Menyimpan Presentasi ke Stream**

Anda dapat menyimpan sebuah presentasi ke stream dengan memberikan output stream ke metode `Save` pada kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/). Sebuah presentasi dapat ditulis ke banyak tipe stream. Pada contoh di bawah, kami membuat presentasi baru dan menyimpannya ke file stream.

```cs
// Buat instance kelas Presentation yang mewakili file presentasi.
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // Simpan presentasi ke stream.
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```

## **Menyimpan Presentasi dengan Tipe Tampilan yang Telah Ditetapkan**

Aspose.Slides memungkinkan Anda mengatur tampilan awal yang digunakan PowerPoint ketika presentasi yang dihasilkan dibuka melalui kelas [ViewProperties](https://reference.aspose.com/slides/id/net/aspose.slides/viewproperties/). Atur properti [LastView](https://reference.aspose.com/slides/id/net/aspose.slides/viewproperties/lastview/) ke nilai dari enumerasi [ViewType](https://reference.aspose.com/slides/id/net/aspose.slides/viewtype/).

```cs
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **Menyimpan Presentasi dalam Format Strict Office Open XML**

Aspose.Slides memungkinkan Anda menyimpan sebuah presentasi dalam format Strict Office Open XML. Gunakan kelas [PptxOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/pptxoptions/) dan atur properti conformance-nya saat menyimpan. Jika Anda mengatur `Conformance.Iso29500_2008_Strict`, file output disimpan dalam format Strict Office Open XML.

Contoh di bawah membuat sebuah presentasi dan menyimpannya dalam format Strict Office Open XML.

```cs
PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// Buat instance kelas Presentation yang mewakili file presentasi.
using (Presentation presentation = new Presentation())
{
    // Simpan presentasi dalam format Strict Office Open XML.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **Menyimpan Presentasi dalam Format Office Open XML dengan Mode Zip64**

File Office Open XML adalah arsip ZIP yang membatasi ukuran tidak terkompresi setiap file menjadi 4 GB (2^32 byte), ukuran terkompresi setiap file, serta total ukuran arsip, dan juga membatasi jumlah file dalam arsip menjadi 65 535 (2^16‑1). Ekstensi format ZIP64 meningkatkan batasan ini menjadi 2^64.

Properti [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/id/net/aspose.slides.export/ipptxoptions/zip64mode/) memungkinkan Anda memilih kapan menggunakan ekstensi format ZIP64 saat menyimpan file Office Open XML.

Properti ini menyediakan mode berikut:

- `IfNecessary` menggunakan ekstensi format ZIP64 hanya jika presentasi melebihi batasan di atas. Ini adalah mode default.
- `Never` tidak pernah menggunakan ekstensi format ZIP64.
- `Always` selalu menggunakan ekstensi format ZIP64.

Kode berikut mendemonstrasikan cara menyimpan sebuah presentasi sebagai PPTX dengan ekstensi format ZIP64 diaktifkan:

```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="NOTE" color="warning" %}}
Saat Anda menyimpan dengan `Zip64Mode.Never`, sebuah [PptxException](https://reference.aspose.com/slides/id/net/aspose.slides/pptxexception/) dilemparkan jika presentasi tidak dapat disimpan dalam format ZIP32.
{{% /alert %}}

## **Menyimpan Presentasi tanpa Menyegarkan Thumbnail**

Properti [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/id/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) mengontrol pembuatan thumbnail saat menyimpan sebuah presentasi ke PPTX:

- Jika diatur ke `true`, thumbnail disegarkan selama penyimpanan. Ini adalah nilai default.
- Jika diatur ke `false`, thumbnail saat ini dipertahankan. Jika presentasi tidak memiliki thumbnail, tidak ada yang dibuat.

Pada kode di bawah, presentasi disimpan ke PPTX tanpa menyegarkan thumbnail-nya.

```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        RefreshThumbnail = false
    });
}
```

{{% alert title="Info" color="info" %}}
Opsi ini membantu mengurangi waktu yang diperlukan untuk menyimpan sebuah presentasi dalam format PPTX.
{{% /alert %}}

## **Memperbarui Progres Penyimpanan dalam Persentase**

Antarmuka [IProgressCallback](https://reference.aspose.com/slides/id/net/aspose.slides/iprogresscallback/) digunakan melalui properti `ProgressCallback` yang disediakan oleh antarmuka [ISaveOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/isaveoptions/) dan kelas abstrak [SaveOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/saveoptions/). Tetapkan implementasi [IProgressCallback](https://reference.aspose.com/slides/id/net/aspose.slides/iprogresscallback/) ke `ProgressCallback` untuk menerima pembaruan progres penyimpanan dalam persentase.

Potongan kode berikut menunjukkan cara menggunakan `IProgressCallback`.

```cs
ISaveOptions saveOptions = new PdfOptions();
saveOptions.ProgressCallback = new ExportProgressHandler();

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pdf", SaveFormat.Pdf, saveOptions);
}
```

```cs
class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        // Gunakan nilai persentase kemajuan di sini.
        int progress = Convert.ToInt32(progressValue);

        Console.WriteLine(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose telah mengembangkan sebuah [aplikasi PowerPoint Splitter gratis](https://products.aspose.app/slides/id/splitter) menggunakan API mereka sendiri. Aplikasi ini memungkinkan Anda memisahkan sebuah presentasi menjadi beberapa file dengan menyimpan slide yang dipilih sebagai file PPTX atau PPT baru.
{{% /alert %}}

## **FAQ**

**Apakah “fast save” (penyimpanan inkremental) didukung sehingga hanya perubahan yang ditulis?**

Tidak. Setiap penyimpanan membuat file target secara lengkap; “fast save” inkremental tidak didukung.

**Apakah aman secara thread untuk menyimpan instance Presentation yang sama dari beberapa thread?**

Tidak. Sebuah instance [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) **tidak thread‑safe**; simpanlah dari satu thread saja.

**Apa yang terjadi pada hyperlink dan file yang ditautkan secara eksternal saat menyimpan?**

[Hyperlink](/slides/id/net/manage-hyperlinks/) dipertahankan. File yang ditautkan secara eksternal (misalnya video dengan jalur relatif) tidak disalin secara otomatis—pastikan jalur yang dirujuk tetap dapat diakses.

**Dapatkah saya mengatur/menyimpan metadata dokumen (Penulis, Judul, Perusahaan, Tanggal)?**

Ya. Properti dokumen standar [/slides/id/net/presentation-properties/] didukung dan akan dituliskan ke file saat disimpan.