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
description: "Aspose.Slides for Python via .NET'i keşfedin: PowerPoint ve OpenDocument formatlarında grafik çalışma kitaplarını kolayca yönetin ve sunum verilerinizi düzenleyin."
---
## **Genel Bakış**

Bu makale Aspose.Slides’da grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Çalışma kitabı akışları aracılığıyla grafik verilerini nasıl okuyup yazacağınızı, çalışma kitabı hücrelerini grafik veri etiketi olarak nasıl kullanacağınızı, çalışma sayfası koleksiyonlarına nasıl erişeceğinizi ve grafik değerleri için veri kaynağı türünü nasıl belirteceğinizi gösterir.

Ayrıca harici çalışma kitaplarının grafik veri kaynağı olarak nasıl kullanılacağını kapsar. Örnekler, harici bir çalışma kitabı oluşturup atamayı, bir grafikle ilişkilendirilmiş harici çalışma kitabının yolunu almayı ve çalışma kitabı mevcut olduğunda grafik verisini düzenlemeyi gösterir.

Eksik veriyi temsil eden çalışma kitabı hücreleri için, boş bir hücre ile sıfır arasındaki farkı ve kullanılabilir görüntüleme modlarının çizgi grafiği karşılaştırmasını görmek üzere [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/python-net/chart-series/) sayfasına bakın.

## **Gizli Satır ve Sütunlardan Veri Dahil Et**

[Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) kullanarak bir grafiğin gizli çalışma sayfası satır ve sütunlarından veri çizip çizmeyeceğini kontrol edin. Görünür hücreleri çizmek için `True`, hem görünür hem de gizli hücreleri dahil etmek için `False` olarak ayarlayın. Bu ayar grafik çizimini kontrol eder; çalışma sayfası satır veya sütunlarını gizlemez veya göstermez.

[örnek sunum](hidden-source-data.pptx) ilk slaytındaki ilk şekil olarak bir sütun grafik içerir. Gömülü çalışma sayfası `Sheet1`, `A1:C4` kaynak aralığını içerir. 3. satır ve C sütunu gizlidir, ancak hücreleri hâlâ değer içerir.

| Çalışma sayfası satırı | A: Ay | B: Perakende | C: Toptan (gizli sütun) |
| --- | --- | --- | --- |
| 2 | Ocak | 10 | 30 |
| 3 (gizli satır) | Şubat | 40 | 60 |
| 4 | Mart | 20 | 50 |

Kaynak hücrelere [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) üzerinden erişin ve gizli durumlarını incelemek için [ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/) özelliğini okuyun. Bu özellik yalnızca okunabilir. Bu dosyada B2 görüntülenir, B3 gizli satıra aittir ve C2 gizli sütuna aittir; örnek sırasıyla `False`, `True` ve `True` yazdırır.

Bu örnek için, çizim ayarını değiştirdikten sonra grafik verisini yenileyin: gömülü çalışma kitabını [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) ile tutun ve [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) ile yeniden yükleyin. Tüm hücreleri dahil ederken, gizli Şubat kategorisini geri getirmek için [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) da kullanın. Sadece bayrağı değiştirmek bu örnekdeki önbelleğe alınmış grafik verisini ve kategori etiketlerini yenilemek için yeterli değildir.

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

Örnek, yalnızca görünür Perakende değerleri (10 ve 20) içeren bir sunum sürümü ve altı değerin tamamını içeren bir diğer sürüm kaydeder. Aşağıdaki görseller, kaydedilen sunumlar tekrar açıldıktan sonra oluşturulmuş olup, her iki dosya da atanan çizim ayarını korur. Satır 3 ve C sütunu her iki gömülü çalışma kitabında da gizli kalır.

| Yalnızca görünür hücreler (`True`) | Tüm hücreler (`False`) |
| --- | --- |
| ![Yalnızca görünür hücreler: Ocak ve Mart için Perakende değerleri 10 ve 20.](hidden_cells_True.png) | ![Tüm hücreler: Ocak, Şubat ve Mart için Perakende ve Toptan değerleri.](hidden_cells_False.png) |

