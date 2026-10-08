---
title: Konfigurasi Substitusi Font dalam Presentasi dengan Python
linktitle: Substitusi Font
type: docs
weight: 70
url: /id/python-net/font-substitution/
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
- Python
- Aspose.Slides
description: "Konfigurasikan aturan substitusi font dan periksa font yang digantikan dalam Aspose.Slides untuk Python via .NET saat merender atau mengonversi presentasi PowerPowerPoint dan OpenDocument."
---
## **Gambaran Umum**

Penggantian font memungkinkan Aspose.Slides untuk menggunakan font yang tersedia sebagai pengganti font yang tidak dapat diakses saat presentasi dirender atau dikonversi. Penggantian memengaruhi output yang dirender; tidak mengubah font yang ditetapkan pada konten presentasi.

Anda dapat menentukan font yang akan digunakan ketika font tertentu tidak tersedia, dan Anda dapat memeriksa penggantian yang akan dilakukan Aspose.Slides selama rendering. Ini membantu menjaga konsistensi output di antara lingkungan dengan font yang terpasang berbeda.

Jika sebuah font tersedia tetapi tidak memiliki jenis tebal khusus, lihat [Handle Fonts Without a Dedicated Bold Typeface](/slides/id/python-net/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Bagian tersebut menjelaskan cara merasterisasi teks yang terkena selama ekspor PDF serta konsekuensinya terhadap pemilihan teks, pencarian, dan penskalaan.

## **Mendapatkan Penggantian Font**

Gunakan metode [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) untuk menentukan font mana yang akan diganti saat presentasi dirender. Metode ini mengembalikan objek [FontSubstitutionInfo](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstitutioninfo/) yang mengidentifikasi nama font asli dan font pengganti.

Contoh Python berikut mencantumkan semua penggantian font untuk sebuah presentasi:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    for substitution in presentation.fonts_manager.get_substitutions():
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")
```

## **Mendapatkan Penggantian Font untuk Slide yang Dipilih**

Gunakan [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) dengan daftar indeks slide untuk memeriksa hanya penggantian yang diperlukan untuk merender slide tertentu. Ini berguna ketika Anda merender atau mengekspor bagian dari presentasi, memeriksa presentasi besar secara inkremental, menemukan slide yang bergantung pada font yang tidak tersedia, menyiapkan paket font minimal untuk server atau kontainer, atau mendiagnosa perbedaan rendering tanpa memproses slide yang tidak relevan.

Daftar tersebut berisi indeks slide berbasis satu: `1` menandakan slide pertama. Sebaliknya, koleksi [Presentation.slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) berbasis nol, sehingga slide yang sama diakses sebagai `presentation.slides[0]`. Ingat perbedaan ini saat menyusun daftar untuk menghindari kesalahan satu indeks.

Panggil metode melalui properti [Presentation.fonts_manager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/fonts_manager/). Metode ini mengembalikan hanya penggantian yang ditentukan selama merender slide yang dipilih. Setiap hasil adalah objek [FontSubstitutionInfo](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstitutioninfo/) yang berisi nama font asli dan penggantinya. Hasil mencerminkan lingkungan font saat ini, aturan fallback yang dikonfigurasi, aturan substitusi yang disimpan dalam [IFontSubstRuleCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ifontsubstrulecollection/), dan [externally loaded fonts](/slides/id/python-net/custom-font/).

Penggantian yang sama dapat diperlukan oleh lebih dari satu slide yang dipilih. Hilangkan duplikasi hasil ketika Anda membuat inventaris font atau laporan preflight. Contoh berikut melaporkan setiap penggantian yang dikembalikan dan kemudian membuat daftar terurut dari pemetaan font unik:

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

Kelas [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) menyediakan kedua bentuk metode tersebut. Pilih salah satu sesuai ruang lingkup operasi rendering:

| Pemanggilan Metode | Gunakan ketika |
|---|---|
| [get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) tanpa argumen | Anda membutuhkan penggantian untuk seluruh presentasi. |
| [get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) dengan daftar indeks slide | Anda membutuhkan penggantian untuk rentang terpilih, pemeriksaan inkremental, atau ekspor parsial. |

## **Atur Aturan Penggantian Font**

Untuk menentukan font yang harus digunakan Aspose.Slides ketika font sumber tidak tersedia:

1. Muat presentasi.
2. Buat definisi font untuk font sumber dan pengganti.
3. Buat sebuah [FontSubstRule](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrule/) dengan kondisi [WHEN_INACCESSIBLE](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstcondition/).
4. Tambahkan aturan ke [FontSubstRuleCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrulecollection/).
5. Tetapkan koleksi ke properti [FontsManager.font_subst_rule_list](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/font_subst_rule_list/).
6. Render atau konversi presentasi.

Contoh Python berikut menggantikan `Arial` untuk `SomeRareFont` ketika `SomeRareFont` tidak tersedia, lalu merender slide pertama untuk memverifikasi hasilnya. Font pengganti harus tersedia untuk Aspose.Slides.

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
Untuk perubahan tanpa syarat pada semua font yang digunakan dalam sebuah presentasi, lihat [Font Replacement](/slides/id/python-net/font-replacement/).
{{% /alert %}}

## **Batasan untuk Font Persamaan Matematika**

Aturan substitusi font merupakan bagian dari proses pemilihan font standar yang digunakan selama rendering dan konversi. Mereka bekerja untuk teks biasa ketika Aspose.Slides dapat mengganti font yang tidak dapat diakses dengan font tersedia yang ditentukan oleh sebuah aturan.

Persamaan Office Math memiliki persyaratan tambahan. Jika sebuah persamaan menggunakan **Cambria Math**, Aspose.Slides mungkin memerlukan font tepat tersebut untuk menghitung dan merender tata letak persamaan. Aturan yang menggantikan font matematika lain, seperti **STIX Two Math**, tidak dapat menggantikan **Cambria Math** untuk tujuan ini, dan rendering mungkin tetap melaporkan bahwa **Cambria Math** diperlukan.

Untuk merender atau mengonversi presentasi semacam itu, buat **Cambria Math** tersedia bagi Aspose.Slides. Instal font tersebut di sistem operasi atau muat sebagai [external font](/slides/id/python-net/custom-font/).

Batasan ini berlaku untuk tata letak persamaan. Aturan substitusi yang dijelaskan di atas tetap berlaku untuk teks presentasi biasa.

## **FAQ**

**Apa perbedaan antara penggantian font dan substitusi font?**

[Font replacement](/slides/id/python-net/font-replacement/) secara sengaja mengubah satu font menjadi font lain di seluruh presentasi. Substitusi font memilih font untuk output yang dirender ketika kondisi yang dikonfigurasi terpenuhi, seperti ketika font asli tidak tersedia.

**Kapan aturan substitusi diterapkan?**

Aturan berpartisipasi dalam [font selection sequence](/slides/id/python-net/font-selection-sequence/) selama rendering dan konversi. Dengan `WHEN_INACCESSIBLE`, aturan digunakan hanya ketika Aspose.Slides tidak dapat mengakses font sumber.

**Apa yang terjadi ketika sebuah font hilang dan tidak ada aturan substitusi yang dikonfigurasi?**

Aspose.Slides memilih font tersedia terdekat menurut proses seleksi fontnya. Hasilnya tergantung pada font yang tersedia di lingkungan runtime.

**Apakah saya dapat memuat font eksternal untuk menghindari substitusi?**

Ya. Anda dapat [load external fonts](/slides/id/python-net/custom-font/) sehingga Aspose.Slides dapat menggunakannya selama rendering dan konversi.

**Apakah Aspose mendistribusikan font bersama pustaka?**

Tidak. Anda bertanggung jawab menyediakan font dan mematuhi lisensi mereka.

**Apakah hasil substitusi dapat berbeda antara Windows, Linux, dan macOS?**

Ya. Font yang terpasang dan lokasi pencarian font berbeda di tiap sistem operasi, sehingga font yang tersedia pada satu mesin mungkin memerlukan substitusi pada mesin lain.

**Bagaimana saya dapat membuat pemilihan font konsisten dalam konversi batch?**

Gunakan file dan versi font yang sama pada setiap mesin atau kontainer, [load required external fonts](/slides/id/python-net/custom-font/), dan [embed fonts](/slides/id/python-net/embedded-font/) bila lisensi memperbolehkan. Anda juga dapat memanggil [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) sebelum ekspor untuk mengidentifikasi substitusi yang tidak diharapkan.