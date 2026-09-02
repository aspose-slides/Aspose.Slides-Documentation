---
title: จัดการกล่องข้อความในงานนำเสนอด้วย C++
linktitle: จัดการกล่องข้อความ
type: docs
weight: 20
url: /th/cpp/manage-textbox/
keywords:
- กล่องข้อความ
- เฟรมข้อความ
- เพิ่มข้อความ
- อัปเดตข้อความ
- สร้างกล่องข้อความ
- ตรวจสอบกล่องข้อความ
- เพิ่มคอลัมน์ข้อความ
- เพิ่มไฮเปอร์ลิงก์
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "Aspose.Slides สำหรับ C++ ทำให้การสร้าง แก้ไข และทำสำเนากล่องข้อความในไฟล์ PowerPoint และ OpenDocument เป็นเรื่องง่าย ช่วยเสริมการทำงานอัตโนมัติของงานนำเสนอของคุณ"
---
## **บทนำ**

ข้อความบนสไลด์มักอยู่ในกล่องข้อความหรือรูปทรง ดังนั้นเพื่อเพิ่มข้อความลงในสไลด์ คุณต้องเพิ่มกล่องข้อความแล้วใส่ข้อความภายในกล่องข้อความ Aspose.Slides สำหรับ C++ มีอินเทอร์เฟซ [IAutoShape](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_auto_shape) ที่ช่วยให้คุณเพิ่มรูปทรงที่มีข้อความ

