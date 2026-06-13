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
- จัดรูปแบบไฮเปอร์ลิงก์
- ลบไฮเปอร์ลิงก์
- อัปเดตไฮเปอร์ลิงก์
- ไฮเปอร์ลิงก์ข้อความ
- ไฮเปอร์ลิงก์สไลด์
- ไฮเปอร์ลิงก์รูปร่าง
- ไฮเปอร์ลิงก์รูปภาพ
- ไฮเปอร์ลิงก์วิดีโอ
- ไฮเปอร์ลิงก์ที่เปลี่ยนแปลงได้
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "จัดการไฮเปอร์ลิงก์ในงานนำเสนอ PowerPoint และ OpenDocument อย่างง่ายดายด้วย Aspose.Slides สำหรับ Node.js—เพิ่มการโต้ตอบและกระบวนการทำงานในไม่กี่นาที."
---
## **บทนำ**

ไฮเปอร์ลิงก์คือการอ้างอิงถึงวัตถุ ข้อมูล หรือสถานที่ในบางอย่าง ซึ่งพบได้บ่อยในงานนำเสนอ PowerPoint:

* ลิงก์ไปยังเว็บไซต์ภายในข้อความ, รูปร่าง หรือสื่อ
* ลิงก์ไปยังสไลด์

Aspose.Slides for Node.js via Java ช่วยให้คุณทำงานหลายอย่างที่เกี่ยวกับไฮเปอร์ลิงก์ในงานนำเสนอได้

{{% alert color="primary" %}} 
คุณอาจต้องการลองใช้ Aspose อย่างง่าย, [free online PowerPoint editor.](https://products.aspose.app/slides/th/editor)
{{% /alert %}} 

## **การเพิ่มไฮเปอร์ลิงก์ URL**

### **การเพิ่มไฮเปอร์ลิงก์ URL ให้กับข้อความ**

โค้ด JavaScript นี้แสดงวิธีเพิ่มไฮเปอร์ลิงก์เว็บไซต์ให้กับข้อความ:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape1 = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    shape1.addTextFrame("Aspose: File Format APIs");
    var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    portionFormat.setFontHeight(32);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

### **การเพิ่มไฮเปอร์ลิงก์ URL ให้กับรูปร่างหรือกรอบ**

โค้ดตัวอย่างใน JavaScript นี้แสดงวิธีเพิ่มไฮเปอร์ลิงก์เว็บไซต์ให้กับรูปร่าง:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50);
    shape.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **การเพิ่มไฮเปอร์ลิงก์ URL ให้กับสื่อ**

Aspose.Slides รองรับการเพิ่มไฮเปอร์ลิงก์ให้กับรูปภาพ, ไฟล์เสียง, และไฟล์วิดีโอ

ตัวอย่างโค้ดนี้แสดงวิธีเพิ่มไฮเปอร์ลิงก์ให้กับ **image**:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // เพิ่มรูปภาพลงในงานนำเสนอ
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(picture);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // สร้างกรอบรูปบนสไลด์ที่ 1 โดยอ้างอิงจากรูปที่เพิ่มไว้ก่อนหน้า
    var pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pictureFrame.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

ตัวอย่างโค้ดนี้แสดงวิธีเพิ่มไฮเปอร์ลิงก์ให้กับ **audio file**:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var audio = pres.getAudios().addAudio(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "audio.mp3")));
    var audioFrame = pres.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio);
    audioFrame.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    audioFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

ตัวอย่างโค้ดนี้แสดงวิธีเพิ่มไฮเปอร์ลิงก์ให้กับ **video**:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var video = pres.getVideos().addVideo(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "video.avi")));
    var videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);
    videoFrame.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    videoFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert  title="Tip"  color="primary"  %}} 
คุณอาจต้องการดู *[Manage OLE](/slides/th/nodejs-java/manage-ole/)*.
{{% /alert %}}

## **ใช้ไฮเปอร์ลิงก์เพื่อสร้างสารบัญ**

เนื่องจากไฮเปอร์ลิงก์ให้คุณเพิ่มการอ้างอิงถึงวัตถุหรือสถานที่ คุณจึงสามารถใช้มันสร้างสารบัญได้

