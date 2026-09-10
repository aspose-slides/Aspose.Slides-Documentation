---
title: จัดรูปแบบแผนภูมิการนำเสนอใน Python
linktitle: การจัดรูปแบบแผนภูมิ
type: docs
weight: 60
url: /th/python-java/chart-formatting/
keywords:
- จัดรูปแบบแผนภูมิ
- การจัดรูปแบบแผนภูมิ
- องค์ประกอบแผนภูมิ
- คุณสมบัติของแผนภูมิ
- การตั้งค่าแผนภูมิ
- ตัวเลือกแผนภูมิ
- คุณสมบัติแบบอักษร
- ขอบโค้ง
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้การจัดรูปแบบแผนภูมิใน Aspose.Slides สำหรับ Python ผ่าน Java และยกระดับการนำเสนอ PowerPoint ของคุณด้วยสไตล์ที่เป็นมืออาชีพและดึงดูดสายตา."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการจัดรูปแบบแผนภูมิในงานนำเสนอ PowerPoint โดยใช้ Aspose.Slides แสดงวิธีการปรับแต่งองค์ประกอบสำคัญของแผนภูมิ เช่น แกน, เส้นกริด, ชื่อ, คำอธิบาย, พื้นที่กราฟ, และการเติมสีกำแพง เพื่อปรับปรุงรูปลักษณ์และความอ่านง่ายของข้อมูลแผนภูมิ

นอกจากนี้ยังแสดงวิธีการตั้งค่าคุณสมบัติของแบบอักษรสำหรับข้อความในแผนภูมิ, การใช้รูปแบบตัวเลขที่กำหนดไว้ล่วงหน้าและแบบกำหนดเองกับข้อมูลแผนภูมิ, และการเปิดใช้งานมุมโค้งสำหรับพื้นที่แผนภูมิ ตัวอย่างเหล่านี้ร่วมกันแสดงวิธีการควบคุมทั้งสไตล์ภาพและการนำเสนอข้อมูลของแผนภูมิในงานนำเสนอ

## **จัดรูปแบบเอนทิตี้ของแผนภูมิ**
Aspose.Slides for Python via Java ให้ผู้พัฒนาสามารถเพิ่มแผนภูมิที่กำหนดเองลงในสไลด์ตั้งแต่ต้น บทความนี้อธิบายวิธีการจัดรูปแบบเอนทิตี้ของแผนภูมิต่าง ๆ รวมถึงแกนประเภทและค่า

