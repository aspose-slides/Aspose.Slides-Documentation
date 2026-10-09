---
title: Terapkan Efek Bentuk dalam Presentasi dengan Python
linktitle: Efek Bentuk
type: docs
weight: 30
url: /id/python-net/shape-effect
keywords:
- efek bentuk
- efek bayangan
- efek refleksi
- efek sinar
- efek tepi halus
- format efek
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Ubah file PPT, PPTX, dan ODP Anda dengan efek bentuk lanjutan menggunakan Aspose.Slides untuk Python—buat slide yang menonjol dan profesional dalam hitungan detik."
---
## **Pengantar**

Sementara efek di PowerPoint dapat digunakan untuk menonjolkan sebuah bentuk, mereka berbeda dari [isi](/slides/id/python-net/shape-formatting/#gradient-fill) atau garis tepi. Dengan menggunakan efek PowerPoint, Anda dapat membuat refleksi yang meyakinkan pada sebuah bentuk, menyebarkan cahaya pada bentuk, dll.

![Efek Bentuk](shape-effect.png)

PowerPoint menyediakan enam efek yang dapat diterapkan pada bentuk. Anda dapat menerapkan satu atau lebih efek pada sebuah bentuk.

Beberapa kombinasi efek terlihat lebih baik daripada yang lain. Karena itu, PowerPoint memiliki opsi di bawah **Preset**. Opsi Preset pada dasarnya merupakan kombinasi dua atau lebih efek yang sudah terbukti bagus. Dengan cara ini, dengan memilih preset, Anda tidak perlu membuang waktu untuk menguji atau menggabungkan efek yang berbeda demi menemukan kombinasi yang tepat.

Aspose.Slides menyediakan properti dan metode di bawah kelas [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) yang memungkinkan Anda menerapkan efek yang sama pada bentuk dalam presentasi PowerPoint.

## **Menerapkan Efek Bayangan**

Aspose.Slides for Python via .NET mendukung bayangan luar dan dalam untuk bentuk. Anda dapat menyesuaikan warna, arah, jarak, dan radius blur agar cocok dengan desain presentasi Anda.

### **Menerapkan Bayangan Luar**

Gunakan bayangan luar untuk membuat kartu atau panel menonjol dari latar belakang slide. Bayangan ini meluas melewati tepi bentuk, menciptakan kesan bahwa bentuk tersebut terangkat di atas slide. Sesuaikan warna, arah, jarak, dan radius blur agar sesuai dengan pencahayaan dan gaya template Anda.

Python ini menunjukkan cara menerapkan [efek bayangan luar](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) pada sebuah persegi panjang:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_outer_shadow_effect()
    shape.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.dark_gray
    shape.effect_format.outer_shadow_effect.distance = 10
    shape.effect_format.outer_shadow_effect.direction = 45

    presentation.save("shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Efek bayangan](shadow_effect.png)

### **Menerapkan Bayangan Dalam**

Saat mereproduksi gaya visual template, gunakan bayangan dalam untuk memberi kartu atau panel tampilan terbenam. Bayangan luar meluas di luar bentuk dan membuatnya tampak terangkat, sementara bayangan dalam memberi warna pada bagian dalam tepi bentuk.

Panggil [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/), lalu konfigurasikan [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/). Nilai radius blur yang lebih besar menghasilkan tepi yang lebih lembut.

Contoh Python ini membuat kartu biru muda dengan bayangan dalam abu‑abu gelap dan menyimpannya sebagai file PPTX:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.light_blue
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    shape.effect_format.enable_inner_shadow_effect()
    shadow = shape.effect_format.inner_shadow_effect
    shadow.shadow_color.color = draw.Color.dim_gray
    shadow.direction = 225
    shadow.distance = 7
    shadow.blur_radius = 6

    presentation.save("inner_shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Persegi panjang biru muda dengan bayangan dalam](inner_shadow_effect.png)

Untuk menghapus bayangan dalam, panggil [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/) pada format efek bentuk.

## **Menerapkan Efek Refleksi**

Untuk menerapkan efek refleksi di Aspose.Slides for Python via .NET, Anda dapat menambahkan refleksi seperti cermin pada bentuk, menyesuaikan parameter seperti jarak, transparansi, dan ukuran. Efek ini meningkatkan estetika presentasi Anda dengan memberikan bentuk tampilan yang lebih halus dan elegan. Implementasinya mudah dengan kode sederhana, memungkinkan penerapan cepat pada banyak elemen untuk desain yang konsisten.

Python ini menunjukkan cara menerapkan [efek refleksi](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) pada sebuah bentuk:

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

## **Menerapkan Efek Sinar**

Untuk menerapkan efek sinar pada sebuah bentuk di Aspose.Slides for Python via .NET, Anda dapat menambahkan aura lembut dan bercahaya di sekitar bentuk, menyesuaikan properti seperti warna dan ukuran. Efek ini membantu bentuk menonjol dan menambahkan elemen visual yang menarik pada presentasi Anda. Implementasinya mudah dengan sedikit kode, meningkatkan tampilan keseluruhan slide Anda.

Python ini menunjukkan cara menerapkan [efek sinar](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) pada sebuah bentuk:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_glow_effect()
    shape.effect_format.glow_effect.color.color = draw.Color.magenta
    shape.effect_format.glow_effect.radius = 15

    presentation.save("glow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Efek sinar](glow_effect.png)

## **Menerapkan Efek Tepi Halus**

Untuk menerapkan efek tepi halus di Aspose.Slides for Python via .NET, Anda dapat membuat transisi halus dan terblur di sekitar tepi bentuk. Efek ini menambah kesan lebih halus dan terperinci, cocok untuk desain yang membutuhkan tampilan lembut. Anda dapat dengan mudah menyesuaikan parameter seperti radius untuk mencapai efek yang diinginkan pada berbagai bentuk dalam presentasi Anda.

Python ini menunjukkan cara menerapkan [tepi halus](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) pada sebuah bentuk:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)
    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 8

    presentation.save("soft_edges_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Efek tepi halus](soft_edges_effect.png)

## **FAQ**

**Bisakah saya menerapkan beberapa efek pada bentuk yang sama?**

Ya, Anda dapat menggabungkan efek yang berbeda, seperti bayangan, refleksi, dan sinar, pada satu bentuk untuk menciptakan tampilan yang lebih dinamis.

**Bentuk apa yang dapat saya terapkan efek?**

Anda dapat menerapkan efek pada berbagai bentuk, termasuk autoshape, bagan, tabel, gambar, objek SmartArt, objek OLE, dan lainnya.

**Bisakah saya menerapkan efek pada bentuk yang dikelompokkan?**

Ya, Anda dapat menerapkan efek pada bentuk yang dikelompokkan. Efek tersebut akan diterapkan pada seluruh grup.