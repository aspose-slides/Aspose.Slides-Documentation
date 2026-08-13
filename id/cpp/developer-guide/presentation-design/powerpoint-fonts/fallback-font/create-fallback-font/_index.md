---
title: Tentukan Font Fallback untuk Presentasi dalam C++
linktitle: Font Fallback
type: docs
weight: 10
url: /id/cpp/create-fallback-font/
keywords:
- font fallback
- aturan fallback
- terapkan font
- ganti font
- rentang Unicode
- glyph yang hilang
- glyph yang tepat
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Kuasi Aspose.Slides untuk C++ guna mengatur font fallback dalam file PPT, PPTX, dan ODP, memastikan tampilan teks yang konsisten pada perangkat atau OS apa pun."
---
## **Ringkasan**

Aspose.Slides memungkinkan Anda menentukan font fallback untuk proses rendering dan ekspor presentasi. Font fallback digunakan ketika font utama tidak memiliki glyph untuk karakter tertentu.

Perilaku fallback dikonfigurasi melalui aturan fallback. Setiap aturan mengaitkan rentang Unicode dengan satu atau beberapa font yang mungkin berisi glyph yang diperlukan. Anda dapat mendefinisikan aturan untuk rentang karakter yang berbeda, menambah atau menghapus font fallback dari aturan yang ada, dan mengatur beberapa aturan dalam koleksi aturan font fallback.

Aturan fallback adalah pengaturan rendering waktu jalan. Mereka tidak mengubah berkas presentasi itu sendiri dan tidak disimpan di dalam berkas PPTX.

## **Aturan Fallback**

Aspose.Slides mendukung antarmuka [IFontFallBackRule](https://reference.aspose.com/slides/id/cpp/aspose.slides/ifontfallbackrule/) dan kelas [FontFallBackRule](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontfallbackrule/) untuk menentukan aturan yang menerapkan font fallback. Kelas [FontFallBackRule](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontfallbackrule/) mewakili asosiasi antara rentang Unicode yang ditentukan, digunakan untuk mencari glyph yang tidak ada, dan daftar font yang mungkin berisi glyph yang tepat:

``` cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Using multiple ways you can add fonts list:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```

Anda juga dapat [Remove()](https://reference.aspose.com/slides/id/cpp/aspose.slides/ifontfallbackrule/remove/) font fallback atau [AddFallBackFonts()](https://reference.aspose.com/slides/id/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) ke dalam objek [FontFallBackRule](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontfallbackrule/) yang sudah ada.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontfallbackrulescollection/) dapat digunakan untuk mengatur daftar objek [FontFallBackRule](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontfallbackrule/) ketika diperlukan untuk menentukan aturan penggantian font fallback bagi beberapa rentang Unicode.

{{% alert color="info" title="Lihat juga" %}} 
- [Buat Koleksi Font Fallback](/slides/id/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

### Apa perbedaan antara font fallback, substitusi font, dan penyematan font?

Font fallback hanya digunakan untuk karakter yang tidak ada dalam font utama. [Font substitution](/slides/id/cpp/font-substitution/) menggantikan seluruh font yang ditentukan dengan font lain. [Font embedding](/slides/id/cpp/embedded-font/) memasukkan font ke dalam berkas keluaran sehingga penerima dapat melihat teks sesuai harapan.

### Apakah font fallback diterapkan selama ekspor seperti PDF, PNG, atau SVG, atau hanya pada rendering layar?

Ya. Fallback memengaruhi semua [rendering and export operations](/slides/id/cpp/convert-presentation/) di mana karakter harus digambar namun tidak ada dalam font sumber.

### Apakah mengonfigurasi fallback mengubah berkas presentasi itu sendiri, dan apakah pengaturan tersebut akan bertahan untuk pembukaan di masa mendatang?

Tidak. Aturan fallback adalah pengaturan rendering waktu jalan dalam kode Anda; mereka tidak disimpan di dalam .pptx dan tidak akan muncul di PowerPoint.

### Apakah sistem operasi (Windows/Linux/macOS) dan set direktori font memengaruhi pemilihan fallback?

Ya. Mesin mencari font dari folder sistem yang tersedia dan setiap [additional paths](/slides/id/cpp/custom-font/) yang Anda sediakan. Jika sebuah font tidak tersedia secara fisik, aturan yang merujuk padanya tidak dapat berfungsi.

### Apakah fallback bekerja untuk WordArt, SmartArt, dan diagram?

Ya. Ketika objek-objek ini berisi teks, mekanisme substitusi glyph yang sama diterapkan untuk merender karakter yang hilang.