---
title: Konfigurasi Substitusi Font pada Presentasi Menggunakan Python melalui Java
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
description: "Konfigurasikan aturan substitusi font dan inspeksi font yang disubstitusi dalam Aspose.Slides untuk Python melalui Java saat merender atau mengonversi presentasi PowerPoint dan OpenDocument."
---
## **Ringkasan**

Penggantian font memungkinkan Aspose.Slides menggunakan font yang tersedia sebagai pengganti font yang tidak dapat diakses saat presentasi dirender atau dikonversi. Penggantian ini memengaruhi output yang dirender; tidak mengubah font yang ditetapkan pada konten presentasi.

Anda dapat menentukan font yang akan digunakan ketika font tertentu tidak tersedia, dan Anda dapat memeriksa substitusi yang akan dilakukan Aspose.Slides selama proses rendering. Ini membantu menjaga konsistensi output di lingkungan dengan font yang terpasang berbeda.

## **Dapatkan Substitusi Font**

Gunakan metode [FontsManager.getSubstitutions](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsmanager/#getSubstitutions) untuk mengetahui font mana yang akan disubstitusi ketika presentasi dirender. Metode ini mengembalikan objek [FontSubstitutionInfo](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsubstitutioninfo/) yang mengidentifikasi nama font asli dan font pengganti.

Contoh Python berikut menampilkan semua substitusi font untuk sebuah presentasi:

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

## **Dapatkan Substitusi Font untuk Slide yang Dipilih**

Gunakan overload [FontsManager.getSubstitutions](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsmanager/#getSubstitutions) dengan argumen array integer Java untuk memeriksa hanya substitusi yang diperlukan untuk merender slide tertentu. Ini berguna ketika Anda merender atau mengekspor bagian dari presentasi, memeriksa presentasi besar secara inkremental, menemukan slide yang bergantung pada font yang tidak tersedia, menyiapkan paket font minimal untuk server atau kontainer, atau mendiagnosa perbedaan rendering tanpa memproses slide yang tidak relevan.

Array `slides` berisi indeks slide berbasis satu: `1` mengidentifikasi slide pertama. Sebaliknya, accessor koleksi [Presentation.getSlides](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getSlides) menggunakan indeks berbasis nol, sehingga slide yang sama diakses sebagai `presentation.getSlides().get_Item(0)`. Ingat perbedaan ini saat membangun array untuk menghindari kesalahan off-by-one.

Panggil overload melalui metode [Presentation.getFontsManager](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getFontsManager). Metode ini mengembalikan hanya substitusi yang ditentukan selama merender slide yang dipilih. Setiap hasil adalah objek [FontSubstitutionInfo](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsubstitutioninfo/) yang berisi nama font asli dan font pengganti. Hasil mencerminkan lingkungan font saat ini, aturan fallback yang dikonfigurasi, aturan substitusi yang disimpan dalam [FontSubstRuleCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsubstrulecollection/), dan [font yang dimuat secara eksternal](/slides/id/python-java/custom-font/).

Substitusi yang sama dapat diperlukan oleh lebih dari satu slide yang dipilih. Hilangkan duplikasi hasil ketika Anda membuat inventaris font atau laporan preflight. Contoh berikut melaporkan setiap substitusi yang dikembalikan dan kemudian membuat daftar terurut dari pemetaan font unik:

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

Kelas [FontsManager](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsmanager/) menyediakan kedua overload. Pilih salah satu sesuai ruang lingkup operasi rendering:

| Overload | Gunakan ketika |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsmanager/#getSubstitutions) tanpa argumen | Anda memerlukan substitusi untuk seluruh presentasi. |
| [getSubstitutions](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsmanager/#getSubstitutions) dengan array integer Java | Anda memerlukan substitusi untuk rentang terpilih, pemeriksaan inkremental, atau ekspor parsial. |

## **Atur Aturan Substitusi Font**

Untuk menentukan font yang harus digunakan Aspose.Slides ketika font sumber tidak tersedia:

1. Muat presentasi.  
2. Buat definisi font untuk font sumber dan font pengganti.  
3. Buat sebuah [FontSubstRule](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsubstrule/) dengan kondisi [WhenInaccessible](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsubstcondition/#WhenInaccessible).  
4. Tambahkan aturan ke [FontSubstRuleCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsubstrulecollection/).  
5. Tetapkan koleksi dengan menggunakan metode [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsmanager/#setFontSubstRuleList).  
6. Render atau konversi presentasi.

Contoh Python berikut menggantikan `Arial` untuk `SomeRareFont` ketika `SomeRareFont` tidak tersedia, kemudian merender slide pertama untuk memverifikasi hasilnya. Font pengganti harus tersedia untuk Aspose.Slides.

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
Untuk perubahan tanpa syarat pada font yang digunakan di seluruh presentasi, lihat [Penggantian Font](/slides/id/python-java/font-replacement/).
{{% /alert %}}

## **Keterbatasan untuk Font Persamaan Matematika**

Aturan substitusi font merupakan bagian dari proses pemilihan font standar yang digunakan selama rendering dan konversi. Mereka berfungsi untuk teks biasa ketika Aspose.Slides dapat mengganti font yang tidak dapat diakses dengan font yang tersedia sebagaimana ditentukan oleh aturan.

Persamaan Office Math memiliki persyaratan tambahan. Jika sebuah persamaan menggunakan **Cambria Math**, Aspose.Slides mungkin memerlukan font tepat itu untuk menghitung dan merender tata letak persamaan. Aturan yang menggantikan font matematika lain, seperti **STIX Two Math**, tidak dapat menggantikan **Cambria Math** untuk tujuan ini, dan rendering masih dapat melaporkan bahwa **Cambria Math** diperlukan.

Untuk merender atau mengonversi presentasi semacam itu, pastikan **Cambria Math** tersedia untuk Aspose.Slides. Instal font tersebut pada sistem operasi atau muat sebagai [font eksternal](/slides/id/python-java/custom-font/).

Keterbatasan ini berlaku pada tata letak persamaan. Aturan substitusi yang dijelaskan di atas tetap berlaku untuk teks presentasi biasa.

## **Tanya Jawab**

**Apa perbedaan antara penggantian font dan substitusi font?**  
[Penggantian font](/slides/id/python-java/font-replacement/) secara sengaja mengubah satu font menjadi font lain di seluruh presentasi. Substitusi font memilih font untuk output yang dirender ketika kondisi yang dikonfigurasi terpenuhi, seperti ketika font asli tidak tersedia.

**Kapan aturan substitusi diterapkan?**  
Aturan berpartisipasi dalam [urutan pemilihan font](/slides/id/python-java/font-selection-sequence/) selama rendering dan konversi. Dengan `WhenInaccessible`, aturan hanya digunakan ketika Aspose.Slides tidak dapat mengakses font sumber.

**Apa yang terjadi ketika sebuah font tidak ada dan tidak ada aturan substitusi yang dikonfigurasi?**  
Aspose.Slides memilih font yang paling mendekati yang tersedia sesuai proses pemilihan fontnya. Hasilnya bergantung pada font yang ada dalam lingkungan runtime.

**Apakah saya dapat memuat font eksternal untuk menghindari substitusi?**  
Ya. Anda dapat [memuat font eksternal](/slides/id/python-java/custom-font/) sehingga Aspose.Slides dapat menggunakannya selama rendering dan konversi.

**Apakah Aspose mendistribusikan font bersama pustaka?**  
Tidak. Anda bertanggung jawab menyediakan font dan mematuhi lisensi mereka.

**Apakah hasil substitusi dapat berbeda antara Windows, Linux, dan macOS?**  
Ya. Font yang terpasang dan lokasi pencarian font berbeda menurut sistem operasi, sehingga font yang tersedia pada satu mesin mungkin memerlukan substitusi pada mesin lain.

**Bagaimana saya dapat membuat pemilihan font konsisten dalam konversi batch?**  
Gunakan file font dan versi yang sama pada setiap mesin atau kontainer, [muat font eksternal yang diperlukan](/slides/id/python-java/custom-font/), dan [sematkan font](/slides/id/python-java/embedded-font/) bila lisensi memungkinkan. Anda juga dapat memanggil [FontsManager.getSubstitutions](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontsmanager/#getSubstitutions) sebelum ekspor untuk mengidentifikasi substitusi yang tidak diharapkan.