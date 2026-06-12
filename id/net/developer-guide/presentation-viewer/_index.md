---
title: Buat Penampil Presentasi di .NET
linktitle: Penampil Presentasi
type: docs
weight: 50
url: /id/net/presentation-viewer/
keywords:
- melihat presentasi
- penampil presentasi
- membuat penampil presentasi
- melihat PPT
- melihat PPTX
- melihat ODP
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Buat penampil presentasi khusus di .NET menggunakan Aspose.Slides. Tampilkan file PowerPoint dan OpenDocument dengan mudah tanpa Microsoft PowerPoint."
---
## **Pendahuluan**

Aspose.Slides untuk .NET digunakan untuk membuat file presentasi dengan slide. Slide ini dapat dilihat dengan membuka presentasi di Microsoft PowerPoint, misalnya. Namun, pengembang kadang perlu melihat slide sebagai gambar di penampil gambar pilihan mereka atau menggunakannya dalam penampil presentasi khusus. Dalam kasus tersebut, Aspose.Slides memungkinkan Anda mengekspor slide individual sebagai gambar. Artikel ini menjelaskan cara melakukannya.

## **Menghasilkan Gambar SVG dari Slide**

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Buka aliran file.
1. Simpan slide sebagai gambar SVG ke aliran file.

```c#
int slideIndex = 0;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (FileStream svgStream = File.Create("output.svg"))
    {
        slide.WriteAsSvg(svgStream);
    }
}
```

## **Menghasilkan SVG dengan ID Bentuk Kustom**

Aspose.Slides dapat digunakan untuk menghasilkan sebuah [SVG](https://docs.fileformat.com/page-description-language/svg/) dari slide dengan `ID` bentuk khusus. Untuk mencapainya, gunakan properti Id dari antarmuka [ISvgShape](https://reference.aspose.com/slides/id/net/aspose.slides.export/isvgshape). Kelas `CustomSvgShapeFormattingController` dapat digunakan untuk mengatur ID bentuk.

```c#
int slideIndex = 0;

using (Presentation presentation = new Presentation("sample.odp"))
{
    ISlide slide = presentation.Slides[slideIndex];
    
    SVGOptions svgOptions = new SVGOptions
    {
        ShapeFormattingController = new CustomSvgShapeFormattingController()
    };

    using (FileStream svgStream = File.Create("output.svg"))
    {
        slide.WriteAsSvg(svgStream, svgOptions);
    }
}
```

```c#
class CustomSvgShapeFormattingController : ISvgShapeFormattingController
{
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController(int shapeStartIndex = 0)
    {
        m_shapeIndex = shapeStartIndex;
    }

    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        svgShape.Id = string.Format("shape-{0}", m_shapeIndex++);
    }
}
```

## **Membuat Gambar Miniatur Slide**

Aspose.Slides membantu Anda menghasilkan gambar miniatur slide. Untuk menghasilkan miniatur slide menggunakan Aspose.Slides, ikuti langkah-langkah berikut:

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Buat gambar miniatur dari slide yang direferensikan dengan skala yang diinginkan.
1. Simpan gambar miniatur dalam format gambar pilihan Anda.

```c#
int slideIndex = 0;
float scaleX = 1;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(scaleX, scaleY))
    {
        image.Save("output.jpg", ImageFormat.Jpeg);
    }
}
```

## **Membuat Miniatur Slide dengan Dimensi yang Ditentukan Pengguna**

Untuk membuat gambar miniatur slide dengan dimensi yang ditentukan pengguna, ikuti langkah-langkah berikut:

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Hasilkan gambar miniatur dari slide yang direferensikan dengan dimensi yang ditentukan.
1. Simpan gambar miniatur dalam format gambar pilihan Anda.

```c#
int slideIndex = 0;
Size slideSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("sample.odp"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(slideSize))
    {
        image.Save("output.jpg", ImageFormat.Jpeg);
    }
}
```

## **Membuat Miniatur Slide dengan Catatan Pembicara**

Untuk menghasilkan miniatur slide dengan catatan pembicara menggunakan Aspose.Slides, ikuti langkah-langkah berikut:

1. Buat sebuah instance kelas [RenderingOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/renderingoptions/).
1. Gunakan properti `RenderingOptions.SlidesLayoutOptions` untuk mengatur posisi catatan pembicara.
1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Hasilkan gambar miniatur dari slide yang direferensikan dengan menggunakan opsi rendering.
1. Simpan gambar miniatur dalam format gambar pilihan Anda.

```c#
int slideIndex = 0;

RenderingOptions renderingOptions = new RenderingOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomTruncated
    }
};

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(renderingOptions))
    {
        image.Save("output.png", ImageFormat.Png);
    }
}
```

## **Contoh Langsung**

Coba aplikasi gratis [**Aspose.Slides Viewer**](https://products.aspose.app/slides/id/viewer/) untuk melihat apa yang dapat Anda implementasikan dengan API Aspose.Slides:

[![Online PowerPoint Viewer](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/id/viewer/)

## **FAQ**

**Apakah Saya dapat menyematkan penampil presentasi dalam aplikasi web ASP.NET?**

Ya. Anda dapat menggunakan Aspose.Slides di sisi server untuk merender slide sebagai gambar atau HTML dan menampilkannya di peramban. Fitur navigasi dan zoom dapat diimplementasikan dengan JavaScript untuk pengalaman interaktif.

**Apa cara terbaik menampilkan slide di dalam penampil .NET khusus?**

Pendekatan yang disarankan adalah merender setiap slide sebagai gambar (misalnya PNG atau SVG) atau mengkonversinya ke HTML menggunakan Aspose.Slides, kemudian menampilkan output di dalam picture box (untuk desktop) atau kontainer HTML (untuk web).

**Bagaimana cara menangani presentasi besar dengan banyak slide?**

Untuk deck besar, pertimbangkan lazy-loading atau rendering slide sesuai permintaan. Ini berarti menghasilkan konten slide hanya ketika pengguna menavigasinya, sehingga mengurangi penggunaan memori dan waktu pemuatan.