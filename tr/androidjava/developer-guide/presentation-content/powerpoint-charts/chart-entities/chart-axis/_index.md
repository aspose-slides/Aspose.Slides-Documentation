---
title: Android'de Sunumlarda Çizelge Eksenlerini Özelleştirme
linktitle: Çizelge Ekseni
type: docs
url: /tr/androidjava/chart-axis/
keywords:
- çizelge ekseni
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
- Android
- Java
- Aspose.Slides
description: "Raporlar ve görselleştirmeler için PowerPoint sunumlarında çizelge eksenlerini özelleştirmek amacıyla Android için Aspose.Slides'ı Java aracılığıyla nasıl kullanacağınızı keşfedin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Android via Java ile çizelge eksenlerini nasıl özelleştireceğinizi açıklar. Hesaplanmış eksen değerleri, çizelge satır ve sütunlarının değiştirilmesi, eksen görünürlüğü, kategori etiketi ve işaretçi aralıkları, tarih kategorileri ve biçimlendirme, başlık dönüşü, eksen konumlandırma, görüntüleme birimleri ve logaritmik ölçeklendirme konularını kapsar.

## **Dikey Eksenin Maksimum Değerlerini Almak**

Bir [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) oluşturun ve varsayılan verilerle bir alan çizelgesi ekleyin. Hesaplanmış eksen değerlerini okumadan önce, çizelge düzeninin güncel olmasını sağlamak için [validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--) çağırın.

Eksen sınırları için [getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMaxValue--) ve [getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinValue--) okuyun ve işaretçi aralıkları için [getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnit--) ve [getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnit--) kullanın. Tarih eksenleriyle ilgili zaman birimi ölçeklerini sağlayan [getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnitScale--) ve [getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnitScale--) metodlarıdır. Örnek bu değerleri yerel değişkenlerde saklar ve çizelgeyi kaydeder.

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

## **Verileri Eksenler Arasında Değiştirin**

Çizelge verilerindeki seri ve kategorilerin rollerini değiştirmek için [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) kullanın. Her eski kategori bir seri, her eski seri ise bir kategori olur. Bu, verilerin nasıl gruplanacağını değiştirir; yatay ve dikey eksenleri değiştirmez. Örnek, satır ve sütunları değiştirmeden önce varsayılan verileri `Sheet1!A1:D5` konumuna, başlık satırı ve kategori sütunu dahil olmak üzere bağlamak için [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setRange-java.lang.String-) metodunu kullanır. Dört seri ve üç kategori içeren bir çizelge kaydeder.

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

## **Çizgi Çizelgeleri için Dikey Ekseni Devre Dışı Bırakın**

Dikey ekseni gizlemek için `false` ile [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) metodunu çağırın. Örnek, varsayılan verilerle bir çizgi çizelgesi oluşturur ve dikey ekseni gizli olarak kaydeder.

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

## **Çizgi Çizelgeleri için Yatay Ekseni Devre Dışı Bırakın**

Yatay ekseni gizlemek için `false` ile [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) metodunu çağırın. Örnek, varsayılan verilerle bir çizgi çizelgesi oluşturur ve yatay ekseni gizli olarak kaydeder.

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

Tarih veya metin kategori ekseni seçmek için [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) metodunu kullanın. Bu örnek, ilk slayttaki ilk şekil olarak bir çizelgeye ve hücrelerde sayısal Excel tarih değerlerine sahip bir `ExistingChart.pptx` dosyasını gerektirir. Yatay ekseni bir tarih ekseni haline getirir. [setAutomaticMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) metodunu `false`, [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnit-double-) metodunu `1` ve [setMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnitScale-int-) metodunu `TimeUnitType.Months` ile ayarlamak, ana işaretçileri bir‑ay aralıklarında konumlandırır.

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

## **Kategori Ekseni Etiket Aralıklarını Kontrol Edin**

Bir çizelgede çok sayıda kategori olduğunda, kategorileri veya veri noktalarını kaldırmadan görünen eksen etiketlerinin sayısını azaltın. [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) metodunu `false` ile çağırın, ardından istenen kategori aralığını [setTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickLabelSpacing-long-) metoduna aktarın. Normal sıralamadaki metin kategorileri için sayma ilk kategori’den başlar:

| Aralık | Örnekte görüntülenen etiketler |
| --- | --- |
| `1` | Kategori 1, Kategori 2, Kategori 3, ... Kategori 24 |
| `2` | Kategori 1, Kategori 3, Kategori 5, ... Kategori 23 |
| `3` | Kategori 1, Kategori 4, Kategori 7, ... Kategori 22 |

`3` aralığı, her üçüncü etiketi gösterir; gösterilen etiketler arasında iki etiket gizli kalır. İlgili sütunları kaldırmaz. Otomatik aralık, kullanılabilir alana göre bir aralık seçer; her etiketi mutlaka göstermez.

