---
title: จัดรูปแบบรูปร่าง PowerPoint ใน C++
linktitle: การจัดรูปแบบรูปร่าง
type: docs
weight: 20
url: /th/cpp/shape-formatting/
keywords:
- จัดรูปแบบรูปร่าง
- จัดรูปแบบเส้น
- เอฟเฟกต์สเก็ตช์
- เส้นรูปร่างสเก็ตช์
- จัดรูปแบบสไตล์การเชื่อมต่อ
- การเติมไล่สี
- การเติมลวดลาย
- การเติมรูปภาพ
- การเติมพื้นผิว
- การเติมสีทึบ
- ความโปร่งแสงของรูปร่าง
- การเรนเดอร์รูปร่างสีขาวดำ
- การเรนเดอร์รูปร่างสีเทา
- หมุนรูปร่าง
- เอฟเฟกต์บีเวล 3 มิติ
- เอฟเฟกต์การหมุน 3 มิติ
- รีเซ็ตการจัดรูปแบบ
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธีจัดรูปแบบรูปร่าง PowerPoint ใน C++ ด้วย Aspose.Slides—ตั้งค่าสไตล์การเติม, เส้น, และเอฟเฟกต์สำหรับไฟล์ PPT และ PPTX ด้วยความแม่นยำและการควบคุมเต็มที่"
---
## **บทนำ**

จัดรูปแบบรูปร่างใน PowerPoint โดยปรับเส้นขอบ การเติมสี และเอฟเฟกต์ต่างๆ Aspose.Slides for C++ ให้คุณควบคุมการตั้งค่าเหล่านี้ด้วยโปรแกรม รวมถึงความโปร่งแสง การหมุน และการจัดรูปแบบ 3 มิติ

![ตัวเลือกการจัดรูปแบบรูปร่างใน PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for C++ มีอินเทอร์เฟซและเมธอดที่ให้คุณจัดรูปแบบรูปร่างโดยใช้ตัวเลือกเดียวกับที่มีใน PowerPoint

## **จัดรูปแบบเส้น**

ใช้ [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) เพื่อควบคุมเส้นขอบของรูปร่าง ตัวอย่างนี้สร้างสี่เหลี่ยมผืนผ้าไม่มีการเติมสีที่มีเส้นขอบสีน้ำเงินแบบประจาย [ILineFormat::set_Style](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_style/) เลือกเส้นแบบผสมหนา‑บาง ในขณะที่ [ILineFormat::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_width/) กำหนดความกว้างเป็น 7 จุด และ [ILineFormat::set_DashStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_dashstyle/) เลือกรูปแบบเส้นประ

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LineDashStyle.h>
#include <DOM/LineStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![เส้นที่จัดรูปแบบในงานนำเสนอ](formatted-lines.png)

### **ตั้งค่าแพทเทิร์นเส้นประแบบกำหนดเอง**

ใช้ [ILineFormat::set_CustomDashPattern](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_customdashpattern/) เมื่อสไตล์เส้นที่กำหนดไว้ล่วงหน้าไม่ให้ความยาวและช่องว่างของเส้นประที่คุณต้องการ เช่น สำหรับเส้นขอบแบรนด์หรือแผนภาพเทคนิค การกำหนดแพทเทิร์นจะเปลี่ยนสไตล์เส้นประเป็นอัตโนมัติเป็น [LineDashStyle::Custom](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/)

รายการในอาเรย์สลับระหว่างความยาวของเส้นประและช่องว่าง โดยเริ่มจากเส้นประ ค่าต่าง ๆ เป็นหลายเท่าของความกว้างของเส้น: `{ 4, 2 }` ที่ความกว้าง 3 จุด จะให้เส้นประ 12 จุดตามด้วยช่องว่าง 6 จุด ใช้คู่ของค่าที่จำกัด ไม่เป็นลบเพื่อกำหนดส่วนเต็มของเส้นประ‑ช่องว่าง ตัวอย่างใช้ค่าบวกเพื่อให้เส้นประและช่องว่างทั้งหมดมองเห็นได้

ตัวอย่างนี้สร้างเส้นสีน้ำเงิน 5 เส้นที่มีความยาวและหัวเส้นแบบแบนเท่ากัน 3 เส้นแรกเปรียบเทียบแพทเทิร์นที่ความกว้าง 3 จุด เส้นที่สี่ทำซ้ำแพทเทิร์นแรกโดยเพิ่มความกว้างเป็นสองเท่า ทำให้ความยาวของเส้นประและช่องว่างเพิ่มขึ้นสองเท่า เส้นที่ห้าเปลี่ยนจากแพทเทิร์นกำหนดเองเป็นเส้นทึบ

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/LineCapStyle.h>
#include <DOM/LineDashStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <system/array.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(600, 300, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto patterns = std::array<ArrayPtr<float>, 5>{
    MakeArray<float>({ 4, 2 }),
    MakeArray<float>({ 1, 2 }),
    MakeArray<float>({ 6, 2, 1, 2 }),
    MakeArray<float>({ 4, 2 }),
    MakeArray<float>({ 4, 2 })
};

for (auto i = 0; i < patterns.size(); i++)
{
    auto line = slide->get_Shapes()->AddAutoShape(ShapeType::Line, 50, 50 + i * 50, 500, 0);
    line->get_LineFormat()->set_Width(i == 3 ? 6 : 3);
    line->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    line->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
    line->get_LineFormat()->set_CapStyle(LineCapStyle::Flat);
    line->get_LineFormat()->set_BeginArrowheadStyle(LineArrowheadStyle::None);
    line->get_LineFormat()->set_EndArrowheadStyle(LineArrowheadStyle::None);
    line->get_LineFormat()->set_CustomDashPattern(patterns[i]);
}

