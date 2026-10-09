---
title: จัดการป้ายข้อมูลแผนภูมิในงานนำเสนอโดยใช้ Java
linktitle: ป้ายข้อมูล
type: docs
url: /th/java/chart-data-label/
keywords:
- แผนภูมิ
- ป้ายข้อมูล
- ความแม่นยำของข้อมูล
- เปอร์เซ็นต์
- ระยะห่างของป้าย
- ตำแหน่งของป้าย
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่มและจัดรูปแบบป้ายข้อมูลแผนภูมิในงานนำเสนอ PowerPoint ด้วย Aspose.Slides for Java เพื่อให้สไลด์น่าสนใจมากยิ่งขึ้น."
---
## **บทนำ**

ป้ายข้อมูลแสดงข้อมูลเกี่ยวกับชุดข้อมูลของแผนภูมิและจุดข้อมูลแต่ละจุด ช่วยให้ผู้อ่านระบุค่าและเข้าใจแผนภูมิได้ บทความนี้อธิบายวิธีจัดรูปแบบค่า แสดงเปอร์เซ็นต์ อ่านข้อความป้าย ควบคุมป้ายที่อยู่นอกขีดจำกัดของแกน ปรับระยะห่างของป้ายแกนประเภท และกำหนดตำแหน่งของป้ายในแผนภูมิพาย

## **ตั้งค่าความแม่นยำของข้อมูลในป้ายข้อมูลแผนภูมิ**

ใช้ [setNumberFormatOfValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setNumberFormatOfValues-java.lang.String-) เพื่อจัดรูปแบบค่าชุดข้อมูล ตัวอย่างนี้สร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้น แสดงตารางข้อมูลและเปิดใช้ป้ายค่าสำหรับชุดแรก รูปแบบ `#,##0.00` จะแสดงเครื่องหมายคั่นหลักพันและทศนิยมสองตำแหน่งโดยไม่เปลี่ยนค่าที่อยู่ภายใต้

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);
    chart.setDataTable(true);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    series.setNumberFormatOfValues("#,##0.00");
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **แสดงเปอร์เซ็นต์เป็นป้าย**

สำหรับแผนภูมิคอลัมน์แบบซ้อนกัน คำนวณค่าทุกค่าเป็นเปอร์เซ็นต์ของยอดรวมประเภทนั้นแล้วกำหนดข้อความไปยังกรอบข้อความที่ได้จาก [getTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--) ตัวอย่างนี้ใช้ข้อมูลแผนภูมิปริยายและแสดงเปอร์เซ็นต์ด้วยทศนิยมสองตำแหน่งในฟอนต์ขนาด 8 จุด หมวดหมู่ที่มียอดรวมเป็นศูนย์จะถูกข้ามเพื่อหลีกเลี่ยงการหารด้วยศูนย์ หากข้อมูลแผนภูมิเปลี่ยนแปลงให้คำนวณข้อความป้ายแบบกำหนดใหม่

