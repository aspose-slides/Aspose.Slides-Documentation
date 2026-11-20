---
title: Android'de Sunumlarda Grafik Eksenlerini Özelleştirme
linktitle: Grafik Ekseni
type: docs
url: /tr/androidjava/chart-axis/
keywords:
- grafik ekseni
- dikey eksen
- yatay eksen
- ekseni özelleştir
- ekseni manipüle et
- ekseni yönet
- eksen özellikleri
- maksimum değer
- minimum değer
- eksen çizgisi
- tarih biçimi
- eksen başlığı
- eksen konumu
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Raporlar ve görselleştirmeler için PowerPoint sunumlarında grafik eksenlerini özelleştirmek üzere Aspose.Slides for Android via Java kullanımını keşfedin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Android via Java ile grafik eksenlerini nasıl özelleştireceğinizi açıklar. Hesaplanan eksen değerleri, grafik satır ve sütunlarının değiştirilmesi, eksen görünürlüğü, kategori etiketi ve çentik aralıkları, tarih kategorileri ve biçimlendirme, başlık dönüşü, eksen konumlandırma, görüntü birimleri ve logaritmik ölçeklendirme konularını kapsar.

## **Grafiklerde Dikey Eksende Maksimum Değerleri Al**

Bir [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) oluşturun ve varsayılan veri ile bir alan grafiği ekleyin. Hesaplanan eksen değerlerini okumadan önce grafik düzeninin güncel olmasını sağlamak için [validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--) çağırın.

Eksen limitleri için [getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMaxValue--) ve [getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinValue--) metodlarını, çentik aralıkları için ise [getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnit--) ve [getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnit--) metodlarını okuyun. Tarih eksenleriyle ilgili olan zaman birimi ölçeklerini sağlamak için [getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnitScale--) ve [getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnitScale--) kullanılır. Örnek bu değerleri yerel değişkenlerde saklar ve grafiği kaydeder.

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

## **Eksenler Arasındaki Verileri Değiştir**

[swapRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) kullanarak grafik verilerinde seriler ve kategorilerin rollerini değiştirin. Her eski kategori bir seri, her eski seri ise bir kategori olur. Bu, verilerin gruplanma şeklini değiştirir; yatay ve dikey eksenleri değiştirmez. Örnek, satır ve sütunları değiştirmeden önce varsayılan verileri `Sheet1!A1:D5` adresine bağlamak için [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setRange-java.lang.String-) metodunu kullanır. Dört seri ve üç kategori içeren bir grafik kaydeder.

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

## **Bir Eksenin Çizim Sırasını Ters Çevir**

[setPlotOrderReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setPlotOrderReversed-boolean-) metodunu kullanarak bir kategori ya da değer ekseninin sırasını tersine çevirin. Örneğin, yatay çubuk grafik, proje aşamalarını çalışma sayfasındaki aynı sırada üstten alta (Planlama, Geliştirme, Test) gösterebilir. Bir ekseni tersine çevirmek çizim yönünü değiştirir; çalışma kitabı verilerini sıralamaz veya yeniden düzenlemez. Karşılaştırma olarak, [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) seriler ve kategorilerin rollerini değiştirir.

Aşağıdaki örnek, üç aşama ve bir seri içeren bir yatay çubuk grafik oluşturur. Normal sırada, ters kategori ve ters değer ekseninde olmak üzere üç slayt kaydeder. Her kopya aynı veri kümesini kullanır ve sadece bir eksen ters çevrilir.

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

    // Slayt 3: yalnızca yatay sayısal ölçeği ters çevir.
    ISlide valueSlide = presentation.getSlides().addClone(slide);
    IChart valueChart = (IChart)valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ters bir eksen, dik ekseni de grafiğin karşı tarafına taşıyabilir. [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) diğer eksenin konfigüre edilen ekseni nerede kestiğini kontrol eder. 2. slaytta, ters kategori ekseninde `CrossesType.Maximum` ile çağırmak, yatay değer eksenini altta tutar. Belirli bir kesişim noktası için [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-) kullanın. Yön değiştirilirken kesişim ayarlarını kontrol edin, özellikle grafik zaten özel bir kesişim noktasına sahipse. Normal çizim yönünü geri yüklemek için `setPlotOrderReversed` metodunu `false` ile çağırın; kesişim ayarları ayrı tutulur.

