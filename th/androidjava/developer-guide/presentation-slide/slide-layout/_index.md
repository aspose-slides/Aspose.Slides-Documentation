---
title: นำไปใช้หรือเปลี่ยนแปลงเค้าโครงสไลด์บน Android
linktitle: เค้าโครงสไลด์
type: docs
weight: 60
url: /th/androidjava/slide-layout/
keywords:
- เค้าโครงสไลด์
- เค้าโครงเนื้อหา
- ตัวแทนตำแหน่ง
- การออกแบบการนำเสนอ
- การออกแบบสไลด์
- เค้าโครงที่ไม่ได้ใช้
- การมองเห็นส่วนท้าย
- สไลด์หัวเรื่อง
- หัวเรื่องและเนื้อหา
- หัวข้อส่วน
- สองเนื้อหา
- การเปรียบเทียบ
- หัวเรื่องเท่านั้น
- เค้าโครงว่าง
- เนื้อหาพร้อมคำบรรยาย
- รูปภาพพร้อมคำบรรยาย
- หัวเรื่องและข้อความแนวตั้ง
- หัวเรื่องแนวตั้งและข้อความ
- PowerPoint
- OpenDocument
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "นำไปใช้, สร้างและแก้ไขเค้าโครงสไลด์ใน Aspose.Slides สำหรับ Android ผ่าน Java, เพิ่มตัวแทนตำแหน่ง, ลบเค้าโครงที่ไม่ได้ใช้, และควบคุมการมองเห็นส่วนท้าย."
---
## **ภาพรวม**

เค้าโครงสไลด์กำหนดตำแหน่งและรูปแบบของตัวแทนตำแหน่งต่าง ๆ เช่น ชื่อเรื่อง, ข้อความ, รูปภาพ, แผนภูมิ, และตาราง การใช้เค้าโครงทำให้สไลด์มีโครงสร้างที่สอดคล้องกันพร้อมกับให้แต่ละสไลด์สามารถมีเนื้อหาของตนเองได้

เค้าโครงที่พบบ่อยที่สุดได้แก่:

- **สไลด์หัวเรื่อง**: มีตัวแทนตำแหน่งชื่อเรื่องและชื่อเรื่องย่อย
- **หัวเรื่องและเนื้อหา**: มีตัวแทนตำแหน่งชื่อเรื่องและตัวแทนตำแหน่งเนื้อหาทั่วไป
- **ว่าง**: ไม่มีตัวแทนตำแหน่งเนื้อหาและมีประโยชน์เมื่อทุกรูปทรงต้องกำหนดตำแหน่งด้วยตนเอง

## **ทำความเข้าใจการสืบทอดเค้าโครง**

การนำเสนอมีระดับที่เกี่ยวข้องสามระดับ:

1. [มาสเตอร์สไลด์](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasterslide/) กำหนดธีม การจัดรูปแบบที่ใช้ร่วมกัน พื้นหลัง และวัตถุทั่วไป
1. [เลย์เอาต์สไลด์](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilayoutslide/) เป็นส่วนหนึ่งของมาสเตอร์และกำหนดการจัดเรียงตัวแทนตำแหน่งเฉพาะ
1. [สไลด์ปกติ](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islide/) ใช้เลย์เอาต์หนึ่งและเก็บเนื้อหาที่ป้อนสำหรับสไลด์นั้น

สไลด์ปกติสืบทอดธีมและการจัดรูปแบบจากเลย์เอาต์ของมัน และเลย์เอาต์สืบทอดจากมาสเตอร์ ค่าที่กำหนดโดยตรงบนสไลด์ปกติจะทับค่าที่สืบทอดไว้ในระดับนั้น เมื่อสร้างสไลด์ปกติ ตัวรูปทรงตัวแทนตำแหน่งจะถูกสร้างจากเลย์เอาต์ที่เลือกไว้ ในขณะที่เนื้อหาที่ป้อนลงในตัวแทนตำแหน่งเหล่านั้นเป็นของสไลด์ปกติ