```java
import com.aspose.slides.*;
import java.util.Locale;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400);

    double[] categoryTotals = new double[chart.getChartData().getCategories().size()];
    for (int k = 0; k < chart.getChartData().getCategories().size(); k++) {
        for (int i = 0; i < chart.getChartData().getSeries().size(); i++) {
            IChartSeries series = chart.getChartData().getSeries().get_Item(i);
            Number pointValue = (Number) series.getDataPoints().get_Item(k).getValue().getData();
            categoryTotals[k] += pointValue.doubleValue();
        }
    }

    for (int x = 0; x < chart.getChartData().getSeries().size(); x++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);

        for (int j = 0; j < series.getDataPoints().size(); j++) {
            IDataLabel label = series.getDataPoints().get_Item(j).getLabel();
            if (categoryTotals[j] == 0) {
                continue;
            }

            Number pointValue = (Number) series.getDataPoints().get_Item(j).getValue().getData();
            double dataPointPercent = (pointValue.doubleValue() / categoryTotals[j]) * 100;

            IPortion portion = new Portion();
            portion.setText(String.format(Locale.US, "%.2f %%", dataPointPercent));
            portion.getPortionFormat().setFontHeight(8f);

            label.getTextFrameForOverriding().setText("");
            IParagraph paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0);
            paragraph.getPortions().add(portion);

            label.getDataLabelFormat().setShowValue(true);
            label.getDataLabelFormat().setShowSeriesName(false);
            label.getDataLabelFormat().setShowPercentage(false);
            label.getDataLabelFormat().setShowLegendKey(false);
            label.getDataLabelFormat().setShowCategoryName(false);
            label.getDataLabelFormat().setShowBubbleSize(false);
        }
    }

    presentation.save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าสัญลักษณ์เปอร์เซ็นต์กับป้ายข้อมูลแผนภูมิ**

เมื่อค่าถูกจัดเก็บเป็นเศษส่วน ใช้ [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) เพื่อแสดงเปอร์เซ็นต์ ส่งค่า `false` ไปยัง [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) เพื่อให้รูปแบบป้ายทำงานแยกจากเซลล์ต้นทาง

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบซ้อน 100% ด้วยชุดสีแดงและสีน้ำเงินในสี่ประเภท แต่ละคู่ค่ารวมกันได้ 1 รูปแบบป้าย `0.0%` จะแสดง 0.30 เป็น 30.0% ขณะที่แกนแนวตั้งใช้ทศนิยมสองตำแหน่ง ทั้งสองชุดใช้ข้อความป้ายสีขาวขนาด 10 จุด

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;
    for (int i = 0; i < 4; i++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    String[] seriesNames = { "Reds", "Blues" };
    Color[] seriesColors = { Color.RED, Color.BLUE };
    double[][] values = { { 0.30, 0.50, 0.80, 0.65 }, { 0.70, 0.50, 0.20, 0.35 } };

    for (int i = 0; i < seriesNames.length; i++) {
        IChartDataCell seriesCell = workbook.getCell(worksheetIndex, 0, i + 1, seriesNames[i]);
        IChartSeries series = chart.getChartData().getSeries().add(seriesCell, chart.getType());
        for (int j = 0; j < 4; j++) {
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, j + 1, i + 1, values[i][j]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        series.getFormat().getFill().setFillType(FillType.Solid);
        series.getFormat().getFill().getSolidFillColor().setColor(seriesColors[i]);

        IDataLabelFormat labelFormat = series.getLabels().getDefaultDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(false);
        labelFormat.setNumberFormat("0.0%");
        labelFormat.getTextFormat().getPortionFormat().setFontHeight(10);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    }

    presentation.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **อ่านข้อความจริงของป้ายข้อมูล**

ใช้ [getActualLabelText](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#getActualLabelText--) เพื่อดึงข้อความที่สร้างโดยการตั้งค่าป้ายข้อมูล ซึ่งมีประโยชน์เมื่อต้องสกัดป้ายสำหรับรายงาน ค้นหาเนื้อหาในงานนำเสนอ หรือทำการตรวจสอบแผนภูมิที่สร้างขึ้น ในตัวอย่างด้านล่าง รูปแบบป้ายข้อมูลปริยาย [data label format](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/) จะรวมชื่อประเภท ชื่อชุดข้อมูล และค่า จุดหนึ่งจัดรูปแบบค่าของมันเป็นเปอร์เซ็นต์ และอีกจุดหนึ่งใช้ข้อความกำหนดเองจาก [getTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell firstCategoryCell = workbook.getCell(0, 1, 0, "Q1");
    chart.getChartData().getCategories().add(firstCategoryCell);
    IChartDataCell secondCategoryCell = workbook.getCell(0, 2, 0, "Q2");
    chart.getChartData().getCategories().add(secondCategoryCell);

    IChartDataCell northSeriesCell = workbook.getCell(0, 0, 1, "North");
    IChartSeries north = chart.getChartData().getSeries().add(northSeriesCell, chart.getType());
    IChartDataCell northFirstValueCell = workbook.getCell(0, 1, 1, 0.25);
    north.getDataPoints().addDataPointForBarSeries(northFirstValueCell);
    IChartDataCell northSecondValueCell = workbook.getCell(0, 2, 1, 0.75);
    north.getDataPoints().addDataPointForBarSeries(northSecondValueCell);

    IChartDataCell southSeriesCell = workbook.getCell(0, 0, 2, "South");
    IChartSeries south = chart.getChartData().getSeries().add(southSeriesCell, chart.getType());
    IChartDataCell southFirstValueCell = workbook.getCell(0, 1, 2, 0.40);
    south.getDataPoints().addDataPointForBarSeries(southFirstValueCell);
    IChartDataCell southSecondValueCell = workbook.getCell(0, 2, 2, 0.60);
    south.getDataPoints().addDataPointForBarSeries(southSecondValueCell);

    for (IChartSeries series : chart.getChartData().getSeries()) {
        IDataLabelFormat format = series.getLabels().getDefaultDataLabelFormat();
        format.setShowCategoryName(true);
        format.setShowSeriesName(true);
        format.setShowValue(true);
    }

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(false);
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%");
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed");

    for (IChartSeries series : chart.getChartData().getSeries()) {
        for (IChartDataPoint point : series.getDataPoints()) {
            IDataLabel label = point.getLabel();
            if (!label.isVisible()) {
                continue;
            }

            System.out.println("Value: " + point.getValue().getData() + "; label: " + label.getActualLabelText());
        }
    }
} finally {
    presentation.dispose();
}
```

