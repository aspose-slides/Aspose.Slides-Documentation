---
title: JavaScript Kullanarak Sunumlarda Pasta Grafiklerini Özelleştirme
linktitle: Pasta Grafiği
type: docs
url: /tr/nodejs-java/pie-chart/
keywords:
- pasta grafiği
- grafik yönetimi
- grafik özelleştirme
- grafik seçenekleri
- grafik ayarları
- çizim seçenekleri
- dilim rengi
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript ile Aspose.Slides for Node.js via Java kullanarak pasta grafiklerini oluşturun ve özelleştirin. İkincil grafikler yapılandırın, veri etiketlerini gösterin ve PowerPoint'te otomatik dilim renkleri uygulayın."
---
## **Genel Bakış**

Bu makale Aspose.Slides'te pasta grafikleriyle nasıl çalışılacağını açıklar. Pie of Pie ve Bar of Pie grafikleri için ikincil grafik seçeneklerini nasıl yapılandıracağınızı ve standart bir pasta grafik için otomatik dilim renklendirmeyi nasıl etkinleştireceğinizi gösterir.

Örnekler, bir grafiği slayta ekleme, seri ve etiket ayarlarını düzenleme, varsayılan grafik verilerini özel kategoriler ve değerlerle değiştirme ve güncellenmiş sunumu kaydetme gibi grafik özelleştirme görevlerine odaklanır.

## **Pie of Pie ve Bar of Pie Grafikleri için İkincil Grafik Seçenekleri**

Node.js için Java üzerinden Aspose.Slides, Pie of Pie ve Bar of Pie grafikleri için ikincil grafik seçeneklerini destekler. Bu seçenekler, ikincil grafiğin boyutunu ve veri noktalarının iki grafik arasında nasıl bölüneceğini kontrol eder.

Aşağıdaki örnek, yeni bir sunumda Pie of Pie grafiği oluşturur ve veri noktası değerlerini etiket olarak gösterir. [setSecondPieSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setSecondPieSize) yöntemi ikincil grafik boyutunu ana grafiğin %149'una ayarlar. [setPieSplitBy](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitBy) yüzde tabanlı bölmeyi seçer ve [setPieSplitPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) eşik değerini %53 olarak belirler.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 500, 400);
    const series = chart.getChartData().getSeries().get_Item(0);

    // Değerleri göster ve ikincil grafiği yapılandır.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    const seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setSecondPieSize(149);
    seriesGroup.setPieSplitBy(aspose.slides.PieSplitType.ByPercentage);
    seriesGroup.setPieSplitPosition(53);

    presentation.save("pie_of_pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **İkincil Grafik İçin Kategorileri Seçme**

Özel bölme, belirli kategorileri yüzde değerleri ne olursa olsun ikincil grafikte gruplayarak göstermek istediğinizde kullanılır. Örneğin, bir satış raporu Online ve Events'i birlikte göstererek okuyucuların bu iki kanalı karşılaştırmasını sağlayabilir; bunlar toplam satışın %35 ve %10'unu oluşturur.

[setPieSplitBy](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitBy) yöntemini [PieSplitType.Custom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplittype/#Custom) ile çağırın ve noktaları [getPieSplitCustomPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints) ile seçin. Koleksiyonun [add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#add) yöntemi seride sıfır‑bazlı bir indeks alır; bir veri noktası nesnesi eklemek için [addItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#addItem) kullanın. Bu örnekte indeks 1 Online'ı, indeks 3 ise Events'i seçer. Partners da geçici olarak eklenir, ardından [removeItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#removeItem) ile çıkarılır.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 600, 200);

    // Varsayılan verileri kanal bazında satışlarla değiştir.
    const workbook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    const categoryNames = [ "Retail", "Online", "Partners", "Events" ];
    const values = [ 40, 35, 15, 10 ];
    const seriesNameCell = workbook.getCell(0, 0, 1, "Sales");
    const series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (let i = 0; i < categoryNames.length; i++) {
        const categoryCell = workbook.getCell(0, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        const valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    const seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setPieSplitBy(aspose.slides.PieSplitType.Custom);
    seriesGroup.setColorVaried(true);

    // Online'ı sıfır‑bazlı indeksiyle ve Events'i veri noktası nesnesiyle seç.
    seriesGroup.getPieSplitCustomPoints().add(1);
    seriesGroup.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3));

    // Partners'ı seçimin dışına çıkar, kaynak verisini silmeden.
    seriesGroup.getPieSplitCustomPoints().add(2);
    seriesGroup.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2));

    presentation.save("pie_of_pie_custom.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Online (35) ve Events (10) ikincil grafikte ayrı dilimler olarak görünür. Birincil grafikte ise 45 değerinde birleşik bir dilim, Retail (40) ve Partners (15) ile birlikte gösterilir. Partners'ın özel seçimden kaldırılması, onu birincil grafikte tutar; kategori ya da değeri grafik kaynak verilerinden silmez.

Aşağıdaki görsel, PowerPoint'te kaydedilen sunumu gösterir:

![Pie of Pie chart with Online and Events in the secondary plot and their combined value of 45 in the primary plot](pie_of_pie_custom.png)

## **Otomatik Pasta Grafiği Dilim Renklerini Ayarlama**

Node.js için Java üzerinden Aspose.Slides, pasta grafik dilimlerine otomatik olarak farklı renkler atayabilir. Aşağıdaki örnek, ortalanmış bir başlıkla pasta grafiği oluşturur ve varsayılan verileri üç çeyrek kategorisi ve değerleriyle değiştirir. [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/#setShowValue) yöntemi 20, 50 ve 30 değerlerini etiket olarak gösterirken, [setColorVaried](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setColorVaried) her dilim için farklı bir renk sağlar.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);

    // Ortalanmış bir grafik başlığı ekle.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Varsayılan verileri ilk çalışma sayfasını kullanarak değiştir.
    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    const categoryNames = [ "First Qtr", "2nd Qtr", "3rd Qtr" ];
    const values = [ 20, 50, 30 ];
    const seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    const series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (let i = 0; i < categoryNames.length; i++) {
        const categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        const valueCell = workbook.getCell(worksheetIndex, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    // Değerleri göster ve dilimlere farklı renkler ata.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getParentSeriesGroup().setColorVaried(true);

    presentation.save("pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SSS**

**Pie of Pie ve Bar of Pie varyasyonları destekleniyor mu?**

Evet, kütüphane [destekler](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) pasta grafikleri için ikincil grafik, Pie of Pie ve Bar of Pie tipleri dahil.

**Grafiği yalnızca bir resim (örneğin PNG) olarak dışa aktarabilir miyim?**

Evet, [grafiği doğrudan bir resim olarak dışa aktarabilirsiniz](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) (örneğin PNG) bütün sunumu dışa aktarmadan.