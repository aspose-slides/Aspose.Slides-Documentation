---
title: จัดรูปแบบแผนภูมิการนำเสนอใน Java
linktitle: การจัดรูปแบบแผนภูมิ
type: docs
weight: 60
url: /th/java/chart-formatting/
keywords:
- จัดรูปแบบแผนภูมิ
- การจัดรูปแบบแผนภูมิ
- องค์ประกอบแผนภูมิ
- คุณสมบัติแผนภูมิ
- การตั้งค่าแผนภูมิ
- ตัวเลือกแผนภูมิ
- คุณสมบัติฟอนต์
- ขอบโค้งมน
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้การจัดรูปแบบแผนภูมิใน Aspose.Slides สำหรับ Java และยกระดับการนำเสนอ PowerPoint ของคุณด้วยแกนที่กำหนดเอง, ฟอนต์, รูปแบบตัวเลข, และขอบแผนภูมิที่โค้งมน."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีจัดรูปแบบแผนภูมิในงานนำเสนอ PowerPoint โดยใช้ Aspose.Slides โดยแสดงวิธีปรับแต่งองค์ประกอบสำคัญของแผนภูมิ เช่น แกน, เส้นกริด, ชื่อเรื่อง, คำอธิบาย, พื้นที่พล็อต, และการเติมผนัง เพื่อปรับปรุงรูปลักษณ์และความสามารถในการอ่านข้อมูลของแผนภูมิ

มันยังสาธิตวิธีตั้งค่าคุณสมบัติฟอนต์สำหรับข้อความในแผนภูมิ, ใช้รูปแบบตัวเลขที่กำหนดไว้ล่วงหน้าสำหรับข้อมูลแผนภูมิ, และเปิดใช้งานมุมโค้งมนสำหรับพื้นที่แผนภูมิ ตัวอย่างเหล่านี้แสดงวิธีควบคุมทั้งสไตล์ภาพและการนำเสนอข้อมูลของแผนภูมิในงานนำเสนอ