// เปลี่ยนเส้นสุดท้ายให้เป็นสไตล์เส้นทึบ.
slide->get_Shape(4)->get_LineFormat()->set_DashStyle(LineDashStyle::Solid);

presentation->Save(u"custom_dash_patterns.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

เพื่อกลับไปใช้สไตล์เส้นประที่กำหนดไว้ล่วงหน้า ให้ส่งค่า [LineDashStyle::Dash](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/) ไปยัง [ILineFormat::set_DashStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_dashstyle/) สไตล์ที่เลือกจะควบคุมลักษณะของเส้น

ผลลัพธ์ใน PowerPoint จากบนลงล่าง: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; และ **Solid, 3 pt**.

![สามแพทเทิร์นเส้นประแบบกำหนดเอง เส้นกว้างกว่าที่ใช้แพทเทิร์นแรก และเส้นทึบใน PowerPoint](custom-dash-patterns.png)


### **ตั้งค่าหัวเส้น**

ใช้ [ILineFormat::set_CapStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_capstyle/) เพื่อกำหนดหัวของเส้นเปิด การนับประเภท [LineCapStyle](https://reference.aspose.com/slides/cpp/aspose.slides/linecapstyle/) มีสามสไตล์หัวเส้นที่ชัดเจน:

- `Flat`: เส้นหยุดที่จุดสิ้นสุด
- `Round`: หัวเส้นแบบกึ่งวงกลมต่อออกจากจุดสิ้นสุดเป็นครึ่งความกว้างของเส้น
- `Square`: หัวเส้นสี่เหลี่ยมต่อออกจากจุดสิ้นสุดเป็นครึ่งความกว้างของเส้น

ค่านิยมยังรวม `NotDefined` ซึ่งหมายถึงไม่มีการกำหนดสไตล์หัวเส้นอย่างชัดเจน

หัวเส้นต่างจากหัวลูกศรที่เพิ่มสัญลักษณ์ที่ปลายเส้น และต่างจากการเชื่อมต่อที่ควบคุมมุมระหว่างส่วนของเส้น ตัวอย่างนี้ปิดการใช้หัวลูกศรผ่าน [ILineFormat::set_BeginArrowheadStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_beginarrowheadstyle/) และ [ILineFormat::set_EndArrowheadStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_endarrowheadstyle/) เพื่อให้เปรียบเทียบเฉพาะรูปทรงหัวเส้น

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/LineArrowheadStyle.h>
#include <DOM/LineCapStyle.h>
#include <DOM/LineDashStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(500, 240, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto capStyles = std::array<LineCapStyle, 3>{ LineCapStyle::Flat, LineCapStyle::Round, LineCapStyle::Square };

for (auto i = 0; i < capStyles.size(); i++)
{
    auto line = slide->get_Shapes()->AddAutoShape(ShapeType::Line, 100, 50 + i * 70, 300, 0);
    line->get_LineFormat()->set_Width(20);
    line->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    line->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
    line->get_LineFormat()->set_DashStyle(LineDashStyle::Solid);
    line->get_LineFormat()->set_CapStyle(capStyles[i]);
    line->get_LineFormat()->set_BeginArrowheadStyle(LineArrowheadStyle::None);
    line->get_LineFormat()->set_EndArrowheadStyle(LineArrowheadStyle::None);
}

presentation->Save(u"line_caps.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์ใน PowerPoint จากบนลงล่าง: **Flat**, **Round**, และ **Square**.

![หัวเส้นแบน, โค้ง, และสี่เหลี่ยมบนเส้นหนาแบบเดียวกันใน PowerPoint](line-caps.png)

## **ใช้เอฟเฟกต์สเก็ตช์กับเส้นของรูปร่าง**

เอฟเฟกต์สเก็ตช์ทำให้เส้นของรูปร่างดูเหมือนวาดด้วยมือ ใช้ [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) เพื่อเข้าถึงการตั้งค่าเส้น, [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/get_sketchformat/) เพื่อเข้าถึงการตั้งค่าสเก็ตช์, และ [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/set_sketchtype/) เพื่อเลือกค่าจากการนับประเภท [LineSketchType](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/)

โค้ด C++ ต่อไปนี้แสดงวิธีใช้เอฟเฟกต์ [LineSketchType::Curved](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/) อ่านค่าที่กำหนดอย่างชัดเจน และลบเอฟเฟกต์ด้วย [LineSketchType::None](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/):

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISketchFormat.h>
#include <DOM/ISlide.h>
#include <DOM/LineSketchType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

auto sketchFormat = shape->get_LineFormat()->get_SketchFormat();
sketchFormat->set_SketchType(LineSketchType::Curved);
auto explicitSketchType = sketchFormat->get_SketchType();
Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);
sketchFormat->set_SketchType(LineSketchType::None);

presentation->Dispose();
```

ค่าที่คืนจาก [ISketchFormat::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/get_sketchtype/) แสดงการตั้งค่าที่กำหนดโดยตรงให้กับรูปร่าง หากการจัดรูปแบบเส้นสามารถสืบทอดจากธีม, มาสเตอร์สไลด์, หรือเลย์เอาต์สไลด์ ให้ใช้ [ILineFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/geteffective/), เข้าถึง [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/), และอ่านค่า [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/) ค่าที่มีประสิทธิผลจะสะท้อนการจัดรูปแบบที่ใช้จริงหลังจากการสืบทอดถูกแก้ไข ตัวอย่างนี้ต้องมีงานนำเสนอที่มีอย่างน้อยหนึ่งรูปร่างบนสไลด์แรกและพิมพ์ค่าทั้งสอง:

```cpp
#include <DOM/ILineFormat.h>
#include <DOM/ILineFormatEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/ISketchFormat.h>
#include <DOM/ISketchFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/LineSketchType.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto lineFormat = shape->get_LineFormat();
auto explicitSketchType = lineFormat->get_SketchFormat()->get_SketchType();
auto effectiveLineFormat = lineFormat->GetEffective();
auto effectiveSketchType = effectiveLineFormat->get_SketchFormat()->get_SketchType();

Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);
Console::WriteLine(u"Effective sketch type: {0}", effectiveSketchType);
presentation->Dispose();
```

## **จัดรูปแบบสไตล์การเชื่อมต่อ**

นี่คือสามตัวเลือกประเภทการเชื่อมต่อ:

* Round
* Miter
* Bevel

สไตล์การเชื่อมต่อกำหนดว่าตัวแบ่งของเส้นสองส่วนมาบรรจบกันอย่างไรที่มุม ใช้ **Round** สำหรับมุมโค้ง, **Miter** สำหรับมุมคม, หรือ **Bevel** สำหรับมุมเรียบ

![สไตล์การเชื่อมต่อในงานนำเสนอ](join-style-powerpoint.png)

ตัวอย่างนี้สร้างสี่เหลี่ยมสีดำ 3 รูปที่มีเส้นขอบสีน้ำเงินกว้าง 15 จุด โดยตั้งค่า [ILineFormat::set_JoinStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_joinstyle/) ให้เป็นค่า miter, bevel, และ round ของ [LineJoinStyle](https://reference.aspose.com/slides/cpp/aspose.slides/linejoinstyle/) ตามลำดับ เพื่อเปรียบเทียบการวาดมุม

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LineJoinStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto miterShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto bevelShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto roundShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

miterShape->get_FillFormat()->set_FillType(FillType::Solid);
miterShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
bevelShape->get_FillFormat()->set_FillType(FillType::Solid);
bevelShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
roundShape->get_FillFormat()->set_FillType(FillType::Solid);
roundShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

miterShape->get_LineFormat()->set_Width(15);
bevelShape->get_LineFormat()->set_Width(15);
roundShape->get_LineFormat()->set_Width(15);

miterShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
miterShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
bevelShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
bevelShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
roundShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
roundShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

miterShape->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
bevelShape->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
roundShape->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

miterShape->get_TextFrame()->set_Text(u"Miter Join Style");
bevelShape->get_TextFrame()->set_Text(u"Bevel Join Style");
roundShape->get_TextFrame()->set_Text(u"Round Join Style");

presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **จำกัดการเชื่อมต่อแบบ Miter ที่มุมแหลม**

ใช้ [ILineFormat::set_MiterLimit](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_miterlimit/) ร่วมกับ [ILineFormat::set_JoinStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_joinstyle/) ที่ตั้งเป็น [LineJoinStyle::Miter](https://reference.aspose.com/slides/cpp/aspose.slides/linejoinstyle/) เพื่อจำกัดระยะที่มุมแหลมสามารถขยายได้

ขีดจำกัดเป็นอัตราส่วนของระยะห่างระหว่างมุมในและนอกของการเชื่อมต่อต่อความกว้างของเส้น ตัวอย่างเช่น ค่า `8` อนุญาตให้ความยาวของมิตเตอร์สูงสุดได้ถึงแปดเท่าของความกว้างเส้น; ไม่ได้เป็นหน่วยจุด หากมุมเกินขีดจำกัด PowerPoint จะใช้การเชื่อมต่อแบบ bevel ที่มุมนั้น ขีดจำกัดที่ใหญ่ขึ้นจะทำให้จุดคมขึ้น การตั้งค่านี้มีผลต่อการเชื่อมต่อแบบ miter เท่านั้น และการเปลี่ยนแปลงจะไม่มีผลต่อมุมที่ยังอยู่ภายในขีดจำกัดทั้งสอง

ตัวอย่างนี้สร้างสองสามเหลี่ยมไม่มีการเติมสีที่มีเส้นขอบกว้าง 20 จุด สามเหลี่ยมซ้ายใช้ขีดจำกัด `2` และสามเหลี่ยมขวาใช้ `8` แต่ละสามเหลี่ยมกว้าง 80 จุด สูง 160 จุด ทำให้มุมบนมีอัตราส่วนความยาวมิตเตอร์ต่อความกว้างเส้นประมาณ `4.12` ดังนั้น PowerPoint จะ bevel จุดยอดซ้ายและคงจุดยอดขวาไว้

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/LineJoinStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(500, 320, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto miterLimits = std::array<float, 2>{ 2.0f, 8.0f };

for (auto i = 0; i < miterLimits.size(); i++)
{
    auto triangle = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 90 + i * 240, 110, 80, 160);
    triangle->get_FillFormat()->set_FillType(FillType::NoFill);
    triangle->get_LineFormat()->set_Width(20);
    triangle->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    triangle->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
    triangle->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
    triangle->get_LineFormat()->set_MiterLimit(miterLimits[i]);
}

presentation->Save(u"miter_limits.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์ใน PowerPoint: **Miter limit 2** ทางซ้ายและ **miter limit 8** ทางขวา.

![จุดยอด bevel ที่มี miter limit 2 และจุดยอดคมที่มี miter limit 8 ใน PowerPoint](miter-limits.png)

## **การเติมไล่สี**

การเติมไล่สีผสมสีทั่วทั้งรูปร่าง ตัวอย่างนี้เติมวงรีด้วยไล่สีเชิงเส้นที่มุม 45° จากสีแดงไปสีม่วงโดยใช้ [IFillFormat::get_GradientFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_gradientformat/). เมธอด [IGradientStopCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides/igradientstopcollection/add/) วางจุดหยุดสีที่ 0 และ 1 ซึ่งเป็นจุดเริ่มและจบของไล่สี การล้างจุดหยุดเดิมทำให้ใช้เฉพาะสองสีนี้

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/PresetColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);
shape->get_FillFormat()->get_GradientFormat()->set_LinearGradientAngle(45);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Clear();
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![วงรีที่เติมไล่สี](gradient-fill.png)

หากไล่สีแสดงผลต่างกันในภาพที่ส่งออกเทียบกับ PowerPoint ให้ดูที่ [Choose a Gradient Rendering Style](/slides/th/cpp/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) คุณสามารถเลือกสไตล์การเรนเดอร์โดยไม่ต้องเปลี่ยนการเติมไล่สีที่บันทึกไว้ในงานนำเสนอ

### **ตั้งค่าองศาไล่สีเชิงเส้น**

ใช้ [IGradientFormat::set_LinearGradientAngle](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_lineargradientangle/) เพื่อควบคุมการวางแนวของการเติม [GradientShape::Linear](https://reference.aspose.com/slides/cpp/aspose.slides/gradientshape/) องศาวัดเป็นระดับและเพิ่มตามเข็มนานาเข็ม: `0` จากซ้ายไปขวา, `90` จากบนลงล่าง, `180` จากขวาไปซ้าย, `270` จากล่างขึ้นบน. รองรับองศาเศษส่วน องศาที่อยู่นอกช่วง `[0, 360)` จะถูกทำให้เป็นหนึ่งรอบ; ตัวอย่างเช่น `-45` จะเป็น `315` และ `360` จะเป็น `0`

ตัวอย่างนี้สร้างสี่เหลี่ยม 6 รูปที่มีจุดหยุดสีแดง, เขียว, น้ำเงินเดียวกันที่ตำแหน่ง `0`, `0.5`, และ `1`. ปิดการสเกลเพื่อให้เปรียบเทียบองศาโดยไม่ขึ้นกับสัดส่วนของสี่เหลี่ยม องศาตั้งแต่ซ้ายไปขวาในแถวแรกคือ `0`, `45`, `90` และในแถวที่สองคือ `135`, `180`, `270`

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 400, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto angles = std::array<float, 6>{ 0, 45, 90, 135, 180, 270 };

for (auto i = 0; i < angles.size(); i++)
{
    auto x = 30 + (i % 3) * 230;
    auto y = 30 + (i / 3) * 190;

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, x, y, 200, 150);
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_FillFormat()->set_FillType(FillType::Gradient);

    auto gradient = shape->get_FillFormat()->get_GradientFormat();
    gradient->set_GradientShape(GradientShape::Linear);
    gradient->get_GradientStops()->Clear();
    gradient->get_GradientStops()->Add(0.0f, Color::get_Red());
    gradient->get_GradientStops()->Add(0.5f, Color::get_Lime());
    gradient->get_GradientStops()->Add(1.0f, Color::get_Blue());
    gradient->set_LinearGradientScaled(NullableBool::False);
    gradient->set_LinearGradientAngle(angles[i]);
}

presentation->Save(u"linear_gradient_angles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์ใน PowerPoint:

![ไล่สีเชิงเส้นที่ 0°, 45°, 90° ในแถวบน, และ 135°, 180°, 270° ในแถวล่าง](linear-gradient-angles.png)

### **ปรับขนาดไล่สีเชิงเส้นตามรูปร่าง**

[IGradientFormat::set_LinearGradientScaled](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_lineargradientscaled/) รับค่า [NullableBool](https://reference.aspose.com/slides/cpp/aspose.slides/nullablebool/) กำหนดเป็น `False` อย่างชัดเจนเพื่อคงองศาไล่สีเชิงทรงเรขาคณิตเมื่อรูปร่างเปลี่ยนสัดส่วน, หรือกำหนดเป็น `True` เพื่อสเกลไล่สีตามความกว้างและความสูงของรูปร่าง เมื่อเปิดสเกลแล้วองศาที่มองเห็นอาจแตกต่างจากองศาที่กำหนดบนรูปร่างที่ไม่เป็นสี่เหลี่ยมจัตุรัส

ตัวอย่างต่อไปนี้ใช้มุม `45`° และจุดหยุดสีเดียวกันกับการเปรียบเทียบองศา คอลัมน์ซ้ายใช้ `False`; คอลัมน์ขวาใช้ `True`. แต่ละคอลัมน์มีสี่เหลี่ยมกว้างด้านบนและสี่เหลี่ยมสูงด้านล่าง ทั้งสองเริ่มด้วยขนาดกว้างเดียวกัน; การเปลี่ยนความกว้างและความสูงของสี่เหลี่ยมที่สองแสดงให้เห็นว่าการเติมตอบสนองอย่างไรต่อการปรับขนาดโดยไม่ต้องเปลี่ยนการตั้งค่าไล่สี

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 460, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

const auto scalingOptions = std::array<NullableBool, 2>{ NullableBool::False, NullableBool::True };

for (auto column = 0; column < scalingOptions.size(); column++)
{
    for (auto row = 0; row < 2; row++)
    {
        auto x = 30 + column * 360;
        auto y = row == 0 ? 30 : 150;

        auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, x, y, 300, 90);
        shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
        shape->get_FillFormat()->set_FillType(FillType::Gradient);

        auto gradient = shape->get_FillFormat()->get_GradientFormat();
        gradient->set_GradientShape(GradientShape::Linear);
        gradient->get_GradientStops()->Clear();
        gradient->get_GradientStops()->Add(0.0f, Color::get_Red());
        gradient->get_GradientStops()->Add(0.5f, Color::get_Lime());
        gradient->get_GradientStops()->Add(1.0f, Color::get_Blue());
        gradient->set_LinearGradientAngle(45);
        gradient->set_LinearGradientScaled(scalingOptions[column]);

        if (row == 1)
        {
            shape->set_Width(90);
            shape->set_Height(280);
        }
    }
}

presentation->Save(u"linear_gradient_scaling.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์ใน PowerPoint, โดยซ้ายไม่มีสเกลและขวามีสเกล:

![สี่เหลี่ยมกว้างและสี่เหลี่ยมสูงที่มีไล่สี 45°, เปรียบเทียบ LinearGradientScaled False ด้ายกับ True ขวา](linear-gradient-scaling.png)

เมื่อปิดสเกล แถบสีทแยงมุมคงทิศทางเดียวกันในทั้งสองสี่เหลี่ยม เมื่อเปิดสเกล แถบสีจะยืดตามสัดส่วนของรูปร่าง สิ่งนี้ช่วยให้ทำสำเนาไล่สีของเทมเพลตเมื่อปรับรูปร่างให้มีขนาดต่างกัน บนสี่เหลี่ยมจัตุรัส การเปิดสเกลไม่เปลี่ยนลักษณะของไล่สี `45`° นี้

ทั้งองศาและการตั้งค่าสเกลใช้กับไล่สีเชิงเส้นเท่านั้น ไม่ควบคุมการเติม [GradientShape::Radial or GradientShape::Rectangle](https://reference.aspose.com/slides/cpp/aspose.slides/gradientshape/)

### **รวมองศากับทิศทางไล่สี**

[IGradientFormat::set_GradientDirection](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_gradientdirection/) เลือกสไตล์ไล่สีจากการนับประเภท [GradientDirection](https://reference.aspose.com/slides/cpp/aspose.slides/gradientdirection/) ซึ่งไม่ใช่การแทนที่ด้วยองศาตัวเลข สำหรับไล่สีเชิงเส้น ทิศทางมุมสามารถเปลี่ยนพื้นที่ที่สีกระจายโดยไม่เปลี่ยนองศาที่กำหนดผ่าน [IGradientFormat::set_LinearGradientAngle](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_lineargradientangle/) ให้คงทิศทางไว้เมื่อเปรียบเทียบองศาหรือสเกล

ตัวอย่างต่อไปนี้ใช้การตั้งค่าเดียวกันแต่เรียงลำดับต่างกัน สี่เหลี่ยมสองรูปจะมีลักษณะเดียวกัน: การกำหนดทิศทางก่อนหรือหลังการกำหนดองศาจะไม่เปลี่ยนผลลัพธ์

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientDirection.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

for (auto i = 0; i < 2; i++)
{
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 30 + i * 140, 320, 100);
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_FillFormat()->set_FillType(FillType::Gradient);

    auto gradient = shape->get_FillFormat()->get_GradientFormat();
    gradient->set_GradientShape(GradientShape::Linear);
    gradient->get_GradientStops()->Clear();
    gradient->get_GradientStops()->Add(0.0f, Color::get_Red());
    gradient->get_GradientStops()->Add(0.5f, Color::get_Lime());
    gradient->get_GradientStops()->Add(1.0f, Color::get_Blue());
    gradient->set_LinearGradientScaled(NullableBool::True);

    if (i == 0)
    {
        gradient->set_GradientDirection(GradientDirection::FromCorner1);
        gradient->set_LinearGradientAngle(30);
    }
    else
    {
        gradient->set_LinearGradientAngle(30);
        gradient->set_GradientDirection(GradientDirection::FromCorner1);
    }
}

presentation->Save(u"linear_gradient_direction.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **การเติมด้วยลวดลาย**

การเติมด้วยลวดลายใช้การออกแบบสองสี เช่น จุด, เส้น, หรือช่องสี ตัวอย่างนี้ใช้ [IPatternFormat::set_PatternStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/set_patternstyle/) เพื่อเลือกลวดลาย trellis. [IPatternFormat::get_BackColor](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_backcolor/) กำหนดพื้นหลังสีเทอ่อน, และ [IPatternFormat::get_ForeColor](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_forecolor/) กำหนดสีเหลืองสำหรับลวดลาย

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPatternFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_FillFormat()->set_FillType(FillType::Pattern);
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![สี่เหลี่ยมที่เติมด้วยลวดลาย](pattern-fill.png)

## **การเติมด้วยรูปภาพ**

การเติมด้วยรูปภาพใช้รูปภาพภายในรูปร่าง ตัวอย่างนี้ต้องการรูปภาพในเครื่องและใช้ [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/) เพื่อโหลดเข้าสู่คอลเลคชันรูปภาพของงานนำเสนอ ตั้งค่า [IPictureFillFormat::set_PictureFillMode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/) เป็นโหมด tiled เพื่อทำซ้ำรูปภาพภายในสี่เหลี่ยม ภาพต้นฉบับที่ใช้แสดงด้านล่าง:

![รูปดอกบัว](lotus.png)

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);
shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

auto image = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(image);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(presentationImage);

presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
image->Dispose();
presentation->Dispose();
```

ผลลัพธ์:

![รูปร่างที่เติมด้วยรูปภาพ](picture-fill.png)

### **ทำรูปภาพเป็นลายกระเบื้องเป็นพื้นผิว**

หากต้องการตั้งรูปภาพเป็นลายกระเบื้องเป็นพื้นผิวและปรับพฤติกรรมการกระเบื้อง คุณสามารถใช้เมธอดต่อไปนี้ของอินเทอร์เฟซ [IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/) และคลาส [PictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/):

- [set_PictureFillMode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): ตั้งโหมดการเติมรูปภาพ—หรือ `Tile` หรือ `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): กำหนดการจัดตำแหน่งของกระเบื้องภายในรูปร่าง.
- [set_TileFlip](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileflip/): ควบคุมว่ากระเบื้องจะแปลงแนวนอน แนวตั้ง หรือทั้งสองอย่าง.
- [set_TileOffsetX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): ตั้งค่าการเยื้องแนวนอนของกระเบื้อง (หน่วยเป็นจุด) จากจุดกำเนิดของรูปร่าง.
- [set_TileOffsetY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): ตั้งค่าการเยื้องแนวตั้งของกระเบื้อง (หน่วยเป็นจุด) จากจุดกำเนิดของรูปร่าง.
- [set_TileScaleX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): กำหนดสเกลแนวนอนของกระเบื้องเป็นเปอร์เซ็นต์.
- [set_TileScaleY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): กำหนดสเกลแนวตั้งของกระเบื้องเป็นเปอร์เซ็นต์.

ตัวอย่างนี้ต้องการรูปภาพในเครื่องและกำหนดให้ [IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/) ทำซ้ำที่ขนาด 50% ของขนาดดั้งเดิม การเยื้อง −32 จุดทำให้กระเบื้องเลื่อนแนวนอนและแนวตั้ง; การจัดตำแหน่ง bottom‑right และการพลิกทั้งสองทิศทางกำหนดวิธีการจัดเรียงลายกระเบื้องที่ทำซ้ำ

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto firstSlide = presentation->get_Slide(0);

auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);
shape->get_FillFormat()->set_FillType(FillType::Picture);

auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);

auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

presentation->Save(u"tile.pptx", SaveFormat::Pptx);
sourceImage->Dispose();
presentation->Dispose();
```

ผลลัพธ์:

![ตัวเลือกการกระเบื้อง](tile-options.png)

## **การเติมสีทึบ**

การเติมสีทึบให้รูปร่างสีเดียวที่สม่ำเสมอ ตัวอย่างนี้ตั้งค่า [IFillFormat::set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) ให้เป็นโหมดเติมสีทึบและกำหนดสีเหลืองผ่าน [IFillFormat::get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/), แล้วบันทึกสี่เหลี่ยมในงานนำเสนอ

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![รูปร่างที่เติมสีทึบ](solid-color-fill.png)

## **ใช้พื้นหลังสไลด์เป็นการเติมของรูปร่าง**

ใช้ [IAutoShape::set_UseBackgroundFill](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/set_usebackgroundfill/) เมื่อรูปร่างควรตรงกับพื้นหลังสไลด์ เช่น ในเทมเพลตงานนำเสนอ ตั้งค่า [IFillFormat::set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) เป็น [FillType::NotDefined](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) ก่อนเพื่อเอาการเติมที่กำหนดไว้ล่วงหน้าออก ด้วยการผสมนี้รูปร่างจะใช้พื้นหลังสไลด์แทนการเติมสไตล์ของมันเอง การเปิดใช้แฟลกเพียงอย่างเดียวจะไม่ลบการเติมที่กำหนดไว้แล้ว

ส่วนนี้แตกต่างจาก [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/): การเติมพื้นหลังจะคลุมวัตถุที่อยู่หลังรูปร่างด้วยพื้นที่ของพื้นหลังสไลด์, ในขณะที่ NoFill ทำให้วัตถุเหล่านั้นมองเห็นได้ การไล่สียังคงจัดแนวกับสไลด์แทนที่จะเริ่มใหม่ภายในแต่ละรูปร่าง

ตัวอย่างต่อไปนี้สร้างพื้นหลังมาสเตอร์ที่สไลด์สืบทอดและวางแถบสีม่วงด้านหลังสามสี่เหลี่ยม สี่เหลี่ยมซ้ายใช้พื้นหลัง, สี่เหลี่ยมกลางไม่มีการเติม, และสี่เหลี่ยมขวาเปลี่ยนจากการเติมพื้นหลังเป็นการเติมสีส้มที่กำหนดอย่างชัดเจน

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 400, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

// สืบทอดไล่สีจากมาสเตอร์.
slide->get_Background()->set_Type(BackgroundType::NotDefined);
slide->get_LayoutSlide()->get_Background()->set_Type(BackgroundType::NotDefined);
auto background = slide->get_LayoutSlide()->get_MasterSlide()->get_Background();
background->set_Type(BackgroundType::OwnBackground);
background->get_FillFormat()->set_FillType(FillType::Gradient);
auto gradient = background->get_FillFormat()->get_GradientFormat();
gradient->set_GradientShape(GradientShape::Linear);
gradient->set_LinearGradientAngle(0);
gradient->get_GradientStops()->Clear();
gradient->get_GradientStops()->Add(0, Color::get_DarkBlue());
gradient->get_GradientStops()->Add(1, Color::get_LightSkyBlue());

// เพิ่มอ็อบเจกต์นี้ก่อนเพื่อให้แสดงด้านหลังสี่เหลี่ยม.
auto band = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 25, 150, 670, 100);
band->get_FillFormat()->set_FillType(FillType::Solid);
band->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Magenta());
band->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

