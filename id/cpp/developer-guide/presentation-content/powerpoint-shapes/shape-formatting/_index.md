---
title: Format Bentuk PowerPoint di C++
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
- C++
- Aspose.Slides
description: "Pelajari cara memformat bentuk PowerPoint di C++ menggunakan Aspose.Slides—atur gaya isi, garis, dan efek untuk file PPT, PPTX, dan ODP dengan presisi dan kontrol penuh."
---
## **Pendahuluan**

Di PowerPoint, Anda dapat menambahkan bentuk ke slide. Karena bentuk terdiri dari garis, Anda dapat memformatnya dengan memodifikasi atau menerapkan efek pada outline-nya. Selain itu, Anda dapat memformat bentuk dengan menentukan pengaturan yang mengontrol bagaimana bagian dalamnya diisi.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides untuk C++ menyediakan antarmuka dan metode yang memungkinkan Anda memformat bentuk menggunakan opsi yang sama tersedia di PowerPoint.

## **Format Garis**

Menggunakan Aspose.Slides, Anda dapat menentukan gaya garis khusus untuk sebuah bentuk. Langkah‑langkah berikut menjelaskan prosedurnya:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) ke slide.
1. Atur [gaya garis](https://reference.aspose.com/slides/cpp/aspose.slides/linestyle/) bentuk.
1. Atur lebar garis.
1. Atur [gaya dash](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/) garis.
1. Atur warna garis untuk bentuk.
1. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Kode berikut menunjukkan cara memformat sebuah `AutoShape` persegi panjang:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LineDashStyle.h>
#include <DOM/LineStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Instansiasi kelas Presentation yang merepresentasikan file presentasi.
auto presentation = MakeObject<Presentation>();

// Dapatkan slide pertama.
auto slide = presentation->get_Slide(0);

// Tambahkan auto shape tipe Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// Atur warna isi untuk shape persegi panjang.
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// Terapkan pemformatan pada garis persegi panjang.
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// Atur warna untuk garis persegi panjang.
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Simpan file PPTX ke disk.
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Hasilnya:

![Garis yang diformat dalam presentasi](formatted-lines.png)

## **Terapkan Efek Sketsa pada Garis Bentuk**

Efek sketsa membuat garis bentuk terlihat digambar tangan. Gunakan [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) untuk mengakses pengaturan garis, [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/get_sketchformat/) untuk mengakses pengaturan sketsa, dan [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/set_sketchtype/) untuk memilih nilai dari enumerasi [LineSketchType](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/).

Kode C++ berikut menunjukkan cara menerapkan efek [LineSketchType::Curved](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/), membaca nilai yang ditetapkan secara eksplisit, dan menghapus efek dengan [LineSketchType::None](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/):

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

Nilai yang dikembalikan oleh [ISketchFormat::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/get_sketchtype/) mewakili pengaturan yang ditetapkan langsung pada bentuk. Jika pemformatan garis dapat diwarisi dari tema, master slide, atau layout slide, gunakan [ILineFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/geteffective/), akses [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/), dan baca [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/). Nilai efektif mencerminkan pemformatan yang sebenarnya diterapkan setelah pewarisan diselesaikan:

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

## **Format Gaya Sambungan**

Berikut tiga opsi tipe sambungan:

* Round
* Miter
* Bevel

Secara default, ketika PowerPoint menyambungkan dua garis pada sudut (seperti pada sudut bentuk), ia menggunakan pengaturan **Round**. Namun, jika Anda menggambar bentuk dengan sudut tajam, Anda mungkin lebih memilih opsi **Miter**.

![Gaya sambungan dalam presentasi](join-style-powerpoint.png)

Kode C++ berikut menunjukkan cara tiga persegi panjang (seperti pada gambar di atas) dibuat menggunakan pengaturan tipe sambungan Miter, Bevel, dan Round:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LineJoinStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Instansiasi kelas Presentation yang merepresentasikan file presentasi.
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

## **Isi Gradien**

Di PowerPoint, Isi Gradien adalah opsi pemformatan yang memungkinkan Anda menerapkan perpaduan warna kontinu pada sebuah bentuk. Misalnya, Anda dapat menerapkan dua atau lebih warna sehingga satu secara bertahap memudar ke warna lainnya.

Berikut cara menerapkan isi gradien pada bentuk menggunakan Aspose.Slides:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) ke slide.
1. Atur [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) bentuk ke `Gradient`.
1. Tambahkan dua warna pilihan Anda dengan posisi yang ditentukan menggunakan metode `Add` dari koleksi gradient stop yang diekspose oleh antarmuka [IGradientFormat](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/).
1. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Kode C++ berikut menunjukkan cara menerapkan efek isi gradien pada sebuah elips:

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientDirection.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/PresetColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instansiasi kelas Presentation yang merepresentasikan file presentasi.
auto presentation = MakeObject<Presentation>();

