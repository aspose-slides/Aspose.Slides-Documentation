---
title: Python ile Sunumlarda 3D Grafikleri Özelleştirme
linktitle: 3D Grafik
type: docs
url: /tr/python-net/3d-chart/
keywords:
- 3D grafik
- dönme
- derinlik
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile PowerPoint sunumlarında 3D grafikler oluşturun. Python örnekleriyle döndürmeyi, yükseklik oranlarını, grafik derinliğini ve seriler arasındaki boşluğu ayarlayın."
---
## **Genel Bakış**

Aspose.Slides for Python via .NET, 3D bir grafiğin görünümünü [Chart.rotation_3d](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/rotation_3d/) özelliği aracılığıyla özelleştirmenizi sağlar. Bu makale, döndürmeyi, yükseklik oranlarını, derinliği, dik açı eksenlerini ve seriler arasındaki boşluğu nasıl ayarlayacağınızı ve ardından sunumu PPTX formatında nasıl kaydedeceğinizi gösterir.

## **3D Grafik Döndürmesini ve Derinliğini Ayarlama**

Aşağıdaki örnek bir [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) oluşturur ve [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) yöntemini kullanarak ilk slaytına yığılmış bir 3D sütun grafiği ekler. Varsayılan serileri ve kategorileri, her biri üç değer içeren iki seriyle değiştirir. Çalışma sayfası indeksi `0`, grafiğin ilk veri çalışma sayfasını tanımlar; satır `0` seri adlarını, sütun `0` ise kategori etiketlerini tutar.

[rotation_x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_x/) ve [rotation_y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/rotation_y/) özellikleri, grafiğin döndürmesini sırasıyla 40 ve 270 derece olarak ayarlar. [depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) derinliğini genişliğinin %150'si olarak belirler, [right_angle_axes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/right_angle_axes/) ise perspektif yerine dik açı eksenlerini etkinleştirir. Ortaya çıkan sunum, bu 3D görünüm ayarlarıyla doldurulmuş grafik içerir.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    
    values = [[20, 50, 30], [30, 10, 60]]

    for category_index in range(3):
        category_cell = workbook.get_cell(worksheet_index, category_index + 1, 0, f"Category {category_index + 1}")
        chart.chart_data.categories.add(category_cell)

    for series_index in range(2):
        series_cell = workbook.get_cell(worksheet_index, 0, series_index + 1, f"Series {series_index + 1}")
        series = chart.chart_data.series.add(series_cell, chart.type)

        for category_index in range(3):
            value_cell = workbook.get_cell(worksheet_index, category_index + 1, series_index + 1, values[series_index][category_index])
            series.data_points.add_data_point_for_bar_series(value_cell)

    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```

## **3D Grafik Yüzeyine Resim Doldurması Uygulama**

Bir 3D grafiğin [side wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/side_wall/), [back wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/) ve [floor](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/) yüzeylerini bağımsız olarak doldurabilirsiniz. Yüzeyin [fill type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) özelliğini `PICTURE` olarak ayarlayın ve bir görüntü atayın. Görüntünün tek bir kopyasının yüzey boyunca yayılmasını sağlamak için hem [picture fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/) hem de yüzeyin [picture type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartwall/picture_type/) özelliğini `STRETCH` olarak ayarlayın.

Çalışma dizinine [arrow.png](arrow.png) kaydedin. Örnek, grafiği döndürür ve dik eksendeki maksimum değeri artırarak zemin yüzeyinin sütunlar arasında görünür olmasını sağlar. Slaytı iki kez klonlar ve ardından ok işaretini her slaytta farklı bir yüzeye uygular. Üç grafik de aynı veri, görünüm açısı ve arka planı paylaşır.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 20, 30, 680, 480)
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 30
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 24

    back_slide = presentation.slides.add_clone(slide)
    floor_slide = presentation.slides.add_clone(slide)
    back_chart = back_slide.shapes[0]
    floor_chart = floor_slide.shapes[0]

    with open("arrow.png", "rb") as image_file:
        image_bytes = image_file.read()
    arrow = presentation.images.add_image(image_bytes)

    for surface in (chart.side_wall, back_chart.back_wall, floor_chart.floor):
        fill = surface.format.fill
        fill.fill_type = slides.FillType.PICTURE
        fill.picture_fill_format.picture.image = arrow
        fill.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        surface.picture_type = charts.PictureType.STRETCH

    presentation.save("chart-surfaces.pptx", slides.export.SaveFormat.PPTX)
```

Microsoft PowerPoint, üç slaytı aşağıdaki gibi gösterir.

| Yan duvar | Arka duvar | Zemin |
| --- | --- | --- |
| ![Grafiğe yan duvar boyunca işaret eden ok](side-wall.png) | ![Arka duvar boyunca sağa işaret eden ok](back-wall.png) | ![Sütunlar arasındaki zeminde sağa işaret eden ok](floor.png) |

