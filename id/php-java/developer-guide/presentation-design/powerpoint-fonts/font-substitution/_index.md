---
title: Konfigurasi Substitusi Font dalam Presentasi Menggunakan PHP
linktitle: Substitusi Font
type: docs
weight: 70
url: /id/php-java/font-substitution/
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
- PHP
- Aspose.Slides
description: "Konfigurasikan aturan substitusi font dan periksa font yang disubstitusi di Aspose.Slides untuk PHP via Java saat merender atau mengonversi presentasi PowerPoint dan OpenDocument."
---
## **Ikhtisar**

Substitusi font memungkinkan Aspose.Slides menggunakan font yang tersedia sebagai pengganti font yang tidak dapat diakses saat presentasi dirender atau dikonversi. Substitusi memengaruhi output yang dirender; tidak mengubah font yang ditetapkan pada konten presentasi.

Anda dapat menentukan font yang akan digunakan ketika font tertentu tidak tersedia, dan Anda dapat memeriksa substitusi yang akan dilakukan Aspose.Slides selama proses rendering. Ini membantu menjaga konsistensi output di lingkungan dengan font yang terpasang berbeda.

## **Dapatkan Substitusi Font**

Gunakan metode [FontsManager::getSubstitutions](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsmanager/getsubstitutions/) untuk menentukan font mana yang akan disubstitusi ketika presentasi dirender. Metode ini mengembalikan objek [FontSubstitutionInfo](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsubstitutioninfo/) yang mengidentifikasi nama font asli dan font yang disubstitusi.

