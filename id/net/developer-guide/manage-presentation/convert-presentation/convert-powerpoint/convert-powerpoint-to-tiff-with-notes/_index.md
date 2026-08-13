---
title: Mengonversi Presentasi PowerPoint ke TIFF dengan Catatan di .NET
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

Aspose.Slides for .NET menyediakan solusi sederhana untuk mengonversi presentasi PowerPoint dan OpenDocument (PPT, PPTX, dan ODP) dengan catatan ke format TIFF. Format ini banyak digunakan untuk penyimpanan gambar berkualitas tinggi, pencetakan, dan pengarsipan dokumen. Dengan Aspose.Slides, Anda tidak hanya dapat mengekspor seluruh presentasi beserta catatan pembicara tetapi juga menghasilkan thumbnail slide dalam tampilan Catatan Slide. Proses konversi sederhana dan efisien, memanfaatkan metode `Save` dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) untuk mengubah seluruh presentasi menjadi serangkaian gambar TIFF sambil mempertahankan catatan dan tata letak.

## **Mengonversi Presentasi ke TIFF dengan Catatan**

Menyimpan presentasi PowerPoint atau OpenDocument ke TIFF dengan catatan menggunakan Aspose.Slides for .NET melibatkan langkah‑langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/): Muat file PowerPoint atau OpenDocument.  
2. Konfigurasikan opsi tata letak output: Gunakan kelas [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/notescommentslayoutingoptions/) untuk menentukan cara menampilkan catatan dan komentar.  
3. Simpan presentasi ke TIFF: Berikan opsi yang telah dikonfigurasi ke metode [Save](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/methods/save/index).

Misalkan kita memiliki file "speaker_notes.pptx" dengan slide berikut:

![Slide presentasi dengan catatan pembicara](slide_with_notes.png)

Potongan kode di bawah ini menunjukkan cara mengonversi presentasi ke gambar TIFF dalam tampilan Catatan Slide menggunakan properti [SlidesLayoutOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/tiffoptions/slideslayoutoptions/).

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instansiasi kelas Presentation yang mewakili file presentasi.
using (Presentation presentation = new Presentation("speaker_notes.pptx"))
{
    // Konfigurasikan opsi TIFF dengan tata letak Catatan.
    TiffOptions tiffOptions = new TiffOptions
    {
        DpiX = 300,
        DpiY = 300,

        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Tampilkan catatan di bawah slide.
        }
    };

    // Simpan presentasi ke TIFF dengan catatan pembicara.
    presentation.Save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
}
```

Hasilnya:

![Gambar TIFF dengan catatan pembicara](TIFF_with_notes.png)

{{% alert title="Tip" color="info" %}}
Lihat Aspose [Konverter PowerPoint ke Poster Gratis](https://products.aspose.app/slides/id/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

### Apakah saya dapat mengontrol posisi area catatan dalam TIFF yang dihasilkan?

Ya. Gunakan [pengaturan tata letak catatan](https://reference.aspose.com/slides/id/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) untuk memilih di antara opsi seperti `None`, `BottomTruncated`, atau `BottomFull`, yang masing‑masing menyembunyikan catatan, menyesuaikannya ke satu halaman, atau memungkinkan catatan mengalir ke halaman tambahan.

### Bagaimana cara mengurangi ukuran file TIFF dengan catatan tanpa mengurangi kualitas secara terlihat?

Pilih [kompresi efisien](https://reference.aspose.com/slides/id/net/aspose.slides.export/tiffoptions/compressiontype/) (misalnya `LZW` atau `RLE`), tetapkan DPI yang wajar, dan bila dapat diterima, gunakan [format piksel](https://reference.aspose.com/slides/id/net/aspose.slides.export/tiffoptions/pixelformat/) yang lebih rendah (seperti 8 bpp atau 1 bpp untuk monokrom). Mengurangi sedikit [dimensi gambar](https://reference.aspose.com/slides/id/net/aspose.slides.export/tiffoptions/imagesize/) juga dapat membantu tanpa mengurangi keterbacaan secara signifikan.

### Apakah font dalam catatan memengaruhi hasil jika font asli tidak ada di sistem?

Ya. Font yang hilang memicu [substitusi](/slides/id/net/font-selection-sequence/), yang dapat mengubah metrik teks dan tampilan. Untuk menghindarinya, [sediakan font yang diperlukan](/slides/id/net/custom-font/) atau atur [font cadangan](/slides/id/net/fallback-font/) default sehingga jenis huruf yang dimaksud digunakan.