---
title: "จัดรูปแบบแผนภูมิการนำเสนอใน JavaScript"
linktitle: "การจัดรูปแบบแผนภูมิ"
type: docs
weight: 60
url: /th/nodejs-java/chart-formatting/
keywords:
- "จัดรูปแบบแผนภูมิ"
- "การจัดรูปแบบแผนภูมิ"
- "องค์ประกอบแผนภูมิ"
- "คุณสมบัติของแผนภูมิ"
- "การตั้งค่าแผนภูมิ"
- "ตัวเลือกแผนภูมิ"
- "คุณสมบัติตัวอักษร"
- "ขอบโค้ง"
- "PowerPoint"
- "การนำเสนอ"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "เรียนรู้การจัดรูปแบบแผนภูมิใน Aspose.Slides สำหรับ Node.js ผ่าน Java และยกระดับการนำเสนอ PowerPoint ของคุณด้วยแกนที่กำหนดเอง, แบบอักษร, รูปแบบตัวเลข, และขอบแผนภูมิที่โค้ง."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีจัดรูปแบบแผนภูมิในงานนำเสนอ PowerPoint ด้วยการใช้ Aspose.Slides ซึ่งแสดงวิธีปรับแต่งองค์ประกอบสำคัญของแผนภูมิเช่น แกน, เส้นกริด, ชื่อเรื่อง, คำอธิบาย, พื้นที่พล็อต, และการเติมสีของผนัง เพื่อปรับปรุงรูปลักษณ์และความอ่านง่ายของข้อมูลแผนภูมิ

บทความยังสาธิตวิธีตั้งค่าคุณสมบัติตัวอักษรสำหรับข้อความในแผนภูมิ, ใช้รูปแบบตัวเลขสำเร็จรูปกับข้อมูลแผนภูมิ, และเปิดใช้งานมุมโค้งสำหรับพื้นที่แผนภูมิ ตัวอย่างเหล่านี้แสดงวิธีควบคุมทั้งสไตล์การแสดงผลและการนำเสนอข้อมูลของแผนภูมิในงานนำเสนอ

