---
title: จัดรูปแบบแผนภูมิการนำเสนอบน Android
linktitle: การจัดรูปแบบแผนภูมิ
type: docs
weight: 60
url: /th/androidjava/chart-formatting/
keywords:
- จัดรูปแบบแผนภูมิ
- การจัดรูปแบบแผนภูมิ
- องค์ประกอบแผนภูมิ
- คุณสมบัติของแผนภูมิ
- การตั้งค่าแผนภูมิ
- ตัวเลือกแผนภูมิ
- คุณสมบัติฟอนต์
- ขอบโค้ง
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้การจัดรูปแบบแผนภูมิใน Aspose.Slides สำหรับ Android ผ่าน Java และยกระดับการนำเสนอ PowerPoint ของคุณด้วยสไตล์มืออาชีพที่ดึงดูดสายตา"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการจัดรูปแบบแผนภูมิในงานนำเสนอ PowerPoint ด้วย Aspose.Slides โดยแสดงวิธีการปรับแต่งองค์ประกอบสำคัญของแผนภูมิ เช่น แกน, เส้นตาราง, ชื่อเรื่อง, คำอธิบาย, พื้นที่พล็อต, และการเติมสีผนัง เพื่อปรับปรุงรูปลักษณ์และความอ่านง่ายของข้อมูลแผนภูมิ

บทความยังแสดงวิธีการตั้งค่าลักษณะฟอนต์สำหรับข้อความในแผนภูมิ, ใช้รูปแบบตัวเลขที่กำหนดล่วงหน้าและกำหนดเองสำหรับข้อมูลแผนภูมิ, และเปิดใช้งานมุมโค้งสำหรับพื้นที่แผนภูมิ ตัวอย่างเหล่านี้แสดงวิธีควบคุมทั้งสไตล์ภาพและการนำเสนอข้อมูลของแผนภูมิในงานนำเสนอ

## **จัดรูปแบบเอนทิตี้ของแผนภูมิ**
Aspose.Slides for Android via Java ให้ผู้พัฒนาสร้างแผนภูมิแบบกำหนดเองตั้งแต่ต้นบนสไลด์ บทความนี้อธิบายวิธีการจัดรูปแบบเอนทิตี้ของแผนภูมิต่าง ๆ รวมถึงแกนหมวดหมู่และแกนค่าของแผนภูมิ

Aspose.Slides for Android via Java มี API ง่ายสำหรับการจัดการเอนทิตี้ของแผนภูมิและจัดรูปแบบด้วยค่าที่กำหนดเอง:

1. สร้างอินสแตนซ์ของคลาส [**Presentation**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) 
1. รับอ้างอิงสไลด์ตามดัชนี
1. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นและประเภทที่ต้องการ (ในตัวอย่างนี้เราจะใช้ ChartType.LineWithMarkers)
1. เข้าถึง Value Axis ของแผนภูมิและตั้งค่าคุณสมบัติดังต่อไปนี้:
   1. ตั้งค่า **Line format** สำหรับ Value Axis Major Grid lines
   1. ตั้งค่า **Line format** สำหรับ Value Axis Minor Grid lines
   1. ตั้งค่า **Number Format** สำหรับ Value Axis
   1. ตั้งค่า **Min, Max, Major and Minor units** สำหรับ Value Axis
   1. ตั้งค่า **Text Properties** สำหรับข้อมูลของ Value Axis
   1. ตั้งค่า **Title** สำหรับ Value Axis
   1. ตั้งค่า **Line Format** สำหรับ Value Axis
1. เข้าถึง Category Axis ของแผนภูมิและตั้งค่าคุณสมบัติดังต่อไปนี้:
   1. ตั้งค่า **Line format** สำหรับ Category Axis Major Grid lines
   1. ตั้งค่า **Line format** สำหรับ Category Axis Minor Grid lines
   1. ตั้งค่า **Text Properties** สำหรับข้อมูลของ Category Axis
   1. ตั้งค่า **Title** สำหรับ Category Axis
   1. ตั้งค่า **Label Positioning** สำหรับ Category Axis
   1. ตั้งค่า **Rotation Angle** สำหรับป้ายชื่อ Category Axis
