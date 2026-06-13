---
title: ใช้หรือเปลี่ยนเค้าโครงสไลด์ใน .NET
linktitle: เค้าโครงสไลด์
type: docs
weight: 60
url: /th/net/slide-layout/
keywords:
- เค้าโครงสไลด์
- เค้าโครงเนื้อหา
- ตัวจับตำแหน่ง
- การออกแบบพรีเซนเทชัน
- การออกแบบสไลด์
- เค้าโครงที่ไม่ได้ใช้
- การมองเห็นส่วนท้าย
- สไลด์หัวข้อ
- หัวข้อและเนื้อหา
- ส่วนหัวของส่วน
- สองเนื้อหา
- การเปรียบเทียบ
- เฉพาะหัวข้อ
- เค้าโครงเปล่า
- เนื้อหาพร้อมคำอธิบาย
- รูปภาพพร้อมคำอธิบาย
- หัวข้อและข้อความแนวตั้ง
- หัวข้อแนวตั้งและข้อความ
- PowerPoint
- OpenDocument
- พรีเซนเทชัน
- C#
- .NET
- Aspose.Slides
description: "จัดการและปรับแต่งเค้าโครงสไลด์ใน Aspose.Slides สำหรับ .NET. สำรวจประเภทของเค้าโครง, การควบคุมตัวจับตำแหน่ง, และการมองเห็นส่วนท้ายผ่านตัวอย่างโค้ด C#."
---
## **บทนำ**

เลเอาท์สไลด์กำหนดการจัดเรียงของกล่องตัวจับตำแหน่งและการจัดรูปแบบสำหรับเนื้อหาบนสไลด์ มันควบคุมว่าจะมีตัวจับตำแหน่งใดบ้างและปรากฏที่ไหน เลเอาท์สไลด์ช่วยให้คุณออกแบบพรีเซนเทชันได้อย่างเร็วและสม่ำเสมอ—ไม่ว่าจะเป็นการสร้างสไลด์แบบง่ายหรือซับซ้อน บางส่วนของเลเอาท์สไลด์ที่พบบ่อยใน PowerPoint ได้แก่:

**เลเอาท์สไลด์หัวข้อ** – มีตัวจับตำแหน่งข้อความสองกล่อง: หนึ่งสำหรับหัวข้อและหนึ่งสำหรับหัวข้อรอง

**เลเอาท์สไลด์หัวข้อและเนื้อหา** – มีตัวจับตำแหน่งหัวข้อขนาดเล็กที่ด้านบนและตัวจับตำแหน่งขนาดใหญ่ด้านล่างสำหรับเนื้อหาหลัก (เช่น ข้อความ, จุดหัวข้อ, แผนภูมิ, รูปภาพ ฯลฯ)

**เลเอาท์เปล่า** – ไม่มีตัวจับตำแหน่งใด ๆ ให้คุณควบคุมการออกแบบสไลด์ตั้งแต่เริ่มต้น

เลเอาท์สไลด์เป็นส่วนหนึ่งของมาสเตอร์สไลด์ ซึ่งเป็นสไลด์ระดับบนสุดที่กำหนดรูปแบบเลเอาท์สำหรับพรีเซนเทชัน คุณสามารถเข้าถึงและแก้ไขสไลด์เลเอาท์ผ่านมาสเตอร์สไลด์—โดยอิงจากประเภท, ชื่อ หรือ ID เฉพาะ หรือคุณอาจแก้ไขสไลด์เลเอาท์เฉพาะโดยตรงภายในพรีเซนเทชัน

ในการทำงานกับเลเอาท์สไลด์ใน Aspose.Slides for .NET คุณสามารถใช้:

- คุณสมบัติเช่น [LayoutSlides](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/layoutslides/) และ [Masters](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/masters/) ภายใต้คลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)
- ชนิดต่าง ๆ เช่น [ILayoutSlide](https://reference.aspose.com/slides/th/net/aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/th/net/aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/th/net/aspose.slides/ilayoutplaceholdermanager/), และ [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/th/net/aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
เพื่อเรียนรู้เพิ่มเติมเกี่ยวกับการทำงานกับมาสเตอร์สไลด์ โปรดดูบทความ [Slide Master](/slides/th/net/slide-master/) 
{{% /alert %}}

## **เพิ่มเลเอาท์สไลด์ในพรีเซนเทชัน**

เพื่อกำหนดลักษณะและโครงสร้างของสไลด์คุณอาจต้องเพิ่มเลเอาท์สไลด์ใหม่ในพรีเซนเทชัน Aspose.Slides for .NET ให้คุณตรวจสอบว่าเลเอาท์ที่ต้องการมีอยู่แล้วหรือไม่, เพิ่มใหม่หากจำเป็น, และใช้เพื่อแทรกสไลด์ตามเลเอาท์นั้น

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)
2. เข้าถึง [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/th/net/aspose.slides/imasterlayoutslidecollection/)
3. ตรวจสอบว่าเลเอาท์สไลด์ที่ต้องการมีอยู่ในคอลเลกชันหรือยัง หากไม่มีให้เพิ่มเลเอาท์สไลด์ที่ต้องการ
4. เพิ่มสไลด์เปล่าตามเลเอาท์สไลด์ใหม่ที่สร้าง
5. บันทึกพรีเซนเทชัน

โค้ด C# ต่อไปนี้แสดงวิธีเพิ่มเลเอาท์สไลด์ในพรีเซนเทชัน PowerPoint:

```cs
// สร้างอินสแตนซ์ของคลาส Presentation ซึ่งเป็นตัวแทนของไฟล์ PowerPoint.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // ไปผ่านประเภทเลเอาท์สไลด์เพื่อเลือกเลเอาท์สไลด์.
    IMasterLayoutSlideCollection layoutSlides = presentation.Masters[0].LayoutSlides;
    ILayoutSlide layoutSlide = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)
    {
        // สถานการณ์ที่พรีเซนเทชันไม่มีประเภทเลเอาท์ทั้งหมด.
        // ไฟล์พรีเซนเทชันมีเฉพาะประเภทเลเอาท์ Blank และ Custom.
        // อย่างไรก็ตาม, เลเอาท์สไลด์ที่มีประเภทกำหนดเองอาจมีชื่อที่จดจำได้,
        // เช่น "Title", "Title and Content", เป็นต้น ซึ่งสามารถใช้สำหรับการเลือกเลเอาท์สไลด์.
        // คุณยังสามารถอาศัยชุดของประเภทรูปทรงตัวจับตำแหน่งได้.
        // ตัวอย่างเช่น สไลด์ Title ควรมีเพียงประเภทตัวจับตำแหน่ง Title เท่านั้น เป็นต้น.
        foreach (ILayoutSlide titleAndObjectLayoutSlide in layoutSlides)
        {
            if (titleAndObjectLayoutSlide.Name == "Title and Object")
            {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null)
        {
            foreach (ILayoutSlide titleLayoutSlide in layoutSlides)
            {
                if (titleLayoutSlide.Name == "Title")
                {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null)
            {
                layoutSlide = layoutSlides.GetByType(SlideLayoutType.Blank);
                if (layoutSlide == null)
                {
                    layoutSlide = layoutSlides.Add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // เพิ่มสไลด์เปล่าโดยใช้เลเอาท์สไลด์ที่เพิ่มไว้.
    presentation.Slides.InsertEmptySlide(0, layoutSlide);

    // บันทึกพรีเซนเทชันลงดิสก์.  
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **ลบเลเอาท์สไลด์ที่ไม่ได้ใช้**

Aspose.Slides มีเมธอด [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) จากคลาส [Compress](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/compress/) เพื่อให้คุณลบเลเอาท์สไลด์ที่ไม่ต้องการและไม่ได้ใช้

โค้ด C# ด้านล่างแสดงวิธีลบเลเอาท์สไลด์จากพรีเซนเทชัน PowerPoint:

```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(presentation);
    
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **เพิ่มตัวจับตำแหน่งในเลเอาท์สไลด์**

