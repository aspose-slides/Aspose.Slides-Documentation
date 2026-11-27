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
- ขอบโค้งมน
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้การจัดรูปแบบแผนภูมิใน Aspose.Slides สำหรับ Android ด้วย Java และยกระดับการนำเสนอ PowerPoint ของคุณด้วยแกนที่กำหนดเอง, ฟอนต์, รูปแบบตัวเลข, และขอบแผนภูมิที่โค้งมน."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีจัดรูปแบบแผนภูมิในงานนำเสนอ PowerPoint ด้วย Aspose.Slides โดยแสดงวิธีปรับแต่งองค์ประกอบสำคัญของแผนภูมิ เช่น แกน, เส้นกริด, ชื่อเรื่อง, คำอธิบาย, พื้นที่พล็อต, และการเติมสีผนัง เพื่อปรับปรุงลักษณะและความอ่านง่ายของข้อมูลแผนภูมิ

นอกจากนี้ยังแสดงวิธีตั้งค่าคุณสมบัติฟอนต์สำหรับข้อความในแผนภูมิ, ใช้รูปแบบตัวเลขที่กำหนดล่วงหน้าในข้อมูลแผนภูมิ, และเปิดใช้งานมุมโค้งมนสำหรับพื้นที่แผนภูมิ ตัวอย่างเหล่านี้แสดงวิธีควบคุมทั้งสไตล์ภาพและการนำเสนอข้อมูลของแผนภูมิในงานนำเสนอ

