---
title: ปรับใช้หรือเปลี่ยนเค้าโครงสไลด์ใน JavaScript
linktitle: เค้าโครงสไลด์
type: docs
weight: 60
url: /th/nodejs-java/slide-layout/
keywords:
- เค้าโครงสไลด์
- เค้าโครงเนื้อหา
- ตัวเก็บตำแหน่ง
- การออกแบบการนำเสนอ
- การออกแบบสไลด์
- เค้าโครงที่ไม่ได้ใช้
- การมองเห็นส่วนท้าย
- สไลด์หัวเรื่อง
- หัวเรื่องและเนื้อหา
- ส่วนหัวของหน้าตอน
- สองส่วนเนื้อหา
- การเปรียบเทียบ
- หัวเรื่องเท่านั้น
- เค้าโครงว่าง
- เนื้อหาพร้อมคำอธิบาย
- รูปภาพพร้อมคำอธิบาย
- หัวเรื่องและข้อความแนวตั้ง
- หัวเรื่องแนวตั้งและข้อความ
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "จัดการและปรับแต่งเค้าโครงสไลด์ใน Aspose.Slides สำหรับ Node.js. สำรวจประเภทเค้าโครง, การควบคุมตัวเก็บตำแหน่ง, และการมองเห็นส่วนท้ายผ่านตัวอย่างโค้ด."
---
## **บทนำ**

เค้าโครงสไลด์กำหนดการจัดเรียงของกล่องตัวเก็บตำแหน่งและการจัดรูปแบบสำหรับเนื้อหาบนสไลด์ มันควบคุมว่าตัวเก็บตำแหน่งใดบ้างที่พร้อมใช้งานและปรากฏที่ใด เค้าโครงสไลด์ช่วยให้คุณออกแบบการนำเสนอได้อย่างรวดเร็วและสม่ำเสมอ—ไม่ว่าคุณจะสร้างอะไรที่ง่ายหรือซับซ้อนบางอย่าง เค้าโครงสไลด์ที่พบบ่อยที่สุดใน PowerPoint ได้แก่:

**เค้าโครงสไลด์หัวเรื่อง** – มีตัวเก็บตำแหน่งข้อความสองอัน: อันหนึ่งสำหรับหัวเรื่องและอีกอันสำหรับหัวข้อรอง

**เค้าโครงหัวเรื่องและเนื้อหา** – มีตัวเก็บตำแหน่งหัวเรื่องขนาดเล็กที่ด้านบนและตัวใหญ่กว่าที่ด้านล่างสำหรับเนื้อหาหลัก (เช่น ข้อความ, จุดตัวอักษร, แผนภูมิ, รูปภาพ, และอื่น ๆ)

**เค้าโครงว่าง** – ไม่มีตัวเก็บตำแหน่งใด ๆ ให้คุณควบคุมเต็มที่ในการออกแบบสไลด์ตั้งแต่ต้น

เค้าโครงสไลด์เป็นส่วนหนึ่งของมาสเตอร์สไลด์ ซึ่งเป็นสไลด์ระดับบนสุดที่กำหนดสไตล์เค้าโครงสำหรับการนำเสนอ คุณสามารถเข้าถึงและแก้ไขเค้าโครงสไลด์ผ่านมาสเตอร์สไลด์—โดยใช้ประเภท, ชื่อ, หรือรหัสประจำตัวแบบยูนีค หรือคุณสามารถแก้ไขเค้าโครงสไลด์เฉพาะโดยตรงในงานนำเสนอได้

