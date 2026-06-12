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
- ukuran slide spesial
- ukuran slide unik
- slide ukuran penuh
- tipe layar
- jangan skala
- pastikan muat
- maksimalkan
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
descriptions: "Pelajari cara cepat mengubah ukuran slide dalam file PPT, PPTX, dan ODP dengan Java dan Aspose.Slides, mengoptimalkan presentasi untuk layar apa pun tanpa kehilangan kualitas."
---
## **Introduction**

Aspose.Slides menyediakan alat lengkap untuk menyesuaikan ukuran slide dan rasio aspek dalam presentasi PowerPoint, penting untuk pencetakan maupun tampilan di layar. 

Popular Slide Sizes and Ratios:

- **Standard (Rasio Aspek 4:3)**: Ideal untuk layar dan perangkat lama.
- **Widescreen (Rasio Aspek 16:9)**: Disarankan untuk proyektor dan tampilan modern.

Pastikan konsistensi di seluruh presentasi Anda karena satu ukuran slide dan rasio aspek diterapkan ke semua slide. Untuk hasil optimal, atur dimensi slide di awal proses pembuatan presentasi untuk menghindari komplikasi.

{{% alert color="primary" %}} 
Secara default, presentasi yang dibuat dengan Aspose.Slides menggunakan rasio aspek standar 4:3.
{{% /alert %}}

## **Change the Slide Size in Presentations**

Kode contoh ini menunjukkan cara mengubah ukuran slide dalam presentasi di Java menggunakan Aspose.Slides:

```java
Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Specify Custom Slide Sizes in Presentations**

Jika ukuran slide umum (4:3 dan 16:9) tidak cocok untuk pekerjaan Anda, Anda dapat memilih ukuran slide yang spesifik atau unik. Misalnya, jika Anda berencana mencetak slide berukuran penuh dari presentasi pada tata letak halaman khusus atau jika Anda ingin menampilkan presentasi pada tipe layar tertentu, Anda kemungkinan akan mendapat manfaat dari pengaturan ukuran khusus untuk presentasi Anda. 

Kode contoh ini menunjukkan cara menggunakan Aspose.Slides untuk Java untuk menentukan ukuran slide khusus untuk sebuah presentasi di Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // Ukuran kertas A4
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Handle Slide Content After Resizing**

Setelah Anda mengubah ukuran slide untuk sebuah presentasi, konten slide (gambar atau objek, misalnya) dapat menjadi terdistorsi. Secara default, objek secara otomatis diubah ukuran agar sesuai dengan ukuran slide yang baru. Namun, saat mengubah ukuran slide presentasi, Anda dapat menentukan pengaturan yang menentukan bagaimana Aspose.Slides menangani konten pada slide. 

Bergantung pada apa yang ingin Anda lakukan atau capai, Anda dapat menggunakan salah satu pengaturan berikut:

- `DoNotScale`

  Jika Anda TIDAK ingin objek pada slide diubah ukurannya, gunakan pengaturan ini.

- `EnsureFit`

  Jika Anda ingin memperkecil ke ukuran slide yang lebih kecil dan membutuhkan Aspose.Slides untuk mengecilkan objek slide agar semuanya muat pada slide (dengan cara ini, Anda menghindari kehilangan konten), gunakan pengaturan ini. 

- `Maximize`

  Jika Anda ingin memperbesar ke ukuran slide yang lebih besar dan membutuhkan Aspose.Slides untuk memperbesar objek slide agar proporsional dengan ukuran slide baru, gunakan pengaturan ini. 

Kode contoh ini menunjukkan cara menggunakan pengaturan `Maximize` saat mengubah ukuran slide presentasi:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Can I set a custom slide size using units other than inches (for example, points or millimeters)?**

Ya. Aspose.Slides menggunakan poin secara internal, di mana 1 poin sama dengan 1/72 inci. Anda dapat mengonversi unit apa pun (seperti milimeter atau sentimeter) ke poin dan menggunakan nilai yang dikonversi untuk mendefinisikan lebar dan tinggi slide.

**Will a very large custom slide size affect performance and memory usage during rendering?**

Ya. Dimensi slide yang lebih besar (dalam poin) dikombinasikan dengan skala rendering yang lebih tinggi menyebabkan peningkatan konsumsi memori dan waktu pemrosesan yang lebih lama. Tujuilah ukuran slide yang praktis dan sesuaikan skala rendering hanya bila diperlukan untuk mencapai kualitas output yang diinginkan.

**Can I define one non-standard slide size and then merge slides from presentations that have different sizes?**

Anda tidak dapat [merge presentations](/slides/id/java/merge-presentation/) ketika mereka memiliki ukuran slide yang berbeda — pertama, ubah ukuran satu presentasi agar cocok dengan yang lain. Saat mengubah ukuran slide, Anda dapat memilih bagaimana konten yang ada ditangani melalui opsi [SlideSizeScaleType](https://reference.aspose.com/slides/id/java/com.aspose.slides/slidesizescaletype/). Setelah menyelaraskan ukuran, Anda dapat menggabungkan slide sambil mempertahankan format.

**Can I generate thumbnails for individual shapes or specific regions of a slide, and will they respect the new slide size?**

Ya. Aspose.Slides dapat merender thumbnail untuk [entire slides](https://reference.aspose.com/slides/id/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) serta untuk [selected shapes](https://reference.aspose.com/slides/id/java/com.aspose.slides/shape/#getImage-int-float-float-). Gambar yang dihasilkan mencerminkan ukuran slide dan rasio aspek saat ini, memastikan bingkai dan geometri yang konsisten.