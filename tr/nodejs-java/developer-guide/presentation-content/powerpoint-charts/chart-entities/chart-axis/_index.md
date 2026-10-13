---
title: JavaScript ile Sunumlarda Grafik Eksenlerini Özelleştirme
linktitle: Grafik Ekseni
type: docs
url: /tr/nodejs-java/chart-axis/
keywords:
- grafik ekseni
- dikey eksen
- yatay eksen
- eksen özelleştirme
- eksen manipülasyonu
- eksen yönetimi
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
description: "Raporlar ve görselleştirmeler için PowerPoint sunumlarında grafik eksenlerini özelleştirmek amacıyla Java aracılığıyla Node.js için Aspose.Slides ile JavaScript kullanımını keşfedin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Node.js via Java kullanarak grafik eksenlerini nasıl özelleştireceğinizi açıklar. Hesaplanan eksen değerleri, grafik satır ve sütunlarının değiştirilmesi, eksen görünürlüğü, kategori etiketi ve tik işareti aralıkları, tarih kategorileri ve biçimlendirme, başlık döndürme, eksen konumlandırma, görüntü birimleri ve logaritmik ölçeklendirme konularını kapsar.

## **Grafiklerde Dikey Eksende Azami Değerleri Al**

Bir [Sunum](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) oluşturun ve varsayılan veriyle bir alan grafik ekleyin. Hesaplanan eksen değerlerini okumadan önce grafik düzeninin güncel olduğundan emin olmak için [validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) çağırın.

Eksen sınırları için [getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmaxvalue/) ve [getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminvalue/) okuyun, tik aralıkları için [getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunit/) ve [getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunit/) kullanın. [getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunitscale/) ve [getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunitscale/) tarih eksenleriyle ilgili zaman birimi ölçeklerini sağlar. Örnek bu değerleri yerel değişkenlerde saklar ve grafiği kaydeder.

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

## **Eksenler Arasındaki Veriyi Değiştir**

Grafik verilerinde seriler ve kategorilerin rollerini değiştirmek için [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) kullanın. Her eski kategori bir seri olur, her eski seri ise bir kategori olur. Bu, verinin nasıl gruplanacağını değiştirir; yatay ve dikey eksenleri değiştirmez. Örnek, satır ve sütunları değiştirmeden önce varsayılan veriyi `Sheet1!A1:D5` adresine, başlık satırı ve kategori sütununu da dahil ederek bağlamak için [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) kullanır. Dört seri ve üç kategori içeren bir grafik kaydeder.

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

## **Çizgi Grafiklerinde Dikey Ekseni Devre Dışı Bırak**

Dikey ekseni gizlemek için `false` ile [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) çağırın. Örnek, varsayılan veriyle bir çizgi grafik oluşturur ve dikey ekseni gizli olarak kaydeder.

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

Yatay ekseni gizlemek için `false` ile [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) çağırın. Örnek, varsayılan veriyle bir çizgi grafik oluşturur ve yatay ekseni gizli olarak kaydeder.

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

[setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) kullanarak tarih veya metin kategori ekseni seçin. Bu örnek, ilk slayttaki ilk şekil olarak bir grafik içeren ve kategori hücrelerinde sayısal Excel tarih değerleri bulunan `ExistingChart.pptx` dosyasını gerektirir. Yatay ekseni tarih ekseni haline getirir. [setAutomaticMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmajorunit/) için `false`, [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) için `1` ve [setMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunitscale/) için `TimeUnitType.Months` ayarlayarak büyük tikleri bir aylık aralıklarla yerleştirir.

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

## **Kategori Ekseni Etiket Aralıklarını Kontrol Et**

Bir grafik çok sayıda kategori içerdiğinde, kategorileri veya veri noktalarını kaldırmadan görünen eksen etiketlerinin sayısını azaltın. [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticticklabelspacing/) için `false` ayarlayın, ardından istenen kategori aralığını [setTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelspacing/) ile geçirin. Normal sıradaki metin kategorileri için sayma ilk kategoriden başlar:

| Aralık | Örnekte Görüntülenen Etiketler |
| --- | --- |
| `1` | Kategori 1, Kategori 2, Kategori 3, ... Kategori 24 |
| `2` | Kategori 1, Kategori 3, Kategori 5, ... Kategori 23 |
| `3` | Kategori 1, Kategori 4, Kategori 7, ... Kategori 22 |

`3` aralığı her üçüncü etiketi görüntüler ve görüntülenen etiketler arasında iki etiket gizli kalır. İlgili sütunlar kaldırılmaz. Otomatik aralık, mevcut boşluğa göre bir aralık seçer; her etiketi mutlaka göstermez.

