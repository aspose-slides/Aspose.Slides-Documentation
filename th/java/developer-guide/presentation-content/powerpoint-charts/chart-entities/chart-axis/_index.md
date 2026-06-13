---
title: กำหนดค่าแกนแผนภูมิในงานนำเสนอโดยใช้ Java
linktitle: แกนแผนภูมิ
type: docs
url: /th/java/chart-axis/
keywords:
- แกนแผนภูมิ
- แกนแนวตั้ง
- แกนแนวนอน
- กำหนดค่าแกน
- จัดการแกน
- ควบคุมแกน
- คุณสมบัติของแกน
- ค่าสูงสุด
- ค่าต่ำสุด
- เส้นแกน
- รูปแบบวันที่
- ชื่อแกน
- ตำแหน่งแกน
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ค้นพบวิธีใช้ Aspose.Slides for Java เพื่อกำหนดค่าแกนแผนภูมิในงานนำเสนอ PowerPoint สำหรับรายงานและการแสดงผลข้อมูล."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการปรับแต่งแกนของแผนภูมิใน Aspose.Slides มันแสดงวิธีการรับค่าจริงของแกน, สลับข้อมูลระหว่างแกน, ซ่อนแกนแนวตั้งหรือแนวนอนสำหรับแผนภูมิเส้น, เปลี่ยนประเภทของแกนประเภท, ตั้งรูปแบบวันที่สำหรับค่าของแกนประเภท, หมุนชื่อแกน, ตั้งตำแหน่งของแกน, และแสดงป้ายหน่วยบนแกนค่า

## **รับค่าสูงสุดบนแกนแนวตั้งของแผนภูมิ**
Aspose.Slides for Java ช่วยให้คุณสามารถรับค่าต่ำสุดและค่าสูงสุดบนแกนแนวตั้งได้ เริ่มทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)
1. เข้าถึงสไลด์แรก.
1. เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้น.
1. รับค่ามากสุดจริงบนแกน.
1. รับค่าต่ำสุดจริงบนแกน.
1. รับหน่วยหลักจริงของแกน.
1. รับหน่วยรองจริงของแกน.
1. รับสเกลหน่วยหลักจริงของแกน.
1. รับสเกลหน่วยรองจริงของแกน.

โค้ดตัวอย่างนี้—การนำขั้นตอนข้างต้นไปใช้—แสดงวิธีการรับค่าที่ต้องการใน Java:

```java
Presentation pres = new Presentation();
try {
	Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
	chart.validateChartLayout();

	double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
	double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

	double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
	double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();

	// บันทึกงานนำเสนอ
	pres.save("MaxValuesVerticalAxis_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **สลับข้อมูลระหว่างแกน**
Aspose.Slides ช่วยให้คุณสามารถสลับข้อมูลระหว่างแกนได้อย่างรวดเร็ว—ข้อมูลที่แสดงบนแกนแนวตั้ง (y-axis) จะย้ายไปยังแกนแนวนอน (x-axis) และในทางกลับกัน.

โค้ด Java นี้แสดงวิธีการทำงานสลับข้อมูลระหว่างแกนบนแผนภูมิ:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	// สลับแถวและคอลัมน์
	// บันทึกงานนำเสนอ
	pres.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **ปิดการใช้งานแกนแนวตั้งสำหรับแผนภูมิเส้น**

โค้ด Java นี้แสดงวิธีซ่อนแกนแนวตั้งสำหรับแผนภูมิเส้น:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
	chart.getAxes().getVerticalAxis().setVisible(false);

	pres.save("chart.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **ปิดการใช้งานแกนแนวนอนสำหรับแผนภูมิเส้น**

โค้ดนี้แสดงวิธีซ่อนแกนแนวนอนสำหรับแผนภูมิเส้น:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
	chart.getAxes().getHorizontalAxis().setVisible(false);

	pres.save("chart.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **เปลี่ยนแกนประเภท**

โดยใช้คุณสมบัติ **CategoryAxisType** คุณสามารถระบุประเภทของแกนประเภทที่ต้องการ (**date** หรือ **text**) โค้ด Java นี้แสดงการทำงาน:

```java
Presentation presentation = new Presentation("ExistingChart.pptx");
try {
	IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
	chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
	chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
	chart.getAxes().getHorizontalAxis().setMajorUnit(1);
	chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months);
	presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
} finally {
	if (presentation != null) presentation.dispose();
}
```

## **ตั้งรูปแบบวันที่สำหรับค่าของแกนประเภท**
Aspose.Slides for Java ช่วยให้คุณตั้งรูปแบบวันที่สำหรับค่าของแกนประเภท การทำงานนี้แสดงในโค้ด Java นี้:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 50, 50, 450, 300);

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", convertToOADate(new GregorianCalendar(2015, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", convertToOADate(new GregorianCalendar(2016, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", convertToOADate(new GregorianCalendar(2017, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", convertToOADate(new GregorianCalendar(2018, 1, 1))));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B2", 1));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B3", 2));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B4", 3));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B5", 4));
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");
	
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
```java
public static String convertToOADate(GregorianCalendar date) throws ParseException
{
    double oaDate;
    SimpleDateFormat myFormat = new SimpleDateFormat("dd MM yyyy");
    java.util.Date baseDate = myFormat.parse("30 12 1899");
    Long days = TimeUnit.DAYS.convert(date.getTimeInMillis() - baseDate.getTime(), TimeUnit.MILLISECONDS);
    oaDate = (double) days + ((double) date.get(Calendar.HOUR_OF_DAY) / 24) + ((double) date.get(Calendar.MINUTE) / (60 * 24)) + ((double) date.get(Calendar.SECOND) / (60 * 24 * 60));
    return String.valueOf(oaDate);
}
```

## **ตั้งมุมการหมุนสำหรับชื่อแกนของแผนภูมิ**
Aspose.Slides for Java ช่วยให้คุณตั้งมุมการหมุนสำหรับชื่อแกนของแผนภูมิ โค้ด Java นี้แสดงการทำงาน:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}

```

## **ตั้งตำแหน่งของแกนบนแกนประเภทหรือแกนค่า**
Aspose.Slides for Java ช่วยให้คุณตั้งตำแหน่งของแกนในแกนประเภทหรือแกนค่า โค้ด Java นี้แสดงวิธีทำงาน:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **เปิดใช้งานการแสดงป้ายหน่วยบนแกนค่าของแผนภูมิ**
Aspose.Slides for Java ช่วยให้คุณกำหนดให้แผนภูมิแสดงป้ายหน่วยบนแกนค่าของแผนภูมิ โค้ด Java นี้แสดงการทำงาน:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);

    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions);
    
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**ฉันจะตั้งค่าที่หนึ่งแกนข้ามอีกแกน (การข้ามแกน) ได้อย่างไร?**

แกนให้ [การตั้งค่าการข้าม](https://reference.aspose.com/slides/th/java/com.aspose.slides/axis/#setCrossType-int-): คุณสามารถเลือกให้ข้ามที่ศูนย์, ที่ค่าตัวสุดของประเภท/ค่า, หรือที่ค่าตัวเลขเฉพาะ การทำเช่นนี้เป็นประโยชน์สำหรับการเลื่อนแกน X ขึ้นหรือลงหรือเพื่อเน้นเส้นฐาน

**ฉันจะกำหนดตำแหน่งของป้ายติ๊กสัมพันธ์กับแกน (ข้างเคียง, ด้านนอก, ด้านใน) อย่างไร?**

ตั้งค่า [ตำแหน่งป้าย](https://reference.aspose.com/slides/th/java/com.aspose.slides/axis/#setMajorTickMark-int-) เป็น "cross", "outside" หรือ "inside" การตั้งค่านี้ส่งผลต่อความอ่านง่ายและช่วยประหยัดพื้นที่ โดยเฉพาะบนแผนภูมิขนาดเล็ก