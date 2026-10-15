---
title: Python ile Sunumlarda Grafik Eksenlerini Özelleştirin
linktitle: Grafik Ekseni
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
description: "Raporlar ve görselleştirmeler için PowerPoint ve OpenDocument sunumlarında grafik eksenlerini özelleştirmek amacıyla Aspose.Slides for Python via .NET kullanımını keşfedin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Python via .NET ile grafik eksenlerini nasıl özelleştireceğinizi açıklar. Hesaplanan eksen değerlerini, grafik satır ve sütunlarının değiştirilmesini, eksen görünürlüğünü, kategori etiketi ve işaretleme aralıklarını, tarih kategorilerini ve biçimlendirmesini, başlık döndürmeyi, eksen konumlandırmasını, görüntüleme birimlerini ve logaritmik ölçeklemeyi kapsar.

## **Grafiklerde Dikey Eksenin Azami Değerlerini Almak**

Varsayılan verilerle bir alan grafiği ekleyerek bir [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) oluşturun. Hesaplanan eksen değerlerini okumadan önce grafiğin düzeninin güncel olması için [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) çağırın.

Eksen sınırları için [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) ve [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) değerlerini, işaretleme aralıkları için [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) ve [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) değerlerini okuyun. Tarih eksenleriyle ilgili olan zaman birimi ölçeklerini sağlamak için [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) ve [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) kullanın. Örnek, bu değerleri yerel değişkenlerde saklar ve grafiği kaydeder.

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

Seri ve kategori rollerini grafik verilerinde değiştirmek için [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) kullanın. Her eski kategori bir seri, her eski seri ise bir kategori olur. Bu, verilerin nasıl gruplandığını değiştirir; yatay ve dikey eksenleri değiştirmez. Örnek, satır ve sütunları değiştirmeden önce [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) kullanarak varsayılan verileri `Sheet1!A1:D5` adresine, başlık satırı ve kategori sütununu dahil ederek bağlar. Dört seri ve üç kategori içeren bir grafik kaydeder.

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

## **Bir Eksenin Çizim Sırasını Tersine Çevirin**

Bir kategori veya değer eksenini tersine çevirmek için [is_plot_order_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_plot_order_reversed/) kullanın. Örneğin, bir yatay çubuk grafik, proje aşamalarını çalışma sayfasındaki aynı sırayla üstten alta gösterebilir: Planlama, Geliştirme, Test. Bir ekseni tersine çevirmek, çizim yönünü değiştirir; veri kümesini sıralamaz veya yeniden düzenlemez. Karşılaştırma olarak, [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) seri ve kategori rollerini değiştirir.

Aşağıdaki örnek, üç aşama ve bir seri içeren bir yatay çubuk grafik oluşturur. Üç slayt kaydeder: normal sıralama, ters kategoriler ve ters değerler. Her kopya aynı veri kümesini kullanır ve her kopyada sadece bir eksen ters çevrilir.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_BAR, 50, 40, 620, 320)
    chart.has_legend = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.CLUSTERED_BAR)
    stages = ["Planning", "Development", "Testing"]
    values = [10, 30, 20]
    for i, stage in enumerate(stages):
        category_cell = workbook.get_cell(0, i + 1, 0, stage)
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, values[i])
        series.data_points.add_data_point_for_bar_series(value_cell)

    # Slayt 2: ilk kategoriyi üstte göster.
    category_slide = presentation.slides.add_clone(slide)
    category_chart = category_slide.shapes[0]
    category_chart.axes.vertical_axis.is_plot_order_reversed = True
    # Yatay değer eksenini altta tut.
    category_chart.axes.vertical_axis.cross_type = charts.CrossesType.MAXIMUM

    # Slayt 3: yalnızca yatay sayısal ölçeği tersine çevir.
    value_slide = presentation.slides.add_clone(slide)
    value_chart = value_slide.shapes[0]
    value_chart.axes.horizontal_axis.is_plot_order_reversed = True

    presentation.save("ReversedAxes.pptx", slides.export.SaveFormat.PPTX)
