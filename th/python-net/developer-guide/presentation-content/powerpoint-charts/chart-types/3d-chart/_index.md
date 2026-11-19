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
- งานนำเสนอ
- Python
- Aspose.Slides
description: "สร้างแผนภูมิ 3 มิติในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET. ปรับการหมุน, อัตราส่วนความสูง, ความลึกของแผนภูมิ, และช่องว่างระหว่างซีรีส์ด้วยตัวอย่าง Python."
---
## **ภาพรวม**

Aspose.Slides for Python via .NET ให้คุณปรับแต่งมุมมองของแผนภูมิ 3 มิติผ่านคุณสมบัติ [Chart.rotation_3d](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/rotation_3d/) บทความนี้แสดงวิธีปรับการหมุน, อัตราส่วนความสูง, ความลึก, แกนมุมฉาก, และช่องว่างระหว่างซีรีส์, แล้วบันทึกงานนำเสนอเป็นรูปแบบ PPTX

## **ตั้งการหมุนและความลึกของแผนภูมิ 3 มิติ**

ตัวอย่างด้านล่างสร้าง [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) และใช้ [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) เพื่อเพิ่มแผนภูมิคอลัมน์ 3 มิติแบบ stacked ลงในสไลด์แรกของมัน มันจะแทนที่ซีรีส์และประเภทเริ่มต้นด้วยสองซีรีส์ที่มีค่าแต่ละค่า 3 ค่า ดัชนี Worksheet `0` ระบุ Worksheet ข้อมูลแรกของแผนภูมิ; แถว `0` เก็บชื่อซีรีส์, และคอลัมน์ `0` เก็บป้ายหมวดหมู่

คุณสมบัติ [rotation_x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_x/) และ [rotation_y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_y/) ตั้งค่าการหมุนของแผนภูมิเป็น 40 และ 270 องศาตามลำดับ [depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) ตั้งค่าความลึกเป็น 150% ของความกว้าง, ขณะที่ [right_angle_axes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/right_angle_axes/) เปิดใช้งานแกนมุมฉากแทนการมองแบบ perspective งานนำเสนอที่ได้จะมีแผนภูมิที่เติมข้อมูลพร้อมการตั้งค่ามุมมอง 3 มิติเหล่านี้

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    
    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.get_cell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.chart_data.categories.add(category_cell)

    for series_index in range(2):
        series_cell = workbook.get_cell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.chart_data.series.add(series_cell, chart.type)

        for category_index in range(3):
            value_cell = workbook.get_cell(worksheet_index, category_index + 1, series_index + 1, values[series_index][category_index])
            series.data_points.add_data_point_for_bar_series(value_cell)

    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ปรับอัตราส่วนความสูงของแผนภูมิ 3 มิติ**

ใช้ [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) เพื่อกำหนดความสูงของแผนภูมิ 3 มิติเป็นเปอร์เซ็นต์ของความกว้าง วิธีนี้จะเปลี่ยนอัตราส่วนของฉาก 3 มิติโดยไม่ต้องเปลี่ยนขนาดของวัตถุแผนภูมิบนสไลด์

ตัวอย่างต่อไปนี้สร้างแผนภูมิ [COLUMN_3D](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) ด้วยข้อมูลเริ่มต้น: สามซีรีส์และสี่หมวดหมู่ มันบันทึกงานนำเสนอสามไฟล์ที่มีอัตราส่วนความสูง 50%, 100% และ 200% ตำแหน่ง, ความกว้าง, และความสูงของแผนภูมิยังคงคงที่ ข้อมูล, การหมุน, ความลึก, ช่องว่างระหว่างซีรีส์, และการจัดรูปแบบทั้งหมดเหมือนกันในสามไฟล์; มีเพียงเปอร์เซ็นต์ความสูงที่เปลี่ยน

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 40, 30, 620, 460)
    chart.rotation_3d.rotation_x = 20
    chart.rotation_3d.rotation_y = 30
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.depth_percents = 100
    chart.chart_data.series[0].parent_series_group.gap_depth = 150

    for height_percent in (50, 100, 200):
        chart.rotation_3d.height_percents = height_percent
        presentation.save(f"chart_height_{height_percent}.pptx", slides.export.SaveFormat.PPTX)