1. เข้าถึง Legend ของแผนภูมิและตั้งค่า **Text Properties** ให้กับมัน
1. ตั้งค่าให้แสดง Legend ของแผนภูมิโดยไม่ให้ทับซ้อนกับแผนภูมิ
1. เข้าถึง Secondary Value Axis ของแผนภูมิและตั้งค่าคุณสมบัติดังต่อไปนี้:
   1. เปิดใช้งาน Secondary **Value Axis**
   1. ตั้งค่า **Line Format** สำหรับ Secondary Value Axis
   1. ตั้งค่า **Number Format** สำหรับ Secondary Value Axis
   1. ตั้งค่า **Min, Max, Major and Minor units** สำหรับ Secondary Value Axis
1. ตอนนี้พล็อตซีรีส์แผนภูมิแรกบน Secondary Value Axis
1. ตั้งค่าสีเติมผนังด้านหลังของแผนภูมิ
1. ตั้งค่าสีเติมพื้นที่พล็อตของแผนภูมิ
1. เขียนไฟล์พรีเซนเทชันที่แก้ไขแล้วเป็นไฟล์ PPTX

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรก
    ISlide slide = pres.getSlides().get_Item(0);

    // เพิ่มแผนภูมุตัวอย่าง
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    // ตั้งค่าชื่อแผนภูมิ
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // ตั้งค่ารูปแบบเส้นกริดหลักสำหรับแกนค่า
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    // ตั้งค่ารูปแบบเส้นกริดรองสำหรับแกนค่า
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // ตั้งค่ารูปแบบตัวเลขของแกนค่า
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    // ตั้งค่าค่าสูงสุดและค่าต่ำสุดของแผนภูมิ
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    // ตั้งค่าคุณสมบัติข้อความของแกนค่า
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

    // ตั้งค่ารูปแบบเส้นกริดหลักสำหรับแกนหมวดหมู่
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    // ตั้งค่ารูปแบบเส้นกริดรองสำหรับแกนหมวดหมู่
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // ตั้งค่าคุณสมบัติข้อความของแกนหมวดหมู่
    IChartPortionFormat txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(NullableBool.True);
    txtCat.getFillFormat().setFillType(FillType.Solid);
    txtCat.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    txtCat.setLatinFont(new FontData("Arial"));

    // ตั้งค่าชื่อหมวดหมู่
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // ตั้งค่าตำแหน่งป้ายกำกับของแกนหมวดหมู่
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);

    // ตั้งค่ามุมการหมุนของป้ายกำกับแกนหมวดหมู่
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    // ตั้งค่าคุณสมบัติข้อความของ Legend
    IChartPortionFormat txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(NullableBool.True);
    txtleg.getFillFormat().setFillType(FillType.Solid);
    txtleg.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkRed));

    // ตั้งค่าให้แสดง Legend ของแผนภูมิโดยไม่ทับซ้อนแผนภูมิ

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

    // ตั้งค่าค่าสูงสุดและค่าต่ำสุดของแผนภูมิ
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

    // บันทึกพรีเซนเทชัน
    pres.save("FormattedChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ตั้งค่าคุณสมบัติดีไซน์ฟอนต์สำหรับแผนภูมิ**
Aspose.Slides for Android via Java ให้การสนับสนุนการตั้งค่าคุณสมบัติที่เกี่ยวข้องกับฟอนต์สำหรับแผนภูมิ โปรดทำตามขั้นตอนด้านล่างเพื่อกำหนดคุณสมบัติฟอนต์สำหรับแผนภูมิ

- สร้างอ็อบเจกต์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) 
- เพิ่มแผนภูมิบนสไลด์
- กำหนดความสูงของฟอนต์
- บันทึกพรีเซนเทชันที่แก้ไขแล้ว

