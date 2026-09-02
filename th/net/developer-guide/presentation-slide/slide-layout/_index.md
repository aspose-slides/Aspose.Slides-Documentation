---
title: ใช้หรือเปลี่ยนรูปแบบสไลด์ใน .NET
linktitle: รูปแบบสไลด์
type: docs
weight: 60
url: /th/net/slide-layout/
keywords:
- รูปแบบสไลด์
- รูปแบบเนื้อหา
- ตารางตำแหน่ง
- การออกแบบงานนำเสนอ
- การออกแบบสไลด์
- รูปแบบที่ไม่ได้ใช้
- การมองเห็นส่วนท้าย
- สไลด์หัวเรื่อง
- หัวเรื่องและเนื้อหา
- ส่วนหัวของหัวข้อ
- สองเนื้อหา
- การเปรียบเทียบ
- หัวเรื่องเท่านั้น
- รูปแบบเปล่า
- เนื้อหาพร้อมคำอธิบายภาพ
- รูปภาพพร้อมคำอธิบายภาพ
- หัวเรื่องและข้อความแนวตั้ง
- หัวเรื่องแนวตั้งและข้อความ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- C#
- .NET
- Aspose.Slides
description: "ใช้, สร้าง และแก้ไขรูปแบบสไลด์ใน Aspose.Slides สำหรับ .NET, เพิ่มตารางตำแหน่ง, ลบรูปแบบที่ไม่ได้ใช้, และควบคุมการมองเห็นส่วนท้าย."
---
## **ภาพรวม**

รูปแบบสไลด์กำหนดตำแหน่งและรูปแบบของตารางตำแหน่ง (placeholder) เช่น ชื่อหัวข้อ, ข้อความ, รูปภาพ, แผนภูมิ, และตาราง การใช้รูปแบบทำให้สไลด์มีโครงสร้างที่สม่ำเสมอในขณะที่แต่ละสไลด์ยังคงมีเนื้อหาเฉพาะของตัวเอง

รูปแบบที่พบมากที่สุดได้แก่:

- **Title Slide**: มีตารางตำแหน่งสำหรับชื่อหัวข้อและหัวข้อย่อย
- **Title and Content**: มีตารางตำแหน่งชื่อหัวข้อและตารางตำแหน่งเนื้อหาทั่วไป
- **Blank**: ไม่มีตารางตำแหน่งเนื้อหาและเป็นประโยชน์เมื่อทุกรูปร่างจะถูกจัดตำแหน่งด้วยตนเอง

## **ทำความเข้าใจการสืบทอดรูปแบบ**

งานนำเสนอมีระดับที่เกี่ยวข้องกันสามระดับ:

1. A [master slide](https://reference.aspose.com/slides/th/net/aspose.slides/imasterslide/) กำหนดธีม, รูปแบบที่ใช้ร่วมกัน, พื้นหลัง, และวัตถุทั่วไป
2. A [layout slide](https://reference.aspose.com/slides/th/net/aspose.slides/ilayoutslide/) เป็นส่วนหนึ่งของ master และกำหนดการจัดเรียงตารางตำแหน่งเฉพาะ
3. A [normal slide](https://reference.aspose.com/slides/th/net/aspose.slides/islide/) ใช้รูปแบบหนึ่งและเก็บเนื้อหาที่ป้อนสำหรับสไลด์นั้น

สไลด์ทั่วไปสืบทอดธีมและรูปแบบจากรูปแบบของมัน, และรูปแบบสืบทอดจาก master ค่าที่กำหนดโดยตรงบนสไลด์ทั่วไปจะทับค่าที่สืบทอดในระดับนั้น เมื่อสร้างสไลด์ทั่วไป รูปแบบของตารางตำแหน่งจะถูกสร้างจากรูปแบบที่เลือก, ขณะที่เนื้อหาที่ป้อนในตารางตำแหน่งเหล่านั้นเป็นของสไลด์ทั่วไป

เพิ่มตารางตำแหน่งที่จำเป็นลงในรูปแบบก่อนสร้างสไลด์จากมัน การเพิ่มตารางตำแหน่งใหม่ในรูปแบบในภายหลังจะไม่ทำให้รูปแบบตารางตำแหน่งที่สอดคล้องกันถูกเพิ่มโดยอัตโนมัติให้กับสไลด์ทั่วไปที่มีอยู่

ความสัมพันธ์นี้มีผลสําคญสองประการ:

- การเปลี่ยนรูปแบบที่สืบทอดหรือเรขาคณิตของตารางตำแหน่งที่มีอยู่ในรูปแบบอาจอัปเดตทุกสไลด์ที่พึ่งพาอยู่ ก่อนแก้ไขรูปแบบที่กำลังใช้งานอยู่ ให้ตรวจสอบสไลด์ที่พึ่งพาและตรวจทานผลลัพธ์ของงานนำเสนอ
- รูปแบบที่ยังคงถูกสไลด์ใช้งานอยู่ไม่สามารถลบได้ ให้กำหนดสไลด์ที่พึ่งพาให้ใช้รูปแบบอื่นก่อน หรือทำการลบเฉพาะรูปแบบที่ไม่ได้ใช้เท่านั้น

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับระดับบนสุดของโครงสร้างนี้ ดูที่ [Slide Master](/slides/th/net/slide-master/).

## **เลือกและใช้รูปแบบสไลด์**

ใช้ประเภทรูปแบบเมื่อการนำเสนอปฏิบัติตามคำนิยามรูปแบบ PowerPoint มาตฐาน ชื่อรูปแบบสามารถแก้ไขได้โดยผู้ใช้และอาจแปลเป็นภาษาท้องถิ่นได้ ดังนั้นการเลือกโดยอ้างอิงชื่อจึงไม่น่าเชื่อถือ เว้นแต่คุณจะควบคุมแม่แบบต้นฉบับ

ตัวอย่างต่อไปนี้มองหา **Title and Content** บน master แรก หากรูปแบบนั้นไม่มีอยู่ จะย้อนกลับไปใช้ **Blank** อย่างตั้งใจ การตรวจสอบค่า null ครั้งที่สองจำเป็นเนื่องจากงานนำเสนออาจมีเฉพาะรูปแบบที่กำหนดเองเท่านั้น รูปแบบที่เลือกจะถูกนำไปใช้กับสไลด์ทั่วไปแรกผ่านคุณสมบัติ [ISlide.LayoutSlide](https://reference.aspose.com/slides/th/net/aspose.slides/islide/layoutslide/)

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlides = presentation.Masters[0].LayoutSlides;
var targetLayout = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Blank);

if (targetLayout == null)
{
    throw new InvalidOperationException("The first master does not contain a suitable layout slide.");
}

presentation.Slides[0].LayoutSlide = targetLayout;
presentation.Save("output-with-new-layout.pptx", SaveFormat.Pptx);
```

การเปลี่ยนรูปแบบของสไลด์จะไม่ลบรูปร่างทั่วไปที่เพิ่มโดยตรงให้กับสไลด์ อย่างไรก็ตาม ตำแหน่งของตารางตำแหน่ง, รูปแบบที่สืบทอด, และความสอดคล้องระหว่างตารางตำแหน่งที่มีอยู่กับรูปแบบใหม่อาจเปลี่ยนแปลง ดังนั้นให้ตรวจสอบผลลัพธ์เมื่อสลับระหว่างรูปแบบที่แตกต่างอย่างมาก

## **เพิ่มสไลด์รูปแบบ**

การเลือกและการสร้างเป็นการดำเนินการแยกกัน ตัวอย่างก่อนหน้าเลือกรูปแบบที่มีอยู่; ไม่ได้สร้างรูปแบบใหม่ เพื่อสร้างรูปแบบ ให้เรียกเมธอด [IMasterLayoutSlideCollection.Add](https://reference.aspose.com/slides/th/net/aspose.slides/masterlayoutslidecollection/add/) บนคอลเลกชันรูปแบบของ master เป้าหมาย

ตัวอย่างต่อไปนี้จะเพิ่มรูปแบบ **Title and Content** ใหม่ชื่อ `Report Title and Content` เสมอ จากนั้นเพิ่มสไลด์ทั่วไปตามรูปแบบนั้น ชื่อรูปแบบต้องไม่ซ้ำกันภายในคอลเลกชัน

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var masterSlide = presentation.Masters[0];
var reportLayout = masterSlide.LayoutSlides.Add(SlideLayoutType.TitleAndObject, "Report Title and Content");
presentation.Slides.AddEmptySlide(reportLayout);

presentation.Save("output-with-report-layout.pptx", SaveFormat.Pptx);
```

เพิ่มรูปแบบเฉพาะเมื่อเทมเพลตต้องการโครงสร้างที่ใช้ซ้ำได้อีกหนึ่งรูปแบบ หากมีรูปแบบที่เหมาะสมอยู่แล้ว ให้เลือกและใช้ซ้ำแทนการสร้างซ้ำ

## **เพิ่มตารางตำแหน่งให้กับสไลด์รูปแบบ**

คุณสมบัติ [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/th/net/aspose.slides/ilayoutslide/placeholdermanager/) ให้ [ILayoutPlaceholderManager](https://reference.aspose.com/slides/th/net/aspose.slides/ilayoutplaceholdermanager/) สำหรับเพิ่มรูปร่างตารางตำแหน่งลงในรูปแบบ

| ตารางตำแหน่ง PowerPoint | `ILayoutPlaceholderManager` เมธอด |
| -------------------------- | --------------------------------- |
| ![เนื้อหา](content.png) | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/net/aspose.slides/layoutplaceholdermanager/addcontentplaceholder/) |
| ![เนื้อหา (แนวตั้ง)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/net/aspose.slides/layoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![ข้อความ](text.png) | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/net/aspose.slides/layoutplaceholdermanager/addtextplaceholder/) |
| ![ข้อความ (แนวตั้ง)](textV.png) | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/net/aspose.slides/layoutplaceholdermanager/addverticaltextplaceholder/) |
| ![รูปภาพ](picture.png) | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/net/aspose.slides/layoutplaceholdermanager/addpictureplaceholder/) |
| ![แผนภูมิ](chart.png) | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/net/aspose.slides/layoutplaceholdermanager/addchartplaceholder/) |
| ![ตาราง](table.png) | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/net/aspose.slides/layoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png) | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/net/aspose.slides/layoutplaceholdermanager/addsmartartplaceholder/) |
| ![สื่อ](media.png) | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/net/aspose.slides/layoutplaceholdermanager/addmediaplaceholder/) |
| ![ภาพออนไลน์](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/net/aspose.slides/layoutplaceholdermanager/addonlineimageplaceholder/) |

