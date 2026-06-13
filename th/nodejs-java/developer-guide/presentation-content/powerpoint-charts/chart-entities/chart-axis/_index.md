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
- ควบคุมแกน
- คุณสมบัติของแกน
- ค่าสูงสุด
- ค่าต่ำสุด
- เส้นแกน
- รูปแบบวันที่
- ชื่อแกน
- ตำแหน่งแกน
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ค้นพบวิธีใช้ JavaScript ร่วมกับ Aspose.Slides สำหรับ Node.js ผ่าน Java เพื่อปรับแต่งแกนแผนภูมิในงานนำเสนอ PowerPoint สำหรับรายงานและการสร้างภาพเชิงสถิติ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการปรับแต่งแกนแผนภูมิใน Aspose.Slides โดยจะแสดงวิธีการรับค่าจริงของแกน, สลับข้อมูลระหว่างแกน, ซ่อนแกนแนวตั้งหรือแนวนอนสำหรับแผนภูมิเส้น, เปลี่ยนประเภทแกนหมวดหมู่, ตั้งรูปแบบวันที่สำหรับค่าของแกนหมวดหมู่, หมุนชื่อแกน, ตั้งตำแหน่งแกน, และแสดงป้ายหน่วยบนแกนค่า.

## **การรับค่ามากที่สุดบนแกนแนวตั้งในแผนภูมิ**

Aspose.Slides for Node.js ผ่าน Java ให้คุณรับค่าต่ำสุดและสูงสุดบนแกนแนวตั้ง ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) class.
2. เข้าถึงสไลด์แรก.
3. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้น.
4. รับค่ามากที่สุดจริงบนแกน.
5. รับค่าต่ำที่สุดจริงบนแกน.
6. รับหน่วยหลักจริงของแกน.
7. รับหน่วยรองจริงของแกน.
8. รับสเกลหน่วยหลักจริงของแกน.
9. รับสเกลหน่วยรองจริงของแกน.

โค้ดตัวอย่างนี้—การดำเนินการตามขั้นตอนข้างต้น—จะแสดงวิธีการรับค่าที่ต้องการใน JavaScript:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    var majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
    // บันทึกงานนำเสนอ
    pres.save("MaxValuesVerticalAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **การสลับข้อมูลระหว่างแกน**

Aspose.Slides ให้คุณสลับข้อมูลระหว่างแกนอย่างรวดเร็ว—ข้อมูลที่แสดงบนแกนแนวตั้ง (y-axis) จะย้ายไปยังแกนแนวนอน (x-axis) และกลับกัน.

โค้ด JavaScript นี้จะแสดงวิธีการทำงานสลับข้อมูลระหว่างแกนบนแผนภูมิ:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    // สลับแถวและคอลัมน์
    chart.getChartData().switchRowColumn();
    // บันทึกงานนำเสนอ
    pres.save("SwitchChartRowColumns_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **การปิดการใช้งานแกนแนวตั้งสำหรับแผนภูมิเส้น**

โค้ด JavaScript นี้จะแสดงวิธีการซ่อนแกนแนวตั้งสำหรับแผนภูมิเส้น:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);
    pres.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **การปิดการใช้งานแกนแนวนอนสำหรับแผนภูมิเส้น**

โค้ดนี้จะแสดงวิธีการซ่อนแกนแนวนอนสำหรับแผนภูมิเส้น:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);
    pres.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **การเปลี่ยนแกนหมวดหมู่**

โดยใช้คุณสมบัติ **CategoryAxisType** คุณสามารถระบุประเภทของแกนหมวดหมู่ที่ต้องการ (**date** หรือ **text**) โค้ดนี้ใน JavaScript จะสาธิตการดำเนินการ:

```javascript
var presentation = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(aspose.slides.TimeUnitType.Months);
    presentation.save("ChangeChartCategoryAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **การตั้งค่ารูปแบบวันที่สำหรับค่าของแกนหมวดหมู่**

Aspose.Slides for Node.js ผ่าน Java ให้คุณตั้งค่ารูปแบบวันที่สำหรับค่าของแกนหมวดหมู่ การดำเนินการแสดงในโค้ด JavaScript นี้:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 50, 50, 450, 300);
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", convertToOADate(java.newInstanceSync("GregorianCalendar", 2015, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", convertToOADate(java.newInstanceSync("GregorianCalendar", 2016, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", convertToOADate(java.newInstanceSync("GregorianCalendar", 2017, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", convertToOADate(java.newInstanceSync("GregorianCalendar", 2018, 1, 1))));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B2", 1));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B3", 2));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B4", 3));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B5", 4));
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
```javascript
const dayjs = require('dayjs');

function convertToOADate(date) {
    const baseDate = dayjs('1899-12-30');

    const days = date.diff(baseDate, 'day');

    const fractionalDay = (date.hour() / 24) +
                          (date.minute() / (60 * 24)) +
                          (date.second() / (60 * 24 * 60));

    const oaDate = days + fractionalDay;

    return String(oaDate);
}
```

## **การตั้งค่ามุมการหมุนสำหรับชื่อแกนแผนภูมิ**

Aspose.Slides for Node.js ผ่าน Java ให้คุณตั้งค่ามุมการหมุนสำหรับชื่อแกนแผนภูมิ โค้ด JavaScript นี้จะแสดงการดำเนินการ:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **การตั้งค่าตำแหน่งแกนในแกนหมวดหมู่หรือแกนค่า**

Aspose.Slides for Node.js ผ่าน Java ให้คุณตั้งค่าตำแหน่งแกนในแกนหมวดหมู่หรือแกนค่า โค้ด JavaScript นี้แสดงวิธีทำงานนี้:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **การเปิดใช้งานป้ายหน่วยการแสดงผลบนแกนค่าของแผนภูมิ**

Aspose.Slides for Node.js ผ่าน Java ให้คุณกำหนดค่าแผนภูมิให้แสดงป้ายหน่วยบนแกนค่าของแผนภูมิ โค้ด JavaScript นี้จะแสดงการดำเนินการ:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Millions);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **คำถามที่พบบ่อย**

**ฉันจะตั้งค่าค่าที่แกนหนึ่งตัดแกนอีก (axis crossing) อย่างไร?**

แกนต่างๆ มี [การตั้งค่าการตัดแกน](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/axis/setcrosstype/) ซึ่งคุณสามารถเลือกให้ตัดที่ศูนย์, ที่ค่าหมวดหมู่/ค่ามากสุด, หรือที่ค่าตัวเลขเฉพาะ การตั้งค่านี้มีประโยชน์ในการย้ายแกน X ขึ้นหรือลงหรือเพื่อเน้นเส้นฐาน.

**ฉันจะจัดตำแหน่งป้าย Tick ให้สัมพันธ์กับแกน (ข้างเคียง, ภายนอก, ภายใน) อย่างไร?**

ตั้งค่า [ตำแหน่งป้าย](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/axis/setmajortickmark/) เป็น "cross", "outside" หรือ "inside" การตั้งค่านี้มีผลต่อการอ่านและช่วยประหยัดพื้นที่ โดยเฉพาะในแผนภูมิขนาดเล็ก.