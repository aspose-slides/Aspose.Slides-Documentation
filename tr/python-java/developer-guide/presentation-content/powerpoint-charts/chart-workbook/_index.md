---
title: Python üzerinden Java ile Sunumlarda Grafik Çalışma Kitaplarını Yönetme
linktitle: Grafik Çalışma Kitabı
type: docs
weight: 70
url: /tr/python-java/chart-workbook/
keywords:
- grafik çalışma kitabı
- grafik veri
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java'ı keşfedin: PowerPoint ve OpenDocument formatlarındaki grafik çalışma kitaplarını sorunsuz bir şekilde yönetin ve sunum verilerinizi düzenleyin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Çalışma kitabı akışları aracılığıyla grafik verilerini nasıl okuyup yazacağınızı, çalışma kitabı hücrelerini grafik veri etiketleri olarak nasıl kullanacağınızı, çalışma sayfası koleksiyonlarına nasıl erişeceğinizi ve grafik değerleri için veri kaynağı türünü nasıl belirteceğinizi gösterir.

Ayrıca harici çalışma kitaplarını grafik veri kaynakları olarak kullanmayı da kapsar. Örnekler, bir harici çalışma kitabı oluşturup atamanın, bir grafikle bağlantılı harici çalışma kitabının yolunu almanın ve çalışma kitabı mevcut olduğunda grafik verilerini düzenlemenin nasıl yapılacağını gösterir.

## **Bir Çalışma Kitabından Grafik Verilerini Okuma ve Yazma**

