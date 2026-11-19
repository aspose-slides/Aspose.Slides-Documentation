---
title: Python Kullanarak Sunumlarda 3D Grafikleri Özelleştirme
linktitle: 3D Grafik
type: docs
url: /tr/python-java/3d-chart/
keywords:
- 3D grafik
- rotasyon
- derinlik
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Python üzerinden Java ile Aspose.Slides kullanarak PowerPoint sunumlarında 3D grafikler oluşturun. Döndürme, yükseklik oranları, grafik derinliği ve seriler arasındaki boşlukları Python örnekleriyle ayarlayın."
---
## **Genel Bakış**

Aspose.Slides for Python via Java, 3D bir grafiğin görünümünü [Chart.getRotation3D](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getRotation3D) metodini kullanarak özelleştirmenizi sağlar. Bu makale, döndürmeyi, yükseklik oranlarını, derinliği, dik açı eksenlerini ve seriler arasındaki boşluğu nasıl ayarlayacağınızı gösterir ve ardından sunumu PPTX formatında kaydeder.

## **3D Grafiğin Döndürülmesi ve Derinliğinin Ayarlanması**

Aşağıdaki örnek bir [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) oluşturur ve [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) kullanarak ilk slaytına yığılmış bir 3D sütun grafiği ekler. Varsayılan serileri ve kategorileri, her biri üç değer içeren iki seriyle değiştirir. Çalışma sayfası indeksi `0`, grafiğin ilk veri çalışma sayfasını belirler; satır `0` seri adlarını, sütun `0` ise kategori etiketlerini tutar.

[setRotationX](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationX) ve [setRotationY](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRotationY) metodları grafiğin döndürülmesini sırasıyla 40 ve 270 dereceye ayarlar. [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) derinliğini genişliğinin %150'si olarak ayarlar, [setRightAngleAxes](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setRightAngleAxes) ise perspektif yerine dik açı eksenlerini etkinleştirir. Ortaya çıkan sunum, bu 3D görünüm ayarlarıyla doldurulmuş grafiği içerir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.getCell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.getChartData().getCategories().add(category_cell)

    for series_index in range(2):
        series_cell = workbook.getCell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())

        for category_index in range(3):
            value_cell = workbook.getCell(worksheet_index, category_index + 1, series_index + 1, jpype.JDouble(values[series_index][category_index]))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **3D Grafiğin Yükseklik Oranlarını Ayarlama**

[Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) yöntemini kullanarak bir 3D grafiğin yüksekliğini genişliğinin yüzde olarak ayarlayabilirsiniz. Bu, slayttaki grafik nesnesinin boyutunu değiştirmeden 3D sahnenin oranlarını değiştirir.