auto backgroundShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 100, 160, 200);
backgroundShape->get_FillFormat()->set_FillType(FillType::NotDefined);
backgroundShape->set_UseBackgroundFill(true);

auto noFillShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 280, 100, 160, 200);
noFillShape->get_FillFormat()->set_FillType(FillType::NoFill);

auto explicitShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 510, 100, 160, 200);
explicitShape->get_FillFormat()->set_FillType(FillType::NotDefined);
explicitShape->set_UseBackgroundFill(true);

// ปิดการเติมพื้นหลังก่อนใช้การเติมแบบกำหนดเอง.
explicitShape->set_UseBackgroundFill(false);
explicitShape->get_FillFormat()->set_FillType(FillType::Solid);
explicitShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

presentation->Save(u"background_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์จากซ้ายไปขวา: **background fill**, **no fill**, และ **explicit fill**. แถบสีม่วงถูกซ่อนโดยสี่เหลี่ยมซ้ายและขวาแต่ยังคงมองเห็นผ่านสี่เหลี่ยมกลาง

![การเติมพื้นหลัง, ไม่มีการเติม, และการเติมสีส้มอย่างชัดเจนเหนือแถบสีม่วง](background-fill.png)

พฤติกรรมเดียวกันใช้กับพื้นหลังที่กำหนดโดยตรงบนสไลด์หรือสืบทอดจากเลย์เอาต์ รูปร่างจะใช้พื้นหลังที่แก้ไขแล้วของสไลด์; ตัวอย่างนี้ทิ้งให้ทั้งพื้นหลังสไลด์และเลย์เอาต์ไม่ได้กำหนดเพื่อให้มาสเตอร์เป็นแหล่งที่มา

## **ตั้งค่าความโปร่งแสง**

สำหรับการเติมสีทึบ ส่วนประกอบอัลฟ่า (alpha) ของสีควบคุมความทึบ: 0 เป็นโปร่งแสงเต็ม, 255 เป็นทึบเต็ม ตัวอย่างนี้ใช้ค่าอัลฟ่า 128 สำหรับสี่เหลี่ยมสีเหลือง ทำให้เป็นโปร่งแสงประมาณ 50% เพื่อให้สี่เหลี่ยมด้านล่างมองเห็นได้ สีถูกกำหนดผ่าน [IFillFormat::get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/)

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

const int alpha = 128;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, Color::get_Yellow()));

presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![รูปร่างที่โปร่งแสง](shape-transparency.png)

## **หมุนรูปร่าง**

ใช้ [IShape::set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_rotation/) เพื่อหมุนรูปร่างบนระนาบสไลด์ องศาวัดเป็นระดับ; ตัวอย่างนี้หมุนสี่เหลี่ยม 5° ตามเข็มนานาเข็มและบันทึกงานนำเสนอ

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->set_Rotation(5);

presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![การหมุนรูปร่าง](shape-rotation.png)

## **เพิ่มเอฟเฟกต์บีเวล 3 มิติ**

ใช้ [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/) เพื่อให้รูปร่างมีความลึกและขอบบีเวล ตัวอย่างนี้สร้างวงรีสีเขียวที่มีเส้นขอบสีส้ม ตั้งค่า [IThreeDFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_depth/) เป็น 4 จุด และใช้บีเวลด้านบนแบบวงกลมที่กว้างและสูง 6 จุดผ่าน [IThreeDFormat::get_BevelTop](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_beveltop/) กล้องออร์โธกราฟิกหน้าและการให้แสงแบบสามจุดทำให้บีเวลมองเห็นได้

```cpp
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);
shape->get_ThreeDFormat()->set_Depth(4);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![เอฟเฟกต์บีเวล 3 มิติ](3D-bevel-effect.png)

## **เพิ่มเอฟเฟกต์การหมุน 3 มิติ**

มุมมอง 3 มิติของรูปร่างควบคุมโดยการตั้งค่ากล้อง ตัวอย่างนี้ใช้ [ICamera::SetRotation](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/setrotation/) กับค่า latitude, longitude, และ revolution ที่ 40°, 35°, และ 20° ตามลำดับ เลือกกล้องอิซอเมตริกผ่าน [ICamera::set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/) และแสงแบบสมดุลผ่าน [ILightRig::set_LightType](https://reference.aspose.com/slides/cpp/aspose.slides/ilightrig/set_lighttype/) แล้วบันทึกสี่เหลี่ยมที่จัดรูปแบบ

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
autoShape->get_TextFrame()->set_Text(u"Hello, Aspose!");
autoShape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
autoShape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
autoShape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![เอฟเฟกต์การหมุน 3 มิติ](3D-rotation-effect.png)

## **ควบคุมการแสดงผลสีขาว‑ดำสำหรับรูปร่าง**

เมธอด [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_blackwhitemode/) ระบุว่ารูปร่างแต่ละอันจะเรนเดอร์อย่างไรเมื่อดูหรือประมวลผลงานนำเสนอในโหมดสีขาว‑ดำ มันไม่ได้เปิดใช้งานการแสดงผลสีขาว‑ดำโดยอัตโนมัติและไม่เปลี่ยนการเติม, เส้น, หรือการจัดรูปแบบอื่น ๆ ของรูปร่างในโหมดสีปกติ

ใช้ค่าจากการนับประเภท [BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/blackwhitemode/) เพื่อเลือกพฤติกรรมที่ต้องการ ตัวอย่างเช่น `Automatic` ให้แอปพลิเคชันเลือกการแปลง, `Gray` และ `LightGray` ใช้สีเทา, `BlackWhite` ใช้เฉพาะสีดำและสีขาว, `Black` และ `White` บังคับให้เป็นสีเดียว, `Color` รักษาสีปกติ, `Hidden` ไม่แสดงรูปร่างในโหมดสีขาว‑ดำ, `NotDefined` หมายถึงไม่มีการกำหนดโหมดระดับรูปร่าง

ตัวอย่างนี้สร้างสี่เหลี่ยมสีส้มและตั้งค่า [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_blackwhitemode/) เป็นสีเทา รูปร่างที่บันทึกจะคงการเติมสีส้มสำหรับการแสดงผลสีปกติและขอให้แอปพลิเคชันใช้สีเทาเมื่อแสดงผลในโหมดสีขาว‑ดำ

```cpp
#include <DOM/BlackWhiteMode.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->set_BlackWhiteMode(BlackWhiteMode::Gray);

