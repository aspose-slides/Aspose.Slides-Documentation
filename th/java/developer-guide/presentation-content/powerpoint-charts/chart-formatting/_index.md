---
title: จัดรูปแบบแผนภูมิเพื่อการนำเสนอใน Java
linktitle: การจัดรูปแบบแผนภูมิ
type: docs
weight: 60
url: /th/java/chart-formatting/
keywords:
- จัดรูปแบบแผนภูมิ
- การจัดรูปแบบแผนภูมิ
- เอนทิตีแผนภูมิ
- คุณสมบัติของแผนภูมิ
- การตั้งค่าแผนภูมิ
- ตัวเลือกแผนภูมิ
- คุณสมบัติตัวอักษร
- ขอบโค้ง
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้การจัดรูปแบบแผนภูมิใน Aspose.Slides สำหรับ Java และยกระดับการนำเสนอ PowerPoint ของคุณด้วยสไตล์มืออาชีพที่ดึงดูดสายตา."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีจัดรูปแบบแผนภูมิในงานนำเสนอ PowerPoint ด้วย Aspose.Slides โดยแสดงวิธีปรับแต่งส่วนประกอบหลักของแผนภูมิ เช่น แกน, เส้นตาราง, ชื่อเรื่อง, คำอธิบาย, พื้นที่พล็อต, และการเติมสีผนัง เพื่อปรับปรุงรูปลักษณ์และความอ่านง่ายของข้อมูลแผนภูมิ

นอกจากนี้ยังสาธิตวิธีตั้งค่าคุณสมบัติตัวอักษรสำหรับข้อความในแผนภูมิ, นำรูปแบบตัวเลขที่ตั้งล่วงหน้าและแบบกำหนดเองไปใช้กับข้อมูลแผนภูมิ, และเปิดใช้งานมุมโค้งของพื้นที่แผนภูมิ ตัวอย่างเหล่านี้แสดงวิธีควบคุมทั้งสไตล์การแสดงผลและการนำเสนอข้อมูลของแผนภูมิในงานนำเสนอ

## **จัดรูปแบบเอนทิตีของแผนภูมิ**
Aspose.Slides for Java ให้ผู้พัฒนาสร้างแผนภูมิกำหนดเองบนสไลด์ตั้งแต่เริ่มต้น บทความนี้อธิบายวิธีจัดรูปแบบเอนทิตีแผนภูมิต่าง ๆ รวมถึงแกนประเภทและค่า

Aspose.Slides for Java มี API ที่เรียบง่ายสำหรับจัดการเอนทิตีแผนภูมิต่าง ๆ และจัดรูปแบบโดยใช้ค่าแบบกำหนดเอง:

1. สร้างอินสแตนซ์ของ [**Presentation**](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) class.
1. รับอ้างอิงของสไลด์ตามดัชนีของมัน.
1. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นและประเภทที่ต้องการ (ในตัวอย่างนี้ใช้ ChartType.LineWithMarkers).
1. เข้าถึงแกนค่า (Value Axis) ของแผนภูมิและตั้งค่าคุณสมบัติดังต่อไปนี้:
   1. ตั้งค่า **Line format** สำหรับเส้นตารางหลักของแกนค่า
   1. ตั้งค่า **Line format** สำหรับเส้นตารางรองของแกนค่า
   1. ตั้งค่า **Number Format** สำหรับแกนค่า
   1. ตั้งค่า **Min, Max, Major and Minor units** สำหรับแกนค่า
   1. ตั้งค่า **Text Properties** สำหรับข้อมูลแกนค่า
   1. ตั้งค่า **Title** สำหรับแกนค่า
   1. ตั้งค่า **Line Format** สำหรับแกนค่า
1. เข้าถึงแกนประเภท (Category Axis) ของแผนภูมิและตั้งค่าคุณสมบัติดังต่อไปนี้:
   1. ตั้งค่า **Line format** สำหรับเส้นตารางหลักของแกนประเภท
   1. ตั้งค่า **Line format** สำหรับเส้นตารางรองของแกนประเภท
   1. ตั้งค่า **Text Properties** สำหรับข้อมูลแกนประเภท
   1. ตั้งค่า **Title** สำหรับแกนประเภท
   1. ตั้งค่า **Label Positioning** สำหรับแกนประเภท
   1. ตั้งค่า **Rotation Angle** สำหรับป้ายกำกับแกนประเภท
