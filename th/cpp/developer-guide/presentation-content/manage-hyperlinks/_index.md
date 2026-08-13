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
- ไฮเปอร์ลิงก์รูปร่าง
- ไฮเปอร์ลิงก์ภาพ
- ไฮเปอร์ลิงก์วิดีโอ
- ไฮเปอร์ลิงก์ที่เปลี่ยนแปลงได้
- PowerPoint
- OpenDocument
- การนำเสนอ
- C++
- Aspose.Slides
description: "จัดการไฮเปอร์ลิงก์ในงานนำเสนอ PowerPoint และ OpenDocument อย่างง่ายดายด้วย Aspose.Slides สำหรับ C++ — เพิ่มความโต้ตอบและประสิทธิภาพการทำงานภายในไม่กี่นาที."
---
## **บทนำ**

ไฮเปอร์ลิงก์คือการอ้างอิงถึงวัตถุหรือข้อมูลหรือสถานที่ในบางอย่าง นี่คือไฮเปอร์ลิงก์ที่พบบ่อยในงานนำเสนอ PowerPoint:

* ลิงก์ไปยังเว็บไซต์ภายในข้อความ, รูปร่าง หรือสื่อ
* ลิงก์ไปยังสไลด์

Aspose.Slides for C++ ช่วยให้คุณทำงานหลายอย่างที่เกี่ยวกับไฮเปอร์ลิงก์ในงานนำเสนอได้

{{% alert color="info" %}} 
คุณอาจต้องการลองดู Aspose อย่างง่าย, [เครื่องมือแก้ไข PowerPoint ออนไลน์ฟรี](https://products.aspose.app/slides/th/editor)
{{% /alert %}} 

## **เพิ่มไฮเปอร์ลิงก์ URL**

### **เพิ่มไฮเปอร์ลิงก์ URL ไปยังข้อความ**

โค้ด C++ นี้แสดงวิธีการเพิ่มไฮเปอร์ลิงก์เว็บไซต์ไปยังข้อความ:
``` cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAutoShape.h>
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

auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f, false);
shape->AddTextFrame(u"Aspose: File Format APIs");

auto portionFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
portionFormat->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
portionFormat->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");
portionFormat->set_FontHeight(32.0f);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

### **เพิ่มไฮเปอร์ลิงก์ URL ไปยังรูปทรงหรือตัวกรอบ**

โค้ดตัวอย่างใน C++ นี้แสดงวิธีการเพิ่มไฮเปอร์ลิงก์เว็บไซต์ไปยังรูปทรง:
``` cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f);

shape->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

### **เพิ่มไฮเปอร์ลิงก์ URL ไปยังสื่อ**

Aspose.Slides ช่วยให้คุณสามารถเพิ่มไฮเปอร์ลิงก์ไปยังไฟล์รูปภาพ, เสียง, และวิดีโอได้

โค้ดตัวอย่างนี้แสดงวิธีการเพิ่มไฮเปอร์ลิงก์ไปยัง **รูปภาพ**:
``` cpp
#include <DOM/Hyperlink.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
// เพิ่มภาพลงในงานนำเสนอ
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
// สร้างกรอบรูปภาพบนสไลด์ 1 โดยอิงจากภาพที่เพิ่มไว้ก่อนหน้า
auto pictureFrame = shapes->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pictureFrame->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
pictureFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

โค้ดตัวอย่างนี้แสดงวิธีการเพิ่มไฮเปอร์ลิงก์ไปยัง **ไฟล์เสียง**:
``` cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAudioCollection.h>
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto audio = pres->get_Audios()->AddAudio(File::ReadAllBytes(u"audio.mp3"));
auto audioFrame = shapes->AddAudioFrameEmbedded(10.0f, 10.0f, 100.0f, 100.0f, audio);

audioFrame->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
audioFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

โค้ดตัวอย่างนี้แสดงวิธีการเพิ่มไฮเปอร์ลิงก์ไปยัง **วิดีโอ**:
``` cpp
#include <DOM/Hyperlink.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IVideoCollection.h>
#include <DOM/IVideoFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto video = pres->get_Videos()->AddVideo(File::ReadAllBytes(u"video.avi"));
auto videoFrame = shapes->AddVideoFrame(10.0f, 10.0f, 100.0f, 100.0f, video);

videoFrame->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
videoFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

{{%  alert  title="Tip"  color="info"  %}} 
คุณอาจต้องการดู *[จัดการ OLE](https://docs.aspose.com/slides/th/cpp/manage-ole/)*.
{{% /alert %}}

## **ใช้ไฮเปอร์ลิงก์เพื่อสร้างสารบัญ**

เนื่องจากไฮเปอร์ลิงก์ช่วยให้คุณเพิ่มการอ้างอิงถึงวัตถุหรือสถานที่ได้ คุณสามารถใช้มันเพื่อสร้างสารบัญได้

โค้ดตัวอย่างนี้แสดงวิธีการสร้างสารบัญพร้อมไฮเปอร์ลิงก์:
``` cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
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
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto firstSlide = presentation->get_Slides()->idx_get(0);
auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto contentTable = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 40.0f, 300.0f, 100.0f);
contentTable->get_FillFormat()->set_FillType(FillType::NoFill);
contentTable->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
contentTable->get_TextFrame()->get_Paragraphs()->Clear();