presentation->Save(u"shape_black_white_mode.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ในโหมดสีปกติ สี่เหลี่ยมคงสีส้มไว้ ในขั้นตอนการแสดงผลสีขาว‑ดำ มันจะใช้สีเทาเพราะโหมดตั้งเป็น `Gray` สิ่งนี้ช่วยให้คุณคงสไลด์สีเต็มเมือกำหนดลักษณะเฉพาะสำหรับการพิมพ์, ดูตัวอย่าง, หรือกระบวนการอื่น ๆ ที่เคารพการตั้งค่าแสดงผลสีขาว‑ดำของงานนำเสนอ

## **รีเซ็ตการจัดรูปแบบ**

ใช้ [ISlide::Reset](https://reference.aspose.com/slides/cpp/aspose.slides/islide/reset/) เพื่อคืนค่าตำแหน่ง, ขนาด, และการจัดรูปแบบของส่วนเติมเต็มในสไลด์จากส่วนเติมเต็มในเลย์เอาต์ที่สอดคล้องกัน ตัวอย่างนี้ต้องมีงานนำเสนอที่มีส่วนเติมเต็มเชื่อมโยงกับเลย์เอาต์และรีเซ็ตทุกสไลด์ก่อนบันทึก รูปร่างที่ไม่มีส่วนเติมเต็มที่สอดคล้องกันในเลย์เอาต์จะไม่ถูกรีเซ็ต

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
for (auto&& slide : IterateOver(presentation->get_Slides()))
{
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **คำถามที่พบบ่อย**

**การจัดรูปแบบรูปร่างมีผลต่อขนาดไฟล์งานนำเสนอสุดท้ายหรือไม่?**

สี, สไตล์เส้น, และการตั้งค่าเอฟเฟกต์ทั่วไปเพิ่มข้อมูลเพียงเล็กน้อยเมื่อเปรียบเทียบกับรูปภาพและสื่อที่ฝังอยู่ การเติมรูปภาพอาจเพิ่มขนาดไฟล์เนื่องจากรูปภาพถูกเก็บไว้ในงานนำเสนอ

**ฉันจะตรวจจับรูปร่างบนสไลด์ที่มีการจัดรูปแบบเดียวกันเพื่อจะรวมกลุ่มได้อย่างไร?**

เปรียบเทียบคุณสมบัติการจัดรูปแบบหลักของแต่ละรูปร่าง—การเติม, เส้น, และการตั้งค่าเอฟเฟกต์ หากค่าทุกค่าตรงกัน ให้ถือว่าสไตล์เดียวกันและจัดกลุ่มรูปร่างเหล่านั้นอย่างมีตรรกะ ซึ่งจะทำให้การจัดการสไตล์ในภายหลังง่ายขึ้น

**ฉันสามารถบันทึกชุดสไตล์รูปร่างแบบกำหนดเองไว้ในไฟล์แยกเพื่อใช้ซ้ำในงานนำเสนออื่นได้หรือไม่?**

ได้. เก็บรูปร่างตัวอย่างที่มีสไตล์ที่ต้องการในเทมเพลตสไลด์หรือไฟล์เทมเพลต .POTX. เมื่อสร้างงานนำเสนอใหม่ ให้เปิดเทมเพลต, คัดลอกรูปร่างที่สไตล์ไว้ที่ต้องการ, แล้วนำไปใช้ใหม่ตามที่ต้องการ