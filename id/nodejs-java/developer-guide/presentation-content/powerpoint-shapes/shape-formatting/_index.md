---
title: Format Bentuk PowerPoint dalam JavaScript
linktitle: Pemformatan Bentuk
type: docs
weight: 20
url: /id/nodejs-java/shape-formatting/
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
- putar bentuk
- efek bevel 3d
- efek rotasi 3d
- reset pemformatan
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Format bentuk PowerPoint dalam JavaScript menggunakan Aspose.Slides—atur gaya isi, garis, dan efek untuk file PPT, PPTX, dan ODP dengan presisi dan kontrol penuh."
---
## **Pendahuluan**

Di PowerPoint, Anda dapat menambahkan bentuk ke slide. Karena bentuk terdiri dari garis, Anda dapat memformatnya dengan memodifikasi atau menerapkan efek pada garis tepinya. Selain itu, Anda dapat memformat bentuk dengan menentukan pengaturan yang mengontrol bagaimana bagian dalamnya diisi.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Node.js via Java menyediakan kelas dan metode yang memungkinkan Anda memformat bentuk menggunakan opsi yang sama dengan yang tersedia di PowerPoint.

## **Format Garis**

Dengan menggunakan Aspose.Slides, Anda dapat menentukan gaya garis khusus untuk sebuah bentuk. Langkah-langkah berikut menjelaskan prosedurnya:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/).
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) ke slide.
4. Atur [gaya garis](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/linestyle/) bentuk.
5. Atur lebar garis.
6. Atur [dash style](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/linedashstyle/) garis.
7. Atur warna garis untuk bentuk.
8. Simpan presentasi yang dimodifikasi sebagai file PPTX.

```js
// Instansiasi kelas Presentation yang mewakili file presentasi.
let presentation = new aspose.slides.Presentation();
try {
    // Ambil slide pertama.
    let slide = presentation.getSlides().get_Item(0);

    // Tambahkan auto shape tipe Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // Atur warna isi untuk shape persegi panjang.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // Terapkan pemformatan pada garis persegi panjang.
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    // Atur warna untuk garis persegi panjang.
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // Simpan file PPTX ke disk.
    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Garis yang diformat dalam presentasi](formatted-lines.png)

## **Format Gaya Sambungan**

Berikut tiga opsi tipe sambungan:

* Round
* Miter
* Bevel

Dengan default, ketika PowerPoint menggabungkan dua garis pada sudut (seperti pada sudut bentuk), ia menggunakan pengaturan **Round**. Namun, jika Anda menggambar bentuk dengan sudut tajam, Anda mungkin lebih menyukai opsi **Miter**.

![Gaya sambungan dalam presentasi](join-style-powerpoint.png)

```js
// Instansiasi kelas Presentation yang mewakili file presentasi.
let presentation = new aspose.slides.Presentation();
try {
    // Ambil slide pertama.
    let slide = presentation.getSlides().get_Item(0);

    // Tambahkan tiga auto shape tipe Rectangle.
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // Atur warna isi untuk setiap shape persegi panjang.
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

    // Atur lebar garis.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Atur warna untuk garis tiap persegi panjang.
    shape1.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape3.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // Atur gaya sambungan.
    shape1.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
    shape2.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Bevel));
    shape3.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Round));

    // Tambahkan teks ke setiap persegi panjang.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Simpan file PPTX ke disk.
    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Isi Gradien**

Di PowerPoint, Gradient Fill adalah opsi pemformatan yang memungkinkan Anda menerapkan perpaduan warna kontinu ke sebuah bentuk. Misalnya, Anda dapat menerapkan dua atau lebih warna sehingga satu secara bertahap memudar menjadi warna lain.

