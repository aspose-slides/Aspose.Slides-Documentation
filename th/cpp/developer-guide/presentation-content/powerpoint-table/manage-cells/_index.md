---
title: จัดการเซลล์ตารางในงานนำเสนอโดยใช้ C++
linktitle: จัดการเซลล์
type: docs
weight: 30
url: /th/cpp/manage-cells/
keywords:
- เซลล์ตาราง
- รวมเซลล์
- ลบกรอบ
- แยกเซลล์
- รูปภาพในเซลล์
- สีพื้นหลัง
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "จัดการเซลล์ตาราง PowerPoint ด้วย C++: ระบุเซลล์ที่รวม, ลบกรอบ, แยกเซลล์, และตั้งค่าสีพื้นหลังและรูปภาพด้วย Aspose.Slides สำหรับ C++."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณเข้าถึงและแก้ไขเซลล์ตารางในงานนำเสนอ PowerPoint ได้ บทความนี้อธิบายวิธีระบุเซลล์ตารางที่รวมกัน การลบกรอบเซลล์ การทำงานกับการนับหมายเลขเซลล์หลังจากการรวมหรือแยกเซลล์ การเปลี่ยนสีพื้นหลังของเซลล์ และการเพิ่มรูปภาพเข้าไปในเซลล์ตาราง ตัวอย่างแสดงวิธีสร้างหรือเปิดงานนำเสนอ ดึงตารางจากสไลด์ ปรับรูปแบบเซลล์ผ่านคุณสมบัติของเซลล์ และบันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX
Aspose.Slides ใช้ดัชนีเริ่มจากศูนย์เพื่อเข้าถึงเซลล์ตารางตามลำดับ `(column, row)`.

## **ระบุเซลล์ตารางที่รวมกัน**

ตัวอย่างเปิดงานนำเสนอที่มีอยู่และเข้าถึงรูปร่างแรกบนสไลด์แรกเป็นตาราง มันสมมติว่ามีสไลด์และรูปร่างอยู่และรูปร่างเป็นตาราง จากนั้นวนซ้ำผ่านทุกแถวและคอลัมน์และใช้ [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) เพื่อระบุเซลล์ในพื้นที่ที่รวมกัน สำหรับแต่ละผลลัพธ์ จะพิมพ์พิกัดเซลล์ในลำดับ `row;column`, [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/), [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/), และพิกัดเริ่มต้นของพื้นที่, [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) และ [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/).

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

## **ลบกรอบเซลล์ตาราง**

สร้าง [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) และเพิ่มตารางไปยังสไลด์แรกด้วย [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/)。 ความกว้างของคอลัมน์, ความสูงของแถว, และตำแหน่งของตารางระบุเป็นจุด ตัวอย่างตั้งค่ากรอบเซลล์สี่ด้านทั้งหมดเป็น [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/), ทำให้มองไม่เห็น.

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

## **รวมเซลล์ตาราง**

