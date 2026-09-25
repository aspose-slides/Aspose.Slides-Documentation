---
title: Kelola Shape Presentasi di C++
linktitle: Manipulasi Shape
type: docs
weight: 40
url: /id/cpp/shape-manipulations/
keywords:
- Shape PowerPoint
- Shape presentasi
- Shape pada slide
- Temukan shape
- Gandakan shape
- Hapus shape
- Sembunyikan shape
- Ubah urutan shape
- Dapatkan ID shape interop
- Teks alternatif shape
- Titik penyesuaian shape
- Penyesuaian shape preset
- Geometri shape
- Format layout shape
- Shape sebagai SVG
- Shape ke SVG
- Selaraskan shape
- Balikkan shape
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Pelajari cara mengidentifikasi, menyesuaikan, menggandakan, menghapus, menyembunyikan, mengubah urutan, mengekspor, menyelaraskan, dan membalik shape presentasi dengan Aspose.Slides untuk C++."
---
## **Gambaran Umum**

Aspose.Slides untuk C++ merepresentasikan shape pada slide sebagai [IShapeCollection](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishapecollection/) yang terurut. Koleksi ini sekaligus menjadi tempat Anda menemukan dan memodifikasi shape serta sumber urutan tumpukan mereka: indeks `0` adalah shape paling belakang, sedangkan indeks terakhir adalah shape paling depan.

Artikel ini mengikuti model tersebut. Pertama dijelaskan cara mengidentifikasi shape secara andal dan memodifikasi titik penyesuaian shape bawaan, kemudian ditunjukkan cara menggandakan, menghapus, menyembunyikan, dan mengubah urutan shape. Bagian akhir mencakup pemformatan tingkat tata letak, ekspor SVG, penyelarasan, dan pengaturan flip. Setiap contoh bersifat independen, sehingga Anda dapat menggunakan hanya operasi yang diperlukan alur kerja Anda.

## **Identifikasi dan Temukan Shape**

Indeks koleksi nyaman saat memproses file yang sudah diketahui, namun bukan pengenal yang stabil. Menambah, menghapus, atau mengubah urutan shape dapat mengubah indeksnya. Pilih pengenal sesuai cara presentasi dibuat dan dipelihara:

- [Name](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/get_name/) berguna untuk templat yang dikendalikan pengembang dan mudah dilihat di Panel Seleksi PowerPoint. Nama dapat diedit dan tidak dijamin unik, jadi tetapkan konvensi penamaan jika kode bergantung padanya.
- [AlternativeText](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/get_alternativetext/) berguna ketika deskripsi aksesibilitas atau tag yang disediakan penulis sudah mengidentifikasi shape. Teks ini terlihat oleh pengguna, dapat dilokalisasi atau ditulis ulang untuk aksesibilitas, dan tidak dijamin unik. Jangan pakai teks aksesibilitas bermakna sebagai kunci basis data secara diam‑diam.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/get_officeinteropshapeid/) adalah pengenal baca‑saja yang unik dalam satu slide dan sesuai dengan ID shape yang digunakan oleh interop PowerPoint. Gunakan ketika mengintegrasikan dengan PowerPoint atau bila Anda memerlukan referensi tak ambigu selama masa hidup shape. Shape yang digandakan atau dibuat ulang adalah shape yang berbeda dan menerima ID-nya sendiri.

Properti terkait [UniqueId](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/get_uniqueid/) memiliki lingkup presentasi, namun ditujukan untuk add‑in dan dapat di‑reassign. Jangan anggap sebagai kunci eksternal permanen. Jika identitas jangka panjang penting, simpan pemetaan dalam data aplikasi dan validasi bahwa shape yang diharapkan masih ada.

Untuk contoh praktis membaca dan memperbarui judul serta deskripsi teks alternatif, lihat [Manage Alternative Text Titles and Descriptions](/slides/id/cpp/presentation-accessibility/). Gunakan teks alternatif untuk menjelaskan arti visual kepada pembaca, dan pisahkan dari nama shape yang digunakan kode untuk menemukan shape.

Contoh berikut mencari berdasarkan `Name` dan melaporkan ID interop berskala slide. Ketika templat tidak berisi shape yang diharapkan, kode melaporkan hasil tersebut alih‑alih melanjutkan dengan objek yang salah.

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

