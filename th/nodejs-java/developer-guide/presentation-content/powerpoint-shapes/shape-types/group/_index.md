---
title: กลุ่มรูปร่างการนำเสนอใน JavaScript
linktitle: กลุ่มรูปร่าง
type: docs
weight: 40
url: /th/nodejs-java/group/
keywords:
- กลุ่มรูปทรง
- กลุ่มรูปร่าง
- เพิ่มกลุ่ม
- ข้อความทางเลือก
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีจัดกลุ่มและยกเลิกการจัดกลุ่มรูปร่างในชุดสไลด์ PowerPoint ด้วย Aspose.Slides for Node.js via Java — คำแนะนำที่เร็วและเป็นขั้นตอนพร้อมโค้ด JavaScript ฟรี."
---
## **Overview**

บทความนี้อธิบายวิธีทำงานกับกลุ่มรูปร่างใน Aspose.Slides แสดงวิธีการเพิ่มกลุ่มรูปร่างลงในสไลด์ วางรูปร่างภายในกลุ่ม และบันทึกงานนำเสนอที่อัปเดต นอกจากนี้ยังสาธิตวิธีการเข้าถึงรูปร่างที่จัดเก็บอยู่ในกลุ่มและอ่านค่า `AlternativeText` ของพวกมัน อีกทั้งบทความยังครอบคลุมสรุปความสามารถที่เกี่ยวข้องกับกลุ่มรูปร่าง เช่น กลุ่มซ้อนกัน ลำดับ z‑order และตัวเลือกการล็อก

## **Add Group Shape**
Aspose.Slides รองรับการทำงานกับกลุ่มรูปร่างบนสไลด์ ฟีเจอร์นี้ช่วยให้นักพัฒนาสามารถสร้างงานนำเสนอที่หลากหลายยิ่งขึ้น Aspose.Slides for Node.js via Java รองรับการเพิ่มหรือเข้าถึงกลุ่มรูปร่าง สามารถเพิ่มรูปร่างลงในกลุ่มรูปร่างที่เพิ่มไว้เพื่อเติมเนื้อหา หรือเข้าถึงคุณสมบัติใด ๆ ของกลุ่มรูปร่าง เพื่อเพิ่มกลุ่มรูปร่างลงในสไลด์โดยใช้ Aspose.Slides for Node.js via Java:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)
1. รับอ้างอิงของสไลด์โดยใช้ Index ของมัน
1. เพิ่มกลุ่มรูปร่างลงในสไลด์
1. เพิ่มรูปร่างลงในกลุ่มรูปร่างที่เพิ่มไว้
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

ตัวอย่างด้านล่างจะแสดงการเพิ่มกลุ่มรูปร่างลงในสไลด์.

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation
var pres = new aspose.slides.Presentation();
try {
    // ดึงสไลด์แรก
    var sld = pres.getSlides().get_Item(0);
    // เข้าถึงคอลเลกชันของรูปร่างในสไลด์
    var slideShapes = sld.getShapes();
    // เพิ่มกลุ่มรูปร่างลงในสไลด์
    var groupShape = slideShapes.addGroupShape();
    // เพิ่มรูปร่างภายในกลุ่มรูปร่างที่เพิ่มไว้
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 300, 100, 100);
    // เพิ่มกรอบของกลุ่มรูปร่าง
    groupShape.setFrame(new aspose.slides.ShapeFrame(100, 300, 500, 40, aspose.slides.NullableBool.False, aspose.slides.NullableBool.False, 0));
    // เขียนไฟล์ PPTX ลงดิสก์
    pres.save("GroupShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Access AltText Property**
หัวข้อนี้แสดงขั้นตอนง่าย ๆ พร้อมตัวอย่างโค้ด สำหรับการเพิ่มกลุ่มรูปร่างและการเข้าถึงคุณสมบัติ AltText ของกลุ่มรูปร่างบนสไลด์ เพื่อเข้าถึง AltText ของกลุ่มรูปร่างในสไลด์โดยใช้ Aspose.Slides for Node.js via Java:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) ที่เป็นตัวแทนไฟล์ PPTX
1. รับอ้างอิงของสไลด์โดยใช้ Index ของมัน
1. เข้าถึงคอลเลกชันของรูปร่างบนสไลด์
1. เข้าถึงกลุ่มรูปร่าง
1. เรียกใช้คุณสมบัติ [getAlternativeText](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Shape#getAlternativeText--)

ตัวอย่างด้านล่างแสดงการเข้าถึงข้อความทางเลือกของกลุ่มรูปร่าง.

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
var pres = new aspose.slides.Presentation("AltText.pptx");
try {
    // ดึงสไลด์แรก
    var sld = pres.getSlides().get_Item(0);
    for (var i = 0; i < sld.getShapes().size(); i++) {
        // เข้าถึงคอลเลกชันของรูปร่างในสไลด์
        var shape = sld.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.GroupShape")) {
            // เข้าถึงกลุ่มรูปร่าง.
            var grphShape = shape;
            for (var j = 0; j < grphShape.getShapes().size(); j++) {
                var shape2 = grphShape.getShapes().get_Item(j);
                // เข้าถึงคุณสมบัติ AltText
                console.log(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**รองรับการจัดกลุ่มซ้อนกัน (กลุ่มภายในกลุ่ม) หรือไม่?**

ใช่. [GroupShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/groupshape/) มีเมธอด [getParentGroup](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/getparentgroup/) ซึ่งแสดงการสนับสนุนลำดับขั้นโดยตรง (กลุ่มหนึ่งสามารถเป็นลูกของกลุ่มอื่นได้).

**ฉันจะควบคุมลำดับ z‑order ของกลุ่มสัมพันธ์กับวัตถุอื่น ๆ บนสไลด์อย่างไร?**

ใช้เมธอด [getZOrderPosition](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/getzorderposition/) ของ [GroupShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/groupshape/) เพื่อพิจารณาตำแหน่งของมันในสต็กการแสดงผล.

**ฉันสามารถป้องกันการย้าย/แก้ไข/ยกเลิกการจัดกลุ่มได้หรือไม่?**

ใช่. ส่วนล็อกของกลุ่มเปิดให้เข้าถึงผ่าน [GroupShapeLock](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/groupshape/getgroupshapelock/) ซึ่งทำให้คุณสามารถจำกัดการดำเนินการบนวัตถุได้.