// Dapatkan slide pertama.
auto slide = presentation->get_Slide(0);

// Tambahkan auto shape tipe Ellipse.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// Terapkan pemformatan gradien pada elips.
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

![Elips dengan isi gradien](gradient-fill.png)

Jika gradien terlihat berbeda pada gambar yang diekspor dibandingkan dengan di PowerPoint, lihat [Pilih Gaya Rendering Gradien](/slides/id/cpp/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Anda dapat memilih gaya rendering tanpa mengubah isi gradien yang disimpan dalam presentasi.

## **Isi Pola**

Di PowerPoint, Isi Pola adalah opsi pemformatan yang memungkinkan Anda menerapkan desain dua warna—seperti titik, garis, silang, atau pola kotak—pada sebuah bentuk. Anda dapat memilih warna khusus untuk latar depan dan latar belakang pola.

Aspose.Slides menyediakan lebih dari 45 gaya pola bawaan yang dapat Anda terapkan pada bentuk untuk meningkatkan daya tarik visual presentasi Anda. Bahkan setelah memilih pola bawaan, Anda tetap dapat menentukan warna persis yang harus digunakan.

Berikut cara menerapkan isi pola pada bentuk menggunakan Aspose.Slides:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) ke slide.
1. Atur [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) bentuk ke `Pattern`.
1. Pilih gaya pola dari opsi bawaan.
1. Atur [Warna Latar Belakang](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_backcolor/) pola.
1. Atur [Warna Depan](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_forecolor/) pola.
1. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Kode C++ berikut menunjukkan cara menerapkan isi pola pada sebuah persegi panjang:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPatternFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Instansiasi kelas Presentation yang merepresentasikan file presentasi.
auto presentation = MakeObject<Presentation>();

// Dapatkan slide pertama.
auto slide = presentation->get_Slide(0);

// Tambahkan auto shape tipe Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Atur tipe isi menjadi Pattern.
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// Atur gaya pola.
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// Atur warna latar belakang dan latar depan pola.
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// Simpan file PPTX ke disk.
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Hasilnya:

![Persegi panjang dengan isi pola](pattern-fill.png)

## **Isi Gambar**

Di PowerPoint, Isi Gambar adalah opsi pemformatan yang memungkinkan Anda menyisipkan gambar di dalam sebuah bentuk—secara efektif menggunakan gambar sebagai latar belakang bentuk.

Berikut cara menggunakan Aspose.Slides untuk menerapkan isi gambar pada sebuah bentuk:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) ke slide.
1. Atur [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) bentuk ke `Picture`.
1. Atur mode isi gambar ke `Tile` (atau mode lain yang diinginkan).
1. Buat objek [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) dari gambar yang ingin Anda gunakan.
1. Kirimkan gambar ke metode `ISlidesPicture.set_Image`.
1. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Misalkan kami memiliki file "lotus.png" dengan gambar berikut:

![Gambar lotus](lotus.png)

Kode C++ berikut menunjukkan cara mengisi sebuah bentuk dengan gambar:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instansiasi kelas Presentation yang merepresentasikan file presentasi.
auto presentation = MakeObject<Presentation>();

// Dapatkan slide pertama.
auto slide = presentation->get_Slide(0);

// Tambahkan auto shape tipe Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// Atur tipe isi menjadi Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Atur mode isi gambar.
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// Muat gambar dan tambahkan ke sumber daya presentasi.
auto image = Images::FromFile(u"lotus.png");
auto picture = presentation->get_Images()->AddImage(image);
image->Dispose();

// Atur gambar.
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(picture);

// Simpan file PPTX ke disk.
presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Hasilnya:

![Bentuk dengan isi gambar](picture-fill.png)

### **Ubin Gambar Sebagai Tekstur**

Jika Anda ingin mengatur gambar ubin sebagai tekstur dan menyesuaikan perilaku ubin, Anda dapat menggunakan metode berikut dari antarmuka [IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/) dan kelas [PictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/):

