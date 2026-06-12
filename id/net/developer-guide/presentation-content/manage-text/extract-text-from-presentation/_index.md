---
title: Ekstraksi Teks Lanjutan dari Presentasi di .NET
linktitle: Ekstrak Teks
type: docs
weight: 90
url: /id/net/extract-text-from-presentation/
keywords:
- ekstrak teks
- ekstrak teks dari slide
- ekstrak teks dari presentasi
- ekstrak teks dari PowerPoint
- ekstrak teks dari OpenDocument
- ekstrak teks dari PPT
- ekstrak teks dari PPTX
- ekstrak teks dari ODP
- ambil teks
- ambil teks dari slide
- ambil teks dari presentasi
- ambil teks dari PowerPoint
- ambil teks dari OpenDocument
- ambil teks dari PPT
- ambil teks dari PPTX
- ambil teks dari ODP
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Ekstrak teks dengan cepat dari presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk .NET. Ikuti panduan sederhana langkah demi langkah kami untuk menghemat waktu."
---
## **Gambaran Umum**

Mengekstrak teks dari presentasi adalah tugas yang umum namun penting bagi pengembang yang bekerja dengan konten slide. Baik Anda menangani file Microsoft PowerPoint dalam format PPT atau PPTX, maupun presentasi OpenDocument (ODP), mengakses dan mengambil data teks dapat menjadi kritis untuk analisis, otomatisasi, pengindeksan, atau tujuan migrasi konten.

Artikel ini memberikan panduan komprehensif tentang cara mengekstrak teks secara efisien dari berbagai format presentasi, termasuk PPT, PPTX, dan ODP, menggunakan Aspose.Slides untuk .NET. Anda akan belajar cara menelusuri elemen presentasi secara sistematis untuk secara akurat mengambil konten teks yang Anda butuhkan.

## **Ekstrak Teks dari Slide**