Aşağıdaki örnek, varsayılan veriyle bir [Column3D](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) grafiği oluşturur: üç seri ve dört kategori. Yükseklik oranları %50, %100 ve %200 olan üç sunum kaydeder. Grafiğin konumu, genişliği ve yüksekliği sabit kalır. Veri, döndürme, derinlik, seri aralığı ve biçimlendirme üç dosyada da aynıdır; yalnızca yükseklik yüzdesi değişir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 460)
    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setDepthPercents(100)
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150)

    for height_percent in [50, 100, 200]:
        chart.getRotation3D().setHeightPercents(height_percent)
        presentation.save(f"chart_height_{height_percent}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Aşağıdaki görseller, eşdeğer .NET örneğinde aynı yükseklik ayarlarını gösterir ve Microsoft PowerPoint kullanılarak dışa aktarılmıştır. Daha düşük bir yüzde daha düz bir sahne oluştururken, daha yüksek bir yüzde aynı grafik nesnesi içinde daha yüksek bir sahne oluşturur. PowerPoint, sahneye uyması için eksen işaretçileri aralıklarını ve etiket yerleşimini de ayarlayabilir.

| Yükseklik: %50 | Yükseklik: %100 | Yükseklik: %200 |
| --- | --- | --- |
| ![Genişliğinin %50'sine ayarlanmış 3D sütun grafiği](height_percent_50.png) | ![Genişliğinin %100'e ayarlanmış 3D sütun grafiği](height_percent_100.png) | ![Genişliğinin %200'e ayarlanmış 3D sütun grafiği](height_percent_200.png) |

Bu yöntemler grafiğin farklı yönlerini kontrol eder:

| Yöntem | Etkisi |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setHeightPercents) | 3D sahnenin yüksekliği, genişliğinin yüzde olarak. |
| [Chart.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHeight) | Slayttaki grafik nesnesinin yüksekliği, puan cinsinden. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | 3D sahnenin derinliği, genişliğinin yüzde olarak. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | Derinlik ekseninde seriler arasındaki boşluk, işaretçi genişliğinin yüzde olarak. |

Yükseklik ayarı, silindir, konik ve piramit varyantları dahil olmak üzere 3D sütun ve çubuk grafiklerini, ayrıca 3D çizgi, alan, pasta ve yüzey grafiklerini etkiler. Yukarıdaki karşılaştırma, doğrulanmış `Column3D` tipini kullanır. Ayar, 2D `ClusteredColumn` grafiğinin veya `BubbleWith3D` grafiğinin görünümünü değiştirmez; bu adlar [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) sınıfının üyeleridir. Diğer grafik görünüm ayarları için [Chart Formatting](/slides/tr/python-java/chart-formatting/) bölümüne bakın.

## **Seriler Arasındaki Boşluğu Ayarlama**

[ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) yöntemini kullanarak 3D bir grafiğin derinlik ekseninde veri serileri arasındaki mesafeyi işaretçi genişliğinin yüzde olarak kontrol edebilirsiniz. **0 ile 500** arasında (0 dahil) değerler kullanın: `0` boşluğu kaldırır, daha büyük değerler aralığı artırır. Sabit bir grafik derinliğiyle, boşluğu artırmak işaretçileri derinlik ekseninde daha ince yapar.

[ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) aracılığıyla gruba erişin. Ayar, ona erişmek için kullanılan seriyi değil, grup içindeki tüm serilere uygulanır. [ChartSeries.getGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getGapDepth) derinlik boşluğunu döndürür ve üst grubun ayarını yansıtır.

Bu ayar, silindir, konik ve piramit varyantları dahil olmak üzere 3D sütun ve çubuk grafiklerini, ayrıca 3D çizgi ve alan grafiklerini etkiler. Görünüm, serilerin derinlikte, gruplanmış ya da yığılmış olmasına bağlıdır. Ayrı seriler arasındaki boşlukları net bir şekilde karşılaştırmak için [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) sınıfındaki `ChartType.Column3D` öğesini kullanın.

Bu yöntemler grafiğin farklı yönlerini kontrol eder:

| Yöntem | Etkisi |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapDepth) | Derinlik ekseninde seriler arasındaki boşluk, işaretçi genişliğinin yüzde olarak. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) | Yan yana çubuk veya sütun kümeleri arasındaki boşluk, çubuk veya sütun genişliğinin yüzde olarak. |
| [setDepthPercents](https://reference.aspose.com/slides/python-java/aspose.slides/rotation3d/#setDepthPercents) | Grafiğin genel derinliği, grafik genişliğinin yüzde olarak. |

Aşağıdaki bağımsız örnek, üç seri ve dört kategori içeren varsayılan grafik verilerini kullanır. Veri, döndürme, boşluk genişliği ve grafik derinliği aynı olan iki sunum kaydeder; yalnızca boşluk derinliği değişir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 230)

    chart.getRotation3D().setRotationX(jpype.JByte(20))
    chart.getRotation3D().setRotationY(30)
    chart.getRotation3D().setDepthPercents(100)

    series = chart.getChartData().getSeries().get_Item(0)
    group = series.getParentSeriesGroup()
    group.setGapWidth(150)

    for gap_depth in [0, 500]:
        group.setGapDepth(gap_depth)

        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Aşağıdaki görseller, eşdeğer .NET örneğinde aynı boşluk derinliği ayarlarını gösterir ve Microsoft PowerPoint kullanılarak dışa aktarılmıştır.

