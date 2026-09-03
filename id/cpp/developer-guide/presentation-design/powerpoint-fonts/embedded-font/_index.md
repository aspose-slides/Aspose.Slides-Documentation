---
title: Menyematkan Font dalam Presentasi di C++
linktitle: Font Tertanam
type: docs
weight: 40
url: /id/cpp/embedded-font/
keywords:
- menambah font
- menyematkan font
- penyematan font
- mengambil font yang disematkan
- menambah font yang disematkan
- menghapus font yang disematkan
- mengompres font yang disematkan
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Kelola font yang disematkan di PowerPoint dengan Aspose.Slides untuk C++. Tambahkan, ambil, hapus, dan kompres font untuk mempertahankan tampilan teks dan mengurangi ukuran file."
---
## **Pendahuluan**

Menyematkan font menyimpan data font di dalam presentasi PowerPoint. Ketika penampil mendukung font yang disematkan, ia dapat menampilkan teks menggunakan font tersebut meskipun tidak terpasang di sistem target. Ini membantu mempertahankan jeda baris, spasi teks, dan tata letak slide.

Aspose.Slides for C++ memungkinkan Anda mengambil, menambah, dan menghapus font yang disematkan melalui metode [Presentation::get_FontsManager](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_fontsmanager/) dari sebuah [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/). Anda juga dapat mengurangi ukuran data font yang disematkan dengan menghapus karakter yang tidak digunakan oleh presentasi.

Contoh berikut bekerja dengan file PPTX. Sebelum menyematkan sebuah font, pastikan data fontnya tersedia untuk Aspose.Slides dan lisensinya mengizinkan penyematan.

## **Mengambil dan Menghapus Font yang Disematkan**