Berikut cara menerapkan isi gradien ke sebuah bentuk menggunakan Aspose.Slides:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/).
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) ke slide.
4. Atur [FillType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/filltype/) bentuk menjadi `Gradient`.
5. Tambahkan dua warna pilihan Anda dengan posisi yang ditentukan menggunakan metode `add` pada koleksi gradient stop yang disediakan oleh kelas [GradientFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/gradientformat/).
6. Simpan presentasi yang dimodifikasi sebagai file PPTX.

```js
// Instansiasi kelas Presentation yang mewakili file presentasi.
let presentation = new aspose.slides.Presentation();
try {
    // Ambil slide pertama.
    let slide = presentation.getSlides().get_Item(0);

    // Tambahkan auto shape tipe Ellipse.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // Terapkan pemformatan gradien ke elips.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

    // Atur arah gradien.
    shape.getFillFormat().getGradientFormat().setGradientDirection(aspose.slides.GradientDirection.FromCorner2);

    // Tambahkan dua gradient stop.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0, aspose.slides.PresetColor.Red);

    // Simpan file PPTX ke disk.
    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Elips dengan isi gradien](gradient-fill.png)

## **Isi Pola**

Di PowerPoint, Pattern Fill adalah opsi pemformatan yang memungkinkan Anda menerapkan desain dua warna—seperti titik, garis, crosshatch, atau kotak—ke sebuah bentuk. Anda dapat memilih warna khusus untuk latar depan dan latar belakang pola.

Aspose.Slides menyediakan lebih dari 45 gaya pola pra‑definisi yang dapat Anda terapkan pada bentuk untuk meningkatkan daya tarik visual presentasi Anda. Bahkan setelah memilih pola pra‑definisi, Anda masih dapat menentukan warna tepat yang harus digunakan.

Berikut cara menerapkan isi pola ke sebuah bentuk menggunakan Aspose.Slides:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/).
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) ke slide.
4. Atur [FillType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/filltype/) bentuk menjadi `Pattern`.
5. Pilih gaya pola dari opsi pra‑definisi.
6. Atur [Background Color](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/patternformat/#getBackColor--) pola.
7. Atur [Foreground Color](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/patternformat/#getForeColor--) pola.
8. Simpan presentasi yang dimodifikasi sebagai file PPTX.

```js
// Instansiasi kelas Presentation yang mewakili file presentasi.
let presentation = new aspose.slides.Presentation();
try {
    // Ambil slide pertama.
    let slide = presentation.getSlides().get_Item(0);

    // Tambahkan auto shape tipe Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Atur tipe isi menjadi Pattern.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // Atur gaya pola.
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // Atur warna latar belakang dan latar depan pola.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Simpan file PPTX ke disk.
    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Persegi panjang dengan isi pola](pattern-fill.png)

## **Isi Gambar**

Di PowerPoint, Picture Fill adalah opsi pemformatan yang memungkinkan Anda menyisipkan gambar di dalam sebuah bentuk—secara efektif menggunakan gambar sebagai latar belakang bentuk.

Berikut cara menggunakan Aspose.Slides untuk menerapkan isi gambar ke sebuah bentuk:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/).
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) ke slide.
4. Atur [FillType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/filltype/) bentuk menjadi `Picture`.
5. Atur mode isi gambar menjadi `Tile` (atau mode lain yang diinginkan).
6. Buat objek [PPImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ppimage/) dari gambar yang ingin Anda gunakan.
7. Berikan gambar tersebut ke metode `ISlidesPicture.setImage`.
8. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Misalkan kita memiliki file "lotus.png" dengan gambar berikut:

![Gambar lotus](lotus.png)

