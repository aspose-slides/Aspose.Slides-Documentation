---
title: ใช้หรือเปลี่ยนเค้าโครงสไลด์บน Android
linktitle: เค้าโครงสไลด์
type: docs
weight: 60
url: /th/androidjava/slide-layout/
keywords:
- เค้าโครงสไลด์
- เค้าโครงเนื้อหา
- ตัวแสดงตำแหน่ง
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
- Android
- Java
- Aspose.Slides
description: "ใช้, สร้างและแก้ไขเค้าโครงสไลด์ใน Aspose.Slides สำหรับ Android ผ่าน Java, เพิ่มตัวแสดงตำแหน่ง, ลบเค้าโครงที่ไม่ได้ใช้, และควบคุมการมองเห็นส่วนท้าย."
---
## **ภาพรวม**

เค้าโครงสไลด์กำหนดตำแหน่งและรูปแบบของตัวแสดงตำแหน่ง (placeholder) เช่น ชื่อเรื่อง, ข้อความ, รูปภาพ, แผนภูมิ, และตาราง การใช้เค้าโครงทำให้สไลด์มีโครงสร้างสอดคล้องกันในขณะที่แต่ละสไลด์สามารถมีเนื้อหาของตนเองได้.

เค้าโครงที่พบบ่อยที่สุดได้แก่:

- **สไลด์หัวข้อ**: มีตัวแสดงตำแหน่งชื่อเรื่องและคำบรรยาย.
- **หัวข้อและเนื้อหา**: มีตัวแสดงตำแหน่งชื่อเรื่องและตัวแสดงตำแหน่งเนื้อหาทั่วไป.
- **เปล่า**: ไม่มีตัวแสดงตำแหน่งเนื้อหาและมีประโยชน์เมื่อรูปแบบทุกอย่างจะถูกจัดตำแหน่งด้วยตนเอง.

## **ทำความเข้าใจการสืบทอดเค้าโครง**

งานนำเสนอมีระดับที่เกี่ยวข้องกันสามระดับ:

1. A [master slide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasterslide/) กำหนดธีม, การจัดรูปแบบที่ใช้ร่วมกัน, พื้นหลัง, และวัตถุทั่วไป.
1. A [layout slide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilayoutslide/) เป็นของสไลด์แม่และกำหนดการจัดเรียงตัวแสดงตำแหน่งเฉพาะ.
1. A [normal slide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islide/) ใช้เค้าโครงหนึ่งอันและเก็บเนื้อหาที่ป้อนสำหรับสไลด์นั้น.

สไลด์ปกติสืบทอดธีมและการจัดรูปแบบจากเค้าโครงของมัน, และเค้าโครงสืบทอดจากสไลด์แม่. ค่าที่ตั้งโดยตรงบนสไลด์ปกติจะทับค่าที่สืบทอดมาที่ระดับนั้น. เมื่อสไลด์ปกติถูกสร้าง, รูปร่างของตัวแสดงตำแหน่งจะถูกสร้างจากเค้าโครงที่เลือก, ขณะที่เนื้อหาที่ป้อนลงในตัวแสดงตำแหน่งนั้นเป็นของสไลด์ปกติ.

เพิ่มตัวแสดงตำแหน่งที่จำเป็นลงในเค้าโครงก่อนสร้างสไลด์จากมัน. การเพิ่มตัวแสดงตำแหน่งใหม่ในเค้าโครงภายหลังจะไม่ทำให้รูปร่างตัวแสดงตำแหน่งที่สอดคล้องกันถูกเพิ่มโดยอัตโนมัติในสไลด์ปกติที่มีอยู่แล้ว.

ความสัมพันธ์นี้มีผลสำคัญสองประการ:

- การเปลี่ยนการจัดรูปแบบที่สืบทอดหรือรูปทรงของตัวแสดงตำแหน่งที่มีอยู่บนเค้าโครงสามารถอัปเดตทุกสไลด์ที่พึ่งพาเค้าโครงนั้นได้. ก่อนแก้ไขเค้าโครงที่กำลังใช้งานอยู่, ให้ตรวจสอบสไลด์ที่พึ่งพาและทบทวนงานนำเสนอที่ได้.
- เค้าโครงที่ยังคงถูกสไลด์ใช้งานอยู่ไม่สามารถลบได้. ให้เปลี่ยนสไลด์ที่พึ่งพาไปใช้เค้าโครงอื่นก่อน, หรือให้ลบเฉพาะเค้าโครงที่ไม่มีการใช้งาน.

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับระดับบนสุดของโครงสร้างนี้ โปรดดู [สไลด์แม่](/slides/th/androidjava/slide-master/).

## **เลือกและใช้เค้าโครงสไลด์**

