---
title: "การทำอัตโนมัติการสร้าง PowerPoint ใน C++: สร้างการนำเสนอแบบไดนามิกได้อย่างง่ายดาย"
linktitle: การทำอัตโนมัติการสร้าง PowerPoint
type: docs
weight: 20
url: /th/cpp/automating-powerpoint-generation-on-cloud-platforms/
keywords:
- แพลตฟอร์มคลาวด์
- ทำอัตโนมัติการสร้าง PowerPoint
- สร้างการนำเสนอแบบโปรแกรมเมติก
- การทำอัตโนมัติ PowerPoint
- การสร้างสไลด์แบบไดนามิก
- รายงานธุรกิจอัตโนมัติ
- การทำอัตโนมัติ PPT
- การนำเสนอ C++
- C++
- Aspose.Slides
description: "ทำอัตโนมัติการสร้างสไลด์บนแพลตฟอร์มคลาวด์ด้วย Aspose.Slides สำหรับ C++—สร้าง, แก้ไขและแปลงไฟล์ PowerPoint และ OpenDocument อย่างรวดเร็วและเชื่อถือได้"
---
## **บทนำ**

การสร้างงานนำเสนอ PowerPoint ด้วยตนเองอาจใช้เวลานานและทำซ้ำได้บ่อยโดยเฉพาะเมื่อเนื้อหาขึ้นอยู่กับข้อมูลแบบไดนามิกที่เปลี่ยนแปลงบ่อย ไม่ว่าจะเป็นการสร้างรายงานธุรกิจรายสัปดาห์ การจัดทำเนื้อหาการศึกษา หรือการผลิตชุดสไลด์ขายพร้อมใช้สำหรับลูกค้า การทำอัตโนมัติสามารถประหยัดชั่วโมงทำงานจำนวนมหาศาลและทำให้ทีมมีความสอดคล้องกัน

สำหรับนักพัฒนา C++ การทำอัตโนมัติการสร้างงานนำเสนอ PowerPoint เปิดโอกาสที่มีพลัง คุณสามารถรวมการสร้างสไลด์เข้าไปในพอร์ทัลเว็บ เครื่องมือเดสก์ท็อป เซอร์วิสแบ็กเอนด์ หรือแพลตฟอร์มคลาวด์เพื่อแปลงข้อมูลเป็นงานนำเสนอระดับมืออาชีพที่มีแบรนด์ได้ตามความต้องการ

ในบทความนี้ เราจะสำรวจกรณีการใช้งานทั่วไปสำหรับการสร้าง PowerPoint แบบอัตโนมัติในแอป C++ (รวมถึงการปรับใช้บนแพลตฟอร์มคลาวด์) และเหตุผลที่มันกำลังกลายเป็นคุณลักษณะที่สำคัญในโซลูชันสมัยใหม่ ตั้งแต่การดึงข้อมูลธุรกิจแบบเรียลไทม์จนถึงการแปลงข้อความหรือรูปภาพเป็นสไลด์ เป้าหมายคือการแปลงเนื้อหาดิบให้เป็นรูปแบบโครงสร้างและภาพที่ผู้ชมเข้าใจได้ทันที

## **กรณีการใช้ทั่วไปสำหรับการอัตโนมัติ PowerPoint ใน C++**

การทำอัตโนมัติการสร้าง PowerPoint มีประโยชน์เป็นพิเศษในสถานการณ์ที่ต้องประกอบเนื้อหาการนำเสนอแบบไดนามิก ปรับให้เป็นส่วนบุคคล หรืออัปเดตบ่อยที่สุดของกรณีการใช้จริง ได้แก่

- **รายงานธุรกิจและแดชบอร์ด**
  สร้างสรุปการขาย, KPI หรือรายงานผลการเงินโดยดึงข้อมูลสดจากฐานข้อมูลหรือ API

- **ชุดสไลด์การขายและการตลาดแบบส่วนตัว**
  สร้างชุดสไลด์นำเสนอเฉพาะลูกค้าโดยอัตโนมัติด้วยข้อมูล CRM หรือแบบฟอร์ม ทำให้การส่งมอบรวดเร็วและรักษาความสอดคล้องของแบรนด์

- **เนื้อหาการศึกษา**
  แปลงเนื้อหาการเรียนรู้, แบบทดสอบ หรือสรุปหลักสูตรเป็นชุดสไลด์โครงสร้างสำหรับแพลตฟอร์ม e‑learning

- **ข้อมูลและการสรุปเชิง AI**
  ใช้การประมวลผลภาษาธรรมชาติหรือเครื่องมือวิเคราะห์เพื่อแปลงข้อมูลดิบหรือข้อความยาวเป็นงานนำเสนอสรุป

- **สไลด์ที่ใช้สื่อเป็นหลัก**
  ประกอบงานนำเสนอจากภาพที่อัปโหลด, ภาพหน้าจอที่มีคำอธิบาย, หรือคีย์เฟรมวิดีโอพร้อมคำอธิบายสนับสนุน

