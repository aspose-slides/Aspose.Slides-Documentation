---
title: จัดการเซลล์ตารางในงานนำเสนอโดยใช้ C++
linktitle: จัดการเซลล์
type: docs
weight: 30
url: /th/cpp/manage-cells/
keywords:
- เซลล์ตาราง
- รวมเซลล์
- ลบเส้นขอบ
- แยกเซลล์
- รูปภาพในเซลล์
- สีพื้นหลัง
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "จัดการเซลล์ตารางใน PowerPoint อย่างง่ายดายด้วย Aspose.Slides สำหรับ C++. เรียนรู้การเข้าถึง, แก้ไข, และจัดรูปแบบเซลล์อย่างรวดเร็วเพื่อการทำอัตโนมัติของสไลด์ที่ราบรื่น."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณเข้าถึงและแก้ไขเซลล์ตารางในงานนำเสนอ PowerPoint บทความนี้อธิบายวิธีระบุเซลล์ตารางที่รวมกัน การลบเส้นขอบเซลล์ การจัดการเลขลำดับของเซลล์หลังจากการรวมหรือแยกเซลล์ การเปลี่ยนสีพื้นหลังของเซลล์ และการเพิ่มรูปภาพภายในเซลล์ตาราง ตัวอย่างแสดงวิธีสร้างหรือเปิดงานนำเสนอ รับตารางจากสไลด์ ปรับรูปแบบเซลล์ผ่านคุณสมบัติของเซลล์ และบันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

## **ระบุเซลล์ที่รวมกัน**
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation).
2. รับตารางจากสไลด์แรก. 
3. วนซ้ำผ่านแถวและคอลัมน์ของตารางเพื่อค้นหาเซลล์ที่รวมกัน.
4. พิมพ์ข้อความเมื่อพบเซลล์ที่รวมกัน.

โค้ด C++ นี้แสดงวิธีระบุเซลล์ตารางที่รวมกันในงานนำเสนอ:

``` cpp
auto pres = System::MakeObject<Presentation>(u"SomePresentationWithTable.pptx");
auto table = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// assuming that Slide#0.Shape#0 is a table
for (int32_t i = 0; i < table->get_Rows()->get_Count(); i++)
{
    for (int32_t j = 0; j < table->get_Columns()->get_Count(); j++)
    {
        auto currentCell = table->get_Rows()->idx_get(i)->idx_get(j);
        if (currentCell->get_IsMergedCell())
        {
            Console::WriteLine(String::Format(u"Cell {0};{1} is a part of merged cell with RowSpan={2} and ColSpan={3} starting from Cell {4};{5}.", 
                i, j, currentCell->get_RowSpan(), currentCell->get_ColSpan(), currentCell->get_FirstRowIndex(), currentCell->get_FirstColumnIndex()));
        }
    }
}
```

## **ลบเส้นขอบเซลล์ตาราง**
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation).
2. รับอ้างอิงสไลด์ผ่านดัชนี. 
3. กำหนดอาร์เรย์ของคอลัมน์พร้อมความกว้าง.
4. กำหนดอาร์เรย์ของแถวพร้อมความสูง.
5. เพิ่มตารางลงในสไลด์ผ่านเมธอด `AddTable`.
6. วนซ้ำผ่านทุกเซลล์เพื่อลบเส้นขอบด้านบน, ล่าง, ขวา, และซ้าย.
7. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

โค้ด C++ นี้แสดงวิธีลบเส้นขอบจากเซลล์ตาราง:

``` cpp
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์ PPTX
auto pres = MakeObject<Presentation>();
// เข้าถึงสไลด์แรก
auto sld = pres->get_Slides()->idx_get(0);

// กำหนดคอลัมน์ด้วยความกว้างและแถวด้วยความสูง
auto dblCols = MakeArray<double>({ 50, 50, 50, 50 });
auto dblRows = MakeArray<double>({ 50, 30, 30, 30, 30 });

// เพิ่มรูปร่างตารางลงในสไลด์
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// ตั้งค่ารูปแบบเส้นขอบสำหรับแต่ละเซลล์
for (const auto& row : System::IterateOver(tbl->get_Rows()))
{
    for (const auto& cell : System::IterateOver(row))
    {
        cell->get_CellFormat()->get_BorderTop()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderRight()->get_FillFormat()->set_FillType(FillType::NoFill);
    }
}

// บันทึกไฟล์ PPTX ไปยังดิสก์
pres->Save(u"table_out.pptx", SaveFormat::Pptx);
```

## **การทำเลขลำดับในเซลล์ที่รวมกัน**

หากเรารวมเซลล์ 2 คู่ (1, 1) x (2, 1) และ (1, 2) x (2, 2) ตารางที่ได้จะมีการจัดลำดับเลข. โค้ด C# นี้แสดงกระบวนการ:

