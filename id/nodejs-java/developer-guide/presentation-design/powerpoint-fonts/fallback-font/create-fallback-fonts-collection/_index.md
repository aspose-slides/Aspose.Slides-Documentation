---
title: Mengonfigurasi Kumpulan Font Fallback dalam JavaScript
linktitle: Kumpulan Font Fallback
type: docs
weight: 20
url: /id/nodejs-java/create-fallback-fonts-collection/
keywords:
- font fallback
- aturan fallback
- kumpulan font
- konfigurasi font
- menyiapkan font
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Siapkan kumpulan font fallback dalam JavaScript dengan Aspose.Slides untuk Node.js agar teks tetap konsisten dan tajam dalam presentasi PowerPoint dan OpenDocument."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda mengonfigurasi kumpulan aturan font fallback untuk sebuah presentasi. Setiap aturan fallback direpresentasikan oleh kelas `FontFallBackRule` dan dapat ditambahkan ke `FontFallBackRulesCollection`.

Setelah membuat kumpulan tersebut, Anda dapat menugaskannya menggunakan metode `setFontFallBackRulesCollection` dari `FontsManager` presentasi. `FontsManager` mengontrol font di seluruh presentasi, dan setiap instance `Presentation` memiliki `FontsManager` miliknya sendiri.

Setelah `FontsManager` diinisialisasi dengan kumpulan font fallback, font fallback yang ditentukan akan diterapkan selama proses render presentasi.

## **Terapkan Aturan Fallback**

Instansi kelas [FontFallBackRule](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/FontFallBackRule) dapat diorganisir ke dalam [FontFallBackRulesCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/FontFallBackRulesCollection), yang mengimplementasikan kelas [FontFallBackRulesCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/FontFallBackRulesCollection). Anda dapat menambah atau menghapus aturan dari kumpulan tersebut.

Kemudian kumpulan ini dapat ditugaskan ke metode [FontFallBackRulesCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/FontFallBackRulesCollection) dari kelas [FontsManager](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/FontsManager). FontsManager mengontrol font di seluruh presentasi.

Setiap [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) memiliki metode [getFontsManager](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation#getFontsManager--) dengan instance [FontsManager](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/FontsManager) miliknya sendiri.

Berikut contoh cara membuat kumpulan aturan font fallback dan menugaskannya ke [FontsManager](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation#getFontsManager--) pada presentasi tertentu:  

```javascript
var pres = new aspose.slides.Presentation();
try {
    var userRulesList = new aspose.slides.FontFallBackRulesCollection();
    userRulesList.add(new aspose.slides.FontFallBackRule(0xb80, 0xbff, "Vijaya"));
    userRulesList.add(new aspose.slides.FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic"));
    pres.getFontsManager().setFontFallBackRulesCollection(userRulesList);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Setelah FontsManager diinisialisasi dengan kumpulan font fallback, font fallback akan diterapkan selama proses render presentasi.

{{% alert color="primary" %}} 
Baca lebih lanjut cara [Render Presentation with Fallback Font](/slides/id/nodejs-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Apakah aturan fallback saya akan disematkan ke dalam file PPTX dan terlihat di PowerPoint setelah disimpan?**

Tidak. Aturan fallback adalah pengaturan render waktu jalan; mereka tidak diserialisasi ke dalam PPTX dan tidak akan muncul di antarmuka PowerPoint.

**Apakah fallback berlaku untuk teks di dalam SmartArt, WordArt, diagram, dan tabel?**

Ya. Mekanisme substitusi glif yang sama digunakan untuk teks apa pun dalam objek-objek tersebut.

**Apakah Aspose mendistribusikan font apa pun bersama perpustakaan?**

Tidak. Anda menambahkan dan menggunakan font di sisi Anda sendiri dan dengan tanggung jawab Anda sendiri.

**Apakah penggantian/substitusi untuk font yang hilang dan fallback untuk glif yang hilang dapat digunakan bersamaan?**

Ya. Mereka adalah tahap independen dari pipeline resolusi font yang sama: pertama mesin menyelesaikan ketersediaan font ([replacement](/slides/id/nodejs-java/font-replacement/)/[substitution](/slides/id/nodejs-java/font-substitution/)), kemudian fallback mengisi kekosongan untuk glif yang hilang pada font yang tersedia.