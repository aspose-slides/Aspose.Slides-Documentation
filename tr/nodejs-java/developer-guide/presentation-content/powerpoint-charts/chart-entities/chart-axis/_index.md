---
title: JavaScript Kullanarak Sunumlarda Grafik Eksenlerini Özelleştirin
linktitle: Grafik Eksenleri
type: docs
url: /tr/nodejs-java/chart-axis/
keywords:
- grafik ekseni
- dikey eksen
- yatay eksen
- ekseni özelleştir
- ekseni manipüle et
- ekseni yönet
- eksen özellikleri
- azami değer
- asgari değer
- eksen çizgisi
- tarih formatı
- eksen başlığı
- eksen konumu
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Java üzerinden Node.js için Aspose.Slides ile JavaScript kullanarak PowerPoint sunumlarında raporlar ve görselleştirmeler için grafik eksenlerini nasıl özelleştireceğinizi keşfedin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Node.js via Java ile grafik eksenlerini nasıl özelleştireceğinizi açıklar. Hesaplanan eksen değerleri, grafik satır ve sütunlarının değiştirilmesi, eksen görünürlüğü, kategori etiketi ve işaret çubuğu aralıkları, tarih kategorileri ve biçimlendirme, başlık dönüşü, eksen konumlandırma, görüntü birimleri ve logaritmik ölçeklendirme konularını kapsar.

## **Grafiklerde Dikey Eksende Azami Değerleri Al**

Bir [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) oluşturun ve varsayılan verilerle bir alan grafiği ekleyin. Hesaplanan eksen değerlerini okumadan önce grafik düzeninin güncel olmasını sağlamak için [validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) çağırın.

[ getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmaxvalue/) ve [getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminvalue/) metodlarını eksen sınırları için, [getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunit/) ve [getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunit/) metodlarını işaret aralıkları için okuyun. [getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunitscale/) ve [getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunitscale/) zaman birimi ölçeklerini sağlar; bu ölçekler tarih eksenleri için geçerlidir. Örnek bu değerleri yerel değişkenlerde saklar ve grafiği kaydeder.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();

    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

    var majorUnit = chart.getAxes().getVerticalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getVerticalAxis().getActualMinorUnit();

    var majorUnitScale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale();
    var minorUnitScale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale();

    presentation.save("AxisValues_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Eksenler Arasındaki Verileri Değiştir**

Grafik verilerinde seriler ve kategorilerin rollerini değiştirmek için [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) kullanın. Önceden kategori olan her öğe bir seri, önceden seri olan her öğe bir kategori olur. Bu, verilerin nasıl gruplanacağını değiştirir; yatay ve dikey eksenleri değiştirmez. Örnek, satır ve sütunları değiştirmeden önce varsayılan verileri `Sheet1!A1:D5` adresine bağlamak için [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) kullanır. Dört seri ve üç kategori içeren bir grafik kaydeder.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    chart.getChartData().setRange("Sheet1!A1:D5");
    chart.getChartData().switchRowColumn();

    presentation.save("SwitchChartRowColumns_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Bir Eksenin Çizim Sırasını Tersine Çevir**

Bir kategori veya değer eksenini tersine çevirmek için [setPlotOrderReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setplotorderreversed/) kullanın. Örneğin, bir yatay çubuk grafiği, proje aşamalarını çalışma sayfasıyla aynı sırada üstten alta gösterebilir: Planning, Development, Testing. Bir ekseni tersine çevirmek çizim yönünü değiştirir; çalışma kitabı verilerini sıralamaz veya yeniden düzenlemez. Karşılaştırma olarak, [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) serilerin ve kategorilerin rollerini değiştirir.

Aşağıdaki örnek, üç aşama ve bir seri içeren bir yatay çubuk grafiği oluşturur. Normal sıra, ters kategoriler ve ters değerler olmak üzere üç slayt içeren bir sunum kaydeder. Her kopya aynı veri kümesini kullanır ve her kopyada yalnızca bir eksen tersine çevrilir.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredBar, 50, 40, 620, 320);
    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.ClusteredBar);
    var stages = ["Planning", "Development", "Testing"];
    var values = [10, 30, 20];
    for (var i = 0; i < stages.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, stages[i]);
        chart.getChartData().getCategories().add(categoryCell);
        var valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    // Slayt 2: ilk kategoriyi üstte göster.
    var categorySlide = presentation.getSlides().addClone(slide);
    var categoryChart = categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // Yatay değer eksenini altta tut.
    categoryChart.getAxes().getVerticalAxis().setCrossType(aspose.slides.CrossesType.Maximum);

    // Slayt 3: sadece yatay sayısal ölçeği tersine çevir.
    var valueSlide = presentation.getSlides().addClone(slide);
    var valueChart = valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bir ekseni tersine çevirmek, dik ekseni grafiğin karşı tarafına taşıyabilir. [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) yapılandırılan eksenin diğer eksenle nerede kesişeceğini kontrol eder. 2. slaytta, ters kategori ekseninde `aspose.slides.CrossesType.Maximum` ile çağırmak yatay değer eksenini altta tutar. Belirli bir kesişim noktası için [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/) kullanın. Yön değiştirirken kesişim ayarlarını kontrol edin, özellikle grafik zaten özel bir kesişim noktasına sahipse. Normal çizim yönünü geri yüklemek için `setPlotOrderReversed` değerini `false` olarak ayarlayın; kesişim ayarları ayrı bir durumdur.

