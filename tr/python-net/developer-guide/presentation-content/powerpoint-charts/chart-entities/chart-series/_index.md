---
title: Python ile Sunumlarda Grafik Veri Serilerini Yönetme
linktitle: Veri Serileri
type: docs
url: /tr/python-net/chart-series/
keywords:
- grafik serileri
- seri çakışması
- seri rengi
- kategori rengi
- seri adı
- veri noktası
- seri boşluğu
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Python ile sunumlarda grafik serilerini, veri noktalarını, çalışma kitabı hücrelerini, biçimlendirmeyi, çakışmayı, boşluk genişliğini ve negatif değerleri nasıl yöneteceğinizi öğrenin."
---
## **Genel Bakış**

Bir grafik, çizilen verilerini bir grafik veri çalışma kitabında depolar. Bir [ChartSeries](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartseries/) bir ilişkili değer kümesini temsil eder ve serideki her bir [ChartDataPoint](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdatapoint/) bir veya daha fazla çalışma kitabı hücresine işaret eder. [ChartCategory](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartcategory/) nesneleri, seriler tarafından paylaşılan etiketleri veya gruplama değerlerini sağlar. Seri adı, kategoriler ve nokta değerleri bu nedenle yalnızca görüntü metni olarak saklanmaz, [ChartDataCell](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdatacell/) nesnelerine bağlanır.

Tipik bir kategori grafiği için, varsayılan çalışma kitabı seri adları için satır 0, kategori adları için sütun 0 ve kalan hücreleri seri değerleri için kullanır. [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) yöntemine geçirilen çalışma sayfası, satır ve sütun indisleri sıfır tabanlıdır. Bu düzen, varsayılan veri ile bir grafik oluştururken kullanışlıdır, ancak her mevcut grafiğin bunu kullandığını varsaymayın. Yüklenmiş bir sunumda, çalışma kitabı değerlerini değiştirmeden önce seriler, kategoriler ve veri noktaları tarafından başvurulan hücreleri inceleyin.

Grafik ayarlarının üç farklı kapsamı vardır:

- Seri düzeyindeki ayarlar, örneğin [ChartSeries.format](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartseries/format/), bir serideki tüm noktalar için varsayılan görünümü sağlar.
- Veri noktası ayarları, örneğin [ChartDataPoint.format](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdatapoint/format/), bir nokta için seri görünümünü geçersiz kılar.
- Grup ayarları, aynı [ChartSeriesGroup](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartseriesgroup/) içinde yer alan uyumlu serilere uygulanır. [ChartSeries.parent_series_group](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartseries/parent_series_group/) aracılığıyla gruba erişin ve çakışma veya boşluk genişliği gibi seçenekleri ayarlayın.

Açık bir nokta veya seri dolgusu belirlenmediğinde, grafik stili ve teması otomatik görünümü belirler. Hem seri hem de nokta biçimlendirmesi varsa, nokta biçimlendirmesi o nokta için öncelikli olur.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Grafik Serisi Çakışmasını Ayarla**

[ChartSeries.overlap](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartseries/overlap/) bir 2D grafikte çubukların veya sütunların ne kadar çakıştığını -%100 ile %100 arasında rapor eder. Bu, üst seri grubundaki ayarın yalnızca okunabilir bir yansımasıdır. [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartseriesgroup/overlap/) ayarlanarak grup içindeki tüm uyumlu seriler güncellenir. Bu seçenek, gruplanmış çubuk veya sütun gösteren grafik türlerine uygulanır; bir kombinasyon grafiğindeki ilgili olmayan seri gruplarını etkilemez.

Aşağıdaki örnek, ilk seriyi içeren grup için çakışmayı ayarlar:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # Yeni grafik örnek seriler, kategoriler ve değerler içerir.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Seri çakışması](series_overlap.png)

## **Seri Dolgu Rengini Değiştir**