- **การแปลงเอกสาร**
  แปลงเอกสาร Word, PDF หรือข้อมูลฟอร์มเป็นงานนำเสนอภาพโดยอัตโนมัติด้วยความพยายามคนละน้อยที่สุด

- **เครื่องมือนักพัฒนาและเทคนิค**
  สร้างการสาธิตเทคโนโลยี, ภาพรวมเอกสาร, หรือบันทึกการเปลี่ยนแปลงในรูปแบบสไลด์โดยตรงจากโค้ดหรือเนื้อหา markdown

โดยการทำอัตโนมัติของเวิร์กโฟลว์เหล่านี้ องค์กรสามารถขยายการสร้างเนื้อหา รักษาความสอดคล้อง และปลดปล่อยเวลาเพื่อทำงานเชิงกลยุทธ์เพิ่มเติม

## **มาทำโค้ดกัน**

สำหรับตัวอย่างนี้ เราได้เลือก **[Aspose.Slides for C++](https://products.aspose.com/slides/th/cpp/)** เพื่อสาธิตการทำอัตโนมัติ PowerPoint เนื่องจากมีชุดฟีเจอร์ที่ครบครันและใช้งานง่ายเมื่อต้องทำงานกับงานนำเสนอแบบเชิงโปรแกรม

ไม่เหมือนไลบรารีระดับล่างที่ต้องให้ผู้พัฒนาทำงานกับโครงสร้าง Open XML โดยตรง (ซึ่งมักทำให้โค้ดยืดยาวและอ่านยาก) Aspose.Slides ให้ API ระดับสูงที่ซ่อนความซับซ้อน ทำให้ผู้พัฒนามุ่งเน้นที่ตรรกะการนำเสนอ เช่น การจัดวาง, การฟอร์แมต, และการผูกข้อมูล โดยไม่ต้องเข้าใจรายละเอียดของรูปแบบไฟล์ PowerPoint

แม้ว่า Aspose.Slides จะเป็นไลบรารีเชิงพาณิชย์ แต่ก็มีรุ่น [free trial](https://releases.aspose.com/slides/th/cpp/) ที่สามารถใช้งานได้เต็มที่สำหรับรันตัวอย่างในบทความนี้ สำหรับการสาธิตแนวคิด, ทดสอบฟีเจอร์, หรือสร้าง proof of concept อย่างที่เรานำเสนอในนี้ รุ่นทดลองเพียงพออย่างมาก ซึ่งทำให้เป็นตัวเลือกที่สะดวกสำหรับทดลองทำการสร้าง PowerPoint แบบอัตโนมัติโดยไม่ต้องซื้อไลเซนส์ล่วงหน้า

ต่อไป เราจะเดินตามขั้นตอนการสร้างงานนำเสนอแบบตัวอย่างโดยใช้เนื้อหาแบบจริงจัง

### **สร้างสไลด์หัวเรื่อง**

เราจะเริ่มด้วยการสร้างงานนำเสนอใหม่และเพิ่มสไลด์หัวเรื่องที่มีหัวข้อหลักและคำนำ

```cpp
auto presentation = MakeObject<Presentation>();

auto slide0 = presentation->get_Slide(0);

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Title);
slide0->set_LayoutSlide(layoutSlide);

auto titleShape = ExplicitCast<IAutoShape>(slide0->get_Shape(0));
auto subtitleShape = ExplicitCast<IAutoShape>(slide0->get_Shape(1));

titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review – Q1 2025");
subtitleShape->get_TextFrame()->set_Text(u"Prepared for Executive Team");
```

![สไลด์หัวเรื่อง](slide_0.png)

### **เพิ่มสไลด์พร้อมแผนภูมิคอลัมน์**

ต่อไป เราจะสร้างสไลด์ที่แสดงผลการขายตามภูมิภาคในรูปแผนภูมิคอลัมน์

```cpp
auto layoutSlide1 = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto slide1 = presentation->get_Slides()->AddEmptySlide(layoutSlide1);

auto chart = slide1->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100, 100, 500, 350, false);
chart->get_Legend()->set_Position(LegendPositionType::Bottom);
chart->set_HasTitle(true);
chart->get_ChartTitle()->AddTextFrameForOverriding(u"Data from January – March 2025");
chart->get_ChartTitle()->set_Overlay(false);

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheetIndex = 0;

chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"North America")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Europe")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Asia Pacific")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 4, 0, ObjectExt::Box<String>(u"Latin America")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 5, 0, ObjectExt::Box<String>(u"Middle East")));

auto series = chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Sales ($K)")), chart->get_Type());
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box<int32_t>(480)));
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box<int32_t>(365)));
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box<int32_t>(290)));
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 4, 1, ObjectExt::Box<int32_t>(150)));
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 5, 1, ObjectExt::Box<int32_t>(120)));
```

![สไลด์ที่มีแผนภูมิ](slide_1.png)

### **เพิ่มสไลด์พร้อมตาราง**

ต่อไปเราจะเพิ่มสไลด์ที่แสดงเมตริกประสิทธิภาพสำคัญในรูปแบบตาราง

```cpp
auto layoutSlide2 = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto slide2 = presentation->get_Slides()->AddEmptySlide(layoutSlide2);

auto columnWidths = MakeArray<double>({ 200, 100 });
auto rowHeights = MakeArray<double>({ 40, 40, 40, 40, 40 });

auto table = slide2->get_Shapes()->AddTable(200, 200, columnWidths, rowHeights);
table->get_Column(0)->idx_get(0)->get_TextFrame()->set_Text(u"Metric");
table->get_Column(1)->idx_get(0)->get_TextFrame()->set_Text(u"Value");
table->get_Column(0)->idx_get(1)->get_TextFrame()->set_Text(u"Total Revenue");
table->get_Column(1)->idx_get(1)->get_TextFrame()->set_Text(u"$1.4M");
table->get_Column(0)->idx_get(2)->get_TextFrame()->set_Text(u"Gross Margin");
table->get_Column(1)->idx_get(2)->get_TextFrame()->set_Text(u"54%");
table->get_Column(0)->idx_get(3)->get_TextFrame()->set_Text(u"New Customers");
table->get_Column(1)->idx_get(3)->get_TextFrame()->set_Text(u"340");
table->get_Column(0)->idx_get(4)->get_TextFrame()->set_Text(u"Customer Retention");
table->get_Column(1)->idx_get(4)->get_TextFrame()->set_Text(u"87%");
```

![สไลด์ที่มีตาราง](slide_2.png)

### **เพิ่มสไลด์สรุปพร้อมรายการหัวข้อ**

สุดท้าย เราจะใส่สรุปและแผนการดำเนินการโดยใช้รายการหัวข้อแบบง่าย

```cpp
static SharedPtr<IParagraph> CreateBulletParagraph(String text) {
    auto paragraph = MakeObject<Paragraph>();
    paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
    paragraph->get_ParagraphFormat()->set_Indent(15);
    paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
    paragraph->set_Text(text);
    return paragraph;
}
```
```cpp
auto layoutSlide3 = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto slide3 = presentation->get_Slides()->AddEmptySlide(layoutSlide3);

auto bulletList = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 50, 600, 200);
bulletList->get_FillFormat()->set_FillType(FillType::NoFill);
bulletList->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

bulletList->get_TextFrame()->get_Paragraphs()->Clear();
bulletList->get_TextFrame()->get_Paragraphs()->Add(CreateBulletParagraph(u"Strong performance in North America; growth opportunity in Asia Pacific"));
bulletList->get_TextFrame()->get_Paragraphs()->Add(CreateBulletParagraph(u"Improve marketing outreach in underperforming regions"));
bulletList->get_TextFrame()->get_Paragraphs()->Add(CreateBulletParagraph(u"Prepare new campaign strategy for Q2"));
bulletList->get_TextFrame()->get_Paragraphs()->Add(CreateBulletParagraph(u"Schedule follow-up review in early July"));
```

![สไลด์ที่มีข้อความ](slide_3.png)

### **บันทึกงานนำเสนอ**

สุดท้าย เราบันทึกงานนำเสนอลงดิสก์:

```java
presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **สรุป**

การทำอัตโนมัติการสร้าง PowerPoint ในแอปพลิเคชัน C++ ให้ประโยชน์ที่ชัดเจนในการประหยัดเวลาและลดความพยายามแบบแมนนวล โดยการผสานเนื้อหาแบบไดนามิก เช่น แผนภูมิ, ตาราง, และข้อความ นักพัฒนาสามารถสร้างงานนำเสนอที่สอดคล้องและเป็นมืออาชีพได้อย่างรวดเร็ว — เหมาะสำหรับรายงานธุรกิจ การประชุมลูกค้า หรือเนื้อหาการศึกษา

ในบทความนี้ เราได้สาธิตวิธีทำอัตโนมัติการสร้างงานนำตั้งแต่เริ่มต้น รวมถึงการเพิ่มสไลด์หัวเรื่อง, แผนภูมิ, และตาราง วิธีการนี้สามารถนำไปใช้ในกรณีการใช้งานหลากหลายที่ต้องการงานนำเสนออัตโนมัติแบบขับเคลื่อนด้วยข้อมูล

ด้วยการใช้เครื่องมือที่เหมาะสม นักพัฒนา C++ สามารถทำอัตโนมัติการสร้าง PowerPoint อย่างมีประสิทธิภาพ เพิ่มประสิทธิภาพการทำงานและรักษาความสอดคล้องในงานนำเสนอทั้งหมด