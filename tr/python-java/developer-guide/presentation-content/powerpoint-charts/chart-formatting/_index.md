---
title: Python'da Sunum Grafiklerini Biçimlendir
linktitle: Grafik Biçimlendirme
type: docs
weight: 60
url: /tr/python-java/chart-formatting/
keywords:
- grafik biçimlendirme
- grafik formatlama
- grafik öğesi
- grafik özellikleri
- grafik ayarları
- grafik seçenekleri
- yazı tipi özellikleri
- yuvarlak kenar
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java'da grafik biçimlendirmeyi öğrenin ve özel eksenler, yazı tipleri, sayı biçimleri ve yuvarlak grafik kenarlarıyla PowerPoint sunumunuzu geliştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarında grafiklerin nasıl biçimlendirileceğini açıklamaktadır. Eksenler, ızgara çizgileri, başlıklar, açıklamalar, çizim alanı ve duvar dolgu gibi ana grafik öğelerini özelleştirerek grafik verilerinin görünümünü ve okunabilirliğini artırmayı gösterir.

Ayrıca, grafik metni için yazı tipi özelliklerini nasıl ayarlayacağınızı, grafik verilerine önceden tanımlı sayısal biçimleri nasıl uygulayacağınızı ve grafik alanı için yuvarlak köşeleri nasıl etkinleştireceğinizi gösterir. Bu örnekler birlikte, bir sunumdaki grafiklerin hem görsel stilini hem de veri sunumunu nasıl kontrol edebileceğinizi gösterir.

