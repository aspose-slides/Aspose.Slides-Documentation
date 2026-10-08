---
title: Konfigurasi Substitusi Font dalam Presentasi Menggunakan Python melalui Java
linktitle: Substitusi Font
type: docs
weight: 70
url: /id/python-java/font-substitution/
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
- Java
- Aspose.Slides
description: "Konfigurasikan aturan substitusi font dan periksa font yang disubstitusi di Aspose.Slides untuk Python melalui Java saat merender atau mengonversi presentasi PowerPoint dan OpenDocument."
---
## **Ikhtisar**

Penggantian font memungkinkan Aspose.Slides menggunakan font yang tersedia sebagai pengganti font yang tidak dapat diakses saat presentasi dirender atau dikonversi. Penggantian memengaruhi output yang dirender; namun tidak mengubah font yang ditetapkan pada konten presentasi.

Anda dapat menentukan font yang akan digunakan ketika font tertentu tidak tersedia, dan Anda dapat memeriksa penggantian yang akan dilakukan Aspose.Slides selama proses rendering. Hal ini membantu menjaga konsistensi output di lingkungan dengan font yang terpasang berbeda.

Jika sebuah font tersedia tetapi tidak memiliki tipe huruf tebal khusus, lihat [Handle Fonts Without a Dedicated Bold Typeface](/slides/id/python-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Bagian tersebut menjelaskan cara meraster teks yang terpengaruh selama ekspor PDF serta konsekuensinya terhadap pemilihan teks, pencarian, dan penskalaan.

## **Dapatkan Penggantian Font**

Gunakan metode [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) untuk menentukan font mana yang akan diganti ketika presentasi dirender. Metode ini mengembalikan objek [FontSubstitutionInfo](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstitutioninfo/) yang mengidentifikasi nama font asli dan font pengganti.

Contoh Python berikut menampilkan semua penggantian font untuk sebuah presentasi:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    for substitution in presentation.getFontsManager().getSubstitutions():
        print(f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}")
finally:
    presentation.dispose()
```

## **Dapatkan Penggantian Font untuk Slide yang Dipilih**

Gunakan overload [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) dengan argumen array integer Java untuk memeriksa hanya penggantian yang diperlukan untuk merender slide tertentu. Ini berguna ketika Anda merender atau mengekspor bagian presentasi, memeriksa presentasi besar secara inkremental, menemukan slide yang bergantung pada font yang tidak tersedia, menyiapkan paket font minimal untuk server atau kontainer, atau mendiagnosa perbedaan rendering tanpa memproses slide yang tidak relevan.

Array `slides` berisi indeks slide berbasis satu: `1` mengidentifikasi slide pertama. Sebaliknya, accessor koleksi [Presentation.getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) menggunakan indeks berbasis nol, sehingga slide yang sama diakses sebagai `presentation.getSlides().get_Item(0)`. Ingat perbedaan ini saat membangun array untuk menghindari kesalahan satu indeks.

Panggil overload melalui metode [Presentation.getFontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getFontsManager). Metode ini mengembalikan hanya penggantian yang ditentukan selama rendering slide yang dipilih. Setiap hasil adalah objek [FontSubstitutionInfo](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstitutioninfo/) yang berisi nama font asli dan font pengganti. Hasil mencerminkan lingkungan font saat ini, aturan fallback yang dikonfigurasi, aturan penggantian yang disimpan dalam [FontSubstRuleCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrulecollection/), dan [externally loaded fonts](/slides/id/python-java/custom-font/).

Penggantian yang sama dapat diperlukan oleh lebih dari satu slide yang dipilih. Hilangkan duplikasi hasil ketika Anda membuat inventaris font atau laporan pra‑penerbangan. Contoh berikut melaporkan setiap penggantian yang dikembalikan dan kemudian membuat daftar terurut dari pemetaan font unik:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    selected_slides = jpype.JArray(jpype.JInt)([1, 3, 5])
    substitutions = list(presentation.getFontsManager().getSubstitutions(selected_slides))

    print("Substitutions for the selected slides:")
    for substitution in substitutions:
        print(f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}")

    unique_entries = {}
    for substitution in substitutions:
        entry = f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}"
        unique_entries.setdefault(entry.casefold(), entry)

    print("Deduplicated font preflight report:")
    for key in sorted(unique_entries):
        print(unique_entries[key])
finally:
    presentation.dispose()
```

Kelas [FontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/) menyediakan kedua overload. Pilih salah satu sesuai lingkup operasi rendering:

| Overload | Gunakan ketika |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) dengan tanpa argumen | Anda memerlukan penggantian untuk seluruh presentasi. |
| [getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) dengan array integer Java | Anda memerlukan penggantian untuk rentang tertentu, pemeriksaan inkremental, atau ekspor parsial. |

## **Atur Aturan Penggantian Font**

