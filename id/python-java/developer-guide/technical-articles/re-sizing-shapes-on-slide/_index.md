---
title: Mengubah Ukuran Bentuk pada Slide Presentasi di Python via Java
type: docs
weight: 110
url: /id/python-java/re-sizing-shapes-on-slide/
keywords:
- ubah ukuran bentuk
- ubah ukuran bentuk
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Dengan mudah mengubah ukuran bentuk pada slide PowerPoint dan OpenDocument dengan Aspose.Slides untuk Python via Java—otomatisasi penyesuaian tata letak slide dan tingkatkan produktivitas."
---
## **Gambaran Umum**

Salah satu pertanyaan paling umum dari pelanggan Aspose.Slides for Python via Java adalah cara mengubah ukuran bentuk sehingga, ketika ukuran slide berubah, data tidak terpotong. Artikel teknis singkat ini menunjukkan cara melakukannya.

## **Ubah Ukuran Bentuk**

Untuk mencegah bentuk menjadi tidak selaras saat ukuran slide berubah, perbarui posisi dan dimensi setiap bentuk agar sesuai dengan tata letak slide yang baru.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, SlideOrientation

# Muat file presentasi.
presentation = Presentation("sample.ppt")
try:
    # Dapatkan ukuran slide asli.
    current_height = presentation.getSlideSize().getSize().getHeight()
    current_width = presentation.getSlideSize().getSize().getWidth()

    # Ubah ukuran slide tanpa menskalakan bentuk yang ada.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)

    # Dapatkan ukuran slide yang baru.
    new_height = presentation.getSlideSize().getSize().getHeight()
    new_width = presentation.getSlideSize().getSize().getWidth()

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    # Ubah ukuran dan posisi bentuk pada setiap slide.
    for slide in presentation.getSlides():
        for shape in slide.getShapes():

            # Skala ukuran bentuk.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Skala posisi bentuk.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 

Tabel tidak memerlukan perlakuan khusus: mengatur lebar dan tinggi tabel akan mengubah skala kolom dan baris secara proporsional, sehingga mengubah skala tinggi baris dan lebar kolom lagi akan menerapkan rasio dua kali.

{{% /alert %}} 

Kode di atas hanya mengubah bentuk pada slide. Slide master dan slide tata letak memiliki bentuk masing-masing, jadi skala mereka juga ketika Anda ingin seluruh presentasi mengikuti ukuran slide yang baru:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, SlideOrientation

presentation = Presentation("sample.pptx")
try:
    # Dapatkan ukuran slide asli.
    current_height = presentation.getSlideSize().getSize().getHeight()
    current_width = presentation.getSlideSize().getSize().getWidth()

    # Ubah ukuran slide tanpa menskalakan bentuk yang ada.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    # presentation.getSlideSize().setOrientation(SlideOrientation.Portrait)

    # Dapatkan ukuran slide yang baru.
    new_height = presentation.getSlideSize().getSize().getHeight()
    new_width = presentation.getSlideSize().getSize().getWidth()

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    for master in presentation.getMasters():
        for shape in master.getShapes():
            # Skala ukuran bentuk.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Skala posisi bentuk.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

        for layout_slide in master.getLayoutSlides():
            for shape in layout_slide.getShapes():
                # Skala ukuran bentuk.
                shape.setHeight(shape.getHeight() * height_ratio)
                shape.setWidth(shape.getWidth() * width_ratio)

                # Skala posisi bentuk.
                shape.setY(shape.getY() * height_ratio)
                shape.setX(shape.getX() * width_ratio)

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            # Skala ukuran bentuk.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # Skala posisi bentuk.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Mengapa bentuk menjadi terdistorsi atau terpotong setelah mengubah ukuran slide?**

Saat mengubah ukuran slide, bentuk mempertahankan posisi dan ukuran aslinya kecuali skala diubah secara eksplisit. Hal ini dapat menyebabkan konten terpotong atau bentuk menjadi tidak selaras.

**Apakah kode yang disediakan berfungsi untuk semua jenis bentuk?**

Ya. Mengatur tinggi dan lebar berfungsi untuk kotak teks, gambar, diagram, dan tabel sekaligus.

**Bagaimana cara mengubah ukuran tabel saat mengubah ukuran slide?**

Skala bentuk tabel itu sendiri, persis seperti bentuk lainnya. Baris dan kolomnya mengikuti secara proporsional, jadi jangan skala mereka lagi setelahnya.

**Apakah pengubahan ukuran ini berfungsi untuk slide master dan slide tata letak?**

Ya, tetapi Anda juga harus melintasi [Presentation.getMasters](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getMasters) dan [Presentation.getLayoutSlides](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getLayoutSlides) dan menerapkan logika skala yang sama pada bentuk mereka untuk memastikan konsistensi di seluruh presentasi.

**Apakah saya dapat mengubah orientasi slide (potret/lanskap) bersama dengan pengubahan ukuran?**

Ya. Anda dapat menggunakan [SlideSize.setOrientation](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidesize/#setOrientation) untuk mengubah orientasi. Pastikan Anda mengatur logika skala secara sesuai untuk mempertahankan tata letak.

**Apakah ada batasan ukuran slide yang dapat saya atur?**

Aspose.Slides mendukung ukuran khusus, tetapi ukuran yang sangat besar dapat memengaruhi kinerja atau kompatibilitas dengan beberapa versi PowerPoint.

**Bagaimana cara mencegah bentuk dengan rasio aspek tetap menjadi terdistorsi?**

Anda dapat memeriksa metode [getAspectRatioLocked](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshapelock/#getAspectRatioLocked) pada kunci bentuk sebelum melakukan skala. Jika terkunci, sesuaikan lebar atau tinggi secara proporsional daripada men‑skala masing‑masing secara terpisah.