---
title: Python ile Sunumlarda Grafik Çalışma Kitaplarını Yönetme
linktitle: Grafik Çalışma Kitabı
type: docs
weight: 70
url: /tr/python-net/chart-workbook/
keywords:
- grafik çalışma kitabı
- grafik verileri
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
description: "Aspose.Slides for Python via .NET'i keşfedin: PowerPoint ve OpenDocument formatlarında grafik çalışma kitaplarını zahmetsizce yönetin ve sunum verilerinizi düzenleyin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Çalışma kitabı akışları aracılığıyla grafik verilerini okuma ve yazma, çalışma kitabı hücrelerini grafik veri etiketleri olarak kullanma, çalışma sayfası koleksiyonlarına erişme ve grafik değerleri için veri kaynağı türünü belirtme konularını gösterir.

Ayrıca harici çalışma kitaplarını grafik veri kaynakları olarak kullanmayı da kapsar. Örnekler, harici bir çalışma kitabı oluşturup atamayı, bir grafikle ilişkilendirilmiş harici çalışma kitabının

yolunu almayı ve çalışma kitabı mevcut olduğunda grafik verilerini düzenlemeyi gösterir.

Eksik veriyi temsil eden çalışma kitabı hücreleri için, boş bir hücre ile sıfır arasındaki farkı ve kullanılabilir görüntüleme modlarının çizgi grafik karşılaştırmasını görmek üzere [Boş Hücrelerin Görüntülenmesini Denetleme](/slides/tr/python-net/chart-series/) bölümüne bakın.

## **Gizli Satır ve Sütunlardan Veri Dahil Et**

Gizli çalışma sayfası satır ve sütunlarından veri çizerken bir grafiğin bunu yapıp yapmayacağını kontrol etmek için [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) kullanın. Yalnızca görünür hücreleri çizmek için `True`, hem görünür hem de gizli hücreleri dahil etmek için `False` olarak ayarlayın. Bu ayar grafik çizimini kontrol eder; çalışma sayfası satır veya sütunlarını gizlemez ya da göstermez.

[örnek sunum](hidden-source-data.pptx) ilk slaytındaki ilk şekil olarak bir sütun grafik içerir. Yerleşik çalışma sayfası `Sheet1`, aşağıdaki kaynak aralığını içerir: `A1:C4`. 3. satır ve C sütunu gizlidir, ancak hücreleri hâlâ değer içerir.

| Çalışma sayfası satırı | A: Ay | B: Perakende | C: Toptan (gizli sütun) |
| --- | --- | --- | --- |
| 2 | Ocak | 10 | 30 |
| 3 (gizli satır) | Şubat | 40 | 60 |
| 4 | Mart | 20 | 50 |

Kaynak hücrelere [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) aracılığıyla erişin ve gizli durumlarını incelemek için [ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/) okuyun. Bu özellik yalnızca okunabilir. Bu dosyada B2 görünür, B3 gizli satıra, C2 ise gizli sütuna aittir; örnek sırasıyla `False`, `True` ve `True` yazdırır.

Bu örnek için, çizim ayarı değiştirildikten sonra grafik verilerini yenileyin: yerleşik çalışma kitabını [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) ile tutun ve [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) ile yeniden yükleyin. Tüm hücreleri dahil ederken, gizli Şubat kategorisini de kapsayan tam aralığı geri getirmek için [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) kullanın. Sadece bayrağı değiştirmek bu örnek için önbellekteki grafik verilerini ve kategori etiketlerini yenilemek için yetersizdir.

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
                # Gizli kategoriler dahil tam kaynak aralığını geri yükle.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

Örnek, yalnızca görünür Perakende değerleri (10 ve 20) içeren bir sürüm ve tüm altı değeri içeren bir sürüm olarak sunumu iki kez kaydeder. Aşağıdaki görseller, kaydedilen sunumlardan yeniden açıldıktan sonra oluşturulmuştur; her iki dosya da atanan çizim ayarını korur. 3. satır ve C sütunu her iki yerleşik çalışma kitabında da gizli kalır.

