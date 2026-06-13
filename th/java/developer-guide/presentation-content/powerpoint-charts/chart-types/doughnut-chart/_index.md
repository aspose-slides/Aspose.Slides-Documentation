---
title: ปรับแต่งแผนภูมิ Doughnut ในการนำเสนอโดยใช้ Java
linktitle: แผนภูมิ Doughnut
type: docs
weight: 30
url: /th/java/doughnut-chart/
keywords:
- แผนภูมิ doughnut
- ช่องว่างศูนย์กลาง
- ขนาดของรู
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "ค้นพบวิธีการสร้างและปรับแต่งแผนภูมิ doughnut ใน Aspose.Slides สำหรับ Java รองรับรูปแบบ PowerPoint สำหรับการนำเสนอแบบไดนามิก"
---
## **ภาพรวม**

บทความนี้แสดงวิธีการทำงานกับแผนภูมิ doughnut ใน Aspose.Slides โดยการเพิ่มแผนภูมิลงในสไลด์ ตั้งค่าขนาดของรูศูนย์กลาง และบันทึกการนำเสนอ เน้นที่เมธอด `setDoughnutHoleSize` และสาธิตขั้นตอนพื้นฐานที่จำเป็นสำหรับการปรับแต่งประเภทแผนภูมินี้ด้วยโค้ด

บทความยังมี FAQ สั้น ๆ เกี่ยวกับสถานการณ์ที่เกี่ยวข้องกับแผนภูมิ doughnut เช่น การใช้ series หลายชุดเพื่อสร้างหลายวง การทำงานกับแผนภูมิ doughnut แบบ exploded และการส่งออกแผนภูมิเป็นภาพ raster หรือ SVG

## **กำหนดช่องว่างศูนย์กลางในแผนภูมิ Doughnut**
{{% alert color="primary" %}} 

Aspose.Slides for Java ตอนนี้รองรับการระบุขนาดของรูในแผนภูมิ doughnut ในหัวข้อนี้ เราจะดูตัวอย่างว่า วิธีการระบุขนาดของรูในแผนภูมิ doughnut อย่างไร

{{% /alert %}} 

เพื่อระบุขนาดของรูในแผนภูมิ doughnut โปรดทำตามขั้นตอนต่อไปนี้:

1. อินสแตนซ์วัตถุ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation)
1. เพิ่มแผนภูมิ doughnut บนสไลด์
1. ระบุขนาดของรูในแผนภูมิ doughnut
1. บันทึกการนำเสนอลงดิสก์

ในตัวอย่างด้านล่าง เราได้ตั้งค่าขนาดของรูในแผนภูมิ doughnut

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // บันทึกการนำเสนอลงดิสก์
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**สามารถสร้าง doughnut ระดับหลายชั้นด้วยหลายวงได้หรือไม่?**

ใช่ เพิ่ม series หลายชุดลงในแผนภูมิ doughnut เดียว—แต่ละ series จะกลายเป็นวงแยก ลำดับของวงกำหนดโดยลำดับของ series ในคอลเลกชัน

**รองรับ doughnut "exploded" (ชิ้นส่วนที่แยกออก) หรือไม่?**

ใช่ มีประเภทแผนภูมิ Exploded Doughnut [chart type](https://reference.aspose.com/slides/th/java/com.aspose.slides/charttype/) และคุณสมบัติ explosion บน data points; คุณสามารถแยกชิ้นส่วนแต่ละชิ้นได้

**จะได้ภาพของแผนภูมิ doughnut (PNG/SVG) สำหรับรายงานอย่างไร?**

แผนภูมิเป็น shape; คุณสามารถเรนเดอร์เป็น [raster image](https://reference.aspose.com/slides/th/java/com.aspose.slides/shape/#getImage-int-float-float-) หรือส่งออกแผนภูมิเป็น [SVG image](https://reference.aspose.com/slides/th/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).