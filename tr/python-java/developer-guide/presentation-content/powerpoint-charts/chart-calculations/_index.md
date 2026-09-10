---
title: Python via Java ile Sunumlar İçin Grafik Hesaplamalarını Optimize Edin
linktitle: Grafik Hesaplamaları
type: docs
weight: 50
url: /tr/python-java/chart-calculations/
keywords:
- grafik hesaplamaları
- grafik öğeleri
- öğe konumu
- gerçek konum
- alt öğe
- üst öğe
- grafik değerleri
- gerçek değer
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java'da PPT ve PPTX için grafik hesaplamalarını, veri güncellemelerini ve hassasiyet kontrolünü, pratik Python kod örnekleriyle anlayın."
---
## **Genel Bakış**

Aspose.Slides, sunumlarda grafik hesaplamaları ve yerleşim verileriyle çalışmak için API'ler sağlar. Bu makale, grafik öğelerinin gerçek konum ve boyutları ile grafik eksenlerinin gerçek değerleri dahil olmak üzere, grafik öğelerinin gerçek değerlerini nasıl alacağınızı gösterir. Ayrıca bu değerlerin grafik yerleşim doğrulamasından sonra doldurulduğunu açıklar.

Ayrıca makale, üst grafik öğelerinin gerçek konumunu nasıl alacağınızı ve başlık, eksenler, lejand ve ızgara çizgileri gibi grafik bileşenlerini nasıl gizleyeceğinizi gösterir. Birlikte, bu örnekler grafik yerleşim bilgilerini incelemenize ve PowerPoint sunumlarında grafik öğelerinin görünürlüğünü programlı olarak kontrol etmenize yardımcı olur.

## **Grafik Öğelerinin Gerçek Değerlerini Hesapla**
Aspose.Slides for Python via Java, bu özellikleri elde etmek için basit bir API sağlar. [Axis](https://reference.aspose.com/slides/tr/python-java/aspose.slides/axis/) sınıfının yöntemleri, grafik eksenlerinin gerçek değerleri hakkında bilgi verir ([getActualMaxValue](https://reference.aspose.com/slides/tr/python-java/aspose.slides/axis/#getActualMaxValue), [getActualMinValue](https://reference.aspose.com/slides/tr/python-java/aspose.slides/axis/#getActualMinValue), [getActualMajorUnit](https://reference.aspose.com/slides/tr/python-java/aspose.slides/axis/#getActualMajorUnit), [getActualMinorUnit](https://reference.aspose.com/slides/tr/python-java/aspose.slides/axis/#getActualMinorUnit), [getActualMajorUnitScale](https://reference.aspose.com/slides/tr/python-java/aspose.slides/axis/#getActualMajorUnitScale), [getActualMinorUnitScale](https://reference.aspose.com/slides/tr/python-java/aspose.slides/axis/#getActualMinorUnitScale)). Bu özellikleri gerçek değerlerle doldurmak için önce [Chart.validateChartLayout](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chart/#validateChartLayout) metodunu çağırın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getHorizontalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getHorizontalAxis().getActualMinorUnit()
finally:
    presentation.dispose()
```

## **Üst Grafik Öğelerinin Gerçek Konumunu Hesapla**
Aspose.Slides for Python via Java, bu özellikleri elde etmek için basit bir API sağlar. [ChartPlotArea](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartplotarea/) sınıfının yöntemleri, grafik çizim alanının gerçek konum ve boyutu hakkında bilgi verir ([getActualX](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartplotarea/#getActualX), [getActualY](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartplotarea/#getActualY), [getActualWidth](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartplotarea/#getActualWidth), [getActualHeight](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartplotarea/#getActualHeight)). Bu özellikleri gerçek değerlerle doldurmak için önce [Chart.validateChartLayout](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chart/#validateChartLayout) metodunu çağırın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350)
    chart.validateChartLayout()

    x = chart.getPlotArea().getActualX()
    y = chart.getPlotArea().getActualY()
    width = chart.getPlotArea().getActualWidth()
    height = chart.getPlotArea().getActualHeight()
finally:
    presentation.dispose()
```

## **Grafik Öğelerini Gizle**
Bu bölüm, bir grafikten bilgileri nasıl gizleyeceğinizi açıklar. Aspose.Slides for Python via Java kullanarak **Başlık, Dikey Eksen, Yatay Eksen** ve **Izgara Çizgileri**ni gizleyebilirsiniz. Aşağıdaki kod örneği bu özelliklerin nasıl kullanılacağını gösterir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LegendDataLabelPosition, LineDashStyle, MarkerStyleType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370)

    # Grafik başlığını gizle.
    chart.setTitle(False)

    # Değer eksenini gizle.
    chart.getAxes().getVerticalAxis().setVisible(False)

    # Kategori eksenini gizle.
    chart.getAxes().getHorizontalAxis().setVisible(False)

    # Lejandı gizle.
    chart.setLegend(False)

    # Ana ızgara çizgilerini gizle.
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    # Yalnızca ilk seriyi tut. Sondan kaldırmak kalan indekslerin geçerli kalmasını sağlar.
    series_collection = chart.getChartData().getSeries()
    while series_collection.size() > 1:
        series_collection.removeAt(series_collection.size() - 1)

    series = series_collection.get_Item(0)

    series.getMarker().setSymbol(MarkerStyleType.Circle)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.Top)
    series.getMarker().setSize(15)

    # Serinin çizgi rengini ayarla.
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid)

    presentation.save("HideInformationFromChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SSS**

**Harici Excel çalışma kitapları veri kaynağı olarak çalışıyor mu ve bu yeniden hesaplamayı nasıl etkiler?**

Evet. Bir grafik dış bir çalışma kitabına başvurabilir: dış kaynağa bağlandığınızda veya yenilediğinizde, formüller ve değerler o çalışma kitabından alınır ve grafik, açma/düzenleme işlemleri sırasında güncellemeleri yansıtır. API, dış çalışma kitabının yolunu [specify the external workbook](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdata/#setExternalWorkbook) belirlemenize ve bağlanan verileri yönetmenize olanak tanır.

**Regresyonu kendim uygulamadan trend çizgilerini hesaplayıp görüntüleyebilir miyim?**

Evet. [Trendlines](/slides/tr/python-java/trend-line/) (doğrusal, üstel ve diğerleri) Aspose.Slides tarafından eklenir ve güncellenir; parametreleri seri verilerinden otomatik olarak yeniden hesaplanır, böylece kendi hesaplamalarınızı uygulamanız gerekmez.

**Bir sunumda birden fazla grafik dış bağlantılarla bulunuyorsa, her bir grafiğin hesaplanan değerler için hangi çalışma kitabını kullandığını kontrol edebilir miyim?**

Evet. Her grafik, kendi [external workbook](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdata/#setExternalWorkbook) referansına sahip olabilir veya diğerlerinden bağımsız olarak grafik başına bir dış çalışma kitabı oluşturup değiştirebilirsiniz.