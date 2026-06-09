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
- dış çalışma kitabı
- dış veri
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python'ı .NET aracılığıyla keşfedin: PowerPoint ve OpenDocument formatlarında grafik çalışma kitaplarını zahmetsizce yöneterek sunum verilerinizi sadeleştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'de grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Çalışma kitabı akışları üzerinden grafik verilerini okuma ve yazma, çalışma kitabı hücrelerini grafik veri etiketleri olarak kullanma, çalışma sayfası koleksiyonlarına erişme ve grafik değerleri için veri kaynağı türünü belirtme konularını gösterir.

Ayrıca, dış çalışma kitaplarını grafik veri kaynakları olarak kullanma konusunu da kapsar. Örnekler, bir dış çalışma kitabı oluşturma ve atama, bir grafikle ilişkili dış çalışma kitabının yolunu alma ve çalışma kitabı mevcut olduğunda grafik verilerini düzenleme işlemlerini gösterir.

## **Çalışma Kitabından Grafik Verilerini Okuma ve Yazma**

Aspose.Slides, grafik verileri çalışma kitaplarını (Aspose.Cells ile düzenlenen grafik verilerini içeren) okuma ve yazma yöntemleri sağlar. **Not:** Grafik verileri aynı şekilde düzenlenmiş olmalı veya kaynağa benzer bir yapıya sahip olmalıdır.

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

## **Bir Çalışma Kitabı Hücresini Grafik Veri Etiketi Olarak Ayarlama**

Bazen grafik etiketlerinin, alttaki veri çalışma kitabındaki hücrelerden doğrudan gelmesi gerekir. Aspose.Slides, veri etiketlerini belirli çalışma kitabı hücrelerine bağlamanıza olanak tanır, böylece etiket metni her zaman hücrenin değerini yansıtır. Aşağıdaki örnek, hücreden gelen değer etiketlerini etkinleştirmeyi ve seçili etiketleri grafiğin çalışma kitabındaki özelleştirilmiş hücrelere yönlendirmeyi gösterir.