- [set_PictureFillMode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): Mengatur mode isi gambar—baik `Tile` atau `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): Menentukan perataan ubin dalam bentuk.
- [set_TileFlip](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileflip/): Mengontrol apakah ubin dibalik secara horizontal, vertikal, atau keduanya.
- [set_TileOffsetX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): Mengatur offset horizontal ubin (dalam poin) dari asal bentuk.
- [set_TileOffsetY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): Mengatur offset vertikal ubin (dalam poin) dari asal bentuk.
- [set_TileScaleX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): Menentukan skala horizontal ubin dalam persentase.
- [set_TileScaleY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): Menentukan skala vertikal ubin dalam persentase.

Kode contoh berikut menunjukkan cara menambahkan bentuk persegi panjang dengan isi gambar ubin dan mengonfigurasi opsi ubin:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instansiasi kelas Presentation yang merepresentasikan file presentasi.
auto presentation = MakeObject<Presentation>();

// Dapatkan slide pertama.
auto firstSlide = presentation->get_Slide(0);

// Tambahkan auto shape persegi panjang.
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// Atur tipe isi shape menjadi Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Muat gambar dan tambahkan ke sumber daya presentasi.
auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

// Tetapkan gambar ke shape.
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// Konfigurasikan mode isi gambar dan properti ubin.
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

## **Isi Warna Solid**

Di PowerPoint, Isi Warna Solid adalah opsi pemformatan yang mengisi sebuah bentuk dengan satu warna seragam. Latar belakang polos ini diterapkan tanpa gradien, tekstur, atau pola apa pun.

Untuk menerapkan isi warna solid pada bentuk menggunakan Aspose.Slides, ikuti langkah‑langkah berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) ke slide.
1. Atur [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) bentuk ke `Solid`.
1. Tetapkan warna isi pilihan Anda ke bentuk.
1. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Kode C++ berikut menunjukkan cara menerapkan isi warna solid pada sebuah persegi panjang dalam slide PowerPoint:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Instansiasi kelas Presentation yang merepresentasikan file presentasi.
auto presentation = MakeObject<Presentation>();

// Dapatkan slide pertama.
auto slide = presentation->get_Slide(0);

// Tambahkan auto shape tipe Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Atur tipe isi menjadi Solid.
shape->get_FillFormat()->set_FillType(FillType::Solid);

// Atur warna isi.
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// Simpan file PPTX ke disk.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Hasilnya:

![Bentuk dengan isi warna solid](solid-color-fill.png)

## **Atur Transparansi**

Di PowerPoint, ketika Anda menerapkan isi warna solid, gradien, gambar, atau tekstur pada bentuk, Anda juga dapat mengatur tingkat transparansi untuk mengontrol opasitas isi. Nilai transparansi yang lebih tinggi membuat bentuk menjadi lebih tembus pandang, memungkinkan latar belakang atau objek di bawahnya terlihat sebagian.

Aspose.Slides memungkinkan Anda mengatur tingkat transparansi dengan menyesuaikan nilai alfa pada warna yang digunakan untuk isi. Berikut caranya:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) ke slide.
1. Atur [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) ke `Solid`.
1. Gunakan `Color` untuk mendefinisikan warna dengan transparansi (komponen `alpha` mengontrol transparansi).
1. Simpan presentasi.

Kode C++ berikut menunjukkan cara menerapkan warna isi transparan pada sebuah persegi panjang:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Instansiasi kelas Presentation yang merepresentasikan file presentasi.
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

## **Putar Bentuk**

Aspose.Slides memungkinkan Anda memutar bentuk dalam presentasi PowerPoint. Hal ini berguna ketika menempatkan elemen visual dengan kebutuhan penyelarasan atau desain tertentu.

Untuk memutar sebuah bentuk pada slide, ikuti langkah‑langkah berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) ke slide.
1. Atur properti rotasi bentuk ke sudut yang diinginkan.
1. Simpan presentasi.

Kode C++ berikut menunjukkan cara memutar sebuah bentuk sebesar 5 derajat:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instansiasi kelas Presentation yang merepresentasikan file presentasi.
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

## **Tambahkan Efek Bevel 3D**

Aspose.Slides memungkinkan Anda menerapkan efek bevel 3D pada bentuk dengan mengonfigurasi properti [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/) mereka.

Untuk menambahkan efek bevel 3D pada sebuah bentuk, ikuti langkah‑langkah berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) ke slide.
1. Konfigurasikan [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/) bentuk untuk mendefinisikan pengaturan bevel.
1. Simpan presentasi.

Kode C++ berikut menunjukkan cara menerapkan efek bevel 3D pada sebuah bentuk:

```cpp
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Buat sebuah instance dari kelas Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Tambah sebuah shape ke slide.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// Atur properti ThreeDFormat shape.
shape->get_ThreeDFormat()->set_Depth(4.0);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

