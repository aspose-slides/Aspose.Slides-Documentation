---
title: Python via Java kullanarak Sunumlarda Grafik Çalışma Kitaplarını Yönetme
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
- harici çalışma kitabı
- harici veri
- grafik önbelleği
- çalışma kitabı kurtarma
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java'ı keşfedin: PowerPoint ve OpenDocument formatlarında grafik çalışma kitaplarını zahmetsizce yönetin ve sunum verilerinizi düzenleyin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'te grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Çalışma kitabı akışları üzerinden grafik verilerini okuma ve yazma, çalışma kitabı hücrelerini grafik veri etiketi olarak kullanma, çalışma sayfası koleksiyonlarına erişme ve grafik değerleri için veri kaynağı türünü belirleme konularını gösterir.

Ayrıca harici çalışma kitaplarının grafik veri kaynağı olarak kullanılmasını da kapsar. Örnekler, harici bir çalışma kitabı oluşturma ve atama, bir grafik ile ilişkilendirilmiş harici çalışma kitabının yolunu alma ve çalışma kitabı mevcut olduğunda grafik verilerini düzenleme konularını gösterir.

Eksik verileri temsil eden çalışma kitabı hücreleri için, boş hücre ile sıfır arasındaki farkı ve mevcut görüntüleme modlarının bir çizgi grafiği karşılaştırmasını görmek üzere [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/python-java/chart-series/) bölümüne bakın.

## **Gizli Satır ve Sütunlardan Veri Dahil Et**

[Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly) kullanarak bir grafiğin gizli çalışma sayfası satır ve sütunlarından veri çizip çizmeyeceğini kontrol edin. Sadece görünen hücreleri çizmek için `True`, hem görünen hem de gizli hücreleri dahil etmek için `False` olarak ayarlayın. Bu ayar grafik çizimini kontrol eder; çalışma sayfası satır veya sütunlarını gizlemez/göstermez.

[örnek sunum](hidden-source-data.pptx) ilk slaytının ilk şekli olarak bir sütun grafiği içerir. Gömülü çalışma sayfası `Sheet1`, `A1:C4` kaynak aralığını içerir. 3. satır ve C sütunu gizlidir, ancak hücreleri hâlâ değer içerir.

| Çalışma sayfası satırı | A: Ay | B: Perakende | C: Toptan (gizli sütun) |
| --- | --- | --- | --- |
| 2 | Ocak | 10 | 30 |
| 3 (gizli satır) | Şubat | 40 | 60 |
| 4 | Mart | 20 | 50 |