```js
// Instansiasi kelas Presentation yang mewakili file presentasi.
let presentation = new aspose.slides.Presentation();
try {
    // Ambil slide pertama.
    let slide = presentation.getSlides().get_Item(0);

    // Tambahkan auto shape tipe Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Atur tipe isi menjadi Picture.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Atur mode isi gambar.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    // Muat gambar dan tambahkan ke sumber daya presentasi.
    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture = presentation.getImages().addImage(image);
    image.dispose();

    // Atur gambar.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Simpan file PPTX ke disk.
    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Bentuk dengan isi gambar](picture-fill.png)

### **Ubin Gambar Sebagai Tekstur**

Jika Anda ingin menetapkan gambar ubin sebagai tekstur dan menyesuaikan perilaku ubin, Anda dapat menggunakan metode berikut dari kelas [PictureFillFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): Mengatur mode pengisian gambar—baik `Tile` atau `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): Menentukan perataan ubin di dalam bentuk.
- [setTileFlip](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): Mengontrol apakah ubin dibalik secara horizontal, vertikal, atau keduanya.
- [setTileOffsetX](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): Menetapkan offset horizontal ubin (dalam poin) dari asal bentuk.
- [setTileOffsetY](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): Menetapkan offset vertikal ubin (dalam poin) dari asal bentuk.
- [setTileScaleX](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): Menentukan skala horizontal ubin dalam persentase.
- [setTileScaleY](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): Menentukan skala vertikal ubin dalam persentase.

```js
// Instansiasi kelas Presentation yang mewakili file presentasi.
let presentation = new aspose.slides.Presentation();
try {
    // Ambil slide pertama.
    let firstSlide = presentation.getSlides().get_Item(0);

    // Tambahkan auto shape persegi panjang.
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // Atur tipe isi shape menjadi Picture.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Muat gambar dan tambahkan ke sumber daya presentasi.
    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Tetapkan gambar ke shape.
    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Konfigurasikan mode isi gambar dan properti ubin.
    pictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.BottomRight));
    pictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // Simpan file PPTX ke disk.
    presentation.save("tile.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Opsi ubin](tile-options.png)

## **Isi Warna Solid**

Di PowerPoint, Solid Color Fill adalah opsi pemformatan yang mengisi sebuah bentuk dengan satu warna seragam. Latar belakang berwarna polos ini diterapkan tanpa gradien, tekstur, atau pola apapun.

Untuk menerapkan isi warna solid ke sebuah bentuk menggunakan Aspose.Slides, ikuti langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/).
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) ke slide.
4. Atur [FillType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/filltype/) bentuk menjadi `Solid`.
5. Tetapkan warna isi yang Anda inginkan ke bentuk.
6. Simpan presentasi yang dimodifikasi sebagai file PPTX.

```js
// Instansiasi kelas Presentation yang mewakili file presentasi.
let presentation = new aspose.slides.Presentation();
try {
    // Ambil slide pertama.
    let slide = presentation.getSlides().get_Item(0);

    // Tambahkan auto shape tipe Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Atur tipe isi menjadi Solid.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));

    // Atur warna isi.
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Simpan file PPTX ke disk.
    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Bentuk dengan isi warna solid](solid-color-fill.png)

## **Atur Transparansi**

Di PowerPoint, ketika Anda menerapkan isi warna solid, gradien, gambar, atau tekstur ke bentuk, Anda juga dapat mengatur tingkat transparansi untuk mengontrol opacity isi. Nilai transparansi yang lebih tinggi membuat bentuk menjadi lebih tembus, memungkinkan latar belakang atau objek di bawahnya terlihat sebagian.

Aspose.Slides memungkinkan Anda mengatur tingkat transparansi dengan menyesuaikan nilai alpha pada warna yang digunakan untuk isi. Berikut caranya:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/).
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) ke slide.
4. Atur [FillType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/filltype/) menjadi `Solid`.
5. Gunakan `Color` untuk mendefinisikan warna dengan transparansi (komponen `alpha` mengontrol transparansi).
6. Simpan presentasi.