For separate fills and outlines on rising and falling intervals, see the [hisse senedi grafiği örneği](/slides/tr/python-java/create-chart/#create-stock-charts).

## **Grafik Öğelerini Biçimlendir**

Grafik başlıklarını, eksenleri, ızgara çizgilerini, açıklamaları ve çizim alanını biçimlendirmek için [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) kullanın. Bu örnek, işaretçili ve varsayılan verili bir çizgi grafiği oluşturur ve ardından değer ve kategori eksenlerine ayrı metin ve çizgi stilleri uygular. Yazı tipi boyutları ve çizgi kalınlıkları puan cinsinden belirtilir; kategori etiketleri 45 derece döndürülür.

Değer ekseni, kaynak hücrelerden bağımsız olarak [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) kullanır. Ölçeği -2 ile 15 arasında, ana aralıkları 2 ve yan aralıkları 0,5 olarak belirlenir. Örnek ayrıca yüzde biçimlendirmesini [setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) ile binler biriminde ayarlanan birimle birleştirir; bu ayarları verinizin anlamı ve büyüklüğüne göre uyarlayın. Açıklama, [setOverlay](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setOverlay) `False` ile çağrıldığı için çizim alanının dışında kalır. Arka duvar ve taban dolgu renkleri [getBackWall](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getBackWall) ve [getFloor](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getFloor) aracılığıyla yapılandırılır, ancak bu yüzeyler yalnızca 3B grafiklerde görünür.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayUnitType, FillType, FontData, LineDashStyle, NullableBool, Presentation, PresetColor, SaveFormat, TickLabelPositionType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400)

    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("")
    chart_title = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    chart_title.setText("Sample Chart")
    chart_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    chart_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    chart_title.getPortionFormat().setFontHeight(20)
    chart_title.getPortionFormat().setFontBold(NullableBool.True_)
    chart_title.getPortionFormat().setFontItalic(NullableBool.True_)

    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot)

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%")

    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getVerticalAxis().setMaxValue(15)
    chart.getAxes().getVerticalAxis().setMinValue(-2)
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0)

    value_axis_text = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat()
    value_axis_text.setFontBold(NullableBool.True_)
    value_axis_text.setFontHeight(16)
    value_axis_text.setFontItalic(NullableBool.True_)
    value_axis_text.getFillFormat().setFillType(FillType.Solid)
    value_axis_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen)
    value_axis_font = FontData("Times New Roman")
    value_axis_text.setLatinFont(value_axis_font)

    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("")
    value_axis_title = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    value_axis_title.setText("Primary Axis")
    value_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    value_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    value_axis_title.getPortionFormat().setFontHeight(20)
    value_axis_title.getPortionFormat().setFontBold(NullableBool.True_)
    value_axis_title.getPortionFormat().setFontItalic(NullableBool.True_)

    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    category_grid_color = Color(0, 128, 0)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(category_grid_color)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5)

    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    category_axis_text = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat()
    category_axis_text.setFontBold(NullableBool.True_)
    category_axis_text.setFontHeight(16)
    category_axis_text.setFontItalic(NullableBool.True_)
    category_axis_text.getFillFormat().setFillType(FillType.Solid)
    category_axis_text.getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    category_axis_font = FontData("Arial")
    category_axis_text.setLatinFont(category_axis_font)

    chart.getAxes().getHorizontalAxis().setTitle(True)
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("")

    category_axis_title = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    category_axis_title.setText("Sample Category")
    category_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    category_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    category_axis_title.getPortionFormat().setFontHeight(20)
    category_axis_title.getPortionFormat().setFontBold(NullableBool.True_)
    category_axis_title.getPortionFormat().setFontItalic(NullableBool.True_)

    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low)
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45)

    legend_text = chart.getLegend().getTextFormat().getPortionFormat()
    legend_text.setFontBold(NullableBool.True_)
    legend_text.setFontHeight(16)
    legend_text.setFontItalic(NullableBool.True_)
    legend_text.getFillFormat().setFillType(FillType.Solid)
    legend_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed)

    chart.getLegend().setOverlay(False)

    chart.getBackWall().setThickness(1)
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid)
    back_wall_color = Color(255, 165, 0)
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(back_wall_color)

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid)
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED)

    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid)
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan)

    presentation.save("FormattedChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Bir Grafik için Yazı Tipi Özelliklerini Ayarlama**

Grafik metni için varsayılan yazı tipi boyutunu [Chart.getTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getTextFormat) aracılığıyla ayarlayın. Bu örnek, 20 puanlık bir yazı tipiyle bir kümelenmiş sütun grafiği oluşturur ve ilk seri için değer etiketlerini [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) ile etkinleştirir. Kendi açık yazı tipi ayarlarına sahip metin öğeleri, grafik varsayılanının üzerine yazabilir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)
    chart.getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Bir Grafik Açıklaması için Metin Çerçevesi Biçimlendirmesini Yeniden Kullanma**