Aspose.Slides, [readWorkbookStream](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdata/#readWorkbookStream) ve [writeWorkbookStream](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdata/#writeWorkbookStream) yöntemlerini sağlar; bu yöntemler, grafik verileri çalışma kitaplarını (Aspose.Cells ile düzenlenmiş grafik verileri içeren) okumanıza ve yazmanıza olanak tanır. **Not**: grafik verileri aynı şekilde düzenlenmiş olmalı veya kaynağa benzer bir yapıya sahip olmalıdır.

Bu Python kodu bir örnek işlemi göstermektedir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()
    workbook_data = chart_data.readWorkbookStream()
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(workbook_data)
finally:
    presentation.dispose()
```

### **Çalışma Kitabı Değiştirildikten Sonra Grafik Düzenini Doğrulama**

Yerleşik bir çalışma kitabını değiştirilmiş bir çalışma kitabıyla değiştirdiğinizde, grafik orijinal seri ve kategori koleksiyonlarını korur. Bu tutarsızlık, [Chart.validateChartLayout](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chart/#validateChartLayout) metodunun bir `ArgumentOutOfRangeException` (parametre: index) atmasına neden olabilir. İstisna oluşmasını önlemek için, güncellenmiş çalışma kitabını grafiğe geri yazmadan önce mevcut serileri ve kategorileri **önceden** temizleyin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

from pathlib import Path

# Değiştirildikten sonra çalışma kitabını oku (örn., Aspose.Cells kullanarak).
updated_workbook = Path("updatedWorkbook.xlsx").read_bytes()

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()

    # Mevcut veri referanslarını temizle.
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(jpype.JArray(jpype.JByte)(updated_workbook))
    chart.validateChartLayout()
finally:
    presentation.dispose()
```

Koleksiyonları temizlemek, grafik veri yapısının yeni çalışma kitabıyla uyumlu olmasını sağlar ve böylece [validateChartLayout](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chart/#validateChartLayout) hatasız bir şekilde tamamlanır.

## **Çalışma Kitabı Hücresini Grafik Veri Etiketi Olarak Ayarlama**

1. [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Kaydırmanın referansını indeksine göre alın.  
3. Bazı veri ile bir Bubble (Balon) grafiği ekleyin.  
4. Grafik serilerine erişin.  
5. Çalışma kitabı hücresini veri etiketi olarak ayarlayın.  
6. Sunumu kaydedin.  

Bu Python kodu, bir çalışma kitabı hücresini grafik veri etiketi olarak nasıl ayarlayacağınızı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart2.pptx")
try:
    label_values = ["Label 0 cell value", "Label 1 cell value", "Label 2 cell value"]
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)
    series = chart.getChartData().getSeries()
    data_labels = series.get_Item(0).getLabels()
    data_labels.getDefaultDataLabelFormat().setShowLabelValueFromCell(True)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(3):
        label_cell = workbook.getCell(0, f"A{10 + i}", label_values[i])
        data_labels.get_Item(i).setValueFromCell(label_cell)
    presentation.save("resultchart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Çalışma Sayfalarını Yönetme**

Bu Python kodu, [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdataworkbook/#getWorksheets) metodunun bir çalışma sayfası koleksiyonuna erişmek için kullanıldığı bir işlemi göstermektedir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 500)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(workbook.getWorksheets().size()):
        print(workbook.getWorksheets().get_Item(i).getName())
finally:
    presentation.dispose()
```

## **Veri Kaynağı Türünü Belirleme**

Bu Python kodu, bir veri kaynağı için tür nasıl belirtileceğini gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, True)
    series_name = chart.getChartData().getSeries().get_Item(0).getName()
    series_name.setDataSourceType(DataSourceType.StringLiterals)
    series_name.setData("LiteralString")
    series_name = chart.getChartData().getSeries().get_Item(1).getName()
    name_cell = chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell")
    series_name.setData(name_cell)
    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Desteklenmeyen Yerleşik Çalışma Kitabı Formatlarını Tespit Etme**

Aspose.Slides, bazı grafiklerde yerleştirilebilen Excel ikili çalışma kitabı (.xlsb) formatını desteklemez. Desteklenmeyen formatları tespit etmek ve bu grafiklerden kaçınmak için [ChartData](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdata/) üzerindeki [getEmbeddedWorkbookType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) metodunu, [WorkbookType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/workbooktype/) Enumeration ile birlikte kullanabilirsiniz.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, WorkbookType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue
        chart_data = shape.getChartData()
        if chart_data.getDataSourceType() == ChartDataSourceType.InternalWorkbook and chart_data.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro:
            # Gömülü çalışma kitabı .xlsb formatında, bu format desteklenmiyor.
            continue
        # Grafik çalışma kitabı verilerini burada okuyun veya değiştirin.
finally:
    presentation.dispose()
```

### **Harici Bir Çalışma Kitabı Oluşturma**

[readWorkbookStream](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdata/#readWorkbookStream) ve [setExternalWorkbook](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdata/#setExternalWorkbook) yöntemlerini kullanarak sıfırdan bir harici çalışma kitabı oluşturabilir veya iç bir çalışma kitabını harici hale getirebilirsiniz.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    workbook_path = "externalWorkbook1.xlsx"
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600)
    workbook_data = chart.getChartData().readWorkbookStream()
    Path(workbook_path).write_bytes(bytes(workbook_data))
    chart.getChartData().setExternalWorkbook(workbook_path)
    presentation.save("externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Harici Bir Çalışma Kitabı Atama**

[setExternalWorkbook](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdata/#setExternalWorkbook) metodunu kullanarak bir harici çalışma kitabını bir grafiğin veri kaynağı olarak atayabilirsiniz. Bu yöntem, harici çalışma kitabının yolunu (eğer taşındıysa) güncellemek için de kullanılabilir.

Uzak konumlardaki veya kaynaklardaki çalışma kitaplarındaki verileri düzenleyemezsiniz, ancak bu çalışma kitaplarını hâlâ harici veri kaynağı olarak kullanabilirsiniz. Harici bir çalışma kitabı için göreceli bir yol sağlanırsa, otomatik olarak tam yola dönüştürülür.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, False)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("externalWorkbook.xlsx")
    workbook = chart_data.getChartDataWorkbook()
    series_name_cell = workbook.getCell(0, "B1")
    series = chart_data.getSeries().add(series_name_cell, ChartType.Pie)
    for row in range(2, 5):
        value_cell = workbook.getCell(0, f"B{row}")
        series.getDataPoints().addDataPointForPieSeries(value_cell)
    for row in range(2, 5):
        category_cell = workbook.getCell(0, f"A{row}")
        chart_data.getCategories().add(category_cell)
    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[setExternalWorkbook](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdata/#setExternalWorkbook) metodunun ikinci (`bool`) parametresi, bir Excel çalışma kitabının yüklenip yüklenmeyeceğini belirtmek için kullanılır.  

* Değeri `False` olarak ayarlandığında, yalnızca çalışma kitabı yolu güncellenir—grafik verileri hedef çalışma kitabından yüklenmez veya güncellenmez. Hedef çalışma kitabı mevcut olmadığında veya erişilemez olduğunda bu ayarı kullanabilirsiniz.  
* Değeri `True` olarak ayarlandığında, grafik verileri hedef çalışma kitabından güncellenir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("http://path/doesnt/exists", False)
    presentation.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Bir Grafiğin Harici Veri Kaynağı Çalışma Kitabı Yolunu Alma**

1. [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Kaydırmanın referansını indeksine göre alın.  
3. Grafik şekli için bir nesne oluşturun.  
4. Kaynağı temsil eden ([ChartDataSourceType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdatasourcetype/)) tipinde bir nesne oluşturun.  
5. Kaynak tipinin harici çalışma kitabı veri kaynağı tipiyle aynı olmasına göre ilgili koşulu belirtin.  

Bu Python kodu işlemi göstermektedir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartDataSourceType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(1)
    chart = slide.getShapes().get_Item(0)
    source_type = chart.getChartData().getDataSourceType()
    if source_type == ChartDataSourceType.ExternalWorkbook:
        path = chart.getChartData().getExternalWorkbookPath()
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Grafik Verilerini Düzenleme**

Harici çalışma kitaplarındaki verileri, iç çalışma kitaplarındaki içerikleri değiştirdiğiniz aynı şekilde düzenleyebilirsiniz. Harici bir çalışma kitabı yüklenemediğinde bir istisna fırlatılır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()
    chart_data.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(jpype.JInt(100))
    presentation.save("presentation_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Grafik Önbelleğinden Çalışma Kitabını Kurtarma**

Bir grafik, eksik veya kullanılamayan bir harici çalışma kitabını kullanıyorsa, Aspose.Slides, sunumda önbelleğe alınmış verilerden grafik çalışma kitabını yeniden oluşturabilir. [LoadOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/) oluşturun, onu [SpreadsheetOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/spreadsheetoptions/) ile yapılandırın ve sunumu açmadan önce `True` ile [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/tr/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) metodunu çağırın.

Aşağıdaki Python örneği, grafiği kullanılabilir olmayan bir harici çalışma kitabına referans veren bir sunumu açar ve kurtarılan verilere [Chart.getChartData](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chart/#getChartData) ve [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdata/#getChartDataWorkbook) aracılığıyla erişir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SpreadsheetOptions

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setRecoverWorkbookFromChartCache(True)
load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    recovered_workbook = chart.getChartData().getChartDataWorkbook()

    # Burada kurtarılan çalışma kitabı verilerini okuyun veya değiştirin.
finally:
    presentation.dispose()
```

Harici çalışma kitabı kullanılabilir değilse ve kurtarma devre dışı bırakılmışsa, Aspose.Slides bir istisna fırlatır. Önbellekteki grafik verilerini kullanmak kabul edilebilir bir geri dönüş olduğunda yalnızca kurtarmayı etkinleştirin; çünkü önbellek, sunumun son güncellenmesinden sonra harici çalışma kitabına yapılan değişiklikleri içermeyebilir.

## **SSS**

**Belirli bir grafiğin harici bir çalışma kitabına mı yoksa gömülü bir çalışma kitabına mı bağlandığını belirleyebilir miyim?**  
Evet. Bir grafiğin bir [veri kaynağı türü](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdata/#getDataSourceType) ve bir [harici çalışma kitabının yolu](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) vardır; kaynak bir harici çalışma kitabıysa, tam yolu okuyarak harici bir dosyanın kullanıldığını doğrulayabilirsiniz.

**Harici çalışma kitapları için göreceli yollar destekleniyor mu ve nasıl depolanıyor?**  
Evet. Göreceli bir yol belirttiğinizde, otomatik olarak mutlak yola dönüştürülür. Bu, proje taşınabilirliği için uygundur; ancak sunumun PPTX dosyasında mutlak yolu depoladığını unutmayın.

**Ağ kaynaklarında/ paylaşımlarda bulunan çalışma kitaplarını kullanabilir miyim?**  
Evet, bu tür çalışma kitapları harici veri kaynağı olarak kullanılabilir. Ancak, uzaktaki çalışma kitaplarını doğrudan Aspose.Slides'tan düzenlemek desteklenmez; yalnızca bir kaynak olarak kullanılabilirler.

**Aspose.Slides, sunumu kaydederken harici XLSX dosyasını üzerine yazıyor mu?**  
Hayır. Sunum, bir [harici dosyaya bağlantı](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) saklar ve verileri okurken bunu kullanır. Sunum kaydedildiğinde harici dosya değişmez.

**Harici dosya parola korumalıysa ne yapmalıyım?**  
Aspose.Slides, bağlantı sırasında şifre kabul etmez. Yaygın bir yaklaşım, korumayı önceden kaldırmak ya da şifresiz bir kopya (örneğin [Aspose.Cells](/cells/python-java/) kullanarak) hazırlamak ve bu kopyaya bağlamaktır.

**Birden fazla grafik aynı harici çalışma kitabına referans verebilir mi?**  
Evet. Her grafik kendi bağlantısını saklar. Hepsi aynı dosyaya işaret ediyorsa, dosya güncellendiğinde veri bir sonraki yüklendiğinde her grafiğe yansır.