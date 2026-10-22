---
title: Sunumlarda JavaScript Kullanarak Grafik Veri Serilerini Yönetme
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
description: JavaScript ile sunumlarda grafik serileri, veri noktaları, çalışma kitabı hücreleri, biçimlendirme, örtüşme, boşluk genişliği ve negatif değerleri nasıl yöneteceğinizi öğrenin.
---
## **Genel Bakış**

Bir grafik, çizilen değerlerini çalışma kitabı hücrelerinde veya doğrudan sayısal sabitler olarak depolayabilir. Bir [ChartSeries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/) bir dizi ilgili değeri temsil eder ve her [ChartDataPoint](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/) o serideki bir noktayı temsil eder. [ChartCategory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategory/) nesneleri seriler tarafından paylaşılan etiketleri veya gruplama değerlerini sağlar. Varsayılan veri ile oluşturulan grafiklerde, seri adları, kategoriler ve nokta değerleri grafik çalışma kitabındaki [ChartDataCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/) nesnelerini kullanır.

Tipik bir kategori grafiği için, varsayılan çalışma kitabı seri adları için satır 0, kategori adları için sütun 0 ve kalan hücreleri seri değerleri için kullanır. [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getcell/) yöntemine geçirilen çalışma sayfası, satır ve sütun indeksleri sıfır‑tabanlıdır. Bu düzen, varsayılan veri ile bir grafik oluşturduğunuzda kullanışlıdır, ancak mevcut her grafiğin bunu kullandığını varsaymayın. Yüklenmiş bir sunum için, çalışma kitabı değerlerini değiştirmeden önce seriler, kategoriler ve veri noktaları tarafından başvurulan hücreleri inceleyin.

Grafik ayarlarının üç farklı kapsamı vardır:

- Seri düzeyindeki ayarlar, örneğin [ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getformat/), bir serideki tüm noktalar için varsayılan görünümü sağlar.
- Veri noktası ayarları, örneğin [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getformat/), bir nokta için seri görünümünü geçersiz kılar.
- Grup ayarları, aynı [ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/) içinde yer alan uyumlu serilere uygulanır. Örtüşme veya boşluk genişliği gibi seçenekleri ayarlamanız gerektiğinde grubu [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/) aracılığıyla erişin.

Açık bir nokta veya seri dolgu ayarı yoksa, grafik stili ve teması otomatik görünümü belirler. Hem seri hem de nokta biçimlendirmesi mevcutsa, nokta biçimlendirmesi o nokta için önceliklidir.

![grafik-seri-powerpoint](chart-series-powerpoint.png)

## **Seri Değerlerini Sayısal Sabitlerle Ayarlama**

Seri değerleri uygulama verilerinden veya hesaplamalarından geliyorsa ve çalışma sayfası hücre referanslarına ihtiyaç duymuyorsa sayısal sabitler kullanın. Her noktanın [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getvalue/) sonucunu [setAsLiteralDouble](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/setasliteraldouble/) aracılığıyla atamadan önce [setDataSourceTypeForValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforvalues/) yöntemini [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) ile birlikte çağırın.

Koleksiyon ayarı, o serideki tüm nokta değerlerinin kaynak tipini kontrol eder. Her nokta değerinin [getDataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/basechartvalue/) yöntemi seçili tipi bildirir; tip değişikliği koleksiyon ayarı aracılığıyla yapılır. `Worksheet` kullanıyorsanız, başvurulan hücreye erişmek için [getAsCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/getascell/) yöntemini kullanın. `DoubleLiterals` kullanıyorsanız, sayıyı doğrudan okumak veya yazmak için [getAsLiteralDouble](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/getasliteraldouble/) veya `setAsLiteralDouble` yöntemini kullanın.

Aşağıdaki örnek, varsayılan seriler ve kategorilerle bir sütun grafik oluşturur, ardından ilk serisinin mevcut noktalarına 10, 20 vb. hesaplanan değerleri atar. Sunumu kaydeder, yeniden açar ve depolanan değerleri yazdırır.

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

Nokta değeri kaynak tipi, grafiğin dahili veya harici çalışma kitabı yapılandırmasını belirten [ChartData.getDataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) öğesinden ayrıdır. Sayısal sabitlerin kullanılması, gömülü çalışma kitabını otomatik olarak kaldırmaz. Bu örnekte, çalışma kitabı hâlâ kategori etiketleri, seri adları ve diğer seriler için kullanılabilir. Çalışma kitabı yönetimi için [Chart Workbook](/slides/tr/nodejs-java/chart-workbook/) bölümüne bakın.

