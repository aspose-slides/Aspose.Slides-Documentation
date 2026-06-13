---
title: เพิ่มรูปร่างเส้นในงานนำเสนอบน Android
linktitle: เส้น
type: docs
weight: 50
url: /th/androidjava/Line/
keywords:
- เส้น
- สร้างเส้น
- เพิ่มเส้น
- เส้นธรรมดา
- กำหนดค่าเส้น
- ปรับแต่งเส้น
- สไตล์เส้นประ
- หัวลูกศร
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้การจัดการรูปแบบเส้นในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Android ค้นพบคุณสมบัติ วิธีการ และตัวอย่าง Java"
---
## **ภาพรวม**

Aspose.Slides ให้คุณเพิ่มรูปร่างเส้นลงในสไลด์ PowerPoint อย่างอัตโนมัติ บทความนี้แสดงวิธีสร้างเส้นง่ายและวิธีปรับแต่งเส้นให้ปรากฏเป็นลูกศร

คุณจะได้เรียนรู้วิธีเพิ่มรูปร่างเส้นลงในสไลด์ ปรับลักษณะการแสดงผลของมัน และบันทึกงานนำเสนอที่อัปเดต ตัวอย่างจะเน้นการตั้งค่าการจัดรูปแบบเส้นที่ใช้งานได้จริง เช่น สไตล์ ความกว้าง แบบเส้นประ ตัวเลือกหัวศร และสีเติม

## **สร้างเส้นธรรมดา**

เพื่อเพิ่มเส้นธรรมดาแบบง่ายลงในสไลด์ที่เลือกของงานนำเสนอ โปรดทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) class.
- รับอ้างอิงของสไลด์โดยใช้ Index ของมัน.
- เพิ่ม AutoShape ประเภท Line โดยใช้เมธอด [addAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) ที่เปิดให้โดยอ็อบเจ็กต์ [IShapeCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShapeCollection).
- เขียนงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX.

ในตัวอย่างที่ให้ไว้ด้านล่าง เราได้เพิ่มเส้นลงในสไลด์แรกของงานนำเสนอ

```java
// สร้างอินสแตนซ์ของคลาส PresentationEx ที่แทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // ดึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);
    
    // เพิ่ม AutoShape ชนิดเส้น
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // บันทึกไฟล์ PPTX ไปที่ดิสก์
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **สร้างเส้นรูปแบบลูกศร**

Aspose.Slides for Android via Java ยังอนุญาตให้ผู้พัฒนากำหนดคุณสมบัติบางอย่างของเส้นเพื่อให้ดูน่าสนใจยิ่งขึ้น ลองกำหนดคุณสมบัติบางอย่างของเส้นเพื่อให้ดูเหมือนลูกศร ตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) class.
- รับอ้างอิงของสไลด์โดยใช้ Index ของมัน.
- เพิ่ม AutoShape ประเภท Line โดยใช้เมธอด [addAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) ที่เปิดให้โดยอ็อบเจ็กต์ [IShapeCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShapeCollection).
- ตั้งค่า [Line Style](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/LineStyle) ให้เป็นหนึ่งในสไตล์ที่ Aspose.Slides for Android via Java มีให้.
- ตั้งค่าความกว้างของเส้น.
- ตั้งค่า [Dash Style](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/LineDashStyle) ของเส้นให้เป็นหนึ่งในสไตล์ที่ Aspose.Slides for Android via Java มีให้.
- ตั้งค่า [Arrow Head Style](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/LineArrowheadStyle) และ [Length](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/LineArrowheadLength) ของจุดเริ่มต้นของเส้น.
- ตั้งค่า [Arrow Head Style](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/LineArrowheadStyle) และ [Length](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/LineArrowheadLength) ของจุดสิ้นสุดของเส้น.
- เขียนงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX.

```java
// สร้างอินสแตนซ์ของคลาส PresentationEx ที่เป็นตัวแทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // ดึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);

    // เพิ่ม AutoShape ชนิดเส้น
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // กำหนดการจัดรูปแบบบางอย่างบนเส้น
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

**ฉันสามารถแปลงเส้นปกติเป็นคอนเน็กเตอร์เพื่อให้มัน "ติด" กับรูปทรงได้ไหม?**

No. A regular line (an [AutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/autoshape/) of type [Line](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shapetype/)) does not automatically become a connector. To make it snap to shapes, use the dedicated [Connector](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/connector/) type and the [corresponding APIs](/slides/th/androidjava/connector/) for connections.

**ฉันควรทำอย่างไรหากคุณสมบัติของเส้นถูกสืบทอดมาจากธีมและยากที่จะกำหนดค่าที่สุดท้าย?**

[Read the effective properties](/slides/th/androidjava/shape-effective-properties/) through the [ILineFormatEffectiveData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ilinefillformateffectivedata/) interfaces—these already account for inheritance and theme styles.

**ฉันสามารถล็อกเส้นเพื่อป้องกันการแก้ไข (ย้าย, ปรับขนาด) ได้ไหม?**

Yes. Shapes provide [lock objects](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/autoshape/#getAutoShapeLock--) that let you disallow editing operations.