## **3D Grafiğin Yükseklik Oranlarını Ayarlama**

[Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) özelliğini kullanarak bir 3D grafiğin yüksekliğini genişliğinin yüzdesi olarak ayarlayabilirsiniz. Bu, slayttaki grafik nesnesinin boyutunu değiştirmeden 3D sahnenin oranlarını değiştirir.

Sıradaki örnek, varsayılan veriyle bir [COLUMN_3D](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) grafiği oluşturur: üç seri ve dört kategori. Yükseklik oranları %50, %100 ve %200 olan üç sunumu kaydeder. Grafiğin konumu, genişliği ve yüksekliği sabit kalır. Veri, döndürme, derinlik, seri aralığı ve biçimlendirme üç dosyada da aynıdır; sadece yükseklik yüzdesi değişir.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 40, 30, 620, 460)
    chart.rotation_3d.rotation_x = 20
    chart.rotation_3d.rotation_y = 30
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.depth_percents = 100
    chart.chart_data.series[0].parent_series_group.gap_depth = 150

    for height_percent in (50, 100, 200):
        chart.rotation_3d.height_percents = height_percent
        presentation.save(f"chart_height_{height_percent}.pptx", slides.export.SaveFormat.PPTX)
```

Aşağıdaki görseller, oluşturulan sunumlardan Microsoft PowerPoint kullanılarak dışa aktarıldı. Daha düşük yüzde, daha düz bir sahne oluştururken, daha yüksek yüzde aynı grafik nesnesi içinde daha yüksek bir sahne oluşturur. PowerPoint ayrıca eksen işaretçi aralıklarını ve etiket yerleşimini sahneye uyacak şekilde ayarlayabilir.

| Yükseklik: 50% | Yükseklik: 100% | Yükseklik: 200% |
| --- | --- | --- |
| ![Genişliğinin %50'si olarak ayarlanmış 3D sütun grafiği](height_percent_50.png) | ![Genişliğinin %100'si olarak ayarlanmış 3D sütun grafiği](height_percent_100.png) | ![Genişliğinin %200'si olarak ayarlanmış 3D sütun grafiği](height_percent_200.png) |

Bu özellikler grafiğin farklı yönlerini kontrol eder:

| Özellik | Etkisi |
| --- | --- |
| [Rotation3D.height_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/height_percents/) | 3D sahnenin yüksekliği, genişliğinin yüzdesi olarak. |
| [Chart.height](https://reference.aspose.com/slides/python-net/aspose.slides/shape/height/) | Slayttaki grafik nesnesinin yüksekliği, nokta cinsinden. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | 3D sahnenin derinliği, genişliğinin yüzdesi olarak. |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | Derinlik ekseni boyunca seriler arasındaki boşluk, işaretçi genişliğinin yüzdesi olarak. |

Yükseklik ayarı, silindir, koni ve piramit varyantlarını içeren 3D sütun ve çubuk grafiklerini, ayrıca 3D çizgi, alan, pasta ve yüzey grafiklerini etkiler. Yukarıdaki karşılaştırma, doğrulanmış `COLUMN_3D` türünü kullanır. Ayar, 2D `CLUSTERED_COLUMN` grafiği veya `BUBBLE_WITH_3D` grafiğinin görünümünü değiştirmez; bu adlar [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) enum üyesidir. Diğer grafik görünüm ayarları için [Chart Formatting](/slides/tr/python-net/chart-formatting/) bölümüne bakın.

## **Seriler Arasındaki Boşluğu Ayarlama**

[ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) özelliğini, 3D grafiğin derinlik ekseni boyunca veri serileri arasındaki mesafeyi işaretçi genişliğinin yüzdesi olarak kontrol etmek için kullanın. **0 ile 500** arasında (0 ve 500 dahil) değerler kullanın: `0` boşluğu kaldırırken, daha büyük değerler aralığı artırır. Sabit bir grafik derinliğiyle, boşluğu artırmak işaretçileri derinlik ekseni boyunca daha ince yapar.

Gruba, [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) aracılığıyla erişin. Ayar, o gruptaki tüm serilere uygulanır, sadece erişilen seriye değil. [ChartSeries.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_depth/) yalnızca okunabilir ve üst grup ayarını yansıtır.

Bu ayar, silindir, koni ve piramit varyantlarını içeren 3D sütun ve çubuk grafiklerini, ayrıca 3D çizgi ve alan grafiklerini etkiler. Görünüm, serilerin derinlik, kümeleme veya yığma şeklinde düzenlenip düzenlenmediğine bağlıdır. Ayrı seriler arasındaki boşlukların net bir karşılaştırması için [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) enumundan `ChartType.COLUMN_3D` kullanın.

| Özellik | Etkisi |
| --- | --- |
| [ChartSeriesGroup.gap_depth](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_depth/) | Derinlik ekseni boyunca seriler arasındaki boşluk, işaretçi genişliğinin yüzdesi olarak. |
| [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) | Yan yana çubuk veya sütun kümeleri arasındaki boşluk, çubuk veya sütun genişliğinin yüzdesi olarak. |
| [Rotation3D.depth_percents](https://reference.aspose.com/slides/python-net/aspose.slides.charts/rotation3d/depth_percents/) | Grafiğin genel derinliği, grafik genişliğinin yüzdesi olarak. |

Aşağıdaki bağımsız örnek, üç seri ve dört kategori içeren varsayılan grafik verisini kullanır. Veri, döndürme, boşluk genişliği ve grafik derinliği aynı olan iki sunumu kaydeder; sadece boşluk derinliği değişir.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 40, 30, 620, 230)

    chart.rotation_3d.rotation_x = 20
    chart.rotation_3d.rotation_y = 30
    chart.rotation_3d.depth_percents = 100

    series = chart.chart_data.series[0]
    group = series.parent_series_group
    group.gap_width = 150

    for gap_depth in (0, 500):
        group.gap_depth = gap_depth
        file_name = f"series_gap_depth_{gap_depth}.pptx"
        presentation.save(file_name, slides.export.SaveFormat.PPTX)
```

