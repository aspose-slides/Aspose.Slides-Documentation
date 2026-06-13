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
- ส่วนหัวของหัวข้อ
- สองส่วนของเนื้อหา
- การเปรียบเทียบ
- หัวเรื่องเท่านั้น
- เค้าโครงเปล่า
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
description: "จัดการและปรับแต่งเค้าโครงสไลด์ใน Aspose.Slides สำหรับ Android สำรวจประเภทเค้าโครง การควบคุมตัวแสดงตำแหน่ง และการมองเห็นส่วนท้ายผ่านตัวอย่างโค้ด Java"
---
## **บทนำ**

เค้าโครงสไลด์กำหนดการจัดเรียงของกล่องตัวแสดงตำแหน่งและการจัดรูปแบบของเนื้อหาบนสไลด์ มันควบคุมว่าตัวแสดงตำแหน่งใดบ้างที่พร้อมใช้งานและปรากฏที่ไหน เค้าโครงสไลด์ช่วยให้คุณออกแบบงานนำเสนอได้อย่างรวดเร็วและสม่ำเสมอ—ไม่ว่าคุณจะสร้างสิ่งที่เรียบง่ายหรือซับซ้อนกว่า ตัวอย่างของเค้าโครงสไลด์ที่พบบ่อยที่สุดใน PowerPoint ได้แก่:

**เค้าโครงสไลด์หัวเรื่อง** – มีตัวแสดงตำแหน่งข้อความสองช่อง: หนึ่งสำหรับหัวเรื่องและอีกหนึ่งสำหรับหัวข้อย่อย.  

**เค้าโครงหัวเรื่องและเนื้อหา** – มีตัวแสดงตำแหน่งหัวเรื่องขนาดเล็กที่ด้านบนและตัวแสดงตำแหน่งขนาดใหญ่ด้านล่างสำหรับเนื้อหาหลัก (เช่น ข้อความ, จุดสัญลักษณ์, แผนภูมิ, รูปภาพ, และอื่น ๆ).  

**เค้าโครงเปล่า** – ไม่มีตัวแสดงตำแหน่งใด ๆ ให้คุณควบคุมเต็มที่ในการออกแบบสไลด์ตั้งแต่ต้น.  

เค้าโครงสไลด์เป็นส่วนหนึ่งของมาสเตอร์สไลด์ ซึ่งเป็นสไลด์ระดับบนสุดที่กำหนดสไตล์เค้าโครงสำหรับการนำเสนอ คุณสามารถเข้าถึงและแก้ไขเค้าโครงสไลด์ผ่านมาสเตอร์สไลด์—โดยอิงจากประเภท, ชื่อ หรือ ID ที่ไม่ซ้ำกัน หรือคุณสามารถแก้ไขเค้าโครงสไลด์เฉพาะโดยตรงภายในงานนำเสนอ  

เพื่อทำงานกับเค้าโครงสไลด์ใน Aspose.Slides for Android คุณสามารถใช้:

- วิธีการเช่น [getLayoutSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getLayoutSlides--) และ [getMasters](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getMasters--) ภายใต้คลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)  
- ประเภทเช่น [ILayoutSlide](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilayoutplaceholdermanager/), และ [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
เพื่อเรียนรู้เพิ่มเติมเกี่ยวกับการทำงานกับมาสเตอร์สไลด์ ให้ดูบทความ [มาสเตอร์สไลด์](/slides/th/androidjava/slide-master/)  
{{% /alert %}}

## **เพิ่มเค้าโครงสไลด์ในงานนำเสนอ**

เพื่อปรับแต่งรูปลักษณ์และโครงสร้างของสไลด์ของคุณ คุณอาจต้องเพิ่มเค้าโครงสไลด์ใหม่ลงในงานนำเสนอ Aspose.Slides for Android อนุญาตให้คุณตรวจสอบว่าเค้าโครงที่ระบุมีอยู่แล้วหรือไม่ หากจำเป็นให้เพิ่มใหม่และใช้เพื่อแทรกสไลด์ตามเค้าโครงนั้น  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/).  
1. เข้าถึง [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imasterlayoutslidecollection/).  
1. ตรวจสอบว่าเค้าโครงสไลด์ที่ต้องการมีอยู่แล้วในคอลเลกชันหรือไม่ หากไม่มี ให้เพิ่มเค้าโครงสไลด์ที่คุณต้องการ.  
1. เพิ่มสไลด์เปล่าที่อิงจากเค้าโครงสไลด์ใหม่.  
1. บันทึกงานนำเสนอ.  

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์ PowerPoint.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // เรียกดูประเภทเค้าโครงสไลด์เพื่อเลือกเค้าโครงสไลด์.
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide layoutSlide = null;
    if (layoutSlides.getByType(SlideLayoutType.TitleAndObject) != null)
        layoutSlide = layoutSlides.getByType(SlideLayoutType.TitleAndObject);
    else
        layoutSlide = layoutSlides.getByType(SlideLayoutType.Title);

    if (layoutSlide == null) {
        // สถานการณ์ที่งานนำเสนอไม่มีเค้าโครงทั้งหมด.
        // ไฟล์งานนำเสนอมีเพียงเค้าโครงประเภท Blank และ Custom เท่านั้น.
        // อย่างไรก็ตาม เค้าโครงสไลด์ที่มีประเภท Custom อาจมีชื่อที่สามารถจดจำได้,
        // เช่น "Title", "Title and Content", เป็นต้น ซึ่งสามารถใช้สำหรับการเลือกเค้าโครงสไลด์.
        // คุณยังสามารถพึ่งพาชุดของประเภทรูปทรงตัวแสดงตำแหน่งได้.
        // ตัวอย่างเช่น สไลด์ Title ควรมีเพียงตัวแสดงตำแหน่งประเภท Title เท่านั้น และอื่น ๆ.
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

    // เพิ่มสไลด์เปล่าโดยใช้เค้าโครงสไลด์ที่เพิ่มไว้.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // บันทึกงานนำเสนอลงดิสก์.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ลบเค้าโครงสไลด์ที่ไม่ได้ใช้**

Aspose.Slides มีเมธอด [removeUnusedLayoutSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) จากคลาส [Compress](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/compress/) เพื่อให้คุณสามารถลบเค้าโครงสไลด์ที่ไม่ต้องการและไม่ได้ใช้  

โค้ด Java ด้านล่างแสดงวิธีการลบเค้าโครงสไลด์จากงานนำเสนอ PowerPoint:  

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **เพิ่มตัวแสดงตำแหน่งในเค้าโครงสไลด์**

Aspose.Slides มีเมธอด [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) ซึ่งอนุญาตให้คุณเพิ่มตัวแสดงตำแหน่งใหม่เข้าไปในเค้าโครงสไลด์  

ผู้จัดการนี้มีเมธอดสำหรับประเภทตัวแสดงตำแหน่งต่อไปนี้:  

| ตัวแสดงตำแหน่ง PowerPoint | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) เมธอด |
| --------------------------- | ------------------------------------------------------------ |
| ![เนื้อหา](content.png) | addContentPlaceholder(float x, float y, float width, float height) |
| ![เนื้อหา (แนวตั้ง)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![ข้อความ](text.png) | addTextPlaceholder(float x, float y, float width, float height) |
| ![ข้อความ (แนวตั้ง)](textV.png) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![รูปภาพ](picture.png) | addPicturePlaceholder(float x, float y, float width, float height) |
| ![แผนภูมิ](chart.png) | addChartPlaceholder(float x, float y, float width, float height) |
| ![ตาราง](table.png) | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![สื่อ](media.png) | addMediaPlaceholder(float x, float y, float width, float height) |
| ![รูปภาพออนไลน์](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

โค้ด Java ต่อไปนี้แสดงวิธีการเพิ่มรูปร่างตัวแสดงตำแหน่งใหม่ไปยังเค้าโครงสไลด์เปล่า:  

```java
Presentation presentation = new Presentation();
try {
    // รับเค้าโครงสไลด์ Blank.
    ILayoutSlide layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // รับผู้จัดการตัวแสดงตำแหน่งของเค้าโครงสไลด์.
    ILayoutPlaceholderManager placeholderManager = layout.getPlaceholderManager();

    // เพิ่มตัวแสดงตำแหน่งต่าง ๆ ไปยังเค้าโครงสไลด์ Blank.
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // เพิ่มสไลด์ใหม่ที่ใช้เค้าโครง Blank.
    ISlide newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:  

![ตัวแสดงตำแหน่งบนเค้าโครงสไลด์](add_placeholders.png)

## **ตั้งค่าการมองเห็นส่วนท้ายสำหรับเค้าโครงสไลด์**

ในงานนำเสนอ PowerPoint ส่วนท้ายเช่น วันที่, หมายเลขสไลด์, และข้อความกำหนดเองสามารถแสดงหรือซ่อนได้ตามเค้าโครงสไลด์ Aspose.Slides for Android อนุญาตให้คุณควบคุมการมองเห็นของตัวแสดงตำแหน่งส่วนท้ายเหล่านี้ ซึ่งมีประโยชน์เมื่อคุณต้องการให้บางเค้าโครงแสดงข้อมูลส่วนท้ายในขณะที่เค้าโครงอื่น ๆ คงความเรียบง่าย  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/).  
1. รับอ้างอิงเค้าโครงสไลด์โดยใช้ดัชนีของมัน.  
1. ตั้งค่าตัวแสดงตำแหน่งส่วนท้ายสไลด์ให้เป็นที่มองเห็น.  
1. ตั้งค่าตัวแสดงตำแหน่งหมายเลขสไลด์ให้เป็นที่มองเห็น.  
1. ตั้งค่าตัวแสดงตำแหน่งวันที่และเวลาให้เป็นที่มองเห็น.  
1. บันทึกงานนำเสนอ.  

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

ในงานนำเสนอ PowerPoint ส่วนท้ายเช่น วันที่, หมายเลขสไลด์, และข้อความกำหนดเองสามารถควบคุมได้ระดับมาสเตอร์สไลด์เพื่อให้สอดคล้องกันทั่วทุกเค้าโครงสไลด์ Aspose.Slides for Android ให้คุณตั้งค่าการมองเห็นและเนื้อหาของตัวแสดงตำแหน่งส่วนท้ายเหล่านี้บนมาสเตอร์สไลด์และกระจายการตั้งค่าเหล่านี้ไปยังเค้าโครงสไลด์ลูกทั้งหมด วิธีนี้ทำให้ข้อมูลส่วนท้ายสอดคล้องกันทั่วทั้งงานนำเสนอ  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/).  
1. รับอ้างอิงมาสเตอร์สไลด์โดยใช้ดัชนีของมัน.  
1. ตั้งค่าตัวแสดงตำแหน่งส่วนท้ายของมาสเตอร์และสไลด์ลูกทั้งหมดให้เป็นที่มองเห็น.  
1. ตั้งค่าตัวแสดงตำแหน่งหมายเลขสไลด์ของมาสเตอร์และสไลด์ลูกทั้งหมดให้เป็นที่มองเห็น.  
1. ตั้งค่าตัวแสดงตำแหน่งวันที่และเวลาของมาสเตอร์และสไลด์ลูกทั้งหมดให้เป็นที่มองเห็น.  
1. บันทึกงานนำเสนอ.  

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

**ความแตกต่างระหว่างมาสเตอร์สไลด์และเค้าโครงสไลด์คืออะไร?**

มาสเตอร์สไลด์กำหนดธีมโดยรวมและการจัดรูปแบบเริ่มต้น ในขณะที่เค้าโครงสไลด์กำหนดการจัดเรียงเฉพาะของตัวแสดงตำแหน่งสำหรับประเภทเนื้อหาต่าง ๆ  

**ฉันสามารถคัดลอกเค้าโครงสไลด์จากงานนำเสนอหนึ่งไปยังอีกงานนำเสนอหนึ่งได้หรือไม่?**

ได้ คุณสามารถโคลนเค้าโครงสไลด์จากคอลเลกชันเค้าโครงสไลด์ของงานนำเสนอหนึ่ง ซึ่งเข้าถึงได้ผ่านเมธอด [getLayoutSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getLayoutSlides--) และแทรกลงในงานนำเสนออื่นโดยใช้เมธอด `addClone`  

**จะเกิดอะไรขึ้นหากฉันลบเค้าโครงสไลด์ที่ยังถูกสไลด์อื่นใช้งานอยู่?**

หากคุณพยายามลบเค้าโครงสไลด์ที่ยังถูกอ้างอิงโดยสไลด์อย่างน้อยหนึ่งสไลด์ในงานนำเสนอ Aspose.Slides จะโยนข้อยกเว้น [PptxEditException](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/pptxeditexception/). เพื่อหลีกเลี่ยงสถานการณ์นี้ ให้ใช้เมธอด [removeUnusedLayoutSlides](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) ซึ่งจะลบเฉพาะเค้าโครงสไลด์ที่ไม่ได้ใช้งานอย่างปลอดภัย