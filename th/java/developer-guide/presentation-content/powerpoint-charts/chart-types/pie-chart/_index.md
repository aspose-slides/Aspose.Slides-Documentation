---
title: ปรับแต่งแผนภูมิวงกลมในการนำเสนอด้วย Java
linktitle: แผนภูมิวงกลม
type: docs
url: /th/java/pie-chart/
keywords:
- แผนภูมิวงกลม
- จัดการแผนภูมิ
- ปรับแต่งแผนภูมิ
- ตัวเลือกแผนภูมิ
- การตั้งค่าแผนภูมิ
- ตัวเลือกพล็อต
- สีสไลซ์
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "สร้างและปรับแต่งแผนภูมิวงกลมใน Java ด้วย Aspose.Slides กำหนดค่าพล็อตที่สอง แสดงป้ายข้อมูล และใช้สีสไลซ์อัตโนมัติใน PowerPoint."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับแผนภูมิวงกลมใน Aspose.Slides โดยแสดงวิธีกำหนดค่าตัวเลือกพล็อตที่สองสำหรับแผนภูมิ Pie of Pie และ Bar of Pie รวมถึงวิธีเปิดใช้การกำหนดสีชิ้นอัตโนมัติสำหรับแผนภูมิกลือดมาตรฐาน

ตัวอย่างมุ่งเน้นที่งานปรับแต่งแผนภูมิ เช่น การเพิ่มแผนภูมิลงในสไลด์ การปรับตั้งค่าชุดข้อมูลและป้ายกำกับ การแทนที่ข้อมูลแผนภูมิดีฟอลต์ด้วยหมวดหมู่และค่าที่กำหนดเอง และการบันทึกงานนำเสนอที่อัปเดต

## **ตัวเลือกพล็อตที่สองสำหรับแผนภูมิ Pie of Pie และ Bar of Pie**

Aspose.Slides for Java รองรับตัวเลือกพล็อตที่สองสำหรับแผนภูมิ Pie of Pie และ Bar of Pie ตัวเลือกเหล่านี้ควบคุมขนาดของพล็อตที่สองและวิธีที่จุดข้อมูลถูกแบ่งระหว่างสองพล็อต

ตัวอย่างต่อไปนี้สร้างแผนภูมิ Pie of Pie ในงานนำเสนอใหม่และแสดงค่าจุดข้อมูลเป็นป้ายกำกับ วิธีการ [setSecondPieSize](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setSecondPieSize-int-) กำหนดขนาดพล็อตที่สองเป็น 149% ของพล็อตหลัก [setPieSplitBy](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) เลือกการแยกตามเปอร์เซ็นต์ และ [setPieSplitPosition](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setPieSplitPosition-double-) กำหนดค่าธรณีเป็น 53%

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // แสดงค่าและกำหนดพล็อตที่สอง
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setSecondPieSize(149);
    seriesGroup.setPieSplitBy(PieSplitType.ByPercentage);
    seriesGroup.setPieSplitPosition(53);

    presentation.save("pie_of_pie.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **เลือกหมวดหมู่สำหรับพล็อตที่สอง**

ใช้การแยกแบบกำหนดเองเมื่อต้องการจัดกลุ่มหมวดหมู่เฉพาะในพล็อตที่สองโดยไม่คำนึงถึงค่าร้อยละของพวกมัน ตัวอย่างเช่น รายงานการขายอาจแสดง Online และ Events ร่วมกันเพื่อให้ผู้อ่านเปรียบเทียบสองช่องทางนี้แม้ว่าจะเป็น 35% และ 10% ของยอดขายทั้งหมด

เรียกใช้ [setPieSplitBy](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) พร้อมกับ [PieSplitType.Custom](https://reference.aspose.com/slides/java/com.aspose.slides/piesplittype/#Custom) และเลือกจุดผ่าน [getPieSplitCustomPoints](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#getPieSplitCustomPoints--). วิธีการ [add](https://reference.aspose.com/slides/java/com.aspose.slides/piesplitcustompointcollection/#add-int-) ของคอลเลกชันรับดัชนีเริ่มจากศูนย์ในชุดข้อมูล; ใช้ [addItem](https://reference.aspose.com/slides/java/com.aspose.slides/piesplitcustompointcollection/#addItem-com.aspose.slides.IChartDataPoint-) เพื่อเพิ่มอ็อบเจกต์จุดข้อมูล ในตัวอย่างนี้ ดัชนี 1 เลือก Online และจุดที่ดัชนี 3 เลือก Events Partners ถูกเพิ่มชั่วคราวแล้วถูกลบออกโดยใช้ [removeItem](https://reference.aspose.com/slides/java/com.aspose.slides/piesplitcustompointcollection/#removeItem-com.aspose.slides.IChartDataPoint-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 200);

    // แทนที่ข้อมูลเริ่มต้นด้วยยอดขายตามช่องทาง
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    String[] categoryNames = { "Retail", "Online", "Partners", "Events" };
    int[] values = { 40, 35, 15, 10 };
    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Sales");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (int i = 0; i < categoryNames.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setPieSplitBy(PieSplitType.Custom);
    seriesGroup.setColorVaried(true);

    // เลือก Online ตามดัชนีเริ่มจากศูนย์และ Events ตามอ็อบเจกต์จุดข้อมูล
    seriesGroup.getPieSplitCustomPoints().add(1);
    seriesGroup.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3));

    // ตัด Partners ออกจากการเลือกโดยไม่ลบข้อมูลต้นทาง
    seriesGroup.getPieSplitCustomPoints().add(2);
    seriesGroup.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2));

    presentation.save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Online (35) และ Events (10) ปรากฏเป็นสไลซ์แยกกันในพล็อตที่สอง ในพล็อตหลัก พวกมันจะรวมเป็นสไลซ์เดียวที่มีค่า 45 พร้อมกับ Retail (40) และ Partners (15) การลบ Partners จากการเลือกแบบกำหนดเองทำให้มันยังคงอยู่ในพล็อตหลัก; ไม่ได้ลบหมวดหมู่หรือค่าของมันจากข้อมูลต้นทางของแผนภูมิ

