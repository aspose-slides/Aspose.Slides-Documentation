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
description: "สร้างและแก้ไขตารางในสไลด์ PowerPoint ด้วย Aspose.Slides สำหรับ C++. ค้นพบตัวอย่างโค้ดง่าย ๆ เพื่อทำให้กระบวนการทำงานกับตารางของคุณเป็นระบบมากขึ้น."
---
## **บทนำ**

ตารางใน PowerPoint เป็นวิธีที่มีประสิทธิภาพในการแสดงและสื่อสารข้อมูล ข้อมูลที่อยู่ในตารางของเซลล์ (จัดเรียงเป็นแถวและคอลัมน์) นั้นเข้าใจได้ง่ายและตรงไปตรงมา。

Aspose.Slides มีคลาส [Table](https://reference.aspose.com/slides/th/cpp/aspose.slides/table/) , อินเทอร์เฟซ [ITable](https://reference.aspose.com/slides/th/cpp/aspose.slides/itable/) , คลาส [Cell](https://reference.aspose.com/slides/th/cpp/aspose.slides/cell/) , อินเทอร์เฟซ [ICell](https://reference.aspose.com/slides/th/cpp/aspose.slides/icell/) และประเภทอื่น ๆ เพื่อให้คุณสามารถสร้าง ปรับปรุง และจัดการตารางในงานนำเสนอทุกประเภทได้。

## **สร้างตารางจากศูนย์**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. กำหนดอาร์เรย์ของ `columnWidth`  
4. กำหนดอาร์เรย์ของ `rowHeight`  
5. เพิ่มอ็อบเจกต์ [ITable](https://reference.aspose.com/slides/th/cpp/aspose.slides/itable/) ไปยังสไลด์โดยใช้เมธอด [AddTable()](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapecollection/addtable/)  
6. วนลูปผ่านแต่ละ [ICell](https://reference.aspose.com/slides/th/cpp/aspose.slides/icell/) เพื่อทำการกำหนดรูปแบบให้กับขอบด้านบน ด้านล่าง ด้านขวา และด้านซ้าย  
7. รวมเซลล์สองเซลล์แรกของแถวแรกของตาราง  
8. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/textframe/) ของ [ICell](https://reference.aspose.com/slides/th/cpp/aspose.slides/icell/)  
9. เพิ่มข้อความบางส่วนลงใน [TextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/textframe/)  
10. บันทึกรายการนำเสนอที่แก้ไขแล้ว  

```c++
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
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

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
auto pres = System::MakeObject<Presentation>();

// เข้าถึงสไลด์แรก
auto sld = pres->get_Slides()->idx_get(0);

// กำหนดคอลัมน์โดยความกว้างและแถวโดยความสูง
auto dblCols = System::MakeArray<double>({ 50, 50, 50 });
auto dblRows = System::MakeArray<double>({ 50, 30, 30, 30, 30 });

// เพิ่มรูปร่างตารางลงในสไลด์
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// ตั้งค่ารูปแบบขอบสำหรับแต่ละเซลล์
for (int32_t row = 0; row < tbl->get_Rows()->get_Count(); row++)
{
    for (int32_t cell = 0; cell < tbl->get_Rows()->idx_get(row)->get_Count(); cell++)
    {
        auto cellFormat = tbl->get_Rows()->idx_get(row)->idx_get(cell)->get_CellFormat();

        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType((FillType::Solid));
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
// รวมเซลล์ 1 และ 2 ของแถวที่ 1
tbl->MergeCells(tbl->get_Rows()->idx_get(0)->idx_get(0), tbl->get_Rows()->idx_get(1)->idx_get(1), false);

// เพิ่มข้อความบางส่วนลงในเซลล์ที่รวมกัน
tbl->get_Rows()->idx_get(0)->idx_get(0)->get_TextFrame()->set_Text(u"Merged Cells");

// บันทึกงานนำเสนอไปยังดิสก์
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **การกำหนดหมายเลขในตารางมาตรฐาน**

ในตารางมาตรฐาน การกำหนดหมายเลขของเซลล์ทำได้ง่ายและเริ่มจากศูนย์ เซลล์แรกในตารางมีดัชนีเป็น 0,0 (คอลัมน์ 0 แถว 0)。

สำหรับตัวอย่าง ตารางที่มี 4 คอลัมน์และ 4 แถว จะถูกกำหนดหมายเลขดังนี้：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

```c++
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
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

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
auto pres = System::MakeObject<Presentation>();

// เข้าถึงสไลด์แรก
auto sld = pres->get_Slides()->idx_get(0);

// กำหนดคอลัมน์โดยความกว้างและแถวโดยความสูง
auto dblCols = System::MakeArray<double>({ 70, 70, 70, 70 });
auto dblRows = System::MakeArray<double>({ 70, 70, 70, 70 });

// เพิ่มรูปร่างตารางลงในสไลด์
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// ตั้งค่ารูปแบบขอบสำหรับแต่ละเซลล์
for (const auto& row : tbl->get_Rows())
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

// บันทึกการนำเสนอไปยังดิสก์
pres->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **การเข้าถึงตารางที่มีอยู่**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)  

2. รับอ้างอิงสไลด์ที่มีตารางผ่านดัชนีของมัน  

3. สร้างอ็อบเจกต์ [ITable](https://reference.aspose.com/slides/th/cpp/aspose.slides/itable/) แล้วตั้งค่าเป็น null  

4. วนลูปผ่านอ็อบเจกต์ [IShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/) ทั้งหมดจนกว่าจะพบตาราง  

    หากคุณสงสัยว่าสไลด์ที่กำลังทำงานอยู่มีเพียงตารางเดียว คุณสามารถตรวจสอบรูปทรงทั้งหมดที่มีอยู่ได้โดยตรง เมื่อรูปทรงถูกระบุว่าเป็นตาราง คุณสามารถทำการแคสเป็นอ็อบเจกต์ [Table](https://reference.aspose.com/slides/th/cpp/aspose.slides/table/) ได้ แต่หากสไลด์นั้นมีหลายตาราง คุณควรค้นหาตารางที่ต้องการผ่านเมธอด [set_AlternativeText()](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/set_alternativetext/)  

5. ใช้อ็อบเจกต์ [ITable](https://reference.aspose.com/slides/th/cpp/aspose.slides/itable/) เพื่อทำงานกับตาราง ในตัวอย่างด้านล่าง เราได้เพิ่มแถวใหม่ลงในตาราง  

6. บันทึกรายการนำเสนอที่แก้ไขแล้ว  

```c++
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
auto pres = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");

// เข้าถึงสไลด์แรก
auto sld = pres->get_Slides()->idx_get(0);

// กำหนดค่าเริ่มต้นของตารางเป็น null
System::SharedPtr<ITable> tbl;

// วนลูปผ่านรูปร่างและตั้งค่าอ้างอิงไปยังตารางที่พบ
for (const auto& shp : System::IterateOver(sld->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// ตั้งค่าข้อความสำหรับคอลัมน์แรกของแถวที่สอง
tbl->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");

// บันทึกการนำเสนอที่แก้ไขแล้วไปยังดิสก์
pres->Save(u"table1_out.pptx", SaveFormat::Pptx);
```

## **ค้นหาเซลล์ที่เป็นเจ้าของ Text Frame**

เมื่อโค้ดการประมวลผลข้อความทั่วไปได้รับ [ITextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/) จากตาราง ให้ใช้ [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/get_parentcell/) เพื่อดึง [ICell] ที่เป็นเจ้าของ สำหรับ Text Frame ของเซลล์ตาราง [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/get_parentcell/) จะคืนค่าเจ้าของและ [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/get_parentshape/) จะคืนค่า `nullptr` แม้ว่าตารางเองเป็นรูปทรง  

พิกัดของเซลล์สามารถเข้าถึงได้ผ่านเมธอดอ่านอย่างเดียว [ICell::get_FirstColumnIndex](https://reference.aspose.com/slides/th/cpp/aspose.slides/icell/get_firstcolumnindex/) และ [ICell::get_FirstRowIndex](https://reference.aspose.com/slides/th/cpp/aspose.slides/icell/get_firstrowindex/)  [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/get_parentcell/) ยังให้การนำทางแบบอ่านอย่างเดียว: มันคืนค่าเจ้าของแต่ไม่เปลี่ยนแปลงความเป็นเจ้าของ ควรตรวจสอบว่าเซลล์ที่ได้เป็น `nullptr` หรือไม่ก่อนใช้งานเสมอ  

สำหรับตัวอย่างเต็มที่ระบุเจ้าของเซลล์ตารางและรูปทรง รวมถึงรูปทรงที่เชื่อมโยงกับโหนด SmartArt ดูที่ [Search and Replace Text](/slides/th/cpp/search-and-replace-text/)  

## **การจัดเรียงข้อความในตาราง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. เพิ่มอ็อบเจกต์ [ITable](https://reference.aspose.com/slides/th/cpp/aspose.slides/itable/) ไปยังสไลด์  
4. เข้าถึงอ็อบเจกต์ [ITextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/) จากตาราง  
5. เข้าถึง [IParagraph](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraph/) ของ [ITextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/)  
6. จัดเรียงข้อความในแนวตั้ง  
7. บันทึกรายการนำเสนอที่แก้ไขแล้ว  

```c++
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
#include <DOM/ISlideCollection.h>
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

// สร้างอินสแตนซ์ของคลาส Presentation
auto presentation = System::MakeObject<Presentation>();

// ดึงสไลด์แรก
auto slide = presentation->get_Slides()->idx_get(0);

// กำหนดคอลัมน์ด้วยความกว้างและแถวด้วยความสูง
auto dblCols = System::MakeArray<double>({ 120, 120, 120, 120 });
auto dblRows = System::MakeArray<double>({ 100, 100, 100, 100 });

// เพิ่มรูปร่างตารางลงในสไลด์
auto tbl = slide->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);
tbl->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
tbl->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
tbl->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

// เข้าถึง TextFrame
auto txtFrame = tbl->idx_get(0, 0)->get_TextFrame();

// สร้างอ็อบเจกต์ Paragraph สำหรับ TextFrame
auto paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// สร้างอ็อบเจกต์ Portion สำหรับ Paragraph
auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// จัดแนวข้อความในแนวตั้ง
auto cell = tbl->idx_get(0, 0);
cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

// บันทึก Presentation ไปยังดิสก์
presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **ตั้งค่าการจัดรูปแบบข้อความระดับตาราง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. เข้าถึงอ็อบเจกต์ [ITable](https://reference.aspose.com/slides/th/cpp/aspose.slides/itable/) จากสไลด์  
4. กำหนดค่า [set_FontHeight()](https://reference.aspose.com/slides/th/cpp/aspose.slides/baseportionformat/set_fontheight/) สำหรับข้อความ  
5. กำหนดค่า [set_Alignment()](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/set_alignment/) และ [set_MarginRight()](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/set_marginright/)  
6. กำหนดค่า [set_TextVerticalType()](https://reference.aspose.com/slides/th/cpp/aspose.slides/textframeformat/set_textverticaltype/)  
7. บันทึกรายการนำเสนอที่แก้ไขแล้ว  

```c++
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
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

// สร้างอินสแตนซ์ของคลาส Presentation
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

// สมมติว่ารูปร่างแรกบนสไลด์แรกเป็นตาราง
auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// ตั้งค่าความสูงฟอนต์ของเซลล์ตาราง
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->SetTextFormat(portionFormat);

// ตั้งค่าการจัดแนวข้อความและขอบขวาของเซลล์ตารางในครั้งเดียว
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->SetTextFormat(paragraphFormat);

// ตั้งค่าชนิดการจัดแนวข้อความแนวตั้งของเซลล์ตาราง
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **รับคุณสมบัติสไตล์ของตาราง**

Aspose.Slides ให้คุณดึงคุณสมบัติสไตล์ของตารางเพื่อที่คุณจะได้นำรายละเอียดเหล่านั้นไปใช้กับตารางอื่นหรือที่อื่น โค้ด C++ นี้แสดงวิธีการดึงคุณสมบัติสไตล์จากสไตล์ตารางที่กำหนดล่วงหน้า：

```c++
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TableStylePreset.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **ล็อกอัตราส่วนของตาราง**

อัตราส่วนของรูปทรงเรขาคณิตคืออัตราส่วนของขนาดในมิติที่ต่างกัน Aspose.Slides มีคุณสมบัติ `AspectRatioLocked()` เพื่อให้คุณสามารถล็อกการตั้งค่าอัตราส่วนสำหรับตารางและรูปทรงอื่น ๆ  

โค้ด C++ นี้แสดงวิธีการล็อกอัตราส่วนสำหรับตาราง：

```c++
#include <DOM/IGraphicalObjectLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto table = System::ExplicitCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());


table->get_GraphicalObjectLock()->set_AspectRatioLocked(!table->get_GraphicalObjectLock()->get_AspectRatioLocked());

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**ฉันสามารถเปิดใช้งานการอ่านจากขวาไปซ้าย (RTL) สำหรับตารางทั้งหมดและข้อความในเซลล์ได้หรือไม่?**  
ใช่ ตารางมีเมธอด [set_RightToLeft](https://reference.aspose.com/slides/th/cpp/aspose.slides/table/set_righttoleft/) และย่อหน้ามี [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/th/cpp/aspose.slides/paragraphformat/set_righttoleft/) การใช้ทั้งสองจะทำให้ลำดับ RTL ถูกต้องและการเรนเดอร์ภายในเซลล์เป็นไปอย่างเหมาะสม。

**ฉันจะป้องกันไม่ให้ผู้ใช้ย้ายหรือปรับขนาดตารางในไฟล์สุดท้ายได้อย่างไร?**  
ใช้ [shape locks](/slides/th/cpp/applying-protection-to-presentation/) เพื่อปิดการย้าย ปรับขนาด การเลือก ฯลฯ การล็อกเหล่านี้ใช้กับตารางเช่นกัน。

**การแทรกรูปภาพภายในเซลล์เป็นพื้นหลังได้รับการสนับสนุนหรือไม่?**  
ใช่ คุณสามารถตั้งค่า [picture fill](https://reference.aspose.com/slides/th/cpp/aspose.slides/picturefillformat/) สำหรับเซลล์; รูปภาพจะครอบคลุมพื้นที่เซลล์ตามโหมดที่เลือก (ขยายหรือเรียงแบบกระเบื้อง)。