Aspose.Slides untuk .NET menyediakan namespace [Aspose.Slides.Util](https://reference.aspose.com/slides/id/net/aspose.slides.util/) yang mencakup kelas [SlideUtil](https://reference.aspose.com/slides/id/net/aspose.slides.util/slideutil/). Kelas ini menyediakan beberapa metode statis yang di‑overload untuk mengekstrak semua teks dari presentasi atau slide. Untuk mengekstrak teks dari sebuah slide dalam presentasi, gunakan metode [GetAllTextBoxes](https://reference.aspose.com/slides/id/net/aspose.slides.util/slideutil/getalltextboxes/). Metode ini menerima objek berjenis [IBaseSlide](https://reference.aspose.com/slides/id/net/aspose.slides/ibaseslide/) sebagai parameter. Saat dijalankan, metode ini memindai seluruh slide untuk teks dan mengembalikan array objek berjenis [ITextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/), mempertahankan segala pemformatan teks.

Potongan kode berikut mengekstrak semua teks dari slide pertama presentasi:

```cs
int slideIndex = 0;

using var presentation = new Presentation("demo.pptx");

var slide = presentation.Slides[slideIndex];

var textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextBoxes(slide);

foreach (var textFrame in textFrames)
{
    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            var portionText = portion.Text;
            Console.WriteLine(portionText);

            var portionFormat = portion.PortionFormat;
            var fontHeight = portionFormat.FontHeight;
            Console.WriteLine(fontHeight);

            var latinFont = portionFormat.LatinFont;
            if (latinFont != null)
            {
                var fontName = latinFont.FontName;
                Console.WriteLine(fontName);
            }
        }
    }
}
```

## **Ekstrak Teks dari Presentasi**

Untuk memindai teks dari seluruh presentasi, gunakan metode statis [GetAllTextFrames](https://reference.aspose.com/slides/id/net/aspose.slides.util/slideutil/getalltextframes/) yang disediakan oleh kelas [SlideUtil](https://reference.aspose.com/slides/id/net/aspose.slides.util/slideutil/). Metode ini menerima dua parameter:

1. Pertama, objek [IPresentation](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentation/) yang mewakili presentasi PowerPoint atau OpenDocument dari mana teks akan diekstrak.
1. Kedua, nilai `Boolean` yang menunjukkan apakah slide master harus disertakan saat memindai teks dari presentasi.

Metode ini mengembalikan array objek berjenis [ITextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/), termasuk informasi pemformatan teks. Kode di bawah ini memindai teks dan detail pemformatan dari sebuah presentasi, termasuk slide master.

```cs
using var presentation = new Presentation("demo.pptx");

var includeMasterSlides = true;
var textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(presentation, includeMasterSlides);

foreach (var textFrame in textFrames)
{
    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            var portionText = portion.Text;
            Console.WriteLine(portionText);

            var portionFormat = portion.PortionFormat;
            var fontHeight = portionFormat.FontHeight;
            Console.WriteLine(fontHeight);

            var latinFont = portionFormat.LatinFont;
            if (latinFont != null)
            {
                var fontName = latinFont.FontName;
                Console.WriteLine(fontName);
            }
        }
    }
}
```

## **Ekstraksi Teks Terkategorisasi dan Cepat**

Kelas [PresentationFactory](https://reference.aspose.com/slides/id/net/aspose.slides/presentationfactory/) juga menyediakan metode untuk mengekstrak semua teks dari presentasi:

``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```

Argumen enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/id/net/aspose.slides/textextractionarrangingmode/) menunjukkan mode untuk mengatur hasil ekstraksi teks dan dapat diatur ke nilai berikut:
- `Unarranged` - Teks mentah tanpa memperhatikan posisinya pada slide.
- `Arranged` - Teks diatur dalam urutan yang sama seperti pada slide.

Mode unarranged dapat digunakan ketika kecepatan sangat penting; mode ini lebih cepat daripada mode arranged.

[IPresentationText](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentationtext/) mewakili teks mentah yang diekstrak dari presentasi. Properti `SlidesText`‑nya mengembalikan array objek berjenis [ISlideText](https://reference.aspose.com/slides/id/net/aspose.slides/islidetext/). Setiap objek mewakili teks pada slide yang bersangkutan. Objek berjenis [ISlideText](https://reference.aspose.com/slides/id/net/aspose.slides/islidetext/) memiliki properti berikut:

- `Text` - Teks dalam bentuk‑bentuk slide.
- `MasterText` - Teks dalam bentuk‑bentuk slide master yang terkait dengan slide ini.
- `LayoutText` - Teks dalam bentuk‑bentuk slide tata letak yang terkait dengan slide ini.
- `NotesText` - Teks dalam bentuk‑bentuk slide catatan yang terkait dengan slide ini.
- `CommentsText` - Teks dalam komentar yang terkait dengan slide ini.

```cs
var presentationPath = "presentation.ppt";
var arrangingMode = TextExtractionArrangingMode.Unarranged;
var presentationText = PresentationFactory.Instance.GetPresentationText(presentationPath, arrangingMode);
var firstSlideText = presentationText.SlidesText[0];

Console.WriteLine(firstSlideText.Text);
Console.WriteLine(firstSlideText.LayoutText);
Console.WriteLine(firstSlideText.MasterText);
Console.WriteLine(firstSlideText.NotesText);
Console.WriteLine(firstSlideText.CommentsText);
```

## **FAQ**

**Seberapa cepat Aspose.Slides memproses presentasi besar saat ekstraksi teks?**

Aspose.Slides dioptimalkan untuk kinerja tinggi dan dapat memproses bahkan [presentasi besar](/slides/id/net/open-presentation/), menjadikannya cocok untuk skenario pemrosesan waktu nyata atau dalam jumlah besar.

**Apakah Aspose.Slides dapat mengekstrak teks dari tabel dan bagan dalam presentasi?**

Ya. Aspose.Slides dapat mengekstrak teks dari banyak elemen slide, termasuk tabel dan objek terkait bagan, sehingga Anda dapat mengakses dan menganalisis konten teks dalam struktur presentasi yang umum.

**Apakah saya memerlukan lisensi khusus Aspose.Slides untuk mengekstrak teks dari presentasi?**

Anda dapat mengekstrak teks menggunakan versi uji coba gratis Aspose.Slides, meskipun memiliki [pembatasan tertentu](/slides/id/net/licensing/), seperti hanya dapat memproses sejumlah slide terbatas. Untuk penggunaan tanpa batas dan menangani presentasi yang lebih besar, disarankan membeli lisensi penuh.