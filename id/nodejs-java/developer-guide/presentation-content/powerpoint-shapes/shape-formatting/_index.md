---
title: Format Bentuk PowerPoint dalam JavaScript
linktitle: Pemformatan Bentuk
type: docs
weight: 20
url: /id/nodejs-java/shape-formatting/
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
- rendering bentuk hitam-putih
- rendering bentuk skala abu-abu
- putar bentuk
- efek bevel 3D
- efek rotasi 3D
- reset pemformatan
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Format bentuk PowerPoint dalam JavaScript menggunakan Aspose.Slides—atur gaya isian, garis, dan efek untuk file PPT, PPTX, dan ODP dengan presisi dan kontrol penuh."
---
## **Pendahuluan**

Di PowerPoint, Anda dapat menambahkan bentuk ke slide. Karena bentuk terdiri dari garis, Anda dapat memformatnya dengan mengubah atau menerapkan efek pada garis tepinya. Selain itu, Anda dapat memformat bentuk dengan menentukan pengaturan yang mengontrol bagaimana bagian dalamnya diisi.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides untuk Node.js via Java menyediakan kelas dan metode yang memungkinkan Anda memformat bentuk menggunakan opsi yang sama tersedia di PowerPoint.

## **Format Garis**

Dengan menggunakan Aspose.Slides, Anda dapat menentukan gaya garis khusus untuk sebuah bentuk. Langkah-langkah berikut menjelaskan prosedurnya:

1. Buat instance dari [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) class.
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) ke slide.
4. Atur [gaya garis](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/linestyle/) bentuk.
5. Atur lebar garis.
6. Atur [gaya dash](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/linedashstyle/) garis.
7. Atur warna garis untuk bentuk.
8. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Kode berikut menunjukkan cara memformat `AutoShape` berbentuk persegi panjang:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Membuat instance kelas Presentation yang mewakili file presentasi.
let presentation = new aspose.slides.Presentation();
try {
    // Dapatkan slide pertama.
    let slide = presentation.getSlides().get_Item(0);

    // Tambahkan auto shape dengan tipe Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // Hapus isian dari shape persegi panjang.
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

Hasil:

![Garis yang diformat dalam presentasi](formatted-lines.png)

## **Terapkan Efek Sketsa pada Garis Bentuk**

Efek sketsa membuat garis bentuk terlihat seperti digambar tangan. Gunakan [Shape.getLineFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/) untuk mengakses pengaturan garis, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/lineformat/) untuk mengakses pengaturan sketsa, dan [SketchFormat.setSketchType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sketchformat/) untuk memilih nilai dari enumerasi [LineSketchType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/linesketchtype/).

