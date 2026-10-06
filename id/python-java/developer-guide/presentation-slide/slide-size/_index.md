---
title: Ubah Ukuran Slide Presentasi dalam Python via Java
linktitle: Ukuran Slide
type: docs
weight: 70
url: /id/python-java/slide-size/
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
- pastikan muat
- maksimalkan
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Pelajari cara cepat mengubah ukuran slide dalam file PPT, PPTX, dan ODP dengan Python via Java dan Aspose.Slides, serta mengoptimalkan presentasi untuk layar apa pun tanpa kehilangan kualitas."
---
## **Pendahuluan**

Aspose.Slides menyediakan alat komprehensif untuk menyesuaikan ukuran slide dan rasio aspek dalam presentasi PowerPoint, penting untuk pencetakan maupun tampilan di layar.

Ukuran Slide Populer dan Rasio:

- **Standard (4:3 Aspect Ratio)**: Ideal untuk layar dan perangkat lama.
- **Widescreen (16:9 Aspect Ratio)**: Direkomendasikan untuk proyektor dan tampilan modern.

Pastikan konsistensi di seluruh presentasi Anda karena satu ukuran slide dan rasio aspek berlaku untuk semua slide. Untuk hasil optimal, atur dimensi slide di awal proses pembuatan presentasi untuk menghindari komplikasi.

{{% alert color="info" title="Note" %}}
Secara default, presentasi yang dibuat dengan Aspose.Slides menggunakan rasio aspek standar 4:3.
{{% /alert %}}

Halaman catatan dan handout memiliki dimensi terpisah dari slide biasa. Lihat [Ukuran Halaman Catatan](/slides/id/python-java/notes-size/) untuk mengubah ukuran dan orientasinya.

## **Ubah Ukuran Slide dalam Presentasi**

Kode contoh ini menunjukkan cara mengubah ukuran slide dalam sebuah presentasi di Python via Java menggunakan Aspose.Slides:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType, SlideSizeType

presentation = Presentation("pres-4x3-aspect-ratio.pptx")
try:
    presentation.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale)
    presentation.save("pres-16x9-aspect-ratio.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tentukan Ukuran Slide Kustom dalam Presentasi**

Jika Anda menemukan ukuran slide umum (4:3 dan 16:9) tidak cocok untuk pekerjaan Anda, Anda dapat memutuskan untuk menggunakan ukuran slide tertentu atau unik. Misalnya, jika Anda berencana mencetak slide ukuran penuh dari presentasi Anda pada tata letak halaman kustom atau jika Anda berniat menampilkan presentasi Anda pada tipe layar tertentu, Anda kemungkinan akan mendapatkan manfaat dari menggunakan pengaturan ukuran khusus untuk presentasi Anda.

Kode contoh ini menunjukkan cara menggunakan Aspose.Slides untuk Python via Java untuk menentukan ukuran slide kustom untuk sebuah presentasi:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("pres.pptx")
try:
    presentation.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale)
    presentation.save("pres-custom-slide-size.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Kelola Konten Slide Setelah Mengubah Ukuran**

Setelah Anda mengubah ukuran slide untuk sebuah presentasi, konten slide (misalnya gambar atau objek) dapat menjadi terdistorsi. Secara default, objek secara otomatis diubah ukurannya untuk menyesuaikan ukuran slide baru. Namun, saat mengubah ukuran slide presentasi, Anda dapat menentukan pengaturan yang menentukan bagaimana Aspose.Slides menangani konten pada slide.

Tergantung pada apa yang Anda ingin lakukan atau capai, Anda dapat menggunakan salah satu pengaturan berikut:

- [DoNotScale](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidesizescaletype/#DoNotScale)
  
  Jika Anda TIDAK ingin objek pada slide diubah ukurannya, gunakan pengaturan ini.

- [EnsureFit](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidesizescaletype/#EnsureFit)
  
  Jika Anda ingin memperkecil ukuran slide dan memerlukan Aspose.Slides untuk memperkecil objek slide agar semuanya muat di slide (dengan cara ini, Anda menghindari kehilangan konten), gunakan pengaturan ini.

- [Maximize](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidesizescaletype/#Maximize)
  
  Jika Anda ingin memperbesar ukuran slide dan memerlukan Aspose.Slides untuk memperbesar objek slide agar proporsional dengan ukuran slide baru, gunakan pengaturan ini.

Kode contoh ini menunjukkan cara menggunakan pengaturan [Maximize](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidesizescaletype/#Maximize) saat mengubah ukuran slide presentasi:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType, SlideSizeType

presentation = Presentation("pres.pptx")
try:
    presentation.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize)
finally:
    presentation.dispose()
```

## **FAQ**

**Apakah saya dapat mengatur ukuran slide kustom menggunakan satuan selain inci (misalnya, poin atau milimeter)?**

Ya. Aspose.Slides menggunakan poin secara internal, di mana 1 poin sama dengan 1/72 inci. Anda dapat mengonversi satuan apa pun (seperti milimeter atau sentimeter) ke poin dan menggunakan nilai yang dikonversi untuk menentukan lebar dan tinggi slide.

**Apakah ukuran slide kustom yang sangat besar akan memengaruhi kinerja dan penggunaan memori saat rendering?**

Ya. Dimensi slide yang lebih besar (dalam poin) yang dikombinasikan dengan skala rendering yang lebih tinggi menyebabkan peningkatan konsumsi memori dan waktu pemrosesan yang lebih lama. Tujuannya adalah ukuran slide yang praktis dan sesuaikan skala rendering hanya bila diperlukan untuk mencapai kualitas output yang diinginkan.

**Apakah saya dapat menentukan satu ukuran slide non-standar lalu menggabungkan slide dari presentasi yang memiliki ukuran berbeda?**

Anda tidak dapat [menggabungkan presentasi](/slides/id/python-java/merge-presentation/) ketika memiliki ukuran slide yang berbeda — pertama, ubah ukuran satu presentasi agar cocok dengan yang lain. Saat mengubah ukuran slide, Anda dapat memilih cara konten yang ada ditangani melalui opsi [SlideSizeScaleType](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidesizescaletype/). Setelah menyelaraskan ukuran, Anda dapat menggabungkan slide sambil menjaga format.

**Apakah saya dapat menghasilkan thumbnail untuk bentuk individu atau wilayah tertentu dari slide, dan apakah mereka akan menghormati ukuran slide baru?**

Ya. Aspose.Slides dapat merender thumbnail untuk [seluruh slide](https://reference.aspose.com/slides/id/python-java/aspose.slides/slide/#getImage) maupun untuk [bentuk terpilih](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getImage). Gambar yang dihasilkan mencerminkan ukuran slide dan rasio aspek saat ini, memastikan bingkai dan geometri yang konsisten.