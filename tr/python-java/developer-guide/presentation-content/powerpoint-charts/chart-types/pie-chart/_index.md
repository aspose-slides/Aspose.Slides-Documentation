---
title: Python via Java Kullanarak Sunumlarda Pasta Grafiklerini Özelleştirme
linktitle: Pasta Grafik
type: docs
url: /tr/python-java/pie-chart/
keywords:
- pasta grafik
- grafik yönetin
- grafiği özelleştirin
- grafik seçenekleri
- grafik ayarları
- grafik çizim seçenekleri
- dilim rengi
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Python via Java ile Aspose.Slides kullanarak pasta grafikler oluşturmayı ve özelleştirmeyi öğrenin, PowerPoint'e aktarılabilir, verilerinizi saniyeler içinde anlatımını güçlendirir."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde pasta grafikleriyle nasıl çalışılacağını açıklar. Pie of Pie ve Bar of Pie grafikleri için ikincil çizim seçeneklerini nasıl yapılandıracağınızı ve standart bir pasta grafik için otomatik dilim renklendirmeyi nasıl etkinleştireceğinizi gösterir.

Örnekler, bir slayta grafik ekleme, seri ve etiket ayarlarını düzenleme, varsayılan grafik verilerini özel kategoriler ve değerlerle değiştirme ve güncellenen sunumu kaydetme gibi pratik grafik özelleştirme adımlarına odaklanır.

## **Pie of Pie ve Bar of Pie Grafikleri için İkinci Çizim Seçenekleri**

Aspose.Slides for Python via Java, Pie of Pie ve Bar of Pie grafikleri için ikinci çizim seçeneklerini destekler. Bu bölüm, bu seçenekleri Aspose.Slides kullanarak nasıl belirteceğinizi gösterir. Aşağıdaki adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) nesnesi oluşturun.
1. Slayta bir grafik ekleyin.
1. Grafiğin ikinci çizim seçeneklerini belirtin.
1. Sunumu diske yazın.

Aşağıdaki örnek, bir Pie of Pie grafiğinin farklı özelliklerini ayarlar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

# Presentation sınıfının bir örneğini oluşturun.
presentation = Presentation()
try:
    # Slayta bir grafik ekleyin.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400)

    # Farklı özellikleri ayarlayın.
    series = chart.getChartData().getSeries().get_Item(0)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setSecondPieSize(149)
    series_group.setPieSplitBy(PieSplitType.ByPercentage)
    series_group.setPieSplitPosition(53)

    # Sunumu diske yazın.
    presentation.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Otomatik Pasta Grafik Dilim Renklerini Ayarlama**

Aspose.Slides for Python via Java, otomatik pasta grafik dilim renklerini ayarlamak için basit bir API sağlar. Aşağıdaki örnek, bu ayarların nasıl uygulanacağını gösterir.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İlk slayta erişin.
1. Varsayılan veriyle bir grafik ekleyin.
1. Grafik başlığını ayarlayın.
1. Grafik veri çalışma sayfasının dizinini ayarlayın.
1. Grafik veri çalışma kitabını alın.
1. Varsayılan serileri ve kategorileri silin.
1. Yeni kategoriler ekleyin.
1. Yeni bir seri ekleyin.
1. Yeni serinin değerleri göstermesini ayarlayın.

Değiştirilmiş sunumu bir PPTX dosyasına yazın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

# Presentation sınıfının bir örneğini oluşturun.
presentation = Presentation()
try:
    # Varsayılan veriyle bir grafik ekleyin.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # Grafik başlığını ayarlayın.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Grafik veri çalışma sayfasının dizinini ayarlayın.
    default_worksheet_index = 0

    # Grafik veri çalışma kitabını alın.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Varsayılan serileri ve kategorileri silin.
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # Yeni kategoriler ekleyin.
    first_category_cell = workbook.getCell(0, 1, 0, "First Qtr")
    chart.getChartData().getCategories().add(first_category_cell)
    second_category_cell = workbook.getCell(0, 2, 0, "2nd Qtr")
    chart.getChartData().getCategories().add(second_category_cell)
    third_category_cell = workbook.getCell(0, 3, 0, "3rd Qtr")
    chart.getChartData().getCategories().add(third_category_cell)

    # Yeni bir seri ekleyin.
    series_cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_cell, chart.getType())

    # Seri verilerini doldurun.
    first_value_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForPieSeries(first_value_cell)
    second_value_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForPieSeries(second_value_cell)
    third_value_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForPieSeries(third_value_cell)

    # Yeni serinin değerleri göstermesini ayarlayın.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    series.getParentSeriesGroup().setColorVaried(True)
    presentation.save("Pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SSS**

**'Pie of Pie' ve 'Bar of Pie' varyasyonları destekleniyor mu?**

Evet, kütüphane, 'Pie of Pie' ve 'Bar of Pie' tipleri dahil olmak üzere pasta grafikler için ikincil bir çizimi [destekler](https://reference.aspose.com/slides/tr/python-java/aspose.slides/charttype/).

**Grafiği yalnızca bir görüntü olarak (örneğin PNG) dışa aktarabilir miyim?**

Evet, tüm sunumu dışarı almadan grafiği doğrudan bir görüntü (örneğin PNG) olarak [dışa aktarabilirsiniz](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/#getImage).