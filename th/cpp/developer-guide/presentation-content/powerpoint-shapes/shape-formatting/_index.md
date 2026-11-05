---
title: จัดรูปแบบรูปร่าง PowerPoint ใน C++
linktitle: การจัดรูปแบบรูปร่าง
type: docs
weight: 20
url: /th/cpp/shape-formatting/
keywords:
- จัดรูปแบบรูปร่าง
- จัดรูปแบบเส้น
- เอฟเฟ็กต์สเก็ตช์
- เส้นรูปร่างสเก็ตช์
- จัดรูปแบบสไตล์การเชื่อมต่อ
- การเติมสีไล่ระดับ
- การเติมลวดลาย
- การเติมรูปภาพ
- การเติมพื้นผิว
- การเติมสีทึบ
- ความโปร่งแสงของรูปร่าง
- การเรนเดอร์รูปร่างขาว-ดำ
- การเรนเดอร์รูปร่างระดับสีเทา
- หมุนรูปร่าง
- เอฟเฟ็กต์เบเวล 3D
- เอฟเฟ็กต์การหมุน 3D
- รีเซ็ตการจัดรูปแบบ
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธีจัดรูปแบบรูปร่าง PowerPoint ใน C++ ด้วย Aspose.Slides—ตั้งค่าการเติม, เส้น, และสไตล์เอฟเฟ็กต์สำหรับไฟล์ PPT และ PPTX ด้วยความแม่นยำและการควบคุมเต็มรูปแบบ."
---
## **บทนำ**

จัดรูปแบบรูปร่างใน PowerPoint โดยการปรับเส้นขอบ, การเติมสี, และเอฟเฟ็กต์ต่างๆ Aspose.Slides for C++ ช่วยให้คุณควบคุมการตั้งค่าเหล่านี้ด้วยโปรแกรม, รวมถึงความโปร่งใส, การหมุน, และการจัดรูปแบบ 3D

