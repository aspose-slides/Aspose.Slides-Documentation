---
title: JavaScript Kullanarak Sunumlarda Grafik Veri Serilerini Yönetme
linktitle: Veri Serileri
type: docs
url: /tr/nodejs-java/chart-series/
keywords:
- grafik serisi
- seri örtüşmesi
- seri rengi
- seri adı
- veri noktası
- çalışma kitabı hücresi
- seri boşluğu
- negatif değer
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript ile sunumlarda grafik serilerini, veri noktalarını, çalışma kitabı hücrelerini, biçimlendirmeyi, örtüşmeyi, boşluk genişliğini ve negatif değerleri nasıl yöneteceğinizi öğrenin."
---
## **Genel Bakış**

Bir grafik, çizilen değerlerini çalışma kitabı hücrelerinde veya doğrudan sayısal sabitler olarak depolayabilir. [ChartSeries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/) bir grup ilişkili değeri temsil eder ve her [ChartDataPoint](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/) o serideki bir noktayı temsil eder. [ChartCategory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategory/) nesneleri, seriler tarafından paylaşılan etiketleri veya gruplama değerlerini sağlar. Varsayılan veri ile oluşturulan grafiklerde, seri adları, kategoriler ve nokta değerleri, grafik çalışma kitabından [ChartDataCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/) nesnelerini kullanır.

Tipik bir kategori grafiği için, varsayılan çalışma kitabı satır 0'ı seri adları, sütun 0'ı kategori adları ve kalan hücreleri seri değerleri için kullanır. Worksheet, satır ve sütun dizinleri [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getcell/) yöntemine sıfır tabanlı olarak iletilir. Bu düzen, varsayılan veri ile bir grafik oluştururken yararlıdır, ancak mevcut her grafiğin bunu kullandığını varsaymayın. Yüklenmiş bir sunumda, çalışma kitabı değerlerini değiştirmeden önce seriler, kategoriler ve veri noktaları tarafından başvurulan hücreleri inceleyin.

Grafik ayarları üç farklı kapsamda bulunur:

- Seri düzeyindeki ayarlar, örneğin [ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getformat/), bir serideki tüm noktalar için varsayılan görünümü sağlar.
- Veri noktası ayarları, örneğin [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getformat/), bir nokta için serinin görünümünü geçersiz kılar.
- Grup ayarları, aynı [ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/) ait uyumlu serilere uygulanır. Örtüşme veya boşluk genişliği gibi seçenekleri ayarlamanız gerektiğinde gruba [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/) üzerinden erişin.

Hiçbir açık nokta veya seri doldurma ayarı yapılmadığında, grafik stili ve teması otomatik görünümü belirler. Hem seri hem de nokta biçimlendirmesi mevcut olduğunda, nokta biçimlendirmesi o nokta için öncelikli olur.

![chart-series-powerpoint](chart-series-powerpoint.png)

