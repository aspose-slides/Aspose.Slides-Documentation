---
title: "Konfigurasi Penggantian Font dalam Presentasi Menggunakan Java"
linktitle: "Penggantian Font"
type: docs
weight: 70
url: /id/java/font-substitution/
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
- Java
- Aspose.Slides
description: "Konfigurasikan aturan penggantian font dan periksa font yang diganti dalam Aspose.Slides untuk Java saat merender atau mengonversi presentasi PowerPoint dan OpenDocument."
---
## **Ikhtisar**

Penggantian font memungkinkan Aspose.Slides menggunakan font yang tersedia sebagai pengganti font yang tidak dapat diakses saat presentasi dirender atau dikonversi. Penggantian ini memengaruhi output yang dirender; tidak mengubah font yang ditetapkan pada konten presentasi.

Anda dapat menentukan font yang akan digunakan ketika font tertentu tidak tersedia, dan Anda dapat memeriksa penggantian yang akan dilakukan Aspose.Slides selama proses rendering. Ini membantu menjaga konsistensi output di lingkungan dengan font yang terpasang berbeda.

## **Dapatkan Penggantian Font**

Gunakan metode [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/id/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) untuk menentukan font mana yang akan diganti ketika presentasi dirender. Metode ini mengembalikan objek [FontSubstitutionInfo](https://reference.aspose.com/slides/id/java/com.aspose.slides/fontsubstitutioninfo/) yang mengidentifikasi nama font asli dan font penggantinya.

Contoh Java berikut mencantumkan semua penggantian font untuk sebuah presentasi:

```java
import com.aspose.slides.FontSubstitutionInfo;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions()) {
        System.out.println(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }
} finally {
    presentation.dispose();
}
```

## **Dapatkan Penggantian Font untuk Slide yang Dipilih**

Gunakan overload [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/id/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) dengan argumen `int[] slides` untuk memeriksa hanya penggantian yang diperlukan untuk merender slide tertentu. Ini berguna ketika Anda merender atau mengekspor bagian dari presentasi, memeriksa presentasi besar secara inkremental, menemukan slide yang bergantung pada font yang tidak tersedia, menyiapkan paket font minimal untuk server atau kontainer, atau mendiagnosa perbedaan rendering tanpa memproses slide yang tidak relevan.

Array `slides` berisi indeks slide berbasis satu: `1` menandakan slide pertama. Sebaliknya, akses koleksi [Presentation.getSlides](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#getSlides--) menggunakan indeks berbasis nol, sehingga slide yang sama diakses sebagai `presentation.getSlides().get_Item(0)`. Ingat perbedaan ini saat membangun array untuk menghindari kesalahan satu indeks.

Panggil overload tersebut melalui metode [Presentation.getFontsManager](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#getFontsManager--). Metode ini mengembalikan hanya penggantian yang ditentukan selama rendering slide yang dipilih. Setiap hasil adalah objek [FontSubstitutionInfo](https://reference.aspose.com/slides/id/java/com.aspose.slides/fontsubstitutioninfo/) yang berisi nama font asli dan penggantinya. Hasil mencerminkan lingkungan font saat ini, aturan fallback yang dikonfigurasi, aturan penggantian yang disimpan dalam [IFontSubstRuleCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/ifontsubstrulecollection/), dan [font yang dimuat secara eksternal](/slides/id/java/custom-font/).

Penggantian yang sama dapat diperlukan oleh lebih dari satu slide yang dipilih. Hapus duplikat hasil ketika Anda membuat inventaris font atau laporan pra‑flight. Contoh berikut melaporkan setiap penggantian yang dikembalikan kemudian membuat daftar terurut dari pemetaan font yang unik:

```java
import com.aspose.slides.FontSubstitutionInfo;
import com.aspose.slides.Presentation;
import java.util.ArrayList;
import java.util.List;
import java.util.Set;
import java.util.TreeSet;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    int[] selectedSlides = { 1, 3, 5 };
    List<FontSubstitutionInfo> substitutions = new ArrayList<>();
    for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions(selectedSlides)) {
        substitutions.add(substitution);
    }

    System.out.println("Substitutions for the selected slides:");
    for (FontSubstitutionInfo substitution : substitutions) {
        System.out.println(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }

    Set<String> sortedPreflightEntries = new TreeSet<>(String.CASE_INSENSITIVE_ORDER);
    for (FontSubstitutionInfo substitution : substitutions) {
        String entry = substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName();
        sortedPreflightEntries.add(entry);
    }

    System.out.println("Deduplicated font preflight report:");
    for (String entry : sortedPreflightEntries) {
        System.out.println(entry);
    }
} finally {
    presentation.dispose();
}
```

Antarmuka [IFontsManager](https://reference.aspose.com/slides/id/java/com.aspose.slides/ifontsmanager/) menyediakan kedua overload. Pilih salah satu sesuai cakupan operasi rendering:

| Overload | Digunakan ketika |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/id/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) tanpa argumen | Anda memerlukan penggantian untuk seluruh presentasi. |
| [getSubstitutions](https://reference.aspose.com/slides/id/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) dengan `int[] slides` | Anda memerlukan penggantian untuk rentang yang dipilih, pemeriksaan inkremental, atau ekspor parsial. |

## **Atur Aturan Penggantian Font**

Untuk menentukan font yang harus digunakan Aspose.Slides ketika font sumber tidak tersedia:

1. Muat presentasi.
2. Buat definisi font untuk font sumber dan font pengganti.
3. Buat sebuah [FontSubstRule](https://reference.aspose.com/slides/id/java/com.aspose.slides/fontsubstrule/) dengan kondisi [WhenInaccessible](https://reference.aspose.com/slides/id/java/com.aspose.slides/fontsubstcondition/).
4. Tambahkan aturan ke [FontSubstRuleCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/fontsubstrulecollection/).
5. Tetapkan koleksi tersebut dengan menggunakan metode [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/id/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-).
6. Render atau konversi presentasi.

Contoh Java berikut menggantikan `Arial` untuk `SomeRareFont` ketika `SomeRareFont` tidak tersedia, kemudian merender slide pertama untuk memverifikasi hasilnya. Font pengganti harus tersedia untuk Aspose.Slides.

```java
import com.aspose.slides.FontData;
import com.aspose.slides.FontSubstCondition;
import com.aspose.slides.FontSubstRule;
import com.aspose.slides.FontSubstRuleCollection;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontSubstRule;
import com.aspose.slides.IFontSubstRuleCollection;
import com.aspose.slides.IImage;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontData sourceFont = new FontData("SomeRareFont");
    IFontData substituteFont = new FontData("Arial");
    IFontSubstRule substitutionRule = new FontSubstRule(sourceFont, substituteFont, FontSubstCondition.WhenInaccessible);

    IFontSubstRuleCollection substitutionRules = new FontSubstRuleCollection();
    substitutionRules.add(substitutionRule);
    presentation.getFontsManager().setFontSubstRuleList(substitutionRules);

    IImage image = presentation.getSlides().get_Item(0).getImage(1f, 1f);
    try {
        image.save("slide.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

Untuk perubahan tanpa syarat pada semua font yang digunakan dalam sebuah presentasi, lihat [Font Replacement](/slides/id/java/font-replacement/).

{{% /alert %}}

## **Batasan untuk Font Persamaan Matematika**

Aturan penggantian font adalah bagian dari proses pemilihan font standar yang digunakan selama rendering dan konversi. Mereka berfungsi untuk teks biasa ketika Aspose.Slides dapat mengganti font yang tidak dapat diakses dengan font yang tersedia sesuai aturan.

Persamaan Office Math memiliki persyaratan tambahan. Jika sebuah persamaan menggunakan **Cambria Math**, Aspose.Slides mungkin memerlukan font tersebut secara tepat untuk menghitung dan merender tata letak persamaan. Aturan yang menggantikan font matematika lain, seperti **STIX Two Math**, tidak dapat menggantikan **Cambria Math** untuk tujuan ini, dan proses rendering masih dapat melaporkan bahwa **Cambria Math** diperlukan.

Untuk merender atau mengonversi presentasi semacam itu, sediakan **Cambria Math** bagi Aspose.Slides. Instal font tersebut di sistem operasi atau muat sebagai [font eksternal](/slides/id/java/custom-font/).

Batasan ini berlaku pada tata letak persamaan. Aturan penggantian yang dijelaskan di atas tetap berlaku untuk teks reguler dalam presentasi.

## **FAQ**

**Apa perbedaan antara penggantian font dan penggantian font (font substitution)?**

[Font replacement](/slides/id/java/font-replacement/) secara sengaja mengubah satu font menjadi font lain di seluruh presentasi. Font substitution memilih font untuk output yang dirender ketika kondisi yang dikonfigurasi terpenuhi, seperti ketika font asli tidak tersedia.

**Kapan aturan penggantian diterapkan?**

Aturan berpartisipasi dalam [urutan pemilihan font](/slides/id/java/font-selection-sequence/) selama rendering dan konversi. Dengan `WhenInaccessible`, sebuah aturan hanya digunakan ketika Aspose.Slides tidak dapat mengakses font sumber.

**Apa yang terjadi ketika sebuah font hilang dan tidak ada aturan penggantian yang dikonfigurasi?**

Aspose.Slides memilih font yang paling mirip yang tersedia menurut proses pemilihan fontnya. Hasilnya bergantung pada font yang tersedia di lingkungan runtime.

**Bisakah saya memuat font eksternal untuk menghindari penggantian?**

Ya. Anda dapat [memuat font eksternal](/slides/id/java/custom-font/) sehingga Aspose.Slides dapat menggunakannya selama rendering dan konversi.

**Apakah Aspose mendistribusikan font bersama pustaka?**

Tidak. Anda bertanggung jawab menyediakan font dan mematuhi lisensinya.

**Apakah hasil penggantian dapat berbeda antara Windows, Linux, dan macOS?**

Ya. Font yang terpasang dan lokasi pencarian font berbeda pada tiap sistem operasi, sehingga sebuah font yang tersedia di satu mesin mungkin memerlukan penggantian di mesin lain.

**Bagaimana saya dapat membuat pemilihan font konsisten dalam konversi batch?**

Gunakan file dan versi font yang sama pada setiap mesin atau kontainer, [muat font eksternal yang diperlukan](/slides/id/java/custom-font/), dan [sematkan font](/slides/id/java/embedded-font/) bila lisensi mengizinkan. Anda juga dapat memanggil [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/id/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) sebelum ekspor untuk mengidentifikasi penggantian yang tidak diharapkan.