```js
// Instansiasi kelas Presentation yang mewakili file presentasi.
let presentation = new aspose.slides.Presentation();
try {
    // Ambil slide pertama.
    let slide = presentation.getSlides().get_Item(0);

    // Tambahkan auto shape persegi panjang solid.
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Tambahkan auto shape persegi panjang transparan di atas shape solid.
    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 204));

    // Simpan file PPTX ke disk.
    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Bentuk transparan](shape-transparency.png)

## **Putar Bentuk**

Aspose.Slides memungkinkan Anda memutar bentuk dalam presentasi PowerPoint. Hal ini berguna saat menempatkan elemen visual dengan kebutuhan penyelarasan atau desain tertentu.

Untuk memutar sebuah bentuk pada slide, ikuti langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/).
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) ke slide.
4. Atur properti rotasi bentuk ke sudut yang diinginkan.
5. Simpan presentasi.

```js
// Instansiasi kelas Presentation yang mewakili file presentasi.
let presentation = new aspose.slides.Presentation();
try {
    // Ambil slide pertama.
    let slide = presentation.getSlides().get_Item(0);

    // Tambahkan auto shape tipe Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Putar shape sebesar 5 derajat.
    shape.setRotation(5);

    // Simpan file PPTX ke disk.
    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Rotasi bentuk](shape-rotation.png)

## **Tambahkan Efek Bevel 3D**

Aspose.Slides memungkinkan Anda menerapkan efek bevel 3D ke bentuk dengan mengonfigurasi properti [ThreeDFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/threedformat/).

Untuk menambahkan efek bevel 3D ke sebuah bentuk, ikuti langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/).
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) ke slide.
4. Konfigurasikan [ThreeDFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/threedformat/) bentuk untuk mendefinisikan pengaturan bevel.
5. Simpan presentasi.

```js
// Buat instance kelas Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Tambahkan shape ke slide.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    shape.getLineFormat().setWidth(2.0);

    // Atur properti ThreeDFormat pada shape.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);

    // Simpan presentasi sebagai file PPTX.
    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Efek bevel 3D](3D-bevel-effect.png)

## **Tambahkan Efek Rotasi 3D**

Aspose.Slides memungkinkan Anda menerapkan efek rotasi 3D ke bentuk dengan mengonfigurasi properti [ThreeDFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/threedformat/).

Untuk menerapkan rotasi 3D ke sebuah bentuk:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/).
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) ke slide.
4. Gunakan [setCameraType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/camera/#setCameraType) dan [setLightType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/lightrig/#setLightType) untuk mendefinisikan rotasi 3D.
5. Simpan presentasi.

```js
// Buat instance kelas Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);

    // Simpan presentasi sebagai file PPTX.
    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Efek rotasi 3D](3D-rotation-effect.png)

## **Reset Pemformatan**

Kode Java berikut menunjukkan cara mereset pemformatan slide dan mengembalikan posisi, ukuran, serta pemformatan semua bentuk dengan placeholder pada [LayoutSlide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutslide/) ke pengaturan default mereka:

```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // Reset setiap shape pada slide yang memiliki placeholder pada layout.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Apakah pemformatan bentuk memengaruhi ukuran file presentasi akhir?**

Hanya secara minimal. Gambar dan media yang disematkan mengambil sebagian besar ruang file, sementara parameter bentuk seperti warna, efek, dan gradien disimpan sebagai metadata dan hampir tidak menambah ukuran.

**Bagaimana saya dapat mendeteksi bentuk pada slide yang memiliki pemformatan identik sehingga saya dapat mengelompokkannya?**

Bandingkan setiap properti pemformatan utama bentuk—pengaturan isi, garis, dan efek. Jika semua nilai yang sesuai cocok, anggap gaya mereka identik dan kelompokkan bentuk‑bentuk tersebut secara logis, yang memudahkan manajemen gaya di kemudian hari.

**Apakah saya dapat menyimpan sekumpulan gaya bentuk khusus ke file terpisah untuk digunakan kembali dalam presentasi lain?**

Ya. Simpan contoh bentuk dengan gaya yang diinginkan dalam slide templat atau file .POTX. Saat membuat presentasi baru, buka templat tersebut, kloning bentuk‑bentuk yang diperlukan, dan terapkan kembali pemformatannya sesuai kebutuhan.