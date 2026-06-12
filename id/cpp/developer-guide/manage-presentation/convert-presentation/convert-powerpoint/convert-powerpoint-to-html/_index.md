---
title: Mengonversi Presentasi PowerPoint ke HTML dalam C++
linktitle: PowerPoint ke HTML
type: docs
weight: 30
url: /id/cpp/convert-powerpoint-to-html/
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
- C++
- Aspose.Slides
description: "Mengonversi presentasi PowerPoint ke HTML dalam C++. Gunakan Aspose.Slides untuk mengekspor berkas PPT dan PPTX, slide terpilih, catatan, font, gambar, SVG, dan media."
---
## **Gambaran Umum**

Aspose.Slides for C++ dapat menyimpan presentasi PowerPoint sebagai HTML tanpa Microsoft PowerPoint. Konversi dasar hanya membutuhkan pemuatan satu [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) dan pemanggilan `Save` dengan [SaveFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/saveformat/). Gunakan [HtmlOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/htmloptions/) ketika Anda perlu mengontrol tata letak, font, gambar, catatan, komentar, output SVG, atau sumber daya yang ditautkan.

Panduan ini berfokus pada skenario ekspor HTML yang praktis:

- Mengekspor seluruh presentasi atau slide terpilih.
- Menghasilkan HTML dengan tata letak tetap, responsif, atau berbasis SVG.
- Menyertakan catatan pembicara dan komentar.
- Mengontrol kualitas gambar dan data gambar yang dipotong.
- Menyematkan font atau menyimpan berkas font secara terpisah.
- Memilih cara menulis dan merujuk sumber daya eksternal serta berkas media.

Secara default, ekspor HTML menghasilkan dokumen HTML yang mandiri di mana sebagian besar sumber daya disematkan. Ini memudahkan berbagi satu berkas, tetapi dapat meningkatkan ukuran output. Untuk publikasi web, pertimbangkan sumber daya eksternal, DPI gambar yang lebih rendah, dan hanya menyematkan font yang tidak tersedia secara andal di lingkungan target.

## **Mengonversi Presentasi ke HTML**

Untuk mengekspor presentasi ke HTML, muat dengan [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) dan simpan dengan `SaveFormat::Html`.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->Save(u"presentation.html", SaveFormat::Html);

presentation->Dispose();
```

Contoh ini menulis satu berkas HTML. Pemanggilan `Dispose` melepaskan pegangan berkas dan sumber daya perenderan setelah ekspor.

## **Menggunakan HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/htmloptions/) adalah kelas konfigurasi utama untuk ekspor HTML. Pengaturan umum meliputi:

- `SlidesLayoutOptions`: menambahkan catatan, komentar, handout, atau informasi tata letak lainnya.
- `HtmlFormatter`: mengubah struktur dokumen HTML atau mendelegasikan pemformatan ke pengontrol.
- `SlideImageFormat`: mengubah cara slide direpresentasikan, misalnya sebagai SVG.
- `PicturesCompression`: mengontrol DPI gambar dan ukuran output.
- `DeletePicturesCroppedAreas`: menyimpan atau menghapus data gambar yang dipotong.
- `SvgResponsiveLayout`: membuat konten SVG yang diekspor menyesuaikan diri dengan kontainer.
- `ShowHiddenSlides`: menyertakan slide tersembunyi bila diperlukan.

Bagian berikut menampilkan opsi paling umum secara terpisah sehingga Anda dapat menggabungkan hanya yang diperlukan dalam alur kerja Anda.

## **Mengonversi Slide Terpilih ke HTML**

Overload `Presentation::Save` yang menerima nomor slide menggunakan posisi slide berbasis 1. Loop di bawah ini menyimpan setiap slide ke berkas HTML terpisah.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slideCount = presentation->get_Slides()->get_Count();

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slideNumber = slideIndex + 1;
    auto slideNumbers = System::MakeArray<int>({ slideNumber });
    auto htmlFileName = System::String::Format(u"slide-{0}.html", slideNumber);

    presentation->Save(htmlFileName, slideNumbers, SaveFormat::Html);
}

presentation->Dispose();
```

