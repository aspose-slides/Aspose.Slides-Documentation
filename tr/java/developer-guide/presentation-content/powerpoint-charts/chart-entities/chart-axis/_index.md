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
- maksimum değer
- minimum değer
- eksen çizgisi
- tarih biçimi
- eksen başlığı
- eksen konumu
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Raporlar ve görselleştirmeler için PowerPoint sunumlarında grafik eksenlerini özelleştirmek amacıyla Aspose.Slides for Java kullanımını keşfedin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Java ile grafik eksenlerini nasıl özelleştireceğinizi açıklar. Hesaplanmış eksen değerleri, grafik satır ve sütunlarının değiştirilmesi, eksen görünürlüğü, kategori etiketi ve işaretçi aralıkları, tarih kategorileri ve biçimlendirme, başlık döndürme, eksen konumlandırma, görüntü birimleri ve logaritmik ölçeklendirme konularını kapsar.

## **Grafiklerde Dikey Eksenin Maksimum Değerlerini Almak**

Bir [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) oluşturun ve varsayılan verilerle bir alan grafiği ekleyin. Hesaplanmış eksen değerlerini okumadan önce grafiğin düzeninin güncel olmasını sağlamak için [validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#validateChartLayout--) metodunu çağırın.

Eksen sınırları için [getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMaxValue--) ve [getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinValue--) metodlarını, işaret aralıkları için ise [getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnit--) ve [getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnit--) metodlarını okuyun. [getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnitScale--) ve [getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnitScale--) zaman birimi ölçeklerini sağlar; bu ölçekler tarih eksenleri için geçerlidir. Örnek bu değerleri yerel değişkenlerde saklar ve grafiği kaydeder.

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

Grafik verilerinde serilerin ve kategorilerin rollerini değiştirmek için [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) kullanın. Önceki her kategori bir seri, önceki her seri ise bir kategori olur. Bu, verilerin nasıl gruplanacağını değiştirir; yatay ve düşey eksenleri değiştirmez. Örnek, satır ve sütunları değiştirmeden önce varsayılan verileri `Sheet1!A1:D5` aralığına bağlamak için [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setRange-java.lang.String-) metodunu kullanır; bu aralık başlık satırı ve kategori sütununu da içerir. Dört seri ve üç kategori içeren bir grafik kaydeder.

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

## **Bir Eksenin Çizim Sırasını Tersine Çevir**

Bir kategori veya değer eksenini tersine çevirmek için [setPlotOrderReversed](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setPlotOrderReversed-boolean-) metodunu kullanın. Örneğin, yatay çubuk grafik proje aşamalarını çalışma sayfasındaki aynı sırada, üstten alta gösterir: Planlama, Geliştirme, Test. Bir ekseni tersine çevirmek çizim yönünü değiştirir; çalışma kitabı verilerini sıralamaz veya yeniden düzenlemez. Karşılaştırma olarak, [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) serilerin ve kategorilerin rollerini değiştirir.

Aşağıdaki örnek, üç aşama ve bir seri içeren yatay bir çubuk grafik oluşturur. Normal sıra, tersine kategoriler ve tersine değerler olmak üzere üç slayt kaydeder. Her kopya aynı veri kümesini kullanır ve her kopyada yalnızca bir eksen tersine çevrilir.

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

    // Slayt 3: sadece yatay sayısal ölçeği tersine çevir.
    ISlide valueSlide = presentation.getSlides().addClone(slide);
    IChart valueChart = (IChart)valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bir ekseni tersine çevirmek aynı zamanda dikey ekseni çizimin karşı tarafına taşıyabilir. [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) diğer eksenin yapılandırılan ekseni nerede kestiğini kontrol eder. 2. slaytta, tersine kategori ekseninde `CrossesType.Maximum` ile çağırmak, yatay değer eksenini altta tutar. Belirli bir kesişim noktası için [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-) metodunu kullanın. Yön değiştirirken kesişim ayarlarını kontrol edin, özellikle grafik zaten özel bir kesişim noktasına sahipse. Normal çizim yönünü geri getirmek için `setPlotOrderReversed` metodunu `false` ile çağırın; kesişim ayarları ayrı bir konudur.

| Normal sıra (slayt 1) | Tersine kategoriler (slayt 2) | Tersine değerler (slayt 3) |
| --- | --- | --- |
| ![Normal kategori ve değer ekseni sırasına sahip yatay çubuk grafiği](axis-order-normal.png) | ![Kategorilerin üstten alta gösterildiği yatay çubuk grafiği](axis-order-categories-reversed.png) | ![Tersine değer ekseni ve sağda sıfır bulunan yatay çubuk grafiği](axis-order-values-reversed.png) |
| Kategoriler alttan üste doğru ilerler; değerler soldan sağa artar. | Planlama, Geliştirme ve Test, üstten alta doğru ilerler. Değerler ve çalışma kitabı satır sırası değişmez. | Kategoriler normal sırayı korur; değerler sağdan sola artar. Kategori ekseni sağda sıfırda kesişir. |

## **Çizgi Grafikleri için Dikey Eksen'i Devre Dışı Bırak**

Dikey eksende `[setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-)` metodunu `false` ile çağırarak ekseni gizleyin. Örnek, varsayılan verilerle bir çizgi grafik oluşturur ve dikey ekseni gizli olarak kaydeder.

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

## **Çizgi Grafikleri için Yatay Eksen'i Devre Dışı Bırak**

Yatay eksende `[setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-)` metodunu `false` ile çağırarak ekseni gizleyin. Örnek, varsayılan verilerle bir çizgi grafik oluşturur ve yatay ekseni gizli olarak kaydeder.

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

Bir eksenin hangi ızgara çizgilerini görüntülediğini kontrol etmek için `[getShowMajorGridLines](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getShowMajorGridLines--)` ve `[getShowMinorGridLines](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getShowMinorGridLines--)` metodlarını çağırın. Bu metodlar mevcut görünürlüğü rapor eder. Küçük ızgara çizgilerini göstermek için `[getMinorGridLinesFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getMinorGridLinesFormat--)` metodunu kullanıp satır dolgusunu katı, görünür bir renge ayarlayın. Gizlemek için dolgu tipini `[FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/#NoFill)` olarak ayarlayın. Büyük ızgara çizgileri için aynı şekilde satır dolgusunu değiştirmek amacıyla `[getMajorGridLinesFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getMajorGridLinesFormat--)` metodunu kullanın. Dolgu değişikliği eksen görünürlüğünü ve işaretçileri korur.

Bu gruplanmış sütun grafiğinin dikey ekseni başlangıçta yalnızca büyük ızgara çizgilerini gösterir. Örnek, küçük ızgara çizgilerini koyu turuncu renkle gösterir, ardından tekrar gizler ve sunumu kaydeder. Her adımda ızgara çizgisi görünürlüğünü yazdırır.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 30, 660, 230);
    IAxis axis = chart.getAxes().getVerticalAxis();
    System.out.printf("Initial: major=%b, minor=%b%n", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    ILineFillFormat minorFill = axis.getMinorGridLinesFormat().getLine().getFillFormat();
    minorFill.setFillType(FillType.Solid);
    minorFill.getSolidFillColor().setColor(new Color(255, 140, 0));
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
| ![Dikey eksende büyük ızgara çizgileri arasındaki turuncu küçük ızgara çizgileri](minor-gridlines-enabled.png) | ![Sadece büyük ızgara çizgileri görünen aynı sütun grafiği](minor-gridlines-hidden.png) |

## **Kategori Eksenini Değiştir**

[Tarih veya metin kategori ekseni seçmek için `setCategoryAxisType`](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) metodunu kullanın. Bu örnek, ilk slayttaki ilk şekil olarak bir grafik içeren `ExistingChart.pptx` dosyasını gerektirir ve kategori hücrelerinde sayısal Excel tarih değerleri bulunur. Yatay ekseni bir tarih ekseni haline getirir. `[setAutomaticMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-)` metodunu `false`, `[setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnit-double-)` metodunu `1` ve `[setMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnitScale-int-)` metodunu `TimeUnitType.Months` olarak ayarlamak, ana işaretçileri bir‑aylık aralıklarla yerleştirir.

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

### **Veriden Kategori Ekseni Tipini Belirle**

Kategorileri doldurduktan sonra `[setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setCategoryAxisTypeAutomatically--)` metodunu çağırın, ardından seçimi incelemek için `[getCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getCategoryAxisType--)` metodunu okuyun. Bu, aynı grafik ya metin etiketleri ya da sayısal tarih değerleri aldığında faydalıdır. Metod, çağrıldığı anda tipi belirler; daha sonra veri değiştiğinde tekrar değerlendirme yapan kalıcı bir mod etkinleştirmez. Kategorileri değiştirdikten sonra tekrar çağırın.

Aşağıdaki örnek, metin kategorili bir grafik oluşturur ve seçilen tip `CategoryAxisType.Text` olduğunda `true` yazdırır. Ardından kategori hücre değerlerini tarihlere değiştirir ve metodu tekrar çağırarak seçilen tip `CategoryAxisType.Date` olduğunda `true` yazdırır. Tarihler, 30 Aralık 1899’dan itibaren geçen gün sayısı şeklinde sayısal OLE Automation değerleri olarak depolanır; bu değerler tarih dizesi değildir. `[setCustomNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-)` metoduyla bu değerlerin gösterim biçimi denetlenir; metni sayısal tarihlere dönüştürmez. Kategori hücreleri hakkında daha fazla bilgi için [Chart Workbook](/slides/tr/java/chart-workbook/) sayfasına bakın.

Otomatik belirlemeyi, girişin metin kategori veya sayısal tarih içerdiği biliniyorsa kullanın. Normal sayısal etiketler, karışık kategoriler veya boş veri için, niyet edilen anlama uygun olarak `[setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setCategoryAxisType-int-)` metodunu açıkça çağırın. Yalnızca sayısal değerler, kategorilerin tarih temsil ettiğini göstermez.

```java
import com.aspose.slides.*;
import java.time.LocalDate;

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

    LocalDate baseDate = LocalDate.of(1899, 12, 30);
    LocalDate[] dates = { LocalDate.of(2026, 1, 1), LocalDate.of(2026, 1, 2), LocalDate.of(2026, 2, 1) };

    for (int i = 0; i < dates.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0);
        categoryCell.setValue((double)(dates[i].toEpochDay() - baseDate.toEpochDay()));
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

Grafikte birçok kategori bulunduğunda, kategori veya veri noktalarını kaldırmadan görünür eksen etiketlerinin sayısını azaltın. `[setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-)` metodunu `false` yapın, ardından istediğiniz kategori aralığını `[setTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickLabelSpacing-long-)` metoduna aktarın. Normal sıradaki metin kategorileri için sayma ilk kategori’den başlar:

| Aralık | Örnekte görüntülenen etiketler |
| --- | --- |
| `1` | Kategori 1, Kategori 2, Kategori 3, ... Kategori 24 |
| `2` | Kategori 1, Kategori 3, Kategori 5, ... Kategori 23 |
| `3` | Kategori 1, Kategori 4, Kategori 7, ... Kategori 22 |

`3` aralığı, her üçüncü etiketi gösterir; gösterilen etiketler arasında iki etiket gizli kalır. Bu, ilgili sütunları kaldırmaz. Otomatik aralık, mevcut alana göre bir değer seçer; her etiketi göstermeyebilir.

İşaretçilerin ayrı kontrolleri vardır. `[setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-)` metodunu `false` yapın ve aralıklarını ayarlamak için `[setTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickMarksSpacing-long-)` metodunu kullanın. Örneğin, `1` her kategori aralığında bir işaretçi bırakırken etiketler yalnızca her üçüncü kategoride görünür. Görünür bir stil ayarlamak için `[setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorTickMark-int-)` metodunu kullanın. Otomatik‑aralık ayarını tekrar `true` yaparsanız grafik tekrar bu aralığı seçer.

Aşağıdaki örnek, 24 kategori ve bir seri oluşturur, ardından `CategoryAxisIntervals.pptx` içinde üç slayt kaydeder: otomatik aralık, bağımsız işaretçilerle manuel etiket aralığı ve otomatik aralığın geri yüklenmesi. İki kopya da özgün grafik verilerini korur. Giriş sunumu gerekmez. Yatay etiket metni, yoğunluk farkını net görmeyi sağlar.

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

**Otomatik aralık (slayt 1):** Bu sunumda, her ikinci kategori etiketi gösterilir ve iki satıra kaydırılır. Otomatik sonuç grafik boyutu, yazı tipleri ve işleyiciye göre değişebilir.

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**Manuel aralık (slayt 2):** Her üçüncü etiket tek satırda gösterilir, işaretçiler ise her kategori aralığında kalır. Etiketi olmayan tüm 24 sütun aynı değerlerle görünür. Slayt 3, yukarıdaki otomatik görünümü geri getirir.

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **Doğru Eksen ve Aralığı Seç**

Bu kategori‑sayısı aralığını, sütun, çizgi, alan veya çubuk gibi bir metin kategori ekseni bulunan grafiklerde kullanın. Sütun grafiğinde bu, yatay eksendir. Yatay çubuk grafiğinde kategori ekseni dikeydir; bu nedenle ayarları `[getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--)` metodunun döndürdüğü eksene uygulayın. İşaretçi aralığı, bir serinin ekseni olan grafiklerde de geçerlidir.

Kategori etiketi aralığını, değer ekseninin sayısal ölçeğini ayarlamak için kullanmayın. Değer ekseninde `[setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorUnit-double-)` bir değer farkı belirler: örneğin, `10` bir birim, eksen sıfırdan başlıyorsa 0, 10, 20 … gibi işaretler oluşturur. `3` bir kategori etiketi aralığı ise veri değerlerinden bağımsız olarak kategori konumlarını sayar. Dağılım ve balon grafiklerde metin kategori ekseni yerine değer eksenleri kullanılır. Tarih ekseni için, [Kategori Eksenini Değiştir](#change-a-category-axis) bölümünde açıklandığı gibi zaman‑tabanlı birim ve ölçekler kullanın.

## **Kategori Eksen Değerleri için Tarih Biçimini Ayarla**

Örnek, varsayılan grafik verilerini dört yıllık değere değiştirir. Tarihler, ilk çalışma sayfasında (indeks `0`) OLE Automation seri numaraları olarak depolanır; bu sayılar 30 Aralık 1899’dan itibaren geçen gün sayısıdır. `[setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-)` metodunu `CategoryAxisType.Date` ile, `[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-)` metodunu `false` ile ve `[setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormat-java.lang.String-)` metoduna `yyyy` aktararak kategori etiketleri hücre biçiminden bağımsız olarak dört basamaklı yıl gösterir.

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

## **Grafik Eksen Başlığı için Döndürme Açısı Ayarla**

Dikey eksende `[setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTitle-boolean-)` metodunu `true` yapın, başlık metnini sağlayın ve `[setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-)` metodunu kullanarak başlığı döndürün. Açı derece cinsindendir; bu örnek, değer ekseni başlığını 90 derece döndürerek bir sütun grafik kaydeder.

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

## **Kategori veya Değer Ekseni Üzerinde Eksen Pozisyonunu Ayarla**

Değer ekseninin kategori eksenini kategori işaretçileri arasında mı yoksa işaretçilerin üzerinde mi geçeceğini kontrol etmek için `[setAxisBetweenCategories](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-)` metodunu kullanın. Bu ayar sadece kategori eksenlerine uygulanır. Örnek, bir sütun grafiğinin yatay kategori ekseninde bu ayarı `true` yapar ve sonucu kaydeder.

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

## **Grafik Değer Ekseni Üzerinde Görüntü Birimini Ayarla**

Değer eksenindeki etiketleri, temel verileri değiştirmeden ölçeklendirmek için `[setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setDisplayUnit-int-)` metodunu kullanın. `[DisplayUnitType](https://reference.aspose.com/slides/java/com.aspose.slides/displayunittype/)` `Millions` olarak ayarlandığında 60 000 000 değeri 60 olarak gösterilir. Örnek, bir sütun grafik oluşturur ve dikey eksenine milyon görüntü birimini uygular.

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

## **Logaritmik Değer Ekseni Yapılandır**

Pozitif değerlerin birkaç kat aralığına yayıldığı durumlarda logaritmik değer ekseni kullanışlıdır. Örneğin bir hizmet, beş dönem içinde 10, 100, 1 000, 10 000 ve 100 000 istek alabilir. Doğrusal ölçekte, küçük değerler sıfıra yakın bir yerde sıkışık görünür. Logaritmik ölçek, bu değerlerin göreli büyümesini karşılaştırmayı kolaylaştırır: eşit mesafeler eşit oranları, eşit farkları temsil eder.

Değer ekseninde `[setLogarithmic](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogarithmic-boolean-)` metodunu `true` yapın ve tabanı seçmek için `[setLogBase](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogBase-double-)` metodunu kullanın. Bu, mevcut değerlerin gösterimini değiştirir; veriyi veya logaritmik trend çizgisini eklemez. Trend çizgisi, verideki uygun bir ilişkiyi temsil eder ve ayrı bir özelliktir.

### **Değer Ekseni ve Tabanı Seç**

Çizgi veya sütun grafiği için değer ekseni `[getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--)` tarafından döndürülür. Yatay çubuk grafiği için `[getHorizontalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getHorizontalAxis--)` metodunu kullanın. Dağılım ve balon grafiklerde iki değer ekseni bulunur; X değerleri için yatay ekseni, Y değerleri için düşey ekseni veya her ikisini de seçin. Kategori eksenine logaritmik ölçekleme uygulamayın.

Varsayılan logaritmik taban `10` dur. PPTX grafiklerinde taban `2` ile `1000` arasında (kapsayıcı) olmalıdır; `2.5` gibi kesirli tabanlar da desteklenir. `10` tabanı ile ardışık katlar 10, 100, 1 000, 10 000 eşit aralıklarla yer alır.

### **Doğrusal ve Logaritmik Ölçeklendirmeyi Karşılaştır**

Aşağıdaki örnek, ilk slaytta beş istek sayısını gösteren bir çizgi grafik oluşturur, ardından bu slaytı kopyalar ve ikinci slaytta taban‑10 logaritmik değer eksenini etkinleştirir. Her iki slayt da aynı veriyi korur.

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

**Doğrusal ölçek (slayt 1):** Eşit dikey mesafeler, istek sayısındaki eşit farkları temsil eder. En büyük değer grafiği domine eder, küçük değerler ayırt edilemez.

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**Logaritmik ölçek (slayt 2):** Eşit dikey mesafeler, eşit oranları temsil eder. Her dönem bir önceki dönemin on katı isteği alır; bu yüzden noktalar taban‑10 ölçeğinde düz bir yükselen çizgi oluşturur. Eksen etiketleri hâlâ özgün istek sayılarını gösterir.

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **Sıfır ve Negatif Değerleri İşle**

Logaritmik ölçek yalnızca kesin pozitif değerleri gösterebilir. Etkinleştirmeden önce verileri kontrol edin. Sıfır veya negatif değerlerin anlamı varsa, doğrusal ölçeği koruyun veya bunları ayrı olarak gösterin. Bu değerleri analiz için dışlamak uygun ise, nedenini açıklayın. Küçük pozitif sayılarla sessizce değiştirmeyin; bu veri anlamını değiştirir. Logaritmik eksen için manuel olarak ayarlanan minimum veya maksimum değerlerin de pozitif olması gerekir.

## **SSS**

**Bir eksenin diğerini kestiği değeri (eksen kesişimi) nasıl ayarlarım?**

Kesişme davranışını seçmek için `[setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-)` metodunu kullanın. Sayısal bir kesişim değeri belirtmek için `[setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-)` metodunu kullanın. Bu ayarlar, eksen kesişimini uygun bir temel çizgisine taşımanıza olanak tanır.

**İşaretçi etiketlerini eksene göre nasıl konumlandırırım?**

`[setTickLabelPosition](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTickLabelPosition-int-)` metodunu `[TickLabelPositionType](https://reference.aspose.com/slides/java/com.aspose.slides/ticklabelpositiontype/)` değerleriyle çağırın: `Low`, `High`, `NextTo` veya `None`. İşaretçilerin kendisini kontrol etmek için `[setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorTickMark-int-)` veya `[setMinorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMinorTickMark-int-)` metodlarını kullanın; bunlar etiket konumlandırmadan ayrı ayarlardır.