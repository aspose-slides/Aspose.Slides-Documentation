---
title: ปรับแต่งแผนภูมิ 3 มิติในงานพรีเซนเทชันโดยใช้ Python
linktitle: แผนภูมิ 3 มิติ
type: docs
url: /th/python-java/3d-chart/
keywords:
- แผนภูมิ 3 มิติ
- การหมุน
- ความลึก
- PowerPoint
- งานพรีเซนเทชัน
- Python
- Java
- Aspose.Slides
description: "สร้างแผนภูมิเชิง 3 มิติในงานพรีเซนเทชัน PowerPoint ด้วย Aspose.Slides สำหรับ Python ผ่าน Java ปรับการหมุน, สัดส่วนความสูง, ความลึกของแผนภูมิ, และระยะห่างระหว่างซีรีส์ด้วยตัวอย่าง Python."
---
## **ภาพรวม**

Aspose.Slides สำหรับ Python ผ่าน Java ให้คุณปรับแต่งมุมมองของแผนภูมิ 3 มิติผ่านเมธอด [Chart.getRotation3D](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getRotation3D) วิธีการนี้ บทความนี้สาธยายวิธีปรับการหมุน, สัดส่วนความสูง, ความลึก, แกนมุมฉาก, และระยะห่างระหว่างซีรีส์, แล้วบันทึกการพรีเซนเทชันเป็นรูปแบบ PPTX

## **ตั้งค่าการหมุนและความลึกของแผนภูมิ 3 มิติ**

ตัวอย่างด้านล่างสร้าง [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) และใช้ [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) เพื่อเพิ่มแผนภูมิคอลัมน์ 3 มิติซ้อนบนสไลด์แรกของมัน แทนที่ซีรีส์และประเภทเริ่มต้นด้วยซีรีส์สองชุดที่แต่ละชุดมีค่าถึงสามค่า Worksheet index `0` ระบุ Worksheet ข้อมูลแรกของแผนภูมิ; แถว `0` เก็บชื่อซีรีส์, และคอลัมน์ `0` เก็บป้ายชื่อประเภท

เมธอด [setRotationX](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationX) และ [setRotationY](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationY) ตั้งค่าการหมุนของแผนภูมิเป็น 40 และ 270 องศาตามลำดับ [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) ตั้งค่าความลึกเป็น 150% ของความกว้าง, ส่วน [setRightAngleAxes](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRightAngleAxes) เปิดใช้งานแกนมุมฉากแทนมุมมองเชิงมโนภาพ การพรีเซนเทชันที่ได้จะแสดงแผนภูมิที่เติมข้อมูลพร้อมการตั้งค่ามุมมอง 3 มิติเหล่านี้

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.getCell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.getChartData().getCategories().add(category_cell)

    for series_index in range(2):
        series_cell = workbook.getCell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())

        for category_index in range(3):
            value_cell = workbook.getCell(worksheet_index, category_index + 1, series_index + 1, jpype.JDouble(values[series_index][category_index]))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ใช้การเติมรูปภาพบนพื้นผิวแผนภูมิ 3 มิติ**

