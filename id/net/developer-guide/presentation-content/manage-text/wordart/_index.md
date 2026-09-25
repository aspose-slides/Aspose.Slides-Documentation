---
title: Buat dan Terapkan Efek WordArt di .NET
linktitle: WordArt
type: docs
weight: 110
url: /id/net/wordart/
keywords:
- WordArt
- buat WordArt
- templat WordArt
- efek WordArt
- efek bayangan
- efek refleksi
- efek cahaya bersinar
- transformasi WordArt
- efek 3D
- efek bayangan luar
- efek bayangan dalam
- .NET
- C#
- Aspose.Slides
description: "Buat dan sesuaikan efek WordArt di Aspose.Slides untuk .NET. Panduan langkah demi langkah ini membantu pengembang meningkatkan presentasi dengan teks profesional dalam C#."
---
## **Overview**

Efek WordArt memungkinkan Anda memberi gaya pada teks dengan isi, garis luar, bayangan, refleksi, cahaya bersinar, transformasi, dan pemformatan 3D. Artikel ini menjelaskan cara membuat dan menyesuaikan efek-efek ini dalam presentasi PowerPoint menggunakan Aspose.Slides untuk .NET, tanpa perlu menginstal Microsoft Office.

## **Create a Simple WordArt Template and Apply It to Text**

Contoh-contoh berikut membuat gaya WordArt sederhana dengan mengatur teks, font, pola isi, dan garis luar.

Setiap contoh membuat presentasi baru dan menambahkan persegi panjang ke slide pertama; tidak diperlukan file input. Contoh pertama mengatur teks menjadi "Aspose.Slides". Posisi dan dimensi bentuk diukur dalam poin:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
var textFrame = autoShape.TextFrame;

var portion = textFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
```

Atur font menjadi Arial Black dengan ukuran 36 poin agar pemformatan lebih terlihat:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;
```

