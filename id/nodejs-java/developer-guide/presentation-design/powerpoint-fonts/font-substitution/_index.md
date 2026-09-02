---
title: Konfigurasi Penggantian Font dalam Presentasi Menggunakan JavaScript
linktitle: Penggantian Font
type: docs
weight: 70
url: /id/nodejs-java/font-substitution/
keywords:
- font
- font pengganti
- penggantian font
- ganti font
- penggantian font
- aturan penggantian
- aturan penggantian
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Konfigurasikan aturan penggantian font dan periksa font yang diganti dalam Aspose.Slides untuk Node.js via Java saat merender atau mengonversi presentasi PowerPoint dan OpenDocument."
---
## **Ringkasan**

Penggantian font memungkinkan Aspose.Slides menggunakan font yang tersedia sebagai pengganti font yang tidak dapat diakses saat presentasi dirender atau dikonversi. Penggantian memengaruhi output yang dirender; tidak mengubah font yang ditetapkan pada konten presentasi.

Anda dapat menentukan font yang akan digunakan ketika font tertentu tidak tersedia, dan Anda dapat memeriksa penggantian yang akan dilakukan Aspose.Slides selama rendering. Hal ini membantu menjaga konsistensi output di lingkungan dengan font yang terpasang berbeda.

## **Dapatkan Penggantian Font**

Gunakan metode [FontsManager.getSubstitutions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) untuk menentukan font mana yang akan diganti ketika presentasi dirender. Metode ini mengembalikan objek [FontSubstitutionInfo](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsubstitutioninfo/) yang mengidentifikasi nama font asli dan font pengganti.

