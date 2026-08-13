---
title: Sesuaikan Font PowerPoint di Android
linktitle: Font Kustom
type: docs
weight: 20
url: /id/androidjava/custom-font/
keywords:
- font
- font kustom
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
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda menggunakan font khusus dalam presentasi tanpa menginstalnya di sistem operasi. Anda dapat memuat font dari folder khusus, menyediakan font untuk presentasi tertentu melalui sumber font tingkat dokumen, atau memuat font eksternal langsung dari data biner.

Font yang dimuat digunakan saat presentasi dirender atau diekspor, misalnya ke PDF, gambar, dan format lain yang didukung. Hal ini membantu menjaga keluaran presentasi tetap konsisten di berbagai lingkungan. Artikel ini juga menjelaskan cara memeriksa folder font yang digunakan oleh Aspose.Slides dan cara membersihkan cache font setelah bekerja dengan font eksternal.

Mendaftarkan font khusus untuk rendering berbeda dari menyematkan font ke dalam file PPTX. Jika sebuah font harus disimpan di dalam presentasi itu sendiri, gunakan fitur penyematan font secara eksplisit.

{{% alert color="info" %}} 
Aspose Slides memungkinkan Anda memuat font ini menggunakan metode [loadExternalFonts](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* TrueType (.ttf) dan TrueType Collection (.ttc). Lihat [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf). Lihat [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Muat Font Kustom**

Aspose.Slides memungkinkan Anda memuat font yang digunakan dalam presentasi tanpa menginstalnya di sistem. Ini memengaruhi keluaran ekspor—seperti PDF, gambar, dan format lain yang didukung—sehingga dokumen yang dihasilkan terlihat konsisten di semua lingkungan. Font dimuat dari direktori khusus.

1. Tentukan satu atau lebih folder yang berisi file font.  
2. Panggil metode statis [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) untuk memuat font dari folder tersebut.  
3. Muat dan render/ekspor presentasi.  
4. Panggil [FontsLoader.clearCache](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/FontsLoader#clearCache--) untuk membersihkan cache font.

Contoh kode berikut menunjukkan proses pemuatan font:

```java
import com.aspose.slides.*;

// Tentukan folder yang berisi file font khusus.
String externalFontFolder1 = "assets/fonts";
String externalFontFolder2 = "global/fonts";

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

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) menambahkan folder tambahan ke jalur pencarian font, tetapi tidak mengubah urutan inisialisasi font.  
Font diinisialisasi dalam urutan berikut:

1. Jalur font sistem operasi default.  
1. Jalur yang dimuat melalui [FontsLoader](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/fontsloader/).

{{%/alert %}}

## **Dapatkan Folder Font Kustom**

Aspose.Slides menyediakan metode [getFontFolders](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) untuk memungkinkan Anda menemukan folder font. Metode ini mengembalikan folder yang ditambahkan melalui metode `LoadExternalFonts` serta folder font sistem.

Kode Java berikut menunjukkan cara menggunakan [getFontFolders](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/fontsloader/#getFontFolders--):

```java
import com.aspose.slides.*;

// Baris ini menampilkan folder tempat file font dicari.
// Itu adalah folder yang ditambahkan melalui metode LoadExternalFonts dan folder font sistem.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Tentukan Font Kustom yang Digunakan dengan Presentasi**

Aspose.Slides menyediakan properti [setDocumentLevelFontSources](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) untuk memungkinkan Anda menentukan font eksternal yang akan digunakan dengan presentasi.

Kode Java berikut menunjukkan cara menggunakan properti [setDocumentLevelFontSources](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

byte[] memoryFont1 = Files.readAllBytes(Paths.get("customfonts/CustomFont1.ttf"));
byte[] memoryFont2 = Files.readAllBytes(Paths.get("customfonts/CustomFont2.ttf"));

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

Aspose.Slides menyediakan metode [loadExternalFont](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) untuk memungkinkan Anda memuat font eksternal dari data biner.

Kode Java berikut mendemonstrasikan proses pemuatan font dari array byte:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

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

### Apakah font kustom memengaruhi ekspor ke semua format (PDF, PNG, SVG, HTML)?

Ya. Font yang terhubung digunakan oleh renderer di semua format ekspor.

### Apakah font kustom secara otomatis disematkan ke dalam PPTX yang dihasilkan?

Tidak. Mendaftarkan font untuk rendering bukanlah hal yang sama dengan menyematkannya ke dalam PPTX. Jika Anda memerlukan font yang dibawa dalam file presentasi, Anda harus menggunakan [fitur penyematan](/slides/id/androidjava/embedded-font/) secara eksplisit.

### Dapatkah saya mengontrol perilaku fallback ketika sebuah font kustom tidak memiliki glyph tertentu?

Ya. Konfigurasikan [font substitution](/slides/id/androidjava/font-substitution/), [replacement rules](/slides/id/androidjava/font-replacement/), dan [fallback sets](/slides/id/androidjava/fallback-font/) untuk menentukan secara tepat font mana yang digunakan ketika glyph yang diminta tidak ada.

### Dapatkah saya menggunakan font di kontainer Linux/Docker tanpa menginstalnya secara sistemwide?

Ya. Arahkan ke folder font Anda sendiri atau muat font dari array byte. Ini menghilangkan ketergantungan pada direktori font sistem di dalam image kontainer.

### Bagaimana dengan lisensi—apakah saya dapat menyematkan font kustom apa pun tanpa batasan?

Anda bertanggung jawab atas kepatuhan lisensi font. Ketentuan bervariasi; beberapa lisensi melarang penyematan atau penggunaan komersial. Selalu tinjau EULA font sebelum mendistribusikan keluaran.