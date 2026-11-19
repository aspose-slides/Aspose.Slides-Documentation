---
title: ปรับแต่งแผนภูมิ 3D ในงานนำเสนอด้วย Python
linktitle: แผนภูมิ 3D
type: docs
url: /th/python-java/3d-chart/
keywords:
- แผนภูมิ 3D
- การหมุน
- ความลึก
- PowerPoint
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "สร้างแผนภูมิ 3D ในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Python ผ่าน Java ปรับการหมุน, สัดส่วนความสูง, ความลึกของแผนภูมิ, และระยะห่างระหว่างซีรีส์ด้วยตัวอย่าง Python."
---
## **ภาพรวม**

Aspose.Slides for Python via Java ให้คุณปรับแต่งมุมมองของแผนภูมิ 3D ผ่านเมธอด [Chart.getRotation3D](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getRotation3D) บทความนี้แสดงวิธีปรับการหมุน, สัดส่วนความสูง, ความลึก, แกนมุมฉาก, และระยะห่างระหว่างชุดข้อมูล, จากนั้นบันทึกงานนำเสนอเป็นรูปแบบ PPTX

## **ตั้งค่าการหมุนและความลึกของแผนภูมิ 3D**

ตัวอย่างด้านล่างสร้าง [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) และใช้ [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) เพื่อเพิ่มแผนภูมิคอลัมน์ 3D แบบ stacked ไปยังสไลด์แรกของมัน มันแทนที่ซีรีส์และหมวดหมู่เริ่มต้นด้วยสองซีรีส์ที่มีค่าแต่ละค่า 3 ค่า ดัชนี worksheet `0` ระบุ worksheet ข้อมูลแรกของแผนภูมิ; แถว `0` เก็บชื่อซีรีส์, และคอลัมน์ `0` เก็บป้ายกำกับหมวดหมู่

เมธอด [setRotationX](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationX) และ [setRotationY](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationY) ตั้งการหมุนของแผนภูมิเป็น 40 และ 270 องศาตามลำดับ [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) ตั้งความลึกเป็น 150% ของความกว้าง, ในขณะที่ [setRightAngleAxes](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRightAngleAxes) เปิดใช้งานแกนมุมฉากแทนการมองแบบ perspective งานนำเสนอที่ได้จะมีแผนภูมิที่เติมข้อมูลพร้อมการตั้งค่ามุมมอง 3D เหล่านี้

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

## **ปรับสัดส่วนความสูงของแผนภูมิ 3D**

ใช้ [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) เพื่อตั้งความสูงของแผนภูมิ 3D เป็นเปอร์เซ็นต์ของความกว้าง วิธีนี้เปลี่ยนสัดส่วนของฉาก 3D โดยไม่ต้องปรับขนาดวัตถุแผนภูมิบนสไลด์

ตัวอย่างต่อไปนี้สร้างแผนภูมิ [Column3D](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) ด้วยข้อมูลเริ่มต้น: สามซีรีส์และสี่หมวดหมู่ มันบันทึกงานนำเสนอสามไฟล์ด้วยสัดส่วนความสูง 50%, 100% และ 200% ความตำแหน่ง, ความกว้าง, และความสูงของแผนภูมิก็ยังคงคงที่ ข้อมูล, การหมุน, ความลึก, ระยะห่างระหว่างซีรีส์, และการจัดรูปแบบทั้งหมดเหมือนกันในทั้งสามไฟล์; มีเพียงเปอร์เซ็นต์ความสูงที่เปลี่ยน

