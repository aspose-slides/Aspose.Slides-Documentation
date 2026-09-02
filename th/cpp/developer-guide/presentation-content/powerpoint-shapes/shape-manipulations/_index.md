---
title: จัดการรูปร่างพรีเซนเทชันใน C++
linktitle: การจัดการรูปร่าง
type: docs
weight: 40
url: /th/cpp/shape-manipulations/
keywords:
- รูปร่าง PowerPoint
- รูปร่างพรีเซนเทชัน
- รูปร่างบนสไลด์
- ค้นหารูปร่าง
- คัดลอกรูปร่าง
- ลบรูปร่าง
- ซ่อนรูปร่าง
- เปลี่ยนลำดับรูปร่าง
- รับ ID รูปร่าง Interop
- ข้อความทางเลือกของรูปร่าง
- รูปแบบเลเอาต์ของรูปร่าง
- รูปร่างเป็น SVG
- แปลงรูปร่างเป็น SVG
- จัดแนวรูปร่าง
- กลับด้านรูปร่าง
- PowerPoint
- พรีเซนเทชัน
- C++
- Aspose.Slides
description: "เรียนรู้วิธีระบุ, คัดลอกรูปร่าง, ลบรูปร่าง, ซ่อนรูปร่าง, จัดเรียงลำดับใหม่, ส่งออก, จัดแนว, และกลับด้านรูปร่างพรีเซนเทชันด้วย Aspose.Slides for C++."
---
## **ภาพรวม**

Aspose.Slides for C++ แสดงรูปร่างบนสไลด์เป็น [IShapeCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapecollection/) ที่จัดลำดับไว้ คอลเลกชันนี้เป็นทั้งที่ที่คุณค้นหาและแก้ไขรูปร่างและเป็นแหล่งที่มาของลำดับการซ้อนกัน: ดัชนี `0` คือรูปร่างที่อยู่ด้านหลังสุด ส่วนดัชนีสุดท้ายคือรูปร่างที่อยู่ด้านหน้าสุด

บทความนี้ใช้โมเดลนั้นเป็นแนวทาง โดยอธิบายวิธีระบุรูปร่างอย่างแม่นยำก่อน แล้วแสดงวิธีทำการคัดลอก, ลบ, ซ่อน, และจัดเรียงลำดับรูปร่าง ส่วนสุดท้ายจะครอบคลุมการจัดรูปแบบระดับเลเอาต์, การส่งออกเป็น SVG, การจัดแนว, และการตั้งค่าการกลับด้าน ตัวอย่างแต่ละอันทำงานอิสระกัน คุณจึงสามารถใช้เพียงส่วนที่เวิร์กโฟลว์ของคุณต้องการได้

## **ระบุและค้นหารูปร่าง**

ดัชนีของคอลเลกชันสะดวกเมื่อต้องประมวลผลไฟล์ที่ทราบไว้แล้ว แต่ไม่ได้เป็นตัวระบุที่คงที่ การเพิ่ม, ลบ, หรือจัดเรียงลำดับรูปร่างใหม่อาจทำให้ดัชนีเปลี่ยน เลือกตัวระบุตามวิธีการสร้างและการดูแลพรีเซนเทชัน:

