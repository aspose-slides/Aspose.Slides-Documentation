---
title: จัดรูปแบบแผนภูมิการนำเสนอใน Java
linktitle: การจัดรูปแบบแผนภูมิ
type: docs
weight: 60
url: /th/java/chart-formatting/
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
- Java
- Aspose.Slides
description: "เรียนรู้การจัดรูปแบบแผนภูมิใน Aspose.Slides สำหรับ Java และยกระดับการนำเสนอ PowerPoint ของคุณด้วยแกนที่กำหนดเอง, ฟอนต์, รูปแบบตัวเลข, และขอบแผนภูมิโค้ง."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการจัดรูปแบบแผนภูมิในงานนำเสนอ PowerPoint ด้วยการใช้ Aspose.Slides แสดงวิธีการปรับแต่งองค์ประกอบหลักของแผนภูมิ เช่น แกน, เส้นกริด, ชื่อเรื่อง, คำอธิบาย, พื้นที่พล็อต, และการเติมกำแพง เพื่อปรับปรุงลักษณะและความอ่านง่ายของข้อมูลแผนภูมิ

มันยังแสดงวิธีการตั้งค่าคุณสมบัติของตัวอักษรสำหรับข้อความในแผนภูมิ, ใช้รูปแบบตัวเลขที่กำหนดล่วงหน้าในข้อมูลแผนภูมิ, และเปิดใช้งานมุมโค้งสำหรับพื้นที่แผนภูมิ ตัวอย่างเหล่านี้ร่วมกันแสดงวิธีการควบคุมทั้งสไตล์การแสดงผลและการนำเสนอข้อมูลของแผนภูมิในงานนำเสนอ

## **จัดรูปแบบเอนทิตี้ของแผนภูมิ**

ใช้ [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/) เพื่อจัดรูปแบบชื่อเรื่องของแผนภูมิ, แกน, เส้นกริด, คำอธิบาย, และพื้นที่พล็อต ตัวอย่างนี้สร้างแผนภูมิเส้นพร้อมเครื่องหมายและข้อมูลค่าเริ่มต้น จากนั้นใช้สไตล์ข้อความและเส้นที่แยกกันสำหรับแกนค่าและแกนประเภท ขนาดตัวอักษรและความกว้างของเส้นระบุเป็นหน่วยจุด; ป้ายชื่อประเภทถูกหมุนที่ 45 องศา

