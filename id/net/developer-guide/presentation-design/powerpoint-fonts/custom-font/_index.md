---
title: "Sesuaikan Font PowerPoint di .NET"
linktitle: "Font Kustom"
type: docs
weight: 20
url: /id/net/custom-font/
keywords:
- font
- font kustom
- font eksternal
- memuat font
- kelola font
- folder font
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Sesuaikan font dalam slide PowerPoint menggunakan Aspose.Slides untuk .NET agar presentasi Anda tetap tajam dan konsisten di semua perangkat."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda menggunakan font kustom dalam presentasi tanpa memasangnya di sistem operasi. Anda dapat memuat font dari folder kustom, menyediakan font untuk presentasi tertentu melalui sumber font tingkat dokumen, atau memuat font eksternal langsung dari data biner.

Font yang dimuat digunakan saat presentasi dirender atau diekspor, misalnya ke PDF, gambar, dan format lain yang didukung. Hal ini membantu menjaga konsistensi output presentasi di berbagai lingkungan. Artikel ini juga menjelaskan cara memeriksa folder font yang digunakan oleh Aspose.Slides dan cara membersihkan cache font setelah bekerja dengan font eksternal.

Mendaftarkan font kustom untuk rendering terpisah dari menyematkan font ke dalam file PPTX. Jika sebuah font harus disimpan di dalam presentasi itu sendiri, gunakan fitur penyematan font secara eksplisit.

{{% alert color="primary" %}} 

Aspose Slides memungkinkan Anda memuat font tersebut menggunakan metode [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/id/net/aspose.slides/fontsloader/loadexternalfonts/) :

* TrueType (.ttf) dan TrueType Collection (.ttc). Lihat [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf). Lihat [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Memuat Font Kustom**

Aspose.Slides memungkinkan Anda memuat font yang digunakan dalam presentasi tanpa menginstalnya di sistem. Ini memengaruhi output ekspor—seperti PDF, gambar, dan format lain yang didukung—sehingga dokumen yang dihasilkan tampak konsisten di semua lingkungan. Font dimuat dari direktori kustom.

1. Tentukan satu atau beberapa folder yang berisi file font.  
2. Panggil metode statis [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/id/net/aspose.slides/fontsloader/loadexternalfonts/) untuk memuat font dari folder tersebut.  
3. Muat dan render/ekspor presentasi.  
4. Panggil [FontsLoader.ClearCache](https://reference.aspose.com/slides/id/net/aspose.slides/fontsloader/clearcache/) untuk membersihkan cache font.

Contoh kode berikut menunjukkan proses pemuatan font:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Tentukan folder yang berisi file font kustom.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// Muat font kustom dari folder yang ditentukan.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Render/ekspor presentasi (misalnya ke PDF, gambar, atau format lain) menggunakan font yang dimuat.
presentation.Save("output.pdf", SaveFormat.Pdf);

// Bersihkan cache font setelah pekerjaan selesai.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}

[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/id/net/aspose.slides/fontsloader/loadexternalfonts/) menambahkan folder tambahan ke jalur pencarian font, tetapi tidak mengubah urutan inisialisasi font.  
Font diinisialisasi dalam urutan berikut:

1. Jalur font default sistem operasi.  
1. Jalur yang dimuat via [FontsLoader](https://reference.aspose.com/slides/id/net/aspose.slides/fontsloader/).

{{%/alert %}}

## **Dapatkan Folder Font Kustom**
Aspose.Slides menyediakan metode [GetFontFolders](https://reference.aspose.com/slides/id/net/aspose.slides/fontsloader/getfontfolders/) untuk memungkinkan Anda menemukan folder font. Metode ini mengembalikan folder yang ditambahkan melalui metode `LoadExternalFonts` serta folder font sistem.

Kode C# berikut menunjukkan cara menggunakan [GetFontFolders](https://reference.aspose.com/slides/id/net/aspose.slides/fontsloader/getfontfolders/) :

```c#
using Aspose.Slides;

// Baris ini menampilkan folder yang diperiksa untuk file font.
// Itu adalah folder yang ditambahkan melalui metode LoadExternalFonts dan folder font sistem.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **Tentukan Font Kustom yang Digunakan dengan Presentasi**
Aspose.Slides menyediakan properti [DocumentLevelFontSources](https://reference.aspose.com/slides/id/net/aspose.slides/loadoptions/documentlevelfontsources/) untuk memungkinkan Anda menentukan font eksternal yang akan digunakan dengan presentasi.

Kode C# berikut menunjukkan cara menggunakan properti [DocumentLevelFontSources](https://reference.aspose.com/slides/id/net/aspose.slides/loadoptions/documentlevelfontsources/) :

```c#
using Aspose.Slides;

byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // Bekerja dengan presentasi
    // CustomFont1, CustomFont2, dan font dari folder assets\fonts & global\fonts serta subfoldernya tersedia untuk presentasi
}
```

## **Kelola Font Secara Eksternal**

Aspose.Slides menyediakan metode [LoadExternalFont](https://reference.aspose.com/slides/id/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) untuk memungkinkan Anda memuat font eksternal dari data biner.

Kode C# berikut mendemonstrasikan proses pemuatan font dari array byte:

```c#
using Aspose.Slides;

FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // font eksternal dimuat selama masa hidup presentasi
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

## **FAQ**

**Apakah font kustom memengaruhi ekspor ke semua format (PDF, PNG, SVG, HTML)?**

Ya. Font yang terhubung digunakan oleh renderer di semua format ekspor.

**Apakah font kustom otomatis disematkan ke dalam PPTX yang dihasilkan?**

Tidak. Mendaftarkan font untuk rendering tidak sama dengan menyematkannya ke dalam PPTX. Jika Anda membutuhkan font berada di dalam file presentasi, Anda harus menggunakan [fitur penyematan](/slides/id/net/embedded-font/).

**Apakah saya dapat mengendalikan perilaku fallback ketika font kustom tidak memiliki glyph tertentu?**

Ya. Konfigurasikan [font substitution](/slides/id/net/font-substitution/), [replacement rules](/slides/id/net/font-replacement/), dan [fallback sets](/slides/id/net/fallback-font/) untuk menentukan font mana yang digunakan ketika glyph yang diminta tidak ada.

**Apakah saya dapat menggunakan font di kontainer Linux/Docker tanpa menginstalnya secara sistem-wide?**

Ya. Arahkan ke folder font Anda sendiri atau muat font dari array byte. Ini menghilangkan ketergantungan pada direktori font sistem dalam image kontainer.

> **Catatan untuk Linux/Docker**: Saat memanggil `FontsLoader.LoadExternalFonts`, pastikan setiap entri dalam array `directories` berisi jalur yang tidak kosong ke direktori yang ada. Jika variabel lingkungan yang digunakan untuk membangun jalur font tidak terdefinisi atau kosong, Aspose.Slides mungkin akan mencoba menyelesaikan nilai kosong tersebut sebagai jalur lengkap, yang mengakibatkan `System.ArgumentException`.

**Bagaimana dengan lisensi—apakah saya dapat menyematkan font kustom apa pun tanpa batasan?**

Anda bertanggung jawab atas kepatuhan lisensi font. Syaratnya bervariasi; beberapa lisensi melarang penyematan atau penggunaan komersial. Selalu tinjau EULA font sebelum mendistribusikan output.