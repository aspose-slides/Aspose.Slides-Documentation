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
- บริหารจัดการแกน
- คุณสมบัติของแกน
- ค่ามากสุด
- ค่าต่ำสุด
- เส้นแกน
- รูปแบบวันที่
- ชื่อแกน
- ตำแหน่งแกน
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ค้นพบวิธีใช้ JavaScript กับ Aspose.Slides สำหรับ Node.js ผ่าน Java เพื่อปรับแต่งแกนแผนภูมิในงานนำเสนอ PowerPoint สำหรับรายงานและการแสดงผล"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการปรับแต่งแกนของแผนภูมิด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java โดยครอบคลุมค่าที่คำนวณของแกน การสลับแถวและคอลัมน์ของแผนภูมิ การแสดงหรือซ่อนแกน ช่วงเวลาของป้ายชื่อและเครื่องหมายติ๊กของประเภท การจัดรูปแบบวันเวลา การหมุนหัวเรื่อง การกำหนดตำแหน่งของแกน หน่วยการแสดงผล และการปรับขนาดแบบลอการิทึม

## **รับค่ามากที่สุดบนแกนแนวตั้งในแผนภูมิ**

สร้าง [การนำเสนอ](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) และเพิ่มแผนภูมิพื้นที่ด้วยข้อมูลเริ่มต้น เรียก [validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) ก่อนอ่านค่าที่คำนวณของแกนเพื่อให้โครงร่างแผนภูมิเป็นปัจจุบัน

อ่าน [getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmaxvalue/) และ [getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminvalue/) เพื่อรับขอบเขตของแกน และอ่าน [getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunit/) และ [getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunit/) เพื่อรับช่วงระยะของเครื่องหมายติ๊ก [getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunitscale/) และ [getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunitscale/) ให้สเกลหน่วยเวลา ซึ่งเกี่ยวข้องกับแกนวันที่ ตัวอย่างจะเก็บค่าเหล่านี้ในตัวแปรท้องถิ่นและบันทึกแผนภูมิ

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

## **เปลี่ยนข้อมูลระหว่างแกน**

ใช้ [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) เพื่อสลับบทบาทของซีรีส์และประเภทในข้อมูลแผนภูมิ แต่ละประเภทเดิมจะกลายเป็นซีรีส์ และแต่ละซีรีส์เดิมจะกลายเป็นประเภท สิ่งนี้จะเปลี่ยนวิธีการจัดกลุ่มข้อมูล แต่ไม่ได้สลับแกนแนวนอนและแนวตั้ง ตัวอย่างใช้ [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) เพื่อผูกข้อมูลเริ่มต้นกับ `Sheet1!A1:D5` รวมถึงแถวหัวเรื่องและคอลัมน์ประเภท ก่อนการสลับแถวและคอลัมน์ จะบันทึกแผนภูมิที่มีสี่ซีรีส์และสามประเภท

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

ใช้ [setPlotOrderReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setplotorderreversed/) เพื่อกลับลำดับของแกนประเภทหรือค่า ตัวอย่างเช่น แผนภูมิแท่งแนวนอนสามารถแสดงขั้นตอนของโครงการจากบนลงล่างในลำดับเดียวกับในแผ่นงาน: Planning, Development, Testing การกลับลำดับของแกนจะเปลี่ยนทิศทางการพล็อต แต่ไม่ได้จัดเรียงหรือปรับตำแหน่งข้อมูลในเวิร์กบุ๊ก สำหรับการเปรียบเทียบ [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) จะสลับบทบาทของซีรีส์และประเภท

ตัวอย่างต่อไปนี้สร้างแผนภูมิแท่งแนวนอนที่มีสามขั้นตอนและหนึ่งซีรีส์ จะบันทึกการนำเสนอที่มีสามสไลด์: ลำดับปกติ, ประเภทกลับลำดับ, และค่ากลับลำดับ แต่ละสำเนาใช้ชุดข้อมูลเดียวกันและแต่ละสำเนาจะกลับลำดับของแกนเพียงหนึ่งแกน

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
    // คงแกนค่าตามแนวนอนไว้ที่ด้านล่าง.
    categoryChart.getAxes().getVerticalAxis().setCrossType(aspose.slides.CrossesType.Maximum);

    // สไลด์ 3: กลับลำดับเฉพาะสเกลตัวเลขแนวนอนเท่านั้น.
    var valueSlide = presentation.getSlides().addClone(slide);
    var valueChart = valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การกลับลำดับของแกนอาจทำให้แกนตั้งฉากย้ายไปยังด้านตรงข้ามของพล็อต [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) ควบคุมว่าตำแหน่งที่แกนอื่นตัดแกนที่กำหนดคือที่ใด ในสไลด์ที่ 2 การเรียกใช้ด้วยค่า `aspose.slides.CrossesType.Maximum` บนแกนประเภทที่กลับลำดับจะทำให้แกนค่าตามแนวนอนอยู่ที่ด้านล่าง สำหรับจุดตัดที่กำหนดให้ใช้ [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/) ตรวจสอบการตั้งค่าตัดเมื่อเปลี่ยนทิศทาง โดยเฉพาะหากแผนภูมิมีจุดตัดที่กำหนดเองแล้ว เรียก `setPlotOrderReversed` ด้วยค่า `false` เพื่อคืนทิศทางการพล็อตปกติ; การตั้งค่าตัดเป็นเรื่องแยกจากกัน

