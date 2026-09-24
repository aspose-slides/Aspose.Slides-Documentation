---
title: Python ile Sunumlarda Grafik Çalışma Kitaplarını Yönetin
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
description: "Aspose.Slides for Python via .NET'i keşfedin: PowerPoint ve OpenDocument formatlarındaki grafik çalışma kitaplarını zahmetsizce yönetin ve sunum verilerinizi kolaylaştırın."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'te grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Çalışma kitabı akışları aracılığıyla grafik verilerini okuma ve yazma, çalışma kitabı hücrelerini grafik veri etiketi olarak kullanma, çalışma sayfası koleksiyonlarına erişme ve grafik değerleri için veri kaynağı türünü belirtme konularını gösterir.

Ayrıca, harici çalışma kitaplarını grafik veri kaynağı olarak kullanma konusunu da kapsar. Örnekler, harici bir çalışma kitabı oluşturup atamayı, bir grafiğe bağlı harici çalışma kitabının yolunu almayı ve çalışma kitabı kullanılabilir olduğunda grafik verilerini düzenlemeyi gösterir.

Eksik verileri temsil eden çalışma kitabı hücreleri için, boş bir hücre ile sıfır arasındaki farkı ve mevcut görüntüleme modlarının çizgi grafik karşılaştırmasını görmek üzere [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/python-net/chart-series/) bölümüne bakın.

## **Bir Çalışma Kitabı'dan Grafik Verilerini Okuma ve Yazma**

Aspose.Slides, grafik verileri çalışma kitaplarını (Aspose.Cells ile düzenlenmiş grafik verilerini içeren) okuma ve yazma yöntemleri sağlar. **Not:** Grafik verileri aynı şekilde düzenlenmiş olmalı veya kaynağa benzer bir yapıya sahip olmalıdır.

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

### **Çalışma Kitabı Değiştirildikten Sonra Grafik Düzenini Doğrulama**

Yerleşik bir çalışma kitabını değiştirilmiş bir çalışma kitabıyla değiştirdiğinizde, grafik orijinal serileri ve kategori koleksiyonlarını korur. Bu uyumsuzluk, [IChart.validate_chart_layout](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/ichart/validate_chart_layout/) çağrısının indeks dışı hata vermesine neden olabilir. Güncellenmiş çalışma kitabını grafiğe geri yazmadan önce mevcut serileri ve kategorileri temizleyin.

```python
# Çalışma kitabı akışı (ör. Aspose.Cells) değiştirildikten sonra
updated_workbook = chart_data.read_workbook_stream()

# Mevcut veri referanslarını temizle.
chart_data.series.clear()
chart_data.categories.clear()

updated_workbook.seek(0)
chart_data.write_workbook_stream(updated_workbook)

chart.validate_chart_layout()
```

Koleksiyonların temizlenmesi, grafik veri yapısının yeni çalışma kitabıyla tutarlı olmasını sağlar ve `validate_chart_layout` hatasız olarak tamamlanabilir.

## **Bir Çalışma Kitabı Hücresini Grafik Veri Etiketi Olarak Ayarlama**

Bazen grafik etiketlerinin doğrudan temel veri çalışma kitabındaki hücrelerden gelmesi gerekir. Aspose.Slides, veri etiketlerini belirli çalışma kitabı hücrelerine bağlamanıza izin verir, böylece etiket metni her zaman hücrenin değerini yansıtır. Aşağıdaki örnek, hücreden değer etiketlerini etkinleştirmeyi ve seçili etiketleri grafiğin çalışma kitabındaki özel hücrelere yönlendirmeyi gösterir.

