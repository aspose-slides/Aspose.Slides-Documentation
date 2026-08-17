---
title: ใช้หรือเปลี่ยนเค้าโครงสไลด์ใน JavaScript
linktitle: เค้าโครงสไลด์
type: docs
weight: 60
url: /th/nodejs-java/slide-layout/
keywords:
- เค้าโครงสไลด์
- เค้าโครงเนื้อหา
- ตั๋วตำแหน่ง
- การออกแบบงานนำเสนอ
- การออกแบบสไลด์
- เค้าโครงที่ไม่ได้ใช้
- การแสดงผลส่วนท้าย
- สไลด์ชื่อเรื่อง
- ชื่อเรื่องและเนื้อหา
- ส่วนหัวของหัวข้อ
- สองส่วนเนื้อหา
- การเปรียบเทียบ
- ชื่อเรื่องเท่านั้น
- เค้าโครงว่าง
- เนื้อหาพร้อมคำอธิบาย
- รูปภาพพร้อมคำอธิบาย
- ชื่อเรื่องและข้อความแนวตั้ง
- ชื่อเรื่องแนวตั้งและข้อความ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ใช้, สร้าง และแก้ไขเค้าโครงสไลด์ใน Aspose.Slides สำหรับ Node.js ผ่าน Java, เพิ่มตั๋วตำแหน่ง, ลบเค้าโครงที่ไม่ได้ใช้, และควบคุมการแสดงผลส่วนท้าย."
---
## **ภาพรวม**

เค้าโครงสไลด์กำหนดตำแหน่งและการจัดรูปแบบของตั๋วตำแหน่ง เช่น ชื่อเรื่อง, ข้อความ, รูปภาพ, แผนภูมิ และตาราง การใช้เค้าโครงทำให้สไลด์มีโครงสร้างสอดคล้องกันพร้อมกับให้แต่ละสไลด์มีเนื้อหาเฉพาะของตัวเอง

เค้าโครงที่พบได้บ่อยได้แก่:

- **สไลด์ชื่อเรื่อง**: มีตั๋วตำแหน่งชื่อเรื่องและชื่อย่อย
- **ชื่อเรื่องและเนื้อหา**: มีตั๋วตำแหน่งชื่อเรื่องและตั๋วตำแหน่งเนื้อหาทั่วไป
- **ว่าง**: ไม่มีตั๋วตำแหน่งใด ๆ และเหมาะเมื่อทุกรูปร่างจะถูกวางด้วยตนเอง

## **ทำความเข้าใจการสืบทอดเค้าโครง**

งานนำเสนอมีระดับที่เกี่ยวข้องกันสามระดับ:

1. A [สไลด์แม่](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masterslide/) กำหนดธีม, การจัดรูปแบบที่ใช้ร่วมกัน, พื้นหลัง, และวัตถุทั่วไป
1. A [สไลด์เค้าโครง](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutslide/) เป็นส่วนหนึ่งของสไลด์แม่และกำหนดการจัดวางตั๋วตำแหน่งเฉพาะ
1. A [สไลด์ปกติ](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slide/) ใช้เค้าโครงหนึ่งและเก็บเนื้อหาที่ป้อนสำหรับสไลด์นั้น

สไลด์ปกติสืบทอดธีมและการจัดรูปแบบจากเค้าโครงของมัน และเค้าโครงสืบทอดจากสไลด์แม่ ค่าที่ตั้งโดยตรงบนสไลด์ปกติจะทับค่าที่สืบทอดในระดับนั้น เมื่อสร้างสไลด์ปกติ รูปร่างตั๋วตำแหน่งจะถูกสร้างจากเค้าโครงที่เลือก ในขณะที่เนื้อหาที่ป้อนลงในตั๋วตำแหน่งนั้นเป็นของสไลด์ปกติ

เพิ่มตั๋วตำแหน่งที่จำเป็นลงในเค้าโครงก่อนสร้างสไลด์จากมัน การเพิ่มตั๋วตำแหน่งใหม่ในเค้าโครงภายหลังจะไม่ทำให้รูปร่างตั๋วตำแหน่งที่สอดคล้องกันถูกเพิ่มโดยอัตโนมัติในสไลด์ปกติที่มีอยู่แล้ว

ความสัมพันธ์นี้มีผลตามมาสองประการที่สำคัญ:

- การเปลี่ยนการจัดรูปแบบที่สืบทอดหรือรูปทรงตั๋วตำแหน่งที่มีอยู่บนเค้าโครงอาจอัปเดตทุกสไลด์ที่พึ่งพาเค้าโครงนั้น ก่อนแก้ไขเค้าโครงที่กำลังใช้อยู่ให้ตรวจสอบสไลด์ที่พึ่งพาและทบทวนผลลัพธ์ของงานนำเสนอ
- เค้าโครงที่ยังคงถูกสไลด์ใช้ไม่สามารถลบได้ ต้องเปลี่ยนสไลด์ที่พึ่งพาไปยังเค้าโครงอื่นก่อน หรือเพียงลบเค้าโครงที่ไม่ได้ใช้งาน

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับระดับบนสุดของลำดับชั้นนี้ ดูที่ [Slide Master](/slides/th/nodejs-java/slide-master/)

