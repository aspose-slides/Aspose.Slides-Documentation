---
title: "นำไปใช้หรือเปลี่ยนแปลงเค้าโครงสไลด์ใน JavaScript"
linktitle: "เค้าโครงสไลด์"
type: docs
weight: 60
url: /th/nodejs-java/slide-layout/
keywords:
- "เค้าโครงสไลด์"
- "เค้าโครงเนื้อหา"
- "ตัวเก็บตำแหน่ง"
- "การออกแบบการนำเสนอ"
- "การออกแบบสไลด์"
- "เค้าโครงที่ไม่ได้ใช้"
- "การมองเห็นส่วนท้าย"
- "สไลด์ชื่อเรื่อง"
- "ชื่อเรื่องและเนื้อหา"
- "หัวข้อส่วน"
- "สองเนื้อหา"
- "การเปรียบเทียบ"
- "เฉพาะชื่อเรื่อง"
- "เค้าโครงเปล่า"
- "เนื้อหาพร้อมคำอธิบาย"
- "รูปภาพพร้อมคำอธิบาย"
- "ชื่อเรื่องและข้อความแนวตั้ง"
- "ชื่อเรื่องแนวตั้งและข้อความ"
- "PowerPoint"
- "OpenDocument"
- "การนำเสนอ"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "นำไปใช้, สร้างและแก้ไขเค้าโครงสไลด์ใน Aspose.Slides สำหรับ Node.js ผ่าน Java, เพิ่มตัวเก็บตำแหน่ง, ลบเค้าโครงที่ไม่ได้ใช้, และควบคุมการมองเห็นส่วนท้าย."
---
## **ภาพรวม**

เค้าโครงสไลด์กำหนดตำแหน่งและรูปแบบของตัวเก็บตำแหน่ง เช่น ชื่อเรื่อง, ข้อความ, รูปภาพ, แผนภูมิ และตาราง การนำเค้าโครงไปใช้ทำให้สไลด์มีโครงสร้างที่สอดคล้องกันในขณะที่แต่ละสไลด์ยังคงมีเนื้อหาเฉพาะของตน

เค้าโครงที่พบมากที่สุดประกอบด้วย:

- **สไลด์ชื่อเรื่อง**: มีตัวเก็บตำแหน่งชื่อเรื่องและหัวเรื่องย่อย
- **ชื่อเรื่องและเนื้อหา**: มีตัวเก็บตำแหน่งชื่อเรื่องและตัวเก็บตำแหน่งเนื้อหาทั่วไป
- **เปล่า**: ไม่มีตัวเก็บตำแหน่งเนื้อหาและเป็นประโยชน์เมื่อรูปทรงทุกอย่างจะถูกจัดตำแหน่งด้วยตนเอง

## **ทำความเข้าใจการสืบทอดเค้าโครง**

การนำเสนอมีระดับที่เกี่ยวข้องสามระดับ:

1. A [สไลด์หลัก](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masterslide/) defines the theme, shared formatting, backgrounds, and common objects.
2. A [สไลด์เค้าโครง](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutslide/) belongs to a master and defines a particular arrangement of placeholders.
3. A [สไลด์ปกติ](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slide/) uses one layout and stores the content entered for that slide.

สไลด์ปกติสืบทอดธีมและรูปแบบจากเค้าโครงของมัน และเค้าโครงสืบทอดจากมาสเตอร์ ค่าใดที่ตั้งโดยตรงบนสไลด์ปกติจะทับค่าที่สืบทอดในระดับนั้น เมื่อสไลด์ปกติถูกสร้าง รูปทรงตัวเก็บตำแหน่งจะถูกสร้างจากเค้าโครงที่เลือกในขณะที่เนื้อหาที่ใส่ลงในตัวเก็บตำแหน่งเหล่านั้นเป็นของสไลด์ปกติ

เพิ่มตัวเก็บตำแหน่งที่จำเป็นลงในเค้าโครงก่อนสร้างสไลด์จากมัน การเพิ่มตัวเก็บตำแหน่งอีกอันลงในเค้าโครงภายหลังจะไม่ทำให้รูปทรงตัวเก็บตำแหน่งที่สอดคล้องกันถูกเพิ่มอัตโนมัติในสไลด์ปกติที่มีอยู่

ความสัมพันธ์นี้มีผลสำคัญสองประการ:

- การเปลี่ยนรูปแบบที่สืบทอดหรือรูปทรงของตัวเก็บตำแหน่งที่มีอยู่บนเค้าโครงสามารถปรับอัปเดตทุกสไลด์ที่พึ่งพาเค้าโครงนั้นได้ ก่อนแก้ไขเค้าโครงที่กำลังใช้งานอยู่ ตรวจสอบสไลด์ที่พึ่งพาและทบทวนการนำเสนอที่ได้
- เค้าโครงที่ยังคงถูกสไลด์หนึ่งใช้งานอยู่ไม่สามารถลบได้ ต้องกำหนดสไลด์ที่พึ่งพาให้ใช้เค้าโครงอื่นก่อน หรือทำการลบเฉพาะเค้าโครงที่ไม่ได้ใช้เท่านั้น

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับระดับบนของโครงสร้างนี้ ดูที่ [Slide Master](/slides/th/nodejs-java/slide-master/)

เพื่อซ่อนโลโก้หรือรูปทรงมาสเตอร์ที่สืบทอดบนสไลด์เดียวหรือผ่านเค้าโครงที่แชร์กัน ดูที่ [Control the Visibility of Master Graphics](/slides/th/nodejs-java/slide-master/). ตัวอย่างเปรียบเทียบสองสไลด์ที่ใช้มาสเตอร์เดียวกัน

## **เลือกและใช้เค้าโครงสไลด์**

ใช้ค่า [SlideLayoutType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidelayouttype/) เมื่อการนำเสนอปฏิบัติตามคำนิยามเค้าโครง PowerPoint มาตรฐาน ชื่อเค้าโครงสามารถแก้ไขได้โดยผู้ใช้และสามารถแปลเป็นภาษาต่างๆ ได้ ดังนั้นการเลือกโดยใช้ชื่อจะน่าเชื่อถือน้อยลง หากคุณควบคุมเทมเพลตต้นแบบ

