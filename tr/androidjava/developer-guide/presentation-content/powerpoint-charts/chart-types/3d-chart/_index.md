---
title: Android'de Sunumlarda 3D Grafikleri Özelleştirme
linktitle: 3D Grafik
type: docs
url: /tr/androidjava/3d-chart/
keywords:
- 3D grafik
- döndürme
- derinlik
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile PowerPoint sunumlarında 3D grafikler oluşturun. Java örnekleriyle döndürme, yükseklik oranları, grafik derinliği ve seriler arasındaki boşlukları ayarlayın."
---
## **Genel Bakış**

Aspose.Slides for Android via Java, 3D bir grafiğin görünümünü [IChart.getRotation3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getRotation3D--) yöntemiyle özelleştirmenizi sağlar. Bu makale, döndürmeyi, yükseklik oranlarını, derinliği, dik açı eksenlerini ve seriler arasındaki boşluğu ayarlamayı ve ardından sunumu PPTX formatında kaydetmeyi gösterir.

## **3D Grafiğin Döndürülmesi ve Derinliğinin Ayarlanması**

Aşağıdaki örnek bir [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) oluşturur ve [IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) yöntemini kullanarak ilk slaytına yığılmış bir 3D sütun grafiği ekler. Varsayılan serileri ve kategorileri, her biri üç değer içeren iki seriyle değiştirir. Çalışma sayfası indeksi `0`, grafiğin ilk veri çalışma sayfasını tanımlar; satır `0` seri adlarını, sütun `0` ise kategori etiketlerini tutar.

[setRotationX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationX-byte-) ve [setRotationY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationY-int-) yöntemleri, grafiğin döndürülmesini sırasıyla 40 ve 270 derece olarak ayarlar. [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) derinliği genişliğinin %150'si olarak belirler, aynı zamanda [setRightAngleAxes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) perspektif yerine dik açı eksenlerini etkinleştirir. Ortaya çıkan sunum, bu 3D görünüm ayarlarıyla doldurulmuş grafiği içerir.

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

## **3D Grafiğin Yüzeyine Resim Doldurma Uygulama**

