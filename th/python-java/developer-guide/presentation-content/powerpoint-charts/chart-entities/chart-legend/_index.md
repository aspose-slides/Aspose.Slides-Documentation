---
title: ปรับแต่งคำอธิบายแผนภูมิในงานนำเสนอด้วย Python
linktitle: คำอธิบายแผนภูมิ
type: docs
url: /th/python-java/chart-legend/
keywords:
- คำอธิบายแผนภูมิ
- ตำแหน่งคำอธิบาย
- ขนาดฟอนต์
- PowerPoint
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "ปรับแต่งคำอธิบายแผนภูมิด้วย Aspose.Slides สำหรับ Python ผ่าน Java เพื่อปรับปรุงงานนำเสนอ PowerPoint ด้วยการจัดรูปแบบคำอธิบายที่กำหนดเอง."
---
## **ภาพรวม**

Aspose.Slides สำหรับ Python ผ่าน Java มีตัวเลือกสำหรับปรับแต่งคำอธิบายแผนภูมิในงานนำเสนอ PowerPoint บทความนี้แสดงวิธีการกำหนดตำแหน่งและขนาดของคำอธิบาย, ตั้งขนาดฟอนต์สำหรับคำอธิบายทั้งหมด, จัดรูปแบบรายการคำอธิบายเดี่ยว, และซ่อนหรือกู้คืนรายการที่เลือก

FAQ นี้ครอบคลุมพฤติกรรมที่เกี่ยวข้อง รวมถึงการสงวนพื้นที่สำหรับคำอธิบาย, การแสดงป้ายหลายบรรทัด, และการสืบทอดการจัดรูปแบบจากธีมของงานนำเสนอ

## **การกำหนดตำแหน่งคำอธิบาย**

ใช้เมธอด [setX](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setX), [setY](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setY), [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setWidth), และ [setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setHeight) ของคำอธิบายเพื่อระบุตำแหน่งและขนาดของมันเป็นส่วนของมิติของแผนภูมิ