ตัวเลขที่จัดเก็บในจุดข้อมูลคงเป็น `0.75` แม้ป้ายจะแสดงเป็น `75%` พร้อมชื่อประเภทและชุดข้อมูล ข้อความกำหนดเองจะทับข้อความป้ายที่สร้างโดยอัตโนมัติ [getActualLabelText](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#getActualLabelText--) จะคืนสตริงของป้ายที่ได้ในทั้งสองกรณี ตรวจสอบ [isVisible](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#isVisible--) แยกต่างหากตามที่แสดงข้างต้นเมื่อคุณต้องการสกัดเฉพาะป้ายที่มองเห็นได้

## **ควบคุมป้ายข้อมูลที่อยู่นอกขีดจำกัดของแกน**

เมื่อคุณกำหนดขอบเขตแกนด้วยตนเอง บางจุดข้อมูลอาจเกินค่าสูงสุดของแกน ใช้ [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setShowDataLabelsOverMaximum-boolean-) เพื่อควบคุมว่าป้ายข้อมูลของจุดที่เกินจะแสดงหรือไม่ การตั้งค่านี้เปลี่ยนการมองเห็นของป้ายเท่านั้น ไม่ได้เปลี่ยนขอบเขตแกนหรือค่าข้อมูลพื้นฐาน

ตัวอย่างด้านล่างสร้างแผนภูมิคอลัมน์แบบคลัสเตอร์ 2D ด้วยค่าที่ 60 และ 120 โดยส่งค่า `false` ไปยัง [setAutomaticMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticMaxValue-boolean-) และกำหนดค่าสูงสุดเป็น 100 ด้วย [setMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMaxValue-double-) บนแกนแนวตั้ง สไลด์แรกอนุญาตให้ป้ายแสดงเหนือค่าสูงสุด; สไลด์สำเนาที่คัดลอกมาจะปิดการแสดงนั้น ทั้งสองสไลด์ถูกบันทึกเป็น `DataLabelsOverMaximum.pptx`

เปิดใช้ป้ายค่าด้วย [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) การตั้งค่าระดับแผนภูมิไม่ได้เปิดการแสดงค่าตามลำพังหรือเขียนทับการปิดแสดงค่าของป้ายเดี่ยว ตัวอย่างนี้เปิดค่าตลอดชุดข้อมูลแล้วใช้ [setPosition](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setPosition-int-) เพื่อตำแหน่งป้ายที่ปลายนอกของแต่ละคอลัมน์

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    IChartDataCell firstCategory = workbook.getCell(0, 1, 0, "Within range");
    IChartDataCell secondCategory = workbook.getCell(0, 2, 0, "Above maximum");

    chart.getChartData().getCategories().add(firstCategory);
    chart.getChartData().getCategories().add(secondCategory);

    IChartDataCell seriesName = workbook.getCell(0, 0, 1, "Values");
    IChartSeries series = chart.getChartData().getSeries().add(seriesName, chart.getType());

    IChartDataCell firstValue = workbook.getCell(0, 1, 1, 60);
    IChartDataCell secondValue = workbook.getCell(0, 2, 1, 120);

    series.getDataPoints().addDataPointForBarSeries(firstValue);
    series.getDataPoints().addDataPointForBarSeries(secondValue);

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd);

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(100);
    chart.setShowDataLabelsOverMaximum(true);

    ISlide secondSlide = presentation.getSlides().addClone(slide);
    IChart secondChart = (IChart) secondSlide.getShapes().get_Item(0);
    secondChart.setShowDataLabelsOverMaximum(false);

    presentation.save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ภาพต่อไปนี้แสดงสไลด์ที่บันทึกและแสดงผลโดย Microsoft PowerPoint เมื่อตั้งค่าเป็น `true` ป้าย **120** จะมองเห็นได้ที่ขอบบน; เมื่อตั้งค่าเป็น `false` ป้ายจะถูกซ่อน ป้าย **60** ยังคงมองเห็นได้ ขีดจำกัดของแกนยังคงเป็น **100** และจุดข้อมูลที่สองยังคงเป็น **120** ในทั้งสองกรณี

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![แผนภูมิ PowerPoint แสดงป้ายค่าที่ 120 กับขีดจำกัดแกนที่ 100](data-labels-over-maximum-true.png) | ![แผนภูมิ PowerPoint ซ่อนป้ายค่าที่ 120 กับขีดจำกัดแกนที่ 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
ตัวอย่างนี้ใช้แผนภูมิคอลัมน์ 2D พร้อมแกนค่า แผนภูมิที่ไม่มีแกนค่า เช่น แผนภูมิพายและโดนัท จะไม่มีขีดจำกัดของแกนที่สามารถกำหนดได้ในลักษณะนี้
{{% /alert %}}

## **ตั้งค่าระยะห่างของป้ายจากแกน**

ใช้ [setLabelOffset](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setLabelOffset-int-) เพื่อควบคุมระยะห่างระหว่างป้ายแกนประเภทกับแกน ค่านี้เป็นเปอร์เซ็นต์ของขนาดฟอนต์สูงสุดของป้ายแกน ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบคลัสเตอร์และกำหนดค่าออฟเซ็ตป้ายแกนแนวนอนเป็น 500 การตั้งค่านี้มีผลต่อป้ายแกนประเภท ไม่ใช่ป้ายที่แนบกับจุดข้อมูลแต่ละจุด

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.getAxes().getHorizontalAxis().setLabelOffset(500);

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ปรับตำแหน่งป้าย**

บนแผนภูมีพาย ปรับตำแหน่งป้ายข้อมูลเพื่อให้ระยะห่างดีขึ้นและให้มีพื้นที่สำหรับเส้นนำ

ตัวอย่างนี้แสดงค่าของจุดข้อมูลแรก วางป้ายด้านนอกสไลซ์ และปรับออฟเซ็ตแนวนอนและตั้งแนวตั้งโดยใช้ [setX](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setX-float-) และ [setY](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setY-float-) ออฟเซ็ตเหล่านี้อิงตามความกว้างและความสูงของแผนภูมิตามลำดับ

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 200, 200);
    IChartSeriesCollection series = chart.getChartData().getSeries();

    IDataLabel label = series.get_Item(0).getLabels().get_Item(0);
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd);
    label.setX(0.71f);
    label.setY(0.04f);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![แผนภูมิพายพร้อมตำแหน่งป้ายข้อมูลที่ปรับแล้ว](pie-chart-adjusted-label.png)

