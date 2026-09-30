---
title: จัดการแถวและคอลัมน์ในตาราง PowerPoint ด้วย C++
linktitle: แถวและคอลัมน์
type: docs
weight: 20
url: /th/cpp/manage-rows-and-columns/
keywords:
- แถวตาราง
- คอลัมน์ตาราง
- แถวแรก
- ส่วนหัวตาราง
- คัดลอกแถว
- คัดลอกคอลัมน์
- คัดลอกแถว
- คัดลอกคอลัมน์
- ลบแถว
- ลบคอลัมน์
- การจัดรูปแบบข้อความของแถว
- การจัดรูปแบบข้อความของคอลัมน์
- สไตล์ตาราง
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "จัดการแถวและคอลัมน์ของตารางใน PowerPoint ด้วย Aspose.Slides สำหรับ C++ เพื่อเร่งกระบวนการแก้ไขการนำเสนอและอัปเดตข้อมูล."
---
## **บทนำ**

Aspose.Slides for C++ ช่วยให้คุณจัดการโครงสร้างและการจัดรูปแบบของตารางในงานนำเสนอ PowerPoint ผ่านคลาส [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) และอินเทอร์เฟซ [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) คุณสามารถกำหนดแถวหัวเรื่อง, คัดลอกหรือเอาแถวและคอลัมน์ออก, และนำการจัดรูปแบบข้อความไปใช้กับแถวหรือคอลัมน์ทั้งหมดได้

บทความนี้อธิบายการดำเนินการเหล่านี้ด้วยตัวอย่าง C++ อีกทั้งแสดงวิธีดึงสไตล์พรีเซ็ตของตารางเพื่อให้คุณสามารถใช้ซ้ำได้ ดัชนีแถวและคอลัมน์ของตารางเริ่มจากศูนย์

## **ควบคุมความสูงของแถว**

