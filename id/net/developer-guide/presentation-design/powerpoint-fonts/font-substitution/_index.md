---
title: Konfigurasi Penggantian Font dalam Presentasi di .NET
linktitle: Penggantian Font
type: docs
weight: 70
url: /id/net/font-substitution/
keywords:
- font
- font substitusi
- substitusi font
- ganti font
- penggantian font
- aturan substitusi
- aturan penggantian
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Konfigurasikan aturan substitusi font dan periksa font yang disubstitusi dalam Aspose.Slides untuk .NET saat merender atau mengonversi presentasi PowerPoint dan OpenDocument."
---
## **Gambaran Umum**

Penggantian font memungkinkan Aspose.Slides menggunakan font yang tersedia sebagai pengganti font yang tidak dapat diakses saat presentasi dirender atau dikonversi. Penggantian memengaruhi output yang dirender; tidak mengubah font yang ditetapkan pada konten presentasi.

Anda dapat menentukan font yang akan digunakan ketika font tertentu tidak tersedia, dan Anda dapat memeriksa penggantian yang akan dilakukan Aspose.Slides selama render. Hal ini membantu menjaga konsistensi output di seluruh lingkungan dengan font yang terpasang berbeda.

## **Dapatkan Penggantian Font**

Gunakan metode [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) untuk menentukan font mana yang akan digantikan saat presentasi dirender. Metode ini mengembalikan objek [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) yang mengidentifikasi nama font asli dan pengganti.

Contoh C# berikut mencantumkan semua penggantian font untuk sebuah presentasi:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **Dapatkan Penggantian Font untuk Slide Terpilih**

Gunakan overload [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) dengan argumen `int[] slides` untuk memeriksa hanya penggantian yang diperlukan untuk merender slide tertentu. Ini berguna ketika Anda merender atau mengekspor bagian dari presentasi, memeriksa presentasi besar secara bertahap, menemukan slide yang bergantung pada font yang tidak tersedia, menyiapkan paket font minimal untuk server atau kontainer, atau mendiagnosis perbedaan render tanpa memproses slide yang tidak terkait.

Array `slides` berisi indeks slide berbasis satu: `1` mengidentifikasi slide pertama. Sebaliknya, pengindeks koleksi [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) berbasis nol, sehingga slide yang sama diakses sebagai `presentation.Slides[0]`. Ingat perbedaan ini saat membuat array untuk menghindari kesalahan satu offset.

Panggil overload melalui properti [Presentation.FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/). Ini mengembalikan hanya penggantian yang ditentukan selama merender slide terpilih. Setiap hasil adalah objek [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) yang berisi nama font asli dan pengganti. Hasil mencerminkan lingkungan font saat ini dan [font yang dimuat secara eksternal](/slides/id/net/custom-font/). Aturan penggantian yang disimpan dalam [IFontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontsubstrulecollection/) mengubah output yang dirender tetapi tidak tercermin dalam hasil.

Penggantian yang sama dapat diperlukan oleh lebih dari satu slide terpilih. Hapus duplikat hasil ketika Anda membuat inventaris font atau laporan preflight. Contoh berikut melaporkan setiap penggantian yang dikembalikan dan kemudian membuat daftar terurut dari pemetaan font unik:

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

int[] selectedSlides = { 1, 3, 5 };
var substitutions = presentation.FontsManager.GetSubstitutions(selectedSlides).ToList();

Console.WriteLine("Substitutions for the selected slides:");
foreach (var substitution in substitutions)
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}