เพื่อทำงานกับเค้าโครงสไลด์ใน Aspose.Slides for Node.js, คุณสามารถใช้:
- วิธีการเช่น [getLayoutSlides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#getLayoutSlides) และ [getMasters](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#getMasters) ภายใต้คลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
- ชนิดเช่น [LayoutSlide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutplaceholdermanager/), และ [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
หากต้องการเรียนรู้เพิ่มเติมเกี่ยวกับการทำงานกับมาสเตอร์สไลด์, ดูบทความ [Slide Master](/slides/th/nodejs-java/slide-master/)​ 
{{% /alert %}}

## **เพิ่มเค้าโครงสไลด์ไปยังการนำเสนอ**

เพื่อปรับลักษณะและโครงสร้างของสไลด์ ให้คุณอาจจำเป็นต้องเพิ่มเค้าโครงสไลด์ใหม่ไปยังงานนำเสนอ Aspose.Slides for Node.js ให้คุณตรวจสอบว่าเค้าโครงที่ระบุมีอยู่แล้วหรือไม่ เพิ่มใหม่หากจำเป็น และใช้เพื่อแทรกสไลด์ตามเค้าโครงนั้น

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
2. เข้าถึง [MasterLayoutSlideCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masterlayoutslidecollection/)
3. ตรวจสอบว่าเค้าโครงสไลด์ที่ต้องการมีอยู่ในคอลเลกชันแล้วหรือไม่ หากไม่มีให้เพิ่มเค้าโครงสไลด์ที่คุณต้องการ
4. เพิ่มสไลด์เปล่าตามเค้าโครงสไลด์ใหม่
5. บันทึกงานนำเสนอ

โค้ด JavaScript ต่อไปนี้แสดงวิธีเพิ่มเค้าโครงสไลด์ไปยังงานนำเสนอ PowerPoint:

```js
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PowerPoint.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    // ตรวจสอบประเภทเค้าโครงสไลด์เพื่อเลือกเค้าโครงสไลด์.
    let layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    let layoutSlide = null;
    if (layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject)) != null) {
        layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject));
    } else {
        layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.Title));
    }

    if (layoutSlide == null) {
        // สถานการณ์ที่งานนำเสนอไม่มีเค้าโครงทุกรูปแบบ.
        // ไฟล์งานนำเสนอมีเพียงเค้าโครงประเภท Blank และ Custom เท่านั้น.
        // อย่างไรก็ตาม เค้าโครงสไลด์ที่เป็นประเภท custom อาจมีชื่อที่จำได้,
        // เช่น "Title", "Title and Content" เป็นต้น ซึ่งสามารถใช้เพื่อเลือกเค้าโครงสไลด์ได้.
        // คุณยังสามารถอาศัยชุดประเภทรูปร่างตัวเก็บตำแหน่งได้.
        // ตัวอย่างเช่น สไลด์ Title ควรมีเพียงประเภทตัวเก็บตำแหน่ง Title เท่านั้น เป็นต้น.
        for (let i = 0; i < layoutSlides.size(); i++) {
            let titleAndObjectLayoutSlide = layoutSlides.get_Item(i);
            if (titleAndObjectLayoutSlide.getName() === "Title and Object") {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null) {
            for (let i = 0; i < layoutSlides.size(); i++) {
                let titleLayoutSlide = layoutSlides.get_Item(i);
                if (titleLayoutSlide.getName() === "Title") {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null) {
                layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.Blank));
                if (layoutSlide == null) {
                    layoutSlide = layoutSlides.add(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject), "Title and Object");
                }
            }
        }
    }

    // เพิ่มสไลด์เปล่าโดยใช้เค้าโครงสไลด์ที่เพิ่มไว้.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // บันทึกงานนำเสนอลงดิสก์.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ลบเค้าโครงสไลด์ที่ไม่ได้ใช้**

Aspose.Slides ให้วิธีการ [removeUnusedLayoutSlides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) จากคลาส [Compress](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/compress/) เพื่อให้คุณลบเค้าโครงสไลด์ที่ไม่ต้องการและไม่ได้ใช้

โค้ด JavaScript ต่อไปนี้แสดงวิธีลบเค้าโครงสไลด์จากงานนำเสนอ PowerPoint:

```js
let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **เพิ่มตัวเก็บตำแหน่งลงในเค้าโครงสไลด์**

Aspose.Slides ให้วิธีการ [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) ซึ่งช่วยให้คุณเพิ่มตัวเก็บตำแหน่งใหม่ลงในเค้าโครงสไลด์

ผู้จัดการนี้มีวิธีการสำหรับประเภทตัวเก็บตำแหน่งต่อไปนี้:

| ตัวเก็บตำแหน่ง PowerPoint | เมธอด [LayoutPlaceholderManager](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutplaceholdermanager/) |
| -------------------------- | --------------------------------------------------------------------------------------------------------------------------------- |
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

โค้ด JavaScript ต่อไปนี้แสดงวิธีเพิ่มรูปทรงตัวเก็บตำแหน่งใหม่ลงในเค้าโครงสไลด์ Blank:

```js
let presentation = new aspose.slides.Presentation();
try {
    // รับเค้าโครงสไลด์ Blank.
    let layout = presentation.getLayoutSlides().getByType(java.newByte(aspose.slides.SlideLayoutType.Blank));

    // รับตัวจัดการตัวเก็บตำแหน่งของเค้าโครงสไลด์.
    let placeholderManager = layout.getPlaceholderManager();

    // เพิ่มตัวเก็บตำแหน่งต่าง ๆ ลงในเค้าโครงสไลด์ Blank.
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // เพิ่มสไลด์ใหม่โดยใช้เค้าโครง Blank.
    let newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ตัวเก็บตำแหน่งบนเค้าโครงสไลด์](add_placeholders.png)

## **ตั้งค่าการมองเห็นส่วนท้ายสำหรับเค้าโครงสไลด์**

ในงานนำเสนอ PowerPoint, ส่วนท้ายเช่น วันที่, หมายเลขสไลด์, และข้อความที่กำหนดเองสามารถแสดงหรือซ่อนได้ขึ้นอยู่กับเค้าโครงสไลด์ Aspose.Slides for Node.js ให้คุณควบคุมการมองเห็นของตัวเก็บตำแหน่งส่วนท้ายเหล่านี้ ซึ่งเป็นประโยชน์เมื่อคุณต้องการให้บางเค้าโครงแสดงข้อมูลส่วนท้ายในขณะที่เค้าโครงอื่น ๆ ดูสะอาดและเรียบง่าย

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
2. รับอ้างอิงเค้าโครงสไลด์ตามดัชนี
3. ตั้งค่าตัวเก็บตำแหน่งส่วนท้ายของสไลด์ให้เป็นแบบมองเห็น
4. ตั้งค่าตัวเก็บตำแหน่งหมายเลขสไลด์ให้เป็นแบบมองเห็น
5. ตั้งค่าตัวเก็บตำแหน่งวันที่‑เวลาให้เป็นแบบมองเห็น
6. บันทึกงานนำเสนอ

โค้ด JavaScript ต่อไปนี้แสดงวิธีตั้งค่าการมองเห็นของส่วนท้ายสไลด์และทำงานที่เกี่ยวข้อง:

```js
let presentation = new aspose.slides.Presentation("Presentation.ppt");
try {
    let headerFooterManager = presentation.getLayoutSlides().get_Item(0).getHeaderFooterManager();

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

    presentation.save("Presentation.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าการมองเห็นส่วนท้ายของลูกสำหรับสไลด์**

ในงานนำเสนอ PowerPoint, ส่วนท้ายเช่น วันที่, หมายเลขสไลด์, และข้อความที่กำหนดเองสามารถควบคุมได้ระดับมาสเตอร์สไลด์เพื่อให้แน่ใจว่ามีความสอดคล้องกันทั่วทั้งเค้าโครงสไลด์ Aspose.Slides for Node.js ช่วยให้คุณตั้งค่าการมองเห็นและเนื้อหาของตัวเก็บตำแหน่งส่วนท้ายเหล่านี้บนมาสเตอร์สไลด์และกระจายการตั้งค่าเหล่านั้นไปยังเค้าโครงสไลด์ลูกทั้งหมด วิธีการนี้ทำให้ข้อมูลส่วนท้ายเป็นแบบเดียวกันทั่วทั้งการนำเสนอ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
2. รับอ้างอิงมาสเตอร์สไลด์ตามดัชนี
3. ตั้งค่าตัวเก็บตำแหน่งส่วนท้ายของมาสเตอร์และเค้าโครงลูกให้เป็นแบบมองเห็น
4. ตั้งค่าตัวเก็บตำแหน่งหมายเลขสไลด์ของมาสเตอร์และเค้าโครงลูกให้เป็นแบบมองเห็น
5. ตั้งค่าตัวเก็บตำแหน่งวันที่‑เวลาของมาสเตอร์และเค้าโครงลูกให้เป็นแบบมองเห็น
6. บันทึกงานนำเสนอ

โค้ด JavaScript ต่อไปนี้แสดงการดำเนินการนี้:

```js
let presentation = new aspose.slides.Presentation("Presentation.ppt");
try {
    let headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();

    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่างมาสเตอร์สไลด์และเค้าโครงสไลด์คืออะไร?**

มาสเตอร์สไลด์กำหนดธีมโดยรวมและการจัดรูปแบบเริ่มต้น ในขณะที่เค้าโครงสไลด์กำหนดการจัดเรียงเฉพาะของตัวเก็บตำแหน่งสำหรับประเภทเนื้อหาต่าง ๆ

**ฉันสามารถคัดลอกเค้าโครงสไลด์จากงานนำเสนอหนึ่งไปยังอีกงานนำเสนอหนึ่งได้หรือไม่?**

ใช่ คุณสามารถโคลนเค้าโครงสไลด์จากคอลเลกชันเค้าโครงสไลด์ของงานนำเสนอหนึ่งโดยใช้วิธี [getLayoutSlides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/#getLayoutSlides) แล้วแทรกเข้าไปในงานนำเสนออื่นโดยใช้เมธอด `addClone`

**จะเกิดอะไรขึ้นหากฉันลบเค้าโครงสไลด์ที่ยังถูกสไลด์ใช้งานอยู่?**

หากคุณพยายามลบเค้าโครงสไลด์ที่ยังอ้างอิงโดยอย่างน้อยหนึ่งสไลด์ในงานนำเสนอ Aspose.Slides จะโยนข้อยกเว้น [PptxEditException](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pptxeditexception/) เพื่อหลีกเลี่ยงปัญหานี้ ให้ใช้ [removeUnusedLayoutSlides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) ซึ่งจะลบเค้าโครงสไลด์ที่ไม่ได้ใช้งานอย่างปลอดภัย