Bir 3D grafiğin bağımsız olarak doldurulabilecek üç yüzeyi vardır: [side wall](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getSideWall--), [back wall](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getBackWall--) ve [floor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getFloor--). Yüzeyin [fill type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) özelliğini `Picture` olarak ayarlayın ve bir görüntü atayın. Hem [picture fill mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) hem de yüzeyin [picture type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartwall/#setPictureType-int-) özelliğini `Stretch` olarak belirleyerek görüntünün bir kopyasının yüzeyde yayılmasını sağlayın.

[arrow.png](arrow.png) dosyasını çalışma dizinine kaydedin. Örnek grafiği döndürür ve dikey eksende maksimum değeri yükselterek sütunlar arasındaki zeminin görünür olmasını sağlar. Daha sonra slaytı iki kez klonlayarak ok resmini her slaytta farklı bir yüzeye uygular. Üç grafik de aynı veri, görüntü açısı ve arka planı korur.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try (FileInputStream image = new FileInputStream("arrow.png")) {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 20, 30, 680, 480);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte) 40);
    chart.getRotation3D().setRotationY(30);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(24);

    ISlide backSlide = presentation.getSlides().addClone(slide);
    ISlide floorSlide = presentation.getSlides().addClone(slide);
    IChart backChart = (IChart) backSlide.getShapes().get_Item(0);
    IChart floorChart = (IChart) floorSlide.getShapes().get_Item(0);

    IPPImage arrow = presentation.getImages().addImage(image);

    IChartWall[] surfaces = { chart.getSideWall(), backChart.getBackWall(), floorChart.getFloor() };
    for (IChartWall surface : surfaces) {
        IFillFormat fill = surface.getFormat().getFill();
        fill.setFillType(FillType.Picture);
        fill.getPictureFillFormat().getPicture().setImage(arrow);
        fill.getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
        surface.setPictureType(PictureType.Stretch);
    }

    presentation.save("chart-surfaces.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Microsoft PowerPoint, üç slaytı aşağıdaki gibi gösterir.

| Yan duvar | Arka duvar | Zemin |
| --- | --- | --- |
| ![Yan duvar boyunca grafiğe doğru işaret eden ok](side-wall.png) | ![Arka duvar boyunca sağa işaret eden ok](back-wall.png) | ![Sütunlar arasındaki zeminde sağa işaret eden ok](floor.png) |

## **3D Grafiğin Yükseklik Oranlarını Ayarlama**

[IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) yöntemini kullanarak bir 3D grafiğin yüksekliğini genişliğinin yüzde olarak ayarlayabilirsiniz. Bu, slayttaki grafik nesnesinin boyutunu değiştirmeden 3D sahnenin oranlarını değiştirir.

Aşağıdaki örnek, varsayılan verilerle bir [Column3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) grafiği oluşturur: üç seri ve dört kategori. Yükseklik oranları %50, %100 ve %200 olan üç sunum kaydeder. Grafiğin konumu, genişliği ve yüksekliği sabit kalır. Veri, döndürme, derinlik, seri aralığı ve biçimlendirme tüm üç dosyada aynıdır; yalnızca yükseklik yüzdesi değişir.

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

Aşağıdaki görseller, eşdeğer .NET örneğinde aynı yükseklik ayarlarını gösterir ve Microsoft PowerPoint kullanılarak dışa aktarılmıştır. Daha düşük bir yüzde daha düz bir sahne oluştururken, daha yüksek bir yüzde aynı grafik nesnesi içinde daha yüksek bir sahne oluşturur. PowerPoint ayrıca eksen işaretçi aralıklarını ve etiket yerleşimini sahneye uyacak şekilde ayarlayabilir.

| Yükseklik: %50 | Yükseklik: %100 | Yükseklik: %200 |
| --- | --- | --- |
| ![Genişliğinin %50'si olarak ayarlanmış yükseklikte 3D sütun grafik](height_percent_50.png) | ![Genişliğinin %100'si olarak ayarlanmış yükseklikte 3D sütun grafik](height_percent_100.png) | ![Genişliğinin %200'si olarak ayarlanmış yükseklikte 3D sütun grafik](height_percent_200.png) |

Bu yöntemler, grafiğin farklı yönlerini kontrol eder:

| Yöntem | Etkisi |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) | 3D sahnenin genişliğine yüzde olarak yüksekliği. |
| [IChart.setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setHeight-float-) | Slayttaki grafik nesnesinin yüksekliği, puan cinsinden. |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | 3D sahnenin genişliğine yüzde olarak derinliği. |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Derinlik ekseni boyunca seriler arasındaki boşluk, işaretçi genişliğinin yüzde olarak. |

Yükseklik ayarı, silindir, koni ve piramit varyantlarını içeren 3D sütun ve çubuk grafiklerinin yanı sıra 3D çizgi, alan, pasta ve yüzey grafiklerini etkiler. Yukarıdaki karşılaştırma doğrulanmış `Column3D` tipini kullanır. Bu ayar, 2D `ClusteredColumn` grafiğinin veya `BubbleWith3D` grafiğinin görünümünü değiştirmez; bu adlar [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) sınıfının üyeleridir. Diğer grafik görünüm ayarları için [Chart Formatting](/slides/tr/androidjava/chart-formatting/) bölümüne bakın.

## **Seriler Arasındaki Boşluğu Ayarlama**

[IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) yöntemini kullanarak 3D bir grafiğin derinlik ekseni boyunca veri serileri arasındaki mesafeyi işaretçi genişliğinin yüzde olarak kontrol edebilirsiniz. **0 ile 500** arasında, dahil olmak üzere değerler kullanın: `0` boşluğu kaldırır, daha büyük değerler ise aralığı artırır. Sabit bir grafik derinliğiyle, boşluk artırıldığında işaretçiler derinlik ekseninde daha ince görünür.

Gruba, [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) aracılığıyla erişin. Ayar, o gruptaki tüm serilere uygulanır, sadece erişilen seriye değil. [IChartSeries.getGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getGapDepth--) derinlik boşluğunu döndürür ve ebeveyn grubun ayarını yansıtır.

Bu ayar, silindir, koni ve piramit varyantlarını içeren 3D sütun ve çubuk grafiklerinin yanı sıra 3D çizgi ve alan grafiklerini etkiler. Görünüm, serilerin derinlik boyunca, kümelenmiş veya yığılmış olmasına bağlıdır. Ayrı seriler arasındaki boşlukları net bir şekilde karşılaştırmak için [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) sınıfından `ChartType.Column3D` kullanın.

| Yöntem | Etkisi |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Derinlik ekseni boyunca seriler arasındaki boşluk, işaretçi genişliğinin yüzde olarak. |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | Bitişik çubuk veya sütun kümeleri arasındaki boşluk, çubuk veya sütun genişliğinin yüzde olarak. |
| [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Grafik toplam derinliği, grafik genişliğinin yüzde olarak. |

Aşağıdaki bağımsız örnek, üç seri ve dört kategori içeren varsayılan grafik verilerini kullanır. Veri, döndürme, boşluk genişliği ve grafik derinliği aynı olan iki sunum kaydeder; yalnızca boşluk derinliği değişir.

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

Aşağıdaki görseller, eşdeğer .NET örneğinde aynı boşluk derinliği ayarlarını gösterir ve Microsoft PowerPoint kullanılarak dışa aktarılmıştır.

| Boşluk derinliği: 0% | Boşluk derinliği: 500% |
| --- | --- |
| ![Derinlik ekseni boyunca seriler arasında boşluk olmayan 3D sütun grafik](gap_depth_0.png) | ![Derinlik ekseni boyunca seriler arasında %500 boşluk olan 3D sütun grafik](gap_depth_500.png) |

## **3D Seri Tipini ve Çubuk Şekli Değiştirme**

Kümelenmiş silindir grafiğinde, ilk seri silindirik çubuk şekliyle başlar. Örnek, her değişiklikten önce ve sonra [IChartSeries.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getType--) ve [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getBar3DShape--) yöntemlerinin döndürdüğü tamsayı değerlerini yazdırır. Tablo, karşılık gelen sabit adları verir.

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

| İlk seriye yapılan değişiklik | Seri tipi | Çubuk şekli |
| --- | --- | --- |
| Grafiği oluştur | `ClusteredCylinder` | `Cylinder` |
| `ClusteredCone` olarak seri tipini ayarla | `ClusteredCone` | `Cone` |
| `Box` olarak çubuk şekli ayarla | `ClusteredColumn3D` | `Box` |

Şekli `Box` olarak ayarlamak aynı zamanda seri tipini `ClusteredColumn3D` olarak değiştirir. Kodunuz seri tipine göre dallanıyorsa, şekli değiştirdikten sonra `series.getType()` metodunu çağırın. Atamadan önce önbelleğe alınan bir değer hala `ClusteredCone` dalını seçecektir.

![Soldan sağa ilk serinin silindir, koni ve dikdörtgen sütunlar olarak gösterildiği PowerPoint karşılaştırması](series-shapes.png)

## **SSS**

**Aspose.Slides'ta hangi grafik tipleri 3D modunu destekler?**

Aspose.Slides, Column 3D, Clustered Column 3D, Stacked Column 3D ve %100 Stacked Column 3D gibi sütun grafiklerinin 3D varyantlarını ve [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) sınıfı aracılığıyla sunulan ilgili 3D tipleri destekler. Tam ve güncel bir liste için, yüklü sürümünüzün API referansındaki [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) üyelerine bakın.

**Bir rapor veya web için 3D grafiğin raster görüntüsünü alabilir miyim?**

Evet. Bir grafiği [Shape.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage--) yöntemiyle görüntüye dışa aktarabilir veya [tüm slaytı](/slides/tr/androidjava/convert-powerpoint-to-png/) PNG veya JPEG gibi formatlara render edebilirsiniz. Bu, raster önizleme gerektiğinde veya grafiği PowerPoint gerektirmeden belgeler, panolar veya web sayfalarına yerleştirmek istediğinizde kullanışlıdır.

**Büyük 3D grafikleri oluşturma ve render etme performansı nasıldır?**

Performans, veri hacmi ve görsel karmaşıklığa bağlıdır. En iyi sonuçlar için 3D efektlerini minimumda tutun, duvarlarda ve grafik alanlarında ağır dokulardan kaçının, mümkün olduğunda seri başına veri noktası sayısını sınırlayın ve hedef görüntüleme veya baskı ihtiyacına uygun çözünürlük ve boyutlarda çıktı render edin.