```c++
const String outPath = u"../out/MergeCells_out.pptx";

// โหลดงานนำเสนอที่ต้องการ
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// เข้าถึงสไลด์แรก
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// กำหนดคอลัมน์ด้วยความกว้างและแถวด้วยความสูง
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// เพิ่มรูปร่างตารางลงในสไลด์
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// ตั้งค่ารูปแบบเส้นขอบสำหรับแต่ละเซลล์
for (int x = 0; x < table->get_Rows()->get_Count(); x++)
{
    SharedPtr<IRow> row = table->get_Rows()->idx_get(x);
    for (int y = 0; y < row->get_Count(); y++)
    {
        SharedPtr<ICell> cell = row->idx_get(y);

        cell->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderTop()->set_Width(5);

        cell->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderBottom()->set_Width(5);

        cell->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderLeft()->set_Width(5);

        cell->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderRight()->set_Width(5);

    }

}
// รวมเซลล์ (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// รวมเซลล์ (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// บันทึกไฟล์ PPTX ไปยังดิสก์
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

จากนั้นเราจะรวมเซลล์เพิ่มเติมโดยการรวม (1, 1) และ (1, 2) ผลลัพธ์คือตารางที่มีเซลล์รวมขนาดใหญ่ตรงกลาง: 

```c++
// พาธไปยังไดเรกทอรีของเอกสาร
const String outPath = u"../out/MergeCells_out.pptx";

// โหลดงานนำเสนอที่ต้องการ
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// เข้าถึงสไลด์แรก
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// กำหนดคอลัมน์ด้วยความกว้างและแถวด้วยความสูง
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// เพิ่มรูปร่างตารางลงในสไลด์
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// ตั้งค่ารูปแบบเส้นขอบสำหรับแต่ละเซลล์
for (int x = 0; x < table->get_Rows()->get_Count(); x++)
{
    SharedPtr<IRow> row = table->get_Rows()->idx_get(x);
    for (int y = 0; y < row->get_Count(); y++)
    {
        SharedPtr<ICell> cell = row->idx_get(y);

        cell->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderTop()->set_Width(5);

        cell->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderBottom()->set_Width(5);

        cell->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderLeft()->set_Width(5);

        cell->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderRight()->set_Width(5);

    }

}

// รวมเซลล์ (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// รวมเซลล์ (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// บันทึกไฟล์ PPTX ไปยังดิสก์
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **การทำเลขลำดับในเซลล์ที่แยกออก**

ในตัวอย่างก่อนหน้าเมื่อเซลล์ตารางถูกรวมกัน ระบบการจัดลำดับหรือเลขในเซลล์อื่นไม่ได้เปลี่ยนแปลง. ครั้งนี้เราจะใช้ตารางปกติ (ตารางที่ไม่มีเซลล์ที่รวม) แล้วลองแยกเซลล์ (1,1) เพื่อให้ได้ตารางที่พิเศษ คุณอาจต้องใส่ใจการจัดลำดับเลขของตารางนี้ซึ่งอาจดูแปลก แต่เป็นวิธีที่ Microsoft PowerPoint จัดลำดับเลขเซลล์ตารางและ Aspose.Slides ทำเช่นเดียวกัน. 

โค้ด C++ นี้แสดงกระบวนการที่อธิบายไว้:

```c++
// พาธไปยังไดเรกทอรีของเอกสาร.
const String outPath = u"../out/CellSplit_out.pptx";

// โหลดงานนำเสนอที่ต้องการ
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// เข้าถึงสไลด์แรก
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// กำหนดคอลัมน์ด้วยความกว้างและแถวด้วยความสูง
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// เพิ่มรูปร่างตารางลงในสไลด์
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// ตั้งค่ารูปแบบเส้นขอบสำหรับแต่ละเซลล์
for (int x = 0; x < table->get_Rows()->get_Count(); x++)
{
    SharedPtr<IRow> row = table->get_Rows()->idx_get(x);
    for (int y = 0; y < row->get_Count(); y++)
    {
        SharedPtr<ICell> cell = row->idx_get(y);

        cell->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderTop()->set_Width(5);

        cell->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderBottom()->set_Width(5);

        cell->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderLeft()->set_Width(5);

        cell->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cell->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        cell->get_BorderRight()->set_Width(5);

    }

}

// รวมเซลล์ (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// รวมเซลล์ (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);

// แยกเซลล์ (1, 1). 
table->idx_get(1, 1)->SplitByWidth(table->idx_get(2, 1)->get_Width() / 2);

// บันทึกไฟล์ PPTX ไปยังดิสก์
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **เปลี่ยนสีพื้นหลังของเซลล์ตาราง**

โค้ด C++ นี้แสดงวิธีเปลี่ยนสีพื้นหลังของเซลล์ตาราง:

``` cpp

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
auto dblCols = System::MakeArray<double>({150, 150, 150, 150});
auto dblRows = System::MakeArray<double>({50, 50, 50, 50, 50});
        
// สร้างตารางใหม่
auto table = slide->get_Shapes()->AddTable(50.0f, 50.0f, dblCols, dblRows);
        
