---
title: Sesuaikan Font PowerPoint di PHP
linktitle: Font Kustom
type: docs
weight: 20
url: /id/php-java/custom-font/
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
- PHP
- Aspose.Slides
description: "Sesuaikan font dalam slide PowerPoint dengan Aspose.Slides untuk PHP melalui Java agar presentasi Anda tetap tajam dan konsisten di semua perangkat."
---
## **Overview**

Aspose.Slides memungkinkan Anda menggunakan font khusus dalam presentasi tanpa menginstalnya pada sistem operasi. Anda dapat memuat font dari folder khusus, menyediakan font untuk presentasi tertentu melalui sumber font tingkat dokumen, atau memuat font eksternal langsung dari data biner.

Font yang dimuat akan digunakan saat presentasi dirender atau diekspor, misalnya ke PDF, gambar, dan format lain yang didukung. Hal ini membantu menjaga konsistensi output presentasi di berbagai lingkungan. Artikel ini juga menjelaskan cara memeriksa folder font yang digunakan oleh Aspose.Slides dan cara menghapus cache font setelah bekerja dengan font eksternal.

Mendaftarkan font khusus untuk rendering terpisah dari proses menyematkan font ke dalam file PPTX. Jika sebuah font harus disimpan di dalam presentasi itu sendiri, gunakan fitur penyematan font secara eksplisit.

{{% alert color="primary" %}} 

Aspose Slides memungkinkan Anda memuat font ini menggunakan metode [loadExternalFonts](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Font TrueType (.ttf) dan TrueType Collection (.ttc). Lihat [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Font OpenType (.otf). Lihat [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Load Custom Fonts**

Aspose.Slides memungkinkan Anda memuat font yang digunakan dalam sebuah presentasi tanpa menginstalnya pada sistem. Hal ini memengaruhi output ekspor—seperti PDF, gambar, dan format lain yang didukung—sehingga dokumen yang dihasilkan terlihat konsisten di berbagai lingkungan. Font dimuat dari direktori khusus.

1. Tentukan satu atau beberapa folder yang berisi file font.
2. Panggil metode statis [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) untuk memuat font dari folder tersebut.
3. Muat dan render/ekspor presentasi.
4. Panggil [FontsLoader::clearCache](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsloader/#clearCache--) untuk menghapus cache font.

Contoh kode berikut menunjukkan proses pemuatan font:

```php
// Definisikan folder yang berisi file font khusus.
$externalFontFolder1 = __DIR__ . "/external-fonts-1";
$externalFontFolder2 = __DIR__ . "/external-fonts-2";
$fontFolders = array($externalFontFolder1, $externalFontFolder2);

// Load custom fonts from the specified folders.
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

{{% alert color="info" title="Note" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) menambahkan folder tambahan ke jalur pencarian font, tetapi tidak mengubah urutan inisialisasi font. Font diinisialisasi dengan urutan berikut:

1. Jalur font default sistem operasi.
1. Jalur yang dimuat melalui [FontsLoader](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsloader/).

{{%/alert %}}

## **Get Custom Font Folders**
Aspose.Slides menyediakan metode [getFontFolders](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsloader/#getFontFolders--) untuk memungkinkan Anda menemukan folder font. Metode ini mengembalikan folder yang ditambahkan melalui metode `LoadExternalFonts` serta folder font sistem.

Kode PHP berikut menunjukkan cara menggunakan [getFontFolders](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsloader/#getFontFolders--):

```php
# Baris ini menampilkan folder tempat file font dicari.
# Itu adalah folder yang ditambahkan melalui metode LoadExternalFonts dan folder font sistem.
$fontFolders = FontsLoader::getFontFolders();
```

## **Specify Custom Fonts Used with a Presentation**
Aspose.Slides menyediakan metode [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/id/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) untuk memungkinkan Anda menentukan font eksternal yang akan digunakan dengan presentasi.

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

## **Manage Fonts Externally**

Aspose.Slides menyediakan metode [loadExternalFont](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) untuk memungkinkan Anda memuat font eksternal dari data biner.

Kode PHP berikut menunjukkan proses pemuatan font dari array byte:

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

**Apakah font khusus memengaruhi ekspor ke semua format (PDF, PNG, SVG, HTML)?**

Ya. Font yang terhubung digunakan oleh renderer pada semua format ekspor.

**Apakah font khusus secara otomatis disematkan ke dalam PPTX yang dihasilkan?**

Tidak. Mendaftarkan font untuk rendering tidak sama dengan menyematkannya ke dalam PPTX. Jika Anda memerlukan font berada di dalam file presentasi, Anda harus menggunakan [fitur penyematan](/slides/id/php-java/embedded-font/).

**Dapatkah saya mengontrol perilaku fallback ketika sebuah font khusus tidak memiliki glyph tertentu?**

Ya. Konfigurasikan [penggantian font](/slides/id/php-java/font-substitution/), [aturan penggantian](/slides/id/php-java/font-replacement/), dan [set fallback](/slides/id/php-java/fallback-font/) untuk menentukan secara tepat font mana yang digunakan ketika glyph yang diminta tidak ada.

**Apakah saya dapat menggunakan font di container Linux/Docker tanpa menginstalnya secara sistem-wide?**

Ya. Arahkan ke folder font Anda sendiri atau muat font dari array byte. Ini menghilangkan ketergantungan pada direktori font sistem dalam image container.

**Bagaimana dengan lisensi—apakah saya dapat menyematkan font khusus apa pun tanpa batasan?**

Anda bertanggung jawab atas kepatuhan lisensi font. Ketentuan bervariasi; beberapa lisensi melarang penyematan atau penggunaan komersial. Selalu tinjau EULA font sebelum mendistribusikan output.