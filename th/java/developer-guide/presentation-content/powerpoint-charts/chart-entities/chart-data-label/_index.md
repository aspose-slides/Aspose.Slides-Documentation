---
title: จัดการป้ายข้อมูลแผนภูมิในการนำเสนอโดยใช้ Java
linktitle: ป้ายข้อมูล
type: docs
url: /th/java/chart-data-label/
keywords:
- แผนภูมิ
- ป้ายข้อมูล
- ความแม่นยำของข้อมูล
- เปอร์เซ็นต์
- ระยะห่างของป้าย
- ตำแหน่งป้าย
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่มและจัดรูปแบบป้ายข้อมูลแผนภูมิในการนำเสนอ PowerPoint โดยใช้ Aspose.Slides สำหรับ Java เพื่อสร้างสไลด์ที่น่าสนใจยิ่งขึ้น."
---
## **บทนำ**

ป้ายข้อมูลแสดงข้อมูลเกี่ยวกับชุดข้อมูลของแผนภูมิและจุดข้อมูลแต่ละจุด ช่วยให้ผู้อ่านระบุค่าและเข้าใจแผนภูมิได้ บทความนี้อธิบายวิธีการจัดรูปแบบค่า การแสดงเปอร์เซ็นต์ การอ่านข้อความป้าย การควบคุมป้ายที่อยู่นอกค่ามากสุดของแกน การปรับระยะห่างของป้ายแกนประเภท และการกำหนดตำแหน่งป้ายของแผนภูมิบาร์พาย

## **กำหนดความแม่นยำของข้อมูลในป้ายแผนภูมิ**

ใช้ [setNumberFormatOfValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setNumberFormatOfValues-java.lang.String-) เพื่อจัดรูปแบบค่าชุดข้อมูล ตัวอย่างนี้สร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้น แสดงตารางข้อมูลของแผนภูมิ และเปิดการแสดงป้ายค่าให้กับชุดแรก รูปแบบ `#,##0.00` แสดงเครื่องหมายคั่นหลักพันและทศนิยมสองตำแหน่งโดยไม่เปลี่ยนค่าเดิม

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