// Simpan presentasi sebagai file PPTX.
presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Hasilnya:

![Efek bevel 3D](3D-bevel-effect.png)

## **Tambahkan Efek Rotasi 3D**

Aspose.Slides memungkinkan Anda menerapkan efek rotasi 3D pada bentuk dengan mengonfigurasi properti [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/) mereka.

Untuk menerapkan rotasi 3D pada sebuah bentuk:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) ke slide.
1. Gunakan [set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/) dan [set_LightType](https://reference.aspose.com/slides/cpp/aspose.slides/ilightrig/set_lighttype/) untuk mendefinisikan rotasi 3D.
1. Simpan presentasi.

Kode C++ berikut menunjukkan cara menerapkan efek rotasi 3D pada sebuah bentuk:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Buat sebuah instance dari kelas Presentation.
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

## **Kontrol Rendering Hitam-Putih untuk Bentuk**

Metode [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_blackwhitemode/) menentukan bagaimana sebuah bentuk individu dirender ketika presentasi dilihat atau diproses dalam mode hitam‑putih. Metode ini tidak mengaktifkan tampilan hitam‑putih sendiri, dan tidak mengubah isi, garis, atau pemformatan lain dalam mode warna normal.

Gunakan nilai dari enumerasi [BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/blackwhitemode/) untuk memilih perilaku yang diinginkan. Misalnya, `Automatic` membiarkan aplikasi rendering memilih konversi, `Gray` dan `LightGray` menggunakan warna abu‑abu, `BlackWhite` hanya menggunakan hitam dan putih, `Black` dan `White` memaksa satu warna, `Color` mempertahankan warna normal, dan `Hidden` menghilangkan bentuk dalam mode hitam‑putih. `NotDefined` berarti tidak ada mode tingkat bentuk yang ditetapkan.

Kode C++ berikut membuat sebuah bentuk berwarna dan membuatnya tampak abu‑abu dalam mode tampilan hitam‑putih:

```cpp
#include <DOM/BlackWhiteMode.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

// Pertahankan isi oranye dalam mode warna, tetapi render bentuk dengan warna abu-abu dalam mode hitam-putih.
shape->set_BlackWhiteMode(BlackWhiteMode::Gray);

presentation->Save(u"shape_black_white_mode.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Dalam mode warna normal, persegi panjang tetap berisi oranye. Dalam alur kerja tampilan hitam‑putih, ia menggunakan warna abu‑abu karena mode‑nya disetel ke `Gray`. Ini memungkinkan Anda mempertahankan slide berwarna penuh sambil menentukan tampilan berbeda untuk pencetakan, pratinjau, atau alur kerja lain yang menghormati pengaturan tampilan hitam‑putih presentasi.

## **Reset Pemformatan**

Kode C++ berikut menunjukkan cara mereset pemformatan slide dan mengembalikan posisi, ukuran, serta pemformatan semua bentuk dengan placeholder pada [LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/layoutslide/) ke pengaturan default mereka:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    // Reset setiap shape pada slide yang memiliki placeholder pada layout.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Apakah pemformatan bentuk memengaruhi ukuran file presentasi akhir?**

Hanya sedikit. Gambar dan media yang disisipkan mengambil sebagian besar ruang file, sementara parameter bentuk seperti warna, efek, dan gradien disimpan sebagai metadata dan hampir tidak menambah ukuran.

**Bagaimana saya dapat mendeteksi bentuk pada slide yang memiliki pemformatan identik sehingga saya dapat mengelompokkannya?**

Bandingkan setiap properti pemformatan utama bentuk—pengaturan isi, garis, dan efek. Jika semua nilai yang bersesuaian cocok, perlakukan gaya mereka sebagai identik dan kelompokkan bentuk‑bentuk tersebut secara logis, yang menyederhanakan manajemen gaya di kemudian hari.

**Apakah saya dapat menyimpan sekumpulan gaya bentuk kustom ke file terpisah untuk digunakan kembali di presentasi lain?**

Ya. Simpan bentuk contoh dengan gaya yang diinginkan dalam slide templat atau file templat .POTX. Saat membuat presentasi baru, buka templat tersebut, kloning bentuk‑bentuk yang diperlukan, dan terapkan kembali pemformatannya sesuai kebutuhan.