```

Bir ekseni tersine çevirmek, dik ekseni grafiğin karşı tarafına taşıyabilir. [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) yapılandırılan eksenin diğer ekseni nerede kestiğini kontrol eder. 2. slaytta, ters kategori ekseninde `MAXIMUM` olarak ayarlandığında, yatay değer ekseni altta kalır. Belirli bir kesişim noktası için [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/) kullanın. Yön değiştirirken özellikle grafiğin zaten özel bir kesişim noktasına sahip olup olmadığını kontrol edin. Normal çizim yönünü geri yüklemek için `is_plot_order_reversed` değerini `False` yapın; kesişim ayarları ayrı bir konudur.

| Normal sıralama (slayt 1) | Ters kategoriler (slayt 2) | Ters değerler (slayt 3) |
| --- | --- | --- |
| ![Normal kategori ve değer ekseni sıralamasına sahip yatay çubuk grafiği](axis-order-normal.png) | ![Kategorilerin üstten alta gösterildiği yatay çubuk grafiği](axis-order-categories-reversed.png) | ![Değer ekseni ters çevrildiği ve sıfırın sağda olduğu yatay çubuk grafiği](axis-order-values-reversed.png) |
| Kategoriler alt'dan üst'e doğru; değerler soldan sağa artar. | Planlama, Geliştirme ve Test, üstten alta doğru. Değerler ve çalışma kitabı satır sırası değişmez. | Kategoriler normal sırasını korur; değerler sağdan sola artar. Kategori ekseni sağdaki sıfırda kesişir. |

## **Çizgi Grafikleri için Dikey Eksen'i Devre Dışı Bırakın**

Dikey ekseni gizlemek için eksende [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) özelliğini `False` olarak ayarlayın. Örnek, varsayılan verilerle bir çizgi grafik oluşturur ve dik ekseni gizlenmiş şekilde kaydeder.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False

    presentation.save("HiddenVerticalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Çizgi Grafikleri için Yatay Eksen'i Devre Dışı Bırakın**

Yatay ekseni gizlemek için eksende [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) özelliğini `False` olarak ayarlayın. Örnek, varsayılan verilerle bir çizgi grafik oluşturur ve yatay ekseni gizlenmiş şekilde kaydeder.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    presentation.save("HiddenHorizontalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Bir Kategori Eksenini Değiştirin**

Bir tarih veya metin kategori ekseni seçmek için [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) ayarlayın. Bu örnek, ilk slayttaki ilk şekil olarak bir grafik içeren ve kategori hücrelerinde sayısal Excel tarih değerleri bulunan `ExistingChart.pptx` dosyasını gerektirir. Yatay ekseni bir tarih ekseni olarak değiştirir. [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) özelliğini `False`, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) özelliğini `1` ve [major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) özelliğini aylar olarak ayarlamak, ana işaretçileri bir‑ay aralıklarla yerleştirir.

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

## **Kategori Eksen Etiketi Aralıklarını Kontrol Edin**

Bir grafikte birçok kategori olduğunda, kategorileri veya veri noktalarını kaldırmadan görünen eksen etiketlerinin sayısını azaltın. [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) özelliğini `False` yapın, ardından istenen kategori aralığını belirtmek için [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) ayarlayın. Normal sıralamadaki metin kategorileri için sayma ilk kategori üzerinden başlar:

| Aralık | Örnekte gösterilen etiketler |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

`3` aralığı, her üçüncü etiketi gösterir ve gösterilen etiketler arasında iki etiket gizlenir. İlgili sütunları kaldırmaz. Otomatik aralık, mevcut alana göre bir aralık seçer; mutlaka her etiketi göstermez.

İşaretçilerin ayrı kontrolleri vardır. [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) özelliğini `False` yapın ve aralıklarını ayarlamak için [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) kullanın. Örneğin, `1` işaretçiyi her kategori aralığında tutarken etiketler sadece her üçüncü kategoride görünür. Görünür bir stil seçmek için [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) ayarlayın. Otomatik‑aralık özelliklerinden birini tekrar `True` yaparsanız, grafik tekrar o aralığı seçer.

Aşağıdaki bağımsız örnek, 24 kategori ve bir seri oluşturur, ardından `CategoryAxisIntervals.pptx` içinde üç slayt kaydeder: otomatik aralık, bağımsız işaretçilerle manuel etiket aralığı ve geri yüklenmiş otomatik aralık. İki kopya orijinal grafik verilerini korur. Giriş sunumu gerekmez. Yatay etiket metni, yoğunluk farkını net görmenizi sağlar.

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

    # Slayt 2: her üçüncü etiketi göster, ancak her kategori için bir işaretçi tut.
    manual_slide = presentation.slides.add_clone(slide)
    manual_chart = manual_slide.shapes[0]
    manual_axis = manual_chart.axes.horizontal_axis
    manual_axis.is_automatic_tick_label_spacing = False
    manual_axis.tick_label_spacing = 3
    manual_axis.is_automatic_tick_marks_spacing = False
    manual_axis.tick_marks_spacing = 1

    # Slayt 3: grafiğin her iki aralığı da tekrar seçmesine izin ver.
    restored_slide = presentation.slides.add_clone(manual_slide)
    restored_chart = restored_slide.shapes[0]
    restored_chart.axes.horizontal_axis.is_automatic_tick_label_spacing = True
    restored_chart.axes.horizontal_axis.is_automatic_tick_marks_spacing = True

    presentation.save("CategoryAxisIntervals.pptx", slides.export.SaveFormat.PPTX)
```