สำหรับการเติมสีและขอบแยกกันบนช่วงที่เพิ่มและลดลง ดูที่[stock chart example](/slides/th/androidjava/create-chart/#create-stock-charts).

## **จัดรูปแบบส่วนประกอบของแผนภูมิ**

ใช้[IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/)เพื่อจัดรูปแบบชื่อแผนภูมิ, แกน, เส้นกริด, คำอธิบาย, และพื้นที่พล็อต ตัวอย่างนี้สร้างแผนภูมิเส้นที่มีเครื่องหมายและข้อมูลเริ่มต้น จากนั้นจึงใช้สไตล์ข้อความและเส้นที่แยกกันสำหรับแกนค่และแกนประเภท ขนาดฟอนต์และความกว้างเส้นระบุเป็น points; ป้ายชื่อประเภทจะหมุน 45 องศา

แกนค่าใช้[setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-)โดยอิสระจากเซลล์ต้นทาง ช่วงของแกนคือ -2 ถึง 15, ที่ช่วงหลักคือ 2 และที่ช่วงย่อยคือ 0.5 ตัวอย่างนี้ยังผสานการจัดรูปแบบเป็นเปอร์เซ็นต์กับ[setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setDisplayUnit-int-)ตั้งเป็นพัน ดังนั้นให้ปรับการตั้งค่าเหล่านี้ให้สอดคล้องกับความหมายและขนาดของข้อมูลของคุณ คำอธิบายอยู่ด้านนอกพื้นที่พล็อตเนื่องจาก[setOverlay](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegend/#setOverlay-boolean-)ถูกเรียกด้วย`false` การเติมสีผนังด้านหลังและพื้นใช้ผ่าน[getBackWall](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getBackWall--)และ[getFloor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getFloor--)แต่พื้นผิวเหล่านี้มองเห็นได้เฉพาะในแผนภูมิ 3D

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    IChartPortionFormat valueAxisText = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    valueAxisText.setFontBold(NullableBool.True);
    valueAxisText.setFontHeight(16);
    valueAxisText.setFontItalic(NullableBool.True);
    valueAxisText.getFillFormat().setFillType(FillType.Solid);
    valueAxisText.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen);
    valueAxisText.setLatinFont(new FontData("Times New Roman"));

    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valueAxisTitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valueAxisTitle.setText("Primary Axis");
    valueAxisTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valueAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valueAxisTitle.getPortionFormat().setFontHeight(20);
    valueAxisTitle.getPortionFormat().setFontBold(NullableBool.True);
    valueAxisTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 128, 0));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    IChartPortionFormat categoryAxisText = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    categoryAxisText.setFontBold(NullableBool.True);
    categoryAxisText.setFontHeight(16);
    categoryAxisText.setFontItalic(NullableBool.True);
    categoryAxisText.getFillFormat().setFillType(FillType.Solid);
    categoryAxisText.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    categoryAxisText.setLatinFont(new FontData("Arial"));

    chart.getAxes().getHorizontalAxis().setTitle(true);
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion categoryAxisTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    categoryAxisTitle.setText("Sample Category");
    categoryAxisTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    categoryAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    categoryAxisTitle.getPortionFormat().setFontHeight(20);
    categoryAxisTitle.getPortionFormat().setFontBold(NullableBool.True);
    categoryAxisTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    IChartPortionFormat legendText = chart.getLegend().getTextFormat().getPortionFormat();
    legendText.setFontBold(NullableBool.True);
    legendText.setFontHeight(16);
    legendText.setFontItalic(NullableBool.True);
    legendText.getFillFormat().setFillType(FillType.Solid);
    legendText.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed);

    chart.getLegend().setOverlay(false);

    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);

    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan);

    presentation.save("FormattedChart_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าคุณสมบัติฟอนต์สำหรับแผนภูมิ**

ตั้งขนาดฟอนต์เริ่มต้นสำหรับข้อความแผนภูมิผ่าน[Chart.getTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#getTextFormat--). ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบกลุ่มที่ใช้ฟอนต์ 20 point และเปิดใช้งานป้ายค่าของชุดข้อมูลแรกผ่าน[setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-). ส่วนประกอบข้อความที่มีการตั้งค่าฟอนต์เฉพาะของตนเองสามารถเขียนทับค่าตั้งต้นของแผนภูมิได้

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ใช้การกำหนดรูปแบบ Text Frame ซ้ำสำหรับ Legend ของแผนภูมิ**

เพื่อให้คำอธิบายตรงกับหัวข้อสไลด์ ให้ตั้งค่าฟอนต์ของหัวข้อผ่าน[getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--)บนย่อหน้าที่หนึ่ง เรียก[copyFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextformat/#copyFrom-com.aspose.slides.ITextFrame-)บนรูปแบบที่ได้จาก[legend's getTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformattedtextcontainer/#getTextFormat--) มันจะคัดลอกการตั้งค่า Text Frame, การฟอร์แมตของย่อหน้าแรก, และคุณสมบัติฟอนต์เริ่มต้นของย่อคนั้น การกำหนดรูปแบบที่ใช้โดยตรงกับส่วนย่อยหรือย่อหน้าถัดไปจะคงอยู่เฉพาะแหล่งที่มานั้น

ตัวอย่างใช้หัวข้อแบบหนา, ฟอนต์ Calibri 26 point สีฟ้าน้ำเงินเป็นแม่แบบ หลังจากสไตลิ่งคำอธิบาย จะเรียก[copyTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextformat/#copyTo-com.aspose.slides.ITextFrame-)เพื่อใช้รูปแบบเดียวกันกับคำบรรยายแยกต่างหาก

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IAutoShape heading = shapes.addAutoShape(ShapeType.Rectangle, 40, 20, 640, 40, false);
    ITextFrame sourceTextFrame = heading.addTextFrame("Quarterly sales");
    IPortionFormat font = sourceTextFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    font.setLatinFont(new FontData("Calibri"));
    font.setFontHeight(26);
    font.setFontBold(NullableBool.True);
    font.getFillFormat().setFillType(FillType.Solid);
    font.getFillFormat().getSolidFillColor().setColor(Color.rgb(32, 64, 96));

    IChart chart = shapes.addChart(ChartType.ClusteredColumn, 40, 75, 640, 360);
    chart.setStyle(StyleType.Style3);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.getCell(0, 0, 1).setValue("Retail");
    workbook.getCell(0, 0, 2).setValue("Online");
    workbook.getCell(0, 0, 3).setValue("Wholesale");
    for (int quarter = 1; quarter <= 4; quarter++) {
        workbook.getCell(0, quarter, 0).setValue("Q" + quarter);
    }

    chart.setLegend(true);
    chart.getLegend().setPosition(LegendPositionType.Bottom);
    IChartTextFormat legendFormat = chart.getLegend().getTextFormat();
    legendFormat.copyFrom(sourceTextFrame);

    IAutoShape caption = shapes.addAutoShape(ShapeType.Rectangle, 40, 460, 640, 40, false);
    ITextFrame captionTextFrame = caption.addTextFrame("Sales in millions of dollars");
    legendFormat.copyTo(captionTextFrame);

    presentation.save("legend-formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ในงานนำเสนอที่บันทึก คำอธิบายและคำบรรยายจะตรงกับหัวข้อในด้านขนาด, น้ำหนัก, และสี คำอธิบายยังแสดงชื่อชุดข้อมูล, ส่วนคำบรรยายยังคงข้อความของตนเอง หากส่วนใดในคำบรรยายมีขนาดฟอนต์ที่ระบุไว้แล้ว ขนาดนั้นจะมีลำดับความสำคัญเหนือค่าเริ่มต้นของย่อหน้าที่คัดลอกมา

| ก่อนคัดลอก | หลังคัดลอก |
| --- | --- |
| ![Quarterly sales chart with regular black legend labels and a black caption](legend-formatting-before.png) | ![The same chart with larger, bold navy legend labels and a matching caption](legend-formatting.png) |

## **ตั้งค่ารูปแบบตัวเลข**

ใช้[IChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setPresetNumberFormat-byte-)เพื่อใช้รูปแบบตัวเลขที่มีอยู่ล่วงหน้าในเซลล์สมุดงานของแผนภูมิ ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบกลุ่มที่ใช้ข้อมูลที่รองรับโดยเซลล์และใส่รูปแบบดัชนี 10 (`0.00%`) ให้กับเซลล์ค่าของแต่ละชุดข้อมูล สิ่งนี้เปลี่ยนวิธีแสดงค่าภายในสมุดงานโดยไม่เปลี่ยนตัวเลขพื้นฐาน; ตัวอย่างเช่น 0.25 จะถูกแสดงเป็น 25.00% รูปแบบแกนและป้ายข้อมูลสามารถกำหนดแยกกันได้

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
    IChartSeriesCollection series = chart.getChartData().getSeries();

    for (IChartSeries chartSeries : series)
    {
        for (IChartDataPoint dataPoint : chartSeries.getDataPoints())
        {
            dataPoint.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    presentation.save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ตารางต่อไปนี้แสดงดัชนีรูปแบบตัวเลขที่มีอยู่ล่วงหน้าพร้อมตัวอย่างรูปแบบ Excel สำหรับภาษอังกฤษ (สหรัฐอเมริกา) สตริงรูปแบบที่แน่นอนและการแสดงผลอาจแตกต่างกันตามแอปพลิเคชันและภาษาที่ตั้งค่า โดยเฉพาะอย่างยิ่งสำหรับสกุลเงินและวันที่ รูปแบบ Excel บางรูปแบบยังแตกต่างจากค่าเริ่มต้นในมาตรฐาน OOXML ตามที่อธิบายใน[Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

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

## **ตั้งค่าขอบโค้งมนของพื้นที่แผนภูมิ**

เรียก[IChart.setRoundedCorners](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setRoundedCorners-boolean-)ด้วย`true`เพื่อทำให้มุมของพื้นที่แผนภูมิโค้งมน ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบกลุ่มและใช้[getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--)ให้ขอบเป็นสีเทาแบบทึบและสไตล์เส้นเดี่ยวก่อนบันทึกงานนำเสนอ

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    chart.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chart.getLineFormat().setStyle(LineStyle.Single);
    chart.setRoundedCorners(true);

    presentation.save("out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **แก้ไขคำอธิบายแผนภูมิที่มีอยู่**

แผนภูมิอาจมีรูปร่างที่กำหนดเอง เช่น คำอธิบายข้อความที่อธิบายสถานะของรายงาน เข้าถึงรูปร่างเหล่านี้ผ่าน[IChart.getUserShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getUserShapes--), ซึ่งยังปรากฏภายใต้[Chart.getUserShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#getUserShapes--)ในเอกสารอ้างอิง API ของ Chart คอลเลกชันที่คืนค่าจาก[getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--)ประกอบด้วยรูปร่างที่เป็นเจ้าของโดยแผนภูมิ

กล่องข้อความธรรมดาที่วางไว้บนแผนภูมิเป็นของสไลด์ แม้ว่าจะดูเหมือนเป็นส่วนหนึ่งของแผนภูมิก็ตาม การวนลูปผ่าน[Slide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--)จะพบแผนภูมิและรูปร่างสไลด์ทั่วไป แต่ไม่แสดงรูปร่างบุคคละแต่ละอันภายในแผนภูมิ ชื่อเรื่องแผนภูมิและป้ายข้อมูลเป็นส่วนแยกของแผนภูมิ ไม่ใช่คำอธิบายกำหนดเองในคอลเลกชันนี้

ดาวน์โหลด[chart-annotations.pptx](chart-annotations.pptx)และวางไว้ในไดเรกทอรีทำงานของแอปพลิเคชัน สไลด์แรกของไฟล์มีแผนภูมิพร้อมคำอธิบายที่ไม่ได้จัดกลุ่มอ่านว่า "Preliminary results", เส้นที่เป็นของแผนภูมิ, และกล่องข้อความสไลด์ธรรมดาที่อ่านว่า "Slide overlay". ตัวอย่างจะค้นหาแผนภูมิแรกบนสไลด์นั้นและเปลี่ยนคำอธิบายเป็น "Final results" เมื่อรายงานพร้อมตีพิมพ์ มันจะตรวจสอบคอลเลกชันที่ว่างเปล่าและแก้ไขเฉพาะ[IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)ที่มี Text Frame ไม่เป็น null ที่ได้จาก[getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#getTextFrame--)และมีข้อความตามที่คาดหวัง

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart-annotations.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IChart) {
            chart = (IChart) shape;
            break;
        }
    }

    if (chart == null || chart.getUserShapes().getShapes().size() == 0) {
        System.out.println("No chart or chart-owned shapes found.");
        return;
    }

    boolean updated = false;
    for (IShape shape : chart.getUserShapes().getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape annotation = (IAutoShape) shape;
            if (annotation.getTextFrame() != null && "Preliminary results".equals(annotation.getTextFrame().getText())) {
                annotation.getTextFrame().setText("Final results");
                updated = true;
                break;
            }
        }
    }

    if (updated) {
        presentation.save("chart-annotations-updated.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("No matching text annotation found.");
    }
} finally {
    presentation.dispose();
}
```

เส้นและกล่องข้อความสไลด์คงเดิม ภาพต่อไปนี้แสดงอินพุตและผลลัพธ์ที่บันทึกแล้วเปิดใหม่:

| ก่อนแก้ไข | หลังแก้ไข |
| --- | --- |
| ![Chart annotation reading Preliminary results](chart-annotations-before.png) | ![Chart annotation reading Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
ตัวอย่างตรวจสอบเฉพาะรูปร่างระดับบนที่เป็นของแผนภูมิ หากมีคำอธิบายอยู่ภายใน[IGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/), ให้ตรวจสอบคอลเลกชัน[getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) ของกลุ่มนั้นด้วย ทำซ้ำแบบเรียกซ้ำสำหรับกลุ่มที่ซ้อนกันโดยใช้การตรวจสอบข้อความเดียวกันกับรูปร่างลูกของพวกมัน กลุ่มเองเป็นคอนเทนเนอร์; อย่าปฏิบัติกลุ่มเป็นกล่องข้อความ
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ฉันสามารถตั้งค่าการเติมสีครึ่งโปร่งใสสำหรับคอลัมน์/พื้นที่ในขณะที่ยังคงให้ขอบทึบได้หรือไม่?**

ได้ การกำหนดความโปร่งใสของการเติมและขอบทำแยกกัน ซึ่งมีประโยชน์ในการทำให้กริดและข้อมูลในภาพที่แน่นอ่านง่ายขึ้น

**ฉันจะจัดการกับป้ายข้อมูลเมื่อมันทับซ้อนกันอย่างไร?**

ลดขนาดฟอนต์, ปิดการใช้งานส่วนประกอบของป้ายที่ไม่จำเป็น (เช่น ประเภท), ปรับตำแหน่งป้าย, แสดงป้ายเฉพาะจุดที่เลือกหากจำเป็น, หรือสลับรูปแบบเป็น "ค่า + คำอธิบาย"

**ฉันสามารถใช้การเติมสีไล่ระดับหรือแบบลายบนชุดข้อมูลได้หรือไม่?**

ได้ ชุดข้อมูลสนับสนุนการเติมสีแบบทึบ, ไล่ระดับ, และลาย ในการใช้งานจริง ควรใช้ไล่ระดับอย่างประหยัดและหลีกเลี่ยงการผสมผสานที่ทำให้ความคอนทราสต์กับกริดและข้อความลดลง