ใช้ [IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/) เพื่อกำหนดความสูงขั้นต่ำของแถวเป็นหน่วยจุด เป็นค่าขอบล่าง ไม่ใช่ความสูงคงที่ [IRow::get_Height](https://reference.aspose.com/slides/cpp/aspose.slides/irow/get_height/) จะคืนค่าความสูงจริง; ค่านี้ไม่สามารถตั้งค่าโดยตรงได้ เข้าถึงแถวผ่าน [ITable::get_Rows](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_rows/)

ตัวอย่างโหลดไฟล์ [row-height-input.pptx](row-height-input.pptx) ซึ่งมีตารางเป็นรูปร่างแรกบนสไลด์แรก แถวแรกเริ่มที่ 70 จุด เซลล์ใช้ข้อความ Arial ขนาด 18 จุด, มีการตัดบรรทัด, และขอบบน‑ล่าง 6 จุด; ข้อความยาวในคอลัมน์ที่สองตัดบรรทัดหลายบรรทัด ตัวอย่างเพิ่มค่าน้อยสุดเป็น 100 จุด แล้วลดลงเป็น 20 จุด, พิมพ์ความสูงจริงหลังการเปลี่ยนแต่ละครั้ง และบันทึกผลลัพธ์ทั้งสอง

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IRow.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"row-height-input.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));
auto row = table->get_Rows()->idx_get(0);

row->set_MinimalHeight(100);
Console::WriteLine(u"Increased: minimum = {0:F1}, actual = {1:F1} pt", row->get_MinimalHeight(), row->get_Height());
presentation->Save(u"row-height-increased.pptx", SaveFormat::Pptx);

row->set_MinimalHeight(20);
Console::WriteLine(u"Decreased: minimum = {0:F1}, actual = {1:F1} pt", row->get_MinimalHeight(), row->get_Height());
presentation->Save(u"row-height-decreased.pptx", SaveFormat::Pptx);
```

ด้วยงานนำเสนอที่ให้มา การเพิ่มค่าน้อยสุดจะเพิ่มพื้นที่ให้กับแถว การลดค่าน้อยสุดจะลบพื้นที่เพิ่มนั้นออก แต่ความสูงจริงยังคงมากกว่า 20 จุดเนื่องจากข้อความและขอบเซลล์ต้องการพื้นที่มากกว่านั้น การลดค่าน้อยสุดอย่างเดียวไม่สามารถบังคับให้แถวต่ำกว่าพื้นที่ที่เนื้อหาต้องการได้

หลายปัจจัยส่งผลต่อความสูงจริง:

- **ข้อความและขนาดแบบอักษร:** ข้อความยาว, การขึ้นบรรทัดใหม่โดยเจตนา, หรือแบบอักษรใหญ่กว่าจะต้องการพื้นที่แนวตั้งมากขึ้น
- **การตัดบรรทัดและความกว้างคอลัมน์:** หากเปิดการตัดบรรทัดแล้วลดความกว้างคอลัมน์ด้วย [IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/) จะทำให้มีบรรทัดเพิ่มขึ้น คอลัมน์กว้างขึ้นอาจลดพื้นที่แนวตั้งที่ต้องการ
- **ขอบเซลล์:** [ICell::set_MarginTop](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_margintop/) และ [ICell::set_MarginBottom](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginbottom/) ควบคุมขอบที่เพิ่มพื้นที่แนวตั้ง [ICell::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginleft/) และ [ICell::set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginright/) ควบคุมขอบที่ลดความกว้างที่มีให้ข้อความและอาจทำให้เกิดการตัดบรรทัดเพิ่มเติม

สำหรับตารางนี้ไม่มีเซลล์ที่รวมกัน เซลล์ที่ต้องการพื้นที่แนวตั้งมากที่สุดจะกำหนดขอบเขตล่างของแถวทั้งหมด หากต้องการให้แถวนั้นสั้นลง คุณอาจต้องลดความยาวข้อความ, ลดขนาดแบบอักษรหรือขอบ, หรือทำให้คอลัมน์กว้างขึ้น

ภาพด้านล่างแสดงตารางเดียวกันในสเกลเดียวกัน ในการแสดงผล .NET ที่อ้างอิงนี้ ความสูงจริงคือ 70, 100 และ 55.2 จุด: แถวสุดท้ายยังคงสูงกว่า 20 จุดค่าน้อยสุดที่กำหนด การวัดข้อความที่แม่นยำอาจแตกต่างตามแบบอักษรที่มีในสภาพแวดล้อมของคุณ ดาวน์โหลดผลลัพธ์ที่บันทึกไว้: [increased minimum](row-height-increased.pptx) และ [decreased minimum](row-height-decreased.pptx)

| Original: minimum 70 pt, actual 70 pt | Increased: minimum 100 pt, actual 100 pt | Decreased: minimum 20 pt, actual 55.2 pt |
| --- | --- | --- |
| ![Original table with a 70-point first row.](row-height-before.png) | ![Table after increasing the first row minimum to 100 points.](row-height-increased.png) | ![Table after decreasing the first row minimum to 20 points; wrapped text keeps the row taller than the minimum.](row-height-decreased.png) |

## **กำหนดแถวแรกเป็นหัวเรื่อง**

ใช้เมธอด [set_FirstRow](https://reference.aspose.com/slides/cpp/aspose.slides/itable/set_firstrow/) เพื่อทำเครื่องหมายแถวแรกให้เป็นรูปแบบหัวเรื่อง รูปลักษณ์ของแถวขึ้นอยู่กับสไตล์ตารางที่นำไปใช้กับตาราง

1. โหลดงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)
2. เข้าถึงสไลด์แรก
3. เข้าถึงตารางที่จัดเก็บเป็นรูปร่างแรกบนสไลด์
4. เปิดใช้การจัดรูปแบบหัวเรื่องสำหรับแถวแรก
5. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างต้องการไฟล์ `table.pptx` ที่มีตารางเป็นรูปร่างแรกบนสไลด์แรก จะเปิดใช้การจัดรูปแบบหัวเรื่องสำหรับแถวแรกและบันทึกเป็น `First_row_header.pptx`

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));
table->set_FirstRow(true);

presentation->Save(u"First_row_header.pptx", SaveFormat::Pptx);
```

## **คัดลอกแถวหรือคอลัมน์ของตาราง**

คัดลอกแถวหรือคอลัมน์เพื่อใช้ซ้ำเนื้อหาและการจัดรูปแบบ คุณสามารถเพิ่มสำเนาที่ส่วนท้ายของตารางหรือแทรกที่ตำแหน่งเฉพาะได้

1. โหลดงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)
2. เข้าถึงสไลด์แรก
3. กำหนดความกว้างคอลัมน์และความสูงแถว
4. เพิ่มตารางด้วยเมธอด [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/)
5. คัดลอกแถวที่ต้องการ
6. คัดลอกคอลัมน์ที่ต้องการ
7. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างต้องการไฟล์ `Test.pptx` ที่มีอย่างน้อยหนึ่งสไลด์ จะสร้างตารางที่มีสามคอลัมน์และห้าแถวโดยกำหนดขนาดเป็นจุด แล้วเพิ่มสำเนาของแถวแรกและคอลัมน์แรก, จากนั้นแทรกสำเนาของแถวสองและคอลัมน์สองที่ตำแหน่งดัชนี 3 (ตำแหน่งที่สี่) ตารางผลลัพธ์จะมีเจ็ดแถวและห้าคอลัมน์ อาร์กิวเมนต์ `false` จะหลีกเลี่ยงการคัดลอกไปยังแถวหรือคอลัมน์ที่รวมกัน; ตารางนี้ไม่มีเซลล์ที่รวมกัน

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Table/ICell.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Test.pptx");
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 50, 50, 50 });
auto rowHeights = MakeArray<double>({ 50, 30, 30, 30, 30 });
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Row 1 Cell 1");
table->idx_get(1, 0)->get_TextFrame()->set_Text(u"Row 1 Cell 2");
table->get_Rows()->AddClone(table->get_Rows()->idx_get(0), false);