- [Name](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/get_name/) มีประโยชน์สำหรับเทมเพลตที่ควบคุมโดยนักพัฒนาและตรวจสอบได้ง่ายในแผงการเลือกของ PowerPoint สามารถแก้ไขได้และไม่ได้รับประกันว่าจะเป็นค่าที่ไม่ซ้ำกัน ดังนั้นจึงควรกำหนดแนวทางการตั้งชื่อหากโค้ดอ้างอิงถึงมัน
- [AlternativeText](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/get_alternativetext/) มีประโยชน์เมื่อคำอธิบายการเข้าถึงหรือแท็กที่ผู้สร้างกำหนดไว้แล้วระบุรูปร่างนั้น มันมองเห็นได้โดยผู้ใช้, อาจแปลหรือเขียนใหม่เพื่อการเข้าถึง และไม่ได้รับประกันความไม่ซ้ำกัน อย่าแปลงข้อความการเข้าถึงที่มีความหมายเป็นคีย์ฐานข้อมูลโดยไม่มีการแจ้ง
- [OfficeInteropShapeId](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/get_officeinteropshapeid/) เป็นตัวระบุแบบอ่านอย่างเดียวที่ไม่ซ้ำกันภายในสไลด์และสอดคล้องกับ Shape ID ที่ PowerPoint ใช้ ใช้เมื่อต้องบูรณาการกับ PowerPoint หรือเมื่อต้องการอ้างอิงที่ไม่คลุมเครือตลอดอายุของรูปร่าง รูปร่างที่คัดลอกหรือสร้างใหม่จะเป็นรูปร่างอื่นและได้รับ ID ของมันเอง

คุณสมบัติ [UniqueId](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/get_uniqueid/) ที่เกี่ยวข้องมีขอบเขตระดับพรีเซนเทชัน แต่ถูกออกแบบมาสำหรับแอดอินและอาจถูกกำหนดค่าใหม่ ไม่ควรถือว่าเป็นคีย์ภายนอกถาวร หากต้องการเอกลักษณ์ระยะยาว ควรเก็บการแมปในข้อมูลแอปและตรวจสอบว่ารูปร่างที่คาดหวังยังคงมีอยู่

ตัวอย่างต่อไปนี้ค้นหาด้วย `Name` และรายงาน interop ID ที่กำหนดไว้ระดับสไลด์ เมื่อเทมเพลตไม่มีรูปร่างที่คาดไว้ โค้ดจะแจ้งผลนั้นแทนที่จะดำเนินต่อด้วยออบเจกต์ที่ผิด

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IShape> targetShape;
for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"RevenueChart")
    {
        targetShape = shape;
        break;
    }
}

if (targetShape == nullptr)
{
    Console::WriteLine(u"The shape 'RevenueChart' was not found on slide 1.");
}
else
{
    Console::WriteLine(String::Format(u"Found {0}; interop ID: {1}", targetShape->get_Name(), targetShape->get_OfficeInteropShapeId()));
}

presentation->Dispose();
```

เมื่อการดำเนินการจำเพาะกับประเภทของรูปร่าง ให้ตรวจสอบอินเทอร์เฟซก่อนใช้สมาชิกที่เฉพาะชนิด ตัวอย่างนี้อัปเดตข้อความและข้อความทางเลือกเฉพาะเมื่อออบเจกต์ที่ระบุชื่อเป็น [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/)

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IShape> candidate;
for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"StatusLabel")
    {
        candidate = shape;
        break;
    }
}

if (candidate != nullptr && ObjectExt::Is<IAutoShape>(candidate))
{
    auto autoShape = ExplicitCast<IAutoShape>(candidate);
    autoShape->get_TextFrame()->set_Text(u"Approved");
    autoShape->set_AlternativeText(u"Approval status: approved");
    presentation->Save(u"identified-shape.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"'StatusLabel' is missing or is not an AutoShape.");
}

presentation->Dispose();
```

## **แก้ไขคอลเลกชันของรูปร่าง**

เมธอดการเพิ่ม, คัดลอก, ลบ, และจัดเรียงลำดับทำงานบนคอลเลกชันโดยทันที หากการดำเนินการเปลี่ยนจำนวนหรือลำดับของรูปร่าง อย่าใช้อินเด็กซ์ที่จับไว้ก่อนการดำเนินการต่อไป

### **คัดลอกรูปร่าง**

[AddClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapecollection/addclone/) สร้างสำเนาอิสระและต่อท้ายที่คอลเลกชันเป้าหมาย [InsertClone](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapecollection/insertclone/) ก็สร้างสำเนาเช่นกันแต่วางที่ดัชนี z‑order ที่ระบุ การ overload ที่รับพิกัดจะย้ายคลอนโดยไม่เปลี่ยนขนาด; overload ที่รับความกว้างและความสูงสามารถปรับขนาดได้ด้วย

