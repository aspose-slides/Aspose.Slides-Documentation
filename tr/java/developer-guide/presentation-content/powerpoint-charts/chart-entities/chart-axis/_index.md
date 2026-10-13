---
title: Sunumlarda Java Kullanarak Grafik Eksenlerini Özelleştirme
linktitle: Grafik Eksenleri
type: docs
url: /tr/java/chart-axis/
keywords:
- grafik ekseni
- dikey eksen
- yatay eksen
- eksen özelleştirme
- eksen manipülasyonu
- eksen yönetimi
- eksen özellikleri
- maksimum değer
- minimum değer
- eksen çizgisi
- tarih formatı
- eksen başlığı
- eksen konumu
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Raporlar ve görselleştirmeler için PowerPoint sunumlarında grafik eksenlerini özelleştirmek amacıyla Aspose.Slides for Java nasıl kullanılır keşfedin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Java ile grafik eksenlerini nasıl özelleştireceğinizi açıklar. Hesaplanmış eksen değerleri, grafik satır ve sütunlarının değiştirilmesi, eksen görünürlüğü, kategori etiketi ve işaret aralıkları, tarih kategorileri ve biçimlendirme, başlık dönüşü, eksen konumlandırma, görüntü birimleri ve logaritmik ölçeklendirme konularını kapsar.

## **Dikey Eksende Maksimum Değerleri Alma**

Bir [Sunum](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) oluşturun ve varsayılan verilerle bir alan grafiği ekleyin. Hesaplanmış eksen değerlerini okumadan önce grafik düzeninin güncel olduğundan emin olmak için [validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#validateChartLayout--) metodunu çağırın.

Eksen sınırları için [getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMaxValue--) ve [getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinValue--) metodlarını, işaret aralıkları için ise [getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnit--) ve [getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnit--) metodlarını okuyun. Tarih eksenleriyle ilgili olan zaman birimi ölçeklerini sağlayan [getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnitScale--) ve [getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnitScale--) metodlarını kullanın. Örnek bu değerleri yerel değişkenlerde saklar ve grafiği kaydeder.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();

    double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

    double majorUnit = chart.getAxes().getVerticalAxis().getActualMajorUnit();
    double minorUnit = chart.getAxes().getVerticalAxis().getActualMinorUnit();

    int majorUnitScale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale();
    int minorUnitScale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale();

    presentation.save("AxisValues_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Verileri Eksenler Arasında Değiştirme**

Grafik verilerinde seriler ve kategorilerin rollerini değiştirmek için [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) metodunu kullanın. Her eski kategori bir seri olur, her eski seri ise bir kategori olur. Bu, verilerin gruplanma şeklini değiştirir; yatay ve dikey eksenleri değiştirmez. Örnek, varsayılan verileri `Sheet1!A1:D5` aralığına (başlık satırı ve kategori sütunu dahil) bağlamak için [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setRange-java.lang.String-) metodunu kullanır, ardından satır ve sütunları değiştirir. Dört seri ve üç kategori içeren bir grafik kaydeder.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    chart.getChartData().setRange("Sheet1!A1:D5");
    chart.getChartData().switchRowColumn();

    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Çizgi Grafiklerinde Dikey Ekseni Devre Dışı Bırakma**

Dikey ekseni gizlemek için `false` parametresiyle [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) metodunu çağırın. Örnek, varsayılan verilerle bir çizgi grafik oluşturur ve dikey ekseni gizli olarak kaydeder.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);

    presentation.save("HiddenVerticalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Çizgi Grafiklerinde Yatay Ekseni Devre Dışı Bırakma**

Yatay ekseni gizlemek için `false` parametresiyle [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) metodunu çağırın. Örnek, varsayılan verilerle bir çizgi grafik oluşturur ve yatay ekseni gizli olarak kaydeder.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);

    presentation.save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Bir Kategori Eksenini Değiştirme**

Tarih veya metin kategori ekseni seçmek için [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) metodunu kullanın. Bu örnek, ilk slayttaki ilk şekil olarak bir grafik içeren ve kategori hücreleri sayısal Excel tarih değerleri içeren `ExistingChart.pptx` dosyasını gerektirir. Yatay ekseni bir tarih eksenine dönüştürür. [setAutomaticMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) metodunu `false`, [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnit-double-) metodunu `1` ve [setMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnitScale-int-) metodunu `TimeUnitType.Months` olarak ayarlamak, ana işaretçileri bir‑aylık aralıklarla yerleştirir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = (IChart) slide.getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months);

    presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kategori Eksen Etiketi Aralıklarını Kontrol Etme**

