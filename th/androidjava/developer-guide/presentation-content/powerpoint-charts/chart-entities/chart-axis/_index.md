---
title: ปรับแต่งแกนแผนภูมิในงานนำเสนอบน Android
linktitle: แกนแผนภูมิ
type: docs
url: /th/androidjava/chart-axis/
keywords:
- แกนแผนภูมิ
- แกนแนวตั้ง
- แกนแนวนอน
- ปรับแต่งแกน
- จัดการแกน
- จัดการแกน
- คุณสมบัติของแกน
- ค่าสูงสุด
- ค่าต่ำสุด
- เส้นแกน
- รูปแบบวันที่
- ชื่อแกน
- ตำแหน่งแกน
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ค้นพบวิธีการใช้ Aspose.Slides for Android ผ่าน Java เพื่อปรับแต่งแกนแผนภูมิในงานนำเสนอ PowerPoint สำหรับรายงานและการแสดงภาพ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการปรับแต่งแกนแผนภูมิใน Aspose.Slides โดยแสดงวิธีการดึงค่าจริงของแกน, สลับข้อมูลระหว่างแกน, ซ่อนแกนแนวตั้งหรือแนวนอนสำหรับแผนภูมิเส้น, เปลี่ยนประเภทของแกนหมวดหมู่, ตั้งค่ารูปแบบวันที่สำหรับค่าของแกนหมวดหมู่, หมุนหัวข้อแกน, ตั้งตำแหน่งแกน, และแสดงป้ายหน่วยบนแกนค่า

## **รับค่าสูงสุดบนแกนแนวตั้งของแผนภูมิ**
Aspose.Slides for Android via Java อนุญาตให้คุณรับค่าต่ำสุดและค่าสูงสุดบนแกนแนวตั้ง ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)
2. เข้าถึงสไลด์แรก
3. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้น
4. รับค่ามากสุดจริงบนแกน
5. รับค่าต่ำสุดจริงบนแกน
6. รับค่าหน่วยหลักจริงของแกน
7. รับค่าหน่วยรองจริงของแกน
8. รับสเกลหน่วยหลักจริงของแกน
9. รับสเกลหน่วยรองจริงของแกน

โค้ดตัวอย่าง—การนำขั้นตอนข้างต้นมาประยุกต์—แสดงวิธีรับค่าที่ต้องการใน Java:

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
Aspose.Slides อนุญาตให้คุณสลับข้อมูลระหว่างแกนได้อย่างรวดเร็ว—ข้อมูลที่แสดงบนแกนแนวตั้ง (y-axis) จะย้ายไปยังแกนแนวนอน (x-axis) และกลับกัน

โค้ด Java นี้แสดงวิธีทำการสลับข้อมูลระหว่างแกนบนแผนภูมิ:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	//สลับแถวและคอลัมน์
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

## **เปลี่ยนแกนหมวดหมู่**

โดยใช้คุณสมบัติ **CategoryAxisType** คุณสามารถระบุประเภทของแกนหมวดหมู่ที่ต้องการ (**date** หรือ **text**) โค้ดใน Java นี้แสดงการทำงาน:

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

## **ตั้งค่ารูปแบบวันที่สำหรับค่าของแกนหมวดหมู่**
Aspose.Slides for Android via Java อนุญาตให้คุณตั้งค่ารูปแบบวันที่สำหรับค่าของแกนหมวดหมู่ การทำงานนี้แสดงในโค้ด Java นี้:

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

## **ตั้งค่ามุมหมุนสำหรับหัวข้อแกนแผนภูมิ**
Aspose.Slides for Android via Java อนุญาตให้คุณตั้งค่ามุมหมุนสำหรับหัวข้อแกนแผนภูมิ โค้ด Java นี้แสดงการทำงาน:

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

## **ตั้งตำแหน่งแกนบนแกนหมวดหมู่หรือค่า**
Aspose.Slides for Android via Java อนุญาตให้คุณตั้งตำแหน่งแกนในแกนหมวดหมู่หรือค่า โค้ด Java นี้แสดงวิธีทำ:

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
Aspose.Slides for Android via Java อนุญาตให้คุณกำหนดค่าให้แผนภูมิแสดงป้ายหน่วยบนแกนค่าของแผนภูมิ โค้ด Java นี้แสดงการทำงาน:

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

## **คำถามที่พบบ่อย**

**ฉันจะตั้งค่าค่าที่แกนหนึ่งตัดผ่านแกนอื่น (การตัดแกน) อย่างไร?**

แกนมีการตั้งค่า [crossing setting](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/axis/#setCrossType-int-): คุณสามารถเลือกให้ตัดที่ศูนย์, ที่ค่ามากสุดของหมวดหมู่/ค่า, หรือที่ค่าตัวเลขเฉพาะ ซึ่งมีประโยชน์สำหรับการเลื่อนแกน X ขึ้นหรือลงหรือเพื่อเน้นเส้นฐาน

**ฉันจะวางตำแหน่งป้ายระดับ (tick labels) เพื่อให้สัมพันธ์กับแกน (ข้างเคียง, นอก, ใน) อย่างไร?**

ตั้งค่า [label position](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) เป็น "cross", "outside", หรือ "inside" สิ่งนี้ส่งผลต่อความอ่านง่ายและช่วยประหยัดพื้นที่โดยเฉพาะบนแผนภูมิขนาดเล็ก