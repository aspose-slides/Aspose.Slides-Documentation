---
title: Python Kullanarak Sunumlarda Grafik Eksenlerini Özelleştirme
linktitle: Grafik Eksenleri
type: docs
url: /tr/python-java/chart-axis/
keywords:
- grafik ekseni
- düşey eksen
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
description: "Raporlar ve görselleştirmeler için PowerPoint sunumlarındaki grafik eksenlerini özelleştirmek üzere Aspose.Slides for Python via Java kullanımını keşfedin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Python via Java ile grafik eksenlerini nasıl özelleştireceğinizi açıklar. Hesaplanmış eksen değerleri, grafik satır ve sütunlarının değiştirilmesi, eksen görünürlüğü, kategori etiketi ve işaretçi aralıkları, tarih kategorileri ve biçimlendirme, başlık döndürme, eksen konumlandırma, gösterim birimleri ve logaritmik ölçeklendirme konularını kapsar.

## **Grafikte Dikey Eksenin Azami Değerlerini Almak**

Bir [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) oluşturun ve varsayılan veri ile bir alan grafiği ekleyin. Hesaplanmış eksen değerlerini okumadan önce grafiğin düzeninin güncel olmasını sağlamak için [validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) çağırın.

Eksen sınırları için [getActualMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMaxValue) ve [getActualMinValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinValue), işaret aralıkları için ise [getActualMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnit) ve [getActualMinorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnit) okuyun. Tarih eksenleriyle ilgili zaman birimi ölçekleri için [getActualMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnitScale) ve [getActualMinorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnitScale) kullanılır. Örnek, bu değerleri yerel değişkenlerde saklar ve grafiği kaydeder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getVerticalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getVerticalAxis().getActualMinorUnit()

    major_unit_scale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale()
    minor_unit_scale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale()

    presentation.save("AxisValues_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Eksenler Arasındaki Veriyi Değiştirmek**

Grafik verisinde seriler ve kategorilerin rollerini değiştirmek için [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) kullanın. Her eski kategori bir seri, her eski seri ise bir kategori olur. Bu, verinin nasıl gruplanacağını değiştirir; yatay ve düşey eksenleri değiştirmez. Örnek, satır ve sütunları değiştirmeden önce varsayılan veriyi `Sheet1!A1:D5` aralığına (başlık satırı ve kategori sütunu dahil) bağlamak için [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) kullanır. Dört seri ve üç kategori içeren bir grafik kaydeder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300)
    chart.getChartData().setRange("Sheet1!A1:D5")
    chart.getChartData().switchRowColumn()

    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Bir Eksenin Çizim Sırasını Tersine Çevirmek**

Bir kategori veya değer ekseninin çizim sırasını tersine çevirmek için [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) kullanın. Örneğin, yatay çubuk grafik, proje aşamalarını (Planlama, Geliştirme, Test) çalışma sayfasındaki aynı sırayla üstten alta gösterebilir. Eksenin tersine çevrilmesi çizim yönünü değiştirir; veri sıralamasını veya çalışma kitabı verilerini değiştirmez. Karşılaştırma olarak, [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) seriler ve kategorilerin rollerini değiştirir.