**Otomatik boşluk (slayt 1):** Bu renderda, her ikinci kategori etiketi gösterilir ve iki satıra kaydırılır. Otomatik sonuç, grafik boyutu, yazı tipleri ve işleyiciye göre değişebilir.

![Tüm 24 sütun görünürken otomatik kategori etiketi aralığı](category-axis-automatic.png)

**Manuel boşluk (slayt 2):** Her üçüncü etiket tek satırda gösterilirken işaretçiler her kategori aralığında kalır. Etiketi olmayan tüm 24 sütun aynı değerlerle görünür. Slayt 3, yukarıda gösterilen otomatik görünümü geri yükler.

![Üç aralıkla manuel kategori etiketi, tüm 24 sütun görünür](category-axis-manual.png)

### **Doğru Eksen ve Aralığı Seçin**

Bir metin kategori ekseni için bu kategori‑sayı aralığını kullanın; örneğin bir sütun, çizgi, alan veya çubuk grafiğinin kategori ekseni. Bir sütun grafiğinde yatay eksen budur. Bir yatay çubuk grafiğinde kategori ekseni dik olduğundan, bu ayarları [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/) üzerine uygulayın. İşaretleme aralığı, bir serinin ekseni olduğu grafiklerde de geçerlidir.

Kategori etiketi aralığını, bir değer ekseninin sayısal ölçeğini ayarlamak için kullanmayın. Değer ekseninde [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) bir değer farkını belirtir: örneğin `10` bir ana birim, eksen sıfırdan başlıyorsa 0, 10, 20 gibi işaretler üretir. `3` bir kategori etiketi aralığı ise veri değerlerinden bağımsız olarak kategori konumlarını sayar. Dağılım ve balon grafiklerinde metin kategori ekseni yerine değer eksenleri kullanılır. Bir tarih ekseni için, [Change a Category Axis](#change-a-category-axis) bölümünde açıklandığı gibi zaman‑temelli ana birimler ve ölçekler kullanın.

## **Kategori Eksen Değerleri için Tarih Biçimini Ayarlayın**

Örnek, varsayılan grafik verilerini dört yıllık değerle değiştirir. Tarihler, ilk çalışma sayfasında (indeks `0`) OLE Automation seri numaraları olarak saklanır. [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) özelliğini bir tarih ekseni olarak ayarlayın, [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) özelliğini devre dışı bırakın ve kategori etiketlerinin hücre biçiminden bağımsız olarak dört rakamlı yılları göstermesi için `yyyy` değerini [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) özelliğine atayın.

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

## **Grafik Eksen Başlığı için Döndürme Açısını Ayarla**

Dikey eksende [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) özelliğini etkinleştirin, başlık metnini sağlayın ve başlığı döndürmek için [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) ayarlayın. Açı derece cinsindendir; bu örnek, değer ekseni başlığını 90 derece döndürmüş bir sütun grafik kaydeder.

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

## **Kategori veya Değer Ekseninde Eksen Konumunu Ayarlayın**

Değer ekseninin kategori eksenini kategoriler arasında mı yoksa kategori işaretçileri üzerinde mi geçeceğini kontrol etmek için [axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) kullanın. Bu özellik yalnızca kategori eksenlerine uygulanır. Örnek, bir sütun grafiğinin yatay kategori ekseninde bu özelliği `True` olarak ayarlar ve sonucu kaydeder.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **Grafik Değer Ekseninde Görüntüleme Birimini Ayarlayın**

Veri setini değiştirmeden değer eksenindeki etiketleri ölçeklendirmek için [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) ayarlayın. [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) `MILLIONS` olarak ayarlandığında, 60 000 000 değeri 60 olarak gösterilir. Örnek, bir sütun grafik oluşturur ve dik eksenine milyon görüntüleme birimini uygular.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **Logaritmik Değer Eksenini Yapılandırın**

Pozitif değerler birkaç büyüklük mertebesi kapsadığında logaritmik değer ekseni yararlıdır. Örneğin bir hizmet, beş dönemde 10, 100, 1 000, 10 000 ve 100 000 istek alabilir. Doğrusal ölçekte, daha küçük değerler sıfıra yakın bir arada görünür. Logaritmik ölçek, bu değerlerin göreceli büyümesini karşılaştırmayı kolaylaştırır: eşit mesafeler eşit oranları temsil eder, eşit farkları değil.

Değer ekseninde [is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) özelliğini `True` yapın ve tabanı seçmek için [log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/) kullanın. Bu, mevcut değerlerin nasıl gösterildiğini değiştirir; veri setini değiştirmez veya logaritmik bir trend çizgisi eklemez. Trend çizgisi, verideki uyarlanmış bir ilişkiyi temsil eder ve ayrı bir özelliktir.

### **Değer Eksenini ve Tabanı Seçin**

Bir çizgi veya sütun grafiğinde değer ekseni [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/) dir. Yatay çubuk grafiğinde ise [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/) dir. Dağılım ve balon grafiklerinde iki değer ekseni bulunduğundan, X değerleri için yatay eksen, Y değerleri için dik eksen ya da her ikisi de seçilebilir. Kategori eksenine logaritmik ölçek uygulamayın.

Varsayılan logaritmik taban `10` dur. PPTX grafiklerinde `2` ile `1000` arasında (dahil) bir taban kullanılabilir; `2.5` gibi kesirli tabanlar da desteklenir. `10` tabanı ile 10, 100, 1 000, 10 000 gibi ardışık güçler eşit aralıklıdır.

### **Doğrusal ve Logaritmik Ölçeklemeyi Karşılaştırın**

Aşağıdaki bağımsız örnek, ilk slaytta beş istek sayısını gösteren bir çizgi grafik oluşturur, ardından bu slaytı kopyalar ve ikinci slaytta taban‑10 logaritmik değer eksenini etkinleştirir. Her iki slayt da aynı veriyi korur.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 30, 40, 660, 200)

    chart.has_legend = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    values = [10, 100, 1000, 10000, 100000]

    for i, value in enumerate(values):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Period {i + 1}")
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, value)
        series.data_points.add_data_point_for_line_series(value_cell)

    # İlk slaytı doğrusal tut ve yalnızca kopyanın değer ekseni ölçeğini değiştir.
    logarithmic_slide = presentation.slides.add_clone(slide)
    logarithmic_chart = logarithmic_slide.shapes[0]
    value_axis = logarithmic_chart.axes.vertical_axis
    value_axis.is_logarithmic = True
    value_axis.log_base = 10

    presentation.save("LogarithmicAxis.pptx", slides.export.SaveFormat.PPTX)