Değer içeren gizli bir hücre, boş bir hücreden farklıdır. [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) eksik değerlerin nasıl gösterileceğini kontrol eder; gizli kaynak veriyi dahil etmez veya hariç tutmaz. Bir örnek için [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/python-net/chart-series/#control-the-display-of-empty-cells) sayfasına bakın.

## **Grafiğin Veri Aralığını Al**

Mevcut bir sunumda çalışma kitabı verilerini güncellemeden önce, her grafiğin hangi çalışma sayfası hücrelerini kullandığını belirlemek amacıyla kaynak aralıkları inceleyin. [ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/) yöntemi, `Sheet1!$A$1:$D$5` gibi bir çalışma sayfası kalifiye formülü olarak geçerli veri aralığını döndürür. Burada `Sheet1` çalışma sayfası adıdır, `!` hücre aralığından ayırır ve `$A$1:$D$5` A1’den D5’e kadar olan hücreleri (dahil) belirtir. `$` işaretleri mutlak satır ve sütun referanslarını gösterir.

Yöntem, grafiği veya çalışma kitabını değiştirmeden geçerli aralığı okur. Grafik veri kaynağı olarak bir çalışma kitabı kullanmıyorsa bir istisna fırlatır. Daha fazla bilgi için [ChartData API Reference](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) sayfasına bakın.

Bu örnek bir sunumu açar ve her slayttaki şekilleri doğrudan kontrol ederek grafik olup olmadığını denetler. Her grafiğin adını ve kaynak aralığını yazdırır. Aralık alınamıyorsa tanı mesajı verir ve sonraki grafiğe geçer.

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

Aspose.Slides for Python via .NET, [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) ve [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) yöntemlerini sağlayarak grafik veri çalışma kitaplarını (Aspose.Cells ile düzenlenmiş) okuyup yazmanıza olanak tanır. **Not** grafik verisinin aynı şekilde düzenlenmiş olması ya da kaynağa benzer bir yapıya sahip olması gerekir.

Bu örnek, ilk slaytındaki ilk şekil olarak bir grafiği olan bir sunum kullanır. Gömülü çalışma kitabını bir akıma okur, mevcut serileri ve kategorileri temizler ve aynı çalışma kitabını tekrar yazar. Değişiklikler bellekte kalır; örnek sunumu kaydetmez.

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

Gömülü bir çalışma kitabını değiştirilmiş bir kitapla değiştirdiğinizde, grafik orijinal serileri ve kategori koleksiyonlarını korur. Bu uyumsuzluk, [Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) yönteminin indeks dışı hata vermesine neden olabilir. Güncellenmiş çalışma kitabını grafiğe geri yazmadan önce mevcut serileri ve kategorileri temizleyin. Bu örnek, ilk slayttaki ilk şekil olarak bir grafik kullanır. Yorum satırı, çalışma kitabı düzenlemesinin nerede gerçekleşeceğini işaret eder; çalıştırılabilir örnek orijinal çalışma kitabını geri yazar ve bellekte düzeni doğrular.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # Çalışma kitabı akışını burada değiştirin, örneğin Aspose.Cells kullanarak.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

Koleksiyonların temizlenmesi, çalışma kitabı geri yazılmadan önce eski veri referanslarını kaldırır. Güncellenmiş çalışma kitabı için gerekli serileri ve kategori eşlemelerini yeniden oluşturun, ardından grafiği kullanın.

## **Bir Çalışma Kitabı Hücresini Grafik Veri Etiketi Olarak Ayarla**

Çalışma kitabı hücrelerindeki metni grafik veri etiketi olarak kullanabilirsiniz.

Bu örnek, mevcut bir sunumun ilk slaytına varsayılan verilere sahip bir balon grafiği ekler. 0‑ıncı çalışma sayfasındaki A10:A12 hücrelerini ilk serinin ilk üç etiketi olarak kullanır, hücrelerden etiketleri etkinleştirir ve güncellenmiş sunumu kaydeder.

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

[ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) özelliği, bir grafik çalışma kitabındaki çalışma sayfalarına erişim sağlar. Bu örnek, varsayılan veriyle bir pasta grafik oluşturur ve her çalışma sayfası adını konsola yazdırır.

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

## **Veri Kaynağı Türünü Belirle**

Bu örnek, varsayılan veriyle bir 3B sütun grafik oluşturur ve iki seri adını farklı veri kaynakları kullanarak ayarlar. İlk ad bir dize sabiti; ikinci ad 0‑ıncı çalışma sayfasındaki C1 hücresinden alınır. [DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) enumu, her ad için kaynağı seçer. Örnek, güncellenmiş seri adlarıyla sunumu kaydeder.

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

## **Desteklenmeyen Gömülü Çalışma Kitabı Formatlarını Algıla**

Aspose.Slides, bazı grafiklerde gömülebilen Excel ikili çalışma kitabı (.xlsb) formatını desteklemez. Bu formatları algılamak ve ilgili grafiklerden kaçınmak için [ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) üzerindeki [embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) özelliğini [WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/) enumu ile birlikte kullanabilirsiniz. Bu örnek, mevcut bir sunumun ilk slaytındaki şekilleri inceler, grafik olmayanları atlar ve .xlsb gömülü çalışma kitabı olan her grafik için tanı mesajı yazdırır.

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

        # Desteklenen grafik çalışma kitabı verilerini burada oku veya değiştir.
```

## **Harici Çalışma Kitabı**

Aspose.Slides, harici çalışma kitaplarını grafik veri kaynağı olarak kullanmayı destekler.

### **Harici Bir Çalışma Kitabı Oluştur**

[read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) ve [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) kullanarak gömülü bir grafik çalışma kitabını bir dosyaya dışa aktarın ve grafiği bu harici çalışma kitabına bağlayın.

Bu örnek, varsayılan veriyle bir pasta grafik oluşturur ve çalışma kitabını dışa aktarır. Harici çalışma kitabını grafik veri kaynağı olarak atamadan önce çıktı akışını kapatır, ardından bağlantılı sunumu kaydeder.

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

### **Harici Bir Çalışma Kitabı Ayarla**

[set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) yöntemiyle bir grafiğe harici bir çalışma kitabını veri kaynağı olarak atayabilirsiniz. Bu yöntem, harici çalışma kitabının yolu taşındıysa yolu güncellemek için de kullanılabilir.

Uzak konumlardaki veya kaynaklardaki çalışma kitaplarındaki verileri doğrudan düzenleyemezsiniz, ancak bu kitaplar harici veri kaynağı olarak kullanılabilir. Bir harici çalışma kitabı için göreceli bir yol sağlanırsa, otomatik olarak tam yola dönüştürülür.

Bu örnek, `Sheet1` adlı çalışma sayfasında B1 hücresinde bir seri adı, A2:A4 aralığında kategori adları ve B2:B4 aralığında sayısal değerler içeren bir harici çalışma kitabı kullanır. Pasta grafik oluşturur, çalışma kitabını bağlar ve [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) kullanarak A1:B4 aralığını bir seri ve üç kategoriye eşler. Bağlantılı grafikli sunumu kaydeder.

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

[set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) yöntemindeki `update_chart_data` parametresi, çalışma kitabının yüklenip yüklenmeyeceğini kontrol eder.

* `update_chart_data` **False** olduğunda yalnızca çalışma kitabı yolu güncellenir. Grafik verisi hedef çalışma kitabından yüklenmez veya güncellenmez, bu yüzden çalışma kitabı mevcut olmayabilir.
* `update_chart_data` **True** olduğunda grafik verisi hedef çalışma kitabından güncellenir.

Aşağıdaki örnek, `update_chart_data` **False** olarak ayarlanmış bir yer tutucu URL atar. Pasta grafiğinin varsayılan verisini korur ve mevcut olmayan çalışma kitabını yüklemeden sunumu kaydeder.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **Bir Grafiğin Harici Veri Kaynağı Çalışma Kitabı Yolunu Al**

Bir grafiğin hangi çalışma kitabına bağlı olduğunu belirlemek için, grafiğin harici bir veri kaynağı kullanıp kullanmadığını kontrol edin ve çalışma kitabı yolunu alın.

Bu örnek, harici bir çalışma kitabına bağlanmış bir grafiğin bulunduğu bir sunumun ilk slaytındaki ilk şekli inceler. Eğer grafik harici bir çalışma kitabına bağlanmışsa, [external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) değerini konsola yazdırır. Ardından sunumun bir kopyasını kaydeder.

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

Harici çalışma kitaplarındaki verileri, iç çalışma kitaplarındaki değişiklikleri yapar gibi düzenleyebilirsiniz. Harici bir çalışma kitabı yüklenemediğinde bir istisna atılır.

Bu örnek, ilk slayttaki ilk şekil olarak bir grafik ve erişilebilir bir harici çalışma kitabı bağlanmış bir grafik kullanır. İlk serinin ilk veri noktasının hücreye dayalı değerini 100 olarak ayarlar ve güncellenmiş sunumu kaydeder. Hücre değerlerini düzenlemek, bağlantılı harici XLSX dosyasını güncelleyebilir; bu nedenle orijinali korumak istiyorsanız bir kopya kullanın.

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

Bir grafik, eksik veya mevcut olmayan bir harici çalışma kitabı kullanıyorsa, Aspose.Slides, sunumda önbelleğe alınan veriden grafik çalışma kitabını yeniden oluşturabilir. [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) oluşturun, onun [spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/) özelliğini yapılandırın ve [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) özelliğini `True` olarak ayarlayın; ardından sunumu açın.

Aşağıdaki Python örneği, ilk slayttaki ilk şekil olarak bir grafik ve kullanılamayan bir harici çalışma kitabına referans veren bir grafik için çalışma kitabı verilerini kurtarır. Kurtarılan verilere [Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/) ve [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) aracılığıyla erişir:

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

Harici çalışma kitabı kullanılamaz ve kurtarma devre dışı bırakılmışsa, Aspose.Slides bir istisna fırlatır. Ön bellekli grafik verisinin kabul edilebilir bir geri dönüş mekanizması olduğu durumlarda yalnızca kurtarmayı etkinleştirin; çünkü önbellek, sunum son güncellendiğinden beri harici çalışma kitabında yapılan değişiklikleri içermeyebilir.

## **SSS**

**Belirli bir grafiğin harici mi yoksa gömülü bir çalışma kitabına mı bağlı olduğunu belirleyebilir miyim?**

Evet. Bir grafiğin bir [veri kaynağı türü](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) ve bir [harici çalışma kitabı yolu](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) vardır; kaynak harici bir çalışma kitabıysa, tam yolu okuyarak dış bir dosyanın kullanıldığını teyit edebilirsiniz.

**Harici çalışma kitapları için göreceli yollar destekleniyor mu ve nasıl depolanıyor?**

Evet. Göreceli bir yol belirtirseniz otomatik olarak mutlak yola dönüştürülür. Sunum, mutlak yolu PPTX dosyasında saklar; bu nedenle çalışma kitabını taşımak bağlantıyı güncellemenizi gerektirebilir.

**Ağ kaynakları/paylaşımları üzerindeki çalışma kitaplarını kullanabilir miyim?**

Evet, bu tür çalışma kitapları harici veri kaynağı olarak kullanılabilir. Ancak, Aspose.Slides doğrudan uzak çalışma kitaplarını düzenlemeyi desteklemez; sadece bir kaynak olarak kullanılabilirler.

**Aspose.Slides, sunumu kaydederken harici XLSX dosyasını üzerine yazar mı?**

Sunum, [harici dosyaya bir bağlantı](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) saklar. Hücreye dayalı grafik verilerini düzenlemek aynı zamanda bağlanan yerel XLSX dosyasını da güncelleyebilir. Orijinal dosyanın değişmemesi gerekiyorsa çalışma kitabının bir kopyasını kullanın.

**Harici dosya şifre korumalıysa ne yapmalıyım?**

Aspose.Slides, bağlama sırasında şifre kabul etmez. Yaygın bir yaklaşım, şifreyi önceden kaldırmak ya da bir şifrelenmemiş kopya hazırlamaktır (örneğin, [Aspose.Cells](https://reference.aspose.com/cells/python-net/) kullanarak) ve bu kopyaya bağlamaktır.

**Birden fazla grafik aynı harici çalışma kitabına başvurabilir mi?**

Evet. Her grafik kendi bağlantısını saklar. Hepsi aynı dosyaya işaret ediyorsa, o dosyada yapılan güncellemeler bir sonraki veri yüklemesinde her grafiğe yansır.