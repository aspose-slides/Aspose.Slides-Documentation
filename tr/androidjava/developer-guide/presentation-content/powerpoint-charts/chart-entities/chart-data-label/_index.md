---
title: Android Sunumlarında Grafik Veri Etiketlerini Yönetme
linktitle: Veri Etiketi
type: docs
url: /tr/androidjava/chart-data-label/
keywords:
- grafik
- veri etiketi
- veri hassasiyeti
- yüzde
- etiket mesafesi
- etiket konumu
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android'ı Java üzerinden kullanarak PowerPoint sunumlarında grafik veri etiketlerini eklemeyi ve biçimlendirmeyi öğrenin, daha etkileyici slaytlar oluşturun."
---
## **Giriş**

Veri etiketleri, grafik serileri ve tek tek veri noktaları hakkında bilgi gösterir, okuyucuların değerleri tanımlamasına ve grafiği anlamasına yardımcı olur. Bu makale, değerleri biçimlendirme, yüzdeleri gösterme, etiket metnini okuma, eksen maksimumunun ötesindeki etiketleri kontrol etme, kategori ekseni etiketi aralığını ayarlama ve pasta grafik etiketlerini konumlandırma konularını açıklar.

## **Grafik Veri Etiketlerinde Veri Hassasiyetini Ayarlama**

Seri değerlerini biçimlendirmek için [setNumberFormatOfValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setNumberFormatOfValues-java.lang.String-) kullanın. Bu örnek, varsayılan verilerle bir çizgi grafik oluşturur, veri tablosunu gösterir ve ilk seri için değer etiketlerini etkinleştirir. `#,##0.00` biçimi, binlik ayırıcı ve iki ondalık basamak gösterir, temel değerleri değiştirmez.

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

## **Yüzdeleri Etiket Olarak Görüntüleme**

Yığınlı sütun grafik için, her değeri kategori toplamının yüzdesi olarak hesaplayın ve metni [getTextFrameForOverriding](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--) tarafından döndürülen metin çerçevesine atayın. Bu örnek, varsayılan grafik verilerini kullanır ve yüzde değerlerini iki ondalık basamakla 8 punto yazı tipinde gösterir. Toplamı sıfır olan kategoriler, sıfıra bölme hatasını önlemek için atlanır. Grafik verileri değişirse özel etiket metnini yeniden hesaplayın.

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

## **Grafik Veri Etiketlerinde Yüzde İşaretini Ayarlama**

Değerler kesir olarak saklandığında, yüzdeleri göstermek için [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) kullanın. Etiket biçimini kaynak hücrelerden bağımsız olarak uygulamak için [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) yöntemine `false` gönderin.

Bu örnek, dört kategori üzerinde kırmızı ve mavi seriler içeren %100 yığınlı bir sütun grafik oluşturur. Her değer çifti 1’e toplamaktadır. `0.0%` etiket biçimi, 0.30 değerini 30.0% olarak gösterirken, dikey eksen iki ondalık basamak kullanır. Her iki seri de beyaz, 10 punto etiket metni kullanır.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int[] seriesColors = { Color.RED, Color.BLUE };
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

## **Veri Etiketlerinin Gerçek Metnini Okuma**

