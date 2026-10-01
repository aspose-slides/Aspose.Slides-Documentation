---
title: Python ile Sunumlarda Grafik Eksenlerini Özelleştirme
linktitle: Grafik Eksenleri
type: docs
url: /tr/python-net/chart-axis/
keywords:
- grafik ekseni
- dikey eksen
- yatay eksen
- eksen özelleştir
- eksen manipüle et
- eksen yönet
- eksen özellikleri
- maksimum değer
- minimum değer
- eksen çizgisi
- tarih biçimi
- eksen başlığı
- eksen konumu
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Rapor ve görselleştirmeler için PowerPoint ve OpenDocument sunumlarında grafik eksenlerini özelleştirmek amacıyla .NET üzerinden Python için Aspose.Slides kullanımını keşfedin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Python via .NET ile grafik eksenlerini nasıl özelleştireceğinizi açıklar. Hesaplanan eksen değerleri, grafik satır ve sütunlarının değiştirilmesi, eksen görünürlüğü, kategori etiketi ve işaretleme aralıkları, tarih kategorileri ve biçimlendirme, başlık döndürmesi, eksen konumlandırması ve gösterim birimlerini kapsar.

## **Grafiklerde Dikey Eksen Üzerindeki Maksimum Değerleri Alın**

Varsayılan verilerle bir [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) oluşturun ve bir alan grafiği ekleyin. Hesaplanan eksen değerlerini okumadan önce grafik düzeninin güncel olması için [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) metodunu çağırın.

[actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) ve [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) yöntemlerini eksen sınırları için, [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) ve [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) yöntemlerini ise işaret aralıkları için okuyun. [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) ve [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) zaman birimi ölçeklerini sağlar; bu ölçekler tarih eksenleri için geçerlidir. Örnek, bu değerleri yerel değişkenlerde saklar ve grafiği kaydeder.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.AREA, 100, 100, 500, 350)
    chart.validate_chart_layout()

    max_value = chart.axes.vertical_axis.actual_max_value
    min_value = chart.axes.vertical_axis.actual_min_value

    major_unit = chart.axes.vertical_axis.actual_major_unit
    minor_unit = chart.axes.vertical_axis.actual_minor_unit

    major_unit_scale = chart.axes.vertical_axis.actual_major_unit_scale
    minor_unit_scale = chart.axes.vertical_axis.actual_minor_unit_scale

    presentation.save("AxisValues_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Eksenler Arasındaki Verileri Değiştirin**

Grafik verilerinde seri ve kategorilerin rollerini değiştirmek için [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) metodunu kullanın. Her eski kategori bir seri, her eski seri bir kategori haline gelir. Bu, verilerin nasıl gruplanacağını değiştirir; yatay ve dikey eksenleri değiştirmez. Örnek, varsayılan verileri `Sheet1!A1:D5` aralığına (başlık satırı ve kategori sütunu dahil) bağlamak için [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) metodunu kullanır, ardından satır ve sütunları değiştirir. Dört seri ve üç kategori içeren bir grafik kaydeder.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    chart.chart_data.set_range("Sheet1!A1:D5")
    chart.chart_data.switch_row_column()

    presentation.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Çizgi Grafiklerinde Dikey Eksen'i Devre Dışı Bırakın**

Dikey eksende [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) özelliğini `False` olarak ayarlayarak gizleyin. Örnek, varsayılan verilerle bir çizgi grafiği oluşturur ve dikey ekseni gizlenmiş olarak kaydeder.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False

    presentation.save("HiddenVerticalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Çizgi Grafiklerinde Yatay Eksen'i Devre Dışı Bırakın**

Yatay eksende [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) özelliğini `False` olarak ayarlayarak gizleyin. Örnek, varsayılan verilerle bir çizgi grafiği oluşturur ve yatay ekseni gizlenmiş olarak kaydeder.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    presentation.save("HiddenHorizontalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Kategori Eksenini Değiştirin**

[category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) özelliğini ayarlayarak tarih veya metin kategori ekseni seçin. Bu örnek, ilk slayttaki ilk şekil olarak bir grafik içeren `ExistingChart.pptx` dosyasını gerektirir ve kategori hücreleri sayısal Excel tarih değerleri içerir. Yatay ekseni tarih ekseni olarak değiştirir. [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) özelliğini `False`, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) özelliğini `1` ve [major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) özelliğini aylar olarak ayarlamak, ana işaretçileri bir ay aralıklarıyla yerleştirir.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("ExistingChart.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes[0]
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_automatic_major_unit = False
    chart.axes.horizontal_axis.major_unit = 1
    chart.axes.horizontal_axis.major_unit_scale = charts.TimeUnitType.MONTHS

    presentation.save("ChangeChartCategoryAxis_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Kategori Eksen Etiket Aralıklarını Kontrol Edin**

Bir grafikte çok sayıda kategori olduğunda, kategorileri veya veri noktalarını kaldırmadan görünür eksen etiket sayısını azaltın. [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) özelliğini `False` olarak ayarlayın, ardından istediğiniz kategori aralığı için [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) özelliğini belirleyin. Metin kategorileri normal sıralarındaysa, sayma ilk kategorizden başlar:

| Aralık | Örnekte Görüntülenen Etiketler |
| --- | --- |
| `1` | Kategori 1, Kategori 2, Kategori 3, ... Kategori 24 |
| `2` | Kategori 1, Kategori 3, Kategori 5, ... Kategori 23 |
| `3` | Kategori 1, Kategori 4, Kategori 7, ... Kategori 22 |

`3` aralığı, her üçüncü etiketi gösterir ve gösterilen etiketler arasında iki etiket gizlenir. İlgili sütunları kaldırmaz. Otomatik aralık, kullanılabilir alana göre bir aralık seçer; bu mutlaka her etiketi göstermez.

İşaretleme çizgileri ayrı kontroller sağlar. [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) özelliğini `False` yapın ve aralıklarını ayarlamak için [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) özelliğini kullanın. Örneğin, `1` her kategori aralığında bir işaret çizgisi tutarken etiketler yalnızca her üçüncü kategoride görünür. Görüntüyü görebilmek için [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) özelliğini görünür bir stil olarak ayarlayın. Otomatik aralık özelliğini `True` yaparsanız, grafik tekrar bu aralığı seçer.

Aşağıdaki bağımsız örnek 24 kategori ve bir seri oluşturur, ardından `CategoryAxisIntervals.pptx` içinde üç slayt kaydeder: otomatik aralık, bağımsız işaret çizgileriyle manuel etiket aralığı ve otomatik aralığın geri yüklenmesi. İki kopya orijinal grafik verilerini korur. Giriş sunumu gerekmez. Yatay etiket metni, yoğunluktaki farkı görmeyi kolaylaştırır.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 40, 660, 320)

    chart.has_legend = False
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.CLUSTERED_COLUMN)
    for i in range(24):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, 10 + i % 6 * 5)
        series.data_points.add_data_point_for_bar_series(value_cell)

    axis = chart.axes.horizontal_axis
    axis.category_axis_type = charts.CategoryAxisType.TEXT
    axis.text_format.text_block_format.rotation_angle = 0
    axis.text_format.portion_format.font_height = 12
    axis.major_tick_mark = charts.TickMarkType.OUTSIDE
    axis.is_automatic_tick_label_spacing = True
    axis.is_automatic_tick_marks_spacing = True

    # Slayt 2: her üçüncü etiketi göster, ancak her kategori için bir işaret çizgisi tut.
    manual_slide = presentation.slides.add_clone(slide)
    manual_chart = manual_slide.shapes[0]
    manual_axis = manual_chart.axes.horizontal_axis
    manual_axis.is_automatic_tick_label_spacing = False
    manual_axis.tick_label_spacing = 3
    manual_axis.is_automatic_tick_marks_spacing = False
    manual_axis.tick_marks_spacing = 1

    # Slayt 3: grafiğin her iki aralığı da yeniden seçmesine izin ver.
    restored_slide = presentation.slides.add_clone(manual_slide)
    restored_chart = restored_slide.shapes[0]
    restored_chart.axes.horizontal_axis.is_automatic_tick_label_spacing = True
    restored_chart.axes.horizontal_axis.is_automatic_tick_marks_spacing = True

    presentation.save("CategoryAxisIntervals.pptx", slides.export.SaveFormat.PPTX)
```

**Automatic spacing (slide 1):** Bu renderlemede, her ikinci kategori etiketi görüntülenir ve iki satıra kaydırılır. Otomatik sonuç, grafik boyutu, yazı tipleri ve renderlayıcıya göre değişebilir.

![Tüm 24 sütun görünürken otomatik kategori etiketi aralığı](category-axis-automatic.png)

**Manual spacing (slide 2):** Her üçüncü etiket tek satırda görüntülenirken, işaret çizgileri her kategori aralığında kalır. Etiket olmadan bile tüm 24 sütun, aynı değerlerle görünür. 3. slayt, yukarıdaki otomatik görünümü geri yükler.

![Üçüncü kategori etiket aralığıyla manuel, tüm 24 sütun görünür](category-axis-manual.png)

### **Doğru Eksen ve Aralığı Seçin**

Metin kategori ekseni için, örneğin bir sütun, çizgi, alan veya çubuk grafiğinin kategori ekseni, bu kategori-sayı aralığını kullanın. Sütun grafiğinde bu, yatay eksendir. Yatay çubuk grafiğinde ise kategori ekseni dikeydir; bu ayarları [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/) için uygulayın. İşaret çizgisi aralığı, bir seri ekseni olan grafiklerde de uygulanabilir.

Kategori etiketi aralığını bir değer ekseninin sayısal ölçeğini ayarlamak için kullanmayın. Değer ekseninde, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) değerin farkını belirtir: örneğin, `10` bir ana birim, eksen sıfırdan başladığında 0, 10, 20 vb. işaretler üretir. `3` kategori etiketi aralığı ise kategori konumlarını sayar, veri değerlerinden bağımsızdır. Dağılım ve balon grafikler, metin kategori ekseni yerine değer eksenleri kullanır. Tarih ekseni için, [Change a Category Axis](#change-a-category-axis) bölümünde açıklandığı gibi zaman tabanlı ana birimler ve ölçekler kullanın.

## **Kategori Ekseni Değerleri için Tarih Biçimini Ayarlayın**

Örnek, varsayılan grafik verilerini dört yıllık değerle değiştirir. Tarihler, ilk çalışma sayfasında (indeks `0`) OLE Automation seri numaraları olarak saklanır. [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) özelliğini tarih ekseni olarak ayarlayın, [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) özelliğini devre dışı bırakın ve kategori etiketlerinin hücre biçimlendirmesinden bağımsız olarak dört basamaklı yılları görüntülemesi için `yyyy` değerini [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) özelliğine atayın.

```python
from datetime import date

import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    for i in range(4):
        category_date = date(2015 + i, 1, 1)
        serial_date = (category_date - date(1899, 12, 30)).days
        category_cell = workbook.get_cell(0, i + 1, 0, serial_date)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, i + 1)
        series.data_points.add_data_point_for_line_series(value_cell)

    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_number_format_linked_to_source = False
    chart.axes.horizontal_axis.number_format = "yyyy"

    presentation.save("DateAxisFormat.pptx", slides.export.SaveFormat.PPTX)
