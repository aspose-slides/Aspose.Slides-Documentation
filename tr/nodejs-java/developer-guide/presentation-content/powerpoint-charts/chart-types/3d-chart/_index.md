---
title: JavaScript Kullanarak Sunumlarda 3D Grafikleri Özelleştirme
linktitle: 3D Grafik
type: docs
url: /tr/nodejs-java/3d-chart/
keywords:
- 3D grafik
- dönüş
- derinlik
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java ile PowerPoint sunumlarında 3D grafikler oluşturun. Dönüş, yükseklik oranları, grafik derinliği ve seriler arasındaki boşlukları JavaScript örnekleriyle ayarlayın."
---
## **Genel Bakış**

Aspose.Slides for Node.js via Java, 3D bir grafiğin görünümünü [Chart.getRotation3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getrotation3d/) yöntemiyle özelleştirmenizi sağlar. Bu makale, dönüş, yükseklik oranları, derinlik, dik açı eksenleri ve seriler arasındaki boşlukları nasıl ayarlayacağınızı ve ardından sunumu PPTX formatında kaydetmenizi gösterir.

## **3D Grafiğin Döndürülmesi ve Derinliğinin Ayarlanması**

Aşağıdaki örnek bir [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) oluşturur ve [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) kullanarak ilk slaytına yığılmış bir 3D sütun grafiği ekler. Varsayılan serileri ve kategorileri, her biri üç değer içeren iki seriyle değiştirir. Çalışma sayfası indeksi `0`, grafiğin ilk veri çalışma sayfasını tanımlar; satır `0` seri adlarını, sütun `0` ise kategori etiketlerini tutar.

