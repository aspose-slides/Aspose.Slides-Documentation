---
title: Konfigurasi Penggantian Font dalam Presentasi di Android
linktitle: Penggantian Font
type: docs
weight: 70
url: /id/androidjava/font-substitution/
keywords:
- font
- font pengganti
- substitusi font
- mengganti font
- penggantian font
- aturan substitusi
- aturan penggantian
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Konfigurasikan aturan penggantian font dan inspeksi font yang diganti di Aspose.Slides untuk Android melalui Java saat merender atau mengonversi presentasi."
---
## **Gambaran Umum**

Penggantian font memungkinkan Aspose.Slides menggunakan font yang tersedia sebagai pengganti font yang tidak dapat diakses ketika presentasi dirender atau dikonversi. Penggantian memengaruhi output yang dirender; tidak mengubah font yang ditetapkan pada konten presentasi.

Anda dapat menentukan font yang akan digunakan ketika font tertentu tidak tersedia, dan Anda dapat memeriksa penggantian yang akan dilakukan Aspose.Slides selama proses rendering. Ini membantu menjaga konsistensi output di seluruh perangkat Android dan lingkungan dengan font yang tersedia berbeda.

Jika sebuah font tersedia tetapi tidak memiliki jenis huruf tebal khusus, lihat [Menangani Font Tanpa Typeface Tebal Khusus](/slides/id/androidjava/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Bagian itu menjelaskan cara merasterkan teks yang terpengaruh selama ekspor PDF dan konsekuensinya untuk pemilihan teks, pencarian, dan skala.

## **Dapatkan Penggantian Font**

Gunakan metode [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) untuk menentukan font mana yang akan diganti ketika presentasi dirender. Metode ini mengembalikan objek [FontSubstitutionInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstitutioninfo/) yang mengidentifikasi nama font asli dan font pengganti.

Contoh Java berikut menampilkan semua penggantian font untuk sebuah presentasi:

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

Gunakan overload [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) dengan argumen `int[] slides` untuk memeriksa hanya penggantian yang diperlukan untuk merender slide tertentu. Ini berguna saat Anda merender atau mengekspor bagian dari presentasi, memeriksa presentasi besar secara bertahap, menemukan slide yang bergantung pada font yang tidak tersedia, menyiapkan paket font minimal untuk aplikasi Android, atau mendiagnosis perbedaan rendering tanpa memproses slide yang tidak terkait.

Array `slides` berisi indeks slide berbasis satu: `1` mengidentifikasi slide pertama. Sebaliknya, accessor koleksi [Presentation.getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) menggunakan indeks berbasis nol, sehingga slide yang sama diakses sebagai `presentation.getSlides().get_Item(0)`. Ingat perbedaan ini saat membangun array untuk menghindari kesalahan satu offset.

Panggil overload tersebut melalui metode [Presentation.getFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getFontsManager--). Metode ini hanya mengembalikan penggantian yang ditentukan selama merender slide yang dipilih. Setiap hasil adalah objek [FontSubstitutionInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstitutioninfo/) yang berisi nama font asli dan font pengganti. Hasil mencerminkan lingkungan font saat ini, aturan fallback yang dikonfigurasi, aturan penggantian yang disimpan dalam sebuah [IFontSubstRuleCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsubstrulecollection/), dan [font yang dimuat secara eksternal](/slides/id/androidjava/custom-font/).

Penggantian yang sama dapat diperlukan oleh lebih dari satu slide yang dipilih. Hilangkan duplikasi hasil ketika Anda membuat inventaris font atau laporan pra-penerbangan. Contoh berikut melaporkan setiap penggantian yang dikembalikan dan kemudian membuat daftar terurut dari pemetaan font unik:

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

Antarmuka [IFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/) menyediakan kedua overload. Pilih salah satu sesuai dengan ruang lingkup operasi rendering:

| Overload | Gunakan ketika |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) dengan tanpa argumen | Anda memerlukan penggantian untuk seluruh presentasi. |
| [getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) dengan `int[] slides` | Anda memerlukan penggantian untuk rentang yang dipilih, pemeriksaan bertahap, atau ekspor parsial. |

## **Atur Aturan Penggantian Font**

Untuk menentukan font yang harus digunakan Aspose.Slides ketika font sumber tidak tersedia:

1. Muat presentasi.
2. Buat definisi font untuk font sumber dan pengganti.
3. Buat sebuah [FontSubstRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrule/) dengan kondisi [WhenInaccessible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstcondition/).
4. Tambahkan aturan ke [FontSubstRuleCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrulecollection/).
5. Tetapkan koleksi dengan menggunakan metode [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-) .
6. Render atau konversi presentasi.

Contoh Java berikut menggantikan `Arial` untuk `SomeRareFont` ketika `SomeRareFont` tidak tersedia, dan kemudian merender slide pertama untuk memverifikasi hasilnya. Font pengganti harus tersedia untuk Aspose.Slides.

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
Untuk perubahan tanpa syarat pada font yang digunakan di seluruh presentasi, lihat [Penggantian Font](/slides/id/androidjava/font-replacement/).
{{% /alert %}}

## **Batasan untuk Font Persamaan Matematika**

Aturan penggantian font merupakan bagian dari proses pemilihan font standar yang digunakan selama rendering dan konversi. Aturan ini bekerja untuk teks biasa ketika Aspose.Slides dapat mengganti font yang tidak dapat diakses dengan font yang tersedia yang ditentukan oleh aturan.

Persamaan Office Math memiliki persyaratan tambahan. Jika sebuah persamaan menggunakan **Cambria Math**, Aspose.Slides mungkin memerlukan font tepat tersebut untuk menghitung dan merender tata letak persamaan. Aturan yang menggantikan dengan font matematika lain, seperti **STIX Two Math**, tidak dapat menggantikan **Cambria Math** untuk tujuan ini, dan proses rendering mungkin masih melaporkan bahwa **Cambria Math** diperlukan.

Untuk merender atau mengonversi presentasi semacam itu, pastikan **Cambria Math** tersedia untuk Aspose.Slides. Muat sebagai [font eksternal](/slides/id/androidjava/custom-font/) agar aplikasi dapat menggunakannya selama rendering dan konversi.

Batasan ini berlaku untuk tata letak persamaan. Aturan penggantian yang dijelaskan di atas tetap berlaku untuk teks presentasi biasa.

## **Tanya Jawab**

**Apa perbedaan antara penggantian font dan substitusi font?**

[Penggantian Font](/slides/id/androidjava/font-replacement/) secara sengaja mengubah satu font menjadi font lain di seluruh presentasi. Substitusi font memilih font untuk output yang dirender ketika kondisi yang dikonfigurasi terpenuhi, seperti saat font asli tidak tersedia.

**Kapan aturan substitusi diterapkan?**

Aturan berpartisipasi dalam [urutan pemilihan font](/slides/id/androidjava/font-selection-sequence/) selama rendering dan konversi. Dengan `WhenInaccessible`, aturan hanya digunakan ketika Aspose.Slides tidak dapat mengakses font sumber.

**Apa yang terjadi ketika sebuah font hilang dan tidak ada aturan substitusi yang dikonfigurasi?**

Aspose.Slides memilih font yang paling dekat tersedia menurut proses pemilihan fontnya. Hasilnya bergantung pada font yang tersedia dalam lingkungan runtime.

**Apakah saya dapat memuat font eksternal untuk menghindari substitusi?**

Ya. Anda dapat [memuat font eksternal](/slides/id/androidjava/custom-font/) sehingga Aspose.Slides dapat menggunakannya selama rendering dan konversi.

**Apakah Aspose mendistribusikan font bersama library?**

Tidak. Anda bertanggung jawab menyediakan font dan mematuhi lisensinya.

**Apakah hasil substitusi dapat berbeda antar perangkat Android?**

Ya. Font sistem yang tersedia dapat berbeda antara versi Android, perangkat, dan vendor, sehingga font yang tersedia di satu lingkungan mungkin memerlukan substitusi di lingkungan lain.

**Bagaimana saya dapat membuat pemilihan font konsisten di seluruh perangkat Android?**

Kemas file font yang diperlukan yang sama bersama aplikasi, [muat sebagai font eksternal](/slides/id/androidjava/custom-font/), dan [sematkan font](/slides/id/androidjava/embedded-font/) bila lisensi mengizinkan. Anda juga dapat memanggil [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) sebelum mengekspor untuk mengidentifikasi substitusi yang tidak terduga.