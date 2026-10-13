---
title: ปรับแต่งแกนแผนภูมิในงานนำเสนอโดยใช้ JavaScript
linktitle: แกนแผนภูมิ
type: docs
url: /th/nodejs-java/chart-axis/
keywords:
- แกนแผนภูมิ
- แกนแนวตั้ง
- แกนแนวนอน
- ปรับแต่งแกน
- จัดการแกน
- จัดการแกน
- คุณสมบัติของแกน
- ค่าสูงสุด
- ค่าต่ำสุด
- เส้นแกน
- รูปแบบวันที่
- หัวข้อแกน
- ตำแหน่งแกน
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ค้นพบวิธีใช้ JavaScript กับ Aspose.Slides สำหรับ Node.js ผ่าน Java เพื่อปรับแต่งแกนแผนภูมิในงานนำเสนอ PowerPoint สำหรับรายงานและการแสดงภาพ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการปรับแต่งแกนของแผนภูมิด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java. ครอบคลุมค่าที่คำนวนของแกน, การสลับแถวและคอลัมน์ของแผนภูมิ, การแสดงหรือซ่อนแกน, ช่วงระยะเวลาของป้ายชื่อหมวดและเครื่องหมายแบ่ง, หมวดวันที่และการจัดรูปแบบ, การหมุนหัวข้อ, การกำหนดตำแหน่งแกน, หน่วยการแสดงผล, และการสเกลแบบลอการิทึม.

## **รับค่าสูงสุดบนแกนแนวตั้งของแผนภูมิ**

สร้าง [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) และเพิ่มแผนภูมิแบบพื้นที่พร้อมข้อมูลเริ่มต้น. เรียก [validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) ก่อนอ่านค่าที่คำนวนของแกน เพื่อให้การจัดวางแผนภูมิเป็นปัจจุบัน.

อ่าน [getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmaxvalue/) และ [getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminvalue/) สำหรับขอบเขตของแกน, และ [getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunit/) และ [getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunit/) สำหรับช่วงของเครื่องหมายแบ่ง. [getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunitscale/) และ [getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunitscale/) ให้สเกลหน่วยเวลา, ซึ่งเกี่ยวข้องกับแกนวันที่. ตัวอย่างนี้เก็บค่าดังกล่าวในตัวแปรท้องถิ่นและบันทึกแผนภูมิ.

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

ใช้ [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) เพื่อแลกเปลี่ยนบทบาทของชุดข้อมูลและหมวดหมู่ในข้อมูลแผนภูมิ. แต่ละหมวดเดิมจะกลายเป็นชุดข้อมูล, และแต่ละชุดข้อมูลเดิมจะกลายเป็นหมวด. การเปลี่ยนนี้ส่งผลต่อการจัดกลุ่มข้อมูล; มันไม่ได้สลับแกนแนวนอนและแนวตั้ง. ตัวอย่างใช้ [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) เพื่อผูกข้อมูลเริ่มต้นกับ `Sheet1!A1:D5`, รวมแถวหัวและคอลัมน์หมวด, ก่อนสลับแถวและคอลัมน์. ตัวอย่างบันทึกแผนภูมิที่มีสี่ชุดข้อมูลและสามหมวด.

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

## **ปิดการแสดงแกนแนวตั้งสำหรับแผนภูมิเส้น**

เรียก [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) ด้วย `false` บนแกนแนวตั้งเพื่อซ่อนมัน. ตัวอย่างสร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้นและบันทึกพร้อมแกนแนวตั้งที่ซ่อนอยู่.

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

เรียก [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) ด้วย `false` บนแกนแนวนอนเพื่อซ่อนมัน. ตัวอย่างสร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้นและบันทึกพร้อมแกนแนวนอนที่ซ่อนอยู่.

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

## **เปลี่ยนแกนหมวดหมู่**

