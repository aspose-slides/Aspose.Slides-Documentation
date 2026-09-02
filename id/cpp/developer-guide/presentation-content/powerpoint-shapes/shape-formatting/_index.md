---
title: Format Bentuk PowerPoint dalam C++
linktitle: Pemformatan Bentuk
type: docs
weight: 20
url: /id/cpp/shape-formatting/
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
- reset pemformatan
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Pelajari cara memformat bentuk PowerPoint dalam C++ menggunakan Aspose.Slides—atur gaya isian, garis, dan efek untuk file PPT, PPTX, dan ODP dengan presisi dan kontrol penuh."
---
## **Pendahuluan**

Di PowerPoint, Anda dapat menambahkan bentuk ke slide. Karena bentuk terdiri dari garis, Anda dapat memformatnya dengan mengubah atau menerapkan efek pada kontur mereka. Selain itu, Anda dapat memformat bentuk dengan menentukan pengaturan yang mengontrol bagaimana interiornya diisi.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for C++ menyediakan antarmuka dan metode yang memungkinkan Anda memformat bentuk menggunakan opsi yang sama tersedia di PowerPoint.

## **Memformat Garis**

Dengan Aspose.Slides, Anda dapat menentukan gaya garis khusus untuk sebuah bentuk. Langkah‑langkah berikut menjelaskan prosedurnya:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/) ke slide.
1. Setel [line style](https://reference.aspose.com/slides/id/cpp/aspose.slides/linestyle/) bentuk.
1. Setel lebar garis.
1. Setel [dash style](https://reference.aspose.com/slides/id/cpp/aspose.slides/linedashstyle/) garis.
1. Setel warna garis untuk bentuk.
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode berikut menunjukkan cara memformat sebuah `AutoShape` persegi panjang:

```cpp
// Buat instance kelas Presentation yang mewakili file presentasi.
auto presentation = MakeObject<Presentation>();

// Dapatkan slide pertama.
auto slide = presentation->get_Slide(0);

// Tambahkan auto shape tipe Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// Setel warna isi untuk shape persegi panjang.
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// Terapkan pemformatan pada garis persegi panjang.
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// Setel warna untuk garis persegi panjang.
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Simpan file PPTX ke disk.
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Hasilnya:

![Garis yang diformat dalam presentasi](formatted-lines.png)

## **Menerapkan Efek Sketsa pada Garis Bentuk**

Efek sketsa membuat garis bentuk tampak seperti digambar tangan. Gunakan [IShape::get_LineFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/get_lineformat/) untuk mengakses pengaturan garis, [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilineformat/get_sketchformat/) untuk mengakses pengaturan sketsa, dan [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/id/cpp/aspose.slides/isketchformat/set_sketchtype/) untuk memilih nilai dari enumerasi [LineSketchType](https://reference.aspose.com/slides/id/cpp/aspose.slides/linesketchtype/).

Kode C++ berikut menunjukkan cara menerapkan efek [LineSketchType::Curved](https://reference.aspose.com/slides/id/cpp/aspose.slides/linesketchtype/), membaca nilai yang secara eksplisit ditetapkan, dan menghapus efek dengan [LineSketchType::None](https://reference.aspose.com/slides/id/cpp/aspose.slides/linesketchtype/):

```cpp
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

// Access the shape's line format and its sketch format.
auto sketchFormat = shape->get_LineFormat()->get_SketchFormat();

// Apply a sketch effect.
sketchFormat->set_SketchType(LineSketchType::Curved);

// Read the sketch effect assigned directly to the shape.
auto explicitSketchType = sketchFormat->get_SketchType();
Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);

// Remove the sketch effect.
sketchFormat->set_SketchType(LineSketchType::None);

presentation->Dispose();
```

Nilai yang dikembalikan oleh [ISketchFormat::get_SketchType](https://reference.aspose.com/slides/id/cpp/aspose.slides/isketchformat/get_sketchtype/) mewakili pengaturan yang ditetapkan langsung pada bentuk. Jika pemformatan garis dapat diwarisi dari tema, master slide, atau layout slide, gunakan [ILineFormat::GetEffective](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilineformat/geteffective/), akses [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/), dan baca [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/id/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/). Nilai efektif mencerminkan pemformatan yang sebenarnya diterapkan setelah pewarisan diselesaikan:

```cpp
auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto lineFormat = shape->get_LineFormat();

auto explicitSketchType = lineFormat->get_SketchFormat()->get_SketchType();
auto effectiveLineFormat = lineFormat->GetEffective();
auto effectiveSketchType = effectiveLineFormat->get_SketchFormat()->get_SketchType();

Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);
Console::WriteLine(u"Effective sketch type: {0}", effectiveSketchType);

