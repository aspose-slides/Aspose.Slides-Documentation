---
title: จัดการซีรีส์ข้อมูลแผนภูมิในงานนำเสนอด้วย Java
linktitle: ซีรีส์ข้อมูล
type: docs
url: /th/java/chart-series/
keywords:
- ซีรีส์แผนภูมิ
- การทับซ้อนของซีรีส์
- สีของซีรีส์
- สีของหมวดหมู่
- ชื่อซีรีส์
- จุดข้อมูล
- ช่องว่างของซีรีส์
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีจัดการซีรีส์แผนภูมิใน Java สำหรับ PowerPoint (PPT/PPTX) พร้อมตัวอย่างโค้ดที่ใช้งานได้จริงและแนวปฏิบัติที่ดีที่สุดเพื่อเสริมสร้างการนำเสนอข้อมูลของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายบทบาทของ [ChartSeries](https://reference.aspose.com/slides/th/java/com.aspose.slides/chartseries/) ใน Aspose.Slides โดยมุ่งเน้นที่วิธีการจัดโครงสร้างและแสดงผลข้อมูลภายในงานนำเสนอ วัตถุเหล่านี้เป็นองค์ประกอบพื้นฐานที่กำหนดชุดจุดข้อมูล, หมวดหมู่, และค่าพารามิเตอร์การแสดงผลในแผนภูมิ เมื่อทำงานกับ [ChartSeries](https://reference.aspose.com/slides/th/java/com.aspose.slides/chartseries/) นักพัฒนาสามารถผสานแหล่งข้อมูลพื้นฐานได้อย่างราบรื่นและควบคุมการแสดงข้อมูลได้อย่างเต็มที่ ทำให้ได้งานนำเสนอแบบไดนามิกที่ขับเคลื่อนด้วยข้อมูลและสื่อความเข้าใจรวมถึงการวิเคราะห์อย่างชัดเจน

Series คือแถวหรือคอลัมน์ของตัวเลขที่ถูกพล็อตในแผนภูมิ

![chart-series-powerpoint](chart-series-powerpoint.png)

## **ตั้งค่าการทับซ้อนของซีรีส์แผนภูมิ**

ด้วยคุณสมบัติ [IChartSeriesOverlap](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseries/properties/overlap) คุณสามารถระบุว่าบาร์และคอลัมน์ควรทับซ้อนกันเท่าใดในแผนภูมิ 2D (ช่วง: -100 ถึง 100) คุณสมบัตินี้ใช้กับซีรีส์ทั้งหมดในกลุ่มซีรีส์พาเรนต์: เป็นการฉายของคุณสมบัติของกลุ่มที่เหมาะสม ดังนั้นคุณสมบัตินี้เป็นแบบอ่านอย่างเดียว

ใช้คุณสมบัติ `ParentSeriesGroup.Overlap` ที่อ่าน/เขียนได้เพื่อกำหนดค่าที่คุณต้องการสำหรับ `Overlap`

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)
1. เพิ่มแผนภูมิคอลัมน์แบบกลุ่มบนสไลด์
1. เข้าถึงซีรีส์แผนภูม้อันดับแรก
1. เข้าถึง `ParentSeriesGroup` ของซีรีส์แผนภูมิและตั้งค่าการทับซ้อนที่ต้องการสำหรับซีรีส์
1. เขียนงานนำเสนอที่แก้ไขแล้วลงไฟล์ PPTX

```java
Presentation pres = new Presentation();
try {
    // เพิ่มแผนภูมิ
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0)
    {
        // ตั้งค่าการทับซ้อนของซีรีส์
        series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);
    }

    // เขียนไฟล์งานนำเสนอลงดิสก์
    pres.save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **เปลี่ยนสีของซีรีส์**

Aspose.Slides for Java ให้คุณเปลี่ยนสีของซีรีส์ได้ดังนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)
1. เพิ่มแผนภูมิบนสไลด์
1. เข้าถึงซีรีส์ที่ต้องการเปลี่ยนสี
1. ตั้งค่าประเภทการเติมและสีที่ต้องการ
1. บันทึกงานนำเสนอที่แก้ไขแล้ว

```java
Presentation pres = new Presentation("test.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 600, 400);
    IChartDataPoint point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(1);

    point.setExplosion(30);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **เปลี่ยนสีของหมวดหมู่ซีรีส์**

Aspose.Slides for Java ให้คุณเปลี่ยนสีของหมวดหมู่ซีรีส์ได้ดังนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)
1. เพิ่มแผนภูมิบนสไลด์
1. เข้าถึงหมวดหมู่ของซีรีส์ที่ต้องการเปลี่ยนสี
1. ตั้งค่าประเภทการเติมและสีที่ต้องการ
1. บันทึกงานนำเสนอที่แก้ไขแล้ว

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    IChartDataPoint point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(0);

    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **เปลี่ยนชื่อซีรีส์**

