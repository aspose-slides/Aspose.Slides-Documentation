---
title: "Sesuaikan Font PowerPoint di PHP"
linktitle: "Font Kustom"
type: docs
weight: 20
url: /id/php-java/custom-font/
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
- PHP
- Aspose.Slides
description: "Sesuaikan font dalam slide PowerPoint dengan Aspose.Slides untuk PHP melalui Java agar presentasi Anda tajam dan konsisten di semua perangkat."
---
## **Ikhtisar**

Aspose.Slides memungkinkan Anda menggunakan font khusus dalam presentasi tanpa menginstalnya di sistem operasi. Anda dapat memuat font dari folder khusus, menyediakan font untuk presentasi tertentu melalui sumber font tingkat dokumen, atau memuat font eksternal langsung dari data biner.

Font yang dimuat akan digunakan saat presentasi dirender atau diekspor, misalnya ke PDF, gambar, dan format lain yang didukung. Hal ini membantu menjaga konsistensi output presentasi di berbagai lingkungan. Artikel ini juga menjelaskan cara memeriksa folder font yang digunakan oleh Aspose.Slides dan cara menghapus cache font setelah bekerja dengan font eksternal.

Mendaftarkan font khusus untuk rendering berbeda dari menyematkan font ke dalam file PPTX. Jika sebuah font harus disimpan di dalam presentasi itu sendiri, gunakan fitur penyematan font secara eksplisit.

Tema presentasi dapat merujuk pada keluarga font yang berbeda untuk sistem penulisan individu. Pemetaan ini menyimpan nama font tetapi tidak menginstal atau memuat file font. Lihat [Script-Specific Theme Fonts](/slides/id/php-java/script-specific-font-mappings/) untuk mengelola pemetaan, dan gunakan opsi pemuatan di bawah untuk membuat font yang dirujuk tersedia bagi rendering yang konsisten.

{{% alert color="info" title="Catatan" %}}

