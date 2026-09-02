---
title: Kelola Font Tema Spesifik Skrip dalam C++
linktitle: Font Tema Spesifik Skrip
type: docs
weight: 15
url: /id/cpp/script-specific-font-mappings/
keywords:
- font tema spesifik skrip
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
- C++
- Aspose.Slides
description: "Periksa, tambahkan, ganti, dan hapus pemetaan font spesifik skrip dalam tema PowerPoint dengan Aspose.Slides untuk C++."
---
## **Ikhtisar**

Tema presentasi dapat memilih keluarga font yang berbeda untuk sistem penulisan yang berbeda. Hal ini memungkinkan teks multibahasa yang masih menggunakan font tema mengikuti satu skema font terkoordinasi sekaligus menggunakan font yang cocok untuk Cyrillic, Arab, Jepang, Georgia, Thaana, dan skrip lainnya.

[IFontScheme](https://reference.aspose.com/slides/id/cpp/aspose.slides.theme/ifontscheme/) tema berisi koleksi font mayor, biasanya dipakai untuk judul, dan koleksi font minor, biasanya dipakai untuk isi teks. Selain properti font Latin dan Asia Timur, kedua koleksi tersebut mengekspos pemetaan dari tag sistem‑penulisan ke nama keluarga font melalui antarmuka [IFonts](https://reference.aspose.com/slides/id/cpp/aspose.slides/ifonts/).

Artikel ini menunjukkan cara memeriksa dan memodifikasi pemetaan tersebut dalam tema master presentasi serta memverifikasi bahwa perubahan tetap ada setelah siklus simpan‑dan‑muat ulang.

## **Memahami Tag Skrip**

Metode font skrip menggunakan sub‑tag skrip BCP 47 empat huruf untuk mengidentifikasi sistem penulisan. Nilai umum meliputi:

| Tag skrip | Sistem penulisan |
|---|---|
| `Cyrl` | Cyrillic |
| `Arab` | Arabic |
| `Hans` | Simplified Chinese |
| `Jpan` | Japanese |
| `Geor` | Georgian |
| `Thaa` | Thaana |

Pemetaan ini milik skema font tema, bukan bagian teks individu. Sebuah presentasi dapat mendefinisikan pemetaan yang berbeda untuk koleksi mayor dan minor, dan dapat menghilangkan pemetaan untuk beberapa skrip.

## **Mengakses dan Memeriksa Pemetaan Font Skrip**

Gunakan [Presentation::get_MasterTheme](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_mastertheme/) untuk mengakses tema tingkat presentasi. Metode [FontScheme::get_Major](https://reference.aspose.com/slides/id/cpp/aspose.slides.theme/fontscheme/get_major/) dan [FontScheme::get_Minor](https://reference.aspose.com/slides/id/cpp/aspose.slides.theme/fontscheme/get_minor/) mengembalikan dua koleksi [IFonts](https://reference.aspose.com/slides/id/cpp/aspose.slides/ifonts/).

Panggil [Fonts::GetScriptFontMap](https://reference.aspose.com/slides/id/cpp/aspose.slides/fonts/getscriptfontmap/) untuk mengambil semua pemetaan dari suatu koleksi. Untuk mencari satu sistem penulisan, panggil [Fonts::GetScriptFont](https://reference.aspose.com/slides/id/cpp/aspose.slides/fonts/getscriptfont/) dengan tag skripnya. `GetScriptFont` mengembalikan string null bila koleksi tersebut tidak mendefinisikan pemetaan yang diminta.

## **Memodifikasi Pemetaan dan Memverifikasi Persistensi**

Gunakan [Fonts::SetScriptFont](https://reference.aspose.com/slides/id/cpp/aspose.slides/fonts/setscriptfont/) untuk membuat pemetaan atau mengganti keluarga fontnya saat ini. Gunakan [Fonts::RemoveScriptFont](https://reference.aspose.com/slides/id/cpp/aspose.slides/fonts/removescriptfont/) untuk menghapus pemetaan.

Contoh end‑to‑end berikut membaca semua pemetaan mayor dan minor yang ada, mencari font mayor Jepang, mengubah font mayor Cyrillic, menghapus pemetaan minor Thaana, menyimpan presentasi, dan membukanya kembali untuk memverifikasi kedua perubahan. Agar langkah penghapusan tidak bergantung pada tema awal, contoh pertama membuat pemetaan Thaana hanya ketika belum ada yang didefinisikan.

```cpp
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <system/collections/idictionary.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto fontScheme = presentation->get_MasterTheme()->get_FontScheme();
auto majorFonts = fontScheme->get_Major();
auto minorFonts = fontScheme->get_Minor();

Console::WriteLine(u"Existing major mappings:");
for (auto&& mapping : majorFonts->GetScriptFontMap())
{
    Console::WriteLine(u"  {0}: {1}", mapping.get_Key(), mapping.get_Value());
}

Console::WriteLine(u"Existing minor mappings:");
for (auto&& mapping : minorFonts->GetScriptFontMap())
{
    Console::WriteLine(u"  {0}: {1}", mapping.get_Key(), mapping.get_Value());
}

auto japaneseFont = majorFonts->GetScriptFont(u"Jpan");
if (japaneseFont.IsNull())
{
    Console::WriteLine(u"No major Japanese font is defined.");
}
else
{
    Console::WriteLine(u"Major Japanese font: {0}", japaneseFont);
}

majorFonts->SetScriptFont(u"Cyrl", u"Arial");

if (minorFonts->GetScriptFont(u"Thaa").IsNull())
{
    minorFonts->SetScriptFont(u"Thaa", u"Arial");
}

minorFonts->RemoveScriptFont(u"Thaa");
presentation->Save(u"script-font-mappings.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"script-font-mappings.pptx");
auto savedFontScheme = savedPresentation->get_MasterTheme()->get_FontScheme();
auto savedMajorFonts = savedFontScheme->get_Major();
auto savedMinorFonts = savedFontScheme->get_Minor();
auto savedCyrillicFont = savedMajorFonts->GetScriptFont(u"Cyrl");
auto savedThaanaFont = savedMinorFonts->GetScriptFont(u"Thaa");

if (savedCyrillicFont == u"Arial")
{
    Console::WriteLine(u"The Cyrillic mapping was preserved.");
}
else
{
    Console::WriteLine(u"The Cyrillic mapping was not preserved.");
}

if (savedThaanaFont.IsNull())
{
    Console::WriteLine(u"The Thaana mapping removal was preserved.");
}
else
{
    Console::WriteLine(u"The Thaana mapping still exists.");
}
```

Verifikasi menggunakan perilaku string null yang sama seperti pencarian biasa: setelah penghapusan disimpan, `GetScriptFont(u"Thaa")` mengembalikan string null untuk koleksi minor.

## **Membedakan Pemetaan Tema dari Pengaturan Font Lain**

Pemetaan tema khusus skrip berpartisipasi dalam pemilihan font, tetapi menyelesaikan masalah yang berbeda dari format teks langsung, substitusi, dan fallback:

| Mekanisme | Tujuan | Efek mengubah pemetaan tema |
|---|---|---|
| Pemetaan font tema khusus skrip | Memilih font tema mayor atau minor untuk suatu sistem penulisan. | Teks yang tetap menggunakan font tema terkait dapat beralih ke keluarga baru yang dipetakan. |
| Font yang ditetapkan secara eksplisit pada bagian teks | Menetapkan keluarga font yang diminta pada bagian tersebut alih‑alih mengandalkan tema. | Bagian tersebut mungkin tetap tidak berubah karena format langsungnya menimpa pilihan tema. |
| Substitusi font | Mengganti font yang diminta ketika font tersebut tidak tersedia atau ketika aturan substitusi berlaku. | Beroperasi setelah font diminta; tidak mengubah pemetaan skrip tema. |
| Fallback font | Menyediakan glif yang tidak terdapat dalam font yang dipilih, biasanya untuk rentang Unicode tertentu. | Mengisi kekurangan glif; tidak mengubah pemetaan tema yang disimpan. |

Untuk informasi lebih lanjut tentang dua mekanisme terakhir, lihat [Font Substitution](/slides/id/cpp/font-substitution/) dan [Fallback Fonts](/slides/id/cpp/fallback-font/).

Mengubah pemetaan di [Presentation::get_MasterTheme](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_mastertheme/) memengaruhi hanya konten yang pemformatannya masih bergantung pada tema tersebut. Teks dapat mewarisi override tema dari master, layout, atau slide, atau menggunakan font yang ditetapkan secara eksplisit. Periksa level tersebut ketika hasil visual tidak mengikuti pemetaan tingkat presentasi.

## **Menyediakan Font yang Dipetakan dan Memvalidasi Hasil**

Pemetaan skrip menyimpan nama keluarga font; ia tidak memasang atau memuat berkas font yang bersangkutan. Untuk rendering dan ekspor yang konsisten, setiap font yang dipetakan harus dipasang di lingkungan atau disuplai ke Aspose.Slides melalui sumber khusus seperti [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsloader/loadexternalfonts/) atau [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/id/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/). Lihat [Custom Fonts](/slides/id/cpp/custom-font/) untuk opsi pemuatan yang tersedia.

Memverifikasi pemetaan yang disimpan hanya memastikan bahwa definisi tema tetap terjaga. Hal ini tidak membuktikan bahwa font tersedia, berisi semua glif yang diperlukan, atau menghasilkan tata letak yang diharapkan. Render teks representatif untuk setiap sistem penulisan yang diperlukan ke gambar atau PDF dan periksa outputnya. Ini akan menangkap font yang hilang, cakupan glif yang tidak lengkap, perilaku fallback, dan perubahan tata letak sebelum presentasi didistribusikan. Lihat [Convert PowerPoint Presentations](/slides/id/cpp/convert-powerpoint/) untuk contoh rendering dan ekspor.

## **Tanya Jawab**

**Apa yang dikembalikan `GetScriptFont` ketika sebuah skrip tidak dipetakan?**

[Fonts::GetScriptFont](https://reference.aspose.com/slides/id/cpp/aspose.slides/fonts/getscriptfont/) mengembalikan string null ketika pemetaan skrip yang diminta tidak didefinisikan dalam koleksi font mayor atau minor tersebut.

**Apakah `SetScriptFont` menambahkan pemetaan kedua ketika skrip sudah ada?**

Tidak. [Fonts::SetScriptFont](https://reference.aspose.com/slides/id/cpp/aspose.slides/fonts/setscriptfont/) membuat pemetaan bila belum ada dan mengganti keluarga font yang dipetakan bila tag skrip yang sama sudah ada.

**Mengapa mengubah pemetaan tema tidak mengubah beberapa teks?**

Teks tersebut mungkin memiliki font yang ditetapkan secara eksplisit, mewarisi tema yang berbeda melalui override, atau dipengaruhi oleh substitusi atau fallback saat rendering. Pemetaan skrip tingkat presentasi hanya mengontrol teks yang pemformatannya masih merujuk pada koleksi font tema tersebut.

**Apakah menyimpan dan membuka kembali cukup untuk memvalidasi output multibahasa?**

Tidak. Membuka kembali hanya memverifikasi keberlangsungan data tema. Selain itu, render teks representatif dari setiap sistem penulisan yang diperlukan untuk memastikan bahwa font yang dipetakan tersedia dan berisi glif yang diperlukan.