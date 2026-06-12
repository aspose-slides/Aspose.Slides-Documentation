---
title: "Sesuaikan Font PowerPoint di C++"
linktitle: "Font Kustom"
type: docs
weight: 20
url: /id/cpp/custom-font/
keywords:
- font
- font kustom
- font eksternal
- muat font
- kelola font
- folder font
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Sesuaikan font pada slide PowerPoint dengan Aspose.Slides untuk C++ agar presentasi Anda tetap tajam dan konsisten di semua perangkat."
---
## **Ikhtisar**

Aspose.Slides memungkinkan Anda menggunakan font kustom dalam presentasi tanpa harus menginstalnya di sistem operasi. Anda dapat memuat font dari folder kustom, menyediakan font untuk presentasi tertentu melalui sumber font tingkat dokumen, atau memuat font eksternal langsung dari data biner.

Font yang dimuat akan digunakan ketika presentasi dirender atau diekspor, misalnya ke PDF, gambar, dan format lain yang didukung. Hal ini membantu menjaga konsistensi output presentasi di berbagai lingkungan. Artikel ini juga menjelaskan cara memeriksa folder font yang digunakan oleh Aspose.Slides dan cara membersihkan cache font setelah bekerja dengan font eksternal.

Pendaftaran font kustom untuk rendering berbeda dari proses menyematkan font ke dalam file PPTX. Jika sebuah font harus disimpan di dalam presentasi itu sendiri, gunakan fitur penyematan font secara eksplisit.

{{% alert color="primary" %}} 

Aspose Slides memungkinkan Anda memuat font ini menggunakan [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* Font TrueType (.ttf) dan TrueType Collection (.ttc). Lihat [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Font OpenType (.otf). Lihat [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Muat Font Kustom**

Aspose.Slides memungkinkan Anda memuat font yang digunakan dalam presentasi tanpa menginstalnya di sistem. Hal ini memengaruhi hasil ekspor—seperti PDF, gambar, dan format lain yang didukung—sehingga dokumen yang dihasilkan terlihat konsisten di semua lingkungan. Font dimuat dari direktori kustom.

1. Tentukan satu atau beberapa folder yang berisi file font.  
2. Panggil metode statis [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsloader/loadexternalfonts/) untuk memuat font dari folder tersebut.  
3. Muat dan render/ekspor presentasi.  
4. Panggil [FontsLoader.clearCache](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsloader/clearcache/) untuk membersihkan cache font.

Contoh kode berikut memperlihatkan proses pemuatan font:

```cpp
// Tentukan folder yang berisi file font kustom.
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// Muat font kustom dari folder yang ditentukan.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Render/ekspor presentasi (mis., ke PDF, gambar, atau format lain) menggunakan font yang dimuat.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// Bersihkan cache font setelah pekerjaan selesai.
FontsLoader::ClearCache();
```

{{% alert color="info" title="Catatan" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsloader/loadexternalfonts/) menambahkan folder tambahan ke jalur pencarian font, tetapi tidak mengubah urutan inisialisasi font.  
Font diinisialisasi dengan urutan berikut:

1. Jalur font default sistem operasi.  
1. Jalur yang dimuat melalui [FontsLoader](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsloader/).

{{%/alert %}}

## **Dapatkan Folder Font Kustom**
Aspose.Slides menyediakan [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsloader/getfontfolders/) untuk memungkinkan Anda menemukan folder font. Metode ini mengembalikan folder yang ditambahkan melalui metode `LoadExternalFonts` serta folder font sistem.

Kode C++ berikut menunjukkan cara menggunakan metode [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsloader/getfontfolders/):

``` cpp
// Baris ini menghasilkan folder yang diperiksa untuk file font.
// Itu adalah folder yang ditambahkan melalui metode LoadExternalFonts dan folder font sistem.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **Tentukan Font Kustom yang Digunakan dengan Presentasi**
Aspose.Slides menyediakan properti [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/id/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) untuk memungkinkan Anda menentukan font eksternal yang akan digunakan bersama presentasi.

Kode C++ berikut menunjukkan cara menggunakan properti [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/id/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/):

``` cpp
auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //bekerja dengan presentasi
    //CustomFont1, CustomFont2 serta font dari folder assets\fonts & global\fonts serta subfoldernya tersedia untuk presentasi
}
```

## **Kelola Font Secara Eksternal**
Aspose.Slides menyediakan metode [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsloader/loadexternalfont/) untuk memungkinkan Anda memuat font eksternal ke dalam array byte.

Kode C++ berikut mendemonstrasikan proses pemuatan font ke dalam array byte:

```cpp
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

**Apakah font kustom memengaruhi ekspor ke semua format (PDF, PNG, SVG, HTML)?**

Ya. Font yang terhubung digunakan oleh renderer pada semua format ekspor.

**Apakah font kustom secara otomatis disematkan ke dalam PPTX yang dihasilkan?**

Tidak. Mendaftarkan font untuk rendering bukanlah hal yang sama dengan menyematkannya ke dalam PPTX. Jika Anda memerlukan font berada di dalam file presentasi, Anda harus menggunakan [fitur penyematan](/slides/id/cpp/embedded-font/) secara eksplisit.

**Bisakah saya mengontrol perilaku fallback ketika sebuah font kustom tidak memiliki glyph tertentu?**

Ya. Konfigurasikan [penggantian font](/slides/id/cpp/font-substitution/), [aturan penggantian](/slides/id/cpp/font-replacement/), dan [set fallback](/slides/id/cpp/fallback-font/) untuk menentukan secara tepat font mana yang digunakan ketika glyph yang diminta tidak tersedia.

**Bisakah saya menggunakan font di dalam kontainer Linux/Docker tanpa menginstalnya secara sistem?**

Ya. Arahkan ke folder font milik Anda sendiri atau muat font dari array byte. Ini menghilangkan ketergantungan pada direktori font sistem di dalam image kontainer.

**Bagaimana dengan lisensi—apakah saya dapat menyematkan font kustom apa saja tanpa batasan?**

Anda bertanggung jawab atas kepatuhan lisensi font. Persyaratan bervariasi; beberapa lisensi melarang penyematan atau penggunaan komersial. Selalu tinjau EULA font sebelum mendistribusikan hasilnya.