---
title: Java Kullanarak Sunumlarda 3B Grafikleri Özelleştirme
linktitle: 3B Grafik
type: docs
url: /tr/java/3d-chart/
keywords:
- 3B grafik
- rotasyon
- derinlik
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint sunumlarında 3B grafikler oluşturun. Java örnekleriyle döndürmeyi, yükseklik oranlarını, grafik derinliğini ve seriler arasındaki boşluğu ayarlayın."
---
## **Genel Bakış**

Aspose.Slides for Java, 3B bir grafiğin görünümünü [IChart.getRotation3D](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getRotation3D--) yöntemiyle özelleştirmenizi sağlar. Bu makale, döndürmeyi, yükseklik oranlarını, derinliği, dik açı eksenlerini ve seriler arasındaki boşluğu nasıl ayarlayacağınızı gösterir ve ardından sunumu PPTX formatında kaydeder.

## **3B Grafik Döndürme ve Derinliğini Ayarlama**

Aşağıdaki örnek bir [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) oluşturur ve [IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) kullanarak ilk slaytına yığılmış bir 3B sütun grafik ekler. Varsayılan serileri ve kategorileri her biri üç değere sahip iki seri ile değiştirir. Çalışma sayfası indeksi `0`, grafiğin ilk veri çalışma sayfasını tanımlar; satır `0` seri adlarını, sütun `0` ise kategori etiketlerini tutar.

The [setRotationX](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationX-byte-) ve [setRotationY](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationY-int-) yöntemleri grafiğin döndürmesini sırasıyla 40 ve 270 derece olarak ayarlar. [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) derinliğini genişliğinin %150'si olarak ayarlar, [setRightAngleAxes](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) ise perspektif yerine dik açı eksenlerini etkinleştirir. Oluşan sunum, bu 3B görünüm ayarlarıyla doldurulmuş grafiği içerir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    double[][] values = { { 20, 50, 30 }, { 30, 10, 60 } };

    for (int categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, categoryIndex + 1, 0, "Category " + (categoryIndex + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (int seriesIndex = 0; seriesIndex < 2; seriesIndex++) {
        IChartDataCell seriesCell = workbook.getCell(worksheetIndex, 0, seriesIndex + 1, "Series " + (seriesIndex + 1));
        IChartSeries series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

        for (int categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }
    }

    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte) 40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);

    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **3B Grafik Yükseklik Oranlarını Ayarlama**

[IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) kullanarak bir 3B grafiğin yüksekliğini genişliğinin yüzde olarak ayarlayın. Bu, slayttaki grafik nesnesinin boyutunu değiştirmeden 3B sahnenin oranlarını değiştirir.

