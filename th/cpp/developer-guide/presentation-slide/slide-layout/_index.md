---
title: ใช้หรือเปลี่ยนเค้าโครงสไลด์ใน C++
linktitle: เค้าโครงสไลด์
type: docs
weight: 60
url: /th/cpp/slide-layout/
keywords:
- เค้าโครงสไลด์
- เค้าโครงเนื้อหา
- ตำแหน่งที่คั่น
- การออกแบบงานนำเสนอ
- การออกแบบสไลด์
- เค้าโครงที่ไม่ได้ใช้
- การมองเห็นส่วนท้าย
- สไลด์หัวเรื่อง
- หัวเรื่องและเนื้อหา
- หัวข้อส่วน
- สองเนื้อหา
- การเปรียบเทียบ
- หัวเรื่องเท่านั้น
- เค้าโครงเปล่า
- เนื้อหาพร้อมคำบรรยาย
- รูปภาพพร้อมคำบรรยาย
- หัวเรื่องและข้อความแนวตั้ง
- หัวเรื่องแนวตั้งและข้อความ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C++
- Aspose.Slides
description: "จัดการและปรับแต่งเค้าโครงสไลด์ใน Aspose.Slides สำหรับ C++. สำรวจประเภทของเค้าโครง การควบคุมตำแหน่งที่คั่น และการมองเห็นส่วนท้ายผ่านตัวอย่างโค้ด C++."
---
## **บทนำ**

เค้าโครงสไลด์กำหนดการจัดวางกล่องตำแหน่งที่คั่นและรูปแบบการจัดรูปแบบสำหรับเนื้อหาบนสไลด์ มันควบคุมว่าตำแหน่งที่คั่นใดบ้างที่พร้อมใช้งานและปรากฏที่ไหน เค้าโครงสไลด์ช่วยให้คุณออกแบบงานนำเสนอได้อย่างรวดเร็วและสม่ำเสมอ — ไม่ว่าคุณกำลังสร้างสิ่งที่เรียบง่ายหรือซับซ้อนมากก็ตาม เค้าโครงสไลด์ที่พบได้บ่อยที่สุดใน PowerPoint ได้แก่:

**Title Slide layout** – มีตำแหน่งที่คั่นข้อความสองตำแหน่ง: หนึ่งสำหรับหัวเรื่องและอีกหนึ่งสำหรับหัวเรื่องย่อย.

**Title and Content layout** – มีตำแหน่งที่คั่นหัวเรื่องขนาดเล็กที่ด้านบนและตำแหน่งที่ใหญ่กว่าอยู่ด้านล่างสำหรับเนื้อหาหลัก (เช่น ข้อความ, รายการหัวข้อย่อย, แผนภูมิ, รูปภาพ และอื่น ๆ).

**Blank layout** – ไม่มีตำแหน่งที่คั่นใด ๆ ให้คุณควบคุมทั้งหมดในการออกแบบสไลด์ตั้งแต่ต้น.

เค้าโครงสไลด์เป็นส่วนหนึ่งของ master slide ซึ่งเป็นสไลด์ระดับบนสุดที่กำหนดสไตล์เค้าโครงสำหรับงานนำเสนอ คุณสามารถเข้าถึงและแก้ไขเค้าโครงสไลด์ผ่าน master slide — ไม่ว่าจะตามประเภท, ชื่อ หรือรหัสประจำตัวที่ไม่ซ้ำกัน หรือคุณสามารถแก้ไขเค้าโครงสไลด์เฉพาะโดยตรงภายในงานนำเสนอได้

เพื่อทำงานกับเค้าโครงสไลด์ใน Aspose.Slides for Android คุณสามารถใช้:

