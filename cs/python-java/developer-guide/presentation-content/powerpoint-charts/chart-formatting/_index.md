---
title: Formátování grafů prezentace v Pythonu
linktitle: Formátování grafu
type: docs
weight: 60
url: /cs/python-java/chart-formatting/
keywords:
- formát grafu
- formátování grafu
- entita grafu
- vlastnosti grafu
- nastavení grafu
- volby grafu
- vlastnosti písma
- zakulacený okraj
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Naučte se formátování grafů v Aspose.Slides pro Python via Java a vylepšete svou prezentaci PowerPoint profesionálním, poutavým stylem."
---
## **Přehled**

Tento článek vysvětluje, jak formátovat grafy v prezentacích PowerPoint pomocí Aspose.Slides. Ukazuje, jak přizpůsobit klíčové prvky grafu, jako jsou osy, mřížkové čáry, názvy, legendy, oblast grafu a výplně stěn, aby se zlepšil vzhled a čitelnost dat v grafu.

Také demonstruje, jak nastavit vlastnosti písma pro text grafu, použít přednastavené a vlastní číselné formáty na data grafu a povolit zaoblené rohy pro oblast grafu. Společně tyto příklady ukazují, jak ovládat jak vizuální styl, tak prezentaci dat v grafu v prezentaci.

## **Formátování entit grafu**

Aspose.Slides for Python via Java umožňuje vývojářům přidávat vlastní grafy do jejich snímků od nuly. Tento článek vysvětluje, jak formátovat různé entity grafu, včetně kategorií a hodnotových os.

Aspose.Slides for Python via Java poskytuje jednoduché API pro správu různých entit grafu a jejich formátování pomocí vlastních hodnot:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
1. Přistupte k snímku podle jeho indexu.
1. Přidejte graf požadovaného typu s výchozími daty (v tomto příkladu se používá [ChartType.LineWithMarkers](https://reference.aspose.com/slides/cs/python-java/aspose.slides/charttype/#LineWithMarkers)).
1. Přistupte k hodnotové ose grafu a nastavte následující vlastnosti:
   1. Nastavte **Line format** pro hlavní mřížkové čáry hodnotové osy.
   1. Nastavte **Line format** pro vedlejší mřížkové čáry hodnotové osy.
   1. Nastavte **Number Format** pro hodnotovou osu.
   1. Nastavte **minimum, maximum, major, and minor units** pro hodnotovou osu.
   1. Nastavte **Text Properties** pro data hodnotové osy.
   1. Nastavte **Title** pro hodnotovou osu.
1. Přistupte k kategoriální ose grafu a nastavte následující vlastnosti:
   1. Nastavte **Line format** pro hlavní mřížkové čáry kategoriální osy.
   1. Nastavte **Line format** pro vedlejší mřížkové čáry kategoriální osy.
   1. Nastavte **Text Properties** pro data kategoriální osy.
   1. Nastavte **Title** pro kategoriální osu.
   1. Nastavte **Label Positioning** pro kategoriální osu.
   1. Nastavte **Rotation Angle** pro popisky kategoriální osy.
1. Přistupte k legendě grafu a nastavte její **text properties**.
1. Zobrazte legendu grafu bez překrývání grafu.
1. Přistupte k **sekundární hodnotové ose** grafu a nastavte následující vlastnosti:
   1. Povolte **sekundární hodnotovou osu**.
   1. Nastavte **Line Format** pro sekundární hodnotovou osu.
   1. Nastavte **Number Format** pro sekundární hodnotovou osu.
   1. Nastavte **minimum, maximum, major, and minor units** pro sekundární hodnotovou osu.
1. Vykreslete první řadu grafu na sekundární hodnotovou osu.
1. Nastavte barvu výplně zadní stěny grafu.
1. Nastavte barvu výplně oblasti grafu.
1. Zapište upravenou prezentaci do souboru PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayUnitType, FillType, FontData, LineDashStyle, LineStyle, NullableBool, Presentation, PresetColor, SaveFormat, TickLabelPositionType

Color = jpype.JClass("java.awt.Color")
nullable_true = NullableBool.True_

# Vytvořte instanci třídy Presentation
presentation = Presentation()
try:
    # Přistupte k prvnímu snímku
    slide = presentation.getSlides().get_Item(0)

    # Přidejte ukázkový graf
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400)

    # Nastavte název grafu
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("")
    chart_title = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    chart_title.setText("Sample Chart")
    chart_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    chart_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    chart_title.getPortionFormat().setFontHeight(20)
    chart_title.getPortionFormat().setFontBold(nullable_true)
    chart_title.getPortionFormat().setFontItalic(nullable_true)

    # Nastavte formát hlavních mřížkových čar pro hodnotovou osu
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot)

    # Nastavte formát vedlejších mřížkových čar pro hodnotovou osu
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    # Nastavte číselný formát hodnotové osi
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%")

    # Nastavte maximální a minimální hodnoty grafu
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getVerticalAxis().setMaxValue(15)
    chart.getAxes().getVerticalAxis().setMinValue(-2)
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0)

    # Nastavte vlastnosti textu hodnotové osy
    value_axis_text = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat()
    value_axis_text.setFontBold(nullable_true)
    value_axis_text.setFontHeight(16)
    value_axis_text.setFontItalic(nullable_true)
    value_axis_text.getFillFormat().setFillType(FillType.Solid)
    value_axis_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen)
    value_axis_font = FontData("Times New Roman")
    value_axis_text.setLatinFont(value_axis_font)

    # Nastavte název hodnotové osy
    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("")
    value_axis_title = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    value_axis_title.setText("Primary Axis")
    value_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    value_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    value_axis_title.getPortionFormat().setFontHeight(20)
    value_axis_title.getPortionFormat().setFontBold(nullable_true)
    value_axis_title.getPortionFormat().setFontItalic(nullable_true)

    # Nastavte formát hlavních mřížkových čar pro kategoriální osu
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5)

    # Nastavte formát vedlejších mřížkových čar pro kategoriální osu
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    # Nastavte vlastnosti textu kategoriální osy
    category_axis_text = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat()
    category_axis_text.setFontBold(nullable_true)
    category_axis_text.setFontHeight(16)
    category_axis_text.setFontItalic(nullable_true)
    category_axis_text.getFillFormat().setFillType(FillType.Solid)
    category_axis_text.getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    category_axis_font = FontData("Arial")
    category_axis_text.setLatinFont(category_axis_font)

    # Nastavte název kategoriální osy
    chart.getAxes().getHorizontalAxis().setTitle(True)
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("")

    category_axis_title = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    category_axis_title.setText("Sample Category")
    category_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    category_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    category_axis_title.getPortionFormat().setFontHeight(20)
    category_axis_title.getPortionFormat().setFontBold(nullable_true)
    category_axis_title.getPortionFormat().setFontItalic(nullable_true)

    # Nastavte pozici popisků kategoriální osy
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low)

    # Nastavte úhel otáčení popisků kategoriální osy
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45)

    # Nastavte vlastnosti textu legendy
    legend_text = chart.getLegend().getTextFormat().getPortionFormat()
    legend_text.setFontBold(nullable_true)
    legend_text.setFontHeight(16)
    legend_text.setFontItalic(nullable_true)
    legend_text.getFillFormat().setFillType(FillType.Solid)
    legend_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed)

    # Zobrazte legendu grafu bez překrývání grafu

    chart.getLegend().setOverlay(False)

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(True)
    # Nastavte sekundární hodnotovou osu
    chart.getAxes().getSecondaryVerticalAxis().setVisible(True)
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin)
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20)

    # Nastavte číselný formát sekundární hodnotové osy
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds)
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%")

    # Nastavte maximální a minimální hodnoty grafu
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20)
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5)
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0)

    # Nastavte barvu zadní stěny grafu
    chart.getBackWall().setThickness(1)
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid)
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE)

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid)
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED)
    # Nastavte barvu oblasti grafu
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid)
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan)

    # Uložte prezentaci
    presentation.save("FormattedChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nastavení vlastností písma pro graf**

Aspose.Slides for Python via Java podporuje nastavení vlastností písma pro grafy. Postupujte podle těchto kroků k nastavení vlastností písma:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
- Přidejte graf do snímku.
- Nastavte výšku písma.
- Uložte upravenou prezentaci.

Následující příklad demonstruje tyto kroky.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Vytvořte instanci třídy Presentation
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)

    chart.getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nastavení číselného formátu**

