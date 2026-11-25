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
description: "สร้างแผนภูมิ 3 มิติในงานนำเสนอ PowerPoint ด้วย Aspose.Slides for Python via .NET ปรับการหมุน, สัดส่วนความสูง, ความลึกของแผนภูมิ, และช่องว่างระหว่างชุดข้อมูลด้วยตัวอย่าง Python."
---
## **ภาพรวม**

Aspose.Slides for Python via .NET ให้คุณปรับแต่งมุมมองของแผนภูมิ 3 มิติผ่านคุณสมบัติ [Chart.rotation_3d](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/rotation_3d/) . บทความนี้แสดงวิธีปรับการหมุน, สัดส่วนความสูง, ความลึก, แกนมุมฉาก, และช่องว่างระหว่างชุดข้อมูล, แล้วบันทึกการนำเสนอเป็นรูปแบบ PPTX.

## **ตั้งค่าการหมุนและความลึกของแผนภูมิ 3 มิติ**

ตัวอย่างด้านล่างสร้าง [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) และใช้ [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) เพื่อเพิ่มแผนภูมิคอลัมน์ 3 มิติแบบ stacked ไปยังสไลด์แรกของมัน. มันแทนที่ชุดข้อมูลและประเภทเริ่มต้นด้วยสองชุดที่แต่ละชุดมีสามค่า. ดัชนี worksheet `0` ระบุ worksheet ข้อมูลแรกของแผนภูมิ; แถว `0` มีชื่อชุดข้อมูล, และคอลัมน์ `0` มีป้ายหมวดหมู่.

คุณสมบัติ [rotation_x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_x/) และ [rotation_y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_y/) ตั้งค่าการหมุนของแผนภูมิเป็น 40 และ 270 องศาตามลำดับ. [depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) ตั้งค่าความลึกเป็น 150% ของความกว้าง, ในขณะที่ [right_angle_axes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/right_angle_axes/) เปิดใช้งานแกนมุมฉากแทนมุมมองแบบ perspective. การนำเสนอที่ได้จะมีแผนภูมิที่เติมข้อมูลพร้อมการตั้งค่ามุมมอง 3 มิติเหล่านี้.

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

## **ใช้การเติมภาพบนพื้นผิวแผนภูมิ 3 มิติ**

คุณสามารถเติม [side wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/side_wall/), [back wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/), และ [floor](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/) ของแผนภูมิ 3 มิติได้อย่างอิสระ. ตั้งค่า [fill type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) ของพื้นผิวเป็น `PICTURE` และกำหนดภาพ. เพื่อให้ภาพหนึ่งสำเนาครอบพื้นผิวทั้งหมด, ตั้งค่า [picture fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/) และ [picture type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartwall/picture_type/) ของพื้นผิวเป็น `STRETCH`.

บันทึกไฟล์ [arrow.png](arrow.png) ไว้ในไดเรกทอรีทำงาน. ตัวอย่างหมุนแผนภูมิและเพิ่มค่ามากสุดบนแกนแนวตั้งเพื่อให้พื้นมองเห็นระหว่างคอลัมน์. มันทำสำเนาสไลด์สองครั้ง, แล้วใส่ลูกศรไปยังพื้นผิวที่ต่างกันในแต่ละสไลด์. แผนภูมิทั้งสามใช้ข้อมูล, มุมมอง, และพื้นหลังเดียวกัน.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 20, 30, 680, 480)
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 30
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 24

    back_slide = presentation.slides.add_clone(slide)
    floor_slide = presentation.slides.add_clone(slide)
    back_chart = back_slide.shapes[0]
    floor_chart = floor_slide.shapes[0]

    with open("arrow.png", "rb") as image_file:
        image_bytes = image_file.read()
    arrow = presentation.images.add_image(image_bytes)

    for surface in (chart.side_wall, back_chart.back_wall, floor_chart.floor):
        fill = surface.format.fill
        fill.fill_type = slides.FillType.PICTURE
        fill.picture_fill_format.picture.image = arrow
        fill.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        surface.picture_type = charts.PictureType.STRETCH

    presentation.save("chart-surfaces.pptx", slides.export.SaveFormat.PPTX)