## **เพิ่มหลายแถวของป้ายข้อมูลเหนือแผนภูมิคอลัมน์**

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์พร้อมสองแถวของป้ายข้อมูลเหนือพื้นที่กราฟ ชุดข้อมูล A แสดงคอลัมน์ที่มองเห็นได้ ส่วนชุดข้อมูล B และ C ให้ป้ายเพิ่มเติม คอลัมน์ของพวกเขาถูกซ่อนไว้โดยลบการเติมสีและขอบ เส้นวิธี [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/chartseriesgroup/) ทำให้ทั้งสามชุดสอดคล้องกับศูนย์กลางประเภทเดียวกัน

การตั้งค่า [ChartPlotArea](https://reference.aspose.com/slides/java/com.aspose.slides/chartplotarea/) จัดสรรพื้นที่สำหรับแถวป้าย หลังจากที่ [Chart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/) คำนวณตำแหน่งเริ่มต้นแล้ว [DataLabel.setX และ DataLabel.setY](https://reference.aspose.com/slides/java/com.aspose.slides/datalabel/) จะรักษาการจัดแนวนอนและใช้การออฟเซ็ตแนวตั้งเพื่อจัดเรียงป้ายเป็นสองแถว ตัวเลขยังคงเป็นป้ายข้อมูลที่เชื่อมโยงกับค่าชุด แต่หัวข้อแถวเป็นรูปแบบข้อความแยกต่างหาก

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 40, 40, 640, 200);
    chart.setTitle(false);
    chart.setLegend(false);
    chart.getTextFormat().getPortionFormat().setFontHeight(12);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    String[] categories = {"North", "South", "East", "West"};
    String[] seriesNames = {"Series A", "Series B", "Series C"};
    double[][] seriesValues = {
            {35, 42, 28, 47},
            {22, 31, 19, 26},
            {12, 16, 14, 18}
    };

    for (int categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
        chart.getChartData().getCategories().add(
                workbook.getCell(0, categoryIndex + 1, 0, categories[categoryIndex]));
    }

    for (int seriesIndex = 0; seriesIndex < seriesNames.length; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().add(
                workbook.getCell(0, 0, seriesIndex + 1, seriesNames[seriesIndex]),
                ChartType.ClusteredColumn);

        for (int categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            series.getDataPoints().addDataPointForBarSeries(workbook.getCell(
                    0, categoryIndex + 1, seriesIndex + 1,
                    seriesValues[seriesIndex][categoryIndex]));
        }

        if (seriesIndex > 0) {
            // ซ่อนคอลัมน์ของ B และ C แต่คงป้ายข้อมูลไว้
            series.getFormat().getFill().setFillType(FillType.NoFill);
            series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
            series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
            series.getLabels().getDefaultDataLabelFormat()
                    .getTextFormat().getPortionFormat().setFontHeight(12);
            IFillFormat labelFill = series.getLabels().getDefaultDataLabelFormat()
                    .getTextFormat().getPortionFormat().getFillFormat();
            labelFill.setFillType(FillType.Solid);
            labelFill.getSolidFillColor().setColor(java.awt.Color.BLACK);
            series.getLabels().getDefaultDataLabelFormat().setPosition(
                    LegendDataLabelPosition.InsideBase);
        }
    }

    // จัดตำแหน่งชุดข้อมูลทั้งสามให้ตรงกับศูนย์ประเภทเดียวกัน
    chart.getChartData().getSeries().get_Item(0)
            .getParentSeriesGroup().setOverlap((byte) 100);

    // ใช้เส้นกริดน้อยลงสำหรับตัวอย่างที่กะทัดรัดนี้
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setMajorUnit(10);

    // จองพื้นที่เหนือแผนภูมิสำหรับสองแถวของป้ายข้อมูล
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner);
    chart.getPlotArea().setX(0.15f);
    chart.getPlotArea().setY(0.32f);
    chart.getPlotArea().setWidth(0.80f);
    chart.getPlotArea().setHeight(0.48f);
    chart.validateChartLayout();

    for (int seriesIndex = 1; seriesIndex < seriesNames.length; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        float rowTop = seriesIndex == 1 ? 0.15f : 0.03f;

        for (int categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            IDataLabel dataLabel = series.getDataPoints().get_Item(categoryIndex).getLabel();
            // คงตำแหน่งแนวนอนเริ่มต้น. Y คือการออฟเซ็ตจาก
            // ตำแหน่งป้ายเริ่มต้น, แสดงเป็นส่วนของความสูงแผนภูมิ
            dataLabel.setX(0);
            dataLabel.setY(rowTop - dataLabel.getActualY() / chart.getHeight());
        }

        // เฉพาะหัวแถวเป็นรูปแบบข้อความแยกต่างหาก
        IAutoShape rowHeading = slide.getShapes().addAutoShape(
                ShapeType.Rectangle, chart.getX(),
                chart.getY() + rowTop * chart.getHeight(), 85, 18);
        rowHeading.getFillFormat().setFillType(FillType.NoFill);
        rowHeading.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        rowHeading.addTextFrame(seriesNames[seriesIndex]);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginTop(0);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginBottom(0);
        IPortionFormat headingFormat = rowHeading.getTextFrame().getParagraphs()
                .get_Item(0).getPortions().get_Item(0).getPortionFormat();
        headingFormat.setFontHeight(12);
        headingFormat.getFillFormat().setFillType(FillType.Solid);
        headingFormat.getFillFormat().getSolidFillColor().setColor(java.awt.Color.BLACK);
    }

    presentation.save("multiple-rows-of-labels.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**วิธีป้องกันไม่ให้ป้ายข้อมูลทับซ้อนกันในแผนภูมิที่แน่นหนา?**

ใช้การวางป้ายอัตโนมัติ เส้นนำ และลดขนาดฟอนต์; หากจำเป็นให้ซ่อนบางฟิลด์ (เช่น ประเภท) หรือแสดงป้ายเฉพาะค่าที่สุดข Extremes หรือจุดสำคัญเท่านั้น

**วิธีปิดการแสดงป้ายเฉพาะค่าศูนย์ ค่าเป็นลบ หรือค่าว่าง?**

กรองจุดข้อมูลก่อนเปิดใช้ป้ายและปิดการแสดงสำหรับค่าที่เป็น 0, ค่าลบ หรือค่าที่หายไปตามกฎที่กำหนด

**วิธีทำให้สไตล์ป้ายคงที่เมื่อส่งออกเป็น PDF/รูปภาพ?**

กำหนดฟอนต์และขนาดอย่างชัดเจน และตรวจสอบว่าฟอนต์นั้นมีอยู่ในสภาพแวดล้อมการเรนเดอร์เพื่อหลีกเลี่ยงการใช้ฟอนต์สำรอง