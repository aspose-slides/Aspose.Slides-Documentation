---
title: ปรับแต่งแผนภูมิดอนัตในงานนำเสนอบน Android
linktitle: แผนภูมิดอนัต
type: docs
weight: 30
url: /th/androidjava/doughnut-chart/
keywords:
- แผนภูมิดอนัต
- ช่องว่างศูนย์กลาง
- ขนาดรู
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ค้นพบวิธีการสร้างและปรับแต่งแผนภูมิดอนัตใน Aspose.Slides สำหรับ Android ผ่าน Java พร้อมสนับสนุนรูปแบบ PowerPoint สำหรับงานนำเสนอแบบไดนามิก"
---
## **ภาพรวม**

บทความนี้แสดงวิธีการทำงานกับแผนภูมิดอนัตใน Aspose.Slides โดยการเพิ่มแผนภูมิลงในสไลด์ กำหนดขนาดของรูศูนย์กลาง และบันทึกงานนำเสนอ โดยเน้นที่เมธอด `setDoughnutHoleSize` และสาธิตขั้นตอนพื้นฐานที่จำเป็นเพื่อปรับแต่งประเภทแผนภูมินี้ด้วยโค้ด

บทความยังรวมส่วน FAQ สั้น ๆ ที่ครอบคลุมสถานการณ์ที่เกี่ยวข้องกับแผนภูมิดอนัต เช่น การใช้หลายซีรีส์เพื่อสร้างหลายวง แผนภูมิดอนัตแบบ exploded และการส่งออกแผนภูมิเป็นรูปภาพเรสเตอร์หรือ SVG

## **กำหนดช่องว่างศูนย์กลางในแผนภูมิดอนัต**
{{% alert color="primary" %}} 

Aspose.Slides for Android via Java ตอนนี้รองรับการระบุขนาดของรูในแผนภูมิดอนัต ในหัวข้อนี้ เราจะดูตัวอย่างการระบุขนาดของรูในแผนภูมิดอนัต

{{% /alert %}} 

เพื่อกำหนดขนาดของรูในแผนภูมิดอนัต โปรดทำตามขั้นตอนด้านล่าง:

1. สร้างวัตถุ [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation)
1. เพิ่มแผนภูมิดอนัตบนสไลด์
1. ระบุขนาดของรูในแผนภูมิดอนัต
1. เขียนงานนำเสนอลงดิสก์

ในตัวอย่างด้านล่าง เราได้ตั้งค่าขนาดของรูในแผนภูมิดอนัตแล้ว

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // บันทึกงานนำเสนอลงดิสก์
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**ฉันสามารถสร้างดอนัตหลายระดับที่มีหลายวงได้หรือไม่?**

ได้ครับ เพิ่มหลายซีรีส์ลงในแผนภูมิดอนัตเดียว—แต่ละซีรีส์จะกลายเป็นวงแยกต่างหาก ลำดับของวงจะกำหนดตามลำดับของซีรีส์ในคอลเลกชัน

**รองรับดอนัตแบบ "exploded" (แยกส่วน) หรือไม่?**

ได้ครับ มีประเภทแผนภูมิ Exploded Doughnut [chart type](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/charttype/) และคุณสมบัติ explosion บนจุดข้อมูล คุณสามารถแยกชิ้นส่วนแต่ละชิ้นได้

**จะรับรูปภาพของแผนภูมิดอนัต (PNG/SVG) สำหรับรายงานได้อย่างไร?**

แผนภูมิจัดเป็น shape; คุณสามารถเรนเดอร์เป็น [raster image](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) หรือส่งออกแผนภูมิเป็นภาพ [SVG](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).