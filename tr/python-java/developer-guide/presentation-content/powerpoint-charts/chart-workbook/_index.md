---
title: Python via Java Kullanarak Sunumlarda Grafik Çalışma Kitaplarını Yönetme
linktitle: Grafik Çalışma Kitabı
type: docs
weight: 70
url: /tr/python-java/chart-workbook/
keywords:
- grafik çalışma kitabı
- grafik verisi
- çalışma kitabı hücresi
- veri etiketi
- çalışma sayfası
- veri kaynağı
- dış çalışma kitabı
- dış veri
- grafik önbelleği
- çalışma kitabı kurtarma
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java'ı keşfedin: PowerPoint ve OpenDocument formatlarında grafik çalışma kitaplarını zahmetsizce yöneterek sunum verilerinizi düzenleyin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Çalışma kitabı akışları aracılığıyla grafik verilerini okuma ve yazma, çalışma kitabı hücrelerini grafik veri etiketleri olarak kullanma, çalışma sayfası koleksiyonlarına erişme ve grafik değerleri için veri kaynağı türünü belirtme yöntemlerini gösterir.

Ayrıca dış çalışma kitaplarını grafik veri kaynakları olarak kullanmayı da kapsar. Örnekler, dış bir çalışma kitabı oluşturup atamayı, bir grafikle ilişkili dış çalışma kitabının yolunu almayı ve çalışma kitabı kullanılabilir olduğunda grafik verilerini düzenlemeyi göstermektedir.

Eksik veriyi temsil eden çalışma kitabı hücreleri için, boş bir hücre ile sıfır arasındaki farkı ve mevcut gösterim modlarının bir çizgi grafik karşılaştırmasını görmek üzere [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/python-java/chart-series/) bölümüne bakınız.

## **Gizli Satır ve Sütunlardaki Verileri Dahil Et**

Gizli çalışma sayfası satır ve sütunlarından veri grafikleyip grafiklemeyeceğinizi kontrol etmek için [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly) yöntemini kullanın. Yalnızca görünür hücreleri çizmek için `True`, hem görünür hem de gizli hücreleri dahil etmek için `False` ayarlayın. Bu ayar grafik çizimini etkiler; çalışma sayfası satır ve sütunlarını gizlemez veya ortaya çıkarmaz.

[örnek sunum](hidden-source-data.pptx) ilk slaytının ilk şekli olarak bir sütun grafik içerir. Gömülü çalışma sayfası `Sheet1`, `A1:C4` kaynak aralığını içerir. Satır 3 ve sütun C gizlidir, ancak hücreleri hâlâ değer içerir.

| Çalışma sayfası satırı | A: Ay | B: Perakende | C: Toptan (gizli sütun) |
| --- | --- | --- | --- |
| 2 | Ocak | 10 | 30 |
| 3 (gizli satır) | Şubat | 40 | 60 |
| 4 | Mart | 20 | 50 |

