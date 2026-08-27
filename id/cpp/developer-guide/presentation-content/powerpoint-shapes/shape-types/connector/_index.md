---
title: "Kelola Konektor dalam Presentasi Menggunakan C++"
linktitle: "Konektor"
type: docs
weight: 10
url: /id/cpp/connector/
keywords:
- konektor
- tipe konektor
- titik konektor
- garis konektor
- sudut konektor
- situs koneksi
- titik penyesuaian
- hubungkan bentuk
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Pelajari cara menambahkan, melampirkan, merutekan ulang, menyesuaikan, dan memeriksa konektor PowerPoint lurus, bengkok, dan melengkung dengan Aspose.Slides untuk C++."
---
## **Gambaran Umum**

Sebuah konektor adalah garis yang dapat tetap terhubung ke dua bentuk saat salah satu bentuk bergerak. Ujung‑ujungnya terhubung ke situs koneksi, yang direpresentasikan oleh titik hijau di PowerPoint. Beberapa konektor bengkok dan melengkung juga menampilkan titik penyesuaian, yang direpresentasikan oleh titik oranye, yang mengontrol posisi segmen‑segmen konektor secara individual.

Aspose.Slides merepresentasikan konektor melalui antarmuka [IConnector](https://reference.aspose.com/slides/id/cpp/aspose.slides/iconnector/). Anda dapat membuatnya, menghubungkan ujung‑ujungnya ke bentuk, memilih situs koneksi, merutekan ulang, dan memodifikasi geometri konektor yang memiliki titik penyesuaian.

## **Jenis Konektor**

Enumerasi [ShapeType](https://reference.aspose.com/slides/id/cpp/aspose.slides/shapetype/) mencakup preset konektor lurus, bengkok, dan melengkung. Tabel berikut menunjukkan geometri konektor yang tersedia dan jumlah titik penyesuaian yang didefinisikan oleh masing‑masing preset.

| Konektor | Gambar | Jumlah titik penyesuaian |
|---|---|---|
| `ShapeType::Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType::StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType::BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType::BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType::BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType::BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType::CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType::CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType::CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType::CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

Jumlah dan arti titik penyesuaian merupakan bagian dari preset konektor yang dipilih. Jangan mengasumsikan bahwa dua tipe konektor yang berbeda menampilkan tata letak koleksi yang sama.

## **Hubungkan Dua Bentuk**

Gunakan [IShapeCollection::AddConnector](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishapecollection/addconnector/) untuk menambahkan sebuah konektor, dan panggil [IConnector::set_StartShapeConnectedTo](https://reference.aspose.com/slides/id/cpp/aspose.slides/iconnector/set_startshapeconnectedto/) serta [IConnector::set_EndShapeConnectedTo](https://reference.aspose.com/slides/id/cpp/aspose.slides/iconnector/set_endshapeconnectedto/) untuk menghubungkan ujung‑ujungnya. Setelah kedua ujung terhubung, [IConnector::Reroute](https://reference.aspose.com/slides/id/cpp/aspose.slides/iconnector/reroute/) memilih rute pendek di antara bentuk‑bentuk tersebut.

Contoh berikut menghubungkan sebuah elips dan persegi panjang dengan konektor bengkok:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IConnector.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto ellipse = shapes->AddAutoShape(ShapeType::Ellipse, 40, 80, 120, 80);
auto rectangle = shapes->AddAutoShape(ShapeType::Rectangle, 320, 240, 140, 80);
auto connector = shapes->AddConnector(ShapeType::BentConnector2, 0, 0, 10, 10);

connector->set_StartShapeConnectedTo(ellipse);
connector->set_EndShapeConnectedTo(rectangle);
connector->Reroute();

presentation->Save(u"connected-shapes.pptx", SaveFormat::Pptx);
```

{{% alert color="warning" title="Warning" %}}
Memanggil `IConnector::Reroute` dapat mengubah nilai [IConnector::set_StartShapeConnectionSiteIndex](https://reference.aspose.com/slides/id/cpp/aspose.slides/iconnector/set_startshapeconnectionsiteindex/) dan [IConnector::set_EndShapeConnectionSiteIndex](https://reference.aspose.com/slides/id/cpp/aspose.slides/iconnector/set_endshapeconnectionsiteindex/). Tetapkan situs koneksi tertentu setelah perutean ulang jika situs‑situs tersebut harus tetap tetap.
{{% /alert %}}

## **Pilih Situs Koneksi**

Setiap bentuk yang dapat dihubungkan melaporkan jumlah situs melalui [IShape::get_ConnectionSiteCount](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/get_connectionsitecount/). Validasi indeks situs berbasis nol yang diinginkan sebelum menetapkannya ke ujung konektor; jumlah situs bervariasi menurut geometri bentuk.

Contoh ini menghubungkan konektor ke situs tertentu pada elips ketika situs tersebut ada:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IConnector.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto ellipse = shapes->AddAutoShape(ShapeType::Ellipse, 40, 80, 120, 80);
auto rectangle = shapes->AddAutoShape(ShapeType::Rectangle, 320, 240, 140, 80);
auto connector = shapes->AddConnector(ShapeType::BentConnector3, 0, 0, 10, 10);

connector->set_StartShapeConnectedTo(ellipse);
connector->set_EndShapeConnectedTo(rectangle);

int32_t preferredSiteIndex = 2;
if (preferredSiteIndex < ellipse->get_ConnectionSiteCount())
{
    connector->set_StartShapeConnectionSiteIndex(preferredSiteIndex);
}
else
{
    Console::WriteLine(u"The ellipse has only {0} connection sites.", ellipse->get_ConnectionSiteCount());
}

presentation->Save(u"specific-connection-site.pptx", SaveFormat::Pptx);
```

## **Sesuaikan Titik Konektor**

Konektor dengan titik penyesuaian menampilkan titik‑titik tersebut melalui [IGeometryShape::get_Adjustments](https://reference.aspose.com/slides/id/cpp/aspose.slides/igeometryshape/get_adjustments/). Periksa setiap [IAdjustValue](https://reference.aspose.com/slides/id/cpp/aspose.slides/iadjustvalue/) dan periksa [IAdjustValue::get_Type](https://reference.aspose.com/slides/id/cpp/aspose.slides/iadjustvalue/get_type/) sebelum mengubah [IAdjustValue::set_RawValue](https://reference.aspose.com/slides/id/cpp/aspose.slides/iadjustvalue/set_rawvalue/). Aturan umum untuk mengidentifikasi penyesuaian bentuk preset dijelaskan dalam [Shape Manipulation](/slides/id/cpp/shape-manipulations/).

Jumlah, urutan, arti, dan rentang nilai yang valid untuk penyesuaian konektor bergantung pada preset konektor. Tipe yang dikembalikan oleh `IAdjustValue::get_Type` bersifat read‑only, sedangkan nilai penyesuaian mentah dapat ditulis. Metode read‑only [IAdjustValue::get_Name](https://reference.aspose.com/slides/id/cpp/aspose.slides/iadjustvalue/get_name/) memberikan identifikasi tambahan ketika sebuah konektor berisi lebih dari satu penyesuaian dengan tipe semantik yang sama.

### **Rute Mengelilingi Rintangan**

Pada tata letak berikut, sebuah konektor `ShapeType::BentConnector5` di antara dua bentuk melewati bentuk ketiga:

![connector-obstruction](connector-obstruction.png)

Kode berikut membuat konektor yang terhalang:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IConnector.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

shapes->AddAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
auto connector = shapes->AddConnector(ShapeType::BentConnector5, 20, 20, 400, 300);

auto lineFormat = connector->get_LineFormat();
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_StartShapeConnectionSiteIndex(2);

presentation->Save(u"connector-obstruction.pptx", SaveFormat::Pptx);
```

Memindahkan bengkok vertikal mengubah rute sehingga konektor melewati rintangan:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Alih‑alih mengasumsikan bahwa indeks koleksi `1` selalu mewakili bengkok vertikal, contoh ini mencari `ShapeAdjustmentType::ConnectorBendPositionY` dan mengubahnya hanya ketika tipe semantik yang diharapkan ada:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IConnector.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

shapes->AddAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
auto connector = shapes->AddConnector(ShapeType::BentConnector5, 20, 20, 400, 300);

auto lineFormat = connector->get_LineFormat();
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_StartShapeConnectionSiteIndex(2);

SharedPtr<IAdjustValue> verticalBend;
auto adjustments = connector->get_Adjustments();
for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
{
    auto adjustment = adjustments->idx_get(adjustmentIndex);
    Console::WriteLine(u"{0}: type = {1}, raw value = {2}", adjustment->get_Name(), static_cast<int32_t>(adjustment->get_Type()), adjustment->get_RawValue());
    if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionY)
    {
        verticalBend = adjustment;
        break;
    }
}

if (verticalBend == nullptr)
{
    Console::WriteLine(u"The connector does not expose a vertical bend adjustment.");
}
else
{
    verticalBend->set_RawValue(60000);
    presentation->Save(u"connector-obstruction-fixed.pptx", SaveFormat::Pptx);
}
```

Sebuah `ShapeType::BentConnector5` memiliki dua penyesuaian `ShapeAdjustmentType::ConnectorBendPositionX` dan satu penyesuaian `ShapeAdjustmentType::ConnectorBendPositionY`. Jika tipe yang Anda butuhkan muncul lebih dari sekali, periksa `IAdjustValue::get_Name` dan geometri preset yang diketahui sebelum memilih salah satunya. Jika sebuah penyesuaian melaporkan `ShapeAdjustmentType::Custom`, perlakukan makna dan rentangnya sebagai spesifik preset dan jangan ubah sampai kontrak tersebut diketahui.

## **Hubungkan Nilai Penyesuaian dengan Geometri Konektor**

Untuk konektor bengkok, nilai penyesuaian dapat digunakan untuk memperkirakan posisi segmen‑segmen individual. Perhitungan ini spesifik untuk preset konektor:

- `ShapeType::BentConnector4` biasanya menampilkan satu penyesuaian `ShapeAdjustmentType::ConnectorBendPositionX` dan satu `ShapeAdjustmentType::ConnectorBendPositionY`.
- Untuk posisi bengkok tersebut, `RawValue / 100000.0f` menghasilkan fraksi lebar atau tinggi kerangka konektor yang dipakai oleh contoh‑contoh di bawah.
- Kerangka konektor dapat diputar atau dibalik, sehingga koordinat kerangka harus ditransformasi sebelum dibandingkan dengan koordinat slide.

Contoh berikut menggunakan `IAdjustValue::get_Type` untuk mengidentifikasi penyesuaian terlebih dahulu. Mereka tidak memperlakukan indeks koleksi sebagai pengenal portabel.

### **Konektor Tanpa Rotasi**

Tata letak awal berisi dua bentuk teks yang terhubung oleh sebuah `ShapeType::BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Contoh ini memeriksa konektor dan memperoleh penyesuaian bengkok horizontal serta vertikal:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IConnector.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
sourceShape->get_TextFrame()->set_Text(u"From");
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
targetShape->get_TextFrame()->set_Text(u"To");
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20, 20, 400, 300);

auto lineFormat = connector->get_LineFormat();
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Crimson());
lineFormat->set_Width(3);
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_StartShapeConnectionSiteIndex(3);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_EndShapeConnectionSiteIndex(2);

