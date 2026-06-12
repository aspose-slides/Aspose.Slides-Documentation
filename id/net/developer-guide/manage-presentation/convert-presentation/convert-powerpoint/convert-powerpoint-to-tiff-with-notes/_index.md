---
title: Konversi Presentasi PowerPoint ke TIFF dengan Catatan di .NET
linktitle: PowerPoint ke TIFF dengan Catatan
type: docs
weight: 100
url: /id/net/convert-powerpoint-to-tiff-with-notes/
keywords:
- konversi PowerPoint
- konversi presentasi
- konversi slide
- konversi PPT
- konversi PPTX
- PowerPoint ke TIFF
- presentasi ke TIFF
- slide ke TIFF
- PPT ke TIFF
- PPTX ke TIFF
- simpan PPT sebagai TIFF
- simpan PPTX sebagai TIFF
- ekspor PPT ke TIFF
- ekspor PPTX ke TIFF
- PowerPoint dengan catatan
- presentasi dengan catatan
- slide dengan catatan
- PPT dengan catatan
- PPTX dengan catatan
- TIFF dengan catatan
- .NET
- C#
- Aspose.Slides
description: "Konversi presentasi PowerPoint ke TIFF dengan catatan menggunakan Aspose.Slides untuk .NET. Pelajari cara mengekspor slide dengan catatan pembicara secara efisien."
---
## **Pendahuluan**

Aspose.Slides for .NET menyediakan solusi sederhana untuk mengonversi presentasi PowerPoint dan OpenDocument (PPT, PPTX, dan ODP) dengan catatan ke format TIFF. Format ini banyak digunakan untuk penyimpanan gambar berkualitas tinggi, pencetakan, dan pengarsipan dokumen. Dengan Aspose.Slides, Anda tidak hanya dapat mengekspor seluruh presentasi beserta catatan pembicara tetapi juga menghasilkan thumbnail slide dalam tampilan Notes Slide. Proses konversi sederhana dan efisien, memanfaatkan metode `Save` dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) untuk mengubah seluruh presentasi menjadi serangkaian gambar TIFF sambil mempertahankan catatan dan tata letaknya.

## **Konversi Presentasi ke TIFF dengan Catatan**

Menyimpan presentasi PowerPoint atau OpenDocument ke TIFF dengan catatan menggunakan Aspose.Slides for .NET melibatkan langkah-langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/): Muat file PowerPoint atau OpenDocument.  
1. Konfigurasikan opsi tata letak output: Gunakan kelas [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/notescommentslayoutingoptions/) untuk menentukan cara menampilkan catatan dan komentar.  
1. Simpan presentasi ke TIFF: Berikan opsi yang telah dikonfigurasi ke metode [Save](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/methods/save/index).

Misalkan kita memiliki file "speaker_notes.pptx" dengan slide berikut:

![The presentation slide with speaker notes](slide_with_notes.png)

Potongan kode di bawah ini menunjukkan cara mengonversi presentasi menjadi gambar TIFF dalam tampilan Notes Slide menggunakan properti [SlidesLayoutOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/tiffoptions/slideslayoutoptions/).

```c#
// Membuat instance kelas Presentation yang mewakili file presentasi.
using (Presentation presentation = new Presentation("speaker_notes.pptx"))
{
    // Mengkonfigurasi opsi TIFF dengan tata letak Catatan.
    TiffOptions tiffOptions = new TiffOptions
    {
        DpiX = 300,
        DpiY = 300,

        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Menampilkan catatan di bawah slide.
        }
    };

    // Menyimpan presentasi ke TIFF dengan catatan pembicara.
    presentation.Save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
}
```

Hasilnya:

![The TIFF image with speaker notes](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Lihat Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/id/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Apakah saya dapat mengontrol posisi area catatan dalam TIFF yang dihasilkan?**

Ya. Gunakan [notes layout settings](https://reference.aspose.com/slides/id/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) untuk memilih di antara opsi seperti `None`, `BottomTruncated`, atau `BottomFull`, yang masing‑masing menyembunyikan catatan, menyesuaikannya ke satu halaman, atau membiarkannya melanjutkan ke halaman tambahan.

**Bagaimana cara mengurangi ukuran file TIFF dengan catatan tanpa kehilangan kualitas yang terlihat?**

Pilih [efficient compression](https://reference.aspose.com/slides/id/net/aspose.slides.export/tiffoptions/compressiontype/) (misalnya `LZW` atau `RLE`), tetapkan DPI yang wajar, dan bila memungkinkan, gunakan [pixel format](https://reference.aspose.com/slides/id/net/aspose.slides.export/tiffoptions/pixelformat/) yang lebih rendah (seperti 8 bpp atau 1 bpp untuk monokrom). Mengurangi sedikit [image dimensions](https://reference.aspose.com/slides/id/net/aspose.slides.export/tiffoptions/imagesize/) juga dapat membantu tanpa mengurangi keterbacaan secara signifikan.

**Apakah font dalam catatan memengaruhi hasil jika font asli tidak ada di sistem?**

Ya. Font yang hilang memicu [substitution](/slides/id/net/font-selection-sequence/), yang dapat mengubah metrik teks dan penampilannya. Untuk menghindarinya, [supply the required fonts](/slides/id/net/custom-font/) atau tetapkan [fallback font](/slides/id/net/fallback-font/) default agar tipe huruf yang dimaksud digunakan.