แผนภูมิ 3 มิติมีสามพื้นผิวที่คุณสามารถเติมแยกกันได้: [side wall](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getSideWall), [back wall](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getBackWall), และ [floor](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getFloor) ตั้งค่า [fill type](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) ของพื้นผิวเป็น `Picture` แล้วกำหนดรูปภาพ ตั้งค่าโหมดการเติมรูปภาพทั้งสอง [picture fill mode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#setPictureFillMode) และ [picture type](https://reference.aspose.com/slides/python-java/aspose.slides/chartwall/#setPictureType) ของพื้นผิวเป็น `Stretch` เพื่อให้รูปภาพเดียวครอบคลุมทั่วพื้นผิว

บันทึกไฟล์ [arrow.png](arrow.png) ลงในไดเรกทอรีทำงาน ตัวอย่างหมุนแผนภูมิและเพิ่มค่าสูงสุดบนแกนตั้งเพื่อให้พื้นมองเห็นระหว่างคอลัมน์ จากนั้นคัดลอกสไลด์สองครั้งและใส่ลูกศรบนพื้นผิวที่แตกต่างกันในแต่ละสไลด์ แผนภูมิทั้งสามคงข้อมูล, มุมมอง, และพื้นหลังเหมือนเดิม

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, PictureFillMode, PictureType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 20, 30, 680, 480)
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(30)
    
    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.setAutomaticMaxValue(False)
    vertical_axis.setMaxValue(24)

    back_slide = presentation.getSlides().addClone(slide)
    floor_slide = presentation.getSlides().addClone(slide)
    back_chart = back_slide.getShapes().get_Item(0)
    floor_chart = floor_slide.getShapes().get_Item(0)

    image_bytes = Path("arrow.png").read_bytes()
    arrow = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(image_bytes))

    surfaces = (chart.getSideWall(), back_chart.getBackWall(), floor_chart.getFloor())
    for surface in surfaces:
        fill = surface.getFormat().getFill()
        fill.setFillType(FillType.Picture)
        picture_fill = fill.getPictureFillFormat()
        picture_fill.getPicture().setImage(arrow)
        picture_fill.setPictureFillMode(PictureFillMode.Stretch)
        surface.setPictureType(PictureType.Stretch)

    presentation.save("chart-surfaces.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Microsoft PowerPoint แสดงสไลด์สามสไลด์ดังต่อไปนี้

| ผนังด้านข้าง | ผนังด้านหลัง | พื้น |
| --- | --- | --- |
| ![ลูกศรชี้เข้าไปในแผนภูมิตามผนังด้านข้าง](side-wall.png) | ![ลูกศรชี้ไปทางขวาตลอดผนังด้านหลัง](back-wall.png) | ![ลูกศรชี้ไปทางขวาตลอดพื้นระหว่างคอลัมน์](floor.png) |

## **ปรับสัดส่วนความสูงของแผนภูมิ 3 มิติ**

ใช้ [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) เพื่อกำหนดความสูงของแผนภูมิ 3 มิติเป็นเปอร์เซ็นต์ของความกว้าง วิธีนี้เปลี่ยนสัดส่วนของฉาก 3 มิติโดยไม่ต้องปรับขนาดวัตถุแผนภูมิบนสไลด์

ตัวอย่างต่อไปนี้สร้างแผนภูมิ [Column3D](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) ด้วยข้อมูลเริ่มต้น: ซีรีส์สามชุดและประเภทสี่ชุด บันทึกพรีเซนเทชันสามไฟล์ด้วยสัดส่วนความสูง 50%, 100%, และ 200% ตำแหน่ง, ความกว้าง, และความสูงของแผนภูมิก็ยังคงที่ ข้อมูล, การหมุน, ความลึก, ระยะห่างซีรีส์, และการจัดรูปแบบเหมือนกันในทั้งสามไฟล์; มีเพียงเปอร์เซ็นต์ความสูงที่เปลี่ยน

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 460)
    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setDepthPercents(100)
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150)

    for height_percent in [50, 100, 200]:
        chart.getRotation3D().setHeightPercents(height_percent)
        presentation.save(f"chart_height_{height_percent}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ภาพต่อไปนี้แสดงการตั้งค่าสัดส่วนความสูงเดียวกันในตัวอย่าง .NET ที่เทียบเท่าและได้ส่งออกโดยใช้ Microsoft PowerPoint เปอร์เซ็นต์ที่น้อยกว่าจะทำให้ฉากแบนลง, ส่วนเปอร์เซ็นต์ที่มากขึ้นจะทำให้ฉากสูงขึ้นภายในวัตถุแผนภูมิเดียวกัน PowerPoint อาจปรับช่วงจุดแบ่งแกนและการวางตำแหน่งป้ายเพื่อให้พอดีกับฉาก

| ความสูง: 50% | ความสูง: 100% | ความสูง: 200% |
| --- | --- | --- |
| ![แผนภูมิคอลัมน์ 3 มิติที่ความสูงตั้งเป็น 50% ของความกว้าง](height_percent_50.png) | ![แผนภูมิคอลัมน์ 3 มิติที่ความสูงตั้งเป็น 100% ของความกว้าง](height_percent_100.png) | ![แผนภูมิคอลัมน์ 3 มิติที่ความสูงตั้งเป็น 200% ของความกว้าง](height_percent_200.png) |

เมธอดเหล่านี้ควบคุมแง่มุมต่าง ๆ ของแผนภูมิ:

| เมธอด | ผล |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) | ความสูงของฉาก 3 มิติเป็นเปอร์เซ็นต์ของความกว้าง |
| [Chart.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHeight) | ความสูงของวัตถุแผนภูมิบนสไลด์ หน่วยเป็นพอยต์ |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | ความลึกของฉาก 3 มิติเป็นเปอร์เซ็นต์ของความกว้าง |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | ระยะห่างระหว่างซีรีส์ตามแกนความลึกเป็นเปอร์เซ็นต์ของความกว้างของมาร์คเกอร์ |