1. เข้าถึงคำอธิบายแผนภูมิ (Legend) และตั้งค่า **Text Properties** สำหรับคำอธิบาย
1. ตั้งค่าให้แสดงคำอธิบายแผนภูมิโดยไม่ทับซ้อนกับแผนภูมิ
1. เข้าถึง **Secondary Value Axis** ของแผนภูมิและตั้งค่าคุณสมบัติดังต่อไปนี้:
   1. เปิดใช้งาน **Value Axis** รอง
   1. ตั้งค่า **Line Format** สำหรับแกนค่ารอง
   1. ตั้งค่า **Number Format** สำหรับแกนค่ารอง
   1. ตั้งค่า **Min, Max, Major and Minor units** สำหรับแกนค่ารอง
1. ตอนนี้พล็อตชุดข้อมูลแรกของแผนภูมิบนแกนค่ารอง
1. ตั้งค่าสีเติมของพื้นผนังด้านหลังของแผนภูมิ
1. ตั้งค่าสีเติมของพื้นที่พล็อตของแผนภูมิ
1. เขียนงานนำเสนอที่แก้ไขแล้วลงในไฟล์ PPTX

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรก
    ISlide slide = pres.getSlides().get_Item(0);

    // เพิ่มแผนภูมิตัวอย่าง
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    // ตั้งค่าชื่อเรื่องแผนภูมิ
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // ตั้งค่ารูปแบบเส้นตารางหลักสำหรับแกนค่า
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    // ตั้งค่ารูปแบบเส้นตารางรองสำหรับแกนค่า
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // ตั้งค่ารูปแบบตัวเลขของแกนค่า
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    // ตั้งค่าค่าสูงสุดและต่ำสุดของแผนภูมิ
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    // ตั้งค่าคุณสมบัติตัวอักษรของแกนค่า
    IChartPortionFormat txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(NullableBool.True);
    txtVal.getFillFormat().setFillType(FillType.Solid);
    txtVal.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkGreen));
    txtVal.setLatinFont(new FontData("Times New Roman"));

    // ตั้งค่าชื่อแกนค่า
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(NullableBool.True);

    // ตั้งค่ารูปแบบเส้นตารางหลักสำหรับแกนประเภท
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    // ตั้งค่ารูปแบบเส้นตารางรองสำหรับแกนประเภท
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // ตั้งค่าคุณสมบัติตัวอักษรของแกนประเภท
    IChartPortionFormat txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(NullableBool.True);
    txtCat.getFillFormat().setFillType(FillType.Solid);
    txtCat.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    txtCat.setLatinFont(new FontData("Arial"));

    // ตั้งค่าชื่อแกนประเภท
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // ตั้งค่าตำแหน่งป้ายกำกับแกนประเภท
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);

    // ตั้งค่ามุมการหมุนของป้ายกำกับแกนประเภท
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    // ตั้งค่าคุณสมบัติตัวอักษรของคำอธิบายแผนภูมิ
    IChartPortionFormat txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(NullableBool.True);
    txtleg.getFillFormat().setFillType(FillType.Solid);
    txtleg.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkRed));

    // ตั้งค่าให้แสดงคำอธิบายแผนภูมิโดยไม่ทับซ้อนกับแผนภูมิ

    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // ตั้งค่าแกนค่ารอง
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);

    // ตั้งค่ารูปแบบตัวเลขของแกนค่ารอง
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");

    // ตั้งค่าค่าสูงสุดและต่ำสุดของแผนภูมิ
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20f);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5f);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0f);

    // ตั้งค่าสีผนังด้านหลังของแผนภูมิ
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    // ตั้งค่าสีพื้นที่พล็อต
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(new Color(PresetColor.LightCyan));

    // บันทึกงานนำเสนอ
    pres.save("FormattedChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ตั้งค่าคุณสมบัติตัวอักษรสำหรับแผนภูมิ**
Aspose.Slides for Java ให้การสนับสนุนการตั้งค่าคุณสมบัติตัวอักษรสำหรับแผนภูมิ โปรดทำตามขั้นตอนต่อไปนี้เพื่อกำหนดคุณสมบัติตัวอักษรสำหรับแผนภูมิ

- สร้างวัตถุ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) class.
- เพิ่มแผนภูมิบนสไลด์
- ตั้งค่าความสูงของตัวอักษร
- บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างโค้ดด้านล่างนี้แสดงให้ดู

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    pres.save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ตั้งค่ารูปแบบตัวเลข**
Aspose.Slides for Java มี API ที่เรียบง่ายสำหรับจัดการรูปแบบข้อมูลแผนภูมิ:

1. สร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) class.
1. รับอ้างอิงของสไลด์ตามดัชนีของมัน.
1. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นและประเภทที่ต้องการ (ตัวอย่างนี้ใช้ **ChartType.ClusteredColumn**).
1. ตั้งค่ารูปแบบตัวเลขจากค่า preset ที่มีอยู่
1. เเบบแผนภูมิข้อมูลในแต่ละชุดข้อมูลและตั้งค่ารูปแบบตัวเลขของข้อมูลแผนภูมิ
1. บันทึกงานนำเสนอ
1. ตั้งค่ารูปแบบตัวเลขแบบกำหนดเอง
1. แบบแผนภูมิข้อมูลในแต่ละชุดข้อมูลและตั้งค่ารูปแบบตัวเลขต่างกันสำหรับข้อมูลแผนภูมิ
1. บันทึกงานนำเสนอ

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรกของงานนำเสนอ
    ISlide slide = pres.getSlides().get_Item(0);

    // เพิ่มแผนภูมิคอลัมน์แบบกลุ่มเริ่มต้น
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

    // เข้าถึงคอลเลคชันของชุดข้อมูลแผนภูมิ
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    // วนรอบผ่านชุดข้อมูลแผนภูมิทั้งหมด
    for (IChartSeries ser : series) 
    {
        // วนรอบผ่านเซลข้อมูลแต่ละรายการในชุดข้อมูล
        for (IChartDataPoint cell : ser.getDataPoints()) 
        {
            // ตั้งค่ารูปแบบตัวเลข
            cell.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    // บันทึกงานนำเสนอ
    pres.save("PresetNumberFormat.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

ค่ารูปแบบตัวเลข preset ที่เป็นไปได้พร้อมด้วยดัชนี preset ที่สามารถใช้ได้ มีดังนี้:

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

## **ตั้งค่าขอบโค้งของพื้นที่แผนภูมิ**
Aspose.Slides for Java ให้การสนับสนุนการตั้งค่าพื้นที่แผนภูมิ วิธี [**hasRoundedCorners**](https://reference.aspose.com/slides/th/java/com.aspose.slides/IChart#hasRoundedCorners--) และ [**setRoundedCorners**](https://reference.aspose.com/slides/th/java/com.aspose.slides/IChart#setRoundedCorners-boolean-) ถูกเพิ่มในอินเทอร์เฟซ [IChart](https://reference.aspose.com/slides/th/java/com.aspose.slides/IChart) และคลาส [Chart](https://reference.aspose.com/slides/th/java/com.aspose.slides/Chart)

1. สร้างวัตถุ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) class.
1. เพิ่มแผนภูมิบนสไลด์
1. ตั้งค่าชนิดการเติมและสีการเติมของแผนภูมิ
1. ตั้งค่าคุณสมบัติขมุมโค้งเป็น True
1. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างโค้ดด้านล่างนี้แสดงให้ดู

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    chart.getLineFormat().setStyle(LineStyle.Single);
    chart.setRoundedCorners(true);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**ฉันสามารถตั้งค่าการเติมกึ่งโปร่งใสสำหรับคอลัมน์/พื้นที่โดยให้ขอบคงเป็นทึบได้หรือไม่?**

ได้ การโปร่งใสของการเติมและเส้นขอบถูกกำหนดแยกกัน ซึ่งเป็นประโยชน์ในการทำให้ตารางและข้อมูลในภาพที่แน่นอ่านง่ายขึ้น

**ฉันจะจัดการกับป้ายข้อมูลเมื่อติดกันอย่างไร?**

ลดขนาดตัวอักษร, ปิดใช้งานส่วนประกอบของป้ายที่ไม่สำคัญ (เช่น ประเภท), ตั้งค่าการชดเชย/ตำแหน่งของป้าย, แสดงป้ายเฉพาะจุดที่เลือกเท่านั้นถ้าจำเป็น, หรือสลับรูปแบบเป็น “ค่า + คำอธิบาย”

**ฉันสามารถใช้การเติมแบบไล่สีหรือรูปแบบให้กับชุดข้อมูลได้หรือไม่?**

ได้ ทั้งการเติมสีทึบและการเติมไล่สี/รูปแบบมักจะพร้อมใช้ ในการปฏิบัติ ควรใช้การไล่สีอย่างระมัดระวังและหลีกเลี่ยงการผสมที่ลดความคอนทราสต์กับตารางและข้อความ.