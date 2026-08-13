---
title: Konfigurasi Koleksi Font Fallback di .NET
linktitle: Koleksi Font Fallback
type: docs
weight: 20
url: /id/net/create-fallback-fonts-collection/
keywords:
- font fallback
- aturan fallback
- koleksi font
- mengkonfigurasi font
- menyiapkan font
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Siapkan koleksi font fallback di Aspose.Slides untuk .NET agar teks tetap konsisten dan tajam dalam presentasi PowerPoint dan OpenDocument."
---
## **Overview**

Aspose.Slides memungkinkan Anda mengkonfigurasi koleksi aturan font fallback untuk sebuah presentasi. Setiap aturan fallback diwakili oleh kelas `FontFallBackRule` dan dapat ditambahkan ke `FontFallBackRulesCollection`, yang mengimplementasikan antarmuka `IFontFallBackRulesCollection`.

Setelah membuat koleksi, Anda dapat menugaskannya ke properti `FontFallBackRulesCollection` pada `FontsManager` presentasi. `FontsManager` mengontrol font di seluruh presentasi, dan setiap instance `Presentation` memiliki `FontsManager` sendiri.

Setelah `FontsManager` diinisialisasi dengan koleksi font fallback, font fallback yang ditentukan diterapkan selama proses render presentasi.

## **Apply Fallback Rules**

Instance kelas [FontFallBackRule](https://reference.aspose.com/slides/id/net/aspose.slides/FontFallBackRule) dapat diatur ke dalam [FontFallBackRulesCollection](https://reference.aspose.com/slides/id/net/aspose.slides/fontfallbackrulescollection), yang mengimplementasikan antarmuka [IFontFallBackRulesCollection](https://reference.aspose.com/slides/id/net/aspose.slides/ifontfallbackrulescollection). Anda dapat menambahkan atau menghapus aturan dari koleksi tersebut.

Kemudian koleksi ini dapat ditugaskan ke [FontFallBackRulesCollection ](https://reference.aspose.com/slides/id/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection)properti pada kelas [FontsManager](https://reference.aspose.com/slides/id/net/aspose.slides/fontsmanager). FontsManager mengontrol font di seluruh presentasi.

Setiap [Presentation ](https://reference.aspose.com/slides/id/net/aspose.slides/presentation)memiliki properti [FontsManager ](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/properties/fontsmanager)dengan instance sendiri dari kelas FontsManager.

Berikut contoh cara membuat koleksi aturan font fallback dan menugaskannya ke FontsManager pada presentasi tertentu:  

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```

Setelah FontsManager diinisialisasi dengan koleksi font fallback, font fallback diterapkan selama proses render presentasi.

{{% alert color="info" %}} 
Baca lebih lanjut bagaimana cara [Render Presentation with Fallback Font](/slides/id/net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

### Will my fallback rules be embedded into the PPTX file and visible in PowerPoint after saving?

Tidak. Aturan fallback adalah pengaturan rendering saat runtime; mereka tidak diserialisasi ke dalam PPTX dan tidak akan muncul di UI PowerPoint.

### Does fallback apply to text inside SmartArt, WordArt, charts, and tables?

Ya. Mekanisme substitusi glyph yang sama digunakan untuk semua teks dalam objek-objek tersebut.

### Does Aspose distribute any fonts with the library?

Tidak. Anda menambahkan dan menggunakan font di sisi Anda sendiri dan dengan tanggung jawab Anda sendiri.

### Can replacement/substitution for missing fonts and fallback for missing glyphs be used together?

Ya. Mereka adalah tahapan independen dalam pipeline resolusi font yang sama: pertama mesin menyelesaikan ketersediaan font ([replacement](/slides/id/net/font-replacement/)/[substitution](/slides/id/net/font-substitution/)), kemudian fallback mengisi kekosongan untuk glyph yang hilang pada font yang tersedia.