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
description: "Aspose.Slides for Python via .NET'i keşfedin: PowerPoint ve OpenDocument formatlarında grafik çalışma kitaplarını zahmetsizce yönetin ve sunum verilerinizi düzene koyun."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Çalışma kitabı akışları aracılığıyla grafik verilerini okuma ve yazma, çalışma kitabı hücrelerini grafik veri etiketleri olarak kullanma, çalışma sayfası koleksiyonlarına erişme ve grafik değerleri için veri kaynağı türünü belirtme konularını gösterir.

Ayrıca harici çalışma kitaplarını grafik veri kaynakları olarak kullanmayı da kapsar. Örnekler, harici bir çalışma kitabı oluşturup atamayı, bir grafikle ilişkili harici çalışma kitabının yolunu almayı ve çalışma kitabı mevcut olduğunda grafik verilerini düzenlemeyi gösterir.

## **Çalışma Kitabından Grafik Verilerini Oku ve Yaz**

Aspose.Slides, grafik verileri çalışma kitaplarını (Aspose.Cells ile düzenlenen grafik verilerini içeren) okuma ve yazma yöntemleri sağlar. **Not:** Grafik verileri aynı şekilde düzenlenmiş olmalı veya kaynağa benzer bir yapıya sahip olmalıdır.

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

### **Çalışma Kitabı Değiştirildikten Sonra Grafik Düzenini Doğrula**

Gömülü bir çalışma kitabını değiştirilmiş bir sürümle değiştirdiğinizde, grafik orijinal serileri ve kategori koleksiyonlarını korur. Bu uyuşmazlık, [IChart.validate_chart_layout](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/ichart/validate_chart_layout/) metodunun indeks dışı hata vermesine neden olabilir. Güncellenmiş çalışma kitabını grafiğe geri yazmadan önce mevcut serileri ve kategorileri temizleyin.

```python
# Çalışma kitabı akışı (ör. Aspose.Cells kullanarak) değiştirildikten sonra
updated_workbook = chart_data.read_workbook_stream()

# Mevcut veri referanslarını temizle.
chart_data.series.clear()
chart_data.categories.clear()

updated_workbook.seek(0)
chart_data.write_workbook_stream(updated_workbook)

chart.validate_chart_layout()
```

Koleksiyonların temizlenmesi, grafik veri yapısının yeni çalışma kitabıyla tutarlı olmasını sağlar ve `validate_chart_layout` hatasız bir şekilde tamamlanabilir.

## **Bir Çalışma Kitabı Hücresini Grafik Veri Etiketi Olarak Ayarla**

Bazen grafik etiketlerinin, temel veri çalışma kitabındaki hücrelerden doğrudan gelmesi gerekir. Aspose.Slides, veri etiketlerini belirli çalışma kitabı hücrelerine bağlamanıza olanak tanır; böylece etiket metni her zaman hücrenin değerini yansıtır. Aşağıdaki örnek, hücre‑tanımlı etiketleri etkinleştirmeyi ve seçilen etiketlerin grafik çalışma kitabındaki özelleştirilmiş hücrelere işaret etmesini gösterir.

