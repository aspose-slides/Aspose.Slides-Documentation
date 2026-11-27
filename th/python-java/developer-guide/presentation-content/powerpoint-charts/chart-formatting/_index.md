---
title: จัดรูปแบบแผนภูมินำเสนอใน Python
linktitle: การจัดรูปแบบแผนภูมิ
type: docs
weight: 60
url: /th/python-java/chart-formatting/
keywords:
- จัดรูปแบบแผนภูมิ
- การจัดรูปแบบแผนภูมิ
- เอนทิตี้แผนภูมิ
- คุณสมบัติของแผนภูมิ
- การตั้งค่าแผนภูมิ
- ตัวเลือกแผนภูมิ
- คุณสมบัติฟอนต์
- ขอบโค้ง
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้การจัดรูปแบบแผนภูมิใน Aspose.Slides สำหรับ Python ผ่าน Java และยกระดับการนำเสนอ PowerPoint ของคุณด้วยแกนที่กำหนดเอง, ฟอนต์, รูปแบบตัวเลข, และขอบแผนภูมิแบบโค้ง."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการจัดรูปแบบแผนภูมิในงานนำเสนอ PowerPoint โดยใช้ Aspose.Slides โดยแสดงวิธีการปรับแต่งองค์ประกอบสำคัญของแผนภูมิ เช่น แกน, เส้นกริด, ชื่อเรื่อง, คำอธิบาย, พื้นที่กราฟ, และการเติมสีผนัง เพื่อปรับปรุงรูปลักษณ์และความอ่านง่ายของข้อมูลแผนภูมิ

นอกจากนี้ยังแสดงวิธีตั้งค่าคุณสมบัติของฟอนต์สำหรับข้อความในแผนภูมิ, ใช้รูปแบบตัวเลขที่ตั้งล่วงหน้ากับข้อมูลแผนภูมิ, และเปิดใช้งานมุมโค้งสำหรับพื้นที่แผนภูมิ ตัวอย่างเหล่านี้ร่วมกันแสดงวิธีควบคุมสไตล์ภาพและการนำเสนอข้อมูลของแผนภูมิในงานนำเสนอ

