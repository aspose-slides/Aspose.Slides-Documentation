---
title: Ubah Ukuran Slide dalam Presentasi dengan Python
linktitle: Ukuran Slide
type: docs
weight: 70
url: /id/python-net/slide-size/
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
- jangan skala
- pastikan muat
- maksimalkan
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara dengan cepat mengubah ukuran slide dalam file PPT, PPTX, dan ODP menggunakan Python dan Aspose.Slides, mengoptimalkan presentasi untuk layar apa pun tanpa kehilangan kualitas."
---
## **Pendahuluan**

Aspose.Slides menyediakan alat lengkap untuk menyesuaikan ukuran slide dan rasio aspek dalam presentasi PowerPoint, yang penting untuk pencetakan maupun tampilan di layar. 

Ukuran Slide Populer dan Rasio:

- **Standard (4:3 Aspect Ratio)**: Ideal untuk layar dan perangkat lama.
- **Widescreen (16:9 Aspect Ratio)**: Direkomendasikan untuk proyektor dan tampilan modern.

Pastikan konsistensi di seluruh presentasi Anda karena satu ukuran slide dan rasio aspek berlaku untuk semua slide. Untuk hasil optimal, atur dimensi slide Anda di awal proses pembuatan presentasi untuk menghindari komplikasi.

{{% alert color="info" title="Note" %}}
Secara default, presentasi yang dibuat dengan Aspose.Slides menggunakan rasio aspek standar 4:3.
{{% /alert %}}

Halaman catatan dan handout memiliki dimensi terpisah dari slide biasa. Lihat [Notes Page Size](/slides/id/python-net/notes-size/) untuk mengubah ukuran dan orientasinya.

## **Ubah Ukuran Slide dalam Presentasi**

Contoh kode ini menunjukkan cara mengubah ukuran slide dalam sebuah presentasi di Python menggunakan Aspose.Slides:

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN_16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-16x9-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## **Tentukan Ukuran Slide Kustom**

Jika Anda menemukan ukuran slide umum (4:3 dan 16:9) tidak cocok untuk pekerjaan Anda, Anda dapat memutuskan untuk menggunakan ukuran slide yang spesifik atau unik. Misalnya, jika Anda berencana mencetak slide ukuran penuh dari presentasi Anda pada tata letak halaman khusus atau jika Anda berniat menampilkan presentasi Anda pada jenis layar tertentu, Anda kemungkinan akan mendapatkan manfaat dari menggunakan pengaturan ukuran kustom untuk presentasi Anda. 

Contoh kode ini menunjukkan cara menggunakan Aspose.Slides untuk Python melalui .NET untuk menentukan ukuran slide kustom untuk sebuah presentasi di Python:

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # Ukuran kertas A4
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## **Tangani Konten Slide Setelah Mengubah Ukuran**

Setelah Anda mengubah ukuran slide untuk sebuah presentasi, konten slide (misalnya gambar atau objek) dapat menjadi terdistorsi. Secara default, objek-objek secara otomatis diubah ukurannya agar sesuai dengan ukuran slide yang baru. Namun, saat mengubah ukuran slide presentasi, Anda dapat menentukan pengaturan yang menentukan cara Aspose.Slides menangani konten pada slide.

Tergantung pada apa yang ingin Anda lakukan atau capai, Anda dapat menggunakan salah satu pengaturan berikut:

- `DO_NOT_SCALE`

  Jika Anda TIDAK ingin objek pada slide diubah ukurannya, gunakan pengaturan ini.

- `ENSURE_FIT`

  Jika Anda ingin memperkecil ke ukuran slide yang lebih kecil dan membutuhkan Aspose.Slides untuk memperkecil objek slide agar semuanya muat pada slide (dengan cara ini, Anda menghindari kehilangan konten), gunakan pengaturan ini. 

- `MAXIMIZE`

  Jika Anda ingin memperbesar ke ukuran slide yang lebih besar dan memerlukan Aspose.Slides untuk memperbesar objek slide agar proporsional dengan ukuran slide yang baru, gunakan pengaturan ini. 

Contoh kode ini menunjukkan cara menggunakan pengaturan `MAXIMIZE` saat mengubah ukuran slide sebuah presentasi:

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```

## **FAQ**

**Apakah saya dapat mengatur ukuran slide kustom menggunakan satuan selain inci (misalnya, poin atau milimeter)?**

Ya. Aspose.Slides menggunakan poin secara internal, di mana 1 poin sama dengan 1/72 inci. Anda dapat mengonversi satuan apa pun (seperti milimeter atau sentimeter) ke poin dan menggunakan nilai yang telah dikonversi untuk menentukan lebar dan tinggi slide.

**Apakah ukuran slide kustom yang sangat besar akan memengaruhi kinerja dan penggunaan memori selama rendering?**

Ya. Dimensi slide yang lebih besar (dalam poin) yang dikombinasikan dengan skala rendering yang lebih tinggi menyebabkan peningkatan penggunaan memori dan waktu proses yang lebih lama. Tujuilah ukuran slide yang praktis dan sesuaikan skala rendering hanya bila diperlukan untuk mencapai kualitas output yang diinginkan.

**Apakah saya dapat menentukan satu ukuran slide non-standar lalu menggabungkan slide dari presentasi yang memiliki ukuran berbeda?**

Anda tidak dapat [merge presentations](/slides/id/python-net/merge-presentation/) ketika mereka memiliki ukuran slide yang berbeda — pertama, ubah ukuran satu presentasi agar cocok dengan yang lain. Saat mengubah ukuran slide, Anda dapat memilih cara penanganan konten yang ada melalui opsi [SlideSizeScaleType](https://reference.aspose.com/slides/id/python-net/aspose.slides/slidesizescaletype/). Setelah menyelaraskan ukuran, Anda dapat menggabungkan slide sambil mempertahankan format.

**Apakah saya dapat menghasilkan thumbnail untuk bentuk individual atau wilayah spesifik dari sebuah slide, dan apakah mereka akan menghormati ukuran slide yang baru?**

Ya. Aspose.Slides dapat merender thumbnail untuk [entire slides](https://reference.aspose.com/slides/id/python-net/aspose.slides/slide/get_image/) serta untuk [selected shapes](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/get_image/). Gambar yang dihasilkan mencerminkan ukuran slide dan rasio aspek saat ini, memastikan bingkai dan geometri yang konsisten.