Bir açıklamayı slayt başlığıyla eşleştirmek için, ilk paragrafta başlığın yazı tipini [getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) aracılığıyla ayarlayın. Açıklamanın [getTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getTextFormat) tarafından döndürülen biçim üzerinde [copyFrom](https://reference.aspose.com/slides/python-java/aspose.slides/charttextformat/#copyFrom) çağırın. Bu, metin çerçevesi ayarlarını, ilk paragrafın biçimlendirmesini ve o paragrafın varsayılan yazı tipi özelliklerini kopyalar. Bireysel bölümlere veya sonraki paragraflara doğrudan uygulanan biçimlendirme kaynağa özgü kalır.

Örnek, koyu mavi renkte kalın, 26 puanlık Calibri başlığı şablon olarak kullanır. Açıklamayı biçimlendirdikten sonra, aynı biçimlendirmeyi ayrı bir başlığa uygulamak için [copyTo](https://reference.aspose.com/slides/python-java/aspose.slides/charttextformat/#copyTo) çağırır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, FontData, LegendPositionType, NullableBool, Presentation, SaveFormat, ShapeType, StyleType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()
    
    heading = shapes.addAutoShape(ShapeType.Rectangle, 40, 20, 640, 40, False)
    source_text_frame = heading.addTextFrame("Quarterly sales")
    paragraph = source_text_frame.getParagraphs().get_Item(0)
    font = paragraph.getParagraphFormat().getDefaultPortionFormat()
    font.setLatinFont(FontData("Calibri"))
    font.setFontHeight(26)
    font.setFontBold(NullableBool.True_)
    font.getFillFormat().setFillType(FillType.Solid)
    font.getFillFormat().getSolidFillColor().setColor(Color(32, 64, 96))

    chart = shapes.addChart(ChartType.ClusteredColumn, 40, 75, 640, 360)
    chart.setStyle(StyleType.Style3)
    workbook = chart.getChartData().getChartDataWorkbook()
    for column, series_name in enumerate(("Retail", "Online", "Wholesale"), start=1):
        workbook.getCell(0, 0, column).setValue(series_name)
    for quarter in range(1, 5):
        workbook.getCell(0, quarter, 0).setValue(f"Q{quarter}")

    chart.setLegend(True)
    legend = chart.getLegend()
    legend.setPosition(LegendPositionType.Bottom)
    legend_format = legend.getTextFormat()
    legend_format.copyFrom(source_text_frame)

    caption = shapes.addAutoShape(ShapeType.Rectangle, 40, 460, 640, 40, False)
    caption_text_frame = caption.addTextFrame("Sales in millions of dollars")
    legend_format.copyTo(caption_text_frame)

    presentation.save("legend-formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kaydedilen sunumda, açıklama ve başlık boyut, kalınlık ve renk açısından başlıkla eşleşir. Açıklama hâlâ seri adlarını gösterir ve başlık kendi metnini korur. Başlıktaki bir bölümde zaten açık bir yazı tipi boyutu varsa, bu boyut kopyalanan paragraf varsayılanının üzerine yazar.

| Before copying | After copying |
| --- | --- |
| ![Dönemsel satış grafiği, normal siyah açıklama etiketleri ve siyah başlık ile](legend-formatting-before.png) | ![Aynı grafik, daha büyük, kalın lacivert açıklama etiketleri ve eşleşen bir başlık ile](legend-formatting.png) |

## **Sayısal Biçimi Ayarla**

Grafik çalışma kitabı hücrelerine yerleşik bir sayı biçimi uygulamak için [ChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setPresetNumberFormat) kullanın. Bu örnek, varsayılan hücre tabanlı veri ile bir kümelenmiş sütun grafiği oluşturur ve her seri değer hücresine format dizini 10 (`0.00%`) uygular. Bu, temel sayıları değiştirmeden değerlerin çalışma kitabında nasıl görüntüleneceğini değiştirir; örneğin, 0.25 değeri 25,00% olarak gösterilir. Eksen ve veri etiketi biçimleri ayrı ayrı yapılandırılabilir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400)
    chart_series_collection = chart.getChartData().getSeries()

    for chart_series in chart_series_collection:
        for data_point in chart_series.getDataPoints():
            data_point.getValue().getAsCell().setPresetNumberFormat(jpype.JByte(10))  # 0.00%

    presentation.save("PresetNumberFormat_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Aşağıdaki tablo, İngilizce (Amerika Birleşik Devletleri) yerel ayarı için temsilci Excel biçimleriyle yerleşik sayı biçimi dizinlerini listeler. Tam format dizgileri ve gösterimleri uygulamaya ve yerel ayara göre değişebilir, özellikle para birimi ve tarih biçimleri için. Bazı Excel biçimleri, [Microsoft'un sayı biçimi uygulama notlarında](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) açıklanan OOXML standardındaki varsayılanlardan da farklıdır.

| Dizin | Biçim |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **Grafik Alanına Yuvarlak Kenarlar Ayarla**

Grafik alanının köşelerini yuvarlatmak için `True` ile [Chart.setRoundedCorners](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setRoundedCorners) çağırın. Örnek, bir kümelenmiş sütun grafiği oluşturur ve sunumu kaydetmeden önce kenarlığına katı gri bir renk ve tek çizgi stili vermek için [getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) kullanır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineStyle, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    chart.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    chart.getLineFormat().setStyle(LineStyle.Single)
    chart.setRoundedCorners(True)

    presentation.save("out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Mevcut Grafik Açıklamalarını Düzenle**

Bir grafik, rapor durumunu açıklayan bir metin açıklaması gibi özel şekiller içerebilir. Bu şekillere [Chart.getUserShapes](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getUserShapes) aracılığıyla erişin. [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) tarafından döndürülen koleksiyon, grafiğe ait şekilleri içerir.

Grafiğin üzerine yerleştirilen sıradan bir metin kutusu, grafik parçası gibi görünse bile slayta aittir. [Slide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes) üzerinden yineleme, grafiği ve sıradan slayt şekillerini bulur, ancak grafiğin içindeki bireysel şekilleri listelemez. Grafik başlıkları ve veri etiketleri ayrı grafik öğeleridir, bu koleksiyondaki özel açıklama değildir.

Download [chart-annotations.pptx](chart-annotations.pptx) and place it in the application's working directory. Its first slide contains a chart with an ungrouped annotation reading "Preliminary results", a chart-owned line, and an ordinary slide text box reading "Slide overlay". The example finds the first chart on that slide and changes the annotation to "Final results" when the report is ready to publish. It checks for an empty collection and only edits an [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) with a text frame other than `None` returned by [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#getTextFrame) and the expected text.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Chart, Presentation, SaveFormat

presentation = Presentation("chart-annotations.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = None
    for shape in slide.getShapes():
        if isinstance(shape, Chart):
            chart = shape
            break

    if chart is None or chart.getUserShapes().getShapes().size() == 0:
        print("No chart or chart-owned shapes found.")
    else:
        updated = False
        for shape in chart.getUserShapes().getShapes():
            if isinstance(shape, AutoShape):
                text_frame = shape.getTextFrame()
                if text_frame is not None and text_frame.getText() == "Preliminary results":
                    text_frame.setText("Final results")
                    updated = True
                    break

        if updated:
            presentation.save("chart-annotations-updated.pptx", SaveFormat.Pptx)
        else:
            print("No matching text annotation found.")
finally:
    presentation.dispose()
```

Satır ve slayt metin kutusu aynı kalır. Aşağıdaki görseller giriş ve kaydedilip yeniden açılan sonucu gösterir:

| Before editing | After editing |
| --- | --- |
| ![Grafik açıklaması 'Preliminary results'](chart-annotations-before.png) | ![Grafik açıklaması 'Final results'](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
Örnek yalnızca üst‑seviye grafik‑ait şekilleri inceler. Bir açıklama bir [GroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/) içinde ise, o grubun [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) koleksiyonunu da inceleyin. İç içe gruplar için bunu yeniden tekrarlayın ve aynı metin kontrollerini alt şekillerine uygulayın. Bir grup kendisi bir kapsayıcıdır; onu bir metin kutusu gibi ele almayın.
{{% /alert %}}

## **SSS**

**Sütunlar/alalar için yarı saydam dolgu ayarlarken kenarlığı opak tutabilir miyim?**

Evet. Dolgu şeffaflığı ve kenarlık ayrı ayrı yapılandırılır. Bu, yoğun görselleştirmelerde ızgara ve verilerin okunabilirliğini artırmak için faydalıdır.

**Veri etiketleri üst üste geldiğinde nasıl başa çıkabilirim?**

Yazı tipi boyutunu küçültün, gereksiz etiket bileşenlerini devre dışı bırakın (örneğin, kategorileri), etiket konumunu ayarlayın, gerekirse yalnızca seçili noktalar için etiket gösterin veya biçimi "değer + açıklama" olarak değiştirin.

**Serilere degrade veya desen dolgu uygulayabilir miyim?**

Evet. Seriler katı, degrade ve desen dolgu destekler. Pratikte, degradeleri ölçülü kullanın ve ızgara ve metinle kontrastı azaltan kombinasyonlardan kaçının.