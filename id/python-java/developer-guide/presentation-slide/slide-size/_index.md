---
title: Ubah Ukuran Slide Presentasi dengan Python via Java
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
  - tidak diskalakan
  - pastikan muat
  - maksimalkan
  - PowerPoint
  - OpenDocument
  - presentasi
  - Python
  - Java
  - Aspose.Slides
description: "Pelajari cara dengan cepat mengubah ukuran slide dalam file PPT, PPTX, dan ODP menggunakan Python via Java dan Aspose.Slides, serta mengoptimalkan presentasi untuk layar apa pun tanpa mengurangi kualitas."
---
## **Pendahuluan**

Aspose.Slides menyediakan alat lengkap untuk menyesuaikan ukuran slide dan rasio aspek dalam presentasi PowerPoint, penting baik untuk pencetakan maupun tampilan di layar.

Ukuran Slide Populer dan Rasio:

- **Standard (Rasio Aspek 4:3)**: Ideal untuk layar dan perangkat lama.
- **Widescreen (Rasio Aspek 16:9)**: Disarankan untuk proyektor dan tampilan modern.

Pastikan konsistensi di seluruh presentasi Anda karena satu ukuran slide dan rasio aspek berlaku untuk semua slide. Untuk hasil optimal, tetapkan dimensi slide Anda di awal proses pembuatan presentasi untuk menghindari komplikasi.

{{% alert color="info" title="Note" %}}
Secara default, presentasi yang dibuat dengan Aspose.Slides menggunakan rasio aspek standar 4:3.
{{% /alert %}}

## **Ubah Ukuran Slide dalam Presentasi**

Contoh kode ini menunjukkan cara mengubah ukuran slide dalam sebuah presentasi menggunakan Python via Java dengan Aspose.Slides:

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

Jika ukuran slide umum (4:3 dan 16:9) tidak cocok untuk pekerjaan Anda, Anda dapat memutuskan untuk menggunakan ukuran slide yang spesifik atau unik. Misalnya, jika Anda berencana mencetak slide berukuran penuh dari presentasi Anda pada tata letak halaman kustom atau jika Anda berniat menampilkan presentasi pada jenis layar tertentu, Anda kemungkinan akan mendapatkan manfaat dari pengaturan ukuran kustom untuk presentasi Anda.

Contoh kode ini menunjukkan cara menggunakan Aspose.Slides untuk Python via Java untuk menentukan ukuran slide kustom bagi sebuah presentasi:

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

Setelah Anda mengubah ukuran slide untuk sebuah presentasi, konten slide (gambar atau objek, misalnya) mungkin menjadi terdistorsi. Secara default, objek-objek secara otomatis diubah ukurannya agar cocok dengan ukuran slide baru. Namun, saat mengubah ukuran slide presentasi, Anda dapat menentukan pengaturan yang menentukan cara Aspose.Slides menangani konten pada slide.

Bergantung pada apa yang ingin Anda lakukan atau capai, Anda dapat menggunakan salah satu pengaturan berikut:

- [DoNotScale](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidesizescaletype/#DoNotScale)

  Jika Anda TIDAK ingin objek pada slide diubah ukurannya, gunakan pengaturan ini.

- [EnsureFit](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidesizescaletype/#EnsureFit)

  Jika Anda ingin memperkecil ke ukuran slide lebih kecil dan membutuhkan Aspose.Slides untuk memperkecil objek slide agar semuanya muat pada slide (dengan cara ini, Anda menghindari kehilangan konten), gunakan pengaturan ini.

- [Maximize](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidesizescaletype/#Maximize)

  Jika Anda ingin memperbesar ke ukuran slide yang lebih besar dan membutuhkan Aspose.Slides untuk memperbesar objek slide agar proporsional dengan ukuran slide baru, gunakan pengaturan ini.

Contoh kode ini menunjukkan cara menggunakan pengaturan [Maximize](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidesizescaletype/#Maximize) saat mengubah ukuran slide sebuah presentasi:

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

**Apakah ukuran slide kustom yang sangat besar akan memengaruhi kinerja dan penggunaan memori saat render?**

Ya. Dimensi slide yang lebih besar (dalam poin) dikombinasikan dengan skala render yang lebih tinggi menyebabkan peningkatan konsumsi memori dan waktu pemrosesan yang lebih lama. Usahakan ukuran slide yang praktis dan sesuaikan skala render hanya bila diperlukan untuk mencapai kualitas output yang diinginkan.

**Apakah saya dapat mendefinisikan satu ukuran slide non-standar dan kemudian menggabungkan slide dari presentasi yang memiliki ukuran berbeda?**

Anda tidak dapat [merge presentations](/slides/id/python-java/merge-presentation/) saat ukuran slide berbeda — pertama, ubah ukuran salah satu presentasi agar cocok dengan yang lain. Saat mengubah ukuran slide, Anda dapat memilih cara konten yang ada ditangani melalui opsi [SlideSizeScaleType](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidesizescaletype/). Setelah ukuran diselaraskan, Anda dapat menggabungkan slide sambil mempertahankan format.

**Apakah saya dapat menghasilkan thumbnail untuk bentuk individu atau wilayah spesifik dari sebuah slide, dan apakah mereka akan menghormati ukuran slide yang baru?**

Ya. Aspose.Slides dapat merender thumbnail untuk [entire slides](https://reference.aspose.com/slides/id/python-java/aspose.slides/slide/#getImage) serta untuk [selected shapes](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getImage). Gambar yang dihasilkan mencerminkan ukuran dan rasio aspek slide saat ini, memastikan framing dan geometri yang konsisten.