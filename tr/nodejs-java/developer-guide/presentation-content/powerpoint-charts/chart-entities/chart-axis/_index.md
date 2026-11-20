---
title: Sunumlarda JavaScript Kullanarak Grafik Eksenlerini Özelleştirme
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
- tarih biçimi
- eksen başlığı
- eksen konumu
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Raporlar ve görselleştirmeler için PowerPoint sunumlarında grafik eksenlerini özelleştirmek amacıyla Java üzerinden Aspose.Slides for Node.js ile JavaScript kullanımını keşfedin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Node.js via Java ile grafik eksenlerini nasıl özelleştirileceğini açıklamaktadır. Hesaplanmış eksen değerleri, grafik satır ve sütunlarının değiştirilmesi, eksen görünürlüğü, kategori etiketi ve işaretçi aralıkları, tarih kategorileri ve biçimlendirme, başlık rotasyonu, eksen konumlandırması, görüntüleme birimleri ve logaritmik ölçeklendirme konularını kapsar.

## **Grafiklerde Dikey Eksenin Maksimum Değerlerini Almak**

Bir [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) oluşturun ve varsayılan verilerle bir alan grafiği ekleyin. Hesaplanmış eksen değerlerini okumadan önce, grafiğin düzeninin güncel olduğundan emin olmak için [validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) metodunu çağırın.  
Eksen sınırları için [getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmaxvalue/) ve [getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminvalue/) metodlarını, işaretçi aralıkları için ise [getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunit/) ve [getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunit/) metodlarını okuyun. [getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunitscale/) ve [getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunitscale/) zaman birimi ölçeklerini sağlar; bu, tarih eksenleri için önemlidir. Örnek, bu değerleri yerel değişkenlerde saklar ve grafiği kaydeder.

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

## **Eksenler Arasındaki Verileri Değiştirin**

Grafik verilerinde seri ve kategori rollerini değiştirmek için [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) metodunu kullanın. Önceki her kategori bir seri, önceki her seri ise bir kategori olur. Bu, verilerin gruplanış şeklini değiştirir; yatay ve dikey eksenleri değiştirmez. Örnek, satır ve sütunları değiştirmeden önce varsayılan verileri `Sheet1!A1:D5` aralığına bağlamak için [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) metodunu kullanır; başlık satırı ve kategori sütunu da dahil edilir. Dört seri ve üç kategori içeren bir grafik kaydeder.

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

## **Bir Eksenin Çizim Sırasını Tersine Çevirin**

[setPlotOrderReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setplotorderreversed/) metodunu kullanarak bir kategori veya değer eksenini tersine çevirebilirsiniz. Örneğin, yatay çubuk grafiği, proje aşamalarını çalışma sayfasındaki sırayla üstten alta gösterebilir: Planlama, Geliştirme, Test. Bir ekseni tersine çevirmek, çizim yönünü değiştirir; veri sayfasındaki verileri sıralamaz veya yeniden düzenlemez. Buna karşılık, [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) seri ve kategori rollerini değiştirir.  

Aşağıdaki örnek, üç aşama ve bir seri içeren bir yatay çubuk grafik oluşturur. Normal sıra, ters kategori ve ters değer olmak üzere üç slayt içeren bir sunum kaydeder. Her kopya aynı veri kümesini kullanır ve her kopyada yalnızca bir eksen tersine çevrilir.

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

Bir ekseni tersine çevirmek, dik ekseni çizimin karşı tarafına taşıyabilir. [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) metoduyla, yapılandırılan eksenin diğer eksenle nerede kesişeceği kontrol edilir. 2. slaytta, ters kategori ekseninde `aspose.slides.CrossesType.Maximum` ile çağrıldığında, yatay değer ekseni altta kalır. Belirli bir kesişme noktası için [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/) metodunu kullanın. Yön değiştirirken, özellikle grafik zaten özel bir kesişim noktasına sahipse, kesişim ayarlarını kontrol edin. Normal çizim yönünü geri getirmek için `setPlotOrderReversed` metodunu `false` ile çağırın; kesişim ayarları bağımsızdır.

| Normal sıra (slayt 1) | Ters kategoriler (slayt 2) | Ters değerler (slayt 3) |
| --- | --- | --- |
| ![Normal kategori ve değer ekseni sırasına sahip yatay çubuk grafik](axis-order-normal.png) | ![Kategorilerin üstten alta gösterildiği yatay çubuk grafik](axis-order-categories-reversed.png) | ![Değer ekseni ters ve sıfır sağda olan yatay çubuk grafik](axis-order-values-reversed.png) |
| Kategoriler alttan üste doğru ilerler; değerler soldan sağa artar. | Planlama, Geliştirme ve Test üstten alta doğru ilerler. Değerler ve çalışma kitabı satır sırası değişmemiştir. | Kategoriler normal sırasını korur; değerler sağdan sola artar. Kategori ekseni sağdaki sıfırda kesişir. |

