---
title: เพิ่มรูปทรงเส้นลงในงานนำเสนอด้วย JavaScript
linktitle: เส้น
type: docs
weight: 50
url: /th/nodejs-java/line/
keywords:
- เส้น
- สร้างเส้น
- เพิ่มเส้น
- เส้นธรรมดา
- กำหนดค่าเส้น
- ปรับแต่งเส้น
- รูปแบบเส้นจุดประดัก
- หัวลูกศร
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้การจัดรูปแบบเส้นในงานนำเสนอ PowerPoint ด้วย JavaScript และ Aspose.Slides สำหรับ Node.js ค้นพบคุณสมบัติ วิธีการ และตัวอย่าง"
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณเพิ่มรูปทรงเส้นลงในสไลด์ PowerPoint โดยโปรแกรมมิ่ง บทความนี้แสดงวิธีสร้างเส้นง่าย ๆ และวิธีปรับแต่งเส้นให้แสดงเป็นลูกศร

คุณจะได้เรียนรู้วิธีเพิ่มรูปทรงเส้นลงในสไลด์ ปรับลักษณะการแสดงผลและบันทึกงานนำเสนอที่อัปเดต ตัวอย่างจะเน้นการตั้งค่าการจัดรูปแบบเส้นเชิงปฏิบัติ เช่น สไตล์ ความกว้าง รูปแบบเส้นขีด ตัวเลือกหัวลูกศร และสีเติม

## **สร้างเส้นธรรมดา**

เพื่อเพิ่มเส้นธรรมดาแบบง่ายลงในสไลด์ที่เลือกของงานนำเสนอ โปรดทำตามขั้นตอนต่อไปนี้:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)
- ดึงอ้างอิงของสไลด์โดยใช้ Index ของมัน
- เพิ่ม AutoShape ประเภท Line ด้วยเมธอด [addAutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) ที่เปิดให้ใช้โดยอ็อบเจกต์ [ShapeCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ShapeCollection)
- เขียนงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง เราได้เพิ่มเส้นลงในสไลด์แรกของงานนำเสนอ

```javascript
// สร้างอินสแตนซ์ของคลาส PresentationEx ที่เป็นตัวแทนไฟล์ PPTX
var pres = new aspose.slides.Presentation();
try {
    // ดึงสไลด์แรก
    var sld = pres.getSlides().get_Item(0);
    // เพิ่ม AutoShape ประเภทเส้น
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // เขียนไฟล์ PPTX ลงดิสก์
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **สร้างเส้นแบบลูกศร**

Aspose.Slides สำหรับ Node.js ผ่าน Java ยังอนุญาตให้ผู้พัฒนาตั้งค่าบางคุณสมบัติของเส้นเพื่อให้ดูน่าสนใจยิ่งขึ้น ลองตั้งค่าบางคุณสมบัติของเส้นเพื่อให้ดูเหมือนลูกศร โปรดทำตามขั้นตอนต่อไปนี้:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)
- ดึงอ้างอิงของสไลด์โดยใช้ Index ของมัน
- เพิ่ม AutoShape ประเภท Line ด้วยเมธอด [addAutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) ที่เปิดให้ใช้โดยอ็อบเจกต์ [ShapeCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ShapeCollection)
- ตั้งค่า [Line Style](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/LineStyle) ให้เป็นหนึ่งในสไตล์ที่ Aspose.Slides สำหรับ Node.js ผ่าน Java มีให้
- ตั้งค่าความกว้างของเส้น
- ตั้งค่า [Dash Style](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/LineDashStyle) ของเส้นให้เป็นหนึ่งในสไตล์ที่ Aspose.Slides สำหรับ Node.js ผ่าน Java มีให้
- ตั้งค่า [Arrow Head Style](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/LineArrowheadStyle) และ [Length](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/LineArrowheadLength) ของจุดเริ่มต้นของเส้น
- ตั้งค่า [Arrow Head Style](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/LineArrowheadStyle) และ [Length](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/LineArrowheadLength) ของจุดสิ้นสุดของเส้น
- เขียนงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

```javascript
// สร้างอินสแตนซ์ของคลาส PresentationEx ที่เป็นตัวแทนไฟล์ PPTX
var pres = new aspose.slides.Presentation();
try {
    // ดึงสไลด์แรก
    var sld = pres.getSlides().get_Item(0);
    // เพิ่ม AutoShape ประเภทเส้น
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // ใช้การจัดรูปแบบบางอย่างบนเส้น
    shp.getLineFormat().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);
    shp.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    shp.getLineFormat().setBeginArrowheadLength(aspose.slides.LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(aspose.slides.LineArrowheadStyle.Oval);
    shp.getLineFormat().setEndArrowheadLength(aspose.slides.LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Maroon));
    // เขียนไฟล์ PPTX ลงดิสก์
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลงเส้นธรรมดาเป็นคอนเน็กเตอร์เพื่อให้มัน “ดึง” ไปยังรูปทรงได้หรือไม่?**

ไม่ เส้นธรรมดา (เป็น [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ประเภท [Line](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapetype/)) จะไม่กลายเป็นคอนเน็กเตอร์โดยอัตโนมัติ เพื่อให้ดึงไปยังรูปทรง ให้ใช้ประเภท [Connector](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/connector/) เฉพาะและ [API ที่สอดคล้อง](/slides/th/nodejs-java/connector/) สำหรับการเชื่อมต่อ

**ฉันควรทำอย่างไรหากคุณสมบัติของเส้นถูกสืบทอดจากธีมและยากที่จะกำหนดค่าที่สุดท้าย?**

[อ่านคุณสมบัติที่มีผล](/slides/th/nodejs-java/shape-effective-properties/) ผ่านคลาส `ILineFormatEffectiveData`/`ILineFillFormatEffectiveData` — สิ่งเหล่านี้ได้คำนึงถึงการสืบทอดและสไตล์ของธีมแล้ว

**ฉันสามารถล็อกเส้นไม่ให้แก้ไข (ย้าย, เปลี่ยนขนาด) ได้หรือไม่?**

ได้ Shapes มี [วัตถุล็อก](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/getautoshapelock/) ที่ให้คุณปิดการทำงานแก้ไข