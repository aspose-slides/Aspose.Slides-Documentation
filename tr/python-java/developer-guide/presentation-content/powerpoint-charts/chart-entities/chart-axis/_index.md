---
title: Python Kullanarak Sunumlarda Grafik Eksenlerini Özelleştirme
linktitle: Grafik Ekseni
type: docs
url: /tr/python-java/chart-axis/
keywords:
- grafik ekseni
- dikey eksen
- yatay eksen
- ekseni özelleştir
- ekseni yönet
- ekseni kontrol et
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

Bu makale, Aspose.Slides for Python via Java ile grafik eksenlerini nasıl özelleştireceğinizi açıklar. Hesaplanmış eksen değerleri, grafik satır ve sütunlarının değiştirilmesi, eksen görünürlüğü, kategori etiketi ve işaret aralıkları, tarih kategorileri ve biçimlendirme, başlık döndürme, eksen konumlandırma ve görüntü birimleri konularını kapsar.

## **Bir Grafiğin Dikey Ekseni Üzerindeki En Büyük Değerleri Almak**

[Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) oluşturun ve varsayılan verilerle bir alan grafiği ekleyin. Hesaplanmış eksen değerlerini okumadan önce grafik düzeninin güncel olduğundan emin olmak için [validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) çağırın.

Eksen sınırları için [getActualMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMaxValue) ve [getActualMinValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinValue) okuyun ve işaret aralıkları için [getActualMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnit) ve [getActualMinorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnit) kullanın. Tarih eksenleriyle ilgili zaman birimi ölçekleri için [getActualMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnitScale) ve [getActualMinorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnitScale) sağlayın. Örnek bu değerleri yerel değişkenlerde saklar ve grafiği kaydeder.

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

## **Verileri Eksenler Arasında Değiştirmek**

Grafik verilerinde seriler ve kategorilerin rollerini takas etmek için [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) kullanın. Her eski kategori bir seri, her eski seri ise bir kategori olur. Bu, verilerin nasıl gruplanacağını değiştirir; yatay ve dikey eksenleri değiştirmez. Örnek, satır ve sütunları değiştirmeden önce [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) ile varsayılan verileri `Sheet1!A1:D5` adresine, başlık satırı ve kategori sütununu dahil ederek bağlar. Dört seri ve üç kategori içeren bir grafik kaydeder.

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

## **Çizgi Grafiklerde Dikey Ekseni Devre Dışı Bırakmak**

Dikey ekseni gizlemek için `False` değeriyle [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) çağırın. Örnek, varsayılan verilerle bir çizgi grafik oluşturur ve dikey eksen gizli olarak kaydeder.

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

## **Çizgi Grafiklerde Yatay Ekseni Devre Dışı Bırakmak**

Yatay ekseni gizlemek için `False` değeriyle [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) çağırın. Örnek, varsayılan verilerle bir çizgi grafik oluşturur ve yatay eksen gizli olarak kaydeder.

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

## **Bir Kategori Eksenini Değiştirmek**

