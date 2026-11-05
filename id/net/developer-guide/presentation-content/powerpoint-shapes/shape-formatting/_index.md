---
title: Format Bentuk PowerPoint dalam .NET
linktitle: Pemformatan Bentuk
type: docs
weight: 20
url: /id/net/shape-formatting/
keywords:
- format bentuk
- format garis
- efek sketsa
- garis bentuk sketsa
- format gaya sambungan
- isian gradien
- isian pola
- isian gambar
- isian tekstur
- isian warna solid
- transparansi bentuk
- rendering bentuk hitam‑putih
- rendering bentuk skala abu‑abu
- putar bentuk
- efek bevel 3D
- efek rotasi 3D
- reset pemformatan
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara memformat bentuk PowerPoint dengan C# menggunakan Aspose.Slides—atur gaya isian, garis, dan efek untuk file PPT dan PPTX dengan presisi dan kontrol penuh."
---
## **Pengantar**

Format bentuk di PowerPoint dengan menyesuaikan garis tepi, isi, dan efeknya. Aspose.Slides untuk .NET memungkinkan Anda mengontrol pengaturan ini secara programatis, termasuk transparansi, rotasi, dan pemformatan 3D.

![Opsi pemformatan bentuk di PowerPoint](format-shape-powerpoint.png)

Aspose.Slides untuk .NET menyediakan antarmuka dan properti yang memungkinkan Anda memformat bentuk dengan menggunakan opsi yang sama tersedia di PowerPoint.

## **Format Garis**

Gunakan [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) untuk mengontrol garis tepi bentuk. Contoh ini membuat persegi panjang tanpa isi dengan garis tepi biru, bergaris putus. [ILineFormat.Style](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/style/) memilih garis gabungan tebal-tipis, sementara [ILineFormat.Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) mengatur lebarnya menjadi 7 poin dan [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) memilih pola garis putus.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.Style = LineStyle.ThickThin;
shape.LineFormat.Width = 7;
shape.LineFormat.DashStyle = LineDashStyle.Dash;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
```

Hasil:
![Garis yang diformat dalam presentasi](formatted-lines.png)

### **Atur Pola Garis Putus Kustom**

Gunakan [ILineFormat.CustomDashPattern](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/customdashpattern/) ketika gaya garis yang telah ditentukan tidak menyediakan panjang dash dan celah yang Anda perlukan, misalnya untuk garis tepi bermerek atau diagram teknis. Menetapkan pola secara otomatis mengatur [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) ke [LineDashStyle.Custom](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/).

Entri array bergantian antara panjang dash dan celah, dimulai dengan dash. Setiap nilai adalah kelipatan lebar garis: `{ 4, 2 }` pada lebar 3 poin menghasilkan dash sepanjang 12 poin diikuti celah 6 poin. Gunakan pasangan nilai terbatas, tidak negatif untuk mendefinisikan segmen dash-dan-celah yang lengkap. Contoh ini menggunakan nilai positif agar setiap dash dan celah terlihat.

Contoh ini membuat lima garis biru dengan panjang yang sama dan ujung datar. Tiga yang pertama membandingkan pola pada lebar 3 poin. Yang keempat mengulangi pola pertama dengan lebar dua kali lipat, menggandakan panjang dash dan celah. Yang kelima beralih dari pola kustom ke garis padat.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(600, 300, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var patterns = new[]
{
    new float[] { 4, 2 },
    new float[] { 1, 2 },
    new float[] { 6, 2, 1, 2 },
    new float[] { 4, 2 },
    new float[] { 4, 2 }
};

for (var i = 0; i < patterns.Length; i++)
{
    var line = slide.Shapes.AddAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0);
    line.LineFormat.Width = i == 3 ? 6 : 3;
    line.LineFormat.FillFormat.FillType = FillType.Solid;
    line.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    line.LineFormat.CapStyle = LineCapStyle.Flat;
    line.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.EndArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.CustomDashPattern = patterns[i];
}

// Kembalikan garis terakhir ke gaya solid.
slide.Shapes[4].LineFormat.DashStyle = LineDashStyle.Solid;

presentation.Save("custom_dash_patterns.pptx", SaveFormat.Pptx);
```

Untuk kembali ke gaya putus yang telah ditentukan, tetapkan [LineDashStyle.Dash](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) ke [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/). Gaya yang dipilih mengontrol tampilan garis.

Hasil di PowerPoint, dari atas ke bawah: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; dan **Solid, 3 pt**.

![Tiga pola dash kustom, garis lebih lebar menggunakan pola pertama, dan garis padat di PowerPoint](custom-dash-patterns.png)

### **Atur Ujung Garis**

