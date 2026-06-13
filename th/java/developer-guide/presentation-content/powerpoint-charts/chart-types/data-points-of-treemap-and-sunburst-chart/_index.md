---
title: ปรับแต่งจุดข้อมูลในแผนภูมิ Treemap และ Sunburst ด้วย Java
linktitle: จุดข้อมูลในแผนภูมิ Treemap และ Sunburst
type: docs
url: /th/java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- แผนภูมิ treemap
- แผนภูมิ sunburst
- จุดข้อมูล
- สีป้าย
- สีสาขา
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีการจัดการจุดข้อมูลในแผนภูมิ treemap และ sunburst ด้วย Aspose.Slides สำหรับ Java ที่รองรับรูปแบบของ PowerPoint."
---
## **การแนะนำ**

นอกเหนือจากประเภทแผนภูมิ PowerPoint อื่น ๆ มีสองประเภท “เชิงลำดับขั้น” คือแผนภูมิ **Treemap** และแผนภูมิ **Sunburst** (ที่รู้จักกันในชื่อ Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph หรือ Multi Level Pie Chart) แผนภูมิเหล่านี้แสดงข้อมูลเชิงลำดับขั้นที่จัดระเบียบเป็นต้นไม้ – จากใบไม้ไปยังยอดของกิ่ง ใบไม้ถูกกำหนดโดยจุดข้อมูลของ series และแต่ละระดับการจัดกลุ่มที่ซ้อนกันต่อมาถูกกำหนดโดยหมวดหมู่ที่สอดคล้องกัน Aspose.Slides for Java ให้คุณจัดรูปแบบจุดข้อมูลของแผนภูมิ Sunburst และ Treemap ด้วย Java

นี่คือแผนภูมิ Sunburst ที่ข้อมูลในคอลัมน์ Series1 กำหนดโนดใบไม้ ส่วนคอลัมน์อื่น ๆ กำหนดจุดข้อมูลเชิงลำดับขั้น:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

เริ่มต้นด้วยการเพิ่มแผนภูมิ Sunburst ใหม​้เข้าไปในงานนำเสนอ:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" title="See also" %}} 
- [**สร้างหรืออัปเดตแผนภูมิ PowerPoint ด้วย Java**](/slides/th/java/create-chart/)
{{% /alert %}}

หากต้องการจัดรูปแบบจุดข้อมูลของแผนภูมิ เราควรใช้สิ่งต่อไปนี้:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/th/java/com.aspose.slides/IChartDataPointLevelsManager), 
[IChartDataPointLevel](https://reference.aspose.com/slides/th/java/com.aspose.slides/IChartDataPointLevel) class 
และ [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/th/java/com.aspose.slides/IChartDataPoint#getDataPointLevels--) method 
ให้การเข้าถึงการจัดรูปแบบจุดข้อมูลของแผนภูมิ Treemap และ Sunburst. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/th/java/com.aspose.slides/IChartDataPointLevelsManager) 
ใช้สำหรับเข้าถึงหมวดหมู่หลายระดับ – มันเป็นคอนเทนเนอร์ของ 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/th/java/com.aspose.slides/IChartDataPointLevel) objects. 
โดยพื้นฐานแล้วเป็น wrapper สำหรับ 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/th/java/com.aspose.slides/IChartCategoryLevelsManager) พร้อมกับ 
คุณสมบัติเพิ่มเติมที่จำเพาะสำหรับจุดข้อมูล. 
คลาส [**IChartDataPointLevel**](https://reference.aspose.com/slides/th/java/com.aspose.slides/IChartDataPointLevel) มี 
สองเมธอด: [**getFormat**](https://reference.aspose.com/slides/th/java/com.aspose.slides/IChartDataPointLevel#getFormat--) และ 
[**getDataLabel**](https://reference.aspose.com/slides/th/java/com.aspose.slides/IChartDataPointLevel#getLabel--) ซึ่ง 
ให้การเข้าถึงการตั้งค่าที่สอดคล้องกัน.

## **แสดงค่าจุดข้อมูล**
แสดงค่าของจุดข้อมูล “Leaf 4”:

```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **ตั้งค่าป้ายและสีของจุดข้อมูล**
ตั้งค่าป้ายข้อมูล “Branch 1” ให้แสดงชื่อ series (“Series1”) แทนชื่อหมวดหมู่ แล้วตั้งค่าสีข้อความเป็นสีเหลือง:

```java
IDataLabel branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);

branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **ตั้งค่าสีของสาขาจุดข้อมูล**
เปลี่ยนสีของสาขา “Steam 4”:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();

    IChartDataPointLevel stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);

    stem4branch.getFormat().getFill().setFillType(FillType.Solid);
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(Color.RED);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **FAQ**

**ฉันสามารถเปลี่ยนลำดับ (การเรียงลำดับ) ของส่วนใน Sunburst/Treemap ได้หรือไม่?**

ไม่ได้ PowerPoint จะเรียงลำดับส่วนอัตโนมัติ (โดยทั่วไปคือค่าลดลงตามเข็มนาฬิกา) Aspose.Slides ทำตามพฤติกรรมนี้เช่นกัน: คุณไม่สามารถเปลี่ยนลำดับโดยตรงได้; ต้องทำการเตรียมข้อมูลล่วงหน้าเพื่อให้ได้ลำดับที่ต้องการ

**ธีมของงานนำเสนอมีผลต่อสีของส่วนและป้ายอย่างไร?**

สีของแผนภูมิสืบทอดจาก [theme/palette](/slides/th/java/presentation-theme/) ของงานนำเสนอ เว้นแต่คุณจะกำหนดสีเติมหรือฟอนต์อย่างชัดเจน เพื่อผลลัพธ์ที่สม่ำเสมอ ควรกำหนดสีเติมแบบทึบและการจัดรูปแบบข้อความที่ระดับที่ต้องการ

**การส่งออกไปยัง PDF/PNG จะรักษาสีสาขาที่กำหนดเองและการตั้งค่าป้ายหรือไม่?**

ใช่ เมื่อส่งออกงานนำเสนอ การตั้งค่าแผนภูมิ (สีเติม, ป้าย) จะถูกเก็บไว้ในรูปแบบไฟล์ผลลัพธ์ เนื่องจาก Aspose.Slides เรนเดอร์ด้วยการจัดรูปแบบที่กำหนดไว้

**ฉันสามารถคำนวณพิกัดจริงของป้าย/องค์ประกอบเพื่อวาง overlay แบบกำหนดเองบนแผนภูมิได้หรือไม่?**

ได้ หลังจากแผนภูมิถูกวาง layout ตรวจสอบแล้ว จะมีค่า *x* และ *y* จริงสำหรับองค์ประกอบ (เช่น [DataLabel](https://reference.aspose.com/slides/th/java/com.aspose.slides/datalabel/)) ซึ่งช่วยให้กำหนดตำแหน่ง overlay อย่างแม่นยำ.