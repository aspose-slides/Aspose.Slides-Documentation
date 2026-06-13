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
- อัตราส่วน
- จัดแนวข้อความ
- การจัดรูปแบบข้อความ
- สไตล์ตาราง
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "สร้างและแก้ไขตารางในสไลด์ PowerPoint ด้วย Aspose.Slides สำหรับ C++. ค้นพบตัวอย่างโค้ดง่าย ๆ เพื่อทำให้กระบวนการทำงานกับตารางของคุณเป็นระเบียบมากขึ้น."
---
## **บทนำ**

ตารางใน PowerPoint เป็นวิธีที่มีประสิทธิภาพในการแสดงและสื่อสารข้อมูล ข้อมูลในกริดของเซลล์ (จัดเรียงเป็นแถวและคอลัมน์) นั้นตรงไปตรงมาและเข้าใจง่าย.

Aspose.Slides มีคลาส [Table](https://reference.aspose.com/slides/th/cpp/aspose.slides/table/) อินเทอร์เฟซ [ITable](https://reference.aspose.com/slides/th/cpp/aspose.slides/itable/) คลาส [Cell](https://reference.aspose.com/slides/th/cpp/aspose.slides/cell/) อินเทอร์เฟซ [ICell](https://reference.aspose.com/slides/th/cpp/aspose.slides/icell/) และประเภทอื่น ๆ เพื่อให้คุณสามารถสร้าง, ปรับปรุง, และจัดการตารางในงานนำเสนอทุกประเภท.

## **สร้างตารางจากศูนย์**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/).
2. ได้รับอ้างอิงของสไลด์ผ่านดัชนีของมัน. 
3. กำหนดอาร์เรย์ของ `columnWidth`.
4. กำหนดอาร์เรย์ของ `rowHeight`.
5. เพิ่มอ็อบเจกต์ [ITable](https://reference.aspose.com/slides/th/cpp/aspose.slides/itable/) ลงในสไลด์ผ่านเมธอด [AddTable()](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapecollection/addtable/).
6. วนลูปผ่านแต่ละ [ICell](https://reference.aspose.com/slides/th/cpp/aspose.slides/icell/) เพื่อกำหนดรูปแบบให้กับเส้นขอบบน, ด้านล่าง, ด้านขวา, และด้านซ้าย.
7. รวมสองเซลล์แรกของแถวแรกของตาราง. 
8. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/textframe/) ของ [ICell](https://reference.aspose.com/slides/th/cpp/aspose.slides/icell/). 
9. เพิ่มข้อความลงใน [TextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/textframe/).
10. บันทึกงานนำเสนอที่แก้ไขแล้ว.

โค้ด C++ ตัวอย่างนี้แสดงวิธีสร้างตารางในงานนำเสนอ:

```c++
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
auto pres = System::MakeObject<Presentation>();

// เข้าถึงสไลด์แรก
auto sld = pres->get_Slides()->idx_get(0);

// กำหนดคอลัมน์ด้วยความกว้างและแถวด้วยความสูง
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

// บันทึกการนำเสนอไปยังดิสก์
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **การกำหนดหมายเลขในตารางมาตรฐาน**

ในตารางมาตรฐาน การกำหนดหมายเลขของเซลล์ทำได้อย่างตรงไปตรงมาและเริ่มจากศูนย์ เซลล์แรกในตารางจะมีดัชนีเป็น 0,0 (คอลัมน์ 0, แถว 0).

ตัวอย่างเช่น เซลล์ในตารางที่มี 4 คอลัมน์และ 4 แถวจะถูกนับเลขดังนี้:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

โค้ด C++ ตัวอย่างนี้แสดงวิธีระบุหมายเลขสำหรับเซลล์ในตาราง:

```c++
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
auto pres = System::MakeObject<Presentation>();

// เข้าถึงสไลด์แรก
auto sld = pres->get_Slides()->idx_get(0);

// กำหนดคอลัมน์ด้วยความกว้างและแถวด้วยความสูง
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

## **เข้าถึงตารางที่มีอยู่**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/).

2. ได้รับอ้างอิงของสไลด์ที่มีตารางผ่านดัชนีของมัน. 

3. สร้างอ็อบเจกต์ [ITable](https://reference.aspose.com/slides/th/cpp/aspose.slides/itable/) และกำหนดค่าเป็น null.

4. วนลูปผ่านอ็อบเจกต์ทั้งหมดของ [IShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/) จนกว่าจะพบตาราง.

   หากคุณสงสัยว่าสไลด์ที่กำลังจัดการมีเพียงตารางเดียว คุณสามารถตรวจสอบทุกรูปร่างที่สไลด์ประกอบอยู่ได้อย่างง่ายดาย เมื่อรูปร่างถูกระบุว่าเป็นตาราง คุณสามารถทำการแคสเป็นอ็อบเจกต์ [Table](https://reference.aspose.com/slides/th/cpp/aspose.slides/table/) ได้ แต่หากสไลด์มีหลายตาราง คุณควรค้นหาตารางที่ต้องการผ่านเมธอด [set_AlternativeText()](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/set_alternativetext/).

5. ใช้อ็อบเจกต์ [ITable](https://reference.aspose.com/slides/th/cpp/aspose.slides/itable/) เพื่อทำงานกับตาราง ในตัวอย่างด้านล่าง เราได้เพิ่มแถวใหม่ลงในตาราง.

6. บันทึกงานนำเสนอที่แก้ไขแล้ว.

โค้ด C++ ตัวอย่างนี้แสดงวิธีเข้าถึงและทำงานกับตารางที่มีอยู่:

```c++
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
auto pres = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");

// เข้าถึงสไลด์แรก
auto sld = pres->get_Slides()->idx_get(0);

// เริ่มต้น Table เป็น null
System::SharedPtr<ITable> tbl;

// วนลูปผ่านรูปร่างต่าง ๆ และตั้งค่าอ้างอิงไปยังตารางที่พบ
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

## **จัดแนวข้อความในตาราง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/).
2. ได้รับอ้างอิงของสไลด์ผ่านดัชนีของมัน. 
3. เพิ่มอ็อบเจกต์ [ITable](https://reference.aspose.com/slides/th/cpp/aspose.slides/itable/) ลงในสไลด์. 
4. เข้าถึงอ็อบเจกต์ [ITextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/) จากตาราง. 
5. เข้าถึง [IParagraph](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraph/) ของ [ITextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/).
6. จัดแนวข้อความแนวตั้ง.
7. บันทึกงานนำเสนอที่แก้ไขแล้ว.

โค้ด C++ ตัวอย่างนี้แสดงวิธีจัดแนวข้อความในตาราง:

```c++
// สร้างอินสแตนซ์ของคลาส Presentation
auto presentation = System::MakeObject<Presentation>();

// ได้รับสไลด์แรก
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

// จัดแนวข้อความแนวตั้ง
auto cell = tbl->idx_get(0, 0);
cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

// บันทึก Presentation ไปยังดิสก์
presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **ตั้งค่าการจัดรูปแบบข้อความในระดับตาราง**

1. สร้างอินสแตนซ์ของ คลาสต่าง ๆ ผ่าน [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) .
2. ได้รับอ้างอิงของสไลด์ผ่านดัชนีของมัน. 
3. เข้าถึงอ็อบเจกต์ [ITable](https://reference.aspose.com/slides/th/cpp/aspose.slides/itable/) จากสไลด์.
4. ตั้งค่า [set_FontHeight()](https://reference.aspose.com/slides/th/cpp/aspose.slides/baseportionformat/set_fontheight/) สำหรับข้อความ. 
5. ตั้งค่า [set_Alignment()](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/set_alignment/) และ [set_MarginRight()](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/set_marginright/). 
6. ตั้งค่า [set_TextVerticalType()](https://reference.aspose.com/slides/th/cpp/aspose.slides/textframeformat/set_textverticaltype/).
7. บันทึกงานนำเสนอที่แก้ไขแล้ว. 

โค้ด C++ ตัวอย่างนี้แสดงวิธีใช้ตัวเลือกการจัดรูปแบบที่คุณต้องการกับข้อความในตาราง:

```c++
// สร้างอินสแตนซ์ของคลาส Presentation
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

// สมมติว่ารูปร่างแรกบนสไลด์แรกเป็นตาราง
auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// ตั้งค่าความสูงของฟอนต์ในเซลล์ตาราง
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->SetTextFormat(portionFormat);

// ตั้งค่าการจัดตำแหน่งข้อความและระยะขอบขวาของเซลล์ตารางในหนึ่งคำสั่ง
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

## **ดึงคุณสมบัติสไตล์ของตาราง**

Aspose.Slides อนุญาตให้คุณดึงคุณสมบัติสไตล์ของตารางเพื่อใช้รายละเอียดเหล่านี้กับตารางอื่นหรือในที่อื่น โค้ด C++ ตัวอย่างนี้แสดงวิธีดึงคุณสมบัติสไตล์จากสไตล์ตารางที่กำหนดไว้ล่วงหน้า:

```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **ล็อกอัตราส่วนของตาราง**

อัตราส่วนของรูปทรงเรขาคณิตคือสัดส่วนของขนาดในมิติที่ต่างกัน Aspose.Slides มีคุณสมบัติ `AspectRatioLocked()` เพื่อให้คุณล็อกการตั้งค่าอัตราส่วนสำหรับตารางและรูปทรงอื่น ๆ 

โค้ด C++ ตัวอย่างนี้แสดงวิธีล็อกอัตราส่วนสำหรับตาราง:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto table = System::ExplicitCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());


table->get_GraphicalObjectLock()->set_AspectRatioLocked(!table->get_GraphicalObjectLock()->get_AspectRatioLocked());

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **คำถามที่พบบ่อย**

**ฉันสามารถเปิดใช้งานทิศทางการอ่านจากขวาไปซ้าย (RTL) สำหรับตารางทั้งหมดและข้อความในเซลล์ได้หรือไม่?**

ใช่ ตารางมีเมธอด [set_RightToLeft](https://reference.aspose.com/slides/th/cpp/aspose.slides/table/set_righttoleft/) และย่อหน้ามี [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/th/cpp/aspose.slides/paragraphformat/set_righttoleft/) การใช้ทั้งสองจะทำให้ลำดับ RTL และการแสดงผลภายในเซลล์ถูกต้อง.

**ฉันจะป้องกันไม่ให้ผู้ใช้ย้ายหรือปรับขนาดตารางในไฟล์ขั้นสุดท้ายได้อย่างไร?**

ใช้ [shape locks](/slides/th/cpp/applying-protection-to-presentation/) เพื่อปิดการย้าย, ปรับขนาด, การเลือก ฯลฯ การล็อกเหล่านี้ใช้กับตารางได้เช่นกัน.

**การแทรกรูปภาพภายในเซลล์เป็นพื้นหลังได้รับการสนับสนุนหรือไม่?**

ใช่ คุณสามารถตั้งค่า [picture fill](https://reference.aspose.com/slides/th/cpp/aspose.slides/picturefillformat/) ให้กับเซลล์; รูปภาพจะครอบคลุมพื้นที่เซลล์ตามโหมดที่เลือก (ยืดหรือเรียงแบบกระเบื้อง).