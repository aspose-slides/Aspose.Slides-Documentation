---
title: จัดการ Callout ในแผนภูมิการนำเสนอโดยใช้ JavaScript
linktitle: Callout
type: docs
url: /th/nodejs-java/callout/
keywords:
- callout แผนภูมิ
- ใช้ callout
- ป้ายข้อมูล
- รูปแบบป้าย
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "สร้างและตกแต่ง callout ใน Aspose.Slides สำหรับ Node.js ผ่าน Java ด้วยตัวอย่างโค้ดสั้น ๆ ที่เข้ากันได้กับ PPT และ PPTX เพื่ออัตโนมัติกระบวนการทำงานของการนำเสนอ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับ callout สำหรับป้ายกำกับข้อมูลของแผนภูมิใน Aspose.Slides โดยแสดงวิธีใช้เมธอด `setShowLabelAsDataCallout` เพื่อแสดงป้ายกำกับเป็น callout วิธีกำหนดค่าการตั้งค่าป้ายกำกับที่เกี่ยวข้องกับ callout สำหรับแผนภูมิ doughnut และระบุว่า callout และลักษณะของมันจะยังคงอยู่เมื่อการนำเสนอถูกส่งออกเป็น PDF, HTML5, SVG และรูปแบบภาพ raster

## **การใช้ Callout**

มีเมธอดใหม่ [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/DataLabelFormat#getShowLabelAsDataCallout--) และ [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/DataLabelFormat#setShowLabelAsDataCallout-boolean-) ถูกเพิ่มเข้าไปในคลาส [DataLabelFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/datalabelformat) และ [DataLabelFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/datalabelformat) เมธอดเหล่านี้กำหนดว่าป้ายกำกับข้อมูลของแผนภูมิที่ระบุจะถูกแสดงเป็น data callout หรือเป็นป้ายกำกับข้อมูล

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 500, 400);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowLabelAsDataCallout(true);
    chart.getChartData().getSeries().get_Item(0).getLabels().get_Item(2).getDataLabelFormat().setShowLabelAsDataCallout(false);
    pres.save("DisplayCharts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ตั้งค่า Callout สำหรับแผนภูมิ Doughnut**

Aspose.Slides for Node.js via Java มีการสนับสนุนการตั้งค่ารูปแบบ callout ของป้ายกำกับข้อมูลซีรีส์สำหรับแผนภูมิ Doughnut ตัวอย่างโค้ดด้านล่างนี้แสดงให้เห็น

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Doughnut, 10, 10, 500, 500, false);
    var workBook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(false);
    var seriesIndex = 0;
    while (seriesIndex < 15) {
        var series = chart.getChartData().getSeries().add(workBook.getCell(0, 0, seriesIndex + 1, "SERIES " + seriesIndex), chart.getType());
        series.setExplosion(0);
        series.getParentSeriesGroup().setDoughnutHoleSize(20);
        series.getParentSeriesGroup().setFirstSliceAngle(351);
        seriesIndex++;
    }
    var categoryIndex = 0;
    while (categoryIndex < 15) {
        chart.getChartData().getCategories().add(workBook.getCell(0, categoryIndex + 1, 0, "CATEGORY " + categoryIndex));
        var i = 0;
        while (i < chart.getChartData().getSeries().size()) {
            var iCS = chart.getChartData().getSeries().get_Item(i);
            var dataPoint = iCS.getDataPoints().addDataPointForDoughnutSeries(workBook.getCell(0, categoryIndex + 1, i + 1, 1));
            dataPoint.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
            dataPoint.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            dataPoint.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
            dataPoint.getFormat().getLine().setWidth(1);
            dataPoint.getFormat().getLine().setStyle(aspose.slides.LineStyle.Single);
            dataPoint.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Solid);
            if (i == (chart.getChartData().getSeries().size() - 1)) {
                var lbl = dataPoint.getLabel();
                lbl.getTextFormat().getTextBlockFormat().setAutofitType(aspose.slides.TextAutofitType.Shape);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setLatinFont(new aspose.slides.FontData("DINPro-Bold"));
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(12);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
                lbl.getDataLabelFormat().getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
                lbl.getDataLabelFormat().setShowValue(false);
                lbl.getDataLabelFormat().setShowCategoryName(true);
                lbl.getDataLabelFormat().setShowSeriesName(false);
                lbl.getDataLabelFormat().setShowLeaderLines(true);
                lbl.getDataLabelFormat().setShowLabelAsDataCallout(false);
                chart.validateChartLayout();
                lbl.setX(lbl.getX() + 0.5);
                lbl.setY(lbl.getY() + 0.5);
            }
            i++;
        }
        categoryIndex++;
    }
    pres.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **คำถามที่พบบ่อย**

**Callout จะยังคงอยู่หรือไม่เมื่อแปลงงานนำเสนอเป็น PDF, HTML5, SVG หรือรูปภาพ?**

ใช่. Callout เป็นส่วนหนึ่งของการเรนเดอร์แผนภูมิ ดังนั้นเมื่อคุณส่งออกเป็น [PDF](/slides/th/nodejs-java/convert-powerpoint-to-pdf/), [HTML5](/slides/th/nodejs-java/export-to-html5/), [SVG](/slides/th/nodejs-java/render-a-slide-as-an-svg-image/), หรือ [raster images](/slides/th/nodejs-java/convert-powerpoint-to-png/) พวกมันจะยังคงอยู่พร้อมกับการจัดรูปแบบของสไลด์

**ฟอนต์แบบกำหนดเองทำงานใน Callout หรือไม่ และลักษณะของมันสามารถคงเดิมเมื่อส่งออกได้หรือไม่?**

ใช่. Aspose.Slides รองรับการ [embedding fonts](/slides/th/nodejs-java/embedded-font/) เข้าไปในงานนำเสนอและควบคุมการฝังฟอนต์ในการส่งออก เช่น [PDF](/slides/th/nodejs-java/convert-powerpoint-to-pdf/) เพื่อให้ Callout มีลักษณะเดียวกันในระบบต่าง ๆ