ใช้ [MergeCells](https://reference.aspose.com/slides/cpp/aspose.slides/itable/mergecells/) เพื่อรวมช่วงสี่เหลี่ยมของเซลล์ตารางเป็นเซลล์เดียว ระบุเซลล์ที่มุมซ้ายบนและมุมขวาล่างของช่วง อากิวเมนต์สุดท้ายควบคุมว่าการรวมอาจรวมเซลล์นอกช่วงที่ระบุหรือไม่; `false` จะทำให้การรวมอยู่ภายในช่วงนั้น

ตัวอย่างสร้างตาราง 4x4 ที่มีคอลัมน์และแถวขนาด 70 จุด จากนั้นรวมเซลล์กลางสี่เซลล์จาก `(1, 1)` ถึง `(2, 2)` เซลล์ที่ได้จะครอบคลุมสองคอลัมน์และสองแถว ในขณะที่กริดพื้นฐานของตารางยังคงมีสี่คอลัมน์และสี่แถว เพื่อเข้าถึงเนื้อหา或รูปแบบของเซลล์ที่รวม ให้ใช้ตำแหน่งมุมซ้ายบน: `table->idx_get(1, 1)` ในตัวอย่างนี้ ตำแหน่งอื่นในช่วงที่รวมยังคงเป็นส่วนหนึ่งของกริดตาราง ดังนั้นดัชนีของเซลล์นอกช่วงจะไม่เปลี่ยน

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

## **แยกเซลล์ตาราง**

การรวมเซลล์ในตัวอย่างก่อนหน้านี้ทำให้กริดของตารางคงเดิม การแยกเซลล์สามารถสร้างคอลัมน์กริดใหม่และเปลี่ยนดัชนีคอลัมน์ของเซลล์ที่อยู่ทางขวา Aspose.Slides ปฏิบัติตามโมเดลกริดของตารางใน PowerPoint.

ตัวอย่างนี้สร้างตาราง 4x4 ที่มีคอลัมน์และแถวขนาด 70 จุดและเรียก [SplitByWidth](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbywidth/) บนเซลล์ `(1, 1)` ครึ่งหนึ่งของความกว้าง 70 จุดของเซลล์จะถูกนำไปสร้างเซลล์สองเซลล์ที่ความกว้างเท่ากัน.

หลังจากการแยกนี้ ครึ่งสองส่วนจะเข้าถึงได้โดยใช้ `table->idx_get(1, 1)` และ `table->idx_get(2, 1)` ตารางกริดตอนนี้มีห้าคอลัมน์: เซลล์ที่เคยอยู่ในคอลัมน์ 2 และ 3 จะย้ายไปที่คอลัมน์ 3 และ 4 ตามลำดับ ดัชนีแถวคงที่ ใช้ดัชนีคอลัมน์ที่อัปเดตนี้เมื่อเข้าถึงเซลล์หลังจากการแยก.

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

### **แยกเซลล์ที่รวมตามช่วงแถวหรือคอลัมน์**

เพื่อเตรียมเซลล์แม่แบบที่รวมไว้สำหรับการเติมข้อมูล ให้ใช้ [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) เพื่อแยกตามเส้นแบ่งแถวที่มีอยู่ หรือใช้ [SplitByColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbycolspan/) เพื่อแยกตามเส้นแบ่งคอลัมน์

`index` เป็นอากิวเมนต์ที่นับจำนวนแถวในส่วนบนหรือคอลัมน์ในส่วนซ้ายของการแยก; มันสัมพันธ์กับพื้นที่ที่รวมไว้:

- การแยกแถว: `0 < index <` [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/).
- การแยกคอลัมน์: `0 < index <` [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/).

ตัวอย่างคาดว่าการนำเสนอมีตารางเป็นรูปร่างแรกบนสไลด์แรก โดยที่เซลล์ `(1, 2)` และ `(1, 3)` ถูกรวมกันในแนวตั้ง. เริ่มจากตำแหน่งล่าง มันใช้ [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) และ [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) เพื่อค้นหาตำแหน่งต้นกำเนิดและตรวจสอบทั้งสองช่วง. จากนั้น `SplitByRowSpan(1)` แยกแถว 2 และ 3 เพื่อชื่อตัวสินค้า. หากต้องการรวมสองคอลัมน์ในแนวนอน ให้ใช้ `SplitByColSpan(1)` แทน.

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

    // ดึงเซลล์ที่ได้จากตารางหลังจากการแยก.
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

กริดของตารางและดัชนีเซลล์โดยรอบคงเดิม. ดึงเซลล์ที่ได้โดยใช้พิกัดของมัน; ในที่นี้ ทั้งสองมีช่วงเป็น 1 และ [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) พิมพ์ `False`. พื้นที่ที่ใหญ่กว่าอาจยังคงรวมกันบางส่วนหลังจากการแยกหนึ่งครั้ง.

ข้อความต้นฉบับและรูปแบบของมันคงอยู่ในเซลล์บน (หรือซ้าย); เซลล์ใหม่เป็นค่าว่างแต่สืบทอดรูปแบบเซลล์เช่นการเติม, กรอบ, และระยะขอบ. เติมข้อมูลในเซลล์หลังจากการแยกและตั้งค่าการจัดรูปแบบข้อความที่ต้องการอย่างชัดเจน.

งานนำเสนอที่บันทึกจะมีเซลล์ "Product A" และ "Product B" แยกกันพร้อมกับรูปแบบเซลล์ตามแม่แบบที่คงไว้ ดูที่ [Cell API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) สำหรับรายละเอียด.

## **เปลี่ยนสีพื้นหลังของเซลล์ตาราง**

ตัวอย่างนี้สร้างตารางที่มีคอลัมน์ขนาด 150 จุดและแถวขนาด 50 จุด ใช้ [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) เพื่อเลือกการเติมแบบสีทึบและ [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/) เพื่อเข้าถึงสีเติมและตั้งค่าเป็นสีแดงสำหรับเซลล์ `(2, 3)`, ซึ่งอยู่ในคอลัมน์ที่สามและแถวที่สี่.

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

## **เพิ่มรูปภาพภายในเซลล์ตาราง**

วางรูปภาพที่ต้องการในไดเรกทอรีทำงานก่อนรันตัวอย่างนี้ มันโหลดรูปภาพด้วย [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/) และเพิ่มลงในคอลเลกชันรูปภาพของงานนำเสนอด้วย [AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/). จากนั้นกำหนดรูปภาพให้กับการเติมรูปภาพของเซลล์ `(0, 0)`, เซลล์แรกของตาราง.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) ขยายรูปภาพให้เต็มเซลล์ ซึ่งอาจเปลี่ยนอัตราส่วนของมัน ความกว้างของคอลัมน์และความสูงของแถวระบุเป็นจุด รูปภาพที่โหลดจะถูกทำลายหลังจากที่ได้ถูกเพิ่มลงในงานนำเสนอแล้ว.

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

