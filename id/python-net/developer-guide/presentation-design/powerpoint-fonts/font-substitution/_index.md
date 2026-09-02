---
title: "Konfigurasi Penggantian Font dalam Presentasi dengan Python"
linktitle: "Penggantian Font"
type: docs
weight: 70
url: /id/python-net/font-substitution/
keywords:
- "font"
- "font pengganti"
- "penggantian font"
- "ganti font"
- "penggantian font"
- "aturan penggantian"
- "aturan penggantian"
- "PowerPoint"
- "OpenDocument"
- "presentasi"
- "Python"
- "Aspose.Slides"
description: "Konfigurasikan aturan penggantian font dan periksa font yang diganti di Aspose.Slides untuk Python via .NET saat merender atau mengonversi presentasi PowerPoint dan OpenDocument."
---
## **Gambaran Umum**

Penggantian font memungkinkan Aspose.Slides menggunakan font yang tersedia sebagai pengganti font yang tidak dapat diakses saat presentasi dirender atau dikonversi. Penggantian memengaruhi keluaran yang dirender; tidak mengubah font yang ditetapkan pada konten presentasi.

Anda dapat menentukan font yang akan digunakan ketika font tertentu tidak tersedia, dan Anda dapat memeriksa penggantian yang akan dilakukan Aspose.Slides selama proses rendering. Ini membantu menjaga konsistensi output di lingkungan dengan font yang terpasang berbeda.

## **Mendapatkan Penggantian Font**

Gunakan metode [FontsManager.get_substitutions](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsmanager/get_substitutions/) untuk menentukan font mana yang akan diganti saat presentasi dirender. Metode ini mengembalikan objek [FontSubstitutionInfo](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsubstitutioninfo/) yang mengidentifikasi nama font asli dan font pengganti.

Contoh Python berikut menampilkan semua penggantian font untuk sebuah presentasi:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    for substitution in presentation.fonts_manager.get_substitutions():
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")
```

## **Mendapatkan Penggantian Font untuk Slide yang Dipilih**

Gunakan [FontsManager.get_substitutions](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsmanager/get_substitutions/) dengan daftar indeks slide untuk memeriksa hanya penggantian yang diperlukan untuk merender slide tertentu. Ini berguna saat Anda merender atau mengekspor sebagian presentasi, memeriksa presentasi besar secara bertahap, menemukan slide yang bergantung pada font yang tidak tersedia, menyiapkan paket font minimal untuk server atau kontainer, atau mendiagnosa perbedaan rendering tanpa memproses slide yang tidak terkait.

Daftar berisi indeks slide berbasis satu: `1` mengidentifikasi slide pertama. Sebaliknya, koleksi [Presentation.slides](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/slides/id/) menggunakan indeks berbasis nol, sehingga slide yang sama diakses sebagai `presentation.slides[0]`. Ingat perbedaan ini saat membangun daftar untuk menghindari kesalahan off‑by‑one.

Panggil metode melalui properti [Presentation.fonts_manager](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/fonts_manager/). Metode ini mengembalikan hanya penggantian yang ditentukan selama merender slide yang dipilih. Setiap hasil adalah objek [FontSubstitutionInfo](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsubstitutioninfo/) yang berisi nama font asli dan pengganti. Hasil mencerminkan lingkungan font saat ini, aturan fallback yang dikonfigurasi, aturan penggantian yang disimpan dalam sebuah [IFontSubstRuleCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/ifontsubstrulecollection/), dan [font yang dimuat secara eksternal](/slides/id/python-net/custom-font/).

Penggantian yang sama dapat diperlukan oleh lebih dari satu slide yang dipilih. Hapus duplikasi hasil ketika Anda membuat inventaris font atau laporan pra‑pemeriksaan. Contoh berikut melaporkan setiap penggantian yang dikembalikan dan kemudian membuat daftar terurut dari pemetaan font unik:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    selected_slides = [1, 3, 5]
    substitutions = list(presentation.fonts_manager.get_substitutions(selected_slides))

    print("Substitutions for the selected slides:")
    for substitution in substitutions:
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")

    preflight_entries = [f"{substitution.original_font_name} -> {substitution.substituted_font_name}" for substitution in substitutions]
    unique_preflight_entries = {entry.casefold(): entry for entry in preflight_entries}
    sorted_preflight_entries = sorted(unique_preflight_entries.values(), key=str.casefold)

    print("Deduplicated font preflight report:")
    for entry in sorted_preflight_entries:
        print(entry)
```

Kelas [FontsManager](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsmanager/) menyediakan kedua bentuk metode. Pilih salah satu sesuai ruang lingkup operasi rendering:

| Pemanggilan metode | Gunakan ketika |
|---|---|
| [get_substitutions](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsmanager/get_substitutions/) with no arguments | Anda membutuhkan penggantian untuk seluruh presentasi. |
| [get_substitutions](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsmanager/get_substitutions/) with a list of slide indexes | Anda membutuhkan penggantian untuk rentang terpilih, pemeriksaan bertahap, atau ekspor parsial. |