İşaretçilerin ayrı kontrolleri vardır. [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) metodunu `false` ile çağırın ve aralıklarını ayarlamak için [setTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) metodunu kullanın. Örneğin, `1` işaretçi, her kategori aralığında bir işaretçi bırakırken etiketler yalnızca her üçüncü kategoride görünür. Görünür bir stil elde etmek için [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorTickMark-int-) metodunu kullanın. Otomatik aralık ayarlarından birini tekrar `true` yapmak, çizelgenin tekrar otomatik aralığı seçmesine izin verir.

Aşağıdaki bağımsız örnek, 24 kategori ve bir seri oluşturur, ardından `CategoryAxisIntervals.pptx` içinde üç slayt kaydeder: otomatik aralık, bağımsız işaretçileri olan manuel etiket aralığı ve yeniden otomatik aralık. İki kopya orijinal çizelge verilerini korur. Girdi sunumu gerekmez. Yatay etiket metni, yoğunluk farkını görmeyi kolaylaştırır.

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

    // Slayt 3: çizelgenin her iki aralığı da tekrar seçmesine izin ver.
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Otomatik aralık (slayt 1):** Bu görüntüde, her ikinci kategori etiketi görüntülenir ve iki satıra kaydırılır. Otomatik sonuç çizelge boyutu, yazı tipleri ve işleyiciye göre değişebilir.

![Otomatik kategori etiketi aralığı, 24 sütunun tümü görünür](category-axis-automatic.png)

**Manuel aralık (slayt 2):** Her üçüncü etiket tek satırda görüntülenir, işaretçiler her kategori aralığında kalır. Etiketsiz olanlar dahil olmak üzere tüm 24 sütun aynı değerlerle görünür. Slayt 3, yukarıda gösterilen otomatik görünümü geri yükler.

![Manuel kategori etiketi aralığı üç, 24 sütunun tümü görünür](category-axis-manual.png)

### **Doğru Ekseni ve Aralığı Seçin**

Metin kategori ekseni için bu kategori‑sayısı aralığını, örneğin bir sütun, çizgi, alan veya çubuk çizelgesinin kategori ekseni olarak kullanın. Bir sütun çizelgesinde bu, yatay eksendir. Yatay çubuk çizelgesinde kategori ekseni dikeydir; bu ayarları [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--) metodu ile dönen eksene uygulayın. İşaretçi aralığı, bir ekseni olan çizelgelerde seri eksenine de uygulanabilir.

