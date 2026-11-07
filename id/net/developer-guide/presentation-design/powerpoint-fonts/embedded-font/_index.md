---
title: Menyematkan Font dalam Presentasi di .NET
linktitle: Font yang Disematkan
type: docs
weight: 40
url: /id/net/embedded-font/
keywords:
- menambah font
- menyematkan font
- penyematan font
- mengambil font yang disematkan
- menambah font yang disematkan
- menghapus font yang disematkan
- mengompres font yang disematkan
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Kelola font yang disematkan dalam PowerPoint dengan Aspose.Slides untuk .NET. Gunakan C# untuk menambah, mengambil, menghapus, dan mengompres font agar mempertahankan tampilan teks dan mengurangi ukuran file."
---
## **Pendahuluan**

Menyematkan font menyimpan data font di dalam presentasi PowerPoint. Ketika penampil mendukung font yang disematkan, ia dapat menampilkan teks menggunakan font tersebut bahkan jika font tidak terpasang pada sistem target. Hal ini membantu mempertahankan pemutusan baris, spasi teks, dan tata letak slide.

Aspose.Slides untuk .NET memungkinkan Anda mengambil, menambah, dan menghapus font yang disematkan melalui properti [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/) dari sebuah [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). Anda juga dapat mengurangi ukuran data font yang disematkan dengan menghapus karakter yang tidak digunakan oleh presentasi.

Contoh di bawah ini bekerja dengan file PPTX. Sebelum menyematkan font, pastikan data fontnya tersedia untuk Aspose.Slides dan lisensinya mengizinkan penyematan.

## **Dapatkan dan Hapus Font yang Disematkan**

Gunakan [GetEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts/) untuk mencantumkan font yang disimpan dalam sebuah presentasi. Untuk menghapus satu, berikan sebuah font dari daftar tersebut ke [RemoveEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/removeembeddedfont/), kemudian simpan presentasi.

Contoh berikut mencantumkan font yang disematkan dalam `EmbeddedFonts.pptx` dan menghapus Calibri jika ada:

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

Menghapus font yang disematkan menghapus data font yang disimpan; hal ini tidak mengubah font yang ditetapkan pada teks. Jika font terpasang pada sistem target, teks masih dapat menggunakannya. Jika tidak, proses rendering mungkin memerlukan [penggantian font](/slides/id/net/font-substitution/), yang dapat memengaruhi tata letak.

## **Periksa Data Font dan Izin Penyematan**