auto paragraph = System::MakeObject<Paragraph>();
auto paragraphFillFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
paragraphFillFormat->set_FillType(FillType::Solid);
paragraphFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
paragraph->set_Text(u"Title of slide 2 .......... ");

auto linkPortion = System::MakeObject<Portion>();
linkPortion->set_Text(u"Page 2");
linkPortion->get_PortionFormat()->get_HyperlinkManager()->SetInternalHyperlinkClick(secondSlide);

paragraph->get_Portions()->Add(linkPortion);
contentTable->get_TextFrame()->get_Paragraphs()->Add(paragraph);
```

## **จัดรูปแบบไฮเปอร์ลิงก์**

### **สี**

ด้วยเมธอด [set_ColorSource()](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_hyperlink#ab739ae21025485366d44a3b72e0d7dac) และ [get_ColorSource()](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_hyperlink#af5370af1ba9fba7b22fcc8a7ce344494) ในอินเทอร์เฟซ [IHyperlink](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_hyperlink) คุณสามารถตั้งค่าสีสำหรับไฮเปอร์ลิงก์และรับข้อมูลสีจากไฮเปอร์ลิงก์ได้ ฟีเจอร์นี้首次แนะนำใน PowerPoint 2019 ดังนั้นการเปลี่ยนแปลงที่เกี่ยวข้องกับคุณสมบัตินี้จะไม่ทำงานกับเวอร์ชัน PowerPoint ที่เก่ากว่า

โค้ดตัวอย่างนี้แสดงการดำเนินการที่เพิ่มไฮเปอร์ลิงก์สีต่าง ๆ ลงในสไลด์เดียวกัน:
``` cpp
#include <DOM/FillType.h>
#include <DOM/Hyperlink.h>
#include <DOM/HyperlinkColorSource.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
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
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 450.0f, 50.0f, false);
shape1->AddTextFrame(u"This is a sample of colored hyperlink.");
auto shape1PortionFormat = shape1->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shape1PortionFormat->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape1PortionFormat->get_HyperlinkClick()->set_ColorSource(HyperlinkColorSource::PortionFormat);
shape1PortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
shape1PortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 450.0f, 50.0f, false);
shape2->AddTextFrame(u"This is a sample of usual hyperlink.");
auto shape2PortionFormat = shape2->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shape2PortionFormat->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));

presentation->Save(u"presentation-out-hyperlink.pptx", SaveFormat::Pptx);
```

## **ลบไฮเปอร์ลิงก์จากงานนำเสนอ**

### **ลบไฮเปอร์ลิงก์จากข้อความ**

โค้ด C++ นี้แสดงวิธีการลบไฮเปอร์ลิงก์จากข้อความในสไลด์งานนำเสนอ:
``` cpp
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
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto slide = pres->get_Slides()->idx_get(0);
for (const auto& shape : slide->get_Shapes())
{
    auto autoShape = System::AsCast<IAutoShape>(shape);
    if (autoShape != nullptr)
    {
        for (const auto& paragraph : autoShape->get_TextFrame()->get_Paragraphs())
        {
            for (const auto& portion : paragraph->get_Portions())
            {
                auto hyperlinkManager = portion->get_PortionFormat()->get_HyperlinkManager();
                hyperlinkManager->RemoveHyperlinkClick();
            }
        }
    }
}