auto adjustments = connector->get_Adjustments();
for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
{
    auto adjustment = adjustments->idx_get(adjustmentIndex);
    Console::WriteLine(u"{0}: type = {1}, raw value = {2}", adjustment->get_Name(), static_cast<int32_t>(adjustment->get_Type()), adjustment->get_RawValue());
}
```

Untuk mengubah kedua bengkok, temukan setiap tipe yang diharapkan dan modifikasi nilai hanya setelah keduanya ditemukan:

```cpp
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IConnector.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_StartShapeConnectionSiteIndex(3);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_EndShapeConnectionSiteIndex(2);

SharedPtr<IAdjustValue> horizontalBend;
SharedPtr<IAdjustValue> verticalBend;
auto adjustments = connector->get_Adjustments();
for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
{
    auto adjustment = adjustments->idx_get(adjustmentIndex);
    if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend == nullptr || verticalBend == nullptr)
{
    Console::WriteLine(u"The connector does not expose the expected bend adjustments.");
}
else
{
    horizontalBend->set_RawValue(horizontalBend->get_RawValue() + 20000);
    verticalBend->set_RawValue(verticalBend->get_RawValue() + 200000);
    presentation->Save(u"connector-adjusted.pptx", SaveFormat::Pptx);
}
```

Hasilnya adalah sebuah konektor yang segmen horizontal dan vertikalnya telah bergeser:

![connector-adjusted-1](connector-adjusted-1.png)

Setelah tipe semantik diketahui, nilainya dapat dikonversi ke koordinat kerangka konektor. Contoh ini menggambar sebuah persegi panjang tipis di atas segmen vertikal yang dikendalikan oleh dua penyesuaian bengkok:

```cpp
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IConnector.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_StartShapeConnectionSiteIndex(3);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_EndShapeConnectionSiteIndex(2);

