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
- tipe tampilan yang ditentukan
- Format Strict Office Open XML
- mode Zip64
- menyegarkan thumbnail
- kemajuan penyimpanan
- .NET
- C#
- Aspose.Slides
description: "Temukan cara menyimpan presentasi di .NET menggunakan Aspose.Slides—ekspor ke PowerPoint atau OpenDocument sambil mempertahankan tata letak, font, dan efek."
---
## **Gambaran Umum**

[Buka Presentasi di C#](/slides/id/net/open-presentation/) menjelaskan cara menggunakan kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) untuk membuka presentasi. Artikel ini menjelaskan cara membuat dan menyimpan presentasi. Kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) berisi konten presentasi. Apakah Anda membuat presentasi dari awal atau memodifikasi yang sudah ada, Anda akan ingin menyimpannya setelah selesai. Dengan Aspose.Slides untuk .NET, Anda dapat menyimpan ke **file** atau **stream**. Artikel ini menjelaskan berbagai cara untuk menyimpan presentasi.

## **Simpan Presentasi ke File**

Simpan presentasi ke file dengan memanggil metode `Save` pada kelas Presentation. Berikan nama file dan format penyimpanan ke metode tersebut. Contoh berikut menunjukkan cara menyimpan presentasi dengan Aspose.Slides.

```cs
// Membuat instance kelas Presentation yang mewakili file presentasi.
using (Presentation presentation = new Presentation())
{
    // Lakukan beberapa pekerjaan di sini...

    // Simpan presentasi ke file.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Simpan Presentasi ke Stream**

Anda dapat menyimpan presentasi ke stream dengan memberikan output stream ke metode `Save` pada kelas Presentation. Sebuah presentasi dapat ditulis ke berbagai jenis stream. Pada contoh di bawah, kami membuat presentasi baru dan menyimpannya ke file stream.

```cs
// Membuat instance kelas Presentation yang mewakili file presentasi.
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

Aspose.Slides memungkinkan Anda mengatur tampilan awal yang digunakan PowerPoint saat presentasi yang dihasilkan dibuka melalui kelas [ViewProperties](https://reference.aspose.com/slides/id/net/aspose.slides/viewproperties/). Atur properti [LastView](https://reference.aspose.com/slides/id/net/aspose.slides/viewproperties/lastview/) ke nilai dari enumerasi [ViewType](https://reference.aspose.com/slides/id/net/aspose.slides/viewtype/).

```cs
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **Simpan Presentasi dalam Format Strict Office Open XML**

Aspose.Slides memungkinkan Anda menyimpan presentasi dalam format Strict Office Open XML. Gunakan kelas [PptxOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/pptxoptions/) dan atur properti conformance‑nya saat menyimpan. Jika Anda mengatur `Conformance.Iso29500_2008_Strict`, file output akan disimpan dalam format Strict Office Open XML.

Contoh di bawah membuat presentasi dan menyimpannya dalam format Strict Office Open XML.

```cs
PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// Membuat instance kelas Presentation yang mewakili file presentasi.
using (Presentation presentation = new Presentation())
{
    // Simpan presentasi dalam format Strict Office Open XML.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **Simpan Presentasi dalam Format Office Open XML dalam Mode Zip64**

File Office Open XML adalah arsip ZIP yang memberlakukan batas 4 GB (2^32 byte) pada ukuran tidak terkompresi setiap file, ukuran terkompresi setiap file, dan total ukuran arsip, serta membatasi arsip hingga 65 535 (2^16‑1) file. Ekstensi format ZIP64 meningkatkan batas tersebut menjadi 2^64.

Properti [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/id/net/aspose.slides.export/ipptxoptions/zip64mode/) memungkinkan Anda memilih kapan menggunakan ekstensi format ZIP64 saat menyimpan file Office Open XML.

Properti ini menyediakan mode berikut:

- `IfNecessary` menggunakan ekstensi format ZIP64 hanya jika presentasi melebihi batas di atas. Ini adalah mode default.
- `Never` tidak pernah menggunakan ekstensi format ZIP64.
- `Always` selalu menggunakan ekstensi format ZIP64.

Kode berikut menunjukkan cara menyimpan presentasi sebagai file PPTX dengan ekstensi format ZIP64 diaktifkan:

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
Saat Anda menyimpan dengan `Zip64Mode.Never`, sebuah [PptxException](https://reference.aspose.com/slides/id/net/aspose.slides/pptxexception/) akan dilemparkan jika presentasi tidak dapat disimpan dalam format ZIP32.
{{% /alert %}}

## **Simpan Presentasi dalam Format Office Open XML dengan Tingkat Kompresi**

Saat bekerja dengan presentasi besar, Anda dapat menyesuaikan tingkat kompresi untuk menyeimbangkan ukuran file dan waktu proses. Bergantung pada kebutuhan Anda, Anda mungkin lebih memilih proses yang lebih cepat atau file output yang lebih kecil.

Aspose.Slides menyediakan properti [IPptxOptions.CompressionLevel](https://reference.aspose.com/slides/id/net/aspose.slides.export/ipptxoptions/compressionlevel/) yang memungkinkan Anda menentukan tingkat kompresi yang digunakan saat menyimpan presentasi dalam format Office Open XML.

Tingkat kompresi berikut tersedia:

- **None**: Tidak ada kompresi yang diterapkan. File disimpan apa adanya.
- **Level1**: Kompresi tercepat dengan rasio kompresi terendah.
- **Level2**: Kompresi lebih cepat dengan rasio kompresi sedikit lebih baik dibanding **Level1**.
- **Level3**: Memberikan kompresi yang lebih baik daripada **Level2** dengan dampak sedang pada waktu proses.
- **Level4**: Memberikan kompresi yang lebih baik daripada **Level3**.
- **Level5**: Memberikan kompresi yang lebih baik daripada **Level4** dengan tambahan waktu proses.
- **Level6**: Kompresi standar yang menawarkan keseimbangan baik antara kecepatan proses dan ukuran file. Ini adalah *tingkat kompresi default*.
- **Level7**: Memberikan kompresi yang lebih baik daripada **Level6** dengan proses yang lebih lambat.
- **Level8**: Memberikan kompresi yang lebih baik daripada **Level7**.
- **Level9**: Kompresi maksimal. Menghasilkan ukuran file terkecil dengan biaya waktu proses terpanjang.

Contoh berikut menunjukkan cara menyimpan presentasi sebagai file PPTX *tanpa kompresi*:
```cs
using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-out.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.None
    });
}
```

Contoh ini menunjukkan cara menyimpan presentasi sebagai file PPTX dengan *kompresi maksimal*:
```cs
using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-level9.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.Level9
    });
}
```

## **Simpan Presentasi tanpa Memperbarui Thumbnail**

Properti [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/id/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) mengontrol pembuatan thumbnail saat menyimpan presentasi ke PPTX:

- Jika diatur ke `true`, thumbnail diperbarui selama penyimpanan. Ini adalah default.
- Jika diatur ke `false`, thumbnail saat ini dipertahankan. Jika presentasi tidak memiliki thumbnail, tidak ada yang dihasilkan.

Dalam kode di bawah, presentasi disimpan ke PPTX tanpa memperbarui thumbnail‑nya.

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
Opsi ini membantu mengurangi waktu yang diperlukan untuk menyimpan presentasi dalam format PPTX.
{{% /alert %}}

## **Simpan Pembaruan Progres dalam Persentase**

Antarmuka [IProgressCallback](https://reference.aspose.com/slides/id/net/aspose.slides/iprogresscallback/) digunakan melalui properti `ProgressCallback` yang diekspos oleh antarmuka [ISaveOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/isaveoptions/) dan kelas abstrak [SaveOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/saveoptions/). Tetapkan implementasi [IProgressCallback](https://reference.aspose.com/slides/id/net/aspose.slides/iprogresscallback/) ke `ProgressCallback` untuk menerima pembaruan progres penyimpanan dalam persentase.

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
        // Gunakan nilai persentase progres di sini.
        int progress = Convert.ToInt32(progressValue);

        Console.WriteLine(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose telah mengembangkan aplikasi *PowerPoint Splitter* gratis menggunakan API‑nya sendiri. Aplikasi ini memungkinkan Anda membagi presentasi menjadi beberapa file dengan menyimpan slide terpilih sebagai file PPTX atau PPT baru. [free PowerPoint Splitter app](https://products.aspose.app/slides/id/splitter)
{{% /alert %}}

## **FAQ**

**Apakah "fast save" (penyimpanan inkremental) didukung sehingga hanya perubahan yang ditulis?**

Tidak. Setiap kali menyimpan, file target lengkap dibuat; “fast save” inkremental tidak didukung.

**Apakah aman untuk menyimpan instance Presentation yang sama dari banyak thread?**

Tidak. Instance Presentation tidak thread‑safe; simpanlah dari satu thread saja.

**Apa yang terjadi pada hyperlink dan file yang terhubung secara eksternal saat menyimpan?**

Hyperlink dipertahankan. File yang terhubung secara eksternal (misalnya video dengan jalur relatif) tidak disalin secara otomatis—pastikan jalur yang dirujuk tetap dapat diakses.

**Bisakah saya mengatur/menyimpan metadata dokumen (Penulis, Judul, Perusahaan, Tanggal)?**

Ya. Properti dokumen standar didukung dan akan ditulis ke file saat disimpan.