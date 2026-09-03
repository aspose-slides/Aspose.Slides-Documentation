---
title: Menyematkan Font dalam Presentasi di .NET
linktitle: Font yang Disematkan
type: docs
weight: 40
url: /id/net/embedded-font/
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
- .NET
- C#
- Aspose.Slides
description: "Kelola font yang disematkan di PowerPoint dengan Aspose.Slides untuk .NET. Gunakan C# untuk menambahkan, mengambil, menghapus, dan mengompres font guna mempertahankan tampilan teks serta mengurangi ukuran file."
---
## **Pendahuluan**

Menyematkan font menyimpan data font di dalam presentasi PowerPoint. Ketika penampil mendukung font yang disematkan, ia dapat menampilkan teks menggunakan font tersebut bahkan jika font tidak terpasang di sistem target. Hal ini membantu mempertahankan pemenggalan baris, spasi teks, dan tata letak slide.

Aspose.Slides untuk .NET memungkinkan Anda mengambil, menambahkan, dan menghapus font yang disematkan melalui properti [FontsManager](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/fontsmanager/) dari sebuah [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/). Anda juga dapat mengurangi ukuran data font yang disematkan dengan menghapus karakter yang tidak digunakan dalam presentasi.

Contoh-contoh di bawah ini bekerja dengan file PPTX. Sebelum menyematkan font, pastikan data font tersebut tersedia untuk Aspose.Slides dan lisensinya memperbolehkan penyematan.

## **Dapatkan dan Hapus Font yang Disematkan**

