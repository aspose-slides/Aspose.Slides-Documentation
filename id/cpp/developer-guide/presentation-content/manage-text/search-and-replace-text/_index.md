---
title: Mencari dan Mengganti Teks dalam Presentasi PowerPoint di C++
linktitle: Mencari dan Mengganti Teks
type: docs
weight: 55
url: /id/cpp/search-and-replace-text/
keywords:
- cari teks
- sorot teks
- ganti teks
- ekspresi reguler
- callback hasil
- bingkai teks
- laporan audit
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Mencari, menyorot, dan mengganti teks dalam presentasi PowerPoint sambil mengumpulkan setiap kecocokan dengan Aspose.Slides untuk C++."
---
## **Ringkasan**

Aspose.Slides for C++ dapat mencari, menyorot, dan mengganti teks dalam satu bingkai teks atau di seluruh presentasi. Setiap operasi juga dapat memberi tahu aplikasi tentang setiap kecocokan melalui callback hasil. Hal ini memungkinkan pembaruan presentasi sekaligus membuat jejak audit yang berisi teks yang cocok, konteksnya, posisi, bingkai teks, dan nomor slide.

Kemampuan ini berguna untuk peninjauan, penyensoran, pemeriksaan terminologi, pembersihan templat, dan alur kerja pelaporan otomatis.

Pada contoh pertama di bawah ini, kami menggunakan file bernama "sample.pptx", yang berisi satu kotak teks pada slide pertama dengan teks berikut:

![Sample text](sample_text.png)

## **Pilih Lingkup Pencarian**

Gunakan metode pada [ITextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/) untuk membatasi operasi pada satu bingkai teks. Gunakan metode pada [IPresentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentation/) untuk memproses semua teks yang relevan dalam presentasi.

| Operasi | Satu bingkai teks | Seluruh presentasi |
|---|---|---|
| Menyorot teks literal | [ITextFrame::HighlightText](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/highlighttext/) | [IPresentation::HighlightText](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentation/highlighttext/) |
| Menyorot kecocokan ekspresi reguler | [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/highlightregex/) | [IPresentation::HighlightRegex](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentation/highlightregex/) |
| Mengganti teks literal | [ITextFrame::ReplaceText](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/replacetext/) | [IPresentation::ReplaceText](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentation/replacetext/) |
| Mengganti kecocokan ekspresi reguler | [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/replaceregex/) | [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentation/replaceregex/) |

## **Konfigurasikan Pencocokan Teks**

Untuk operasi teks literal, gunakan [ITextSearchOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextsearchoptions/) untuk mengontrol pencocokan:

- [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) membatasi kecocokan hanya pada kata lengkap.
- [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) mengatur apakah huruf besar/kecil harus cocok.
- [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextsearchoptions/set_includenotes/) menyertakan catatan slide dalam pencarian, penggantian, dan penyorotan tingkat presentasi.

Operasi ekspresi reguler menggunakan `System::Text::RegularExpressions::Regex`, sehingga aturan pencocokan seperti sensitivitas huruf dan batas kata didefinisikan oleh ekspresi dan opsinya.

## **Identifikasi Pemilik Bingkai Teks**

Alur kerja pemrosesan teks generik sering menerima sebuah [ITextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/) saat mencari, mengganti, memvalidasi, atau mengekspor teks. Gunakan [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/get_parentshape/) dan [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/get_parentcell/) untuk menentukan objek presentasi mana yang memiliki bingkai teks tersebut.

Nilai yang diharapkan tergantung pada pemiliknya:

| Pemilik bingkai teks | `get_ParentShape` | `get_ParentCell` |
|---|---|---|
| Sebuah AutoShape atau bentuk lain yang berisi teks | [IShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/) yang memiliki | `nullptr` |
| Sebuah sel tabel | `nullptr` | [ICell](https://reference.aspose.com/slides/id/cpp/aspose.slides/icell/) yang memiliki |

Kedua metode menyediakan navigasi read‑only. Memanggilnya tidak memindahkan bingkai teks atau mengubah pemiliknya. Kode generik harus memeriksa kedua nilai untuk `nullptr` dan menangani kemungkinan bahwa tidak ada pemilik yang tersedia.

Contoh berikut menggunakan [SlideUtil::GetAllTextFrames](https://reference.aspose.com/slides/id/cpp/aspose.slides.util/slideutil/getalltextframes/) untuk iterasi melalui semua bingkai teks dalam sebuah presentasi. Untuk bentuk, contoh melaporkan nama bentuk, tipe runtime C++, dan slide yang memuatnya. Untuk sel tabel, contoh melaporkan koordinat kolom dan baris berbasis nol serta slide yang memuatnya.

```cpp
#include <DOM/IBaseSlide.h>
#include <DOM/INotesSlide.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <Util/SlideUtil.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using Aspose::Slides::IBaseSlide;
using Aspose::Slides::INotesSlide;
using Aspose::Slides::IShape;
using Aspose::Slides::ISlide;
using Aspose::Slides::ITextFrame;
using Aspose::Slides::Presentation;
using Aspose::Slides::Util::SlideUtil;
using System::AsCast;
using System::Console;
using System::MakeObject;
using System::String;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto textFrames = SlideUtil::GetAllTextFrames(presentation, false);

for (const auto& textFrame : textFrames)
{
    auto ownerShape = textFrame->get_ParentShape();
    if (ownerShape != nullptr)
    {
        auto shapeName = String::IsNullOrEmpty(ownerShape->get_Name()) ? u"(unnamed)" : ownerShape->get_Name();
        auto shapeType = ownerShape->GetType().get_Name();
        auto baseSlide = ownerShape->get_Slide();
        String slideLabel;
        auto slide = AsCast<ISlide>(baseSlide);

        if (slide != nullptr)
        {
            slideLabel = String::Format(u"slide {0}", slide->get_SlideNumber());
        }
        else
        {
            auto notesSlide = AsCast<INotesSlide>(baseSlide);
            if (notesSlide != nullptr)
            {
                slideLabel = String::Format(u"notes for slide {0}", notesSlide->get_ParentSlide()->get_SlideNumber());
            }
            else
            {
                slideLabel = baseSlide->GetType().get_Name();
            }
        }

        Console::WriteLine(u"Shape: {0}; type: {1}; {2}", shapeName, shapeType, slideLabel);
        continue;
    }

    auto ownerCell = textFrame->get_ParentCell();
    if (ownerCell != nullptr)
    {
        auto baseSlide = ownerCell->get_Slide();
        String slideLabel;
        auto slide = AsCast<ISlide>(baseSlide);

        if (slide != nullptr)
        {
            slideLabel = String::Format(u"slide {0}", slide->get_SlideNumber());
        }
        else
        {
            auto notesSlide = AsCast<INotesSlide>(baseSlide);
            if (notesSlide != nullptr)
            {
                slideLabel = String::Format(u"notes for slide {0}", notesSlide->get_ParentSlide()->get_SlideNumber());
            }
            else
            {
                slideLabel = baseSlide->GetType().get_Name();
            }
        }

        Console::WriteLine(u"Table cell: column {0}, row {1}; {2}", ownerCell->get_FirstColumnIndex(), ownerCell->get_FirstRowIndex(), slideLabel);
        continue;
    }

    Console::WriteLine(u"The text frame owner is not available as a shape or table cell.");
}
```

Untuk konten SmartArt, iterasi melalui bentuk‑bentuk dalam [ISmartArtNode::get_Shapes](https://reference.aspose.com/slides/id/cpp/aspose.slides.smartart/ismartartnode/get_shapes/) dan akses setiap [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides.smartart/ismartartshape/get_textframe/). Bingkai teks dapat ditelusuri ke bentuk terkait melalui [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/get_parentshape/), sementara [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/get_parentcell/) mengembalikan `nullptr`. Oleh karena itu, cabang bentuk dalam contoh juga menangani teks dari node SmartArt.

## **Kumpulkan Informasi Kecocokan dengan Callback**

Implementasikan [IFindResultCallback](https://reference.aspose.com/slides/id/cpp/aspose.slides/ifindresultcallback/) untuk menerima notifikasi pada setiap kecocokan. Metode [IFindResultCallback::FoundResult](https://reference.aspose.com/slides/id/cpp/aspose.slides/ifindresultcallback/foundresult/) menyediakan bingkai teks terkait, teks sumber, teks yang cocok, dan posisi kecocokan.

Callback tidak menerima nomor slide secara langsung. Implementasi di bawah menurunkannya dari [ISlideComponent::get_Slide](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidecomponent/get_slide/) dan juga menangani teks yang ditemukan di catatan slide melalui [INotesSlide::get_ParentSlide](https://reference.aspose.com/slides/id/cpp/aspose.slides/inotesslide/get_parentslide/). Nomor slide yang dapat bernilai null memungkinkan model hasil yang sama merepresentasikan teks yang terkait dengan tipe slide lain.

```cpp
#include <DOM/IBaseSlide.h>
#include <DOM/INotesSlide.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Table/ICell.h>
#include <IFindResultCallback.h>
#include <system/collections/list.h>
#include <system/nullable.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using Aspose::Slides::IBaseSlide;
using Aspose::Slides::IFindResultCallback;
using Aspose::Slides::INotesSlide;
using Aspose::Slides::IShape;
using Aspose::Slides::ISlide;
using Aspose::Slides::ITextFrame;
using System::AsCast;
using System::MakeObject;
using System::Nullable;
using System::SharedPtr;
using System::String;
using System::Collections::Generic::List;

class TextMatch : public System::Object
{
public:
    TextMatch(SharedPtr<ITextFrame> textFrame, String sourceText, String foundText,
        int32_t textPosition, Nullable<int32_t> slideNumber)
        : TextFrame(textFrame), SourceText(sourceText), FoundText(foundText),
          TextPosition(textPosition), SlideNumber(slideNumber)
    {
    }

    SharedPtr<ITextFrame> TextFrame;
    String SourceText;
    String FoundText;
    int32_t TextPosition;
    Nullable<int32_t> SlideNumber;
};

class TextSearchCallback : public IFindResultCallback
{
public:
    TextSearchCallback()
        : Results(MakeObject<List<SharedPtr<TextMatch>>>())
    {
    }

    void FoundResult(SharedPtr<ITextFrame> textFrame, String sourceText,
        String foundText, int32_t textPosition) override
    {
        auto slideNumber = GetSlideNumber(textFrame);
        auto result = MakeObject<TextMatch>(textFrame, sourceText, foundText,
            textPosition, slideNumber);

        Results->Add(result);
    }

    SharedPtr<List<SharedPtr<TextMatch>>> Results;

private:
    static Nullable<int32_t> GetSlideNumber(SharedPtr<ITextFrame> textFrame)
    {
        auto parentShape = textFrame->get_ParentShape();
        auto parentCell = textFrame->get_ParentCell();
        SharedPtr<IBaseSlide> baseSlide;

        if (parentShape != nullptr)
        {
            baseSlide = parentShape->get_Slide();
        }
        else if (parentCell != nullptr)
        {
            baseSlide = parentCell->get_Slide();
        }
        else
        {
            baseSlide = textFrame->get_Slide();
        }

        auto slide = AsCast<ISlide>(baseSlide);

        if (slide != nullptr)
        {
            return slide->get_SlideNumber();
        }

        auto notesSlide = AsCast<INotesSlide>(baseSlide);
        if (notesSlide != nullptr)
        {
            auto parentSlide = notesSlide->get_ParentSlide();
            return parentSlide->get_SlideNumber();
        }

        return nullptr;
    }
};
```

Untuk operasi penggantian, `FoundText` berisi teks asli yang cocok, sehingga callback dapat mencatat tepat istilah mana yang diganti.

## **Sorot Teks**

Gunakan metode [ITextFrame::HighlightText](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/highlighttext/) untuk menyorot kecocokan teks literal dalam sebuah bingkai teks. Kirimkan [ITextSearchOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextsearchoptions/) untuk mengontrol pencarian dan sebuah callback untuk mengumpulkan detail kecocokan.

Contoh kode di bawah menyorot semua kemunculan karakter **"try"** dan kemudian hanya menyorot kata lengkap **"to"**. Kedua pencarian melaporkan kecocokannya ke callback yang sama.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using Aspose::Slides::IAutoShape;
using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Dapatkan bentuk pertama dari slide pertama.
auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();

auto substringSearchOptions = MakeObject<TextSearchOptions>();
substringSearchOptions->set_CaseSensitive(false);

// Highlight every occurrence of "try" in the text frame.
shape->get_TextFrame()->HighlightText(
    u"try", System::Drawing::Color::get_LightBlue(), substringSearchOptions, callback);

auto wholeWordSearchOptions = MakeObject<TextSearchOptions>();
wholeWordSearchOptions->set_WholeWordsOnly(true);
wholeWordSearchOptions->set_CaseSensitive(false);

// Highlight only the complete word "to".
shape->get_TextFrame()->HighlightText(
    u"to", System::Drawing::Color::get_Violet(), wholeWordSearchOptions, callback);

for (auto&& result : callback->Results)
{
    auto slideLabel = result->SlideNumber.get_HasValue()
        ? System::String::Format(u"{0}", result->SlideNumber.get_Value())
        : u"Other";

    System::Console::WriteLine(u"Found '{0}' at position {1} on slide {2}.",
        result->FoundText, result->TextPosition, slideLabel);
}

presentation->Save(u"highlighted_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Hasilnya:

![The highlighted text](highlighted_text.png)

## **Sorot Teks Menggunakan Ekspresi Reguler**

Metode [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/highlightregex/) menyorot kecocokan teks yang ditemukan oleh ekspresi reguler dalam sebuah bingkai teks.

Kode berikut menyorot semua kata yang berisi tujuh karakter atau lebih dan mengumpulkan tiap kecocokan:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>

using Aspose::Slides::IAutoShape;
using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SaveFormat;
using System::ExplicitCast;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();
auto regex = MakeObject<Regex>(u"\\b[^\\s]{7,}\\b");

shape->get_TextFrame()->HighlightRegex(
    regex, System::Drawing::Color::get_Yellow(), callback);

presentation->Save(u"highlighted_text_using_regex.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Hasilnya:

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **Sorot Teks di Seluruh Presentasi**

Gunakan [IPresentation::HighlightText](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentation/highlighttext/) dan [IPresentation::HighlightRegex](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentation/highlightregex/) untuk mencari semua bingkai teks yang relevan dalam sebuah presentasi. Contoh berikut menyorot istilah literal dan semua alamat email sambil mempertahankan koleksi hasil terpisah untuk kedua pencarian.

```cpp
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>
#include <system/text/regularexpressions/regex_options.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;
using System::Text::RegularExpressions::RegexOptions;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto termCallback = MakeObject<TextSearchCallback>();
auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(false);

presentation->HighlightText(
    u"confidential", System::Drawing::Color::get_Orange(), searchOptions, termCallback);

auto emailCallback = MakeObject<TextSearchCallback>();
auto emailRegex = MakeObject<Regex>(
    u"\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b", RegexOptions::IgnoreCase);

presentation->HighlightRegex(
    emailRegex, System::Drawing::Color::get_Yellow(), emailCallback);

presentation->Save(u"highlighted_presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ganti Teks dalam Bingkai Teks**

Gunakan [ITextFrame::ReplaceText](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/replacetext/) untuk teks literal dan [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/replaceregex/) untuk penggantian berbasis pola. Metode‑metode ini memperbarui teks yang cocok di dalam bingkai teks yang ada, sehingga format bagian sekitar tetap dipertahankan alih‑alih membangun ulang bingkai teks dari string polos.

Contoh berikut menstandarkan varian ejaan dan kemudian mengganti label versi. Callback yang sama mencatat istilah asli yang cocok oleh kedua operasi.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>
#include <system/text/regularexpressions/regex_options.h>

using Aspose::Slides::IAutoShape;
using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::ExplicitCast;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;
using System::Text::RegularExpressions::RegexOptions;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto shape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));
auto callback = MakeObject<TextSearchCallback>();
auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(false);

shape->get_TextFrame()->ReplaceText(u"colour", u"color", searchOptions, callback);

auto versionRegex = MakeObject<Regex>(
    u"\\bv\\d+(?:\\.\\d+)*\\b", RegexOptions::IgnoreCase);
shape->get_TextFrame()->ReplaceRegex(versionRegex, u"current version", callback);

presentation->Save(u"updated_text_frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Jika satu kecocokan meliputi bagian dengan format berbeda, tinjau output untuk memastikan format mana yang harus diterapkan pada teks pengganti.

## **Ganti Teks di Seluruh Presentasi**

Gunakan [IPresentation::ReplaceText](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentation/replacetext/) dan [IPresentation::ReplaceRegex](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentation/replaceregex/) untuk menerapkan operasi yang sama di seluruh presentasi. Ini berguna untuk pembersihan templat, pembaruan terminologi, dan penyensoran.

```cpp
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/text/regularexpressions/regex.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::TextSearchOptions;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::Text::RegularExpressions::Regex;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto callback = MakeObject<TextSearchCallback>();
auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(true);

presentation->ReplaceText(u"Contoso", u"Example Corp", searchOptions, callback);

auto accountNumberRegex = MakeObject<Regex>(u"\\bACCT-\\d{6}\\b");
presentation->ReplaceRegex(accountNumberRegex, u"ACCT-REDACTED", callback);

presentation->Save(u"updated_presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Kelompokkan Kecocokan untuk Pelaporan**

Karena setiap hasil menyimpan nomor slide dan bingkai teks, aplikasi dapat mengelompokkan kecocokan untuk audit, pelaporan, atau alur kerja peninjauan. Contoh berikut mengelompokkan hasil yang dikumpulkan pertama berdasarkan slide lalu berdasarkan bingkai teks:

```cpp
#include <DOM/ITextFrame.h>
#include <system/console.h>
#include <system/string.h>
#include <map>
#include <vector>

std::map<int32_t, std::map<Aspose::Slides::ITextFrame*,
    std::vector<System::SharedPtr<TextMatch>>>> matchesBySlide;

for (auto&& result : callback->Results)
{
    int32_t slideKey = result->SlideNumber.get_HasValue()
        ? result->SlideNumber.get_Value()
        : 0;
    auto textFrameKey = result->TextFrame.get();

    matchesBySlide[slideKey][textFrameKey].push_back(result);
}

for (const auto& slideGroup : matchesBySlide)
{
    auto slideLabel = slideGroup.first == 0
        ? System::String(u"Other")
        : System::String::Format(u"{0}", slideGroup.first);
    System::Console::WriteLine(u"Slide: {0}", slideLabel);

    for (const auto& textFrameGroup : slideGroup.second)
    {
        auto textFrameText = textFrameGroup.first->get_Text();
        System::Console::WriteLine(u"  Text frame: {0}", textFrameText);

        for (const auto& result : textFrameGroup.second)
        {
            System::Console::WriteLine(
                u"    '{0}' at position {1}; context: '{2}'",
                result->FoundText, result->TextPosition, result->SourceText);
        }
    }
}
```

## **FAQ**

**Bagaimana cara mencari hanya satu kotak teks alih‑alih seluruh presentasi?**

Dapatkan bingkai teks dari bentuk dan panggil [ITextFrame::HighlightText](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/highlighttext/), [ITextFrame::HighlightRegex](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/highlightregex/), [ITextFrame::ReplaceText](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/replacetext/), atau [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/replaceregex/) pada bingkai teks tersebut. Metode tingkat presentasi memproses semua bingkai teks yang relevan.

**Bagaimana cara mencocokkan kata lengkap dengan kapitalisasi yang tepat?**

Panggil [ITextSearchOptions::set_WholeWordsOnly](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextsearchoptions/set_wholewordsonly/) dan [ITextSearchOptions::set_CaseSensitive](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextsearchoptions/set_casesensitive/) dengan `true`, lalu kirimkan opsi tersebut ke metode penyorotan atau penggantian teks literal. Untuk ekspresi reguler, definisikan batas kata dan sensitivitas huruf dalam `System::Text::RegularExpressions::Regex` itu sendiri.

**Apakah pencarian dan penggantian dapat menyertakan teks dalam catatan slide?**

Ya. Panggil [ITextSearchOptions::set_IncludeNotes](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextsearchoptions/set_includenotes/) dengan `true` ketika menggunakan operasi teks literal tingkat presentasi. Implementasi callback yang ditunjukkan di atas memetakan kecocokan di catatan slide kembali ke nomor slide induknya.

**Bagaimana cara membuat laporan tanpa memindai presentasi lagi?**

Kirimkan implementasi [IFindResultCallback](https://reference.aspose.com/slides/id/cpp/aspose.slides/ifindresultcallback/) ke operasi penyorotan atau penggantian. Callback menerima setiap kecocokan selama operasi berjalan, sehingga aplikasi dapat menyimpan teks sumber, teks yang cocok, posisi, bingkai teks, dan nomor slide yang diturunkan untuk pengelompokan atau ekspor nanti.

**Apakah penggantian teks mempertahankan formatnya?**

[ITextFrame::ReplaceText](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/replacetext/) dan [ITextFrame::ReplaceRegex](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframe/replaceregex/) mengubah teks yang cocok di dalam bingkai teks yang ada dan mempertahankan format bagian sekitarnya. Jika satu kecocokan meliputi bagian dengan format berbeda, periksa hasilnya untuk memastikan pengganti menggunakan gaya yang diinginkan.