การตั้งค่านี้มีผลต่อแผนภูมิคอลัมน์และแผนภูมิบาร์ 3 มิติ รวมถึงรูปแบบทรงกระบอก, โคน, และพีระมิด, รวมถึงแผนภูมิ 3 มิติด้านเส้น, พื้นที่, พาย, และพื้นผิว การเปรียบเทียบข้างต้นใช้ประเภท `Column3D` ที่ตรวจสอบแล้ว การตั้งค่านี้ไม่เปลี่ยนลักษณะของแผนภูมิ 2 มิติ `ClusteredColumn` หรือแผนภูมิ `BubbleWith3D`; ชื่อเหล่านี้เป็นสมาชิกของคลาส [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) สำหรับการตั้งค่าลักษณะแผนภูมิอื่น ๆ ดู [การจัดรูปแบบแผนภูมิ](/slides/th/python-java/chart-formatting/)

## **ปรับระยะห่างระหว่างซีรีส์**

ใช้ [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) เพื่อควบคุมระยะห่างระหว่างซีรีส์ข้อมูลตามแกนความลึกของแผนภูมิ 3 มิติ, แสดงเป็นเปอร์เซ็นต์ของความกว้างมาร์คเกอร์ ใช้ค่าตั้งแต่ **0 ถึง 500** รวม: `0` จะลบช่องว่าง, ค่าสูงกว่าจะเพิ่มระยะห่าง กับความลึกของแผนภูมิที่คงที่ การเพิ่มช่องว่างทำให้มาร์คเกอร์บางลงตามแกนความลึก

เข้าถึงกลุ่มผ่าน [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) การตั้งค่านี้ใช้กับทุกซีรีส์ในกลุ่มนั้น ไม่ใช่แค่ซีรีส์ที่ใช้เข้าถึงมัน [ChartSeries.getGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getGapDepth) คืนค่าช่องว่างความลึกและสะท้อนการตั้งค่ากลุ่มแม่

การตั้งค่านี้มีผลต่อแผนภูมิคอลัมน์และบาร์ 3 มิติ รวมถึงรูปแบบทรงกระบอก, โคน, และพีระมิด, รวมถึงแผนภูมิเส้นและพื้นที่ 3 มิติ ลักษณะการแสดงผลขึ้นอยู่กับว่าซีรีส์จัดเรียงตามความลึก, กลุ่ม, หรือซ้อนกัน เพื่อเปรียบเทียบช่องว่างระหว่างซีรีส์ที่แยกจากกันอย่างชัดเจน ใช้ `ChartType.Column3D` จากคลาส [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/)

เมธอดเหล่านี้ควบคุมแง่มุมต่าง ๆ ของแผนภูมิ:

| เมธอด | ผล |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | ระยะห่างระหว่างซีรีส์ตามแกนความลึกเป็นเปอร์เซ็นต์ของความกว้างของมาร์คเกอร์ |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) | ระยะห่างระหว่างกลุ่มแท่งหรือคอลัมน์ที่อยู่ติดกันเป็นเปอร์เซ็นต์ของความกว้างของแท่งหรือคอลัมน์ |
| [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | ความลึกโดยรวมของแผนภูมิเป็นเปอร์เซ็นต์ของความกว้างของแผนภูมิ |

ตัวอย่างต่อไปนี้เป็นตัวอย่างที่สมบูรณ์โดยใช้ข้อมูลแผนภูมิเบื้องต้น ซึ่งมีซีรีส์สามชุดและประเภทสี่ชุด บันทึกพรีเซนเทชันสองไฟล์โดยข้อมูล, การหมุน, ความกว้างช่องว่าง, และความลึกของแผนภูมิเหมือนกัน; มีเพียงความลึกช่องว่างที่เปลี่ยน

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 230)

    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setDepthPercents(100)

    series = chart.getChartData().getSeries().get_Item(0)
    group = series.getParentSeriesGroup()
    group.setGapWidth(150)

    for gap_depth in [0, 500]:
        group.setGapDepth(gap_depth)

        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ภาพต่อไปนี้แสดงการตั้งค่าความลึกช่องว่างเดียวกันในตัวอย่าง .NET ที่เทียบเท่าและได้ส่งออกโดยใช้ Microsoft PowerPoint