ใช้ประเภทเค้าโครงเมื่อการนำเสนอปฏิบัติตามคำนิยามเค้าโครง PowerPoint มาตรฐาน. ชื่อเค้าโครงสามารถแก้ไขได้โดยผู้ใช้และอาจแปลเป็นภาษาต่าง ๆ, ดังนั้นการเลือกตามชื่อจะน่าเชื่อถือน้อยลงเว้นแต่คุณจะควบคุมเทมเพลตต้นฉบับ.

ตัวอย่างต่อไปนี้ค้นหา **หัวข้อและเนื้อหา** บนสไลด์แม่คนแรก. หากไม่มีเค้าโครงนั้น, จะทำการย้อนกลับไปยัง **เปล่า** อย่างตั้งใจ. การตรวจสอบ null ครั้งที่สองเป็นสิ่งจำเป็นเนื่องจากการนำเสนออาจมีเพียงเค้าโครงที่กำหนดเอง. จากนั้นเค้าโครงที่เลือกจะถูกนำไปใช้กับสไลด์ปกติคนแรกผ่านวิธี [ISlide.setLayoutSlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-) .

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

การเปลี่ยนเค้าโครงของสไลด์จะไม่ลบรูปร่างปกติที่เพิ่มโดยตรงลงบนสไลด์. อย่างไรก็ตาม, ตำแหน่งของตัวแสดงตำแหน่ง, การจัดรูปแบบที่สืบทอด, และความสัมพันธ์ระหว่างตัวแสดงตำแหน่งที่มีอยู่กับเค้าโครงใหม่อาจเปลี่ยนแปลง, จึงควรตรวจสอบผลลัพธ์เมื่อสลับระหว่างเค้าโครงที่แตกต่างกันอย่างมาก.

## **เพิ่มสไลด์เค้าโครง**

การเลือกและการสร้างเป็นการดำเนินการแยกจากกัน. ตัวอย่างก่อนหน้านี้เลือกเค้าโครงที่มีอยู่; มันไม่ได้สร้างเค้าโครงใหม่. เพื่อสร้างเค้าโครง, เรียกวิธี [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) บนคอลเลกชันเค้าโครงของสไลด์แม่เป้าหมาย.

ตัวอย่างต่อไปนี้จะเพิ่มเค้าโครง **หัวข้อและเนื้อหา** ใหม่ชื่อ `Report Title and Content` เสมอ, แล้วเพิ่มสไลด์ปกติที่อิงตามมัน. ชื่อเค้าโครงต้องเป็นเอกลักษณ์ภายในคอลเลกชัน.

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

เพิ่มเค้าโครงเฉพาะเมื่อเทมเพลตต้องการโครงสร้างที่ใช้ซ้ำได้จริง. หากมีเค้าโครงที่เหมาะสมอยู่แล้ว, ให้เลือกและใช้ซ้ำแทนการสร้างซ้ำ.

## **เพิ่มตัวแสดงตำแหน่งลงในสไลด์เค้าโครง**

วิธี [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) ให้บริการ [ILayoutPlaceholderManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) สำหรับการเพิ่มรูปร่างตัวแสดงตำแหน่งลงในเค้าโครง.

| ตัวแสดงตำแหน่ง PowerPoint | `ILayoutPlaceholderManager` เมธอด |
| --------------------------- | ----------------------------------- |
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

ตัวอย่างต่อไปนี้ตรวจสอบว่ามีเค้าโครง **เปล่า** อยู่, เพิ่มตัวแสดงตำแหน่งสี่ตัวลงในมัน, แล้วสร้างสไลด์ปกติที่ใช้เค้าโครงที่แก้ไขแล้ว. การจัดลำดับเป็นเจตนา: ตัวแสดงตำแหน่งถูกเพิ่มก่อนสร้างสไลด์ปกติ, เพื่อที่ Aspose.Slides จะสร้างรูปร่างตัวแสดงตำแหน่งที่สอดคล้องบนสไลด์นั้น.

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

![ตัวแสดงตำแหน่งบนสไลด์เค้าโครง](add_placeholders.png)

{{% alert color="warning" title="คำเตือน" %}}
การเปลี่ยนการจัดรูปแบบที่สืบทอดหรือรูปทรงของตัวแสดงตำแหน่งเค้าโครงที่มีอยู่สามารถส่งผลต่อสไลด์ที่พึ่งพาได้. ตัวแสดงตำแหน่งที่เพิ่มใหม่จะไม่ถูกเติมกลับไปยังสไลด์ปกติที่มีอยู่แล้ว. ให้ทดสอบการเปลี่ยนแปลงเค้าโครงบนสำเนาของงานนำเสนอและตรวจสอบทุกสไลด์ที่พึ่งพา.
{{% /alert %}}

