---
title: Otomatisasi Lokalisasi Presentasi dalam C++
linktitle: Lokalisasi Presentasi
type: docs
weight: 100
url: /id/cpp/presentation-localization/
keywords:
- ubah bahasa
- pemeriksaan ejaan
- menahan pemeriksaan ejaan
- bahasa proofing
- id bahasa
- teks multibahasa
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Atur bahasa proofing untuk teks presentasi PowerPoint dan OpenDocument dalam C++ dengan Aspose.Slides, termasuk nilai default dan paragraf multibahasa."
---
## **Gambaran Umum**

Aspose.Slides untuk C++ memungkinkan Anda mengonfigurasi metadata proofing untuk bagian teks individu. Gunakan [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/id/cpp/aspose.slides/ibaseportionformat/set_languageid/) untuk mengidentifikasi bahasa proofing, [BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/id/cpp/aspose.slides/baseportionformat/set_spellcheck/) untuk mengizinkan atau menekan pemeriksaan ejaan, dan [BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/id/cpp/aspose.slides/baseportionformat/set_proofdisabled/) untuk mengendalikan status tidak-proof yang lebih luas. Karena pengaturan ini diterapkan pada tingkat bagian, satu paragraf dapat berisi beberapa bahasa dan aturan proofing yang berbeda.

Artikel ini menjelaskan cara menetapkan bahasa ke teks tertentu, mengatur bahasa default untuk teks baru dengan [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/id/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/), membangun paragraf multibahasa, memilih antara `SpellCheck` dan `ProofDisabled`, serta mempertahankan pengaturan yang dimaksud saat menggunakan [Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/joinportionswithsameformatting/). Properti‑properti ini menyimpan metadata untuk aplikasi presentasi; mereka tidak menerjemahkan teks, melakukan pemeriksaan ejaan berbasis kamus, atau mengembalikan kata yang salah eja.

## **Atur Bahasa Proofing untuk Teks**

Buat atau muat sebuah [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/), akses bagian teks yang diperlukan melalui [IPortion::get_PortionFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/iportion/get_portionformat/), dan tetapkan identifier bahasa-nya. Contoh berikut membuat sebuah shape, mengatur bahasa Inggris Britania sebagai bahasa proofing, dan menyimpan hasilnya dengan [Presentation::Save](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/save/):

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Set the proofing language for this text.");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->set_LanguageId(u"en-GB");

presentation->Save(u"proofing_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Atur Bahasa Default untuk Teks Baru**

Gunakan [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/id/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) untuk menentukan bahasa proofing yang akan diberikan Aspose.Slides ke teks yang baru dibuat. Pengaturan ini berguna ketika sebagian besar atau semua teks baru dalam presentasi menggunakan bahasa yang sama. Pengaturan ini tidak mengubah metadata bahasa pada teks yang sudah memiliki bahasa eksplisit.

Contoh berikut membuat sebuah presentasi dimana teks baru menggunakan aturan proofing bahasa Jerman:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"de-DE");

auto presentation = System::MakeObject<Presentation>(loadOptions);
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Willkommen zur Präsentation");

