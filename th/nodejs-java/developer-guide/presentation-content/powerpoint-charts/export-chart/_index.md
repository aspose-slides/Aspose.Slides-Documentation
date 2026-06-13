---
title: ส่งออกแผนภูมิการนำเสนอใน JavaScript
linktitle: ส่งออกแผนภูมิ
type: docs
weight: 90
url: /th/nodejs-java/export-chart/
keywords:
- แผนภูมิ
- แผนภูมิเป็นภาพ
- แผนภูมิเป็นภาพ
- ดึงรูปภาพแผนภูมิ
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีส่งออกแผนภูมิการนำเสนอด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java รองรับรูปแบบ PPT และ PPTX และทำให้การรายงานเป็นไปอย่างราบรื่นในกระบวนการทำงานใดๆ"
---
## **ภาพรวม**

Aspose.Slides ช่วยให้คุณส่งออกแผนภูมิจากงานนำเสนอเป็นรูปภาพ บทความนี้แสดงวิธีดึงรูปภาพจากแผนภูมิและบันทึกไว้ ซึ่งเป็นประโยชน์เมื่อคุณต้องการนำภาพแผนภูมิไปใช้ภายนอกงานนำเสนอ PowerPoint

## **รับรูปภาพแผนภูมิ**
Aspose.Slides for Node.js via Java ให้การสนับสนุนการสกัดรูปภาพของแผนภูมิเฉพาะ ตัวอย่างด้านล่างเป็นตัวอย่างที่ให้ไว้

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var slideImage = chart.getImage();
    try {
        slideImage.save("image.jpg", aspose.slides.ImageFormat.Jpeg);
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

## **คำถามที่พบบ่อย**

**ฉันสามารถส่งออกแผนภูมิเป็นเวกเตอร์ (SVG) แทนภาพเรสเตอร์ได้หรือไม่?**  
ใช่. แผนภูมิเป็นรูปทรง และเนื้อหาของมันสามารถบันทึกเป็น SVG ได้โดยใช้ [วิธีการบันทึก shape-to-SVG](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/writeassvg/).

**ฉันจะตั้งขนาดที่แน่นอนของแผนภูมิที่ส่งออกเป็นพิกเซลได้อย่างไร?**  
ใช้การโอเวอร์โหลด image-rendering ที่ให้คุณระบุขนาดหรือสเกล — ไลบรารีรองรับการเรนเดอร์ออบเจ็กต์ด้วยมิติหรือสเกลที่กำหนด

**ฉันควรทำอย่างไรหากแบบอักษรในป้ายกำกับและคำอธิบายแสดงผลผิดพลาดหลังการส่งออก?**  
[โหลดแบบอักษรที่จำเป็น](/slides/th/nodejs-java/custom-font/) ผ่าน [FontsLoader](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontsloader/) เพื่อให้การเรนเดอร์แผนภูมิคงไว้ซึ่งเมตริกซ์และลักษณะตัวอักษร

**การส่งออกรักษาธีม, สไตล์และเอฟเฟกต์ของ PowerPoint หรือไม่?**  
ใช่. ตัวเรนเดอร์ของ Aspose.Slides ปฏิบัติตามการจัดรูปแบบของงานนำเสนอ (ธีม, สไตล์, การเติม, เอฟเฟกต์) ดังนั้นลักษณะของแผนภูมิจึงถูกคงไว้

**ฉันสามารถค้นหาความสามารถในการเรนเดอร์/ส่งออกที่มีอยู่เพิ่มเติมจากรูปภาพแผนภูมิได้จากที่ไหน?**  
ดูที่ [API](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/)/[เอกสาร](/slides/th/nodejs-java/convert-powerpoint/) สำหรับเป้าหมายการส่งออก ([PDF](/slides/th/nodejs-java/convert-powerpoint-to-pdf/), [SVG](/slides/th/nodejs-java/render-a-slide-as-an-svg-image/), [XPS](/slides/th/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/th/nodejs-java/convert-powerpoint-to-html/), ฯลฯ) และตัวเลือกการเรนเดอร์ที่เกี่ยวข้อง