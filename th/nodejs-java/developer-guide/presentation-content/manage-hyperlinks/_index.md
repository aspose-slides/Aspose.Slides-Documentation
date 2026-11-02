---
title: จัดการไฮเปอร์ลิงก์ของงานนำเสนอใน JavaScript
linktitle: จัดการไฮเปอร์ลิงก์
type: docs
weight: 20
url: /th/nodejs-java/manage-hyperlinks/
keywords:
- เพิ่ม URL
- เพิ่มไฮเปอร์ลิงก์
- สร้างไฮเปอร์ลิงก์
- จัดรูปแบบไฮเปอร์ลิงก์
- ลบไฮเปอร์ลิงก์
- อัปเดตไฮเปอร์ลิงก์
- ไฮเปอร์ลิงก์ข้อความ
- ไฮเปอร์ลิงก์สไลด์
- ไฮเปอร์ลิงก์รูปร่าง
- ไฮเปอร์ลิงก์รูปภาพ
- ไฮเปอร์ลิงก์วิดีโอ
- ไฮเปอร์ลิงก์ที่ปรับเปลี่ยนได้
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เพิ่ม, จัดรูปแบบ, อัปเดตและลบไฮเปอร์ลิงก์ในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java โดยใช้ตัวอย่าง JavaScript"
---
## **บทนำ**

Hyperlink เชื่อมต่อเนื้อหาการนำเสนอไปยังเว็บไซต์หรือตำแหน่งภายในงานนำเสนอ ใน PowerPoint Hyperlink มักใช้เพื่อสองวัตถุประสงค์:

* เปิดเว็บไซต์จากข้อความ, รูปร่าง หรือกรอบสื่อ
* นำทางไปยังสไลด์อื่น, ตัวอย่างเช่น จากสารบัญ

Aspose.Slides for Node.js via Java ให้คุณเพิ่มลิงก์เหล่านี้, ควบคุมลักษณะและเสียง, ปรับปรุงคุณสมบัติ, และลบออก ตัวอย่างด้านล่างแสดงวิธีทำงานกับ Hyperlink บนแต่ละองค์ประกอบและวิธีเข้าถึง Hyperlink ระดับงานนำเสนอ, สไลด์, หรือกรอบข้อความ

