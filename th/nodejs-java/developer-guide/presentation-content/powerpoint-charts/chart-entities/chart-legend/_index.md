---
title: ปรับแต่งคำนำแผนภูมิในงานนำเสนอด้วย JavaScript
linktitle: คำนำแผนภูมิ
type: docs
url: /th/nodejs-java/chart-legend/
keywords:
- คำนำแผนภูมิ
- ตำแหน่งคำนำ
- ขนาดตัวอักษร
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ปรับแต่งคำนำแผนภูมิด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java เพื่อเพิ่มประสิทธิภาพงานนำเสนอ PowerPoint ด้วยการจัดรูปแบบคำนำที่กำหนดเอง"
---
## **ภาพรวม**

Aspose.Slides for Node.js via Java มีตัวเลือกสำหรับการปรับแต่งคำนำของแผนภูมิในงานนำเสนอ PowerPoint บทความนี้แสดงวิธีกำหนดตำแหน่งและขนาดของคำนำ การตั้งค่าขนาดตัวอักษรสำหรับคำนำทั้งหมด การจัดรูปแบบรายการคำนำแต่ละรายการ และการซ่อนหรือคืนค่ารายการที่เลือก

FAQ ครอบคลุมพฤติกรรมที่เกี่ยวข้อง รวมถึงการสำรองพื้นที่ให้คำนำ การแสดงป้ายกำกับหลายบรรทัด และการสืบทอดการจัดรูปแบบจากธีมของงานนำเสนอ

## **การจัดตำแหน่งคำนำ**

ใช้เมธอดของคำนำ [setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setx/), [setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/sety/), [setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setwidth/) และ [setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setheight/) เพื่อกำหนดตำแหน่งและขนาดของคำนำเป็นอัตราส่วนของมิติของแผนภูมิ