Contoh PHP berikut menampilkan semua substitusi font untuk sebuah presentasi:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $enumerator = $presentation->getFontsManager()->getSubstitutions()->iterator();
    try {
        while (java_values($enumerator->hasNext())) {
            $substitution = $enumerator->next();
            $originalFontName = java_values($substitution->getOriginalFontName());
            $substitutedFontName = java_values($substitution->getSubstitutedFontName());
            echo $originalFontName . " -> " . $substitutedFontName . PHP_EOL;
        }
    } finally {
        $enumerator->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Dapatkan Substitusi Font untuk Slide yang Dipilih**

Gunakan overload [FontsManager::getSubstitutions](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsmanager/getsubstitutions/) dengan argumen `int[] slides` untuk memeriksa hanya substitusi yang diperlukan untuk merender slide tertentu. Ini berguna ketika Anda merender atau mengekspor sebagian presentasi, memeriksa presentasi besar secara inkremental, menemukan slide yang bergantung pada font yang tidak tersedia, menyiapkan paket font minimal untuk server atau kontainer, atau mendiagnosis perbedaan rendering tanpa memproses slide yang tidak terkait.

Array `slides` berisi indeks slide berbasis satu: `1` mengidentifikasi slide pertama. Sebaliknya, accessor koleksi [Presentation::getSlides](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#getSlides) menggunakan pengindeksan berbasis nol, sehingga slide yang sama diakses sebagai `$presentation->getSlides()->get_Item(0)`. Ingat perbedaan ini saat membangun array untuk menghindari kesalahan off-by-one.

Panggil overload melalui metode [Presentation::getFontsManager](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#getFontsManager). Metode ini mengembalikan hanya substitusi yang ditentukan selama rendering slide yang dipilih. Setiap hasil adalah objek [FontSubstitutionInfo](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsubstitutioninfo/) yang berisi nama font asli dan font yang disubstitusi. Hasil mencerminkan lingkungan font saat ini, aturan fallback yang dikonfigurasi, aturan substitusi yang disimpan dalam [FontSubstRuleCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsubstrulecollection/), dan [font yang dimuat secara eksternal](/slides/id/php-java/custom-font/).

Substitusi yang sama dapat diperlukan oleh lebih dari satu slide yang dipilih. Hilangkan duplikasi hasil ketika Anda membuat inventaris font atau laporan preflight. Contoh berikut melaporkan setiap substitusi yang dikembalikan dan kemudian membuat daftar terurut dari pemetaan font unik:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $selectedSlides = [1, 3, 5];
    $substitutions = [];
    $enumerator = $presentation->getFontsManager()->getSubstitutions($selectedSlides)->iterator();
    try {
        while (java_values($enumerator->hasNext())) {
            $substitutions[] = $enumerator->next();
        }
    } finally {
        $enumerator->dispose();
    }

    echo "Substitutions for the selected slides:" . PHP_EOL;
    foreach ($substitutions as $substitution) {
        $originalFontName = java_values($substitution->getOriginalFontName());
        $substitutedFontName = java_values($substitution->getSubstitutedFontName());
        echo $originalFontName . " -> " . $substitutedFontName . PHP_EOL;
    }

    $sortedPreflightEntries = [];
    foreach ($substitutions as $substitution) {
        $originalFontName = java_values($substitution->getOriginalFontName());
        $substitutedFontName = java_values($substitution->getSubstitutedFontName());
        $entry = $originalFontName . " -> " . $substitutedFontName;
        $sortedPreflightEntries[strtolower($entry)] = $entry;
    }
    ksort($sortedPreflightEntries, SORT_NATURAL | SORT_FLAG_CASE);

    echo "Deduplicated font preflight report:" . PHP_EOL;
    foreach ($sortedPreflightEntries as $entry) {
        echo $entry . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Kelas [FontsManager](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsmanager/) menyediakan kedua overload. Pilih salah satu sesuai lingkup operasi rendering:

| Overload | Gunakan ketika |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsmanager/getsubstitutions/) dengan tidak ada argumen | Anda memerlukan substitusi untuk seluruh presentasi. |
| [getSubstitutions](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsmanager/getsubstitutions/) dengan `int[] slides` | Anda memerlukan substitusi untuk rentang tertentu, pemeriksaan inkremental, atau ekspor parsial. |

## **Tetapkan Aturan Substitusi Font**

Untuk menentukan font yang harus digunakan Aspose.Slides ketika font sumber tidak tersedia:

1. Muat presentasi.  
2. Buat definisi font untuk font sumber dan font pengganti.  
3. Buat sebuah [FontSubstRule](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsubstrule/) dengan kondisi [WhenInaccessible](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsubstcondition/).  
4. Tambahkan aturan ke [FontSubstRuleCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsubstrulecollection/).  
5. Tetapkan koleksi dengan menggunakan metode [FontsManager::setFontSubstRuleList](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsmanager/setfontsubstrulelist/).  
6. Render atau konversi presentasi.

Contoh PHP berikut mensubstitusi `Arial` untuk `SomeRareFont` ketika `SomeRareFont` tidak tersedia, lalu merender slide pertama untuk memverifikasi hasilnya. Font pengganti harus tersedia untuk Aspose.Slides.

```php
use aspose\slides\FontData;
use aspose\slides\FontSubstCondition;
use aspose\slides\FontSubstRule;
use aspose\slides\FontSubstRuleCollection;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("Fonts.pptx");
try {
    $sourceFont = new FontData("SomeRareFont");
    $substituteFont = new FontData("Arial");
    $substitutionRule = new FontSubstRule($sourceFont, $substituteFont, FontSubstCondition::WhenInaccessible);

    $substitutionRules = new FontSubstRuleCollection();
    $substitutionRules->add($substitutionRule);
    $presentation->getFontsManager()->setFontSubstRuleList($substitutionRules);

    $image = $presentation->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    try {
        $image->save("slide.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Untuk pengubahan font secara tidak bersyarat di seluruh presentasi, lihat [Font Replacement](/slides/id/php-java/font-replacement/).
{{% /alert %}}

## **Batasan untuk Font Persamaan Matematika**

Aturan substitusi font merupakan bagian dari proses pemilihan font standar yang digunakan selama rendering dan konversi. Mereka bekerja untuk teks biasa ketika Aspose.Slides dapat mengganti font yang tidak dapat diakses dengan font yang tersedia sesuai aturan.

Persamaan Office Math memiliki persyaratan tambahan. Jika sebuah persamaan menggunakan **Cambria Math**, Aspose.Slides mungkin memerlukan font tersebut secara tepat untuk menghitung dan merender tata letak persamaan. Aturan yang menggantikan dengan font matematika lain, seperti **STIX Two Math**, tidak dapat menggantikan **Cambria Math** untuk tujuan ini, dan rendering masih dapat melaporkan bahwa **Cambria Math** diperlukan.

Untuk merender atau mengonversi presentasi semacam itu, sediakan **Cambria Math** untuk Aspose.Slides. Instal font tersebut di sistem operasi atau muat sebagai [font eksternal](/slides/id/php-java/custom-font/).

Batasan ini berlaku untuk tata letak persamaan. Aturan substitusi yang dijelaskan di atas tetap berlaku untuk teks presentasi biasa.

## **FAQ**

**Apa perbedaan antara penggantian font dan substitusi font?**

[Font replacement](/slides/id/php-java/font-replacement/) secara sengaja mengubah satu font menjadi font lain di seluruh presentasi. Substitusi font memilih font untuk output yang dirender ketika kondisi yang dikonfigurasi terpenuhi, seperti ketika font asli tidak tersedia.

**Kapan aturan substitusi diterapkan?**

Aturan berpartisipasi dalam [urutan pemilihan font](/slides/id/php-java/font-selection-sequence/) selama rendering dan konversi. Dengan `WhenInaccessible`, aturan hanya digunakan ketika Aspose.Slides tidak dapat mengakses font sumber.

**Apa yang terjadi ketika sebuah font hilang dan tidak ada aturan substitusi yang dikonfigurasi?**

Aspose.Slides memilih font yang paling mirip yang tersedia menurut proses pemilihan fontnya. Hasilnya bergantung pada font yang tersedia di lingkungan runtime.

**Bisakah saya memuat font eksternal untuk menghindari substitusi?**

Ya. Anda dapat [memuat font eksternal](/slides/id/php-java/custom-font/) sehingga Aspose.Slides dapat menggunakannya selama rendering dan konversi.

**Apakah Aspose mendistribusikan font bersama perpustakaan?**

Tidak. Anda bertanggung jawab menyediakan font dan mematuhi lisensi mereka.

**Apakah hasil substitusi dapat berbeda antara Windows, Linux, dan macOS?**

Ya. Font yang terpasang dan lokasi pencarian font berbeda antar sistem operasi, sehingga font yang tersedia di satu mesin mungkin memerlukan substitusi di mesin lain.

**Bagaimana cara membuat pemilihan font konsisten dalam konversi batch?**

Gunakan file dan versi font yang sama pada setiap mesin atau kontainer, [muat font eksternal yang diperlukan](/slides/id/php-java/custom-font/), dan [sematkan font](/slides/id/php-java/embedded-font/) bila lisensi mengizinkan. Anda juga dapat memanggil [FontsManager::getSubstitutions](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsmanager/getsubstitutions/) sebelum ekspor untuk mengidentifikasi substitusi yang tidak diharapkan.