Gunakan pola ini ketika situs web atau aplikasi memerlukan satu halaman HTML per slide. Jika setiap slide harus memiliki tata letak yang sama, buat satu instance [HtmlOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/htmloptions/) dan berikan ke setiap pemanggilan `Save`.

## **Membuat HTML Responsif**

[ResponsiveHtmlController](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/responsivehtmlcontroller/) menyediakan output HTML responsif melalui [HtmlFormatter](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/htmlformatter/). Gunakan ketika halaman yang diekspor harus menyesuaikan lebar browser dengan lebih baik.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto controller = System::MakeObject<ResponsiveHtmlController>();
auto formatter = HtmlFormatter::CreateCustomFormatter(controller);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-responsive.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Untuk tata letak responsif berbasis SVG, atur `SvgResponsiveLayout` pada [HtmlOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/htmloptions/). Ini berguna ketika konten slide diekspor sebagai markup SVG yang skalabel.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_SvgResponsiveLayout(true);

presentation->Save(u"presentation-svg-responsive.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

## **Menyertakan Catatan Pembicara dan Komentar**

Gunakan [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/notescommentslayoutingoptions/) melalui `HtmlOptions.SlidesLayoutOptions` untuk menyertakan catatan pembicara atau komentar. Catatan dan komentar disembunyikan secara default kecuali Anda menentukan posisinya.

Misalkan presentasi sumber berisi catatan pembicara:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

Kode berikut mengekspor konten slide beserta catatan pembicara di bawah slide.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto layoutOptions = System::MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_NotesPosition(NotesPositions::BottomFull);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_SlidesLayoutOptions(layoutOptions);

presentation->Save(u"presentation-with-notes.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

HTML yang diekspor menyertakan area catatan:

![HTML output with the slide and speaker notes](HTML_with_notes.png)

Untuk mengekspor komentar, atur `CommentsPosition`, misalnya ke `CommentsPositions::Right` atau `CommentsPositions::Bottom`. Jika Anda hanya memerlukan komentar, abaikan `NotesPosition`. Jika Anda memerlukan keduanya, atur kedua properti tersebut.

## **Mengontrol Kualitas Gambar dan Area yang Dipotong**

Ekspor HTML dapat mengompresi gambar slide untuk mengurangi ukuran output. Atur `PicturesCompression` ke nilai dari [PicturesCompression](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/picturescompression/) ketika Anda memerlukan kualitas gambar yang lebih tinggi.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_PicturesCompression(PicturesCompression::Dpi150);

presentation->Save(u"presentation-dpi-150.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Secara default, area yang dipotong dari gambar dapat dihapus dari output yang diekspor. Simpan data yang dipotong hanya ketika pengguna harus dapat memulihkan atau memeriksa bagian gambar yang tersembunyi tersebut. Menyimpannya dapat meningkatkan ukuran HTML.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_DeletePicturesCroppedAreas(false);

presentation->Save(u"presentation-with-cropped-areas.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

## **Menambah CSS**

Untuk stilasi sederhana, berikan string CSS ke `HtmlFormatter::CreateDocumentFormatter`. Ini mengubah dokumen HTML di sekelilingnya sementara Aspose.Slides tetap merender konten slide.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto cssRules = u"body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
auto formatter = HtmlFormatter::CreateDocumentFormatter(cssRules, true);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-styled.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Untuk header dokumen khusus, berkas CSS yang ditautkan, atau markup khusus di sekitar slide dan shape, implementasikan [IHtmlFormattingController](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/ihtmlformattingcontroller/) dan berikan ke [HtmlFormatter](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/htmlformatter/) dengan `CreateCustomFormatter`.

## **Menyematkan Font**

Jika lingkungan target mungkin tidak memiliki font presentasi yang terpasang, sematkan font dalam HTML dengan [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/embedallfontshtmlcontroller/). Menyematkan meningkatkan kesetiaan visual tetapi menambah ukuran output.

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto fontNamesToExclude = System::MakeArray<System::String>({ u"Arial" });
auto fontController = System::MakeObject<EmbedAllFontsHtmlController>(fontNamesToExclude);
auto formatter = HtmlFormatter::CreateCustomFormatter(fontController);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-embedded-fonts.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Kecualikan font hanya ketika Anda yakin bahwa peramban atau sistem target sudah menyediakannya. Untuk font merek atau font yang tidak umum, menyematkan biasanya lebih aman.

## **Menautkan Berkas Font Alih-alih Menyematkannya**

Untuk mengurangi ukuran berkas HTML, Anda dapat menulis data font ke berkas WOFF terpisah dan menambahkan aturan `@font-face` ke HTML. Pembantu di bawah ini memperluas [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/embedallfontshtmlcontroller/) dan menimpa `WriteFont`.

```cpp
class LinkedFontsHtmlController : public EmbedAllFontsHtmlController
{
public:
    LinkedFontsHtmlController(
        System::String fontOutputDirectory,
        System::String fontUrlPrefix)
        : EmbedAllFontsHtmlController(System::MakeArray<System::String>(0)),
          m_fontOutputDirectory(fontOutputDirectory),
          m_fontUrlPrefix(fontUrlPrefix.TrimEnd(u'/') + u"/")
    {
        System::IO::Directory::CreateDirectory_(m_fontOutputDirectory);
    }

    void WriteFont(
        System::SharedPtr<IHtmlGenerator> generator,
        System::SharedPtr<IFontData> originalFont,
        System::SharedPtr<IFontData> substitutedFont,
        System::String fontStyle,
        System::String fontWeight,
        System::ArrayPtr<uint8_t> fontData) override
    {
        auto font = substitutedFont == nullptr ? originalFont : substitutedFont;
        auto safeFontName = MakeSafeFileName(font->get_FontName());
        auto safeFontStyle = System::String::IsNullOrWhiteSpace(fontStyle) ? u"normal" : fontStyle;
        auto safeFontWeight = System::String::IsNullOrWhiteSpace(fontWeight) ? u"normal" : fontWeight;
        auto fontFileName = System::String::Format(u"{0}-{1}-{2}.woff", safeFontName, safeFontStyle, safeFontWeight);
        auto fontFilePath = System::IO::Path::Combine(m_fontOutputDirectory, fontFileName);

        System::IO::File::WriteAllBytes(fontFilePath, fontData);

        auto fontUrl = m_fontUrlPrefix + System::Uri::EscapeDataString(fontFileName);
        auto fontFamily = font->get_FontName().Replace(u"\\", u"\\\\").Replace(u"'", u"\\'");

        generator->AddHtml(u"<style>");
        generator->AddHtml(u"@font-face {");
        generator->AddHtml(System::String::Format(u"font-family: '{0}';", fontFamily));
        generator->AddHtml(System::String::Format(u"font-style: {0};", safeFontStyle));
        generator->AddHtml(System::String::Format(u"font-weight: {0};", safeFontWeight));
        generator->AddHtml(System::String::Format(u"src: url('{0}') format('woff');", fontUrl));
        generator->AddHtml(u"}");
        generator->AddHtml(u"</style>");
    }

private:
    System::String m_fontOutputDirectory;
    System::String m_fontUrlPrefix;

    System::String MakeSafeFileName(System::String fileName)
    {
        auto invalidCharacters = System::IO::Path::GetInvalidFileNameChars();
        auto safeCharacters = fileName.ToCharArray();

        for (int characterIndex = 0; characterIndex < safeCharacters->get_Length(); characterIndex++)
        {
            if (System::Array<int16_t>::IndexOf(invalidCharacters, safeCharacters[characterIndex]) >= 0)
            {
                safeCharacters[characterIndex] = u'_';
            }
        }

        return System::String(safeCharacters);
    }
};

auto outputDirectory = System::IO::Path::Combine(System::Environment::get_CurrentDirectory(), u"html-output");
auto fontsDirectory = System::IO::Path::Combine(outputDirectory, u"fonts");
System::IO::Directory::CreateDirectory_(outputDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto fontController = System::MakeObject<LinkedFontsHtmlController>(fontsDirectory, u"fonts");
auto formatter = HtmlFormatter::CreateCustomFormatter(fontController);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

auto htmlFilePath = System::IO::Path::Combine(outputDirectory, u"presentation.html");
presentation->Save(htmlFilePath, SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

Dalam contoh ini, berkas font disimpan ke `html-output/fonts`, dan HTML merujuknya dengan URL seperti `fonts/BrandFont-normal-400.woff`. Jika berkas HTML dan font ditempatkan di lokasi lain, pilih `fontUrlPrefix` sehingga sesuai dengan jalur URL yang diterapkan.

## **Menyimpan Sumber Daya Secara Eksternal**

HTML mandiri mudah dipindahkan, tetapi sumber daya yang disematkan dalam Base64 dapat membuat berkas menjadi besar. Jika aplikasi Anda memerlukan berkas gambar eksternal, implementasikan [ILinkEmbedController](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/ilinkembedcontroller/) dan berikan ke konstruktor [HtmlOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/htmloptions/).

Saat Anda mengeksternalisasi sumber daya, pilih dua jalur dengan cermat:

- Jalur output sistem berkas, tempat aplikasi Anda menulis gambar, font, audio, atau video yang dihasilkan.
- Jalur URL, yaitu yang digunakan peramban dari dokumen HTML untuk memuat berkas‑berkas tersebut.

## **Mengekspor Berkas Media**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/videoplayerhtmlcontroller/) mengekspor berkas video dan audio serta menulis HTML yang dapat memutarnya di peramban. Konstruktornya menerima:

- `path`: direktori tempat berkas media yang dihasilkan akan ditulis.
- `fileName`: nama berkas HTML yang sedang dibuat.
- `baseUri`: awalan URI absolut yang digunakan dalam tautan HTML ke berkas media.

Jika berkas HTML berada di `html-output/presentation.html` dan berkas media disimpan di `html-output/media`, `path` harus menunjuk ke direktori media di disk, sedangkan `baseUri` harus menunjuk ke direktori yang sama dari sudut pandang peramban. Untuk pratinjau lokal, Anda dapat membangun URI `file:///` dari direktori media. Untuk aplikasi yang dipublikasikan, gunakan URL absolut dari direktori media yang dipublikasikan.

```cpp
auto outputDirectory = System::IO::Path::Combine(System::Environment::get_CurrentDirectory(), u"html-output");
auto mediaDirectory = System::IO::Path::Combine(outputDirectory, u"media");
System::IO::Directory::CreateDirectory_(outputDirectory);
System::IO::Directory::CreateDirectory_(mediaDirectory);

auto htmlFileName = u"presentation.html";
auto mediaBaseUri = System::MakeObject<System::Uri>(mediaDirectory + System::IO::Path::DirectorySeparatorChar)->get_AbsoluteUri();

auto presentation = System::MakeObject<Presentation>();
auto videoStream = System::MakeObject<System::IO::FileStream>(u"intro.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);

auto video = presentation->get_Videos()->AddVideo(videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddVideoFrame(20.0f, 20.0f, 480.0f, 270.0f, video);

auto controller = System::MakeObject<VideoPlayerHtmlController>(mediaDirectory, htmlFileName, mediaBaseUri);
auto formatter = HtmlFormatter::CreateCustomFormatter(controller);
auto svgOptions = System::MakeObject<SVGOptions>(controller);
auto slideImageFormat = SlideImageFormat::Svg(svgOptions);

auto htmlOptions = System::MakeObject<HtmlOptions>(controller);
htmlOptions->set_HtmlFormatter(formatter);
htmlOptions->set_SlideImageFormat(slideImageFormat);

auto htmlFilePath = System::IO::Path::Combine(outputDirectory, htmlFileName);
presentation->Save(htmlFilePath, SaveFormat::Html, htmlOptions);

videoStream->Dispose();
presentation->Dispose();
```

Gunakan direktori output yang unik per pekerjaan ekspor, terutama pada aplikasi server. Jalur output yang dibagikan dapat menyebabkan berkas‑berkas dari konversi yang berbeda saling menimpa.

## **Kinerja dan Pengelolaan Sumber Daya**

Konversi HTML adalah operasi perenderan, sehingga waktu proses dan penggunaan memori bergantung pada jumlah slide, resolusi gambar, font, efek, grafik, dan media yang disematkan. Nilai DPI `PicturesCompression` yang lebih tinggi, font yang disematkan, output SVG, dan area gambar yang dipotong yang dipertahankan dapat meningkatkan kesetiaan tetapi biasanya menambah ukuran output.

Untuk konversi batch:

- Segera `Dispose` setiap instance [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
- Gunakan direktori output terpisah untuk pekerjaan terpisah.
- Hindari menyematkan font umum kecuali kesetiaan memerlukannya.
- Turunkan DPI gambar ketika HTML hanya untuk pratinjau atau thumbnail.
- Simpan presentasi sumber, HTML yang dihasilkan, dan sumber daya eksternal bersama hingga jalur penerapan final.

## **FAQ**

**Apakah hyperlink dipertahankan dalam output HTML?**

Ya. Hyperlink pada presentasi diekspor ke HTML dan tetap dapat diklik bila URL target valid.

**Bisakah saya mengonversi presentasi ke HTML secara paralel?**

Ya, tetapi jangan berbagi satu instance [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) di antara thread. Proses berkas yang berbeda dengan instance presentasi terpisah, aliran terpisah, dan direktori output terpisah. Lihat panduan [multithreading guidance](/slides/id/cpp/multithreading/) untuk detailnya.

**Apakah objek Presentation bersifat thread‑safe?**

Tidak. Satu instance [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) harus dimuat, dimodifikasi, disimpan, dan di‑dispose pada satu thread. Untuk pekerjaan paralel, buat instance independen per thread atau proses.

**Mengapa berkas HTML yang dihasilkan berukuran besar?**

Ekspor default dapat menyematkan sumber daya langsung ke dalam HTML. Font yang disematkan, gambar DPI tinggi, media, konten SVG, dan area gambar yang dipotong yang dipertahankan juga menambah ukuran. Gunakan sumber daya eksternal, kecualikan font umum dari penyematan, dan turunkan `PicturesCompression` bila ukuran output lebih penting daripada kesetiaan maksimal.

**Mengapa ukuran font PowerPoint seperti 24 pt muncul sebagai 17.999819 pt di HTML?**

Hal ini dapat terjadi karena PowerPoint dan HTML menggunakan model DPI yang berbeda. PowerPoint menyimpan ukuran teks dalam poin tipografi berdasarkan 72 DPI, sementara tata letak HTML didasarkan pada piksel CSS dalam model 96 DPI. Ketika Aspose.Slides mengekspor presentasi ke HTML, ukuran font diterjemahkan antara kedua sistem tersebut, dan konversi dapat menghasilkan perbedaan pembulatan kecil.

Nilai‑nilai ini tidak menunjukkan perubahan visual nyata pada ukuran font. Mereka hanya efek samping matematis dari konversi metrik teks antara PowerPoint dan HTML.

**Bagaimana cara memilih baseUri untuk ekspor media?**

Pilih `baseUri` dari sudut pandang peramban dan berikan sebagai URI absolut. Untuk pratinjau lokal, Anda dapat menurunkannya dari direktori output dengan `System::MakeObject<System::Uri>(mediaDirectory + System::IO::Path::DirectorySeparatorChar)->get_AbsoluteUri()`. Untuk penerapan, gunakan URL absolut dari direktori media yang dipublikasikan. Jalur sistem berkas `path` dan `baseUri` peramban tidak harus berupa string yang sama, tetapi harus menggambarkan lokasi sumber daya yang sama.

**Bisakah saya menyertakan slide tersembunyi?**

Ya. Atur `ShowHiddenSlides` ke `true` pada [HtmlOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/htmloptions/) ketika slide tersembunyi harus diekspor.