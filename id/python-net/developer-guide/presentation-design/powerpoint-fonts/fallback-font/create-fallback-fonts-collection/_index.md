---
title: Mengonfigurasi Koleksi Font Fallback di Python
linktitle: Koleksi Font Fallback
type: docs
weight: 20
url: /id/python-net/create-fallback-fonts-collection/
keywords:
- font fallback
- aturan fallback
- koleksi font
- konfigurasi font
- menyiapkan font
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Siapkan koleksi font fallback di Aspose.Slides untuk Python via .NET agar teks tetap konsisten dan tajam dalam presentasi PowerPoint dan OpenDocument."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda mengonfigurasi sekumpulan aturan font fallback untuk sebuah presentasi. Setiap aturan fallback direpresentasikan oleh kelas `FontFallBackRule` dan dapat ditambahkan ke `FontFallBackRulesCollection`.

Setelah membuat koleksi tersebut, Anda dapat menetapkannya ke properti `font_fall_back_rules_collection` dari `fonts_manager` presentasi. `fonts_manager` mengendalikan font di seluruh presentasi, dan setiap instance `Presentation` memiliki `FontsManager` masing‑masing.

Setelah `FontsManager` diinisialisasi dengan koleksi font fallback, font fallback yang ditentukan akan diterapkan selama proses rendering presentasi.

## **Terapkan Aturan Fallback**

Instance dari kelas[FontFallBackRule](https://reference.aspose.com/slides/id/python-net/aspose.slides/FontFallBackRule/) dapat diatur ke dalam[FontFallBackRulesCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontfallbackrulescollection/). Anda dapat menambahkan atau menghapus aturan dari koleksi tersebut.

Kemudian koleksi ini dapat ditetapkan ke properti[font_fall_back_rules_collection](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsmanager/font_fall_back_rules_collection/) dari kelas[FontsManager](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsmanager/). FontsManager mengendalikan font di seluruh presentasi.

Setiap[Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) memiliki properti[fonts_manager](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/fonts_manager/) dengan instance sendiri dari kelas FontsManager.

Berikut ini contoh cara membuat koleksi aturan font fallback dan menugaskannya ke FontsManager pada sebuah presentasi tertentu:  

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
	userRulesList = slides.FontFallBackRulesCollection()

	userRulesList.add(slides.FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"))
	userRulesList.add(slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"))

	presentation.fonts_manager.font_fall_back_rules_collection = userRulesList
```

Setelah FontsManager diinisialisasi dengan koleksi font fallback, font fallback akan diterapkan selama proses rendering presentasi.

{{% alert color="primary" %}} 
Baca selengkapnya cara [Render Presentasi dengan Font Fallback](/slides/id/python-net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Apakah aturan fallback saya akan disematkan ke dalam file PPTX dan terlihat di PowerPoint setelah disimpan?**

Tidak. Aturan fallback merupakan pengaturan rendering saat runtime; mereka tidak diserialisasi ke dalam PPTX dan tidak akan muncul di UI PowerPoint.

**Apakah fallback berlaku untuk teks di dalam SmartArt, WordArt, diagram, dan tabel?**

Ya. Mekanisme substitusi glyph yang sama digunakan untuk semua teks dalam objek-objek tersebut.

**Apakah Aspose mendistribusikan font apa pun bersama perpustakaan?**

Tidak. Anda menambahkan dan menggunakan font di sisi Anda sendiri dan bertanggung jawab atasnya.

**Apakah penggantian/substitusi untuk font yang hilang dan fallback untuk glyph yang hilang dapat digunakan bersamaan?**

Ya. Mereka merupakan tahapan independen dalam pipeline resolusi font yang sama: pertama mesin menyelesaikan ketersediaan font ([replacement](/slides/id/python-net/font-replacement/)/[substitution](/slides/id/python-net/font-substitution/)), kemudian fallback mengisi celah untuk glyph yang hilang pada font yang tersedia.