---
title: Python ile Sunumlarda Grafik Eksenlerini Özelleştirme
linktitle: Grafik Eksenleri
type: docs
url: /tr/python-net/chart-axis/
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
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET'i kullanarak PowerPoint ve OpenDocument sunumlarında raporlar ve görselleştirmeler için grafik eksenlerini nasıl özelleştirebileceğinizi keşfedin."
---
## **Genel Bakış**

Bu makale Aspose.Slides içinde grafik eksenlerini nasıl özelleştireceğinizi açıklar. Gerçek eksen değerlerini elde etmeyi, eksenler arasındaki verileri değiştirmeyi, çizgi grafiklerde dikey ya da yatay ekseni gizlemeyi, kategori ekseni tipini değiştirmeyi, kategori ekseni değerleri için tarih biçimini ayarlamayı, bir eksen başlığını döndürmeyi, eksen konumunu ayarlamayı ve değer ekseninde bir birim etiketi görüntülemeyi gösterir.

## **Grafiklerde Düşey Eksende Azami Değerleri Alma**
Aspose.Slides for Python via .NET, düşey eksende minimum ve maksimum değerleri elde etmenizi sağlar. Aşağıdaki adımları izleyin:

1. Presentation sınıfının bir örneğini oluşturun.
1. İlk slayta erişin.
1. Varsayılan veri ile bir grafik ekleyin.
1. Eksende gerçek azami değeri alın.
1. Eksende gerçek asgari değeri alın.
1. Eksenin gerçek ana birimini alın.
1. Eksenin gerçek alt birimini alın.
1. Eksenin gerçek ana birim ölçeğini alın.
1. Eksenin gerçek alt birim ölçeğini alın.

Bu örnek kod—yukarıdaki adımların bir uygulaması—gereken değerleri Python’da nasıl alacağınızı gösterir:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 100, 100, 500, 350)
	chart.validate_chart_layout()

	maxValue = chart.axes.vertical_axis.actual_max_value
	minValue = chart.axes.vertical_axis.actual_min_value

	majorUnit = chart.axes.horizontal_axis.actual_major_unit
	minorUnit = chart.axes.horizontal_axis.actual_minor_unit
	
	# Sunumu kaydeder
	pres.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Eksenler Arasındaki Verileri Değiştirme**
Aspose.Slides, eksenler arasındaki verileri hızlıca değiştirmenizi sağlar—düşey eksende (y-ekseninde) temsil edilen veriler yatay eksene (x-eksenine) ve tersine taşınır.

Bu Python kodu, bir grafik üzerindeki eksenler arasındaki veri değişimini nasıl yapacağınızı gösterir:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Boş sunum oluşturur
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    #Satır ve sütunları değiştirir
    chart.chart_data.switch_row_column()
            
    # Sunumu kaydeder
    pres.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Çizgi Grafiklerde Dikey Ekseni Devre Dışı Bırakma**

Bu Python kodu, bir çizgi grafik için dikey ekseni nasıl gizleyeceğinizi gösterir:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False
    
    pres.save("chart-is_visible.pptx", slides.export.SaveFormat.PPTX)
```

## **Çizgi Grafiklerde Yatay Ekseni Devre Dışı Bırakma**

Bu kod, bir çizgi grafik için yatay ekseni nasıl gizleyeceğinizi gösterir:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
 
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    pres.save("chart-2.pptx", slides.export.SaveFormat.PPTX)
```

## **Kategori Eksenini Değiştirme**

**CategoryAxisType** özelliğini kullanarak tercih ettiğiniz kategori eksen tipini (**date** veya **text**) belirtebilirsiniz. Bu Python kodu işlemi gösterir:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_automatic_major_unit = False
    chart.axes.horizontal_axis.major_unit = 1
    chart.axes.horizontal_axis.major_unit_scale = charts.TimeUnitType.MONTHS
    presentation.save("ChangeChartCategoryAxis_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Kategori Ekseni Değeri İçin Tarih Biçimini Ayarlama**
Aspose.Slides for Python via .NET, bir kategori ekseni değeri için tarih biçimini ayarlamanızı sağlar. İşlem bu Python kodunda gösterilmiştir:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
from datetime import date

def to_oadate(dt):
    delta = dt - date(1899, 12, 30)
    return delta.days + (delta.seconds + delta.microseconds / 1e6) / (24 * 3600)

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 50, 50, 450, 300)

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    chart.chart_data.categories.add(wb.get_cell(0, "A2", to_oadate(date(2015, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A3", to_oadate(date(2016, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A4", to_oadate(date(2017, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A5", to_oadate(date(2018, 1, 1))))

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B2", 1))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B3", 2))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B4", 3))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B5", 4))
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_number_format_linked_to_source = False
    chart.axes.horizontal_axis.number_format = "yyyy"
    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **Grafik Ekseni Başlığı İçin Dönme Açısını Ayarlama**
Aspose.Slides for Python via .NET, bir grafik ekseni başlığı için dönme açısını ayarlamanızı sağlar. Bu Python kodu işlemi gösterir:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **Kategori veya Değer Ekseninde Konum Eksenini Ayarlama**
Aspose.Slides for Python via .NET, bir kategori veya değer ekseninde konum eksenini ayarlamanızı sağlar. Bu Python kodu görevi nasıl yapacağınızı gösterir:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.horizontal_axis.axis_between_categories = True

	pres.save("AsposeScatterChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Grafik Değer Ekseninde Görüntüleme Birimi Etiketini Etkinleştirme**
Aspose.Slides for Python via .NET, bir grafik değer ekseninde bir birim etiketi gösterilmesini yapılandırmanıza olanak tanır. Bu Python kodu işlemi gösterir:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Bir eksenin diğerini kestiği değeri (ekseni kesişim) nasıl ayarlarım?**

Eksenler bir [crossing setting](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/axis/cross_type/) sağlar: sıfırda, maksimum kategori/değerde ya da belirli bir sayısal değerde kesişmeyi seçebilirsiniz. Bu, X eksenini yukarı ya da aşağı kaydırmak veya bir temel çizgiyi vurgulamak için faydalıdır.

**Tick etiketlerini eksene göre (yan tarafta, dışta, içinde) nasıl konumlandırabilirim?**

[label position](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/axis/major_tick_mark/) **"cross"**, **"outside"** veya **"inside"** olarak ayarlayın. Bu, okunurluğu etkiler ve özellikle küçük grafiklerde alan tasarrufu sağlar.