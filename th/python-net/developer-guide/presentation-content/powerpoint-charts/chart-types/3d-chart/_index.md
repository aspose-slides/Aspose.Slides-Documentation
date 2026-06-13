---
title: ปรับแต่งแผนภูมิ 3 มิติในงานนำเสนอด้วย Python
linktitle: แผนภูมิ 3 มิติ
type: docs
url: /th/python-net/3d-chart/
keywords:
- แผนภูมิ 3 มิติ
- การหมุน
- ความลึก
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีสร้างและปรับแต่งแผนภูมิ 3 มิติใน Aspose.Slides สำหรับ Python ผ่าน .NET พร้อมการรองรับไฟล์ PPT, PPTX และ ODP — เพิ่มศักยภาพให้งานนำเสนอของคุณวันนี้."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีปรับแต่งแผนภูมิ 3 มิติใน Aspose.Slides โดยกำหนดค่าการตั้งค่า `rotation_3d` เช่น `rotation_x`, `rotation_y`, `depth_percents` และ `right_angle_axes`. มันอธิบายขั้นตอนการสร้างงานนำเสนอ, การเพิ่มแผนภูมิ 3 มิติด้วยข้อมูลเริ่มต้น, การใช้การตั้งค่ามุมมอง 3 มิติที่จำเป็น, และการบันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

## **ตั้งค่าคุณสมบัติ RotationX, RotationY และ DepthPercents ของแผนภูมิ 3D**

Aspose.Slides for Python via .NET มี API ที่ง่ายสำหรับการตั้งค่าคุณสมบัติเหล่านี้. บทความต่อไปนี้จะช่วยคุณในการตั้งค่าต่างๆ เช่น การหมุน X, Y, **DepthPercents** เป็นต้น. ตัวอย่างโค้ดจะใช้การตั้งค่าคุณสมบัติดังกล่าว.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) .
2. เข้าถึงสไลด์แรก.
3. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้น.
4. ตั้งค่าคุณสมบัติ Rotation3D.
5. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# สร้างอินสแตนซ์ของคลาส Presentation
with slides.Presentation() as presentation:
            
    # เข้าถึงสไลด์แรก
    slide = presentation.slides[0]

    # เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้น
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    # ตั้งค่าดัชนีของแผ่นข้อมูลแผนภูมิ
    defaultWorksheetIndex = 0

    # รับแผ่นงานข้อมูลแผนภูมิ
    fact = chart.chart_data.chart_data_workbook

    # เพิ่มซีรีส์
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.type)

    # เพิ่มประเภท
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"))

    # ตั้งค่าคุณสมบัติ Rotation3D
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    # ดึงซีรีส์ที่สองของแผนภูมิ
    series = chart.chart_data.series[1]

    # ตอนนี้กำลังเพิ่มข้อมูลให้ซีรีส์
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 2, 60))

    # ตั้งค่า OverLap เป็น 100         

    series.parent_series_group.overlap = 100         

    # บันทึกงานนำเสนอลงดิสก์
    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

**ประเภทแผนภูมิใดบ้างที่รองรับโหมด 3D ใน Aspose.Slides?**

Aspose.Slides รองรับรูปแบบ 3D ของแผนภูมิคอลัมน์ รวมถึง Column 3D, Clustered Column 3D, Stacked Column 3D, และ 100% Stacked Column 3D พร้อมกับประเภท 3D ที่เกี่ยวข้องซึ่งเปิดให้ใช้ผ่านการสืบค้นของ enumeration [ChartType](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/charttype/). สำหรับรายการที่แม่นยำและเป็นปัจจุบันที่สุด ให้ตรวจสอบสมาชิกของ [ChartType](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/charttype/) ในเอกสารอ้างอิง API ของเวอร์ชันที่คุณติดตั้ง.

**ฉันสามารถรับภาพแรสเตอร์ของแผนภูมิ 3D สำหรับรายงานหรือเว็บได้หรือไม่?**

ใช่ คุณสามารถส่งออกแผนภูมิเป็นภาพได้ผ่าน [chart API](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chart/get_image/) หรือ [render the entire slide](/slides/th/python-net/convert-powerpoint-to-png/) เป็นรูปแบบเช่น PNG หรือ JPEG. สิ่งนี้มีประโยชน์เมื่อคุณต้องการดูตัวอย่างที่พิกเซลสมบูรณ์หรือฝังแผนภูมิลงในเอกสาร, แดชบอร์ด, หรือหน้าเว็บโดยไม่ต้องใช้ PowerPoint.

**การสร้างและเรนเดอร์แผนภูมิ 3D ขนาดใหญ่มีประสิทธิภาพแค่ไหน?**

ประสิทธิภาพขึ้นอยู่กับปริมาณข้อมูลและความซับซ้อนของภาพ. เพื่อให้ได้ผลลัพธ์ดีที่สุด ควรลดเอฟเฟกต์ 3D ลงให้น้อยที่สุด, หลีกเลี่ยงพื้นผิวที่มีเทกซ์เจอร์หนาแน่นบนผนังและพื้นที่แผนภูมิ, จำกัดจำนวนจุดข้อมูลต่อซีรีส์เมื่อเป็นไปได้, และเรนเดอร์เป็นขนาดเอาต์พุตที่เหมาะสม (ความละเอียดและมิติ) เพื่อให้ตรงกับการแสดงผลหรือการพิมพ์เป้าหมาย.