table->idx_get(0, 1)->get_TextFrame()->set_Text(u"Row 2 Cell 1");
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"Row 2 Cell 2");
table->get_Rows()->InsertClone(3, table->get_Rows()->idx_get(1), false);

table->get_Columns()->AddClone(table->get_Columns()->idx_get(0), false);
table->get_Columns()->InsertClone(3, table->get_Columns()->idx_get(1), false);

presentation->Save(u"table_out.pptx", SaveFormat::Pptx);
```

## **ลบแถวหรือคอลัมน์จากตาราง**

ลบแถวหรือคอลัมน์ที่ไม่ต้องการอีกต่อไปในตาราง การลบรายการจะทำให้ดัชนีของแถวหรือคอลัมน์ที่ตามมาถูกเลื่อน

1. สร้างงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)
2. เข้าถึงสไลด์แรก
3. กำหนดความกว้างคอลัมน์และความสูงแถว
4. เพิ่มตารางด้วยเมธอด [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/)
5. ลบแถวที่สองและคอลัมน์ที่สอง
6. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างนี้สร้างตาราง 3×3 และลบแถวและคอลัมน์ที่ดัชนี 1 ทำให้เหลือ ตาราง 2×2 ในไฟล์ `TestTable_out.pptx` ขนาดเป็นหน่วยจุด อาร์กิวเมนต์ `false` ปิดการลบแถวหรือคอลัมน์ที่รวมกัน; ตารางนี้ไม่มีเซลล์ที่รวมกัน

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 100, 50, 30 });
auto rowHeights = MakeArray<double>({ 30, 50, 30 });
auto table = slide->get_Shapes()->AddTable(100, 100, columnWidths, rowHeights);

table->get_Rows()->RemoveAt(1, false);
table->get_Columns()->RemoveAt(1, false);

presentation->Save(u"TestTable_out.pptx", SaveFormat::Pptx);
```

## **กำหนดการจัดรูปแบบข้อความบนระดับแถวของตาราง**

ใช้การจัดรูปแบบข้อความกับแถวทั้งหมดเพื่อให้เซลล์มีความสอดคล้องกัน คุณสามารถตั้งค่าคุณสมบัติแบบอักษร, การจัดรูปแบบย่อหน้า, และทิศทางข้อความโดยไม่ต้องจัดรูปแบบแต่ละเซลล์แยกกัน

1. โหลดงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)
2. เข้าถึงตารางบนสไลด์แรก
3. ตั้งค่าสูงของแบบอักษรด้วย [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) สำหรับแถวแรก
4. ตั้งค่าการจัดแนวและขอบย่อหน้าขวาด้วย [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) และ [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) สำหรับแถวแรก
5. ตั้งค่าทิศทางข้อความด้วย [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) สำหรับแถวที่สอง
6. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างต้องการไฟล์ `table.pptx` ที่มีตารางเป็นรูปร่างแรกบนสไลด์แรกและต้องมีอย่างน้อยสองแถว จะใช้ข้อความขนาด 25 จุด, การจัดแนวขวา, และขอบย่อหน้าขวา 20 จุดกับแถวแรก, จากนั้นตั้งค่าข้อความแนวตั้งในแถวที่สอง

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/PortionFormat.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <DOM/Table/IRow.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25);
table->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

