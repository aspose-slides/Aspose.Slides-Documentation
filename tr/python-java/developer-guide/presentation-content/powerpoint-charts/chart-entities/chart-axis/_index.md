---
title: Python Kullanarak Sunumlarda Grafik Eksenlerini Özelleştirme
linktitle: Grafik Ekseni
type: docs
url: /tr/python-java/chart-axis/
keywords:
- grafik ekseni
- dikey eksen
- yatay eksen
- eksen özelleştir
- eksen üzerinde işlem yap
- eksen yönet
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

Bu makale, Aspose.Slides for Python via Java ile grafik eksenlerini nasıl özelleştireceğinizi açıklar. Hesaplanan eksen değerleri, grafik satır ve sütunlarının değiştirilmesi, eksen görünürlüğü, kategori etiketi ve tik işareti aralıkları, tarih kategorileri ve biçimlendirme, başlık döndürme, eksen konumlandırma, gösterim birimleri ve logaritmik ölçeklendirme konularını kapsar.

## **Bir Grafiğin Dikey Eksenindeki Azami Değerleri Almak**

Bir [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) oluşturun ve varsayılan verilerle bir alan grafiği ekleyin. Hesaplanan eksen değerlerini okumadan önce grafiğin düzeninin güncel olması için [validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) metodunu çağırın.

Eksen sınırları için [getActualMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMaxValue) ve [getActualMinValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinValue) metodlarını, tik aralıkları için [getActualMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnit) ve [getActualMinorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnit) metodlarını okuyun. [getActualMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnitScale) ve [getActualMinorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnitScale) tarih eksenleriyle ilgili zaman birimi ölçeklerini sağlar. Örnek bu değerleri yerel değişkenlere saklar ve grafiği kaydeder.

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

## **Eksenler Arasındaki Verileri Değiştir**

[switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) metodunu kullanarak grafik verilerinde serilerin ve kategorilerin rollerini değiştirin. Her eski kategori bir seri, her eski seri bir kategori olur. Bu, verilerin gruplanma şeklini değiştirir; yatay ve dikey eksenleri değiştirmez. Örnek satır ve sütunları değiştirmeden önce varsayılan verileri `Sheet1!A1:D5` aralığına bağlamak için [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) metodunu kullanır; başlık satırı ve kategori sütunu dahildir. Dört seri ve üç kategori içeren bir grafik kaydeder.

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

## **Bir Eksenin Çizim Sırasını Tersine Çevir**

[setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) metodunu kullanarak bir kategori veya değer eksenini tersine çevirin. Örneğin, yatay çubuk grafik, proje aşamalarını çalışma sayfasındaki aynı sırayla üstten alta gösterebilir: Planlama, Geliştirme, Test. Bir ekseni tersine çevirmek çizim yönünü değiştirir; çalışma kitabı verilerini sıralamaz veya yeniden düzenlemez. Buna karşılık, [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) serilerin ve kategorilerin rollerini değiştirir.

