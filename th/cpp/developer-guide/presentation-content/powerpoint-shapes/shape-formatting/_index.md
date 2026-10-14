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
- การเติมแบบไล่สี
- การเติมแบบลวดลาย
- การเติมแบบภาพ
- การเติมแบบพื้นผิว
- การเติมสีทึบ
- ความโปร่งแสงของรูปทรง
- การเรนเดอร์รูปทรงสีขาว-ดำ
- การเรนเดอร์รูปทรงระดับสีเทา
- หมุนรูปทรง
- เอฟเฟกต์บีเวล 3 มิติ
- เอฟเฟกต์การหมุน 3 มิติ
- รีเซ็ตการจัดรูปแบบ
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธีจัดรูปแบบรูปร่าง PowerPoint ใน C++ ด้วย Aspose.Slides—ตั้งค่าการเติม, เส้น, และสไตล์เอฟเฟกต์สำหรับไฟล์ PPT, PPTX และ ODP อย่างแม่นยำและควบคุมเต็มที่"
---
## **บทนำ**

ใน PowerPoint คุณสามารถเพิ่มรูปทรงลงในสไลด์ได้ เนื่องจากรูปทรงประกอบด้วยเส้น คุณสามารถจัดรูปแบบได้โดยแก้ไขหรือใช้เอฟเฟกต์กับโครงร่างของมัน นอกจากนี้คุณยังสามารถจัดรูปแบบรูปทรงโดยระบุการตั้งค่าที่ควบคุมการเติมสีภายในของรูปทรงได้

