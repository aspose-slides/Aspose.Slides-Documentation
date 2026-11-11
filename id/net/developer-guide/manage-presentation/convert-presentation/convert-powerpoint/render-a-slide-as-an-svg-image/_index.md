---
title: Render Slide Presentasi sebagai Gambar SVG di .NET
linktitle: Slide ke SVG
type: docs
weight: 50
url: /id/net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint ke SVG
- presentasi ke SVG
- slide ke SVG
- PPT ke SVG
- PPTX ke SVG
- opsi ekspor SVG
- SVG interaktif
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Ekspor slide PowerPoint sebagai gambar SVG di .NET dan kontrol font, teks, gambar, ID, serta peristiwa dengan Aspose.Slides."
---
## **Gambaran Umum**

SVG adalah format gambar berbasis XML yang dapat diskalakan, cocok untuk penerbitan web, penampil slide, alur kerja aksesibilitas, dan pemrosesan otomatis. Aspose.Slides mengekspor setiap slide ke file SVG terpisah dan memungkinkan Anda mengontrol cara teks, font, gambar, dan elemen SVG ditulis.

Gunakan [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) ketika SVG yang diekspor harus kompak, dapat diprediksi di semua peramban, atau siap untuk penggunaan interaktif.

## **Ekspor Slide sebagai SVG**

Buat [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), pilih slide, dan tulis ke aliran. Contoh berikut mengekspor setiap slide dalam presentasi sebagai file SVG terpisah.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

Nama file menggunakan [ISlide.SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/) bukan indeks perulangan. Anda juga dapat mengekspor bentuk individual dengan [IShape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/ishape/writeassvg/) ketika penampil slide atau halaman web hanya membutuhkan bentuk tersebut.

## **Konfigurasikan Output SVG**

[SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) mengontrol rendering SVG. Untuk bingkai teks, [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframesize/) menyertakan bingkai teks dalam area rendering, dan [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframerotation/) menentukan apakah rotasi bingkai diterapkan. Atur [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablefontligatures/) ke `true` ketika teks harus dirender tanpa ligatur.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    DisableFontLigatures = true,
    UseFrameSize = true,
    UseFrameRotation = false
};

