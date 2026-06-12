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
- "4:3"
- "16:9"
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
descriptions: "Pelajari cara dengan cepat mengubah ukuran slide dalam file PPT, PPTX, dan ODP menggunakan Python dan Aspose.Slides, mengoptimalkan presentasi untuk setiap layar tanpa kehilangan kualitas."
---
## **Pendahuluan**

Aspose.Slides menyediakan alat lengkap untuk menyesuaikan ukuran slide dan rasio aspek dalam presentasi PowerPoint, yang penting untuk pencetakan maupun tampilan di layar. 

Ukuran Slide dan Rasio Populer:

- **Standar (Rasio Aspek 4:3)**: Ideal untuk layar dan perangkat lama.
- **Layar Lebar (Rasio Aspek 16:9)**: Disarankan untuk proyektor dan tampilan modern.

Pastikan konsistensi di seluruh presentasi Anda karena satu ukuran slide dan rasio aspek berlaku untuk semua slide. Untuk hasil optimal, atur dimensi slide di awal proses pembuatan presentasi guna menghindari komplikasi.

{{% alert color="primary" %}} 
Secara default, presentasi yang dibuat dengan Aspose.Slides menggunakan rasio aspek standar 4:3.
{{% /alert %}}

## **Ubah Ukuran Slide dalam Presentasi**

Kode contoh ini menunjukkan cara mengubah ukuran slide dalam sebuah presentasi menggunakan Python dengan Aspose.Slides:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-4x3-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## **Tentukan Ukuran Slide Kustom**

Jika ukuran slide umum (4:3 dan 16:9) tidak cocok untuk pekerjaan Anda, Anda dapat memutuskan untuk menggunakan ukuran slide yang spesifik atau unik. Misalnya, jika Anda berencana mencetak slide berukuran penuh dari presentasi Anda pada tata letak halaman khusus atau jika Anda ingin menampilkan presentasi pada jenis layar tertentu, Anda kemungkinan akan mendapatkan manfaat dengan menggunakan pengaturan ukuran kustom untuk presentasi Anda. 

Kode contoh ini menunjukkan cara menggunakan Aspose.Slides untuk Python via .NET guna menentukan ukuran slide kustom untuk sebuah presentasi dalam Python:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # ukuran kertas A4
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## **Kelola Konten Slide Setelah Mengubah Ukuran**

Setelah Anda mengubah ukuran slide untuk sebuah presentasi, konten slide (misalnya gambar atau objek) dapat menjadi terdistorsi. Secara default, objek secara otomatis diubah ukuran agar sesuai dengan ukuran slide baru. Namun, saat mengubah ukuran slide presentasi, Anda dapat menentukan pengaturan yang menentukan bagaimana Aspose.Slides menangani konten pada slide.

Bergantung pada apa yang ingin Anda lakukan atau capai, Anda dapat menggunakan salah satu pengaturan berikut:

- `DO_NOT_SCALE`

  Jika Anda TIDAK ingin objek pada slide diubah ukurannya, gunakan pengaturan ini.

- `ENSURE_FIT`

  Jika Anda ingin memperkecil ukuran slide dan memerlukan Aspose.Slides untuk mengecilkan objek slide agar semuanya muat pada slide (dengan cara ini, Anda menghindari kehilangan konten), gunakan pengaturan ini. 

- `MAXIMIZE`

  Jika Anda ingin memperbesar ukuran slide dan memerlukan Aspose.Slides untuk memperbesar objek slide agar proporsional dengan ukuran slide baru, gunakan pengaturan ini. 

Kode contoh ini menunjukkan cara menggunakan pengaturan `MAXIMIZE` saat mengubah ukuran slide dalam sebuah presentasi:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```

## **FAQ**

**Bisakah saya mengatur ukuran slide kustom menggunakan satuan selain inci (misalnya, poin atau milimeter)?**

Ya. Aspose.Slides menggunakan poin secara internal, di mana 1 poin sama dengan 1/72 inci. Anda dapat mengonversi satuan apa pun (seperti milimeter atau sentimeter) ke poin dan menggunakan nilai yang telah dikonversi untuk menentukan lebar dan tinggi slide.

**Apakah ukuran slide kustom yang sangat besar akan memengaruhi kinerja dan penggunaan memori saat rendering?**

Ya. Dimensi slide yang lebih besar (dalam poin) dikombinasikan dengan skala rendering yang lebih tinggi menyebabkan peningkatan penggunaan memori dan waktu pemrosesan yang lebih lama. Targetkan ukuran slide yang praktis dan sesuaikan skala rendering hanya bila diperlukan untuk mencapai kualitas output yang diinginkan.

**Dapatkah saya mendefinisikan satu ukuran slide non-standar dan kemudian menggabungkan slide dari presentasi yang memiliki ukuran berbeda?**

Anda tidak dapat [merge presentations](/slides/id/python-net/merge-presentation/) sementara mereka memiliki ukuran slide yang berbeda — pertama, ubah ukuran satu presentasi agar cocok dengan yang lain. Saat mengubah ukuran slide, Anda dapat memilih cara konten yang ada ditangani melalui opsi [SlideSizeScaleType](https://reference.aspose.com/slides/id/python-net/aspose.slides/slidesizescaletype/). Setelah menyamakan ukuran, Anda dapat menggabungkan slide sambil mempertahankan pemformatan.

**Dapatkah saya menghasilkan thumbnail untuk bentuk individu atau wilayah tertentu dari slide, dan apakah mereka akan menghormati ukuran slide yang baru?**

Ya. Aspose.Slides dapat menghasilkan thumbnail untuk [entire slides](https://reference.aspose.com/slides/id/python-net/aspose.slides/slide/get_image/) serta untuk [selected shapes](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/get_image/). Gambar yang dihasilkan mencerminkan ukuran slide dan rasio aspek saat ini, memastikan bingkai dan geometri yang konsisten.