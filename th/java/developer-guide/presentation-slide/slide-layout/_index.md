---
title: ใช้หรือเปลี่ยนเค้าโครงสไลด์ใน Java
linktitle: เค้าโครงสไลด์
type: docs
weight: 60
url: /th/java/slide-layout/
keywords:
- เค้าโครงสไลด์
- เค้าโครงเนื้อหา
- ตัวจัดตำแหน่ง
- การออกแบบการนำเสนอ
- การออกแบบสไลด์
- เค้าโครงที่ไม่ได้ใช้
- การแสดงผลส่วนท้าย
- สไลด์หัวข้อ
- หัวข้อและเนื้อหา
- หัวข้อส่วน
- สองส่วนเนื้อหา
- การเปรียบเทียบ
- หัวข้อเท่านั้น
- เค้าโครงเปล่า
- เนื้อหาพร้อมคำอธิบาย
- รูปภาพพร้อมคำอธิบาย
- หัวข้อและข้อความแนวตั้ง
- หัวข้อแนวตั้งและข้อความ
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ใช้, สร้างและแก้ไขเค้าโครงสไลด์ใน Aspose.Slides สำหรับ Java, เพิ่มตัวจัดตำแหน่ง, ลบเค้าโครงที่ไม่ได้ใช้, และควบคุมการแสดงผลส่วนท้าย."
---
## **ภาพรวม**

เค้าโครงสไลด์กำหนดตำแหน่งและการจัดรูปแบบของตัวจัดตำแหน่งเช่น ชื่อเรื่อง, ข้อความ, รูปภาพ, แผนภูมิ, และตาราง การใช้เค้าโครงทำให้สไลด์มีโครงสร้างที่สอดคล้องกันในขณะที่แต่ละสไลด์สามารถมีเนื้อหาของตนเอง

เค้าโครงที่พบมากที่สุดได้แก่:

- **Title Slide**: มีตัวจัดตำแหน่งหัวข้อและหัวข้อย่อย
- **Title and Content**: มีตัวจัดตำแหน่งหัวข้อและตัวจัดตำแหน่งเนื้อหาทั่วไป
- **Blank**: ไม่มีตัวจัดตำแหน่งเนื้อหาและเหมาะสมเมื่อทุกรูปร่างจะถูกวางตำแหน่งโดยการจัดการด้วยตนเอง

## **ทำความเข้าใจการสืบทอดเค้าโครง**

การนำเสนอมีระดับที่เกี่ยวข้องกันสามระดับ:

1. A [master slide](https://reference.aspose.com/slides/th/java/com.aspose.slides/imasterslide/) กำหนดธีม การจัดรูปแบบที่ใช้ร่วมกัน พื้นหลัง และวัตถุทั่วไป
1. A [layout slide](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilayoutslide/) เป็นของ master และกำหนดการจัดเรียงตำแหน่งตัวจัดตำแหน่งเฉพาะ
1. A [normal slide](https://reference.aspose.com/slides/th/java/com.aspose.slides/islide/) ใช้เค้าโครงหนึ่งเค้าโครงและเก็บเนื้อหาที่ป้อนสำหรับสไลด์นั้น

สไลด์ปกติสืบทอดธีมและการจัดรูปแบบจากเค้าโครงของมัน, และเค้าโครงสืบทอดจาก master. ค่าที่ตั้งโดยตรงบนสไลด์ปกติจะเขียนทับค่าที่สืบทอดในระดับนั้น. เมื่อสไลด์ปกติถูกสร้าง, รูปร่างตัวจัดตำแหน่งจะถูกสร้างจากเค้าโครงที่เลือก, ส่วนเนื้อหาที่ป้อนในตัวจัดตำแหน่งนั้นเป็นของสไลด์ปกติ

เพิ่มตัวจัดตำแหน่งที่จำเป็นในเค้าโครงก่อนสร้างสไลด์จากมัน. การเพิ่มตัวจัดตำแหน่งอื่นในเค้าโครงภายหลังจะไม่เพิ่มรูปร่างตัวจัดตำแหน่งที่สอดคล้องในสไลด์ปกติที่มีอยู่โดยอัตโนมัติ

ความสัมพันธ์นี้มีผลสำคัญสองประการ:

- การเปลี่ยนการจัดรูปแบบที่สืบทอดหรือรูปทรงของตัวจัดตำแหน่งที่มีอยู่บนเค้าโครงสามารถอัปเดตทุกสไลด์ที่พึ่งพาเค้าโครงนั้นได้. ก่อนแก้ไขเค้าโครงที่กำลังใช้, ตรวจสอบสไลด์ที่พึ่งพาและทบทวนผลลัพธ์ของการนำเสนอ
- เค้าโครงที่ยังถูกสไลด์ใช้งานไม่สามารถลบได้. ให้ย้ายสไลด์ที่พึ่งพาไปยังเค้าโครงอื่นก่อน, หรือทำการลบเฉพาะเค้าโครงที่ไม่ได้ใช้เท่านั้น

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับระดับบนของโครงสร้างนี้, ดูที่ [Slide Master](/slides/th/java/slide-master/)

เพื่อซ่อนโลโก้หรือรูปทรง master ที่ตกแต่งซึ่งสืบทอดบนสไลด์หนึ่งหรือผ่านเค้าโครงที่ใช้ร่วมกัน, ดูที่ [Control the Visibility of Master Graphics](/slides/th/java/slide-master/). ตัวอย่างเปรียบเทียบสองสไลด์ที่ใช้ master เดียวกัน

## **เลือกและใช้เค้าโครงสไลด์**

ใช้ประเภทเค้าโครงเมื่อการนำเสนอปฏิบัติตามคำนิยามเค้าโครง PowerPoint มาตรฐาน. ชื่อเค้าโครงสามารถแก้ไขได้โดยผู้ใช้และอาจแปลเป็นภาษาต่างๆ, ดังนั้นการเลือกโดยอิงชื่ออาจไม่น่าเชื่อถือหากคุณไม่ได้ควบคุมเทมเพลตต้นฉบับ

ตัวอย่างต่อไปนี้ค้นหา **Title and Content** บน master แรก. หากเค้าโครงนั้นไม่มี, ระบบจะย้อนกลับไปใช้ **Blank** อย่างเจตนา. การตรวจสอบ null ครั้งที่สองจำเป็นเพราะการนำเสนออาจมีเฉพาะเค้าโครงที่กำหนดเอง. เค้าโครงที่เลือกจะถูกนำไปใช้กับสไลด์ปกติแรกผ่านเมธอด [ISlide.setLayoutSlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-) 

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide targetLayout = layoutSlides.getByType(SlideLayoutType.TitleAndObject);

    if (targetLayout == null) {
        targetLayout = layoutSlides.getByType(SlideLayoutType.Blank);
    }

    if (targetLayout == null) {
        throw new IllegalStateException("The first master does not contain a suitable layout slide.");
    }

    presentation.getSlides().get_Item(0).setLayoutSlide(targetLayout);
    presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การเปลี่ยนเค้าโครงของสไลด์ไม่ทำการลบรูปร่างปกติที่เพิ่มโดยตรงไปยังสไลด์. อย่างไรก็ตาม, ตำแหน่งตัวจัดตำแหน่ง, การจัดรูปแบบที่สืบทอด, และความสอดคล้องระหว่างตัวจัดตำแหน่งที่มีอยู่กับเค้าโครงใหม่อาจเปลี่ยนแปลง, ดังนั้นควรตรวจสอบผลลัพธ์เมื่อสลับระหว่างเค้าโครงที่แตกต่างอย่างมาก

## **เพิ่มเค้าโครงสไลด์**

การเลือกและการสร้างเป็นการดำเนินการแยกกัน. ตัวอย่างก่อนหน้าเลือกเค้าโครงที่มีอยู่; ไม่ได้สร้างใหม่. เพื่อสร้างเค้าโครง, เรียกเมธอด [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/th/java/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) บนคอลเลกชันเค้าโครงของ master เป้าหมาย

ตัวอย่างต่อไปนี้จะเพิ่มเค้าโครง **Title and Content** ใหม่ชื่อ `Report Title and Content` เสมอ, จากนั้นเพิ่มสไลด์ปกติที่อ้างอิงเค้าโครงนั้น. ชื่อเค้าโครงต้องไม่ซ้ำกันภายในคอลเลกชัน

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide reportLayout = masterSlide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content");
    presentation.getSlides().addEmptySlide(reportLayout);

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

เพิ่มเค้าโครงเฉพาะเมTemplateต้องการโครงสร้างที่ใช้ซ้ำได้จริง. หากมีเค้าโครงที่เหมาะสมแล้ว, ให้เลือกและใช้ซ้ำแทนการสร้างเค้าโครงซ้ำซ้อน

## **เพิ่มตัวจัดตำแหน่งในเค้าโครงสไลด์**

เมธอด [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) ให้บริการ [ILayoutPlaceholderManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilayoutplaceholdermanager/) เพื่อเพิ่มรูปร่างตัวจัดตำแหน่งในเค้าโครง

| ตัวจัดตำแหน่ง PowerPoint | `ILayoutPlaceholderManager` Method |
| -------------------------- | ---------------------------------- |
| ![เนื้อหา](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![เนื้อหา (แนวตั้ง)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![ข้อความ](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![ข้อความ (แนวตั้ง)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![รูปภาพ](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![แผนภูมิ](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![ตาราง](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![สื่อ](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![รูปภาพออนไลน์](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

ตัวอย่างต่อไปนี้ตรวจสอบว่าเค้าโครง **Blank** มีอยู่, เพิ่มสี่ตัวจัดตำแหน่งเข้าไป, จากนั้นสร้างสไลด์ปกติที่ใช้เค้าโครงที่แก้ไขแล้ว. การจัดลำดับเป็นเจตนา: ตัวจัดตำแหน่งถูกเพิ่มก่อนสร้างสไลด์ปกติ, เพื่อให้ Aspose.Slides สร้างรูปร่างตัวจัดตำแหน่งที่สอดคล้องบนสไลด์นั้น

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayout == null) {
        throw new IllegalStateException("The presentation does not contain a Blank layout slide.");
    }

    ILayoutPlaceholderManager placeholderManager = blankLayout.getPlaceholderManager();
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    presentation.getSlides().addEmptySlide(blankLayout);
    presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ตัวจัดตำแหน่งบนเค้าโครงสไลด์](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
การเปลี่ยนการจัดรูปแบบที่สืบทอดหรือรูปทรงของตัวจัดตำแหน่งที่มีอยู่บนเค้าโครงอาจส่งผลต่อสไลด์ที่พึ่งพา. ตัวจัดตำแหน่งที่เพิ่มใหม่จะไม่ถูกเติมย้อนกลับไปยังสไลด์ปกติที่มีอยู่. ควรทดสอบการเปลี่ยนแปลงเค้าโครงบนสำเนาของการนำเสนอและตรวจสอบทุกสไลด์ที่พึ่งพา
{{% /alert %}}

## **ลบเค้าโครงสไลด์ที่ไม่ได้ใช้**

ใช้เมธอด [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/th/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) เพื่อลบเค้าโครงที่ไม่มีสไลด์ปกติอ้างอิง. เมธอดจะคงเค้าโครงที่ยังใช้งานอยู่ไว้

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

เพื่อเอาเค้าโครงเฉพาะออก, ก่อนอื่นใช้เมธอด [hasDependingSlides](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilayoutslide/#hasDependingSlides--) หรือ [getDependingSlides](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) ของมัน. ย้ายสไลด์ที่พึ่งพาก่อนเรียก [ILayoutSlide.remove](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilayoutslide/#remove--). การพยายามลบเค้าโครงที่ยังใช้งานจะทำให้เกิด [PptxEditException](https://reference.aspose.com/slides/th/java/com.aspose.slides/pptxeditexception/)

## **ควบคุมการแสดงผลส่วนท้ายบนเค้าโครงสไลด์**

เค้าโครงมีส่วนท้ายของตนเอง, ตัวเลขสไลด์, และตัวจัดตำแหน่งวันที่/เวลา. ใช้เมธอด [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) เพื่อควบคุมตัวจัดตำแหน่งเหล่านั้นสำหรับเค้าโครงหนึ่ง. ตัวอย่างเช่น, เค้าโครงเนื้อหาควรแสดงส่วนท้ายแต่เค้าโครงหัวข้อไม่ควรแสดง

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject);

    if (layoutSlide == null) {
        layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    }

    if (layoutSlide == null) {
        throw new IllegalStateException("The presentation does not contain a suitable layout slide.");
    }

    ILayoutSlideHeaderFooterManager headerFooterManager = layoutSlide.getHeaderFooterManager();
    headerFooterManager.setFooterVisibility(true);
    headerFooterManager.setSlideNumberVisibility(true);
    headerFooterManager.setDateTimeVisibility(true);
    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ควบคุมการแสดงผลส่วนท้ายบน Master และเค้าโครงลูกของมัน**

เพื่อกำหนดการตั้งค่าส่วนท้ายให้สอดคล้องทั่วทั้งโครงสร้าง master, ใช้เมธอด [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/imasterslide/#getHeaderFooterManager--) . วิธีการกระจายของ [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/imasterslideheaderfootermanager/) ทำงานบน master, เค้าโครงและสไลด์ปกติที่พึ่งพา; ไม่ได้มุ่งเป้าแค่สไลด์ปกติเดียว

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);
    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**What Is the Difference Between a Master Slide and a Layout Slide?**

Master slide กำหนดธีมและการจัดรูปแบบที่ใช้ร่วมกันของการนำเสนอ. Layout slide เป็นของ master และกำหนดการจัดเรียงตัวจัดตำแหน่งที่ใช้ซ้ำได้หนึ่งแบบ. สไลด์ปกติใช้เค้าโครงเหล่านั้นและเก็บเนื้อหาเฉพาะสไลด์

**Can I Copy a Layout Slide from One Presentation to Another?**

ได้. ใช้เมธอด [addClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) เพื่อเพิ่มสำเนาไปยังคอลเลกชันปลายทาง. เมื่อคัดลอกจากการนำเสนอหนึ่งไปยังอีกการนำเสนอหนึ่ง, ควรตรวจสอบฟอนต์, ธีม, รูปภาพและทรัพยากรอื่นที่ layout ใช้

**What Happens When I Modify a Layout That Is Already in Use?**

สไลด์ที่พึ่งพาจะสืบทอดการเปลี่ยนแปลงของเค้าโครง, ยกเว้นว่าพวกมันได้เขียนทับการจัดรูปแบบหรือวัตถุที่เกี่ยวข้องในระดับท้องถิ่น. รูปร่างตัวจัดตำแหน่งและสไตล์ที่สืบทอดอาจเปลี่ยนแปลงบนสไลด์หลายอันพร้อมกัน. ใช้ [getDependingSlides](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) เพื่อระบุสไลด์ที่ได้รับผลกระทบก่อนแก้ไขเค้าโครง

**What Happens If I Remove a Layout That Is Still in Use?**

Aspose.Slides จะโยน [PptxEditException](https://reference.aspose.com/slides/th/java/com.aspose.slides/pptxeditexception/). ให้ย้ายสไลด์ที่พึ่งพาก่อน, หรือใช้ [removeUnusedLayoutSlides](https://reference.aspose.com/slides/th/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) เพื่อลบเฉพาะเค้าโครงที่ไม่มีการอ้างอิง.