เพิ่มตัวแทนตำแหน่งที่จำเป็นลงในเลย์เอาต์ก่อนสร้างสไลด์จากมัน การเพิ่มตัวแทนตำแหน่งใหม่ในเลย์เอาต์ภายหลังจะไม่ทำให้สไลด์ปกติที่มีอยู่แล้วเพิ่มรูปทรงตัวแทนตำแหน่งโดยอัตโนมัติ

ความสัมพันธ์นี้มีผลสำคัญสองประการ:

- การเปลี่ยนการจัดรูปแบบที่สืบทอดหรือรูปทรงของตัวแทนตำแหน่งที่มีอยู่บนเลย์เอาต์อาจอัปเดตสไลด์ทั้งหมดที่พึ่งพาเลย์เอาต์นั้น ก่อนแก้ไขเลย์เอาต์ที่กำลังใช้งานอยู่ให้ตรวจสอบสไลด์ที่พึ่งพาและตรวจทานผลลัพธ์ของการนำเสนอ
- เลย์เอาต์ที่ยังถูกสไลด์ใช้งานอยู่ไม่สามารถลบได้ ต้องมอบหมายสไลด์ที่พึ่งพาให้กับเลย์เอาต์อื่นก่อน หรือทำการลบเฉพาะเลย์เอาต์ที่ไม่ได้ใช้

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับระดับบนสุดของโครงสร้างนี้ ดูที่ [มาสเตอร์สไลด์](/slides/th/androidjava/slide-master/)

เพื่อซ่อนโลโก้หรือรูปแบบมาสเตอร์ที่สืบทอดบนสไลด์เดียวหรือผ่านเลย์เอาต์ที่ใช้ร่วมกัน ดูที่ [ควบคุมการมองเห็นกราฟิกมาสเตอร์](/slides/th/androidjava/slide-master/) ตัวอย่างเปรียบเทียบสองสไลด์ที่ใช้มาสเตอร์เดียวกัน

## **เลือกและใช้เค้าโครงสไลด์**

ใช้ประเภทเค้าโครงเมื่อการนำเสนอปฏิบัติตามคำนิยามเค้าโครง PowerPoint มาตรฐาน ชื่อเค้าโครงสามารถแก้ไขได้โดยผู้ใช้และสามารถแปลเป็นภาษาต่าง ๆ ได้ ดังนั้นการเลือกโดยอ้างอิงชื่ออาจไม่เชื่อถือได้หากคุณไม่ได้ควบคุมแม่แบบต้นฉบับ

ตัวอย่างต่อไปมองหา **หัวเรื่องและเนื้อหา** บนมาสเตอร์แรก หากเค้าโครงนั้นไม่มีอยู่จะย้อนกลับไปใช้ **ว่าง** โดยเจตนา การตรวจสอบค่า null ครั้งที่สองจำเป็นเพราะการนำเสนออาจมีเฉพาะเค้าโครงที่กำหนดเองเท่านั้น เค้าโครงที่เลือกแล้วจะถูกนำไปใช้กับสไลด์ปกติแรกผ่านเมธอด [ISlide.setLayoutSlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-)  

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

การเปลี่ยนเค้าโครงของสไลด์จะไม่ลบรูปทรงปกติที่เพิ่มโดยตรงลงในสไลด์ อย่างไรก็ตาม ตำแหน่งของตัวแทนตำแหน่ง การจัดรูปแบบที่สืบทอด และความสัมพันธ์ระหว่างตัวแทนตำแหน่งที่มีอยู่กับเค้าโครงใหม่อาจเปลี่ยนแปลงได้ ดังนั้นให้ตรวจสอบผลลัพธ์เมื่อสลับระหว่างเค้าโครงที่แตกต่างกันอย่างมาก

