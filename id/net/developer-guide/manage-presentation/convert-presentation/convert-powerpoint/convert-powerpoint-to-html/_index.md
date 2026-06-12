---
title: Mengonversi Presentasi PowerPoint ke HTML di .NET
linktitle: PowerPoint ke HTML
type: docs
weight: 30
url: /id/net/convert-powerpoint-to-html/
keywords:
- konversi PowerPoint
- konversi presentasi
- konversi slide
- konversi PPT
- konversi PPTX
- PowerPoint ke HTML
- presentasi ke HTML
- slide ke HTML
- PPT ke HTML
- PPTX ke HTML
- simpan PowerPoint sebagai HTML
- simpan presentasi sebagai HTML
- simpan slide sebagai HTML
- simpan PPT sebagai HTML
- simpan PPTX sebagai HTML
- ekspor PPT ke HTML
- ekspor PPTX ke HTML
- .NET
- C#
- Aspose.Slides
description: "Konversi presentasi PowerPoint ke HTML di .NET. Gunakan Aspose.Slides untuk mengekspor file PPT dan PPTX, slide yang dipilih, catatan, font, gambar, SVG, dan media."
---
## **Gambaran Umum**

Aspose.Slides untuk .NET dapat menyimpan presentasi PowerPoint sebagai HTML tanpa Microsoft PowerPoint. Konversi dasar adalah memuat satu [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) dan memanggil [Save](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/save/) dengan [SaveFormat](https://reference.aspose.com/slides/id/net/aspose.slides.export/saveformat/). Gunakan [HtmlOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/htmloptions/) ketika Anda perlu mengontrol tata letak yang diekspor, font, gambar, catatan, komentar, output SVG, atau sumber daya yang ditautkan.

Panduan ini berfokus pada skenario ekspor HTML praktis:

- Mengekspor seluruh presentasi atau slide yang dipilih.
- Menghasilkan HTML dengan tata letak tetap, responsif, atau berbasis SVG.
- Menyertakan catatan pembicara dan komentar.
- Mengontrol kualitas gambar dan data gambar terpotong.
- Menyematkan font atau menyimpan file font secara terpisah.
- Memilih cara sumber daya eksternal dan file media ditulis dan direferensikan.

Secara default, ekspor HTML menghasilkan dokumen HTML yang mandiri di mana sebagian besar sumber daya disematkan. Ini memudahkan berbagi satu file, tetapi dapat meningkatkan ukuran output. Untuk penerbitan web, pertimbangkan sumber daya eksternal, DPI gambar yang lebih rendah, dan hanya menyematkan font yang tidak tersedia secara dapat diandalkan di lingkungan target.

## **Mengonversi Presentasi ke HTML**

Untuk mengekspor presentasi ke HTML, muat dengan [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) dan simpan dengan [SaveFormat.Html](https://reference.aspose.com/slides/id/net/aspose.slides.export/saveformat/).

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.Save("presentation.html", SaveFormat.Html);
```

Contoh ini menulis satu file HTML. Objek presentasi dibuang oleh deklarasi `using`, yang melepaskan handle file dan sumber daya rendering setelah ekspor.

## **Gunakan HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/htmloptions/) adalah kelas konfigurasi utama untuk ekspor HTML. Pengaturan umum meliputi:

- `SlidesLayoutOptions`: menambahkan catatan, komentar, handout, atau informasi tata letak lainnya.
- `HtmlFormatter`: mengubah struktur dokumen HTML atau mendelegasikan pemformatan ke pengontrol.
- `SlideImageFormat`: mengubah cara slide direpresentasikan, misalnya sebagai SVG.
- `PicturesCompression`: mengontrol DPI gambar dan ukuran output.
- `DeletePicturesCroppedAreas`: menyimpan atau menghapus data gambar terpotong.
- `SvgResponsiveLayout`: membuat konten SVG yang diekspor menyesuaikan dengan kontainernya.
- `ShowHiddenSlides`: menyertakan slide tersembunyi bila diperlukan.

Bagian berikut menunjukkan opsi paling umum secara terpisah sehingga Anda dapat menggabungkan hanya yang diperlukan dalam alur kerja Anda.

## **Mengonversi Slide Terpilih ke HTML**

[Presentation.Save](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/save/) yang menerima nomor slide menggunakan posisi slide berbasis 1. Loop di bawah ini menyimpan setiap slide ke file HTML terpisah.

```csharp
using var presentation = new Presentation("presentation.pptx");

var slideCount = presentation.Slides.Count;

for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    var slideNumber = slideIndex + 1;
    var slideNumbers = new[] { slideNumber };
    var htmlFileName = $"slide-{slideNumber}.html";

    presentation.Save(htmlFileName, slideNumbers, SaveFormat.Html);
}
```

Gunakan pola ini ketika situs web atau aplikasi membutuhkan satu halaman HTML per slide. Jika setiap slide harus memiliki tata letak yang sama, buat satu instance [HtmlOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/htmloptions/) dan berikan ke setiap pemanggilan `Save`.

## **Buat HTML Responsif**

[ResponsiveHtmlController](https://reference.aspose.com/slides/id/net/aspose.slides.export/responsivehtmlcontroller/) menyediakan output HTML responsif melalui [HtmlFormatter](https://reference.aspose.com/slides/id/net/aspose.slides.export/htmlformatter/). Gunakan ketika halaman yang diekspor harus menyesuaikan lebar browser dengan lebih baik.

```csharp
using var presentation = new Presentation("presentation.pptx");

var controller = new ResponsiveHtmlController();
var formatter = HtmlFormatter.CreateCustomFormatter(controller);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-responsive.html", SaveFormat.Html, htmlOptions);
```

Untuk tata letak responsif berbasis SVG, atur `SvgResponsiveLayout` pada [HtmlOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/htmloptions/). Ini berguna ketika konten slide diekspor sebagai markup SVG yang dapat diskalakan.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    SvgResponsiveLayout = true
};

presentation.Save("presentation-svg-responsive.html", SaveFormat.Html, htmlOptions);
```

## **Sertakan Catatan Pembicara dan Komentar**

Gunakan [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/notescommentslayoutingoptions/) melalui `HtmlOptions.SlidesLayoutOptions` untuk menyertakan catatan pembicara atau komentar. Catatan dan komentar disembunyikan secara default kecuali Anda memilih posisinya.

Misalkan presentasi sumber berisi catatan pembicara:

![Slide dengan catatan pembicara di PowerPoint](slide_with_notes.png)

Kode berikut mengekspor konten slide dengan catatan pembicara di bawah slide.

```csharp
using var presentation = new Presentation("presentation.pptx");

var layoutOptions = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomFull
};

var htmlOptions = new HtmlOptions
{
    SlidesLayoutOptions = layoutOptions
};

presentation.Save("presentation-with-notes.html", SaveFormat.Html, htmlOptions);
```

HTML yang diekspor mencakup area catatan:

![Output HTML dengan slide dan catatan pembicara](HTML_with_notes.png)

Untuk mengekspor komentar, atur `CommentsPosition`, misalnya ke `CommentsPositions.Right` atau `CommentsPositions.Bottom`. Jika hanya membutuhkan komentar, hilangkan `NotesPosition`. Jika memerlukan keduanya, atur kedua properti tersebut.

## **Kontrol Kualitas Gambar dan Area Terpotong**

Ekspor HTML dapat mengompres gambar slide untuk mengurangi ukuran output. Atur `PicturesCompression` ke nilai dari [PicturesCompression](https://reference.aspose.com/slides/id/net/aspose.slides.export/picturescompression/) ketika Anda memerlukan kualitas gambar yang lebih tinggi.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    PicturesCompression = PicturesCompression.Dpi150
};

presentation.Save("presentation-dpi-150.html", SaveFormat.Html, htmlOptions);
```

Secara default, area terpotong gambar dapat dihapus dari output yang diekspor. Simpan data terpotong hanya ketika pengguna harus dapat memulihkan atau memeriksa bagian gambar tersembunyi tersebut. Menyimpannya dapat meningkatkan ukuran HTML.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    DeletePicturesCroppedAreas = false
};

presentation.Save("presentation-with-cropped-areas.html", SaveFormat.Html, htmlOptions);
```

## **Tambahkan CSS**

Untuk penataan sederhana, berikan string CSS ke [HtmlFormatter.CreateDocumentFormatter](https://reference.aspose.com/slides/id/net/aspose.slides.export/htmlformatter/createdocumentformatter/). Ini mengubah dokumen HTML di sekitarnya sementara Aspose.Slides terus merender konten slide.

```csharp
using var presentation = new Presentation("presentation.pptx");

var cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
var formatter = HtmlFormatter.CreateDocumentFormatter(cssRules, true);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-styled.html", SaveFormat.Html, htmlOptions);
```

Untuk header dokumen khusus, file CSS tertaut, atau markup khusus di sekitar slide dan bentuk, implementasikan [IHtmlFormattingController](https://reference.aspose.com/slides/id/net/aspose.slides.export/ihtmlformattingcontroller/) dan berikan ke [HtmlFormatter](https://reference.aspose.com/slides/id/net/aspose.slides.export/htmlformatter/) dengan `CreateCustomFormatter`.

## **Sematkan Font**

Jika lingkungan target mungkin tidak memiliki font presentasi yang terpasang, sematkan font dalam HTML dengan [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/id/net/aspose.slides.export/embedallfontshtmlcontroller/). Penyematan meningkatkan kesetiaan visual tetapi meningkatkan ukuran output.

```csharp
using var presentation = new Presentation("presentation.pptx");

string[] fontNamesToExclude = { "Arial", "Calibri" };
var fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
var formatter = HtmlFormatter.CreateCustomFormatter(fontController);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
```

Kecualikan font hanya ketika Anda yakin peramban atau sistem target sudah menyediakannya. Untuk font merek atau font yang kurang umum, penyematan biasanya lebih aman.

## **Tautkan File Font Ali Menyematkannya**

Untuk mengurangi ukuran file HTML, Anda dapat menulis data font ke file WOFF terpisah dan menambahkan aturan `@font-face` ke HTML. Pembantu di bawah ini memperluas [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/id/net/aspose.slides.export/embedallfontshtmlcontroller/) dan menimpa `WriteFont`.

```cs
using var presentation = new Presentation("presentation.pptx");

var outputDirectory = Path.Combine(Environment.CurrentDirectory, "html-output");
var fontsDirectory = Path.Combine(outputDirectory, "fonts");
Directory.CreateDirectory(outputDirectory);

var fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
var formatter = HtmlFormatter.CreateCustomFormatter(fontController);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

var htmlFilePath = Path.Combine(outputDirectory, "presentation.html");
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);
```

```cs
public sealed class LinkedFontsHtmlController : EmbedAllFontsHtmlController
{
    private readonly string _fontOutputDirectory;
    private readonly string _fontUrlPrefix;

    public LinkedFontsHtmlController(
        string fontOutputDirectory,
        string fontUrlPrefix)
        : base(Array.Empty<string>())
    {
        _fontOutputDirectory = fontOutputDirectory;
        _fontUrlPrefix = fontUrlPrefix.TrimEnd('/') + "/";

        Directory.CreateDirectory(_fontOutputDirectory);
    }

    public override void WriteFont(
        IHtmlGenerator generator,
        IFontData originalFont,
        IFontData substitutedFont,
        string fontStyle,
        string fontWeight,
        byte[] fontData)
    {
        var font = substitutedFont ?? originalFont;
        var safeFontName = MakeSafeFileName(font.FontName);
        var safeFontStyle = string.IsNullOrWhiteSpace(fontStyle) ? "normal" : fontStyle;
        var safeFontWeight = string.IsNullOrWhiteSpace(fontWeight) ? "normal" : fontWeight;
        var fontFileName = $"{safeFontName}-{safeFontStyle}-{safeFontWeight}.woff";
        var fontFilePath = Path.Combine(_fontOutputDirectory, fontFileName);

        File.WriteAllBytes(fontFilePath, fontData);

        var fontUrl = _fontUrlPrefix + Uri.EscapeDataString(fontFileName);
        var fontFamily = font.FontName.Replace("\\", "\\\\").Replace("'", "\\'");

        generator.AddHtml("<style>");
        generator.AddHtml("@font-face {");
        generator.AddHtml($"font-family: '{fontFamily}';");
        generator.AddHtml($"font-style: {safeFontStyle};");
        generator.AddHtml($"font-weight: {safeFontWeight};");
        generator.AddHtml($"src: url('{fontUrl}') format('woff');");
        generator.AddHtml("}");
        generator.AddHtml("</style>");
    }

    private static string MakeSafeFileName(string fileName)
    {
        var invalidCharacters = Path.GetInvalidFileNameChars();
        var safeCharacters = fileName.ToCharArray();

        for (var characterIndex = 0; characterIndex < safeCharacters.Length; characterIndex++)
        {
            if (Array.IndexOf(invalidCharacters, safeCharacters[characterIndex]) >= 0)
            {
                safeCharacters[characterIndex] = '_';
            }
        }

        return new string(safeCharacters);
    }
}
```

Dalam contoh ini, file font disimpan ke `html-output/fonts`, dan HTML merujuknya dengan URL seperti `fonts/BrandFont-normal-400.woff`. Jika file HTML dan font ditempatkan di lokasi lain, pilih `fontUrlPrefix` sehingga cocok dengan jalur URL yang diterapkan.

## **Simpan Sumber Daya Secara Eksternal**

HTML yang mandiri mudah dipindahkan, tetapi sumber daya Base64 yang disematkan dapat membuat file menjadi besar. Jika aplikasi Anda memerlukan file gambar eksternal, implementasikan [ILinkEmbedController](https://reference.aspose.com/slides/id/net/aspose.slides.export/ilinkembedcontroller/) dan berikan ke konstruktor [HtmlOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/htmloptions/htmloptions/).

Ketika Anda mengeksternalisasi sumber daya, pilih dua jalur dengan sengaja:

- Jalur output sistem file, tempat aplikasi Anda menulis gambar, font, audio, atau video yang dihasilkan.
- Jalur URL, yaitu apa yang digunakan peramban dari dokumen HTML untuk memuat file tersebut.

Untuk implementasi penautan gambar lengkap, lihat [Export Presentations to HTML with Externally Linked Images](/slides/id/net/exporting-presentations-to-html-with-externally-linked-images/).

## **Ekspor File Media**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/id/net/aspose.slides.export/videoplayerhtmlcontroller/) mengekspor file video dan audio serta menulis HTML yang dapat memutarnya di peramban. Konstruktornya menerima:

- `path`: direktori tempat file media yang dihasilkan akan ditulis.
- `fileName`: nama file HTML yang sedang dibuat.
- `baseUri`: prefiks URI absolut yang digunakan dalam tautan HTML ke file media.

Jika file HTML berada di `html-output/presentation.html` dan file media disimpan di `html-output/media`, `path` harus menunjuk ke direktori media di disk, sementara `baseUri` harus menunjuk ke direktori yang sama dari sudut pandang peramban. Untuk pratinjau lokal, Anda dapat membangun URI `file:///` dari direktori media. Untuk aplikasi yang dipublikasikan, gunakan URL absolut dari direktori media yang dipublikasikan.

```csharp
var outputDirectory = Path.Combine(Environment.CurrentDirectory, "html-output");
var mediaDirectory = Path.Combine(outputDirectory, "media");
Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(mediaDirectory);

var htmlFileName = "presentation.html";
var mediaBaseUri = new Uri(mediaDirectory + Path.DirectorySeparatorChar).AbsoluteUri;

using var presentation = new Presentation();
using var videoStream = new FileStream("intro.mp4", FileMode.Open, FileAccess.Read);

var video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
var slide = presentation.Slides[0];
slide.Shapes.AddVideoFrame(20, 20, 480, 270, video);

var controller = new VideoPlayerHtmlController(mediaDirectory, htmlFileName, mediaBaseUri);
var formatter = HtmlFormatter.CreateCustomFormatter(controller);
var svgOptions = new SVGOptions(controller);
var slideImageFormat = SlideImageFormat.Svg(svgOptions);

var htmlOptions = new HtmlOptions(controller)
{
    HtmlFormatter = formatter,
    SlideImageFormat = slideImageFormat
};

var htmlFilePath = Path.Combine(outputDirectory, htmlFileName);
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);
```

Gunakan direktori output yang unik per pekerjaan ekspor, terutama dalam aplikasi server. Jalur output bersama dapat menyebabkan file dari konversi yang berbeda menimpa satu sama lain.

## **Kinerja dan Manajemen Sumber Daya**

Konversi HTML adalah operasi rendering, sehingga waktu pemrosesan dan penggunaan memori bergantung pada jumlah slide, resolusi gambar, font, efek, diagram, dan media yang disematkan. Nilai DPI `PicturesCompression` yang lebih tinggi, font yang disematkan, output SVG, dan area gambar terpotong yang dipertahankan dapat meningkatkan kesetiaan tetapi biasanya meningkatkan ukuran output.

Untuk konversi batch:

- Buang setiap instance [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) dengan cepat.
- Gunakan direktori output terpisah untuk pekerjaan terpisah.
- Hindari menyematkan font umum kecuali kesetiaan memerlukannya.
- Turunkan DPI gambar ketika HTML hanya untuk pratinjau atau thumbnail.
- Simpan presentasi sumber, HTML yang dihasilkan, dan sumber daya eksternal bersama hingga jalur penerapan final.

## **Tanya Jawab**

**Apakah tautan hiper tetap dipertahankan dalam output HTML?**

Ya. Tautan hiper presentasi diekspor ke HTML dan tetap dapat diklik ketika URL target valid.

**Bisakah saya mengonversi presentasi ke HTML secara paralel?**

Ya, tetapi jangan bagikan satu instance [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) di antara beberapa thread. Proses file yang berbeda dengan instance presentasi terpisah, aliran terpisah, dan direktori output terpisah. Lihat panduan [multithreading](/slides/id/net/multithreading/) untuk detailnya.

**Apakah objek Presentation thread‑safe?**

Tidak. Satu instance [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) harus dimuat, dimodifikasi, disimpan, dan dibuang pada satu thread. Untuk pekerjaan paralel, buat instance independen per thread atau proses.

**Mengapa file HTML yang dihasilkan besar?**

Ekspor default dapat menyematkan sumber daya langsung ke dalam HTML. Font yang disematkan, gambar DPI tinggi, media, konten SVG, dan area gambar terpotong yang dipertahankan juga menambah ukuran. Gunakan sumber daya eksternal, kecualikan font umum dari penyematan, dan turunkan `PicturesCompression` ketika ukuran kecil lebih penting daripada kesetiaan maksimum.

**Mengapa ukuran font PowerPoint seperti 24 pt muncul sebagai 17.999819 pt di HTML?**

Hal ini dapat terjadi karena PowerPoint dan HTML menggunakan model DPI yang berbeda. PowerPoint menyimpan ukuran teks dalam poin tipografi berdasarkan 72 DPI, sementara tata letak HTML berbasis piksel CSS dalam model 96 DPI. Ketika Aspose.Slides mengekspor presentasi ke HTML, ukuran font diterjemahkan antar sistem tersebut, dan konversi dapat menghasilkan perbedaan pembulatan kecil.

Nilai‑nilai tersebut tidak menunjukkan perubahan visual nyata pada ukuran font. Mereka hanya efek samping matematis dari konversi metrik teks antara PowerPoint dan HTML.

**Bagaimana saya harus memilih baseUri untuk ekspor media?**

Pilih `baseUri` dari sudut pandang peramban dan berikan sebagai URI absolut. Untuk pratinjau lokal, Anda dapat menurunkannya dari direktori output dengan `new Uri(mediaDirectory + Path.DirectorySeparatorChar).AbsoluteUri`. Untuk penerapan, gunakan URL absolut dari direktori media yang dipublikasikan. Direktori sistem file `path` dan `baseUri` peramban tidak harus berupa string yang sama, tetapi harus menggambarkan lokasi sumber daya yang sama.

**Apakah saya dapat menyertakan slide tersembunyi?**

Ya. Atur `ShowHiddenSlides = true` pada [HtmlOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/htmloptions/) ketika slide tersembunyi harus diekspor.