Kode JavaScript berikut menunjukkan cara menerapkan efek [LineSketchType.Curved](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/linesketchtype/) , membaca nilai yang ditetapkan secara eksplisit, dan menghapus efek dengan [LineSketchType.None](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/linesketchtype/):

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    // Akses format garis shape dan format sketsa-nya.
    let sketchFormat = shape.getLineFormat().getSketchFormat();

    // Terapkan efek sketsa.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);

    // Baca efek sketsa yang ditetapkan langsung pada shape.
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);

    // Hapus efek sketsa.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Nilai yang dikembalikan oleh [SketchFormat.getSketchType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sketchformat/) mewakili pengaturan yang ditetapkan langsung pada bentuk. Jika pemformatan garis dapat diwarisi dari tema, master slide, atau layout slide, gunakan [LineFormat.getEffective](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/lineformat/), panggil `getSketchFormat` pada objek yang dikembalikan, dan kemudian panggil metode `getSketchType`‑nya. Nilai efektif mencerminkan pemformatan yang sebenarnya diterapkan setelah pewarisan diselesaikan:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    let lineFormat = shape.getLineFormat();

    let explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    let effectiveLineFormat = lineFormat.getEffective();
    let effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    console.log("Explicit sketch type: " + explicitSketchType);
    console.log("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **Format Gaya Sambungan**

Berikut adalah tiga opsi jenis sambungan:

* Round
* Miter
* Bevel

Secara default, ketika PowerPoint menggabungkan dua garis pada sudut (seperti pada sudut bentuk), ia menggunakan pengaturan **Round**. Namun, jika Anda menggambar bentuk dengan sudut tajam, Anda mungkin lebih menyukai opsi **Miter**.

![Gaya sambungan dalam presentasi](join-style-powerpoint.png)

Kode JavaScript berikut menunjukkan bagaimana tiga persegi panjang (seperti yang ditampilkan pada gambar di atas) dibuat menggunakan pengaturan jenis sambungan Miter, Bevel, dan Round:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Membuat instance kelas Presentation yang mewakili file presentasi.
let presentation = new aspose.slides.Presentation();
try {
    // Dapatkan slide pertama.
    let slide = presentation.getSlides().get_Item(0);

    // Tambahkan tiga auto shape dengan tipe Rectangle.
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // Atur warna isian untuk setiap shape persegi panjang.
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

    // Atur warna untuk garis setiap persegi panjang.
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

## **Isian Gradien**

Di PowerPoint, Gradient Fill adalah opsi pemformatan yang memungkinkan Anda menerapkan perpaduan warna kontinu pada sebuah bentuk. Misalnya, Anda dapat menerapkan dua atau lebih warna sehingga satu secara bertahap memudar menjadi warna lain.

Berikut cara menerapkan isian gradien pada sebuah bentuk menggunakan Aspose.Slides:

1. Buat instance dari [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) class.
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) ke slide.
4. Atur [FillType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/filltype/) bentuk menjadi `Gradient`.
5. Tambahkan dua warna pilihan Anda dengan posisi yang ditentukan menggunakan metode `add` pada koleksi gradient stop yang disediakan oleh kelas [GradientFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/gradientformat/).
6. Simpan presentasi yang dimodifikasi sebagai file PPTX.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Membuat instance kelas Presentation yang mewakili file presentasi.
let presentation = new aspose.slides.Presentation();
try {
    // Dapatkan slide pertama.
    let slide = presentation.getSlides().get_Item(0);

    // Tambahkan auto shape dengan tipe Ellipse.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // Terapkan pemformatan gradien pada elips.
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

Hasil:

![Elips dengan isian gradien](gradient-fill.png)

## **Isian Pola**

Di PowerPoint, Pattern Fill adalah opsi pemformatan yang memungkinkan Anda menerapkan desain dua warna—seperti titik, garis, pola silang, atau cek—ke sebuah bentuk. Anda dapat memilih warna khusus untuk latar depan dan latar belakang pola.

Aspose.Slides menyediakan lebih dari 45 gaya pola yang telah ditentukan sebelumnya yang dapat Anda terapkan pada bentuk untuk meningkatkan daya tarik visual presentasi Anda. Bahkan setelah memilih pola yang telah ditentukan, Anda masih dapat menentukan warna tepat yang akan digunakan.

Berikut cara menerapkan isian pola pada sebuah bentuk menggunakan Aspose.Slides:

1. Buat instance dari [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) class.
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) ke slide.
4. Atur [FillType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/filltype/) bentuk menjadi `Pattern`.
5. Pilih gaya pola dari opsi yang telah ditentukan.
6. Atur [Background Color](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/patternformat/#getBackColor--) pola.
7. Atur [Foreground Color](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/patternformat/#getForeColor--) pola.
8. Simpan presentasi yang dimodifikasi sebagai file PPTX.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Membuat instance kelas Presentation yang mewakili file presentasi.
let presentation = new aspose.slides.Presentation();
try {
    // Dapatkan slide pertama.
    let slide = presentation.getSlides().get_Item(0);

    // Tambahkan auto shape dengan tipe Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Atur tipe isian menjadi Pattern.
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

Hasil:

![Persegi panjang dengan isian pola](pattern-fill.png)

## **Isian Gambar**

Di PowerPoint, Picture Fill adalah opsi pemformatan yang memungkinkan Anda menyisipkan gambar di dalam sebuah bentuk—secara efektif menggunakan gambar sebagai latar belakang bentuk.

Berikut cara menggunakan Aspose.Slides untuk menerapkan isian gambar pada sebuah bentuk:

1. Buat instance dari [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) class.
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) ke slide.
4. Atur [FillType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/filltype/) bentuk menjadi `Picture`.
5. Atur mode isian gambar menjadi `Tile` (atau mode lain yang diinginkan).
6. Buat objek [PPImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ppimage/) dari gambar yang ingin Anda gunakan.
7. Berikan gambar ke metode `ISlidesPicture.setImage`.
8. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Misalkan kita memiliki file "lotus.png" dengan gambar berikut:

![Gambar lotus](lotus.png)

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Membuat instance kelas Presentation yang mewakili file presentasi.
let presentation = new aspose.slides.Presentation();
try {
    // Dapatkan slide pertama.
    let slide = presentation.getSlides().get_Item(0);

    // Tambahkan auto shape dengan tipe Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Atur tipe isian menjadi Picture.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Atur mode isian gambar.
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

Hasil:

![Bentuk dengan isian gambar](picture-fill.png)

### **Ubin Gambar sebagai Tekstur**

Jika Anda ingin mengatur gambar berulang sebagai tekstur dan menyesuaikan perilaku pengulangan, Anda dapat menggunakan metode berikut dari kelas [PictureFillFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): Mengatur mode isian gambar—baik `Tile` atau `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): Menentukan perataan ubin dalam bentuk.
- [setTileFlip](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): Mengontrol apakah ubin dibalik secara horizontal, vertikal, atau keduanya.
- [setTileOffsetX](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): Mengatur offset horizontal ubin (dalam poin) dari asal bentuk.
- [setTileOffsetY](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): Mengatur offset vertikal ubin (dalam poin) dari asal bentuk.
- [setTileScaleX](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): Mendefinisikan skala horizontal ubin dalam persentase.
- [setTileScaleY](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): Mendefinisikan skala vertikal ubin dalam persentase.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Membuat instance kelas Presentation yang mewakili file presentasi.
let presentation = new aspose.slides.Presentation();
try {
    // Dapatkan slide pertama.
    let firstSlide = presentation.getSlides().get_Item(0);

    // Tambahkan auto shape persegi panjang.
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // Atur tipe isian bentuk menjadi Picture.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Muat gambar dan tambahkan ke sumber daya presentasi.
    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Tetapkan gambar ke bentuk.
    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Konfigurasikan mode isian gambar dan properti ubinnya.
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

Hasil:

![Opsi ubin](tile-options.png)

## **Isian Warna Solid**

Di PowerPoint, Solid Color Fill adalah opsi pemformatan yang mengisi bentuk dengan satu warna seragam. Latar belakang berwarna polos ini diterapkan tanpa gradien, tekstur, atau pola.

Untuk menerapkan isian warna solid pada sebuah bentuk menggunakan Aspose.Slides, ikuti langkah berikut:

1. Buat instance dari [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) class.
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) ke slide.
4. Atur [FillType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/filltype/) bentuk menjadi `Solid`.
5. Tetapkan warna isian yang Anda inginkan pada bentuk.
6. Simpan presentasi yang dimodifikasi sebagai file PPTX.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Membuat instance kelas Presentation yang mewakili file presentasi.
let presentation = new aspose.slides.Presentation();
try {
    // Dapatkan slide pertama.
    let slide = presentation.getSlides().get_Item(0);

    // Tambahkan auto shape dengan tipe Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Atur tipe isian menjadi Solid.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));

    // Atur warna isian.
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Simpan file PPTX ke disk.
    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![Bentuk dengan isian warna solid](solid-color-fill.png)

## **Atur Transparansi**

Di PowerPoint, ketika Anda menerapkan isian warna solid, gradien, gambar, atau tekstur pada bentuk, Anda juga dapat mengatur tingkat transparansi untuk mengontrol opasitas isian. Nilai transparansi yang lebih tinggi membuat bentuk lebih tembus pandang, memungkinkan latar belakang atau objek di bawahnya terlihat sebagian.

Aspose.Slides memungkinkan Anda mengatur tingkat transparansi dengan menyesuaikan nilai alfa pada warna yang digunakan untuk isian. Berikut caranya:

1. Buat instance dari [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) class.
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) ke slide.
4. Atur [FillType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/filltype/) menjadi `Solid`.
5. Gunakan `Color` untuk mendefinisikan warna dengan transparansi (komponen `alpha` mengontrol transparansi).
6. Simpan presentasi.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Membuat instance kelas Presentation yang mewakili file presentasi.
let presentation = new aspose.slides.Presentation();
try {
    // Dapatkan slide pertama.
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

Hasil:

![Bentuk transparan](shape-transparency.png)

## **Putar Bentuk**

Aspose.Slides memungkinkan Anda memutar bentuk dalam presentasi PowerPoint. Ini berguna saat menempatkan elemen visual dengan kebutuhan penyelarasan atau desain tertentu.

Untuk memutar sebuah bentuk pada slide, ikuti langkah berikut:

1. Buat instance dari [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) class.
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) ke slide.
4. Atur properti rotasi bentuk ke sudut yang diinginkan.
5. Simpan presentasi.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Membuat instance kelas Presentation yang mewakili file presentasi.
let presentation = new aspose.slides.Presentation();
try {
    // Dapatkan slide pertama.
    let slide = presentation.getSlides().get_Item(0);

    // Tambahkan auto shape dengan tipe Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Putar shape sebesar 5 derajat.
    shape.setRotation(5);

    // Simpan file PPTX ke disk.
    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![Rotasi bentuk](shape-rotation.png)

## **Tambahkan Efek Bevel 3D**

Aspose.Slides memungkinkan Anda menerapkan efek bevel 3D pada bentuk dengan mengkonfigurasi properti [ThreeDFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/threedformat/)‑nya.

Untuk menambahkan efek bevel 3D pada sebuah bentuk, ikuti langkah berikut:

1. Instansiasikan class [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/).
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) ke slide.
4. Konfigurasikan [ThreeDFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/threedformat/) bentuk untuk mendefinisikan pengaturan bevel.
5. Simpan presentasi.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Buat instance dari kelas Presentation.
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

    // Atur properti ThreeDFormat shape.
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

Hasil:

![Efek bevel 3D](3D-bevel-effect.png)

## **Tambahkan Efek Rotasi 3D**

Aspose.Slides memungkinkan Anda menerapkan efek rotasi 3D pada bentuk dengan mengkonfigurasi properti [ThreeDFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/threedformat/)‑nya.

Untuk menerapkan rotasi 3D pada sebuah bentuk:

1. Buat instance dari [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) class.
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) ke slide.
4. Gunakan [setCameraType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/camera/#setCameraType) dan [setLightType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/lightrig/#setLightType) untuk mendefinisikan rotasi 3D.
5. Simpan presentasi.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Buat instance dari kelas Presentation.
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

Hasil:

![Efek rotasi 3D](3D-rotation-effect.png)

## **Kontrol Rendering Hitam-putih untuk Bentuk**

Metode [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) menentukan bagaimana sebuah bentuk individual dirender ketika presentasi dilihat atau diproses dalam mode hitam‑putih. Metode ini tidak mengaktifkan tampilan hitam‑putih sendiri, dan tidak mengubah isian, garis, atau pemformatan lain dalam mode warna normal.

Gunakan nilai dari enumerasi [BlackWhiteMode](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/blackwhitemode/) untuk memilih perilaku yang diinginkan. Misalnya, `Automatic` membiarkan aplikasi rendering memilih konversi, `Gray` dan `LightGray` menggunakan warna abu‑abu, `BlackWhite` hanya menggunakan hitam dan putih, `Black` dan `White` memaksa satu warna, `Color` mempertahankan warna normal, dan `Hidden` menghilangkan bentuk dalam mode hitam‑putih. `NotDefined` berarti tidak ada mode tingkat bentuk yang ditetapkan.

Kode JavaScript berikut membuat bentuk berwarna dan membuatnya tampil abu‑abu dalam mode tampilan hitam‑putih:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));

    // Pertahankan isian oranye dalam mode warna, tetapi render bentuk dengan pewarnaan abu-abu dalam mode hitam-putih.
    shape.setBlackWhiteMode(java.newByte(aspose.slides.BlackWhiteMode.Gray));

    presentation.save("shape_black_white_mode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dalam mode warna normal, persegi panjang mempertahankan isian oranye. Dalam alur kerja tampilan hitam‑putih, ia menggunakan pewarnaan abu‑abu karena mode‑nya disetel ke `Gray`. Ini memungkinkan Anda mempertahankan slide berwarna penuh sambil mendefinisikan tampilan khusus untuk pencetakan, pratinjau, atau alur kerja lain yang menghormati pengaturan tampilan hitam‑putih presentasi.

## **Reset Pemformatan**

Kode JavaScript berikut menunjukkan cara mereset pemformatan slide dan mengembalikan posisi, ukuran, serta pemformatan semua bentuk dengan placeholder pada [LayoutSlide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/layoutslide/) ke pengaturan default mereka:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

Hanya sedikit. Gambar dan media yang disematkan menempati sebagian besar ruang file, sementara parameter bentuk seperti warna, efek, dan gradien disimpan sebagai metadata dan hampir tidak menambah ukuran.

**Bagaimana saya dapat mendeteksi bentuk pada slide yang memiliki pemformatan identik sehingga saya dapat mengelompokkannya?**

Bandingkan setiap properti pemformatan kunci bentuk—pengaturan isian, garis, dan efek. Jika semua nilai yang bersesuaian cocok, perlakukan gaya mereka sebagai identik dan kelompokkan bentuk‑bentuk tersebut secara logis, yang mempermudah manajemen gaya nanti.

**Bisakah saya menyimpan sekumpulan gaya bentuk khusus ke file terpisah untuk digunakan kembali dalam presentasi lain?**

Ya. Simpan contoh bentuk dengan gaya yang diinginkan dalam deck slide templat atau file .POTX. Saat membuat presentasi baru, buka templat, klon bentuk bergaya yang diperlukan, dan terapkan kembali pemformatannya di mana diperlukan.