สำหรับการเติมสีและขอบที่แยกกันในช่วงที่ค่าเพิ่มและลดลง, ดูที่ [ตัวอย่างแผนภูมิหุ้น](/slides/th/python-java/create-chart/#create-stock-charts).

## **จัดรูปแบบเอนทิตี้ของแผนภูมิ**

ใช้ [แผนภูมิ](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) เพื่อจัดรูปแบบชื่อเรื่องของแผนภูมิ, แกน, เส้นกริด, คำอธิบาย, และพื้นที่กราฟ ตัวอย่างนี้สร้างแผนภูมิเส้นพร้อมเครื่องหมายและข้อมูลเริ่มต้น, แล้วใช้สไตล์ข้อความและเส้นที่แยกกันกับแกนค่ามากและแกนหมวดหมู่ ขนาดฟอนต์และความกว้างของเส้นระบุเป็นจุด; ป้ายชื่อหมวดหมู่อาจหมุน 45 องศา

แกนค่าจะใช้ [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) โดยอิสระจากเซลล์ต้นทาง ช่วงสเกลตั้งแต่ -2 ถึง 15, โดยมีช่วงหลักเป็น 2 และช่วงรองเป็น 0.5 ตัวอย่างยังรวมการจัดรูปแบบเปอร์เซ็นต์กับ [setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) ที่ตั้งเป็นพัน, ดังนั้นปรับค่าตั้งเหล่านี้ให้สอดคล้องกับความหมายและขนาดของข้อมูลของคุณ คำอธิบายยังคงอยู่นอกพื้นที่กราฟเนื่องจาก [setOverlay](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setOverlay) ถูกเรียกด้วย `False` การเติมสีผนังด้านหลังและพื้นถูกกำหนดผ่าน [getBackWall](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getBackWall) และ [getFloor](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getFloor) แต่พื้นผิวเหล่านี้จะมองเห็นได้เฉพาะในแผนภูมิ 3 มิติ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayUnitType, FillType, FontData, LineDashStyle, NullableBool, Presentation, PresetColor, SaveFormat, TickLabelPositionType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400)

    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("")
    chart_title = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    chart_title.setText("Sample Chart")
    chart_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    chart_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    chart_title.getPortionFormat().setFontHeight(20)
    chart_title.getPortionFormat().setFontBold(NullableBool.True_)
    chart_title.getPortionFormat().setFontItalic(NullableBool.True_)

    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot)

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%")

    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getVerticalAxis().setMaxValue(15)
    chart.getAxes().getVerticalAxis().setMinValue(-2)
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0)

    value_axis_text = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat()
    value_axis_text.setFontBold(NullableBool.True_)
    value_axis_text.setFontHeight(16)
    value_axis_text.setFontItalic(NullableBool.True_)
    value_axis_text.getFillFormat().setFillType(FillType.Solid)
    value_axis_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen)
    value_axis_font = FontData("Times New Roman")
    value_axis_text.setLatinFont(value_axis_font)

    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("")
    value_axis_title = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    value_axis_title.setText("Primary Axis")
    value_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    value_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    value_axis_title.getPortionFormat().setFontHeight(20)
    value_axis_title.getPortionFormat().setFontBold(NullableBool.True_)
    value_axis_title.getPortionFormat().setFontItalic(NullableBool.True_)

    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    category_grid_color = Color(0, 128, 0)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(category_grid_color)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5)

    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    category_axis_text = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat()
    category_axis_text.setFontBold(NullableBool.True_)
    category_axis_text.setFontHeight(16)
    category_axis_text.setFontItalic(NullableBool.True_)
    category_axis_text.getFillFormat().setFillType(FillType.Solid)
    category_axis_text.getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    category_axis_font = FontData("Arial")
    category_axis_text.setLatinFont(category_axis_font)

    chart.getAxes().getHorizontalAxis().setTitle(True)
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("")

    category_axis_title = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    category_axis_title.setText("Sample Category")
    category_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    category_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    category_axis_title.getPortionFormat().setFontHeight(20)
    category_axis_title.getPortionFormat().setFontBold(NullableBool.True_)
    category_axis_title.getPortionFormat().setFontItalic(NullableBool.True_)

    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low)
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45)

    legend_text = chart.getLegend().getTextFormat().getPortionFormat()
    legend_text.setFontBold(NullableBool.True_)
    legend_text.setFontHeight(16)
    legend_text.setFontItalic(NullableBool.True_)
    legend_text.getFillFormat().setFillType(FillType.Solid)
    legend_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed)

    chart.getLegend().setOverlay(False)

    chart.getBackWall().setThickness(1)
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid)
    back_wall_color = Color(255, 165, 0)
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(back_wall_color)

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid)
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED)

    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid)
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan)

    presentation.save("FormattedChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ตั้งค่าคุณสมบัติฟอนต์สำหรับแผนภูมิ**

ตั้งค่าขนาดฟอนต์เริ่มต้นสำหรับข้อความแผนภูมิผ่าน [Chart.getTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getTextFormat) ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบกลุ่มโดยใช้ฟอนต์ 20 จุดและเปิดใช้งานป้ายค่าในซีรีส์แรกผ่าน [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) องค์ประกอบข้อความที่มีการตั้งค่าฟอนต์แบบชัดเจนของตนเองสามารถเขียนทับค่าเริ่มต้นของแผนภูมิได้

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)
    chart.getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **นำการจัดรูปแบบ Text Frame ไปใช้ซ้ำสำหรับ Legend ของแผนภูมิ**

