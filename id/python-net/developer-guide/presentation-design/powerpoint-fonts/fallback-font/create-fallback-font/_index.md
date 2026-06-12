---
title: Tentukan Font Cadangan untuk Presentasi di Python
linktitle: Font Cadangan
type: docs
weight: 10
url: /id/python-net/create-fallback-font/
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
- Python
- Aspose.Slides
description: "Kuasi Aspose.Slides untuk Python via .NET guna mengatur font cadangan dalam file PPT, PPTX, dan ODP, melindungi tampilan teks yang konsisten di semua perangkat atau sistem operasi."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda menentukan font cadangan untuk proses rendering dan ekspor presentasi. Font cadangan digunakan ketika font utama tidak memiliki glyph untuk karakter tertentu.

Perilaku cadangan dikonfigurasi melalui aturan fallback. Setiap aturan mengaitkan rentang Unicode dengan satu atau beberapa font yang mungkin berisi glyph yang diperlukan. Anda dapat mendefinisikan aturan untuk rentang karakter yang berbeda, menambah atau menghapus font cadangan dari aturan yang ada, dan mengatur beberapa aturan dalam koleksi aturan font cadangan.

Aturan fallback adalah pengaturan rendering waktu jalan. Mereka tidak mengubah file presentasi itu sendiri dan tidak disimpan di dalam file PPTX.

## **Tentukan Font Cadangan**

Aspose.Slides mendukung kelas [FontFallBackRule](https://reference.aspose.com/slides/id/python-net/aspose.slides/FontFallBackRule/) untuk menentukan aturan penerapan font cadangan. Kelas [FontFallBackRule](https://reference.aspose.com/slides/id/python-net/aspose.slides/FontFallBackRule/) mewakili asosiasi antara rentang Unicode yang ditentukan, yang digunakan untuk mencari glyph yang hilang, dan daftar font yang mungkin berisi glyph yang tepat:

```py
startUnicodeIndex = 0x0B80
endUnicodeIndex = 0x0BFF

firstRule = slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya")
secondRule = slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

#Menggunakan beberapa cara Anda dapat menambahkan daftar font:
fontNames =  ["Segoe UI Emoji, Segoe UI Symbol", "Arial" ]

thirdRule = slides.FontFallBackRule(0x1F300, 0x1F64F, fontNames)
```

Anda juga dapat [remove](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontfallbackrule/remove/) font cadangan atau [add_fall_back_fonts](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontfallbackrule/add_fall_back_fonts/) ke dalam objek [FontFallBackRule](https://reference.aspose.com/slides/id/python-net/aspose.slides/FontFallBackRule/) yang sudah ada.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontfallbackrulescollection/) dapat digunakan untuk mengatur daftar objek [FontFallBackRule](https://reference.aspose.com/slides/id/python-net/aspose.slides/FontFallBackRule/), ketika diperlukan untuk menentukan aturan penggantian font cadangan untuk beberapa rentang Unicode.

{{% alert color="primary" title="Lihat juga" %}} 
- [Buat Koleksi Font Cadangan](/slides/id/python-net/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Apa perbedaan antara font cadangan, substitusi font, dan penyematan font?**

Font cadangan hanya digunakan untuk karakter yang tidak ada di font utama. [Font substitution](/slides/id/python-net/font-substitution/) menggantikan seluruh font yang ditentukan dengan font lain. [Font embedding](/slides/id/python-net/embedded-font/) mengemas font ke dalam file output sehingga penerima dapat melihat teks seperti yang dimaksud.

**Apakah font cadangan diterapkan selama ekspor seperti PDF, PNG, atau SVG, atau hanya pada rendering di layar?**

Ya. Font cadangan memengaruhi semua [rendering and export operations](/slides/id/python-net/convert-presentation/) di mana karakter harus digambar tetapi tidak ada dalam font sumber.

**Apakah mengonfigurasi font cadangan mengubah file presentasi itu sendiri, dan apakah pengaturan akan tetap ada untuk pembukaan selanjutnya?**

Tidak. Aturan fallback adalah pengaturan rendering waktu jalan dalam kode Anda; mereka tidak disimpan di dalam .pptx dan tidak akan muncul di PowerPoint.

**Apakah sistem operasi (Windows/Linux/macOS) dan kumpulan direktori font memengaruhi pemilihan font cadangan?**

Ya. Mesin mencari font dari folder sistem yang tersedia dan [additional paths](/slides/id/python-net/custom-font/) yang Anda berikan. Jika sebuah font tidak tersedia secara fisik, aturan yang merujuk padanya tidak dapat diterapkan.

**Apakah font cadangan berfungsi untuk WordArt, SmartArt, dan diagram?**

Ya. Ketika objek-objek ini berisi teks, mekanisme substitusi glyph yang sama diterapkan untuk merender karakter yang hilang.