ตัวอย่างนี้สร้างงานนำเสนอและเพิ่มแผนภูมิดิ่งกลุ่มที่มีข้อมูลค่าเริ่มต้นลงในสไลด์แรก การหารค่าการเลื่อนและขนาดของคำนำที่ต้องการด้วยความกว้างและความสูงของแผนภูมิจะทำให้เป็นค่าตามสัดส่วน: คำนำถูกเลื่อน 50 จุดจากมุมบนซ้ายของแผนภูมิและมีขนาด 100 × 100 จุด

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 500);

    // ระบุตำแหน่งและขนาดของคำนำสัมพันธ์กับแผนภูมิ
    chart.getLegend().setX(java.newFloat(50 / chart.getWidth()));
    chart.getLegend().setY(java.newFloat(50 / chart.getHeight()));
    chart.getLegend().setWidth(java.newFloat(100 / chart.getWidth()));
    chart.getLegend().setHeight(java.newFloat(100 / chart.getHeight()));

    presentation.save("legend_position.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าขนาดตัวอักษรของคำนำ**

ใช้ [getTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/gettextformat/) ของคำนำเพื่อเข้าถึงการจัดรูปแบบข้อความและใช้ [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) เพื่อตั้งค่าขนาดตัวอักษรเป็นจุด

ตัวอย่างนี้สร้างแผนภูมิด้วยข้อมูลค่าเริ่มต้นและตั้งค่าขนาดข้อความคำนำเป็น 20 จุด นอกจากนี้ยังปิดการกำหนดขอบอัตโนมัติสำหรับแกนตั้งและตั้งช่วงค่าจาก -5 ถึง 10

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    presentation.save("legend_font_size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าขนาดตัวอักษรของรายการคำนำแบบแยกส่วน**

ใช้คอลเลกชันที่คืนจากเมธอด [getEntries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/getentries/) ของคำนำเพื่อเข้าถึงการจัดรูปแบบของรายการเฉพาะ ดัชนีของรายการเริ่มจากศูนย์ ดังนั้นดัชนี `1` หมายถึงรายการที่สอง

ตัวอย่างนี้สร้างแผนภูมิดิ่งกลุ่มที่ข้อมูลค่าเริ่มต้นมีอย่างน้อยสองชุดข้อมูล มันจัดรูปแบบรายการคำนำที่สองให้เป็นตัวหนา ตัวเอียง และข้อความสีฟ้า 20 จุด

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var textFormat = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    textFormat.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    textFormat.getPortionFormat().setFontHeight(20);
    textFormat.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    textFormat.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    var blue = java.getStaticFieldValue("java.awt.Color", "BLUE");
    textFormat.getPortionFormat().getFillFormat().getSolidFillColor().setColor(blue);

    presentation.save("legend_entry_format.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ซ่อนรายการคำนำแบบแยกส่วน**

เพื่อไม่ให้ชุดข้อมูลเสริมแสดงในคำนำขณะยังคงแสดงข้อมูลอยู่ ให้เรียก [LegendEntryProperties.setHide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legendentryproperties/sethide/) ด้วยค่า `true` ผ่าน [ChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getrelatedlegendentry/) วิธีนี้จะซ่อนเฉพาะรายการคำนำที่เลือก ไม่ได้ลบชุดข้อมูลหรือจุดข้อมูลออก การเรียก [Chart.setLegend](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setlegend/) ด้วยค่า `false` ในทางกลับกันจะซ่อนคำนำทั้งหมด

ตัวอย่างด้านล่างสร้างแผนภูมิดิ่งกลุ่มที่มีหลายชุดข้อมูลโดยใช้ข้อมูลค่าเริ่มต้น มันซ่อนรายการคำนำของชุดข้อมูลที่สอง (ดัชนี `1`) แล้วบันทึกงานนำเสนอ จากนั้นคืนค่ารายการโดยเรียก [setHide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legendentryproperties/sethide/) ด้วยค่า `false` และบันทึกสำเนาที่สอง คอลัมน์ยังคงแสดงในทั้งสองไฟล์

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(true);

    var legendEntry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry();

    legendEntry.setHide(true);
    presentation.save("hidden_legend_entry.pptx", aspose.slides.SaveFormat.Pptx);

    // กู้คืนรายการเดิมโดยไม่เปลี่ยนแปลงข้อมูลแผนภูมิ
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การเปรียบเทียบด้านล่างแสดงแผนภูมิเดียวกันที่รายการทั้งหมดแสดงและรายการที่สองถูกซ่อน คอลัมน์ของชุดข้อมูลที่สองยังคงไม่เปลี่ยนแปลง

![เปรียบเทียบแผนภูมิที่มีรายการคำนำทั้งหมดแสดงและรายการที่สองถูกซ่อน; คอลัมน์ทั้งหมดยังคงแสดง](hide-legend-entry.png)

ในแผนภูมิคอลัมน์, แถบ, และเส้น, รายการคำนำระบุชุดข้อมูล ส่วนในแผนภูมิพายจะระบุจุดข้อมูลแต่ละจุด (ส่วน), ดังนั้นให้ใช้ [ChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getrelatedlegendentry/) กับส่วนที่เลือก API เอกสารวิธีนี้สำหรับประเภทแผนภูมิ `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` และ `BarOfPie` อย่าสมมติว่าใช้ได้กับแผนภูมิดอนัท ซึ่งไม่ได้อยู่ในรายการนั้น

## **FAQ**

**ฉันสามารถทำให้แผนภูมิสำรองพื้นที่ให้คำนำแทนการทับซ้อนได้หรือไม่?**

ได้ ให้เรียก [setOverlay](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setoverlay/) ด้วยค่า `false` เพื่อสำรองพื้นที่ให้คำนำแทนการให้ทับบริเวณแผนภูมิ

**ฉันสามารถทำให้ป้ายกำกับคำนำเป็นหลายบรรทัดได้หรือไม่?**

ได้ ป้ายกำกับยาวสามารถตัดบรรทัดได้เมื่อความกว้างที่ใช้ได้ไม่เพียงพอ คุณยังสามารถใช้อักขระขึ้นบรรทัดใหม่ในชื่อชุดข้อมูลเพื่อขอให้ตัดบรรทัด

**ฉันจะทำให้คำนำสืบทอดโทนสีจากธีมของงานนำเสนอได้อย่างไร?**

ปล่อยให้สี, การเติมสี, และแบบอักษรของคำนำไม่ได้กำหนดค่า เพื่อให้คำนำสืบทอดการจัดรูปแบบจากธีม การจัดรูปแบบอย่างชัดเจนจะลบการตั้งค่าของธีมที่สอดคล้องกันออก