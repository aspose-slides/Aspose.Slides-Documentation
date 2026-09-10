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
description: "Aspose.Slides for Python via Java ile sunumlarda grafik serileri, veri noktaları, çalışma kitabı hücreleri, biçimlendirme, örtüşme, boşluk genişliği ve negatif değerleri nasıl yöneteceğinizi öğrenin."
---
## **Genel Bakış**

Bir grafik, çizilen verilerini bir grafik veri çalışma kitabında saklar. Bir [ChartSeries](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseries/) bir değer kümesini temsil eder ve serideki her bir [ChartDataPoint](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdatapoint/) bir veya daha fazla çalışma kitabı hücresine başvurur. [ChartCategory](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartcategory/) nesneleri, seriler tarafından paylaşılan etiketleri veya gruplama değerlerini sağlar. Serinin adı, kategoriler ve nokta değerleri bu nedenle yalnızca görüntü metni olarak depolanmak yerine [ChartDataCell](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdatacell/) nesnelerine bağlanır.

Tipik bir kategori grafiği için, varsayılan çalışma kitabı satır 0’ı seri adları, sütun 0’ı kategori adları ve kalan hücreleri seri değerleri için kullanır. [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdataworkbook/#getCell) yöntemine geçirilen sayfa, satır ve sütun indeksleri sıfır‑tabanlıdır. Bu düzen, varsayılan veriyle bir grafik oluşturduğunuzda kullanışlıdır, ancak mevcut her grafiğin bunu kullandığını varsaymayın. Yüklenmiş bir sunum için, çalışma kitabı değerlerini değiştirmeden önce seriler, kategoriler ve veri noktaları tarafından başvurulan hücreleri inceleyin.

Grafik ayarlarının üç farklı kapsamı vardır:

- Seri‑düzeyi ayarlar, örneğin [ChartSeries.getFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseries/#getFormat), bir serideki tüm noktalar için varsayılan görünümü belirler.
- Veri‑noktası ayarları, örneğin [ChartDataPoint.getFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdatapoint/#getFormat), bir nokta için seri görünümünü geçersiz kılar.
- Grup ayarları, aynı [ChartSeriesGroup](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseriesgroup/) içinde bulunan uyumlu serilere uygulanır. Örtüşme veya boşluk genişliği gibi seçenekleri ayarlamanız gerektiğinde, grup üzerinden [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseries/#getParentSeriesGroup) erişin.

Açık bir nokta ya da seri doldurma rengi ayarlanmamışsa, grafik stili ve teması otomatik görünümü belirler. Hem seri hem de nokta biçimlendirmesi mevcutsa, nokta biçimlendirmesi o nokta için önceliklidir.

![grafik-seri-powerpoint](chart-series-powerpoint.png)

## **Grafik Serisi Örtüşmesini Ayarlama**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseries/#getOverlap), 2B bir grafikte çubuklar veya sütunların ne kadar örtüştüğünü %‑100 ile -100 arasında raporlar. Bu, üst‑seri grubundaki ayarın salt okunur bir yansımasıdır. Aynı gruptaki tüm uyumlu serileri güncellemek için [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseriesgroup/#setOverlap) kullanın. Bu seçenek, gruplanmış çubuk veya sütun gösteren grafik türlerine uygulanır; birleşik bir grafikteki ilişkili olmayan seri gruplarını etkilemez.

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

## **Seri Dolgu Rengini Değiştirme**

Tüm bir seri için varsayılan dolgu ayarlamak üzere [ChartSeries.getFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseries/#getFormat) kullanın. Bir nokta zaten açık bir dolguye sahipse, o noktanın [ChartDataPoint.getFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdatapoint/#getFormat) ayarı seri dolgusunu geçersiz kılar.

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

Bir seri adı grafik veri çalışma kitabında saklanır ve genellikle lejende gösterilir. Küme sütun grafiği için oluşturulan varsayılan çalışma kitabında, B1 hücresi (satır 0, sütun 1) ilk serinin adını içerir. Aşağıdaki örnekteki isimlendirilmiş değişkenler bu yapıyı açıkça gösterir:

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

Ayrıca [ChartSeries.getName](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseries/#getName) tarafından zaten başvurulan hücreyi güncelleyebilirsiniz. Bu yaklaşım, mevcut bir grafikte belirli bir satır ve sütun varsayımından kaçınır:

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

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) yöntemi, seri indeksi ve grafik stilinden hesaplanan rengi döndürür. Bu, seri doldurması açıkça tanımlanmamışsa kullanılan renktir. Yöntemi çağırmak hesaplanan rengi okur; yeni bir dolgu atamaz.

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

## **Bir Grafik Serisi için Ters Dolgu Rengini Ayarlama**

Çubuk, sütun ve balon serileri için, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseries/#setInvertIfNegative) negatif değerleri farklı bir dolgu ile gösterebilir. Normal seri dolgusunu katı olarak ayarlayın, terslemeyi etkinleştirin ve negatif değer rengi için [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) kullanın. Negatif sayılar çalışma kitabında değişmeden kalır; yalnızca görüntü rengi değişir.

Aşağıdaki örnek, varsayılan grafik verisini tek bir seriyle değiştirir. Sayfa satır 0 seri adını, sütun 0 kategori adlarını ve sütun 1 değerleri içerir:

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

![Ters katı dolgu rengi](inverted_solid_fill_color.png)

Bir nokta için terslemeyi [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) ile etkinleştirebilirsiniz. Aşağıdaki örnekte, tersleme seri için devre dışı bırakılır ve yalnızca seçili nokta için etkinleştirilir. Etkiyi göstermek için nokta aynı zamanda negatif bir değer alır:

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

## **Belirli Bir Veri Noktası Değerini Temizleme**

Bir noktayı diğerlerini kaldırmadan boş bırakmak için, arka plan hücresini `None` olarak ayarlayın. Bir sütun grafiği için, çizilen değer [ChartDataPoint.getValue](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdatapoint/#getValue) yöntemiyle elde edilir. Veri noktası aynı kategori konumunda kalır, ancak grafik boş‑değer ayarlarına göre değeri boş kabul eder.

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

Dağılım grafiklerinde X ve Y hücreleri ayrı, balon grafiklerinde ayrıca bir boyut hücresi bulunur. Kaldırmak istediğiniz değeri temsil eden hücreyi yalnızca temizleyin. Diğer noktaları korumak istediğinizde [ChartDataPointCollection.clear](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdatapointcollection/#clear) çağırmayın; bu yöntem koleksiyondaki tüm veri noktalarını siler.

## **Seri Boşluk Genişliğini Ayarlama**

Boşluk genişliği, yan yana çubuk ya da sütun kümeleri arasındaki boşluk olup, çubuk ya da sütun genişliğinin yüzdesi olarak ifade edilir. Örtüşme gibi, bu ayar da bir seriye değil, üst‑seri grubuna aittir. Grup için bir kez [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseriesgroup/#setGapWidth) çağırın. Daha büyük bir değer kümeler arasındaki boşluğu artırır; daha küçük bir değer onları daha sıkıştırır.

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

[ChartType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/charttype/) enum’u tarafından temsil edilen tüm grafik türleri veri kullanır, ancak serileri aynı değer yapısına veya ayarlara sahip değildir. Örneğin, kategori grafikleri kategori ve değer kullanırken, dağılım grafikleri X ve Y değerlerini, balon grafikleri ise balon boyutlarını ekler. Seri tipine uygun veri‑nokta oluşturma yöntemini kullanın. Örtüşme ve boşluk genişliği gibi seçenekler yalnızca uyumlu çubuk ya da sütun gruplarına uygulanır.

**Grafik serisi grubu nedir?**

[ChartSeriesGroup](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseriesgroup/) aynı grup‑düzeyi çizim ayarlarını paylaşan uyumlu serileri içerir. Bir birleşik grafikte birden fazla grup bulunabilir; bir seriden ulaşarak grup ayarlarını değiştirmek, grafikteki diğer serileri zorunlu olarak etkilemez.

**Yeni oluşturulan bir grafik varsayılan veri içerir mi?**

Evet. Varsayılan olarak, [ShapeCollection.addChart](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/#addChart) örnek seriler, kategoriler ve değerler oluşturur. Bu hücreleri düzenleyebilir veya tamamen özelleştirilmiş bir veri kümesi eklemeden önce serileri ve kategori koleksiyonlarını temizleyebilirsiniz. Bir aşırı yükleme, varsayılan veri olmadan da grafik oluşturabilir.

**Grafik nesneleri çalışma kitabı hücrelerine nasıl bağlanır?**

Seri adları, kategori etiketleri ve veri‑nokta değerleri, bir [ChartDataWorkbook](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdataworkbook/) içinde hücrelere başvurur. Başvurulan bir hücreyi değiştirmek ilgili grafik unsurunu günceller. Özel veri oluştururken, her noktanın hedef kategori altında çizildiğinden emin olmak için kategori satırları ile serinin değer satırlarını hizalı tutun.

**Bir seriyi değil, yalnızca bir noktayı nasıl temizlerim?**

İlgili değer hücresini `None` olarak ayarlayın; böylece noktanın kategori konumu boş bir nokta olarak kalır. [ChartDataPointCollection.clear](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdatapointcollection/#clear) yalnızca o seriden tüm noktaları kaldırmak istediğinizde kullanılmalıdır. Kategorileri de kaldırıyorsanız, her serinin değerlerini kategori koleksiyonuyla hizalı tutacak şekilde güncelleyin.

**Boş noktalar nasıl gösterilir?**

Sonuç, grafik türüne ve [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chart/#setDisplayBlanksAs) aracılığıyla yapılandırılan değere bağlıdır. Desteklenen grafikler, boşları boşluk olarak, sıfır değeri olarak ya da komşu noktaları birleştirerek gösterebilir. Sunumunuzdaki eksik verinin anlamına en uygun ayarı seçin.

**Negatif değerler nasıl biçimlendirilir?**

Desteklenen çubuk, sütun ve balon serileri için [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseries/#setInvertIfNegative) çağırın ve [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) tarafından döndürülen rengi ayarlayın. Bireysel bir nokta için terslemeyi [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) ile geçersiz kılabilirsiniz. Bu yöntemler biçimlendirmeyi etkiler; saklanan sayısal değerleri değiştirmez.

**Seri ve nokta aynı anda biçimlendirilirse hangisi geçerli olur?**

Açık veri‑nokta biçimlendirmesi o nokta için önceliklidir. Diğer noktalar, seri için açık bir format tanımlıysa o formatı, tanımlı değilse otomatik grafik stili ve temasını kullanır. Örtüşme ve boşluk genişliği gibi grup ayarları düzeni kontrol eder ve nokta‑düzeyinde bir biçimlendirme geçersiz kılma değildir.

**Bir grafikte kaç seri bulunabilir?**

Aspose.Slides ayrı bir seri sayısı sınırı getirmaz. Pratikte, sunum dosyası kısıtlamaları, kullanılabilir bellek, render süresi ve grafik okunabilirliği faydalı bir sınır belirler.

**Sütunlar çok yakın ya da çok uzakta olduğunda ne değiştirilmelidir?**

Uygun üst‑seri grubu üzerinde [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseriesgroup/#setGapWidth) çağırın. Değeri artırmak kümeler arasındaki boşluğu genişletir, azaltmak ise kümeleri birbirine yaklaştırır.