Contoh JavaScript berikut menampilkan semua penggantian font untuk sebuah presentasi:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var substitutions = presentation.getFontsManager().getSubstitutions().iterator();
    while (substitutions.hasNext()) {
        var substitution = substitutions.next();
        console.log(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }
} finally {
    presentation.dispose();
}
```

## **Dapatkan Penggantian Font untuk Slide yang Dipilih**

Gunakan overload [FontsManager.getSubstitutions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) dengan array indeks slide untuk memeriksa hanya penggantian yang diperlukan untuk merender slide tertentu. Ini berguna saat Anda merender atau mengekspor bagian dari presentasi, memeriksa presentasi besar secara bertahap, menemukan slide yang bergantung pada font yang tidak tersedia, menyiapkan paket font minimal untuk server atau kontainer, atau mendiagnosa perbedaan rendering tanpa memproses slide yang tidak relevan.

Overload ini mengharapkan primitive Java `int[]`. Buat dengan `java.newArray("int", [...])`; array JavaScript biasa dikonversi menjadi `Integer[]` dan tidak cocok dengan overload ini.

Array berisi indeks slide berbasis satu: `1` mengidentifikasi slide pertama. Sebaliknya, accessor koleksi [Presentation.getSlides](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/getslides/) menggunakan indeks berbasis nol, sehingga slide yang sama diakses sebagai `presentation.getSlides().get_Item(0)`. Ingat perbedaan ini saat membangun array untuk menghindari kesalahan satu indeks.

Panggil overload melalui [Presentation.getFontsManager](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/getfontsmanager/). Ia mengembalikan hanya penggantian yang ditentukan saat merender slide yang dipilih. Setiap hasil adalah objek [FontSubstitutionInfo](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsubstitutioninfo/) yang berisi nama font asli dan font pengganti. Hasil mencerminkan lingkungan font saat ini, aturan fallback yang dikonfigurasi, aturan penggantian yang disimpan dalam [FontSubstRuleCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsubstrulecollection/), dan [font yang dimuat secara eksternal](/slides/id/nodejs-java/custom-font/).

Penggantian yang sama dapat diperlukan oleh lebih dari satu slide yang dipilih. Hilangkan duplikasi hasil saat Anda membuat inventaris font atau laporan pra‑pemeriksaan. Contoh berikut melaporkan setiap penggantian yang dikembalikan lalu membuat daftar terurut dari pemetaan font unik:

```javascript
var aspose = aspose || {};
const java = require("java");
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var selectedSlides = java.newArray("int", [1, 3, 5]);
    var substitutions = [];
    var substitutionIterator = presentation.getFontsManager().getSubstitutions(selectedSlides).iterator();
    while (substitutionIterator.hasNext()) {
        substitutions.push(substitutionIterator.next());
    }

    console.log("Substitutions for the selected slides:");
    substitutions.forEach(function (substitution) {
        console.log(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    });

    var preflightEntries = substitutions.map(function (substitution) {
        return substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName();
    });
    var sortedPreflightEntries = Array.from(new Set(preflightEntries)).sort(function (first, second) {
        return first.localeCompare(second, undefined, { sensitivity: "base" });
    });

    console.log("Deduplicated font preflight report:");
    sortedPreflightEntries.forEach(function (entry) {
        console.log(entry);
    });
} finally {
    presentation.dispose();
}
```

Kelas [FontsManager](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsmanager/) menyediakan kedua overload. Pilih salah satu sesuai ruang lingkup operasi rendering:

| Overload | Gunakan ketika |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) tanpa argumen | Anda memerlukan penggantian untuk seluruh presentasi. |
| [getSubstitutions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) dengan `int[]` Java berisi indeks slide | Anda memerlukan penggantian untuk rentang tertentu, pemeriksaan bertahap, atau ekspor parsial. |

## **Atur Aturan Penggantian Font**

Untuk menentukan font yang harus digunakan Aspose.Slides ketika font sumber tidak tersedia:

1. Muat presentasi.
2. Buat definisi font untuk font sumber dan font pengganti.
3. Buat sebuah [FontSubstRule](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsubstrule/) dengan kondisi [WhenInaccessible](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsubstcondition/).
4. Tambahkan aturan ke [FontSubstRuleCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsubstrulecollection/).
5. Tetapkan koleksi dengan menggunakan metode [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsmanager/setfontsubstrulelist/).
6. Render atau konversi presentasi.

Contoh JavaScript berikut menggantikan `Arial` untuk `SomeRareFont` ketika `SomeRareFont` tidak tersedia, lalu merender slide pertama untuk memverifikasi hasilnya. Font pengganti harus tersedia untuk Aspose.Slides.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var sourceFont = new aspose.slides.FontData("SomeRareFont");
    var substituteFont = new aspose.slides.FontData("Arial");
    var substitutionRule = new aspose.slides.FontSubstRule(sourceFont, substituteFont, aspose.slides.FontSubstCondition.WhenInaccessible);

    var substitutionRules = new aspose.slides.FontSubstRuleCollection();
    substitutionRules.add(substitutionRule);
    presentation.getFontsManager().setFontSubstRuleList(substitutionRules);

    var image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0);
    try {
        image.save("slide.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Catatan" %}}
Untuk perubahan tanpa syarat pada font yang digunakan di seluruh presentasi, lihat [Font Replacement](/slides/id/nodejs-java/font-replacement/).
{{% /alert %}}

## **Batasan untuk Font Persamaan Matematis**

Aturan penggantian font adalah bagian dari proses pemilihan font standar yang digunakan selama rendering dan konversi. Mereka berfungsi untuk teks biasa ketika Aspose.Slides dapat mengganti font yang tidak dapat diakses dengan font yang tersedia sesuai aturan.

Persamaan Office Math memiliki persyaratan tambahan. Jika sebuah persamaan menggunakan **Cambria Math**, Aspose.Slides mungkin memerlukan font tepat itu untuk menghitung dan merender tata letak persamaan. Aturan yang menggantikan font matematis lain, seperti **STIX Two Math**, tidak dapat menggantikan **Cambria Math** untuk tujuan ini, dan rendering masih dapat melaporkan bahwa **Cambria Math** diperlukan.

Untuk merender atau mengonversi presentasi semacam itu, sediakan **Cambria Math** untuk Aspose.Slides. Instal font tersebut di sistem operasi atau muat sebagai [font eksternal](/slides/id/nodejs-java/custom-font/).

Batasan ini berlaku pada tata letak persamaan. Aturan penggantian yang dijelaskan di atas tetap berlaku untuk teks presentasi biasa.

## **FAQ**

**Apa perbedaan antara penggantian font dan penggantian font?**

[Font replacement](/slides/id/nodejs-java/font-replacement/) secara sengaja mengubah satu font menjadi font lain di seluruh presentasi. Penggantian font memilih font untuk output yang dirender ketika kondisi yang dikonfigurasi terpenuhi, seperti ketika font asli tidak tersedia.

**Kapan aturan penggantian diterapkan?**

Aturan berpartisipasi dalam [urutan pemilihan font](/slides/id/nodejs-java/font-selection-sequence/) selama rendering dan konversi. Dengan `WhenInaccessible`, sebuah aturan hanya digunakan ketika Aspose.Slides tidak dapat mengakses font sumber.

**Apa yang terjadi ketika sebuah font hilang dan tidak ada aturan penggantian yang dikonfigurasi?**

Aspose.Slides memilih font yang paling mendekati yang tersedia berdasarkan proses pemilihan fontnya. Hasilnya tergantung pada font yang tersedia di lingkungan runtime.

**Apakah saya dapat memuat font eksternal untuk menghindari penggantian?**

Ya. Anda dapat [memuat font eksternal](/slides/id/nodejs-java/custom-font/) sehingga Aspose.Slides dapat menggunakannya selama rendering dan konversi.

**Apakah Aspose mendistribusikan font bersama pustaka?**

Tidak. Anda bertanggung jawab menyediakan font dan mematuhi lisensinya.

**Apakah hasil penggantian dapat berbeda antara Windows, Linux, dan macOS?**

Ya. Font yang terpasang dan lokasi pencarian font berbeda per sistem operasi, sehingga font yang tersedia pada satu mesin mungkin memerlukan penggantian pada mesin lain.

**Bagaimana cara membuat pemilihan font konsisten dalam konversi batch?**

Gunakan file dan versi font yang sama pada setiap mesin atau kontainer, [muat font eksternal yang diperlukan](/slides/id/nodejs-java/custom-font/), dan [sematkan font](/slides/id/nodejs-java/embedded-font/) bila lisensi mengizinkan. Anda juga dapat memanggil [FontsManager.getSubstitutions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) sebelum ekspor untuk mengidentifikasi penggantian yang tidak diharapkan.