```python
import jpide
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

ภาพต่อไปนี้แสดงการตั้งค่าสูงเดียวกันในตัวอย่าง .NET ที่เทียบเคียงกันและส่งออกโดย Microsoft PowerPoint ค่าเปอร์เซ็นต์ที่น้อยกว่าจะทำให้ฉากแบนลง, ส่วนค่าที่มากกว่าจะทำให้ฉากสูงขึ้นภายในวัตถุแผนภูมิเดียวกัน PowerPoint อาจปรับช่วงติกของแกนและตำแหน่งป้ายกำกับเพื่อให้พอดีกับฉาก

| ความสูง: 50% | ความสูง: 100% | ความสูง: 200% |
| --- | --- | --- |
| ![แผนภูมิคอลัมน์ 3D ที่ความสูงตั้งค่าเป็น 50 เปอร์เซ็นต์ของความกว้าง](height_percent_50.png) | ![แผนภูมิคอลัมน์ 3D ที่ความสูงตั้งค่าเป็น 100 เปอร์เซ็นต์ของความกว้าง](height_percent_100.png) | ![แผนภูมิคอลัมน์ 3D ที่ความสูงตั้งค่าเป็น 200 เปอร์เซ็นต์ของความกว้าง](height_percent_200.png) |

เมธอดเหล่านี้ควบคุมแง่มุมต่าง ๆ ของแผนภูมิ:

| เมธอด | ผลลัพธ์ |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) | ความสูงของฉาก 3D เป็นเปอร์เซ็นต์ของความกว้าง |
| [Chart.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHeight) | ความสูงของวัตถุแผนภูมิบนสไลด์, หน่วยเป็นพอยต์ |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | ความลึกของฉาก 3D เป็นเปอร์เซ็นต์ของความกว้าง |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | ระยะห่างระหว่างชุดข้อมูลตามแกนความลึก, เป็นเปอร์เซ็นต์ของความกว้างมาร์กเกอร์ |

การตั้งค่านี้มีผลกับแผนภูมิคอลัมน์และแผนภูมิแท่ง 3D รวมถึงแบบทรงกระบอก, รูปกรวย, และรูปพีระมิด, รวมถึงแผนภูมิเส้น, พื้นที่, พาย, และพื้นผิว 3D การเปรียบเทียบด้านบนใช้ประเภท `Column3D` ที่ตรวจสอบแล้ว การตั้งค่าไม่เปลี่ยนลักษณะของแผนภูมิ 2D `ClusteredColumn` หรือแผนภูมิ `BubbleWith3D`; ชื่อเหล่านี้เป็นสมาชิกของคลาส [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) สำหรับการตั้งค่าลักษณะอื่น ๆ ของแผนภูมิ ดูที่ [Chart Formatting](/slides/th/python-java/chart-formatting/)

## **ปรับช่องว่างระหว่างชุดข้อมูล**

ใช้ [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) เพื่อควบคุมระยะทางระหว่างชุดข้อมูลตามแกนความลึกของแผนภูมิ 3D โดยแสดงเป็นเปอร์เซ็นต์ของความกว้างมาร์กเกอร์ ใช้ค่า **0 ถึง 500** รวม: `0` จะลบช่องว่าง, ค่าที่มากกว่าจะเพิ่มระยะห่าง ด้วยความลึกแผนภูมิคงที่ การเพิ่มช่องว่างทำให้มาร์กเกอร์บางลงตามแกนความลึก

เข้าถึงกลุ่มผ่าน [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) การตั้งค่านี้จะนำไปใช้กับทุกซีรีส์ในกลุ่มนั้น, ไม่ใช่แค่ซีรีส์ที่ใช้เข้าถึงมัน [ChartSeries.getGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getGapDepth) จะคืนค่าช่องว่างความลึกและสะท้อนการตั้งค่าของกลุ่มแม่

การตั้งค่านี้มีผลกับแผนภูมิคอลัมน์และแผนภูมิแท่ง 3D รวมถึงแบบทรงกระบอก, รูปกรวย, และรูปพีระมิด, รวมถึงแผนภูมิเส้นและพื้นที่ รูปแบบขึ้นอยู่กับว่าชุดข้อมูลจัดเรียงตามความลึก, กลุ่ม, หรือ stacked สำหรับการเปรียบเทียบที่ชัดเจนของช่องว่างระหว่างชุดแยกกัน ใช้ `ChartType.Column3D` จากคลาส [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/)

เมธอดเหล่านี้ควบคุมแง่มุมต่าง ๆ ของแผนภูมิ:

| เมธอด | ผลลัพธ์ |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | ระยะห่างระหว่างชุดข้อมูลตามแกนความลึก, เป็นเปอร์เซ็นต์ของความกว้างมาร์กเกอร์ |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) | ระยะห่างระหว่างกลุ่มแท่งหรือคอลัมน์ที่อยู่ติดกัน, เป็นเปอร์เซ็นต์ของความกว้างของแท่งหรือคอลัมน์ |
| [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | ความลึกรวมของแผนภูมิ, เป็นเปอร์เซ็นต์ของความกว้างแผนภูมิ |

ตัวอย่างแบบอิสระต่อไปนี้ใช้ข้อมูลแผนภูมิดิฟอลต์ที่มีสามซีรีส์และสี่หมวดหมู่ มันบันทึกงานนำเสนอสองไฟล์ด้วยข้อมูล, การหมุน, ความกว้างช่อง, และความลึกของแผนภูมิที่เหมือนกัน; มีเพียงความลึกช่องที่เปลี่ยน

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

ภาพต่อไปนี้แสดงการตั้งค่าความลึกช่องเดียวกันในตัวอย่าง .NET ที่เทียบเคียงกันและส่งออกโดย Microsoft PowerPoint

| ความลึกของช่องว่าง: 0% | ความลึกของช่องว่าง: 500% |
| --- | --- |
| ![แผนภูมิคอลัมน์ 3D ที่ไม่มีช่องว่างระหว่างชุดข้อมูลตามแกนความลึก](gap_depth_0.png) | ![แผนภูมิคอลัมน์ 3D ที่มีช่องว่าง 500 เปอร์เซ็นต์ระหว่างชุดข้อมูลตามแกนความลึก](gap_depth_500.png) |

## **เปลี่ยนประเภทซีรีส์ 3D และรูปแบบแท่ง**

ในแผนภูมิสกุลทรงกระบอกแบบ clustered, ซีรีส์แรกเริ่มด้วยรูปแบบแท่งทรงกระบอก ตัวอย่างพิมพ์ค่าจำนวนเต็มที่คืนจาก [ChartSeries.getType](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getType) และ [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getBar3DShape) ก่อนและหลังการเปลี่ยนแต่ละครั้ง ตารางให้ชื่อคอนสแตนท์ที่สอดคล้อง

```python
import jpade
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