{{% alert color="info" title="Note" %}}
คุณยังสามารถแก้ไขงานนำเสนอด้วย [ฟรีออนไลน์ Aspose PowerPoint editor](https://products.aspose.app/slides/editor)
{{% /alert %}} 

## **เพิ่ม URL ไฮเปอร์ลิงก์**

คุณสามารถกำหนด URL เว็บไซต์ให้กับข้อความ, รูปร่าง, หรือกรอบสื่อได้ พื้นที่กดคลิกจะขึ้นกับองค์ประกอบที่คุณกำหนด Hyperlink : ส่วนของข้อความจะเชื่อมต่อข้อความที่เลือก, ในขณะที่รูปร่างหรือกรอบจะเชื่อมต่อกับวัตถุสไลด์

สำหรับงานนำเสนอที่มี Hyperlink แบบสัมพันธ์, ดูที่ [Manage the Hyperlink Base](/slides/th/nodejs-java/presentation-properties/#manage-the-hyperlink-base) เพื่ออ่าน, แก้ไข, หรือเคลียร์ฐานระดับเอกสาร

### **เพิ่ม URL ไฮเปอร์ลิงก์ให้กับข้อความ**

ในการเชื่อมข้อความไปยังเว็บไซต์, ส่งค่า [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) ไปยังเมธอด [setHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PortionFormat#setHyperlinkClick) ของส่วนข้อความตามที่แสดงด้านล่าง เพียงส่วนข้อความนั้นเท่านั้นที่จะกดคลิกได้

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

### **เพิ่ม URL ไฮเปอร์ลิงก์ให้กับรูปร่างและกรอบสื่อ**

เพื่อทำให้รูปร่างหรือกรอบกดคลิกได้, เรียกเมธอด [setHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setHyperlinkClick) ของมัน Hyperlink จะเป็นของวัตถุเอง ไม่ได้เป็นของส่วนข้อความภายใน

แนวทางเดียวกันใช้ได้กับกรอบรูป, เสียง, และวิดีโอ: กำหนด Hyperlink ให้กับกรอบและเรียก [setTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTooltip) หากต้องการ

ตัวอย่างต่อไปทำให้สี่เหลี่ยมกดคลิกได้:

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

## **ใช้ Hyperlink สร้างสารบัญ**

Hyperlink ภายในทำให้ผู้อ่านกระโดดจากสารบัญไปยังสไลด์ที่กำหนด ตัวอย่างต่อไปใช้ [setInternalHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#setInternalHyperlinkClick) เพื่อลิงก์ข้อความ “Page 2” บนสไลด์แรกไปยังสไลด์ที่สอง

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

## **จัดรูปแบบ Hyperlink**

### **สี**

เมธอด [setColorSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setColorSource) ของ [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) กำหนดว่า Hyperlink จะใช้สี Hyperlink ของงานนำเสนอหรือการฟอร์แมตของส่วนข้อความหรือไม่ เพื่อใช้สีข้อความกำหนดเอง ให้เลือก [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkColorSource) และตั้งค่าสีเติมของส่วนนี้ ฟีเจอร์นี้เริ่มต้นจาก PowerPoint 2019; เวอร์ชันเก่าจะไม่ใช้การตั้งค่านี้

ตัวอย่างต่อไปเพิ่ม Hyperlink ข้อความสองอันในสไลด์เดียว อันแรกใช้สีเติมข้อความสีแดง, ส่วนที่สองใช้สี Hyperlink เริ่มต้น

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

Hyperlink สามารถเล่นเสียงเมื่อเปิดใช้งาน หรือหยุดเสียงที่กำลังเล่นอยู่ ใช้เมธอดต่อไปนี้เพื่อกำหนดพฤติกรรม:

- [Hyperlink.setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setSound) ระบุไฟล์เสียงที่เชื่อมกับ Hyperlink
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick) ควบคุมว่าการเปิด Hyperlink จะหยุดเสียงก่อนหน้าหรือไม่

#### **เพิ่มเสียงให้กับ Hyperlink**

ตัวอย่างต่อไปโหลด `sampleaudio.wav` แล้วเชื่อมกับปุ่มบนสไลด์แรก การคลิกปุ่มจะเล่นเสียงและไปสไลด์ถัดไป รูปร่างอื่นบนสไลด์นั้นจะหยุดเสียงก่อนหน้าเมื่อคลิกโดยไม่มีการนำทาง

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

#### **ดึงเสียงจาก Hyperlink**

ตัวอย่างต่อไปเปิดงานนำเสนอที่สร้างข้างต้นและอ่านเสียง Hyperlink ของรูปร่างแรกเข้าสู่หน่วยความจำผ่าน [getSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getSound) และ [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Audio#getBinaryData)

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

### **คำอธิบายและการตั้งค่าการโต้ตอบ**

คุณสามารถเรียกเมธอดของ [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) เหล่านี้หลังจากกำหนด Hyperlink ให้กับข้อความหรือรูปร่าง:

- [setTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTooltip) ตั้งข้อความแนะนำที่ผู้ชมสามารถมองเห็นเป็นคำชี้แนะสำหรับลิงก์
- [setTargetFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTargetFrame) ระบุเฟรมเป้าหมายภายในชุดเฟรม HTML ของพาเรนต์, เมื่อมีความเกี่ยวข้อง
- [setHistory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setHistory) ควบคุมว่าการเปิดลิงก์จะเพิ่มปลายทางลงในรายการ Hyperlink ที่เคยดูหรือไม่
- [setHighlightClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setHighlightClick) ควบคุมว่าการคลิก Hyperlink จะทำให้ไฮไลท์หรือไม่

## **ลบ Hyperlink จากงานนำเสนอ**

ใช้ [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) เพื่อรวบรวมคอนเทนเนอร์ของ Hyperlink รวมถึงลิงก์ส่วนข้อความ ก่อนทำการเปลี่ยนแปลง ตัวอย่างต่อไปลบประเภทการเปิดใช้งานทั้งสองจากสไลด์แรก เพื่อลบเพียงประเภทเดียวให้เรียกเฉพาะ [removeHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) หรือ [removeHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver); การลบการคลิกจะไม่ลบการโฮเวอร์

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

สำหรับการลบโดยไม่มีเงื่อนไข, [removeAllHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) จะลบประเภทการเปิดใช้งานทั้งสองในขอบเขตที่เลือกในหนึ่งคำสั่ง สำหรับการทำความสะอาดแบบเลือกและครอบคลุม masters, layouts, และ notes ให้ดูที่ [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)

## **สร้างรายการตรวจสอบ Hyperlink แบบสมบูรณ์**

ก่อนแจกจ่ายงานนำเสนอ, ควรทำรายการตรวจสอบการกระทำเชิงโต้ตอบและลิงก์เว็บทั้งหมด [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) จะคืนคอนเทนเนอร์ของ Hyperlink ไม่ใช่รายการ URL แบน ตรวจสอบทั้ง [getHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkClick) และ [getHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkMouseOver) บนแต่ละคอนเทนเนอร์ พวกมันเป็นอิสระ: คอนเทนเนอร์เดียวกันสามารถเปิดใช้งานทั้งสองการกระทำได้ ดังนั้นรายงานสมบูรณ์อาจต้องมีแถวสูงสุดสองแถวต่อคอนเทนเนอร์

การสแกนเฉพาะ Hyperlink ระดับรูปร่างอาจพลาดลิงก์ที่แนบกับส่วนข้อความ ให้สอบถามขอบเขตที่เหมาะสมแทนและเก็บคอนเทนเนอร์ที่คืนค่ามาไว้เพื่อที่จะอัปเดตหรือเอาการกระทำออกในภายหลัง

### **สอบถามขอบเขต Presentation, Slide, และ Text‑Frame**

คลาส [HyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries) สามารถเรียกได้ผ่าน [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries), และ [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries) แต่ละขอบเขตสนับสนุนการสอบถามเดียวกัน:

- [getHyperlinkClicks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks) คืนคอนเทนเนอร์ที่มีการกระทำคลิก
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers) คืนคอนเทนเนอร์ที่มีการกระทำโฮเวอร์
- [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) คืนคอนเทนเนอร์ที่มีการกระทำใด ๆ หรือทั้งสองอย่าง

ตัวอย่างต่อไปสร้างไฟล์ `hyperlink-audit-input.pptx` พร้อมลิงก์คลิกภายนอก, ลิงก์โฮเวอร์ไฟล์, การนำทางสไลด์ภายใน, ลิงก์โฮเวอร์ข้อความ, และการกระทำแมโคร ตัวอย่างไม่ได้เรียกใช้การกระทำใด ๆ ทั้งหมด การสอบถามสามประเภททำงานได้ที่ทุกขอบเขต; จำนวนที่แสดงเป็นจำนวนคอนเทนเนอร์ ไม่ใช่จำนวนการกระทำ ขอบเขต Text‑Frame จะไม่รวมลิงก์ของรูปร่างที่บรรจุอยู่

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

สำหรับตัวอย่างนี้, การสอบถามระดับ Presentation และ Slide แสดงคอนเทนเนอร์คลิกสามรายการ, คอนเทนเนอร์โฮเวอร์สองรายการ, และคอนเทนเนอร์ที่มีการกระทำใด ๆ ก็ตามสามรายการ ขอบเขต Text‑Frame แสดงคอนเทนเนอร์หนึ่งรายการในแต่ละประเภท

### **จำแนกประเภทการกระทำและปลายทาง**

ใช้ [Hyperlink.getActionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getActionType) เพื่อแปลความหมายของการกระทำก่อนแปลความหมายของปลายทาง ค่าของ [HyperlinkActionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkActionType) ครอบคลุมมากกว่าการนำทางเว็บ:

| Values | Meaning for an audit |
| --- | --- |
| `Hyperlink` | Hyperlink ภายนอก; ตรวจสอบ URL และสคีม |
| `JumpSpecificSlide` | การนำทางภายในไปยังสไลด์ที่ระบุ |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | การนำทางสไลด์โชว์ที่สร้างขึ้นโดยอัตโนมัติ, ทำงานในบริบทของการสไลด์โชว์ |
| `JumpEndShow`, `StartCustomSlideShow` | สิ้นสุดการแสดงปัจจุบันหรือเริ่มการแสดงแบบกำหนดเอง |
| `StartMacro` | เรียกใช้แมโคร |
| `StartProgram` | เปิดโปรแกรม |
| `OpenFile`, `OpenPresentation` | เปิดไฟล์หรือการนำเสนออื่น; แยกตรวจสอบจาก URL เว็บ |
| `StartStopMedia` | เริ่มหรือหยุดการเล่นสื่อ |
| `NoAction`, `Unknown` | ไม่มีการนำทาง, หรือการกระทำที่ไม่รู้จักต้องตรวจสอบ |

อ่านปลายทางภายนอกจาก [getExternalUrl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) และปลายทางภายในเฉพาะจาก [getTargetSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getTargetSlide) การกระทำภายในและคำสั่งในตัวอาจไม่มี URL ภายนอก; URL ว่างไม่หมายความว่าคอนเทนเนอร์ไม่มีการกระทำ ให้เก็บค่าที่คืนจาก [getExternalUrlOriginal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrlOriginal) เมื่อแตกต่างจาก URL ที่ทำให้เป็นมาตรฐานและรวมคำอธิบายจาก [getTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getTooltip) หากมี

### **Report, Sanitize, and Verify Hyperlinks**

ตัวอย่าง JavaScript ต่อไปอ่านงานนำเสนอที่มีอยู่ (ใช้ไฟล์ที่สร้างข้างต้น), เขียน `hyperlink-audit.json`, ใช้นโยบาย, บันทึก `hyperlink-sanitized.pptx`, แล้วเปิดใหม่เพื่อตรวจสอบประเภทการกระทำทั้งสองอีกครั้ง จะรวบรวมคอนเทนเนอร์ก่อนทำการเปลี่ยนแปลงและใช้การเทียบค่าด้วยการอ้างอิงเพื่อหลีกเลี่ยงการประมวลผลคอนเทนเนอร์เดียวกันสองครั้ง การสอบถามระดับงานนำเสนอครอบคลุมสไลด์ปกติ; สำหรับการตรวจสอบระดับแพ็กเกจทั้งหมดยังสอบถาม masters, layouts, notes, และ notes & handout masters เมื่อมีอยู่

รายงานบันทึกดัชนีสไลด์แบบหนึ่ง‑ฐานและ [getSlideId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getSlideId) หากมี [getSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getSlide) ให้สไลด์เจ้าของสำหรับคอนเทนเนอร์ที่รองรับ Masters, layouts, และ notes ไม่มีดัชนีสไลด์ปกติและจะระบุด้วยขอบเขตของมันเอง คอนเทนเนอร์รูปร่างและคอนเทนเนอร์ฟอร์แมตส่วนข้อความจะมีป้ายแยกกัน; ประเภทคอนเทนเนอร์อื่นจะเก็บชื่อประเภทในเวลารัน รายการแต่ละคอนเทนเนอร์จะได้รับ ID เฉพาะในรายงานเพื่อให้การกระทำทั้งสองสามารถเชื่อมโยงกันได้ รายงานเก็บประเภทการกระทำเป็นค่าคงที่จำนวนเต็มจากการกำหนดค่า HyperlinkActionType

นโยบายแอปพลิเคชันที่เข้มงวดนี้อนุญาตเพียง URL HTTPS แบบเต็มและเป้าหมายสไลด์ภายในที่ถูกต้อง จะปฏิเสธแมโคร, โปรแกรม, การกระทำไฟล์, การกระทำสไลด์โชว์อื่น ๆ, การกระทำที่ไม่รู้จัก, และสคีม URL อื่น ๆ การปฏิเสธเป็นการตัดสินใจของนโยบาย ไม่ใช่การตัดสินความปลอดภัยของ Aspose.Slides HTTPS อย่างเดียวไม่เพียงพอ: ควรเพิ่มรายการอนุญาตโฮสต์และการตรวจสอบอื่น ๆ สำหรับแอปของคุณ ทั้ง URL ภายนอกดั้งเดิมและที่ทำให้เป็นมาตรฐานจะถูกตรวจสอบ ตัวอย่างทำการตรวจสอบเมตาดาต้าโดยไม่เปิดลิงก์หรือเรียกการกระทำ

สำหรับการแก้ไข, คอนเทนเนอร์ [getHyperlinkManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkManager) รองรับ [setExternalHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick), และ [removeHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver) ที่นี่ ลิงก์คลิกภายนอกที่ไม่ได้รับอนุญาตจะถูกแทนที่ด้วยหน้า HTTPS คงที่; การคลิกที่ไม่ได้รับอนุญาตและการกระทำโฮเวอร์ที่ไม่ได้รับอนุญาตอื่น ๆ จะถูกลบแยกกัน ตั้งค่า `replaceExternalClicks` เป็น `false` เพื่อเอาการละเมิดนโยบายทั้งหมดออก เลือกหน้าทดแทนที่เป็นของแอปก่อนการปรับใช้

ค่าสธนของการส่งออกในรายงานใช้แนวนโยบายรีวิว PDF เชิงรหัส: ทำเครื่องหมายการกระทำโฮเวอร์และสิ่งใด ๆ ที่ไม่ใช่ลิงก์ภายนอกหรือการกระโดดสไลด์เฉพาะว่าอาจไม่รองรับ เป็นคำแนะนำการรีวิว ไม่ใช่การทดสอบความสามารถหรือการรับประกันว่าลิงก์ที่ไม่ได้ทำเครื่องหมายจะคงอยู่ การส่งออก [PDF](/slides/th/nodejs-java/convert-powerpoint-to-pdf/) และ [HTML](/slides/th/nodejs-java/convert-powerpoint-to-html/) ที่รองรับอาจคง Hyperlink ไว้ ขึ้นอยู่กับการกระทำ, ตัวเลือกการส่งออก, และผู้ดูภาพ ส่วน [images](/slides/th/nodejs-java/convert-powerpoint-to-png/) และ [video](/slides/th/nodejs-java/convert-powerpoint-to-video/) ไม่สามารถคง Hyperlink เชิงโต้ตอบได้; ควรทำเครื่องหมายทุกการกระทำเมื่อทำการตรวจสอบเพื่อเอาท์พุตเหล่านั้น

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

ด้วยอินพุตที่สร้างข้างต้น, รายงานมีแถวการกระทำห้ารายการ ลิงก์ไฟล์โฮเวอร์และแมโครคลิกถูกลบ ขณะที่ลิงก์ HTTPS และการนำทางสไลด์ภายในยังคงอยู่ การตรวจสอบจะแสดงศูนย์การกระทำที่ถูกห้าม อินพุตที่มี URL คลิกภายนอกที่ห้ามจะทำให้สาขาการแทนที่ทำงาน คอนเทนเนอร์ที่มีคลิกที่อนุญาตและโฮเวอร์ที่ห้ามจะเก็บคลิกไว้

การทำความสะอาดแบบเลือกนี้แตกต่างจาก [removeAllHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) ซึ่งลบการกระทำทั้งสองในขอบเขตที่เลือกโดยไม่คำนึงถึงนโยบาย การตรวจสอบที่นี่ตรวจสอบการกระทำของ Hyperlink เท่านั้น; ไม่ลบโครงการ VBA ฝัง, วัตถุ OLE, หรือเนื้อหาแอคทีฟอื่น ๆ, และไม่ตรวจสอบไฟล์ PDF หรือ HTML ที่ส่งออก

## **คำถามที่พบบ่อย**

**ฉันจะเชื่อมโยงไปยังส่วนหรือสไลด์แรกของมันได้อย่างไร?**

ส่วนใน PowerPoint จะจัดกลุ่มสไลด์, แต่ Hyperlink ภายในจะชี้ไปยังสไลด์เดี่ยว เพื่อสร้างการนำทางไปยังส่วน, ให้เชื่อมไปยังสไลด์แรกของส่วนนั้น

**ฉันสามารถผูก Hyperlink กับองค์ประกอบของมาสเตอร์สไลด์เพื่อให้ทำงานบนทุกสไลด์ได้หรือไม่?**

ได้ มาสเตอร์สไลด์และองค์ประกอบของเลเอาต์รองรับ Hyperlink ลิงก์บนองค์ประกอบเหล่านี้จะพร้อมใช้งานขณะแสดงสไลด์บนสไลด์ที่ใช้มาสเตอร์หรือเลเอาต์นั้น

**Hyperlink จะคงอยู่เมื่อส่งออกเป็น PDF, HTML, ภาพ หรือวิดีโอหรือไม่?**

การส่งออก PDF และ HTML ที่รองรับอาจคง Hyperlink ไว้; ภาพเรสเตอร์และวิดีโอไม่สามารถคง Hyperlink เชิงโต้ตอบได้ ดูข้อควรพิจารณาการส่งออกใน [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)