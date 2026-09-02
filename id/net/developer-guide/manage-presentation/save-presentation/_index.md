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
- tipe tampilan yang telah ditentukan
- Format Strict Office Open XML
- mode Zip64
- menyegarkan gambar mini
- progres penyimpanan
- .NET
- C#
- Aspose.Slides
description: "Temukan cara menyimpan presentasi di .NET menggunakan Aspose.Slides - ekspor ke PowerPoint atau OpenDocument sambil mempertahankan tata letak, font, dan efek."
---
## **Gambaran Umum**

[Buka Presentasi di C#](/slides/id/net/open-presentation/) menjelaskan cara menggunakan kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) untuk membuka sebuah presentasi. Artikel ini menjelaskan cara membuat dan menyimpan presentasi. Kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) berisi isi sebuah presentasi. Apakah Anda membuat presentasi dari awal atau memodifikasi yang sudah ada, Anda perlu menyimpannya setelah selesai. Dengan Aspose.Slides untuk .NET, Anda dapat menyimpan ke **file** atau **stream**. Artikel ini menjelaskan berbagai cara menyimpan sebuah presentasi.

## **Simpan Presentasi ke File**

Simpan sebuah presentasi ke file dengan memanggil metode `Save` milik kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/). Berikan nama file dan format penyimpanan ke metode tersebut. Contoh berikut menunjukkan cara menyimpan presentasi dengan Aspose.Slides.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiasi kelas Presentation yang mewakili file presentasi.
using (Presentation presentation = new Presentation())
{
    // Lakukan beberapa pekerjaan di sini...

    // Simpan presentasi ke file.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Simpan Presentasi ke Stream**

Anda dapat menyimpan sebuah presentasi ke stream dengan memberikan output stream ke metode `Save` milik kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/). Sebuah presentasi dapat ditulis ke banyak jenis stream. Pada contoh di bawah, kami membuat presentasi baru dan menyimpannya ke file stream.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiasi kelas Presentation yang mewakili file presentasi.
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // Simpan presentasi ke stream.
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```

## **Simpan Presentasi dengan Tipe Tampilan yang Ditentukan**

Aspose.Slides memungkinkan Anda mengatur tampilan awal yang digunakan PowerPoint ketika presentasi yang dihasilkan dibuka melalui kelas [ViewProperties](https://reference.aspose.com/slides/id/net/aspose.slides/viewproperties/). Atur properti [LastView](https://reference.aspose.com/slides/id/net/aspose.slides/viewproperties/lastview/) ke nilai dari enumerasi [ViewType](https://reference.aspose.com/slides/id/net/aspose.slides/viewtype/).

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **Simpan Presentasi dalam Format Strict Office Open XML**

Aspose.Slides memungkinkan Anda menyimpan sebuah presentasi dalam format Strict Office Open XML. Gunakan kelas [PptxOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/pptxoptions/) dan atur properti conformance-nya saat menyimpan. Jika Anda mengatur `Conformance.Iso29500_2008_Strict`, file output disimpan dalam format Strict Office Open XML.

Contoh di bawah membuat sebuah presentasi dan menyimpannya dalam format Strict Office Open XML.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// Instansiasi kelas Presentation yang mewakili file presentasi.
using (Presentation presentation = new Presentation())
{
    // Simpan presentasi dalam format Strict Office Open XML.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **Simpan Presentasi dalam Format Office Open XML dengan Mode Zip64**

File Office Open XML adalah arsip ZIP yang membatasi ukuran tidak terkompresi maksimum 4 GB (2^32 byte), ukuran terkompresi maksimum, serta total ukuran arsip, dan juga membatasi jumlah file menjadi 65 535 (2^16‑1). Ekstensi format ZIP64 menaikkan batas tersebut menjadi 2^64.

Properti [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/id/net/aspose.slides.export/ipptxoptions/zip64mode/) memungkinkan Anda memilih kapan menggunakan ekstensi format ZIP64 saat menyimpan file Office Open XML.

Properti ini menyediakan mode berikut:

- `IfNecessary` menggunakan ekstensi format ZIP64 hanya jika presentasi melebihi batas di atas. Ini adalah mode default.
- `Never` tidak pernah menggunakan ekstensi format ZIP64.
- `Always` selalu menggunakan ekstensi format ZIP64.

Kode berikut mendemonstrasikan cara menyimpan sebuah presentasi sebagai file PPTX dengan ekstensi format ZIP64 diaktifkan:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Simpan Presentasi dalam Format Office Open XML dengan Tingkat Kompresi**

Saat bekerja dengan presentasi besar, Anda dapat menyesuaikan tingkat kompresi untuk menyeimbangkan ukuran file dan waktu pemrosesan. Tergantung pada kebutuhan, Anda mungkin lebih memilih pemrosesan yang lebih cepat atau file output yang lebih kecil.

Aspose.Slides menyediakan properti [IPptxOptions.CompressionLevel](https://reference.aspose.com/slides/id/net/aspose.slides.export/ipptxoptions/compressionlevel/) yang memungkinkan Anda menentukan tingkat kompresi yang digunakan saat menyimpan presentasi dalam format Office Open XML.

Tingkat kompresi berikut tersedia:

- **None**: Tidak ada kompresi yang diterapkan. File disimpan sebagaimana adanya.
- **Level1:** Kompresi tercepat dengan rasio kompresi terendah.
- **Level2:** Kompresi lebih cepat dengan rasio kompresi sedikit lebih baik daripada **Level1**.
- **Level3:** Memberikan kompresi lebih baik daripada **Level2** dengan dampak sedang pada waktu pemrosesan.
- **Level4:** Memberikan kompresi lebih baik daripada **Level3**.
- **Level5:** Memberikan kompresi yang ditingkatkan dibandingkan **Level4** dengan tambahan waktu pemrosesan.
- **Level6:** Kompresi standar yang menawarkan keseimbangan yang baik antara kecepatan pemrosesan dan ukuran file. Ini adalah *tingkat kompresi default*.
- **Level7:** Memberikan kompresi lebih baik daripada **Level6** dengan pemrosesan yang lebih lambat.
- **Level8:** Memberikan kompresi lebih baik daripada **Level7**.
- **Level9:** Kompresi maksimum. Menghasilkan ukuran file terkecil dengan biaya waktu pemrosesan terlama.

Contoh berikut mendemonstrasikan cara menyimpan sebuah presentasi sebagai file PPTX *tanpa kompresi*:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-out.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.None
    });
}
```

