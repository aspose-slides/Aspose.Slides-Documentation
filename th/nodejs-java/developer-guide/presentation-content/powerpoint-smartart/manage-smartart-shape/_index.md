---
title: จัดการกราฟิก SmartArt ในงานนำเสนอด้วย JavaScript
linktitle: กราฟิก SmartArt
type: docs
weight: 20
url: /th/nodejs-java/manage-smartart-shape/
keywords:
- วัตถุ SmartArt
- กราฟิก SmartArt
- สไตล์ SmartArt
- สี SmartArt
- สร้าง SmartArt
- เพิ่ม SmartArt
- แก้ไข SmartArt
- เปลี่ยน SmartArt
- เข้าถึง SmartArt
- ประเภทการจัดวาง SmartArt
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ทำงานอัตโนมัติการสร้าง, แก้ไขและตกแต่ง SmartArt ของ PowerPoint ใน JavaScript ด้วย Aspose.Slides พร้อมตัวอย่างโค้ดสั้น ๆ และแนวทางที่เน้นประสิทธิภาพ"
---
## **ภาพรวม**

Aspose.Slides ให้คุณสร้างและจัดการกราฟิก SmartArt ในงานนำเสนอ PowerPoint ด้วยโปรแกรม ตัวอย่างนี้อธิบายวิธีเพิ่มรูปแบบ SmartArt ลงในสไลด์, เข้าถึงรูปแบบ SmartArt ที่มีอยู่, ค้นหา SmartArt ด้วย LayoutType เฉพาะ, และอัปเดตลักษณะการแสดงผลโดยการเปลี่ยนสไตล์หรือสีสไตล์ของ SmartArt

ตัวอย่างแสดงวิธีทำงานกับรูปแบบ SmartArt ผ่านคอลเลกชันรูปแบบของสไลด์, ตรวจสอบว่ารูปแบบเป็น SmartArt หรือไม่ แล้วแก้ไขหรือสอบถามคุณสมบัติต่าง ๆ ของมัน

## **สร้างรูปแบบ SmartArt**
Aspose.Slides for Node.js via Java มี API สำหรับสร้างรูปแบบ SmartArt เพื่อสร้างรูปแบบ SmartArt ในสไลด์ โปรดทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation).
2. ดึงอ้างอิงของสไลด์โดยใช้ Index ของมัน.
3. [เพิ่มรูปแบบ SmartArt](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) โดยกำหนด [LayoutType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SmartArtLayoutType).
4. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

```javascript
// สร้างอินสแตนซ์คลาส Presentation
var pres = new aspose.slides.Presentation();
try {
    // ดึงสไลด์แรก
    var slide = pres.getSlides().get_Item(0);
    // เพิ่มรูปแบบ Smart Art
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.BasicBlockList);
    // บันทึกงานนำเสนอ
    pres.save("SimpleSmartArt.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**ภาพ: รูป SmartArt ที่เพิ่มลงในสไลด์**|

## **เข้าถึงรูปแบบ SmartArt ในสไลด์**
โค้ดต่อไปนี้จะใช้เพื่อเข้าถึงรูปแบบ SmartArt ที่เพิ่มในสไลด์งานนำเสนอ ในโค้ดตัวอย่างเราจะวนผ่านรูปแบบทุกอันในสไลด์และตรวจสอบว่ามันเป็นรูปแบบ [SmartArt](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SmartArt) หรือไม่ หากเป็นประเภท SmartArt เราจะทำการแคสต์เป็นอินสแตนซ์ [**SmartArt**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SmartArt).

```javascript
// โหลดงานนำเสนอที่ต้องการ
var pres = new aspose.slides.Presentation("AccessSmartArtShape.pptx");
try {
    // วนผ่านรูปทุกรูปภายในสไลด์แรก
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // ตรวจสอบว่ารูปแบบเป็นประเภท SmartArt หรือไม่
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // แคสต์รูปแบบเป็น SmartArtEx
            var smart = shape;
            console.log("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **เข้าถึงรูปแบบ SmartArt ด้วย LayoutType เฉพาะ**
โค้ดตัวอย่างต่อไปนี้จะช่วยให้เข้าถึงรูปแบบ [SmartArt](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SmartArt) ด้วย LayoutType เฉพาะ โปรดทราบว่าคุณไม่สามารถเปลี่ยน LayoutType ของ SmartArt ได้ เนื่องจากเป็นค่าอ่านอย่างเดียวและตั้งค่าเมื่อเพิ่มรูปแบบ [SmartArt](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SmartArt).

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) และโหลดงานนำเสนอที่มีรูปแบบ SmartArt.
2. ดึงอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน.
3. วนผ่านรูปแบบทุกอันในสไลด์แรก.
4. ตรวจสอบว่ารูปแบบเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SmartArt) หรือไม่และแคสต์รูปแบบที่เลือกเป็น SmartArt หากเป็น SmartArt.
5. ตรวจสอบรูปแบบ SmartArt ที่มี LayoutType เฉพาะและดำเนินการตามที่ต้องการต่อไป.

