---
title: Terapkan Efek Bentuk dalam Presentasi di .NET
linktitle: Efek Bentuk
type: docs
weight: 30
url: /id/net/shape-effect/
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
description: "Ubah file PPT dan PPTX Anda dengan efek bentuk lanjutan menggunakan Aspose.Slides untuk .NET—buat slide yang menarik dan profesional dalam hitungan detik."
---
## **Pendahuluan**

Sementara efek di PowerPoint dapat digunakan untuk menonjolkan sebuah bentuk, mereka berbeda dari [isian](/slides/id/net/shape-formatting/#gradient-fill) atau outline. Dengan menggunakan efek PowerPoint, Anda dapat membuat refleksi yang meyakinkan pada sebuah bentuk, menyebarkan cahaya bentuk, dll.

![Efek Bentuk](shape-effect.png)

PowerPoint menyediakan enam efek yang dapat diterapkan pada bentuk. Anda dapat menerapkan satu atau beberapa efek pada sebuah bentuk.

Beberapa kombinasi efek terlihat lebih baik daripada yang lain. Karena itu, PowerPoint memiliki opsi di bawah **Preset**. Opsi Preset pada dasarnya merupakan kombinasi yang sudah terbukti bagus dari dua atau lebih efek. Dengan cara ini, dengan memilih preset, Anda tidak perlu membuang waktu menguji atau menggabungkan efek yang berbeda untuk menemukan kombinasi yang tepat.

Aspose.Slides menyediakan properti dan metode di bawah kelas [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) yang memungkinkan Anda menerapkan efek yang sama pada bentuk dalam presentasi PowerPoint.

## **Menerapkan Efek Bayangan**

Aspose.Slides untuk .NET mendukung bayangan luar dan dalam untuk bentuk. Anda dapat menyesuaikan warna, arah, jarak, dan radius blur mereka agar sesuai dengan desain presentasi Anda.

### **Menerapkan Bayangan Luar**

Gunakan bayangan luar untuk membuat kartu atau panel menonjol di atas latar belakang slide. Bayangan meluas di luar tepi bentuk, menciptakan kesan bahwa bentuk tersebut terangkat di atas slide. Sesuaikan warna, arah, jarak, dan radius blur‑nya agar cocok dengan pencahayaan dan gaya templat Anda.

Kode C# berikut menunjukkan cara menerapkan [efek bayangan luar](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) pada sebuah persegi panjang:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
shape.EffectFormat.EnableOuterShadowEffect();
shape.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.DarkGray;
shape.EffectFormat.OuterShadowEffect.Distance = 10;
shape.EffectFormat.OuterShadowEffect.Direction = 45;

presentation.Save("shadow_effect.pptx", SaveFormat.Pptx);
```

![Efek Bayangan](shadow_effect.png)

### **Menerapkan Bayangan Dalam**

Saat mereproduksi gaya visual templat, gunakan bayangan dalam untuk memberi kartu atau panel tampilan tercekik. Bayangan luar memperluas di luar bentuk dan membuatnya tampak terangkat, sedangkan bayangan dalam memberi bayangan pada bagian dalam tepinya.

Panggil [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/), kemudian konfigurasikan [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/). Nilai yang lebih besar menghasilkan tepi yang lebih lembut.

Kode C# berikut membuat kartu biru muda dengan bayangan dalam abu‑abu gelap dan menyimpannya sebagai file PPTX:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.LightBlue;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;

shape.EffectFormat.EnableInnerShadowEffect();
var shadow = shape.EffectFormat.InnerShadowEffect;
shadow.ShadowColor.Color = Color.DimGray;
shadow.Direction = 225;
shadow.Distance = 7;
shadow.BlurRadius = 6;

presentation.Save("inner_shadow_effect.pptx", SaveFormat.Pptx);
```

![Persegi panjang biru muda dengan bayangan dalam](inner_shadow_effect.png)

Untuk menghapus bayangan dalam, panggil [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) pada format efek bentuk.

## **Menerapkan Efek Refleksi**

Untuk menerapkan efek refleksi di Aspose.Slides untuk .NET, Anda dapat menambahkan refleksi seperti cermin pada bentuk, menyesuaikan parameter seperti jarak, transparansi, dan ukuran. Efek ini meningkatkan estetika presentasi Anda dengan memberikan bentuk tampilan yang lebih halus dan canggih. Mudah diimplementasikan dengan kode sederhana, memungkinkan penerapan cepat pada banyak elemen untuk desain yang konsisten.

Kode C# berikut menunjukkan cara menerapkan [efek refleksi](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) pada sebuah bentuk:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

![Efek Refleksi](reflection_effect.png)

## **Menerapkan Efek Cahaya**

Untuk menerapkan efek cahaya pada sebuah bentuk di Aspose.Slides untuk .NET, Anda dapat menambahkan aura lembut yang bersinar di sekitar bentuk, menyesuaikan properti seperti warna dan ukuran. Efek ini membantu bentuk menonjol dan menambahkan elemen visual yang menarik pada presentasi Anda. Mudah diimplementasikan dengan kode minimal, meningkatkan tampilan keseluruhan slide Anda.

Kode C# berikut menunjukkan cara menerapkan [efek cahaya](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) pada sebuah bentuk:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
shape.EffectFormat.EnableGlowEffect();
shape.EffectFormat.GlowEffect.Color.Color = Color.Magenta;
shape.EffectFormat.GlowEffect.Radius = 15;

presentation.Save("glow_effect.pptx", SaveFormat.Pptx);
```

![Efek Cahaya](glow_effect.png)

## **Menerapkan Efek Tepi Lembut**

Untuk menerapkan efek tepi lembut di Aspose.Slides untuk .NET, Anda dapat menciptakan transisi halus yang buram di sekitar tepi bentuk. Efek ini menambah tampilan yang lebih halus dan halus, cocok untuk desain yang memerlukan penampilan yang lembut. Anda dapat dengan mudah menyesuaikan parameter seperti radius untuk mencapai efek yang diinginkan pada berbagai bentuk dalam presentasi Anda.

Kode C# berikut menunjukkan cara menerapkan [tepi lembut](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) pada sebuah bentuk:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
shape.EffectFormat.EnableSoftEdgeEffect();
shape.EffectFormat.SoftEdgeEffect.Radius = 8;

presentation.Save("soft_edges_effect.pptx", SaveFormat.Pptx);
```

![Efek Tepi Lembut](soft_edges_effect.png)

## **Menerapkan Efek Blur**

Gunakan blur bentuk untuk melunakkan isi dan outline bentuk sambil tetap dapat mengedit bentuk. Panggil [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) pada format efek bentuk. Radius diukur dalam poin (1/72 inci): gunakan nilai non‑negatif, dengan nilai yang lebih besar menghasilkan blur yang lebih kuat. Radius nol tidak mengubah tampilan.

Pengaturan [Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) mengontrol batas tampak efek. Dengan `false`, blur dipotong pada batas asli yang digambar, termasuk outline. Dengan `true`, blur dapat meluas melampaui batas tersebut. Kedua pengaturan tidak mengubah posisi atau dimensi bentuk.

Perbandingan di bawah menggunakan isi, outline, dan dimensi bentuk yang sama sepanjang contoh. Baris atas menggunakan `grow = false`; baris bawah menggunakan `grow = true`.

![Persegi panjang asli dibandingkan dengan radius blur 5 dan 15 poin, dengan grow dinonaktifkan dan diaktifkan](shape_blur_comparison.png)

Contoh C# berikut membuat persegi panjang oranye dengan outline biru gelap, menerapkan blur 5‑poin, lalu memperbaruinya menjadi blur 15‑poin dengan memanggil [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) lagi. Kedua keadaan blur disimpan, kemudian memanggil [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/) dan menyimpan bentuk tanpa blur.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
shape.LineFormat.Width = 8;

shape.EffectFormat.SetBlurEffect(5, false);
presentation.Save("shape_blur_5.pptx", SaveFormat.Pptx);

shape.EffectFormat.SetBlurEffect(15, true);
presentation.Save("shape_blur_15.pptx", SaveFormat.Pptx);

shape.EffectFormat.DisableBlurEffect();
presentation.Save("shape_blur_removed.pptx", SaveFormat.Pptx);
```

Blur bentuk memengaruhi isi dan outline bersama‑sama. Efek tepi lembut memudarkan tepi bentuk, sementara blur bayangan melunakkan hanya bayangan. Efek transformasi gambar beroperasi pada konten gambar; contoh ini menerapkan blur langsung pada format efek bentuk tanpa mengonversi bentuk menjadi gambar.

## **FAQ**

**Bisakah saya menerapkan beberapa efek pada bentuk yang sama?**

Ya, Anda dapat menggabungkan berbagai efek, seperti bayangan, refleksi, dan cahaya, pada satu bentuk untuk menciptakan tampilan yang lebih dinamis.

**Bentuk apa yang dapat saya terapkan efek?**

Anda dapat menerapkan efek pada berbagai bentuk, termasuk autoshape, diagram, tabel, gambar, objek SmartArt, objek OLE, dan lainnya.

**Bisakah saya menerapkan efek pada bentuk yang dikelompokkan?**

Ya, Anda dapat menerapkan efek pada bentuk yang dikelompokkan. Efek akan diterapkan pada seluruh grup.