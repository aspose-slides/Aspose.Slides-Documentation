---
title: จัดรูปแบบแผนภูมิการนำเสนอใน JavaScript
linktitle: การจัดรูปแบบแผนภูมิ
type: docs
weight: 60
url: /th/nodejs-java/chart-formatting/
keywords:
- จัดรูปแบบแผนภูมิ
- การจัดรูปแบบแผนภูมิ
- เอนทิตีแผนภูมิ
- คุณสมบัติแผนภูมิ
- การตั้งค่าแผนภูมิ
- ตัวเลือกแผนภูมิ
- คุณสมบัติตัวอักษร
- ขอบโค้งมน
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้การจัดรูปแบบแผนภูมิใน Aspose.Slides สำหรับ Node.js ด้วย JavaScript และยกระดับงานนำเสนอ PowerPoint ของคุณด้วยสไตล์ระดับมืออาชีพที่ดึงดูดสายตา"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการจัดรูปแบบแผนภูมิในงานนำเสนอ PowerPoint ด้วย Aspose.Slides โดยแสดงวิธีการปรับแต่งองค์ประกอบสำคัญของแผนภูมิเช่น แกน, เส้นตาราง, ชื่อเรื่อง, คำอธิบาย, พื้นที่พล็อต, และการเติมสีผนัง เพื่อปรับปรุงลักษณะและความอ่านง่ายของข้อมูลแผนภูมิ

นอกจากนี้ยังสาธิตวิธีการตั้งค่าคุณสมบัติตัวอักษรสำหรับข้อความในแผนภูมิ, ใช้รูปแบบตัวเลขที่กำหนดไว้ล่วงหน้าและกำหนดเองกับข้อมูลแผนภูมิ, และเปิดใช้งานมุมโค้งมนสำหรับพื้นที่แผนภูมิ ตัวอย่างเหล่านี้แสดงให้เห็นวิธีควบคุมทั้งสไตล์ภาพและการนำเสนอข้อมูลของแผนภูมิในงานนำเสนอ

## **จัดรูปแบบเอนทิตีของแผนภูมิ**

Aspose.Slides for Node.js via Java ช่วยให้นักพัฒนาสร้างแผนภูมิตามต้องการตั้งแต่ต้น บทความนี้อธิบายวิธีการจัดรูปแบบเอนทิตีต่าง ๆ ของแผนภูมิรวมถึงแกนประเภทและค่า

Aspose.Slides for Node.js via Java มี API ที่ง่ายต่อการจัดการเอนทิตีของแผนภูมิและจัดรูปแบบด้วยค่าที่กำหนดเอง:

1. สร้างอินสแตนส์ของคลาส [**Presentation**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) 
1. ดึงอ้างอิงสไลด์โดยใช้ดัชนีของมัน
1. เพิ่มแผนภูมิด้วยข้อมูลค่าเริ่มต้นพร้อมกับประเภทที่ต้องการ (ในตัวอย่างนี้จะใช้ ChartType.LineWithMarkers)
1. เข้าถึง Value Axis ของแผนภูมิและตั้งค่าคุณสมบัติดังต่อไปนี้:
   1. ตั้งค่า **Line format** สำหรับ Value Axis Major Grid lines
   1. ตั้งค่า **Line format** สำหรับ Value Axis Minor Grid lines
   1. ตั้งค่า **Number Format** สำหรับ Value Axis
   1. ตั้งค่า **Min, Max, Major and Minor units** สำหรับ Value Axis
   1. ตั้งค่า **Text Properties** สำหรับข้อมูล Value Axis
   1. ตั้งค่า **Title** สำหรับ Value Axis
   1. ตั้งค่า **Line Format** สำหรับ Value Axis
1. เข้าถึง Category Axis ของแผนภูมิและตั้งค่าคุณสมบัติดังต่อไปนี้:
   1. ตั้งค่า **Line format** สำหรับ Category Axis Major Grid lines
   1. ตั้งค่า **Line format** สำหรับ Category Axis Minor Grid lines
   1. ตั้งค่า **Text Properties** สำหรับข้อมูล Category Axis
   1. ตั้งค่า **Title** สำหรับ Category Axis
   1. ตั้งค่า **Label Positioning** สำหรับ Category Axis
   1. ตั้งค่า **Rotation Angle** สำหรับป้ายกำกับ Category Axis