## **เพิ่มเค้าโครงสไลด์**

การเลือกและการสร้างเป็นการทำงานที่แยกจากกัน ตัวอย่างก่อนหน้าเลือกเค้าโครงที่มีอยู่แล้ว; ไม่ได้สร้างเค้าโครงใหม่ เพื่อสร้างเค้าโครง ให้เรียกเมธอด [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) บนคอลเลกชันเลย์เอาต์ของมาสเตอร์เป้าหมาย

ตัวอย่างต่อไปจะเพิ่มเค้าโครง **หัวเรื่องและเนื้อหา** ใหม่ที่ชื่อ `Report Title and Content` เสมอ แล้วจึงเพิ่มสไลด์ปกติที่อิงจากเค้าโครงนั้น ชื่อเค้าโครงต้องไม่ซ้ำกันภายในคอลเลกชัน  

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

เพิ่มเค้าโครงเฉพาะเมื่อแม่แบบต้องการโครงสร้างที่ใช้งานซ้ำได้จริง หากเค้าโครงที่เหมาะสมมีอยู่แล้ว ให้เลือกและใช้ซ้ำแทนการสร้างสำเนาใหม่

## **เพิ่มตัวแทนตำแหน่งในเค้าโครงสไลด์**

เมธอด [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) ให้บริการ [ILayoutPlaceholderManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) สำหรับการเพิ่มรูปทรงตัวแทนตำแหน่งลงในเค้าโครง

