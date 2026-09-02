---
title: นำไปใช้หรือเปลี่ยนแปลงเลเอาต์สไลด์ใน Java
linktitle: เลเอาต์สไลด์
type: docs
weight: 60
url: /th/java/slide-layout/
keywords:
- เลเอาต์สไลด์
- เลเอาต์เนื้อหา
- ส่วนเติม
- การออกแบบการนำเสนอ
- การออกแบบสไลด์
- เลเอาต์ที่ไม่ได้ใช้
- การมองเห็นส่วนเท้า
- สไลด์หัวเรื่อง
- หัวเรื่องและเนื้อหา
- หัวเรื่องส่วน
- สองส่วนเนื้อหา
- การเปรียบเทียบ
- หัวเรื่องเท่านั้น
- เลเอาต์เปล่า
- เนื้อหาพร้อมคำบรรยาย
- รูปภาพพร้อมคำบรรยาย
- หัวเรื่องและข้อความแนวตั้ง
- หัวเรื่องแนวตั้งและข้อความ
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "นำไปใช้, สร้างและแก้ไขเลเอาต์สไลด์ใน Aspose.Slides สำหรับ Java, เพิ่มส่วนเติม, ลบเลเอาต์ที่ไม่ได้ใช้, และควบคุมการมองเห็นส่วนเท้า."
---
## **ภาพรวม**

เลเอาต์ของสไลด์กำหนดตำแหน่งและการจัดรูปแบบของส่วนเติม (placeholder) เช่น ชื่อเรื่อง, ข้อความ, รูปภาพ, แผนภูมิ, และตาราง การใช้เลเอาต์ทำให้สไลด์มีโครงสร้างสอดคล้องกันขณะยังให้สไลด์แต่ละอันสามารถมีเนื้อหาของตนเองได้

เลเอาต์ที่พบบ่อยที่สุดได้แก่:

- **สไลด์หัวเรื่อง**: มีส่วนเติมชื่อเรื่องและหัวข้อย่อย
- **หัวเรื่องและเนื้อหา**: มีส่วนเติมชื่อเรื่องและส่วนเติมเนื้อหาทั่วไป
- **เปล่า**: ไม่มีส่วนเติมใด ๆ เหมาะเมื่อทุกรูปร่างจะถูกจัดตำแหน่งด้วยตนเอง

## **ทำความเข้าใจการสืบทอดเลเอาต์**

การนำเสนอมีระดับที่เกี่ยวข้องกันสามระดับ:

1. A [master slide](https://reference.aspose.com/slides/th/java/com.aspose.slides/imasterslide/) กำหนดธีม, การจัดรูปแบบที่ใช้ร่วมกัน, พื้นหลัง, และวัตถุทั่วไป
2. A [layout slide](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilayoutslide/) เป็นส่วนหนึ่งของมาสเตอร์และกำหนดการจัดเรียงส่วนเติมเฉพาะ
3. A [normal slide](https://reference.aspose.com/slides/th/java/com.aspose.slides/islide/) ใช้เลเอาต์หนึ่งและเก็บเนื้อหาที่ป้อนเข้าสำหรับสไลด์นั้น

สไลด์ปกติสืบทอดธีมและการจัดรูปแบบจากเลเอาต์ของมัน, และเลเอาต์สืบทอดจากมาสเตอร์ ค่าที่ตั้งโดยตรงบนสไลด์ปกติจะทับค่าที่สืบทอดในระดับนั้น เมื่อสร้างสไลด์ปกติ รูปร่างส่วนเติมจะถูกสร้างจากเลเอาต์ที่เลือก, ขณะที่เนื้อหาที่ป้อนในส่วนเติมนั้นเป็นของสไลด์ปกติ

เพิ่มส่วนเติมที่จำเป็นให้กับเลเอาต์ก่อนสร้างสไลด์จากมัน การเพิ่มส่วนเติมใหม่ในภายหลังจะไม่ทำให้รูปร่างส่วนเติมที่สอดคล้องกันถูกเพิ่มอัตโนมัติให้กับสไลด์ปกติที่มีอยู่แล้ว

ความสัมพันธ์นี้มีผลลัพธ์สำคัญสองประการ:

- การเปลี่ยนแปลงการจัดรูปแบบที่สืบทอดหรือเรขาคณิตของส่วนเติมที่มีอยู่บนเลเอาต์สามารถอัปเดตสไลด์ทุกอันที่พึ่งพามัน ก่อนแก้ไขเลเอาต์ที่ใช้งานอยู่แล้ว ให้ตรวจสอบสไลด์ที่พึ่งพาและทบทวนผลลัพธ์ของการนำเสนอ
- เลเอาต์ที่ยังถูกสไลด์ใดสไลด์หนึ่งใช้ไม่สามารถลบได้ ต้องกำหนดสไลด์ที่พึ่งพาให้ใช้เลเอาต์อื่นก่อน, หรือเพียงลบเลเอาต์ที่ไม่ได้ใช้เท่านั้น

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับระดับบนสุดของลำดับชั้นนี้, ดูที่ [Slide Master](/slides/th/java/slide-master/)

## **เลือกและใช้เลเอาต์สไลด์**

ใช้ประเภทเลเอาต์เมื่อการนำเสนอปฏิบัติตามคำนิยามเลเอาต์มาตรฐานของ PowerPoint ชื่อเลเอาต์สามารถแก้ไขได้โดยผู้ใช้และสามารถแปลเป็นภาษาต่าง ๆ ได้ ดังนั้นการเลือกตามชื่อจึงน้อยความน่าเชื่อถือ หากคุณไม่ได้ควบคุมเทมเพลตต้นฉบับ

ตัวอย่างต่อไปนี้ค้นหา **หัวเรื่องและเนื้อหา** บนมาสเตอร์แรก หากเลเอาต์นั้นไม่มีอยู่ จะพยายามใช้ **เปล่า** แทน การตรวจสอบค่า null ครั้งที่สองจำเป็นเพราะการนำเสนออาจมีเพียงเลเอาต์แบบกำหนดเองเท่านั้น เลเอาต์ที่เลือกจากนั้นจะถูกนำไปใช้กับสไลด์ปกติเพื่อแรกผ่านเมธอด [ISlide.setLayoutSlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-)  

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

การเปลี่ยนเลเอาต์ของสไลด์ไม่ได้ลบรูปร่างปกติที่เพิ่มโดยตรงลงบนสไลด์ อย่างไรก็ตามตำแหน่งส่วนเติม, การจัดรูปแบบที่สืบทอด, และความสอดคล้องระหว่างส่วนเติมที่มีอยู่กับเลเอาต์ใหม่อาจเปลี่ยนแปลงได้ ดังนั้นควรตรวจสอบผลลัพธ์เมื่อตัดสลับระหว่างเลเอาต์ที่แตกต่างอย่างมาก

## **เพิ่มสไลด์เลเอาต์**

การเลือกและการสร้างเป็นการกระทำที่แยกจากกัน ตัวอย่างก่อนหน้าเลือกเลเอาต์ที่มีอยู่; ไม่ได้สร้างเลเอาต์ใหม่ เพื่อสร้างเลเอาต์ให้เรียกเมธอด [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/th/java/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) บนคอลเลกชันเลเอาต์ของมาสเตอร์เป้าหมาย

ตัวอย่างต่อไปนี้จะเพิ่มเลเอาต์ **หัวเรื่องและเนื้อหา** ใหม่ชื่อ `Report Title and Content` เสมอ, แล้วเพิ่มสไลด์ปกติตามนั้น ชื่อเลเอาต์ต้องไม่ซ้ำกันภายในคอลเลกชัน  

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

เพิ่มเลเอาต์เฉพาะเมื่อเทมเพลตต้องการโครงสร้างที่ใช้ซ้ำได้จริง หากมีเลเอาต์ที่เหมาะสมอยู่แล้ว ให้เลือกและใช้ซ้ำแทนการสร้างสำเนา

## **เพิ่มส่วนเติมให้กับสไลด์เลเอาต์**

เมธอด [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) ให้บริการ [ILayoutPlaceholderManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilayoutplaceholdermanager/) สำหรับเพิ่มรูปร่างส่วนเติมลงบนเลเอาต์

| PowerPoint Placeholder | `ILayoutPlaceholderManager` เมธอด |
| ---------------------- | ----------------------------------- |
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

ตัวอย่างต่อไปนี้ตรวจสอบว่าเลเอาต์ **เปล่า** มีอยู่, เพิ่มส่วนเติมสี่ส่วนเติมให้กับมัน, แล้วสร้างสไลด์ปกติที่ใช้เลเอาต์ที่ปรับเปลี่ยนแล้ว ลำดับนี้ตั้งใจไว้: ส่วนเติมจะถูกเพิ่มก่อนสร้างสไลด์ปกติ เพื่อให้ Aspose.Slides สามารถสร้างรูปร่างส่วนเติมที่สอดคล้องบนสไลด์นั้นได้  

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

![ส่วนเติมบนสไลด์เลเอาต์](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
การเปลี่ยนแปลงการจัดรูปแบบที่สืบทอดหรือเรขาคณิตของส่วนเติมเลเอาต์ที่มีอยู่สามารถส่งผลต่อสไลด์ที่พึ่งพาได้ ส่วนเติมเลเอาต์ที่เพิ่มใหม่จะไม่ถูกเติมกลับเข้าสู่สไลด์ปกติที่มีอยู่แล้ว ให้ทดสอบการเปลี่ยนแปลงเลเอาต์บนสำเนาของการนำเสนอและตรวจสอบสไลด์ที่พึ่งพาทุกอัน
{{% /alert %}}

## **ลบสไลด์เลเอาต์ที่ไม่ได้ใช้**

ใช้เมธอด [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/th/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) เพื่อลบเลเอาต์ที่ไม่มีสไลด์ปกติอ้างอิง เมธอดจะคงเลเอาต์ที่ยังถูกใช้ไว้  

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

เพื่อเอาเลเอาต์เฉพาะออก, ก่อนอื่นให้ใช้เมธอด [hasDependingSlides](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilayoutslide/#hasDependingSlides--) หรือ [getDependingSlides](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) ของมัน ทำการกำหนดสไลด์ที่พึ่งพาใหม่ก่อนเรียก [ILayoutSlide.remove](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilayoutslide/#remove--). การพยายามลบเลเอาต์ที่กำลังถูกใช้จะทำให้เกิด [PptxEditException](https://reference.aspose.com/slides/th/java/com.aspose.slides/pptxeditexception/)  

## **ควบคุมการมองเห็นส่วนเท้า (Footer) บนสไลด์เลเอาต์**

เลเอาต์มีส่วนเท้า, ตัวเลขสไลด์, และส่วนเติมวันที่/เวลาเป็นของมันเอง ใช้เมธอด [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) เพื่อควบคุมส่วนเติมเหล่านั้นสำหรับเลเอาต์เดียว นี่เป็นประโยชน์เมื่อเช่น เลเอาต์เนื้อหาต้องแสดงส่วนเท้าแต่เลเอาต์หัวเรื่องไม่ต้องการ  

ตัวอย่างต่อไปนี้เลือกเลเอาต์อย่างปลอดภัยและทำให้ส่วนเท้าของมันมองเห็นได้:  

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

## **ควบคุมการมองเห็นส่วนเท้า (Footer) บนมาสเตอร์และเลเอาต์ลูกของมัน**

เพื่อกำหนดค่าเท้าให้สอดคล้องทั่วทั้งลำดับชั้นมาสเตอร์, ใช้เมธอด [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/imasterslide/#getHeaderFooterManager--) วิธีการกระจายของ [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/imasterslideheaderfootermanager/) ทำงานบนมาสเตอร์และสไลด์เลเอาต์และสไลด์ปกติที่พึ่งพา; ไม่ได้มุ่งเป้าแค่สไลด์ปกติเดียว  

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

**ความแตกต่างระหว่างมาสเตอร์สไลด์และสไลด์เลเอาต์คืออะไร?**

มาสเตอร์สไลด์กำหนดธีมและการจัดรูปแบบที่ใช้ร่วมกันของการนำเสนอ สไลด์เลเอาต์เป็นส่วนหนึ่งของมาสเตอร์และกำหนดการจัดเรียงส่วนเติมที่ใช้ซ้ำได้ สไลด์ปกติใช้เลเอาต์เหล่านั้นและเก็บเนื้อหาที่เฉพาะกับสไลด์แต่ละอัน

**ฉันสามารถคัดลอกสไลด์เลเอาต์จากการนำเสนอหนึ่งไปยังอีกการนำเสนอหนึ่งได้หรือไม่?**

ทำได้ เพิ่มสำเนาไปยังคอลเลกชันปลายทางด้วยเมธอด [addClone](https://reference.aspose.com/slides/th/java/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-). เมื่อตัวคัดลอกระหว่างการนำเสนอ ควรตรวจสอบแบบอักษร, ธีม, รูปภาพ, และทรัพยากรอื่น ๆ ที่เลเอาต์ต้นทางใช้

**เกิดอะไรขึ้นเมื่อฉันแก้ไขเลเอาต์ที่กำลังใช้อยู่?**

สไลด์ที่พึ่งพาจะสืบทอดการเปลี่ยนแปลงของเลเอาต์ เว้นแต่จะมีการทับการจัดรูปแบบหรือวัตถุที่ส่งผลโดยเฉพาะในระดับสไลด์ การเปลี่ยนแปลงเรขาคณิตและสไตล์ที่สืบทอดของส่วนเติมอาจทำให้หลายสไลด์เปลี่ยนแปลงพร้อมกัน ใช้เมธอด [getDependingSlides](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) เพื่อระบุสไลด์ที่ได้รับผลกระทบก่อนแก้ไขเลเอาต์

**จะเกิดอะไรขึ้นหากฉันลบเลเอาต์ที่ยังถูกใช้?**

Aspose.Slides จะโยน [PptxEditException](https://reference.aspose.com/slides/th/java/com.aspose.slides/pptxeditexception/). ให้กำหนดสไลด์ที่พึ่งพาใหม่ก่อน, หรือใช้ [removeUnusedLayoutSlides](https://reference.aspose.com/slides/th/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) เพื่อลบเฉพาะเลเอาต์ที่ไม่มีการอ้างอิง.