---
title: ปรับแต่งแกนแผนภูมิในงานนำเสนอด้วย JavaScript
linktitle: แกนแผนภูมิ
type: docs
url: /th/nodejs-java/chart-axis/
keywords:
- แกนแผนภูมิ
- แกนแนวตั้ง
- แกนแนวนอน
- ปรับแต่งแกน
- จัดการแกน
- ดูแลแกน
- คุณสมบัติของแกน
- ค่าสูงสุด
- ค่าต่ำสุด
- เส้นแกน
- รูปแบบวันที่
- หัวข้อแกน
- ตำแหน่งแกน
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ค้นพบวิธีใช้ JavaScript กับ Aspose.Slides สำหรับ Node.js ผ่าน Java เพื่อปรับแต่งแกนแผนภูมิในงานนำเสนอ PowerPoint สำหรับรายงานและการสร้างภาพ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการปรับแต่งแกนของแผนภูมิด้วย Aspose.Slides for Node.js ผ่าน Java โดยครอบคลุมค่าที่คำนวณของแกน การสลับแถวและคอลัมน์ของแผนภูมิ การมองเห็นของแกน ช่วงเวลาของป้ายชื่อประเภทและเครื่องหมายติ๊ก การจัดรูปแบบหมวดวันที่ การหมุนหัวข้อ การวางตำแหน่งแกน หน่วยการแสดงผล และการสเกลแบบลอการิทึม

## **รับค่าสูงสุดบนแกนแนวตั้งของแผนภูมิ**

สร้าง [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) และเพิ่มแผนภูมิพื้นที่ด้วยข้อมูลเริ่มต้น เรียกใช้ [validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) ก่อนอ่านค่าที่คำนวณของแกนเพื่อให้การจัดวางแผนภูมิมีอัพเดตล่าสุด

อ่าน [getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmaxvalue/) และ [getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminvalue/) เพื่อขอบเขตของแกน และ [getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunit/) และ [getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunit/) เพื่อช่วงของเครื่องหมายติ๊ก [getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunitscale/) และ [getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunitscale/) ให้สเกลหน่วยเวลา ซึ่งเกี่ยวข้องกับแกนวันที่ ตัวอย่างจะเก็บค่าต่าง ๆ เหล่านี้ในตัวแปรท้องถิ่นและบันทึกแผนภูมิ

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();

    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

    var majorUnit = chart.getAxes().getVerticalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getVerticalAxis().getActualMinorUnit();

    var majorUnitScale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale();
    var minorUnitScale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale();

    presentation.save("AxisValues_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **สลับข้อมูลระหว่างแกน**

ใช้ [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) เพื่อแลกเปลี่ยนบทบาทของซีรีส์และประเภทในข้อมูลแผนภูมิ แต่ละประเภทเดิมจะกลายเป็นซีรีส์และแต่ละซีรีส์เดิมจะกลายเป็นประเภท การเปลี่ยนแปลงนี้มีผลต่อการจัดกลุ่มข้อมูล ไม่ได้สลับแกนแนวนอนกับแนวตั้ง ตัวอย่างใช้ [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) เพื่อผูกข้อมูลเริ่มต้นกับ `Sheet1!A1:D5` รวมถึงแถวหัวและคอลัมน์ประเภทก่อนสลับแถวและคอลัมน์ ตัวอย่างบันทึกแผนภูมิที่มีสี่ซีรีส์และสามประเภท

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    chart.getChartData().setRange("Sheet1!A1:D5");
    chart.getChartData().switchRowColumn();

    presentation.save("SwitchChartRowColumns_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **กลับลำดับการพล็อตของแกน**

ใช้ [setPlotOrderReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setplotorderreversed/) เพื่อกลับลำดับของแกนประเภทหรือค่า ตัวอย่างเช่น แผนภูมิแท่งแนวนอนอาจแสดงขั้นตอนโครงการจากบนลงล่างในลำดับเดียวกับชีต: Planning, Development, Testing การกลับแกนจะเปลี่ยนทิศทางการพล็อต ไม่ได้จัดเรียงหรือย้ายข้อมูลในเวิร์กบุ๊ก ในการเปรียบเทียบ [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) จะแลกเปลี่ยนบทบาทของซีรีส์และประเภท

ตัวอย่างต่อไปนี้สร้างแผนภูมิแท่งแนวนอนที่มีสามขั้นตอนและหนึ่งซีรีส์ บันทึกการนำเสนอที่มีสามสไลด์: ลำดับปกติ, หมวดหมู่ย้อนกลับ, ค่ากลับด้าน แต่ละสำเนาใช้ชุดข้อมูลเดียวกันและมีการกลับแกนเพียงหนึ่งแกนต่อสำเนา

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredBar, 50, 40, 620, 320);
    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.ClusteredBar);
    var stages = ["Planning", "Development", "Testing"];
    var values = [10, 30, 20];
    for (var i = 0; i < stages.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, stages[i]);
        chart.getChartData().getCategories().add(categoryCell);
        var valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    // สไลด์ 2: แสดงประเภทแรกที่ด้านบน.
    var categorySlide = presentation.getSlides().addClone(slide);
    var categoryChart = categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // รักษาแกนค่าที่แนวนอนให้อยู่ที่ด้านล่าง.
    categoryChart.getAxes().getVerticalAxis().setCrossType(aspose.slides.CrossesType.Maximum);

    // สไลด์ 3: กลับทิศเฉพาะสเกลเชิงตัวเลขแนวนอน.
    var valueSlide = presentation.getSlides().addClone(slide);
    var valueChart = valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การกลับแกนยังสามารถย้ายแกนตั้งฉากไปยังด้านตรงข้ามของพล็อตได้ [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) ควบคุมว่ากAxisอื่นข้ามแกนที่กำหนดไว้ที่ตำแหน่งใด ในสไลด์ 2 การเรียกด้วย `aspose.slides.CrossesType.Maximum` บนแกนประเภทที่กลับไว้ทำให้แกนค่าตั้งอยู่ที่ด้านล่าง สำหรับจุดข้ามที่กำหนดเฉพาะใช้ [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/) ตรวจสอบการตั้งค่าข้ามเมื่อเปลี่ยนทิศทาง โดยเฉพาะอย่างยิ่งหากแผนภูมิมีจุดข้ามที่กำหนดไว้เอง เรียก `setPlotOrderReversed` ด้วย `false` เพื่อคืนทิศทางพล็อตปกติ; การตั้งค่าข้ามเป็นค่าแยกกัน

