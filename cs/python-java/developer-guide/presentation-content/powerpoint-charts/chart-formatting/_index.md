---
title: Formátování grafů prezentace v Pythonu
linktitle: Formátování grafu
type: docs
weight: 60
url: /cs/python-java/chart-formatting/
keywords:
- formátovat graf
- formátování grafu
- prvek grafu
- vlastnosti grafu
- nastavení grafu
- možnosti grafu
- vlastnosti písma
- zaoblený okraj
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Naučte se formátovat grafy v Aspose.Slides pro Python pomocí Javy a vylepšete svou prezentaci PowerPoint pomocí vlastních os, písem, číselných formátů a zaoblených okrajů grafu."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Aspose.Slides formátovat grafy v prezentacích PowerPoint. Ukazuje, jak přizpůsobit klíčové prvky grafu, jako jsou osy, mřížkové čáry, nadpisy, legendy, vykreslovací oblast a výplně stěn, aby se zlepšil vzhled a čitelnost dat v grafu.

Také demonstruje, jak nastavit vlastnosti písma pro text v grafu, použít předdefinované číselné formáty pro data v grafu a povolit zaoblené rohy pro oblast grafu. Tyto příklady ukazují, jak ovládat jak vizuální styl, tak prezentaci dat v grafu v prezentaci.

## **Formátovat entity grafu**

Použijte [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) k formátování nadpisů grafu, os, mřížkových čar, legend a vykreslovací oblasti. Tento příklad vytváří čárový graf s značkami a výchozími daty, poté aplikuje samostatné textové a čárové styly na osu hodnot a osu kategorií. Velikosti písma a šířky čar jsou zadány v bodech; štítky kategorií jsou otočeny o 45 stupňů.

Osa hodnot používá [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) nezávisle na zdrojových buňkách. Její měřítko běží od -2 do 15 s hlavními intervaly 2 a vedlejšími intervaly 0,5. Příklad také kombinuje formátování procent s [setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) nastaveným na tisíce, takže upravte tato nastavení podle významu a rozsahu vašich dat. Legenda zůstává mimo vykreslovací oblast, protože [setOverlay](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setOverlay) je volána s `False`. Výplně zadní stěny a podlahy jsou konfigurovány pomocí [getBackWall](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getBackWall) a [getFloor](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getFloor), ale tyto povrchy jsou viditelné jen v 3D grafech.

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

## **Nastavit vlastnosti písma pro graf**

Nastavte výchozí velikost písma pro text v grafu pomocí [Chart.getTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getTextFormat). Příklad vytváří seskupený sloupcový graf s 20‑bodovým písmem a povoluje štítky hodnot pro první sérii pomocí [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue). Textové prvky s vlastními explicitními nastaveními písma mohou přebít výchozí nastavení grafu.

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

## **Nastavit číselný formát**

Použijte [ChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setPresetNumberFormat) k aplikaci vestavěného číselného formátu na buňky pracovního sešitu grafu. Tento příklad vytváří seskupený sloupcový graf s výchozími, buňkami podloženými daty a aplikuje formátový index 10 (`0.00%`) na buňku hodnoty každé série. Tím se změní způsob, jakým jsou hodnoty zobrazeny v sešitu, aniž by se změnily podkladové číslice; například 0,25 se zobrazí jako 25,00 %. Formáty os a popisků dat lze konfigurovat odděleně.

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

Následující tabulka uvádí vestavěné číselné formátové indexy s reprezentativními formáty Excelu pro anglické (USA) národní prostředí. Přesné řetězce formátů a jejich zobrazení se mohou lišit podle aplikace a národního prostředí, zejména pro měny a data. Některé formáty Excelu se také liší od výchozích hodnot v standardu OOXML, jak je popsáno v [poznámkách k implementaci číselného formátu společnosti Microsoft](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| Index | Formát |
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

## **Nastavit zakulacené okraje oblasti grafu**

Zavolejte [Chart.setRoundedCorners](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setRoundedCorners) s `True`, aby se rohy oblasti grafu zaoblily. Příklad vytváří seskupený sloupcový graf a používá [getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) k nastavení obrysu na pevnou šedou barvu a jednojádrový styl před uložením prezentace.

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

## **Upravit existující poznámky k grafu**

Graf může obsahovat vlastní tvary, například textovou poznámku vysvětlující stav zprávy. Přístup k těmto tvarům získáte přes [Chart.getUserShapes](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getUserShapes). Kolekce vrácená metodou [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) obsahuje tvary vlastněné grafem.

Obyčejné textové pole umístěné nad grafem patří do snímku, i když vypadá jako součást grafu. Procházením [Slide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes) se najde graf a běžné tvary snímku, ale nevyjmenují se jednotlivé tvary uvnitř grafu. Nadpisy grafu a popisky dat jsou samostatné grafické prvky, nikoli vlastní poznámky v této kolekci.

Stáhněte [chart-annotations.pptx](chart-annotations.pptx) a umístěte jej do pracovního adresáře aplikace. Jeho první snímek obsahuje graf s neagregovanou poznámkou „Preliminary results“, řádkem vlastněným grafem a obyčejným textovým polem snímku „Slide overlay“. Příklad najde první graf na tomto snímku a změní poznámku na „Final results“, když je zpráva připravena k publikaci. Ověří, zda je kolekce prázdná, a upraví pouze [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) s textovým rámečkem odlišným od `None`, který vrací [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#getTextFrame), a očekávaný text.

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

Čára a textové pole snímku zůstávají beze změny. Následující obrázky ukazují vstupní soubor a uložený, znovu otevřený výsledek:

| Před úpravou | Po úpravě |
| --- | --- |
| ![Chart annotation reading Preliminary results](chart-annotations-before.png) | ![Chart annotation reading Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
Příklad zkoumá pouze tvary na nejvyšší úrovni, které vlastní graf. Pokud je poznámka uvnitř [GroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/), také prozkoumejte kolekci [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) této skupiny. Opakujte to rekurzivně pro vnořené skupiny a použijte stejné kontroly textu na jejich podřízené tvary. Skupina sama je kontejner; nepovažujte ji za textové pole.
{{% /alert %}}

## **FAQ**

**Mohu nastavit poloprůhledné výplně pro sloupce/oblastí a přitom zachovat okraj neprůhledný?**

Ano. Průhlednost výplně a obrys jsou konfigurovány odděleně. To je užitečné pro zlepšení čitelnosti mřížky a dat v hustých vizualizacích.

**Jak mohu řešit překrývající se popisky dat?**

Zmenšte velikost písma, vypněte nepodstatné komponenty popisků (například kategorie), upravte umístění popisku, zobrazujte popisky jen pro vybrané body, nebo přepněte formát na „hodnota + legenda“.

**Mohu na sérii použít gradientní nebo vzorové výplně?**

Ano. Série podporují pevné, gradientní a vzorové výplně. V praxi používejte gradienty střídmě a vyhněte se kombinacím, které snižují kontrast vůči mřížce a textu.