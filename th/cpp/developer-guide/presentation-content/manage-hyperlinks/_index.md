---
title: จัดการไฮเปอร์ลิงก์การนำเสนอใน C++
linktitle: จัดการไฮเปอร์ลิงก์
type: docs
weight: 20
url: /th/cpp/manage-hyperlinks/
keywords:
- เพิ่ม URL
- เพิ่มไฮเปอร์ลิงก์
- สร้างไฮเปอร์ลิงก์
- จัดรูปแบบไฮเปอร์ลิงก์
- ลบไฮเปอร์ลิงก์
- อัปเดตไฮเปอร์ลิงก์
- ไฮเปอร์ลิงก์ข้อความ
- ไฮเปอร์ลิงก์สไลด์
- ไฮเปอร์ลิงก์รูปทรง
- ไฮเปอร์ลิงก์รูปภาพ
- ไฮเปอร์ลิงก์วิดีโอ
- ไฮเปอร์ลิงก์ที่แก้ไขได้
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "เพิ่ม, จัดรูปแบบ, อัปเดต, และลบไฮเปอร์ลิงก์ในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ C++ โดยใช้ตัวอย่าง C++"
---
## **บทนำ**

ไฮเปอร์ลิงก์เชื่อมต่อเนื้อหาในงานนำเสนอกับเว็บไซต์หรือที่ตั้งภายในงานนำเสนอ ใน PowerPoint ไฮเปอร์ลิงก์มักใช้เพื่อวัตถุประสงค์สองอย่าง:

* เปิดเว็บไซต์จากข้อความ รูปทรง หรือกรอบสื่อ
* ไปยังสไลด์อื่น ตัวอย่างเช่น จากสารบัญ

Aspose.Slides for C++ ให้คุณเพิ่มลิงก์เหล่านี้ ควบคุมลักษณะและเสียงของมัน ปรับปรุงการตั้งค่า และลบออก ตัวอย่างด้านล่างแสดงวิธีทำงานกับไฮเปอร์ลิงก์บนแต่ละองค์ประกอบและวิธีเข้าถึงไฮเปอร์ลิงก์ในระดับงานนำเสนอ สไลด์ หรือกรอบข้อความ

