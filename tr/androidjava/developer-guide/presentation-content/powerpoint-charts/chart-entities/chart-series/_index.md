---
title: Android'de Sunumlarda Grafik Veri Serilerini Yönetme
linktitle: Veri Serileri
type: docs
url: /tr/androidjava/chart-series/
keywords:
- grafik serileri
- seri örtüşmesi
- seri rengi
- seri adı
- veri noktası
- çalışma kitabı hücresi
- seri boşluğu
- negatif değer
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Android'de sunumlarda grafik serilerini, veri noktalarını, çalışma kitabı hücrelerini, biçimlendirmeyi, örtüşmeyi, boşluk genişliğini ve negatif değerleri nasıl yöneteceğinizi öğrenin."
---
## **Genel Bakış**

Bir grafik, çizilen verilerini bir grafik veri çalışma kitabında saklar. Bir [IChartSeries](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseries/) ilişkili değerlerin bir kümesini temsil eder ve serideki her bir [IChartDataPoint](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatapoint/) bir veya daha fazla çalışma kitabı hücresine başvurur. [IChartCategory](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartcategory/) nesneleri, seriler tarafından paylaşılan etiketleri veya grup değerlerini sağlar. Bu nedenle seri adı, kategoriler ve nokta değerleri yalnızca görüntü metni olarak saklanmak yerine [IChartDataCell](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatacell/) nesnelerine bağlanır.

Tipik bir kategori grafiği için, varsayılan çalışma kitabı seri adları için satır 0, kategori adları için sütun 0 ve kalan hücreler seri değerleri için kullanır. [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) yöntemine gönderilen çalışma sayfası, satır ve sütun indisleri sıfır‑tabanlıdır. Bu düzen, varsayılan veriyle bir grafik oluşturduğunuzda faydalıdır, ancak her mevcut grafiğin bunu kullandığını varsaymayın. Yüklenmiş bir sunumda, çalışma kitabı değerlerini değiştirmeden önce seriler, kategoriler ve veri noktalarının başvurduğu hücreleri inceleyin.

Grafik ayarlarının üç farklı kapsamı vardır:

- Seri‑seviyesi ayarlar, örneğin [IChartSeries.getFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseries/#getFormat--) bir serideki tüm noktalar için varsayılan görünümü sağlar.
- Veri‑nokta ayarları, örneğin [IChartDataPoint.getFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) bir nokta için seri görünümünü geçersiz kılar.
- Grup ayarları, aynı [IChartSeriesGroup](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseriesgroup/) içinde bulunan uyumlu serilere uygulanır. Örtüşme veya boşluk genişliği gibi seçenekleri ayarlamanız gerektiğinde grup, [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) üzerinden alınır.

Açıkça bir nokta ya da seri dolgu ayarı yapılmamışsa, grafik stili ve teması otomatik görünümü belirler. Hem seri hem de nokta biçimlendirmesi mevcut olduğunda, nokta biçimlendirmesi o nokta için önceliklidir.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Grafik Serisi Örtüşmesini Ayarlama**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseries/#getOverlap--) 2B bir grafikte çubukların veya sütunların ne kadar örtüştüğünü -%100 ile %100 arasında rapor eder. Bu, üst serinin grup ayarının yalnızca okunabilir bir yansımasıdır. O gruptaki tüm uyumlu serileri güncellemek için [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) kullanın. Bu seçenek, gruplanmış çubuk veya sütun gösteren grafik türlerine uygulanır; birleşik bir grafikte ilişkili olmayan seri gruplarını etkilemez.

Aşağıdaki örnek, ilk seriyi içeren grup için örtüşmeyi ayarlar:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // Yeni grafik örnek seriler, kategoriler ve değerler içerir.
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![The series overlap](series_overlap.png)

## **Seri Dolgu Rengini Değiştirme**

[Tüm bir seri için varsayılan dolgu ayarlamak] için [IChartSeries.getFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseries/#getFormat--) yöntemini kullanın. Bir noktanın zaten açık bir dolgusu varsa, o noktanın [IChartDataPoint.getFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) ayarı seri dolgusunu geçersiz kılar.

Aşağıdaki örnek, ilk seriye katı mavi bir dolgu uygular:

```java
import com.aspose.slides.*;
import android.graphics.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("series_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![The color of the series](series_color.png)

## **Seri Adını Değiştirme**

Bir seri adı grafik veri çalışma kitabında saklanır ve genellikle lejende görüntülenir. Kümeleme sütun grafiği için varsayılan çalışma kitabında, B1 hücresi (satır 0, sütun 1) ilk serinin adını içerir. Aşağıdaki örnekteki adlandırılmış sabitler bu yapıyı açıkça gösterir:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int seriesNameRowIndex = 0;
final int firstSeriesColumnIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ayrıca [IChartSeries.getName](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseries/#getName--) tarafından zaten başvurulan hücreyi güncelleyebilirsiniz. Bu yaklaşım, mevcut bir grafikte belirli bir satır ve sütunu tahmin etmeyi önler:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int firstNameCellIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataCell seriesNameCell = series.getName().getAsCells().get_Item(firstNameCellIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![The series name](series_name.png)

## **Otomatik Seri Dolgu Rengini Alma**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) yöntem, seri indeksine ve grafik stiline göre hesaplanan rengi Android ARGB tamsayı değeri olarak döndürür. Bu, seri dolgu açıkça tanımlanmadığında kullanılan renktir. Yöntem, hesaplanan rengi okur; yeni bir dolgu atamaz.

Aşağıdaki örnek, her varsayılan serinin otomatik renk tamsayısını yazdırır:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    int seriesCount = chart.getChartData().getSeries().size();
    for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        int automaticColor = series.getAutomaticSeriesColor();
        System.out.println("Series " + seriesIndex + ": " + automaticColor);
    }
} finally {
    presentation.dispose();
}
```

Kesin tamsayı değerleri grafik stili ve temaya bağlıdır.

## **Bir Grafik Serisi İçin Ters Doldurma Rengini Ayarlama**

Çubuk, sütun ve baloncuk serileri için, negatif değerleri farklı bir dolgu ile göstermek amacıyla [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) kullanılabilir. Normal seri dolgusunu katı olarak ayarlayın, ters dönmeyi etkinleştirin ve negatif değer rengini [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) üzerinden atayın. Negatif sayılar çalışma kitabında değişmeden kalır; yalnızca görüntüleme rengi değişir.

Aşağıdaki örnek, varsayılan grafik verilerini tek bir seriyle değiştirir. Çalışma sayfası satır 0 seri adını, sütun 0 kategori adlarını, sütun 1 ise değerleri içerir:

```java
import com.aspose.slides.*;
import android.graphics.Color;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int headerRowIndex = 0;
final int categoryColumnIndex = 0;
final int firstSeriesColumnIndex = 1;
final int firstDataRowIndex = 1;

String[] categoryNames = { "Category 1", "Category 2", "Category 3" };
int[] seriesValues = { -20, 50, -30 };

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartData chartData = chart.getChartData();
    IChartDataWorkbook workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
    int chartType = chart.getType();
    IChartSeries series = chartData.getSeries().add(seriesNameCell, chartType);

    for (int categoryIndex = 0; categoryIndex < categoryNames.length; categoryIndex++) {
        int dataRowIndex = firstDataRowIndex + categoryIndex;
        String categoryName = categoryNames[categoryIndex];
        int seriesValue = seriesValues[categoryIndex];

        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
        chartData.getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    int automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.setInvertIfNegative(true);
    series.getInvertedSolidFillColor().setColor(Color.RED);

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![The inverted solid fill color](inverted_solid_fill_color.png)

Bir nokta için ters dönmeyi [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) ile etkinleştirebilirsiniz. Aşağıdaki örnekte, ters dönme seri için devre dışı bırakılmış ve yalnızca seçili nokta için etkinleştirilmiştir. Etkinin görülmesi için nokta ayrıca negatif bir değer almıştır:

```java
import com.aspose.slides.*;
import android.graphics.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 2;
final int negativeValue = -30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    int automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.getInvertedSolidFillColor().setColor(Color.RED);
    series.setInvertIfNegative(false);

    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(negativeValue);
    dataPoint.setInvertIfNegative(true);

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Belirli Bir Veri Noktasının Değerini Temizleme**

Diğer noktaları kaldırmadan bir noktayı boş bırakmak için, ilgili çalışma kitabı hücresini `null` olarak ayarlayın. Sütun grafiğinde, çizilen değer [IChartDataPoint.getValue](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) üzerinden elde edilir. Veri noktası aynı kategori konumunda kalır, ancak grafik değerini boş olarak kabul eder; bu, grafiğin boş‑değer ayarına göre işlenir.

Aşağıdaki örnek, ilk serideki yalnızca ikinci noktayı temizler:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(null);

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Saçılma grafiklerinde X ve Y hücreleri ayrı ayrı, baloncuk grafiklerinde ise bir boyut hücresi de bulunur. Kaldırmak istediğiniz değeri temsil eden hücreyi yalnızca temizleyin. Diğer noktaları tutmak istediğinizde [IChartDataPointCollection.clear](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) yöntemini çağırmayın; bu yöntem koleksiyondaki tüm veri noktalarını siler.

## **Seri Boşluk Genişliğini Ayarlama**

Boşluk genişliği, bitişik çubuk veya sütun kümeleri arasındaki boşluk olup, çubuk veya sütun genişliğinin yüzde olarak ifadesidir. Örtüşme gibi, bu ayar da bir seriye değil, üst seri grubuna aittir. Grup için bir kez [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) çağırın. Daha büyük bir değer kümeler arasındaki boşluğu artırır; daha küçük bir değer onları daha sıklaştırır.

Aşağıdaki örnek, boşluk genişliğini değiştirir ve yalnızca son sunumu kaydeder:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int gapWidthPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setGapWidth(gapWidthPercent);

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sonuç:

![The gap width](gap_width.png)

## **SSS**

**Hangi grafik türleri veri serilerini destekler?**

[ChartType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/charttype/) enum‑u tarafından temsil edilen tüm grafik türleri veri içerir, ancak serilerinin değer yapıları ve ayarları aynı değildir. Örneğin, kategori grafikleri kategori ve değer kullanırken, saçılma grafikleri X ve Y değerlerini; baloncuk grafikleri ise baloncuk boyutlarını ekler. Seri tipine uygun veri‑nokta oluşturma yöntemini kullanın. Örtüşme ve boşluk genişliği gibi seçenekler yalnızca uyumlu çubuk veya sütun gruplarına uygulanır.

**Grafik serisi grubu nedir?**

[IChartSeriesGroup](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseriesgroup/) aynı grup‑seviyesi çizim ayarlarını paylaşan uyumlu serileri içerir. Bir birleşik grafik birden fazla grup içerebilir; bu yüzden bir seriden ulaşarak grup ayarını değiştirmek, grafikteki her seriyi zorunlu olarak etkilemez.

**Yeni oluşturulan bir grafik varsayılan veri içerir mi?**

Evet. Varsayılan olarak, [IShapeCollection.addChart](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) örnek seriler, kategoriler ve değerler oluşturur. Bu hücreleri düzenleyebilir veya tamamen özel bir veri kümesi eklemeden önce hem serileri hem de kategori koleksiyonlarını temizleyebilirsiniz. Bir aşırı yükleme, varsayılan veri olmadan da grafik oluşturabilir.

**Grafik nesneleri çalışma kitabı hücrelerine nasıl bağlanır?**

Seri adları, kategori etiketleri ve veri‑nokta değerleri bir [IChartDataWorkbook](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdataworkbook/) içinde bulunan hücrelere başvurur. Başvurulan bir hücre değiştirildiğinde ilgili grafik öğesi güncellenir. Özel veri oluştururken, her noktanın istenen kategori altında çizilebilmesi için kategori satırları ile seri‑değer satırlarını hizalı tutun.

**Bir serinin tümünü değil, sadece bir noktayı nasıl temizlerim?**

İlgili değer hücresini `null` olarak ayarlayın; bu, noktanın kategori konumunu boş bir nokta olarak tutar. Bir serideki tüm noktaları kaldırmak istediğinizde yalnızca [IChartDataPointCollection.clear](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) yöntemini kullanın. Kategorileri de kaldırıyorsanız, tüm serileri güncelleyerek değerlerin kategori koleksiyonuyla hizalı kalmasını sağlayın.

**Boş noktalar nasıl görüntülenir?**

Sonuç, grafik türüne ve [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) ile yapılandırılan değere bağlıdır. Desteklenen grafikler boşlukları göçük, sıfır değer veya komşu noktaları birleştirerek gösterebilir. Sunumunuzdaki eksik verinin anlamına en uygun ayarı seçin.

**Negatif değerler nasıl biçimlendirilir?**

Desteklenen çubuk, sütun ve baloncuk serileri için [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) metodunu çağırın ve [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) tarafından döndürülen rengi ayarlayın. Bireysel bir nokta için davranışı [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) ile geçersiz kılabilirsiniz. Bu yöntemler yalnızca biçimlendirmeyi etkiler; saklanan sayısal değerler değişmez.

**Hem seri hem de nokta biçimlendirilmişse hangi format kazanır?**

Açık veri‑nokta biçimlendirmesi o nokta için önceliklidir. Diğer noktalar açık seri formatını veya (seri formatı tanımlı değilse) otomatik grafik stili ve temasını kullanmaya devam eder. Örtüşme ve boşluk genişliği gibi grup ayarları düzeni kontrol eder ve nokta‑seviyesi biçimlendirme geçersiz kılmalarına girmez.

**Bir grafiğin içerebileceği seri sayısı için bir sınır var mı?**

Aspose.Slides, ayrı bir sabit seri‑sayısı limiti uygulamaz. Uygulamada, sunum dosyası kısıtlamaları, kullanılabilir bellek, render süresi ve grafik okunabilirliği pratik bir sınır belirler.

**Sütunlar çok yakışık ya da çok uzak ise ne değiştirilmelidir?**

Uygun üst seri grubunda [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) metodunu çağırın. Değeri artırmak kümeler arasındaki boşluğu genişletir, azaltmak ise kümeleri birbirine yaklaştırır.