## **Çizgi Grafiklerde Dikey Eksen'i Devre Dışı Bırakın**

Dikey ekseni gizlemek için [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) metodunu `false` ile çağırın. Örnek, varsayılan verilerle bir çizgi grafik oluşturur ve dik ekseni gizli olarak kaydeder.

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

## **Çizgi Grafiklerde Yatay Eksen'i Devre Dışı Bırakın**

Yatay ekseni gizlemek için [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) metodunu `false` ile çağırın. Örnek, varsayılan verilerle bir çizgi grafik oluşturur ve yatay ekseni gizli olarak kaydeder.

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

## **Grafik Izgara Çizgilerini Gösterin veya Gizleyin**

[getShowMajorGridLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getshowmajorgridlines/) ve [getShowMinorGridLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getshowminorgridlines/) metodlarını çağırarak bir eksenin hangi ızgara çizgilerini gösterdiğini kontrol edin. Küçük ızgara çizgilerini göstermek için [getMinorGridLinesFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getminorgridlinesformat/) metodunu kullanıp satır doldurmayı katı, görünür bir renge ayarlayın. Gizlemek için doldurmayı [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) olarak ayarlayın. Aynı şekilde büyük ızgara çizgileri için satır doldurmayı değiştirmek amacıyla [getMajorGridLinesFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getmajorgridlinesformat/) metodunu kullanın. Doldurma değişikliği eksenin görünürlüğünü ve işaretçileri korur.  