สำหรับการเติมสีและขอบที่แยกต่างหากบนช่วงที่เพิ่มขึ้นและลดลง, ดูที่ [ตัวอย่างแผนภูมิสต็อก](/slides/th/nodejs-java/create-chart/#create-stock-charts)

## **จัดรูปแบบองค์ประกอบของแผนภูมิ**

ใช้ [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/) เพื่อจัดรูปแบบชื่อแผนภูมิ, แกน, เส้นกริด, คำอธิบาย, และพื้นที่พล็อต ตัวอย่างนี้สร้างแผนภูมิเส้นพร้อมมาร์คเกอร์และข้อมูลเริ่มต้น จากนั้นใช้สไตล์ข้อความและเส้นที่แยกกันสำหรับแกนค่าตัวและแกนประเภท ขนาดตัวอักษรและความกว้างของเส้นระบุเป็นจุด; ป้ายชื่อประเภทถูกหมุน 45 องศา

แกนค่าตัวใช้ [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/#setNumberFormat) อย่างอิสระจากเซลล์ต้นทาง ช่วงค่าของมันอยู่ระหว่าง -2 ถึง 15 โดยมีช่วงหลักที่ 2 และช่วงย่อยที่ 0.5 ตัวอย่างยังรวมการจัดรูปแบบเป็นเปอร์เซ็นต์กับ [setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/#setDisplayUnit) ที่ตั้งค่าเป็นพัน ดังนั้นจึงปรับการตั้งค่าเหล่านี้ให้สอดคล้องกับความหมายและขนาดของข้อมูลของคุณ คำอธิบายยังคงอยู่ด้านนอกพื้นที่พล็อตเพราะ [setOverlay](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/#setOverlay) ถูกเรียกด้วยค่า `false` การเติมสีผนังกับพื้นผิวพื้นกำหนดผ่าน [getBackWall](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getBackWall) และ [getFloor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getFloor) แต่พื้นผิวเหล่านี้จะมองเห็นได้เฉพาะในแผนภูมิ 3 มิติ

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 50, 50, 500, 400);

    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("");
    let chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    chartTitle.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));

    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.DashDot));

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);

    chart.getAxes().getVerticalAxis().setMaxValue(15);
    chart.getAxes().getVerticalAxis().setMinValue(-2);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0);

    let valueAxisText = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    valueAxisText.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    valueAxisText.setFontHeight(16);
    valueAxisText.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    valueAxisText.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    valueAxisText.getFillFormat().getSolidFillColor().setPresetColor(java.newByte(aspose.slides.PresetColor.DarkGreen));
    valueAxisText.setLatinFont(new aspose.slides.FontData("Times New Roman"));

    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    let valueAxisTitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valueAxisTitle.setText("Primary Axis");
    valueAxisTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    valueAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    valueAxisTitle.getPortionFormat().setFontHeight(20);
    valueAxisTitle.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    valueAxisTitle.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));

    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 128, 0));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    let categoryAxisText = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    categoryAxisText.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    categoryAxisText.setFontHeight(16);
    categoryAxisText.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    categoryAxisText.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    categoryAxisText.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    categoryAxisText.setLatinFont(new aspose.slides.FontData("Arial"));

    chart.getAxes().getHorizontalAxis().setTitle(true);
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    let categoryAxisTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    categoryAxisTitle.setText("Sample Category");
    categoryAxisTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    categoryAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    categoryAxisTitle.getPortionFormat().setFontHeight(20);
    categoryAxisTitle.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    categoryAxisTitle.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));

    chart.getAxes().getHorizontalAxis().setTickLabelPosition(aspose.slides.TickLabelPositionType.Low);
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    let legendText = chart.getLegend().getTextFormat().getPortionFormat();
    legendText.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    legendText.setFontHeight(16);
    legendText.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    legendText.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    legendText.getFillFormat().getSolidFillColor().setPresetColor(java.newByte(aspose.slides.PresetColor.DarkRed));

    chart.getLegend().setOverlay(false);

    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 165, 0));

    chart.getFloor().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    chart.getPlotArea().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(java.newByte(aspose.slides.PresetColor.LightCyan));

    presentation.save("FormattedChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าคุณสมบัติตัวอักษรสำหรับแผนภูมิ**

ตั้งค่าขนาดตัวอักษรเริ่มต้นสำหรับข้อความในแผนภูมิผ่าน [Chart.getTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getTextFormat) ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบกลุ่มพร้อมฟอนต์ขนาด 20 จุดและเปิดใช้งานการแสดงป้ายค่าของชุดข้อมูลแรกผ่าน [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/#setShowValue) องค์ประกอบข้อความที่มีการตั้งค่าฟอนต์โดยเฉพาะสามารถลบล้างค่าตั้งต้นของแผนภูมิได้

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("FontPropertiesForChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ใช้การจัดรูปแบบกรอบข้อความซ้ำสำหรับคำอธิบายแผนภูมิ**

เพื่อให้คำอธิบายสอดคล้องกับหัวข้อสไลด์ ให้ตั้งค่าฟอนต์ของหัวข้อผ่าน [getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) ในย่อหน้าที่หนึ่ง เรียก [copyFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttextformat/#copyFrom) บนรูปแบบที่ได้จาก [getTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/#getTextFormat) ของคำอธิบาย มันจะคัดลอกการตั้งค่ากรอบข้อความ การจัดรูปแบบของย่อหน้าแรกและคุณสมบัติฟอนต์เริ่มต้นของย่อคนั้น การจัดรูปแบบที่ใช้โดยตรงกับส่วนย่อยหรือย่อหน้าต่อมาจะคงอยู่เฉพาะแหล่งที่มา

ตัวอย่างใช้หัวข้อ Calibri หนา 26 จุดสีกรมท่เป็นแม่แบบ หลังจากจัดรูปแบบคำอธิบายแล้ว จะเรียก [copyTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttextformat/#copyTo) เพื่อใช้การจัดรูปแบบเดียวกันกับคำอธิบายแยก

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const heading = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 20, 640, 40, false);
    const sourceTextFrame = heading.addTextFrame("Quarterly sales");
    const font = sourceTextFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    font.setLatinFont(new aspose.slides.FontData("Calibri"));
    font.setFontHeight(26);
    font.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    font.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    font.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 32, 64, 96));

    const chart = shapes.addChart(aspose.slides.ChartType.ClusteredColumn, 40, 75, 640, 360);
    chart.setStyle(java.newByte(aspose.slides.StyleType.Style3));
    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.getCell(0, 0, 1).setValue("Retail");
    workbook.getCell(0, 0, 2).setValue("Online");
    workbook.getCell(0, 0, 3).setValue("Wholesale");
    for (let quarter = 1; quarter <= 4; quarter++) {
        workbook.getCell(0, quarter, 0).setValue("Q" + quarter);
    }

    chart.setLegend(true);
    chart.getLegend().setPosition(java.newByte(aspose.slides.LegendPositionType.Bottom));
    const legendFormat = chart.getLegend().getTextFormat();
    legendFormat.copyFrom(sourceTextFrame);

    const caption = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 460, 640, 40, false);
    const captionTextFrame = caption.addTextFrame("Sales in millions of dollars");
    legendFormat.copyTo(captionTextFrame);

    presentation.save("legend-formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ในงานนำเสนอที่บันทึกแล้ว คำอธิบายและคำอธิบายย่อยจะตรงกับหัวข้อในเรื่องของขนาด น้ำหนัก และสี คำอธิบายยังคงแสดงชื่อชุดข้อมูล และคำอธิบายย่อยคงข้อความของตัวเอง หากส่วนหนึ่งในคำอธิบายย่อยมีขนาดฟอนต์ที่กำหนดไว้แล้ว ขนาดนั้นจะมีลำดับความสำคัญเหนือค่าตั้งต้นของย่อหน้าที่คัดลอก

| ก่อนคัดลอก | หลังคัดลอก |
| --- | --- |
| ![แผนภูมิการขายรายไตรมาสพร้อมป้ายคำอธิบายสีดำแบบปกติและคำอธิบายสีดำ](legend-formatting-before.png) | ![แผนภูมิเดียวกันที่มีป้ายอธิบายสีกรมท่าใหญ่ขึ้นหนาและคำอธิบายที่สอดคล้องกัน](legend-formatting.png) |

## **ตั้งค่ารูปแบบตัวเลข**

ใช้ [ChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/#setPresetNumberFormat) เพื่อใช้รูปแบบตัวเลขที่มีอยู่แล้วกับเซลล์ในเวิร์กบุ๊กของแผนภูมิ ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบกลุ่มโดยใช้ข้อมูลเริ่มต้นที่มาจากเซลล์ และใช้รูปแบบดัชนี 10 (`0.00%`) กับเซลล์ค่าของแต่ละชุดข้อมูล การทำเช่นนี้จะเปลี่ยนการแสดงค่าภายในเวิร์กบุ๊กโดยไม่เปลี่ยนตัวเลขพื้นฐาน; ตัวอย่างเช่น 0.25 จะถูกแสดงเป็น 25.00% รูปแบบแกนและป้ายข้อมูลสามารถกำหนดแยกกันได้

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 400);
    let series = chart.getChartData().getSeries();

    for (let i = 0; i < series.size(); i++) {
        let chartSeries = series.get_Item(i);
        for (let j = 0; j < chartSeries.getDataPoints().size(); j++) {
            let dataPoint = chartSeries.getDataPoints().get_Item(j);
            dataPoint.getValue().getAsCell().setPresetNumberFormat(java.newByte(10)); // 0.00%
        }
    }

    presentation.save("PresetNumberFormat_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ตารางต่อไปนี้แสดงดัชนีรูปแบบตัวเลขที่มีอยู่พร้อมรูปแบบ Excel ที่เป็นตัวอย่างสำหรับโลแคล English (United States) รูปแบบสตริงที่แน่นอนและการแสดงผลอาจแตกต่างกันตามแอปพลิเคชันและโลแคล โดยเฉพาะสำหรับสกุลเงินและวันที่ บางรูปแบบ Excel ยังแตกต่างจากค่าเริ่มต้นในมาตรฐาน OOXML ตามที่อธิบายใน [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528)

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

เรียก [Chart.setRoundedCorners](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#setRoundedCorners) ด้วยค่า `true` เพื่อทำให้มุมของพื้นที่แผนภูมิเป็นโค้ง ตัวอย่างสร้างแผนภูมิคอลัมน์แบบกลุ่มและใช้ [getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) เพื่อให้เส้นขอบเป็นสีเทาแข็งและสไตล์เส้นเดี่ยวก่อนบันทึกงานนำเสนอ

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    chart.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.Single));
    chart.setRoundedCorners(true);

    presentation.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **แก้ไขหมายเหตุแผนภูมิที่มีอยู่**

แผนภูมิอาจมีรูปร่างที่กำหนดเอง เช่น หมายเหตุข้อความอธิบายสถานะของรายงาน เข้าถึงรูปร่างเหล่านี้ผ่าน [Chart.getUserShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getUserShapes) คอลเลกชันที่คืนค่าจาก [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) มีรูปร่างที่เป็นของแผนภูมิ

กล่องข้อความธรรมดาที่วางเหนือแผนภูมิเกี่ยวข้องกับสไลด์ แม้จะดูเหมือนเป็นส่วนของแผนภูมิ การวนซ้ำผ่าน [Slide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes) จะพบแผนภูมิและรูปร่างสไลด์ทั่วไป แต่จะไม่แสดงรายการรูปร่างแยกภายในแผนภูมิ ชื่อแผนภูมิและป้ายข้อมูลเป็นองค์ประกอบแผนภูมิแยกจากกัน ไม่ได้เป็นหมายเหตุที่กำหนดเองในคอลเลกชันนี้

ดาวน์โหลด [chart-annotations.pptx](chart-annotations.pptx) และวางไว้ในไดเรกทอรีทำงานของแอปพลิเคชัน สไลด์แรกมีแผนภูมิพร้อมหมายเหตุที่ไม่ได้จัดกลุ่มข้อความ "Preliminary results", เส้นที่เป็นของแผนภูมิ, และกล่องข้อความสไลด์ธรรมดาข้อความ "Slide overlay" ตัวอย่างค้นหาแผนภูมิแรกบนสไลด์นั้นและเปลี่ยนหมายเหตุเป็น "Final results" เมื่อรายงานพร้อมเผยแพร่ จะตรวจสอบว่าคอลเลกชันว่างหรือไม่และแก้ไขเฉพาะ [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) ที่มีกรอบข้อความไม่เป็นค่าว่างซึ่งคืนค่าจาก [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#getTextFrame) และมีข้อความที่คาดหวัง

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation("chart-annotations.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    let chart = null;
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
            chart = shape;
            break;
        }
    }

    if (chart == null || chart.getUserShapes().getShapes().size() == 0) {
        console.log("No chart or chart-owned shapes found.");
    } else {
        let updated = false;
        for (let i = 0; i < chart.getUserShapes().getShapes().size(); i++) {
            let shape = chart.getUserShapes().getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                let annotation = shape;
                if (annotation.getTextFrame() != null && annotation.getTextFrame().getText() === "Preliminary results") {
                    annotation.getTextFrame().setText("Final results");
                    updated = true;
                    break;
                }
            }
        }

        if (updated) {
            presentation.save("chart-annotations-updated.pptx", aspose.slides.SaveFormat.Pptx);
        } else {
            console.log("No matching text annotation found.");
        }
    }
} finally {
    presentation.dispose();
}
```

เส้นและกล่องข้อความสไลด์จะคงเดิม รูปภาพต่อไปนี้แสดงผลลัพธ์ก่อนและหลังการบันทึกและเปิดใหม่:

| ก่อนแก้ไข | หลังแก้ไข |
| --- | --- |
| ![หมายเหตุแผนภูมิแสดงผลลัพธ์เบื้องต้น](chart-annotations-before.png) | ![หมายเหตุแผนภูมิแสดงผลลัพธ์สุดท้าย](chart-annotations-after.png) |

{{% alert color="info" title="หมายเหตุ" %}}
ตัวอย่างตรวจสอบเฉพาะรูปร่างที่เป็นของแผนภูมิระดับบนสุด หากหมายเหตุอยู่ภายใน [GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/), ให้ตรวจสอบคอลเลกชัน [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) ของกลุ่มนั้นด้วย การทำซ้ำแบบเรียกซ้อนไปยังกลุ่มย่อยที่ซ้อนกันโดยใช้การตรวจสอบข้อความเดียวกันกับรูปร่างลูกของพวกมัน กลุ่มเองเป็นคอนเทนเนอร์; อย่าถือว่าเป็นกล่องข้อความ
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ฉันสามารถตั้งค่าการเติมสีกึ่งโปร่งใสสำหรับคอลัมน์/พื้นที่ในขณะที่คงเส้นขอบให้ทึบได้หรือไม่?**  
ใช่ การโปร่งแสงของการเติมสีและเส้นขอบถูกกำหนดค่าแยกกัน สิ่งนี้เป็นประโยชน์สำหรับการปรับปรุงความอ่านง่ายของกริดและข้อมูลในภาพที่แออัด

**จะจัดการกับป้ายข้อมูลเมื่อมันทับซ้อนกันอย่างไร?**  
ลดขนาดฟอนต์, ปิดส่วนประกอบป้ายที่ไม่สำคัญ (เช่น หมวดหมู่), ปรับตำแหน่งป้าย, แสดงป้ายเฉพาะจุดที่เลือกหากจำเป็น, หรือสลับรูปแบบเป็น "ค่า + คำอธิบาย"

**ฉันสามารถใช้การเติมสีแบบไล่ระดับสีหรือรูปแบบให้กับชุดข้อมูลได้หรือไม่?**  
ได้ ชุดข้อมูลรองรับการเติมสีแบบทึบ, ไล่ระดับสี, และรูปแบบ ในการปฏิบัติใช้ไล่ระดับสีอย่างประหยัดและหลีกเลี่ยงการผสมที่ลดความคอนทราสต์กับกริดและข้อความ