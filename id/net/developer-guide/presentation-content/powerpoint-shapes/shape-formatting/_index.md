---
title: Format Bentuk PowerPoint di .NET
linktitle: Pemformatan Bentuk
type: docs
weight: 20
url: /id/net/shape-formatting/
keywords:
- memformat bentuk
- memformat garis
- memformat gaya sambungan
- isian gradien
- isian pola
- isian gambar
- isian tekstur
- isian warna solid
- transparansi bentuk
- memutar bentuk
- efek bevel 3D
- efek rotasi 3D
- mengatur ulang pemformatan
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara memformat bentuk PowerPoint dalam C# menggunakan Aspose.Slides—atur gaya isian, garis, dan efek untuk file PPT dan PPTX dengan presisi dan kontrol penuh."
---
## **Pendahuluan**

Di PowerPoint, Anda dapat menambahkan bentuk ke slide. Karena bentuk terdiri dari garis, Anda dapat memformatnya dengan memodifikasi atau menerapkan efek pada kontur mereka. Selain itu, Anda dapat memformat bentuk dengan menentukan pengaturan yang mengontrol bagaimana interiornya diisi.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for .NET menyediakan antarmuka dan properti yang memungkinkan Anda memformat bentuk menggunakan opsi yang sama tersedia di PowerPoint.

## **Format Garis**

