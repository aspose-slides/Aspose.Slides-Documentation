---
title: จัดการตัวบ่งชี้ข้อมูลแผนภูมิในงานนำเสนอด้วย Python
linktitle: ตัวบ่งชี้ข้อมูล
type: docs
url: /th/python-net/chart-data-marker/
keywords:
- แผนภูมิ
- จุดข้อมูล
- ตัวบ่งชี้
- ตัวเลือกของตัวบ่งชี้
- ขนาดตัวบ่งชี้
- ประเภทการเติม
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีปรับแต่งตัวบ่งชี้ข้อมูลแผนภูมิใน Aspose.Slides เพื่อเพิ่มประสิทธิภาพของงานนำเสนอในรูปแบบ PPT, PPTX และ ODP ด้วยตัวอย่างโค้ดที่ชัดเจน."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับตัวบ่งชี้ข้อมูลแผนภูมิใน Aspose.Slides แสดงวิธีสร้างแผนภูมิ, เข้าถึงซีรีส์และจุดข้อมูลของมัน, ใช้การเติมภาพกับตัวบ่งชี้ในระดับจุดข้อมูล, ปรับขนาดตัวบ่งชี้, และบันทึกงานนำเสนอที่อัปเดต รวมทั้งระบุว่ารูปแบบตัวบ่งชี้มาตรฐานมีให้ใช้ผ่านการนับ `MarkerStyleType` และการแสดงผลของตัวบ่งชี้จะคงอยู่เมื่อนำแผนภูมิเสียบออกเป็นรูปแบบเรสเตอร์หรือ SVG.

## **ตั้งค่าตัวบ่งชี้แผนภูมิ**
ตัวบ่งชี้สามารถตั้งค่าบนจุดข้อมูลของแผนภูมิภายในซีรีส์เฉพาะได้ เพื่อกำหนดตัวเลือกตัวบ่งชี้ของแผนภูมิ กรุณาทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/).
- สร้างแผนภูมิปริยาย.
- ตั้งค่าภาพ.
- รับซีรีส์แผนภูมิแรก.
- เพิ่มจุดข้อมูลใหม่.
- บันทึกงานนำเสนอไปยังดิสก์.

ในตัวอย่างที่ให้ไว้ด้านล่าง เราได้ตั้งค่าตัวบ่งชี้แผนภูมิในระดับจุดข้อมูล.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# สร้างอินสแตนซ์ของคลาส Presentation
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # สร้างแผนภูมิปริยาย
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 0, 0, 400, 400)

    # รับดัชนี worksheet ของข้อมูลแผนภูมิปริยาย
    defaultWorksheetIndex = 0

    # รับ worksheet ของข้อมูลแผนภูมิ
    fact = chart.chart_data.chart_data_workbook

    # ลบซีรีส์ตัวอย่าง
    chart.chart_data.series.clear()

    # เพิ่มซีรีส์ใหม่
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.type)
            
    # ตั้งค่าภาพ
    image1 = draw.Bitmap(path + "aspose-logo.jpg")
    imgx1 = presentation.images.add_image(image1)

    # ตั้งค่าภาพ
    image2 = draw.Bitmap(path + "Tulips.jpg")
    imgx2 = presentation.images.add_image(image2)

    # รับซีรีส์แผนภูมิแรก
    series = chart.chart_data.series[0]

    # เพิ่มจุดข้อมูลใหม่ (1:3) ที่นี่
    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 4.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx1

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 2.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx2

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 3.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx1

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 4, 1, 4.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx2

    # เปลี่ยนตัวบ่งชี้ของซีรีส์แผนภูมิ
    series.marker.size = 15

    # บันทึกงานนำเสนอลงดิสก์
    presentation.save("MarkOptions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

**รูปแบบตัวบ่งชี้ที่มีให้โดยตรงคืออะไร?**

รูปแบบมาตรฐานพร้อมให้ใช้ (วงกลม, สี่เหลี่ยมจัตุรัส, เพชร, สามเหลี่ยม ฯลฯ) รายการนี้ถูกกำหนดโดยการนับ [MarkerStyleType](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/markerstyletype/) หากคุณต้องการรูปแบบที่ไม่เป็นมาตรฐาน ใช้ตัวบ่งชี้ที่เติมด้วยภาพเพื่อจำลองภาพที่กำหนดเอง.

**ตัวบ่งชี้จะคงอยู่เมื่อส่งออกแผนภูมิเป็นภาพหรือ SVG หรือไม่?**

ใช่ เมื่อเรนเดอร์แผนภูมิเป็น [raster formats](/slides/th/python-net/convert-powerpoint-to-png/) หรือบันทึก [shapes as SVG](/slides/th/python-net/render-a-slide-as-an-svg-image/) ตัวบ่งชี้จะคงลักษณะและการตั้งค่าเดิมรวมถึงขนาด, การเติม, และเส้นขอบ.