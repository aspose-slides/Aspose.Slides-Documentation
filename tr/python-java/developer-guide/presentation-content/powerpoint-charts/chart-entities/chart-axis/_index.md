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

Bu makale, Aspose.Slides for Python via Java ile grafik eksenlerini nasıl özelleştireceğinizi açıklar. Hesaplanmış eksen değerleri, grafik satır ve sütunlarının değiştirilmesi, eksen görünürlüğü, kategori etiketi ve işaretçi aralıkları, tarih kategorileri ve biçimlendirme, başlık döndürme, eksen konumlandırma, görüntü birimleri ve logaritmik ölçeklendirme konularını kapsar.

## **Bir Grafiğin Dikey Eksenindeki Azami Değerleri Almak**

Varsayılan verilerle bir alan grafiği ekleyerek bir [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) oluşturun. Hesaplanmış eksen değerlerini okumadan önce grafiğin düzeninin güncel olması için [validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) çağırın.

[getActualMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMaxValue) ve [getActualMinValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinValue) ile eksen sınırlarını, [getActualMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnit) ve [getActualMinorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnit) ile işaretçi aralıklarını okuyun. [getActualMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnitScale) ve [getActualMinorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnitScale) tarih eksenleriyle ilgili zaman birimi ölçeklerini sağlar. Örnek bu değerleri yerel değişkenlerde saklar ve grafiği kaydeder.

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

## **Eksenler Arasındaki Verileri Değiştirin**

[switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) kullanarak grafik verilerinde seri ve kategorilerin rollerini değiştirin. Her eski kategori bir seri, her eski seri ise bir kategori olur. Bu, verilerin nasıl gruplandığını değiştirir; yatay ve dikey eksenleri değiştirmez. Örnek, satır ve sütunları değiştirmeden önce varsayılan verileri `Sheet1!A1:D5` aralığına, başlık satırı ve kategori sütunu dahil olmak üzere bağlamak için [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) kullanır. Dört seri ve üç kategori içeren bir grafik kaydeder.

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

## **Çizgi Grafiklerde Dikey Eksen'i Devre Dışı Bırakma**

Dikey ekseni gizlemek için `False` ile [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) çağırın. Örnek, varsayılan verilerle bir çizgi grafik oluşturur ve dikey eksen gizli olarak kaydeder.

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

## **Çizgi Grafiklerde Yatay Eksen'i Devre Dışı Bırakma**

Yatay ekseni gizlemek için `False` ile [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) çağırın. Örnek, varsayılan verilerle bir çizgi grafik oluşturur ve yatay eksen gizli olarak kaydeder.

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

## **Bir Kategori Eksenini Değiştirme**

[setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) kullanarak tarih veya metin kategori ekseni seçin. Bu örnek, ilk slayttaki ilk şekil olarak bir grafik ve kategori hücrelerinde sayısal Excel tarih değerleri bulunan `ExistingChart.pptx` dosyasını gerektirir. Yatay ekseni bir tarih eksenine dönüştürür. [setAutomaticMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMajorUnit) `False`, [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) `1` ve [setMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnitScale) [TimeUnitType.Months](https://reference.aspose.com/slides/python-java/aspose.slides/timeunittype/#Months) ile çağırarak ana işaretçileri bir‑aylık aralıklarla yerleştirir.

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

## **Kategori Ekseni Etiket Aralıklarını Kontrol Etme**

Bir grafikte birçok kategori olduğunda, kategorileri veya veri noktalarını kaldırmadan görünen eksen etiketlerinin sayısını azaltın. [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickLabelSpacing) `False` ile çağırın, ardından istenen kategori aralığını [setTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelSpacing) parametresi olarak geçirin. Normal sıradaki metin kategorileri için sayım ilk kategoriden başlar:

| Aralık | Örnekte görüntülenen etiketler |
| --- | --- |
| `1` | Kategori 1, Kategori 2, Kategori 3, ... Kategori 24 |
| `2` | Kategori 1, Kategori 3, Kategori 5, ... Kategori 23 |
| `3` | Kategori 1, Kategori 4, Kategori 7, ... Kategori 22 |

`3` aralığı her üçüncü etiketi gösterir ve gösterilen etiketler arasında iki etiket gizli kalır. İlgili sütunları kaldırmaz. Otomatik aralık, mevcut alana göre bir aralık seçer; her etiketi mutlaka göstermez.

İşaretçiler ayrı kontrollerle ayarlanır. [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickMarksSpacing) `False` ile çağırın ve aralıklarını ayarlamak için [setTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickMarksSpacing) kullanın. Örneğin, `1` her kategori aralığında bir işaretçi bırakırken etiketler yalnızca her üçüncü kategoride görünür. Sonucu görebilmek için görünür bir stil ile [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) kullanın. Otomatik‑aralık ayarlayıcısını tekrar `True` ile çağırmak, grafiğin tekrar o aralığı seçmesini sağlar.

Aşağıdaki bağımsız örnek 24 kategori ve bir seri oluşturur, ardından `CategoryAxisIntervals.pptx` içinde üç slayt kaydeder: otomatik aralık, bağımsız işaretçilerle manuel etiket aralığı ve yeniden otomatik aralık. İki kopya özgün grafik verilerini korur. Giriş sunumu gerekmez. Yatay etiket metni, yoğunluk farkını görmeyi kolaylaştırır.

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

    # Slayt 3: grafiğin her iki aralığı da tekrar seçmesine izin ver.
    restored_slide = presentation.getSlides().addClone(manual_slide)
    restored_chart = restored_slide.getShapes().get_Item(0)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(True)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(True)

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Otomatik aralık (slayt 1):** Bu gösterimde her ikinci kategori etiketi gösterilir ve iki satıra sarılır. Otomatik sonuç, grafik boyutu, yazı tipleri ve işleyiciye göre değişebilir.

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**Manuel aralık (slayt 2):** Her üçüncü etiket tek satırda gösterilir, işaretçiler ise her kategori aralığında kalır. Etiketsiz olanlar dahil, tüm 24 sütun aynı değerlerle görünür. Slayt 3 yukarıda gösterilen otomatik görünümü geri yükler.

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **Doğru Ekseni ve Aralığı Seçin**

Bu kategori‑sayısı aralığını, sütun, çizgi, alan veya çubuk grafik gibi bir metin kategori ekseni için kullanın. Sütun grafiğinde yatay eksen olur. Yatay çubuk grafiğinde kategori ekseni dikeydir, bu yüzden bu ayarları [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis) tarafından döndürülen eksene uygulayın. İşaretçi aralığı, bir seriye sahip grafiklerde seri eksenine de uygulanır.

Kategori etiketi aralığını, değer ekseninin sayısal ölçeğini ayarlamak için kullanmayın. Değer ekseninde, [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) değer farkını belirtir: örneğin, `10` bir ana birim eksen sıfırdan başladığında 0, 10, 20 vb. işaretçiler üretir. `3` bir kategori etiketi aralığı ise veri değerlerinden bağımsız olarak kategori konumlarını sayar. Dağılım ve balon grafikler metin kategori ekseni yerine değer eksenleri kullanır. Tarih ekseni için, [Change a Category Axis](#change-a-category-axis) bölümünde açıklandığı gibi zaman tabanlı ana birimler ve ölçekler kullanın.

## **Kategori Eksen Değerleri için Tarih Biçimini Ayarlama**

Örnek, varsayılan grafik verilerini dört yıllık değerle değiştirir. Tarihler, ilk çalışma sayfasında (indeks `0`) OLE Automation seri numaraları olarak depolanır; bu tarihler 30 Aralık 1899'dan itibaren gün sayısı olarak hesaplanır. [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) ile [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date) kullanın, [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) `False` ile çağırın ve kategori etiketlerinin hücre biçiminden bağımsız olarak dört basamaklı yıl göstermesi için `yyyy` değerini [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) ile geçirin.

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

## **Grafik Eksen Başlığı için Döndürme Açısını Ayarlama**

Dikey eksende `True` ile [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTitle) çağırın, başlık metnini sağlayın ve başlığın metin bloğu biçiminde döndürme açısını ayarlayın. Açı dereceler cinsinden ölçülür; bu örnek, değer ekseni başlığı 90 derece döndürülmüş bir sütun grafik kaydeder.

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

## **Kategori veya Değer Ekseninde Eksen Konumunu Ayarlama**

[setAxisBetweenCategories](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAxisBetweenCategories) kullanarak değer ekseninin kategori eksenini kategoriler arasında mı yoksa kategori işaretçileri üzerinde mi kestiğini kontrol edin. Bu ayar kategori eksenlerine uygulanır. Örnek, bir sütun grafiğinin yatay kategori ekseninde `True` olarak ayarlar ve sonucu kaydeder.

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

## **Grafik Değer Ekseninde Görüntüleme Birimini Ayarlama**

[setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) kullanarak değer eksenindeki etiketleri veri değişmeden ölçeklendirin. [DisplayUnitType](https://reference.aspose.com/slides/python-java/aspose.slides/displayunittype/) `Millions` (Milyon) olarak ayarlandığında 60.000.000 değeri 60 olarak gösterilir. Örnek bir sütun grafik oluşturur ve dikey eksenine milyon görüntüleme birimini uygular.

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

Pozitif değerler birkaç büyüklük mertebesi kapsadığında logaritmik değer ekseni yararlıdır. Örneğin bir hizmet, beş dönem boyunca 10, 100, 1.000, 10.000 ve 100.000 istek alabilir. Doğrusal ölçekte küçük değerler sıfıra yakın bir arada görünür. Logaritmik ölçek, göreceli büyümeyi karşılaştırmayı kolaylaştırır: eşit mesafeler eşit oranları, eşit farkları göstermez.

Değer ekseninde `True` ile [setLogarithmic](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogarithmic) çağırın ve tabanı seçmek için [setLogBase](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogBase) kullanın. Bu, mevcut değerlerin görüntülenme şeklini değiştirir; veriyi değiştirmez veya logaritmik bir eğri eklemez. Eğri çizgisi, verideki uygun ilişkiyi temsil eder ve ayrı bir özelliktir.

### **Değer Eksenini ve Tabanı Seçme**

Çizgi veya sütun grafiği için değer ekseni [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis) tarafından döndürülür. Yatay çubuk grafiği için [getHorizontalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getHorizontalAxis) döndürür. Dağılım ve balon grafiklerde iki değer ekseni vardır; X değerleri için yatay ekseni, Y değerleri için dikey ekseni veya her ikisini seçin. Kategori eksenine logaritmik ölçeklendirme uygulamayın.

Varsayılan logaritmik taban `10`'dur. PPTX grafiklerinde `2` ile `1000` arasında (dahil) bir taban kullanın; `2.5` gibi kesirli tabanlar da desteklenir. `10` tabanı ile ardışık kuvvetler 10, 100, 1.000 ve 10.000 eşit aralıklarla yer alır.

### **Doğrusal ve Logaritmik Ölçeklendirmeyi Karşılaştırma**

Aşağıdaki bağımsız örnek, ilk slaytta beş istek sayısı ile bir çizgi grafik oluşturur, ardından bu slaytı çoğaltır ve ikinci slaytta taban‑10 logaritmik değer eksenini etkinleştirir. Her iki slayt da aynı veriyi korur.

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

    # İlk slaytı doğrusal tutun ve yalnızca kopyanın değer ekseni ölçeğini değiştirin.
    logarithmic_slide = presentation.getSlides().addClone(slide)
    logarithmic_chart = logarithmic_slide.getShapes().get_Item(0)
    value_axis = logarithmic_chart.getAxes().getVerticalAxis()
    value_axis.setLogarithmic(True)
    value_axis.setLogBase(10)

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Doğrusal ölçek (slayt 1):** Eşit dikey mesafeler istek sayılarındaki eşit farkları temsil eder. En büyük değer grafiği domine eder, küçük değerleri ayırt etmeyi zorlaştırır.

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**Logaritmik ölçek (slayt 2):** Eşit dikey mesafeler eşit oranları temsil eder. Her dönem, bir önceki dönemin on katı istek alır, bu yüzden noktalar taban‑10 ölçeğinde düz bir yükselen çizgi oluşturur. Eksen etiketleri hâlâ özgün istek sayısını gösterir.

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **Sıfır ve Negatif Değerleri Ele Alma**

Logaritmik ölçek yalnızca kesinlikle pozitif değerleri gösterebilir. Etkinleştirmeden önce verileri kontrol edin. Sıfır veya negatif değerler anlamlıysa, doğrusal ölçeği koruyun veya ayrı gösterin. Analiz için bu değerleri dışlamak uygun ise, dışlamayı açıklayın. Veri anlamını değiştirdiği için onları sessizce küçük pozitif sayılarla değiştirmeyin. Logaritmik eksen için manuel olarak ayarlanan herhangi bir minimum veya maksimum da pozitif olmalıdır.

## **SSS**

**Bir eksenin diğerini kestiği değeri (ekseni kesişim) nasıl ayarlarım?**  
[setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) kullanarak kesişim davranışını seçin. Sayısal bir kesişim değeri belirlemek için [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt) kullanın. Bu ayarlar, eksen kesişimini uygun bir temel çizgiye taşımanıza olanak verir.

**İşaretçi etiketlerini eksene göre nasıl konumlandırabilirim?**  
[setTickLabelPosition](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelPosition) kullanarak [TickLabelPositionType](https://reference.aspose.com/slides/python-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` veya `None` değerlerinden birini seçin. İşaretçileri kendilerini kontrol etmek için [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) veya [setMinorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMinorTickMark) kullanın; bunlar etiket konumlandırmadan ayrı özelliklerdir.