Dengan Aspose.Slides, Anda dapat menentukan gaya garis khusus untuk sebuah bentuk. Langkah‑langkah berikut menjelaskan prosedurnya:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) ke slide.
1. Atur [line style](https://reference.aspose.com/slides/id/net/aspose.slides/linestyle/) bentuk.
1. Atur lebar garis.
1. Atur [dash style](https://reference.aspose.com/slides/id/net/aspose.slides/linedashstyle/) garis.
1. Atur warna garis untuk bentuk.
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Berikut kode C# yang menunjukkan cara memformat sebuah `AutoShape` persegi panjang:

```c#
// Membuat instance kelas Presentation yang mewakili file presentasi.
using (Presentation presentation = new Presentation())
{
    // Dapatkan slide pertama.
    ISlide slide = presentation.Slides[0];

    // Tambahkan auto shape tipe Rectangle.
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

Hasilnya:

![The formatted lines in the presentation](formatted-lines.png)

## **Format Gaya Sambungan**

Berikut tiga opsi tipe sambungan:

* Round
* Miter
* Bevel

Secara default, ketika PowerPoint menggabungkan dua garis pada sudut (misalnya pada sudut sebuah bentuk), ia menggunakan pengaturan **Round**. Namun, jika Anda menggambar bentuk dengan sudut tajam, Anda mungkin lebih memilih opsi **Miter**.

![The join style in the presentation](join-style-powerpoint.png)

Berikut kode C# yang menunjukkan bagaimana tiga persegi panjang (seperti pada gambar di atas) dibuat menggunakan pengaturan sambungan Miter, Bevel, dan Round:

```c#
// Instansiasi kelas Presentation yang mewakili file presentasi.
using (Presentation presentation = new Presentation())
{
    // Dapatkan slide pertama.
    ISlide slide = presentation.Slides[0];

    // Tambahkan tiga auto shape tipe Rectangle.
    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Atur warna isi untuk masing-masing bentuk persegi panjang.
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

    // Atur warna untuk garis masing-masing persegi panjang.
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

    // Tambahkan teks ke masing-masing persegi panjang.
    shape1.TextFrame.Text = "Miter Join Style";
    shape2.TextFrame.Text = "Bevel Join Style";
    shape3.TextFrame.Text = "Round Join Style";

    // Simpan file PPTX ke disk.
    presentation.Save("join_styles.pptx", SaveFormat.Pptx);
}
```

## **Gradient Fill**

Di PowerPoint, Gradient Fill adalah opsi pemformatan yang memungkinkan Anda menerapkan campuran warna berkelanjutan ke sebuah bentuk. Misalnya, Anda dapat menerapkan dua atau lebih warna sehingga satu warna secara bertahap memudar menjadi warna lain.

Berikut cara menerapkan gradient fill ke sebuah bentuk menggunakan Aspose.Slides:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) ke slide.
1. Atur [FillType](https://reference.aspose.com/slides/id/net/aspose.slides/filltype/) bentuk menjadi `Gradient`.
1. Tambahkan dua warna pilihan Anda dengan posisi yang ditentukan menggunakan metode `Add` pada koleksi gradient stop yang disediakan oleh antarmuka [IGradientFormat](https://reference.aspose.com/slides/id/net/aspose.slides/igradientformat/).
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Berikut kode C# yang menunjukkan cara menerapkan efek gradient fill pada sebuah elips:

```c#
// Instansiasi kelas Presentation yang mewakili file presentasi.
using (Presentation presentation = new Presentation())
{
    // Ambil slide pertama.
    ISlide slide = presentation.Slides[0];

    // Tambahkan auto shape tipe Ellipse.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Terapkan pemformatan gradien ke elips.
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // Atur arah gradien.
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // Tambahkan dua stop gradien.
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // Simpan file PPTX ke disk.
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![The ellipse with gradient fill](gradient-fill.png)

## **Pattern Fill**

Di PowerPoint, Pattern Fill adalah opsi pemformatan yang memungkinkan Anda menerapkan desain dua warna—seperti titik, garis, silang, atau kotak—to sebuah bentuk. Anda dapat memilih warna khusus untuk latar depan dan latar belakang pola.

Aspose.Slides menyediakan lebih dari 45 gaya pola bawaan yang dapat Anda terapkan pada bentuk untuk meningkatkan daya tarik visual presentasi Anda. Bahkan setelah memilih pola bawaan, Anda masih dapat menentukan warna tepat yang akan digunakan.

Berikut cara menerapkan pattern fill ke sebuah bentuk menggunakan Aspose.Slides:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) ke slide.
1. Atur [FillType](https://reference.aspose.com/slides/id/net/aspose.slides/filltype/) bentuk menjadi `Pattern`.
1. Pilih gaya pola dari opsi bawaan.
1. Atur [Background Color](https://reference.aspose.com/slides/id/net/aspose.slides/ipatternformat/backcolor/) pola.
1. Atur [Foreground Color](https://reference.aspose.com/slides/id/net/aspose.slides/ipatternformat/forecolor/) pola.
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Berikut kode C# yang menunjukkan cara menerapkan pattern fill pada sebuah persegi panjang:

```c#
// Instansiasi kelas Presentation yang mewakili file presentasi.
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

![The rectangle with pattern fill](pattern-fill.png)

## **Picture Fill**

Di PowerPoint, Picture Fill adalah opsi pemformatan yang memungkinkan Anda menyisipkan gambar di dalam sebuah bentuk—secara efektif menggunakan gambar sebagai latar belakang bentuk.

Berikut cara menggunakan Aspose.Slides untuk menerapkan picture fill ke sebuah bentuk:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) ke slide.
1. Atur [FillType](https://reference.aspose.com/slides/id/net/aspose.slides/filltype/) bentuk menjadi `Picture`.
1. Atur mode picture fill menjadi `Tile` (atau mode lain yang diinginkan).
1. Buat objek [IPPImage](https://reference.aspose.com/slides/id/net/aspose.slides/ippimage/) dari gambar yang ingin Anda gunakan.
1. Tetapkan gambar ini ke properti `Picture.Image` dari `PictureFillFormat` bentuk.
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Misalkan kita memiliki file "lotus.png" dengan gambar berikut:

![The lotus picture](lotus.png)

Berikut kode C# yang menunjukkan cara mengisi sebuah bentuk dengan gambar:

```c#
// Instansiasi kelas Presentation yang mewakili file presentasi.
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

![The shape with picture fill](picture-fill.png)

### **Tile Picture As Texture**

Jika Anda ingin menetapkan gambar berulang sebagai tekstur dan menyesuaikan perilaku pengulangan, Anda dapat menggunakan properti berikut dari antarmuka [IPictureFillFormat](https://reference.aspose.com/slides/id/net/aspose.slides/ipicturefillformat/) dan kelas [PictureFillFormat](https://reference.aspose.com/slides/id/net/aspose.slides/picturefillformat/):

- [PictureFillMode](https://reference.aspose.com/slides/id/net/aspose.slides/ipicturefillformat/picturefillmode/): Menetapkan mode picture fill—baik `Tile` maupun `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/id/net/aspose.slides/ipicturefillformat/tilealignment/): Menentukan perataan ubin dalam bentuk.
- [TileFlip](https://reference.aspose.com/slides/id/net/aspose.slides/ipicturefillformat/tileflip/): Mengontrol apakah ubin dibalik secara horizontal, vertikal, atau keduanya.
- [TileOffsetX](https://reference.aspose.com/slides/id/net/aspose.slides/ipicturefillformat/tileoffsetx/): Menetapkan offset horizontal ubin (dalam poin) dari asal bentuk.
- [TileOffsetY](https://reference.aspose.com/slides/id/net/aspose.slides/ipicturefillformat/tileoffsety/): Menetapkan offset vertikal ubin (dalam poin) dari asal bentuk.
- [TileScaleX](https://reference.aspose.com/slides/id/net/aspose.slides/ipicturefillformat/tilescalex/): Menentukan skala horizontal ubin dalam persentase.
- [TileScaleY](https://reference.aspose.com/slides/id/net/aspose.slides/ipicturefillformat/tilescaley/): Menentukan skala vertikal ubin dalam persentase.

Berikut contoh kode yang menunjukkan cara menambahkan sebuah bentuk persegi panjang dengan picture fill berulang dan mengkonfigurasi opsi ubin:

```c#
// Membuat instance kelas Presentation yang mewakili file presentasi.
using (Presentation presentation = new Presentation())
{
    // Ambil slide pertama.
    ISlide firstSlide = presentation.Slides[0];

    // Tambahkan auto shape persegi panjang.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Atur tipe isi bentuk menjadi Picture.
    shape.FillFormat.FillType = FillType.Picture;

    // Muat gambar dan tambahkan ke sumber daya presentasi.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // Tetapkan gambar ke bentuk.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // Konfigurasi mode picture fill dan properti pengulangan.
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

![The tile options](tile-options.png)

## **Solid Color Fill**

Di PowerPoint, Solid Color Fill adalah opsi pemformatan yang mengisi sebuah bentuk dengan satu warna seragam. Latar belakang berwarna polos ini diterapkan tanpa gradien, tekstur, atau pola apapun.

Untuk menerapkan solid color fill ke sebuah bentuk menggunakan Aspose.Slides, ikuti langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) ke slide.
1. Atur [FillType](https://reference.aspose.com/slides/id/net/aspose.slides/filltype/) bentuk menjadi `Solid`.
1. Tetapkan warna isi yang Anda pilih ke bentuk.
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Berikut kode C# yang menunjukkan cara menerapkan solid color fill pada sebuah persegi panjang di slide PowerPoint:

```c#
// Membuat instance kelas Presentation yang mewakili file presentasi.
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

![The shape with solid color fill](solid-color-fill.png)

## **Set Transparency**

Di PowerPoint, ketika Anda menerapkan solid color, gradient, picture, atau texture fill ke bentuk, Anda juga dapat mengatur tingkat transparansi untuk mengontrol opasitas isi. Nilai transparansi yang lebih tinggi membuat bentuk menjadi lebih tembus pandang, memungkinkan latar belakang atau objek di bawahnya terlihat sebagian.

Aspose.Slides memungkinkan Anda mengatur tingkat transparansi dengan menyesuaikan nilai alpha pada warna yang digunakan untuk isi. Berikut cara melakukannya:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) ke slide.
1. Atur [FillType](https://reference.aspose.com/slides/id/net/aspose.slides/filltype/) menjadi `Solid`.
1. Gunakan `Color.FromArgb(alpha, baseColor)` untuk mendefinisikan warna dengan transparansi (komponen `alpha` mengontrol transparansi).
1. Simpan presentasi.

Berikut kode C# yang menunjukkan cara menerapkan warna isi transparan ke sebuah persegi panjang:

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

Hasilnya:

![The transparent shape](shape-transparency.png)

## **Rotate Shapes**

Aspose.Slides memungkinkan Anda memutar bentuk dalam presentasi PowerPoint. Ini dapat berguna ketika menempatkan elemen visual dengan kebutuhan penyelarasan atau desain tertentu.

Untuk memutar sebuah bentuk pada slide, ikuti langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) ke slide.
1. Atur properti `Rotation` bentuk ke sudut yang diinginkan.
1. Simpan presentasi.

Berikut kode C# yang menunjukkan cara memutar sebuah bentuk sebesar 5 derajat:

```c#
// Membuat instance kelas Presentation yang mewakili file presentasi.
using (Presentation presentation = new Presentation())
{
    // Dapatkan slide pertama.
    ISlide slide = presentation.Slides[0];

    // Tambahkan auto shape tipe Rectangle.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Putar bentuk sebesar 5 derajat.
    shape.Rotation = 5;

    // Simpan file PPTX ke disk.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

Hasilnya:

![The shape rotation](shape-rotation.png)

## **Add 3D Bevel Effects**

Aspose.Slides memungkinkan Anda menerapkan efek bevel 3D ke bentuk dengan mengkonfigurasi properti [ThreeDFormat](https://reference.aspose.com/slides/id/net/aspose.slides/threedformat/).

Untuk menambahkan efek bevel 3D ke sebuah bentuk, ikuti langkah berikut:

1. Instansiasikan kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) ke slide.
1. Konfigurasikan [ThreeDFormat](https://reference.aspose.com/slides/id/net/aspose.slides/threedformat/) bentuk untuk mendefinisikan pengaturan bevel.
1. Simpan presentasi.

Berikut kode C# yang menunjukkan cara menerapkan efek bevel 3D ke sebuah bentuk:

```c#
// Buat instance kelas Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Tambahkan shape ke slide.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.FillFormat.FillType = FillType.Solid;
    shape.FillFormat.SolidFillColor.Color = Color.Green;
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
    shape.LineFormat.Width = 2.0;

    // Atur properti ThreeDFormat shape.
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

![The 3D bevel effect](3D-bevel-effect.png)

## **Add 3D Rotation Effects**

Aspose.Slides memungkinkan Anda menerapkan efek rotasi 3D ke bentuk dengan mengkonfigurasi properti [ThreeDFormat](https://reference.aspose.com/slides/id/net/aspose.slides/threedformat/).

Untuk menerapkan rotasi 3D ke sebuah bentuk:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) ke slide.
1. Atur [CameraType](https://reference.aspose.com/slides/id/net/aspose.slides/icamera/cameratype/) dan [LightType](https://reference.aspose.com/slides/id/net/aspose.slides/ilightrig/lighttype/) bentuk untuk menentukan rotasi 3D.
1. Simpan presentasi.

Berikut kode C# yang menunjukkan cara menerapkan efek rotasi 3D ke sebuah bentuk:

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

Hasilnya:

![The 3D rotation effect](3D-rotation-effect.png)

## **Reset Formatting**

Berikut kode C# yang menunjukkan cara mengatur ulang pemformatan slide dan mengembalikan posisi, ukuran, serta pemformatan semua bentuk dengan placeholder pada [LayoutSlide](https://reference.aspose.com/slides/id/net/aspose.slides/layoutslide/) ke pengaturan default mereka:

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Atur ulang setiap bentuk pada slide yang memiliki placeholder pada layout.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Apakah pemformatan bentuk memengaruhi ukuran file presentasi akhir?**

Hanya sedikit. Gambar dan media yang disematkan menempati sebagian besar ruang file, sementara parameter bentuk seperti warna, efek, dan gradien disimpan sebagai metadata dan hampir tidak menambah ukuran ekstra.

**Bagaimana saya dapat mendeteksi bentuk pada slide yang memiliki pemformatan identik sehingga saya dapat mengelompokkannya?**

Bandingkan setiap properti pemformatan utama bentuk—pengaturan isi, garis, dan efek. Jika semua nilai yang bersesuaian cocok, anggap gaya mereka identik dan kelompokkan bentuk‑bentuk tersebut secara logis, yang menyederhanakan manajemen gaya di kemudian hari.

**Bisakah saya menyimpan sekumpulan gaya bentuk khusus ke file terpisah untuk digunakan kembali di presentasi lain?**

Ya. Simpan bentuk contoh dengan gaya yang diinginkan dalam slide templat atau file .POTX. Saat membuat presentasi baru, buka templat tersebut, kloning bentuk bergaya yang Anda butuhkan, dan terapkan kembali pemformatannya di mana diperlukan.