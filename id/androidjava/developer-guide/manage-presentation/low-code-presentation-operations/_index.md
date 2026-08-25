---
title: Operasi Presentasi Low-Code pada Android
linktitle: API Low-Code
type: docs
weight: 50
url: /id/androidjava/low-code-presentation-operations/
keywords:
- API presentasi low-code
- konversi presentasi
- gabungkan presentasi
- iterasi slide
- iterasi bentuk
- iterasi teks
- kumpulkan bentuk
- kompresi presentasi
- hapus slide master yang tidak terpakai
- hapus slide tata letak yang tidak terpakai
- kompres font yang disematkan
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Gunakan API low-code Aspose.Slides pada Android untuk mengkonversi dan menggabungkan presentasi, mengiterasi konten, mengumpulkan bentuk, dan mengurangi ukuran presentasi."
---
## **Gambaran Umum**

Paket [com.aspose.slides](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/) menyediakan kelas pembantu statis untuk operasi presentasi umum. Pembantu ini membungkus alur kerja model objek yang sering digunakan dalam metode terfokus, sehingga Anda dapat mengkonversi atau menggabungkan file, memproses elemen presentasi, mengumpulkan bentuk, dan menghapus konten yang tidak terpakai dengan lebih sedikit kode.

Pembantu low-code paling berguna ketika operasi diterapkan pada seluruh file atau presentasi dan alur kerja default cocok dengan kebutuhan Anda. Gunakan [model objek Aspose.Slides](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/) lengkap ketika Anda memerlukan kontrol detail atas slide individual, master, tata letak, bentuk, pengaturan ekspor, atau hubungan antar elemen presentasi.

Tabel berikut merangkum pembantu yang tersedia:

| Helper | Gunakan untuk |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/convert/) | Mengonversi sebuah presentasi ke format lain dengan pemanggilan langsung file-ke-file. |
| [Merger](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/merger/) | Menggabungkan file presentasi lengkap dengan format yang sama. |
| [ForEach](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/foreach/) | Menjalankan aksi untuk setiap slide, bentuk, paragraf, atau bagian teks. |
| [Collect](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/collect/) | Mengambil bentuk dari seluruh presentasi untuk pemrosesan atau analisis berulang. |
| [Compress](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/compress/) | Menghapus master dan tata letak yang tidak terpakai serta mengurangi data font yang disematkan. |

## **Mengonversi Presentasi**

Gunakan [Convert.autoByExtension](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) ketika ekstensi file output cukup untuk memilih format ekspor. Metode ini membuka presentasi sumber, menentukan format yang diperlukan dari jalur output, dan menulis hasilnya.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

Kelas [Convert](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/convert/) juga menyediakan metode khusus untuk output PDF, SVG, JPEG, PNG, dan TIFF. Gunakan model objek lengkap ketika Anda perlu memeriksa atau memodifikasi presentasi sebelum ekspor atau mengonfigurasi opsi ekspor yang tidak tersedia pada pembantu yang dipilih. Lihat [Convert Presentation](/slides/id/androidjava/convert-presentation/) untuk alur kerja dan opsi khusus format.

## **Menggabungkan Presentasi**

Gunakan [Merger.process](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) untuk menggabungkan file presentasi lengkap dengan satu pemanggilan. Presentasi masukan harus memiliki format file yang sama.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

Pembantu ini cocok ketika semua slide harus ditambahkan ke satu hasil tanpa memilih atau memetakan ulang secara individual. Gunakan model objek lengkap ketika Anda perlu menggabungkan slide terpilih, menerapkan master atau tata letak tujuan, mempertahankan bagian secara eksplisit, atau menyelaraskan ukuran slide yang berbeda. Lihat [Merge Presentations](/slides/id/androidjava/merge-presentation/) untuk skenario tersebut.

## **Iterasi Elemen Presentasi**

Kelas [ForEach](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/foreach/) memanggil callback untuk setiap tipe elemen presentasi yang diminta. Ini menghindari loop koleksi bersarang dan memudahkan inspeksi atau perubahan format pada seluruh presentasi.

