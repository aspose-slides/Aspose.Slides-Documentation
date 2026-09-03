---
title: Menyematkan Font dalam Presentasi dengan JavaScript
linktitle: Font Tersematkan
type: docs
weight: 40
url: /id/nodejs-java/embedded-font/
keywords:
- tambahkan font
- sematkan font
- penyematan font
- dapatkan font tersematkan
- tambahkan font tersematkan
- hapus font tersematkan
- kompres font tersematkan
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Kelola font yang disematkan di PowerPoint dengan Aspose.Slides untuk Node.js via Java. Tambahkan, ambil, hapus, dan kompres font untuk mempertahankan tampilan teks serta mengurangi ukuran file."
---
## **Pendahuluan**

Embedding fonts menyimpan data font di dalam presentasi PowerPoint. Ketika penampil mendukung font yang disematkan, ia dapat menampilkan teks dengan font tersebut meskipun tidak terpasang di sistem target. Hal ini membantu mempertahankan pemenggalan baris, spasi teks, dan tata letak slide.

Aspose.Slides for Node.js via Java memungkinkan Anda mengambil, menambah, dan menghapus font yang disematkan melalui kelas [FontsManager](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsmanager/) yang dikembalikan oleh [Presentation.getFontsManager](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/getfontsmanager/). Anda juga dapat mengurangi ukuran data font yang disematkan dengan menghapus karakter yang tidak digunakan dalam presentasi.

Contoh di bawah ini bekerja dengan file PPTX. Sebelum menyematkan font, pastikan data font tersedia untuk Aspose.Slides dan lisensinya memungkinkan penyematan.

## **Mengambil dan Menghapus Font yang Disematkan**

Gunakan [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) untuk menampilkan daftar font yang disimpan dalam sebuah presentasi. Untuk menghapus satu font, berikan sebuah font dari daftar tersebut ke [FontsManager.removeEmbeddedFont](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsmanager/removeembeddedfont/), lalu simpan presentasinya.

