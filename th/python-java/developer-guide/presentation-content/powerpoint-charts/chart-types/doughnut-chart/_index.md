---
title: ปรับแต่งแผนภูมิ Doughnut ในงานนำเสนอโดยใช้ Python ผ่าน Java
linktitle: แผนภูมิ Doughnut
type: docs
weight: 30
url: /th/python-java/doughnut-chart/
keywords:
- แผนภูมิ doughnut
- ช่องว่างศูนย์กลาง
- ขนาดรู
- PowerPoint
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "ค้นพบวิธีการสร้างและปรับแต่งแผนภูมิ doughnut ใน Aspose.Slides สำหรับ Python ผ่าน Java รองรับรูปแบบ PowerPoint สำหรับงานนำเสนอที่เป็นไดนามิก"
---
## **Overview**

บทความนี้แสดงวิธีการทำงานกับแผนภูมิ doughnut ใน Aspose.Slides โดยการเพิ่มแผนภูมิเข้าสไลด์ ตั้งค่าขนาดของรูตรงกลาง และบันทึกงานนำเสนอ มุ่งเน้นที่เมธอด [setDoughnutHoleSize](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartseriesgroup/#setDoughnutHoleSize) และสาธิตขั้นตอนพื้นฐานที่จำเป็นสำหรับการปรับแต่งประเภทแผนภูมินี้ด้วยโค้ด

บทความยังรวมส่วน FAQ สั้น ๆ ที่ครอบคลุมสถานการณ์ที่เกี่ยวข้องกับแผนภูมิ doughnut เช่น การใช้หลาย series เพื่อสร้างหลายวง, การทำแผนภูมิ doughnut แบบ exploded, และการส่งออกแผนภูมิเป็นรูปภาพ raster หรือ SVG

## **Specify the Center Gap in a Doughnut Chart**

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java รองรับการกำหนดขนาดของรูในแผนภูมิ doughnut ส่วนนี้จะแสดงวิธีการกำหนดขนาดของรูด้วยตัวอย่าง
{{% /alert %}}

เพื่อกำหนดขนาดของรูในแผนภูมิ doughnut ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างวัตถุ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)  
1. เพิ่มแผนภูมิ doughnut ลงในสไลด์  
1. ระบุขนาดของรูในแผนภูมิ doughnut  
1. เขียนงานนำเสนอไปยังดิสก์

ตัวอย่างต่อไปนี้ตั้งค่าขนาดของรูในแผนภูมิ doughnut

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# สร้างอินสแตนซ์ของคลาส Presentation.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400)
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(jpype.JByte(90))

    # เขียนงานนำเสนอลงดิสก์.
    presentation.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Can I create a multi-level doughnut with multiple rings?**

ได้ คุณสามารถเพิ่มหลาย series ลงในแผนภูมิ doughnut เดียว—แต่ละ series จะกลายเป็นวงแยกจากกัน ลำดับของวงกำหนดโดยลำดับของ series ในคอลเลกชัน

**Is an "exploded" doughnut (separated slices) supported?**

ได้ มีประเภทแผนภูมิ Exploded Doughnut [chart type](https://reference.aspose.com/slides/th/python-java/aspose.slides/charttype/) และคุณสมบัติ explosion บน data points; คุณสามารถแยกแต่ละส่วนได้

**How can I get an image of a doughnut chart (PNG/SVG) for a report?**

แผนภูมิเป็น [shape](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/) คุณสามารถเรนเดอร์เป็น [raster image](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getImage) หรือส่งออกแผนภูมิเป็นภาพ SVG ได้