ภาพต่อไปนี้แสดงงานนำเสนอที่บันทึกใน PowerPoint:

![แผนภูมิ Pie of Pie ที่มี Online และ Events ในพล็อตที่สองและค่ารวม 45 ในพล็อตหลัก](pie_of_pie_custom.png)

## **ตั้งค่าสีชิ้นของแผนภูมิวงกลมโดยอัตโนมัติ**

Aspose.Slides for Java สามารถกำหนดสีที่แตกต่างให้กับสไลซ์ของแผนภูมิวงกลมโดยอัตโนมัติ ตัวอย่างต่อไปนี้สร้างแผนภูมิวงกลมที่มีหัวเรื่องอยู่ตรงกลางและแทนที่ข้อมูลเริ่มต้นด้วยสามหมวดไตรมาสพร้อมค่าของแต่ละหมวด วิธีการ [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) แสดงค่า 20, 50, และ 30 เป็นป้ายกำกับ ในขณะเดียวกัน [setColorVaried](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setColorVaried-boolean-) เปิดใช้สีที่แตกต่างสำหรับแต่ละสไลซ์

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // เพิ่มหัวเรื่องแผนภูมิที่ศูนย์กลาง
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // แทนที่ข้อมูลเริ่มต้นโดยใช้แผ่นงานแรก
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    String[] categoryNames = { "First Qtr", "2nd Qtr", "3rd Qtr" };
    int[] values = { 20, 50, 30 };
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (int i = 0; i < categoryNames.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    // แสดงค่าและกำหนดสีที่แตกต่างให้กับสไลซ์
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getParentSeriesGroup().setColorVaried(true);

    presentation.save("pie.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**รูปแบบ Pie of Pie และ Bar of Pie ได้รับการสนับสนุนหรือไม่?**

ใช่, ไลบรารี [สนับสนุน](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) พล็อตที่สองสำหรับแผนภูมิวงกลมรวมถึงประเภท Pie of Pie และ Bar of Pie

**ฉันสามารถส่งออกแผนภูมิเพียงอย่างเดียวเป็นภาพ (เช่น PNG) ได้หรือไม่?**

ใช่, คุณสามารถ [ส่งออกแผนภูมิเองเป็นภาพ](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage--) (เช่น PNG) ได้โดยไม่ต้องส่งออกงานนำเสนอทั้งหมด