## **Menetapkan Aturan Penggantian Font**

Untuk menentukan font yang harus digunakan Aspose.Slides ketika font sumber tidak tersedia:

1. Muat presentasi.  
2. Buat definisi font untuk font sumber dan pengganti.  
3. Buat sebuah [FontSubstRule](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsubstrule/) dengan kondisi [WHEN_INACCESSIBLE](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsubstcondition/).  
4. Tambahkan aturan ke sebuah [FontSubstRuleCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsubstrulecollection/).  
5. Tetapkan koleksi ke properti [FontsManager.font_subst_rule_list](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsmanager/font_subst_rule_list/).  
6. Render atau konversi presentasi.

Contoh Python berikut menggantikan `Arial` untuk `SomeRareFont` ketika `SomeRareFont` tidak tersedia, kemudian merender slide pertama untuk memverifikasi hasilnya. Font pengganti harus tersedia bagi Aspose.Slides.

```python
import aspose.slides as slides

with slides.Presentation("Fonts.pptx") as presentation:
    source_font = slides.FontData("SomeRareFont")
    substitute_font = slides.FontData("Arial")
    substitution_rule = slides.FontSubstRule(source_font, substitute_font, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    substitution_rules = slides.FontSubstRuleCollection()
    substitution_rules.add(substitution_rule)
    presentation.fonts_manager.font_subst_rule_list = substitution_rules

    with presentation.slides[0].get_image(1, 1) as image:
        image.save("slide.jpg", slides.ImageFormat.JPEG)
```

{{% alert color="info" title="Note" %}}
Untuk perubahan tanpa syarat pada font yang digunakan di seluruh presentasi, lihat [Font Replacement](/slides/id/python-net/font-replacement/).
{{% /alert %}}

## **Batasan untuk Font Persamaan Matematika**

Aturan penggantian font merupakan bagian dari proses pemilihan font standar yang digunakan selama rendering dan konversi. Mereka bekerja untuk teks biasa ketika Aspose.Slides dapat mengganti font yang tidak dapat diakses dengan font tersedia yang ditentukan oleh aturan.

Persamaan Office Math memiliki persyaratan tambahan. Jika sebuah persamaan menggunakan **Cambria Math**, Aspose.Slides mungkin memerlukan font tersebut secara tepat untuk menghitung dan merender tata letak persamaan. Aturan yang mengganti dengan font matematika lain, seperti **STIX Two Math**, tidak dapat menggantikan **Cambria Math** untuk tujuan ini, dan rendering masih dapat melaporkan bahwa **Cambria Math** dibutuhkan.

Untuk merender atau mengonversi presentasi semacam itu, pastikan **Cambria Math** tersedia bagi Aspose.Slides. Instal font tersebut di sistem operasi atau muat sebagai [font eksternal](/slides/id/python-net/custom-font/).

Batasan ini berlaku pada tata letak persamaan. Aturan penggantian yang dijelaskan di atas tetap berlaku untuk teks presentasi biasa.

## **FAQ**

**What is the difference between font replacement and font substitution?**  
[Font replacement](/slides/id/python-net/font-replacement/) secara sengaja mengubah satu font menjadi font lain di seluruh presentasi. Penggantian font memilih font untuk output yang dirender ketika kondisi yang dikonfigurasi terpenuhi, seperti ketika font asli tidak tersedia.

**When are substitution rules applied?**  
Aturan berpartisipasi dalam [font selection sequence](/slides/id/python-net/font-selection-sequence/) selama rendering dan konversi. Dengan `WHEN_INACCESSIBLE`, sebuah aturan hanya digunakan ketika Aspose.Slides tidak dapat mengakses font sumber.

**What happens when a font is missing and no substitution rule is configured?**  
Aspose.Slides memilih font yang paling mendekati yang tersedia sesuai proses pemilihan fontnya. Hasilnya bergantung pada font yang tersedia di lingkungan runtime.

**Can I load external fonts to avoid substitution?**  
Ya. Anda dapat [load external fonts](/slides/id/python-net/custom-font/) sehingga Aspose.Slides dapat menggunakannya selama rendering dan konversi.

**Does Aspose distribute fonts with the library?**  
Tidak. Anda bertanggung jawab menyediakan font dan mematuhi lisensi mereka.

**Can substitution results differ between Windows, Linux, and macOS?**  
Ya. Font yang terpasang dan lokasi pencarian font berbeda antar sistem operasi, sehingga font yang tersedia pada satu mesin mungkin memerlukan penggantian pada mesin lain.

**How can I make font selection consistent in batch conversions?**  
Gunakan file font dan versi yang sama pada setiap mesin atau kontainer, [load required external fonts](/slides/id/python-net/custom-font/), dan [embed fonts](/slides/id/python-net/embedded-font/) bila lisensi mengizinkan. Anda juga dapat memanggil [FontsManager.get_substitutions](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsmanager/get_substitutions/) sebelum ekspor untuk mengidentifikasi penggantian yang tidak diharapkan.