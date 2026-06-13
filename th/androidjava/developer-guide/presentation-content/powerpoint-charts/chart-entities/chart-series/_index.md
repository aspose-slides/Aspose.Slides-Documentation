---
title: จัดการชุดข้อมูลแผนภูมิในงานนำเสนอบน Android
linktitle: ชุดข้อมูล
type: docs
url: /th/androidjava/chart-series/
keywords:
- ชุดข้อมูลแผนภูมิ
- การทับซ้อนของชุดข้อมูล
- สีของชุดข้อมูล
- สีของประเภท
- ชื่อชุดข้อมูล
- จุดข้อมูล
- ช่องว่างของชุดข้อมูล
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีจัดการชุดข้อมูลแผนภูมิบน Android สำหรับ PowerPoint (PPT/PPTX) ด้วยตัวอย่างโค้ด Java ที่ใช้งานได้จริงและแนวปฏิบัติที่ดีที่สุดเพื่อยกระดับการนำเสนอข้อมูลของคุณ"
---
## **ภาพรวม**

บทความนี้อธิบายบทบาทของ [ChartSeries](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/chartseries/) ใน Aspose.Slides โดยมุ่งเน้นที่วิธีการจัดโครงสร้างและแสดงผลข้อมูลภายในงานนำเสนอ วัตถุเหล่านี้ให้ส่วนประกอบพื้นฐานที่กำหนดชุดข้อมูล จุดข้อมูล ประเภท และพารามิเตอร์การแสดงผลในแผนภูมิ การทำงานกับ [ChartSeries](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/chartseries/) ทำให้นักพัฒนาสามารถบูรณาการแหล่งข้อมูลพื้นฐานได้อย่างราบรื่นและควบคุมการแสดงข้อมูลได้เต็มที่ ส่งผลให้งานนำเสนอที่เป็นแบบไดนามิกและขับเคลื่อนด้วยข้อมูลซึ่งสื่อสารข้อมูลเชิงลึกและการวิเคราะห์ได้อย่างชัดเจน

ซีรีส์คือแถวหรือคอลัมน์ของตัวเลขที่ถูกพล็อตในแผนภูมิ

![ชุดข้อมูลแผนภูมิใน PowerPoint](chart-series-powerpoint.png)

## **ตั้งค่าการทับซ้อนของชุดข้อมูลแผนภูมิ**