| Normal sıra (slayt 1) | Ters kategoriler (slayt 2) | Ters değerler (slayt 3) |
| --- | --- | --- |
| ![Normal kategori ve değer ekseni sırasıyla yatay çubuk grafik](axis-order-normal.png) | ![Kategorileri üstten alta gösteren yatay çubuk grafik](axis-order-categories-reversed.png) | ![Ters değer ekseni ve sağda sıfırla yatay çubuk grafik](axis-order-values-reversed.png) |
| Kategoriler alt taraftan üst tarafa doğru; değerler soldan sağa artar. | Planlama, Geliştirme ve Test üstten alta doğru. Değerler ve çalışma kitabı satır sırası değişmez. | Kategoriler normal sıralarını korur; değerler sağdan sola artar. Kategori ekseni sağdaki sıfırda kesişir. |

## **Çizgi Grafiklerde Dikey Ekseni Devre Dışı Bırak**

Dikey ekseni gizlemek için `false` ile [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) metodunu çağırın. Örnek, varsayılan veri ile bir çizgi grafik oluşturur ve dik ekseni gizli olarak kaydeder.

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

## **Çizgi Grafiklerde Yatay Ekseni Devre Dışı Bırak**

Yatay ekseni gizlemek için `false` ile [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) metodunu çağırın. Örnek, varsayılan veri ile bir çizgi grafik oluşturur ve yatay ekseni gizli olarak kaydeder.

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

## **Grafik Izgara Çizgilerini Göster veya Gizle**