สำหรับการเติมและกรอบที่แยกกันในช่วงที่เพิ่มและลดลง, ดูที่ [ตัวอย่างแผนภูมิหุ้น](/slides/th/java/create-chart/#create-stock-charts).

## **จัดรูปแบบรายการแผนภูมิ**

ใช้ [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/) เพื่อจัดรูปแบบชื่อเรื่องของแผนภูมิ, แกน, เส้นกริด, คำอธิบาย, และพื้นที่พล็อต ตัวอย่างนี้สร้างแผนภูมิเส้นพร้อมเครื่องหมายและข้อมูลเริ่มต้น, จากนั้นใช้สไตล์ข้อความและเส้นที่แยกต่างหากสำหรับแกนค่และแกนประเภท ขนาดฟอนต์และความกว้างของเส้นระบุเป็นหน่วยจุด; ป้ายชื่อประเภทถูกหมุน 45 องศา

แกนค่าจะใช้ [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) อย่างอิสระจากเซลล์ต้นทาง ช่วงของมันเริ่มจาก -2 ถึง 15, โดยมีช่วงหลักที่ 2 และช่วงรองที่ 0.5 ตัวอย่างนี้ยังรวมการจัดรูปแบบเปอร์เซ็นต์กับ [setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setDisplayUnit-int-) ที่ตั้งเป็นพัน, ดังนั้นให้ปรับการตั้งค่าเหล่านี้ให้สอดคล้องกับความหมายและขนาดของข้อมูลของคุณ คำอธิบายยังคงอยู่ด้านนอกพื้นที่พล็อตเนื่องจาก [setOverlay](https://reference.aspose.com/slides/java/com.aspose.slides/ilegend/#setOverlay-boolean-) ถูกเรียกด้วย `false` การเติมผนังด้านหลังและพื้นกำหนดผ่าน [getBackWall](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getBackWall--) และ [getFloor](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getFloor--), แต่พื้นผิวนเหล่านี้จะมองเห็นได้เฉพาะในแผนภูมิ 3 มิติ

```java
import com.aspose.slides.*;
import java.awt.Color;

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
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(new Color(0, 128, 0));
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
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(new Color(255, 165, 0));

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

ตั้งค่าขนาดฟอนต์เริ่มต้นสำหรับข้อความในแผนภูมิผ่าน [Chart.getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#getTextFormat--). ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบกลุ่มโดยใช้ฟอนต์ขนาด 20 จุดและเปิดใช้งานป้ายค่าสำหรับชุดข้อมูลแรกผ่าน [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-). ธาตุข้อความที่มีการตั้งค่าฟอนต์อย่างชัดเจนของตนเองสามารถแทนที่ค่าเริ่มต้นของแผนภูมิได้

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

## **ใช้การจัดรูปแบบกรอบข้อความซ้ำสำหรับคำอธิบายแผนภูมิ**

เพื่อให้คำอธิบายตรงกับหัวข้อสไลด์, ตั้งค่า ฟอนต์ของหัวข้อผ่าน [getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) ในย่อหน้าที่แรก เรียก [copyFrom](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextformat/#copyFrom-com.aspose.slides.ITextFrame-) บนรูปแบบที่คืนจาก [getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iformattedtextcontainer/#getTextFormat--) ของคำอธิบาย มันจะคัดลอกการตั้งค่ากรอบข้อความ, การจัดรูปแบบของย่อหน้าแรก, และคุณสมบัติฟอนต์เริ่มต้นของย่อหนนั้น การจัดรูปแบบที่ใช้โดยตรงกับส่วนย่อยหรือย่อหน้าถัดไปจะคงอยู่เฉพาะในแหล่งที่มานั้น

ตัวอย่างนี้ใช้หัวข้อ Calibri ขนาด 26 จุดสีกรมท่าแบบหนาเป็นแม่แบบ หลังจากจัดสไตล์คำอธิบาย, มันเรียก [copyTo](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextformat/#copyTo-com.aspose.slides.ITextFrame-) เพื่อใช้การจัดรูปแบบเดียวกันกับคำบรรยายแยก

```java
import com.aspose.slides.*;
import java.awt.Color;

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
    font.getFillFormat().getSolidFillColor().setColor(new Color(32, 64, 96));

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

ในการนำเสนอที่บันทึกไว้, คำอธิบายและคำบรรยายตรงกับหัวข้อในเรื่องขนาด, ความหนา, และสี คำอธิบายยังคงแสดงชื่อชุดข้อมูล, และคำบรรยายเก็บข้อความของตนเอง หากส่วนในคำบรรยายมีขนาดฟอนต์ที่ระบุไว้แล้ว, ขนาดนั้นจะมีลำดับความสำคัญเหนือค่าดีฟอลต์ของย่อหน้าที่คัดลอก

| ก่อนคัดลอก | หลังคัดลอก |
| --- | --- |
| ![แผนภูมิขายไตรมาสพร้อมป้ายคำอธิบายสีดำแบบทั่วไปและคำบรรยายสีดำ](legend-formatting-before.png) | ![แผนภูมิเดียวกันพร้อมป้ายคำอธิบายสีกรมท่าใหญ่ขึ้น, หนา, และคำบรรยายที่ตรงกัน](legend-formatting.png) |

## **ตั้งค่ารูปแบบตัวเลข**

ใช้ [IChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setPresetNumberFormat-byte-) เพื่อใช้รูปแบบตัวเลขที่มีมาในตัวกับเซลล์ workbook ของแผนภูมิ ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบกลุ่มด้วยข้อมูลเริ่มต้นที่อ้างอิงจากเซลล์และใช้ดัชนีรูปแบบ 10 (`0.00%`) กับแต่ละเซลล์ค่าของชุดข้อมูล ซึ่งจะเปลี่ยนวิธีการแสดงค่าต่าง ๆ ใน workbook โดยไม่เปลี่ยนตัวเลขพื้นฐาน; ตัวอย่างเช่น 0.25 จะถูกแสดงเป็น 25.00% รูปแบบของแกนและป้ายข้อมูลสามารถกำหนดแยกกันได้

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

ตารางต่อไปนี้แสดงดัชนีรูปแบบตัวเลขที่มีมาในตัวพร้อมรูปแบบ Excel ตัวแทนสำหรับภาษาอังกฤษ (สหรัฐอเมริกา) สตริงรูปแบบที่แน่นอนและการแสดงผลอาจแตกต่างกันตามแอปพลิเคชันและภาษาท้องถิ่น, โดยเฉพาะอย่างยิ่งสำหรับสกุลเงินและวันที่ บางรูปแบบของ Excel ยังแตกต่างจากค่าปริยายในมาตรฐาน OOXML, ดังที่อธิบายใน [บันทึกหมายเหตุการใช้งานรูปแบบตัวเลขของ Microsoft](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528)

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

เรียก [IChart.setRoundedCorners](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setRoundedCorners-boolean-) ด้วยค่า `true` เพื่อทำให้มุมของพื้นที่แผนภูมิเป็นมุมโค้ง ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบกลุ่มและใช้ [getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) เพื่อให้เส้นกรอบเป็นสีเทาเข้มแบบทึบและสไตล์เส้นเดี่ยวก่อนบันทึกการนำเสนอ

```java
import com.aspose.slides.*;
import java.awt.Color;

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

แผนภูมิสามารถมีรูปร่างกำหนดเอง, เช่น คำอธิบายข้อความที่อธิบายสถานะของรายงาน เข้าถึงรูปร่างเหล่านี้ผ่าน [IChart.getUserShapes](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getUserShapes--), ที่ปรากฏใน [Chart.getUserShapes](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#getUserShapes--) ในอ้างอิง API ของแผนภูมิ คอลเลกชันที่คืนจาก [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) มีรูปร่างที่เป็นของแผนภูมิ

กล่องข้อความธรรมดาที่วางเหนือแผนภูมิจัดเป็นของสไลด์, แม้ว่าจะดูเหมือนเป็นส่วนหนึ่งของแผนภูมิ การวนลูปผ่าน [Slide.getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getShapes--) จะพบแผนภูมิและรูปแบบสไลด์ธรรมดา, แต่จะไม่แสดงรูปร่างแต่ละอันภายในแผนภูมิ ชื่อหัวข้อแผนภูมิและป้ายข้อมูลเป็นองค์ประกอบแผนภูมิแยกต่างหาก, ไม่ใช่คำอธิบายกำหนดเองในคอลเลกชันนี้

ดาวน์โหลด [chart-annotations.pptx](chart-annotations.pptx) และวางไว้ในไดเรกทอรีทำงานของแอปพลิเคชัน สไลด์แรกของไฟล์ประกอบด้วยแผนภูมิที่มีคำอธิบายที่ไม่ได้จัดกลุ่มแสดงข้อความ "Preliminary results", เส้นที่เป็นของแผนภูมิ, และกล่องข้อความสไลด์ธรรมดาแสดงข้อความ "Slide overlay" ตัวอย่างค้นหาแผนภูมิเชิงแรกบนสไลด์นั้นและเปลี่ยนคำอธิบายเป็น "Final results" เมื่อรายงานพร้อมเผยแพร่ มันตรวจสอบคอลเลกชันว่าเป็นค่าว่างหรือไม่และแก้ไขเฉพาะ [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) ที่มีกรอบข้อความไม่เป็น null ที่คืนจาก [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#getTextFrame--) และข้อความที่คาดไว้

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

เส้นและกล่องข้อความสไลด์ยังคงไม่เปลี่ยนแปลง ภาพต่อไปนี้แสดงผลอินพุตและผลลัพธ์ที่บันทึกแล้ว, เปิดใหม่อีกครั้ง:

| ก่อนแก้ไข | หลังแก้ไข |
| --- | --- |
| ![คำอธิบายแผนภูมิที่อ่านว่า Preliminary results](chart-annotations-before.png) | ![คำอธิบายแผนภูมิที่อ่านว่า Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
ตัวอย่างตรวจสอบเฉพาะรูปร่างระดับบนสุดที่เป็นของแผนภูมิ หากคำอธิบายอยู่ภายใน [IGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/), ให้ตรวจสอบคอลเลกชัน [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) ของกลุ่มนั้นด้วย การทำซ้ำแบบเรียกตัวเองสำหรับกลุ่มที่ซ้อนกัน, ใช้การตรวจสอบข้อความเดียวกันกับรูปร่างลูกของพวกมัน กลุ่มเองเป็นคอนเทนเนอร์; อย่าปฏิบัติเช่นเป็นกล่องข้อความ
{{% /alert %}}

## **FAQ**

**ฉันสามารถตั้งค่าการเติมกึ่งโปร่งแสงสำหรับคอลัมน์/พื้นที่ได้ขณะยังคงให้ขอบเป็นทึบหรือไม่?**

ใช่. ความโปร่งแสงของการเติมและเส้นขอบถูกกำหนดแยกกัน สิ่งนี้มีประโยชน์สำหรับการปรับปรุงความอ่านง่ายของกริดและข้อมูลในภาพที่แออัด

**ฉันจะจัดการกับป้ายข้อมูลเมื่อมันทับซ้อนกันได้อย่างไร?**

ลดขนาดฟอนต์, ปิดใช้งานส่วนประกอบป้ายที่ไม่จำเป็น (เช่น หมวดหมู่), ปรับตำแหน่งป้าย, แสดงป้ายเฉพาะจุดที่เลือกหากจำเป็น, หรือเปลี่ยนรูปแบบเป็น “value + legend”

**ฉันสามารถใช้การเติมแบบไล่สีหรือแบบลวดลายให้กับชุดข้อมูลได้หรือไม่?**

ใช่. ชุดข้อมูลรองรับการเติมแบบทึบ, ไล่สี, และลวดลาย ในการใช้งานจริงควรใช้ไล่สีอย่างระมัดระวังและหลีกเลี่ยงการผสมที่ทำให้ความคมชัดกับกริดและข้อความลดลง