Dağılım (scatter) ve balon grafiklerinde, [setDataSourceTypeForXValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforxvalues/) ve [setDataSourceTypeForYValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforyvalues/) yöntemleri sırasıyla [getXValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getxvalue/) ve [getYValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getyvalue/) kaynaklarını seçmek için kullanılır. Balon grafikler ayrıca [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforbubblesizes/) ile [getBubbleSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getbubblesize/) kaynağını belirler. Her ilgili kaynağı `DoubleLiterals` olarak ayarlayın ve ardından o değerin `setAsLiteralDouble` yöntemiyle sayı atayın.

## **Grafik Serisi Örtüşmesini Ayarlama**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getoverlap/) yöntemi, 2D bir grafikte çubukların veya sütunların ne kadar örtüştüğünü –100 ile 100 yüzde arasında – raporlar. Bu, üst seri grubundaki ayarın yalnızca okunabilir bir yansımasıdır. Gruptaki tüm uyumlu serileri güncellemek için [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setoverlap/) yöntemini kullanın. Bu seçenek, gruplanmış çubuk veya sütun gösteren grafik türleri için geçerlidir; birleşik bir grafikteki ilişkili olmayan seri gruplarını etkilemez.

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

![Seri örtüşmesi](series_overlap.png)

## **Seri Dolgu Rengini Değiştirme**

Tüm seri için varsayılan dolgu ayarlamak üzere [ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getformat/) yöntemini kullanın. Bir nokta zaten açık bir dolguya sahipse, o noktanın [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getformat/) ayarı seri dolgusunu geçersiz kılar.

Aşağıdaki örnek, ilk seriye katı mavi bir dolgu uygular:

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

![Seri rengi](series_color.png)

## **Seri Adını Değiştirme**

Seri adı grafik veri çalışma kitabında depolanır ve genellikle lejende gösterilir. Küme sütun grafiği için oluşturulan varsayılan çalışma kitabında, B1 hücresi (satır 0, sütun 1) ilk serinin adını içerir. Aşağıdaki örnekteki adlandırılmış sabitler bu yapıyı açıkça gösterir:

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

Ayrıca, [ChartSeries.getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getname/) tarafından zaten başvurulan hücreyi güncelleyebilirsiniz. Bu yaklaşım, mevcut bir grafikte belirli bir satır ve sütun varsayımını ortadan kaldırır:

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

![Seri adı](series_name.png)

### **Birden Çok Hücreden Oluşan Seri Adı Oluşturma**

Ürün adı ve raporlama dönemi ayrı çalışma kitabı hücrelerinde saklanıyorsa birleşik bir seri adı yararlı olabilir. Örneğin, B1’deki `Product A` ve C1’deki `2026` değerlerini tek bir seri adı olarak birleştirirken her iki kısmın da kaynak hücrelerine bağlı kalmasını sağlayabilirsiniz.

İsim aralığını almak için [ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getcellcollection/) yöntemini kullanın, ardından bu koleksiyonu [ChartSeriesCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriescollection/add/) yöntemine gönderin. `skipHiddenCells` bağımsız değişkeni gizli hücrelerin dahil edilip edilmediğini kontrol eder: `true` gizli hücreleri dışlar, `false` dahil eder. Bu örnek, isim aralığındaki her hücreyi dahil etmek için `false` kullanır.

Aşağıdaki örnek, bir seri ve iki veri noktası içeren bir sunum oluşturur. B1:C1 hücreleri yalnızca seri adını, A2:A3 hücreleri kategori etiketlerini ve B2:B3 hücreleri sayısal değerleri sağlar.

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

Ortaya çıkan seri adı `Product A 2026` olur; iki hücre değeri arasında bir boşluk bulunur. Lejende bu, iki sütun için tek bir giriş olarak gösterilir. Sonuç aşağıdaki görselde gösterilmiştir:

![Kuzey ve Güney değerleriyle sütun grafik ve birleşik seri adı Product A 2026 lejende](composite_series_name.png)

## **Otomatik Seri Dolgu Rengini Alma**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getautomaticseriescolor/) yöntemi, seri indeksi ve grafik stilinden hesaplanan rengi döndürür. Seri dolgu açıkça tanımlanmamışsa kullanılan renk budur. Yöntem, hesaplanan rengi okur; yeni bir dolgu atamaz.

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

Tam renkler grafik stiline ve temaya bağlıdır.

## **Bir Grafik Serisi için Ters Dolgu Rengini Ayarlama**

Çubuk, sütun ve balon serileri için, negatif değerleri farklı bir dolgu ile göstermek amacıyla [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setinvertifnegative/) yöntemi kullanılabilir. Normal seri dolgusunu katı olarak ayarlayıp terslemeyi etkinleştirin ve negatif değer rengini [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getinvertedsolidfillcolor/) yöntemiyle atayın. Negatif sayılar çalışma kitabında değişmeden kalır; yalnızca gösterim rengi değişir.