presentation->Dispose();
```

## **Memformat Gaya Sambungan**

Berikut tiga opsi jenis sambungan:

* Round
* Miter
* Bevel

Secara default, ketika PowerPoint menyambungkan dua garis pada sudut (seperti pada sudut bentuk), ia menggunakan pengaturan **Round**. Namun, jika Anda menggambar bentuk dengan sudut tajam, Anda mungkin lebih suka opsi **Miter**.

![Gaya sambungan dalam presentasi](join-style-powerpoint.png)

Kode C++ berikut menunjukkan cara tiga persegi panjang (seperti pada gambar di atas) dibuat menggunakan pengaturan sambungan Miter, Bevel, dan Round:

```cpp
// Membuat instance kelas Presentation yang mewakili file presentasi.
auto presentation = MakeObject<Presentation>();

// Dapatkan slide pertama.
auto slide = presentation->get_Slide(0);

// Tambahkan tiga auto shape tipe Rectangle.
auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

// Atur warna isi untuk setiap shape persegi panjang.
shape1->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape2->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape3->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Atur lebar garis.
shape1->get_LineFormat()->set_Width(15);
shape2->get_LineFormat()->set_Width(15);
shape3->get_LineFormat()->set_Width(15);

// Atur warna untuk garis setiap persegi panjang.
shape1->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape3->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Atur gaya sambungan.
shape1->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
shape2->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
shape3->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

// Tambahkan teks ke setiap persegi panjang.
shape1->get_TextFrame()->set_Text(u"Miter Join Style");
shape2->get_TextFrame()->set_Text(u"Bevel Join Style");
shape3->get_TextFrame()->set_Text(u"Round Join Style");

// Simpan file PPTX ke disk.
presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Isian Gradien**

Di PowerPoint, Isian Gradien adalah opsi pemformatan yang memungkinkan Anda menerapkan perpaduan warna berkelanjutan ke sebuah bentuk. Misalnya, Anda dapat menerapkan dua atau lebih warna sehingga satu secara bertahap memudar menjadi warna lain.