Aşağıdaki örnek, üç aşama ve bir seri içeren bir yatay çubuk grafik oluşturur. Üç slayt kaydeder: normal sıra, ters çevrilmiş kategoriler ve ters çevrilmiş değerler. Her kopya aynı veri kümesini kullanır ve her kopyada sadece bir eksen ters çevrilir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, CrossesType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredBar, 50, 40, 620, 320)
    chart.setLegend(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.ClusteredBar)
    stages = ["Planning", "Development", "Testing"]
    values = [10, 30, 20]
    for i, stage in enumerate(stages):
        category_cell = workbook.getCell(0, i + 1, 0, stage)
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, float(values[i]))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    # 2. slayt: ilk kategoriyi üstte göster.
    category_slide = presentation.getSlides().addClone(slide)
    category_chart = category_slide.getShapes().get_Item(0)
    category_chart.getAxes().getVerticalAxis().setPlotOrderReversed(True)
    # Yatay değer eksenini altta tut.
    category_chart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum)

    # 3. slayt: yalnızca yatay sayısal ölçeği tersine çevir.
    value_slide = presentation.getSlides().addClone(slide)
    value_chart = value_slide.getShapes().get_Item(0)
    value_chart.getAxes().getHorizontalAxis().setPlotOrderReversed(True)

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Bir ekseni ters çevirmek, dik ekseni grafiğin karşı tarafına taşıyabilir. [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType), diğer eksenin yapılandırılan ekseni nerede kestiğini kontrol eder. 2. slaytta, ters çevrilmiş kategori ekseninde [CrossesType.Maximum](https://reference.aspose.com/slides/python-java/aspose.slides/crossestype/#Maximum) kullanmak, yatay değer eksenini altta tutar. Belirli bir kesişim noktası için [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt) kullanın. Yön değiştirirken kesişim ayarlarını kontrol edin; özellikle grafik zaten özel bir kesişim noktasına sahipse. Normal çizim yönünü geri yüklemek için `False` ile [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) çağırın; kesişim ayarları ayrı tutulur.

| Normal sıra (slayt 1) | Ters çevrilmiş kategoriler (slayt 2) | Ters çevrilmiş değerler (slayt 3) |
| --- | --- | --- |
| ![Normal kategori ve değer eksen sırasına sahip yatay çubuk grafik](axis-order-normal.png) | ![Üstten alta gösterilen kategorilere sahip yatay çubuk grafik](axis-order-categories-reversed.png) | ![Sağda sıfırda kesişen ters değer eksenli yatay çubuk grafik](axis-order-values-reversed.png) |
| Kategoriler alttan üste doğru ilerler; değerler soldan sağa artar. | Planlama, Geliştirme ve Test üstten alta doğru ilerler. Değerler ve çalışma kitabı satır sırası değişmez. | Kategoriler normal sırasını korur; değerler sağdan sola artar. Kategori ekseni sağdaki sıfırda kesişir. |

## **Çizgi Grafiklerde Dikey Eksenin Görünürlüğünü Kapatmak**

Dikey ekseni gizlemek için `False` ile [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) çağırın. Örnek, varsayılan veri ile bir çizgi grafik oluşturur ve dik ekseni gizli olarak kaydeder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getVerticalAxis().setVisible(False)

    presentation.save("HiddenVerticalAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Çizgi Grafiklerde Yatay Eksenin Görünürlüğünü Kapatmak**

Yatay ekseni gizlemek için `False` ile [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) çağırın. Örnek, varsayılan veri ile bir çizgi grafik oluşturur ve yatay ekseni gizli olarak kaydeder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getHorizontalAxis().setVisible(False)

    presentation.save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Grafik Izgara Çizgilerini Gösterme veya Gizleme**

Bir eksenin hangi ızgara çizgilerini gösterdiğini kontrol etmek için [getShowMajorGridLines](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getShowMajorGridLines) ve [getShowMinorGridLines](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getShowMinorGridLines) çağırın. Küçük ızgara çizgilerini göstermek için [getMinorGridLinesFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getMinorGridLinesFormat) kullanın ve çizgi doldurmasını katı, görülebilir bir renge ayarlayın. Gizlemek için doldurmayı [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/#NoFill) yapın. Büyük ızgara çizgileri için aynı şekilde çizgi doldurmasını değiştirmek üzere [getMajorGridLinesFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getMajorGridLinesFormat) kullanın. Doldurmanın değiştirilmesi eksen görünürlüğünü ve işaretçileri korur.

Bu kümelenmiş sütun grafikde, düşey eksen başlangıçta yalnızca büyük ızgara çizgilerini gösterir. Örnek, küçük ızgara çizgilerini koyu turuncu renkte gösterir, ardından tekrar gizler ve sunumu kaydeder. Her adımda ızgara çizgisi görünürlüğünü yazdırır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 30, 660, 230)
    axis = chart.getAxes().getVerticalAxis()
    print(f"Initial: major={axis.getShowMajorGridLines()}, minor={axis.getShowMinorGridLines()}")

    minor_fill = axis.getMinorGridLinesFormat().getLine().getFillFormat()
    minor_fill.setFillType(FillType.Solid)
    minor_fill.getSolidFillColor().setColor(Color(255, 140, 0))
    print(f"Enabled: minor={axis.getShowMinorGridLines()}")

    minor_fill.setFillType(FillType.NoFill)
    print(f"Hidden: major={axis.getShowMajorGridLines()}, minor={axis.getShowMinorGridLines()}")

    presentation.save("ChartGridlines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| Küçük ızgara çizgileri etkin | Küçük ızgara çizgileri gizli |
| --- | --- |
| ![Düşey eksende büyük ızgara çizgileri arasında turuncu küçük ızgara çizgileri](minor-gridlines-enabled.png) | ![Sadece büyük ızgara çizgileri görünen aynı sütun grafik](minor-gridlines-hidden.png) |

## **Bir Kategori Eksenini Değiştirmek**

[Tarih veya metin kategori ekseni] seçmek için [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) kullanın. Bu örnek, ilk slayttaki ilk şekil olarak bir grafik içeren `ExistingChart.pptx` dosyasını gerektirir ve kategori hücreleri sayısal Excel tarih değerleri içerir. Yatay ekseni tarih ekseni yapar. [setAutomaticMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMajorUnit) `False`, [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) `1` ve [setMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnitScale) [TimeUnitType.Months](https://reference.aspose.com/slides/python-java/aspose.slides/timeunittype/#Months) ile büyük işaretçileri bir ay aralığına ayarlar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, CategoryAxisType, TimeUnitType

presentation = Presentation("ExistingChart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().get_Item(0)
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getHorizontalAxis().setMajorUnit(1)
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months)

    presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Veriden Kategori Eksen Türünü Belirlemek**

Kategorileri doldurduktan sonra [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisTypeAutomatically) çağırın, ardından seçimi incelemek için [getCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getCategoryAxisType) okuyun. Aynı grafik metin etiketleri ya da sayısal tarih değerleri alabileceğinde bu yararlıdır. Yöntem çağrıldığında türü belirler; daha sonraki veri değişikliklerini yeniden değerlendiren kalıcı bir modu etkinleştirmez. Kategorileri değiştirdikten sonra tekrar çağırın.

Aşağıdaki örnek, metin kategorileriyle bir grafik oluşturur ve seçilen tür [CategoryAxisType.Text](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Text) olduğunda `True` yazdırır. Ardından kategori hücre değerlerini tarihlerle değiştirir ve yöntemi tekrar çağırarak seçilen tür [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date) olduğunda `True` yazdırır. Tarihler sayısal OLE Automation değerleri olarak depolanır; 30 Aralık 1899’dan itibaren gün sayısıdır, tarih dizgileri değildir. [setCustomNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setCustomNumberFormat) bu değerlerin nasıl gösterileceğini kontrol eder; metni sayısal tarihlere dönüştürmez. Kategori hücreleri hakkında daha fazla bilgi için [Chart Workbook](/slides/tr/python-java/chart-workbook/) bölümüne bakın.

Girişin yalnızca metin kategorileri ya da sayısal tarihler içerdiği biliniyorsa otomatik belirlemeyi kullanın. Normal sayısal etiketler, karışık kategoriler veya boş veri için, istenen anlamı yansıtmak üzere açıkça [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) çağırın. Yalnız sayısal değerlerin bulunması, kategorilerin tarih olduğu anlamına gelmez.

```python
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, CategoryAxisType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series_name = workbook.getCell(0, 0, 1, "Sales")
    series = chart.getChartData().getSeries().add(series_name, chart.getType())
    labels = ["First", "Second", "Third"]

    for i, label in enumerate(labels):
        category_cell = workbook.getCell(0, i + 1, 0, label)
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, float((i + 1) * 10))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    axis = chart.getAxes().getHorizontalAxis()
    axis.setCategoryAxisTypeAutomatically()
    print(axis.getCategoryAxisType() == CategoryAxisType.Text)  # Doğru

    base_date = date(1899, 12, 30)
    dates = [date(2026, 1, 1), date(2026, 1, 2), date(2026, 2, 1)]

    for i, category_date in enumerate(dates):
        category_cell = workbook.getCell(0, i + 1, 0)
        category_cell.setValue(float((category_date - base_date).days))
        category_cell.setCustomNumberFormat("yyyy-mm-dd")

    axis.setCategoryAxisTypeAutomatically()
    print(axis.getCategoryAxisType() == CategoryAxisType.Date)  # Doğru

    presentation.save("AutomaticCategoryAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Kategori Eksen Etiket Aralıklarını Kontrol Etmek**

Bir grafikte çok sayıda kategori olduğunda, kategori sayısını ve veri noktalarını kaldırmadan görünür eksen etiketlerinin sayısını azaltın. Önce [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickLabelSpacing) `False` ile kapatın, ardından istenen kategori aralığını [setTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelSpacing) ile geçirin. Normal sıralı metin kategorileri için sayma ilk kategoriden başlar:

| Aralık | Örnekte görüntülenen etiketler |
| --- | --- |
| `1` | Kategori 1, Kategori 2, Kategori 3, ... Kategori 24 |
| `2` | Kategori 1, Kategori 3, Kategori 5, ... Kategori 23 |
| `3` | Kategori 1, Kategori 4, Kategori 7, ... Kategori 22 |

`3` aralığı her üçüncü etiketi gösterir, görüntülenen etiketlerin arasında iki etiket gizli kalır. İlgili sütunlar kaldırılmaz. Otomatik aralık, kullanılabilir alana göre bir aralık seçer; her etiketi mutlaka göstermez.

İşaretçilerin (tick marks) ayrı kontrolleri vardır. Önce [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickMarksSpacing) `False` ile kapatın ve ardından [setTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickMarksSpacing) ile aralıklarını ayarlayın. Örneğin, `1` her kategori aralığında bir işaretçi bırakırken etiketler yalnız her üçüncü kategoride gösterilir. Görünür bir stil kullanarak [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) çağırın. Otomatik‑aralık ayarını tekrar `True` yaparsanız grafik yeniden aralığı seçer.

Aşağıdaki bağımsız örnek, 24 kategori ve bir seri oluşturur, ardından `CategoryAxisIntervals.pptx` içinde üç slayt kaydeder: otomatik aralık, bağımsız işaretçili manuel etiket aralığı ve otomatik aralığa geri dönüş. İki kopya orijinal grafik verisini korur. Giriş sunumu gerekli değildir. Yatay etiket metni, yoğunluk farkını görmeyi kolaylaştırır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType, TickMarkType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320)

    chart.setLegend(False)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.ClusteredColumn)
    for i in range(24):
        category_cell = workbook.getCell(0, i + 1, 0, f"Category {i + 1}")
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, float(10 + i % 6 * 5))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    axis = chart.getAxes().getHorizontalAxis()
    axis.setCategoryAxisType(CategoryAxisType.Text)
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0)
    axis.getTextFormat().getPortionFormat().setFontHeight(12)
    axis.setMajorTickMark(TickMarkType.Outside)
    axis.setAutomaticTickLabelSpacing(True)
    axis.setAutomaticTickMarksSpacing(True)

    # 2. slayt: her üçüncü etiketi göster, ancak her kategori için bir işaretçi tut.
    manual_slide = presentation.getSlides().addClone(slide)
    manual_chart = manual_slide.getShapes().get_Item(0)
    manual_axis = manual_chart.getAxes().getHorizontalAxis()
    manual_axis.setAutomaticTickLabelSpacing(False)
    manual_axis.setTickLabelSpacing(3)
    manual_axis.setAutomaticTickMarksSpacing(False)
    manual_axis.setTickMarksSpacing(1)

    # 3. slayt: grafiğin her iki aralığı da yeniden seçmesine izin ver.
    restored_slide = presentation.getSlides().addClone(manual_slide)
    restored_chart = restored_slide.getShapes().get_Item(0)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(True)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(True)

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Otomatik aralık (slayt 1):** Bu görünümde her ikinci kategori etiketi görüntülenir ve iki satıra sarılır. Otomatik sonuç grafik boyutu, yazı tipleri ve renderlayıcıya göre değişebilir.

![Tüm 24 sütun görünürken otomatik kategori etiketi aralığı](category-axis-automatic.png)

**Manuel aralık (slayt 2):** Her üçüncü etiket tek satırda görüntülenir, işaretçiler ise her kategori aralığında kalır. Etiketsiz olanlar dahil olmak üzere tüm 24 sütun aynı değerlerle görünür. 3. slayt, yukarıdaki otomatik görünümü geri yükler.

![Tüm 24 sütun görünürken üçlü manuel kategori etiketi aralığı](category-axis-manual.png)

### **Doğru Eksen ve Aralığı Seçmek**

Metin kategori ekseni kullanan bir grafik (sütun, çizgi, alan veya çubuk grafik) için bu kategori‑sayım aralığını kullanın. Sütun grafikinde bu, yatay eksendir. Yatay çubuk grafikinde kategori ekseni düşeydedir; bu ayarları [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis) ile dönen eksene uygulayın. İşaret aralığı, bir serinin eksenine sahip grafiklerde de geçerlidir.

Değer ekseninin sayısal ölçeğini ayarlamak için kategori etiketi aralığını kullanmayın. Değer ekseninde [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) bir değer farkını belirtir: örneğin `10` bir birim, eksen sıfırdan başlıyorsa 0, 10, 20 … noktalarında işaretçi oluşturur. `3` kategori etiketi aralığı ise veri değerlerinden bağımsız olarak kategori konumlarını sayar. Dağılım ve balon grafikler metin kategori ekseni yerine değer eksenleri kullanır. Tarih ekseni için, [Kategori Eksenini Değiştirmek](#change-a-category-axis) bölümünde açıklandığı gibi zaman‑tabanlı birim ve ölçek kullanın.

## **Kategori Eksen Değerleri için Tarih Biçimini Ayarlamak**

Örnek, varsayılan grafik verisini dört yıllık değerle değiştirir. Tarihler, ilk çalışma sayfasında (indeks `0`) OLE Automation seri sayıları olarak depolanır; bu sayılar, 30 Aralık 1899’dan itibaren geçen gün sayısıdır. [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) ile [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date) seçin, ardından [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) `False` ve `yyyy` değerini [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) içine gönderin; böylece kategori etiketleri hücre biçiminden bağımsız olarak dört haneli yıl gösterir.

```python
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    base_date = date(1899, 12, 30)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    for i in range(4):
        category_date = date(2015 + i, 1, 1)
        category_value = float((category_date - base_date).days)
        category_cell = workbook.getCell(0, i + 1, 0, category_value)
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, float(i + 1))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy")

    presentation.save("DateAxisFormat.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Grafik Eksen Başlığı için Döndürme Açısı Ayarlamak**

Dikey eksende başlığı etkinleştirmek için `True` ile [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTitle) çağırın, başlık metnini sağlayın ve başlığın metin bloğu biçiminde döndürme açısını ayarlayın. Açı derece cinsindendir; bu örnek, değer ekseni başlığını 90 derece döndürmüş bir sütun grafik kaydeder.

```python
import jpype
import asposeslides

if not jpime.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value")
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90)

    presentation.save("RotatedAxisTitle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Kategori veya Değer Ekseninde Eksen Konumunu Ayarlamak**

Değer ekseninin kategori eksenini kategoriler arasında mı yoksa kategori işaretçileri üzerinde mi kestiğini kontrol etmek için [setAxisBetweenCategories](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAxisBetweenCategories) kullanın. Bu ayar yalnız kategori eksenlerine uygulanır. Örnek, bir sütun grafiğin yatay kategori ekseninde `True` olarak ayarlar ve sonucu kaydeder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(True)

    presentation.save("AxisBetweenCategories.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Grafik Değer Ekseninde Gösterim Birimini Ayarlamak**

Değer eksenindeki etiketleri temel veriyi değiştirmeden ölçeklendirmek için [setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) kullanın. [DisplayUnitType](https://reference.aspose.com/slides/python-java/aspose.slides/displayunittype/) `Millions` olarak ayarlandığında, 60 000 000 değeri 60 olarak gösterilir. Örnek, bir sütun grafik oluşturur ve dik eksenine milyon gösterim birimini uygular.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, DisplayUnitType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions)

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Logaritmik Değer Eksenini Yapılandırmak**

Pozitif değerler birkaç büyüklük derecesine yayıldığında logaritmik değer ekseni kullanışlıdır. Örneğin, bir hizmet beş dönemde 10, 100, 1 000, 10 000 ve 100 000 istek alabilir. Doğrusal ölçekle, küçük değerler sıfıra yakın bir arada görünür. Logaritmik ölçek, göreceli büyümeyi karşılaştırmayı kolaylaştırır: eşit mesafeler eşit oranları temsil eder, eşit farkları değil.

Değer ekseninde `True` ile [setLogarithmic](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogarithmic) çağırın ve tabanı seçmek için [setLogBase](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogBase) kullanın. Bu, mevcut değerlerin gösterimini değiştirir; veriyi değiştirmez ve logaritmik bir eğilim çizgisi eklemez. Eğilim çizgisi, verideki ilişkiyi uyduran ayrı bir özelliktir.

### **Değer Eksenini ve Tabanı Seçmek**

Çizgi veya sütun grafiğinde değer ekseni, [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis) ile döner. Yatay çubuk grafiğinde ise [getHorizontalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getHorizontalAxis) döner. Dağılım ve balon grafiklerde iki değer ekseni bulunur; X değerleri için yatay ekseni, Y değerleri için düşey ekseni veya ikisini de seçin. Kategori eksenine logaritmik ölçek uygulamayın.

Varsayılan logaritmik taban `10`dır. PPTX grafiklerde taban `2` ile `1000` arasında (dahil) bir değer olmalıdır; `2.5` gibi kesirli tabanlar da desteklenir. `10` tabanında, 10, 100, 1 000 ve 10 000 gibi ardışık katlar eşit aralıklıdır.

### **Doğrusal ve Logaritmik Ölçekleri Karşılaştırmak**

Aşağıdaki bağımsız örnek, ilk slaytta beş istek sayısını içeren bir çizgi grafik oluşturur, ardından bu slaytı klonlar ve ikinci slaytta 10 tabanlı logaritmik değer ekseni etkinleştirir. Her iki slayt da aynı veriyi korur.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 30, 40, 660, 200)

    chart.setLegend(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    values = [10, 100, 1000, 10000, 100000]

    for i, value in enumerate(values):
        category_cell = workbook.getCell(0, i + 1, 0, f"Period {i + 1}")
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, float(value))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    # İlk slaytı doğrusal tut ve yalnızca kopyanın değer ekseni ölçeğini değiştir.
    logarithmic_slide = presentation.getSlides().addClone(slide)
    logarithmic_chart = logarithmic_slide.getShapes().get_Item(0)
    value_axis = logarithmic_chart.getAxes().getVerticalAxis()
    value_axis.setLogarithmic(True)
    value_axis.setLogBase(10)

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Doğrusal ölçek (slayt 1):** Eşit düşey mesafeler istek sayısındaki eşit farkları temsil eder. En büyük değer grafiği domine eder, küçük değerleri ayırt etmeyi zorlaştırır.

![Doğrusal değer ekseninde beş istek sayısını gösteren PowerPoint çizgi grafik](value-axis-linear.png)

**Logaritmik ölçek (slayt 2):** Eşit düşey mesafeler eşit oranları temsil eder. Her dönem, bir önceki dönemin on katı isteğe sahiptir; bu yüzden noktalar 10 tabanlı ölçek üzerinde düz bir yükselen çizgi oluşturur. Eksen etiketleri hâlâ orijinal istek sayılarını gösterir.

![PowerPoint'te 10 tabanlı logaritmik değer ekseninde aynı beş istek sayısı](value-axis-logarithmic.png)

### **Sıfır ve Negatif Değerleri Ele Almak**

Logaritmik ölçek yalnızca kesin pozitif değerleri gösterebilir. Etkinleştirmeden önce veriyi kontrol edin. Sıfır veya negatif değerler anlamlıysa, doğrusal ölçeği tutun veya ayrı olarak gösterin. Bu değerleri analiz için dışlamak uygun ise nedeni açıklayın. Küçük pozitif sayılarla sessizce değiştirmeyin; bu veri anlamını değiştirir. Logaritmik eksen için manuel ayarlanan minimum ya da maksimum da pozitif olmalıdır.

## **SSS**

**Bir eksenin diğerini nerede kestiği (ekseni kesişim) değerini nasıl ayarlarım?**

Kesişme davranışını seçmek için [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) kullanın. Sayısal bir kesişim değeri belirtmek için [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt) kullanın. Bu ayarlar eksen kesişimini uygun bir temel çizgisine taşımanıza olanak tanır.

**İşaret etiketi konumunu eksene göre nasıl konumlandırabilirim?**

[TickLabelPositionType](https://reference.aspose.com/slides/python-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` veya `None` kullanarak [setTickLabelPosition](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelPosition) çağırın. İşaretçilerin kendisini kontrol etmek için [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) veya [setMinorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMinorTickMark) kullanın; bunlar etiket konumlandırmadan ayrı özelliklerdir.