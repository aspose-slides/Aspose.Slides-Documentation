---
title: Sunumlarda Python ile Grafik Veri Serilerini Yönetme
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
description: "Aspose.Slides for Python via Java kullanarak sunumlarda grafik serilerini, veri noktalarını, çalışma kitabı hücrelerini, biçimlendirmeyi, örtüşmeyi, boşluk genişliğini ve negatif değerleri nasıl yöneteceğinizi öğrenin."
---
## **Genel Bakış**

Bir grafik, çizilen verilerini bir chart data workbook içinde saklar. Bir [ChartSeries](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseries/) ilgili değerlerin bir setini temsil eder ve serideki her bir [ChartDataPoint](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdatapoint/) bir veya daha fazla çalışma sayfası hücresine refere eder. [ChartCategory](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartcategory/) nesneleri, seriler tarafından paylaşılan etiketleri veya gruplama değerlerini sağlar. Serinin adı, kategoriler ve nokta değerleri bu nedenle yalnızca görüntü metni olarak saklanmaz, [ChartDataCell](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdatacell/) nesnelerine bağlanır.

Tipik bir kategori grafiği için, varsayılan çalışma kitabı satır 0'ı seri adları için, sütun 0'ı kategori adları için ve kalan hücreleri seri değerleri için kullanır. [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdataworkbook/#getCell) metoduna gönderilen çalışma sayfası, satır ve sütun indisleri sıfır‑tabanlıdır. Bu düzen, varsayılan verilerle bir grafik oluşturduğunuzda yararlıdır, ancak her mevcut grafiğin bunu kullandığını varsaymayın. Yüklenmiş bir sunumda, çalışma kitabı değerlerini değiştirmeden önce seriler, kategoriler ve veri noktaları tarafından referans edilen hücreleri inceleyin.

Grafik ayarlarının üç farklı kapsamı vardır:

- Seri‑düzeyindeki ayarlar, örneğin [ChartSeries.getFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseries/#getFormat), bir serideki tüm noktalar için varsayılan görünümü sağlar.
- Veri‑nokta ayarları, örneğin [ChartDataPoint.getFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdatapoint/#getFormat), bir nokta için seri görünümünü geçersiz kılar.
- Grup ayarları, aynı [ChartSeriesGroup](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseriesgroup/) içinde bulunan uyumlu serilere uygulanır. Örtüşme veya açıklık genişliği gibi seçenekleri ayarlamanız gerektiğinde, [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseries/#getParentSeriesGroup) üzerinden grup erişimi sağlayın.

Açıkça bir nokta ya da seri dolgusu ayarlanmamışsa, grafik stili ve teması otomatik görünüme karar verir. Hem seri hem de nokta biçimlendirmesi mevcutsa, nokta biçimlendirmesi o nokta için önceliklidir.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Grafik Serisi Örtüşmesini Ayarlama**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseries/#getOverlap) bir 2D grafikte çubukların veya kolonların ne kadar örtüştüğünü -%100 ile %100 arasında raporlar. Bu, üst serinin grup ayarının yalnızca okunabilen bir yansımasıdır. O grup içindeki tüm uyumlu serileri güncellemek için [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseriesgroup/#setOverlap) kullanın. Bu seçenek, gruplanmış çubuk veya kolon gösteren grafik türlerine uygulanır; birleşik bir grafikteki ilgili olmayan seriler grubunu etkilemez.

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

    # Yeni grafik örnek serileri, kategorileri ve değerleri içerir.
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

Tüm bir seri için varsayılan dolgu ayarlamak amacıyla [ChartSeries.getFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseries/#getFormat) kullanın. Bir nokta zaten açıkça bir dolgu tanımlamışsa, onun [ChartDataPoint.getFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdatapoint/#getFormat) ayarı, o nokta için seri dolgusunu geçersiz kılar.

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

Seri adı grafik veri çalışma kitabında saklanır ve genellikle açıklamada gösterilir. Kümeleme sütun grafiği için oluşturulan varsayılan çalışma kitabında, B1 hücresi satır 0, sütun 1 konumunda olup ilk serinin adını içerir. Aşağıdaki örnekteki adlandırılmış değişkenler bu yapıyı açıkça ortaya koyar:

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

Ayrıca, [ChartSeries.getName](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseries/#getName) tarafından zaten referans edilen hücreyi güncelleyebilirsiniz. Bu yaklaşım, mevcut bir grafikte belirli bir satır ve sütun varsayımından kaçınır:

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

## **Otomatik Seri Dolgu Rengini Alma**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) metodu, seri indeksine ve grafik stiline göre hesaplanan rengi döndürür. Bu, seri dolgusu açıkça tanımlanmamışsa kullanılan renktir. Metod, hesaplanan rengi okur; yeni bir dolgu atamaz.

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

## **Bir Grafik Serisi için Ters Çevrilmiş Dolgu Rengini Ayarlama**

Çubuk, sütun ve baloncuk serileri için [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseries/#setInvertIfNegative) negatif değerleri farklı bir dolgu ile gösterebilir. Normal seri dolgusunu katı olarak ayarlayın, ters çevirme özelliğini etkinleştirin ve negatif değer rengi için [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) metodunu kullanın. Negatif sayılar çalışma kitabında değişmeden kalır; yalnızca gösterim rengi değişir.

Aşağıdaki örnek, varsayılan grafik verisini tek bir seri ile değiştirir. Çalışma sayfasının satır 0'ı seri adını, sütun 0'ı kategori adlarını, sütun 1'i değerleri barındırır:

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

Bir nokta için ters çevirme, [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) ile etkinleştirilebilir. Aşağıdaki örnekte, ters çevirme seri için devre dışı bırakılmış ve yalnızca seçili nokta için etkinleştirilmiştir. Etkiyi göstermek amacıyla nokta da negatif bir değer alır:

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

Diğer noktaları kaldırmadan bir noktayı boş bırakmak için, onun temel çalışma kitabı hücresini `None` yapın. Bir sütun grafiğinde, çizilen değer [ChartDataPoint.getValue](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdatapoint/#getValue) üzerinden alınabilir. Veri noktası aynı kategori konumunda kalır, ancak grafik boş‑değer ayarlarına göre değeri boş olarak işler.

Aşağıdaki örnek, ilk serideki sadece ikinci noktayı temizler:

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

Dağılım grafikleri ayrı X ve Y hücreleri, baloncuk grafikler ise ek bir boyut hücresi kullanır. Kaldırmak istediğiniz değeri temsil eden hücreyi yalnızca temizleyin. Diğer noktaları korumak istediğinizde [ChartDataPointCollection.clear](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdatapointcollection/#clear) metodunu çağırmayın; bu yöntem serideki tüm veri noktalarını siler.

## **Boş Hücrelerin Görüntülenmesini Kontrol Etme**

Değer içeren gizli hücreler, boş hücrelerden farklı bir durumdur. Gizli çalışma sayfası satırları ve sütunlarından veri dahil etme/etmeme hakkında bilgi için **[Include Data from Hidden Rows and Columns](/slides/tr/python-java/chart-workbook/#include-data-from-hidden-rows-and-columns)** bölümüne bakın.

Boş bir çalışma kitabı hücresi eksik veriyi temsil eder; `0` içeren bir hücre bilinen sayısal bir değeri temsil eder. Bir hücreyi boş yapmak için [ChartDataCell.setValue](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdatacell/#setValue) metoduna `None` gönderin. Sayısal sıfır, boş‑hücre ayarından bağımsız olarak sıfır kalır.

Grafiğin boş hücreleri nasıl göstereceğini seçmek için [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chart/#setDisplayBlanksAs) metodunu kullanın. Bu ayar tüm grafik için geçerlidir ve boşların nasıl çizileceğini belirler; boş hücreyi sıfır ya da ara bir değerle doldurmaz.

Aşağıdaki bağımsız örnek, bir çizgi grafiği oluşturur, 3. Gün değerini temizler ve her modda aynı grafiği kaydeder. Giriş dosyasına ihtiyaç yoktur. [ChartDataWorkbook](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdataworkbook/) çalışma sayfası 0, sütun 0 kategori etiketleri, sütun 1 değerler; satır 0 seri adı içerir. Son veri `10, 20, empty, 30, 40` şeklindedir.

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

    # 3. günü gerçekten boş bırakın, ancak kategorisini ve veri noktasını koruyun.
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Her çıktı dosyası, kaydetmeden önce seçilen modu ismiyle saklar: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` ve `empty_cells_Span.pptx`. Tek bir sürüm kaydetmek isterseniz, istediğiniz modu ayarlayıp sunumu bir kez kaydedin; tüm modlar üzerinden yineleme yapmayın.

Aşağıdaki karşılaştırma, aynı verinin üç dosyadaki görüntüsünü gösterir. 3. Gün her durumda çalışma kitabında boştur:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Görünür etki grafik türüne bağlıdır. Çizgi grafiği üç modu da kolayca karşılaştırır. Çubuk ve sütun grafikleri eksik bir kategori üzerinden bir çizgi bağlayamaz; bu yüzden `Span` yukarıdaki gibi bir bağlayıcı segment üretemez; eksik bir sütun ve sıfır‑yükseklikli bir sütun da benzer görünebilir. Benzer şekilde, yalnızca işaretçileri olan dağılım grafiğinde de bağlayıcı çizgi yoktur. Her grafik türü için üç ayrı sonuç beklemeyin; kullandığınız türdeki çıktıyı kontrol edin.

## **Seri Boşluk Genişliğini Ayarlama**

Boşluk genişliği, yan yana çubuk veya kolon kümeleri arasındaki boşluk olup, çubuk ya da kolon genişliğinin yüzde olarak ifadesidir. Örtüşme gibi, bu da tek bir seriye değil, üst serinin grup ayarına aittir. Grup için bir kez [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseriesgroup/#setGapWidth) çağırın. Daha büyük bir değer kümeler arasına daha fazla boşluk ekler; daha küçük bir değer onları daha yoğun hâle getirir.

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

## **SSS**

**Hangi grafik türleri veri serilerini destekler?**

[ChartType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/charttype/) enumʼu ile temsil edilen tüm grafik türleri veri içerir, ancak serilerinin değer yapısı veya ayarları aynı değildir. Örneğin, kategori grafikleri kategori ve değer, dağılım grafikleri X ve Y değer, baloncuk grafikleri ise baloncuk boyutları kullanır. Seri tipine uygun veri‑nokta oluşturma yöntemini kullanın. Örtüşme ve boşluk genişliği gibi seçenekler yalnızca uyumlu çubuk veya sütun gruplarına uygulanır.

**Grafik serisi grubu nedir?**

[ChartSeriesGroup](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseriesgroup/) aynı grup‑düzeyinde çizim ayarlarını paylaşan uyumlu serileri içerir. Bir birleşik grafik birden fazla grup barındırabilir; bir seri üzerinden erişilen grup ayarını değiştirmek, grafikteki tüm serileri zorunlu olarak etkilemez.

**Yeni oluşturulan bir grafik varsayılan veri içerir mi?**

Evet. Varsayılan olarak, [ShapeCollection.addChart](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/#addChart) örnek seriler, kategoriler ve değerler oluşturur. Bu hücreleri düzenleyebilir ya da tamamen özelleştirilmiş bir veri seti eklemeden önce serileri ve kategori koleksiyonlarını temizleyebilirsiniz. Bir aşırı yükleme (overload) varsayılan veri olmadan da grafik oluşturabilir.

**Grafik nesneleri çalışma kitabı hücrelerine nasıl bağlanır?**

Seri adları, kategori etiketleri ve veri‑nokta değerleri bir [ChartDataWorkbook](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdataworkbook/) içinde hücrelere refere eder. Referans verilen bir hücreyi değiştirmek, ilgili grafik öğesini günceller. Özel veri oluştururken, her noktanın istenen kategori altında çizilmesi için kategori satırları ile seri‑değer satırlarını hizalı tutun.

**Bir seriyi değil tek bir noktayı nasıl temizlerim?**

İlgili değer hücresini `None` yaparak noktanın kategori konumunu boş bir nokta olarak tutun. [ChartDataPointCollection.clear](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdatapointcollection/#clear) metodunu yalnızca serideki tüm noktaları kaldırmak istediğinizde kullanın. Kategorileri de kaldırıyorsanız, her serinin değerlerini kategori koleksiyonuyla hizalı tutmak için tüm serileri güncelleyin.

**Boş noktalar nasıl gösterilir?**

Sonuç, grafik türüne ve [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chart/#setDisplayBlanksAs) üzerinden yapılandırılan değere bağlıdır. Desteklenen grafikler boşları boşluk, sıfır değeri ya da komşu noktaları bağlayarak gösterebilir. Sunumunuzdaki eksik verinin anlamına en uygun ayarı seçin. Tam bir örnek ve görsel karşılaştırma için **[Control the Display of Empty Cells](#control-the-display-of-empty-cells)** bölümüne bakın.

**Negatif değerler nasıl biçimlendirilir?**

Desteklenen çubuk, sütun ve baloncuk serileri için [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseries/#setInvertIfNegative) metodunu çağırın ve [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) metodundan dönen rengi ayarlayın. Bireysel bir nokta için davranışı [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) ile geçersiz kılabilirsiniz. Bu yöntemler biçimlendirmeyi etkiler, saklanan sayısal değerleri değiştirmez.

**Seri ve nokta aynı anda biçimlendirilirse hangisi kazanır?**

Açıkça belirtilen veri‑nokta biçimlendirmesi o nokta için önceliklidir. Diğer noktalar ya açık seri biçimini ya da seri biçimi tanımlı değilse otomatik grafik stil ve temayı kullanır. Örtüşme ve boşluk genişliği gibi grup ayarları yerleşimi kontrol eder ve nokta‑düzeyinde bir biçimlendirme geçersiz kılmaz.

**Bir grafiğin içerebileceği seri sayısında bir sınırlama var mı?**

Aspose.Slides ayrı bir sabit seri‑sayısı sınırı getirmez. Uygulamada, sunum dosyasının sınırlamaları, mevcut bellek, işleme süresi ve grafiğin okunabilirliği pratik bir sınır belirler.

**Sütunlar çok yakın ya da çok uzak olduğunda ne yapılmalı?**

Uygun üst seri grubunda [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseriesgroup/#setGapWidth) metodunu çağırın. Değeri artırarak kümeler arasındaki boşluğu genişletin, azaltarak kümeleri birbirine yaklaştırın.