Kümelenmiş silindir grafik için, [3D seri tipini veya çubuk şekli değiştirmek](/slides/tr/nodejs-java/3d-chart/#change-the-3d-series-type-and-bar-shape) bağlantısının ilk seriyi nasıl etkilediğine bakın.

## **Sayısal Sabitler Kullanarak Seri Değerlerini Ayarlama**

Seri değerleri uygulama verilerinden veya hesaplamalardan geldiğinde ve çalışma sayfası hücre referanslarına gerek olmadığında sayısal sabitler kullanın. [setDataSourceTypeForValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforvalues/) yöntemini, her noktanın [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getvalue/) sonucunu [setAsLiteralDouble](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/setasliteraldouble/) üzerinden atamadan önce [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) ile çağırın.

Koleksiyon ayarı, o serideki tüm nokta değerlerinin kaynak tipini kontrol eder. Her nokta değerinin [getDataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/basechartvalue/) metodu seçilen tipi rapor eder; bunu koleksiyon ayarıyla değiştirin. `Worksheet` ile, başvurulan hücreye erişmek için [getAsCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/getascell/) kullanın. `DoubleLiterals` ile, sayıyı doğrudan okumak veya yazmak için [getAsLiteralDouble](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/getasliteraldouble/) veya `setAsLiteralDouble` kullanın.

Aşağıdaki örnek, varsayılan seriler ve kategorilerle bir sütun grafik oluşturur, ardından ilk serisinin mevcut noktalarına 10, 20 ve devamı gibi hesaplanmış değerler atar. Sunumu kaydeder, tekrar açar ve saklanan değerleri yazdırır.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);
    const series = chart.getChartData().getSeries().get_Item(0);

    series.getDataPoints().setDataSourceTypeForValues(aspose.slides.DataSourceType.DoubleLiterals);
    for (let i = 0; i < series.getDataPoints().size(); i++) {
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10);
    }

    presentation.save("numeric_literals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation("numeric_literals.pptx");
try {
    const reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    const reopenedChart = reopenedSlide.getShapes().get_Item(0);
    const reopenedSeries = reopenedChart.getChartData().getSeries().get_Item(0);
    for (let i = 0; i < reopenedSeries.getDataPoints().size(); i++) {
        const point = reopenedSeries.getDataPoints().get_Item(i);
        console.log(point.getValue().getAsLiteralDouble());
    }
} finally {
    reopenedPresentation.dispose();
}
```

Nokta değeri kaynak türü, grafiğin iç veya dış çalışma kitabı yapılandırmasını belirleyen [ChartData.getDataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) öğesinden ayrıdır. Sayısal sabitler kullanmak, tek başına gömülü çalışma kitabını kaldırmaz. Bu örnekte, çalışma kitabı kategori etiketleri, seri adları ve diğer seriler için hâlâ kullanılabilir. Çalışma kitabı yönetimi için [Grafik Çalışma Kitabı](/slides/tr/nodejs-java/chart-workbook/) bölümüne bakın.

Dağılma ve baloncuk grafikleri için, [getXValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getxvalue/) ve [getYValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getyvalue/) kaynaklarını seçmek üzere [setDataSourceTypeForXValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforxvalues/) ve [setDataSourceTypeForYValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforyvalues/) yöntemlerini kullanın. Baloncuk grafiklerinde ayrıca [getBubbleSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getbubblesize/) için [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforbubblesizes/) kullanılır. Sayıları o değerin `setAsLiteralDouble` yöntemiyle atamadan önce ilgili kaynakları `DoubleLiterals` olarak ayarlayın.

## **Grafik Serisi Örtüşmesini Ayarlama**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getoverlap/) 2D bir grafikte çubukların veya sütunların ne kadar örtüştüğünü -%100'den %100'e kadar rapor eder. Bu, ana seri grubundaki ayarın yalnızca okunabilir bir yansımasıdır. Bu gruptaki uyumlu tüm serileri güncellemek için [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setoverlap/) kullanın. Bu seçenek, gruplanmış çubuk veya sütun gösteren grafik türlerine uygulanır; birleşik bir grafikte ilgili olmayan seri gruplarını etkilemez.

Aşağıdaki örnek, ilk seriyi içeren grup için örtüşmeyi ayarlar:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const overlapPercent = java.newByte(30);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    // Yeni grafik örnek seriler, kategoriler ve değerler içerir.
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![The series overlap](series_overlap.png)

## **Seri Dolgu Rengini Değiştirme**

Tüm bir seri için varsayılan doldurmayı ayarlamak üzere [ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getformat/) kullanın. Bir noktanın zaten açık bir doldurması varsa, onun [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getformat/) ayarı serinin doldurmasını o nokta için geçersiz kılar.

Aşağıdaki örnek, ilk seriye katı mavi bir doldurma uygular:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(blueColor);

    presentation.save("series_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![The color of the series](series_color.png)

## **Seri Adını Değiştirme**

Seri adı, grafik veri çalışma kitabında saklanır ve normalde lejende gösterilir. Kümelenmiş sütun grafik için oluşturulan varsayılan çalışma kitabında, B1 hücresi satır 0, sütun 1'de bulunur ve ilk serinin adını içerir. Aşağıdaki örnekteki isimlendirilmiş sabitler bu yapıyı açıkça gösterir:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const worksheetIndex = 0;
const seriesNameRowIndex = 0;
const firstSeriesColumnIndex = 1;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const workbook = chart.getChartData().getChartDataWorkbook();
    const seriesNameCell = workbook.getCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[ChartSeries.getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getname/) ile zaten başvurulan hücreyi de güncelleyebilirsiniz. Bu yaklaşım, mevcut bir grafikte belirli bir satır ve sütun varsayımından kaçınır:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const firstNameCellIndex = 0;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const seriesNameCell = series.getName().getAsCells().get_Item(firstNameCellIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![The series name](series_name.png)

### **Birden Çok Hücreden Oluşan Seri İsmi Oluşturma**

Bir bileşik seri adı, ürün adı ve raporlama dönemi ayrı çalışma kitabı hücrelerinde saklandığında kullanışlıdır. Örneğin, B1'deki `Product A` ve C1'deki `2026` değerlerini tek bir seri adı olarak birleştirebilir ve her iki kısmın da kaynak hücrelerine bağlı kalmasını sağlayabilirsiniz.

[ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getcellcollection/) kullanarak ad aralığını alın, ardından bu koleksiyonu [ChartSeriesCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriescollection/add/) yöntemine geçirin. `skipHiddenCells` argümanı gizli hücrelerin dahil edilip edilmeyeceğini kontrol eder: `true` dışlar, `false` dahil eder. Bu örnek, ad aralığındaki tüm hücreleri dahil etmek için `false` kullanır.

Aşağıdaki örnek, bir seri ve iki veri noktasına sahip bir sunum oluşturur. B1:C1 hücreleri yalnızca seri adını sağlar; A2:A3 kategori etiketlerini, B2:B3 ise sayısal değerleri sağlar.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 620, 180);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(true);

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // Bu iki hücre seri adını sağlar.
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    const nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    const series = chart.getChartData().getSeries().add(nameCells, aspose.slides.ChartType.ClusteredColumn);

    // Ayrı hücreler kategorileri ve sayısal veri noktalarını sağlar.
    const northCategory = workbook.getCell(0, 1, 0, "North");
    const southCategory = workbook.getCell(0, 2, 0, "South");
    chart.getChartData().getCategories().add(northCategory);
    chart.getChartData().getCategories().add(southCategory);
    const northValue = workbook.getCell(0, 1, 1, 120);
    const southValue = workbook.getCell(0, 2, 1, 150);
    series.getDataPoints().addDataPointForBarSeries(northValue);
    series.getDataPoints().addDataPointForBarSeries(southValue);

    presentation.save("composite_series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ortaya çıkan seri adı `Product A 2026` olup iki hücre değeri arasında bir boşluk vardır. Lejende bu, iki sütun için tek bir giriş olarak gösterilir. Aşağıdaki resim sonucu göstermektedir:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Otomatik Seri Dolgu Rengini Almak**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getautomaticseriescolor/) seri indeksinden ve grafik stilinden hesaplanan rengi döndürür. Bu, seri doldurması açıkça tanımlanmadığında kullanılan renktir. Yöntemi çağırmak, hesaplanan rengi okur; yeni bir doldurma atamaz.

Aşağıdaki örnek, her varsayılan serinin otomatik rengini yazdırır:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const seriesCount = chart.getChartData().getSeries().size();
    for (let seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const automaticColor = series.getAutomaticSeriesColor();
        const automaticColorText = automaticColor.toString();
        console.log("Series " + seriesIndex + ": " + automaticColorText);
    }
} finally {
    presentation.dispose();
}
```

Varsayılan grafik stili için örnek çıktı:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Kesin renkler grafik stili ve temaya bağlıdır.

## **Grafik Serisi için Ters Doldurma Rengini Ayarlama**

Çubuk, sütun ve baloncuk serileri için, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setinvertifnegative/) negatif değerleri farklı bir doldurma ile gösterebilir. Normal seri doldurmasını katı olarak ayarlayın, terslemeyi etkinleştirin ve negatif değer rengini [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getinvertedsolidfillcolor/) aracılığıyla atayın. Negatif sayılar çalışma kitabında değişmez; yalnızca gösterim rengi değişir.

