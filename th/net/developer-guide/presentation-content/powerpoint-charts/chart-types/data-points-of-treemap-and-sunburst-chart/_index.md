---
title: ปรับแต่งจุดข้อมูลในแผนภูมิ Treemap และ Sunburst สำหรับ .NET
linktitle: จุดข้อมูลในแผนภูมิ Treemap และ Sunburst
type: docs
url: /th/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- แผนภูมิ treemap
- แผนภูมิ sunburst
- แผนภูมิลำดับขั้น
- จุดข้อมูล
- ป้ายข้อมูล
- สีสาขา
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีสร้างข้อมูลเชิงลำดับขั้นและปรับแต่งระดับ, ป้ายและสีในแผนภูมิ Treemap และ Sunburst ด้วย Aspose.Slides สำหรับ .NET."
---
## **ภาพรวม**

Treemap และ Sunburst แสดงข้อมูลเชิงลำดับขั้นแบบเดียวกัน แต่ใช้การจัดวางที่แตกต่างกัน Treemap จะวาดลำดับขั้นเป็นสี่เหลี่ยมซ้อนกันโดยพื้นที่แทนค่าของใบข้อมูล ส่วน Sunburst จะวาดเป็นวงวงกลมศูนย์กลาง: กลุ่มระดับบนอยู่ใกล้ศูนย์กลาง และหมวดใบอยู่ที่วงนอก

ใน Aspose.Slides for .NET แต่ละค่าตัวเลขเป็น [IChartDataPoint](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatapoint/). คอลเลกชัน [IChartDataPoint.DataPointLevels](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatapoint/datapointlevels/) ให้เข้าถึงใบข้อมูลและกลุ่มผู้ปกครองของมัน บทความนี้อธิบายการแมปนี้และแสดงวิธีสร้างและจัดรูปแบบทั้งสองประเภทแผนภูมิจากข้อมูลตัวอย่างเดียวกัน

![แผนภูมิ Treemap ที่มีสาขา Consumer และ Business](treemap-hierarchy.png)

![แผนภูมิ Sunburst ที่มีลำดับขั้น Consumer และ Business เดียวกัน](sunburst-hierarchy.png)

## **ทำความเข้าใจหมวดหมู่, จุดข้อมูล, และระดับ**

ตัวอย่างที่ใช้ด้านล่างมีสามระดับหมวดหมู่และชุดตัวเลขหนึ่งชุด:

| สาขา | ส่วนย่อย | ใบ | รายได้ |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

แต่ละแถวสร้างหมวดหมู่ใบหนึ่งและจุดข้อมูลหนึ่ง ระดับการจัดกลุ่มหมวดหมู่อธิบายเส้นทางจากใบนั้นถึงผู้ปกครองของมัน สำหรับแถวแรก เส้นทางคือ `Consumer > Computers > Laptops`.

`DataPointLevels` ดัชนี | ระดับตรรกะ | การแสดงผล Treemap | การแสดงผล Sunburst |
---: | --- | --- | --- |
`0` | ใบ | สี่เหลี่ยมค่า | ส่วนวงนอก |
`1` | ส่วนย่อย | สี่เหลี่ยมผู้ปกครองหรือหัวข้อ | ส่วนวงกลาง |
`2` | สาขา | สี่เหลี่ยมระดับบนหรือหัวข้อ | ส่วนวงใน |

ลำดับนี้เหมือนกันสำหรับทั้งสองประเภทแผนภูมิแม้ว่าการจัดวางภาพจะแตกต่างกัน ส่วนผู้ปกครองจะถูกใช้ร่วมกันโดยหลายใบ เพื่อจัดรูปแบบให้ใช้ระดับที่สอดคล้องกับจุดข้อมูลแรกในกลุ่มนั้น ตัวอย่างเช่น สาขา `Consumer` เริ่มด้วยจุด `Laptops` ขณะที่ส่วนย่อย `Software` เริ่มด้วยจุด `Licenses` การเก็บอ้างอิงไปยังจุดเหล่านั้นทำให้ชัดเจนและปลอดภัยกว่าการใช้สูตรที่ไม่อธิบายเช่น `dataPoints[0]` หรือ `dataPoints[6]`.

## **สร้างและปรับแต่งทั้งสองประเภทแผนภูมิ**

