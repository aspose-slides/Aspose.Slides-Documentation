---
title: Tentukan Font Cadangan untuk Presentasi di .NET
linktitle: Font Cadangan
type: docs
weight: 10
url: /id/net/create-fallback-font/
keywords:
- font cadangan
- aturan cadangan
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
description: "Kuasa Aspose.Slides untuk .NET dalam mengatur font cadangan di file PPT, PPTX, dan ODP, memastikan tampilan teks yang konsisten pada perangkat atau sistem operasi apa pun."
---
## **Ringkasan**

Aspose.Slides memungkinkan Anda menentukan font cadangan untuk proses rendering dan ekspor presentasi. Font cadangan digunakan ketika font utama tidak memiliki glyph untuk karakter tertentu.

Perilaku fallback dikonfigurasi melalui aturan fallback. Setiap aturan mengaitkan rentang Unicode dengan satu atau lebih font yang mungkin berisi glyph yang diperlukan. Anda dapat mendefinisikan aturan untuk rentang karakter yang berbeda, menambahkan atau menghapus font cadangan dari aturan yang ada, dan mengatur beberapa aturan dalam koleksi aturan font fallback.

Aturan fallback adalah pengaturan rendering waktu runtime. Mereka tidak mengubah file presentasi itu sendiri dan tidak disimpan di dalam file PPTX.

## **Aturan Fallback**

Aspose.Slides mendukung antarmuka [IFontFallBackRule](https://reference.aspose.com/slides/id/net/aspose.slides/iFontFallBackRule) dan kelas [FontFallBackRule](https://reference.aspose.com/slides/id/net/aspose.slides/FontFallBackRule) untuk menentukan aturan penerapan font fallback. Kelas [FontFallBackRule](https://reference.aspose.com/slides/id/net/aspose.slides/FontFallBackRule) mewakili asosiasi antara rentang Unicode yang ditentukan, yang digunakan untuk mencari glyph yang hilang, dan daftar font yang mungkin berisi glyph yang tepat:

```c#
uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Dengan berbagai cara Anda dapat menambahkan daftar font:
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Juga dimungkinkan untuk [Remove()](https://reference.aspose.com/slides/id/net/aspose.slides/ifontfallbackrule/methods/remove) font fallback atau [AddFallBackFonts()](https://reference.aspose.com/slides/id/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) ke dalam objek [FontFallBackRule](https://reference.aspose.com/slides/id/net/aspose.slides/FontFallBackRule) yang sudah ada.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/id/net/aspose.slides/fontfallbackrulescollection)[ ](https://reference.aspose.com/slides/id/net/aspose.slides/fontfallbackrulescollection) dapat digunakan untuk mengatur daftar objek [FontFallBackRule](https://reference.aspose.com/slides/id/net/aspose.slides/FontFallBackRule), ketika perlu menentukan aturan penggantian font fallback untuk beberapa rentang Unicode.

{{% alert color="primary" title="Lihat juga" %}} 
- [Buat Koleksi Font Fallback](/slides/id/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Apa perbedaan antara font fallback, substitusi font, dan embedding font?**

Font fallback hanya digunakan untuk karakter yang tidak ada di font utama. [Font substitution](/slides/id/net/font-substitution/) menggantikan seluruh font yang ditentukan dengan font lain. [Font embedding](/slides/id/net/embedded-font/) mengemas font ke dalam file output sehingga penerima dapat melihat teks sebagaimana dimaksud.

**Apakah font fallback diterapkan selama ekspor seperti PDF, PNG, atau SVG, atau hanya pada rendering di layar?**

Ya. Fallback memengaruhi semua [rendering and export operations](/slides/id/net/convert-presentation/) di mana karakter harus digambar tetapi tidak ada dalam font sumber.

**Apakah mengonfigurasi fallback mengubah file presentasi itu sendiri, dan apakah pengaturan tersebut akan tetap ada untuk pembukaan selanjutnya?**

Tidak. Aturan fallback adalah pengaturan rendering waktu runtime dalam kode Anda; mereka tidak disimpan di dalam .pptx dan tidak akan muncul di PowerPoint.

**Apakah sistem operasi (Windows/Linux/macOS) dan kumpulan direktori font memengaruhi pemilihan fallback?**

Ya. Mesin mencari font dari folder sistem yang tersedia dan [additional paths](/slides/id/net/custom-font/) yang Anda sediakan. Jika sebuah font tidak tersedia secara fisik, aturan yang merujuknya tidak dapat diterapkan.

**Apakah fallback bekerja untuk WordArt, SmartArt, dan grafik?**

Ya. Ketika objek-objek ini berisi teks, mekanisme substitusi glyph yang sama diterapkan untuk merender karakter yang hilang.