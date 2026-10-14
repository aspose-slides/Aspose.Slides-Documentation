---
title: Python via Java kullanarak Sunumlarda Pasta Grafiklerini Özelleştirme
linktitle: Pasta Grafiği
type: docs
url: /tr/python-java/pie-chart/
keywords:
- pasta grafiği
- grafik yönetimi
- grafik özelleştirme
- grafik seçenekleri
- grafik ayarları
- çizim seçenekleri
- dilim rengi
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides ile Python üzerinden Java kullanarak pasta grafiklerini oluşturun ve özelleştirin. İkincil grafikleri yapılandırın, veri etiketlerini gösterin ve PowerPoint'te otomatik dilim renklerini uygulayın."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde pasta grafikleriyle nasıl çalışılacağını açıklar. Pie of Pie ve Bar of Pie grafikleri için ikincil grafik seçeneklerinin nasıl yapılandırılacağını ve standart bir pasta grafiği için otomatik dilim renklerinin nasıl etkinleştirileceğini gösterir.

Örnekler, bir slayta grafik ekleme, seriler ve etiket ayarlarını düzenleme, varsayılan grafik verilerini özel kategoriler ve değerlerle değiştirme ve güncellenen sunumu kaydetme gibi grafik özelleştirme görevlerine odaklanır.

## **Pie of Pie ve Bar of Pie Grafikleri İçin İkincil Grafik Seçenekleri**

Aspose.Slides for Python via Java, Pie of Pie ve Bar of Pie grafikleri için ikincil grafik seçeneklerini destekler. Bu seçenekler, ikincil grafiğin boyutunu ve veri noktalarının iki grafik arasında nasıl bölündüğünü kontrol eder.

Aşağıdaki örnek, yeni bir sunumda bir Pie of Pie grafiği oluşturur ve veri noktası değerlerini etiket olarak gösterir. [setSecondPieSize](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setSecondPieSize) yöntemi, ikincil grafik boyutunu ana grafiğin %149'una ayarlar. [setPieSplitBy](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitBy) yüzde tabanlı bölmeyi seçer ve [setPieSplitPosition](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) eşik değerini %53 olarak belirler.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400)
    series = chart.getChartData().getSeries().get_Item(0)

    # Değerleri göster ve ikincil grafiği yapılandır.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setSecondPieSize(149)
    series_group.setPieSplitBy(PieSplitType.ByPercentage)
    series_group.setPieSplitPosition(53)

    presentation.save("pie_of_pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **İkincil Grafik İçin Kategorileri Seçin**

Yüzde değerlerinden bağımsız olarak belirli kategorileri ikincil grafikte gruplayarak özel bölme kullanın. Örneğin, bir satış raporu Online ve Events'i birlikte gösterebilir, böylece okuyucular bu iki kanalı karşılaştırabilir; bunlar toplam satışın %35 ve %10'unu oluşturmasına rağmen.

Bu örnekte, [setPieSplitBy](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitBy) yöntemini [PieSplitType.Custom](https://reference.aspose.com/slides/python-java/aspose.slides/piesplittype/#Custom) ile çağırın ve noktaları [getPieSplitCustomPoints](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints) aracılığıyla seçin. Koleksiyonun [add](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#add) yöntemi, seride sıfır tabanlı bir indeks kabul eder; bir veri noktası nesnesi eklemek için [addItem](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#addItem) kullanın. Bu örnekte, indeks 1 Online'ı, indeks 3 ise Events'i seçer. Partners da geçici olarak eklenir ve ardından [removeItem](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#removeItem) kullanılarak çıkarılır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 200)

    # Varsayılan verileri kanal bazında satışlarla değiştir.
    workbook = chart.getChartData().getChartDataWorkbook()
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    category_names = ["Retail", "Online", "Partners", "Events"]
    values = [40, 35, 15, 10]
    series_name_cell = workbook.getCell(0, 0, 1, "Sales")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    for i in range(len(category_names)):
        category_cell = workbook.getCell(0, i + 1, 0, category_names[i])
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, jpype.JInt(values[i]))
        series.getDataPoints().addDataPointForPieSeries(value_cell)

    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setPieSplitBy(PieSplitType.Custom)
    series_group.setColorVaried(True)

    # Online'ı sıfır tabanlı indeks ile ve Events'i veri noktası nesnesiyle seç.
    series_group.getPieSplitCustomPoints().add(1)
    series_group.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3))

    # Partners'ı seçmeden, kaynak verilerini silmeden hariç tut.
    series_group.getPieSplitCustomPoints().add(2)
    series_group.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2))

    presentation.save("pie_of_pie_custom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Online (35) ve Events (10), ikincil grafikte ayrı dilimler olarak görünür. Birincil grafikte, Retail (40) ve Partners (15) ile birlikte 45 değerinde tek bir birleşik dilim olarak temsil edilirler. Partners'ı özel seçimden kaldırmak, onu birincil grafikte tutar; kategoriyi veya değerini grafik kaynak verilerinden kaldırmaz.

Aşağıdaki resim, kaydedilen sunumu PowerPoint'te gösterir:
![İkincil grafikte Online ve Events bulunan Pie of Pie grafiği ve birincil grafikte birleşik 45 değeri](pie_of_pie_custom.png)

## **Pasta Grafiği Dilim Renklerini Otomatik Olarak Ayarlama**

Aspose.Slides for Python via Java, pasta grafiği dilimlerine otomatik olarak farklı renkler atayabilir. Aşağıdaki örnek, ortalanmış bir başlıkla bir pasta grafiği oluşturur ve varsayılan verileri üç çeyrek kategorisi ve değerleriyle değiştirir. [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) yöntemi 20, 50 ve 30 değerlerini etiket olarak gösterirken, [setColorVaried](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setColorVaried) her dilim için ayrı bir renk etkinleştirir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # Ortalanmış bir grafik başlığı ekle.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # İlk çalışma sayfasını kullanarak varsayılan verileri değiştir.
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    category_names = ["First Qtr", "2nd Qtr", "3rd Qtr"]
    values = [20, 50, 30]
    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    for i in range(len(category_names)):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, category_names[i])
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(worksheet_index, i + 1, 1, jpype.JInt(values[i]))
        series.getDataPoints().addDataPointForPieSeries(value_cell)

    # Değerleri göster ve dilimlere farklı renkler ata.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getParentSeriesGroup().setColorVaried(True)

    presentation.save("pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SSS**

**Pie of Pie ve Bar of Pie varyasyonları destekleniyor mu?**

Evet, kütüphane [destekler](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) pasta grafikleri için ikincil bir grafik, Pie of Pie ve Bar of Pie türleri dahil olmak üzere.

**Sadece grafiği bir görüntü (örneğin PNG) olarak dışa aktarabilir miyim?**

Evet, tüm sunumu dışa aktarmadan grafiği bir görüntü (örneğin PNG) olarak [grafiği bir görüntü olarak dışa aktar](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) yapabilirsiniz.