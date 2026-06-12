---
title: Ekstraksi Teks Lanjutan dari Presentasi dengan C++
linktitle: Ekstrak Teks
type: docs
weight: 90
url: /id/cpp/extract-text-from-presentation/
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
- C++
- Aspose.Slides
description: "Ekstrak teks dengan cepat dari presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk C++. Ikuti panduan sederhana langkah demi langkah kami untuk menghemat waktu."
---
## **Gambaran Umum**

Mengekstrak teks dari presentasi adalah tugas yang umum namun penting bagi pengembang yang bekerja dengan konten slide. Baik Anda menangani file Microsoft PowerPoint dalam format PPT atau PPTX, maupun presentasi OpenDocument (ODP), mengakses dan mengambil data tekstual dapat menjadi krusial untuk analisis, otomatisasi, pengindeksan, atau tujuan migrasi konten.

Artikel ini memberikan panduan komprehensif tentang cara mengekstrak teks secara efisien dari berbagai format presentasi, termasuk PPT, PPTX, dan ODP, menggunakan Aspose.Slides untuk C++. Anda akan belajar cara mengiterasi elemen presentasi secara sistematis untuk secara akurat mengambil konten teks yang Anda butuhkan.

## **Ekstrak Teks dari Slide**

Aspose.Slides untuk C++ menyediakan namespace [Aspose.Slides.Util](https://reference.aspose.com/slides/id/cpp/aspose.slides.util/) yang mencakup kelas [SlideUtil](https://reference.aspose.com/slides/id/cpp/aspose.slides.util/slideutil/). Kelas ini menyediakan beberapa metode statis yang di‑overload untuk mengekstrak semua teks dari sebuah presentasi atau slide. Untuk mengekstrak teks dari sebuah slide dalam presentasi, gunakan metode [GetAllTextBoxes](https://reference.aspose.com/slides/id/cpp/aspose.slides.util/slideutil/getalltextboxes/). Metode ini menerima objek bertipe [IBaseSlide](https://reference.aspose.com/slides/id/cpp/aspose.slides/ibaseslide/) sebagai parameter. Ketika dijalankan, metode ini memindai seluruh slide untuk teks dan mengembalikan array objek bertipe [ITextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/), mempertahankan semua format teks.

Potongan kode berikut mengekstrak semua teks dari slide pertama presentasi:

```cpp
auto slideIndex = 0;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto textFrames = Util::SlideUtil::GetAllTextBoxes(slide);

for (const auto& textFrame : textFrames)
{
    for (const auto& paragraph : textFrame->get_Paragraphs())
    {
        for (const auto& portion : paragraph->get_Portions())
        {
            auto portionText = portion->get_Text();
            Console::WriteLine(portionText);

            auto portionFormat = portion->get_PortionFormat();
            auto fontHeight = portionFormat->get_FontHeight();
            Console::WriteLine(fontHeight);

            auto latinFont = portionFormat->get_LatinFont();
            if (latinFont != nullptr)
            {
                auto fontName = latinFont->get_FontName();
                Console::WriteLine(fontName);
            }
        }
    }
}

presentation->Dispose();
```

## **Ekstrak Teks dari Presentasi**

Untuk memindai teks dari seluruh presentasi, gunakan metode statis [GetAllTextFrames](https://reference.aspose.com/slides/id/cpp/aspose.slides.util/slideutil/getalltextframes/) yang disediakan oleh kelas [SlideUtil](https://reference.aspose.com/slides/id/cpp/aspose.slides.util/slideutil/). Metode ini menerima dua parameter:

1. Pertama, objek [IPresentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentation/) yang mewakili presentasi PowerPoint atau OpenDocument tempat teks akan diekstrak.  
2. Kedua, nilai `Boolean` yang menunjukkan apakah master slide harus disertakan saat memindai teks dari presentasi.

Metode ini mengembalikan array objek bertipe [ITextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/), termasuk informasi format teks. Kode di bawah ini memindai teks dan detail format dari sebuah presentasi, termasuk master slide.

```cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto includeMasterSlides = true;
auto textFrames = Util::SlideUtil::GetAllTextFrames(presentation, includeMasterSlides);

for (const auto& textFrame : textFrames)
{
    for (const auto& paragraph : textFrame->get_Paragraphs())
    {
        for (const auto& portion : paragraph->get_Portions())
        {
            auto portionText = portion->get_Text();
            Console::WriteLine(portionText);

            auto portionFormat = portion->get_PortionFormat();
            auto fontHeight = portionFormat->get_FontHeight();
            Console::WriteLine(fontHeight);

            auto latinFont = portionFormat->get_LatinFont();
            if (latinFont != nullptr)
            {
                auto fontName = latinFont->get_FontName();
                Console::WriteLine(fontName);
            }
        }
    }
}

presentation->Dispose();
```

## **Ekstraksi Teks Terkategorikan dan Cepat**

Kelas [PresentationFactory](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentationfactory/) juga menyediakan metode untuk mengekstrak semua teks dari presentasi:

```cpp
System::SharedPtr<IPresentationText> GetPresentationText(System::String file, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode, System::SharedPtr<ILoadOptions> options);
```

Argumen enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/id/cpp/aspose.slides/textextractionarrangingmode/) menunjukkan mode pengorganisasian hasil ekstraksi teks dan dapat disetel ke nilai berikut:
- `Unarranged` - Teks mentah tanpa memperhatikan posisinya pada slide.  
- `Arranged` - Teks diatur dalam urutan yang sama seperti pada slide.

Mode unarranged dapat digunakan ketika kecepatan sangat penting; ia lebih cepat dibandingkan mode arranged.

[IPresentationText](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentationtext/) mewakili teks mentah yang diekstrak dari presentasi. Metode `get_SlidesText()`‑nya mengembalikan array objek bertipe [ISlideText](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidetext/). Setiap objek mewakili teks pada slide yang bersangkutan. Objek bertipe [ISlideText](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidetext/) memiliki metode berikut:

- `get_Text()` - Teks dalam shape pada slide.  
- `get_MasterText()` - Teks dalam shape master slide yang terkait dengan slide ini.  
- `get_LayoutText()` - Teks dalam shape layout slide yang terkait dengan slide ini.  
- `get_NotesText()` - Teks dalam shape catatan slide yang terkait dengan slide ini.  
- `get_CommentsText()` - Teks dalam komentar yang terkait dengan slide ini.

```cpp
auto presentationPath = u"presentation.ppt";
auto arrangingMode = TextExtractionArrangingMode::Unarranged;
auto presentationText = PresentationFactory::get_Instance()->GetPresentationText(presentationPath, arrangingMode);
auto firstSlideText = presentationText->get_SlidesText()[0];

Console::WriteLine(firstSlideText->get_Text());
Console::WriteLine(firstSlideText->get_LayoutText());
Console::WriteLine(firstSlideText->get_MasterText());
Console::WriteLine(firstSlideText->get_NotesText());
Console::WriteLine(firstSlideText->get_CommentsText());
```

## **Tanya Jawab**

**Seberapa cepat Aspose.Slides memproses presentasi besar saat mengekstrak teks?**

Aspose.Slides dioptimalkan untuk kinerja tinggi dan dapat memproses bahkan [presentasi besar](/slides/id/cpp/open-presentation/), menjadikannya cocok untuk skenario pemrosesan waktu nyata atau pemrosesan massal.

**Apakah Aspose.Slides dapat mengekstrak teks dari tabel dan bagan dalam presentasi?**

Ya. Aspose.Slides dapat mengekstrak teks dari banyak elemen slide, termasuk tabel dan objek terkait bagan, sehingga Anda dapat mengakses dan menganalisis konten tekstual dalam struktur presentasi yang umum.

**Apakah saya memerlukan lisensi khusus Aspose.Slides untuk mengekstrak teks dari presentasi?**

Anda dapat mengekstrak teks menggunakan versi percobaan gratis Aspose.Slides, meskipun akan memiliki [batasan tertentu](/slides/id/cpp/licensing/), seperti pemrosesan hanya pada sejumlah slide terbatas. Untuk penggunaan tanpa batas dan menangani presentasi yang lebih besar, disarankan untuk membeli lisensi penuh.