Aşağıdaki örnek, varsayılan grafik verilerini bir seri ile değiştirir. Çalışma sayfası satır 0 seri adını, sütun 0 kategori adlarını ve sütun 1 değerleri içerir:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const worksheetIndex = 0;
const headerRowIndex = 0;
const categoryColumnIndex = 0;
const firstSeriesColumnIndex = 1;
const firstDataRowIndex = 1;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const redColor = java.getStaticFieldValue("java.awt.Color", "RED");

const categoryNames = ["Category 1", "Category 2", "Category 3"];
const seriesValues = [-20, 50, -30];

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);
    const chartData = chart.getChartData();
    const workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    const seriesNameCell = workbook.getCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
    const chartType = chart.getType();
    const series = chartData.getSeries().add(seriesNameCell, chartType);

    for (let categoryIndex = 0; categoryIndex < categoryNames.length; categoryIndex++) {
        const dataRowIndex = firstDataRowIndex + categoryIndex;
        const categoryName = categoryNames[categoryIndex];
        const seriesValue = seriesValues[categoryIndex];

        const categoryCell = workbook.getCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
        chartData.getCategories().add(categoryCell);

        const valueCell = workbook.getCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    const automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.setInvertIfNegative(true);
    series.getInvertedSolidFillColor().setColor(redColor);

    presentation.save("inverted_solid_fill_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![The inverted solid fill color](inverted_solid_fill_color.png)

Bir nokta için terslemeyi [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/setinvertifnegative/) yöntemiyle etkinleştirebilirsiniz. Aşağıdaki örnekte tersleme seri için devre dışı bırakılmış ve yalnızca seçilen nokta için etkinleştirilmiştir. Noktaya, etkinin görünür olması için negatif bir değer de atanır:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const targetDataPointIndex = 2;
const negativeValue = -30;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const redColor = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.getInvertedSolidFillColor().setColor(redColor);
    series.setInvertIfNegative(false);

    const dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(negativeValue);
    dataPoint.setInvertIfNegative(true);

    presentation.save("data_point_invert_color_if_negative.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Belirli Bir Veri Noktası Değerini Temizleme**

Diğer noktaları kaldırmadan bir noktayı boş yapmak için, ona ait çalışma kitabı hücresini `null` olarak ayarlayın. Sütun grafik için, çizilen değer [ChartDataPoint.getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getvalue/) üzerinden elde edilebilir. Veri noktası aynı kategori konumunda kalır, ancak grafik değerini boş olarak, grafik boş değer ayarlarına göre işler.

Aşağıdaki örnek, ilk serideki yalnızca ikinci noktayı temizler:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const targetDataPointIndex = 1;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(null);

    presentation.save("clear_data_point_value.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dağılma grafikler ayrı X ve Y hücreleri kullanır, baloncuk grafikler ayrıca bir boyut hücresi kullanır. Kaldırmak istediğiniz değeri temsil eden hücreyi yalnızca temizleyin. Diğer noktaları korumak istediğinizde [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/clear/) çağırmayın; bu yöntem koleksiyondaki tüm veri noktalarını siler.

## **Boş Hücrelerin Görüntülenmesini Kontrol Etme**

Değer içeren gizli hücreler boş hücrelerden ayrı bir durumdur. Gizli satır ve sütunlardan veri dahil etmek veya hariç tutmak için [Gizli Satır ve Sütunlardan Veri İçerme](/slides/tr/nodejs-java/chart-workbook/#include-data-from-hidden-rows-and-columns) bölümüne bakın. Boş bir çalışma kitabı hücresi eksik veriyi temsil eder; `0` içeren bir hücre bilinen sayısal bir değeri temsil eder. Bir hücreyi boş yapmak için [ChartDataCell.setValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setvalue/) metodunu `null` ile çağırın. Sayısal sıfır, boş hücre ayarına bakılmaksızın sıfır olarak kalır.

[Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/) kullanarak grafiğin boş hücreleri nasıl göstereceğini seçin. Bu ayar tüm grafiğe uygulanır. Boşlukların nasıl çizileceğini değiştirir, boş çalışma kitabı hücresini sıfır ya da ara değerle doldurmaz.

Aşağıdaki bağımsız örnek, bir seri ile bir çizgi grafik oluşturur, 3. Gün değerini temizler ve grafiği her modda kaydeder. Giriş dosyasına gerek yoktur. [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/) çalışma sayfası 0, kategori etiketleri için sütun 0 ve değerler için sütun 1 kullanır; satır 0 seri adını tutar. Son veri `10, 20, empty, 30, 40` şeklindedir.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 40, 40, 640, 400);
    const chartData = chart.getChartData();
    const workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    const seriesNameCell = workbook.getCell(0, 0, 1, "Measurements");
    const series = chartData.getSeries().add(seriesNameCell, chart.getType());
    const values = [10, 20, 25, 30, 40];

    for (let i = 0; i < values.length; i++) {
        const categoryCell = workbook.getCell(0, i + 1, 0, "Day " + (i + 1));
        chartData.getCategories().add(categoryCell);
        const valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // 3. Günü gerçekten boş bırak, ancak onun kategorisini ve veri noktasını tut.
    workbook.getCell(0, 3, 1).setValue(null);

    const modes = [aspose.slides.DisplayBlanksAsType.Gap, aspose.slides.DisplayBlanksAsType.Zero, aspose.slides.DisplayBlanksAsType.Span];
    const modeNames = ["Gap", "Zero", "Span"];
    for (let i = 0; i < modes.length; i++) {
        chart.setDisplayBlanksAs(modes[i]);
        presentation.save("empty_cells_" + modeNames[i] + ".pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Her çıktı dosyası, kaydetmeden önce atanmış modu saklar: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` ve `empty_cells_Span.pptx`. Tek bir sürüm kaydetmek için, istenen modu atayın ve modlar üzerinde döngü kurmak yerine sunumu bir kez kaydedin.

Aşağıdaki karşılaştırma, aynı veriyi üç dosyada gösterir. 3. Gün çalışma kitabında her durumda boştur:

![Aynı veriye sahip çizgi grafikler: Gap 3. Günde çizgiyi kırar, Zero çizgiyi sıfıra düşürür, Span 2. Günü 4. Güne bağlar.](display_blanks_as.png)

Görünür etki grafik tipine bağlıdır. Çizgi grafik, üç modu da karşılaştırmayı kolaylaştırır. Çubuk ve sütun grafiklerde eksik bir kategori üzerinden bağlayacak bir çizgi olmadığı için `Span` yukarıdaki bağlayıcı segmenti oluşturamaz; eksik bir sütun ve sıfır yüksekliğindeki bir sütun da benzer görünebilir. Benzer şekilde, yalnızca işaretçileri olan bir dağılma grafiğinde bağlayıcı çizgi yoktur. Her grafik tipinde üç ayrı sonuç beklemeyin; kullandığınız tip için çıktıyı kontrol edin.

## **Seri Boşluk Genişliğini Ayarlama**

Boşluk genişliği, yan yana çubuk veya sütun kümeleri arasındaki boşluktur ve çubuk veya sütun genişliğinin yüzdesi olarak ifade edilir. Örtüşme gibi, bu da tek bir seriye değil, ana seri grubuna aittir. Grup için bir kez [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) çağırın. Daha büyük değer kümeler arasındaki boşluğu artırır; daha küçük değer onları daha yoğun yapar.

Aşağıdaki örnek, boşluk genişliğini değiştirir ve yalnızca son sunumu kaydeder:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const gapWidthPercent = 30;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setGapWidth(gapWidthPercent);

    presentation.save("gap_width_30.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![The gap width](gap_width.png)

## **Seri Çizgilerini Gösterme veya Gizleme**

Seri çizgileri, bir grafiğin ilgili bölümlerini görsel olarak bağlar. Desteklenen yığılmış çubuk ve OfPie grafiklerinde göstermek veya gizlemek için [ChartSeriesGroup.setSeriesLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setserieslines/) kullanın. İki boyutlu yığılmış çubuk ve sütun grafiklerde, kategori içinde ilgili yığın sınırlarını bağlar. Pie of Pie ve Bar of Pie grafiklerinde, ana çizimi ikincil çizime bağlar. Bu ayar diğer grafik tipleri için genel amaçlı bir bağlayıcı değildir.

[ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/) üzerinden gruba erişin. Ayar, o gruptaki tüm serilere uygulanır. [ChartSeries.hasSeriesLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/hasserieslines/) yalnızca okunabilir ve ana grup ayarını yansıtır; güncellemek için grubun ayarlayıcısını çağırın.

Aşağıdaki örnek, varsayılan veriyle bir [PieOfPie](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) grafik oluşturur. Aynı grafiği seri çizgileri etkinleştirilmiş ve ardından devre dışı bırakılmış şekilde kaydeder; karşılaştırma için iki sunum üretir.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 600, 400);
    const series = chart.getChartData().getSeries().get_Item(0);
    const seriesGroup = series.getParentSeriesGroup();

    seriesGroup.setSeriesLines(true);
    presentation.save("series_lines_enabled.pptx", aspose.slides.SaveFormat.Pptx);

    seriesGroup.setSeriesLines(false);
    presentation.save("series_lines_disabled.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Seri çizgileri etkin | Seri çizgileri devre dışı |
| --- | --- |
| ![Pie of Pie chart with series lines enabled](series_lines_enabled.png) | ![Pie of Pie chart with series lines disabled](series_lines_disabled.png) |
| İki çizgi, ana pasta dilimini ikincil pasta dilimine bağlar. | Her iki pasta da görünür kalır, ancak bağlayıcı çizgiler gizlenir. |

Seri çizgileri, etiketleri veri noktalarına bağlayan veri etiketi lider çizgileri, grafik eksenleri boyunca aralıkları işaretleyen ızgara çizgileri ve veri değerlerini temsil eden çizgi grafik çizgileri gibi öğelerden farklıdır. Bu ayar bu öğeleri kontrol etmez.

## **SSS**

**Hangi grafik tipleri veri serilerini destekler?**  
Tüm grafik tipleri, [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) enum'ı tarafından temsil edilen, grafik verisi kullanır, ancak serileri aynı değer yapısına veya ayarlara sahip değildir. Örneğin, kategori grafikler kategori ve değer kullanır, dağılma grafikler X ve Y değerlerini, baloncuk grafikler ise ek olarak baloncuk boyutlarını kullanır. Seri tipine uygun veri noktası oluşturma metodunu kullanın. Örtüşme ve boşluk genişliği gibi seçenekler yalnızca uyumlu çubuk veya sütun gruplarında geçerlidir.

**Grafik seri grubu nedir?**  
[ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/) uyumlu serileri, grup düzeyindeki çizim ayarlarını paylaşacak şekilde içerir. Bir kombinasyon grafiği birden fazla grup içerebilir; bu nedenle bir seriden erişilen grup değiştirildiğinde, grafikteki tüm seriler mutlaka değişmez.

**Yeni oluşturulan bir grafik varsayılan veri içerir mi?**  
Evet. Varsayılan olarak, [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) örnek seriler, kategoriler ve değerler oluşturur. Bu hücreleri düzenleyebilir veya tamamen özel bir veri seti eklemeden önce seri ve kategori koleksiyonlarını temizleyebilirsiniz. Bir aşırı yükleme (overload) aynı zamanda varsayılan veri olmadan bir grafik oluşturabilir.

**Grafik nesneleri çalışma kitabı hücrelerine nasıl bağlanır?**  
Seri adları, kategori etiketleri ve veri noktası değerleri, bir [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/) içindeki hücrelere başvurur. Başvurulan hücreyi değiştirmek, ilgili grafik öğesini günceller. Özel veri oluştururken, her noktanın istenen kategori altında çizileceği şekilde kategori satırları ve seri-değer satırlarını hizalı tutun.

**Tüm seriyi değil, tek bir noktayı nasıl temizlerim?**  
İlgili değer hücresini `null` olarak ayarlayarak, noktanın kategori konumunu boş bir nokta olarak koruyun. [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/clear/) yöntemini yalnızca o serideki tüm noktaları kaldırmak istediğinizde kullanın. Kategorileri de kaldırıyorsanız, her seriyi güncelleyerek değerlerinin kategori koleksiyonu ile hizalı kalmasını sağlayın.

**Boş noktalar nasıl görüntülenir?**  
Sonuç, grafik tipine ve [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/) aracılığıyla yapılandırılan değere bağlıdır. Desteklenen grafikler boşlukları boşluk olarak, sıfır değeri olarak veya komşu noktaları bağlayarak gösterebilir. Sunumunuzdaki eksik verinin anlamına uygun ayarı seçin. Tam bir örnek ve görsel karşılaştırma için [Boş Hücrelerin Görüntülenmesini Kontrol Etme](#control-the-display-of-empty-cells) bölümüne bakın.

**Negatif değerler nasıl biçimlendirilir?**  
Desteklenen çubuk, sütun ve baloncuk serileri için, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setinvertifnegative/) çağırın ve [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getinvertedsolidfillcolor/) tarafından döndürülen rengi ayarlayın. Tek bir nokta için davranışı [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/setinvertifnegative/) ile geçersiz kılabilirsiniz. Bu yöntemler biçimlendirmeyi etkiler, saklanan sayısal değerleri değil.

**Bir seri ve bir nokta aynı anda biçimlendirildiğinde hangi biçimlendirme geçerli olur?**  
Açık veri noktası biçimlendirmesi o nokta için önceliklidir. Diğer noktalar, açık seri biçimini ya da seri biçimi tanımlı değilse otomatik grafik stilini ve temasını kullanmaya devam eder. Örtüşme ve boşluk genişliği gibi grup ayarları düzeni kontrol eder ve nokta düzeyinde biçimlendirme geçersiz kılmaları değildir.

**Bir grafiğin içerebileceği seri sayısında bir sınırlama var mı?**  
Aspose.Slides ayrı bir sabit seri sayısı sınırlaması getirmez. Pratikte, sunum dosyası kısıtlamaları, mevcut bellek, işleme süresi ve grafiğin okunabilirliği kullanışlı bir sınır belirler.

**Sütunlar çok yakın ya da çok uzak olduğunda neyi değiştirmeliyim?**  
Uygun ana seri grubunda [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) metodunu çağırın. Değeri artırarak kümeler arasındaki boşluğu genişletin, azaltarak kümeleri birbirine daha yakın hale getirin.