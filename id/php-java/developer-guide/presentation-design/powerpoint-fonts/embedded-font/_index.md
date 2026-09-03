---
title: Menyematkan Font dalam Presentasi Menggunakan PHP
linktitle: Font Tersematkan
type: docs
weight: 40
url: /id/php-java/embedded-font/
keywords:
- tambahkan font
- menyematkan font
- penyematan font
- ambil font yang disematkan
- tambahkan font yang disematkan
- hapus font yang disematkan
- kompres font yang disematkan
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Kelola font yang disematkan dalam PowerPoint dengan Aspose.Slides untuk PHP via Java. Tambahkan, ambil, hapus, dan kompres font untuk mempertahankan tampilan teks dan mengurangi ukuran file."
---
## **Pendahuluan**

Menyematkan font menyimpan data font di dalam presentasi PowerPoint. Ketika penampil mendukung font yang disematkan, ia dapat menampilkan teks menggunakan font tersebut bahkan jika font tidak terpasang pada sistem target. Ini membantu mempertahankan jeda baris, spasi teks, dan tata letak slide.

Aspose.Slides untuk PHP via Java memungkinkan Anda mengambil, menambah, dan menghapus font yang disematkan melalui kelas [FontsManager](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsmanager/) yang dikembalikan oleh [Presentation::getFontsManager](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#getFontsManager). Anda juga dapat mengurangi ukuran data font yang disematkan dengan menghapus karakter yang tidak digunakan oleh presentasi.

Contoh di bawah ini bekerja dengan file PPTX. Sebelum menyematkan font, pastikan data font tersedia untuk Aspose.Slides dan lisensinya memperbolehkan penyematan.

## **Dapatkan dan Hapus Font yang Disematkan**

Gunakan [FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) untuk menampilkan daftar font yang disimpan dalam sebuah presentasi. Untuk menghapus satu font, berikan sebuah font dari daftar tersebut ke [FontsManager::removeEmbeddedFont](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont), lalu simpan presentasinya.

Contoh berikut menampilkan daftar font yang disematkan dalam `EmbeddedFonts.pptx` dan menghapus Calibri jika ada:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("EmbeddedFonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $embeddedFonts = $fontsManager->getEmbeddedFonts();

    foreach ($embeddedFonts as $font) {
        echo java_values($font->getFontName()) . PHP_EOL;
    }

    $fontToRemove = null;
    foreach ($embeddedFonts as $font) {
        $fontName = java_values($font->getFontName());
        if (strcasecmp($fontName, "Calibri") === 0) {
            $fontToRemove = $font;
            break;
        }
    }

    if ($fontToRemove !== null) {
        $fontsManager->removeEmbeddedFont($fontToRemove);
        $presentation->save("WithoutEmbeddedCalibri.pptx", SaveFormat::Pptx);
    } else {
        echo "Calibri is not embedded. No output file was created." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Menghapus font yang disematkan menghapus data font yang disimpan; hal ini tidak mengubah font yang ditetapkan pada teks. Jika font terpasang pada sistem target, teks masih dapat menggunakannya. Jika tidak, proses render mungkin memerlukan [font substitution](/slides/id/php-java/font-substitution/), yang dapat memengaruhi tata letak.

## **Periksa Data Font dan Izin Penyematan**

Gunakan kelas [FontsManager](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsmanager/) untuk memeriksa font sebelum menyematkannya. Panggil [FontsManager::getFonts](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsmanager/#getFonts) untuk mengambil font yang digunakan dalam presentasi. Untuk setiap font, berikan objek [FontData](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontdata/) dan nilai [FontStyleType](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontstyletype/) yang diperlukan ke [FontsManager::getFontBytes](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsmanager/#getFontBytes). Metode ini mengembalikan data biner untuk gaya font tersebut, atau `null` ketika font atau gaya yang diminta tidak tersedia. Jangan berikan hasil `null` ke [FontsManager::getFontEmbeddingLevel](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel), karena metode itu memerlukan array byte.

[EmbeddingLevel](https://reference.aspose.com/slides/id/php-java/aspose.slides/embeddinglevel/) adalah enumerasi flag yang melaporkan pembatasan penyematan yang disimpan dalam font:

- `Installable` memungkinkan penyematan dan instalasi permanen pada sistem lain, tergantung pada lisensi font.
- `Restricted` melarang penyematan kecuali izin diperoleh dari pemilik sah font ketika flag ini satu‑satunya flag izin penggunaan.
- `PreviewPrint` memungkinkan penggunaan sementara untuk melihat dan mencetak; dokumen yang berisi font harus bersifat baca‑saja.
- `Editable` memungkinkan penggunaan sementara dan memperbolehkan dokumen diedit serta disimpan.
- `NoSubsetting` adalah pembatasan tambahan yang melarang penyematan hanya sebagian glyph. Menyematkan semua karakter ketika flag ini ada.
- `BitmapOnly` adalah pembatasan tambahan yang hanya memperbolehkan bitmap strike disematkan, bukan data outline. Jika font tidak memiliki bitmap strike, font tidak dapat disematkan.

Empat nilai pertama menggambarkan izin penggunaan, sementara `NoSubsetting` dan `BitmapOnly` dapat digabungkan dengan mereka. Periksa modifier dengan operasi bitwise. Karena `Installable` bernilai nol, mask bit izin penggunaan dan bandingkan hasilnya dengan `Installable` alih‑alih memeriksanya sebagai flag. Font saat ini seharusnya mengatur paling banyak satu bit izin penggunaan. Untuk kompatibilitas dengan font lama yang mengatur lebih dari satu, pembantu di bawah ini memilih izin paling tidak restriktif: `Editable`, kemudian `PreviewPrint`, kemudian `Restricted`.

Contoh berikut mengaudit data reguler, tebal, miring, dan tebal‑miring yang tersedia untuk setiap font yang dikembalikan oleh `FontsManager::getFonts`. Ia melewatkan gaya yang tidak tersedia, font yang terbatas, font bitmap‑only, font yang terbatas pada preview dan print karena output tetap dapat diedit, serta font yang sudah disematkan. Jika ada gaya yang tersedia memiliki `NoSubsetting`, semua karakter untuk keluarga font tersebut akan disematkan.

```php
use aspose\slides\EmbedFontCharacters;
use aspose\slides\EmbeddingLevel;
use aspose\slides\FontStyleType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function getUsagePermission($level) {
    $permissionMask = EmbeddingLevel::Restricted | EmbeddingLevel::PreviewPrint | EmbeddingLevel::Editable;
    $permissions = $level & $permissionMask;

    if (($permissions & EmbeddingLevel::Editable) !== 0) {
        return EmbeddingLevel::Editable;
    }

    if (($permissions & EmbeddingLevel::PreviewPrint) !== 0) {
        return EmbeddingLevel::PreviewPrint;
    }

    if (($permissions & EmbeddingLevel::Restricted) !== 0) {
        return EmbeddingLevel::Restricted;
    }

    return EmbeddingLevel::Installable;
}

$presentation = new Presentation("Fonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $fontStyles = [
        FontStyleType::Regular,
        FontStyleType::Bold,
        FontStyleType::Italic,
        FontStyleType::Bold | FontStyleType::Italic
    ];

    $embeddedFontNames = [];
    foreach ($fontsManager->getEmbeddedFonts() as $embeddedFont) {
        $fontName = java_values($embeddedFont->getFontName());
        $embeddedFontNames[strtolower($fontName)] = true;
    }

    $fontsToEmbed = [];
    $embeddingRules = [];
    foreach ($fontsManager->getFonts() as $font) {
        $fontName = java_values($font->getFontName());
        if (isset($embeddedFontNames[strtolower($fontName)])) {
            echo $fontName . ": already embedded." . PHP_EOL;
            continue;
        }

        $hasAvailableData = false;
        $allAvailableStylesCanBeEmbedded = true;
        $previewPrintOnly = false;
        $requiresFullFont = false;

        foreach ($fontStyles as $fontStyle) {
            $fontBytes = $fontsManager->getFontBytes($font, $fontStyle);
            if (java_is_null($fontBytes)) {
                echo $fontName . " (" . $fontStyle . "): font data is unavailable." . PHP_EOL;
                continue;
            }

            $hasAvailableData = true;
            $embeddingLevel = java_values($fontsManager->getFontEmbeddingLevel($fontBytes, $fontName));
            $usagePermission = getUsagePermission($embeddingLevel);
            $noSubsetting = ($embeddingLevel & EmbeddingLevel::NoSubsetting) !== 0;
            $bitmapOnly = ($embeddingLevel & EmbeddingLevel::BitmapOnly) !== 0;

            $requiresFullFont = $requiresFullFont || $noSubsetting;
            $previewPrintOnly = $previewPrintOnly || $usagePermission === EmbeddingLevel::PreviewPrint;
            $allAvailableStylesCanBeEmbedded = $allAvailableStylesCanBeEmbedded && $usagePermission !== EmbeddingLevel::Restricted && !$bitmapOnly;

            echo $fontName . " (" . $fontStyle . "): " . $embeddingLevel . "." . PHP_EOL;
        }

        if (!$hasAvailableData) {
            echo $fontName . ": skipped because no requested style is available." . PHP_EOL;
        } elseif (!$allAvailableStylesCanBeEmbedded) {
            echo $fontName . ": skipped because at least one available style does not permit outline embedding." . PHP_EOL;
        } elseif ($previewPrintOnly) {
            echo $fontName . ": skipped because this example produces an editable presentation." . PHP_EOL;
        } else {
            $rule = $requiresFullFont ? EmbedFontCharacters::All : EmbedFontCharacters::OnlyUsed;
            $fontsToEmbed[] = $font;
            $embeddingRules[] = $rule;
        }
    }

    for ($i = 0; $i < count($fontsToEmbed); $i++) {
        $fontsManager->addEmbeddedFont($fontsToEmbed[$i], $embeddingRules[$i]);
    }

    $presentation->save("WithAuditedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Pemeriksaan ini melaporkan pembatasan yang dikodekan dalam setiap berkas font. Ini tidak memberikan lisensi, membuktikan bahwa Anda memperoleh font secara legal, atau menggantikan pengecekan perjanjian lisensi font sebelum mendistribusikan salinan yang disematkan.

## **Tambah Font yang Disematkan**

Gunakan [FontsManager::addEmbeddedFont](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsmanager/#addEmbeddedFont) untuk menyematkan sebuah font. Overload-nya menerima baik objek [FontData](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontdata/) atau array byte yang berisi data font. Enumerasi [EmbedFontCharacters](https://reference.aspose.com/slides/id/php-java/aspose.slides/embedfontcharacters/) mengontrol karakter mana yang dimasukkan:

- [All](https://reference.aspose.com/slides/id/php-java/aspose.slides/embedfontcharacters/) menyematkan semua karakter dalam font. Gunakan opsi ini ketika penerima perlu mengedit presentasi dan memasukkan teks baru.
- [OnlyUsed](https://reference.aspose.com/slides/id/php-java/aspose.slides/embedfontcharacters/) hanya menyematkan karakter yang digunakan dalam presentasi untuk mengurangi ukuran berkas. Pilih opsi ini untuk presentasi selesai yang terutama ditujukan untuk ditampilkan.

Contoh berikut menggunakan [FontsManager::getFonts](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsmanager/#getFonts) untuk mengambil font yang digunakan dalam `Fonts.pptx` dan menyematkan yang belum disematkan. Font yang akan ditambahkan harus tersedia pada mesin yang menjalankan kode. Font yang sudah disematkan tetap mempertahankan set karakter saat ini.

```php
use aspose\slides\EmbedFontCharacters;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Fonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $allFonts = $fontsManager->getFonts();
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    $embeddedFontNames = [];

    foreach ($embeddedFonts as $embeddedFont) {
        $fontName = java_values($embeddedFont->getFontName());
        $embeddedFontNames[strtolower($fontName)] = true;
    }

    foreach ($allFonts as $font) {
        $fontName = java_values($font->getFontName());
        $normalizedFontName = strtolower($fontName);
        if (!isset($embeddedFontNames[$normalizedFontName])) {
            $fontsManager->addEmbeddedFont($font, EmbedFontCharacters::All);
            $embeddedFontNames[$normalizedFontName] = true;
        }
    }

    $presentation->save("WithEmbeddedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Kompres Font yang Disematkan**

[Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/id/php-java/aspose.slides/compress/#compressEmbeddedFonts) mengurangi data font yang disematkan dengan menghapus karakter yang tidak terpakai. Ia beroperasi pada font yang sudah disematkan, sehingga pengurangan ukuran tergantung pada berapa banyak data font yang tidak terpakai yang ada dalam presentasi.

Contoh berikut mengompres font dalam `EmbeddedFonts.pptx` dan menyimpan hasilnya sebagai berkas terpisah:

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("EmbeddedFonts.pptx");
try {
    Compress::compressEmbeddedFonts($presentation);
    $presentation->save("CompressedEmbeddedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Simpan berkas asli jika penerima mungkin perlu menambah teks nanti. Karakter yang dihapus selama kompresi tidak lagi tersedia dari font yang disematkan, bahkan jika Anda awalnya menyematkan semua karakter.

## **FAQ**

**Bagaimana saya dapat memeriksa apakah font yang disematkan masih akan digantikan selama rendering?**

Panggil [FontsManager::getSubstitutions](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsmanager/#getSubstitutions) dalam lingkungan tempat Anda merender presentasi untuk melihat font mana yang akan diganti oleh Aspose.Slides. Juga periksa pengaturan [font substitution](/slides/id/php-java/font-substitution/) dan aturan [font fallback](/slides/id/php-java/fallback-font/). Fallback menangani karakter yang hilang, sehingga menyematkan font tidak menyelesaikan karakter yang tidak ada dalam font tersebut.

**Haruskah saya menyematkan font umum seperti Arial dan Calibri?**

Dasarkan keputusan pada lingkungan target. Jika font yang diperlukan tersedia di setiap mesin yang membuka atau merender presentasi, menyematkannya dapat menambah ukuran berkas yang tidak diperlukan. Jika penerima atau server mungkin tidak memiliki font tersebut, menyematkannya dapat membantu mempertahankan tampilan yang diinginkan, asalkan lisensinya memperbolehkannya.