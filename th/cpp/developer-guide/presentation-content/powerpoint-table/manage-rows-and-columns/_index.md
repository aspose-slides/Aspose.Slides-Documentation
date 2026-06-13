---
title: จัดการแถวและคอลัมน์ในตาราง PowerPoint ด้วย C++
linktitle: แถวและคอลัมน์
type: docs
weight: 20
url: /th/cpp/manage-rows-and-columns/
keywords:
- แถวของตาราง
- คอลัมน์ของตาราง
- แถวแรก
- ส่วนหัวของตาราง
- คัดลอกแถว
- คัดลอกคอลัมน์
- คัดลอกแถว
- คัดลอกคอลัมน์
- ลบแถว
- ลบคอลัมน์
- การจัดรูปแบบข้อความของแถว
- การจัดรูปแบบข้อความของคอลัมน์
- สไตล์ของตาราง
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "จัดการแถวและคอลัมน์ของตารางใน PowerPoint ด้วย Aspose.Slides สำหรับ C++ และเร่งการแก้ไขงานนำเสนอและอัปเดตข้อมูล."
---
## **บทนำ**

เพื่อให้คุณสามารถจัดการแถวและคอลัมน์ของตารางในงานนำเสนอ PowerPoint ได้ Aspose.Slides ให้บริการคลาส [Table](https://reference.aspose.com/slides/th/cpp/aspose.slides/table/) , อินเทอร์เฟซ [ITable](https://reference.aspose.com/slides/th/cpp/aspose.slides/itable/) และประเภทอื่น ๆ มากมาย

## **กำหนดแถวแรกเป็นส่วนหัว**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation) และโหลดงานนำเสนอ  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. สร้างอ็อบเจ็กต์ [ITable](https://reference.aspose.com/slides/th/cpp/aspose.slides/itable/) แล้วกำหนดค่าเป็น null  
4. วนลูปผ่านอ็อบเจ็กต์ [IShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/) ทั้งหมดเพื่อค้นหาตารางที่เกี่ยวข้อง  
5. ตั้งค่าแถวแรกของตารางเป็นส่วนหัวของตาราง  

โค้ด C++ นี้แสดงวิธีการตั้งค่าแถวแรกของตารางเป็นส่วนหัว:

```c++
// สร้างอินสแตนซ์ของคลาส Presentation 
auto pres = System::MakeObject<Presentation>(u"table.pptx");

// เข้าถึงสไลด์แรก
auto sld = pres->get_Slides()->idx_get(0);

// กำหนดค่าเริ่มต้น TableEx เป็น null
SharedPtr<ITable> tbl;

// วนลูปผ่านรูปร่างทั้งหมดและกำหนดอ้างอิงไปยังตาราง
for (const auto& shp : sld->get_Shapes())
{
    if (ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// กำหนดแถวแรกของตารางเป็นส่วนหัว 
tbl->set_FirstRow(true);
```

## **คัดลอกแถวหรือคอลัมน์ของตาราง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation) และโหลดงานนำเสนอ,  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. กำหนดอาเรย์ของ `columnWidth`  
4. กำหนดอาเรย์ของ `rowHeight`  
5. เพิ่มอ็อบเจ็กต์ [ITable](https://reference.aspose.com/slides/th/cpp/aspose.slides/itable/) ไปยังสไลด์ผ่านเมธอด [AddTable()](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapecollection/addtable/)  
6. คัดลอกแถวของตาราง  
7. คัดลอกคอลัมน์ของตาราง  
8. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ด C++ นี้แสดงวิธีการคัดลอกแถวหรือคอลัมน์ของตาราง PowerPoint:

```c++
 // เส้นทางไปยังไดเรกทอรีของเอกสาร.
const String outPath = u"../out/CloningInTable_out.pptx";

// สร้างอินสแตนซ์ของคลาส Presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// เข้าถึงสไลด์แรก
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// กำหนดคอลัมน์พร้อมความกว้างและแถวพร้อมความสูง
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// เพิ่มรูปร่างตารางลงในสไลด์
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// ตั้งค่ารูปแบบขอบสำหรับแต่ละเซลล์
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

table->idx_get(0, 0)->get_TextFrame()->set_Text(u"00");
table->idx_get(0, 1)->get_TextFrame()->set_Text(u"01");
table->idx_get(0, 2)->get_TextFrame()->set_Text(u"02");
table->idx_get(0, 3)->get_TextFrame()->set_Text(u"03");
table->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
table->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"11");
table->idx_get(2, 1)->get_TextFrame()->set_Text(u"21");

// AddClone เพิ่มแถวที่ส่วนท้ายของตาราง
table->get_Rows()->AddClone(table->get_Rows()->idx_get(0), false);

// InsertClone เพิ่มแถวที่ตำแหน่งเฉพาะในตาราง
table->get_Rows()->InsertClone(2, table->get_Rows()->idx_get(0), false);

// AddClone เพิ่มคอลัมน์ที่ส่วนท้ายของตาราง
table->get_Columns()->AddClone(table->get_Columns()->idx_get(0), false);

// InsertClone เพิ่มคอลัมน์ที่ตำแหน่งเฉพาะในตาราง
table->get_Columns()->InsertClone(2, table->get_Columns()->idx_get(0), false);


// บันทึกงานนำเสนอลงดิสก์
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **ลบแถวหรือคอลัมน์จากตาราง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation) และโหลดงานนำเสนอ,  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. กำหนดอาเรย์ของ `columnWidth`  
4. กำหนดอาเรย์ของ `rowHeight`  
5. เพิ่มอ็อบเจ็กต์ [ITable](https://reference.aspose.com/slides/th/cpp/aspose.slides/itable/) ไปยังสไลด์ผ่านเมธอด [AddTable()](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapecollection/addtable/)  
6. ลบแถวของตาราง  
7. ลบคอลัมน์ของตาราง  
8. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ด C++ นี้แสดงวิธีการลบแถวหรือคอลัมน์จากตาราง:

```c++
// เส้นทางไปยังไดเรกทอรีของเอกสาร.
const String outPath = u"../out/RemovingRowColumn_out.pptx";

// สร้างอินสแตนซ์ของคลาส Presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// เข้าถึงสไลด์แรก
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// กำหนดคอลัมน์พร้อมความกว้างและแถวพร้อมความสูง
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// เพิ่มรูปร่างตารางลงในสไลด์
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);

table->get_Rows()->RemoveAt(1, false);
table->get_Columns()->RemoveAt(1, false);


// รวมเซลล์ (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// รวมเซลล์ (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// บันทึกงานนำเสนอลงดิสก์
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **ตั้งค่าการจัดรูปแบบข้อความระดับแถวของตาราง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation) และโหลดงานนำเสนอ,  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. เข้าถึงอ็อบเจ็กต์ [ITable](https://reference.aspose.com/slides/th/cpp/aspose.slides/itable/) ที่เกี่ยวข้องจากสไลด์  
4. ตั้งค่า [set_FontHeight()](https://reference.aspose.com/slides/th/cpp/aspose.slides/baseportionformat/set_fontheight/) ของเซลล์แถวแรก  
5. ตั้งค่า [set_Alignment()](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/set_alignment/) และ [set_MarginRight()](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/set_marginright/) ของเซลล์แถวแรก  
6. ตั้งค่า [set_TextVerticalType()](https://reference.aspose.com/slides/th/cpp/aspose.slides/textframeformat/set_textverticaltype/) ของเซลล์แถวที่สอง  
7. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ด C++ นี้สาธิตการดำเนินการ

```c++
// สร้างอินสแตนซ์ของคลาส Presentation
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// สมมติว่ารูปร่างแรกในสไลด์แรกเป็นตาราง
// ตั้งค่าความสูงของแบบอักษรในเซลล์แถวแรก
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

// ตั้งค่าการจัดข้อความและระยะขอบขวาของเซลล์แถวแรก
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

// ตั้งค่าชนิดการจัดวางข้อความแนวตั้งของเซลล์แถวที่สอง
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

// บันทึกงานนำเสนอลงดิสก์
presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **ตั้งค่าการจัดรูปแบบข้อความระดับคอลัมน์ของตาราง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation) และโหลดงานนำเสนอ,  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. เข้าถึงอ็อบเจ็กต์ [ITable](https://reference.aspose.com/slides/th/cpp/aspose.slides/itable/) ที่เกี่ยวข้องจากสไลด์  
4. ตั้งค่า [set_FontHeight()](https://reference.aspose.com/slides/th/cpp/aspose.slides/baseportionformat/set_fontheight/) ของเซลล์คอลัมน์แรก  
5. ตั้งค่า [set_Alignment()](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/set_alignment/) และ [set_MarginRight()](https://reference.aspose.com/slides/th/cpp/aspose.slides/iparagraphformat/set_marginright/) ของเซลล์คอลัมน์แรก  
6. ตั้งค่า [set_TextVerticalType()](https://reference.aspose.com/slides/th/cpp/aspose.slides/textframeformat/set_textverticaltype/) ของเซลล์คอลัมน์ที่สอง  
7. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ด C++ นี้สาธิตการดำเนินการ: 

```c++
// สร้างอินสแตนซ์ของคลาส Presentation
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// สมมติว่ารูปร่างแรกในสไลด์แรกเป็นตาราง

// ตั้งค่าความสูงของแบบอักษรในเซลล์ของคอลัมน์แรก
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

// ตั้งค่าการจัดตำแหน่งข้อความและระยะขอบขวาของเซลล์คอลัมน์แรกในคำสั่งเดียว
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

// ตั้งค่าชนิดการจัดวางข้อความแนวตั้งของเซลล์คอลัมน์ที่สอง
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

pres->Save(u"result.pptx", SaveFormat::Pptx);
```

## **รับคุณสมบัติรูปแบบตาราง**

Aspose.Slides อนุญาตให้คุณดึงคุณสมบัติรูปแบบของตารางเพื่อที่คุณจะได้ใช้รายละเอียดเหล่านั้นกับตารางอื่นหรือที่อื่น โค้ด C++ นี้แสดงวิธีการรับคุณสมบัติรูปแบบจากสไตล์ตารางที่กำหนดล่วงหน้า:

```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Can I apply PowerPoint themes/styles to a table that’s already created?**

ได้ ตารางจะสืบทอดธีมของสไลด์/เลย์เอาต์/มาสเตอร์ และคุณยังสามารถเขียนทับการเติมสี, เส้นขอบ, และสีข้อความเหนือธีมนั้นได้

**Can I sort table rows like in Excel?**

ไม่ได้ ตารางของ Aspose.Slides ไม่มีการจัดเรียงหรือฟิลเตอร์ในตัว ให้คุณจัดเรียงข้อมูลในหน่วยความจำก่อน แล้วจึงเติมแถวของตารางใหม่ตามลำดับนั้น

**Can I have banded (striped) columns while keeping custom colors on specific cells?**

ได้ เปิดใช้งานคอลัมน์แบบมีแถบ แล้วเขียนทับเซลล์เฉพาะด้วยการจัดรูปแบบท้องถิ่น การจัดรูปแบบระดับเซลล์จะมีลำดับความสำคัญเหนือสไตล์ของตาราง