| Normal sıra (slayt 1) | Ters kategoriler (slayt 2) | Ters değerler (slayt 3) |
| --- | --- | --- |
| ![Normal kategori ve değer eksen sırası ile yatay çubuk grafiği](axis-order-normal.png) | ![Kategorilerin üstten alta gösterildiği yatay çubuk grafiği](axis-order-categories-reversed.png) | ![Ters değer ekseni ve sağda sıfır ile yatay çubuk grafiği](axis-order-values-reversed.png) |
| Kategoriler alttan üste doğru ilerler; değerler soldan sağa artar. | Planlama, Geliştirme ve Test üstten alta doğru ilerler. Değerler ve çalışma kitabı satır sırası değişmez. | Kategoriler normal sıralarını korur; değerler sağdan sola artar. Kategori ekseni sağda sıfırda kesişir. |

## **Çizgi Grafiklerinde Dikey Ekseni Devre Dışı Bırak**

[setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) metodunu dik eksende `false` ile çağırarak gizleyin. Örnek, varsayılan verilerle bir çizgi grafiği oluşturur ve dik ekseni gizlenmiş olarak kaydeder.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);

    presentation.save("HiddenVerticalAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Çizgi Grafiklerinde Yatay Ekseni Devre Dışı Bırak**

[setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) metodunu yatay eksende `false` ile çağırarak gizleyin. Örnek, varsayılan verilerle bir çizgi grafiği oluşturur ve yatay ekseni gizlenmiş olarak kaydeder.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);

    presentation.save("HiddenHorizontalAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Bir Kategori Eksenini Değiştir**

[setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) kullanarak tarih veya metin kategori ekseni seçin. Bu örnek, ilk slayttaki ilk şekil olarak bir grafik ve kategori hücrelerinde sayısal Excel tarih değerleri bulunan `ExistingChart.pptx` dosyasını gerektirir. Yatay ekseni tarih ekseni olarak değiştirir. [setAutomaticMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmajorunit/) metodunu `false`, [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) metodunu `1` ve [setMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunitscale/) metodunu `TimeUnitType.Months` ile çağırmak, ana işaretçileri bir aylık aralıklarla yerleştirir.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(aspose.slides.TimeUnitType.Months);

    presentation.save("ChangeChartCategoryAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kategori Eksen Etiketi Aralıklarını Kontrol Et**

Bir grafikte çok sayıda kategori olduğunda, kategorileri veya veri noktalarını kaldırmadan görünen eksen etiketlerinin sayısını azaltın. [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticticklabelspacing/) metodunu `false` ile çağırın, ardından istenen kategori aralığını [setTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelspacing/) metoduna geçirin. Normal sıradaki metin kategorileri için sayma ilk kategoriyle başlar:

| Aralık | Örnekte Görülen Etiketler |
| --- | --- |
| `1` | Kategori 1, Kategori 2, Kategori 3, ... Kategori 24 |
| `2` | Kategori 1, Kategori 3, Kategori 5, ... Kategori 23 |
| `3` | Kategori 1, Kategori 4, Kategori 7, ... Kategori 22 |

`3` aralığı her üçüncü etiketi gösterir, gösterilen etiketler arasında iki etiket gizlenir. İlgili sütunlar kaldırılmaz. Otomatik aralık, mevcut alana göre bir aralık seçer; her etiketi mutlaka göstermez.

İşaret çubuğu (tick mark) ayarları ayrı kontrol edilirdir. [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomatictickmarksspacing/) metodunu `false` ile çağırın ve [setTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settickmarksspacing/) metoduyla aralığını ayarlayın. Örneğin, `1` her kategori aralığında bir işaret çubuğu tutar, etiketler ise yalnızca her üçüncü kategoride görünür. Görünür bir stil ile [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) kullanarak sonucu görebilirsiniz. Otomatik ayarlayıcı metodlardan birini `true` ile tekrar çağırmak, grafiğin o aralığı yeniden seçmesine izin verir.

Aşağıdaki örnek, 24 kategori ve bir seri oluşturur, ardından `CategoryAxisIntervals.pptx` içinde üç slayt kaydeder: otomatik aralık, bağımsız işaret çubuğu ile manuel etiket aralığı ve geri yüklenmiş otomatik aralık. İki kopya orijinal grafik verilerini korur. Giriş sunumu gerekmez. Yatay etiket metni yoğunluk farkını kolayca görmeyi sağlar.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.setLegend(false);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.ClusteredColumn);
    for (var i = 0; i < 24; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        var valueCell = workbook.getCell(0, i + 1, 1, 10 + i % 6 * 5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    var axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisType(aspose.slides.CategoryAxisType.Text);
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0);
    axis.getTextFormat().getPortionFormat().setFontHeight(12);
    axis.setMajorTickMark(aspose.slides.TickMarkType.Outside);
    axis.setAutomaticTickLabelSpacing(true);
    axis.setAutomaticTickMarksSpacing(true);

    // Slayt 2: her üçüncü etiketi göster, ancak her kategori için bir işaret çubuğu tut.
    var manualSlide = presentation.getSlides().addClone(slide);
    var manualChart = manualSlide.getShapes().get_Item(0);
    var manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // Slayt 3: grafiğin her iki aralığı da tekrar seçmesine izin ver.
    var restoredSlide = presentation.getSlides().addClone(manualSlide);
    var restoredChart = restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Otomatik aralık (slayt 1):** Bu renderda her ikinci kategori etiketi gösterilir ve iki satıra kaydırılır. Otomatik sonuç grafik boyutu, yazı tipleri ve renderlayıcıya bağlı olarak değişebilir.

![Tüm 24 sütun görünürken otomatik kategori etiketi aralığı](category-axis-automatic.png)

**Manuel aralık (slayt 2):** Her üçüncü etiket tek satırda gösterilir, işaretçikler ise her kategori aralığında kalır. Etiketsiz olanlar da dahil olmak üzere tüm 24 sütun aynı değerlerle görünür. Slayt 3, yukarıdaki otomatik görünümü geri yükler.

![Tüm 24 sütun görünürken üçlü manuel kategori etiketi aralığı](category-axis-manual.png)

### **Doğru Ekseni ve Aralığı Seç**

Bu kategori-sayısı aralığını metin kategori ekseni olan kolon, çizgi, alan veya çubuk grafiklerde kullanın. Kolon grafiğinde yatay eksendir. Yatay çubuk grafiğinde kategori ekseni dik olduğundan, bu ayarları [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/) tarafından döndürülen eksene uygulayın. İşaret çubuğu aralığı, bir seriye sahip grafiklerde seriler eksenine de uygulanır.

Kategori etiketi aralığını, değer ekseninin sayısal ölçeğini ayarlamak için kullanmayın. Değer ekseninde [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) bir değer farkı belirler: örneğin, `10` ana birim eksen sıfırdan başlıyorsa 0, 10, 20 vb. noktalara işaret çubuğu koyar. `3` kategori etiketi aralığı ise veri değerlerinden bağımsız olarak kategori konumlarını sayar. Dağılım ve balon grafikler metin kategori ekseni yerine değer eksenleri kullanır. Tarih ekseni için, [Change a Category Axis](#change-a-category-axis) bölümünde açıklandığı gibi zaman tabanlı ana birimler ve ölçekler kullanın.

## **Kategori Eksen Değerleri İçin Tarih Formatını Ayarla**

Örnek, varsayılan grafik verilerini dört yıllık değerle değiştirir. Tarihler, ilk çalışma sayfasında (indeks `0`) OLE Automation seri numaraları olarak saklanır; bu numaralar 30 Aralık 1899'dan itibaren gün sayısıdır. JavaScript hesaplaması UTC zaman damgalarını kullanır ve farkı günde 86 400 000 milisaniye ile böler. [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) metodunu `CategoryAxisType.Date` ile kullanın, [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) metodunu `false` ile çağırın ve `yyyy` değerini [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) metoduna aktarın; böylece kategori etiketleri hücre biçimlendirmesinden bağımsız olarak dört basamaklı yıl gösterir.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var baseDate = Date.UTC(1899, 11, 30);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    for (var i = 0; i < 4; i++) {
        var date = Date.UTC(2015 + i, 0, 1);
        var categoryCell = workbook.getCell(0, i + 1, 0, (date - baseDate) / 86400000);
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, i + 1);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");

    presentation.save("DateAxisFormat.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Bir Grafik Eksen Başlığı İçin Döndürme Açısını Ayarla**

Dikey eksende [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settitle/) metodunu `true` ile çağırın, başlık metnini sağlayın ve başlığı döndürmek için [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setrotationangle/) metodunu kullanın. Açı derece cinsinden ölçülür; örnek, değer ekseni başlığı 90 derece döndürülmüş bir kolon grafiği kaydeder.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value");
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    presentation.save("RotatedAxisTitle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kategori veya Değer Ekseninde Ekseni Konumlandır**

[getAxisBetweenCategories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaxisbetweencategories/) metodunu kullanarak değer ekseninin kategori eksenini kategori aralıkları arasında mı yoksa kategori işaretçileri üzerinde mi kesiştireceğini kontrol edin. Bu ayar sadece kategori eksenlerine uygulanır. Örnek, bir kolon grafiğinin yatay kategori ekseninde bu ayarı `true` yapar ve sonucu kaydeder.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    presentation.save("AxisBetweenCategories.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Grafik Değer Ekseninde Görüntü Birimini Ayarla**

[setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setdisplayunit/) metodunu kullanarak değer eksenindeki etiketleri, temel veriyi değiştirmeden ölçeklendirin. [DisplayUnitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/displayunittype/) `Millions` olarak ayarlandığında 60 000 000 değeri 60 olarak gösterilir. Örnek, bir kolon grafiği oluşturur ve dik eksenine milyon birimini uygular.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Millions);

    presentation.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Logaritmik Değer Eksenini Yapılandır**

Logaritmik değer ekseni, pozitif değerlerin birkaç mertebe genişlediği durumlarda faydalıdır. Örneğin, bir hizmet beş dönemde 10, 100, 1 000, 10 000 ve 100 000 istek alabilir. Doğrusal ölçekte küçük değerler sıfıra yakın bir arada görünür. Logaritmik ölçek, bu büyümeleri karşılaştırmayı kolaylaştırır: eşit mesafeler eşit oranları temsil eder, eşit farkları değil.

Değer ekseninde [setLogarithmic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogarithmic/) metodunu `true` ile çağırın ve tabanı seçmek için [setLogBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogbase/) metodunu kullanın. Bu, mevcut değerlerin gösterimini değiştirir; veriyi değiştirmez veya logaritmik bir trend çizgisi eklemez. Trend çizgisi, verideki ilişkiyi modele oturtan ayrı bir özelliktir.

### **Değer Eksenini ve Tabanı Seç**

Çizgi veya kolon grafiği için değer ekseni [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/) tarafından döndürülür. Yatay çubuk grafiği için [getHorizontalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/gethorizontalaxis/) döndürür. Dağılım ve balon grafiklerin iki değer ekseni vardır; X değerleri için yatay ekseni, Y değerleri için dik ekseni veya her ikisini seçin. Kategori eksenine logaritmik ölçek uygulamayın.

Varsayılan logaritmik taban `10`‘dur. PPTX grafiklerinde taban `2`‑`1000` arasında bir tam sayı olabilir; kesirli tabanlar (`2.5` gibi) da desteklenir. Tabana `10` ile ardışık güçler 10, 100, 1 000, 10 000 eşit aralıklarla yer alır.

### **Doğrusal ve Logaritmik Ölçeklendirmeyi Karşılaştır**

Aşağıdaki örnek, ilk slaytta beş istek sayısını gösteren bir çizgi grafiği oluşturur, ardından bu slaytı kopyalar ve ikinci slaytta taban‑10 logaritmik değer eksenini etkinleştirir. İki slayt da aynı veriyi korur.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 30, 40, 660, 200);

    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    var values = [10, 100, 1000, 10000, 100000];

    for (var i = 0; i < values.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, "Period " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // İlk slaytı doğrusal tut ve yalnızca kopyanın değer ekseni ölçeğini değiştir.
    var logarithmicSlide = presentation.getSlides().addClone(slide);
    var logarithmicChart = logarithmicSlide.getShapes().get_Item(0);
    var valueAxis = logarithmicChart.getAxes().getVerticalAxis();
    valueAxis.setLogarithmic(true);
    valueAxis.setLogBase(10);

    presentation.save("LogarithmicAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Doğrusal ölçek (slayt 1):** Eşit dik mesafeler istek sayılarındaki eşit farkları temsil eder. En büyük değer grafiği domine eder, küçük değerleri ayırt etmeyi zorlaştırır.

![Doğrusal değer ekseninde beş istek sayısını gösteren PowerPoint'te çizgi grafiği](value-axis-linear.png)

**Logaritmik ölçek (slayt 2):** Eşit dik mesafeler eşit oranları temsil eder. Her dönem bir öncekinin on katı istek alır; bu nedenle noktalar taban‑10 ölçeğinde düz bir yükselen çizgi oluşturur. Ekseni etiketleri hâlâ orijinal istek sayılarını gösterir.

![PowerPoint'te aynı beş istek sayısı 10 tabanlı logaritmik değer ekseninde](value-axis-logarithmic.png)

### **Sıfır ve Negatif Değerleri Yönet**

Logaritmik ölçek yalnızca mutlak pozitif değerleri gösterebilir. Etkinleştirmeden önce verileri kontrol edin. Sıfır veya negatif değerler anlamlıysa, doğrusal ölçek tutun veya bu değerleri ayrı bir şekilde gösterin. Bu değerleri analiz için dışlamak uygun ise, dışlamayı açıklayın. Küçük pozitif sayılarla sessizce değiştirmeyin; bu veri anlamını değiştirir. Logaritmik eksen için manuel olarak ayarlanan minimum veya maksimum da pozitif olmalıdır.

## **SSS**

**How do I set the value at which one axis crosses the other (axis crossing)?**

[setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) metodunu kullanarak kesişme davranışını seçin. Sayısal bir kesişme değeri belirtmek için [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/) metodunu kullanın. Bu ayarlar eksen kesişimini uygun bir temel çizgisine taşımanıza olanak tanır.

**How can I position tick labels relative to the axis?**

[setTickLabelPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelposition/) metodunu [TickLabelPositionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ticklabelpositiontype/) (`Low`, `High`, `NextTo`, `None`) ile çağırın. İşaret çubuğu (tick mark) konumunu kontrol etmek için [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) veya [setMinorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setminortickmark/) metodlarını kullanın; bunlar etiket konumlandırmadan ayrı ayarlardır.