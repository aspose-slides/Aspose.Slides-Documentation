---
title: Tentukan Font Fallback untuk Presentasi di .NET
linktitle: Font Fallback
type: docs
weight: 10
url: /id/net/create-fallback-font/
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
- .NET
- C#
- Aspose.Slides
description: "Menguasai Aspose.Slides untuk .NET untuk mengatur font fallback dalam file PPT, PPTX, dan ODP, melindungi tampilan teks yang konsisten pada perangkat atau OS apa pun."
---
## **Overview**

Aspose.Slides memungkinkan Anda menentukan font fallback untuk proses rendering dan ekspor presentasi. Font fallback digunakan ketika font utama tidak memiliki glyph untuk karakter tertentu.

Perilaku fallback dikonfigurasi melalui aturan fallback. Setiap aturan mengaitkan rentang Unicode dengan satu atau lebih font yang mungkin berisi glyph yang diperlukan. Anda dapat mendefinisikan aturan untuk rentang karakter yang berbeda, menambah atau menghapus font fallback dari aturan yang ada, dan mengatur beberapa aturan dalam koleksi aturan font fallback.

Aturan fallback adalah pengaturan rendering pada waktu jalan. Mereka tidak mengubah file presentasi itu sendiri dan tidak disimpan di dalam file PPTX.

## **Fallback Rules**

Aspose.Slides mendukung antarmuka [IFontFallBackRule](https://reference.aspose.com/slides/id/net/aspose.slides/iFontFallBackRule) dan [FontFallBackRule](https://reference.aspose.com/slides/id/net/aspose.slides/FontFallBackRule) kelas untuk menentukan aturan penerapan font fallback. Kelas [FontFallBackRule](https://reference.aspose.com/slides/id/net/aspose.slides/FontFallBackRule) mewakili asosiasi antara rentang Unicode yang ditentukan, digunakan untuk mencari glyph yang hilang, dan daftar font yang mungkin berisi glyph yang tepat:

```c#
using Aspose.Slides;

uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Dengan berbagai cara Anda dapat menambahkan daftar font:
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```



Juga dimungkinkan untuk [Remove()](https://reference.aspose.com/slides/id/net/aspose.slides/ifontfallbackrule/methods/remove) font fallback atau [AddFallBackFonts()](https://reference.aspose.com/slides/id/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) ke dalam objek [FontFallBackRule](https://reference.aspose.com/slides/id/net/aspose.slides/FontFallBackRule) yang sudah ada.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/id/net/aspose.slides/fontfallbackrulescollection)[ ](https://reference.aspose.com/slides/id/net/aspose.slides/fontfallbackrulescollection) dapat digunakan untuk mengatur daftar objek [FontFallBackRule](https://reference.aspose.com/slides/id/net/aspose.slides/FontFallBackRule) ketika diperlukan menentukan aturan penggantian font fallback untuk beberapa rentang Unicode.

{{% alert color="info" title="See also" %}} 
- [Buat Koleksi Font Fallback](/slides/id/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

### What is the difference between a fallback font, font substitution, and font embedding?

Font fallback hanya digunakan untuk karakter yang tidak ada di font utama. [Font substitution](/slides/id/net/font-substitution/) menggantikan seluruh font yang ditentukan dengan font lain. [Font embedding](/slides/id/net/embedded-font/) menyertakan font di dalam file output sehingga penerima dapat melihat teks sebagaimana dimaksud.

### Are fallback fonts applied during exports like PDF, PNG, or SVG, or only on-screen rendering?

Ya. Fallback memengaruhi semua [rendering and export operations](/slides/id/net/convert-presentation/) di mana karakter harus digambar tetapi tidak ada dalam font sumber.

### Does configuring fallback change the presentation file itself, and will the setting persist for future openings?

Tidak. Aturan fallback adalah pengaturan rendering pada waktu jalan dalam kode Anda; mereka tidak disimpan di dalam .pptx dan tidak akan muncul di PowerPoint.

### Does the operating system (Windows/Linux/macOS) and the set of font directories affect fallback selection?

Ya. Mesin mencari font dari folder sistem yang tersedia dan [additional paths](/slides/id/net/custom-font/) yang Anda berikan. Jika sebuah font tidak tersedia secara fisik, aturan yang merujuknya tidak dapat berfungsi.

### Does fallback work for WordArt, SmartArt, and charts?

Ya. Ketika objek-objek tersebut berisi teks, mekanisme substitusi glyph yang sama diterapkan untuk merender karakter yang hilang.