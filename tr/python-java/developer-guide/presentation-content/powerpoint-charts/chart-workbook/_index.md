---
title: Python üzerinden Java ile Sunumlarda Grafik Kitaplıklarını Yönetme
linktitle: Grafik Kitaplığı
type: docs
weight: 70
url: /tr/python-java/chart-workbook/
keywords:
- grafik kitaplığı
- grafik verisi
- kitaplık hücresi
- veri etiketi
- çalışma sayfası
- veri kaynağı
- dış kitaplık
- dış veri
- grafik önbelleği
- kitaplık kurtarma
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java'ı keşfedin: PowerPoint ve OpenDocument formatlarında grafik kitaplıklarını zahmetsizce yönetin ve sunum verilerinizi sadeleştirin."
---
## **Genel Bakış**

Bu makale Aspose.Slides'te grafik kitapçıklarıyla nasıl çalışılacağını açıklar. Kitaplık akışları aracılığıyla grafik verilerini okuma ve yazma, kitaplık hücrelerini grafik veri etiketleri olarak kullanma, çalışma sayfası koleksiyonlarına erişme ve grafik değerleri için veri kaynağı tipini belirtme konularını gösterir.

Ayrıca dış kitaplıkların grafik veri kaynakları olarak kullanılması da ele alınır. Örnekler, dış bir kitaplık oluşturup atamayı, bir grafik ile ilişkilendirilmiş dış kitaplığın yolunu almayı ve kitaplık mevcut olduğunda grafik verisini düzenlemeyi gösterir.

Eksik veri temsil eden kitaplık hücreleri için, boş bir hücre ile sıfır arasındaki farkı ve kullanılabilir görüntüleme modlarının bir çizgi grafik karşılaştırmasını görmek üzere [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/python-java/chart-series/) bölümüne bakın.

## **Gizli Satır ve Sütunlardan Veri Dahil Etme**

Gizli çalışma sayfası satır ve sütunlarından veri gösterilip gösterilmeyeceğini kontrol etmek için [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly) yöntemini kullanın. Görünür hücreleri yalnızca çizmek için `True`, hem görünür hem de gizli hücreleri dahil etmek için `False` olarak ayarlayın. Bu ayar sadece grafiğin çizim davranışını kontrol eder; çalışma sayfası satır veya sütunlarını gizlemez veya göstermez.

[hidden-source-data.pptx](hidden-source-data.pptx) dosyasını indirin ve çalışma dizinine yerleştirin. İlk slaytı, ilk şekil olarak bir sütun grafik içerir. Gömülü çalışma sayfası `Sheet1`, `A1:C4` aralığını içerir. 3. satır ve C sütunu gizlidir, ancak hücreleri hâlâ değer içerir.

| Çalışma sayfası satırı | A: Ay | B: Perakende | C: Toptan (gizli sütun) |
| --- | --- | --- | --- |
| 2 | Ocak | 10 | 30 |
| 3 (gizli satır) | Şubat | 40 | 60 |
| 4 | Mart | 20 | 50 |

