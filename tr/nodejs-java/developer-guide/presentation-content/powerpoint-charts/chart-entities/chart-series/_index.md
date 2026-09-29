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

Bir grafik, çizilen verilerini bir grafik veri çalışma kitabında saklar. Bir [ChartSeries](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseries/) bir grup ilişkili değeri temsil eder ve serideki her bir [ChartDataPoint](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatapoint/) bir veya daha fazla çalışma kitabı hücresine başvurur. [ChartCategory](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartcategory/) nesneleri, seriler tarafından paylaşılan etiketleri veya gruplama değerlerini sağlar. Serinin adı, kategoriler ve nokta değerleri bu nedenle yalnızca metin olarak depolanmak yerine [ChartDataCell](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatacell/) nesnelerine bağlanır.

Tipik bir kategori grafiği için, varsayılan çalışma kitabı satır 0’ı seri adları için, sütun 0’ı kategori adları için ve kalan hücreleri seri değerleri için kullanır. [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdataworkbook/#getCell) metoduna geçirilen çalışma sayfası, satır ve sütun indeksleri sıfır‑tabanlıdır. Bu düzen, varsayılan verilerle bir grafik oluşturduğunuzda yararlıdır, ancak her mevcut grafiğin bunu kullandığını varsaymayın. Yüklenmiş bir sunumda, çalışma kitabı değerlerini değiştirmeden önce seriler, kategoriler ve veri noktaları tarafından başvurulan hücreleri inceleyin.

Grafik ayarları üç farklı kapsamda bulunur:

- Seri‑seviyesindeki ayarlar, örneğin [ChartSeries.getFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseries/#getFormat), bir serideki tüm noktalar için varsayılan görünümü sağlar.
- Veri‑nokta ayarları, örneğin [ChartDataPoint.getFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatapoint/#getFormat), bir nokta için seri görünümünü geçersiz kılar.
- Grup ayarları, aynı [ChartSeriesGroup](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseriesgroup/) içinde yer alan uyumlu serilere uygulanır. [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseries/#getParentSeriesGroup) üzerinden gruba erişerek örtüşme veya boşluk genişliği gibi seçenekleri ayarlayabilirsiniz.

Açık bir nokta veya seri dolgusu ayarlanmamışsa, grafik stili ve teması otomatik görünümü belirler. Hem seri hem de nokta biçimlendirmesi mevcutsa, nokta biçimlendirmesi o nokta için önceliklidir.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Grafik Serisi Örtüşmesini Ayarlama**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseries/#getOverlap) 2B bir grafikte çubukların veya sütunların yüzde -100 ile 100 arasında ne kadar örtüştüğünü raporlar. Bu, üst seriler grubundaki ayarın salt okunur bir yansımasıdır. Bu gruptaki tüm uyumlu serileri güncellemek için [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseriesgroup/#setOverlap) kullanın. Bu seçenek, gruplanmış çubuk veya sütun gösteren grafik türlerine uygulanır; birleşik bir grafikte ilgili olmayan seri gruplarını etkilemez.

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

Tüm bir seri için varsayılan dolguyu ayarlamak üzere [ChartSeries.getFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseries/#getFormat) kullanın. Bir nokta zaten açık bir dolguya sahipse, onun [ChartDataPoint.getFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatapoint/#getFormat) ayarı o nokta için seri dolgusunu geçersiz kılar.

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

![The color of the series](series_color.png)

## **Seri Adını Değiştirme**

Bir seri adı grafik veri çalışma kitabında saklanır ve genellikle lejanda görüntülenir. Kümeleme sütun grafiği için oluşturulan varsayılan çalışma kitabında B1 hücresi (satır 0, sütun 1) ilk serinin adını içerir. Aşağıdaki örnekteki adlandırılmış sabitler bu yapıyı açıkça gösterir:

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

Ayrıca [ChartSeries.getName](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseries/#getName) tarafından zaten başvurulan hücreyi güncelleyebilirsiniz. Bu yaklaşım, mevcut bir grafikte belirli bir satır ve sütun varsayımından kaçınır:

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

## **Otomatik Seri Dolgu Rengini Alma**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseries/#getAutomaticSeriesColor), seri indeksine ve grafik stiline göre hesaplanan rengi döndürür. Bu, seri dolgu açıkça tanımlanmamışsa kullanılan renktir. Metodu çağırmak hesaplanan rengi okur; yeni bir dolgu atamaz.

Aşağıdaki örnek, her varsayılan seri için otomatik rengi yazdırır:

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

Kesin renkler grafik stiline ve temaya bağlıdır.

## **Bir Grafik Serisi için Ters Dolgu Rengini Ayarlama**

Çubuk, sütun ve baloncuk serileri için, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) negatif değerleri farklı bir dolgu ile gösterebilir. Normal seri dolgusunu katı olarak ayarlayın, terslemeyi etkinleştirin ve negatif değer rengi için [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor) metodunu kullanın. Negatif sayılar çalışma kitabında değişmeden kalır; yalnızca gösterim rengi değişir.

Aşağıdaki örnek, varsayılan grafik verisini tek bir seriyle değiştirir. Çalışma sayfası satır 0 serinin adını, sütun 0 kategori adlarını ve sütun 1 değerleri içerir:

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

Bir nokta için terslemeyi [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative) ile etkinleştirebilirsiniz. Aşağıdaki örnekte, tersleme seri için devre dışı bırakılır ve yalnızca seçilen nokta için etkinleştirilir. Etkinliği görmek için nokta ayrıca negatif bir değer alır:

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

Diğer noktaları kaldırmadan bir noktayı boş bırakmak için, onun bağlı çalışma kitabı hücresini `null` olarak ayarlayın. Bir sütun grafiğinde, çizilen değer [ChartDataPoint.getValue](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatapoint/#getValue) aracılığıyla elde edilir. Veri noktası aynı kategori konumunda kalır, ancak grafik boş‑değer ayarlarına göre değerini boş olarak kabul eder.

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

Dağılım grafiklerinde ayrı X ve Y hücreleri, baloncuk grafiklerinde ise bir boyut hücresi bulunur. Kaldırmak istediğiniz değeri temsil eden hücreyi yalnızca temizleyin. Diğer noktaları korumak istiyorsanız, [ChartDataPointCollection.clear](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatapointcollection/#clear) metodunu çağırmayın; bu metod koleksiyondaki tüm veri noktalarını siler.

## **Boş Hücrelerin Görüntülenmesini Kontrol Etme**

Değer içeren gizli hücreler, boş hücrelerden ayrı bir durumu temsil eder. Gizli çalışma sayfası satır ve sütunlarından veri dahil etmek veya hariç tutmak için **[Include Data from Hidden Rows and Columns](/slides/tr/nodejs-java/chart-workbook/#include-data-from-hidden-rows-and-columns)** bölümüne bakın.

Boş bir çalışma kitabı hücresi eksik veriyi temsil eder; `0` içeren bir hücre bilinen sayısal bir değeri temsil eder. Bir hücreyi boş yapmak için `null` ile [ChartDataCell.setValue](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatacell/#setValue) metodunu çağırın. Sayısal sıfır, boş‑hücre ayarına bakılmaksızın sıfır olarak kalır.

[Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) metodunu kullanarak grafiğin boş hücreleri nasıl göstereceğini seçin. Bu ayar tüm grafik için geçerlidir. Boşlukları doldurmaz, hücreyi sıfır veya ara bir değerle doldurmaz; yalnızca çizim biçimini değiştirir.

Aşağıdaki bağımsız örnek, bir serili çizgi grafiği oluşturur, 3. Gün değerini temizler ve her moda göre aynı grafiği kaydeder. Giriş dosyasına gerek yoktur. [ChartDataWorkbook](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdataworkbook/) çalışma sayfası 0, kategori etiketleri için sütun 0 ve değerler için sütun 1 kullanır; satır 0 seri adını tutar. Son veri `10, 20, empty, 30, 40` şeklindedir.

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

    // Day 3'ü gerçekten boş bırak, ancak kategorisini ve veri noktasını tut.
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

Her çıktı dosyası, kaydetmeden önce atanmış modu içerir: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` ve `empty_cells_Span.pptx`. Tek bir sürüm kaydetmek isterseniz, istediğiniz modu atayın ve sunumu yalnızca bir kez kaydedin; modlar arasında döngü yapmayın.

Aşağıdaki karşılaştırma, aynı verinin üç dosyada nasıl göründüğünü gösterir. 3. Gün her durumda çalışma kitabında boştur:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Görünür etki grafik türüne bağlıdır. Çizgi grafiği, üç modu karşılaştırmayı kolaylaştırır. Çubuk ve sütun grafiklerinde eksik bir kategori için bağlayıcı bir çizgi olmadığından, `Span` yukarıda gösterilen bağlayıcı segmenti üretemez; eksik bir sütun ve sıfır‑yükseklikteki bir sütun da benzer görünebilir. Benzer şekilde, yalnızca işaretçileri olan bir dağılım grafiğinde de bağlayıcı çizgi yoktur. Her grafik türü için üç ayrı sonuç beklemeyin; kullandığınız tür için çıktıyı kontrol edin.

## **Seri Boşluk Genişliğini Ayarlama**

Boşluk genişliği, yan yana çubuk veya sütun kümeleri arasındaki boşluktur ve çubuk veya sütun genişliğinin yüzdesi olarak ifade edilir. Örtüşme gibi, bu da tek bir seri yerine üst seri grubuna aittir. Grup için bir kez [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) çağırın. Daha büyük bir değer kümeler arasındaki boşluğu artırır; daha küçük bir değer onları daha yoğun hâle getirir.

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

![The gap width](gap_width.png)

## **SSS**

**Hangi grafik türleri veri serilerini destekler?**

[ChartType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/charttype/) enumʼu tarafından temsil edilen tüm grafik türleri veri kullanır, ancak serileri aynı değer yapısına veya ayarlara sahip olmayabilir. Örneğin, kategori grafiklerinde kategori ve değerler, dağılım grafiklerinde X ve Y değerleri, baloncuk grafiklerinde ise baloncuk boyutları bulunur. Seri tipine uygun veri‑nokta oluşturma yöntemini kullanın. Örtüşme ve boşluk genişliği gibi seçenekler yalnızca uyumlu çubuk veya sütun gruplarına uygulanır.

**Grafik serisi grubu nedir?**

[ChartSeriesGroup](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseriesgroup/) aynı grup‑seviyesi çizim ayarlarını paylaşan uyumlu serileri içerir. Bir birleşik grafik birden fazla grup içerebilir; bu yüzden bir seriden elde edilen grup ayarları, grafikteki tüm serileri zorunlu olarak etkilemez.

**Yeni oluşturulan bir grafik varsayılan veri içerir mi?**

Evet. Varsayılan olarak, [ShapeCollection.addChart](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapecollection/#addChart) örnek seriler, kategoriler ve değerler oluşturur. Bu hücreleri düzenleyebilir veya tamamen özel bir veri kümesi eklemeden önce serileri ve kategori koleksiyonlarını temizleyebilirsiniz. Bir aşırı yükleme, varsayılan veri olmadan da grafik oluşturabilir.

**Grafik nesneleri çalışma kitabı hücreleriyle nasıl ilişkilendirilir?**

Seri adları, kategori etiketleri ve veri‑nokta değerleri bir [ChartDataWorkbook](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdataworkbook/) içindeki hücrelere başvurur. Başvurulan bir hücreyi değiştirmek, karşılık gelen grafik öğesini günceller. Özel veri oluştururken, her noktanın istenen kategori altında çizildiğinden emin olmak için kategori satırları ve seri‑değer satırlarını hizalı tutun.

**Bir seriyi değil tek bir noktayı nasıl temizlerim?**

İlgili değer hücresini `null` yaparak noktanın kategori konumunu boş bir nokta olarak tutun. [ChartDataPointCollection.clear](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatapointcollection/#clear) metodunu yalnızca serideki tüm noktaları kaldırmak istediğinizde kullanın. Kategorileri de kaldırıyorsanız, tüm serileri güncelleyerek değerlerin kategori koleksiyonuyla hizalanmasını sağlayın.

**Boş noktalar nasıl gösterilir?**

Sonuç, grafik türüne ve [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) ile yapılandırılan değere bağlıdır. Desteklenen grafikler boşlukları, sıfır değerlerini veya komşu noktaları bağlayarak gösterebilir. Sunumunuzdaki eksik verinin anlamına uygun ayarı seçin. Tam örnek ve görsel karşılaştırma için **[Control the Display of Empty Cells](#control-the-display-of-empty-cells)** bölümüne bakın.

**Negatif değerler nasıl biçimlendirilir?**

Desteklenen çubuk, sütun ve baloncuk serileri için, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) metodunu çağırın ve [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor) ile dönen rengi ayarlayın. Bireysel bir nokta için davranışı [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative) ile geçersiz kılabilirsiniz. Bu yöntemler biçimlendirmeyi etkiler; depolanan sayısal değerler değişmez.

**Seri ve nokta aynı anda biçimlendirilirse hangi biçimlendirme geçerli olur?**

Açık veri‑nokta biçimlendirmesi o nokta için önceliklidir. Diğer noktalar, seri için açık bir format tanımlıysa onu, tanımlı değilse otomatik grafik stili ve temasını kullanır. Örtüşme ve boşluk genişliği gibi grup ayarları yerleşimi kontrol eder ve nokta‑seviyesi biçimlendirme geçersizliği yapmaz.

**Bir grafiğin içerebileceği seri sayısı için bir limit var mı?**

Aspose.Slides ayrı bir sabit seri‑sayısı sınırlaması getirmez. Pratikte, sunum dosyası kısıtlamaları, kullanılabilir bellek, işleme süresi ve grafik okunabilirliği faydalı bir sınır belirler.

**Sütunlar çok sıkı ya da çok uzak olduğunda ne yapmalıyım?**

Uygun üst seri grubunda [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) metodunu çağırın. Değeri artırarak kümeler arasındaki boşluğu genişletebilir, azaltarak kümeleri daha yaklaştırabilirsiniz.