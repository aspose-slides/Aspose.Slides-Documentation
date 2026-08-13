---
title: Konfigurasi Kumpulan Font Fallback pada Android
linktitle: Koleksi Font Fallback
type: docs
weight: 20
url: /id/androidjava/create-fallback-fonts-collection/
keywords:
- font fallback
- aturan fallback
- koleksi font
- konfigurasi font
- menyiapkan font
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Menyiapkan koleksi font fallback di Aspose.Slides untuk Android melalui Java agar teks tetap konsisten dan tajam dalam presentasi PowerPoint dan OpenDocument."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda mengonfigurasi kumpulan aturan font fallback untuk sebuah presentasi. Setiap aturan fallback diwakili oleh kelas `FontFallBackRule` dan dapat ditambahkan ke `FontFallBackRulesCollection`, yang mengimplementasikan antarmuka `IFontFallBackRulesCollection`.

Setelah membuat kumpulan tersebut, Anda dapat menetapkannya ke properti `FontFallBackRulesCollection` dari `FontsManager` presentasi. `FontsManager` mengontrol font di seluruh presentasi, dan setiap instance `Presentation` memiliki `FontsManager`‑nya masing‑masing.

Setelah `FontsManager` diinisialisasi dengan kumpulan font fallback, font fallback yang ditentukan akan diterapkan selama proses rendering presentasi.

## **Terapkan Aturan Fallback**

Instance dari kelas [FontFallBackRule](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/FontFallBackRule) dapat diatur ke dalam [FontFallBackRulesCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/FontFallBackRulesCollection), yang mengimplementasikan antarmuka [IFontFallBackRulesCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IFontFallBackRulesCollection). Anda dapat menambahkan atau menghapus aturan dari kumpulan tersebut.

Kemudian kumpulan ini dapat ditetapkan ke metode [FontFallBackRulesCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/FontFallBackRulesCollection) dari kelas [FontsManager](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/FontsManager). FontsManager mengontrol font di seluruh presentasi.

Setiap [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) memiliki metode [getFontsManager](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation#getFontsManager--) dengan instance [FontsManager](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/FontsManager) miliknya sendiri.

Berikut adalah contoh cara membuat kumpulan aturan font fallback dan menugaskannya ke [FontsManager](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation#getFontsManager--) dari presentasi tertentu:  

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

    userRulesList.add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
    userRulesList.add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

    pres.getFontsManager().setFontFallBackRulesCollection(userRulesList);
} finally {
    if (pres != null) pres.dispose();
}
```

Setelah FontsManager diinisialisasi dengan kumpulan font fallback, font fallback diterapkan selama proses rendering presentasi.

{{% alert color="info" %}} 
Baca lebih lanjut cara [Render Presentasi dengan Font Fallback](/slides/id/androidjava/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Tanya Jawab**

### Apakah aturan fallback saya akan disematkan ke dalam file PPTX dan terlihat di PowerPoint setelah disimpan?

Tidak. Aturan fallback adalah pengaturan rendering pada waktu jalan; mereka tidak diserialisasi ke dalam PPTX dan tidak akan muncul di antarmuka PowerPoint.

### Apakah fallback berlaku untuk teks di dalam SmartArt, WordArt, diagram, dan tabel?

Ya. Mekanisme substitusi glyph yang sama digunakan untuk semua teks dalam objek‑objek tersebut.

### Apakah Aspose mendistribusikan font apa pun bersama pustaka?

Tidak. Anda menambahkan dan menggunakan font di sisi Anda dan atas tanggung jawab Anda sendiri.

### Apakah penggantian/substitusi untuk font yang hilang dan fallback untuk glyph yang hilang dapat digunakan bersama?

Ya. Mereka merupakan tahap independen dalam pipeline resolusi font yang sama: pertama mesin menyelesaikan ketersediaan font ([penggantian](/slides/id/androidjava/font-replacement/)/[substitusi](/slides/id/androidjava/font-substitution/)), kemudian fallback mengisi celah untuk glyph yang hilang pada font yang tersedia.