Gunakan antarmuka [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) untuk memeriksa font sebelum menyematkannya. Panggil [IFontsManager.GetFonts](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfonts/) untuk mengambil font yang digunakan dalam presentasi. Untuk setiap font, berikan objek [IFontData](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/) dan nilai [FontStyleType](https://reference.aspose.com/slides/net/aspose.slides/fontstyletype/) yang diperlukan ke [IFontsManager.GetFontBytes](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfontbytes/). Metode ini mengembalikan data biner untuk gaya font tersebut, atau `null` bila font atau gaya yang diminta tidak tersedia. Jangan berikan hasil `null` ke [IFontsManager.GetFontEmbeddingLevel](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfontembeddinglevel/), karena metode itu memerlukan array byte.

[EmbeddingLevel](https://reference.aspose.com/slides/net/aspose.slides/embeddinglevel/) adalah enumerasi flag yang melaporkan pembatasan penyematan yang disimpan dalam font:

- `Installable` memungkinkan penyematan dan instalasi permanen pada sistem lain, tergantung pada lisensi font.
- `Restricted` melarang penyematan kecuali izin diperoleh dari pemilik hukum font ketika itu satu-satunya flag izin penggunaan.
- `PreviewPrint` mengizinkan penggunaan sementara untuk melihat dan mencetak; dokumen yang berisi font harus bersifat hanya-baca.
- `Editable` mengizinkan penggunaan sementara dan memungkinkan dokumen diedit dan disimpan.
- `NoSubsetting` adalah pembatasan tambahan yang melarang penyematan hanya sebagian glyph. Sematkan semua karakter ketika flag ini ada.
- `BitmapOnly` adalah pembatasan tambahan yang hanya mengizinkan bitmap strike disematkan, bukan data outline. Jika font tidak memiliki bitmap strike, ia tidak dapat disematkan.

Empat nilai pertama menggambarkan izin penggunaan, sedangkan `NoSubsetting` dan `BitmapOnly` dapat digabungkan dengan mereka. Periksa pengubah dengan operasi bitwise. Karena `Installable` bernilai nol, jangan gunakan `HasFlag` untuk mendeteksinya; masker bit izin penggunaan dan bandingkan hasilnya dengan `Installable`. Font saat ini seharusnya mengatur paling banyak satu bit izin penggunaan. Untuk kompatibilitas dengan font lama yang mengatur lebih dari satu, pembantu di bawah ini memilih izin yang paling tidak restriktif: `Editable`, kemudian `PreviewPrint`, kemudian `Restricted`.

Contoh berikut mengaudit data reguler, tebal, miring, dan tebal-miring yang tersedia untuk setiap font yang dikembalikan oleh `GetFonts`. Ini melewati gaya yang tidak tersedia, font terbatas, font bitmap-only, font yang terbatas pada preview dan print karena output tetap dapat diedit, dan font yang sudah disematkan. Jika ada gaya yang tersedia memiliki `NoSubsetting`, maka semua karakter disematkan untuk keluarga font tersebut.

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

Pemeriksaan ini melaporkan pembatasan yang dikodekan dalam setiap file font. Ini tidak memberikan lisensi, membuktikan bahwa Anda memperoleh font secara sah, atau menggantikan pengecekan perjanjian lisensi font sebelum mendistribusikan salinan yang disematkan.

## **Tambah Font yang Disematkan**

Gunakan [AddEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/addembeddedfont/) untuk menyematkan sebuah font. Overload-nya menerima baik objek [IFontData](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/) atau array byte yang berisi data font. Enumerasi [EmbedFontCharacters](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) mengontrol karakter mana yang disertakan:

- [All](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) menyematkan semua karakter dalam font. Gunakan opsi ini ketika penerima perlu mengedit presentasi dan memasukkan teks baru.
- [OnlyUsed](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) hanya menyematkan karakter yang digunakan dalam presentasi untuk mengurangi ukuran file. Pilih opsi ini untuk presentasi selesai yang terutama ditujukan untuk ditampilkan.

Contoh berikut menggunakan [GetFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getfonts/) untuk mengambil font yang digunakan dalam `Fonts.pptx` dan menyematkan yang belum disematkan. Font yang akan ditambahkan harus tersedia pada mesin yang menjalankan kode. Font yang sudah disematkan akan mempertahankan set karakter saat ini.

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

[CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) mengurangi data font yang disematkan dengan menghapus karakter yang tidak terpakai. Ini beroperasi pada font yang sudah disematkan, sehingga pengurangan ukuran tergantung pada berapa banyak data font yang tidak terpakai yang ada dalam presentasi.

Contoh berikut mengompres font dalam `EmbeddedFonts.pptx` dan menyimpan hasilnya sebagai file terpisah:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("EmbeddedFonts.pptx");
Compress.CompressEmbeddedFonts(presentation);
presentation.Save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
```

Simpan file asli jika penerima mungkin perlu menambahkan teks kemudian. Karakter yang dihapus selama kompresi tidak lagi tersedia dari font yang disematkan, bahkan jika Anda awalnya menyematkan semua karakter.

Untuk membiarkan font terdaftar yang cocok memiliki prioritas selama ekspor tanpa menghapus font yang disematkan, lihat [Lebih Memilih Font Terdaftar daripada Font yang Disematkan](/slides/id/net/font-selection-sequence/#prefer-registered-fonts-over-embedded-fonts) (.NET 26.11 atau lebih baru).

## **FAQ**

**Bagaimana saya dapat memeriksa apakah font yang disematkan masih akan digantikan selama rendering?**

Panggil [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/) di lingkungan tempat Anda merender presentasi untuk melihat font mana yang akan diganti oleh Aspose.Slides. Juga periksa pengaturan [penggantian font](/slides/id/net/font-substitution/) dan aturan [fallback font](/slides/id/net/fallback-font/). Fallback menangani karakter yang hilang, sehingga menyematkan font tidak menyelesaikan karakter yang tidak dimiliki font tersebut.

**Haruskah saya menyematkan font umum seperti Arial dan Calibri?**

Buat keputusan berdasarkan lingkungan target. Jika font yang diperlukan tersedia di setiap mesin yang membuka atau merender presentasi, menyematkannya dapat menambah ukuran file yang tidak diperlukan. Jika penerima atau server mungkin tidak memiliki font tersebut, menyematkannya dapat membantu mempertahankan tampilan yang diinginkan, asalkan lisensinya memperbolehkan.