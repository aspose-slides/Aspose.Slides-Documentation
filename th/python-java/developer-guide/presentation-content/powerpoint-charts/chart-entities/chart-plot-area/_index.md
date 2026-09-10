---
title: ปรับแต่งพื้นที่พล็อตของแผนภูมิในงานนำเสนอด้วย Python
linktitle: พื้นที่พล็อต
type: docs
url: /th/python-java/chart-plot-area/
keywords:
- แผนภูมิ
- พื้นที่พล็อต
- ความกว้างของพื้นที่พล็อต
- ความสูงของพื้นที่พล็อต
- ขนาดของพื้นที่พล็อต
- โหมดการจัดเค้าโครง
- PowerPoint
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "ค้นพบวิธีการปรับแต่งพื้นที่พล็อตของแผนภูมิในงานนำเสนอ PowerPoint ด้วย Aspose.Slides for Python via Java. ปรับปรุงภาพสไลด์ของคุณได้อย่างง่ายดาย."
---
## **ภาพรวม**

บทความนี้แสดงวิธีทำงานกับพื้นที่พล็อตของแผนภูมิใน Aspose.Slides โดยอธิบายวิธีการรับตำแหน่งและขนาดจริงของพื้นที่พล็อตโดยการตรวจสอบเค้าโครงแผนภูมิแล้วอ่านค่า X, Y, ความกว้าง และความสูง

นอกจากนี้ยังสาธิตวิธีกำหนดค่าโหมดเค้าโครงของพื้นที่พล็อตเมื่อกำหนดเค้าโครงด้วยตนเอง โดยใช้ [LayoutTargetType](https://reference.aspose.com/slides/th/python-java/aspose.slides/layouttargettype/) เพื่อระบุว่าพื้นที่พล็อตจะคำนวณจากบริเวณภายในหรือจากบริเวณภายนอกพร้อมกับแกนและป้ายแกน

## **รับความกว้างและความสูงของพื้นที่พล็อตแผนภูมิ**

Aspose.Slides for Python via Java มี API อย่างง่ายสำหรับการอ่านตำแหน่งและขนาดจริงของพื้นที่พล็อตของแผนภูมิ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์แรก
3. เพิ่มแผนภูมิพร้อมข้อมูลค่าเริ่มต้น
4. เรียกเมธอด [Chart.validateChartLayout](https://reference.aspose.com/slides/th/python-java/aspose.slides/chart/#validateChartLayout) ก่อนการรับค่าแท้จริง
5. รับตำแหน่ง X แท้จริง (ซ้าย) ขององค์ประกอบแผนภูมิสัมพันธ์กับมุมซ้ายบนของแผนภูมิ
6. รับตำแหน่ง Y แท้จริง (บน) ขององค์ประกอบแผนภูมิสัมพันธ์กับมุมซ้ายบนของแผนภูมิ
7. รับความกว้างแท้จริงขององค์ประกอบแผนภูมิ
8. รับความสูงแท้จริงขององค์ประกอบแผนภูมิ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

# สร้างอินสแตนซ์ของคลาส Presentation.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350)
    chart.validateChartLayout()

    plot_area = chart.getPlotArea()
    x = plot_area.getActualX()
    y = plot_area.getActualY()
    width = plot_area.getActualWidth()
    height = plot_area.getActualHeight()
finally:
    presentation.dispose()
```

## **ตั้งค่าโหมดเค้าโครงของพื้นที่พล็อตแผนภูมิ**

Aspose.Slides for Python via Java มี API อย่างง่ายเพื่อกำหนดค่าโหมดเค้าโครงของพื้นที่พล็อตแผนภูมิ เมธอด [setLayoutTargetType](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartplotarea/#setLayoutTargetType) และ [getLayoutTargetType](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartplotarea/#getLayoutTargetType) มีอยู่ในคลาส [ChartPlotArea](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartplotarea/) หากกำหนดเค้าโครงของพื้นที่พล็อตด้วยตนเอง การตั้งค่านี้จะระบุว่าจัดวางพื้นที่พล็อตโดยด้านใน (ไม่รวมแกนและป้ายแกน) หรือด้านนอก (รวมแกนและป้ายแกน) มีค่าได้สองค่าที่กำหนดใน enumeration ของ [LayoutTargetType](https://reference.aspose.com/slides/th/python-java/aspose.slides/layouttargettype/)

- [Inner](https://reference.aspose.com/slides/th/python-java/aspose.slides/layouttargettype/#Inner) ระบุว่าขนาดพื้นที่พล็อตไม่รวมเครื่องหมายติ๊กและป้ายแกน
- [Outer](https://reference.aspose.com/slides/th/python-java/aspose.slides/layouttargettype/#Outer) ระบุว่าขนาดพื้นที่พล็อตรวมเครื่องหมายติ๊กและป้ายแกน

ตัวอย่างโค้ดแสดงด้านล่าง

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LayoutTargetType, Presentation, SaveFormat

# สร้างอินสแตนซ์ของคลาส Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    plot_area = chart.getPlotArea()
    plot_area.setX(0.2)
    plot_area.setY(0.2)
    plot_area.setWidth(0.7)
    plot_area.setHeight(0.7)
    plot_area.setLayoutTargetType(LayoutTargetType.Inner)

    presentation.save("SetLayoutMode_inner.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**หน่วยที่ใช้คืนค่าตำแหน่ง X แท้จริง, Y แท้จริง, ความกว้างแท้จริง และความสูงแท้จริงคืออะไร?**

เป็นหน่วยพอยท์; 1 นิ้ว = 72 พอยท์ ซึ่งเป็นหน่วยพิกัดของ Aspose.Slides  

**พื้นที่พล็อตแตกต่างจากพื้นที่แผนภูมิในแง่ของเนื้อหาอย่างไร?**

พื้นที่พล็อตคือพื้นที่การวาดข้อมูล (ซีรีส์, เส้นกริด, เส้นแนวโน้ม ฯลฯ) ส่วนพื้นที่แผนภูมิรวมถึงองค์ประกอบรอบข้าง (ชื่อ, เลเจนด์ ฯลฯ) สำหรับแผนภูมิ 3 มิติ พื้นที่พล็อตยังรวมถึงผนัง/พื้นและแกนด้วย  

**ตำแหน่ง X, Y, ความกว้างและความสูงของพื้นที่พล็อตถูกตีความอย่างไรเมื่อเค้าโครงกำหนดด้วยตนเอง?**

ค่าจะเป็นส่วนของ (0–1) ของขนาดโดยรวมของแผนภูมิ; ในโหมดนี้ การจัดตำแหน่งอัตโนมัติจะถูกปิดและใช้ส่วนที่คุณตั้งค่า  

**ทำไมตำแหน่งของพื้นที่พล็อตจึงเปลี่ยนแปลงหลังจากเพิ่มหรือย้ายเลเจนด์?**

เลเจนด์อยู่ในพื้นที่แผนภูมิที่อยู่นอกพื้นที่พล็อตแต่มีผลต่อเค้าโครงและพื้นที่ที่ใช้ได้ ทำให้พื้นที่พล็อตอาจเลื่อนเมื่อการจัดตำแหน่งอัตโนมัติทำงาน (เป็นพฤติกรรมมาตรฐานของแผนภูมิ PowerPoint)