ตัวอย่างสร้างสไลด์ปลายทาง, คัดลอกรูสี่เหลี่ยมที่มีป้ายกำกับไปด้านหน้า, และแทรกคลอนที่สองที่ด้านหลัง การเปลี่ยนแปลงใด ๆ กับคลอนใดคลอนหนึ่งจะไม่กระทบรูปต้นฉบับ

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto sourceSlide = presentation->get_Slide(0);
auto sourceShape = sourceSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 180, 60);
sourceShape->set_Name(u"SourceLabel");
sourceShape->get_TextFrame()->set_Text(u"Source");

auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto destinationSlide = presentation->get_Slides()->AddEmptySlide(blankLayout);

auto frontCloneShape = destinationSlide->get_Shapes()->AddClone(sourceShape, 80, 80);
frontCloneShape->set_Name(u"FrontClone");
if (ObjectExt::Is<IAutoShape>(frontCloneShape))
{
    auto frontClone = ExplicitCast<IAutoShape>(frontCloneShape);
    frontClone->get_TextFrame()->set_Text(u"Front clone");
}
else
{
    Console::WriteLine(u"The front clone is not an AutoShape; its text was not changed.");
}

auto backCloneShape = destinationSlide->get_Shapes()->InsertClone(0, sourceShape, 80, 180);
backCloneShape->set_Name(u"BackClone");
if (ObjectExt::Is<IAutoShape>(backCloneShape))
{
    auto backClone = ExplicitCast<IAutoShape>(backCloneShape);
    backClone->get_TextFrame()->set_Text(u"Back clone");
}
else
{
    Console::WriteLine(u"The back clone is not an AutoShape; its text was not changed.");
}

presentation->Save(u"cloned-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

การคัดลอกจะคัดลอกเนื้อหาและการจัดรูปแบบของรูปร形รวมถึงชื่อและข้อความทางเลือกด้วย ให้กำหนดตัวระบุเชิงตรรกะใหม่ให้กับคลอนหากค่าดังกล่าวต้องไม่ซ้ำกัน งานทรัพยากรของรูปร่างซับซ้อนจะจัดการโดยพรีเซนเทชัน แต่คลอนยังคงเป็นรายการใหม่ในคอลเลกชันพร้อมอัตลักษณ์รูปร่างใหม่

### **ลบรูปร่าง**

[Remove](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapecollection/remove/) ลบออบเจกต์รูปร่างเฉพาะจากคอลเลกชันของมัน เมื่อทำการลบหลายรายการที่ตรงกันขณะวนรอบแบบใช้ดัชนี ควรเริ่มจากท้ายสุดเพื่อให้ดัชนีที่เหลือยังคงใช้งานได้

ตัวอย่างนี้ลบทุกรูปร่างที่มีชื่อที่กำหนดไว้ มันอ่านรูปร่างที่มีดัชนีปัจจุบัน ไม่ใช่รายการคอลเลกชันคงที่ และไม่ได้ทำการคาสท์รูปร่างโดยไม่จำเป็น

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto keepShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 140, 60);
keepShape->set_Name(u"Keep");

auto firstTemporaryShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 220, 40, 80, 80);
firstTemporaryShape->set_Name(u"Temporary");

auto secondTemporaryShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 340, 40, 100, 80);
secondTemporaryShape->set_Name(u"Temporary");

for (int32_t i = slide->get_Shapes()->get_Count() - 1; i >= 0; --i)
{
    auto shape = slide->get_Shape(i);
    if (shape->get_Name() == u"Temporary")
    {
        slide->get_Shapes()->Remove(shape);
    }
}