โดยค่าเริ่มต้น ชื่อในตำนานของแผนภูมิจะมาจากเนื้อหาของเซลล์ที่อยู่เหนือแต่ละคอลัมน์หรือแถวของข้อมูล

ในตัวอย่างของเรา (ภาพตัวอย่าง),

* คอลัมน์คือ *Series 1, Series 2,* และ *Series 3*;
* แถวคือ *Category 1, Category 2, Category 3,* และ *Category 4*.

Aspose.Slides for Java ให้คุณอัปเดตหรือเปลี่ยนชื่อซีรีส์ในข้อมูลแผนภูมิและตำนานได้

โค้ด Java นี้แสดงวิธีการเปลี่ยนชื่อซีรีส์ในข้อมูลแผนภูมิ `ChartDataWorkbook`:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);

    IChartDataCell seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("New name");

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

โค้ด Java นี้แสดงวิธีการเปลี่ยนชื่อซีรีส์ในตำนานผ่าน`Series`:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    IStringChartValue name = series.getName();
    name.getAsCells().get_Item(0).setValue("New name");
} finally {
    if (pres != null) pres.dispose();
}
```

## **ตั้งค่าสีเติมอัตโนมัติสำหรับซีรีส์แผนภูมิ**

Aspose.Slides for Java ให้คุณตั้งค่าสีเติมอัตโนมัติสำหรับซีรีส์แผนภูมิภายในพื้นที่พล็อตได้ดังนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)
1. รับการอ้างอิงของสไลด์โดยใช้ดัชนี
1. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นตามประเภทที่คุณต้องการ (ในตัวอย่างนี้เราใช้ `ChartType.ClusteredColumn`)
1. เข้าถึงซีรีส์แผนภูมิและตั้งค่าสีเติมเป็น Automatic
1. บันทึกงานนำเสนอเป็นไฟล์ PPTX

```java
Presentation pres = new Presentation();
try {
    // สร้างแผนภูมิคอลัมน์แบบกลุ่ม
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // ตั้งค่ารูปแบบการเติมสีของซีรีส์เป็นอัตโนมัติ
    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }

    // เขียนไฟล์งานนำเสนอลงดิสก์
    pres.save("AutoFillSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ตั้งค่าสีเติมกลับด้านสำหรับซีรีส์แผนภูมิ**

Aspose.Slides ให้คุณตั้งค่าสีเติมกลับด้านสำหรับซีรีส์แผนภูมิภายในพื้นที่พล็อตได้ดังนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)
1. รับการอ้างอิงของสไลด์โดยใช้ดัชนี
1. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นตามประเภทที่คุณต้องการ (ในตัวอย่างนี้เราใช้ `ChartType.ClusteredColumn`)
1. เข้าถึงซีรีส์แผนภูมิและตั้งค่าสีเติมเป็น invert
1. บันทึกงานนำเสนอเป็นไฟล์ PPTX