```javascript
var pres = new aspose.slides.Presentation("AccessSmartArtShape.pptx");
try {
    // วนผ่านรูปทุกรูปภายในสไลด์แรก
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // ตรวจสอบว่ารูปแบบเป็นประเภท SmartArt หรือไม่
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // แคสต์รูปแบบเป็น SmartArtEx
            var smart = shape;
            // ตรวจสอบ Layout ของ SmartArt
            if (smart.getLayout() == aspose.slides.SmartArtLayoutType.BasicBlockList) {
                console.log("Do some thing here....");
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **เปลี่ยนสไตล์รูปแบบ SmartArt**
ในตัวอย่างนี้ เราจะเรียนรู้การเปลี่ยนสไตล์ด่วนสำหรับรูปแบบ SmartArt ใด ๆ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) และโหลดงานนำเสนอที่มีรูปแบบ SmartArt.
2. ดึงอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน.
3. วนผ่านรูปแบบทุกอันในสไลด์แรก.
4. ตรวจสอบว่ารูปแบบเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SmartArt) หรือไม่และแคสต์รูปแบบที่เลือกเป็น SmartArt หากเป็น SmartArt.
5. ค้นหารูปแบบ SmartArt ที่มีสไตล์เฉพาะ.
6. ตั้งค่าสไตล์ใหม่ให้กับรูปแบบ SmartArt.
7. บันทึกงานนำเสนอ.

```javascript
// สร้างอินสแตนซ์คลาส Presentation
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // ดึงสไลด์แรก
    var slide = pres.getSlides().get_Item(0);
    // วนผ่านรูปทุกรูปภายในสไลด์แรก
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // ตรวจสอบว่ารูปแบบเป็นประเภท SmartArt หรือไม่
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // แคสต์รูปแบบเป็น SmartArtEx
            var smart = shape;
            // ตรวจสอบสไตล์ SmartArt
            if (smart.getQuickStyle() == aspose.slides.SmartArtQuickStyleType.SimpleFill) {
                // เปลี่ยนสไตล์ SmartArt
                smart.setQuickStyle(aspose.slides.SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // บันทึกงานนำเสนอ
    pres.save("ChangeSmartArtStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**ภาพ: รูป SmartArt ที่เปลี่ยนสไตล์**|

## **เปลี่ยนสีสไตล์ของรูปแบบ SmartArt**
ในตัวอย่างนี้ เราจะเรียนรู้การเปลี่ยนสีสไตล์สำหรับรูปแบบ SmartArt ใด ๆ ในโค้ดตัวอย่างต่อไปนี้จะเข้าถึงรูปแบบ SmartArt ด้วยสีสไตล์เฉพาะและจะเปลี่ยนสไตล์ของมัน

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) และโหลดงานนำเสนอที่มีรูปแบบ SmartArt.
2. ดึงอ้างอิงของสไลด์แรกโดยใช้ Index ของมัน.
3. วนผ่านรูปแบบทุกอันในสไลด์แรก.
4. ตรวจสอบว่ารูปแบบเป็นประเภท [SmartArt](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/SmartArt) หรือไม่และแคสต์รูปแบบที่เลือกเป็น SmartArt หากเป็น SmartArt.
5. ค้นหารูปแบบ SmartArt ที่มีสีสไตล์เฉพาะ.
6. ตั้งค่าสีสไตล์ใหม่ให้กับรูปแบบ SmartArt.
7. บันทึกงานนำเสนอ.

```javascript
// สร้างอินสแตนซ์คลาส Presentation
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // ดึงสไลด์แรก
    var slide = pres.getSlides().get_Item(0);
    // วนผ่านรูปทุกรูปภายในสไลด์แรก
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // ตรวจสอบว่ารูปแบบเป็นประเภท SmartArt หรือไม่
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // แคสต์รูปแบบเป็น SmartArtEx
            var smart = shape;
            // ตรวจสอบประเภทสีของ SmartArt
            if (smart.getColorStyle() == aspose.slides.SmartArtColorType.ColoredFillAccent1) {
                // เปลี่ยนประเภทสีของ SmartArt
                smart.setColorStyle(aspose.slides.SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // บันทึกงานนำเสนอ
    pres.save("ChangeSmartArtColorStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**ภาพ: รูป SmartArt ที่เปลี่ยนสีสไตล์**|

## **คำถามที่พบบ่อย**

**ฉันสามารถทำแอนิเมชันให้ SmartArt เป็นวัตถุเดียวได้หรือไม่?**

ใช่. SmartArt เป็นรูปแบบหนึ่ง ดังนั้นคุณสามารถใช้ [การเคลื่อนไหวมาตรฐาน](/slides/th/nodejs-java/powerpoint-animation/) ผ่าน API การเคลื่อนไหว (เข้าฉาก, ออกฉาก, เน้น, เส้นทางการเคลื่อนไหว) เช่นเดียวกับรูปแบบอื่น ๆ.

**ฉันจะหาตำแหน่ง SmartArt เฉพาะบนสไลด์ได้อย่างไรหากไม่ทราบ ID ภายใน?**

กำหนดและใช้ข้อความแทน (AltText) แล้วค้นหารูปแบบตามค่านั้น — วิธีนี้แนะนำให้ใช้เพื่อค้นหารูปแบบเป้าหมาย.

**ฉันสามารถจัดกลุ่ม SmartArt กับรูปแบบอื่นได้หรือไม่?**

ใช่. คุณสามารถจัดกลุ่ม SmartArt กับรูปแบบอื่น (รูปภาพ, ตาราง, เป็นต้น) แล้ว [จัดการกลุ่ม](/slides/th/nodejs-java/group/).

**ฉันจะได้รูปภาพของ SmartArt เฉพาะ (เช่น สำหรับการแสดงตัวอย่างหรือรายงาน) อย่างไร?**

ส่งออกภาพขนาดย่อย/รูปภาพของรูปแบบ; ไลบรารีสามารถ [เรนเดอร์รูปแบบแต่ละแบบ](/slides/th/nodejs-java/create-shape-thumbnails/) ไปเป็นไฟล์เรสเตอร์ (PNG/JPG/TIFF).

**ลักษณะของ SmartArt จะคงเดิมเมื่อต้องแปลงงานนำเสนอทั้งหมดเป็น PDF หรือไม่?**

ใช่. เอนจินเรนเดอร์มุ่งเน้นความแม่นยำสูงสำหรับ [การส่งออก PDF](/slides/th/nodejs-java/convert-powerpoint-to-pdf/), พร้อมตัวเลือกคุณภาพและความเข้ากันได้หลายระดับ.