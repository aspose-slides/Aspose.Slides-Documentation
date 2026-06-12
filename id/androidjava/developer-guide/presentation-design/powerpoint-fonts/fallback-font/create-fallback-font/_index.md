---
title: Tentukan Font Fallback untuk Presentasi di Android
linktitle: Font Fallback
type: docs
weight: 10
url: /id/androidjava/create-fallback-font/
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
- Android
- Java
- Aspose.Slides
description: "Menguasai Aspose.Slides untuk Android via Java untuk mengatur font fallback dalam file PPT, PPTX, dan ODP, memastikan tampilan teks yang konsisten pada perangkat atau sistem operasi apa pun."
---
## **Ikhtisar**

Aspose.Slides memungkinkan Anda menentukan font fallback untuk rendering presentasi dan operasi ekspor. Font fallback digunakan ketika font utama tidak memiliki glif untuk karakter tertentu.

Perilaku fallback dikonfigurasi melalui aturan fallback. Setiap aturan mengaitkan rentang Unicode dengan satu atau lebih font yang mungkin berisi glif yang diperlukan. Anda dapat menentukan aturan untuk rentang karakter yang berbeda, menambah atau menghapus font fallback dari aturan yang ada, dan mengatur beberapa aturan dalam koleksi aturan font fallback.

Aturan fallback adalah pengaturan rendering saat runtime. Mereka tidak mengubah file presentasi itu sendiri dan tidak disimpan di dalam file PPTX.

## **Aturan Fallback**

Aspose.Slides mendukung antarmuka [IFontFallBackRule](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IFontFallBackRule) dan kelas [FontFallBackRule](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/FontFallBackRule) untuk menentukan aturan penerapan font fallback. Kelas [FontFallBackRule](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/FontFallBackRule) mewakili asosiasi antara rentang Unicode yang ditentukan, yang digunakan untuk mencari glif yang hilang, dan daftar font yang mungkin berisi glif yang tepat:

```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Menggunakan berbagai cara Anda dapat menambahkan daftar font:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Anda juga dapat [remove](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) font fallback atau [addFallBackFonts](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) ke dalam objek [FontFallBackRule](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/FontFallBackRule) yang ada.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/FontFallBackRulesCollection) dapat digunakan untuk mengatur daftar objek [FontFallBackRule](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/FontFallBackRule), ketika diperlukan untuk menentukan aturan penggantian font fallback untuk beberapa rentang Unicode.

{{% alert color="primary" title="Lihat juga" %}} 
- [Buat Koleksi Font Fallback](/slides/id/androidjava/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Apa perbedaan antara font fallback, substitusi font, dan embedding font?**

Font fallback hanya digunakan untuk karakter yang tidak ada dalam font utama. [Font substitution](/slides/id/androidjava/font-substitution/) menggantikan seluruh font yang ditentukan dengan font lain. [Font embedding](/slides/id/androidjava/embedded-font/) mengemas font ke dalam file output sehingga penerima dapat melihat teks sesuai yang dimaksud.

**Apakah font fallback diterapkan selama ekspor seperti PDF, PNG, atau SVG, atau hanya pada rendering di layar?**

Ya. Fallback memengaruhi semua [operasi rendering dan ekspor](/slides/id/androidjava/convert-presentation/) di mana karakter harus digambar tetapi tidak ada dalam font sumber.

**Apakah mengonfigurasi fallback mengubah file presentasi itu sendiri, dan apakah pengaturan akan tetap ada untuk pembukaan selanjutnya?**

Tidak. Aturan fallback adalah pengaturan rendering runtime dalam kode Anda; mereka tidak disimpan di dalam .pptx dan tidak akan muncul di PowerPoint.

**Apakah sistem operasi (Windows/Linux/macOS) dan kumpulan direktori font memengaruhi pemilihan fallback?**

Ya. Mesin mencari font dari folder sistem yang tersedia dan [jalur tambahan](/slides/id/androidjava/custom-font/) yang Anda berikan. Jika sebuah font tidak tersedia secara fisik, aturan yang merujuk padanya tidak dapat diterapkan.

**Apakah fallback berfungsi untuk WordArt, SmartArt, dan diagram?**

Ya. Ketika objek-objek ini berisi teks, mekanisme substitusi glif yang sama diterapkan untuk merender karakter yang hilang.