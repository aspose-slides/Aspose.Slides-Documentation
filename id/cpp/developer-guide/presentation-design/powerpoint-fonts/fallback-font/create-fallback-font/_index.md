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
- glif yang hilang
- glif yang tepat
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Kuasa Aspose.Slides untuk C++ dalam mengatur font fallback pada file PPT, PPTX, dan ODP, memastikan tampilan teks yang konsisten di semua perangkat atau sistem operasi."
---
## **Overview**

Aspose.Slides memungkinkan Anda menentukan font fallback untuk proses render dan ekspor presentasi. Font fallback digunakan ketika font utama tidak memiliki glif untuk karakter tertentu.

Perilaku fallback dikonfigurasi melalui aturan fallback. Setiap aturan mengaitkan rentang Unicode dengan satu atau lebih font yang mungkin berisi glif yang diperlukan. Anda dapat mendefinisikan aturan untuk berbagai rentang karakter, menambah atau menghapus font fallback dari aturan yang ada, dan mengatur beberapa aturan dalam koleksi aturan font fallback.

Aturan fallback adalah pengaturan render waktu jalan. Mereka tidak mengubah file presentasi itu sendiri dan tidak disimpan di dalam file PPTX.

## **Fallback Rules**

Aspose.Slides mendukung antarmuka [IFontFallBackRule](https://reference.aspose.com/slides/id/cpp/aspose.slides/ifontfallbackrule/) dan kelas [FontFallBackRule](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontfallbackrule/) untuk menentukan aturan penerapan font fallback. Kelas [FontFallBackRule](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontfallbackrule/) mewakili asosiasi antara rentang Unicode yang ditentukan, yang digunakan untuk mencari glif yang hilang, dan daftar font yang mungkin berisi glif yang tepat:

``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Using multiple ways you can add fonts list:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```

Anda juga dapat [Remove()](https://reference.aspose.com/slides/id/cpp/aspose.slides/ifontfallbackrule/remove/) font fallback atau [AddFallBackFonts()](https://reference.aspose.com/slides/id/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) ke dalam objek [FontFallBackRule](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontfallbackrule/) yang sudah ada.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontfallbackrulescollection/) dapat digunakan untuk mengatur daftar objek [FontFallBackRule](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontfallbackrule/), ketika diperlukan aturan penggantian font fallback untuk beberapa rentang Unicode.

{{% alert color="primary" title="Lihat juga" %}} 
- [Buat Koleksi Font Fallback](/slides/id/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Apa perbedaan antara font fallback, substitusi font, dan penyematan font?**

Font fallback hanya digunakan untuk karakter yang tidak ada dalam font utama. [Font substitution](/slides/id/cpp/font-substitution/) menggantikan seluruh font yang ditentukan dengan font lain. [Font embedding](/slides/id/cpp/embedded-font/) memasukkan font ke dalam file output sehingga penerima dapat melihat teks sebagaimana dimaksud.

**Apakah font fallback diterapkan selama ekspor seperti PDF, PNG, atau SVG, atau hanya pada render di layar?**

Ya. Fallback memengaruhi semua [rendering and export operations](/slides/id/cpp/convert-presentation/) di mana karakter harus digambar tetapi tidak ada dalam font sumber.

**Apakah mengonfigurasi fallback mengubah file presentasi itu sendiri, dan apakah pengaturan akan bertahan untuk pembukaan selanjutnya?**

Tidak. Aturan fallback adalah pengaturan render waktu jalan dalam kode Anda; mereka tidak disimpan di dalam .pptx dan tidak akan muncul di PowerPoint.

**Apakah sistem operasi (Windows/Linux/macOS) dan kumpulan direktori font memengaruhi pemilihan fallback?**

Ya. Mesin mencari font dari folder sistem yang tersedia dan [additional paths](/slides/id/cpp/custom-font/) yang Anda sediakan. Jika sebuah font tidak tersedia secara fisik, aturan yang merujuknya tidak dapat diterapkan.

**Apakah fallback berfungsi untuk WordArt, SmartArt, dan diagram?**

Ya. Ketika objek-objek ini berisi teks, mekanisme substitusi glif yang sama diterapkan untuk merender karakter yang hilang.