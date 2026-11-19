---
title: "Python'da Sunumlarda Grafik Veri Serilerini Yönetme"
linktitle: "Veri Serileri"
type: docs
url: /tr/python-java/chart-series/
keywords:
- grafik serileri
- seri örtüşmesi
- seri rengi
- seri adı
- veri noktası
- çalışma kitabı hücresi
- seri boşluğu
- negatif değer
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile sunumlarda grafik serilerini, veri noktalarını, çalışma kitabı hücrelerini, biçimlendirmeyi, örtüşmeyi, boşluk genişliğini ve negatif değerleri nasıl yöneteceğinizi öğrenin."
---
## **Genel Bakış**

Bir grafik, çizilen değerlerini çalışma kitabı hücrelerinde veya doğrudan sayısal sabitler olarak saklayabilir. Bir [ChartSeries](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/) bir ilgili değer kümesini temsil eder ve her [ChartDataPoint](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/) bu serideki bir noktayı temsil eder. [ChartCategory](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategory/) nesneleri seriler tarafından paylaşılan etiketleri veya gruplama değerlerini sağlar. Varsayılan verilerle oluşturulan grafiklerde, seri adları, kategoriler ve nokta değerleri grafik çalışma kitabı içindeki [ChartDataCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/) nesneleri kullanılarak tutulur.

Tipik bir kategori grafiği için, varsayılan çalışma kitabı seri adları için satır 0, kategori adları için sütun 0 ve kalan hücreler seri değerleri için kullanır. [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCell) metoduna geçirilen çalışma sayfası, satır ve sütun indisleri sıfır‑tabanlıdır. Bu düzen, varsayılan verilerle bir grafik oluşturduğunuzda kullanışlıdır, ancak mevcut her grafiğin bunu kullandığını varsaymayın. Yüklenmiş bir sunumda, çalışma kitabı değerlerini değiştirmeden önce seriler, kategoriler ve veri noktaları tarafından kullanılan hücreleri inceleyin.

Grafik ayarları üç farklı kapsamda bulunur:

- Bir seriye özgü ayarlar, örneğin [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat), bir serideki tüm noktalar için varsayılan görünümü sağlar.
- Veri‑nokta ayarları, örneğin [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat), bir nokta için serinin görünümünü geçersiz kılar.
- Grup ayarları, aynı [ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/) içinde bulunan uyumlu serilere uygulanır. Örtüşme veya boşluk genişliği gibi seçenekleri ayarlamanız gerektiğinde, [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) üzerinden gruba erişin.

Açık bir nokta ya da seri dolgu ayarı belirlenmemişse, grafik stili ve teması otomatik görünümü belirler. Hem seri hem de nokta biçimlendirmesi mevcutsa, nokta biçimlendirmesi o nokta için önceliklidir.

![grafik-seri-powerpoint](chart-series-powerpoint.png)