Untuk menentukan font yang harus digunakan Aspose.Slides ketika font sumber tidak tersedia:

1. Muat presentasi.  
2. Buat definisi font untuk font sumber dan font pengganti.  
3. Buat sebuah [FontSubstRule](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrule/) dengan kondisi [WhenInaccessible](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstcondition/#WhenInaccessible).  
4. Tambahkan aturan ke dalam [FontSubstRuleCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrulecollection/).  
5. Tetapkan koleksi dengan menggunakan metode [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#setFontSubstRuleList).  
6. Render atau konversi presentasi.

Contoh Python berikut menggantikan `Arial` untuk `SomeRareFont` ketika `SomeRareFont` tidak tersedia, lalu merender slide pertama untuk memverifikasi hasilnya. Font pengganti harus tersedia bagi Aspose.Slides.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, FontSubstCondition, FontSubstRule, FontSubstRuleCollection, ImageFormat, Presentation

presentation = Presentation("Fonts.pptx")
try:
    source_font = FontData("SomeRareFont")
    substitute_font = FontData("Arial")
    substitution_rule = FontSubstRule(source_font, substitute_font, FontSubstCondition.WhenInaccessible)

    substitution_rules = FontSubstRuleCollection()
    substitution_rules.add(substitution_rule)
    presentation.getFontsManager().setFontSubstRuleList(substitution_rules)

    image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        image.save("slide.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Untuk perubahan font secara tidak bersyarat di seluruh presentasi, lihat [Font Replacement](/slides/id/python-java/font-replacement/).
{{% /alert %}}

## **Batasan untuk Font Persamaan Matematika**

Aturan penggantian font adalah bagian dari proses pemilihan font standar yang digunakan selama rendering dan konversi. Mereka berfungsi untuk teks biasa ketika Aspose.Slides dapat mengganti font yang tidak dapat diakses dengan font yang tersedia sesuai aturan.

Persamaan Office Math memiliki persyaratan tambahan. Jika sebuah persamaan menggunakan **Cambria Math**, Aspose.Slides mungkin memerlukan font tepat itu untuk menghitung dan merender tata letak persamaan. Aturan yang menggantikan font matematika lain, seperti **STIX Two Math**, tidak dapat menggantikan **Cambria Math** untuk tujuan ini, dan rendering mungkin masih melaporkan bahwa **Cambria Math** diperlukan.

Untuk merender atau mengonversi presentasi semacam itu, pastikan **Cambria Math** tersedia bagi Aspose.Slides. Instal font ini di sistem operasi atau muat sebagai [external font](/slides/id/python-java/custom-font/).

Batasan ini berlaku untuk tata letak persamaan. Aturan penggantian yang dijelaskan di atas tetap berlaku untuk teks reguler dalam presentasi.

## **FAQ**

**Apa perbedaan antara font replacement dan font substitution?**  
[Font replacement](/slides/id/python-java/font-replacement/) secara sengaja mengubah satu font menjadi font lain di seluruh presentasi. Font substitution memilih font untuk output yang dirender ketika kondisi yang dikonfigurasi terpenuhi, misalnya ketika font asli tidak tersedia.

**Kapan aturan penggantian diterapkan?**  
Aturan berpartisipasi dalam [font selection sequence](/slides/id/python-java/font-selection-sequence/) selama rendering dan konversi. Dengan `WhenInaccessible`, aturan hanya digunakan ketika Aspose.Slides tidak dapat mengakses font sumber.

**Apa yang terjadi bila sebuah font hilang dan tidak ada aturan penggantian yang dikonfigurasi?**  
Aspose.Slides memilih font terdekat yang tersedia sesuai proses pemilihan fontnya. Hasilnya bergantung pada font yang tersedia di lingkungan runtime.

**Bisakah saya memuat font eksternal untuk menghindari penggantian?**  
Ya. Anda dapat [load external fonts](/slides/id/python-java/custom-font/) sehingga Aspose.Slides dapat menggunakannya selama rendering dan konversi.

**Apakah Aspose mendistribusikan font bersama pustaka?**  
Tidak. Anda bertanggung jawab menyediakan font dan mematuhi lisensi mereka.

**Apakah hasil penggantian dapat berbeda antara Windows, Linux, dan macOS?**  
Ya. Font yang terpasang dan lokasi pencarian font berbeda per sistem operasi, sehingga font yang tersedia di satu mesin mungkin memerlukan penggantian di mesin lain.

**Bagaimana saya dapat membuat pemilihan font konsisten dalam konversi batch?**  
Gunakan file font dan versi yang sama pada setiap mesin atau kontainer, [load required external fonts](/slides/id/python-java/custom-font/), dan [embed fonts](/slides/id/python-java/embedded-font/) bila lisensi mengizinkan. Anda juga dapat memanggil [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) sebelum ekspor untuk mengidentifikasi penggantian yang tidak diharapkan.