Tik işaretlerinin ayrı kontrolleri vardır. [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomatictickmarksspacing/) için `false` ayarlayın ve aralıklarını belirlemek için [setTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settickmarksspacing/) kullanın. Örneğin, `1` her kategori aralığında bir tik işareti bırakırken etiketler yalnızca her üçüncü kategoride görünür. Görünür bir stil ile [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) çağırarak sonucu görebilirsiniz. Otomatik‑aralık ayarını `true` yaparsanız grafik tekrar otomatik aralık seçer.

Aşağıdaki bağımsız örnek 24 kategori ve bir seri oluşturur, ardından `CategoryAxisIntervals.pptx` içinde üç slayt kaydeder: otomatik aralık, bağımsız tik işaretleriyle manuel etiket aralığı ve geri getirilen otomatik aralık. İki kopya orijinal grafik verisini korur. Giriş sunumu gerekmez. Yatay etiket metni yoğunluğun farkını görmeyi kolaylaştırır.

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

    // Slayt 2: her üçüncü etiketi göster, ancak her kategori için bir tik işareti tut.
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

**Otomatik aralık (slayt 1):** Bu gösterimde her ikinci kategori etiketi görüntülenir ve iki satıra kaydırılır. Otomatik sonuç grafik boyutu, yazı tipleri ve işleyiciye göre değişebilir.

![Otomatik kategori etiketi aralığı, 24 sütunun tümü görünür](category-axis-automatic.png)

**Manuel aralık (slayt 2):** Her üçüncü etiket tek satırda görüntülenirken tik işaretleri her kategori aralığında kalır. Etiketsiz olanlar dahil 24 sütun aynı değerlerle görünebilir. Slayt 3 otomatik görünümü geri yükler.

![Manuel kategori etiketi aralığı üç, 24 sütunun tümü görünür](category-axis-manual.png)

### **Doğru Eksen ve Aralığı Seçin**

Metin kategori ekseni için, örneğin bir sütun, çizgi, alan veya çubuk grafiğinin kategori ekseni gibi, bu kategori‑sayısı aralığını kullanın. Bir sütun grafiğinde yatay eksen budur. Yatay çubuk grafiğinde kategori ekseni dikeydir; bu yüzden ayarları [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/) tarafından döndürülen eksene uygulayın. Tik işareti aralığı, bir eksen içeren grafiklerde seriler eksenine de uygulanabilir.

