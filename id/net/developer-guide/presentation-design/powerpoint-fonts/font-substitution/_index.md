---
title: Konfigurasi Substitusi Font dalam Presentasi di .NET
linktitle: Substitusi Font
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
description: "Konfigurasi aturan substitusi font dan periksa font yang disubstitusi di Aspose.Slides untuk .NET saat merender atau mengonversi presentasi PowerPoint dan OpenDocument."
---
## **Gambaran Umum**

Substitusi font memungkinkan Aspose.Slides menggunakan font yang tersedia sebagai pengganti font yang tidak dapat diakses saat presentasi dirender atau dikonversi. Substitusi memengaruhi output yang dirender; tidak mengubah font yang ditetapkan pada konten presentasi.

Anda dapat menentukan font yang akan digunakan ketika font tertentu tidak tersedia, dan Anda dapat memeriksa substitusi yang akan dilakukan Aspose.Slides selama proses rendering. Hal ini membantu menjaga konsistensi output di lingkungan dengan font yang terpasang berbeda.

## **Dapatkan Substitusi Font**

Gunakan metode [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/id/net/aspose.slides/ifontsmanager/getsubstitutions/) untuk menentukan font mana yang akan disubstitusi saat presentasi dirender. Metode ini mengembalikan objek [FontSubstitutionInfo](https://reference.aspose.com/slides/id/net/aspose.slides/fontsubstitutioninfo/) yang mengidentifikasi nama font asli dan font pengganti.

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

Gunakan overload [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/id/net/aspose.slides/ifontsmanager/getsubstitutions/) dengan argumen `int[] slides` untuk memeriksa hanya substitusi yang diperlukan untuk merender slide tertentu. Ini berguna saat Anda merender atau mengekspor bagian dari presentasi, memeriksa presentasi besar secara bertahap, menemukan slide yang bergantung pada font yang tidak tersedia, menyiapkan paket font minimal untuk server atau kontainer, atau mendiagnosis perbedaan rendering tanpa memproses slide yang tidak terkait.

Array `slides` berisi indeks slide berbasis satu: `1` mengidentifikasi slide pertama. Sebaliknya, indeks koleksi [Presentation.Slides](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/slides/id/) berbasis nol, sehingga slide yang sama diakses sebagai `presentation.Slides[0]`. Ingat perbedaan ini saat membuat array untuk menghindari kesalahan off-by-one.

Panggil overload melalui properti [Presentation.FontsManager](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/fontsmanager/). Metode ini hanya mengembalikan substitusi yang ditentukan selama merender slide yang dipilih. Setiap hasil adalah objek [FontSubstitutionInfo](https://reference.aspose.com/slides/id/net/aspose.slides/fontsubstitutioninfo/) yang berisi nama font asli dan penggantinya. Hasil mencerminkan lingkungan font saat ini, aturan fallback yang dikonfigurasi, aturan substitusi yang disimpan dalam [IFontSubstRuleCollection](https://reference.aspose.com/slides/id/net/aspose.slides/ifontsubstrulecollection/), dan [font yang dimuat secara eksternal](/slides/id/net/custom-font/).

Substitusi yang sama dapat diperlukan oleh lebih dari satu slide yang dipilih. Hilangkan duplikasi hasil saat Anda membuat inventaris font atau laporan pra‑penerbangan. Contoh berikut melaporkan setiap substitusi yang dikembalikan dan kemudian membuat daftar terurut pemetaan font unik:

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

Antarmuka [IFontsManager](https://reference.aspose.com/slides/id/net/aspose.slides/ifontsmanager/) menyediakan kedua overload. Pilih salah satu sesuai cakupan operasi rendering:

| Overload | Gunakan ketika |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/id/net/aspose.slides/ifontsmanager/getsubstitutions/) tanpa argumen | Anda memerlukan substitusi untuk seluruh presentasi. |
| [GetSubstitutions](https://reference.aspose.com/slides/id/net/aspose.slides/ifontsmanager/getsubstitutions/) dengan `int[] slides` | Anda memerlukan substitusi untuk rentang terpilih, pemeriksaan bertahap, atau ekspor parsial. |

## **Atur Aturan Substitusi Font**

Untuk menentukan font yang harus digunakan Aspose.Slides ketika font sumber tidak tersedia:

1. Muat presentasi.  
2. Buat definisi font untuk font sumber dan font pengganti.  
3. Buat sebuah [FontSubstRule](https://reference.aspose.com/slides/id/net/aspose.slides/fontsubstrule/) dengan kondisi [WhenInaccessible](https://reference.aspose.com/slides/id/net/aspose.slides/fontsubstcondition/).  
4. Tambahkan aturan ke [FontSubstRuleCollection](https://reference.aspose.com/slides/id/net/aspose.slides/fontsubstrulecollection/).  
5. Tetapkan koleksi ke properti [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/id/net/aspose.slides/fontsmanager/fontsubstrulelist/).  
6. Render atau konversi presentasi.

Contoh C# berikut men-substitusi `Arial` untuk `SomeRareFont` ketika `SomeRareFont` tidak tersedia, kemudian merender slide pertama untuk memverifikasi hasilnya. Font pengganti harus tersedia bagi Aspose.Slides.

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

{{% alert color="info" title="Catatan" %}}

Untuk perubahan tanpa syarat pada semua font yang digunakan dalam sebuah presentasi, lihat [Penggantian Font](/slides/id/net/font-replacement/).

{{% /alert %}}

## **Batasan untuk Font Persamaan Matematika**

Aturan substitusi font merupakan bagian dari proses pemilihan font standar yang digunakan selama rendering dan konversi. Aturan ini bekerja untuk teks biasa ketika Aspose.Slides dapat mengganti font yang tidak dapat diakses dengan font yang tersedia sesuai aturan.

Persamaan Office Math memiliki persyaratan tambahan. Jika sebuah persamaan menggunakan **Cambria Math**, Aspose.Slides mungkin memerlukan font tersebut secara tepat untuk menghitung dan merender tata letak persamaan. Aturan yang men-substitusi font matematika lain, seperti **STIX Two Math**, tidak dapat menggantikan **Cambria Math** untuk tujuan ini, dan rendering tetap dapat melaporkan bahwa **Cambria Math** diperlukan.

Untuk merender atau mengonversi presentasi semacam itu, sediakan **Cambria Math** bagi Aspose.Slides. Instal font tersebut di sistem operasi atau muat sebagai [font eksternal](/slides/id/net/custom-font/).

Batasan ini berlaku pada tata letak persamaan. Aturan substitusi yang dijelaskan di atas tetap berlaku untuk teks presentasi biasa.

## **FAQ**

**Apa perbedaan antara penggantian font dan substitusi font?**

[Penggantian font](/slides/id/net/font-replacement/) secara sengaja mengubah satu font menjadi font lain di seluruh presentasi. Substitusi font memilih font untuk output yang dirender ketika kondisi yang dikonfigurasi terpenuhi, seperti ketika font asli tidak tersedia.

**Kapan aturan substitusi diterapkan?**

Aturan berpartisipasi dalam [urutan pemilihan font](/slides/id/net/font-selection-sequence/) selama rendering dan konversi. Dengan `WhenInaccessible`, aturan hanya digunakan ketika Aspose.Slides tidak dapat mengakses font sumber.

**Apa yang terjadi ketika sebuah font hilang dan tidak ada aturan substitusi yang dikonfigurasi?**

Aspose.Slides memilih font yang paling mendekati yang tersedia menurut proses pemilihan fontnya. Hasilnya bergantung pada font yang tersedia di lingkungan runtime.

**Bisakah saya memuat font eksternal untuk menghindari substitusi?**

Ya. Anda dapat [memuat font eksternal](/slides/id/net/custom-font/) sehingga Aspose.Slides dapat menggunakannya selama rendering dan konversi.

**Apakah Aspose mendistribusikan font bersama pustaka?**

Tidak. Anda bertanggung jawab menyediakan font dan mematuhi lisensinya.

**Apakah hasil substitusi dapat berbeda antara Windows, Linux, dan macOS?**

Ya. Font yang terpasang dan lokasi pencarian font berbeda menurut sistem operasi, sehingga font yang tersedia di satu mesin mungkin memerlukan substitusi di mesin lain.

**Bagaimana cara membuat pemilihan font konsisten dalam konversi batch?**

Gunakan file dan versi font yang sama di setiap mesin atau kontainer, [muat font eksternal yang diperlukan](/slides/id/net/custom-font/), dan [sematkan font](/slides/id/net/embedded-font/) bila lisensi memperbolehkan. Anda juga dapat memanggil [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/id/net/aspose.slides/ifontsmanager/getsubstitutions/) sebelum ekspor untuk mengidentifikasi substitusi yang tidak diharapkan.