Bir veri etiketinin ayarları tarafından üretilen metni almak için [getActualLabelText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabel/#getActualLabelText--) kullanın. Bu, raporlar için etiketleri çıkarırken, sunum içeriğini ararken veya oluşturulan grafikleri doğrularken faydalıdır. Aşağıdaki örnekte, varsayılan [veri etiketi biçimi](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/) her kategori adı, seri adı ve değeri birleştirir. Bir nokta değerini yüzde olarak biçimlerken, diğeri [getTextFrameForOverriding](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--) üzerinden özel metin kullanır.

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

Bir veri noktasında saklanan sayı `0.75` olarak kalır, etiketinde `75%` ve kategori ile seri adları gösterilse bile. Özel metin, oluşturulan etiket metninin yerini alır. [getActualLabelText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabel/#getActualLabelText--) her iki durumda da sonuç etiket dizesini döndürür. Yalnızca görünür etiketleri çıkarmak istediğinizde, yukarıda gösterildiği gibi [isVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabel/#isVisible--) değerini ayrı ayrı kontrol edin.

## **Eksen Maksimumunun Ötesindeki Veri Etiketlerini Kontrol Etme**

Bir eksen aralığını manuel olarak sınırladığınızda, bazı veri noktaları maksimumu aşabilir. Etiketlerinin gösterilip gösterilmeyeceğini kontrol etmek için [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setShowDataLabelsOverMaximum-boolean-) kullanın. Bu ayar, etiket görünürlüğünü değiştirir; eksen aralığını veya temel veri değerlerini değiştirmez.

İşte aşağıdaki örnek, 60 ve 120 değerlerine sahip 2B kümelenmiş bir sütun grafik oluşturur. Dikey eksende [setAutomaticMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticMaxValue-boolean-) yöntemine `false` gönderir ve [setMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMaxValue-double-) ile maksimumu 100 olarak ayarlar. İlk slayt, maksimumun ötesindeki etiketlere izin verir; bu slaytın bir kopyası ise bunları devre dışı bırakır. Her iki slayt da `DataLabelsOverMaximum.pptx` dosyasına kaydedilir.

[setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) ile değer etiketlerini etkinleştirin. Grafik düzeyindeki ayar, tek başına değer gösterimini etkinleştirmez ve bireysel bir etiketin devre dışı bırakılmış değer gösterimini geçersiz kılmaz. Bu örnek, tüm seri için değerleri etkinleştirir ve [setPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setPosition-int-) kullanarak etiketleri her bir sütunun dış ucuna yerleştirir.

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

Aşağıdaki görseller, Microsoft PowerPoint tarafından render edilen kaydedilmiş slaytları gösterir. `true` ile **120** etiketi üst sınırda görünür; `false` ile gizlenir. **60** etiketi görünür kalır, eksen maksimumu **100** olarak kalır ve ikinci veri noktası her iki durumda da **120** olarak kalır.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![PowerPoint grafiği, eksen maksimumu 100 iken değer etiketi 120'yi gösteriyor](data-labels-over-maximum-true.png) | ![PowerPoint grafiği, eksen maksimumu 100 iken değer etiketi 120'yi gizliyor](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Bu örnek, değer ekseni olan 2B sütun grafik kullanır. Pasta ve halka grafikleri gibi değer ekseni olmayan grafikler, bu şekilde sınırlandırılabilecek bir eksen maksimumuna sahip değildir.
{{% /alert %}}

## **Etiket Mesafesini Eksenle Ayarlama**

[setLabelOffset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setLabelOffset-int-) kullanarak kategori ekseni etiketleri ile eksen arasındaki mesafeyi kontrol edin. Değer, eksen etiketlerinin maksimum yazı tipi boyutunun yüzdesidir. Bu örnek, kümelenmiş bir sütun grafik oluşturur ve yatay eksen etiket offsetini 500 olarak ayarlar. Bu ayar, bireysel veri noktalarına eklenen etiketlerden ziyade kategori ekseni etiketlerini etkiler.

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

## **Etiket Konumunu Ayarlama**

Pasta grafiğinde, veri etiketi konumlarını ayarlayarak boşlukları iyileştirin ve gösterge hatları için yer açın.

Bu örnek, ilk veri noktasının değerini gösterir, etiketini dilimin dışına yerleştirir ve [setX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutable/#setX-float-) ve [setY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutable/#setY-float-) kullanarak yatay ve dikey offsetlerini ayarlar. Bu offsetler, sırasıyla grafiğin genişliği ve yüksekliğine göre oranlanır.

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

![Ayarlanmış veri etiketi konumlu pasta grafik](pie-chart-adjusted-label.png)

## **Bir Sütun Grafiğinin Üzerine Birden Çok Satır Veri Etiketi Ekleme**

Bu örnek, çizim alanı üzerinde iki satır veri etiketiyle bir sütun grafik oluşturur. A Serisi görünür sütunları gösterirken, B ve C Serileri ek etiketleri sağlar. Bu sütunlar dolgu ve kenarlık kaldırılarak gizlenir. [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartseriesgroup/#setOverlap-byte-) yöntemi, üç seriyi aynı kategori merkezleriyle hizalar.

[ChartPlotArea](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartplotarea/) ayarları etiket satırları için alan ayırır. [Chart.validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--) varsayılan konumları hesapladıktan sonra, [DataLabel.setX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datalabel/#setX-float-) ve [DataLabel.setY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datalabel/#setY-float-) yatay hizalamayı korur ve iki satırda etiketleri düzenlemek için dikey offsetler uygular. Sayılar, seri değerlerine bağlı veri etiketleri olarak kalır; yalnızca satır başlıkları ayrı metin şekilleridir.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
        IChartDataCell categoryCell = workbook.getCell(0, categoryIndex + 1, 0, categories[categoryIndex]);
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (int seriesIndex = 0; seriesIndex < seriesNames.length; seriesIndex++) {
        IChartDataCell seriesCell = workbook.getCell(0, 0, seriesIndex + 1, seriesNames[seriesIndex]);
        IChartSeries series = chart.getChartData().getSeries().add(seriesCell, ChartType.ClusteredColumn);

        for (int categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            IChartDataCell valueCell = workbook.getCell(0, categoryIndex + 1, seriesIndex + 1, seriesValues[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        if (seriesIndex > 0) {
            // B ve C sütunlarını gizle, ancak veri etiketlerini tut.
            series.getFormat().getFill().setFillType(FillType.NoFill);
            series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
            series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
            series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(12);
            IFillFormat labelFill = series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat();
            labelFill.setFillType(FillType.Solid);
            labelFill.getSolidFillColor().setColor(Color.BLACK);
            series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.InsideBase);
        }
    }

    // Üç seriyi aynı kategori merkezleriyle hizala.
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setOverlap((byte) 100);

    // Bu kompakt örnek için daha az ızgara çizgisi kullan.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setMajorUnit(10);

    // Çizim alanının üstüne iki satır veri etiketi için alan ayır.
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
            // Varsayılan yatay konumu koru. Y, şu konumdan bir offsettir:
            // varsayılan etiket konumudur, grafik yüksekliği oranı olarak ifade edilir.
            dataLabel.setX(0);
            dataLabel.setY(rowTop - dataLabel.getActualY() / chart.getHeight());
        }

        // Sadece satır başlığı ayrı bir metin şeklidir.
        IAutoShape rowHeading = slide.getShapes().addAutoShape(ShapeType.Rectangle, chart.getX(), chart.getY() + rowTop * chart.getHeight(), 85, 18);
        rowHeading.getFillFormat().setFillType(FillType.NoFill);
        rowHeading.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        rowHeading.addTextFrame(seriesNames[seriesIndex]);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginTop(0);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginBottom(0);
        IPortionFormat headingFormat = rowHeading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        headingFormat.setFontHeight(12);
        headingFormat.getFillFormat().setFillType(FillType.Solid);
        headingFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    }

    presentation.save("multiple-rows-of-labels.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Çizim alanı üzerinde iki satır veri etiketi bulunan sütun grafik](multiple-rows-of-labels.png)

## **SSS**

**Yoğun grafiklerde veri etiketlerinin üst üste gelmesini nasıl önleyebilirim?**

Otomatik etiket yerleştirme, gösterge hatları ve daha küçük yazı tipi boyutunu birleştirin; gerekirse bazı alanları (örneğin, kategori) gizleyin veya yalnızca uç değerler ya da ana noktalar için etiket gösterin.

**Sıfır, negatif veya boş değerler için etiketleri nasıl devre dışı bırakabilirim?**

Etiketleri etkinleştirmeden önce veri noktalarını filtreleyin ve tanımlı bir kurala göre 0, negatif veya eksik değerler için gösterimi kapatın.

**PDF/görsellere dışa aktarırken tutarlı bir etiket stili nasıl sağlanır?**

Yazı tipi ailesini ve boyutunu açıkça ayarlayın ve geri dönüşümden kaçınmak için yazı tipinin render ortamında mevcut olduğunu doğrulayın.