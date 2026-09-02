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

Bir grafik, çizilen verilerini bir chart data workbook içinde saklar. Bir [ChartSeries](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseries/) bir grup ilgili değeri temsil eder ve serideki her [ChartDataPoint](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatapoint/) bir veya daha fazla çalışma kitabı hücresine başvurur. [ChartCategory](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartcategory/) nesneleri, seri tarafından paylaşılan etiketleri veya gruplama değerlerini sağlar. Serinin adı, kategoriler ve nokta değerleri bu nedenle yalnızca görüntü metni olarak depolanmak yerine [ChartDataCell](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatacell/) nesnelerine bağlanır.

Tipik bir kategori grafiği için, varsayılan workbook satır 0'ı seri adları için, sütun 0'ı kategori adları için ve kalan hücreleri seri değerleri için kullanır. [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdataworkbook/#getCell) metoduna geçirilen çalışma sayfası, satır ve sütun indeksleri sıfır‑tabanlıdır. Bu düzen, varsayılan verilerle bir grafik oluşturduğunuzda kullanışlıdır, ancak mevcut her grafiğin bunu kullandığını varsaymayın. Yüklenmiş bir sunumda, workbook değerlerini değiştirmeden önce seriler, kategoriler ve veri noktalarıyla ilişkili hücreleri inceleyin.

Grafik ayarlarının üç farklı kapsamı vardır:

- Seri‑seviyesi ayarlar, örneğin [ChartSeries.getFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseries/#getFormat), bir serideki tüm noktalar için varsayılan görünümü sağlar.
- Veri‑nokta ayarları, örneğin [ChartDataPoint.getFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatapoint/#getFormat), bir nokta için serinin görünümünü geçersiz kılar.
- Grup ayarları, aynı [ChartSeriesGroup](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseriesgroup/) içinde yer alan uyumlu serilere uygulanır. Örtüşme veya boşluk genişliği gibi seçenekleri ayarlamanız gerektiğinde, grup üzerinden [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseries/#getParentSeriesGroup) ile erişin.

Açık bir nokta ya da seri dolgusu ayarlanmamışsa, grafik stili ve teması otomatik görünümü belirler. Hem seri hem de nokta biçimlendirmesi mevcutsa, nokta biçimlendirmesi o nokta için önceliklidir.

![grafik-seri-powerpoint](chart-series-powerpoint.png)

## **Grafik Seri Örtüşmesini Ayarla**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseries/#getOverlap) 2D bir grafikte çubukların ya da sütunların ne kadar örtüştüğünü –%‑100 ila %100 arasında – raporlar. Bu, üst seri grubundaki ayarın yalnızca okunabilir bir yansımasıdır. O gruptaki tüm uyumlu serileri güncellemek için [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseriesgroup/#setOverlap) kullanın. Bu seçenek, gruplanmış çubuk ya da sütun gösteren grafik türlerine uygulanır; birleşik bir grafikte ilişkili olmayan seri gruplarını etkilemez.

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

Tüm bir seri için varsayılan dolgu ayarlamak üzere [ChartSeries.getFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseries/#getFormat) kullanın. Bir nokta zaten açık bir dolguye sahipse, onun [ChartDataPoint.getFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatapoint/#getFormat) ayarı o nokta için seri dolgusunu geçersiz kılar.

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

## **Seri Adını Değiştir**

Bir seri adı, grafik veri workbook'unda saklanır ve genellikle lejende görüntülenir. Kümeleme sütun grafiği için oluşturulan varsayılan workbook'ta, B1 hücresi satır 0, sütun 1'de bulunur ve ilk serinin adını içerir. Aşağıdaki örnekte adlandırılmış sabitler bu yapıyı açıkça gösterir:

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

Ayrıca, [ChartSeries.getName](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseries/#getName) ile zaten başvurulan hücreyi güncelleyebilirsiniz. Bu yaklaşım, mevcut bir grafikte belirli bir satır ve sütun varsayımından kaçınır:

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

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseries/#getAutomaticSeriesColor) seri indeksine ve grafik stiline göre hesaplanan rengi döndürür. Bu, seri dolgu açıkça tanımlanmadığında kullanılan renktir. Metodu çağırmak hesaplanan rengi okur; yeni bir dolgu atamaz.

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

Kesin renkler grafik stiline ve temaya bağlıdır.

## **Bir Grafik Serisi için Ters Çevirme Dolgu Rengini Ayarla**

Çubuk, sütun ve balon serileri için, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) negatif değerleri farklı bir dolgu ile gösterebilir. Düzenli seri dolgusunu katı olarak ayarlayın, ters çevirme özelliğini etkinleştirin ve negatif değer rengine [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor) üzerinden atayın. Negatif sayılar workbook'ta değişmez; yalnızca görüntü renkleri değişir.

Aşağıdaki örnek, varsayılan grafik verisini tek bir seriyle değiştirir. Çalışma sayfasının satır 0'ı seri adını, sütun 0'ı kategori adlarını, sütun 1'i değerleri içerir:

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

![Ters çevrilmiş katı dolgu rengi](inverted_solid_fill_color.png)

Bir nokta için ters çevirme, [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative) ile etkinleştirilebilir. Aşağıdaki örnekte, ters çevirme seri için devre dışı bırakılmış ve yalnızca seçilen nokta için etkinleştirilmiştir. Efektin görülmesi için nokta ayrıca negatif bir değer alır:

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

## **Belirli Bir Veri Noktası Değerini Temizle**

Diğer noktaları kaldırmadan bir noktayı boş bırakmak için, onun arka plan workbook hücresini `null` olarak ayarlayın. Bir sütun grafiğinde, çizilen değer [ChartDataPoint.getValue](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatapoint/#getValue) üzerinden elde edilebilir. Veri noktası aynı kategori konumunda kalır, ancak grafik değerini boş olarak kabul eder (grafiğin boş‑değer ayarlarına göre).

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

Dağılım grafiklerinde X ve Y hücreleri ayrı ayrı, balon grafiklerinde ise bir boyut hücresi de bulunur. Kaldırmak istediğiniz değeri temsil eden hücreyi yalnızca temizleyin. Diğer noktaları tutmak istediğinizde [ChartDataPointCollection.clear](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatapointcollection/#clear) metodunu çağırmayın; bu metod koleksiyondaki tüm veri noktalarını siler.

## **Seri Boşluk Genişliğini Ayarla**

Boşluk genişliği, bitişik çubuk ya da sütun kümeleri arasındaki boşluk olup, çubuk ya da sütun genişliğinin yüzdesi olarak ifade edilir. Örtüşme gibi, bu da bir seri grubuna aittir, tek bir seriye değil. Grup için bir kez [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) metodunu çağırın. Daha büyük bir değer kümeler arasındaki boşluğu artırır; daha küçük bir değer onları daha sıklaştırır.

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

[ChartType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/charttype/) enum'ı tarafından temsil edilen tüm grafik türleri veri kullanır, ancak serileri aynı değer yapısına ya da ayarlara sahip değildir. Örneğin, kategori grafiklerinde kategoriler ve değerler, dağılım grafiklerinde X ve Y değerleri, balon grafiklerinde ise balon boyutları bulunur. Seri tipine uygun veri‑nokta oluşturma metodunu kullanın. Örtüşme ve boşluk genişliği gibi seçenekler yalnızca uyumlu çubuk ya da sütun gruplarına uygulanır.

**Grafik seri grubu nedir?**

[ChartSeriesGroup](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseriesgroup/) aynı grup‑seviyesi çizim ayarlarını paylaşan uyumlu serileri içerir. Bir birleşik grafik birden çok grup içerebilir; bu yüzden bir seriden erişilen grup ayarını değiştirmek, grafikteki tüm serileri zorunlu olarak etkilemez.

**Yeni oluşturulan bir grafikte varsayılan veri bulunur mu?**

Evet. Varsayılan olarak [ShapeCollection.addChart](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapecollection/#addChart) örnek seriler, kategoriler ve değerler oluşturur. Bu hücreleri düzenleyebilir ya da tamamen özel bir veri kümesi eklemeden önce serileri ve kategori koleksiyonlarını temizleyebilirsiniz. Bir aşırı yükleme, varsayılan veri olmadan da bir grafik oluşturabilir.

**Grafik nesneleri workbook hücrelerine nasıl bağlanır?**

Seri adları, kategori etiketleri ve veri‑nokta değerleri bir [ChartDataWorkbook](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdataworkbook/) içindeki hücrelere başvurur. Başvurulan bir hücre değiştirilirse ilgili grafik öğesi güncellenir. Özel veri oluştururken, kategori satırları ile seri‑değer satırlarının hizalı olduğundan emin olun; böylece her nokta istenen kategori altında çizilir.

**Bir seriyi değil, sadece bir noktayı nasıl temizlerim?**

İlgili değer hücresini `null` yaparak noktanın kategori konumunu boş bir nokta olarak tutun. Bu seriden tüm noktaları kaldırmak istediğinizde yalnızca [ChartDataPointCollection.clear](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatapointcollection/#clear) metodunu kullanın. Kategorileri de kaldırıyorsanız, her serinin değerlerini kategori koleksiyonuyla hizalı tutacak şekilde güncelleyin.

**Boş noktalar nasıl görüntülenir?**

Sonuç, grafik türüne ve [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) ile yapılandırılan değere bağlıdır. Desteklenen grafikler boşlukları, sıfır değerlerini ya da komşu noktaları bağlayarak gösterebilir. Sunumunuzdaki eksik verinin anlamına uygun ayarı seçin.

**Negatif değerler nasıl biçimlendirilir?**

Desteklenen çubuk, sütun ve balon serileri için [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) çağırın ve [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor) tarafından döndürülen rengi ayarlayın. Bireysel bir nokta için davranışı [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative) ile geçersiz kılabilirsiniz. Bu yöntemler biçimlendirmeyi etkiler, saklanan sayısal değerleri değil.

**Hem seri hem de nokta biçimlendirilmişse hangi biçimlendirme kazanır?**

Açık veri‑nokta biçimlendirmesi o nokta için önceliklidir. Diğer noktalar açık seri formatını ya da seri formatı tanımlı değilse otomatik grafik stilini ve temayı kullanmaya devam eder. Örtüşme ve boşluk genişliği gibi grup ayarları düzeni kontrol eder ve nokta‑seviyesi biçimlendirme geçersiz kılmaları değildir.

**Bir grafikte kaç seri bulunabilir? Bir limit var mı?**

Aspose.Slides ayrı bir sabit seri sayısı sınırı koymaz. Gerçekte, sunum dosyası kısıtlamaları, mevcut bellek, işleme süresi ve grafiğin okunabilirliği kullanılabilir bir sınır belirler.

**Sütunlar çok yakın ya da çok uzak olduğunda ne değiştirilmelidir?**

Uygun üst seri grubunda [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) metodunu çağırın. Değeri artırarak kümeler arasındaki boşluğu genişletin, azaltarak kümeleri birbirine yaklaştırın.