Aşağıdaki örnek, varsayılan veri ile bir [Column3D](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) grafik oluşturur: üç seri ve dört kategori. Yükseklik oranları %50, %100 ve %200 olan üç sunumu kaydeder. Grafiğin konumu, genişliği ve yüksekliği sabit kalır. Veri, döndürme, derinlik, seri aralığı ve biçimlendirme üç dosyada da aynı olur; sadece yükseklik yüzdesi değişir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 460);
    chart.getRotation3D().setRotationX((byte) 20);
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setDepthPercents(100);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150);

    for (int heightPercent : new int[] { 50, 100, 200 }) {
        chart.getRotation3D().setHeightPercents(heightPercent);
        presentation.save("chart_height_" + heightPercent + ".pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Aşağıdaki görseller, eşdeğer .NET örneğindeki aynı yükseklik ayarlarını gösterir ve Microsoft PowerPoint kullanılarak dışa aktarılmıştır. Daha düşük bir yüzde daha düz bir sahne oluştururken, daha yüksek bir yüzde aynı grafik nesnesi içinde daha yüksek bir sahne oluşturur. PowerPoint, sahneye sığdırmak için eksen işaretçi aralıklarını ve etiket yerleşimini de ayarlayabilir.

| Yükseklik: %50 | Yükseklik: %100 | Yükseklik: %200 |
| --- | --- | --- |
| ![Genişliğinin %50'sine ayarlanmış 3B sütun grafik](height_percent_50.png) | ![Genişliğinin %100'üne ayarlanmış 3B sütun grafik](height_percent_100.png) | ![Genişliğinin %200'üne ayarlanmış 3B sütun grafik](height_percent_200.png) |

Bu yöntemler grafiğin farklı yönlerini kontrol eder:

| Yöntem | Etkisi |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) | 3B sahnenin genişliğinin yüzde olarak yüksekliği. |
| [IChart.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setHeight-float-) | Slayttaki grafik nesnesinin yüksekliği, puan cinsinden. |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | 3B sahnenin genişliğinin yüzde olarak derinliği. |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Derinlik ekseni boyunca seriler arasındaki boşluk, işaretçi genişliğinin yüzde olarak. |

Yükseklik ayarı, silindir, koni ve piramit varyantlarını içeren 3B sütun ve çubuk grafiklerin yanı sıra 3B çizgi, alan, pasta ve yüzey grafiklerini etkiler. Yukarıdaki karşılaştırma doğrulanmış `Column3D` tipini kullanır. Bu ayar, 2D `ClusteredColumn` grafiğinin veya `BubbleWith3D` grafiğinin görünümünü değiştirmez; bu adlar [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) sınıfının üyeleridir. Diğer grafik görünüm ayarları için [Chart Formatting](/slides/tr/java/chart-formatting/) bölümüne bakın.

## **Seriler Arasındaki Boşluğu Ayarlama**

[IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) kullanarak bir 3B grafiğin derinlik ekseni boyunca veri serileri arasındaki mesafeyi, işaretçi genişliğinin yüzde olarak kontrol edin. **0 ile 500** arasında değerler kullanın: `0` boşluğu kaldırır, daha büyük değerler aralığı artırır. Sabit bir grafik derinliğiyle, boşluğu artırmak işaretçileri derinlik ekseninde daha ince yapar.

[IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) aracılığıyla gruba erişin. Ayar, sadece ona erişen seriyi değil, o gruptaki tüm serileri kapsar. [IChartSeries.getGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getGapDepth--) derinlik boşluğunu döndürür ve ana grup ayarını yansıtır.

Bu ayar, silindir, koni ve piramit varyantlarını içeren 3B sütun ve çubuk grafiklerin yanı sıra 3B çizgi ve alan grafiklerini etkiler. Görünüm, serilerin derinlik, kümelenmiş veya yığılmış olmasına bağlıdır. Ayrı seriler arasındaki boşlukları net bir şekilde karşılaştırmak için [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) sınıfından `ChartType.Column3D` kullanın.

Bu yöntemler grafiğin farklı yönlerini kontrol eder:

| Yöntem | Etkisi |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Derinlik ekseni boyunca seriler arasındaki boşluk, işaretçi genişliğinin yüzde olarak. |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | Bitişik çubuk veya sütun kümeleri arasındaki boşluk, çubuk veya sütun genişliğinin yüzde olarak. |
| [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Grafik genişliğinin yüzde olarak toplam derinliği. |

Aşağıdaki bağımsız örnek, üç seri ve dört kategori içeren varsayılan grafik verilerini kullanır. Veri, döndürme, boşluk genişliği ve grafik derinliği aynı olan iki sunumu kaydeder; sadece boşluk derinliği değişir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 230);

    chart.getRotation3D().setRotationX((byte) 20);
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setDepthPercents(100);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartSeriesGroup group = series.getParentSeriesGroup();
    group.setGapWidth(150);

    for (int gapDepth : new int[] { 0, 500 }) {
        group.setGapDepth(gapDepth);

        String fileName = "series_gap_depth_" + gapDepth + ".pptx";
        presentation.save(fileName, SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Aşağıdaki görseller, eşdeğer .NET örneğindeki aynı boşluk derinliği ayarlarını gösterir ve Microsoft PowerPoint kullanılarak dışa aktarılmıştır.

| Boşluk derinliği: 0% | Boşluk derinliği: 500% |
| --- | --- |
| ![Derinlik ekseni boyunca seriler arasında boşluk olmadan 3B sütun grafik](gap_depth_0.png) | ![Derinlik ekseni boyunca seriler arasında %500 boşluklu 3B sütun grafik](gap_depth_500.png) |

## **3B Seri Türünü ve Çubuk Şeklini Değiştirme**

Kümelenmiş silindir grafiğinde, ilk seri silindirik çubuk şekliyle başlar. Örnek, her değişiklikten önce ve sonra [IChartSeries.getType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getType--) ve [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getBar3DShape--) tarafından döndürülen tam sayı değerlerini yazdırır. Tablo ilgili sabit adları verir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredCylinder, 20, 20, 500, 300);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    System.out.println(series.getType() + " | " + series.getBar3DShape());

    series.setType(ChartType.ClusteredCone);
    System.out.println(series.getType() + " | " + series.getBar3DShape());

    series.setBar3DShape(ChartShapeType.Box);
    System.out.println(series.getType() + " | " + series.getBar3DShape());

    presentation.save("series_shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Değişiklik | Seri tipi | Çubuk şekli |
| --- | --- | --- |
| Grafiği oluştur | `ClusteredCylinder` | `Cylinder` |
| Seri tipini `ClusteredCone` olarak ayarla | `ClusteredCone` | `Cone` |
| Çubuk şekli `Box` olarak ayarla | `ClusteredColumn3D` | `Box` |

`Box` şekline ayarlamak aynı zamanda seri tipini `ClusteredColumn3D` olarak değiştirir. Kodunuz seri tipine göre dallanıyorsa, şekli değiştirdikten sonra `series.getType()` çağırın. Atamadan önce önbelleğe alınan bir değer hâlâ `ClusteredCone` dalını seçecektir.

![PowerPoint karşılaştırması, ilk serinin soldan sağa silindir, koni ve dikdörtgen sütunlar olarak gösterilmesi](series-shapes.png)

## **SSS**

**Aspose.Slides'te hangi grafik türleri 3B modunu destekler?**

Aspose.Slides, sütun grafiklerinin 3B varyantlarını destekler; bu türler Column 3D, Clustered Column 3D, Stacked Column 3D ve %100 Stacked Column 3D'yi içerir ve ayrıca [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) sınıfı aracılığıyla sunulan ilgili 3B tipleri de vardır. Tam ve güncel bir liste için, yüklü sürümünüzün API referansındaki [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) üyelerine bakın.

**Bir rapor veya web için 3B grafiğin raster (bitmap) görüntüsünü alabilir miyim?**

Evet. Bir grafiği [Shape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage--) ile görüntü olarak dışa aktarabilir veya tüm slaytı [render the entire slide](/slides/tr/java/convert-powerpoint-to-png/) kullanarak PNG veya JPEG gibi formatlara dönüştürebilirsiniz. Bu, raster önizleme ihtiyacınız olduğunda veya grafiği PowerPoint gerektirmeden belge, gösterge paneli veya web sayfasına gömmek istediğinizde faydalıdır.

**Büyük 3B grafikler oluşturma ve render etme performansı nasıldır?**

Performans, veri miktarı ve görsel karmaşıklığa bağlıdır. En iyi sonuçlar için 3B efektleri minimumda tutun, duvar ve çizim alanlarında ağır dokulardan kaçının, mümkün olduğunda seriler başına veri noktası sayısını sınırlayın ve hedef ekran veya baskı ihtiyacına uygun çözünürlük ve boyutlarda çıktı oluşturun.