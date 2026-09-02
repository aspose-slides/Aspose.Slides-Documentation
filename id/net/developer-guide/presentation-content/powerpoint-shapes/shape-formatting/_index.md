---
title: Format Bentuk PowerPoint di .NET
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
- isi gradien
- isi pola
- isi gambar
- isi tekstur
- isi warna solid
- transparansi bentuk
- rendering bentuk hitam-putih
- rendering bentuk skala abu-abu
- putar bentuk
- efek bevel 3D
- efek rotasi 3D
- reset pemformatan
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara memformat bentuk PowerPoint dalam C# menggunakan Aspose.Slides—atur gaya isi, garis, dan efek untuk file PPT dan PPTX dengan presisi dan kontrol penuh."
---
## **Pendahuluan**

Di PowerPoint, Anda dapat menambahkan bentuk ke slide. Karena bentuk terdiri dari garis, Anda dapat memformatnya dengan mengubah atau menerapkan efek pada garis tepinya. Selain itu, Anda dapat memformat bentuk dengan menentukan pengaturan yang mengontrol bagaimana bagian dalamnya diisi.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for .NET menyediakan antarmuka dan properti yang memungkinkan Anda memformat bentuk menggunakan opsi yang sama tersedia di PowerPoint.

## **Format Garis**