| การเปลี่ยนแปลงในชุดแรก | ประเภทซีรีส์ | รูปร่างแท่ง |
| --- | --- | --- |
| สร้างแผนภูมิ | `ClusteredCylinder` | `Cylinder` |
| ตั้งค่าประเภทซีรีส์เป็น `ClusteredCone` | `ClusteredCone` | `Cone` |
| ตั้งค่ารูปร่างแท่งเป็น `Box` | `ClusteredColumn3D` | `Box` |

การตั้งค่ารูปร่างเป็น `Box` ยังทำให้ประเภทซีรีส์เปลี่ยนเป็น `ClusteredColumn3D` หากโค้ดของคุณตรวจสอบประเภทซีรีส์, เรียก `series.getType()` หลังจากเปลี่ยนรูปร่าง ค่าที่แคชไว้ก่อนการกำหนดจะยังคงเลือกสาขา `ClusteredCone`

![การเปรียบเทียบ PowerPoint แสดงชุดแรกเป็นทรงกระบอก, รูปกรวย, และคอลัมน์สี่เหลี่ยมจากซ้ายไปขวา](series-shapes.png)

## **คำถามที่พบบ่อย**

**ประเภทแผนภูมิใดที่รองรับโหมด 3D ใน Aspose.Slides?**

Aspose.Slides รองรับรูปแบบ 3D ของแผนภูมิคอลัมน์ รวมถึง Column 3D, Clustered Column 3D, Stacked Column 3D, และ 100% Stacked Column 3D พร้อมประเภท 3D ที่เกี่ยวข้องซึ่งเปิดให้เข้าถึงผ่านคลาส [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) สำหรับรายการที่แม่นยำและอัปเดตล่าสุด ตรวจสอบสมาชิกของ [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) ในเอกสาร API ของเวอร์ชันที่คุณติดตั้ง

**ฉันสามารถรับภาพเรสเตอร์ของแผนภูมิ 3D เพื่อใช้ในรายงานหรือเว็บได้หรือไม่?**

ได้ คุณสามารถส่งออกแผนภูมิเป็นภาพด้วย [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) หรือ [render the entire slide](/slides/th/python-java/convert-powerpoint-to-png/) เป็นรูปแบบเช่น PNG หรือ JPEG สิ่งนี้มีประโยชน์เมื่อคุณต้องการภาพแสดงตัวอย่างแบบเรสเตอร์หรือฝังแผนภูมิลงในเอกสาร, แดชบอร์ด, หรือหน้าเว็บโดยไม่ต้องใช้ PowerPoint

**ประสิทธิภาพการสร้างและเรนเดอร์แผนภูมิ 3D ขนาดใหญ่เป็นอย่างไร?**

ประสิทธิภาพขึ้นอยู่กับปริมาณข้อมูลและความซับซ้อนของภาพ สำหรับผลลัพธ์ที่ดีที่สุด ควรลดเอฟเฟกต์ 3D ให้น้อยที่สุด, อย่าใช้พื้นผิวที่มีเทกซ์เจอร์หนักบนผนังและพื้นที่พล็อต, จำกัดจำนวนจุดข้อมูลต่อซีรีส์เมื่อต้องทำได้, และเรนเดอร์เป็นเอาต์พุตขนาดที่เหมาะสม (ความละเอียดและมิติ) เพื่อให้ตรงกับการแสดงผลหรือการพิมพ์ที่ต้องการ