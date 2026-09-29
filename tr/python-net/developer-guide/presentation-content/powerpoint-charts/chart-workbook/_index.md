---
title: Python ile Sunumlarda Grafik Çalışma Kitaplarını Yönetme
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
description: "Aspose.Slides for Python via .NET'i keşfedin: PowerPoint ve OpenDocument formatlarında grafik çalışma kitaplarını zahmetsizce yöneterek sunum verilerinizi düzenleyin."
---
## **Genel Bakış**

Bu makale Aspose.Slides'da grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Çalışma kitabı akışları aracılığıyla grafik verilerini okuma ve yazma, çalışma kitabı hücrelerini grafik veri etiketleri olarak kullanma, çalışma sayfası koleksiyonlarına erişme ve grafik değerleri için veri kaynağı türünü belirtme yöntemlerini gösterir.

Ayrıca harici çalışma kitaplarının grafik veri kaynağı olarak kullanılmasını da kapsar. Örnekler, harici bir çalışma kitabı oluşturup atamayı, bir grafik ile ilişkilendirilmiş harici çalışma kitabının yolunu almayı ve çalışma kitabı mevcut olduğunda grafik verilerini düzenlemeyi gösterir.

Eksik veri temsil eden çalışma kitabı hücreleri için boş bir hücre ile sıfır arasındaki farkı ve mevcut görüntüleme modlarının bir çizgi grafik karşılaştırmasını görmek üzere [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/python-net/chart-series/) bölümüne bakın.

## **Gizli Satır ve Sütunlardan Veri İçerme**

[Chart.plot_visible_cells_only](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) özelliğini kullanarak bir grafiğin gizli çalışma sayfası satır ve sütunlarından veri çizip çizmeyeceğini kontrol edin. Görünür hücreleri çizmek için `True`, hem görünür hem de gizli hücreleri dahil etmek için `False` olarak ayarlayın. Bu ayar grafik çizimini kontrol eder; çalışma sayfası satırlarını veya sütunlarını gizlemez veya göstermez.

[hidden-source-data.pptx](hidden-source-data.pptx) dosyasını indirin ve çalışma dizinine yerleştirin. İlk slaytı, ilk şekil olarak bir sütun grafik içerir. Gömülü çalışma sayfası `Sheet1`, aşağıdaki kaynak aralığını, `A1:C4`, içerir. Satır 3 ve sütun C gizlidir, ancak hücreleri hâlâ değer içerir.

| Çalışma sayfası satırı | A: Ay | B: Perakende | C: Toptan (gizli sütun) |
| --- | --- | --- | --- |
| 2 | Ocak | 10 | 30 |
| 3 (gizli satır) | Şubat | 40 | 60 |
| 4 | Mart | 20 | 50 |

Kaynak hücrelere [ChartData.chart_data_workbook](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) üzerinden erişin ve gizli durumlarını incelemek için [ChartDataCell.is_hidden](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdatacell/is_hidden/) özelliğini okuyun. Bu özellik yalnızca okunabilir. Bu dosyada B2 görünür, B3 gizli satıra ait ve C2 gizli sütuna ait; örnek sırasıyla `False`, `True` ve `True` değerlerini yazdırır.

Bu örnek için çizim ayarı değiştirildikten sonra grafiğin verilerini yenileyin: gömülü çalışma kitabını [read_workbook_stream](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) ile tutun ve [write_workbook_stream](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) ile yeniden yükleyin. Tüm hücreler dahil edildiğinde gizli Şubat kategorisini de içerecek şekilde tam aralığı geri yüklemek için [set_range](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/set_range/) kullanın. Sadece bayrağı değiştirmek, bu örnek için önbelleğe alınmış grafik verilerini ve kategori etiketlerini yenilemek için yeterli değildir.

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

            # Yerleşik çalışma kitabından grafik verilerini yenile.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # Gizli kategorileri de içerecek şekilde tam kaynak aralığını geri yükle.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

Örnek, yalnızca görünür Perakende değerleri (10 ve 20) ile `hidden_cells_True.pptx` ve tüm altı değer ile `hidden_cells_False.pptx` dosyalarını kaydeder. Aşağıdaki görseller, kayıtlı sunumlar yeniden açıldıktan sonra oluşturulmuş ve her iki dosya da atanan çizim ayarını korur. Satır 3 ve sütun C, her iki gömülü çalışma kitabında da gizli kalır.

