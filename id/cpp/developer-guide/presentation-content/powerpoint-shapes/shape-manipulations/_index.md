---
title: Kelola Bentuk Presentasi di C++
linktitle: Manipulasi Bentuk
type: docs
weight: 40
url: /id/cpp/shape-manipulations/
keywords:
- Bentuk PowerPoint
- Bentuk presentasi
- Bentuk pada slide
- cari bentuk
- gandakan bentuk
- hapus bentuk
- sembunyikan bentuk
- ubah urutan bentuk
- dapatkan ID bentuk interop
- teks alternatif bentuk
- titik penyesuaian bentuk
- penyesuaian bentuk preset
- geometri bentuk
- format tata letak bentuk
- bentuk sebagai SVG
- bentuk ke SVG
- rata bentuk
- balikkan bentuk
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Pelajari cara mengidentifikasi, menyesuaikan, menggandakan, menghapus, menyembunyikan, mengubah urutan, mengekspor, meratakan, dan membalik bentuk presentasi dengan Aspose.Slides untuk C++."
---
## **Ikhtisar**

Aspose.Slides for C++ merepresentasikan bentuk pada sebuah slide sebagai [IShapeCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishapecollection/) yang terurut. Koleksi ini sekaligus tempat Anda menemukan dan memodifikasi bentuk serta sumber urutan penumpukan mereka: indeks `0` adalah bentuk paling belakang, sementara indeks terakhir adalah bentuk paling depan.

Artikel ini mengikuti model tersebut. Pertama menjelaskan cara mengidentifikasi bentuk secara andal dan memodifikasi titik penyesuaian bentuk preset, kemudian menunjukkan cara menggandakan, menghapus, menyembunyikan, dan mengubah urutan bentuk. Bagian akhir mencakup pemformatan tingkat tata letak, ekspor SVG, perataan, dan pengaturan flip. Setiap contoh bersifat independen, sehingga Anda dapat menggunakan hanya operasi yang diperlukan dalam alur kerja Anda.

## **Identifikasi dan Temukan Bentuk**

Indeks koleksi nyaman saat memproses file yang sudah dikenal, tetapi bukan pengidentifikasi yang stabil. Menambahkan, menghapus, atau mengubah urutan sebuah bentuk dapat mengubah indeksnya. Pilih pengidentifikasi sesuai dengan cara presentasi dibuat dan dipelihara:

- [Name](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/get_name/) berguna untuk templat yang dikontrol pengembang dan mudah diperiksa di Panel Seleksi PowerPoint. Nama dapat diedit dan tidak dijamin unik, jadi tetapkan konvensi penamaan jika kode bergantung padanya.
- [AlternativeText](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/get_alternativetext/) berguna ketika deskripsi aksesibilitas atau tag yang diberikan penulis sudah mengidentifikasi bentuk. Teks ini terlihat oleh pengguna, dapat dilokalkan atau ditulis ulang untuk aksesibilitas, dan tidak dijamin unik. Jangan diam‑diam memakai teks aksesibilitas yang bermakna sebagai kunci basis data.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/get_officeinteropshapeid/) adalah pengidentifikasi hanya‑baca yang unik dalam sebuah slide dan sesuai dengan ID bentuk yang digunakan oleh interop PowerPoint. Gunakan ketika berintegrasi dengan PowerPoint atau saat Anda membutuhkan referensi yang tidak ambigu selama masa hidup sebuah bentuk. Bentuk yang digandakan atau dibuat ulang adalah bentuk berbeda dan menerima IDnya masing‑masing.

Properti terkait [UniqueId](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/get_uniqueid/) memiliki lingkup presentasi, tetapi dimaksudkan untuk add‑in dan dapat dipindahtugaskan kembali. Itu tidak boleh diperlakukan sebagai kunci eksternal permanen. Jika identitas jangka panjang penting, simpan pemetaan dalam data aplikasi dan validasi bahwa bentuk yang diharapkan masih ada.

Contoh berikut mencari berdasarkan `Name` dan melaporkan ID interop ber‑lingkup slide. Ketika templat tidak berisi bentuk yang diharapkan, kode melaporkan hasil tersebut alih‑alih melanjutkan dengan objek yang salah.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IShape> targetShape;
for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"RevenueChart")
    {
        targetShape = shape;
        break;
    }
}

