---
title: Konfigurasi Koleksi Font Fallback di C++
linktitle: Koleksi Font Fallback
type: docs
weight: 20
url: /id/cpp/create-fallback-fonts-collection/
keywords:
- font fallback
- aturan fallback
- koleksi font
- konfigurasi font
- menyiapkan font
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Siapkan koleksi font fallback di Aspose.Slides untuk C++ agar teks tetap konsisten dan tajam dalam presentasi PowerPoint dan OpenDocument."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda mengonfigurasi kumpulan aturan font fallback untuk sebuah presentasi. Setiap aturan fallback diwakili oleh kelas `FontFallBackRule` dan dapat ditambahkan ke `FontFallBackRulesCollection`, yang mengimplementasikan antarmuka `IFontFallBackRulesCollection`.

Setelah membuat koleksi, Anda dapat menetapkannya menggunakan metode `set_FontFallBackRulesCollection` dari `FontsManager` presentasi. `FontsManager` mengontrol font di seluruh presentasi, dan setiap instance `Presentation` memiliki `FontsManager`‑nya sendiri.

Setelah `FontsManager` diinisialisasi dengan koleksi font fallback, font fallback yang ditentukan akan diterapkan selama proses rendering presentasi.

## **Terapkan Aturan Fallback**

Instansi kelas [FontFallBackRule](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontfallbackrule/) dapat diatur ke dalam [FontFallBackRulesCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontfallbackrulescollection/) yang mengimplementasikan antarmuka [IFontFallBackRulesCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/ifontfallbackrulescollection/). Dimungkinkan untuk menambah atau menghapus aturan dari koleksi.

Kemudian koleksi ini dapat diteruskan ke metode [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) dari kelas [FontsManager](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsmanager/). FontsManager mengontrol font di seluruh presentasi.

Setiap [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) memiliki metode [get_FontsManager()](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_fontsmanager/) dengan instance sendiri dari kelas FontsManager.

Berikut contoh cara membuat koleksi aturan font fallback dan menetapkannya ke FontsManager pada presentasi tertentu:

``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

Setelah FontsManager diinisialisasi dengan koleksi font fallback, font fallback diterapkan selama proses rendering presentasi.

{{% alert color="primary" %}} 
Baca selengkapnya cara [Render Presentation with Fallback Font](/slides/id/cpp/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Apakah aturan fallback saya akan disematkan ke dalam file PPTX dan terlihat di PowerPoint setelah disimpan?**

Tidak. Aturan fallback adalah pengaturan rendering waktu jalan; mereka tidak diserialisasi ke dalam PPTX dan tidak akan muncul di antarmuka PowerPoint.

**Apakah fallback berlaku untuk teks di dalam SmartArt, WordArt, grafik, dan tabel?**

Ya. Mekanisme substitusi glif yang sama digunakan untuk semua teks dalam objek-objek tersebut.

**Apakah Aspose mendistribusikan font apapun bersama perpustakaan?**

Tidak. Anda menambahkan dan menggunakan font di sisi Anda sendiri dan dengan tanggung jawab Anda.

**Apakah penggantian/substitusi untuk font yang hilang dan fallback untuk glif yang hilang dapat digunakan bersamaan?**

Ya. Mereka adalah tahap independen dari pipeline resolusi font yang sama: pertama mesin menyelesaikan ketersediaan font ([replacement](/slides/id/cpp/font-replacement/)/[substitution](/slides/id/cpp/font-substitution/)), kemudian fallback mengisi celah untuk glif yang hilang pada font yang tersedia.