presentation->Save(u"default_text_language.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Gunakan Beberapa Bahasa dalam Satu Paragraf**

Sebuah [IParagraph](https://reference.aspose.com/slides/id/cpp/aspose.slides/iparagraph/) berisi kumpulan bagian teks. Buat sebuah [Portion](https://reference.aspose.com/slides/id/cpp/aspose.slides/portion/) terpisah untuk setiap bahasa dan atur `LanguageId`‑nya secara independen.

Contoh ini membuat satu paragraf dengan bagian bahasa Inggris dan Prancis:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 420.0f, 80.0f);
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
paragraph->get_Portions()->Clear();

auto englishPortion = System::MakeObject<Portion>(u"Welcome");
englishPortion->get_PortionFormat()->set_LanguageId(u"en-US");
paragraph->get_Portions()->Add(englishPortion);

auto frenchPortion = System::MakeObject<Portion>(u" — Bienvenue");
frenchPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
paragraph->get_Portions()->Add(frenchPortion);

presentation->Save(u"multilingual_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Aktifkan atau Tahan Pemeriksaan Ejaan untuk Bagian Individual**

[IPortionFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/iportionformat/) mewarisi properti teks umum yang didefinisikan oleh [IBasePortionFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/ibaseportionformat/). Akses format bagian melalui [IPortion::get_PortionFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/iportion/get_portionformat/) dan panggil [BasePortionFormat::set_SpellCheck](https://reference.aspose.com/slides/id/cpp/aspose.slides/baseportionformat/set_spellcheck/) untuk mengendalikan apakah aplikasi presentasi dapat memeriksa ejaan untuk bagian tersebut. Nilai default adalah `false`: `true` mengizinkan pemeriksaan ejaan, sedangkan `false` menahannya.

Pengaturan ini berlaku untuk bagian teks individual. Karena itu, bagian yang berbeda dalam paragraf yang sama dapat menggunakan nilai yang berbeda. [BasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/id/cpp/aspose.slides/baseportionformat/set_languageid/) dan `SpellCheck` melayani tujuan komplementer: `LanguageId` mengidentifikasi bahasa proofing, sementara `SpellCheck` menentukan apakah pemeriksaan ejaan diizinkan untuk bagian tersebut.

[BasePortionFormat::set_ProofDisabled](https://reference.aspose.com/slides/id/cpp/aspose.slides/baseportionformat/set_proofdisabled/) juga mengendalikan proofing, tetapi mewakili status “jangan proof” yang lebih luas sebagai [NullableBool](https://reference.aspose.com/slides/id/cpp/aspose.slides/nullablebool/). Gunakan `SpellCheck` ketika Anda memerlukan saklar Boolean langsung khusus untuk pemeriksaan ejaan. Gunakan `ProofDisabled` ketika Anda perlu mempertahankan atau secara eksplisit mengendalikan metadata tidak‑proof presentasi, termasuk status `NullableBool::NotDefined`‑nya. Jika Anda menyetel kedua properti, jaga konsistensi nilainya; jangan menggabungkan `SpellCheck = true` dengan `ProofDisabled = NullableBool::True`.

Properti‑properti ini mengonfigurasi metadata proofing yang digunakan oleh PowerPoint dan aplikasi presentasi lainnya. Aspose.Slides tidak menggunakan mereka untuk menjalankan pemeriksaan ejaan berbasis kamus atau mengembalikan daftar kata yang salah eja.

Contoh lengkap berikut membuat presentasi input, memuatnya, menetapkan pengaturan pemeriksaan ejaan dan bahasa proofing yang berbeda ke dua bagian dalam paragraf yang sama, menyimpan hasilnya, membuka kembali, dan memverifikasi nilai yang disimpan:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const System::String inputFile = u"spell_check_input.pptx";
const System::String outputFile = u"spell_check_settings.pptx";

{
    auto sourcePresentation = System::MakeObject<Presentation>();
    auto sourceSlide = sourcePresentation->get_Slide(0);
    auto sourceShape = sourceSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 420.0f, 80.0f);
    auto sourceParagraph = sourceShape->get_TextFrame()->get_Paragraph(0);
    sourceParagraph->get_Portions()->Clear();

    auto sourceEnglishPortion = System::MakeObject<Portion>(u"Check this text. ");
    sourceEnglishPortion->get_PortionFormat()->set_LanguageId(u"en-US");
    sourceParagraph->get_Portions()->Add(sourceEnglishPortion);

    auto sourceFrenchPortion = System::MakeObject<Portion>(u"Ignorer ce code : ZX-81.");
    sourceFrenchPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
    sourceParagraph->get_Portions()->Add(sourceFrenchPortion);

    sourcePresentation->Save(inputFile, SaveFormat::Pptx);
    sourcePresentation->Dispose();
}

{
    auto presentation = System::MakeObject<Presentation>(inputFile);
    auto firstShape = presentation->get_Slide(0)->get_Shape(0);
    auto shape = System::ExplicitCast<IAutoShape>(firstShape);
    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);

    auto checkedPortion = paragraph->get_Portion(0);
    checkedPortion->get_PortionFormat()->set_LanguageId(u"en-US");
    checkedPortion->get_PortionFormat()->set_SpellCheck(true);

    auto suppressedPortion = paragraph->get_Portion(1);
    suppressedPortion->get_PortionFormat()->set_LanguageId(u"fr-FR");
    suppressedPortion->get_PortionFormat()->set_SpellCheck(false);

    presentation->Save(outputFile, SaveFormat::Pptx);
    presentation->Dispose();
}

auto reopenedPresentation = System::MakeObject<Presentation>(outputFile);
auto reopenedFirstShape = reopenedPresentation->get_Slide(0)->get_Shape(0);
auto reopenedShape = System::ExplicitCast<IAutoShape>(reopenedFirstShape);
auto storedParagraph = reopenedShape->get_TextFrame()->get_Paragraph(0);

bool portionsStored = storedParagraph->get_Portions()->get_Count() == 2;
if (portionsStored)
{
    auto firstStoredPortion = storedParagraph->get_Portion(0);
    auto secondStoredPortion = storedParagraph->get_Portion(1);

    bool firstPortionStored = firstStoredPortion->get_PortionFormat()->get_LanguageId() == u"en-US" && 
        firstStoredPortion->get_PortionFormat()->get_SpellCheck();

    bool secondPortionStored = secondStoredPortion->get_PortionFormat()->get_LanguageId() == u"fr-FR" && 
        !secondStoredPortion->get_PortionFormat()->get_SpellCheck();

    if (firstPortionStored && secondPortionStored)
    {
        System::Console::WriteLine(u"The proofing settings were stored correctly.");
    }
    else
    {
        System::Console::WriteLine(u"The proofing settings could not be verified.");
    }
}
else
{
    System::Console::WriteLine(u"The proofing settings could not be verified.");
}

reopenedPresentation->Dispose();
```

[Presentation::JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/joinportionswithsameformatting/) menggabungkan bagian bersebelahan yang memiliki format yang sama. Perbedaan pada `SpellCheck` saja tidak membuat bagian tersebut tetap terpisah; setelah digabung, bagian hasil mempertahankan nilai `SpellCheck` dari bagian pertama. Jika bagian memerlukan pengaturan pemeriksaan ejaan yang berbeda, panggil `JoinPortionsWithSameFormatting` sebelum menetapkan pengaturan tersebut, atau inspeksi batas bagian hasil dan terapkan kembali pengaturan setelahnya. Bagian dengan nilai `LanguageId` yang berbeda tetap terpisah karena format bahasa proofing mereka berbeda.

## **FAQ**

**Apakah ID bahasa menerjemahkan teks?**

Tidak. [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/id/cpp/aspose.slides/ibaseportionformat/set_languageid/) menyimpan metadata proofing untuk ejaan dan tata bahasa; ia tidak mengubah isi teks. Terjemahkan teks secara terpisah, lalu tetapkan identifier bahasa yang sesuai untuk setiap bagian yang telah diterjemahkan.

**Apakah bahasa proofing mengendalikan font, hyphenation, atau pembungkusan baris?**

Tidak. Identifier bahasa digunakan untuk proofing. Rendering teks dan tata letak terutama bergantung pada [font](/slides/id/cpp/powerpoint-fonts/) yang tersedia, sistem penulisan, dan pengaturan bingkai teks. Untuk rendering yang dapat diandalkan, sediakan font yang diperlukan, konfigurasikan [penggantian font](/slides/id/cpp/font-substitution/), atau [sematkan font](/slides/id/cpp/embedded-font/) dalam presentasi.

**Apakah satu paragraf dapat menggunakan beberapa bahasa proofing?**

Ya. Tetapkan setiap bahasa ke bagian terpisah, seperti yang ditunjukkan dalam contoh paragraf multibahasa.

**Haruskah saya menggunakan `DefaultTextLanguage` atau `LanguageId`?**

Gunakan [ILoadOptions::set_DefaultTextLanguage](https://reference.aspose.com/slides/id/cpp/aspose.slides/iloadoptions/set_defaulttextlanguage/) ketika Anda menginginkan nilai default untuk teks yang baru dibuat. Gunakan [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/id/cpp/aspose.slides/ibaseportionformat/set_languageid/) ketika sebuah bagian spesifik membutuhkan bahasa proofing eksplisit atau ketika sebuah paragraf berisi beberapa bahasa.