pres->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
```

### **ลบไฮเปอร์ลิงก์จากรูปทรงหรือกรอบ**

โค้ด C++ นี้แสดงวิธีการลบไฮเปอร์ลิงก์จากรูปทรงในสไลด์งานนำเสนอ:
``` cpp
#include <DOM/IHyperlinkManager.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = pres->get_Slides()->idx_get(0);
for (const auto& shape : slide->get_Shapes())
{
    shape->get_HyperlinkManager()->RemoveHyperlinkClick();
}
pres->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
```

## **ไฮเปอร์ลิงก์ที่เปลี่ยนแปลงได้**

คลาส [Hyperlink](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.hyperlink) เป็นคลาสที่สามารถเปลี่ยนแปลงได้ ด้วยคลาสนี้คุณสามารถเปลี่ยนค่าของเมธอดต่อไปนี้ได้:

- [IHyperlink::set_TargetFrame()](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_hyperlink#af2d9c5672517d98afe5868903a5a637f)
- [IHyperlink::set_Tooltip()](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_hyperlink#adf1c8eee89bd292292293e58da79a6f2)
- [IHyperlink.set_History()](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_hyperlink#a1a4a96d280f54b641e3ada3557b6688d)
- [IHyperlink.set_HighlightClick()](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_hyperlink#ac48a0fa4106cff14cb5772269399587e)
- [IHyperlink.set_StopSoundOnClick()](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_hyperlink#ad0db04da8009b329d2c79019642aaa43)

โค้ดตัวอย่างนี้แสดงวิธีการเพิ่มไฮเปอร์ลิงก์ไปยังสไลด์และแก้ไข tooltip ของมันในภายหลัง:
``` cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAutoShape.h>
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

auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f, false);

shape->AddTextFrame(u"Aspose: File Format APIs");

auto shapePortionFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shapePortionFormat->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shapePortionFormat->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");
shapePortionFormat->set_FontHeight(32.0f);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

## **เมธอดที่รองรับใน IHyperlinkQueries**

คุณสามารถเข้าถึง IHyperlinkQueries จากงานนำเสนอ, สไลด์ หรือข้อความที่กำหนดไฮเปอร์ลิงก์ไว้ได้

- [IPresentation::get_HyperlinkQueries()](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_presentation#a7e84086f34ddc742ea9124ab11727691)
- [IBaseSlide::get_HyperlinkQueries()](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_base_slide#a8593a5a5f6b7e051aa859ec373c66421)
- [ITextFrame::get_HyperlinkQueries()](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_text_frame#a1303ef71d3c50d471e35434dcaaa2e4e)

คลาส IHyperlinkQueries รองรับเมธอดต่อไปนี้:

- [IHyperlinkQueries::GetHyperlinkClicks()](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_hyperlink_queries#aaea0b1b68ff2e65240612fb1f08361c1)
- [IHyperlinkQueries::GetHyperlinkMouseOvers()](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_hyperlink_queries#ac68ac55d183323f11e604b40760b0e4b)
- [IHyperlinkQueries::GetAnyHyperlinks()](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_hyperlink_queries#acaf9ded3920056054e0e70c24129d73a)
- [IHyperlinkQueries::RemoveAllHyperlinks()](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.i_hyperlink_queries#a289f52c992f939fe46282536cec7222d)

## **คำถามที่พบบ่อย**

### ฉันจะสร้างการนำทางภายในไม่ใช่แค่สไลด์ แต่เป็น "ส่วน" หรือสไลด์แรกของส่วนได้อย่างไร?

ส่วนใน PowerPoint คือการจัดกลุ่มสไลด์; การนำทางโดยเทคนิคจะชี้ไปที่สไลด์เฉพาะ เพื่อ "นำทางไปยังส่วน" คุณมักจะแล้งค์ไปยังสไลด์แรกของส่วนนั้น

### ฉันสามารถแนบไฮเปอร์ลิงก์ไปยังองค์ประกอบของมาสเตอร์สไลด์เพื่อให้ทำงานบนทุกสไลด์ได้หรือไม่?

ได้. องค์ประกอบมาสเตอร์สไลด์และเลย์เอาต์รองรับไฮเปอร์ลิงก์ ลิงก์เหล่านี้จะแสดงบนสไลด์ย่อยและสามารถคลิกได้ระหว่างการนำเสนอ

### ไฮเปอร์ลิงก์จะถูกเก็บไว้เมื่อนำออกเป็น PDF, HTML, รูปภาพ หรือวิดีโอหรือไม่?

ใน [PDF](/slides/th/cpp/convert-powerpoint-to-pdf/) และ [HTML](/slides/th/cpp/convert-powerpoint-to-html/) ใช่—ลิงก์จะโดยทั่วไปถูกเก็บไว้ เมื่อนำออกเป็น [รูปภาพ](/slides/th/cpp/convert-powerpoint-to-png/) และ [วิดีโอ](/slides/th/cpp/convert-powerpoint-to-video/) ความสามารถในการคลิกจะไม่ถ่ายทอดต่อไป เนื่องจากลักษณะของรูปแบบเหล่านั้น (เฟรมราสเตอร์/วิดีโอไม่รองรับไฮเปอร์ลิงก์)