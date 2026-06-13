---
title: จัดการ Callouts ในแผนภูมิการนำเสนอโดยใช้ Java
linktitle: การเชื่อมต่อ
type: docs
url: /th/java/callout/
keywords:
- การเชื่อมต่อแผนภูมิ
- ใช้การเชื่อมต่อ
- ป้ายข้อมูล
- รูปแบบป้าย
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "สร้างและกำหนดรูปแบบการเชื่อมต่อใน Aspose.Slides สำหรับ Java ด้วยตัวอย่างโค้ดสั้น ๆ รองรับไฟล์ PPT และ PPTX เพื่อทำงานอัตโนมัติในกระบวนการนำเสนอ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับการเชื่อมต่อสำหรับป้ายข้อมูลของแผนภูมิใน Aspose.Slides แสดงวิธีใช้เมธอด `setShowLabelAsDataCallout` เพื่อแสดงป้ายเป็นการเชื่อมต่อ วิธีกำหนดค่าการตั้งค่าป้ายที่เกี่ยวข้องกับการเชื่อมต่อสำหรับแผนภูมิโดนัท และระบุว่าการเชื่อมต่อและลักษณะของมันจะถูกเก็บรักษาไว้เมื่อการนำเสนอถูกส่งออกเป็น PDF, HTML5, SVG และรูปแบบภาพเรสเตอร์

## **การใช้งาน Callouts**
เมธอดใหม่ [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/th/java/com.aspose.slides/IDataLabelFormat#getShowLabelAsDataCallout--) และ [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/th/java/com.aspose.slides/IDataLabelFormat#setShowLabelAsDataCallout-boolean-) ได้ถูกเพิ่มไปยังคลาส [DataLabelFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/datalabelformat) และอินเทอร์เฟซ [IDataLabelFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/idatalabelformat) เมธอดเหล่านี้กำหนดว่าจะให้ป้ายข้อมูลของแผนภูมิที่ระบุแสดงเป็นการเชื่อมต่อข้อมูลหรือเป็นป้ายข้อมูลปกติ

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 500, 400);
    
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowLabelAsDataCallout(true);
    chart.getChartData().getSeries().get_Item(0).getLabels().get_Item(2).getDataLabelFormat().setShowLabelAsDataCallout(false);
    
    pres.save("DisplayCharts.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ตั้งค่า Callout สำหรับแผนภูมิ Doughnut**
Aspose.Slides for Java ให้การสนับสนุนการตั้งค่ารูปร่างการเชื่อมต่อของป้ายข้อมูลชุดสำหรับแผนภูมิโดนัท ตัวอย่างโค้ดด้านล่างนี้ได้ถูกจัดเตรียมไว้

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.Doughnut, 10, 10, 500, 500, false);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(false);
    int seriesIndex = 0;
    while (seriesIndex < 15)
    {
        IChartSeries series = chart.getChartData().getSeries().add(workBook.getCell(0, 0, seriesIndex + 1, "SERIES " + seriesIndex), chart.getType());
        series.setExplosion(0);
        series.getParentSeriesGroup().setDoughnutHoleSize((byte)20);
        series.getParentSeriesGroup().setFirstSliceAngle(351);
        seriesIndex++;
    }
    int categoryIndex = 0;
    while (categoryIndex < 15)
    {
        chart.getChartData().getCategories().add(workBook.getCell(0, categoryIndex + 1, 0, "CATEGORY " + categoryIndex));
        int i = 0;
        while (i < chart.getChartData().getSeries().size())
        {
            IChartSeries iCS = chart.getChartData().getSeries().get_Item(i);
            IChartDataPoint dataPoint = iCS.getDataPoints().addDataPointForDoughnutSeries(workBook.getCell(0, categoryIndex + 1, i + 1, 1));
            dataPoint.getFormat().getFill().setFillType(FillType.Solid);
            dataPoint.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
            dataPoint.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.awt.Color.WHITE);
            dataPoint.getFormat().getLine().setWidth(1);
            dataPoint.getFormat().getLine().setStyle(LineStyle.Single);
            dataPoint.getFormat().getLine().setDashStyle(LineDashStyle.Solid);
            if (i == chart.getChartData().getSeries().size() - 1)
            {
                IDataLabel lbl = dataPoint.getLabel();
                lbl.getTextFormat().getTextBlockFormat().setAutofitType(TextAutofitType.Shape);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setFontBold(NullableBool.True);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setLatinFont(new FontData("DINPro-Bold"));
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(12);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.awt.Color.LIGHT_GRAY);
                lbl.getDataLabelFormat().getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.awt.Color.WHITE);
                lbl.getDataLabelFormat().setShowValue(false);
                lbl.getDataLabelFormat().setShowCategoryName(true);
                lbl.getDataLabelFormat().setShowSeriesName(false);
                lbl.getDataLabelFormat().setShowLeaderLines(true);
                lbl.getDataLabelFormat().setShowLabelAsDataCallout(false);
                chart.validateChartLayout();
                lbl.setX((float) lbl.getX()+ (float)0.5);
                lbl.setY((float)lbl.getY()+ (float)0.5);
            }
            i++;
        }
        categoryIndex++;
    }
    pres.save("chart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**การเชื่อมต่อจะถูกเก็บรักษาไว้เมื่อแปลงการนำเสนอเป็น PDF, HTML5, SVG หรือภาพหรือไม่?**

ใช่ การเชื่อมต่อเป็นส่วนหนึ่งของการแสดงผลแผนภูมิ ดังนั้นเมื่อคุณส่งออกเป็น [PDF](/slides/th/java/convert-powerpoint-to-pdf/), [HTML5](/slides/th/java/export-to-html5/), [SVG](/slides/th/java/render-a-slide-as-an-svg-image/), หรือ [raster images](/slides/th/java/convert-powerpoint-to-png/), พวกมันจะถูกเก็บรักษาพร้อมกับการจัดรูปแบบของสไลด์

**ฟอนต์ที่กำหนดเองทำงานในการเชื่อมต่อหรือไม่ และลักษณะของมันสามารถถูกเก็บรักษาไว้เมื่อส่งออกได้หรือไม่?**

ใช่ Aspose.Slides รองรับการ [embedding fonts](/slides/th/java/embedded-font/) ในการนำเสนอและควบคุมการฝังฟอนต์ระหว่างการส่งออก เช่น [PDF](/slides/th/java/convert-powerpoint-to-pdf/), ทำให้การเชื่อมต่อแสดงผลเดียวกันในระบบต่าง ๆ