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
- ukuran slide khusus
- ukuran slide unik
- slide ukuran penuh
- tipe layar
- jangan skala
- pastikan muat
- maksimalkan
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Pelajari cara dengan cepat mengubah ukuran slide dalam file PPT, PPTX, dan ODP menggunakan C++ dan Aspose.Slides, mengoptimalkan presentasi untuk layar apa pun tanpa kehilangan kualitas."
---
## **Pendahuluan**

Aspose.Slides menyediakan alat lengkap untuk menyesuaikan ukuran slide dan rasio aspek dalam presentasi PowerPoint, penting untuk pencetakan maupun tampilan di layar. 

Ukuran Slide Populer dan Rasio:

- **Standar (Rasio Aspek 4:3)**: Ideal untuk layar dan perangkat lama.
- **Layar Lebar (Rasio Aspek 16:9)**: Disarankan untuk proyektor dan tampilan modern.

Pastikan konsistensi sepanjang presentasi Anda karena satu ukuran slide dan rasio aspek berlaku untuk semua slide. Untuk hasil optimal, atur dimensi slide di awal proses pembuatan presentasi untuk menghindari komplikasi.

{{% alert color="info" %}} 
Secara default, presentasi yang dibuat dengan Aspose.Slides menggunakan rasio aspek standar 4:3.
{{% /alert %}}

Halaman catatan dan handout memiliki dimensi terpisah dari slide biasa. Lihat [Ukuran Halaman Catatan](/slides/id/cpp/notes-size/) untuk mengubah ukuran dan orientasinya.

## **Ubah Ukuran Slide dalam Presentasi**

Kode contoh ini menunjukkan cara mengubah ukuran slide dalam sebuah presentasi di C++ menggunakan Aspose.Slides:

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## **Tentukan Ukuran Slide Kustom dalam Presentasi**

Jika ukuran slide umum (4:3 dan 16:9) tidak cocok untuk pekerjaan Anda, Anda dapat memutuskan untuk menggunakan ukuran slide yang spesifik atau unik. Misalnya, jika Anda berencana mencetak slide ukuran penuh dari presentasi pada tata letak halaman khusus atau jika Anda ingin menampilkan presentasi pada tipe layar tertentu, Anda kemungkinan besar akan memperoleh manfaat dengan menggunakan pengaturan ukuran kustom untuk presentasi Anda. 

Kode contoh ini menunjukkan cara menggunakan Aspose.Slides untuk C++ untuk menentukan ukuran slide kustom bagi sebuah presentasi di C++:

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// Ukuran kertas A4
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## **Kelola Konten Slide setelah Mengubah Ukuran**

Setelah Anda mengubah ukuran slide untuk sebuah presentasi, konten slide (gambar atau objek, misalnya) dapat menjadi terdistorsi. Secara default, objek-objek secara otomatis diubah ukurannya agar sesuai dengan ukuran slide baru. Namun, saat mengubah ukuran slide presentasi, Anda dapat menentukan pengaturan yang menentukan bagaimana Aspose.Slides menangani konten pada slide.

Tergantung pada apa yang ingin Anda lakukan atau capai, Anda dapat menggunakan salah satu pengaturan berikut:

- `DoNotScale`

  Jika Anda TIDAK ingin objek pada slide diubah ukurannya, gunakan pengaturan ini.

- `EnsureFit`

  Jika Anda ingin memperkecil ukuran slide dan memerlukan Aspose.Slides untuk mengecilkan objek slide agar semuanya muat pada slide (dengan cara ini, Anda menghindari kehilangan konten), gunakan pengaturan ini. 

- `Maximize`

  Jika Anda ingin memperbesar ukuran slide dan memerlukan Aspose.Slides untuk memperbesar objek slide agar proporsional dengan ukuran slide baru, gunakan pengaturan ini. 

Kode contoh ini menunjukkan cara menggunakan pengaturan `Maximize` saat mengubah ukuran slide presentasi:

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

## **FAQ**

### Saya dapat mengatur ukuran slide kustom menggunakan satuan selain inci (misalnya, poin atau milimeter)?

Ya. Aspose.Slides menggunakan poin secara internal, di mana 1 poin sama dengan 1/72 inci. Anda dapat mengonversi satuan apa pun (seperti milimeter atau sentimeter) ke poin dan menggunakan nilai yang telah dikonversi untuk mendefinisikan lebar dan tinggi slide.

### Apakah ukuran slide kustom yang sangat besar akan memengaruhi kinerja dan penggunaan memori selama proses rendering?

Ya. Dimensi slide yang lebih besar (dalam poin) dikombinasikan dengan skala rendering yang lebih tinggi menghasilkan peningkatan konsumsi memori dan waktu pemrosesan yang lebih lama. Tujuilah ukuran slide yang praktis dan sesuaikan skala rendering hanya bila diperlukan untuk mencapai kualitas output yang diinginkan.

### Saya dapat mendefinisikan satu ukuran slide non-standar lalu menggabungkan slide dari presentasi yang memiliki ukuran berbeda?

Anda tidak dapat [merge presentations](/slides/id/cpp/merge-presentation/) sementara mereka memiliki ukuran slide yang berbeda — pertama, ubah ukuran salah satu presentasi agar cocok dengan yang lain. Saat mengubah ukuran slide, Anda dapat memilih bagaimana konten yang ada ditangani melalui opsi [SlideSizeScaleType](https://reference.aspose.com/slides/id/cpp/aspose.slides/slidesizescaletype/). Setelah ukuran selaras, Anda dapat menggabungkan slide sambil mempertahankan format.

### Saya dapat menghasilkan thumbnail untuk bentuk individu atau wilayah spesifik pada slide, dan apakah mereka akan menghormati ukuran slide baru?

Ya. Aspose.Slides dapat merender thumbnail untuk [entire slides](https://reference.aspose.com/slides/id/cpp/aspose.slides/slide/getimage/) serta untuk [selected shapes](https://reference.aspose.com/slides/id/cpp/aspose.slides/shape/getimage/). Gambar yang dihasilkan mencerminkan ukuran slide dan rasio aspek saat ini, memastikan framing dan geometri yang konsisten.