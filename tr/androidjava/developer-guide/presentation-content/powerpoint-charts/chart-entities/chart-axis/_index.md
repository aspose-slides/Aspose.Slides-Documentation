---
title: Android'de Sunumlarda Grafik Eksenlerini Özelleştirme
linktitle: Grafik Ekseni
type: docs
url: /tr/androidjava/chart-axis/
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
- Android
- Java
- Aspose.Slides
description: "Raporlar ve görselleştirmeler için PowerPoint sunumlarında grafik eksenlerini özelleştirmek üzere Java aracılığıyla Android için Aspose.Slides kullanımını keşfedin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Android via Java ile grafik eksenlerini nasıl özelleştirileceğini açıklar. Hesaplanmış eksen değerleri, grafik satır ve sütunlarının değiştirilmesi, eksen görünürlüğü, kategori etiketi ve işaretçik aralıkları, tarih kategorileri ve biçimlendirme, başlık döndürme, eksen konumlandırma, gösterim birimleri ve logaritmik ölçeklendirme konularını kapsar.

## **Grafiklerde Dikey Eksenin Maksimum Değerlerini Alın**

Bir [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) oluşturun ve varsayılan verilerle bir alan grafiği ekleyin. Hesaplanmış eksen değerlerini okumadan önce grafik düzeninin güncel olduğundan emin olmak için [validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--) yöntemini çağırın.

Eksen sınırları için [getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMaxValue--) ve [getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinValue--) metodunu, işaretçi aralıkları için ise [getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnit--) ve [getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnit--) metodunu okuyun. [getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnitScale--) ve [getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnitScale--) tarih eksenleriyle ilgili zaman birimi ölçeklerini sağlar. Örnek bu değerleri yerel değişkenlerde saklar ve grafiği kaydeder.

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

## **Eksenler Arasındaki Verileri Değiştirin**

[swapRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) yöntemini kullanarak grafik verilerinde seri ve kategori rollerini değiştirin. Her önceki kategori bir seri, her önceki seri ise bir kategori olur. Bu, verilerin gruplanma şeklini değiştirir; yatay ve dikey eksenleri değiştirmez. Örnek, satır ve sütunları değiştirmeden önce varsayılan veriyi `Sheet1!A1:D5` adresine (başlık satırı ve kategori sütunu dahil) bağlamak için [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setRange-java.lang.String-) metodunu kullanır. Dört seri ve üç kategori içeren bir grafik kaydeder.

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

## **Bir Eksenin Çizim Sırasını Tersine Çevirin**

[setPlotOrderReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setPlotOrderReversed-boolean-) metodunu kullanarak bir kategori ya da değer eksenini tersine çevirin. Örneğin, bir yatay çubuk grafiği proje aşamalarını çalışma sayfasındaki aynı sırayla üstten alta gösterebilir: Planlama, Geliştirme, Test. Bir ekseni tersine çevirmek çizim yönünü değiştirir; verileri sıralamaz veya yeniden düzenlemez. Karşılaştırma olarak, [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) seri ve kategori rollerini değiştirir.

Aşağıdaki örnek üç aşamalı ve bir serili bir yatay çubuk grafiği oluşturur. Normal sıralama, tersine çevrilmiş kategoriler ve tersine çevrilmiş değerler olmak üzere üç slayt içeren bir sunum kaydeder. Her kopya aynı veri kümesini kullanır ve her kopyada yalnızca bir eksen tersine çevrilir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredBar, 50, 40, 620, 320);
    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.ClusteredBar);
    String[] stages = { "Planning", "Development", "Testing" };
    int[] values = { 10, 30, 20 };
    for (int i = 0; i < stages.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, stages[i]);
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    // Slayt 2: ilk kategoriyi üstte göster.
    ISlide categorySlide = presentation.getSlides().addClone(slide);
    IChart categoryChart = (IChart)categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // Yatay değer eksenini altta tut.
    categoryChart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum);

    // Slayt 3: yalnızca yatay sayısal ölçeği tersine çevir.
    ISlide valueSlide = presentation.getSlides().addClone(slide);
    IChart valueChart = (IChart)valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bir ekseni tersine çevirmek, dik ekseni grafiğin karşı tarafına da taşıyabilir. [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) başka bir eksenin yapılandırılan ekseni nerede kestiğini kontrol eder. 2. slaytta, tersine çevrilmiş kategori ekseninde `CrossesType.Maximum` ile çağırmak, yatay değer eksenini altta tutar. Belirli bir kesişim noktası için [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-) kullanın. Yön değiştirilirken kesişim ayarlarını kontrol edin, özellikle grafik zaten özel bir kesişim noktasına sahipse. Normal çizim yönünü geri getirmek için `setPlotOrderReversed` metodunu `false` ile çağırın; kesişim ayarları ayrı tutulur.

