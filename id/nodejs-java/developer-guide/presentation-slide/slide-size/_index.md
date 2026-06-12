---
title: Mengubah Ukuran Slide Presentasi di JavaScript
linktitle: Ukuran Slide
type: docs
weight: 70
url: /id/nodejs-java/slide-size/
keywords:
- ukuran slide
- rasio aspek
- standar
- layar lebar
- 4:3
- 16:9
- atur ukuran slide
- ubah ukuran slide
- ukuran slide kustom
- ukuran slide khusus
- ukuran slide unik
- slide ukuran penuh
- tipe layar
- jangan skala
- pastikan pas
- maksimalkan
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
descriptions: "Pelajari cara dengan cepat mengubah ukuran slide dalam file PPT, PPTX, dan ODP menggunakan Node.js dan Aspose.Slides, optimalkan presentasi untuk layar apa pun tanpa kehilangan kualitas."
---
## **Pendahuluan**

Aspose.Slides menyediakan alat lengkap untuk menyesuaikan ukuran slide dan rasio aspek dalam presentasi PowerPoint, yang penting untuk pencetakan maupun tampilan di layar.

Ukuran Slide dan Rasio yang Populer:

- **Standar (Rasio Aspek 4:3)**: Ideal untuk layar dan perangkat lama.
- **Layar Lebar (Rasio Aspek 16:9)**: Disarankan untuk proyektor dan tampilan modern.

Pastikan konsistensi sepanjang presentasi Anda karena satu ukuran slide dan rasio aspek berlaku untuk semua slide. Untuk hasil optimal, tetapkan dimensi slide di awal proses pembuatan presentasi agar menghindari komplikasi.

{{% alert color="primary" %}} 
Secara default, presentasi yang dibuat dengan Aspose.Slides menggunakan rasio aspek standar 4:3.
{{% /alert %}}

## **Mengubah Ukuran Slide dalam Presentasi**

Kode contoh ini menunjukkan cara mengubah ukuran slide dalam sebuah presentasi menggunakan JavaScript dengan Aspose.Slides:

```javascript
var pres = new aspose.slides.Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(aspose.slides.SlideSizeType.OnScreen16x9, aspose.slides.SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Menentukan Ukuran Slide Kustom dalam Presentasi**

Jika ukuran slide umum (4:3 dan 16:9) tidak cocok untuk pekerjaan Anda, Anda dapat memutuskan untuk menggunakan ukuran slide yang spesifik atau unik. Misalnya, jika Anda berencana mencetak slide ukuran penuh dari presentasi pada tata letak halaman kustom atau menampilkan presentasi pada tipe layar tertentu, Anda kemungkinan akan mendapatkan manfaat dari pengaturan ukuran kustom untuk presentasi Anda.

Kode contoh ini menunjukkan cara menggunakan Aspose.Slides untuk Node.js melalui Java untuk menentukan ukuran slide kustom dalam sebuah presentasi menggunakan JavaScript:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, aspose.slides.SlideSizeScaleType.DoNotScale);// Ukuran kertas A4
    pres.save("pres-a4-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Menangani Masalah saat Mengubah Ukuran Slide dalam Presentasi**

Setelah Anda mengubah ukuran slide untuk sebuah presentasi, konten slide (gambar atau objek, misalnya) dapat menjadi terdistorsi. Secara default, objek secara otomatis diubah ukurannya agar sesuai dengan ukuran slide baru. Namun, saat mengubah ukuran slide presentasi, Anda dapat menentukan pengaturan yang menentukan bagaimana Aspose.Slides menangani konten pada slide.

Bergantung pada apa yang ingin Anda lakukan atau capai, Anda dapat menggunakan salah satu pengaturan ini:

- `DoNotScale`

  Jika Anda **tidak** ingin objek pada slide diubah ukurannya, gunakan pengaturan ini.

- `EnsureFit`

  Jika Anda ingin memperkecil ukuran slide dan memerlukan Aspose.Slides untuk menurunkan ukuran objek slide agar semuanya muat pada slide (dengan cara ini Anda menghindari kehilangan konten), gunakan pengaturan ini.

- `Maximize`

  Jika Anda ingin memperbesar ukuran slide dan memerlukan Aspose.Slides untuk memperbesar objek slide agar proporsional dengan ukuran slide baru, gunakan pengaturan ini.

Kode contoh ini menunjukkan cara menggunakan pengaturan `Maximize` saat mengubah ukuran slide presentasi:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(aspose.slides.SlideSizeType.Ledger, aspose.slides.SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Apakah saya dapat mengatur ukuran slide kustom menggunakan satuan selain inci (misalnya, poin atau milimeter)?**

Ya. Aspose.Slides menggunakan poin secara internal, di mana 1 poin sama dengan 1/72 inci. Anda dapat mengonversi satuan apa pun (seperti milimeter atau sentimeter) ke poin dan menggunakan nilai yang dikonversi untuk menentukan lebar dan tinggi slide.

**Apakah ukuran slide kustom yang sangat besar memengaruhi kinerja dan penggunaan memori selama rendering?**

Ya. Dimensi slide yang lebih besar (dalam poin) dikombinasikan dengan skala rendering yang lebih tinggi akan meningkatkan konsumsi memori dan waktu proses. Usahakan ukuran slide yang praktis dan sesuaikan skala rendering hanya bila diperlukan untuk mencapai kualitas output yang diinginkan.

**Bisakah saya mendefinisikan satu ukuran slide non-standar lalu menggabungkan slide dari presentasi yang memiliki ukuran berbeda?**

Anda tidak dapat [merge presentations](/slides/id/nodejs-java/merge-presentation/) sementara mereka memiliki ukuran slide yang berbeda — pertama, ubah ukuran satu presentasi agar cocok dengan yang lain. Saat mengubah ukuran slide, Anda dapat memilih cara menangani konten yang ada melalui opsi [SlideSizeScaleType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slidesizescaletype/). Setelah ukuran selaras, Anda dapat menggabungkan slide sambil mempertahankan format.

**Apakah saya dapat menghasilkan thumbnail untuk bentuk individu atau wilayah tertentu dari slide, dan apakah thumbnail tersebut menghormati ukuran slide baru?**

Ya. Aspose.Slides dapat merender thumbnail untuk [entire slides](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slide/#getImage) maupun untuk [selected shapes](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/#getImage). Gambar yang dihasilkan mencerminkan ukuran slide dan rasio aspek saat ini, memastikan bingkai dan geometri yang konsisten.