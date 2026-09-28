---
title: ใช้หรือเปลี่ยนเค้าโครงสไลด์ใน .NET
linktitle: เค้าโครงสไลด์
type: docs
weight: 60
url: /th/net/slide-layout/
keywords:
- เค้าโครงสไลด์
- เค้าโครงเนื้อหา
- ตัวตำแหน่ง
- การออกแบบการนำเสนอ
- การออกแบบสไลด์
- เค้าโครงที่ไม่ได้ใช้
- การมองเห็นส่วนท้
- สไลด์ชื่อเรื่อง
- ชื่อเรื่องและเนื้อหา
- หัวข้อส่วน
- สองส่วนเนื้อหา
- การเปรียบเทียบ
- เฉพาะชื่อเรื่อง
- เค้าโครงเปล่า
- เนื้อหาพร้อมคำอธิบาย
- รูปภาพพร้อมคำอธิบาย
- ชื่อเรื่องและข้อความแนวตั้ง
- ชื่อเรื่องแนวตั้งและข้อความ
- PowerPoint
- OpenDocument
- การนำเสนอ
- C#
- .NET
- Aspose.Slides
description: "ใช้, สร้างและแก้ไขเค้าโครงสไลด์ใน Aspose.Slides สำหรับ .NET, เพิ่มตัวตำแหน่ง, ลบเค้าโครงที่ไม่ได้ใช้, และควบคุมการมองเห็นส่วนท้าย."
---
## **ภาพรวม**

เค้าโครงสไลด์กำหนดตำแหน่งและการจัดรูปแบบของตัวตำแหน่งเช่น ชื่อเรื่อง, ข้อความ, รูปภาพ, แผนภูมิ และตาราง การใช้เค้าโครงทำให้สไลด์มีโครงสร้างสม่ำเสมอขณะยังให้แต่ละสไลด์สามารถมีเนื้อหาเองได้

เค้าโครงที่พบบ่อยที่สุดได้แก่:

- **Title Slide**: มีตัวตำแหน่งชื่อเรื่องและชื่อเรื่องย่อย
- **Title and Content**: มีตัวตำแหน่งชื่อเรื่องและตัวตำแหน่งเนื้อหาทั่วไป
- **Blank**: ไม่มีตัวตำแหน่งเนื้อหาและมีประโยชน์เมื่อทุกรูปร่างจะถูกจัดตำแหน่งด้วยตนเอง

## **ทำความเข้าใจการสืบทอดเค้าโครง**

งานนำเสนอมีระดับที่เกี่ยวข้องสามระดับ:

1. A [master slide](https://reference.aspose.com/slides/th/net/aspose.slides/imasterslide/) กำหนดธีม, การจัดรูปแบบที่ใช้ร่วม, พื้นหลัง, และอ็อบเจกต์ทั่วไป.
2. A [layout slide](https://reference.aspose.com/slides/th/net/aspose.slides/ilayoutslide/) เป็นส่วนของ master และกำหนดการจัดเรียงเฉพาะของตัวตำแหน่ง.
3. A [normal slide](https://reference.aspose.com/slides/th/net/aspose.slides/islide/) ใช้เค้าโครงหนึ่งและเก็บเนื้อหาที่ป้อนสำหรับสไลด์นั้น.

สไลด์ปกติสืบทอดธีมและการจัดรูปแบบจากเค้าโครงของมัน, และเค้าโครงสืบทอดจาก master. ค่าที่ตั้งโดยตรงบนสไลด์ปกติจะทับค่าที่สืบทอดในระดับนั้น. เมื่อสไลด์ปกติถูกสร้าง, รูปร่างตัวตำแหน่งจะถูกสร้างจากเค้าโครงที่เลือก, ในขณะที่เนื้อหาที่ป้อนในตัวตำแหน่งนั้นเป็นของสไลด์ปกติ.

เพิ่มตัวตำแหน่งที่จำเป็นลงในเค้าโครงก่อนสร้างสไลด์จากมัน. การเพิ่มตัวตำแหน่งอื่นลงในเค้าโครงภายหลังจะไม่เพิ่มรูปทรงตัวตำแหน่งที่สอดคล้องให้กับสไลด์ปกติที่มีอยู่โดยอัตโนมัติ.

ความสัมพันธ์นี้มีผลสำคัญสองประการ:

- การเปลี่ยนแปลงการจัดรูปแบบที่สืบทอดหรือรูปทรงของตัวตำแหน่งที่มีอยู่บนเค้าโครงอาจอัปเดตสไลด์ทุกสไลด์ที่พึ่งพาอยู่. ก่อนแก้ไขเค้าโครงที่กำลังใช้อยู่ให้ตรวจสอบสไลด์ที่พึ่งพาและตรวจสอบการนำเสนอที่ได้.
- เค้าโครงที่ยังถูกสไลด์ใช้อยู่ไม่สามารถลบได้. ต้องกำหนดสไลด์ที่พึ่งพาไปยังเค้าโครงอื่นก่อน, หรือเพียงลบเค้าโครงที่ไม่ได้ใช้.

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับระดับบนสุดของโครงสร้างนี้ ดูที่ [Slide Master](/slides/th/net/slide-master/).

เพื่อซ่อนโลโก้ที่สืบทอดหรือรูปแบบ master ที่เป็นการตกแต่งบนสไลด์เดียวหรือผ่านเค้าโครงที่ใช้ร่วม ดูที่ [Control the Visibility of Master Graphics](/slides/th/net/slide-master/). ตัวอย่างเปรียบเทียบสองสไลด์ที่ใช้ master เดียวกัน.

## **เลือกและใช้เค้าโครงสไลด์**

ใช้ประเภทเค้าโครงเมื่อการนำเสนอทำตามคำนิยามเค้าโครง PowerPoint มาตรฐาน. ชื่อเค้าโครงสามารถแก้ไขโดยผู้ใช้และสามารถแปลได้, ดังนั้นการเลือกตามชื่อจึงน่าเชื่อถือน้อยกว่า หากคุณไม่ได้ควบคุมเทมเพลตต้นฉบับ.

ตัวอย่างต่อไปนี้ค้นหา **Title and Content** บน master แรก. หากเค้าโครงนั้นไม่มีอยู่, จะกลับไปใช้ **Blank** อย่างตั้งใจ. การตรวจสอบค่า null ครั้งที่สองจำเป็นเนื่องจากการนำเสนออาจมีเฉพาะเค้าโครงที่กำหนดเองเท่านั้น. เค้าโครงที่เลือกจะถูกนำไปใช้กับสไลด์ปกติแรกผ่านคุณสมบัติ [ISlide.LayoutSlide](https://reference.aspose.com/slides/th/net/aspose.slides/islide/layoutslide/).

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

การเปลี่ยนเค้าโครงของสไลด์ไม่ทำให้รูปทรงทั่วไปที่เพิ่มโดยตรงบนสไลด์หายไป. อย่างไรก็ตาม, ตำแหน่งของตัวตำแหน่ง, การจัดรูปแบบที่สืบทอด, และความสอดคล้องระหว่างตัวตำแหน่งที่มีอยู่กับเค้าโครงใหม่อาจเปลี่ยนแปลง, ดังนั้นควรตรวจสอบผลลัพธ์เมื่อสลับระหว่างเค้าโครงที่แตกต่างอย่างมาก.

## **เพิ่มเค้าโครงสไลด์**

การเลือกและการสร้างเป็นการดำเนินการแยกกัน. ตัวอย่างก่อนหน้านี้เลือกเค้าโครงที่มีอยู่; ไม่ได้สร้างเค้าโครงใหม่. การสร้างเค้าโครงให้เรียกเมธอด [IMasterLayoutSlideCollection.Add](https://reference.aspose.com/slides/th/net/aspose.slides/masterlayoutslidecollection/add/) บนคอล렉ชันเค้าโครงของ master ที่ต้องการ.

ตัวอย่างต่อไปนี้จะเพิ่มเค้าโครง **Title and Content** ใหม่ที่ชื่อ `Report Title and Content` เสมอ, แล้วจึงเพิ่มสไลด์ปกติที่อิงตามเค้าโครงนั้น. ชื่อเค้าโครงต้องไม่ซ้ำกันภายในคอล렉ชัน.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var masterSlide = presentation.Masters[0];
var reportLayout = masterSlide.LayoutSlides.Add(SlideLayoutType.TitleAndObject, "Report Title and Content");
presentation.Slides.AddEmptySlide(reportLayout);

presentation.Save("output-with-report-layout.pptx", SaveFormat.Pptx);
```

เพิ่มเค้าโครงเฉพ็ตเมื่อเทมเพลตต้องการโครงสร้างที่ใช้ซ้ำได้จริง ๆ. หากมีเค้าโครงที่เหมาะสมอยู่แล้ว, ให้เลือกและใช้ซ้ำแทนการสร้างสำเนาใหม่.

## **เพิ่มตัวตำแหน่งลงในเค้าโครงสไลด์**

คุณสมบัติ [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/th/net/aspose.slides/ilayoutslide/placeholdermanager/) ให้ [ILayoutPlaceholderManager](https://reference.aspose.com/slides/th/net/aspose.slides/ilayoutplaceholdermanager/) สำหรับการเพิ่มรูปทรงตัวตำแหน่งลงในเค้าโครง.

| PowerPoint Placeholder | `ILayoutPlaceholderManager` Method |
| ---------------------- | ---------------------------------- |
| ![เนื้อหา](content.png) | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/net/aspose.slides/layoutplaceholdermanager/addcontentplaceholder/) |
| ![เนื้อหา (แนวตั้ง)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/net/aspose.slides/layoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![ข้อความ](text.png) | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/net/aspose.slides/layoutplaceholdermanager/addtextplaceholder/) |
| ![ข้อความ (แนวตั้ง)](textV.png) | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/net/aspose.slides/layoutplaceholdermanager/addverticaltextplaceholder/) |
| ![รูปภาพ](picture.png) | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/net/aspose.slides/layoutplaceholdermanager/addpictureplaceholder/) |
| ![แผนภูมิ](chart.png) | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/net/aspose.slides/layoutplaceholdermanager/addchartplaceholder/) |
| ![ตาราง](table.png) | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/net/aspose.slides/layoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png) | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/net/aspose.slides/layoutplaceholdermanager/addsmartartplaceholder/) |
| ![สื่อ](media.png) | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/net/aspose.slides/layoutplaceholdermanager/addmediaplaceholder/) |
| ![รูปภาพออนไลน์](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/net/aspose.slides/layoutplaceholdermanager/addonlineimageplaceholder/) |

ตัวอย่างต่อไปนี้ตรวจสอบว่าเค้าโครง **Blank** มีอยู่, เพิ่มตัวตำแหน่งสี่รายการลงในนั้น, แล้วสร้างสไลด์ปกติที่ใช้เค้าโครงที่แก้ไขแล้ว. ลำดับการทำเป็นตามเจตนา: ตัวตำแหน่งถูกเพิ่มก่อนสร้างสไลด์ปกติ, เพื่อให้ Aspose.Slides สามารถสร้างรูปทรงตัวตำแหน่งที่สอดคล้องบนสไลด์นั้น.

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

![ตัวตำแหน่งบนเค้าโครงสไลด์](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
การเปลี่ยนแปลงการจัดรูปแบบที่สืบทอดหรือรูปทรงของตัวตำแหน่งเค้าโครงที่มีอยู่สามารถส่งผลต่อสไลด์ที่พึ่งพา. ตัวตำแหน่งเค้าโครงที่เพิ่มใหม่จะไม่ถูกเติมกลับเข้าสู่สไลด์ปกติที่มีอยู่. ทดสอบการเปลี่ยนแปลงเค้าโครงบนสำเนาของการนำเสนอและตรวจสอบสไลด์ที่พึ่งพาทุกสไลด์.
{{% /alert %}}

## **ลบเค้าโครงสไลด์ที่ไม่ได้ใช้**

ใช้เมธอด [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) เพื่อลบเค้าโครงที่ไม่มีสไลด์ปกติใดอ้างอิง. เมธอดจะคงเค้าโครงที่ยังถูกใช้อยู่ไว้ไม่มีการเปลี่ยนแปลง.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
presentation.Save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
```

เพื่อทำการลบเค้าโครงเฉพาะหนึ่ง, ให้ใช้คุณสมบัติ [HasDependingSlides](https://reference.aspose.com/slides/th/net/aspose.slides/ilayoutslide/hasdependingslides/) หรือเมธอด [GetDependingSlides](https://reference.aspose.com/slides/th/net/aspose.slides/ilayoutslide/getdependingslides/) ก่อน. จากนั้นกำหนดสไลด์ที่พึ่งพาใหม่ก่อนเรียก [ILayoutSlide.Remove](https://reference.aspose.com/slides/th/net/aspose.slides/ilayoutslide/remove/). การพยายามลบเค้าโครงที่กำลังใช้งานจะทำให้เกิด [PptxEditException](https://reference.aspose.com/slides/th/net/aspose.slides/pptxeditexception/).

## **ควบคุมการมองเห็นส่วนท้ายบนเค้าโครงสไลด์**

เค้าโครงมีตัวตำแหน่งส่วนท้าย, ตัวเลขสไลด์, และวันที่‑เวลา ของตัวเอง. ใช้คุณสมบัติ [ILayoutSlide.HeaderFooterManager](https://reference.aspose.com/slides/th/net/aspose.slides/ilayoutslide/headerfootermanager/) เพื่อควบคุมตัวตำแหน่งเหล่านี้สำหรับเค้าโครงหนึ่ง, ซึ่งมีประโยชน์ในกรณีเช่น เค้าโครงเนื้อหาควรแสดงส่วนท้ายแต่เค้าโครงหัวข้อไม่ควร.

ตัวอย่างต่อไปนี้เลือกเค้าโครงอย่างปลอดภัยและทำให้ส่วนของส่วนท้ายแสดงผล:

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

## **ควบคุมการมองเห็นส่วนท้ายบน Master และเค้าโครงลูกของมัน**

เพื่อกำหนดการตั้งค่าส่วนท้ายที่สอดคล้องทั่วทั้งลำดับชั้น master, ให้ใช้คุณสมบัติ [IMasterSlide.HeaderFooterManager](https://reference.aspose.com/slides/th/net/aspose.slides/imasterslide/headerfootermanager/). วิธีการกระจายของ [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/th/net/aspose.slides/imasterslideheaderfootermanager/) ทำงานบน master และเค้าโครงสไลด์ที่พึ่งพา, รวมถึงสไลด์ปกติ; ไม่ได้มุ่งเป้าเพียงสไลด์ปกติเดียว.

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

**ความแตกต่างระหว่าง Master Slide กับ Layout Slide คืออะไร?**

master slide กำหนดธีมและการจัดรูปแบบที่ใช้ร่วมของการนำเสนอ. layout slide เป็นส่วนของ master และกำหนดการจัดเรียงตัวตำแหน่งที่ใช้ซ้ำได้หนึ่งแบบ. สไลด์ปกติใช้เค้าโครงเหล่านี้และเก็บเนื้อหาเฉพาะสไลด์.

**ฉันสามารถคัดลอก Layout Slide จากการนำเสนอหนึ่งไปยังอีกการนำเสนอได้หรือไม่?**

ได้. เพิ่มสำเนาไปยังคอลเลกชันปลายทางด้วยเมธอด [AddClone](https://reference.aspose.com/slides/th/net/aspose.slides/globallayoutslidecollection/addclone/). เมื่อคัดลอกระหว่างการนำเสนอควรตรวจสอบฟอนต์, ธีม, รูปภาพ, และทรัพยากรอื่น ๆ ที่ใช้โดย layout ต้นฉบับ.

**จะเกิดอะไรขึ้นเมื่อฉันแก้ไข Layout ที่กำลังถูกใช้อยู่?**

สไลด์ที่พึ่งพาจะสืบรับการเปลี่ยนแปลงของ layout ยกเว้นว่าพวกมันได้ทับการจัดรูปแบบหรืออ็อบเจกต์ที่ได้รับผลกระทบในระดับท้องถิ่น. ดังนั้นรูปทรงของตัวตำแหน่งและสไตล์ที่สืบทอดอาจเปลี่ยนบนหลายสไลด์พร้อมกัน. ใช้ [GetDependingSlides](https://reference.aspose.com/slides/th/net/aspose.slides/ilayoutslide/getdependingslides/) เพื่อระบุสไลด์ที่ได้รับผลกระทบก่อนแก้ไขเค้าโครง.

**จะเกิดอะไรขึ้นหากฉันลบ Layout ที่ยังถูกใช้อยู่?**

Aspose.Slides จะโยน [PptxEditException](https://reference.aspose.com/slides/th/net/aspose.slides/pptxeditexception/). ให้กำหนดสไลด์ที่พึ่งพาใหม่ก่อน, หรือใช้ [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/th/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) เพื่อลบเฉพาะเค้าโครงที่ไม่มีการอ้างอิง.