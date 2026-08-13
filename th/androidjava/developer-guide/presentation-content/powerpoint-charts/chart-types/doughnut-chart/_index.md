---
title: ปรับแต่งแผนภูมิ Doughnut ในงานนำเสนอบน Android
linktitle: แผนภูมิ Doughnut
type: docs
weight: 30
url: /th/androidjava/doughnut-chart/
keywords:
- แผนภูมิ doughnut
- ช่องว่างตรงกลาง
- ขนาดรู
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ค้นพบวิธีสร้างและปรับแต่งแผนภูมิ doughnut ใน Aspose.Slides สำหรับ Android ผ่าน Java โดยรองรับรูปแบบ PowerPoint สำหรับงานนำเสนอแบบไดนามิก"
---
## **ภาพรวม**

บทความนี้แสดงวิธีการทำงานกับแผนภูมิ doughnut ใน Aspose.Slides โดยการเพิ่มแผนภูมิลงในสไลด์ ตั้งค่าขนาดของรูตรงกลาง และบันทึกงานนำเสนอ มุ่งเน้นที่เมธอด `setDoughnutHoleSize` และสาธิตขั้นตอนพื้นฐานที่จำเป็นสำหรับการปรับแต่งประเภทแผนภูมนี้ด้วยโค้ด

นอกจากนี้ยังมีส่วน FAQ สั้น ๆ ที่ครอบคลุมสถานการณ์ที่เกี่ยวข้องกับแผนภูมิ doughnut เช่น การใช้หลายซีรีส์เพื่อสร้างหลายวง, การทำงานกับแผนภูมิ doughnut exploded, และการส่งออกแผนภูมิเป็นภาพราสเตอร์หรือ SVG

## **ระบุช่องว่างตรงกลางในแผนภูมิ Doughnut**
{{% alert color="info" %}} 

Aspose.Slides for Android ผ่าน Java ตอนนี้รองรับการระบุขนาดของรูในแผนภูมิ doughnut ในหัวข้อนี้ เราจะดูตัวอย่างวิธีการระบุขนาดของรูในแผนภูมิ doughnut
{{% /alert %}} 

เพื่อระบุขนาดของรูในแผนภูมิ doughnut โปรดทำตามขั้นตอนด้านล่าง:

1. สร้างอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation)
1. เพิ่มแผนภูมิ doughnut บนสไลด์
1. ระบุขนาดของรูในแผนภูมิ doughnut
1. เขียนงานนำเสนอลงดิสก์

ในตัวอย่างด้านล่าง เราได้ตั้งค่าขนาดของรูในแผนภูมิ doughnut

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

### ฉันสามารถสร้าง doughnut หลายระดับพร้อมหลายวงได้หรือไม่?

ใช่. เพิ่มหลายซีรีส์ลงในแผนภูมิ doughnut เดียว—แต่ละซีรีส์จะกลายเป็นวงแยกกัน ลำดับของวงจะกำหนดโดยลำดับของซีรีส์ในคอลเลกชัน

### รองรับ doughnut แบบ "exploded" (ชิ้นส่วนแยก) หรือไม่?

ใช่. มีประเภทแผนภูมิ [ประเภทแผนภูมิ](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/charttype/) Exploded Doughnut และคุณสมบัติ explosion บนข้อมูลจุด; คุณสามารถแยกชิ้นส่วนแต่ละชิ้นได้

### ฉันจะได้ภาพของแผนภูมิ doughnut (PNG/SVG) สำหรับรายงานได้อย่างไร?

แผนภูมิเป็นรูปทรง; คุณสามารถเรนเดอร์เป็น [ภาพราสเตอร์](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) หรือส่งออกแผนภูมิเป็น [ภาพ SVG](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-)