---
title: Sesuaikan Font PowerPoint dengan JavaScript
linktitle: Font Kustom
type: docs
weight: 20
url: /id/nodejs-java/custom-font/
keywords:
- font
- font kustom
- font eksternal
- muat font
- kelola font
- folder font
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Sesuaikan font dalam slide PowerPoint dengan JavaScript dan Aspose.Slides untuk Node.js melalui Java agar presentasi Anda tetap tajam dan konsisten di semua perangkat."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda menggunakan font kustom dalam presentasi tanpa menginstalnya di sistem operasi. Anda dapat memuat font dari folder kustom, menyediakan font untuk presentasi tertentu melalui sumber font tingkat dokumen, atau memuat font eksternal langsung dari data biner.

Font yang dimuat digunakan ketika presentasi dirender atau diekspor, misalnya ke PDF, gambar, dan format lain yang didukung. Hal ini membantu menjaga konsistensi keluaran presentasi di berbagai lingkungan. Artikel ini juga menjelaskan cara memeriksa folder font yang digunakan oleh Aspose.Slides dan cara membersihkan cache font setelah bekerja dengan font eksternal.

Mendaftarkan font kustom untuk rendering terpisah dari proses menyematkan font ke dalam file PPTX. Jika font harus disimpan di dalam presentasi itu sendiri, gunakan fitur penyematan font secara eksplisit.

{{% alert color="primary" %}} 

Aspose Slides memungkinkan Anda memuat font ini menggunakan metode [loadExternalFonts](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* TrueType (.ttf) dan TrueType Collection (.ttc). Lihat [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf). Lihat [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Muat Font Kustom**

Aspose.Slides memungkinkan Anda memuat font yang digunakan dalam presentasi tanpa menginstalnya di sistem. Ini memengaruhi output ekspor—seperti PDF, gambar, dan format lain yang didukung—sehingga dokumen yang dihasilkan terlihat konsisten di seluruh lingkungan. Font dimuat dari direktori kustom.

1. Tentukan satu atau beberapa folder yang berisi file font.
2. Panggil metode statis [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) untuk memuat font dari folder tersebut.
3. Muat dan render/ekspor presentasi.
4. Panggil [FontsLoader.clearCache](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsloader/clearcache/) untuk membersihkan cache font.

Contoh kode berikut memperlihatkan proses pemuatan font:

```js
// Tentukan folder yang berisi file font kustom.
let fontFolders = java.newArray("java.lang.String", [externalFontFolder1, externalFontFolder2]);

// Muat font kustom dari folder yang ditentukan.
aspose.slides.FontsLoader.loadExternalFonts(fontFolders);

let presentation = null;
try {
    presentation = new aspose.slides.Presentation("sample.pptx");
    
    // Render/ekspor presentasi (mis., ke PDF, gambar, atau format lain) menggunakan font yang dimuat.
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Bersihkan cache font setelah pekerjaan selesai.
    aspose.slides.FontsLoader.clearCache();
}
```

{{% alert color="info" title="Catatan" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) menambahkan folder tambahan ke jalur pencarian font, tetapi tidak mengubah urutan inisialisasi font.
Font diinisialisasi dalam urutan berikut:

1. Jalur font default sistem operasi.
1. Jalur yang dimuat melalui [FontsLoader](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsloader/).

{{%/alert %}}

## **Dapatkan Folder Font Kustom**
Aspose.Slides menyediakan metode [getFontFolders](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) untuk memungkinkan Anda menemukan folder font. Metode ini mengembalikan folder yang ditambahkan melalui metode `LoadExternalFonts` serta folder font sistem.

Kode JavaScript berikut menunjukkan cara menggunakan [getFontFolders](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsloader/#getFontFolders--):

```javascript
// Baris ini menampilkan folder tempat file font dicari.
// Itu adalah folder yang ditambahkan melalui metode LoadExternalFonts dan folder font sistem.
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```

## **Tentukan Font Kustom yang Digunakan dengan Presentasi**
Aspose.Slides menyediakan properti [setDocumentLevelFontSources](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) untuk memungkinkan Anda menentukan font eksternal yang akan digunakan dengan presentasi.

Kode JavaScript berikut menunjukkan cara menggunakan properti [setDocumentLevelFontSources](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-):

```javascript
var memoryFont1 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont1.ttf"));
var memoryFont2 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont2.ttf"));
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(java.newArray("java.lang.String", ["assets/fonts", "global/fonts"]));
loadOptions.getDocumentLevelFontSources().setMemoryFonts(java.newArray("[B", [java.newArray("byte", ["item1", "item2", "item3"])]));
var pres = new aspose.slides.Presentation("MyPresentation.pptx", loadOptions);
try {
    // Bekerja dengan presentasi
    // CustomFont1, CustomFont2, dan font dari folder assets\fonts & global\fonts serta subfoldernya tersedia untuk presentasi
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Kelola Font Secara Eksternal**

Aspose.Slides menyediakan metode [loadExternalFont](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) untuk memungkinkan Anda memuat font eksternal dari data biner.

Kode JavaScript berikut mendemonstrasikan proses pemuatan font dari array byte:

```javascript
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALN.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNBI.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNI.TTF")));
try {
    var pres = new aspose.slides.Presentation("");
    try {
        // font eksternal dimuat selama masa hidup presentasi
    } finally {
    }
} finally {
    java.callStaticMethodSync("com.aspose.slides.FontsLoader", "clearCache");
}
```

## **FAQ**

**Apakah font kustom memengaruhi ekspor ke semua format (PDF, PNG, SVG, HTML)?**

Ya. Font yang terhubung digunakan oleh renderer pada semua format ekspor.

**Apakah font kustom secara otomatis disematkan ke dalam PPTX yang dihasilkan?**

Tidak. Mendaftarkan font untuk rendering bukanlah hal yang sama dengan menyematkannya ke dalam PPTX. Jika Anda memerlukan font yang dibawa di dalam file presentasi, Anda harus menggunakan fitur [embedding](/slides/id/nodejs-java/embedded-font/) secara eksplisit.

**Apakah saya dapat mengontrol perilaku fallback ketika font kustom tidak memiliki glyph tertentu?**

Ya. Konfigurasikan [font substitution](/slides/id/nodejs-java/font-substitution/), [replacement rules](/slides/id/nodejs-java/font-replacement/), dan [fallback sets](/slides/id/nodejs-java/fallback-font/) untuk menentukan font mana yang digunakan ketika glyph yang diminta tidak ada.

**Apakah saya dapat menggunakan font di kontainer Linux/Docker tanpa menginstalnya secara sistem-wide?**

Ya. Arahkan ke folder font Anda sendiri atau muat font dari array byte. Ini menghilangkan ketergantungan pada direktori font sistem di dalam image kontainer.

**Bagaimana dengan lisensi—apakah saya dapat menyematkan font kustom apa pun tanpa batasan?**

Anda bertanggung jawab atas kepatuhan lisensi font. Persyaratan bervariasi; beberapa lisensi melarang penyematan atau penggunaan komersial. Selalu tinjau EULA font sebelum mendistribusikan output.