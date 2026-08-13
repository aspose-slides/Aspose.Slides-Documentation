---
title: Sesuaikan Font PowerPoint di C++
linktitle: Font Kustom
type: docs
weight: 20
url: /id/cpp/custom-font/
keywords:
- font
- font khusus
- font eksternal
- muat font
- kelola font
- folder font
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Sesuaikan font dalam slide PowerPoint dengan Aspose.Slides untuk C++ agar presentasi Anda tetap tajam dan konsisten di semua perangkat."
---
## **Ringkasan**

Aspose.Slides memungkinkan Anda menggunakan font khusus dalam presentasi tanpa menginstalnya di sistem operasi. Anda dapat memuat font dari folder khusus, menyediakan font untuk presentasi tertentu melalui sumber font tingkat dokumen, atau memuat font eksternal langsung dari data biner.

Font yang dimuat digunakan saat presentasi dirender atau diekspor, misalnya ke PDF, gambar, dan format lain yang didukung. Ini membantu menjaga konsistensi output presentasi di berbagai lingkungan. Artikel ini juga menjelaskan cara memeriksa folder font yang digunakan oleh Aspose.Slides dan cara membersihkan cache font setelah bekerja dengan font eksternal.

Mendaftarkan font khusus untuk rendering terpisah dari proses menyematkan font ke dalam file PPTX. Jika sebuah font harus disimpan di dalam presentasi itu sendiri, gunakan fitur penyematan font secara eksplisit.

{{% alert color="info" %}} 
Aspose Slides memungkinkan Anda memuat font ini menggunakan [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* TrueType (.ttf) dan TrueType Collection (.ttc). Lihat [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf). Lihat [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Muat Font Kustom**

Aspose.Slides memungkinkan Anda memuat font yang digunakan dalam presentasi tanpa menginstalnya di sistem. Hal ini memengaruhi output ekspor—seperti PDF, gambar, dan format lain yang didukung—sehingga dokumen yang dihasilkan tampak konsisten di semua lingkungan. Font dimuat dari direktori khusus.

1. Tentukan satu atau lebih folder yang berisi file font.
2. Panggil metode statis [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsloader/loadexternalfonts/) untuk memuat font dari folder tersebut.
3. Muat dan render/ekspor presentasi.
4. Panggil [FontsLoader.clearCache](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsloader/clearcache/) untuk membersihkan cache font.

Contoh kode berikut menunjukkan proses pemuatan font:

```cpp
#include <DOM/Fonts/FontsLoader.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Tentukan folder yang berisi file font khusus.
String externalFontFolder = u"assets/fonts";
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// Muat font khusus dari folder yang ditentukan.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Render/ekspor presentasi (mis., ke PDF, gambar, atau format lain) menggunakan font yang dimuat.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// Bersihkan cache font setelah pekerjaan selesai.
FontsLoader::ClearCache();
```

{{% alert color="info" title="Note" %}}
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsloader/loadexternalfonts/) menambahkan folder tambahan ke jalur pencarian font, tetapi tidak mengubah urutan inisialisasi font.  
Font diinisialisasi dalam urutan berikut:

1. Jalur font default sistem operasi.
1. Jalur yang dimuat melalui [FontsLoader](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsloader/).

{{%/alert %}}

## **Dapatkan Folder Font Kustom**
Aspose.Slides menyediakan [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsloader/getfontfolders/) untuk memungkinkan Anda menemukan folder font. Metode ini mengembalikan folder yang ditambahkan melalui metode `LoadExternalFonts` dan folder font sistem.

Kode C++ ini menunjukkan cara menggunakan metode [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsloader/getfontfolders/):

``` cpp
#include <DOM/Fonts/FontsLoader.h>
using namespace Aspose::Slides;

// Baris ini menampilkan folder yang diperiksa untuk file font.
// Itu adalah folder yang ditambahkan melalui metode LoadExternalFonts dan folder font sistem.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **Tentukan Font Kustom yang Digunakan dengan Presentasi**
Aspose.Slides menyediakan properti [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/id/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) untuk memungkinkan Anda menentukan font eksternal yang akan digunakan dengan presentasi.

Kode C++ ini menunjukkan cara menggunakan properti [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/id/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/):

``` cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //bekerja dengan presentasi
    //CustomFont1, CustomFont2 serta font dari folder assets\fonts & global\fonts dan subfoldernya tersedia untuk presentasi
}
```

## **Kelola Font Secara Eksternal**
Aspose.Slides menyediakan metode [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsloader/loadexternalfont/) untuk memungkinkan Anda memuat font eksternal ke dalam array byte.

Kode C++ ini menunjukkan proses pemuatan font ke array byte:

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

// Jalur ke direktori dokumen
const String outPath = u"../out/SpecifyFontsUsedWithPresentation.pptx";
const String templatePath = u"../templates/AccessSlides.pptx";

ArrayPtr<String> fontsLocation =  MakeArray<System::String>({ u"assets\\fonts", u"global\\fonts" });// ;
ArrayPtr<ArrayPtr<uint8_t>> memoryfontsLocation = MakeArray < ArrayPtr<uint8_t>>({ File::ReadAllBytes(u"../templates/CustomFont1.ttf"), File::ReadAllBytes(u"../templates/CustomFont2.ttf") });

SharedPtr < Aspose::Slides::LoadOptions > loadOptions = MakeObject <Aspose::Slides::LoadOptions>();

loadOptions->get_DocumentLevelFontSources()->set_FontFolders(fontsLocation);
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(memoryfontsLocation);
	
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath, loadOptions);
```

## **FAQ**

### Apakah font khusus memengaruhi ekspor ke semua format (PDF, PNG, SVG, HTML)?

Ya. Font yang terhubung digunakan oleh renderer di semua format ekspor.

### Apakah font khusus secara otomatis disematkan ke dalam PPTX yang dihasilkan?

Tidak. Mendaftarkan font untuk rendering tidak sama dengan menyematkannya ke dalam PPTX. Jika Anda memerlukan font berada di dalam file presentasi, Anda harus menggunakan [embedding features](/slides/id/cpp/embedded-font/) secara eksplisit.

### Apakah saya dapat mengontrol perilaku fallback ketika font khusus tidak memiliki glyph tertentu?

Ya. Konfigurasikan [font substitution](/slides/id/cpp/font-substitution/), [replacement rules](/slides/id/cpp/font-replacement/), dan [fallback sets](/slides/id/cpp/fallback-font/) untuk menentukan secara tepat font mana yang digunakan ketika glyph yang diminta tidak ada.

### Apakah saya dapat menggunakan font di kontainer Linux/Docker tanpa menginstalnya secara sistem-wide?

Ya. Arahkan ke folder font Anda sendiri atau muat font dari array byte. Ini menghilangkan ketergantungan pada folder font sistem dalam image kontainer.

### Bagaimana dengan lisensi—apakah saya bisa menyematkan font khusus apa pun tanpa batasan?

Anda bertanggung jawab atas kepatuhan lisensi font. Persyaratan bervariasi; beberapa lisensi melarang penyematan atau penggunaan komersial. Selalu tinjau EULA font sebelum mendistribusikan output.