Contoh ini menunjukkan cara menyimpan sebuah presentasi sebagai file PPTX dengan *kompresi maksimum*:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-level9.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.Level9
    });
}
```

## **Simpan Presentasi tanpa Menyegarkan Gambar Mini**

Properti [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/id/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) mengontrol pembuatan gambar mini saat menyimpan sebuah presentasi ke PPTX:

- Jika disetel ke `true`, gambar mini disegarkan selama penyimpanan. Ini adalah default.
- Jika disetel ke `false`, gambar mini saat ini dipertahankan. Jika presentasi tidak memiliki gambar mini, tidak ada yang dihasilkan.

Pada kode di bawah, presentasi disimpan ke PPTX tanpa menyegarkan gambar mini-nya.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Perbarui Progres Penyimpanan dalam Persentase**

Antarmuka [IProgressCallback](https://reference.aspose.com/slides/id/net/aspose.slides/iprogresscallback/) digunakan melalui properti `ProgressCallback` yang diekspos oleh antarmuka [ISaveOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/isaveoptions/) dan kelas abstrak [SaveOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/saveoptions/). Tetapkan implementasi [IProgressCallback](https://reference.aspose.com/slides/id/net/aspose.slides/iprogresscallback/) ke `ProgressCallback` untuk menerima pembaruan progres penyimpanan dalam persentase.

Potongan kode berikut menunjukkan cara menggunakan `IProgressCallback`.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

ISaveOptions saveOptions = new PdfOptions();
saveOptions.ProgressCallback = new ExportProgressHandler();

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pdf", SaveFormat.Pdf, saveOptions);
}
```

```cs
using Aspose.Slides;

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
Aspose telah mengembangkan sebuah [aplikasi PowerPoint Splitter gratis](https://products.aspose.app/slides/id/splitter) menggunakan API-nya sendiri. Aplikasi ini memungkinkan Anda membagi sebuah presentasi menjadi beberapa file dengan menyimpan slide terpilih sebagai file PPTX atau PPT baru.
{{% /alert %}}

## **FAQ**

**Apakah "penyimpanan cepat" (penyimpanan inkremental) didukung sehingga hanya perubahan yang ditulis?**

Tidak. Setiap penyimpanan membuat file target lengkap; "penyimpanan cepat" inkremental tidak didukung.

**Apakah aman dari segi thread untuk menyimpan instance Presentation yang sama dari beberapa thread?**

Tidak. Sebuah instance [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) **tidak thread‑safe**; simpanlah dari satu thread saja.

**Apa yang terjadi pada hyperlink dan file yang ditautkan secara eksternal saat menyimpan?**

[Hyperlink](/slides/id/net/manage-hyperlinks/) dipertahankan. File yang ditautkan secara eksternal (misalnya video dengan jalur relatif) tidak disalin secara otomatis—pastikan jalur yang dirujuk tetap dapat diakses.

**Bisakah saya mengatur/menyimpan metadata dokumen (Penulis, Judul, Perusahaan, Tanggal)?**

Ya. Properti dokumen standar [/slides/id/net/presentation-properties/] didukung dan akan ditulis ke file saat disimpan.