| ลำดับปกติ (สไลด์ 1) | ประเภทกลับลำดับ (สไลด์ 2) | ค่ากลับลำดับ (สไลด์ 3) |
| --- | --- | --- |
| ![แผนภูมิแท่งแนวนอนที่มีลำดับปกติของแกนประเภทและค่า](axis-order-normal.png) | ![แผนภูมิแท่งแนวนอนที่แสดงประเภทจากบนลงล่าง](axis-order-categories-reversed.png) | ![แผนภูมิแท่งแนวนอนที่มีแกนค่ากลับลำดับและศูนย์อยู่ด้านขวา](axis-order-values-reversed.png) |
| ประเภทวิ่งจากล่างขึ้นบน; ค่าจะเพิ่มจากซ้ายไปขวา. | Planning, Development, และ Testing วิ่งจากบนลงล่าง ค่และลำดับแถวในเวิร์กบุ๊กไม่เปลี่ยนแปลง. | ประเภทคงลำดับปกติ; ค่าจะเพิ่มจากขวาไปซ้าย แกนประเภทตัดที่ศูนย์ด้านขวา. |

## **ปิดการแสดงแกนแนวตั้งสำหรับแผนภูมิเส้น**

เรียก [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) ด้วยค่า `false` บนแกนแนวตั้งเพื่อซ่อนมัน ตัวอย่างสร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้นและบันทึกโดยมีแกนแนวตั้งซ่อนอยู่

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

เรียก [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) ด้วยค่า `false` บนแกนแนวนอนเพื่อซ่อนมัน ตัวอย่างสร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้นและบันทึกโดยมีแกนแนวนอนซ่อนอยู่

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

## **เปลี่ยนแกนประเภท**

ใช้ [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) เพื่อเลือกแกนประเภทแบบวันที่หรือข้อความ ตัวอย่างนี้ต้องใช้ไฟล์ `ExistingChart.pptx` ซึ่งมีแผนภูมิเป็นรูปร่างแรกบนสไลด์แรกและเซลล์ประเภทมีค่าตัวเลขวันที่ของ Excel จะเปลี่ยนแกนแนวนอนเป็นแกนวันที่ การเรียก [setAutomaticMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmajorunit/) ด้วยค่า `false`, [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) ด้วยค่า `1`, และ [setMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunitscale/) ด้วยค่า `TimeUnitType.Months` จะวางเครื่องหมายติ๊กหลักในช่วงระยะเวลาเดือนละหนึ่งครั้ง

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

## **ควบคุมช่วงเวลาของป้ายชื่อแกนประเภท**

เมื่อแผนภูมิมีหลายประเภท ให้ลดจำนวนป้ายชื่อแกนที่มองเห็นได้โดยไม่ต้องลบประเภทหรือจุดข้อมูล เรียก [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticticklabelspacing/) ด้วยค่า `false` จากนั้นส่งค่าช่วงประเภทที่ต้องการไปที่ [setTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelspacing/) สำหรับประเภทข้อความตามลำดับปกติ การนับเริ่มจากประเภทแรก:

| ช่วง | ป้ายชื่อที่แสดงในตัวอย่าง |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

ช่วง `3` จะแสดงป้ายชื่อทุกสามตำแหน่ง โดยเว้นป้ายสองตำแหน่งระหว่างป้ายที่แสดง ไม่ได้ลบคอลัมน์ที่สอดคล้องกัน การจัดระยะห่างอัตโนมัติเลือกช่วงตามพื้นที่ที่มีอยู่; ไม่ได้แสดงป้ายชื่อทุกอันเสมอ

