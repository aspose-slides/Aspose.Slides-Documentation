---
title: Mengonversi Slide PowerPoint ke PNG dalam Python
linktitle: PowerPoint ke PNG
type: docs
weight: 30
url: /id/python-java/convert-powerpoint-to-png/
keywords:
- konversi PowerPoint
- konversi presentasi
- konversi slide
- konversi PPT
- konversi PPTX
- PowerPoint ke PNG
- presentasi ke PNG
- slide ke PNG
- PPT ke PNG
- PPTX ke PNG
- simpan PPT sebagai PNG
- simpan PPTX sebagai PNG
- ekspor PPT ke PNG
- ekspor PPTX ke PNG
- Python
- Java
- Aspose.Slides
description: "Mengonversi slide PowerPoint menjadi gambar PNG di Python melalui Java. Ekspor presentasi PPT, PPTX, dan ODP dengan skala khusus atau dimensi gambar yang tepat."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengonversi presentasi PowerPoint menjadi gambar PNG menggunakan Aspose.Slides untuk Python melalui Java. Anda dapat memuat file PPT, PPTX, dan ODP, merender setiap slide, dan menyimpannya sebagai gambar PNG terpisah.

Contoh-contoh juga menunjukkan cara mengendalikan dimensi output dengan faktor skala atau lebar dan tinggi yang tepat. Setiap contoh memulai mesin virtual Java bila diperlukan dan melepaskan sumber daya presentasi serta gambar setelah digunakan.

## **Convert PowerPoint to PNG**

1. Muat file input dengan kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).
2. Dapatkan slide dengan menggunakan [Presentation.getSlides](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getSlides).
3. Render setiap slide menggunakan [Slide.getImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/slide/#getImage).
4. Simpan setiap gambar yang dirender dengan [ImageFormat.Png](https://reference.aspose.com/slides/id/python-java/aspose.slides/imageformat/#Png), lalu lepaskan sumber dayanya.

Contoh Python berikut mengekspor semua slide dengan ukuran default mereka:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage()
        try:
            slide_image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Convert PowerPoint to PNG with a Custom Scale**

Berikan faktor skala horizontal dan vertikal ke [Slide.getImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/slide/#getImage) untuk memperbesar atau memperkecil dimensi output. Misalnya, slide 720 × 540 poin yang dirender dengan faktor skala 2 pada kedua sumbu menghasilkan gambar 1440 × 1080 piksel.

Gunakan faktor skala yang sama untuk mempertahankan rasio aspek slide. Faktor yang berbeda akan meregangkan slide secara horizontal atau vertikal.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    scale_x = 2.0
    scale_y = 2.0
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(scale_x, scale_y)
        try:
            slide_image.save(f"slide_scaled_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Convert PowerPoint to PNG with a Custom Size**

Untuk menentukan dimensi piksel yang tepat, berikan objek Java `Dimension` dengan lebar dan tinggi yang diinginkan ke [Slide.getImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/slide/#getImage). Pilih dimensi dengan rasio aspek yang sama dengan slide sumber agar tidak terjadi distorsi.

Contoh berikut menyimpan setiap slide sebagai gambar PNG 960 × 720 piksel:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    image_size = Dimension(960, 720)
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(image_size)
        try:
            slide_image.save(f"slide_sized_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**Apakah saya dapat mengekspor bentuk individual, seperti bagan atau gambar, alih-alih seluruh slide?**

Ya. Aspose.Slides mendukung [membuat thumbnail untuk bentuk individual](/slides/id/python-java/create-shape-thumbnails/), yang dapat Anda simpan sebagai gambar PNG.

**Apakah saya dapat mengonversi presentasi secara paralel di server?**

Gunakan instance presentasi terpisah untuk tiap thread atau proses, dan gunakan jalur output yang unik agar file tidak tertimpa. Jangan bagikan instance presentasi antar thread. Lihat [Multithreading](/slides/id/python-java/multithreading/).

**Apa saja batasan versi percobaan saat mengekspor ke PNG?**

Mode evaluasi menambahkan watermark pada gambar output dan menerapkan [pembatasan lain](/slides/id/python-java/licensing/). Terapkan lisensi untuk menghapus batasan ini.