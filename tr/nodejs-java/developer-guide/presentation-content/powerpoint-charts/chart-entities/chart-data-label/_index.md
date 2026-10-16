---
title: JavaScript Kullanarak Sunumlarda Grafik Veri Etiketlerini Yönetme
linktitle: Veri Etiketi
type: docs
url: /tr/nodejs-java/chart-data-label/
keywords:
- grafik
- veri etiketi
- veri hassasiyeti
- yüzde
- etiket mesafesi
- etiket konumu
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint sunumlarında JavaScript ve Aspose.Slides for Node.js kullanarak grafik veri etiketlerini eklemeyi ve biçimlendirmeyi öğrenin, Java üzerinden daha etkileyici slaytlar için."
---
## **Giriş**

Veri etiketleri, grafik serileri ve tek tek veri noktaları hakkında bilgi göstererek okuyucuların değerleri tanımlamasına ve grafiği anlamasına yardımcı olur. Bu makale, değerleri biçimlendirme, yüzde gösterme, etiket metnini okuma, eksen maksimumunun ötesindeki etiketleri kontrol etme, kategori ekseni etiketi aralığını ayarlama ve pasta grafik etiketlerini konumlandırma konularını açıklar.

## **Grafik Veri Etiketlerinde Veri Hassasiyetini Ayarlama**