1. Bir [Presentation](https://docs.aspose.com/slides/tr/python-net/api-reference/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Dizine göre slayta bir referans alın.
1. Örnek veriyle bir balon grafik ekleyin.
1. Grafik serisine erişin.
1. Bir çalışma kitabı hücresini veri etiketi olarak kullanın.
1. Sunumu kaydedin.

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

Aşağıdaki Python kodu, bir veri kaynağı türünün nasıl belirleneceğini gösterir:

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

## **Desteklenmeyen Gömülü Çalışma Kitabı Formatlarını Algılama**

Aspose.Slides, bazı grafiklerde gömülebilen Excel ikili çalışma kitabı (.xlsb) formatını desteklemez. Desteklenmeyen formatları algılamak ve bu grafiklerden geçmek için [ChartData](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/) üzerindeki `embedded_workbook_type` özelliğini [WorkbookType](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/workbooktype/) sayımıyla birlikte kullanabilirsiniz.

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

        # Burada grafik çalışma kitabı verilerini okuyabilir veya değiştirebilirsiniz.
```

## **Dış Çalışma Kitapları**

Aspose.Slides, dış çalışma kitaplarını grafikler için veri kaynağı olarak kullanmayı destekler.

### **Dış Çalışma Kitaplarını Ayarlama**

[ChartData.set_external_workbook](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/set_external_workbook/) yöntemini kullanarak, bir dış çalışma kitabını grafik için veri kaynağı olarak atayabilirsiniz. Bu yöntem, dış çalışma kitabının konumu taşındıysa yolu da güncelleyebilir.

Uzak konumlarda veya kaynaklarda depolanan çalışma kitaplarındaki verileri düzenleyemesiniz de, bu çalışma kitaplarını hâlâ dış veri kaynağı olarak kullanabilirsiniz. Bir dış çalışma kitabı için göreli bir yol sağlarsanız, otomatik olarak tam bir yola dönüştürülür.

Aşağıdaki Python kodu, bir dış çalışma kitabının nasıl ayarlanacağını gösterir:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chart.chart_data.set_external_workbook("external_workbook.xlsx")

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

[set_external_workbook](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/set_external_workbook/) yönteminin `update_chart_data` parametresi, Excel çalışma kitabının yüklenip yüklenmeyeceğini belirtir.

- `update_chart_data` `False` olarak ayarlandığında, yalnızca çalışma kitabı yolu güncellenir; grafik verileri hedef kitapttan yüklenmez veya yenilenmez. Bu ayarı, hedef çalışma kitabı mevcut değilse veya erişilemezse kullanın.
- `update_chart_data` `True` olarak ayarlandığında, grafik verileri hedef çalışma kitabından yüklenir ve güncellenir.

### **Dış Çalışma Kitapları Oluşturma**

[read_workbook_stream](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) ve [set_external_workbook](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/set_external_workbook/) yöntemlerini kullanarak, ya sıfırdan bir dış çalışma kitabı oluşturabilir ya da iç bir çalışma kitabını dış birine dönüştürebilirsiniz.

Bu Python kodu, dış çalışma kitabı oluşturma sürecini gösterir:

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

### **Bir Grafik İçin Dış Veri Kaynağı Çalışma Kitabı Yolunu Almak**

Bazen bir grafiğin verileri, sunumun gömülü verileri yerine dış bir Excel çalışma kitabına bağlanır. Aspose.Slides ile grafiğin veri kaynağını inceleyebilir ve eğer dış bir çalışma kitabıysa tam yolunu okuyabilirsiniz.

1. Bir [Presentation](https://docs.aspose.com/slides/tr/python-net/api-reference/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksine göre slayta bir referans alın.
1. Grafik şekline bir referans alın.
1. Grafiğin veri kaynağını temsil eden kaynağı ([ChartDataSourceType](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdatasourcetype/)) edinin.
1. Kaynak türünün dış çalışma kitabı veri kaynağı türüyle eşleşip eşleşmediğini kontrol edin.

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

Dış çalışma kitaplarındaki verileri, iç çalışma kitaplarındaki gibi düzenleyebilirsiniz. Bir dış çalışma kitabı yüklenemezse, bir istisna fırlatılır.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Belirli bir grafiğin dış bir çalışma kitabına mı yoksa gömülü bir çalışma kitabına mı bağlandığını belirleyebilir miyim?**

Evet. Bir grafiğin bir [veri kaynağı türü](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/data_source_type/) ve bir [dış çalışma kitabı yolu](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/external_workbook_path/) vardır; kaynak dış bir çalışma kitabıysa, dış bir dosyanın kullanıldığından emin olmak için tam yolu okuyabilirsiniz.

**Dış çalışma kitapları için göreli yollar destekleniyor mu ve nasıl saklanıyor?**

Evet. Göreli bir yol belirtirseniz, otomatik olarak mutlak bir yola dönüştürülür. Bu, projenin taşınabilirliği için uygundur; ancak, sunumun PPTX dosyasında mutlak yolu saklayacağını unutmayın.

**Ağ kaynakları/paylaşımları üzerindeki çalışma kitaplarını kullanabilir miyim?**

Evet, bu tür çalışma kitapları dış veri kaynağı olarak kullanılabilir. Ancak, uzak çalışma kitaplarını doğrudan Aspose.Slides'tan düzenlemek desteklenmez; yalnızca bir kaynak olarak kullanılabilirler.

**Aspose.Slides sunumu kaydederken dış XLSX dosyasını üzerine yazar mı?**

Hayır. Sunum, dış dosyaya bir [bağlantı](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/external_workbook_path/) saklar ve verileri okurken bunu kullanır. Sunum kaydedildiğinde dış dosya kendisi değiştirilmez.

**Dış dosya şifre korumalıysa ne yapmalıyım?**

Aspose.Slides bağlantı sırasında şifre kabul etmez. Yaygın bir yaklaşım, önceden korumayı kaldırmak veya şifresi çözülmüş bir kopya hazırlamaktır (örneğin, [Aspose.Cells](/cells/python-net/) kullanarak) ve bu kopyaya bağlamaktır.

**Birden fazla grafik aynı dış çalışma kitabına referans verebilir mi?**

Evet. Her grafik kendi bağlantısını saklar. Hepsi aynı dosyaya işaret ediyorsa, dosya güncellendiğinde veri bir sonraki yüklendiğinde her grafikte de yansır.