Gunakan [IFontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/id/cpp/aspose.slides/ifontsmanager/getembeddedfonts/) untuk membuat daftar font yang disimpan dalam sebuah presentasi. Untuk menghapus satu, berikan sebuah font dari daftar tersebut ke [IFontsManager::RemoveEmbeddedFont](https://reference.aspose.com/slides/id/cpp/aspose.slides/ifontsmanager/removeembeddedfont/), lalu simpan presentasinya.

Contoh berikut menampilkan daftar font yang disematkan dalam `EmbeddedFonts.pptx` dan menghapus Calibri jika ada:
```cpp
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"EmbeddedFonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto embeddedFonts = fontsManager->GetEmbeddedFonts();
SharedPtr<IFontData> fontToRemove;

for (auto&& font : embeddedFonts)
{
    Console::WriteLine(font->get_FontName());

    if (String::Equals(font->get_FontName(), u"Calibri", StringComparison::OrdinalIgnoreCase))
    {
        fontToRemove = font;
    }
}

if (fontToRemove != nullptr)
{
    fontsManager->RemoveEmbeddedFont(fontToRemove);
    presentation->Save(u"WithoutEmbeddedCalibri.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Calibri is not embedded. No output file was created.");
}

presentation->Dispose();
```

Menghapus font yang disematkan menghapus data font yang disimpan; ini tidak mengubah font yang ditetapkan pada teks. Jika font tersebut terpasang di sistem target, teks masih dapat menggunakannya. Jika tidak, rendering mungkin memerlukan [substitusi font](/slides/id/cpp/font-substitution/), yang dapat memengaruhi tata letak.

## **Memeriksa Data Font dan Izin Penyematan**

Gunakan antarmuka [IFontsManager](https://reference.aspose.com/slides/id/cpp/aspose.slides/ifontsmanager/) untuk memeriksa font sebelum menyematkannya. Panggil [IFontsManager::GetFonts](https://reference.aspose.com/slides/id/cpp/aspose.slides/ifontsmanager/getfonts/) untuk mengambil font yang digunakan dalam presentasi. Untuk setiap font, berikan sebuah objek [IFontData](https://reference.aspose.com/slides/id/cpp/aspose.slides/ifontdata/) dan nilai [FontStyleType](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontstyletype/) yang diperlukan ke [IFontsManager::GetFontBytes](https://reference.aspose.com/slides/id/cpp/aspose.slides/ifontsmanager/getfontbytes/). Metode ini mengembalikan data biner untuk gaya font tersebut, atau `nullptr` bila font atau gaya yang diminta tidak tersedia. Jangan berikan hasil `nullptr` ke [IFontsManager::GetFontEmbeddingLevel](https://reference.aspose.com/slides/id/cpp/aspose.slides/ifontsmanager/getfontembeddinglevel/), karena metode itu memerlukan array byte.

[EmbeddingLevel](https://reference.aspose.com/slides/id/cpp/aspose.slides/embeddinglevel/) adalah enumerasi flag yang melaporkan pembatasan penyematan yang disimpan dalam font:

- `Installable` mengizinkan penyematan dan instalasi permanen pada sistem lain, sesuai dengan lisensi font.
- `Restricted` melarang penyematan kecuali izin diperoleh dari pemilik hukum font ketika itu satu-satunya flag izin penggunaan.
- `PreviewPrint` mengizinkan penggunaan sementara untuk melihat dan mencetak; dokumen yang berisi font harus bersifat baca-saja.
- `Editable` mengizinkan penggunaan sementara dan memungkinkan dokumen diedit serta disimpan.
- `NoSubsetting` adalah pembatasan tambahan yang melarang penyematan hanya sebagian glyph. Sematkan semua karakter ketika flag ini ada.
- `BitmapOnly` adalah pembatasan tambahan yang hanya mengizinkan bitmap strikes disematkan, bukan data outline. Jika font tidak memiliki bitmap strikes, font tidak dapat disematkan.

Empat nilai pertama menggambarkan izin penggunaan, sementara `NoSubsetting` dan `BitmapOnly` dapat digabungkan dengan mereka. Periksa modifier dengan operasi bitwise. Karena `Installable` bernilai nol, mask bit izin penggunaan dan bandingkan hasilnya dengan `Installable`. Font saat ini seharusnya hanya mengatur satu bit izin penggunaan paling banyak. Untuk kompatibilitas dengan font lama yang mengatur lebih dari satu, pembantu di bawah ini memilih izin yang paling tidak membatasi: `Editable`, kemudian `PreviewPrint`, kemudian `Restricted`.

Contoh berikut mengaudit data reguler, tebal, miring, dan tebal‑miring yang tersedia untuk setiap font yang dikembalikan oleh `GetFonts`. Ia melewati gaya yang tidak tersedia, font yang dibatasi, font bitmap‑only, font yang terbatas pada preview dan print karena output tetap dapat diedit, dan font yang sudah disematkan. Jika ada gaya yang tersedia dengan `NoSubsetting`, ia menyematkan semua karakter untuk keluarga font tersebut.
```cpp
#include <DOM/EmbeddingLevel.h>
#include <DOM/FontStyleType.h>
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/EmbedFontCharacters.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/collections/list.h>
#include <system/collections/sorted_set.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;

auto getUsagePermission = [](EmbeddingLevel level)
{
    const auto permissionMask = EmbeddingLevel::Restricted | EmbeddingLevel::PreviewPrint | EmbeddingLevel::Editable;
    auto permissions = level & permissionMask;

    if ((permissions & EmbeddingLevel::Editable) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::Editable;
    }

    if ((permissions & EmbeddingLevel::PreviewPrint) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::PreviewPrint;
    }

    if ((permissions & EmbeddingLevel::Restricted) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::Restricted;
    }

    return EmbeddingLevel::Installable;
};

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto fontStyles = MakeArray<FontStyleType>({
    FontStyleType::Regular,
    FontStyleType::Bold,
    FontStyleType::Italic,
    FontStyleType::Bold | FontStyleType::Italic
});
auto fontStyleNames = MakeArray<String>({u"regular", u"bold", u"italic", u"bold-italic"});

auto embeddedFontNames = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());
for (auto&& embeddedFont : fontsManager->GetEmbeddedFonts())
{
    embeddedFontNames->Add(embeddedFont->get_FontName());
}

auto fontsToEmbedAll = MakeObject<List<SharedPtr<IFontData>>>();
auto fontsToEmbedUsedOnly = MakeObject<List<SharedPtr<IFontData>>>();
for (auto&& font : fontsManager->GetFonts())
{
    if (embeddedFontNames->Contains(font->get_FontName()))
    {
        Console::WriteLine(u"{0}: already embedded.", font->get_FontName());
        continue;
    }

    auto hasAvailableData = false;
    auto allAvailableStylesCanBeEmbedded = true;
    auto previewPrintOnly = false;
    auto requiresFullFont = false;

    for (auto styleIndex = 0; styleIndex < fontStyles->get_Length(); styleIndex++)
    {
        auto fontStyle = fontStyles[styleIndex];
        auto fontBytes = fontsManager->GetFontBytes(font, fontStyle);
        if (fontBytes == nullptr)
        {
            Console::WriteLine(u"{0} ({1}): font data is unavailable.", font->get_FontName(), fontStyleNames[styleIndex]);
            continue;
        }

        hasAvailableData = true;
        auto embeddingLevel = fontsManager->GetFontEmbeddingLevel(fontBytes, font->get_FontName());
        auto usagePermission = getUsagePermission(embeddingLevel);
        auto noSubsetting = (embeddingLevel & EmbeddingLevel::NoSubsetting) != EmbeddingLevel::Installable;
        auto bitmapOnly = (embeddingLevel & EmbeddingLevel::BitmapOnly) != EmbeddingLevel::Installable;

        requiresFullFont |= noSubsetting;
        previewPrintOnly |= usagePermission == EmbeddingLevel::PreviewPrint;
        allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel::Restricted && !bitmapOnly;

        Console::WriteLine(u"{0} ({1}): embedding level {2}.", font->get_FontName(), fontStyleNames[styleIndex], static_cast<uint16_t>(embeddingLevel));
    }

    if (!hasAvailableData)
    {
        Console::WriteLine(u"{0}: skipped because no requested style is available.", font->get_FontName());
    }
    else if (!allAvailableStylesCanBeEmbedded)
    {
        Console::WriteLine(u"{0}: skipped because at least one available style does not permit outline embedding.", font->get_FontName());
    }
    else if (previewPrintOnly)
    {
        Console::WriteLine(u"{0}: skipped because this example produces an editable presentation.", font->get_FontName());
    }
    else if (requiresFullFont)
    {
        fontsToEmbedAll->Add(font);
    }
    else
    {
        fontsToEmbedUsedOnly->Add(font);
    }
}

for (auto&& font : fontsToEmbedAll)
{
    fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::All);
}

for (auto&& font : fontsToEmbedUsedOnly)
{
    fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::OnlyUsed);
}

presentation->Save(u"WithAuditedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Pemeriksaan ini melaporkan pembatasan yang dikodekan dalam setiap file font. Ini tidak memberikan lisensi, membuktikan bahwa Anda memperoleh font secara legal, atau menggantikan pemeriksaan perjanjian lisensi font sebelum mendistribusikan salinan yang disematkan.

## **Menambahkan Font yang Disematkan**

Gunakan [IFontsManager::AddEmbeddedFont](https://reference.aspose.com/slides/id/cpp/aspose.slides/ifontsmanager/addembeddedfont/) untuk menyematkan sebuah font. Overload‑nya menerima baik objek [IFontData](https://reference.aspose.com/slides/id/cpp/aspose.slides/ifontdata/) atau array byte yang berisi data font. Enumerasi [EmbedFontCharacters](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/embedfontcharacters/) mengontrol karakter mana yang disertakan:

- [All](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/embedfontcharacters/) menyematkan semua karakter dalam font. Gunakan opsi ini ketika penerima perlu mengedit presentasi dan memasukkan teks baru.
- [OnlyUsed](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/embedfontcharacters/) hanya menyematkan karakter yang digunakan dalam presentasi untuk mengurangi ukuran file. Pilih opsi ini untuk presentasi selesai yang terutama dimaksudkan untuk dilihat.

Contoh berikut menggunakan [IFontsManager::GetFonts](https://reference.aspose.com/slides/id/cpp/aspose.slides/ifontsmanager/getfonts/) untuk mengambil font yang digunakan dalam `Fonts.pptx` dan menyematkan font yang belum disematkan. Font yang akan ditambahkan harus tersedia pada mesin yang menjalankan kode. Font yang sudah disematkan mempertahankan set karakter saat ini.
```cpp
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/EmbedFontCharacters.h>
#include <Export/SaveFormat.h>
#include <system/collections/sorted_set.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto allFonts = fontsManager->GetFonts();
auto embeddedFonts = fontsManager->GetEmbeddedFonts();
auto embeddedFontNames = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());

for (auto&& embeddedFont : embeddedFonts)
{
    embeddedFontNames->Add(embeddedFont->get_FontName());
}

for (auto&& font : allFonts)
{
    if (!embeddedFontNames->Contains(font->get_FontName()))
    {
        fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::All);
        embeddedFontNames->Add(font->get_FontName());
    }
}

presentation->Save(u"WithEmbeddedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Mengompres Font yang Disematkan**

[Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/id/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) mengurangi data font yang disematkan dengan menghapus karakter yang tidak terpakai. Ia beroperasi pada font yang sudah disematkan, sehingga pengurangan ukuran bergantung pada berapa banyak data font yang tidak terpakai yang ada dalam presentasi.

Contoh berikut mengompres font dalam `EmbeddedFonts.pptx` dan menyimpan hasilnya sebagai file terpisah:
```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;
using namespace System;

auto presentation = MakeObject<Presentation>(u"EmbeddedFonts.pptx");
Compress::CompressEmbeddedFonts(presentation);
presentation->Save(u"CompressedEmbeddedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Simpan file asli jika penerima mungkin perlu menambahkan teks nanti. Karakter yang dihapus selama kompresi tidak lagi tersedia dari font yang disematkan, bahkan jika Anda awalnya menyematkan semua karakter.

## **FAQ**

**Bagaimana saya dapat memeriksa apakah font yang disematkan masih akan disubstitusi selama rendering?**

Panggil [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/id/cpp/aspose.slides/ifontsmanager/getsubstitutions/) di lingkungan tempat Anda merender presentasi untuk melihat font mana yang akan diganti oleh Aspose.Slides. Juga periksa pengaturan [substitusi font](/slides/id/cpp/font-substitution/) dan aturan [font fallback](/slides/id/cpp/fallback-font/). Fallback menangani karakter yang hilang, sehingga menyematkan font tidak menyelesaikan karakter yang tidak terdapat dalam font itu sendiri.

**Apakah saya harus menyematkan font umum seperti Arial dan Calibri?**

Dasarkan keputusan pada lingkungan target. Jika font yang diperlukan tersedia di setiap mesin yang membuka atau merender presentasi, menyematkannya dapat menambah ukuran file yang tidak perlu. Jika penerima atau server mungkin tidak memiliki font tersebut, menyematkannya dapat membantu mempertahankan tampilan yang diinginkan, asalkan lisensinya mengizinkannya.