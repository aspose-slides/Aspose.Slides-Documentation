---
title: Format Bentuk PowerPoint dalam Java
linktitle: Pemformatan Bentuk
type: docs
weight: 20
url: /id/java/shape-formatting/
keywords:
- format bentuk
- format garis
- efek sketsa
- garis bentuk sketsa
- format gaya sambungan
- isi gradasi
- isi pola
- isi gambar
- isi tekstur
- isi warna solid
- transparansi bentuk
- putar bentuk
- efek bevel 3D
- efek rotasi 3D
- reset format
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Pelajari cara memformat bentuk PowerPoint dalam Java menggunakan Aspose.Slides—atur gaya isi, garis, dan efek untuk file PPT, PPTX, dan ODP dengan presisi dan kontrol penuh."
---
## **Pengantar**

Di PowerPoint, Anda dapat menambahkan bentuk ke slide. Karena bentuk terdiri dari garis, Anda dapat memformatnya dengan mengubah atau menerapkan efek pada tepiannya. Selain itu, Anda dapat memformat bentuk dengan menentukan pengaturan yang mengontrol bagaimana bagian dalamnya diisi.

![format-bentuk-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Java menyediakan antarmuka dan metode yang memungkinkan Anda memformat bentuk menggunakan opsi yang sama tersedia di PowerPoint.

## **Format Garis**

Menggunakan Aspose.Slides, Anda dapat menentukan gaya garis khusus untuk sebuah bentuk. Langkah‑langkah berikut menjelaskan prosedurnya:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) .
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/) ke slide.
4. Atur [line style](https://reference.aspose.com/slides/id/java/com.aspose.slides/linestyle/) bentuk.
5. Atur lebar garis.
6. Atur [dash style](https://reference.aspose.com/slides/id/java/com.aspose.slides/linedashstyle/) garis.
7. Atur warna garis untuk bentuk.
8. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Kode berikut menunjukkan cara memformat `AutoShape` berbentuk persegi panjang:

```java
// Buat instance kelas Presentation yang mewakili file presentasi.
Presentation presentation = new Presentation();
try {
    // Dapatkan slide pertama.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Tambahkan auto shape tipe Persegi Panjang.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Atur warna isi untuk bentuk persegi panjang.
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

Hasil:

![Garis yang diformat dalam presentasi](formatted-lines.png)

## **Terapkan Efek Sketsa pada Garis Bentuk**

Efek sketsa membuat garis bentuk terlihat seperti digambar tangan. Gunakan [IShape.getLineFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/) untuk mengakses pengaturan garis, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilineformat/) untuk mengakses pengaturan sketsa, dan [ISketchFormat.setSketchType](https://reference.aspose.com/slides/id/java/com.aspose.slides/isketchformat/) untuk memilih nilai dari enumerasi [LineSketchType](https://reference.aspose.com/slides/id/java/com.aspose.slides/linesketchtype/).

Kode Java berikut menunjukkan cara menerapkan efek [LineSketchType.Curved](https://reference.aspose.com/slides/id/java/com.aspose.slides/linesketchtype/), membaca nilai yang ditetapkan secara eksplisit, dan menghapus efek dengan [LineSketchType.None](https://reference.aspose.com/slides/id/java/com.aspose.slides/linesketchtype/):

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Akses format garis bentuk dan format sketsanya.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // Terapkan efek sketsa.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // Baca efek sketsa yang ditetapkan langsung pada bentuk.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // Hapus efek sketsa.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Nilai yang dikembalikan oleh [ISketchFormat.getSketchType](https://reference.aspose.com/slides/id/java/com.aspose.slides/isketchformat/) mewakili pengaturan yang ditetapkan langsung pada bentuk. Jika format garis dapat diwariskan dari tema, master slide, atau layout slide, gunakan [ILineFormat.getEffective](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilineformat/), akses [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilineformateffectivedata/), dan baca [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/id/java/com.aspose.slides/isketchformateffectivedata/). Nilai efektif mencerminkan format yang sebenarnya diterapkan setelah pewarisan diselesaikan:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    ILineFormat lineFormat = shape.getLineFormat();

    int explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    ILineFormatEffectiveData effectiveLineFormat = lineFormat.getEffective();
    int effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    System.out.println("Explicit sketch type: " + explicitSketchType);
    System.out.println("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **Format Gaya Sambungan**

Berikut tiga opsi tipe sambungan:

* Round
* Miter
* Bevel

Secara default, ketika PowerPoint menggabungkan dua garis dengan sudut (seperti pada sudut bentuk), ia menggunakan pengaturan **Round**. Namun, jika Anda menggambar bentuk dengan sudut tajam, Anda mungkin lebih suka opsi **Miter**.

![Gaya sambungan dalam presentasi](join-style-powerpoint.png)

Kode Java berikut menunjukkan bagaimana tiga persegi panjang (seperti yang ditampilkan pada gambar di atas) dibuat menggunakan pengaturan tipe sambungan Miter, Bevel, dan Round:

```java
// Buat instance kelas Presentation yang mewakili file presentasi.
Presentation presentation = new Presentation();
try {
    // Dapatkan slide pertama.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Tambahkan tiga auto shape tipe Persegi Panjang.
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

    // Atur warna untuk setiap garis persegi panjang.
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

## **Isi Gradient**

Di PowerPoint, Gradient Fill adalah opsi pemformatan yang memungkinkan Anda menerapkan perpaduan warna secara kontinu pada sebuah bentuk. Misalnya, Anda dapat menerapkan dua atau lebih warna sehingga satu secara bertahap memudar menjadi warna lain.

Berikut cara menerapkan isi gradient pada bentuk menggunakan Aspose.Slides:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) .
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/) ke slide.
4. Atur [FillType](https://reference.aspose.com/slides/id/java/com.aspose.slides/filltype/) bentuk menjadi `Gradient` .
5. Tambahkan dua warna pilihan Anda dengan posisi yang ditentukan menggunakan metode `add` dari koleksi gradient stop yang disajikan oleh antarmuka [IGradientFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/igradientformat/) .
6. Simpan presentasi yang dimodifikasi sebagai file PPTX.

```java
// Buat instance kelas Presentation yang mewakili file presentasi.
Presentation presentation = new Presentation();
try {
    // Dapatkan slide pertama.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Tambahkan auto shape tipe Elips.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Terapkan pemformatan gradien pada elips.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Atur arah gradien.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Tambahkan dua titik gradien.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Simpan file PPTX ke disk.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Elips dengan isi gradient](gradient-fill.png)

## **Isi Pola**

Di PowerPoint, Pattern Fill adalah opsi pemformatan yang memungkinkan Anda menerapkan desain dua warna—seperti titik, garis, silang, atau pola kotak—ke sebuah bentuk. Anda dapat memilih warna khusus untuk latar depan dan latar belakang pola.

Aspose.Slides menyediakan lebih dari 45 gaya pola yang telah ditentukan sebelumnya yang dapat Anda terapkan pada bentuk untuk meningkatkan daya tarik visual presentasi Anda. Bahkan setelah memilih pola yang telah ditentukan, Anda masih dapat menentukan warna tepat yang harus digunakan.

Berikut cara menerapkan isi pola pada bentuk menggunakan Aspose.Slides:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) .
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/) ke slide.
4. Atur [FillType](https://reference.aspose.com/slides/id/java/com.aspose.slides/filltype/) bentuk menjadi `Pattern` .
5. Pilih gaya pola dari opsi yang telah ditentukan.
6. Atur [Background Color](https://reference.aspose.com/slides/id/java/com.aspose.slides/patternformat/#getBackColor--) pola.
7. Atur [Foreground Color](https://reference.aspose.com/slides/id/java/com.aspose.slides/patternformat/#getForeColor--) pola.
8. Simpan presentasi yang dimodifikasi sebagai file PPTX.

```java
// Buat instance kelas Presentation yang mewakili file presentasi.
Presentation presentation = new Presentation();
try {
    // Dapatkan slide pertama.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Tambahkan auto shape tipe Persegi Panjang.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Atur tipe isi menjadi Pattern.
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

![Persegi panjang dengan isi pola](pattern-fill.png)

## **Isi Gambar**

Di PowerPoint, Picture Fill adalah opsi pemformatan yang memungkinkan Anda menyisipkan gambar di dalam sebuah bentuk—secara efektif menggunakan gambar tersebut sebagai latar belakang bentuk.

Berikut cara menggunakan Aspose.Slides untuk menerapkan isi gambar pada sebuah bentuk:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) .
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/) ke slide.
4. Atur [FillType](https://reference.aspose.com/slides/id/java/com.aspose.slides/filltype/) bentuk menjadi `Picture` .
5. Atur mode isi gambar menjadi `Tile` (atau mode lain yang diinginkan).
6. Buat objek [IPPImage](https://reference.aspose.com/slides/id/java/com.aspose.slides/ippimage/) dari gambar yang ingin Anda gunakan.
7. Berikan gambar tersebut ke metode `ISlidesPicture.setImage` .
8. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Misalkan kita memiliki file "lotus.png" dengan gambar berikut:

![Gambar lotus](lotus.png)

```java
// Buat instance kelas Presentation yang mewakili file presentasi.
Presentation presentation = new Presentation();
try {
    // Dapatkan slide pertama.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Tambahkan auto shape tipe Persegi Panjang.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Atur tipe isi menjadi Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Atur mode isi gambar.
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

![Bentuk dengan isi gambar](picture-fill.png)

### **Ubin Gambar sebagai Tekstur**

Jika Anda ingin mengatur gambar berulang sebagai tekstur dan menyesuaikan perilaku pengulangan, Anda dapat menggunakan metode berikut dari antarmuka [IPictureFillFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipicturefillformat/) dan kelas [PictureFillFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Menetapkan mode isi gambar—baik `Tile` maupun `Stretch` .
- [setTileAlignment](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Menentukan perataan ubin dalam bentuk .
- [setTileFlip](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Mengontrol apakah ubin dibalik secara horizontal, vertikal, atau keduanya .
- [setTileOffsetX](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Menetapkan offset horizontal ubin (dalam poin) dari asal bentuk .
- [setTileOffsetY](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Menetapkan offset vertikal ubin (dalam poin) dari asal bentuk .
- [setTileScaleX](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Mendefinisikan skala horizontal ubin dalam persentase .
- [setTileScaleY](https://reference.aspose.com/slides/id/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Mendefinisikan skala vertikal ubin dalam persentase .

```java
// Buat instance kelas Presentation yang mewakili file presentasi.
Presentation presentation = new Presentation();
try {
    // Dapatkan slide pertama.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Tambahkan auto shape persegi panjang.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Atur tipe isi bentuk menjadi Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Muat gambar dan tambahkan ke sumber daya presentasi.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Tetapkan gambar ke bentuk.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Konfigurasikan mode isi gambar dan properti ubin.
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

![Opsi ubin](tile-options.png)

## **Isi Warna Solid**

Di PowerPoint, Solid Color Fill adalah opsi pemformatan yang mengisi sebuah bentuk dengan satu warna seragam. Warna latar belakang sederhana ini diterapkan tanpa gradien, tekstur, atau pola apapun.

Untuk menerapkan isi warna solid pada sebuah bentuk menggunakan Aspose.Slides, ikuti langkah-langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) .
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/) ke slide.
4. Atur [FillType](https://reference.aspose.com/slides/id/java/com.aspose.slides/filltype/) bentuk menjadi `Solid` .
5. Tetapkan warna isi yang Anda inginkan pada bentuk.
6. Simpan presentasi yang dimodifikasi sebagai file PPTX.

```java
// Buat instance kelas Presentation yang mewakili file presentasi.
Presentation presentation = new Presentation();
try {
    // Dapatkan slide pertama.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Tambahkan auto shape tipe Persegi Panjang.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Atur tipe isi menjadi Solid.
    shape.getFillFormat().setFillType(FillType.Solid);

    // Atur warna isi.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // Simpan file PPTX ke disk.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Bentuk dengan isi warna solid](solid-color-fill.png)

## **Atur Transparansi**

Di PowerPoint, ketika Anda menerapkan isi warna solid, gradient, gambar, atau tekstur pada bentuk, Anda juga dapat mengatur tingkat transparansi untuk mengontrol opasitas isi. Nilai transparansi yang lebih tinggi membuat bentuk lebih tembus pandang, sehingga latar belakang atau objek di bawahnya menjadi terlihat sebagian.

Aspose.Slides memungkinkan Anda mengatur tingkat transparansi dengan menyesuaikan nilai alpha pada warna yang digunakan untuk isi. Berikut cara melakukannya:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) .
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/) ke slide.
4. Atur [FillType](https://reference.aspose.com/slides/id/java/com.aspose.slides/filltype/) menjadi `Solid` .
5. Gunakan `Color` untuk mendefinisikan warna dengan transparansi (komponen `alpha` mengontrol transparansi) .
6. Simpan presentasi.

```java
// Buat instance kelas Presentation yang mewakili file presentasi.
Presentation presentation = new Presentation();
try {
    // Dapatkan slide pertama.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Tambahkan auto shape persegi panjang solid.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Tambahkan auto shape persegi panjang transparan di atas bentuk solid.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // Simpan file PPTX ke disk.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Bentuk transparan](shape-transparency.png)

## **Putar Bentuk**

Aspose.Slides memungkinkan Anda memutar bentuk dalam presentasi PowerPoint. Hal ini berguna saat menempatkan elemen visual dengan kebutuhan penyelarasan atau desain tertentu.

Untuk memutar sebuah bentuk pada slide, ikuti langkah-langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) .
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/) ke slide.
4. Atur properti rotasi bentuk ke sudut yang diinginkan.
5. Simpan presentasi.

```java
// Buat instance kelas Presentation yang mewakili file presentasi.
Presentation presentation = new Presentation();
try {
    // Dapatkan slide pertama.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Tambahkan auto shape tipe Persegi Panjang.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Putar bentuk sebesar 5 derajat.
    shape.setRotation(5);

    // Simpan file PPTX ke disk.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Rotasi bentuk](shape-rotation.png)

## **Tambahkan Efek Bevel 3D**

Aspose.Slides memungkinkan Anda menerapkan efek bevel 3D pada bentuk dengan mengkonfigurasi properti [ThreeDFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/threedformat/) mereka.

Untuk menambahkan efek bevel 3D pada sebuah bentuk, ikuti langkah-langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) .
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/) ke slide.
4. Konfigurasikan [ThreeDFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/threedformat/) bentuk untuk mendefinisikan pengaturan bevel.
5. Simpan presentasi.

```java
// Buat instance kelas Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Tambahkan sebuah bentuk ke slide.
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

![Efek bevel 3D](3D-bevel-effect.png)

## **Tambahkan Efek Rotasi 3D**

Aspose.Slides memungkinkan Anda menerapkan efek rotasi 3D pada bentuk dengan mengkonfigurasi properti [ThreeDFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/threedformat/) mereka.

Untuk menerapkan rotasi 3D pada sebuah bentuk:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) .
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/iautoshape/) ke slide.
4. Gunakan [setCameraType](https://reference.aspose.com/slides/id/java/com.aspose.slides/icamera/#setCameraType-int-) dan [setLightType](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilightrig/#setLightType-int-) untuk mendefinisikan rotasi 3D.
5. Simpan presentasi.

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

![Efek rotasi 3D](3D-rotation-effect.png)

## **Reset Format**

Kode Java berikut menunjukkan cara mereset format slide dan mengembalikan posisi, ukuran, serta format semua bentuk dengan placeholder pada [LayoutSlide](https://reference.aspose.com/slides/id/java/com.aspose.slides/layoutslide/) ke pengaturan default mereka:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Reset setiap bentuk pada slide yang memiliki placeholder pada layout.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Apakah pemformatan bentuk memengaruhi ukuran file presentasi akhir?**

Hanya sedikit. Gambar dan media yang disematkan menempati sebagian besar ruang file, sedangkan parameter bentuk seperti warna, efek, dan gradien disimpan sebagai metadata dan hampir tidak menambah ukuran.

**Bagaimana saya dapat mendeteksi bentuk pada slide yang memiliki format identik sehingga saya dapat mengelompokkannya?**

Bandingkan properti format utama setiap bentuk—pengaturan isi, garis, dan efek. Jika semua nilai yang bersesuaian cocok, anggap gaya mereka identik dan kelompokkan bentuk-bentuk tersebut secara logis, yang menyederhanakan manajemen gaya di kemudian hari.

**Apakah saya dapat menyimpan sekumpulan gaya bentuk khusus ke file terpisah untuk digunakan kembali di presentasi lain?**

Ya. Simpan bentuk contoh dengan gaya yang diinginkan dalam deck slide template atau file template .POTX. Saat membuat presentasi baru, buka template tersebut, kloning bentuk bergaya yang diperlukan, dan terapkan kembali formatnya di mana pun diperlukan.