SharedPtr<IAdjustValue> horizontalBend;
SharedPtr<IAdjustValue> verticalBend;
auto adjustments = connector->get_Adjustments();
for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
{
    auto adjustment = adjustments->idx_get(adjustmentIndex);
    if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend == nullptr || verticalBend == nullptr)
{
    Console::WriteLine(u"The connector does not expose the expected bend adjustments.");
}
else
{
    float x = connector->get_X() + connector->get_Width() * horizontalBend->get_RawValue() / 100000.0f;
    float y = connector->get_Y();
    float height = connector->get_Height() * verticalBend->get_RawValue() / 100000.0f;
    shapes->AddAutoShape(ShapeType::Rectangle, x, y, 1, height);
    presentation->Save(u"connector-segment-guide.pptx", SaveFormat::Pptx);
}
```

Bentuk panduan menandai segmen yang dihitung:

![connector-adjusted-2](connector-adjusted-2.png)

### **Konektor Diputar atau Dibalik**

Ketika geometri konektor yang sama diarahkan secara vertikal, nilai [IShape::get_Frame](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/get_frame/), [IShapeFrame::get_FlipH](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishapeframe/get_fliph/), dan [IShapeFrame::get_FlipV](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishapeframe/get_flipv/) memengaruhi konversi dari koordinat kerangka konektor ke koordinat slide.

Contoh ini membuat dan menyesuaikan konektor yang berorientasi vertikal:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IConnector.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
sourceShape->get_TextFrame()->set_Text(u"From");
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
targetShape->get_TextFrame()->set_Text(u"To 1");
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20, 20, 400, 300);

auto lineFormat = connector->get_LineFormat();
lineFormat->set_EndArrowheadStyle(LineArrowheadStyle::Triangle);
auto lineFillFormat = lineFormat->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_MediumAquamarine());
lineFormat->set_Width(3);
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_StartShapeConnectionSiteIndex(2);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_EndShapeConnectionSiteIndex(3);

auto adjustments = connector->get_Adjustments();
for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
{
    auto adjustment = adjustments->idx_get(adjustmentIndex);
    if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionX)
    {
        adjustment->set_RawValue(adjustment->get_RawValue() + 20000);
    }
    else if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionY)
    {
        adjustment->set_RawValue(adjustment->get_RawValue() + 200000);
    }
}

presentation->Save(u"vertical-connector-adjusted.pptx", SaveFormat::Pptx);
```

