---
title: Konfigurasikan Koleksi Font Fallback di PHP
linktitle: Koleksi Font Fallback
type: docs
weight: 20
url: /id/php-java/create-fallback-fonts-collection/
keywords:
- font fallback
- aturan fallback
- koleksi font
- konfigurasi font
- menyiapkan font
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Siapkan koleksi font fallback di Aspose.Slides untuk PHP via Java agar teks tetap konsisten dan tajam dalam presentasi PowerPoint dan OpenDocument."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda mengkonfigurasi kumpulan aturan font fallback untuk sebuah presentasi. Setiap aturan fallback direpresentasikan oleh kelas `FontFallBackRule` dan dapat ditambahkan ke `FontFallBackRulesCollection`.

Setelah membuat koleksi, Anda dapat menetapkannya menggunakan metode `setFontFallBackRulesCollection` dari `FontsManager` presentasi. `FontsManager` mengontrol font di seluruh presentasi, dan setiap instance `Presentation` memiliki `FontsManager`‑nya sendiri.

Setelah `FontsManager` diinisialisasi dengan koleksi font fallback, font fallback yang ditentukan akan diterapkan selama render presentasi.

## **Terapkan Aturan Fallback**

Instance kelas [FontFallBackRule](https://reference.aspose.com/slides/id/php-java/aspose.slides/FontFallBackRule) dapat diorganisir ke dalam [FontFallBackRulesCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/FontFallBackRulesCollection). Dimungkinkan untuk menambah atau menghapus aturan dari koleksi tersebut.

Kemudian koleksi ini dapat ditetapkan ke metode [FontFallBackRulesCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/FontFallBackRulesCollection) dari kelas [FontsManager](https://reference.aspose.com/slides/id/php-java/aspose.slides/FontsManager). FontsManager mengontrol font di seluruh presentasi.

Setiap [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation) memiliki metode [getFontsManager](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation#getFontsManager) dengan instance [FontsManager](https://reference.aspose.com/slides/id/php-java/aspose.slides/FontsManager)‑nya sendiri.

Berikut contoh cara membuat koleksi aturan font fallback dan menugaskan ke [FontsManager](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation#getFontsManager) dari sebuah presentasi tertentu:  

```php
  $pres = new Presentation();
  try {
    $userRulesList = new FontFallBackRulesCollection();
    $userRulesList->add(new FontFallBackRule(0xb80, 0xbff, "Vijaya"));
    $userRulesList->add(new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic"));
    $pres->getFontsManager()->setFontFallBackRulesCollection($userRulesList);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Setelah FontsManager diinisialisasi dengan koleksi font fallback, font fallback diterapkan selama render presentasi.

{{% alert color="primary" %}} 
Baca lebih lanjut cara [Render Presentasi dengan Font Fallback](/slides/id/php-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Apakah aturan fallback saya akan disematkan ke dalam file PPTX dan terlihat di PowerPoint setelah disimpan?**

Tidak. Aturan fallback adalah pengaturan rendering pada waktu berjalan; mereka tidak diserialisasi ke dalam PPTX dan tidak akan muncul di antarmuka PowerPoint.

**Apakah fallback berlaku untuk teks di dalam SmartArt, WordArt, diagram, dan tabel?**

Ya. Mekanisme substitusi glif yang sama digunakan untuk semua teks dalam objek-objek tersebut.

**Apakah Aspose mendistribusikan font apa pun bersama pustaka?**

Tidak. Anda menambahkan dan menggunakan font di sisi Anda sendiri dengan tanggung jawab Anda.

**Apakah penggantian/substitusi untuk font yang hilang dan fallback untuk glif yang hilang dapat digunakan bersama?**

Ya. Kedua proses itu merupakan tahapan independen dalam pipeline penyelesaian font yang sama: pertama mesin menyelesaikan ketersediaan font ([replacement](/slides/id/php-java/font-replacement/)/[substitution](/slides/id/php-java/font-substitution/)), kemudian fallback mengisi kekosongan glif yang hilang pada font yang tersedia.