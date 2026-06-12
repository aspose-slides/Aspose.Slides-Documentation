---
title: Tentukan Font Fallback untuk Presentasi di PHP
linktitle: Font Fallback
type: docs
weight: 10
url: /id/php-java/create-fallback-font/
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
- PHP
- Aspose.Slides
description: "Kuasi Aspose.Slides untuk PHP via Java untuk mengatur font fallback dalam file PPT, PPTX, dan ODP, memastikan tampilan teks yang konsisten di semua perangkat atau sistem operasi."
---
## **Ikhtisar**

Aspose.Slides memungkinkan Anda menentukan font fallback untuk proses render presentasi dan operasi ekspor. Font fallback digunakan ketika font utama tidak memiliki glyph untuk karakter tertentu.

Perilaku fallback dikonfigurasi melalui aturan fallback. Setiap aturan mengaitkan rentang Unicode dengan satu atau beberapa font yang mungkin berisi glyph yang diperlukan. Anda dapat mendefinisikan aturan untuk rentang karakter yang berbeda, menambahkan atau menghapus font fallback dari aturan yang ada, dan mengatur beberapa aturan dalam koleksi aturan font fallback.

Aturan fallback adalah pengaturan rendering pada waktu berjalan. Mereka tidak mengubah file presentasi itu sendiri dan tidak disimpan di dalam file PPTX.

## **Aturan Fallback**

Aspose.Slides mendukung kelas [FontFallBackRule](https://reference.aspose.com/slides/id/php-java/aspose.slides/FontFallBackRule) untuk menentukan aturan menerapkan font fallback. Kelas [FontFallBackRule](https://reference.aspose.com/slides/id/php-java/aspose.slides/FontFallBackRule) mewakili asosiasi antara rentang Unicode yang ditentukan, yang digunakan untuk mencari glyph yang hilang, dan daftar font yang mungkin berisi glyph yang tepat:

```php
  $startUnicodeIndex = 0xb80;
  $endUnicodeIndex = 0xbff;
  $firstRule = new FontFallBackRule($startUnicodeIndex, $endUnicodeIndex, "Vijaya");
  $secondRule = new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
  # Menggunakan beberapa cara Anda dapat menambahkan daftar font:
  $fontNames = array("Segoe UI Emoji, Segoe UI Symbol", "Arial" );
  $thirdRule = new FontFallBackRule(0x1f300, 0x1f64f, $fontNames);
```

Anda juga dapat [remove](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontfallbackrule/remove/) font fallback atau [addFallBackFonts](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontfallbackrule/addfallbackfonts/) ke dalam objek [FontFallBackRule](https://reference.aspose.com/slides/id/php-java/aspose.slides/FontFallBackRule) yang ada.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/FontFallBackRulesCollection) dapat digunakan untuk mengatur daftar objek [FontFallBackRule](https://reference.aspose.com/slides/id/php-java/aspose.slides/FontFallBackRule), ketika diperlukan menentukan aturan penggantian font fallback untuk beberapa rentang Unicode.

{{% alert color="primary" title="Lihat juga" %}} 
- [Buat Koleksi Font Fallback](/slides/id/php-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Apa perbedaan antara font fallback, substitusi font, dan penyematan font?**

Font fallback hanya digunakan untuk karakter yang tidak ada di font utama. [Font substitution](/slides/id/php-java/font-substitution/) menggantikan seluruh font yang ditentukan dengan font lain. [Font embedding](/slides/id/php-java/embedded-font/) mengemas font ke dalam file output sehingga penerima dapat melihat teks seperti yang dimaksudkan.

**Apakah font fallback diterapkan selama ekspor seperti PDF, PNG, atau SVG, atau hanya pada rendering di layar?**

Ya. Fallback memengaruhi semua [rendering and export operations](/slides/id/php-java/convert-presentation/) di mana karakter harus digambar tetapi tidak ada dalam font sumber.

**Apakah mengonfigurasi fallback mengubah file presentasi itu sendiri, dan apakah pengaturan tersebut akan bertahan untuk pembukaan di masa mendatang?**

Tidak. Aturan fallback adalah pengaturan rendering pada waktu berjalan dalam kode Anda; mereka tidak disimpan di dalam .pptx dan tidak akan muncul di PowerPoint.

**Apakah sistem operasi (Windows/Linux/macOS) dan kumpulan direktori font memengaruhi pemilihan fallback?**

Ya. Mesin mencari font dari folder sistem yang tersedia dan [additional paths](/slides/id/php-java/custom-font/) yang Anda sediakan. Jika sebuah font tidak tersedia secara fisik, aturan yang merujuknya tidak dapat berlaku.

**Apakah fallback berfungsi untuk WordArt, SmartArt, dan diagram?**

Ya. Ketika objek-objek ini berisi teks, mekanisme substitusi glyph yang sama diterapkan untuk merender karakter yang hilang.