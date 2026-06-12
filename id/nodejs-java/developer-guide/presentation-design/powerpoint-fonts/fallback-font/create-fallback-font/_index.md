---
title: Menentukan Font Fallback untuk Presentasi dalam JavaScript
linktitle: Font Fallback
type: docs
weight: 10
url: /id/nodejs-java/create-fallback-font/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Menguasai Aspose.Slides untuk Node.js untuk mengatur font fallback dalam file PPT, PPTX, dan ODP menggunakan JavaScript, memastikan tampilan teks yang konsisten di semua perangkat atau sistem operasi."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda menentukan font fallback untuk proses rendering dan ekspor presentasi. Font fallback digunakan ketika font utama tidak memiliki glyph untuk karakter tertentu.

Perilaku fallback dikonfigurasi melalui aturan fallback. Setiap aturan mengaitkan rentang Unicode dengan satu atau lebih font yang mungkin berisi glyph yang dibutuhkan. Anda dapat mendefinisikan aturan untuk rentang karakter yang berbeda, menambah atau menghapus font fallback dari aturan yang ada, dan mengatur beberapa aturan dalam koleksi aturan font fallback.

Aturan fallback adalah pengaturan rendering waktu jalan. Mereka tidak mengubah file presentasi itu sendiri dan tidak disimpan di dalam file PPTX.

## **Aturan Fallback**

Aspose.Slides mendukung kelas [FontFallBackRule](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/FontFallBackRule) dan [FontFallBackRule](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/FontFallBackRule) untuk menentukan aturan yang menerapkan font fallback. Kelas [FontFallBackRule](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/FontFallBackRule) mewakili asosiasi antara rentang Unicode yang ditentukan, yang digunakan untuk mencari glyph yang hilang, dan daftar font yang mungkin berisi glyph yang tepat:

```javascript
var startUnicodeIndex = 0xb80;
var endUnicodeIndex = 0xbff;
var firstRule = new aspose.slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
var secondRule = new aspose.slides.FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
// Menggunakan beberapa cara Anda dapat menambahkan daftar font:
var fontNames = java.newArray("java.lang.String", ["Segoe UI Emoji, Segoe UI Symbol", "Arial"]));
var thirdRule = new aspose.slides.FontFallBackRule(0x1f300, 0x1f64f, fontNames);
```

Juga memungkinkan untuk [remove](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) font fallback atau [addFallBackFonts](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) ke dalam objek [FontFallBackRule](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/FontFallBackRule) yang sudah ada.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/FontFallBackRulesCollection) dapat digunakan untuk mengatur daftar objek [FontFallBackRule](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/FontFallBackRule) ketika diperlukan menentukan aturan penggantian font fallback untuk beberapa rentang Unicode.

{{% alert color="primary" title="Lihat juga" %}} 
- [Buat Koleksi Font Fallback](/slides/id/nodejs-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Apa perbedaan antara font fallback, substitusi font, dan penyematan font?**

Font fallback hanya digunakan untuk karakter yang tidak ada di font utama. [Font substitution](/slides/id/nodejs-java/font-substitution/) menggantikan seluruh font yang ditentukan dengan font lain. [Font embedding](/slides/id/nodejs-java/embedded-font/) memasukkan font ke dalam file output sehingga penerima dapat melihat teks sebagaimana dimaksud.

**Apakah font fallback diterapkan selama ekspor seperti PDF, PNG, atau SVG, atau hanya pada rendering di layar?**

Ya. Fallback memengaruhi semua [rendering and export operations](/slides/id/nodejs-java/convert-presentation/) di mana karakter harus digambar tetapi tidak ada dalam font sumber.

**Apakah mengonfigurasi fallback mengubah file presentasi itu sendiri, dan apakah pengaturan tersebut akan tetap ada saat dibuka di masa mendatang?**

Tidak. Aturan fallback adalah pengaturan rendering waktu jalan dalam kode Anda; mereka tidak disimpan di dalam file .pptx dan tidak akan muncul di PowerPoint.

**Apakah sistem operasi (Windows/Linux/macOS) dan kumpulan direktori font memengaruhi pemilihan fallback?**

Ya. Mesin mencari font dari folder sistem yang tersedia serta [additional paths](/slides/id/nodejs-java/custom-font/) yang Anda sediakan. Jika suatu font tidak tersedia secara fisik, aturan yang merujuk padanya tidak dapat diterapkan.

**Apakah fallback berfungsi untuk WordArt, SmartArt, dan diagram?**

Ya. Ketika objek-objek ini berisi teks, mekanisme substitusi glyph yang sama diterapkan untuk merender karakter yang hilang.