เครื่องหมายติ๊กมีการควบคุมแยกต่างหาก เรียก [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomatictickmarksspacing/) ด้วยค่า `false` แล้วใช้ [setTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settickmarksspacing/) เพื่อตั้งค่าช่วงของมัน ตัวอย่างเช่นค่า `1` จะทำให้มีเครื่องหมายติ๊กที่ทุกช่วงประเภท ขณะเดียวกันป้ายชื่อจะแสดงเฉพาะทุกสามประเภท ใช้ [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) พร้อมสไตล์ที่มองเห็นได้เพื่อดูผล การเรียกตั้งค่าอัตโนมัติใด ๆ อีกครั้งด้วยค่า `true` จะทำให้แผนภูมิเลือกช่วงนั้นใหม่

ตัวอย่างอิสระต่อไปนี้สร้าง 24 ประเภทและหนึ่งซีรีส์ จากนั้นบันทึกสามสไลด์ในไฟล์ `CategoryAxisIntervals.pptx`: การจัดระยะห่างอัตโนมัติ, การจัดระยะห่างป้ายชื่อด้วยตนเองพร้อมเครื่องหมายติ๊กอิสระ, และการคืนค่าการจัดระยะห่างอัตโนมัติ ทั้งสองสำเนารักษาข้อมูลแผนภูมิดั้งเดิม ไม่จำเป็นต้องมีการนำเสนอเข้ามา ข้อความป้ายชื่อแนวนอนทำให้เห็นความแตกต่างของความหนาแน่นได้ง่าย

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

    // สไลด์ 2: แสดงทุกป้ายกำกับที่สาม แต่คงเครื่องหมายติ๊กไว้สำหรับทุกประเภท.
    var manualSlide = presentation.getSlides().addClone(slide);
    var manualChart = manualSlide.getShapes().get_Item(0);
    var manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // สไลด์ 3: ให้แผนภูมิเลือกช่วงทั้งสองใหม่อีกครั้ง.
    var restoredSlide = presentation.getSlides().addClone(manualSlide);
    var restoredChart = restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**การจัดระยะห่างอัตโนมัติ (สไลด์ 1):**  
ในการแสดงผลนี้ ป้ายชื่อประเภททุกสองตำแหน่งจะแสดงและตัดบรรทัดเป็นสองบรรทัด ผลลัพธ์อัตโนมัติอาจแตกต่างกันตามขนาดแผนภูมิ, ฟอนต์, และตัวเรนเดอร์  
![การจัดระยะห่างป้ายชื่อประเภทอัตโนมัติพร้อมคอลัมน์ทั้งหมด 24 คอลัมน์มองเห็น](category-axis-automatic.png)

**การจัดระยะห่างด้วยตนเอง (สไลด์ 2):**  
ป้ายชื่อทุกสามตำแหน่งจะแสดงในบรรทัดเดียว ขณะที่เครื่องหมายติ๊กยังคงอยู่ที่ทุกช่วงประเภท ทั้ง 24 คอลัมน์รวมถึงคอลัมน์ที่ไม่มีป้ายชื่อยังคงมองเห็นได้พร้อมค่าที่เหมือนเดิม สไลด์ที่ 3 คืนลักษณะอัตโนมัติที่แสดงข้างต้น  
![ช่วงป้ายชื่อประเภทด้วยตนเองที่สามพร้อมคอลัมน์ทั้งหมด 24 คอลัมน์มองเห็น](category-axis-manual.png)

### **เลือกแกนและช่วงที่ถูกต้อง**

ใช้ช่วงจำนวนประเภทนี้สำหรับแกนประเภทข้อความ เช่น แกนประเภทของแผนภูมิคอลัมน์, เส้น, พื้นที่ หรือแท่ง ในแผนภูมิคอลัมน์ จะเป็นแกนแนวนอน ในแผนภูมิแท่งแนวนอน แกนประเภทจะเป็นแนวตั้ง ดังนั้นให้ใช้การตั้งค่าเหล่านี้กับแกนที่ได้จาก [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/) ระยะห่างของเครื่องหมายติ๊กยังใช้กับแกนซีรีส์ในแผนภูมิที่มีแกนซีรีส์