ตัวอย่างเต็มต่อไปนี้สร้าง Treemap บนสไลด์แรกและ Sunburst บนสไลด์ที่สอง มันสร้างลำดับขั้น แสดงค่าของ `Tablets` ใช้สีคงที่กับระดับที่เลือก จัดรูปแบบป้ายสาขา และบันทึกการนำเสนอ

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var treemapSlide = presentation.Slides[0];
AddHierarchyChart(treemapSlide, ChartType.Treemap);

var layoutSlide = presentation.LayoutSlides[0];
var sunburstSlide = presentation.Slides.AddEmptySlide(layoutSlide);
AddHierarchyChart(sunburstSlide, ChartType.Sunburst);

presentation.Save("hierarchical-charts.pptx", SaveFormat.Pptx);

static void AddHierarchyChart(ISlide slide, ChartType chartType)
{
    const int worksheetIndex = 0;
    const int leafLevelIndex = 0;
    const int stemLevelIndex = 1;
    const int branchLevelIndex = 2;

    var chart = slide.Shapes.AddChart(chartType, 40, 40, 640, 440);
    chart.HasTitle = false;
    chart.HasLegend = false;
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    var workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(worksheetIndex);

    // เพิ่มหมวดหมู่ใบ. รายการจัดกลุ่มจะถูกตั้งค่าเฉพาะเมื่อเริ่มกลุ่มใหม่;
    // หมวดหมู่ต่อไปนี้จะคงอยู่ในกลุ่มนั้นจนกว่าจะมีการตั้งค่ารายการใหม่.
    var laptopsCategory = AddCategory(1, "Laptops");
    laptopsCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Computers");
    laptopsCategory.GroupingLevels.SetGroupingItem(branchLevelIndex, "Consumer");

    AddCategory(2, "Desktops");

    var phonesCategory = AddCategory(3, "Phones");
    phonesCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Mobile");

    AddCategory(4, "Tablets");

    var consultingCategory = AddCategory(5, "Consulting");
    consultingCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Services");
    consultingCategory.GroupingLevels.SetGroupingItem(branchLevelIndex, "Business");

    AddCategory(6, "Support");

    var licensesCategory = AddCategory(7, "Licenses");
    licensesCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Software");

    AddCategory(8, "Subscriptions");

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 3, "Revenue");
    var series = chart.ChartData.Series.Add(seriesNameCell, chartType);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;

    var laptopsDataPoint = AddDataPoint(1, 12);
    AddDataPoint(2, 8);
    AddDataPoint(3, 15);
    var tabletsDataPoint = AddDataPoint(4, 6);
    AddDataPoint(5, 10);
    AddDataPoint(6, 7);
    var licensesDataPoint = AddDataPoint(7, 11);
    AddDataPoint(8, 14);

    // แสดงหมวดหมู่และค่าในใบ Tablets.
    var tabletsLabelFormat = tabletsDataPoint.DataPointLevels[leafLevelIndex]
        .Label.DataLabelFormat;
    tabletsLabelFormat.ShowCategoryName = true;
    tabletsLabelFormat.ShowValue = true;
    tabletsLabelFormat.Separator = "\n";
    tabletsLabelFormat.NumberFormat = "$0";

    // จัดรูปแบบสาขา Consumer ผ่านใบแรกในสาขานั้น.
    var consumerBranchLevel = laptopsDataPoint.DataPointLevels[branchLevelIndex];
    var consumerBranchFill = consumerBranchLevel.Format.Fill;
    var consumerBranchColor = Color.FromArgb(31, 78, 121);
    SetSolidFill(consumerBranchFill, consumerBranchColor);

    var consumerLabelFormat = consumerBranchLevel.Label.DataLabelFormat;
    consumerLabelFormat.ShowCategoryName = true;
    consumerLabelFormat.ShowSeriesName = false;
    var consumerLabelTextFill = consumerLabelFormat.TextFormat.PortionFormat.FillFormat;
    SetSolidFill(consumerLabelTextFill, Color.White);

    // จัดรูปแบบส่วนย่อย Software ผ่านใบแรกในส่วนย่อยนั้น.
    var softwareStemLevel = licensesDataPoint.DataPointLevels[stemLevelIndex];
    var softwareStemFill = softwareStemLevel.Format.Fill;
    var softwareStemColor = Color.FromArgb(112, 173, 71);
    SetSolidFill(softwareStemFill, softwareStemColor);

    // ParentLabelLayout มีผลต่อป้ายผู้ปกครองของ Treemap; Sunburst ใช้ส่วนของวง.
    if (chartType == ChartType.Treemap)
    {
        series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;
    }

    IChartCategory AddCategory(int rowIndex, string leafName)
    {
        var categoryCell = workbook.GetCell(worksheetIndex, rowIndex, 2, leafName);
        return chart.ChartData.Categories.Add(categoryCell);
    }

    IChartDataPoint AddDataPoint(int rowIndex, double value)
    {
        var valueCell = workbook.GetCell(worksheetIndex, rowIndex, 3, value);

        if (chartType == ChartType.Treemap)
        {
            return series.DataPoints.AddDataPointForTreemapSeries(valueCell);
        }

        return series.DataPoints.AddDataPointForSunburstSeries(valueCell);
    }

    static void SetSolidFill(IFillFormat fillFormat, Color color)
    {
        fillFormat.FillType = FillType.Solid;
        fillFormat.SolidFillColor.Color = color;
    }
}
```

เซลล์หมวดหมู่และเซลล์ค่าใช้แถว worksheet เดียวกัน ดังนั้นตำแหน่งคอลเลกชันของพวกมันจะยังคงสอดคล้องกัน เมื่อทำงานกับแผนภูมิที่มีอยู่แทนการสร้างใหม่ ให้ตรวจสอบแถวหมวดหมู่ก่อนและเก็บอ้างอิงชื่อไปยังจุดข้อมูลและระดับที่ต้องการจัดรูปแบบ

## **พฤติกรรมและข้อควรพิจารณาเชิงปฏิบัติ**

### **ความแตกต่างระหว่าง Treemap และ Sunburst**

- Treemap ใช้พื้นที่เพื่อสื่อค่าและสี่เหลี่ยมซ้อนกันเพื่อสื่อลำดับขั้น คุณสมบัติ [IChartSeries.ParentLabelLayout](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseries/parentlabellayout/) ควบคุมวิธีที่ป้ายผู้ปกครองปรากฏในประเภทแผนภูมินี้
- Sunburst ใช้มุมเพื่อสื่อค่าและความลึกของวงเพื่อสื่อลำดับขั้น [IChartSeries.ParentLabelLayout](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseries/parentlabellayout/) ไม่ควบคุมป้ายวงของมัน
- ทั้งสองประเภทแผนภูมิใช้ระดับการจัดกลุ่มหมวดหมู่เดียวกันและลำดับ leaf‑to‑parent เดียวกันใน `DataPointLevels` ดังนั้นโค้ดการสร้างข้อมูลและการจัดรูปแบบระดับสามารถแชร์กันได้
- ค่าผู้ปกครองคำนวณจากใบข้อมูลที่สืบทอด อย่าเพิ่มจุดตัวเลขแยกสำหรับสาขาหรือส่วนย่อย

### **การเรียงลำดับและลำดับส่วน**

เครื่องมือจัดวางแผนภูมิจะกำหนดตำแหน่งสุดท้ายของสี่เหลี่ยมและส่วนวง จัดกลุ่มแถวหมวดหมู่ที่เกี่ยวข้องให้เรียงกันก่อนเพิ่มลงไป แต่ไม่ควรพึ่งพาตำแหน่งสี่เหลี่ยมหรือมุมเริ่มต้นที่เฉพาะเจาะจง หากลำดับมีความหมาย ให้รวมไว้ในป้ายหรือใช้ประเภทแผนภูมิที่มีแกนหมวดหมู่ชัดเจน

### **ธีมและสีคงที่**

ระดับแผนภูมิที่ไม่ได้จัดรูปแบบจะสืบทอดสีจากธีมการนำเสนอ ตัวอย่างใช้การเติมสี RGB อย่างชัดเจนเพื่อผลลัพธ์ที่คาดเดาได้ หากต้องการให้แผนภูมิติดตามการเปลี่ยนแปลงธีม ให้ใช้สีจากสคีมแทนค่า RGB คงที่และหลีกเลี่ยงการเขียนทับทุกระดับ ตรวจสอบความคมชัดของป้ายหลังจากเปลี่ยนสีสาขาหรือส่วนย่อย

### **ป้ายชื่อและพื้นที่ที่ใช้ได้**

PowerPoint อาจซ่อนหรือตัดป้ายเมื่อส่วนมีขนาดเล็กเกินไป การเพิ่มขนาดแผนภูมิ, ย่อชื่อหมวดหมู่, หรือแสดงฟิลด์ป้ายให้น้อยลงมักทำให้ผลลัพธ์ชัดเจนขึ้น ป้ายสามารถรวมชื่อหมวดหมู่, ชื่อชุด, และค่าได้ผ่าน [IDataLabelFormat](https://reference.aspose.com/slides/th/net/aspose.slides.charts/idatalabelformat/) แต่การเปิดใช้งานทุกฟิลด์มักทำให้แผนภูมิเชิงลำดับขั้นอ่านยาก

### **การส่งออกและการเรนเดอร์**

การบันทึกเป็น PPTX จะทำให้แผนภูมิแก้ไขได้ เมื่อ Aspose.Slides เรนเดอร์การนำเสนอเป็น PDF หรือรูปภาพ การเติมสีและการตั้งค่าป้ายที่รองรับจะถูกรวมในการเรนเดอร์ การแทนที่ฟอนต์และความแตกต่างเล็กน้อยในพื้นที่จัดวางที่ใช้ได้อาจเปลี่ยนการตัดบรรทัดหรือการแสดงป้าย ดังนั้นให้ติดตั้งฟอนต์ที่จำเป็นและตรวจสอบเป้าหมายการส่งออกที่สำคัญ

## **คำถามที่พบบ่อย**

**ทำไมการเปลี่ยนระดับผู้ปกครองถึงส่งผลต่อหลายใบ?**  
สาขาหรือส่วนย่อยเป็นส่วนภาพที่ใช้ร่วมกัน [IChartDataPointLevel](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatapointlevel/) สามารถเข้าถึงได้ผ่านใบข้อมูลสืบทอด แต่การจัดรูปแบบจะเป็นของส่วนผู้ปกครองที่แชร์ ไม่ใช่เฉพาะใบเดียวเท่านั้น

**ทำไมป้ายข้อมูลหายไป?**  
ก่อนอื่นเปิดใช้งานฟิลด์ที่ต้องการบนวัตถุ [IDataLabelFormat](https://reference.aspose.com/slides/th/net/aspose.slides.charts/idatalabelformat/) แล้วตรวจสอบว่ามีพื้นที่เพียงพอหรือไม่ การจัดวางป้ายผู้ปกครองของ Treemap, ขนาดแผนภูมิ, ความยาวป้าย, ขนาดฟอนต์, และจำนวนฟิลด์ที่เปิดใช้งานทั้งหมดมีผลต่อการแสดงป้าย

**ฉันสามารถกำหนดลำดับหรือพิกัดที่แน่นอนของส่วนได้หรือไม่?**  
คุณสามารถควบคุมลำดับแถวต้นทางและทำให้แต่ละกลุ่มต่อเนื่องกันได้ แต่ไม่สามารถกำหนดสี่เหลี่ยม Treemap หรือมุม Sunburst อย่างแม่นยำได้ เครื่องมือจัดวางแผนภูมิคำนวณจากลำดับขั้น, ค่า, และพื้นที่ที่มี

**ทำไมสีถึงเปลี่ยนเมื่อตัวธีมการนำเสนอเปลี่ยน?**  
การเติมสีตามธีมออกแบบให้สอดคล้องกับพาเลตของการนำเสนอ ใช้สี RGB ที่ชัดเจนกับระดับที่ต้องคงที่ หรือใช้สีสคีมเมื่อปรับให้เข้ากับธีมใหม่เป็นทางเลือกที่ต้องการ

**การจัดรูปแบบที่กำหนดเองจะคงอยู่ในการส่งออกเป็น PDF และรูปภาพหรือไม่?**  
ใช่ การเติมสีแผนภูมิและการตั้งค่าป้ายที่สนับสนุนจะถูกรวมในระหว่างการเรนเดอร์ เพื่อผลลัพธ์สม่ำเสมอระหว่างระบบ ให้ทำให้ฟอนต์ที่จำเป็นพร้อมใช้งานและทดสอบขนาดการส่งออกสุดท้ายเนื่องจากการใส่ป้ายขึ้นอยู่กับการจัดวาง

## **ดูเพิ่มเติม**

- [สร้างแผนภูมิ Treemap](/slides/th/net/create-chart/#create-tree-map-charts)
- [สร้างแผนภูมิ Sunburst](/slides/th/net/create-chart/#create-sunburst-charts)
- [ส่งออกแผนภูมิการนำเสนอ](/slides/th/net/export-chart/)
- [จัดการธีมการนำเสนอ](/slides/th/net/presentation-theme/)