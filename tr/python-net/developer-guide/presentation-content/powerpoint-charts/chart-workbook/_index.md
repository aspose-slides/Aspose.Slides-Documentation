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
description: "Aspose.Slides for Python'i .NET üzerinden keşfedin: PowerPoint ve OpenDocument formatlarında grafik çalışma kitaplarını zahmetsizce yöneterek sunum verilerinizi düzenleyin."
---
## **Genel Bakış**

Bu makale Aspose.Slides içinde grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Çalışma kitabı akışları aracılığıyla grafik verilerini nasıl okuyup yazacağınızı, çalışma kitabı hücrelerini grafik veri etiketleri olarak nasıl kullanacağınızı, çalışma sayfası koleksiyonlarına nasıl erişeceğinizi ve grafik değerleri için veri kaynağı türünü nasıl belirteceğinizi gösterir.

Ayrıca harici çalışma kitaplarının grafik veri kaynakları olarak kullanılmasını da kapsar. Örnekler, harici bir çalışma kitabı oluşturup atamayı, bir grafikle ilişkilendirilmiş harici çalışma kitabının yolunu almayı ve çalışma kitabı mevcut olduğunda grafik verisini düzenlemeyi gösterir.

## **Bir Çalışma Kitabından Grafik Verisini Oku ve Yaz**

Aspose.Slides, grafik veri çalışma kitaplarını (Aspose.Cells ile düzenlenen grafik verilerini içerir) okuma ve yazma yöntemleri sağlar. **Not:** Grafik verileri aynı şekilde düzenlenmiş ya da kaynağa benzer bir yapıya sahip olmalıdır.

Aşağıdaki Python kodu örnek bir işlemi gösterir:

```py
import aspose.slides as slides

with slides.Presentation("chart.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]

    data_stream = chart.chart_data.read_workbook_stream()

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    data_stream.seek(0)
    chart.chart_data.write_workbook_stream(data_stream)
```

## **Bir WorkBook Hücresini Grafik Veri Etiketi Olarak Ayarla**

Bazen grafik etiketlerinin, temel veri çalışma kitabındaki hücrelerden doğrudan gelmesi gerekir. Aspose.Slides, veri etiketlerini belirli çalışma kitabı hücrelerine bağlamanızı sağlar; böylece etiket metni her zaman hücrenin değerini yansıtır. Aşağıdaki örnek, hücre‑değerinden etiketleri etkinleştirmeyi ve seçilen etiketleri grafiğin çalışma kitabındaki özel hücrelere işaret etmeyi gösterir.

1. [Presentation](https://docs.aspose.com/slides/tr/python-net/api-reference/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Slayta indeks ile bir referans alın.
1. Örnek verilerle bir balon grafiği ekleyin.
1. Grafik serisine erişin.
1. Bir çalışma kitabı hücresini veri etiketi olarak kullanın.
1. Sunumu kaydedin.

Aşağıdaki Python kodu, bir çalışma kitabı hücresini grafik veri etiketi olarak ayarlamayı gösterir:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluşturun.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)

    series = chart.chart_data.series[0]

    series.labels.default_data_label_format.show_label_value_from_cell = True

    workbook = chart.chart_data.chart_data_workbook

    series.labels[0].value_from_cell = workbook.get_cell(0, "A10", "Label 0")
    series.labels[1].value_from_cell = workbook.get_cell(0, "A11", "Label 1")
    series.labels[2].value_from_cell = workbook.get_cell(0, "A12", "Label 2")

    presentation.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **Çalışma Sayfalarını Yönet**

Aşağıdaki Python kodu, `worksheets` özelliğini kullanarak çalışma sayfası koleksiyonuna nasıl erişileceğini gösterir:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)

    workbook = chart.chart_data.chart_data_workbook
    for i in range(len(workbook.worksheets)):
        print(workbook.worksheets[i].name)
