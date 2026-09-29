---
title: Python ile Sunumlarda Grafik Veri Serilerini Yönetme
linktitle: Veri Serileri
type: docs
url: /tr/python-net/chart-series/
keywords:
- grafik serisi
- seri örtüşmesi
- seri rengi
- kategori rengi
- seri adı
- veri noktası
- seri boşluğu
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Python ile sunumlarda grafik serilerini, veri noktalarını, çalışma kitabı hücrelerini, biçimlendirmeyi, örtüşmeyi, boşluk genişliğini ve negatif değerleri nasıl yöneteceğinizi öğrenin."
---
## **Genel Bakış**

Bir grafik, çizilen verileri bir grafik veri çalışma kitabında saklar. Bir [ChartSeries](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartseries/) bir dizi ilişkili değeri temsil eder ve serideki her [ChartDataPoint](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdatapoint/) bir veya daha fazla çalışma kitabı hücresine başvurur. [ChartCategory](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartcategory/) nesneleri seriler tarafından paylaşılan etiketleri veya gruplama değerlerini sağlar. Serinin adı, kategoriler ve nokta değerleri bu nedenle yalnızca gösterim metni olarak saklanmak yerine [ChartDataCell](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdatacell/) nesnelerine bağlanır.

Tipik bir kategori grafiği için, varsayılan çalışma kitabı satır 0’ı seri adları için, sütun 0’ı kategori adları için ve kalan hücreleri seri değerleri için kullanır. [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) yöntemine geçirilen çalışma sayfası, satır ve sütun indeksleri sıfır‑tabanlıdır. Bu düzen, varsayılan verilerle bir grafik oluşturduğunuzda kullanışlıdır, ancak her mevcut grafiğin bunu kullandığını varsaymayın. Yüklenmiş bir sunumda, çalışma kitabı değerlerini değiştirmeden önce seriler, kategoriler ve veri noktaları tarafından başvurulan hücreleri inceleyin.

Grafik ayarları üç farklı kapsamda bulunur:

- Seri‑seviye ayarları, örneğin [ChartSeries.format](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartseries/format/) bir serideki tüm noktalar için varsayılan görünümü sağlar.
- Veri‑noktası ayarları, örneğin [ChartDataPoint.format](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdatapoint/format/) bir nokta için seri görünümünü geçersiz kılar.
- Grup ayarları, aynı [ChartSeriesGroup](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartseriesgroup/) içinde bulunan uyumlu serilere uygulanır. Örtüşme veya boşluk genişliği gibi seçenekleri ayarlamanız gerektiğinde, [ChartSeries.parent_series_group](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartseries/parent_series_group/) üzerinden gruba erişin.

Açıkça bir nokta veya seri dolgu ayarı belirlenmediğinde, grafik stili ve teması otomatik görünümü belirler. Hem seri hem de nokta biçimlendirmesi mevcutsa, nokta biçimlendirmesi o nokta için önceliklidir.

![grafik-serileri-powerpoint](chart-series-powerpoint.png)

## **Grafik Serisi Örtüşmesini Ayarlama**

[ChartSeries.overlap](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartseries/overlap/) 2B bir grafikte çubukların veya sütunların ne kadar örtüştüğünü -%100’den %100’e kadar bildirir. Bu, üst seriler grubundaki ayarın sadece okunabilir bir yansımasıdır. Tüm uyumlu serileri güncellemek için [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartseriesgroup/overlap/) ayarlayın. Bu seçenek, gruplanmış çubuk veya sütun gösteren grafik türlerine uygulanır; birleşik bir grafikte ilgili olmayan seri gruplarını etkilemez.

Aşağıdaki örnek, ilk seriyi içeren grup için örtüşmeyi ayarlar:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # Yeni grafik örnek serileri, kategorileri ve değerleri içerir.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Seri örtüşmesi](series_overlap.png)

## **Seri Dolgu Rengini Değiştirme**