- วิธีการเช่น [get_LayoutSlides](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_layoutslides/) และ [get_Masters](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_masters/) ใต้คลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)
- ชนิดเช่น [ILayoutSlide](https://reference.aspose.com/slides/th/cpp/aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/th/cpp/aspose.slides/ilayoutplaceholdermanager/), และ [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/th/cpp/aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
เพื่อเรียนรู้เพิ่มเติมเกี่ยวกับการทำงานกับ master slide ให้ตรวจสอบบทความ [Slide Master](/slides/th/cpp/slide-master/) 
{{% /alert %}}

## **เพิ่มเค้าโครงสไลด์ลงในงานนำเสนอ**

เพื่อปรับแต่งลักษณะและโครงสร้างของสไลด์ของคุณ คุณอาจต้องเพิ่มเค้าโครงสไลด์ใหม่ลงในงานนำเสนอ Aspose.Slides for Android อนุญาตให้คุณตรวจสอบว่าเค้าโครงที่ต้องการมีอยู่แล้วหรือไม่ เพิ่มใหม่หากจำเป็น และใช้เพื่อแทรกสไลด์ตามเค้าโครงนั้น

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) 
1. เข้าถึง [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/th/cpp/aspose.slides/imasterlayoutslidecollection/) 
1. ตรวจสอบว่าเค้าโครงสไลด์ที่ต้องการมีอยู่แล้วในคอลเลกชันหรือไม่ หากไม่มีให้เพิ่มเค้าโครงสไลด์ที่ต้องการ 
1. เพิ่มสไลด์เปล่าตามเค้าโครงสไลด์ใหม่ 
1. บันทึกงานนำเสนอ 

โค้ด C++ ต่อไปนี้แสดงวิธีเพิ่มเค้าโครงสไลด์ลงในงานนำเสนอ PowerPoint:

```cpp
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์ PowerPoint.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Go through the layout slide types to select a layout slide.
auto layoutSlides = presentation->get_Master(0)->get_LayoutSlides();
SharedPtr<ILayoutSlide> layoutSlide;
if (layoutSlides->GetByType(SlideLayoutType::TitleAndObject) != nullptr)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);
}
else if (layoutSlides->GetByType(SlideLayoutType::Title) != nullptr)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::Title);
}

if (layoutSlide == nullptr)
{
    // สถานการณ์ที่งานนำเสนอไม่มีเค้าโครงทุกประเภท.
    // ไฟล์งานนำเสนอมีเพียงเค้าโครงประเภท Blank และ Custom เท่านั้น.
    // อย่างไรก็ตาม เค้าโครงสไลด์ที่เป็นประเภท Custom อาจมีชื่อที่จดจำได้,
    // เช่น "Title", "Title and Content" เป็นต้น ซึ่งสามารถใช้ในการเลือกเค้าโครงสไลด์ได้.
    // คุณสามารถพึ่งพาชุดประเภทรูปทรงตำแหน่งที่คั่นได้เช่นกัน.
    // ตัวอย่างเช่น สไลด์ Title ควรมีเพียงตำแหน่งที่คั่นประเภท Title เท่านั้น เป็นต้น.
    for (int i = 0; i < layoutSlides->get_Count(); i++)
    {
        auto titleAndObjectLayoutSlide = layoutSlides->idx_get(i);

        if (titleAndObjectLayoutSlide->get_Name().Equals(u"Title and Object"))
        {
            layoutSlide = titleAndObjectLayoutSlide;
            break;
        }
    }

    if (layoutSlide == nullptr)
    {
        for (int i = 0; i < layoutSlides->get_Count(); i++)
        {
            auto titleLayoutSlide = layoutSlides->idx_get(i);

            if (titleLayoutSlide->get_Name() == u"Title")
            {
                layoutSlide = titleLayoutSlide;
                break;
            }
        }

        if (layoutSlide == nullptr)
        {
            layoutSlide = layoutSlides->GetByType(SlideLayoutType::Blank);
            if (layoutSlide == nullptr)
            {
                layoutSlide = layoutSlides->Add(SlideLayoutType::TitleAndObject, u"Title and Object");
            }
        }
    }
}

// เพิ่มสไลด์เปล่าโดยใช้เค้าโครงสไลด์ที่เพิ่มไว้.
presentation->get_Slides()->InsertEmptySlide(0, layoutSlide);

// บันทึกงานนำเสนอไปยังดิสก์.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ลบเค้าโครงสไลด์ที่ไม่ได้ใช้**

Aspose.Slides มีเมธอด [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) จากคลาส [Compress](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/compress/) เพื่อให้คุณลบเค้าโครงสไลด์ที่ไม่ต้องการและไม่ได้ใช้

โค้ด C++ ต่อไปนี้แสดงวิธีลบเค้าโครงสไลด์จากงานนำเสนอ PowerPoint:

```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **เพิ่มตำแหน่งที่คั่นลงในเค้าโครงสไลด์**