using var svgStream = File.Create("slide-with-custom-options.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

## **Kendalikan Pemotongan Ujung Garis pada Kepala Panah**

SVG 1.1 tidak memiliki pengaturan inset penanda untuk menentukan di mana sebuah garis harus berhenti di bawah kepala panah. Secara default, Aspose.Slides memendekkan garis yang diekspor sehingga goresannya tidak menonjol melalui penanda. Atur [SVGOptions.DisableLineEndCropping](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablelineendcropping/) ke `true` untuk menggambar goresan sampai ke titik akhir asli garis. Pengaturan ini hanya memengaruhi output SVG. Garis tetap mempertahankan posisi dan panjangnya pada slide.

Contoh menggambar kepala panah segitiga dan berlian pada garis dengan lebar 2 dan 10 poin. Ia mengekspor slide yang sama dua kali, hanya mengubah opsi pemotongan.

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var y = 40;

foreach (var style in new[] { LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond })
{
    foreach (var width in new[] { 2, 10 })
    {
        var line = slide.Shapes.AddAutoShape(ShapeType.Line, 40, y, 200, 0);
        var format = line.LineFormat;
        format.FillFormat.FillType = FillType.Solid;
        format.FillFormat.SolidFillColor.Color = Color.DarkBlue;
        format.Width = width;
        format.EndArrowheadStyle = style;
        y += 50;
    }
}

var options = new SVGOptions { DisableLineEndCropping = false };
using var cropped = File.Create("cropped.svg");
slide.WriteAsSvg(cropped, options);

options.DisableLineEndCropping = true;
using var uncropped = File.Create("uncropped.svg");
slide.WriteAsSvg(uncropped, options);
```

Perbandingan menunjukkan kepala panah segitiga pada garis 10 poin. Dengan pemotongan diaktifkan, ujungnya tajam. Dengan pemotongan dinonaktifkan, goresan menonjol melalui sisi miring penanda dan meninggalkan ujung datar.

![Enlarged 10-point triangle with a sharp tip when cropping is enabled and a flat end when cropping is disabled](line-end-cropping.png)

Pada garis lain dalam contoh, goresan yang menonjol kurang terlihat pada segitiga 2 poin. Berlian berisi menutupi ujung goresan pada kedua lebar.

## **Kendalikan Teks dan Font**

Saat mengekspor slide ke SVG, Anda dapat mengontrol apakah teks tetap berupa teks atau diubah menjadi grafik vektor, serta bagaimana font eksternal disertakan atau dirujuk. Opsi berikut membantu menyeimbangkan konsistensi visual, pilihan teks, dan ketergantungan font dalam SVG yang diekspor.

### **Vektorkan Semua Teks**

Atur [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) ke `true` untuk menulis semua teks slide sebagai grafik vektor. Ini menghilangkan ketergantungan font dan membuat hasil visual lebih konsisten di berbagai peramban, tetapi teks tidak lagi dapat dipilih atau dicari sebagai teks SVG.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    VectorizeText = true
};

using var svgStream = File.Create("slide-with-vectorized-text.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

### **Pilih Cara Penanganan Font Eksternal**

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/externalfontshandling/) menggunakan nilai [SvgExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) untuk font yang dimuat secara eksternal. Pilih `AddLinksToFontFiles` untuk merujuk file font terpisah, `Embed` untuk menyertakan data font dalam SVG, atau `Vectorize` untuk merender hanya teks yang menggunakan font eksternal sebagai grafik. Verifikasi lisensi font sebelum menyertakan font.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var linkedFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.AddLinksToFontFiles
};

using var linkedFontsStream = File.Create("slide-with-font-links.svg");
presentation.Slides[0].WriteAsSvg(linkedFontsStream, linkedFontsOptions);

var embeddedFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.Embed
};

using var embeddedFontsStream = File.Create("slide-with-embedded-fonts.svg");
presentation.Slides[0].WriteAsSvg(embeddedFontsStream, embeddedFontsOptions);

var vectorizedExternalFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.Vectorize
};

using var vectorizedExternalFontsStream = File.Create("slide-with-vectorized-external-fonts.svg");
presentation.Slides[0].WriteAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
```

## **Kurangi Ukuran Gambar Tersemat**

Gunakan [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) untuk mengurangi resolusi gambar tersemat, [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) untuk menghilangkan area sumber yang dipotong, dan [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) untuk mengontrol kualitas enkoding JPEG. Pengaturan ini mengurangi ukuran file dengan mengorbankan ketajaman gambar atau data gambar yang dipertahankan.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    PicturesCompression = PicturesCompression.Dpi150,
    DeletePicturesCroppedAreas = true,
    JpegQuality = 80
};