ใช้ [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) เพื่อเลือกแกนหมวดหมู่แบบวันที่หรือข้อความ. ตัวอย่างนี้ต้องใช้ `ExistingChart.pptx`, ที่มีแผนภูมิเป็นรูปแบบแรกบนสไลด์แรกและเซลล์หมวดมีค่าตัวเลขของวันที่ใน Excel. ตัวอย่างเปลี่ยนแกนแนวนอนเป็นแกนวันที่. เรียก [setAutomaticMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmajorunit/) ด้วย `false`, [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) ด้วย `1`, และ [setMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunitscale/) ด้วย `TimeUnitType.Months` เพื่อวางเครื่องหมายหลักที่ช่วงเดือนละหนึ่งครั้ง.

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

## **ควบคุมช่วงเวลาของป้ายชื่อแกนหมวดหมู่**

เมื่อแผนภูมิมีหมวดจำนวนมาก, ลดจำนวนป้ายชื่อแกนที่มองเห็นได้โดยไม่ต้องลบหมวดหรือจุดข้อมูล. เรียก [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticticklabelspacing/) ด้วย `false`, แล้วส่งค่าช่วงหมวดที่ต้องการไปยัง [setTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelspacing/). สำหรับหมวดข้อความในลำดับปกติ, การนับเริ่มจากหมวดแรก:

| ช่วงเวลา | ป้ายชื่อที่แสดงในตัวอย่าง |
| --- | --- |
| `1` | หมวด 1, หมวด 2, หมวด 3, ... หมวด 24 |
| `2` | หมวด 1, หมวด 3, หมวด 5, ... หมวด 23 |
| `3` | หมวด 1, หมวด 4, หมวด 7, ... หมวด 22 |

ช่วงเวลา `3` จะแสดงป้ายชื่อทุกสามตำแหน่ง, โดยซ่อนสองป้ายระหว่างป้ายที่แสดง. มันไม่ได้ลบคอลัมน์ที่สอดคล้องกัน. การจัดระยะอัตโนมัติโหนดเลือกช่วงตามพื้นที่ที่มี; ไม่ได้จำเป็นต้องแสดงทุกป้าย.

เครื่องหมายแบ่งมีการควบคุมแยกต่างหาก. เรียก [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomatictickmarksspacing/) ด้วย `false` และใช้ [setTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settickmarksspacing/) เพื่อกำหนดช่วงของมัน. ตัวอย่างเช่น, `1` จะทำให้มีเครื่องหมายแบ่งที่ทุกช่วงหมวดขณะที่ป้ายชื่อปรากฏเฉพาะทุกสามหมวด. ใช้ [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) กับสไตล์ที่มองเห็นได้เพื่อดูผล. การเรียกตั้งค่าอัตโนมัติใด ๆ ด้วย `true` อีกครั้งจะทำให้แผนภูมิตั้งค่าช่วงนั้นใหม่.

ตัวอย่างอิสระต่อไปนี้สร้างหมวด 24 รายการและชุดข้อมูลหนึ่งชุด, จากนั้นบันทึกสามสไลด์ใน `CategoryAxisIntervals.pptx`: การจัดระยะอัตโนมัติ, การจัดระยะด้วยป้ายกำหนดเองพร้อมเครื่องหมายแบ่งอิสระ, และการคืนค่าการจัดระยะอัตโนมัติ. สองสำเนารักษาข้อมูลแผนภูมิดั้งเดิม. ไม่จำเป็นต้องมีการนำเสนออินพุต. ข้อความป้ายแนวนอนทำให้ความหนาแน่นเห็นได้ชัด.

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

    // สไลด์ 2: แสดงป้ายชื่อทุกสามตำแหน่ง, แต่ยังคงมีเครื่องหมายแบ่งสำหรับทุกหมวด.
    var manualSlide = presentation.getSlides().addClone(slide);
    var manualChart = manualSlide.getShapes().get_Item(0);
    var manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // สไลด์ 3: ให้แผนภูมิเลือกช่วงเวลาทั้งสองใหม่อีกครั้ง.
    var restoredSlide = presentation.getSlides().addClone(manualSlide);
    var restoredChart = restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**การจัดระยะอัตโนมัติ (สไลด์ 1):** ในการแสดงผลนี้, ป้ายชื่อหมวดที่แสดงทุกสองตำแหน่งและห่อบรรทัดเป็นสองบรรทัด. ผลลัพธ์อัตโนมัติอาจแตกต่างตามขนาดแผนภูมิ, ฟอนต์, และเครื่องเรนเดอร์.