Tüm bir seri için varsayılan dolgu ayarlamak üzere [ChartSeries.format](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartseries/format/) kullanın. Bir nokta zaten açık bir dolguye sahipse, onun [ChartDataPoint.format](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdatapoint/format/) ayarı o nokta için seri dolgusunu geçersiz kılar.

Aşağıdaki örnek, ilk seriye katı mavi dolgu uygular:

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

![Seri rengi](series_color.png)

## **Seri Adını Değiştirme**

Seri adı grafik veri çalışma kitabında saklanır ve genellikle lejende gösterilir. Kümeleme sütun grafiği için oluşturulan varsayılan çalışma kitabında, B1 hücresi satır 0, sütun 1 konumunda bulunur ve ilk serinin adını içerir. Aşağıdaki örnekteki adlandırılmış sabitler bu yapıyı açıkça belirtir:

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

Ayrıca [ChartSeries.name](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartseries/name/) tarafından zaten başvurulan hücreyi güncelleyebilirsiniz. Bu yaklaşım mevcut bir grafikte belirli bir satır ve sütun varsayımını önler:

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

## **Otomatik Seri Dolgu Rengini Alma**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) seri indeksine ve grafik stiline göre hesaplanan rengi döndürür. Bu, seri dolgu açıkça tanımlanmadığında kullanılan renktir. Yöntemi çağırmak hesaplanan rengi okur; yeni bir dolgu atamaz.

Aşağıdaki örnek, her varsayılan seri için otomatik rengi yazdırır:

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

Kesin renkler grafik stili ve temasına bağlıdır.

## **Bir Grafik Serisi için Ters Doldurma Rengini Ayarlama**

Çubuk, sütun ve balon serileri için, [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartseries/invert_if_negative/) negatif değerleri farklı bir dolgu ile gösterebilir. Normal seri dolgusunu katı olarak ayarlayın, ters çevirmeyi etkinleştirin ve negatif değer rengini [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) ile atayın. Negatif sayılar çalışma kitabında değişmeden kalır; yalnızca gösterim renkleri değişir.

Aşağıdaki örnek, varsayılan grafik verisini bir seriyle değiştirir. Çalışma sayfası satır 0 seri adını, sütun 0 kategori adlarını ve sütun 1 değerleri içerir:

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

Bir nokta için ters çevirme, [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) ile etkinleştirilebilir. Aşağıdaki örnekte, seri için ters çevirme devre dışı bırakılmış ve yalnızca seçilen nokta için etkinleştirilmiştir. Etkinin görünür olması için nokta negatif bir değer almıştır:

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

## **Belirli Bir Veri Noktası Değerini Temizleme**

Diğer noktaları kaldırmadan bir noktayı boş bırakmak için, onun arka uç çalışma kitabı hücresini `None` olarak ayarlayın. Bir sütun grafiğinde, çizilen değer [ChartDataPoint.value](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdatapoint/value/) üzerinden elde edilebilir. Veri noktası aynı kategori konumunda kalır, ancak grafik boş‑değer ayarlarına göre değerini boş olarak kabul eder.

Aşağıdaki örnek, ilk serideki sadece ikinci noktayı temizler:

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

Saçılım (scatter) grafikler ayrı X ve Y hücreleri kullanır, balon grafikler ayrıca bir boyut hücresi kullanır. Kaldırmak istediğiniz değeri temsil eden hücreyi yalnızca temizleyin. Diğer noktaları korumak istediğinizde [ChartDataPointCollection.clear](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdatapointcollection/clear/) metodunu çağırmayın; bu metot koleksiyondaki tüm veri noktalarını siler.

## **Boş Hücrelerin Görüntülenmesini Kontrol Etme**

Değer içeren gizli hücreler, boş hücrelerden ayrı bir durumdur. Gizli çalışma sayfası satır ve sütunlarından veri dahil etme veya dışlama hakkında bilgi için, [Include Data from Hidden Rows and Columns](/slides/tr/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns) bölümüne bakın.