Konektor yang disesuaikan muncul secara vertikal di antara bentuk‑bentuk tersebut:

![connector-adjusted-3](connector-adjusted-3.png)

Untuk sudut rotasi sewenang‑wenang `alpha`, putar titik kerangka konektor `(x, y)` di sekitar pusat kerangka `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Kode berikut menangani orientasi 90 derajat yang digunakan dalam contoh ini dan menggambar panduan merah di atas segmen konektor yang bersesuaian:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IConnector.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IShapeFrame.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

auto sourceShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
auto targetShape = shapes->AddAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
auto connector = shapes->AddConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
connector->set_StartShapeConnectedTo(sourceShape);
connector->set_StartShapeConnectionSiteIndex(2);
connector->set_EndShapeConnectedTo(targetShape);
connector->set_EndShapeConnectionSiteIndex(3);

SharedPtr<IAdjustValue> horizontalBend;
SharedPtr<IAdjustValue> verticalBend;
auto adjustments = connector->get_Adjustments();
for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
{
    auto adjustment = adjustments->idx_get(adjustmentIndex);
    if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment->get_Type() == ShapeAdjustmentType::ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend == nullptr || verticalBend == nullptr)
{
    Console::WriteLine(u"The connector does not expose the expected bend adjustments.");
}
else
{
    horizontalBend->set_RawValue(horizontalBend->get_RawValue() + 20000);
    verticalBend->set_RawValue(verticalBend->get_RawValue() + 200000);

    float x = connector->get_X();
    float y = connector->get_Y();
    auto frame = connector->get_Frame();
    if (frame->get_FlipH() == NullableBool::True)
    {
        x += connector->get_Width();
    }
    if (frame->get_FlipV() == NullableBool::True)
    {
        y += connector->get_Height();
    }

    x += connector->get_Width() * horizontalBend->get_RawValue() / 100000.0f;
    float rotatedX = frame->get_CenterX() - y + frame->get_CenterY();
    float rotatedY = x - frame->get_CenterX() + frame->get_CenterY();
    float segmentWidth = connector->get_Height() * verticalBend->get_RawValue() / 100000.0f;
    auto guide = shapes->AddAutoShape(ShapeType::Rectangle, rotatedX, rotatedY, segmentWidth, 1);
    auto guideLineFillFormat = guide->get_LineFormat()->get_FillFormat();
    guideLineFillFormat->set_FillType(FillType::Solid);
    guideLineFillFormat->get_SolidFillColor()->set_Color(Color::get_Red());

    presentation->Save(u"rotated-connector-segment-guide.pptx", SaveFormat::Pptx);
}
```

