---
title: Format Bentuk PowerPoint di Java
linktitle: Pemformatan Bentuk
type: docs
weight: 20
url: /id/java/shape-formatting/
keywords:
- format bentuk
- format garis
- format gaya sambungan
- isi gradien
- isi pola
- isi gambar
- isi tekstur
- isi warna solid
- transparansi bentuk
- rotasi bentuk
- efek bevel 3D
- efek rotasi 3D
- reset pemformatan
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Pelajari cara memformat bentuk PowerPoint di Java menggunakan Aspose.Slides—atur gaya isi, garis, dan efek untuk file PPT, PPTX, dan ODP dengan presisi dan kontrol penuh."
---
## **Pendahuluan**

Di PowerPoint, Anda dapat menambahkan bentuk ke slide. Karena bentuk terdiri dari garis, Anda dapat memformatnya dengan memodifikasi atau menerapkan efek pada garis tepinya. Selain itu, Anda dapat memformat bentuk dengan menentukan pengaturan yang mengontrol bagaimana interiornya diisi.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Java menyediakan antarmuka dan metode yang memungkinkan Anda memformat bentuk menggunakan opsi yang sama tersedia di PowerPoint.

## **Format Garis**

Menggunakan Aspose.Slides, Anda dapat menentukan gaya garis khusus untuk sebuah bentuk. Langkah-langkah berikut menjelaskan prosedurnya:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/) ke slide.
1. Atur [line style](https://reference.aspose.com/slides/id/java/com.aspose.slides/linestyle/) bentuk.
1. Atur lebar garis.
1. Atur [dash style](https://reference.aspose.com/slides/id/java/com.aspose.slides/linedashstyle/) garis.
1. Atur warna garis untuk bentuk.
1. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Kode berikut menunjukkan cara memformat sebuah `AutoShape` persegi panjang:

```java
// Instansiasi kelas Presentation yang mewakili file presentasi.
Presentation presentation = new Presentation();
try {
    // Dapatkan slide pertama.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Tambahkan auto shape dengan tipe Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Atur warna isian untuk bentuk persegi panjang.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Terapkan pemformatan pada garis persegi panjang.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Atur warna untuk garis persegi panjang.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Simpan file PPTX ke disk.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Garis yang diformat dalam presentasi](formatted-lines.png)

## **Format Gaya Sambungan**

Berikut tiga opsi jenis sambungan:

* Round
* Miter
* Bevel

Secara default, ketika PowerPoint menggabungkan dua garis pada sudut (seperti pada sudut bentuk), ia menggunakan pengaturan **Round**. Namun, jika Anda menggambar bentuk dengan sudut tajam, Anda mungkin lebih menyukai opsi **Miter**.

![Gaya sambungan dalam presentasi](join-style-powerpoint.png)

Kode Java berikut menunjukkan bagaimana tiga persegi panjang (seperti pada gambar di atas) dibuat menggunakan pengaturan jenis sambungan Miter, Bevel, dan Round:

```java
// Instansiasi kelas Presentation yang mewakili file presentasi.
Presentation presentation = new Presentation();
try {
    // Dapatkan slide pertama.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Tambahkan tiga auto shape dengan tipe Rectangle.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Atur warna isi untuk setiap bentuk persegi panjang.
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Atur lebar garis.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Atur warna untuk garis setiap persegi panjang.
    shape1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Atur gaya sambungan.
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // Tambahkan teks ke setiap persegi panjang.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Simpan file PPTX ke disk.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gradient Fill**

Di PowerPoint, Gradient Fill adalah opsi pemformatan yang memungkinkan Anda menerapkan perpaduan warna berkelanjutan pada sebuah bentuk. Misalnya, Anda dapat menerapkan dua atau lebih warna dengan cara satu secara bertahap memudar ke warna lainnya.

Berikut cara menerapkan gradient fill ke sebuah bentuk menggunakan Aspose.Slides:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/) ke slide.
1. Atur [FillType](https://reference.aspose.com/slides/id/java/com.aspose.slides/filltype/) bentuk menjadi `Gradient`.
1. Tambahkan dua warna pilihan Anda dengan posisi yang ditentukan menggunakan metode `add` dari koleksi gradient stop yang disediakan oleh antarmuka [IGradientFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/igradientformat/).
1. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Kode Java berikut menunjukkan cara menerapkan efek gradient fill ke sebuah elips:

```java
// Instansiasi kelas Presentation yang mewakili file presentasi.
Presentation presentation = new Presentation();
try {
    // Dapatkan slide pertama.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Tambahkan auto shape dengan tipe Ellipse.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Terapkan pemformatan gradien ke elips.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Atur arah gradien.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Tambahkan dua titik henti gradien.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Simpan file PPTX ke disk.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Elips dengan gradient fill](gradient-fill.png)

## **Pattern Fill**

Di PowerPoint, Pattern Fill adalah opsi pemformatan yang memungkinkan Anda menerapkan desain dua warna—seperti titik, garis, silang, atau kotak—ke sebuah bentuk. Anda dapat memilih warna khusus untuk latar depan dan latar belakang pola.

Aspose.Slides menyediakan lebih dari 45 gaya pola pra‑definisi yang dapat Anda terapkan pada bentuk untuk meningkatkan daya tarik visual presentasi Anda. Bahkan setelah memilih pola pra‑definisi, Anda masih dapat menentukan warna tepat yang harus digunakan.

Berikut cara menerapkan pattern fill ke sebuah bentuk menggunakan Aspose.Slides:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/) ke slide.
1. Atur [FillType](https://reference.aspose.com/slides/id/java/com.aspose.slides/filltype/) bentuk menjadi `Pattern`.
1. Pilih gaya pola dari opsi pra‑definisi.
1. Atur [Background Color](https://reference.aspose.com/slides/id/java/com.aspose.slides/patternformat/#getBackColor--) pola.
1. Atur [Foreground Color](https://reference.aspose.com/slides/id/java/com.aspose.slides/patternformat/#getForeColor--) pola.
1. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Kode Java berikut menunjukkan cara menerapkan pattern fill ke sebuah persegi panjang:

```java
// Instansiasi kelas Presentation yang mewakili file presentasi.
Presentation presentation = new Presentation();
try {
    // Dapatkan slide pertama.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Tambahkan auto shape dengan tipe Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Atur tipe isian menjadi Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // Atur gaya pola.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // Atur warna latar belakang dan latar depan pola.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Simpan file PPTX ke disk.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Persegi panjang dengan pattern fill](pattern-fill.png)

## **Picture Fill**

Di PowerPoint, Picture Fill adalah opsi pemformatan yang memungkinkan Anda menyisipkan gambar di dalam sebuah bentuk—secara efektif menggunakan gambar sebagai latar belakang bentuk.

Berikut cara menggunakan Aspose.Slides untuk menerapkan picture fill ke sebuah bentuk:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/) ke slide.
1. Atur [FillType](https://reference.aspose.com/slides/id/java/com.aspose.slides/filltype/) bentuk menjadi `Picture`.
1. Atur mode picture fill menjadi `Tile` (atau mode lain yang diinginkan).
1. Buat objek [IPPImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/ippimage/) dari gambar yang ingin Anda gunakan.
1. Berikan gambar ke metode `ISlidesPicture.setImage`.
1. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Misalkan kita memiliki file "lotus.png" dengan gambar berikut:

![Gambar lotus](lotus.png)

Kode Java berikut memperlihatkan cara mengisi sebuah bentuk dengan gambar:

```java
// Instansiasi kelas Presentation yang mewakili file presentasi.
Presentation presentation = new Presentation();
try {
    // Dapatkan slide pertama.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Tambahkan auto shape dengan tipe Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Atur tipe isian menjadi Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Atur mode pengisian gambar.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Muat gambar dan tambahkan ke sumber daya presentasi.
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // Atur gambar.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Simpan file PPTX ke disk.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Bentuk dengan picture fill](picture-fill.png)

### **Tile Picture As Texture**

Jika Anda ingin menetapkan gambar berulang sebagai tekstur dan menyesuaikan perilaku penataan, Anda dapat menggunakan metode berikut dari antarmuka [IPictureFillFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipicturefillformat/) dan kelas [PictureFillFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Menetapkan mode picture fill—baik `Tile` maupun `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Menentukan perataan ubin di dalam bentuk.
- [setTileFlip](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Mengontrol apakah ubin dibalik secara horizontal, vertikal, atau keduanya.
- [setTileOffsetX](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Menetapkan offset horizontal ubin (dalam poin) dari asal bentuk.
- [setTileOffsetY](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Menetapkan offset vertikal ubin (dalam poin) dari asal bentuk.
- [setTileScaleX](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Mendefinisikan skala horizontal ubin dalam persentase.
- [setTileScaleY](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Mendefinisikan skala vertikal ubin dalam persentase.

Contoh kode berikut menunjukkan cara menambahkan bentuk persegi panjang dengan picture fill berulang dan mengonfigurasi opsi ubin:

```java
// Instansiasi kelas Presentation yang mewakili file presentasi.
Presentation presentation = new Presentation();
try {
    // Dapatkan slide pertama.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Tambahkan auto shape persegi panjang.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Atur tipe isian bentuk menjadi Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Muat gambar dan tambahkan ke sumber daya presentasi.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Tetapkan gambar ke bentuk.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Konfigurasikan mode pengisian gambar dan properti ubin.
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // Simpan file PPTX ke disk.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Opsi ubin](tile-options.png)

## **Solid Color Fill**

Di PowerPoint, Solid Color Fill adalah opsi pemformatan yang mengisi sebuah bentuk dengan satu warna seragam. Latar belakang berwarna polos ini diterapkan tanpa gradien, tekstur, atau pola apa pun.

Untuk menerapkan solid color fill ke sebuah bentuk menggunakan Aspose.Slides, ikuti langkah-langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/) ke slide.
1. Atur [FillType](https://reference.aspose.com/slides/id/java/com.aspose.slides/filltype/) bentuk menjadi `Solid`.
1. Tetapkan warna isian pilihan Anda ke bentuk.
1. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Kode Java berikut memperlihatkan cara menerapkan solid color fill ke sebuah persegi panjang dalam slide PowerPoint:

```java
// Instansiasi kelas Presentation yang mewakili file presentasi.
Presentation presentation = new Presentation();
try {
    // Dapatkan slide pertama.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Tambahkan auto shape dengan tipe Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Atur tipe isian menjadi Solid.
    shape.getFillFormat().setFillType(FillType.Solid);

    // Atur warna isi.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // Simpan file PPTX ke disk.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Bentuk dengan solid color fill](solid-color-fill.png)

## **Set Transparency**

Di PowerPoint, ketika Anda menerapkan isian berwarna solid, gradien, gambar, atau tekstur ke bentuk, Anda juga dapat mengatur tingkat transparansi untuk mengendalikan opasitas isian. Nilai transparansi yang lebih tinggi membuat bentuk lebih tembus pandang, memungkinkan latar belakang atau objek di bawahnya terlihat sebagian.

Aspose.Slides memungkinkan Anda mengatur tingkat transparansi dengan menyesuaikan nilai alfa pada warna yang digunakan untuk isian. Berikut caranya:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/) ke slide.
1. Atur [FillType](https://reference.aspose.com/slides/id/java/com.aspose.slides/filltype/) menjadi `Solid`.
1. Gunakan `Color` untuk mendefinisikan warna dengan transparansi (komponen `alpha` mengontrol transparansi).
1. Simpan presentasi.

Kode Java berikut memperlihatkan cara menerapkan warna isian transparan ke sebuah persegi panjang:

```java
// Instansiasi kelas Presentation yang mewakili file presentasi.
Presentation presentation = new Presentation();
try {
    // Dapatkan slide pertama.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Tambahkan auto shape persegi panjang solid.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Tambahkan auto shape persegi panjang transparan di atas shape solid.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // Simpan file PPTX ke disk.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Bentuk transparan](shape-transparency.png)

## **Rotate Shapes**

Aspose.Slides memungkinkan Anda memutar bentuk dalam presentasi PowerPoint. Hal ini dapat berguna saat menempatkan elemen visual dengan kebutuhan penyelarasan atau desain tertentu.

Untuk memutar sebuah bentuk pada slide, ikuti langkah-langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/) ke slide.
1. Atur properti rotasi bentuk ke sudut yang diinginkan.
1. Simpan presentasi.

Kode Java berikut memperlihatkan cara memutar sebuah bentuk sebesar 5 derajat:

```java
// Instansiasi kelas Presentation yang mewakili file presentasi.
Presentation presentation = new Presentation();
try {
    // Dapatkan slide pertama.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Tambahkan auto shape dengan tipe Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Putar bentuk sebesar 5 derajat.
    shape.setRotation(5);

    // Simpan file PPTX ke disk.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Rotasi bentuk](shape-rotation.png)

## **Add 3D Bevel Effects**

Aspose.Slides memungkinkan Anda menerapkan efek bevel 3D ke bentuk dengan mengkonfigurasi properti [ThreeDFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/threedformat/) mereka.

Untuk menambahkan efek bevel 3D ke sebuah bentuk, ikuti langkah-langkah berikut:

1. Instansiasi kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/) ke slide.
1. Konfigurasikan [ThreeDFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/threedformat/) bentuk untuk mendefinisikan pengaturan bevel.
1. Simpan presentasi.

Kode Java berikut menunjukkan cara menerapkan efek bevel 3D ke sebuah bentuk:

```java
// Buat instance kelas Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Tambahkan bentuk ke slide.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // Atur properti ThreeDFormat bentuk.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // Simpan presentasi sebagai file PPTX.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Efek bevel 3D](3D-bevel-effect.png)

## **Add 3D Rotation Effects**

Aspose.Slides memungkinkan Anda menerapkan efek rotasi 3D ke bentuk dengan mengkonfigurasi properti [ThreeDFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/threedformat/) mereka.

Untuk menerapkan rotasi 3D ke sebuah bentuk:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/) ke slide.
1. Gunakan [setCameraType](https://reference.aspose.com/slides/id/java/com.aspose.slides/icamera/#setCameraType-int-) dan [setLightType](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilightrig/#setLightType-int-) untuk mendefinisikan rotasi 3D.
1. Simpan presentasi.

Kode Java berikut memperlihatkan cara menerapkan efek rotasi 3D ke sebuah bentuk:

```java
// Buat instance kelas Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    // Simpan presentasi sebagai file PPTX.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Efek rotasi 3D](3D-rotation-effect.png)

## **Reset Formatting**

Kode Java berikut memperlihatkan cara mengatur ulang pemformatan slide dan mengembalikan posisi, ukuran, serta pemformatan semua bentuk dengan placeholder pada [LayoutSlide](https://reference.aspose.com/slides/id/java/com.aspose.slides/layoutslide/) ke pengaturan default mereka:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Reset setiap bentuk pada slide yang memiliki placeholder pada tata letak.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Apakah pemformatan bentuk memengaruhi ukuran file presentasi akhir?**

Hanya sedikit saja. Gambar dan media yang disematkan memakan sebagian besar ruang file, sementara parameter bentuk seperti warna, efek, dan gradien disimpan sebagai metadata dan hampir tidak menambah ukuran.

**Bagaimana saya dapat mendeteksi bentuk pada slide yang memiliki pemformatan identik sehingga dapat saya kelompokkan?**

Bandingkan setiap properti pemformatan utama bentuk—pengaturan isi, garis, dan efek. Jika semua nilai yang bersesuaian cocok, anggap gaya mereka identik dan kelompokkan bentuk‑bentuk tersebut secara logis, yang mempermudah manajemen gaya nantinya.

**Apakah saya dapat menyimpan sekumpulan gaya bentuk kustom ke file terpisah untuk digunakan kembali di presentasi lain?**

Ya. Simpan contoh bentuk dengan gaya yang diinginkan dalam slide templat atau file .POTX templat. Saat membuat presentasi baru, buka templat tersebut, kloning bentuk ber‑gaya yang Anda perlukan, dan terapkan kembali pemformatannya sesuai kebutuhan.