Bir eksenin hangi ızgara çizgilerini gösterdiğini kontrol etmek için [getShowMajorGridLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getShowMajorGridLines--) ve [getShowMinorGridLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getShowMinorGridLines--) metodlarını çağırın. Bu metodlar geçerli görünürlüğü raporlar. Küçük ızgara çizgilerini göstermek için [getMinorGridLinesFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getMinorGridLinesFormat--) metodunu elde edip satır doldurmasını katı, görünür bir renge ayarlayın. Gizlemek için doldurmayı [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/#NoFill) olarak ayarlayın. Ana ızgara çizgileri için aynı şekilde satır doldurmasını değiştirmek üzere [getMajorGridLinesFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getMajorGridLinesFormat--) metodunu kullanın. Doldurmayı değiştirmek eksen görünürlüğünü ve çentik işaretlerini korur.

Bu kümelenmiş sütun grafiğinin dik ekseni başlangıçta yalnızca ana ızgara çizgilerini gösterir. Örnek, küçük ızgara çizgilerini koyu turuncu olarak gösterir, ardından tekrar gizler ve sunumu kaydeder. Her adımda ızgara çizgisi görünürlüğünü yazdırır.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 30, 660, 230);
    IAxis axis = chart.getAxes().getVerticalAxis();
    System.out.printf("Initial: major=%b, minor=%b%n", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    ILineFillFormat minorFill = axis.getMinorGridLinesFormat().getLine().getFillFormat();
    minorFill.setFillType(FillType.Solid);
    minorFill.getSolidFillColor().setColor(Color.rgb(255, 140, 0));
    System.out.printf("Enabled: minor=%b%n", axis.getShowMinorGridLines());

    minorFill.setFillType(FillType.NoFill);
    System.out.printf("Hidden: major=%b, minor=%b%n", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    presentation.save("ChartGridlines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Küçük ızgara çizgileri etkin | Küçük ızgara çizgileri gizli |
| --- | --- |
| ![Dikey eksende ana ızgara çizgileri arasında turuncu küçük ızgara çizgileri](minor-gridlines-enabled.png) | ![Sadece ana ızgara çizgileri görünür aynı sütun grafik](minor-gridlines-hidden.png) |

## **Bir Kategori Ekseni Değiştir**

[setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) metodunu kullanarak tarih ya da metin kategori ekseni seçin. Bu örnek, `ExistingChart.pptx` dosyasını gerektirir; grafik ilk slayttaki ilk şekil olup kategori hücreleri sayısal Excel tarih değerleri içerir. Yatay ekseni bir tarih ekseni haline getirir. [setAutomaticMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) metodunu `false`, [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnit-double-) metodunu `1` ve [setMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnitScale-int-) metodunu `TimeUnitType.Months` olarak ayarlamak, ana çentikleri bir‑aylık aralıklarla yerleştirir.

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

### **Veriden Kategori Ekseni Türünü Belirle**

Kategorileri doldurduktan sonra [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setCategoryAxisTypeAutomatically--) metodunu çağırın, ardından seçimi incelemek için [getCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getCategoryAxisType--) metodunu okuyun. Bu, aynı grafik hem metin etiketleri hem de sayısal tarih değerleri aldığında yararlıdır. Metod, çağrıldığı anda türü belirler; daha sonra veri değişikliklerini yeniden değerlendiren kalıcı bir mod etkinleştirmez. Kategorileri değiştirince tekrar çağırın.

Aşağıdaki örnek, metin kategorileri içeren bir grafik oluşturur ve seçilen tür `CategoryAxisType.Text` olduğunda `true` yazdırır. Ardından kategori hücre değerlerini tarihlere değiştirir ve metodu tekrar çağırarak seçilen tür `CategoryAxisType.Date` olduğunda `true` yazdırır. Tarihler, 30 Aralık 1899’dan itibaren geçen gün sayısı olarak sayısal OLE Automation değerleriyle saklanır; tarih dizesi olarak değil. Her iki takvim de UTC kullanır ve tarih ayarlarından önce temizlenir; böylece yaz saati uygulaması ve günün saati hesabı etkilemez. [setCustomNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) değerlerin nasıl gösterileceğini kontrol eder; metni sayısal tarihlere dönüştürmez. Kategori hücreleri hakkında daha fazla bilgi için [Chart Workbook](/slides/tr/androidjava/chart-workbook/) sayfasına bakın.

Girişin yalnızca metin kategorileri veya sayısal tarihler içerdiği biliniyorsa otomatik belirlemeyi kullanın. Normal sayısal etiketler, karışık kategoriler veya boş veri durumunda, istenen anlamı yansıtmak için açıkça [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setCategoryAxisType-int-) metodunu çağırın. Sadece sayısal değerler, kategorilerin tarih olduğunu kanıtlamaz.

```java
import com.aspose.slides.*;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.TimeZone;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell seriesName = workbook.getCell(0, 0, 1, "Sales");
    IChartSeries series = chart.getChartData().getSeries().add(seriesName, chart.getType());
    String[] labels = { "First", "Second", "Third" };

    for (int i = 0; i < labels.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, labels[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, (i + 1) * 10);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    IAxis axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisTypeAutomatically();
    System.out.println(axis.getCategoryAxisType() == CategoryAxisType.Text); // doğru

    TimeZone timeZone = TimeZone.getTimeZone("UTC");
    Calendar baseDate = new GregorianCalendar(timeZone);
    baseDate.clear();
    baseDate.set(1899, Calendar.DECEMBER, 30);
    int[][] dates = { { 2026, Calendar.JANUARY, 1 }, { 2026, Calendar.JANUARY, 2 }, { 2026, Calendar.FEBRUARY, 1 } };

    for (int i = 0; i < dates.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0);
        Calendar date = new GregorianCalendar(timeZone);
        date.clear();
        date.set(dates[i][0], dates[i][1], dates[i][2]);
        double serialDate = (date.getTimeInMillis() - baseDate.getTimeInMillis()) / 86400000.0;
        categoryCell.setValue(serialDate);
        categoryCell.setCustomNumberFormat("yyyy-mm-dd");
    }

    axis.setCategoryAxisTypeAutomatically();
    System.out.println(axis.getCategoryAxisType() == CategoryAxisType.Date); // doğru

    presentation.save("AutomaticCategoryAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kategori Ekseni Etiket Aralıklarını Kontrol Et**

Bir grafikte çok sayıda kategori olduğunda, kategori ve veri noktalarını kaldırmadan eksen etiketlerinin görünür sayısını azaltın. [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) metodunu `false` ile çağırın, ardından istenen kategori aralığını [setTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickLabelSpacing-long-) metoduna aktarın. Normal sıradaki metin kategorileri için sayım ilk kategoriden başlar:

| Interval | Labels displayed in the example |
| --- | --- |
| `1` | Kategori 1, Kategori 2, Kategori 3, ... Kategori 24 |
| `2` | Kategori 1, Kategori 3, Kategori 5, ... Kategori 23 |
| `3` | Kategori 1, Kategori 4, Kategori 7, ... Kategori 22 |

`3` aralığı, her üçüncü etiketi gösterir; gösterilen etiketler arasında iki etiket gizli kalır. İlgili sütunları kaldırmaz. Otomatik aralık, mevcut alana göre bir değer seçer; her zaman tüm etiketleri göstermez.

Çentik işaretlerinin ayrı kontrolleri vardır. [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) metodunu `false` yapın ve aralıklarını belirlemek için [setTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) metodunu kullanın. Örneğin, `1` her kategori aralığında bir çentik işareti tutar; etiketler yalnızca her üçüncü kategoride görünür. Görünür bir stil ayarlamak için [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorTickMark-int-) metodunu kullanın. Otomatik‑aralık ayarını tekrar `true` yaparsanız grafik yeniden o aralığı seçer.

Aşağıdaki bağımsız örnek, 24 kategori ve bir seri oluşturur, ardından `CategoryAxisIntervals.pptx` içinde üç slayt kaydeder: otomatik aralık, bağımsız çentik işaretli manuel etiket aralığı ve otomatik aralığa geri dönüş. İki kopya orijinal grafik verisini korur. Giriş sunumu gerekmez. Yatay etiket metni, yoğunluk farkını net görmeyi sağlar.

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

    // Slayt 2: her üçüncü etiketi göster, ancak her kategori için bir çentik işareti tut.
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

**Otomatik aralık (slayt 1):** Bu oluşturulmada her ikinci kategori etiketi gösterilir ve iki satıra kaydırılır. Otomatik sonuç grafik boyutu, font ve işleyiciye göre değişebilir.

![Tüm 24 sütun görünürken otomatik kategori etiketi aralığı](category-axis-automatic.png)

**Manuel aralık (slayt 2):** Her üçüncü etiket tek satırda gösterilir, çentik işaretleri ise her kategori aralığında kalır. Etiketi olmayan tüm 24 sütun aynı değerlerle görünür. 3. slayt, yukarıdaki otomatik görünüme geri döner.

![Üçlü manuel kategori etiketi aralığı, tüm 24 sütun görünür](category-axis-manual.png)

### **Doğru Ekseni ve Aralığı Seç**

Bu kategori‑sayımı aralığını, bir metin kategori ekseni (ör. sütun, çizgi, alan ya da çubuk grafiğin kategori ekseni) için kullanın. Sütun grafiğinde yatay eksen, yatay çubuk grafiğinde ise kategori ekseni dikeydir; bu ayarları [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--) ile dönen eksene uygulayın. Çentik aralığı ayrıca bir serinin eksenine de uygulanabilir.

Kategori etiketi aralığını bir değer ekseninin sayısal ölçeğini ayarlamak için kullanmayın. Değer ekseninde, [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorUnit-double-) bir değer farkı belirtir: ör. `10` bir birim, eksen sıfırdan başlıyorsa 0, 10, 20 … gibi çentik üretir. `3` kategori etiketi aralığı yalnızca kategori konumlarını sayar, veri değerlerini dikkate almaz. Dağılım ve balon grafikler bir metin kategori ekseni yerine değer eksenleri kullanır. Tarih ekseni için, [Change a Category Axis](#change-a-category-axis) bölümünde açıklandığı gibi zaman‑bazlı büyük birimler ve ölçekler kullanın.

## **Kategori Ekseni Değerleri İçin Tarih Biçimini Ayarla**

Örnek, varsayılan grafik verilerini dört yıllık değerle değiştirir. Tarihler, ilk çalışma sayfasında (indeks `0`) OLE Automation seri numaraları olarak saklanır; bu, ilgili tarihler için 30 Aralık 1899’dan itibaren geçen gün sayısıdır. Her iki takvim de UTC kullanır ve tarih ayarlarından önce temizlenir; böylece yaz saati ve günün saati hesabı etkilenmez. [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) metodunu `CategoryAxisType.Date` ile, [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) metodunu `false` ve [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) metoduna `yyyy` geçirerek, kategori etiketlerinin hücre biçiminden bağımsız olarak dört basamaklı yıl göstermesini sağlayın.

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

## **Grafik Ekseni Başlığı İçin Döndürme Açısı Ayarla**

Dikey eksende başlığı etkinleştirmek için [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTitle-boolean-) metodunu `true` yapın, başlık metnini sağlayın ve başlığı döndürmek için [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) metodunu kullanın. Açı derece cinsindendir; bu örnek, değer ekseni başlığını 90 derece döndürerek bir sütun grafik kaydeder.

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

## **Kategori veya Değer Ekseninde Ekseni Konumlandır**

[setAxisBetweenCategories](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) metodunu kullanarak değer ekseninin kategori eksenini kategori aralıkları arasında mı yoksa kategori çentik işaretlerinde mi keseceğini kontrol edin. Bu ayar sadece kategori eksenlerine uygulanır. Örnek, bir sütun grafiğinin yatay kategori ekseninde bu ayarı `true` yapar ve sonucu kaydeder.

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

## **Grafik Değer Ekseninde Görüntü Birimini Ayarla**

[setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setDisplayUnit-int-) metodunu kullanarak bir değer eksenindeki etiketleri veriyi değiştirmeden ölçekleyin. [DisplayUnitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/displayunittype/) `Millions` olarak ayarlandığında, 60 000 000 değeri 60 olarak görünür. Örnek, bir sütun grafik oluşturur ve dik eksenine milyon görüntü birimini uygular.

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

## **Logaritmik Değer Eksenini Yapılandır**

Pozitif değerler birkaç mertebe fark ediyor ise logaritmik değer ekseni faydalıdır. Örneğin bir hizmet beş dönemde 10, 100, 1 000, 10 000 ve 100 000 istek alabilir. Doğrusal ölçekte küçük değerler sıfıra yakın bir aralıkta toplanır. Logaritmik ölçek, göreli büyümeyi karşılaştırmayı kolaylaştırır: eşit mesafeler eşit oranları temsil eder, eşit farkları değil.

Değer ekseninde [setLogarithmic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogarithmic-boolean-) metodunu `true` ve [setLogBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogBase-double-) metodunu baz seçerek çağırın. Bu, mevcut değerlerin gösterilme biçimini değiştirir; veri kendisini değiştirmez veya logaritmik bir trend çizgisi eklemez. Trend çizgisi, verideki bir ilişkiyi uydurur ve ayrı bir özelliktir.

### **Değer Eksenini ve Tabanı Seç**

Çizgi veya sütun grafiğinde değer ekseni, [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--) ile döner. Yatay çubuk grafiğinde ise [getHorizontalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getHorizontalAxis--) döner. Dağılım ve balon grafiklerde iki değer ekseni olur; X değerleri için yatay, Y değerleri için dik eksen veya her ikisi de seçilebilir. Kategori eksenine logaritmik ölçek uygulamayın.

Varsayılan logaritmik taban `10`dır. PPTX grafiklerde taban `2` ile `1000` arasında (dahil) kullanılabilir; `2.5` gibi kesirli tabanlar da desteklenir. Tabana `10` verildiğinde, 10, 100, 1 000, 10 000 gibi art arda gelen güçler eşit aralıkta olur.

### **Doğrusal ve Logaritmik Ölçeklendirmeyi Karşılaştır**

Aşağıdaki bağımsız örnek, ilk slaytta beş istek sayısını içeren bir çizgi grafik oluşturur, ardından bu slaytı kopyalar ve ikinci slaytta taban‑10 logaritmik değer eksenini etkinleştirir. Her iki slayt da aynı veriyi korur.

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

    // İlk slaytı doğrusal tut ve yalnızca kopyanın değer ekseni ölçeğini değiştir.
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

**Doğrusal ölçek (slayt 1):** Eşit dik mesafeler, istek sayılarındaki eşit farkları temsil eder. En büyük değer grafiği hâkim kılar, küçük değerler ayırt edilemez.

![Doğrusal değer ekseninde beş istek sayısını gösteren PowerPoint'te çizgi grafik](value-axis-linear.png)

**Logaritmik ölçek (slayt 2):** Eşit dik mesafeler eşit oranları temsil eder. Her dönem bir öncekinin on katı istek alır; noktalar taban‑10 ölçeğinde düz bir yükselen çizgi oluşturur. Ekseni etiketleri hâlâ orijinal istek sayısını gösterir.

![PowerPoint'te aynı beş istek sayısı, 10 tabanlı logaritmik değer ekseninde](value-axis-logarithmic.png)

### **Sıfır ve Negatif Değerleri İşle**

Logaritmik ölçek yalnızca kesin pozitif değerleri gösterebilir. Etkinleştirmeden önce veriyi kontrol edin. Sıfır ya da negatif değerler anlamlıysa doğrusal ölçek kullanın veya ayrı olarak gösterin. Eğer bu değerleri analizden dışlamak uygun ise, eksikliğin nedenini açıklayın. Küçük pozitif sayılarla sessizce değiştirmeyin; bu, verinin anlamını değiştirir. Logaritmik eksen için el ile ayarlanan minimum ya da maksimum da pozitif olmalıdır.

## **SSS**

**Bir eksenin diğerini kestiği değeri (ekseni kesişim) nasıl ayarlarım?**

Kesişme davranışını seçmek için [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) metodunu kullanın. Sayısal bir kesişme değeri belirtmek için [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-) metodunu kullanın. Bu ayarlar, eksen kesişimini uygun bir temel üzerine taşımanıza izin verir.

**Çentik etiketlerini eksene göre nasıl konumlandırabilirim?**

[setTickLabelPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTickLabelPosition-int-) metodunu [TickLabelPositionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ticklabelpositiontype/) `Low`, `High`, `NextTo` veya `None` değerleriyle çağırın. Çentik işaretlerini kontrol etmek için ayrı olarak [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) ya da [setMinorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMinorTickMark-int-) metodlarını kullanın; bunlar etiket konumlandırmadan bağımsızdır.