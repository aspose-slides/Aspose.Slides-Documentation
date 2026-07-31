---
title: "Ubah Ukuran Slide Presentasi di C++"
linktitle: "Ukuran Slide"
type: docs
weight: 70
url: /id/cpp/slide-size/
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
- jenis layar
- jangan skalakan
- pastikan muat
- maksimalkan
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Pelajari cara cepat mengubah ukuran slide dalam file PPT, PPTX, dan ODP menggunakan C++ dan Aspose.Slides, mengoptimalkan presentasi untuk layar apa pun tanpa kehilangan kualitas."
---
## **Introduction**

Aspose.Slides menyediakan alat lengkap untuk menyesuaikan ukuran slide dan rasio aspek dalam presentasi PowerPoint, penting baik untuk pencetakan maupun tampilan di layar. 

Ukuran Slide Populer dan Rasio:

- **Standard (4:3 Aspect Ratio)**: Ideal untuk layar dan perangkat lama.
- **Widescreen (16:9 Aspect Ratio)**: Disarankan untuk proyektor dan tampilan modern.

Pastikan konsistensi sepanjang presentasi Anda karena satu ukuran slide dan rasio aspek diterapkan pada semua slide. Untuk hasil optimal, atur dimensi slide di awal proses pembuatan presentasi untuk menghindari komplikasi.

{{% alert color="primary" %}} 
Secara default, presentasi yang dibuat dengan Aspose.Slides menggunakan rasio aspek standar 4:3.
{{% /alert %}}

## **Ubah Ukuran Slide dalam Presentasi**

Contoh kode ini menunjukkan cara mengubah ukuran slide dalam sebuah presentasi di C++ menggunakan Aspose.Slides:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## **Tentukan Ukuran Slide Kustom dalam Presentasi**

Jika ukuran slide umum (4:3 dan 16:9) tidak cocok untuk pekerjaan Anda, Anda dapat memutuskan untuk menggunakan ukuran slide tertentu atau unik. Misalnya, jika Anda berencana mencetak slide berukuran penuh dari presentasi Anda pada tata letak halaman khusus atau jika Anda ingin menampilkan presentasi pada jenis layar tertentu, Anda kemungkinan akan mendapat manfaat dari pengaturan ukuran kustom untuk presentasi Anda. 

Contoh kode ini menunjukkan cara menggunakan Aspose.Slides untuk C++ untuk menentukan ukuran slide kustom bagi sebuah presentasi di C++:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// ukuran kertas A4
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## **Tangani Konten Slide Setelah Mengubah Ukuran**

Setelah Anda mengubah ukuran slide untuk sebuah presentasi, konten slide (gambar atau objek, misalnya) mungkin menjadi terdistorsi. Secara default, objek secara otomatis diubah ukurannya untuk menyesuaikan ukuran slide baru. Namun, saat mengubah ukuran slide presentasi, Anda dapat menentukan pengaturan yang menentukan cara Aspose.Slides menangani konten pada slide.

Bergantung pada apa yang ingin Anda lakukan atau capai, Anda dapat menggunakan salah satu pengaturan berikut:

- `DoNotScale`

  Jika Anda TIDAK ingin objek pada slide diubah ukurannya, gunakan pengaturan ini.

- `EnsureFit`

  Jika Anda ingin memperkecil ukuran slide dan membutuhkan Aspose.Slides untuk mengecilkan objek slide agar semua muat pada slide (dengan cara ini, Anda menghindari kehilangan konten), gunakan pengaturan ini.

- `Maximize`

  Jika Anda ingin memperbesar ukuran slide dan membutuhkan Aspose.Slides untuk memperbesar objek slide agar proporsional dengan ukuran slide baru, gunakan pengaturan ini.

Contoh kode ini menunjukkan cara menggunakan pengaturan `Maximize` saat mengubah ukuran slide presentasi:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

## **FAQ**

**Apakah saya dapat mengatur ukuran slide kustom menggunakan satuan selain inci (misalnya, poin atau milimeter)?**

Ya. Aspose.Slides menggunakan poin secara internal, di mana 1 poin sama dengan 1/72 inci. Anda dapat mengonversi satuan apapun (seperti milimeter atau sentimeter) ke poin dan menggunakan nilai yang dikonversi untuk menentukan lebar dan tinggi slide.

**Apakah ukuran slide kustom yang sangat besar akan memengaruhi kinerja dan penggunaan memori saat rendering?**

Ya. Dimensi slide yang lebih besar (dalam poin) yang digabungkan dengan skala rendering yang lebih tinggi menyebabkan peningkatan konsumsi memori dan waktu proses yang lebih lama. Usahakan ukuran slide yang praktis dan sesuaikan skala rendering hanya bila diperlukan untuk mencapai kualitas output yang diinginkan.

**Apakah saya dapat mendefinisikan satu ukuran slide non-standar dan kemudian menggabungkan slide dari presentasi yang memiliki ukuran berbeda?**

Anda tidak dapat [menggabungkan presentasi](/slides/id/cpp/merge-presentation/) ketika mereka memiliki ukuran slide yang berbeda — pertama, ubah ukuran satu presentasi agar cocok dengan yang lain. Saat mengubah ukuran slide, Anda dapat memilih cara penanganan konten yang ada melalui opsi [SlideSizeScaleType](https://reference.aspose.com/slides/id/cpp/aspose.slides/slidesizescaletype/). Setelah menyelaraskan ukuran, Anda dapat menggabungkan slide sambil mempertahankan pemformatan.

**Apakah saya dapat menghasilkan thumbnail untuk bentuk individual atau wilayah tertentu dari sebuah slide, dan apakah mereka akan menghormati ukuran slide yang baru?**

Ya. Aspose.Slides dapat menghasilkan thumbnail untuk [seluruh slide](https://reference.aspose.com/slides/id/cpp/aspose.slides/slide/getimage/) serta untuk [bentuk yang dipilih](https://reference.aspose.com/slides/id/cpp/aspose.slides/shape/getimage/). Gambar yang dihasilkan mencerminkan ukuran slide dan rasio aspek saat ini, memastikan bingkai dan geometri yang konsisten.