![การจัดระยะป้ายชื่อหมวดอัตโนมัติพร้อมคอลัมน์ 24 คอลัมน์ที่มองเห็นทั้งหมด](category-axis-automatic.png)

**การจัดระยะแบบกำหนดเอง (สไลด์ 2):** ป้ายชื่อทุกสามตำแหน่งจะปรากฏบนบรรทัดเดียว, ในขณะที่เครื่องหมายแบ่งยังคงอยู่ที่ทุกช่วงหมวด. คอลัมน์ 24 ทั้งหมด, รวมถึงที่ไม่มีป้ายชื่อ, ยังคงมองเห็นได้ด้วยค่าเดียวกัน. สไลด์ 3 คืนค่าการแสดงผลอัตโนมัติที่แสดงข้างต้น.

![ช่วงเวลาป้ายชื่อหมวดแบบกำหนดเองเป็นสามพร้อมคอลัมน์ 24 คอลัมน์ที่มองเห็นทั้งหมด](category-axis-manual.png)

### **เลือกแกนและช่วงเวลาที่ถูกต้อง**

ใช้ช่วงเวลานับจำนวนหมวดนี้สำหรับแกนหมวดหมู่แบบข้อความ, เช่น แกนหมวดของแผนภูมิคอลัมน์, เส้น, พื้นที่ หรือแผนภูมิแท่ง. ในแผนภูมิคอลัมน์, มันคือแกนแนวนอน. ในแผนภูมิแท่งแนวนอน, แกนหมวดอยู่แนวตั้ง, ดังนั้นให้ใช้การตั้งค่านี้กับแกนที่ได้จาก [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/). การจัดระยะเครื่องหมายแบ่งยังใช้ได้กับแกนชุดข้อมูลในแผนภูมิที่มีแกนชุดข้อมูล.

