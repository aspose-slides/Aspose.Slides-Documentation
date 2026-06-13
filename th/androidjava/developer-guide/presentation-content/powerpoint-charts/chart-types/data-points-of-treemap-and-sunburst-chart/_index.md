---
title: ปรับแต่งจุดข้อมูลในแผนภูมิ Treemap และ Sunburst บน Android
linktitle: จุดข้อมูลในแผนภูมิ Treemap และ Sunburst
type: docs
url: /th/androidjava/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- แผนภูมิ treemap
- แผนภูมิ sunburst
- จุดข้อมูล
- สีป้าย
- สีกิ่ง
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีจัดการจุดข้อมูลในแผนภูมิ treemap และ sunburst ด้วย Aspose.Slides สำหรับ Android ผ่าน Java ที่รองรับรูปแบบของ PowerPoint"
---
## **บทนำ**

ในหมวดอื่นของแผนภูมิ PowerPoint มีประเภทเชิงลำดับขั้นสองประเภทคือ **Treemap** และ **Sunburst** (ซึ่งยังรู้จักกันในชื่อ Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph หรือ Multi Level Pie Chart) แผนภูมิเหล่านี้แสดงข้อมูลเชิงลำดับขั้นที่จัดระเบียบเป็นต้นไม้ ตั้งแต่ใบจนถึงยอดของกิ่ง ใบถูกกำหนดโดยจุดข้อมูลของซีรีส์ และระดับการจัดกลุ่มซ้อนกันแต่ละระดับต่อไปถูกกำหนดโดยหมวดที่สอดคล้องกัน Aspose.Slides for Android ผ่าน Java อนุญาตให้จัดรูปแบบจุดข้อมูลของแผนภูมิ Sunburst และ Treemap ใน Java

นี่คือแผนภูมิ Sunburst ที่ข้อมูลในคอลัมน์ Series1 กำหนดโหนดใบไม้ ในขณะที่คอลัมน์อื่นกำหนดข้อมูลเชิงลำดับขั้น:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

เริ่มต้นด้วยการเพิ่มแผนภูมิ Sunburst ใหม่ไปยังการนำเสนอ:

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
- [**สร้างหรืออัปเดตแผนภูมิการนำเสนอ PowerPoint บน Android**](/slides/th/androidjava/create-chart/)
{{% /alert %}}

หากต้องการจัดรูปแบบจุดข้อมูลของแผนภูมิ เราควรใช้สิ่งต่อไปนี้:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChartDataPointLevelsManager),
[IChartDataPointLevel](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChartDataPointLevel) classes
และเมธอด [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChartDataPoint#getDataPointLevels--) ให้การเข้าถึงการจัดรูปแบบจุดข้อมูลของแผนภูมิ Treemap และ Sunburst. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChartDataPointLevelsManager)
ใช้สำหรับเข้าถึงหมวดหลายระดับ - มันเป็นตัวแทนของคอนเทนเนอร์ของวัตถุ [**IChartDataPointLevel**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChartDataPointLevel). 
โดยพื้นฐานแล้วมันเป็น wrapper สำหรับ 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChartCategoryLevelsManager) 
พร้อมคุณสมบัติที่เพิ่มเฉพาะสำหรับจุดข้อมูล. 
คลาส [**IChartDataPointLevel**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChartDataPointLevel) มีสองเมธอด: [**getFormat**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChartDataPointLevel#getFormat--) และ [**getDataLabel**](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChartDataPointLevel#getLabel--) ซึ่งให้การเข้าถึงการตั้งค่าที่เกี่ยวข้อง.

## **แสดงค่าจุดข้อมูล**

แสดงค่าของจุดข้อมูล "Leaf 4":

```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **ตั้งค่าป้ายและสีของจุดข้อมูล**

ตั้งค่าป้ายข้อมูลของ "Branch 1" ให้แสดงชื่อซีรีส์ ("Series1") แทนชื่อหมวด แล้วตั้งค่าสีข้อความเป็นสีเหลือง:

```java
IDataLabel branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);

branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **ตั้งค่าสีกิ่งของจุดข้อมูล**

เปลี่ยนสีของกิ่ง "Steam 4":

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

## **คำถามที่พบบ่อย**

**ฉันสามารถเปลี่ยนลำดับ (การจัดเรียง) ของเซกเมนต์ใน Sunburst/Treemap ได้หรือไม่?**  
ไม่ได้ PowerPoint จัดเรียงเซกเมนต์โดยอัตโนมัติ (โดยทั่วไปตามค่าลดลงและตามเข็มนาฬิกา) Aspose.Slides ทำตามพฤติกรรมนี้เช่นกัน: ไม่สามารถเปลี่ยนลำดับโดยตรงได้; ต้องทำโดยการเตรียมข้อมูลล่วงหน้า.

**ธีมการนำเสนอมีผลต่อสีของเซกเมนต์และป้ายอย่างไร?**  
สีของแผนภูมิจะสืบทอดจาก [theme/palette](/slides/th/androidjava/presentation-theme/) ของการนำเสนอ เว้นแต่คุณจะตั้งค่าเติมสี/ฟอนต์อย่างชัดเจน เพื่อผลลัพธ์ที่สอดคล้องกัน ควรกำหนดการเติมสีทึบและการจัดรูปแบบข้อความที่ระดับที่ต้องการ.

**การส่งออกเป็น PDF/PNG จะรักษาสีกิ่งที่กำหนดเองและการตั้งค่าป้ายไว้หรือไม่?**  
ใช่ เมื่อส่งออกการนำเสนอ การตั้งค่าแผนภูมิ (การเติมสี, ป้าย) จะถูกรักษาในรูปแบบไฟล์ที่ส่งออก เนื่องจาก Aspose.Slides เรนเดอร์ด้วยการจัดรูปแบบของแผนภูมิที่กำหนดไว้.

**ฉันสามารถคำนวณพิกัดจริงของป้าย/องค์ประกอบเพื่อนำไปวาง overlay ส่วนกำหนดเองบนแผนภูมิได้หรือไม่?**  
ใช่ หลังจากการจัดวางแผนภูมิได้รับการตรวจสอบแล้ว ค่า *x* และ *y* จริงจะพร้อมใช้งานสำหรับองค์ประกอบ (เช่น [DataLabel](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/datalabel/)) ซึ่งช่วยในการกำหนดตำแหน่ง overlay อย่างแม่นยำ.