Bir serinin tümü için varsayılan dolguyu ayarlamak üzere [ChartSeries.format](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartseries/format/) kullanın. Bir nokta zaten açık bir dolguya sahipse, onun [ChartDataPoint.format](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdatapoint/format/) ayarı o nokta için seri dolgusunu geçersiz kılar.

Aşağıdaki örnek, ilk seriye katı mavi bir dolgu uygular:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = drawing.Color.blue

    presentation.save("series_color.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Serinin rengi](series_color.png)

## **Seri Adını Değiştir**

Bir seri adı grafik veri çalışma kitabında depolanır ve genellikle lejende gösterilir. Küme sütun grafiği için oluşturulan varsayılan çalışma kitabında, B1 hücresi satır 0, sütun 1 konumunda olup ilk serinin adını içerir. Aşağıdaki örnekteki adlandırılmış sabitler bu yapıyı açıkça gösterir:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
worksheet_index = 0
series_name_row_index = 0
first_series_column_index = 1

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    workbook = chart.chart_data.chart_data_workbook
    series_name_cell = workbook.get_cell(worksheet_index, series_name_row_index, first_series_column_index)
    series_name_cell.value = "Revenue"

    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

Ayrıca, zaten [ChartSeries.name](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartseries/name/) tarafından başvurulan hücreyi güncelleyebilirsiniz. Bu yaklaşım, mevcut bir grafikte belirli bir satır ve sütun varsayımını önler:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
first_name_cell_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series_name_cell = series.name.as_cells[first_name_cell_index]
    series_name_cell.value = "Revenue"

    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Seri adı](series_name.png)

## **Otomatik Seri Dolgu Rengini Al**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) seri indeksine ve grafik stiline göre hesaplanan rengi döndürür. Bu, seri dolgusunun açıkça tanımlanmadığı durumlarda kullanılan renktir. Yöntem çağrısı hesaplanan rengi okur; yeni bir dolgu atamaz.

Aşağıdaki örnek, her varsayılan serinin otomatik rengini yazdırır:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series_count = len(chart.chart_data.series)
    for series_index in range(series_count):
        series = chart.chart_data.series[series_index]
        automatic_color = series.get_automatic_series_color()
        print(f"Series {series_index}: {automatic_color.name}")
```

Varsayılan grafik stili için örnek çıktı:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Kesin renkler grafik stili ve temaya bağlıdır.

## **Bir Grafik Serisi için Ters Dolgu Rengini Ayarla**

Çubuk, sütun ve baloncuk serileri için, [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartseries/invert_if_negative/) negatif değerleri farklı bir dolgu ile gösterebilir. Normal seri dolgusunu katı olarak ayarlayın, terslemeyi etkinleştirin ve negatif değer rengini [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) üzerinden atayın. Negatif sayılar çalışma kitabında değişmeden kalır; yalnızca gösterim rengi değişir.

Aşağıdaki örnek, varsayılan grafik verisini tek bir seri ile değiştirir. Çalışma sayfası satırı 0 seri adını, sütun 0 kategori adlarını ve sütun 1 değerleri içerir:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
worksheet_index = 0
header_row_index = 0
category_column_index = 0
first_series_column_index = 1
first_data_row_index = 1

category_names = ["Category 1", "Category 2", "Category 3"]
series_values = [-20, 50, -30]

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    chart_data = chart.chart_data
    workbook = chart_data.chart_data_workbook

    chart_data.series.clear()
    chart_data.categories.clear()

    series_name_cell = workbook.get_cell(worksheet_index, header_row_index, first_series_column_index, "Series 1")
    series = chart_data.series.add(series_name_cell, chart.type)

    category_count = len(category_names)
    for category_index in range(category_count):
        data_row_index = first_data_row_index + category_index
        category_name = category_names[category_index]
        series_value = series_values[category_index]

        category_cell = workbook.get_cell(worksheet_index, data_row_index, category_column_index, category_name)
        chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(worksheet_index, data_row_index, first_series_column_index, series_value)
        series.data_points.add_data_point_for_bar_series(value_cell)

    automatic_series_color = series.get_automatic_series_color()
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = automatic_series_color
    series.invert_if_negative = True
    series.inverted_solid_fill_color.color = drawing.Color.red

    presentation.save("inverted_solid_fill_color.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Ters katı dolgu rengi](inverted_solid_fill_color.png)

Bir nokta için terslemeyi [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) aracılığıyla etkinleştirebilirsiniz. Aşağıdaki örnekte, seri için tersleme devre dışı bırakılır ve yalnızca seçilen nokta için etkinleştirilir. Etkiyi göstermek amacıyla nokta da negatif bir değer alır:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
target_data_point_index = 2
negative_value = -30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    automatic_series_color = series.get_automatic_series_color()
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = automatic_series_color
    series.inverted_solid_fill_color.color = drawing.Color.red
    series.invert_if_negative = False

    data_point = series.data_points[target_data_point_index]
    data_point.value.as_cell.value = negative_value
    data_point.invert_if_negative = True

    presentation.save("data_point_invert_color_if_negative.pptx", slides.export.SaveFormat.PPTX)
```

