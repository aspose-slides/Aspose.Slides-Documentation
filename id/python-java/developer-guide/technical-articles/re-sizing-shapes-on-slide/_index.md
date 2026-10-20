---
title: Ubah Ukuran Bentuk pada Slide Presentasi dengan Python via Java
type: docs
weight: 110
url: /id/python-java/resizing-shapes-on-slide/
aliases:
  - /python-java/mengubah-ukuran-bentuk-pada-slide/
  - /id/python-java/re-sizing-shapes-on-slide/
keywords:
  - ubah ukuran bentuk
  - ubah ukuran bentuk
  - PowerPoint
  - OpenDocument
  - presentasi
  - Python
  - Java
  - Aspose.Slides
description: "Dengan mudah mengubah ukuran bentuk pada slide PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Python via Java—otomatisasi penyesuaian tata letak slide dan tingkatkan produktivitas."
---
## **Gambaran Umum**

Saat Anda mengubah ukuran slide presentasi, Anda mungkin juga perlu mengubah ukuran dan memposisikan kembali bentuk‑bentuknya agar sesuai dengan dimensi baru. Artikel ini menunjukkan cara memperbesar bentuk secara manual dan cara menangani tabel pada slide, master, dan tata letak.

## **Ubah Ukuran Bentuk**

Untuk mempertahankan posisi dan ukuran relatif setiap bentuk, kalikan koordinat horizontal dan lebar bentuk tersebut dengan rasio lebar slide baru terhadap lebar asli. Terapkan rasio tinggi yang sesuai pada koordinat vertikal dan tinggi bentuk.

Contoh pertama memuat presentasi yang slide‑nya tidak mengandung tabel, mengubah ukuran slide menjadi A4, dan menyimpan hasilnya. Ia menggunakan [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize) dengan [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/python-java/aspose.slides/slidesizescaletype/#DoNotScale) sehingga loop berikutnya mengendalikan skala. Rasio‑rasio tersebut tidak memiliki satuan; posisi dan dimensi bentuk diukur dalam poin. Rasio lebar dan tinggi yang berbeda dapat mendistorsi bentuk, dan mengubah dimensi bentuk tidak mengubah skala ukuran font.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType

presentation = Presentation("sample.pptx")
try:
    # Hitung faktor skala horizontal dan vertikal secara independen.
    original_size = presentation.getSlideSize().getSize()
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    target_size = presentation.getSlideSize().getSize()
    width_ratio = target_size.getWidth() / original_size.getWidth()
    height_ratio = target_size.getHeight() / original_size.getHeight()

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            shape.setWidth(shape.getWidth() * width_ratio)
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setX(shape.getX() * width_ratio)
            shape.setY(shape.getY() * height_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Tabel memerlukan penanganan terpisah: skala lebar kolom dan tinggi baris alih‑alih menetapkan lebar dan tinggi keseluruhan tabel. Tinggi baris dapat tetap lebih besar daripada yang diminta jika konten sel memerlukan lebih banyak ruang.
{{% /alert %}}

Contoh kedua mendukung tabel dan memproses bentuk pada master dan tata letak serta slide individu sebelum menyimpan presentasi yang telah diubah ukurannya. Pembantuannya menangani setiap [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) dengan memperbesar lebar kolom menggunakan [Column.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/column/#setWidth) dan tinggi minimal baris dengan [Row.setMinimalHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#setMinimalHeight). Kemudian ia memperbesar posisi tabel tanpa memperbesar dimensi keseluruhannya secara terpisah.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, Table


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, Table):
            # Dimensi tabel dikendalikan oleh lebar kolom dan tinggi baris.
            for column in shape.getColumns():
                column.setWidth(column.getWidth() * width_ratio)

            for row in shape.getRows():
                row.setMinimalHeight(row.getMinimalHeight() * height_ratio)
        else:
            shape.setWidth(shape.getWidth() * width_ratio)
            shape.setHeight(shape.getHeight() * height_ratio)

        shape.setX(shape.getX() * width_ratio)
        shape.setY(shape.getY() * height_ratio)


presentation = Presentation("sample.pptx")
try:
        # Hitung faktor skala horizontal dan vertikal secara independen.
        original_size = presentation.getSlideSize().getSize()
        presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
        target_size = presentation.getSlideSize().getSize()
        width_ratio = target_size.getWidth() / original_size.getWidth()
        height_ratio = target_size.getHeight() / original_size.getHeight()

        # Ubah ukuran bentuk yang didefinisikan pada master dan tata letak serta slide individual.
        for master in presentation.getMasters():
            resize_shapes(master.getShapes(), width_ratio, height_ratio)

            for layout_slide in master.getLayoutSlides():
                resize_shapes(layout_slide.getShapes(), width_ratio, height_ratio)

        for slide in presentation.getSlides():
            resize_shapes(slide.getShapes(), width_ratio, height_ratio)

        presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tanya Jawab**

**Mengapa bentuk menjadi terdistorsi atau terpotong setelah mengubah ukuran slide?**

Jika Anda mengubah ukuran slide tanpa menskalakan bentuk‑bentuk, mereka mempertahankan posisi dan dimensi asli dan dapat melampaui batas slide. Menskalakan lebar dan tinggi dengan rasio yang berbeda juga dapat mendistorsi bentuk.

**Apakah kode yang disediakan berfungsi untuk semua jenis bentuk?**

Contoh pertama mengubah batas bentuk secara langsung dan ditujukan untuk slide tanpa tabel. Contoh kedua menangani tabel secara terpisah. Periksa tata letak yang dihasilkan, terutama teks dan tabel, karena contoh‑contoh ini tidak menskalakan ukuran font dan konten tabel dapat membatasi tinggi baris.

**Bagaimana cara mengubah ukuran tabel saat mengubah ukuran slide?**

Skala lebar kolom dengan rasio lebar dan tinggi minimal baris dengan rasio tinggi, lalu skala posisi tabel, seperti yang ditunjukkan pada contoh kedua.

**Apakah perubahan ukuran ini berfungsi untuk slide master dan slide tata letak?**

Ya. Contoh kedua mengiterasi melalui [Presentation.getMasters](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasters) dan setiap master melalui [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#getLayoutSlides) serta menerapkan logika pengubahan ukuran yang sama pada bentuk‑bentuknya.

**Apakah saya dapat mengubah orientasi slide (potret/lanskap) bersamaan dengan mengubah ukuran?**

Ya. Panggil [SlideSize.setOrientation](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setOrientation) setelah mengubah ukuran slide dan sebelum membaca dimensi target, sehingga faktor skala mencerminkan orientasi akhir.

**Apakah ada batas ukuran slide yang dapat saya atur?**

Anda dapat menentukan dimensi slide khusus dengan [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize). Dimensi yang didukung juga bergantung pada format presentasi dan aplikasi yang digunakan untuk membuka file.

**Bagaimana saya dapat mencegah bentuk dengan rasio aspek tetap menjadi terdistorsi?**

Gunakan faktor skala yang sama untuk lebar dan tinggi. Untuk menyesuaikan tata letak asli dalam dimensi slide baru, gunakan rasio yang lebih kecil antara lebar dan tinggi untuk kedua dimensi dan posisi. Ini mempertahankan proporsi tetapi dapat meninggalkan ruang kosong di salah satu sisi.