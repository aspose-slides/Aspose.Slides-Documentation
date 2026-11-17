---
title: จัดการเซลล์ตารางในงานนำเสนอด้วย C++
linktitle: จัดการเซลล์
type: docs
weight: 30
url: /th/cpp/manage-cells/
keywords:
- เซลล์ตาราง
- รวมเซลล์
- ลบขอบ
- แยกเซลล์
- รูปภาพในเซลล์
- สีพื้นหลัง
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "จัดการเซลล์ตาราง PowerPoint ด้วย C++: ระบุเซลล์ที่รวมกัน, ลบขอบ, แยกเซลล์, และตั้งค่าสีพื้นหลังและรูปภาพด้วย Aspose.Slides สำหรับ C++."
---
## **Overview**

Aspose.Slides อนุญาตให้คุณเข้าถึงและแก้ไขเซลล์ตารางในงานนำเสนอ PowerPoint บทความนี้อธิบายวิธีระบุเซลล์ตารางที่รวมอยู่, ลบขอบเซลล์, ทำงานกับการนับเลขเซลล์หลังจากการรวมหรือแยกเซลล์, เปลี่ยนสีพื้นหลังของเซลล์, และเพิ่มภาพภายในเซลล์ตาราง ตัวอย่างจะแสดงวิธีสร้างหรือเปิดงานนำเสนอ, ดึงตารางจากสไลด์, ปรับรูปแบบเซลล์ผ่านคุณสมบัติของเซลล์, และบันทึกงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

Aspose.Slides ใช้ดัชนีเริ่มจากศูนย์เพื่อเข้าถึงเซลล์ตารางตามลำดับ `(column, row)`

## **Identify a Merged Table Cell**

ตัวอย่างเปิดงานนำเสนอที่มีอยู่และเข้าถึงรูปร่างแรกบนสไลด์แรกในรูปแบบตาราง สมมติว่ามีสไลด์และรูปร่างอยู่และรูปร่างเป็นตาราง จากนั้นวนลูปผ่านทุกแถวและคอลัมน์และใช้ [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) เพื่อระบุเซลล์ในพื้นที่ที่รวมกัน สำหรับแต่ละที่ตรงกัน จะพิมพ์พิกัดของเซลล์ในรูปแบบ `row;column`, [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/), [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/), และพิกัดเริ่มต้นของบริเวณ, [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) และ [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/)

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation_with_table.pptx");
auto slide = presentation->get_Slide(0);
auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto rowCount = table->get_Rows()->get_Count();
for (auto rowIndex = 0; rowIndex < rowCount; rowIndex++)
{
    auto columnCount = table->get_Columns()->get_Count();
    for (auto columnIndex = 0; columnIndex < columnCount; columnIndex++)
    {
        auto cell = table->idx_get(columnIndex, rowIndex);
        if (cell->get_IsMergedCell())
        {
            Console::WriteLine(u"Cell {0};{1} belongs to a merged region with RowSpan={2} and ColSpan={3} starting at {4};{5}.", rowIndex, columnIndex, cell->get_RowSpan(), cell->get_ColSpan(), cell->get_FirstRowIndex(), cell->get_FirstColumnIndex());
        }
    }
}
```

## **Remove Table Cell Borders**

สร้าง [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) และเพิ่มตารางไปยังสไลด์แรกด้วย [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/). ความกว้างคอลัมน์, ความสูงแถว, และตำแหน่งของตารางกำหนดเป็นหน่วยพอยท์ ตัวอย่างตั้งค่าขอบเซลล์สี่ด้านทั้งหมดเป็น [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/), ทำให้ขอบไม่แสดง

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <system/enumerator_adapter.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({50, 50, 50, 50});
auto rowHeights = MakeArray<double>({50, 30, 30, 30, 30});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

for (const auto& row : IterateOver(table->get_Rows()))
    for (const auto& cell : IterateOver(row))
    {
        cell->get_CellFormat()->get_BorderTop()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderRight()->get_FillFormat()->set_FillType(FillType::NoFill);
    }

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Add Diagonal Cell Borders**

ใช้ [get_BorderDiagonalDown](https://reference.aspose.com/slides/cpp/aspose.slides/icellformat/get_borderdiagonaldown/) เพื่อวาดเส้นจากมุมซ้ายบนไปมุมขวาล่าง, และ [get_BorderDiagonalUp](https://reference.aspose.com/slides/cpp/aspose.slides/icellformat/get_borderdiagonalup/) เพื่อวาดเส้นจากมุมซ้ายล่างไปมุมขวาบน เส้นทแยงสามารถทำเครื่องหมายหัวข้อมุม; เส้นทแยงสองเส้นสามารถสร้างรูป X เพื่อทำเครื่องหมายว่าเซลล์ไม่ใช้ได้

แต่ละเส้นทแยงเป็น [ILineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/). ใช้ [get_FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/get_fillformat/) เพื่อเข้าถึงการเติม, เรียก [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ilinefillformat/set_filltype/) พร้อมกับ [FillType::Solid](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) และเลือกสีผ่าน [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ilinefillformat/get_solidfillcolor/). ตั้งความกว้างเส้นด้วย [set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_width/) หน่วยพอยท์

ตัวอย่างสร้างเซลล์สามเซลล์ในหนึ่งแถว: เส้นทแยงลงสีแดง, เส้นทแยงขึ้นสีน้ำเงิน, และเส้นทแยงทั้งสอง. ขอบด้านบน, ด้านล่าง, ด้านซ้าย, และด้านขวาของเซลล์ยังคงไม่เปลี่ยน

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/array.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({210, 210, 210});
auto rowHeights = MakeArray<double>({160});
auto table = slide->get_Shapes()->AddTable(45, 130, columnWidths, rowHeights);

auto downwardBorder = table->idx_get(0, 0)->get_CellFormat()->get_BorderDiagonalDown();
downwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
downwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
downwardBorder->set_Width(3);

auto upwardBorder = table->idx_get(1, 0)->get_CellFormat()->get_BorderDiagonalUp();
upwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
upwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
upwardBorder->set_Width(5);

auto crossDownwardBorder = table->idx_get(2, 0)->get_CellFormat()->get_BorderDiagonalDown();
crossDownwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
crossDownwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
crossDownwardBorder->set_Width(3);

auto crossUpwardBorder = table->idx_get(2, 0)->get_CellFormat()->get_BorderDiagonalUp();
crossUpwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
crossUpwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
crossUpwardBorder->set_Width(5);

presentation->Save(u"diagonal_cell_borders.pptx", SaveFormat::Pptx);
```