presentation->Save(u"removed-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

หลังการลบ จำนวนรูปร่างและดัชนีของรูปร่างต่อมาจะเปลี่ยน การอ้างอิงถึงรูปร่างที่ไม่ได้รับผลกระทบยังคงเชื่อถือได้กว่าการบันทึกดัชนีเดิม ควรคำนึงถึงคอนเน็กเตอร์, แอนิเมชัน, และคุณลักษณะอื่น ๆ ของพรีเซนเทชันที่อาจอ้างอิงถึงออบเจกต์ที่ถูกลบ; การลบรูปร่างที่มองเห็นได้อาจเปลี่ยนมากกว่าลักษณะของสไลด์เท่านั้น

### **ซ่อนรูปร่าง**

การตั้งค่า [Hidden](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/set_hidden/) เป็น `true` ทำให้รูปร่างยังคงอยู่ในคอลเลกชันแต่ไม่ปรากฏในโหมดสไลด์โชว์ปกติ ดัชนี, การจัดรูปแบบ, และเนื้อหายังคงพร้อมให้โค้ดใช้ ดังนั้นการซ่อนจึงเหมาะกับองค์ประกอบทางเลือกที่อาจคืนค่าได้ในภายหลัง

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto visibleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 160, 60);
visibleShape->set_Name(u"VisibleLabel");

auto optionalShape = slide->get_Shapes()->AddAutoShape(ShapeType::Moon, 240, 40, 100, 100);
optionalShape->set_Name(u"OptionalDecoration");

for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"OptionalDecoration")
    {
        shape->set_Hidden(true);
    }
}

presentation->Save(u"hidden-shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

การซ่อนไม่ใช่การลบหรือความปลอดภัย อ็อบเจกต์ยังคงค้นพบและยกเลิกการซ่อนโดยผู้ใช้หรือโค้ดได้ และยังคงเป็นส่วนหนึ่งของไฟล์พรีเซนเทชัน

### **เปลี่ยน Z‑Order**

รูปร่างที่ทับซ้อนกันจะวาดตามลำดับคอลเลกชัน [Reorder](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapecollection/reorder/) ย้ายรูปร่างที่มีอยู่ไปยังดัชนีเป้าหมายโดยไม่ต้องคัดลอก ดัชนี `0` คือด้านหลัง; `Count - 1` คือด้านหน้า

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto blueRectangle = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 220, 120);
blueRectangle->set_Name(u"BlueRectangle");
blueRectangle->get_FillFormat()->set_FillType(FillType::Solid);
blueRectangle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());

auto orangeEllipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 180, 140, 220, 120);
orangeEllipse->set_Name(u"OrangeEllipse");
orangeEllipse->get_FillFormat()->set_FillType(FillType::Solid);
orangeEllipse->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

slide->get_Shapes()->Reorder(slide->get_Shapes()->get_Count() - 1, blueRectangle);
presentation->Save(u"reordered-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

สี่เหลี่ยมถูกสร้างก่อนและตั้งต้นอยู่หลังวงรี การย้ายมันไปยังดัชนีสุดท้ายจะทำให้มันอยู่ด้านหน้า ควรสรุป z‑order หลังจากเพิ่มหรือคัดลอกรูปร่างทั้งหมดที่เกี่ยวข้อง เพราะการดำเนินการเหล่านั้นจะต่อท้ายหรือแทรกรายการใหม่ในคอลเลกชันและอาจเปลี่ยนลำดับที่ตั้งใจไว้

## **ตรวจสอบรูปร่างบนสไลด์เลเอาต์**

สไลด์ปกติ, สไลด์เลเอาต์, และสไลด์มาสเตอร์มีคอลเลกชันรูปร่างแยกกัน รูปร่างในคอลเลกชันเลเอาต์ไม่ใช่อ็อบเจกต์เดียวกับรูปร่างที่อยู่ตำแหน่งเดียวกันบนสไลด์ปกติ ตรวจสอบรูปร่างเลเอาต์เมื่อคุณต้องการทำความเข้าใจหรือเปลี่ยนการจัดรูปแบบที่มาจากเลเอาต์

ตัวอย่างต่อไปนี้อ่าน [FillFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/get_fillformat/) และ [LineFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/get_lineformat/) ของแต่ละรูปร่างในเลเอาต์โดยไม่สมมุติว่าทุกรูปร่างเป็น `AutoShape`

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto layoutSlide : presentation->get_LayoutSlides())
{
    for (auto shape : layoutSlide->get_Shapes())
    {
        auto fillType = shape->get_FillFormat()->get_FillType();
        auto lineWidth = shape->get_LineFormat()->get_Width();
        Console::WriteLine(String::Format(u"{0} / {1}: fill={2}, line width={3}", layoutSlide->get_Name(), shape->get_Name(), fillType, lineWidth));
    }
}

