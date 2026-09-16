---
title: จัดการไฮเปอร์ลิงก์การนำเสนอใน JavaScript
linktitle: จัดการไฮเปอร์ลิงก์
type: docs
weight: 20
url: /th/nodejs-java/manage-hyperlinks/
keywords:
- เพิ่ม URL
- เพิ่มไฮเปอร์ลิงก์
- สร้างไฮเปอร์ลิงก์
- กำหนดรูปแบบไฮเปอร์ลิงก์
- ลบไฮเปอร์ลิงก์
- อัปเดตไฮเปอร์ลิงก์
- ไฮเปอร์ลิงก์ข้อความ
- ไฮเปอร์ลิงก์สไลด์
- ไฮเปอร์ลิงก์รูปร่าง
- ไฮเปอร์ลิงก์ภาพ
- ไฮเปอร์ลิงก์วิดีโอ
- ไฮเปอร์ลิงก์ที่แก้ไขได้
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เพิ่ม, กำหนดรูปแบบ, อัปเดตและลบไฮเปอร์ลิงก์ในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java โดยใช้ตัวอย่าง JavaScript."
---
## **บทนำ**

ไฮเปอร์ลิงก์เชื่อมต่อเนื้อหางานนำเสนอไปยังเว็บไซต์หรือตำแหน่งภายในงานนำเสนอเอง ใน PowerPoint ไฮเปอร์ลิงก์มักทำหน้าที่สองอย่าง:

* เปิดเว็บไซต์จากข้อความ รูปร่าง หรือเฟรมสื่อ
* ไปยังสไลด์อื่น ตัวอย่างเช่นจากสารบัญ

Aspose.Slides for Node.js via Java ให้คุณเพิ่มลิงก์เหล่านี้ ควบคุมลักษณะและเสียงของมัน ปรับปรุงคุณสมบัติ และลบออก ตัวอย่างด้านล่างแสดงวิธีทำงานกับไฮเปอร์ลิงก์บนองค์ประกอบแต่ละตัวและวิธีเข้าถึงไฮเปอร์ลิงก์ที่ระดับงานนำเสนอ สไลด์ หรือกรอบข้อความ

{{% alert color="info" title="Note" %}}

