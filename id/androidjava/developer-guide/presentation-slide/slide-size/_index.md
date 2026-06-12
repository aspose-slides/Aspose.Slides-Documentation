---
title: Ubah Ukuran Slide Presentasi di Android
linktitle: Ukuran Slide
type: docs
weight: 70
url: /id/androidjava/slide-size/
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
- slide berukuran penuh
- tipe layar
- jangan skalakan
- pastikan muat
- maksimalkan
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
descriptions: "Dengan cepat mengubah ukuran slide dalam file PPT, PPTX, dan ODP menggunakan Java dan Aspose.Slides untuk Android, mengoptimalkan presentasi untuk layar apa pun tanpa kehilangan kualitas."
---
## **Pendahuluan**

Aspose.Slides menyediakan alat lengkap untuk mengatur ukuran slide dan rasio aspek dalam presentasi PowerPoint, yang penting untuk pencetakan maupun tampilan di layar. 

Ukuran Slide Populer dan Rasio:

- **Standar (Rasio Aspek 4:3)**: Ideal untuk layar dan perangkat lama.
- **Layar Lebar (Rasio Aspek 16:9)**: Disarankan untuk proyektor dan tampilan modern.

Pastikan konsistensi di seluruh presentasi Anda karena satu ukuran slide dan rasio aspek berlaku untuk semua slide. Untuk hasil optimal, tetapkan dimensi slide Anda di awal proses pembuatan presentasi untuk menghindari komplikasi.

{{% alert color="primary" %}} 
Secara default, presentasi yang dibuat dengan Aspose.Slides menggunakan rasio aspek standar 4:3.
{{% /alert %}}

## **Ubah Ukuran Slide dalam Presentasi**

Kode contoh ini menunjukkan cara mengubah ukuran slide dalam sebuah presentasi di Java menggunakan Aspose.Slides:

```java
Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tentukan Ukuran Slide Kustom dalam Presentasi**

Jika Anda menemukan ukuran slide umum (4:3 dan 16:9) tidak sesuai dengan pekerjaan Anda, Anda dapat memutuskan untuk menggunakan ukuran slide yang spesifik atau unik. Misalnya, jika Anda berencana mencetak slide berukuran penuh dari presentasi Anda pada tata letak halaman khusus atau jika Anda berniat menampilkan presentasi pada tipe layar tertentu, Anda kemungkinan besar akan mendapatkan manfaat dari penggunaan pengaturan ukuran khusus untuk presentasi Anda. 

Kode contoh ini menunjukkan cara menggunakan Aspose.Slides untuk Android via Java untuk menentukan ukuran slide kustom untuk sebuah presentasi di Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // Ukuran kertas A4
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Kelola Konten Slide Setelah Mengubah Ukuran**

Setelah Anda mengubah ukuran slide untuk sebuah presentasi, konten slide (gambar atau objek, misalnya) dapat menjadi terdistorsi. Secara default, objek akan secara otomatis diubah ukurannya agar sesuai dengan ukuran slide baru. Namun, saat mengubah ukuran slide presentasi, Anda dapat menentukan pengaturan yang menentukan bagaimana Aspose.Slides menangani konten pada slide.

Tergantung pada apa yang ingin Anda lakukan atau capai, Anda dapat menggunakan salah satu pengaturan berikut:

- `DoNotScale`

  Jika Anda TIDAK ingin objek pada slide diubah ukurannya, gunakan pengaturan ini.

- `EnsureFit`

  Jika Anda ingin memperkecil ukuran slide dan memerlukan Aspose.Slides untuk memperkecil objek slide agar semuanya muat di slide (dengan cara ini, Anda menghindari kehilangan konten), gunakan pengaturan ini. 

- `Maximize`

  Jika Anda ingin memperbesar ukuran slide dan memerlukan Aspose.Slides untuk memperbesar objek slide sehingga proporsional dengan ukuran slide baru, gunakan pengaturan ini. 

Kode contoh ini menunjukkan cara menggunakan pengaturan `Maximize` saat mengubah ukuran slide sebuah presentasi:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Apakah saya dapat mengatur ukuran slide kustom menggunakan satuan selain inci (misalnya, poin atau milimeter)?**

Ya. Aspose.Slides menggunakan poin secara internal, di mana 1 poin sama dengan 1/72 inci. Anda dapat mengonversi satuan apa pun (seperti milimeter atau sentimeter) ke poin dan menggunakan nilai yang dikonversi untuk menentukan lebar dan tinggi slide.

**Apakah ukuran slide kustom yang sangat besar akan memengaruhi kinerja dan penggunaan memori saat rendering?**

Ya. Dimensi slide yang lebih besar (dalam poin) dikombinasikan dengan skala rendering yang lebih tinggi akan meningkatkan konsumsi memori dan waktu proses yang lebih lama. Tujulah ukuran slide yang praktis dan sesuaikan skala rendering hanya jika diperlukan untuk mencapai kualitas output yang diinginkan.

**Apakah saya dapat menentukan satu ukuran slide non-standar dan kemudian menggabungkan slide dari presentasi yang memiliki ukuran berbeda?**

Anda tidak dapat [menggabungkan presentasi](/slides/id/androidjava/merge-presentation/) saat mereka memiliki ukuran slide yang berbeda — pertama, ubah ukuran salah satu presentasi agar cocok dengan yang lain. Saat mengubah ukuran slide, Anda dapat memilih bagaimana konten yang ada ditangani melalui opsi [SlideSizeScaleType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/slidesizescaletype/). Setelah menyelaraskan ukuran, Anda dapat menggabungkan slide sambil mempertahankan pemformatan.

**Apakah saya dapat menghasilkan thumbnail untuk bentuk individu atau wilayah spesifik dari sebuah slide, dan apakah mereka akan menghormati ukuran slide baru?**

Ya. Aspose.Slides dapat merender thumbnail untuk [seluruh slide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) serta untuk [bentuk terpilih](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/shape/#getImage-int-float-float-). Gambar yang dihasilkan mencerminkan ukuran slide dan rasio aspek saat ini, memastikan bingkai dan geometri yang konsisten.