presentation->Dispose();
```

การแก้ไขเลเอาต์อาจส่งผลต่อหลายสไลด์ที่ใช้มัน ก่อนเปลี่ยนรูปร่างในเลเอาต์ ให้กำหนดว่าสติกของสไลด์ปกติสืบทอดอ็อบเจกต์นั้นหรือมีการเขียนทับแบบท้องถิ่น และทดสอบทุกสไลด์ที่ใช้เลเอาต์นั้น

## **ส่งออกรูปร่างเป็น SVG**

[WriteAsSvg](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/writeassvg/) เขียนเนื้อหาที่เรนเดอร์ของรูปร่างหนึ่งไปยังสตรีม ผลลัพธ์จะมีเฉพาะรูปร่าง ไม่รวมพื้นหลังสไลด์ทั้งหมดหรือรูปร่างใกล้เคียง

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

if (slide->get_Shapes()->get_Count() == 0)
{
    Console::WriteLine(u"Slide 1 does not contain a shape to export.");
}
else
{
    auto shape = slide->get_Shape(0);
    auto svgStream = File::Create(u"shape.svg");
    shape->WriteAsSvg(svgStream);
    svgStream->Close();
}

presentation->Dispose();
```

ให้เปิดพรีเซนเทชันขณะเรนเดอร์ เอาต์พุตขึ้นอยู่กับการจัดรูปแบบของรูปร่างและทรัพยากรเช่นแบบอักษรและรูปภาพ หากต้องการส่งออกผังทั้งหมด ให้ส่งออกสไลด์แทนการส่งออกรูปร่างแยก ส่วนเรียกใช้ต้องเป็นเจ้าของสตรีมและต้องปิดหรือทำลายสตรีมนั้น

## **จัดแนวรูปร่าง**

เมท็อด [SlideUtil::AlignShapes](https://reference.aspose.com/slides/th/cpp/aspose.slides.util/slideutil/alignshapes/) มี overload ที่จัดแนวทั้งหมดหรือดัชนีคอลเลกชันที่เลือก [ShapesAlignmentType](https://reference.aspose.com/slides/th/cpp/aspose.slides/shapesalignmenttype/) ระบุขอบ, เส้นศูนย์กลาง, หรือโหมดการเว้นระยะ ตั้ง `alignToSlide` เป็น `true` เพื่อใช้งานขอบสไลด์; ตั้งเป็น `false` เพื่อจัดแนวรูปร่างที่เลือกสัมพันธ์กัน

ตัวอย่างนี้จัดแนวสามรูปร่างให้ชิดขอบบนของสไลด์ การอ้างอิงรูปร่างที่ส่งกลับจะถูกแปลงเป็นดัชนีปัจจุบันโดยทันทีก่อนทำการจัดแนว

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/ShapesAlignmentType.h>
#include <Export/SaveFormat.h>
#include <Util/SlideUtil.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Util;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto firstShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 60, 80, 120, 50);
auto secondShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 240, 160, 120, 50);
auto thirdShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 420, 240, 120, 50);
firstShape->set_Name(u"FirstAlignedShape");
secondShape->set_Name(u"SecondAlignedShape");
thirdShape->set_Name(u"ThirdAlignedShape");

auto shapeIndexes = MakeArray<int32_t>({slide->get_Shapes()->IndexOf(firstShape), slide->get_Shapes()->IndexOf(secondShape), slide->get_Shapes()->IndexOf(thirdShape)});

