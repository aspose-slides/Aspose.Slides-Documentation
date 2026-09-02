---
title: Kelola Font Tema Khusus Skrip di Android
linktitle: Font Tema Khusus Skrip
type: docs
weight: 15
url: /id/androidjava/script-specific-font-mappings/
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
- Android
- Java
- Aspose.Slides
description: "Periksa, tambahkan, ganti, dan hapus pemetaan font khusus skrip dalam tema PowerPoint dengan Aspose.Slides untuk Android via Java."
---
## **Gambaran Umum**

Tema presentasi dapat memilih keluarga font yang berbeda untuk sistem penulisan yang berbeda. Hal ini memungkinkan teks multibahasa yang tetap menggunakan font tema mengikuti satu skema font terkoordinasi sambil menggunakan font yang sesuai untuk Cyrillic, Arab, Jepang, Georgia, Thaana, dan skrip lainnya.

Tema tersebut memiliki [IFontScheme](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ifontscheme/) yang berisi koleksi font utama, biasanya digunakan untuk judul, dan koleksi font minor, biasanya digunakan untuk teks tubuh. Selain pengaturan font Latin dan Asia Timur mereka, kedua koleksi tersebut menampilkan pemetaan dari tag sistem penulisan ke nama keluarga font melalui antarmuka [IFonts](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ifonts/).

Artikel ini menunjukkan cara memeriksa dan mengubah pemetaan tersebut dalam tema master presentasi serta memverifikasi bahwa perubahan tersebut bertahan melalui siklus simpan-dan-muat ulang.

## **Memahami Tag Skrip**

Metode font skrip menggunakan subtags skrip BCP 47 berukuran empat huruf untuk mengidentifikasi sistem penulisan. Nilai umum meliputi:

| Script tag | Sistem penulisan |
|---|---|
| `Cyrl` | Cyrillic |
| `Arab` | Arabic |
| `Hans` | Cina Sederhana |
| `Jpan` | Jepang |
| `Geor` | Georgian |
| `Thaa` | Thaana |

Pemetaan ini milik skema font tema, bukan bagian teks individu. Sebuah presentasi dapat mendefinisikan pemetaan berbeda untuk koleksi mayor dan minor, dan dapat mengabaikan pemetaan untuk beberapa skrip.

## **Akses dan Periksa Pemetaan Font Skrip**

