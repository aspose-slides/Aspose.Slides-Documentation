---
title: Sesuaikan Font PowerPoint di Java
linktitle: Font Kustom
type: docs
weight: 20
url: /id/java/custom-font/
keywords:
- font
- font khusus
- font eksternal
- memuat font
- kelola font
- folder font
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Sesuaikan font dalam slide PowerPoint dengan Aspose.Slides untuk Java agar presentasi Anda tetap tajam dan konsisten di semua perangkat."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda menggunakan font khusus dalam presentasi tanpa menginstalnya pada sistem operasi. Anda dapat memuat font dari folder khusus, menyediakan font untuk presentasi tertentu melalui sumber font tingkat dokumen, atau memuat font eksternal langsung dari data biner.

Font yang dimuat digunakan ketika sebuah presentasi dirender atau diekspor, misalnya ke PDF, gambar, dan format lain yang didukung. Hal ini membantu menjaga konsistensi output presentasi di berbagai lingkungan. Artikel ini juga menjelaskan cara memeriksa folder font yang digunakan oleh Aspose.Slides dan cara membersihkan cache font setelah bekerja dengan font eksternal.

Mendaftarkan font khusus untuk rendering berbeda dari proses menyematkan font ke dalam file PPTX. Jika sebuah font harus disimpan di dalam presentasi itu sendiri, gunakan fitur penyematan font secara eksplisit.

{{% alert color="primary" %}} 
Aspose Slides memungkinkan Anda memuat font ini menggunakan metode [loadExternalFonts](https://reference.aspose.com/slides/id/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Font TrueType (.ttf) dan TrueType Collection (.ttc). Lihat [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Font OpenType (.otf). Lihat [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Muat Font Kustom**

Aspose.Slides memungkinkan Anda memuat font yang digunakan dalam sebuah presentasi tanpa menginstalnya pada sistem. Ini memengaruhi output ekspor—seperti PDF, gambar, dan format lain yang didukung—sehingga dokumen yang dihasilkan terlihat konsisten di semua lingkungan. Font dimuat dari direktori kustom.

1. Tentukan satu atau beberapa folder yang berisi file font.
2. Panggil metode statis [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/id/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) untuk memuat font dari folder tersebut.
3. Muat dan render/ekspor presentasi.
4. Panggil [FontsLoader.clearCache](https://reference.aspose.com/slides/id/java/com.aspose.slides/FontsLoader#clearCache--) untuk membersihkan cache font.

Contoh kode berikut memperlihatkan proses pemuatan font:

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
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/id/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) menambahkan folder tambahan ke jalur pencarian font, tetapi tidak mengubah urutan inisialisasi font.  
Font diinisialisasi dalam urutan berikut:

1. Jalur font default sistem operasi.  
1. Jalur yang dimuat melalui [FontsLoader](https://reference.aspose.com/slides/id/java/com.aspose.slides/fontsloader/).

{{%/alert %}}

## **Dapatkan Folder Font Kustom**
Aspose.Slides menyediakan metode [getFontFolders](https://reference.aspose.com/slides/id/java/com.aspose.slides/fontsloader/#getFontFolders--) untuk memungkinkan Anda menemukan folder font. Metode ini mengembalikan folder yang ditambahkan melalui metode `LoadExternalFonts` serta folder font sistem.

Kode Java berikut menunjukkan cara menggunakan [getFontFolders](https://reference.aspose.com/slides/id/java/com.aspose.slides/fontsloader/#getFontFolders--):

```java
// Baris ini menampilkan folder tempat file font dicari.
// Itu adalah folder yang ditambahkan melalui metode LoadExternalFonts dan folder font sistem.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Tentukan Font Kustom yang Digunakan pada Presentasi**
Aspose.Slides menyediakan properti [setDocumentLevelFontSources](https://reference.aspose.com/slides/id/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) untuk memungkinkan Anda menentukan font eksternal yang akan digunakan pada presentasi.

Kode Java berikut menunjukkan cara menggunakan properti [setDocumentLevelFontSources](https://reference.aspose.com/slides/id/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

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

## **Kelola Font Secara Eksternal**

Aspose.Slides menyediakan metode [loadExternalFont](https://reference.aspose.com/slides/id/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) untuk memungkinkan Anda memuat font eksternal dari data biner.

Kode Java berikut memperlihatkan proses pemuatan font dari array byte:

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

Tidak. Mendaftarkan font untuk rendering bukanlah hal yang sama dengan menyematkannya ke dalam PPTX. Jika Anda memerlukan font berada di dalam file presentasi, Anda harus menggunakan fitur [penyematan secara eksplisit](/slides/id/java/embedded-font/).

**Bisakah saya mengontrol perilaku fallback ketika sebuah font kustom tidak memiliki glyph tertentu?**

Ya. Konfigurasikan [penggantian font](/slides/id/java/font-substitution/), [aturan penggantian](/slides/id/java/font-replacement/), dan [set fallback](/slides/id/java/fallback-font/) untuk mendefinisikan secara tepat font mana yang digunakan saat glyph yang diminta tidak tersedia.

**Apakah saya dapat menggunakan font di kontainer Linux/Docker tanpa menginstalnya secara sistem-wide?**

Ya. Arahkan ke folder font Anda sendiri atau muat font dari array byte. Ini menghilangkan ketergantungan pada direktori font sistem dalam image kontainer.

**Bagaimana dengan lisensi—apakah saya dapat menyematkan font kustom apa saja tanpa batasan?**

Anda bertanggung jawab atas kepatuhan lisensi font. Persyaratan bervariasi; beberapa lisensi melarang penyematan atau penggunaan komersial. Selalu tinjau EULA font sebelum mendistribusikan hasil.