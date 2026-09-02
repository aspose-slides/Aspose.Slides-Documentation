---
title: Kelola Font Tema Spesifik Skrip dalam JavaScript
linktitle: Font Tema Spesifik Skrip
type: docs
weight: 15
url: /id/nodejs-java/script-specific-font-mappings/
keywords:
- font tema spesifik skrip
- pemetaan font tema
- presentasi multibahasa
- sistem penulisan
- font Cyrillic
- font Arab
- font Jepang
- font Georgia
- font Thaana
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Inspeksi, tambahkan, ganti, dan hapus pemetaan font spesifik skrip dalam tema PowerPoint dengan Aspose.Slides untuk Node.js."
---
## **Ringkasan**

Tema presentasi dapat memilih keluarga font yang berbeda untuk sistem penulisan yang berbeda. Ini memungkinkan teks multibahasa yang tetap menggunakan font tema mengikuti satu skema font terkoordinasi sambil menggunakan font yang cocok untuk Cyrillic, Arab, Jepang, Georgia, Thaana, dan skrip lain.

[FontScheme](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontscheme/) tema berisi koleksi font utama, biasanya digunakan untuk judul, dan koleksi font sekunder, biasanya digunakan untuk teks tubuh. Selain pengaturan font Latin dan Asia Timur mereka, kedua koleksi mengekspos pemetaan dari tag sistem‑penulisan ke nama keluarga font melalui kelas [Fonts](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fonts/).

Artikel ini menunjukkan cara memeriksa dan memodifikasi pemetaan tersebut di tema master presentasi serta memverifikasi bahwa perubahan bertahan setelah siklus simpan‑dan‑muat ulang.

## **Memahami Tag Skrip**

Metode font skrip menggunakan sub‑tag skrip BCP 47 berempat huruf untuk mengidentifikasi sistem penulisan. Nilai umum meliputi:

| Tag skrip | Sistem penulisan |
|---|---|
| `Cyrl` | Cyrillic |
| `Arab` | Arab |
| `Hans` | Cina Sederhana |
| `Jpan` | Jepang |
| `Geor` | Georgia |
| `Thaa` | Thaana |

Pemetaan ini merupakan bagian dari skema font tema, bukan bagian dari potongan teks individu. Sebuah presentasi dapat menentukan pemetaan yang berbeda untuk koleksi utama dan sekunder, dan dapat tidak menyertakan pemetaan untuk beberapa skrip.

## **Mengakses dan Memeriksa Pemetaan Font Skrip**

Gunakan [Presentation.getMasterTheme](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/getmastertheme/) untuk mengakses tema pada tingkat presentasi. Metode [FontScheme.getMajor](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontscheme/) dan [FontScheme.getMinor](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontscheme/) mengembalikan dua koleksi [Fonts](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fonts/).

Panggil [Fonts.getScriptFontMap](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fonts/) untuk mengambil semua pemetaan dari sebuah koleksi. Untuk mencari satu sistem penulisan, panggil [Fonts.getScriptFont](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fonts/) dengan tag skripnya. `getScriptFont` mengembalikan `null` bila koleksi tersebut tidak mendefinisikan pemetaan yang diminta.

## **Memodifikasi Pemetaan dan Memverifikasi Persistensi**

Gunakan [Fonts.setScriptFont](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fonts/) untuk membuat pemetaan atau mengganti keluarga fontnya saat ini. Gunakan [Fonts.removeScriptFont](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fonts/) untuk menghapus pemetaan.

