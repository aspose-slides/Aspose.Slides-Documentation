---
title: Operasi Presentasi Low-Code dalam Java
linktitle: API Low-Code
type: docs
weight: 50
url: /id/java/low-code-presentation-operations/
keywords:
- API presentasi low-code
- konversi presentasi
- gabungkan presentasi
- iterasi slide
- iterasi shape
- iterasi teks
- kumpulkan shape
- kompres presentasi
- hapus slide master yang tidak terpakai
- hapus slide tata letak yang tidak terpakai
- kompres font tertanam
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Gunakan API low-code Aspose.Slides di Java untuk mengonversi dan menggabungkan presentasi, mengiterasi konten, mengumpulkan shape, dan mengurangi ukuran presentasi."
---
## **Ringkasan**

Paket [com.aspose.slides](https://reference.aspose.com/slides/id/java/com.aspose.slides/) menyediakan kelas pembantu statis untuk operasi presentasi umum. Pembantu ini membungkus alur kerja model objek yang sering digunakan dalam metode terfokus, sehingga Anda dapat mengonversi atau menggabungkan file, memproses elemen presentasi, mengumpulkan shape, dan menghapus konten yang tidak terpakai dengan lebih sedikit kode.

Pembantu low-code paling berguna ketika operasi berlaku pada seluruh file atau presentasi dan alur kerja default sesuai dengan kebutuhan Anda. Gunakan [model objek Aspose.Slides](https://reference.aspose.com/slides/id/java/com.aspose.slides/) secara lengkap ketika Anda memerlukan kontrol detail atas slide individual, master, tata letak, shape, pengaturan ekspor, atau hubungan antar elemen presentasi.

Tabel berikut merangkum pembantu yang tersedia:

| Pembantu | Gunakan untuk |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/id/java/com.aspose.slides/convert/) | Mengonversi presentasi ke format lain dengan panggilan langsung file-ke-file. |
| [Merger](https://reference.aspose.com/slides/id/java/com.aspose.slides/merger/) | Menggabungkan file presentasi lengkap dengan format yang sama. |
| [ForEach](https://reference.aspose.com/slides/id/java/com.aspose.slides/foreach/) | Menjalankan aksi untuk setiap slide, shape, paragraf, atau bagian teks. |
| [Collect](https://reference.aspose.com/slides/id/java/com.aspose.slides/collect/) | Mengambil shape dari seluruh presentasi untuk proses berulang atau analisis. |
| [Compress](https://reference.aspose.com/slides/id/java/com.aspose.slides/compress/) | Menghapus master dan tata letak yang tidak terpakai serta mengurangi data font yang tertanam. |

## **Mengonversi Presentasi**

Gunakan [Convert.autoByExtension](https://reference.aspose.com/slides/id/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) ketika ekstensi file output sudah cukup untuk memilih format ekspor. Metode ini membuka presentasi sumber, menentukan format yang diperlukan dari jalur output, dan menulis hasilnya.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

Kelas [Convert](https://reference.aspose.com/slides/id/java/com.aspose.slides/convert/) juga menyediakan metode khusus untuk output PDF, SVG, JPEG, PNG, dan TIFF. Gunakan model objek lengkap ketika Anda perlu memeriksa atau memodifikasi presentasi sebelum ekspor atau mengkonfigurasi opsi ekspor yang tidak disediakan oleh pembantu yang dipilih. Lihat [Convert Presentation](/slides/id/java/convert-presentation/) untuk alur kerja dan opsi spesifik format.

## **Menggabungkan Presentasi**

Gunakan [Merger.process](https://reference.aspose.com/slides/id/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) untuk menggabungkan file presentasi lengkap dengan satu panggilan. Presentasi masukan harus memiliki format file yang sama.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

Pembantu ini cocok ketika semua slide harus ditambahkan ke satu hasil tanpa memilih atau memetakan ulang slide secara individual. Gunakan model objek lengkap ketika Anda perlu menggabungkan slide yang dipilih, menerapkan master atau tata letak tujuan, mempertahankan bagian secara eksplisit, atau menyelaraskan ukuran slide yang berbeda. Lihat [Merge Presentations](/slides/id/java/merge-presentation/) untuk skenario tersebut.

## **Iterasi Elemen Presentasi**

Kelas [ForEach](https://reference.aspose.com/slides/id/java/com.aspose.slides/foreach/) memanggil callback untuk setiap tipe elemen presentasi yang diminta. Ini menghindari loop koleksi bersarang dan nyaman untuk inspeksi atau perubahan format di seluruh presentasi.

Contoh berikut menggunakan [ForEach.slide](https://reference.aspose.com/slides/id/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/id/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/id/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), dan [ForEach.portion](https://reference.aspose.com/slides/id/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) untuk memeriksa elemen yang bersangkutan:

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

Secara default, penelusuran shape dan teks di seluruh presentasi mencakup slide normal, master, dan tata letak. Overload dengan parameter `includeNotes` juga dapat memproses slide catatan. Gunakan loop koleksi langsung ketika urutan penelusuran, keluar lebih awal, filter sebelum pemanggilan callback, atau kontrol induk‑anak yang detail penting.

## **Kumpulkan Shape**

Gunakan [Collect.shapes](https://reference.aspose.com/slides/id/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) ketika Anda memerlukan koleksi semua shape dalam sebuah presentasi bukan callback untuk setiap shape. Ini berguna ketika kumpulan yang sama akan difilter, dihitung, atau diproses lebih dari sekali.

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

Gunakan [ForEach.shape](https://reference.aspose.com/slides/id/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) sebagai gantinya ketika setiap shape dapat diproses segera dan Anda tidak perlu menyimpan hasil yang dikumpulkan.

## **Kompres Konten Presentasi**

Kelas [Compress](https://reference.aspose.com/slides/id/java/com.aspose.slides/compress/) dapat menghapus elemen struktural yang tidak terpakai dan mengurangi data font yang tertanam:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/id/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) menghapus slide tata letak yang tidak direferensikan oleh slide normal.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/id/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) menghapus slide master yang tidak lagi digunakan.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/id/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) menghapus karakter yang tidak terpakai dari font yang tertanam.

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

Hapus tata letak yang tidak terpakai sebelum master yang tidak terpakai sehingga master yang menjadi tidak direferensikan setelah pembersihan tata letak juga dapat dihapus. Simpan presentasi yang dioptimalkan ke file baru jika Anda mungkin memerlukan master, tata letak, atau data font tertanam lengkap yang asli nanti. Untuk detail lebih lanjut, lihat [Slide Master](/slides/id/java/slide-master/) dan [Embedded Font](/slides/id/java/embedded-font/).

## **FAQ**

**Kapan saya harus menggunakan API low-code dibandingkan model objek lengkap?**

Gunakan pembantu low-code ketika operasi standar berlaku pada file atau presentasi lengkap dan tidak memerlukan kontrol detail atas elemen individual. Gunakan model objek lengkap ketika Anda perlu memilih slide tertentu, mengontrol hubungan master dan tata letak, memeriksa keadaan menengah, atau mengkonfigurasi perilaku yang tidak disediakan oleh pembantu.

**Apakah Merger dapat menggabungkan presentasi dengan format file yang berbeda?**

Tidak. [Merger.process](https://reference.aspose.com/slides/id/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) memerlukan presentasi masukan dalam format yang sama. Konversi file masukan ke format umum terlebih dahulu, misalnya dengan [Convert.autoByExtension](https://reference.aspose.com/slides/id/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), lalu gabungkan file yang sudah dikonversi.

**Apakah ForEach memproses slide master, layout, dan catatan?**

[ForEach.slide](https://reference.aspose.com/slides/id/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) mengiterasi slide presentasi normal. Operasi [ForEach.shape](https://reference.aspose.com/slides/id/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/id/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), dan [ForEach.portion](https://reference.aspose.com/slides/id/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) termasuk slide normal, master, dan layout secara default. Gunakan overload mereka dengan `includeNotes` diset ke `true` untuk menyertakan slide catatan.

**Apa perbedaan antara ForEach.shape dan Collect.shapes?**

Gunakan [ForEach.shape](https://reference.aspose.com/slides/id/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) untuk memproses setiap shape secara langsung melalui callback. Gunakan [Collect.shapes](https://reference.aspose.com/slides/id/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) ketika Anda memerlukan hasil iterabel yang dapat disimpan, difilter, dihitung, atau ditelusuri berulang kali.

**Apakah Compress selalu membuat file presentasi lebih kecil?**

Tidak selalu. Hasilnya tergantung pada apakah presentasi berisi tata letak yang tidak terpakai, master yang tidak terpakai, atau font tertanam dengan karakter yang tidak terpakai. Jika tidak ada yang demikian, operasi [Compress](https://reference.aspose.com/slides/id/java/com.aspose.slides/compress/) yang bersangkutan mungkin tidak mengurangi ukuran file.

**Apakah perubahan yang dibuat oleh ForEach atau Compress disimpan secara otomatis?**

Tidak. Pembantu ini beroperasi pada objek [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) yang dimuat di memori. Setelah mengubah elemen dalam callback [ForEach](https://reference.aspose.com/slides/id/java/com.aspose.slides/foreach/) atau menjalankan [Compress](https://reference.aspose.com/slides/id/java/com.aspose.slides/compress/), panggil [Presentation.save](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#save-java.lang.String-int-) untuk menulis hasilnya.

## **Artikel Terkait**

- [Konversi Presentasi](/slides/id/java/convert-presentation/)
- [Gabungkan Presentasi](/slides/id/java/merge-presentation/)
- [Master Slide](/slides/id/java/slide-master/)
- [Kelola Kotak Teks](/slides/id/java/manage-textbox/)
- [Font Tertanam](/slides/id/java/embedded-font/)