{{% alert title="Info" color="info" %}}
Aspose.Slides ยังมีอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_shape) ที่ช่วยให้คุณเพิ่มรูปทรงลงในสไลด์ อย่างไรก็ตาม ไม่ใช่รูปทรงทั้งหมดที่เพิ่มผ่านอินเทอร์เฟซ `IShape` จะสามารถเก็บข้อความได้ แต่รูปทรงที่เพิ่มผ่านอินเทอร์เฟซ [IAutoShape](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_auto_shape) อาจมีข้อความ
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
ดังนั้นเมื่อทำงานกับรูปทรงที่คุณต้องการเพิ่มข้อความ คุณอาจต้องตรวจสอบและยืนยันว่ามันถูกแคสต์ผ่านอินเทอร์เฟซ `IAutoShape` เท่านั้นจึงจะสามารถทำงานกับ [TextFrame](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.text_frame) ซึ่งเป็นคุณสมบัติภายใต้ `IAutoShape` ดูส่วน [Update Text](https://docs.aspose.com/slides/th/cpp/manage-textbox/#update-text) ในหน้านี้
{{% /alert %}}

## **สร้างกล่องข้อความบนสไลด์**

เพื่อสร้างกล่องข้อความบนสไลด์ ให้ทำตามขั้นตอนเหล่านี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation)  
2. รับอ้างอิงของสไลด์แรกในพรีเซนเทชันที่สร้างใหม่  
3. เพิ่มออบเจกต์ [IAutoShape](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_auto_shape) พร้อมกับ [ShapeType](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_geometry_shape#ad941a828a2d9dd58ae1417b5c00c9a5c) ตั้งเป็น `Rectangle` ที่ตำแหน่งที่กำหนดบนสไลด์และรับอ้างอิงของออบเจกต์ `IAutoShape` ที่เพิ่มใหม่  
4. เพิ่มคุณสมบัติ `TextFrame` ให้กับออบเจกต์ `IAutoShape` เพื่อเก็บข้อความ ในตัวอย่างด้านล่าง เราได้เพิ่มข้อความนี้: *Aspose TextBox*  
5. สุดท้ายให้เขียนไฟล์ PPTX ผ่านออบเจกต์ `Presentation`  

โค้ด C++ นี้—การนำขั้นตอนข้างต้นไปใช้—แสดงวิธีเพิ่มข้อความลงในสไลด์:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// สร้างอินสแตนซ์ Presentation
auto pres = System::MakeObject<Presentation>();

// รับสไลด์แรกในพรีเซนเทชัน
auto sld = pres->get_Slides()->idx_get(0);

// เพิ่ม AutoShape โดยกำหนดประเภทเป็น Rectangle
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// เพิ่ม TextFrame ให้กับ Rectangle
ashp->AddTextFrame(u" ");

// เข้าถึง TextFrame
auto txtFrame = ashp->get_TextFrame();

// สร้างอ็อบเจกต์ Paragraph สำหรับ TextFrame
auto para = txtFrame->get_Paragraphs()->idx_get(0);

// สร้างอ็อบเจกต์ Portion สำหรับ Paragraph
auto portion = para->get_Portions()->idx_get(0);

// ตั้งค่า Text
portion->set_Text(u"Aspose TextBox");

// บันทึกพรีเซนเทชันลงดิสก์
pres->Save(u"TextBox_out.pptx", SaveFormat::Pptx);
```

## **ตรวจสอบรูปทรงประเภทกล่องข้อความ**

Aspose.Slides มีเมธอด [get_IsTextBox](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/get_istextbox/) จากอินเทอร์เฟซ [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) ที่ช่วยให้คุณตรวจสอบรูปทรงและระบุว่าเป็นกล่องข้อความหรือไม่

![กล่องข้อความและรูปทรง](istextbox.png)

โค้ด C++ นี้แสดงวิธีตรวจสอบว่ารูปทรงถูกสร้างเป็นกล่องข้อความหรือไม่:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/Presentation.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            Console::WriteLine(autoShape->get_IsTextBox() ? u"shape is a text box" : u"shape is not a text box");
        }
    }
}

presentation->Dispose();
```

โปรดทราบว่า หากคุณเพียงเพิ่มออโต้เชปโดยใช้เมธอด `AddAutoShape` จากอินเทอร์เฟซ [IShapeCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapecollection/) เมธอด `get_IsTextBox` ของออโต้เชปจะคืนค่า `false` อย่างไรก็ตาม หลังจากคุณเพิ่มข้อความให้กับออโต้เชปโดยใช้เมธอด `AddTextFrame` หรือเมธอด `set_Text` เมธอด `get_IsTextBox` จะคืนค่า `true`

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->get_IsTextBox() คืนค่า false
shape1->AddTextFrame(u"shape 1");
// shape1->get_IsTextBox() คืนค่า true

auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->get_IsTextBox() คืนค่า false
shape2->get_TextFrame()->set_Text(u"shape 2");
// shape2->get_IsTextBox() คืนค่า true

auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->get_IsTextBox() คืนค่า false
shape3->AddTextFrame(u"");
// shape3->get_IsTextBox() คืนค่า false

auto shape4 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->get_IsTextBox() คืนค่า false
shape4->get_TextFrame()->set_Text(u"");
// shape4->get_IsTextBox() คืนค่า false
```

## **ค้นหารูปทรงที่เป็นเจ้าของ Text Frame**

ในโค้ดการประมวลผลข้อความทั่วไป คุณอาจได้รับออบเจกต์ [ITextFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/) โดยยังไม่รู้ว่าพรีเซนเทชันใดเป็นเจ้าของ ใช้เมธอด [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/get_parentshape/) เพื่อย้อนกลับไปยัง [IShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishape/) ที่เป็นเจ้าของ

สำหรับ Text Frame ที่เป็นของ [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) หรือรูปทรงอื่นที่มีข้อความ เมธอด [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/get_parentshape/) จะคืนค่าเจ้าของและเมธอด [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/get_parentcell/) จะคืนค่า `nullptr` ทั้งสองเมธอดให้การนำทางแบบอ่านอย่างเดียว ดังนั้นการเรียกใช้จะไม่เปลี่ยนแปลงความเป็นเจ้าของ ตรวจสอบค่า `nullptr` ก่อนเข้าถึงรูปทรงเสมอ

สำหรับตัวอย่างเต็มที่ระบุเจ้าของรูปทรงและเซลล์ของตาราง รวมถึงรูปทรงที่เชื่อมโยงกับโหนด SmartArt ดู [Search and Replace Text](/slides/th/cpp/search-and-replace-text/)

## **เพิ่มคอลัมน์ในกล่องข้อความ**

Aspose.Slides มีเมธอด [set_ColumnCount](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) และ [set_ColumnSpacing](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_text_frame_format#a5254ce6acdc2cd90f4db1c861a94716a) (จากอินเทอร์เฟซ [ITextFrameFormat](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_text_frame_format) และคลาส [TextFrameFormat](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_text_frame_format)) ที่ให้คุณเพิ่มคอลัมน์ในกล่องข้อความ คุณสามารถกำหนดจำนวนคอลัมน์และระยะห่างระหว่างคอลัมน์เป็นจุด

โค้ด C++ นี้แสดงการดำเนินการที่อธิบายไว้:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
// รับสไลด์แรกในพรีเซนเทชัน
auto slide = presentation->get_Slides()->idx_get(0);

// เพิ่ม AutoShape โดยกำหนดประเภทเป็น Rectangle
auto aShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);

// เพิ่ม TextFrame ให้กับ Rectangle
aShape->AddTextFrame(String(u"All these columns are limited to be within a single text container -- ") 
    + u"you can add or delete text and the new or remaining text automatically adjusts " 
    + u"itself to flow within the container. You cannot have text flow from one container " 
    + u"to other though -- we told you PowerPoint's column options for text are limited!");

// รับรูปแบบข้อความของ TextFrame
auto format = aShape->get_TextFrame()->get_TextFrameFormat();

// กำหนดจำนวนคอลัมน์ใน TextFrame
format->set_ColumnCount(3);

// กำหนดระยะห่างระหว่างคอลัมน์
format->set_ColumnSpacing(10);

// บันทึกพรีเซนเทชัน
presentation->Save(u"ColumnCount.pptx", SaveFormat::Pptx);
```

## **เพิ่มคอลัมน์ใน Text Frame**

Aspose.Slides for C++ มีเมธอด [set_ColumnCount](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) (จากอินเทอร์เฟซ [ITextFrameFormat](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_text_frame_format)) ที่ให้คุณเพิ่มคอลัมน์ใน Text Frame ผ่านเมธอดนี้คุณสามารถกำหนดจำนวนคอลัมน์ที่ต้องการใน Text Frame

โค้ด C++ นี้แสดงวิธีเพิ่มคอลัมน์ภายใน Text Frame:

```cpp
#include <DOM/AutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextFrameFormat.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

String outPptxFileName = u"ColumnsTest.pptx";
    
auto pres = System::MakeObject<Presentation>();
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);
auto format = System::ExplicitCast<TextFrameFormat>(shape->get_TextFrame()->get_TextFrameFormat());

format->set_ColumnCount(2);
shape->get_TextFrame()->set_Text(String(u"All these columns are forced to stay within a single text container -- ") 
    + u"you can add or delete text - and the new or remaining text automatically adjusts " 
    + u"itself to stay within the container. You cannot have text spill over from one container " 
    + u"to other, though -- because PowerPoint's column options for text are limited!");
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format1 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format1->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(std::numeric_limits<double>::quiet_NaN() == format1->get_ColumnSpacing());
}

format->set_ColumnSpacing(20);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format2 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format2->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(20 == format2->get_ColumnSpacing());
}

format->set_ColumnCount(3);
format->set_ColumnSpacing(15);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format3 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(3 == format3->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(15 == format3->get_ColumnSpacing());
}
```

## **อัปเดตข้อความ**

Aspose.Slides อนุญาตให้คุณเปลี่ยนหรืออัปเดตข้อความที่อยู่ในกล่องข้อความหรือข้อความทั้งหมดในพรีเซนเทชัน

โค้ด C++ นี้แสดงการดำเนินการที่อัปเดตหรือเปลี่ยนข้อความทั้งหมดในพรีเซนเทชัน:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>(u"text.pptx");
for (const auto& slide : System::IterateOver(pres->get_Slides()))
{
    for (const auto& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = System::AsCast<IAutoShape>(shape);
            for (const auto& paragraph : System::IterateOver(autoShape->get_TextFrame()->get_Paragraphs()))
            {
                for (const auto& portion : System::IterateOver(paragraph->get_Portions()))
                {
                    //เปลี่ยนข้อความ
                    portion->set_Text(portion->get_Text().Replace(u"years", u"months"));
                    //เปลี่ยนการจัดรูปแบบ
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

//บันทึกพรีเซนเทชันที่แก้ไขแล้ว
pres->Save(u"text-changed.pptx", SaveFormat::Pptx);
```

## **เพิ่มกล่องข้อความพร้อมไฮเปอร์ลิงก์**

คุณสามารถแทรกลิงก์ภายในกล่องข้อความ เมื่อคลิกกล่องข้อความผู้ใช้จะถูกนำไปเปิดลิงก์

เพื่อเพิ่มกล่องข้อความที่มีลิงก์ ให้ทำตามขั้นตอนเหล่านี้:

1. สร้างอินสแตนซ์ของคลาส `Presentation`  
2. รับอ้างอิงของสไลด์แรกในพรีเซนเทชันที่สร้างใหม่  
3. เพิ่มออบเจกต์ `AutoShape` โดยตั้งค่า `ShapeType` เป็น `Rectangle` ที่ตำแหน่งที่กำหนดบนสไลด์และรับอ้างอิงของออบเจกต์ AutoShape ที่เพิ่มใหม่  
4. เพิ่ม `TextFrame` ให้กับออบเจกต์ `AutoShape` ซึ่งมีข้อความเริ่มต้นเป็น *Aspose TextBox*  
5. สร้างออบเจกต์ `IHyperlinkManager`  
6. กำหนดออบเจกต์ `IHyperlinkManager` ให้กับเมธอด [set_HyperlinkClick](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.shape#a617f857c862b71ac2093ed7866677a5c) ที่เชื่อมกับส่วนของ `TextFrame` ที่คุณต้องการ  
7. สุดท้ายให้เขียนไฟล์ PPTX ผ่านออบเจกต์ `Presentation`

โค้ด C++ นี้—การนำขั้นตอนข้างต้นไปใช้—แสดงวิธีเพิ่มกล่องข้อความพร้อมไฮเปอร์ลิงก์ลงในสไลด์:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์ PPTX
auto presentation = System::MakeObject<Presentation>();

// รับสไลด์แรกในพรีเซนเทชัน
auto slide = presentation->get_Slides()->idx_get(0);

// เพิ่มอ็อบเจกต์ AutoShape โดยกำหนดประเภทเป็น Rectangle
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 150.0f, 150.0f, 50.0f);

// แคสต์รูปร่างเป็น AutoShape
auto autoShape = System::ExplicitCast<IAutoShape>(shape);

// เข้าถึงคุณสมบัติ ITextFrame ที่เชื่อมกับ AutoShape
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();

// เพิ่มข้อความบางส่วนลงในเฟรม
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->set_Text(u"Aspose.Slides");

// ตั้งค่า Hyperlink สำหรับข้อความส่วน
auto linkManager = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_HyperlinkManager();
linkManager->SetExternalHyperlinkClick(u"http://www.aspose.com");

// บันทึกพรีเซนเทชัน PPTX
presentation->Save(u"hLinkPPTX_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**ความแตกต่างระหว่างกล่องข้อความและตัวตำแหน่งข้อความเมื่อทำงานกับสไลด์มาสเตอร์คืออะไร?**

[placeholder](/slides/th/cpp/manage-placeholder/) สืบทอดสไตล์/ตำแหน่งจาก [master](https://reference.aspose.com/slides/th/cpp/aspose.slides/masterslide/) และสามารถถูกเขียนทับบน [layouts](https://reference.aspose.com/slides/th/cpp/aspose.slides/layoutslide/) ได้ ส่วนกล่องข้อความทั่วไปเป็นออบเจกต์อิสระบนสไลด์เฉพาะและจะไม่เปลี่ยนแปลงเมื่อคุณสลับเลย์เอาต์

**ทำอย่างไรจึงจะทำการแทนที่ข้อความจำนวนมากทั่วทั้งพรีเซนเทชันโดยไม่กระทบข้อความภายในแผนภูมิ ตาราง และ SmartArt?**

จำกัดการวนลูปเฉพาะออโต้เชปที่มี Text Frame และละเว้นออบเจกต์ฝังอยู่ ([charts](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/th/cpp/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/th/cpp/aspose.slides.smartart/smartart/)) โดยแยกสำรวจคอลเล็กชันของพวกมันหรือข้ามประเภทออบเจกต์เหล่านั้น