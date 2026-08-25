---
title: Kelola Font Tema Khusus Skrip di PHP
linktitle: Font Tema Khusus Skrip
type: docs
weight: 15
url: /id/php-java/script-specific-font-mappings/
keywords:
- font khusus skrip
- pemetaan font tema
- presentasi multibahasa
- sistem penulisan
- font Cyrillic
- font Arab
- font Jepang
- font Georgian
- font Thaana
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Periksa, tambahkan, ganti, dan hapus pemetaan font khusus skrip dalam tema PowerPoint dengan Aspose.Slides untuk PHP via Java."
---
## **Gambaran Umum**

Tema presentasi dapat memilih keluarga font yang berbeda untuk sistem penulisan yang berbeda. Hal ini memungkinkan teks multibahasa yang masih menggunakan font tema mengikuti satu skema font terkoordinasi sambil menggunakan font yang sesuai untuk Cyrillic, Arab, Jepang, Georgian, Thaana, dan skrip lainnya.

Tema [FontScheme](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontscheme/) berisi koleksi font mayor, biasanya digunakan untuk judul, dan koleksi font minor, biasanya digunakan untuk teks badan. Selain pengaturan font Latin dan Asia Timur mereka, kedua koleksi [Fonts](https://reference.aspose.com/slides/id/php-java/aspose.slides/fonts/) menampilkan pemetaan dari tag sistem penulisan ke nama keluarga font.

Artikel ini menunjukkan cara memeriksa dan mengubah pemetaan tersebut dalam tema master presentasi serta memverifikasi bahwa perubahan bertahan melalui siklus simpan‑dan‑buka kembali.

## **Memahami Tag Skrip**

Metode font skrip menggunakan subtags skrip BCP 47 empat huruf untuk mengidentifikasi sistem penulisan. Nilai umum meliputi:

| Tag skrip | Sistem penulisan |
|---|---|
| `Cyrl` | Cyrillic |
| `Arab` | Arab |
| `Hans` | Mandarin Sederhana |
| `Jpan` | Jepang |
| `Geor` | Georgian |
| `Thaa` | Thaana |

Pemetaan ini milik skema font tema, bukan bagian teks individual. Sebuah presentasi dapat mendefinisikan pemetaan yang berbeda untuk koleksi mayor dan minor, dan dapat tidak menyertakan pemetaan untuk beberapa skrip.

## **Mengakses dan Memeriksa Pemetaan Font Skrip**

Gunakan [Presentation::getMasterTheme](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#getMasterTheme) untuk mengakses tema tingkat presentasi. Metode [MasterTheme::getFontScheme](https://reference.aspose.com/slides/id/php-java/aspose.slides/mastertheme/#getFontScheme), [FontScheme::getMajor](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontscheme/#getMajor), dan [FontScheme::getMinor](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontscheme/#getMinor) memberikan akses ke dua koleksi [Fonts](https://reference.aspose.com/slides/id/php-java/aspose.slides/fonts/).

Panggil [Fonts::getScriptFontMap](https://reference.aspose.com/slides/id/php-java/aspose.slides/fonts/#getScriptFontMap) untuk mengambil semua pemetaan dari sebuah koleksi. Untuk mencari satu sistem penulisan, panggil [Fonts::getScriptFont](https://reference.aspose.com/slides/id/php-java/aspose.slides/fonts/#getScriptFont) dengan tag skripnya. `Fonts::getScriptFont` mengembalikan `null` ketika koleksi tersebut tidak mendefinisikan pemetaan yang diminta.

## **Mengubah Pemetaan dan Memverifikasi Persistensi**

Gunakan [Fonts::setScriptFont](https://reference.aspose.com/slides/id/php-java/aspose.slides/fonts/#setScriptFont) untuk membuat pemetaan atau mengganti keluarga fontnya yang saat ini. Gunakan [Fonts::removeScriptFont](https://reference.aspose.com/slides/id/php-java/aspose.slides/fonts/#removeScriptFont) untuk menghapus pemetaan.

Contoh end‑to‑end berikut membaca semua pemetaan mayor dan minor yang ada, mencari font mayor Jepang, mengubah font mayor Cyrillic, menghapus pemetaan minor Thaana, menyimpan presentasi, dan membukanya kembali untuk memverifikasi kedua perubahan. Untuk membuat langkah penghapusan independen dari tema awal, contoh pertama membuat pemetaan Thaana hanya bila belum didefinisikan.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $fontScheme = $presentation->getMasterTheme()->getFontScheme();
    $majorFonts = $fontScheme->getMajor();
    $minorFonts = $fontScheme->getMinor();

    echo "Existing major mappings:" . PHP_EOL;
    $majorMappings = $majorFonts->getScriptFontMap()->iterator();
    while (java_values($majorMappings->hasNext())) {
        $mapping = $majorMappings->next();
        echo "  " . java_values($mapping->getKey()) . ": " . java_values($mapping->getValue()) . PHP_EOL;
    }

    echo "Existing minor mappings:" . PHP_EOL;
    $minorMappings = $minorFonts->getScriptFontMap()->iterator();
    while (java_values($minorMappings->hasNext())) {
        $mapping = $minorMappings->next();
        echo "  " . java_values($mapping->getKey()) . ": " . java_values($mapping->getValue()) . PHP_EOL;
    }

    $japaneseFont = $majorFonts->getScriptFont("Jpan");
    if (java_is_null($japaneseFont)) {
        echo "No major Japanese font is defined." . PHP_EOL;
    } else {
        echo "Major Japanese font: " . java_values($japaneseFont) . PHP_EOL;
    }

    $majorFonts->setScriptFont("Cyrl", "Arial");

    if (java_is_null($minorFonts->getScriptFont("Thaa"))) {
        $minorFonts->setScriptFont("Thaa", "Arial");
    }

    $minorFonts->removeScriptFont("Thaa");
    $presentation->save("script-font-mappings.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$savedPresentation = new Presentation("script-font-mappings.pptx");
try {
    $savedMajorFonts = $savedPresentation->getMasterTheme()->getFontScheme()->getMajor();
    $savedMinorFonts = $savedPresentation->getMasterTheme()->getFontScheme()->getMinor();
    $savedCyrillicFont = $savedMajorFonts->getScriptFont("Cyrl");
    $savedThaanaFont = $savedMinorFonts->getScriptFont("Thaa");

    if (!java_is_null($savedCyrillicFont) && java_values($savedCyrillicFont) === "Arial") {
        echo "The Cyrillic mapping was preserved." . PHP_EOL;
    } else {
        echo "The Cyrillic mapping was not preserved." . PHP_EOL;
    }

    if (java_is_null($savedThaanaFont)) {
        echo "The Thaana mapping removal was preserved." . PHP_EOL;
    } else {
        echo "The Thaana mapping still exists." . PHP_EOL;
    }
} finally {
    $savedPresentation->dispose();
}
```

Verifikasi menggunakan perilaku `null` yang sama seperti pencarian biasa: setelah penghapusan disimpan, `Fonts::getScriptFont("Thaa")` mengembalikan `null` untuk koleksi minor.

## **Membedakan Pemetaan Tema dari Pengaturan Font Lain**

Pemetaan font tema khusus skrip berpartisipasi dalam pemilihan font, tetapi menyelesaikan masalah yang berbeda dari pemformatan teks langsung, substitusi, dan fallback:

| Mekanisme | Tujuan | Efek mengubah pemetaan tema |
|---|---|---|
| Pemetaan font tema khusus skrip | Memilih font tema mayor atau minor untuk sebuah sistem penulisan. | Teks yang masih menggunakan font tema yang bersesuaian dapat menyelesaikan ke keluarga font yang baru dipetakan. |
| Font yang ditetapkan secara eksplisit ke bagian teks | Mengunci keluarga font yang diminta pada bagian tersebut alih‑alih bergantung pada tema. | Bagian tersebut mungkin tetap tidak berubah karena format langsungnya menimpa pilihan tema. |
| Substitusi font | Mengganti font yang diminta ketika font tersebut tidak tersedia atau ketika aturan substitusi berlaku. | Itu beraksi setelah font diminta; tidak mendefinisikan ulang pemetaan skrip tema. |
| Fallback font | Menyediakan glyph yang tidak terdapat dalam font terpilih, biasanya untuk rentang Unicode tertentu. | Ini mengisi cakupan glyph yang hilang; tidak mengubah pemetaan tema yang disimpan. |

Untuk informasi lebih lanjut tentang dua mekanisme terakhir, lihat [Font Substitution](/slides/id/php-java/font-substitution/) dan [Fallback Fonts](/slides/id/php-java/fallback-font/).

Mengubah pemetaan di [Presentation::getMasterTheme](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#getMasterTheme) memengaruhi hanya konten yang format efektifnya masih bergantung pada tema itu. Teks dapat mewarisi override tema dari master, tata letak, atau slide, atau menggunakan font yang ditetapkan secara eksplisit. Periksa tingkat‑tingkat tersebut ketika hasil yang terlihat tidak mengikuti pemetaan tingkat presentasi.

## **Menyediakan Font yang Dipetakan dan Memvalidasi Hasil**

Pemetaan skrip menyimpan nama keluarga font; ia tidak memasang atau memuat file font yang bersesuaian. Untuk rendering dan ekspor yang konsisten, setiap font yang dipetakan harus dipasang di lingkungan atau disuplai ke Aspose.Slides melalui sumber khusus seperti [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/id/php-java/aspose.slides/fontsloader/#loadExternalFonts) atau [LoadOptions::getDocumentLevelFontSources](https://reference.aspose.com/slides/id/php-java/aspose.slides/loadoptions/#getDocumentLevelFontSources). Lihat [Custom Fonts](/slides/id/php-java/custom-font/) untuk opsi pemuatan yang tersedia.

Memverifikasi pemetaan yang disimpan hanya memastikan definisi tema dipertahankan. Itu tidak membuktikan bahwa font tersedia, berisi semua glyph yang diperlukan, atau menghasilkan tata letak yang dimaksud. Render teks representatif untuk setiap sistem penulisan yang dibutuhkan ke dalam gambar atau PDF dan periksa hasilnya. Ini menangkap font yang hilang, cakupan glyph yang tidak lengkap, perilaku fallback, dan perubahan tata letak sebelum presentasi didistribusikan. Lihat [Convert PowerPoint Presentations](/slides/id/php-java/convert-powerpoint/) untuk contoh rendering dan ekspor.

## **Tanya Jawab**

**Apa yang dikembalikan `Fonts::getScriptFont` ketika sebuah skrip tidak dipetakan?**

`Fonts::getScriptFont` mengembalikan `null` ketika pemetaan skrip yang diminta tidak didefinisikan dalam koleksi font mayor atau minor tersebut.

**Apakah `Fonts::setScriptFont` menambahkan pemetaan kedua ketika skrip sudah ada?**

Tidak. `Fonts::setScriptFont` membuat pemetaan ketika belum ada dan mengganti keluarga font yang dipetakan ketika tag skrip yang sama sudah ada.

**Mengapa mengubah pemetaan tema tidak mengubah beberapa teks?**

Teks mungkin memiliki font yang ditetapkan secara eksplisit, mewarisi tema yang berbeda melalui override, atau dipengaruhi oleh substitusi atau fallback saat rendering. Pemetaan skrip tingkat presentasi hanya mengontrol teks yang format efektifnya masih merujuk pada koleksi font tema itu.

**Apakah menyimpan dan membuka kembali cukup untuk memvalidasi output multibahasa?**

Tidak. Membuka kembali memverifikasi persistensi data tema. Selain itu, render teks representatif dari setiap sistem penulisan yang diperlukan untuk memastikan bahwa font yang dipetakan tersedia dan berisi glyph yang diperlukan.