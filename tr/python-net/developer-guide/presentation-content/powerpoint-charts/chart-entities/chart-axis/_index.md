---
title: Python ile Sunumlarda Grafik Eksenlerini Özelleştirme
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
description: "Aspose.Slides for Python via .NET'i kullanarak rapor ve görselleştirmeler için PowerPoint ve OpenDocument sunumlarında grafik eksenlerini nasıl özelleştireceğinizi keşfedin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Python via .NET ile grafik eksenlerini nasıl özelleştireceğinizi açıklar. Hesaplanmış eksen değerleri, grafik satır ve sütunlarının değiştirilmesi, eksen görünürlüğü, kategori etiketi ve işaretçi aralıkları, tarih kategorileri ve biçimlendirme, başlık döndürme, eksen konumlandırma, görüntü birimleri ve logaritmik ölçeklendirme konularını kapsar.

## **Grafiklerde Dikey Eksenin Maksimum Değerlerini Alın**

Bir [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) oluşturun ve varsayılan verilerle bir alan grafiği ekleyin. Hesaplanmış eksen değerlerini okumadan önce grafik düzeninin güncel olması için [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) çağırın.

Eksen limitleri için [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) ve [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) okuyun, işaretçi aralıkları için ise [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) ve [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) kullanın. [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) ve [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) tarih eksenleriyle ilgili zaman birimi ölçeklerini sağlar. Örnek bu değerleri yerel değişkenlerde saklar ve grafiği kaydeder.

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

## **Eksenler Arasında Veriyi Değiştir**

[switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) kullanarak grafik verisinde seriler ve kategoriler arasındaki rolleri değiştirin. Her eski kategori bir seri, her eski seri ise bir kategori olur. Bu, verinin nasıl gruplanacağını değiştirir; yatay ve düşey eksenleri değiştirmez. Örnek satır ve sütunları değiştirmeden önce varsayılan verileri `Sheet1!A1:D5` adresine bağlamak için [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) kullanır. Dört seri ve üç kategori içeren bir grafik kaydeder.

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

## **Çizgi Grafiklerinde Dikey Ekseni Devre Dışı Bırak**