Aşağıdaki görseller, oluşturulan sunumlardan Microsoft PowerPoint kullanılarak dışa aktarıldı.

| Boşluk derinliği: 0% | Boşluk derinliği: 500% |
| --- | --- |
| ![Derinlik ekseni boyunca seriler arasında boşluk olmadan 3D sütun grafiği](gap_depth_0.png) | ![Derinlik ekseni boyunca seriler arasında %500 boşluklu 3D sütun grafiği](gap_depth_500.png) |

## **3D Seri Tipini ve Çubuk Şeklini Değiştirme**

Kümeleme silindir grafikinde, ilk seri silindirik çubuklarla başlar. Örnek, her değişiklikten önce ve sonra [ChartSeries.type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/type/) ve [ChartSeries.bar_3d_shape](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/bar_3d_shape/) değerlerini okur.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_CYLINDER, 20, 20, 500, 300)
    series = chart.chart_data.series[0]
    
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    series.type = charts.ChartType.CLUSTERED_CONE
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    series.bar_3d_shape = charts.ChartShapeType.BOX
    print(f"{series.type.name} | {series.bar_3d_shape.name}")

    presentation.save("series_shape.pptx", slides.export.SaveFormat.PPTX)
```

| İlk seriye yapılan değişiklik | `type` | `bar_3d_shape` |
| --- | --- | --- |
| Grafiği oluştur | `CLUSTERED_CYLINDER` | `CYLINDER` |
| `type` değerini `CLUSTERED_CONE` olarak ayarla | `CLUSTERED_CONE` | `CONE` |
| `bar_3d_shape` değerini `BOX` olarak ayarla | `CLUSTERED_COLUMN_3D` | `BOX` |

![PowerPoint karşılaştırması, ilk serinin soldan sağa silindir, koni ve dikdörtgen sütunlar olarak gösterilmesini gösterir](series-shapes.png)

## **SSS**

**Aspose.Slides'ta hangi grafik tipleri 3D modunu destekler?**

Aspose.Slides, sütun grafiklerinin 3D varyantlarını destekler; bunlar Column 3D, Clustered Column 3D, Stacked Column 3D ve %100 Stacked Column 3D'yi içerir ve ayrıca [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) enumu aracılığıyla sunulan ilgili 3D tipleri de kapsar. Tam ve güncel bir liste için, yüklü sürümünüzün API referansındaki [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) üyelerine bakın.

**Bir rapor veya web için 3D grafiğin raster görüntüsünü alabilir miyim?**

Evet. Bir grafiği, [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) yöntemiyle bir görüntüye dışa aktarabilir veya [tüm slaytı render ederek](/slides/tr/python-net/convert-powerpoint-to-png/) PNG veya JPEG gibi formatlara dönüştürebilirsiniz. Bu, bir raster önizleme ihtiyacınız olduğunda veya grafiği PowerPoint gerektirmeden belgeler, kontrol panelleri veya web sayfalarına yerleştirmek istediğinizde yararlıdır.

**Büyük 3D grafikleri oluşturma ve render etme performansı nasıldır?**

Performans, veri miktarı ve görsel karmaşıklığa bağlıdır. En iyi sonuçlar için 3D efektleri minimumda tutun, duvar ve grafik alanlarında ağır dokulardan kaçının, mümkün olduğunda seri başına veri nokta sayısını sınırlayın ve hedef görüntüleme veya baskı ihtiyaçlarına uygun çözünürlük ve boyutlarda bir çıktı oluşturun.