using var svgStream = File.Create("compressed-slide.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

## **Kendalikan Resolusi Rasterisasi Metafile**

[SVGOptions.MetafileRasterizationDpi](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/metafilerasterizationdpi/) menetapkan batas resolusi rendah untuk merasterkan metafile selama ekspor SVG. Gunakan untuk menyeimbangkan detail dan ukuran file ketika gambar EMF atau WMF dirasterkan. Ini tidak mendefinisikan DPI global untuk SVG atau memaksa setiap objek pada slide menjadi gambar raster.

Unduh [metafile-rasterization.pptx](metafile-rasterization.pptx), yang berisi gambar EMF dengan garis diagonal berjarak rapat. Contoh berikut mengekspor slide pertama pada tiga resolusi rasterisasi melalui [ISlide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/islide/writeassvg/). Semua pengaturan ekspor lainnya tetap identik sehingga hasilnya dapat dibandingkan.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("metafile-rasterization.pptx");

foreach (var dpi in new[] { 72, 150, 300 })
{
    var svgOptions = new SVGOptions
    {
        MetafileRasterizationDpi = dpi,
        PicturesCompression = PicturesCompression.Dpi330,
        JpegQuality = 90
    };

    using var svgStream = File.Create($"slide-{dpi}.svg");
    presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
}
```

Dalam keluaran, EMF menjadi satu PNG tersemat di setiap SVG. Pengukuran berikut untuk presentasi yang disediakan; bukan rumus umum untuk mengonversi DPI ke dimensi piksel.

| DPI rasterisasi Metafile | Dimensi PNG Tersemat | Ukuran file SVG (byte) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Perbandingan di bawah memperlihatkan area yang sama dari raster tersemat pada ukuran tampilan yang diperbesar. Garis diagonal menunjukkan pikselasi yang terlihat pada 72 DPI dan tepi yang lebih halus pada resolusi lebih tinggi, sementara ukuran file SVG bertambah. Meningkatkan nilai tidak selalu memperbaiki setiap detail atau mengubah setiap gambar yang diekspor.

![Enlarged diagonal-line detail at 72, 150, and 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) mengontrol pengurangan resolusi gambar dan dapat menutupi efek perubahan resolusi rasterisasi metafile. [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) mengontrol kualitas enkoding JPEG, bukan resolusi rasterisasi metafile.

## **Tetapkan ID Stabil untuk Bentuk dan Teks**

Gunakan [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/) untuk menetapkan [ISvgShape.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/id/) bagi setiap bentuk SVG. Untuk menetapkan nilai [ISvgTSpan.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgtspan/id/) pada elemen `tspan` teks juga, terapkan [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeandtextformattingcontroller/). Tetapkan salah satu controller dengan [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/).

Controller berikut menggunakan [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/net/aspose.slides/ishape/officeinteropshapeid/), yang stabil selama masa hidup bentuk, dan penghitung berulang untuk span teksnya. Ini membuat ID yang dihasilkan cocok untuk pemrosesan lanjutan pada presentasi yang tidak berubah.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    ShapeFormattingController = new StableSvgIdController()
};

using var svgStream = File.Create("slide-with-stable-ids.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);

class StableSvgIdController : ISvgShapeAndTextFormattingController
{
    private string currentShapeId = string.Empty;
    private int textSpanIndex;

    public ISvgShapeFormattingController AsISvgShapeFormattingController => this;

    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        currentShapeId = $"shape-{shape.OfficeInteropShapeId}";
        textSpanIndex = 0;
        svgShape.Id = currentShapeId;
    }

    public void FormatText(ISvgTSpan svgTSpan, IPortion portion, ITextFrame textFrame)
    {
        svgTSpan.Id = $"{currentShapeId}-text-{textSpanIndex++}";
    }
}
```

## **Tambahkan Penangan Peristiwa SVG**

Dalam sebuah [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/), panggil [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/seteventhandler/) dengan nilai [SvgEvent](https://reference.aspose.com/slides/net/aspose.slides.export/svgevent/) untuk menambahkan penangan peristiwa JavaScript ke bentuk yang diekspor. Tetapkan controller dengan [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) dan definisikan fungsi JavaScript di halaman atau dokumen SVG yang menampung hasilnya.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    ShapeFormattingController = new SvgEventController()
};

using var svgStream = File.Create("interactive-slide.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);

class SvgEventController : ISvgShapeFormattingController
{
    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        if (shape.Name == "ActionButton")
        {
            svgShape.Id = "action-button";
            svgShape.SetEventHandler(SvgEvent.OnClick, "handleShapeClick(event)");
        }
    }
}
```

Halaman host dapat mendefinisikan fungsi JavaScript yang dirujuk oleh penangan. Penetapan ID dan penangan peristiwa memungkinkan penampil slide, peningkatan aksesibilitas, dan alur kerja SVG interaktif lainnya.

## **FAQ**

**Kapan saya harus menggunakan [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) alih-alih [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/)?**

Gunakan [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) ketika semua teks harus terlepas dari font. Gunakan [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) ketika hanya teks yang memakai font eksternal yang harus diubah menjadi grafik.

**Apa cara terbaik untuk membuat SVG lebih kecil?**

Mulailah dengan mengompres gambar tersemat, menghapus area gambar yang dipotong, dan memilih file font terhubung ketika lingkungan target dapat menyediakannya. Uji hasilnya karena resolusi gambar lebih rendah, kualitas JPEG lebih rendah, dan teks yang divisualisasikan masing‑masing memiliki kompromi kualitas dan ukuran yang berbeda.

**Bisakah saya memodifikasi elemen SVG yang diekspor setelah ekspor?**

Ya. Tetapkan ID melalui controller pemformatan, lalu pilih elemen SVG yang cocok dalam alat pemrosesan lanjutan atau skrip peramban Anda.