1. [Presentation](https://docs.aspose.com/slides/tr/python-net/api-reference/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. İndeksine göre slayta bir referans alın.  
1. Örnek verilerle bir balon grafiği ekleyin.  
1. Grafik serisine erişin.  
1. Bir çalışma kitabı hücresini veri etiketi olarak kullanın.  
1. Sunumu kaydedin.  

Aşağıdaki Python kodu bir çalışma kitabı hücresini grafik veri etiketi olarak ayarlamayı gösterir:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Sunum dosyasını temsil eden Presentation sınıfını örnekleyin.
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

## **Çalışma Sayfalarını Yönetme**

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

## **Veri Kaynağı Türünü Belirleme**

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

## **Desteklenmeyen Yerleşik Çalışma Kitabı Formatlarını Algılama**

Aspose.Slides, bazı grafiklerde yerleştirilebilen Excel ikili çalışma kitabı (.xlsb) formatını desteklemez. Desteklenmeyen formatları algılamak ve bu grafikleri atlamak için [ChartData](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/) üzerindeki `embedded_workbook_type` özelliğini, [WorkbookType](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/workbooktype/) enumu ile birlikte kullanabilirsiniz.

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
            # Gömülü çalışma kitabı .xlsb formatında, bu format desteklenmemektedir.
            continue

        # Burada grafik çalışma kitabı verisini okuyabilir veya değiştirebilirsiniz.
```

## **Harici Çalışma Kitapları**

Aspose.Slides, harici çalışma kitaplarını grafikler için veri kaynağı olarak kullanmayı destekler.

### **Harici Çalışma Kitaplarını Ayarlama**

[ChartData.set_external_workbook](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/set_external_workbook/) metodunu kullanarak bir harici çalışma kitabını grafiğin veri kaynağı olarak atayabilirsiniz. Bu metod, çalışma kitabı taşınmışsa yolunu da güncelleyebilir.

Uzak konumlardaki veya kaynaklardaki çalışma kitaplarındaki verileri düzenleyemesiniz de, bu çalışma kitaplarını harici veri kaynağı olarak kullanabilirsiniz. Harici bir çalışma kitabı için göreceli bir yol sağlarsanız, otomatik olarak tam yola dönüştürülür.

Aşağıdaki Python kodu, harici bir çalışma kitabının nasıl ayarlanacağını gösterir:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    # False değerini geçerek yalnızca yol saklanır: hedef çalışma kitabının henüz var olması gerekmez.
    chart.chart_data.set_external_workbook("external_workbook.xlsx", False)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

`set_external_workbook` metodunun `update_chart_data` parametresi, Excel çalışma kitabının yüklenip yüklenmeyeceğini belirler.

- `update_chart_data` `False` olarak ayarlandığında, yalnızca çalışma kitabı yolu güncellenir; grafik verisi hedef çalışma kitabından yüklenmez veya yenilenmez. Hedef çalışma kitabı mevcut değilse veya erişilemezse bu ayarı kullanın.  
- `update_chart_data` `True` (varsayılan) olduğunda, grafik verisi hedef çalışma kitabından yüklenir ve güncellenir. Bu çalışma kitabı açılamazsa, “External workbook is not available” mesajlı bir istisna yükseltilir.

### **Harici Çalışma Kitapları Oluşturma**

[read_workbook_stream](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) ve [set_external_workbook](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/set_external_workbook/) metodlarını kullanarak ya sıfırdan bir harici çalışma kitabı oluşturabilir ya da iç bir çalışma kitabını harici bir çalışmaya dönüştürebilirsiniz.

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

### **Bir Grafik İçin Harici Veri Kaynağı Çalışma Kitabı Yolunu Alma**

Bazen bir grafiğin verileri, sunumun gömülü verileri yerine harici bir Excel çalışma kitabına bağlanır. Aspose.Slides ile grafiğin veri kaynağını inceleyebilir ve eğer harici bir çalışma kitabı ise tam yolunu okuyabilirsiniz.

1. [Presentation](https://docs.aspose.com/slides/tr/python-net/api-reference/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. İndeksine göre slayta bir referans alın.  
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

### **Grafik Verilerini Düzenleme**

Harici çalışma kitaplarındaki verileri, iç çalışma kitaplarındaki verileri düzenlediğiniz gibi düzenleyebilirsiniz. Harici bir çalışma kitabı yüklenemezse bir istisna fırlatılır.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Grafik Önbelleğinden Çalışma Kitabını Kurtarma**

Bir grafik, eksik veya kullanılamayan bir harici çalışma kitabını kullanıyorsa, Aspose.Slides sunumda önbelleğe alınmış verilerden grafik çalışma kitabını yeniden oluşturabilir. [LoadOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides/loadoptions/) oluşturun, ardından sunumu açmadan önce [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/tr/python-net/aspose.slides/loadoptions/spreadsheet_options/) üzerinden [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/tr/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) özelliğini etkinleştirin.

Aşağıdaki Python örneği, grafiği kullanılabilir olmayan bir harici çalışma kitabına referans veren bir sunumu açar ve kurtarılan verilere [Chart.chart_data](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chart/chart_data/) ve [ChartData.chart_data_workbook](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) aracılığıyla erişir:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # Kurtarılan çalışma kitabı verisini burada okuyabilir veya değiştirebilirsiniz.
```

Harici çalışma kitabı kullanılabilir değilse ve kurtarma devre dışı bırakılmışsa, Aspose.Slides bir istisna yükseltir. Önbelleğe alınmış grafik verilerinin kullanılabilir bir geri dönüş olduğu durumlarda yalnızca kurtarmayı etkinleştirin; çünkü önbellek, sunum son güncellendiğinden sonra harici çalışma kitabında yapılan değişiklikleri içermeyebilir.

## **SSS**

**Belirli bir grafiğin harici bir çalışma kitabına mı yoksa gömülü bir çalışma kitabına mı bağlandığını belirleyebilir miyim?**

Evet. Bir grafiğin bir [data source type](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/data_source_type/) ve bir [path to an external workbook](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/external_workbook_path/) vardır; kaynak bir harici çalışma kitabıysa, bir harici dosyanın kullanıldığını doğrulamak için tam yolu okuyabilirsiniz.

**Harici çalışma kitapları için göreceli yollar destekleniyor mu ve nasıl depolanıyor?**

Evet. Göreceli bir yol belirttiğinizde otomatik olarak mutlak bir yola dönüştürülür. Bu, proje taşınabilirliği için kullanışlıdır; ancak sunum, mutlak yolu PPTX dosyasında saklayacaktır.

**Ağ kaynakları/paylaşım alanlarında bulunan çalışma kitaplarını kullanabilir miyim?**

Evet, bu tür çalışma kitapları harici veri kaynağı olarak kullanılabilir. Ancak, uzaktaki çalışma kitaplarını Aspose.Slides ile doğrudan düzenlemek desteklenmez—yalnızca kaynak olarak kullanılabilirler.

**Aspose.Slides, sunumu kaydederken harici XLSX dosyasını üzerine yazar mı?**

Sadece grafik verilerini düzenlediyseniz yazar. Sunum, bir [link to the external file](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/external_workbook_path/) saklar ve veri okuma için bunu kullanır; bu yüzden bir sunumu açıp kaydetmek çalışma kitabını dokunulmaz bırakır. Ancak, grafik verileri aracılığıyla (bkz. [Edit Chart Data](#edit-chart-data) bölümü) yaptığınız değişiklikler sunum kaydedildiğinde harici çalışma kitabına geri yazılır—orijinali bozulmamalıysa bir kopya üzerinde çalışın.

**Harici dosya şifre korumalıysa ne yapmalıyım?**

Aspose.Slides, bağlanırken şifre kabul etmez. Yaygın bir yaklaşım, önceden korumayı kaldırmak veya şifresiz bir kopya (örneğin [Aspose.Cells](/cells/python-net/) kullanarak) hazırlamak ve o kopyaya bağlanmaktır.

**Birden fazla grafik aynı harici çalışma kitabına referans verebilir mi?**

Evet. Her grafik kendi bağlantısını saklar. Hepsi aynı dosyaya işaret ediyorsa, dosya güncellendiğinde veri bir sonraki yüklemede her grafik için yansıtılacaktır.