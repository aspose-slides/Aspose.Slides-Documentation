---
title: Python ile Sunumlarda Grafik Çalışma Kitaplarını Yönet
linktitle: Grafik Çalışma Kitabı
type: docs
weight: 70
url: /tr/python-net/chart-workbook/
keywords:
- grafik çalışma kitabı
- grafik verisi
- çalışma kitabı hücresi
- veri etiketi
- çalışma sayfası
- veri kaynağı
- harici çalışma kitabı
- harici veri
- grafik önbelleği
- çalışma kitabı kurtarma
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET'i keşfedin: PowerPoint ve OpenDocument formatlarında grafik çalışma kitaplarını sorunsuz bir şekilde yöneterek sunum verilerinizi düzenleyin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'te grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Çalışma kitabı akışları aracılığıyla grafik verilerini nasıl okuyup yazacağınızı, çalışma kitabı hücrelerini grafik veri etiketleri olarak nasıl kullanacağınızı, çalışma sayfası koleksiyonlarına nasıl erişileceğini ve grafik değerleri için veri kaynağı türünün nasıl belirtileceğini gösterir.

Ayrıca dış çalışma kitaplarının grafik veri kaynakları olarak kullanılmasını da kapsar. Örnekler, dış bir çalışma kitabı oluşturup atamayı, bir grafik ile ilişkilendirilmiş dış çalışma kitabının yolunu almaya ve çalışma kitabı mevcut olduğunda grafik verilerini düzenlemeye nasıl yapılacağını gösterir.

Eksik veriyi temsil eden çalışma kitabı hücreleri için, boş bir hücre ile sıfır arasındaki farkı ve kullanılabilir görüntüleme modlarının bir çizgi grafik karşılaştırmasını görmek üzere [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/python-net/chart-series/) sayfasına bakın.

## **Gizli Satır ve Sütunlardan Veri Dahil Et**

Gizli çalışma sayfası satır ve sütunlarından veri çizip çizmediğini kontrol etmek için [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) kullanın. Görünür hücreleri yalnızca çizmek için `True`, görünür ve gizli hücreleri dahil etmek için `False` olarak ayarlayın. Bu ayar grafik çizimini kontrol eder; çalışma sayfası satır veya sütunlarını gizlemez veya göstermez.

[örnek sunum](hidden-source-data.pptx) ilk slaytının ilk şekli olarak bir sütun grafik içerir. Gömülü çalışma sayfası `Sheet1`, aşağıdaki kaynak aralığını (`A1:C4`) içerir. Satır 3 ve sütun C gizlidir, ancak hücreleri hâlâ değer içerir.

| Çalışma sayfası satırı | A: Ay | B: Perakende | C: Toptan (gizli sütun) |
| --- | --- | --- | --- |
| 2 | Ocak | 10 | 30 |
| 3 (gizli satır) | Şubat | 40 | 60 |
| 4 | Mart | 20 | 50 |

Kaynak hücrelere [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) üzerinden erişin ve gizli durumlarını incelemek için [ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/) okuyun. Bu özellik yalnızca okunabilir. Bu dosyada B2 görünür, B3 gizli satıra aittir ve C2 gizli sütuna aittir; örnek sırasıyla `False`, `True` ve `True` yazdırır.