```

ภาพต่อไปนี้ถูกส่งออกจากงานนำเสนอที่สร้างโดยใช้ Microsoft PowerPoint เปอร์เซ็นต์ที่น้อยลงทำให้ฉากแบนลง, ส่วนเปอร์เซ็นต์ที่มากขึ้นทำให้ฉากสูงขึ้นภายในวัตถุแผนภูมิเดียวกัน PowerPoint อาจปรับช่วงการทำเครื่องหมายของแกนและตำแหน่งป้ายกำกับเพื่อให้พอดีกับฉาก

| ความสูง: 50% | ความสูง: 100% | ความสูง: 200% |
| --- | --- | --- |
| ![แผนภูมิคอลัมน์ 3 มิติที่ตั้งความสูงเป็น 50% ของความกว้างของมัน](height_percent_50.png) | ![แผนภูมิคอลัมน์ 3 มิติที่ตั้งความสูงเป็น 100% ของความกว้างของมัน](height_percent_100.png) | ![แผนภูมิคอลัมน์ 3 มิติที่ตั้งความสูงเป็น 200% ของความกว้างของมัน](height_percent_200.png) |

คุณสมบัติเหล่านี้ควบคุมแง่มุมต่าง ๆ ของแผนภูมิ:

| คุณสมบัติ | ผลลัพธ์ |
| --- | --- |
| [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) | ความสูงของฉาก 3 มิติเป็นเปอร์เซ็นต์ของความกว้าง |
| [Chart.height](https://reference.aspose.com/slides/python-net/aspose.slides/shape/height/) | ความสูงของวัตถุแผนภูมิบนสไลด์, หน่วยเป็น point |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | ความลึกของฉาก 3 มิติเป็นเปอร์เซ็นต์ของความกว้าง |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | ช่องว่างระหว่างซีรีส์ตามแกนความลึก, เป็นเปอร์เซ็นต์ของความกว้างของมาร์คเกอร์ |

การตั้งค่านี้ส่งผลกับแผนภูมิคอลัมน์และแผนภูมิแท่ง 3 มิติรวมถึงรูปแบบทรงกระบอก, รูปกรวย, และรูปพีระมิด, รวมถึงแผนภูมิเส้น, พื้นที่, พาย, และพื้นผิว 3 มิติ การเปรียบเทียบด้านบนใช้ประเภท `COLUMN_3D` ที่ตรวจสอบแล้ว การตั้งค่าไม่ได้เปลี่ยนลักษณะของแผนภูมิ 2 มิติ `CLUSTERED_COLUMN` หรือแผนภูมิ `BUBBLE_WITH_3D`; ชื่อเหล่านี้เป็นสมาชิกของ enum [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) สำหรับการตั้งค่าลักษณะแผนภูมิอื่น ๆ ดูที่ [Chart Formatting](/slides/th/python-net/chart-formatting/)

## **ปรับช่องว่างระหว่างซีรีส์**

ใช้ [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) เพื่อควบคุมระยะห่างระหว่างซีรีส์ข้อมูลตามแกนความลึกของแผนภูมิ 3 มิติ, แสดงเป็นเปอร์เซ็นต์ของความกว้างมาร์คเกอร์ ใช้ค่าจาก **0 ถึง 500**, รวม: `0` ลบช่องว่าง, ค่าที่มากขึ้นเพิ่มช่องว่าง ด้วยความลึกของแผนภูมิคงที่ การเพิ่มช่องว่างทำให้มาร์คเกอร์บางลงตามแกนความลึก

เข้าถึงกลุ่มผ่าน [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) การตั้งค่านี้ใช้กับทุกซีรีส์ในกลุ่มนั้น, ไม่ได้จำกัดแค่ซีรีส์ที่ใช้เพื่อเข้าถึงมัน [ChartSeries.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_depth/) เป็นแบบอ่านอย่างเดียวและสะท้อนการตั้งค่าของกลุ่มแม่

การตั้งค่านี้ส่งผลกับแผนภูมิคอลัมน์และแท่ง 3 มิติรวมถึงรูปแบบทรงกระบอก, รูปกรวย, และรูปพีระมิด, รวมถึงแผนภูมิเส้นและพื้นที่ 3 มิติ ลักษณะของแผนภูมิขึ้นอยู่กับว่า ซีรีส์ถูกจัดเรียงตามความลึก, เป็นกลุ่ม, หรือเป็น stacked สำหรับการเปรียบเทียบช่องว่างระหว่างซีรีส์แยกต่างหากอย่างชัดเจน ใช้ `ChartType.COLUMN_3D` จาก enum [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/)

คุณสมบัติเหล่านี้ควบคุมแง่มุมต่าง ๆ ของแผนภูมิ:

| คุณสมบัติ | ผลลัพธ์ |
| --- | --- |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | ช่องว่างระหว่างซีรีส์ตามแกนความลึก, เป็นเปอร์เซ็นต์ของความกว้างมาร์คเกอร์ |
| [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) | ช่องว่างระหว่างกลุ่มแท่งหรือคอลัมน์ที่อยู่ติดกัน, เป็นเปอร์เซ็นต์ของความกว้างแท่งหรือคอลัมน์ |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | ความลึกโดยรวมของแผนภูมิ, เป็นเปอร์เซ็นต์ของความกว้างแผนภูมิ |

ตัวอย่างต่อไปนี้เป็นตัวอย่างที่รวมทุกอย่างในตัวโดยใช้ข้อมูลแผนภูมิเบื้องต้นที่มีสามซีรีส์และสี่หมวดหมู่ มันบันทึกงานนำเสนอสองไฟล์ที่มีข้อมูล, การหมุน, ความกว้างช่องว่าง, และความลึกแผนภูมิเดียวกัน; มีเพียงความลึกของช่องว่างที่เปลี่ยน

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 40, 30, 620, 230)

    chart.rotation_3d.rotation_x = 20
    chart.rotation_3d.rotation_y = 30
    chart.rotation_3d.depth_percents = 100

    series = chart.chart_data.series[0]
    group = series.parent_series_group
    group.gap_width = 150

    for gap_depth in (0, 500):
        group.gap_depth = gap_depth
        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, slides.export.SaveFormat.PPTX)
```

