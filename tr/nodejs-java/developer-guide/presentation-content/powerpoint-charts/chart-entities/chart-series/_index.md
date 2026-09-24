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
description: "JavaScript ile sunumlarda grafik serileri, veri noktaları, çalışma kitabı hücreleri, biçimlendirme, örtüşme, boşluk genişliği ve negatif değerleri nasıl yöneteceğinizi öğrenin."
---
## **Genel Bakış**

Bir grafik, çizilen verilerini bir grafik veri çalışma kitabında saklar. Bir [ChartSeries](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseries/) bir dizi ilgili değeri temsil eder ve serideki her [ChartDataPoint](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatapoint/) bir veya daha fazla çalışma kitabı hücresine başvurur. [ChartCategory](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartcategory/) nesneleri seriler arasında paylaşılan etiketleri veya gruplama değerlerini sağlar. Bu nedenle serinin adı, kategoriler ve nokta değerleri yalnızca görüntü metni olarak saklanmak yerine [ChartDataCell](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatacell/) nesnelerine bağlanır.

Tipik bir kategori grafiği için, varsayılan çalışma kitabı seri adları için satır 0, kategori adları için sütun 0 ve kalan hücreler seri değerleri için kullanılır. [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdataworkbook/#getCell) yöntemine geçirilen çalışma sayfası, satır ve sütun indeksleri sıfır tabanlıdır. Bu düzen, varsayılan veriyle bir grafik oluşturduğunuzda kullanışlıdır, ancak mevcut her grafiğin bunu kullandığını varsaymayın. Yüklenmiş bir sunumda, çalışma kitabı değerlerini değiştirmeden önce seriler, kategoriler ve veri noktaları tarafından başvurulan hücreleri inceleyin.

Grafik ayarlarının üç farklı kapsamı vardır:

- Seri düzeyindeki ayarlar, örneğin [ChartSeries.getFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseries/#getFormat), bir serideki tüm noktalar için varsayılan görünümü sağlar.
- Veri noktası ayarları, örneğin [ChartDataPoint.getFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatapoint/#getFormat), bir nokta için seri görünümünü geçersiz kılar.
- Grup ayarları, aynı [ChartSeriesGroup](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseriesgroup/) içinde yer alan uyumlu serilere uygulanır. Örtüşme veya boşluk genişliği gibi seçenekleri ayarlamanız gerektiğinde grubu [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseries/#getParentSeriesGroup) aracılığıyla erişin.

Açık bir nokta veya seri dolgu ayarı yapılmadığında, grafik stili ve teması otomatik görünümü belirler. Hem seri hem de nokta biçimlendirmesi mevcut olduğunda, nokta biçimlendirmesi o nokta için öncelikli olur.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Grafik Serisi Örtüşmesini Ayarla**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseries/#getOverlap) 2B bir grafikte çubukların veya sütunların -%100 ile %100 arasında ne kadar örtüştüğünü raporlar. Bu, üst seri grubundaki ayarın yalnızca okunabilir bir yansımasıdır. Grup içindeki tüm uyumlu serileri güncellemek için [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseriesgroup/#setOverlap) kullanın. Bu seçenek, gruplanmış çubuk veya sütunları gösteren grafik tiplerine uygulanır; kombinasyon grafiğinde ilişkili olmayan seri gruplarını etkilemez.

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

## **Seri Dolgu Rengini Değiştir**

[ChartSeries.getFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseries/#getFormat) kullanarak bir serinin tamamı için varsayılan dolgu ayarlanabilir. Bir nokta zaten açık bir dolgu içeriyorsa, onun [ChartDataPoint.getFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatapoint/#getFormat) ayarı o nokta için seri dolgusunu geçersiz kılar.

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

![Serinin rengi](series_color.png)

## **Seri Adını Değiştir**

Bir seri adı, grafik veri çalışma kitabında saklanır ve genellikle lejende görüntülenir. Küme sütun grafiği için oluşturulan varsayılan çalışma kitabında, B1 hücresi satır 0, sütun 1 konumunda olup ilk serinin adını içerir. Aşağıdaki örnekteki adlandırılmış sabitler bu yapıyı açıkça gösterir:

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

Ayrıca, zaten [ChartSeries.getName](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseries/#getName) tarafından başvurulan hücreyi güncelleyebilirsiniz. Bu yaklaşım, mevcut bir grafikte belirli bir satır ve sütun varsayımından kaçınır:

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

## **Otomatik Seri Dolgu Rengini Al**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseries/#getAutomaticSeriesColor) serinin indeksine ve grafik stiline göre hesaplanan rengi döndürür. Bu, seri dolgusunun açıkça tanımlanmadığı durumlarda kullanılan renktir. Yöntemi çağırmak hesaplanan rengi okur; yeni bir dolgu atamaz.

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

Tam renkler grafik stili ve temasına bağlıdır.

## **Grafik Serisi İçin Ters Dolgu Rengini Ayarla**

Çubuk, sütun ve balon serileri için [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) negatif değerleri farklı bir dolgu ile gösterebilir. Normal seri dolgusunu katı olarak ayarlayın, terslemeyi etkinleştirin ve negatif değer rengini [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor) aracılığıyla atayın. Negatif sayılar çalışma kitabında değişmeden kalır; yalnızca görüntülenme rengi değişir.

Aşağıdaki örnek, varsayılan grafik verisini tek bir seri ile değiştirir. Çalışma sayfası satır 0 seri adını, sütun 0 kategori adlarını ve sütun 1 değerleri içerir:

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

Bir nokta için terslemeyi [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative) ile etkinleştirebilirsiniz. Aşağıdaki örnekte, seri için tersleme devre dışı bırakılmış ve yalnızca seçilen nokta için etkinleştirilmiştir. Etkiyi görmek için noktaya negatif bir değer atanmıştır:

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

## **Belirli Bir Veri Noktasının Değerini Temizle**

Diğer noktaları kaldırmadan bir noktayı boş bırakmak için ilgili çalışma kitabı hücresini `null` olarak ayarlayın. Sütun grafiği için çizilen değer [ChartDataPoint.getValue](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatapoint/#getValue) aracılığıyla alınabilir. Veri noktası aynı kategori konumunda kalır, ancak grafik değerini grafik boş‑değer ayarına göre boş kabul eder.

Aşağıdaki örnek, ilk seride yalnızca ikinci noktayı temizler:

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

Dağılım grafiklerinde X ve Y hücreleri ayrı, balon grafiklerinde ise bir boyut hücresi ek olarak bulunur. Kaldırmak istediğiniz değeri temsil eden hücreyi yalnızca o hücreyi temizleyin. Diğer noktaları korumak istediğinizde [ChartDataPointCollection.clear](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatapointcollection/#clear) metodunu çağırmayın; bu metod serinin tüm veri noktalarını kaldırır.

## **Boş Hücrelerin Görüntülenmesini Kontrol Et**

Boş bir çalışma kitabı hücresi eksik veriyi temsil eder; `0` içeren bir hücre bilinen sayısal bir değeri temsil eder. Bir hücreyi boş yapmak için [ChartDataCell.setValue](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatacell/#setValue) metodunu `null` ile çağırın. Sayısal sıfır, boş‑hücre ayarına bakılmaksızın sıfır olarak kalır.

Grafiğin boş hücreleri nasıl göstereceğini seçmek için [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) kullanın. Bu ayar tüm grafik için geçerlidir. Boşlukları çizim olarak değiştirir, boş hücreyi sıfır veya ara değerle doldurmaz.

Aşağıdaki bağımsız örnek, bir seri içeren bir çizgi grafik oluşturur, 3. günün değerini temizler ve aynı grafiği her modda kaydeder. Girdi dosyası gerekmez. [ChartDataWorkbook](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdataworkbook/) çalışma sayfası 0, sütun 0 kategori etiketleri, sütun 1 değerler için kullanır; satır 0 seri adını tutar. Son veri `10, 20, empty, 30, 40` şeklindedir.

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

    // Gün 3'ü gerçekten boş bırak, ancak kategorisini ve veri noktasını koru.
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

Her çıktı dosyası kaydetmeden önce atanan modu saklar: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` ve `empty_cells_Span.pptx`. Tek bir versiyonu kaydetmek için istediğiniz modu atayın ve sunumu bir kez kaydedin, modlar arasında döngü yapmayın.

Aşağıdaki karşılaştırma aynı veriyi üç dosyada gösterir. 3. gün çalışma kitabında her durumda boştur:

![Aynı veriye sahip çizgi grafikler: Boşluk, 3. günde çizgiyi keser; Sıfır, çizgiyi sıfıra düşürür; Aralık, 2. günü 4. günle bağlar.](display_blanks_as.png)

Görünür etki grafik tipine bağlıdır. Çizgi grafiği, üç modu da kolayca karşılaştırmanıza olanak tanır. Çubuk ve sütun grafiklerinde eksik bir kategori için bağlayacak bir çizgi olmadığından `Span` yukarıda gösterilen bağlantı segmentini oluşturamaz; eksik bir sütun ile sıfır‑yükseklikteki bir sütun da benzer görünebilir. Benzer şekilde sadece işaretçili bir dağılım grafiğinde de bağlayıcı bir çizgi yoktur. Her grafik tipinde üç ayrı sonuç beklemeyin; kullandığınız tip için çıktıyı kontrol edin.

## **Seri Boşluk Genişliğini Ayarla**

Boşluk genişliği, yan yana çubuk veya sütun kümeleri arasındaki boşluk olup çubuğun veya sütunun genişliğinin yüzdesi olarak ifade edilir. Örtüşme gibi, bu da tek bir seriye değil, üst seri grubuna aittir. Grup için bir kez [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) metodunu çağırın. Daha büyük bir değer kümeler arasındaki boşluğu artırır; daha küçük bir değer onları daha yoğun yapar.

Aşağıdaki örnek boşluk genişliğini değiştirir ve yalnızca nihai sunumu kaydeder:

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

**Hangi grafik tipleri veri serilerini destekler?**

[ChartType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/charttype/)枚举 tarafından temsil edilen tüm grafik tipleri veri kullanır, ancak serilerinin değer yapısı veya ayarları aynı değildir. Örneğin, kategori grafikleri kategori ve değer kullanır, dağılım grafikleri X ve Y değerlerini, balon grafikleri ise balon boyutlarını ekler. Seri tipine uygun veri‑nokta oluşturma metodunu kullanın. Örtüşme ve boşluk genişliği gibi seçenekler yalnızca uyumlu çubuk veya sütun gruplarına uygulanır.

**Grafik seri grubu nedir?**

[ChartSeriesGroup](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseriesgroup/) aynı grup‑seviyesi çizim ayarlarını paylaşan uyumlu serileri içerir. Bir kombinasyon grafiği birden fazla grup içerebilir; bir seriden ulaşarak grup ayarını değiştirmek, grafikteki tüm serileri mutlaka etkilemez.

**Yeni oluşturulan bir grafik varsayılan veri içerir mi?**

Evet. Varsayılan olarak, [ShapeCollection.addChart](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapecollection/#addChart) örnek seriler, kategoriler ve değerler oluşturur. Bu hücreleri düzenleyebilir veya tamamen özel bir veri kümesi eklemeden önce serileri ve kategori koleksiyonlarını temizleyebilirsiniz. Bir aşırı yükleme, varsayılan veri olmadan bir grafik de oluşturabilir.

**Grafik nesneleri çalışma kitabı hücrelerine nasıl bağlanır?**

Seri adları, kategori etiketleri ve veri‑nokta değerleri bir [ChartDataWorkbook](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdataworkbook/) içindeki hücrelere başvurur. Başvurulan bir hücre değiştirildiğinde ilgili grafik öğesi güncellenir. Özel veri oluştururken, her noktanın istenen kategori altında çizildiğinden emin olmak için kategori satırlarını ve seri‑değer satırlarını hizalı tutun.

**Bir serinin tamamı yerine tek bir noktayı nasıl temizlerim?**

İlgili değer hücresini `null` yaparak noktayı kategori pozisyonunda boş bir nokta olarak tutun. [ChartDataPointCollection.clear](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatapointcollection/#clear) metodunu yalnızca seriden tüm noktaları kaldırmak istediğinizde kullanın. Kategorileri de kaldırıyorsanız, her serinin değerlerini kategori koleksiyonuyla hizalanmış tutmak için güncelleyin.

**Boş noktalar nasıl görüntülenir?**

Sonuç, grafik tipine ve [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) aracılığıyla yapılandırılan değere bağlıdır. Desteklenen grafikler boşlukları boşluk olarak, sıfır değerler olarak ya da komşu noktaları bağlayarak gösterebilir. Eksik verinin anlamına uygun ayarı seçin. Tam örnek ve görsel karşılaştırma için **[Boş Hücrelerin Görüntülenmesini Kontrol Et](#control-the-display-of-empty-cells)** bölümüne bakın.

**Negatif değerler nasıl biçimlendirilir?**

Desteklenen çubuk, sütun ve balon serileri için [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) metodunu çağırın ve [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor) ile dönen rengi ayarlayın. Bireysel bir nokta için biçimlendirmeyi [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative) ile geçersiz kılabilirsiniz. Bu yöntemler biçimlendirmeyi etkiler, saklanan sayısal değerleri değiştirmez.

**Hem seri hem de nokta biçimlendirilmiş olduğunda hangisi kazanır?**

Açık veri‑nokta biçimlendirmesi o nokta için önceliklidir. Diğer noktalar açık seri biçimini ya da seri biçimi tanımlı değilse otomatik grafik stilini ve temasını kullanmaya devam eder. Grup ayarları (örneğin örtüşme ve boşluk genişliği) düzeni kontrol eder ve nokta‑seviyesi biçimlendirme geçersiz kılmaları değildir.

**Bir grafiğin içerebileceği seri sayısına bir sınırlama var mı?**

Aspose.Slides ayrı bir sabit seri sayısı limiti uygulamaz. Pratikte, sunum dosyası kısıtlamaları, kullanılabilir bellek, render süresi ve grafik okunabilirliği faydalı bir sınırı belirler.

**Sütunlar çok yaklaştığında veya çok uzaklaştığında neyi değiştirmeliyim?**

Uygun üst seri grubunda [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) metodunu çağırın. Değeri artırarak kümeler arasındaki boşluğu genişletin, azaltarak kümeleri birbirine daha yakın hâle getirin.