Contoh end‑to‑end berikut membaca semua pemetaan utama dan sekunder yang ada, mencari font utama Jepang, mengubah font utama Cyrillic, menghapus pemetaan sekunder Thaana, menyimpan presentasi, dan membukanya kembali untuk memverifikasi kedua perubahan. Agar langkah penghapusan tidak bergantung pada tema awal, contoh pertama membuat pemetaan Thaana hanya bila belum ada.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var fontScheme = presentation.getMasterTheme().getFontScheme();
    var majorFonts = fontScheme.getMajor();
    var minorFonts = fontScheme.getMinor();

    console.log("Existing major mappings:");
    var majorMappings = majorFonts.getScriptFontMap().iterator();
    while (majorMappings.hasNext()) {
        var mapping = majorMappings.next();
        console.log("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    console.log("Existing minor mappings:");
    var minorMappings = minorFonts.getScriptFontMap().iterator();
    while (minorMappings.hasNext()) {
        var mapping = minorMappings.next();
        console.log("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    var japaneseFont = majorFonts.getScriptFont("Jpan");
    if (japaneseFont == null) {
        console.log("No major Japanese font is defined.");
    } else {
        console.log("Major Japanese font: " + japaneseFont);
    }

    majorFonts.setScriptFont("Cyrl", "Arial");

    if (minorFonts.getScriptFont("Thaa") == null) {
        minorFonts.setScriptFont("Thaa", "Arial");
    }

    minorFonts.removeScriptFont("Thaa");
    presentation.save("script-font-mappings.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

var savedPresentation = new aspose.slides.Presentation("script-font-mappings.pptx");
try {
    var savedMajorFonts = savedPresentation.getMasterTheme().getFontScheme().getMajor();
    var savedMinorFonts = savedPresentation.getMasterTheme().getFontScheme().getMinor();
    var savedCyrillicFont = savedMajorFonts.getScriptFont("Cyrl");
    var savedThaanaFont = savedMinorFonts.getScriptFont("Thaa");

    if (savedCyrillicFont === "Arial") {
        console.log("The Cyrillic mapping was preserved.");
    } else {
        console.log("The Cyrillic mapping was not preserved.");
    }

    if (savedThaanaFont == null) {
        console.log("The Thaana mapping removal was preserved.");
    } else {
        console.log("The Thaana mapping still exists.");
    }
} finally {
    savedPresentation.dispose();
}
```

Verifikasi menggunakan perilaku `null` yang sama seperti pencarian biasa: setelah penghapusan disimpan, `getScriptFont("Thaa")` mengembalikan `null` untuk koleksi sekunder.

## **Membedakan Pemetaan Tema dari Pengaturan Font Lain**

Pemetaan tema yang spesifik skrip berpartisipasi dalam pemilihan font, tetapi menyelesaikan masalah yang berbeda dari pemformatan teks langsung, substitusi, dan fallback:

| Mekanisme | Tujuan | Pengaruh mengubah pemetaan tema |
|---|---|---|
| Pemetaan font tema spesifik skrip | Memilih font tema utama atau sekunder untuk sebuah sistem penulisan. | Teks yang masih menggunakan font tema terkait dapat beralih ke keluarga yang baru dipetakan. |
| Font yang ditetapkan secara eksplisit pada potongan teks | Menetapkan keluarga font yang diminta pada potongan tersebut alih‑alih mengandalkan tema. | Potongan dapat tetap tidak berubah karena pemformatan langsungnya menimpa pilihan tema. |
| Substitusi font | Mengganti font yang diminta bila font tersebut tidak tersedia atau bila aturan substitusi berlaku. | Beraksi setelah font diminta; tidak mengubah pemetaan skrip tema. |
| Fallback font | Menyediakan glyph yang tidak ada dalam font yang dipilih, biasanya untuk rentang Unicode tertentu. | Mengisi kekurangan glyph; tidak mengubah pemetaan tema yang disimpan. |

Untuk informasi lebih lanjut tentang dua mekanisme terakhir, lihat [Font Substitution](/slides/id/nodejs-java/font-substitution/) dan [Fallback Fonts](/slides/id/nodejs-java/fallback-font/).

Mengubah pemetaan di [Presentation.getMasterTheme](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/getmastertheme/) memengaruhi hanya konten yang pemformatan efektifnya masih bergantung pada tema tersebut. Teks dapat mewarisi override tema dari master, layout, atau slide, atau menggunakan font yang ditetapkan secara eksplisit. Periksa tingkat‑tingkat itu bila hasil yang terlihat tidak mengikuti pemetaan pada tingkat presentasi.

## **Menyediakan Font yang Dipetakan dan Memvalidasi Hasil**

Pemetaan skrip menyimpan nama keluarga font; ia tidak memasang atau memuat berkas font yang bersangkutan. Agar render konsisten dan ekspor tepat, setiap font yang dipetakan harus dipasang di lingkungan atau disediakan ke Aspose.Slides melalui sumber khusus seperti [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) atau [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/loadoptions/). Lihat [Custom Fonts](/slides/id/nodejs-java/custom-font/) untuk opsi pemuatan yang tersedia.

Memverifikasi pemetaan yang disimpan hanya memastikan definisi tema tetap terjaga. Ini tidak membuktikan bahwa font tersedia, berisi semua glyph yang diperlukan, atau menghasilkan tata letak yang diinginkan. Render teks perwakilan untuk setiap sistem penulisan yang diperlukan ke gambar atau PDF dan periksa outputnya. Langkah ini menangkap font yang hilang, cakupan glyph tidak lengkap, perilaku fallback, dan perubahan tata letak sebelum presentasi didistribusikan. Lihat [Convert PowerPoint Presentations](/slides/id/nodejs-java/convert-powerpoint/) untuk contoh rendering dan ekspor.

## **FAQ**

**Apa yang dikembalikan `getScriptFont` ketika sebuah skrip tidak dipetakan?**

[Fonts.getScriptFont](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fonts/) mengembalikan `null` ketika pemetaan skrip yang diminta tidak didefinisikan dalam koleksi font utama atau sekunder.

**Apakah `setScriptFont` menambahkan pemetaan kedua ketika skrip sudah ada?**

Tidak. [Fonts.setScriptFont](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fonts/) membuat pemetaan ketika belum ada dan mengganti keluarga font yang dipetakan ketika tag skrip yang sama sudah ada.

**Mengapa mengubah pemetaan tema tidak mengubah beberapa teks?**

Teks mungkin memiliki font yang ditetapkan secara eksplisit, mewarisi tema berbeda melalui override, atau dipengaruhi oleh substitusi atau fallback saat render. Pemetaan skrip pada tingkat presentasi hanya mengontrol teks yang pemformatan efektifnya masih merujuk pada koleksi font tema tersebut.

**Apakah menyimpan dan membuka kembali cukup untuk memvalidasi output multibahasa?**

Tidak. Membuka kembali hanya memverifikasi persistensi data tema. Selain itu render teks perwakilan dari setiap sistem penulisan yang diperlukan untuk memastikan bahwa font yang dipetakan tersedia dan berisi glyph yang diperlukan.