Aşağıdaki örnek, üç aşama ve bir seri içeren yatay çubuk grafik oluşturur. Normal sıra, ters kategoriler ve ters değerler olmak üzere üç slaytlı bir sunum kaydeder. Her kopya aynı veri kümesini kullanır ve her kopyada yalnızca bir eksen ters çevrilir.

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

    # Slayt 2: ilk kategoriyi üstte göster.
    category_slide = presentation.getSlides().addClone(slide)
    category_chart = category_slide.getShapes().get_Item(0)
    category_chart.getAxes().getVerticalAxis().setPlotOrderReversed(True)
    # Yatay değer eksenini altta tut.
    category_chart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum)

    # Slayt 3: yalnızca yatay sayısal ölçeği ters çevir.
    value_slide = presentation.getSlides().addClone(slide)
    value_chart = value_slide.getShapes().get_Item(0)
    value_chart.getAxes().getHorizontalAxis().setPlotOrderReversed(True)

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ters bir eksen, dik ekseni çizimin karşı tarafına taşıyabilir. [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) diğer eksenin yapılandırılan ekseni nerede kestiğini kontrol eder. 2. slaytta, ters kategori ekseninde [CrossesType.Maximum](https://reference.aspose.com/slides/python-java/aspose.slides/crossestype/#Maximum) ile çağırmak yatay değer eksenini altta tutar. Belirli bir kesişme noktası için [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt) kullanın. Yön değiştirirken, özellikle grafik zaten özel bir kesişme noktasına sahipse, kesişme ayarlarını kontrol edin. Normal çizim yönünü geri getirmek için [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) metodunu `False` ile çağırın; kesişme ayarları ayrı tutulur.

| Normal sıra (slayt 1) | Ters kategoriler (slayt 2) | Ters değerler (slayt 3) |
| --- | --- | --- |
| ![Normal kategori ve değer ekseni sırasına sahip yatay çubuk grafik](axis-order-normal.png) | ![Kategorilerin üstten alta gösterildiği yatay çubuk grafik](axis-order-categories-reversed.png) | ![Ters değer ekseni ve sağda sıfır olan yatay çubuk grafik](axis-order-values-reversed.png) |
| Kategoriler altardan üste yürür; değerler soldan sağa artar. | Planlama, Geliştirme ve Test üstten alta yürür. Değerler ve çalışma kitabı satır sırası değişmez. | Kategoriler normal sırasını korur; değerler sağdan sola artar. Kategori ekseni sağda sıfırda kesişir. |

## **Çizgi Grafiklerde Dikey Ekseni Devre Dışı Bırak**

Dikey ekseni gizlemek için [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) metodunu `False` ile çağırın. Örnek varsayılan verilerle bir çizgi grafik oluşturur ve dik eksen gizli olarak kaydeder.

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

## **Çizgi Grafiklerde Yatay Ekseni Devre Dışı Bırak**

Yatay ekseni gizlemek için [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) metodunu `False` ile çağırın. Örnek varsayılan verilerle bir çizgi grafik oluşturur ve yatay eksen gizli olarak kaydeder.

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

## **Bir Kategori Eksenini Değiştir**

[setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) metodunu kullanarak tarih veya metin kategori ekseni seçin. Bu örnek `ExistingChart.pptx` dosyasını gerektirir; ilk slayttaki ilk şekil bir grafik ve kategori hücreleri sayısal Excel tarih değerleri içerir. Yatay ekseni tarih ekseni olarak değiştirir. [setAutomaticMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMajorUnit) `False`, [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) `1` ve [setMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnitScale) ile [TimeUnitType.Months](https://reference.aspose.com/slides/python-java/aspose.slides/timeunittype/#Months) kullanmak ana tikleri bir aylık aralıklarla yerleştirir.

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

## **Kategori Eksen Etiketi Aralıklarını Kontrol Et**

Bir grafikte birçok kategori olduğunda, kategori veya veri noktalarını kaldırmadan görünür eksen etiketlerinin sayısını azaltın. [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickLabelSpacing) metodunu `False` ile çağırın, ardından istediğiniz kategori aralığını [setTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelSpacing) metoduna geçirin. Normal sıradaki metin kategorileri için sayım ilk kategoriden başlar:

| Aralık | Örnekte görüntülenen etiketler |
| --- | --- |
| `1` | Kategori 1, Kategori 2, Kategori 3, ... Kategori 24 |
| `2` | Kategori 1, Kategori 3, Kategori 5, ... Kategori 23 |
| `3` | Kategori 1, Kategori 4, Kategori 7, ... Kategori 22 |

`3` aralığı her üçüncü etiketi gösterir, gösterilen etiketler arasında iki etiket gizli kalır. İlgili sütunları kaldırmaz. Otomatik aralık, mevcut alana göre bir aralık seçer; her etiketi mutlaka göstermez.

Tik işaretlerinin ayrı kontrolleri vardır. [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickMarksSpacing) metodunu `False` ile çağırın ve aralıklarını ayarlamak için [setTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickMarksSpacing) yöntemini kullanın. Örneğin, `1` her kategori aralığında bir tik işareti tutarken etiketler sadece her üçüncü kategoride görünür. Görünür bir stil ile [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) kullanarak sonucu görebilirsiniz. Otomatik aralık ayarlarından birini `True` yaparak grafiğin yeniden o aralığı seçmesine izin verilir.

Aşağıdaki bağımsız örnek, 24 kategori ve bir seri oluşturur, ardından `CategoryAxisIntervals.pptx` içinde üç slayt kaydeder: otomatik aralık, bağımsız tik işaretleriyle manuel etiket aralığı ve yeniden otomatik aralık. İki kopya orijinal grafik verilerini korur. Giriş sunumu gerektirmez. Yatay etiket metni, yoğunluktaki farkı görmeyi kolaylaştırır.

```python
import jpime
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

    # Slide 2: her üçüncü etiketi göster, ancak her kategori için bir tik işareti tut.
    manual_slide = presentation.getSlides().addClone(slide)
    manual_chart = manual_slide.getShapes().get_Item(0)
    manual_axis = manual_chart.getAxes().getHorizontalAxis()
    manual_axis.setAutomaticTickLabelSpacing(False)
    manual_axis.setTickLabelSpacing(3)
    manual_axis.setAutomaticTickMarksSpacing(False)
    manual_axis.setTickMarksSpacing(1)

    # Slide 3: grafiğin her iki aralığı da yeniden seçmesine izin ver.
    restored_slide = presentation.getSlides().addClone(manual_slide)
    restored_chart = restored_slide.getShapes().get_Item(0)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(True)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(True)

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Otomatik aralık (slayt 1):** Bu görüntüde, her ikinci kategori etiketi gösterilir ve iki satıra kaydırılır. Otomatik sonuç grafik boyutu, yazı tipleri ve işleyiciye bağlı olarak değişebilir.

![Tüm 24 sütun görünürken otomatik kategori etiketi aralığı](category-axis-automatic.png)

**Manuel aralık (slayt 2):** Her üçüncü etiket tek satırda gösterilir, tik işaretleri ise her kategori aralığında kalır. Etiketsiz olanlar dahil tüm 24 sütun aynı değerlerle görünür. 3. slayt yukarıdaki otomatik görünümü geri getirir.

![Tüm 24 sütun görünürken üçlü manuel kategori etiketi aralığı](category-axis-manual.png)

### **Doğru Eksen ve Aralığı Seç**

Bu kategori sayısı aralığını, bir sütun, çizgi, alan veya çubuk grafiğin kategori ekseni gibi metin kategori ekseni için kullanın. Sütun grafiğinde yatay eksen, yatay çubuk grafiğinde ise kategori ekseni dik olduğundan, bu ayarları [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis) tarafından döndürülen eksene uygulayın. Tik işareti aralığı, bir seriye sahip grafiklerde seri eksenine de uygulanır.

Kategori etiketi aralığını bir değer ekseninin sayısal ölçeğini ayarlamak için kullanmayın. Değer ekseninde, [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) bir değer farkı belirler: örneğin, `10` birim, eksen sıfırdan başladığında 0, 10, 20 vb. noktalarda tik oluşturur. `3` bir kategori etiketi aralığı, veri değerlerinden bağımsız olarak kategori konumlarını sayar. Dağılım ve balon grafikleri metin kategori ekseni yerine değer eksenleri kullanır. Tarih ekseni için, [Change a Category Axis](#change-a-category-axis) bölümünde açıklandığı gibi zaman temelli ana birimler ve ölçekler kullanın.

## **Kategori Eksen Değerleri İçin Tarih Biçimini Ayarla**

Örnek, varsayılan grafik verilerini dört yıllık değerle değiştirir. Tarihler, ilk çalışma sayfasında (indeks `0`) OLE Automation seri numaraları olarak saklanır; bu tarihler 30 Aralık 1899'dan itibaren gün sayısı olarak hesaplanır. [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) metodunu [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date) ile kullanın, [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) metodunu `False` ile çağırın ve kategori etiketlerinin hücre biçiminden bağımsız olarak dört basamaklı yıl göstermesi için `yyyy` değerini [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) metoduna geçirin.

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

## **Grafik Eksen Başlığı İçin Döndürme Açısı Ayarla**

Dikey eksende [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTitle) metodunu `True` ile çağırın, başlık metnini sağlayın ve başlığın metin bloğu biçimlendirmesinde döndürme açısını ayarlayın. Açı derece cinsindendir; bu örnek, değer ekseni başlığı 90 derece döndürülmüş bir sütun grafik kaydeder.

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
    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value")
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90)

    presentation.save("RotatedAxisTitle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Kategori veya Değer Ekseninde Eksen Konumunu Ayarla**

[setAxisBetweenCategories](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAxisBetweenCategories) metodunu kullanarak değer ekseninin kategori eksenini kategoriler arasında mı yoksa kategori tik işaretlerinde mi kestiğini kontrol edin. Bu ayar kategori eksenlerine uygulanır. Örnek, bir sütun grafiğinin yatay kategori ekseninde bunu `True` olarak ayarlar ve sonucu kaydeder.

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

## **Grafik Değer Ekseninde Gösterim Birimini Ayarla**

[setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) metodunu, temel verileri değiştirmeden bir değer eksenindeki etiketleri ölçeklendirmek için kullanın. [DisplayUnitType](https://reference.aspose.com/slides/python-java/aspose.slides/displayunittype/) `Millions` olarak ayarlandığında, 60.000.000 değeri 60 olarak gösterilir. Örnek bir sütun grafik oluşturur ve dik eksenine milyon gösterim birimini uygular.

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

## **Logaritmik Değer Ekseni Yapılandırma**

Pozitif değerler birkaç mertebe boyunca genişlediğinde logaritmik değer ekseni faydalıdır. Örneğin, bir hizmet beş dönemde 10, 100, 1.000, 10.000 ve 100.000 istek alabilir. Doğrusal ölçekte, küçük değerler sıfıra yakın bir arada görünür. Logaritmik ölçek, göreceli büyümeyi karşılaştırmayı kolaylaştırır: eşit mesafeler eşit oranları, eşit farkları değil temsil eder.

Değer ekseninde [setLogarithmic](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogarithmic) metodunu `True` ile çağırın ve tabanı seçmek için [setLogBase](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogBase) metodunu kullanın. Bu, mevcut değerlerin nasıl gösterildiğini değiştirir; verileri değiştirmez veya logaritmik bir trend çizgisi eklemez. Trend çizgisi, verilerdeki uyarlanmış bir ilişkiyi temsil eder ve ayrı bir özelliktir.

### **Değer Ekseni ve Tabanı Seç**

Çizgi veya sütun grafiğinde değer ekseni [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis) tarafından döndürülür. Yatay çubuk grafiğinde ise [getHorizontalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getHorizontalAxis) tarafından döndürülür. Dağılım ve balon grafiklerde iki değer ekseni vardır; X değerleri için yatay ekseni, Y değerleri için dik ekseni veya her ikisini seçin. Bir kategori eksenine logaritmik ölçek uygulamayın.

Varsayılan logaritmik taban `10`'dur. PPTX grafiklerinde, `2` ile `1000` arasında (dahil) bir taban kullanın; `2.5` gibi kesirli bazlar da desteklenir. `10` tabanı ile ardışık katlar 10, 100, 1.000 ve 10.000 eşit aralıklarla yer alır.

### **Doğrusal ve Logaritmik Ölçekleme Karşılaştırması**

Aşağıdaki bağımsız örnek, ilk slaytta beş istek sayısıyla bir çizgi grafik oluşturur, ardından bu slaytı kopyalar ve ikinci slaytta taban-10 logaritmik değer eksenini etkinleştirir. Her iki slayt da aynı veriyi korur.

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

**Doğrusal ölçek (slayt 1):** Eşit dikey mesafeler istek sayısındaki eşit farkları temsil eder. En büyük değer grafiği domine eder, daha küçük değerleri ayırt etmeyi zorlaştırır.

![Doğrusal değer ekseninde beş istek sayısını gösteren PowerPoint çizgi grafiği](value-axis-linear.png)

**Logaritmik ölçek (slayt 2):** Eşit dikey mesafeler eşit oranları temsil eder. Her dönem, bir önceki döneme göre on kat daha fazla istek alır; bu yüzden noktalar taban-10 ölçeğinde düz bir yükselen hat oluşturur. Eksen etiketleri hâlâ orijinal istek sayılarını gösterir.

![PowerPoint'te aynı beş istek sayısının taban-10 logaritmik değer ekseninde gösterimi](value-axis-logarithmic.png)

### **Sıfır ve Negatif Değerlerle Baş et**

Logaritmik ölçek yalnızca kesinlikle pozitif değerleri gösterebilir. Etkinleştirmeden önce verileri kontrol edin. Sıfır veya negatif değerler anlamlıysa, doğrusal ölçek tutun veya bunları ayrı gösterin. Analiz için bu değerleri dışlamak uygun ise, eksikliği açıklayın. Verileri sessizce küçük pozitif sayılarla değiştirmeyin; bu, verinin anlamını değiştirir. Logaritmik eksen için manuel olarak ayarlanan herhangi bir minimum veya maksimum da pozitif olmalıdır.

## **SSS**

**Bir eksenin diğerini kestiği değeri (ekseni kesişim) nasıl ayarlarım?**  
[setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) metodunu kullanarak kesişim davranışını seçin. Sayısal bir kesişim değeri belirtmek için [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt) metodunu kullanın; bu ayarlar eksen kesişimini uygun bir temel çizgiye taşımanıza izin verir.

**Tik etiketlerini eksene göre nasıl konumlandırabilirim?**  
[setTickLabelPosition](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelPosition) metodunu [TickLabelPositionType](https://reference.aspose.com/slides/python-java/aspose.slides/ticklabelpositiontype/) kullanarak çağırın: `Low`, `High`, `NextTo` veya `None`. Tik işaretlerini kontrol etmek için [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) veya [setMinorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMinorTickMark) metodlarını kullanın; bunlar etiket konumlandırmasından ayrı.