Dengan Aspose.Slides, Anda dapat menentukan gaya garis khusus untuk sebuah bentuk. Langkah‑langkah berikut menjelaskan prosedurnya:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) .
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) ke slide.
1. Atur [line style](https://reference.aspose.com/slides/id/net/aspose.slides/linestyle/) bentuk.
1. Atur lebar garis.
1. Atur [dash style](https://reference.aspose.com/slides/id/net/aspose.slides/linedashstyle/) garis.
1. Atur warna garis untuk bentuk.
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode C# berikut memperlihatkan cara memformat sebuah `AutoShape` persegi panjang:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Buat instance kelas Presentation yang mewakili file presentasi.
using (Presentation presentation = new Presentation())
{
    // Dapatkan slide pertama.
    ISlide slide = presentation.Slides[0];

    // Tambahkan auto shape tipe Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Atur warna isi untuk shape persegi panjang.
    shape.FillFormat.FillType = FillType.NoFill;

    // Terapkan pemformatan pada garis persegi panjang.
    shape.LineFormat.Style = LineStyle.ThickThin;
    shape.LineFormat.Width = 7;
    shape.LineFormat.DashStyle = LineDashStyle.Dash;

    // Atur warna untuk garis persegi panjang.
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Simpan file PPTX ke disk.
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![Garis yang diformat dalam presentasi](formatted-lines.png)

## **Terapkan Efek Sketsa pada Garis Bentuk**

Efek sketsa membuat garis bentuk tampak seperti digambar tangan. Gunakan [IShape.LineFormat](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/lineformat/) untuk mengakses pengaturan garis, [ILineFormat.SketchFormat](https://reference.aspose.com/slides/id/net/aspose.slides/ilineformat/sketchformat/) untuk mengakses pengaturan sketsa, dan [ISketchFormat.SketchType](https://reference.aspose.com/slides/id/net/aspose.slides/isketchformat/sketchtype/) untuk memilih nilai dari enumerasi [LineSketchType](https://reference.aspose.com/slides/id/net/aspose.slides/linesketchtype/) .

Kode C# berikut menunjukkan cara menerapkan efek [LineSketchType.Curved](https://reference.aspose.com/slides/id/net/aspose.slides/linesketchtype/) , membaca nilai yang ditetapkan secara eksplisit, dan menghapus efek dengan [LineSketchType.None](https://reference.aspose.com/slides/id/net/aspose.slides/linesketchtype/) :

```csharp
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

// Access the shape's line format and its sketch format.
var sketchFormat = shape.LineFormat.SketchFormat;

// Apply a sketch effect.
sketchFormat.SketchType = LineSketchType.Curved;

// Read the sketch effect assigned directly to the shape.
var explicitSketchType = sketchFormat.SketchType;
Console.WriteLine($"Explicit sketch type: {explicitSketchType}");

// Remove the sketch effect.
sketchFormat.SketchType = LineSketchType.None;
```

Nilai yang dikembalikan oleh `ISketchFormat.SketchType` mewakili pengaturan yang ditetapkan langsung pada bentuk. Jika pemformatan garis dapat diwarisi dari tema, master slide, atau layout slide, gunakan [ILineFormat.GetEffective](https://reference.aspose.com/slides/id/net/aspose.slides/ilineformat/geteffective/) , akses [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/id/net/aspose.slides/ilineformateffectivedata/sketchformat/) , dan baca [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/id/net/aspose.slides/isketchformateffectivedata/sketchtype/) . Nilai efektif mencerminkan pemformatan yang sebenarnya diterapkan setelah pewarisan diselesaikan:

```csharp
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

Berikut tiga pilihan tipe sambungan:

* Round
* Miter
* Bevel

Secara default, ketika PowerPoint menyambungkan dua garis pada sudut (misalnya pada sudut bentuk), ia menggunakan pengaturan **Round**. Namun, jika Anda menggambar bentuk dengan sudut tajam, Anda mungkin lebih menyukai opsi **Miter**.

![Gaya sambungan dalam presentasi](join-style-powerpoint.png)

Kode C# berikut memperlihatkan bagaimana tiga persegi panjang (seperti pada gambar di atas) dibuat menggunakan pengaturan tipe sambungan Miter, Bevel, dan Round:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Buat instance kelas Presentation yang mewakili file presentasi.
using (Presentation presentation = new Presentation())
{
    // Dapatkan slide pertama.
    ISlide slide = presentation.Slides[0];

    // Tambahkan tiga auto shape tipe Rectangle.
    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Atur warna isi untuk setiap shape persegi panjang.
    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.Color = Color.Black;
    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.Color = Color.Black;
    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.Color = Color.Black;

    // Atur lebar garis.
    shape1.LineFormat.Width = 15;
    shape2.LineFormat.Width = 15;
    shape3.LineFormat.Width = 15;

    // Atur warna untuk setiap garis persegi panjang.
    shape1.LineFormat.FillFormat.FillType = FillType.Solid;
    shape1.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape2.LineFormat.FillFormat.FillType = FillType.Solid;
    shape2.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape3.LineFormat.FillFormat.FillType = FillType.Solid;
    shape3.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Atur gaya sambungan.
    shape1.LineFormat.JoinStyle = LineJoinStyle.Miter;
    shape2.LineFormat.JoinStyle = LineJoinStyle.Bevel;
    shape3.LineFormat.JoinStyle = LineJoinStyle.Round;

    // Tambahkan teks ke setiap persegi panjang.
    shape1.TextFrame.Text = "Miter Join Style";
    shape2.TextFrame.Text = "Bevel Join Style";
    shape3.TextFrame.Text = "Round Join Style";

    // Simpan file PPTX ke disk.
    presentation.Save("join_styles.pptx", SaveFormat.Pptx);
}
```

## **Gradient Fill**

Di PowerPoint, Gradient Fill adalah opsi pemformatan yang memungkinkan Anda menerapkan perpaduan warna kontinu pada sebuah bentuk. Misalnya, Anda dapat menerapkan dua atau lebih warna sehingga satu warna secara bertahap memudar menjadi warna lainnya.

Berikut cara menerapkan gradient fill pada bentuk menggunakan Aspose.Slides:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) .
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) ke slide.
1. Atur [FillType](https://reference.aspose.com/slides/id/net/aspose.slides/filltype/) bentuk menjadi `Gradient` .
1. Tambahkan dua warna pilihan Anda dengan posisi yang ditentukan menggunakan metode `Add` dari koleksi gradient stop yang diekspos oleh antarmuka [IGradientFormat](https://reference.aspose.com/slides/id/net/aspose.slides/igradientformat/) .
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode C# berikut memperlihatkan cara menerapkan efek gradient fill pada sebuah elips:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Buat instance kelas Presentation yang mewakili file presentasi.
using (Presentation presentation = new Presentation())
{
    // Dapatkan slide pertama.
    ISlide slide = presentation.Slides[0];

    // Tambahkan auto shape tipe Ellipse.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Terapkan pemformatan gradien ke elips.
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // Atur arah gradien.
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // Tambahkan dua gradient stop.
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // Simpan file PPTX ke disk.
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![Elips dengan gradient fill](gradient-fill.png)

## **Pattern Fill**

Di PowerPoint, Pattern Fill adalah opsi pemformatan yang memungkinkan Anda menerapkan desain dua warna—seperti titik, garis, crosshatch, atau kotak—pada sebuah bentuk. Anda dapat memilih warna kustom untuk latar depan dan latar belakang pola.

Aspose.Slides menyediakan lebih dari 45 gaya pola bawaan yang dapat Anda terapkan pada bentuk untuk meningkatkan daya tarik visual presentasi Anda. Bahkan setelah memilih pola bawaan, Anda masih dapat menentukan warna tepat yang harus digunakan.

Berikut cara menerapkan pattern fill pada bentuk menggunakan Aspose.Slides:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) .
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) ke slide.
1. Atur [FillType](https://reference.aspose.com/slides/id/net/aspose.slides/filltype/) bentuk menjadi `Pattern` .
1. Pilih gaya pola dari opsi bawaan.
1. Atur [Background Color](https://reference.aspose.com/slides/id/net/aspose.slides/ipatternformat/backcolor/) pola.
1. Atur [Foreground Color](https://reference.aspose.com/slides/id/net/aspose.slides/ipatternformat/forecolor/) pola.
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode C# berikut memperlihatkan cara menerapkan pattern fill pada sebuah persegi panjang:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Buat instance kelas Presentation yang mewakili file presentasi.
using (Presentation presentation = new Presentation())
{
    // Dapatkan slide pertama.
    ISlide slide = presentation.Slides[0];

    // Tambahkan auto shape tipe Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Atur tipe isi menjadi Pattern.
    shape.FillFormat.FillType = FillType.Pattern;

    // Atur gaya pola.
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // Atur warna latar belakang dan latar depan pola.
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // Simpan file PPTX ke disk.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![Persegi panjang dengan pattern fill](pattern-fill.png)

## **Picture Fill**

Di PowerPoint, Picture Fill adalah opsi pemformatan yang memungkinkan Anda menyisipkan gambar di dalam bentuk—secara efektif menggunakan gambar sebagai latar belakang bentuk.

Berikut cara menggunakan Aspose.Slides untuk menerapkan picture fill pada bentuk:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) .
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) ke slide.
1. Atur [FillType](https://reference.aspose.com/slides/id/net/aspose.slides/filltype/) bentuk menjadi `Picture` .
1. Atur mode picture fill menjadi `Tile` (atau mode lain yang Anda inginkan).
1. Buat objek [IPPImage](https://reference.aspose.com/slides/id/net/aspose.slides/ippimage/) dari gambar yang ingin Anda gunakan.
1. Tetapkan gambar ini ke properti `Picture.Image` dari `PictureFillFormat` bentuk.
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Misalkan kami memiliki file "lotus.png" dengan gambar berikut:

![Gambar lotus](lotus.png)

Kode C# berikut memperlihatkan cara mengisi bentuk dengan gambar:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Buat instance kelas Presentation yang mewakili file presentasi.
using (Presentation presentation = new Presentation())
{
    // Dapatkan slide pertama.
    ISlide slide = presentation.Slides[0];

    // Tambahkan auto shape tipe Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // Atur tipe isi menjadi Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Atur mode picture fill.
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // Muat gambar dan tambahkan ke sumber daya presentasi.
    IImage image = Images.FromFile("lotus.png");
    IPPImage presentationImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Atur gambar.
    shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

    // Simpan file PPTX ke disk.
    presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![Bentuk dengan picture fill](picture-fill.png)

### **Tile Picture As Texture**

Jika Anda ingin mengatur gambar ubin sebagai tekstur dan menyesuaikan perilaku ubin, Anda dapat menggunakan properti berikut dari antarmuka [IPictureFillFormat](https://reference.aspose.com/slides/id/net/aspose.slides/ipicturefillformat/) dan kelas [PictureFillFormat](https://reference.aspose.com/slides/id/net/aspose.slides/picturefillformat/) :

- [PictureFillMode](https://reference.aspose.com/slides/id/net/aspose.slides/ipicturefillformat/picturefillmode/) : Mengatur mode picture fill—baik `Tile` atau `Stretch` .
- [TileAlignment](https://reference.aspose.com/slides/id/net/aspose.slides/ipicturefillformat/tilealignment/) : Menentukan perataan ubin dalam bentuk.
- [TileFlip](https://reference.aspose.com/slides/id/net/aspose.slides/ipicturefillformat/tileflip/) : Mengontrol apakah ubin dibalik secara horizontal, vertikal, atau keduanya.
- [TileOffsetX](https://reference.aspose.com/slides/id/net/aspose.slides/ipicturefillformat/tileoffsetx/) : Mengatur offset horizontal ubin (dalam poin) dari asal bentuk.
- [TileOffsetY](https://reference.aspose.com/slides/id/net/aspose.slides/ipicturefillformat/tileoffsety/) : Mengatur offset vertikal ubin (dalam poin) dari asal bentuk.
- [TileScaleX](https://reference.aspose.com/slides/id/net/aspose.slides/ipicturefillformat/tilescalex/) : Mendefinisikan skala horizontal ubin sebagai persentase.
- [TileScaleY](https://reference.aspose.com/slides/id/net/aspose.slides/ipicturefillformat/tilescaley/) : Mendefinisikan skala vertikal ubin sebagai persentase.

Contoh kode berikut menunjukkan cara menambahkan bentuk persegi panjang dengan picture fill ubin dan mengonfigurasi opsi ubin:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Buat instance kelas Presentation yang mewakili file presentasi.
using (Presentation presentation = new Presentation())
{
    // Dapatkan slide pertama.
    ISlide firstSlide = presentation.Slides[0];

    // Tambahkan auto shape persegi panjang.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Atur tipe isi shape menjadi Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Muat gambar dan tambahkan ke sumber daya presentasi.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // Tetapkan gambar ke shape.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // Konfigurasikan mode picture fill dan properti ubin.
    pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    pictureFillFormat.TileOffsetX = -32;
    pictureFillFormat.TileOffsetY = -32;
    pictureFillFormat.TileScaleX = 50;
    pictureFillFormat.TileScaleY = 50;
    pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
    pictureFillFormat.TileFlip = TileFlip.FlipBoth;

    // Simpan file PPTX ke disk.
    presentation.Save("tile.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![Opsi ubin](tile-options.png)

## **Solid Color Fill**

Di PowerPoint, Solid Color Fill adalah opsi pemformatan yang mengisi bentuk dengan satu warna seragam. Latar belakang berwarna polos ini diterapkan tanpa gradient, tekstur, atau pola apa pun.

Untuk menerapkan solid color fill pada bentuk menggunakan Aspose.Slides, ikuti langkah‑langkah berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) .
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) ke slide.
1. Atur [FillType](https://reference.aspose.com/slides/id/net/aspose.slides/filltype/) bentuk menjadi `Solid` .
1. Tetapkan warna isi pilihan Anda ke bentuk.
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode C# berikut memperlihatkan cara menerapkan solid color fill pada sebuah persegi panjang di slide PowerPoint:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Buat instance kelas Presentation yang mewakili file presentasi.
using (Presentation presentation = new Presentation())
{
    // Dapatkan slide pertama.
    ISlide slide = presentation.Slides[0];

    // Tambahkan auto shape tipe Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Atur tipe isi menjadi Solid.
    shape.FillFormat.FillType = FillType.Solid;

    // Atur warna isi.
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // Simpan file PPTX ke disk.
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![Bentuk dengan solid color fill](solid-color-fill.png)

## **Set Transparency**

Di PowerPoint, ketika Anda menerapkan solid color, gradient, picture, atau texture fill pada bentuk, Anda juga dapat mengatur tingkat transparansi untuk mengontrol opasitas isi. Nilai transparansi yang lebih tinggi membuat bentuk semakin tembus pandang, memungkinkan latar belakang atau objek di bawahnya terlihat sebagian.

Aspose.Slides memungkinkan Anda mengatur tingkat transparansi dengan menyesuaikan nilai alpha pada warna yang digunakan untuk isi. Berikut caranya:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) .
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) ke slide.
1. Atur [FillType](https://reference.aspose.com/slides/id/net/aspose.slides/filltype/) menjadi `Solid` .
1. Gunakan `Color.FromArgb(alpha, baseColor)` untuk mendefinisikan warna dengan transparansi (komponen `alpha` mengontrol transparansi).
1. Simpan presentasi.

Kode C# berikut memperlihatkan cara menerapkan warna isi transparan pada sebuah persegi panjang:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const int alpha = 128;

// Buat instance kelas Presentation yang mewakili file presentasi.
using (Presentation presentation = new Presentation())
{
    // Dapatkan slide pertama.
    ISlide slide = presentation.Slides[0];

    // Tambahkan auto shape persegi panjang solid.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Tambahkan auto shape persegi panjang transparan di atas shape solid.
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // Simpan file PPTX ke disk.
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![Bentuk transparan](shape-transparency.png)

## **Rotate Shapes**

Aspose.Slides memungkinkan Anda memutar bentuk dalam presentasi PowerPoint. Hal ini dapat berguna saat menempatkan elemen visual dengan kebutuhan penyelarasan atau desain khusus.

Untuk memutar bentuk pada slide, ikuti langkah‑langkah berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) .
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) ke slide.
1. Atur properti `Rotation` bentuk ke sudut yang diinginkan.
1. Simpan presentasi.

Kode C# berikut memperlihatkan cara memutar bentuk sebesar 5 derajat:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Buat instance kelas Presentation yang mewakili file presentasi.
using (Presentation presentation = new Presentation())
{
    // Dapatkan slide pertama.
    ISlide slide = presentation.Slides[0];

    // Tambahkan auto shape tipe Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Putar shape sebesar 5 derajat.
    shape.Rotation = 5;

    // Simpan file PPTX ke disk.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![Rotasi bentuk](shape-rotation.png)

## **Add 3D Bevel Effects**

Aspose.Slides memungkinkan Anda menerapkan efek bevel 3D pada bentuk dengan mengonfigurasi properti [ThreeDFormat](https://reference.aspose.com/slides/id/net/aspose.slides/threedformat/)‑nya.

Untuk menambahkan efek bevel 3D pada bentuk, ikuti langkah‑langkah berikut:

1. Instansiasi kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) .
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) ke slide.
1. Konfigurasikan [ThreeDFormat](https://reference.aspose.com/slides/id/net/aspose.slides/threedformat/) bentuk untuk menentukan pengaturan bevel.
1. Simpan presentasi.

Kode C# berikut menunjukkan cara menerapkan efek bevel 3D pada bentuk:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Buat instance kelas Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Tambahkan sebuah bentuk ke slide.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.FillFormat.FillType = FillType.Solid;
    shape.FillFormat.SolidFillColor.Color = Color.Green;
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
    shape.LineFormat.Width = 2.0;

    // Atur properti ThreeDFormat bentuk.
    shape.ThreeDFormat.Depth = 4;
    shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    shape.ThreeDFormat.BevelTop.Height = 6;
    shape.ThreeDFormat.BevelTop.Width = 6;
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

    // Simpan presentasi sebagai file PPTX.
    presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![Efek bevel 3D](3D-bevel-effect.png)

## **Add 3D Rotation Effects**

Aspose.Slides memungkinkan Anda menerapkan efek rotasi 3D pada bentuk dengan mengonfigurasi properti [ThreeDFormat](https://reference.aspose.com/slides/id/net/aspose.slides/threedformat/)‑nya.

Untuk menerapkan rotasi 3D pada bentuk:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) .
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) ke slide.
1. Atur [CameraType](https://reference.aspose.com/slides/id/net/aspose.slides/icamera/cameratype/) dan [LightType](https://reference.aspose.com/slides/id/net/aspose.slides/ilightrig/lighttype/) bentuk untuk mendefinisikan rotasi 3D.
1. Simpan presentasi.

Kode C# berikut memperlihatkan cara menerapkan efek rotasi 3D pada bentuk:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Buat instance kelas Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // Simpan presentasi sebagai file PPTX.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![Efek rotasi 3D](3D-rotation-effect.png)

## **Control Black-and-White Rendering for Shapes**

Properti [IShape.BlackWhiteMode](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/blackwhitemode/) menentukan bagaimana sebuah bentuk individual dirender ketika presentasi dilihat atau diproses dalam mode hitam‑putih. Properti ini tidak mengaktifkan tampilan hitam‑putih sendiri, dan tidak mengubah isi, garis, atau pemformatan lain dari bentuk dalam mode warna normal.

Gunakan nilai dari enumerasi [BlackWhiteMode](https://reference.aspose.com/slides/id/net/aspose.slides/blackwhitemode/) untuk memilih perilaku yang diinginkan. Misalnya, `Automatic` membiarkan aplikasi rendering memilih konversi, `Gray` dan `LightGray` menggunakan warna abu‑abu, `BlackWhite` hanya menggunakan hitam dan putih, `Black` dan `White` memaksa satu warna, `Color` mempertahankan warna normal, dan `Hidden` menghilangkan bentuk dalam mode hitam‑putih. `NotDefined` berarti tidak ada mode level bentuk yang ditetapkan.

Kode C# berikut membuat sebuah bentuk berwarna dan membuatnya muncul abu‑abu dalam mode tampilan hitam‑putih:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;

// Keep the orange fill in color mode, but render the shape with gray coloring in black-and-white mode.
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

Dalam mode warna normal, persegi panjang tetap berisi oranye. Dalam alur kerja tampilan hitam‑putih, ia menggunakan warna abu‑abu karena mode‑nya diatur ke `Gray`. Hal ini memungkinkan Anda mempertahankan slide berwarna penuh sambil mendefinisikan tampilan khusus untuk pencetakan, pratinjau, atau alur kerja lain yang menghormati pengaturan tampilan hitam‑putih presentasi.

## **Reset Formatting**

Kode C# berikut memperlihatkan cara mengatur ulang pemformatan slide dan mengembalikan posisi, ukuran, serta pemformatan semua bentuk dengan placeholder pada [LayoutSlide](https://reference.aspose.com/slides/id/net/aspose.slides/layoutslide/) ke pengaturan defaultnya:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Reset setiap shape pada slide yang memiliki placeholder pada layout.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Apakah pemformatan bentuk mempengaruhi ukuran akhir file presentasi?**

Hanya secara minimal. Gambar dan media yang disematkan memakan sebagian besar ruang file, sedangkan parameter bentuk seperti warna, efek, dan gradient disimpan sebagai metadata dan hampir tidak menambah ukuran.

**Bagaimana cara mendeteksi bentuk pada slide yang memiliki pemformatan identik sehingga saya dapat mengelompokkannya?**

Bandingkan setiap properti pemformatan utama bentuk—pengaturan isi, garis, dan efek. Jika semua nilai yang bersesuaian cocok, perlakukan gaya mereka sebagai identik dan kelompokan bentuk‑bentuk tersebut secara logis, yang mempermudah manajemen gaya nantinya.

**Apakah saya dapat menyimpan sekumpulan gaya bentuk khusus ke file terpisah untuk digunakan kembali di presentasi lain?**

Ya. Simpan bentuk contoh dengan gaya yang diinginkan dalam deck slide templat atau file .POTX. Saat membuat presentasi baru, buka templat tersebut, kloning bentuk bergaya yang diperlukan, dan terapkan kembali pemformatannya sesuai kebutuhan.