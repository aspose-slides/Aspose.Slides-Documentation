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
- isian gradien
- isian pola
- isian gambar
- isian tekstur
- isian warna solid
- transparansi bentuk
- putar bentuk
- efek bevel 3D
- efek rotasi 3D
- atur ulang pemformatan
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara memformat bentuk PowerPoint dalam C# menggunakan Aspose.Slides—atur gaya isian, garis, dan efek untuk file PPT dan PPTX dengan presisi dan kontrol penuh."
---
## **Pendahuluan**

Di PowerPoint, Anda dapat menambahkan bentuk ke slide. Karena bentuk terdiri dari garis, Anda dapat memformatnya dengan memodifikasi atau menerapkan efek pada kontur mereka. Selain itu, Anda dapat memformat bentuk dengan menentukan pengaturan yang mengontrol bagaimana bagian dalamnya diisi.

![format-bentuk-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for .NET menyediakan antarmuka dan properti yang memungkinkan Anda memformat bentuk dengan menggunakan opsi yang sama tersedia di PowerPoint.

## **Format Garis**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) .
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) ke slide.
1. Atur [line style](https://reference.aspose.com/slides/id/net/aspose.slides/linestyle/) bentuk.
1. Atur lebar garis.
1. Atur [dash style](https://reference.aspose.com/slides/id/net/aspose.slides/linedashstyle/) garis.
1. Atur warna garis untuk bentuk.
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

```c#
// Membuat instance kelas Presentation yang mewakili file presentasi.
using (Presentation presentation = new Presentation())
{
    // Dapatkan slide pertama.
    ISlide slide = presentation.Slides[0];

    // Tambahkan auto shape tipe Persegi Panjang.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Atur warna isi untuk bentuk persegi panjang.
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

![Garis yang diformat dalam presentasi](formatted-lines.png)

## **Terapkan Efek Sketsa pada Garis Bentuk**

Efek sketsa membuat garis bentuk terlihat seperti digambar tangan. Gunakan [IShape.LineFormat](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/lineformat/) untuk mengakses pengaturan garis, [ILineFormat.SketchFormat](https://reference.aspose.com/slides/id/net/aspose.slides/ilineformat/sketchformat/) untuk mengakses pengaturan sketsa, dan [ISketchFormat.SketchType](https://reference.aspose.com/slides/id/net/aspose.slides/isketchformat/sketchtype/) untuk memilih nilai dari enumerasi [LineSketchType](https://reference.aspose.com/slides/id/net/aspose.slides/linesketchtype/).

Kode C# berikut menunjukkan cara menerapkan efek [LineSketchType.Curved](https://reference.aspose.com/slides/id/net/aspose.slides/linesketchtype/) , membaca nilai yang ditetapkan secara eksplisit, dan menghapus efek dengan [LineSketchType.None](https://reference.aspose.com/slides/id/net/aspose.slides/linesketchtype/) :

```csharp
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

Nilai yang dikembalikan oleh `ISketchFormat.SketchType` mewakili pengaturan yang ditetapkan langsung ke bentuk. Jika pemformatan garis dapat diwarisi dari tema, master slide, atau layout slide, gunakan [ILineFormat.GetEffective](https://reference.aspose.com/slides/id/net/aspose.slides/ilineformat/geteffective/) , akses [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/id/net/aspose.slides/ilineformateffectivedata/sketchformat/) , dan baca [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/id/net/aspose.slides/isketchformateffectivedata/sketchtype/) . Nilai efektif mencerminkan pemformatan yang sebenarnya diterapkan setelah pewarisan diselesaikan :

```csharp
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

* Bulat
* Miter
* Bevel

Secara default, ketika PowerPoint menggabungkan dua garis pada sudut (seperti pada sudut bentuk), ia menggunakan pengaturan **Bulat**. Namun, jika Anda menggambar bentuk dengan sudut tajam, Anda mungkin lebih memilih opsi **Miter**.

![Gaya sambungan dalam presentasi](join-style-powerpoint.png)

Kode C# berikut menunjukkan bagaimana tiga persegi panjang (seperti pada gambar di atas) dibuat menggunakan pengaturan tipe sambungan Miter, Bevel, dan Bulat :

```c#
// Instansiasi kelas Presentation yang mewakili file presentasi.
using (Presentation presentation = new Presentation())
{
    // Dapatkan slide pertama.
    ISlide slide = presentation.Slides[0];

    // Tambahkan tiga auto shape tipe Persegi Panjang.
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

## **Isian Gradien**

Di PowerPoint, Isian Gradien adalah opsi pemformatan yang memungkinkan Anda menerapkan perpaduan warna kontinu ke sebuah bentuk. Misalnya, Anda dapat menerapkan dua atau lebih warna sehingga satu secara bertahap memudar menjadi warna lainnya.

Berikut cara menerapkan isian gradien ke sebuah bentuk menggunakan Aspose.Slides:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) .
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) ke slide.
4. Atur [FillType](https://reference.aspose.com/slides/id/net/aspose.slides/filltype/) bentuk menjadi `Gradient` .
5. Tambahkan dua warna pilihan Anda dengan posisi yang ditentukan menggunakan metode `Add` dari koleksi gradient stop yang disediakan oleh antarmuka [IGradientFormat](https://reference.aspose.com/slides/id/net/aspose.slides/igradientformat/) .
6. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

```c#
// Membuat instance kelas Presentation yang mewakili file presentasi.
using (Presentation presentation = new Presentation())
{
    // Dapatkan slide pertama.
    ISlide slide = presentation.Slides[0];

    // Tambahkan auto shape tipe Ellipse.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Terapkan pemformatan gradien pada ellips.
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

![Elips dengan isian gradien](gradient-fill.png)

## **Isian Pola**

Di PowerPoint, Isian Pola adalah opsi pemformatan yang memungkinkan Anda menerapkan desain dua warna—seperti titik, garis, silang, atau kotak—to sebuah bentuk. Anda dapat memilih warna khusus untuk latar depan dan latar belakang pola.

Aspose.Slides menyediakan lebih dari 45 gaya pola pra‑definisi yang dapat Anda terapkan pada bentuk untuk meningkatkan daya tarik visual presentasi Anda. Bahkan setelah memilih pola pra‑definisi, Anda masih dapat menentukan warna tepat yang harus digunakan.

Berikut cara menerapkan isian pola ke sebuah bentuk menggunakan Aspose.Slides:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) .
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) ke slide.
4. Atur [FillType](https://reference.aspose.com/slides/id/net/aspose.slides/filltype/) bentuk menjadi `Pattern` .
5. Pilih gaya pola dari opsi pra‑definisi.
6. Atur [Background Color](https://reference.aspose.com/slides/id/net/aspose.slides/ipatternformat/backcolor/) pola.
7. Atur [Foreground Color](https://reference.aspose.com/slides/id/net/aspose.slides/ipatternformat/forecolor/) pola.
8. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

```c#
// Membuat instance kelas Presentation yang mewakili file presentasi.
using (Presentation presentation = new Presentation())
{
    // Dapatkan slide pertama.
    ISlide slide = presentation.Slides[0];

    // Tambahkan auto shape tipe Persegi Panjang.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Atur tipe isian menjadi Pola.
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

![Persegi panjang dengan isian pola](pattern-fill.png)

## **Isian Gambar**

Di PowerPoint, Isian Gambar adalah opsi pemformatan yang memungkinkan Anda menyisipkan gambar di dalam sebuah bentuk—secara efektif menggunakan gambar sebagai latar belakang bentuk.

Berikut cara menggunakan Aspose.Slides untuk menerapkan isian gambar ke sebuah bentuk:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) .
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) ke slide.
4. Atur [FillType](https://reference.aspose.com/slides/id/net/aspose.slides/filltype/) bentuk menjadi `Picture` .
5. Atur mode isian gambar menjadi `Tile` (atau mode lain yang diinginkan).
6. Buat objek [IPPImage](https://reference.aspose.com/slides/id/net/aspose.slides/ippimage/) dari gambar yang ingin Anda gunakan.
7. Tetapkan gambar ini ke properti `Picture.Image` dari `PictureFillFormat` bentuk.
8. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Misalkan kami memiliki file "lotus.png" dengan gambar berikut:

![Gambar lotus](lotus.png)

```c#
// Membuat instance kelas Presentation yang mewakili file presentasi.
using (Presentation presentation = new Presentation())
{
    // Dapatkan slide pertama.
    ISlide slide = presentation.Slides[0];

    // Tambahkan auto shape tipe Persegi Panjang.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // Atur tipe isian menjadi Gambar.
    shape.FillFormat.FillType = FillType.Picture;

    // Atur mode isian gambar.
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

![Bentuk dengan isian gambar](picture-fill.png)

### **Tile Gambar Sebagai Tekstur**

Jika Anda ingin mengatur gambar berulang sebagai tekstur dan menyesuaikan perilaku pengulangan, Anda dapat menggunakan properti berikut dari antarmuka [IPictureFillFormat](https://reference.aspose.com/slides/id/net/aspose.slides/ipicturefillformat/) dan kelas [PictureFillFormat](https://reference.aspose.com/slides/id/net/aspose.slides/picturefillformat/) :

- [PictureFillMode](https://reference.aspose.com/slides/id/net/aspose.slides/ipicturefillformat/picturefillmode/) : Mengatur mode isian gambar—baik `Tile` maupun `Stretch` .
- [TileAlignment](https://reference.aspose.com/slides/id/net/aspose.slides/ipicturefillformat/tilealignment/) : Menentukan perataan ubin dalam bentuk.
- [TileFlip](https://reference.aspose.com/slides/id/net/aspose.slides/ipicturefillformat/tileflip/) : Mengontrol apakah ubin dibalik secara horizontal, vertikal, atau keduanya.
- [TileOffsetX](https://reference.aspose.com/slides/id/net/aspose.slides/ipicturefillformat/tileoffsetx/) : Mengatur offset horizontal ubin (dalam poin) dari asal bentuk.
- [TileOffsetY](https://reference.aspose.com/slides/id/net/aspose.slides/ipicturefillformat/tileoffsety/) : Mengatur offset vertikal ubin (dalam poin) dari asal bentuk.
- [TileScaleX](https://reference.aspose.com/slides/id/net/aspose.slides/ipicturefillformat/tilescalex/) : Menentukan skala horizontal ubin dalam persen.
- [TileScaleY](https://reference.aspose.com/slides/id/net/aspose.slides/ipicturefillformat/tilescaley/) : Menentukan skala vertikal ubin dalam persen.

Contoh kode berikut menunjukkan cara menambahkan bentuk persegi panjang dengan isian gambar berulang dan mengonfigurasi opsi ubin :

```c#
// Membuat instance kelas Presentation yang mewakili file presentasi.
using (Presentation presentation = new Presentation())
{
    // Dapatkan slide pertama.
    ISlide firstSlide = presentation.Slides[0];

    // Tambahkan auto shape persegi panjang.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Atur tipe isian bentuk menjadi Gambar.
    shape.FillFormat.FillType = FillType.Picture;

    // Muat gambar dan tambahkan ke sumber daya presentasi.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // Tetapkan gambar ke bentuk.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // Konfigurasikan mode isian gambar dan properti pengulangan.
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

![Opsi ubin](tile-options.png)

## **Isian Warna Solid**

Di PowerPoint, Isian Warna Solid adalah opsi pemformatan yang mengisi sebuah bentuk dengan satu warna seragam. Warna latar belakang sederhana ini diterapkan tanpa gradien, tekstur, atau pola apa pun.

Untuk menerapkan isian warna solid ke sebuah bentuk menggunakan Aspose.Slides, ikuti langkah-langkah berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) .
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) ke slide.
4. Atur [FillType](https://reference.aspose.com/slides/id/net/aspose.slides/filltype/) bentuk menjadi `Solid` .
5. Tetapkan warna isian pilihan Anda ke bentuk.
6. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

```c#
 // Instansiasi kelas Presentation yang mewakili file presentasi.
 using (Presentation presentation = new Presentation())
 {
     // Dapatkan slide pertama.
     ISlide slide = presentation.Slides[0];

     // Tambahkan auto shape tipe Persegi Panjang.
     IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

     // Atur tipe isian menjadi Solid.
     shape.FillFormat.FillType = FillType.Solid;

     // Atur warna isian.
     shape.FillFormat.SolidFillColor.Color = Color.Yellow;

     // Simpan file PPTX ke disk.
     presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
 }
```

![Bentuk dengan isian warna solid](solid-color-fill.png)

## **Atur Transparansi**

Di PowerPoint, ketika Anda menerapkan isian warna solid, gradien, gambar, atau tekstur pada bentuk, Anda juga dapat mengatur tingkat transparansi untuk mengontrol opasitas isian. Nilai transparansi yang lebih tinggi membuat bentuk lebih tembus, memungkinkan latar belakang atau objek di bawahnya terlihat sebagian.

Aspose.Slides memungkinkan Anda mengatur tingkat transparansi dengan menyesuaikan nilai alpha pada warna yang digunakan untuk isian. Berikut cara melakukannya:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) .
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) ke slide.
4. Atur [FillType](https://reference.aspose.com/slides/id/net/aspose.slides/filltype/) menjadi `Solid` .
5. Gunakan `Color.FromArgb(alpha, baseColor)` untuk mendefinisikan warna dengan transparansi (komponen `alpha` mengontrol transparansi) .
6. Simpan presentasi.

```c#
const int alpha = 128;

// Membuat instance kelas Presentation yang mewakili file presentasi.
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

![Bentuk transparan](shape-transparency.png)

## **Putar Bentuk**

Aspose.Slides memungkinkan Anda memutar bentuk dalam presentasi PowerPoint. Hal ini dapat berguna saat menempatkan elemen visual dengan kebutuhan perataan atau desain tertentu.

Untuk memutar bentuk pada slide, ikuti langkah-langkah berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) .
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) ke slide.
4. Atur properti `Rotation` bentuk ke sudut yang diinginkan.
5. Simpan presentasi.

```c#
 // Membuat instance kelas Presentation yang mewakili file presentasi.
 using (Presentation presentation = new Presentation())
 {
     // Dapatkan slide pertama.
     ISlide slide = presentation.Slides[0];

     // Tambahkan auto shape tipe Persegi Panjang.
     IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

     // Putar bentuk sebesar 5 derajat.
     shape.Rotation = 5;

     // Simpan file PPTX ke disk.
     presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
 }
```

![Rotasi bentuk](shape-rotation.png)

## **Tambahkan Efek Bevel 3D**

Aspose.Slides memungkinkan Anda menerapkan efek bevel 3D pada bentuk dengan mengonfigurasi properti [ThreeDFormat](https://reference.aspose.com/slides/id/net/aspose.slides/threedformat/) mereka.

Untuk menambahkan efek bevel 3D pada bentuk, ikuti langkah-langkah berikut:

1. Instansiasi kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) .
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) ke slide.
4. Konfigurasikan [ThreeDFormat](https://reference.aspose.com/slides/id/net/aspose.slides/threedformat/) bentuk untuk mendefinisikan pengaturan bevel.
5. Simpan presentasi.

```c#
 // Buat instance kelas Presentation.
 using (Presentation presentation = new Presentation())
 {
     ISlide slide = presentation.Slides[0];

     // Tambahkan bentuk ke slide.
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

![Efek bevel 3D](3D-bevel-effect.png)

## **Tambahkan Efek Rotasi 3D**

Aspose.Slides memungkinkan Anda menerapkan rotasi 3D pada bentuk dengan mengonfigurasi properti [ThreeDFormat](https://reference.aspose.com/slides/id/net/aspose.slides/threedformat/) mereka.

Untuk menerapkan rotasi 3D pada bentuk:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) .
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) ke slide.
4. Atur [CameraType](https://reference.aspose.com/slides/id/net/aspose.slides/icamera/cameratype/) dan [LightType](https://reference.aspose.com/slides/id/net/aspose.slides/ilightrig/lighttype/) bentuk untuk mendefinisikan rotasi 3D.
5. Simpan presentasi.

```c#
 // Buat instance kelas Presentation.
 using (Presentation presentation = new Presentation())
 {
     ISlide slide = presentation.Slides[0];

     IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
     autoShape.TextFrame.Text = "Hello, Aspose!";

     autoShape.ThreeDFormat.Depth = 6;
     autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
     autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
     autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

     // Simpan presentasi sebagai file PPTX.
     presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
 }
```

![Efek rotasi 3D](3D-rotation-effect.png)

## **Atur Ulang Pemformatan**

Kode C# berikut menunjukkan cara mengatur ulang pemformatan slide dan mengembalikan posisi, ukuran, serta pemformatan semua bentuk dengan placeholder di [LayoutSlide](https://reference.aspose.com/slides/id/net/aspose.slides/layoutslide/) ke pengaturan default mereka:

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Atur ulang setiap shape pada slide yang memiliki placeholder pada layout.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Apakah pemformatan bentuk memengaruhi ukuran file presentasi akhir?**

Hanya sedikit. Gambar dan media yang disematkan mengambil sebagian besar ruang file, sementara parameter bentuk seperti warna, efek, dan gradien disimpan sebagai metadata dan hampir tidak menambah ukuran tambahan.

**Bagaimana saya dapat mendeteksi bentuk pada slide yang memiliki pemformatan identik sehingga saya dapat mengelompokkannya?**

Bandingkan setiap properti pemformatan utama bentuk—pengaturan isian, garis, dan efek. Jika semua nilai yang bersesuaian cocok, anggap gaya mereka identik dan kelompokkan bentuk-bentuk tersebut secara logis, yang mempermudah manajemen gaya di kemudian hari.

**Bisakah saya menyimpan sekumpulan gaya bentuk khusus ke file terpisah untuk digunakan kembali di presentasi lain?**

Ya. Simpan contoh bentuk dengan gaya yang diinginkan dalam deck slide template atau file template .POTX. Saat membuat presentasi baru, buka template tersebut, kloning bentuk bergaya yang Anda butuhkan, dan terapkan kembali pemformatannya di mana pun diperlukan.