Gunakan [Presentation.getMasterTheme](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#getMasterTheme--) untuk mengakses tema tingkat presentasi. Metode [IFontScheme.getMajor](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ifontscheme/#getMajor--) dan [IFontScheme.getMinor](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ifontscheme/#getMinor--) mengembalikan dua koleksi [IFonts](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ifonts/).

Panggil [IFonts.getScriptFontMap](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/fonts/#getScriptFontMap--) untuk mengambil semua pemetaan dari sebuah koleksi. Untuk mencari satu sistem penulisan, panggil [IFonts.getScriptFont](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) dengan tag skripnya. `getScriptFont` mengembalikan `null` ketika koleksi tersebut tidak mendefinisikan pemetaan yang diminta.

## **Ubah Pemetaan dan Verifikasi Persistensi**

Gunakan [IFonts.setScriptFont](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) untuk membuat pemetaan atau mengganti keluarga fontnya saat ini. Gunakan [IFonts.removeScriptFont](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/fonts/#removeScriptFont-java.lang.String-) untuk menghapus sebuah pemetaan.

Contoh ujung ke ujung berikut membaca semua pemetaan mayor dan minor yang ada, mencari font mayor Jepang, mengubah font mayor Cyrillic, menghapus pemetaan minor Thaana, menyimpan presentasi, dan membukanya kembali untuk memverifikasi kedua perubahan. Untuk membuat langkah penghapusan independen dari tema awal, contoh pertama kali membuat pemetaan Thaana hanya bila belum ada yang didefinisikan.

```java
import com.aspose.slides.*;
import com.aspose.slides.Collections.Generic.Dictionary;
import com.aspose.slides.Collections.Generic.KeyValuePair;

Presentation presentation = new Presentation();
try {
    IFontScheme fontScheme = presentation.getMasterTheme().getFontScheme();
    IFonts majorFonts = fontScheme.getMajor();
    IFonts minorFonts = fontScheme.getMinor();

    System.out.println("Existing major mappings:");
    Dictionary.Enumerator<String, String> majorMappings = majorFonts.getScriptFontMap().iterator();
    while (majorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = majorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    System.out.println("Existing minor mappings:");
    Dictionary.Enumerator<String, String> minorMappings = minorFonts.getScriptFontMap().iterator();
    while (minorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = minorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    String japaneseFont = majorFonts.getScriptFont("Jpan");
    if (japaneseFont == null) {
        System.out.println("No major Japanese font is defined.");
    } else {
        System.out.println("Major Japanese font: " + japaneseFont);
    }

    majorFonts.setScriptFont("Cyrl", "Arial");

    if (minorFonts.getScriptFont("Thaa") == null) {
        minorFonts.setScriptFont("Thaa", "Arial");
    }

    minorFonts.removeScriptFont("Thaa");
    presentation.save("script-font-mappings.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("script-font-mappings.pptx");
try {
    IFonts savedMajorFonts = savedPresentation.getMasterTheme().getFontScheme().getMajor();
    IFonts savedMinorFonts = savedPresentation.getMasterTheme().getFontScheme().getMinor();
    String savedCyrillicFont = savedMajorFonts.getScriptFont("Cyrl");
    String savedThaanaFont = savedMinorFonts.getScriptFont("Thaa");

    if ("Arial".equals(savedCyrillicFont)) {
        System.out.println("The Cyrillic mapping was preserved.");
    } else {
        System.out.println("The Cyrillic mapping was not preserved.");
    }

    if (savedThaanaFont == null) {
        System.out.println("The Thaana mapping removal was preserved.");
    } else {
        System.out.println("The Thaana mapping still exists.");
    }
} finally {
    savedPresentation.dispose();
}
```

Verifikasi menggunakan perilaku `null` yang sama seperti pencarian biasa: setelah penghapusan disimpan, `getScriptFont("Thaa")` mengembalikan `null` untuk koleksi minor.

## **Membedakan Pemetaan Tema dari Pengaturan Font Lain**

Pemetaan tema khusus skrip berpartisipasi dalam pemilihan font, tetapi mereka menyelesaikan masalah yang berbeda dari pemformatan teks langsung, substitusi, dan fallback:

| Mekanisme | Tujuan | Efek mengubah pemetaan tema |
|---|---|---|
| Pemetaan font tema khusus skrip | Memilih font tema mayor atau minor untuk suatu sistem penulisan. | Teks yang masih menggunakan font tema yang bersangkutan dapat beralih ke keluarga font yang baru dipetakan. |
| Font yang ditetapkan secara eksplisit pada bagian teks | Menetapkan keluarga font yang diminta pada bagian tersebut alih-alih bergantung pada tema. | Bagian tersebut mungkin tetap tidak berubah karena pemformatan langsungnya menggantikan pilihan tema. |
| Substitusi font | Mengganti font yang diminta ketika font tersebut tidak tersedia atau ketika aturan substitusi berlaku. | Ia beraksi setelah font diminta; tidak mendefinisikan ulang pemetaan skrip tema. |
| Fallback font | Menyediakan glif yang tidak dimiliki font yang dipilih, sering untuk rentang Unicode tertentu. | Ia melengkapi cakupan glif yang hilang; tidak mengubah pemetaan tema yang tersimpan. |

Untuk informasi lebih lanjut tentang dua mekanisme terakhir, lihat [Font Substitution](/slides/id/androidjava/font-substitution/) dan [Fallback Fonts](/slides/id/androidjava/fallback-font/).

Mengubah pemetaan di [Presentation.getMasterTheme](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#getMasterTheme--) memengaruhi hanya konten yang pemformatannya masih bergantung pada tema tersebut. Teks dapat mewarisi override tema dari master, tata letak, atau slide, atau menggunakan font yang ditetapkan secara eksplisit. Periksa tingkat-tingkat tersebut bila hasil yang terlihat tidak mengikuti pemetaan tingkat presentasi.

## **Membuat Font yang Dipetakan Tersedia dan Validasi Hasil**

Pemetaan skrip menyimpan nama keluarga font; ia tidak menginstal atau memuat berkas font yang bersangkutan. Untuk rendering dan ekspor yang konsisten, setiap font yang dipetakan harus diinstal di lingkungan atau disediakan ke Aspose.Slides melalui sumber khusus seperti [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) atau [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/loadoptions/#getDocumentLevelFontSources--). Lihat [Custom Fonts](/slides/id/androidjava/custom-font/) untuk opsi pemuatan yang tersedia.

Memverifikasi pemetaan yang disimpan hanya memastikan definisi tema tetap terjaga. Itu tidak membuktikan bahwa font tersedia, berisi semua glif yang diperlukan, atau menghasilkan tata letak yang dimaksud. Render teks representatif untuk setiap sistem penulisan yang dibutuhkan ke gambar atau PDF dan periksa outputnya. Ini menangkap font yang hilang, cakupan glif yang tidak lengkap, perilaku fallback, dan perubahan tata letak sebelum presentasi didistribusikan. Lihat [Convert PowerPoint Presentations](/slides/id/androidjava/convert-powerpoint/) untuk contoh rendering dan ekspor.

## **FAQ**

**Apa yang dikembalikan `getScriptFont` ketika sebuah skrip tidak dipetakan?**

[IFonts.getScriptFont](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) mengembalikan `null` ketika pemetaan skrip yang diminta tidak didefinisikan dalam koleksi font mayor atau minor tersebut.

**Apakah `setScriptFont` menambah pemetaan kedua ketika skrip sudah ada?**

Tidak. [IFonts.setScriptFont](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) membuat pemetaan ketika belum ada dan mengganti keluarga font yang dipetakan ketika tag skrip yang sama sudah ada.

**Mengapa mengubah pemetaan tema tidak mengubah beberapa teks?**

Teks tersebut mungkin memiliki font yang ditetapkan secara eksplisit, mewarisi tema berbeda melalui override, atau dipengaruhi oleh substitusi atau fallback saat rendering. Pemetaan skrip tingkat presentasi hanya mengontrol teks yang pemformatannya masih mengacu pada koleksi font tema tersebut.

**Apakah menyimpan dan membuka kembali cukup untuk memvalidasi output multibahasa?**

Tidak. Membuka kembali hanya memverifikasi keberlanjutan data tema. Selain itu, render teks representatif dari setiap sistem penulisan yang dibutuhkan untuk memastikan font yang dipetakan tersedia dan berisi glif yang diperlukan.