---
title: Python'da Sunumlarda Grafik Veri Serilerini Yönetme
linktitle: Veri Serileri
type: docs
url: /tr/python-java/chart-series/
keywords:
- grafik serisi
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

Bir grafik, çizilen verilerini bir grafik veri çalışma kitabında saklar. Bir [ChartSeries](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseries/) bir grup ilgili değeri temsil eder ve serideki her [ChartDataPoint](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdatapoint/) bir veya daha fazla çalışma kitabı hücresine başvurur. [ChartCategory](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartcategory/) nesneleri, seri tarafından paylaşılan etiketleri veya grup değerlerini sağlar. Serinin adı, kategoriler ve nokta değerleri bu nedenle yalnızca görüntü metni olarak saklanmak yerine [ChartDataCell](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdatacell/) nesnelerine bağlanır.

Tipik bir kategori grafiği için, varsayılan çalışma kitabı satır 0'ı seri adları için, sütun 0'ı kategori adları için ve kalan hücreleri seri değerleri için kullanır. [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdataworkbook/#getCell) metoduna geçirilen çalışma sayfası, satır ve sütun indeksleri sıfır bazlıdır. Bu düzen, varsayılan veri ile bir grafik oluşturduğunuzda yararlıdır, ancak mevcut her grafiğin bunu kullandığını varsaymayın. Yüklenmiş bir sunum için, çalışma kitabı değerlerini değiştirmeden önce seriler, kategoriler ve veri noktaları tarafından başvurulan hücreleri inceleyin.

Grafik ayarları üç farklı kapsamda bulunur:

- Serie seviyesindeki ayarlar, örneğin [ChartSeries.getFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseries/#getFormat), bir serideki tüm noktalar için varsayılan görünümü sağlar.
- Veri noktası ayarları, örneğin [ChartDataPoint.getFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdatapoint/#getFormat), bir nokta için seri görünümünü geçersiz kılar.
- Grup ayarları, aynı [ChartSeriesGroup](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseriesgroup/) dahiline ait uyumlu serilere uygulanır. Örtüşme veya boşluk genişliği gibi seçenekleri ayarlamanız gerektiğinde gruba [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseries/#getParentSeriesGroup) üzerinden erişin.

Açık bir nokta veya seri doldurması ayarlanmamışsa, grafik stili ve teması otomatik görünümü belirler. Hem seri hem de nokta biçimlendirmesi mevcut olduğunda, nokta biçimlendirmesi o nokta için öncelikli olur.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Grafik Serisi Örtüşmesini Ayarlama**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseries/#getOverlap) 2B bir grafikte çubukların veya sütunların ne kadar örtüştüğünü -%100 ila %100 arasında rapor eder. Bu, üst seriler grubundaki ayarın yalnızca okunabilir bir yansımasıdır. Bu gruptaki tüm uyumlu serileri güncellemek için [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseriesgroup/#setOverlap) kullanın. Bu seçenek, gruplanmış çubuk veya sütun gösteren grafik türlerine uygulanır; kombinasyon grafiğindeki alakasız seri gruplarını etkilemez.

Aşağıdaki örnek, ilk seriyi içeren grup için örtüşmeyi ayarlar:

```python
import jpype
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

## **Seri Doldurma Rengini Değiştir**

Bir bütün seri için varsayılan doldurmayı ayarlamak için [ChartSeries.getFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseries/#getFormat) kullanın. Bir noktanın zaten açık bir doldurması varsa, onun [ChartDataPoint.getFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdatapoint/#getFormat) ayarı seri doldurmasını o nokta için geçersiz kılar.

Aşağıdaki örnek, ilk seriye katı mavi bir doldurma uygular:

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

![Serinin rengi](series_color.png)

## **Seri Adını Değiştir**

Bir seri adı, grafik veri çalışma kitabında saklanır ve genellikle lejende gösterilir. Küme sütun grafiği için oluşturulan varsayılan çalışma kitabında, B1 hücresi satır 0, sütun 1'de bulunur ve ilk serinin adını içerir. Aşağıdaki örnekteki adlandırılmış değişkenler bu yapıyı açıkça gösterir:

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

Ayrıca, [ChartSeries.getName](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseries/#getName) tarafından zaten başvurulan hücreyi güncelleyebilirsiniz. Bu yaklaşım, mevcut bir grafikte belirli bir satır ve sütun varsayımını önler:

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

## **Otomatik Seri Doldurma Rengini Al**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) seri indeksinden ve grafik stilinden hesaplanan rengi döndürür. Bu, seri doldurması açıkça tanımlanmadığında kullanılan renktir. Metodu çağırmak, hesaplanan rengi okur; yeni bir doldurma atamaz.

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

Tam renkler grafik stiline ve temaya bağlıdır.

## **Bir Grafik Serisi için Ters Doldurma Rengini Ayarla**

Çubuk, sütun ve baloncuk serileri için, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseries/#setInvertIfNegative) negatif değerleri farklı bir doldurmaya sahip gösterebilir. Normal seri doldurmasını katı olarak ayarlayın, terslemeyi etkinleştirin ve negatif değer rengini [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) aracılığıyla atayın. Negatif sayılar çalışma kitabında değişmez; yalnızca görüntü rengi değişir.

Aşağıdaki örnek, varsayılan grafik verilerini bir seriyle değiştirir. Çalışma sayfası satırı 0 seri adını, sütun 0 kategori adlarını ve sütun 1 değerleri içerir:

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

![Ters katı doldurma rengi](inverted_solid_fill_color.png)

Bir nokta için terslemeyi [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) aracılığıyla etkinleştirebilirsiniz. Aşağıdaki örnekte, seri için tersleme devre dışı bırakılmış ve yalnızca seçilen nokta için etkinleştirilmiştir. Etkinin görünür olması için noktaya negatif bir değer de atanmıştır:

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

## **Belirli Bir Veri Noktası Değerini Temizle**

Diğer noktaları kaldırmadan bir noktayı boş yapmak için, ilgili çalışma kitabı hücresini `None` olarak ayarlayın. Bir sütun grafiği için çizilen değer [ChartDataPoint.getValue](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdatapoint/#getValue) üzerinden elde edilir. Veri noktası aynı kategori konumunda kalır, ancak grafik, boş değer ayarlarına göre değerini boş olarak işler.

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

Saçılım grafiklerinde ayrı X ve Y hücreleri, baloncuk grafiklerinde ise bir boyut hücresi kullanılır. Kaldırmak istediğiniz değeri temsil eden hücreyi yalnızca temizleyin. Diğer noktaları korumak istediğinizde [ChartDataPointCollection.clear](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdatapointcollection/#clear) çağırmayın; çünkü bu yöntem koleksiyondaki tüm veri noktalarını kaldırır.

## **Boş Hücrelerin Görüntülenmesini Kontrol Et**

Boş bir çalışma kitabı hücresi eksik veriyi temsil eder; `0` içeren bir hücre bilinen sayısal bir değeri temsil eder. Bir hücreyi boş yapmak için [ChartDataCell.setValue](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdatacell/#setValue) metodunu `None` ile çağırın. Sayısal sıfır, boş hücre ayarına bakılmaksızın sıfır olarak kalır.

[Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chart/#setDisplayBlanksAs) kullanarak grafiğin boş hücreleri nasıl göstereceğini seçin. Bu ayar tüm grafik için geçerlidir. Boşlukların nasıl çizileceğini değiştirir, boş çalışma kitabı hücresini sıfır veya ara bir değerle doldurmaz.

Aşağıdaki bağımsız örnek, bir seri ile bir çizgi grafik oluşturur, Gün 3 için değeri temizler ve aynı grafiği her modda kaydeder. Girdi dosyasına ihtiyaç yoktur. [ChartDataWorkbook](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdataworkbook/) çalışma sayfası 0, kategori etiketleri için sütun 0 ve değerler için sütun 1 kullanır; satır 0 seri adını tutar. Son veri `10, 20, boş, 30, 40` dir.

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

    # Gün 3'ü gerçekten boş bırakın, fakat kategori ve veri noktasını koruyun.
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Her çıktı dosyası, kaydetmeden önce atanan modu saklar: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` ve `empty_cells_Span.pptx`. Tek bir versiyonu kaydetmek için, istediğiniz modu atayın ve sunumu bir kez kaydedin; modlar arasında döngü yapmayın.

Aşağıdaki karşılaştırma, aynı veriyi üç dosyada gösterir. Gün 3 her durumda çalışma kitabında boştur:

![Aynı veriye sahip çizgi grafikler: Gap, Gün 3'te çizgiyi kırar, Zero, çizgiyi sıfıra düşürür, Span ise Gün 2'yi Gün 4'e bağlar.](display_blanks_as.png)

Görünür etki grafik türüne bağlıdır. Çizgi grafiği, üç modu da karşılaştırmayı kolaylaştırır. Çubuk ve sütun grafiklerinde eksik bir kategori arasında bağlayacak bir çizgi olmadığından, `Span` yukarıda gösterilen bağlayıcı segmenti oluşturamaz; eksik bir sütun ile sıfır yükseklikteki bir sütun da benzer görünebilir. Benzer şekilde, yalnızca işaretleyicileri olan bir saçılım grafiğinde de bağlayıcı çizgi yoktur. Her grafik türü için üç ayrı sonuç beklemeyin; kullandığınız tür için çıktıyı kontrol edin.

## **Seri Boşluk Genişliğini Ayarla**

Boşluk genişliği, yan yana çubuk veya sütun kümeleri arasındaki boşluk olup, çubuk veya sütun genişliğinin yüzdesi olarak ifade edilir. Örtüşme gibi, tek bir seriye değil üst seri grubuna aittir. Grup için bir kez [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseriesgroup/#setGapWidth) çağırın. Daha büyük bir değer kümeler arasındaki boşluğu artırır; daha küçük bir değer onları daha yoğun yapar.

Aşağıdaki örnek, boşluk genişliğini değiştirir ve yalnızca son sunumu kaydeder:

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

## **SSS**

**Hangi grafik türleri veri serilerini destekler?**

[ChartType] sayımı tarafından temsil edilen tüm grafik türleri grafik verisi kullanır, ancak serileri aynı değer yapısına veya ayarlara sahip değildir. Örneğin, kategori grafikleri kategori ve değerler, saçılım grafikleri X ve Y değerleri, baloncuk grafikleri ise baloncuk boyutları kullanır. Seri tipine uygun veri noktası oluşturma yöntemini kullanın. Örtüşme ve boşluk genişliği gibi seçenekler yalnızca uyumlu çubuk veya sütun gruplarına uygulanır.

**Bir grafik seri grubu nedir?**

[ChartSeriesGroup] grup düzeyindeki çizim ayarlarını paylaşan uyumlu serileri içerir. Bir kombinasyon grafiği birden fazla grup içerebilir, bu yüzden bir seriden erişilen grup değiştirilse bile grafikteki tüm seriler mutlaka değişmez.

**Yeni oluşturulan bir grafik varsayılan veri içerir mi?**

Evet. Varsayılan olarak, [ShapeCollection.addChart] örnek seriler, kategoriler ve değerler oluşturur. Bu hücreleri düzenleyebilir veya tamamen özelleştirilmiş bir veri kümesi eklemeden önce serileri ve kategori koleksiyonlarını temizleyebilirsiniz. Bir aşırı yükleme, varsayılan veri olmadan da bir grafik oluşturabilir.

**Grafik nesneleri çalışma kitabı hücrelerine nasıl bağlanır?**

Seri adları, kategori etiketleri ve veri noktası değerleri bir [ChartDataWorkbook] içindeki hücrelere başvurur. Başvurulan bir hücreyi değiştirmek ilgili grafik öğesini günceller. Özelleştirilmiş veri oluştururken, her noktanın istenen kategori altında çizildiğinden emin olmak için kategori satırları ve seri‑değer satırlarını hizalı tutun.

**Tüm seriyi değil tek bir noktayı nasıl temizlerim?**

İlgili değer hücresini `None` olarak ayarlayarak noktanın kategori konumunu boş bir nokta olarak koruyun. [ChartDataPointCollection.clear] metodunu yalnızca o seriden tüm noktaları kaldırmak istediğinizde kullanın. Kategorileri de kaldırıyorsanız, değerlerin kategori koleksiyonuyla hizalı kalması için tüm serileri güncelleyin.

**Boş noktalar nasıl görüntülenir?**

Sonuç, grafik türüne ve [Chart.setDisplayBlanksAs] üzerinden yapılandırılan değere bağlıdır. Desteklenen grafikler boşlukları boşluklar, sıfır değerler veya komşu noktaları bağlayarak gösterebilir. Sunumunuzdaki eksik verinin anlamına uygun ayarı seçin. Tam bir örnek ve görsel karşılaştırma için [Boş Hücrelerin Görüntülenmesini Kontrol Et](#control-the-display-of-empty-cells) bölümüne bakın.

**Negatif değerler nasıl biçimlendirilir?**

Desteklenen çubuk, sütun ve baloncuk serileri için, [ChartSeries.setInvertIfNegative] metodunu çağırın ve [ChartSeries.getInvertedSolidFillColor] tarafından döndürülen rengi ayarlayın. Bireysel bir nokta için davranışı [ChartDataPoint.setInvertIfNegative] ile geçersiz kılabilirsiniz. Bu yöntemler biçimlendirmeyi etkiler, depolanan sayısal değerleri etkilemez.

**Bir seri ve bir nokta aynı anda biçimlendirildiğinde hangi biçimlendirme kazanır?**

Açık veri noktası biçimlendirmesi o nokta için önceliklidir. Diğer noktalar açık seri biçimini ya da seri biçimi tanımlı değilse otomatik grafik stilini ve temayı kullanmaya devam eder. Örtüşme ve boşluk genişliği gibi grup ayarları düzeni kontrol eder ve nokta seviyesindeki biçimlendirme geçersizliği değildir.

**Bir grafiğin içerebileceği seri sayısı için bir limit var mı?**

Aspose.Slides ayrı bir sabit seri sayısı limiti getirmez. Pratikte, sunum dosyası kısıtlamaları, mevcut bellek, render süresi ve grafik okunabilirliği kullanılabilir bir sınırlamayı belirler.

**Sütunlar çok yakın veya çok uzak olduğunda neyi değiştirmeliyim?**

Uygun üst seri grubunda [ChartSeriesGroup.setGapWidth] metodunu çağırın. Değeri artırarak kümeler arasındaki boşluğu genişletebilir, azaltarak kümeleri birbirine daha yakın hâle getirebilirsiniz.