---
title: Tentukan Font Fallback untuk Presentasi di Python via Java
linktitle: Font Fallback
type: docs
weight: 10
url: /id/python-java/create-fallback-font/
keywords:
- font fallback
- aturan fallback
- terapkan font
- ganti font
- rentang Unicode
- glyph yang terlewat
- glyph yang tepat
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Kuasai Aspose.Slides untuk Python via Java untuk mengatur font fallback dalam file PPT, PPTX, dan ODP, memastikan tampilan teks yang konsisten di semua perangkat atau sistem operasi."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda menentukan font fallback untuk rendering presentasi dan operasi ekspor. Font fallback digunakan ketika font utama tidak memiliki glyph untuk karakter tertentu.

Perilaku fallback dikonfigurasi melalui aturan fallback. Setiap aturan mengaitkan rentang Unicode dengan satu atau beberapa font yang mungkin berisi glyph yang diperlukan. Anda dapat mendefinisikan aturan untuk rentang karakter yang berbeda, menambah atau menghapus font fallback dari aturan yang ada, dan mengatur beberapa aturan dalam koleksi aturan font fallback.

Aturan fallback adalah pengaturan rendering waktu jalan. Mereka tidak mengubah file presentasi itu sendiri dan tidak disimpan di dalam file PPTX.

## **Aturan Fallback**

Aspose.Slides menyediakan kelas [FontFallBackRule](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontfallbackrule/) untuk menentukan aturan penerapan font fallback. Kelas ini merepresentasikan asosiasi antara rentang Unicode yang digunakan untuk mencari glyph yang hilang dan daftar font yang mungkin berisi glyph yang diperlukan:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule

start_unicode_index = 0x0B80
end_unicode_index = 0x0BFF

first_rule = FontFallBackRule(start_unicode_index, end_unicode_index, "Vijaya")
second_rule = FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

# Gunakan beberapa cara untuk menentukan daftar font.
font_names = jpype.JArray(jpype.JString)(["Segoe UI Emoji, Segoe UI Symbol", "Arial"])

third_rule = FontFallBackRule(0x1F300, 0x1F64F, font_names)
```

Anda juga dapat menghapus font fallback menggunakan [remove](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontfallbackrule/#remove) atau menambah font fallback menggunakan [addFallBackFonts](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontfallbackrule/#addFallBackFonts) pada objek [FontFallBackRule](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontfallbackrule/) yang sudah ada.

[FontFallBackRulesCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontfallbackrulescollection/) dapat mengatur daftar objek [FontFallBackRule](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontfallbackrule/) ketika Anda perlu menentukan aturan penggantian font fallback untuk beberapa rentang Unicode.

{{% alert color="info" title="Lihat juga" %}} 
- [Buat Koleksi Font Fallback](/slides/id/python-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Apa perbedaan antara font fallback, substitusi font, dan penyematan font?**

Font fallback hanya digunakan untuk karakter yang tidak ada dalam font utama. [Font substitution](/slides/id/python-java/font-substitution/) menggantikan seluruh font yang ditentukan dengan font lain. [Font embedding](/slides/id/python-java/embedded-font/) mengemas font di dalam file output sehingga penerima dapat melihat teks sebagaimana dimaksud.

**Apakah font fallback diterapkan selama ekspor seperti PDF, PNG, atau SVG, atau hanya saat rendering di layar?**

Ya. Fallback memengaruhi semua [rendering and export operations](/slides/id/python-java/convert-presentation/) di mana karakter harus digambar tetapi tidak ada dalam font sumber.

**Apakah mengonfigurasi fallback mengubah file presentasi itu sendiri, dan apakah pengaturannya akan tetap ada untuk pembukaan selanjutnya?**

Tidak. Aturan fallback adalah pengaturan rendering waktu jalan dalam kode Anda; mereka tidak disimpan di dalam .pptx dan tidak akan muncul di PowerPoint.

**Apakah sistem operasi (Windows/Linux/macOS) dan kumpulan direktori font memengaruhi pemilihan fallback?**

Ya. Mesin mencari font dari folder sistem yang tersedia dan jalur tambahan yang Anda berikan. Jika sebuah font tidak tersedia secara fisik, aturan yang merujuk padanya tidak dapat beraksi.

**Apakah fallback berfungsi untuk WordArt, SmartArt, dan diagram?**

Ya. Ketika objek-objek ini berisi teks, mekanisme substitusi glyph yang sama diterapkan untuk merender karakter yang hilang.