```java
Color inverColor = Color.RED;
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // เพิ่มซีรีส์และหมวดหมู่ใหม่
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));

    // นำซีรีส์แผนภูม้อันดับแรกและเติมข้อมูลซีรีส์ของมัน.
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 1, 1, -20));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 3, 1, -30));
    Color seriesColor = series.getAutomaticSeriesColor();
    series.setInvertIfNegative(true);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(seriesColor);
    series.getInvertedSolidFillColor().setColor(inverColor);
    
    pres.save("SetInvertFillColorChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ตั้งค่าให้ซีรีส์กลับด้านเมื่อค่าติดลบ**

Aspose.Slides ให้คุณตั้งค่าการกลับด้านผ่านคุณสมบัติ `IChartDataPoint.InvertIfNegative` และ `ChartDataPoint.InvertIfNegative` เมื่อการกลับด้านถูกตั้งค่าผ่านคุณสมบัติเหล่านี้ จุดข้อมูลจะสลับสีเมื่อได้รับค่าติดลบ

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    chart.getChartData().getSeries().clear();

    IChartSeries chartSeries = series.add(chart.getChartData().getChartDataWorkbook().getCell(0, "B1"), chart.getType());
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B2", -5));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B3", 3));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B4", -2));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B5", 1));

    chartSeries.setInvertIfNegative(false);

    chartSeries.getDataPoints().get_Item(2).setInvertIfNegative(true);

    pres.save("out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ลบข้อมูลจุดเฉพาะ**

Aspose.Slides for Java ให้คุณลบข้อมูล `DataPoints` ของซีรีส์แผนภูมิเฉพาะได้ดังนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)
2. รับการอ้างอิงของสไลด์ผ่านดัชนี
3. รับการอ้างอิงของแผนภูมิผ่านดัชนี
4. วนซ้ำผ่าน `DataPoints` ทั้งหมดของแผนภูมิและตั้งค่า `XValue` และ `YValue` เป็น null
5. ลบ `DataPoints` ทั้งหมดสำหรับซีรีส์แผนภูมิที่ระบุ
6. เขียนงานนำเสนอที่แก้ไขแล้วลงไฟล์ PPTX

```java
Presentation pres = new Presentation("TestChart.pptx");
try {
    ISlide sl = pres.getSlides().get_Item(0);

    IChart chart = (IChart)sl.getShapes().get_Item(0);

    for (IChartDataPoint dataPoint : chart.getChartData().getSeries().get_Item(0).getDataPoints())
    {
        dataPoint.getXValue().getAsCell().setValue(null);
        dataPoint.getYValue().getAsCell().setValue(null);
    }

    chart.getChartData().getSeries().get_Item(0).getDataPoints().clear();

    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ตั้งค่าความกว้างช่องว่างของซีรีส์**

Aspose.Slides for Java ให้คุณตั้งค่าความกว้างช่องว่างของซีรีส์ผ่านคุณสมบัติ **`GapWidth`** ได้ดังนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)
1. เข้าถึงสไลด์แรก
1. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้น
1. เข้าถึงซีรีส์แผนภูมิใดก็ได้
1. ตั้งค่าคุณสมบัติ `GapWidth`
1. เขียนงานนำเสนอที่แก้ไขแล้วลงไฟล์ PPTX

```java
// สร้างงานนำเสนอเปล่า 
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรกของงานนำเสนอ
    ISlide slide = pres.getSlides().get_Item(0);
    
    // เพิ่มแผนภูมิกับข้อมูลเริ่มต้น
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 0, 0, 500, 500);
    
    // กำหนดดัชนีของชีตข้อมูลแผนภูมิ
    int defaultWorksheetIndex = 0;
    
    // ดึงเวิร์กชีตข้อมูลแผนภูมิ
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // เพิ่มซีรีส์
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // เพิ่มหมวดหมู่
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // ดึงซีรีส์แผนภูมิที่สอง
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // เติมข้อมูลให้ซีรีส์
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // ตั้งค่าความกว้างช่องว่าง
    series.getParentSeriesGroup().setGapWidth(50);
    
    // บันทึกงานนำเสนอลงดิสก์
    pres.save("GapWidth_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**มีขีดจำกัดจำนวนซีรีส์ที่แผนภูมิเดียวสามารถมีได้หรือไม่?**

Aspose.Slides ไม่กำหนดขีดจำกัดคงที่สำหรับจำนวนซีรีส์ที่คุณเพิ่ม เพดานที่เป็นจริงจะถูกกำหนดโดยความสามารถในการอ่านของแผนภูมิและโดยหน่วยความจำที่มีให้กับแอปพลิเคชันของคุณ

**ถ้าคอลัมน์ภายในกลุ่มใกล้กันเกินไปหรือห่างกันมากเกินไปควรทำอย่างไร?**

ปรับค่าการตั้งค่า `GapWidth` สำหรับซีรีส์นั้น (หรือกลุ่มซีรีส์พาเรนต์) การเพิ่มค่าจะทำให้คอลัมน์ห่างกันมากขึ้น ในขณะที่การลดค่าจะทำให้คอลัมน์เข้าหากันมากขึ้น