Bir grafikte çok sayıda kategori olduğunda, kategorileri veya veri noktalarını kaldırmadan görünür eksen etiketi sayısını azaltın. Öncelikle [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) metodunu `false` yapın, ardından istediğiniz kategori aralığını [setTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickLabelSpacing-long-) metoduna gönderin. Normal sıralamadaki metin kategorileri için sayma ilk kategoriden başlar:

| Aralık | Örnekte gösterilen etiketler |
| --- | --- |
| `1` | Kategori 1, Kategori 2, Kategori 3, ... Kategori 24 |
| `2` | Kategori 1, Kategori 3, Kategori 5, ... Kategori 23 |
| `3` | Kategori 1, Kategori 4, Kategori 7, ... Kategori 22 |

`3` aralığı, her üçüncü etiketi gösterir ve gösterilen etiketler arasında iki etiket gizli kalır. İlgili sütunlar kaldırılmaz. Otomatik aralık, mevcut alana göre bir aralık seçer; her etiketi göstermeyebilir.

İşaretçilerin ayrı kontrolleri vardır. [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) metodunu `false` yapın ve işaretçi aralığını ayarlamak için [setTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) metodunu kullanın. Örneğin, `1` ayarı her kategori aralığında bir işaretçi bırakırken, etiketler yalnızca her üçüncü kategoride görünür. Görünür bir stil ayarlamak için [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorTickMark-int-) metodunu kullanın. Otomatik‑aralık ayarlarından birini `true` yaparak grafiğin tekrar otomatik aralık seçmesini sağlayabilirsiniz.

Aşağıdaki bağımsız örnek 24 kategori ve bir seri oluşturur, ardından `CategoryAxisIntervals.pptx` içinde üç slayt kaydeder: otomatik aralık, bağımsız işaretçilerle manuel etiket aralığı ve geri yüklenmiş otomatik aralık. İki kopya da özgün grafik verisini korur. Giriş sunumu gerekmeyebilir. Yatay etiket metni, yoğunluk farkını görmeyi kolaylaştırır.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.setLegend(false);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.ClusteredColumn);
    for (int i = 0; i < 24; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, 10 + i % 6 * 5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    IAxis axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisType(CategoryAxisType.Text);
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0);
    axis.getTextFormat().getPortionFormat().setFontHeight(12);
    axis.setMajorTickMark(TickMarkType.Outside);
    axis.setAutomaticTickLabelSpacing(true);
    axis.setAutomaticTickMarksSpacing(true);

    // Slayt 2: her üçüncü etiketi göster, ancak her kategori için bir işaretçi tut.
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // Slayt 3: grafiğin her iki aralığı da tekrar seçmesine izin ver.
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Otomatik aralık (slayt 1):** Bu görüntüde, her ikinci kategori etiketi gösterilir ve iki satıra kaydırılır. Otomatik sonuç grafik boyutuna, yazı tipine ve renderlayıcıya göre değişebilir.

![Tüm 24 sütun görünürken otomatik kategori etiketi aralığı](category-axis-automatic.png)

**Manuel aralık (slayt 2):** Her üçüncü etiket tek satırda gösterilir, işaretçiler ise her kategori aralığında kalır. Etiketsiz olanlar dahil olmak üzere tüm 24 sütun aynı değerlerle görünür. Slayt 3, yukarıdaki otomatik görünümü geri getirir.

![Tüm 24 sütun görünürken üçlü manuel kategori etiketi aralığı](category-axis-manual.png)

### **Doğru Eksen ve Aralığı Seçme**

Bu kategori‑sayısı aralığını bir metin kategori ekseni için kullanın; örneğin bir sütun, çizgi, alan veya çubuk grafiğinin kategori ekseni. Bir sütun grafiğinde yatay eksen olur. Yatay çubuk grafiğinde kategori ekseni dikeydir; bu ayarları [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--) tarafından döndürülen eksene uygulayın. İşaretçi aralığı ayrıca bir seri eksenine sahip grafiklerde geçerlidir.