Terapkan pola [SmallGrid](https://reference.aspose.com/slides/id/net/aspose.slides/patternstyle/) dengan latar depan oranye tua dan latar belakang putih, lalu tambahkan garis luar teks berwarna hitam dengan lebar 1 poin:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;

portion.PortionFormat.LineFormat.Width = 1;
portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
```

Teks yang dihasilkan:

![Template WordArt sederhana](WordArt_template.png)

## **Apply Other WordArt Effects**

Contoh-contoh berikut menunjukkan cara menerapkan bayangan, refleksi, cahaya bersinar, transformasi, dan efek 3D ke teks.

### **Apply Outer Shadow Effects**

Bayangan luar menambahkan kedalaman dengan menempatkan bayangan di belakang teks. Anda dapat menyesuaikan warna, arah, jarak, radius blur, skala, dan skew‑nya.

Contoh ini memanggil [EnableOuterShadowEffect](https://reference.aspose.com/slides/id/net/aspose.slides/effectformat/enableoutershadoweffect/) dan mengatur bayangan hitam dengan radius blur 4 poin, arah 230 derajat, dan jarak 30 poin. Nilai skala 100 mempertahankan ukuran bayangan, sementara skew horizontal memiringkannya 20 derajat. Transformasi alpha mengatur opacity menjadi 32%:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.EffectFormat.EnableOuterShadowEffect();
portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.Black;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleHorizontal = 100;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleVertical = 100;
portion.PortionFormat.EffectFormat.OuterShadowEffect.BlurRadius = 4;
portion.PortionFormat.EffectFormat.OuterShadowEffect.Direction = 230;
portion.PortionFormat.EffectFormat.OuterShadowEffect.Distance = 30;
portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewHorizontal = 20;
portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewVertical = 0;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.32f);
```

Teks yang dihasilkan:

![Efek Bayangan Luar](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Ketika bayangan luar dan bayangan preset digunakan bersamaan, hanya bayangan luar yang diterapkan.
- Jika bayangan luar dan dalam digunakan secara simultan, efek yang dihasilkan tergantung pada versi PowerPoint. Misalnya, di PowerPoint 2013 efeknya menjadi dua kali lipat, sedangkan di PowerPoint 2007 hanya bayangan luar yang diterapkan.
{{% /alert %}}

### **Apply Reflection Effects**

Refleksi membuat salinan cermin dari teks. Sesuaikan posisi, skala, blur, dan opacity untuk mengontrol tampilannya.

Contoh ini memanggil [EnableReflectionEffect](https://reference.aspose.com/slides/id/net/aspose.slides/effectformat/enablereflectioneffect/) dan membalik refleksi secara vertikal dengan skala -100%. Ia menggunakan radius blur 0,5 poin dan jarak 4,72 poin. Opacity menurun dari 60% menjadi 0,9% antara posisi 0% dan 60% sepanjang refleksi:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.EffectFormat.EnableReflectionEffect();
portion.PortionFormat.EffectFormat.ReflectionEffect.BlurRadius = 0.5;
portion.PortionFormat.EffectFormat.ReflectionEffect.Distance = 4.72;
portion.PortionFormat.EffectFormat.ReflectionEffect.StartPosAlpha = 0f;
portion.PortionFormat.EffectFormat.ReflectionEffect.EndPosAlpha = 60f;
portion.PortionFormat.EffectFormat.ReflectionEffect.Direction = 90;
portion.PortionFormat.EffectFormat.ReflectionEffect.ScaleHorizontal = 100;
portion.PortionFormat.EffectFormat.ReflectionEffect.ScaleVertical = -100;
portion.PortionFormat.EffectFormat.ReflectionEffect.StartReflectionOpacity = 60f;
portion.PortionFormat.EffectFormat.ReflectionEffect.EndReflectionOpacity = 0.9f;
portion.PortionFormat.EffectFormat.ReflectionEffect.RectangleAlign = RectangleAlignment.BottomLeft;
```

Teks yang dihasilkan:

![Efek Refleksi](reflection_effect.png)

### **Apply Glow Effects**

Cahaya bersinar menambahkan garis luar berwarna lembut di sekitar teks. Sesuaikan warna, opacity, dan radius untuk mengontrol efeknya.

Contoh ini memanggil [EnableGlowEffect](https://reference.aspose.com/slides/id/net/aspose.slides/effectformat/enablegloweffect/) dan menerapkan cahaya bersinar merah dengan opacity 54% dan radius 7 poin:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.EffectFormat.EnableGlowEffect();
portion.PortionFormat.EffectFormat.GlowEffect.Color.Color = System.Drawing.Color.Red;
portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
```

Teks yang dihasilkan:

![Efek Cahaya Bersinar](glow_effect.png)

### **Apply WordArt Transformations**

Transformasi WordArt melengkungkan, meregangkan, atau memelintir blok teks.

Atur [Transform](https://reference.aspose.com/slides/id/net/aspose.slides/textframeformat/transform/) ke [ArchUpPour](https://reference.aspose.com/slides/id/net/aspose.slides/textshapetype/) untuk melengkungkan seluruh bingkai teks ke atas:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var textFrame = autoShape.TextFrame;
textFrame.Text = "Aspose.Slides";
textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
```

Teks yang dihasilkan:

![Transformasi WordArt](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides untuk .NET menyediakan sekumpulan [tipe transformasi](https://reference.aspose.com/slides/id/net/aspose.slides/textshapetype/) yang telah ditentukan.
{{% /alert %}}

### **Apply 3D Effects to Shapes and Text**

Anda dapat menerapkan efek 3D pada bentuk atau pada teksnya. Bevel, ekstrusi, pencahayaan, dan pengaturan kamera mengontrol tampilan akhir.

Contoh berikut menggunakan [ThreeDFormat](https://reference.aspose.com/slides/id/net/aspose.slides/threedformat/) untuk menambahkan bevel melingkar, ekstrusi oranye, dan kontur merah tua pada persegi panjang. Dimensi bevel, tinggi ekstrusi, lebar kontur, dan kedalaman diukur dalam poin. Material plastik, pencahayaan seimbang diputar 40 derajat di sekitar sumbu Z, dan kamera perspektif menentukan penampilannya:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
autoShape.TextFrame.Text = "Aspose.Slides";

autoShape.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
autoShape.ThreeDFormat.BevelBottom.Height = 10.5;
autoShape.ThreeDFormat.BevelBottom.Width = 10.5;

autoShape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
autoShape.ThreeDFormat.BevelTop.Height = 12.5;
autoShape.ThreeDFormat.BevelTop.Width = 11;

autoShape.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
autoShape.ThreeDFormat.ExtrusionHeight = 6;

autoShape.ThreeDFormat.ContourColor.Color = Color.DarkRed;
autoShape.ThreeDFormat.ContourWidth = 1.5;

autoShape.ThreeDFormat.Depth = 3;

autoShape.ThreeDFormat.Material = MaterialPresetType.Plastic;

autoShape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
autoShape.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
```

Bentuk yang dihasilkan:

![Efek 3D Bentuk](shape_3D_effect.png)

Contoh ini menerapkan pemformatan 3D serupa pada teks melalui [TextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/id/net/aspose.slides/textframeformat/threedformat/). Bevel yang lebih kecil membentuk tepi huruf, sementara ekstrusi dan pencahayaan memberi kedalaman pada teks:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
var textFrame = autoShape.TextFrame;
textFrame.Text = "Aspose.Slides";

textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Height = 3.5;
textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Width = 3.5;

textFrame.TextFrameFormat.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Height = 4;
textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Width = 4;

textFrame.TextFrameFormat.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
textFrame.TextFrameFormat.ThreeDFormat.ExtrusionHeight = 6;

textFrame.TextFrameFormat.ThreeDFormat.ContourColor.Color = Color.DarkRed;
textFrame.TextFrameFormat.ThreeDFormat.ContourWidth = 1.5;

textFrame.TextFrameFormat.ThreeDFormat.Depth = 3;

textFrame.TextFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;

textFrame.TextFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
textFrame.TextFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
textFrame.TextFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

textFrame.TextFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
```

Teks yang dihasilkan:

![Efek 3D Teks](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
Penerapan efek 3D pada teks atau bentuknya—dan interaksi antar efek tersebut—diatur oleh aturan khusus. Pertimbangkan sebuah adegan yang melibatkan teks dan bentuk yang menampungnya. Efek 3D mencakup representasi 3D objek dan adegan tempat objek tersebut ditempatkan.

- Jika adegan ditetapkan untuk baik bentuk maupun teks, adegan bentuk memiliki prioritas dan adegan teks diabaikan.
- Jika bentuk tidak memiliki adegan sendiri tetapi memiliki representasi 3D, adegan teks yang digunakan.
- Jika bentuk tidak memiliki efek 3D sama sekali, ia diperlakukan sebagai datar, dan efek 3D hanya diterapkan pada teks.

Perilaku ini berhubungan dengan properti [ThreeDFormat.LightRig](https://reference.aspose.com/slides/id/net/aspose.slides/threedformat/lightrig/) dan [ThreeDFormat.Camera](https://reference.aspose.com/slides/id/net/aspose.slides/threedformat/camera/).
{{% /alert %}}

Untuk menjaga teks tetap datar dan mudah dibaca sambil mempertahankan pemformatan 3D bentuk, lihat [Keep Text Flat on a 3D Shape](/slides/id/net/3d-presentation/) untuk perbandingan kedua pengaturan dan contoh lengkap C#.

## **FAQ**

**Apakah saya dapat menggunakan efek WordArt dengan font atau skrip berbeda (misalnya Arab, Cina)?**

Ya, Aspose.Slides untuk .NET mendukung Unicode dan berfungsi dengan semua font dan skrip utama. Efek WordArt seperti bayangan, isi, dan garis luar dapat diterapkan terlepas dari bahasa, meskipun ketersediaan font dan rendering dapat bergantung pada font sistem.

**Apakah saya dapat menerapkan efek WordArt pada elemen master slide?**

Ya, Anda dapat menerapkan efek WordArt pada bentuk di slide master, termasuk placeholder judul, footer, atau teks latar belakang. Perubahan pada tata letak master akan tercermin pada semua slide yang terkait.

**Apakah efek WordArt memengaruhi ukuran file presentasi?**

Sedikit. Efek WordArt seperti bayangan, cahaya bersinar, dan isi gradien dapat sedikit menambah ukuran file karena metadata pemformatan tambahan, tetapi perbedaannya biasanya tidak signifikan.

**Apakah saya dapat melihat pratinjau hasil efek WordArt tanpa menyimpan presentasi?**

Ya, Anda dapat merender slide yang berisi WordArt menjadi gambar (misalnya PNG, JPEG) menggunakan [ISlide.GetImage](https://reference.aspose.com/slides/id/net/aspose.slides/islide/getimage/), atau merender bentuk individual menggunakan [IShape.GetImage](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/getimage/). Ini memungkinkan Anda melihat pratinjau hasil di memori atau di layar sebelum menyimpan atau mengekspor presentasi secara keseluruhan.