## **ลบสไลด์เค้าโครงที่ไม่ได้ใช้**

ใช้วิธี [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) เพื่อลบเค้าโครงที่ไม่มีสไลด์ปกติอ้างอิง. วิธีนี้จะคงเค้าโครงที่ยังคงใช้งานอยู่ไว้.

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

เพื่อจะลบเค้าโครงเฉพาะหนึ่งอัน, ให้ใช้วิธี [hasDependingSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilayoutslide/#hasDependingSlides--) หรือ [getDependingSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) ของมันก่อน. ย้ายสไลด์ที่พึ่งพาไปยังเค้าโครงอื่นก่อนเรียก [ILayoutSlide.remove](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilayoutslide/#remove--). หากพยายามลบเค้าโครงที่กำลังใช้งานอยู่จะเกิดข้อยกเว้น [PptxEditException](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pptxeditexception/).

## **ควบคุมการมองเห็นส่วนท้ายบนสไลด์เค้าโครง**

เค้าโครงมีส่วนท้าย, หมายเลขสไลด์, และตัวแสดงตำแหน่งวันที่/เวลาเป็นของตนเอง. ใช้วิธี [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) เพื่อควบคุมตัวแสดงตำแหน่งเหล่านี้สำหรับเค้าโครงหนึ่งอัน. สิ่งนี้มีประโยชน์เมื่อเช่น เค้าโครงเนื้อหาควรแสดงส่วนท้ายแต่เค้าโครงหัวข้อไม่ควรแสดง.

ตัวอย่างต่อไปนี้เลือกเค้าโครงอย่างปลอดภัยและทำให้ส่วนท้ายของมันแสดงผล:

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

## **ควบคุมการมองเห็นส่วนท้ายบนสไลด์แม่และเค้าโครงลูกของมัน**

เพื่อกำหนดการตั้งค่าส่วนท้ายให้สอดคล้องทั่วทั้งลำดับชั้นของสไลด์แม่, ใช้วิธี [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasterslide/#getHeaderFooterManager--) . วิธีการกระจายของ [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasterslideheaderfootermanager/) ทำงานบนสไลด์แม่และสไลด์เค้าโครงและสไลด์ปกติที่พึ่งพา; ไม่ได้มุ่งเป้าเฉพาะสไลด์ปกติเดียว.

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

**ความแตกต่างระหว่างสไลด์แม่และสไลด์เค้าโครงคืออะไร?**

สไลด์แม่กำหนดธีมและการจัดรูปแบบที่ใช้ร่วมกันของงานนำเสนอ. สไลด์เค้าโครงเป็นของสไลด์แม่และกำหนดการจัดเรียงตัวแสดงตำแหน่งที่สามารถใช้ซ้ำได้หนึ่งแบบ. สไลด์ปกติใช้เค้าโครงเหล่านั้นและเก็บเนื้อหาเฉพาะสไลด์.

**ฉันสามารถคัดลอกสไลด์เค้าโครงจากงานนำเสนอหนึ่งไปยังอีกงานนำเสนอได้หรือไม่?**

ทำได้. ให้เพิ่มสำเนาไปยังคอลเลกชันปลายทางด้วยวิธี [addClone](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-). เมื่อคัดลอกระหว่างงานนำเสนอ, ควรตรวจสอบฟอนต์, ธีม, รูปภาพ, และทรัพยากรอื่น ๆ ที่ใช้โดยเค้าโครงต้นทาง.

**จะเกิดอะไรขึ้นเมื่อฉันแก้ไขเค้าโครงที่กำลังใช้งานอยู่?**

สไลด์ที่พึ่งพาจะสืบทอดการเปลี่ยนแปลงของเค้าโครง เว้นแต่พวกมันจะทับการจัดรูปแบบหรือวัตถุที่เกี่ยวข้องในระดับท้องถิ่น. รูปทรงของตัวแสดงตำแหน่งและสไตล์ที่สืบทอดจึงอาจเปลี่ยนแปลงในสไลด์หลาย ๆ สไลด์พร้อมกัน. ใช้ [getDependingSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) เพื่อระบุสไลด์ที่ได้รับผลกระทบก่อนแก้ไขเค้าโครง.

**จะเกิดอะไรขึ้นหากฉันลบเค้าโครงที่ยังคงใช้งานอยู่?**

Aspose.Slides จะโยงข้อยกเว้น [PptxEditException](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pptxeditexception/). ให้เปลี่ยนสไลด์ที่พึ่งพาไปยังเค้าโครงอื่นก่อน, หรือใช้ [removeUnusedLayoutSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) เพื่อลบเฉพาะเค้าโครงที่ไม่ได้อ้างอิง.