Değer ekseninin sayısal ölçeğini ayarlamak için kategori etiketi aralığını kullanmayın. Değer ekseninde [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) değer farkını belirtir: örneğin `10` bir birim, eksen sıfırdan başlıyorsa 0, 10, 20 vb. oluşturur. `3` kategori etiketi aralığı yalnızca kategori konumlarını sayar, veri değerlerinden bağımsızdır. Dağılım ve balon grafikler bir metin kategori ekseni yerine değer eksenleri kullanır. Tarih ekseni için, [Change a Category Axis](#change-a-category-axis) bölümünde açıklandığı gibi zaman‑tabanlı büyük birimler ve ölçekler kullanın.

## **Kategori Ekseni Değerleri İçin Tarih Biçimini Ayarla**

Örnek, varsayılan grafik verisini dört yıllık değere değiştirir. Tarihler, ilk çalışma sayfasında (`0` dizini) OLE Automation seri numaraları olarak saklanır; bu numaralar 30 Aralık 1899 tarihinden itibaren geçen gün sayısıdır. JavaScript hesabı UTC zaman damgalarını kullanır ve farkı günde 86 400 000 ms’ye bölerek hesaplar. [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) ile `CategoryAxisType.Date`, [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) ile `false` ve `yyyy` değerini [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) metoduna geçirerek kategori etiketlerinin hücre biçiminden bağımsız dört haneli yıl olarak gösterilmesini sağlayın.

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

## **Bir Grafik Ekseni Başlığı İçin Döndürme Açısı Ayarla**

Dikey eksende `true` ile [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settitle/) çağırın, başlık metnini sağlayın ve [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setrotationangle/) ile başlığı döndürün. Açı derece cinsindendir; bu örnek, değer ekseni başlığını 90 derece döndürerek bir sütun grafik kaydeder.

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

## **Kategori veya Değer Ekseni Üzerinde Eksen Konumunu Ayarla**

[setAxisBetweenCategories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaxisbetweencategories/) kullanarak değer ekseninin kategori eksenini kategori aralıkları arasında mı yoksa kategori tik işaretlerinde mi keseceğini kontrol edin. Bu ayar yalnızca kategori eksenleri için geçerlidir. Örnek, bir sütun grafiğinin yatay kategori ekseninde `true` ayarlar ve sonucu kaydeder.

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

## **Bir Grafik Değer Ekseninde Görüntü Birimini Ayarla**

[setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setdisplayunit/) kullanarak değer eksenindeki etiketleri veri değiştirilmeden ölçeklendirin. [DisplayUnitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/displayunittype/) `Millions` olarak ayarlandığında 60 000 000 değeri 60 olarak gösterilir. Örnek, bir sütun grafik oluşturur ve dikey eksenine milyonlar birimini uygular.

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

Pozitif değerler birkaç mertebe farkı gösterdiğinde logaritmik değer ekseni faydalıdır. Örneğin bir hizmet beş dönemde 10, 100, 1 000, 10 000 ve 100 000 istek alabilir. Doğrusal ölçekte küçük değerler sıfıra yakın bir yerde toplanır. Logaritmik ölçek, eşit mesafelerin eşit oranları temsil etmesi sayesinde büyümenin karşılaştırılmasını kolaylaştırır; eşit mesafeler eşit farklar değil, eşit oranlar ifade eder.

Değer ekseninde `true` ile [setLogarithmic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogarithmic/) çağırın ve tabanı seçmek için [setLogBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogbase/) kullanın. Bu, mevcut değerlerin nasıl gösterileceğini değiştirir; veriyi değiştirmez ya da logaritmik bir trend çizgisi eklemez. Trend çizgisi, veriye uyarlanmış bir ilişkiyi temsil eder ve ayrı bir özelliktir.

### **Değer Eksenini ve Tabanı Seç**

Çizgi veya sütun grafiğinde değer ekseni [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/) ile döner. Yatay çubuk grafiğinde [getHorizontalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/gethorizontalaxis/) döner. Dağılım ve balon grafiklerde iki değer ekseni vardır; X değerleri için yatay eksen, Y değerleri için dikey eksen ya da her ikisi kullanılabilir. Kategori eksenine logaritmik ölçek uygulamayın.

Varsayılan logaritmik taban `10`dır. PPTX grafiklerinde taban `2` ile `1000` arasında bir sayı olabilir; kesirli tabanlar (ör. `2.5`) da desteklenir. Tabana `10` verildiğinde 10, 100, 1 000, 10 000 gibi ardışık katlar eşit aralıkta yer alır.

### **Doğrusal ve Logaritmik Ölçekleri Karşılaştır**

Aşağıdaki bağımsız örnek, beş istek sayısını ilk slaytta bir çizgi grafik olarak oluşturur, ardından bu slaytı kopyalar ve ikinci slaytta taban‑10 logaritmik değer ekseni etkinleştirir. İki slayt aynı veriyi tutar.

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

**Doğrusal ölçek (slayt 1):** Eşit dikey mesafeler istek sayısındaki eşit farkları gösterir. En büyük değer grafiği domine eder, küçük değerler ayırt edilemez.

![Doğrusal değer ekseninde beş istek sayısını gösteren çizgi grafik](value-axis-linear.png)

**Logaritmik ölçek (slayt 2):** Eşit dikey mesafeler eşit oranları temsil eder. Her dönem bir önceki dönemden on kat fazla istek alır; noktalar taban‑10 ölçeğinde doğrusal bir yükselen çizgi oluşturur. Eksende etiketler hâlâ orijinal istek sayılarını gösterir.

![Taban‑10 logaritmik değer ekseninde aynı beş istek sayısını gösteren grafik](value-axis-logarithmic.png)

### **Sıfır ve Negatif Değerleri Ele Al**

Logaritmik ölçek yalnızca kesin pozitif değerleri gösterir. Etkinleştirmeden önce veriyi kontrol edin. Sıfır veya negatif değerler anlamlıysa, doğrusal ölçek kullanın veya bunları ayrı olarak gösterin. Bu değerleri dışarıda bırakmak analiz için uygunsa, dışlama nedenini açıklayın. Küçük pozitif sayılara sessizce dönüşüm yapmayın; bu veri anlamını değiştirir. Logaritmik eksen için manuel olarak ayarlanan minimum veya maksimum da pozitif olmalıdır.

## **SSS**

**Bir eksenin diğerini kestiği değeri (eks kesişmesi) nasıl ayarlarım?**

Kesme davranışını seçmek için [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) kullanın. Sayısal bir kesme değeri belirtmek için [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/) kullanın. Bu ayarlar eksen kesişimini uygun bir baz çizgisine taşımanıza olanak tanır.

**Tik etiketlerini eksene göre nasıl konumlandırırım?**

[TikLabelPositionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ticklabelpositiontype/) `Low`, `High`, `NextTo` veya `None` değerleriyle [setTickLabelPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelposition/) çağırın. Tik işaretlerini kontrol etmek için [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) veya [setMinorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setminortickmark/) kullanın; bunlar etiket konumlandırmadan bağımsızdır.