---
title: Sesuaikan Font PowerPoint di JavaScript
linktitle: Font Kustom
type: docs
weight: 20
url: /id/nodejs-java/custom-font/
keywords:
- font
- font kustom
- font eksternal
- memuat font
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
## **Overview**

Aspose.Slides memungkinkan Anda menggunakan font khusus dalam presentasi tanpa harus menginstalnya di sistem operasi. Anda dapat memuat font dari folder khusus, menyediakan font untuk presentasi tertentu melalui sumber font tingkat dokumen, atau memuat font eksternal langsung dari data biner.

Font yang dimuat akan digunakan saat presentasi dirender atau diekspor, misalnya ke PDF, gambar, dan format lain yang didukung. Hal ini membantu menjaga konsistensi output presentasi di berbagai lingkungan. Artikel ini juga menjelaskan cara memeriksa folder font yang digunakan oleh Aspose.Slides dan cara membersihkan cache font setelah bekerja dengan font eksternal.

Mendaftarkan font khusus untuk rendering berbeda dari menyematkan font ke dalam file PPTX. Jika font harus disimpan di dalam presentasi itu sendiri, gunakan fitur penyematan font secara eksplisit.

Tema presentasi dapat merujuk ke keluarga font yang berbeda untuk masing‑masing sistem penulisan. Pemetaannya menyimpan nama font tetapi tidak menginstal atau memuat file font. Lihat [Font Tema Spesifik Skrip](/slides/id/nodejs-java/script-specific-font-mappings/) untuk mengelola pemetaan, dan gunakan opsi pemuatan di bawah ini agar font yang dirujuk tersedia untuk rendering yang konsisten.

{{% alert color="info" title="Note" %}}
Aspose Slides memungkinkan Anda memuat font ini menggunakan metode [loadExternalFonts](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Font TrueType (.ttf) dan TrueType Collection (.ttc). Lihat [TrueType](https://en.wikipedia.org/wiki/TrueType).
* Font OpenType (.otf). Lihat [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Load Custom Fonts**

Aspose.Slides memungkinkan Anda memuat font yang digunakan dalam sebuah presentasi tanpa menginstalnya di sistem. Hal ini memengaruhi output ekspor—seperti PDF, gambar, dan format lain yang didukung—sehingga dokumen yang dihasilkan tampak konsisten di semua lingkungan. Font dimuat dari direktori khusus.

1. Tentukan satu atau beberapa folder yang berisi file font.
2. Panggil metode statis [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) untuk memuat font dari folder tersebut.
3. Muat dan render/ekspor presentasi.
4. Panggil [FontsLoader.clearCache](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsloader/clearcache/) untuk membersihkan cache font.

Contoh kode berikut memperlihatkan proses pemuatan font:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Tentukan folder yang berisi file font khusus.
let externalFontFolder1 = "fonts";
let externalFontFolder2 = "extra-fonts";
let fontFolders = java.newArray("java.lang.String", [externalFontFolder1, externalFontFolder2]);

// Muat font khusus dari folder yang ditentukan.
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

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) menambahkan folder tambahan ke jalur pencarian font, tetapi tidak mengubah urutan inisialisasi font.  
Font diinisialisasi dalam urutan berikut:

1. Jalur font sistem operasi default.  
2. Jalur yang dimuat melalui [FontsLoader](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsloader/).
{{%/alert %}}

## **Get Custom Fonts Folder**

Aspose.Slides menyediakan metode [getFontFolders](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) untuk memungkinkan Anda menemukan folder font. Metode ini mengembalikan folder yang ditambahkan melalui metode `LoadExternalFonts` serta folder font sistem.

Kode JavaScript berikut menunjukkan cara menggunakan [getFontFolders](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsloader/#getFontFolders--):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Baris ini menampilkan folder tempat file font dicari.
// Itu adalah folder yang ditambahkan melalui metode LoadExternalFonts dan folder font sistem.
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```

## **Specify Custom Fonts Used With Presentation**

Aspose.Slides menyediakan properti [setDocumentLevelFontSources](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) untuk memungkinkan Anda menentukan font eksternal yang akan digunakan dengan presentasi.

Kode JavaScript berikut menunjukkan cara menggunakan properti [setDocumentLevelFontSources](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

## **Manage Fonts Externally**

Aspose.Slides menyediakan metode [loadExternalFont](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) untuk memungkinkan Anda memuat font eksternal dari data biner.

Kode JavaScript berikut mendemonstrasikan proses pemuatan font dari array byte:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

### Apakah font khusus memengaruhi ekspor ke semua format (PDF, PNG, SVG, HTML)?

Ya. Font yang terhubung digunakan oleh renderer di semua format ekspor.

### Apakah font khusus otomatis disematkan ke dalam PPTX yang dihasilkan?

Tidak. Mendaftarkan font untuk rendering bukanlah hal yang sama dengan menyematkannya ke dalam PPTX. Jika Anda membutuhkan font berada di dalam file presentasi, Anda harus menggunakan [fitur penyematan](/slides/id/nodejs-java/embedded-font/).

### Bisakah saya mengontrol perilaku fallback ketika sebuah font khusus tidak memiliki glyph tertentu?

Ya. Konfigurasikan [penggantian font](/slides/id/nodejs-java/font-substitution/), [aturan pengganti](/slides/id/nodejs-java/font-replacement/), dan [set fallback](/slides/id/nodejs-java/fallback-font/) untuk menentukan font mana yang digunakan ketika glyph yang diminta tidak ada.

### Bisakah saya menggunakan font di kontainer Linux/Docker tanpa menginstalnya secara sistem?

Ya. Arahkan ke folder font Anda sendiri atau muat font dari array byte. Ini menghilangkan ketergantungan pada direktori font sistem dalam gambar kontainer.

### Bagaimana dengan lisensi—apakah saya dapat menyematkan font khusus apa saja tanpa batasan?

Anda bertanggung jawab atas kepatuhan lisensi font. Persyaratan bervariasi; beberapa lisensi melarang penyematan atau penggunaan komersial. Selalu tinjau EULA font sebelum mendistribusikan output.