| Yalnızca görünür hücreler (`True`) | Tüm hücreler (`False`) |
| --- | --- |
| ![Yalnızca görünür hücreler: Ocak ve Mart ayları için Perakende değerleri 10 ve 20.](hidden_cells_True.png) | ![Tüm hücreler: Ocak, Şubat ve Mart ayları için Perakende ve Toptan değerleri.](hidden_cells_False.png) |

Değer içeren bir gizli hücre, boş bir hücreden farklıdır. [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) eksik değerlerin nasıl gösterileceğini kontrol eder; gizli kaynak verileri ekleyip çıkarmaz. Bir örnek için [Boş Hücrelerin Görüntülenmesini Denetleme](/slides/tr/python-net/chart-series/#control-the-display-of-empty-cells) bölümüne bakın.

## **Bir Grafiğin Veri Aralığını Almak**

Mevcut bir sunumda çalışma kitabı verilerini güncellemeden önce, her grafiğin hangi çalışma sayfası hücrelerini kullandığını belirlemek üzere kaynak aralıklarını inceleyin. [ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/) yöntemi, örneğin `Sheet1!$A$1:$D$5` gibi bir çalışma sayfası nitelikli formül olarak geçerli veri aralığını döndürür. Burada `Sheet1` çalışma sayfası adıdır, `!` hücre aralığından ayırır ve `$A$1:$D$5` A1‑D5 hücrelerini kapsar. Dolar işaretleri mutlak satır ve sütun referanslarını gösterir.

Yöntem, grafiği veya onun çalışma kitabını değiştirmeden geçerli aralığı okur. Grafik, veri kaynağı olarak bir çalışma kitabı kullanmıyorsa bir istisna fırlatır. Daha fazla bilgi için [ChartData API Reference](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) bölümüne bakın.

Bu örnek bir sunumu açar ve her slayttaki şekilleri doğrudan kontrol ederek grafik olup olmadığını denetler. Her grafiğin adını ve kaynak aralığını yazdırır. Aralık alınamıyorsa tanı mesajı verir ve bir sonraki grafikle devam eder.

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

## **Bir Çalışma Kitabından Grafik Verilerini Okuma ve Yazma**

Aspose.Slides for Python via .NET, grafik verilerini içeren çalışma kitaplarını (Aspose.Cells ile düzenlenmiş) okumanıza ve yazmanıza olanak tanıyan [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) ve [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) metodlarını sunar. **Note** grafik verileri aynı şekilde düzenlenmeli veya kaynağa benzer bir yapıya sahip olmalıdır.

Bu örnek, ilk slaytındaki ilk şekil olarak bir grafik içeren bir sunum kullanır. Yerleşik çalışma kitabını bir akısa okur, mevcut serileri ve kategorileri temizler ve aynı çalışma kitabını geri yazar. Değişiklikler bellekte kalır; örnek sunumu kaydetmez.

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

### **Çalışma Kitabı Değişikliği Sonrası Grafik Düzenini Doğrulama**

Yerleşik bir çalışma kitabını değiştirilmiş bir sürümle değiştirirken, grafik orijinal seri ve kategori koleksiyonlarını tutar. Bu uyumsuzluk, [Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) yönteminin indeks dışı hata vermesine neden olabilir. Güncellenmiş çalışma kitabını grafiğe geri yazmadan önce mevcut serileri ve kategorileri temizleyin. Bu örnek, ilk slayttaki ilk şekil olarak bir grafiği kullanır. Yorum, çalışma kitabı düzenlemesinin nerede gerçekleşeceğini işaret eder; çalışan örnek orijinal çalışma kitabını geri yazar ve bellekte düzeni doğrular.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # Burada, örneğin Aspose.Cells kullanarak çalışma kitabı akışını değiştirin.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

Koleksiyonların temizlenmesi, çalışma kitabı geri yazılmadan önce eski veri referanslarını kaldırır. Güncellenmiş çalışma kitabı için gerekli seri ve kategori eşlemelerini yeniden oluşturun ve grafiği kullanmadan önce bunu yapın.

## **Çalışma Kitabı Hücreleri için Özel Sayı Biçimleri Ayarlama**

[ChartDataCell.custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/) kullanarak bir grafiğin yerleşik çalışma kitabındaki sayısal değerlerin nasıl görüneceğini kontrol edin. Örneğin, bir rapor dönüşüm oranını yüzde olarak dört ondalık basamak ve bir katsayıyı beş ondalık basamakla gösterebilir. Her iki değeri de sayısal tutun; böylece hesaplamalar ve grafik çizimi için kullanılabilir kalırlar.

Bir sayı biçimi gösterimi değiştirir, saklanan değeri değiştirmez. `0.0000%` biçimi `0.125` sayısını `12.5000%` olarak gösterir; saklanan sayı `12.5` olarak değiştirilmez. Benzer şekilde, `0.00000` `0.1234567` sayısını `0.12346` olarak gösterir; saklanan değer yuvarlanmaz. Özel biçim boş bir dizge (`""`) ise [preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) kullanılır.

Aşağıdaki örnek bir sütun grafik oluşturur ve hücrelerine [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) üzerinden erişir. Çalışma sayfası 0’da B2 dönüşüm oranını, C2 ise katsayıyı içerir. Her iki hücre de grafik değerlerini sağlar. Örnek ayrıca, kaynak biçimlere bağlı değer etiketlerini etkinleştirir.

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

Çalışma kitabı hücre biçimleri, grafik eksenleri veya veri etiketlerinde doğrudan ayarlanan biçimlerden ayrı tutulur. Bu örnekte, her etiket kaynak hücresinin değerini görüntüler çünkü [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) etkinleştirilmiştir ve [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) `True` olarak ayarlanmıştır. Sunumu kaydedip yeniden açtıktan sonra etiketler `12.5000%` ve `0.12346` gösterir. Dikey eksen ise kendi [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) `0.00` biçimini kullanır ve [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) `False` olarak ayarlanmıştır.

Bir veri etiketini bağımsız biçimlendirmek için, kaynak‑bağlantı bayrağını `False` yapın ve [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/) atayın. Bu, çalışma kitabı hücresinin biçimini değiştirmez. Örneğin, bağımsız bir etiket biçimi `0.00` ilk değeri `0.13` olarak gösterirken B2 hâlâ `12.5000%` gösterir. Doğrudan etiket biçimlendirme için [Chart Data Labels](/slides/tr/python-net/chart-data-label/#set-percentage-sign-with-chart-data-labels) bölümüne bakın.

Aşağıdaki görsel, kaydedilen sunumu yeniden açtıktan sonra oluşturulmuştur:

![Kaynak‑bağlantılı etiketlerin 12.5000% ve 0.12346, bağımsız biçimlendirilmiş sayısal eksen gösterdiği bir sütun grafik.](custom-cell-formats.png)

## **Bir Çalışma Kitabı Hücresini Grafik Veri Etiketi Olarak Ayarlama**

Çalışma kitabı hücrelerinden alınan metni grafik veri etiketi olarak kullanabilirsiniz.

Bu örnek, mevcut bir sunumun ilk slaydına varsayılan verilerle bir balon grafik ekler. Hücre A10:A12 (çalışma sayfası 0) ilk serinin ilk üç etiketi olarak kullanılır, hücrelerden etiketler etkinleştirilir ve güncellenen sunum kaydedilir.

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

## **Çalışma Sayfalarını Yönetme**

[ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) özelliği, bir grafik çalışma kitabındaki çalışma sayfalarına erişim sağlar. Bu örnek, varsayılan verilerle bir pasta grafik oluşturur ve her çalışma sayfasının adını konsola yazar.

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

## **Veri Kaynağı Türünü Belirleme**

Seri nokta değerleri doğrudan sayısal değişmezler olarak da saklanabilir. Bütün bir örnek için [Set Series Values Using Numeric Literals](/slides/tr/python-net/chart-series/#set-series-values-using-numeric-literals) bölümüne bakın. Nokta değerlerinin veri kaynağı türü, grafiğin dahili veya harici çalışma kitabı yapılandırmasından ayrıdır; sayısal değişmezler kullanmak tek başına yerleşik çalışma kitabını kaldırmaz.

Bu örnek, varsayılan verilerle bir 3D sütun grafik oluşturur ve iki seri adını farklı veri kaynaklarıyla ayarlar. İlk ad bir dize değişmezü, ikinci ad ise çalışma sayfası 0’da C1 hücresidir. [DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) enumı, her ad için kaynağı seçer. Örnek, güncellenen seri adlarıyla sunumu kaydeder.

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

## **Desteklenmeyen Yerleşik Çalışma Kitabı Biçimlerini Algılama**

Aspose.Slides, bazı grafiklerde yerleşik olarak bulunabilen Excel ikili çalışma kitabı (.xlsb) formatını desteklemez. [ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) üzerindeki [embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) özelliği ile [WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/) enumını birlikte kullanarak desteklenmeyen biçimleri tespit edebilir ve bu grafikleri atlayabilirsiniz. Bu örnek, mevcut bir sunumun ilk slaydındaki şekilleri inceler, grafik olmayan şekilleri atlar ve .xlsb yerleşik çalışma kitabı içeren her grafik için tanı mesajı yazar.

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

        # Burada desteklenen grafik çalışma kitabı verilerini okuyun veya değiştirin.
```

## **Harici Çalışma Kitabı**

Aspose.Slides, grafikler için harici çalışma kitaplarını veri kaynağı olarak kullanmayı destekler.

### **Harici Çalışma Kitabı Oluşturma**

[read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) ve [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) kullanarak bir yerleşik grafik çalışma kitabını bir dosyaya dışa aktarabilir ve grafiği bu harici çalışma kitabına bağlayabilirsiniz.

Bu örnek, varsayılan verilerle bir pasta grafik oluşturur ve çalışma kitabını dışa aktarır. Dışa aktarılan akışı kapattıktan sonra harici çalışma kitabını grafik veri kaynağı olarak atar, ardından bağlı sunumu kaydeder.

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

### **Harici Çalışma Kitabını Ayarlama**

[set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) yöntemiyle bir grafiğe harici bir çalışma kitabını veri kaynağı olarak atayabilirsiniz. Bu yöntem, harici çalışma kitabının yolu taşındıysa yolu güncellemek için de kullanılabilir.

Uzak konumlardaki veya kaynaklardaki çalışma kitaplarının verilerini doğrudan düzenleyemezsiniz, ancak bu kitaplar harici veri kaynağı olarak kullanılabilir. Göreceli bir yol sağlanırsa, otomatik olarak tam yola dönüştürülür.

Bu örnek, `Sheet1` adlı çalışma sayfasında B1’de bir seri adı, A2:A4’te kategori adları ve B2:B4’te sayısal değerler bulunan bir harici çalışma kitabı kullanır. Pasta grafik oluşturur, çalışma kitabını bağlar ve [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) ile A1:B4 aralığını bir seri ve üç kategoriye eşler. Bağlı grafikle birlikte sunumu kaydeder.

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

[set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) metodundaki `update_chart_data` parametresi, çalışma kitabının yüklenip yüklenmeyeceğini kontrol eder.

* `update_chart_data` `False` olduğunda yalnızca çalışma kitabı yolu güncellenir. Grafik verisi hedef çalışma kitabından yüklenmez veya güncellenmez; bu nedenle çalışma kitabı mevcut olmayabilir.
* `update_chart_data` `True` olduğunda grafik verisi hedef çalışma kitabından güncellenir.

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

### **Bir Grafiğin Harici Veri Kaynağı Çalışma Kitabı Yolunu Almak**

Bir grafiğin bağlı olduğu çalışma kitabını belirlemek için, grafiğin harici bir veri kaynağı kullanıp kullanmadığını kontrol edin ve çalışma kitabı yolunu alın.

Bu örnek, bir harici çalışma kitabına bağlanmış bir sunumun ilk slaydındaki ilk şekli inceler. Eğer şekil harici bir çalışma kitabına bağlı bir grafikse, [external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) konsola yazar. Ardından sunumun bir kopyasını kaydeder.

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

### **Grafik Verilerini Düzenleme**

Harici çalışma kitaplarındaki verileri, iç çalışma kitaplarındaki gibi düzenleyebilirsiniz. Harici çalışma kitabı yüklenemezse bir istisna atılır.

Bu örnek, ilk slayttaki ilk şekil olarak bir grafik kullanır ve erişilebilir bir harici çalışma kitabına bağlanır. İlk serinin ilk veri noktasının hücre‑tabanlı değerini 100 olarak ayarlar ve güncellenen sunumu kaydeder. Hücre değerlerini düzenlemek, bağlı harici XLSX dosyasını güncelleyebilir; bu yüzden orijinali korumak istiyorsanız bir kopya kullanın.

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

### **Grafik Önbelleğinden Çalışma Kitabı Kurtarma**

Bir grafik, eksik veya mevcut olmayan bir harici çalışma kitabına sahipse, Aspose.Slides sunumda önbellekteki verilerden grafik çalışma kitabını yeniden oluşturabilir. [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) oluşturun, [spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/) yapılandırın ve [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) özelliğini `True` yaparak sunumu açmadan önce ayarlayın.

Aşağıdaki Python örneği, ilk slayttaki ilk şekil olarak bir grafik ve erişilemeyen bir harici çalışma kitabına referans veren bir senaryoda çalışma kitabı verilerini kurtarır. Kurtarılan verilere [Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/) ve [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) aracılığıyla erişir:

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

        # Burada kurtarılan çalışma kitabı verilerini okuyun veya değiştirin.
    else:
        print("The first shape is not a chart.")
```

Harici çalışma kitabı mevcut değilse ve kurtarma devre dışı bırakılırsa, Aspose.Slides bir istisna fırlatır. Önbellekten grafik verilerini kullanmak kabul edilebilir bir geri dönüşse yalnızca kurtarmayı etkinleştirin; önbellek, sunum son güncellendikten sonra harici çalışma kitabında yapılan değişiklikleri içermeyebilir.

## **SSS**

**Belirli bir grafiğin harici mi yoksa yerleşik bir çalışma kitabına mı bağlı olduğunu belirleyebilir miyim?**

Evet. Bir grafiğin [veri kaynağı türü](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) ve [harici bir çalışma kitabının yolu](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) vardır; kaynak bir harici çalışma kitabıysa tam yolu okuyarak bir dış dosyanın kullanıldığını doğrulayabilirsiniz.

**Harici çalışma kitapları için göreceli yollar destekleniyor mu ve nasıl depolanıyor?**

Evet. Göreceli bir yol belirttiğinizde otomatik olarak mutlak yola dönüştürülür. Sunum, mutlak yolu PPTX dosyasında saklar; bu nedenle çalışma kitabını taşıdığınızda bağlantıyı güncellemeniz gerekebilir.

**Ağ kaynakları/paylaşımları üzerindeki çalışma kitaplarını kullanabilir miyim?**

Evet, bu tür çalışma kitapları harici veri kaynağı olarak kullanılabilir. Ancak Aspose.Slides ile uzak çalışma kitaplarını doğrudan düzenleme desteklenmez; sadece kaynak olarak kullanılabilirler.

**Aspose.Slides sunumu kaydederken harici XLSX dosyasını üzerine yazar mı?**

Sunum, harici dosyaya bir [bağlantı](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) saklar. Hücre‑tabanlı grafik verilerini düzenlemek, bağlı yerel XLSX dosyasını da güncelleyebilir. Orijinal dosyanın değişmemesi gerekiyorsa çalışma kitabının bir kopyasını kullanın.

**Harici dosya parola korumalıysa ne yapmalıyım?**

Aspose.Slides, bağlanırken parola kabul etmez. Yaygın bir yaklaşım, önceden korumayı kaldırmak ya da bir kopyasını (örneğin [Aspose.Cells](https://reference.aspose.com/cells/python-net/) ile) şifresiz olarak hazırlayıp ona bağlanmaktır.

**Birden fazla grafik aynı harici çalışma kitabına başvurabilir mi?**

Evet. Her grafik kendi bağlantısını saklar. Hepsi aynı dosyaya işaret ediyorsa, dosya güncellendiğinde veri bir sonraki yüklemede her grafik için yansıtılacaktır.