| Boşluk derinliği: 0% | Boşluk derinliği: 500% |
| --- | --- |
| ![Derinlik ekseninde seriler arasında boşluk olmayan 3D sütun grafiği](gap_depth_0.png) | ![Derinlik ekseninde seriler arasında %500 boşluk olan 3D sütun grafiği](gap_depth_500.png) |

## **3D Seri Türünü ve Çubuk Şeklini Değiştirme**

Küme halinde silindir grafiğinde, ilk seri silindirik çubuk şekliyle başlar. Örnek, her değişiklikten önce ve sonra [ChartSeries.getType](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getType) ve [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getBar3DShape) tarafından döndürülen tam sayı değerlerini yazdırır. Tablo, karşılık gelen sabit adları verir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartShapeType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredCylinder, 20, 20, 500, 300)
    series = chart.getChartData().getSeries().get_Item(0)
    
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setType(ChartType.ClusteredCone)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    series.setBar3DShape(ChartShapeType.Box)
    print(f"{series.getType()} | {series.getBar3DShape()}")

    presentation.save("series_shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| İlk serideki değişiklik | Seri türü | Çubuk şekli |
| --- | --- | --- |
| Grafiği oluştur | `ClusteredCylinder` | `Cylinder` |
| Seri türünü `ClusteredCone` olarak ayarla | `ClusteredCone` | `Cone` |
| Çubuk şeklini `Box` olarak ayarla | `ClusteredColumn3D` | `Box` |

Şekli `Box` olarak ayarlamak aynı zamanda seri türünü `ClusteredColumn3D` olarak değiştirir. Kodunuz seri tipine göre dallanıyorsa, şekli değiştirdikten sonra `series.getType()` çağırın. Atamadan önce önbelleğe alınan bir değer hâlâ `ClusteredCone` dalını seçecektir.

![PowerPoint karşılaştırması, ilk serinin soldan sağa silindir, koni ve dikdörtgen sütunlar olarak gösterilmesi](series-shapes.png)

## **SSS**

**Aspose.Slides'te hangi grafik türleri 3D modunu destekler?**

Aspose.Slides, Column 3D, Clustered Column 3D, Stacked Column 3D ve %100 Stacked Column 3D dahil olmak üzere sütun grafiklerinin 3D varyantlarını ve [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) sınıfı aracılığıyla sunulan ilgili 3D tiplerini destekler. Kesin ve güncel liste için, yüklü sürümünüzün API referansındaki [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) üyelerine bakın.

**Rapor veya web için 3D grafiğin raster görüntüsünü alabilir miyim?**

Evet. Bir grafiği [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) ile görüntüye dışa aktarabilir veya [tüm slaytı render et](/slides/tr/python-java/convert-powerpoint-to-png/) yoluyla tüm slaytı PNG veya JPEG gibi formatlarda dışa aktarabilirsiniz. Bu, bir raster önizleme gerektiğinde veya grafiği belge, gösterge panosu veya web sayfasına PowerPoint gerektirmeden gömmek istediğinizde kullanışlıdır.

**Büyük 3D grafikleri oluşturma ve render etme performansı nasıldır?**

Performans, veri miktarı ve görsel karmaşıklığa bağlıdır. En iyi sonuçlar için 3D efektleri minimal tutun, duvar ve çizim alanlarında ağır dokulardan kaçının, mümkün olduğunda seri başına veri noktası sayısını sınırlayın ve hedef görüntüleme ya da baskı ihtiyacına uygun çözünürlük ve boyutlarda bir çıktı render edin.