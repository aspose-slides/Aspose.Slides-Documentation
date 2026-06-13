---
title: ปรับแต่งแผนภูมิงวดโดนัทในงานนำเสนอโดยใช้ JavaScript
linktitle: แผนภูมิงวดโดนัท
type: docs
weight: 30
url: /th/nodejs-java/doughnut-chart/
keywords:
- แผนภูมิงวดโดนัท
- ช่องว่างศูนย์กลาง
- ขนาดรู
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ค้นพบวิธีสร้างและปรับแต่งแผนภูมิงวดโดนัทด้วย JavaScript และ Aspose.Slides สำหรับ Node.js รองรับรูปแบบ PowerPoint สำหรับงานนำเสนอแบบไดนามิก"
---
## **ภาพรวม**

บทความนี้แสดงวิธีการทำงานกับแผนภูมิงวดโดนัทใน Aspose.Slides โดยการเพิ่มแผนภูมิเข้าสไลด์ ตั้งค่าขนาดของรูศูนย์กลาง และบันทึกพรีเซนเทชัน เน้นที่เมธอด `setDoughnutHoleSize` และสาธิตขั้นตอนพื้นฐานที่จำเป็นสำหรับการปรับแต่งประเภทรูปแบบแผนภูมินี้ด้วยโค้ด

บทความยังรวมคำถามที่พบบ่อยสั้น ๆ ที่ครอบคลุมสถานการณ์ที่เกี่ยวข้องกับแผนภูมิงวดโดนัท เช่น การใช้หลายซีรีส์เพื่อสร้างหลายวง การทำงานกับแผนภูมิงวดโดนัทแบบ exploded และการส่งออกแผนภูมิเป็นภาพเรสเตอร์หรือ SVG

## **เปลี่ยนช่องว่างศูนย์กลางในแผนภูมิงวดโดนัท**

เพื่อระบุขนาดของรูในแผนภูมิงวดโดนัท โปรดทำตามขั้นตอนต่อไปนี้:

1. สร้างอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation) 
1. เพิ่มแผนภูมิงวดโดนัทบนสไลด์ 
1. กำหนดขนาดของช่องว่างในแผนภูมิงวดโดนัท 
1. บันทึกพรีเซนเทชันลงดิสก์ 

ในตัวอย่างด้านล่าง เราได้กำหนดขนาดของช่องว่างในแผนภูมิงวดโดนัท

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Doughnut, 50, 50, 400, 400);
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(90);
    // เขียนงานนำเสนอลงดิสก์
    pres.save("DoughnutHoleSize_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถสร้างโดนัทหลายระดับที่มีหลายวงได้หรือไม่?**

ได้ คุณสามารถเพิ่มหลายซีรีส์ลงในแผนภูมิงวดโดนัทเดียว—แต่ละซีรีส์จะกลายเป็นวงแยกต่างหาก ลำดับของวงจะกำหนดโดยลำดับของซีรีส์ในคอลเลกชัน

**โดนัทแบบ "exploded" (แยกชิ้น) รองรับหรือไม่?**

ได้ มีประเภทแผนภูมิ Exploded Doughnut และคุณสมบัติการระเบิดบนจุดข้อมูล; คุณสามารถแยกชิ้นส่วนแต่ละชิ้นได้

**ฉันจะได้ภาพของแผนภูมิงวดโดนัท (PNG/SVG) สำหรับรายงานอย่างไร?**

แผนภูมิคือรูปร่าง; คุณสามารถเรนเดอร์เป็น [raster image](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/#getImage) หรือส่งออกแผนภูมิเป็น [SVG image](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/writeassvg/) ได้.