## **คำถามที่พบบ่อย**

**ฉันสามารถกำหนดความหนาและสไตล์ของเส้นที่ต่างกันสำหรับด้านต่าง ๆ ของเซลล์เดียวได้หรือไม่?**

ได้. กรอบ [top](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_bordertop/)/[bottom](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderbottom/)/[left](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderleft/)/[right](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderright/) มีคุณสมบัติเฉพาะของแต่ละด้าน ดังนั้นความหนาและสไตล์ของแต่ละด้านสามารถแตกต่างกันได้.

**จะเกิดอะไรขึ้นกับรูปภาพหากฉันเปลี่ยนขนาดคอลัมน์/แถวหลังจากตั้งรูปภาพเป็นพื้นหลังของเซลล์?**

พฤติกรรมขึ้นอยู่กับ [fill mode](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) (stretch/tile). หากใช้การขยาย, รูปภาพจะปรับให้เข้ากับเซลล์ใหม่; หากใช้การปูกระเบียง, แผ่นลายจะถูกคำนวณใหม่.

**ฉันสามารถกำหนดไฮเปอร์ลิงก์ให้กับเนื้อหาทั้งหมดของเซลล์ได้หรือไม่?**

[Hyperlinks](/slides/th/cpp/manage-hyperlinks/) ถูกตั้งค่าในระดับข้อความ (portion) ภายในกรอบข้อความของเซลล์หรือในระดับของตาราง/รูปร่างทั้งหมด ในการใช้งานจริง คุณกำหนดลิงก์ให้กับส่วนหนึ่งหรือกับข้อความทั้งหมดในเซลล์.

**ฉันสามารถกำหนดแบบอักษรที่แตกต่างกันภายในเซลล์เดียวได้หรือไม่?**

ได้. กรอบข้อความของเซลล์รองรับ [portions](https://reference.aspose.com/slides/cpp/aspose.slides/portion/) (runs) ที่มีการจัดรูปแบบอิสระ—ฟอนต์, สไตล์, ขนาด, และสี.