เพื่อให้คำอธิบายตรงกับหัวข้อสไลด์, ตั้งค่าฟอนต์ของหัวข้อโดยใช้ [getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) บนย่อหน้าที่แรก เรียก [copyFrom](https://reference.aspose.com/slides/python-java/aspose.slides/charttextformat/#copyFrom) บนรูปแบบที่ได้จาก [getTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getTextFormat) ของ legend วิธีนี้จะคัดลอกการตั้งค่า Text Frame, การจัดรูปแบบของย่อหน้าแรก, และคุณสมบัติฟอนต์เริ่มต้นของย่อคนั้น การจัดรูปแบบที่กำหนดโดยตรงให้กับส่วนย่อยหรือย่อหน้าต่อ ๆ ไปจะคงอยู่เฉพาะที่ต้นฉบับ

ตัวอย่างใช้หัวข้อแบบ Calibri ตัวหนา 26 จุดสีกรมท่าเป็นแม่แบบ หลังจากจัดรูปแบบ legend แล้วจะเรียก [copyTo](https://reference.aspose.com/slides/python-java/aspose.slides/charttextformat/#copyTo) เพื่อใช้การจัดรูปแบบเดียวกันกับคำบรรยายแยกต่างหาก

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, FontData, LegendPositionType, NullableBool, Presentation, SaveFormat, ShapeType, StyleType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()
    
    heading = shapes.addAutoShape(ShapeType.Rectangle, 40, 20, 640, 40, False)
    source_text_frame = heading.addTextFrame("Quarterly sales")
    paragraph = source_text_frame.getParagraphs().get_Item(0)
    font = paragraph.getParagraphFormat().getDefaultPortionFormat()
    font.setLatinFont(FontData("Calibri"))
    font.setFontHeight(26)
    font.setFontBold(NullableBool.True_)
    font.getFillFormat().setFillType(FillType.Solid)
    font.getFillFormat().getSolidFillColor().setColor(Color(32, 64, 96))

    chart = shapes.addChart(ChartType.ClusteredColumn, 40, 75, 640, 360)
    chart.setStyle(StyleType.Style3)
    workbook = chart.getChartData().getChartDataWorkbook()
    for column, series_name in enumerate(("Retail", "Online", "Wholesale"), start=1):
        workbook.getCell(0, 0, column).setValue(series_name)
    for quarter in range(1, 5):
        workbook.getCell(0, quarter, 0).setValue(f"Q{quarter}")

    chart.setLegend(True)
    legend = chart.getLegend()
    legend.setPosition(LegendPositionType.Bottom)
    legend_format = legend.getTextFormat()
    legend_format.copyFrom(source_text_frame)

    caption = shapes.addAutoShape(ShapeType.Rectangle, 40, 460, 640, 40, False)
    caption_text_frame = caption.addTextFrame("Sales in millions of dollars")
    legend_format.copyTo(caption_text_frame)

    presentation.save("legend-formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ในงานนำเสนอที่บันทึก, legend และ caption จะตรงกับหัวข้อในด้านขนาด, น้ำหนัก, และสี legend ยังแสดงชื่อซีรีส์, ส่วน caption จะรักษาข้อความของตนเอง หากส่วนใดใน caption มีขนาดฟอนต์ที่กำหนดไว้แล้ว ขนาดนั้นจะมีลำดับความสำคัญเหนือค่าฟอนต์เริ่มต้นของย่อหน้าที่คัดลอก

| ก่อนทำการคัดลอก | หลังทำการคัดลอก |
| --- | --- |
| ![แผนภูมิการขายรายไตรมาสพร้อมป้ายคำอธิบายสีดำปกติและคำบรรยายสีดำ](legend-formatting-before.png) | ![แผนภูมิเดียวกันพร้อมป้ายคำอธิบายสีกรมท่าแบบหนาและใหญ่กว่าและคำบรรยายที่สอดคล้องกัน](legend-formatting.png) |

## **ตั้งค่ารูปแบบตัวเลข**

ใช้ [ChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setPresetNumberFormat) เพื่อใช้รูปแบบตัวเลขที่มีมาให้กับเซลล์ในเวิร์กบุ๊กของแผนภูมิ ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบกลุ่มโดยใช้ข้อมูลที่สนับสนุนโดยเซลล์เริ่มต้นและใช้ดัชนีรูปแบบ 10 (`0.00%`) กับเซลล์ค่าของแต่ละซีรีส์ วิธีนี้จะเปลี่ยนการแสดงค่าที่เวิร์กบุ๊กโดยไม่ต้องเปลี่ยนตัวเลขดิบ ตัวอย่างเช่น 0.25 จะแสดงเป็น 25.00% รูปแบบแกนและป้ายข้อมูลสามารถกำหนดแยกกันได้

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400)
    chart_series_collection = chart.getChartData().getSeries()

    for chart_series in chart_series_collection:
        for data_point in chart_series.getDataPoints():
            data_point.getValue().getAsCell().setPresetNumberFormat(jpype.JByte(10))  # 0.00%

    presentation.save("PresetNumberFormat_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ตารางต่อไปนี้แสดงดัชนีรูปแบบตัวเลขที่มีมาให้พร้อมตัวอย่างรูปแบบ Excel สำหรับภาษาจากสหรัฐอเมริกา สตริงรูปแบบที่แท้จริงและการแสดงผลอาจแตกต่างกันตามแอปพลิเคชันและภาษาท้องถิ่น โดยเฉพาะอย่างยิ่งสำหรับสกุลเงินและวันที่ บางรูปแบบ Excel ยังแตกต่างจากค่าเริ่มต้นในมาตรฐาน OOXML ตามที่อธิบายใน [บันทึกการดำเนินการรูปแบบตัวเลขของ Microsoft](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528)

| ดัชนี | รูปแบบ |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **ตั้งค่าขอบโค้งของพื้นที่แผนภูมิ**

เรียก [Chart.setRoundedCorners](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setRoundedCorners) ด้วย `True` เพื่อทำให้มุมของพื้นที่แผนภูมิเป็นโค้ง ตัวอย่างสร้างแผนภูมิคอลัมน์แบบกลุ่มและใช้ [getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) เพื่อกำหนดเส้นขอบให้เป็นสีเทาเข้มและสไตล์เส้นเดียวก่อนบันทึกงานนำเสนอ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineStyle, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    chart.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    chart.getLineFormat().setStyle(LineStyle.Single)
    chart.setRoundedCorners(True)

    presentation.save("out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **แก้ไขคำอธิบายแผนภูมิที่มีอยู่**

แผนภูมิสามารถมีรูปทรงแบบกำหนดเองได้ เช่น คำอธิบายข้อความที่อธิบายสถานะของรายงาน เข้าถึงรูปทรงเหล่านี้ผ่าน [Chart.getUserShapes](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getUserShapes) คอลเลกชันที่ส่งกลับโดย [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) จะประกอบด้วยรูปทรงที่เป็นของแผนภูมิ

กล่องข้อความธรรมดาที่วางไว้เหนือแผนภูมิจะเป็นของสไลด์ แม้ว่าจะดูเหมือนเป็นส่วนหนึ่งของแผนภูมิ การวนลูปผ่าน [Slide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes) จะพบแผนภูมิและรูปทรงสไลด์ทั่วไป แต่จะไม่แสดงรายการรูปทรงแต่ละรายการภายในแผนภูมิ ชื่อเรื่องแผนภูมิและป้ายข้อมูลเป็นองค์ประกอบแผนภูมิแยกจากกัน ไม่ใช่คำอธิบายแบบกำหนดเองในคอลเลกชันนี้

ดาวน์โหลด [chart-annotations.pptx](chart-annotations.pptx) แล้ววางไว้ในไดเรกทอรีทำงานของแอปพลิเคชัน สไลด์แรกของไฟล์นี้มีแผนภูมิพร้อมคำอธิบายที่ไม่ได้จัดกลุ่มโดยอ่านว่า "Preliminary results", เส้นที่เป็นของแผนภูมิ, และกล่องข้อความสไลด์ธรรมดาที่อ่านว่า "Slide overlay" ตัวอย่างจะค้นหาแผนภูมิแรกบนสไลด์นั้นและเปลี่ยนคำอธิบายเป็น "Final results" เมื่อรายงานพร้อมเผยแพร่ จะตรวจสอบว่าคอลเลกชันว่างหรือไม่และแก้ไขเฉพาะ [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) ที่มี Text Frame ไม่เป็น `None` ที่ส่งกลับจาก [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#getTextFrame) พร้อมข้อความที่คาดหวัง

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Chart, Presentation, SaveFormat

presentation = Presentation("chart-annotations.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = None
    for shape in slide.getShapes():
        if isinstance(shape, Chart):
            chart = shape
            break

    if chart is None or chart.getUserShapes().getShapes().size() == 0:
        print("No chart or chart-owned shapes found.")
    else:
        updated = False
        for shape in chart.getUserShapes().getShapes():
            if isinstance(shape, AutoShape):
                text_frame = shape.getTextFrame()
                if text_frame is not None and text_frame.getText() == "Preliminary results":
                    text_frame.setText("Final results")
                    updated = True
                    break

        if updated:
            presentation.save("chart-annotations-updated.pptx", SaveFormat.Pptx)
        else:
            print("No matching text annotation found.")
finally:
    presentation.dispose()
```

เส้นและกล่องข้อความสไลด์ยังคงไม่เปลี่ยนแปลง ภาพต่อไปนี้แสดงอินพุตและผลลัพธ์ที่บันทึกและเปิดใหม่อีกครั้ง:

| ก่อนแก้ไข | หลังแก้ไข |
| --- | --- |
| ![คำอธิบายแผนภูมิที่เขียนว่า Preliminary results](chart-annotations-before.png) | ![คำอธิบายแผนภูมิที่เขียนว่า Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
ตัวอย่างตรวจสอบเฉพาะรูปทรงระดับบนสุดที่เป็นของแผนภูมิ หากคำอธิบายอยู่ภายใน [GroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/), ตรวจสอบคอลเลกชัน [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) ของกลุ่มนั้นด้วย ทำซ้ำแบบเรียกซ้ำสำหรับกลุ่มที่ซ้อนกันและใช้การตรวจสอบข้อความเดียวกันกับรูปทรงลูกของพวกมัน กลุ่มเองเป็นคอนเทนเนอร์; อย่าถือว่ามันเป็นกล่องข้อความ
{{% /alert %}}

## **คำถามที่พบบ่อย**

**Can I set semi-transparent fills for columns/areas while keeping the border opaque?**

Yes. Fill transparency and the outline are configured separately. This is useful for improving the readability of the grid and data in dense visualizations.

**How can I deal with data labels when they overlap?**

Reduce the font size, disable nonessential label components (for example, categories), adjust the label position, show labels only for selected points if necessary, or switch the format to "value + legend".

**Can I apply gradient or pattern fills to series?**

Yes. Series support solid, gradient, and pattern fills. In practice, use gradients sparingly and avoid combinations that reduce contrast with the grid and text.