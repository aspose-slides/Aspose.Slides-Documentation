---
title: Konversi Presentasi PowerPoint ke TIFF di .NET
titlelink: PowerPoint ke TIFF
type: docs
weight: 90
url: /id/net/convert-powerpoint-to-tiff/
keywords:
- konversi PowerPoint
- konversi OpenDocument
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
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara dengan mudah mengonversi presentasi PowerPoint (PPT, PPTX) menjadi gambar TIFF berkualitas tinggi menggunakan Aspose.Slides untuk .NET. Contoh kode C#."
---
## **Pendahuluan**

TIFF (**Tagged Image File Format**) adalah format gambar raster tanpa kehilangan yang banyak digunakan, dikenal karena kualitasnya yang luar biasa dan preservasi detail grafis. Desainer, fotografer, dan penerbit desktop sering memilih TIFF untuk mempertahankan lapisan, akurasi warna, dan pengaturan asli pada gambar mereka.

Dengan menggunakan Aspose.Slides, Anda dapat dengan mudah mengonversi slide PowerPoint Anda (PPT, PPTX) dan slide OpenDocument (ODP) langsung menjadi gambar TIFF berkualitas tinggi, memastikan presentasi Anda mempertahankan fidelitas visual maksimal. 

## **Mengonversi Presentasi ke TIFF**

Dengan menggunakan metode [Save](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/save/) yang disediakan oleh kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/), Anda dapat dengan cepat mengonversi seluruh presentasi PowerPoint ke TIFF. Gambar TIFF yang dihasilkan sesuai dengan ukuran slide default.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Buat instance kelas Presentation yang mewakili file presentasi (PPT, PPTX, ODP, dll).
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // Simpan presentasi sebagai TIFF.
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```

## **Mengonversi Presentasi ke TIFF Hitam-Putih**

Properti [BwConversionMode](https://reference.aspose.com/slides/id/net/aspose.slides.export/tiffoptions/bwconversionmode/) dalam kelas [TiffOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/tiffoptions/) memungkinkan Anda menentukan algoritma yang digunakan saat mengonversi slide atau gambar berwarna menjadi TIFF hitam-putih. Perhatikan bahwa pengaturan ini hanya berlaku ketika properti [CompressionType](https://reference.aspose.com/slides/id/net/aspose.slides.export/tiffoptions/compressiontype/) disetel ke `CCITT4` atau `CCITT3`.

{{% alert color="info" title="Note" %}}
[TiffOptions.BwConversionMode](https://reference.aspose.com/slides/id/net/aspose.slides.export/tiffoptions/bwconversionmode/) adalah pengaturan tingkat ekspor yang memilih algoritma konversi piksel untuk seluruh gambar TIFF. Untuk menentukan bagaimana bentuk individual tampil saat mode tampilan hitam-putih aktif, gunakan [IShape.BlackWhiteMode](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/blackwhitemode/). Lihat [Control Black-and-White Rendering for Shapes](/net/shape-formatting/#control-black-and-white-rendering-for-shapes) untuk contoh.
{{% /alert %}}

Misalkan kita memiliki file "sample.pptx" dengan slide berikut:

![Slide presentasi](slide_black_and_white.png)

Kode C# berikut menunjukkan cara mengonversi slide berwarna menjadi TIFF hitam-putih:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

TiffOptions tiffOptions = new TiffOptions
{
    CompressionType = TiffCompressionTypes.CCITT4,
    BwConversionMode = BlackWhiteConversionMode.Dithering
};

using (Presentation presentation = new Presentation("sample.pptx"))
{
    presentation.Save("output.tiff", SaveFormat.Tiff, tiffOptions);
}
```

Hasil:

![TIFF Hitam-Putih](TIFF_black_and_white.png)

## **Mengonversi Presentasi ke TIFF dengan Ukuran Kustom**

Jika Anda memerlukan gambar TIFF dengan dimensi tertentu, Anda dapat mengatur nilai yang diinginkan menggunakan properti yang tersedia dalam [TiffOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/tiffoptions/). Misalnya, properti [ImageSize](https://reference.aspose.com/slides/id/net/aspose.slides.export/tiffoptions/imagesize/) memungkinkan Anda menentukan ukuran gambar yang dihasilkan.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Buat instance kelas Presentation yang mewakili file presentasi (PPT, PPTX, ODP, dll).
using (Presentation presentation = new Presentation("sample.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();

    // Atur jenis kompresi.
    tiffOptions.CompressionType = TiffCompressionTypes.Default;
    /* 
    Jenis kompresi:
        Default - Menentukan skema kompresi default (LZW).
        None - Menentukan tidak ada kompresi.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // Kedalaman tergantung pada jenis kompresi dan tidak dapat diatur secara manual.

    // Atur DPI gambar.
    tiffOptions.DpiX = 200;
    tiffOptions.DpiY = 200;

    // Atur ukuran gambar.
    tiffOptions.ImageSize = new Size(1728, 1078);

    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    // Simpan presentasi sebagai TIFF dengan ukuran yang ditentukan.
    presentation.Save("custom_size.tiff", SaveFormat.Tiff, tiffOptions);
}
```

## **Mengonversi Presentasi ke TIFF dengan Format Piksel Gambar Kustom**

Dengan menggunakan properti [PixelFormat](https://reference.aspose.com/slides/id/net/aspose.slides.export/tiffoptions/pixelformat/) dari kelas [TiffOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/tiffoptions), Anda dapat menentukan format piksel pilihan Anda untuk gambar TIFF yang dihasilkan.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Buat instance kelas Presentation yang mewakili file presentasi (PPT, PPTX, ODP, dll).
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();
   
    tiffOptions.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat berisi nilai-nilai berikut (seperti yang disebutkan dalam dokumentasi):
        Format1bppIndexed - 1 bit per piksel, terindeks.
        Format4bppIndexed - 4 bit per piksel, terindeks.
        Format8bppIndexed - 8 bit per piksel, terindeks.
        Format24bppRgb    - 24 bit per piksel, RGB.
        Format32bppArgb   - 32 bit per piksel, ARGB.
    */

    // Simpan presentasi sebagai TIFF dengan ukuran gambar yang ditentukan.
    presentation.Save("Custom_Image_Pixel_Format.tiff", SaveFormat.Tiff, tiffOptions);
}
```

{{% alert title="Tip" color="info" %}}
Lihat [konverter PowerPoint ke Poster GRATIS](https://products.aspose.app/slides/id/conversion/convert-ppt-to-poster-online) dari Aspose.
{{% /alert %}}

## **FAQ**

**Apakah saya dapat mengonversi slide individual alih-alih seluruh presentasi PowerPoint ke TIFF?**

Ya. Aspose.Slides memungkinkan Anda mengonversi slide individual dari presentasi PowerPoint dan OpenDocument menjadi gambar TIFF secara terpisah.

**Apakah ada batasan jumlah slide saat mengonversi presentasi ke TIFF?**

Tidak, Aspose.Slides tidak memberlakukan batasan apa pun pada jumlah slide. Anda dapat mengonversi presentasi dengan ukuran berapa pun ke format TIFF.

**Apakah animasi PowerPoint dan efek transisi dipertahankan saat mengonversi slide ke TIFF?**

Tidak, TIFF adalah format gambar statis. Oleh karena itu, animasi dan efek transisi tidak dipertahankan; hanya snapshot statis slide yang diekspor.