```

## **Veri Kaynağı Türünü Belirle**

Aşağıdaki Python kodu, bir veri kaynağı türünün nasıl belirtileceğini gösterir:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)

    series_name = chart.chart_data.series[0].name
    series_name.data_source_type = slides.charts.DataSourceType.STRING_LITERALS
    series_name.data = "LiteralString"

    series_name = chart.chart_data.series[1].name
    series_name.data = chart.chart_data.chart_data_workbook.get_cell(0, "B1", "NewCell")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Desteklenmeyen Gömülü Çalışma Kitabı Formatlarını Algıla**

Aspose.Slides, bazı grafiklerde gömülebilen Excel ikili çalışma kitabı (.xlsb) formatını desteklemez. Desteklenmeyen formatları algılamak ve bu grafikleri atlamak için [ChartData](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/) üzerindeki `embedded_workbook_type` özelliğini, [WorkbookType](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/workbooktype/) diziniyle birlikte kullanabilirsiniz.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, charts.Chart):
            continue

        chart = shape
        chart_data = chart.chart_data

        if (chart_data.data_source_type == charts.ChartDataSourceType.INTERNAL_WORKBOOK and
                chart_data.embedded_workbook_type == charts.WorkbookType.WORKBOOK_BINARY_MACRO):
                # Gömülü çalışma kitabı .xlsb formatında, bu format desteklenmiyor.
                continue

        # Grafik çalışma kitabı verisini burada okuyun veya değiştirin.
```

## **Harici Çalışma Kitapları**

Aspose.Slides, harici çalışma kitaplarını grafikler için veri kaynağı olarak kullanmayı destekler.

### **Harici Çalışma Kitaplarını Ayarla**

[ChartData.set_external_workbook](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/set_external_workbook/) yöntemini kullanarak bir grafiğe veri kaynağı olarak harici bir çalışma kitabı atayabilirsiniz. Bu yöntem, çalışma kitabı taşınmışsa yolunu da güncelleyebilir.

Uzak konumlardaki veya kaynaklardaki çalışma kitaplarındaki verileri düzenleyemesiniz de, bu kitapları harici veri kaynakları olarak kullanabilirsiniz. Harici bir çalışma kitabı için göreceli bir yol sağlarsanız, otomatik olarak tam yola dönüştürülür.

Aşağıdaki Python kodu, harici bir çalışma kitabı ayarlamayı gösterir:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chart.chart_data.set_external_workbook("external_workbook.xlsx")

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

`update_chart_data` parametresi, [set_external_workbook](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/set_external_workbook/) yönteminde Excel çalışma kitabının yükleneceğini belirler.

- `update_chart_data` `False` olarak ayarlandığında yalnızca çalışma kitabı yolu güncellenir; grafik verileri hedef çalışma kitabından yüklenmez veya yenilenmez. Hedef çalışma kitabı mevcut değilse ya da kullanılamıyorsa bu ayarı kullanın.
- `update_chart_data` `True` olarak ayarlandığında grafik verileri hedef çalışma kitabından yüklenir ve güncellenir.

### **Harici Çalışma Kitapları Oluştur**

[read_workbook_stream](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) ve [set_external_workbook](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/set_external_workbook/) yöntemlerini kullanarak ya tamamen yeni bir harici çalışma kitabı oluşturabilir ya da dahili bir çalışma kitabını harici bir çalışma kitabına dönüştürebilirsiniz.

Bu Python kodu, harici çalışma kitabı oluşturma sürecini gösterir:

```python
import pathlib
import aspose.slides as slides
import aspose.slides.charts as charts

workbook_path = "external_workbook.xlsx"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600)

    workbook_data = chart.chart_data.read_workbook_stream().read()

    with open(workbook_path, "wb") as file_stream:
        file_stream.write(workbook_data)

    full_path = str(pathlib.Path(workbook_path).resolve())
    chart.chart_data.set_external_workbook(full_path)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

### **Bir Grafik İçin Harici Veri Kaynağı Çalışma Kitabı Yolunu Al**

Bazen bir grafiğin verileri, sunumun gömülü verileri yerine harici bir Excel çalışma kitabına bağlanır. Aspose.Slides ile grafiğin veri kaynağını inceleyebilir ve eğer harici bir çalışma kitabı ise tam çalışma kitabı yolunu okuyabilirsiniz.

1. [Presentation](https://docs.aspose.com/slides/tr/python-net/api-reference/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Slayta indeks ile bir referans alın.
1. Grafik şekline bir referans alın.
1. Grafiğin veri kaynağını temsil eden ([ChartDataSourceType](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdatasourcetype/)) kaynağı elde edin.
1. Kaynak türünün harici çalışma kitabı veri kaynağı türüyle eşleşip eşleşmediğini kontrol edin.

Aşağıdaki Python kodu bu işlemi gösterir:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart_with_external_workbook.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    source_type = chart.chart_data.data_source_type
    if source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
        print(chart.chart_data.external_workbook_path)
```

