---
title: ส่งออกแผนภูมืองานนำเสนอบน Android
linktitle: ส่งออกแผนภูมิ
type: docs
weight: 90
url: /th/androidjava/export-chart/
keywords:
- แผนภูมิ
- แผนภูมิเพื่อเป็นภาพ
- แผนภูมิเป็นภาพ
- ดึงภาพแผนภูมิ
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีส่งออกแผนภูมืองานนำเสนอด้วย Aspose.Slides สำหรับ Android ผ่าน Java รองรับรูปแบบ PPT และ PPTX พร้อมปรับกระบวนการรายงานให้เป็นอัตโนมัติในทุกเวิร์กโฟลว์."
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณส่งออกแผนภูมิจากงานนำเสนอเป็นภาพได้ บทความนี้แสดงวิธีดึงภาพจากแผนภูมิและบันทึกมัน ซึ่งมีประโยชน์เมื่อคุณต้องการนำภาพแผนภูมิกลับไปใช้ภายนอกงานนำเสนอ PowerPoint  

นอกเหนือจากขั้นตอนการส่งออกภาพพื้นฐานแล้ว บทความนี้ยังตอบคำถามทั่วไปที่เกี่ยวกับการส่งออก เช่น การบันทึกเนื้อหาแผนภูมิเป็น SVG, การควบคุมขนาดผลลัพธ์ผ่านตัวเลือกการเรนเดอร์, การโหลดแบบอักษรเพื่อรักษาลักษณะของป้ายและคำอธิบาย, และการรักษาฟอร์แมตต้นฉบับของงานนำเสนอ เช่น ธีม, สไตล์, การเติมสี, และเอฟเฟกต์ระหว่างการเรนเดอร์  

## **รับภาพแผนภูมิ**
Aspose.Slides สำหรับ Android ผ่าน Java มีการสนับสนุนการดึงภาพของแผนภูมิที่ระบุ ตัวอย่างโค้ดด้านล่างแสดงให้ดู  

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

**ฉันสามารถส่งออกแผนภูมิเป็นเวกเตอร์ (SVG) แทนภาพเรสเตอร์ได้หรือไม่?**  

ได้. แผนภูมิเป็นรูปทรง และเนื้อหาของมันสามารถบันทึกเป็น SVG ได้โดยใช้ [shape-to-SVG saving method](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).

**ฉันจะกำหนดขนาดที่แน่นอนของแผนภูมิที่ส่งออกเป็นพิกเซลได้อย่างไร?**  

ใช้ฟังก์ชัน overload ของการเรนเดอร์ภาพที่ให้คุณระบุขนาดหรือสเกล—ไลบรารีสนับสนุนการเรนเดอร์วัตถุด้วยมิติหรือสเกลที่กำหนด

**ฉันควรทำอย่างไรหากแบบอักษรในป้ายและคำอธิบายแสดงผิดพลาดหลังการส่งออก?**  

[โหลดแบบอักษรที่จำเป็น](/slides/th/androidjava/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/fontsloader/) เพื่อให้การเรนเดอร์แผนภูมิรักษาเมตริกและลักษณะของข้อความ

**การส่งออกเคารพธีม, สไตล์, และเอฟเฟกต์ของ PowerPoint หรือไม่?**  

ได้. ตัวเรนเดอร์ของ Aspose.Slides ปฏิบัติตามการฟอร์แมตของงานนำเสนอ (ธีม, สไตล์, การเติมสี, เอฟเฟกต์) ดังนั้นลักษณะของแผนภูมิจะถูกรักษาไว้

**ฉันจะพบความสามารถการเรนเดอร์/ส่งออกที่มีนอกเหนือจากภาพแผนภูมิได้จากที่ไหน?**  

ดูที่ [API](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/)/[documentation](/slides/th/androidjava/convert-powerpoint/) สำหรับเป้าหมายการส่งออก ([PDF](/slides/th/androidjava/convert-powerpoint-to-pdf/), [SVG](/slides/th/androidjava/render-a-slide-as-an-svg-image/), [XPS](/slides/th/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/th/androidjava/convert-powerpoint-to-html/), ฯลฯ) và ตัวเลือกการเรนเดอร์ที่เกี่ยวข้อง.