Aspose.Slides for Python via Java มี API อย่างง่ายสำหรับการจัดการเอนทิตี้ของแผนภูมิและจัดรูปแบบโดยใช้ค่าที่กำหนดเอง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)  
1. เข้าถึงสไลด์โดยใช้ดัชนี  
1. เพิ่มแผนภูมประเภทที่ต้องการพร้อมข้อมูลเริ่มต้น (ตัวอย่างนี้ใช้ [ChartType.LineWithMarkers](https://reference.aspose.com/slides/th/python-java/aspose.slides/charttype/#LineWithMarkers))  
1. เข้าถึงแกนค่าของแผนภูมิและตั้งค่าคุณสมบัติดังต่อไปนี้:  
   1. ตั้งค่า **Line format** สำหรับเส้นกริดหลักของแกนค่า  
   1. ตั้งค่า **Line format** สำหรับเส้นกริดย่อยของแกนค่า  
   1. ตั้งค่า **Number Format** สำหรับแกนค่า  
   1. ตั้งค่า **minimum, maximum, major, and minor units** สำหรับแกนค่า  
   1. ตั้งค่า **Text Properties** สำหรับข้อมูลบนแกนค่า  
   1. ตั้งค่า **Title** สำหรับแกนค่า  
1. เข้าถึงแกนประเภทของแผนภูมิและตั้งค่าคุณสมบัติดังต่อไปนี้:  
   1. ตั้งค่า **Line format** สำหรับเส้นกริดหลักของแกนประเภท  
   1. ตั้งค่า **Line format** สำหรับเส้นกริดย่อยของแกนประเภท  
   1. ตั้งค่า **Text Properties** สำหรับข้อมูลบนแกนประเภท  
   1. ตั้งค่า **Title** สำหรับแกนประเภท  
   1. ตั้งค่า **Label Positioning** สำหรับแกนประเภท  
   1. ตั้งค่า **Rotation Angle** สำหรับป้ายชื่อแกนประเภท  
1. เข้าถึงคำอธิบายแผนภูมิและตั้งค่า **text properties** ของมัน  
1. แสดงคำอธิบายแผนภูมิโดยไม่ให้ทับซ้อนกับแผนภูมิ  
1. เข้าถึง **secondary value axis** ของแผนภูมิและตั้งค่าคุณสมบัติดังต่อไปนี้:  
   1. เปิดใช้งาน **value axis** รอง  
   1. ตั้งค่า **Line Format** สำหรับแกนค่ารอง  
   1. ตั้งค่า **Number Format** สำหรับแกนค่ารอง  
   1. ตั้งค่า **minimum, maximum, major, and minor units** สำหรับแกนค่ารอง  
1. พล็อตชุดข้อมูลแรกของแผนภูมิบนแกนค่ารอง  
1. ตั้งค่าสีเติมกำแพงด้านหลังของแผนภูมิ  
1. ตั้งค่าสีเติมพื้นที่พล็อตของแผนภูมิ  
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayUnitType, FillType, FontData, LineDashStyle, LineStyle, NullableBool, Presentation, PresetColor, SaveFormat, TickLabelPositionType

Color = jpype.JClass("java.awt.Color")
nullable_true = NullableBool.True_

    # สร้างอินสแตนซ์ของคลาส Presentation
presentation = Presentation()
try:
    # เข้าถึงสไลด์แรก
    slide = presentation.getSlides().get_Item(0)

    # เพิ่มแผนภูมิตัวอย่าง
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400)

    # ตั้งค่าชื่อแผนภูมิ
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("")
    chart_title = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    chart_title.setText("Sample Chart")
    chart_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    chart_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    chart_title.getPortionFormat().setFontHeight(20)
    chart_title.getPortionFormat().setFontBold(nullable_true)
    chart_title.getPortionFormat().setFontItalic(nullable_true)

    # ตั้งค่ารูปแบบเส้นกริดหลักสำหรับแกนค่า
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot)

    # ตั้งค่ารูปแบบเส้นกริดย่อยสำหรับแกนค่า
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    # ตั้งค่ารูปแบบตัวเลขของแกนค่า
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%")

    # ตั้งค่าสูงสุดและต่ำสุดของแผนภูมิ
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getVerticalAxis().setMaxValue(15)
    chart.getAxes().getVerticalAxis().setMinValue(-2)
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0)

    # ตั้งค่าคุณสมบัติข้อความของแกนค่า
    value_axis_text = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat()
    value_axis_text.setFontBold(nullable_true)
    value_axis_text.setFontHeight(16)
    value_axis_text.setFontItalic(nullable_true)
    value_axis_text.getFillFormat().setFillType(FillType.Solid)
    value_axis_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen)
    value_axis_font = FontData("Times New Roman")
    value_axis_text.setLatinFont(value_axis_font)

    # ตั้งค่าชื่อแกนค่า
    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("")
    value_axis_title = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    value_axis_title.setText("Primary Axis")
    value_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    value_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    value_axis_title.getPortionFormat().setFontHeight(20)
    value_axis_title.getPortionFormat().setFontBold(nullable_true)
    value_axis_title.getPortionFormat().setFontItalic(nullable_true)

    # ตั้งค่ารูปแบบเส้นกริดหลักสำหรับแกนประเภท
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5)

    # ตั้งค่ารูปแบบเส้นกริดย่อยสำหรับแกนประเภท
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    # ตั้งค่าคุณสมบัติข้อความของแกนประเภท
    category_axis_text = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat()
    category_axis_text.setFontBold(nullable_true)
    category_axis_text.setFontHeight(16)
    category_axis_text.setFontItalic(nullable_true)
    category_axis_text.getFillFormat().setFillType(FillType.Solid)
    category_axis_text.getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    category_axis_font = FontData("Arial")
    category_axis_text.setLatinFont(category_axis_font)

    # ตั้งค่าชื่อประเภท
    chart.getAxes().getHorizontalAxis().setTitle(True)
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("")

    category_axis_title = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    category_axis_title.setText("Sample Category")
    category_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    category_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    category_axis_title.getPortionFormat().setFontHeight(20)
    category_axis_title.getPortionFormat().setFontBold(nullable_true)
    category_axis_title.getPortionFormat().setFontItalic(nullable_true)

    # ตั้งค่าตำแหน่งป้ายกำกับของแกนประเภท
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low)

    # ตั้งค่ามุมการหมุนของป้ายกำกับแกนประเภท
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45)

    # ตั้งค่าคุณสมบัติข้อความของคำอธิบาย
    legend_text = chart.getLegend().getTextFormat().getPortionFormat()
    legend_text.setFontBold(nullable_true)
    legend_text.setFontHeight(16)
    legend_text.setFontItalic(nullable_true)
    legend_text.getFillFormat().setFillType(FillType.Solid)
    legend_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed)

    # แสดงคำอธิบายแผนภูมิโดยไม่ให้ทับซ้อนกับแผนภูมิ

    chart.getLegend().setOverlay(False)

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(True)
    # ตั้งค่าแกนค่ารอง
    chart.getAxes().getSecondaryVerticalAxis().setVisible(True)
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin)
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20)

    # ตั้งค่ารูปแบบตัวเลขของแกนค่ารอง
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds)
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%")

    # ตั้งค่าสูงสุดและต่ำสุดของแผนภูมิ
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20)
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5)
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0)

    # ตั้งค่าสีผนังด้านหลังของแผนภูมิ
    chart.getBackWall().setThickness(1)
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid)
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE)

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid)
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED)
    # ตั้งค่าสีพื้นที่พล็อต
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid)
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan)

    # บันทึกงานนำเสนอ
    presentation.save("FormattedChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ตั้งค่าคุณสมบัติแบบอักษรสำหรับแผนภูมิ**
Aspose.Slides for Python via Java รองรับการตั้งค่าคุณสมบัติแบบอักษรสำหรับแผนภูมิ ทำตามขั้นตอนต่อไปนี้เพื่อกำหนดคุณสมบัติแบบอักษร:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)  
- เพิ่มแผนภูมิลงในสไลด์  
- ตั้งค่าความสูงของแบบอักษร  
- บันทึกงานนำเสนอที่แก้ไข  