Bu örnek için, çizim ayarını değiştirdikten sonra grafik verilerini yenileyin: gömülü çalışma kitabını [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) ile tutun ve [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) ile yeniden yükleyin. Tüm hücreleri dahil ederken, gizli Şubat kategorisini içerecek tam aralığı geri yüklemek için ayrıca [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) kullanın. Sadece bayrağı değiştirmek bu örneğin önbelleğe alınmış grafik verilerini ve kategori etiketlerini yenilemek için yetersizdir.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("hidden-source-data.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        workbook = chart.chart_data.chart_data_workbook
        print(f"B2 hidden: {workbook.get_cell(0, 'B2').is_hidden}")
        print(f"B3 hidden: {workbook.get_cell(0, 'B3').is_hidden}")
        print(f"C2 hidden: {workbook.get_cell(0, 'C2').is_hidden}")

        workbook_stream = chart.chart_data.read_workbook_stream()
        for visible_only in [True, False]:
            chart.plot_visible_cells_only = visible_only

            # Gömülü çalışma kitabından grafik verilerini yenile.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # Gizli kategorileri de içerecek şekilde tam kaynak aralığını geri yükle.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

Örnek, sunumun iki sürümünü kaydeder: yalnızca görünür Perakende değerleri (10 ve 20) içeren bir sürüm ve tüm altı değeri içeren bir sürüm. Aşağıdaki görseller, kaydedilen sunumlar yeniden açıldıktan sonra render edilmiştir; her iki dosya da atanmış çizim ayarını korur. Satır 3 ve sütun C her iki gömülü çalışma kitabında da gizli kalır.

| Yalnızca görünür hücreler (`True`) | Tüm hücreler (`False`) |
| --- | --- |
| ![Yalnızca görünür hücreler: Ocak ve Mart ayları için Perakende değerleri 10 ve 20.](hidden_cells_True.png) | ![Tüm hücreler: Ocak, Şubat ve Mart ayları için Perakende ve Toptan değerleri.](hidden_cells_False.png) |

Değer içeren bir gizli hücre, boş bir hücreden farklıdır. [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) eksik değerlerin nasıl gösterileceğini denetler; gizli kaynak verilerini eklemez veya çıkarmaz. Bir örnek için [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/python-net/chart-series/#control-the-display-of-empty-cells) sayfasına bakın.

## **Grafiğin Veri Aralığını Al**

Mevcut bir sunumda çalışma kitabı verilerini güncellemeden önce, her bir grafiğin kullandığı çalışma sayfası hücrelerini belirlemek için kaynak aralıkları inceleyin. [ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/) yöntemi, `Sheet1!$A$1:$D$5` gibi bir çalışma sayfası nitelikli formül olarak geçerli veri aralığını döndürür. Burada `Sheet1` çalışma sayfası adıdır, `!` hücre aralığından ayırır ve `$A$1:$D$5` A1'den D5'e kadar (dahil) hücreleri tanımlar. Dolar işaretleri mutlak satır ve sütun referanslarını gösterir.

Yöntem, grafiği veya onun çalışma kitabını değiştirmeden geçerli aralığı okur. Grafik bir çalışma kitabını veri kaynağı olarak kullanmıyorsa bir istisna fırlatır. Daha fazla bilgi için [ChartData API Reference](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) sayfasına bakın.

Bu örnek bir sunumu açar ve her slayttaki şekilleri doğrudan grafikler için kontrol eder. Her grafiğin adını ve kaynak aralığını yazdırır. Aralık alınamıyorsa teşhis mesajı verir ve bir sonraki grafiğe geçer.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, charts.Chart):
                try:
                    data_range = shape.chart_data.get_range()
                    print(f"{shape.name}: {data_range}")
                except RuntimeError as error:
                    print(f"{shape.name}: Unable to retrieve the chart data range. {error}")
```

## **Bir Çalışma Kitabından Grafik Verilerini Oku ve Yaz**

Aspose.Slides for Python via .NET, grafik verileri çalışma kitaplarını (Aspose.Cells ile düzenlenmiş) okumanıza ve yazmanıza olanak tanıyan [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) ve [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) yöntemlerini sağlar. **Not** grafik verileri aynı şekilde düzenlenmiş olmalı veya kaynağa benzer bir yapıya sahip olmalıdır.

Bu örnek, ilk slaytının ilk şekli olarak bir grafik içeren bir sunum kullanır. Gömülü çalışma kitabını bir akışa okur, mevcut serileri ve kategorileri temizler ve aynı çalışma kitabını geri yazar. Değişiklikler bellek içinde kalır; örnek sunumu kaydetmez.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
    else:
        print("The first shape is not a chart.")
```

### **Çalışma Kitabı Değişikliği Sonrası Grafik Düzenini Doğrula**

Gömülü bir çalışma kitabını değiştirilmiş bir sürümle değiştirdiğinizde, grafik orijinal seri ve kategori koleksiyonlarını tutar. Bu uyumsuzluk, [Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) yönteminin indeks dışı hatasıyla başarısız olmasına neden olabilir. Güncellenmiş çalışma kitabını grafik içine geri yazmadan önce mevcut seri ve kategorileri temizleyin. Bu örnek, ilk slaytın ilk şekli olarak bir grafik kullanır. Yorum, çalışma kitabı düzenlemesinin nerede gerçekleşeceğini işaret eder; çalışan örnek orijinal çalışma kitabını geri yazar ve bellek içinde düzeni doğrular.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # Bu noktada çalışma kitabı akışını değiştirin, örneğin Aspose.Cells kullanarak.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

Koleksiyonları temizlemek, çalışma kitabı geri yazılmadan önce eski veri referanslarını kaldırır. Güncellenmiş çalışma kitabı için gerekli seri ve kategori eşlemelerini yeniden oluşturun ve grafiği kullanmadan önce bunu yapın.

## **Kategori Etiketlerini Nasıl Depolayacağınızı Seçin**

[Kategori koleksiyonu boşken] [ChartCategoryCollection.use_cells](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorycollection/use_cells/) ayarlayın. Etiketlerin çalışma sayfası hücrelerine bağlanması veya yıl içinde gruplanmış çeyrekler gibi bir hiyerarşi oluşturması için `True`, sadece dize olarak sağlanan tek seviyeli etiketler için `False` ayarlayın. Bu ayar yalnızca kategorilere uygulanır. Örnekteki iki grafik, sayısal seri değerleri için çalışma sayfası hücrelerini kullanır.

Örnek iki sütun grafik oluşturur ve depolama modunu ve her biri için `Q1 Q2 Q3 Q4` etiketlerini yazdırır. Hücre destekli etiketler için [ChartCategory.as_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/as_cell/) çalışma sayfası hücresini döndürür ve [ChartDataCell.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/value/) içinde depolanan etiketi verir. Düz etiketler için doğrudan [ChartCategory.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/value/) okunur.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes
    
    for use_cells, x in [(True, 20), (False, 360)]:
        chart = shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, x, 20, 320, 250)
        data = chart.chart_data
        data.series.clear()
        data.categories.clear()
        data.categories.use_cells = use_cells

        workbook = data.chart_data_workbook
        series_name = workbook.get_cell(0, 0, 1, "Sales")
        series = data.series.add(series_name, chart.type)
        for row in range(1, 5):
            label = f"Q{row}"
            if use_cells:
                label_cell = workbook.get_cell(0, row, 0, label)
                data.categories.add(label_cell)
            else:
                data.categories.add(label)

            value_cell = workbook.get_cell(0, row, 1, row * 10)
            series.data_points.add_data_point_for_bar_series(value_cell)

        labels = [category.as_cell.value if use_cells else category.value for category in data.categories]
        print(f"use_cells = {data.categories.use_cells}:", *labels)

    presentation.save("category-labels.pptx", slides.export.SaveFormat.PPTX)
