---
title: Konfigurasi Koleksi Font Fallback di Android
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
description: "Menyiapkan koleksi font fallback di Aspose.Slides untuk Android via Java agar teks tetap konsisten dan tajam dalam presentasi PowerPoint dan OpenDocument."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda mengonfigurasi kumpulan aturan font fallback untuk presentasi. Setiap aturan fallback direpresentasikan oleh kelas `FontFallBackRule` dan dapat ditambahkan ke `FontFallBackRulesCollection`, yang mengimplementasikan antarmuka `IFontFallBackRulesCollection`.

Setelah membuat koleksi, Anda dapat menetapkannya ke properti `FontFallBackRulesCollection` dari `FontsManager` presentasi. `FontsManager` mengontrol font di seluruh presentasi, dan setiap instance `Presentation` memiliki `FontsManager` masing‑masing.

Setelah `FontsManager` diinisialisasi dengan koleksi font fallback, font fallback yang ditentukan akan diterapkan selama proses render presentasi.

## **Terapkan Aturan Fallback**

Instansi kelas [FontFallBackRule](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/FontFallBackRule) dapat diatur menjadi [FontFallBackRulesCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/FontFallBackRulesCollection), yang mengimplementasikan antarmuka [IFontFallBackRulesCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IFontFallBackRulesCollection). Dimungkinkan untuk menambahkan atau menghapus aturan dari koleksi.

Kemudian koleksi ini dapat ditetapkan ke metode [FontFallBackRulesCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/FontFallBackRulesCollection) dari kelas [FontsManager](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/FontsManager). FontsManager mengontrol font di seluruh presentasi.

Setiap [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) memiliki metode [getFontsManager](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation#getFontsManager--) dengan instance [FontsManager](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/FontsManager) miliknya sendiri.

Berikut contoh cara membuat koleksi aturan font fallback dan menetapkannya ke [FontsManager](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation#getFontsManager--) pada presentasi tertentu:

```java
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

Setelah FontsManager diinisialisasi dengan koleksi font fallback, font fallback diterapkan selama proses render presentasi.

{{% alert color="primary" %}} 
Baca selengkapnya cara [Render Presentasi dengan Font Fallback](/slides/id/androidjava/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Tanya Jawab**

**Apakah aturan fallback saya akan disematkan ke dalam file PPTX dan terlihat di PowerPoint setelah disimpan?**

Tidak. Aturan fallback adalah pengaturan rendering waktu‑jalan; mereka tidak diserialisasi ke dalam PPTX dan tidak akan muncul di antarmuka PowerPoint.

**Apakah fallback berlaku untuk teks di dalam SmartArt, WordArt, diagram, dan tabel?**

Ya. Mekanisme substitusi glif yang sama digunakan untuk semua teks dalam objek‑objek tersebut.

**Apakah Aspose mendistribusikan font apa pun bersama pustaka?**

Tidak. Anda menambahkan dan menggunakan font di sisi Anda dan sepenuhnya menjadi tanggung jawab Anda.

**Dapatkah penggantian/substitusi untuk font yang hilang dan fallback untuk glif yang hilang digunakan bersamaan?**

Ya. Mereka merupakan tahap independen dalam pipeline resolusi font yang sama: pertama mesin menyelesaikan ketersediaan font ([penggantian](/slides/id/androidjava/font-replacement/)/[substitusi](/slides/id/androidjava/font-substitution/)), kemudian fallback mengisi kekosongan untuk glif yang hilang pada font yang tersedia.