Tarih ya da metin kategori ekseni seçmek için [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) kullanın. Bu örnek, ilk slayttaki ilk şekil olarak bir grafik içeren `ExistingChart.pptx` dosyasını gerektirir; kategori hücreleri sayısal Excel tarih değerleri içerir. Yatay ekseni bir tarih ekseni olarak değiştirir. [setAutomaticMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMajorUnit) ile `False`, [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) ile `1` ve [setMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnitScale) ile [TimeUnitType.Months](https://reference.aspose.com/slides/python-java/aspose.slides/timeunittype/#Months) ayarlamak, ana işaretçileri bir ay aralıklarıyla yerleştirir.

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

## **Kategori Ekseni Etiketi Aralıklarını Kontrol Etmek**

Bir grafikte birçok kategori olduğunda, kategorileri veya veri noktalarını kaldırmadan görünür eksen etiketlerinin sayısını azaltın. [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickLabelSpacing) ile `False` çağırın, ardından istenen kategori aralığını [setTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelSpacing) ile geçirin. Normal sıradaki metin kategorileri için sayma ilk kategoriden başlar:

| Aralık | Örnekte gösterilen etiketler |
| --- | --- |
| `1` | Kategori 1, Kategori 2, Kategori 3, ... Kategori 24 |
| `2` | Kategori 1, Kategori 3, Kategori 5, ... Kategori 23 |
| `3` | Kategori 1, Kategori 4, Kategori 7, ... Kategori 22 |

`3` aralığı her üçüncü etiketi gösterir; görüntülenen etiketler arasında iki etiket gizlenir. İlgili sütunlar kaldırılmaz. Otomatik aralık, mevcut alana göre bir aralık seçer; her etiketi göstermeyebilir.

İşaretçilerin ayrı kontrolleri vardır. [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickMarksSpacing) ile `False` ve ardından [setTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickMarksSpacing) ile aralığını ayarlayın. Örneğin, `1` her kategori aralığında bir işaretçi bırakırken etiketler yalnızca her üçüncü kategoride görünür. Görünür bir stil elde etmek için [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) kullanın. Otomatik‑aralık ayarlayıcısını tekrar `True` yaparsanız grafik yine o aralığı seçer.

Aşağıdaki bağımsız örnek 24 kategori ve bir seri oluşturur, ardından `CategoryAxisIntervals.pptx` içinde üç slayt kaydeder: otomatik aralık, bağımsız işaretçili manuel etiket aralığı ve geri alınmış otomatik aralık. İki kopya orijinal grafik verisini korur. Giriş sunumu gerekmez. Yatay etiket metni, yoğunluk farkını görmeyi kolaylaştırır.

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

    # Slayt 2: her üçüncü etiketi göster, ancak her kategori için bir işaretçi tut.
    manual_slide = presentation.getSlides().addClone(slide)
    manual_chart = manual_slide.getShapes().get_Item(0)
    manual_axis = manual_chart.getAxes().getHorizontalAxis()
    manual_axis.setAutomaticTickLabelSpacing(False)
    manual_axis.setTickLabelSpacing(3)
    manual_axis.setAutomaticTickMarksSpacing(False)
    manual_axis.setTickMarksSpacing(1)

    # Slayt 3: grafiğin her iki aralığı da yeniden seçmesine izin ver.
    restored_slide = presentation.getSlides().addClone(manual_slide)
    restored_chart = restored_slide.getShapes().get_Item(0)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(True)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(True)

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Otomatik aralık (slayt 1):** Bu görüntüde her ikinci kategori etiketi gösterilir ve iki satıra kaydırılır. Otomatik sonuç grafik boyutu, yazı tipleri ve işleyiciye bağlı olarak değişebilir.

![Tüm 24 sütun görünürken otomatik kategori etiketi aralığı](category-axis-automatic.png)

**Manuel aralık (slayt 2):** Her üçüncü etiket tek satırda gösterilir, işaretçiler ise her kategori aralığında kalır. Etiketi olmayanlar da dahil olmak üzere tüm 24 sütun aynı değerlerle görünür. Slayt 3 otomatik görünümü geri getirir.

![Tüm 24 sütun görünürken üçlü manuel kategori etiketi aralığı](category-axis-manual.png)

### **Doğru Ekseni ve Aralığı Seçin**

Bu kategori‑sayısı aralığını metin kategori ekseni için kullanın; örneğin bir sütun, çizgi, alan veya çubuk grafiğinin kategori ekseni. Bir sütun grafiğinde bu, yatay eksendir. Yatay çubuk grafiğinde kategori ekseni dikeydedir; bu nedenle bu ayarları [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis) tarafından döndürülen eksene uygulayın. İşaret‑aralığı, bir ekseni olan grafiklerde seri eksenine de uygulanır.

Değer ekseninin sayısal ölçeğini ayarlamak için kategori etiketi aralığını kullanmayın. Değer ekseninde [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit), değerde bir fark belirtir: örneğin `10` bir büyük birim, eksen sıfırdan başladığında 0, 10, 20 … işaretçileri üretir. `3` kategori etiketi aralığı ise veri değerlerinden bağımsız olarak kategori konumlarını sayar. Dağılım ve balon grafikleri metin kategori ekseni yerine değer eksenleri kullanır. Tarih ekseni için, [Değiştir Kategori Ekseni](#change-a-category-axis) bölümünde açıklandığı gibi zaman tabanlı büyük birimler ve ölçekler kullanın.

## **Kategori Ekseni Değerleri İçin Tarih Biçimini Ayarlamak**

Örnek, varsayılan grafik verilerini dört yıllık değerle değiştirir. Tarihler, ilk çalışma sayfasında (indeks `0`) OLE Automation seri numaraları olarak saklanır; bu, 30 Aralık 1899’dan itibaren gün sayısıdır. [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) ile [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date) kullanın, [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) ile `False` ve [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) ile `yyyy` geçirerek kategori etiketlerinin hücre biçiminden bağımsız olarak dört basamaklı yıl göstermesini sağlayın.

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

## **Bir Grafik Ekseni Başlığı İçin Döndürme Açısı Ayarlamak**

Dikey eksende `True` ile [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTitle) çağırın, başlık metnini sağlayın ve başlığın metin bloğu biçimlendirmesinde döndürme açısını ayarlayın. Açı derece cinsinden ölçülür; bu örnek, değer ekseni başlığını 90 derece döndürerek bir sütun grafik kaydeder.

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

## **Kategori veya Değer Ekseni Üzerinde Ekseni Konumlandırmak**

Değer ekseninin kategori eksenini kategoriler arasında mı yoksa kategori işaretçileri üzerinde mi kestiğini kontrol etmek için [setAxisBetweenCategories](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAxisBetweenCategories) kullanın. Bu ayar kategori eksenlerine uygulanır. Örnek, bir sütun grafiğinin yatay kategori ekseninde `True` olarak ayarlar ve sonucu kaydeder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpape.startJVM()

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

## **Bir Grafik Değer Ekseninde Görüntü Birimini Ayarlamak**

[setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) kullanarak veri değişmeden değer ekseni etiketlerini ölçeklendirin. [DisplayUnitType](https://reference.aspose.com/slides/python-java/aspose.slides/displayunittype/) `Millions` olarak ayarlandığında, 60 000 000 değeri 60 olarak gösterilir. Örnek bir sütun grafik oluşturur ve dikey eksenine milyon görüntü birimini uygular.

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

## **SSS**

**Bir eksenin diğerini kestiği değeri (ekseni kesişim) nasıl ayarlarım?**

Kesişme davranışını seçmek için [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) kullanın. Sayısal bir kesişim değeri belirtmek için [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt) kullanın. Bu ayarlar, eksen kesişimini uygun bir temel çizgiye taşımanıza olanak tanır.

**İşaret etiketlerini eksene göre nasıl konumlandırırım?**

[TickLabelPositionType](https://reference.aspose.com/slides/python-java/aspose.slides/ticklabelpositiontype/) üzerinden `Low`, `High`, `NextTo` veya `None` değerleriyle [setTickLabelPosition](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelPosition) çağırın. İşaretçileri kontrol etmek için [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) veya [setMinorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMinorTickMark) kullanın; bunlar etiket konumlandırmadan ayrı çalışır.