---
title: Java Kullanarak Sunumlarda Grafik Eksenlerini Özelleştirme
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
- azami değer
- asgari değer
- eksen çizgisi
- tarih biçimi
- eksen başlığı
- eksen konumu
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Raporlar ve görselleştirmeler için PowerPoint sunumlarında grafik eksenlerini özelleştirmek amacıyla Aspose.Slides for Java'nın nasıl kullanılacağını keşfedin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Java ile grafik eksenlerini nasıl özelleştireceğinizi açıklar. Hesaplanmış eksen değerleri, grafik satır ve sütunlarının değiştirilmesi, eksen görünürlüğü, kategori etiketi ve işaret aralığı, tarih kategorileri ve biçimlendirmesi, başlık dönüşü, eksen konumlandırması, gösterim birimleri ve logaritmik ölçeklendirme konularını kapsar.

## **Dikey Eksenin En Büyük Değerlerini Almak**

[Sunum](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) oluşturun ve varsayılan veriyle bir alan grafiği ekleyin. Hesaplanmış eksen değerlerini okumadan önce grafiğin düzeninin güncel olmasını sağlamak için [validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#validateChartLayout--) çağırın.

Eksen sınırları için [getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMaxValue--) ve [getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinValue--) okuyun; işaret aralıkları için [getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnit--) ve [getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnit--) kullanın. Tarih eksenleriyle ilgili zaman birimi ölçekleri için [getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnitScale--) ve [getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnitScale--) sağlanır. Örnek bu değerleri yerel değişkenlerde saklar ve grafiği kaydeder.

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

Grafik verilerinde seriler ve kategorilerin rollerini değiştirmek için [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) kullanın. Her eski kategori bir seri, her eski seri ise bir kategori olur. Bu, verilerin nasıl gruplanacağını değiştirir; yatay ve dikey eksenleri değiştirmez. Örnek, satır ve sütunları değiştirmeden önce varsayılan veriyi `Sheet1!A1:D5` adresine (başlık satırı ve kategori sütunu dahil) bağlamak için [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setRange-java.lang.String-) kullanır. Dört seri ve üç kategori içeren bir grafik kaydeder.

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

## **Bir Eksenin Çizim Sırasını Tersine Çevirmek**

Bir kategori veya değer eksenini tersine çevirmek için [setPlotOrderReversed](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setPlotOrderReversed-boolean-) kullanın. Örneğin, yatay çubuk grafiği proje aşamalarını çalışma sayfasındaki aynı sırayla (Planlama, Geliştirme, Test) üstten alta gösterebilir. Eksenin tersine çevrilmesi çizim yönünü değiştirir; çalışma kitabı verilerini sıralamaz veya yeniden düzenlemez. Karşılaştırma olarak, [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) seriler ve kategorilerin rollerini değiştirir.

Aşağıdaki örnek üç aşamalı bir yatay çubuk grafiği oluşturur ve üç slayt kaydeder: normal sıra, ters kategoriler ve ters değerler. Her kopya aynı veri kümesini kullanır ve her kopyada yalnızca bir eksen tersine çevrilir.

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

Bir ekseni tersine çevirmek, dik ekseni grafiğin karşı tarafına taşıyabilir. [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) diğer eksenin ayarlanan ekseni nerede kestiğini belirler. 2. slaytta, ters kategori ekseninde `CrossesType.Maximum` ile çağırmak, yatay değer eksenini altta tutar. Belirli bir kesişim noktası için [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-) kullanın. Yön değiştirirken kesişim ayarlarını kontrol edin, özellikle grafik zaten özel bir kesişim noktasına sahipse. Normal çizim yönünü geri getirmek için `setPlotOrderReversed`’ı `false` yapın; kesişim ayarları ayrı bir özelliktir.

| Normal sıra (slayt 1) | Ters kategoriler (slayt 2) | Ters değerler (slayt 3) |
| --- | --- | --- |
| ![Normal kategori ve değer ekseni sırasına sahip yatay çubuk grafik](axis-order-normal.png) | ![Kategoriler üstten alta görüntülenen yatay çubuk grafik](axis-order-categories-reversed.png) | ![Sağda sıfır kesişimi olan ters değer eksenli yatay çubuk grafik](axis-order-values-reversed.png) |
| Kategoriler alt'tan üst'e; değerler soldan sağa artar. | Planlama, Geliştirme ve Test üstten alta. Değerler ve çalışma kitabı satır sırası aynı kalır. | Kategoriler normal sırada; değerler sağdan sola artar. Kategori ekseni sağdaki sıfırda kesişir. |

## **Çizgi Grafiklerinde Dikey Eksen'i Devre Dışı Bırakma**

Dikey ekseni gizlemek için `false` ile [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) çağırın. Örnek, varsayılan veriyle bir çizgi grafiği oluşturur ve dik ekseni gizli şekilde kaydeder.

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

## **Çizgi Grafiklerinde Yatay Eksen'i Devre Dışı Bırakma**

Yatay ekseni gizlemek için `false` ile [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) çağırın. Örnek, varsayılan veriyle bir çizgi grafiği oluşturur ve yatay ekseni gizli şekilde kaydeder.

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

[setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) kullanarak tarih veya metin kategori ekseni seçin. Bu örnek, ilk slayttaki ilk şekil olarak bir grafik içeren `ExistingChart.pptx` dosyasını gerektirir ve kategori hücrelerinde sayısal Excel tarih değerleri bulunur. Yatay ekseni tarih ekseni yapar. [setAutomaticMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) `false`, [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnit-double-) `1` ve [setMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnitScale-int-) `TimeUnitType.Months` ile ana işaretleri bir‑ay aralıklarla yerleştirir.

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

Grafiğinizde birçok kategori varsa, kategorileri veya veri noktalarını kaldırmadan görünür eksen etiketlerinin sayısını azaltın. [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) `false` yapın, ardından istenen kategori aralığını [setTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickLabelSpacing-long-) ile belirtin. Normal sıradaki metin kategorileri için sayma ilk kategoriden başlar:

| Aralık | Örnekte gösterilen etiketler |
| --- | --- |
| `1` | Kategori 1, Kategori 2, Kategori 3, … Kategori 24 |
| `2` | Kategori 1, Kategori 3, Kategori 5, … Kategori 23 |
| `3` | Kategori 1, Kategori 4, Kategori 7, … Kategori 22 |

`3` aralığı her üçüncü etiketi gösterir, iki etiket gizlenir. İlgili sütunlar kaldırılmaz. Otomatik aralık, mevcut alana göre bir değer seçer; her etiketi mutlaka göstermez.

İşaretçikler ayrı olarak kontrol edilir. [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) `false` yapın ve [setTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) ile aralıklarını ayarlayın. Örneğin, `1` her kategori aralığında bir işaretçi bırakırken etiketler sadece her üçüncü kategoride görünür. Görünür bir stil için [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorTickMark-int-) kullanın. Otomatik‑aralık ayarını tekrar `true` yaparsanız grafik yeniden otomatik seçim yapar.

Aşağıdaki bağımsız örnek 24 kategori ve bir seri oluşturur, ardından `CategoryAxisIntervals.pptx` içinde üç slayt kaydeder: otomatik aralık, bağımsız işaretçikli manuel etiket aralığı ve otomatik aralığın geri yüklenmesi. İki kopya orijinal grafik verisini korur. Giriş sunumu gerekmez. Yatay etiket metni yoğunluk farkını net gösterir.

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

    // Slayt 3: grafiğin iki aralığı da yeniden seçmesine izin ver.
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Otomatik aralık (slayt 1):** Bu görüntüde her ikinci kategori etiketi gösterilir ve iki satıra kayar. Otomatik sonuç grafik boyutu, font ve işleyiciye göre değişebilir.

![Tüm 24 sütun görünürken otomatik kategori etiketi aralığı](category-axis-automatic.png)

**Manuel aralık (slayt 2):** Her üçüncü etiket tek satırda gösterilir, işaretçiler ise her kategori aralığında kalır. Etiketi olmayan tüm 24 sütun aynı değerlerle görünür. Slayt 3, yukarıdaki otomatik görünümü geri yükler.

![Tüm 24 sütun görünürken üçer etiket aralıklı manuel kategori etiketi](category-axis-manual.png)

### **Doğru Eksen ve Aralığı Seçme**

Metin kategori ekseni kullanan sütun, çizgi, alan veya çubuk grafiklerde bu kategori‑sayım aralığını uygulayın. Sütun grafiğinde yatay eksen, yatay çubuk grafiğinde ise kategori ekseni dik eksen olduğundan, ayarları [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--) ile alınan eksene uygulayın. İşaretçi aralığı, bir serinin ekseni olan grafiklerde de geçerlidir.

Değer ekseninin sayısal ölçeğini kategori etiketi aralığıyla ayarlamaya çalışmayın. Değer ekseninde [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorUnit-double-) bir değer farkı belirtir: örneğin `10` birim, eksen sıfırdan başlıyorsa 0, 10, 20 … işaretleri üretir. `3` kategori etiketi aralığı yalnızca kategori konumlarını sayar, veri değerlerine bakmaz. Dağılım ve balon grafikler metin kategori ekseni yerine değer eksenleri kullanır. Tarih ekseni için, [Change a Category Axis](#change-a-category-axis) bölümünde açıklandığı gibi zaman temelli birimler ve ölçekler kullanın.

## **Kategori Eksen Değerleri için Tarih Biçimini Ayarlama**

Örnek, varsayılan grafik verisini dört yıllık değerle değiştirir. Tarihler, ilk çalışma sayfasında (indeks `0`) OLE Automation seri numaraları olarak saklanır; bu sayılar 30 Aralık 1899’dan itibaren geçen gün sayısıdır. [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) `CategoryAxisType.Date` ile ayarlayın, [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) `false` yapın ve [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) `yyyy` gönderin; böylece kategori etiketleri hücre biçiminden bağımsız olarak dört basamaklı yıl gösterir.

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

## **Grafik Eksen Başlığı için Döndürme Açısını Ayarlama**

Dikey eksende [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTitle-boolean-) `true` ile başlık etkinleştirin, başlık metnini sağlayın ve [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) ile başlığı döndürün. Açı derece cinsindendir; bu örnek, değer ekseni başlığını 90 derece döndürülmüş bir sütun grafiği kaydeder.

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

## **Kategori veya Değer Ekseni Üzerinde Eksen Konumunu Ayarlama**

[setAxisBetweenCategories](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) kullanarak değer ekseninin kategori eksenini kategori işaretçileri arasında mı yoksa işaretçilerin üzerinde mi keseceğini kontrol edin. Bu ayar yalnızca kategori eksenlerine uygulanır. Örnek, bir sütun grafiğinin yatay kategori ekseninde bunu `true` yapar ve sonucu kaydeder.

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

## **Grafik Değer Ekseninde Gösterim Birimini Ayarlama**

[setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setDisplayUnit-int-) kullanarak bir değer eksenindeki etiketleri veri değişmeden ölçeklendirin. [DisplayUnitType](https://reference.aspose.com/slides/java/com.aspose.slides/displayunittype/) `Millions` olarak ayarlandığında 60 000 000 değeri 60 olarak görüntülenir. Örnek, bir sütun grafiği oluşturur ve dik eksenine milyon gösterim birimini uygular.

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

Pozitif değerler birkaç mertebe arasında değişiyorsa logaritmik değer ekseni faydalıdır. Örneğin, bir hizmet beş dönemde 10, 100, 1 000, 10 000 ve 100 000 istek alabilir. Doğrusal ölçekte küçük değerler sıfıra yakın bir arada görünür. Logaritmik ölçek, eşit mesafelerin eşit oranları temsil etmesini sağlar; fark değil oran temsil edilir.

Değer ekseninde [setLogarithmic](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogarithmic-boolean-) `true` yapın ve tabanı seçmek için [setLogBase](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogBase-double-) kullanın. Bu, mevcut değerlerin nasıl gösterileceğini değiştirir; veri ya da logaritmik trend çizgisi eklemez. Trend çizgisi, verideki bir ilişkiyi modelleyen ayrı bir özelliktir.

### **Değer Ekseni ve Tabanı Seçme**

Çizgi veya sütun grafiğinde değer ekseni [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--) ile alınır. Yatay çubuk grafiğinde [getHorizontalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getHorizontalAxis--) döner. Dağılım ve balon grafiklerde iki değer ekseni bulunduğundan, X değerleri için yatay, Y değerleri için dik eksen ya da her ikisi seçilebilir. Kategori eksenine logaritmik ölçek uygulamayın.

Varsayılan logaritmik taban `10` dur. PPTX grafiklerinde taban `2`‑`1000` arasında olabilir; `2.5` gibi kesirli tabanlar da desteklenir. Tabana `10` konulduğunda 10, 100, 1 000, 10 000 gibi ardışık katlar eşit aralıkta olur.

### **Doğrusal ve Logaritmik Ölçekleme Karşılaştırması**

Aşağıdaki bağımsız örnek, ilk slaytta beş istek sayısını gösteren bir çizgi grafiği oluşturur, ardından bu slaytı kopyalar ve ikinci slaytta taban‑10 logaritmik değer ekseni etkinleştirir. Her iki slayt da aynı veriyi korur.

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

**Doğrusal ölçek (slayt 1):** Eşit dik mesafeler istek sayısındaki eşit farkları gösterir. En büyük değer grafiği domine eder, küçük değerler ayırt edilemez.

![Doğrusal değer ekseninde beş istek sayısını gösteren PowerPoint çizgi grafiği](value-axis-linear.png)

**Logaritmik ölçek (slayt 2):** Eşit dik mesafeler eşit oranları temsil eder. Her dönem bir öncekinin on katı istek alır; bu yüzden noktalar taban‑10 ölçeğinde düz bir yükselen çizgi oluşturur. Eksende hâlâ orijinal istek sayıları gösterilir.

![PowerPoint’te taban‑10 logaritmik değer ekseninde aynı beş istek sayısı](value-axis-logarithmic.png)

### **Sıfır ve Negatif Değerleri Yönetme**

Logaritmik ölçek yalnızca kesin pozitif değerleri gösterir. Etkinleştirmeden önce veriyi kontrol edin. Sıfır veya negatif değerler anlamlıysa doğrusal ölçek kullanın veya ayrı olarak gösterin. Bu değerleri dışlamak analiz için uygun ise çıkarma sebebini açıklayın. Küçük pozitif sayılarla gizlice değiştirmeyin; bu veri anlamını değiştirir. Logaritmik eksen için manuel olarak ayarlanan minimum veya maksimum da pozitif olmalıdır.

## **SSS**

**Bir eksenin diğerini nerede kestiği (ekseni kesişimi) nasıl ayarlanır?**

Kesişme davranışını seçmek için [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) kullanın. Sayısal bir kesişme değeri belirtmek için [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-) kullanın. Bu ayarlar eksen kesişimini uygun bir temel çizgisine taşımanıza olanak tanır.

**İşaretçi etiketlerini eksene göre nasıl konumlandırabilirim?**

[TickLabelPositionType](https://reference.aspose.com/slides/java/com.aspose.slides/ticklabelpositiontype/) üzerinden `Low`, `High`, `NextTo` veya `None` değerlerini kullanarak [setTickLabelPosition](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTickLabelPosition-int-) çağırın. İşaretçileri kontrol etmek için [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorTickMark-int-) veya [setMinorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMinorTickMark-int-) kullanın; bunlar etiket konumlandırmasından ayrı bir özelliktir.