Boş bir çalışma kitabı hücresi eksik veriyi temsil eder; `0` içeren bir hücre bilinen bir sayı değeridir. Bir hücreyi boş yapmak için [ChartDataCell.value](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdatacell/value/) değerini `None` olarak ayarlayın. Sayısal sıfır, boş hücre ayarından bağımsız olarak sıfır olarak kalır.

Boş hücrelerin grafikte nasıl gösterileceğini seçmek için [Chart.display_blanks_as](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chart/display_blanks_as/) kullanın. Bu ayar tüm grafik için geçerlidir. Boşlukların nasıl çizileceğini değiştirir; boş çalışma kitabı hücresi sıfır ya da ara değerle doldurulmaz.

Aşağıdaki bağımsız örnek, bir satır serili çizgi grafik oluşturur, 3. Gün için değeri temizler ve her moda göre aynı grafiği kaydeder. Giriş dosyasına ihtiyaç yoktur. [ChartDataWorkbook](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdataworkbook/) çalışma sayfası 0, kategori etiketleri için sütun 0 ve değerler için sütun 1 kullanır; satır 0 seri adını tutar. Son veri `10, 20, empty, 30, 40` şeklindedir.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 40, 40, 640, 400)
    chart_data = chart.chart_data
    workbook = chart_data.chart_data_workbook

    chart_data.series.clear()
    chart_data.categories.clear()

    series_name_cell = workbook.get_cell(0, 0, 1, "Measurements")
    series = chart_data.series.add(series_name_cell, chart.type)
    values = [10, 20, 25, 30, 40]

    for i, value in enumerate(values):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Day {i + 1}")
        chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, value)
        series.data_points.add_data_point_for_line_series(value_cell)

    # Day 3'ü gerçekten boş bırak, ancak kategorisini ve veri noktasını koru.
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