ด้วยเมธอด [IChartSeries.getOverlap](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartseries/#getOverlap--) คุณสามารถกำหนดว่าบาร์และคอลัมน์ควรทับซ้อนกันมากแค่ใดในแผนภูมิ 2D (ช่วง: -100 ถึง 100) คุณสมบัตินี้ใช้กับชุดข้อมูลทั้งหมดในกลุ่ม series พ่อแม่: ซึ่งเป็นการโปรเจคของคุณสมบัติกลุ่มที่เหมาะสม ดังนั้นคุณสมบัตินี้เป็นแบบอ่านอย่างเดียว

ใช้เมธอด `getParentSeriesGroup().setOverlap()` เพื่อกำหนดค่าการทับซ้อนตามที่คุณต้องการ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
1. เพิ่มแผนภูมิคอลัมน์แบบจัดกลุ่มบนสไลด์  
1. เข้าถึงชุดข้อมูลแผนภูมิแรก  
1. เข้าถึง `ParentSeriesGroup` ของชุดข้อมูลแผนภูมิและกำหนดค่าการทับซ้อนตามที่คุณต้องการสำหรับชุดข้อมูลนั้น  
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

ตัวอย่างโค้ด Java นี้แสดงวิธีตั้งค่าการทับซ้อนสำหรับชุดข้อมูลแผนภูมิ:

```java
Presentation pres = new Presentation();
try {
    // เพิ่มแผนภูมิ
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0)
    {
        // ตั้งค่าการทับซ้อนของชุดข้อมูล
        series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);
    }

    // เขียนไฟล์งานนำเสนอไปยังดิสก์
    pres.save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **เปลี่ยนสีของชุดข้อมูล**

Aspose.Slides for Android ผ่าน Java ให้คุณเปลี่ยนสีของชุดข้อมูลได้ตามวิธีนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
1. เพิ่มแผนภูมิบนสไลด์  
1. เข้าถึงชุดข้อมูลที่คุณต้องการเปลี่ยนสี  
1. กำหนดประเภทการเติมและสีการเติมตามที่คุณต้องการ  
1. บันทึกงานนำเสนอที่แก้ไข  

โค้ด Java นี้แสดงวิธีเปลี่ยนสีของชุดข้อมูล:

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

## **เปลี่ยนสีของประเภทชุดข้อมูล**

Aspose.Slides for Android ผ่าน Java ให้คุณเปลี่ยนสีของประเภทของชุดข้อมูลได้ตามวิธีนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
1. เพิ่มแผนภูมิบนสไลด์  
1. เข้าถึงประเภทของชุดข้อมูลที่คุณต้องการเปลี่ยนสี  
1. กำหนดประเภทการเติมและสีการเติมตามที่คุณต้องการ  
1. บันทึกงานนำเสนอที่แก้ไข  

โค้ด Java นี้แสดงวิธีเปลี่ยนสีของประเภทชุดข้อมูล:

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

## **เปลี่ยนชื่อชุดข้อมูล** 

โดยค่าเริ่มต้น ชื่อของเลเจนด์ในแผนภูมิจะมาจากเนื้อหาของเซลข้างบนแต่ละคอลัมน์หรือแถวของข้อมูล

ในตัวอย่างของเรา (ภาพตัวอย่าง),

* คอลัมน์คือ *Series 1, Series 2,* และ *Series 3*;  
* แถวคือ *Category 1, Category 2, Category 3,* และ *Category 4.*  

Aspose.Slides for Android ผ่าน Java ให้คุณอัปเดตหรือเปลี่ยนชื่อชุดข้อมูลในข้อมูลแผนภูมิและเลเจนด์

โค้ด Java นี้แสดงวิธีเปลี่ยนชื่อของชุดข้อมูลใน `ChartDataWorkbook` ของข้อมูลแผนภูมิ:

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

โค้ด Java นี้แสดงวิธีเปลี่ยนชื่อชุดข้อมูลในเลเจนด์ผ่าน`Series`:

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

## **ตั้งค่าสีการเติมของชุดข้อมูลแผนภูมิ**

Aspose.Slides for Android ผ่าน Java ให้คุณตั้งค่าสีการเติมอัตโนมัติสำหรับชุดข้อมูลแผนภูมิภายในพื้นที่พล็อตได้ตามวิธีนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
1. รับอ้างอิงของสไลด์ด้วยดัชนีของมัน  
1. เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้นตามประเภทที่คุณต้องการ (ในตัวอย่างด้านล่าง เราใช้ `ChartType.ClusteredColumn`)  
1. เข้าถึงชุดข้อมูลแผนภูมิและตั้งค่าสีการเติมเป็น Automatic  
1. บันทึกงานนำเสนอเป็นไฟล์ PPTX  

โค้ด Java นี้แสดงวิธีตั้งค่าสีการเติมอัตโนมัติสำหรับชุดข้อมูลแผนภูมิ:

```java
Presentation pres = new Presentation();
try {
    // สร้างแผนภูมิคอลัมน์แบบจัดกลุ่ม
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // ตั้งค่ารูปแบบการเติมของชุดข้อมูลเป็นอัตโนมัติ
    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }

    // เขียนไฟล์งานนำเสนอไปยังดิสก์
    pres.save("AutoFillSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ตั้งค่าสีการเติมแบบกลับด้านสำหรับชุดข้อมูลแผนภูมิ**

Aspose.Slides ให้คุณตั้งค่าสีการเติมแบบกลับด้านสำหรับชุดข้อมูลแผนภูมิภายในพื้นที่พล็อตได้ตามวิธีนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
1. รับอ้างอิงของสไลด์ด้วยดัชนีของมัน  
1. เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้นตามประเภทที่คุณต้องการ (ในตัวอย่างด้านล่าง เราใช้ `ChartType.ClusteredColumn`)  
1. เข้าถึงชุดข้อมูลแผนภูมิและตั้งค่าสีการเติมเป็น invert  
1. บันทึกงานนำเสนอเป็นไฟล์ PPTX  

โค้ด Java นี้แสดงการทำงาน:

```java
Color inverColor = Color.RED;
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // เพิ่มชุดข้อมูลและประเภทใหม่
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));

    // นำชุดข้อมูลแผนภูมิลำดับแรกมาและเติมข้อมูลชุดข้อมูลของมัน
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

## **ตั้งให้ชุดข้อมูลกลับด้านเมื่อค่าติดลบ**

Aspose.Slides ให้คุณตั้งค่าการกลับด้านผ่านคุณสมบัติ `IChartDataPoint.InvertIfNegative` และ `ChartDataPoint.InvertIfNegative` เมื่อกำหนดการกลับด้านด้วยคุณสมบัติเหล่านี้ จุดข้อมูลจะกลับสีของมันเมื่อได้รับค่าติดลบ

โค้ด Java นี้แสดงการทำงาน:

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

## **ล้างข้อมูลจุดเฉพาะ**

Aspose.Slides for Android ผ่าน Java ให้คุณล้างข้อมูล `DataPoints` ของชุดข้อมูลแผนภูมิเฉพาะได้ตามวิธีนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. รับอ้างอิงของแผนภูมิผ่านดัชนีของมัน  
4. วนลูปผ่าน `DataPoints` ทั้งหมดของแผนภูมิและตั้งค่า `XValue` และ `YValue` เป็น null  
5. ลบ `DataPoints` ทั้งหมดสำหรับชุดข้อมูลแผนภูมิที่ระบุ  
6. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Java นี้แสดงการทำงาน:

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

## **ตั้งค่าความกว้างช่องว่างของชุดข้อมูล**

Aspose.Slides for Android ผ่าน Java ให้คุณตั้งค่าความกว้างช่องว่าง (Gap Width) ของชุดข้อมูลผ่านคุณสมบัติ **`GapWidth`** ได้ตามวิธีนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
1. เข้าถึงสไลด์แรก  
1. เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้น  
1. เข้าถึงชุดข้อมูลแผนภูมิใดก็ได้  
1. ตั้งค่าคุณสมบัติ `GapWidth`  
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Java นี้แสดงวิธีตั้งค่าความกว้างช่องว่างของชุดข้อมูล:

```java
// สร้างงานนำเสนอเปล่า 
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรกของงานนำเสนอ
    ISlide slide = pres.getSlides().get_Item(0);
    
    // เพิ่มแผนภูมิกับข้อมูลเริ่มต้น
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 0, 0, 500, 500);
    
    // ตั้งค่าดัชนีของแผ่นข้อมูลแผนภูมิ
    int defaultWorksheetIndex = 0;
    
    // รับแผ่นงานข้อมูลแผนภูมิ
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // เพิ่มชุดข้อมูล
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // เพิ่มประเภท
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // นำชุดข้อมูลแผนภูมิลำดับที่สอง
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // เติมข้อมูลชุดข้อมูล
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // ตั้งค่าค่า GapWidth
    series.getParentSeriesGroup().setGapWidth(50);
    
    // บันทึกงานนำเสนอไปยังดิสก์
    pres.save("GapWidth_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**มีขีดจำกัดจำนวนชุดข้อมูลที่แผนภูมิเดียวสามารถบรรจุได้หรือไม่?**

Aspose.Slides ไม่ได้กำหนดขีดจำกัดคงที่สำหรับจำนวนชุดข้อมูลที่คุณเพิ่ม เนื่องจากขีดจำกัดเชิงปฏิบัติขึ้นอยู่กับความอ่านง่ายของแผนภูมิและหน่วยความจำที่แอปพลิเคชันของคุณมี

**ถ้าคอลัมน์ภายในกลุ่มใกล้กันเกินไปหรือห่างกันเกินไปจะทำอย่างไร?**

ปรับค่าการตั้งค่า `GapWidth` สำหรับชุดข้อมูลนั้น (หรือกลุ่ม series พ่อแม่ของมัน) การเพิ่มค่าจะทำให้ช่องว่างระหว่างคอลัมน์กว้างขึ้น ส่วนการลดค่าจะทำให้คอลัมน์ใกล้กันมากขึ้น.