ตัวอย่างต่อไปนี้มองหา **ชื่อเรื่องและเนื้อหา** บนมาสเตอร์แรก หากไม่มีเค้าโครงนั้น จะย้อนกลับอย่างเจตนาไปยัง **เปล่า** การตรวจสอบ null ครั้งที่สองจำเป็นเพราะการนำเสนออาจมีเฉพาะเค้าโครงแบบกำหนดเองเท่านั้น เค้าโครงที่เลือกจากนั้นจะถูกนำไปใช้กับสไลด์ปกติแรกผ่านเมธอด [Slide.setLayoutSlide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slide/#setLayoutSlide)

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let targetLayout = layoutSlides.getByType(titleAndObjectLayoutType);

    if (targetLayout === null) {
        targetLayout = layoutSlides.getByType(blankLayoutType);
    }

    if (targetLayout === null) {
        throw new Error("The first master does not contain a suitable layout slide.");
    }

    presentation.getSlides().get_Item(0).setLayoutSlide(targetLayout);
    presentation.save("output-with-new-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การเปลี่ยนเค้าโครงของสไลด์ไม่ทำให้รูปทรงปกติที่เพิ่มโดยตรงบนสไลด์หายไป อย่างไรก็ตาม ตำแหน่งของตัวเก็บตำแหน่ง รูปแบบที่สืบทอด และความสอดคล้องระหว่างตัวเก็บตำแหน่งที่มีอยู่กับเค้าโครงใหม่อาจเปลี่ยนแปลงได้ ดังนั้นควรตรวจสอบผลลัพธ์เมื่อสลับระหว่างเค้าโครงที่แตกต่างอย่างมีนัยสำคัญ

## **เพิ่มสไลด์เค้าโครง**

การเลือกและการสร้างเป็นการดำเนินการแยกกัน ตัวอย่างก่อนหน้านี้เลือกเค้าโครงที่มีอยู่ แต่ไม่ได้สร้างเค้าโครงใหม่ เพื่อสร้างเค้าโครง ให้เรียกเมธอด [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masterlayoutslidecollection/#add) บนคอลเลกชันเค้าโครงของมาสเตอร์เป้าหมาย

ตัวอย่างต่อไปนี้จะเพิ่มเค้าโครง **ชื่อเรื่องและเนื้อหา** ใหม่ที่ชื่อ `Report Title and Content` เสมอ แล้วจึงเพิ่มสไลด์ปกติที่อิงตามเค้าโครงนั้น ชื่อเค้าโครงต้องไม่ซ้ำกันภายในคอลเลกชัน

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let reportLayout = masterSlide.getLayoutSlides().add(titleAndObjectLayoutType, "Report Title and Content");
    presentation.getSlides().addEmptySlide(reportLayout);

    presentation.save("output-with-report-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

เพิ่มเค้าโครงเฉพาะเมื่อเทมเพลตต้องการโครงสร้างที่ใช้งานซ้ำได้จริง หากมีเค้าโครงที่เหมาะสมอยู่แล้ว ให้เลือกและนำกลับมาใช้แทนการสร้างสำเนาใหม่

## **เพิ่มตัวเก็บตำแหน่งในสไลด์เค้าโครง**

เมธอด [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) ให้ [LayoutPlaceholderManager](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutplaceholdermanager/) สำหรับการเพิ่มรูปทรงตัวเก็บตำแหน่งลงในเค้าโครง

| ตัวตำแหน่ง PowerPoint | `LayoutPlaceholderManager` Method |
| ---------------------- | --------------------------------- |
| ![เนื้อหา](content.png) | [`addContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![เนื้อหา (แนวตั้ง)](contentV.png) | [`addVerticalContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![ข้อความ](text.png) | [`addTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![ข้อความ (แนวตั้ง)](textV.png) | [`addVerticalTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![รูปภาพ](picture.png) | [`addPicturePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![แผนภูมิ](chart.png) | [`addChartPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![ตาราง](table.png) | [`addTablePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![สื่อ](media.png) | [`addMediaPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![ภาพออนไลน์](onlineImage.png) | [`addOnlineImagePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

ตัวอย่างต่อไปนี้ตรวจสอบว่าเค้าโครง **เปล่า** มีอยู่แล้ว เพิ่มตัวเก็บตำแหน่งสี่อันลงในเค้าโครงนั้น จากนั้นสร้างสไลด์ปกติที่ใช้เค้าโครงที่แก้ไขแล้ว ลำดับขั้นตอนตั้งใจให้เพิ่มตัวเก็บตำแหน่งก่อนสร้างสไลด์ปกติ เพื่อให้ Aspose.Slides สามารถสร้างรูปทรงตัวเก็บตำแหน่งที่สอดคล้องกันบนสไลด์นั้นได้

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let blankLayout = presentation.getLayoutSlides().getByType(blankLayoutType);

    if (blankLayout === null) {
        throw new Error("The presentation does not contain a Blank layout slide.");
    }

    let placeholderManager = blankLayout.getPlaceholderManager();
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    presentation.getSlides().addEmptySlide(blankLayout);
    presentation.save("output-with-placeholders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ตัวเก็บตำแหน่งบนสไลด์เค้าโครง](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
การเปลี่ยนรูปแบบที่สืบทอดหรือรูปทรงของตัวเก็บตำแหน่งเค้าโครงที่มีอยู่สามารถส่งผลต่อสไลด์ที่พึ่งพาได้ ตัวเก็บตำแหน่งเค้าโครงที่เพิ่มใหม่จะไม่ถูกเติมกลับไปยังสไลด์ปกติที่มีอยู่แล้ว ทดสอบการเปลี่ยนแปลงเค้าโครงบนสำเนาของการนำเสนอและตรวจสอบสไลด์ที่พึ่งพาทุกสไลด์
{{% /alert %}}

## **ลบสไลด์เค้าโครงที่ไม่ได้ใช้**

ใช้เมธอด [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) เพื่อลบเค้าโครงที่ไม่มีสไลด์ปกติอ้างอิง เมธอดจะละทิ้งเค้าโครงที่ยังคงถูกใช้

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("output-without-unused-layouts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

เพื่อจะลบเค้าโครงเฉพาะหนึ่งอัน ให้ใช้เมธอด [hasDependingSlides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutslide/#hasDependingSlides) หรือ [getDependingSlides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) ของเค้าโครงนั้นก่อน ย้ายสไลด์ที่พึ่งพาไปยังเค้าโครงอื่นก่อนเรียก [LayoutSlide.remove](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutslide/#remove) การพยายามลบเค้าโครงที่กำลังใช้งานจะทำให้เกิด [PptxEditException](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pptxeditexception/)

## **ควบคุมการมองเห็นส่วนท้ายบนสไลด์เค้าโครง**

เค้าโครงมีส่วนท้ายของตัวเอง, ตัวเลขสไลด์, และตัวเก็บตำแหน่งวันที่‑เวลา ใช้เมธอด [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutslide/#getHeaderFooterManager) เพื่อควบคุมตัวเก็บตำแหน่งเหล่านั้นสำหรับเค้าโครงหนึ่ง ซึ่งมีประโยชน์เมื่อ ตัวอย่างเช่น เค้าโครงเนื้อหาควรแสดงส่วนท้ายแต่เค้าโครงชื่อเรื่องไม่ควรแสดง

ตัวอย่างต่อไปนี้เลือกเค้าโครงอย่างปลอดภัยและทำให้ส่วนท้ายของเค้าโครงนั้นมองเห็นได้:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = presentation.getLayoutSlides().getByType(titleAndObjectLayoutType);

    if (layoutSlide === null) {
        layoutSlide = presentation.getLayoutSlides().getByType(blankLayoutType);
    }

    if (layoutSlide === null) {
        throw new Error("The presentation does not contain a suitable layout slide.");
    }

    let headerFooterManager = layoutSlide.getHeaderFooterManager();
    headerFooterManager.setFooterVisibility(true);
    headerFooterManager.setSlideNumberVisibility(true);
    headerFooterManager.setDateTimeVisibility(true);
    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("output-with-layout-footers.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ควบคุมการมองเห็นส่วนท้ายบนมาสเตอร์และเค้าโครงลูกของมัน**

เพื่อใช้การตั้งค่าส่วนท้ายที่สอดคล้องกันทั่วทั้งลำดับชั้นมาสเตอร์ ให้ใช้เมธอด [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masterslide/#getHeaderFooterManager) วิธีการเผยแพร่ของ [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masterslideheaderfootermanager/) ทำงานบนมาสเตอร์และสไลด์เค้าโครงที่พึ่งพาและสไลด์ปกติ; ไม่ได้มุ่งเป้าไปที่สไลด์ปกติหนึ่งเดียว

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);
    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("output-with-master-footers.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่างสไลด์มาสเตอร์และสไลด์เค้าโครงคืออะไร?**

สไลด์มาสเตอร์กำหนดธีมและรูปแบบที่ใช้ร่วมกันของการนำเสนอ สไลด์เค้าโครงเป็นส่วนหนึ่งของมาสเตอร์และกำหนดการจัดเรียงตัวเก็บตำแหน่งที่สามารถนำกลับมาใช้ได้หนึ่งแบบ สไลด์ปกติใช้เค้าโครงเหล่านั้นและเก็บเนื้อหาเฉพาะสไลด์

**ฉันสามารถคัดลอกสไลด์เค้าโครงจากการนำเสนอหนึ่งไปยังอีกการนำเสนอได้หรือไม่?**

ได้ เพิ่มสำเนาไปยังคอลเลกชันปลายในปลายทางด้วยเมธอด [addClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/globallayoutslidecollection/#addClone) เมื่อคัดลอกระหว่างการนำเสนอ ควรตรวจสอบแบบอักษร, ธีม, รูปภาพและทรัพยากรอื่น ๆ ที่ใช้โดยเค้าโครงต้นฉบับด้วย

**จะเกิดอะไรขึ้นเมื่อฉันแก้ไขเค้าโครงที่กำลังใช้งานอยู่?**

สไลด์ที่พึ่งพาจะสืบทอดการเปลี่ยนแปลงของเค้าโครง เว้นแต่พวกเขาจะเขียนทับรูปแบบหรือวัตถุที่ได้รับผลกระทบในระดับท้องถิ่น รูปทรงของตัวเก็บตำแหน่งและสไตล์ที่สืบทอดอาจเปลี่ยนแปลงในหลายสไลด์พร้อมกัน ใช้ [getDependingSlides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) เพื่อระบุตัวสไลด์ที่ได้รับผลกระทบก่อนแก้ไขเค้าโครง

**จะเกิดอะไรขึ้นหากลบเค้าโครงที่ยังคงถูกใช้อยู่?**

Aspose.Slides จะโยน [PptxEditException](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pptxeditexception/) ให้ย้ายสไลด์ที่พึ่งพาไปก่อน หรือใช้ [removeUnusedLayoutSlides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) เพื่อลบเฉพาะเค้าโครงที่ไม่มีการอ้างอิงเท่านั้น