อย่าใช้การจัดระยะป้ายชื่อหมวดเพื่อกำหนดสเกลเชิงตัวเลขของแกนค่า. บนแกนค่า, [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) ระบุความแตกต่างของค่า: ตัวอย่างเช่น, หน่วยหลัก `10` จะสร้างเครื่องหมายที่ 0, 10, 20 ฯลฯ เมื่อแกนเริ่มที่ศูนย์. ช่วงเวลาป้ายชื่อหมวด `3` จะนับตำแหน่งหมวดโดยไม่คำนึงถึงค่าข้อมูล. แผนภูมิกระจายและฟองใช้แกนค่าแทนแกนหมวดข้อความ. สำหรับแกนวันที่, ใช้หน่วยหลักและสเกลตามเวลาแบบอธิบายใน [Change a Category Axis](#change-a-category-axis).

## **กำหนดรูปแบบวันที่สำหรับค่าของแกนหมวดหมู่**

ตัวอย่างนี้แทนที่ข้อมูลเริ่มต้นของแผนภูมิโดยค่าประจำปีสี่ค่า. วันที่ถูกเก็บเป็นเลขอนุกรม OLE Automation ในชีตแรก (ดัชนี `0`), คำนวณเป็นจำนวนวันตั้งแต่ 30 ธันวาคม 1899 สำหรับวันที่เหล่านี้. การคำนวณใน JavaScript ใช้ timestamp UTC และหารผลต่างด้วย 86,400,000 มิลลิวินาทีต่อวัน. ใช้ [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) กับ `CategoryAxisType.Date`, เรียก [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) ด้วย `false`, และส่ง `yyyy` ไปยัง [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) เพื่อให้ป้ายชื่อหมวดแสดงปีสี่หลักโดยอิสระจากการจัดรูปแบบเซลล์.

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

## **ตั้งค่ามุมการหมุนสำหรับหัวข้อแกนของแผนภูมิ**

เรียก [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settitle/) ด้วย `true` บนแกนแนวตั้ง, ให้ข้อความหัวข้อ, และใช้ [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setrotationangle/) เพื่อหมุนหัวข้อ. มุมวัดเป็นองศา; ตัวอย่างนี้บันทึกแผนภูมิคอลัมน์ที่หัวข้อแกนค่าถูกหมุน 90 องศา.

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

## **ตั้งค่าตำแหน่งแกนบนแกนหมวดหมู่หรือแกนค่า**

ใช้ [setAxisBetweenCategories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaxisbetweencategories/) เพื่อควบคุมว่าแกนค่าตัดแกนหมวดระหว่างหมวดหรือที่เครื่องหมายแบ่งหมวด. การตั้งค่านี้ใช้กับแกนหมวด. ตัวอย่างตั้งค่าเป็น `true` บนแกนหมวดแนวนอนของแผนภูมิคอลัมน์และบันทึกผลลัพธ์.

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

ใช้ [setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setdisplayunit/) เพื่อสเกลป้ายชื่อบนแกนค่าโดยไม่เปลี่ยนข้อมูลพื้นฐาน. เมื่อ [DisplayUnitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/displayunittype/) ตั้งเป็น `Millions`, ค่า 60,000,000 จะแสดงเป็น 60. ตัวอย่างสร้างแผนภูมิคอลัมน์และกำหนดหน่วยแสดงผลเป็นล้านบนแกนแนวตั้ง.

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

แกนค่าลอการิทึมมีประโยชน์เมื่อค่าบวกกระจายหลายระดับลำดับ. ตัวอย่างเช่น, บริการอาจรับ 10, 100, 1,000, 10,000, และ 100,000 คำขอในห้าช่วงเวลา. บนสเกลเชิงเส้น, ค่าขนาดเล็กจะอยู่ใกล้ศูนย์กัน. สเกลลอการิทึมทำให้การเติบโตสัมพัทธ์ง่ายต่อการเปรียบเทียบ: ระยะห่างที่เท่ากันแทนอัตราส่วนที่เท่ากันแทนความแตกต่างที่เท่ากัน.

เรียก [setLogarithmic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogarithmic/) ด้วย `true` บนแกนค่และใช้ [setLogBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogbase/) เพื่อเลือกฐาน. การทำเช่นนี้เปลี่ยนวิธีแสดงค่าที่มีอยู่; ไม่ได้เปลี่ยนข้อมูลหรือเพิ่มเส้นแนวโน้มลอการิทึม. เส้นแนวโน้มเป็นฟีเจอร์แยกต่างหากที่แสดงความสัมพันธ์ที่ฟิตกับข้อมูล.

### **เลือกแกนค่าและฐาน**

สำหรับแผนภูมิเส้นหรือคอลัมน์, แกนค่าจะได้จาก [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/). สำหรับแผนภูมิกระแท่งแนวนอน, จะได้จาก [getHorizontalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/gethorizontalaxis/). แผนภูมิกระจายและฟองมีแกนค่าสองแกน, ดังนั้นเลือกแกนแนวนอนสำหรับค่า X, แกนแนวตั้งสำหรับค่า Y, หรือทั้งสอง. อย่าใช้การสเกลลอการิทึมกับแกนหมวด.

ฐานลอการิทึมเริ่มต้นคือ `10`. สำหรับแผนภูมิ PPTX, สามารถใช้ฐานตั้งแต่ `2` ถึง `1000` (รวม), รวมถึงฐานเศษส่วนเช่น `2.5`. ด้วยฐาน `10`, พลังต่อเนื่องเช่น 10, 100, 1,000, และ 10,000 จะมีระยะห่างเท่ากัน.

### **เปรียบเทียบการสเกลเชิงเส้นและลอการิทึม**

ตัวอย่างอิสระต่อไปนี้สร้างแผนภูมิเส้นที่แสดงจำนวนคำขอห้าครั้งบนสไลด์แรก, จากนั้นคัดลอกสไลด์นั้นและเปิดใช้งานแกนค่าลอการิทึมฐาน 10 บนสไลด์ที่สอง. ทั้งสองสไลด์รักษาข้อมูลเดียวกัน.

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

    // คงสไลด์แรกเป็นเชิงเส้นและเปลี่ยนเฉพาะสเกลแกนค่าของสำเนา
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

**สเกลเชิงเส้น (สไลด์ 1):** ระยะแนวตั้งที่เท่ากันแทนความแตกต่างที่เท่ากันของจำนวนคำขอ. ค่าที่ใหญ่ที่สุดครอบงำแผนภูมิ, ทำให้ค่าที่เล็กกว่าแยกแยะได้ยาก.

![แผนภูมิเส้นใน PowerPoint แสดงจำนวนการร้องขอห้าครั้งบนแกนค่าที่เป็นเชิงเส้น](value-axis-linear.png)

**สเกลลอการิทึม (สไลด์ 2):** ระยะแนวตั้งที่เท่ากันแทนอัตราส่วนที่เท่ากัน. แต่ละช่วงมีจำนวนคำขอเพิ่มขึ้นสิบเท่า, ดังนั้นจุดจะเป็นเส้นตรงที่ขึ้นบนสเกลฐาน 10. ป้ายแกนยังแสดงจำนวนคำขอเดิม.

![จำนวนการร้องขอห้าครั้งเดียวกันใน PowerPoint บนแกนค่าลอการิทึมฐาน 10](value-axis-logarithmic.png)

### **จัดการค่าศูนย์และค่าติดลบ**

สเกลลอการิทึมสามารถแสดงได้เฉพาะค่าบวกที่แน่นอน. ตรวจสอบข้อมูลก่อนเปิดใช้งาน. หากค่าศูนย์หรือค่าติดลบมีความหมาย, ควรใช้สเกลเชิงเส้นหรือแสดงแยกต่างหาก. หากการยกเว้นค่าดังกล่าวเหมาะสมต่อการวิเคราะห์, ให้อธิบายเหตุผล. อย่าแทนที่ค่าดังกล่าวด้วยจำนวนบวกเล็ก ๆ อย่างเงียบ เนื่องจากจะเปลี่ยนความหมายของข้อมูล. ค่าต่ำสุดหรือสูงสุดที่กำหนดด้วยตนเองสำหรับแกนลอการิทึมต้องเป็นบวกเช่นกัน.

## **คำถามที่พบบ่อย**

**ฉันจะตั้งค่าที่แกนหนึ่งตัดกับอีกแกนได้อย่างไร (การตัดแกน)?**

ใช้ [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) เพื่อเลือกพฤติกรรมการตัด. หากต้องการระบุค่าตัดเชิงตัวเลข, ใช้ [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/). การตั้งค่าเหล่านี้ทำให้คุณย้ายตำแหน่งการตัดแกนไปยังฐานที่เหมาะสม.

**ฉันจะกำหนดตำแหน่งป้ายกำกับเครื่องหมายแบ่งสัมพันธ์กับแกนได้อย่างไร?**

เรียก [setTickLabelPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelposition/) โดยใช้ [TickLabelPositionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo`, หรือ `None`. เพื่อควบคุมเครื่องหมายแบ่งเอง, ใช้ [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) หรือ [setMinorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setminortickmark/); สิ่งเหล่านี้แยกจากการจัดตำแหน่งป้าย.