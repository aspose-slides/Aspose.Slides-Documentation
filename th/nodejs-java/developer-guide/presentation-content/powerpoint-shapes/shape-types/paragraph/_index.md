---
title: รับขอบเขตของย่อหน้าในงานนำเสนอด้วย JavaScript
linktitle: ย่อหน้า
type: docs
weight: 60
url: /th/nodejs-java/paragraph/
keywords:
- ขอบเขตของย่อหน้า
- ขอบเขตของส่วนข้อความ
- พิกัดของย่อหน้า
- พิกัดของส่วน
- ขนาดของย่อหน้า
- ขนาดของส่วนข้อความ
- กรอบข้อความ
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีดึงขอบเขตของย่อหน้าและส่วนข้อความใน JavaScript ด้วย Aspose.Slides สำหรับ Node.js เพื่อเพิ่มประสิทธิภาพการวางตำแหน่งข้อความในงานนำเสนอ PowerPoint."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการรับค่าขอบเขต, ขนาด, และพิกัดของย่อหน้าและส่วนของข้อความใน Aspose.Slides. แสดงวิธีการดึงสี่เหลี่ยมของย่อหน้าใน `TextFrame` ด้วยการใช้ `getRect()`, วิธีการรับพิกัดของย่อหน้าและส่วนภายในกรอบข้อความของเซลล์ตาราง, และเน้นรายละเอียดสำคัญเช่นหน่วยวัด, ผลของการตัดบรรทัดต่อขอบเขต, การแปลงเป็นพิกเซล, และค่าการจัดรูปแบบย่อหน้าแบบมีประสิทธิภาพ.

## **รับพิกัดของย่อหน้าและส่วนใน TextFrame**
ด้วย Aspose.Slides for Node.js via Java นักพัฒนาสามารถรับพิกัดสี่เหลี่ยมของ Paragraph ภายในคอลเลกชันย่อหน้าของ TextFrame ได้แล้ว. นอกจากนี้ยังสามารถรับ [พิกัดของส่วน](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Portion#getCoordinates--) ภายในคอลเลกชันส่วนของย่อหน้าได้. ในหัวข้อนี้ เราจะสาธิตด้วยตัวอย่างว่าหากจะรับพิกัดสี่เหลี่ยมของย่อหน้าพร้อมตำแหน่งของส่วนภายในย่อหน้าอย่างไร.

```javascript
var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
var textFrame = shape.getTextFrame();
for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
    const paragraph = textFrame.getParagraphs().get_Item(i);
    for (let j = 0; j < paragraph.getPortions().getCount(); j++) {
        const portion = paragraph.getPortions().get_Item(j);
        var point = portion.getCoordinates();
    }
}
```

## **รับพิกัดสี่เหลี่ยมของ Paragraph**
โดยใช้เมธอด [**getRect()**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Paragraph#getRect--) นักพัฒนาสามารถรับสี่เหลี่ยมขอบเขตของย่อหน้าได้.

```javascript
var pres = new aspose.slides.Presentation("HelloWorld.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var textFrame = shape.getTextFrame();
    var rect = textFrame.getParagraphs().get_Item(0).getRect();
    console.log("X: " + rect.x + " Y: " + rect.y + " Width: " + rect.width + " Height: " + rect.height);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **รับขนาดของย่อหน้าและส่วนภายในกรอบข้อความของเซลล์ตาราง**
เพื่อรับขนาดและพิกัดของ [Portion](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Portion) หรือ [Paragraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Paragraph) ในกรอบข้อความของเซลล์ตาราง, คุณสามารถใช้เมธอด [Portion.getRect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Portion#getRect--) และ [Paragraph.getRect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Paragraph#getRect--) ได้.

ตัวอย่างโค้ดนี้สาธิตการทำงานที่อธิบายไว้:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var tbl = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var cell = tbl.getRows().get_Item(1).get_Item(1);
    var x = tbl.getX() + tbl.getRows().get_Item(1).get_Item(1).getOffsetX();
    var y = tbl.getY() + tbl.getRows().get_Item(1).get_Item(1).getOffsetY();
    
    for (let i = 0; i < cell.getTextFrame().getParagraphs().getCount(); i++) {
        const para = cell.getTextFrame().getParagraphs().get_Item(i);
        if (para.getText() === "") {
            continue;
        }
        var rect = para.getRect();
        var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, java.newFloat(rect.getX() + x), java.newFloat(rect.getY() + y), java.newFloat(rect.getWidth()), java.newFloat(rect.getHeight()));
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        for (let j = 0; j < para.getPortions().getCount(); j++) {
            const portion = para.getPortions().get_Item(j);
            if (portion.getText().includes("0")) {
                rect = portion.getRect();
                shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, java.newFloat(rect.getX() + x), java.newFloat(rect.getY() + y), java.newFloat(rect.getWidth()), java.newFloat(rect.getHeight()));
                shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            }
        }
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **คำถามที่พบบ่อย**

**พิกัดที่ส่งคืนสำหรับย่อหน้าและส่วนของข้อความมีหน่วยเป็นอะไร?**  
หน่วยเป็นพ้อยท์, โดยที่ 1 นิ้ว = 72 พ้อยท์. ค่าดังกล่าวใช้กับพิกัดและมิติทั้งหมดบนสไลด์.

**การตัดบรรทัดมีผลต่อขอบเขตของย่อหน้าหรือไม่?**  
ใช่. หาก [wrapping](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframeformat/setwraptext/) ถูกเปิดใช้งานใน [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/), ข้อความจะตัดเพื่อให้พอดีกับความกว้างของพื้นที่, ซึ่งทำให้ขอบเขตจริงของย่อหน้าเปลี่ยนแปลง.

**พิกัดของย่อหน้าสามารถแมปไปยังพิกเซลในภาพที่ส่งออกได้อย่างน่าเชื่อถือหรือไม่?**  
ใช่. แปลงพ้อยท์เป็นพิกเซลโดยใช้สูตร: pixels = points × (DPI / 72). ผลลัพธ์ขึ้นอยู่กับ DPI ที่เลือกสำหรับการเรนเดอร์/ส่งออก.

**จะรับพารามิเตอร์การจัดรูปแบบย่อหน้า “effective” อย่างไรโดยคำนึงถึงการสืบทอดสไตล์?**  
ใช้ [effective paragraph formatting data structure](/slides/th/nodejs-java/shape-effective-properties/); มันจะคืนค่าที่สรุปขั้นสุดท้ายสำหรับการเยื้อง, ระยะห่าง, การตัดบรรทัด, RTL, และอื่น ๆ.