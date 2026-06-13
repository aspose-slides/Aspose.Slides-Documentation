---
title: ใช้หรือเปลี่ยนรูปแบบสไลด์ใน Java
linktitle: รูปแบบสไลด์
type: docs
weight: 60
url: /th/java/slide-layout/
keywords:
- รูปแบบสไลด์
- รูปแบบเนื้อหา
- ตัวแทน
- การออกแบบพรีเซนเทชัน
- การออกแบบสไลด์
- รูปแบบที่ไม่ได้ใช้
- การมองเห็นส่วนท้าย
- สไลด์หัวเรื่อง
- หัวเรื่องและเนื้อหา
- ส่วนหัวเรื่อง
- สองส่วนเนื้อหา
- การเปรียบเทียบ
- แค่หัวเรื่อง
- รูปแบบเปล่า
- เนื้อหาพร้อมคำอธิบาย
- ภาพพร้อมคำอธิบาย
- หัวเรื่องและข้อความแนวตั้ง
- หัวเรื่องแนวตั้งและข้อความ
- PowerPoint
- OpenDocument
- พรีเซนเทชัน
- Java
- Aspose.Slides
description: "จัดการและปรับแต่งรูปแบบสไลด์ใน Aspose.Slides for Java สำรวจประเภทของรูปแบบ การควบคุมตัวแทน และการมองเห็นส่วนท้ายผ่านตัวอย่างโค้ด Java"
---
## **บทนำ**

รูปแบบสไลด์กำหนดการจัดวางกล่องตัวแทนและการจัดรูปแบบสำหรับเนื้อหาบนสไลด์ โดยควบคุมว่าตัวแทนใดบ้างที่พร้อมใช้งานและปรากฏที่ใด รูปแบบสไลด์ช่วยให้คุณออกแบบการพรีเซนเทชันอย่างรวดเร็วและสอดคล้องกัน—ไม่ว่าจะสร้างสิ่งง่าย ๆ หรือตัวที่ซับซ้อน บางรูปแบบสไลด์ที่พบบ่อยใน PowerPoint มีดังนี้:

**Title Slide layout** – มีตัวแทนข้อความสองกล่อง: หนึ่งสำหรับหัวเรื่องและอีกหนึ่งสำหรับหัวเรื่องย่อย

**Title and Content layout** – มีตัวแทนหัวเรื่องขนาดเล็กด้านบนและตัวแทนเนื้อหาหลักที่ใหญ่กว่าอยู่ด้านล่าง (เช่น ข้อความ, จุดรายการ, แผนภูมิ, รูปภาพ ฯลฯ)

**Blank layout** – ไม่มีตัวแทนใด ๆ ทำให้คุณมีอิสระเต็มที่ในการออกแบบสไลด์ตั้งแต่ต้น

รูปแบบสไลด์เป็นส่วนหนึ่งของหน้าผู้นำสไลด์ (slide master) ซึ่งเป็นสไลด์ระดับบนสุดที่กำหนดสไตล์การจัดวางสำหรับการพรีเซนเทชัน คุณสามารถเข้าถึงและแก้ไขสไลด์รูปแบบผ่านหน้าผู้นำสไลด์—โดยอ้างอิงตามประเภท, ชื่อ หรือ ID ที่ไม่ซ้ำ เรือ, คุณสามารถแก้ไขสไลด์รูปแบบเฉพาะโดยตรงภายในพรีเซนเทชันได้

เพื่อทำงานกับรูปแบบสไลด์ใน Aspose.Slides for Java, คุณสามารถใช้:

- วิธีการเช่น [getLayoutSlides](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getLayoutSlides--) และ [getMasters](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getMasters--) ภายใต้คลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)
- ประเภทเช่น [ILayoutSlide](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilayoutplaceholdermanager/), และ [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
เพื่อเรียนรู้เพิ่มเติมเกี่ยวกับการทำงานกับหน้าผู้นำสไลด์, ดูบทความ [Slide Master](/slides/th/java/slide-master/) ได้เลย
{{% /alert %}}

## **เพิ่มรูปแบบสไลด์ลงในการพรีเซนเทชัน**

หากต้องการปรับแต่งรูปลักษณ์และโครงสร้างของสไลด์, คุณอาจต้องเพิ่มสไลด์รูปแบบใหม่ลงในพรีเซนเทชัน Aspose.Slides for Java จะช่วยให้คุณตรวจสอบว่ารูปแบบที่ต้องการมีอยู่แล้วหรือไม่, เพิ่มใหม่หากจำเป็น, และใช้เพื่อแทรกสไลด์ที่อิงตามรูปแบบนั้น

1. สร้างออบเจ็กต์จากคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)
1. เข้าถึง [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/imasterlayoutslidecollection/)
1. ตรวจสอบว่ารูปแบบสไลด์ที่ต้องการมีอยู่ในคอลเลกชันหรือไม่ ถ้าไม่มีให้เพิ่มรูปแบบสไลด์ที่ต้องการ
1. เพิ่มสไลด์ว่างที่อิงตามรูปแบบสไลด์ใหม่
1. บันทึกพรีเซนเทชัน

