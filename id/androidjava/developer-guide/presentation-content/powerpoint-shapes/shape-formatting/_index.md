---
title: Format Bentuk PowerPoint di Android
linktitle: Pemformatan Bentuk
type: docs
weight: 20
url: /id/androidjava/shape-formatting/
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
- rendering bentuk grayscale
- putar bentuk
- efek bevel 3D
- efek rotasi 3D
- reset pemformatan
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Pelajari cara memformat bentuk PowerPoint di Android menggunakan Aspose.Slides—atur gaya isian, garis, dan efek untuk file PPT, PPTX, dan ODP dengan presisi dan kontrol penuh."
---
## **Pendahuluan**

Di PowerPoint, Anda dapat menambahkan bentuk ke slide. Karena bentuk terbuat dari garis, Anda dapat memformatnya dengan memodifikasi atau menerapkan efek pada garis tepinya. Selain itu, Anda dapat memformat bentuk dengan menentukan pengaturan yang mengontrol bagaimana bagian dalamnya diisi.

![format-bentuk-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Android via Java menyediakan antarmuka dan metode yang memungkinkan Anda memformat bentuk menggunakan opsi yang sama dengan yang tersedia di PowerPoint.

## **Format Garis**

Menggunakan Aspose.Slides, Anda dapat menentukan gaya garis khusus untuk sebuah bentuk. Langkah‑langkah berikut menjelaskan prosedurnya:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) ke slide.
1. Atur [line style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linestyle/) pada bentuk.
1. Atur lebar garis.
1. Atur [dash style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/) pada garis.
1. Atur warna garis untuk bentuk.
1. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Berikut kode yang menunjukkan cara memformat `AutoShape` persegi panjang:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Membuat instance kelas Presentation yang mewakili file presentasi.
Presentation presentation = new Presentation();
try {
    // Dapatkan slide pertama.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Tambahkan auto shape tipe Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Hapus isian dari shape persegi panjang sehingga hanya garisnya yang terlihat.
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

Efek sketsa membuat garis bentuk terlihat seperti digambar tangan. Gunakan [IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) untuk mengakses pengaturan garis, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/) untuk mengakses pengaturan sketsa, dan [ISketchFormat.setSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/) untuk memilih nilai dari enumerasi [LineSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/).

Berikut kode Java yang menunjukkan cara menerapkan efek [LineSketchType.Curved](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/), membaca nilai yang secara eksplisit ditetapkan, dan menghapus efek dengan [LineSketchType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Akses format garis bentuk dan format sketsanya.
    // Terapkan efek sketsa.
    // Baca efek sketsa yang ditetapkan langsung pada bentuk.
    // Hapus efek sketsa.
} finally {
    presentation.dispose();
}
```

Nilai yang dikembalikan oleh [ISketchFormat.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/) mewakili pengaturan yang ditetapkan langsung pada bentuk. Jika pemformatan garis dapat diwarisi dari tema, master slide, atau layout slide, gunakan [ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/), akses [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformateffectivedata/), dan baca [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformateffectivedata/). Nilai efektif mencerminkan pemformatan yang sebenarnya diterapkan setelah pewarisan diselesaikan:

```java
import com.aspose.slides.*;

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

Berikut tiga opsi jenis sambungan:

* Bulat
* Miter
* Bevel

Secara default, ketika PowerPoint menyambungkan dua garis pada sudut (misalnya pada sudut sebuah bentuk), ia menggunakan pengaturan **Bulat**. Namun, jika Anda menggambar bentuk dengan sudut tajam, Anda mungkin lebih menyukai opsi **Miter**.

![Gaya sambungan dalam presentasi](join-style-powerpoint.png)

