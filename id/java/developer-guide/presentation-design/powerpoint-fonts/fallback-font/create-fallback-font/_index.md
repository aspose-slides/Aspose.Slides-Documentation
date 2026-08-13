---
title: Tentukan Font Fallback untuk Presentasi di Java
linktitle: Font Fallback
type: docs
weight: 10
url: /id/java/create-fallback-font/
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
- Java
- Aspose.Slides
description: "Kuasi Aspose.Slides untuk Java untuk mengatur font fallback dalam file PPT, PPTX, dan ODP, menjaga tampilan teks yang konsisten pada perangkat atau sistem operasi mana pun."
---
## **Ikhtisar**

Aspose.Slides memungkinkan Anda menentukan font fallback untuk proses rendering presentasi dan operasi ekspor. Font fallback digunakan ketika font utama tidak memiliki glyph untuk karakter tertentu.

Perilaku fallback dikonfigurasi melalui aturan fallback. Setiap aturan mengaitkan rentang Unicode dengan satu atau beberapa font yang mungkin berisi glyph yang diperlukan. Anda dapat menentukan aturan untuk rentang karakter yang berbeda, menambah atau menghapus font fallback dari aturan yang ada, dan mengatur beberapa aturan dalam koleksi aturan font fallback.

Aturan fallback adalah pengaturan rendering saat runtime. Mereka tidak mengubah file presentasi itu sendiri dan tidak disimpan di dalam file PPTX.

## **Aturan Fallback**

Aspose.Slides mendukung antarmuka [IFontFallBackRule](https://reference.aspose.com/slides/id/java/com.aspose.slides/IFontFallBackRule) dan kelas [FontFallBackRule](https://reference.aspose.com/slides/id/java/com.aspose.slides/FontFallBackRule) untuk menentukan aturan yang menerapkan font fallback. Kelas [FontFallBackRule](https://reference.aspose.com/slides/id/java/com.aspose.slides/FontFallBackRule) mewakili asosiasi antara rentang Unicode yang ditentukan, yang digunakan untuk mencari glyph yang hilang, dan daftar font yang mungkin berisi glyph yang tepat:

```java
import com.aspose.slides.*;

long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Dengan berbagai cara Anda dapat menambahkan daftar font:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Juga dimungkinkan untuk [remove](https://reference.aspose.com/slides/id/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) font fallback atau [addFallBackFonts](https://reference.aspose.com/slides/id/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) ke dalam objek [FontFallBackRule](https://reference.aspose.com/slides/id/java/com.aspose.slides/FontFallBackRule) yang ada.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/FontFallBackRulesCollection) dapat digunakan untuk mengatur daftar objek [FontFallBackRule](https://reference.aspose.com/slides/id/java/com.aspose.slides/FontFallBackRule), ketika diperlukan untuk menentukan aturan penggantian font fallback untuk beberapa rentang Unicode.

{{% alert color="info" title="Lihat juga" %}} 
- [Buat Koleksi Font Fallback](/slides/id/java/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

### Apa perbedaan antara font fallback, substitusi font, dan penyematan font?

Font fallback hanya digunakan untuk karakter yang tidak ada di font utama. [Font substitution](/slides/id/java/font-substitution/) menggantikan seluruh font yang ditentukan dengan font lain. [Font embedding](/slides/id/java/embedded-font/) mengemas font ke dalam file output sehingga penerima dapat melihat teks sesuai yang dimaksud.

### Apakah font fallback diterapkan selama ekspor seperti PDF, PNG, atau SVG, atau hanya pada rendering di layar?

Ya. Fallback memengaruhi semua [operasi rendering dan ekspor](/slides/id/java/convert-presentation/) di mana karakter harus digambar tetapi tidak ada dalam font sumber.

### Apakah mengonfigurasi fallback mengubah file presentasi itu sendiri, dan apakah pengaturan tersebut akan bertahan untuk pembukaan di masa mendatang?

Tidak. Aturan fallback adalah pengaturan rendering saat runtime dalam kode Anda; mereka tidak disimpan di dalam .pptx dan tidak akan muncul di PowerPoint.

### Apakah sistem operasi (Windows/Linux/macOS) dan kumpulan direktori font memengaruhi pemilihan fallback?

Ya. Mesin menyelesaikan font dari folder sistem yang tersedia dan [jalur tambahan](/slides/id/java/custom-font/) yang Anda berikan. Jika sebuah font tidak tersedia secara fisik, aturan yang merujuk padanya tidak dapat berfungsi.

### Apakah fallback berfungsi untuk WordArt, SmartArt, dan diagram?

Ya. Ketika objek-objek ini berisi teks, mekanisme substitusi glyph yang sama diterapkan untuk merender karakter yang hilang.