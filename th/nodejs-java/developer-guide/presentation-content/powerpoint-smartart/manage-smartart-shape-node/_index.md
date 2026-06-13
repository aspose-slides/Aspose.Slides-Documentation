---
title: จัดการโนดรูปร่าง SmartArt ในงานพรีเซนเทชันด้วย JavaScript
linktitle: โนดรูปร่าง SmartArt
type: docs
weight: 30
url: /th/nodejs-java/manage-smartart-shape-node/
keywords:
- โนด SmartArt
- โนดลูก
- เพิ่มโนด
- ตำแหน่งโนด
- เข้าถึงโนด
- ลบโนด
- ตำแหน่งกำหนดเอง
- โนดผู้ช่วย
- รูปแบบการเติม
- เรนเดอร์โนด
- PowerPoint
- พรีเซนเทชัน
- Node.js
- JavaScript
- Aspose.Slides
description: "จัดการโนดรูปร่าง SmartArt ในไฟล์ PPT และ PPTX ด้วย Aspose.Slides สำหรับ Node.js. รับตัวอย่างโค้ด JavaScript ที่ชัดเจนและเคล็ดลับเพื่อทำให้การพรีเซนเทชันของคุณเป็นระเบียบง่ายขึ้น."
---
## **ภาพรวม**

กราฟิก SmartArt ในงานพรีเซนเทชันของ PowerPoint ถูกจัดระเบียบผ่านโนดที่มีข้อความและกำหนดโครงสร้างของแผนภาพ Aspose.Slides ให้คุณทำงานกับโนด SmartArt เหล่านี้ด้วยโปรแกรมได้: เพิ่มโนดและโนดลูกใหม่, แทรกโนดลูกในตำแหน่งที่กำหนด, เข้าถึงโนดที่มีอยู่, และอ่านข้อความ ระดับ และตำแหน่งของมัน

บทความนี้อธิบายวิธีการจัดการโนดรูปแบบ SmartArt ทั้งการลบโนด, ทำงานกับโนดลูกโดยใช้ดัชนีหรือตำแหน่ง, เปลี่ยนโนดผู้ช่วยให้เป็นโนดปกติ, ปรับตำแหน่ง ขนาด และการหมุนของรูปโนด SmartArt, ตั้งค่ารูปแบบการเติมของโนด, และสร้างภาพขนาดย่อของโนดลูก SmartArt