Aşağıdaki örnek, varsayılan grafik verisini tek bir seriyle değiştirir. Çalışma sayfası satır 0 seri adını, sütun 0 kategori adlarını ve sütun 1 değerleri içerir:

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

![Ters katı dolgu rengi](inverted_solid_fill_color.png)

Bir nokta için terslemeyi etkinleştirmek isterseniz, [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/setinvertifnegative/) yöntemini kullanabilirsiniz. Aşağıdaki örnekte, seri için tersleme devre dışı bırakılmış ve yalnızca seçili nokta için etkinleştirilmiştir. Etkiyi görmek için nokta negatif bir değere de atanmıştır:

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

## **Belirli Bir Veri Noktasının Değerini Temizleme**

Diğer noktaları kaldırmadan bir noktayı boş bırakmak için ilgili çalışma kitabı hücresini `null` olarak ayarlayın. Bir sütun grafiğinde, çizilen değer [ChartDataPoint.getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getvalue/) yöntemiyle elde edilir. Veri noktası aynı kategori konumunda kalır, ancak grafik boş‑değer ayarına göre değeri boş olarak işler.

Aşağıdaki örnek, ilk seride sadece ikinci noktayı temizler:

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

Dağılım grafiklerinde X ve Y hücreleri ayrı ayrı, balon grafiklerinde ise ek bir boyut hücresi bulunur. Kaldırmak istediğiniz değere karşılık gelen hücreyi yalnızca temizleyin. Diğer noktaları korumak istediğinizde [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/clear/) yöntemini çağırmayın; bu yöntem koleksiyondaki tüm veri noktalarını siler.

## **Boş Hücrelerin Görüntülenmesini Kontrol Etme**