Kaynak hücrelere [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) üzerinden erişin ve gizli durumlarını incelemek için [ChartDataCell.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#isHidden) değerini okuyun. Bu yöntem gizli durumu değiştirmeden rapor eder. Bu dosyada B2 görünür, B3 gizli satıra aittir ve C2 gizli sütuna aittir; örnek sırasıyla `False`, `True` ve `True` değerlerini yazdırır.

Bu örnek için, çizim ayarını değiştirdikten sonra grafik verisini yenileyin: gömülü çalışma kitabını [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) ile tutun ve [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) ile yeniden yükleyin. Tüm hücreleri dahil ederken, gizli Şubat kategorisini de içeren tam aralığı geri yüklemek için [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) kullanın. Bayrağı yalnızca değiştirmek, bu örnek için önbellekteki grafik verilerini ve kategori etiketlerini yenilemek için yetersizdir.

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

            # Gömülü çalışma kitabından grafik verilerini yenile.
            chart.getChartData().writeWorkbookStream(workbook_data)
            if not visible_only:
                # Gizli kategoriler dahil tam kaynak aralığını geri yükle.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Örnek, yalnızca görünen Perakende değerleri (10 ve 20) içeren bir sunum sürümü ve tüm altı değeri içeren bir sürüm kaydeder. Aşağıdaki görüntüler iki çizim modunu gösterir. 3. satır ve C sütunu her iki gömülü çalışma kitabında da gizli kalır.

| Yalnızca görünen hücreler (`True`) | Tüm hücreler (`False`) |
| --- | --- |
| ![Yalnızca görünen hücreler: Ocak ve Mart için Perakende değerleri 10 ve 20.](hidden_cells_True.png) | ![Tüm hücreler: Ocak, Şubat ve Mart için Perakende ve Toptan değerleri.](hidden_cells_False.png) |

Değer içeren gizli bir hücre, boş bir hücreden farklıdır. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) eksik değerlerin nasıl görüntüleneceğini kontrol eder; gizli kaynak veriyi dahil etmez ya da hariç tutmaz. Bir örnek için [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/python-java/chart-series/#control-the-display-of-empty-cells) bölümüne bakın.

## **Bir Grafiğin Veri Aralığını Alma**

Mevcut bir sunumda çalışma kitabı verilerini güncellemeden önce, her bir grafiğin hangi çalışma sayfası hücrelerini kullandığını belirlemek için kaynak aralıklarını inceleyin. [ChartData.getRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getRange) yöntemi, `Sheet1!$A$1:$D$5` gibi bir çalışma sayfası nitelikli formül olarak mevcut veri aralığını döndürür. Burada `Sheet1` çalışma sayfası adıdır, `!` hücre aralığından ayırır ve `$A$1:$D$5` A1'den D5'e kadar olan hücreleri (dahil) gösterir. Dolar işaretleri mutlak satır ve sütun referanslarını belirtir.

Yöntem, grafiği veya onun çalışma kitabını değiştirmeden mevcut aralığı okur. Grafik, veri kaynağı olarak bir çalışma kitabı kullanmıyorsa `InvalidOperationException` hatası verir. Daha fazla bilgi için [ChartData API Referansı](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/) bölümüne bakın.

Bu örnek bir sunumu açar ve her slayttaki şekilleri doğrudan kontrol ederek grafikleri bulur. Her grafiğin adını ve kaynak aralığını yazdırır. Bir grafik çalışma kitabı kullanmıyorsa bir mesaj verir ve sonraki grafiğe geçer.

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

## **Bir Çalışma Kitabından Grafik Verilerini Okuma ve Yazma**

Aspose.Slides for Python via Java, [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) ve [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) yöntemlerini sağlar; bu yöntemler, Aspose.Cells ile düzenlenmiş grafik verilerini içeren çalışma kitaplarını okumanıza ve yazmanıza olanak tanır. **Not** grafik verileri aynı şekilde düzenlenmeli veya kaynağa benzer bir yapıya sahip olmalıdır.

Bu örnek, ilk slaytının ilk şekli olarak bir grafik içeren bir sunum kullanır. Gömülü çalışma kitabını bir bayt dizisine okur, mevcut serileri ve kategorileri temizler ve aynı çalışma kitabını geri yazar. Değişiklikler bellekte kalır; örnek sunumu kaydetmez.

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

### **Çalışma Kitabı Değiştirdikten Sonra Grafik Düzenini Doğrulama**

Gömülü bir çalışma kitabını değiştirilmiş bir sürümle değiştirdiğinizde, grafik orijinal seri ve kategori koleksiyonlarını tutar. Bu uyumsuzluk, [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) yönteminin indeks dışı hata vermesine neden olabilir. Güncellenmiş çalışma kitabını grafiğe geri yazmadan önce mevcut serileri ve kategorileri temizleyin. Bu örnek, ilk slaytın ilk şekli olarak bir grafik kullanır. Yorum, çalışma kitabı düzenlemesinin nerede yapılacağını işaret eder; çalıştırılabilir örnek orijinal çalışma kitabını geri yazar ve düzeni bellek içinde doğrular.

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

Koleksiyonların temizlenmesi, çalışma kitabı geri yazılmadan önce eski veri referanslarını kaldırır. Güncellenmiş çalışma kitabı için gerekli seri ve kategori eşlemelerini yeniden oluşturun ve ardından grafiği kullanın.

## **Çalışma Kitabı Hücreleri için Özel Sayı Biçimleri Ayarla**

[ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setCustomNumberFormat) kullanarak bir grafiğin gömülü çalışma kitabındaki sayısal değerlerin nasıl görüneceğini kontrol edin. Örneğin, bir rapor dönüşüm oranını yüzde dört ondalık basamakla ve bir katsayıyı beş ondalık basamakla göstermek isteyebilir. Her iki değeri de sayısal tutun, böylece hesaplamalar ve grafik çizimi için kullanılabilir.

Sayı biçimi yalnızca görüntüyü değiştirir, saklanan değeri değiştirmez. `0.0000%` biçimi `0.125` sayısını `12.5000%` olarak gösterir; saklanan sayı `12.5` olarak değiştirilmez. Benzer şekilde, `0.00000` `0.1234567` sayısını `0.12346` gösterir, saklanan değeri yuvarlamaz. Özel biçim boş bir dize (`""`) ise, [getPresetNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#getPresetNumberFormat) tarafından döndürülen biçim kullanılır.

Aşağıdaki örnek bir sütun grafiği oluşturur ve hücrelerine [getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) üzerinden erişir. Çalışma sayfası 0'da B2 dönüşüm oranını, C2 ise katsayıyı içerir. Her iki hücre de grafik değerleri sağlar. Örnek ayrıca kaynak biçimlere bağlı değer etiketlerini etkinleştirir.

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

Çalışma kitabı hücre biçimleri, doğrudan grafik eksenlerine veya veri etiketlerine ayarlanan biçimlerden ayrı tutulur. Bu örnekte, her etiket [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) `True` olduğu için kaynak hücresinin değerini gösterir ve [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) `True` olduğu için kaynak sayı biçimini takip eder. Sunumu kaydedip yeniden açtıktan sonra etiketler `12.5000%` ve `0.12346` gösterir, aşağıda gösterildiği gibi. Dikey eksen, [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) ile `0.00` biçiminde, [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) `False` olarak ayarlanmış kendi biçimini kullanır.

Bir veri etiketini bağımsız biçimlendirmek için, kaynak‑bağlantı bayrağını `False` yapın ve [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat) ile bir biçim atayın. Bu, çalışma kitabı hücresinin biçimini değiştirmez. Örneğin, bağımsız bir etiket biçimi `0.00` ilk değeri `0.13` olarak gösterirken, B2 hâlâ `12.5000%` gösterir. Doğrudan etiket biçimlendirme için [Grafik Veri Etiketleri](/slides/tr/python-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) bölümüne bakın.

Aşağıdaki görüntü, sunum kaydedildikten ve yeniden açıldıktan sonra oluşturulmuştur:

![Kaynak‑bağlantılı etiketlerin 12.5000% ve 0.12346 gösterdiği ve bağımsız biçimlendirilmiş sayısal eksenin bulunduğu sütun grafiği.](custom-cell-formats.png)

## **Bir Çalışma Kitabı Hücresini Grafik Veri Etiketi Olarak Ayarla**

Çalışma kitabı hücrelerindeki metni grafik veri etiketleri olarak kullanabilirsiniz.

Bu örnek, mevcut bir sunumun ilk slaydına varsayılan verilerle bir balon grafiği ekler. İlk serideki ilk üç etiket için çalışma sayfası 0'da A10:A12 hücrelerini kullanır, hücrelerden gelen etiketleri etkinleştirir ve güncellenmiş sunumu kaydeder.

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

[ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getWorksheets) yöntemi, bir grafik çalışma kitabındaki çalışma sayfalarına erişim sağlar. Bu örnek, varsayılan veri ile bir pasta grafiği oluşturur ve her bir çalışma sayfasının adını konsola yazdırır.

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

## **Veri Kaynağı Türünü Belirleme**

Seri nokta değerleri aynı zamanda doğrudan sayısal sabitler olarak da depolanabilir. Tam örnek için [Sayısal Sabitler Kullanarak Seri Değerlerini Ayarlama](/slides/tr/python-java/chart-series/#set-series-values-using-numeric-literals) bölümüne bakın. Nokta değerlerinin kaynak türü, grafiğin dahili veya harici çalışma kitabı yapılandırmasından ayrıttır; sayısal sabitler kullanmak, gömülü çalışma kitabını otomatik olarak kaldırmaz.

Bu örnek, varsayılan veri ile bir 3B sütun grafiği oluşturur ve iki seri adını farklı veri kaynaklarıyla ayarlar. İlk ad bir dize sabiti; ikincisi ise çalışma sayfası 0'da C1 hücresidir. [DataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/) enumu, her bir ad için kaynağı seçer. Örnek, güncellenmiş seri adlarıyla sunumu kaydeder.

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

## **Desteklenmeyen Gömülü Çalışma Kitabı Biçimlerini Algılama**

Aspose.Slides, bazı grafiklerde gömülebilen Excel ikili çalışma kitabı (.xlsb) formatını desteklemez. Desteklenmeyen biçimleri algılamak ve bu grafikleri atlamak için [ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/) üzerindeki [getEmbeddedWorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) yöntemini, [WorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/workbooktype/) enumu ile birlikte kullanabilirsiniz. Bu örnek, mevcut bir sunumun ilk slaydındaki şekilleri inceler, grafik olmayan şekilleri atlar ve .xlsb gömülü çalışma kitabı bulunan her grafiğe tanılayıcı bir mesaj yazdırır.

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

## **Harici Çalışma Kitabı**

Aspose.Slides, harici çalışma kitaplarını grafikler için veri kaynağı olarak kullanmayı destekler.

### **Harici Çalışma Kitabı Oluşturma**

[readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) ve [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) kullanarak gömülü bir grafik çalışma kitabını bir dosyaya dışa aktarabilir ve grafiği bu harici çalışma kitabına bağlayabilirsiniz.

Bu örnek, varsayılan veri ile bir pasta grafiği oluşturur ve çalışma kitabını dışa aktarır. Dosya yazma tamamlandıktan sonra harici çalışma kitabını grafik veri kaynağı olarak atar ve bağlı sunumu kaydeder.

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

### **Harici Çalışma Kitabını Ayarla**

[setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) yöntemiyle bir grafiğe harici bir çalışma kitabı veri kaynağı olarak atayabilirsiniz. Bu yöntem aynı zamanda harici çalışma kitabının yolunu (dosya taşınmışsa) güncellemek için de kullanılabilir.

Uzak konumlardaki veya kaynaklardaki çalışma kitaplarındaki verileri doğrudan düzenleyemezsiniz, ancak bu çalışma kitaplarını harici veri kaynağı olarak kullanabilirsiniz. Harici çalışma kitabı için bir göreli yol sağlanırsa, otomatik olarak tam yola dönüştürülür.

Bu örnek, `Sheet1` adlı çalışma sayfası B1'de bir seri adı, A2:A4'te kategori adları ve B2:B4'te sayısal değerler içeren bir harici çalışma kitabı kullanır. Örnek bir pasta grafiği oluşturur, çalışma kitabını bağlar ve [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) ile A1:B4 aralığını bir seri ve üç kategoriye eşler. Bağlı grafikle sunumu kaydeder.

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

[setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) yönteminin `updateChartData` parametresi, çalışma kitabının yüklenip yüklenmeyeceğini denetler.

* `updateChartData` **False** olduğunda yalnızca çalışma kitabı yolu güncellenir. Grafik verileri hedef çalışma kitabından yüklenmez veya güncellenmez, bu yüzden çalışma kitabı mevcut olmayabilir.
* `updateChartData` **True** olduğunda grafik verileri hedef çalışma kitabından güncellenir.

Aşağıdaki örnek, `updateChartData` **False** olarak ayarlanmış bir yer tutucu URL atar. Pasta grafiğinin varsayılan verileri korunur ve kullanılabilir olmayan çalışma kitabı yüklenmeden sunum kaydedilir.

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

### **Bir Grafiğin Harici Veri Kaynağı Çalışma Kitabı Yolunu Alma**

Bir grafiğin hangi çalışma kitabına bağlandığını belirlemek için, grafiğin harici bir veri kaynağı kullanıp kullanmadığını kontrol edin ve çalışma kitabı yolunu alın.

Bu örnek, harici bir çalışma kitabına bağlı bir grafik içeren bir sunumun ilk slaydındaki ilk şekli inceler. Eğer harici bir çalışma kitabına bağlı bir grafik ise, [getExternalWorkbookPath](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) değerini konsola yazdırır. Ardından sunumun bir kopyasını kaydeder.

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

Harici çalışma kitaplarındaki verileri, iç çalışma kitaplarındaki içerik değişiklikleri gibi düzenleyebilirsiniz. Harici bir çalışma kitabı yüklenemediğinde bir istisna fırlatılır.

Bu örnek, ilk slaydın ilk şekli olarak bir grafik ve erişilebilir bir harici çalışma kitabı içerir. İlk serideki ilk veri noktasının hücre‑tabanlı değerini 100 olarak ayarlar ve güncellenmiş sunumu kaydeder. Hücre değerlerini düzenlemek, bağlanan harici XLSX dosyasını güncelleyebilir; bu yüzden orijinali korumak istiyorsanız bir kopya kullanın.

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

### **Grafik Önbelleğinden Çalışma Kitabını Kurtarma**

Bir grafik, eksik veya kullanılamayan bir harici çalışma kitabı kullandığında, Aspose.Slides sunumdaki önbellekteki verilerden grafik çalışma kitabını yeniden oluşturabilir. [LoadOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/) oluşturun, [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions) çağırın ve [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) `True` olarak ayarlayın, ardından sunumu açın.

Aşağıdaki Python örneği, ilk slaydın ilk şekli olarak bir grafiği ve kullanılamayan bir harici çalışma kitabını referans alan bir senaryoda çalışma kitabı verilerini kurtarır. Kurtarılan verilere [Chart.getChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getChartData) ve [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) üzerinden erişir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

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

        # Burada kurtarılan çalışma kitabı verilerini okuyun veya değiştirin.
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Harici çalışma kitabı kullanılamaz ve kurtarma devre dışı bırakılmışsa Aspose.Slides bir istisna fırlatır. Ön bellek verilerini kullanmak kabul edilebilir bir geri dönüşümse yalnızca kurtarmayı etkinleştirin; önbellek, sunum son güncellendikten sonra harici çalışma kitabında yapılan değişiklikleri içermeyebilir.

## **SSS**

**Belirli bir grafiğin harici mi yoksa gömülü bir çalışma kitabına mı bağlandığını belirleyebilir miyim?**

Evet. Bir grafiğin [veri kaynağı türü](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) ve [harici çalışma kitabı yolu](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) vardır; kaynak harici bir çalışma kitabıysa tam yolu okuyarak bir dış dosyanın kullanıldığını doğrulayabilirsiniz.

**Harici çalışma kitapları için göreli yollar destekleniyor mu ve nasıl depolanıyor?**

Evet. Göreli bir yol belirtirseniz otomatik olarak mutlak yola dönüştürülür. Sunum, mutlak yolu PPTX dosyasında saklar, bu yüzden çalışma kitabı taşındığında bağlantının güncellenmesi gerekebilir.

**Ağ kaynakları/paylaşımları üzerindeki çalışma kitaplarını kullanabilir miyim?**

Evet, bu tür çalışma kitapları harici veri kaynağı olarak kullanılabilir. Ancak, Aspose.Slides'tan uzak çalışma kitaplarını doğrudan düzenlemek desteklenmez; yalnızca kaynak olarak kullanılabilirler.

**Aspose.Slides sunumu kaydederken harici XLSX dosyasını üzerine yazar mı?**

Sunum, harici dosyaya bir [bağlantı](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) saklar. Hücre‑tabanlı grafik verilerini düzenlemek aynı zamanda bağlı yerel XLSX dosyasını da güncelleyebilir. Orijinalin değişmemesi gerekiyorsa çalışma kitabının bir kopyasını kullanın.

**Harici dosya şifre korumalıysa ne yapmalıyım?**

Aspose.Slides bağlanırken bir şifre kabul etmez. Yaygın bir yaklaşım, önceden korumayı kaldırmak ya da bir şifresiz kopya (örneğin, [Aspose.Cells](https://reference.aspose.com/cells/python-java/)) hazırlamaktır ve bu kopyaya bağlanmaktır.

**Birden fazla grafik aynı harici çalışma kitabına referans verebilir mi?**

Evet. Her grafik kendi bağlantısını saklar. Hepsi aynı dosyaya işaret ediyorsa, dosya güncellendiğinde veri bir sonraki yüklemede her grafiğe yansır.