```

Microsoft PowerPoint แสดงสไลด์สามสไลด์ดังต่อไปนี้.

| ด้านข้าง | ด้านหลัง | พื้น |
| --- | --- | --- |
| ![ลูกศรชี้เข้าสู่แผนภูมิตามด้านข้าง](side-wall.png) | ![ลูกศรชี้ไปทางขวาบนด้านหลัง](back-wall.png) | ![ลูกศรชี้ไปทางขวาบนพื้นระหว่างคอลัมน์](floor.png) |

## **ปรับสัดส่วนความสูงของแผนภูมิ 3 มิติ**

ใช้ [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) เพื่อตั้งค่าความสูงของแผนภูมิ 3 มิติเป็นเปอร์เซ็นต์ของความกว้าง. สิ่งนี้เปลี่ยนสัดส่วนของฉาก 3 มิติโดยไม่ต้องปรับขนาดวัตถุแผนภูมิบนสไลด์.

ตัวอย่างต่อไปนี้สร้างแผนภูมิ [COLUMN_3D](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) ด้วยข้อมูลเริ่มต้น: สามชุดและสี่ประเภท. มันบันทึกการนำเสนอสามไฟล์โดยมีสัดส่วนความสูง 50%, 100%, และ 200%. ตำแหน่ง, ความกว้าง, และความสูงของแผนภูมิคงที่. ข้อมูล, การหมุน, ความลึก, ช่องว่างระหว่างชุด, และการจัดรูปแบบเหมือนกันในทุกไฟล์; มีเพียงเปอร์เซ็นต์ความสูงที่เปลี่ยน.

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

ภาพต่อไปนี้ถูกส่งออกจากการนำเสนอที่สร้างโดยใช้ Microsoft PowerPoint. เปอร์เซ็นต์ที่เล็กกว่าจะทำให้ฉากแบนลง, ส่วนเปอร์เซ็นต์ที่ใหญ่กว่าจะทำให้ฉากสูงขึ้นภายในวัตถุแผนภูมิเดียวกัน. PowerPoint อาจปรับช่วงการทำเครื่องหมายแกนและตำแหน่งป้ายเพื่อให้พอดีกับฉาก.

| ความสูง: 50% | ความสูง: 100% | ความสูง: 200% |
| --- | --- | --- |
| ![แผนภูมิคอลัมน์ 3 มิติที่ตั้งค่าความสูงเป็น 50% ของความกว้าง](height_percent_50.png) | ![แผนภูมิคอลัมน์ 3 มิติที่ตั้งค่าความสูงเป็น 100% ของความกว้าง](height_percent_100.png) | ![แผนภูมิคอลัมน์ 3 มิติที่ตั้งค่าความสูงเป็น 200% ของความกว้าง](height_percent_200.png) |

คุณสมบัติเหล่านี้ควบคุมแง่มุมต่าง ๆ ของแผนภูมิ:

| คุณสมบัติ | ผล |
| --- | --- |
| [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) | ความสูงของฉาก 3 มิติเป็นเปอร์เซ็นต์ของความกว้าง |
| [Chart.height](https://reference.aspose.com/slides/python-net/aspose.slides/shape/height/) | ความสูงของวัตถุแผนภูมิบนสไลด์, หน่วยเป็นจุด |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | ความลึกของฉาก 3 มิติเป็นเปอร์เซ็นต์ของความกว้าง |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | ช่องว่างระหว่างชุดข้อมูลตามแกนความลึก, เป็นเปอร์เซ็นต์ของความกว้างของมาร์คเกอร์ |

การตั้งค่าความสูงส่งผลต่อแผนภูมิคอลัมน์และแผนภูมิแท่ง 3 มิติ, รวมถึงรูปแบบทรงกระบอก, รูปทรงกรวย, และรูปทรงพีรามิด, รวมถึงแผนภูมิเส้น, พื้นที่, พาย, และพื้นผิu 3 มิติ. การเปรียบเทียบข้างต้นใช้ประเภท `COLUMN_3D` ที่ยืนยันแล้ว. การตั้งค่านี้ไม่ได้เปลี่ยนลักษณะของแผนภูมิ 2 มิติ `CLUSTERED_COLUMN` หรือแผนภูมิ `BUBBLE_WITH_3D`; ชื่อเหล่านี้เป็นสมาชิกของ enumeration [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) . สำหรับการตั้งค่าลักษณะของแผนภูมิอื่น ๆ, ดู [การจัดรูปแบบแผนภูมิ](/slides/th/python-net/chart-formatting/).

## **ปรับระยะห่างระหว่างชุดข้อมูล**

ใช้ [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) เพื่อควบคุมระยะห่างระหว่างชุดข้อมูลตามแกนความลึกของแผนภูมิ 3 มิติ, แสดงเป็นเปอร์เซ็นต์ของความกว้างมาร์คเกอร์. ใช้ค่าตั้งแต่ **0 ถึง 500**, มีค่ารวม: `0` จะลบช่องว่าง, ค่าที่มากกว่าจะเพิ่มช่องว่าง. ด้วยความลึกแผนภูมิที่คงที่, การเพิ่มช่องว่างจะทำให้มาร์คเกอร์บางลงตามแกนความลึก.

เข้าถึงกลุ่มผ่าน [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/). การตั้งค่านี้ใช้กับทุกชุดข้อมูลในกลุ่มนั้น, ไม่ใช่เพียงชุดข้อมูลที่ใช้เข้าถึง. [ChartSeries.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_depth/) เป็นแบบอ่านอย่างเดียวและสะท้อนการตั้งค่าของกลุ่มพาเรนต์.

การตั้งค่านี้ส่งผลต่อแผนภูมิคอลัมน์และแท่ง 3 มิติ, รวมถึงรูปแบบทรงกระบอก, รูปทรงกรวย, และพีรามิด, รวมถึงแผนภูมิเส้นและพื้นที่ 3 มิติ. ลักษณะขึ้นอยู่กับว่าชุดข้อมูลจัดเรียงตามความลึก, กลุ่ม, หรือซ้อนกันอย่างไร. เพื่อการเปรียบเทียบช่องว่างระหว่างชุดข้อมูลแยกต่างหากอย่างชัดเจน, ใช้ `ChartType.COLUMN_3D` จาก enumeration [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) .

คุณสมบัติเหล่านี้ควบคุมแง่มุมต่าง ๆ ของแผนภูมิ:

| คุณสมบัติ | ผล |
| --- | --- |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | ช่องว่างระหว่างชุดข้อมูลตามแกนความลึก, เป็นเปอร์เซ็นต์ของความกว้างมาร์คเกอร์ |
| [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) | ช่องว่างระหว่างคลัสเตอร์ของแท่งหรือคอลัมน์ที่อยู่ติดกัน, เป็นเปอร์เซ็นต์ของความกว้างแท่งหรือคอลัมน์ |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | ความลึกรวมของแผนภูมิ, เป็นเปอร์เซ็นต์ของความกว้างแผนภูมิ |

ตัวอย่างอิสระต่อไปนี้ใช้ข้อมูลเริ่มต้นของแผนภูมิที่มีสามชุดข้อมูลและสี่ประเภท. มันบันทึกการนำเสนอสองไฟล์ด้วยข้อมูล, การหมุน, ความกว้างช่องว่าง, และความลึกของแผนภูมิที่เหมือนกัน; มีเพียงความลึกช่องว่างที่เปลี่ยน.

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

ภาพต่อไปนี้ถูกส่งออกจากการนำเสนอที่สร้างโดยใช้ Microsoft PowerPoint.

| ความลึกช่องว่าง: 0% | ความลึกช่องว่าง: 500% |
| --- | --- |
| ![แผนภูมิคอลัมน์ 3 มิติที่ไม่มีช่องว่างระหว่างชุดข้อมูลตามแกนความลึก](gap_depth_0.png) | ![แผนภูมิคอลัมน์ 3 มิติที่มีช่องว่าง 500% ระหว่างชุดข้อมูลตามแกนความลึก](gap_depth_500.png) |

## **เปลี่ยนประเภทชุด 3D และรูปร่างแท่ง**

ในแผนภูมิกระบอกร่วมกลุ่ม, ชุดแรกเริ่มด้วยแท่งทรงกระบอก. ตัวอย่างอ่านค่า [ChartSeries.type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/type/) และ [ChartSeries.bar_3d_shape](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/bar_3d_shape/) ก่อนและหลังการเปลี่ยนแปลงแต่ละครั้ง.

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

| การเปลี่ยนสำหรับชุดแรก | `type` | `bar_3d_shape` |
| --- | --- | --- |
| สร้างแผนภูมิ | `CLUSTERED_CYLINDER` | `CYLINDER` |
| ตั้งค่า `type` เป็น `CLUSTERED_CONE` | `CLUSTERED_CONE` | `CONE` |
| ตั้งค่า `bar_3d_shape` เป็น `BOX` | `CLUSTERED_COLUMN_3D` | `BOX` |

การตั้งค่ารูปร่างเป็น `BOX` ยังเปลี่ยนประเภทชุดข้อมูลเป็น `CLUSTERED_COLUMN_3D`. หากโค้ดของคุณแยกสาขาตามประเภทชุดข้อมูล, ให้อ่าน `series.type` หลังจากเปลี่ยนรูปร่าง. ค่าที่เก็บไว้ก่อนการกำหนดค่าจะยังคงเลือกสาขา `CLUSTERED_CONE`.

![เปรียบเทียบ PowerPoint แสดงชุดแรกเป็นทรงกระบอก, ทรงกรวย, และคอลัมน์สี่เหลี่ยมจากซ้ายไปขวา](series-shapes.png)

## **คำถามที่พบบ่อย**

**ประเภทแผนภูมิใดบ้างที่รองรับโหมด 3D ใน Aspose.Slides?**

Aspose.Slides รองรับรูปแบบ 3D ของแผนภูมิคอลัมน์, รวมถึง Column 3D, Clustered Column 3D, Stacked Column 3D, และ 100% Stacked Column 3D, พร้อมกับประเภท 3D ที่เกี่ยวข้องที่เปิดเผยผ่าน enumeration [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) . สำหรับรายการที่แน่นอนและเป็นปัจจุบัน, ตรวจสอบสมาชิกของ [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) ในเอกสารอ้างอิง API ของเวอร์ชันที่คุณติดตั้ง.

**ฉันสามารถรับภาพเรสเตอร์ของแผนภูมิ 3D สำหรับรายงานหรือเว็บได้หรือไม่?**

ได้. คุณสามารถส่งออกแผนภูมิเป็นภาพด้วย [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) หรือ [render the entire slide](/slides/th/python-net/convert-powerpoint-to-png/) ไปยังรูปแบบเช่น PNG หรือ JPEG. สิ่งนี้มีประโยชน์เมื่อคุณต้องการภาพตัวอย่างแบบเรสเตอร์หรือฝังแผนภูมิลงในเอกสาร, แดชบอร์ด, หรือหน้าเว็บโดยไม่ต้องใช้ PowerPoint.

**ประสิทธิภาพการสร้างและเรนเดอร์แผนภูมิ 3D ขนาดใหญ่เป็นอย่างไร?**

ประสิทธิภาพขึ้นอยู่กับปริมาณข้อมูลและความซับซ้อนของภาพ. เพื่อผลลัพธ์ที่ดีที่สุด, ควรลดเอฟเฟกต์ 3D ให้น้อยที่สุด, หลีกเลี่ยงการใช้เทกเจอร์หนักบนผนังและพื้นที่แผนภูมิ, จำกัดจำนวนจุดข้อมูลต่อชุดเมื่อเป็นไปได้, และเรนเดอร์เป็นผลลัพธ์ที่มีขนาดเหมาะสม (ความละเอียดและมิติ) เพื่อให้ตรงกับการแสดงผลหรือความต้องการพิมพ์.