---
title: Python'da Sunum Grafiklerini Biçimlendirme
linktitle: Grafik Biçimlendirme
type: docs
weight: 60
url: /tr/python-java/chart-formatting/
keywords:
- grafik biçimlendirme
- grafik formatlama
- grafik varlığı
- grafik özellikleri
- grafik ayarları
- grafik seçenekleri
- yazı tipi özellikleri
- yuvarlatılmış kenar
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java'da grafik biçimlendirmeyi öğrenin ve PowerPoint sunumunuzu profesyonel, göz alıcı bir stil ile yükseltin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarında grafiklerin nasıl biçimlendirileceğini açıklar. Ekseler, ızgara çizgileri, başlıklar, açıklamalar, çizim alanı ve duvar dolguları gibi temel grafik öğelerinin nasıl özelleştirileceğini göstererek grafik verilerinin görünümünü ve okunabilirliğini artırır.

Ayrıca, grafik metni için yazı tipi özelliklerinin nasıl ayarlanacağını, grafik verilerine önceden tanımlı ve özelleştirilmiş sayısal biçimlerin nasıl uygulanacağını ve grafik alanı için yuvarlatılmış köşelerin nasıl etkinleştirileceğini gösterir. Bu örnekler birlikte, bir sunumdaki grafiklerin görsel stilini ve veri sunumunu nasıl kontrol edebileceğinizi gösterir.

## **Grafik Varlıklarını Biçimlendirme**
Aspose.Slides for Python via Java, geliştiricilerin sıfırdan özel grafikler eklemelerine olanak tanır. Bu makale, kategori ve değer eksenlerini içeren farklı grafik varlıklarının nasıl biçimlendirileceğini açıklar.

