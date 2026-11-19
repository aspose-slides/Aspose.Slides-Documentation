---
title: จัดการไฮเพอร์ลิงก์การนำเสนอใน C++
linktitle: จัดการไฮเพอร์ลิงก์
type: docs
weight: 20
url: /th/cpp/manage-hyperlinks/
keywords:
- เพิ่ม URL
- เพิ่มไฮเพอร์ลิงก์
- สร้างไฮเพอร์ลิงก์
- รูปแบบไฮเพอร์ลิงก์
- ลบไฮเพอร์ลิงก์
- อัปเดตไฮเพอร์ลิงก์
- ไฮเพอร์ลิงก์ข้อความ
- ไฮเพอร์ลิงก์สไลด์
- ไฮเพอร์ลิงก์รูปร่าง
- ไฮเพอร์ลิงก์รูปภาพ
- ไฮเพอร์ลิงก์วิดีโอ
- ไฮเพอร์ลิงก์ที่เปลี่ยนแปลงได้
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "เพิ่ม, รูปแบบ, อัปเดต และลบไฮเพอร์ลิงก์ในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ C++ โดยใช้ตัวอย่าง C++"
---
## **บทนำ**

ไฮเพอร์ลิงก์จะเชื่อมต่อเนื้อหาการนำเสนอไปยังเว็บไซต์หรือสถานที่ภายในการนำเสนอ. ใน PowerPoint, ไฮเพอร์ลิงก์มักใช้เพื่อจุดประสงค์สองประการ:

* เปิดเว็บไซต์จากข้อความ, รูปร่าง, หรือกรอบสื่อ.
* นำทางไปยังสไลด์อื่น, ตัวอย่างเช่น จากสารบัญ.

Aspose.Slides for C++ ช่วยให้คุณสามารถเพิ่มลิงก์เหล่านี้, ควบคุมล appearance และเสียง, ปรับปรุงการตั้งค่า, และลบออกได้. ตัวอย่างต่อไปนี้แสดงวิธีทำงานกับไฮเพอร์ลิงก์บนองค์ประกอบแต่ละอันและวิธีเข้าถึงไฮเพอร์ลิงก์ในระดับการนำเสนอ, สไลด์, หรือกรอบข้อความ.