เส้นทแยงเป็นคุณสมบัติการจัดรูปแบบ, ไม่ใช่การแยกเซลล์. แต่ละเซลล์ยังคงมีกรอบข้อความเดียวที่เข้าถึงได้ผ่าน [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/); พื้นที่แต่ละข้างของเส้นทแยงไม่สามารถแก้ไขแยกกันได้

ตารางที่บันทึกแล้ว, แสดงใน Microsoft PowerPoint:

![เซลล์ตารางสามเซลล์แสดงเส้นทแยงสีแดงจากมุมซ้ายบนไปมุมขวาล่าง, เส้นทแยงสีน้ำเงินจากมุมซ้ายล่างไปมุมขวาบน, และเส้นทแยงสองเส้นสร้างรูป X](diagonal-cell-borders.png)

*จากซ้ายไปขวา: เส้นทแยงลง (สีแดง, 3 pt), เส้นทแยงขึ้น (สีน้ำเงิน, 5 pt), และเส้นทแยงสองเส้น*

## **Merge Table Cells**

ใช้ [MergeCells](https://reference.aspose.com/slides/cpp/aspose.slides/itable/mergecells/) เพื่อรวมช่วงสี่เหลี่ยมของเซลล์ตารางเป็นเซลล์เดียว ระบุเซลล์ที่มุมซ้ายบนและมุมขวาล่างของช่วง. อาร์กิวเมนต์สุดท้ายควบคุมว่าการรวมอาจรวมเซลล์ที่อยู่นอกช่วงที่ระบุหรือไม่; `false` ทำให้การรวมอยู่ภายในช่วงเท่านั้น

ตัวอย่างสร้างตาราง 4x4 ที่คอลัมน์และแถวมีความกว้าง 70 พอยท์, จากนั้นรวมเซลล์ศูนย์กลางสี่เซลล์จาก `(1, 1)` ถึง `(2, 2)`. เซลล์ที่ได้ครอบคลุมสองคอลัมน์และสองแถว, ขณะที่กริดพื้นฐานของตารางยังคงมีสี่คอลัมน์และสี่แถว. เพื่อเข้าถึงเนื้อหาหรือรูปแบบของเซลล์ที่รวม, ใช้ตำแหน่งซ้ายบน: `table->idx_get(1, 1)` ในตัวอย่างนี้. ตำแหน่งอื่น ๆ ในช่วงที่รวมยังคงเป็นส่วนหนึ่งของกริดตาราง, ดังนั้นดัชนีของเซลล์ที่อยู่นอกช่วงจะไม่เปลี่ยน

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({70, 70, 70, 70});
auto rowHeights = MakeArray<double>({70, 70, 70, 70});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 2), false);

