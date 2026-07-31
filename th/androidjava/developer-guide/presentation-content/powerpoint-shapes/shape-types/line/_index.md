---
title: เพิ่มรูปทรงเส้นในงานนำเสนอบน Android
linktitle: เส้น
type: docs
weight: 50
url: /th/androidjava/line/
keywords:
- เส้น
- สร้างเส้น
- เพิ่มเส้น
- เส้นธรรมดา
- กำหนดค่ารูปเส้น
- ปรับแต่งเส้น
- รูปแบบเส้นประ
- หัวลูกศร
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีจัดการรูปแบบเส้นในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Android ค้นพบคุณสมบัติ วิธีการ และตัวอย่าง Java"
---
## **Overview**

Aspose.Slides ช่วยให้คุณสามารถเพิ่มรูปทรงเส้นลงในสไลด์ PowerPoint ได้โดยอัตโนมัติ บทความนี้แสดงวิธีสร้างเส้นเรียบง่ายและวิธีปรับแต่งเส้นให้แสดงเป็นลูกศร

คุณจะได้เรียนรู้วิธีการเพิ่มรูปทรงเส้นลงในสไลด์ ปรับลักษณะภาพลักษณ์ของมัน และบันทึกงานนำเสนอที่อัปเดต ตัวอย่างมุ่งเน้นที่การตั้งค่าการจัดรูปแบบเส้นที่ใช้งานได้จริง เช่น สไตล์ ความกว้าง รูปแบบเส้นประ ตัวเลือกหัวลูกศร และสีเติม

## **Create a Plain Line**

เพื่อเพิ่มเส้นธรรมดา ๆ ลงในสไลด์ที่เลือกของงานนำเสนอ โปรดทำตามขั้นตอนต่อไปนี้：

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) 
- รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน
- เพิ่ม AutoShape ประเภท Line โดยใช้เมธอด [addAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) ของอ็อบเจกต์ [IShapeCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShapeCollection)
- เขียนงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง เราได้เพิ่มเส้นลงในสไลด์แรกของงานนำเสนอ

```java
// สร้างอินสแตนซ์ของคลาส PresentationEx ที่เป็นตัวแทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // ดึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);
    
    // เพิ่ม AutoShape ประเภท line
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // เขียนไฟล์ PPTX ไปยังดิสก์
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Create an Arrow-Shaped Line**

Aspose.Slides for Android via Java ยังอนุญาตให้นักพัฒนาตั้งค่าคุณสมบัติบางอย่างของเส้นเพื่อให้ดูสวยงามยิ่งขึ้น ลองกำหนดค่าบางอย่างของเส้นเพื่อให้ดูเหมือนลูกศรตามขั้นตอนต่อไปนี้：

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) 
- รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน
- เพิ่ม AutoShape ประเภท Line โดยใช้เมธอด [addAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) ของอ็อบเจกต์ [IShapeCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShapeCollection)
- ตั้งค่า [Line Style](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/LineStyle) ให้เป็นหนึ่งในสไตล์ที่ Aspose.Slides for Android via Java มีให้
- ตั้งค่าความกว้างของเส้น
- ตั้งค่า [Dash Style](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/LineDashStyle) ของเส้นให้เป็นหนึ่งในสไตล์ที่ Aspose.Slides for Android via Java มีให้
- ตั้งค่า [Arrow Head Style](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/LineArrowheadStyle) และ [Length](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/LineArrowheadLength) ของจุดเริ่มต้นของเส้น
- ตั้งค่า [Arrow Head Style](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/LineArrowheadStyle) และ [Length](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/LineArrowheadLength) ของจุดสิ้นสุดของเส้น
- เขียนงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```java
// สร้างอินสแตนซ์ของคลาส PresentationEx ที่แสดงไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // ดึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);

    // เพิ่ม AutoShape ประเภท line
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // ใช้การจัดรูปแบบบางอย่างกับเส้น
    shp.getLineFormat().setStyle(LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);

    shp.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    shp.getLineFormat().setBeginArrowheadLength(LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.Oval);

    shp.getLineFormat().setEndArrowheadLength(LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);

    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Maroon));

    // เขียนไฟล์ PPTX ไปยังดิสก์
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Can I convert a regular line into a connector so it "snaps" to shapes?**

ไม่ได้ เส้นธรรมดา (AutoShape ประเภท Line) จะไม่กลายเป็นคอนเน็กเตอร์โดยอัตโนมัติ หากต้องการให้เส้นจับกับรูปทรง ให้ใช้ประเภท [Connector](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/connector/) พร้อม API ที่เกี่ยวข้อง (/slides/th/androidjava/connector/) สำหรับการเชื่อมต่อ

**What should I do if a line’s properties are inherited from the theme and it’s hard to determine the final values?**

ใช้ [Read the effective properties](/slides/th/androidjava/shape-effective-properties/) ผ่านอินเทอร์เฟซ [ILineFormatEffectiveData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilinefillformateffectivedata/) — อินเทอร์เฟซเหล่านี้จะคำนึงถึงการสืบทอดและสไตล์จากธีมแล้ว

**Can I lock a line against editing (moving, resizing)?**

ทำได้ Shape มี [lock objects](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/autoshape/#getAutoShapeLock--) ที่ช่วยป้องกันการแก้ไขต่าง ๆ เช่น การย้ายหรือการปรับขนาด