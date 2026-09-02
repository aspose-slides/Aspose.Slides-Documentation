---
title: "จัดการกล่องข้อความในงานนำเสนอด้วย JavaScript"
linktitle: "จัดการกล่องข้อความ"
type: docs
weight: 20
url: /th/nodejs-java/manage-textbox/
keywords:
- "กล่องข้อความ"
- "กรอบข้อความ"
- "เพิ่มข้อความ"
- "อัปเดตข้อความ"
- "สร้างกล่องข้อความ"
- "ตรวจสอบกล่องข้อความ"
- "เพิ่มคอลัมน์ข้อความ"
- "เพิ่มไฮเปอร์ลิงก์"
- "PowerPoint"
- "งานนำเสนอ"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Aspose.Slides สำหรับ Node.js ทำให้การสร้าง แก้ไข และคัดลอกกล่องข้อความในไฟล์ PowerPoint และ OpenDocument เป็นเรื่องง่าย ช่วยเพิ่มประสิทธิภาพการทำงานอัตโนมัติของงานนำเสนอของคุณ"
---
## **บทนำ**

ข้อความบนสไลด์มักจะอยู่ในกล่องข้อความหรือรูปทรง ดังนั้น เพื่อเพิ่มข้อความลงในสไลด์ คุณต้องเพิ่มกล่องข้อความและใส่ข้อความบางส่วนลงในกล่องนั้น Aspose.Slides for Node.js ผ่าน Java มีคลาส [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/AutoShape) ที่อนุญาตให้คุณเพิ่มรูปทรงที่มีข้อความได้.

{{% alert title="ข้อมูล" color="info" %}}

Aspose.Slides ยังมีคลาส [Shape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Shape) ที่อนุญาตให้คุณเพิ่มรูปทรงลงในสไลด์ อย่างไรก็ตาม รูปทรงทั้งหมดที่เพิ่มด้วยคลาส `Shape` ไม่สามารถเก็บข้อความได้ แต่รูปทรงที่เพิ่มด้วยคลาส [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/AutoShape) อาจมีข้อความได้.

{{% /alert %}}

{{% alert title="หมายเหตุ" color="warning" %}} 

ดังนั้น เมื่อทำงานกับรูปทรงที่ต้องการเพิ่มข้อความ คุณอาจต้องตรวจสอบและยืนยันว่ามันถูกแคสต์จากคลาส `AutoShape` เท่านั้นจึงจะสามารถทำงานกับ [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/TextFrame) ซึ่งเป็นคุณสมบัติของ `AutoShape` ได้ ดูส่วน [Update Text](https://docs.aspose.com/slides/th/nodejs-java/manage-textbox/#update-text) ในหน้านี้.

{{% /alert %}}

## **สร้างกล่องข้อความบนสไลด์**

เพื่อสร้างกล่องข้อความบนสไลด์ ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation).
2. รับอ้างอิงของสไลด์แรกในพรีเซนเทชันที่สร้างใหม่. 
3. เพิ่มอ็อบเจ็กต์ [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/AutoShape) ที่กำหนด `ShapeType` เป็น `Rectangle` ที่ตำแหน่งที่ระบุบนสไลด์และรับอ้างอิงของอ็อบเจ็กต์ `AutoShape` ที่เพิ่มใหม่.
4. เพิ่มคุณสมบัติ `TextFrame` ให้กับอ็อบเจ็กต์ `AutoShape` เพื่อเก็บข้อความ ตัวอย่างด้านล่างเราเพิ่มข้อความ: *Aspose TextBox*
5. สุดท้าย เขียนไฟล์ PPTX ผ่านอ็อบเจ็กต์ `Presentation`. 

โค้ด JavaScript นี้—การทำตามขั้นตอนข้างต้น—แสดงวิธีเพิ่มข้อความลงในสไลด์:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// สร้างอินสแทนซ์ Presentation
    // รับสไลด์แรกในพรีเซนเทชัน
    // เพิ่ม AutoShape ที่ประเภทตั้งเป็น Rectangle
    // เพิ่ม TextFrame ไปยัง Rectangle
    // เข้าถึง TextFrame
    // สร้างอ็อบเจ็กต์ Paragraph สำหรับ TextFrame
    // สร้างอ็อบเจ็กต์ Portion สำหรับ Paragraph
    // ตั้งค่าข้อความ
    // บันทึกพรีเซนเทชันลงดิสก์