หากต้องการจัดรูปแบบเซลล์ตัวเลขในตารางงานที่ฝังอยู่ของแผนภูมิ ให้ดู [Set Custom Number Formats for Workbook Cells](/slides/th/java/chart-workbook/#set-custom-number-formats-for-workbook-cells) ตัวอย่างนั้นยังแสดงให้เห็นว่าป้ายค่าจะใช้รูปแบบเซลล์ต้นทางโดยคงค่าตัวเลขเดิมไว้

## **แสดงเปอร์เซ็นต์เป็นป้าย**

สำหรับแผนภูมิคอลัมน์แบบซ้อนกัน ให้คำนวณแต่ละค่าเป็นเปอร์เซ็นต์ของผลรวมประเภทและกำหนดข้อความให้กับกรอบข้อความที่คืนโดย [getTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--) ตัวอย่างนี้ใช้ข้อมูลแผนภูมิโด้นเริ่มต้นและแสดงเปอร์เซ็นต์ด้วยทศนิยมสองตำแหน่งในฟอนต์ขนาด 8 จุด ประเภทที่ผลรวมเป็นศูนย์จะถูกข้ามเพื่อหลีกเลี่ยงการหารด้วยศูนย์ หากข้อมูลแผนภูมิมีการเปลี่ยนแปลง ให้คำนวณข้อความป้ายที่กำหนดใหม่

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

## **ตั้งสัญลักษณ์เปอร์เซ็นต์กับป้ายแผนภูมิ**

เมื่อค่าถูกจัดเก็บเป็นเศษส่วน ให้ใช้ [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) เพื่อแสดงเป็นเปอร์เซ็นต์ ส่งค่า `false` ไปยัง [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) เพื่อให้รูปแบบป้ายทำงานแยกจากเซลล์ต้นทาง

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ซ้อน 100% ที่มีซีรีส์สีแดงและสีน้ำเงินสี่ประเภท แต่ละคู่ค่ารวมกันเท่ากับ 1 รูปแบบป้าย `0.0%` จะทำให้ค่า 0.30 แสดงเป็น 30.0% ในขณะที่แกนแนวตั้งใช้ทศนิยมสองตำแหน่ง ทั้งสองซีรีส์ใช้ข้อความป้ายสีขาว ขนาด 10 จุด

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

ใช้ [getActualLabelText](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#getActualLabelText--) เพื่อดึงข้อความที่สร้างโดยการตั้งค่าป้ายข้อมูล วิธีนี้มีประโยชน์เมื่อต้องดึงป้ายสำหรับรายงาน ค้นหาเนื้อหาในการนำเสนอ หรือทำการตรวจสอบแผนภูมิที่สร้างขึ้น ในตัวอย่างด้านล่าง รูปแบบ [data label format](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/) เริ่มต้นจะรวมชื่อประเภท ชื่อซีรีส์ และค่า จุดหนึ่งจัดรูปแบบค่าเป็นเปอร์เซ็นต์ และอีกจุดหนึ่งใช้ข้อความกำหนดเองจาก [getTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--)

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

ค่าที่เก็บในจุดข้อมูลยังคงเป็น `0.75` แม้ว่าป้ายจะแสดง `75%` พร้อมชื่อประเภทและชื่อซีรีส์ ข้อความกำหนดเองจะแทนที่ข้อความป้ายที่สร้างขึ้น [getActualLabelText](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#getActualLabelText--) จะคืนสตริงป้ายในทั้งสองกรณี ตรวจสอบ [isVisible](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#isVisible--) แยกต่างหากตามที่แสดงด้านบนเมื่อคุณต้องการดึงเฉพาะป้ายที่มองเห็นได้

## **ควบคุมป้ายข้อมูลที่อยู่นอกค่ามากสุดของแกน**

เมื่อคุณกำหนดช่วงแกนด้วยมือ บางจุดข้อมูลอาจเกินค่ามากสุด ใช้ [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setShowDataLabelsOverMaximum-boolean-) เพื่อควบคุมว่าป้ายของจุดเหล่านั้นจะแสดงหรือไม่ การตั้งค่านี้เปลี่ยนการมองเห็นของป้ายเท่านั้น ไม่ได้เปลี่ยนช่วงแกนหรือค่าข้อมูลที่อยู่ภายใต้

ตัวอย่างด้านล่างสร้างแผนภูมิคอลัมน์แบบคลัสเตอร์ 2D ด้วยค่าที่ 60 และ 120 มันส่ง `false` ไปยัง [setAutomaticMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticMaxValue-boolean-) และตั้งค่ามากสุดเป็น 100 ด้วย [setMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMaxValue-double-) บนแกนแนวตั้ง สไลด์แรกเปิดให้แสดงป้ายที่อยู่นอกค่ามากสุด; การทำสำเนาของสไลด์นั้นปิดการแสดงผล ทั้งสองสไลด์ถูกบันทึกเป็น `DataLabelsOverMaximum.pptx`

เปิดป้ายค่าโดยใช้ [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) การตั้งค่าระดับแผนภูมิไม่ได้เปิดการแสดงค่าด้วยตนเองหรือเขียนทับการปิดการแสดงค่าของป้ายเดี่ยว ๆ ตัวอย่างนี้เปิดค่าทั้งซีรีส์และใช้ [setPosition](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setPosition-int-) เพื่อวางป้ายที่ปลายนอกของแต่ละคอลัมน์

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

ภาพต่อไปนี้แสดงสไลด์ที่บันทึกโดย Microsoft PowerPoint ด้วย `true` ป้าย **120** จะมองเห็นได้ที่ขอบบน; ด้วย `false` ป้ายจะถูกซ่อน ป้าย **60** ยังคงมองเห็นได้ แกนสูงสุดคงอยู่ที่ **100** และจุดข้อมูลที่สองยังคงเป็น **120** ในทั้งสองกรณี

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
ตัวอย่างนี้ใช้แผนภูมิคอลัมน์ 2D พร้อมแกนค่า แผนภูมิที่ไม่มีแกนค่า เช่น แผนภูมิเพียและโดนัท จะไม่มีค่ามากสุดของแกนให้กำหนดในลักษณะนี้
{{% /alert %}}

## **กำหนดระยะห่างของป้ายจากแกน**

ใช้ [setLabelOffset](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setLabelOffset-int-) เพื่อควบคุมระยะห่างระหว่างป้ายแกนประเภทกับแกน ค่าเป็นเปอร์เซ็นต์ของขนาดฟอนต์สูงสุดของป้ายแกน ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบคลัสเตอร์และตั้งค่าออฟเซ็ตของป้ายแกนแนวนอนเป็น 500 การตั้งค่านี้ส่งผลต่อป้ายแกนประเภท ไม่ใช่ป้ายที่แนบกับจุดข้อมูลแต่ละจุด

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

บนแผนภูมิเพีย ปรับตำแหน่งป้ายข้อมูลเพื่อให้มีช่องว่างและสร้างที่ว่างสำหรับเส้นนำ

ตัวอย่างนี้แสดงค่าของจุดข้อมูลแรก วางป้ายนอกส่วนของพาย และปรับออฟเซ็ตแนวนอนและแนวตั้งโดยใช้ [setX](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setX-float-) และ [setY](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setY-float-) ออฟเซ็ตเหล่านี้เป็นสัดส่วนของความกว้างและความสูงของแผนภูมิ

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

![Pie chart with an adjusted data label position](pie-chart-adjusted-label.png)

## **จัดรูปแบบเส้นนำ**

เมื่อป้ายแผนภูมิปายอยู่ด้านนอกส่วนของพาย เส้นนำช่วยให้ผู้อ่านจับคู่ค่าแต่ละค่ากับส่วนที่ถูกต้อง สีตัดกันและเส้นหนานิดหน่อยทำให้การเชื่อมต่อดูง่ายขึ้น ส่วนความโปร่งใสและสไตล์เป็นเส้นประทำให้เส้นไม่โดดเด่นเกินไป

ใช้ [getLeaderLinesFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelcollection/#getLeaderLinesFormat--) เพื่อจัดรูปแบบเส้นนำระดับคอลเลกชันป้ายข้อมูลของซีรีส์ การตั้งค่าใน `series.getLabels().getLeaderLinesFormat().getLine()` จะใช้กับคอลเลกชันทั้งหมด ไม่ใช่ป้ายเดี่ยว

ตัวอย่างนี้สร้างแผนภูมิปายด้วยข้อมูลเริ่มต้น แสดงค่าอยู่นอกส่วนของพาย และเปิดใช้งาน [setShowLeaderLines](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowLeaderLines-boolean-) ย้ายสองป้ายไกลจากส่วนของพายด้วยออฟเซ็ต [setX](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setX-float-) และ [setY](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setY-float-) เป็นส่วนของความกว้างและความสูงของแผนภูมิ ไม่ต้องใช้การนำเสนออินพุต

เมธอด [getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getFillFormat--) ของเส้นกำหนดสีฟ้าโทนเดียวที่มีค่าอัลฟ่า 191 จาก 255 ประมาณ 25% โปร่งแสง [setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setWidth-double-) ตั้งความหนาเป็น 2 จุด และ [setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-) ทำให้เส้นเป็นเส้นประ

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 80, 50, 560, 400);
    chart.setLegend(false);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    IDataLabelFormat labelFormat = series.getLabels().getDefaultDataLabelFormat();
    labelFormat.setShowValue(true);
    labelFormat.setPosition(LegendDataLabelPosition.OutsideEnd);
    labelFormat.setShowLeaderLines(true);

    // ย้ายป้ายสองรายการให้ไกลออกจากชิ้นส่วนของพายมากขึ้น.
    series.getLabels().get_Item(0).setX(0.10f);
    series.getLabels().get_Item(0).setY(-0.05f);
    series.getLabels().get_Item(1).setX(-0.10f);
    series.getLabels().get_Item(1).setY(0.05f);

    ILineFormat line = series.getLabels().getLeaderLinesFormat().getLine();
    line.getFillFormat().setFillType(FillType.Solid);
    line.getFillFormat().getSolidFillColor().setColor(new Color(30, 90, 160, 191));
    line.setWidth(2);
    line.setDashStyle(LineDashStyle.Dash);

    presentation.save("FormattedLeaderLines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การเปิดใช้งานเส้นนำไม่ได้รับประกันว่าจะมีเส้นสำหรับทุกป้าย ความมองเห็นขึ้นอยู่กับตำแหน่งป้ายและพฤติกรรมการจัดวางของแผนภูมิ ในตัวอย่างนี้สองป้ายที่ถูกย้ายไกลมีเส้นนำที่มองเห็นได้; ป้ายที่อยู่ใกล้ส่วนของพายไม่จำเป็นต้องมีเส้นนำ

ภาพต่อไปนี้แสดงไฟล์ `FormattedLeaderLines.pptx` ที่บันทึกแล้วและเรนเดอร์ด้วย Aspose.Slides:

![Pie chart with blue, semitransparent dashed leader lines connecting two outside labels to their slices](formatted-leader-lines.png)

## **เพิ่มหลายแถวของป้ายข้อมูลเหนือแผนภูมิคอลัมน์**

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ที่มีสองแถวของป้ายข้อมูลเหนือพื้นที่พล็อต Series A แสดงคอลัมน์ที่มองเห็นได้ ส่วน Series B และ Series C ให้ป้ายเพิ่มเติม คอลัมน์ของพวกมันถูกซ่อนโดยลบการเติมสีและขอบ วิธี [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/chartseriesgroup/) ทำให้สามซีรีส์ทั้งหมดตรงศูนย์กลางประเภทเดียวกัน

การตั้งค่า [ChartPlotArea](https://reference.aspose.com/slides/java/com.aspose.slides/chartplotarea/) สงวนพื้นที่สำหรับแถวป้าย หลังจากที่ [Chart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/) คำนวนตำแหน่งเริ่มต้นแล้ว [DataLabel.setX and DataLabel.setY](https://reference.aspose.com/slides/java/com.aspose.slides/datalabel/) จะรักษาการจัดแนวแนวนอนและใช้ค่าลอยแนวตั้งเพื่อจัดแถวป้ายเป็นสองแถว ตัวเลขยังคงเป็นป้ายข้อมูลที่เชื่อมโยงกับค่าซีรีส์; ส่วนหัวแถวเป็นรูปข้อความแยกต่างหาก

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
            // ซ่อนคอลัมน์ของ B และ C แต่คงป้ายข้อมูลไว้.
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

    // จัดแนวทั้งหมดสามซีรีส์ให้ตรงกับศูนย์กลางประเภทเดียวกัน.
    chart.getChartData().getSeries().get_Item(0)
            .getParentSeriesGroup().setOverlap((byte) 100);

    // ใช้เส้นกริดน้อยลงสำหรับตัวอย่างที่กะทัดรัดนี้.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setMajorUnit(10);

    // สงวนพื้นที่เหนือพื้นที่พล็อตสำหรับสองแถวของป้ายข้อมูล.
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
            // คงตำแหน่งแนวนอนเริ่มต้นไว้. Y คือการเยื้องจาก
            // ตำแหน่งป้ายเริ่มต้น, แสดงเป็นส่วนของความสูงแผนภูมิ.
            dataLabel.setX(0);
            dataLabel.setY(rowTop - dataLabel.getActualY() / chart.getHeight());
        }

        // เฉพาะหัวแถวเป็นรูปร่างข้อความแยกต่างหาก.
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

![Column chart with two rows of data labels above the plot area](multiple-rows-of-labels.png)

## **คำถามที่พบบ่อย**

**ทำอย่างไรจึงจะป้องกันไม่ให้ป้ายข้อมูลทับซ้อนกันในแผนภูมิที่หนาแน่น?**

ผสานการวางป้ายอัตโนมัติ, เส้นนำ, และลดขนาดฟอนต์; หากจำเป็นให้ซ่อนบางฟิลด์ (เช่น ประเภท) หรือแสดงป้ายเฉพาะค่าตำแหน่งสุดขีดหรือจุดสำคัญ

**ทำอย่างไรจึงจะปิดการแสดงป้ายสำหรับค่าเป็นศูนย์, ลบ, หรือค่าว่างเท่านั้น?**

กรองจุดข้อมูลก่อนเปิดป้ายและปิดการแสดงสำหรับค่าที่เป็น 0, ค่าลบ, หรือค่าที่หายไปตามกฎที่กำหนด

**ทำอย่างไรจึงจะทำให้สไตล์ป้ายคงที่เมื่อส่งออกเป็น PDF/ภาพ?**

กำหนดฟอนต์แบบชัดเจนทั้งครอบครัวและขนาด และตรวจสอบว่าฟอนต์พร้อมใช้งานในสภาพแวดล้อมการเรนเดอร์เพื่อหลีกเลี่ยงการใช้ฟอนต์สำรอง