// set the background color for a cell 
System::SharedPtr<ICell> cell = table->idx_get(2, 3);
cell->get_CellFormat()->get_FillFormat()->set_FillType(Aspose::Slides::FillType::Solid);
cell->get_CellFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        
presentation->Save(u"cell_background_color.pptx", Aspose::Slides::Export::SaveFormat::Pptx);

```

## **เพิ่มรูปภาพภายในเซลล์ตาราง**
1. สร้างอินสแตนซ์ของคลาส `Presentation`.
2. รับอ้างอิงสไลด์ผ่านดัชนี.
3. กำหนดอาร์เรย์ของคอลัมน์พร้อมความกว้าง.
4. กำหนดอาร์เรย์ของแถวพร้อมความสูง.
5. เพิ่มตารางลงในสไลด์ผ่านเมธอด `AddTable`. 
6. สร้างอ็อบเจกต์ `Bitmap` เพื่อเก็บไฟล์ภาพ.
7. เพิ่มภาพบิตแมพลงในอ็อบเจกต์ `IPPImage`.
8. ตั้งค่า `FillFormat` ของเซลล์ตารางเป็น `Picture`.
9. เพิ่มภาพลงในเซลล์แรกของตาราง.
10. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด C# นี้แสดงวิธีใส่รูปภาพภายในเซลล์ตารางเมื่อสร้างตาราง:

```c++
// พาธไปยังไดเรกทอรีของเอกสาร.
const String outPath = u"../out/Image_In_TableCell_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// โหลดงานนำเสนอที่ต้องการ
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// เข้าถึงสไลด์แรก
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// กำหนดคอลัมน์ด้วยความกว้างและแถวด้วยความสูง
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 150);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 100);
System::ArrayPtr<double> total_for_Cat = System::MakeObject<System::Array<double>>(5, 0);

// เพิ่มรูปร่างตารางลงในสไลด์
auto tbl = islide->get_Shapes()->AddTable(50, 50, dblCols, dblRows);

// ดึงรูปภาพ
auto img = Images::FromFile(ImagePath);

// เพิ่มรูปภาพลงในคอลเลกชันรูปภาพของงานนำเสนอ
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(img);


// เพิ่มรูปภาพลงในเซลล์ตารางแรก
tbl->idx_get(0, 0)->get_FillFormat()->set_FillType(FillType::Picture);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(imgx);

// บันทึกไฟล์ PPTX ไปยังดิสก์
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **FAQ**

**ฉันสามารถกำหนดความหนาและสไตล์ของเส้นต่างกันสำหรับด้านแต่ละด้านของเซลล์เดียวได้ไหม?**

ได้. เส้นขอบ [top](https://reference.aspose.com/slides/th/cpp/aspose.slides/cellformat/get_bordertop/)/[bottom](https://reference.aspose.com/slides/th/cpp/aspose.slides/cellformat/get_borderbottom/)/[left](https://reference.aspose.com/slides/th/cpp/aspose.slides/cellformat/get_borderleft/)/[right](https://reference.aspose.com/slides/th/cpp/aspose.slides/cellformat/get_borderright/) มีคุณสมบัติเพียกัน ทำให้ความหนาและสไตล์ของแต่ละด้านสามารถแตกต่างกันได้ นี้สอดคล้องกับการควบคุมเส้นขอบแบบแยกด้านสำหรับเซลล์ที่แสดงในบทความ.

**เกิดอะไรขึ้นกับภาพหากฉันเปลี่ยนขนาดคอลัมน์/แถวหลังจากตั้งรูปภาพเป็นพื้นหลังของเซลล์?**

พฤติกรรมขึ้นกับ [fill mode](https://reference.aspose.com/slides/th/cpp/aspose.slides/picturefillmode/) (stretch/tile) หากกำหนดให้ขยายภาพจะปรับให้เข้ากับเซลล์ใหม่; หากกำหนดให้ทำกระเบื้องภาพจะถูกคำนวณใหม่ บทความกล่าวถึงโหมดการแสดงผลของภาพในเซลล์.

**ฉันสามารถกำหนดไฮเปอร์ลิงก์ให้กับเนื้อหาทั้งหมดของเซลล์ได้หรือไม่?**

[Hyperlinks](/slides/th/cpp/manage-hyperlinks/) ถูกกำหนดที่ระดับข้อความ (portion) ภายในเฟรมข้อความของเซลล์หรือที่ระดับของตาราง/รูปร่างทั้งหมด ในการใช้งานจริงคุณจะกำหนดลิงก์ให้กับส่วนหนึ่งหรือให้กับข้อความทั้งหมดในเซลล์.

**ฉันสามารถตั้งฟอนต์ที่แตกต่างกันภายในเซลล์เดียวได้หรือไม่?**

ได้. เฟรมข้อความของเซลล์สนับสนุน [portions](https://reference.aspose.com/slides/th/cpp/aspose.slides/portion/) (runs) ที่มีการจัดรูปแบบอิสระ—แบบอักษร, สไตล์, ขนาด, และสี.