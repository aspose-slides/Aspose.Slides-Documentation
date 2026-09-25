---
title: Buat Efek 3D pada Presentasi Menggunakan .NET
linktitle: Presentasi 3D
type: docs
weight: 232
url: /id/net/3d-presentation/
keywords:
- PowerPoint 3D
- presentasi 3D
- rotasi 3D
- kedalaman 3D
- ekstrusi 3D
- gradasi 3D
- teks 3D
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Terapkan dan render efek 3D untuk bentuk dan teks PowerPoint di .NET dengan Aspose.Slides. Konfigurasikan kamera, pencahayaan, material, ekstrusi, isian, dan teks 3D."
---
## **Ringkasan**

Aspose.Slides untuk .NET dapat membuat, mengedit, mempertahankan, dan merender pemformatan 3D gaya PowerPoint untuk bentuk dan teks. Artikel ini mencakup efek 3D seperti rotasi, ekstrusi, bevel, pencahayaan, material, isian gradasi atau gambar, dan teks 3D.

{{% alert color="info" title="Note" %}}
Artikel ini tentang efek pemformatan 3D pada bentuk dan teks PowerPoint. Ini bukan tentang memasukkan atau mengedit file model 3D terpisah. Saat Anda mengekspor slide ke gambar, PDF, atau HTML, Aspose.Slides merender efek 3D tersebut ke dalam output 2D yang diekspor.
{{% /alert %}}

## **Konsep Pemformatan 3D**