Berikut kode Java yang menunjukkan cara tiga persegi panjang (seperti pada gambar di atas) dibuat menggunakan pengaturan sambungan Miter, Bevel, dan Bulat:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Membuat instance kelas Presentation yang mewakili file presentasi.
Presentation presentation = new Presentation();
try {
    // Dapatkan slide pertama.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Tambahkan tiga auto shape tipe Rectangle.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Atur warna isian untuk setiap shape persegi panjang.
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

## **Isian Gradien**

Di PowerPoint, Isian Gradien adalah opsi pemformatan yang memungkinkan Anda menerapkan campuran warna berkelanjutan pada sebuah bentuk. Misalnya, Anda dapat menerapkan dua atau lebih warna sehingga satu secara perlahan memudar menjadi warna lain.

Berikut cara menerapkan isian gradien pada sebuah bentuk menggunakan Aspose.Slides:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) ke slide.
1. Atur [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) bentuk menjadi `Gradient`.
1. Tambahkan dua warna pilihan Anda dengan posisi yang ditentukan menggunakan metode `add` dari koleksi stop gradien yang diekspos oleh antarmuka [IGradientFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/) .
1. Simpan presentasi yang dimodifikasi sebagai file PPTX.

```java
import com.aspose.slides.*;

// Membuat instance kelas Presentation yang mewakili file presentasi.
Presentation presentation = new Presentation();
try {
    // Dapatkan slide pertama.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Tambahkan auto shape tipe Ellipse.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Terapkan pemformatan gradien pada elips.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Atur arah gradien.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Tambahkan dua gradient stop.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Simpan file PPTX ke disk.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Elips dengan isian gradien](gradient-fill.png)

Jika gradien terlihat berbeda dalam gambar yang diekspor dibandingkan dengan di PowerPoint, lihat [Choose a Gradient Rendering Style](/slides/id/androidjava/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Anda dapat memilih gaya rendering tanpa mengubah isian gradien yang disimpan dalam presentasi.

## **Isian Pola**

Di PowerPoint, Isian Pola adalah opsi pemformatan yang memungkinkan Anda menerapkan desain dua warna—seperti titik, garis, crosshatch, atau ceklis—pada sebuah bentuk. Anda dapat memilih warna khusus untuk latar depan dan latar belakang pola.

Aspose.Slides menyediakan lebih dari 45 gaya pola yang telah ditentukan sebelumnya yang dapat Anda terapkan pada bentuk untuk meningkatkan daya tarik visual presentasi Anda. Bahkan setelah memilih pola yang telah ditentukan, Anda masih dapat menentukan warna tepat yang harus digunakan.

Berikut cara menerapkan isian pola pada sebuah bentuk menggunakan Aspose.Slides:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) ke slide.
1. Atur [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) bentuk menjadi `Pattern`.
1. Pilih gaya pola dari opsi yang telah ditentukan.
1. Atur [Background Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/patternformat/#getBackColor--) pola.
1. Atur [Foreground Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/patternformat/#getForeColor--) pola.
1. Simpan presentasi yang dimodifikasi sebagai file PPTX.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Membuat instance kelas Presentation yang mewakili file presentasi.
Presentation presentation = new Presentation();
try {
    // Dapatkan slide pertama.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Tambahkan auto shape tipe Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Atur jenis isian menjadi Pattern.
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

![Persegi dengan isian pola](pattern-fill.png)

## **Isian Gambar**

Di PowerPoint, Isian Gambar adalah opsi pemformatan yang memungkinkan Anda memasukkan gambar ke dalam sebuah bentuk—secara efektif menggunakan gambar tersebut sebagai latar belakang bentuk.

Berikut cara menggunakan Aspose.Slides untuk menerapkan isian gambar pada sebuah bentuk:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) ke slide.
1. Atur [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) bentuk menjadi `Picture`.
1. Atur mode isian gambar menjadi `Tile` (atau mode lain yang diinginkan).
1. Buat objek [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) dari gambar yang ingin Anda gunakan.
1. Kirim gambar ke metode `ISlidesPicture.setImage` .
1. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Misalkan kami memiliki file "lotus.png" dengan gambar berikut:

![Gambar lotus](lotus.png)

Berikut kode Java yang menunjukkan cara mengisi sebuah bentuk dengan gambar:

```java
import com.aspose.slides.*;