| ความลึกช่องว่าง: 0% | ความลึกช่องว่าง: 500% |
| --- | --- |
| ![แผนภูมิคอลัมน์ 3 มิติที่ไม่มีช่องว่างระหว่างซีรีส์ตามแกนความลึก](gap_depth_0.png) | ![แผนภูมิคอลัมน์ 3 มิติที่มีช่องว่าง 500% ระหว่างซีรีส์ตามแกนความลึก](gap_depth_500.png) |

## **เปลี่ยนประเภทซีรีส์ 3 มิติและรูปแบบแท่ง**

ในแผนภูมิทรงกระบอกแบบกลุ่ม, ซีรีส์แรกเริ่มด้วยรูปแบบแท่งทรงกระบอก ตัวอย่างพิมพ์ค่าจำนวนเต็มที่ [ChartSeries.getType](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getType) และ [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getBar3DShape) คืนค่า ก่อนและหลังการเปลี่ยนแปลงแต่ละครั้ง ตารางแสดงชื่อคอนสแตนต์ที่สอดคล้อง

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartShapeType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredCylinder, 20, 20, 500, 300)
    series = chart.getChartData().getSeries().get_Item(0)
    
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setType(ChartType.ClusteredCone)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setBar3DShape(ChartShapeType.Box)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    presentation.save("series_shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| เปลี่ยนที่ซีรีส์แรก | ประเภทซีรีส์ | รูปแบบแท่ง |
| --- | --- | --- |
| สร้างแผนภูมิ | `ClusteredCylinder` | `Cylinder` |
| ตั้งค่าประเภทซีรีส์เป็น `ClusteredCone` | `ClusteredCone` | `Cone` |
| ตั้งค่ารูปแบบแท่งเป็น `Box` | `ClusteredColumn3D` | `Box` |

การตั้งค่ารูปแบบเป็น `Box` จะเปลี่ยนประเภทซีรีส์เป็น `ClusteredColumn3D` ด้วย หากโค้ดของคุณตรวจสอบประเภทซีรีส์, ให้เรียก `series.getType()` หลังจากเปลี่ยนรูปแบบ ค่าใดที่ถูกแคชก่อนการกำหนดค่าจะยังคงเลือกสาขา `ClusteredCone`

![เปรียบเทียบ PowerPoint แสดงซีรีส์แรกเป็นทรงกระบอก, โคน, และคอลัมน์สี่เหลี่ยมจากซ้ายไปขวา](series-shapes.png)

## **คำถามที่พบบ่อย**

**แผนภูมิประเภทใดที่รองรับโหมด 3 มิติใน Aspose.Slides?**

Aspose.Slides รองรับรูปแบบ 3 มิติของแผนภูมิคอลัมน์รวมถึง Column 3D, Clustered Column 3D, Stacked Column 3D, และ 100% Stacked Column 3D พร้อมประเภท 3 มิติที่เกี่ยวข้องที่เปิดให้เข้าถึงผ่านคลาส [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) สำหรับรายการที่แม่นยำและอัพเดตล่าสุด ให้ตรวจสอบสมาชิกของ [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) ในเอกสารอ้างอิง API ของเวอร์ชันที่คุณติดตั้ง

**ฉันสามารถรับภาพราสเตอร์ของแผนภูมิ 3 มิติสำหรับรายงานหรือเว็บได้หรือไม่?**

ได้ คุณสามารถส่งออกแผนภูมิเป็นภาพด้วย [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) หรือ [render the entire slide](/slides/th/python-java/convert-powerpoint-to-png/) ไปเป็นรูปแบบเช่น PNG หรือ JPEG วิธีนี้มีประโยชน์เมื่อคุณต้องการตัวอย่างราสเตอร์หรือฝังแผนภูมิลงในเอกสาร, แดชบอร์ด, หรือหน้าเว็บโดยไม่ต้องใช้ PowerPoint

**ประสิทธิภาพการสร้างและการเรนเดอร์แผนภูมิ 3 มิติขนาดใหญ่เป็นอย่างไร?**

ประสิทธิภาพขึ้นอยู่กับปริมาณข้อมูลและความซับซ้อนของภาพ สำหรับผลลัพธ์ที่ดีที่สุด ควรใช้เอฟเฟ็กต์ 3 มิติน้อยที่สุด, หลีกเลี่ยงพื้นผิวที่มีเท็กซ์เจอร์หนัก, จำกัดจำนวนจุดข้อมูลต่อซีรีส์เมื่อเป็นไปได้, และเรนเดอร์เป็นขนาดเอาต์พุตที่เหมาะสม (ความละเอียดและมิติ) เพื่อให้ตรงกับอุปกรณ์แสดงผลหรือความต้องการพิมพ์.