| Normal sıralama (slayt 1) | Tersine çevrilmiş kategoriler (slayt 2) | Tersine çevrilmiş değerler (slayt 3) |
| --- | --- | --- |
| ![Normal kategori ve değer ekseni düzenine sahip yatay çubuk grafiği](axis-order-normal.png) | ![Kategorilerin yukarıdan aşağıya gösterildiği yatay çubuk grafiği](axis-order-categories-reversed.png) | ![Tersine çevrilmiş değer ekseni ve sağda sıfır olan yatay çubuk grafiği](axis-order-values-reversed.png) |
| Kategoriler alttan üste doğru; değerler soldan sağa artar. | Planlama, Geliştirme ve Test, yukarıdan aşağıya doğru. Değerler ve çalışma kitabı satır sırası değişmez. | Kategoriler normal sıralarını korur; değerler sağdan sola artar. Kategori ekseni sağda sıfırda kesişir. |

## **Çizgi Grafiklerinde Dikey Eksen'i Devre Dışı Bırakın**

Dikey eksende `[setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-)` metodunu `false` olarak çağırarak gizleyin. Örnek, varsayılan verilerle bir çizgi grafiği oluşturur ve dik ekseni gizlenmiş olarak kaydeder.

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

## **Çizgi Grafiklerinde Yatay Eksen'i Devre Dışı Bırakın**

Yatay eksende `[setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-)` metodunu `false` olarak çağırarak gizleyin. Örnek, varsayılan verilerle bir çizgi grafiği oluşturur ve yatay ekseni gizlenmiş olarak kaydeder.

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

## **Bir Kategori Eksenini Değiştirin**

[setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) metodunu kullanarak tarih ya da metin kategori ekseni seçin. Bu örnek `ExistingChart.pptx` dosyasını gerektirir; grafik ilk slayttaki ilk şekil olup kategori hücreleri sayısal Excel tarih değerleri içerir. Yatay ekseni tarih ekseni olarak değiştirir. [setAutomaticMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) metodunu `false`, [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnit-double-) metodunu `1` ve [setMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnitScale-int-) metodunu `TimeUnitType.Months` olarak ayarlamak, ana işaretçileri bir‑ay aralıklarla yerleştirir.

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

## **Kategori Eksen Etiketi Aralıklarını Kontrol Edin**

Bir grafikte çok sayıda kategori olduğunda, kategori ya da veri noktalarını kaldırmadan görünen eksen etiketlerinin sayısını azaltın. [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) metodunu `false` yapın, ardından istediğiniz kategori aralığını [setTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickLabelSpacing-long-) metoduna gönderin. Normal sıralamadaki metin kategorileri için sayma ilk kategoriden başlar:

| Aralık | Örnekte gösterilen etiketler |
| --- | --- |
| `1` | Kategori 1, Kategori 2, Kategori 3, ... Kategori 24 |
| `2` | Kategori 1, Kategori 3, Kategori 5, ... Kategori 23 |
| `3` | Kategori 1, Kategori 4, Kategori 7, ... Kategori 22 |

`3` aralığı her üçüncü etiketi gösterir, gösterilen etiketlerin arasına iki etiket gizlenir. İlgili sütunlar kaldırılmaz. Otomatik aralık, mevcut alana göre bir aralık seçer; her etiketi mutlaka göstermez.

İşaretçikler ayrı kontrollerle ayarlanır. [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) metodunu `false` yapın ve [setTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) metodunu kullanarak aralıklarını belirleyin. Örneğin, `1` değeri, etiketler her üçüncü kategoriye rağmen her kategori aralığında bir işaretçi bırakır. Görünür bir stil için [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorTickMark-int-) metodunu kullanabilirsiniz. Otomatik‑aralık ayarlarını tekrar `true` yaparsanız grafik yeniden aralığı seçer.

Aşağıdaki örnek, 24 kategori ve bir seri oluşturur, ardından `CategoryAxisIntervals.pptx` içinde üç slayt kaydeder: otomatik aralık, bağımsız işaretçikli manuel etiket aralığı ve geri yüklenmiş otomatik aralık. İki kopya orijinal grafik verisini korur. Giriş sunumu gerekmez. Yatay etiket metni yoğunluğu görmeyi kolaylaştırır.

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

    // Slayt 2: her üçüncü etiketi göster, ancak her kategori için bir işaretçiyi koru.
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