Berikut cara menerapkan isian gradien ke bentuk menggunakan Aspose.Slides:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/) ke slide.
1. Setel [FillType](https://reference.aspose.com/slides/id/cpp/aspose.slides/filltype/) bentuk menjadi `Gradient`.
1. Tambahkan dua warna pilihan Anda dengan posisi yang ditentukan menggunakan metode `Add` pada koleksi gradient stop yang diekspos oleh antarmuka [IGradientFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/igradientformat/).
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode C++ berikut menunjukkan cara menerapkan efek isian gradien ke sebuah elips:

```cpp
// Membuat instance kelas Presentation yang mewakili file presentasi.
auto presentation = MakeObject<Presentation>();

// Dapatkan slide pertama.
auto slide = presentation->get_Slide(0);

// Tambahkan auto shape tipe Ellipse.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// Terapkan pemformatan gradien ke elips.
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// Atur arah gradien.
shape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// Tambahkan dua gradient stop.
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// Simpan file PPTX ke disk.
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Hasilnya:

![Elips dengan isian gradien](gradient-fill.png)

## **Isian Pola**

Di PowerPoint, Isian Pola adalah opsi pemformatan yang memungkinkan Anda menerapkan desain dua warna—seperti titik, garis, silang, atau kotak—ke sebuah bentuk. Anda dapat memilih warna khusus untuk latar depan dan latar belakang pola.

Aspose.Slides menyediakan lebih dari 45 gaya pola pra‑definisi yang dapat Anda terapkan pada bentuk untuk meningkatkan daya tarik visual presentasi Anda. Bahkan setelah memilih pola pra‑definisi, Anda masih dapat menentukan warna tepat yang harus digunakan.

Berikut cara menerapkan isian pola ke bentuk menggunakan Aspose.Slides:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/) ke slide.
1. Setel [FillType](https://reference.aspose.com/slides/id/cpp/aspose.slides/filltype/) bentuk menjadi `Pattern`.
1. Pilih gaya pola dari opsi pra‑definisi.
1. Setel [Background Color](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipatternformat/get_backcolor/) pola.
1. Setel [Foreground Color](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipatternformat/get_forecolor/) pola.
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode C++ berikut menunjukkan cara menerapkan isian pola ke sebuah persegi panjang:

```cpp
// Membuat instance kelas Presentation yang mewakili file presentasi.
auto presentation = MakeObject<Presentation>();

// Dapatkan slide pertama.
auto slide = presentation->get_Slide(0);

// Tambahkan auto shape tipe Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Setel tipe isi menjadi Pattern.
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// Setel gaya pola.
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// Setel warna latar belakang dan latar depan pola.
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// Simpan file PPTX ke disk.
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Hasilnya:

![Persegi panjang dengan isian pola](pattern-fill.png)

## **Isian Gambar**

Di PowerPoint, Isian Gambar adalah opsi pemformatan yang memungkinkan Anda menyisipkan gambar di dalam bentuk—secara efektif menggunakan gambar sebagai latar belakang bentuk.

Berikut cara menggunakan Aspose.Slides untuk menerapkan isian gambar ke bentuk:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/) ke slide.
1. Setel [FillType](https://reference.aspose.com/slides/id/cpp/aspose.slides/filltype/) bentuk menjadi `Picture`.
1. Setel mode isian gambar ke `Tile` (atau mode lain yang diinginkan).
1. Buat objek [IPPImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/ippimage/) dari gambar yang ingin Anda gunakan.
1. Berikan gambar tersebut ke metode `ISlidesPicture.set_Image`.
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Misalkan kami memiliki file "lotus.png" dengan gambar berikut:

![Gambar lotus](lotus.png)

Kode C++ berikut menunjukkan cara mengisi bentuk dengan gambar:

```cpp
// Membuat instance kelas Presentation yang mewakili file presentasi.
auto presentation = MakeObject<Presentation>();

// Dapatkan slide pertama.
auto slide = presentation->get_Slide(0);

// Tambahkan auto shape tipe Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// Setel tipe isi menjadi Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Setel mode isi gambar.
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// Muat gambar dan tambahkan ke sumber daya presentasi.
auto image = Images::FromFile(u"lotus.png");
auto picture = presentation->get_Images()->AddImage(image);
image->Dispose();

// Setel gambar.
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(picture);

// Simpan file PPTX ke disk.
presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Hasilnya:

![Bentuk dengan isian gambar](picture-fill.png)

### **Tile Picture Sebagai Tekstur**

Jika Anda ingin mengatur gambar berulang sebagai tekstur dan menyesuaikan perilaku pengulangan, Anda dapat menggunakan metode berikut dari antarmuka [IPictureFillFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipicturefillformat/) dan kelas [PictureFillFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/picturefillformat/):

- [set_PictureFillMode](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): Menetapkan mode isian gambar—baik `Tile` atau `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): Menentukan perataan ubin di dalam bentuk.
- [set_TileFlip](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipicturefillformat/set_tileflip/): Mengontrol apakah ubin dibalik secara horizontal, vertikal, atau keduanya.
- [set_TileOffsetX](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): Menetapkan offset horizontal ubin (dalam point) dari asal bentuk.
- [set_TileOffsetY](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): Menetapkan offset vertikal ubin (dalam point) dari asal bentuk.
- [set_TileScaleX](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): Menentukan skala horizontal ubin sebagai persentase.
- [set_TileScaleY](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): Menentukan skala vertikal ubin sebagai persentase.