1. [Presentation](https://docs.aspose.com/slides/tr/python-net/api-reference/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Dizine göre slayta referans alın.  
3. Örnek veriyle bir balon grafik ekleyin.  
4. Grafik serisine erişin.  
5. Bir çalışma kitabı hücresini veri etiketi olarak kullanın.  
6. Sunumu kaydedin.

Aşağıdaki Python kodu bir çalışma kitabı hücresini grafik veri etiketi olarak ayarlamayı gösterir:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluştur.
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

Aşağıdaki Python kodu veri kaynağı türünün nasıl belirleneceğini gösterir:

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

## **Desteklenmeyen Gömülü Çalışma Kitabı Biçimlerini Algıla**

Aspose.Slides, bazı grafiklerde gömülebilen Excel ikili çalışma kitabı (.xlsb) biçimini desteklemez. Desteklenmeyen biçimleri algılamak ve bu grafikleri atlamak için [ChartData](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/) üzerindeki `embedded_workbook_type` özelliği ile [WorkbookType](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/workbooktype/) sayımını birlikte kullanabilirsiniz.

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
            # Gömülü çalışma kitabı .xlsb formatında ve bu format desteklenmiyor.
            continue

        # Burada grafik çalışma kitabı verisini okuyabilir veya değiştirebilirsiniz.
```

## **Harici Çalışma Kitapları**

Aspose.Slides, harici çalışma kitaplarını grafikler için veri kaynağı olarak kullanmayı destekler.

### **Harici Çalışma Kitaplarını Ayarla**

[ChartData.set_external_workbook](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/set_external_workbook/) metodunu kullanarak, bir grafik için veri kaynağı olarak harici bir çalışma kitabı atayabilirsiniz. Bu yöntem, harici çalışma kitabının konumu taşındıysa yolu da güncelleyebilir.

Uzak konumlardaki veya kaynaklardaki çalışma kitaplarındaki verileri düzenleyemezsiniz, ancak bu kitapları harici veri kaynakları olarak kullanabilirsiniz. Harici bir çalışma kitabı için göreli bir yol sağlarsanız, otomatik olarak tam yola dönüştürülür.

Aşağıdaki Python kodu bir harici çalışma kitabının nasıl ayarlanacağını gösterir:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    # False değerini geçirerek yalnızca yolun kaydedilmesini sağla: hedef çalışma kitabının henüz var olması gerekmez.
    chart.chart_data.set_external_workbook("external_workbook.xlsx", False)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

[set_external_workbook](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/set_external_workbook/) metodundaki `update_chart_data` parametresi, Excel çalışma kitabının yüklenip yüklenmeyeceğini belirtir.

- `update_chart_data` **False** olarak ayarlandığında, yalnızca çalışma kitabı yolu güncellenir; grafik verileri hedef çalışma kitabından yüklenmez veya yenilenmez. Hedef çalışma kitabı mevcut değilse veya erişilemezse bu ayarı kullanın.  
- `update_chart_data` **True** (varsayılan) olduğunda, grafik verileri hedef çalışma kitabından yüklenir ve güncellenir. O çalışma kitap açılamazsa, “External workbook is not available” mesajlı bir istisna fırlatılır.

### **Harici Çalışma Kitapları Oluştur**

[read_workbook_stream](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) ve [set_external_workbook](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/set_external_workbook/) metodlarını kullanarak, ya sıfırdan bir harici çalışma kitabı oluşturabilir ya da içsel bir çalışma kitabını hariciye dönüştürebilirsiniz.

Bu Python kodu harici çalışma kitabı oluşturma sürecini gösterir:

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

Bazen bir grafiğin verileri, sunumun gömülü verileri yerine harici bir Excel çalışma kitabına bağlanır. Aspose.Slides ile grafiğin veri kaynağını inceleyebilir ve eğer harici bir çalışma kitabıysa tam yolunu okuyabilirsiniz.

1. [Presentation](https://docs.aspose.com/slides/tr/python-net/api-reference/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Dizine göre slayta referans alın.  
3. Grafik şekline referans alın.  
4. Grafiğin veri kaynağını temsil eden [ChartDataSourceType](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdatasourcetype/) öğesini elde edin.  
5. Kaynak türünün harici çalışma kitabı veri kaynağı türüyle eşleşip eşleşmediğini kontrol edin.

Aşağıdaki Python kodu işlemi gösterir:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart_with_external_workbook.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    source_type = chart.chart_data.data_source_type
    if source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
        print(chart.chart_data.external_workbook_path)
```

### **Grafik Verilerini Düzenle**

Harici çalışma kitaplarındaki verileri, içsel çalışma kitaplarındaki gibi düzenleyebilirsiniz. Harici bir çalışma kitabı yüklenemezse, bir istisna fırlatılır.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Grafik Önbelleğinden Bir Çalışma Kitabını Kurtar**

Bir grafik, eksik veya kullanılamayan bir harici çalışma kitabı kullanıyorsa, Aspose.Slides sunumda önbelleğe alınan verilerden grafik çalışma kitabını yeniden oluşturabilir. Öncelikle [LoadOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides/loadoptions/) oluşturun, ardından sunumu açmadan önce `LoadOptions.spreadsheet_options` aracılığıyla [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/tr/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) özelliğini etkinleştirin.

Aşağıdaki Python örneği, harici bir çalışma kitabına referans veren bir sunumu açar ve [Chart.chart_data](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chart/chart_data/) ve [ChartData.chart_data_workbook](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) aracılığıyla elde edilen kurtarılmış veriye erişir:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # Kurtarılmış çalışma kitabı verisini burada okuyabilir veya değiştirebilirsiniz.
```

Harici çalışma kitabı kullanılamaz ve kurtarma devre dışı bırakılmışsa, Aspose.Slides bir istisna fırlatır. Kurtarmayı yalnızca önbellekteki grafik verilerinin kabul edilebilir bir geri dönüş olduğu durumlarda etkinleştirin; çünkü önbellek, sunum son güncellendiğinden beri harici çalışma kitabına yapılan değişiklikleri içermeyebilir.

## **SSS**

**Belirli bir grafiğin harici mi yoksa gömülü bir çalışma kitabına mı bağlı olduğunu belirleyebilir miyim?**

Evet. Bir grafiğin [data source type](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/data_source_type/) ve bir [path to an external workbook](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/external_workbook_path/) vardır; kaynak harici bir çalışma kitabıysa, tam yolu okuyarak bir harici dosyanın kullanıldığını doğrulayabilirsiniz.

**Harici çalışma kitapları için göreli yollar destekleniyor mu, nasıl depolanıyor?**

Evet. Göreli bir yol belirttiğinizde otomatik olarak mutlak yola dönüştürülür. Bu, proje taşınabilirliği açısından kullanışlıdır; ancak sunum, mutlak yolu PPTX dosyasında saklar.

**Ağ kaynaklarındaki/paylaşımlardaki çalışma kitaplarını kullanabilir miyim?**

Evet, bu tür çalışma kitapları harici veri kaynağı olarak kullanılabilir. Ancak Aspose.Slides üzerinden uzak çalışma kitaplarını doğrudan düzenlemek desteklenmez—yalnızca kaynak olarak kullanılabilirler.

**Aspose.Slides, sunumu kaydederken harici XLSX dosyasını üzerine yazar mı?**

Yalnızca grafik verilerini düzenlediyseniz yazar. Sunum, [link to the external file](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/external_workbook_path/) tutar ve veri okuma için bunu kullanır; bu yüzden bir sunumu açıp kaydetmek çalışma kitabını dokunulmaz bırakır. Ancak grafik verileri üzerinden yaptığınız değişiklikler ([Edit Chart Data](#edit-chart-data) bölümüne bakın) sunum kaydedildiğinde harici çalışma kitabına geri yazılır—orijinalin değişmemesi gerekiyorsa bir kopya üzerinde çalışın.

**Harici dosya şifre korumalıysa ne yapmalıyım?**

Aspose.Slides, bağlantı sırasında şifre kabul etmez. Yaygın bir yaklaşım, önce korumayı kaldırmak veya şifresiz bir kopya hazırlamaktır (örneğin [Aspose.Cells](/cells/python-net/) kullanarak) ve bu kopyaya bağlanmaktır.

**Birden fazla grafik aynı harici çalışma kitabına referans verebilir mi?**

Evet. Her grafik kendi bağlantısını saklar. Hepsi aynı dosyaya işaret ediyorsa, dosyada yapılan güncellemeler bir sonraki veri yüklemesinde her grafikte yansıtılır.