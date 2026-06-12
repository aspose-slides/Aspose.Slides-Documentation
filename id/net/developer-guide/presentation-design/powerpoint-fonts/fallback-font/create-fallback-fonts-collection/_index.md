---
title: Konfigurasikan Koleksi Font Fallback di .NET
linktitle: Koleksi Font Fallback
type: docs
weight: 20
url: /id/net/create-fallback-fonts-collection/
keywords:
- font fallback
- aturan fallback
- koleksi font
- konfigurasi font
- menyiapkan font
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Siapkan koleksi font fallback di Aspose.Slides untuk .NET agar teks tetap konsisten dan tajam dalam presentasi PowerPoint dan OpenDocument."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda mengonfigurasi kumpulan aturan font fallback untuk sebuah presentasi. Setiap aturan fallback direpresentasikan oleh kelas `FontFallBackRule` dan dapat ditambahkan ke `FontFallBackRulesCollection`, yang mengimplementasikan antarmuka `IFontFallBackRulesCollection`.

Setelah membuat koleksi, Anda dapat menugaskannya ke properti `FontFallBackRulesCollection` dari `FontsManager` presentasi. `FontsManager` mengontrol font di seluruh presentasi, dan setiap instance `Presentation` memiliki `FontsManager` miliknya sendiri.

Setelah `FontsManager` diinisialisasi dengan koleksi font fallback, font fallback yang ditentukan akan diterapkan selama proses rendering presentasi.

## **Terapkan Aturan Fallback**

Instansi kelas [FontFallBackRule](https://reference.aspose.com/slides/id/net/aspose.slides/FontFallBackRule) dapat diatur ke dalam [FontFallBackRulesCollection](https://reference.aspose.com/slides/id/net/aspose.slides/fontfallbackrulescollection), yang mengimplementasikan antarmuka [IFontFallBackRulesCollection](https://reference.aspose.com/slides/id/net/aspose.slides/ifontfallbackrulescollection). Anda dapat menambah atau menghapus aturan dari koleksi.

Kemudian koleksi ini dapat ditugaskan ke properti [FontFallBackRulesCollection](https://reference.aspose.com/slides/id/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) dari kelas [FontsManager](https://reference.aspose.com/slides/id/net/aspose.slides/fontsmanager). FontsManager mengontrol font di seluruh presentasi.

Setiap [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) memiliki properti [FontsManager](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/properties/fontsmanager) dengan instance sendiri dari kelas FontsManager.

Berikut contoh cara membuat koleksi aturan font fallback dan menugaskannya ke FontsManager dari presentasi tertentu:

```c#
using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```

Setelah FontsManager diinisialisasi dengan koleksi font fallback, font fallback akan diterapkan selama proses rendering presentasi.

{{% alert color="primary" %}} 
Baca lebih lanjut cara [Render Presentasi dengan Font Fallback](/slides/id/net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Tanya Jawab**

**Apakah aturan fallback saya akan disematkan ke dalam file PPTX dan terlihat di PowerPoint setelah disimpan?**

Tidak. Aturan fallback adalah pengaturan rendering waktu jalan; mereka tidak diserialisasi ke dalam PPTX dan tidak akan muncul di UI PowerPoint.

**Apakah fallback berlaku untuk teks di dalam SmartArt, WordArt, grafik, dan tabel?**

Ya. Mekanisme substitusi glyph yang sama digunakan untuk semua teks di objek tersebut.

**Apakah Aspose mendistribusikan font apa pun bersama perpustakaan?**

Tidak. Anda menambahkan dan menggunakan font di sisi Anda sendiri dengan tanggung jawab Anda.

**Apakah penggantian/substitusi untuk font yang hilang dan fallback untuk glyph yang hilang dapat digunakan bersamaan?**

Ya. Mereka merupakan tahap independen dari pipeline resolusi font yang sama: pertama mesin menyelesaikan ketersediaan font ([replacement](/slides/id/net/font-replacement/)/[substitution](/slides/id/net/font-substitution/)), kemudian fallback mengisi celah untuk glyph yang hilang pada font yang tersedia.