## **เลือกและนำไปใช้เค้าโครงสไลด์**

ใช้ค่า [SlideLayoutType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slidelayouttype/) เมื่องานนำปฏิบัติตามคำนิยามเค้าโครง PowerPoint มาตรฐาน ชื่อเค้าโครงสามารถแก้ไขได้โดยผู้ใช้และสามารถแปลเป็นภาษาต่าง ๆ ดังนั้นการเลือกโดยอิงชื่อจึงน้อยกว่าเชื่อถือได้ เว้นแต่คุณจะควบคุมเทมเพลตต้นทาง

ตัวอย่างต่อไปนี้ค้นหา **Title and Content** บนสไลด์แม่แรก หากไม่มีเค้าโครงนั้นจะย้อนกลับไปใช้ **Blank** อย่างเจตนา การตรวจสอบค่า null ครั้งที่สองเป็นสิ่งจำเป็นเพราะงานนำเสนออาจมีเฉพาะเค้าโครงที่กำหนดเองเท่านั้น เค้าโครงที่เลือกจะถูกนำไปใช้กับสไลด์ปกติแรกผ่านวิธี [Slide.setLayoutSlide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slide/#setLayoutSlide)

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

การเปลี่ยนเค้าโครงของสไลด์จะไม่ลบรูปร่างปกติที่เพิ่มโดยตรงลงบนสไลด์ อย่างไรก็ตามตำแหน่งตั๋วตำแหน่ง, การจัดรูปแบบที่สืบทอด, และความสอดคล้องระหว่างตั๋วตำแหน่งที่มีอยู่กับเค้าโครงใหม่อาจเปลี่ยนแปลง ดังนั้นให้ตรวจสอบผลลัพธ์เมื่อสลับไปมาระหว่างเค้าโครงที่แตกต่างกันอย่างชัดเจน

## **เพิ่มสไลด์เค้าโครง**

การเลือกและการสร้างเป็นการดำเนินการแยกกัน ตัวอย่างก่อนหน้านี้เลือกเค้าโครงที่มีอยู่แล้ว; ไม่ได้สร้างเค้าโครงใหม่ เพื่อสร้างเค้าโครงให้เรียกใช้วิธี [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masterlayoutslidecollection/#add) บนคอลเลกชันเค้าโครงของสไลด์แม่เป้าหมาย

ตัวอย่างต่อไปนี้จะเพิ่มเค้าโครง **Title and Content** ใหม่ที่ชื่อ `Report Title and Content` เสมอ แล้วจึงเพิ่มสไลด์ปกติที่อิงตามเค้าโครงนั้น ชื่อเค้าโครงต้องไม่ซ้ำในคอลเลกชัน

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

เพิ่มเค้าโครงเฉพาะเมื่อเทมเพลตต้องการโครงสร้างที่ใช้ซ้ำได้จริง หากมีเค้าโครงที่เหมาะสมอยู่แล้ว ให้เลือกและใช้ซ้ำแทนการสร้างสำเนาใหม่

## **เพิ่มตั๋วตำแหน่งลงในสไลด์เค้าโครง**

วิธี [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) ให้บริการ [LayoutPlaceholderManager](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutplaceholdermanager/) สำหรับการเพิ่มรูปร่างตั๋วตำแหน่งลงในเค้าโครง

| Placeholder ของ PowerPoint | วิธีการ `LayoutPlaceholderManager` |
| ---------------------------- | ----------------------------------- |
| ![Content](content.png) | [`addContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Content (Vertical)](contentV.png) | [`addVerticalContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Text](text.png) | [`addTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Text (Vertical)](textV.png) | [`addVerticalTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Picture](picture.png) | [`addPicturePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Chart](chart.png) | [`addChartPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Table](table.png) | [`addTablePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png) | [`addMediaPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online Image](onlineImage.png) | [`addOnlineImagePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

ตัวอย่างต่อไปนี้ตรวจสอบว่าเค้าโครง **Blank** มีอยู่ แล้วเพิ่มตั๋วตำแหน่งสี่รายการลงในเค้าโครงนั้น จากนั้นสร้างสไลด์ปกติที่ใช้เค้าโครงที่แก้ไขแล้ว ลำดับการทำงานตั้งใจให้เพิ่มตั๋วตำแหน่งก่อนสร้างสไลด์ปกติ เพื่อให้ Aspose.Slides สามารถสร้างรูปร่างตั๋วตำแหน่งที่สอดคล้องกันบนสไลด์นั้น

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

![The placeholders on the layout slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
การเปลี่ยนการจัดรูปแบบที่สืบทอดหรือรูปทรงของตั๋วตำแหน่งเค้าโครงที่มีอยู่สามารถส่งผลต่อสไลด์ที่พึ่งพาได้ ตั๋วตำแหน่งเค้าโครงที่เพิ่มใหม่จะไม่ถูกเติมกลับเข้าสู่สไลด์ปกติที่มีอยู่แล้ว ให้ทดสอบการเปลี่ยนแปลงเค้าโครงบนสำเนาของงานนำเสนอและตรวจสอบสไลด์ที่พึ่งพาทุกสไลด์
{{% /alert %}}

## **ลบสไลด์เค้าโครงที่ไม่ได้ใช้**

ใช้วิธี [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) เพื่อลบเค้าโครงที่ไม่มีสไลด์ปกติอ้างอิง วิธีนี้จะละทิ้งเค้าโครงที่ยังคงใช้งานอยู่

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

เพื่อทำการลบเค้าโครงเฉพาะหนึ่งรายการ ให้ใช้วิธี [hasDependingSlides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutslide/#hasDependingSlides) หรือ [getDependingSlides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) ก่อน ย้ายสไลด์ที่พึ่งพาไปยังเค้าโครงอื่นก่อนเรียก [LayoutSlide.remove](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutslide/#remove) การพยายามลบเค้าโครงที่กำลังใช้งานจะทำให้เกิด [PptxEditException](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pptxeditexception/)

## **ควบคุมการแสดงผลส่วนท้ายบนสไลด์เค้าโครง**

เค้าโครงมีส่วนท้าย, ตัวเลขสไลด์, และตั๋วตำแหน่งวันที่‑เวลา ของตนเอง ใช้วิธี [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutslide/#getHeaderFooterManager) เพื่อควบคุมตั๋วตำแหน่งเหล่านั้นสำหรับเค้าโครงหนึ่ง ๆ นี่เป็นประโยชน์เมื่อเช่น เค้าโครงเนื้อหาควรแสดงส่วนท้ายแต่เค้าโครงชื่อเรื่องไม่ควรแสดง

ตัวอย่างต่อไปนี้เลือกเค้าโครงอย่างปลอดภัยและทำให้ส่วนท้ายของมันแสดงผล

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

## **ควบคุมการแสดงผลส่วนท้ายบนสไลด์แม่และเค้าโครงลูกของมัน**

เพื่อใช้การตั้งค่าส่วนท้ายอย่างสอดคล้องกันทั่วทั้งลำดับชั้นสไลด์แม่ ให้ใช้วิธี [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masterslide/#getHeaderFooterManager) วิธีการเผยแพร่ของ [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masterslideheaderfootermanager/) ทำงานบนสไลด์แม่และสไลด์เค้าโครงและสไลด์ปกติที่พึ่งพา; ไม่ได้มุ่งเป้าแค่สไลด์ปกติหนึ่งสไลด์

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

**ความแตกต่างระหว่างสไลด์แม่และสไลด์เค้าโครงคืออะไร?**

สไลด์แม่กำหนดธีมและการจัดรูปแบบที่ใช้ร่วมกันของงานนำเสนอ สไลด์เค้าโครงเป็นส่วนหนึ่งของสไลด์แม่และกำหนดการจัดวางตั๋วตำแหน่งที่ใช้ซ้ำได้ สไลด์ปกติใช้เค้าโครงเหล่านั้นและเก็บเนื้อหาเฉพาะสไลด์

**ฉันสามารถคัดลอกสไลด์เค้าโครงจากงานนำเสนอหนึ่งไปยังอีกงานนำเสนอได้หรือไม่?**

ทำได้ ให้เพิ่มสำเนาไปยังคอลเลกชันปลายทางด้วยวิธี [addClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/globallayoutslidecollection/#addClone) เมื่อคัดลอกระหว่างงานนำเสนอให้ตรวจสอบแบบอักษร, ธีม, รูปภาพและทรัพยากรอื่น ๆ ที่ใช้โดยเค้าโครงต้นทางด้วย

**จะเกิดอะไรขึ้นเมื่อฉันแก้ไขเค้าโครงที่กำลังใช้อยู่แล้ว?**

สไลด์ที่พึ่งพาจะสืบทอดการเปลี่ยนแปลงเค้าโครง เว้นแต่พวกเขาจะทับการจัดรูปแบบหรือวัตถุที่ได้รับผลกระทบไว้ในระดับท้องถิ่น รูปร่างตั๋วตำแหน่งและสไตล์ที่สืบทอดอาจเปลี่ยนแปลงบนหลายสไลด์พร้อมกัน ใช้วิธี [getDependingSlides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) เพื่อระบุสไลด์ที่ได้รับผลกระทบก่อนแก้ไขเค้าโครง

**จะเกิดอะไรขึ้นหากฉันลบเค้าโครงที่ยังคงถูกใช้งานอยู่?**

Aspose.Slides จะโยง [PptxEditException](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pptxeditexception/) ให้ย้ายสไลด์ที่พึ่งพาไปยังเค้าโครงอื่นก่อน หรือตัวเลือกใช้ [removeUnusedLayoutSlides](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) เพื่อลบเฉพาะเค้าโครงที่ไม่มีการอ้างอิง

{{% /alert %}}