var preflightEntries = substitutions.Select(substitution => $"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
var uniquePreflightEntries = preflightEntries.Distinct(StringComparer.OrdinalIgnoreCase);
var sortedPreflightEntries = uniquePreflightEntries.OrderBy(entry => entry, StringComparer.OrdinalIgnoreCase).ToList();

Console.WriteLine("Deduplicated font preflight report:");
foreach (var entry in sortedPreflightEntries)
{
    Console.WriteLine(entry);
}
```

Antarmuka [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) menyediakan kedua overload. Pilih salah satu sesuai dengan lingkup operasi rendering:

| Overload | Digunakan ketika |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) with no arguments | Anda memerlukan penggantian untuk seluruh presentasi. |
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) with `int[] slides` | Anda memerlukan penggantian untuk rentang terpilih, pemeriksaan bertahap, atau ekspor parsial. |

## **Atur Aturan Penggantian Font**

Untuk menentukan font yang harus digunakan Aspose.Slides ketika font sumber tidak tersedia:

1. Muat presentasi.
2. Buat definisi font untuk font sumber dan pengganti.
3. Buat sebuah [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) dengan kondisi [WhenInaccessible](https://reference.aspose.com/slides/net/aspose.slides/fontsubstcondition/).
4. Tambahkan aturan ke dalam [FontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrulecollection/).
5. Tetapkan koleksi ke properti [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/fontsubstrulelist/).
6. Render atau konversi presentasi.

Contoh C# berikut menggantikan `Arial` dengan `SomeRareFont` ketika `SomeRareFont` tidak tersedia, dan kemudian merender slide pertama untuk memverifikasi hasilnya. Font pengganti harus tersedia untuk Aspose.Slides.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("Fonts.pptx");

var sourceFont = new FontData("SomeRareFont");
var substituteFont = new FontData("Arial");
var substitutionRule = new FontSubstRule(sourceFont, substituteFont, FontSubstCondition.WhenInaccessible);

var substitutionRules = new FontSubstRuleCollection();
substitutionRules.Add(substitutionRule);
presentation.FontsManager.FontSubstRuleList = substitutionRules;

using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("slide.jpg", ImageFormat.Jpeg);
```

{{% alert color="info" title="Note" %}}
Untuk perubahan font yang tidak bersyarat di seluruh presentasi, lihat [Penggantian Font](/slides/id/net/font-replacement/).
{{% /alert %}}

## **Batasan untuk Font Persamaan Matematika**

Aturan penggantian font merupakan bagian dari proses pemilihan font standar yang digunakan selama render dan konversi. Mereka berfungsi untuk teks biasa ketika Aspose.Slides dapat mengganti font yang tidak dapat diakses dengan font yang tersedia sesuai aturan.

Persamaan Office Math memiliki persyaratan tambahan. Jika sebuah persamaan menggunakan **Cambria Math**, Aspose.Slides mungkin memerlukan font tersebut secara tepat untuk menghitung dan merender tata letak persamaan. Aturan yang menggantikan dengan font matematika lain, seperti **STIX Two Math**, tidak dapat menggantikan **Cambria Math** untuk tujuan ini, dan proses render masih dapat melaporkan bahwa **Cambria Math** diperlukan.

Untuk merender atau mengonversi presentasi semacam itu, pastikan **Cambria Math** tersedia untuk Aspose.Slides. Instal font ini di sistem operasi atau muat sebagai [font eksternal](/slides/id/net/custom-font/).

Batasan ini berlaku untuk tata letak persamaan. Aturan penggantian yang dijelaskan di atas tetap berlaku untuk teks presentasi biasa.

## **FAQ**

**Apa perbedaan antara penggantian font dan substitusi font?**

[Penggantian Font](/slides/id/net/font-replacement/) secara sengaja mengubah satu font menjadi font lain di seluruh presentasi. Substitusi font memilih font untuk output yang dirender ketika kondisi yang dikonfigurasi terpenuhi, seperti ketika font asli tidak tersedia.

**Kapan aturan substitusi diterapkan?**

Aturan berpartisipasi dalam [urutan pemilihan font](/slides/id/net/font-selection-sequence/) selama render dan konversi. Dengan `WhenInaccessible`, aturan hanya digunakan ketika Aspose.Slides tidak dapat mengakses font sumber.

**Apa yang terjadi ketika sebuah font tidak ada dan tidak ada aturan substitusi yang dikonfigurasi?**

Aspose.Slides memilih font terdekat yang tersedia menurut proses pemilihan fontnya. Hasilnya bergantung pada font yang tersedia di lingkungan runtime.

**Apakah saya dapat memuat font eksternal untuk menghindari substitusi?**

Ya. Anda dapat [memuat font eksternal](/slides/id/net/custom-font/) sehingga Aspose.Slides dapat menggunakannya selama render dan konversi.

**Apakah Aspose mendistribusikan font bersama perpustakaan?**

Tidak. Anda bertanggung jawab menyediakan font dan mematuhi lisensinya.

**Apakah hasil substitusi dapat berbeda antara Windows, Linux, dan macOS?**

Ya. Font yang terpasang dan lokasi pencarian font berbeda antar sistem operasi, sehingga font yang tersedia di satu mesin mungkin memerlukan substitusi di mesin lain.

**Bagaimana cara membuat pemilihan font konsisten dalam konversi batch?**

Gunakan file font dan versi yang sama pada setiap mesin atau kontainer, [muat font eksternal yang diperlukan](/slides/id/net/custom-font/), dan [sematkan font](/slides/id/net/embedded-font/) bila lisensi mengizinkan. Anda juga dapat memanggil [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) sebelum ekspor untuk mengidentifikasi substitusi yang tidak terduga.