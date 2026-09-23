---
title: จัดการป้ายกำกับข้อมูลแผนภูมิในงานนำเสนอด้วย Java
linktitle: ป้ายกำกับข้อมูล
type: docs
url: /th/java/chart-data-label/
keywords:
- แผนภูมิ
- ป้ายกำกับข้อมูล
- ความแม่นยำของข้อมูล
- เปอร์เซ็นต์
- ระยะห่างของป้ายกำกับ
- ตำแหน่งป้ายกำกับ
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้การเพิ่มและจัดรูปแบบป้ายกำกับข้อมูลแผนภูมิในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Java เพื่อทำให้สไลด์น่าสนใจยิ่งขึ้น."
---
## **บทนำ**

ป้ายกำกับข้อมูลแสดงข้อมูลเกี่ยวกับชุดข้อมูลในแผนภูมิและจุดข้อมูลรายตัว ช่วยให้ผู้อ่านระบุค่าและเข้าใจแผนภูมิได้ บทความนี้อธิบายวิธีจัดรูปแบบค่า การแสดงเปอร์เซ็นต์ การอ่านข้อความป้ายกำกับ การปรับระยะห่างของป้ายกำกับแกนหมวดหมู่ และการกำหนดตำแหน่งป้ายกำกับในแผนภูมิวงกลม

## **ตั้งค่าความแม่นยำของข้อมูลในป้ายกำกับแผนภูมิ**

