---
title: Terapkan Efek Bentuk pada Presentasi dengan Python
linktitle: Efek Bentuk
type: docs
weight: 30
url: /id/python-net/shape-effect
keywords:
- efek bentuk
- efek bayangan
- efek refleksi
- efek cahaya
- efek tepi lembut
- format efek
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Ubah file PPT, PPTX, dan ODP Anda dengan efek bentuk lanjutan menggunakan Aspose.Slides untuk Python—buat slide yang menarik dan profesional dalam hitungan detik."
---
## **Pendahuluan**

Sementara efek di PowerPoint dapat digunakan untuk membuat sebuah bentuk menonjol, mereka berbeda dari [isian](/slides/id/python-net/shape-formatting/#gradient-fill) atau outline. Dengan menggunakan efek PowerPoint, Anda dapat membuat refleksi yang meyakinkan pada sebuah bentuk, menyebarkan cahaya bentuk, dll.

![Efek bentuk](shape-effect.png)

PowerPoint menyediakan enam efek yang dapat diterapkan pada bentuk. Anda dapat menerapkan satu atau beberapa efek pada sebuah bentuk.

Beberapa kombinasi efek terlihat lebih baik daripada yang lain. Untuk alasan ini, PowerPoint memiliki opsi di bawah **Preset**. Opsi Preset pada dasarnya adalah kombinasi dua atau lebih efek yang telah terbukti terlihat bagus. Dengan cara ini, dengan memilih preset, Anda tidak perlu membuang waktu menguji atau menggabungkan efek yang berbeda untuk menemukan kombinasi yang tepat.

Aspose.Slides menyediakan properti dan metode di bawah kelas [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) yang memungkinkan Anda menerapkan efek yang sama pada bentuk dalam presentasi PowerPoint.

## **Menerapkan Efek Bayangan**

Aspose.Slides untuk Python via .NET mendukung bayangan luar dan dalam untuk bentuk. Anda dapat menyesuaikan warna, arah, jarak, dan radius blur agar sesuai dengan desain presentasi Anda.

### **Menerapkan Bayangan Luar**

Gunakan bayangan luar untuk membuat kartu atau panel menonjol di latar belakang slide. Bayangan ini meluas di luar tepi bentuk, menciptakan kesan bahwa bentuk tersebut terangkat di atas slide. Sesuaikan warna, arah, jarak, dan radius blur agar cocok dengan pencahayaan dan gaya templat Anda.

Kode Python berikut menunjukkan cara menerapkan [efek bayangan luar](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) pada sebuah persegi panjang:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_outer_shadow_effect()
    shape.effect_format.outer_shadow_effect.shadow_color.color = slides.Color.dark_gray
    shape.effect_format.outer_shadow_effect.distance = 10
    shape.effect_format.outer_shadow_effect.direction = 45

    presentation.save("shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Efek bayangan](shadow_effect.png)

### **Menerapkan Bayangan Dalam**

Saat mereproduksi gaya visual templat, gunakan bayangan dalam untuk memberikan tampilan kartu atau panel yang terukir. Bayangan luar meluas di luar bentuk dan membuatnya tampak terangkat, sementara bayangan dalam memberikan bayangan pada bagian dalam tepi bentuk.

Panggil [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/), lalu konfigurasikan [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/). Nilai radius blur yang lebih besar menghasilkan tepi yang lebih lembut.

Contoh Python ini membuat kartu biru muda dengan bayangan dalam berwarna abu‑abu gelap dan menyimpannya sebagai file PPTX:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.light_blue
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    shape.effect_format.enable_inner_shadow_effect()
    shadow = shape.effect_format.inner_shadow_effect
    shadow.shadow_color.color = slides.Color.dim_gray
    shadow.direction = 225
    shadow.distance = 7
    shadow.blur_radius = 6

    presentation.save("inner_shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Persegi panjang biru muda dengan bayangan dalam](inner_shadow_effect.png)

Untuk menghapus bayangan dalam, panggil [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/) pada format efek bentuk.

### **Menerapkan, Mengubah, dan Menghapus Bayangan Preset**

Panggil [enable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_preset_shadow_effect/) dan atur properti [praset](https://reference.aspose.com/slides/python-net/aspose.slides.effects/presetshadow/preset/) bayangan ke nilai [PresetShadowType](https://reference.aspose.com/slides/python-net/aspose.slides/presetshadowtype/). Untuk mengganti gaya, ubah praset pada bentuk yang sama. Panggil [disable_preset_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_preset_shadow_effect/) untuk menghapus bayangan sambil mempertahankan isian dan outline.

Contoh ini memperlihatkan empat tahap berdampingan pada satu slide. Ia menggandakan persegi panjang sebelum setiap perubahan sehingga Anda dapat membandingkan hasilnya. Kedua bayangan dipindahkan sebesar 10 poin. Arah 225° menempatkan bayangan pertama di atas dan ke kiri persegi panjang, dan 45° menempatkan yang kedua di bawah dan ke kanan.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(800, 120, slides.SlideSizeScaleType.DO_NOT_SCALE)
    shapes = presentation.slides[0].shapes

    shape = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 15, 30, 170, 60)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.steel_blue
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = slides.Color.dark_blue
    shape.text_frame.text = "No shadow"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 14
    shapes.add_clone(shape)

    shape.x += 200
    shape.effect_format.enable_preset_shadow_effect()
    shadow = shape.effect_format.preset_shadow_effect
    shadow.preset = slides.PresetShadowType.TOP_LEFT_DROP_SHADOW
    shadow.distance = 10
    shadow.direction = 225
    shape.text_frame.text = "TopLeftDropShadow"
    shapes.add_clone(shape)

    shape.x += 200
    shadow.preset = slides.PresetShadowType.BOTTOM_RIGHT_DROP_SHADOW
    shadow.direction = 45
    shape.text_frame.text = "BottomRightDropShadow"
    shapes.add_clone(shape)

    shape.x += 200
    shape.effect_format.disable_preset_shadow_effect()
    shape.text_frame.text = "No shadow"

    presentation.save("preset_shadows.pptx", slides.export.SaveFormat.PPTX)
```

| Asli | Preset pertama | Preset kedua | Setelah dihapus |
| :---: | :---: | :---: | :---: |
| ![Tanpa bayangan](preset_shadow_original.png) | ![Bayangan jatuh kiri atas](preset_shadow_top_left.png) | ![Bayangan jatuh kanan bawah](preset_shadow_bottom_right.png) | ![Tanpa bayangan setelah dihapus](preset_shadow_removed.png) |

## **Menerapkan Efek Refleksi**

Untuk menerapkan efek refleksi di Aspose.Slides untuk Python via .NET, Anda dapat menambahkan refleksi mirip cermin pada bentuk, menyesuaikan parameter seperti jarak, transparansi, dan ukuran. Efek ini meningkatkan estetika presentasi Anda dengan memberikan bentuk tampilan yang lebih halus dan canggih. Mudah diimplementasikan dengan kode sederhana, memungkinkan penerapan cepat pada banyak elemen untuk desain yang konsisten.

Kode Python berikut menunjukkan cara menerapkan [efek refleksi](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) pada sebuah bentuk:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_reflection_effect()
    shape.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM
    shape.effect_format.reflection_effect.direction = 90
    shape.effect_format.reflection_effect.distance = 40
    shape.effect_format.reflection_effect.blur_radius = 2

    presentation.save("reflection_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Efek refleksi](reflection_effect.png)

## **Menerapkan Efek Cahaya**

Untuk menerapkan efek cahaya pada sebuah bentuk di Aspose.Slides untuk Python via .NET, Anda dapat menambahkan aura lembut yang bersinar di sekitar bentuk, menyesuaikan properti seperti warna dan ukuran. Efek ini membantu membuat bentuk menonjol dan menambahkan elemen visual yang menarik pada presentasi Anda. Mudah diimplementasikan dengan kode minimal, meningkatkan tampilan keseluruhan slide Anda.

Kode Python berikut menunjukkan cara menerapkan [efek cahaya](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) pada sebuah bentuk:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_glow_effect()
    shape.effect_format.glow_effect.color.color = slides.Color.magenta
    shape.effect_format.glow_effect.radius = 15

    presentation.save("glow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Efek cahaya](glow_effect.png)

## **Menerapkan Efek Tepi Lembut**

Untuk menerapkan efek tepi lembut di Aspose.Slides untuk Python via .NET, Anda dapat menciptakan transisi halus dan kabur di sekitar tepi bentuk. Efek ini menambahkan tampilan yang lebih subtil dan halus, cocok untuk desain yang memerlukan penampilan lembut. Anda dapat dengan mudah menyesuaikan parameter seperti radius untuk mencapai efek yang diinginkan pada berbagai bentuk dalam presentasi Anda.

Kode Python berikut menunjukkan cara menerapkan [tepi lembut](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) pada sebuah bentuk:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)
    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 8

    presentation.save("soft_edges_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Efek tepi lembut](soft_edges_effect.png)

## **Menerapkan Efek Blur**

Gunakan blur bentuk untuk melunakkan isian dan outline bentuk sambil tetap mempertahankan bentuk dapat diedit. Panggil [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) pada format efek bentuk. Radius diukur dalam poin (1/72 inci): gunakan nilai non‑negatif, dengan nilai yang lebih besar menghasilkan blur yang lebih kuat. Radius nol tidak mengubah tampilan.

Pengaturan [grow](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/grow/) mengontrol batas tampak dari efek. Dengan `False`, blur dipotong pada batas gambar asli, termasuk outline. Dengan `True`, blur dapat melampaui batas tersebut. Tidak ada pengaturan yang mengubah posisi atau ukuran bentuk.

Perbandingan di bawah ini menggunakan isian, outline, dan dimensi bentuk yang sama sepanjang proses. Baris atas menggunakan `grow = False`; baris bawah menggunakan `grow = True`.

![Persegi panjang asli dibandingkan dengan radius blur 5 dan 15 poin, dengan grow dinonaktifkan dan diaktifkan](shape_blur_comparison.png)

Contoh Python ini membuat persegi panjang oranye dengan outline biru tua, menerapkan blur 5 poin, kemudian memperbaruinya menjadi blur 15 poin dengan memanggil [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) lagi. Ia menyimpan kedua keadaan blur, lalu memanggil [disable_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_blur_effect/) dan menyimpan bentuk tanpa blur.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 80, 160, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.orange
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = slides.Color.dark_blue
    shape.line_format.width = 8

    shape.effect_format.set_blur_effect(5, False)
    presentation.save("shape_blur_5.pptx", slides.export.SaveFormat.PPTX)

    shape.effect_format.set_blur_effect(15, True)
    presentation.save("shape_blur_15.pptx", slides.export.SaveFormat.PPTX)

    shape.effect_format.disable_blur_effect()
    presentation.save("shape_blur_removed.pptx", slides.export.SaveFormat.PPTX)
```

Blur bentuk memengaruhi isian dan outline bersama-sama. Efek tepi lembut memudarkan tepi bentuk, sementara blur bayangan melunakkan hanya bayangan. Efek transformasi gambar bekerja pada konten gambar; contoh ini menerapkan blur langsung pada format efek bentuk tanpa mengonversi bentuk menjadi gambar.

## **FAQ**

**Apakah saya dapat menerapkan beberapa efek pada bentuk yang sama?**

Ya, Anda dapat menggabungkan berbagai efek, seperti bayangan, refleksi, dan cahaya, pada satu bentuk untuk menciptakan tampilan yang lebih dinamis.

**Bentuk apa saja yang dapat saya beri efek?**

Anda dapat menerapkan efek pada berbagai bentuk, termasuk autoshape, diagram, tabel, gambar, objek SmartArt, objek OLE, dan lainnya.

**Apakah saya dapat menerapkan efek pada bentuk yang dikelompokkan?**

Ya, Anda dapat menerapkan efek pada bentuk yang dikelompokkan. Efek akan diterapkan pada seluruh grup.