ตัวอย่างโค้ดต่อไปนี้เป็นตัวอย่าง

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
Aspose.Slides for Android via Java มี API ง่ายสำหรับการจัดการรูปแบบข้อมูลของแผนภูมิ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) 
1. รับอ้างอิงสไลด์ตามดัชนี
1. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นและประเภทที่ต้องการ (ตัวอย่างนี้ใช้ **ChartType.ClusteredColumn**)
1. ตั้งค่ารูปแบบตัวเลขล่วงหน้าจากค่า preset ที่มีอยู่
1. วนผ่านเซลล์ข้อมูลของแผนภูมิในแต่ละซีรีส์และตั้งค่ารูปแบบตัวเลขของข้อมูลแผนภูมิ
1. บันทึกพรีเซนเทชัน
1. ตั้งค่ารูปแบบตัวเลขที่กำหนดเอง
1. วนผ่านเซลล์ข้อมูลของแผนภูมิในแต่ละซีรีส์และตั้งค่ารูปแบบตัวเลขของข้อมูลแผนภูมิที่แตกต่างกัน
1. บันทึกพรีเซนเทชัน

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์การนำเสนอแรก
    ISlide slide = pres.getSlides().get_Item(0);

    // เพิ่มแผนภูมิคอลัมน์แบบกลุ่มเริ่มต้น
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

    // เข้าถึงคอลเลกชันของซีรีส์แผนภูมิ
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    // วนผ่านทุกซีรีส์ของแผนภูมิ
    for (IChartSeries ser : series) 
    {
        // วนผ่านทุกเซลล์ข้อมูลในซีรีส์
        for (IChartDataPoint cell : ser.getDataPoints()) 
        {
            // ตั้งค่ารูปแบบตัวเลข
            cell.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    // บันทึกการนำเสนอ
    pres.save("PresetNumberFormat.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

ค่ารูปแบบตัวเลขล่วงหน้าที่เป็นไปได้พร้อมดัชนี preset ที่สามารถใช้ได้มีดังต่อไปนี้:

|**0**|General|
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
Aspose.Slides for Android via Java ให้การสนับสนุนการตั้งค่าพื้นที่แผนภูมิ วิธีการ [**hasRoundedCorners**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChart#hasRoundedCorners--) และ [**setRoundedCorners**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChart#setRoundedCorners-boolean-) ได้ถูกเพิ่มลงในอินเทอร์เฟซ [IChart](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChart) และคลาส [Chart](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Chart) 

1. สร้างอ็อบเจกต์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) 
1. เพิ่มแผนภูมิบนสไลด์
1. ตั้งค่าประเภทการเติมและสีเติมของแผนภูมิ
1. ตั้งค่าคุณสมบัติมุมโค้งเป็น True
1. บันทึกพรีเซนเทชันที่แก้ไขแล้ว

ตัวอย่างโค้ดต่อไปนี้เป็นตัวอย่าง

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

**ฉันสามารถตั้งค่าการเติมแบบกึ่งโปร่งใสสำหรับคอลัมน์/พื้นที่โดยยังคงให้ขอบไม่โปร่งใสได้หรือไม่?**

ใช่ การตั้งค่าความโปร่งใสของการเติมและเส้นขอบทำแยกกัน ซึ่งช่วยให้ปรับปรุงความอ่านง่ายของตารางและข้อมูลในภาพที่หนาแน่น

**ฉันจะจัดการกับป้ายข้อมูลเมื่อตรงกันได้อย่างไร?**

ลดขนาดฟอนต์ ปิดการทำงานของส่วนที่ไม่สำคัญของป้าย (เช่น หมวดหมู่) ตั้งค่าออฟเซ็ต/ตำแหน่งของป้าย แสดงป้ายเฉพาะสำหรับจุดที่เลือกเมื่อต้องการ หรือเปลี่ยนรูปแบบเป็น "value + legend"

**ฉันสามารถใช้การเติมเต็มแบบไล่สีหรือรูปแบบลงในซีรีส์ได้หรือไม่?**

ใช้งานได้ ทั้งแบบสีทับทานและสีไล่สี/ลวดลาย จะเป็นช่วงเวลาที่ทำให้ใช้ไล่สีอย่างสั้น ๆ และหลีกเลี่ยงการผสมผสานที่ลดความคมชัดกับตารางและข้อความ

---
title: จัดรูปแบบแผนภูมิการนำเสนอบน Android
linktitle: การจัดรูปแบบแผนภูมิ
type: docs
weight: 60
url: /th/androidjava/chart-formatting/
keywords:
- จัดรูปแบบแผนภูมิ
- การจัดรูปแบบแผนภูมิ
- องค์ประกอบแผนภูมิ
- คุณสมบัติของแผนภูมิ
- การตั้งค่าแผนภูมิ
- ตัวเลือกแผนภูมิ
- คุณสมบัติฟอนต์
- ขอบโค้ง
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้การจัดรูปแบบแผนภูมิใน Aspose.Slides สำหรับ Android ผ่าน Java และยกระดับการนำเสนอ PowerPoint ของคุณด้วยสไตล์มืออาชีพที่ดึงดูดสายตา"
---