Dikey eksende [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) özelliğini `False` olarak ayarlayın. Örnek varsayılan verilerle bir çizgi grafiği oluşturur ve dikey ekseni gizli olarak kaydeder.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False

    presentation.save("HiddenVerticalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Çizgi Grafiklerinde Yatay Ekseni Devre Dışı Bırak**

Yatay eksende [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) özelliğini `False` olarak ayarlayın. Örnek varsayılan verilerle bir çizgi grafiği oluşturur ve yatay ekseni gizli olarak kaydeder.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    presentation.save("HiddenHorizontalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Bir Kategori Ekseni Değiştir**

[category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) ayarını tarih veya metin kategori ekseni seçmek için kullanın. Bu örnek `ExistingChart.pptx` dosyasını gerektirir; ilk slayttaki ilk şekil bir grafiktir ve kategori hücreleri sayısal Excel tarih değerleri içerir. Yatay ekseni tarih ekseni olarak değiştirir. [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) özelliğini `False`, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) özelliğini `1` ve [major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) özelliğini aylara ayarlayarak ana işaretçileri bir‑ay aralıklarla yerleştirir.

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

## **Kategori Ekseni Etiket Aralıklarını Kontrol Et**

Bir grafikte birçok kategori olduğunda, kategori ya da veri noktalarını kaldırmadan görünen eksen etiketlerinin sayısını azaltın. [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) özelliğini `False` yapın, ardından [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) özelliğini istediğiniz kategori aralığına ayarlayın. Metin kategorileri normal sıralarında olduğunda, sayma ilk kategoriden başlar:

| Aralık | Örnekte Görünen Etiketler |
| --- | --- |
| `1` | Kategori 1, Kategori 2, Kategori 3, ... Kategori 24 |
| `2` | Kategori 1, Kategori 3, Kategori 5, ... Kategori 23 |
| `3` | Kategori 1, Kategori 4, Kategori 7, ... Kategori 22 |

`3` aralığı, her üçüncü etiketi gösterir; gösterilen etiketlerin arasında iki etiket gizli kalır. İlgili sütunları kaldırmaz. Otomatik aralık, kullanılabilir alana göre bir aralık seçer; her etiketi mutlaka göstermez.

İşaretçi çizgileri ayrı kontrol edilir. [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) özelliğini `False` yapın ve [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) ile aralığını ayarlayın. Örneğin, `1` her kategori aralığında bir işaretçi bırakırken etiketler yalnızca her üçüncü kategoride görünür. [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) özelliğini görünür bir stil olarak ayarlayın, böylece sonucu görebilirsiniz. Otomatik‑aralık özelliğini `True` yaparsanız grafik tekrar o aralığı seçer.

Aşağıdaki kendi içinde bütünleşik örnek 24 kategori ve bir seri oluşturur, ardından `CategoryAxisIntervals.pptx` içinde üç slayt kaydeder: otomatik aralık, bağımsız işaretçilerle manuel etiket aralığı ve otomatik aralığın geri yüklenmesi. İki kopya orijinal grafik verilerini korur. Giriş sunumu gerekmez. Yatay etiket metni, yoğunluk farkını görmeyi kolaylaştırır.

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

**Otomatik aralık (slayt 1):** Bu gösterimde, her ikinci kategori etiketi görüntülenir ve iki satıra sarılır. Otomatik sonuç grafik boyutu, yazı tipleri ve oluşturucuya göre değişebilir.

![Otomatik kategori etiketi aralığı, tüm 24 sütun görünür](category-axis-automatic.png)

**Manuel aralık (slayt 2):** Her üçüncü etiket tek satırda gösterilir, işaretçiler ise her kategori aralığında kalır. Etiketleri olmayanlar dahil tüm 24 sütun aynı değerlerle görünür. Slayt 3, yukarıda gösterilen otomatik görünümü geri yükler.

![Manuel kategori etiketi aralığı üç, tüm 24 sütun görünür](category-axis-manual.png)

### **Doğru Eksen ve Aralığı Seçin**

Metin kategori ekseni olan bir sütun, çizgi, alan veya bar grafiğinin kategori ekseni için bu kategori‑sayı aralığını kullanın. Sütun grafiğinde bu, yatay eksendir. Yatay bar grafiğinde kategori ekseni düşeydir; bu ayarları [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/) üzerinde uygulayın. İşaretçi aralığı, bir seri ekseni olan grafiklerde de geçerlidir.

Değer ekseninin sayısal ölçeğini ayarlamak için kategori etiketi aralığını kullanmayın. Değer ekseninde [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) değer farkını belirler: örneğin, `10` bir ana birim, eksen sıfırdan başlayınca 0, 10, 20 vb. işaretçiler üretir. `3` bir kategori etiketi aralığı, veri değerlerinden bağımsız olarak kategori konumlarını sayar. Saçılım ve balon grafikler metin kategori ekseni yerine değer eksenleri kullanır. Tarih ekseni için, [Change a Category Axis](#change-a-category-axis) bölümünde açıklandığı gibi zaman‑temelli ana birimler ve ölçekler kullanın.

## **Kategori Ekseni Değerleri için Tarih Biçimini Ayarla**

Örnek, varsayılan grafik verilerini dört yıllık değerle değiştirir. Tarihler, ilk çalışma sayfasında (indeks `0`) OLE Automation seri numaraları olarak saklanır. [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) ayarını tarih ekseni yapın, [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) özelliğini devre dışı bırakın ve [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) özelliğine `yyyy` atayarak kategori etiketlerinin hücre biçiminden bağımsız olarak dört haneli yıl göstermesini sağlayın.

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

## **Bir Grafik Eksen Başlığı için Döndürme Açısı Ayarla**

Düşey eksende [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) özelliğini etkinleştirin, başlık metni sağlayın ve başlığı döndürmek için [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) ayarını kullanın. Açı derece cinsindendir; bu örnek, değer ekseni başlığını 90 derece döndürerek bir sütun grafiği kaydeder.

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

## **Kategori veya Değer Ekseni Üzerinde Eksen Pozisyonunu Ayarla**

[axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) özelliğini kullanarak değer ekseninin kategori eksenini kategoriler arasında mı yoksa kategori işaretçileri üzerinde mi keseceğini kontrol edin. Bu özellik kategori eksenlerine uygulanır. Örnek, bir sütun grafiğinin yatay kategori ekseninde bu özelliği `True` yapar ve sonucu kaydeder.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **Grafik Değer Ekseninde Görüntü Birimini Ayarla**

[display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) ayarını, temel verileri değiştirmeden bir değer eksenindeki etiketleri ölçeklendirmek için kullanın. [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) özelliği `MILLIONS` olarak ayarlandığında, 60 000 000 değeri 60 olarak gösterilir. Örnek bir sütun grafiği oluşturur ve düşey eksenine milyonlar görüntü birimini uygular.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **Logaritmik Değer Ekseni Yapılandır**

Pozitif değerler birkaç mertebe genişlediğinde logaritmik değer ekseni kullanışlıdır. Örneğin, bir hizmet beş dönem boyunca sırasıyla 10, 100, 1 000, 10 000 ve 100 000 istek alabilir. Lineer ölçekte küçük değerler sıfıra yakın bir arada görünür. Logaritmik ölçek, bunların göreli büyümesini karşılaştırmayı kolaylaştırır: eşit mesafeler eşit oranları, eşit farkları temsil eder.

Değer ekseninde [is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) özelliğini `True` yapın ve tabanı seçmek için [log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/) özelliğini kullanın. Bu, mevcut değerlerin nasıl gösterildiğini değiştirir; veriyi değiştirmez ve logaritmik bir trend çizgisi eklemez. Trend çizgisi, verideki uygun bir ilişkiyi temsil eder ve ayrı bir özelliktir.

### **Değer Eksenini ve Tabanı Seçin**

Çizgi veya sütun grafiğinde değer ekseni [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/) olur. Yatay bar grafiğinde [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/) olur. Saçılım ve balon grafiklerinde iki değer ekseni bulunur; X değerleri için yatay ekseni, Y değerleri için düşey ekseni ya da her ikisini seçin. Kategori eksenine logaritmik ölçek uygulamayın.

Varsayılan logaritmik taban `10` dur. PPTX grafiklerinde `2` ile `1000` arasında (dahil) bir taban kullanın; `2.5` gibi kesirli tabanlar da desteklenir. Tabana `10` verildiğinde, art arda gelen 10, 100, 1 000 ve 10 000 gibi katlar eşit aralıklarla yer alır.

### **Lineer ve Logaritmik Ölçeklendirmeyi Karşılaştır**

Aşağıdaki kendi içinde bütünleşik örnek, ilk slaytta beş istek sayısını içeren bir çizgi grafiği oluşturur, ardından bu slaytı kopyalar ve ikinci slaytta taban‑10 logaritmik değer ekseni etkinleştirir. Her iki slayt da aynı veriyi korur.

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

    # İlk slaytı lineer tut ve yalnızca kopyanın değer ekseni ölçeğini değiştir.
    logarithmic_slide = presentation.slides.add_clone(slide)
    logarithmic_chart = logarithmic_slide.shapes[0]
    value_axis = logarithmic_chart.axes.vertical_axis
    value_axis.is_logarithmic = True
    value_axis.log_base = 10

    presentation.save("LogarithmicAxis.pptx", slides.export.SaveFormat.PPTX)
```

**Lineer ölçek (slayt 1):** Eşit düşey mesafeler, istek sayılarındaki eşit farkları temsil eder. En büyük değer grafiği domine eder, küçük değerleri ayırt etmeyi zorlaştırır.

![PowerPoint’te lineer değer ekseninde beş istek sayısını gösteren çizgi grafik](value-axis-linear.png)

**Logaritmik ölçek (slayt 2):** Eşit düşey mesafeler eşit oranları temsil eder. Her dönem bir önceki dönemin on katı istek alır; bu yüzden noktalar taban‑10 ölçeğinde düz bir yükselen çizgi oluşturur. Eksende etiketler hâlâ özgün istek sayılarını gösterir.

![PowerPoint’te taban‑10 logaritmik değer ekseninde aynı beş istek sayısı](value-axis-logarithmic.png)

### **Sıfır ve Negatif Değerleri İşleyin**

Logaritmik ölçek yalnızca kesin pozitif değerleri gösterebilir. Kullanımdan önce veriyi kontrol edin. Sıfır ya da negatif değerler anlamlıysa, lineer ölçek tutun ya da bu değerleri ayrı şekilde gösterin. Bu değerleri analizden çıkarmak uygun ise, eksikliği açıklayın. Küçük pozitif sayılarla gizlice değiştirmeyin; bu, verinin anlamını değiştirir. Logaritmik eksen için elle ayarlanan minimum veya maksimum değerler de pozitif olmalıdır.

## **SSS**

**Bir eksenin diğerini kestiği değeri (eksen kesişimi) nasıl ayarlarım?**

[cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) kullanarak kesişim davranışını seçin. Sayısal bir kesişim değeri belirlemek için [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/) ayarlayın. Bu ayarlar, eksen kesişimini uygun bir temel çizgiye taşımanıza olanak tanır.

**Etiketleri eksene göre nasıl konumlandırabilirim?**

[tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) ayarını [TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/) ile kullanın: `LOW`, `HIGH`, `NEXT_TO` veya `NONE`. İşaretçi çizgilerini kontrol etmek için, etiket konumlandırmasından ayrı olarak, [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) veya [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/) kullanın.