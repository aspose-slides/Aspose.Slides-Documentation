---
title: ปรับแต่งพื้นที่พล็อตของแผนภูมิการนำเสนอใน Python
linktitle: พื้นที่พล็อต
type: docs
url: /th/python-net/chart-plot-area/
keywords:
- แผนภูมิ
- พื้นที่พล็อต
- ความกว้างพื้นที่พล็อต
- ความสูงพื้นที่พล็อต
- ขนาดพื้นที่พล็อต
- โหมดการจัดวาง
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "ค้นพบวิธีการปรับแต่งพื้นที่พล็อตของแผนภูมิใน PowerPoint และงานนำเสนอ OpenDocument ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET ปรับปรุงภาพสไลด์ของคุณได้อย่างง่ายดาย"
---
## **ภาพรวม**

บทความนี้แสดงวิธีทำงานกับพื้นที่พล็อตของแผนภูมิใน Aspose.Slides โดยอธิบายวิธีรับตำแหน่งและขนาดจริงของพื้นที่พล็อตโดยการตรวจสอบการจัดวางแผนภูมิแล้วอ่านค่า X, Y, ความกว้าง และความสูงของมัน

นอกจากนี้ยังสาธิตวิธีกำหนดโหมดการจัดวางของพื้นที่พล็อตเมื่อการจัดวางตั้งค่าโดยมือ โดยใช้ `LayoutTargetType` เพื่อกำหนดว่าพื้นที่พล็อตจะคำนวณจากภายในหรือจากภายนอกพร้อมกับแกนและป้ายแกน

## **รับความกว้างและความสูงของพื้นที่พล็อตแผนภูมิ**
Aspose.Slides for Python via .NET มี API ที่เรียบง่ายสำหรับ .

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) 
1. เข้าถึงสไลด์แรก
1. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้น
1. เรียกเมธอด IChart.ValidateChartLayout() ก่อนเพื่อรับค่าจริง
1. รับตำแหน่ง X จริง (ซ้าย) ขององค์ประกอบแผนภูมิเกี่ยวกับมุมซ้ายบนของแผนภูมิ
1. รับตำแหน่งบนจริงขององค์ประกอบแผนภูมิสัมพันธ์กับมุมซ้ายบนของแผนภูมิ
1. รับความกว้างจริงขององค์ประกอบแผนภูมิ
1. รับความสูงจริงขององค์ประกอบแผนภูมิ

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    x = chart.plot_area.actual_x
    y = chart.plot_area.actual_y
    w = chart.plot_area.actual_width
    h = chart.plot_area.actual_height
	
	# บันทึกงานนำเสนอพร้อมแผนภูมิ
    pres.save("Chart_out.pptx", slides.export.SaveFormat.PPTX)
```




## **ตั้งค่าโหมดการจัดวางของพื้นที่พล็อตแผนภูมิ**
Aspose.Slides for Python via .NET มี API ที่เรียบง่ายเพื่อกำหนดโหมดการจัดวางของพื้นที่พล็อตแผนภูมิ คุณสมบัติ **LayoutTargetType** ถูกเพิ่มเข้าไปในคลาส **ChartPlotArea** และ **IChartPlotArea** หากการจัดวางของพื้นที่พล็อตกำหนดด้วยมือ คุณลักษณะนี้จะระบุว่าจะจัดวางพื้นที่พล็อตโดยภายใน (ไม่รวมแกนและป้ายแกน) หรือโดยภายนอก (รวมแกนและป้ายแกน) มีสองค่าที่เป็นไปได้ซึ่งกำหนดใน enum **LayoutTargetType**

- **LayoutTargetType.Inner** - ระบุว่าขนาดของพื้นที่พล็อตจะกำหนดขนาดของพื้นที่พล็อตโดยไม่รวมเครื่องหมายติ๊กและป้ายแกน
- **LayoutTargetType.Outer** - ระบุว่าขนาดของพื้นที่พล็อตจะกำหนดขนาดของพื้นที่พล็อต, เครื่องหมายติ๊ก, และป้ายแกน

โค้ดตัวอย่างแสดงด้านล่าง

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
    chart.plot_area.as_i_layoutable.x = 0.2
    chart.plot_area.as_i_layoutable.y = 0.2
    chart.plot_area.as_i_layoutable.width = 0.7
    chart.plot_area.as_i_layoutable.height = 0.7
    chart.plot_area.layout_target_type = charts.LayoutTargetType.INNER

    presentation.save("SetLayoutMode_outer.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

**หน่วยที่จริงของ actual_x, actual_y, actual_width, และ actual_height ถูกคืนค่าเป็นอะไร?**

ในหน่วยจุด; 1 นิ้ว = 72 จุด. นี่คือหน่วยพิกัดของ Aspose.Slides.

**พื้นที่พล็อตแตกต่างจากพื้นที่แผนภูมิอย่างไรในแง่ของเนื้อหา?**

พื้นที่พล็อตคือบริเวณการวาดข้อมูล (ซีรีส์, เส้นกริด, เส้นเทรนด์, ฯลฯ); ส่วนพื้นที่แผนภูมิรวมถึงองค์ประกอบโดยรอบ (หัวเรื่อง, คำอธิบาย, ฯลฯ). ในแผนภูมิ 3 มิติ, พื้นที่พล็อตยังรวมถึงผนัง/พื้นและแกนด้วย.

**ค่า X, Y, ความกว้างและความสูงของพื้นที่พล็อตจะถูกตีความอย่างไรเมื่อการจัดวางตั้งค่าเป็นมือ?**

พวกมันเป็นส่วนแบ่ง (0–1) ของขนาดโดยรวมของแผนภูมิ; ในโหมดนี้ การวางตำแหน่งอัตโนมัติจะถูกปิดและใช้ส่วนแบ่งที่คุณตั้งค่า.

**ทำไมตำแหน่งของพื้นที่พล็อตจึงเปลี่ยนหลังจากเพิ่ม/ย้ายคำอธิบาย?**

คำอธิบายอยู่ในพื้นที่แผนภูมิที่อยู่นอกพื้นที่พล็อตแต่มีผลต่อการจัดวางและพื้นที่ที่ใช้ได้ จึงทำให้พื้นที่พล็อตอาจย้ายเมื่อมีการวางตำแหน่งอัตโนมัติ (นี่เป็นพฤติกรรมมาตรฐานของแผนภูมิ PowerPoint).