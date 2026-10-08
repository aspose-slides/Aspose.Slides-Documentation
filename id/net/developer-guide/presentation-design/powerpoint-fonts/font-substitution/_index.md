---
title: Mengonfigurasi Substitusi Font dalam Presentasi di .NET
linktitle: Substitusi Font
type: docs
weight: 70
url: /id/net/font-substitution/
keywords:
- font
- font pengganti
- substitusi font
- mengganti font
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

Font substitution memungkinkan Aspose.Slides menggunakan font yang tersedia sebagai pengganti font yang tidak dapat diakses saat presentasi dirender atau dikonversi. Substitusi memengaruhi output yang dirender; tidak mengubah font yang ditetapkan pada konten presentasi.

Anda dapat menentukan font yang akan digunakan ketika font tertentu tidak tersedia, dan Anda dapat memeriksa substitusi yang akan dilakukan Aspose.Slides selama proses rendering. Ini membantu menjaga konsistensi output di lingkungan dengan font yang terpasang berbeda.

Jika sebuah font tersedia tetapi tidak memiliki bentuk tebal khusus, lihat [Handle Fonts Without a Dedicated Bold Typeface](/slides/id/net/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Bagian tersebut menjelaskan cara meraster teks yang terpengaruh selama ekspor PDF serta konsekuensinya terhadap pemilihan teks, pencarian, dan skala.

## **Dapatkan Substitusi Font**

Gunakan metode [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) untuk menentukan font mana yang akan disubstitusi ketika presentasi dirender. Metode ini mengembalikan objek [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) yang mengidentifikasi nama font asli dan font pengganti.

Contoh C# berikut menampilkan semua substitusi font untuk sebuah presentasi:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **Dapatkan Substitusi Font untuk Slide yang Dipilih**

Gunakan overload [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) dengan argumen `int[] slides` untuk memeriksa hanya substitusi yang diperlukan untuk merender slide tertentu. Ini berguna saat Anda merender atau mengekspor sebagian presentasi, melakukan pemeriksaan inkremental pada presentasi besar, menemukan slide yang bergantung pada font yang tidak tersedia, menyiapkan paket font minimal untuk server atau kontainer, atau mendiagnosa perbedaan rendering tanpa memproses slide yang tidak relevan.

Array `slides` berisi indeks slide berbasis satu: `1` mengidentifikasi slide pertama. Sebaliknya, pengindeks koleksi [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) menggunakan basis nol, sehingga slide yang sama diakses dengan `presentation.Slides[0]`. Ingat perbedaan ini saat membangun array untuk menghindari kesalahan satu off-by-one.

Panggil overload melalui properti [Presentation.FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/). Metode ini mengembalikan hanya substitusi yang ditentukan selama merender slide yang dipilih. Setiap hasil adalah objek [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) yang berisi nama font asli dan font pengganti. Hasil mencerminkan lingkungan font saat ini dan [font yang dimuat secara eksternal](/slides/id/net/custom-font/). Aturan substitusi yang disimpan dalam [IFontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontsubstrulecollection/) mengubah output yang dirender tetapi tidak tercermin dalam hasil.

Substitusi yang sama dapat diperlukan oleh lebih dari satu slide yang dipilih. Hilangkan duplikat hasil ketika Anda membuat inventaris font atau laporan prapemeriksaan. Contoh berikut melaporkan setiap substitusi yang dikembalikan dan kemudian membuat daftar terurut dari pemetaan font unik:

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

Antarmuka [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) menyediakan kedua overload. Pilih salah satu sesuai cakupan operasi rendering:

| Overload | Gunakan ketika |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) tanpa argumen | Anda membutuhkan substitusi untuk seluruh presentasi. |
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) dengan `int[] slides` | Anda membutuhkan substitusi untuk rentang yang dipilih, pemeriksaan inkremental, atau ekspor parsial. |

## **Atur Aturan Substitusi Font**

Untuk menentukan font yang harus digunakan Aspose.Slides ketika font sumber tidak tersedia:

1. Muat presentasi.
2. Buat definisi font untuk font sumber dan font pengganti.
3. Buat sebuah [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) dengan kondisi [WhenInaccessible](https://reference.aspose.com/slides/net/aspose.slides/fontsubstcondition/).
4. Tambahkan aturan ke [FontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrulecollection/).
5. Tetapkan koleksi ke properti [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/fontsubstrulelist/).
6. Render atau konversi presentasi.

Contoh C# berikut menggantikan `Arial` untuk `SomeRareFont` ketika `SomeRareFont` tidak tersedia, lalu merender slide pertama untuk memverifikasi hasilnya. Font pengganti harus tersedia untuk Aspose.Slides.

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
Untuk perubahan tanpa syarat pada font yang digunakan di seluruh presentasi, lihat [Font Replacement](/slides/id/net/font-replacement/).
{{% /alert %}}

## **Batasan untuk Font Persamaan Matematika**

Aturan substitusi font merupakan bagian dari proses pemilihan font standar yang digunakan selama rendering dan konversi. Mereka berfungsi untuk teks biasa ketika Aspose.Slides dapat menggantikan font yang tidak dapat diakses dengan font yang tersedia sesuai aturan.

Persamaan Office Math memiliki persyaratan tambahan. Jika sebuah persamaan menggunakan **Cambria Math**, Aspose.Slides mungkin memerlukan font tepat tersebut untuk menghitung dan merender tata letak persamaan. Aturan yang menggantikan font matematika lain, seperti **STIX Two Math**, tidak dapat menggantikan **Cambria Math** untuk tujuan ini, dan rendering mungkin tetap melaporkan bahwa **Cambria Math** diperlukan.

Untuk merender atau mengonversi presentasi semacam itu, sediakan **Cambria Math** untuk Aspose.Slides. Instal font tersebut di sistem operasi atau muat sebagai [font eksternal](/slides/id/net/custom-font/).

Batasan ini berlaku pada tata letak persamaan. Aturan substitusi yang dijelaskan di atas tetap berlaku untuk teks presentasi biasa.

## **FAQ**

**Apa perbedaan antara penggantian font dan substitusi font?**

[Font replacement](/slides/id/net/font-replacement/) secara sengaja mengubah satu font menjadi font lain di seluruh presentasi. Substitusi font memilih font untuk output yang dirender ketika kondisi yang dikonfigurasi terpenuhi, seperti ketika font asli tidak tersedia.

**Kapan aturan substitusi diterapkan?**

Aturan berpartisipasi dalam [font selection sequence](/slides/id/net/font-selection-sequence/) selama rendering dan konversi. Dengan `WhenInaccessible`, aturan digunakan hanya ketika Aspose.Slides tidak dapat mengakses font sumber.

**Apa yang terjadi ketika sebuah font hilang dan tidak ada aturan substitusi yang dikonfigurasi?**

Aspose.Slides memilih font yang paling mendekati yang tersedia menurut proses pemilihan fontnya. Hasilnya tergantung pada font yang tersedia di lingkungan runtime.

**Bisakah saya memuat font eksternal untuk menghindari substitusi?**

Ya. Anda dapat [load external fonts](/slides/id/net/custom-font/) sehingga Aspose.Slides dapat menggunakannya selama rendering dan konversi.

**Apakah Aspose mendistribusikan font bersama perpustakaan?**

Tidak. Anda bertanggung jawab menyediakan font dan mematuhi lisensi mereka.

**Apakah hasil substitusi dapat berbeda antara Windows, Linux, dan macOS?**

Ya. Font yang terpasang dan lokasi pencarian font berbeda per sistem operasi, sehingga font yang tersedia di satu mesin mungkin memerlukan substitusi di mesin lain.

**Bagaimana saya dapat membuat pemilihan font konsisten dalam konversi batch?**

Gunakan file dan versi font yang sama di setiap mesin atau kontainer, [load required external fonts](/slides/id/net/custom-font/), dan [embed fonts](/slides/id/net/embedded-font/) bila lisensi mengizinkan. Anda juga dapat memanggil [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) sebelum ekspor untuk mengidentifikasi substitusi tak terduga.