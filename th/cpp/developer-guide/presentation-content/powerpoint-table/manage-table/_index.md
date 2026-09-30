---
title: จัดการตารางการนำเสนอใน C++
linktitle: จัดการตาราง
type: docs
weight: 10
url: /th/cpp/manage-table/
keywords:
- เพิ่มตาราง
- สร้างตาราง
- เข้าถึงตาราง
- อัตราส่วนภาพ
- จัดแนวข้อความ
- การจัดรูปแบบข้อความ
- สไตล์ตาราง
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "สร้างและแก้ไขตารางในสไลด์ PowerPoint ด้วย Aspose.Slides สำหรับ C++. ค้นหาโค้ดตัวอย่างง่าย ๆ เพื่อทำให้กระบวนการทำงานกับตารางของคุณเป็นระเบียบยิ่งขึ้น."
---
## **บทนำ**

ตารางใน PowerPoint จัดระเบียบข้อมูลเป็นแถวและคอลัมน์ ทำให้อ่านและเปรียบเทียบค่าได้ง่ายขึ้น.

Aspose.Slides มีคลาส [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) , อินเทอร์เฟซ [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) , คลาส [Cell](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) , อินเทอร์เฟซ [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) และประเภทอื่น ๆ เพื่อให้คุณสามารถสร้าง อัปเดต และจัดการตารางในงานนำเสนอได้.

## **สร้างตารางจากศูนย์**

สร้างตารางโดยระบุตำแหน่ง ความกว้างของคอลัมน์ และความสูงของแถว หลังจากเพิ่มลงในสไลด์แล้ว คุณสามารถจัดรูปแบบเส้นขอบของเซลล์ ผสานเซลล์ และแทรกข้อความได้.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน.
3. กำหนดอาเรย์ของความกว้างคอลัมน์เป็นหน่วยพอยต์.
4. กำหนดอาเรย์ของความสูงแถวเป็นหน่วยพอยต์.
5. เพิ่มอ็อบเจ็กต์ [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) ไปยังสไลด์ผ่านเมธอด [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/).
6. วนลูปผ่านแต่ละ [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) เพื่อใช้การจัดรูปแบบกับเส้นขอบบน, ล่าง, ขวาและซ้าย.
7. ผสานเซลล์สองเซลล์แรกของแถวแรกของตาราง.
8. เข้าถึงเซลล์ที่ผสานแล้วผ่านเมธอด [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/).
9. ตั้งค่าข้อความในเซลล์ที่ผสาน.
10. บันทึกงานนำเสนอที่แก้ไขแล้ว.