ใช้ [setNumberFormatOfValues](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseries/#setNumberFormatOfValues-java.lang.String-) เพื่อจัดรูปแบบค่าของชุดข้อมูล ตัวอย่างนี้สร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้น แสดงตารางข้อมูลของมัน และเปิดใช้งานป้ายกำกับค่าสำหรับชุดข้อมูลแรก รูปแบบ `#,##0.00` จะใส่คั่นหลักพันและแสดงตำแหน่งทศนิยมสองตำแหน่งโดยไม่เปลี่ยนค่าที่อยู่เบื้องหลัง

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

## **แสดงเปอร์เซ็นต์เป็นป้ายกำกับ**

สำหรับแผนภูมิคอลัมน์แบบซ้อนกัน คำนวณแต่ละค่เป็นเปอร์เซ็นต์ของผลรวมประเภทของมันและกำหนดข้อความลงในกรอบข้อความที่ได้จาก [getTextFrameForOverriding](https://reference.aspose.com/slides/th/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--) ตัวอย่างนี้ใช้ข้อมูลแผนภูมิเบื้องต้นและแสดงเปอร์เซ็นต์ด้วยตำแหน่งทศนิยมสองตำแหน่งในฟอนต์ขนาด 8 pt ประเภทที่มีผลรวมเป็นศูนย์จะถูกข้ามเพื่อหลีกเลี่ยงการหารด้วยศูนย์ หากข้อมูลแผนภูมิมีการเปลี่ยนแปลงให้คำนวณข้อความป้ายกำกับแบบกำหนดใหม่

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

## **ตั้งสัญลักษณ์เปอร์เซ็นต์กับป้ายกำกับแผนภูมิ**

เมื่อค่าถูกเก็บเป็นเศษส่วน ใช้ [setNumberFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) เพื่อแสดงเป็นเปอร์เซ็นต์ ส่งค่า `false` ไปยัง [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/th/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) เพื่อให้รูปแบบป้ายกำกับทำงานแยกจากเซลล์ต้นฉบับ ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบซ้อน 100% ที่มีซีรีส์สีแดงและสีน้ำเงินสี่ประเภท แต่ละคู่ค่าจะรวมกันเป็น 1 รูปแบบป้ายกำกับ `0.0%` จะทำให้ 0.30 แสดงเป็น 30.0% ในขณะที่แกนตั้งใช้ตำแหน่งทศนิยมสองตำแหน่ง ทั้งสองซีรีส์ใช้ข้อความป้ายกำกับสีขาว ขนาด 10 pt

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

## **อ่านข้อความจริงของป้ายกำกับข้อมูล**

ใช้ [getActualLabelText](https://reference.aspose.com/slides/th/java/com.aspose.slides/idatalabel/#getActualLabelText--) เพื่อดึงข้อความที่สร้างโดยการตั้งค่าป้ายกำกับข้อมูล ซึ่งมีประโยชน์เมื่อดึงป้ายกำกับสำหรับรายงาน ค้นหาเนื้อหาในงานนำเสนอ หรือยืนยันความถูกต้องของแผนภูมิที่สร้าง ตัวอย่างด้านล่างใช้รูปแบบ [data label format](https://reference.aspose.com/slides/th/java/com.aspose.slides/idatalabelformat/) เริ่มต้นที่รวมชื่อประเภท ชื่อซีรีส์ และค่าไว้ด้วยกัน จุดหนึ่งกำหนดค่าของมันเป็นเปอร์เซ็นต์ อีกจุดหนึ่งใช้ข้อความกำหนดเองจาก [getTextFrameForOverriding](https://reference.aspose.com/slides/th/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--)

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

ตัวเลขที่เก็บในจุดข้อมูลยังคงเป็น `0.75` แม้ว่า ป้ายกำกับของมันจะแสดงเป็น `75%` ร่วมกับชื่อประเภทและชื่อซีรีส์ ข้อความกำหนดเองจะทดแทนข้อความป้ายกำกับที่สร้างขึ้น [getActualLabelText](https://reference.aspose.com/slides/th/java/com.aspose.slides/idatalabel/#getActualLabelText--) จะคืนสตริงป้ายกำกับที่ได้ในทั้งสองกรณี ตรวจสอบ [isVisible](https://reference.aspose.com/slides/th/java/com.aspose.slides/idatalabel/#isVisible--) แยกต่างหากตามที่แสดงด้านบนเมื่อคุณต้องการดึงเฉพาะป้ายกำกับที่มองเห็นได้

## **ตั้งค่าระยะห่างของป้ายกำกับจากแกน**

ใช้ [setLabelOffset](https://reference.aspose.com/slides/th/java/com.aspose.slides/iaxis/#setLabelOffset-int-) เพื่อควบคุมระยะห่างระหว่างป้ายกำกับแกนหมวดหมู่และแกน ค่าที่ตั้งเป็นเปอร์เซ็นต์ของขนาดฟอนต์สูงสุดของป้ายกำกับแกน ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบจัดกลุ่มและตั้งค่าการชิดป้ายกำกับแกนแนวนอนไปที่ 500 การตั้งค่านี้ส่งผลต่อป้ายกำกับแกนหมวดหมู่ไม่ใช่ป้ายกำกับที่แนบกับจุดข้อมูลแต่ละจุด

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

## **ปรับตำแหน่งป้ายกำกับ**

ในแผนภูมิวุ้นกลม ปรับตำแหน่งป้ายกำกับข้อมูลเพื่อปรับปรุงช่องว่างและให้พื้นที่สำหรับเส้นนำ ตัวอย่างนี้แสดงค่าของจุดข้อมูลแรก วางป้ายกำกับไว้ด้านนอกส่วนของวงกลม และปรับการชิดแนวนอนและแนวตั้งโดยใช้ [setX](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilayoutable/#setX-float-) และ [setY](https://reference.aspose.com/slides/th/java/com.aspose.slides/ilayoutable/#setY-float-) การชิดเหล่านี้เป็นอัตราส่วนของความกว้างและความสูงของแผนภูมิ ตามลำดับ

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

![แผนภูมวงกลมที่มีตำแหน่งป้ายกำกับข้อมูลปรับแล้ว](pie-chart-adjusted-label.png)

## **คำถามที่พบบ่อย**

**ฉันจะป้องกันไม่ให้ป้ายกำกับข้อมูลทับซ้อนกันในแผนภูมิที่แน่นหนาได้อย่างไร?**

ผสานการวางป้ายกำกับอัตโนมัติ, เส้นนำ, และการลดขนาดฟอนต์ หากจำเป็นให้ซ่อนฟิลด์บางส่วน (เช่น ประเภท) หรือแสดงป้ายกำกับเฉพาะค่าที่สุดโต่งหรือจุดสำคัญ

**ฉันจะปิดใช้ป้ายกำกับเฉพาะค่าศูนย์ ค่าติดลบ หรือค่าที่ว่างเปล่าได้อย่างไร?**

กรองจุดข้อมูลก่อนเปิดป้ายกำกับและปิดการแสดงผลสำหรับค่าที่เป็น 0, ค่าติดลบ หรือค่าที่หายไปตามกฎที่กำหนด

**ฉันจะทำให้สไตล์ป้ายกำกับสอดคล้องกันเมื่อส่งออกเป็น PDF/รูปภาพได้อย่างไร?**

กำหนดฟอนต์และขนาดฟอนต์อย่างชัดเจนและตรวจสอบว่าฟอนต์นั้นมีอยู่ในสภาพแวดล้อมการเรนเดอร์เพื่อหลีกเลี่ยงการสำรองฟอนต์