Aspose.Slides for Python via Java poskytuje jednoduché API pro správu formátů dat grafu:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
1. Přistupte k snímku podle jeho indexu.
1. Přidejte graf požadovaného typu s výchozími daty (v tomto příkladu se používá [ChartType.ClusteredColumn](https://reference.aspose.com/slides/cs/python-java/aspose.slides/charttype/#ClusteredColumn)).
1. Nastavte přednastavený číselný formát z možných přednastavených hodnot.
1. Projděte buňky dat v každé řadě grafu a nastavte jejich číselný formát.
1. Uložte prezentaci.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Vytvořte instanci třídy Presentation
presentation = Presentation()
try:
    # Přistupte k prvnímu snímku prezentace
    slide = presentation.getSlides().get_Item(0)

    # Přidejte výchozí shlukovaný sloupcový graf
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400)

    # Přistupte ke kolekci řad grafu
    chart_series_collection = chart.getChartData().getSeries()

    # Procházejte všechny řady grafu
    for chart_series in chart_series_collection:
        # Procházejte všechny datové body v řadě
        for data_point in chart_series.getDataPoints():
            # Nastavte číselný formát
            data_point.getValue().getAsCell().setPresetNumberFormat(jpype.JByte(10))  # 0.00%

    # Uložte prezentaci
    presentation.save("PresetNumberFormat.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Dostupné přednastavené číselné formáty a jejich indexy jsou uvedeny níže:

|**0**|Obecný|
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

## **Nastavení zakulacených okrajů oblasti grafu**

Aspose.Slides for Python via Java podporuje zakulacené rohy pro oblast grafu prostřednictvím metod [hasRoundedCorners](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chart/#hasRoundedCorners) a [setRoundedCorners](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chart/#setRoundedCorners) třídy [Chart](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chart/).

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
1. Přidejte graf do snímku.
1. Nastavte typ výplně a styl čáry okraje grafu.
1. Povolte zakulacené rohy.
1. Uložte upravenou prezentaci.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineStyle, Presentation, SaveFormat

# Vytvořte instanci třídy Presentation
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

## **Často kladené otázky**

**Mohu nastavit poloprůhledné výplně pro sloupce/oblasti a zároveň zachovat okraj neprůhledný?**

Ano. Průhlednost výplně a obrys jsou konfigurovány odděleně. To je užitečné pro zlepšení čitelnosti mřížky a dat v hustých vizualizacích.

**Jak mohu řešit popisky dat, když se překrývají?**

Zmenšete velikost písma, zakažte nepodstatné komponenty popisků (například kategorie), nastavte offset/pozici popisku, zobrazte popisky jen pro vybrané body, pokud je to nutné, nebo přepněte formát na „value + legend“.

**Mohu použít gradientní nebo vzorové výplně na řady?**

Ano. Obvykle jsou k dispozici jak plné, tak gradientní/vzorové výplně. V praxi používejte gradienty střídmě a vyhněte se kombinacím, které snižují kontrast s mřížkou a textem.