| ตัวแทน PowerPoint | เมธอด `ILayoutPlaceholderManager` |
| ------------------- | --------------------------------- |
| ![เนื้อหา](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![เนื้อหา (แนวตั้ง)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![ข้อความ](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![ข้อความ (แนวตั้ง)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![รูปภาพ](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![แผนภูมิ](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![ตาราง](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![สื่อ](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![รูปภาพออนไลน์](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

ตัวอย่างต่อไปตรวจสอบว่าเค้าโครง **ว่าง** มีอยู่แล้ว เพิ่มตัวแทนตำแหน่งสี่ตำแหน่งลงในมัน แล้วจึงสร้างสไลด์ปกติที่ใช้เค้าโครงที่แก้ไขแล้ว การจัดลำดับนี้ตั้งใจไว้: ตัวแทนตำแหน่งถูกเพิ่มก่อนสร้างสไลด์ปกติเพื่อให้ Aspose.Slides สามารถสร้างรูปทรงตัวแทนตำแหน่งที่สอดคล้องบนสไลด์นั้น  

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

![ตัวแทนตำแหน่งบนเค้าโครงสไลด์](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
การเปลี่ยนการจัดรูปแบบที่สืบทอดหรือรูปทรงของตัวแทนตำแหน่งเค้าโครงที่มีอยู่สามารถส่งผลต่อสไลด์ที่พึ่งพาได้ ตัวแทนตำแหน่งที่เพิ่มใหม่จะไม่ถูกเติมกลับเข้าไปในสไลด์ปกติที่มีอยู่แล้ว ให้ทดสอบการเปลี่ยนแปลงเค้าโครงบนสำเนาของการนำเสนอและตรวจสอบสไลด์ที่พึ่งพาทุกสไลด์
{{% /alert %}}

## **ลบเค้าโครงสไลด์ที่ไม่ได้ใช้**

ใช้เมธอด [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) เพื่อลบเค้าโครงที่ไม่มีสไลด์ปกติอ้างอิง เมธอดจะปล่อยเค้าโครงที่ยังคงใช้งานอยู่ไว้ไม่เปลี่ยน  

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

เพื่อทำการลบเค้าโครงเฉพาะหนึ่งรายการ ให้ใช้เมธอด [hasDependingSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilayoutslide/#hasDependingSlides--) หรือ [getDependingSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) ของเค้าโครงนั้นก่อนลบ ย้ายสไลด์ที่พึ่งพาไปยังเค้าโครงอื่นก่อนเรียก [ILayoutSlide.remove](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilayoutslide/#remove--) การพยายามลบเค้าโครงที่กำลังใช้งานจะทำให้เกิดข้อผิดพลาด [PptxEditException](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pptxeditexception/)

## **ควบคุมการมองเห็นส่วนท้ายบนเค้าโครงสไลด์**

เค้าโครงมีตัวแทนตำแหน่งส่วนท้าย, ตัวเลขสไลด์, และวัน‑เวลาของตนเอง ใช้เมธอด [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) เพื่อควบคุมตัวแทนตำแหน่งเหล่านี้สำหรับเค้าโครงหนึ่ง ตัวอย่างเช่น เนื้อหาเค้าโครงอาจต้องแสดงส่วนท้าย แต่เค้าโครงหัวเรื่องไม่ต้องการ  

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

## **ควบคุมการมองเห็นส่วนท้ายบนมาสเตอร์และเค้าโครงลูกของมัน**

เพื่อกำหนดการตั้งค่าส่วนท้ายอย่างสม่ำเสมอในระดับมาสเตอร์ ให้ใช้เมธอด [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasterslide/#getHeaderFooterManager--) วิธีการกระจายของ [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasterslideheaderfootermanager/) จะทำงานบนมาสเตอร์และเค้าโครงสไลด์และสไลด์ปกติที่พึ่งพา; ไม่ได้มุ่งหมายเฉพาะสไลด์ปกติหนึ่งรายการ  

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

**ความแตกต่างระหว่างมาสเตอร์สไลด์และเลย์เอาต์สไลด์คืออะไร?**

มาสเตอร์สไลด์กำหนดธีมและการจัดรูปแบบที่ใช้ร่วมกันของการนำเสนอ เลย์เอาต์สไลด์เป็นส่วนหนึ่งของมาสเตอร์และกำหนดการจัดเรียงตัวแทนตำแหน่งที่สามารถนำไปใช้ซ้ำได้ สไลด์ปกติใช้เลย์เอาต์เหล่านั้นและเก็บเนื้อหาเฉพาะสไลด์ของตนเอง

**ฉันสามารถคัดลอกเลย์เอาต์สไลด์จากการนำเสนอหนึ่งไปยังอีกการนำเสนอหนึ่งได้หรือไม่?**

ทำได้ สามารถเพิ่มสำเนาไปยังคอลเลกชันปลายทางด้วยเมธอด [addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) เมื่อคัดลอกระหว่างการนำเสนอ ควรตรวจสอบแบบอักษร, ธีม, รูปภาพและทรัพยากรอื่น ๆ ที่เลย์เอาต์ต้นฉบับใช้

**จะเกิดอะไรขึ้นเมื่อแก้ไขเลย์เอาต์ที่กำลังใช้งานอยู่?**

สไลด์ที่พึ่งพาจะสืบทอดการเปลี่ยนแปลงของเลย์เออตจนกว่าจะมีการทับค่าการจัดรูปแบบหรือวัตถุในระดับท้องถิ่น รูปร่างของตัวแทนตำแหน่งและสไตล์ที่สืบทอดอาจเปลี่ยนแปลงบนหลายสไลด์พร้อมกัน ใช้เมธอด [getDependingSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) เพื่อระบุสไลด์ที่ได้รับผลกระทบก่อนแก้ไขเลย์เออต

**จะเกิดอะไรขึ้นหากลบเลย์เอาต์ที่ยังคงถูกใช้งาน?**

Aspose.Slides จะโยนข้อผิดพลาด [PptxEditException](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pptxeditexception/) ให้มอบหมายสไลด์ที่พึ่งพาไปยังเลย์เอาต์อื่นก่อน หรือใช้เมธอด [removeUnusedLayoutSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) เพื่อลบเฉพาะเลย์เอาต์ที่ไม่มีการอ้างอิง