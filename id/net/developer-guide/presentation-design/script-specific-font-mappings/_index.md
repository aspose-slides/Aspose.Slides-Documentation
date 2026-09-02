---
title: Kelola Font Tema Khusus Skrip di .NET
linktitle: Font Tema Khusus Skrip
type: docs
weight: 15
url: /id/net/script-specific-font-mappings/
keywords:
- font khusus skrip
- pemetaan font tema
- presentasi multibahasa
- sistem penulisan
- font Cyrillic
- font Arab
- font Jepang
- font Georgia
- font Thaana
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Periksa, tambahkan, ganti, dan hapus pemetaan font khusus skrip dalam tema PowerPoint dengan Aspose.Slides untuk .NET."
---
## **Ikhtisar**

Sebuah tema presentasi dapat memilih keluarga font yang berbeda untuk sistem penulisan yang berbeda. Ini memungkinkan teks multibahasa yang tetap menggunakan font tema mengikuti satu skema font yang terkoordinasi sekaligus menggunakan font yang sesuai untuk Cyrillic, Arab, Jepang, Georgia, Thaana, dan skrip lainnya.

Theme tersebut memiliki [IFontScheme](https://reference.aspose.com/slides/id/net/aspose.slides.theme/ifontscheme/) yang berisi koleksi font utama, biasanya digunakan untuk judul, dan koleksi font minor, biasanya digunakan untuk teks badan. Selain properti font Latin dan Asia Timur mereka, kedua koleksi tersebut mengekspos pemetaan dari tag sistem penulisan ke nama keluarga font melalui antarmuka [IFonts](https://reference.aspose.com/slides/id/net/aspose.slides/ifonts/).

Artikel ini menunjukkan cara memeriksa dan memodifikasi pemetaan tersebut dalam master theme presentasi serta memverifikasi bahwa perubahan tetap ada setelah siklus simpan-dan-muat kembali.

## **Memahami Tag Skrip**

Metode font skrip menggunakan subtag skrip BCP 47 yang terdiri dari empat huruf untuk mengidentifikasi sistem penulisan. Nilai umum meliputi:

| Tag skrip | Sistem penulisan |
|---|---|
| `Cyrl` | Cyrillic |
| `Arab` | Arab |
| `Hans` | Cina Sederhana |
| `Jpan` | Jepang |
| `Geor` | Georgian |
| `Thaa` | Thaana |

Pemetaan ini merupakan bagian dari skema font tema, bukan dari bagian teks individu. Sebuah presentasi dapat mendefinisikan pemetaan yang berbeda untuk koleksi utama dan minor, dan dapat mengabaikan pemetaan untuk beberapa skrip.

## **Mengakses dan Memeriksa Pemetaan Font Skrip**

Gunakan [Presentation.MasterTheme](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/mastertheme/) untuk mengakses tema tingkat presentasi. Properti [FontScheme.Major](https://reference.aspose.com/slides/id/net/aspose.slides.theme/fontscheme/major/) dan [FontScheme.Minor](https://reference.aspose.com/slides/id/net/aspose.slides.theme/fontscheme/minor/) mengembalikan dua koleksi [IFonts](https://reference.aspose.com/slides/id/net/aspose.slides/ifonts/).

Gunakan [IFonts.GetScriptFontMap](https://reference.aspose.com/slides/id/net/aspose.slides/fonts/getscriptfontmap/) untuk mengambil semua pemetaan dari suatu koleksi. Untuk mencari satu sistem penulisan, panggil [IFonts.GetScriptFont](https://reference.aspose.com/slides/id/net/aspose.slides/fonts/getscriptfont/) dengan tag skripnya. `GetScriptFont` mengembalikan `null` bila koleksi tersebut tidak mendefinisikan pemetaan yang diminta.

## **Memodifikasi Pemetaan dan Memverifikasi Persistensi**

Gunakan [IFonts.SetScriptFont](https://reference.aspose.com/slides/id/net/aspose.slides/fonts/setscriptfont/) untuk membuat pemetaan atau mengganti keluarga font yang saat ini. Gunakan [IFonts.RemoveScriptFont](https://reference.aspose.com/slides/id/net/aspose.slides/fonts/removescriptfont/) untuk menghapus sebuah pemetaan.

Contoh end-to-end berikut membaca semua pemetaan utama dan minor yang ada, mencari font utama Jepang, mengubah font utama Cyrillic, menghapus pemetaan minor Thaana, menyimpan presentasi, dan membuka kembali untuk memverifikasi kedua perubahan. Agar langkah penghapusan tidak bergantung pada tema awal, contoh tersebut pertama-tama membuat pemetaan Thaana hanya bila belum ada yang didefinisikan.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

static void PrintScriptFontMap(string label, IFonts fonts)
{
    Console.WriteLine(label);
    foreach (var mapping in fonts.GetScriptFontMap())
    {
        Console.WriteLine($"  {mapping.Key}: {mapping.Value}");
    }
}

using var presentation = new Presentation();
var fontScheme = presentation.MasterTheme.FontScheme;
var majorFonts = fontScheme.Major;
var minorFonts = fontScheme.Minor;

PrintScriptFontMap("Existing major mappings:", majorFonts);
PrintScriptFontMap("Existing minor mappings:", minorFonts);

var japaneseFont = majorFonts.GetScriptFont("Jpan");
if (japaneseFont is null)
{
    Console.WriteLine("No major Japanese font is defined.");
}
else
{
    Console.WriteLine($"Major Japanese font: {japaneseFont}");
}

majorFonts.SetScriptFont("Cyrl", "Arial");

if (minorFonts.GetScriptFont("Thaa") is null)
{
    minorFonts.SetScriptFont("Thaa", "Arial");
}

minorFonts.RemoveScriptFont("Thaa");
presentation.Save("script-font-mappings.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("script-font-mappings.pptx");
var savedMajorFonts = savedPresentation.MasterTheme.FontScheme.Major;
var savedMinorFonts = savedPresentation.MasterTheme.FontScheme.Minor;
var savedCyrillicFont = savedMajorFonts.GetScriptFont("Cyrl");
var savedThaanaFont = savedMinorFonts.GetScriptFont("Thaa");

if (savedCyrillicFont == "Arial")
{
    Console.WriteLine("The Cyrillic mapping was preserved.");
}
else
{
    Console.WriteLine("The Cyrillic mapping was not preserved.");
}

if (savedThaanaFont is null)
{
    Console.WriteLine("The Thaana mapping removal was preserved.");
}
else
{
    Console.WriteLine("The Thaana mapping still exists.");
}
```

Verifikasi menggunakan perilaku `null` yang sama seperti pencarian biasa: setelah penghapusan disimpan, `GetScriptFont("Thaa")` mengembalikan `null` untuk koleksi minor.

## **Membedakan Pemetaan Tema dari Pengaturan Font Lain**

Pemetaan tema spesifik skrip berpartisipasi dalam pemilihan font, tetapi mereka menyelesaikan masalah yang berbeda dari pemformatan teks langsung, substitusi, dan fallback:

| Mekanisme | Tujuan | Efek mengubah pemetaan tema |
|---|---|---|
| Pemetaan font tema khusus skrip | Memilih font tema utama atau minor untuk sebuah sistem penulisan. | Teks yang masih menggunakan font tema yang bersangkutan dapat beralih ke keluarga font yang baru dipetakan. |
| Font yang ditetapkan secara eksplisit ke bagian teks | Menetapkan keluarga font yang diminta pada bagian tersebut alih-alih mengandalkan tema. | Bagian tersebut mungkin tetap tidak berubah karena format langsungnya menimpa pilihan tema. |
| Substitusi font | Mengganti font yang diminta ketika font tersebut tidak tersedia atau ketika aturan substitusi berlaku. | Beroperasi setelah font diminta; tidak mendefinisikan ulang pemetaan skrip tema. |
| Fallback font | Menyediakan glyph yang tidak dimiliki font yang dipilih, sering untuk rentang Unicode tertentu. | Mengisi cakupan glyph yang hilang; tidak mengubah pemetaan tema yang disimpan. |

Untuk informasi lebih lanjut tentang dua mekanisme terakhir, lihat [Substitusi Font](/slides/id/net/font-substitution/) dan [Font Fallback](/slides/id/net/fallback-font/).

Mengubah pemetaan di [Presentation.MasterTheme](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/mastertheme/) memengaruhi hanya konten yang format efektifnya masih bergantung pada tema tersebut. Teks dapat mewarisi penimpaan tema dari master, tata letak, atau slide, atau menggunakan font yang ditetapkan secara eksplisit. Periksa level tersebut ketika hasil yang terlihat tidak mengikuti pemetaan tingkat presentasi.

## **Menyediakan Font yang Dipetakan dan Memvalidasi Hasil**

Pemetaan skrip menyimpan nama keluarga font; ia tidak menginstal atau memuat file font yang bersangkutan. Untuk rendering dan ekspor yang konsisten, setiap font yang dipetakan harus diinstal di lingkungan atau disediakan ke Aspose.Slides melalui sumber kustom seperti [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/id/net/aspose.slides/fontsloader/loadexternalfonts/) atau [LoadOptions.DocumentLevelFontSources](https://reference.aspose.com/slides/id/net/aspose.slides/loadoptions/documentlevelfontsources/). Lihat [Custom Fonts](/slides/id/net/custom-font/) untuk opsi pemuatan yang tersedia.

Memverifikasi pemetaan yang disimpan hanya memastikan definisi tema tetap terjaga. Itu tidak membuktikan bahwa font tersedia, berisi semua glyph yang diperlukan, atau menghasilkan tata letak yang diinginkan. Render teks representatif untuk setiap sistem penulisan yang diperlukan ke gambar atau PDF dan periksa hasilnya. Hal ini menangkap font yang hilang, cakupan glyph yang tidak lengkap, perilaku fallback, dan perubahan tata letak sebelum presentasi didistribusikan. Lihat [Convert PowerPoint Presentations](/slides/id/net/convert-powerpoint/) untuk contoh rendering dan ekspor.

## **FAQ**

**Apa yang dikembalikan `GetScriptFont` ketika skrip tidak dipetakan?**

[IFonts.GetScriptFont](https://reference.aspose.com/slides/id/net/aspose.slides/fonts/getscriptfont/) mengembalikan `null` ketika pemetaan skrip yang diminta tidak didefinisikan dalam koleksi font utama atau minor tersebut.

**Apakah `SetScriptFont` menambah pemetaan kedua ketika skrip sudah ada?**

Tidak. [IFonts.SetScriptFont](https://reference.aspose.com/slides/id/net/aspose.slides/fonts/setscriptfont/) membuat pemetaan ketika belum ada dan mengganti keluarga font yang dipetakan ketika tag skrip yang sama sudah ada.

**Mengapa mengubah pemetaan tema tidak mengubah beberapa teks?**

Teks mungkin memiliki font yang ditetapkan secara eksplisit, mewarisi tema yang berbeda melalui penimpaan, atau terpengaruh oleh substitusi atau fallback selama rendering. Pemetaan skrip tingkat presentasi hanya mengontrol teks yang format efektifnya masih merujuk pada koleksi font tema tersebut.

**Apakah menyimpan dan membuka kembali cukup untuk memvalidasi output multibahasa?**

Tidak. Membuka kembali memverifikasi keberlanjutan data tema. Selain itu, render teks representatif dari setiap sistem penulisan yang diperlukan untuk memastikan bahwa font yang dipetakan tersedia dan berisi glyph yang diperlukan.