![ตัวเลือกการจัดรูปแบบรูปร่างใน PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for C++ ให้ส่วนติดต่อและเมธอดที่ทำให้คุณสามารถจัดรูปแบบรูปร่างได้โดยใช้ตัวเลือกเดียวกับที่มีใน PowerPoint

## **จัดรูปแบบเส้น**

ใช้ [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) เพื่อควบคุมเส้นขอบของรูปร่าง ตัวอย่างนี้สร้างสี่เหลี่ยมผืนผ้าไม่มีการเติมสีที่มีเส้นขอบสีน้ำเงินเป็นเส้นประ   [ILineFormat::set_Style](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_style/) เลือกเส้นสไตล์หนา-บางแบบผสม, ในขณะที่ [ILineFormat::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_width/) ตั้งความกว้างเป็น 7 จุดและ [ILineFormat::set_DashStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_dashstyle/) เลือกรูปแบบเส้นประ

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

### **ตั้งค่ารูปแบบเส้นประแบบกำหนดเอง**

ใช้ [ILineFormat::set_CustomDashPattern](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_customdashpattern/) เมื่อสไตล์เส้นที่กำหนดไว้ล่วงหน้าไม่ให้ความยาวและช่องว่างที่ต้องการ, เช่นสำหรับเส้นขอบแบรนด์หรือแผนภาพเทคนิค การกำหนดรูปแบบจะเปลี่ยนสไตล์เส้นเป็น [LineDashStyle::Custom](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/)

ค่าที่อยู่ในอาร์เรย์สลับระหว่างความยาวของเส้นและช่องว่าง เริ่มจากเส้น ความยาวแต่ละค่าเป็นหลายเท่าของความกว้างเส้น: `{ 4, 2 }` ที่ความกว้าง 3 จุดจะให้เส้น 12 จุดตามด้วยช่องว่าง 6 จุด ใช้คู่ค่าที่เป็นจำนวนจริง, ไม่เป็นลบเพื่อกำหนดส่วนเส้นและช่องว่างอย่างสมบูรณ์ ตัวอย่างใช้ค่าเป็นบวกเพื่อให้ทุกเส้นและช่องว่างมองเห็นได้

ตัวอย่างนี้สร้างเส้นสีน้ำเงิน 5 เส้นที่มีความยาวเท่าเดิมและปลายเส้นแบบแบน 3 เส้นแรกเปรียบเทียบรูปแบบที่ความกว้าง 3 จุด เส้นที่สี่ทำซ้ำรูปแบบแรกโดยเพิ่มความกว้างเป็นสองเท่า ทำให้เส้นและช่องว่างยาวสองเท่า เส้นที่ห้าสลับจากรูปแบบกำหนดเองเป็นเส้นทึบ

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

// Return the last line to a solid style.
slide->get_Shape(4)->get_LineFormat()->set_DashStyle(LineDashStyle::Solid);

presentation->Save(u"custom_dash_patterns.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

หากต้องการกลับไปใช้สไตล์เส้นประที่กำหนดไว้ล่วงหน้า ให้ส่ง [LineDashStyle::Dash](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/) ไปยัง [ILineFormat::set_DashStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_dashstyle/) สไตล์ที่เลือกจะควบคุมลักษณะของเส้น

ผลลัพธ์ใน PowerPoint ตั้งแต่บนลงล่าง: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; และ **Solid, 3 pt**

![สามรูปแบบเส้นประกำหนดเอง, เส้นกว้างกว่าโดยใช้รูปแบบแรก, และเส้นทึบใน PowerPoint](custom-dash-patterns.png)


### **ตั้งค่าปลายเส้น**

ใช้ [ILineFormat::set_CapStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_capstyle/) เพื่อกำหนดปลายของเส้นเปิด  [LineCapStyle](https://reference.aspose.com/slides/cpp/aspose.slides/linecapstyle/) มีสามสไตล์ปลายที่ชัดเจน:

- `Flat`: ฝุ่นหยุดที่จุดสิ้นสุด
- `Round`: ปลายรูปครึ่งวงกลมยืดออกเกินจุดสิ้นสุดครึ่งความกว้างเส้น
- `Square`: ปลายสี่เหลี่ยมยืดออกเกินจุดสิ้นสุดครึ่งความกว้างเส้น

นอกจากนี้ยังมี `NotDefined` ที่หมายความว่าไม่มีการกำหนดสไตล์ปลายอย่างชัดเจน

ปลายเส้นต่างจากหัวศูลที่เพิ่มสัญลักษณ์ที่ปลายเส้นและการเชื่อมต่อที่ควบคุมมุมระหว่างส่วนเส้น ตัวอย่างนี้ปิดหัวศูลด้วย [ILineFormat::set_BeginArrowheadStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_beginarrowheadstyle/) และ [ILineFormat::set_EndArrowheadStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_endarrowheadstyle/) เพื่อให้เปรียบเทียบเฉพาะรูปแบบปลาย

ตัวอย่างต่อไปนี้สร้างเส้นแนวนอนสามเส้นที่เหมือนกัน, ความกว้าง 20 จุด ตั้งแต่บนลงล่างใช้ปลาย Flat, Round, และ Square ตามลำดับ จุดสิ้นสุดของเส้นแต่ละเส้นมีพิกัดแนวนอนเดียวกัน; ปลาย Round และ Square ยืดออกเกิน 10 จุดจากแต่ละจุดสิ้นสุด

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

ผลลัพธ์ใน PowerPoint ตั้งแต่บนลงล่าง: **Flat**, **Round**, และ **Square**

![ปลาย Flat, Round, และ Square บนเส้นหนาเดียวกันใน PowerPoint](line-caps.png)

## **ใช้เอฟเฟ็กต์สเก็ตช์กับเส้นรูปร่าง**

เอฟเฟ็กต์สเก็ตช์ทำให้เส้นรูปร่างดูเหมือนถูกวาดด้วยมือ ใช้ [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) เพื่อเข้าถึงการตั้งค่าเส้น, [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/get_sketchformat/) เพื่อเข้าถึงการตั้งค่าสเก็ตช์, และ [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/set_sketchtype/) เพื่อเลือกค่าจาก enumeration [LineSketchType](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/)

โค้ด C++ ต่อไปนี้แสดงการใช้เอฟเฟ็กต์ [LineSketchType::Curved](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/) อ่านค่าที่กำหนดโดยชัดเจน, และลบเอฟเฟ็กต์ด้วย [LineSketchType::None](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/):

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

ค่าที่คืนจาก [ISketchFormat::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/get_sketchtype/) แสดงการตั้งค่าที่กำหนดโดยตรงให้กับรูปร่าง หากการจัดรูปแบบเส้นอาจสืบทอดจากธีม, สไลด์แม่, หรือสไลด์เค้าโครง, ใช้ [ILineFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/geteffective/), เข้าถึง [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/), แล้วอ่าน [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/) ค่าที่มีผลจะแสดงการจัดรูปแบบที่ถูกนำไปใช้จริงหลังจากการสืบทอดเสร็จ ตัวอย่างนี้ต้องการงานนำเสนอที่มีอย่างน้อยหนึ่งรูปร่างบนสไลด์แรกและพิมพ์ค่าทั้งสอง:

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

ตัวเลือกสไตล์การเชื่อมต่อสามแบบ:

* Round
* Miter
* Bevel

สไตล์การเชื่อมต่อควบคุมการต่อกันของสองส่วนขอบที่มุม ใช้ **Round** สำหรับมุมโค้ง, **Miter** สำหรับมุมคม, หรือ **Bevel** สำหรับมุมเรียบ

![สไตล์การเชื่อมต่อในงานนำเสนอ](join-style-powerpoint.png)

ตัวอย่างนี้สร้างสี่เหลี่ยมสีดำ 3 รูปที่มีเส้นขอบสีน้ำเงินกว้าง 15 จุด ตั้งค่า [ILineFormat::set_JoinStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_joinstyle/) เป็นค่า miter, bevel, และ round ของ [LineJoinStyle](https://reference.aspose.com/slides/cpp/aspose.slides/linejoinstyle/) เพื่อตรวจสอบวิธีที่มุมถูกวาด

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

### **จำกัด Miter ที่มุมคม**

ใช้ [ILineFormat::set_MiterLimit](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_miterlimit/) พร้อมกับ [ILineFormat::set_JoinStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_joinstyle/) ตั้งเป็น [LineJoinStyle::Miter](https://reference.aspose.com/slides/cpp/aspose.slides/linejoinstyle/) เพื่อจำกัดระยะที่มุมคมสามารถยืดออกได้

ค่าจำกัดเป็นอัตราส่วนของระยะห่างระหว่างมุมในและนอกของการเชื่อมต่อต่อความกว้างเส้น ตัวอย่างเช่น ค่า `8` อนุญาตให้ความยาวมิตเตอร์ยาวได้ถึงแปดเท่าของความกว้างเส้น; ไม่ได้เป็นหน่วยจุด หากมุมเกินขีดจำกัด PowerPoint จะใช้การเชื่อมต่อแบบ bevel ที่มุมนั้น ขีดจำกัดที่ใหญ่ขึ้นทำให้จุดคมมากขึ้น การตั้งค่านี้มีผลต่อการเชื่อมต่อแบบ miter เท่านั้น, การเปลี่ยนแปลงไม่มีผลต่อการแสดงผลเมื่อมุมยังอยู่ในขอบเขตของทั้งสองขีดจำกัด

ตัวอย่างนี้สร้างสามเหลี่ยมไม่มีการเติมสีสองรูปที่เหมือนกัน, เส้นขอบกว้าง 20 จุด สามเหลี่ยมซ้ายใช้ขีดจำกัด `2`, ขวาใช้ `8` แต่ละสามเหลี่ยมกว้าง 80 จุด สูง 160 จุด ทำให้อัตราส่วนความยาวมิตเตอร์ต่อความกว้างเส้นของมุมบนประมาณ `4.12` ผลลัพธ์ PowerPoint: มิตเตอร์ลิมิต 2 ทางซ้ายและมิตเตอร์ลิมิต 8 ทางขวา

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

ผลลัพธ์ใน PowerPoint: **Miter limit 2** ทางซ้ายและ **miter limit 8** ทางขวา

![ยอด bevel ด้วยมิตเตอร์ลิมิต 2 และยอดแหลมด้วยมิตเตอร์ลิมิต 8 ใน PowerPoint](miter-limits.png)

## **เติมสีไล่ระดับ (Gradient Fill)**

การเติมสีไล่ระดับผสานสีทั่วรูปร่าง ตัวอย่างนี้เติมรูปวงรีด้วยไล่สีเชิงเส้นที่มุม 45 องศาจากสีแดงไปสีม่วงโดยใช้ [IFillFormat::get_GradientFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_gradientformat/)  วิธี [IGradientStopCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides/igradientstopcollection/add/) จะใส่จุดหยุดสีที่ 0 และ 1, จุดเริ่มต้นและจบของไล่สี การลบจุดหยุดเดิมทำให้ใช้สีสองสีนี้เท่านั้น

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

หากไล่สีแสดงผลต่างกันในภาพที่ส่งออกเมื่อเทียบกับ PowerPoint, ดูที่ [Choose a Gradient Rendering Style](/slides/th/cpp/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) คุณสามารถเลือกสไตล์การเรนเดอร์โดยไม่ต้องเปลี่ยนไล่สีที่เก็บในงานนำเสนอ

### **ตั้งค่ามุมไล่สีเชิงเส้น**

ใช้ [IGradientFormat::set_LinearGradientAngle](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_lineargradientangle/) เพื่อควบคุมทิศทางของการเติม [GradientShape::Linear](https://reference.aspose.com/slides/cpp/aspose.slides/gradientshape/) มุมวัดเป็นองศาและเพิ่มตามเข็มนาฬิกา: `0` จากซ้ายไปขวา, `90` จากบนลงล่าง, `180` จากขวาไปซ้าย, `270` จากล่างขึ้นบน มุมที่เป็นเศษส่วนก็รองรับ มุมที่อยู่นอกช่วง `[0, 360)` จะทำให้เป็นมุมรอบหนึ่งครบ เช่น `-45` กลายเป็น `315` และ `360` กลายเป็น `0`

ตัวอย่างนี้สร้างสี่เหลี่ยม 6 รูปที่มีจุดหยุดสีแดง, เขียว, น้ำเงินที่ตำแหน่ง `0`, `0.5`, และ `1` เท่ากัน การสเกลถูกปิดเพื่อให้เปรียบเทียบมุมโดยไม่พิจารณาอัตราส่วนของสี่เหลี่ยม มุมจากซ้ายไปขวาในแถวแรกคือ `0`, `45`, `90`; แถวที่สองคือ `135`, `180`, `270`

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

![ไล่สีเชิงเส้นที่มุม 0, 45, 90 องศาในแถวบนและ 135, 180, 270 องศาในแถวล่าง](linear-gradient-angles.png)

### **สเกลไล่สีเชิงเส้นตามรูปร่าง**

[IGradientFormat::set_LinearGradientScaled](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_lineargradientscaled/) รับค่า [NullableBool](https://reference.aspose.com/slides/cpp/aspose.slides/nullablebool/) ตั้งเป็น `False` เพื่อคงมุมไล่สีเชิงเรขาคณิตเมื่อรูปร่างเปลี่ยนสัดส่วน, หรือ `True` เพื่อสเกลไล่สีตามความกว้างและความสูงของรูปร่าง เมื่อเปิดสเกล มุมที่มองเห็นอาจต่างจากมุมที่กำหนดบนรูปร่างที่ไม่เป็นสี่เหลี่ยมจัตุรัส

ตัวอย่างต่อไปนี้ใช้มุม `45` องศาและจุดหยุดสีเดียวกันกับการเปรียบเทียบมุม คอลัมน์ซ้ายตั้งค่า `False`; คอลัมน์ขวาตั้งค่า `True` แต่ละคอลัมน์มีสี่เหลี่ยมกว้างด้านบนและสี่เหลี่ยมสูงด้านล่าง ทั้งสองเริ่มจากขนาดกว้างเท่าเดิม; การเปลี่ยนความกว้างและความสูงของสี่เหลี่ยมที่สองแสดงว่าการเติมสีตอบสนองต่อการปรับขนาดโดยไม่เปลี่ยนค่าการไล่สี

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

ผลลัพธ์ใน PowerPoint, ปิดสเกลทางซ้ายและเปิดสเกลทางขวา:

![สี่เหลี่ยมกว้างและสูงที่มีไล่สี 45 องศา, เปรียบเทียบ LinearGradientScaled False ด้านซ้ายกับ True ด้านขวา](linear-gradient-scaling.png)

เมื่อสเกลปิด, แถบสีทแยงมุมคงทิศทางเดียวกันในทั้งสองสี่เหลี่ยม เมื่อสเกลเปิด, แถบสียืดตามสัดส่วนของรูปร่าง ช่วยให้คัดลอกไล่สีของแม่แบบเมื่อต้องปรับรูปร่างให้มีขนาดต่างกัน บนสี่เหลี่ยมจัตุรัส การเปิดสเกลจะไม่เปลี่ยนลักษณะของไล่สี `45` องศานี้

ทั้งมุมและการสเกลใช้กับไล่สีเชิงเส้น ไม่ควบคุมการเติม [GradientShape::Radial หรือ GradientShape::Rectangle](https://reference.aspose.com/slides/cpp/aspose.slides/gradientshape/)

### **ผสานมุมกับทิศทางไล่สี**

[IGradientFormat::set_GradientDirection](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_gradientdirection/) เลือกสไตล์ไล่สีจาก enumeration [GradientDirection](https://reference.aspose.com/slides/cpp/aspose.slides/gradientdirection/) ไม่ใช่การแทนที่มุมเชิงตัวเลข สำหรับไล่สีเชิงเส้น, สไตล์มุมอาจเปลี่ยนพื้นที่การกระจายสีโดยไม่เปลี่ยนมุมที่ตั้งผ่าน [IGradientFormat::set_LinearGradientAngle](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/set_lineargradientangle/) ให้คงทิศทางเมื่อเปรียบเทียบมุมหรือสเกล

ตัวอย่างต่อไปนี้ใช้การตั้งค่าเดียวกันแต่สลับลำดับ สี่เหลี่ยมสองรูปมีลักษณะเดียวกัน: การกำหนดทิศทางก่อนหรือหลังมุมไม่ทำให้ผลลัพธ์เปลี่ยน

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

## **การเติมลวดลาย (Pattern Fill)**

การเติมลวดลายใช้การออกแบบสองสี เช่น จุด, แถบ, หรือตาราง ตัวอย่างนี้ใช้ [IPatternFormat::set_PatternStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/set_patternstyle/) เพื่อเลือกลวดลาย trellis  [IPatternFormat::get_BackColor](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_backcolor/) ตั้งพื้นหลังสีเทาอ่อน, และ [IPatternFormat::get_ForeColor](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_forecolor/) ตั้งสีเหลืองให้ลวดลาย

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

![สี่เหลี่ยมที่เติมลวดลาย](pattern-fill.png)

## **การเติมรูปภาพ (Picture Fill)**

การเติมรูปภาพใช้ภาพภายในรูปร่าง ตัวอย่างนี้ต้องการภาพในเครื่องและใช้ [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/) เพื่อโหลดเข้าสู่คอลเลกชันภาพของงานนำเสนอ การตั้งค่า [IPictureFillFormat::set_PictureFillMode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/) เป็นโหมด tiled ทำให้ภาพซ้ำภายในสี่เหลี่ยม ภาพต้นฉบับที่ใช้แสดงด้านล่าง:

![รูปภาพดอกบัว](lotus.png)

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

![รูปร่างที่เติมรูปภาพ](picture-fill.png)

### **ตั้งค่าการปูภาพเป็นพื้นผิว (Tile Picture As Texture)**

หากต้องการตั้งค่าภาพแบบ tiled เป็นพื้นผิวและปรับพฤติกรรมการปู, สามารถใช้เมธอดต่อไปนี้ของส่วนติดต่อ [IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/) และคลาส [PictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/) :

- [set_PictureFillMode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): ตั้งโหมดการเติมภาพ—`Tile` หรือ `Stretch`
- [set_TileAlignment](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): กำหนดการจัดตำแหน่งของแผ่นภาพภายในรูปร่าง
- [set_TileFlip](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileflip/): ควบคุมการพลิกภาพแนวนอน, แนวตั้ง, หรือทั้งสองอย่าง
- [set_TileOffsetX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): ตั้งค่าการชี้ออฟเซ็ตแนวนอนของแผ่นภาพ (หน่วยจุด) จากจุดกำเนิดของรูปร่าง
- [set_TileOffsetY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): ตั้งค่าการชี้ออฟเซ็ตแนวตั้งของแผ่นภาพ (หน่วยจุด) จากจุดกำเนิดของรูปร่าง
- [set_TileScaleX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): นิยามสเกลแนวนอนของแผ่นภาพเป็นเปอร์เซ็นต์
- [set_TileScaleY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): นิยามสเกลแนวตั้งของแผ่นภาพเป็นเปอร์เซ็นต์

ตัวอย่างนี้ต้องการภาพในเครื่องและกำหนดค่า [IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/) ให้ซ้ำที่ 50% ของขนาดเดิม การชี้ออฟเซ็ต `−32` จุดทำให้แผ่นภาพเคลื่อนที่แนวนอนและแนวตั้ง; การจัดตำแหน่งด้านล่างขวาและการพลิกทั้งสองทิศทางกำหนดวิธีจัดเรียงพื้นผิวที่ซ้ำ

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

![ตัวเลือกการปูภาพ](tile-options.png)

## **การเติมสีทึบ (Solid Color Fill)**

การเติมสีทึบให้รูปร่างเป็นสีเดียวแบบสม่ำเสมอ ตัวอย่างนี้ตั้งค่า [IFillFormat::set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) เป็นโหมดสีทึบและกำหนดสีเหลืองผ่าน [IFillFormat::get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/), แล้วบันทึกสี่เหลี่ยมในงานนำเสนอ

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

### **คัดลอกสีโดยคงการอ้างอิงธีม**

ใช้ [IColorFormat::CopyFrom](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/copyfrom/) เพื่อคัดลอกการกำหนดค่าสีรวมถึงประเภทสี, การอ้างอิงธีม, และการแปลงต่างๆ นี้มีประโยชน์เมื่อโอนสีเติมระหว่างรูปร่างที่ควรยังคงตามธีมของงานนำเสนอ วิธีนี้คัดลอกเฉพาะสี ไม่คัดลอกประเภทการเติม, ขอบ, หรือการจัดรูปแบบรูปร่างอื่นๆ ตั้งค่าประเภทการเติมของปลายทางอย่างชัดเจนด้วย [IFillFormat::set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/)

ตัวอย่างนี้สร้างสี่เหลี่ยมสามรูปจากซ้ายไปขวา: ต้นฉบับ, คัดลอกที่คำนึงถึงธีม, และคัดลอกเป็น RGB คงที่ ต้นฉบับใช้ [IColorFormat::set_SchemeColor](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/set_schemecolor/) เพื่ออ้างอิงสีสำเร็จแรกและเพิ่ม tint ผ่าน [IColorOperationCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides/icoloroperationcollection/add/) คัดลอก RGB ใช้สีเติมที่มีผลของต้นฉบับทำให้ทั้งสามดูเหมือนกันในตอนแรก การเรียก [IColorFormat::set_Color](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/set_color/) ตั้งค่ารหัส RGB คงที่และลบการแปลงสีที่มีอยู่

```cpp
#include <DOM/ColorTransformOperation.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
#include <initializer_list>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(660, 220, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

presentation->get_MasterTheme()->get_ColorScheme()->get_Accent1()->set_Color(Color::get_RoyalBlue());

auto source = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 40, 180, 140);
auto themeCopy = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 240, 40, 180, 140);
auto rgbCopy = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 450, 40, 180, 140);

for (auto shape : { source, themeCopy, rgbCopy })
{
    shape->get_FillFormat()->set_FillType(FillType::Solid);
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
}

auto sourceColor = source->get_FillFormat()->get_SolidFillColor();
sourceColor->set_SchemeColor(SchemeColor::Accent1);
sourceColor->get_ColorTransform()->Add(ColorTransformOperation::Tint, 0.75f);

themeCopy->get_FillFormat()->get_SolidFillColor()->CopyFrom(sourceColor);
auto effectiveFill = source->get_FillFormat()->GetEffective();
rgbCopy->get_FillFormat()->get_SolidFillColor()->set_Color(effectiveFill->get_SolidFillColor());

auto before = slide->GetImage(1.0f, 1.0f);
before->Save(u"color-copy-before.png", ImageFormat::Png);
before->Dispose();

// Theme references follow the new accent color; the fixed RGB value does not.
presentation->get_MasterTheme()->get_ColorScheme()->get_Accent1()->set_Color(Color::get_OrangeRed());

auto after = slide->GetImage(1.0f, 1.0f);
after->Save(u"color-copy-after.png", ImageFormat::Png);
after->Dispose();
presentation->Save(u"copied_colors.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ก่อนเปลี่ยนธีม, การเติมทั้งสามตรงกัน:

![ต้นฉบับ, ปลายทาง CopyFrom, และปลายทาง RGB คงที่ที่มีสีเติมสีน้ำเงินเหมือนกัน](color-copy-before.png)

หลังจากเปลี่ยนธีม, ต้นฉบับและคัดลอกที่คำนึงถึงธีมตามสีสำเร็จใหม่และคง tint ส่วนคัดลอก RGB คงที่ยังคงเป็นสีน้ำเงิน:

![ต้นฉบับและปลายทาง CopyFrom ที่เติมสีส้ม, ส่วนปลายทาง RGB คงที่ยังคงสีน้ำเงิน](color-copy-after.png)

การกำหนดที่คัดลอกเป็นอิสระจากต้นฉบับ การเปลี่ยนแปลงอ้างอิงธีมของต้นฉบับ, การกำหนดสีใหม่, หรือการเพิ่ม/ลบการแปลงจะไม่กระทบต่อปลายทาง การเปลี่ยนธีมยังคงมีผลต่อรูปร่างทั้งสองเนื่องจากแต่ละรูปอ้างอิงสีธีมเดียวกัน

การบันทึกและเปิดไฟล์ PPTX อีกครั้งจะคงประเภทสีที่คัดลอกไว้, สามารถดูได้ผ่าน [IColorFormat::get_ColorType](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/get_colortype/), การอ้างอิงธีม, และคอลเลกชันการแปลงที่คืนจาก [IColorFormat::get_ColorTransform](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/get_colortransform/) มิได้แปลงเป็น RGB

เมื่อคัดลอกจากบริบทธีมต่างกัน, เช่นงานนำเสนอที่ใช้พาเลตสำเร็จต่างกัน, การอ้างอิงที่คัดลอกจะอิงตามธีมของปลายทาง ดังนั้นการอ้างอิงและการแปลงเดียวกันอาจให้สีที่มองเห็นต่างกัน ดูรายละเอียดเพิ่มเติมที่ [Presentation Theme](/slides/th/cpp/presentation-theme/) เพื่อเรียนรู้การกำหนดสีธีม

## **ใช้พื้นหลังสไลด์เป็นการเติมสีของรูปร่าง**

ใช้ [IAutoShape::set_UseBackgroundFill](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/set_usebackgroundfill/) เมื่อรูปร่างควรตรงกับพื้นหลังสไลด์, ตัวอย่างเช่นในแม่แบบงานนำเสนอ ตั้งค่า [IFillFormat::set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) เป็น [FillType::NotDefined](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) ก่อนเพื่อเอาการเติมแบบชัดเจนออก ด้วยการผสมนี้รูปร่างจะใช้พื้นหลังสไลด์แทนการเติมแบบสไตล์ของตัวเอง การเปิดแฟล็กนี้อย่างเดียวไม่ลบการเติมที่ชัดเจนอยู่แล้ว

ต่างจาก [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/): การเติมพื้นหลังครอบคลุมวัตถุที่อยู่ด้านหลังรูปร่างด้วยส่วนพื้นหลังสไลด์ที่สอดคล้องกัน, ในขณะที่ NoFill ทำให้วัตถุเหล่านั้นมองเห็นได้ การไล่สียังคงจัดแนวกับสไลด์แทนการเริ่มใหม่ภายในแต่ละรูปร่าง

ตัวอย่างต่อไปนี้สร้างพื้นหลังแม่แบบที่สืบทอดโดยสไลด์และวางแถบสีชมพูหลังสี่เหลี่ยมสามรูป สี่เหลี่ยมซ้ายใช้พื้นหลัง, กลางไม่มีการเติม, ขวาสลับจากพื้นหลังเป็นการเติมสีส้มชัดเจน

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

// เพิ่มวัตถุนี้เป็นอันดับแรกเพื่อให้ปรากฏอยู่ด้านหลังสี่เหลี่ยม.
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

// ปิดการเติมพื้นหลังก่อนใช้การเติมแบบชัดเจน.
explicitShape->set_UseBackgroundFill(false);
explicitShape->get_FillFormat()->set_FillType(FillType::Solid);
explicitShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

presentation->Save(u"background_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์จากซ้ายไปขวา: **การเติมพื้นหลัง**, **ไม่มีการเติม**, และ **การเติมชัดเจน** แถบสีชมพูถูกซ่อนโดยสี่เหลี่ยมซ้ายและขวาแต่ยังมองเห็นผ่านสี่เหลี่ยมกลาง

![การเติมพื้นหลัง, ไม่มีการเติม, และการเติมสีส้มชัดเจนบนแถบสีชมพู](background-fill.png)

พฤติกรรมเดียวกันใช้กับพื้นหลังที่กำหนดโดยตรงบนสไลด์หรือสืบทอดจากเลย์เอาต์ รูปร่างใช้พื้นหลังที่แก้ไขแล้วของสไลด์; ตัวอย่างนี้ทำให้พื้นหลังของสไลด์และเลย์เอาต์ไม่มีการกำหนดเพื่อให้แม่แบบเป็นผู้จัดหา

## **ตั้งค่าความโปร่งแสง**

สำหรับการเติมสีทึบ, ส่วนอัลฟาของสีควบคุมความทึบ: 0 คือโปร่งแสงทั้งหมด, 255 คือทึบเต็ม ตัวอย่างนี้ใช้ค่าอัลฟา 128 สำหรับสี่เหลี่ยมสีเหลือง ทำให้โปร่งแสงประมาณ 50% เพื่อให้สี่เหลี่ยมด้านล่างยังมองเห็นได้ สีถูกกำหนดผ่าน [IFillFormat::get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/)

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

ใช้ [IShape::set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_rotation/) เพื่อหมุนรูปร่างในระนาบสไลด์ มุมวัดเป็นองศา; ตัวอย่างนี้หมุนสี่เหลี่ยม 5 องศาตามเข็มนาฬิกาและบันทึกงานนำเสนอ

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

## **เพิ่มเอฟเฟ็กต์เบเวล 3D**

ใช้ [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/) เพื่อให้รูปร่างมีความลึกและขอบเบเวล ตัวอย่างนี้สร้างวงรีสีเขียวที่มีเส้นขอบสีส้ม, ตั้งค่า [IThreeDFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_depth/) เป็น 4 จุด, และใช้เบเวลด้านบนแบบวงกลมที่มีความกว้างและความสูง 6 จุดผ่าน [IThreeDFormat::get_BevelTop](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_beveltop/) กล้องแบบออร์โทกราฟิกที่หันหน้าและแสงสามจุดทำให้เบเวลมองเห็นได้

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

![เอฟเฟ็กต์เบเวล 3D](3D-bevel-effect.png)

## **เพิ่มเอฟเฟ็กต์การหมุน 3D**

มุมมอง 3D ของรูปร่างควบคุมโดยการตั้งค่ากล้อง ตัวอย่างนี้ใช้ [ICamera::SetRotation](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/setrotation/) ด้วยมุมละติจูด, ลองจิจูด, และรอบการหมุน 40°, 35°, และ 20° ตามลำดับ เลือกกล้องแบบอิซอเมตริกผ่าน [ICamera::set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/) และแสงแบบสมดุลผ่าน [ILightRig::set_LightType](https://reference.aspose.com/slides/cpp/aspose.slides/ilightrig/set_lighttype/) แล้วบันทึกสี่เหลี่ยมที่จัดรูปแบบ

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

![เอฟเฟ็กต์การหมุน 3D](3D-rotation-effect.png)

## **ควบคุมการแสดงผลขาว-ดำสำหรับรูปร่าง**

เมธอด [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_blackwhitemode/) ระบุวิธีการเรนเดอร์รูปร่างเดี่ยวเมื่อดูหรือประมวลผลงานนำเสนอในโหมดขาว-ดำ ไม่ได้เปิดใช้งานการแสดงผลขาว-ดำโดยอัตโนมัติและไม่ได้เปลี่ยนการเติม, เส้น, หรือการจัดรูปแบบอื่นในโหมดสีปกติ

ใช้ค่าจาก enumeration [BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/blackwhitemode/) เพื่อเลือกพฤติกรรมที่ต้องการ ตัวอย่างเช่น `Automatic` ให้แอปพลิเคชันเลือกการแปลง, `Gray` และ `LightGray` ใช้สีเทา, `BlackWhite` ใช้สีดำและขาวเท่านั้น, `Black` และ `White` บังคับสีเดียว, `Color` คงสีปกติ, `Hidden` ลบรูปร่างในโหมดขาว-ดำ, `NotDefined` หมายความว่าไม่ได้กำหนดโหมดระดับรูปร่าง

ตัวอย่างนี้สร้างสี่เหลี่ยมสีส้มและตั้งค่า [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_blackwhitemode/) เป็นสีเทา รูปที่บันทึกยังคงสีส้มสำหรับการแสดงผลสีปกติและขอให้แอปพลิเคชันที่รองรับโหมดขาว-ดำแสดงเป็นสีเทา:

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

ในโหมดสีปกติ, สี่เหลี่ยมยังคงสีส้ม ในกระบวนการแสดงผลขาว-ดำ, มันใช้สีเทาเพราะตั้งค่าเป็น `Gray` สิ่งนี้ช่วยให้คุณคงสไลด์สีเต็มในขณะที่กำหนดลักษณะต่างหากสำหรับการพิมพ์, การพรีวิว, หรือกระบวนการอื่นที่เคารพการตั้งค่าแสดงผลขาว-ดำของงานนำเสนอ

## **รีเซ็ตการจัดรูปแบบ**

ใช้ [ISlide::Reset](https://reference.aspose.com/slides/cpp/aspose.slides/islide/reset/) เพื่อคืนตำแหน่ง, ขนาด, และการจัดรูปแบบของตัวตำแหน่งแบบจับภาพจากเลย์เอาต์ที่สอดคล้องกัน ตัวอย่างนี้ต้องการงานนำเสนอที่มีตัวตำแหน่งเชื่อมโยงกับเลย์เอาต์และรีเซ็ตทุกสไลด์ก่อนบันทึก รูปร่างที่ไม่มีตัวตำแหน่งในเลย์เอาต์จะไม่ถูกรีเซ็ต

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

## **คำถามที่พบบ่อย (FAQ)**

**การจัดรูปแบบรูปร่างส่งผลต่อขนาดไฟล์งานนำเสนอสุดท้ายหรือไม่?**

สี, สไตล์เส้น, และการตั้งค่าเอฟเฟ็กต์โดยทั่วไปเพิ่มข้อมูลเพียงเล็กน้อยเมื่อเทียบกับภาพและสื่อที่ฝังไว้ การเติมรูปภาพอาจเพิ่มขนาดไฟล์เนื่องจากภาพถูกเก็บในงานนำเสนอ

**ฉันจะตรวจจับรูปร่างบนสไลด์ที่มีการจัดรูปแบบเดียวกันเพื่อจัดกลุ่มได้อย่างไร?**

เปรียบเทียบคุณสมบัติกุญแจการจัดรูปแบบของแต่ละรูปร่าง—การเติม, เส้น, และการตั้งค่าเอฟเฟ็กต์ หากค่าตรงกันทั้งหมด ให้ถือว่ารูปร่างมีสไตล์เดียวกันและจัดกลุ่มเชิงตรรกะ ซึ่งช่วยลดความซับซ้อนในการจัดการสไตล์ในภายหลัง

**ฉันสามารถบันทึกชุดสไตล์รูปร่างที่กำหนดเองเป็นไฟล์แยกเพื่อใช้ใหม่ในงานนำเสนออื่นได้หรือไม่?**

ได้. เก็บรูปร่างตัวอย่างที่มีสไตล์ที่ต้องการในสไลด์เทมเพลตหรือไฟล์เทมเพลต .POTX เมื่อสร้างงานนำเสนอใหม่, เปิดเทมเพลต, คัดลอกรูปร่างที่สไตล์ต้องการ, แล้วนำการจัดรูปแบบไปใช้ตามต้องการ.