อย่าใช้การจัดระยะห่างของป้ายชื่อประเภทเพื่อกำหนดสเกลเชิงตัวเลขของแกนค่า บนแกนค่า, [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) กำหนดความแตกต่างของค่า: ตัวอย่างเช่น หน่วยหลัก `10` จะสร้างเครื่องหมายติ๊กที่ 0, 10, 20 เป็นต้นเมื่อแกนเริ่มที่ศูนย์ ช่วงป้ายชื่อประเภท `3` จะนับตำแหน่งประเภทโดยไม่คำนึงถึงค่าข้อมูล แผนภูมิกระจายและฟองอากาศใช้แกนค่าแทนแกนประเภทข้อความ สำหรับแกนวันที่ ให้ใช้หน่วยหลักและสเกลตามเวลาอย่างที่อธิบายใน [เปลี่ยนแกนประเภท](#change-a-category-axis)

## **ตั้งค่ารูปแบบวันที่สำหรับค่าแกนประเภท**

ตัวอย่างนี้แทนที่ข้อมูลแผนภูมิเริ่มต้นด้วยค่าปีละสี่ค่า วันที่ถูกเก็บเป็นเลขซีเรียล OLE Automation ในแผ่นงานแรก (ดัชนี `0`) ซึ่งคำนวณจากจำนวนวันตั้งแต่วันที่ 30 ธันวาคม 1899 สำหรับวันที่เหล่านี้ การคำนวณใน JavaScript ใช้เวลา UTC แล้วหารผลต่างด้วย 86,400,000 มิลลิวินาทีต่อวัน ใช้ [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) ด้วยค่า `CategoryAxisType.Date` เรียก [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) ด้วยค่า `false` และส่ง `yyyy` ไปที่ [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) เพื่อให้ป้ายชื่อประเภทแสดงปีสี่หลักโดยอิสระจากการฟอร์แมตของเซลล์

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

## **ตั้งค่ามุมการหมุนสำหรับหัวเรื่องแกนแผนภูมิ**

เรียก [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settitle/) ด้วยค่า `true` บนแกนแนวตั้ง ให้ข้อความหัวเรื่อง และใช้ [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setrotationangle/) เพื่อหมุนหัวเรื่อง มุมจะวัดเป็นองศา; ตัวอย่างนี้บันทึกแผนภูมิคอลัมน์ที่หัวเรื่องแกนค่าถูกหมุน 90 องศา

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

## **ตั้งตำแหน่งแกนบนแกนประเภทหรือแกนค่า**

ใช้ [setAxisBetweenCategories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaxisbetweencategories/) เพื่อควบคุมว่ากราฟค่า จะตัดแกนประเภทระหว่างประเภทหรือที่เครื่องหมายติ๊กของประเภท การตั้งค่านี้ใช้กับแกนประเภท ตัวอย่างตั้งค่าเป็น `true` บนแกนประเภทแนวนอนของแผนภูมิคอลัมน์และบันทึกผลลัพธ์

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

## **ตั้งค่าหน่วยการแสดงผลบนแกนค่าของแผนภูมิ**

ใช้ [setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setdisplayunit/) เพื่อปรับสเกลของป้ายชื่อบนแกนค่าโดยไม่เปลี่ยนข้อมูลพื้นฐาน ด้วยการตั้งค่า [DisplayUnitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/displayunittype/) เป็น `Millions` ค่าที่ 60,000,000 จะแสดงเป็น 60 ตัวอย่างสร้างแผนภูมิคอลัมน์และใช้หน่วยการแสดงผลเป็นล้านบนแกนแนวตั้งของมัน

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

## **กำหนดค่าแกนค่าลอการิทึม**

แกนค่าลอการิทึมมีประโยชน์เมื่อค่าบวกมีช่วงหลายระดับขนาด ตัวอย่างเช่น บริการอาจได้รับคำขอ 10, 100, 1,000, 10,000, และ 100,000 ครั้งในห้าช่วง เวลาในสเกลเชิงเส้น ค่าที่เล็กจะอยู่ใกล้กันใกล้ศูนย์ สเกลลอการิทึมทำให้การเปรียบเทียบการเติบโตสัมพัทธ์ง่ายขึ้น: ระยะทางที่เท่ากันแทนอัตราส่วนที่เท่ากัน ไม่ใช่ความแตกต่างที่เท่ากัน

เรียก [setLogarithmic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogarithmic/) ด้วยค่า `true` บนแกนค่าและใช้ [setLogBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogbase/) เพื่อเลือกฐาน การทำเช่นนี้จะเปลี่ยนวิธีการแสดงค่าที่มีอยู่ ไม่ได้เปลี่ยนข้อมูลหรือเพิ่มเส้นเทรนด์ลอการิทึม เส้นเทรนด์เป็นตัวแทนของความสัมพันธ์ที่ฟิตกับข้อมูลและเป็นคุณลักษณะแยกจากกัน

### **เลือกแกนค่าและฐาน**

สำหรับแผนภูมิเส้นหรือคอลัมน์ แกนค่าจะได้จาก [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/) สำหรับแผนภูมิแท่งแนวนอน จะได้จาก [getHorizontalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/gethorizontalaxis/) แผนภูมิกระจายและฟองอากาศมีแกนค่าสองแกน ดังนั้นให้เลือกแกนแนวนอนสำหรับค่า X, แกนนอนสำหรับค่า Y หรือทั้งสองแกน อย่าใช้สเกลลอการิทึมกับแกนประเภท

ฐานลอการิทึมเริ่มต้นคือ `10` สำหรับแผนภูมิ PPTX ให้ใช้ฐานตั้งแต่ `2` ถึง `1000` รวมถึงฐานเศษส่วนเช่น `2.5` ด้วย เมื่อใช้ฐาน `10` กำลังต่อเนื่องเช่น 10, 100, 1,000 และ 10,000 จะมีระยะห่างเท่ากัน

### **เปรียบเทียบการสเกลเชิงเส้นและลอการิทึม**

ตัวอย่างอิสระต่อไปนี้สร้างแผนภูมิเส้นที่มีจำนวนคำขอห้าค่าบนสไลด์แรก จากนั้นคัดลอกสไลด์นั้นและเปิดใช้งานแกนค่าลอการิทึมฐาน 10 บนสไลด์ที่สอง ทั้งสองสไลด์คงข้อมูลเดิม

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

    // คงสไลด์แรกเป็นเชิงเส้นและเปลี่ยนสเกลแกนค่าของสำเนาเท่านั้น.
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

**สเกลเชิงเส้น (สไลด์ 1):**  
ระยะแนวตั้งที่เท่ากันแทนความแตกต่างที่เท่ากันของจำนวนคำขอ ค่าที่ใหญ่ที่สุดครอบงำแผนภูมิ ทำให้ค่าที่เล็กกว่าที่ยากต่อการแยกแยะ  
![แผนภูมิเส้นใน PowerPoint แสดงจำนวนคำขอห้าคาในแกนค่าตามสเกลเชิงเส้น](value-axis-linear.png)

**สเกลลอการิทึม (สไลด์ 2):**  
ระยะแนวตั้งที่เท่ากันแทนอัตราส่วนที่เท่ากัน แต่ละช่วงมีจำนวนคำขอมากกว่าช่วงก่อนสิบเท่า ดังนั้นจุดจะสร้างเส้นตรงที่โค้งขึ้นบนสเกลฐาน 10 ป้ายชื่อแกนยังคงแสดงจำนวนคำขอเดิม  
![จำนวนคำขอห้าค่าเดียวกันใน PowerPoint บนแกนค่าลอการิทึมฐาน 10](value-axis-logarithmic.png)

### **จัดการค่าศูนย์และค่าติดลบ**

สเกลลอการิทึมสามารถแสดงได้เฉพาะค่าบวกอย่างเคร่งครัด ตรวจสอบข้อมูลก่อนเปิดใช้งาน หากค่าศูนย์หรือค่าติดลบมีความหมาย ให้คงสเกลเชิงเส้นหรือแสดงแยกออก หากการตัดค่าดังกล่าวออกเป็นสิ่งที่เหมาะสมสำหรับการวิเคราะห์ ให้อธิบายการละเว้น อย่าแทนที่ค่าด้วยจำนวนบวกเล็ก ๆ โดยไม่แจ้ง เนื่องจากจะเปลี่ยนความหมายของข้อมูล ค่าต่ำสุดหรือค่าสูงสุดที่กำหนดด้วยตนเองสำหรับแกนลอการิทึมต้องเป็นค่าบวกด้วย

## **คำถามที่พบบ่อย**

**ฉันจะตั้งค่าค่าที่แกนหนึ่งตัดแกนอีก (การตัดแกน) อย่างไร?**  
ใช้ [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) เพื่อเลือกพฤติกรรมการตัดแกน หากต้องการระบุค่าตัดเชิงตัวเลข ให้ใช้ [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/) การตั้งค่าเหล่านี้ช่วยให้คุณย้ายตำแหน่งการตัดแกนไปยังเส้นฐานที่เหมาะสม

**ฉันจะกำหนดตำแหน่งป้ายที่ติ๊กสัมพันธ์กับแกนได้อย่างไร?**  
เรียก [setTickLabelPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelposition/) ด้วยค่า [TickLabelPositionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo`, หรือ `None` เพื่อควบคุมตำแหน่งป้ายที่ติ๊กเอง ใช้ [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) หรือ [setMinorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setminortickmark/); สิ่งเหล่านี้แยกจากการกำหนดตำแหน่งป้าย