// Membuat instance kelas Presentation yang mewakili file presentasi.
Presentation presentation = new Presentation();
try {
    // Dapatkan slide pertama.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Tambahkan auto shape tipe Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Atur jenis isian menjadi Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Atur mode isian gambar.
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

![Bentuk dengan isian gambar](picture-fill.png)

### **Utile Gambar Sebagai Tekstur**

Jika Anda ingin menyetel gambar ubin sebagai tekstur dan menyesuaikan perilaku ubin, Anda dapat menggunakan metode berikut dari antarmuka [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) dan kelas [PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) : Menetapkan mode isian gambar—baik `Tile` atau `Stretch` .
- [setTileAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-) : Menentukan perataan ubin di dalam bentuk.
- [setTileFlip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-) : Mengontrol apakah ubin dibalik secara horizontal, vertikal, atau keduanya.
- [setTileOffsetX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-) : Menetapkan offset horizontal ubin (dalam poin) dari asal bentuk.
- [setTileOffsetY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-) : Menetapkan offset vertikal ubin (dalam poin) dari asal bentuk.
- [setTileScaleX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-) : Mendefinisikan skala horizontal ubin sebagai persentase.
- [setTileScaleY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-) : Mendefinisikan skala vertikal ubin sebagai persentase.

Berikut contoh kode yang menunjukkan cara menambahkan bentuk persegi panjang dengan isian gambar ubin dan mengonfigurasi opsi ubin:

```java
import com.aspose.slides.*;

// Membuat instance kelas Presentation yang mewakili file presentasi.
Presentation presentation = new Presentation();
try {
    // Dapatkan slide pertama.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Tambahkan auto shape persegi panjang.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Atur jenis isian shape menjadi Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Muat gambar dan tambahkan ke sumber daya presentasi.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Tetapkan gambar ke shape.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Konfigurasikan mode isian gambar dan properti ubin.
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

## **Isian Warna Solid**

Di PowerPoint, Isian Warna Solid adalah opsi pemformatan yang mengisi bentuk dengan satu warna seragam. Latar belakang polos ini diterapkan tanpa gradien, tekstur, atau pola apa pun.

Untuk menerapkan isian warna solid pada sebuah bentuk menggunakan Aspose.Slides, ikuti langkah‑langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) ke slide.
1. Atur [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) bentuk menjadi `Solid`.
1. Tetapkan warna isian pilihan Anda ke bentuk.
1. Simpan presentasi yang dimodifikasi sebagai file PPTX.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Membuat instance kelas Presentation yang mewakili file presentasi.
Presentation presentation = new Presentation();
try {
    // Dapatkan slide pertama.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Tambahkan auto shape tipe Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Atur jenis isian menjadi Solid.
    shape.getFillFormat().setFillType(FillType.Solid);

    // Atur warna isian.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // Simpan file PPTX ke disk.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Bentuk dengan isian warna solid](solid-color-fill.png)

## **Atur Transparansi**

Di PowerPoint, ketika Anda menerapkan isian warna solid, gradien, gambar, atau tekstur pada bentuk, Anda juga dapat mengatur tingkat transparansi untuk mengontrol opasitas isian. Nilai transparansi yang lebih tinggi membuat bentuk menjadi lebih tembus pandang, sehingga latar belakang atau objek di bawahnya terlihat sebagian.

Aspose.Slides memungkinkan Anda mengatur tingkat transparansi dengan menyesuaikan nilai alfa pada warna yang digunakan untuk isian. Berikut caranya:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) ke slide.
1. Atur [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) menjadi `Solid`.
1. Gunakan `Color` untuk mendefinisikan warna dengan transparansi (komponen `alpha` mengontrol transparansi).
1. Simpan presentasi.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Membuat instance kelas Presentation yang mewakili file presentasi.
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

![Bentuk transparan](shape-transparency.png)

## **Putar Bentuk**

Aspose.Slides memungkinkan Anda memutar bentuk dalam presentasi PowerPoint. Ini dapat berguna saat menempatkan elemen visual dengan kebutuhan penyelarasan atau desain tertentu.

Untuk memutar sebuah bentuk pada slide, ikuti langkah‑langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) ke slide.
1. Atur properti rotasi bentuk ke sudut yang diinginkan.
1. Simpan presentasi.

```java
import com.aspose.slides.*;

// Membuat instance kelas Presentation yang mewakili file presentasi.
Presentation presentation = new Presentation();
try {
    // Dapatkan slide pertama.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Tambahkan auto shape tipe Rectangle.
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

Aspose.Slides memungkinkan Anda menerapkan efek bevel 3D pada bentuk dengan mengonfigurasi properti [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/) mereka.

Untuk menambahkan efek bevel 3D pada sebuah bentuk, ikuti langkah‑langkah berikut:

1. Instansiasikan kelas [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) ke slide.
1. Konfigurasikan [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/) bentuk untuk mendefinisikan pengaturan bevel.
1. Simpan presentasi.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Buat sebuah instance dari kelas Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Tambahkan sebuah shape ke slide.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // Atur properti ThreeDFormat shape.
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

Aspose.Slides memungkinkan Anda menerapkan efek rotasi 3D pada bentuk dengan mengonfigurasi properti [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/) mereka.

Untuk menerapkan rotasi 3D pada sebuah bentuk:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) ke slide.
1. Gunakan [setCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setCameraType-int-) dan [setLightType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) untuk mendefinisikan rotasi 3D.
1. Simpan presentasi.

```java
import com.aspose.slides.*;

// Buat sebuah instance dari kelas Presentation.
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

## **Kontrol Rendering Hitam-putih untuk Bentuk**

Metode [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) menentukan cara sebuah bentuk individual dirender ketika presentasi dilihat atau diproses dalam mode hitam‑putih. Metode ini tidak mengaktifkan tampilan hitam‑putih sendiri, dan tidak mengubah isian, garis, atau pemformatan lain bentuk dalam mode warna normal.

Gunakan nilai dari kelas [BlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blackwhitemode/) untuk memilih perilaku yang diinginkan. Misalnya, `Automatic` membiarkan aplikasi rendering memilih konversi, `Gray` dan `LightGray` menggunakan warna abu‑abu, `BlackWhite` hanya menggunakan hitam dan putih, `Black` dan `White` memaksa satu warna, `Color` mempertahankan warna normal, dan `Hidden` menghilangkan bentuk dalam mode hitam‑putih. `NotDefined` berarti tidak ada mode tingkat bentuk yang ditetapkan.

Berikut kode Java yang membuat bentuk berwarna dan membuatnya terlihat abu‑abu dalam mode tampilan hitam‑putih:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    // Pertahankan isian oranye dalam mode warna, tetapi render bentuk dengan pewarnaan abu-abu dalam mode hitam-putih.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dalam mode warna normal, persegi panjang mempertahankan isian oranye. Dalam alur kerja tampilan hitam‑putih, ia menggunakan warna abu‑abu karena mode‑nya disetel ke `Gray`. Ini memungkinkan Anda mempertahankan slide berwarna penuh sambil mendefinisikan tampilan khusus untuk pencetakan, pratinjau, atau alur kerja lain yang menghormati pengaturan tampilan hitam‑putih presentasi.

## **Reset Pemformatan**

Berikut kode Java yang menunjukkan cara mereset pemformatan slide dan mengembalikan posisi, ukuran, serta pemformatan semua bentuk dengan placeholder pada [LayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/layoutslide/) ke pengaturan default mereka:

```java
import com.aspose.slides.*;

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

Hanya sedikit saja. Gambar dan media yang disisipkan menempati sebagian besar ruang file, sedangkan parameter bentuk seperti warna, efek, dan gradien disimpan sebagai metadata dan hampir tidak menambah ukuran.

**Bagaimana cara mendeteksi bentuk pada slide yang memiliki pemformatan identik sehingga saya dapat mengelompokkannya?**

Bandingkan properti pemformatan utama setiap bentuk—pengaturan isian, garis, dan efek. Jika semua nilai yang bersesuaian cocok, anggap gaya mereka identik dan kelompokan bentuk‑bentuk tersebut secara logis, yang menyederhanakan manajemen gaya selanjutnya.

**Bisakah saya menyimpan satu set gaya bentuk khusus ke file terpisah untuk digunakan kembali di presentasi lain?**

Ya. Simpan contoh bentuk dengan gaya yang diinginkan dalam template slide deck atau file template .POTX. Saat membuat presentasi baru, buka template, klon bentuk bergaya yang diperlukan, dan terapkan kembali pemformatannya di mana diperlukan.