Değer ekseninin sayısal ölçeğini ayarlamak için kategori etiketi aralığını kullanmayın. Değer ekseninde [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorUnit-double-) bir değer farkı belirtir: örneğin, `10` bir birim, eksen sıfırdan başladığında 0, 10, 20 … işaretçilerini üretir. `3` bir kategori etiketi aralığı ise veri değerlerinden bağımsız olarak kategori konumlarını sayar. Dağılım ve balon çizelgeleri, metin kategori ekseni yerine değer eksenleri kullanır. Tarih ekseni için, [Change a Category Axis](#change-a-category-axis) bölümünde açıklandığı gibi zaman tabanlı birim ve ölçekler kullanın.

## **Kategori Ekseni Değerleri için Tarih Biçimini Ayarlayın**

Örnek, varsayılan çizelge verilerini dört yıllık değerle değiştirir. Tarihler, ilk çalışma sayfasında (indeks `0`) OLE Automation seri numarası olarak saklanır; bu sayılar 30 Aralık 1899’dan itibaren geçen gün sayısıdır. Her iki takvim de UTC kullanır ve tarihleri ayarlamadan önce temizlenir; böylece yaz saati uygulaması ve günün saati hesaplamayı etkilemez. [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) metodunu `CategoryAxisType.Date` ile, [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) metodunu `false` ile ve [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) metoduna `yyyy` aktararak kategori etiketlerinin hücre biçiminden bağımsız dört basamaklı yıl olarak gösterilmesini sağlayın.

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

## **Çizelge Ekseni Başlığı için Döndürme Açısı Ayarlayın**

Dikey eksende başlığı göstermek için [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTitle-boolean-) metodunu `true` ile çağırın, başlık metnini sağlayın ve başlığı döndürmek için [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) metodunu kullanın. Açı derece cinsindendir; bu örnek, değer‑ekseni başlığı 90 derece döndürülmüş bir sütun çizelgesi kaydeder.

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

## **Kategori veya Değer Ekseni Üzerinde Ekseni Konumlandırın**

Değer ekseninin kategori eksenini kategoriler arasında mı yoksa kategori işaretçileri üzerinde mi keseceğini kontrol etmek için [setAxisBetweenCategories](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) metodunu kullanın. Bu ayar kategori eksenlerine uygulanır. Örnek, bir sütun çizelgesinin yatay kategori ekseninde bunu `true` olarak ayarlar ve sonucu kaydeder.

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

## **Çizelge Değer Ekseninde Görüntüleme Birimini Ayarlayın**

Verileri değiştirmeden bir değer eksenindeki etiketleri ölçeklemek için [setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setDisplayUnit-int-) metodunu kullanın. [DisplayUnitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/displayunittype/) `Millions` olarak ayarlandığında, 60 000 000 değeri 60 olarak gösterilir. Örnek bir sütun çizelgesi oluşturur ve dikey eksenine milyon görüntüleme birimini uygular.

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

## **Logaritmik Değer Eksenini Yapılandırın**

Pozitif değerler birkaç mertebe büyüklük farkı gösterdiğinde bir logaritmik değer ekseni yararlıdır. Örneğin, bir hizmet beş dönemde 10, 100, 1 000, 10 000 ve 100 000 istek alabilir. Doğrusal ölçekte, küçük değerler sıfıra yakın bir arada görünür. Logaritmik ölçek, eşit mesafelerin eşit oranları temsil etmesini sağlar; bu da göreceli büyümeyi karşılaştırmayı kolaylaştırır.

Değer ekseninde logaritmik ölçeği etkinleştirmek için [setLogarithmic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogarithmic-boolean-) metodunu `true` ile ve tabanı seçmek için [setLogBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogBase-double-) metodunu kullanın. Bu, mevcut değerlerin nasıl gösterildiğini değiştirir; verileri veya logaritmik bir trend çizgisi eklemez. Trend çizgisi, verideki ilişkili bir uyumu temsil eden ayrı bir özelliktir.

### **Değer Eksenini ve Tabanı Seçin**

Çizgi veya sütun çizelgesinde değer ekseni, [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--) metodu ile döner. Yatay çubuk çizelgesinde ise [getHorizontalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getHorizontalAxis--) metodu döner. Dağılım ve balon çizelgelerinde iki değer ekseni bulunduğundan, X değerleri için yatay ekseni, Y değerleri için dikey ekseni veya her ikisini seçin. Logaritmik ölçekleme bir kategori eksenine uygulanmamalıdır.

Varsayılan logaritmik taban `10`dır. PPTX çizelgeleri için `2` ile `1000` arasında (dahil) bir taban kullanabilirsiniz; `2.5` gibi kesirli tabanlar da desteklenir. `10` tabanı ile ardışık güçler 10, 100, 1 000, 10 000 eşit aralıklarla yer alır.

### **Doğrusal ve Logaritmik Ölçeklemeyi Karşılaştırın**

Aşağıdaki bağımsız örnek, ilk slaytta beş istek sayısını içeren bir çizgi çizelgesi oluşturur, ardından bu slaytı kopyalar ve ikinci slaytta taban‑10 logaritmik değer eksenini etkinleştirir. Her iki slayt da aynı verileri korur.

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

**Doğrusal ölçek (slayt 1):** Eşit dikey mesafeler, istek sayılarındaki eşit farkları temsil eder. En büyük değer çizelgeyi domine eder, küçük değerleri ayırt etmeyi zorlaştırır.

![Doğrusal değer ekseninde beş istek sayısını gösteren PowerPoint çizgi çizelgesi](value-axis-linear.png)

**Logaritmik ölçek (slayt 2):** Eşit dikey mesafeler eşit oranları temsil eder. Her dönem, bir önceki dönemin on katı istek alır; bu nedenle noktalar taban‑10 ölçeğinde düz bir yükselen çizgi oluşturur. Eksen etiketleri hâlâ orijinal istek sayılarını gösterir.

![PowerPoint’te taban‑10 logaritmik değer ekseninde aynı beş istek sayısı](value-axis-logarithmic.png)

### **Sıfır ve Negatif Değerleri Ele Alın**

Logaritmik ölçek yalnızca kesin pozitif değerleri gösterebilir. Etkinleştirmeden önce verileri kontrol edin. Sıfır veya negatif değerler anlamlıysa, doğrusal ölçeği koruyun veya bunları ayrı olarak gösterin. Bu değerleri dışlamak analiz için uygunsa, eksikliği açıklayın. Küçük pozitif sayılarla sessizce değiştirmeyin; bu veri anlamını değiştirir. Logaritmik eksen için manuel olarak yapılandırılmış herhangi bir minimum veya maksimum değer de pozitif olmalıdır.

## **SSS**

**Bir eksenin diğerini kestiği (eks kesişimi) noktayı nasıl ayarlarım?**

Kesişme davranışını seçmek için [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) metodunu kullanın. Sayısal bir kesişme değeri belirtmek için [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-) metodunu kullanın. Bu ayarlar, eksen kesişimini uygun bir temel çizgisine taşımanıza olanak tanır.

**İşaretçi etiketlerini eksene göre nasıl konumlandırırım?**

[TickLabelPositionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ticklabelpositiontype/) `Low`, `High`, `NextTo` veya `None` seçeneklerini kullanarak [setTickLabelPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTickLabelPosition-int-) metodunu çağırın. İşaretçileri kontrol etmek için [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) veya [setMinorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMinorTickMark-int-) metodlarını kullanın; bunlar etiket konumlandırmadan ayrı işlemlerdir.