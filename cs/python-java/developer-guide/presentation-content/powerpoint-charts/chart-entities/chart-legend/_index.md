---
title: Přizpůsobení legend grafů v prezentacích pomocí Pythonu
linktitle: Legenda grafu
type: docs
url: /cs/python-java/chart-legend/
keywords:
- legenda grafu
- pozice legendy
- velikost písma
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Přizpůsobte legendy grafů pomocí Aspose.Slides pro Python přes Java a optimalizujte prezentace PowerPoint s upraveným formátováním legend."
---
## **Přehled**

Aspose.Slides for Python via Java poskytuje možnosti přizpůsobení legend grafů v prezentacích PowerPoint. Tento článek ukazuje, jak umístit a změnit velikost legendy, nastavit velikost písma pro celou legendu, formátovat jednotlivou položku legendy a skrýt nebo obnovit vybrané položky.

FAQ pokrývá související chování, včetně rezervace místa pro legendu, zobrazení víceřádkových popisků a dědění formátování z motivu prezentace.

## **Umístění legendy**

Použijte metody legendy [setX](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setX), [setY](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setY), [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setWidth) a [setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setHeight) k určení její pozice a velikosti jako podílů rozměrů grafu.

Tento příklad vytváří prezentaci a přidává seskupený sloupcový graf s výchozími daty na první snímek. Rozdělením požadovaných posunů a rozměrů legendy šířkou a výškou grafu je převede na relativní hodnoty: legenda je od grafu odsazena o 50 bodů od levého horního rohu a má velikost 100 × 100 bodů.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500)

    # Vyjádřete pozici a velikost legendy relativně k grafu.
    chart.getLegend().setX(50 / chart.getWidth())
    chart.getLegend().setY(50 / chart.getHeight())
    chart.getLegend().setWidth(100 / chart.getWidth())
    chart.getLegend().setHeight(100 / chart.getHeight())

    presentation.save("legend_position.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nastavení velikosti písma legendy**

Použijte legendu [getTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getTextFormat) k získání formátování textu a [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) k nastavení velikosti písma v bodech.

Tento příklad vytváří graf s výchozími daty a nastavuje text legendy na 20 bodů. Také vypíná automatické ohraničení pro svislou osu a nastavuje její rozsah na -5 až 10.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)
    chart.getAxes().getVerticalAxis().setMinValue(-5)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setMaxValue(10)

    presentation.save("legend_font_size.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nastavení velikosti písma konkrétní položky legendy**

Použijte kolekci vrácenou metodou legendy [getEntries](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getEntries) k přístupu k formátování konkrétní položky. Indexy položek jsou nulové, takže index `1` odkazuje na druhou položku.

Tento příklad vytváří seskupený sloupcový graf, jehož výchozí data obsahují alespoň dva seriály. Formátuje druhou položku legendy tučným, kurzívou a 20‑bodovým modrým textem.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    text_format = chart.getLegend().getEntries().get_Item(1).getTextFormat()

    text_format.getPortionFormat().setFontBold(NullableBool.True_)
    text_format.getPortionFormat().setFontHeight(20)
    text_format.getPortionFormat().setFontItalic(NullableBool.True_)
    text_format.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    text_format.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("legend_entry_format.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Skrytí konkrétních položek legendy**

Chcete-li vyloučit pomocný seriál z legendy při zachování jeho dat, zavolejte [LegendEntryProperties.setHide](https://reference.aspose.com/slides/python-java/aspose.slides/legendentryproperties/#setHide) s hodnotou `True` přes [ChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getRelatedLegendEntry). Tím se skryje pouze vybraná položka legendy; nesmaže to seriál ani jeho datové body. Volání [Chart.setLegend](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setLegend) s hodnotou `False` naopak skryje celou legendu.

Níže uvedený příklad vytváří seskupený sloupcový graf s více seriály pomocí výchozích dat. Skryje položku legendy druhého seriálu (index `1`) a uloží prezentaci. Poté položku obnoví voláním [setHide](https://reference.aspose.com/slides/python-java/aspose.slides/legendentryproperties/#setHide) s hodnotou `False` a uloží druhou kopii. Sloupce zůstávají viditelné v obou souborech.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setLegend(True)

    legend_entry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry()

    legend_entry.setHide(True)
    presentation.save("hidden_legend_entry.pptx", SaveFormat.Pptx)

    # Obnovte stejnou položku bez změny dat grafu.
    legend_entry.setHide(False)
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Porovnání níže ukazuje stejný graf se všemi položkami legendy viditelnými a s druhou položkou skrytou. Sloupce druhého seriálu zůstávají beze změny.

![Porovnání grafu se všemi položkami legendy viditelnými a s druhým seriálem skrytým v legendě; všechny sloupce zůstávají viditelné.](hide-legend-entry.png)

Ve sloupcových, pruhových a čárových grafech položky legendy identifikují seriály. V koláčových grafech identifikují jednotlivé datové body (výseče), takže použijte [ChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getRelatedLegendEntry) na vybrané výseči. API dokumentuje tuto metodu datového bodu pro typy grafů `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` a `BarOfPie`. Nepředpokládejte, že se vztahuje i na prstencové grafy, které v tomto seznamu nejsou.

## **FAQ**

**Mohu nechat graf vyhradit prostor pro legendu místo překrývání?**

Ano. Zavolejte [setOverlay](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setOverlay) s hodnotou `False`, abyste rezervovali místo pro legendu místo povolení překrytí vykreslovací plochy.

**Mohu mít víceliniové popisky legendy?**

Ano. Dlouhé popisky se mohou zalomit, když není k dispozici dostatečná šířka. Můžete také použít znaky nového řádku v názvech sérií pro požadavek na zalomení.

**Jak zajistit, aby legenda následovala barevné schéma motivu prezentace?**

Nechte barvy, výplně a písma legendy nenastavené, aby mohla zdědit formátování motivu. Explicitní formátování přepíše odpovídající nastavení motivu.