var pres = new aspose.slides.Presentation();
try {
    // Gets the first slide in the presentation
    var sld = pres.getSlides().get_Item(0);
    // Adds an AutoShape with type set as Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // Adds TextFrame to the Rectangle
    ashp.addTextFrame(" ");
    // Accesses the text frame
    var txtFrame = ashp.getTextFrame();
    // Creates the Paragraph object for text frame
    var para = txtFrame.getParagraphs().get_Item(0);
    // Creates a Portion object for paragraph
    var portion = para.getPortions().get_Item(0);
    // Sets Text
    portion.setText("Aspose TextBox");
    // Saves the presentation to disk
    pres.save("TextBox_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ตรวจสอบรูปทรงกล่องข้อความ**

Aspose.Slides มีเมธอด [isTextBox](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/#isTextBox) จากคลาส [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ที่ช่วยให้คุณตรวจสอบรูปทรงและระบุว่ารูปทรงเป็นกล่องข้อความหรือไม่.

![กล่องข้อความและรูปทรง](istextbox.png)

โค้ด JavaScript นี้แสดงวิธีตรวจสอบว่ารูปทรงถูกสร้างเป็นกล่องข้อความหรือไม่:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (var slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        var slide = presentation.getSlides().get_Item(slideIndex);
        for (var shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            var shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                console.log(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

โปรดทราบว่าหากคุณเพิ่ม autoshape ด้วยเมธอด `addAutoShape` จากคลาส [ShapeCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapecollection/) เมธอด `isTextBox` ของ autoshape จะคืนค่า `false` อย่างไรก็ตาม หลังจากคุณเพิ่มข้อความลงใน autoshape ด้วยเมธอด `addTextFrame` หรือเมธอด `setText` คุณสมบัติ `isTextBox` จะคืนค่า `true`.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() คืนค่า false
shape1.addTextFrame("shape 1");
// shape1.isTextBox() คืนค่า true

var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() คืนค่า false
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() คืนค่า true

var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() คืนค่า false
shape3.addTextFrame("");
// shape3.isTextBox() คืนค่า false

var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() คืนค่า false
shape4.getTextFrame().setText("");
// shape4.isTextBox() คืนค่า false
```

## **ค้นหารูปทรงที่เป็นเจ้าของ Text Frame**

ในโค้ดการประมวลผลข้อความทั่วไป คุณอาจได้รับอ็อบเจ็กต์ [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) โดยไม่ทราบว่ามันอยู่ในพรีเซนเทชันใด ใช้วิธีการ [TextFrame.getParentShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/#getParentShape--) เพื่อกลับไปยัง [Shape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/) ที่เป็นเจ้าของ.

สำหรับ TextFrame ที่เป็นส่วนหนึ่งของ [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) หรือรูปทรงอื่นที่มีข้อความ [TextFrame.getParentShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/#getParentShape--) จะคืนค่าเจ้าของและ [TextFrame.getParentCell](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/#getParentCell--) จะคืนค่า `null` ทั้งสองเมธอดเป็นการนำทางแบบอ่านอย่างเดียว ดังนั้นการเรียกใช้จะไม่ได้เปลี่ยนแปลงเจ้าของ อย่าลืมตรวจสอบค่าที่คืนว่าเป็น `null` ก่อนเข้าถึงรูปทรง.

สำหรับตัวอย่างเต็มที่ระบุเจ้าของรูปทรงและเซลล์ตาราง รวมถึงรูปทรงที่เชื่อมกับโหนด SmartArt ดูที่ [Search and Replace Text](/slides/th/nodejs-java/search-and-replace-text/).

## **เพิ่มคอลัมน์ในกล่องข้อความ**

Aspose.Slides มีเมธอด [setColumnCount](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) และ [setColumnSpacing](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/TextFrameFormat#setColumnSpacing-double-) จากคลาส [TextFrameFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/TextFrameFormat) ที่อนุญาตให้คุณเพิ่มคอลัมน์ในกล่องข้อความ คุณสามารถกำหนดจำนวนคอลัมน์ในกล่องข้อความและตั้งค่าระยะห่างระหว่างคอลัมน์เป็นหน่วยพอยท์ได้.

โค้ด JavaScript นี้แสดงการดำเนินการตามที่อธิบาย:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // รับสไลด์แรกในพรีเซนเทชัน
    var slide = pres.getSlides().get_Item(0);
    // เพิ่ม AutoShape ที่ประเภทตั้งเป็น Rectangle
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // เพิ่ม TextFrame ไปยัง Rectangle
    aShape.addTextFrame((("All these columns are limited to be within a single text container -- " + "you can add or delete text and the new or remaining text automatically adjusts ") + "itself to flow within the container. You cannot have text flow from one container ") + "to other though -- we told you PowerPoint's column options for text are limited!");
    // รับรูปแบบข้อความของ TextFrame
    var format = aShape.getTextFrame().getTextFrameFormat();
    // กำหนดจำนวนคอลัมน์ใน TextFrame
    format.setColumnCount(3);
    // กำหนดระยะห่างระหว่างคอลัมน์
    format.setColumnSpacing(10);
    // บันทึกพรีเซนเทชัน
    pres.save("ColumnCount.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **เพิ่มคอลัมน์ใน Text Frame**

Aspose.Slides for Node.js ผ่าน Java มีเมธอด [setColumnCount](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) จากคลาส [TextFrameFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/TextFrameFormat) ที่ช่วยให้คุณเพิ่มคอลัมน์ใน Text Frame ผ่านคุณสมบัตินี้คุณสามารถกำหนดจำนวนคอลัมน์ที่ต้องการใน Text Frame ได้.

โค้ด JavaScript นี้แสดงวิธีเพิ่มคอลัมน์ภายใน Text Frame:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const assert = require("assert");

var outPptxFileName = "ColumnsTest.pptx";
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    var format = shape1.getTextFrame().getTextFrameFormat();
    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " + "you can add or delete text - and the new or remaining text automatically adjusts " + "itself to stay within the container. You cannot have text spill over from one container " + "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test.getSlides().get_Item(0).getShapes().get_Item(0);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 2);
        // ช่องว่างระหว่างคอลัมน์ไม่มีการตั้งค่าเลย จึงแสดงเป็น NaN.
        assert.ok(Number.isNaN(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing()));
    } finally {
        if (test != null) {
            test.dispose();
        }
    }
    format.setColumnSpacing(20);
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test1 = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test1.getSlides().get_Item(0).getShapes().get_Item(0);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 2);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing(), 20);
    } finally {
        if (test1 != null) {
            test1.dispose();
        }
    }
    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test2 = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test2.getSlides().get_Item(0).getShapes().get_Item(0);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 3);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing(), 15);
    } finally {
        if (test2 != null) {
            test2.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **อัปเดตข้อความ**

Aspose.Slides อนุญาตให้คุณเปลี่ยนหรืออัปเดตข้อความที่อยู่ในกล่องข้อความหรือข้อความทั้งหมดในพรีเซนเทชัน.

โค้ด JavaScript นี้แสดงการอัปเดตหรือเปลี่ยนข้อความทั้งหมดในพรีเซนเทชัน:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // ตรวจสอบว่ารูปทรงรองรับ TextFrame (IAutoShape) หรือไม่.
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                // วนรอบผ่านย่อหน้าภายใน TextFrame
                for (let j = 0; j < autoShape.getTextFrame().getParagraphs().getCount(); j++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(j);
                    // วนรอบผ่านแต่ละ Portion ในย่อหน้า
                    for (let k = 0; k < paragraph.getPortions().getCount(); k++) {
                        let portion = paragraph.getPortions().get_Item(k);
                        portion.setText(portion.getText().replace("years", "months"));// เปลี่ยนข้อความ
                        portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));// เปลี่ยนการจัดรูปแบบ
                    }
                }
            }
        }
    }
    // บันทึกพรีเซนเทชันที่แก้ไขแล้ว
    pres.save("text-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **เพิ่มกล่องข้อความพร้อมลิงก์** 

คุณสามารถแทรกลิงก์ภายในกล่องข้อความได้ เมื่อคลิกที่กล่องข้อความ ผู้ใช้จะถูกนำไปเปิดลิงก์นั้น. 

เพื่อเพิ่มกล่องข้อความที่มีลิงก์ ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส `Presentation`. 
2. รับอ้างอิงของสไลด์แรกในพรีเซนเทชันที่เพิ่งสร้าง. 
3. เพิ่มอ็อบเจ็กต์ `AutoShape` ที่กำหนด `ShapeType` เป็น `Rectangle` ที่ตำแหน่งที่ระบุบนสไลด์และรับอ้างอิงของอ็อบเจ็กต์ AutoShape ที่เพิ่มใหม่.
4. เพิ่ม `TextFrame` ให้กับอ็อบเจ็กต์ `AutoShape` และตั้งค่าข้อความของส่วนแรกของมัน ตัวอย่างด้านล่างเราใช้ข้อความ: *Aspose.Slides*
5. รับ `HyperlinkManager` ของส่วนนั้นผ่าน `PortionFormat` ของมัน.
6. เรียกใช้ `setExternalHyperlinkClick` บน `HyperlinkManager` เพื่อแนบลิงก์กับส่วนนั้น.
7. สุดท้าย เขียนไฟล์ PPTX ผ่านอ็อบเจ็กต์ `Presentation`. 

โค้ด JavaScript นี้—การทำตามขั้นตอนข้างต้น—แสดงวิธีเพิ่มกล่องข้อความพร้อมลิงก์ไปยังสไลด์:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของ PPTX
var pres = new aspose.slides.Presentation();
try {
    // รับสไลด์แรกในพรีเซนเทชัน
    var slide = pres.getSlides().get_Item(0);
    // เพิ่มอ็อบเจ็กต์ AutoShape ที่ประเภทตั้งเป็น Rectangle
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 150, 50);
    // แคสต์รูปทรงเป็น AutoShape
    var pptxAutoShape = shape;
    // เข้าถึงคุณสมบัติ ITextFrame ที่เชื่อมโยงกับ AutoShape
    pptxAutoShape.addTextFrame("");
    var textFrame = pptxAutoShape.getTextFrame();
    // เพิ่มข้อความบางส่วนลงในเฟรม
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");
    // ตั้งค่า Hyperlink สำหรับข้อความส่วน
    var hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");
    // บันทึกพรีเซนเทชัน PPTX
    pres.save("hLink_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**กล่องข้อความกับตัวจัดตำแหน่งข้อความ (placeholder) มีความแตกต่างอย่างไรเมื่อทำงานกับมาสเตอร์สไลด์?**

ตัวจัดตำแหน่ง (placeholder) สืบทอดสไตล์/ตำแหน่งจากมาสเตอร์และสามารถถูกแก้ไขได้บนเลย์เอาต์ต่าง ๆ ในขณะที่กล่องข้อความปกติเป็นอ็อบเจ็กต์อิสระบนสไลด์เฉพาะและจะไม่เปลี่ยนแปลงเมื่อคุณสลับเลย์เอาต์.

**ฉันจะทำการแทนที่ข้อความแบบกลุ่มทั่วทั้งพรีเซนเทชันโดยไม่กระทบข้อความภายในชาร์ต ตาราง และ SmartArt อย่างไร?**

จำกัดการวนซ้ำของคุณให้เฉพาะ auto‑shape ที่มี Text Frame และละเว้นอ็อบเจ็กต์ฝังรวม (เช่น [charts](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/smartart/)) โดยทำการเดินทางผ่านคอลเลกชันของพวกมันแยกกันหรือข้ามประเภทอ็อบเจ็กต์เหล่านั้น.