{{% alert color="info" title="Note" %}}
คุณยังสามารถแก้ไขงานนำเสนอด้วย [free online Aspose PowerPoint editor](https://products.aspose.app/slides/th/editor) ได้เช่นกัน
{{% /alert %}} 

## **เพิ่มไฮเปอร์ลิงก์ URL**

คุณสามารถกำหนด URL ของเว็บไซต์ไปยังข้อความ รูปทรง หรือกรอบสื่อได้ ส่วนที่คุณกำหนดไฮเปอร์ลิงก์จะเป็นพื้นที่ที่คลิกได้: ส่วนข้อความจะลิงก์ข้อความที่เลือก ส่วนรูปทรงหรือกรอบจะลิงก์อ็อบเจกต์สไลด์

### **เพิ่มไฮเปอร์ลิงก์ URL ไปยังข้อความ**

เพื่อเชื่อมข้อความกับเว็บไซต์ ให้สร้าง [Hyperlink](https://reference.aspose.com/slides/th/cpp/aspose.slides/hyperlink/) และกำหนดด้วยเมธอด [set_HyperlinkClick](https://reference.aspose.com/slides/th/cpp/aspose.slides/portionformat/set_hyperlinkclick/) ของส่วนข้อความ ตามตัวอย่างด้านล่าง เพียงส่วนข้อความนั้นเท่านั้นที่กลายเป็นคลิกได้

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto textShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
textShape->AddTextFrame(u"Aspose: File Format APIs");
auto portionFormat = textShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
portionFormat->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
portionFormat->get_HyperlinkClick()->set_Tooltip(u"Explore Aspose file format APIs");
portionFormat->set_FontHeight(32);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

### **เพิ่มไฮเปอร์ลิงก์ URL ไปยังรูปทรงและกรอบสื่อ**

เพื่อให้รูปทรงหรือกรอบสามารถคลิกได้ ให้ใช้เมธอด [set_HyperlinkClick](https://reference.aspose.com/slides/th/cpp/aspose.slides/shape/set_hyperlinkclick/) ของอ็อบเจกต์นั้น ไฮเปอร์ลิงก์เป็นของอ็อบเจกต์เอง ไม่ใช่ของส่วนข้อความภายใน

แนวทางเดียวกันใช้กับรูปภาพ, ไฟล์เสียง, และวิดีโอ: กำหนดไฮเปอร์ลิงก์ให้กับกรอบและใช้ [set_Tooltip](https://reference.aspose.com/slides/th/cpp/aspose.slides/ihyperlink/set_tooltip/) เพื่อเพิ่มคำแนะนำหากต้องการ

ตัวอย่างต่อไปทำให้สี่เหลี่ยมคลิกได้:

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);

shape->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape->get_HyperlinkClick()->set_Tooltip(u"Explore Aspose file format APIs");

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

## **ใช้ไฮเปอร์ลิงก์เพื่อสร้างสารบัญ**

ไฮเปอร์ลิงก์ภายในทำให้ผู้อ่านกระโดดจากสารบัญไปยังสไลด์เฉพาะ ตัวอย่างต่อไปใช้ [SetInternalHyperlinkClick](https://reference.aspose.com/slides/th/cpp/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) เพื่อเชื่อมข้อความ “Page 2” บนสไลด์แรกไปยังสไลด์ที่สอง

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);
auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto tableOfContents = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
tableOfContents->get_FillFormat()->set_FillType(FillType::NoFill);
tableOfContents->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
tableOfContents->get_TextFrame()->get_Paragraphs()->Clear();

auto paragraph = System::MakeObject<Paragraph>();
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
paragraph->set_Text(u"Title of slide 2 .......... ");

auto linkPortion = System::MakeObject<Portion>();
linkPortion->set_Text(u"Page 2");
linkPortion->get_PortionFormat()->get_HyperlinkManager()->SetInternalHyperlinkClick(secondSlide);

paragraph->get_Portions()->Add(linkPortion);
tableOfContents->get_TextFrame()->get_Paragraphs()->Add(paragraph);

presentation->Save(u"link_to_slide.pptx", SaveFormat::Pptx);
```

## **จัดรูปแบบไฮเปอร์ลิงก์**

### **สี**

เมธอด [set_ColorSource](https://reference.aspose.com/slides/th/cpp/aspose.slides/ihyperlink/set_colorsource/) ของ [IHyperlink](https://reference.aspose.com/slides/th/cpp/aspose.slides/ihyperlink/) กำหนดว่าไฮเปอร์ลิงก์จะใช้สีไฮเปอร์ลิงก์ของงานนำเสนอหรือการฟอร์แมตของส่วนข้อความ เพื่อใช้สีข้อความกำหนดเอง ให้เลือก [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/th/cpp/aspose.slides/hyperlinkcolorsource/) แล้วตั้งค่าสีเติมของส่วนนั้น ฟีเจอร์นี้มีตั้งแต่ PowerPoint 2019; เวอร์ชันเก่าจะไม่ใช้การตั้งค่านี้

ตัวอย่างต่อไปเพิ่มไฮเปอร์ลิงก์ข้อความสองรายการบนสไลด์เดียว รายการแรกใช้สีเติมข้อความสีแดง ส่วนรายการที่สองใช้สีไฮเปอร์ลิงก์เริ่มต้น

```cpp
#include <DOM/FillType.h>
#include <DOM/Hyperlink.h>
#include <DOM/HyperlinkColorSource.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IHyperlink.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto coloredShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
coloredShape->AddTextFrame(u"This hyperlink uses a custom color.");
auto coloredPortionFormat = coloredShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
coloredPortionFormat->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
coloredPortionFormat->get_HyperlinkClick()->set_ColorSource(HyperlinkColorSource::PortionFormat);
coloredPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
coloredPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

auto defaultShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
defaultShape->AddTextFrame(u"This hyperlink uses the default color.");
defaultShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));

presentation->Save(u"presentation-out-hyperlink.pptx", SaveFormat::Pptx);
```

### **เสียง**

ไฮเปอร์ลิงก์สามารถเล่นเสียงเมื่อเปิดใช้งานหรือหยุดเสียงที่กำลังเล่นอยู่ ใช้เมธอดต่อไปนี้เพื่อกำหนดพฤติกรรมเหล่านั้น:

- [IHyperlink::set_Sound](https://reference.aspose.com/slides/th/cpp/aspose.slides/ihyperlink/set_sound/) ระบุออดิโอที่เชื่อมโยงกับไฮเปอร์ลิงก์
- [IHyperlink::set_StopSoundOnClick](https://reference.aspose.com/slides/th/cpp/aspose.slides/ihyperlink/set_stopsoundonclick/) ควบคุมว่าการเปิดไฮเปอร์ลิงก์จะหยุดเสียงก่อนหน้าหรือไม่

#### **เพิ่มเสียงไฮเปอร์ลิงก์**

ตัวอย่างต่อไปโหลด `sampleaudio.wav` แล้วผูกกับปุ่มบนสไลด์แรก คลิกปุ่มจะเล่นเสียงและไปยังสไลด์ถัดไป รูปร่างที่สองบนสไลด์นั้นจะหยุดเสียงก่อนหน้าเมื่อคลิก โดยไม่ทำการนำทางใด ๆ

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAudio.h>
#include <DOM/IAudioCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto audioData = System::IO::File::ReadAllBytes(u"sampleaudio.wav");
auto hyperlinkSound = presentation->get_Audios()->AddAudio(audioData);

auto firstSlide = presentation->get_Slide(0);

auto playButton = firstSlide->get_Shapes()->AddAutoShape(ShapeType::SoundButton, 100, 100, 100, 50);
playButton->set_HyperlinkClick(Hyperlink::get_NextSlide());

if (!playButton->get_HyperlinkClick()->get_StopSoundOnClick() && playButton->get_HyperlinkClick()->get_Sound() == nullptr)
{
    playButton->get_HyperlinkClick()->set_Sound(hyperlinkSound);
}

auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto stopButton = secondSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 100, 50);
stopButton->set_HyperlinkClick(Hyperlink::get_NoAction());

stopButton->get_HyperlinkClick()->set_StopSoundOnClick(true);

presentation->Save(u"hyperlink-sound.pptx", SaveFormat::Pptx);
```

#### **ดึงเสียงไฮเปอร์ลิงก์**

ตัวอย่างต่อไปเปิดงานนำเสนอที่สร้างไว้ข้างต้นและอ่านออดิโอของไฮเปอร์ลิงก์รูปแรกเข้าสู่หน่วยความจำผ่าน [get_Sound](https://reference.aspose.com/slides/th/cpp/aspose.slides/ihyperlink/get_sound/) และ [get_BinaryData](https://reference.aspose.com/slides/th/cpp/aspose.slides/iaudio/get_binarydata/)

```cpp
#include <DOM/IAudio.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"hyperlink-sound.pptx");

if (presentation->get_Slides()->get_Count() > 0 && presentation->get_Slide(0)->get_Shapes()->get_Count() > 0)
{
    auto hyperlink = presentation->get_Slide(0)->get_Shape(0)->get_HyperlinkClick();
    auto sound = hyperlink != nullptr ? hyperlink->get_Sound() : nullptr;
    if (sound != nullptr)
    {
        auto audioData = sound->get_BinaryData();
        System::Console::WriteLine(u"Extracted {0} bytes of hyperlink audio.", audioData->get_Length());
    }
    else
    {
        System::Console::WriteLine(u"The first shape has no hyperlink sound.");
    }
}
else
{
    System::Console::WriteLine(u"The presentation has no first slide or shape to inspect.");
}
```

### **การตั้งค่า Tooltip และการโต้ตอบ**

หลังจากกำหนดไฮเปอร์ลิงก์ให้กับข้อความหรือรูปทรง คุณสามารถอัปเดตการตั้งค่า [IHyperlink](https://reference.aspose.com/slides/th/cpp/aspose.slides/ihyperlink/) ต่อไปนี้ได้ด้วยเมธอดเหล่านี้:

- [set_Tooltip](https://reference.aspose.com/slides/th/cpp/aspose.slides/ihyperlink/set_tooltip/) ตั้งข้อความที่ผู้ชมสามารถแสดงเป็นคำแนะนำสำหรับลิงก์
- [set_TargetFrame](https://reference.aspose.com/slides/th/cpp/aspose.slides/ihyperlink/set_targetframe/) ระบุกรอบเป้าหมายภายในเฟรมชุด HTML พ่อแม่ เมื่อมีความเกี่ยวข้อง
- [set_History](https://reference.aspose.com/slides/th/cpp/aspose.slides/ihyperlink/set_history/) ควบคุมว่าการเปิดลิงก์จะเพิ่มจุดหมายลงในรายการไฮเปอร์ลิงก์ที่เคยดูหรือไม่
- [set_HighlightClick](https://reference.aspose.com/slides/th/cpp/aspose.slides/ihyperlink/set_highlightclick/) ควบคุมว่าการคลิกไฮเปอร์ลิงก์จะทำให้ไฮเปอร์ลิงก์ถูกไฮไลท์หรือไม่

## **ลบไฮเปอร์ลิงก์ออกจากงานนำเสนอ**

ใช้ [GetAnyHyperlinks](https://reference.aspose.com/slides/th/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) เพื่อรวบรวมคอนเทนเนอร์ของไฮเปอร์ลิงก์รวมถึงลิงก์ส่วนข้อความก่อนทำการเปลี่ยนแปลง ตัวอย่างต่อไปลบประเภทการเปิดใช้งานทั้งสองจากสไลด์แรก หากต้องการลบเพียงประเภทเดียว ให้เรียกใช้เฉพาะ [RemoveHyperlinkClick](https://reference.aspose.com/slides/th/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) หรือ [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/th/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/) การลบการคลิกจะไม่ลบการเมาส์โอเวอร์ที่สอดคล้องกัน

```cpp
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

if (presentation->get_Slides()->get_Count() > 0)
{
    auto containers = presentation->get_Slide(0)->get_HyperlinkQueries()->GetAnyHyperlinks();
    for (const auto& container : containers)
    {
        container->get_HyperlinkManager()->RemoveHyperlinkClick();
        container->get_HyperlinkManager()->RemoveHyperlinkMouseOver();
    }
    presentation->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
}
else
{
    System::Console::WriteLine(u"The presentation has no slides to process.");
}
```

สำหรับการลบโดยไม่มีเงื่อนไข [RemoveAllHyperlinks](https://reference.aspose.com/slides/th/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) จะลบประเภทการเปิดใช้งานทั้งสองในขอบเขตที่เลือกด้วยการเรียกครั้งเดียว สำหรับการทำความสะอาดเลือกเฉพาะและครอบคลุมมาสเตอร์, เลย์เอาต์, โน้ต ให้ดูที่ [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)

## **สร้างรายการไฮเปอร์ลิงก์อย่างครบถ้วน**

ก่อนแจกจ่ายงานนำเสนอ ควรทำรายการการกระทำเชิงโต้ตอบและลิงก์เว็บของมัน [GetAnyHyperlinks](https://reference.aspose.com/slides/th/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) จะคืนค่าอ็อบเจกต์ [IHyperlinkContainer](https://reference.aspose.com/slides/th/cpp/aspose.slides/ihyperlinkcontainer/) ไม่ใช่รายการแบนของสตริง URL ตรวจสอบทั้ง [get_HyperlinkClick](https://reference.aspose.com/slides/th/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkclick/) และ [get_HyperlinkMouseOver](https://reference.aspose.com/slides/th/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmouseover/) ในแต่ละคอนเทนเนอร์ พวกมันเป็นอิสระกัน: คอนเทนเนอร์เดียวกันอาจเปิดเผยการกระทำทั้งสอง ดังนั้นรายงานครบต้องมีสูงสุดสองแถวต่อคอนเทนเนอร์

การสแกนไฮเปอร์ลิงก์ระดับรูปทรงเท่านั้นอาจพลาดลิงก์ที่แนบกับส่วนข้อความ ให้ทำคิวรีในขอบเขตที่เหมาะสมแทน และเก็บคอนเทนเนอร์ที่คืนกลับไว้เพื่อที่ภายหลังจะอัปเดตหรือถอนการกระทำได้

### **คิวรีขอบเขต Presentation, Slide, และ Text-Frame**

อินเทอร์เฟซ [IHyperlinkQueries](https://reference.aspose.com/slides/th/cpp/aspose.slides/ihyperlinkqueries/) มีให้ผ่าน [IPresentation::get_HyperlinkQueries](https://reference.aspose.com/slides/th/cpp/aspose.slides/ipresentation/get_hyperlinkqueries/), [IBaseSlide::get_HyperlinkQueries](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibaseslide/get_hyperlinkqueries/), และ [ITextFrame::get_HyperlinkQueries](https://reference.aspose.com/slides/th/cpp/aspose.slides/itextframe/get_hyperlinkqueries/). แต่ละขอบเขตสนับสนุนคิวรีเดียวกัน:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/th/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) คืนคอนเทนเนอร์ที่มีการคลิก
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/th/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) คืนคอนเทนเนอร์ที่มีการเมาส์โอเวอร์
- [GetAnyHyperlinks](https://reference.aspose.com/slides/th/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) คืนคอนเทนเนอร์ที่มีหนึ่งหรือสองการกระทำใดก็ตาม

ตัวอย่างต่อไปสร้าง `hyperlink-audit-input.pptx` พร้อมลิงก์คลิกภายนอก, ลิงก์เมาส์โอเวอร์ไฟล์, การนำทางสไลด์ภายใน, ลิงก์เมาส์โอเวอร์ข้อความ, และการกระทำแมโคร โดยไม่ทำการเรียกใช้ใด ๆ คิวรีสามแบบทำงานที่ทุกขอบเขต; จำนวนที่แสดงเป็นจำนวนคอนเทนเนอร์ ไม่ใช่จำนวนการกระทำ ขอบเขต Text-Frame ไม่รวมลิงก์ของรูปทรงที่ครอบมันอยู่

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
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
#include <system/console.h>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto printCounts = [](System::String scope, System::SharedPtr<IHyperlinkQueries> queries)
{
    auto clickContainers = queries->GetHyperlinkClicks();
    auto mouseOverContainers = queries->GetHyperlinkMouseOvers();
    auto allContainers = queries->GetAnyHyperlinks();
    System::Console::WriteLine(u"{0}: click={1}, mouse-over={2}, any={3}", scope, clickContainers->get_Count(), mouseOverContainers->get_Count(), allContainers->get_Count());
};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto destination = presentation->get_Slides()->AddEmptySlide(slide->get_LayoutSlide());
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
shape->get_TextFrame()->set_Text(u"Click the text to go to slide 2");
shape->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://example.com/");
shape->get_HyperlinkClick()->set_Tooltip(u"Public website");
shape->get_HyperlinkManager()->SetExternalHyperlinkMouseOver(u"file:///C:/private/report.xlsx");

auto portionFormat = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
portionFormat->get_HyperlinkManager()->SetInternalHyperlinkClick(destination);
portionFormat->get_HyperlinkManager()->SetExternalHyperlinkMouseOver(u"https://example.com/help");
auto macroButton = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 120, 200, 60);
macroButton->get_HyperlinkManager()->SetMacroHyperlinkClick(u"ReviewPresentation");

printCounts(u"Presentation", presentation->get_HyperlinkQueries());
printCounts(u"Slide 1", slide->get_HyperlinkQueries());
printCounts(u"Text frame", shape->get_TextFrame()->get_HyperlinkQueries());
presentation->Save(u"hyperlink-audit-input.pptx", SaveFormat::Pptx);
```

สำหรับตัวอย่างนี้ คิวรีระดับงานนำเสนอและสไลด์แต่ละอันรายงานคอนเทนเนอร์คลิก 3 รายการ, คอนเทนเนอร์เมาส์โอเวอร์ 2 รายการ, และคอนเทนเนอร์ที่มีหนึ่งในสองการกระทำ 3 รายการ ส่วนคิวรี Text-Frame รายงานคอนเทนเนอร์หนึ่งรายการในแต่ละประเภท

### **จัดประเภทการกระทำและปลายทาง**

ใช้ [IHyperlink::get_ActionType](https://reference.aspose.com/slides/th/cpp/aspose.slides/ihyperlink/get_actiontype/) เพื่อแปลความหมายของการกระทำก่อนแปลความหมายของปลายทาง ค่า [HyperlinkActionType](https://reference.aspose.com/slides/th/cpp/aspose.slides/hyperlinkactiontype/) ครอบคลุมมากกว่าการนำทางเว็บ:

| ค่า | ความหมายสำหรับการตรวจสอบ |
| --- | --- |
| `Hyperlink` | ไฮเปอร์ลิงก์ภายนอก; ตรวจสอบ URL และสคีมของมัน |
| `JumpSpecificSlide` | การนำทางภายในไปยังสไลด์เฉพาะ |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | การนำทางสไลด์โชว์ในตัว, แก้ไขในบริบทสไลด์โชว์ |
| `JumpEndShow`, `StartCustomSlideShow` | สิ้นสุดการแสดงปัจจุบันหรือเริ่มการแสดงแบบกำหนดเอง |
| `StartMacro` | เรียกใช้แมโคร |
| `StartProgram` | เปิดโปรแกรม |
| `OpenFile`, `OpenPresentation` | เปิดไฟล์หรือการนำเสนออื่น; ตรวจสอบแยกจาก URL เว็บ |
| `StartStopMedia` | เริ่มหรือหยุดการเล่นสื่อ |
| `NoAction`, `Unknown` | ไม่มีการนำทางหรือการกระทำที่ไม่รู้จักต้องตรวจสอบ |

อ่านปลายทางภายนอกจาก [get_ExternalUrl](https://reference.aspose.com/slides/th/cpp/aspose.slides/ihyperlink/get_externalurl/) และปลายทางภายในเฉพาะจาก [get_TargetSlide](https://reference.aspose.com/slides/th/cpp/aspose.slides/ihyperlink/get_targetslide/). การกระทำภายในและคำสั่งในตัวอาจไม่มี URL ภายนอก; URL ว่างไม่หมายความว่าคอนเทนเนอร์ไม่มีการกระทำ ให้เก็บ [get_ExternalUrlOriginal](https://reference.aspose.com/slides/th/cpp/aspose.slides/ihyperlink/get_externalurloriginal/) เมื่อแตกต่างจาก URL ที่ทำให้เป็นมาตรฐาน และรวม tooltip ที่คืนจาก [get_Tooltip](https://reference.aspose.com/slides/th/cpp/aspose.slides/ihyperlink/get_tooltip/) หากมี

### **รายงาน, ทำความสะอาด, และตรวจสอบไฮเปอร์ลิงก์**

ตัวอย่าง C++ ต่อไปอ่านงานนำเสนอที่มีอยู่ (ใช้ไฟล์ที่สร้างข้างบน) เขียน `hyperlink-audit.json` ใช้มาตรการ นำออกเป็น `hyperlink-sanitized.pptx` และเปิดใหม่เพื่อตรวจสอบประเภทการเปิดใช้งานอีกครั้ง ตัวอย่างนี้รวบรวมคอนเทนเนอร์ก่อนทำการเปลี่ยนแปลงและใช้เอกลักษณ์ของพอยเตอร์เพื่อหลีกเลี่ยงการประมวลผลคอนเทนเนอร์ซ้ำ คิวรีงานนำเสนอครอบคลุมสไลด์ทั่วไป; สำหรับการสำรวจระดับแพคเกจ ยังทำคิวรีมาสเตอร์, เลย์เอาต์, โน้ต, และมาสเตอร์โน้ต/แฮนด์เอาท์เมื่อมี

รายงานบันทึกดัชนีสไลด์ตั้งแต่ 1 และ [get_SlideId](https://reference.aspose.com/slides/th/cpp/aspose.slides/ibaseslide/get_slideid/) หากมี [ISlideComponent::get_Slide](https://reference.aspose.com/slides/th/cpp/aspose.slides/islidecomponent/get_slide/) จัดหาสไลด์เจ้าของสำหรับคอนเทนเนอร์ที่รองรับ มาสเตอร์, เลย์เอาต์, และโน้ตไม่มีดัชนีสไลด์ปกติและจะระบุด้วยขอบเขตของมันเอง คอนเทนเนอร์รูปทรงและคอนเทนเนอร์การฟอร์แมตส่วนข้อความจะถูกตั้งชื่อแยกกัน; ประเภทคอนเทนเนอร์อื่นจะรักษาชื่อชนิดเวลารันแต่ละตัว คอนเทนเนอร์แต่ละตัวจะได้รับ ID ภายในรายงานเพื่อให้สามารถเชื่อมโยงการกระทำสองอย่างได้

นโยบายแอปพลิเคชันที่เข้มงวดนี้ยอมรับเฉพาะ URL HTTPS แบบเต็มรูปแบบและเป้าหมายสไลด์ภายในที่ถูกต้อง จะปฏิเสธแมโคร, โปรแกรม, การกระทำไฟล์, การกระทำสไลด์โชว์อื่น ๆ, การกระทำที่ไม่รู้จัก, และสกีม URL อื่น ๆ การปฏิเสธเหล่านี้เป็นการตัดสินใจของนโยบาย ไม่ได้เป็นการประเมินความปลอดภัยของ Aspose.Slides HTTPS เพียงอย่างเดียวไม่สร้างความเชื่อถือ: เพิ่มรายการอนุญาตโฮสต์และการตรวจสอบอื่น ๆ สำหรับแอปของคุณ ทั้ง URL ภายนอกดั้งเดิมและที่ทำให้เป็นมาตรฐานจะถูกตรวจสอบ ตัวอย่างตรวจสอบเมตาดาต้าโดยไม่เปิดลิงก์หรือรันการกระทำ

เพื่อแก้ไข คอนเทนเนอร์ของ [get_HyperlinkManager](https://reference.aspose.com/slides/th/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmanager/) รองรับ [SetExternalHyperlinkClick](https://reference.aspose.com/slides/th/cpp/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/th/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/), และ [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/th/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). ที่นี่ ลิงก์คลิกภายนอกที่ห้ามจะถูกแทนที่ด้วยหน้า HTTPS คงที่; คลิกที่ห้ามอื่น ๆ และการเมาส์โอเวอร์ที่ห้ามจะถูกลบแยกกัน ตั้งค่า `replaceExternalClicks` เป็น `false` เพื่อเอาการละเมิดนโยบายทั้งหมดออก เลือกหน้าทดแทนที่เป็นของแอปก่อนการปรับใช้

ฟลักสำหรับการส่งออกของรายงานใช้แนวทางทบทวน PDF อย่างระมัดระวัง: ทำเครื่องหมายการเมาส์โอเวอร์และทุกอย่างที่ไม่ใช่ลิงก์ภายนอกหรือการกระโดดสไลด์เฉพาะว่าอาจไม่รองรับ เป็นการแนะนำการทบทวน ไม่ใช่การทดสอบความสามารถหรือการรับรองว่าลิงก์ที่ไม่ได้ทำเครื่องหมายจะยังคงอยู่ในการส่งออก การส่งออก PDF และ HTML ที่รองรับอาจเก็บไฮเปอร์ลิงก์ไว้ ขึ้นอยู่กับการกระทำ, ตัวเลือกการส่งออก, และโปรแกรมอ่านภาพ raster เช่น PNG หรือวิดีโอย่อมไม่สามารถเก็บไฮเปอร์ลิงก์เชิงโต้ตอบ; ควรทำเครื่องหมายทุกการกระทำเมื่อทำการตรวจสอบสำหรับเอาต์พุตเหล่านั้น

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/HyperlinkActionType.h>
#include <DOM/IBaseSlide.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IHyperlink.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/INotesSlide.h>
#include <DOM/INotesSlideManager.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPresentation.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideComponent.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/uri.h>
#include <system/environment.h>
#include <fstream>
#include <sstream>
#include <iomanip>
#include <vector>
#include <unordered_set>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const auto replaceExternalClicks = true;
const System::String replacementUrl = u"https://example.com/blocked-link";
auto presentation = System::MakeObject<Presentation>(u"hyperlink-audit-input.pptx");

auto collectContainers = [](System::SharedPtr<IPresentation> source)
{
    std::vector<System::SharedPtr<IHyperlinkContainer>> found;
    std::unordered_set<IHyperlinkContainer*> seen;
    auto addQueries = [&](System::SharedPtr<IHyperlinkQueries> queries)
    {
        auto containers = queries->GetAnyHyperlinks();
        for (const auto& container : containers)
        {
            if (seen.insert(container.get()).second) found.push_back(container);
        }
    };
    auto addScope = [&](System::SharedPtr<IBaseSlide> slide)
    {
        if (slide != nullptr) addQueries(slide->get_HyperlinkQueries());
    };
    addQueries(source->get_HyperlinkQueries());
    for (const auto& master : source->get_Masters()) addScope(master);
    for (const auto& layout : source->get_LayoutSlides()) addScope(layout);
    for (const auto& slide : source->get_Slides()) addScope(slide->get_NotesSlideManager()->get_NotesSlide());
    addScope(source->get_MasterNotesSlideManager()->get_MasterNotesSlide());
    addScope(source->get_MasterHandoutSlideManager()->get_MasterHandoutSlide());
    return found;
};

auto isHttps = [](System::String value)
{
    System::SharedPtr<System::Uri> uri;
    return System::Uri::TryCreate(value, System::UriKind::Absolute, uri) && uri->get_Scheme() == System::Uri::UriSchemeHttps;
};
auto policyViolation = [&](System::SharedPtr<IHyperlink> link) -> System::String
{
    if (link == nullptr) return u"";
    if (link->get_ActionType() == HyperlinkActionType::JumpSpecificSlide)
    {
        return link->get_TargetSlide() == nullptr ? u"Missing target slide" : u"";
    }
    if (link->get_ActionType() != HyperlinkActionType::Hyperlink) return u"Action is not allowed";
    if (!isHttps(link->get_ExternalUrl())) return u"Normalized URL is not absolute HTTPS";
    auto original = link->get_ExternalUrlOriginal();
    if (!original.IsNullOrEmpty() && !isHttps(original)) return u"Original URL is not absolute HTTPS";
    return u"";
};
auto slideIndex = [&](System::SharedPtr<IBaseSlide> slide)
{
    for (auto index = 0; index < presentation->get_Slides()->get_Count(); index++)
    {
        if (presentation->get_Slide(index) == slide) return index + 1;
    }
    return 0;
};
auto jsonString = [](System::String value)
{
    std::ostringstream escaped;
    escaped << '"';
    for (unsigned char character : value.ToUtf8String())
    {
        if (character == '"' || character == '\\') escaped << '\\' << character;
        else if (character < 0x20) escaped << "\\u" << std::hex << std::setw(4) << std::setfill('0') << static_cast<int>(character);
        else escaped << character;
    }
    escaped << '"';
    return escaped.str();
};
auto containers = collectContainers(presentation);
std::ofstream report("hyperlink-audit.json", std::ios::binary);
if (!report)
{
    System::Console::WriteLine(u"Cannot open the audit report for writing.");
    System::Environment::set_ExitCode(1);
    return;
}
auto rowCount = 0;
report << "[\n";
auto addRow = [&](System::SharedPtr<IHyperlink> link, System::String activation, System::SharedPtr<IHyperlinkContainer> container, size_t containerId)
{
    if (link == nullptr) return;
    auto component = System::AsCast<ISlideComponent>(container);
    auto ownerSlide = component != nullptr ? component->get_Slide() : nullptr;
    auto targetSlide = link->get_TargetSlide();
    auto violation = policyViolation(link);
    auto shape = System::AsCast<IShape>(container);
    auto portionFormat = System::AsCast<IPortionFormat>(container);
    auto ownerType = shape != nullptr ? System::String(u"Shape") : portionFormat != nullptr ? System::String(u"Text portion") : container->GetType().get_Name();
    auto ordinaryAction = link->get_ActionType() == HyperlinkActionType::Hyperlink || link->get_ActionType() == HyperlinkActionType::JumpSpecificSlide;
    auto ownerIndex = slideIndex(ownerSlide);
    auto targetIndex = slideIndex(targetSlide);
    if (rowCount++ != 0) report << ",\n";
    report << "  {\"ContainerId\":" << containerId;
    report << ",\"SlideIndex\":" << (ownerIndex != 0 ? std::to_string(ownerIndex) : "null");
    report << ",\"SlideId\":" << (ownerSlide != nullptr ? std::to_string(ownerSlide->get_SlideId()) : "null");
    report << ",\"Scope\":" << (ownerSlide != nullptr ? jsonString(ownerSlide->GetType().get_Name()) : "null");
    report << ",\"OwnerType\":" << jsonString(ownerType);
    report << ",\"Activation\":" << jsonString(activation);
    report << ",\"ActionType\":" << jsonString(System::ObjectExt::ToString(link->get_ActionType()));
    report << ",\"ExternalUrl\":" << jsonString(link->get_ExternalUrl());
    report << ",\"TargetSlideIndex\":" << (targetIndex != 0 ? std::to_string(targetIndex) : "null");
    report << ",\"TargetSlideId\":" << (targetSlide != nullptr ? std::to_string(targetSlide->get_SlideId()) : "null");
    report << ",\"Tooltip\":" << jsonString(link->get_Tooltip());
    report << ",\"OriginalExternalUrl\":" << (link->get_ExternalUrlOriginal() != link->get_ExternalUrl() ? jsonString(link->get_ExternalUrlOriginal()) : "null");
    report << ",\"PotentiallyUnsafe\":" << (!violation.IsNullOrEmpty() ? "true" : "false");
    report << ",\"PolicyViolation\":" << (!violation.IsNullOrEmpty() ? jsonString(violation) : "null");
    report << ",\"TargetExport\":\"PDF\",\"PotentiallyUnsupportedByExport\":" << (activation == u"mouse-over" || !ordinaryAction ? "true" : "false") << "}";
};
for (auto index = size_t{0}; index < containers.size(); index++)
{
    auto container = containers[index];
    addRow(container->get_HyperlinkClick(), u"click", container, index + 1);
    addRow(container->get_HyperlinkMouseOver(), u"mouse-over", container, index + 1);
}
report << "\n]\n";
report.close();
if (!report)
{
    System::Console::WriteLine(u"The audit report could not be written completely.");
    System::Environment::set_ExitCode(1);
    return;
}

for (const auto& container : containers)
{
    auto click = container->get_HyperlinkClick();
    if (!policyViolation(click).IsNullOrEmpty())
    {
        if (replaceExternalClicks && click->get_ActionType() == HyperlinkActionType::Hyperlink)
        {
            container->get_HyperlinkManager()->SetExternalHyperlinkClick(replacementUrl);
        }
        else
        {
            container->get_HyperlinkManager()->RemoveHyperlinkClick();
        }
    }
    if (!policyViolation(container->get_HyperlinkMouseOver()).IsNullOrEmpty())
    {
        container->get_HyperlinkManager()->RemoveHyperlinkMouseOver();
    }
}
presentation->Save(u"hyperlink-sanitized.pptx", SaveFormat::Pptx);
auto reopened = System::MakeObject<Presentation>(u"hyperlink-sanitized.pptx");
auto remainingContainers = collectContainers(reopened);
auto violations = 0;
for (const auto& container : remainingContainers)
{
    if (!policyViolation(container->get_HyperlinkClick()).IsNullOrEmpty()) violations++;
    if (!policyViolation(container->get_HyperlinkMouseOver()).IsNullOrEmpty()) violations++;
}
System::Console::WriteLine(u"Audit rows: {0}; prohibited actions after reopening: {1}", rowCount, violations);
if (violations != 0)
{
    System::Console::WriteLine(u"Verification failed: do not distribute the saved presentation.");
    System::Environment::set_ExitCode(1);
}
```

ด้วยอินพุตที่สร้างข้างบน รายงานมีแถวการกระทำห้าแถว ลิงก์เมาส์โอเวอร์ไฟล์และแมโครคลิกถูกลบ ส่วนลิงก์ HTTPS และการนำทางสไลด์ภายในยังคงอยู่ การตรวจสอบพิมพ์ว่าการกระทำที่ห้ามเป็นศูนย์ อินพุตที่มี URL คลิกภายนอกที่ห้ามก็ทำให้สาขาการแทนที่ทำงาน คอนเทนเนอร์ที่มีคลิกที่อนุญาตและเมาส์โอเวอร์ที่ห้ามจะเก็บการกระทำคลิกไว้

การทำความสะอาดแบบเลือกนี้แตกต่างจาก [RemoveAllHyperlinks](https://reference.aspose.com/slides/th/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) ซึ่งลบการกระทำทั้งสองในขอบเขตที่เลือกโดยไม่คำนึงถึงนโยบาย การตรวจสอบที่นี่ตรวจสอบเฉพาะการกระทำของไฮเปอร์ลิงก์; ไม่ได้ลบ VBA ที่ฝังอยู่, วัตถุ OLE, หรือเนื้อหาเชิงโต้ตอบอื่น ๆ และไม่ตรวจสอบไฟล์ PDF หรือ HTML ที่ส่งออก

## **FAQ**

**ฉันจะเชื่อมโยงไปยังส่วนหรือสไลด์แรกของส่วนได้อย่างไร?**

ส่วนใน PowerPoint จัดกลุ่มสไลด์ แต่ไฮเปอร์ลิงก์ภายในจะชี้ไปยังสไลด์เดียว เพื่อสร้างการนำทางไปยังส่วน ให้เชื่อมไปยังสไลด์แรกของส่วนนั้น

**ฉันสามารถแนบไฮเปอร์ลิงก์ให้กับองค์ประกอบมาสเตอร์สไลด์เพื่อให้ทำงานบนทุกสไลด์ได้หรือไม่?**

ได้ มาสเตอร์สไลด์และองค์ประกอบเลย์เอาต์สนับสนุนไฮเปอร์ลิงก์ ลิงก์บนองค์ประกอบเหล่านี้จะพร้อมใช้งานระหว่างการแสดงสไลด์บนสไลด์ที่ใช้มาสเตอร์หรือเลย์เอาต์นั้น

**ไฮเปอร์ลิงก์จะถูกเก็บไว้เมื่อส่งออกเป็น PDF, HTML, ภาพ หรือวิดีโอหรือไม่?**

การส่งออก PDF และ HTML ที่รองรับอาจเก็บไฮเปอร์ลิงก์ไว้ ส่วนภาพ raster และวิดีโอไม่สามารถเก็บไฮเปอร์ลิงก์เชิงโต้ตอบได้ ดูข้อพิจารณาการส่งออกใน [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)