![รูปแบบ-รูปร่าง-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for C++ มีอินเทอร์เฟซและเมธอดที่ช่วยให้คุณสามารถจัดรูปแบบรูปทรงโดยใช้ตัวเลือกเดียวกับที่มีใน PowerPoint.

## **จัดรูปแบบเส้น**

โดยใช้ Aspose.Slides คุณสามารถระบุสไตล์เส้นแบบกำหนดเองสำหรับรูปทรงได้ ขั้นตอนต่อไปนี้แสดงวิธีการ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)  
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน  
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) ไปยังสไลด์  
1. ตั้งค่า [line style](https://reference.aspose.com/slides/cpp/aspose.slides/linestyle/) ของรูปทรง  
1. ตั้งค่าความกว้างของเส้น  
1. ตั้งค่า [dash style](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/) ของเส้น  
1. ตั้งค่าสีเส้นสำหรับรูปทรง  
1. บันทึกพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX  

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
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์พรีเซนเทชัน
auto presentation = MakeObject<Presentation>();

// รับสไลด์แรก
auto slide = presentation->get_Slide(0);

// เพิ่ม AutoShape ประเภทสี่เหลี่ยม
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// ตั้งค่าสีเติมสำหรับรูปทรงสี่เหลี่ยม
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// ใช้การจัดรูปแบบกับเส้นของสี่เหลี่ยม
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// ตั้งค่าสีสำหรับเส้นของสี่เหลี่ยม
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// บันทึกไฟล์ PPTX ลงดิสก์
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![เส้นที่จัดรูปแบบในพรีเซนเทชัน](formatted-lines.png)

## **ใช้เอฟเฟ็กต์สเก็ตช์กับเส้นรูปทรง**

เอฟเฟ็กต์สเก็ตช์ทำให้เส้นของรูปทรงดูเหมือนวาดด้วยมือ ใช้ [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) เพื่อเข้าถึงการตั้งค่าเส้น, [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/get_sketchformat/) เพื่อเข้าถึงการตั้งค่าสเก็ตช์, และ [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/set_sketchtype/) เพื่อเลือกค่าจากแบรนด์ [LineSketchType](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/)  

โค้ด C++ ด้านล่างแสดงวิธีใช้เอฟเฟ็กต์ [LineSketchType::Curved](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/) , อ่านค่าที่กำหนดโดยตรง, และลบเอฟเฟ็กต์ด้วย [LineSketchType::None](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/) :

```cpp
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

// Access the shape's line format and its sketch format.
auto sketchFormat = shape->get_LineFormat()->get_SketchFormat();

// Apply a sketch effect.
sketchFormat->set_SketchType(LineSketchType::Curved);

// Read the sketch effect assigned directly to the shape.
auto explicitSketchType = sketchFormat->get_SketchType();
Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);

// Remove the sketch effect.
sketchFormat->set_SketchType(LineSketchType::None);

presentation->Dispose();
```

ค่าที่ส่งกลับโดย [ISketchFormat::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/get_sketchtype/) แสดงการตั้งค่าที่กำหนดโดยตรงให้กับรูปทรง หากการกำหนดรูปแบบเส้นสามารถสืบทอดจากธีม, สไลด์แม่, หรือสไลด์เลย์เอาต์ ให้ใช้ [ILineFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/geteffective/), เข้าถึง [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/) และอ่านค่า [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/) ค่าที่มีผลจริงจะแสดงการจัดรูปแบบที่ถูกนำไปใช้จริงหลังจากการสืบทอดได้รับการแก้ไข :

```cpp
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

ต่อไปนี้คือสามตัวเลือกประเภทการเชื่อมต่อ:

* Round
* Miter
* Bevel

โดยค่าเริ่มต้น เมื่อ PowerPoint เชื่อมสองเส้นที่มุม (เช่นที่มุมของรูปทรง) จะใช้การตั้งค่า **Round** หากคุณวาดรูปทรงที่มุมแหลม คุณอาจต้องการตัวเลือก **Miter**  

![สไตล์การเชื่อมต่อในพรีเซนเทชัน](join-style-powerpoint.png)

โค้ด C++ ด้านล่างแสดงวิธีที่สี่เหลี่ยมสามรูป (ตามรูปด้านบน) ถูกสร้างโดยใช้การตั้งค่าประเภทการเชื่อมต่อ Miter, Bevel, และ Round :

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
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์พรีเซนเทชัน
auto presentation = MakeObject<Presentation>();

// รับสไลด์แรก
auto slide = presentation->get_Slide(0);

// เพิ่ม AutoShape จำนวนสามรูปที่เป็นประเภทสี่เหลี่ยม
auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

// ตั้งค่าสีเติมสำหรับแต่ละรูปทรงสี่เหลี่ยม
shape1->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape2->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape3->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// ตั้งค่าความกว้างของเส้น
shape1->get_LineFormat()->set_Width(15);
shape2->get_LineFormat()->set_Width(15);
shape3->get_LineFormat()->set_Width(15);

// ตั้งค่าสีสำหรับเส้นของแต่ละสี่เหลี่ยม
shape1->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape3->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// ตั้งค่าสไตล์การเชื่อมต่อ
shape1->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
shape2->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
shape3->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

// เพิ่มข้อความให้กับแต่ละสี่เหลี่ยม
shape1->get_TextFrame()->set_Text(u"Miter Join Style");
shape2->get_TextFrame()->set_Text(u"Bevel Join Style");
shape3->get_TextFrame()->set_Text(u"Round Join Style");

// บันทึกไฟล์ PPTX ลงดิสก์
presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **การเติมแบบไล่สี**

ใน PowerPoint การเติมแบบไล่สีเป็นตัวเลือกการจัดรูปแบบที่ให้คุณใช้การผสมสีอย่างต่อเนื่องกับรูปทรง ตัวอย่างเช่น คุณสามารถใช้สีสองสีหรือมากกว่านั้นโดยสีหนึ่งค่อย ๆ เบลอเข้ากับอีกสีหนึ่ง  

ต่อไปนี้เป็นวิธีการใช้ Aspose.Slides เพื่อเติมแบบไล่สีให้กับรูปทรง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)  
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน  
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) ไปยังสไลด์  
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) ของรูปทรงเป็น `Gradient`  
1. เพิ่มสีที่คุณต้องการสองสีพร้อมตำแหน่งที่กำหนดโดยใช้เมธอด `Add` ของคอลเลกชันจุดหยุดไล่สีที่เปิดเผยโดยอินเทอร์เฟซ [IGradientFormat](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/)  
1. บันทึกพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX  

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientDirection.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/PresetColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์พรีเซนเทชัน
auto presentation = MakeObject<Presentation>();

// รับสไลด์แรก
auto slide = presentation->get_Slide(0);

// เพิ่ม AutoShape ประเภท Ellipse
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// ใช้การจัดรูปแบบไล่สีกับวงรี
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// ตั้งค่าทิศทางของไล่สี
shape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// เพิ่มจุดหยุดไล่สีสองจุด
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// บันทึกไฟล์ PPTX ลงดิสก์
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![วงรีที่มีการเติมแบบไล่สี](gradient-fill.png)

หากไล่สีดูแตกต่างในภาพที่ส่งออกเมื่อเทียบกับใน PowerPoint ให้ดูที่ [Choose a Gradient Rendering Style](/slides/th/cpp/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). คุณสามารถเลือกสไตล์การเรนเดอร์ได้โดยไม่ต้องเปลี่ยนการเติมแบบไล่สีที่เก็บไว้ในพรีเซนเทชัน.

## **การเติมแบบลวดลาย**

ใน PowerPoint การเติมแบบลวดลายเป็นตัวเลือกการจัดรูปแบบที่ให้คุณใช้การออกแบบสองสี—เช่น จุด, ลายเส้น, ลายตะแครง, หรือเช็คบอร์ด—กับรูปทรง คุณสามารถเลือกสีที่กำหนดเองสำหรับพื้นหน้าและพื้นหลังของลวดลายได้  

Aspose.Slides มีลายลักษณ์แบบล่วงหน้ากว่า 45 แบบที่คุณสามารถใช้กับรูปทรงเพื่อเพิ่มความสวยงามของพรีเซนเทชันได้ แม้หลังจากเลือกลายลักษณ์แบบที่กำหนดไว้แล้ว คุณก็ยังสามารถระบุสีที่ต้องการใช้ได้อย่างแม่นยำ  

ต่อไปนี้เป็นวิธีการใช้ Aspose.Slides เพื่อเติมแบบลวดลายให้รูปทรง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)  
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน  
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) ไปยังสไลด์  
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) ของรูปทรงเป็น `Pattern`  
1. เลือกสไตล์ลวดลายจากตัวเลือกที่กำหนดไว้ล่วงหน้า  
1. ตั้งค่า [Background Color](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_backcolor/) ของลวดลาย  
1. ตั้งค่า [Foreground Color](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_forecolor/) ของลวดลาย  
1. บันทึกพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX  

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
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์พรีเซนเทชัน
auto presentation = MakeObject<Presentation>();

// รับสไลด์แรก
auto slide = presentation->get_Slide(0);

// เพิ่ม AutoShape ประเภท Rectangle
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// ตั้งค่าชนิดการเติมเป็น Pattern
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// ตั้งค่าสไตล์ลายลักษณ์แบบ
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// ตั้งค่าสีพื้นหลังและสีพื้นหน้าของลายลักษณ์แบบ
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// บันทึกไฟล์ PPTX ลงดิสก์
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![สี่เหลี่ยมที่มีการเติมลวดลาย](pattern-fill.png)

## **การเติมแบบภาพ**

ใน PowerPoint การเติมแบบภาพเป็นตัวเลือกการจัดรูปแบบที่ให้คุณแทรกภาพภายในรูปทรง—โดยใช้ภาพเป็นพื้นหลังของรูปทรงอย่างมีประสิทธิภาพ  

ต่อไปนี้เป็นวิธีการใช้ Aspose.Slides เพื่อเติมแบบภาพให้กับรูปทรง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)  
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน  
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) ไปยังสไลด์  
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) ของรูปทรงเป็น `Picture`  
1. ตั้งค่าโหมดการเติมภาพเป็น `Tile` (หรือโหมดที่ต้องการอื่น)  
1. สร้างวัตถุ [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) จากภาพที่คุณต้องการใช้  
1. ส่งภาพไปยังเมธอด `ISlidesPicture.set_Image`  
1. บันทึกพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX  

สมมติว่าเรามีไฟล์ "lotus.png" ที่มีภาพต่อไปนี้:

![ภาพดอกบัว](lotus.png)

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
using namespace Aspose::Slides::Export;
using namespace System;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์พรีเซนเทชัน
auto presentation = MakeObject<Presentation>();

// รับสไลด์แรก
auto slide = presentation->get_Slide(0);

// เพิ่ม AutoShape ประเภท Rectangle
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// ตั้งค่าชนิดการเติมเป็น Picture
shape->get_FillFormat()->set_FillType(FillType::Picture);

// ตั้งค่าโหมดการเติมภาพ
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// โหลดภาพและเพิ่มเข้าไปในทรัพยากรของพรีเซนเทชัน
auto image = Images::FromFile(u"lotus.png");
auto picture = presentation->get_Images()->AddImage(image);
image->Dispose();

// ตั้งค่าภาพ
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(picture);

// บันทึกไฟล์ PPTX ลงดิสก์
presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![รูปทรงที่เติมด้วยภาพ](picture-fill.png)

### **วางรูปภาพเป็นพื้นผิวแบบต่อกัน**

หากคุณต้องการตั้งค่าภาพต่อกันเป็นพื้นผิวและปรับพฤติกรรมการต่อให้กำหนดเอง คุณสามารถใช้เมธอดต่อนี้ของอินเทอร์เฟซ [IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/) และคลาส [PictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/) :

- [set_PictureFillMode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): ตั้งค่าโหมดการเติมภาพ—either `Tile` หรือ `Stretch`.  
- [set_TileAlignment](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): ระบุตำแหน่งการจัดเรียงของกระเบื้องภายในรูปทรง.  
- [set_TileFlip](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileflip/): ควบคุมว่ากระเบื้องจะกลับด้านในแนวนอน แนวตั้ง หรือทั้งสองอย่าง.  
- [set_TileOffsetX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): ตั้งค่าออฟเซ็ตแนวนอนของกระเบื้อง (เป็นจุด) จากต้นกำเนิดของรูปทรง.  
- [set_TileOffsetY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): ตั้งค่าออฟเซ็ตแนวตั้งของกระเบื้อง (เป็นจุด) จากต้นกำเนิดของรูปทรง.  
- [set_TileScaleX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): กำหนดสเกลแนวนอนของกระเบื้องเป็นเปอร์เซ็นต์.  
- [set_TileScaleY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): กำหนดสเกลแนวตั้งของกระเบื้องเป็นเปอร์เซ็นต์.  

โค้ดตัวอย่างต่อไปนี้แสดงวิธีเพิ่มรูปทรงสี่เหลี่ยมที่มีการเติมภาพแบบต่อกันและกำหนดตัวเลือกของกระเบื้อง:

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
using namespace Aspose::Slides::Export;
using namespace System;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์พรีเซนเทชัน
auto presentation = MakeObject<Presentation>();

// รับสไลด์แรก
auto firstSlide = presentation->get_Slide(0);

// เพิ่ม AutoShape ประเภท Rectangle
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// ตั้งค่าชนิดการเติมของรูปทรงเป็น Picture
shape->get_FillFormat()->set_FillType(FillType::Picture);

// โหลดภาพและเพิ่มเข้าไปในทรัพยากรของพรีเซนเทชัน
auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

// กำหนดภาพให้กับรูปทรง
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// กำหนดค่าโหมดการเติมภาพและคุณลักษณะการต่อภาพ
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

// บันทึกไฟล์ PPTX ลงดิสก์
presentation->Save(u"tile.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![ตัวเลือกการต่อภาพ](tile-options.png)

## **การเติมสีทึบ**

ใน PowerPoint การเติมสีทึบเป็นตัวเลือกการจัดรูปแบบที่เติมสีเดียวที่สม่ำเสมอลงในรูปทรง สีพื้นหลังเรียบนี้จะถูกใช้โดยไม่มีการไล่สี, พื้นผิว, หรือ ลวดลายใดๆ  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)  
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน  
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) ไปยังสไลด์  
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) ของรูปทรงเป็น `Solid`  
1. กำหนดสีเติมที่คุณต้องการให้กับรูปทรง  
1. บันทึกพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX  

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
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์พรีเซนเทชัน
auto presentation = MakeObject<Presentation>();

// รับสไลด์แรก
auto slide = presentation->get_Slide(0);

// เพิ่ม AutoShape ประเภท Rectangle
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// ตั้งค่าชนิดการเติมเป็น Solid
shape->get_FillFormat()->set_FillType(FillType::Solid);

// ตั้งค่าสีเติม
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// บันทึกไฟล์ PPTX ลงดิสก์
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![รูปทรงที่เติมสีทึบ](solid-color-fill.png)

## **ตั้งค่าความโปร่งแสง**

ใน PowerPoint เมื่อคุณใช้สีทึบ, ไล่สี, ภาพ, หรือการเติมพื้นผิวกับรูปทรง คุณยังสามารถตั้งค่าระดับความโปร่งแสงเพื่อควบคุมความทึบของการเติมได้ ค่าความโปร่งแสงที่สูงทำให้รูปทรงดูโปร่งแสงมากขึ้น ทำให้พื้นหลังหรือวัตถุที่อยู่ด้านล่างมองเห็นได้บางส่วน  

Aspose.Slides ให้คุณตั้งค่าระดับความโปร่งแสงโดยปรับค่า alpha ของสีที่ใช้สำหรับการเติม นี่คือวิธีทำ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)  
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน  
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) ไปยังสไลด์  
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) เป็น `Solid`  
1. ใช้ `Color` เพื่อกำหนดสีที่มีความโปร่งแสง (ส่วนประกอบ `alpha` ควบคุมความโปร่งแสง)  
1. บันทึกพรีเซนเทชัน  

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
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์พรีเซนเทชัน
auto presentation = MakeObject<Presentation>();

// รับสไลด์แรก
auto slide = presentation->get_Slide(0);

// เพิ่ม AutoShape สี่เหลี่ยมสีทึบ
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// เพิ่ม AutoShape สี่เหลี่ยมโปร่งแสงเหนือรูปทรงสีทึบ
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// บันทึกไฟล์ PPTX ลงดิสก์
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![รูปทรงโปร่งแสง](shape-transparency.png)

## **หมุนรูปทรง**

Aspose.Slides ให้คุณหมุนรูปทรงในพรีเซนเทชัน PowerPoint ซึ่งเป็นประโยชน์เมื่อต้องการจัดตำแหน่งองค์ประกอบภาพด้วยการจัดแนวหรือการออกแบบที่เฉพาะเจาะจง.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)  
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน  
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) ไปยังสไลด์  
1. ตั้งค่าคุณสมบัติการหมุนของรูปทรงเป็นมุมที่ต้องการ  
1. บันทึกพรีเซนเทชัน  

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์พรีเซนเทชัน
auto presentation = MakeObject<Presentation>();

// รับสไลด์แรก
auto slide = presentation->get_Slide(0);

// เพิ่ม AutoShape ประเภท Rectangle
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// หมุนรูปทรงโดย 5 องศา
shape->set_Rotation(5);

// บันทึกไฟล์ PPTX ลงดิสก์
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![การหมุนรูปทรง](shape-rotation.png)

## **เพิ่มเอฟเฟ็กต์บีเวล 3 มิติ**

Aspose.Slides อนุญาตให้คุณใช้เอฟเฟ็กต์บีเวล 3 มิติบนรูปทรงโดยกำหนดคุณสมบัติของ [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/)  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)  
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน  
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) ไปยังสไลด์  
1. กำหนดค่า [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/) ของรูปทรงเพื่อกำหนดการตั้งค่าบีเวล  
1. บันทึกพรีเซนเทชัน  

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
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// สร้างอินสแตนซ์ของคลาส Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// เพิ่มรูปทรงลงบนสไลด์.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// ตั้งค่าคุณสมบัติ ThreeDFormat ของรูปทรง.
shape->get_ThreeDFormat()->set_Depth(4.0);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

// บันทึกพรีเซนเทชันเป็นไฟล์ PPTX.
presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![เอฟเฟ็กต์บีเวล 3 มิติ](3D-bevel-effect.png)

## **เพิ่มเอฟเฟ็กต์การหมุน 3 มิติ**

Aspose.Slides อนุญาตให้คุณใช้เอฟเฟ็กต์การหมุน 3 มิติบนรูปทรงโดยกำหนดคุณสมบัติของ [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/)  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)  
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน  
1. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) ไปยังสไลด์  
1. ใช้เมธอด [set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/) และ [set_LightType](https://reference.aspose.com/slides/cpp/aspose.slides/ilightrig/set_lighttype/) เพื่อกำหนดการหมุน 3 มิติ  
1. บันทึกพรีเซนเทชัน  

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
using namespace Aspose::Slides::Export;
using namespace System;

// สร้างอินสแตนซ์ของคลาส Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_TextFrame()->set_Text(u"Hello, Aspose!");

shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// บันทึกพรีเซนเทชันเป็นไฟล์ PPTX.
presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![เอฟเฟ็กต์การหมุน 3 มิติ](3D-rotation-effect.png)

## **ควบคุมการเรนเดอร์สีขาว-ดำสำหรับรูปทรง**

เมธอด [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_blackwhitemode/) ระบุว่ารูปทรงแต่ละอันจะถูกเรนเดอร์อย่างไรเมื่อพรีเซนเทชันถูกดูหรือประมวลผลในโหมดสีขาว-ดำ มันไม่ได้เปิดใช้งานการแสดงสีขาว-ดำโดยคนเดียว และไม่ได้เปลี่ยนการเติม, เส้น, หรือการจัดรูปแบบอื่นของรูปทรงในโหมดสีปกติ.  

ใช้ค่าจาก enumeration [BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/blackwhitemode/) เพื่อเลือกพฤติกรรมที่ต้องการ ตัวอย่างเช่น `Automatic` ให้แอปพลิเคชันเรนเดอร์เลือกการแปลง, `Gray` และ `LightGray` ใช้สีเทา, `BlackWhite` ใช้เฉพาะสีดำและสีขาว, `Black` และ `White` บังคับให้เป็นสีเดียว, `Color` คงสีปกติ, และ `Hidden` ลบรูปทรงในโหมดสีขาว-ดำ. `NotDefined` หมายความว่าไม่มีการกำหนดโหมดระดับรูปทรง.  

โค้ด C++ ด้านล่างสร้างรูปทรงสีและทำให้มันแสดงเป็นสีเทาในโหมดการแสดงสีขาว-ดำ:

```cpp
#include <DOM/BlackWhiteMode.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
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

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

// เก็บการเติมสีส้มในโหมดสี แต่เรนเดอร์รูปทรงด้วยสีเทาในโหมดสีขาว-ดำ.
shape->set_BlackWhiteMode(BlackWhiteMode::Gray);

presentation->Save(u"shape_black_white_mode.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ในโหมดสีปกติ สี่เหลี่ยมจะคงการเติมสีส้มของมัน ในกระบวนการแสดงสีขาว-ดำ มันจะใช้สีเทาเพราะโหมดถูกตั้งเป็น `Gray` สิ่งนี้ทำให้คุณสามารถรักษาสไลด์สีเต็มได้ในขณะที่กำหนดลักษณะเฉพาะสำหรับการพิมพ์, การดูตัวอย่าง, หรือกระบวนการอื่นที่เคารพการตั้งค่าการแสดงสีขาว-ดำของพรีเซนเทชัน.

## **รีเซ็ตการจัดรูปแบบ**

โค้ด C++ ด้านล่างแสดงวิธีรีเซ็ตการจัดรูปแบบของสไลด์และคืนตำแหน่ง, ขนาด, และการจัดรูปแบบของรูปทรงทั้งหมดที่มี placeholder บน [LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/layoutslide/) ให้เป็นการตั้งค่าเริ่มต้น:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    // รีเซ็ตแต่ละรูปทรงบนสไลด์ที่มี placeholder บน layout.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **คำถามที่พบบ่อย**

**การจัดรูปแบบรูปทรงมีผลต่อขนาดไฟล์พรีเซนเทชันสุดท้ายหรือไม่?**

เพียงเล็กน้อย เท่านั้น ภาพและสื่อที่ฝังอยู่ใช้พื้นที่ไฟล์ส่วนใหญ่ ส่วนพารามิเตอร์ของรูปทรงเช่นสี, เอฟเฟกต์, และไล่สีถูกเก็บเป็น metadata และเพิ่มขนาดไฟล์เกือบไม่มี.

**ฉันจะตรวจจับรูปทรงบนสไลด์ที่มีการจัดรูปแบบเดียวกันเพื่อที่จะจัดกลุ่มได้อย่างไร?**

ให้เปรียบเทียบคุณสมบัติการจัดรูปแบบหลักของแต่ละรูปทรง—การเติม, เส้น, และการตั้งค่าเอฟเฟกต์ หากค่าที่สอดคล้องกันทั้งหมดตรงกัน ให้ถือว่าสไตล์เหมือนกันและจัดกลุ่มรูปทรงเหล่านั้นในเชิงตรรกะ ซึ่งช่วยให้งานจัดการสไตล์ในภายหลังง่ายขึ้น.

**ฉันสามารถบันทึกชุดสไตล์รูปทรงที่กำหนดเองลงไฟล์แยกเพื่อใช้ซ้ำในพรีเซนเทชันอื่นได้หรือไม่?**

ได้ โดยให้บันทึกรูปทรงตัวอย่างที่มีสไตล์ที่ต้องการในชุดสไลด์เทมเพลตหรือไฟล์เทมเพลต .POTX เมื่อต้องสร้างพรีเซนเทชันใหม่ ให้เปิดเทมเพลต, คัดลอกรูปทรงที่มีสไตล์ที่ต้องการ, แล้วนำการจัดรูปแบบของมันไปใช้ใหม่ตามต้องการ.