Contoh berikut menampilkan font yang disematkan dalam `EmbeddedFonts.pptx` dan menghapus Calibri bila ada:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var embeddedFonts = fontsManager.getEmbeddedFonts();

    for (var i = 0; i < embeddedFonts.length; i++) {
        console.log(embeddedFonts[i].getFontName());
    }

    var fontToRemove = null;
    for (var i = 0; i < embeddedFonts.length; i++) {
        if (String(embeddedFonts[i].getFontName()).toLowerCase() === "calibri") {
            fontToRemove = embeddedFonts[i];
            break;
        }
    }

    if (fontToRemove !== null) {
        fontsManager.removeEmbeddedFont(fontToRemove);
        presentation.save("WithoutEmbeddedCalibri.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("Calibri is not embedded. No output file was created.");
    }
} finally {
    presentation.dispose();
}
```

Menghapus font yang disematkan menghilangkan data font yang tersimpan; hal ini tidak mengubah font yang ditetapkan pada teks. Jika font tersebut terpasang di sistem target, teks tetap dapat menggunakan font itu. Jika tidak, proses rendering mungkin memerlukan [font substitution](/slides/id/nodejs-java/font-substitution/), yang dapat memengaruhi tata letak.

## **Memeriksa Data Font dan Izin Penyematan**

Gunakan kelas [FontsManager](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsmanager/) untuk memeriksa font sebelum menyematkannya. Panggil [FontsManager.getFonts](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsmanager/getfonts/) untuk mengambil font yang digunakan dalam presentasi. Untuk setiap font, berikan objek [FontData](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontdata/) dan nilai [FontStyleType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontstyletype/) yang diperlukan ke [FontsManager.getFontBytes](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsmanager/#getFontBytes). Metode ini mengembalikan data biner untuk gaya font tersebut, atau `null` bila font atau gaya yang diminta tidak tersedia. Jangan mengirimkan hasil `null` ke [FontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel), karena metode tersebut memerlukan array byte. Di Node.js, ubah array JavaScript yang dikembalikan menjadi array byte Java dengan `java.newArray` sebelum mengirimkannya ke `getFontEmbeddingLevel`.

[EmbeddingLevel](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/embeddinglevel/) melaporkan pembatasan penyematan yang disimpan dalam font sebagai sekumpulan flag:

- `Installable` mengizinkan penyematan dan instalasi permanen pada sistem lain, sesuai dengan lisensi font.
- `Restricted` melarang penyematan kecuali izin diperoleh dari pemilik sah font ketika flag ini menjadi satu‑satunya flag izin penggunaan.
- `PreviewPrint` mengizinkan penggunaan sementara untuk melihat dan mencetak; dokumen yang berisi font harus bersifat hanya‑baca.
- `Editable` mengizinkan penggunaan sementara dan memungkinkan dokumen diedit serta disimpan.
- `NoSubsetting` adalah pembatas tambahan yang melarang penyematan hanya sebagian glif. Sematkan semua karakter bila flag ini ada.
- `BitmapOnly` adalah pembatas tambahan yang hanya mengizinkan bitmap strike disematkan, bukan data outline. Jika font tidak memiliki bitmap strike, maka tidak dapat disematkan.

Empat nilai pertama menggambarkan izin penggunaan, sementara `NoSubsetting` dan `BitmapOnly` dapat digabungkan dengan mereka. Periksa modifier dengan operasi bitwise. Karena `Installable` bernilai nol, mask bit izin penggunaan dan bandingkan hasilnya dengan `Installable` alih‑alih memeriksanya sebagai flag. Font saat ini seharusnya mengatur paling banyak satu bit izin penggunaan. Untuk kompatibilitas dengan font lama yang mengatur lebih dari satu, pembantu di bawah ini memilih izin paling tidak ketat: `Editable`, kemudian `PreviewPrint`, kemudian `Restricted`.

Contoh berikut meninjau data reguler, tebal, miring, dan tebal‑miring yang tersedia untuk setiap font yang dikembalikan oleh `getFonts`. Ia melewati gaya yang tidak tersedia, font yang dibatasi, font bitmap‑only, font terbatas pada preview dan print karena output tetap dapat diedit, serta font yang sudah disematkan. Jika ada gaya yang tersedia memiliki `NoSubsetting`, maka semua karakter disematkan untuk keluarga font tersebut.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

function getUsagePermission(level) {
    var permissionMask = aspose.slides.EmbeddingLevel.Restricted | aspose.slides.EmbeddingLevel.PreviewPrint | aspose.slides.EmbeddingLevel.Editable;
    var permissions = level & permissionMask;

    if ((permissions & aspose.slides.EmbeddingLevel.Editable) !== 0) {
        return aspose.slides.EmbeddingLevel.Editable;
    }

    if ((permissions & aspose.slides.EmbeddingLevel.PreviewPrint) !== 0) {
        return aspose.slides.EmbeddingLevel.PreviewPrint;
    }

    if ((permissions & aspose.slides.EmbeddingLevel.Restricted) !== 0) {
        return aspose.slides.EmbeddingLevel.Restricted;
    }

    return aspose.slides.EmbeddingLevel.Installable;
}

var presentation = new aspose.slides.Presentation("Fonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var fontStyles = [aspose.slides.FontStyleType.Regular, aspose.slides.FontStyleType.Bold, aspose.slides.FontStyleType.Italic, aspose.slides.FontStyleType.Bold | aspose.slides.FontStyleType.Italic];

    var embeddedFontNames = new Set();
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    for (var i = 0; i < embeddedFonts.length; i++) {
        embeddedFontNames.add(String(embeddedFonts[i].getFontName()).toLowerCase());
    }

    var fontsToEmbed = [];
    var embeddingRules = [];
    var fonts = fontsManager.getFonts();
    for (var i = 0; i < fonts.length; i++) {
        var font = fonts[i];
        var fontName = String(font.getFontName());
        if (embeddedFontNames.has(fontName.toLowerCase())) {
            console.log(fontName + ": already embedded.");
            continue;
        }

        var hasAvailableData = false;
        var allAvailableStylesCanBeEmbedded = true;
        var previewPrintOnly = false;
        var requiresFullFont = false;

        for (var j = 0; j < fontStyles.length; j++) {
            var fontStyle = fontStyles[j];
            var fontBytes = fontsManager.getFontBytes(font, fontStyle);
            if (fontBytes === null) {
                console.log(fontName + " (" + fontStyle + "): font data is unavailable.");
                continue;
            }

            hasAvailableData = true;
            var fontByteValues = Array.from(fontBytes);
            var javaFontBytes = java.newArray("byte", fontByteValues);
            var embeddingLevel = fontsManager.getFontEmbeddingLevel(javaFontBytes, fontName);
            var usagePermission = getUsagePermission(embeddingLevel);
            var noSubsetting = (embeddingLevel & aspose.slides.EmbeddingLevel.NoSubsetting) !== 0;
            var bitmapOnly = (embeddingLevel & aspose.slides.EmbeddingLevel.BitmapOnly) !== 0;

            requiresFullFont = requiresFullFont || noSubsetting;
            previewPrintOnly = previewPrintOnly || usagePermission === aspose.slides.EmbeddingLevel.PreviewPrint;
            allAvailableStylesCanBeEmbedded = allAvailableStylesCanBeEmbedded && usagePermission !== aspose.slides.EmbeddingLevel.Restricted && !bitmapOnly;

            console.log(fontName + " (" + fontStyle + "): " + embeddingLevel + ".");
        }

        if (!hasAvailableData) {
            console.log(fontName + ": skipped because no requested style is available.");
        } else if (!allAvailableStylesCanBeEmbedded) {
            console.log(fontName + ": skipped because at least one available style does not permit outline embedding.");
        } else if (previewPrintOnly) {
            console.log(fontName + ": skipped because this example produces an editable presentation.");
        } else {
            var rule = requiresFullFont ? aspose.slides.EmbedFontCharacters.All : aspose.slides.EmbedFontCharacters.OnlyUsed;
            fontsToEmbed.push(font);
            embeddingRules.push(rule);
        }
    }

    for (var i = 0; i < fontsToEmbed.length; i++) {
        fontsManager.addEmbeddedFont(fontsToEmbed[i], embeddingRules[i]);
    }

    presentation.save("WithAuditedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pemeriksaan ini melaporkan pembatasan yang dikodekan dalam setiap file font. Ini tidak memberikan lisensi, membuktikan bahwa Anda memperoleh font secara sah, atau menggantikan pengecekan perjanjian lisensi font sebelum mendistribusikan salinan yang disematkan.

## **Menambahkan Font yang Disematkan**

Gunakan [FontsManager.addEmbeddedFont](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsmanager/addembeddedfont/) untuk menyematkan sebuah font. Overload‑nya menerima objek [FontData](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontdata/) atau array byte yang berisi data font. [EmbedFontCharacters](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/embedfontcharacters/) mengontrol karakter mana yang disertakan:

- `All` menyematkan semua karakter dalam font. Gunakan opsi ini ketika penerima perlu mengedit presentasi dan memasukkan teks baru.
- `OnlyUsed` menyematkan hanya karakter yang dipakai dalam presentasi untuk mengurangi ukuran file. Pilih opsi ini untuk presentasi selesai yang terutama ditujukan untuk ditampilkan.

Contoh berikut menggunakan [FontsManager.getFonts](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsmanager/getfonts/) untuk mengambil font yang dipakai dalam `Fonts.pptx` dan menyematkan yang belum disematkan. Font yang ditambahkan harus tersedia pada mesin yang menjalankan kode. Font yang sudah disematkan tetap mempertahankan set karakter saat ini.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("Fonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var allFonts = fontsManager.getFonts();
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    var embeddedFontNames = new Set();
    var fontStyles = [aspose.slides.FontStyleType.Regular, aspose.slides.FontStyleType.Bold, aspose.slides.FontStyleType.Italic, aspose.slides.FontStyleType.Bold | aspose.slides.FontStyleType.Italic];

    for (var i = 0; i < embeddedFonts.length; i++) {
        embeddedFontNames.add(String(embeddedFonts[i].getFontName()).toLowerCase());
    }

    for (var i = 0; i < allFonts.length; i++) {
        var font = allFonts[i];
        var fontName = String(font.getFontName()).toLowerCase();
        if (!embeddedFontNames.has(fontName)) {
            var hasAvailableData = false;
            for (var j = 0; j < fontStyles.length; j++) {
                if (fontsManager.getFontBytes(font, fontStyles[j]) !== null) {
                    hasAvailableData = true;
                    break;
                }
            }

            if (hasAvailableData) {
                fontsManager.addEmbeddedFont(font, aspose.slides.EmbedFontCharacters.All);
                embeddedFontNames.add(fontName);
            } else {
                console.log(font.getFontName() + ": skipped because its font data is unavailable.");
            }
        }
    }

    presentation.save("WithEmbeddedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Mengompresi Font yang Disematkan**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/compress/compressembeddedfonts/) mengurangi data font yang disematkan dengan menghapus karakter yang tidak dipakai. Ia beroperasi pada font yang sudah disematkan, sehingga pengurangan ukuran bergantung pada berapa banyak data font yang tidak dipakai dalam presentasi.

Contoh berikut mengompresi font dalam `EmbeddedFonts.pptx` dan menyimpan hasilnya sebagai file terpisah:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    aspose.slides.Compress.compressEmbeddedFonts(presentation);
    presentation.save("CompressedEmbeddedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Simpan file asli jika penerima mungkin perlu menambah teks nanti. Karakter yang dihapus selama kompresi tidak lagi tersedia dari font yang disematkan, bahkan bila Anda awalnya menyematkan semua karakter.

## **FAQ**

**Bagaimana cara memeriksa apakah font yang disematkan masih akan digantikan selama rendering?**

Panggil [FontsManager.getSubstitutions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) di lingkungan tempat Anda merender presentasi untuk melihat font apa yang akan diganti oleh Aspose.Slides. Juga periksa pengaturan [font substitution](/slides/id/nodejs-java/font-substitution/) dan aturan [font fallback](/slides/id/nodejs-java/fallback-font/). Fallback menangani karakter yang hilang, sehingga penyematan font tidak menyelesaikan karakter yang tidak ada dalam font itu sendiri.

**Haruskah saya menyematkan font umum seperti Arial dan Calibri?**

Buat keputusan berdasarkan lingkungan target. Jika font yang diperlukan tersedia di setiap mesin yang membuka atau merender presentasi, menyematkannya mungkin menambah ukuran file yang tidak diperlukan. Jika penerima atau server mungkin tidak memiliki font tersebut, menyematkannya dapat membantu mempertahankan tampilan yang dimaksud, dengan catatan lisensinya memperbolehkannya.