```

## **Çalışma Kitabı Hücreleri için Özel Sayı Biçimlerini Ayarla**

[ChartDataCell.custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/) kullanarak sayısal değerlerin bir grafiğin gömülü çalışma kitabında nasıl görüneceğini kontrol edin. Örneğin, bir rapor dönüşüm oranını yüzde olarak dört ondalık basamakla ve katsayıyı beş ondalık basamakla gösterebilir. Her iki değeri de sayısal tutun, böylece hesaplamalar ve grafik çizimi için kullanılabilir.

Bir sayı biçimi görünümü değiştirir, saklanan değeri değiştirmez. `0.0000%` biçimi `0.125` sayısını `12.5000%` olarak gösterir; sayı `12.5` olarak değiştirilmez. Benzer şekilde, `0.00000` `0.1234567` sayısını `0.12346` olarak gösterir, fakat saklanan değer yuvarlanmaz. Özel biçim boş bir dize (`""`) ise, [preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) kullanılır.

Aşağıdaki örnek bir sütun grafik oluşturur ve hücrelerine [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) aracılığıyla erişir. Çalışma sayfası 0'da B2 dönüşüm oranını, C2 ise katsayıyı içerir. Her iki hücre de grafik değerleri sağlar. Örnek aynı zamanda kaynak biçimlerine bağlanan değer etiketlerini etkinleştirir.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 270, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 20, 620, 210)
    chart.has_title = False

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00"
    chart.axes.vertical_axis.is_automatic_min_value = False
    chart.axes.vertical_axis.min_value = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    category_cell = workbook.get_cell(0, "A2", "Sample")
    chart.chart_data.categories.add(category_cell)

    percentage_cell = workbook.get_cell(0, "B2", 0.125)
    percentage_cell.custom_number_format = "0.0000%"
    percentage_name = workbook.get_cell(0, "B1", "Conversion rate")
    percentage_series = chart.chart_data.series.add(percentage_name, chart.type)
    percentage_series.data_points.add_data_point_for_bar_series(percentage_cell)

    precision_cell = workbook.get_cell(0, "C2", 0.1234567)
    precision_cell.custom_number_format = "0.00000"
    precision_name = workbook.get_cell(0, "C1", "Coefficient")
    precision_series = chart.chart_data.series.add(precision_name, chart.type)
    precision_series.data_points.add_data_point_for_bar_series(precision_cell)

    for series in chart.chart_data.series:
        label_format = series.data_points[0].label.data_label_format
        label_format.show_value = True
        label_format.is_number_format_linked_to_source = True

    presentation.save("CustomCellFormats.pptx", slides.export.SaveFormat.PPTX)
```