โค้ด Java ตัวอย่างต่อไปนี้แสดงวิธีเพิ่มรูปแบบสไลด์ลงในพรีเซนเทชัน PowerPoint:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์ PowerPoint.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // ดำเนินการตรวจสอบประเภทสไลด์เลย์เอาต์เพื่อเลือกสไลด์เลย์เอาต์.
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide layoutSlide = null;
    if (layoutSlides.getByType(SlideLayoutType.TitleAndObject) != null)
        layoutSlide = layoutSlides.getByType(SlideLayoutType.TitleAndObject);
    else
        layoutSlide = layoutSlides.getByType(SlideLayoutType.Title);

    if (layoutSlide == null) {
        // สถานการณ์ที่พรีเซนเทชันไม่ได้มีประเภทเลย์เอาต์ทั้งหมด.
        // ไฟล์พรีเซนเทชันมีเพียงประเภทเลย์เอตต์ Blank และ Custom เท่านั้น.
        // อย่างไรก็ตาม สไลด์เลย์เอาต์ที่มีประเภทแบบกำหนดเองอาจมีชื่อที่จำง่าย,
        // เช่น "Title", "Title and Content", เป็นต้น ซึ่งสามารถใช้ในการเลือกสไลด์เลย์เอาต์ได้.
        // คุณยังสามารถอาศัยชุดของประเภทรูปทรงตัวแทนได้.
        // ตัวอย่างเช่น สไลด์ Title ควรมีเพียงประเภทตัวแทน Title เท่านั้น เป็นต้น.
        for (ILayoutSlide titleAndObjectLayoutSlide : layoutSlides) {
            if (titleAndObjectLayoutSlide.getName().equals("Title and Object")) {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null) {
            for (ILayoutSlide titleLayoutSlide : layoutSlides) {
                if (titleLayoutSlide.getName().equals("Title")) {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null) {
                layoutSlide = layoutSlides.getByType(SlideLayoutType.Blank);
                if (layoutSlide == null) {
                    layoutSlide = layoutSlides.add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // เพิ่มสไลด์เปล่าโดยใช้สไลด์เลย์เอาต์ที่เพิ่มเข้ามา.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // บันทึกพรีเซนเทชันลงดิสก์.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ลบสไลด์เลย์เอาต์ที่ไม่ได้ใช้**

Aspose.Slides มีเมธอด [removeUnusedLayoutSlides](https://reference.aspose.com/slides/th/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) จากคลาส [Compress](https://reference.aspose.com/slides/th/java/com.aspose.slides/compress/) เพื่อให้คุณลบสไลด์เลย์เอาต์ที่ไม่ต้องการและไม่ได้ใช้ได้

โค้ด Java ตัวอย่างต่อไปนี้แสดงวิธีลบสไลด์เลย์เอาต์จากพรีเซนเทชัน PowerPoint:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **เพิ่มตัวแทนลงในรูปแบบสไลด์**

Aspose.Slides มีเมธอด [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) ที่ช่วยให้คุณเพิ่มตัวแทนใหม่ลงในสไลด์รูปแบบ

ผู้จัดการนี้มีเมธอดสำหรับประเภทตัวแทนต่อไปนี้:

| PowerPoint Placeholder | Method |
| ----------------------- | -------------------------------------------- |
| ![Content](content.png) | addContentPlaceholder(float x, float y, float width, float height) |
| ![Content (Vertical)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png) | addTextPlaceholder(float x, float y, float width, float height) |
| ![Text (Vertical)](textV.png) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Picture](picture.png) | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Chart](chart.png) | addChartPlaceholder(float x, float y, float width, float height) |
| ![Table](table.png) | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png) | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Online Image](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

โค้ด Java ตัวอย่างต่อไปนี้แสดงวิธีเพิ่มรูปทรงตัวแทนใหม่ลงในสไลด์รูปแบบ Blank:

```java
Presentation presentation = new Presentation();
try {
    // ดึงสไลด์เลย์เอาต์ Blank.
    ILayoutSlide layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // ดึงตัวจัดการตัวแทนของสไลด์เลย์เอต.
    ILayoutPlaceholderManager placeholderManager = layout.getPlaceholderManager();

    // เพิ่มตัวแทนหลายประเภทลงในสไลด์เลย์เอาต์ Blank.
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // เพิ่มสไลด์ใหม่ด้วยเลย์เอาต์ Blank.
    ISlide newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![The placeholders on the layout slide](add_placeholders.png)

## **ตั้งค่าการมองเห็นส่วนท้ายสำหรับสไลด์เลย์เอาต์**

ในพรีเซนเทชัน PowerPoint, ส่วนท้ายเช่น วันที่, หมายเลขสไลด์, และข้อความกำหนดเองสามารถแสดงหรือซ่อนได้ตามรูปแบบสไลด์ Aspose.Slides for Java ให้คุณควบคุมการมองเห็นของตัวแทนส่วนท้ายเหล่านี้ ซึ่งมีประโยชน์เมื่อคุณต้องการให้บางรูปแบบแสดงข้อมูลส่วนท้ายขณะที่รูปแบบอื่นคงความเรียบง่าย

1. สร้างออบเจ็กต์จากคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)
1. ดึงอ้างอิงสไลด์รูปแบบด้วยดัชนีของมัน
1. ตั้งค่าตัวแทนส่วนท้ายของสไลด์ให้เป็นแบบมองเห็น
1. ตั้งค่าตัวแทนหมายเลขสไลด์ให้เป็นแบบมองเห็น
1. ตั้งค่าตัวแทนวัน‑เวลาให้เป็นแบบมองเห็น
1. บันทึกพรีเซนเทชัน

โค้ด Java ตัวอย่างต่อไปนี้แสดงวิธีตั้งค่าการมองเห็นของส่วนท้ายสไลด์และทำงานที่เกี่ยวข้อง:

```java
Presentation presentation = new Presentation("Presentation.ppt");
try {
    ILayoutSlideHeaderFooterManager headerFooterManager = presentation.getLayoutSlides().get_Item(0).getHeaderFooterManager();

    if (!headerFooterManager.isFooterVisible()) {
        headerFooterManager.setFooterVisibility(true);
    }

    if (!headerFooterManager.isSlideNumberVisible()) {
        headerFooterManager.setSlideNumberVisibility(true);
    }

    if (!headerFooterManager.isDateTimeVisible()) {
        headerFooterManager.setDateTimeVisibility(true);
    }

    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("Presentation.ppt", SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าการมองเห็นส่วนท้ายของสไลด์ลูก**

ในพรีเซนเทชัน PowerPoint, ส่วนท้ายเช่น วันที่, หมายเลขสไลด์, และข้อความกำหนดเองสามารถควบคุมได้ระดับหน้าผู้นำสไลด์เพื่อให้สอดคล้องทั่วทั้งสไลด์รูปแบบ Aspose.Slides for Java ช่วยให้คุณตั้งค่าการมองเห็นและเนื้อหาของตัวแทนส่วนท้ายเหล่านี้บนหน้าผู้นำสไลด์และกระจายการตั้งค่าเหล่านั้นไปยังสไลด์รูปแบบลูกทั้งหมด วิธีนี้ทำให้ข้อมูลส่วนท้ายเหมือนกันทั่วพรีเซนเทชันของคุณ

1. สร้างออบเจ็กต์จากคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)
1. ดึงอ้างอิงหน้าผู้นำสไลด์ด้วยดัชนีของมัน
1. ตั้งค่าตัวแทนส่วนท้ายของหน้าผู้นำและสไลด์ลูกทั้งหมดให้เป็นแบบมองเห็น
1. ตั้งค่าตัวแทนหมายเลขสไลด์ของหน้าผู้นำและสไลด์ลูกทั้งหมดให้เป็นแบบมองเห็น
1. ตั้งค่าตัวแทนวัน‑เวลาของหน้าผู้นำและสไลด์ลูกทั้งหมดให้เป็นแบบมองเห็น
1. บันทึกพรีเซนเทชัน

โค้ด Java ตัวอย่างต่อไปนี้แสดงการดำเนินการนี้:

```java
Presentation presentation = new Presentation("Presentation.ppt");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();

    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่างหน้าผู้นำสไลด์และสไลด์เลย์เอาต์คืออะไร?**

หน้าผู้นำสไลด์กำหนดธีมโดยรวมและการจัดรูปแบบเริ่มต้น, ส่วนสไลด์เลย์เอาต์กำหนดการจัดวางตัวแทนเฉพาะสำหรับประเภทเนื้อหาต่าง ๆ

**ฉันสามารถคัดลอกสไลด์เลย์เอาต์จากพรีเซนเทชันหนึ่งไปยังอีกพรีเซนเทชันได้หรือไม่?**

ได้, คุณสามารถโคลนสไลด์เลย์เอาต์จากคอลเลกชันสไลด์เลย์เออตของพรีเซนเทชันหนึ่ง (เข้าถึงได้ผ่านเมธอด [getLayoutSlides](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getLayoutSlides--)) แล้วแทรกลงในพรีเซนเทชันอื่นโดยใช้เมธอด `addClone`

**เกิดอะไรขึ้นหากฉันลบสไลด์เลย์เอาต์ที่ยังถูกสไลด์อื่นใช้อยู่?**

หากคุณพยายามลบสไลด์เลย์เอาต์ที่ยังมีสไลด์อย่างน้อยหนึ่งสไลด์อ้างอิงถึง, Aspose.Slides จะโยนข้อยกเว้น [PptxEditException](https://reference.aspose.com/slides/th/java/com.aspose.slides/pptxeditexception/). เพื่อหลีกเลี่ยงสถานการณ์นี้, ใช้เมธอด [removeUnusedLayoutSlides](https://reference.aspose.com/slides/th/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) ซึ่งจะลบสไลด์เลย์เอาต์ที่ไม่ได้ใช้อย่างปลอดภัย