Aspose.Slides มีเมธอด [ILayoutSlide.get_PlaceholderManager](https://reference.aspose.com/slides/th/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) ซึ่งอนุญาตให้คุณเพิ่มตำแหน่งที่คั่นใหม่ลงในเค้าโครงสไลด์

ผู้จัดการนี้มีเมธอดสำหรับประเภทตำแหน่งที่คั่นต่อไปนี้:

| PowerPoint Placeholder | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/th/cpp/aspose.slides/ilayoutplaceholdermanager/) เมธอด |
| ----------------------------------- | ------------------------------------------------------------ |
| ![เนื้อหา](content.png) | AddContentPlaceholder(float x, float y, float width, float height) |
| ![เนื้อหา (แนวตั้ง)](contentV.png) | AddVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![ข้อความ](text.png) | AddTextPlaceholder(float x, float y, float width, float height) |
| ![ข้อความ (แนวตั้ง)](textV.png) | AddVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![รูปภาพ](picture.png) | AddPicturePlaceholder(float x, float y, float width, float height) |
| ![แผนภูมิ](chart.png) | AddChartPlaceholder(float x, float y, float width, float height) |
| ![ตาราง](table.png) | AddTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | AddSmartArtPlaceholder(float x, float y, float width, float height) |
| ![สื่อ](media.png) | AddMediaPlaceholder(float x, float y, float width, float height) |
| ![รูปภาพออนไลน์](onlineimage.png) | AddOnlineImagePlaceholder(float x, float y, float width, float height) |

โค้ด C++ ต่อไปนี้แสดงวิธีเพิ่มรูปทรงตำแหน่งที่คั่นใหม่ลงในเค้าโครง Blank:

```cpp
auto presentation = MakeObject<Presentation>();

// รับเค้าโครงสไลด์แบบ Blank.
auto layout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

// รับผู้จัดการตำแหน่งที่คั่นของสไลด์เค้าโครง.
auto placeholderManager = layout->get_PlaceholderManager();

// เพิ่มตำแหน่งที่คั่นต่างๆ ไปยังสไลด์เค้าโครงแบบ Blank.
placeholderManager->AddContentPlaceholder(20, 20, 310, 270);
placeholderManager->AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager->AddChartPlaceholder(20, 310, 310, 180);
placeholderManager->AddTablePlaceholder(350, 310, 350, 180);

// Add a new slide with the Blank layout.
auto newSlide = presentation->get_Slides()->AddEmptySlide(layout);

presentation->Save(u"Placeholders.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![ตำแหน่งที่คั่นบนเค้าโครงสไลด์](add_placeholders.png)

## **กำหนดการมองเห็น Footer สำหรับเค้าโครงสไลด์**

ในงานนำเสนอ PowerPoint องค์ประกอบ Footer เช่น วันที่, เลขสไลด์, และข้อความกำหนดเองสามารถแสดงหรือซ่อนได้ตามเค้าโครงสไลด์ Aspose.Slides for Android อนุญาตให้คุณควบคุมการมองเห็นของตำแหน่งที่คั่น Footer เหล่านี้ ซึ่งมีประโยชน์เมื่อคุณต้องการให้เค้าโครงบางอย่างแสดงข้อมูล Footer ในขณะที่เค้าโครงอื่น ๆ คงความเรียบง่าย

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) 
1. รับอ้างอิงเค้าโครงสไลด์ตามดัชนี 
1. ตั้งค่าตำแหน่งที่คั่น Footer ของสไลด์ให้มองเห็น 
1. ตั้งค่าตำแหน่งที่คั่นเลขสไลด์ให้มองเห็น 
1. ตั้งค่าตำแหน่งที่คั่นวัน‑เวลาให้มองเห็น 
1. บันทึกงานนำเสนอ 

โค้ด C++ ต่อไปนี้แสดงวิธีตั้งค่าการมองเห็นของ Footer สไลด์และทำงานที่เกี่ยวข้อง:

```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.ppt");
auto headerFooterManager = presentation->get_LayoutSlides()->idx_get(0)->get_HeaderFooterManager();