ตัวอย่างโค้ดนี้แสดงวิธีสร้างสารบัญพร้อมไฮเปอร์ลิงก์:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var firstSlide = pres.getSlides().get_Item(0);
    var secondSlide = pres.getSlides().addEmptySlide(firstSlide.getLayoutSlide());
    var contentTable = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 100);
    contentTable.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    contentTable.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    contentTable.getTextFrame().getParagraphs().clear();
    var paragraph = new aspose.slides.Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    paragraph.setText("Title of slide 2 .......... ");
    var linkPortion = new aspose.slides.Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);
    paragraph.getPortions().add(linkPortion);
    contentTable.getTextFrame().getParagraphs().add(paragraph);
    pres.save("link_to_slide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **การจัดรูปแบบไฮเปอร์ลิงก์**

### **สี**

ด้วยเมธอด [setColorSource](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Hyperlink#setColorSource-int-) ในคลาส [Hyperlink](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Hyperlink) คุณสามารถตั้งค่าสีให้กับไฮเปอร์ลิงก์และยังดึงข้อมูลสีจากไฮเปอร์ลิงก์ได้ ฟีเจอร์นี้เริ่มต้นมาจาก PowerPoint 2019 ดังนั้นการเปลี่ยนแปลงที่เกี่ยวกับคุณสมบัตินี้จะไม่ส่งผลต่อเวอร์ชัน PowerPoint เก่า

ตัวอย่างโค้ดนี้สาธิตการเพิ่มไฮเปอร์ลิงก์หลายสีในสไลด์เดียวกัน:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 450, 50, false);
    shape1.addTextFrame("This is a sample of colored hyperlink.");
    var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setColorSource(aspose.slides.HyperlinkColorSource.PortionFormat);
    portionFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portionFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    var shape2 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 450, 50, false);
    shape2.addTextFrame("This is a sample of usual hyperlink.");
    shape2.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    pres.save("presentation-out-hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **การลบไฮเปอร์ลิงก์ในงานนำเสนอ**

### **การลบไฮเปอร์ลิงก์จากข้อความ**

โค้ด JavaScript นี้แสดงวิธีลบไฮเปอร์ลิงก์จากข้อความในสไลด์งานนำเสนอ:

```javascript
var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let slide = pres.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            // ตรวจสอบว่า shape รองรับ text frame (IAutoShape) หรือไม่.
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                var autoShape = shape;
                // วนรอบผ่านย่อหน้าใน text frame
                for (let i1 = 0; i1 < autoShape.getTextFrame().getParagraphs().getCount(); i1++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(i1);
                    // วนรอบผ่านแต่ละ portion ในย่อหน้า
                    for (let j1 = 0; j1 < paragraph.getPortions().getCount(); j1++) {
                        let portion = paragraph.getPortions().get_Item(j1)
                        portion.setText(portion.getText().replace("years", "months"));// เปลี่ยนข้อความ
                        portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));// เปลี่ยนการจัดรูปแบบ
                    }
                }
            }
        }
    }
    // บันทึกงานนำเสนอที่แก้ไขแล้ว
    pres.save("text-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **การลบไฮเปอร์ลิงก์จากรูปร่างหรือกรอบ**

โค้ด JavaScript นี้แสดงวิธีลบไฮเปอร์ลิงก์จากรูปร่างในสไลด์งานนำเสนอ:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        shape.getHyperlinkManager().removeHyperlinkClick();
    }
    pres.save("pres-removed-hyperlinks.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ไฮเปอร์ลิงก์ที่เปลี่ยนแปลงได้**

คลาส [Hyperlink](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Hyperlink) เป็น mutable โดยคุณสามารถแก้ไขค่าของคุณสมบัติต่าง ๆ ดังนี้:

- [Hyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Hyperlink#setTargetFrame-java.lang.String-)
- [Hyperlink.setTooltip(String value)](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Hyperlink#setTooltip-java.lang.String-)
- [Hyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Hyperlink#setHistory-boolean-)
- [Hyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Hyperlink#setHighlightClick-boolean-)
- [Hyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick-boolean-)

โค้ดส่วนนี้แสดงวิธีเพิ่มไฮเปอร์ลิงก์ลงในสไลด์และแก้ไข tooltip ภายหลัง:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    shape1.addTextFrame("Aspose: File Format APIs");
    var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    portionFormat.setFontHeight(32);
    pres.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **คุณสมบัติที่รองรับใน IHyperlinkQueries**

คุณสามารถเข้าถึง [HyperlinkQueries](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/HyperlinkQueries) จากงานนำเสนอ, สไลด์ หรือข้อความที่กำหนดไฮเปอร์ลิงก์ไว้

- [Presentation.getHyperlinkQueries()](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries--)
- [BaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries--)
- [TextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries--)

คลาส [HyperlinkQueries](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/HyperlinkQueries) รองรับเมธอดและคุณสมบัติดังต่อไปนี้:

- [HyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks--)
- [HyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers--)
- [HyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks--)
- [HyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks--)

## **คำถามที่พบบ่อย**

**ฉันจะสร้างการนำทางภายในไม่ใช่แค่สไลด์เดียว แต่เป็น “section” หรือสไลด์แรกของ section ได้อย่างไร?**  
Sections ใน PowerPoint คือการจัดกลุ่มสไลด์; การนำทางโดยเทคนิคจะชี้ไปที่สไลด์เฉพาะ เพื่อ “ไปยัง section” คุณมักจะลิงก์ไปยังสไลด์แรกของ section นั้น

**ฉันสามารถแนบไฮเปอร์ลิงก์กับองค์ประกอบของมาสเตอร์สไลด์เพื่อให้ทำงานบนสไลด์ทั้งหมดได้หรือไม่?**  
ได้ มาสเตอร์สไลด์และเลย์เอาต์รองรับไฮเปอร์ลิงก์ ลิงก์เหล่านี้จะแสดงบนสไลด์ลูกและสามารถคลิกได้ในระหว่างการแสดงสไลด์

**ไฮเปอร์ลิงก์จะถูกคงไว้เมื่อตัดออกเป็น PDF, HTML, รูปภาพ หรือวิดีโอหรือไม่?**  
ใน [PDF](/slides/th/nodejs-java/convert-powerpoint-to-pdf/) และ [HTML](/slides/th/nodejs-java/convert-powerpoint-to-html/) จะคงลิงก์ไว้ทั่วไป แต่เมื่อส่งออกเป็น [images](/slides/th/nodejs-java/convert-powerpoint-to-png/) และ [video](/slides/th/nodejs-java/convert-powerpoint-to-video/) ความสามารถในการคลิกจะไม่ถ่ายทอดต่อเนื่องเนื่องจากรูปแบบเหล่านั้นเป็นเฟรม/วิดีโอแบบเรสเตอร์ที่ไม่รองรับไฮเปอร์ลิงก์