auto paragraphFormat = MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20);
table->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

auto textFrameFormat = MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

presentation->Save(u"row_formatting.pptx", SaveFormat::Pptx);
```

## **กำหนดการจัดรูปแบบข้อความบนระดับคอลัมน์ของตาราง**

ใช้การจัดรูปแบบข้อความกับคอลัมน์ทั้งหมดเพื่อให้เซลล์มีความสอดคล้องกัน คุณสามารถตั้งค่าคุณสมบัติแบบอักษร, การจัดรูปแบบย่อหน้า, และทิศทางข้อความโดยไม่ต้องจัดรูปแบบแต่ละเซลล์แยกกัน

1. โหลดงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)
2. เข้าถึงตารางบนสไลด์แรก
3. ตั้งค่าสูงของแบบอักษรด้วย [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) สำหรับคอลัมน์แรก
4. ตั้งค่าการจัดแนวและขอบย่อหน้าขวาด้วย [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) และ [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) สำหรับคอลัมน์แรก
5. ตั้งค่าทิศทางข้อความด้วย [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) สำหรับคอลัมน์ที่สอง
6. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างต้องการไฟล์ `table.pptx` ที่มีตารางเป็นรูปร่างแรกบนสไลด์แรกและต้องมีอย่างน้อยสองคอลัมน์ จะใช้ข้อความขนาด 25 จุด, การจัดแนวขวา, และขอบย่อหน้าขวา 20 จุดกับคอลัมน์แรก, จากนั้นตั้งค่าข้อความแนวตั้งในคอลัมน์ที่สอง

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/PortionFormat.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <DOM/Table/IColumn.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25);
table->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

auto paragraphFormat = MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20);
table->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

auto textFrameFormat = MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

presentation->Save(u"column_formatting.pptx", SaveFormat::Pptx);
```

## **รับคุณสมบัติสไตล์ของตาราง**

ใช้เมธอด [get_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_stylepreset/) เพื่อดึงพรีเซ็ตที่นำไปใช้กับตารางและใช้ซ้ำบนตารางอื่น ๆ วิธีนี้จะระบุพรีเซ็ตแทนการเขียนทับการจัดรูปแบบของเซลล์แต่ละเซลล์

ตัวอย่างสร้างตาราง, ใช้ [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/cpp/aspose.slides/tablestylepreset/) แล้วอ่านพรีเซ็ตกลับมา พิมพ์ `DarkStyle1` และบันทึกตารางในไฟล์ `table.pptx`

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <DOM/TableStylePreset.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 100, 150 });
auto rowHeights = MakeArray<double>({ 5, 5, 5 });
auto table = slide->get_Shapes()->AddTable(10, 10, columnWidths, rowHeights);
table->set_StylePreset(TableStylePreset::DarkStyle1);

Console::WriteLine(u"{0}", table->get_StylePreset());

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **FAQ**

**ฉันสามารถใช้ธีม/สไตล์ของ PowerPoint กับตารางที่สร้างแล้วได้หรือไม่?**

ได้ ตารางสืบทอดธีมของสไลด์/เลเอาต์/มาสเตอร์ และคุณยังคงสามารถเขียนทับการเติมสี, เส้นขอบ, และสีข้อความเหนือธีมนั้นได้

**ฉันสามารถจัดเรียงแถวของตารางแบบ Excel ได้หรือไม่?**

ไม่ได้ ตารางของ Aspose.Slides ไม่มีฟังก์ชันการจัดเรียงหรือกรองในตัว ให้จัดเรียงข้อมูลในหน่วยความจำก่อนแล้วเติมแถวตารางตามลำดับนั้นใหม่

**ฉันสามารถทำคอลัมน์เป็นแบบลายเส้น (banded) พร้อมคงสีที่กำหนดเองในเซลล์เฉพาะได้หรือไม่?**

ได้ เปิดการใช้คอลัมน์แบบลายเส้นแล้วเขียนทับเซลล์เฉพาะด้วยการจัดรูปแบบระดับเซลล์; การจัดรูปแบบระดับเซลล์จะมีความสำคัญเหนือสไตล์ของตาราง