Gunakan [ILineFormat.CapStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/capstyle/) untuk mengatur ujung garis terbuka. Enumerasi [LineCapStyle](https://reference.aspose.com/slides/net/aspose.slides/linecapstyle/) menyediakan tiga gaya ujung eksplisit:

- `Flat`: Garis berhenti pada titik akhir.
- `Round`: Ujung setengah lingkaran meluas melampaui titik akhir sebesar setengah lebar garis.
- `Square`: Ujung persegi meluas melampaui titik akhir sebesar setengah lebar garis.

Enumerasi juga mencakup `NotDefined`, yang berarti tidak ada gaya ujung yang ditetapkan secara eksplisit.

Ujung berbeda dari kepala panah, yang menambahkan simbol pada ujung garis, dan sambungan, yang mengontrol sudut antara segmen garis. Contoh ini menonaktifkan kepala panah melalui [ILineFormat.BeginArrowheadStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/beginarrowheadstyle/) dan [ILineFormat.EndArrowheadStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/endarrowheadstyle/) sehingga hanya bentuk ujung yang dibandingkan.

Contoh berikut membuat tiga garis horizontal yang identik, lebar 20 poin. Dari atas ke bawah, mereka menggunakan ujung flat, round, dan square. Titik akhir mereka memiliki koordinat horizontal yang sama; ujung round dan square meluas 10 poin di luar setiap titik akhir.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(500, 240, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var capStyles = new[] { LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square };

for (var i = 0; i < capStyles.Length; i++)
{
    var line = slide.Shapes.AddAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0);
    line.LineFormat.Width = 20;
    line.LineFormat.FillFormat.FillType = FillType.Solid;
    line.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    line.LineFormat.DashStyle = LineDashStyle.Solid;
    line.LineFormat.CapStyle = capStyles[i];
    line.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.EndArrowheadStyle = LineArrowheadStyle.None;
}

presentation.Save("line_caps.pptx", SaveFormat.Pptx);
```

Hasil di PowerPoint, dari atas ke bawah: **Flat**, **Round**, dan **Square**.

![Ujung flat, round, dan square pada garis tebal identik di PowerPoint](line-caps.png)

## **Terapkan Efek Sketsa pada Garis Bentuk**

Efek sketsa membuat garis bentuk terlihat seperti digambar tangan. Gunakan [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) untuk mengakses pengaturan garis, [ILineFormat.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/sketchformat/) untuk mengakses pengaturan sketsa, dan [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) untuk memilih nilai dari enumerasi [LineSketchType](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/).

Kode C# berikut menunjukkan cara menerapkan efek [LineSketchType.Curved](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) , membaca nilai yang ditetapkan secara eksplisit, dan menghapus efek dengan [LineSketchType.None](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/):

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

var sketchFormat = shape.LineFormat.SketchFormat;
sketchFormat.SketchType = LineSketchType.Curved;
var explicitSketchType = sketchFormat.SketchType;
Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
sketchFormat.SketchType = LineSketchType.None;
```

Nilai yang dikembalikan oleh [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) mewakili pengaturan yang ditetapkan langsung pada bentuk. Jika pemformatan garis dapat diwarisi dari tema, slide master, atau slide tata letak, gunakan [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/), akses [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/sketchformat/), dan baca [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformateffectivedata/sketchtype/). Nilai efektif mencerminkan pemformatan yang sebenarnya diterapkan setelah warisan diselesaikan. Contoh ini memerlukan presentasi yang sudah ada dengan setidaknya satu bentuk pada slide pertama dan mencetak kedua nilai:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var shape = presentation.Slides[0].Shapes[0];

var lineFormat = shape.LineFormat;
var explicitSketchType = lineFormat.SketchFormat.SketchType;
var effectiveLineFormat = lineFormat.GetEffective();
var effectiveSketchType = effectiveLineFormat.SketchFormat.SketchType;

Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
Console.WriteLine($"Effective sketch type: {effectiveSketchType}");
```

## **Format Gaya Sambungan**

Berikut tiga opsi tipe sambungan:
* Round
* Miter
* Bevel

Gaya sambungan mengontrol bagaimana dua segmen garis tepi bertemu pada sudut. Gunakan **Round** untuk sudut melengkung, **Miter** untuk sudut tajam, atau **Bevel** untuk sudut rata.

![Gaya sambungan dalam presentasi](join-style-powerpoint.png)

Contoh ini membuat tiga persegi panjang hitam dengan garis tepi biru lebar 15 poin. Ia mengatur [ILineFormat.JoinStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/joinstyle/) ke nilai miter, bevel, dan round dari [LineJoinStyle](https://reference.aspose.com/slides/net/aspose.slides/linejoinstyle/), masing‑masing, untuk membandingkan bagaimana sudut digambar.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var miterShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
var bevelShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
var roundShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

miterShape.FillFormat.FillType = FillType.Solid;
miterShape.FillFormat.SolidFillColor.Color = Color.Black;
bevelShape.FillFormat.FillType = FillType.Solid;
bevelShape.FillFormat.SolidFillColor.Color = Color.Black;
roundShape.FillFormat.FillType = FillType.Solid;
roundShape.FillFormat.SolidFillColor.Color = Color.Black;

miterShape.LineFormat.Width = 15;
bevelShape.LineFormat.Width = 15;
roundShape.LineFormat.Width = 15;

miterShape.LineFormat.FillFormat.FillType = FillType.Solid;
miterShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
bevelShape.LineFormat.FillFormat.FillType = FillType.Solid;
bevelShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
roundShape.LineFormat.FillFormat.FillType = FillType.Solid;
roundShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

miterShape.LineFormat.JoinStyle = LineJoinStyle.Miter;
bevelShape.LineFormat.JoinStyle = LineJoinStyle.Bevel;
roundShape.LineFormat.JoinStyle = LineJoinStyle.Round;

miterShape.TextFrame.Text = "Miter Join Style";
bevelShape.TextFrame.Text = "Bevel Join Style";
roundShape.TextFrame.Text = "Round Join Style";

presentation.Save("join_styles.pptx", SaveFormat.Pptx);
```

### **Batasi Sambungan Miter pada Sudut Tajam**

Gunakan [ILineFormat.MiterLimit](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/miterlimit/) dengan [ILineFormat.JoinStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/joinstyle/) yang diatur ke [LineJoinStyle.Miter](https://reference.aspose.com/slides/net/aspose.slides/linejoinstyle/) untuk membatasi seberapa jauh sudut tajam dapat meluas.

Batas tersebut adalah rasio antara jarak antara sudut dalam dan sudut luar sambungan terhadap lebar garis. Misalnya, nilai `8` mengizinkan panjang miter hingga delapan kali lebar garis; itu bukan ukuran dalam poin. Jika sudut melebihi batas, PowerPoint menggunakan sambungan bevel pada sudut tersebut. Batas yang lebih besar memungkinkan titik yang lebih tajam. Pengaturan ini hanya memengaruhi sambungan miter, dan mengubahnya tidak menghasilkan efek yang terlihat ketika sudut tetap berada dalam kedua batas.

Contoh ini membuat dua segitiga identik tanpa isi dengan garis tepi lebar 20 poin. Segitiga kiri menggunakan batas `2`, dan yang kanan menggunakan `8`. Setiap segitiga lebar 80 poin dan tinggi 160 poin, memberikan sudut atasnya rasio panjang miter terhadap lebar garis sekitar `4.12`. Akibatnya, PowerPoint menambahkan bevel pada puncak kiri dan mempertahankan puncak kanan.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(500, 320, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var miterLimits = new[] { 2f, 8f };

for (var i = 0; i < miterLimits.Length; i++)
{
    var triangle = slide.Shapes.AddAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
    triangle.FillFormat.FillType = FillType.NoFill;
    triangle.LineFormat.Width = 20;
    triangle.LineFormat.FillFormat.FillType = FillType.Solid;
    triangle.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    triangle.LineFormat.JoinStyle = LineJoinStyle.Miter;
    triangle.LineFormat.MiterLimit = miterLimits[i];
}

presentation.Save("miter_limits.pptx", SaveFormat.Pptx);
```

Hasil di PowerPoint: **Miter limit 2** di kiri dan **miter limit 8** di kanan.

![Puncak bevel dengan miter limit 2 dan puncak runcing dengan miter limit 8 di PowerPoint](miter-limits.png)

## **Isian Gradien**

Isian gradien menggabungkan warna di seluruh bentuk. Contoh ini mengisi elips dengan gradien linear pada sudut 45 derajat dari merah ke ungu menggunakan [IFillFormat.GradientFormat](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/gradientformat/). Metode [IGradientStopCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/igradientstopcollection/add/) menempatkan titik warna pada 0 dan 1, yaitu awal dan akhir gradien. Menghapus titik yang ada memastikan hanya kedua warna ini yang digunakan.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Gradient;
shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
shape.FillFormat.GradientFormat.LinearGradientAngle = 45;
shape.FillFormat.GradientFormat.GradientStops.Clear();
shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
```

Hasil:
![Elips dengan isian gradien](gradient-fill.png)

Jika gradien terlihat berbeda dalam gambar yang diekspor dibandingkan dengan di PowerPoint, lihat [Choose a Gradient Rendering Style](/slides/id/net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Anda dapat memilih gaya perenderan tanpa mengubah isian gradien yang disimpan dalam presentasi.

### **Atur Sudut Gradien Linear**

Gunakan [IGradientFormat.LinearGradientAngle](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientangle/) untuk mengontrol orientasi isian [GradientShape.Linear](https://reference.aspose.com/slides/net/aspose.slides/gradientshape/) . Sudut diukur dalam derajat dan meningkat searah jarum jam: `0` berjalan dari kiri ke kanan, `90` dari atas ke bawah, `180` dari kanan ke kiri, dan `270` dari bawah ke atas. Sudut pecahan didukung. Sudut terbatas di luar `[0, 360)` dinormalisasi menjadi satu putaran; misalnya, `-45` menjadi `315` dan `360` menjadi `0`.

Contoh ini membuat enam persegi panjang dengan titik warna merah, hijau, dan biru yang identik pada posisi `0`, `0.5`, dan `1`. Skala dinonaktifkan sehingga sudut dapat dibandingkan secara independen dari proporsi persegi panjang. Sudut, dari kiri ke kanan, adalah `0`, `45`, dan `90` pada baris pertama, serta `135`, `180`, dan `270` pada baris kedua.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 400, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var angles = new float[] { 0, 45, 90, 135, 180, 270 };

for (var i = 0; i < angles.Length; i++)
{
    var x = 30 + (i % 3) * 230;
    var y = 30 + (i / 3) * 190;

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, 200, 150);
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
    shape.FillFormat.FillType = FillType.Gradient;

    var gradient = shape.FillFormat.GradientFormat;
    gradient.GradientShape = GradientShape.Linear;
    gradient.GradientStops.Clear();
    gradient.GradientStops.Add(0f, Color.Red);
    gradient.GradientStops.Add(0.5f, Color.Lime);
    gradient.GradientStops.Add(1f, Color.Blue);
    gradient.LinearGradientScaled = NullableBool.False;
    gradient.LinearGradientAngle = angles[i];
}

presentation.Save("linear_gradient_angles.pptx", SaveFormat.Pptx);
```

Hasil di PowerPoint:
![Gradien linear pada 0, 45, dan 90 derajat di baris atas, serta 135, 180, dan 270 derajat di baris bawah](linear-gradient-angles.png)

### **Skala Gradien Linear dengan Bentuk**

[IGradientFormat.LinearGradientScaled](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientscaled/) menerima nilai [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/). Tetapkan secara eksplisit ke `False` untuk mempertahankan sudut gradien geometris saat proporsi bentuk berubah, atau ke `True` untuk menyesuaikan skala gradien dengan lebar dan tinggi bentuk. Dengan skala diaktifkan, sudut yang terlihat dapat berbeda dari sudut yang ditetapkan pada bentuk yang tidak berbentuk kotak.

Contoh berikut menggunakan sudut `45` derajat dan titik warna yang sama seperti perbandingan sudut. Kolom kiri menggunakan `False`; kolom kanan menggunakan `True`. Setiap kolom berisi persegi panjang lebar di atas persegi panjang tinggi. Kedua kolom mulai dengan dimensi lebar yang sama; mengubah lebar dan tinggi persegi panjang kedua menunjukkan bagaimana isian merespons perubahan ukuran tanpa mengubah pengaturan gradien.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 460, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var scalingOptions = new[] { NullableBool.False, NullableBool.True };

for (var column = 0; column < scalingOptions.Length; column++)
{
    for (var row = 0; row < 2; row++)
    {
        var x = 30 + column * 360;
        var y = row == 0 ? 30 : 150;
        
        var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, 300, 90);
        shape.LineFormat.FillFormat.FillType = FillType.NoFill;
        shape.FillFormat.FillType = FillType.Gradient;

        var gradient = shape.FillFormat.GradientFormat;
        gradient.GradientShape = GradientShape.Linear;
        gradient.GradientStops.Clear();
        gradient.GradientStops.Add(0f, Color.Red);
        gradient.GradientStops.Add(0.5f, Color.Lime);
        gradient.GradientStops.Add(1f, Color.Blue);
        gradient.LinearGradientAngle = 45;
        gradient.LinearGradientScaled = scalingOptions[column];

        if (row == 1)
        {
            shape.Width = 90;
            shape.Height = 280;
        }
    }
}

presentation.Save("linear_gradient_scaling.pptx", SaveFormat.Pptx);
```

Hasil di PowerPoint, dengan skala dinonaktifkan di kiri dan diaktifkan di kanan:
![Persegi panjang lebar dan tinggi dengan gradien 45 derajat, membandingkan LinearGradientScaled False di kiri dengan True di kanan](linear-gradient-scaling.png)

Dengan skala dinonaktifkan, pita warna diagonal mempertahankan orientasi yang sama pada kedua persegi panjang. Dengan skala diaktifkan, pita-pita tersebut meregang sesuai proporsi bentuk. Ini membantu mereproduksi gradien templat saat menyesuaikan bentuk ke ukuran yang berbeda. Pada bentuk kotak, mengaktifkan skala tidak mengubah tampilan gradien `45` derajat ini.

Baik pengaturan sudut maupun skala berlaku untuk gradien linear. Mereka tidak mengontrol isian [GradientShape.Radial or GradientShape.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/gradientshape/).

### **Gabungkan Sudut dengan Arah Gradien**

[IGradientFormat.GradientDirection](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/gradientdirection/) memilih gaya gradien dari enumerasi [GradientDirection](https://reference.aspose.com/slides/net/aspose.slides/gradientdirection/); ini bukan pengganti sudut numerik. Untuk gradien linear, gaya sudut dapat mengubah area distribusi warna tanpa mengubah [LinearGradientAngle](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientangle/). Pertahankan arah tetap sama saat membandingkan sudut atau skala.

Contoh berikut menerapkan pengaturan yang sama dalam urutan terbalik. Kedua persegi panjang memiliki tampilan yang sama: menetapkan arah sebelum atau sesudah sudut tidak mengubah hasil.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

for (var i = 0; i < 2; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
    shape.FillFormat.FillType = FillType.Gradient;

    var gradient = shape.FillFormat.GradientFormat;
    gradient.GradientShape = GradientShape.Linear;
    gradient.GradientStops.Clear();
    gradient.GradientStops.Add(0f, Color.Red);
    gradient.GradientStops.Add(0.5f, Color.Lime);
    gradient.GradientStops.Add(1f, Color.Blue);
    gradient.LinearGradientScaled = NullableBool.True;

    if (i == 0)
    {
        gradient.GradientDirection = GradientDirection.FromCorner1;
        gradient.LinearGradientAngle = 30;
    }
    else
    {
        gradient.LinearGradientAngle = 30;
        gradient.GradientDirection = GradientDirection.FromCorner1;
    }
}

presentation.Save("linear_gradient_direction.pptx", SaveFormat.Pptx);
```

## **Isian Pola**

Isian pola menerapkan desain dua warna, seperti titik, garis, atau kotak. Contoh ini menggunakan [IPatternFormat.PatternStyle](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/patternstyle/) untuk memilih pola trellis. [IPatternFormat.BackColor](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/) menyediakan latar belakang abu‑abu muda, dan [IPatternFormat.ForeColor](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/) menyediakan warna pola kuning.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Pattern;
shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;
shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
```

Hasil:
![Persegi panjang dengan isian pola](pattern-fill.png)

## **Isian Gambar**

Isian gambar menggunakan gambar di dalam bentuk. Contoh ini memerlukan gambar lokal dan menggunakan [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) untuk memuatnya ke dalam koleksi gambar presentasi. Mengatur [IPictureFillFormat.PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/) ke mode ubin mengulang gambar di dalam persegi panjang. Gambar sumber yang digunakan di sini ditampilkan di bawah:

![Gambar lotus](lotus.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

using var image = Images.FromFile("lotus.png");
var presentationImage = presentation.Images.AddImage(image);
shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
```

Hasil:
![Bentuk dengan isian gambar](picture-fill.png)

### **Ubin Gambar sebagai Tekstur**

Jika Anda ingin mengatur gambar ubin sebagai tekstur dan menyesuaikan perilaku ubin, Anda dapat menggunakan properti berikut dari antarmuka [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) dan kelas [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/):

- [PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/): Mengatur mode isian gambar—`Tile` atau `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilealignment/): Menentukan perataan ubin dalam bentuk.
- [TileFlip](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileflip/): Mengontrol apakah ubin dibalik secara horizontal, vertikal, atau keduanya.
- [TileOffsetX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsetx/): Mengatur offset horizontal ubin (dalam poin) dari asal bentuk.
- [TileOffsetY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsety/): Mengatur offset vertikal ubin (dalam poin) dari asal bentuk.
- [TileScaleX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescalex/): Menetapkan skala horizontal ubin sebagai persentase.
- [TileScaleY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescaley/): Menetapkan skala vertikal ubin sebagai persentase.

Contoh ini memerlukan gambar lokal dan mengonfigurasi [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) untuk mengulangnya pada 50% dari ukuran aslinya. Offset −32 poin memindahkan ubin secara horizontal dan vertikal; perataan kanan-bawah dan pembalikan di kedua arah menentukan bagaimana tekstur yang diulang diatur.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];

var shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);
shape.FillFormat.FillType = FillType.Picture;

using var sourceImage = Images.FromFile("lotus.png");
var presentationImage = presentation.Images.AddImage(sourceImage);

var pictureFillFormat = shape.FillFormat.PictureFillFormat;
pictureFillFormat.Picture.Image = presentationImage;
pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
pictureFillFormat.TileOffsetX = -32;
pictureFillFormat.TileOffsetY = -32;
pictureFillFormat.TileScaleX = 50;
pictureFillFormat.TileScaleY = 50;
pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
pictureFillFormat.TileFlip = TileFlip.FlipBoth;

presentation.Save("tile.pptx", SaveFormat.Pptx);
```

Hasil:
![Opsi ubin](tile-options.png)

## **Isian Warna Solid**

Isian solid memberi bentuk satu warna seragam. Contoh ini mengatur [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) ke mode isian solid dan menetapkan kuning melalui [IFillFormat.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/), lalu menyimpan persegi panjang dalam sebuah presentasi.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Yellow;

presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
```

Hasil:
![Bentuk dengan isian warna solid](solid-color-fill.png)

### **Salin Warna Sambil Mempertahankan Referensi Tema**

Gunakan [IColorFormat.CopyFrom](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/copyfrom/) untuk menyalin definisi warna, termasuk tipe warna, referensi tema, dan transformasi. Ini berguna saat memindahkan warna isian antar bentuk yang harus tetap mengikuti tema presentasi. Metode ini hanya menyalin warna: tidak menyalin tipe isian, garis tepi, atau pemformatan bentuk lainnya. Tetapkan [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) tujuan secara eksplisit.

Contoh ini membuat tiga persegi panjang, dari kiri ke kanan: sumber, salinan yang menyadari tema, dan salinan RGB tetap. Sumber menggunakan [IColorFormat.SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/schemecolor/) untuk merujuk ke warna aksen pertama dan menambahkan tint melalui [IColorOperationCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/icoloroperationcollection/add/). Salinan RGB menggunakan warna isian efektif sumber sehingga ketiganya awalnya tampak identik. Menetapkan [IColorFormat.Color](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/color/) menetapkan nilai RGB tetap dan menghapus transformasi warna yang ada.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(660, 220, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

presentation.MasterTheme.ColorScheme.Accent1.Color = Color.RoyalBlue;

var source = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 40, 180, 140);
var themeCopy = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 240, 40, 180, 140);
var rgbCopy = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 450, 40, 180, 140);

foreach (var shape in new[] { source, themeCopy, rgbCopy })
{
    shape.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
}

var sourceColor = source.FillFormat.SolidFillColor;
sourceColor.SchemeColor = SchemeColor.Accent1;
sourceColor.ColorTransform.Add(ColorTransformOperation.Tint, 0.75f);

themeCopy.FillFormat.SolidFillColor.CopyFrom(sourceColor);
rgbCopy.FillFormat.SolidFillColor.Color = source.FillFormat.GetEffective().SolidFillColor;

using var before = slide.GetImage(1f, 1f);
before.Save("color-copy-before.png", ImageFormat.Png);

// Theme references follow the new accent color; the fixed RGB value does not.
presentation.MasterTheme.ColorScheme.Accent1.Color = Color.OrangeRed;

using var after = slide.GetImage(1f, 1f);
after.Save("color-copy-after.png", ImageFormat.Png);
presentation.Save("copied_colors.pptx", SaveFormat.Pptx);
```

Sebelum perubahan tema, ketiga isian cocok:
![Sumber, tujuan CopyFrom, dan tujuan RGB tetap dengan isian biru identik](color-copy-before.png)

Setelah perubahan tema, sumber dan salinan yang menyadari tema mengikuti warna aksen baru dan mempertahankan tint-nya. Salinan RGB tetap biru:
![Sumber dan tujuan CopyFrom dengan isian oranye, sementara tujuan RGB tetap biru](color-copy-after.png)

Definisi yang disalin independen dari sumber. Selanjutnya mengubah referensi tema sumber, menetapkan warna lain, atau menambah atau menghapus transformasinya tidak mengubah tujuan. Perubahan tema tetap memengaruhi kedua bentuk karena masing‑masing merujuk secara independen ke warna tema yang sama.

Menyimpan dan membuka kembali PPTX mempertahankan [IColorFormat.ColorType](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/colortype/), referensi tema, dan koleksi [IColorFormat.ColorTransform](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/colortransform/) warna yang disalin; tidak meratakan definisi menjadi RGB.

Saat menyalin antara konteks tema yang berbeda, seperti presentasi dengan palet aksen yang berbeda, referensi yang disalin diselesaikan terhadap tema tujuan. Referensi dan transformasi yang sama dapat menghasilkan warna yang terlihat berbeda. Lihat [Presentation Theme](/slides/id/net/presentation-theme/) untuk informasi lebih lanjut tentang mengonfigurasi warna tema.

## **Gunakan Latar Belakang Slide sebagai Isian Bentuk**

Gunakan [IAutoShape.UseBackgroundFill](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/usebackgroundfill/) ketika bentuk harus cocok dengan latar belakang slide, misalnya dalam templat presentasi. Tetapkan [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) ke [FillType.NotDefined](https://reference.aspose.com/slides/net/aspose.slides/filltype/) terlebih dahulu untuk menghapus isian eksplisit apa pun. Dengan kombinasi ini, bentuk menggunakan latar belakang slide alih‑alih isian gaya nya. Mengaktifkan flag saja tidak menghapus isian eksplisit yang ada.

Ini berbeda dari [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/): isian latar belakang menutupi objek di belakang bentuk dengan area latar belakang slide yang bersesuaian, sementara NoFill membiarkan objek tersebut tetap terlihat. Gradien tetap disejajarkan dengan slide alih‑alih memulai kembali di dalam setiap bentuk.

Contoh berikut membuat latar belakang master yang diwarisi oleh slide dan menempatkan pita magenta di belakang tiga persegi panjang. Persegi panjang kiri menggunakan latar belakang, persegi panjang tengah tidak memiliki isian, dan persegi panjang kanan beralih dari isian latar belakang ke isian oranye eksplisit.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 400, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

// Wariskan gradien dari master.
slide.Background.Type = BackgroundType.NotDefined;
slide.LayoutSlide.Background.Type = BackgroundType.NotDefined;
var background = slide.LayoutSlide.MasterSlide.Background;
background.Type = BackgroundType.OwnBackground;
background.FillFormat.FillType = FillType.Gradient;
var gradient = background.FillFormat.GradientFormat;
gradient.GradientShape = GradientShape.Linear;
gradient.LinearGradientAngle = 0;
gradient.GradientStops.Clear();
gradient.GradientStops.Add(0, Color.DarkBlue);
gradient.GradientStops.Add(1, Color.LightSkyBlue);

// Tambahkan objek ini terlebih dahulu agar muncul di belakang persegi panjang.
var band = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 25, 150, 670, 100);
band.FillFormat.FillType = FillType.Solid;
band.FillFormat.SolidFillColor.Color = Color.Magenta;
band.LineFormat.FillFormat.FillType = FillType.NoFill;

var backgroundShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 100, 160, 200);
backgroundShape.FillFormat.FillType = FillType.NotDefined;
backgroundShape.UseBackgroundFill = true;

var noFillShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 280, 100, 160, 200);
noFillShape.FillFormat.FillType = FillType.NoFill;

var explicitShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 510, 100, 160, 200);
explicitShape.FillFormat.FillType = FillType.NotDefined;
explicitShape.UseBackgroundFill = true;

// Nonaktifkan isian latar belakang sebelum menerapkan isian eksplisit.
explicitShape.UseBackgroundFill = false;
explicitShape.FillFormat.FillType = FillType.Solid;
explicitShape.FillFormat.SolidFillColor.Color = Color.Orange;

presentation.Save("background_fill.pptx", SaveFormat.Pptx);
```

Hasil, dari kiri ke kanan: **background fill**, **no fill**, dan **explicit fill**. Pita magenta disembunyikan oleh persegi panjang kiri dan kanan tetapi tetap terlihat melalui persegi panjang tengah.

![Isian latar belakang, tanpa isian, dan isian oranye eksplisit di atas pita magenta](background-fill.png)

Perilaku yang sama berlaku untuk latar belakang yang didefinisikan langsung pada slide atau diwarisi dari tata letak. Bentuk menggunakan latar belakang slide yang telah diselesaikan; contoh ini membiarkan latar belakang slide dan tata letak tidak ditetapkan sehingga master menyediakannya.

## **Atur Transparansi**

Untuk isian solid, komponen alfa warna mengontrol opasitas: 0 berarti sepenuhnya transparan dan 255 sepenuhnya opak. Contoh ini menggunakan nilai alfa 128 untuk persegi panjang kuning, menjadikannya kira‑kira 50% transparan sehingga persegi panjang di bawahnya tetap terlihat. Warna ditetapkan melalui [IFillFormat.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/).

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const int alpha = 128;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

var transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
transparentShape.FillFormat.FillType = FillType.Solid;
transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
```

Hasil:
![Bentuk transparan](shape-transparency.png)

## **Putar Bentuk**

Gunakan [IShape.Rotation](https://reference.aspose.com/slides/net/aspose.slides/ishape/rotation/) untuk memutar bentuk dalam bidang slide. Sudut diukur dalam derajat; contoh ini memutar persegi panjang 5 derajat searah jarum jam dan menyimpan presentasi.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.Rotation = 5;

presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
```

Hasil:
![Rotasi bentuk](shape-rotation.png)

## **Tambahkan Efek Bevel 3D**

Gunakan [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/threedformat/) untuk memberi bentuk kedalaman dan tepi bevel. Contoh ini membuat elips hijau dengan garis tepi oranye, mengatur [IThreeDFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/depth/) menjadi 4 poin, dan menerapkan bevel atas berbentuk melingkar dengan lebar dan tinggi 6 poin melalui [IThreeDFormat.BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/beveltop/). Kamera ortografik menghadap depan dan pencahayaan tiga titik membuat bevel terlihat.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Green;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
shape.LineFormat.Width = 2.0;
shape.ThreeDFormat.Depth = 4;
shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
shape.ThreeDFormat.BevelTop.Height = 6;
shape.ThreeDFormat.BevelTop.Width = 6;
shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
```

Hasil:
![Efek bevel 3D](3D-bevel-effect.png)

## **Tambahkan Efek Rotasi 3D**

Tampilan 3D sebuah bentuk dikontrol oleh pengaturan kameranya. Contoh ini menggunakan [ICamera.SetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/setrotation/) dengan sudut lintang, bujur, dan revolusi masing‑masing 40, 35, dan 20 derajat. Ia memilih kamera isometrik melalui [ICamera.CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) dan pencahayaan seimbang melalui [ILightRig.LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/lighttype/), lalu menyimpan persegi panjang yang diformat.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
autoShape.TextFrame.Text = "Hello, Aspose!";
autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
```

Hasil:
![Efek rotasi 3D](3D-rotation-effect.png)

## **Kontrol Rendering Hitam‑Putih untuk Bentuk**

Properti [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) menentukan bagaimana sebuah bentuk individual dirender ketika presentasi dilihat atau diproses dalam mode hitam‑putih. Properti ini tidak mengaktifkan tampilan hitam‑putih sendiri, dan tidak mengubah isian, garis, atau pemformatan lain bentuk dalam mode warna normal.

Gunakan nilai dari enumerasi [BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/blackwhitemode/) untuk memilih perilaku yang diinginkan. Misalnya, `Automatic` membiarkan aplikasi perenderan memilih konversi, `Gray` dan `LightGray` menggunakan warna abu‑abu, `BlackWhite` hanya menggunakan hitam dan putih, `Black` dan `White` memaksa satu warna, `Color` mempertahankan warna normal, dan `Hidden` menghilangkan bentuk dalam mode hitam‑putih. `NotDefined` berarti tidak ada mode tingkat bentuk yang ditetapkan.

Contoh ini membuat persegi panjang oranye dan mengatur [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) ke gray. Bentuk yang disimpan mempertahankan isian oranye untuk tampilan warna normal dan meminta pewarnaan abu‑abu dari aplikasi yang menghormati pengaturan tampilan hitam‑putih:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

Dalam mode warna normal, persegi panjang mempertahankan isian oranye. Dalam alur kerja tampilan hitam‑putih, ia menggunakan pewarnaan abu‑abu karena mode-nya diatur ke `Gray`. Ini memungkinkan Anda mempertahankan slide berwarna penuh sambil mendefinisikan tampilan yang berbeda untuk pencetakan, pratinjau, atau alur kerja lain yang menghormati pengaturan tampilan hitam‑putih presentasi.

## **Setel Ulang Pemformatan**

Gunakan [ISlide.Reset](https://reference.aspose.com/slides/net/aspose.slides/islide/reset/) untuk mengembalikan posisi, ukuran, dan pemformatan placeholder slide dari placeholder tata letak yang bersesuaian. Contoh ini memerlukan presentasi yang sudah ada dengan placeholder yang terhubung ke tata letak dan menyetel ulang setiap slide sebelum menyimpan. Bentuk tanpa placeholder tata letak yang bersesuaian tidak disetel ulang.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
foreach (var slide in presentation.Slides)
{
    slide.Reset();
}

presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Apakah pemformatan bentuk memengaruhi ukuran akhir file presentasi?**

Warna, gaya garis, dan pengaturan efek umumnya menambahkan sedikit data dibandingkan dengan gambar dan media yang disematkan. Isian gambar dapat meningkatkan ukuran file karena gambar mereka disimpan dalam presentasi.

**Bagaimana saya dapat mendeteksi bentuk pada slide yang memiliki pemformatan identik sehingga saya dapat mengelompokkannya?**

Bandingkan setiap properti pemformatan utama bentuk—isi, garis, dan pengaturan efek. Jika semua nilai yang bersesuaian cocok, anggap gaya mereka identik dan kelompokkan bentuk‑bentuk tersebut secara logis, yang menyederhanakan pengelolaan gaya selanjutnya.

**Apakah saya dapat menyimpan sekumpulan gaya bentuk kustom ke file terpisah untuk digunakan kembali di presentasi lain?**

Ya. Simpan bentuk contoh dengan gaya yang diinginkan dalam satu set slide templat atau file templat .POTX. Saat membuat presentasi baru, buka templat, kloning bentuk bergaya yang Anda butuhkan, dan terapkan kembali pemformatannya di mana pun diperlukan.