---
title: Dapatkan Properti Efektif Bentuk dari Presentasi dalam C++
linktitle: Properti Efektif
type: docs
weight: 50
url: /id/cpp/shape-effective-properties/
keywords:
- properti bentuk
- properti kamera
- rig cahaya
- bentuk bevel
- bingkai teks
- gaya teks
- tinggi font
- format isian
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Pelajari cara menggunakan Aspose.Slides untuk C++ guna membedakan pemformatan bentuk lokal, terwarisi, dan efektif dalam presentasi PowerPoint."
---
## **Pahami Properti Lokal, Terwarisi, dan Efektif**

Pemformatan PowerPoint dapat berasal dari beberapa sumber. Nilai yang disimpan langsung pada sebuah objek disebut **nilai lokal**. Jika nilai tersebut tidak diatur, PowerPoint akan melihat sumber pemformatan induk, seperti default paragraf, gaya teks, tata letak atau slide master, tema, atau default tingkat presentasi. Nilai-nilai tersebut adalah **nilai terwarisi**. Nilai yang tersisa setelah seluruh hierarki diselesaikan adalah **nilai efektif**—nilai yang digunakan untuk merender objek.

Sebagai contoh, sebuah bagian teks mungkin tidak mendefinisikan tinggi fontnya sendiri. Nilai lokal [tinggi font](https://reference.aspose.com/slides/id/cpp/aspose.slides/ibaseportionformat/) maka adalah `std::numeric_limits<float>::quiet_NaN()`, yang berarti "tidak diatur di sini." Bagian tersebut dapat mewarisi tinggi dari paragrafnya, gaya teks default presentasi, atau sumber lain yang relevan. Memanggil [GetEffective](https://reference.aspose.com/slides/id/cpp/aspose.slides/iportionformat/) pada format bagian mengembalikan tinggi yang telah diselesaikan akhir.

Gunakan dua jenis data pemformatan untuk tujuan yang berbeda:

- Baca atau ubah objek format lokal, seperti [IPortionFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/iportionformat/), ketika Anda perlu mengontrol di mana nilai didefinisikan.
- Baca objek data efektif, seperti [IPortionFormatEffectiveData](https://reference.aspose.com/slides/id/cpp/aspose.slides/iportionformateffectivedata/), ketika Anda memerlukan hasil akhir yang dirender. Data efektif bersifat read‑only.

## **Bandingkan Nilai Lokal, Terwarisi, dan Efektif**

Contoh lengkap berikut membuat sebuah bentuk dan menerapkan tinggi font pada tingkat presentasi, paragraf, dan bagian. Setiap langkah mencetak nilai yang didefinisikan pada tingkat tersebut dan nilai efektif yang dihasilkan untuk bagian teks yang sama. Ini juga menunjukkan mengapa data efektif harus dibaca kembali setelah perubahan pemformatan.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <cmath>
#include <limits>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 500.0f, 80.0f, false);
auto textFrame = shape->AddTextFrame(u"Effective formatting");
auto paragraph = textFrame->get_Paragraph(0);
auto portion = paragraph->get_Portion(0);

// Tentukan nilai yang diwarisi pada dua level yang berbeda.
presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->set_FontHeight(20.0f);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(28.0f);

auto formatLocalValue = [](float value) -> System::String
{
    return std::isnan(value) ? System::String(u"<not set>") : System::ObjectExt::ToString(value);
};

auto printFontHeights = [&](System::String caption)
{
    auto presentationValue = presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->get_FontHeight();
    auto paragraphValue = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FontHeight();
    auto localValue = portion->get_PortionFormat()->get_FontHeight();

    // Baca data efektif setelah perubahan sebelumnya.
    auto effectiveValue = portion->get_PortionFormat()->GetEffective()->get_FontHeight();

    System::Console::WriteLine(caption);
    System::Console::WriteLine(System::String(u"  Presentation default: ") + formatLocalValue(presentationValue));
    System::Console::WriteLine(System::String(u"  Paragraph default:    ") + formatLocalValue(paragraphValue));
    System::Console::WriteLine(System::String(u"  Portion local:        ") + formatLocalValue(localValue));
    System::Console::WriteLine(System::String(u"  Portion effective:    ") + effectiveValue);
};

printFontHeights(u"The portion inherits from the paragraph");

// Nilai lokal pada bagian mengesampingkan kedua nilai yang diwarisi.
portion->get_PortionFormat()->set_FontHeight(36.0f);
printFontHeights(u"A local value overrides inherited values");

// Mengubah nilai yang diwarisi tidak mengesampingkan nilai lokal yang ada.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(30.0f);
printFontHeights(u"The local value still has priority");

// Bersihkan nilai lokal. Bagian kini kembali mewarisi dari paragraf.
portion->get_PortionFormat()->set_FontHeight(std::numeric_limits<float>::quiet_NaN());
printFontHeights(u"The local value is cleared");

// Bersihkan nilai paragraf. Default presentasi kini menyediakan hasilnya.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(std::numeric_limits<float>::quiet_NaN());
printFontHeights(u"The paragraph value is cleared");

presentation->Save(u"effective-properties.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Prioritas dalam contoh ini adalah pemformatan lokal bagian, kemudian pemformatan paragraf, dan kemudian default presentasi. Objek lain dapat memiliki rantai pewarisan yang berbeda, tetapi prinsipnya sama: nilai eksplisit yang lebih spesifik menang, dan [GetEffective](https://reference.aspose.com/slides/id/cpp/aspose.slides/iportionformat/) mengembalikan hasil akhir.

## **Dapatkan Properti Teks Efektif**

Pemformatan teks dibagi menjadi beberapa objek:

- [ITextFrameFormat::GetEffective](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextframeformat/) menyelesaikan properti bingkai teks seperti margin, penambatan, autofit, dan arah teks vertikal.
- [ITextStyle::GetEffective](https://reference.aspose.com/slides/id/cpp/aspose.slides/itextstyle/) menyelesaikan pemformatan paragraf untuk setiap level gaya teks.
- [IParagraphFormat::GetEffective](https://reference.aspose.com/slides/id/cpp/aspose.slides/iparagraphformat/) menyelesaikan properti paragraf seperti perataan, indentasi, dan bullet.
- [IPortionFormat::GetEffective](https://reference.aspose.com/slides/id/cpp/aspose.slides/iportionformat/) menyelesaikan properti karakter seperti tinggi font, jenis huruf, warna, tebal, dan miring.

Untuk contoh berikut, `text-formatting.pptx` harus berisi setidaknya satu slide dan satu [IAutoShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/iautoshape/) dengan bingkai teks yang tidak kosong. IAutoShape dapat muncul di posisi mana saja dalam koleksi bentuk; kode mencari objek yang sesuai dan memvalidasinya sebelum digunakan.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/ITextStyle.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"text-formatting.pptx");

if (presentation->get_Slides()->get_Count() == 0)
    throw System::InvalidOperationException(u"The presentation contains no slides.");

auto slide = presentation->get_Slide(0);
System::SharedPtr<IAutoShape> shape;

for (int shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
{
    auto candidate = slide->get_Shapes()->idx_get(shapeIndex);

    if (!System::ObjectExt::Is<IAutoShape>(candidate))
        continue;

    auto autoShape = System::ExplicitCast<IAutoShape>(candidate);
    auto candidateTextFrame = autoShape->get_TextFrame();

    if (candidateTextFrame == nullptr || candidateTextFrame->get_Paragraphs()->get_Count() == 0)
        continue;

    if (candidateTextFrame->get_Paragraph(0)->get_Portions()->get_Count() == 0)
        continue;

    shape = autoShape;
    break;
}

if (shape == nullptr)
    throw System::InvalidOperationException(u"The first slide must contain an IAutoShape with non-empty text.");

auto textFrame = shape->get_TextFrame();
auto paragraph = textFrame->get_Paragraph(0);
auto portion = paragraph->get_Portion(0);

auto textFrameEffective = textFrame->get_TextFrameFormat()->GetEffective();
auto paragraphEffective = paragraph->get_ParagraphFormat()->GetEffective();
auto portionEffective = portion->get_PortionFormat()->GetEffective();

System::Console::WriteLine(u"Text frame margins:");
System::Console::WriteLine(System::String(u"  Left: ") + textFrameEffective->get_MarginLeft());
System::Console::WriteLine(System::String(u"  Top: ") + textFrameEffective->get_MarginTop());
System::Console::WriteLine(System::String(u"  Right: ") + textFrameEffective->get_MarginRight());
System::Console::WriteLine(System::String(u"  Bottom: ") + textFrameEffective->get_MarginBottom());
System::Console::WriteLine(System::String(u"Paragraph alignment: ") + System::ObjectExt::ToString(paragraphEffective->get_Alignment()));
System::Console::WriteLine(System::String(u"Font height: ") + portionEffective->get_FontHeight());
System::Console::WriteLine(System::String(u"Bold: ") + System::ObjectExt::ToString(portionEffective->get_FontBold()));

auto effectiveTextStyle = textFrame->get_TextFrameFormat()->get_TextStyle()->GetEffective();
for (int level = 0; level < 9; ++level)
{
    auto levelEffective = effectiveTextStyle->GetLevel(level);
    System::Console::WriteLine(System::String(u"Level ") + level + u" indent: " + levelEffective->get_Indent());
}

presentation->Dispose();
```

## **Dapatkan Properti 3D Efektif**

[IThreeDFormat::GetEffective](https://reference.aspose.com/slides/id/cpp/aspose.slides/ithreedformat/) mengembalikan satu objek [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/id/cpp/aspose.slides/ithreedformateffectivedata/) yang mengelompokkan semua pengaturan 3D yang telah diselesaikan. Data [kamera](https://reference.aspose.com/slides/id/cpp/aspose.slides/icameraeffectivedata/), [rig cahaya](https://reference.aspose.com/slides/id/cpp/aspose.slides/ilightrigeffectivedata/), [bevel atas](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishapebeveleffectivedata/) dan [bevel bawah](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishapebeveleffectivedata/) menampilkan pengaturan efektif yang bersangkutan. Membaca pengaturan terkait ini secara bersamaan memudahkan pemahaman tampilan 3D akhir sebuah bentuk.

Untuk contoh ini, `shape-3d.pptx` harus berisi setidaknya satu bentuk pada slide pertamanya. Terapkan pengaturan kamera 3D, pencahayaan, atau bevel pada bentuk tersebut jika Anda menginginkan output berisi nilai selain default.

```cpp
#include <DOM/ICameraEffectiveData.h>
#include <DOM/ILightRigEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeBevelEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"shape-3d.pptx");

if (presentation->get_Slides()->get_Count() == 0 || presentation->get_Slide(0)->get_Shapes()->get_Count() == 0)
    throw System::InvalidOperationException(u"The first slide must contain a shape.");

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto threeDEffective = shape->get_ThreeDFormat()->GetEffective();

System::Console::WriteLine(u"Camera:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_Camera()->get_CameraType()));
System::Console::WriteLine(System::String(u"  Field of view: ") + threeDEffective->get_Camera()->get_FieldOfViewAngle());
System::Console::WriteLine(System::String(u"  Zoom: ") + threeDEffective->get_Camera()->get_Zoom());

System::Console::WriteLine(u"Light rig:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_LightRig()->get_LightType()));
System::Console::WriteLine(System::String(u"  Direction: ") + System::ObjectExt::ToString(threeDEffective->get_LightRig()->get_Direction()));

System::Console::WriteLine(u"Top bevel:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_BevelTop()->get_BevelType()));
System::Console::WriteLine(System::String(u"  Width: ") + threeDEffective->get_BevelTop()->get_Width());
System::Console::WriteLine(System::String(u"  Height: ") + threeDEffective->get_BevelTop()->get_Height());

presentation->Dispose();
```

## **Dapatkan Pemformatan Tabel Efektif**

Pemformatan tabel dapat berasal dari gaya tabel dan dari format yang diterapkan pada seluruh tabel, kolom, baris, atau sel individual. Untuk konflik di antara isian yang didefinisikan secara eksplisit, prioritasnya adalah sel, baris, kolom, dan kemudian seluruh tabel. Format efektif sebuah sel adalah format akhir yang digunakan untuk menggambar sel tersebut.

Untuk contoh ini, `table-formatting.pptx` harus berisi setidaknya satu tabel pada slide pertamanya. Tabel tersebut harus memiliki setidaknya satu baris dan satu kolom. Kode mencari sebuah [ITable](https://reference.aspose.com/slides/id/cpp/aspose.slides/itable/) alih-alih mengasumsikan bahwa bentuk pertama adalah tabel.

```cpp
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/Table/IColumnFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IRowFormat.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ITableFormat.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"table-formatting.pptx");

if (presentation->get_Slides()->get_Count() == 0)
    throw System::InvalidOperationException(u"The presentation contains no slides.");

auto slide = presentation->get_Slide(0);
System::SharedPtr<ITable> table;

for (int shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
{
    auto candidate = slide->get_Shapes()->idx_get(shapeIndex);

    if (System::ObjectExt::Is<ITable>(candidate))
    {
        table = System::ExplicitCast<ITable>(candidate);
        break;
    }
}

if (table == nullptr)
    throw System::InvalidOperationException(u"The first slide must contain a table.");

if (table->get_Rows()->get_Count() == 0 || table->get_Columns()->get_Count() == 0)
    throw System::InvalidOperationException(u"The table must contain at least one cell.");

auto tableEffective = table->get_TableFormat()->GetEffective();
auto rowEffective = table->get_Row(0)->get_RowFormat()->GetEffective();
auto columnEffective = table->get_Column(0)->get_ColumnFormat()->GetEffective();
auto cellEffective = table->idx_get(0, 0)->get_CellFormat()->GetEffective();

System::Console::WriteLine(System::String(u"Table fill: ") + System::ObjectExt::ToString(tableEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Row fill: ") + System::ObjectExt::ToString(rowEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Column fill: ") + System::ObjectExt::ToString(columnEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Final cell fill: ") + System::ObjectExt::ToString(cellEffective->get_FillFormat()->get_FillType()));

presentation->Dispose();
```

Jika Anda memerlukan warna bukan hanya jenis isian, pertama periksa [FillType](https://reference.aspose.com/slides/id/cpp/aspose.slides/ifillformateffectivedata/) yang efektif, kemudian baca properti yang berlaku untuk tipe tersebut—misalnya, [SolidFillColor](https://reference.aspose.com/slides/id/cpp/aspose.slides/ifillformateffectivedata/) untuk isian solid.

## **Baca Ulang Data Efektif Setelah Perubahan**

Data efektif menggambarkan hierarki pemformatan pada saat diselesaikan. Panggil `GetEffective` lagi setelah mengubah apa pun yang dapat berpartisipasi dalam hierarki tersebut, termasuk:

- pemformatan lokal objek;
- default paragraf atau bingkai teks;
- gaya tabel, tabel, kolom, baris, atau format sel;
- pemformatan tata letak atau slide master;
- data tema atau default tingkat presentasi;
- tata letak atau master yang ditetapkan pada slide.

Jangan menyimpan objek data efektif sebagai snapshot permanen. Aspose.Slides dapat menyimpan beberapa data efektif secara internal, dan panggilan `GetEffective` berikutnya dapat memperbarui data tersebut. Jika Anda perlu membandingkan nilai sebelum dan sesudah perubahan, salin nilai skalar yang diperlukan—misalnya tinggi font, warna, perataan, atau lebar bevel—ke variabel Anda sendiri sebelum melakukan perubahan.

Untuk mengubah nilai, perbarui objek format lokal yang sesuai lalu panggil `GetEffective` untuk memverifikasi hasilnya. Objek data efektif bersifat read‑only.

## **FAQ**

**Bagaimana saya dapat mengetahui level mana yang menyediakan nilai efektif?**

Data efektif berisi nilai akhir, bukan sumbernya. Periksa objek lokal yang berlaku mulai dari level paling spesifik ke luar. Untuk teks, ini dapat mencakup bagian, paragraf, bingkai teks, tata letak, master, tema, dan default presentasi. Nilai yang tidak terdefinisi seperti `std::numeric_limits<float>::quiet_NaN()` atau `nullptr` menunjukkan bahwa pencarian berlanjut ke level lain.

**Apa yang terjadi ketika tidak ada level yang mendefinisikan properti?**

Aspose.Slides menyelesaikan default PowerPoint atau perpustakaan yang sesuai. Nilai yang diselesaikan tersebut muncul dalam data efektif meskipun tidak ada objek lokal yang secara eksplisit mendefinisikannya.

**Mengapa nilai efektif kadang sama dengan nilai lokal?**

Nilai lokal menang dalam perhitungan pewarisan. Hal ini diharapkan ketika properti secara eksplisit diatur pada objek dan tidak ada aturan yang lebih spesifik yang menimpanya.

**Kapan saya harus menggunakan data lokal alih-alih data efektif?**

Gunakan data lokal untuk memeriksa atau menyunting level pemformatan tertentu. Gunakan data efektif ketika Anda membutuhkan tampilan akhir setelah pewarisan, aturan tema, dan gaya yang berlaku diselesaikan. [Contoh perbandingan lengkap](#compare-local-inherited-and-effective-values) menunjukkan keduanya dalam alur kerja yang sama.