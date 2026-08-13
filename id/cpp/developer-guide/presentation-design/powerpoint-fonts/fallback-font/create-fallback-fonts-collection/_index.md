---
title: Konfigurasikan Kumpulan Font Fallback di C++
linktitle: Koleksi Font Fallback
type: docs
weight: 20
url: /id/cpp/create-fallback-fonts-collection/
keywords:
- font fallback
- aturan fallback
- kumpulan font
- konfigurasi font
- menyiapkan font
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Siapkan kumpulan font fallback di Aspose.Slides untuk C++ agar teks tetap konsisten dan tajam dalam presentasi PowerPoint dan OpenDocument."
---
## **Ikhtisar**

Aspose.Slides memungkinkan Anda mengonfigurasi kumpulan aturan font fallback untuk sebuah presentasi. Setiap aturan fallback diwakili oleh kelas `FontFallBackRule` dan dapat ditambahkan ke `FontFallBackRulesCollection`, yang mengimplementasikan antarmuka `IFontFallBackRulesCollection`.

Setelah membuat kumpulan, Anda dapat menugaskannya menggunakan metode `set_FontFallBackRulesCollection` dari `FontsManager` presentasi. `FontsManager` mengontrol font di seluruh presentasi, dan setiap instance `Presentation` memiliki `FontsManager`nya masing‑masing.

Setelah `FontsManager` diinisialisasi dengan kumpulan font fallback, font fallback yang ditentukan akan diterapkan selama proses rendering presentasi.

## **Terapkan Aturan Fallback**

Instansi kelas [FontFallBackRule](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontfallbackrule/) dapat diatur ke dalam [FontFallBackRulesCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontfallbackrulescollection/), yang mengimplementasikan antarmuka [IFontFallBackRulesCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/ifontfallbackrulescollection/). Anda dapat menambah atau menghapus aturan dari kumpulan tersebut.

Kemudian kumpulan ini dapat dilewatkan ke metode [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) dari kelas [FontsManager](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsmanager/). `FontsManager` mengontrol font di seluruh presentasi.

Setiap [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) memiliki metode [get_FontsManager()](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_fontsmanager/) dengan instance `FontsManager` miliknya sendiri.

Berikut contoh cara membuat koleksi aturan font fallback dan menugaskannya ke `FontsManager` dari sebuah presentasi tertentu:  

``` cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <DOM/Fonts/FontFallBackRulesCollection.h>
#include <DOM/IFontFallBackRule.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

Setelah `FontsManager` diinisialisasi dengan kumpulan font fallback, font fallback diterapkan selama proses rendering presentasi.

{{% alert color="info" %}} 
Baca lebih lanjut cara [Render Presentasi dengan Font Fallback](/slides/id/cpp/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

### Apakah aturan fallback saya akan disematkan ke dalam file PPTX dan terlihat di PowerPoint setelah disimpan?

Tidak. Aturan fallback adalah pengaturan rendering waktu jalan; mereka tidak diserialisasi ke dalam PPTX dan tidak akan muncul di UI PowerPoint.

### Apakah fallback berlaku untuk teks di dalam SmartArt, WordArt, diagram, dan tabel?

Ya. Mekanisme substitusi glyph yang sama digunakan untuk semua teks dalam objek tersebut.

### Apakah Aspose mendistribusikan font apa pun bersama pustaka?

Tidak. Anda menambahkan dan menggunakan font di sisi Anda dan atas tanggung jawab Anda sendiri.

### Apakah penggantian/substitusi untuk font yang hilang dan fallback untuk glyph yang hilang dapat digunakan bersamaan?

Ya. Mereka adalah tahapan independen dari pipeline resolusi font yang sama: pertama mesin menentukan ketersediaan font ([replacement](/slides/id/cpp/font-replacement/)/[substitution](/slides/id/cpp/font-substitution/)), kemudian fallback mengisi celah untuk glyph yang hilang dalam font yang tersedia.