---
title: Konfigurasi Substitusi Font pada Presentasi di C++
linktitle: Substitusi Font
type: docs
weight: 70
url: /id/cpp/font-substitution/
keywords:
- font
- font pengganti
- substitusi font
- ganti font
- penggantian font
- aturan substitusi
- aturan penggantian
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Konfigurasikan aturan substitusi font dan inspeksi font yang disubstitusi di Aspose.Slides untuk C++ saat merender atau mengonversi presentasi PowerPoint dan OpenDocument."
---
## **Gambaran Umum**

Penggantian font memungkinkan Aspose.Slides menggunakan font yang tersedia sebagai pengganti font yang tidak dapat diakses saat presentasi dirender atau dikonversi. Penggantian ini memengaruhi output yang dirender; tidak mengubah font yang ditetapkan pada konten presentasi.

Anda dapat menentukan font yang akan digunakan ketika font tertentu tidak tersedia, dan dapat memeriksa substitusi yang akan dilakukan Aspose.Slides selama proses rendering. Hal ini membantu menjaga konsistensi output di berbagai lingkungan dengan font yang terpasang berbeda.

## **Dapatkan Substitusi Font**

Gunakan metode [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/id/cpp/aspose.slides/ifontsmanager/getsubstitutions/) untuk menentukan font mana yang akan disubstitusi ketika presentasi dirender. Metode ini mengembalikan objek [FontSubstitutionInfo](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsubstitutioninfo/) yang mengidentifikasi nama font asli dan font pengganti.

Contoh C++ berikut menampilkan semua substitusi font untuk sebuah presentasi:

```cpp
#include <DOM/FontSubstitutionInfo.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

for (auto&& substitution : presentation->get_FontsManager()->GetSubstitutions())
{
    Console::WriteLine(u"{0} -> {1}", substitution->get_OriginalFontName(), substitution->get_SubstitutedFontName());
}

presentation->Dispose();
```

## **Dapatkan Substitusi Font untuk Slide yang Dipilih**

Gunakan overload [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/id/cpp/aspose.slides/ifontsmanager/getsubstitutions/) dengan argumen `System::ArrayPtr<int32_t> slides` untuk memeriksa hanya substitusi yang diperlukan untuk merender slide tertentu. Ini berguna saat Anda merender atau mengekspor sebagian presentasi, memeriksa presentasi besar secara bertahap, menemukan slide yang bergantung pada font yang tidak tersedia, menyiapkan paket font minimal untuk server atau kontainer, atau mendiagnosis perbedaan rendering tanpa memproses slide yang tidak terkait.

Array `slides` berisi indeks slide berbasis satu: `1` mengidentifikasi slide pertama. Sebaliknya, metode [Presentation::get_Slide](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_slide/) menggunakan indeks berbasis nol, sehingga slide yang sama diakses sebagai `presentation->get_Slide(0)`. Ingat perbedaan ini saat membangun array untuk menghindari kesalahan satu indeks.

Panggil overload tersebut melalui metode [Presentation::get_FontsManager](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_fontsmanager/). Metode ini hanya mengembalikan substitusi yang ditentukan selama merender slide yang dipilih. Setiap hasil adalah objek [FontSubstitutionInfo](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsubstitutioninfo/) yang berisi nama font asli dan pengganti. Hasil tersebut mencerminkan lingkungan font saat ini, aturan fallback yang dikonfigurasi, aturan substitusi yang disimpan dalam sebuah [IFontSubstRuleCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/ifontsubstrulecollection/), dan [font yang dimuat secara eksternal](/slides/id/cpp/custom-font/).

Substitusi yang sama dapat diperlukan oleh lebih dari satu slide yang dipilih. Hilangkan duplikasi hasil ketika Anda membuat inventaris font atau laporan preflight. Contoh berikut melaporkan setiap substitusi yang dikembalikan dan kemudian membuat daftar terurut dari pemetaan font unik:

```cpp
#include <DOM/FontSubstitutionInfo.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/collections/sorted_set.h>
#include <system/console.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

auto selectedSlides = MakeArray<int32_t>({1, 3, 5});
auto substitutions = presentation->get_FontsManager()->GetSubstitutions(selectedSlides);
auto sortedPreflightEntries = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());

Console::WriteLine(u"Substitutions for the selected slides:");
for (auto&& substitution : substitutions)
{
    auto entry = String::Format(u"{0} -> {1}", substitution->get_OriginalFontName(), substitution->get_SubstitutedFontName());
    Console::WriteLine(entry);
    sortedPreflightEntries->Add(entry);
}

Console::WriteLine(u"Deduplicated font preflight report:");
for (auto&& entry : sortedPreflightEntries)
{
    Console::WriteLine(entry);
}

presentation->Dispose();
```

