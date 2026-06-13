---
title: ส่งออกแผนภูมิการนำเสนอด้วย Java
linktitle: ส่งออกแผนภูมิ
type: docs
weight: 90
url: /th/java/export-chart/
keywords:
- แผนภูมิ
- แผนภูมิเป็นภาพ
- แผนภูมิในรูปภาพ
- ดึงภาพแผนภูมิ
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีส่งออกแผนภูมิการนำเสนอด้วย Aspose.Slides สำหรับ Java รองรับรูปแบบ PPT และ PPTX และทำให้การรายงานเป็นกระบวนการอัตโนมัติในทุกเวิร์กโฟลว์."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณส่งออกแผนภูมิจากงานนำเสนอเป็นภาพได้ บทความนี้แสดงวิธีดึงภาพจากแผนภูมิและบันทึกไว้ ซึ่งมีประโยชน์เมื่อคุณต้องการใช้ภาพแผนภูมิซ้ำนอกงานนำเสนอ PowerPoint

นอกเหนือจากขั้นตอนการส่งออกภาพพื้นฐานแล้ว บทความยังตอบคำถามทั่วไปเกี่ยวกับการส่งออก รวมถึงการบันทึกเนื้อหาแผนภูมิเป็น SVG การควบคุมขนาดผลลัพธ์ผ่านตัวเลือกการเรนเดอร์ การโหลดฟอนต์เพื่อรักษาลักษณะของป้ายชื่อและคำอธิบาย รวมถึงการเก็บรูปแบบการนำเสนอเดิม เช่น ธีม, สไตล์, การเติมสีและเอฟเฟกต์ระหว่างการเรนเดอร์

## **รับภาพแผนภูมิ**
Aspose.Slides for Java มีการสนับสนุนการดึงภาพของแผนภูมิเฉพาะ ตัวอย่างด้านล่างนี้แสดงให้เห็น

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IImage slideImage = chart.getImage();

    try {
          slideImage.save("image.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถส่งออกแผนภูมิเป็นเวกเตอร์ (SVG) แทนภาพแรสเตอร์ได้หรือไม่?**

ใช่ แผนภูมิเป็นรูปทรง และเนื้อหาสามารถบันทึกเป็น SVG ได้โดยใช้ [shape-to-SVG saving method](https://reference.aspose.com/slides/th/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).

**ฉันจะตั้งขนาดที่แน่นอนของแผนภูมิที่ส่งออกเป็นพิกเซลได้อย่างไร?**

ใช้ overload ของการเรนเดอร์ภาพที่ให้คุณระบุขนาดหรือสเกล — ไลบรารีสนับสนุนการเรนเดอร์ออบเจ็กต์ด้วยมิติหรือสเกลที่กำหนด

**ฉันควรทำอย่างไรหากฟอนต์ในป้ายชื่อและคำอธิบายแสดงผลไม่ถูกต้องหลังการส่งออก?**

[โหลดฟอนต์ที่จำเป็น](/slides/th/java/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsloader/) เพื่อให้การเรนเดอร์แผนภูมิรักษาความแม่นยำของเมตริกและลักษณะของข้อความ

**การส่งออกให้เคารพธีมของ PowerPoint, สไตล์, และเอฟเฟกต์หรือไม่?**

ใช่ เรนเดอร์ของ Aspose.Slides ปฏิบัติตามรูปแบบของงานนำเสนอ (ธีม, สไตล์, การเติมสี, เอฟเฟกต์) ดังนั้นลักษณะของแผนภูมิจะถูกรักษาไว้

**ฉันจะค้นหาความสามารถในการเรนเดอร์/ส่งออกที่มีอยู่ นอกเหนือจากภาพแผนภูมิได้จากที่ไหน?**

ดูที่ [API](https://reference.aspose.com/slides/th/java/com.aspose.slides/)/[documentation](/slides/th/java/convert-powerpoint/) สำหรับเป้าหมายการส่งออก ([PDF](/slides/th/java/convert-powerpoint-to-pdf/), [SVG](/slides/th/java/render-a-slide-as-an-svg-image/), [XPS](/slides/th/java/convert-powerpoint-to-xps/), [HTML](/slides/th/java/convert-powerpoint-to-html/), ฯลฯ) และตัวเลือกการเรนเดอร์ที่เกี่ยวข้อง.