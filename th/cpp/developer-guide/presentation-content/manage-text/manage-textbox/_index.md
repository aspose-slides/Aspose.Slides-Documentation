---
title: จัดการกล่องข้อความในงานนำเสนอโดยใช้ C++
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
description: "Aspose.Slides for C++ ทำให้สร้าง แก้ไข และคัดลอกกล่องข้อความในไฟล์ PowerPoint และ OpenDocument ได้อย่างง่ายดาย ช่วยเพิ่มประสิทธิภาพการทำอัตโนมัติของงานนำเสนอของคุณ."
---
## **บทนำ**

ข้อความบนสไลด์มักอยู่ในช่องข้อความหรือรูปทรง ดังนั้นเพื่อเพิ่มข้อความลงในสไลด์ คุณต้องเพิ่มช่องข้อความแล้วใส่ข้อความบางส่วนลงในช่องนั้น Aspose.Slides for C++ มีอินเทอร์เฟซ [IAutoShape](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_auto_shape) ที่ช่วยให้คุณเพิ่มรูปทรงที่มีข้อความได้

{{% alert title="Info" color="info" %}}
Aspose.Slides ยังมีอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_shape) ที่ช่วยให้คุณเพิ่มรูปทรงลงในสไลด์ อย่างไรก็ตาม รูปทรงทั้งหมดที่เพิ่มผ่านอินเทอร์เฟซ `IShape` ไม่สามารถเก็บข้อความได้ แต่รูปทรงที่เพิ่มผ่านอินเทอร์เฟซ [IAutoShape](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_auto_shape) อาจมีข้อความได้
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
ดังนั้นเมื่อทำงานกับรูปทรงที่ต้องการเพิ่มข้อความ คุณควรตรวจสอบและยืนยันว่ามันถูกแคสผ่านอินเทอร์เฟซ `IAutoShape` เท่านั้น จึงจะสามารถทำงานกับ [TextFrame](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.text_frame) ซึ่งเป็นคุณสมบัติของ `IAutoShape` ดูส่วน [Update Text](https://docs.aspose.com/slides/th/cpp/manage-textbox/#update-text) ในหน้า นี้
{{% /alert %}}

## **สร้างช่องข้อความบนสไลด์**

เพื่อต้องการสร้างช่องข้อความบนสไลด์ ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation) 
2. รับอ้างอิงของสไลด์แรกในงานนำเสนอใหม่ที่สร้างขึ้น 
3. เพิ่มวัตถุ [IAutoShape](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_auto_shape) โดยตั้งค่า [ShapeType](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_geometry_shape#ad941a828a2d9dd58ae1417b5c00c9a5c) เป็น `Rectangle` ที่ตำแหน่งที่ระบุบนสไลด์และรับอ้างอิงของวัตถุ `IAutoShape` ที่เพิ่มใหม่ 
4. เพิ่มคุณสมบัติ `TextFrame` ให้กับวัตถุ `IAutoShape` ที่จะบรรจุข้อความ ในตัวอย่างด้านล่าง เราได้เพิ่มข้อความนี้: *Aspose TextBox* 
5. สุดท้ายให้เขียนไฟล์ PPTX ผ่านวัตถุ `Presentation` 

โค้ด C++ ที่เป็นการลงมือทำตามขั้นตอนด้านบนแสดงวิธีเพิ่มข้อความลงในสไลด์:

```cpp
// สร้างอินสแตนซ์ Presentation
auto pres = System::MakeObject<Presentation>();

// ดึงสไลด์แรกในงานนำเสนอ
auto sld = pres->get_Slides()->idx_get(0);

// เพิ่ม AutoShape โดยกำหนดประเภทเป็น Rectangle
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// เพิ่ม TextFrame ให้กับ Rectangle
ashp->AddTextFrame(u" ");

// เข้าถึง Text Frame
auto txtFrame = ashp->get_TextFrame();

// สร้างอ็อบเจกต์ Paragraph สำหรับ Text Frame
auto para = txtFrame->get_Paragraphs()->idx_get(0);

// สร้างอ็อบเจกต์ Portion สำหรับ Paragraph
auto portion = para->get_Portions()->idx_get(0);

// ตั้งค่า Text
portion->set_Text(u"Aspose TextBox");

// บันทึกงานนำเสนอลงดิสก์
pres->Save(u"TextBox_out.pptx", SaveFormat::Pptx);
```

## **ตรวจสอบรูปทรงประเภทช่องข้อความ**

Aspose.Slides มีเมธอด [get_IsTextBox](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/get_istextbox/) จากอินเทอร์เฟซ [IAutoShape](https://reference.aspose.com/slides/th/cpp/aspose.slides/iautoshape/) ที่ช่วยให้คุณตรวจสอบรูปทรงและระบุว่าเป็นช่องข้อความหรือไม่

![กล่องข้อความและรูปทรง](istextbox.png)

โค้ด C++ นี้แสดงวิธีตรวจสอบว่ารูปทรงถูกสร้างเป็นช่องข้อความหรือไม่:

```c++
auto presentation = MakeObject<Presentation>(u"sample.pptx");
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
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

หมายเหตุว่า หากคุณเพียงเพิ่มออโตช์เพมโดยใชเมธอด `AddAutoShape` จากอินเทอร์เฟซ [IShapeCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapecollection/) เมธอด `get_IsTextBox` ของออโตช์เพมจะคืนค่า `false` อย่างไรก็ตาม หลังจากคุณเพิ่มข้อความให้กับออโตช์เพมโดยใช้เมธอด `AddTextFrame` หรือเมธอด `set_Text` เมธอด `get_IsTextBox` จะคืนค่า `true`

```cpp
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

## **เพิ่มคอลัมน์ให้กับช่องข้อความ**

Aspose.Slides มีเมธอด [set_ColumnCount](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) และ [set_ColumnSpacing](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_text_frame_format#a5254ce6acdc2cd90f4db1c861a94716a) (จากอินเทอร์เฟซ [ITextFrameFormat](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_text_frame_format) และคลาส [TextFrameFormat](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_text_frame_format)) ที่ช่วยให้คุณเพิ่มคอลัมน์ให้กับช่องข้อความ คุณสามารถระบุจำนวนคอลัมน์ในช่องข้อความและกำหนดระยะห่างระหว่างคอลัมน์เป็นหน่วยพ้อยต์

โค้ด C++ นี้สาธิตการทำงานตามที่อธิบาย:

```cpp
auto presentation = System::MakeObject<Presentation>();
// ดึงสไลด์แรกในงานนำเสนอ
auto slide = presentation->get_Slides()->idx_get(0);

// เพิ่ม AutoShape โดยกำหนดประเภทเป็น Rectangle
auto aShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);

// เพิ่ม TextFrame ให้กับ Rectangle
aShape->AddTextFrame(String(u"All these columns are limited to be within a single text container -- ") 
    + u"you can add or delete text and the new or remaining text automatically adjusts " 
    + u"itself to flow within the container. You cannot have text flow from one container " 
    + u"to other though -- we told you PowerPoint's column options for text are limited!");

// ดึงฟอร์แมตข้อความของ TextFrame
auto format = aShape->get_TextFrame()->get_TextFrameFormat();

// ระบุจำนวนคอลัมน์ใน TextFrame
format->set_ColumnCount(3);

// ระบุช่องว่างระหว่างคอลัมน์
format->set_ColumnSpacing(10);

// บันทึกงานนำเสนอ
presentation->Save(u"ColumnCount.pptx", SaveFormat::Pptx);
```

## **เพิ่มคอลัมน์ให้กับ Text Frame**

Aspose.Slides for C++ มีเมธอด [set_ColumnCount](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) (จากอินเทอร์เฟซ [ITextFrameFormat](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_text_frame_format)) ที่ช่วยให้คุณเพิ่มคอลัมน์ใน Text Frame ผ่านเมธอดนี้ คุณสามารถระบุตัวเลขคอลัมน์ที่ต้องการใน Text Frame ได้

โค้ด C++ นี้แสดงวิธีเพิ่มคอลัมน์ภายใน Text Frame:

```cpp
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

Aspose.Slides ให้คุณเปลี่ยนหรืออัปเดตข้อความที่อยู่ในช่องข้อความหรือข้อความทั้งหมดในงานนำเสนอ

โค้ด C++ นี้แสดงการดำเนินการที่อัปเดตหรือเปลี่ยนข้อความทั้งหมดในงานนำเสนอ:

```cpp
auto pres = System::MakeObject<Presentation>(u"text.pptx");
for (const auto& slide : pres->get_Slides())
{
    for (const auto& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = System::AsCast<IAutoShape>(shape);
            for (const auto& paragraph : autoShape->get_TextFrame()->get_Paragraphs())
            {
                for (const auto& portion : paragraph->get_Portions())
                {
                    //เปลี่ยนข้อความ
                    portion->set_Text(portion->get_Text().Replace(u"years", u"months"));
                    //เปลี่ยนรูปแบบ
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

//บันทึกงานนำเสนอที่แก้ไขแล้ว
pres->Save(u"text-changed.pptx", SaveFormat::Pptx);
```

## **เพิ่มช่องข้อความพร้อมไฮเปอร์ลิงก์**

คุณสามารถแทรกลิงก์ภายในช่องข้อความ เมื่อผู้ใช้คลิกที่ช่องข้อความจะถูกนำไปเปิดลิงก์

ขั้นตอนการเพิ่มช่องข้อความที่มีลิงก์:

1. สร้างอินสแตนซ์ของคลาส `Presentation` 
2. รับอ้างอิงของสไลด์แรกในงานนำเสนอใหม่ที่สร้างขึ้น 
3. เพิ่มวัตถุ `AutoShape` โดยตั้งค่า `ShapeType` เป็น `Rectangle` ที่ตำแหน่งที่ระบุบนสไลด์และรับอ้างอิงของวัตถุ AutoShape ที่เพิ่มใหม่ 
4. เพิ่ม `TextFrame` ให้กับวัตถุ `AutoShape` ที่มีข้อความเริ่มต้นเป็น *Aspose TextBox* 
5. สร้างอินสแตนซ์ของคลาส `IHyperlinkManager` 
6. กำหนดวัตถุ `IHyperlinkManager` ให้กับเมธอด [set_HyperlinkClick](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.shape#a617f857c862b71ac2093ed7866677a5c) ที่เชื่อมกับส่วนที่ต้องการของ `TextFrame` 
7. สุดท้ายให้เขียนไฟล์ PPTX ผ่านวัตถุ `Presentation` 

โค้ด C++ นี้—การลงมือทำตามขั้นตอนข้างต้น—แสดงวิธีเพิ่มช่องข้อความพร้อมไฮเปอร์ลิงก์ลงในสไลด์:

```cpp
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์ PPTX
auto presentation = System::MakeObject<Presentation>();

// ดึงสไลด์แรกในงานนำเสนอ
auto slide = presentation->get_Slides()->idx_get(0);

// เพิ่มอ็อบเจกต์ AutoShape โดยตั้งค่าชนิดเป็น Rectangle
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 150.0f, 150.0f, 50.0f);

// แคสรูปทรงเป็น AutoShape
auto autoShape = System::ExplicitCast<IAutoShape>(shape);

// เข้าถึงคุณสมบัติ ITextFrame ที่เชื่อมกับ AutoShape
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();

// เพิ่มข้อความบางส่วนลงในเฟรม
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->set_Text(u"Aspose.Slides");

// ตั้งค่า Hyperlink สำหรับข้อความส่วน
auto linkManager = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_HyperlinkManager();
linkManager->SetExternalHyperlinkClick(u"http://www.aspose.com");

// บันทึกงานนำเสนอ PPTX
presentation->Save(u"hLinkPPTX_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**ความแตกต่างระหว่างช่องข้อความกับตัวจัดตำแหน่งข้อความเมื่อทำงานกับสไลด์แม่คืออะไร?**

[placeholder](/slides/th/cpp/manage-placeholder/) สืบทอดสไตล์/ตำแหน่งจาก [master](https://reference.aspose.com/slides/th/cpp/aspose.slides/masterslide/) และสามารถถูกเปลี่ยนแปลงใน [layouts](https://reference.aspose.com/slides/th/cpp/aspose.slides/layoutslide/) ได้ ในขณะที่ช่องข้อความปกติเป็นออบเจกต์อิสระบนสไลด์เฉพาะและไม่เปลี่ยนแปลงเมื่อสลับเลย์เอาต์

**จะทำการแทนที่ข้อความจำนวนมากทั่วทั้งงานนำเสนอโดยไม่กระทบข้อความในแผนภูมิ ตาราง หรือ SmartArt อย่างไร?**

จำกัดการวนลูปให้กับออโตช์เพมที่มี TextFrame และละเว้นออบเจกต์ที่ฝังอยู่ ([charts](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/th/cpp/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/th/cpp/aspose.slides.smartart/smartart/)) โดยแยกคอลเลกชันเหล่านี้ออกจากกันหรือข้ามประเภทออบเจกต์ดังกล่าว