SlideUtil::AlignShapes(ShapesAlignmentType::AlignTop, true, slide, shapeIndexes);
presentation->Save(u"aligned-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

การจัดแนวเปลี่ยนตำแหน่ง ไม่เปลี่ยน z‑order การจัดแนวแบบสัมพันธ์มักต้องใช้อย่างน้อยสองรูปร่าง ส่วนการจัดกระจายแนวนอนหรือแนวตั้งต้องมีรูปร่างจำนวนเพียงพอเพื่อกำหนดช่องว่าง หากแก้ไขคอลเลกชันก่อนเรียกเมท็อด ให้คำนวณดัชนีใหม่

## **กลับด้านรูปร่าง**

คลาส [ShapeFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/shapeframe/) เก็บตำแหน่ง, ขนาด, การกลับด้านแนวนอนและแนวตั้ง, และการหมุน ค่า `FlipH` และ `FlipV` ใช้ [NullableBool](https://reference.aspose.com/slides/th/cpp/aspose.slides/nullablebool/): `True` เปิดการกลับด้าน, `False` ปิด, `NotDefined` คงสถานะที่ไม่ได้กำหนดหรือค่าเริ่มต้น

พรีเซนเทชันตัวอย่างด้านล่างมีรูปร่างหนึ่งอันที่ยังไม่ได้กลับด้าน

![The shape before flipping](shape_to_be_flipped.png)

ตัวอย่างนี้คงค่ากรอบอื่น ๆ ทั้งหมดและแทนที่เฉพาะการตั้งค่าการกลับด้านสองค่าเท่านั้น สิ่งนี้สำคัญเพราะการกำหนดค่า [Frame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/set_frame/) ใหม่จะทำการแทนที่กรอบทั้งหมด

```cpp
#include <DOM/IShape.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeFrame.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto frame = shape->get_Frame();

Console::WriteLine(String::Format(u"Horizontal flip before change: {0}", frame->get_FlipH()));
Console::WriteLine(String::Format(u"Vertical flip before change: {0}", frame->get_FlipV()));

shape->set_Frame(MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y(), frame->get_Width(), frame->get_Height(), NullableBool::True, NullableBool::True, frame->get_Rotation()));

presentation->Save(u"flipped-shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

รูปร่างที่บันทึกไว้จะถูกส่องกระจกในแนวนอนและแนวตั้ง ในขณะที่ตำแหน่ง, ขนาด, และการหมุนยังคงเดิม

![The shape after flipping](flipped_shape.png)

## **คำถามที่พบบ่อย**

**ควรใช้ดัชนีคอลเลกชันเป็นตัวระบุรูปร่างหรือไม่?**

ใช้ได้เฉพาะสำหรับการประมวลผลระยะสั้นเมื่อคอลเลกชันจะไม่เปลี่ยนแปลงก่อนใช้ดัชนี แนะนำให้ใช้ `Name` หรือ `AlternativeText` ที่ตรวจสอบแล้วสำหรับเทมเพลตที่สร้างขึ้น, หรือใช้ `OfficeInteropShapeId` สำหรับงานที่ต้องอ้างอิงระดับสไลด์

**การซ่อนรูปร่างทำให้มันถูกลบออกจาก z‑order หรือไม่?**

ไม่ รูปร่างที่ซ่อนยังคงอยู่ในคอลเลกชันที่ดัชนีเดียวกัน สามารถค้นหา, จัดเรียงลำดับใหม่, แก้ไข, หรือทำให้มองเห็นได้อีกครั้ง

**ทำไมรูปร่างที่คัดลอกจึงแสดงอยู่หน้ารูปร่างอื่น?**

`AddClone` จะต่อท้ายคลอนที่ท้ายคอลเลกชันซึ่งเป็นด้านหน้าของ z‑order ใช้ `InsertClone` เพื่อกำหนดดัชนีเริ่มต้น หรือใช้ `Reorder` หลังจากเพิ่มรูปร่างทั้งหมดแล้ว