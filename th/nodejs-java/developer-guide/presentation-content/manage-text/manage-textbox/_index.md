---
title: จัดการกล่องข้อความในงานนำเสนอด้วย JavaScript
linktitle: จัดการกล่องข้อความ
type: docs
weight: 20
url: /th/nodejs-java/manage-textbox/
keywords:
- กล่องข้อความ
- กรอบข้อความ
- เพิ่มข้อความ
- อัปเดตข้อความ
- สร้างกล่องข้อความ
- ตรวจสอบกล่องข้อความ
- เพิ่มคอลัมน์ข้อความ
- เพิ่มไฮเปอร์ลิงก์
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides สำหรับ Node.js ทำให้การสร้าง แก้ไข และคัดลอกกล่องข้อความในไฟล์ PowerPoint และ OpenDocument เป็นเรื่องง่าย ช่วยปรับปรุงการทำงานอัตโนมัติของงานนำเสนอของคุณ."
---
## **คำนำ**

ข้อความในสไลด์มักอยู่ในกล่องข้อความหรือรูปทรง ดังนั้นเพื่อเพิ่มข้อความลงในสไลด์ คุณต้องเพิ่มกล่องข้อความแล้วใส่ข้อความลงในกล่องนั้น Aspose.Slides for Node.js via Java มีคลาส [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/AutoShape) ที่อนุญาตให้คุณเพิ่มรูปทรงที่มีข้อความได้

{{% alert title="Info" color="info" %}}
Aspose.Slides ยังมีคลาส [Shape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Shape) ที่ให้คุณเพิ่มรูปทรงลงในสไลด์ อย่างไรก็ตาม ไม่ใช่รูปทรงทั้งหมดที่สร้างด้วยคลาส `Shape` จะสามารถบรรจุข้อความได้ แต่รูปทรงที่สร้างด้วยคลาส [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/AutoShape) อาจมีข้อความได้
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
ดังนั้นเมื่อทำงานกับรูปทรงที่คุณต้องการเพิ่มข้อความ คุณควรตรวจสอบและยืนยันว่ารูปทรงนั้นถูกแคสต์ผ่านคลาส `AutoShape` เท่านั้นจึงจะสามารถทำงานกับ [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/TextFrame) ซึ่งเป็นคุณสมบัติของ `AutoShape` ได้ ดูส่วน [Update Text](https://docs.aspose.com/slides/th/nodejs-java/manage-textbox/#update-text) ในหน้านี้
{{% /alert %}}

## **สร้างกล่องข้อความบนสไลด์**

เพื่อสร้างกล่องข้อความบนสไลด์ ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแทนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)
2. รับอ้างอิงของสไลด์แรกในพรีเซนเทชันที่สร้างใหม่
3. เพิ่มอ็อบเจกต์ [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/AutoShape) ที่มี `ShapeType` ตั้งเป็น `Rectangle` ที่ตำแหน่งที่กำหนดบนสไลด์และรับอ้างอิงของอ็อบเจกต์ `AutoShape` ที่เพิ่มใหม่
4. เพิ่มคุณสมบัติ `TextFrame` ให้กับอ็อบเจกต์ `AutoShape` ที่จะบรรจุข้อความ ในตัวอย่างด้านล่าง เราเพิ่มข้อความนี้: *Aspose TextBox*
5. สุดท้าย เขียนไฟล์ PPTX ผ่านอ็อบเจกต์ `Presentation`

โค้ด JavaScript—ซึ่งเป็นการดำเนินการตามขั้นตอนข้างต้น—แสดงวิธีเพิ่มข้อความลงในสไลด์:

```javascript
// สร้างอินสแทนซ์ของ Presentation
var pres = new aspose.slides.Presentation();
try {
    // ดึงสไลด์แรกในพรีเซนเทชัน
    var sld = pres.getSlides().get_Item(0);
    // เพิ่ม AutoShape โดยตั้งประเภทเป็น Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // เพิ่ม TextFrame ให้กับ Rectangle
    ashp.addTextFrame(" ");
    // เข้าถึง TextFrame
    var txtFrame = ashp.getTextFrame();
    // สร้างอ็อบเจกต์ Paragraph สำหรับ TextFrame
    var para = txtFrame.getParagraphs().get_Item(0);
    // สร้างอ็อบเจกต์ Portion สำหรับ Paragraph
    var portion = para.getPortions().get_Item(0);
    // ตั้งค่าข้อความ
    portion.setText("Aspose TextBox");
    // บันทึกพรีเซนเทชันลงดิสก์
    pres.save("TextBox_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ตรวจสอบรูปทรงกล่องข้อความ**

Aspose.Slides มีเมธอด [isTextBox](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/#isTextBox) จากคลาส [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ที่ช่วยให้คุณตรวจสอบรูปทรงและระบุว่าเป็นกล่องข้อความหรือไม่

![Text box and shape](istextbox.png)

โค้ด JavaScript นี้แสดงวิธีตรวจสอบว่ารูปทรงถูกสร้างเป็นกล่องข้อความหรือไม่:

```javascript
var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    java.callStaticMethodSync("ForEach", "shape", presentation, (shape, slide, index) -> {
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            var autoShape = shape;
            console.log(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
        }
    });
} finally {
    presentation.dispose();
}
```

โปรดทราบว่า หากคุณเพียงเพิ่มออโต้เชปโดยใช้เมธอด `addAutoShape` จากคลาส [ShapeCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapecollection/) เมธอด `isTextBox` ของออโต้เชปจะคืนค่า `false` อย่างไรก็ตาม หลังจากคุณเพิ่มข้อความให้กับออโต้เชปโดยใช้เมธอด `addTextFrame` หรือเมธอด `setText` คุณสมบัติ `isTextBox` จะคืนค่า `true`

```javascript
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

## **เพิ่มคอลัมน์ในกล่องข้อความ**