Aspose.Slides for Python via Java, farklı grafik varlıklarını yönetmek ve bunları özelleştirilmiş değerlerle biçimlendirmek için basit bir API sağlar:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. İndeksine göre bir slayta erişin.  
1. İstenilen tipte bir grafiği varsayılan verilerle ekleyin (bu örnek [ChartType.LineWithMarkers](https://reference.aspose.com/slides/tr/python-java/aspose.slides/charttype/#LineWithMarkers) kullanır).  
1. Grafik değer eksenine erişin ve aşağıdaki özellikleri ayarlayın:  
   1. Değer ekseninin ana ızgara çizgileri için **Line format** ayarlayın.  
   1. Değer ekseninin alt ızgara çizgileri için **Line format** ayarlayın.  
   1. Değer ekseni için **Number Format** ayarlayın.  
   1. Değer ekseni için **minimum, maximum, major ve minor birimlerini** ayarlayın.  
   1. Değer ekseni verileri için **Text Properties** ayarlayın.  
   1. Değer ekseni için **Title** ayarlayın.  
1. Grafik kategori eksenine erişin ve aşağıdaki özellikleri ayarlayın:  
   1. Kategori ekseninin ana ızgara çizgileri için **Line format** ayarlayın.  
   1. Kategori ekseninin alt ızgara çizgileri için **Line format** ayarlayın.  
   1. Kategori ekseni verileri için **Text Properties** ayarlayın.  
   1. Kategori ekseni için **Title** ayarlayın.  
   1. Kategori ekseni için **Label Positioning** ayarlayın.  
   1. Kategori ekseni etiketleri için **Rotation Angle** ayarlayın.  
1. Grafik açıklamasına erişin ve **text properties** özelliğini ayarlayın.  
1. Grafiği, grafikle çakışmayacak şekilde gösterin.  
1. Grafik **secondary value axis** öğesine erişin ve aşağıdaki özellikleri ayarlayın:  
   1. İkincil **value axis** etkinleştirin.  
   1. İkincil değer ekseni için **Line Format** ayarlayın.  
   1. İkincil değer ekseni için **Number Format** ayarlayın.  
   1. İkincil değer ekseni için **minimum, maximum, major ve minor birimlerini** ayarlayın.  
1. İlk grafik serisini ikincil değer eksenine çizin.  
1. Grafik arka duvar dolgu rengini ayarlayın.  
1. Grafik çizim alanı dolgu rengini ayarlayın.  
1. Değiştirilmiş sunumu bir PPTX dosyasına yazın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayUnitType, FillType, FontData, LineDashStyle, LineStyle, NullableBool, Presentation, PresetColor, SaveFormat, TickLabelPositionType

Color = jpype.JClass("java.awt.Color")
nullable_true = NullableBool.True_

    # Presentation sınıfının bir örneğini oluştur
presentation = Presentation()
try:
    # İlk slayta eriş
    slide = presentation.getSlides().get_Item(0)

    # Örnek grafiği ekle
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400)

    # Grafik Başlığını Ayarla
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("")
    chart_title = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    chart_title.setText("Sample Chart")
    chart_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    chart_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    chart_title.getPortionFormat().setFontHeight(20)
    chart_title.getPortionFormat().setFontBold(nullable_true)
    chart_title.getPortionFormat().setFontItalic(nullable_true)

    # Değer ekseni için ana ızgara çizgileri biçimini ayarla
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot)

    # Değer ekseni için alt ızgara çizgileri biçimini ayarla
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    # Değer ekseni sayı biçimini ayarla
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%")

    # Grafik maksimum, minimum değerlerini ayarla
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getVerticalAxis().setMaxValue(15)
    chart.getAxes().getVerticalAxis().setMinValue(-2)
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0)

    # Değer Ekseni Metin Özelliklerini Ayarla
    value_axis_text = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat()
    value_axis_text.setFontBold(nullable_true)
    value_axis_text.setFontHeight(16)
    value_axis_text.setFontItalic(nullable_true)
    value_axis_text.getFillFormat().setFillType(FillType.Solid)
    value_axis_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen)
    value_axis_font = FontData("Times New Roman")
    value_axis_text.setLatinFont(value_axis_font)

    # Değer ekseni başlığını ayarla
    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("")
    value_axis_title = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    value_axis_title.setText("Primary Axis")
    value_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    value_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    value_axis_title.getPortionFormat().setFontHeight(20)
    value_axis_title.getPortionFormat().setFontBold(nullable_true)
    value_axis_title.getPortionFormat().setFontItalic(nullable_true)

    # Kategori ekseni için ana ızgara çizgileri biçimini ayarla
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5)

    # Kategori ekseni için alt ızgara çizgileri biçimini ayarla
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    # Kategori Ekseni Metin Özelliklerini Ayarla
    category_axis_text = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat()
    category_axis_text.setFontBold(nullable_true)
    category_axis_text.setFontHeight(16)
    category_axis_text.setFontItalic(nullable_true)
    category_axis_text.getFillFormat().setFillType(FillType.Solid)
    category_axis_text.getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    category_axis_font = FontData("Arial")
    category_axis_text.setLatinFont(category_axis_font)

    # Kategori Başlığını Ayarla
    chart.getAxes().getHorizontalAxis().setTitle(True)
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("")

    category_axis_title = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    category_axis_title.setText("Sample Category")
    category_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    category_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    category_axis_title.getPortionFormat().setFontHeight(20)
    category_axis_title.getPortionFormat().setFontBold(nullable_true)
    category_axis_title.getPortionFormat().setFontItalic(nullable_true)

    # Kategori ekseni etiket konumunu ayarla
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low)

    # Kategori ekseni etiket dönüş açısını ayarla
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45)

    # Açıklama Metin Özelliklerini Ayarla
    legend_text = chart.getLegend().getTextFormat().getPortionFormat()
    legend_text.setFontBold(nullable_true)
    legend_text.setFontHeight(16)
    legend_text.setFontItalic(nullable_true)
    legend_text.getFillFormat().setFillType(FillType.Solid)
    legend_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed)

    # Grafik açıklamasını grafiğe çakışmayacak şekilde göster

    chart.getLegend().setOverlay(False)

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(True)
    # İkincil değer eksenini ayarla
    chart.getAxes().getSecondaryVerticalAxis().setVisible(True)
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin)
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20)

    # İkincil değer ekseni sayı biçimini ayarla
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds)
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%")

    # Grafik maksimum, minimum değerlerini ayarla
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20)
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5)
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0)

    # Grafiğin arka duvar rengini ayarla
    chart.getBackWall().setThickness(1)
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid)
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE)

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid)
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED)
    # Çizim alanı rengini ayarla
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid)
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan)

    # Sunumu kaydet
    presentation.save("FormattedChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Grafik İçin Yazı Tipi Özelliklerini Ayarlama**
Aspose.Slides for Python via Java, grafikler için yazı tipi özelliklerinin ayarlanmasını destekler. Yazı tipi özelliklerini ayarlamak için aşağıdaki adımları izleyin:

- Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
- Slayta bir grafik ekleyin.  
- Yazı tipi yüksekliğini ayarlayın.  
- Değiştirilmiş sunumu kaydedin.

Aşağıdaki örnek bu adımları göstermektedir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Presentation sınıfının bir örneğini oluştur
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)

    chart.getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Sayısal Biçimi Ayarlama**