Gunakan [GetEmbeddedFonts](https://reference.aspose.com/slides/id/net/aspose.slides/fontsmanager/getembeddedfonts/) untuk menampilkan daftar font yang disimpan dalam sebuah presentasi. Untuk menghapus salah satunya, berikan sebuah font dari daftar tersebut ke [RemoveEmbeddedFont](https://reference.aspose.com/slides/id/net/aspose.slides/fontsmanager/removeembeddedfont/), lalu simpan presentasinya.

Contoh berikut menampilkan font yang disematkan dalam `EmbeddedFonts.pptx` dan menghapus Calibri jika ada:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("EmbeddedFonts.pptx");
var fontsManager = presentation.FontsManager;
var embeddedFonts = fontsManager.GetEmbeddedFonts();

foreach (var font in embeddedFonts)
{
    Console.WriteLine(font.FontName);
}

var fontToRemove = Array.Find(embeddedFonts, font => string.Equals(font.FontName, "Calibri", StringComparison.OrdinalIgnoreCase));
if (fontToRemove != null)
{
    fontsManager.RemoveEmbeddedFont(fontToRemove);
    presentation.Save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Calibri is not embedded. No output file was created.");
}
```

Menghapus font yang disematkan menghapus data font yang disimpan; hal ini tidak mengubah font yang ditetapkan pada teks. Jika font tersebut terpasang di sistem target, teks tetap dapat menggunakannya. Jika tidak, proses rendering mungkin memerlukan [font substitution](/slides/id/net/font-substitution/), yang dapat memengaruhi tata letak.

## **Periksa Data Font dan Izin Penyematan**

Gunakan antarmuka [IFontsManager](https://reference.aspose.com/slides/id/net/aspose.slides/ifontsmanager/) untuk memeriksa font sebelum menyematkannya. Panggil [IFontsManager.GetFonts](https://reference.aspose.com/slides/id/net/aspose.slides/ifontsmanager/getfonts/) untuk mengambil font yang digunakan dalam presentasi. Untuk setiap font, berikan objek [IFontData](https://reference.aspose.com/slides/id/net/aspose.slides/ifontdata/) dan nilai [FontStyleType](https://reference.aspose.com/slides/id/net/aspose.slides/fontstyletype/) yang diperlukan ke [IFontsManager.GetFontBytes](https://reference.aspose.com/slides/id/net/aspose.slides/ifontsmanager/getfontbytes/). Metode ini mengembalikan data biner untuk gaya font tersebut, atau `null` bila font atau gaya yang diminta tidak tersedia. Jangan berikan hasil `null` ke [IFontsManager.GetFontEmbeddingLevel](https://reference.aspose.com/slides/id/net/aspose.slides/ifontsmanager/getfontembeddinglevel/), karena metode tersebut memerlukan array byte.

[EmbeddingLevel](https://reference.aspose.com/slides/id/net/aspose.slides/embeddinglevel/) adalah enumerasi flag yang melaporkan pembatasan penyematan yang disimpan dalam font:

- `Installable` memperbolehkan penyematan dan instalasi permanen pada sistem lain, tergantung pada lisensi font.
- `Restricted` melarang penyematan kecuali izin diperoleh dari pemilik sah font ketika ini menjadi satu-satunya flag izin penggunaan.
- `PreviewPrint` memperbolehkan penggunaan sementara untuk melihat dan mencetak; dokumen yang berisi font harus bersifat read-only.
- `Editable` memperbolehkan penggunaan sementara dan memungkinkan dokumen untuk diedit serta disimpan.
- `NoSubsetting` merupakan pembatasan tambahan yang melarang penyematan hanya sebagian glyph. Sematkan semua karakter bila flag ini ada.
- `BitmapOnly` merupakan pembatasan tambahan yang memperbolehkan hanya bitmap strike yang disematkan, bukan data outline. Jika font tidak memiliki bitmap strike, font tidak dapat disematkan.

Empat nilai pertama menggambarkan izin penggunaan, sementara `NoSubsetting` dan `BitmapOnly` dapat digabungkan dengan mereka. Periksa modifier dengan operasi bitwise. Karena `Installable` bernilai nol, jangan gunakan `HasFlag` untuk mendeteksinya; mask bit izin penggunaan dan bandingkan hasilnya dengan `Installable`. Font saat ini seharusnya mengatur paling banyak satu bit izin penggunaan. Untuk kompatibilitas dengan font lama yang mengatur lebih dari satu, helper di bawah ini memilih izin yang paling tidak restriktif: `Editable`, kemudian `PreviewPrint`, kemudian `Restricted`.

Contoh berikut mengaudit data reguler, tebal, miring, dan tebal-miring yang tersedia untuk setiap font yang dikembalikan oleh `GetFonts`. Ia melewatkan gaya yang tidak tersedia, font yang terbatas, font bitmap-only, font yang hanya untuk preview dan print karena output tetap dapat diedit, serta font yang sudah disematkan. Jika ada gaya yang tersedia memiliki `NoSubsetting`, ia menyematkan semua karakter untuk keluarga font tersebut.

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

static EmbeddingLevel GetUsagePermission(EmbeddingLevel level)
{
    const EmbeddingLevel permissionMask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable;
    var permissions = level & permissionMask;

    if ((permissions & EmbeddingLevel.Editable) != 0)
    {
        return EmbeddingLevel.Editable;
    }

    if ((permissions & EmbeddingLevel.PreviewPrint) != 0)
    {
        return EmbeddingLevel.PreviewPrint;
    }

    if ((permissions & EmbeddingLevel.Restricted) != 0)
    {
        return EmbeddingLevel.Restricted;
    }

    return EmbeddingLevel.Installable;
}

using var presentation = new Presentation("Fonts.pptx");
var fontsManager = presentation.FontsManager;
var fontStyles = new[]
{
    FontStyleType.Regular,
    FontStyleType.Bold,
    FontStyleType.Italic,
    FontStyleType.Bold | FontStyleType.Italic
};

var embeddedFontNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
foreach (var embeddedFont in fontsManager.GetEmbeddedFonts())
{
    embeddedFontNames.Add(embeddedFont.FontName);
}

var embeddingPlan = new List<(IFontData Font, EmbedFontCharacters Rule)>();
foreach (var font in fontsManager.GetFonts())
{
    if (embeddedFontNames.Contains(font.FontName))
    {
        Console.WriteLine($"{font.FontName}: already embedded.");
        continue;
    }

    var hasAvailableData = false;
    var allAvailableStylesCanBeEmbedded = true;
    var previewPrintOnly = false;
    var requiresFullFont = false;

    foreach (var fontStyle in fontStyles)
    {
        var fontBytes = fontsManager.GetFontBytes(font, fontStyle);
        if (fontBytes == null)
        {
            Console.WriteLine($"{font.FontName} ({fontStyle}): font data is unavailable.");
            continue;
        }

        hasAvailableData = true;
        var embeddingLevel = fontsManager.GetFontEmbeddingLevel(fontBytes, font.FontName);
        var usagePermission = GetUsagePermission(embeddingLevel);
        var noSubsetting = (embeddingLevel & EmbeddingLevel.NoSubsetting) != 0;
        var bitmapOnly = (embeddingLevel & EmbeddingLevel.BitmapOnly) != 0;

        requiresFullFont |= noSubsetting;
        previewPrintOnly |= usagePermission == EmbeddingLevel.PreviewPrint;
        allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel.Restricted && !bitmapOnly;

        Console.WriteLine($"{font.FontName} ({fontStyle}): {embeddingLevel}.");
    }

    if (!hasAvailableData)
    {
        Console.WriteLine($"{font.FontName}: skipped because no requested style is available.");
    }
    else if (!allAvailableStylesCanBeEmbedded)
    {
        Console.WriteLine($"{font.FontName}: skipped because at least one available style does not permit outline embedding.");
    }
    else if (previewPrintOnly)
    {
        Console.WriteLine($"{font.FontName}: skipped because this example produces an editable presentation.");
    }
    else
    {
        var rule = requiresFullFont ? EmbedFontCharacters.All : EmbedFontCharacters.OnlyUsed;
        embeddingPlan.Add((font, rule));
    }
}

foreach (var item in embeddingPlan)
{
    fontsManager.AddEmbeddedFont(item.Font, item.Rule);
}

presentation.Save("WithAuditedFonts.pptx", SaveFormat.Pptx);
```

Pemeriksaan ini melaporkan pembatasan yang dikodekan dalam setiap file font. Ini tidak memberi lisensi, tidak membuktikan bahwa Anda memperoleh font secara legal, dan tidak menggantikan pengecekan perjanjian lisensi font sebelum mendistribusikan salinan yang disematkan.

## **Tambahkan Font yang Disematkan**

Gunakan [AddEmbeddedFont](https://reference.aspose.com/slides/id/net/aspose.slides/fontsmanager/addembeddedfont/) untuk menyematkan sebuah font. Overload-nya menerima baik objek [IFontData](https://reference.aspose.com/slides/id/net/aspose.slides/ifontdata/) maupun array byte yang berisi data font. Enumerasi [EmbedFontCharacters](https://reference.aspose.com/slides/id/net/aspose.slides.export/embedfontcharacters/) mengontrol karakter mana yang disertakan:

- [All](https://reference.aspose.com/slides/id/net/aspose.slides.export/embedfontcharacters/) menyematkan semua karakter dalam font. Gunakan opsi ini ketika penerima perlu mengedit presentasi dan memasukkan teks baru.
- [OnlyUsed](https://reference.aspose.com/slides/id/net/aspose.slides.export/embedfontcharacters/) hanya menyematkan karakter yang digunakan dalam presentasi untuk mengurangi ukuran file. Pilih opsi ini untuk presentasi selesai yang terutama ditujukan untuk ditampilkan.

Contoh berikut menggunakan [GetFonts](https://reference.aspose.com/slides/id/net/aspose.slides/fontsmanager/getfonts/) untuk mengambil font yang digunakan dalam `Fonts.pptx` dan menyematkan font yang belum disematkan. Font yang akan ditambahkan harus tersedia di mesin yang menjalankan kode. Font yang sudah disematkan mempertahankan set karakter saat ini.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Fonts.pptx");
var fontsManager = presentation.FontsManager;
var allFonts = fontsManager.GetFonts();
var embeddedFonts = fontsManager.GetEmbeddedFonts();
var embeddedFontNames = embeddedFonts.Select(font => font.FontName);
var embeddedNames = new HashSet<string>(embeddedFontNames, StringComparer.OrdinalIgnoreCase);

foreach (var font in allFonts)
{
    if (!embeddedNames.Contains(font.FontName))
    {
        fontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
        embeddedNames.Add(font.FontName);
    }
}

presentation.Save("WithEmbeddedFonts.pptx", SaveFormat.Pptx);
```

## **Kompres Font yang Disematkan**

[CompressEmbeddedFonts](https://reference.aspose.com/slides/id/net/aspose.slides.lowcode/compress/compressembeddedfonts/) mengurangi data font yang disematkan dengan menghapus karakter yang tidak digunakan. Ia bekerja pada font yang sudah disematkan, sehingga pengurangan ukuran bergantung pada berapa banyak data font yang tidak terpakai dalam presentasi.

Contoh berikut mengompres font dalam `EmbeddedFonts.pptx` dan menyimpan hasilnya sebagai file terpisah:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("EmbeddedFonts.pptx");
Compress.CompressEmbeddedFonts(presentation);
presentation.Save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
```

Simpan file asli jika penerima mungkin perlu menambahkan teks di kemudian hari. Karakter yang dihapus selama kompresi tidak lagi tersedia dari font yang disematkan, bahkan jika Anda awalnya menyematkan semua karakter.

## **FAQ**

**Bagaimana saya dapat memeriksa apakah font yang disematkan masih akan digantikan selama rendering?**

Panggil [GetSubstitutions](https://reference.aspose.com/slides/id/net/aspose.slides/fontsmanager/getsubstitutions/) di lingkungan tempat Anda merender presentasi untuk melihat font mana yang akan diganti oleh Aspose.Slides. Juga periksa pengaturan [font substitution](/slides/id/net/font-substitution/) dan aturan [font fallback](/slides/id/net/fallback-font/). Fallback menangani karakter yang hilang, sehingga menyematkan font tidak menyelesaikan karakter yang tidak ada dalam font itu sendiri.

**Haruskah saya menyematkan font umum seperti Arial dan Calibri?**

Buat keputusan berdasarkan lingkungan target. Jika font yang dibutuhkan tersedia di setiap mesin yang membuka atau merender presentasi, menyematkannya mungkin menambah ukuran file yang tidak diperlukan. Jika penerima atau server mungkin tidak memiliki font tersebut, menyematkannya dapat membantu mempertahankan tampilan yang dimaksud, asalkan lisensinya memperbolehkan.