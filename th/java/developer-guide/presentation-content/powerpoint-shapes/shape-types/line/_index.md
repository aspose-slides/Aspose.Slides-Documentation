---
title: เพิ่มรูปทรงเส้นในงานนำเสนอด้วย Java
linktitle: เส้น
type: docs
weight: 50
url: /th/java/line/
keywords:
- เส้น
- สร้างเส้น
- เพิ่มเส้น
- เส้นธรรมดา
- กำหนดค่าเส้น
- ปรับแต่งเส้น
- สไตล์เส้นขีด
- หัวลูกศร
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้การจัดรูปแบบเส้นในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Java. ค้นพบคุณสมบัติ วิธีการ และตัวอย่าง."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณสามารถเพิ่มรูปทรงเส้นลงในสไลด์ PowerPoint ได้โดยอัตโนมัติ บทความนี้จะแสดงวิธีสร้างเส้นง่ายๆ และวิธีปรับแต่งเส้นให้แสดงเป็นลูกศร

คุณจะได้เรียนรู้วิธีเพิ่มรูปทรงเส้นลงในสไลด์ ปรับลักษณะการแสดงผลของมัน และบันทึกงานนำเสนอที่อัปเดต ตัวอย่างมุ่งเน้นการตั้งค่าการจัดรูปแบบเส้นที่ใช้ได้จริง เช่น สไตล์ ความกว้าง รูปแบบจุดแตก (dash) ตัวเลือกหัวลูกศร และสีเติม

## **สร้างเส้นธรรมดา**

เพื่อเพิ่มเส้นธรรมดาแบบง่ายลงในสไลด์ที่เลือกของงานนำเสนอ โปรดทำตามขั้นตอนต่อไปนี้:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)  
- รับอ้างอิงของสไลด์โดยใช้ Index ของมัน  
- เพิ่ม AutoShape ชนิด Line โดยใช้เมธอด [addAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) ที่เปิดให้ใช้โดยอ็อบเจกต์ [IShapeCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShapeCollection)  
- บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

ในตัวอย่างด้านล่าง เราได้เพิ่มเส้นลงในสไลด์แรกของงานนำเสนอ

```java
// สร้างอินสแตนซ์ของคลาส PresentationEx ซึ่งเป็นตัวแทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // รับสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);
    
    // เพิ่ม AutoShape ชนิดเส้น
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **สร้างเส้นรูปรูปลูกศร**

Aspose.Slides for Java ยังอนุญาตให้นักพัฒนาตั้งค่าคุณสมบัติบางอย่างของเส้นเพื่อให้ดูสวยงามขึ้น ลองตั้งค่าคุณสมบัติบางอย่างของเส้นเพื่อให้มันดูเหมือนลูกศรตามขั้นตอนต่อไปนี้:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)  
- รับอ้างอิงของสไลด์โดยใช้ Index ของมัน  
- เพิ่ม AutoShape ชนิด Line โดยใช้เมธอด [addAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) ที่เปิดให้ใช้โดยอ็อบเจกต์ [IShapeCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShapeCollection)  
- ตั้งค่า [Line Style](https://reference.aspose.com/slides/th/java/com.aspose.slides/LineStyle) เป็นหนึ่งในสไตล์ที่ Aspose.Slides for Java เสนอ  
- ตั้งค่าความกว้างของเส้น  
- ตั้งค่า [Dash Style](https://reference.aspose.com/slides/th/java/com.aspose.slides/LineDashStyle) ของเส้นเป็นหนึ่งในสไตล์ที่ Aspose.Slides for Java เสนอ  
- ตั้งค่า [Arrow Head Style](https://reference.aspose.com/slides/th/java/com.aspose.slides/LineArrowheadStyle) และ [Length](https://reference.aspose.com/slides/th/java/com.aspose.slides/LineArrowheadLength) ของจุดเริ่มต้นของเส้น  
- ตั้งค่า [Arrow Head Style](https://reference.aspose.com/slides/th/java/com.aspose.slides/LineArrowheadStyle) และ [Length](https://reference.aspose.com/slides/th/java/com.aspose.slides/LineArrowheadLength) ของจุดสิ้นสุดของเส้น  
- บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

```java
// สร้างอินสแตนซ์ของคลาส PresentationEx ซึ่งแทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // รับสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);

    // เพิ่ม AutoShape ชนิดเส้น
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // ปรับรูปแบบบางอย่างให้กับเส้น
    shp.getLineFormat().setStyle(LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);

    shp.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    shp.getLineFormat().setBeginArrowheadLength(LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.Oval);

    shp.getLineFormat().setEndArrowheadLength(LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);

    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Maroon));

    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถแปลงเส้นปกติให้เป็นคอนเนคเตอร์ที่ “ติด” กับรูปทรงได้หรือไม่?**

ไม่ได้ เส้นปกติ (หนึ่ง [AutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/autoshape/) ชนิด [Line](https://reference.aspose.com/slides/th/java/com.aspose.slides/shapetype/)) จะไม่กลายเป็นคอนเนคเตอร์โดยอัตโนมัติ หากต้องการให้มันติดกับรูปทรง ให้ใช้ประเภท [Connector](https://reference.aspose.com/slides/th/java/com.aspose.slides/connector/) เฉพาะและ API ที่เกี่ยวข้อง [/slides/th/java/connector/] สำหรับการเชื่อมต่อ

**ถ้าคุณสมบัติของเส้นถูกสืบทอดจากธีมและยากจะกำหนดค่าที่สุดท้ายควรทำอย่างไร?**

[อ่านคุณสมบัติที่มีผล](/slides/th/java/shape-effective-properties/) ผ่านอินเตอร์เฟส [ILineFormatEffectiveData](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilinefillformateffectivedata/) — อินเตอร์เฟสเหล่านี้จะคำนึงถึงการสืบทอดและสไตล์ของธีมให้แล้ว

**ฉันสามารถล็อกเส้นไม่ให้แก้ไข (ย้าย ปรับขนาด) ได้หรือไม่?**

ได้ Shape มี [lock objects](https://reference.aspose.com/slides/th/java/com.aspose.slides/autoshape/#getAutoShapeLock--) ที่อนุญาตให้คุณ [ห้ามการดำเนินการแก้ไข](/slides/th/java/applying-protection-to-presentation/)