Seri değerlerini biçimlendirmek için [setNumberFormatOfValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setnumberformatofvalues/) kullanın. Bu örnek, varsayılan verilerle bir çizgi grafik oluşturur, veri tablosunu gösterir ve ilk seri için değer etiketlerini etkinleştirir. `#,##0.00` biçimi, binlik ayırıcı ve iki ondalık basamak gösterir; temel değerleri değiştirmez.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 50, 50, 450, 300);
    chart.setDataTable(true);

    const series = chart.getChartData().getSeries().get_Item(0);
    series.setNumberFormatOfValues("#,##0.00");
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("PrecisionOfDatalabels_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Yüzdeleri Etiket Olarak Görüntüleme**

Yığılmış sütun grafik için, her değeri kategori toplamına göre yüzde olarak hesaplayın ve metni [getTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/) tarafından döndürülen metin çerçevesine atayın. Bu örnek, varsayılan grafik verilerini kullanır ve yüzde değerlerini iki ondalık basamakla 8 punto fontta gösterir. Toplamı sıfır olan kategoriler bölme hatasından kaçınmak için atlanır. Grafik verileri değişirse özel etiket metnini yeniden hesaplayın.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 400, 400);

    const categoryTotals = new Array(chart.getChartData().getCategories().size()).fill(0);
    for (let k = 0; k < chart.getChartData().getCategories().size(); k++) {
        for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
            const series = chart.getChartData().getSeries().get_Item(i);
            const pointValue = series.getDataPoints().get_Item(k).getValue().getData();
            categoryTotals[k] += Number(pointValue);
        }
    }

    for (let x = 0; x < chart.getChartData().getSeries().size(); x++) {
        const series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);

        for (let j = 0; j < series.getDataPoints().size(); j++) {
            const label = series.getDataPoints().get_Item(j).getLabel();
            if (categoryTotals[j] == 0) {
                continue;
            }

            const pointValue = series.getDataPoints().get_Item(j).getValue().getData();
            const dataPointPercent = (Number(pointValue) / categoryTotals[j]) * 100;

            const portion = new aspose.slides.Portion();
            portion.setText(dataPointPercent.toFixed(2) + " %");
            portion.getPortionFormat().setFontHeight(8);

            label.getTextFrameForOverriding().setText("");
            const paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0);
            paragraph.getPortions().add(portion);

            label.getDataLabelFormat().setShowValue(true);
            label.getDataLabelFormat().setShowSeriesName(false);
            label.getDataLabelFormat().setShowPercentage(false);
            label.getDataLabelFormat().setShowLegendKey(false);
            label.getDataLabelFormat().setShowCategoryName(false);
            label.getDataLabelFormat().setShowBubbleSize(false);
        }
    }

    presentation.save("DisplayPercentageAsLabels_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Grafik Veri Etiketlerinde Yüzde İşareti Ayarlama**

Değerler kesir olarak saklanıyorsa, yüzde göstermek için [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformat/) kullanın. Etiket biçimini kaynak hücrelerden bağımsız olarak uygulamak için [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) `false` gönderin.

Bu örnek, dört kategori boyunca kırmızı ve mavi seriler içeren %100 yığılmış sütun grafik oluşturur. Her değer çifti 1’e toplar. `0.0%` etiketi biçimi, 0.30’u 30.0% olarak gösterirken, dikey eksen iki ondalık basamak kullanır. Her iki seri de beyaz, 10 punto etiket metni kullanır.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PercentsStackedColumn, 20, 20, 500, 400);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;
    for (let i = 0; i < 4; i++) {
        const categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    const seriesNames = ["Reds", "Blues"];
    const white = java.getStaticFieldValue("java.awt.Color", "WHITE");
    const seriesColors = [java.getStaticFieldValue("java.awt.Color", "RED"), java.getStaticFieldValue("java.awt.Color", "BLUE")];
    const values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]];

    for (let i = 0; i < seriesNames.length; i++) {
        const seriesCell = workbook.getCell(worksheetIndex, 0, i + 1, seriesNames[i]);
        const series = chart.getChartData().getSeries().add(seriesCell, chart.getType());
        for (let j = 0; j < 4; j++) {
            const valueCell = workbook.getCell(worksheetIndex, j + 1, i + 1, values[i][j]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
        series.getFormat().getFill().getSolidFillColor().setColor(seriesColors[i]);

        const labelFormat = series.getLabels().getDefaultDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(false);
        labelFormat.setNumberFormat("0.0%");
        labelFormat.getTextFormat().getPortionFormat().setFontHeight(10);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(white);
    }

    presentation.save("SetDataLabelsPercentageSign_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Veri Etiketlerinin Gerçek Metnini Okuma**

Veri etiketinin ayarları tarafından üretilen metni almak için [getActualLabelText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) kullanın. Bu, raporlar için etiketleri çıkartırken, sunum içeriğinde arama yaparken veya oluşturulan grafikleri doğrularken faydalıdır. Aşağıdaki örnekte, varsayılan [data label format](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/) her kategori adını, seri adını ve değeri birleştirir. Bir nokta değerini yüzde olarak biçimler, diğeri ise [getTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/) ile özel metin kullanır.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const firstCategoryCell = workbook.getCell(0, 1, 0, "Q1");
    chart.getChartData().getCategories().add(firstCategoryCell);
    const secondCategoryCell = workbook.getCell(0, 2, 0, "Q2");
    chart.getChartData().getCategories().add(secondCategoryCell);

    const northSeriesCell = workbook.getCell(0, 0, 1, "North");
    const north = chart.getChartData().getSeries().add(northSeriesCell, chart.getType());
    const northFirstValueCell = workbook.getCell(0, 1, 1, 0.25);
    north.getDataPoints().addDataPointForBarSeries(northFirstValueCell);
    const northSecondValueCell = workbook.getCell(0, 2, 1, 0.75);
    north.getDataPoints().addDataPointForBarSeries(northSecondValueCell);

    const southSeriesCell = workbook.getCell(0, 0, 2, "South");
    const south = chart.getChartData().getSeries().add(southSeriesCell, chart.getType());
    const southFirstValueCell = workbook.getCell(0, 1, 2, 0.40);
    south.getDataPoints().addDataPointForBarSeries(southFirstValueCell);
    const southSecondValueCell = workbook.getCell(0, 2, 2, 0.60);
    south.getDataPoints().addDataPointForBarSeries(southSecondValueCell);

    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        const series = chart.getChartData().getSeries().get_Item(i);
        const format = series.getLabels().getDefaultDataLabelFormat();
        format.setShowCategoryName(true);
        format.setShowSeriesName(true);
        format.setShowValue(true);
    }

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(false);
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%");
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed");

    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        const series = chart.getChartData().getSeries().get_Item(i);
        for (let j = 0; j < series.getDataPoints().size(); j++) {
            const point = series.getDataPoints().get_Item(j);
            const label = point.getLabel();
            if (!label.isVisible()) {
                continue;
            }

            console.log("Value: " + point.getValue().getData() + "; label: " + label.getActualLabelText());
        }
    }
} finally {
    presentation.dispose();
}
```

Veri noktasında saklanan sayı `0.75` olarak kalır; etiketinde ise kategori ve seri adlarıyla birlikte `75%` gösterilir. Özel metin, oluşturulan etiket metninin yerini alır. [getActualLabelText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) her iki durumda da sonuç etiket dizesini döndürür. Görünür etiketleri yalnızca çıkartmak istediğinizde, yukarıda gösterildiği gibi [isVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/isvisible/) ayrı ayrı kontrol edin.

## **Eksen Maksimumunun Ötesindeki Veri Etiketlerini Kontrol Etme**

Eksen aralığını manuel olarak sınırladığınızda, bazı veri noktaları maksimumu aşabilir. Bu noktaların veri etiketlerinin gösterilip gösterilmeyeceğini kontrol etmek için [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setshowdatalabelsovermaximum/) kullanın. Bu ayar etiket görünürlüğünü değiştirir; eksen aralığını veya temel veri değerlerini değiştirmez.

Aşağıdaki örnek, 60 ve 120 değerli 2D kümelenmiş sütun grafik oluşturur. Dikey eksende [setAutomaticMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmaxvalue/) `false` gönderir ve maksimumu 100 olarak [setMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmaxvalue/) ile ayarlar. İlk slayt, maksimumun ötesindeki etiketlere izin verir; aynı slaydın bir kopyası bunları devre dışı bırakır. İki slayt da `DataLabelsOverMaximum.pptx` içinde kaydedilir.

Değer etiketlerini [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowvalue/) ile etkinleştirin. Grafik düzeyindeki bu ayar, tek bir etiketin devre dışı bırakılmış değer gösterimini geçersiz kılmaz; ayrıca tek başına değer gösterimini etkinleştirmez. Bu örnek, tüm seri için değerleri etkinleştirir ve [setPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setposition/) ile etiketleri her sütunun dış ucuna konumlandırır.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();

    const firstCategory = workbook.getCell(0, 1, 0, "Within range");
    const secondCategory = workbook.getCell(0, 2, 0, "Above maximum");

    chart.getChartData().getCategories().add(firstCategory);
    chart.getChartData().getCategories().add(secondCategory);

    const seriesName = workbook.getCell(0, 0, 1, "Values");
    const series = chart.getChartData().getSeries().add(seriesName, chart.getType());

    const firstValue = workbook.getCell(0, 1, 1, 60);
    const secondValue = workbook.getCell(0, 2, 1, 120);

    series.getDataPoints().addDataPointForBarSeries(firstValue);
    series.getDataPoints().addDataPointForBarSeries(secondValue);

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(100);
    chart.setShowDataLabelsOverMaximum(true);

    const secondSlide = presentation.getSlides().addClone(slide);
    const secondChart = secondSlide.getShapes().get_Item(0);
    secondChart.setShowDataLabelsOverMaximum(false);

    presentation.save("DataLabelsOverMaximum.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Aşağıdaki görseller, Microsoft PowerPoint tarafından oluşturulan kaydedilmiş slaytları gösterir. `true` kullanıldığında, **120** etiketi üst sınırda görünür; `false` kullanıldığında gizlenir. **60** etiketi görünür kalır, eksen maksimumu **100** olarak kalır ve ikinci veri noktası her iki durumda da **120** olur.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![Eksen maksimumu 100 iken değer etiketi 120 gösteren PowerPoint grafiği](data-labels-over-maximum-true.png) | ![Eksen maksimumu 100 iken değer etiketi 120 gizleyen PowerPoint grafiği](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Bu örnek, değer ekseni olan 2D sütun grafik kullanır. Pasta ve halka grafikler gibi değer ekseni olmayan grafiklerde, bu şekilde sınırlandırılacak bir eksen maksimumu bulunmaz.
{{% /alert %}}

## **Etiketi Eksen’den Uzaklık Olarak Ayarlama**

Kategori ekseni etiketleri ile eksen arasındaki mesafeyi kontrol etmek için [setLabelOffset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlabeloffset/) kullanın. Değer, eksen etiketlerinin maksimum yazı tipi boyutunun yüzde oranıdır. Bu örnek, kümelenmiş sütun grafik oluşturur ve yatay eksen etiketi offsetini 500 olarak ayarlar. Bu ayar, tek tek veri noktalarına iliştirilmiş etiketler yerine kategori ekseni etiketlerini etkiler.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.getAxes().getHorizontalAxis().setLabelOffset(500);

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Etiket Konumunu Ayarlama**

Pasta grafiklerde, veri etiketi konumlarını ayarlayarak boşlukları artırabilir ve gösterge çizgileri için yer açabilirsiniz.

Bu örnek, ilk veri noktasının değerini gösterir, etiketini dilimin dışına yerleştirir ve yatay‑dikey ofsetlerini [setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/setx/) ve [setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/sety/) ile ayarlar. Bu ofsetler, grafik genişliği ve yüksekliğine göre oranlanmıştır.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 200, 200);
    const series = chart.getChartData().getSeries();

    const label = series.get_Item(0).getLabels().get_Item(0);
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);
    label.setX(java.newFloat(0.71));
    label.setY(java.newFloat(0.04));

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Ayarlanmış veri etiketi konumuna sahip pasta grafik](pie-chart-adjusted-label.png)

## **Gösterge Çizgilerini Biçimlendirme**

Pasta grafik etiketleri dilimlerin dışına çıktığında, gösterge çizgileri her değeri doğru dilimle eşleştirmede okuyucuya yardımcı olur. Zıt bir renk ve hafif kalın bir çizgi bu bağlantıları takip etmeyi kolaylaştırır; şeffaflık ve kesikli stil ise çizgileri göz yormaz tutar.

Seri veri etiketi koleksiyonu düzeyinde gösterge çizgilerini biçimlendirmek için [getLeaderLinesFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelcollection/getleaderlinesformat/) kullanın. `series.getLabels().getLeaderLinesFormat().getLine()` içindeki ayarlar, bireysel etiket yerine koleksiyona uygulanır.

Bu örnek, varsayılan verilerle bir pasta grafik oluşturur, değerleri dilimlerin dışına gösterir ve [setShowLeaderLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowleaderlines/) i etkinleştirir. İki etiketi dilimlerinden daha uzakta konumlandırmak için [setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/setx/) ve [setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/sety/) ofsetleri, grafik genişliği ve yüksekliğinin kesirleri olarak belirtilir. Girdi sunumuna ihtiyaç yoktur.

Çizginin [getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/getfillformat/) i, alfa değeri 191/255 olan katı mavi renk ayarlar; bu yaklaşık %25 şeffaflık verir. [setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/setwidth/) i kalınlığı 2 puana, [setDashStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/setdashstyle/) i ise kesikli yapar.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 80, 50, 560, 400);
    chart.setLegend(false);

    const series = chart.getChartData().getSeries().get_Item(0);

    const labelFormat = series.getLabels().getDefaultDataLabelFormat();
    labelFormat.setShowValue(true);
    labelFormat.setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);
    labelFormat.setShowLeaderLines(true);

    // İki etiketi dilimlerinden daha uzağa taşı.
    series.getLabels().get_Item(0).setX(java.newFloat(0.10));
    series.getLabels().get_Item(0).setY(java.newFloat(-0.05));
    series.getLabels().get_Item(1).setX(java.newFloat(-0.10));
    series.getLabels().get_Item(1).setY(java.newFloat(0.05));

    const line = series.getLabels().getLeaderLinesFormat().getLine();
    line.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const lineColor = java.newInstanceSync("java.awt.Color", 30, 90, 160, 191);
    line.getFillFormat().getSolidFillColor().setColor(lineColor);
    line.setWidth(2);
    line.setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    presentation.save("FormattedLeaderLines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Gösterge çizgilerini etkinleştirmek, her etiket için bir çizginin görünmesini garanti etmez. Görünürlük, etiket yerleşimine ve grafiğin yerleşim davranışına bağlıdır. Bu örnekte, iki uzaklaştırılmış etikete gösterge çizgileri görünür; dilimlerine yakın kalan etiketlerin ise buna ihtiyacı yoktur.

Aşağıdaki görsel, Aspose.Slides ile oluşturulmuş `FormattedLeaderLines.pptx` dosyasının kaydedilmiş halini gösterir:

![İki dış etiket ile dilimlerine bağlanan mavi, yarı şeffaf kesikli gösterge çizgileri içeren pasta grafik](formatted-leader-lines.png)

## **Sütun Grafiğinin Üstünde Birden Fazla Satır Veri Etiketi Ekleme**

Bu örnek, çizim alanının üstünde iki satır veri etiketi bulunan bir sütun grafik oluşturur. Seri A, görünür sütunları gösterirken, Seri B ve Seri C ek etiketleri sağlar. Bu serilerin sütunları, dolgu ve dış hat kaldırılarak gizlenir. [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setoverlap/) metodu, üç seriyi aynı kategori merkezleriyle hizalar.

[ChartPlotArea](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartplotarea/) ayarları etiket satırları için alan ayırır. [Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) varsayılan konumları hesapladıktan sonra, [DataLabel.setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/setx/) ve [DataLabel.setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/sety/) yatay hizalamayı korur ve dikey ofsetleri iki satırda etiketleri düzenlemek için uygular. Sayılar, seri değerlerine bağlı veri etiketleri olarak kalır; sadece satır başlıkları ayrı metin şekilleridir.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const black = java.getStaticFieldValue("java.awt.Color", "BLACK");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 40, 40, 640, 200);
    chart.setTitle(false);
    chart.setLegend(false);
    chart.getTextFormat().getPortionFormat().setFontHeight(12);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    const categories = ["North", "South", "East", "West"];
    const seriesNames = ["Series A", "Series B", "Series C"];
    const seriesValues = [[35, 42, 28, 47], [22, 31, 19, 26], [12, 16, 14, 18]];

    for (let categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
        const categoryCell = workbook.getCell(0, categoryIndex + 1, 0, categories[categoryIndex]);
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (let seriesIndex = 0; seriesIndex < seriesNames.length; seriesIndex++) {
        const seriesCell = workbook.getCell(0, 0, seriesIndex + 1, seriesNames[seriesIndex]);
        const series = chart.getChartData().getSeries().add(seriesCell, aspose.slides.ChartType.ClusteredColumn);

        for (let categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            const valueCell = workbook.getCell(0, categoryIndex + 1, seriesIndex + 1, seriesValues[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        if (seriesIndex > 0) {
            // B ve C sütunlarını gizle, ancak veri etiketlerini tut.
            series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            series.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
            series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(12);
            const labelFill = series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat();
            labelFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
            labelFill.getSolidFillColor().setColor(black);
            series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.InsideBase);
        }
    }

    // Üç seriyi aynı kategori merkezleriyle hizala.
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setOverlap(java.newByte(100));

    // Bu kompakt örnek için daha az ızgara çizgisi kullan.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setMajorUnit(10);

    // Çizim alanının üzerindeki iki satır veri etiketi için alan ayır.
    chart.getPlotArea().setLayoutTargetType(aspose.slides.LayoutTargetType.Inner);
    chart.getPlotArea().setX(java.newFloat(0.15));
    chart.getPlotArea().setY(java.newFloat(0.32));
    chart.getPlotArea().setWidth(java.newFloat(0.80));
    chart.getPlotArea().setHeight(java.newFloat(0.48));
    chart.validateChartLayout();

    for (let seriesIndex = 1; seriesIndex < seriesNames.length; seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const rowTop = seriesIndex == 1 ? 0.15 : 0.03;

        for (let categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            const dataLabel = series.getDataPoints().get_Item(categoryIndex).getLabel();
            // Varsayılan yatay konumu koru. Y, şu konumdan bir ofsettir
            // varsayılan etiket konumundan, grafik yüksekliği oranı olarak ifade edilir.
            dataLabel.setX(0);
            dataLabel.setY(java.newFloat(rowTop - dataLabel.getActualY() / chart.getHeight()));
        }

        // Sadece satır başlığı ayrı bir metin şeklidir.
        const rowHeading = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, chart.getX(), chart.getY() + rowTop * chart.getHeight(), 85, 18);
        rowHeading.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        rowHeading.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        rowHeading.addTextFrame(seriesNames[seriesIndex]);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginTop(0);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginBottom(0);
        const headingFormat = rowHeading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        headingFormat.setFontHeight(12);
        headingFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        headingFormat.getFillFormat().getSolidFillColor().setColor(black);
    }

    presentation.save("multiple-rows-of-labels.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Çizim alanının üstünde iki satır veri etiketi bulunan sütun grafik](multiple-rows-of-labels.png)

## **SSS**

**Yoğun grafiklerde veri etiketlerinin üst üste binmesini nasıl önleyebilirim?**

Otomatik etiket yerleştirme, gösterge çizgileri ve küçültülmüş yazı tipi boyutunu birleştirin; gerekirse bazı alanları (ör. kategori) gizleyin veya yalnızca uç değerler/ana noktalar için etiket gösterin.

**Sıfır, negatif veya boş değerler için etiketleri nasıl devre dışı bırakabilirim?**

Etiketleri etkinleştirmeden önce veri noktalarını filtreleyin ve 0, negatif veya eksik değerler için gösterimi kapatın; kural bazlı bir yaklaşım kullanın.

**PDF/görüntülere dışa aktarırken tutarlı bir etiket stili nasıl sağlanır?**

Yazı tipi ailesi ve boyutunu açıkça ayarlayın ve render ortamında yazı tipinin mevcut olduğundan emin olun, böylece yedekleme önlenir.