| Yalnızca görünür hücreler (`True`) | Tüm hücreler (`False`) |
| --- | --- |
| ![Yalnızca görünür hücreler: Ocak ve Mart ayları için Perakende değerleri 10 ve 20.](hidden_cells_True.png) | ![Tüm hücreler: Ocak, Şubat ve Mart ayları için Perakende ve Toptan değerleri.](hidden_cells_False.png) |

Değer içeren bir gizli hücre, boş bir hücreden farklıdır. [Chart.display_blanks_as](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chart/display_blanks_as/) eksik değerlerin nasıl görüntüleneceğini kontrol eder; gizli kaynak verilerini içermez veya dışarı çıkarmaz. Bir örnek için [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/python-net/chart-series/#control-the-display-of-empty-cells) bölümüne bakın.

## **Bir Çalışma Kitabından Grafik Verilerini Okuma ve Yazma**

Aspose.Slides for Python via .NET, [read_workbook_stream](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) ve [write_workbook_stream](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) yöntemlerini sağlar; bu yöntemler, Aspose.Cells ile düzenlenen grafik verilerini içeren çalışma kitaplarını okumanıza ve yazmanıza olanak tanır. **Not** grafik verileri aynı şekilde düzenlenmiş olmalı veya kaynağa benzer bir yapıya sahip olmalıdır.

Bu örnek, ilk slaytının ilk şekli olarak bir grafik içermesi gereken `chart.pptx` dosyasını açar. Gömülü çalışma kitabını bir akışa okur, mevcut serileri ve kategorileri temizler ve aynı çalışma kitabını geri yazar. Değişiklikler bellekte kalır; örnek sunumu kaydetmez.

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

Gömülü bir çalışma kitabını değiştirilmiş bir kitapla değiştirdiğinizde, grafik orijinal seri ve kategori koleksiyonlarını tutar. Bu uyumsuzluk, [Chart.validate_chart_layout](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chart/validate_chart_layout/) metodunun indeks dışı hatasıyla başarısız olmasına neden olabilir. Güncellenmiş çalışma kitabını grafiğe geri yazmadan önce mevcut serileri ve kategorileri temizleyin. Bu örnek, ilk slaytının ilk şekli olarak bir grafik içeren `chart.pptx` dosyasını gerektirir. Yorum satırları, çalışma kitabı düzenlemesinin nerede gerçekleşeceğini gösterir; çalıştırılabilir örnek, orijinal çalışma kitabını geri yazar ve bellekte düzeni doğrular.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # Burada çalışma kitabı akışını değiştirin, örneğin Aspose.Cells kullanarak.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

Koleksiyonları temizlemek, çalışma kitabı geri yazılmadan önce eski veri referanslarını kaldırır. Güncellenmiş çalışma kitabı için gerekli serileri ve kategori eşlemelerini yeniden oluşturun ve ardından grafiği kullanın.

## **Bir Çalışma Kitabı Hücresini Grafik Veri Etiketi Olarak Ayarlama**

Çalışma kitabı hücrelerindeki metni grafik veri etiketleri olarak kullanabilirsiniz. Aşağıdaki adımlar, bir balon grafiğinde etiketleri veri kitabındaki hücrelere bağlamayı gösterir.

1. Presentation sınıfının bir örneğini oluşturun.
2. Sıfır tabanlı indeksiyle ilk slayta erişin.
3. Varsayılan verilerle bir balon grafiği ekleyin.
4. Grafik serisine erişin.
5. Çalışma kitabı hücresini veri etiketi olarak ayarlayın.
6. Sunumu kaydedin.

Bu örnek, en az bir slayt içeren `chart2.pptx` dosyasını açar ve varsayılan veriyle bir balon grafiği ekler. İlk serideki ilk üç etiket için çalışma sayfası 0'da A10:A12 hücrelerini kullanır, hücrelerden etiket alımını etkinleştirir ve sonucu `resultchart.pptx` olarak kaydeder.

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

[ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) özelliği, bir grafik çalışma kitabındaki çalışma sayfalarına erişim sağlar. Bu örnek, varsayılan veriyle bir pasta grafik oluşturur ve her çalışma sayfasının adını konsola yazdırır.

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

## **Veri Kaynağı Türünü Belirtme**

Bu örnek, varsayılan veriyle bir 3D sütun grafik oluşturur ve iki seri adını farklı veri kaynaklarıyla ayarlar. İlk ad, bir dize sabiti kullanır; ikincisi, çalışma sayfası 0'da C1 hücresini kullanır. [DataSourceType](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/datasourcetype/) enum'ı, her adın kaynağını seçer. Sonuç `pres.pptx` olarak kaydedilir.

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

Aspose.Slides, bazı grafiklerde gömülebilen Excel ikili çalışma kitabı (.xlsb) biçimini desteklemez. [ChartData](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/) üzerindeki [embedded_workbook_type](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) özelliğini ve [WorkbookType](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/workbooktype/) enum'ını birlikte kullanarak desteklenmeyen biçimleri algılayabilir ve bu grafikleri atlayabilirsiniz. Bu örnek, `sample.pptx` dosyasının ilk slaydındaki şekilleri inceler, grafik olmayan şekilleri atlar ve gömülü .xlsb çalışma kitabı olan her grafik için tanı mesajı yazdırır.

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

Aspose.Slides, grafikler için veri kaynağı olarak harici çalışma kitaplarını kullanmayı destekler.

### **Harici Çalışma Kitabı Oluşturma**

[read_workbook_stream](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) ve [set_external_workbook](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/set_external_workbook/) yöntemlerini kullanarak gömülü bir grafik çalışma kitabını bir dosyaya dışa aktarabilir ve grafiği bu harici çalışma kitabına bağlayabilirsiniz.

Bu örnek, varsayılan veriyle bir pasta grafik oluşturur, çalışma kitabını `externalWorkbook1.xlsx` dosyasına yazar ve çıktıyı kapatıp dosyayı grafik veri kaynağı olarak atar. Bağlantılı sunumu `externalWorkbook.pptx` olarak kaydeder.

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

### **Harici Çalışma Kitabı Ayarlama**

[set_external_workbook](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/set_external_workbook/) metodunu kullanarak bir grafiğe harici bir çalışma kitabını veri kaynağı olarak atayabilirsiniz. Bu yöntem, harici çalışma kitabının yolunu değiştirerek (dosya taşındıysa) güncellemek için de kullanılabilir.

Uzak konumlardaki veya kaynaklardaki çalışma kitaplarının verileri doğrudan düzenlenemez, ancak bu tür çalışma kitapları harici veri kaynağı olarak kullanılabilir. Bir harici çalışma kitabı için göreli bir yol sağlanırsa, otomatik olarak tam bir yola dönüştürülür.

Bu örnek, çalışma dizininde `externalWorkbook.xlsx` dosyasının bulunmasını gerektirir. `Sheet1` adlı çalışma sayfası, B1 hücresinde bir seri adı, A2:A4 aralığında kategori adları ve B2:B4 aralığında sayısal değerler içermelidir. Örnek bir pasta grafik oluşturur, çalışma kitabını bağlar ve [set_range](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/set_range/) ile A1:B4 aralığını bir seri ve üç kategori olarak eşler. Sonuç `Presentation_with_externalWorkbook.pptx` olarak kaydedilir.

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

[set_external_workbook](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/set_external_workbook/) metodunun `update_chart_data` parametresi, çalışma kitabının yüklenip yüklenmeyeceğini kontrol eder.

* `update_chart_data` **False** olduğunda, yalnızca çalışma kitabı yolu güncellenir. Grafik verisi hedef çalışma kitabından yüklenmez veya güncellenmez; bu nedenle çalışma kitabı mevcut olmayabilir.
* `update_chart_data` **True** olduğunda, grafik verisi hedef çalışma kitabından güncellenir.

Aşağıdaki örnek, `update_chart_data` **False** olarak ayarlanmış bir yer tutucu URL atar. Pasta grafiğinin varsayılan verilerini korur ve mevcut olmayan çalışma kitabını yüklemeden sunumu kaydeder.

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

Bir grafiğin hangi çalışma kitabına bağlı olduğunu belirlemek için önce grafiğin harici bir veri kaynağı kullanıp kullanmadığını kontrol edin. Kullanıyorsa, aşağıdaki adımları izleyerek çalışma kitabı yolunu alabilirsiniz.

1. Presentation sınıfının bir örneğini oluşturun.
2. Sıfır tabanlı indeksiyle ilk slayta erişin.
3. İlk şeklin bir grafik olduğundan emin olun.
4. Grafik veri kaynağı türünü okuyun.
5. Kaynak harici bir çalışma kitabı ise, yolunu okuyun.

Bu örnek, önceki örnekte oluşturulan `externalWorkbook.pptx` dosyasını açar ve ilk slaydın ilk şekline bakar. Eğer bu şekil harici bir çalışma kitabına bağlı bir grafikse, [external_workbook_path](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/external_workbook_path/) değerini konsola yazdırır. Ardından sunumun bir kopyasını `Result.pptx` olarak kaydeder.

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

Harici çalışma kitaplarındaki verileri, iç çalışma kitaplarındaki gibi düzenleyebilirsiniz. Harici bir çalışma kitabı yüklenemediğinde bir istisna fırlatılır.

Bu örnek, ilk slaydının ilk şekli olarak bir grafik içeren `presentation.pptx` dosyasını ve erişilebilir bir harici çalışma kitabını gerektirir. İlk serinin ilk veri noktasının hücre destekli değerini 100 olarak ayarlar ve sunumu `presentation_out.pptx` olarak kaydeder. Hücre değerlerini düzenlemek, bağlanan harici XLSX dosyasını da güncelleyebilir; bu nedenle orijinali korumak istiyorsanız bir kopya kullanın.

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

### **Grafik Önbelleğinden Çalışma Kitabını Kurtarma**

Bir grafik, eksik veya mevcut olmayan bir harici çalışma kitabı kullanıyorsa, Aspose.Slides, sunumda önbelleğe alınan verilerden grafik çalışma kitabını yeniden oluşturabilir. [LoadOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides/loadoptions/) oluşturun, [spreadsheet_options](https://reference.aspose.com/slides/tr/python-net/aspose.slides/loadoptions/spreadsheet_options/) yapılandırın ve [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/tr/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) özelliğini `True` olarak ayarlayın; ardından sunumu açın.

Aşağıdaki Python örneği, ilk slaydının ilk şekli olarak bir grafik içeren `presentation.pptx` dosyasını açar; bu grafik, mevcut olmayan bir harici çalışma kitabına başvurur. Kurtarılan veriye [Chart.chart_data](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chart/chart_data/) ve [ChartData.chart_data_workbook](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) üzerinden erişir:

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

Harici çalışma kitabı mevcut değil ve kurtarma devre dışı bırakılmışsa, Aspose.Slides bir istisna fırlatır. Önbellekten gelen grafik verilerini kullanmak kabul edilebilir bir geri dönüşümse, kurtarmayı etkinleştirin; çünkü önbellek, sunum son güncellendiğinde harici çalışma kitabında yapılan değişiklikleri içermeyebilir.

## **SSS**

**Belirli bir grafiğin harici mi yoksa gömülü bir çalışma kitabına mı bağlı olduğunu belirleyebilir miyim?**

Evet. Bir grafiğin bir [data source type](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/data_source_type/) ve bir [path to an external workbook](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/external_workbook_path/) vardır; kaynak bir harici çalışma kitabıysa, tam yolu okuyarak bir dış dosyanın kullanıldığını doğrulayabilirsiniz.

**Harici çalışma kitapları için göreli yollar destekleniyor mu, nasıl depolanıyor?**

Evet. Bir göreli yol belirtirseniz, otomatik olarak mutlak bir yola dönüştürülür. Sunum, mutlak yolu PPTX dosyasında saklar; bu nedenle çalışma kitabını taşıdığınızda bağlantıyı güncellemeniz gerekebilir.

**Ağ kaynakları/paylaşımları üzerindeki çalışma kitaplarını kullanabilir miyim?**

Evet, bu tür çalışma kitapları harici veri kaynağı olarak kullanılabilir. Ancak, Aspose.Slides doğrudan uzak çalışma kitaplarını düzenlemeyi desteklemez; yalnızca bir kaynak olarak kullanılabilirler.

**Aspose.Slides, sunumu kaydederken harici XLSX dosyasını üzerine yazar mı?**

Sunum, dış dosyaya bir [link to the external file](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/external_workbook_path/) saklar. Hücre destekli grafik verilerini düzenlemek, bağlı yerel XLSX dosyasını da güncelleyebilir. Orijinal dosyanın değişmemesi gerekiyorsa bir kopya kullanın.

**Harici dosya şifre korumalıysa ne yapmalıyım?**

Aspose.Slides, bağlantı sırasında şifre kabul etmez. Yaygın bir yöntem, önceden korumayı kaldırmak veya bir şifre çözülmüş kopya hazırlamaktır (örneğin, [Aspose.Cells](https://reference.aspose.com/cells/python-net/) kullanarak) ve bu kopyaya bağlanmaktır.

**Birden fazla grafik aynı harici çalışma kitabına başvurabilir mi?**

Evet. Her grafik kendi bağlantısını saklar. Hepsi aynı dosyaya işaret ediyorsa, dosya güncellendiğinde veri bir sonraki yüklemede her grafik için yansıtılır.