ตัวอย่างต่อไปนี้ตรวจสอบว่ามีรูปแบบ **Blank** อยู่, เพิ่มตารางตำแหน่งสี่รายการลงไป, แล้วสร้างสไลด์ทั่วไปที่ใช้รูปแบบที่ปรับเปลี่ยนแล้ว การจัดลำดับนี้ตั้งใจไว้: ตารางตำแหน่งถูกเพิ่มก่อนสร้างสไลด์ทั่วไป เพื่อให้ Aspose.Slides สามารถสร้างรูปร่างตารางตำแหน่งที่สอดคล้องบนสไลด์นั้น

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (blankLayout == null)
{
    throw new InvalidOperationException("The presentation does not contain a Blank layout slide.");
}

var placeholderManager = blankLayout.PlaceholderManager;
placeholderManager.AddContentPlaceholder(20, 20, 310, 270);
placeholderManager.AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager.AddChartPlaceholder(20, 310, 310, 180);
placeholderManager.AddTablePlaceholder(350, 310, 350, 180);

presentation.Slides.AddEmptySlide(blankLayout);
presentation.Save("output-with-placeholders.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![ตารางตำแหน่งบนสไลด์รูปแบบ](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
การเปลี่ยนรูปแบบที่สืบทอดหรือเรขาคณิตของตารางตำแหน่งรูปแบบที่มีอยู่สามารถส่งผลต่อสไลด์ที่พึ่งพาได้ ตารางตำแหน่งรูปแบบที่เพิ่มใหม่จะไม่ถูกเติมกลับเข้าไปในสไลด์ทั่วไปที่มีอยู่ ทดสอบการเปลี่ยนแปลงรูปแบบบนสำเนาของงานนำเสนอและตรวจสอบสไลด์ที่พึ่งพาทุกสไลด์
{{% /alert %}}

## **ลบสไลด์รูปแบบที่ไม่ได้ใช้**

ใช้เมธอด [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) เพื่อลบรูปแบบที่ไม่มีสไลด์ทั่วไปอ้างอิง เมธอดจะปล่อยรูปแบบที่ยังใช้งานอยู่ให้คงอยู่

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
presentation.Save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
```

เพื่อทำการลบรูปแบบใดรูปแบบหนึ่ง ให้ใช้คุณสมบัติ [HasDependingSlides](https://reference.aspose.com/slides/th/net/aspose.slides/ilayoutslide/hasdependingslides/) หรือเมธอด [GetDependingSlides](https://reference.aspose.com/slides/th/net/aspose.slides/ilayoutslide/getdependingslides/) ของมัน ก่อนเรียก [ILayoutSlide.Remove](https://reference.aspose.com/slides/th/net/aspose.slides/ilayoutslide/remove/) ให้กำหนดสไลด์ที่พึ่งพาใหม่ การพยายามลบรูปแบบที่กำลังถูกใช้จะทำให้เกิด [PptxEditException](https://reference.aspose.com/slides/th/net/aspose.slides/pptxeditexception/)

## **ควบคุมการมองเห็นส่วนท้ายบนสไลด์รูปแบบ**

รูปแบบมีส่วนท้าย, ตัวเลขสไลด์, และตารางตำแหน่งวันที่และเวลาเป็นของตนเอง ใช้คุณสมบัติ [ILayoutSlide.HeaderFooterManager](https://reference.aspose.com/slides/th/net/aspose.slides/ilayoutslide/headerfootermanager/) เพื่อควบคุมตารางตำแหน่งเหล่านั้นสำหรับรูปแบบหนึ่ง ซึ่งมีประโยชน์เมื่อตัวอย่างเช่น รูปแบบเนื้อควรแสดงส่วนท้ายแต่รูปแบบหัวข้อไม่ควรแสดง

ตัวอย่างต่อไปนี้เลือกรูปแบบอย่างปลอดภัยและทำให้ส่วนท้ายของมันแสดงผล:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (layoutSlide == null)
{
    throw new InvalidOperationException("The presentation does not contain a suitable layout slide.");
}

var headerFooterManager = layoutSlide.HeaderFooterManager;
headerFooterManager.SetFooterVisibility(true);
headerFooterManager.SetSlideNumberVisibility(true);
headerFooterManager.SetDateTimeVisibility(true);
headerFooterManager.SetFooterText("Footer text");
headerFooterManager.SetDateTimeText("Date and time text");

presentation.Save("output-with-layout-footers.pptx", SaveFormat.Pptx);
```

## **ควบคุมการมองเห็นส่วนท้ายบน Master และรูปแบบลูกของมัน**

เพื่อใช้การตั้งค่าส่วนท้ายอย่างสอดคล้องกันทั่วทั้งลำดับชั้น master ให้ใช้คุณสมบัติ [IMasterSlide.HeaderFooterManager](https://reference.aspose.com/slides/th/net/aspose.slides/imasterslide/headerfootermanager/) วิธีการกระจายของ [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/th/net/aspose.slides/imasterslideheaderfootermanager/) ทำงานบน master และสไลด์รูปแบบและสไลด์ทั่วไปที่พึ่งพา; ไม่ได้มุ่งเป้าไปที่สไลด์ทั่วไปเพียงอันเดียว

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var headerFooterManager = presentation.Masters[0].HeaderFooterManager;
headerFooterManager.SetFooterAndChildFootersVisibility(true);
headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);
headerFooterManager.SetFooterAndChildFootersText("Footer text");
headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");

presentation.Save("output-with-master-footers.pptx", SaveFormat.Pptx);
```

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่าง Master Slide และ Layout Slide คืออะไร?**

Master slide กำหนดธีมและรูปแบบที่ใช้ร่วมกันของงานนำเสนอ Layout slide เป็นส่วนหนึ่งของ master และกำหนดการจัดเรียงตารางตำแหน่งที่ใช้ซ้ำได้หนึ่งแบบ สไลด์ทั่วไปใช้รูปแบบเหล่านั้นและเก็บเนื้อหาเฉพาะสไลด์

**ฉันสามารถคัดลอก Layout Slide จากงานนำเสนอหนึ่งไปยังงานนำเสนออื่นได้หรือไม่?**

ได้. ให้เพิ่มสำเนาไปยังคอลเลกชันปลายทางด้วยเมธอด [AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/globallayoutslidecollection/addclone/) เมื่อคัดลอกระหว่างงานนำเสนอ ควรตรวจสอบแบบอักษร, ธีม, รูปภาพ, และทรัพยากรอื่น ๆ ที่ใช้โดย Layout ต้นทางด้วย

**จะเกิดอะไรขึ้นเมื่อฉันแก้ไข Layout ที่กำลังใช้อยู่?**

สไลด์ที่พึ่งพาจะสืบทอดการเปลี่ยนแปลงรูปแบบ เว้นแต่พวกมันจะทับรูปแบบหรือวัตถุที่ได้รับผลกระทบในระดับท้องถิ่น ดังนั้นเรขาคณิตของตารางตำแหน่งและสไตล์ที่สืบทอดอาจเปลี่ยนแปลงหลายสไลด์พร้อมกัน ใช้ [GetDependingSlides](https://reference.aspose.com/slides/th/net/aspose.slides/ilayoutslide/getdependingslides/) เพื่อระบุสไลด์ที่ได้รับผลกระทบก่อนแก้ไขรูปแบบ

**จะเกิดอะไรขึ้นหากฉันลบ Layout ที่ยังคงถูกใช้งานอยู่?**

Aspose.Slides จะทำให้เกิด [PptxEditException](https://reference.aspose.com/slides/th/net/aspose.slides/pptxeditexception/). ให้กำหนดสไลด์ที่พึ่งพาใหม่ก่อน หรือใช้ [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) เพื่อลบเฉพาะรูปแบบที่ไม่ได้อ้างอิง