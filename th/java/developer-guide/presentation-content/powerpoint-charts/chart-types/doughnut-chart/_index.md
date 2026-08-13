---
title: ปรับแต่งแผนภูมิโดนัทในงานนำเสนอโดยใช้ Java
linktitle: แผนภูมิโดนัท
type: docs
weight: 30
url: /th/java/doughnut-chart/
keywords:
- แผนภูมิโดนัท
- ช่องว่างศูนย์กลาง
- ขนาดรู
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ค้นหาวิธีสร้างและปรับแต่งแผนภูมิโดนัทใน Aspose.Slides for Java รองรับรูปแบบ PowerPoint สำหรับงานนำเสนอที่ไดนามิก"
---
## **ภาพรวม**

บทความนี้แสดงวิธีการทำงานกับแผนภูมิโดนัทใน Aspose.Slides โดยการเพิ่มแผนภูมิลงในสไลด์ ตั้งขนาดของรูศูนย์กลาง และบันทึกงานนำเสนอ มุ่งเน้นที่เมธอด `setDoughnutHoleSize` และสาธิตขั้นตอนพื้นฐานที่จำเป็นในการปรับแต่งประเภทแผนภูมินี้ด้วยโค้ด

นอกจากนี้ยังมีส่วนคำถามที่พบบ่อยสั้น ๆ ครอบคลุมสถานการณ์ที่เกี่ยวข้องกับแผนภูมิโดนัท เช่น การใช้หลายซีรีส์เพื่อสร้างหลายวง การทำงานกับแผนภูมิโดนัทที่แยกส่วนออก และการส่งออกแผนภูมิเป็นภาพแบบราสเตอร์หรือ SVG

## **ระบุช่องว่างศูนย์กลางในแผนภูมิโดนัท**
{{% alert color="info" %}} 
Aspose.Slides for Java ตอนนี้รองรับการระบุขนาดของรูในแผนภูมิโดนัท ในหัวข้อนี้ เราจะดูตัวอย่างวิธีการระบุขนาดของรูในแผนภูมิโดนัท
{{% /alert %}} 

เพื่อระบุขนาดของรูในแผนภูมิโดนัท โปรดทำตามขั้นตอนด้านล่าง:

1. สร้างอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation)
1. เพิ่มแผนภูมิโดนัทบนสไลด์
1. ระบุขนาดของรูในแผนภูมิโดนัท
1. เขียนงานนำเสนอลงดิสก์

ในตัวอย่างด้านล่าง เราได้ตั้งค่าขนาดของรูในแผนภูมิโดนัท

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // เขียนงานนำเสนอลงดิสก์
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

### ฉันสามารถสร้างโดนัทหลายระดับที่มีหลายวงได้หรือไม่?

ใช่. เพิ่มหลายซีรีส์ลงในแผนภูมิโดนัทเดียว—แต่ละซีรีส์จะกลายเป็นวงแยกต่างหาก ลำดับของวงจะกำหนดโดยลำดับของซีรีส์ในคอลเลกชัน

### รองรับโดนัทแบบ "exploded" (สไลซ์แยก) หรือไม่?

ใช่. มีประเภทแผนภูมิ Exploded Doughnut [chart type](https://reference.aspose.com/slides/th/java/com.aspose.slides/charttype/) และคุณสมบัติ explosion บนจุดข้อมูล; คุณสามารถแยกสไลซ์แต่ละอันได้

### ฉันจะได้ภาพของแผนภูมิโดนัท (PNG/SVG) สำหรับรายงานได้อย่างไร?

แผนภูมิเป็นรูปแบบ; คุณสามารถเรนเดอร์เป็น [raster image](https://reference.aspose.com/slides/th/java/com.aspose.slides/shape/#getImage-int-float-float-) หรือส่งออกแผนภูมิเป็น [SVG image](https://reference.aspose.com/slides/th/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).