Kaynak hücrelere [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdata/#getChartDataWorkbook) ile erişin ve gizli durumlarını incelemek için [ChartDataCell.isHidden](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdatacell/#isHidden) metodunu okuyun. Bu metod gizli durumunu değiştirmeden raporlar. Bu dosyada B2 görünür, B3 gizli satıra ait ve C2 gizli sütuna ait; örnek sırasıyla `False`, `True` ve `True` değerlerini yazdırır.

Bu örnek için, çizim ayarını değiştirdikten sonra grafik verisini yenileyin: gömülü kitaplığı [readWorkbookStream](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdata/#readWorkbookStream) ile tutun ve [writeWorkbookStream](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdata/#writeWorkbookStream) ile yeniden yükleyin. Tüm hücreleri dahil ederken, gizli Şubat kategorisini de içerecek şekilde tam aralığı geri yüklemek için [setRange](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdata/#setRange) kullanın. Sadece bayrağı değiştirmek, bu örnekta önbelleğe alınmış grafik verisini ve kategori etiketlerini yenilemek için yeterli değildir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("hidden-source-data.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        workbook = chart.getChartData().getChartDataWorkbook()
        print("B2 hidden:", workbook.getCell(0, "B2").isHidden())
        print("B3 hidden:", workbook.getCell(0, "B3").isHidden())
        print("C2 hidden:", workbook.getCell(0, "C2").isHidden())

        workbook_data = chart.getChartData().readWorkbookStream()
        for visible_only in (True, False):
            chart.setPlotVisibleCellsOnly(visible_only)

            # Gömülü kitaplıktan grafik verisini yenile.
            chart.getChartData().writeWorkbookStream(workbook_data)
            if not visible_only:
                # Gizli kategorileri dahil ederek tam kaynak aralığını geri yükle.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Örnek, yalnızca görünür Perakende değerlerini (10 ve 20) içeren `hidden_cells_True.pptx` ve tüm altı değeri içeren `hidden_cells_False.pptx` dosyalarını kaydeder. Aşağıdaki görseller iki çizim modunu gösterir. Satır 3 ve sütun C, her iki gömülü kitaplıkta da gizli kalır.

| Yalnızca görünür hücreler (`True`) | Tüm hücreler (`False`) |
| --- | --- |
| ![Yalnızca görünür hücreler: Ocak ve Mart için Perakende değerleri 10 ve 20.](hidden_cells_True.png) | ![Tüm hücreler: Ocak, Şubat ve Mart için Perakende ve Toptan değerleri.](hidden_cells_False.png) |

Değer içeren bir gizli hücre, boş bir hücreden farklıdır. Eksik değerlerin nasıl görüntüleneceğini kontrol etmek için [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chart/#setDisplayBlanksAs) kullanılır; bu, gizli kaynak verisini eklemez veya çıkarmaz. Örnek için [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/python-java/chart-series/#control-the-display-of-empty-cells) bölümünü inceleyin.

## **Kitaplıktan Grafik Verisini Okuma ve Yazma**

Aspose.Slides for Python via Java, [readWorkbookStream](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdata/#readWorkbookStream) ve [writeWorkbookStream](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdata/#writeWorkbookStream) yöntemlerini sunar; bu yöntemler, Aspose.Cells ile düzenlenen grafik verisini içeren kitaplıkları okumanıza ve yazmanıza olanak sağlar. **Not**: Grafik verisi aynı şekilde düzenlenmiş olmalı ya da kaynakla benzer bir yapıya sahip olmalıdır.

Bu örnek, ilk slaytının ilk şekli olarak bir grafik içermesi gereken `chart.pptx` dosyasını açar. Gömülü kitaplık bir byte dizisine okunur, mevcut seriler ve kategoriler temizlenir ve aynı kitaplık geri yazılır. Değişiklikler bellekte kalır; örnek sunumu kaydetmez.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        workbook_data = chart_data.readWorkbookStream()

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

### **Kitaplık Değişikliği Sonrası Grafik Düzenini Doğrulama**

Gömülü bir kitaplığı değiştirilen bir kitaplıkla değiştirirken, grafik orijinal seri ve kategori koleksiyonlarını korur. Bu uyumsuzluk, [Chart.validateChartLayout](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chart/#validateChartLayout) metodunun indeks dışı hatasıyla başarısız olmasına neden olabilir. Güncellenmiş kitaplığı grafiğe geri yazmadan önce mevcut serileri ve kategorileri temizleyin. Bu örnek, ilk slaytının ilk şekli olarak bir grafik içeren `chart.pptx` gerektirir. Yorum satırı, kitaplık düzenlemesinin nerede yapılacağını gösterir; çalıştırılabilir örnek orijinal kitaplığı geri yazar ve düzeni bellek içinde doğrular.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        workbook_data = chart_data.readWorkbookStream()

        # Kitaplık baytlarını burada, örneğin Aspose.Cells kullanarak, değiştirin.

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Koleksiyonları temizlemek, kitaplık geri yazılmadan önce eski veri referanslarını kaldırır. Güncellenmiş kitaplık için gerekli seri ve kategori eşlemelerini yeniden oluşturun ve ardından grafiği kullanın.

## **Bir Kitaplık Hücresini Grafik Veri Etiketi Olarak Ayarlama**

Kitaplık hücrelerindeki metni grafik veri etiketi olarak kullanabilirsiniz. Aşağıdaki adımlar, bir balon grafiğindeki etiketleri veri kitaplığındaki hücrelere nasıl bağlayacağınızı gösterir.

1. [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Sıfır tabanlı indeksiyle ilk slayta erişin.  
3. Varsayılan verilerle bir balon grafik ekleyin.  
4. Grafik serisine erişin.  
5. Kitaplık hücresini veri etiketi olarak ayarlayın.  
6. Sunumu kaydedin.

Bu örnek, en az bir slayt içeren `chart2.pptx` dosyasını açar ve varsayılan verilerle bir balon grafik ekler. İlk serideki ilk üç etiket için çalışma sayfası 0 üzerindeki A10:A12 hücrelerini kullanır, hücrelerden etiketleri etkinleştirir ve sonucu `resultchart.pptx` olarak kaydeder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart2.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    label_values = ["Label 0 cell value", "Label 1 cell value", "Label 2 cell value"]
    
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

[ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdataworkbook/#getWorksheets) yöntemi, bir grafik kitaplığındaki çalışma sayfalarına erişim sağlar. Bu örnek, varsayılan verilerle bir pasta grafik oluşturur ve her bir çalışma sayfası adını konsola yazdırır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 500)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(workbook.getWorksheets().size()):
        print(workbook.getWorksheets().get_Item(i).getName())
finally:
    presentation.dispose()
```

## **Veri Kaynağı Tipini Belirtme**

Bu örnek, varsayılan verilerle bir 3B sütun grafik oluşturur ve iki seri adını farklı veri kaynaklarıyla ayarlar. İlk ad bir dize sabiti kullanır; ikincisi çalışma sayfası 0 üzerindeki C1 hücresini kullanır. [DataSourceType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/datasourcetype/) enum'ı, her ad için kaynağı seçer. Sonuç `pres.pptx` olarak kaydedilir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, True)
    literal_name = chart.getChartData().getSeries().get_Item(0).getName()
    literal_name.setDataSourceType(DataSourceType.StringLiterals)
    literal_name.setData("LiteralString")
    cell_name = chart.getChartData().getSeries().get_Item(1).getName()
    name_cell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell")
    cell_name.setDataSourceType(DataSourceType.Worksheet)
    cell_name.setData(name_cell)
    
    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Desteklenmeyen Gömülü Kitaplık Biçimlerini Algılama**

Aspose.Slides, bazı grafiklerde gömülebilen Excel ikili kitaplık (.xlsb) biçimini desteklemez. [ChartData](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdata/) üzerindeki [getEmbeddedWorkbookType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) metodunu, [WorkbookType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/workbooktype/) enum'ı ile birlikte kullanarak desteklenmeyen biçimleri algılayabilir ve bu grafikleri atlayabilirsiniz. Bu örnek, `sample.pptx` dosyasının ilk slaytındaki şekilleri inceler, grafik olmayan şekilleri atlar ve .xlsb gömülü kitaplığı olan her grafik için tanı mesajı yazdırır.

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

        is_internal_workbook = chart_data.getDataSourceType() == ChartDataSourceType.InternalWorkbook
        is_binary_macro = chart_data.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue
        # Burada desteklenen grafik kitaplığı verilerini okuyun veya değiştirin.
finally:
    presentation.dispose()
```

## **Dış Kitaplık**

Aspose.Slides, dış kitaplıkları grafik veri kaynağı olarak kullanmayı destekler.

### **Dış Kitaplık Oluşturma**

Gömülü bir grafik kitaplığını bir dosyaya dışa aktarmak ve grafiği bu dış kitaplığa bağlamak için [readWorkbookStream](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdata/#readWorkbookStream) ve [setExternalWorkbook](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdata/#setExternalWorkbook) yöntemlerini kullanın.

Bu örnek, varsayılan verilerle bir pasta grafik oluşturur, kitaplığını `externalWorkbook1.xlsx` dosyasına yazar ve dosya yazımı tamamlandıktan sonra dosyayı grafik veri kaynağı olarak atar. Bağlantılı sunumu `externalWorkbook.pptx` olarak kaydeder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600)
    workbook_path = Path("externalWorkbook1.xlsx").resolve()
    workbook_data = chart.getChartData().readWorkbookStream()
    Path(workbook_path).write_bytes(bytes(workbook_data))
    chart.getChartData().setExternalWorkbook(str(workbook_path))

    presentation.save("externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Dış Kitaplık Ayarlama**

[setExternalWorkbook](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdata/#setExternalWorkbook) metodunu kullanarak bir grafiğin veri kaynağı olarak dış bir kitaplığı atayabilirsiniz. Bu metod ayrıca dış kitaplığın yolunu (kitaplık taşındıysa) güncellemek için de kullanılabilir.

Uzak konumlardaki veya kaynaklardaki kitaplıklardaki verileri doğrudan düzenleyemezseniz de, bu kitaplıkları dış veri kaynağı olarak kullanabilirsiniz. Bir dış kitaplık için göreli bir yol sağlanırsa, otomatik olarak tam yola dönüştürülür.

Bu örnek, çalışma dizininde `externalWorkbook.xlsx` dosyasının bulunmasını gerektirir. `Sheet1` adlı çalışma sayfası B1 hücresinde bir seri adı, A2:A4 aralığında kategori adları ve B2:B4 aralığında sayısal değerler içermelidir. Örnek bir pasta grafik oluşturur, kitaplığı bağlar ve [setRange](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdata/#setRange) ile A1:B4 aralığını bir seri ve üç kategoriye eşler. Sonuç `Presentation_with_externalWorkbook.pptx` olarak kaydedilir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    workbook_path = str(Path("externalWorkbook.xlsx").resolve())
    chart_data.setExternalWorkbook(workbook_path)
    chart_data.setRange("Sheet1!$A$1:$B$4")

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[setExternalWorkbook](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdata/#setExternalWorkbook) metodundaki `updateChartData` parametresi, kitaplığın yüklenip yüklenmeyeceğini kontrol eder.

* `updateChartData` `False` ise, yalnızca kitaplık yolu güncellenir. Grafik verisi hedef kitaplıktan yüklenmez veya güncellenmez, bu nedenle kitaplık mevcut olmayabilir.  
* `updateChartData` `True` ise, grafik verisi hedef kitaplıktaki verilerle güncellenir.

Aşağıdaki örnek, `updateChartData` değeri `False` olarak ayarlanmış bir yer tutucu URL atar. Pasta grafiğinin varsayılan verileri korunur ve mevcut olmayan kitaplık yüklenmeden sunum kaydedilir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", False)

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Bir Grafiğin Dış Veri Kaynağı Kitaplık Yolunu Alma**

Bir grafik ile ilişkili kitaplığı belirlemek için önce grafiğin dış veri kaynağı kullanıp kullanmadığını kontrol edin. Kullanıyorsa, aşağıdaki adımları izleyerek kitaplık yolunu alabilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Sıfır tabanlı indeksiyle ilk slayta erişin.  
3. İlk şeklin bir grafik olduğundan emin olun.  
4. Grafik veri kaynağı tipini okuyun.  
5. Kaynak dış bir kitaplık ise, yolunu okuyun.

Bu örnek, önceki örnekte oluşturulan `externalWorkbook.pptx` dosyasını açar ve ilk slaytındaki ilk şekli inceler. Eğer bu şekil dış bir kitaplığa bağlanmış bir grafik ise, [getExternalWorkbookPath](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) değerini konsola yazdırır. Ardından sunumun bir kopyasını `Result.pptx` olarak kaydeder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, SaveFormat

presentation = Presentation("externalWorkbook.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        if chart_data.getDataSourceType() == ChartDataSourceType.ExternalWorkbook:
            print(chart_data.getExternalWorkbookPath())
        else:
            print("The chart does not use an external workbook.")
    else:
        print("The first shape is not a chart.")

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Grafik Verisini Düzenleme**

Dış kitaplıklardaki verileri, iç kitaplıklardaki değişiklikleri yaptığınız gibi düzenleyebilirsiniz. Dış bir kitaplık yüklenemediğinde bir istisna fırlatılır.

Bu örnek, ilk slaytının ilk şekli olarak bir grafik içeren `presentation.pptx` ve erişilebilir bir dış kitaplık gerektirir. İlk serideki ilk veri noktasının hücre temelli değerini 100 olarak ayarlar ve sunumu `presentation_out.pptx` olarak kaydeder. Hücre değerlerini düzenlemek bağlı dış XLSX dosyasını da güncelleyebilir; bu yüzden orijinali korumak istiyorsanız bir kopya kullanın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        series = chart.getChartData().getSeries()
        if series.size() > 0 and series.get_Item(0).getDataPoints().size() > 0:
            value_cell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell()
            if value_cell is not None:
                value_cell.setValue(jpype.JInt(100))
                presentation.save("presentation_out.pptx", SaveFormat.Pptx)
            else:
                print("The first data point is not linked to a workbook cell.")
        else:
            print("The chart has no data points to edit.")
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

### **Grafik Önbelleğinden Kitaplığı Geri Kazanma**

Bir grafik, eksik veya kullanılamayan bir dış kitaplık kullanıyorsa, Aspose.Slides sunumdaki önbelleğe alınan veriden grafik kitaplığını yeniden oluşturabilir. [LoadOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/) oluşturun, [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions) çağırın ve [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/tr/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) özelliğini `True` olarak ayarlayın; ardından sunumu açın.

Aşağıdaki Python örneği, ilk slaydındaki ilk şekil bir grafik olan ve erişilemeyen bir dış kitaplığa başvuran `presentation.pptx` dosyasını açar ve geri kazanılan verileri [Chart.getChartData](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chart/#getChartData) ve [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdata/#getChartDataWorkbook) aracılığıyla erişir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, LoadOptions, Presentation, SpreadsheetOptions

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setRecoverWorkbookFromChartCache(True)

load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        recovered_workbook = chart.getChartData().getChartDataWorkbook()

        # Kurtarılan kitaplık verilerini burada okuyun veya değiştirin.
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Dış kitaplık kullanılamazsa ve geri kazanma devre dışı bırakılmışsa, Aspose.Slides bir istisna fırlatır. Geri kazanmayı yalnızca önbellekteki grafik verisini kullanmak kabul edilebilir bir çözüm olduğunda etkinleştirin; çünkü önbellek, dış kitaplıkta sunum son güncellendiğinden sonra yapılan değişiklikleri içermeyebilir.

## **SSS**

**Belirli bir grafiğin dış mı yoksa gömülü bir kitaplığa mı bağlandığını nasıl öğrenebilirim?**

Evet. Bir grafiğin [veri kaynağı tipi](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdata/#getDataSourceType) ve [dış bir kitaplığın yolu](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) vardır; kaynak dış bir kitaplık ise tam yolu okuyarak dış bir dosyanın kullanıldığını doğrulayabilirsiniz.

**Dış kitaplıklar için göreli yollar destekleniyor mu ve nasıl depolanıyor?**

Evet. Göreli bir yol belirtirseniz, otomatik olarak mutlak yola dönüştürülür. Sunum, mutlak yolu PPTX dosyasında saklar; bu nedenle kitaplık taşındığında bağlantıyı güncellemeniz gerekebilir.

**Ağ kaynakları/paylaşımları üzerindeki kitaplıkları kullanabilir miyim?**

Evet, bu tür kitaplıklar dış veri kaynağı olarak kullanılabilir. Ancak, Aspose.Slides'tan uzaktaki kitaplıkları doğrudan düzenlemek desteklenmez; yalnızca kaynak olarak kullanılabilirler.

**Aspose.Slides, sunumu kaydederken dış XLSX dosyasını üzerine yazar mı?**

Sunum, dış dosyaya bir [bağlantı](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) saklar. Hücre temelli grafik verilerini düzenlemek aynı zamanda bağlı yerel XLSX dosyasını da güncelleyebilir. Orijinalini değiştirmemek gerekiyorsa bir kopya kullanın.

**Dış dosya şifre korumalıysa ne yapmalıyım?**

Aspose.Slides, bağlantı sırasında şifre kabul etmez. Yaygın bir yaklaşım, önceden korumayı kaldırmak veya bir kopyasını (örneğin [Aspose.Cells](https://reference.aspose.com/cells/python-java/)) çözerek ona bağlamaktır.

**Birden fazla grafik aynı dış kitaplığa başvurabilir mi?**

Evet. Her grafik kendi bağlantısını saklar. Hepsi aynı dosyaya işaret ediyorsa, dosya güncellendiğinde bu değişiklik bir sonraki veri yüklemesinde tüm grafiklerde yansır.