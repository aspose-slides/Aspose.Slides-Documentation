---
title: Menerapkan Efek Bentuk dalam Presentasi dengan Python
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

Sementara efek di PowerPoint dapat digunakan untuk membuat sebuah bentuk menonjol, mereka berbeda dari [isi](/slides/id/python-net/shape-formatting/#gradient-fill) atau garis tepi. Dengan menggunakan efek PowerPoint, Anda dapat membuat refleksi yang meyakinkan pada sebuah bentuk, menyebarkan cahaya pada bentuk, dll.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint menyediakan enam efek yang dapat diterapkan pada bentuk. Anda dapat menerapkan satu atau lebih efek pada sebuah bentuk. 

* Beberapa kombinasi efek terlihat lebih baik daripada yang lain. Karena itu, PowerPoint memiliki pilihan di bawah **Preset**. Opsi Preset pada dasarnya merupakan kombinasi dua atau lebih efek yang diketahui terlihat bagus. Dengan cara ini, dengan memilih preset, Anda tidak perlu membuang waktu menguji atau menggabungkan efek yang berbeda untuk menemukan kombinasi yang baik.

Aspose.Slides menyediakan properti dan metode di bawah kelas [EffectFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/effectformat/) yang memungkinkan Anda menerapkan efek yang sama pada bentuk dalam presentasi PowerPoint.

## **Terapkan Efek Bayangan**

Kode Python ini menunjukkan cara menerapkan efek bayangan luar (`outer_shadow_effect`) pada sebuah persegi panjang:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_outer_shadow_effect()
    shape.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.dark_gray
    shape.effect_format.outer_shadow_effect.distance = 10
    shape.effect_format.outer_shadow_effect.direction = 45

    pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Terapkan Efek Refleksi**

Kode Python ini menunjukkan cara menerapkan efek refleksi pada sebuah bentuk:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_reflection_effect()
    shape.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM
    shape.effect_format.reflection_effect.direction = 90
    shape.effect_format.reflection_effect.distance = 55
    shape.effect_format.reflection_effect.blur_radius = 4

    pres.save("reflection.pptx", slides.export.SaveFormat.PPTX)
```

## **Terapkan Efek Glow**

Kode Python ini menunjukkan cara menerapkan efek glow pada sebuah bentuk:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_glow_effect()
    shape.effect_format.glow_effect.color.color = draw.Color.magenta
    shape.effect_format.glow_effect.radius = 15

    pres.save("glow.pptx", slides.export.SaveFormat.PPTX)
```

## **Terapkan Efek Tepi Lembut**

Kode Python ini menunjukkan cara menerapkan tepi lembut pada sebuah bentuk:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 15

    pres.save("softEdges.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Apakah saya dapat menerapkan beberapa efek pada bentuk yang sama?**

Ya, Anda dapat menggabungkan berbagai efek, seperti bayangan, refleksi, dan glow, pada satu bentuk untuk menciptakan tampilan yang lebih dinamis.

**Bentuk apa yang dapat saya terapkan efek?**

Anda dapat menerapkan efek pada berbagai bentuk, termasuk autoshape, grafik, tabel, gambar, objek SmartArt, objek OLE, dan lainnya.

**Apakah saya dapat menerapkan efek pada bentuk yang dikelompokkan?**

Ya, Anda dapat menerapkan efek pada bentuk yang dikelompokkan. Efek tersebut akan diterapkan pada seluruh grup.