presentation->Save(u"merged_cells.pptx", SaveFormat::Pptx);
```

## **Split Table Cells**

การรวมเซลล์ในตัวอย่างก่อนหน้ารักษากริดของตารางไว้ การแยกเซลล์อาจสร้างคอลัมน์กริดใหม่และเปลี่ยนดัชนีคอลัมน์ของเซลล์ทางขวา Aspose.Slides ปฏิบัติตามโมเดลกริดตารางของ PowerPoint

ตัวอย่างนี้สร้างตาราง 4x4 ที่คอลัมน์และแถวมีความกว้าง 70 พอยท์และเรียก [SplitByWidth](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbywidth/) บนเซลล์ `(1, 1)`. ครึ่งหนึ่งของความกว้าง 70 พอยท์ของเซลล์จะถูกใช้เพื่อสร้างสองเซลล์ที่ความกว้างเท่ากัน

หลังจากการแยกนี้, ส่วนครึ่งสองจะเข้าถึงได้เป็น `table->idx_get(1, 1)` และ `table->idx_get(2, 1)`. กริดตารางตอนนี้มีห้าคอลัมน์: เซลล์ที่เคยอยู่ในคอลัมน์ 2 และ 3 ย้ายไปที่คอลัมน์ 3 และ 4 ตามลำดับ. ดัชนีแถวยังคงเดิม. ใช้ดัชนีคอลัมน์ที่อัปเดตนี้เมื่อเข้าถึงเซลล์หลังจากการแยก

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({70, 70, 70, 70});
auto rowHeights = MakeArray<double>({70, 70, 70, 70});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->idx_get(1, 1)->SplitByWidth(table->idx_get(1, 1)->get_Width() / 2);

presentation->Save(u"split_cells.pptx", SaveFormat::Pptx);
```