คุณสามารถแก้ไขงานนำเสนอด้วย [ฟรีออนไลน์ Aspose PowerPoint editor](https://products.aspose.app/slides/th/editor) ได้เช่นกัน

{{% /alert %}} 

## **เพิ่มไฮเปอร์ลิงก์ URL**

คุณสามารถกำหนด URL ของเว็บไซต์ให้กับข้อความ รูปร่าง หรือเฟรมสื่อได้ พื้นที่ที่คลิกได้จะขึ้นอยู่กับองค์ประกอบที่คุณกำหนดไฮเปอร์ลิงก์: ส่วนของข้อความจะเป็นลิงก์ที่เชื่อมต่อกับข้อความที่เลือก ขณะที่รูปร่างหรือเฟรมจะเป็นลิงก์ที่เชื่อมต่อกับอ็อบเจ็กต์สไลด์

### **เพิ่มไฮเปอร์ลิงก์ URL ให้กับข้อความ**

เพื่อเชื่อมข้อความกับเว็บไซต์ ให้ส่ง [Hyperlink](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Hyperlink) ไปยังเมธอด [setHyperlinkClick](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/PortionFormat#setHyperlinkClick) ของส่วนข้อความ ตามตัวอย่างด้านล่าง ส่วนของข้อความนั้นจะกลายเป็นคลิกได้เท่านั้น

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const textShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    textShape.addTextFrame("Aspose: File Format APIs");
    const portionFormat = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");
    portionFormat.setFontHeight(32);

    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **เพิ่มไฮเปอร์ลิงก์ URL ให้กับรูปร่างและเฟรมสื่อ**

เพื่อทำให้รูปร่างหรือเฟรมสามารถคลิกได้ ให้เรียกเมธอด [setHyperlinkClick](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Shape#setHyperlinkClick) ของมัน ไฮเปอร์ลิงก์จะเป็นของอ็อบเจ็กต์เอง ไม่ใช่ของส่วนข้อความภายใน

วิธีเดียวกันใช้กับรูปภาพ เสียง และวิดีโอเฟรม: กำหนดไฮเปอร์ลิงก์ให้กับเฟรมและเรียก [setTooltip](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Hyperlink#setTooltip) หากต้องการ

ตัวอย่างต่อไปทำให้สี่เหลี่ยมสามารถคลิกได้:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50);

    shape.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");

    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ใช้ไฮเปอร์ลิงก์สร้างสารบัญ**

ไฮเปอร์ลิงก์ภายในทำให้ผู้อ่านกระโดดจากสารบัญไปยังสไลด์ที่ต้องการ ตัวอย่างต่อไปใช้ [setInternalHyperlinkClick](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/HyperlinkManager#setInternalHyperlinkClick) เพื่อเชื่อมข้อความ “Page 2” บนสไลด์แรกไปยังสไลด์ที่สอง

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    const tableOfContents = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 100);
    tableOfContents.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    tableOfContents.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    tableOfContents.getTextFrame().getParagraphs().clear();

    const paragraph = new aspose.slides.Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    paragraph.setText("Title of slide 2 .......... ");

    const linkPortion = new aspose.slides.Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

    paragraph.getPortions().add(linkPortion);
    tableOfContents.getTextFrame().getParagraphs().add(paragraph);

    presentation.save("link_to_slide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **กำหนดรูปแบบไฮเปอร์ลิงก์**

### **สี**

เมธอด [setColorSource](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Hyperlink#setColorSource) ของ [Hyperlink](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Hyperlink) กำหนดว่าไฮเปอร์ลิงก์จะใช้สีไฮเปอร์ลิงก์ของงานนำเสนอหรือการจัดรูปแบบของส่วนข้อความหรือไม่ หากต้องการใช้สีข้อความที่กำหนดเอง ให้เลือก [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/HyperlinkColorSource) และตั้งค่าสีเติมของส่วนนั้น ฟีเจอร์นี้เริ่มต้นตั้งแต่ PowerPoint 2019; รุ่นก่อนหน้าจะไม่ใช้การตั้งค่านี้

ตัวอย่างต่อไปเพิ่มไฮเปอร์ลิงก์ข้อความสองตัวบนสไลด์เดียว ตัวแรกใช้สีเติมข้อความสีแดง ส่วนที่สองใช้สีไฮเปอร์ลิงก์เริ่มต้น

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const coloredShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 450, 50, false);
    coloredShape.addTextFrame("This hyperlink uses a custom color.");
    const coloredPortionFormat = coloredShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    coloredPortionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    coloredPortionFormat.getHyperlinkClick().setColorSource(aspose.slides.HyperlinkColorSource.PortionFormat);
    coloredPortionFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    coloredPortionFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    const defaultShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 450, 50, false);
    defaultShape.addTextFrame("This hyperlink uses the default color.");
    defaultShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));

    presentation.save("presentation-out-hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
### **เสียง**

ไฮเปอร์ลิงก์สามารถเล่นเสียงเมื่อเปิดใช้งานหรือหยุดเสียงที่กำลังเล่นอยู่ได้ ใช้เมธอดต่อไปนี้เพื่อกำหนดพฤติกรรมเหล่านั้น:

- [Hyperlink.setSound](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Hyperlink#setSound) ระบุไฟล์เสียงที่เชื่อมกับไฮเปอร์ลิงก์
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick) ควบคุมว่าการคลิกไฮเปอร์ลิงก์จะหยุดเสียงก่อนหน้าหรือไม่

#### **เพิ่มเสียงให้กับไฮเปอร์ลิงก์**

ตัวอย่างต่อไปโหลด `sampleaudio.wav` แล้วเชื่อมกับปุ่มบนสไลด์แรก การคลิกปุ่มจะเล่นเสียงและไปยังสไลด์ถัดไป รูปร่างที่สองบนสไลด์เดียวกันจะหยุดเสียงก่อนหน้าเมื่อคลิกโดยไม่ทำการนำทางใด ๆ

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sampleaudio.wav");
    let hyperlinkSound;
    try {
        hyperlinkSound = presentation.getAudios().addAudio(audioStream);
    } finally {
        audioStream.close();
    }

    const firstSlide = presentation.getSlides().get_Item(0);

    const playButton = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.SoundButton, 100, 100, 100, 50);
    playButton.setHyperlinkClick(aspose.slides.Hyperlink.getNextSlide());

    if (!playButton.getHyperlinkClick().getStopSoundOnClick() && playButton.getHyperlinkClick().getSound() == null)
    {
        playButton.getHyperlinkClick().setSound(hyperlinkSound);
    }

    const secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    const stopButton = secondSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 100, 50);
    stopButton.setHyperlinkClick(aspose.slides.Hyperlink.getNoAction());

    stopButton.getHyperlinkClick().setStopSoundOnClick(true);

    presentation.save("hyperlink-sound.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

#### **ดึงเสียงจากไฮเปอร์ลิงก์**

ตัวอย่างต่อไปเปิดงานนำเสนอที่สร้างไว้ข้างต้นและอ่านเสียงของไฮเปอร์ลิงก์ในรูปร่างแรกเข้าสู่หน่วยความจำโดยใช้ [getSound](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Hyperlink#getSound) และ [getBinaryData](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Audio#getBinaryData)

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("hyperlink-sound.pptx");
try {
    if (presentation.getSlides().size() > 0 && presentation.getSlides().get_Item(0).getShapes().size() > 0) {
        const hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick();
        const sound = hyperlink == null ? null : hyperlink.getSound();
        if (sound != null) {
            const audioData = sound.getBinaryData();
            console.log("Extracted " + audioData.length + " bytes of hyperlink audio.");
        } else {
            console.log("The first shape has no hyperlink sound.");
        }
    } else {
        console.log("The presentation has no first slide or shape to inspect.");
    }
} finally {
    presentation.dispose();
}
```

### **Tooltip และการตั้งค่าปฏิสัมพันธ์**

หลังจากกำหนดไฮเปอร์ลิงก์ให้กับข้อความหรือรูปร่าง คุณสามารถเรียกเมธอด [Hyperlink](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Hyperlink) ดังต่อไปนี้:

- [setTooltip](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Hyperlink#setTooltip) ตั้งข้อความที่ผู้ชมสามารถแสดงเป็นคำแนะนำสำหรับลิงก์
- [setTargetFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Hyperlink#setTargetFrame) ระบุเฟรมเป้าหมายภายในชุดเฟรม HTML ของพาเรนต์ (หากมี)
- [setHistory](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Hyperlink#setHistory) ควบคุมว่าการเปิดลิงก์จะเพิ่มตำแหน่งปลายทางไปยังรายการไฮเปอร์ลิงก์ที่เคยดูหรือไม่
- [setHighlightClick](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Hyperlink#setHighlightClick) ควบคุมว่าฮไฮเปอร์ลิงก์จะถูกเน้นเมื่อคลิกหรือไม่

## **ลบไฮเปอร์ลิงก์ออกจากงานนำเสนอ**

ใช้ [getAnyHyperlinks](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) เพื่อรวบรวมคอนเทนเนอร์ไฮเปอร์ลิงก์ รวมถึงลิงก์ส่วนข้อความ ก่อนทำการเปลี่ยนแปลง ตัวอย่างต่อไปลบทั้งสองประเภทการเปิดใช้งานจากสไลด์แรก หากต้องการลบเฉพาะประเภทใดประเภทหนึ่ง ให้เรียกเฉพาะ [removeHyperlinkClick](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) หรือ [removeHyperlinkMouseOver](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver) การลบการคลิกจะไม่ลบการเมาส์โอเวอร์ที่สอดคล้องกัน

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    if (presentation.getSlides().size() > 0) {
        const found = presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks();
        const containers = [];
        for (let index = 0; index < found.size(); index++) {
            containers.push(found.get_Item(index));
        }
        for (const container of containers) {
            container.getHyperlinkManager().removeHyperlinkClick();
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
        presentation.save("pres-removed-hyperlinks.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("The presentation has no slides to process.");
    }
} finally {
    presentation.dispose();
}
```

สำหรับการลบแบบไม่มีเงื่อนไข [removeAllHyperlinks](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) จะลบทั้งสองประเภทการเปิดใช้งานในสโคปที่เลือกในหนึ่งคำสั่ง สำหรับการทำความสะอาดแบบเลือกและครอบคลุมมาสเตอร์, เลย์เอาต์, และโน้ต ให้ดูที่ [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)

## **สร้างรายการตรวจสอบไฮเปอร์ลิงก์ครบถ้วน**

ก่อนเผยแพร่งานนำเสนอ ควรตรวจสอบการกระทำแบบโต้ตอบและลิงก์เว็บของมัน [getAnyHyperlinks](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) จะคืนค่าคอนเทนเนอร์ไฮเปอร์ลิงก์ ไม่ใช่รายการแบนของสตริง URL ตรวจสอบทั้ง [getHyperlinkClick](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Shape#getHyperlinkClick) และ [getHyperlinkMouseOver](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Shape#getHyperlinkMouseOver) บนแต่ละคอนเทนเนอร์ พวกมันเป็นอิสระกัน: คอนเทนเนอร์เดียวกันอาจเปิดให้ทำทั้งสองการกระทำ ดังนั้นรายงานครบถ้วนอาจต้องมีแถวสูงสุดสองแถวต่อคอนเทนเนอร์

การสแกนเฉพาะไฮเปอร์ลิงก์ระดับรูปร่างอาจพลาดลิงก์ที่แนบกับส่วนข้อความ ให้สืบค้นในสโคปที่เหมาะแทน แล้วเก็บคอนเทนเนอร์ที่คืนค่าไว้เพื่อที่คุณจะได้อัปเดตหรือลบการกระทำของมันภายหลัง

### **สืบค้นสโคปของงานนำเสนอ สไลด์ และกรอบข้อความ**

คลาส [HyperlinkQueries](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/HyperlinkQueries) สามารถเข้าถึงได้ผ่าน [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries), และ [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries) แต่ละสโคปสนับสนุนการสืบค้นเดียวกัน:

- [getHyperlinkClicks](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks) คืนค่าคอนเทนเนอร์ที่มีการคลิก
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers) คืนค่าคอนเทนเนอร์ที่มีการเมาส์โอเวอร์
- [getAnyHyperlinks](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) คืนค่าคอนเทนเนอร์ที่มีการกระทำอย่างใดอย่างหนึ่งหรือทั้งสอง

ตัวอย่างต่อไปสร้างไฟล์ `hyperlink-audit-input.pptx` ที่มีลิงก์คลิกภายนอก, ลิงก์เมาส์โอเวอร์ไฟล์, การนำทางสไลด์ภายใน, ลิงก์เมาส์โอเวอร์ข้อความ, และการกระทำแมโคร โดยไม่ทำการเรียกใช้การกระทำใด ๆ การสืบค้นทั้งสามทำงานที่ทุกสโคป; จำนวนที่แสดงเป็นจำนวนคอนเทนเนอร์ ไม่ใช่จำนวนการกระทำเอง กรอบข้อความจะยกเว้นลิงก์ของรูปร่างที่ล้อมรอบ

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

function printQueryCounts(scope, queries) {
const clickCount = queries.getHyperlinkClicks().size();
const mouseOverCount = queries.getHyperlinkMouseOvers().size();
const anyCount = queries.getAnyHyperlinks().size();
console.log(scope + ": click=" + clickCount + ", mouse-over=" + mouseOverCount + ", any=" + anyCount);
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide());
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Click the text to go to slide 2");
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/");
    shape.getHyperlinkClick().setTooltip("Public website");
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    const portionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.getHyperlinkManager().setInternalHyperlinkClick(destination);
    portionFormat.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help");
    const macroButton = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 120, 200, 60);
    macroButton.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation");

    printQueryCounts("Presentation", presentation.getHyperlinkQueries());
    printQueryCounts("Slide 1", slide.getHyperlinkQueries());
    printQueryCounts("Text frame", shape.getTextFrame().getHyperlinkQueries());
    presentation.save("hyperlink-audit-input.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

สำหรับตัวอย่างนี้ การสืบค้นระดับงานนำเสนอและสไลด์แต่ละอันรายงานคอนเทนเนอร์คลิกสามรายการ, คอนเทนเนอร์เมาส์โอเวอร์สองรายการ, และคอนเทนเนอร์ที่มีการกระทำใดอย่างหนึ่งสามรายการ ส่วนการสืบค้นระดับกรอบข้อความรายงานหนึ่งคอนเทนเนอร์ในแต่ละประเภท

### **จำแนกการกระทำและปลายทาง**

ใช้ [Hyperlink.getActionType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Hyperlink#getActionType) เพื่อแปลประเภทการกระทำก่อนแปลปลายทางค่า [HyperlinkActionType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/HyperlinkActionType) ครอบคลุมมากกว่าการนำทางเว็บ:

| ค่า | ความหมายสำหรับการตรวจสอบ |
| --- | --- |
| `Hyperlink` | ไฮเปอร์ลิงก์ภายนอก; ตรวจสอบ URL และสเค็มของมัน |
| `JumpSpecificSlide` | การนำทางภายในไปยังสไลด์เฉพาะ |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | การนำทางสไลด์ที่มาพร้อมโปรแกรม, แก้ไขตามบริบทการแสดงสไลด์ |
| `JumpEndShow`, `StartCustomSlideShow` | สิ้นสุดการแสดงปัจจุบันหรือเริ่มการแสดงแบบกำหนดเอง |
| `StartMacro` | เริ่มทำแมโคร |
| `StartProgram` | เรียกโปรแกรม |
| `OpenFile`, `OpenPresentation` | เปิดไฟล์หรือการนำเสนออื่น; ตรวจสอบแยกจาก URL เว็บ |
| `StartStopMedia` | เริ่มหรือหยุดการเล่นสื่อ |
| `NoAction`, `Unknown` | ไม่มีการนำทาง หรือการกระทำที่ไม่รู้จักต้องตรวจสอบ |

อ่านปลายทางภายนอกจาก [getExternalUrl](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) และปลายทางภายในเฉพาะจาก [getTargetSlide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Hyperlink#getTargetSlide) การกระทำภายในและคำสั่งในตัวอาจไม่มี URL ภายนอก; URL ว่างไม่หมายความว่าคอนเทนเนอร์ไม่มีการกระทำ อย่าลืมเก็บค่าที่คืนจาก [getExternalUrlOriginal](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Hyperlink#getExternalUrlOriginal) เมื่อแตกต่างจาก URL ที่ทำให้เป็นมาตรฐาน, และรวม tooltip จาก [getTooltip](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Hyperlink#getTooltip) หากมี

### **รายงาน ทำความสะอาด และตรวจสอบไฮเปอร์ลิงก์**

ตัวอย่าง JavaScript ต่อไปอ่านงานนำเสนอที่มีอยู่ (ใช้ไฟล์ที่สร้างด้านบน), เขียน `hyperlink-audit.json`, ใช้นโยบาย, บันทึก `hyperlink-sanitized.pptx`, แล้วเปิดใหม่เพื่อตรวจสอบทั้งสองประเภทการเปิดใช้งานอีกครั้ง ตัวอย่างจะรวบรวมคอนเทนเนอร์ก่อนทำการเปลี่ยนแปลงและใช้การเทียบค่าอ้างอิงเพื่อหลีกเลี่ยงการประมวลผลคอนเทนเนอร์ซ้ำ การสืบค้นงานนำเสนอครอบคลุมสไลด์ปกติ; สำหรับการตรวจสอบทั่วแพ็กเกจ จะสืบค้นมาสเตอร์, เลย์เอาต์, โน้ต, และมาสเตอร์ของโน้ตและแจกจ่ายเมื่อมี

รายงานบันทึกดัชนีสไลด์แบบหนึ่งฐานและ [getSlideId](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/BaseSlide#getSlideId) หากมี [getSlide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Shape#getSlide) จะให้สไลด์เจ้าของสำหรับคอนเทนเนอร์ที่รองรับ มาสเตอร์, เลย์เอาต์, และโน้ตไม่มีดัชนีสไลด์ปกติและจะระบุด้วยสโคปของมัน คอนเทนเนอร์รูปร่างและคอนเทนเนอร์การจัดรูปแบบส่วนข้อความจะถูกระบุแยกกัน; ประเภทคอนเทนเนอร์อื่นจะคงชื่อประเภทรันไทม์ของมันเอง แต่ละคอนเทนเนอร์จะได้รับ ID รายงานระดับท้องถิ่นเพื่อให้การกระทำสองอย่างสามารถเชื่อมโยงกันได้ รายงานจะเก็บประเภทการกระทำเป็นค่าคงที่จำนวนเต็มจากการนับของ `HyperlinkActionType`

นโยบายการใช้งานที่เข้มงวดนี้อนุญาตเฉพาะ URL HTTPS แบบเต็มและปลายทางสไลด์ภายในที่ถูกต้อง มันจะปฏิเสธแมโคร, โปรแกรม, การกระทำไฟล์, การกระทำสไลด์อื่น ๆ, การกระทำที่ไม่รู้จัก, และสเค็ม URL อื่น ๆ การปฏิเสธเหล่านี้เป็นการตัดสินใจของนโยบาย ไม่ใช่คำตัดสินด้านความปลอดภัยของ Aspose.Slides HTTPS เพียงอย่างเดียวไม่ทำให้เชื่อถือได้: ควรเพิ่มรายการอนุญาตโฮสต์และการตรวจสอบอื่น ๆ สำหรับแอปพลิเคชันของคุณ URL ภายนอกต้นฉบับและที่ทำให้เป็นมาตรฐานทั้งสองจะถูกตรวจสอบ ตัวอย่างตรวจสอบเมตาดาต้าโดยไม่เปิดลิงก์หรือรันการกระทำ

สำหรับการแก้ไข คอนเทนเนอร์ของ [getHyperlinkManager](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Shape#getHyperlinkManager) รองรับ [setExternalHyperlinkClick](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/HyperlinkManager#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) และ [removeHyperlinkMouseOver](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver) ที่นี่ลิงก์คลิกภายนอกที่ไม่ได้รับอนุญาตจะถูกแทนที่ด้วยหน้า Landing HTTPS คงที่; การคลิกที่ไม่ได้รับอนุญาตอื่น ๆ และการเมาส์โอเวอร์ที่ไม่ได้รับอนุญาตจะถูกลบแยกกัน ตั้งค่า `replaceExternalClicks` เป็น `false` เพื่อทำการลบทุกการละเมิดนโยบายแทน เลือกหน้าแทนที่ที่เป็นของแอปพลิเคชันก่อนการเผยแพร่

ธงการส่งออกของรายงานใช้การทบทวน PDF อย่างระมัดระวัง: ทำเครื่องหมายการกระทำเมาส์โอเวอร์และทุกอย่างที่ไม่ใช่ลิงก์ภายนอกหรือการกระโดดสไลด์เฉพาะว่าอาจไม่รองรับ มันเป็นเคล็ดลับการทบทวน ไม่ใช่การทดสอบความสามารถหรือการการันตีว่าลิงก์ที่ไม่มีเครื่องหมายจะคงอยู่ในการส่งออก การส่งออก PDF และ HTML ที่สนับสนุน ([PDF](/slides/th/nodejs-java/convert-powerpoint-to-pdf/) และ [HTML](/slides/th/nodejs-java/convert-powerpoint-to-html/)) อาจเก็บไฮเปอร์ลิงก์ไว้ขึ้นกับการกระทำ, ตัวเลือกการส่งออก, และโปรแกรมชมไฟล์ ภาพ raster ([images](/slides/th/nodejs-java/convert-powerpoint-to-png/)) และวิดีโอ ([video](/slides/th/nodejs-java/convert-powerpoint-to-video/)) ไม่สามารถเก็บไฮเปอร์ลิงก์แบบโต้ตอบได้; ควรทำเครื่องหมายทุกการกระทำเมื่อทำการตรวจสอบสำหรับผลลัพธ์เหล่านั้น

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

function slideIndex(presentation, slide) {
    if (slide == null) return null;
    for (let index = 0; index < presentation.getSlides().size(); index++) {
        if (presentation.getSlides().get_Item(index).equals(slide)) return index + 1;
    }
    return null;
}

function isHttps(value) {
    if (value == null || value.length === 0) return false;
    try {
        const uri = java.newInstanceSync("java.net.URI", value);
        const scheme = uri.getScheme();
        return uri.isAbsolute() && scheme != null && scheme.toLowerCase() === "https" && uri.getHost() != null;
    } catch (exception) {
        return false;
    }
}

function policyViolation(link) {
    if (link == null) return null;
    if (link.getActionType() === aspose.slides.HyperlinkActionType.JumpSpecificSlide) {
        return link.getTargetSlide() == null ? "Missing target slide" : null;
    }
    if (link.getActionType() !== aspose.slides.HyperlinkActionType.Hyperlink) return "Action is not allowed";
    if (!isHttps(link.getExternalUrl())) return "Normalized URL is not absolute HTTPS";
    const original = link.getExternalUrlOriginal();
    if (original != null && original.length > 0 && !isHttps(original)) return "Original URL is not absolute HTTPS";
    return null;
}

function collectContainers(presentation) {
    const found = [];
    function addQueries(queries) {
        const containers = queries.getAnyHyperlinks();
        for (let index = 0; index < containers.size(); index++) {
            found.push(containers.get_Item(index));
        }
    }
    function addScope(slide) {
        if (slide != null) addQueries(slide.getHyperlinkQueries());
    }
    addQueries(presentation.getHyperlinkQueries());
    for (let index = 0; index < presentation.getMasters().size(); index++) {
        addScope(presentation.getMasters().get_Item(index));
    }
    for (let index = 0; index < presentation.getLayoutSlides().size(); index++) {
        addScope(presentation.getLayoutSlides().get_Item(index));
    }
    for (let index = 0; index < presentation.getSlides().size(); index++) {
        addScope(presentation.getSlides().get_Item(index).getNotesSlideManager().getNotesSlide());
    }
    addScope(presentation.getMasterNotesSlideManager().getMasterNotesSlide());
    addScope(presentation.getMasterHandoutSlideManager().getMasterHandoutSlide());
    const seen = java.newInstanceSync("java.util.IdentityHashMap");
    const unique = [];
    for (const container of found) {
        if (!seen.containsKey(container)) {
            seen.put(container, true);
            unique.push(container);
        }
    }
    return unique;
}

function addRow(rows, presentation, link, activation, container, containerId) {
    if (link == null) return;
    const ownerSlide = java.instanceOf(container, "com.aspose.slides.ISlideComponent") ? container.getSlide() : null;
    const targetSlide = link.getTargetSlide();
    const violation = policyViolation(link);
    const ownerType = java.instanceOf(container, "com.aspose.slides.IShape") ? "Shape" : java.instanceOf(container, "com.aspose.slides.IPortionFormat") ? "Text portion" : container.getClass().getSimpleName();
    const ordinaryAction = link.getActionType() === aspose.slides.HyperlinkActionType.Hyperlink || link.getActionType() === aspose.slides.HyperlinkActionType.JumpSpecificSlide;
    rows.push({
        ContainerId: containerId,
        SlideIndex: slideIndex(presentation, ownerSlide),
        SlideId: ownerSlide == null ? null : ownerSlide.getSlideId(),
        Scope: ownerSlide == null ? null : ownerSlide.getClass().getSimpleName(),
        OwnerType: ownerType,
        Activation: activation,
        ActionType: link.getActionType(),
        ExternalUrl: link.getExternalUrl(),
        TargetSlideIndex: slideIndex(presentation, targetSlide),
        TargetSlideId: targetSlide == null ? null : targetSlide.getSlideId(),
        Tooltip: link.getTooltip(),
        OriginalExternalUrl: link.getExternalUrlOriginal() === link.getExternalUrl() ? null : link.getExternalUrlOriginal(),
        PotentiallyUnsafe: violation != null,
        PolicyViolation: violation,
        TargetExport: "PDF",
        PotentiallyUnsupportedByExport: activation === "mouse-over" || !ordinaryAction
    });
}

const replaceExternalClicks = true;
const replacementUrl = "https://example.com/blocked-link";
const presentation = new aspose.slides.Presentation("hyperlink-audit-input.pptx");
try {
    const containers = collectContainers(presentation);
    const rows = [];
    for (let index = 0; index < containers.length; index++) {
        const container = containers[index];
        addRow(rows, presentation, container.getHyperlinkClick(), "click", container, index + 1);
        addRow(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, index + 1);
    }
    const json = JSON.stringify(rows, null, 2);
    fs.writeFileSync("hyperlink-audit.json", json, "utf8");

    for (const container of containers) {
        const click = container.getHyperlinkClick();
        if (policyViolation(click) != null) {
            if (replaceExternalClicks && click.getActionType() === aspose.slides.HyperlinkActionType.Hyperlink) {
                container.getHyperlinkManager().setExternalHyperlinkClick(replacementUrl);
            } else {
                container.getHyperlinkManager().removeHyperlinkClick();
            }
        }
        if (policyViolation(container.getHyperlinkMouseOver()) != null) {
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
    }
    presentation.save("hyperlink-sanitized.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("hyperlink-sanitized.pptx");
    try {
        const remainingContainers = collectContainers(reopened);
        let violations = 0;
        for (const container of remainingContainers) {
            if (policyViolation(container.getHyperlinkClick()) != null) violations++;
            if (policyViolation(container.getHyperlinkMouseOver()) != null) violations++;
        }
        console.log("Audit rows: " + rows.length + "; prohibited actions after reopening: " + violations);
        if (violations !== 0) {
            console.log("Verification failed: do not distribute the saved presentation.");
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

ด้วยอินพุตที่สร้างข้างต้น รายงานมีห้าแถวการกระทำ ลิงก์เมาส์โอเวอร์ไฟล์และแมโครคลิกจะถูกลบ ส่วนลิงก์ HTTPS และการนำทางสไลด์ภายในยังคงอยู่ การตรวจสอบพิมพ์ศูนย์การกระทำที่ไม่ได้รับอนุญาต อินพุตที่มี URL คลิกภายนอกที่ไม่ได้รับอนุญาตจะทำให้สาขาการแทนที่ทำงาน คอนเทนเนอร์ที่มีคลิกที่ได้รับอนุญาตและเมาส์โอเวอร์ที่ไม่ได้รับอนุญาตจะเก็บคลิกไว้

การทำความสะอาดแบบเลือกนี้แตกต่างจาก [removeAllHyperlinks](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) ที่ลบทั้งสองประเภทการเปิดใช้งานในสโคปที่เลือกโดยไม่คำนึงถึงนโยบาย การตรวจสอบที่นี่ตรวจสอบการกระทำของไฮเปอร์ลิงก์เท่านั้น; ไม่ได้ลบโครงการ VBA ฝัง, วัตถุ OLE, หรือเนื้อหาแอคทีฟอื่น ๆ และไม่ได้ตรวจสอบไฟล์ PDF หรือ HTML ที่ส่งออก

## **FAQ**

**ฉันจะเชื่อมไปยังส่วนหรือสไลด์แรกของส่วนได้อย่างไร?**

ส่วนใน PowerPoint จะจัดกลุ่มสไลด์ แต่ไฮเปอร์ลิงก์ภายในจะชี้ไปยังสไลด์เดียว หากต้องการสร้างการนำทางไปยังส่วน ให้เชื่อมไปยังสไลด์แรกของส่วนนั้น

**ฉันสามารถแนบไฮเปอร์ลิงก์กับองค์ประกอบมาสเตอร์สไลด์เพื่อให้ทำงานบนทุกสไลด์ได้หรือไม่?**

ได้ มาสเตอร์สไลด์และองค์ประกอบเลย์เอาต์รองรับไฮเปอร์ลิงก์ ลิงก์บนองค์ประกอบเหล่านี้จะพร้อมใช้งานในโหมดสไลด์โชว์บนสไลด์ที่ใช้มาสเตอร์หรือเลย์เอาต์ที่สอดคล้องกัน

**ไฮเปอร์ลิงก์จะคงอยู่เมื่อส่งออกเป็น PDF, HTML, ภาพ หรือวิดีโอหรือไม่?**

การส่งออก PDF และ HTML ที่สนับสนุนอาจคงไฮเปอร์ลิงก์ไว้; ภาพ raster และวิดีโอไม่สามารถคงไฮเปอร์ลิงก์แบบโต้ตอบได้ ดูข้อควรพิจารณาการส่งออกใน [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)