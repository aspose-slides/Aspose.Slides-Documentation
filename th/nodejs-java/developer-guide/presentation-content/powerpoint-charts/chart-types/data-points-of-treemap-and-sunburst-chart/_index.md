---
title: ปรับแต่งจุดข้อมูลในแผนภูมิ Treemap และ Sunburst ด้วย JavaScript
linktitle: จุดข้อมูลในแผนภูมิ Treemap และ Sunburst
type: docs
url: /th/nodejs-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- แผนภูมิ treemap
- แผนภูมิ sunburst
- จุดข้อมูล
- สีป้าย
- สีสาขา
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีจัดการจุดข้อมูลในแผนภูมิ treemap และ sunburst ด้วย JavaScript และ Aspose.Slides สำหรับ Node.js ผ่าน Java ซึ่งรองรับรูปแบบไฟล์ PowerPoint"
---
## **บทนำ**

ในหมวดอื่นของแผนภูมิ PowerPoint มีประเภท “เชิงลำดับชั้น” สองประเภท คือแผนภูมิ **Treemap** และ **Sunburst** (ที่เรียกอีกอย่างว่า Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph หรือ Multi Level Pie Chart) แผนภูมิเหล่านี้แสดงข้อมูลเชิงลำดับชั้นที่จัดเรียงเป็นต้นไม้ ตั้งแต่ใบไม้จนถึงยอดกิ่ง ใบไม้ถูกกำหนดโดยจุดข้อมูลของซีรีส์ และแต่ละระดับการจัดกลุ่มซ้อนกันต่อไปถูกกำหนดโดยประเภทที่สอดคล้อง Aspose.Slides for Node.js ผ่าน Java ช่วยให้สามารถจัดรูปแบบจุดข้อมูลของแผนภูมิ Sunburst และ Treemap ด้วย JavaScript ได้

นี่คือแผนภูมิ Sunburst ซึ่งข้อมูลในคอลัมน์ Series1 กำหนดโนด leaf ส่วนคอลัมน์อื่นกำหนดจุดข้อมูลเชิงลำดับชั้น:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

เริ่มต้นด้วยการเพิ่มแผนภูมิ Sunburst ใหม่ลงในงานนำเสนอ:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    // ...
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" title="ดูเพิ่มเติม" %}} 
- [**Create or Update PowerPoint Presentation Charts in JavaScript**](/slides/th/nodejs-java/create-chart/)
{{% /alert %}}

หากต้องการจัดรูปแบบจุดข้อมูลของแผนภูมิ เราควรใช้สิ่งต่อไปนี้:

[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartDataPointLevelsManager), 
[ChartDataPointLevel](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartDataPointLevel) classes 
and [**ChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartDataPoint#getDataPointLevels--) method 
provide access to format data points of Treemap and Sunburst charts. 
[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartDataPointLevelsManager)
is used for accessing multi-level categories - it represents the container of 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartDataPointLevel) objects.
Basically it is a wrapper for 
[**ChartCategoryLevelsManager**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartCategoryLevelsManager) with
the properties added specific for data points. 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartDataPointLevel) class has
two methods: [**getFormat**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartDataPointLevel#getFormat--) and 
[**getDataLabel**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartDataPointLevel#getLabel--) which
provide access to corresponding settings.

## **แสดงค่าจุดข้อมูล**
แสดงค่าของจุดข้อมูล “Leaf 4”:

```javascript
var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **ตั้งค่าป้ายและสีจุดข้อมูล**
ตั้งค่าป้ายข้อมูล “Branch 1” ให้แสดงชื่อซีรีส์ (“Series1”) แทนชื่อประเภท จากนั้นตั้งค่าสีข้อความเป็นสีเหลือง:

```javascript
var branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **ตั้งค่าสีสาขาจุดข้อมูล**
เปลี่ยนสีของสาขา “Steam 4”:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
    var stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);
    stem4branch.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **คำถามที่พบบ่อย**

**Can I change the order (sorting) of segments in Sunburst/Treemap?**

No. PowerPoint sorts segments automatically (typically by descending values, clockwise). Aspose.Slides mirrors this behavior: you can’t change the order directly; you achieve it by preprocessing the data.

**How does the presentation theme affect the colors of segments and labels?**

Chart colors inherit the presentation’s [theme/palette](/slides/th/nodejs-java/presentation-theme/) unless you explicitly set fills/fonts. For consistent results, lock in solid fills and text formatting at the required levels.

**Will export to PDF/PNG preserve custom branch colors and label settings?**

Yes. When exporting the presentation, chart settings (fills, labels) are preserved in the output formats because Aspose.Slides renders with the chart’s formatting applied.

**Can I compute the actual coordinates of a label/element for custom overlay placement on top of the chart?**

Yes. After the chart layout is validated, actual X and actual Y are available for elements (for example, a [DataLabel](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/datalabel/)), which helps with precise positioning of overlays.