Gunakan properti [IShape.ThreeDFormat](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/properties/threedformat) untuk menerapkan pemformatan 3D pada sebuah bentuk. Properti tersebut mengekspos [IThreeDFormat](https://reference.aspose.com/slides/id/net/aspose.slides/ithreedformat), yang mengontrol adegan 3D untuk bentuk tersebut.

Untuk teks, gunakan properti [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/id/net/aspose.slides/itextframeformat/properties/threedformat). Ini menerapkan pemformatan 3D pada bingkai teks, bukan pada badan bentuk.

Properti terpenting adalah:

| Properti | Apa yang dikontrol | Kapan digunakan |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/id/net/aspose.slides/ithreedformat/properties/camera) | Titik pandang, jenis kamera preset, rotasi, zoom, dan perspektif. | Putar objek dalam ruang 3D atau cocokkan dengan preset rotasi 3D PowerPoint. |
| [LightRig](https://reference.aspose.com/slides/id/net/aspose.slides/ithreedformat/properties/lightrig) | Preset cahaya, arah, dan rotasi cahaya. | Ubah cara sorotan dan bayangan muncul pada permukaan 3D. |
| [Material](https://reference.aspose.com/slides/id/net/aspose.slides/ithreedformat/properties/material) | Material permukaan, seperti datar, matte, plastik, atau logam. | Membuat geometri yang sama tampak lebih datar, lebih lembut, mengkilap, atau logam. |
| [ExtrusionHeight](https://reference.aspose.com/slides/id/net/aspose.slides/ithreedformat/properties/extrusionheight) | Seberapa jauh bentuk memperluas ke belakang dari wajah depannya. | Mengubah bentuk datar menjadi objek 3D yang tampak tebal. |
| [ExtrusionColor](https://reference.aspose.com/slides/id/net/aspose.slides/ithreedformat/properties/extrusioncolor) | Warna sisi yang diekstrusi. | Membuat kedalaman terlihat atau menyesuaikan warna sisi dengan isian depan. |
| [Depth](https://reference.aspose.com/slides/id/net/aspose.slides/ithreedformat/properties/depth) | Kedalaman 3D tambahan yang digunakan oleh pemformatan 3D PowerPoint. | Menyetel kedalaman secara halus untuk bentuk atau teks, terutama bersama dengan pengaturan bevel dan material. |
| [BevelTop](https://reference.aspose.com/slides/id/net/aspose.slides/ithreedformat/properties/beveltop) and [BevelBottom](https://reference.aspose.com/slides/id/net/aspose.slides/ithreedformat/properties/bevelbottom) | Tepi yang terangkat atau melengkung pada wajah depan dan belakang. | Menambahkan tepi yang lembut atau dibentuk alih-alih wajah datar yang tajam. |
| [ContourColor](https://reference.aspose.com/slides/id/net/aspose.slides/ithreedformat/properties/contourcolor) and [ContourWidth](https://reference.aspose.com/slides/id/net/aspose.slides/ithreedformat/properties/contourwidth) | Garis tepi di sekitar objek 3D. | Menekankan batas objek dalam output yang dirender. |

## **Buat Bentuk 3D**

Sebuah bentuk biasanya memerlukan empat jenis pengaturan sebelum terlihat meyakinkan sebagai 3D:

- Pengaturan kamera, karena tampilan depan default dapat menyembunyikan ekstrusi.
- Pengaturan cahaya, karena pencahayaan membuat wajah dan sisi dapat dilihat.
- Pengaturan material, karena permukaan memengaruhi cara cahaya dirender.
- Pengaturan ekstrusi atau kedalaman, karena bentuk datar memerlukan ketebalan.

Contoh berikut membuat sebuah persegi panjang, menambahkan teks ke wajah depannya, dan menerapkan pemformatan 3D. Nilai rotasi kamera dalam derajat, dan tinggi ekstrusi adalah 100 poin. Contoh ini merender slide ke gambar PNG dengan ukuran dua kali dimensi defaultnya dan menyimpan presentasi sebagai PPTX.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const float imageScale = 2;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.TextFrame.Text = "3D";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.CornflowerBlue;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Blue;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("shape_3d.png");

presentation.Save("shape_3d.pptx", SaveFormat.Pptx);
```

Gambar slide yang dirender menunjukkan persegi panjang sebagai balok 3D yang tebal:

![Persegi panjang 3D biru yang dirender dengan teks 3D putih pada wajah depan](img_01_01.png)

## **Putar Bentuk dengan Kamera**

Di PowerPoint, rotasi 3D dikonfigurasi dari panel 3‑D Rotation. Nilai rotasi X, Y, dan Z sesuai dengan rotasi yang Anda atur melalui API kamera.

![Panel 3‑D Rotation PowerPoint dengan nilai rotasi X, Y, dan Z disorot](img_02_01.png)

Di Aspose.Slides, akses kamera melalui [IThreeDFormat.Camera](https://reference.aspose.com/slides/id/net/aspose.slides/ithreedformat/properties/camera). Contoh ini membuat sebuah persegi panjang, memilih tampilan depan ortografik, dan mengatur rotasi X, Y, dan Z menjadi 20, 30, dan 40 derajat masing‑masing. Ia mengonfigurasi bentuk di memori tanpa menyimpan file:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

Gunakan kamera ketika Anda perlu mengubah cara penonton melihat objek. Itu tidak mengubah geometri bentuk 2D pada slide. Itu mengubah titik pandang 3D yang digunakan oleh PowerPoint dan oleh Aspose.Slides saat merender.

## **Tambahkan Ekstrusi dan Kedalaman**

Ekstrusi membuat bentuk terlihat tebal dengan memperluasnya ke belakang dari wajah depan. Di PowerPoint, kontrol kedalaman mengatur ketebalan yang terlihat, dan kontrol warna mengatur warna sisi.

![Kontrol kedalaman PowerPoint dipetakan ke properti warna ekstrusi dan tinggi ekstrusi](img_02_02.png)

Atur [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/id/net/aspose.slides/ithreedformat/properties/extrusionheight) untuk ketebalan dan [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/id/net/aspose.slides/ithreedformat/properties/extrusioncolor) untuk warna sisi. Contoh ini memberi persegi panjang ekstrusi 100 poin dengan sisi ungu dan memutar kamera untuk menampilkan ketebalannya. Ia mengonfigurasi bentuk di memori tanpa menyimpan file:

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

[IThreeDFormat.Depth](https://reference.aspose.com/slides/id/net/aspose.slides/ithreedformat/properties/depth) mengatur kedalaman bentuk 3D. Properti [ExtrusionHeight](https://reference.aspose.com/slides/id/net/aspose.slides/ithreedformat/properties/extrusionheight) mengontrol tinggi efek ekstrusi, seperti yang ditunjukkan pada contoh ini.

## **Gunakan Isian Gradien atau Gambar dengan Efek 3D**

Pemformatan 3D independen dari isian bentuk. Anda dapat menerapkan warna padat, gradien, pola, atau isian gambar ke wajah depan dan tetap menggunakan kamera, cahaya, material, serta pengaturan ekstrusi yang sama.

Contoh ini menerapkan gradien biru‑ke‑oranye ke wajah depan dan warna oranye gelap ke ekstrusi 150 poin. Henti gradien pada 0 dan 100 menandai awal dan akhir gradien. Nilai rotasi kamera dalam derajat. Slide dirender ke gambar PNG dengan ukuran dua kali dimensi defaultnya:

```csharp
using System.Drawing;
using Aspose.Slides;

const float imageScale = 2;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
shape.TextFrame.Text = "3D Gradient";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

shape.FillFormat.FillType = FillType.Gradient;
shape.FillFormat.GradientFormat.GradientStops.Add(0, Color.Blue);
shape.FillFormat.GradientFormat.GradientStops.Add(100, Color.Orange);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("gradient_3d.png");
```

Gambar yang dirender mempertahankan gradien pada wajah depan dan merender ekstrusi secara terpisah:

![Persegi panjang 3D yang dirender dengan isian gradien biru‑ke‑oranye dan ekstrusi oranye](img_02_03.png)

Untuk menggunakan isian gambar, tambahkan gambar ke presentasi dan tetapkan ke isian bentuk. Contoh ini memerlukan file yang sudah ada bernama "image.jpg" di direktori kerja. Ia memperluas gambar untuk mengisi persegi panjang, menerapkan ekstrusi 150 poin, dan mengatur rotasi kamera dalam derajat. Ia mengonfigurasi bentuk di memori tanpa menyimpan atau merender file:

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

var imageData = File.ReadAllBytes("image.jpg");
var image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
```

Gambar dirender pada wajah depan, sementara ekstrusi dirender sebagai permukaan sisi 3D:

![Persegi panjang 3D yang dirender dengan isian foto pada wajah depan dan ekstrusi oranye](img_02_04.png)

## **Terapkan Pemformatan 3D ke Teks**

Pemformatan 3D pada bentuk memengaruhi badan bentuk. Pemformatan 3D pada teks memengaruhi bingkai teks. Ini berguna untuk efek mirip WordArt di mana huruf‑hurufnya sendiri memerlukan ekstrusi, material, pencahayaan, dan pengaturan kamera.

Contoh berikut membuat teks dengan pola kisi oranye‑dan‑putih, menerapkan lengkungan ke atas, dan mengonfigurasi pengaturan 3D melalui [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/id/net/aspose.slides/itextframeformat/properties/threedformat). Tinggi ekstrusi dan kedalaman dalam poin, dan rotasi cahaya dalam derajat. Isian bentuk dan garis luar disembunyikan sehingga hanya teks yang terlihat. Contoh ini merender gambar PNG dengan ukuran dua kali dimensi slide default dan menyimpan presentasi sebagai PPTX:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const float imageScale = 2;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Text = "3D Text";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.LargeGrid;

shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 128;

var textFrameFormat = shape.TextFrame.TextFrameFormat;
textFrameFormat.Transform = TextShapeType.ArchUp;
textFrameFormat.ThreeDFormat.ExtrusionHeight = 3.5f;
textFrameFormat.ThreeDFormat.Depth = 3;
textFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;
textFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
textFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
textFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);
textFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("text_3d.png");

presentation.Save("text_3d.pptx", SaveFormat.Pptx);
```

Teks dirender sebagai huruf 3D melengkung dan diekstrusi:

![Teks 3D yang dirender dengan transformasi WordArt melengkung, isian pola oranye, dan ekstrusi gelap](img_02_05.png)

## **Jaga Teks Tetap Datar pada Bentuk 3D**

Untuk menjaga teks tetap terbaca sambil mempertahankan tampilan 3D bentuk, atur [ITextFrameFormat.KeepTextFlat](https://reference.aspose.com/slides/id/net/aspose.slides/itextframeformat/keeptextflat/) lewat [ITextFrame.TextFrameFormat](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/textframeformat/). Ketika nilai `true`, teks berada di luar adegan 3D. Ketika `false`, teks berpartisipasi dalam adegan dan mengikuti orientasi 3D.

Pengaturan ini tidak menghapus pemformatan 3D bentuk: kamera, pencahayaan, material, dan ekstrusinya tetap dikonfigurasi melalui [IShape.ThreeDFormat](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/threedformat/). Ini juga berbeda dari rotasi biasa. [IShape.Rotation](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/rotation/) memutar bentuk dalam bidang slide, sementara [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/id/net/aspose.slides/itextframeformat/rotationangle/) mengontrol rotasi khusus teks dalam kotak pembatasnya. Menjaga teks di luar adegan 3D tidak mengatur ulang kedua sudut tersebut.

Contoh mandiri berikut membuat persegi panjang biru dengan teks dan menggandakannya di samping yang asli. Kedua bentuk memiliki pemformatan 3D yang sama; hanya pengaturan teks yang berbeda: `false` di kiri dan `true` di kanan. Sudut kamera dalam derajat, dan tinggi ekstrusi 40 poin. Contoh ini menyimpan presentasi sebagai PPTX dan merender slide perbandingan ke PNG dengan ukuran dua kali dimensi defaultnya.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

shape.TextFrame.Text = "Readable text";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 28;
shape.TextFrame.Paragraphs[0].ParagraphFormat.Alignment = TextAlignment.Center;
shape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Center;
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.CornflowerBlue;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(30, 30, 0);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 40;
shape.ThreeDFormat.ExtrusionColor.Color = Color.RoyalBlue;
shape.TextFrame.TextFrameFormat.KeepTextFlat = false;

var flatTextShape = (IAutoShape)slide.Shapes.AddClone(shape, 400, 160);
flatTextShape.TextFrame.TextFrameFormat.KeepTextFlat = true;

presentation.Save("keep_text_flat.pptx", SaveFormat.Pptx);
using var image = slide.GetImage(2, 2);
image.Save("keep_text_flat.png");
```

![Dua persegi panjang 3D berdampingan: KeepTextFlat false di kiri dan true di kanan](keep_text_flat.png)

## **Perilaku Ekspor dan Rendering**

Aspose.Slides mempertahankan pemformatan 3D saat menyimpan ke format PowerPoint seperti PPTX. Saat merender atau mengekspor ke format tata letak tetap, adegan 3D dirasterisasi atau digambar ke dalam output sebagai hasil 2D. Hal ini berlaku ketika Anda merender slide ke [PNG](/slides/id/net/convert-powerpoint-to-png/), mengekspor ke [PDF](/slides/id/net/convert-powerpoint-to-pdf/), mengekspor ke [HTML](/slides/id/net/convert-powerpoint-to-html/), atau menghasilkan bingkai untuk [konversi video](/slides/id/net/convert-powerpoint-to-video/).

Ingat poin-poin berikut:

- Gambar dan PDF yang diekspor tidak interaktif. Objek tidak dapat diputar oleh penonton setelah diekspor.
- Penampilan akhir tergantung pada kombinasi kamera, light rig, material, ekstrusi, isian, dan skala slide.
- Jika Anda perlu memeriksa nilai format yang diwariskan atau berbasis tema, baca [properti bentuk efektif](/slides/id/net/shape-effective-properties/).
- Beberapa format output tidak dapat menyimpan pemformatan 3D PowerPoint yang dapat diedit. Pada format tersebut, hasil visual dirender alih‑alih disimpan sebagai pengaturan 3D yang dapat diedit.

## **FAQ**

**Apakah Aspose.Slides dapat membuat presentasi 3D interaktif?**

Aspose.Slides membuat dan merender efek 3D PowerPoint untuk bentuk dan teks. Ia tidak menjadikan gambar, PDF, atau halaman HTML yang diekspor menjadi adegan 3D interaktif yang dapat diputar oleh penonton. Pada PPTX, pemformatan 3D tetap dapat diedit di PowerPoint bila formatnya mendukungnya.

**Apa perbedaan antara model 3D dan efek 3D?**

Model 3D adalah objek 3D terpisah yang dimasukkan ke dalam presentasi. Efek 3D adalah format yang diterapkan pada bentuk atau teks PowerPoint biasa, seperti rotasi, ekstrusi, bevel, pencahayaan, dan material. Artikel ini membahas efek 3D.

**Pengaturan apa yang diperlukan untuk bentuk 3D yang terlihat?**

Setidaknya, atur rotasi kamera dan ekstrusi atau kedalaman. Praktiknya, juga atur light rig dan material agar wajah yang dirender memiliki sorotan dan bayangan yang jelas.

**Bisakah saya menerapkan efek 3D pada bentuk dan teks?**

Ya. Gunakan [IShape.ThreeDFormat](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/properties/threedformat) untuk badan bentuk dan [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/id/net/aspose.slides/itextframeformat/properties/threedformat) untuk teks.

**Apakah efek 3D akan muncul saat mengekspor ke gambar, PDF, HTML, atau bingkai video?**

Ya. Aspose.Slides merender efek 3D saat menghasilkan gambar slide, output PDF, output HTML, dan bingkai yang digunakan untuk konversi video. Output yang diekspor berisi tampilan yang dirender, bukan objek 3D yang dapat diedit.

**Bisakah saya membaca nilai 3D akhir setelah warisan dan pengaturan tema diterapkan?**

Ya. Gunakan API pemformatan efektif yang dijelaskan dalam [Shape Effective Properties](/slides/id/net/shape-effective-properties/) untuk membaca kamera, light rig, bevel, dan nilai 3D terkait yang final.