ภาพต่อไปนี้ถูกส่งออกจากงานนำเสนอที่สร้างโดยใช้ Microsoft PowerPoint

| ความลึกช่องว่าง: 0% | ความลึกช่องว่าง: 500% |
| --- | --- |
| ![แผนภูมิคอลัมน์ 3 มิติที่ไม่มีช่องว่างระหว่างซีรีส์ตามแกนความลึก](gap_depth_0.png) | ![แผนภูมิคอลัมน์ 3 มิติที่มีช่องว่าง 500% ระหว่างซีรีส์ตามแกนความลึก](gap_depth_500.png) |

## **เปลี่ยนประเภทซีรีส์ 3 มิติและรูปแบบแท่ง**

ในแผนภูมิทรงกระบอกแบบ clustered, ซีรีส์แรกเริ่มต้นด้วยแท่งทรงกระบอก ตัวอย่างอ่านค่า [ChartSeries.type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/type/) และ [ChartSeries.bar_3d_shape](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/bar_3d_shape/) ก่อนและหลังแต่ละการเปลี่ยนแปลง

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_CYLINDER, 20, 20, 500, 300)
    series = chart.chart_data.series[0]
    
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    series.type = charts.ChartType.CLUSTERED_CONE
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    series.bar_3d_shape = charts.ChartShapeType.BOX
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    presentation.save("series_shape.pptx", slides.export.SaveFormat.PPTX)
```

| การเปลี่ยนแปลงที่ซีรีส์แรก | `type` | `bar_3d_shape` |
| --- | --- | --- |
| สร้างแผนภูมิ | `CLUSTERED_CYLINDER` | `CYLINDER` |
| ตั้งค่า `type` เป็น `CLUSTERED_CONE` | `CLUSTERED_CONE` | `CONE` |
| ตั้งค่า `bar_3d_shape` เป็น `BOX` | `CLUSTERED_COLUMN_3D` | `BOX` |

การตั้งค่าให้รูปทรงเป็น `BOX` จะเปลี่ยนประเภทซีรีส์เป็น `CLUSTERED_COLUMN_3D` หากโค้ดของคุณมีการสาขาตามประเภทซีรีส์, ให้อ่าน `series.type` หลังจากเปลี่ยนรูปทรง ค่าเก่า ๆ ที่เก็บไว้ก่อนการกำหนดจะยังเลือกสาขา `CLUSTERED_CONE` อยู่

![การเปรียบเทียบใน PowerPoint แสดงซีรีส์แรกเป็นทรงกระบอก, รูปกรวย, และคอลัมน์สี่เหลี่ยมจากซ้ายไปขวา](series-shapes.png)

## **FAQ**

**ประเภทแผนภูมิใดบ้างที่รองรับโหมด 3 มิติใน Aspose.Slides?**

Aspose.Slides รองรับรูปแบบ 3 มิติของแผนภูมิคอลัมน์, รวมถึง Column 3D, Clustered Column 3D, Stacked Column 3D, และ 100% Stacked Column 3D พร้อมประเภท 3 มิติที่เกี่ยวข้องที่เปิดเผยผ่าน enum [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) สำหรับรายการที่แม่นยำและเป็นปัจจุบัน, ตรวจสอบสมาชิกของ [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) ในเอกสาร API ของเวอร์ชันที่ติดตั้ง

**ฉันสามารถรับภาพเรสเตอร์ของแผนภูมิ 3 มิติสำหรับรายงานหรือเว็บได้หรือไม่?**

ได้ คุณสามารถส่งออกรูปภาพของแผนภูมิด้วย [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) หรือ [render the entire slide](/slides/th/python-net/convert-powerpoint-to-png/) ไปยังรูปแบบเช่น PNG หรือ JPEG สิ่งนี้มีประโยชน์เมื่อคุณต้องการพรีวิวแบบเรสเตอร์หรือฝังแผนภูมิในเอกสาร, แดชบอร์ด, หรือหน้าเว็บโดยไม่ต้องอาศัย PowerPoint

**ประสิทธิภาพการสร้างและเรนเดอร์แผนภูมิ 3 มิติขนาดใหญ่เป็นอย่างไร?**

ประสิทธิภาพขึ้นกับปริมาณข้อมูลและความซับซ้อนของภาพ เพื่อให้ได้ผลดีที่สุด, ควรจำกัดเอฟเฟกต์ 3 มิติ, หลีกเลี่ยงเทกซ์เจอร์หนักบนผนังและพื้นที่พล็อต, จำกัดจำนวนจุดข้อมูลต่อซีรีส์เมื่อเป็นไปได้, และเรนเดอร์เป็นขนาดเอาต์พุตที่เหมาะสม (ความละเอียดและมิติ) ให้ตรงกับหน้าจอหรือความต้องการพิมพ์.