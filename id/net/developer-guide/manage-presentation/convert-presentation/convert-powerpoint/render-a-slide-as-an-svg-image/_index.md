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
## **Ikhtisar**

SVG adalah format gambar berbasis XML yang dapat diskalakan dan bekerja dengan baik untuk penerbitan web, penampil slide, alur kerja aksesibilitas, serta pemrosesan pasca otomatis. Aspose.Slides mengekspor setiap slide ke file SVG terpisah dan memungkinkan Anda mengontrol cara teks, font, gambar, dan elemen SVG ditulis.

Gunakan [SVGOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/svgoptions/) ketika SVG yang diekspor harus kompak, dapat diprediksi di semua peramban, atau siap untuk penggunaan interaktif.

## **Ekspor Slide sebagai SVG**

Buat sebuah [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/), pilih sebuah slide, dan tulis ke stream. Contoh berikut mengekspor setiap slide dalam sebuah presentasi sebagai file SVG terpisah.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

Nama file menggunakan [ISlide.SlideNumber](https://reference.aspose.com/slides/id/net/aspose.slides/islide/slidenumber/) bukan indeks perulangan. Anda juga dapat mengekspor bentuk individual dengan [IShape.WriteAsSvg](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/writeassvg/) ketika penampil slide atau halaman web hanya memerlukan bentuk tersebut.

## **Konfigurasi Output SVG**

[SVGOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/svgoptions/) mengontrol rendering SVG. Untuk bingkai teks, [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/id/net/aspose.slides.export/svgoptions/useframesize/) menyertakan bingkai teks dalam area rendering, dan [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/id/net/aspose.slides.export/svgoptions/useframerotation/) menentukan apakah rotasi bingkai diterapkan. Atur [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/id/net/aspose.slides.export/svgoptions/disablefontligatures/) ke `true` ketika teks harus dirender tanpa ligatur.

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

## **Kontrol Teks dan Font**

### **Vektorisasi Semua Teks**

Atur [SVGOptions.VectorizeText](https://reference.aspose.com/slides/id/net/aspose.slides.export/svgoptions/vectorizetext/) ke `true` untuk menulis semua teks slide sebagai grafik vektor. Ini menghilangkan ketergantungan pada font dan membuat hasil visual lebih konsisten di semua peramban, tetapi teks tidak lagi dapat dipilih atau dicari sebagai teks SVG.

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

### **Pilih Cara Menangani Font Eksternal**

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/id/net/aspose.slides.export/svgoptions/externalfontshandling/) menggunakan nilai [SvgExternalFontsHandling](https://reference.aspose.com/slides/id/net/aspose.slides.export/svgexternalfontshandling/) untuk font yang dimuat secara eksternal. Pilih `AddLinksToFontFiles` untuk merujuk ke file font terpisah, `Embed` untuk menyertakan data font dalam SVG, atau `Vectorize` untuk merender hanya teks yang menggunakan font eksternal sebagai grafik. Verifikasi lisensi font sebelum menyematkan font.

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

Gunakan [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/id/net/aspose.slides.export/svgoptions/picturescompression/) untuk mengurangi resolusi gambar yang tersemat, [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/id/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) untuk menghilangkan area sumber yang dipotong, dan [SVGOptions.JpegQuality](https://reference.aspose.com/slides/id/net/aspose.slides.export/svgoptions/jpegquality/) untuk mengontrol kualitas enkoding JPEG. Pengaturan ini mengurangi ukuran berkas dengan mengorbankan kesetiaan gambar atau data gambar yang dipertahankan.

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

## **Tetapkan ID Stabil untuk Bentuk dan Teks**

Gunakan [ISvgShapeFormattingController](https://reference.aspose.com/slides/id/net/aspose.slides.export/isvgshapeformattingcontroller/) untuk mengatur [ISvgShape.Id](https://reference.aspose.com/slides/id/net/aspose.slides.export/isvgshape/id/) bagi setiap bentuk SVG. Untuk mengatur nilai [ISvgTSpan.Id](https://reference.aspose.com/slides/id/net/aspose.slides.export/isvgtspan/id/) pada elemen teks `tspan` juga, implementasikan [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/id/net/aspose.slides.export/isvgshapeandtextformattingcontroller/). Tetapkan salah satu controller dengan [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/id/net/aspose.slides.export/svgoptions/shapeformattingcontroller/).

Controller berikut menggunakan [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/officeinteropshapeid/), yang stabil selama masa hidup bentuk, dan penghitung berulang untuk rentang teksnya. Ini menjadikan ID yang dihasilkan cocok untuk pemrosesan lanjutan pada presentasi yang tidak diubah.

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

Dalam sebuah [ISvgShapeFormattingController](https://reference.aspose.com/slides/id/net/aspose.slides.export/isvgshapeformattingcontroller/), panggil [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/id/net/aspose.slides.export/isvgshape/seteventhandler/) dengan nilai [SvgEvent](https://reference.aspose.com/slides/id/net/aspose.slides.export/svgevent/) untuk menambahkan penangan peristiwa JavaScript ke bentuk yang diekspor. Tetapkan controller dengan [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/id/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) dan definisikan fungsi JavaScript di halaman atau dokumen SVG yang menampung hasilnya.

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

**Kapan saya harus menggunakan [SVGOptions.VectorizeText](https://reference.aspose.com/slides/id/net/aspose.slides.export/svgoptions/vectorizetext/) alih-alih [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/id/net/aspose.slides.export/svgexternalfontshandling/)?**

Gunakan [SVGOptions.VectorizeText](https://reference.aspose.com/slides/id/net/aspose.slides.export/svgoptions/vectorizetext/) ketika semua teks harus independen dari font. Gunakan [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/id/net/aspose.slides.export/svgexternalfontshandling/) ketika hanya teks yang menggunakan font eksternal yang harus dikonversi menjadi grafik.

**Apa cara terbaik untuk memperkecil ukuran SVG?**

Mulailah dengan mengompresi gambar yang tersemat, menghapus area gambar yang dipotong, dan memilih file font yang ditautkan ketika lingkungan target dapat menyediakannya. Uji hasilnya karena resolusi gambar yang lebih rendah, kualitas JPEG yang lebih rendah, dan teks yang dipvectorisasikan masing‑masing memiliki pertukaran kualitas dan ukuran yang berbeda.

**Apakah saya dapat memodifikasi elemen SVG yang diekspor setelah ekspor?**

Ya. Tetapkan ID melalui controller pemformatan, lalu pilih elemen SVG yang cocok di alat pemrosesan lanjutan atau skrip peramban Anda.