Kaynak hücrelere [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) üzerinden erişin ve gizli durumlarını incelemek için [ChartDataCell.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#isHidden) özelliğini okuyun. Bu yöntem gizli durumunu değiştirmeden bildirir. Bu dosyada B2 görünür, B3 gizli satıra ait ve C2 gizli sütuna aittir; örnek sırasıyla `False`, `True` ve `True` değerlerini yazdırır.

Bu örnek için, çizim ayarı değiştirildikten sonra grafik verilerini yenileyin: gömülü çalışma kitabını [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) ile tutun ve [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) ile yeniden yükleyin. Tüm hücreleri dahil ederken, gizli Şubat kategorisini de içermek için [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) yöntemini kullanın. Bayrağı yalnızca değiştirmek, bu örneğin önbelleğe alınmış grafik verilerini ve kategori etiketlerini yenilemek için yeterli değildir.

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

            # Gömülü çalışma kitabından grafik verilerini yenileyin.
            chart.getChartData().writeWorkbookStream(workbook_data)
            if not visible_only:
                # Gizli kategoriler dahil olmak üzere tam kaynak aralığını geri yükleyin.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Örnek, sunumu iki sürüm olarak kaydeder: yalnızca görünür Perakende değerleri (10 ve 20) içeren bir sürüm ve tüm altı değeri içeren bir sürüm. Aşağıdaki görseller iki çizim modunu gösterir. Satır 3 ve sütun C her iki gömülü çalışma kitabında da gizli kalır.

| Yalnızca görünür hücreler (`True`) | Tüm hücreler (`False`) |
| --- | --- |
| ![Sadece görünür hücreler: Ocak ve Mart için Perakende değerleri 10 ve 20.](hidden_cells_True.png) | ![Tüm hücreler: Ocak, Şubat ve Mart için Perakende ve Toptan değerleri.](hidden_cells_False.png) |

Değer içeren gizli bir hücre, boş bir hücreden farklıdır. Eksik değerlerin nasıl gösterileceğini kontrol etmek için [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) yöntemi kullanılır; bu yöntem gizli kaynak verileri eklemez veya çıkarmaz. Bir örnek için [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/python-java/chart-series/#control-the-display-of-empty-cells) bölümüne bakınız.

## **Bir Grafiğin Veri Aralığını Al**

Mevcut bir sunumda çalışma kitabı verilerini güncellemeden önce, her grafiğin kullandığı çalışma sayfası hücrelerini belirlemek amacıyla kaynak aralıklarını inceleyin. [ChartData.getRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getRange) yöntemi, örneğin `Sheet1!$A$1:$D$5` gibi çalışma sayfası nitelikli bir formül olarak geçerli veri aralığını döndürür. Burada `Sheet1` çalışma sayfası adıdır, `!` hücre aralığını ayırır ve `$A$1:$D$5` A1’den D5’e kadar olan hücreleri (dahil) tanımlar. Dolar işaretleri mutlak satır ve sütun referanslarını gösterir.

Yöntem, grafik veya onun çalışma kitabını değiştirmeden geçerli aralığı okur. Grafik veri kaynağı olarak bir çalışma kitabı kullanmıyorsa `InvalidOperationException` hatası atar. Daha fazla bilgi için [ChartData API Referansı](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/) bölümüne bakınız.

Bu örnek bir sunumu açar ve her slayttaki şekilleri doğrudan grafik için kontrol eder. Her grafiğin adını ve kaynak aralığını yazdırır. Grafik bir çalışma kitabı kullanmıyorsa bir mesaj verir ve bir sonraki grafiğe geçer.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

InvalidOperationException = jpype.JClass("com.aspose.slides.exceptions.InvalidOperationException")

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, Chart):
                try:
                    data_range = shape.getChartData().getRange()
                    print(f"{shape.getName()}: {data_range}")
                except InvalidOperationException:
                    print(f"{shape.getName()}: The chart does not use a workbook as its data source.")
finally:
    presentation.dispose()
```

## **Bir Çalışma Kitabından Grafik Verilerini Oku ve Yaz**

Aspose.Slides for Python via Java, [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) ve [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) yöntemlerini sağlar; bu yöntemlerle Aspose.Cells ile düzenlenmiş grafik veri çalışma kitaplarını okuyup yazabilirsiniz. **Not**: Grafik verileri aynı şekilde düzenlenmiş olmalı veya kaynakla benzer bir yapıya sahip olmalıdır.

Bu örnek, ilk slaytının ilk şekli olarak bir grafik içeren bir sunumu kullanır. Gömülü çalışma kitabını bir bayt dizisine okur, mevcut serileri ve kategorileri temizler ve aynı çalışma kitabını geri yazar. Değişiklikler bellekte kalır; örnek sunumu kaydetmez.

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

### **Çalışma Kitabı Değişikliği Sonrası Grafik Yerleşimini Doğrula**

Gömülü bir çalışma kitabını değiştirilmiş bir sürümle değiştirdiğinizde, grafik orijinal seri ve kategori koleksiyonlarını tutar. Bu uyumsuzluk, [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) yönteminin indeks dışı hata vermesine neden olabilir. Güncellenmiş çalışma kitabını grafiğe geri yazmadan önce mevcut serileri ve kategorileri temizleyin. Bu örnek, ilk slaytının ilk şekli olarak bir grafik kullanır. Yorum satırı, çalışma kitabı düzenlemesinin nerede gerçekleşeceğini işaret eder; çalıştırılabilir örnek orijinal çalışma kitabını geri yazar ve yerleşimi bellekte doğrular.

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

        # Burada çalışma kitabı baytlarını değiştirin, örneğin Aspose.Cells kullanarak.

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Koleksiyonları temizlemek, çalışma kitabı geri yazılmadan önce eski veri referanslarını kaldırır. Güncellenmiş çalışma kitabı için gerekli serileri ve kategori eşlemelerini yeniden oluşturun ve ardından grafiği kullanın.

## **Çalışma Kitabı Hücreleri için Özel Sayı Formatları Ayarla**

[ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setCustomNumberFormat) yöntemi, bir grafiğin gömülü çalışma kitabındaki sayısal değerlerin nasıl görüneceğini kontrol eder. Örneğin, bir rapor dönüşüm oranını yüzde olarak dört ondalık basamak ve katsayısını beş ondalık basamakla gösterebilir. Her iki değeri de sayısal tutun; böylece hesaplamalar ve grafik çizimi için kullanılabilir kalırlar.

Bir sayı formatı görüntüyü değiştirir, saklanan değeri değiştirmez. `0.0000%` formatı `0.125` sayısını `12.5000%` olarak gösterir; saklanan sayıyı `12.5` yapmaz. Benzer şekilde, `0.00000` formatı `0.1234567` sayısını `0.12346` olarak gösterir ancak saklanan değeri yuvarlamaz. Özel format boş bir dize (`""`) ise, [getPresetNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#getPresetNumberFormat) tarafından döndürülen format kullanılır.

Aşağıdaki örnek, bir sütun grafik oluşturur ve hücrelerine [getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) üzerinden erişir. Çalışma sayfası 0’da B2 dönüşüm oranını, C2 ise katsayısını içerir. Her iki hücre de grafik değerlerini sağlar. Örnek ayrıca, kaynak formatlara bağlı değer etiketlerini etkinleştirir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 270, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 20, 620, 210)
    chart.setTitle(False)

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00")
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)
    chart.getAxes().getVerticalAxis().setMinValue(0)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    category_cell = workbook.getCell(0, "A2", "Sample")
    chart.getChartData().getCategories().add(category_cell)

    percentage_cell = workbook.getCell(0, "B2", jpype.JDouble(0.125))
    percentage_cell.setCustomNumberFormat("0.0000%")
    percentage_name = workbook.getCell(0, "B1", "Conversion rate")
    percentage_series = chart.getChartData().getSeries().add(percentage_name, chart.getType())
    percentage_series.getDataPoints().addDataPointForBarSeries(percentage_cell)

    precision_cell = workbook.getCell(0, "C2", jpype.JDouble(0.1234567))
    precision_cell.setCustomNumberFormat("0.00000")
    precision_name = workbook.getCell(0, "C1", "Coefficient")
    precision_series = chart.getChartData().getSeries().add(precision_name, chart.getType())
    precision_series.getDataPoints().addDataPointForBarSeries(precision_cell)

    for series in chart.getChartData().getSeries():
        label_format = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat()
        label_format.setShowValue(True)
        label_format.setNumberFormatLinkedToSource(True)

    presentation.save("CustomCellFormats.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Çalışma kitabı hücre formatları, grafik eksenlerine veya veri etiketlerine doğrudan ayarlanan formatlardan ayrı tutulur. Bu örnekte, her etiket, [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) `True` olduğu için kaynak hücrenin değerini gösterir ve [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) `True` olduğu için kaynak sayı formatını takip eder. Sunumu kaydedip yeniden açtıktan sonra etiketler `12.5000%` ve `0.12346` olarak gösterilir. Dikey eksen, kendi sayı formatını [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) `0.00` ile ayarlar ve [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) `False` olarak ayarlanmıştır.

Bir veri etiketini bağımsız olarak biçimlendirmek için, kaynak‑bağlantı bayrağını `False` yapın ve [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat) ile bir format atayın. Bu, çalışma kitabı hücresinin formatını değiştirmez. Örneğin, bağımsız etiket formatı `0.00` ilk değeri `0.13` olarak gösterirken B2 hâlâ `12.5000%` gösterir. Doğrudan etiket biçimlendirmesi için [Chart Data Labels](/slides/tr/python-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) bölümüne bakınız.

Aşağıdaki resim, sunumu kaydedip yeniden açtıktan sonra oluşturulmuştur:

![Kaynak‑bağlantılı etiketleriyle 12.5000% ve 0.12346 gösteren sütun grafik ve bağımsız olarak biçimlendirilmiş sayısal eksen.](custom-cell-formats.png)

## **Bir Çalışma Kitabı Hücresini Grafik Veri Etiketi Olarak Ayarla**

Çalışma kitabı hücrelerindeki metni grafik veri etiketi olarak kullanabilirsiniz.

Bu örnek, mevcut bir sunumun ilk slaytına varsayılan verilerle bir balon grafik ekler. İlk serideki ilk üç etiket için çalışma sayfası 0’da A10:A12 hücrelerini kullanır, hücrelerden etiketleri etkinleştirir ve güncellenmiş sunumu kaydeder.

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

## **Çalışma Sayfalarını Yönet**

[ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getWorksheets) yöntemi, bir grafik çalışma kitabındaki çalışma sayfalarına erişim sağlar. Bu örnek, varsayılan verilerle bir pasta grafik oluşturur ve her çalışma sayfasının adını konsola yazar.

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

## **Veri Kaynağı Türünü Belirle**

Bu örnek, varsayılan verilerle bir 3D sütun grafik oluşturur ve iki seri adını farklı veri kaynakları kullanarak ayarlar. İlk ad, bir dize sabiti olarak; ikinci ad ise çalışma sayfası 0’da C1 hücresinden alınır. [DataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/) enum\'u her ad için kaynağı seçer. Örnek, güncellenmiş seri adlarıyla sunumu kaydeder.

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

## **Gömülü Çalışma Kitabı Formatlarını Desteklemediğini Algıla**

Aspose.Slides, bazı grafiklerde gömülebilen Excel ikili çalışma kitabı (.xlsb) formatını desteklemez. Desteklenmeyen formatları algılamak ve bu grafikleri atlamak için, [ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/) üzerindeki [getEmbeddedWorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) yöntemi ve [WorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/workbooktype/) enum\'u kullanılabilir. Bu örnek, mevcut bir sunumun ilk slaydındaki şekilleri inceler, grafik olmayan şekilleri atlar ve .xlsb gömülü çalışma kitabı bulunan her grafik için bir tanı mesajı yazar.

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
        # Desteklenen grafik çalışma kitabı verilerini burada okuyun veya değiştirin.
finally:
    presentation.dispose()
```

## **Dış Çalışma Kitabı**

Aspose.Slides, grafikler için dış çalışma kitaplarını veri kaynağı olarak kullanmayı destekler.

### **Dış Çalışma Kitabı Oluştur**

[readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) ve [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) yöntemleriyle gömülü grafik çalışma kitabını bir dosyaya aktarabilir ve grafiği bu dış çalışma kitabına bağlayabilirsiniz.

Bu örnek, varsayılan verilerle bir pasta grafik oluşturur ve çalışma kitabını dışa aktarır. Dosya yazma işlemi tamamlandıktan sonra dış çalışma kitabı veri kaynağı olarak atanır ve bağlanmış sunum kaydedilir.

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

### **Dış Çalışma Kitabı Ata**

[setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) yöntemiyle bir grafiğe dış bir çalışma kitabını veri kaynağı olarak atayabilirsiniz. Bu yöntem, dış çalışma kitabının konumu değiştiğinde yolu güncellemek için de kullanılabilir (dosya taşındıysa).

Uzak konumlardaki veya kaynaklardaki çalışma kitaplarının verileri doğrudan düzenlenemez, ancak bu çalışma kitapları dış veri kaynağı olarak kullanılabilir. Göreli bir yol sağlanırsa, otomatik olarak tam yola dönüştürülür.

Bu örnek, `Sheet1` adlı çalışma sayfasında B1’de bir seri adı, A2:A4 aralığında kategori adları ve B2:B4 aralığında sayısal değerler bulunan bir dış çalışma kitabı kullanır. Pasta grafik oluşturur, çalışma kitabını bağlar ve [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) ile A1:B4 aralığını bir seri ve üç kategoriye eşler. Bağlantılı grafikle birlikte sunumu kaydeder.

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

[setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) yönteminin `updateChartData` parametresi, çalışma kitabının yüklenip yüklenmeyeceğini kontrol eder.

* `updateChartData` `False` olduğunda yalnızca çalışma kitabı yolu güncellenir. Grafik verileri hedef çalışma kitabından yüklenmez veya güncellenmez; bu nedenle çalışma kitabı bulunmayabilir.
* `updateChartData` `True` olduğunda grafik verileri hedef çalışma kitabından güncellenir.

Aşağıdaki örnek, `updateChartData` `False` olarak ayarlanmış bir yer tutucu URL atar. Pasta grafiğinin varsayılan verileri korunur ve bulunmayan çalışma kitabı yüklenmeden sunum kaydedilir.

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

### **Bir Grafiğin Dış Veri Kaynağı Çalışma Kitabı Yolunu Al**

Bir grafiğin bağlı olduğu çalışma kitabını belirlemek için, grafiğin dış veri kaynağı kullanıp kullanmadığını kontrol edin ve çalışma kitabı yolunu alın.

Bu örnek, dış çalışma kitabına bağlı bir grafik olup olmadığını kontrol etmek için sunumun ilk slaydındaki ilk şekli inceler. Eğer grafik dış bir çalışma kitabına bağlıysa, [getExternalWorkbookPath](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) metodunu konsola yazar ve ardından sunumun bir kopyasını kaydeder.

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

### **Grafik Verilerini Düzenle**

Dış çalışma kitaplarındaki verileri, iç çalışma kitaplarındaki gibi düzenleyebilirsiniz. Dış çalışma kitabı yüklenemediğinde bir istisna oluşur.

Bu örnek, ilk slaytının ilk şekli olarak bir grafik kullanır ve erişilebilir bir dış çalışma kitabına bağlıdır. İlk serinin ilk veri noktasının hücre‑temelli değerini 100 olarak ayarlar ve güncellenmiş sunumu kaydeder. Hücre değerlerini düzenlemek, bağlanan dış XLSX dosyasını güncelleyebilir; bu nedenle orijinali korumak istiyorsanız bir kopya kullanın.

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

### **Grafik Önbelleğinden Çalışma Kitabını Kurtar**

Bir grafik, eksik veya erişilemeyen bir dış çalışma kitabı kullanıyorsa, Aspose.Slides sunumda önbelleğe alınan verilerden grafik çalışma kitabını yeniden oluşturabilir. [LoadOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/) oluşturun, [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions) çağırın ve [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) `True` olarak ayarlayın; ardından sunumu açın.

Aşağıdaki Python örneği, ilk slaydının ilk şekli olarak bir grafik ve erişilemeyen bir dış çalışma kitabına başvuran bir senaryoda çalışma kitabı verilerini kurtarır. Kurtarılan verilere [Chart.getChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getChartData) ve [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) üzerinden erişir:

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

        # Kurtarılan çalışma kitabı verilerini burada okuyun veya değiştirin.
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Dış çalışma kitabı mevcut değil ve kurtarma devre dışı bırakıldıysa Aspose.Slides bir istisna fırlatır. Önbellekten grafik verilerini kullanmak kabul edilebilir bir geri dönüşse, kurtarmayı etkinleştirin; çünkü önbellek, dış çalışma kitabında sunum son güncellendiğinden sonraki değişiklikleri içermeyebilir.

## **SSS**

**Belirli bir grafiğin dış mı yoksa gömülü bir çalışma kitabına mı bağlı olduğunu belirleyebilir miyim?**

Evet. Bir grafiğin [data source type](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) ve [external workbook path](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) vardır; kaynak dış bir çalışma kitabı ise tam yolu okuyup dış dosyanın kullanıldığını doğrulayabilirsiniz.

**Dış çalışma kitapları için göreli yollar destekleniyor mu ve nasıl depolanıyor?**

Evet. Göreli bir yol belirtirseniz otomatik olarak mutlak yola dönüştürülür. Sunum, mutlak yolu PPTX dosyasında saklar; bu nedenle çalışma kitabını taşımak bağlantının güncellenmesini gerektirebilir.

**Ağ kaynakları/paylaşımları üzerindeki çalışma kitaplarını kullanabilir miyim?**

Evet, bu tür çalışma kitapları dış veri kaynağı olarak kullanılabilir. Ancak, Aspose.Slides üzerinden uzak çalışma kitaplarını doğrudan düzenlemek desteklenmez; yalnızca kaynak olarak kullanılabilirler.

**Sunumu kaydederken Aspose.Slides dış XLSX dosyasını üzerine yazar mı?**

Sunum, dış dosyaya bir [link](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) saklar. Hücre‑temelli grafik verilerini düzenlemek, bağlantılı yerel XLSX dosyasını da güncelleyebilir. Orijinal dosyanın değişmemesi gerekiyorsa bir kopyasını kullanın.

**Dış dosya şifre korumalıysa ne yapmalıyım?**

Aspose.Slides, bağlanırken şifre kabul etmez. Yaygın bir çözüm, önceden korumayı kaldırmak veya bir şifre çözülmüş kopya hazırlamaktır (örneğin [Aspose.Cells](https://reference.aspose.com/cells/python-java/) kullanarak) ve bu kopyaya bağlanmaktır.

**Birden fazla grafik aynı dış çalışma kitabına başvurabilir mi?**

Evet. Her grafik kendi bağlantısını saklar. Hepsi aynı dosyaya işaret ediyorsa, dosya güncellendiğinde veri bir sonraki yüklemede tüm grafiklerde yansır.