**Automatic spacing (slide 1):** Bu görüntüde her ikinci kategori etiketi gösterilir ve iki satıra kaydırılır. Otomatik sonuç grafik boyutu, yazı tipi ve işleyiciye göre değişebilir.

![Tüm 24 sütun görünürken otomatik kategori etiketi aralığı](category-axis-automatic.png)

**Manual spacing (slide 2):** Her üçüncü etiket tek satırda gösterilir, işaretçikler ise her kategori aralığında kalır. Etiketsiz olanlar dahil 24 sütun aynı değerlerle görünür. 3. slayt yukarıdaki otomatik görünümü geri yükler.

![Tüm 24 sütun görünürken üçlü manuel kategori etiketi aralığı](category-axis-manual.png)

### **Doğru Eksen ve Aralığı Seçin**

Metin kategori ekseni için bu kategori‑sayı aralığını kullanın; örneğin sütun, çizgi, alan ya da çubuk grafiğinin kategori ekseni. Sütun grafiğinde yatay eksendir. Yatay çubuk grafiğinde kategori ekseni dik olduğundan, bu ayarları [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--) metodundan dönen eksene uygulayın. İşaretçik aralığı aynı zamanda bir serinin eksenine de uygulanır.

Değer ekseninin sayısal ölçeğini ayarlamak için kategori etiketi aralığını kullanmayın. Değer ekseninde [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorUnit-double-) yöntemi bir değer farkı belirtir: örneğin `10` ana birim değer eksenini 0, 10, 20 … şeklinde işaretler. `3` kategori etiketi aralığı ise veri değerlerinden bağımsız olarak kategori konumlarını sayar. Dağılım ve balon grafikler metin kategori ekseni yerine değer eksenleri kullanır. Tarih ekseni için, [Change a Category Axis](#change-a-category-axis) bölümünde açıklandığı gibi zaman‑tabanlı ana birimler ve ölçekler kullanın.

## **Kategori Eksen Değerleri için Tarih Formatını Ayarlayın**

Örnek, varsayılan grafik verilerini dört yıllık değere değiştirir. Tarihler, ilk çalışma sayfasında (indeks `0`) OLE Automation seri sayıları olarak saklanır; bu sayılar 30 Aralık 1899’dan beri geçen gün sayısıdır. Her iki takvim UTC olarak ayarlanır ve tarih ayarları yapılmadan önce temizlenir; böylece yaz saati değişikliği ve günün saati hesaplamayı etkilemez. [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) metodunu `CategoryAxisType.Date` ile kullanın, [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) metodunu `false` yapın ve [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) metoduna `yyyy` geçerek kategori etiketlerinin hücre biçiminden bağımsız olarak dört basamaklı yıl göstermesini sağlayın.

```java
import com.aspose.slides.*;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.TimeZone;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    TimeZone timeZone = TimeZone.getTimeZone("UTC");
    Calendar baseDate = new GregorianCalendar(timeZone);
    baseDate.clear();
    baseDate.set(1899, Calendar.DECEMBER, 30);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    for (int i = 0; i < 4; i++) {
        Calendar date = new GregorianCalendar(timeZone);
        date.clear();
        date.set(2015 + i, Calendar.JANUARY, 1);
        double serialDate = (date.getTimeInMillis() - baseDate.getTimeInMillis()) / 86400000.0;
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, serialDate);
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

## **Bir Grafik Eksen Başlığı İçin Döndürme Açısı Ayarlayın**

Dikey eksende `[setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTitle-boolean-)` metodunu `true` ile çağırın, başlık metnini sağlayın ve `[setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-)` metodunu kullanarak başlığı döndürün. Açı derece cinsindendir; bu örnek, değer‑eksen başlığı 90 derece döndürülmüş bir sütun grafiği kaydeder.

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

## **Kategori ya da Değer Ekseni Üzerinde Eksen Konumunu Ayarlayın**

[setAxisBetweenCategories](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) metodunu kullanarak değer ekseninin kategori eksenini kategori işaretçikleri arasında mı yoksa işaretçi konumunda mı keseceğini denetleyin. Bu ayar sadece kategori eksenlerine uygulanır. Örnek, bir sütun grafiğinin yatay kategori ekseninde bu ayarı `true` yapar ve sonucu kaydeder.

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

## **Bir Grafik Değer Ekseni Üzerinde Görüntüleme Birimini Ayarlayın**

[setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setDisplayUnit-int-) metodunu kullanarak değer eksenindeki etiketleri verileri değiştirmeden ölçeklendirin. [DisplayUnitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/displayunittype/) `Millions` olarak ayarlandığında 60 000 000 değeri 60 olarak gösterilir. Örnek bir sütun grafiği oluşturur ve dik eksenine milyon görüntüleme birimini uygular.

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

## **Logaritmik Değer Ekseni Yapılandırın**

Pozitif değerler birkaç mertebe boyunca değişiyorsa logaritmik değer ekseni faydalıdır. Örneğin bir hizmet beş dönem içinde 10, 100, 1 000, 10 000 ve 100 000 istek alabilir. Doğrusal ölçekte daha küçük değerler sıfıra yakın bir yerde toplanır. Logaritmik ölçek, büyüme oranlarını karşılaştırmayı kolaylaştırır: eşit mesafeler eşit oranları temsil eder, eşit farkları değil.

Değer ekseninde `[setLogarithmic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogarithmic-boolean-)` metodunu `true` yapın ve `[setLogBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogBase-double-)` metoduyla tabanı seçin. Bu, mevcut değerlerin gösterimini değiştirir; verileri ya da logaritmik bir trend çizgisi eklemez. Trend çizgisi, verilerde uygun bir ilişkiyi temsil eden ayrı bir özelliktir.

### **Değer Ekseni ve Tabanı Seçin**

Çizgi ya da sütun grafiğinde değer ekseni `[getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--)` metodundan alınır. Yatay çubuk grafiğinde değer ekseni `[getHorizontalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getHorizontalAxis--)` metodundan alınır. Dağılım ve balon grafiklerin iki değer ekseni olduğundan X değerleri için yatay, Y değerleri için dik eksen ya da her ikisi kullanılabilir. Kategori eksenine logaritmik ölçek uygulamayın.

Varsayılan logaritmik taban `10` dır. PPTX grafiklerde `2`‑`1000` aralığında (dahil) bir taban kullanılabilir; `2.5` gibi kesirli tabanlar da desteklenir. Tabana `10` verirseniz 10, 100, 1 000, 10 000 gibi ardışık güçler eşit aralıkta yer alır.

### **Doğrusal ve Logaritmik Ölçeklendirmeyi Karşılaştırın**

Aşağıdaki örnek, ilk slaytta beş istek sayısını gösteren bir çizgi grafiği oluşturur, ardından bu slaytı kopyalar ve ikinci slaytta taban‑10 logaritmik değer eksenini etkinleştirir. İki slayt da aynı veriyi korur.

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

**Doğrusal ölçek (slayt 1):** Eşit dik mesafeler eşit istek sayısı farklarını temsil eder. En büyük değer grafiği domine eder, küçük değerleri ayırt etmeyi zorlaştırır.

![Doğrusal değer ekseninde beş istek sayısı gösteren PowerPoint'teki çizgi grafiği](value-axis-linear.png)

**Logaritmik ölçek (slayt 2):** Eşit dik mesafeler eşit oranları temsil eder. Her dönem bir öncekinin on katı istek alır; bu yüzden noktalar taban‑10 ölçeğinde düz bir yükselen çizgi oluşturur. Ekseni etiketleri hâlâ orijinal istek sayılarını gösterir.

![PowerPoint'te aynı beş istek sayısı temel-10 logaritmik değer ekseni üzerinde](value-axis-logarithmic.png)

### **Sıfır ve Negatif Değerleri İşleyin**

Logaritmik ölçek yalnızca kesinlikle pozitif değerleri gösterebilir. Etkinleştirmeden önce verileri kontrol edin. Sıfır ya da negatif değerler anlamlıysa doğrusal ölçek kullanın ya da bunları ayrı olarak gösterin. Bu değerleri dışlamak analiz için uygun ise nedeni açıklayın. Küçük pozitif sayılarla sessizce değiştirmeyin; bu veri anlamını değiştirir. Logaritmik eksen için manuel olarak ayarlanan minimum ya da maksimum değer de pozitif olmalıdır.

## **SSS**

**Bir eksenin diğerini kestiği değeri (ekseni kesişim) nasıl ayarlarım?**

[setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) metodunu kullanarak kesişim davranışını seçin. Sayısal bir kesişim değeri belirtmek için [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-) metodunu kullanın. Bu ayarlar, eksen kesişimini uygun bir temel çizgiye taşımanızı sağlar.

**İşaretçi etiketlerini eksene göre nasıl konumlandırabilirim?**

[setTickLabelPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTickLabelPosition-int-) metodunu [TickLabelPositionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ticklabelpositiontype/) ile `Low`, `High`, `NextTo` veya `None` olarak çağırın. İşaretçi işaretçiklerini kontrol etmek için [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) ya da [setMinorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMinorTickMark-int-) metodlarını kullanın; bunlar etiket konumlandırmadan ayrı olarak değerlendirilir.