Contoh kode berikut memperlihatkan cara menambahkan bentuk persegi panjang dengan isian gambar berulang dan mengonfigurasi opsi ubin:

```cpp
// Membuat instance kelas Presentation yang mewakili file presentasi.
auto presentation = MakeObject<Presentation>();

// Dapatkan slide pertama.
auto firstSlide = presentation->get_Slide(0);

// Tambahkan auto shape persegi panjang.
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// Setel tipe isi shape menjadi Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Muat gambar dan tambahkan ke sumber daya presentasi.
auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

// Tetapkan gambar ke shape.
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// Konfigurasikan mode isi gambar dan properti pengulangan.
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

// Simpan file PPTX ke disk.
presentation->Save(u"tile.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Hasilnya:

![Opsi ubin](tile-options.png)

## **Isian Warna Solid**

Di PowerPoint, Isian Warna Solid adalah opsi pemformatan yang mengisi bentuk dengan satu warna seragam. Warna latar belakang polos ini diterapkan tanpa gradien, tekstur, atau pola apa pun.

Untuk menerapkan isian warna solid ke bentuk menggunakan Aspose.Slides, ikuti langkah‑langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/) ke slide.
1. Setel [FillType](https://reference.aspose.com/slides/id/cpp/aspose.slides/filltype/) bentuk menjadi `Solid`.
1. Tetapkan warna isian pilihan Anda ke bentuk.
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode C++ berikut menunjukkan cara menerapkan isian warna solid ke persegi panjang dalam slide PowerPoint:

```cpp
// Membuat instance kelas Presentation yang mewakili file presentasi.
auto presentation = MakeObject<Presentation>();

// Dapatkan slide pertama.
auto slide = presentation->get_Slide(0);

// Tambahkan auto shape tipe Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Setel tipe isi menjadi Solid.
shape->get_FillFormat()->set_FillType(FillType::Solid);

// Setel warna isi.
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// Simpan file PPTX ke disk.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Hasilnya:

![Bentuk dengan isian warna solid](solid-color-fill.png)

## **Mengatur Transparansi**

Di PowerPoint, ketika Anda menerapkan isian warna solid, gradien, gambar, atau tekstur ke bentuk, Anda juga dapat mengatur tingkat transparansi untuk mengontrol opasitas isian. Nilai transparansi yang lebih tinggi membuat bentuk menjadi lebih tembus pandang, memungkinkan latar belakang atau objek di bawahnya terlihat sebagian.

Aspose.Slides memungkinkan Anda mengatur tingkat transparansi dengan menyesuaikan nilai alfa pada warna yang digunakan untuk isian. Berikut caranya:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/) ke slide.
1. Setel [FillType](https://reference.aspose.com/slides/id/cpp/aspose.slides/filltype/) menjadi `Solid`.
1. Gunakan `Color` untuk mendefinisikan warna dengan transparansi (komponen `alpha` mengontrol transparansi).
1. Simpan presentasi.

Kode C++ berikut menunjukkan cara menerapkan warna isian transparan ke persegi panjang:

```cpp
// Membuat instance kelas Presentation yang mewakili file presentasi.
auto presentation = MakeObject<Presentation>();

// Dapatkan slide pertama.
auto slide = presentation->get_Slide(0);

// Tambahkan auto shape persegi panjang solid.
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Tambahkan auto shape persegi panjang transparan di atas shape solid.
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// Simpan file PPTX ke disk.
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Hasilnya:

![Bentuk transparan](shape-transparency.png)

## **Memutar Bentuk**

Aspose.Slides memungkinkan Anda memutar bentuk dalam presentasi PowerPoint. Hal ini dapat berguna saat menempatkan elemen visual dengan kebutuhan penyelarasan atau desain tertentu.

Untuk memutar bentuk pada slide, ikuti langkah‑langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/) ke slide.
1. Setel properti rotasi bentuk ke sudut yang diinginkan.
1. Simpan presentasi.

Kode C++ berikut menunjukkan cara memutar bentuk sebesar 5 derajat:

```cpp
// Membuat instance kelas Presentation yang mewakili file presentasi.
auto presentation = MakeObject<Presentation>();

// Dapatkan slide pertama.
auto slide = presentation->get_Slide(0);

// Tambahkan auto shape tipe Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Putar shape sebesar 5 derajat.
shape->set_Rotation(5);

// Simpan file PPTX ke disk.
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Hasilnya:

![Rotasi bentuk](shape-rotation.png)

## **Menambahkan Efek Bevel 3D**

Aspose.Slides memungkinkan Anda menerapkan efek bevel 3D ke bentuk dengan mengonfigurasi properti [ThreeDFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/threedformat/) mereka.

Untuk menambahkan efek bevel 3D ke bentuk, ikuti langkah‑langkah berikut:

1. Instansiasi kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/) ke slide.
1. Konfigurasikan [ThreeDFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/threedformat/) bentuk untuk menentukan pengaturan bevel.
1. Simpan presentasi.