Değer içeren gizli hücreler, boş hücrelerden farklı bir durum oluşturur. Gizli çalışma sayfası satır ve sütunlarından veri dahil etmek veya hariç tutmak için [Include Data from Hidden Rows and Columns](/slides/tr/nodejs-java/chart-workbook/#include-data-from-hidden-rows-and-columns) bölümüne bakın.

Boş bir çalışma kitabı hücresi eksik veriyi temsil eder; `0` içeren bir hücre bilinen sayısal bir değeri temsil eder. Hücreyi boş yapmak için [ChartDataCell.setValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setvalue/) yöntemine `null` gönderin. Sayısal sıfır, boş‑hücre ayarına bakılmaksızın sıfır olarak kalır.

Boş hücrelerin grafik üzerinde nasıl gösterileceğini seçmek için [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/) yöntemini kullanın. Bu ayar tüm grafik için geçerlidir ve boş değerlerin nasıl çizileceğini değiştirir; hücreleri sıfırla veya interpolasyonla doldurmaz.

Aşağıdaki bağımsız örnek bir satır grafik oluşturur, 3. günün değerini temizler ve her modu ayrı bir dosya olarak kaydeder. Giriş dosyasına gerek yoktur. [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/) çalışma sayfası 0, kategori etiketleri için sütun 0 ve değerler için sütun 1 kullanır; satır 0 seri adını tutar. Son veri `10, 20, boş, 30, 40` şeklindedir.

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

    // 3. günü gerçekten boş bırak, ancak kategori ve veri noktasını koru.
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

Her çıktı dosyası, kaydetmeden önce atanan modu içerir: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` ve `empty_cells_Span.pptx`. Tek bir sürüm kaydetmek isterseniz, istediğiniz modu atayıp sunumu bir kez kaydedin, modlar arasında döngü yapmayın.

Aşağıdaki karşılaştırma aynı veriyi üç dosyada gösterir. 3. gün çalışma kitabında her durumda boştur:

![Kimliksiz çizgi grafikler: Gap çizgiyi 3. günde keser, Zero çizgiyi sıfıra düşürür, Span ise 2. günden 4. güne bağlar.](display_blanks_as.png)

Görünüm etkisi grafik türüne bağlıdır. Çizgi grafikleri üç modu da net bir şekilde karşılaştırmaya olanak tanır. Çubuk ve sütun grafiklerinde eksik bir kategori için bağlayacak bir çizgi olmadığından `Span` görünür bir bağlantı segmenti üretmez; eksik bir sütun ve sıfır‑yüksekliğinde bir sütun da benzer görünebilir. Benzer şekilde, yalnızca işaretleyicileri olan dağılım grafiklerinde de bağlayıcı bir çizgi yoktur. Her grafik türü için üç farklı sonuç beklemeyin; kullandığınız türün çıktısını kontrol edin.

## **Seri Boşluk Genişliğini Ayarlama**

Boşluk genişliği, komşu çubuk veya sütun kümeleri arasındaki boşluğu, çubuk veya sütun genişliğinin yüzdesi olarak ifade eder. Örtüşme gibi, seriye ait değil, üst seri grubuna aittir. Gruba bir kez [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) yöntemiyle erişin. Daha büyük bir değer kümeler arası daha fazla alan yaratır; daha küçük bir değer onları daha yoğun hâle getirir.

Aşağıdaki örnek boşluk genişliğini değiştirir ve yalnızca son sunumu kaydeder:

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

![Boşluk genişliği](gap_width.png)

## **SSS**

**Hangi grafik türleri veri serilerini destekler?**

[ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) enum’u tarafından temsil edilen tüm grafik türleri veri içerir, ancak serileri aynı değer yapısına veya ayarlara sahip olmayabilir. Örneğin, kategori grafiklerinde kategori ve değer, dağılım grafiklerinde X ve Y değer, balon grafiklerinde ise balon boyutları bulunur. Seri türüne uygun veri‑nokta oluşturma yöntemini kullanın. Örtüşme ve boşluk genişliği gibi seçenekler yalnızca uyumlu çubuk veya sütun gruplarında geçerlidir.

**Grafik seri grubu nedir?**

[ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/) aynı grup‑seviye çizim ayarlarını paylaşan uyumlu serileri içerir. Kombinasyon grafiği birden fazla grup içerebilir; bir seriden ulaşarak grup ayarlarını değiştirmek, grafikteki tüm serileri zorunlu olarak değiştirmez.

**Yeni oluşturulan bir grafik varsayılan veri içerir mi?**

Evet. Varsayılan olarak, [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) örnek seriler, kategoriler ve değerler oluşturur. Bu hücreleri düzenleyebilir veya tamamen özel bir veri seti eklemeden önce serileri ve kategori koleksiyonlarını temizleyebilirsiniz. Bir aşırı yükleme (overload) aynı zamanda varsayılan veri olmadan bir grafik oluşturabilir.

**Grafik nesneleri çalışma kitabı hücrelerine nasıl bağlanır?**

Seri adları, kategori etiketleri ve veri‑nokta değerleri bir [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/) içinde hücrelere başvurur. Başvurulan bir hücreyi değiştirmek ilgili grafik öğesini günceller. Özel veri oluştururken, her noktanın istediğiniz kategori altında çizildiğinden emin olmak için kategori satırları ve seri‑değer satırlarını hizalı tutun.

**Tüm seriyi temizlemeden sadece bir noktayı nasıl temizlerim?**

İlgili değer hücresini `null` olarak ayarlayın; böylece noktanın kategori konumu korunur ve boş bir nokta olarak kalır. [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/clear/) yöntemini yalnızca o serideki tüm noktaları kaldırmak istediğinizde kullanın. Kategorileri de kaldırıyorsanız, her serinin değerlerinin kategori koleksiyonuyla hizalı kalması için tüm serileri güncelleyin.

**Boş noktalar nasıl gösterilir?**

Sonuç, grafik türüne ve [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/) üzerinden yapılandırılan değere bağlıdır. Desteklenen grafikler boşlukları, sıfır değerleri veya komşu noktaları bağlayarak gösterebilir. Sunumunuzdaki eksik verinin anlamına en uygun ayarı seçin. Tam örnek ve görsel karşılaştırma için [Boş Hücrelerin Görüntülenmesini Kontrol Etme](#control-the-display-of-empty-cells) bölümüne bakın.

**Negatif değerlerin biçimi nasıl olur?**

Desteklenen çubuk, sütun ve balon serileri için, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setinvertifnegative/) yöntemini çağırın ve [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getinvertedsolidfillcolor/) tarafından döndürülen rengi ayarlayın. Bireysel bir nokta için davranışı [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/setinvertifnegative/) ile geçersiz kılabilirsiniz. Bu yöntemler biçimlendirmeyi etkiler, saklanan sayısal değerleri değiştirmez.

**Seri ve nokta her ikisi de biçimlendirildiğinde hangisi kazanır?**

Açık veri‑nokta biçimlendirmesi o nokta için önceliklidir. Diğer noktalar, açık bir seri biçimi varsa onu, yoksa otomatik grafik stili ve temasını kullanır. Örtüşme ve boşluk genişliği gibi grup ayarları düzeni kontrol eder ve nokta‑seviyesinde bir biçimlendirme geçersizliği oluşturmaz.

**Bir grafik kaç seriyi barındırabilir?**

Aspose.Slides ayrı bir sabit seri sayısı sınırı uygulamaz. Pratikte, sunum dosyası sınırlamaları, mevcut bellek, işleme süresi ve grafiğin okunabilirliği kullanılabilir bir sınırı belirler.

**Sütunlar çok yakına mı çok uzağa mı mı? Ne yapmalıyım?**

Uygun üst seri grubunda [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) yöntemini çağırın. Değeri artırarak kümeler arasındaki boşluğu genişletin, azaltarak kümeleri birbirine yaklaştırın.