if (!headerFooterManager->get_IsFooterVisible())
{
    headerFooterManager->SetFooterVisibility(true);
}

if (!headerFooterManager->get_IsSlideNumberVisible())
{
    headerFooterManager->SetSlideNumberVisibility(true);
}

if (!headerFooterManager->get_IsDateTimeVisible())
{
    headerFooterManager->SetDateTimeVisibility(true);
}

headerFooterManager->SetFooterText(u"Footer text");
headerFooterManager->SetDateTimeText(u"Date and time text");

presentation->Save(u"Presentation.ppt", SaveFormat::Pptx);
presentation->Dispose();
```

## **กำหนดการมองเห็น Footer ของสไลด์ลูก**

​ในงานนำเสนอ PowerPoint องค์ประกอบ Footer เช่น วันที่, เลขสไลด์, และข้อความกำหนดเองสามารถควบคุมระดับ master slide เพื่อให้สอดคล้องกันทั่วเค้าโครงสไลด์ทั้งหมด Aspose.Slides for Android ทำให้คุณตั้งค่าการมองเห็นและเนื้อหาของตำแหน่งที่คั่น Footer เหล่านี้บน master slide แล้วกระจายการตั้งค่าเหล่านั้นไปยังสไลด์ลูกทั้งหมด วิธีนี้ทำให้ข้อมูล Footer มีความสม่ำเสมอทั่วทั้งงานนำเสนอ​ 

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) 
1. รับอ้างอิง master slide ตามดัชนี 
1. ตั้งค่าตำแหน่งที่คั่น Footer ของ master และสไลด์ลูกทั้งหมดให้มองเห็น 
1. ตั้งค่าตำแหน่งที่คั่นเลขสไลด์ของ master และสไลด์ลูกทั้งหมดให้มองเห็น 
1. ตั้งค่าตำแหน่งที่คั่นวัน‑เวลา ของ master และสไลด์ลูกทั้งหมดให้มองเห็น 
1. บันทึกงานนำเสนอ 

โค้ด C++ ต่อไปนี้แสดงการดำเนินการนี้:

```cpp
auto presentation = MakeObject<Presentation>();

auto headerFooterManager = presentation->get_Master(0)->get_HeaderFooterManager();

headerFooterManager->SetFooterAndChildFootersVisibility(true);
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่าง master slide กับ layout slide คืออะไร?**

master slide กำหนดธีมโดยรวมและการจัดรูปแบบเริ่มต้นในขณะที่ layout slide กำหนดการจัดวางตำแหน่งที่คั่นเฉพาะสำหรับประเภทเนื้อหาต่าง ๆ

**ฉันสามารถคัดลอก layout slide จากงานนำเสนอหนึ่งไปยังอีกงานนำเสนอหนึ่งได้หรือไม่?**

ได้ คุณสามารถโคลน layout slide จากคอลเลกชัน layout slide ของงานนำเสนอหนึ่ง (เข้าถึงได้ผ่านเมธอด [get_LayoutSlides](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/get_layoutslides/)) แล้วแทรกลงในงานนำเสนออื่นโดยใช้เมธอด `AddClone`

**จะเกิดอะไรขึ้นถ้าฉันลบ layout slide ที่ยังถูกสไลด์อื่นใช้งานอยู่?**

หากคุณพยายามลบ layout slide ที่ยังถูกอ้างอิงโดยสไลด์อย่างน้อยหนึ่งสไลด์ในงานนำเสนอ Aspose.Slides จะโยนข้อผิดพลาด [PptxEditException](https://reference.aspose.com/slides/th/cpp/aspose.slides/pptxeditexception/) เพื่อหลีกเลี่ยงปัญหานี้ให้ใช้เมธอด [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/th/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) ซึ่งจะลบเฉพาะเค้าโครงสไลด์ที่ไม่ได้ใช้งานอย่างปลอดภัย