ตัวอย่างต่อไปนี้แสดงขั้นตอนเหล่านั้น  

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# สร้างอินสแตนซ์ของคลาส Presentation
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)

    chart.getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ตั้งค่ารูปแบบตัวเลข**
Aspose.Slides for Python via Java มี API อย่างง่ายสำหรับการจัดการรูปแบบข้อมูลของแผนภูมิ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)  
1. เข้าถึงสไลด์โดยใช้ดัชนี  
1. เพิ่มแผนภูมาประเภทที่ต้องการพร้อมข้อมูลเริ่มต้น (ตัวอย่างนี้ใช้ [ChartType.ClusteredColumn](https://reference.aspose.com/slides/th/python-java/aspose.slides/charttype/#ClusteredColumn))  
1. ตั้งค่ารูปแบบตัวเลขที่กำหนดไว้ล่วงหน้าจากค่าที่เป็นไปได้  
1. วนลูปผ่านเซลล์ข้อมูลในแต่ละชุดของแผนภูมิและตั้งค่ารูปแบบตัวเลขของแต่ละเซลล์  
1. บันทึกงานนำเสนอ  

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# สร้างอินสแตนซ์ของคลาส Presentation
presentation = Presentation()
try:
    # เข้าถึงสไลด์แรกของการนำเสนอ
    slide = presentation.getSlides().get_Item(0)

    # เพิ่มแผนภูมิคอลัมน์แบบคลัสเตอร์เริ่มต้น
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400)

    # เข้าถึงคอลเลกชันซีรีส์ของแผนภูมิ
    chart_series_collection = chart.getChartData().getSeries()

    # วนลูปผ่านทุกซีรีส์ของแผนภูมิ
    for chart_series in chart_series_collection:
        # วนลูปผ่านทุกจุดข้อมูลในซีรีส์
        for data_point in chart_series.getDataPoints():
            # ตั้งค่ารูปแบบตัวเลข
            data_point.getValue().getAsCell().setPresetNumberFormat(jpype.JByte(10))  # 0.00%

    # บันทึกการนำเสนอ
    presentation.save("PresetNumberFormat.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

รูปแบบตัวเลขที่กำหนดไว้ล่วงหน้าและดัชนีของแต่ละรูปแบบมีดังต่อไปนี้:

|**0**|ทั่วไป|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **ตั้งค่ามุมโค้งของพื้นที่แผนภูมิ**
Aspose.Slides for Python via Java รองรับมุมโค้งสำหรับพื้นที่แผนภูมิผ่านเมธอด [hasRoundedCorners](https://reference.aspose.com/slides/th/python-java/aspose.slides/chart/#hasRoundedCorners) และ [setRoundedCorners](https://reference.aspose.com/slides/th/python-java/aspose.slides/chart/#setRoundedCorners) ของคลาส [Chart](https://reference.aspose.com/slides/th/python-java/aspose.slides/chart/)

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)  
1. เพิ่มแผนภูมิลงในสไลด์  
1. ตั้งค่าประเภทและสไตล์ของเส้นขอบแผนภูมิ  
1. เปิดใช้งานมุมโค้ง  
1. บันทึกงานนำเสนอที่แก้ไข  

ตัวอย่างต่อไปนี้แสดงขั้นตอนดังกล่าว  

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineStyle, Presentation, SaveFormat

# สร้างอินสแตนซ์ของคลาส Presentation
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    chart.getLineFormat().setStyle(LineStyle.Single)
    chart.setRoundedCorners(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**ฉันตั้งค่าสีเติมกึ่งโปร่งใสสำหรับคอลัมน์/พื้นที่โดยยังคงให้เส้นขอบทึบได้หรือไม่?**

ได้ การตั้งค่าความโปร่งใสของการเติมและการกำหนดเส้นขอบทำแยกจากกัน ซึ่งเป็นประโยชน์ในการเพิ่มความอ่านง่ายของกริดและข้อมูลในภาพที่แออัด

**ฉันจะจัดการกับป้ายข้อมูลที่ทับซ้อนกันอย่างไร?**

ลดขนาดแบบอักษร, ปิดใช้งานส่วนที่ไม่จำเป็นของป้าย (เช่น หมวดหมู่), ตั้งค่าออฟเซ็ต/ตำแหน่งของป้าย, แสดงป้ายเฉพาะจุดที่เลือกตามต้องการ, หรือเปลี่ยนรูปแบบเป็น “ค่า + คำอธิบาย”

**ฉันสามารถใช้การเติมแบบไล่สีหรือแบบลวดลายกับชุดข้อมูลได้หรือไม่?**

ได้ ทั้งการเติมแบบสีทึบและแบบไล่สี/ลวดลายมักจะมีให้ใช้งาน ในการใช้งานจริง ควรใช้ไล่สีอย่างเหมาะสมและหลีกเลี่ยงการผสมผสานที่ลดความคอนทราสต์กับกริดและข้อความ