```

**Doğrusal ölçek (slayt 1):** Eşit dikey mesafeler, istek sayılarındaki eşit farkları temsil eder. En büyük değer grafiği domine eder, daha küçük değerlerin ayırt edilmesini zorlaştırır.

![Doğrusal değer ekseninde beş istek sayısını gösteren PowerPoint çizgi grafiği](value-axis-linear.png)

**Logaritmik ölçek (slayt 2):** Eşit dikey mesafeler, eşit oranları temsil eder. Her dönem bir öncekinin on katı istek alır, bu yüzden noktalar taban‑10 ölçeğinde düz bir yükselen çizgi oluşturur. Eksen etiketleri hâlâ orijinal istek sayılarını gösterir.

![PowerPoint'te aynı beş istek sayısını taban‑10 logaritmik değer ekseninde gösteren grafik](value-axis-logarithmic.png)

### **Sıfır ve Negatif Değerleri Ele Alın**

Logaritmik ölçek yalnızca kesin pozitif değerleri gösterebilir. Etkinleştirmeden önce veriyi kontrol edin. Sıfır veya negatif değerler anlamlıysa, doğrusal ölçek tutun veya bunları ayrı bir şekilde gösterin. Bu değerleri analiz için dışlamak uygun ise, eksikliği açıklayın. Küçük pozitif sayılarla sessizce değiştirmeyin; bu veri anlamını değiştirir. Logaritmik eksen için manuel olarak ayarlanan minimum veya maksimum da pozitif olmalıdır.

## **SSS**

**Bir eksenin diğerini kestiği değeri (ekseni kesişim) nasıl ayarlarım?**

Kesişme davranışını seçmek için [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) kullanın. Sayısal bir kesişim değeri belirtmek için [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/) ayarlayın. Bu ayarlar, eksen kesişimini uygun bir temel çizgiye taşımanıza olanak tanır.

**İşaretleme etiketlerini eksene göre nasıl konumlandırabilirim?**

[TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/) üzerinden `LOW`, `HIGH`, `NEXT_TO` veya `NONE` seçenekleriyle [tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) ayarlayın. İşaretleme çizgilerini kontrol etmek için [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) veya [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/) kullanın; bunlar etiket konumlandırmasından ayrı ayarlardır.