Aspose.Slides มีเมธอด [setColumnCount](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) และ [setColumnSpacing](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/TextFrameFormat#setColumnSpacing-double-) จากคลาส [TextFrameFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/TextFrameFormat) ที่ช่วยให้คุณเพิ่มคอลัมน์ในกล่องข้อความ คุณสามารถกำหนดจำนวนคอลัมน์ในกล่องข้อความและตั้งค่าการเว้นระยะห่างเป็นจุดระหว่างคอลัมน์ได้

โค้ด JavaScript ด้านล่างแสดงการทำงานดังกล่าว:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // ดึงสไลด์แรกในพรีเซนเทชัน
    var slide = pres.getSlides().get_Item(0);
    // เพิ่ม AutoShape โดยตั้งประเภทเป็น Rectangle
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // เพิ่ม TextFrame ให้กับ Rectangle
    aShape.addTextFrame((("All these columns are limited to be within a single text container -- " + "you can add or delete text and the new or remaining text automatically adjusts ") + "itself to flow within the container. You cannot have text flow from one container ") + "to other though -- we told you PowerPoint's column options for text are limited!");
    // ดึงรูปแบบข้อความของ TextFrame
    var format = aShape.getTextFrame().getTextFrameFormat();
    // ระบุจำนวนคอลัมน์ใน TextFrame
    format.setColumnCount(3);
    // ระบุระยะห่างระหว่างคอลัมน์
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

Aspose.Slides for Node.js via Java มีเมธอด [setColumnCount](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) จากคลาส [TextFrameFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/TextFrameFormat) ที่ช่วยให้คุณเพิ่มคอลัมน์ใน Text Frame ผ่านคุณสมบัตินี้คุณสามารถกำหนดจำนวนคอลัมน์ที่ต้องการใน Text Frame ได้

โค้ด JavaScript นี้แสดงวิธีเพิ่มคอลัมน์ภายใน Text Frame:

```javascript
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
        java.callStaticMethodSync("Assert", "assertTrue", 2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", java.getStaticFieldValue("java.lang.Double", "NaN") == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
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
        java.callStaticMethodSync("Assert", "assertTrue", 2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", 20 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
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
        java.callStaticMethodSync("Assert", "assertTrue", 3 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", 15 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
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

Aspose.Slides อนุญาตให้คุณเปลี่ยนหรืออัปเดตข้อความที่อยู่ในกล่องข้อความหรือข้อความทั้งหมดในพรีเซนเทชัน

โค้ด JavaScript นี้สาธิตการดำเนินการที่อัปเดตหรือเปลี่ยนข้อความทั้งหมดในพรีเซนเทชัน:

```javascript
var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // ตรวจสอบว่ารูปทรงสนับสนุน TextFrame (IAutoShape) หรือไม่.
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                // วนซ้ำผ่านย่อหน้าใน TextFrame
                for (let j = 0; j < autoShape.getTextFrame().getParagraphs().getCount(); j++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(j);
                    // วนซ้ำผ่านแต่ละ Portion ในย่อหน้า
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

## **เพิ่มกล่องข้อความพร้อมไฮเปอร์ลิงก์** 

คุณสามารถแทรกลิงก์ภายในกล่องข้อความได้ เมื่อคลิกที่กล่องข้อความ ผู้ใช้จะถูกนำไปเปิดลิงก์

เพื่อเพิ่มกล่องข้อความที่มีลิงก์ ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแทนซ์ของคลาส `Presentation`
2. รับอ้างอิงของสไลด์แรกในพรีเซนเทชันที่สร้างใหม่
3. เพิ่มอ็อบเจกต์ `AutoShape` ที่มี `ShapeType` ตั้งเป็น `Rectangle` ที่ตำแหน่งที่กำหนดบนสไลด์และรับอ้างอิงของอ็อบเจกต์ AutoShape ที่เพิ่มใหม่
4. เพิ่ม `TextFrame` ให้กับอ็อบเจกต์ `AutoShape` โดยมีข้อความเริ่มต้นเป็น *Aspose TextBox*
5. สร้างอินสแทนซ์ของคลาส `HyperlinkManager`
6. กำหนดอ็อบเจกต์ `HyperlinkManager` ให้กับคุณสมบัติ [HyperlinkClick](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Shape#getHyperlinkClick--) ที่เชื่อมโยงกับส่วนที่คุณต้องการใน `TextFrame`
7. สุดท้าย เขียนไฟล์ PPTX ผ่านอ็อบเจกต์ `Presentation`

โค้ด JavaScript—ซึ่งเป็นการดำเนินการตามขั้นตอนข้างต้น—แสดงวิธีเพิ่มกล่องข้อความพร้อมไฮเปอร์ลิงก์ลงในสไลด์:

```javascript
// สร้างอินสแทนซ์ของคลาส Presentation ที่เป็นตัวแทนของ PPTX
var pres = new aspose.slides.Presentation();
try {
    // ดึงสไลด์แรกในพรีเซนเทชัน
    var slide = pres.getSlides().get_Item(0);
    // เพิ่มอ็อบเจกต์ AutoShape โดยตั้งประเภทเป็น Rectangle
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 150, 50);
    // แคสต์รูปทรงเป็น AutoShape
    var pptxAutoShape = shape;
    // เข้าถึงคุณสมบัติ ITextFrame ที่เชื่อมโยงกับ AutoShape
    pptxAutoShape.addTextFrame("");
    var textFrame = pptxAutoShape.getTextFrame();
    // เพิ่มข้อความบางส่วนลงในเฟรม
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");
    // ตั้งค่า Hyperlink ให้กับข้อความ Portion
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

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่างกล่องข้อความและตัวเก็บตำแหน่งข้อความเมื่อทำงานกับสไลด์แม่คืออะไร?**

[ตัวเก็บตำแหน่ง](/slides/th/nodejs-java/manage-placeholder/) สืบทอดรูปแบบ/ตำแหน่งจาก [แม่สไลด์](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/masterslide/) และสามารถถูกแทนที่ได้บน [เค้าโครง](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutslide/) ในขณะที่กล่องข้อความปกติเป็นอ็อบเจกต์อิสระบนสไลด์เฉพาะและจะไม่เปลี่ยนแปลงเมื่อคุณสลับเค้าโครง

**ฉันจะทำการแทนที่ข้อความจำนวนมากทั่วทั้งพรีเซนเทชันโดยไม่กระทบข้อความในแผนภูมิ ตาราง หรือ SmartArt ได้อย่างไร?**

จำกัดการวนลูปของคุณให้กับออโต้เชปที่มี Text Frame เท่านั้นและตัดวัตถุที่ฝังอยู่ ([แผนภูมิ](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chart/), [ตาราง](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/smartart/)) โดยแยกการเดินสำรวจคอลเลกชันของพวกมันออกจากกันหรือข้ามประเภทวัตถุเหล่านั้น