{{% alert color="info" title="Note" %}}
คุณสามารถแก้ไขการนำเสนอด้วย [เครื่องมือแก้ไข PowerPoint ออนไลน์ฟรีของ Aspose](https://products.aspose.app/slides/editor).
{{% /alert %}}

## **เพิ่มไฮเพอร์ลิงก์ URL**

คุณสามารถกำหนด URL ของเว็บไซต์ให้กับข้อความ, รูปร่าง, หรือกรอบสื่อ. องค์ประกอบที่คุณกำหนดไฮเพอร์ลิงก์จะเป็นตัวกำหนดพื้นที่ที่คลิกได้: ส่วนของข้อความจะลิงก์ข้อความที่เลือก, ในขณะที่รูปร่างหรือกรอบจะลิงก์วัตถุสไลด์.

สำหรับการนำเสนอที่มีไฮเพอร์ลิงก์แบบสัมพันธ์, ดูที่ [จัดการฐานของไฮเพอร์ลิงก์](/slides/th/cpp/presentation-properties/#manage-the-hyperlink-base) เพื่ออ่าน, เปลี่ยน, หรือเคลียร์ฐานระดับเอกสาร.

### **เพิ่มไฮเพอร์ลิงก์ URL ไปยังข้อความ**

เพื่อเชื่อมข้อความกับเว็บไซต์, สร้าง [ไฮเพอร์ลิงก์](https://reference.aspose.com/slides/cpp/aspose.slides/hyperlink/) และกำหนดด้วยเมธอดของส่วนข้อความ [set_HyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/set_hyperlinkclick/) ตามตัวอย่างด้านล่าง. เฉพาะส่วนของข้อความนั้นเท่านั้นที่จะสามารถคลิกได้.

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

### **เพิ่มไฮเพอร์ลิงก์ URL ไปยังรูปร่างและกรอบสื่อ**

เรียกใช้ [set_HyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_hyperlinkclick/) บนสี่เหลี่ยมเพื่อให้พื้นที่ทั้งหมดสามารถคลิกได้. ใช้ [set_Tooltip](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_tooltip/) เพื่อให้ผู้อ่านเห็นคำแนะนำเกี่ยวกับจุดหมายเมื่อเมาส์อยู่เหนือสี่เหลี่ยม. ทั้งสองเมธอดนี้ยังใช้ได้กับกรอบรูปภาพ, เสียง, และวิดีโอ.

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

## **ใช้ไฮเพอร์ลิงก์เพื่อสร้างสารบัญ**

ไฮเพอร์ลิงก์ภายในช่วยให้ผู้อ่านกระโดดจากสารบัญไปยังสไลด์เฉพาะ. ตัวอย่างต่อไปนี้ใช้ [SetInternalHyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) เพื่อเชื่อมข้อความ “หน้า 2” บนสไลด์แรกไปยังสไลด์ที่สอง.

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

## **จัดรูปแบบไฮเพอร์ลิงก์**

คุณสามารถเปลี่ยนสีของข้อความที่ลิงก์, เล่นหรือหยุดเสียงเมื่อผู้อ่านเปิดลิงก์, และตั้งค่า tooltip ที่ปรากฏเมื่อเมาส์อยู่เหนือ.

### **สี**

เมธอด [set_ColorSource](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_colorsource/) ของ [IHyperlink](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/) กำหนดว่าจะใช้สีไฮเพอร์ลิงก์ของการนำเสนอหรือการจัดรูปแบบของส่วนข้อความ. เพื่อกำหนดสีข้อความแบบกำหนดเอง, เลือก [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/hyperlinkcolorsource/) แล้วตั้งค่าสีเติมของส่วน. ฟีเจอร์นี้เริ่มต้นใน PowerPoint 2019; รุ่นเก่าจะไม่ใช้งานการตั้งค่านี้.

ในตัวอย่างนี้, ลิงก์แรกใช้ [set_ColorSource](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_colorsource/) เพื่อแสดงสีเติมข้อความสีแดง. ลิงก์ที่สองคงสีไฮเพอร์ลิงก์ของการนำเสนอ.

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

ไฮเพอร์ลิงก์สามารถเล่นเสียงเมื่อเปิดหรือหยุดเสียงที่กำลังเล่นอยู่. ใช้เมธอดต่อไปนี้เพื่อกำหนดพฤติกรรม:

- [IHyperlink::set_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_sound/) ระบุไฟล์เสียงที่เชื่อมกับไฮเพอร์ลิงก์.
- [IHyperlink::set_StopSoundOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_stopsoundonclick/) ควบคุมว่าการเปิดไฮเพอร์ลิงก์จะหยุดเสียงก่อนหน้าหรือไม่.

#### **เพิ่มเสียงไฮเพอร์ลิงก์**

ปุ่มบนสไลด์แรกใช้ [set_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_sound/) เพื่อเล่นไฟล์ `sampleaudio.wav` เมื่อผู้อ่านคลิกเพื่อไปต่อ. บนสไลด์ที่สอง, ปุ่มแยกต่างหากใช้ [set_StopSoundOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_stopsoundonclick/) เพื่อหยุดการเล่นและคงผู้อ่านอยู่บนสไลด์นั้น.

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

#### **ดึงเสียงไฮเพอร์ลิงก์**

ตัวอย่างต่อไปนี้เปิดการนำเสนอที่สร้างขึ้นข้างบนและอ่านเสียงไฮเพอร์ลิงก์ของรูปร่างแรกเข้าสู่หน่วยความจำผ่าน [get_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_sound/) และ [get_BinaryData](https://reference.aspose.com/slides/cpp/aspose.slides/iaudio/get_binarydata/).

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

### **การตั้งค่าเครื่องมืออธิบายและการโต้ตอบ**

คุณสามารถอัปเดตการตั้งค่า [IHyperlink](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/) ต่อไปนี้ผ่านเมธอดเหล่านี้หลังจากกำหนดไฮเพอร์ลิงก์ให้กับข้อความหรือรูปร่าง:

- [set_Tooltip](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_tooltip/) ตั้งข้อความที่ผู้ชมสามารถแสดงเป็นคำแนะนำสำหรับลิงก์.
- [set_TargetFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_targetframe/) ระบุกล่องเฟรมเป้าหมายภายในชุดเฟรม HTML ของพาเรนต์, เมื่อใช้ได้.
- [set_History](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_history/) ควบคุมว่าการเปิดลิงก์จะเพิ่มจุดหมายลงในรายการไฮเพอร์ลิงก์ที่เคยดูหรือไม่.
- [set_HighlightClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_highlightclick/) ควบคุมว่ามีการไฮไลต์ไฮเพอร์ลิงก์เมื่อคลิกหรือไม่.

## **ลบไฮเพอร์ลิงก์ออกจากการนำเสนอ**

ใช้ [GetAnyHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) เพื่อรวบรวมคอนเทนเนอร์ของไฮเพอร์ลิงก์, รวมถึงลิงก์ส่วนข้อความ, ก่อนทำการเปลี่ยนแปลง. ตัวอย่างต่อไปนี้ลบทั้งสองประเภทการกระทำจากสไลด์แรก. หากต้องการลบเพียงประเภทเดียว, ให้เรียกใช้เพียง [RemoveHyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) หรือ [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/); การลบการคลิกจะไม่ลบการเมาส์โอเวอร์ที่สอดคล้องกัน.

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

สำหรับการลบโดยไม่มีเงื่อนไข, [RemoveAllHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) จะลบทั้งสองประเภทการกระทำในช่วงที่เลือกด้วยการเรียกครั้งเดียว. สำหรับการทำความสะอาดแบบเลือกและครอบคลุมมาสเตอร์, เลย์เอาต์, และโน้ต, ดูที่ [รายงาน, ทำความสะอาด, และตรวจสอบไฮเพอร์ลิงก์](#report-sanitize-and-verify-hyperlinks).

### **ล้างไฮเพอร์ลิงก์ก่อนแทนที่ข้อความ SmartArt**

เมื่อคุณแทนที่ย่อหน้าภายในโหนด SmartArt ที่มีอยู่, การล้างส่วนของข้อความอาจทำให้ไฮเพอร์ลิงก์เก่า仍ค้างอยู่. ดึงย่อหน้าผ่าน [ISmartArtNode::get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/get_textframe/). ก่อนล้างส่วน, เรียก [RemoveAllHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) ผ่าน [get_HyperlinkQueries](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_hyperlinkqueries/) บนกรอบข้อความของรูปร่างโหนดที่แสดงย่อหน้า. การกระทำนี้จะลบไฮเพอร์ลิงก์ทั้งหมดในกรอบนั้น, รวมถึงลิงก์ในย่อหน้าอื่น ๆ.

ตัวอย่างสมมติว่ารูปร่างที่สามบนสไลด์แรกเป็นกราฟิก SmartArt. ตัวอย่างจะแทนที่ย่อหน้าที่หนึ่งของโหนดที่สี่. ในการนำเสนอนี้, รูปร่างแรกของโหนดจะแสดงย่อหน้านั้น.

หลังจากเพิ่มส่วนทั้งสอง, ตัวอย่างจะอ่านการจัดรูปแบบที่มีผลของพวกมันด้วย [GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/geteffective/). เมธอด [get_HyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformateffectivedata/get_hyperlinkclick/) จะคืนค่าไฮเพอร์ลิงก์ใหม่สำหรับส่วนแรกและ `nullptr` สำหรับส่วนที่สอง.

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IHyperlink.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/ISmartArtShape.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>(u"SmartArtHyperlink.pptx");
auto slide = presentation->get_Slide(0);

auto smartArt = ExplicitCast<ISmartArt>(slide->get_Shape(2));
auto node = smartArt->get_NodeFromAll(3);
auto paragraph = node->get_TextFrame()->get_Paragraph(0);

node->get_Shape(0)->get_TextFrame()->get_HyperlinkQueries()->RemoveAllHyperlinks();
auto portions = paragraph->get_Portions();
portions->Clear();

auto link = MakeObject<Portion>(u"New reference");
auto destination = MakeObject<Hyperlink>(u"https://example.com/new");
link->get_PortionFormat()->set_HyperlinkClick(destination);
portions->Add(link);
auto text = MakeObject<Portion>(u" (updated)");
portions->Add(text);

auto firstAction = link->get_PortionFormat()->GetEffective()->get_HyperlinkClick();
auto secondAction = text->get_PortionFormat()->GetEffective()->get_HyperlinkClick();
Console::WriteLine(firstAction->get_ExternalUrl()); // https://example.com/new
Console::WriteLine(secondAction ? secondAction->get_ExternalUrl() : String(u"nullptr")); // nullptr
```

## **สร้างรายการไฮเพอร์ลิงก์ครบถ้วน**

ก่อนที่จะเผยแพร่การนำเสนอ, ควรทำรายการการกระทำเชิงโต้ตอบและลิงก์เว็บของมัน. [GetAnyHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) จะคืนออบเจกต์ [IHyperlinkContainer](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkcontainer/) ไม่ใช่รายการแบนของสตริง URL. ตรวจสอบทั้ง [get_HyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkclick/) และ [get_HyperlinkMouseOver](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmouseover/) บนแต่ละคอนเทนเนอร์. พวกมันเป็นอิสระกัน: คอนเทนเนอร์เดียวกันอาจเปิดเผยทั้งสองการกระทำ, ดังนั้นรายงานครบถ้วนอาจต้องมีสองแถวต่อคอนเทนเนอร์.

การสแกนไฮเพอร์ลิงก์ระดับรูปร่างเท่านั้นอาจพลาดลิงก์ที่แนบกับส่วนข้อความ. ควรสอบถามช่วงที่เหมาะสมแทน, และเก็บคอนเทนเนอร์ที่คืนค่าไว้เพื่อให้สามารถอัปเดตหรือลบการกระทำในภายหลังได้.

### **สอบถามช่วงการนำเสนอ, สไลด์, และกรอบข้อความ**

อินเทอร์เฟซ [IHyperlinkQueries](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/) สามารถเข้าถึงได้ผ่าน [IPresentation::get_HyperlinkQueries](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_hyperlinkqueries/), [IBaseSlide::get_HyperlinkQueries](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_hyperlinkqueries/), และ [ITextFrame::get_HyperlinkQueries](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_hyperlinkqueries/). แต่ละช่วงรองรับการสอบถามเดียวกัน:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) คืนคอนเทนเนอร์ที่มีการกระทำคลิก.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) คืนคอนเทนเนอร์ที่มีการกระทำเมาส์โอเวอร์.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) คืนคอนเทนเนอร์ที่มีการกระทำอย่างใดอย่างหนึ่งหรือทั้งสอง.

ตัวอย่างนี้กำหนดการกระทำคลิกและเมาส์โอเวอร์ให้กับรูปร่างและข้อความของมัน, และกำหนดการกระทำแมโครให้กับปุ่มแยกต่างหาก. ตัวอย่างเปรียบเทียบคอนเทนเนอร์ที่คืนมาจาก [GetAnyHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) กับจำนวนของแต่ละประเภทการกระทำ. การสอบถามกรอบข้อความจะนับเฉพาะลิงก์ในข้อความ. การกระทำของรูปร่างที่หุ้มอยู่จะปรากฏในผลการสอบถามของสไลด์และการนำเสนอ.

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

สำหรับตัวอย่างนี้, การสอบถามระดับการนำเสนอและสไลด์แต่ละอันจะแสดงคอนเทนเนอร์คลิก 3 รายการ, คอนเทนเนอร์เมาส์โอเวอร์ 2 รายการ, และคอนเทนเนอร์ที่มีการกระทำใดการกระทำหนึ่ง 3 รายการ. การสอบถามระดับกรอบข้อความจะแสดงคอนเทนเนอร์หนึ่งรายการในแต่ละประเภท.

### **จำแนกการกระทำและเป้าหมาย**

ใช้ [IHyperlink::get_ActionType](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_actiontype/) เพื่อแปลความหมายของการกระทำก่อนแปลความหมายของเป้าหมาย. ค่าของ [HyperlinkActionType](https://reference.aspose.com/slides/cpp/aspose.slides/hyperlinkactiontype/) ครอบคลุมมากกว่าการนำทางเว็บ:

| ค่า | ความหมายสำหรับการตรวจสอบ |
| --- | --- |
| `Hyperlink` | ไฮเพอร์ลิงก์ภายนอก; ตรวจสอบ URL และสคีมของมัน. |
| `JumpSpecificSlide` | การนำทางภายในไปยังสไลด์เฉพาะ. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | การนำทางสไลด์โชว์ในตัว, แก้ไขในบริบทของสไลด์โชว์. |
| `JumpEndShow`, `StartCustomSlideShow` | จบการแสดงปัจจุบันหรือเริ่มการแสดงแบบกำหนดเอง. |
| `StartMacro` | ดำเนินการมครอ. |
| `StartProgram` | เปิดโปรแกรม. |
| `OpenFile`, `OpenPresentation` | เปิดไฟล์หรือการนำเสนออื่น; ตรวจสอบแยกจาก URL ของเว็บ. |
| `StartStopMedia` | เริ่มหรือหยุดการเล่นสื่อ. |
| `NoAction`, `Unknown` | ไม่มีการนำทาง หรือการกระทำที่ไม่รู้จักต้องตรวจสอบ. |

อ่านเป้าหมายภายนอกจาก [get_ExternalUrl](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_externalurl/) และเป้าหมายภายในเฉพาะจาก [get_TargetSlide](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_targetslide/). การกระทำภายในและคำสั่งในตัวอาจไม่มี URL ภายนอก; URL ว่างไม่หมายความว่าคอนเทนเนอร์ไม่มีการกระทำ. ควรเก็บ [get_ExternalUrlOriginal](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_externalurloriginal/) เมื่อแตกต่างจาก URL ที่ทำการมาตรฐาน, และรวม tooltip ที่คืนค่าจาก [get_Tooltip](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_tooltip/) หากมี.

### **รายงาน, ทำความสะอาด, และตรวจสอบไฮเพอร์ลิงก์**

ตัวอย่าง C++ นี้เปิดการนำเสนอจากตัวอย่างก่อนหน้าและเขียนบันทึก JSON หนึ่งรายการต่อการกระทำ. มันใช้ [GetAnyHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) เพื่อรวบรวมคอนเทนเนอร์บนสไลด์ปกติ, มาสเตอร์, เลย์เอาต์, และโน้ต, รวมถึงมาสเตอร์โน้ตและมาสเตอร์เอกสารเมื่อมี. ตัวอย่างใช้ตัวตนของพอยน์เตอร์เพื่อนับคอนเทนเนอร์แต่ละอันเพียงครั้งเดียว, ปรับใช้แนวนโยบายที่อธิบายด้านล่าง, และเปิดการนำเสนอที่บันทึกใหม่เพื่อตรวจสอบทั้งการกระทำคลิกและเมาส์โอเวอร์.

บันทึกรายงานจะรวมดัชนีสไลด์ที่เริ่มจากหนึ่งและ [get_SlideId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideid/) เมื่อมี. [ISlideComponent::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/islidecomponent/get_slide/) จะให้สไลด์เจ้าของสำหรับคอนเทนเนอร์ที่รองรับ. มาสเตอร์, เลย์เอาต์, และโน้ตไม่มีดัชนีสไลด์ปกติและจะระบุด้วยช่วงของมัน. คอนเทนเนอร์รูปร่างและคอนเทนเนอร์รูปแบบส่วนข้อความจะมีป้ายแยกกัน; ประเภทคอนเทนเนอร์อื่นจะรักษาชื่อประเภทรันไทม์ของมัน. แต่ละคอนเทนเนอร์จะได้รับ ID รายงานภายในเพื่อให้สามารถเชื่อมโยงการกระทำทั้งสองได้.

แนวนโยบายแอปพลิเคชันที่เข้มงวดนี้อนุญาตเฉพาะ URL HTTPS แบบสมบูรณ์และจุดหมายสไลด์ภายในที่ถูกต้อง. จะปฏิเสธแมโคร, โปรแกรม, การกระทำไฟล์, การกระทำสไลด์โชว์อื่น ๆ, การกระทำที่ไม่รู้จัก, และสคีม URL อื่น. การปฏิเสธเหล่านี้เป็นการตัดสินใจของนโยบาย, ไม่ใช่การตัดสินความปลอดภัยของ Aspose.Slides. HTTPS เพียงอย่างเดียวไม่ได้สร้างความเชื่อถือ: ควรเพิ่มรายการอนุญาตโฮสต์และการตรวจสอบอื่น ๆ สำหรับแอปของคุณ. ทั้ง URL ภายนอกต้นฉบับและที่ทำมาตรฐานจะถูกตรวจสอบ. ตัวอย่างทำการตรวจสอบเมตาดาทาโดยไม่เปิดลิงก์หรือดำเนินการใด ๆ.

สำหรับการแก้ไข, [get_HyperlinkManager](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmanager/) ของคอนเทนเนอร์สนับสนุน [SetExternalHyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/), และ [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). ที่นี่, ลิงก์คลิกภายนอกที่ห้ามไว้จะถูกแทนที่ด้วยหน้า Landing Page HTTPS ที่กำหนด, ส่วนคลิกและเมาส์โอเวอร์ที่ห้ามอื่น ๆ จะถูกลบแยกกัน. ตั้งค่า `replaceExternalClicks` เป็น `false` เพื่อทำการลบทุกการละเมิดนโยบายแทน. ควรเลือกหน้าแทนที่ที่เป็นของแอปก่อนการปรับใช้.

ธงการส่งออกของรายงานใช้แนวนโยบายการตรวจสอบ PDF ที่ระมัดระวัง: ทำเครื่องหมายการกระทำเมาส์โอเวอร์และสิ่งใดนอกจากลิงก์ภายนอกหรือการกระโดดสไลด์เฉพาะว่าอาจไม่รองรับ. นี่เป็นคำแนะนำการตรวจสอบ, ไม่ใช่การทดสอบความสามารถหรือการรับประกันว่าลิงก์ที่ไม่ได้ทำเครื่องหมายจะคงอยู่หลังการส่งออก. การส่งออก [PDF](/slides/th/cpp/convert-powerpoint-to-pdf/) และ [HTML](/slides/th/cpp/convert-powerpoint-to-html/) ที่รองรับอาจคงไว้ซึ่งไฮเพอร์ลิงก์, ขึ้นกับการกระทำ, ตัวเลือกการส่งออก, และผู้ดู. ภาพ [images](/slides/th/cpp/convert-powerpoint-to-png/) และ [video](/slides/th/cpp/convert-powerpoint-to-video/) ไม่สามารถคงไว้ซึ่งไฮเพอร์ลิงก์เชิงโต้ตอบ; ควรทำเครื่องหมายทุกการกระทำเมื่อทำการตรวจสอบสำหรับผลลัพธ์เหล่านั้น.

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

ด้วยข้อมูลที่สร้างขึ้นข้างบน, รายงานประกอบด้วยห้ารายการการกระทำ. ลิงก์เมาส์โอเวอร์ไฟล์และแมโครคลิกจะถูกลบ, ส่วนลิงก์ HTTPS และการนำทางสไลด์ภายในจะคงอยู่. การตรวจสอบจะแสดงศูนย์การกระทำที่ห้าม. อินพุตที่มี URL คลิกภายนอกที่ห้ามก็จะทดสอบสาขาการแทนที่. คอนเทนเนอร์ที่มีคลิกที่อนุญาตและเมาส์โอเวอร์ที่ห้ามจะคงการกระทำคลิกไว้.

การทำความสะอาดแบบเลือกนี้แตกต่างจาก [RemoveAllHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/), ซึ่งลบทั้งสองประเภทการกระทำในช่วงที่เลือกโดยไม่คำนึงถึงนโยบาย. การตรวจสอบที่นี่ตรวจสอบการกระทำของไฮเพอร์ลิงก์เท่านั้น; ไม่ลบโปรเจ็กต์ VBA ที่ฝังอยู่, วัตถุ OLE, หรือเนื้อหาแอคทีฟอื่น ๆ, และไม่ตรวจสอบไฟล์ PDF หรือ HTML ที่ส่งออกแล้ว.

## **คำถามที่พบบ่อย**

**ฉันจะลิงก์ไปยังส่วนหรือสไลด์แรกของมันได้อย่างไร?**

ส่วนใน PowerPoint จะจัดกลุ่มสไลด์, แต่ไฮเพอร์ลิงก์ภายในจะชี้ไปยังสไลด์เดี่ยว. เพื่อสร้างการนำทางไปยังส่วน, ให้ลิงก์ไปยังสไลด์แรกของส่วนนั้น.

**ฉันสามารถแนบไฮเพอร์ลิงก์ให้กับองค์ประกอบมาสเตอร์สไลด์เพื่อให้ทำงานบนทุกสไลด์ได้หรือไม่?**

ใช่. องค์ประกอบมาสเตอร์สไลด์และเลย์เอาต์รองรับไฮเพอร์ลิงก์. ลิงก์บนองค์ประกอบเหล่านี้จะพร้อมใช้งานระหว่างการแสดงสไลด์บนสไลด์ที่ใช้มาสเตอร์หรือเลย์เอาต์นั้น.

**ไฮเพอร์ลิงก์จะคงอยู่เมื่อนำออกเป็น PDF, HTML, images, หรือ video หรือไม่?**

การส่งออก PDF และ HTML ที่รองรับอาจคงไว้ซึ่งไฮเพอร์ลิงก์; ภาพ raster และวิดีโอไม่สามารถทำเช่นนั้นได้. ดูพิจารณาการส่งออกใน [รายงาน, ทำความสะอาด, และตรวจสอบไฮเพอร์ลิงก์](#report-sanitize-and-verify-hyperlinks).