Kode C++ berikut memperlihatkan cara menerapkan efek bevel 3D ke bentuk:

```cpp
// Buat instance dari kelas Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Add a shape to the slide.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// Set the shape's ThreeDFormat properties.
shape->get_ThreeDFormat()->set_Depth(4.0);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

// Save the presentation as a PPTX file.
presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Hasilnya:

![Efek bevel 3D](3D-bevel-effect.png)

## **Menambahkan Efek Rotasi 3D**

Aspose.Slides memungkinkan Anda menerapkan efek rotasi 3D ke bentuk dengan mengonfigurasi properti [ThreeDFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/threedformat/) mereka.

Untuk menerapkan rotasi 3D ke bentuk:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/) ke slide.
1. Gunakan [set_CameraType](https://reference.aspose.com/slides/id/cpp/aspose.slides/icamera/set_cameratype/) dan [set_LightType](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilightrig/set_lighttype/) untuk mendefinisikan rotasi 3D.
1. Simpan presentasi.

Kode C++ berikut menunjukkan cara menerapkan efek rotasi 3D ke bentuk:

```cpp
// Buat instance dari kelas Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_TextFrame()->set_Text(u"Hello, Aspose!");

shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// Simpan presentasi sebagai file PPTX.
presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Hasilnya:

![Efek rotasi 3D](3D-rotation-effect.png)

## **Mengatur Ulang Pemformatan**

Kode C++ berikut menunjukkan cara mengatur ulang pemformatan slide dan mengembalikan posisi, ukuran, serta pemformatan semua bentuk dengan placeholder pada [LayoutSlide](https://reference.aspose.com/slides/id/cpp/aspose.slides/layoutslide/) ke pengaturan default mereka:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // Reset setiap shape pada slide yang memiliki placeholder pada layout.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Apakah pemformatan bentuk memengaruhi ukuran file presentasi akhir?**

Hanya secara minimal. Gambar dan media yang disisipkan memakan sebagian besar ruang file, sementara parameter bentuk seperti warna, efek, dan gradien disimpan sebagai metadata dan hampir tidak menambah ukuran.

**Bagaimana cara mendeteksi bentuk pada slide yang memiliki pemformatan identik sehingga saya dapat mengelompokkannya?**

Bandingkan masing‑masing properti pemformatan utama bentuk—pengaturan isian, garis, dan efek. Jika semua nilai yang bersesuaian cocok, perlakukan gaya mereka sebagai identik dan kelompokkan bentuk‑bentuk tersebut secara logis, yang mempermudah pengelolaan gaya di kemudian hari.

**Apakah saya dapat menyimpan seperangkat gaya bentuk kustom ke file terpisah untuk digunakan kembali di presentasi lain?**

Ya. Simpan contoh bentuk dengan gaya yang diinginkan dalam deck slide templat atau file .POTX. Saat membuat presentasi baru, buka templat tersebut, kloning bentuk yang sudah bergaya yang Anda perlukan, dan terapkan kembali pemformatannya sesuai kebutuhan.