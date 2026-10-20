---
title: "Ubah Ukuran Bentuk pada Slide Presentasi dengan Python"
type: docs
weight: 130
url: /id/python-net/resizing-shapes-on-slide/
aliases:
  - /python-net/re-sizing-shapes-on-slide/
  - /id/python-net/re-sizing-shapes-on-slide/
keywords:
  - ubah ukuran bentuk
  - mengubah ukuran bentuk
  - PowerPoint
  - OpenDocument
  - presentasi
  - Python
  - Aspose.Slides
description: "Dengan mudah mengubah ukuran bentuk pada slide PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Python via .NET—otomatisasi penyesuaian tata letak slide dan tingkatkan produktivitas."
---
## **Gambaran Umum**

Saat Anda mengubah ukuran slide presentasi, Anda mungkin juga perlu mengubah ukuran dan memposisikan kembali bentuk‑bentuknya agar sesuai dengan dimensi baru. Artikel ini menunjukkan cara menskalakan bentuk secara manual serta cara menangani tabel pada slide, master, dan tata letak.

## **Ubah Ukuran Bentuk**

Untuk mempertahankan posisi dan ukuran relatif setiap bentuk, kalikan koordinat horizontal dan lebar bentuk dengan rasio lebar slide baru terhadap lebar asli. Terapkan rasio tinggi yang sesuai pada koordinat vertikal dan tinggi bentuk.

Contoh pertama memuat presentasi yang slide‑nya tidak berisi tabel, mengubah ukuran slide menjadi A4, dan menyimpan hasilnya. Contoh ini menggunakan [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/) dengan [SlideSizeScaleType.DO_NOT_SCALE](https://reference.aspose.com/slides/python-net/aspose.slides/slidesizescaletype/) sehingga perulangan selanjutnya mengendalikan penskalaan. Rasio‑rasio tersebut tidak memiliki satuan; posisi dan dimensi bentuk diukur dalam poin. Rasio lebar dan tinggi yang berbeda dapat mendistorsi bentuk, dan mengubah dimensi bentuk tidak menyesuaikan ukuran font.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Hitung faktor skala horizontal dan vertikal secara independen.
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    for slide in presentation.slides:
        for shape in slide.shapes:
            shape.width *= width_ratio
            shape.height *= height_ratio
            shape.x *= width_ratio
            shape.y *= height_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Note" %}}
Tabel memerlukan penanganan terpisah: skalakan lebar kolom dan tinggi baris alih‑alih menetapkan lebar serta tinggi keseluruhan tabel. Tinggi baris dapat tetap lebih besar dari yang diminta jika konten sel memerlukan ruang lebih.
{{% /alert %}}

Contoh kedua mendukung tabel dan memproses bentuk pada master serta tata letak, selain slide individu, sebelum menyimpan presentasi yang telah diubah ukurannya. Pembantu dalam contoh ini menangani setiap [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) dengan menskalakan [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) dan [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/). Selanjutnya contoh ini menskalakan posisi tabel tanpa menskalakan dimensi keseluruhannya secara terpisah.

```python
import aspose.slides as slides


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, slides.Table):
            # Dimensi tabel dikontrol oleh lebar kolom dan tinggi baris.
            for column in shape.columns:
                column.width *= width_ratio

            for row in shape.rows:
                row.minimal_height *= height_ratio
        else:
            shape.width *= width_ratio
            shape.height *= height_ratio

        shape.x *= width_ratio
        shape.y *= height_ratio


with slides.Presentation("sample.pptx") as presentation:
    # Hitung faktor skala horizontal dan vertikal secara independen.
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    # Ubah ukuran bentuk yang didefinisikan pada master dan tata letak serta slide individu.
    for master in presentation.masters:
        resize_shapes(master.shapes, width_ratio, height_ratio)

        for layout_slide in master.layout_slides:
            resize_shapes(layout_slide.shapes, width_ratio, height_ratio)

    for slide in presentation.slides:
        resize_shapes(slide.shapes, width_ratio, height_ratio)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Mengapa bentuk menjadi terdistorsi atau terpotong setelah mengubah ukuran slide?**

Jika Anda mengubah ukuran slide tanpa menskalakan bentuk, maka bentuk tetap pada posisi dan dimensi asalnya dan dapat melampaui batas slide. Menskalakan lebar dan tinggi dengan rasio yang berbeda juga dapat mendistorsi bentuk.

**Apakah kode yang diberikan berfungsi untuk semua jenis bentuk?**

Contoh pertama mengubah batas bentuk secara langsung dan ditujukan untuk slide yang tidak memiliki tabel. Contoh kedua menangani tabel secara terpisah. Periksa tata letak hasil, khususnya teks dan tabel, karena contoh‑contoh ini tidak menskalakan ukuran font dan konten tabel dapat membatasi tinggi baris.

**Bagaimana cara mengubah ukuran tabel saat mengubah ukuran slide?**

Skalakan lebar kolom dengan rasio lebar dan tinggi baris minimum dengan rasio tinggi, kemudian skalakan posisi tabel, seperti yang ditunjukkan pada contoh kedua.

**Apakah perubahan ukuran ini berlaku untuk slide master dan slide tata letak?**

Ya. Contoh kedua mengiterasi melalui [Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) dan tiap master melalui [MasterSlide.layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/layout_slides/) serta menerapkan logika pengubahan ukuran yang sama pada bentuk‑bentuknya.

**Bisakah saya mengubah orientasi slide (potret/lanskap) bersamaan dengan pengubahan ukuran?**

Ya. Atur [SlideSize.orientation](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/orientation/) setelah mengubah ukuran slide dan sebelum membaca dimensi target, sehingga faktor skala mencerminkan orientasi akhir.

**Apakah ada batasan ukuran slide yang dapat saya tentukan?**

Anda dapat menentukan dimensi slide kustom dengan [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/). Dimensi yang didukung juga tergantung pada format presentasi dan aplikasi yang digunakan untuk membuka file.

**Bagaimana cara mencegah bentuk dengan rasio aspek tetap menjadi terdistorsi?**

Gunakan faktor skala yang sama untuk lebar dan tinggi. Untuk menyesuaikan tata letak asli dalam dimensi slide baru, gunakan rasio yang lebih kecil antara lebar dan tinggi untuk kedua dimensi serta posisi. Cara ini mempertahankan proporsi tetapi dapat meninggalkan ruang kosong di salah satu sisi.