Aspose.Slides มีคุณสมบัติ [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/th/net/aspose.slides/ilayoutslide/placeholdermanager/) ที่อนุญาตให้คุณเพิ่มตัวจับตำแหน่งใหม่ในเลเอาท์สไลด์

ผู้จัดการนี้มีเมธอดสำหรับประเภทตัวจับตำแหน่งต่อไปนี้:

| ตัวจับตำแหน่ง PowerPoint | เมธอดใน [ILayoutPlaceholderManager](https://reference.aspose.com/slides/th/net/aspose.slides/ilayoutplaceholdermanager/) |
| -------------------------- | ------------------------------------------------------------ |
| ![Content](content.png) | AddContentPlaceholder(float x, float y, float width, float height) |
| ![Content (Vertical)](contentV.png) | AddVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png) | AddTextPlaceholder(float x, float y, float width, float height) |
| ![Text (Vertical)](textV.png) | AddVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Picture](picture.png) | AddPicturePlaceholder(float x, float y, float width, float height) |
| ![Chart](chart.png) | AddChartPlaceholder(float x, float y, float width, float height) |
| ![Table](table.png) | AddTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | AddSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png) | AddMediaPlaceholder(float x, float y, float width, float height) |
| ![Online Image](onlineimage.png) | AddOnlineImagePlaceholder(float x, float y, float width, float height) |

โค้ด C# ด้านล่างแสดงวิธีเพิ่มรูปร่างตัวจับตำแหน่งใหม่ลงในเลเอาท์สไลด์ Blank:

```cs
using (var presentation = new Presentation())
{
    // ดึงเลเอาท์สไลด์ Blank.
    ILayoutSlide layout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // ดึงผู้จัดการตัวจับตำแหน่งของเลเอาท์สไลด์.
    ILayoutPlaceholderManager placeholderManager = layout.PlaceholderManager;

    // เพิ่มตัวจับตำแหน่งต่าง ๆ ไปยังเลเอาท์สไลด์ Blank.
    placeholderManager.AddContentPlaceholder(20, 20, 310, 270);
    placeholderManager.AddVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.AddChartPlaceholder(20, 310, 310, 180);
    placeholderManager.AddTablePlaceholder(350, 310, 350, 180);

    // เพิ่มสไลด์ใหม่ด้วยเลเอาท์ Blank.
    ISlide newSlide = presentation.Slides.AddEmptySlide(layout);

    presentation.Save("Placeholders.pptx", SaveFormat.Pptx);
}
```

ผลลัพธ์:

![The placeholders on the layout slide](add_placeholders.png)

## **ตั้งค่าการแสดงผล Footer สำหรับเลเอาท์สไลด์**

ในพรีเซนเทชัน PowerPoint, องค์ประกอบ Footer เช่น วันที่, หมายเลขสไลด์, และข้อความกำหนดเองสามารถแสดงหรือซ่อนได้ขึ้นกับเลเอาท์สไลด์ Aspose.Slides for .NET ให้คุณควบคุมการมองเห็นของตัวจับตำแหน่ง Footer เหล่านี้ ซึ่งมีประโยชน์เมื่อคุณต้องการให้บางเลเอาท์แสดงข้อมูล Footer แต่เลเอาท์อื่น ๆ คงความเรียบง่าย

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)
2. ดึงอ้างอิงเลเอาท์สไลด์ตามดัชนี
3. ตั้งค่าตัวจับตำแหน่ง Footer ของสไลด์ให้แสดง
4. ตั้งค่าตัวจับตำแหน่งหมายเลขสไลด์ให้แสดง
5. ตั้งค่าตัวจับตำแหน่งวันที่‑เวลาให้แสดง
6. บันทึกพรีเซนเทชัน

โค้ด C# ด้านล่างแสดงวิธีตั้งค่าการมองเห็นของ Footer สไลด์และทำงานที่เกี่ยวข้อง:

```cs
using (Presentation presentation = new Presentation("Presentation.ppt"))
{
    ILayoutSlideHeaderFooterManager headerFooterManager = presentation.LayoutSlides[0].HeaderFooterManager;

    if (!headerFooterManager.IsFooterVisible)
    {
        headerFooterManager.SetFooterVisibility(true);
    }

    if (!headerFooterManager.IsSlideNumberVisible)
    {
        headerFooterManager.SetSlideNumberVisibility(true);
    }

    if (!headerFooterManager.IsDateTimeVisible)
    {
        headerFooterManager.SetDateTimeVisibility(true);
    }

    headerFooterManager.SetFooterText("Footer text");
    headerFooterManager.SetDateTimeText("Date and time text");

    presentation.Save("Presentation.ppt", SaveFormat.Ppt);
}
```

## **ตั้งค่าการแสดงผล Footer ของสไลด์ลูก**

​ในพรีเซนเทชัน PowerPoint, องค์ประกอบ Footer เช่น วันที่, หมายเลขสไลด์, และข้อความกำหนดเองสามารถควบคุมได้ระดับมาสเตอร์สไลด์เพื่อให้สอดคล้องกันทั่วทุกเลเอาท์สไลด์ Aspose.Slides for .NET ให้คุณตั้งค่าการมองเห็นและเนื้อหาของตัวจับตำแหน่ง Footer เหล่านี้บนมาสเตอร์สไลด์และกระจายการตั้งค่าเหล่านั้นไปยังเลเอาท์สไลด์ลูกทั้งหมด วิธีนี้ทำให้ข้อมูล Footer มีความสม่ำเสมอตลอดพรีเซนเทชัน​​

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)
2. ดึงอ้างอิงมาสเตอร์สไลด์ตามดัชนี
3. ตั้งค่าตัวจับตำแหน่ง Footer ของมาสเตอร์และสไลด์ลูกทั้งหมดให้แสดง
4. ตั้งค่าตัวจับตำแหน่งหมายเลขสไลด์ของมาสเตอร์และสไลด์ลูกทั้งหมดให้แสดง
5. ตั้งค่าตัวจับตำแหน่งวันที่‑เวลา ของมาสเตอร์และสไลด์ลูกทั้งหมดให้แสดง
6. บันทึกพรีเซนเทชัน

โค้ด C# ด้านล่างแสดงการดำเนินการนี้:

```cs
using (Presentation presentation = new Presentation("Presentation.ppt"))
{
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.Masters[0].HeaderFooterManager;

    headerFooterManager.SetFooterAndChildFootersVisibility(true);
    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.SetFooterAndChildFootersText("Footer text");
    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");

    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**ความแตกต่างระหว่างมาสเตอร์สไลด์และเลเอาท์สไลด์คืออะไร?**

มาสเตอร์สไลด์กำหนดธีมโดยรวมและการจัดรูปแบบเริ่มต้น ในขณะที่เลเอาท์สไลด์กำหนดการจัดเรียงตัวจับตำแหน่งเฉพาะสำหรับประเภทเนื้อหาที่ต่างกัน

**ฉันสามารถคัดลอกเลเอาท์สไลด์จากพรีเซนเทชันหนึ่งไปยังอีกพรีเซนเทชันหนึ่งได้หรือไม่?**

ได้ คุณสามารถโคลนเลเอาท์สไลด์จากคอลเลกชัน [LayoutSlides](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/layoutslides/) ของพรีเซนเทชันหนึ่งและแทรกลงในพรีเซนเทชันอื่นโดยใช้เมธอด `AddClone`

**ถ้าฉันลบเลเอาท์สไลด์ที่ยังถูกสไลด์อื่นอ้างถึงจะเกิดอะไรขึ้น?**

หากคุณพยายามลบเลเอาท์สไลด์ที่ยังถูกสไลด์อย่างน้อยหนึ่งสไลด์อ้างถึง Aspose.Slides จะโยนข้อยกเว้น [PptxEditException](https://reference.aspose.com/slides/th/net/aspose.slides/pptxeditexception/). เพื่อหลีกเลี่ยงปัญหานี้ให้ใช้เมธอด [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) ซึ่งจะลบเลเอาท์สไลด์ที่ไม่ได้ใช้อย่างปลอดภัย