Her çıktı dosyası, kaydetmeden önce atanmış modu içerir: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` ve `empty_cells_Span.pptx`. Tek bir sürüm kaydetmek isterseniz, istenen modu atayın ve sunumu yalnızca bir kez kaydedin; modlar arasında döngü yapmayın.

Aşağıdaki karşılaştırma, aynı verinin üç dosyada nasıl gösterildiğini gösterir. Gün 3, çalışma kitabında her durumda boştur:

![Aynı veriye sahip çizgi grafikler: Gap, Gün 3’te çizgiyi koparır; Zero, çizgiyi sıfıra düşürür; Span, Gün 2’yi Gün 4’e bağlar.](display_blanks_as.png)

Görünür etki grafik türüne bağlıdır. Çizgi grafiği üç modu da karşılaştırmayı kolaylaştırır. Çubuk ve sütun grafiklerinde eksik bir kategori için bağlayıcı bir çizgi olmadığından `SPAN` yukarıdaki bağlayıcı segmenti oluşturamaz; eksik bir sütun ve sıfır‑yükseklikte bir sütun da benzer görünebilir. Benzer şekilde, yalnızca işaretleyicileri olan bir saçılım grafiği de bağlayıcı çizgi içermez. Her grafik türü için üç ayrı sonuç beklemeyin; kullandığınız tür için çıktıyı kontrol edin.

## **Seri Boşluk Genişliğini Ayarlama**

Boşluk genişliği, yan yana çubuk veya sütun kümeleri arasındaki boşluk olup, çubuk veya sütun genişliğinin yüzde cinsinden ifade edilir. Örtüşme gibi, bu da tek bir seriye değil, üst seriler grubuna aittir. Grup için bir kez [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) ayarlayın. Daha büyük bir değer kümeler arasındaki boşluğu artırır; daha küçük bir değer onları daha sıklaştırır.

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

[ChartType](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/charttype/) enum’u tarafından temsil edilen tüm grafik türleri veri kullanır, ancak serileri aynı değer yapısına veya ayarlara sahip değildir. Örneğin, kategori grafiklerinde kategori ve değerler, saçılım grafiklerinde X ve Y değerleri, balon grafiklerinde ise balon boyutları bulunur. Seri türüne uygun veri‑nokta oluşturma yöntemini kullanın. Örtüşme ve boşluk genişliği gibi seçenekler yalnızca uyumlu çubuk veya sütun gruplarına uygulanır.

**Grafik seri grubu nedir?**

[ChartSeriesGroup](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartseriesgroup/) grup‑seviyesi çizim ayarlarını paylaşan uyumlu serileri içerir. Bir birleşik grafik birden fazla grup içerebilir; bir seriden ulaşarak grup değiştirmek, grafikteki tüm serileri zorunlu olarak değiştirmez.

**Yeni oluşturulan bir grafik varsayılan veri içerir mi?**

Evet. Varsayılan olarak, [ShapeCollection.add_chart](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/add_chart/) örnek seriler, kategoriler ve değerler oluşturur. Bu hücreleri düzenleyebilir veya tamamen özelleştirilmiş bir veri kümesi eklemeden önce seri ve kategori koleksiyonlarını temizleyebilirsiniz. Bir aşırı yük de varsayılan veri olmadan bir grafik oluşturabilir.

**Grafik nesneleri çalışma kitabı hücrelerine nasıl bağlanır?**

Seri adları, kategori etiketleri ve veri‑nokta değerleri bir [ChartDataWorkbook](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdataworkbook/) içindeki hücrelere başvurur. Başvurulan bir hücre değiştiğinde ilgili grafik öğesi güncellenir. Özelleştirilmiş veri oluştururken, her noktanın amaçlanan kategori altında çizildiğinden emin olmak için kategori satırları ve seri‑değer satırlarını hizalı tutun.

**Bir bütün seriyi değil sadece bir noktayı nasıl temizlerim?**

İlgili değer hücresini `None` olarak ayarlayın; böylece noktanın kategori konumu boş bir nokta olarak kalır. Bir serideki tüm noktaları kaldırmak istediğinizde yalnızca [ChartDataPointCollection.clear](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdatapointcollection/clear/) kullanın. Kategorileri de kaldırıyorsanız, her serinin değerleri kategori koleksiyonuyla hizalı kalacak şekilde güncelleyin.

**Boş noktalar nasıl gösterilir?**

Sonuç, grafik türüne ve [Chart.display_blanks_as](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chart/display_blanks_as/) ayarına bağlıdır. Desteklenen grafikler boşlukları, sıfır değerlerini veya komşu noktaları bağlayarak gösterebilir. Sunumunuzdaki eksik verinin anlamına uygun ayarı seçin. Tam bir örnek ve görsel karşılaştırma için **Boş Hücrelerin Görüntülenmesini Kontrol Etme** bölümüne bakın.

**Negatif değerler nasıl biçimlendirilir?**

Desteklenen çubuk, sütun ve balon serileri için [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartseries/invert_if_negative/) etkinleştirin ve [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) ile negatif değer rengini atayın. Bireysel bir nokta için davranışı [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) ile geçersiz kılabilirsiniz. Bu özellikler biçimlendirmeyi etkiler, saklanan sayısal değeri değiştirmez.

**Hem seri hem de nokta biçimlendirilmişse hangisi kazanır?**

Açık veri‑nokta biçimlendirmesi o nokta için önceliklidir. Diğer noktalar açık seri biçimi veya seri biçimi tanımlı değilse otomatik grafik stili ve teması kullanır. Örtüşme ve boşluk genişliği gibi grup özellikleri yerleşimi kontrol eder ve nokta‑seviyesi biçimlendirme geçersiz kılmaları değildir.

**Bir grafik kaç seri içerebilir?**

Aspose.Slides ayrı bir sabit seri sayısı sınırı koymaz. Pratikte, dosya boyutu kısıtlamaları, kullanılabilir bellek, render süresi ve grafiğin okunabilirliği kullanılabilir sınırı belirler.

**Sütunlar çok yakın ya da çok uzak olduğunda ne değiştirilmelidir?**

Uygun üst seri grubunda [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) ayarlayın. Değeri artırarak kümeler arasındaki boşluğu genişletin, azaltarak kümeleri birbirine yaklaştırın.