Küme silindir grafiği için, [3D seri tipini veya çubuk şekli değiştirme](/slides/tr/python-java/3d-chart/#change-the-3d-series-type-and-bar-shape) ilk seriyi nasıl etkilediğine bakın.

## **Seri Değerlerini Sayısal Sabitlerle Ayarlama**

Seri değerleri uygulama verilerinden veya hesaplamalarından geliyorsa ve çalışma sayfası hücre referansına ihtiyaç duymuyorsa sayısal sabitleri kullanın. Her noktanın [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue) sonucunu [setAsLiteralDouble](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#setAsLiteralDouble) üzerinden atamadan önce [setDataSourceTypeForValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForValues) metodunu [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/#DoubleLiterals) ile çağırın.

Koleksiyon ayarı, serideki tüm nokta değerlerinin kaynak türünü kontrol eder. Her nokta değerinin [getDataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/basechartvalue/#getDataSourceType) metodu seçili türü raporlar; koleksiyon ayarıyla değiştirin. `Worksheet` ile referans alınan hücreye erişmek için [getAsCell](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#getAsCell) kullanın. `DoubleLiterals` ile sayıyı doğrudan okumak veya yazmak için [getAsLiteralDouble](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#getAsLiteralDouble) ya da `setAsLiteralDouble` kullanın.

Aşağıdaki örnek, varsayılan seri ve kategorilere sahip bir sütun grafiği oluşturur, ardından ilk serisinin mevcut noktalarına 10, 20 vb. hesaplanmış değerleri atar. Sunumu kaydeder, yeniden açar ve saklanan değerleri yazdırır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)
    series = chart.getChartData().getSeries().get_Item(0)

    series.getDataPoints().setDataSourceTypeForValues(DataSourceType.DoubleLiterals)
    for i in range(series.getDataPoints().size()):
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10)

    presentation.save("numeric_literals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation("numeric_literals.pptx")
try:
    reopened_slide = reopened_presentation.getSlides().get_Item(0)
    reopened_chart = reopened_slide.getShapes().get_Item(0)
    reopened_series = reopened_chart.getChartData().getSeries().get_Item(0)
    for point in reopened_series.getDataPoints():
        print(point.getValue().getAsLiteralDouble())
finally:
    reopened_presentation.dispose()
```

Nokta değeri kaynak türü, grafiğin iç veya dış çalışma kitabı yapılandırmasını belirleyen [ChartData.getDataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) metodundan ayrı bir özelliktir. Sayısal sabitlerin kullanılması, gömülü çalışma kitabını tek başına kaldırmaz. Bu örnekte, çalışma kitabı hâlâ kategori etiketleri, seri adları ve diğer seriler için kullanılabilir. Çalışma kitabı yönetimi için [Chart Workbook](/slides/tr/python-java/chart-workbook/) sayfasına bakın.

Serpilme ve balon grafiklerinde, [setDataSourceTypeForXValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForXValues) ve [setDataSourceTypeForYValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForYValues) metodları sırasıyla [getXValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getXValue) ve [getYValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getYValue) için kaynak seçer. Balon grafikleri ayrıca [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForBubbleSizes) metodunu [getBubbleSize](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getBubbleSize) için kullanır. Her ilgili kaynağı `DoubleLiterals` olarak ayarlayın, ardından o değerin `setAsLiteralDouble` yöntemiyle sayıyı atayın.

## **Grafik Serisi Örtüşmesini Ayarlama**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getOverlap) 2D bir grafikte çubukların veya kolonların ne kadar örtüştüğünü %-100 ile -100 arasında raporlar. Bu, üst seri grubundaki ayarın salt okunur bir yansımasıdır. Grup içindeki uyumlu tüm serileri güncellemek için [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) metodunu kullanın. Bu seçenek, gruplanmış çubuk veya kolon gösteren grafik tipleri için geçerlidir; birleşik bir grafikte ilgisiz seri gruplarını etkilemez.

Aşağıdaki örnek, ilk seriyi içeren grup için örtüşmeyi ayarlar:

```python
import jpase
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    # Yeni grafik örnek seriler, kategoriler ve değerler içerir.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sonuç:

![Seri örtüşmesi](series_overlap.png)

## **Seri Dolgu Rengini Değiştirme**

Tüm bir seri için varsayılan dolguyu ayarlamak üzere [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat) kullanın. Bir noktanın zaten açık bir dolgusu varsa, onun [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat) ayarı, o nokta için seri dolgusunu geçersiz kılar.

Aşağıdaki örnek, ilk seriye katı mavi bir dolgu uygular:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("series_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sonuç:

![Seri rengi](series_color.png)

## **Seri Adını Değiştirme**

Seri adı grafik veri çalışma kitabında saklanır ve genellikle lejende gösterilir. Küme sütun grafiği için oluşturulan varsayılan çalışma kitabında, B1 hücresi (satır 0, sütun 1) ilk serinin adını içerir. Aşağıdaki örnekteki adlandırılmış değişkenler bu yapıyı açıkça gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
worksheet_index = 0
series_name_row_index = 0
first_series_column_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    workbook = chart.getChartData().getChartDataWorkbook()
    series_name_cell = workbook.getCell(worksheet_index, series_name_row_index, first_series_column_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ayrıca, [ChartSeries.getName](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getName) tarafından zaten referans edilen hücreyi güncelleyebilirsiniz. Bu yaklaşım, mevcut bir grafikte belirli bir satır ve sütun varsayımını ortadan kaldırır:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
first_name_cell_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series_name_cell = series.getName().getAsCells().get_Item(first_name_cell_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sonuç:

![Seri adı](series_name.png)

### **Birden Çok Hücreden Oluşan Seri Adı Oluşturma**

Ürün adı ve raporlama dönemi ayrı çalışma kitabı hücrelerinde tutuluyorsa birleşik bir seri adı faydalı olur. Örneğin, B1 hücresindeki `Product A` ile C1 hücresindeki `2026` değerlerini tek bir seri adı olarak birleştirirken her iki kısmın da kaynak hücrelerine bağlı kalabilirsiniz.

İsim aralığını almak için [ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCellCollection) metodunu kullanın, ardından bu koleksiyonu [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriescollection/#add) metoduna geçirin. `skipHiddenCells` parametresi gizli hücrelerin dahil edilip edilmeyeceğini kontrol eder: `True` gizli hücreleri dışarı bırakır, `False` ise dahil eder. Bu örnek, isim aralığındaki tüm hücreleri dahil etmek için `False` kullanır.

Aşağıdaki örnek, bir seri ve iki veri noktasına sahip bir sunum oluşturur. B1:C1 hücreleri yalnızca seri adını, A2:A3 hücreleri kategori etiketlerini, B2:B3 hücreleri ise sayısal değerleri sağlar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 620, 180)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    chart.setLegend(True)

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    # Bu iki hücre seri adını sağlar.
    workbook.getCell(0, 0, 1, "Product A")
    workbook.getCell(0, 0, 2, "2026")
    name_cells = workbook.getCellCollection("Sheet1!$B$1:$C$1", False)
    series = chart.getChartData().getSeries().add(name_cells, ChartType.ClusteredColumn)

    # Ayrı hücreler kategorileri ve sayısal veri noktalarını sağlar.
    north_category = workbook.getCell(0, 1, 0, "North")
    south_category = workbook.getCell(0, 2, 0, "South")
    chart.getChartData().getCategories().add(north_category)
    chart.getChartData().getCategories().add(south_category)
    north_value = workbook.getCell(0, 1, 1, jpype.JInt(120))
    south_value = workbook.getCell(0, 2, 1, jpype.JInt(150))
    series.getDataPoints().addDataPointForBarSeries(north_value)
    series.getDataPoints().addDataPointForBarSeries(south_value)

    presentation.save("composite_series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Oluşan seri adı `Product A 2026` şeklinde, iki hücre değeri arasına bir boşluk eklenerek elde edilir. Lejende bu, iki sütun için tek bir giriş olarak gösterilir. Aşağıdaki görüntü sonucu gösterir:

![Kuzey ve Güney değerleri ile birleşik seri adı Product A 2026 olan sütun grafiği](composite_series_name.png)

## **Otomatik Seri Dolgu Rengini Alma**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) metodu, seri indeksi ve grafik stiline göre hesaplanan rengi döndürür. Seri dolgu açıkça tanımlanmadığında kullanılan renktir. Metodun çağrılması sadece hesaplanan rengi okur; yeni bir dolgu tanımlamaz.

Aşağıdaki örnek, her varsayılan serinin otomatik rengini yazdırır:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

first_slide_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series_count = chart.getChartData().getSeries().size()
    for series_index in range(series_count):
        series = chart.getChartData().getSeries().get_Item(series_index)
        automatic_color = series.getAutomaticSeriesColor()
        print(f"Series {series_index}: {automatic_color}")
finally:
    presentation.dispose()
```

Varsayılan grafik stili için örnek çıktı:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Kesin renkler grafik stiline ve temaya bağlıdır.

## **Bir Grafik Serisi İçin Negatif Dolgu Rengini Ters Çevirme**

Çubuk, kolon ve balon serileri için, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) yöntemi negatif değerleri farklı bir dolgu ile gösterebilir. Normal seri dolgusunu katı olarak ayarlayın, ters çevirme özelliğini etkinleştirin ve negatif değer rengi için [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) metodunu kullanın. Negatif sayılar çalışma kitabında değişmeden kalır; yalnızca gösterim rengi değişir.

Aşağıdaki örnek, varsayılan grafik verisini tek bir seri ile değiştirir. Çalışma sayfası satır 0 seri adını, sütun 0 kategori adlarını, sütun 1 ise değerleri içerir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
worksheet_index = 0
header_row_index = 0
category_column_index = 0
first_series_column_index = 1
first_data_row_index = 1

category_names = ["Category 1", "Category 2", "Category 3"]
series_values = [-20, 50, -30]

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)
    chart_data = chart.getChartData()
    workbook = chart_data.getChartDataWorkbook()

    chart_data.getSeries().clear()
    chart_data.getCategories().clear()

    series_name_cell = workbook.getCell(worksheet_index, header_row_index, first_series_column_index, "Series 1")
    chart_type = chart.getType()
    series = chart_data.getSeries().add(series_name_cell, chart_type)

    for category_index in range(len(category_names)):
        data_row_index = first_data_row_index + category_index
        category_name = category_names[category_index]
        series_value = series_values[category_index]

        category_cell = workbook.getCell(worksheet_index, data_row_index, category_column_index, category_name)
        chart_data.getCategories().add(category_cell)

        value_cell = workbook.getCell(worksheet_index, data_row_index, first_series_column_index, series_value)
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.setInvertIfNegative(True)
    series.getInvertedSolidFillColor().setColor(Color.RED)

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sonuç:

![Ters çevrilmiş katı dolgu rengi](inverted_solid_fill_color.png)

Bir nokta için ters çevirme, [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) ile etkinleştirilebilir. Aşağıdaki örnekte, seri için ters çevirme devre dışı bırakılır ve yalnızca seçili nokta için etkinleştirilir. Etkiyi görmek için nokta negatif bir değer alır:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0
target_data_point_index = 2
negative_value = -30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.getInvertedSolidFillColor().setColor(Color.RED)
    series.setInvertIfNegative(False)

    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(negative_value)
    data_point.setInvertIfNegative(True)

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Belirli Bir Veri Noktasının Değerini Temizleme**

Diğer noktaları kaldırmadan bir noktayı boş bırakmak için, onun destekleyen çalışma kitabı hücresini `None` olarak ayarlayın. Bir sütun grafiğinde, çizilen değer [ChartDataPoint.getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue) üzerinden elde edilebilir. Veri noktası aynı kategori konumunda kalır, ancak grafik değeri boş olarak değerlendirir ve boş‑değer ayarlarına göre işlenir.

Aşağıdaki örnek, ilk serideki yalnızca ikinci noktayı temizler:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
target_data_point_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(None)

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Serpilme ve balon grafiklerinde X ve Y hücreleri ayrı, balon grafiklerinde ayrıca bir boyut hücresi bulunur. Silmek istediğiniz değeri temsil eden hücreyi yalnızca temizleyin. Diğer noktaları korumak istiyorsanız [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) metodunu çağırmayın; bu metod bütün veri noktalarını koleksiyondan kaldırır.

## **Boş Hücrelerin Görüntülenmesini Kontrol Etme**

Değer içeren gizli hücreler, boş hücrelerden ayrı bir durumdur. Gizli çalışma sayfası satırları ve sütunlarından veri dahil etme veya hariç tutma hakkında bilgi için [Gizli Satır ve Sütunlardan Veri Dahil Etme](/slides/tr/python-java/chart-workbook/#include-data-from-hidden-rows-and-columns) sayfasına bakın.

Boş bir çalışma kitabı hücresi eksik veriyi temsil eder; `0` içeren bir hücre ise bilinen sayısal bir değerdir. Hücreyi boş yapmak için [ChartDataCell.setValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setValue) metodunu `None` ile çağırın. Sayısal sıfır, boş‑hücre ayarından bağımsız olarak sıfır olarak kalır.

Boş hücrelerin grafikte nasıl gösterileceğini seçmek için [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) metodunu kullanın. Bu ayar tüm grafik için geçerlidir ve boşların nasıl çizileceğini belirler; boş hücreyi sıfır ya da ara değerle doldurmaz.

Aşağıdaki bağımsız örnek, bir satır grafiği oluşturur, 3. Gün değerini temizler ve her modda aynı grafiği kaydeder. Giriş dosyasına ihtiyaç yoktur. [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) çalışma sayfası 0, kategori etiketleri için sütun 0 ve değerler için sütun 1 kullanır; satır 0 seri adını tutar. Son veri `10, 20, boş, 30, 40` şeklindedir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayBlanksAsType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 40, 40, 640, 400)
    chart_data = chart.getChartData()
    workbook = chart_data.getChartDataWorkbook()

    chart_data.getSeries().clear()
    chart_data.getCategories().clear()

    series_name_cell = workbook.getCell(0, 0, 1, "Measurements")
    series = chart_data.getSeries().add(series_name_cell, chart.getType())
    values = [10, 20, 25, 30, 40]

    for i, value in enumerate(values):
        category_cell = workbook.getCell(0, i + 1, 0, f"Day {i + 1}")
        chart_data.getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, jpype.JInt(value))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    #     Day 3'ü gerçekten boş bırak, ancak kategorisini ve veri noktasını koru.
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Her çıktı dosyası, kaydedilmeden önce atanan modu dosya adında saklar: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` ve `empty_cells_Span.pptx`. Tek bir sürüm kaydetmek isterseniz, istenen modu atayın ve sunumu bir kez kaydedin.

Aşağıdaki karşılaştırma, üç dosyada aynı veriyi gösterir. Gün 3 her durumda çalışma kitabında boştur:

![Gün 3 boş olan aynı veri: Gap çizgiyi Gün 3’te keser, Zero çizgiyi sıfıra indirebilir, Span ise Gün 2’yi Gün 4’e bağlar.](display_blanks_as.png)

Görünüm etkisi grafik tipine bağlıdır. Çizgi grafiği üç modu da net bir şekilde karşılaştırmaya izin verir. Çubuk ve kolon grafiklerinde eksik bir kategori için bağlayıcı bir çizgi olmadığı için `Span` yukarıdaki gibi bir bağlayıcı segment üretmez; eksik bir kolon ve sıfır‑yükseklikli bir kolon da benzer görünebilir. Benzer şekilde, sadece işaretçilerle bir serpilme grafiği de bağlayıcı çizgi içermez. Her grafik tipinde üç ayrı sonuç beklemeyin; kullandığınız tip için çıktıyı kontrol edin.

## **Seri Boşluk Genişliğini Ayarlama**

Boşluk genişliği, yan yana çubuk veya kolon kümeleri arasındaki boşluktur ve çubuk/kolon genişliğinin yüzdesi olarak ifade edilir. Örtüşme gibi, bu ayar tek bir seriye değil, üst seriler grubuna aittir. Grup için bir kez [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) çağırın. Daha büyük bir değer kümeler arasındaki boşluğu artırır; daha küçük bir değer onları daha sıklaştırır.

Aşağıdaki örnek boşluk genişliğini değiştirir ve yalnızca son sunumu kaydeder:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
gap_width_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setGapWidth(gap_width_percent)

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sonuç:

![Boşluk genişliği](gap_width.png)

## **Seri Çizgilerini Gösterme veya Gizleme**

Seri çizgileri, bir grafiğin ilgili bölümlerini görsel olarak bağlar. Desteklenen yığılmış çubuk ve OfPie grafiklerinde çizgileri göstermek veya gizlemek için [ChartSeriesGroup.setSeriesLines](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setSeriesLines) metodunu kullanın. İki boyutlu yığılmış çubuk ve kolon grafiklerinde, bu çizgiler kategori boyunca karşılık gelen yığın sınırlarını birleştirir. Pie of Pie ve Bar of Pie grafiklerinde, ana grafiği ikincil grafiğe bağlar. Bu ayar, diğer grafik tipleri için genel bir bağlayıcı değildir.

Grup, [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup) üzerinden erişilir. Ayar, grup içindeki her seri için geçerlidir. [ChartSeries.hasSeriesLines](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#hasSeriesLines) sadece salt okunur bir özelliktir ve üst grup ayarını yansıtır; güncellemek için grup ayarlayıcısını çağırın.

Aşağıdaki örnek, varsayılan veriyle bir [PieOfPie](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#PieOfPie) grafiği oluşturur. Grafik iki kez kaydedilir; birinde seri çizgileri etkin, diğerinde devre dışı bırakılır ve karşılaştırma için iki sunum elde edilir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 400)
    series = chart.getChartData().getSeries().get_Item(0)
    series_group = series.getParentSeriesGroup()

    series_group.setSeriesLines(True)
    presentation.save("series_lines_enabled.pptx", SaveFormat.Pptx)

    series_group.setSeriesLines(False)
    presentation.save("series_lines_disabled.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| Seri çizgileri etkin | Seri çizgileri devre dışı |
| --- | --- |
| ![Seri çizgileri etkin Pie of Pie grafiği](series_lines_enabled.png) | ![Seri çizgileri devre dışı Pie of Pie grafiği](series_lines_disabled.png) |
| İki çizgi, ana dilimi ikincil dilime bağlar. | Her iki dilim de görünür, ancak bağlayıcı çizgiler gizlidir. |

Seri çizgileri, veri etiketi kılavuz çizgileri (etiketleri veri noktalarına bağlayan), eksen üzerindeki ızgara çizgileri ve bir çizgi grafiğindeki veri noktalarını gösteren çizgilerden farklıdır. Bu ayar, bu öğeleri kontrol etmez.

## **SSS**

**Hangi grafik tipleri veri serilerini destekler?**

[ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) enum’u ile temsil edilen tüm grafik tipleri veri kullanır, ancak serilerin değer yapısı ve ayarları farklıdır. Örneğin, kategori grafiklerinde kategori ve değer, serpilme grafiklerinde X ve Y değer, balon grafiklerinde ise balon boyutları bulunur. Seri tipine uygun veri‑nokta oluşturma metodunu kullanın. Örtüşme ve boşluk genişliği gibi seçenekler yalnızca uyumlu çubuk veya kolon gruplarına uygulanır.

**Grafik serisi grubu nedir?**

[ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/) aynı grup‑seviye çizim ayarlarını paylaşan uyumlu serileri içerir. Kombinasyon grafiği birden fazla grup içerebilir; bir seriden erişilen grup ayarlarını değiştirmek, grafikteki tüm serileri zorunlu olarak etkilemez.

**Yeni oluşturulan bir grafik varsayılan veri içerir mi?**

Evet. Varsayılan olarak, [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) örnek seriler, kategoriler ve değerler oluşturur. Bu hücreleri düzenleyebilir veya tamamen özel bir veri kümesi eklemeden önce serileri ve kategorileri temizleyebilirsiniz. Bir aşırı yüklü (overload) metodla varsayılan veri olmadan da grafik oluşturulabilir.

**Grafik nesneleri çalışma kitabı hücrelerine nasıl bağlanır?**

Seri adları, kategori etiketleri ve veri‑nokta değerleri bir [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) içindeki hücrelere referans verir. Referans verilen bir hücreyi değiştirmek ilgili grafik öğesini günceller. Özel veri oluştururken, her noktanın doğru kategori altında çizildiğinden emin olmak için kategori satırları ile seri‑değer satırlarını hizalı tutun.

**Bir seriyi değil tek bir noktayı nasıl temizlerim?**

İlgili değer hücresini `None` olarak ayarlayın; böylece nokta aynı kategori konumunda kalır ancak değeri boş olarak işlenir. [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) metodunu sadece serinin tüm noktalarını kaldırmak istediğinizde kullanın; aksi takdirde diğer noktalar silinir.

**Boş noktalar nasıl gösterilir?**

Sonuç, grafik tipine ve [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) ile yapılandırılmış değere bağlıdır. Desteklenen grafikler boşları boşluk, sıfır değeri veya komşu noktaları bağlayarak gösterebilir. Sunumunuzdaki eksik verinin anlamına uygun ayarı seçin. Tam örnek ve görsel karşılaştırma için [Boş Hücrelerin Görüntülenmesini Kontrol Etme](#control-the-display-of-empty-cells) bölümüne bakın.

**Negatif değerler nasıl biçimlendirilir?**

Desteklenen çubuk, kolon ve balon serileri için [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) metodunu çağırın ve [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) tarafından döndürülen rengi ayarlayın. Bireysel bir nokta için davranışı [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) ile geçersiz kılabilirsiniz. Bu yöntemler biçimlendirmeyi etkiler, saklanan sayısal değerleri değil.

**Seri ve nokta aynı anda biçimlendirilmişse hangisi kazanır?**

Açık veri‑nokta biçimlendirmesi o nokta için önceliklidir. Diğer noktalar açık seri biçimlendirmesini ya da seri biçimi tanımlı değilse otomatik grafik stil ve temayı kullanır. Örtüşme ve boşluk genişliği gibi grup ayarları düzeni kontrol eder ve nokta‑seviyesinde bir biçimlendirme geçersizliği oluşturmaz.

**Bir grafiğin içerebileceği seri sayısında bir limit var mı?**

Aspose.Slides ayrı bir sabit seri sayısı limiti getirmez. Pratikte, sunum dosyası kısıtlamaları, kullanılabilir bellek, render süresi ve grafik okunabilirliği faydalı bir sınır belirler.

**Sütunlar çok yakın veya çok uzak olduğunda ne yapılmalı?**

Uygun üst seri grubunda [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) metodunu çağırın. Değeri artırarak kümeler arasındaki boşluğu genişletin, azaltarak kümeleri birbirine yakınlaştırın.