<!-- visual-explanation:manage-cells:start -->
[![เซลล์ขนาด 70 พอยท์ที่ไม่ได้รวมกันแยกเป็นสองเซลล์ขนาด 35 พอยท์, เพิ่มคอลัมน์กริดที่ห้าคอลัมน์และเปลี่ยนตำแหน่งดัชนีทางด้านขวา.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*การแยกความกว้างส่งผลต่อเซลล์ (1, 1) โดยใช้ดัชนีเริ่มจากศูนย์ (คอลัมน์, แถว) แถวอื่น ๆ ยังคงมีเซลล์ที่ครอบคลุมตำแหน่งคอลัมน์ใหม่ทั้งสอง*
<!-- visual-explanation:manage-cells:end -->

### **Split Merged Cells by Row or Column Span**

เพื่อเตรียมเซลล์แม่แบบที่รวมไว้สำหรับการเติมข้อมูล, ใช้ [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) เพื่อแยกตามขอบแถวที่มีอยู่, หรือ [SplitByColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbycolspan/) เพื่อแยกตามขอบคอลัมน์

อาร์กิวเมนต์ `index` นับแถวในส่วนบนหรือคอลัมน์ในส่วนซ้ายของการแยก; มันสัมพันธ์กับบริเวณที่รวมอยู่:
- แยกแถว: `0 < index <` [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/)
- แยกคอลัมน์: `0 < index <` [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/)

ตัวอย่างคาดว่างานนำเสนอมีตารางเป็นรูปร่างแรกบนสไลด์แรก, โดย `(1, 2)` และ `(1, 3)` รวมกันในแนวตั้ง. เริ่มจากตำแหน่งล่าง, ใช้ [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) และ [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) เพื่อหาแหล่งกำเนิดและตรวจสอบทั้งสองช่วง. `SplitByRowSpan(1)` จากนั้นจะแยกแถว 2 และ 3 สำหรับชื่อสินค้า. สำหรับการรวมแนวนอนสองคอลัมน์, ใช้ `SplitByColSpan(1)` แทน

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/ITextFrame.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table_template.pptx");
auto slide = presentation->get_Slide(0);
auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto selectedCell = table->idx_get(1, 3);
auto firstColumnIndex = selectedCell->get_FirstColumnIndex();
auto firstRowIndex = selectedCell->get_FirstRowIndex();
auto mergedCell = table->idx_get(firstColumnIndex, firstRowIndex);

if (mergedCell->get_IsMergedCell() && mergedCell->get_RowSpan() == 2 && mergedCell->get_ColSpan() == 1)
{
    mergedCell->SplitByRowSpan(1);

    // ดึงเซลล์ที่ได้จากตารางหลังการแยก.
    auto upperCell = table->idx_get(firstColumnIndex, firstRowIndex);
    auto lowerCell = table->idx_get(firstColumnIndex, firstRowIndex + 1);
    Console::WriteLine(u"Upper cell merged: {0}", upperCell->get_IsMergedCell());
    Console::WriteLine(u"Lower cell merged: {0}", lowerCell->get_IsMergedCell());

    upperCell->get_TextFrame()->set_Text(u"Product A");
    lowerCell->get_TextFrame()->set_Text(u"Product B");

    presentation->Save(u"split_template.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Select a merged region spanning exactly two rows and one column.");
}
```

กริดตารางและดัชนีเซลล์โดยรอบคงเดิม. ดึงเซลล์ที่ได้ตามพิกัด; ที่นี่ทั้งสองเซลล์มีช่วงเป็น 1 และ [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) พิมพ์ `False`. พื้นที่ขนาดใหญ่กว่าอาจยังคงรวมกันบางส่วนหลังจากการแยกหนึ่งครั้ง

ข้อความดั้งเดิมและรูปแบบของมันคงอยู่ในเซลล์บน (หรือซ้าย); เซลล์ใหม่เป็นค่าว่างแต่สืบทอดรูปแบบเซลล์เช่นการเติม, ขอบ, และระยะขอบ. เติมข้อมูลในเซลล์หลังจากการแยกและตั้งค่าการฟอร์แมตข้อความที่ต้องการอย่างชัดเจน

งานนำเสนอที่บันทึกมีเซลล์ “Product A” และ “Product B” แยกจากกันพร้อมรูปแบบเซลล์ของแม่แบบที่คงไว้. ดู [Cell API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) สำหรับรายละเอียด

### **Split a Cell at a Specific Height**

[SplitByHeight](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyheight/) รับความสูงของส่วนบนเป็นพอยท์. [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) รับจำนวนแถวกริดที่มีอยู่ในส่วนบน. เพื่อจัดตำแหน่งเซลล์ 40 พอยท์ในคอลัมน์ขวา, ลบ 40 จากความสูงจริงของเซลล์และแบ่งพื้นที่ส่วนที่เหลือเท่า ๆ กันด้านบนและด้านล่าง

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <DOM/ITextFrame.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({160, 160});
auto rowHeights = MakeArray<double>({140});

auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);
table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Left");

auto height = table->idx_get(1, 0)->get_Height();
auto margin = (height - 40) / 2;

table->idx_get(1, 0)->SplitByHeight(margin);
table->idx_get(1, 1)->SplitByHeight(40);
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"Middle");

presentation->Save(u"split_by_height.pptx", SaveFormat::Pptx);
```

การแยกแรกเพิ่มแถวกริด, ทิ้งส่วนล่างที่เหลือ 90 พอยท์ที่ `(1, 1)`. การแยกที่สองมุ่งเป้าไปที่เซลล์นั้นและเพิ่มแถวอีกหนึ่งแถวด้านล่าง. คอลัมน์ขวาตอนนี้มี `(1, 0)` ที่ 50 พอยท์ (`margin`), `(1, 1)` ที่ 40 พอยท์, และ `(1, 2)` ที่ 50 พอยท์ (`margin`). เซลล์ซ้ายครอบคลุมทั้งสามแถวที่ความสูงเดิม 140 พอยท์

![เซลล์ซ้ายครอบคลุมความสูงเต็มของตารางอยู่ข้างเซลล์สามเซลล์ที่มีข้อความ Middle อยู่กึ่งกลาง.](split-by-height.png)

## **Change the Table Cell Background Color**

ตัวอย่างนี้สร้างตารางที่คอลัมน์มีความกว้าง 150 พอยท์และแถวมีความสูง 50 พอยท์. ใช้ [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) เพื่อเลือกการเติมแบบสีทึบและ [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/) เพื่อเข้าถึงสีเติมและตั้งเป็นสีแดงสำหรับเซลล์ `(2, 3)`, ซึ่งอยู่ในคอลัมน์ที่สามและแถวที่สี่

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/Table/ICellFormat.h>
#include <drawing/color.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({150, 150, 150, 150});
auto rowHeights = MakeArray<double>({50, 50, 50, 50, 50});
auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);

auto cell = table->idx_get(2, 3);
cell->get_CellFormat()->get_FillFormat()->set_FillType(FillType::Solid);
cell->get_CellFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

presentation->Save(u"cell_background_color.pptx", SaveFormat::Pptx);
```

## **Add an Image Inside a Table Cell**

วางภาพอินพุตในไดเรกทอรีทำงานก่อนรันตัวอย่างนี้. มันโหลดภาพด้วย [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/) และเพิ่มเข้าไปในคอลเลกชันภาพของงานนำเสนอด้วย [AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/). จากนั้นกำหนดภาพให้กับการเติมรูปภาพของเซลล์ `(0, 0)`, เซลล์แรกของตาราง

[PictureFillMode::Stretch](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) ขยายภาพให้เต็มเซลล์, ซึ่งอาจเปลี่ยนอัตราส่วนภาพ. ความกว้างคอลัมน์และความสูงแถวเป็นพอยท์. ภาพที่โหลดแล้วจะถูกทำลายหลังจากเพิ่มเข้าไปในงานนำเสนอ

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/IImageCollection.h>
#include <IImage.h>
#include <DOM/IPPImage.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Table/ICellFormat.h>
#include <Util/Images.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({150, 150, 150, 150});
auto rowHeights = MakeArray<double>({100, 100, 100, 100, 90});
auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);

auto image = Images::FromFile(u"aspose_logo.jpg");
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->set_FillType(FillType::Picture);
table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

presentation->Save(u"table_cell_with_image.pptx", SaveFormat::Pptx);
```

## **FAQ**

**ฉันสามารถตั้งความหนาและสไตล์ของเส้นที่แตกต่างกันสำหรับด้านต่าง ของเซลล์เดียวได้หรือไม่?**

ใช่. ขอบ[ด้านบน](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_bordertop/)/[ด้านล่าง](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderbottom/)/[ด้านซ้าย](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderleft/)/[ด้านขว](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderright/) มีคุณสมบัติแยกกัน, ดังนั้นความหนาและสไตล์ของแต่ละด้านจึงสามารถแตกต่างกันได้

**จะเกิดอะไรขึ้นกับภาพหากฉันเปลี่ยนขนาดคอลัมน์/แถวหลังจากตั้งรูปภาพเป็นพื้นหลังของเซลล์?**

พฤติกรรมขึ้นอยู่กับ [fill mode](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) (stretch/tile). เมื่อขยาย, ภาพจะปรับให้พอดีกับเซลล์ใหม่; เมื่อเติมกระเบื้อง, กระเบื้องจะถูกคำนวณใหม่

**ฉันสามารถกำหนดไฮเปอร์ลิงก์ให้กับเนื้อหาทั้งหมดของเซลล์ได้หรือไม่?**

[Hyperlinks](/slides/th/cpp/manage-hyperlinks/) ตั้งระดับข้อความ (portion) ภายในกรอบข้อความของเซลล์หรือระดับของตาราง/รูปร่างทั้งหมด. ในการใช้งานจริงคุณจะกำหนดลิงก์ให้กับ portion หนึ่งหรือให้กับข้อความทั้งหมดในเซลล์

**ฉันสามารถตั้งฟอนต์ที่แตกต่างกันภายในเซลล์เดียวได้หรือไม่?**

ใช่. กรอบข้อความของเซลล์รองรับ [portions](https://reference.aspose.com/slides/cpp/aspose.slides/portion/) (run) ที่มีการฟอร์แมตอิสระ—ครอบครัวฟอนต์, สไตล์, ขนาด, และสี