```

## **Grafik Eksen Başlığı için Döndürme Açısını Ayarlayın**

Dikey eksende [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) özelliğini etkinleştirin, başlık metni sağlayın ve başlığı döndürmek için [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) özelliğini ayarlayın. Açı derece cinsinden ölçülür; bu örnek, değerekseni başlığı 90 derece döndürülmüş bir sütun grafiği kaydeder.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("Value")
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    presentation.save("RotatedAxisTitle.pptx", slides.export.SaveFormat.PPTX)
```

## **Kategori veya Değer Ekseni Üzerinde Eksen Konumunu Ayarlayın**

[axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) özelliğini, değer ekseninin kategori eksenini kategoriler arasında mı yoksa kategori işaretleri üzerinde mi kesiştireceğini kontrol etmek için kullanın. Bu özellik kategori eksenlerine uygulanır. Örnek, bir sütun grafiğinin yatay kategori ekseninde bu özelliği `True` olarak ayarlar ve sonucu kaydeder.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **Grafik Değer Ekseni için Gösterim Birimini Ayarlayın**

[display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) özelliğini, temel verileri değiştirmeden değer eksenindeki etiketleri ölçeklendirmek için ayarlayın. [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) `MILLIONS` olarak ayarlandığında, 60.000.000 değeri 60 olarak gösterilir. Örnek, bir sütun grafiği oluşturur ve dikey eksenine milyon gösterim birimini uygular.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Bir eksenin diğerini kestiği değeri (ekseni kesişim) nasıl ayarlarım?**

[cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) özelliğini kullanarak kesişim davranışını seçin. Sayısal bir kesişim değeri belirtmek için [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/) özelliğini ayarlayın. Bu ayarlar, eksen kesişimini uygun bir temel çizgisine taşımanıza olanak tanır.

**İşaret etiketi konumlarını eksene göre nasıl konumlandırırım?**

[tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) özelliğini [TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/) ile `LOW`, `HIGH`, `NEXT_TO` veya `NONE` olarak ayarlayın. İşaret çizgilerini kontrol etmek için, etiket konumlandırmasından bağımsız olarak [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) veya [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/) özelliklerini kullanın.