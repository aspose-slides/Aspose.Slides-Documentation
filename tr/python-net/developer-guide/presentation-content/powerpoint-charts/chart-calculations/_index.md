---
title: Python'da Sunumlar İçin Grafik Hesaplamalarını Optimize Et
linktitle: Grafik Hesaplamaları
type: docs
weight: 50
url: /tr/python-net/chart-calculations/
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
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET'de PPT, PPTX ve ODP için grafik hesaplamalarını, veri güncellemelerini ve hassasiyet kontrolünü, pratik kod örnekleriyle anlayın."
---
## **Genel Bakış**

Aspose.Slides, sunumlarda grafik hesaplamaları ve yerleşim verileriyle çalışmak için API’ler sağlar. Bu makale, `ActualLayout` uygulayan öğelerin gerçek konum ve boyutları ile grafik eksenlerinin gerçek değerlerini içeren grafik öğelerinin gerçek değerlerinin nasıl alınacağını gösterir. Ayrıca bu değerlerin grafik yerleşim doğrulamasından sonra doldurulduğunu açıklar.

Ek olarak, makale üst grafik öğelerinin gerçek konumunun nasıl alınacağını ve başlık, eksenler, açıklama ve ızgara çizgileri gibi grafik bileşenlerinin nasıl gizleneceğini göstermektedir. Bu örnekler, grafik yerleşim bilgilerini incelemenize ve PowerPoint sunumlarında grafik öğelerinin görünürlüğünü programlı olarak kontrol etmenize yardımcı olur.

## **Grafik Öğelerinin Gerçek Değerlerini Hesaplama**
Aspose.Slides for Python via .NET, bu özellikleri almanız için basit bir API sunar. Bu, grafik öğelerinin gerçek değerlerini hesaplamanıza yardımcı olur. Gerçek değerler, [IActualLayout](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/iactuallayout/) sınıfını (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) miras alan öğelerin konumlarını ve gerçek eksen değerlerini (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale) içerir.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    maxValue = chart.axes.vertical_axis.actual_max_value
    minValue = chart.axes.vertical_axis.actual_min_value
    majorUnit = chart.axes.horizontal_axis.actual_major_unit
    minorUnit = chart.axes.horizontal_axis.actual_minor_unit
```

## **Üst Grafik Öğelerinin Gerçek Konumunu Hesaplama**
Aspose.Slides for Python via .NET, bu özellikleri almanız için basit bir API sunar. IActualLayout özellikleri, üst grafik öğesinin gerçek konumu hakkında bilgi sağlar. Özelliklerin gerçek değerlerle doldurulması için önceden IChart.ValidateChartLayout() yönteminin çağrılması gerekir.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    x = chart.plot_area.actual_x
    y = chart.plot_area.actual_y
    w = chart.plot_area.actual_width
    h = chart.plot_area.actual_height
```

## **Grafikten Bilgi Gizleme**
Bu konu, grafikten bilginin nasıl gizleneceğini anlamanıza yardımcı olur. Aspose.Slides for Python via .NET kullanarak grafiğin **Başlığını, Dikey Ekseni, Yatay Ekseni** ve **Izgara Çizgilerini** gizleyebilirsiniz. Aşağıdaki kod örneği bu özelliklerin nasıl kullanılacağını gösterir.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 140, 118, 320, 370)

    # Grafiğin Başlığını Gizleme
    chart.has_title = False

    # Değer Eksenini Gizleme
    chart.axes.vertical_axis.is_visible = False

    # Kategori Ekseni Görünürlüğü
    chart.axes.horizontal_axis.is_visible = False

    # Açıklamayı Gizleme
    chart.has_legend = False

    # Ana Izgara Çizgilerini Gizleme
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    #for i in range(len(chart.chart_data.series)):
    #    chart.chart_data.series.remove_at(i)

    series = chart.chart_data.series[0]

    series.marker.symbol = charts.MarkerStyleType.CIRCLE
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.position = charts.LegendDataLabelPosition.TOP
    series.marker.size = 15

    # Seri çizgi rengini ayarlama
    series.format.line.fill_format.fill_type = slides.FillType.SOLID
    series.format.line.fill_format.solid_fill_color.color = draw.Color.purple
    series.format.line.dash_style = slides.LineDashStyle.SOLID

    pres.save("HideInformationFromChart.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Harici Excel çalışma kitapları veri kaynağı olarak kullanılabilir mi ve bu yeniden hesaplamayı nasıl etkiler?**

Evet. Bir grafik harici bir çalışma kitabına başvurabilir: harici kaynağa bağlandığınızda veya yenilediğinizde, formüller ve değerler o çalışma kitabından alınır ve grafik, açık/düzenleme işlemleri sırasında güncellemeleri yansıtır. API, harici çalışma kitabının yolunu [harici çalışma kitabını belirtmenizi](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/set_external_workbook/) ve bağlanan verileri yönetmenizi sağlar.

**Kendi regresyonumu uygulamadan trend çizgilerini hesaplayıp görüntüleyebilir miyim?**

Evet. [Trendlines](/slides/tr/python-net/trend-line/) (doğrusal, üstel ve diğerleri) Aspose.Slides tarafından eklenir ve güncellenir; parametreleri seri verilerinden otomatik olarak yeniden hesaplanır, böylece kendi hesaplamalarınızı uygulamanıza gerek kalmaz.

**Bir sunumda birden fazla grafik harici bağlantılara sahipse, her grafiğin hesaplanan değerler için hangi çalışma kitabını kullandığını kontrol edebilir miyim?**

Evet. Her grafik kendi [harici çalışma kitabına](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdata/set_external_workbook/) işaret edebilir veya diğerlerinden bağımsız olarak grafik başına bir harici çalışma kitabı oluşturup değiştirebilirsiniz.