Panduan merah menandai segmen yang dihitung setelah transformasi koordinat:

![connector-adjusted-4](connector-adjusted-4.png)

Rumus‑rumus ini menggambarkan preset yang dipakai dalam contoh, bukan model konektor universal. Validasi tipe penyesuaian, orientasi kerangka, dan rentang nilai sebelum menerapkan perhitungan yang sama pada preset lain.

## **Temukan Sudut Arah Konektor**

Arah sebuah konektor lurus dapat dihitung dari lebar dan tinggi, dengan pembalikan horizontal dan vertikal diterapkan. Contoh berikut melaporkan sudut searah jarum jam dari sumbu horizontal positif dalam koordinat slide:

```cpp
#include <DOM/IConnector.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IShapeFrame.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/math.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto connector = slide->get_Shapes()->AddConnector(ShapeType::StraightConnector1, 100, 100, 200, 100);
auto frame = connector->get_Frame();

bool flipH = frame->get_FlipH() == NullableBool::True;
bool flipV = frame->get_FlipV() == NullableBool::True;
float deltaX = connector->get_Width() * (flipH ? -1 : 1);
float deltaY = connector->get_Height() * (flipV ? -1 : 1);
double angle = Math::Atan2(deltaY, deltaX) * 180.0 / Math::PI;

if (angle < 0)
{
    angle += 360;
}

Console::WriteLine(u"Connector direction: {0:F2} degrees", angle);
```

## **FAQ**

**Bagaimana cara mengetahui apakah sebuah konektor dapat dipasang ke sebuah bentuk?**  
Periksa nilai `IShape::get_ConnectionSiteCount` pada bentuk. Jumlah positif berarti bentuk tersebut memiliki situs koneksi. Validasi indeks situs yang dipilih sebelum menetapkannya ke ujung konektor mana pun.

**Apakah saya dapat mengidentifikasi penyesuaian konektor melalui indeks koleksinya?**  
Indeks hanya bermakna untuk preset konektor dan tata letak koleksi yang diketahui. Periksa `IAdjustValue::get_Type` sebelum mengubah nilai, dan gunakan `IAdjustValue::get_Name` sebagai informasi tambahan bila tipe semantik yang sama muncul lebih dari sekali.

**Apa yang terjadi ketika sebuah bentuk yang terhubung dihapus?**  
Ujung konektor yang bersangkutan menjadi terlepas. Konektor tetap berada di slide dan dapat dihapus, diposisikan sebagai garis bebas, atau dipasang kembali ke bentuk lain.

**Apakah ikatan konektor dipertahankan saat slide disalin?**  
Ikatan umumnya dipertahankan ketika bentuk‑bentuk yang terhubung disalin bersama slide. Jika sebuah konektor disalin tanpa salah satu bentuk targetnya, ujung yang terpengaruh harus dipasang kembali.