if (targetShape == nullptr)
{
    Console::WriteLine(u"The shape 'RevenueChart' was not found on slide 1.");
}
else
{
    Console::WriteLine(String::Format(u"Found {0}; interop ID: {1}", targetShape->get_Name(), targetShape->get_OfficeInteropShapeId()));
}

presentation->Dispose();
```

Ketika sebuah operasi khusus untuk tipe bentuk tertentu, periksa antarmuka sebelum menggunakan anggota yang bersifat tipe‑spesifik. Contoh ini memperbarui teks dan teks alternatif hanya bila objek bernama tersebut adalah sebuah [IAutoShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/).

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IShape> candidate;
for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"StatusLabel")
    {
        candidate = shape;
        break;
    }
}

if (candidate != nullptr && ObjectExt::Is<IAutoShape>(candidate))
{
    auto autoShape = ExplicitCast<IAutoShape>(candidate);
    autoShape->get_TextFrame()->set_Text(u"Approved");
    autoShape->set_AlternativeText(u"Approval status: approved");
    presentation->Save(u"identified-shape.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"'StatusLabel' is missing or is not an AutoShape.");
}

presentation->Dispose();
```

## **Identifikasi dan Modifikasi Penyesuaian Bentuk Preset**

Bentuk geometri preset dapat mengekspos titik penyesuaian yang mengontrol fitur seperti ukuran sudut, proporsi panah, atau sudut busur. Akses mereka melalui koleksi baca‑saja [IGeometryShape::get_Adjustments](https://reference.aspose.com/slides/id/cpp/aspose.slides/igeometryshape/get_adjustments/). Koleksi itu disediakan oleh bentuk, tetapi setiap [IAdjustValue](https://reference.aspose.com/slides/id/cpp/aspose.slides/iadjustvalue/) berisi nilai yang dapat diubah.

Jangan bergantung hanya pada indeks koleksi tetap. Iterasikan penyesuaian dan inspeksi properti baca‑saja [IAdjustValue::get_Type](https://reference.aspose.com/slides/id/cpp/aspose.slides/iadjustvalue/get_type/), yang nilai [ShapeAdjustmentType](https://reference.aspose.com/slides/id/cpp/aspose.slides/shapeadjustmenttype/)‑nya menjelaskan apa yang dikontrol penyesuaian tersebut. Properti baca‑saja [IAdjustValue::get_Name](https://reference.aspose.com/slides/id/cpp/aspose.slides/iadjustvalue/get_name/) memberikan informasi identifikasi tambahan dan sangat berguna ketika preset berisi lebih dari satu penyesuaian dengan tipe semantik yang sama.

Gunakan properti nilai yang cocok dengan makna penyesuaian:

| Tipe Penyesuaian | Tujuan | Nilai yang diubah |
|---|---|---|
| `CornerSize` | Ukuran sudut bulat | [RawValue](https://reference.aspose.com/slides/id/cpp/aspose.slides/iadjustvalue/set_rawvalue/) |
| `ArrowTailThickness` | Ketebalan ekor panah | `RawValue` |
| `ArrowheadLength` | Panjang kepala panah | `RawValue` |
| `ArrowheadWidth` | Lebar kepala panah | `RawValue` |
| `StartAngle` | Sudut awal pai atau busur | [AngleValue](https://reference.aspose.com/slides/id/cpp/aspose.slides/iadjustvalue/set_anglevalue/) |
| `EndAngle` | Sudut akhir pai atau busur | `AngleValue` |

`Type` dan `Name` tidak dapat ditetapkan. `RawValue` adalah integer baca‑tulis dalam satuan geometri native preset, sedangkan `AngleValue` adalah sudut baca‑tulis dalam derajat. Jumlah, urutan, makna, dan rentang nilai penyesuaian tergantung pada preset [ShapeType](https://reference.aspose.com/slides/id/cpp/aspose.slides/igeometryshape/get_shapetype/). Nilai yang valid untuk satu preset mungkin tidak valid atau memiliki efek berbeda untuk preset lainnya.

Ketika `Type` adalah `ShapeAdjustmentType::Custom`, API tidak mengenali makna semantik standar. Periksa `Name`, tipe preset, dan nilai yang ada, dan biarkan penyesuaian tidak berubah kecuali makna dan rentang yang diharapkan diketahui. Bahkan untuk tipe yang dikenali, periksa apakah tipe yang sama muncul lebih dari satu kali sebelum memilih nilai. Artikel [Connector](/slides/id/cpp/connector/) menunjukkan situasi ini dengan penyesuaian tikungan konektor.

Contoh lengkap berikut membuat versi default dan dimodifikasi dari tiga bentuk preset. Ia mengiterasi setiap penyesuaian, melaporkan `Name` dan `Type`‑nya, mengubah nilai terkait ukuran lewat `RawValue`, mengubah sudut lewat `AngleValue`, dan menyimpan hasilnya. Kolom kiri mempertahankan geometri default; kolom kanan menampilkan persegi panjang bulat yang disesuaikan, panah empat arah, dan pai.

```cpp
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Menambahkan header untuk kolom bentuk default dan yang disesuaikan.
auto defaultColumnLabel = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 20, 250, 30);
defaultColumnLabel->get_TextFrame()->set_Text(u"Default preset geometry");
auto adjustedColumnLabel = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 390, 20, 250, 30);
adjustedColumnLabel->get_TextFrame()->set_Text(u"Modified adjustment values");

slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 80, 70, 160, 70);
auto modifiedRoundedRectangle = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 430, 70, 160, 70);
modifiedRoundedRectangle->set_Name(u"ModifiedRoundedRectangle");

slide->get_Shapes()->AddAutoShape(ShapeType::QuadArrow, 80, 180, 160, 110);
auto modifiedArrow = slide->get_Shapes()->AddAutoShape(ShapeType::QuadArrow, 430, 180, 160, 110);
modifiedArrow->set_Name(u"ModifiedQuadArrow");

slide->get_Shapes()->AddAutoShape(ShapeType::Pie, 95, 330, 130, 130);
auto modifiedPie = slide->get_Shapes()->AddAutoShape(ShapeType::Pie, 445, 330, 130, 130);
modifiedPie->set_Name(u"ModifiedPie");

auto shapesToAdjust = MakeArray<SharedPtr<IGeometryShape>>({modifiedRoundedRectangle, modifiedArrow, modifiedPie});

for (auto shape : shapesToAdjust)
{
    auto adjustments = shape->get_Adjustments();
    for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
    {
        auto adjustment = adjustments->idx_get(adjustmentIndex);
        Console::WriteLine(shape->get_Name() + u" / " + adjustment->get_Name() + u": " + ObjectExt::ToString(adjustment->get_Type()));

        switch (adjustment->get_Type())
        {
            case ShapeAdjustmentType::CornerSize:
                adjustment->set_RawValue(5000);
                break;
            case ShapeAdjustmentType::ArrowTailThickness:
                adjustment->set_RawValue(25000);
                break;
            case ShapeAdjustmentType::ArrowheadLength:
                adjustment->set_RawValue(30000);
                break;
            case ShapeAdjustmentType::ArrowheadWidth:
                adjustment->set_RawValue(40000);
                break;
            case ShapeAdjustmentType::StartAngle:
                adjustment->set_AngleValue(30);
                break;
            case ShapeAdjustmentType::EndAngle:
                adjustment->set_AngleValue(300);
                break;
            case ShapeAdjustmentType::Custom:
                Console::WriteLine(u"Custom adjustment '" + adjustment->get_Name() + u"' was not changed.");
                break;
        }
    }
}

presentation->Save(u"preset-shape-adjustments.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Memeriksa tipe semantik sebelum mengubah nilai membuat kode eksplisit tentang niatnya dan menghindari asumsi bahwa indeks koleksi tertentu memiliki makna yang sama pada bentuk preset yang berbeda.

## **Modifikasi Koleksi Bentuk**

Metode tambah, gandakan, hapus, dan ubah urutan beroperasi pada koleksi secara langsung. Jika sebuah operasi mengubah jumlah atau urutan bentuk, jangan terus mengandalkan indeks yang diambil sebelum operasi tersebut.

### **Gandakan Sebuah Bentuk**

[AddClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishapecollection/addclone/) membuat salinan independen dan menambahkannya ke koleksi target. [InsertClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishapecollection/insertclone/) juga membuat salinan tetapi menempatkannya pada indeks z‑order yang ditentukan. Overload yang menerima koordinat memindahkan klon tanpa mengubah ukurannya; overload dengan lebar dan tinggi dapat mengubah ukuran juga.

Contoh membuat slide tujuan, menggandakan persegi panjang berlabel ke depan, dan menyisipkan klon kedua ke belakang. Perubahan pada salah satu klon tidak memodifikasi bentuk sumber.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto sourceSlide = presentation->get_Slide(0);
auto sourceShape = sourceSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 180, 60);
sourceShape->set_Name(u"SourceLabel");
sourceShape->get_TextFrame()->set_Text(u"Source");

auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto destinationSlide = presentation->get_Slides()->AddEmptySlide(blankLayout);

auto frontCloneShape = destinationSlide->get_Shapes()->AddClone(sourceShape, 80, 80);
frontCloneShape->set_Name(u"FrontClone");
if (ObjectExt::Is<IAutoShape>(frontCloneShape))
{
    auto frontClone = ExplicitCast<IAutoShape>(frontCloneShape);
    frontClone->get_TextFrame()->set_Text(u"Front clone");
}
else
{
    Console::WriteLine(u"The front clone is not an AutoShape; its text was not changed.");
}

auto backCloneShape = destinationSlide->get_Shapes()->InsertClone(0, sourceShape, 80, 180);
backCloneShape->set_Name(u"BackClone");
if (ObjectExt::Is<IAutoShape>(backCloneShape))
{
    auto backClone = ExplicitCast<IAutoShape>(backCloneShape);
    backClone->get_TextFrame()->set_Text(u"Back clone");
}
else
{
    Console::WriteLine(u"The back clone is not an AutoShape; its text was not changed.");
}

presentation->Save(u"cloned-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Penggandaan menyalin konten dan pemformatan bentuk, termasuk nama dan teks alternatifnya. Tetapkan pengidentifikasi logis baru ke klon ketika nilai‑nilai tersebut harus unik. Sumber daya yang digunakan oleh bentuk kompleks ditangani oleh presentasi, tetapi klon tetap menjadi item koleksi baru dengan identitas bentuk baru.

### **Hapus Bentuk**

[Remove](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishapecollection/remove/) menghapus objek bentuk tertentu dari koleksinya. Saat menghapus beberapa kecocokan selama iterasi ber‑indeks, lalui dari akhir sehingga setiap indeks yang tersisa tetap valid.

Contoh ini menghapus setiap bentuk dengan nama yang ditentukan. Ia membaca bentuk yang di‑indeks saat ini, bukan item koleksi tetap, dan tidak melakukan cast bentuk yang tidak diperlukan.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto keepShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 140, 60);
keepShape->set_Name(u"Keep");

auto firstTemporaryShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 220, 40, 80, 80);
firstTemporaryShape->set_Name(u"Temporary");

auto secondTemporaryShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 340, 40, 100, 80);
secondTemporaryShape->set_Name(u"Temporary");

for (int32_t i = slide->get_Shapes()->get_Count() - 1; i >= 0; --i)
{
    auto shape = slide->get_Shape(i);
    if (shape->get_Name() == u"Temporary")
    {
        slide->get_Shapes()->Remove(shape);
    }
}

presentation->Save(u"removed-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Setelah penghapusan, jumlah bentuk dan indeks bentuk‑bentuk berikutnya berubah. Referensi ke bentuk yang tidak terpengaruh tetap lebih dapat diandalkan daripada indeks yang disimpan. Pertimbangkan juga konektor, animasi, dan fitur presentasi lain yang mungkin merujuk pada objek yang dihapus; menghapus bentuk yang terlihat dapat mengubah lebih dari sekadar tampilan slide.

### **Sembunyikan Sebuah Bentuk**

Menetapkan [Hidden](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/set_hidden/) ke `true` menjaga bentuk tetap berada dalam koleksi tetapi mencegahnya muncul dalam tampilan slide normal. Indeks, pemformatan, dan kontennya tetap tersedia bagi kode, sehingga menyembunyikan cocok untuk elemen opsional yang mungkin dipulihkan nanti.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto visibleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 160, 60);
visibleShape->set_Name(u"VisibleLabel");

auto optionalShape = slide->get_Shapes()->AddAutoShape(ShapeType::Moon, 240, 40, 100, 100);
optionalShape->set_Name(u"OptionalDecoration");

for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"OptionalDecoration")
    {
        shape->set_Hidden(true);
    }
}

presentation->Save(u"hidden-shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Menyembunyikan bukan berarti menghapus atau mengamankan. Objek masih dapat ditemukan dan ditampilkan kembali oleh pengguna atau kode, dan tetap menjadi bagian dari berkas presentasi.

### **Ubah Z‑Order**

Bentuk yang saling tumpang tindih digambar sesuai urutan koleksi. [Reorder](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishapecollection/reorder/) memindahkan bentuk yang ada ke indeks target tanpa menggandakannya. Indeks `0` adalah belakang; `Count - 1` adalah depan.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto blueRectangle = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 220, 120);
blueRectangle->set_Name(u"BlueRectangle");
blueRectangle->get_FillFormat()->set_FillType(FillType::Solid);
blueRectangle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());

auto orangeEllipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 180, 140, 220, 120);
orangeEllipse->set_Name(u"OrangeEllipse");
orangeEllipse->get_FillFormat()->set_FillType(FillType::Solid);
orangeEllipse->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

slide->get_Shapes()->Reorder(slide->get_Shapes()->get_Count() - 1, blueRectangle);
presentation->Save(u"reordered-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Persegi panjang dibuat terlebih dahulu dan awalnya berada di belakang elips. Memindahkannya ke indeks akhir menempatkannya di depan. Selesaikan z‑order setelah menambahkan atau menggandakan semua bentuk terkait, karena operasi‑operasi tersebut menambah atau menyisipkan item koleksi baru dan dapat mengubah tumpukan yang diinginkan.

## **Periksa Bentuk pada Slide Tata Letak**

Slide normal, slide tata letak, dan slide master memiliki koleksi bentuk terpisah. Sebuah bentuk dalam koleksi tata letak bukan objek yang sama dengan bentuk yang posisinya serupa pada slide normal. Periksa bentuk tata letak ketika Anda perlu memahami atau mengubah pemformatan yang disediakan oleh tata letak.

Contoh berikut membaca masing‑masing [FillFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/get_fillformat/) dan [LineFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/get_lineformat/) pada bentuk tata letak tanpa mengasumsikan bahwa setiap bentuk adalah `AutoShape`.

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto layoutSlide : presentation->get_LayoutSlides())
{
    for (auto shape : layoutSlide->get_Shapes())
    {
        auto fillType = shape->get_FillFormat()->get_FillType();
        auto lineWidth = shape->get_LineFormat()->get_Width();
        Console::WriteLine(String::Format(u"{0} / {1}: fill={2}, line width={3}", layoutSlide->get_Name(), shape->get_Name(), fillType, lineWidth));
    }
}

presentation->Dispose();
```

Menyunting tata letak dapat memengaruhi banyak slide yang menggunakannya. Sebelum mengubah bentuk tata letak, tentukan apakah slide normal mewarisi objek tersebut atau berisi penimpaan lokal, dan uji setiap slide yang memakai tata letak itu.

## **Ekspor Bentuk ke SVG**

[WriteAsSvg](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/writeassvg/) menulis konten ter‑render satu bentuk ke sebuah aliran. Hasilnya berisi bentuk itu, bukan latar belakang seluruh slide atau bentuk‑bentuk tetangganya.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

if (slide->get_Shapes()->get_Count() == 0)
{
    Console::WriteLine(u"Slide 1 does not contain a shape to export.");
}
else
{
    auto shape = slide->get_Shape(0);
    auto svgStream = File::Create(u"shape.svg");
    shape->WriteAsSvg(svgStream);
    svgStream->Close();
}

presentation->Dispose();
```

Biarkan presentasi tetap terbuka selama proses rendering. Output bergantung pada pemformatan bentuk serta sumber daya seperti font dan gambar. Jika Anda membutuhkan keseluruhan komposisi, ekspor slide alih‑alih bentuk individual. Pemanggil memiliki aliran dan harus menutup atau membuangnya.

## **Ratakan Bentuk**

Overload [SlideUtil::AlignShapes](https://reference.aspose.com/slides/id/cpp/aspose.slides.util/slideutil/alignshapes/) meratakan semua bentuk atau indeks koleksi yang dipilih. [ShapesAlignmentType](https://reference.aspose.com/slides/id/cpp/aspose.slides/shapesalignmenttype/) menentukan tepi, garis tengah, atau mode distribusi. Setel `alignToSlide` ke `true` untuk menggunakan tepi slide; setel ke `false` untuk meratakan bentuk‑bentuk terpilih relatif satu sama lain.

Contoh ini meratakan tiga bentuk ke tepi atas slide. Referensi bentuk yang dikembalikan dikonversi ke indeksnya saat ini tepat sebelum perataan.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/ShapesAlignmentType.h>
#include <Export/SaveFormat.h>
#include <Util/SlideUtil.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Util;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto firstShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 60, 80, 120, 50);
auto secondShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 240, 160, 120, 50);
auto thirdShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 420, 240, 120, 50);
firstShape->set_Name(u"FirstAlignedShape");
secondShape->set_Name(u"SecondAlignedShape");
thirdShape->set_Name(u"ThirdAlignedShape");

auto shapeIndexes = MakeArray<int32_t>({slide->get_Shapes()->IndexOf(firstShape), slide->get_Shapes()->IndexOf(secondShape), slide->get_Shapes()->IndexOf(thirdShape)});

SlideUtil::AlignShapes(ShapesAlignmentType::AlignTop, true, slide, shapeIndexes);
presentation->Save(u"aligned-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Perataan mengubah posisi, bukan z‑order. Perataan relatif biasanya membutuhkan setidaknya dua bentuk, sementara distribusi horizontal atau vertikal memerlukan cukup bentuk untuk menentukan jarak. Hitung ulang indeks jika Anda memodifikasi koleksi sebelum memanggil metode.

## **Balikkan Bentuk**

Kelas [ShapeFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/shapeframe/) menyimpan posisi, ukuran, pengaturan flip horizontal dan vertikal, serta rotasi. Nilai `FlipH` dan `FlipV`‑nya menggunakan [NullableBool](https://reference.aspose.com/slides/id/cpp/aspose.slides/nullablebool/): `True` mengaktifkan flip, `False` menonaktifkannya, dan `NotDefined` mempertahankan keadaan tak ditentukan/default.

Presentasi input di bawah berisi satu bentuk yang tidak dibalik.

![The shape before flipping](shape_to_be_flipped.png)

Contoh ini mempertahankan semua nilai frame lainnya dan mengganti hanya dua pengaturan flip. Ini penting karena menetapkan [Frame](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/set_frame/) baru menggantikan seluruh frame.

```cpp
#include <DOM/IShape.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeFrame.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto frame = shape->get_Frame();

Console::WriteLine(String::Format(u"Horizontal flip before change: {0}", frame->get_FlipH()));
Console::WriteLine(String::Format(u"Vertical flip before change: {0}", frame->get_FlipV()));

shape->set_Frame(MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y(), frame->get_Width(), frame->get_Height(), NullableBool::True, NullableBool::True, frame->get_Rotation()));

presentation->Save(u"flipped-shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Bentuk yang disimpan menjadi cermin secara horizontal dan vertikal sementara posisi, ukuran, dan rotasinya tetap.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Haruskah saya menggunakan indeks koleksi sebagai pengidentifikasi bentuk?**

Hanya untuk pemrosesan singkat ketika koleksi tidak akan berubah sebelum indeks digunakan. Lebih baik memakai konvensi `Name` atau `AlternativeText` yang divalidasi untuk templat yang ditulis, atau `OfficeInteropShapeId` untuk pekerjaan interop ber‑lingkup slide.

**Apakah menyembunyikan bentuk menghapusnya dari z‑order?**

Tidak. Bentuk tersembunyi tetap berada dalam koleksi pada indeks yang sama. Bentuk tersebut dapat ditemukan, diubah urutannya, diedit, atau dibuat terlihat kembali.

**Mengapa bentuk yang digandakan muncul di depan bentuk lain?**

`AddClone` menambahkan klon ke akhir koleksi, yang merupakan bagian depan z‑order. Gunakan `InsertClone` untuk memilih indeks awal atau `Reorder` setelah semua bentuk ditambahkan.

**Bisakah saya menggunakan indeks tetap untuk mengidentifikasi penyesuaian bentuk preset?**

Hanya setelah memvalidasi preset dan tata letak koleksi secara tepat. Lebih baik mengiterasi melalui `IGeometryShape::get_Adjustments` dan memeriksa `IAdjustValue::get_Type`; gunakan `IAdjustValue::get_Name` sebagai informasi tambahan ketika tipe semantik yang sama muncul lebih dari satu kali.