ตัวอย่างด้านล่างสร้างตารางที่มีสามคอลัมน์และห้าแถวที่ตำแหน่ง (100, 50) พอยต์ มันใช้เส้นขอบสีแดงที่มีความกว้าง 5 พอยต์ ผสานเซลล์สองเซลล์แรกในแถวแรก และบันทึกผลลัพธ์เป็น `table.pptx`.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 50, 50, 50 });
auto rowHeights = System::MakeArray<double>({ 50, 30, 30, 30, 30 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

for (const auto& row : table->get_Rows())
{
    for (const auto& cell : row)
    {
        auto cellFormat = cell->get_CellFormat();

        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}

table->MergeCells(table->idx_get(0, 0), table->idx_get(1, 0), false);
table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Merged Cells");

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **การจัดลำดับในตารางมาตรฐาน**

ในตารางมาตรฐาน ดัชนีของเซลล์เริ่มจากศูนย์และใช้ลำดับ (คอลัมน์, แถว) เซลล์แรกมีดัชนีเป็น (0, 0).

ตัวอย่างเช่น เซลล์ในตารางที่มี 4 คอลัมน์และ 4 แถวจะถูกนับเลขดังนี้:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

ตัวอย่างนี้สร้างตาราง 4 × 4 ตามที่แสดงด้านบน โดยมีความกว้างคอลัมน์และความสูงแถวที่ 70 พอยต์และเส้นขอบเซลล์สีแดงที่มีความกว้าง 5 พอยต์ พิกัดแสดงดัชนีของเซลล์; ตัวอย่างนี้ปล่อยให้เซลล์ว่างเปล่าและบันทึกตารางเป็น `StandardTables_out.pptx`.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 70, 70, 70, 70 });
auto rowHeights = System::MakeArray<double>({ 70, 70, 70, 70 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

for (const auto& row : table->get_Rows())
{
    for (const auto& cell : row)
    {
        auto cellFormat = cell->get_CellFormat();
        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}

presentation->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **เข้าถึงตารางที่มีอยู่**

ตารางถูกเก็บในคอลเลกชันรูปร่างของสไลด์. วนลูปผ่านรูปร่างเพื่อค้นหาตาราง แล้วใช้อินเทอร์เฟซ [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) เพื่ออ่านหรืออัปเดตเซลล์ของมัน.

1. โหลดงานนำเสนอโดยใช้คลาส [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. รับอ้างอิงไปยังสไลด์ที่มีตารางอยู่โดยใช้ดัชนีของมัน.
3. วนลูปผ่านอ็อบเจ็กต์ [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) และหยุดเมื่อพบตาราง หากสไลด์มีหลายตาราง ใช้ [get_AlternativeText](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_alternativetext/) เพื่อระบุตารางที่คุณต้องการ.
4. อัปเดตข้อความในเซลล์เป้าหมาย.
5. บันทึกงานนำเสนอที่แก้ไขแล้ว.

ตัวอย่างด้านล่างเปิดไฟล์ `UpdateExistingTable.pptx` และค้นหาตารางแรกบนสไลด์แรก มันตั้งค่าเซลล์ที่คอลัมน์ 0 แถว 1 เป็น `New` และบันทึกผลลัพธ์เป็น `table1_out.pptx` อินพุตต้องมีอย่างน้อยหนึ่งสไลด์ และตารางแรกบนสไลด์นั้นต้องมีอย่างน้อยหนึ่งคอลัมน์และสองแถว.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");
auto slide = presentation->get_Slide(0);
System::SharedPtr<ITable> table;

for (const auto& shape : System::IterateOver(slide->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shape))
    {
        table = System::ExplicitCast<ITable>(shape);
        break;
    }
}

if (table != nullptr)
{
    table->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");
    presentation->Save(u"table1_out.pptx", SaveFormat::Pptx);
}
```

เพื่อปรับขนาดแถวในตารางที่มีอยู่และเข้าใจว่าทำไมความสูงจริงจึงอาจเกินค่าต่ำสุดที่ร้องขอ โปรดดู [ควบคุมความสูงของแถว](/slides/th/cpp/manage-rows-and-columns/#control-row-height).

## **ค้นหาเซลล์ที่เป็นเจ้าของกรอบข้อความ**

เมื่อโค้ดการประมวลผลข้อความทั่วไปรับอ็อบเจ็กต์ [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) จากตาราง ให้ใช้ [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) เพื่อดึง [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) ที่เป็นเจ้าของ สำหรับกรอบข้อความของเซลล์ตาราง, [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) จะคืนค่าเจ้าของและ [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentshape/) จะคืนค่า `nullptr` แม้ว่าตารางเองจะเป็นรูปร่างก็ตาม.

พิกัดของเซลล์สามารถเข้าถึงได้ผ่านเมธอดอ่านอย่างเดียว [ICell::get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) และ [ICell::get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) . [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) ยังให้การนำทางแบบอ่านอย่างเดียว: มันคืนค่าเจ้าของแต่ไม่เปลี่ยนแปลงความเป็นเจ้าของ ตรวจสอบว่าเซลล์ที่คืนค่ามี `nullptr` หรือไม่เสมอก่อนนำไปใช้.

สำหรับตัวอย่างที่ครบถ้วนซึ่งระบุเจ้าของเซลล์ตารางและรูปร่าง รวมถึงรูปร่างที่เชื่อมโยงกับโหนด SmartArt โปรดดู [ค้นหาและแทนที่ข้อความ](/slides/th/cpp/search-and-replace-text/).

## **จัดแนวข้อความในตาราง**

คุณสามารถควบคุมการยึดแนวตั้งและทิศทางของข้อความในแต่ละเซลล์ตาราง ตัวอย่างในส่วนนี้จัดให้อยู่กึ่งกลางในเซลล์แรกและหมุนข้อความ 270 องศา.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน.
3. เพิ่มอ็อบเจ็กต์ [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) ไปยังสไลด์.
4. เข้าถึงอ็อบเจ็กต์ [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) จากตาราง.
5. เข้าถึง [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) ตัวแรกและตั้งค่าข้อความและสีของมัน.
6. ตั้งค่าการยึดแนวตั้งของเซลล์และทิศทางของข้อความโดยใช้ [set_TextAnchorType](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_textanchortype/) และ [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_textverticaltype/).
7. บันทึกงานนำเสนอที่แก้ไขแล้ว.

ตัวอย่างนี้สร้างตาราง 4 × 4 ที่มีความกว้างคอลัมน์ 120 พอยต์และความสูงแถว 100 พอยต์ มันจัดรูปแบบข้อความในเซลล์ (0, 0) เพิ่มค่าลงในเซลล์ที่เหลือในแถวแรก และบันทึกผลลัพธ์เป็น `Vertical_Align_Text_out.pptx`.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <DOM/TextAnchorType.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 120, 120, 120, 120 });
auto rowHeights = System::MakeArray<double>({ 100, 100, 100, 100 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

table->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
table->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
table->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

auto cell = table->idx_get(0, 0);
auto paragraph = cell->get_TextFrame()->get_Paragraphs()->idx_get(0);

auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **ตั้งค่าการจัดรูปแบบข้อความระดับตาราง**

ใช้ [SetTextFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulktextformattable/settextformat/) เพื่อใช้การจัดรูปแบบข้อความกับเซลล์ทั้งหมดในตาราง ฟังก์ชันโอเวอร์โหลดรับการจัดรูปแบบส่วน, ย่อหน้า, และกรอบข้อความ ทำให้คุณสามารถตั้งค่าคุณสมบัติเหล่านี้ได้โดยไม่ต้องวนลูปผ่านเซลล์แต่ละเซลล์.

1. โหลดงานนำเสนอโดยใช้คลาส [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน.
3. เข้าถึงอ็อบเจ็กต์ [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) จากสไลด์.
4. ตั้งค่าขนาดฟอนต์โดยใช้ [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) สำหรับข้อความ.
5. ตั้งค่าการจัดตำแหน่งย่อหน้าและขอบขวาโดยใช้ [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) และ [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/).
6. ตั้งค่าทิศทางข้อความโดยใช้ [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/).
7. บันทึกงานนำเสนอที่แก้ไขแล้ว.

ตัวอย่างด้านล่างเปิดไฟล์ `table.pptx` ซึ่งต้องมีอย่างน้อยหนึ่งสไลด์ที่มีตารางเป็นรูปร่างแรก มันตั้งค่าขนาดฟอนต์เป็น 25 พอยต์ จัดย่อหน้าขวาด้วยขอบขวา 20 พอยต์ และทำให้ข้อความเป็นแนวตั้ง งานนำเสนอที่จัดรูปแบบแล้วจะถูกบันทึกเป็น `result.pptx`.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/PortionFormat.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
table->SetTextFormat(portionFormat);

auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
table->SetTextFormat(paragraphFormat);

auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **รับคุณสมบัติสไตล์ของตาราง**

ใช้ [get_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_stylepreset/) เพื่ออ่านสไตล์ตั้งล่วงหน้าของตารางและ [set_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/set_stylepreset/) เพื่อกำหนดสไตล์ ตัวอย่างนี้ใช้ [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/cpp/aspose.slides/tablestylepreset/) กับตารางหนึ่ง พิมพ์ชื่อสไตล์ที่ตั้งไว้และกำหนดสไตล์เดียวกันให้กับตารางที่สอง ทั้งสองตารางจะถูกบันทึกใน `table-style.pptx`.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TableStylePreset.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 100, 150 });
auto rowHeights = System::MakeArray<double>({ 5, 5, 5 });
auto table = slide->get_Shapes()->AddTable(10, 10, columnWidths, rowHeights);
table->set_StylePreset(TableStylePreset::DarkStyle1);

auto stylePreset = table->get_StylePreset();
System::Console::WriteLine(u"Table style preset: {0}", stylePreset);

auto anotherTable = slide->get_Shapes()->AddTable(10, 100, columnWidths, rowHeights);
anotherTable->set_StylePreset(stylePreset);

presentation->Save(u"table-style.pptx", SaveFormat::Pptx);
```

## **ล็อกอัตราส่วนของตาราง**

อัตราส่วนของตารางคืออัตราส่วนของความกว้างต่อความสูง ใช้ [set_AspectRatioLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/set_aspectratiolocked/) เพื่อทำการล็อกอัตราส่วนนี้สำหรับตาราง.

ตัวอย่างด้านล่างเปิดไฟล์ `pres.pptx` ซึ่งต้องมีอย่างน้อยหนึ่งสไลด์ที่มีตารางเป็นรูปร่างแรก มันพิมพ์สถานะล็อกปัจจุบัน เปิดการล็อกอัตราส่วน แล้วพิมพ์สถานะที่อัปเดต (`True`) และบันทึกผลลัพธ์เป็น `pres-out.pptx`.

```cpp
#include <DOM/IGraphicalObjectLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto slide = presentation->get_Slide(0);

auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

table->get_GraphicalObjectLock()->set_AspectRatioLocked(true);
Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

presentation->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**ฉันสามารถเปิดใช้งานทิศทางการอ่านจากขวาไปซ้าย (RTL) สำหรับตารางทั้งหมดและข้อความในเซลล์ของมันได้หรือไม่?**

ได้. ตารางมีเมธอด [set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/table/set_righttoleft/) และย่อหน้ามี [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphformat/set_righttoleft/). การใช้ทั้งสองจะทำให้ลำดับ RTL ถูกต้องและการแสดงผลภายในเซลล์เป็นไปตามที่คาดหวัง.

**ฉันจะป้องกันไม่ให้ผู้ใช้ย้ายหรือปรับขนาดตารางในไฟล์สุดท้ายได้อย่างไร?**

ใช้ [shape locks](/slides/th/cpp/applying-protection-to-presentation/) เพื่อปิดการย้าย, ปรับขนาด, เลือก เป็นต้น การล็อกเหล่านี้ใช้กับตารางด้วย.

**การแทรกรูปภาพภายในเซลล์เป็นพื้นหลังได้รับการสนับสนุนหรือไม่?**

ได้. คุณสามารถกำหนด [picture fill](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/) ให้กับเซลล์; รูปภาพจะครอบคลุมพื้นที่เซลล์ตามโหมดที่เลือก (ยืดหรือกระเบื้อง).