---
title: Terapkan Efek Bentuk dalam Presentasi di .NET
linktitle: Efek Bentuk
type: docs
weight: 30
url: /id/net/shape-effect
keywords:
- efek bentuk
- efek bayangan
- efek refleksi
- efek cahaya
- efek tepi lembut
- format efek
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Ubah file PPT dan PPTX Anda dengan efek bentuk lanjutan menggunakan Aspose.Slides untuk .NET—buat slide yang mencolok dan profesional dalam hitungan detik."
---
## **Introduction**

Sementara efek di PowerPoint dapat digunakan untuk membuat sebuah bentuk menonjol, efek tersebut berbeda dari [fills](/slides/id/net/shape-formatting/#gradient-fill) atau outline. Dengan menggunakan efek PowerPoint, Anda dapat membuat refleksi yang meyakinkan pada sebuah bentuk, menyebarkan cahaya pada bentuk, dll.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

PowerPoint menyediakan enam efek yang dapat diterapkan pada bentuk. Anda dapat menerapkan satu atau lebih efek pada sebuah bentuk.

Beberapa kombinasi efek terlihat lebih baik daripada yang lain. Karena itu, PowerPoint memiliki opsi di bawah **Preset**. Opsi Preset pada dasarnya adalah kombinasi dua atau lebih efek yang telah terbukti terlihat bagus. Dengan cara ini, dengan memilih preset, Anda tidak perlu membuang waktu untuk menguji atau menggabungkan efek yang berbeda demi menemukan kombinasi yang tepat.

Aspose.Slides menyediakan properti dan metode di bawah kelas [EffectFormat](https://reference.aspose.com/slides/id/net/aspose.slides/effectformat/) yang memungkinkan Anda menerapkan efek yang sama pada bentuk dalam presentasi PowerPoint.

## **Apply a Shadow Effect**

Untuk menerapkan efek bayangan pada sebuah bentuk di Aspose.Slides for .NET, Anda dapat dengan mudah menyesuaikan parameter seperti warna, radius blur, dan arah. Hal ini memberikan bentuk Anda penampilan yang lebih dinamis dan profesional, menambahkan kedalaman serta fokus. Dengan menggunakan potongan kode sederhana, Anda dapat menerapkan efek ini pada banyak bentuk, meningkatkan daya tarik visual keseluruhan presentasi Anda.

Kode C# ini menunjukkan cara menerapkan [outer shadow effect](https://reference.aspose.com/slides/id/net/aspose.slides/effectformat/outershadoweffect/) pada sebuah persegi panjang:

```c#
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);

shape.EffectFormat.EnableOuterShadowEffect();
shape.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.DarkGray;
shape.EffectFormat.OuterShadowEffect.Distance = 10;
shape.EffectFormat.OuterShadowEffect.Direction = 45;

presentation.Save("shadow_effect.pptx", SaveFormat.Pptx);
```

![Shadow effect](shadow_effect.png)

## **Apply a Reflection Effect**

Untuk menerapkan efek refleksi di Aspose.Slides for .NET, Anda dapat menambahkan refleksi mirip cermin pada bentuk, menyesuaikan parameter seperti jarak, transparansi, dan ukuran. Efek ini meningkatkan estetika presentasi Anda dengan memberikan bentuk tampilan yang lebih halus dan canggih. Implementasinya mudah dengan kode sederhana, memungkinkan penerapan cepat pada banyak elemen untuk desain yang konsisten.

Kode C# ini menunjukkan cara menerapkan [reflection effect](https://reference.aspose.com/slides/id/net/aspose.slides/effectformat/reflectioneffect/) pada sebuah bentuk:

```c#
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);

shape.EffectFormat.EnableReflectionEffect();
shape.EffectFormat.ReflectionEffect.RectangleAlign = RectangleAlignment.Bottom;
shape.EffectFormat.ReflectionEffect.Direction = 90;
shape.EffectFormat.ReflectionEffect.Distance = 40;
shape.EffectFormat.ReflectionEffect.BlurRadius = 2;

presentation.Save("reflection_effect.pptx", SaveFormat.Pptx);
```

![Reflection effect](reflection_effect.png)

## **Apply a Glow Effect**

Untuk menerapkan efek cahaya pada sebuah bentuk di Aspose.Slides for .NET, Anda dapat menambahkan aura lembut yang bersinar di sekitar bentuk, menyesuaikan properti seperti warna dan ukuran. Efek ini membantu bentuk menonjol dan menambahkan elemen visual yang menarik pada presentasi Anda. Implementasinya mudah dengan kode minimal, meningkatkan tampilan keseluruhan slide Anda.

Kode C# ini menunjukkan cara menerapkan [glow effect](https://reference.aspose.com/slides/id/net/aspose.slides/effectformat/gloweffect/) pada sebuah bentuk:

```c#
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);

shape.EffectFormat.EnableGlowEffect();
shape.EffectFormat.GlowEffect.Color.Color = Color.Magenta;
shape.EffectFormat.GlowEffect.Radius = 15;

presentation.Save("glow_effect.pptx", SaveFormat.Pptx);
```

![Glow effect](glow_effect.png)

## **Apply a Soft Edges Effect**

Untuk menerapkan efek tepi lembut di Aspose.Slides for .NET, Anda dapat menciptakan transisi halus yang kabur di sekitar tepi sebuah bentuk. Efek ini menambahkan kesan yang lebih subtil dan halus, cocok untuk desain yang memerlukan penampilan lembut. Anda dapat dengan mudah menyesuaikan parameter seperti radius untuk mencapai efek yang diinginkan pada berbagai bentuk dalam presentasi Anda.

Kode C# ini menunjukkan cara menerapkan [soft edges](https://reference.aspose.com/slides/id/net/aspose.slides/effectformat/softedgeeffect/) pada sebuah bentuk:

```c#
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

shape.EffectFormat.EnableSoftEdgeEffect();
shape.EffectFormat.SoftEdgeEffect.Radius = 8;

presentation.Save("soft_edges_effect.pptx", SaveFormat.Pptx);
```

![Soft edges effect](soft_edges_effect.png)

## **FAQ**

**Can I apply multiple effects to the same shape?**

Ya, Anda dapat menggabungkan berbagai efek, seperti bayangan, refleksi, dan cahaya, pada satu bentuk untuk menciptakan tampilan yang lebih dinamis.

**What shapes can I apply effects to?**

Anda dapat menerapkan efek pada berbagai bentuk, termasuk autoshape, grafik, tabel, gambar, objek SmartArt, objek OLE, dan lainnya.

**Can I apply effects to grouped shapes?**

Ya, Anda dapat menerapkan efek pada bentuk yang dikelompokkan. Efek akan diterapkan pada seluruh grup.