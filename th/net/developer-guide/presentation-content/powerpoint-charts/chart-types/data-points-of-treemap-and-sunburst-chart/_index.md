---
title: ปรับแต่งจุดข้อมูลในแผนภูมิ Treemap และ Sunburst ใน .NET
linktitle: จุดข้อมูลในแผนภูมิ Treemap และ Sunburst
type: docs
url: /th/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- แผนภูมิ treemap
- แผนภูมิ sunburst
- จุดข้อมูล
- สีป้าย
- สีสาขา
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีจัดการจุดข้อมูลในแผนภูมิ treemap และ sunburst ด้วย Aspose.Slides สำหรับ .NET ที่รองรับรูปแบบของ PowerPoint"
---
## **บทนำ**

นอกเหนือจากประเภทอื่น ๆ ของแผนภูมิ PowerPoint มีสองประเภทที่เป็น “เชิงลำดับขั้น” คือแผนภูมิ **Treemap** และ **Sunburst** (ที่รู้จักกันในชื่อ Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph หรือ Multi Level Pie Chart) แผนภูมิเหล่านี้แสดงข้อมูลเชิงลำดับขั้นที่จัดเป็นต้นไม้ ตั้งแต่ใบไม้จนถึงยอดของกิ่ง ใบไม้ถูกกำหนดโดยจุดข้อมูลของชุดข้อมูล และแต่ละระดับการจัดกลุ่มซ้อนกันต่อไปถูกกำหนดโดยประเภทที่สอดคล้องกัน Aspose.Slides for .NET รองรับการจัดรูปแบบจุดข้อมูลของแผนภูมิ Sunburst และ Treemap ใน C#.

นี่คือแผนภูมิ Sunburst ที่ข้อมูลในคอลัมน์ Series1 กำหนดโหนดใบไม้ ขณะที่คอลัมน์อื่น ๆ กำหนดจุดข้อมูลเชิงลำดับขั้น:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

เริ่มต้นด้วยการเพิ่มแผนภูมิ Sunburst ใหม่ลงในงานนำเสนอ:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    // ...
}
```

{{% alert color="primary" title="ดูเพิ่มเติม" %}} 
- [**สร้างแผนภูมิ Sunburst**](/slides/th/net/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

หากต้องการจัดรูปแบบจุดข้อมูลของแผนภูมิ เราควรใช้สิ่งต่อไปนี้:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/th/net/aspose.slides.charts/IChartDataPointLevelsManager), [IChartDataPointLevel](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatapointlevel) classes และ [**IChartDataPoint.DataPointLevels**](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatapoint/properties/datapointlevels) property ให้การเข้าถึงเพื่อจัดรูปแบบจุดข้อมูลของแผนภูมิ Treemap และ Sunburst. [**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/th/net/aspose.slides.charts/IChartDataPointLevelsManager) ใช้สำหรับการเข้าถึงหมวดหมู่หลายระดับ – เป็นตัวแทนของคอนเทนเนอร์ของวัตถุ [**IChartDataPointLevel**](https://reference.aspose.com/slides/th/net/aspose.slides.charts/IChartDataPointLevel) objects. โดยพื้นฐานแล้วเป็น wrapper สำหรับ [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/th/net/aspose.slides.charts/IChartCategoryLevelsManager) ที่มี properties เพิ่มเติมเฉพาะสำหรับจุดข้อมูล. คลาส [**IChartDataPointLevel**](https://reference.aspose.com/slides/th/net/aspose.slides.charts/IChartDataPointLevel) มีสอง properties: [**Format**](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatapointlevel/properties/format) และ [**DataLabel**](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatapointlevel/properties/label) ที่ให้การเข้าถึงการตั้งค่าที่สอดคล้องกัน.

## **แสดงค่าจุดข้อมูล**

แสดงค่าของจุดข้อมูล “Leaf 4”:

```c#
IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;
dataPoints[3].DataPointLevels[0].Label.DataLabelFormat.ShowValue = true;
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **ตั้งค่าป้ายและสีของจุดข้อมูล**

ตั้งค่าป้ายข้อมูลของ “Branch 1” ให้แสดงชื่อชุดข้อมูล (“Series1”) แทนชื่อประเภท จากนั้นตั้งค่าสีข้อความเป็นสีเหลือง:

```c#
IDataLabel branch1Label = dataPoints[0].DataPointLevels[2].Label;
branch1Label.DataLabelFormat.ShowCategoryName = false;
branch1Label.DataLabelFormat.ShowSeriesName = true;

branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **ตั้งค่าสีสาขาจุดข้อมูล**

เปลี่ยนสีของสาขา “Stem 4”:

```csharp
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    
    IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;

    IChartDataPointLevel stem4branch = dataPoints[9].DataPointLevels[1];
    
    stem4branch.Format.Fill.FillType = FillType.Solid;
    stem4branch.Format.Fill.SolidFillColor.Color = Color.Red;
      
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **คำถามที่พบบ่อย**

**ฉันสามารถเปลี่ยนลำดับ (การเรียงลำดับ) ของส่วนใน Sunburst/Treemap ได้หรือไม่?**

ไม่ PowerPoint จะเรียงลำดับส่วนโดยอัตโนมัติ (โดยทั่วไปจากค่าที่สูงไปต่ำ ตามเข็มนาฬิกา) Aspose.Slides ทำตามพฤติกรรมนี้เช่นเดียวกัน: คุณไม่สามารถเปลี่ยนลำดับโดยตรงได้; คุณต้องทำการเตรียมข้อมูลล่วงหน้าเพื่อให้ได้ลำดับที่ต้องการ.

**ธีมของงานนำเสนอส่งผลต่อสีของส่วนและป้ายอย่างไร?**

สีของแผนภูมิจะสืบทอดจาก [theme/palette](/slides/th/net/presentation-theme/) ของงานนำเสนอ เว้นแต่คุณจะตั้งค่าการเติมสีหรือฟอนต์อย่างชัดเจน เพื่อผลลัพธ์ที่สม่ำเสมอ ควรกำหนดการเติมสีทึบและการจัดรูปแบบข้อความที่ระดับที่ต้องการ.

**การส่งออกเป็น PDF/PNG จะคงสีสาขาและการตั้งค่าป้ายที่กำหนดเองไว้หรือไม่?**

ใช่ เมื่อส่งออกงานนำเสนอ การตั้งค่าแผนภูมิ (การเติมสี, ป้าย) จะถูกเก็บรักษาไว้ในรูปแบบผลลัพธ์เนื่องจาก Aspose.Slides ทำการเรนเดอร์โดยใช้การจัดรูปแบบของแผนภูมิ.

**ฉันสามารถคำนวณพิกัดจริงของป้าย/องค์ประกอบเพื่อวางซ้อนแบบกำหนดเองบนแผนภูมิได้หรือไม่?**

ใช่ หลังจากที่การจัดวางแผนภูมิได้รับการตรวจสอบแล้ว `ActualX`/`ActualY` จะพร้อมใช้งานสำหรับองค์ประกอบ (เช่น [DataLabel](https://reference.aspose.com/slides/th/net/aspose.slides.charts/datalabel/)) ซึ่งช่วยในการกำหนดตำแหน่งที่แม่นยำของการวางซ้อน.