| ลำดับปกติ (สไลด์ 1) | หมวดหมู่ย้อนกลับ (สไลด์ 2) | ค่ากลับด้าน (สไลด์ 3) |
| --- | --- | --- |
| ![แผนภูมิแท่งแนวนอนที่มีลำดับแกนหมวดและค่าแบบปกติ](axis-order-normal.png) | ![แผนภูมิแท่งแนวนอนที่แสดงประเภทจากบนลงล่าง](axis-order-categories-reversed.png) | ![แผนภูมิแท่งแนวนอนที่มีแกนค่ากลับด้านและศูนย์อยู่ด้านขวา](axis-order-values-reversed.png) |
| ประเภทวิ่งจากล่างขึ้นบน; ค่าเพิ่มจากซ้ายไปขวา. | Planning, Development, และ Testing วิ่งจากบนลงล่าง. ค่าและลำดับแถวเวิร์กบุ๊กไม่มีการเปลี่ยนแปลง. | ประเภทคงลำดับปกติ; ค่าเพิ่มจากขวาไปซ้าย. แกนประเภทข้ามที่ศูนย์ด้านขวา. |

## **ปิดการแสดงแกนแนวตั้งสำหรับแผนภูมิเส้น**

เรียก [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) ด้วย `false` บนแกนแนวตั้งเพื่อซ่อนมัน ตัวอย่างสร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้นและบันทึกโดยที่แกนแนวตั้งถูกซ่อน

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);

    presentation.save("HiddenVerticalAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ปิดการแสดงแกนแนวนอนสำหรับแผนภูมิเส้น**

เรียก [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) ด้วย `false` บนแกนแนวนอนเพื่อซ่อนมัน ตัวอย่างสร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้นและบันทึกโดยที่แกนแนวนอนถูกซ่อน

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);

    presentation.save("HiddenHorizontalAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **แสดงหรือซ่อนเส้นกริดของแผนภูมิ**

เรียก [getShowMajorGridLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getshowmajorgridlines/) และ [getShowMinorGridLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getshowminorgridlines/) เพื่อตรวจสอบว่าแกนแสดงเส้นกริดใดบ้าง หากต้องการแสดงเส้นกริดย่อย ใช้ [getMinorGridLinesFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getminorgridlinesformat/) แล้วตั้งค่าการเติมเส้นเป็นสีทึบที่มองเห็นได้ หากต้องการซ่อน ให้ตั้งค่าการเติมเป็น [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/). ใช้ [getMajorGridLinesFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getmajorgridlinesformat/) เพื่อเปลี่ยนการเติมเส้นสำหรับกริดหลักในวิธีเดียวกัน การเปลี่ยนการเติมจะคงการมองเห็นของแกนและเครื่องหมายติ๊ก

แกนแนวตั้งของแผนภูมิคอลัมน์แบบกลุ่มนี้เริ่มต้นแสดงเพียงกริดหลัก ตัวอย่างแสดงกริดย่อยเป็นสีส้มเข้มแล้วซ่อนอีกครั้งก่อนบันทึกการนำเสนอ และพิมพ์สถานะการมองเห็นของกริดในแต่ละขั้นตอน

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 30, 660, 230);
    var axis = chart.getAxes().getVerticalAxis();
    console.log("Initial: major=%s, minor=%s", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    var minorFill = axis.getMinorGridLinesFormat().getLine().getFillFormat();
    minorFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
    var darkOrange = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    minorFill.getSolidFillColor().setColor(darkOrange);
    console.log("Enabled: minor=%s", axis.getShowMinorGridLines());

    minorFill.setFillType(java.newByte(aspose.slides.FillType.NoFill));
    console.log("Hidden: major=%s, minor=%s", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    presentation.save("ChartGridlines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| เปิดใช้งานกริดย่อย | ซ่อนกริดย่อย |
| --- | --- |
| ![กริดย่อยสีส้มระหว่างกริดหลักบนแกนแนวตั้ง](minor-gridlines-enabled.png) | ![แผนภูมิคอลัมน์เดียวกันที่แสดงเฉพาะกริดหลัก](minor-gridlines-hidden.png) |

## **เปลี่ยนแกนประเภท**

ใช้ [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) เพื่อเลือกแกนประเภทแบบวันที่หรือข้อความ ตัวอย่างนี้ต้องการไฟล์ `ExistingChart.pptx` ที่มีแผนภูมิเป็นรูปร่างแรกบนสไลด์แรกและเซลล์ประเภทมีค่าตัวเลขของวันที่ Excel จะเปลี่ยนแกนแนวนอนเป็นแกนวันที่ การเรียก [setAutomaticMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmajorunit/) ด้วย `false`, [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) ด้วย `1`, และ [setMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunitscale/) ด้วย `TimeUnitType.Months` จะวางเครื่องหมายหลักที่ช่วงหนึ่งเดือน

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(aspose.slides.TimeUnitType.Months);

    presentation.save("ChangeChartCategoryAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **กำหนดประเภทแกนประเภทจากข้อมูล**

หลังจากเติมประเภทแล้วเรียก [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistypeautomatically/) แล้วอ่าน [getCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getcategoryaxistype/) เพื่อตรวจสอบการเลือก วิธีนี้มีประโยชน์เมื่อแผนภูมิเช่นเดียวกันอาจได้รับป้ายข้อความหรือค่าตัวเลขของวันที่ วิธีนี้กำหนดประเภทเมื่อเรียกใช้; ไม่ได้เปิดโหมดคงที่ที่จะประเมินข้อมูลใหม่ในภายหลัง เรียกอีกครั้งหลังจากแทนที่ประเภท

ตัวอย่างต่อไปนี้สร้างแผนภูมิที่มีประเภทเป็นข้อความและพิมพ์ `true` เมื่อประเภทที่เลือกคือ `CategoryAxisType.Text` จากนั้นแทนที่ค่าของเซลล์ประเภทด้วยวันที่และเรียกเมธอดอีกครั้ง พิมพ์ `true` เมื่อประเภทที่เลือกคือ `CategoryAxisType.Date` วันที่ถูกเก็บเป็นค่าตัวเลข OLE Automation ซึ่งคำนวนเป็นจำนวนวันตั้งแต่ 30 ธันวาคม 1899 ไม่ใช่สตริงวันที่ การคำนวนใน JavaScript ใช้เวลาแบบ UTC แล้วหารผลต่างด้วย 86 400 000 มิลลิวินาทีต่อวัน; ตัวบ่งชี้เดือนเริ่มจากศูนย์ ใช้ `java.newDouble` เพื่อส่งค่าตำแหน่งวันที่แต่ละค่าไปยัง Java เป็น double [setCustomNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setcustomnumberformat/) ควบคุมการแสดงค่าดังกล่าว; ไม่ได้แปลงข้อความเป็นวันที่ตัวเลข สำหรับข้อมูลประเภทเพิ่มเติมดูที่ [Chart Workbook](/slides/th/nodejs-java/chart-workbook/)

ใช้การกำหนดอัตโนมัติเสมอเมื่ออินพุตมีประเภทข้อความหรือวันที่เชิงตัวเลข อย่างเช่นในตัวอย่างนี้ สำหรับป้ายตัวเลขธรรมดา ประเภทผสม หรือข้อมูลว่าง ให้เรียก [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) อย่างชัดเจนเพื่อให้ตรงกับความหมายที่ต้องการ ค่าตัวเลขเดี่ยวไม่ได้บ่งบอกว่าประเภทเป็นวันที่

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var seriesName = workbook.getCell(0, 0, 1, "Sales");
    var series = chart.getChartData().getSeries().add(seriesName, chart.getType());
    var labels = ["First", "Second", "Third"];

    for (var i = 0; i < labels.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, labels[i]);
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, (i + 1) * 10);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    var axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisTypeAutomatically();
    console.log(axis.getCategoryAxisType() === aspose.slides.CategoryAxisType.Text); // จริง

    var baseDate = Date.UTC(1899, 11, 30);
    var dates = [Date.UTC(2026, 0, 1), Date.UTC(2026, 0, 2), Date.UTC(2026, 1, 1)];

    for (var i = 0; i < dates.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0);
        var dateValue = java.newDouble((dates[i] - baseDate) / 86400000);
        categoryCell.setValue(dateValue);
        categoryCell.setCustomNumberFormat("yyyy-mm-dd");
    }

    axis.setCategoryAxisTypeAutomatically();
    console.log(axis.getCategoryAxisType() === aspose.slides.CategoryAxisType.Date); // จริง

    presentation.save("AutomaticCategoryAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ควบคุมช่วงเวลาของป้ายแกนประเภท**

เมื่อแผนภูมิมีประเภทจำนวนมาก ให้ลดจำนวนป้ายแกนที่มองเห็นได้โดยไม่ต้องลบประเภทหรือจุดข้อมูล เรียก [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticticklabelspacing/) ด้วย `false` แล้วส่งช่วงประเภทที่ต้องการไปที่ [setTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelspacing/) สำหรับประเภทข้อความในลำดับปกติ การนับเริ่มจากประเภทแรก:

| ช่วง | ป้ายที่แสดงในตัวอย่าง |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

ช่วง `3` จะแสดงป้ายทุก ๆ ที่สาม โดยซ่อนสองป้ายระหว่างป้ายที่แสดง ไม่ได้ลบคอลัมน์ที่สอดคล้องกัน การจัดระยะอัตโนมัติเลือกช่วงตามพื้นที่ที่มีอยู่; ไม่ได้รับประกันว่าจะเห็นทุกป้าย

เครื่องหมายติ๊กมีการควบคุมแยกกัน เรียก [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomatictickmarksspacing/) ด้วย `false` แล้วใช้ [setTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settickmarksspacing/) เพื่อกำหนดช่วงของมัน ตัวอย่างเช่น `1` จะทำให้มีเครื่องหมายติ๊กที่ทุกช่วงประเภทขณะที่ป้ายปรากฏเฉพาะทุก ๆ ที่สาม ใช้ [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) พร้อมสไตล์ที่มองเห็นได้เพื่อดูผลลัพธ์ การเรียกตั้งค่าการจัดระยะอัตโนมัติอีกครั้งด้วย `true` จะทำให้แผนภูมิกำหนดช่วงใหม่

ตัวอย่างต่อไปนี้สร้าง 24 ประเภทและหนึ่งซีรีส์ แล้วบันทึกสามสไลด์ใน `CategoryAxisIntervals.pptx`: การจัดระยะอัตโนมัติ, การจัดระยะแบบกำหนดเองพร้อมเครื่องหมายติ๊กแยกจากกัน, และการคืนค่าการจัดระยะอัตโนมัติ สองสำเนารักษาข้อมูลแผนภูมิดั้งเดิม ไม่ต้องมีการนำเข้าการนำเสนอใด ๆ ข้อความป้ายแนวนอนทำให้เห็นความหนาแน่นได้ง่าย

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.setLegend(false);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.ClusteredColumn);
    for (var i = 0; i < 24; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        var valueCell = workbook.getCell(0, i + 1, 1, 10 + i % 6 * 5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    var axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisType(aspose.slides.CategoryAxisType.Text);
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0);
    axis.getTextFormat().getPortionFormat().setFontHeight(12);
    axis.setMajorTickMark(aspose.slides.TickMarkType.Outside);
    axis.setAutomaticTickLabelSpacing(true);
    axis.setAutomaticTickMarksSpacing(true);

    // สไลด์ 2: แสดงป้ายทุกสามรายการ แต่คงเครื่องหมายติ๊กสำหรับแต่ละประเภท.
    var manualSlide = presentation.getSlides().addClone(slide);
    var manualChart = manualSlide.getShapes().get_Item(0);
    var manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // สไลด์ 3: ให้แผนภูมิเ�เลือกช่วงทั้งสองใหม่อีกครั้ง.
    var restoredSlide = presentation.getSlides().addClone(manualSlide);
    var restoredChart = restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**การจัดระยะอัตโนมัติ (สไลด์ 1):** ในการแสดงผลนี้ ป้ายประเภทที่สองจะแสดงและแตกบรรทัดสองบรรทัด ผลลัพธ์อัตโนมัติอาจแตกต่างตามขนาดแผนภูมิ, ฟอนต์และเครื่องเรนเดอร์

![การจัดระยะป้ายประเภทอัตโนมัติที่แสดงคอลัมน์ทั้งหมด 24 คอลัมน์ที่มองเห็นได้](category-axis-automatic.png)

**การจัดระยะแบบกำหนดเอง (สไลด์ 2):** ป้ายทุก ๆ ที่สามจะแสดงบนบรรทัดเดียว ขณะที่เครื่องหมายติ๊กยังคงอยู่ที่ทุกช่วงประเภท คอลัมน์ทั้งหมด 24 คอลัมน์ รวมถึงคอลัมน์ที่ไม่มีป้าย ยังคงมองเห็นได้ด้วยค่าทันเดิม สไลด์ 3 คืนค่าการแสดงผลอัตโนมัติที่แสดงข้างต้น

![การจัดระยะป้ายประเภทแบบกำหนดเองที่สามกับคอลัมน์ทั้งหมด 24 คอลัมน์ที่มองเห็นได้](category-axis-manual.png)

### **เลือกแกนและช่วงที่ถูกต้อง**

ใช้ช่วงจำนวนประเภทนี้สำหรับแกนประเภทข้อความ เช่น แกนประเภทของแผนภูมิคอลัมน์, เส้น, พื้นที่หรือแท่ง ในแผนภูมิคอลัมน์เป็นแกนแนวนอน ในแผนภูมิแท่งแนวนอนแกนประเภทอยู่แนวตั้ง จึงใช้การตั้งค่าเหล่านี้กับแกนที่ได้จาก [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/) การจัดระยะเครื่องหมายติ๊กยังใช้ได้กับแกนซีรีส์ในแผนภูมิที่มีแกนซีรีส์

ห้ามใช้การจัดระยะป้ายประเภทเพื่อกำหนดสเกลเชิงตัวเลขของแกนค่า บนแกนค่า [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) ระบุความแตกต่างของค่า: เช่น หน่วยหลัก `10` จะสร้างเครื่องหมายที่ 0, 10, 20,… เมื่อแกนเริ่มที่ศูนย์ ช่วงป้ายประเภท `3` นับตำแหน่งประเภทโดยไม่คำนึงถึงค่าข้อมูล แผนภูมิกระจายและฟองใช้แกนค่าแทนแกนประเภทข้อความ สำหรับแกนวันที่ให้ใช้หน่วยหลักและสเกลตามเวลาอย่างที่อธิบายในส่วน [Change a Category Axis](#change-a-category-axis)

## **ตั้งรูปแบบวันที่สำหรับค่าของแกนประเภท**

ตัวอย่างนี้แทนที่ข้อมูลแผนภูมิเริ่มต้นด้วยค่าปีละสี่ค่า วันที่ถูกเก็บเป็นหมายเลขอนุกรม OLE Automation ในเวิร์กชีตแรก (ดัชนี `0`) คำนวนเป็นจำนวนวันตั้งแต่ 30 ธันวาคม 1899 สำหรับวันที่เหล่านี้ การคำนวนใน JavaScript ใช้ไทม์สแตมป์ UTC แล้วหารด้วย 86 400 000 มิลลิวินาทีต่อวัน ใช้ [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) กับ `CategoryAxisType.Date`, เรียก [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) ด้วย `false`, แล้วส่ง `yyyy` ไปที่ [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) เพื่อให้ป้ายประเภทแสดงปีสี่หลักโดยอิสระจากการฟอร์แมตของเซลล์

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var baseDate = Date.UTC(1899, 11, 30);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    for (var i = 0; i < 4; i++) {
        var date = Date.UTC(2015 + i, 0, 1);
        var categoryCell = workbook.getCell(0, i + 1, 0, (date - baseDate) / 86400000);
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, i + 1);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");

    presentation.save("DateAxisFormat.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งมุมการหมุนสำหรับหัวข้อแกนแผนภูมิ**

เรียก [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settitle/) ด้วย `true` บนแกนแนวตั้ง ให้ข้อความหัวข้อ แล้วใช้ [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setrotationangle/) เพื่อหมุนหัวข้อ มุมวัดเป็นองศา; ตัวอย่างนี้บันทึกแผนภูมิคอลัมน์ที่หัวข้อแกนค่าถูกหมุน 90 องศา

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value");
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    presentation.save("RotatedAxisTitle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งตำแหน่งแกนบนแกนประเภทหรือค่า**

ใช้ [setAxisBetweenCategories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaxisbetweencategories/) เพื่อควบคุมว่าแกนค่า จะข้ามแกนประเภทระหว่างประเภทหรือที่เครื่องหมายติ๊กของประเภท การตั้งค่านี้ใช้กับแกนประเภท ตัวอย่างตั้งค่าเป็น `true` บนแกนประเภทแนวนอนของแผนภูมิคอลัมน์และบันทึกผลลัพธ์

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    presentation.save("AxisBetweenCategories.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งหน่วยการแสดงผลบนแกนค่าของแผนภูมิ**

ใช้ [setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setdisplayunit/) เพื่อปรับสเกลป้ายบนแกนค่าโดยไม่เปลี่ยนข้อมูลพื้นฐาน ด้วย [DisplayUnitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/displayunittype/) ตั้งเป็น `Millions` ค่าที่ 60 000 000 จะปรากฏเป็น 60 ตัวอย่างสร้างแผนภูมิคอลัมน์และใช้หน่วยการแสดงผลเป็นล้านบนแกนแนวตั้ง

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Millions);

    presentation.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **กำหนดค่าการทำงานของแกนค่าลอการิทึม**

แกนค่าลอการิทึมมีประโยชน์เมื่อค่าบวกกระจายหลายลำดับขนาด ตัวอย่างเช่น ระบบอาจรับคำขอ 10, 100, 1 000, 10 000, 100 000 คำขอในห้าช่วง บนสเกลเชิงเส้นค่าที่เล็กจะอยู่ใกล้ศูนย์ ทำให้ยากต่อการเปรียบเทียบ ลอการิทึมทำให้การเติบโตสัมพัทธ์ง่ายต่อการเปรียบเทียบ: ระยะห่างเท่ากันแทนอัตราส่วนที่เท่ากันไม่ใช่ความแตกต่างเท่าเดิม

เรียก [setLogarithmic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogarithmic/) ด้วย `true` บนแกนค่า และใช้ [setLogBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogbase/) เพื่อเลือกฐาน การเปลี่ยนนี้ส่งผลต่อการแสดงค่าที่มีอยู่ ไม่ได้เปลี่ยนข้อมูลหรือเพิ่มเส้นเทรนด์ลอการิทึม เส้นเทรนด์เป็นฟีเจอร์แยกต่างหากที่แสดงความสัมพันธ์ที่ฟิตกับข้อมูล

### **เลือกแกนค่าและฐาน**

สำหรับแผนภูมิเส้นหรือคอลัมน์ แกนค่าจะได้จาก [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/). สำหรับแผนภูมิแท่งแนวนอน จะได้จาก [getHorizontalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/gethorizontalaxis/). แผนภูมิกระจายและฟองมีแกนค่าสองแกน ดังนั้นเลือกแกนแนวนอนสำหรับค่า X, แกนแนวตั้งสำหรับค่า Y หรือทั้งสองแกน อย่าใช้การสเกลลอการิทึมกับแกนประเภท

ฐานลอการิทึมเริ่มต้นคือ `10`. สำหรับแผนภูมิ PPTX ให้ใช้ฐานตั้งแต่ `2` ถึง `1000` รวมถึงฐานเศษส่วนเช่น `2.5` ฐาน `10` จะทำให้พลังที่ต่อเนื่องเช่น 10, 100, 1 000, 10 000 มีระยะห่างเท่ากัน

### **เปรียบเทียบการสเกลเชิงเส้นและลอการิทึม**

ตัวอย่างต่อไปนี้สร้างแผนภูมิเส้นที่มีจำนวนคำขอห้าครั้งในสไลด์แรก แล้วทำสำเนาสไลด์นั้นและเปิดใช้งานแกนค่าลอการิทึมฐาน 10 ในสไลด์สอง ทั้งสองสไลด์รักษาข้อมูลเดิม

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 30, 40, 660, 200);

    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    var values = [10, 100, 1000, 10000, 100000];

    for (var i = 0; i < values.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, "Period " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // รักษาให้สไลด์แรกเป็นเชิงเส้นและเปลี่ยนเฉพาะสเกลแกนค่าของสำเนาเท่านั้น.
    var logarithmicSlide = presentation.getSlides().addClone(slide);
    var logarithmicChart = logarithmicSlide.getShapes().get_Item(0);
    var valueAxis = logarithmicChart.getAxes().getVerticalAxis();
    valueAxis.setLogarithmic(true);
    valueAxis.setLogBase(10);

    presentation.save("LogarithmicAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**สเกลเชิงเส้น (สไลด์ 1):** ระยะแนวตั้งเท่ากันแทนความแตกต่างของจำนวนคำขอ ค่าที่ใหญ่ที่สุดครองแผนภูมิ ทำให้ค่าที่เล็กยากต่อการมองเห็น

![แผนภูมิเส้นใน PowerPoint ที่แสดงจำนวนคำขอห้าค่าบนแกนค่เชิงเส้น](value-axis-linear.png)

**สเกลลอการิทึม (สไลด์ 2):** ระยะแนวตั้งเท่ากันแทนอัตราส่วน ค่าต่อช่วงเพิ่มขึ้นสิบเท่าต่อช่วงก่อนหน้า ทำให้จุดข้อมูลเป็นเส้นตรงที่ขึ้นบนสเกลฐาน 10 ป้ายแกนยังคงแสดงจำนวนคำขอเดิม

![จำนวนคำขอห้าแบบเดียวกันใน PowerPoint บนแกนค่าลอการิทึมฐาน 10](value-axis-logarithmic.png)

### **จัดการศูนย์และค่าติดลบ**

สเกลลอการิทึมสามารถแสดงค่าเชิงบวกเท่านั้น ตรวจสอบข้อมูลก่อนเปิดใช้งาน หากค่าศูนย์หรือค่าติดลบมีความหมาย ควรใช้สเกลเชิงเส้นหรือแสดงแยกออก หากการยกเว้นค่าดังกล่าวเหมาะสมกับการวิเคราะห์ ให้อธิบายเหตุผล ห้ามแทนที่ค่าดังกล่าวด้วยตัวเลขบวกเล็ก ๆ อย่างเงียบ ๆ เพราะจะเปลี่ยนความหมายของข้อมูล ค่า minimum หรือ maximum ที่ตั้งค่ามาเองสำหรับแกนลอการิทึมก็ต้องเป็นบวกเช่นกัน

## **คำถามที่พบบ่อย**

**ฉันจะตั้งค่าตำแหน่งที่แกนหนึ่งข้ามอีกแกน (การข้ามแกน) อย่างไร?**

ใช้ [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) เพื่อเลือกพฤติกรรมการข้าม เพื่อระบุค่าตำแหน่งการข้ามเชิงตัวเลข ให้ใช้ [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/) การตั้งค่าเหล่านี้ช่วยย้ายการข้ามแกนไปยังเส้นฐานที่เหมาะสม

**ฉันจะวางตำแหน่งป้ายติ๊กสัมพันธ์กับแกนอย่างไร?**

เรียก [setTickLabelPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelposition/) ด้วย [TickLabelPositionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` หรือ `None`. เพื่อควบคุมเครื่องหมายติ๊กเอง ใช้ [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) หรือ [setMinorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setminortickmark/); สิ่งเหล่านี้แยกจากการวางตำแหน่งป้าย.