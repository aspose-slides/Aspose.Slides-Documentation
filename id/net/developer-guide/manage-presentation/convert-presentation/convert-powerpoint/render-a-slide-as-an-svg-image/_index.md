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
description: "Ekspor slide PowerPoint sebagai gambar SVG di .NET dan kendalikan font, teks, gambar, ID, serta peristiwa dengan Aspose.Slides."
---
## **Gambaran Umum**

SVG adalah format gambar berbasis XML yang dapat diskalakan dan bekerja dengan baik untuk penerbitan web, penampil slide, alur kerja aksesibilitas, dan pemrosesan pasca otomatis. Aspose.Slides mengekspor setiap slide ke file SVG terpisah dan memungkinkan Anda mengontrol bagaimana teks, font, gambar, dan elemen SVG ditulis.

Gunakan [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) ketika SVG yang diekspor harus kompak, dapat diprediksi di semua peramban, atau siap untuk penggunaan interaktif.

## **Ekspor Slide sebagai SVG**

Buat sebuah [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), pilih sebuah slide, dan tulis ke dalam aliran. Contoh berikut mengekspor setiap slide dalam presentasi sebagai file SVG terpisah.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

Nama file menggunakan [ISlide.SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/) bukan indeks perulangan. Anda juga dapat mengekspor sebuah bentuk individual dengan [IShape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/ishape/writeassvg/) ketika penampil slide atau halaman web hanya memerlukan bentuk tersebut.

## **Konfigurasikan Output SVG**

[SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) mengendalikan perenderan SVG. Untuk bingkai teks, [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframesize/) menyertakan bingkai teks dalam area perenderan, dan [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframerotation/) menentukan apakah rotasi bingkai diterapkan. Atur [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablefontligatures/) ke `true` ketika teks harus dirender tanpa ligatur.

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

## **Kendalikan Teks dan Font**

Saat mengekspor slide ke SVG, Anda dapat mengendalikan apakah teks tetap sebagai teks atau dikonversi menjadi grafik vektor, serta bagaimana font eksternal disertakan atau direferensikan. Opsi berikut membantu Anda menyeimbangkan konsistensi visual, pemilihan teks, dan ketergantungan font dalam SVG yang diekspor.

### **Vektorkan Semua Teks**

Atur [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) ke `true` untuk menulis semua teks slide sebagai grafik vektor. Ini menghilangkan ketergantungan font dan membuat hasil visual lebih konsisten di semua peramban, namun teks tidak lagi dapat dipilih atau dicari sebagai teks SVG.

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

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/externalfontshandling/) menggunakan nilai [SvgExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) untuk font yang dimuat secara eksternal. Pilih `AddLinksToFontFiles` untuk mereferensikan file font terpisah, `Embed` untuk menyertakan data font dalam SVG, atau `Vectorize` untuk merender hanya teks yang menggunakan font eksternal sebagai grafik. Verifikasi lisensi font sebelum menyematkan font.

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

## **Kurangi Ukuran Gambar yang Disematkan**

Gunakan [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) untuk mengurangi resolusi gambar yang disematkan, [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) untuk menghilangkan area sumber yang dipotong, dan [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) untuk mengendalikan kualitas pengkodean JPEG. Pengaturan ini mengurangi ukuran file dengan mengorbankan kesetiaan gambar atau data gambar yang dipertahankan.

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

[SVGOptions.MetafileRasterizationDpi](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/metafilerasterizationdpi/) menetapkan batas resolusi terendah untuk merasterkan metafile selama ekspor SVG. Gunakan ini untuk menyeimbangkan detail dan ukuran file ketika gambar EMF atau WMF dirasterkan. Ini tidak mendefinisikan DPI global untuk SVG atau memaksa setiap objek pada slide menjadi gambar raster.

Unduh [metafile-rasterization.pptx](metafile-rasterization.pptx), yang berisi gambar EMF dengan garis diagonal berjarak rapat. Contoh berikut mengekspor slide pertama pada tiga resolusi rasterisasi melalui [ISlide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/islide/writeassvg/). Semua pengaturan ekspor lainnya tetap identik sehingga hasil dapat dibandingkan.

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

Dalam output, EMF menjadi satu PNG yang disematkan di setiap SVG. Pengukuran berikut berlaku untuk presentasi yang disediakan; bukan rumus umum untuk mengonversi DPI ke dimensi piksel.

| DPI rasterisasi Metafile | Dimensi PNG yang disematkan | Ukuran file SVG (byte) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Perbandingan di bawah menunjukkan area yang sama dari raster yang disematkan pada ukuran tampilan yang diperbesar yang sama. Garis diagonal menunjukkan pikselisasi yang terlihat pada 72 DPI dan tepi yang lebih halus pada resolusi yang lebih tinggi, sementara file SVG bertambah. Meningkatkan nilai tidak selalu memperbaiki setiap detail atau mengubah setiap gambar yang diekspor.

![Detail garis diagonal yang diperbesar pada 72, 150, dan 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) mengendalikan pengurangan resolusi gambar dan dapat menyamarkan efek perubahan resolusi rasterisasi metafile. [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) mengendalikan kualitas pengkodean JPEG, bukan resolusi rasterisasi metafile.

## **Tetapkan ID Stabil untuk Bentuk dan Teks**

Gunakan [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/) untuk mengatur [ISvgShape.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/id/) untuk setiap bentuk SVG. Untuk mengatur nilai [ISvgTSpan.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgtspan/id/) pada elemen teks `tspan` juga, implementasikan [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeandtextformattingcontroller/). Tetapkan salah satu kontroler dengan [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/).

Kontroler berikut menggunakan [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/net/aspose.slides/ishape/officeinteropshapeid/), yang stabil selama masa hidup bentuk, dan penghitung yang dapat diulang untuk rentang teksnya. Ini membuat ID yang dihasilkan cocok untuk pemrosesan lanjutan pada presentasi yang tidak berubah.

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

Dalam sebuah [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/), panggil [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/seteventhandler/) dengan nilai [SvgEvent](https://reference.aspose.com/slides/net/aspose.slides.export/svgevent/) untuk menambahkan penangan peristiwa JavaScript ke bentuk yang diekspor. Tetapkan kontroler dengan [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) dan definisikan fungsi JavaScript di halaman atau dokumen SVG yang menampung hasilnya.

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

Halaman host dapat mendefinisikan fungsi JavaScript yang direferensikan oleh penangan. Penetapan ID dan penangan peristiwa memungkinkan penampil slide, peningkatan aksesibilitas, dan alur kerja SVG interaktif lainnya.

## **FAQ**

**Kapan saya harus menggunakan [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) alih-alih [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/)?**

Gunakan [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) ketika semua teks harus independen dari font. Gunakan [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) ketika hanya teks yang menggunakan font eksternal yang harus dikonversi menjadi grafik.

**Apa cara terbaik untuk membuat SVG lebih kecil?**

Mulailah dengan mengompres gambar yang disematkan, menghapus area gambar yang dipotong, dan memilih file font yang ditautkan ketika lingkungan target dapat menyediakannya. Uji hasilnya karena resolusi gambar yang lebih rendah, kualitas JPEG yang lebih rendah, dan teks yang vektorisasi masing-masing memiliki trade‑off kualitas dan ukuran yang berbeda.

**Apakah saya dapat memodifikasi elemen SVG yang diekspor setelah ekspor?**

Ya. Tetapkan ID melalui kontroler pemformatan, kemudian pilih elemen SVG yang sesuai dalam alat pemrosesan lanjutan atau skrip peramban Anda.