Contoh berikut menggunakan [ForEach.slide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), dan [ForEach.portion](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) untuk memeriksa elemen yang bersesuaian:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ForEach.slide(presentation, (slide, index) -> {
        System.out.println(String.format("Slide %d: %d shapes", index, slide.getShapes().size()));
    });

    ForEach.shape(presentation, (shape, slide, index) -> {
        System.out.println(String.format("Shape %d on %s: %s", index, slide.getClass().getSimpleName(), shape.getName()));
    });

    ForEach.paragraph(presentation, (paragraph, slide, index) -> {
        System.out.println(String.format("Paragraph %d on %s: %s", index, slide.getClass().getSimpleName(), paragraph.getText()));
    });

    ForEach.portion(presentation, (portion, paragraph, slide, index) -> {
        System.out.println(String.format("Portion %d on %s: %s", index, slide.getClass().getSimpleName(), portion.getText()));
    });
} finally {
    presentation.dispose();
}
```

Secara default, penelusuran bentuk dan teks pada seluruh presentasi mencakup slide normal, master, dan tata letak. Overload dengan parameter `includeNotes` juga dapat memproses slide catatan. Gunakan loop koleksi langsung ketika urutan penelusuran, keluar lebih awal, penyaringan sebelum pemanggilan callback, atau kontrol detail orang tua‑anak penting.

## **Mengumpulkan Bentuk**

Gunakan [Collect.shapes](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) ketika Anda membutuhkan koleksi semua bentuk dalam sebuah presentasi daripada callback untuk setiap bentuk. Ini berguna ketika set yang sama akan difilter, dihitung, atau diproses lebih dari sekali.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Iterable<Shape> shapes = Collect.shapes(presentation);

    for (Shape shape : shapes) {
        System.out.println(String.format("%s: %s", shape.getName(), shape.getClass().getSimpleName()));
    }
} finally {
    presentation.dispose();
}
```

Gunakan [ForEach.shape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) sebagai gantinya ketika setiap bentuk dapat ditangani secara langsung dan Anda tidak memerlukan hasil yang dikumpulkan tetap.

## **Mengompres Konten Presentasi**

Kelas [Compress](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/compress/) dapat menghapus elemen struktural yang tidak terpakai dan mengurangi data font yang disematkan:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) menghapus slide tata letak yang tidak direferensikan oleh slide normal.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) menghapus slide master yang tidak lagi digunakan.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) menghapus karakter yang tidak terpakai dari font yang disematkan.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    Compress.removeUnusedMasterSlides(presentation);
    Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hapus tata letak yang tidak terpakai sebelum master yang tidak terpakai sehingga master yang menjadi tidak direferensikan setelah pembersihan tata letak juga dapat dihapus. Simpan presentasi yang dioptimalkan ke file baru jika Anda mungkin memerlukan master, tata letak, atau data font yang disematkan lengkap di kemudian hari. Untuk detail lebih lanjut, lihat [Slide Master](/slides/id/androidjava/slide-master/) dan [Embedded Font](/slides/id/androidjava/embedded-font/).

## **FAQ**

**Kapan saya harus menggunakan API low-code alih-alih model objek lengkap?**

Gunakan pembantu low-code ketika operasi standar diterapkan pada file atau presentasi lengkap dan tidak memerlukan kontrol detail atas elemen individual. Gunakan model objek lengkap ketika Anda perlu memilih slide tertentu, mengontrol hubungan master dan tata letak, memeriksa keadaan antara, atau mengonfigurasi perilaku yang tidak disediakan oleh pembantu.

**Apakah Merger dapat menggabungkan presentasi dalam format file yang berbeda?**

Tidak. [Merger.process](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) memerlukan presentasi masukan dalam format yang sama. Konversi file masukan ke format umum terlebih dahulu, misalnya dengan [Convert.autoByExtension](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), lalu gabungkan file yang telah dikonversi.

**Apakah ForEach memproses slide master, tata letak, dan catatan?**

[ForEach.slide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) mengiterasi slide presentasi normal. Operasi [ForEach.shape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), dan [ForEach.portion](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) pada seluruh presentasi mencakup slide normal, master, dan tata letak secara default. Gunakan overload mereka dengan `includeNotes` diatur ke `true` untuk menyertakan slide catatan.

**Apa perbedaan antara ForEach.shape dan Collect.shapes?**

Gunakan [ForEach.shape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) untuk memproses setiap bentuk secara langsung melalui callback. Gunakan [Collect.shapes](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) ketika Anda membutuhkan hasil yang dapat diiterasi yang dapat dipertahankan, difilter, dihitung, atau dilalui beberapa kali.

**Apakah Compress selalu memperkecil ukuran file presentasi?**

Tidak selalu. Hasilnya tergantung pada apakah presentasi berisi tata letak yang tidak terpakai, master yang tidak terpakai, atau font yang disematkan dengan karakter yang tidak terpakai. Jika tidak ada yang tersebut, operasi [Compress](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/compress/) yang bersangkutan mungkin tidak mengurangi ukuran file.

**Apakah perubahan yang dibuat oleh ForEach atau Compress disimpan secara otomatis?**

Tidak. Pembantu ini beroperasi pada objek [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) yang dimuat di memori. Setelah mengubah elemen dalam callback [ForEach](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/foreach/) atau menjalankan [Compress](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/compress/), panggil [Presentation.save](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) untuk menulis hasilnya.

## **Artikel Terkait**

- [Mengonversi Presentasi](/slides/id/androidjava/convert-presentation/)
- [Menggabungkan Presentasi](/slides/id/androidjava/merge-presentation/)
- [Slide Master](/slides/id/androidjava/slide-master/)
- [Mengelola Kotak Teks](/slides/id/androidjava/manage-textbox/)
- [Font Tertanam](/slides/id/androidjava/embedded-font/)