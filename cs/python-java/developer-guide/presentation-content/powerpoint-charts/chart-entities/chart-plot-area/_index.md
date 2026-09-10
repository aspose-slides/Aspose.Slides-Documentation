---
title: Přizpůsobení oblastí vykreslování grafů v prezentacích v Pythonu
linktitle: Oblast vykreslování
type: docs
url: /cs/python-java/chart-plot-area/
keywords:
- graf
- oblast vykreslování
- šířka oblasti vykreslování
- výška oblasti vykreslování
- velikost oblasti vykreslování
- režim rozvržení
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Objevte, jak přizpůsobit oblasti vykreslování grafů v prezentacích PowerPoint pomocí Aspose.Slides pro Python přes Java. Zlepšte vizuální podobu snímků bez námahy."
---
## **Přehled**

Tento článek ukazuje, jak pracovat s oblastí vykreslování grafu v Aspose.Slides. Vysvětluje, jak získat skutečnou polohu a velikost oblasti vykreslování ověřením rozvržení grafu a následným načtením hodnot X, Y, šířky a výšky.

Také ukazuje, jak nastavit režim rozvržení oblasti vykreslování, když je rozvržení nastaveno ručně, pomocí [LayoutTargetType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layouttargettype/) k definování, zda je oblast vykreslování počítána dle vnitřní oblasti nebo dle vnější oblasti společně s osami a popisky os.

## **Získání šířky a výšky oblasti vykreslování grafu**

Aspose.Slides for Python via Java poskytuje jednoduché API pro čtení skutečné polohy a velikosti oblasti vykreslování grafu.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
1. Získejte první snímek.
1. Přidejte graf s výchozími daty.
1. Volajte metodu [Chart.validateChartLayout](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chart/#validateChartLayout) před získáním skutečných hodnot.
1. Získejte skutečnou hodnotu X (levá) elementu grafu relativně k levému hornímu rohu grafu.
1. Získejte skutečnou hodnotu Y (horní) elementu grafu relativně k levému hornímu rohu grafu.
1. Získejte skutečnou šířku elementu grafu.
1. Získejte skutečnou výšku elementu grafu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

# Vytvořte instanci třídy Presentation.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350)
    chart.validateChartLayout()

    plot_area = chart.getPlotArea()
    x = plot_area.getActualX()
    y = plot_area.getActualY()
    width = plot_area.getActualWidth()
    height = plot_area.getActualHeight()
finally:
    presentation.dispose()
```

## **Nastavení režimu rozvržení oblasti vykreslování grafu**

Aspose.Slides for Python via Java poskytuje jednoduché API pro nastavení režimu rozvržení oblasti vykreslování grafu. Metody [setLayoutTargetType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartplotarea/#setLayoutTargetType) a [getLayoutTargetType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartplotarea/#getLayoutTargetType) jsou k dispozici ve třídě [ChartPlotArea](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartplotarea/). Pokud je rozvržení oblasti vykreslování definováno ručně, toto nastavení určuje, zda rozvrhnout oblast vykreslování podle vnitřní (bez os a popisků os) nebo vnější (s osami a popisky os) strany. Existují dvě možné hodnoty definované v enumeraci [LayoutTargetType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layouttargettype/).

- [Inner](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layouttargettype/#Inner) určuje, že velikost oblasti vykreslování nezahrnuje značky a popisky os.
- [Outer](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layouttargettype/#Outer) určuje, že velikost oblasti vykreslování zahrnuje značky a popisky os.

Níže je uveden ukázkový kód.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LayoutTargetType, Presentation, SaveFormat

# Vytvořte instanci třídy Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    plot_area = chart.getPlotArea()
    plot_area.setX(0.2)
    plot_area.setY(0.2)
    plot_area.setWidth(0.7)
    plot_area.setHeight(0.7)
    plot_area.setLayoutTargetType(LayoutTargetType.Inner)

    presentation.save("SetLayoutMode_inner.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**V jakých jednotkách jsou vráceny skutečné X, skutečné Y, skutečná šířka a skutečná výška?**

V bodech; 1 palec = 72 bodů. Jedná se o souřadnicové jednotky Aspose.Slides.

**Jak se liší oblast vykreslování od oblasti grafu z hlediska obsahu?**

Oblast vykreslování je oblast, kde se kreslí data (řady, mřížky, trendové čáry atd.); oblast grafu zahrnuje okolní prvky (název, legendu atd.). Ve 3D grafech oblast vykreslování také zahrnuje stěny/podlahu a osy.

**Jak jsou X, Y, šířka a výška oblasti vykreslování interpretovány, když je rozvržení nastaveno ručně?**

Jedná se o zlomky (0–1) celkové velikosti grafu; v tomto režimu je automatické umisťování vypnuto a použijí se nastavené zlomky.

**Proč se pozice oblasti vykreslování změnila po přidání nebo přesunutí legendy?**

Legenda se nachází v oblasti grafu mimo oblast vykreslování, ale ovlivňuje rozvržení a dostupný prostor, takže oblast vykreslování se může posunout, když je zapnuté automatické umisťování. (Jedná se o standardní chování grafů v PowerPointu.)