Çalışma kitabı hücre biçimleri, doğrudan grafik eksenlerine veya veri etiketlerine ayarlanan biçimlerden ayrıdır. Bu örnekte her etiket, [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) etkin olduğu için kaynak hücresinin değerini gösterir ve [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) `True` olduğu için kaynak sayı biçimini izler. Sunum kaydedilip yeniden açıldıktan sonra etiketler `12.5000%` ve `0.12346` olarak görüntülenir, aşağıda gösterildiği gibi. Dikey eksen kendi `0.00` [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) değerini kullanır ve [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) `False` olarak ayarlanmıştır.

Bağımsız olarak bir veri etiketini biçimlendirmek için, kaynak‑bağlantı bayrağını `False` yapın ve [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/) ayarlayın. Bu, çalışma kitabı hücresinin biçimini değiştirmez. Örneğin, bağımsız bir etiket biçimi `0.00` ilk değeri `0.13` olarak gösterirken B2 hâlâ `12.5000%` gösterir. Doğrudan etiket biçimlendirme için [Chart Data Labels](/slides/tr/python-net/chart-data-label/#set-percentage-sign-with-chart-data-labels) sayfasına bakın.

Aşağıdaki görüntü, sunum kaydedilip yeniden açıldıktan sonra render edilmiştir:

![Kaynak‑bağlantılı etiketlerin 12.5000% ve 0.12346 gösterdiği ve bağımsız olarak biçimlendirilmiş sayısal eksenin bulunduğu sütun grafik.](custom-cell-formats.png)

## **Bir Çalışma Kitabı Hücresini Grafik Veri Etiketi Olarak Kullan**

Çalışma kitabı hücrelerinden gelen metni grafik veri etiketi olarak kullanabilirsiniz.

Bu örnek, mevcut bir sunumun ilk slaytına varsayılan verilerle bir balon grafik ekler. Çalışma sayfası 0'da A10:A12 hücrelerini ilk serideki ilk üç etiket olarak kullanır, hücrelerden etiketleri etkinleştirir ve güncellenmiş sunumu kaydeder.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart2.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    series = chart.chart_data.series[0]
    workbook = chart.chart_data.chart_data_workbook

    series.labels.default_data_label_format.show_label_value_from_cell = True
    series.labels[0].value_from_cell = workbook.get_cell(0, "A10", "Label 0 cell value")
    series.labels[1].value_from_cell = workbook.get_cell(0, "A11", "Label 1 cell value")
    series.labels[2].value_from_cell = workbook.get_cell(0, "A12", "Label 2 cell value")

    presentation.save("resultchart.pptx", slides.export.SaveFormat.PPTX)
```

## **Çalışma Sayfalarını Yönet**

[ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) özelliği, bir grafik çalışma kitabındaki çalışma sayfalarına erişim sağlar. Bu örnek bir pasta grafik oluşturur, varsayılan verileri kullanır ve her çalışma sayfasının adını konsola yazar.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)
    workbook = chart.chart_data.chart_data_workbook

    for worksheet in workbook.worksheets:
        print(worksheet.name)
```

## **Veri Kaynağı Türünü Belirt**

Seri nokta değerleri doğrudan sayısal sabitler olarak da depolanabilir. Sayısal sabitler kullanarak kaydedip okuyan tam bir örnek için [Set Series Values Using Numeric Literals](/slides/tr/python-net/chart-series/#set-series-values-using-numeric-literals) sayfasına bakın. Nokta değerlerinin kaynak türü, grafiğin iç veya dış çalışma kitabı yapılandırmasından ayrıktır; sayısal sabitler kullanmak tek başına gömülü çalışma kitabını kaldırmaz.

Bu örnek, varsayılan verilerle bir 3B sütun grafik oluşturur ve iki seri adını farklı veri kaynaklarıyla ayarlar. İlk ad bir dize sabiti; ikinci ad ise çalışma sayfası 0'da C1 hücresini kullanır. [DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) enumu, her ad için kaynağı seçer. Örnek, güncellenmiş seri adlarıyla sunumu kaydeder.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)
    literal_name = chart.chart_data.series[0].name

    literal_name.data_source_type = charts.DataSourceType.STRING_LITERALS
    literal_name.data = "LiteralString"

    cell_name = chart.chart_data.series[1].name
    name_cell = chart.chart_data.chart_data_workbook.get_cell(0, "C1", "NewCell")
    cell_name.data_source_type = charts.DataSourceType.WORKSHEET
    cell_name.data = name_cell

    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Desteklenmeyen Gömülü Çalışma Kitabı Biçimlerini Algıla**

Aspose.Slides, bazı grafiklerde gömülebilen Excel ikili çalışma kitabı (.xlsb) biçimini desteklemez. Desteklenmeyen biçimleri algılamak ve bu grafikleri atlamak için [ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) üzerindeki [embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) özelliğini, [WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/) enumu ile birlikte kullanabilirsiniz. Bu örnek mevcut bir sunumun ilk slaydındaki şekilleri inceler, grafik olmayan şekilleri atlar ve .xlsb gömülü çalışma kitabına sahip her grafik için bir teşhis mesajı yazar.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, charts.Chart):
            continue

        chart_data = shape.chart_data
        is_internal_workbook = chart_data.data_source_type == charts.ChartDataSourceType.INTERNAL_WORKBOOK
        is_binary_macro = chart_data.embedded_workbook_type == charts.WorkbookType.WORKBOOK_BINARY_MACRO

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue

        # Desteklenen grafik çalışma kitabı verilerini burada okuyun veya değiştirin.
```

## **Dış Çalışma Kitabı**

Aspose.Slides, grafikler için dış çalışma kitaplarını veri kaynağı olarak kullanmayı destekler.

### **Dış Çalışma Kitabı Oluştur**

[read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) ve [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) kullanarak gömülü bir grafik çalışma kitabını bir dosyaya dışa aktarın ve grafiği bu dış çalışma kitabına bağlayın.

Bu örnek, varsayılan verilerle bir pasta grafik oluşturur ve çalışma kitabını dışa aktarır. Dış çalışma kitabını grafik veri kaynağı olarak atamadan önce çıkış akışını kapatır, ardından bağlanmış sunumu kaydeder.

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600)
    workbook_path = str(Path("externalWorkbook1.xlsx").resolve())

    workbook_stream = chart.chart_data.read_workbook_stream()
    workbook_data = workbook_stream.read()
    with open(workbook_path, "wb") as file_stream:
        file_stream.write(workbook_data)

    chart.chart_data.set_external_workbook(workbook_path)

    presentation.save("externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

### **Dış Çalışma Kitabı Ata**

[set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) yöntemiyle bir grafiğe dış bir çalışma kitabını veri kaynağı olarak atayabilirsiniz. Bu yöntem aynı zamanda dış çalışma kitabının yolunu (dosya taşınmışsa) güncellemek için de kullanılabilir.

Uzak konumlardaki veya kaynaklardaki çalışma kitaplarındaki verileri düzenleyemezsiniz, ancak bu tür çalışma kitapları dış veri kaynağı olarak kullanılabilir. Dış çalışma kitabı için göreceli bir yol sağlanırsa, otomatik olarak tam yola dönüştürülür.

Bu örnek, `Sheet1` adlı çalışma sayfasında B1’de bir seri adı, A2:A4 aralığında kategori adları ve B2:B4 aralığında sayısal değerler içeren bir dış çalışma kitabı kullanır. Örnek bir pasta grafik oluşturur, çalışma kitabını bağlar ve [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) ile A1:B4 aralığını bir seri ve üç kategoriye eşler. Bağlı grafiği içeren sunumu kaydeder.

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart_data = chart.chart_data
    workbook_path = str(Path("externalWorkbook.xlsx").resolve())

    chart_data.set_external_workbook(workbook_path)
    chart_data.set_range("Sheet1!$A$1:$B$4")

    presentation.save("Presentation_with_externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

[set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) metodunun `update_chart_data` parametresi, çalışma kitabının yüklenip yüklenmeyeceğini belirler.

* `update_chart_data` `False` olduğunda yalnızca çalışma kitabı yolu güncellenir. Grafik verileri hedef çalışma kitabından yüklenmez veya güncellenmez, bu yüzden çalışma kitabı mevcut olmayabilir.
* `update_chart_data` `True` olduğunda grafik verileri hedef çalışma kitabından güncellenir.

Aşağıdaki örnek, `update_chart_data` `False` olarak ayarlanmış bir yer tutucu URL atar. Pasta grafiğinin varsayılan verileri korunur ve kullanılabilir olmayan çalışma kitabı yüklenmeden sunum kaydedilir.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **Bir Grafiğin Dış Veri Kaynağı Çalışma Kitabı Yolunu Al**

Bir grafiğin hangi çalışma kitabına bağlandığını belirlemek için grafiğin dış veri kaynağı kullanıp kullanmadığını kontrol edin ve çalışma kitabı yolunu alın.

Bu örnek, dış çalışma kitabına bağlanan bir grafik olup olmadığını kontrol etmek için bir sunumun ilk slaydındaki ilk şekli inceler. Eğer dış çalışma kitabına bağlanan bir grafik ise, [external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) konsola yazdırılır. Ardından sunumun bir kopyası kaydedilir.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("externalWorkbook.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        if chart_data.data_source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
            print(chart_data.external_workbook_path)
        else:
            print("The chart does not use an external workbook.")
    else:
        print("The first shape is not a chart.")

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

### **Grafik Verilerini Düzenle**

Dış çalışma kitaplarındaki verileri, iç çalışma kitaplarındaki gibi düzenleyebilirsiniz. Dış bir çalışma kitabı yüklenemediğinde bir istisna fırlatılır.

Bu örnek, ilk slaytın ilk şekli olarak bir grafik kullanır ve erişilebilir bir dış çalışma kitabına bağlanır. İlk serideki ilk veri noktasının hücre‑destekli değerini 100 olarak ayarlar ve güncellenmiş sunumu kaydeder. Hücre değerlerini düzenlemek, bağlanan dış XLSX dosyasını güncelleyebilir; bu yüzden orijinali korumak istiyorsanız bir kopya kullanın.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        series = chart.chart_data.series
        if len(series) > 0 and len(series[0].data_points) > 0:
            value_cell = series[0].data_points[0].value.as_cell
            if value_cell is not None:
                value_cell.value = 100
                presentation.save("presentation_out.pptx", slides.export.SaveFormat.PPTX)
            else:
                print("The first data point is not linked to a workbook cell.")
        else:
            print("The chart has no data points to edit.")
    else:
        print("The first shape is not a chart.")
```

### **Grafik Önbelleğinden Çalışma Kitabını Kurtar**

Bir grafik, eksik veya kullanılabilir olmayan bir dış çalışma kitabına bağlıysa, Aspose.Slides sunumda önbelleğe alınan verilerden grafik çalışma kitabını yeniden oluşturabilir. [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) oluşturun, [spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/) yapılandırın ve [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) `True` olarak ayarlayın; ardından sunumu açın.

Aşağıdaki Python örneği, ilk slaydın ilk şekli olarak bir grafik için dış çalışma kitabı bulunmayan durumdaki çalışma kitabı verilerini kurtarır. Kurtarılan verilere [Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/) ve [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) aracılığıyla erişir:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        recovered_workbook = chart.chart_data.chart_data_workbook

        # Kurtarılan çalışma kitabı verilerini burada okuyun veya değiştirin.
    else:
        print("The first shape is not a chart.")
```

Dış çalışma kitabı bulunamaz ve kurtarma devre dışı bırakılmışsa, Aspose.Slides bir istisna fırlatır. Önbellekten grafik verilerini kullanmak kabul edilebilir bir geri dönüş ise yalnızca kurtarmayı etkinleştirin; çünkü önbellek, sunum son kez güncellendikten sonra dış çalışma kitabında yapılan değişiklikleri içermeyebilir.

## **SSS**

**Belirli bir grafiğin dış veya gömülü bir çalışma kitabına bağlandığını nasıl anlayabilirim?**

Evet. Bir grafiğin [data source type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) ve bir [external workbook path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) vardır; kaynak dış bir çalışma kitabı ise tam yolu okuyarak dış bir dosyanın kullanıldığını teyit edebilirsiniz.

**Dış çalışma kitapları için göreceli yollar destekleniyor mu, nasıl depolanıyor?**

Evet. Göreceli bir yol belirtirseniz otomatik olarak mutlak yola dönüştürülür. Sunum, mutlak yolu PPTX dosyasında depolar; bu yüzden çalışma kitabını taşıdığınızda bağlantıyı güncellemeniz gerekebilir.

**Ağ kaynakları/paylaşımları üzerindeki çalışma kitaplarını kullanabilir miyim?**

Evet, bu tür çalışma kitapları dış veri kaynağı olarak kullanılabilir. Ancak, Aspose.Slides ile uzaktaki çalışma kitaplarını doğrudan düzenlemek desteklenmez; yalnızca kaynak olarak kullanılabilirler.

**Aspose.Slides, sunumu kaydederken dış XLSX dosyasını üzerine yazar mı?**

Sunum, dış dosyaya bir [link](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) depolar. Hücre‑destekli grafik verilerini düzenlemek, bağlı yerel XLSX dosyasını da güncelleyebilir. Orijinalinin değişmemesi gerekiyorsa çalışma kitabının bir kopyasını kullanın.

**Dış dosya şifre korumalı ise ne yapmalıyım?**

Aspose.Slides, bağlama sırasında şifre kabul etmez. Yaygın bir yaklaşım, önceden korumayı kaldırmak ya da bir kopyasını (örneğin [Aspose.Cells](https://reference.aspose.com/cells/python-net/)) şifresiz hazırlamak ve o kopyaya bağlamaktır.

**Birden fazla grafik aynı dış çalışma kitabına referans verebilir mi?**

Evet. Her grafik kendi bağlantısını depolar. Hepsi aynı dosyaya işaret ediyorsa, dosyadaki bir güncelleme bir sonraki veri yüklemesinde tüm grafiklerde yansır.