Bu kümelenmiş sütun grafiğinin dik ekseni başlangıçta yalnızca büyük ızgara çizgilerini gösterir. Örnek, küçük ızgara çizgilerini koyu turuncu renkte gösterir, ardından tekrar gizler ve sunumu kaydeder. Her adımda ızgara çizgisi görünürlüğünü yazdırır.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 30, 660, 230);
    var axis = chart.getAxes().getVerticalAxis();
    console.log("Initial: major=%s, minor=%s", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    var minorFill = axis.getMinorGridLinesFormat().getLine().getFillFormat();
    minorFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
    var darkOrange = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    minorFill.getSolidFillColor().setColor(darkOrange);
    console.log("Enabled: minor=%s", axis.getShowMinorGridLines());

    minorFill.setFillType(java.newByte(aspose.slides.FillType.NoFill));
    console.log("Hidden: major=%s, minor=%s", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    presentation.save("ChartGridlines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Küçük ızgara çizgileri etkin | Küçük ızgara çizgileri gizli |
| --- | --- |
| ![Dikey eksende büyük ızgara çizgileri arasındaki turuncu küçük ızgara çizgileri](minor-gridlines-enabled.png) | ![Yalnızca büyük ızgara çizgileri görünür aynı sütun grafik](minor-gridlines-hidden.png) |

## **Kategori Eksenini Değiştirin**

[setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) metodunu kullanarak tarih ya da metin kategori ekseni seçin. Bu örnek `ExistingChart.pptx` dosyasını gerektirir; ilk slayttaki ilk şekil bir grafik ve kategori hücreleri sayısal Excel tarih değerleri içerir. Yatay ekseni bir tarih ekseni yapar. [setAutomaticMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmajorunit/) metodunu `false`, [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) metodunu `1` ve [setMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunitscale/) metodunu `TimeUnitType.Months` olarak ayarlamak, ana işaretçileri bir‑ay aralıklarla yerleştirir.

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

### **Verilerden Kategori Eksen Tipini Belirleyin**

Kategorileri doldurduktan sonra [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistypeautomatically/) metodunu çağırın, ardından seçimi incelemek için [getCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getcategoryaxistype/) metodunu okuyun. Aynı grafiğe metin etiketleri ya da sayısal tarih değerleri verilebileceğinde bu faydalıdır. Metod çağrıldığı anda türü belirler; daha sonraki veri değişikliklerini yeniden değerlendiren kalıcı bir mod etkinleştirmez. Kategorileri değiştirdikten sonra tekrar çağırın.  

Aşağıdaki örnek, metin kategorili bir grafik oluşturur ve seçilen tip `CategoryAxisType.Text` olduğunda `true` yazdırır. Ardından kategori hücre değerlerini tarihlerle değiştirir, metodu tekrar çağırır ve seçilen tip `CategoryAxisType.Date` olduğunda `true` yazdırır. Tarihler, ilk çalışma sayfasında (indeks `0`) OLE Automation seri sayıları olarak saklanır; bu, tarihlerin 30 Aralık 1899’dan itibaren geçen gün sayısıdır, tarih dizgileri değildir. JavaScript hesabı UTC zaman damgalarını kullanır ve farkı 86 400 000 milisaniye (gün) ile böler; ay indeksleri sıfır‑bazlıdır. Her tarih değerini Java’ya çift olarak geçirmek için `java.newDouble` kullanın. [setCustomNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setcustomnumberformat/) metoduyla bu değerlerin nasıl gösterileceği kontrol edilir; metni sayısal tarihlere dönüştürmez. Kategori hücreleri hakkında daha fazla bilgi için [Chart Workbook](/slides/tr/nodejs-java/chart-workbook/) sayfasına bakın.  

Girişin metin kategorileri ya da sayısal tarihler içerdiği biliniyorsa otomatik belirlemeyi kullanın. Normal sayısal etiketler, karışık kategoriler ya da boş veri için, istenen anlama uyması için açıkça [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) metodunu çağırın. Yalnızca sayısal değerler, kategorilerin tarih olduğu anlamını taşımaz.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var seriesName = workbook.getCell(0, 0, 1, "Sales");
    var series = chart.getChartData().getSeries().add(seriesName, chart.getType());
    var labels = ["First", "Second", "Third"];

    for (var i = 0; i < labels.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, labels[i]);
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, (i + 1) * 10);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    var axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisTypeAutomatically();
    console.log(axis.getCategoryAxisType() === aspose.slides.CategoryAxisType.Text); // doğru

    var baseDate = Date.UTC(1899, 11, 30);
    var dates = [Date.UTC(2026, 0, 1), Date.UTC(2026, 0, 2), Date.UTC(2026, 1, 1)];

    for (var i = 0; i < dates.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0);
        var dateValue = java.newDouble((dates[i] - baseDate) / 86400000);
        categoryCell.setValue(dateValue);
        categoryCell.setCustomNumberFormat("yyyy-mm-dd");
    }

    axis.setCategoryAxisTypeAutomatically();
    console.log(axis.getCategoryAxisType() === aspose.slides.CategoryAxisType.Date); // doğru

    presentation.save("AutomaticCategoryAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kategori Eksen Etiket Aralıklarını Kontrol Edin**

Bir grafikte çok sayıda kategori bulunduğunda, kategori ya da veri noktalarını kaldırmadan görünür eksen etiketi sayısını azaltın. [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticticklabelspacing/) metodunu `false` ile çağırın, ardından istediğiniz kategori aralığını [setTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelspacing/) metoduna geçirin. Normal sıradaki metin kategorileri için sayma ilk kategoriden başlar:

| Aralık | Örnekte görüntülenen etiketler |
| --- | --- |
| `1` | Kategori 1, Kategori 2, Kategori 3, … Kategori 24 |
| `2` | Kategori 1, Kategori 3, Kategori 5, … Kategori 23 |
| `3` | Kategori 1, Kategori 4, Kategori 7, … Kategori 22 |

`3` aralık, her üçüncü etiketi gösterir; gösterilen etiketler arasında iki etiket gizli kalır. İlgili sütunları kaldırmaz. Otomatik aralık, kullanılabilir alana göre bir aralık seçer; her etiketi gösterme garantisi yoktur.  

İşaretçilerin ayrı kontrolleri vardır. [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomatictickmarksspacing/) metodunu `false` ile çağırıp [setTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settickmarksspacing/) ile aralığını ayarlayın. Örneğin, `1` işaretçi her kategori aralığında kalırken etiketler yalnızca her üçüncü kategoride görünür. Görünür bir stil ile [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) metodunu kullanarak sonucu izleyin. Otomatik‑aralık ayarını tekrar `true` yaparsanız grafik aynı aralığı yeniden seçer.  

Aşağıdaki örnek, 24 kategori ve bir seri oluşturur, ardından `CategoryAxisIntervals.pptx` içinde üç slayt kaydeder: otomatik aralık, bağımsız işaretçili manuel etiket aralığı ve otomatik aralığın geri yüklenmesi. İki kopya orijinal grafik verisini korur. Giriş sunumu gerekmez. Yatay etiket metni, yoğunluk farkını net görmenizi sağlar.

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

    // Slayt 2: her üçüncü etiketi göster, ancak her kategori için bir işaretçi tut.
    var manualSlide = presentation.getSlides().addClone(slide);
    var manualChart = manualSlide.getShapes().get_Item(0);
    var manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // Slayt 3: grafiğin her iki aralığı da yeniden seçmesine izin ver.
    var restoredSlide = presentation.getSlides().addClone(manualSlide);
    var restoredChart = restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Otomatik aralık (slayt 1):** Bu renderda, her ikinci kategori etiketi gösterilir ve iki satıra kaydırılır. Otomatik sonuç grafik boyutu, yazı tipleri ve renderlayıcıya göre değişebilir.

![Tüm 24 sütunun görüldüğü otomatik kategori etiketi aralığı](category-axis-automatic.png)

**Manuel aralık (slayt 2):** Her üçüncü etiket bir satırda gösterilir, işaretçiler her kategori aralığında kalır. Tüm 24 sütun, etiketi olmayanlar dahil, aynı değerlerle görünür. 3. slayt otomatik görünümü geri yükler.

![Tüm 24 sütunun görüldüğü üçlü manuel kategori etiketi aralığı](category-axis-manual.png)

### **Doğru Eksen ve Aralığı Seçin**

Bu kategori‑sayım aralığını bir metin kategori ekseni için kullanın; örneğin bir sütun, çizgi, alan ya da çubuk grafiğinin kategori ekseni. Sütun grafiğinde yatay eksen, yatay çubuk grafiğinde ise kategori ekseni dikeydir; bu yüzden ayarları [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/) tarafından döndürülen eksene uygulayın. İşaretçi aralığı, bir seriye sahip grafiklerde seriler eksenine de uygulanabilir.  

Kategori etiketi aralığını bir değer ekseninin sayısal ölçeğini ayarlamak için kullanmayın. Değer ekseninde [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) bir değer farkı belirler; örneğin `10` bir birim, eksen sıfırdan başladığında 0, 10, 20 … işaretçileri oluşturur. `3` kategori etiketi aralığı ise veri değerlerinden bağımsız olarak kategori konumlarını sayar. Dağılım ve balon grafikler bir metin kategori ekseni yerine değer eksenleri kullanır. Tarih ekseni için, [Kategori Eksenini Değiştirin](#change-a-category-axis) başlığında açıklandığı gibi zaman‑bazlı ana birimler ve ölçekler kullanın.

## **Kategori Eksen Değerleri için Tarih Biçimini Ayarlayın**

Örnek, varsayılan grafik verisini dört yıllık değerle değiştirir. Tarihler, birinci çalışma sayfasındaki (indeks `0`) OLE Automation seri sayıları olarak saklanır; bu, tarihlerin 30 Aralık 1899’dan itibaren geçen gün sayısıdır, tarih dizgileri değildir. JavaScript hesabı UTC zaman damgalarını kullanır ve farkı 86 400 000 milisaniye (gün) ile böler. [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) metodunu `CategoryAxisType.Date` ile, [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) metodunu `false` ile ve [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) metoduna `yyyy` geçerek kategori etiketlerinin hücre biçiminden bağımsız olarak dört basamaklı yıl göstermesini sağlayın.

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

## **Grafik Eksen Başlığı için Döndürme Açısını Ayarlayın**

Dikey eksende [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settitle/) metodunu `true` ile çağırın, başlık metnini sağlayın ve başlığı döndürmek için [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setrotationangle/) metodunu kullanın. Açı dereceler cinsinden ölçülür; bu örnek, değer ekseni başlığını 90 derece döndürerek bir sütun grafik kaydeder.

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

## **Kategori veya Değer Ekseni Üzerinde Eksen Konumunu Ayarlayın**

[setAxisBetweenCategories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaxisbetweencategories/) metodunu kullanarak değer ekseninin kategori eksenini kategoriler arasından mı yoksa kategori işaretçilerinde mi keseceğini kontrol edin. Bu ayar kategori eksenlerine uygulanır. Örnek, bir sütun grafiğinin yatay kategori ekseninde bunu `true` yapar ve sonucu kaydeder.

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

## **Grafik Değer Ekseni Üzerinde Görüntüleme Birimini Ayarlayın**

[setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setdisplayunit/) metodunu kullanarak veri değişmeden değer ekseni etiketlerini ölçeklendirin. [DisplayUnitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/displayunittype/) `Millions` olarak ayarlandığında, 60 000 000 değeri 60 olarak gösterilir. Örnek bir sütun grafik oluşturur ve dik eksenine milyon görüntüleme birimini uygular.

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

## **Logaritmik Değer Ekseni Yapılandırması**

Logaritmik değer ekseni, pozitif değerler birkaç büyüklük mertebesine yayıldığında yararlıdır. Örneğin, bir hizmet beş dönem boyunca 10, 100, 1 000, 10 000 ve 100 000 istek alabilir. Lineer ölçekte, daha küçük değerler sıfıra yakın bir arada görünür. Logaritmik ölçek, bunların göreceli büyümesini daha kolay karşılaştırır: eşit mesafeler eşit oranları temsil eder, eşit farkları değil.  

Değer ekseninde [setLogarithmic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogarithmic/) metodunu `true` ile çağırın ve temel seçmek için [setLogBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogbase/) metodunu kullanın. Bu, mevcut değerlerin gösterilme şeklini değiştirir; veriyi değiştirmez ya da logaritmik bir trend çizgisi eklemez. Trend çizgisi, verideki uyarlanmış ilişkiyi temsil eder ve ayrı bir özelliktir.  

### **Değer Eksenini ve Tabanı Seçin**

Çizgi ya da sütun grafiğinde değer ekseni [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/) tarafından döndürülür. Yatay çubuk grafikinde [getHorizontalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/gethorizontalaxis/) metoduyla elde edilir. Dağılım ve balon grafiklerde iki değer ekseni bulunur; X değerleri için yatay, Y değerleri için dik eksen ya da ikisi seçilir. Bir kategori eksenine logaritmik ölçek uygulamayın.  

Varsayılan logaritmik taban `10`’dur. PPTX grafiklerinde `2`‑`1000` arasında (dahil) bir taban kullanılabilir; `2.5` gibi kesirli tabanlar da desteklenir. Tabana `10` verildiğinde, ardışık kat sayılar 10, 100, 1 000, 10 000 eşit aralıklarda yer alır.  

### **Lineer ve Logaritmik Ölçeklemeyi Karşılaştırın**

Aşağıdaki örnek, ilk slaytta beş istek sayısını içeren bir çizgi grafik oluşturur, ardından bu slaytı kopyalar ve ikinci slaytta taban‑10 logaritmik değer eksenini etkinleştirir. İki slayt aynı veriyi korur.

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

    // İlk slaytı lineer tut ve yalnızca kopyanın değer ekseni ölçeğini değiştir.
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

**Lineer ölçek (slayt 1):** Eşit dikey mesafeler, istek sayısındaki eşit farkları temsil eder. En büyük değer grafiği domine eder, daha küçük değerleri ayırt etmeyi zorlaştırır.

![Lineer değer ekseninde beş istek sayısını gösteren PowerPoint'te çizgi grafik](value-axis-linear.png)

**Logaritmik ölçek (slayt 2):** Eşit dikey mesafeler eşit oranları temsil eder. Her dönem, bir önceki döneme göre on kat fazla istek alır; bu yüzden noktalar taban‑10 ölçeğinde düz bir yükselen çizgi oluşturur. Eksen etiketleri hâlâ orijinal istek sayılarını gösterir.

![PowerPoint'te aynı beş istek sayısı, taban-10 logaritmik değer ekseninde](value-axis-logarithmic.png)

### **Sıfır ve Negatif Değerlerle Başa Çıkma**

Logaritmik ölçek yalnızca kesin pozitif değerleri gösterebilir. Etkinleştirmeden önce verileri kontrol edin. Sıfır ya da negatif değerler anlamlıysa, lineer ölçeği koruyun ya da ayrı olarak gösterin. Analiz için bu değerleri dışlamak uygun ise, eksikliği açıklayın. Veriyi gizlice küçük pozitif sayılarla değiştirmeyin; bu, verinin anlamını değiştirir. Logaritmik eksen için manuel olarak ayarlanan herhangi bir minimum veya maksimum da pozitif olmalıdır.

## **SSS**

**Bir eksenin diğerini kestiği değeri (eksen kesişimi) nasıl ayarlarım?**  
[setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) metodunu kullanarak kesişim davranışını seçin. Sayısal bir kesişim değeri belirtmek için [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/) metodunu kullanın. Bu ayarlar, eksen kesişimini uygun bir temel çizgisine taşımanıza olanak tanır.  

**İşaretçi etiketlerini eksene göre nasıl konumlandırabilirim?**  
[setTickLabelPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelposition/) metodunu [TickLabelPositionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ticklabelpositiontype/) ile birlikte kullanın: `Low`, `High`, `NextTo` ya da `None`. İşaretçi işaretçilerini kontrol etmek için [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) ya da [setMinorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setminortickmark/) metodlarını kullanın; bunlar etiket konumlandırmasından ayrı özelliklerdir.