Aspose.Slides for Python via Java, grafik veri biçimlerini yönetmek için basit bir API sağlar:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. İndeksine göre bir slayta erişin.  
1. İstenilen tipte bir grafiği varsayılan verilerle ekleyin (bu örnek [ChartType.ClusteredColumn](https://reference.aspose.com/slides/tr/python-java/aspose.slides/charttype/#ClusteredColumn) kullanır).  
1. Olası önceden tanımlı değerlerden birini seçerek ön ayarlı sayı biçimini ayarlayın.  
1. Her bir grafik serisindeki veri hücrelerini dolaşarak sayı biçimlerini ayarlayın.  
1. Sunumu kaydedin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Presentation sınıfının bir örneğini oluştur
presentation = Presentation()
try:
    # İlk sunum slaytına eriş
    slide = presentation.getSlides().get_Item(0)

    # Varsayılan kümelenmiş sütun grafiği ekle
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400)

    # Grafik serileri koleksiyonuna eriş
    chart_series_collection = chart.getChartData().getSeries()

    # Her bir grafik serisi üzerinde döngü yap
    for chart_series in chart_series_collection:
        # Serideki her bir veri noktasında döngü yap
        for data_point in chart_series.getDataPoints():
            # Sayı biçimini ayarla
            data_point.getValue().getAsCell().setPresetNumberFormat(jpype.JByte(10))  # 0.00%

    # Sunumu kaydet
    presentation.save("PresetNumberFormat.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kullanılabilir ön ayarlı sayı biçimleri ve indeksleri aşağıda listelenmiştir:

|**0**|Genel|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Grafik Alanı Yuvarlatılmış Kenarlıkları Ayarlama**
Aspose.Slides for Python via Java, [Chart](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chart/) sınıfının [hasRoundedCorners](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chart/#hasRoundedCorners) ve [setRoundedCorners](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chart/#setRoundedCorners) yöntemleri aracılığıyla grafik alanı için yuvarlatılmış köşeleri destekler.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. Slayta bir grafik ekleyin.  
1. Grafik kenar çizgisinin dolgu tipini ve stilini ayarlayın.  
1. Yuvarlatılmış köşeleri etkinleştirin.  
1. Değiştirilmiş sunumu kaydedin.

Aşağıdaki örnek bu adımları göstermektedir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineStyle, Presentation, SaveFormat

# Presentation sınıfının bir örneğini oluştur
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    chart.getLineFormat().setStyle(LineStyle.Single)
    chart.setRoundedCorners(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SSS**

**Sütunlar/alanlar için yarı saydam dolgular ayarlarken kenarlığı opak tutabilir miyim?**

Evet. Dolgu şeffaflığı ve dış hat ayrı ayrı yapılandırılır. Bu, yoğun görselleştirmelerde ızgara ve veri okunabilirliğini artırmak için faydalıdır.

**Veri etiketleri üst üste bindiğinde nasıl başa çıkabilirim?**

Yazı tipi boyutunu küçültün, gereksiz etiket bileşenlerini (örneğin kategorileri) devre dışı bırakın, etiket ofsetini/konumunu ayarlayın, gerekirse yalnızca seçili noktalara etiket gösterin veya formatı “değer + açıklama” şeklinde değiştirin.

**Serilere degrade veya desen dolgular uygulayabilir miyim?**

Evet. Hem katı hem de degrade/desen dolgular genellikle mevcuttur. Pratikte, degradeleri ölçülü kullanın ve ızgara ile metin arasındaki kontrasti azaltan kombinasyonlardan kaçının.