Aspose Slides memungkinkan Anda memuat font ini menggunakan metode [loadExternalFonts](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* TrueType (.ttf) dan TrueType Collection (.ttc). Lihat [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf). Lihat [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Muat Font Kustom**

Aspose.Slides memungkinkan Anda memuat font yang digunakan dalam presentasi tanpa menginstalnya di sistem. Hal ini memengaruhi output ekspor—seperti PDF, gambar, dan format lain yang didukung—sehingga dokumen yang dihasilkan tampak konsisten di semua lingkungan. Font dimuat dari direktori khusus.

1. Tentukan satu atau beberapa folder yang berisi file font.
2. Panggil metode statis [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) untuk memuat font dari folder tersebut.
3. Muat dan render/ekspor presentasi.
4. Panggil [FontsLoader::clearCache](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsloader/#clearCache--) untuk menghapus cache font.

Contoh kode berikut menunjukkan proses pemuatan font:

```php
// Tentukan folder yang berisi file font khusus.
$externalFontFolder1 = __DIR__ . "/external-fonts-1";
$externalFontFolder2 = __DIR__ . "/external-fonts-2";
$fontFolders = array($externalFontFolder1, $externalFontFolder2);

// Muat font khusus dari folder yang ditentukan.
FontsLoader::loadExternalFonts($fontFolders);

$presentation = null;
try {
    $presentationPath = __DIR__ . "/sample.pptx";
    $presentation = new Presentation($presentationPath);
    
    // Render/ekspor presentasi (mis., ke PDF, gambar, atau format lain) menggunakan font yang dimuat.
    $outputPath = __DIR__ . "/output.pdf";
    $presentation->save($outputPath, SaveFormat::Pdf);
} finally {
    if ($presentation != null) $presentation->dispose();

    // Hapus cache font setelah pekerjaan selesai.
    FontsLoader::clearCache();
}
```

{{% alert color="info" title="Catatan" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) menambahkan folder tambahan ke jalur pencarian font, tetapi tidak mengubah urutan inisialisasi font.
Font diinisialisasi dalam urutan berikut:

1. Jalur font sistem operasi default.
1. Jalur yang dimuat melalui [FontsLoader](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsloader/).

{{%/alert %}}

## **Dapatkan Folder Font Kustom**
Aspose.Slides menyediakan metode [getFontFolders](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsloader/#getFontFolders--) untuk memungkinkan Anda menemukan folder font. Metode ini mengembalikan folder yang ditambahkan melalui metode `LoadExternalFonts` serta folder font sistem.

Kode PHP berikut menunjukkan cara menggunakan [getFontFolders](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsloader/#getFontFolders--):

```php
# Baris ini menampilkan folder tempat file font dicari.
# Itu adalah folder yang ditambahkan melalui metode LoadExternalFonts dan folder font sistem.
$fontFolders = FontsLoader::getFontFolders();
```

## **Tentukan Font Kustom yang Digunakan pada Presentasi**
Aspose.Slides menyediakan metode [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/id/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) untuk memungkinkan Anda menentukan font eksternal yang akan digunakan pada presentasi.

Kode PHP berikut menunjukkan cara menggunakan metode [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/id/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

```php
$javaArray = new JavaClass("java.lang.reflect.Array");
$javaByteType = (new JavaClass("java.lang.Byte"))->TYPE;

$customFontsDirectory = __DIR__ . "/customfonts/";
$customFont1Path = $customFontsDirectory . "CustomFont1.ttf";
$customFontFile1 = new Java("java.io.File", $customFont1Path);
$customFontFile1Length = $customFontFile1->length();
$memoryFont1 = $javaArray->newInstance($javaByteType, $customFontFile1Length);
$dataInputStream1 = null;
try {
    $fileInputStream1 = new Java("java.io.FileInputStream", $customFontFile1);
    $dataInputStream1 = new Java("java.io.DataInputStream", $fileInputStream1);
    $dataInputStream1->readFully($memoryFont1);
} finally {
    if (!java_is_null($dataInputStream1)) $dataInputStream1->close();
}

$customFont2Path = $customFontsDirectory . "CustomFont2.ttf";
$customFontFile2 = new Java("java.io.File", $customFont2Path);
$customFontFile2Length = $customFontFile2->length();
$memoryFont2 = $javaArray->newInstance($javaByteType, $customFontFile2Length);
$dataInputStream2 = null;
try {
    $fileInputStream2 = new Java("java.io.FileInputStream", $customFontFile2);
    $dataInputStream2 = new Java("java.io.DataInputStream", $fileInputStream2);
    $dataInputStream2->readFully($memoryFont2);
} finally {
    if (!java_is_null($dataInputStream2)) $dataInputStream2->close();
}

$loadOptions = new LoadOptions();
$assetFontsFolder = __DIR__ . "/assets/fonts";
$globalFontsFolder = __DIR__ . "/global/fonts";
$loadOptions->getDocumentLevelFontSources()->setFontFolders(array($assetFontsFolder, $globalFontsFolder));
$loadOptions->getDocumentLevelFontSources()->setMemoryFonts(array($memoryFont1, $memoryFont2 ));

$presentationPath = __DIR__ . "/MyPresentation.pptx";
$presentation = new Presentation($presentationPath, $loadOptions);
try {
    # Bekerja dengan presentasi
    # CustomFont1, CustomFont2, dan font dari folder assets\fonts & global\fonts serta subfoldernya tersedia untuk presentasi
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Kelola Font Secara Eksternal**

Aspose.Slides menyediakan metode [loadExternalFont](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) untuk memungkinkan Anda memuat font eksternal dari data biner.

Kode PHP berikut mendemonstrasikan proses pemuatan font dari array byte:

```php
$javaArray = new JavaClass("java.lang.reflect.Array");
$javaByteType = (new JavaClass("java.lang.Byte"))->TYPE;
$fontDirectory = __DIR__ . "/";

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALN.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALNBI.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALNI.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

try {
    $presentation = new Presentation();
    try {
        # font eksternal dimuat selama masa hidup presentasi
    } finally {
        if (!java_is_null($presentation)) {
            $presentation->dispose();
        }
    }
} finally {
    FontsLoader->clearCache();
}
```

## **FAQ**

### Apakah font kustom memengaruhi ekspor ke semua format (PDF, PNG, SVG, HTML)?

Ya. Font yang terhubung digunakan oleh renderer pada semua format ekspor.

### Apakah font kustom secara otomatis disematkan ke dalam PPTX yang dihasilkan?

Tidak. Mendaftarkan font untuk rendering bukanlah hal yang sama dengan menyematkannya ke dalam PPTX. Jika Anda memerlukan font berada di dalam file presentasi, gunakan [fitur penyematan](/slides/id/php-java/embedded-font/).

### Bisakah saya mengontrol perilaku fallback ketika sebuah font kustom tidak memiliki glyph tertentu?

Ya. Konfigurasikan [font substitution](/slides/id/php-java/font-substitution/), [replacement rules](/slides/id/php-java/font-replacement/), dan [fallback sets](/slides/id/php-java/fallback-font/) untuk menentukan font mana yang akan dipakai ketika glyph yang diminta tidak ada.

### Bisakah saya menggunakan font di kontainer Linux/Docker tanpa menginstalnya secara sistem?

Ya. Arahkan ke folder font Anda sendiri atau muat font dari array byte. Ini menghilangkan ketergantungan pada direktori font sistem dalam gambar kontainer.

### Bagaimana dengan lisensi—apakah saya dapat menyematkan font kustom apa pun tanpa batasan?

Anda bertanggung jawab atas kepatuhan lisensi font. Persyaratan bervariasi; beberapa lisensi melarang penyematan atau penggunaan komersial. Selalu tinjau EULA font sebelum mendistribusikan hasil.