[setRotationX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationx/) ve [setRotationY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationy/) metodları, grafiğin dönüşünü sırasıyla 40 ve 270 derece olarak ayarlar. [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) derinliğini genişliğinin %150'si olarak belirler, [setRightAngleAxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrightangleaxes/) ise perspektif yerine dik açı eksenlerini etkinleştirir. Ortaya çıkan sunum, bu 3D görünüm ayarlarıyla doldurulmuş grafiği içerir.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.StackedColumn3D, 0, 0, 500, 500);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    const values = [[20, 50, 30], [30, 10, 60]];

    for (let categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
        const categoryCell = workbook.getCell(worksheetIndex, categoryIndex + 1, 0, "Category " + (categoryIndex + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (let seriesIndex = 0; seriesIndex < 2; seriesIndex++) {
        const seriesCell = workbook.getCell(worksheetIndex, 0, seriesIndex + 1, "Series " + (seriesIndex + 1));
        const series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

        for (let categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
            const valueCell = workbook.getCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }
    }

    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(java.newByte(40));
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);

    presentation.save("Rotation3D_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **3D Grafiğin Yükseklik Oranlarını Ayarlama**

[Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) kullanarak bir 3D grafiğin yüksekliğini genişliğine yüzde olarak ayarlayabilirsiniz. Bu, slayttaki grafik nesnesinin yeniden boyutlandırılmadan 3D sahnenin oranlarını değiştirir.

Aşağıdaki örnek, varsayılan veriyle bir [Column3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) grafiği oluşturur: üç seri ve dört kategori. Yükseklik oranları %50, %100 ve %200 olan üç sunumu kaydeder. Grafiğin konumu, genişliği ve yüksekliği sabit kalır. Veri, dönüş, derinlik, seri aralığı ve biçimlendirme üç dosyada da aynı; yalnızca yükseklik yüzdesi değişir.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 40, 30, 620, 460);
    chart.getRotation3D().setRotationX(java.newByte(20));
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setDepthPercents(100);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150);

    for (const heightPercent of [50, 100, 200]) {
        chart.getRotation3D().setHeightPercents(heightPercent);
        presentation.save("chart_height_" + heightPercent + ".pptx", slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Aşağıdaki görseller, eşdeğer .NET örneğindeki aynı yükseklik ayarlarını göstermekte ve Microsoft PowerPoint kullanılarak dışa aktarılmıştır. Daha düşük bir yüzde daha düz bir sahne üretirken, daha yüksek bir yüzde aynı grafik nesnesi içinde daha yüksek bir sahne üretir. PowerPoint ayrıca eksen işaret aralıklarını ve etiket yerleşimini sahneye sığdırmak için ayarlayabilir.

| Yükseklik: %50 | Yükseklik: %100 | Yükseklik: %200 |
| --- | --- | --- |
| ![3D sütun grafiği, yüksekliği genişliğinin %50'si olarak ayarlandı](height_percent_50.png) | ![3D sütun grafiği, yüksekliği genişliğinin %100'si olarak ayarlandı](height_percent_100.png) | ![3D sütun grafiği, yüksekliği genişliğinin %200'si olarak ayarlandı](height_percent_200.png) |

Bu yöntemler grafiğin farklı yönlerini kontrol eder:

| Yöntem | Etkisi |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) | 3D sahnenin yüksekliği, genişliğine yüzde olarak. |
| [Chart.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setheight/) | Slayttaki grafik nesnesinin yüksekliği, puan cinsinden. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | 3D sahnenin derinliği, genişliğine yüzde olarak. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | Derinlik ekseni boyunca seriler arasındaki boşluk, işaretçinin genişliğinin yüzde olarak. |

Yükseklik ayarı, silindir, koni ve piramit varyantları dahil olmak üzere 3D sütun ve çubuk grafiklerini, ayrıca 3D çizgi, alan, pasta ve yüzey grafiklerini etkiler. Yukarıdaki karşılaştırma doğrulanmış `Column3D` türünü kullanır. Bu ayar, 2D `ClusteredColumn` grafiğinin veya `BubbleWith3D` grafiğinin görünümünü değiştirmez; bu adlar [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) sınıfının üyeleridir. Diğer grafik görünüm ayarları için [Chart Formatting](/slides/tr/nodejs-java/chart-formatting/) bölümüne bakın.

## **Seriler Arasındaki Boşluğu Ayarlama**

[ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) kullanarak bir 3D grafiğin derinlik ekseni boyunca veri serileri arasındaki mesafeyi, işaretçinin genişliğine yüzde olarak kontrol edebilirsiniz. **0 ile 500** arasında değerler kullanılabilir: `0` boşluğu kaldırır, daha büyük değerler ise aralığı artırır. Sabit bir grafik derinliğiyle, boşluğu artırmak işaretçileri derinlik ekseninde daha ince yapar.

Grupla [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/) aracılığıyla erişin. Bu ayar, ona erişmek için kullanılan seriyi değil, gruptaki her seriye uygulanır. [ChartSeries.getGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getgapdepth/) derinlik boşluğunu döndürür ve üst grubun ayarını yansıtır.

Bu ayar, silindir, koni ve piramit varyantları dahil olmak üzere 3D sütun ve çubuk grafiklerini, ayrıca 3D çizgi ve alan grafiklerini etkiler. Görünüm, serilerin derinlik, kümelenmiş veya yığılmış olmasına bağlıdır. Ayrı seriler arasındaki boşlukları net bir şekilde karşılaştırmak için [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) sınıfından `ChartType.Column3D` kullanın.

| Yöntem | Etkisi |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | Derinlik ekseni boyunca seriler arasındaki boşluk, işaretçinin genişliğinin yüzde olarak. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) | Bitişik çubuk veya sütun kümeleri arasındaki boşluk, çubuk veya sütunun genişliğinin yüzde olarak. |
| [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | Grafik derinliği, grafik genişliğinin yüzde olarak. |

Aşağıdaki bağımsız örnek, üç seri ve dört kategori içeren varsayılan grafik verilerini kullanır. Veri, dönüş, boşluk genişliği ve grafik derinliği aynı olan iki sunumu kaydeder; yalnızca derinlik boşluğu değişir.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 40, 30, 620, 230);

    chart.getRotation3D().setRotationX(java.newByte(20));
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setDepthPercents(100);

    const series = chart.getChartData().getSeries().get_Item(0);
    const group = series.getParentSeriesGroup();
    group.setGapWidth(150);

    for (const gapDepth of [0, 500]) {
        group.setGapDepth(gapDepth);

        const fileName = "series_gap_depth_" + gapDepth + ".pptx";
        presentation.save(fileName, slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Aşağıdaki görseller, eşdeğer .NET örneğindeki aynı boşluk derinliği ayarlarını göstermekte ve Microsoft PowerPoint kullanılarak dışa aktarılmıştır.

| Boşluk derinliği: 0% | Boşluk derinliği: 500% |
| --- | --- |
| ![Derinlik ekseni boyunca seriler arasında boşluk olmayan 3D sütun grafiği](gap_depth_0.png) | ![Derinlik ekseni boyunca seriler arasında %500 boşluk olan 3D sütun grafiği](gap_depth_500.png) |

## **3D Seri Tipini ve Çubuk Şeklini Değiştirme**

Kümelenmiş silindir grafiğinde, ilk seri silindirik çubuk şekliyle başlar. Örnek, her değişiklikten önce ve sonra [ChartSeries.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/gettype/) ve [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getbar3dshape/) tarafından döndürülen tam sayı değerlerini yazdırır. Tablo, karşılık gelen sabit adlarını verir.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.ClusteredCylinder, 20, 20, 500, 300);
    const series = chart.getChartData().getSeries().get_Item(0);

    console.log(series.getType() + " | " + series.getBar3DShape());

    series.setType(slides.ChartType.ClusteredCone);
    console.log(series.getType() + " | " + series.getBar3DShape());

    series.setBar3DShape(slides.ChartShapeType.Box);
    console.log(series.getType() + " | " + series.getBar3DShape());

    presentation.save("series_shape.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| İlk seride yapılan değişiklik | Seri tipi | Çubuk şekli |
| --- | --- | --- |
| Create the chart | `ClusteredCylinder` | `Cylinder` |
| Set the series type to `ClusteredCone` | `ClusteredCone` | `Cone` |
| Set the bar shape to `Box` | `ClusteredColumn3D` | `Box` |

`Box` şekline ayarlamak, aynı zamanda seri tipini `ClusteredColumn3D` olarak değiştirir. Kodunuz seri tipine göre dallanıyorsa, şekli değiştirdikten sonra `series.getType()` çağırın. Atamadan önce önbelleğe alınan bir değer hâlâ `ClusteredCone` dalını seçecektir.

![PowerPoint karşılaştırması, ilk seriyi soldan sağa silindir, koni ve dikdörtgen sütunlar olarak gösterir](series-shapes.png)

## **SSS**

**Aspose.Slides'te hangi grafik tipleri 3D modunu destekler?**

Aspose.Slides, Column 3D, Clustered Column 3D, Stacked Column 3D ve %100 Stacked Column 3D gibi sütun grafiklerinin 3D varyantlarını ve [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) sınıfı aracılığıyla sunulan ilgili 3D tiplerini destekler. Tam ve güncel bir liste için, kurulu sürümünüzün API referansındaki [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) üyelerine bakın.

**Bir rapor veya web için 3D grafiğin raster görüntüsünü alabilir miyim?**

Evet. Bir grafiği [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) ile bir görüntüye ya da tüm slaytı [render the entire slide](/slides/tr/nodejs-java/convert-powerpoint-to-png/) adresindeki yöntemle PNG veya JPEG gibi formatlara dışa aktarabilirsiniz. Bu, raster bir ön izleme gerektiğinde veya grafiği belge, pano veya web sayfasına PowerPoint gerektirmeden gömmek istediğinizde faydalıdır.

**Büyük 3D grafiklerin oluşturulması ve render edilmesi ne kadar performanslıdır?**

Performans, veri hacmine ve görsel karmaşıklığa bağlıdır. En iyi sonuçlar için 3D efektlerini minimal tutun, duvar ve çizim alanlarında ağır doku kullanımından kaçının, mümkün olduğunda seri başına veri nokta sayısını sınırlayın ve hedef gösterim ya da baskı ihtiyaçlarına uygun bir çözünürlük ve boyutla çıkışa render edin.