1. เข้าถึง Legend ของแผนภูมิและตั้งค่า **Text Properties** สำหรับพวกมัน
1. ตั้งค่าให้แสดง Legend ของแผนภูมิโดยไม่ทับซ้อนกับแผนภูมิ
1. เข้าถึง **Secondary Value Axis** ของแผนภูมิและตั้งค่าคุณสมบัติดังต่อไปนี้:
   1. เปิดใช้งาน Secondary **Value Axis**
   1. ตั้งค่า **Line Format** สำหรับ Secondary Value Axis
   1. ตั้งค่า **Number Format** สำหรับ Secondary Value Axis
   1. ตั้งค่า **Min, Max, Major and Minor units** สำหรับ Secondary Value Axis
1. ตอนนี้พล็อตซีรีส์แรกของแผนภูมิบน Secondary Value Axis
1. ตั้งค่าสีเติมผนังด้านหลังของแผนภูมิ
1. ตั้งค่าสีเติมพื้นที่พล็อตของแผนภูมิ
1. เขียนงานนำเสนอที่แก้ไขแล้วลงไฟล์ PPTX

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation
var pres = new aspose.slides.Presentation();
try {
    // เข้าถึงสไลด์แรก
    var slide = pres.getSlides().get_Item(0);
    // เพิ่มแผนภูมิตัวอย่าง
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 50, 50, 500, 400);
    // ตั้งค่าชื่อเรื่องของแผนภูมิ
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    var chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // ตั้งค่ารูปแบบเส้นกริดหลักสำหรับแกนค่า
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    // ตั้งค่ารูปแบบเส้นกริดรองสำหรับแกนค่า
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);
    // ตั้งค่ารูปแบบตัวเลขของแกนค่า
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");
    // ตั้งค่าค่าสูงสุดและค่าต่ำสุดของแผนภูมิ
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();
    chart.getAxes().getVerticalAxis().setMaxValue(15.0);
    chart.getAxes().getVerticalAxis().setMinValue(-2.0);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0);
    // ตั้งค่าคุณลักษณะข้อความของแกนค่า
    var txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(aspose.slides.NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(aspose.slides.NullableBool.True);
    txtVal.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtVal.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.DarkGreen));
    txtVal.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // ตั้งค่าชื่อเรื่องของแกนค่า
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    var valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // ตั้งค่ารูปแบบเส้นกริดหลักสำหรับแกนหมวดหมู่
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    // ตั้งค่ารูปแบบเส้นกริดรองสำหรับแกนหมวดหมู่
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);
    // ตั้งค่าคุณลักษณะข้อความของแกนหมวดหมู่
    var txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(aspose.slides.NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(aspose.slides.NullableBool.True);
    txtCat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtCat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    txtCat.setLatinFont(new aspose.slides.FontData("Arial"));
    // ตั้งค่าชื่อเรื่องของแกนหมวดหมู่
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");
    var catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // ตั้งค่าตำแหน่งป้ายกำกับของแกนหมวดหมู่
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(aspose.slides.TickLabelPositionType.Low);
    // ตั้งค่ามุมการหมุนของป้ายกำกับแกนหมวดหมู่
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);
    // ตั้งค่าคุณลักษณะข้อความของคำอธิบาย
    var txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(aspose.slides.NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(aspose.slides.NullableBool.True);
    txtleg.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtleg.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.DarkRed));
    // ตั้งค่าการแสดงคำอธิบายแผนภูมิโดยไม่ทับซ้อนกับแผนภูมิ
    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;
    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // ตั้งค่าแกนค่ารอง
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);
    // ตั้งค่ารูปแบบตัวเลขของแกนค่ารอง
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");
    // ตั้งค่าค่าสูงสุดและค่าต่ำสุดของแผนภูมิ
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();
    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20.0);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5.0);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0);
    // ตั้งค่าสีผนังด้านหลังของแผนภูมิ
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    chart.getFloor().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // ตั้งค่าสีพื้นที่พล็อต
    chart.getPlotArea().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.LightCyan));
    // บันทึกงานนำเสนอ
    pres.save("FormattedChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ตั้งค่าคุณสมบัติตัวอักษรสำหรับแผนภูมิ**

Aspose.Slides for Node.js via Java รองรับการตั้งค่าคุณสมบัติตัวอักษรสำหรับแผนภูมิ โปรดทำตามขั้นตอนด้านล่างเพื่อกำหนดค่าตัวอักษรสำหรับแผนภูมิ

- สร้างอ็อบเจกต์คลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) 
- เพิ่มแผนภูมิกับสไลด์
- ตั้งค่าความสูงของฟอนต์
- บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างโค้ดต่อไปนี้เป็นตัวอย่างที่ให้ไว้

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    pres.save("FontPropertiesForChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ตั้งค่ารูปแบบตัวเลข**

Aspose.Slides for Node.js via Java มี API ที่ง่ายต่อการจัดการรูปแบบข้อมูลของแผนภูมิ:

1. สร้างอินสแตนส์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) 
1. ดึงอ้างอิงสไลด์โดยใช้ดัชนีของมัน
1. เพิ่มแผนภูมด้วยข้อมูลค่าเริ่มต้นพร้อมกับประเภทที่ต้องการ (ตัวอย่างนี้ใช้ **ChartType.ClusteredColumn**)
1. ตั้งค่ารูปแบบตัวเลขจากค่าที่กำหนดไว้ล่วงหน้าที่เป็นไปได้
1. วนผ่านเซลล์ข้อมูลของแผนภูมิในแต่ละซีรีส์และตั้งค่ารูปแบบตัวเลขของข้อมูลแผนภูมิ
1. บันทึกงานนำเสนอ
1. ตั้งค่ารูปแบบตัวเลขที่กำหนดเอง
1. วนผ่านเซลล์ข้อมูลของแผนภูมิในแต่ละซีรีส์และตั้งค่ารูปแบบตัวเลขของข้อมูลแผนภูมิที่แตกต่างกัน
1. บันทึกงานนำเสนอ

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation
var pres = new aspose.slides.Presentation();
try {
    // เข้าถึงสไลด์แรกของงานนำเสนอ
    var slide = pres.getSlides().get_Item(0);
    // เพิ่มแผนภูมิคอลัมน์แบบกลุ่มเริ่มต้น
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 400);
    // เข้าถึงคอลเลกชันของซีรีส์แผนภูมิ
    var series = chart.getChartData().getSeries();
    // วนผ่านทุกซีรีส์ของแผนภูมิ
    for (var i = 0; i < series.size(); i++) {
        var ser = series.get_Item(i);
        // วนผ่านทุกเซลล์ข้อมูลในซีรีส์
        for (var j = 0; j < ser.getDataPoints().size(); j++) {
            var cell = ser.getDataPoints().get_Item(j);
            // ตั้งค่ารูปแบบตัวเลข
            cell.getValue().getAsCell().setPresetNumberFormat(java.newByte(10));// 0.00%
        }
    }
    // บันทึกงานนำเสนอ
    pres.save("PresetNumberFormat.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

ค่ารูปแบบตัวเลขที่กำหนดไว้ล่วงหน้าที่เป็นไปได้พร้อมกับดัชนีของแต่ละรูปแบบมีดังต่อไปนี้:

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

## **ตั้งค่าขอบโค้งมนของพื้นที่แผนภูมิ**

Aspose.Slides for Node.js via Java รองรับการตั้งค่าพื้นที่แผนภูมิ วิธีการ [**hasRoundedCorners**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Chart#hasRoundedCorners--) และ [**setRoundedCorners**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Chart#setRoundedCorners-boolean-) ได้ถูกเพิ่มเข้าไปในคลาส [Chart](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Chart) 

1. สร้างอ็อบเจกต์คลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) 
1. เพิ่มแผนภูมิกับสไลด์
1. ตั้งค่าประเภทการเติมและสีการเติมของแผนภูมิ
1. ตั้งค่าคุณสมบัติ round corner เป็น True
1. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างโค้ดต่อไปนี้เป็นตัวอย่างที่ให้ไว้

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getLineFormat().setStyle(aspose.slides.LineStyle.Single);
    chart.setRoundedCorners(true);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**ฉันสามารถตั้งค่าการเติมกึ่งโปร่งใสสำหรับคอลัมน์/พื้นที่โดยให้ขอบคงที่เป็นทึบได้หรือไม่?**

ได้ การตั้งค่าความโปร่งใสของการเติมและเส้นขอบทำแยกจากกัน ซึ่งเป็นประโยชน์สำหรับการปรับปรุงความอ่านง่ายของตารางและข้อมูลในภาพที่มีความหนาแน่นสูง

**ฉันจะจัดการกับป้ายข้อมูลเมื่อมันทับซ้อนกันอย่างไร?**

ลดขนาดฟอนต์, ปิดใช้งานส่วนประกอบของป้ายที่ไม่จำเป็น (เช่น หมวดหมู่), ตั้งค่าการชิด/ตำแหน่งของป้าย, แสดงป้ายเฉพาะจุดที่เลือกเมื่อจำเป็น, หรือเปลี่ยนรูปแบบเป็น “value + legend”

**ฉันสามารถใช้การเติมแบบไล่สีหรือรูปแบบกับซีรีส์ได้หรือไม่?**

ได้ ทั้งการเติมแบบสีเดียวและแบบไล่สี/ลวดลายมักจะพร้อมใช้งาน ในการปฏิบัติ ใช้ไล่สีอย่างระมัดระวังและหลีกเลี่ยงการผสมที่ทำให้ความคอนทราสต์กับตารางและข้อความลดลง