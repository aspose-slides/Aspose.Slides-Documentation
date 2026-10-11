---
title: Ubah Ukuran Slide Presentasi di Java
linktitle: Ukuran Slide
type: docs
weight: 70
url: /id/java/slide-size/
keywords:
- ukuran slide
- rasio aspek
- standar
- layar lebar
- 4:3
- 16:9
- atur ukuran slide
- ubah ukuran slide
- ukuran slide khusus
- ukuran slide istimewa
- ukuran slide unik
- slide ukuran penuh
- tipe layar
- jangan skala
- memastikan cocok
- maksimalkan
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Pelajari cara dengan cepat mengubah ukuran slide dalam file PPT, PPTX, dan ODP menggunakan Java dan Aspose.Slides, mengoptimalkan presentasi untuk layar apa pun tanpa kehilangan kualitas."
---
## **Pendahuluan**

Aspose.Slides menyediakan alat lengkap untuk menyesuaikan ukuran slide dan rasio aspek dalam presentasi PowerPoint, yang penting untuk pencetakan dan tampilan di layar. 

Ukuran Slide Populer dan Rasio:

- **Standar (Rasio Aspek 4:3)**: Ideal untuk layar dan perangkat lama.
- **Layar Lebar (Rasio Aspek 16:9)**: Disarankan untuk proyektor dan tampilan modern.

Pastikan konsistensi di seluruh presentasi Anda karena satu ukuran slide dan rasio aspek diterapkan pada semua slide. Untuk hasil optimal, atur dimensi slide di awal proses pembuatan presentasi Anda untuk menghindari komplikasi.

{{% alert color="info" title="Note" %}}
Secara default, presentasi yang dibuat dengan Aspose.Slides menggunakan rasio aspek standar 4:3.
{{% /alert %}}

Halaman catatan dan lembaran tangan memiliki dimensi terpisah dari slide reguler. Lihat [Ukuran Halaman Catatan](/slides/id/java/notes-size/) untuk mengubah ukuran dan orientasinya.

## **Mengubah Ukuran Slide dalam Presentasi**

Kode contoh ini menunjukkan cara mengubah ukuran slide dalam presentasi Java menggunakan Aspose.Slides:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-16x9-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Menentukan Ukuran Slide Kustom dalam Presentasi**

Jika Anda menemukan ukuran slide umum (4:3 dan 16:9) tidak cocok untuk pekerjaan Anda, Anda dapat memutuskan menggunakan ukuran slide tertentu atau unik. Misalnya, jika Anda berencana mencetak slide berukuran penuh dari presentasi pada tata letak halaman kustom atau jika Anda ingin menampilkan presentasi pada jenis layar tertentu, Anda mungkin akan mendapat manfaat dari menggunakan pengaturan ukuran kustom untuk presentasi Anda. 

Kode contoh ini menunjukkan cara menggunakan Aspose.Slides untuk Java untuk menentukan ukuran slide kustom untuk sebuah presentasi dalam Java:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // Ukuran kertas A4
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Menangani Konten Slide Setelah Mengubah Ukuran**

Setelah Anda mengubah ukuran slide untuk sebuah presentasi, konten slide (gambar atau objek, misalnya) dapat menjadi terdistorsi. Secara default, objek secara otomatis diubah ukurannya agar sesuai dengan ukuran slide baru. Namun, ketika mengubah ukuran slide presentasi, Anda dapat menentukan pengaturan yang menentukan bagaimana Aspose.Slides menangani konten pada slide.

Bergantung pada apa yang Anda ingin lakukan atau capai, Anda dapat menggunakan salah satu dari pengaturan berikut:

- `DoNotScale`  Jika Anda TIDAK ingin objek pada slide diubah ukurannya, gunakan pengaturan ini.

- `EnsureFit`  Jika Anda ingin memperkecil ukuran slide dan memerlukan Aspose.Slides untuk memperkecil objek slide agar semua muat pada slide (dengan cara ini, Anda menghindari kehilangan konten), gunakan pengaturan ini. 

- `Maximize`  Jika Anda ingin memperbesar ukuran slide dan memerlukan Aspose.Slides untuk memperbesar objek slide agar proporsional dengan ukuran slide baru, gunakan pengaturan ini. 

Kode contoh ini menunjukkan cara menggunakan pengaturan `Maximize` saat mengubah ukuran slide presentasi:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Apakah saya dapat menetapkan ukuran slide kustom menggunakan satuan selain inci (misalnya, poin atau milimeter)?**

Ya. Aspose.Slides menggunakan poin secara internal, di mana 1 poin sama dengan 1/72 inci. Anda dapat mengonversi satuan apa pun (seperti milimeter atau sentimeter) ke poin dan menggunakan nilai yang dikonversi untuk menentukan lebar dan tinggi slide.

**Apakah ukuran slide kustom yang sangat besar akan memengaruhi kinerja dan penggunaan memori selama proses rendering?**

Ya. Dimensi slide yang lebih besar (dalam poin) dikombinasikan dengan skala rendering yang lebih tinggi menyebabkan peningkatan konsumsi memori dan waktu pemrosesan yang lebih lama. Tetapkan ukuran slide yang praktis dan sesuaikan skala rendering hanya bila diperlukan untuk mencapai kualitas output yang diinginkan.

**Apakah saya dapat menentukan satu ukuran slide non-standar dan kemudian menggabungkan slide dari presentasi yang memiliki ukuran berbeda?**

Anda tidak dapat [menggabungkan presentasi](/slides/id/java/merge-presentation/) ketika mereka memiliki ukuran slide yang berbeda — pertama, ubah ukuran salah satu presentasi agar cocok dengan yang lain. Saat mengubah ukuran slide, Anda dapat memilih cara penanganan konten yang ada melalui opsi [SlideSizeScaleType](https://reference.aspose.com/slides/id/java/com.aspose.slides/slidesizescaletype/). Setelah menyelaraskan ukuran, Anda dapat menggabungkan slide sambil mempertahankan format.

**Apakah saya dapat menghasilkan thumbnail untuk bentuk individu atau wilayah tertentu dari sebuah slide, dan apakah mereka akan menghormati ukuran slide baru?**

Ya. Aspose.Slides dapat merender thumbnail untuk [seluruh slide](https://reference.aspose.com/slides/id/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) serta untuk [bentuk yang dipilih](https://reference.aspose.com/slides/id/java/com.aspose.slides/shape/#getImage-int-float-float-). Gambar yang dihasilkan mencerminkan ukuran slide dan rasio aspek saat ini, memastikan bingkai dan geometri yang konsisten.