Değer ekseni üzerindeki sayısal ölçeği ayarlamak için kategori etiketi aralığını kullanmayın. Değer ekseninde, [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorUnit-double-) metodu değer farkını belirtir: örneğin `10` birim, eksen sıfırdan başlıyorsa 0, 10, 20 … işaretçileri oluşturur. `3` aralıklı kategori etiketi ise veri değerlerinden bağımsız olarak kategori konumlarını sayar. Dağılım ve balon grafikler bir metin kategori ekseni yerine değer eksenleri kullanır. Tarih ekseni için, [Change a Category Axis](#change-a-category-axis) bölümünde açıklandığı gibi zaman‑tabanlı birim ve ölçekleri kullanın.

## **Kategori Ekseni Değerleri için Tarih Biçimini Ayarlama**

Örnek, varsayılan grafik verilerini dört yıllık değerle değiştirir. Tarihler, ilk çalışma sayfasında (indeks `0`) OLE Automation seri numarası olarak saklanır; bu sayı 30 Aralık 1899’dan itibaren geçen gün sayısıdır. [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) metodunu `CategoryAxisType.Date` ile çağırın, [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) metodunu `false` yapın ve `yyyy` değerini [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) metoduna gönderin; böylece kategori etiketleri hücre biçiminden bağımsız olarak dört haneli yılları gösterir.

```java
import com.aspose.slides.*;
import java.time.LocalDate;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    LocalDate baseDate = LocalDate.of(1899, 12, 30);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    for (int i = 0; i < 4; i++) {
        LocalDate date = LocalDate.of(2015 + i, 1, 1);
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, date.toEpochDay() - baseDate.toEpochDay());
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, i + 1);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");

    presentation.save("DateAxisFormat.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Grafik Eksen Başlığı İçin Döndürme Açısını Ayarlama**

Dikey eksende [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTitle-boolean-) metodunu `true` ile çağırın, başlık metnini sağlayın ve başlığı döndürmek için [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) metodunu kullanın. Açı derece cinsindendir; bu örnek, değer‑eksen başlığını 90 derece döndürerek bir sütun grafik kaydeder.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value");
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    presentation.save("RotatedAxisTitle.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kategori veya Değer Ekseninde Eksen Konumunu Ayarlama**

Değer ekseninin kategori eksenini kategoriler arasında mı yoksa kategori işaretçileri üzerinde mi keseceğini kontrol etmek için [setAxisBetweenCategories](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) metodunu kullanın. Bu ayar sadece kategori eksenlerine uygulanır. Örnek, bir sütun grafiğinin yatay kategori ekseninde bu özelliği `true` yapar ve sonucu kaydeder.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    presentation.save("AxisBetweenCategories.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Bir Grafik Değer Ekseninde Görüntü Birimini Ayarlama**

Veriyi değiştirmeden bir değer eksenindeki etiketleri ölçeklemek için [setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setDisplayUnit-int-) metodunu kullanın. [DisplayUnitType](https://reference.aspose.com/slides/java/com.aspose.slides/displayunittype/) `Millions` (Milyonlar) olarak ayarlandığında, 60 000 000 değeri 60 olarak gösterilir. Örnek bir sütun grafik oluşturur ve dikey eksenine milyon görüntü birimini uygular.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions);

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Logaritmik Değer Eksenini Yapılandırma**

Pozitif değerlerin birden çok mertebe kadar yayılması durumunda logaritmik değer ekseni kullanışlıdır. Örneğin, bir hizmet beş dönem içinde sırasıyla 10, 100, 1 000, 10 000 ve 100 000 istek alabilir. Doğrusal ölçekte küçük değerler sıfıra yakın bir aralıkta toplanır. Logaritmik ölçekte ise eşit mesafeler eşit oranları temsil eder; bu da büyüme oranlarını karşılaştırmayı kolaylaştırır.

Değer ekseninde [setLogarithmic](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogarithmic-boolean-) metodunu `true` ve tabanı seçmek için [setLogBase](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogBase-double-) metodunu kullanın. Bu, mevcut değerlerin gösterim şeklini değiştirir; veriyi veya logaritmik trend çizgisini değiştirmez. Trend çizgisi, verideki uyumlu ilişkiyi temsil eden ayrı bir özelliktir.

### **Değer Eksenini ve Tabanı Seçme**

Çizgi veya sütun grafiğinde değer ekseni, [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--) tarafından döndürülür. Yatay çubuk grafiğinde ise [getHorizontalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getHorizontalAxis--) metodundan elde edilir. Dağılım ve balon grafiklerde iki değer ekseni bulunur; X değerleri için yatay eksen, Y değerleri için dikey eksen veya her ikisi seçilebilir. Kategori eksenine logaritmik ölçek uygulamayın.

Varsayılan logaritmik taban `10`‘dur. PPTX grafiklerinde taban `2` ile `1000` arasında (dahil) herhangi bir tam sayı olabilir; `2.5` gibi kesirli tabanlar da desteklenir. Tabana `10` uygulandığında, 10, 100, 1 000, 10 000 gibi ardışık kuvvetler eşit aralıklarla yer alır.

### **Doğrusal ve Logaritmik Ölçekleme Karşılaştırması**

Aşağıdaki bağımsız örnek, ilk slaytta beş istek sayısı ile bir çizgi grafik oluşturur, ardından bu slaytı kopyalar ve ikinci slaytta taban‑10 logaritmik değer eksenini etkinleştirir. Her iki slayt da aynı veriyi korur.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 30, 40, 660, 200);

    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    double[] values = { 10, 100, 1000, 10000, 100000 };

    for (int i = 0; i < values.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Period " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // İlk slaytı lineer tut ve yalnızca kopyanın değer ekseni ölçeğini değiştir.
    ISlide logarithmicSlide = presentation.getSlides().addClone(slide);
    IChart logarithmicChart = (IChart)logarithmicSlide.getShapes().get_Item(0);
    IAxis valueAxis = logarithmicChart.getAxes().getVerticalAxis();
    valueAxis.setLogarithmic(true);
    valueAxis.setLogBase(10);

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Doğrusal ölçek (slayt 1):** Eşit dikey mesafeler, istek sayısındaki eşit farkları gösterir. En büyük değer grafiği hâkim kılar, küçük değerleri ayırt etmeyi zorlaştırır.

![Doğrusal değer ekseninde beş istek sayısını gösteren PowerPoint çizgi grafiği](value-axis-linear.png)

**Logaritmik ölçek (slayt 2):** Eşit dikey mesafeler, eşit oranları temsil eder. Her dönem bir önceki döneme göre on kat fazla istek alır; böylece noktalar taban‑10 ölçeğinde düz bir yükselen çizgi oluşturur. Eksen etiketleri hâlâ özgün istek sayılarını gösterir.

![Taban‑10 logaritmik değer ekseninde aynı beş istek sayısını gösteren PowerPoint grafiği](value-axis-logarithmic.png)

### **Sıfır ve Negatif Değerleri Ele Alma**

Logaritmik ölçek yalnızca kesin pozitif değerleri gösterir. Etkinleştirmeden önce veriyi kontrol edin. Sıfır veya negatif değerler anlamlıysa, doğrusal ölçeği koruyun veya bunları ayrı bir şekilde gösterin. Bu değerleri dışarıda bırakmak analiz için uygun ise, bunu açıklayın. Küçük pozitif sayılarla sessizce değiştirmeyin; bu veri anlamını değiştirir. Logaritmik eksen için manuel olarak ayarlanan minimum veya maksimum değerler de pozitif olmalıdır.

## **SSS**

**Bir eksenin diğerini kestiği noktayı (eks kesişimi) nasıl ayarlarım?**

Kesişme davranışını seçmek için [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) metodunu kullanın. Sayısal bir kesişme değeri belirtmek için [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-) metodunu kullanın. Bu ayarlar eksen kesişimini uygun bir temel çizgiye taşımanıza olanak tanır.

**İşaretçi etiketlerini eksene göre nasıl konumlandırırım?**

[TickLabelPositionType](https://reference.aspose.com/slides/java/com.aspose.slides/ticklabelpositiontype/) değerlerinden birini kullanarak [setTickLabelPosition](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTickLabelPosition-int-) metodunu çağırın: `Low`, `High`, `NextTo` veya `None`. İşaretçilerin kendisini kontrol etmek için [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorTickMark-int-) veya [setMinorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMinorTickMark-int-) metodlarını kullanın; bunlar etiket konumlandırmadan ayrı ayarlardır.