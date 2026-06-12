---
title: Ubah Ukuran Slide Presentasi dalam C++
linktitle: Ukuran Slide
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
- ukuran slide khusus
- ukuran slide spesial
- ukuran slide unik
- slide ukuran penuh
- tipe layar
- jangan skalakan
- pastikan muat
- maksimalkan
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
descriptions: "Pelajari cara dengan cepat mengubah ukuran slide dalam file PPT, PPTX, dan ODP menggunakan C++ dan Aspose.Slides, optimalkan presentasi untuk layar apa pun tanpa kehilangan kualitas."
---
## **Pendahuluan**

Aspose.Slides menyediakan alat lengkap untuk menyesuaikan ukuran slide dan rasio aspek dalam presentasi PowerPoint, penting untuk pencetakan maupun tampilan di layar. 

Ukuran Slide Populer dan Rasio:

- **Standard (Rasio Aspek 4:3)**: Ideal untuk layar dan perangkat lama.
- **Widescreen (Rasio Aspek 16:9)**: Disarankan untuk proyektor dan tampilan modern.

Pastikan konsistensi di seluruh presentasi Anda karena satu ukuran slide dan rasio aspek berlaku untuk semua slide. Untuk hasil optimal, atur dimensi slide di awal proses pembuatan presentasi untuk menghindari komplikasi.

{{% alert color="primary" %}} 
Secara default, presentasi yang dibuat dengan Aspose.Slides menggunakan rasio aspek standar 4:3.
{{% /alert %}}

## **Ubah Ukuran Slide dalam Presentasi**

Contoh kode ini menunjukkan cara mengubah ukuran slide dalam sebuah presentasi menggunakan C++ dengan Aspose.Slides:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## **Tentukan Ukuran Slide Kustom dalam Presentasi**

Jika ukuran slide umum (4:3 dan 16:9) tidak cocok untuk pekerjaan Anda, Anda dapat memutuskan menggunakan ukuran slide yang spesifik atau unik. Misalnya, jika Anda berencana mencetak slide berukuran penuh dari presentasi pada tata letak halaman khusus atau jika Anda ingin menampilkan presentasi pada tipe layar tertentu, Anda kemungkinan besar akan mendapatkan manfaat dengan menggunakan pengaturan ukuran kustom untuk presentasi Anda. 

Contoh kode ini menunjukkan cara menggunakan Aspose.Slides untuk C++ guna menentukan ukuran slide kustom untuk sebuah presentasi dalam C++:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// Ukuran kertas A4
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## **Kelola Konten Slide Setelah Mengubah Ukuran**

Setelah Anda mengubah ukuran slide untuk sebuah presentasi, konten slide (gambar atau objek, misalnya) dapat menjadi terdistorsi. Secara default, objek otomatis diubah ukurannya agar sesuai dengan ukuran slide yang baru. Namun, saat mengubah ukuran slide presentasi, Anda dapat menentukan pengaturan yang menentukan bagaimana Aspose.Slides menangani konten pada slide.

Bergantung pada apa yang ingin Anda lakukan atau capai, Anda dapat menggunakan salah satu pengaturan berikut:

- `DoNotScale`

  Jika Anda TIDAK ingin objek pada slide diubah ukurannya, gunakan pengaturan ini.

- `EnsureFit`

  Jika Anda ingin mengubah ke ukuran slide yang lebih kecil dan memerlukan Aspose.Slides untuk memperkecil objek slide sehingga semuanya muat pada slide (dengan cara ini, Anda menghindari kehilangan konten), gunakan pengaturan ini. 

- `Maximize`

  Jika Anda ingin mengubah ke ukuran slide yang lebih besar dan memerlukan Aspose.Slides untuk memperbesar objek slide agar proporsional dengan ukuran slide yang baru, gunakan pengaturan ini. 

Contoh kode ini menunjukkan cara menggunakan pengaturan `Maximize` saat mengubah ukuran slide presentasi:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

## **FAQ**

**Apakah saya dapat mengatur ukuran slide kustom dengan satuan selain inci (misalnya, poin atau milimeter)?**

Ya. Aspose.Slides menggunakan poin secara internal, di mana 1 poin sama dengan 1/72 inci. Anda dapat mengonversi satuan apa pun (seperti milimeter atau sentimeter) ke poin dan menggunakan nilai yang telah dikonversi untuk menentukan lebar dan tinggi slide.

**Apakah ukuran slide kustom yang sangat besar akan memengaruhi kinerja dan penggunaan memori selama proses rendering?**

Ya. Dimensi slide yang lebih besar (dalam poin) yang dikombinasikan dengan skala rendering yang lebih tinggi akan meningkatkan konsumsi memori dan memperpanjang waktu pemrosesan. Usahakan ukuran slide yang praktis dan sesuaikan skala rendering hanya bila diperlukan untuk mencapai kualitas output yang diinginkan.

**Dapatkah saya mendefinisikan satu ukuran slide non-standar lalu menggabungkan slide dari presentasi yang memiliki ukuran berbeda?**

Anda tidak dapat [merge presentations](/slides/id/cpp/merge-presentation/) ketika mereka memiliki ukuran slide yang berbeda — pertama, ubah ukuran satu presentasi agar cocok dengan yang lain. Saat mengubah ukuran slide, Anda dapat memilih cara konten yang ada ditangani melalui opsi [SlideSizeScaleType](https://reference.aspose.com/slides/id/cpp/aspose.slides/slidesizescaletype/). Setelah menyelaraskan ukuran, Anda dapat menggabungkan slide sambil mempertahankan format.

**Apakah saya dapat membuat thumbnail untuk bentuk individual atau wilayah tertentu dari sebuah slide, dan apakah thumbnail tersebut akan menghormati ukuran slide yang baru?**

Ya. Aspose.Slides dapat merender thumbnail untuk [entire slides](/slides/id/cpp/slide/getimage/) serta untuk [selected shapes](/slides/id/cpp/shape/getimage/). Gambar yang dihasilkan mencerminkan ukuran slide dan rasio aspek saat ini, memastikan framing dan geometri yang konsisten.