## **Belirli Bir Veri Noktasının Değerini Temizle**

Diğer noktaları kaldırmadan bir noktayı boş bırakmak için ilgili çalışma kitabı hücresini `None` olarak ayarlayın. Sütun grafiği için çizilen değer [ChartDataPoint.value](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdatapoint/value/) üzerinden elde edilir. Veri noktası aynı kategori konumunda kalır, ancak grafik değerini, grafik boş değer ayarlarına göre boş kabul eder.

Aşağıdaki örnek, ilk seride yalnızca ikinci noktayı temizler:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
target_data_point_index = 1

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    data_point = series.data_points[target_data_point_index]
    data_point.value.as_cell.value = None

    presentation.save("clear_data_point_value.pptx", slides.export.SaveFormat.PPTX)
```

Saçılım (scatter) grafiklerinde ayrı X ve Y hücreleri, baloncuk grafiklerinde ise bir boyut hücresi bulunur. Kaldırmak istediğiniz değeri temsil eden hücreyi yalnızca temizleyin. Diğer noktaları tutmak istiyorsanız [ChartDataPointCollection.clear](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdatapointcollection/clear/) metodunu çağırmayın; bu metod koleksiyondaki tüm veri noktalarını siler.

## **Seri Boşluk Genişliğini Ayarla**

Boşluk genişliği, bitişik çubuk veya sütun kümeleri arasındaki boşluktur ve çubuk veya sütun genişliğinin yüzdesi olarak ifade edilir. Çakışma gibi, bu ayar bir seriye değil, üst seri grubuna aittir. Grup için bir kez [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) ayarlayın. Daha büyük bir değer kümeler arasındaki boşluğu artırır; daha küçük bir değer onları daha sıkıştırır.

Aşağıdaki örnek boşluk genişliğini değiştirir ve yalnızca son sunumu kaydeder:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
gap_width_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.gap_width = gap_width_percent

    presentation.save("gap_width_30.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Boşluk genişliği](gap_width.png)

## **SSS**

**Hangi grafik türleri veri serilerini destekler?**

[ChartType](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/charttype/) enum’ı tarafından temsil edilen tüm grafik türleri veri kullanır, ancak serileri aynı değer yapısına veya ayarlara sahip değildir. Örneğin, kategori grafiklerinde kategori ve değerler, saçılım grafiklerinde X ve Y değerleri, baloncuk grafiklerinde ise ek olarak baloncuk boyutları bulunur. Seri tipine uygun veri noktası oluşturma metodunu kullanın. Çakışma ve boşluk genişliği gibi seçenekler yalnızca uyumlu çubuk veya sütun gruplarına uygulanır.

**Bir grafik serisi grubu nedir?**

[ChartSeriesGroup](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartseriesgroup/) aynı grup‑seviyesi çizim ayarlarını paylaşan uyumlu serileri içerir. Bir kombinasyon grafiği birden fazla grup içerebilir; bu yüzden bir seriden ulaşarak grup ayarlarını değiştirmek, grafikteki tüm serileri zorunlu olarak etkilemez.

**Yeni oluşturulan bir grafik varsayılan veri içerir mi?**

Evet. Varsayılan olarak [ShapeCollection.add_chart](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/add_chart/) örnek seriler, kategoriler ve değerler oluşturur. Bu hücreleri düzenleyebilir veya tamamen özel bir veri kümesi eklemeden önce serileri ve kategori koleksiyonlarını temizleyebilirsiniz. Aşırı yükleme (overload) aynı zamanda varsayılan veri olmadan bir grafik oluşturabilir.

**Grafik nesneleri çalışma kitabı hücrelerine nasıl bağlanır?**

Seri adları, kategori etiketleri ve veri‑nokta değerleri bir [ChartDataWorkbook](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdataworkbook/) içindeki hücrelere işaret eder. Başvurulan bir hücre değiştirildiğinde ilgili grafik öğesi güncellenir. Özel veri oluştururken, her noktanın istenen kategori altında çizilebilmesi için kategori satırları ve seri‑değer satırlarının hizalı olduğundan emin olun.

**Bir seriyi tamamen temizlemek yerine tek bir noktayı nasıl temizlerim?**

İlgili değer hücresini `None` yaparak noktanın kategori konumunu boş bir nokta olarak tutabilirsiniz. [ChartDataPointCollection.clear](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdatapointcollection/clear/) metodunu yalnızca seri içindeki tüm noktaları kaldırmak istediğinizde kullanın. Kategorileri de kaldırıyorsanız, her serinin değerlerini kategori koleksiyonuyla uyumlu tutmak için güncelleyin.

**Boş noktalar nasıl görüntülenir?**

Sonuç, grafik türüne ve [Chart.display_blanks_as](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chart/display_blanks_as/) ayarına bağlıdır. Desteklenen grafikler boşları boşluk olarak, sıfır değer olarak ya da bitişik noktaları bağlayarak gösterebilir. Sunumunuzdaki eksik verinin anlamına en uygun ayarı seçin.

**Negatif değerler nasıl formatlanır?**

Desteklenen çubuk, sütun ve baloncuk serileri için [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartseries/invert_if_negative/) etkinleştirilir ve [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) aracılığıyla negatif değer rengi atanır. Tek bir nokta için davranışı [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) ile geçersiz kılabilirsiniz. Bu özellikler yalnızca biçimlendirmeyi etkiler; saklanan sayısal değerler değişmez.

**Hem seri hem de nokta formatlandığında hangi formatlama geçerli olur?**

Açık veri‑nokta formatlaması o nokta için önceliklidir. Diğer noktalar, açık bir seri formatı varsa onu, aksi takdirde otomatik grafik stili ve teması tarafından belirlenen rengi kullanır. Çakışma ve boşluk genişliği gibi grup özellikleri yerleşimi kontrol eder ve nokta‑seviyesi format geçersiz kılmalarını etkilemez.

**Bir grafiğin içerebileceği seri sayısında bir sınırlama var mı?**

Aspose.Slides ayrı bir sabit seri sayısı sınırlaması getirmez. Pratikte, sunum dosyası kısıtlamaları, mevcut bellek, işleme süresi ve grafik okunabilirliği faydalı bir sınır belirler.

**Sütunlar çok yakın veya çok uzak olduğunda ne değiştirmeliyim?**

Uygun üst seri grubunda [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) ayarını yapın. Değeri artırarak kümeler arasındaki boşluğu genişletebilir, azaltarak kümeleri birbirine daha yakın hâle getirebilirsiniz.