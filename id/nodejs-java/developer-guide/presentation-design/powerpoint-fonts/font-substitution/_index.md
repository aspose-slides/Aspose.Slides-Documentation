---
title: Mengonfigurasi Penggantian Font dalam Presentasi Menggunakan JavaScript
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
- aturan substitusi
- aturan penggantian
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Mengonfigurasi aturan penggantian font dan memeriksa font yang diganti dalam Aspose.Slides untuk Node.js melalui Java saat merender atau mengonversi presentasi PowerPoint dan OpenDocument."
---
## **Gambaran Umum**

Penggantian font memungkinkan Aspose.Slides menggunakan font yang tersedia sebagai pengganti font yang tidak dapat diakses saat presentasi dirender atau dikonversi. Penggantian ini memengaruhi output yang dirender; tidak mengubah font yang ditugaskan pada konten presentasi.

Anda dapat menentukan font yang akan digunakan ketika font tertentu tidak tersedia, dan Anda dapat memeriksa penggantian yang akan dilakukan Aspose.Slides selama proses rendering. Ini membantu menjaga konsistensi output di lingkungan dengan font yang terpasang berbeda.

Jika sebuah font tersedia tetapi tidak memiliki tipe huruf tebal khusus, lihat [Menangani Font Tanpa Huruf Tebal Khusus](/slides/id/nodejs-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Bagian tersebut menjelaskan cara meraster teks yang terpengaruh selama ekspor PDF serta konsekuensinya untuk pemilihan teks, pencarian, dan skala.

## **Dapatkan Penggantian Font**

Gunakan metode [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) untuk menentukan font mana yang akan diganti ketika presentasi dirender. Metode ini mengembalikan objek [FontSubstitutionInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstitutioninfo/) yang mengidentifikasi nama font asli dan font pengganti.

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

Gunakan overload [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) dengan array indeks slide untuk memeriksa hanya penggantian yang diperlukan untuk merender slide tertentu. Ini berguna ketika Anda merender atau mengekspor sebagian presentasi, memeriksa presentasi besar secara inkremental, menemukan slide yang bergantung pada font yang tidak tersedia, menyiapkan paket font minimal untuk server atau kontainer, atau mendiagnosis perbedaan rendering tanpa memproses slide yang tidak terkait.

Overload ini mengharapkan primitive Java `int[]`. Buat dengan `java.newArray("int", [...])`; array JavaScript biasa dikonversi menjadi `Integer[]` dan tidak cocok dengan overload ini.

Array berisi indeks slide berbasis satu: `1` mengidentifikasi slide pertama. Sebaliknya, accessor koleksi [Presentation.getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getslides/) menggunakan indeks berbasis nol, sehingga slide yang sama diakses sebagai `presentation.getSlides().get_Item(0)`. Ingat perbedaan ini saat membuat array untuk menghindari kesalahan off‑by‑one.

Panggil overload melalui [Presentation.getFontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getfontsmanager/). Metode ini mengembalikan hanya penggantian yang ditentukan saat merender slide yang dipilih. Setiap hasil adalah objek [FontSubstitutionInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstitutioninfo/) yang berisi nama font asli dan penggantinya. Hasil mencerminkan lingkungan font saat ini, aturan fallback yang dikonfigurasi, aturan penggantian yang disimpan dalam [FontSubstRuleCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrulecollection/), dan [font yang dimuat secara eksternal](/slides/id/nodejs-java/custom-font/).

Penggantian yang sama dapat diperlukan oleh lebih dari satu slide yang dipilih. Hilangkan duplikasi hasil ketika Anda membuat inventaris font atau laporan preflight. Contoh berikut melaporkan setiap penggantian yang dikembalikan dan kemudian membuat daftar terurut pemetaan font unik:

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

Kelas [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/) menyediakan kedua overload. Pilih salah satu sesuai ruang lingkup operasi rendering:

| Overload | Gunakan ketika |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) tanpa argumen | Anda memerlukan penggantian untuk seluruh presentasi. |
| [getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) dengan `int[]` Java berisi indeks slide | Anda memerlukan penggantian untuk rentang terpilih, pemeriksaan inkremental, atau ekspor parsial. |

## **Atur Aturan Penggantian Font**

Untuk menentukan font yang harus digunakan Aspose.Slides ketika font sumber tidak tersedia:

1. Muat presentasi.  
2. Buat definisi font untuk font sumber dan font pengganti.  
3. Buat sebuah [FontSubstRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrule/) dengan kondisi [WhenInaccessible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstcondition/).  
4. Tambahkan aturan ke dalam [FontSubstRuleCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrulecollection/).  
5. Tetapkan koleksi menggunakan metode [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/setfontsubstrulelist/).  
6. Render atau konversi presentasi.

Contoh JavaScript berikut menggantikan `Arial` untuk `SomeRareFont` ketika `SomeRareFont` tidak tersedia, kemudian merender slide pertama untuk memverifikasi hasilnya. Font pengganti harus tersedia untuk Aspose.Slides.

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

{{% alert color="info" title="Note" %}}
Untuk perubahan tanpa syarat pada semua font yang digunakan di seluruh presentasi, lihat [Penggantian Font](/slides/id/nodejs-java/font-replacement/).
{{% /alert %}}

## **Batasan untuk Font Persamaan Matematika**

Aturan penggantian font merupakan bagian dari proses pemilihan font standar yang digunakan selama rendering dan konversi. Mereka berfungsi untuk teks reguler ketika Aspose.Slides dapat menggantikan font yang tidak dapat diakses dengan font yang tersedia menurut aturan.

Persamaan Office Math memiliki persyaratan tambahan. Jika sebuah persamaan menggunakan **Cambria Math**, Aspose.Slides mungkin memerlukan font tepat itu untuk menghitung dan merender tata letak persamaan. Aturan yang menggantikan dengan font matematika lain, seperti **STIX Two Math**, tidak dapat menggantikan **Cambria Math** untuk tujuan ini, dan rendering mungkin tetap melaporkan bahwa **Cambria Math** diperlukan.

Untuk merender atau mengonversi presentasi semacam itu, sediakan **Cambria Math** untuk Aspose.Slides. Instal di sistem operasi atau muat sebagai [font eksternal](/slides/id/nodejs-java/custom-font/).

Batasan ini berlaku pada tata letak persamaan. Aturan penggantian yang dijelaskan di atas tetap berlaku untuk teks presentasi biasa.

## **FAQ**

**Apa perbedaan antara penggantian font dan penggantian font?**

[Penggantian Font](/slides/id/nodejs-java/font-replacement/) secara sengaja mengubah satu font menjadi font lain di seluruh presentasi. Penggantian font memilih font untuk output yang dirender ketika kondisi yang dikonfigurasi terpenuhi, misalnya ketika font asli tidak tersedia.

**Kapan aturan penggantian diterapkan?**

Aturan berpartisipasi dalam [urutan pemilihan font](/slides/id/nodejs-java/font-selection-sequence/) selama rendering dan konversi. Dengan `WhenInaccessible`, aturan hanya digunakan ketika Aspose.Slides tidak dapat mengakses font sumber.

**Apa yang terjadi ketika sebuah font hilang dan tidak ada aturan penggantian yang dikonfigurasi?**

Aspose.Slides memilih font tersedia terdekat sesuai proses pemilihan fontnya. Hasilnya tergantung pada font yang tersedia di lingkungan runtime.

**Apakah saya dapat memuat font eksternal untuk menghindari penggantian?**

Ya. Anda dapat [memuat font eksternal](/slides/id/nodejs-java/custom-font/) sehingga Aspose.Slides dapat menggunakannya selama rendering dan konversi.

**Apakah Aspose mendistribusikan font bersama pustaka?**

Tidak. Anda bertanggung jawab menyediakan font dan mematuhi lisensinya.

**Apakah hasil penggantian dapat berbeda antara Windows, Linux, dan macOS?**

Ya. Font yang terpasang dan lokasi pencarian font berbeda per sistem operasi, sehingga font yang tersedia pada satu mesin mungkin memerlukan penggantian pada mesin lain.

**Bagaimana saya dapat membuat pemilihan font konsisten dalam konversi batch?**

Gunakan file dan versi font yang sama pada setiap mesin atau kontainer, [muat font eksternal yang diperlukan](/slides/id/nodejs-java/custom-font/), dan [sematkan font](/slides/id/nodejs-java/embedded-font/) bila lisensi memperbolehkan. Anda juga dapat memanggil [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) sebelum ekspor untuk mengidentifikasi penggantian yang tidak diharapkan.