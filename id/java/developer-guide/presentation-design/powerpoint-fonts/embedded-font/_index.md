---
title: Menyematkan Font dalam Presentasi di Java
linktitle: Font yang Disematkan
type: docs
weight: 40
url: /id/java/embedded-font/
keywords:
- menambahkan font
- menyematkan font
- penyematan font
- mengambil font yang disematkan
- menambahkan font yang disematkan
- menghapus font yang disematkan
- mengompres font yang disematkan
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Kelola font yang disematkan dalam PowerPoint dengan Aspose.Slides untuk Java. Tambahkan, ambil, hapus, dan kompres font untuk mempertahankan tampilan teks dan mengurangi ukuran file."
---
## **Pendahuluan**

Menyematkan font menyimpan data font di dalam presentasi PowerPoint. Ketika penampil mendukung font yang disematkan, ia dapat menampilkan teks menggunakan font tersebut bahkan jika font tidak diinstal di sistem target. Hal ini membantu mempertahankan jeda baris, spasi teks, dan tata letak slide.

Aspose.Slides for Java memungkinkan Anda mengambil, menambahkan, dan menghapus font yang disematkan melalui antarmuka [IFontsManager](https://reference.aspose.com/slides/id/java/com.aspose.slides/ifontsmanager/) yang dikembalikan oleh [Presentation.getFontsManager](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#getFontsManager--). Anda juga dapat mengurangi ukuran data font yang disematkan dengan menghapus karakter yang tidak digunakan oleh presentasi.

Contoh di bawah ini bekerja dengan file PPTX. Sebelum menyematkan font, pastikan data font tersebut tersedia untuk Aspose.Slides dan lisensinya mengizinkan penyematan.

## **Dapatkan dan Hapus Font yang Disematkan**

Gunakan [getEmbeddedFonts](https://reference.aspose.com/slides/id/java/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) untuk menampilkan daftar font yang disimpan dalam sebuah presentasi. Untuk menghapusnya, berikan sebuah font dari daftar tersebut ke [removeEmbeddedFont](https://reference.aspose.com/slides/id/java/com.aspose.slides/ifontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-), kemudian simpan presentasi.

Contoh berikut menampilkan font yang disematkan dalam `EmbeddedFonts.pptx` dan menghapus Calibri jika ada:

```java
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("EmbeddedFonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    for (IFontData font : embeddedFonts) {
        System.out.println(font.getFontName());
    }

    IFontData fontToRemove = null;
    for (IFontData font : embeddedFonts) {
        if ("Calibri".equalsIgnoreCase(font.getFontName())) {
            fontToRemove = font;
            break;
        }
    }

    if (fontToRemove != null) {
        fontsManager.removeEmbeddedFont(fontToRemove);
        presentation.save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("Calibri is not embedded. No output file was created.");
    }
} finally {
    presentation.dispose();
}
```

Menghapus font yang disematkan menghapus data font yang disimpan; hal ini tidak mengubah font yang ditetapkan ke teks. Jika font tersebut terinstal di sistem target, teks masih dapat menggunakannya. Jika tidak, rendering mungkin memerlukan [font substitution](/slides/id/java/font-substitution/), yang dapat memengaruhi tata letak.

## **Periksa Data Font dan Izin Penyematan**

Gunakan antarmuka [IFontsManager](https://reference.aspose.com/slides/id/java/com.aspose.slides/ifontsmanager/) untuk memeriksa font sebelum menyematkannya. Panggil [IFontsManager.getFonts](https://reference.aspose.com/slides/id/java/com.aspose.slides/ifontsmanager/#getFonts--) untuk mengambil font yang digunakan dalam presentasi. Untuk setiap font, berikan objek [IFontData](https://reference.aspose.com/slides/id/java/com.aspose.slides/ifontdata/) dan nilai [FontStyleType](https://reference.aspose.com/slides/id/java/com.aspose.slides/fontstyletype/) yang diperlukan ke [IFontsManager.getFontBytes](https://reference.aspose.com/slides/id/java/com.aspose.slides/ifontsmanager/#getFontBytes-com.aspose.slides.IFontData-int-). Metode ini mengembalikan data biner untuk gaya font tersebut, atau `null` ketika font atau gaya yang diminta tidak tersedia. Jangan memberikan hasil `null` ke [IFontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/id/java/com.aspose.slides/ifontsmanager/#getFontEmbeddingLevel-byte---java.lang.String-), karena metode tersebut memerlukan array byte.

[EmbeddingLevel](https://reference.aspose.com/slides/id/java/com.aspose.slides/embeddinglevel/) adalah enumerasi flag yang melaporkan pembatasan penyematan yang disimpan dalam font:

- `Installable` mengizinkan penyematan dan instalasi permanen pada sistem lain, tergantung pada lisensi font.
- `Restricted` melarang penyematan kecuali izin diperoleh dari pemilik sah font saat itu menjadi satu-satunya flag izin penggunaan.
- `PreviewPrint` mengizinkan penggunaan sementara untuk melihat dan mencetak; dokumen yang berisi font harus bersifat read-only.
- `Editable` mengizinkan penggunaan sementara dan memperbolehkan dokumen diedit serta disimpan.
- `NoSubsetting` adalah pembatasan tambahan yang melarang penyematan hanya sebagian glyph. Menyematkan semua karakter ketika flag ini ada.
- `BitmapOnly` adalah pembatasan tambahan yang hanya memperbolehkan menyematkan bitmap strikes, bukan data outline. Jika font tidak memiliki bitmap strikes, font tidak dapat disematkan.

Empat nilai pertama menggambarkan izin penggunaan, sementara `NoSubsetting` dan `BitmapOnly` dapat digabungkan dengan mereka. Periksa modifikator dengan operasi bitwise. Karena `Installable` bernilai nol, masking bit izin penggunaan dan bandingkan hasilnya dengan `Installable` alih-alih memeriksanya sebagai flag. Font saat ini seharusnya mengatur paling banyak satu bit izin penggunaan. Untuk kompatibilitas dengan font lama yang mengatur lebih dari satu, pembantu di bawah ini memilih izin paling tidak restriktif: `Editable`, lalu `PreviewPrint`, lalu `Restricted`.

Contoh berikut mengaudit data regular, bold, italic, dan bold-italic yang tersedia untuk setiap font yang dikembalikan oleh `getFonts`. Ia melewatkan gaya yang tidak tersedia, font yang dibatasi, font bitmap-only, font yang terbatas pada preview dan print karena output tetap dapat diedit, dan font yang sudah disematkan. Jika ada gaya yang tersedia memiliki `NoSubsetting`, ia menyematkan semua karakter untuk keluarga font tersebut.

```java
import com.aspose.slides.EmbedFontCharacters;
import com.aspose.slides.EmbeddingLevel;
import com.aspose.slides.FontStyleType;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Locale;
import java.util.Set;

class EmbeddingPermission {
    int getUsagePermission(int level) {
        int permissionMask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable;
        int permissions = level & permissionMask;

        if ((permissions & EmbeddingLevel.Editable) != 0) {
            return EmbeddingLevel.Editable;
        }

        if ((permissions & EmbeddingLevel.PreviewPrint) != 0) {
            return EmbeddingLevel.PreviewPrint;
        }

        if ((permissions & EmbeddingLevel.Restricted) != 0) {
            return EmbeddingLevel.Restricted;
        }

        return EmbeddingLevel.Installable;
    }
}

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    int[] fontStyles = {
        FontStyleType.Regular,
        FontStyleType.Bold,
        FontStyleType.Italic,
        FontStyleType.Bold | FontStyleType.Italic
    };

    Set<String> embeddedFontNames = new HashSet<String>();
    for (IFontData embeddedFont : fontsManager.getEmbeddedFonts()) {
        embeddedFontNames.add(embeddedFont.getFontName().toLowerCase(Locale.ROOT));
    }

    EmbeddingPermission permissionHelper = new EmbeddingPermission();
    List<IFontData> fontsToEmbed = new ArrayList<IFontData>();
    List<Integer> embeddingRules = new ArrayList<Integer>();
    for (IFontData font : fontsManager.getFonts()) {
        if (embeddedFontNames.contains(font.getFontName().toLowerCase(Locale.ROOT))) {
            System.out.println(font.getFontName() + ": already embedded.");
            continue;
        }

        boolean hasAvailableData = false;
        boolean allAvailableStylesCanBeEmbedded = true;
        boolean previewPrintOnly = false;
        boolean requiresFullFont = false;

        for (int fontStyle : fontStyles) {
            byte[] fontBytes = fontsManager.getFontBytes(font, fontStyle);
            if (fontBytes == null) {
                System.out.println(font.getFontName() + " (" + fontStyle + "): font data is unavailable.");
                continue;
            }

            hasAvailableData = true;
            int embeddingLevel = fontsManager.getFontEmbeddingLevel(fontBytes, font.getFontName());
            int usagePermission = permissionHelper.getUsagePermission(embeddingLevel);
            boolean noSubsetting = (embeddingLevel & EmbeddingLevel.NoSubsetting) != 0;
            boolean bitmapOnly = (embeddingLevel & EmbeddingLevel.BitmapOnly) != 0;

            requiresFullFont |= noSubsetting;
            previewPrintOnly |= usagePermission == EmbeddingLevel.PreviewPrint;
            allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel.Restricted && !bitmapOnly;

            System.out.println(font.getFontName() + " (" + fontStyle + "): " + embeddingLevel + ".");
        }

        if (!hasAvailableData) {
            System.out.println(font.getFontName() + ": skipped because no requested style is available.");
        } else if (!allAvailableStylesCanBeEmbedded) {
            System.out.println(font.getFontName() + ": skipped because at least one available style does not permit outline embedding.");
        } else if (previewPrintOnly) {
            System.out.println(font.getFontName() + ": skipped because this example produces an editable presentation.");
        } else {
            int rule = requiresFullFont ? EmbedFontCharacters.All : EmbedFontCharacters.OnlyUsed;
            fontsToEmbed.add(font);
            embeddingRules.add(rule);
        }
    }

    for (int i = 0; i < fontsToEmbed.size(); i++) {
        fontsManager.addEmbeddedFont(fontsToEmbed.get(i), embeddingRules.get(i));
    }

    presentation.save("WithAuditedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pemeriksaan ini melaporkan pembatasan yang dikodekan dalam setiap file font. Ini tidak memberikan lisensi, membuktikan bahwa Anda memperoleh font secara legal, atau menggantikan pengecekan perjanjian lisensi font sebelum mendistribusikan salinan yang disematkan.

## **Tambahkan Font yang Disematkan**

Gunakan [addEmbeddedFont](https://reference.aspose.com/slides/id/java/com.aspose.slides/ifontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) untuk menyematkan sebuah font. Overload-nya menerima baik objek [IFontData](https://reference.aspose.com/slides/id/java/com.aspose.slides/ifontdata/) atau array byte yang berisi data font. Enumerasi [EmbedFontCharacters](https://reference.aspose.com/slides/id/java/com.aspose.slides/embedfontcharacters/) mengendalikan karakter mana yang termasuk:

- [All](https://reference.aspose.com/slides/id/java/com.aspose.slides/embedfontcharacters/) menyematkan semua karakter dalam font. Gunakan opsi ini ketika penerima perlu mengedit presentasi dan memasukkan teks baru.
- [OnlyUsed](https://reference.aspose.com/slides/id/java/com.aspose.slides/embedfontcharacters/) hanya menyematkan karakter yang digunakan dalam presentasi untuk mengurangi ukuran file. Pilih opsi ini untuk presentasi selesai yang terutama dimaksudkan untuk ditampilkan.

Contoh berikut menggunakan [getFonts](https://reference.aspose.com/slides/id/java/com.aspose.slides/ifontsmanager/#getFonts--) untuk mengambil font yang digunakan dalam `Fonts.pptx` dan menyematkan font yang belum disematkan. Font yang akan ditambahkan harus tersedia di mesin yang menjalankan kode. Font yang sudah disematkan mempertahankan set karakter saat ini.

```java
import com.aspose.slides.EmbedFontCharacters;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.util.HashSet;
import java.util.Locale;
import java.util.Set;

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    IFontData[] allFonts = fontsManager.getFonts();
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();
    Set<String> embeddedFontNames = new HashSet<String>();

    for (IFontData embeddedFont : embeddedFonts) {
        embeddedFontNames.add(embeddedFont.getFontName().toLowerCase(Locale.ROOT));
    }

    for (IFontData font : allFonts) {
        String fontName = font.getFontName().toLowerCase(Locale.ROOT);
        if (!embeddedFontNames.contains(fontName)) {
            fontsManager.addEmbeddedFont(font, EmbedFontCharacters.All);
            embeddedFontNames.add(fontName);
        }
    }

    presentation.save("WithEmbeddedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kompres Font yang Disematkan**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/id/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) mengurangi data font yang disematkan dengan menghapus karakter yang tidak terpakai. Ia beroperasi pada font yang sudah disematkan, jadi pengurangan ukuran tergantung pada berapa banyak data font yang tidak terpakai yang terdapat dalam presentasi.

Contoh berikut mengompres font dalam `EmbeddedFonts.pptx` dan menyimpan hasilnya sebagai file terpisah:

```java
import com.aspose.slides.Compress;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("EmbeddedFonts.pptx");
try {
    Compress.compressEmbeddedFonts(presentation);
    presentation.save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Simpan file asli jika penerima mungkin perlu menambahkan teks nanti. Karakter yang dihapus selama kompresi tidak lagi tersedia dari font yang disematkan, bahkan jika Anda awalnya menyematkan semua karakter.

## **FAQ**

**Bagaimana saya dapat memeriksa apakah font yang disematkan masih akan digantikan selama rendering?**

Panggil [getSubstitutions](https://reference.aspose.com/slides/id/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) di lingkungan tempat Anda merender presentasi untuk melihat font mana yang akan diganti oleh Aspose.Slides. Juga periksa pengaturan [font substitution](/slides/id/java/font-substitution/) dan aturan [font fallback](/slides/id/java/fallback-font/). Fallback menangani karakter yang hilang, sehingga menyematkan font tidak menyelesaikan karakter yang tidak dimiliki oleh font tersebut.

**Haruskah saya menyematkan font umum seperti Arial dan Calibri?**

Buat keputusan berdasarkan lingkungan target. Jika font yang dibutuhkan tersedia di setiap mesin yang membuka atau merender presentasi, menyematkannya mungkin menambah ukuran file yang tidak perlu. Jika penerima atau server mungkin tidak memiliki font tersebut, menyematkannya dapat membantu menjaga tampilan yang diinginkan, asalkan lisensinya mengizinkannya.