## **เพิ่มโนด SmartArt ในพรีเซนเทชัน PowerPoint ด้วย JavaScript**
Aspose.Slides for Node.js via Java ได้ให้ API ที่ง่ายที่สุดสำหรับจัดการรูปร่าง SmartArt อย่างง่ายที่สุด ตัวอย่างโค้ดต่อไปนี้จะช่วยให้คุณเพิ่มโนดและโนดลูกภายในรูปร่าง SmartArt

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) และโหลดพรีเซนเทชันที่มีรูปร่าง SmartArt
1. รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
1. วนผ่านรูปทรงทั้งหมดในสไลด์แรก
1. ตรวจสอบว่ารูปทรงเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SmartArt) หรือไม่ และทำการแคสท์รูปทรงที่เลือกเป็น [SmartArt](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SmartArt) หากเป็น SmartArt
1. [เพิ่มโนดใหม่](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--) ในรูปร่าง SmartArt [**NodeCollection**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SmartArt#getAllNodes--) และตั้งค่าข้อความใน TextFrame
1. ตอนนี้, [เพิ่ม](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--) [**Child Node**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) ในโนด [SmartArt](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SmartArt) ที่เพิ่มใหม่และตั้งค่าข้อความใน TextFrame
1. บันทึกพรีเซนเทชัน

```javascript
// โหลดพรีเซนเทชันที่ต้องการ
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // วนผ่านรูปทรงทั้งหมดในสไลด์แรก
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // ตรวจสอบว่ารูปทรงเป็นประเภท SmartArt หรือไม่
        if (java.instanceOf(shape, "com.aspose.slides.SmartArt")) {
            // แคสท์รูปทรงเป็น SmartArt
            var smart = shape;
            // เพิ่มโนด SmartArt ใหม่
            var TemNode = smart.getAllNodes().addNode();
            // เพิ่มข้อความ
            TemNode.getTextFrame().setText("Test");
            // เพิ่มโนดลูกใหม่ในโนดพาเรนท์ จะถูกเพิ่มในตำแหน่งสุดท้ายของคอลเลกชัน
            var newNode = TemNode.getChildNodes().addNode();
            // เพิ่มข้อความ
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    // บันทึกพรีเซนเทชัน
    pres.save("AddSmartArtNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **เพิ่มโนด SmartArt ที่ตำแหน่งเฉพาะ**
ในตัวอย่างโค้ดต่อไปนี้ เราได้อธิบายวิธีการเพิ่มโนดลูกที่เป็นส่วนหนึ่งของโนดต่าง ๆ ของรูปร่าง SmartArt ในตำแหน่งที่ระบุ

1. สร้างอินสแตนซ์ของคลาส Presentation
1. รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
1. เพิ่มรูปร่าง [**StackedList**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SmartArtLayoutType#StackedList) ประเภท SmartArt ในสไลด์ที่เข้าถึง
1. เข้าถึงโนดแรกในรูปร่าง SmartArt ที่เพิ่มไว้
1. ตอนนี้, เพิ่ม [**Child Node**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) สำหรับ [**Node**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SmartArtNode) ที่เลือกที่ตำแหน่ง 2 และตั้งค่าข้อความของมัน
1. บันทึกพรีเซนเทชัน

```javascript
// สร้างอินสแตนซ์พรีเซนเทชัน
var pres = new aspose.slides.Presentation();
try {
    // เข้าถึงสไลด์พรีเซนเทชัน
    var slide = pres.getSlides().get_Item(0);
    // เพิ่ม Smart Art IShape
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.StackedList);
    // เข้าถึงโนด SmartArt ที่ดัชนี 0
    var node = smart.getAllNodes().get_Item(0);
    // เพิ่มโนดลูกใหม่ที่ตำแหน่ง 2 ในโนดพาเรนท์
    var chNode = node.getChildNodes().addNodeByPosition(2);
    // เพิ่มข้อความ
    chNode.getTextFrame().setText("Sample Text Added");
    // บันทึกพรีเซนเทชัน
    pres.save("AddSmartArtNodeByPosition.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **เข้าถึงโนด SmartArt ในพรีเซนเทชัน PowerPoint ด้วย JavaScript**
ตัวอย่างโค้ดต่อไปนี้จะช่วยให้คุณเข้าถึงโนดภายในรูปร่าง SmartArt โปรดทราบว่าคุณไม่สามารถเปลี่ยน LayoutType ของ SmartArt ได้ เพราะเป็นค่าอ่านอย่างเดียวและจะตั้งค่าเฉพาะเมื่อรูปร่าง SmartArt ถูกเพิ่ม

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation) และโหลดพรีเซนเทชันที่มีรูปร่าง SmartArt
1. รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
1. วนผ่านรูปทรงทั้งหมดในสไลด์แรก
1. ตรวจสอบว่ารูปทรงเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SmartArt) หรือไม่ และทำการแคสท์รูปทรงที่เลือกเป็น [SmartArt](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SmartArt) หากเป็น SmartArt
1. วนผ่านทุก [**Nodes**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SmartArt#getAllNodes--) ภายในรูปร่าง SmartArt
1. เข้าถึงและแสดงข้อมูลเช่น ตำแหน่งของโนด SmartArt, ระดับและข้อความ

```javascript
// สร้างอินสแตนซ์คลาส Presentation
var pres = new aspose.slides.Presentation("SmartArtShape.pptx");
try {
    // ดึงสไลด์แรก
    var slide = pres.getSlides().get_Item(0);
    // วนผ่านรูปทรงทั้งหมดในสไลด์แรก
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // ตรวจสอบว่ารูปทรงเป็นประเภท SmartArt หรือไม่
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // แคสท์รูปทรงเป็น SmartArt
            var smart = shape;
            // วนผ่านโนดทั้งหมดภายใน SmartArt
            for (var j = 0; j < smart.getAllNodes().size(); j++) {
                // เข้าถึงโนด SmartArt ที่ดัชนี i
                var node = smart.getAllNodes().get_Item(j);
                // พิมพ์พารามิเตอร์ของโนด SmartArt
                console.log(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **เข้าถึงโนดลูก SmartArt**
ตัวอย่างโค้ดต่อไปนี้จะช่วยให้คุณเข้าถึงโนดลูกที่เป็นส่วนหนึ่งของโนดต่าง ๆ ของรูปร่าง SmartArt

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation) และโหลดพรีเซนเทชันที่มีรูปร่าง SmartArt
1. รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
1. วนผ่านรูปทรงทั้งหมดในสไลด์แรก
1. ตรวจสอบว่ารูปทรงเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SmartArt) หรือไม่ และทำการแคสท์รูปทรงที่เลือกเป็น [SmartArt](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SmartArt) หากเป็น SmartArt
1. วนผ่านทุก [**Nodes**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SmartArt#getAllNodes--) ภายในรูปร่าง SmartArt
1. สำหรับแต่ละ [**Node**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SmartArtNode) ของรูปร่าง SmartArt ที่เลือก, วนผ่านทุก [**Child Nodes**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) ภายในโนดนั้น
1. เข้าถึงและแสดงข้อมูลเช่น ตำแหน่งของ [**Child Node**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) ระดับและข้อความ

```javascript
// สร้างอินสแตนซ์คลาส Presentation
var pres = new aspose.slides.Presentation("AccessChildNodes.pptx");
try {
    // ดึงสไลด์แรก
    var slide = pres.getSlides().get_Item(0);
    // วนผ่านรูปทรงทั้งหมดในสไลด์แรก
    for (let s = 0; s < slide.getShapes().size(); s++) {
        let shape = slide.getShapes().get_Item(s);
        // ตรวจสอบว่ารูปทรงเป็นประเภท SmartArt หรือไม่
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // แคสท์รูปทรงเป็น SmartArt
            var smart = shape;
            // วนผ่านโนดทั้งหมดภายใน SmartArt
            for (var i = 0; i < smart.getAllNodes().size(); i++) {
                // เข้าถึงโนด SmartArt ที่ดัชนี i
                var node0 = smart.getAllNodes().get_Item(i);
                // วนผ่านโนดลูกในโนด SmartArt ที่ดัชนี i
                for (var j = 0; j < node0.getChildNodes().size(); j++) {
                    // เข้าถึงโนดลูกในโนด SmartArt
                    var node = node0.getChildNodes().get_Item(j);
                    // พิมพ์พารามิเตอร์ของโนดลูก SmartArt
                    console.log("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **เข้าถึงโนดลูก SmartArt ที่ตำแหน่งเฉพาะ**
ในตัวอย่างนี้ เราจะเรียนรู้วิธีเข้าถึงโนดลูกที่อยู่ในตำแหน่งบางส่วนของโนดต่าง ๆ ของรูปร่าง SmartArt

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation)
1. รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
1. เพิ่มรูปร่าง [**StackedList**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SmartArtLayoutType#StackedList) ประเภท SmartArt
1. เข้าถึงรูปร่าง SmartArt ที่เพิ่มไว้
1. เข้าถึงโนดที่ดัชนี 0 ของรูปร่าง SmartArt ที่เข้าถึง
1. ตอนนี้, เข้าถึง [**Child Node**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) ที่ตำแหน่ง 1 ของโนด SmartArt ที่เข้าถึงโดยใช้เมธอด **get_Item()**
1. เข้าถึงและแสดงข้อมูลเช่น ตำแหน่งของ [**Child Node**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) ระดับและข้อความ

```javascript
// สร้างอินสแตนซ์พรีเซนเทชัน
var pres = new aspose.slides.Presentation();
try {
    // เข้าถึงสไลด์แรก
    var slide = pres.getSlides().get_Item(0);
    // เพิ่มรูปร่าง SmartArt ในสไลด์แรก
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.StackedList);
    // เข้าถึงโนด SmartArt ที่ดัชนี 0
    var node = smart.getAllNodes().get_Item(0);
    // เข้าถึงโนดลูกที่ตำแหน่ง 1 ในโนดพาเรนท์
    var position = 1;
    var chNode = node.getChildNodes().get_Item(position);
    // พิมพ์พารามิเตอร์ของโนดลูก SmartArt
    console.log("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ลบโนด SmartArt ในพรีเซนเทชัน PowerPoint ด้วย JavaScript**
ในตัวอย่างนี้ เราจะเรียนรู้วิธีลบโนดภายในรูปร่าง SmartArt

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation) และโหลดพรีเซนเทชันที่มีรูปร่าง SmartArt
1. รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
1. วนผ่านรูปทรงทั้งหมดในสไลด์แรก
1. ตรวจสอบว่ารูปทรงเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SmartArt) หรือไม่ และทำการแคสท์รูปทรงที่เลือกเป็น [SmartArt](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SmartArt) หากเป็น SmartArt
1. ตรวจสอบว่า [SmartArt](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SmartArt) มีโนดมากกว่า 0 หรือไม่
1. เลือกโนด SmartArt ที่ต้องการลบ
1. ตอนนี้, ลบโนดที่เลือกโดยใช้เมธอด [**RemoveNode**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SmartArtNodeCollection#removeNode-aspose.slides.ISmartArtNode-) 
1. บันทึกพรีเซนเทชัน

```javascript
// โหลดพรีเซนเทชันที่ต้องการ
var pres = new aspose.slides.Presentation("AddSmartArtNode.pptx");
try {
    // วนผ่านรูปทรงทั้งหมดในสไลด์แรก
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // ตรวจสอบว่ารูปทรงเป็นประเภท SmartArt หรือไม่
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // แคสท์รูปทรงเป็น SmartArt
            var smart = shape;
            if (smart.getAllNodes().size() > 0) {
                // เข้าถึงโนด SmartArt ที่ดัชนี 0
                var node = smart.getAllNodes().get_Item(0);
                // ลบโนดที่เลือก
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    // บันทึกพรีเซนเทชัน
    pres.save("RemoveSmartArtNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ลบโนด SmartArt ที่ตำแหน่งเฉพาะ**
ในตัวอย่างนี้ เราจะเรียนรู้วิธีลบโนดภายในรูปร่าง SmartArt ที่ตำแหน่งเฉพาะ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation) และโหลดพรีเซนเทชันที่มีรูปร่าง SmartArt
1. รับอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน
1. วนผ่านรูปทรงทั้งหมดในสไลด์แรก
1. ตรวจสอบว่ารูปทรงเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SmartArt) หรือไม่ และทำการแคสท์รูปทรงที่เลือกเป็น [SmartArt](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SmartArt) หากเป็น SmartArt
1. เลือกโนดรูปร่าง SmartArt ที่ดัชนี 0
1. ตอนนี้, ตรวจสอบว่าโนด SmartArt ที่เลือกมีโนดลูกมากกว่า 2 หรือไม่
1. ตอนนี้, ลบโนดที่ตำแหน่ง **Position 1** โดยใช้เมธอด [**RemoveNode**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SmartArtNodeCollection#removeNode-int-)
1. บันทึกพรีเซนเทชัน

```javascript
// โหลดพรีเซนเทชันที่ต้องการ
var pres = new aspose.slides.Presentation("AddSmartArtNode.pptx");
try {
    // วนผ่านรูปทรงทั้งหมดในสไลด์แรก
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // ตรวจสอบว่ารูปทรงเป็นประเภท SmartArt หรือไม่
        if (java.instanceOf(shape, "com.aspose.slides.SmartArt")) {
            // แคสท์รูปทรงเป็น SmartArt
            var smart = shape;
            if (smart.getAllNodes().size() > 0) {
                // เข้าถึงโนด SmartArt ที่ดัชนี 0
                var node = smart.getAllNodes().get_Item(0);
                if (node.getChildNodes().size() >= 2) {
                    // ลบโนดลูกที่ตำแหน่ง 1
                    node.getChildNodes().removeNode(1);
                }
            }
        }
    }
    // บันทึกพรีเซนเทชัน
    pres.save("RemoveSmartArtNodeByPosition.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ตั้งค่าตำแหน่งกำหนดเองสำหรับโนดลูกใน SmartArt**
ตอนนี้ Aspose.Slides for Node.js via Java รองรับการตั้งค่าคุณสมบัติ [SmartArtShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Shape#setX-float-) และ [Y](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Shape#setY-float-) โค้ดสแนปด้านล่างแสดงวิธีตั้งค่าตำแหน่ง, ขนาด และการหมุนของ SmartArtShape แบบกำหนดเอง โปรดทราบว่าการเพิ่มโนดใหม่จะทำให้ตำแหน่งและขนาดของโนดทั้งหมดต้องคำนวณใหม่ และด้วยการตั้งค่าตำแหน่งแบบกำหนดเอง ผู้ใช้สามารถกำหนดตำแหน่งโนดตามความต้องการ

```javascript
// สร้างอินสแตนซ์คลาส Presentation
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, aspose.slides.SmartArtLayoutType.OrganizationChart);
    // ย้ายรูปร่าง SmartArt ไปยังตำแหน่งใหม่
    var node = smart.getAllNodes().get_Item(1);
    var shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + (shape.getWidth() * 2));
    shape.setY(shape.getY() - (shape.getHeight() * 2));
    // เปลี่ยนความกว้างของรูปร่าง SmartArt
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + (shape.getWidth() * 2));
    // เปลี่ยนความสูงของรูปร่าง SmartArt
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + (shape.getHeight() * 2));
    // เปลี่ยนการหมุนของรูปร่าง SmartArt
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);
    pres.save("SmartArt.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **ตรวจสอบโนดผู้ช่วย**
{{% alert color="primary" %}} 

ในบทความนี้เราจะสำรวจคุณลักษณะของรูปร่าง SmartArt ที่เพิ่มในสไลด์พรีเซนเทชันโดยใช้ Aspose.Slides for Node.js via Java

{{% /alert %}} 

เราจะใช้รูปร่าง SmartArt แหล่งที่มาดังต่อไปนี้สำหรับการสำรวจในส่วนต่าง ๆ ของบทความนี้

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**รูปที่ 1: รูปร่าง SmartArt แหล่งที่มาบนสไลด์**|

ในตัวอย่างโค้ดต่อไปนี้ เราจะสำรวจวิธีการระบุ **Assistant Nodes** ในคอลเลกชันโนด SmartArt และการเปลี่ยนแปลงของพวกมัน

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation) และโหลดพรีเซนเทชันที่มีรูปร่าง SmartArt
1. รับอ้างอิงของสไลด์ที่สองโดยใช้ Index ของมัน
1. วนผ่านรูปทรงทั้งหมดในสไลด์แรก
1. ตรวจสอบว่ารูปทรงเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SmartArt) หรือไม่ และทำการแคสท์รูปทรงที่เลือกเป็น [SmartArt](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SmartArt) หากเป็น SmartArt
1. วนผ่านโนดทั้งหมดภายในรูปร่าง SmartArt และตรวจสอบว่าพวกมันเป็น [**Assistant Nodes**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SmartArtNode#isAssistant--) หรือไม่
1. เปลี่ยนสถานะของโนดผู้ช่วยให้เป็นโนดปกติ
1. บันทึกพรีเซนเทชัน

```javascript
// สร้างอินสแตนซ์พรีเซนเทชัน
var pres = new aspose.slides.Presentation("AddNodes.pptx");
try {
    // วนผ่านรูปทรงทั้งหมดในสไลด์แรก
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // ตรวจสอบว่ารูปทรงเป็นประเภท SmartArt หรือไม่
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // แคสท์รูปทรงเป็น SmartArt
            var smart = shape;
            // วนผ่านโนดทั้งหมดของรูปร่าง SmartArt
            for (var j = 0; j < smart.getAllNodes().size(); j++) {
                var node = smart.getAllNodes().get_Item(j);
                // ตรวจสอบว่าโนดเป็นโนดผู้ช่วยหรือไม่
                if (node.isAssistant()) {
                    // ตั้งค่าโนดผู้ช่วยเป็น false และทำให้เป็นโนดปกติ
                    node.isAssistant();
                }
            }
        }
    }
    // บันทึกพรีเซนเทชัน
    pres.save("ChangeAssitantNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**รูปที่ 2: โนดผู้ช่วยที่เปลี่ยนในรูปร่าง SmartArt บนสไลด์**|

## **ตั้งค่ารูปแบบการเติมของโนด**
Aspose.Slides for Node.js via Java ทำให้สามารถเพิ่มรูปร่าง SmartArt แบบกำหนดเองและตั้งค่ารูปแบบการเติมของมันได้ บทความนี้อธิบายวิธีสร้างและเข้าถึงรูปร่าง SmartArt และตั้งค่ารูปแบบการเติมโดยใช้ Aspose.Slides for Node.js via Java

กรุณาติดตามขั้นตอนต่อไปนี้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation)
1. รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน
1. เพิ่มรูปร่าง [SmartArt](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SmartArt) โดยกำหนด [**LayoutType**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess)
1. ตั้งค่า [**FillFormat**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Shape#getFillFormat--) สำหรับโนดรูปร่าง SmartArt
1. เขียนพรีเซนเทชันที่แก้ไขแล้วเป็นไฟล์ PPTX

```javascript
// สร้างอินสแตนซ์พรีเซนเทชัน
var pres = new aspose.slides.Presentation();
try {
    // เข้าถึงสไลด์
    var slide = pres.getSlides().get_Item(0);
    // เพิ่มรูปร่าง SmartArt และโนด
    var chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, aspose.slides.SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    // ตั้งค่าสีเติมของโนด
    for (let i = 0; i < node.getShapes().size(); i++) {
        let item = node.getShapes().get_Item(i);
        item.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        item.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    }
    // บันทึกพรีเซนเทชัน
    pres.save("TestSmart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **สร้างภาพขนาดย่อของโนดลูก SmartArt**
นักพัฒนาสามารถสร้างภาพขนาดย่อของโนดลูกของ SmartArt ได้โดยทำตามขั้นตอนต่อไปนี้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation)
1. [เพิ่ม SmartArt](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--)
1. รับอ้างอิงของโนดโดยใช้ Index ของมัน
1. รับภาพขนาดย่อ
1. บันทึกภาพขนาดย่อในรูปแบบภาพที่ต้องการใด ๆ

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
var pres = new aspose.slides.Presentation();
try {
    // เพิ่ม SmartArt
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicCycle);
    // รับอ้างอิงของโนดโดยใช้ Index ของมัน
    var node = smart.getNodes().get_Item(1);
    // รับภาพขนาดย่อ
    var slideImage = node.getShapes().get_Item(0).getImage();
    // บันทึกภาพขนาดย่อ
    try {
        slideImage.save("SmartArt_ChildNote_Thumbnail.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**SmartArt animation ถูกสนับสนุนหรือไม่?**

ใช่ SmartArt ถูกถือว่าเป็นรูปทรงปกติ ดังนั้นคุณสามารถ [apply standard animations](/slides/th/nodejs-java/shape-animation/) (entrance, exit, emphasis, motion paths) และปรับเวลาการแสดงได้ คุณยังสามารถทำให้รูปทรงภายในโนด SmartArt เคลื่อนไหวได้เมื่อจำเป็น

**หากไม่ทราบ ID ภายในของ SmartArt จะค้นหา SmartArt ที่กำหนดบนสไลด์ได้อย่างไร?**

กำหนดและค้นหาโดยใช้ [alternative text](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/getalternativetext/) การตั้งค่า AltText ที่เด่นบน SmartArt จะทำให้คุณพบได้โดยไม่ต้องอ้างอิงถึงตัวระบุภายใน

**รูปลักษณ์ของ SmartArt จะคงเดิมเมื่อแปลงพรีเซนเทชันเป็น PDF หรือไม่?**

ใช่ Aspose.Slides เรนเดอร์ SmartArt ด้วยความแม่นยำสูงในระหว่าง [PDF export](/slides/th/nodejs-java/convert-powerpoint-to-pdf/) ทำให้คงการจัดวาง สี และเอฟเฟ็กต์

**สามารถดึงภาพของ SmartArt ทั้งหมด (สำหรับพรีวิวหรือรายงาน) ได้หรือไม่?**

ได้ คุณสามารถเรนเดอร์รูปร่าง SmartArt เป็น [raster formats](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/#getImage) หรือเป็น [SVG](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/writeassvg/) สำหรับเอาต์พุตเวกเตอร์ที่ขยายได้ ทำให้เหมาะสำหรับภาพขนาดย่อ รายงาน หรือการใช้งานบนเว็บ