Antarmuka [IFontsManager](https://reference.aspose.com/slides/id/cpp/aspose.slides/ifontsmanager/) menyediakan kedua overload. Pilih salah satu sesuai dengan ruang lingkup operasi rendering:

| Overload | Gunakan ketika |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/id/cpp/aspose.slides/ifontsmanager/getsubstitutions/) with no arguments | Anda memerlukan substitusi untuk seluruh presentasi. |
| [GetSubstitutions](https://reference.aspose.com/slides/id/cpp/aspose.slides/ifontsmanager/getsubstitutions/) with `System::ArrayPtr<int32_t> slides` | Anda memerlukan substitusi untuk rentang terpilih, pemeriksaan bertahap, atau ekspor parsial. |

## **Atur Aturan Substitusi Font**

Untuk menentukan font yang harus digunakan Aspose.Slides ketika font sumber tidak tersedia:

1. Muat presentasi.
2. Buat definisi font untuk font sumber dan font pengganti.
3. Buat sebuah [FontSubstRule](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsubstrule/) dengan kondisi [WhenInaccessible](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsubstcondition/).
4. Tambahkan aturan ke dalam sebuah [FontSubstRuleCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsubstrulecollection/).
5. Tetapkan koleksi dengan menggunakan metode [IFontsManager::set_FontSubstRuleList](https://reference.aspose.com/slides/id/cpp/aspose.slides/ifontsmanager/set_fontsubstrulelist/).
6. Render atau konversi presentasi.

Contoh C++ berikut menggantikan `Arial` untuk `SomeRareFont` ketika `SomeRareFont` tidak tersedia, dan kemudian merender slide pertama untuk memverifikasi hasilnya. Font pengganti harus tersedia untuk Aspose.Slides.

```cpp
#include <DOM/FontSubstCondition.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/Fonts/FontSubstRule.h>
#include <DOM/Fonts/FontSubstRuleCollection.h>
#include <DOM/IFontsManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");

auto sourceFont = MakeObject<FontData>(u"SomeRareFont");
auto substituteFont = MakeObject<FontData>(u"Arial");
auto substitutionRule = MakeObject<FontSubstRule>(sourceFont, substituteFont, FontSubstCondition::WhenInaccessible);

auto substitutionRules = MakeObject<FontSubstRuleCollection>();
substitutionRules->Add(substitutionRule);
presentation->get_FontsManager()->set_FontSubstRuleList(substitutionRules);

auto image = presentation->get_Slide(0)->GetImage(1.0f, 1.0f);
image->Save(u"slide.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Untuk perubahan tanpa syarat pada font yang digunakan di seluruh presentasi, lihat [Penggantian Font](/slides/id/cpp/font-replacement/).
{{% /alert %}}

## **Batasan untuk Font Persamaan Matematika**

Aturan substitusi font merupakan bagian dari proses pemilihan font standar yang digunakan selama rendering dan konversi. Aturan ini berfungsi untuk teks biasa ketika Aspose.Slides dapat mengganti font yang tidak dapat diakses dengan font yang tersedia sesuai aturan.

Persamaan Office Math memiliki persyaratan tambahan. Jika sebuah persamaan menggunakan **Cambria Math**, Aspose.Slides mungkin memerlukan font tersebut secara tepat untuk menghitung dan merender tata letak persamaan. Aturan yang menggantikan dengan font matematika lain, seperti **STIX Two Math**, tidak dapat menggantikan **Cambria Math** untuk tujuan ini, dan rendering masih dapat melaporkan bahwa **Cambria Math** diperlukan.

Untuk merender atau mengonversi presentasi semacam itu, pastikan **Cambria Math** tersedia untuk Aspose.Slides. Instal font tersebut di sistem operasi atau muat sebagai [font eksternal](/slides/id/cpp/custom-font/).

Batasan ini berlaku pada tata letak persamaan. Aturan substitusi yang dijelaskan di atas tetap berlaku untuk teks presentasi biasa.

## **FAQ**

**Apa perbedaan antara penggantian font dan substitusi font?**

[Penggantian Font](/slides/id/cpp/font-replacement/) secara sengaja mengubah satu font menjadi font lain di seluruh presentasi. Substitusi font memilih font untuk output yang dirender ketika kondisi yang dikonfigurasi terpenuhi, seperti ketika font asli tidak tersedia.

**Kapan aturan substitusi diterapkan?**

Aturan berpartisipasi dalam [urutan pemilihan font](/slides/id/cpp/font-selection-sequence/) selama rendering dan konversi. Dengan `WhenInaccessible`, aturan hanya digunakan ketika Aspose.Slides tidak dapat mengakses font sumber.

**Apa yang terjadi ketika sebuah font hilang dan tidak ada aturan substitusi yang dikonfigurasi?**

Aspose.Slides memilih font terdekat yang tersedia berdasarkan proses pemilihan fontnya. Hasilnya bergantung pada font yang tersedia di lingkungan runtime.

**Apakah saya dapat memuat font eksternal untuk menghindari substitusi?**

Ya. Anda dapat [memuat font eksternal](/slides/id/cpp/custom-font/) sehingga Aspose.Slides dapat menggunakannya selama rendering dan konversi.

**Apakah Aspose mendistribusikan font bersama perpustakaan?**

Tidak. Anda bertanggung jawab menyediakan font dan mematuhi lisensinya.

**Apakah hasil substitusi dapat berbeda antara Windows, Linux, dan macOS?**

Ya. Font yang terpasang dan lokasi pencarian font berbeda per sistem operasi, sehingga font yang tersedia di satu mesin mungkin memerlukan substitusi di mesin lain.

**Bagaimana cara membuat pemilihan font konsisten dalam konversi batch?**

Gunakan file font dan versi yang sama pada setiap mesin atau kontainer, [muat font eksternal yang diperlukan](/slides/id/cpp/custom-font/), dan [sematkan font](/slides/id/cpp/embedded-font/) bila lisensi mengizinkan. Anda juga dapat memanggil [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/id/cpp/aspose.slides/ifontsmanager/getsubstitutions/) sebelum ekspor untuk mengidentifikasi substitusi yang tidak diharapkan.