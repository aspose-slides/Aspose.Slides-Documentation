---
title: Sesuaikan Font PowerPoint di Android
linktitle: Font Kustom
type: docs
weight: 20
url: /id/androidjava/custom-font/
keywords:
- font
- font khusus
- font eksternal
- memuat font
- mengelola font
- folder font
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Sesuaikan font dalam slide PowerPoint dengan Aspose.Slides untuk Android via Java agar presentasi Anda tetap tajam dan konsisten di semua perangkat."
---
## **Ikhtisar**

Aspose.Slides memungkinkan Anda menggunakan font kustom dalam presentasi tanpa menginstalnya pada sistem operasi. Anda dapat memuat font dari folder kustom, menyediakan font untuk presentasi tertentu melalui sumber font tingkat dokumen, atau memuat font eksternal langsung dari data biner.

Font yang dimuat digunakan saat presentasi dirender atau diekspor, misalnya ke PDF, gambar, dan format lain yang didukung. Hal ini membantu menjaga output presentasi tetap konsisten di berbagai lingkungan. Artikel ini juga menjelaskan cara memeriksa folder font yang digunakan oleh Aspose.Slides dan cara menghapus cache font setelah bekerja dengan font eksternal.

Pendaftaran font kustom untuk rendering terpisah dari proses menyematkan font ke dalam file PPTX. Jika sebuah font harus disimpan di dalam presentasi itu sendiri, gunakan fitur penyematan font secara eksplisit.

{{% alert color="primary" %}} 
Aspose Slides memungkinkan Anda memuat font ini menggunakan metode [loadExternalFonts](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* TrueType (.ttf) dan TrueType Collection (.ttc). Lihat [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf). Lihat [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Memuat Font Kustom**

Aspose.Slides memungkinkan Anda memuat font yang digunakan dalam presentasi tanpa menginstalnya pada sistem. Hal ini memengaruhi output ekspor—seperti PDF, gambar, dan format lain yang didukung—sehingga dokumen yang dihasilkan tampak konsisten di berbagai lingkungan. Font dimuat dari direktori kustom.

1. Tentukan satu atau beberapa folder yang berisi file font.
2. Panggil metode statis [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) untuk memuat font dari folder tersebut.
3. Muat dan render/ekspor presentasi.
4. Panggil [FontsLoader.clearCache](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/FontsLoader#clearCache--) untuk menghapus cache font.

Contoh kode berikut menunjukkan proses pemuatan font:

```java
// Tentukan folder yang berisi file font khusus.
String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// Muat font khusus dari folder yang ditentukan.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");
    
    // Render/ekspor presentasi (mis., ke PDF, gambar, atau format lain) menggunakan font yang dimuat.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Bersihkan cache font setelah pekerjaan selesai.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Catatan" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) menambahkan folder tambahan ke jalur pencarian font, tetapi tidak mengubah urutan inisialisasi font.
Font diinisialisasi dalam urutan berikut:

1. Jalur font sistem operasi default.
1. Jalur yang dimuat melalui [FontsLoader](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/fontsloader/).
{{%/alert %}}

## **Mendapatkan Folder Font Kustom**
Aspose.Slides menyediakan metode [getFontFolders](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) yang memungkinkan Anda menemukan folder font. Metode ini mengembalikan folder yang ditambahkan melalui metode `LoadExternalFonts` dan folder font sistem.

Kode Java berikut menunjukkan cara menggunakan [getFontFolders](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/fontsloader/#getFontFolders--):

```java
// Baris ini menampilkan folder tempat file font dicari.
// Itu adalah folder yang ditambahkan melalui metode LoadExternalFonts dan folder font sistem.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Menentukan Font Kustom yang Digunakan dengan Presentasi**
Aspose.Slides menyediakan properti [setDocumentLevelFontSources](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) yang memungkinkan Anda menentukan font eksternal yang akan digunakan dengan presentasi.

Kode Java berikut menunjukkan cara menggunakan properti [setDocumentLevelFontSources](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // Bekerja dengan presentasi
    // CustomFont1, CustomFont2, dan font dari folder assets\fonts & global\fonts serta subfoldernya tersedia untuk presentasi
} finally {
    if (pres != null) pres.dispose();
}
```

## **Mengelola Font Secara Eksternal**

Aspose.Slides menyediakan metode [loadExternalFont](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) yang memungkinkan Anda memuat font eksternal dari data biner.

Kode Java berikut menunjukkan proses pemuatan font dari array byte:

```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // font eksternal dimuat selama masa hidup presentasi
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **FAQ**

**Apakah font kustom memengaruhi ekspor ke semua format (PDF, PNG, SVG, HTML)?**

Ya. Font yang terhubung digunakan oleh renderer pada semua format ekspor.

**Apakah font kustom secara otomatis disematkan ke dalam PPTX yang dihasilkan?**

Tidak. Mendaftarkan font untuk rendering bukanlah hal yang sama dengan menyematkannya ke dalam PPTX. Jika Anda memerlukan font berada di dalam file presentasi, Anda harus menggunakan [fitur penyematan](/slides/id/androidjava/embedded-font/).

**Apakah saya dapat mengontrol perilaku fallback ketika sebuah font kustom tidak memiliki glyph tertentu?**

Ya. Konfigurasikan [substitusi font](/slides/id/androidjava/font-substitution/), [aturan penggantian](/slides/id/androidjava/font-replacement/), dan [set fallback](/slides/id/androidjava/fallback-font/) untuk menentukan secara tepat font mana yang digunakan ketika glyph yang diminta tidak ada.

**Apakah saya dapat menggunakan font di kontainer Linux/Docker tanpa menginstalnya secara sistem-wide?**

Ya. Arahkan ke folder font Anda sendiri atau muat font dari array byte. Ini menghilangkan ketergantungan pada direktori font sistem dalam image kontainer.

**Bagaimana dengan lisensi—apakah saya dapat menyematkan font kustom apa pun tanpa batasan?**

Anda bertanggung jawab atas kepatuhan lisensi font. Persyaratannya bervariasi; beberapa lisensi melarang penyematan atau penggunaan komersial. Selalu tinjau EULA font sebelum mendistribusikan output.