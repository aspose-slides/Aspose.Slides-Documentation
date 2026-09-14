---
title: Konfigurasi Koleksi Font Fallback di Python melalui Java
linktitle: Koleksi Font Fallback
type: docs
weight: 20
url: /id/python-java/create-fallback-fonts-collection/
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
- Java
- Aspose.Slides
description: "Siapkan koleksi font fallback di Aspose.Slides untuk Python melalui Java agar teks tetap konsisten dan tajam dalam presentasi PowerPoint dan OpenDocument."
---
## **Ikhtisar**

Aspose.Slides memungkinkan Anda mengkonfigurasi kumpulan aturan font fallback untuk sebuah presentasi. Setiap aturan fallback direpresentasikan oleh kelas [FontFallBackRule](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontfallbackrule/) dan dapat ditambahkan ke [FontFallBackRulesCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontfallbackrulescollection/).

Setelah membuat kumpulan tersebut, Anda dapat menugaskannya menggunakan metode [setFontFallBackRulesCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) dari [FontsManager](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsmanager/) presentasi. [FontsManager](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsmanager/) mengontrol font di seluruh presentasi, dan setiap instance [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) memiliki [FontsManager](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsmanager/) masing‑mereknya.

Setelah [FontsManager](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsmanager/) diinisialisasi dengan koleksi font fallback, font fallback yang ditentukan akan diterapkan saat rendering presentasi.

## **Terapkan Aturan Fallback**

Instansi kelas [FontFallBackRule](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontfallbackrule/) dapat diorganisasikan ke dalam [FontFallBackRulesCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontfallbackrulescollection/). Anda dapat menambah atau menghapus aturan dari koleksi tersebut.

Koleksi ini kemudian dapat ditugaskan menggunakan metode [setFontFallBackRulesCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) dari kelas [FontsManager](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsmanager/), yang mengontrol font di seluruh presentasi.

Setiap [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) memiliki metode [getFontsManager](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getFontsManager) yang mengembalikan instance [FontsManager](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsmanager/) miliknya sendiri.

Contoh berikut menunjukkan cara membuat koleksi aturan font fallback dan menugaskannya ke [FontsManager](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsmanager/) sebuah presentasi:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule, FontFallBackRulesCollection, Presentation

presentation = Presentation()
try:
    fallback_rules = FontFallBackRulesCollection()

    tamil_rule = FontFallBackRule(0x0B80, 0x0BFF, "Vijaya")
    fallback_rules.add(tamil_rule)
    hiragana_rule = FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")
    fallback_rules.add(hiragana_rule)

    presentation.getFontsManager().setFontFallBackRulesCollection(fallback_rules)
finally:
    presentation.dispose()
```

Setelah [FontsManager](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsmanager/) diinisialisasi dengan koleksi font fallback, font fallback akan diterapkan selama proses rendering presentasi.

{{% alert color="info" title="Note" %}}
Baca lebih lanjut tentang cara [menampilkan presentasi dengan font fallback](/slides/id/python-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Apakah aturan fallback saya akan disematkan ke dalam file PPTX dan terlihat di PowerPoint setelah disimpan?**

Tidak. Aturan fallback adalah pengaturan rendering waktu jalan; mereka tidak diserialisasi ke dalam PPTX dan tidak akan muncul di UI PowerPoint.

**Apakah fallback berlaku untuk teks di dalam SmartArt, WordArt, bagan, dan tabel?**

Ya. Mekanisme substitusi glif yang sama digunakan untuk setiap teks dalam objek-objek ini.

**Apakah Aspose mendistribusikan font apa pun bersama perpustakaan?**

Tidak. Anda menambahkan dan menggunakan font di sisi Anda sendiri dengan tanggung jawab Anda.

**Bisakah penggantian/substitusi untuk font yang hilang dan fallback untuk glif yang hilang digunakan bersamaan?**

Ya. Mereka merupakan tahap independen dalam pipeline resolusi font yang sama: pertama mesin menyelesaikan ketersediaan font ([replacement](/slides/id/python-java/font-replacement/)/[substitution](/slides/id/python-java/font-substitution/)), kemudian fallback mengisi kekosongan untuk glif yang hilang dalam font yang tersedia.