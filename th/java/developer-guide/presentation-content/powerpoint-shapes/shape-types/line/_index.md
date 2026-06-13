---
title: เพิ่มรูปทรงเส้นในงานนำเสนอด้วย Java
linktitle: เส้น
type: docs
weight: 50
url: /th/java/Line/
keywords:
- เส้น
- สร้างเส้น
- เพิ่มเส้น
- เส้นธรรมดา
- กำหนดค่าเส้น
- ปรับแต่งเส้น
- รูปแบบเส้นประ
- หัวลูกศร
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้การจัดการรูปแบบเส้นในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Java. ค้นหาคุณสมบัติ วิธีการ และตัวอย่าง."
---
## **ภาพรวม**

Aspose.Slides ให้คุณเพิ่มรูปทรงเส้นลงในสไลด์ PowerPoint โดยโปรแกรมได้ โดยบทความนี้แสดงวิธีสร้างเส้นเรียบง่ายและวิธีปรับแต่งเส้นให้แสดงเป็นลูกศร

คุณจะได้เรียนรู้วิธีเพิ่มรูปทรงเส้นลงในสไลด์ ปรับลักษณะการแสดงผลของมัน และบันทึกงานนำเสนอที่อัปเดต ตัวอย่างมุ่งเน้นที่การตั้งค่าการจัดรูปแบบเส้นที่ใช้ได้จริง เช่น สไตล์ ความกว้าง รูปแบบเส้นประ ตัวเลือกหัวลูกศร และสีเติม

## **สร้างเส้นธรรมดา**

เพื่อเพิ่มเส้นธรรมดาไปยังสไลด์ที่เลือกของงานนำเสนอ โปรดทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) class
- รับอ้างอิงของสไลด์โดยใช้ Index ของมัน
- เพิ่ม AutoShape ประเภท Line โดยใช้เมธอด [addAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) ที่เปิดให้ใช้งานโดยอ็อบเจ็กต์ [IShapeCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShapeCollection)
- เขียนงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง เราได้เพิ่มเส้นไปยังสไลด์แรกของงานนำเสนอ

```java
// สร้างอินสแตนซ์ของคลาส PresentationEx ที่แสดงไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // รับสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);
    
    // เพิ่ม AutoShape ประเภทเส้น
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // เขียนไฟล์ PPTX ลงดิสก์
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **สร้างเส้นรูปทรงลูกศร**

Aspose.Slides for Java ยังอนุญาตให้นักพัฒนาตั้งค่าคุณสมบัติบางอย่างของเส้นเพื่อให้ดูน่าสนใจยิ่งขึ้น ลองตั้งค่าคุณสมบัติบางอย่างของเส้นให้ดูเหมือนลูกศรโดยทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) class
- รับอ้างอิงของสไลด์โดยใช้ Index ของมัน
- เพิ่ม AutoShape ประเภท Line โดยใช้เมธอด [addAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) ที่เปิดให้ใช้งานโดยอ็อบเจ็กต์ [IShapeCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShapeCollection)
- ตั้งค่า [Line Style](https://reference.aspose.com/slides/th/java/com.aspose.slides/LineStyle) เป็นหนึ่งในสไตล์ที่ Aspose.Slides for Java มีให้
- ตั้งค่าความกว้างของเส้น
- ตั้งค่า [Dash Style](https://reference.aspose.com/slides/th/java/com.aspose.slides/LineDashStyle) ของเส้นเป็นหนึ่งในสไตล์ที่ Aspose.Slides for Java มีให้
- ตั้งค่า [Arrow Head Style](https://reference.aspose.com/slides/th/java/com.aspose.slides/LineArrowheadStyle) และ [Length](https://reference.aspose.com/slides/th/java/com.aspose.slides/LineArrowheadLength) ของจุดเริ่มต้นของเส้น
- ตั้งค่า [Arrow Head Style](https://reference.aspose.com/slides/th/java/com.aspose.slides/LineArrowheadStyle) และ [Length](https://reference.aspose.com/slides/th/java/com.aspose.slides/LineArrowheadLength) ของจุดสิ้นสุดของเส้น
- เขียนงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

```java
// สร้างอินสแตนซ์ของคลาส PresentationEx ที่แทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // รับสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);

    // เพิ่ม AutoShape ประเภทเส้น
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // ใช้การจัดรูปแบบบางอย่างบนเส้น
    shp.getLineFormat().setStyle(LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);

    shp.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    shp.getLineFormat().setBeginArrowheadLength(LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.Oval);

    shp.getLineFormat().setEndArrowheadLength(LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);

    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Maroon));

    // เขียนไฟล์ PPTX ลงดิสก์
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลงเส้นปกติให้เป็นคอนเน็กเตอร์เพื่อให้ “สแนป” ไปยังรูปร่างได้หรือไม่?**

ไม่ได้ เส้นปกติ (เป็น [AutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/autoshape/) ประเภท [Line](https://reference.aspose.com/slides/th/java/com.aspose.slides/shapetype/)) ไม่ได้กลายเป็นคอนเน็กเตอร์โดยอัตโนมัติ เพื่อให้สแนปกับรูปร่าง ให้ใช้ประเภท [Connector](https://reference.aspose.com/slides/th/java/com.aspose.slides/connector/) ที่กำหนดไว้และ API ที่เกี่ยวข้อง [/slides/th/java/connector/] สำหรับการเชื่อมต่อ

**ควรทำอย่างไรหากคุณสมบัติของเส้นถูกสืบทอดจากธีมและยากต่อการกำหนดค่าที่สุดท้าย?**

[อ่านคุณสมบัติที่มีผล](/slides/th/java/shape-effective-properties/) ผ่านอินเตอร์เฟส [ILineFormatEffectiveData](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilinefillformateffectivedata/) — อินเตอร์เฟสเหล่านี้ได้คำนึงถึงการสืบทอดและสไตล์ของธีมแล้ว

**ฉันสามารถล็อคเส้นไม่ให้แก้ไข (ย้าย, ปรับขนาด) ได้หรือไม่?**

ได้ Shape มี [lock objects](https://reference.aspose.com/slides/th/java/com.aspose.slides/autoshape/#getAutoShapeLock--) ที่ทำให้คุณ [ห้ามการดำเนินการแก้ไข](/slides/th/java/applying-protection-to-presentation/)