ตัวอย่างนี้สร้างงานนำเสนอและเพิ่มแผนภูมิคอลัมน์แบบกลุ่มที่มีข้อมูลเริ่มต้นไปยังสไลด์แรก การแบ่งค่าออฟเซ็ตและมิติของคำอธิบายที่ต้องการด้วยความกว้างและความสูงของแผนภูมิจะทำให้เป็นค่าที่สัมพันธ์กัน: คำอธิบายจะถูกออฟเซ็ต 50 จุดจากมุมบนซ้ายของแผนภูมิและมีขนาด 100 x 100 จุด

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500)

    # แสดงตำแหน่งและขนาดของคำอธิบายสัมพันธ์กับแผนภูมิ
    chart.getLegend().setX(50 / chart.getWidth())
    chart.getLegend().setY(50 / chart.getHeight())
    chart.getLegend().setWidth(100 / chart.getWidth())
    chart.getLegend().setHeight(100 / chart.getHeight())

    presentation.save("legend_position.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ตั้งขนาดฟอนต์ของคำอธิบาย**

ใช้ [getTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getTextFormat) ของคำอธิบายเพื่อเข้าถึงการจัดรูปแบบข้อความของมันและใช้ [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) เพื่อตั้งค่าขนาดฟอนต์เป็นจุด

ตัวอย่างนี้สร้างแผนภูมิกับข้อมูลเริ่มต้นและตั้งค่าข้อความคำอธิบายเป็น 20 จุด นอกจากนี้ยังปิดการจำกัดอัตโนมัติสำหรับแกนแนวตั้งและตั้งช่วงค่าเป็น -5 ถึง 10

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)
    chart.getAxes().getVerticalAxis().setMinValue(-5)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setMaxValue(10)

    presentation.save("legend_font_size.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ตั้งขนาดฟอนต์ของรายการคำอธิบายเดี่ยว**

ใช้คอลเลกชันที่เมธอด [getEntries](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getEntries) ของคำอธิบายคืนค่าเพื่อเข้าถึงการจัดรูปแบบของรายการเฉพาะ ดัชนีของรายการเริ่มจากศูนย์ ดังนั้นดัชนี `1` หมายถึงรายการที่สอง

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบกลุ่มซึ่งข้อมูลเริ่มต้นมีอย่างน้อยสองซีรีส์ มันจัดรูปแบบรายการคำอธิบายที่สองด้วยข้อความหนา, ตัวเอียง, และสีฟ้า ขนาด 20 จุด

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    text_format = chart.getLegend().getEntries().get_Item(1).getTextFormat()

    text_format.getPortionFormat().setFontBold(NullableBool.True_)
    text_format.getPortionFormat().setFontHeight(20)
    text_format.getPortionFormat().setFontItalic(NullableBool.True_)
    text_format.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    text_format.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("legend_entry_format.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ซ่อนรายการคำอธิบายเดี่ยว**

เพื่อไม่รวมซีรีส์เสริมจากคำอธิบายขณะยังคงให้ข้อมูลปรากฏ, เรียก [LegendEntryProperties.setHide](https://reference.aspose.com/slides/python-java/aspose.slides/legendentryproperties/#setHide) ด้วยค่า `True` ผ่าน [ChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getRelatedLegendEntry). วิธีนี้จะซ่อนเฉพาะรายการคำอธิบายที่เลือก; ไม่ได้ลบซีรีส์หรือจุดข้อมูลของมัน การเรียก [Chart.setLegend](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setLegend) ด้วยค่า `False` ในทางกลับกันจะซ่อนคำอธิบายทั้งหมด

ตัวอย่างด้านล่างสร้างแผนภูมิคอลัมน์แบบกลุ่มที่มีหลายซีรีส์โดยใช้ข้อมูลเริ่มต้น มันซ่อนรายการคำอธิบายของซีรีส์ที่สอง (ดัชนี `1`) และบันทึกงานนำเสนอ จากนั้นกู้คืนรายการโดยเรียก [setHide](https://reference.aspose.com/slides/python-java/aspose.slides/legendentryproperties/#setHide) ด้วยค่า `False` และบันทึกสำเนาที่สอง คอลัมน์ยังคงมองเห็นได้ในทั้งสองไฟล์

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setLegend(True)

    legend_entry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry()

    legend_entry.setHide(True)
    presentation.save("hidden_legend_entry.pptx", SaveFormat.Pptx)

    # กู้คืนรายการเดียวกันโดยไม่เปลี่ยนแปลงข้อมูลแผนภูมิ
    legend_entry.setHide(False)
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

การเปรียบเทียบด้านล่างแสดงแผนภูมิเหเดียวกันที่มีรายการทั้งหมดมองเห็นและรายการที่สองถูกซ่อน คอลัมน์ของซีรีส์ที่สองยังคงไม่เปลี่ยนแปลง

![เปรียบเทียบแผนภูมิที่มีรายการคำอธิบายทั้งหมดมองเห็นและรายการ Series 2 ถูกซ่อนจากคำอธิบาย; คอลัมน์ทั้งหมดยังคงมองเห็นได้.](hide-legend-entry.png)

ในแผนภูมิคอลัมน์, แถบ, และเส้น, รายการคำอธิบายระบุซีรีส์ สำหรับแผนภูมิเผิ, พวกมันระบุจุดข้อมูลเดี่ยว (ชิ้น), ดังนั้นให้ใช้ [ChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getRelatedLegendEntry) กับชิ้นที่เลือกแทน เอกสาร API ระบุเมธอดจุดข้อมูลนี้สำหรับประเภทแผนภูมิ `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` และ `BarOfPie` อย่าสันนิษฐานว่าใช้ได้กับแผนภูมิดอนัท ซึ่งไม่ได้อยู่ในรายการนั้น

## **คำถามที่พบบ่อย**

**ฉันสามารถทำให้แผนภูมิสงวนพื้นที่สำหรับคำอธิบายแทนการวางทับได้ไหม?**

ใช่. เรียก [setOverlay](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setOverlay) ด้วยค่า `False` เพื่อสงวนพื้นที่สำหรับคำอธิบายแทนการให้มันวางทับบนพื้นที่กราฟ

**ฉันสามารถทำป้ายคำอธิบายหลายบรรทัดได้ไหม?**

ใช่. ป้ายที่ยาวสามารถตัดบรรทัดเมื่อความกว้างที่มีไม่เพียงพอ คุณยังสามารถใช้ตัวอักษรขึ้นบรรทัดใหม่ในชื่อซีรีส์เพื่อขอให้ตัดบรรทัดได้

**ฉันจะทำให้คำอธิบายใช้สีสตามาตรฐานของธีมงานนำเสนอได้อย่างไร?**

ไม่กำหนดสี, การเติม, และฟอนต์ของคำอธิบาย เพื่อให้มันสืบทอดการจัดรูปแบบจากธีม การจัดรูปแบบโดยเจตนา จะทับค่าการตั้งค่าของธีมที่สอดคล้อง