แกนค่าใช้ [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) อย่างอิสระจากเซลล์ต้นทาง มาตราส่วนของแกนไล่ตั้งแต่ -2 ถึง 15, โดยมีช่วงหลักที่ 2 และช่วงย่อยที่ 0.5 ตัวอย่างนี้ยังรวมการจัดรูปแบบเป็นเปอร์เซ็นต์กับ [setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setDisplayUnit-int-) ที่ตั้งค่าเป็นพัน ดังนั้นให้ปรับการตั้งค่าเหล่านี้ให้สอดคล้องกับความหมายและขนาดของข้อมูลของคุณ คำอธิบายจะอยู่ด้านนอกพื้นที่พล็อตเนื่องจาก [setOverlay](https://reference.aspose.com/slides/java/com.aspose.slides/ilegend/#setOverlay-boolean-) ถูกเรียกด้วยค่า `false` การเติมกำแพงหลังและพื้นถูกกำหนดผ่าน [getBackWall](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getBackWall--) และ [getFloor](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getFloor--) แต่พื้นผิวเหล่านี้จะแสดงเฉพาะในแผนภูมิ 3 มิติ

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

## **ตั้งค่าคุณสมบัติตัวอักษรสำหรับแผนภูมิ**

ตั้งค่าขนาดตัวอักษรเริ่มต้นสำหรับข้อความในแผนภูมิผ่าน [Chart.getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#getTextFormat--). ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบกลุ่มโดยใช้ฟอนต์ขนาด 20 จุดและเปิดใช้งานป้ายค่าของชุดข้อมูลแรกผ่าน [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-). องค์ประกอบข้อความที่มีการตั้งค่าฟอนต์เฉพาะของตนสามารถทับค่าตั้งต้นของแผนภูมิได้

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

## **ตั้งค่ารูปแบบตัวเลข**

ใช้ [IChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setPresetNumberFormat-byte-) เพื่อใช้รูปแบบตัวเลขในตัวที่สร้างไว้ล่วงหน้ากับเซลล์เวิร์กบุ๊กของแผนภูมิ ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบกลุ่มด้วยข้อมูลค่าเริ่มต้นที่รองรับจากเซลล์และกำหนดรูปแบบดัชนี 10 (`0.00%`) ให้กับเซลล์ค่าของแต่ละชุดข้อมูล สิ่งนี้เปลี่ยนวิธีการแสดงค่าในเวิร์กบุ๊กโดยไม่เปลี่ยนตัวเลขพื้นฐาน; ตัวอย่างเช่น 0.25 จะแสดงเป็น 25.00% รูปแบบของแกนและป้ายข้อมูลสามารถกำหนดค่าแยกกันได้

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

ตารางต่อไปนี้แสดงดัชนีรูปแบบตัวเลขที่สร้างไว้ล่วงหน้าพร้อมรูปแบบ Excel ตัวแทนสำหรับภาษีอังกฤษ (สหรัฐอเมริกา) สตริงรูปแบบที่แน่นอนและการแสดงผลอาจแตกต่างกันไปตามแอปพลิเคชันและภาษี, โดยเฉพาะสำหรับสกุลเงินและวันที่ รูปแบบ Excel บางอย่างยังแตกต่างจากค่าเริ่มต้นในมาตรฐาน OOXML ตามที่อธิบายใน [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

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

เรียกใช้ [IChart.setRoundedCorners](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setRoundedCorners-boolean-) ด้วยค่า `true` เพื่อทำมุมของพื้นที่แผนภูมิให้โค้ง ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบกลุ่มและใช้ [getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) เพื่อกำหนดเส้นขอบให้เป็นสีเทาเรียบและสไตล์เส้นเดียว ก่อนบันทึกงานนำเสนอ

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

## **แก้ไขหมายเหตุแผนภูมิที่มีอยู่**

แผนภูมิสามารถมีรูปทรงแบบกำหนดเองได้ เช่น หมายเหตุข้อความอธิบายสถานะของรายงาน เข้าถึงรูปทรงเหล่านี้ผ่าน [IChart.getUserShapes](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getUserShapes--), ซึ่งยังปรากฏใน [Chart.getUserShapes](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#getUserShapes--) ในอ้างอิง API ของแผนภูมิ คอลเลกชันที่ส่งคืนโดย [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) มีรูปทรงที่เป็นของแผนภูมิ

กล่องข้อความธรรมดาที่วางบนแผนภูมิเป็นของสไลด์แม้ว่าจะดูเหมือนเป็นส่วนหนึ่งของแผนภูมิ การวนลูปผ่าน [Slide.getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getShapes--) จะพบแผนภูมิและรูปทรงสไลด์ธรรมดา แต่จะไม่แยกรูปทรงแต่ละอันภายในแผนภูมิ ชื่อเรื่องของแผนภูมิและป้ายข้อมูลเป็นองค์ประกอบแผนภูมิแยกต่างหาก ไม่ใช่หมายเหตุกำหนดเองในคอลเลกชันนี้

ดาวน์โหลด [chart-annotations.pptx](chart-annotations.pptx) และวางไว้ในไดเรกทอรีทำงานของแอปพลิเคชัน สไลด์แรกมีแผนภูมิพร้อมหมายเหตุที่ไม่มีการจัดกลุ่มที่เขียนว่า "Preliminary results", เส้นที่เป็นของแผนภูมิ, และกล่องข้อความสไลด์ธรรมดาที่เขียนว่า "Slide overlay" ตัวอย่างจะค้นหาแผนภูมิแรกบนสไลด์นั้นและเปลี่ยนหมายเหตุเป็น "Final results" เมื่อรายงานพร้อมเผยแพร่ จะตรวจสอบว่าคอลเลกชันว่างหรือไม่และแก้ไขเฉพาะ [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) ที่มีเฟรมข้อความที่ไม่เป็นค่าว่างซึ่งส่งกลับโดย [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#getTextFrame--) และข้อความที่คาดหวัง

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

เส้นและกล่องข้อความสไลด์จะคงเดิม ภาพต่อไปนี้แสดงอินพุตและผลลัพธ์ที่บันทึกแล้วเปิดใหม่:

| ก่อนแก้ไข | หลังแก้ไข |
| --- | --- |
| ![Chart annotation reading Preliminary results](chart-annotations-before.png) | ![Chart annotation reading Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
ตัวอย่างตรวจสอบเฉพาะรูปทรงระดับบนสุดของแผนภูมิ หากมีหมายเหตุอยู่ภายใน [IGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/), ให้ตรวจสอบคอลเลกชัน [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) ของกลุ่มนั้นด้วย ทำซ้ำแบบเรียกซ้ำสำหรับกลุ่มซ้อนกันโดยใช้การตรวจสอบข้อความเดียวกันกับรูปทรงลูกของพวกมัน กลุ่มเองเป็นคอนเทนเนอร์; อย่าปฏิบัติโดยให้เป็นกล่องข้อความ
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ฉันสามารถตั้งค่าการเติมกึ่งโปร่งใสสำหรับคอลัมน์/พื้นที่ในขณะที่ขอบยังคงทึบได้หรือไม่?**

ได้. ความโปร่งใสของการเติมและเส้นขอบถูกกำหนดค่าแยกกัน ซึ่งเป็นประโยชน์สำหรับการปรับปรุงความอ่านง่ายของกริดและข้อมูลในภาพที่แน่นหนา

**ฉันจะจัดการกับป้ายข้อมูลเมื่อตรงกันได้อย่างไร?**

ลดขนาดตัวอักษร, ปิดใช้งานส่วนประกอบของป้ายที่ไม่จำเป็น (เช่น ประเภท), ปรับตำแหน่งป้าย, แสดงป้ายเฉพาะสำหรับจุดที่เลือกหากจำเป็น, หรือเปลี่ยนรูปแบบเป็น "ค่า + คำอธิบาย"

**ฉันสามารถใช้การเติมแบบไล่สีหรือแบบลวดลายกับชุดข้อมูลได้หรือไม่?**

ได้. ชุดข้อมูลรองรับการเติมแบบทึบ, ไล่สี, และลวดลาย ในการปฏิบัติ ควรใช้ไล่สีอย่างจำกัดและหลีกเลี่ยงการผสมผสานที่ทำให้ความคอนทราสต์กับกริดและข้อความลดลง