Ketika operasi spesifik untuk tipe shape, periksa antarmuka sebelum menggunakan anggota tipe‑spesifik. Contoh ini memperbarui teks dan teks alternatif hanya bila objek yang dinamai adalah sebuah [IAutoShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/).

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

## **Identifikasi dan Modifikasi Penyesuaian Shape Bawaan**

Shape geometri bawaan dapat mengekspos titik penyesuaian yang mengontrol fitur seperti ukuran sudut, proporsi panah, atau sudut busur. Akses melalui koleksi baca‑saja [IGeometryShape::get_Adjustments](https://reference.aspose.com/slides/id/cpp/aspose.slides/igeometryshape/get_adjustments/). Koleksi tersebut disediakan oleh shape, namun setiap [IAdjustValue](https://reference.aspose.com/slides/id/cpp/aspose.slides/iadjustvalue/) berisi nilai yang dapat diubah.

Jangan mengandalkan indeks koleksi tetap. Iterasikan penyesuaian dan periksa properti baca‑saja [IAdjustValue::get_Type](https://reference.aspose.com/slides/id/cpp/aspose.slides/iadjustvalue/get_type/), yang nilai [ShapeAdjustmentType](https://reference.aspose.com/slides/id/cpp/aspose.slides/shapeadjustmenttype/)‑nya menjelaskan apa yang dikendalikan penyesuaian. Properti baca‑saja [IAdjustValue::get_Name](https://reference.aspose.com/slides/id/cpp/aspose.slides/iadjustvalue/get_name/) memberikan informasi identifikasi tambahan dan sangat berguna ketika preset berisi lebih dari satu penyesuaian dengan tipe semantik yang sama.

Gunakan properti nilai yang sesuai dengan makna penyesuaian:

| Adjustment type | Purpose | Value to change |
|---|---|---|
| `CornerSize` | Ukuran sudut melengkung | [RawValue](https://reference.aspose.com/slides/id/cpp/aspose.slides/iadjustvalue/set_rawvalue/) |
| `ArrowTailThickness` | Ketebalan ekor panah | `RawValue` |
| `ArrowheadLength` | Panjang kepala panah | `RawValue` |
| `ArrowheadWidth` | Lebar kepala panah | `RawValue` |
| `StartAngle` | Sudut awal pai atau busur | [AngleValue](https://reference.aspose.com/slides/id/cpp/aspose.slides/iadjustvalue/set_anglevalue/) |
| `EndAngle` | Sudut akhir pai atau busur | `AngleValue` |

`Type` dan `Name` tidak dapat ditetapkan. `RawValue` adalah integer baca‑tulis dalam satuan geometri native preset, sedangkan `AngleValue` adalah sudut baca‑tulis dalam derajat. Jumlah, urutan, makna, dan rentang nilai yang valid tergantung pada preset [ShapeType](https://reference.aspose.com/slides/id/cpp/aspose.slides/igeometryshape/get_shapetype/). Nilai yang valid untuk satu preset mungkin tidak valid atau memiliki efek berbeda untuk preset lain.

Ketika `Type` adalah `ShapeAdjustmentType::Custom`, API tidak mengenali makna semantik standar. Periksa `Name`, tipe preset, dan nilai yang ada, dan biarkan penyesuaian tidak berubah kecuali makna dan rentang yang diharapkan diketahui. Bahkan untuk tipe yang dikenali, periksa apakah tipe yang sama muncul lebih dari satu kali sebelum memilih nilai. Artikel [Connector](/slides/id/cpp/connector/) menunjukkan situasi ini dengan penyesuaian bengkok konektor.

Contoh lengkap berikut membuat versi default dan dimodifikasi dari tiga shape preset. Ia mengiterasi setiap penyesuaian, melaporkan `Name` dan `Type`‑nya, mengubah nilai terkait ukuran lewat `RawValue`, mengubah sudut lewat `AngleValue`, dan menyimpan hasilnya. Kolom kiri mempertahankan geometri default; kolom kanan menampilkan persegi panjang melengkung, panah empat‑arah, dan pai yang telah disesuaikan.

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

// Menambahkan header untuk kolom shape default dan yang disesuaikan.
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

Memeriksa tipe semantik sebelum mengubah nilai membuat kode eksplisit mengenai niatnya dan menghindari asumsi bahwa indeks koleksi tertentu memiliki arti yang sama pada berbagai shape preset.

## **Modifikasi Koleksi Shape**

Metode tambah, gandakan, hapus, dan ubah urutan beroperasi pada koleksi secara langsung. Jika suatu operasi mengubah jumlah atau urutan shape, jangan terus mengandalkan indeks yang diambil sebelum operasi tersebut.

### **Gandakan Sebuah Shape**

[AddClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishapecollection/addclone/) membuat salinan independen dan menambahkannya ke koleksi target. [InsertClone](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishapecollection/insertclone/) juga membuat salinan tetapi menempatkannya pada indeks z‑order yang ditentukan. Overload yang menerima koordinat memindahkan klon tanpa mengubah ukurannya; overload dengan lebar dan tinggi dapat meresize juga.

Contoh membuat slide tujuan, menggandakan persegi panjang berlabel ke depan, dan menyisipkan klon kedua di belakang. Perubahan pada salah satu klon tidak memodifikasi shape sumber.

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

Penggandaan menyalin konten dan pemformatan shape, termasuk nama dan teks alternatifnya. Tetapkan pengenal logis baru pada klon bila nilai‑nilai tersebut harus unik. Sumber daya yang digunakan oleh shape kompleks ditangani oleh presentasi, namun klon tetap menjadi item koleksi baru dengan identitas shape baru.

### **Hapus Shape**

[Remove](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishapecollection/remove/) menghapus objek shape tertentu dari koleksinya. Saat menghapus beberapa kecocokan selama iterasi berindeks, lalui dari akhir sehingga setiap indeks yang tersisa tetap valid.

Contoh ini menghapus setiap shape dengan nama yang ditetapkan. Ia membaca shape yang diindeks saat ini, bukan item koleksi tetap, dan tidak melakukan cast yang tidak diperlukan.

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

Setelah penghapusan, jumlah shape dan indeks shape berikutnya berubah. Referensi ke shape yang tidak terpengaruh tetap lebih dapat diandalkan daripada indeks yang disimpan. Pertimbangkan juga konektor, animasi, dan fitur presentasi lain yang mungkin merujuk pada objek yang dihapus; menghapus shape yang terlihat dapat mengubah lebih dari sekadar tampilan slide.

### **Sembunyikan Sebuah Shape**

Menetapkan [Hidden](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/set_hidden/) ke `true` menjaga shape dalam koleksi namun mencegahnya muncul dalam tampilan slide normal. Indeks, pemformatan, dan kontennya tetap tersedia bagi kode, sehingga menyembunyikan cocok untuk elemen opsional yang mungkin dipulihkan nanti.

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

Menyembunyikan bukan berarti menghapus atau mengamankan. Objek tetap dapat ditemukan dan dibuka kembali oleh pengguna atau kode, dan tetap menjadi bagian dari berkas presentasi.

### **Ubah Z‑Order**

Shape yang tumpang tindih digambar sesuai urutan koleksi. [Reorder](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishapecollection/reorder/) memindahkan shape yang ada ke indeks target tanpa menggandakannya. Indeks `0` adalah belakang; `Count - 1` adalah depan.

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

Persegi panjang dibuat dulu dan awalnya berada di belakang elips. Memindahkannya ke indeks akhir menempatkannya di depan. Selesaikan urutan z setelah menambah atau menggandakan semua shape terkait, karena operasi tersebut menambah atau menyisipkan item koleksi baru dan dapat mengubah tumpukan yang dimaksud.

## **Periksa Shape pada Slide Layout**

Slide normal, slide layout, dan slide master memiliki koleksi shape terpisah. Shape dalam koleksi layout bukan objek yang sama dengan shape yang diposisikan serupa pada slide normal. Periksa shape layout ketika Anda perlu memahami atau mengubah pemformatan yang disediakan oleh layout.

Contoh berikut membaca setiap [FillFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/get_fillformat/) dan [LineFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/get_lineformat/) shape layout tanpa mengasumsikan bahwa setiap shape adalah `AutoShape`.

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

Menyunting layout dapat memengaruhi beberapa slide yang menggunakannya. Sebelum mengubah shape layout, tentukan apakah slide normal mewarisi objek tersebut atau berisi override lokal, dan uji setiap slide yang memakai layout itu.

## **Ekspor Shape ke SVG**

[WriteAsSvg](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/writeassvg/) menulis konten ter-render satu shape ke aliran. Hasilnya berisi shape, bukan latar belakang slide seluruhnya atau shape tetangga.

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

Biarkan presentasi tetap terbuka selama rendering. Output tergantung pada pemformatan shape serta sumber daya seperti font dan gambar. Jika Anda memerlukan seluruh komposisi, ekspor slide bukan shape individual. Pemanggil memiliki aliran dan harus menutup atau membuangnya.

## **Menyelaraskan Shape**

[SlideUtil::AlignShapes](https://reference.aspose.com/slides/id/cpp/aspose.slides.util/slideutil/alignshapes/) memiliki overload yang menyelaraskan semua shape atau indeks koleksi terpilih. [ShapesAlignmentType](https://reference.aspose.com/slides/id/cpp/aspose.slides/shapesalignmenttype/) menentukan tepi, garis tengah, atau mode distribusi. Setel `alignToSlide` ke `true` untuk menggunakan tepi slide; setel ke `false` untuk menyelaraskan shape terpilih relatif satu sama lain.

Contoh ini menyelaraskan tiga shape ke tepi atas slide. Referensi shape yang dikembalikan dikonversi ke indeks saat ini tepat sebelum penyelarasan.

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

Penyelarasan mengubah posisi, bukan z‑order. Penyelarasan relatif biasanya memerlukan setidaknya dua shape, sementara distribusi horizontal atau vertikal memerlukan cukup shape untuk menentukan jarak. Hitung ulang indeks jika Anda memodifikasi koleksi sebelum memanggil metode.

## **Flip Sebuah Shape**

Kelas [ShapeFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/shapeframe/) menyimpan posisi, ukuran, pengaturan flip horizontal dan vertical, serta rotasi. Nilai `FlipH` dan `FlipV`‑nya menggunakan [NullableBool](https://reference.aspose.com/slides/id/cpp/aspose.slides/nullablebool/): `True` mengaktifkan flip, `False` menonaktifkannya, dan `NotDefined` mempertahankan keadaan tak‑ditentukan/default.

Presentasi input di bawah berisi satu shape yang tidak di‑flip.

![The shape before flipping](shape_to_be_flipped.png)

Contoh ini mempertahankan semua nilai frame lainnya dan hanya mengganti dua pengaturan flip. Ini penting karena menetapkan [Frame](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/set_frame/) baru menggantikan seluruh frame.

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

Shape yang disimpan dipantulkan secara horizontal dan vertikal sementara posisi, ukuran, dan rotasinya tetap.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Haruskah saya menggunakan indeks koleksi sebagai pengenal shape?**

Hanya untuk pemrosesan singkat ketika koleksi tidak akan berubah sebelum indeks digunakan. Lebih baik gunakan konvensi `Name` atau `AlternativeText` yang tervalidasi untuk templat yang dibuat, atau `OfficeInteropShapeId` untuk pekerjaan interop berskala slide.

**Apakah menyembunyikan shape menghapusnya dari z‑order?**

Tidak. Shape yang disembunyikan tetap berada di koleksi pada indeks yang sama. Ia dapat ditemukan, di‑reorder, diedit, atau dibuat terlihat kembali.

**Mengapa shape yang digandakan muncul di depan shape lain?**

`AddClone` menambahkan klon ke akhir koleksi, yang merupakan depan z‑order. Gunakan `InsertClone` untuk memilih indeks awal atau `Reorder` setelah semua shape ditambahkan.

**Bisakah saya menggunakan indeks tetap untuk mengidentifikasi penyesuaian shape preset?**

Hanya setelah memvalidasi preset dan tata letak koleksi secara tepat. Lebih baik iterasikan melalui `IGeometryShape::get_Adjustments` dan periksa `IAdjustValue::get_Type`; gunakan `IAdjustValue::get_Name` sebagai informasi tambahan bila tipe semantik yang sama muncul lebih dari sekali.