### **Grafik Verisini Düzenle**

Harici çalışma kitaplarındaki verileri, dahili çalışma kitaplarındaki verileri düzenlediğiniz gibi düzenleyebilirsiniz. Harici bir çalışma kitabı yüklenemezse bir istisna fırlatılır.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Grafik Önbelleğinden Bir Çalışma Kitabı Geri Yükle**

Bir grafik, eksik ya da kullanılamayan bir harici çalışma kitabı kullanıyorsa, Aspose.Slides sunumda önbelleğe alınmış verilerden grafik çalışma kitabını yeniden oluşturabilir. [LoadOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides/loadoptions/) oluşturun, ardından sunumu açmadan önce [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/tr/python-net/aspose.slides/loadoptions/spreadsheet_options/) aracılığıyla [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/tr/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) seçeneğini etkinleştirin.

Aşağıdaki Python örneği, grafikleri kullanılamayan bir harici çalışma kitabına referans veren bir sunumu açar ve geri yüklenmiş verilere [Chart.chart_data](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chart/chart_data/) ve [ChartData.chart_data_workbook](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) aracılığıyla erişir:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # Geri yüklenen çalışma kitabı verisini burada okuyun veya değiştirin.
```

Harici çalışma kitabı kullanılamıyorsa ve geri yükleme devre dışı bırakılmışsa, Aspose.Slides bir istisna fırlatır. Geri yüklemeyi yalnızca önbellekteki grafik verilerini kullanmanın kabul edilebilir bir alternatif olduğu durumlarda etkinleştirin; çünkü önbellek, sunum son güncellendiğinden sonra harici çalışma kitabında yapılan değişiklikleri içermeyebilir.

## **SSS**

**Belirli bir grafiğin harici bir çalışma kitabına mı yoksa gömülü bir çalışma kitabına mı bağlandığını belirleyebilir miyim?**

Evet. Bir grafiğin bir [data source type](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/data_source_type/) ve bir [path to an external workbook](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/external_workbook_path/) vardır; kaynak harici bir çalışma kitabıysa tam yolu okuyarak dış bir dosyanın kullanıldığını teyit edebilirsiniz.

**Harici çalışma kitapları için göreceli yollar destekleniyor mu ve nasıl depolanıyor?**

Evet. Göreceli bir yol belirttiğinizde otomatik olarak mutlak yola dönüştürülür. Bu, proje taşınabilirliği için kullanışlıdır; ancak sunum, mutlak yolu PPTX dosyasında saklayacaktır.

**Ağ kaynakları/paylaşımları üzerindeki çalışma kitaplarını kullanabilir miyim?**

Evet, bu tür çalışma kitapları harici veri kaynağı olarak kullanılabilir. Ancak, uzak çalışma kitaplarını doğrudan Aspose.Slides'ten düzenlemek desteklenmez; yalnızca kaynak olarak kullanılabilirler.

**Aspose.Slides, sunumu kaydederken harici XLSX dosyasını üzerine yazar mı?**

Hayır. Sunum, [link to the external file](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/external_workbook_path/) saklar ve verileri okurken bu bağlantıyı kullanır. Sunum kaydedildiğinde harici dosya değiştirilmez.

**Harici dosya şifre korumalıysa ne yapmalıyım?**

Aspose.Slides bağlanırken şifre kabul etmez. Yaygın bir yaklaşım, şifreyi önceden kaldırmak veya bir şifresiz kopya (örneğin [Aspose.Cells](/cells/python-net/) kullanarak) hazırlayıp ona bağlanmaktır.

**Birden fazla grafik aynı harici çalışma kitabına referans gösterebilir mi?**

Evet. Her grafik kendi bağlantısını saklar. Hepsi aynı dosyaya işaret ediyorsa, dosyada yapılan güncellemeler bir sonraki veri yüklemesinde her grafiğe yansır.