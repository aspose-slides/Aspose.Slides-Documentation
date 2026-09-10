---
title: Python Kullanarak Sunumlarda Grafik Eksenlerini Özelleştirme
linktitle: Grafik Ekseni
type: docs
url: /tr/python-java/chart-axis/
keywords:
- grafik ekseni
- dikey eksen
- yatay eksen
- eksen özelleştirme
- eksen manipülasyonu
- eksen yönetimi
- eksen özellikleri
- azami değer
- asgari değer
- eksen çizgisi
- tarih biçimi
- eksen başlığı
- eksen konumu
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Raporlar ve görselleştirmeler için PowerPoint sunumlarında grafik eksenlerini özelleştirmek amacıyla Aspose.Slides for Python via Java kullanımını keşfedin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde grafik eksenlerini nasıl özelleştireceğinizi açıklar. Gerçek eksen değerlerini alma, eksenler arasındaki verileri değiştirme, çizgi grafiklerde dikey veya yatay ekseni gizleme, kategori eksen tipini değiştirme, kategori eksen değerleri için tarih biçimini ayarlama, eksen başlığını döndürme, eksen konumunu ayarlama ve değer ekseninin gösterim birimini ayarlama konularını gösterir.

## **Bir Grafik İçin Dikey Eksende Azami Değerleri Alın**

Aspose.Slides for Python via Java, dikey bir eksende minimum ve maksimum değerleri elde etmenizi sağlar. Aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İlk slayta erişin.
1. Varsayılan veriyle bir grafik ekleyin.
1. Eksen üzerindeki gerçek azami değeri alın.
1. Eksen üzerindeki gerçek asgari değeri alın.
1. Eksenin gerçek ana birimini alın.
1. Eksenin gerçek ikincil birimini alın.
1. Eksenin gerçek ana birim ölçeğini alın.
1. Eksenin gerçek ikincil birim ölçeğini alın.

Bu örnek kod—yukarıdaki adımların bir uygulaması—gerekli değerleri Python’da nasıl alacağınızı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getVerticalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getVerticalAxis().getActualMinorUnit()

    major_unit_scale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale()
    minor_unit_scale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale()

    # Sunumu kaydeder
    presentation.save("MaxValuesVerticalAxis_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Eksenler Arasındaki Verileri Değiştirin**

Aspose.Slides, eksenler arasındaki verileri hızlıca değiştirmenizi sağlar—dikey eksende (y-eksen) temsil edilen veri yatay eksene (x-eksen) ve tersine taşınır.

Bu Python kodu, bir grafikte eksenler arasındaki veri değişimini nasıl yapacağınızı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300)

    # Grafiğin varsayılan verilerini çalışma kitabına yükler — switchRowColumn çalışma kitabını transpoze eder,
    # bu yüzden önce doldurulması gerekir
    workbook = chart.getChartData().getChartDataWorkbook()

    # Satırları ve sütunları değiştirir
    chart.getChartData().switchRowColumn()

    # Sunumu kaydeder
    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Çizgi Grafiklerde Dikey Ekseni Devre Dışı Bırakın**

Bu Python kodu, bir çizgi grafik için dikey ekseni nasıl gizleyeceğinizi gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getVerticalAxis().setVisible(False)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Çizgi Grafiklerde Yatay Ekseni Devre Dışı Bırakın**

Bu kod, bir çizgi grafik için yatay ekseni nasıl gizleyeceğinizi gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getHorizontalAxis().setVisible(False)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Kategori Eksenini Değiştirin**

[setCategoryAxisType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/axis/#setCategoryAxisType) metodunu kullanarak tercih edilen kategori ekseni tipinizi (**date** veya **text**) belirtebilirsiniz. Bu Python kodu işlemi göstermektedir:

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Presentation, Chart, SaveFormat, CategoryAxisType, TimeUnitType

presentation = Presentation("ExistingChart.pptx")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getShapes().size() > 0:
        chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        if isinstance(chart, Chart):
            chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
            chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(False)
            chart.getAxes().getHorizontalAxis().setMajorUnit(1)
            chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months)
            presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx)
        else:
            print("The first shape is not a chart.")
    else:
        print("The presentation has no first shape to update.")
finally:
    presentation.dispose()
```

## **Kategori Eksen Değerleri İçin Tarih Biçimini Ayarlayın**

Aspose.Slides for Python via Java, bir kategori eksen değeri için tarih biçimini ayarlamanıza olanak tanır. İşlem bu Python kodunda gösterilmiştir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType

from datetime import datetime

def convert_to_oa_date(date):
    base_date = datetime(1899, 12, 30)
    return (date - base_date).total_seconds() / 86400


presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 50, 50, 450, 300)

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()
    category_date = datetime(2015, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A2", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2016, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A3", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2017, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A4", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2018, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A5", category_value)
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    value_cell = workbook.getCell(0, "B2", 1.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B3", 2.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B4", 3.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B5", 4.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Grafik Ekseni Başlığı İçin Döndürme Açısını Ayarlayın**

Aspose.Slides for Python via Java, bir grafik ekseni başlığı için döndürme açısını ayarlamanıza izin verir. Bu Python kodu işlemi gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Kategori veya Değer Ekseni Üzerinde Ekseni Konumlandırın**

Aspose.Slides for Python via Java, bir kategori veya değer ekseni üzerindeki eksen konumunu ayarlamanıza olanak sağlar. Bu Python kodu görevi nasıl gerçekleştireceğinizi gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Grafik Değer Ekseni Üzerinde Görüntüleme Birimini Ayarlayın**

Aspose.Slides for Python via Java, bir grafik değer ekseninin gösterim birimini ayarlamanıza izin verir. Ekseni bu birime göre işaret etiketlerini ölçeklendirir: [DisplayUnitType.Millions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/displayunittype/#Millions) ile 60.000.000’a kadar uzanan bir eksen 0‑60 olarak etiketlenir. Bu Python kodu işlemi gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, DisplayUnitType

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SSS**

**Bir eksenin diğerini kestiği değeri (eks kesişmesi) nasıl ayarlarım?**

Eksenler bir [crossing setting](https://reference.aspose.com/slides/tr/python-java/aspose.slides/axis/#setCrossType) sunar: sıfırda, maksimum kategori/değerde veya belirli bir sayısal değerde kesişmeyi seçebilirsiniz. Bu, X‑eksenini yukarı veya aşağı kaydırmak veya bir temel çizgiyi vurgulamak için yararlıdır.

**İşaretçileri eksene göre (kesişme, dış, iç) nasıl konumlandırırım?**

[Tick mark position](https://reference.aspose.com/slides/tr/python-java/aspose.slides/axis/#setMajorTickMark) ayarını "cross", "outside" veya "inside" olarak belirleyin. Bu, okunabilirliği etkiler ve özellikle küçük grafiklerde alan tasarrufu sağlar.