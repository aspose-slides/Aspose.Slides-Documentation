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
description: "Přizpůsobte legendy grafů pomocí Aspose.Slides pro Python přes Java a optimalizujte prezentace PowerPoint s přizpůsobeným formátováním legend."
---
## **Přehled**

Aspose.Slides poskytuje možnosti pro přizpůsobení legend grafů v prezentacích PowerPoint. Tento článek ukazuje, jak umístit a změnit velikost legendy, nastavit velikost písma pro celou legendu a použít formátování na jednotlivý položku legendy.  

Také se v častých dotazech (FAQ) probírají související chování, včetně použití režimu bez překrytí, aby oblast grafu vytvořila místo pro legendu, umožnění zalamování dlouhých popisků legendy nebo použití koncových řádků a umožnění, aby formátování legendy dědilo motiv prezentace, pokud nejsou nastaveny explicitní textové a výplňové vlastnosti.

## **Umístění legendy**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek.
1. Přidejte graf na snímek.
1. Nastavte vlastnosti legendy.
1. Uložte prezentaci jako soubor PPTX.

Následující příklad nastavuje pozici a velikost legendy grafu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Vytvořte prázdnou prezentaci.
presentation = Presentation()
try:
    # Získejte odkaz na snímek.
    slide = presentation.getSlides().get_Item(0)

    # Přidejte do snímku seskupený sloupcový graf.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500)

    # Nastavte vlastnosti legendy.
    legend = chart.getLegend()
    legend.setX(50 / chart.getWidth())
    legend.setY(50 / chart.getHeight())
    legend.setWidth(100 / chart.getWidth())
    legend.setHeight(100 / chart.getHeight())

    # Uložte prezentaci na disk.
    presentation.save("Legend_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nastavení velikosti písma legendy**

Aspose.Slides for Python via Java umožňuje nastavit velikost písma legendy. Postupujte podle těchto kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
1. Vytvořte výchozí graf.
1. Nastavte velikost písma.
1. Nastavte minimální hodnotu osy.
1. Nastavte maximální hodnotu osy.
1. Uložte prezentaci na disk.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Vytvořte prázdnou prezentaci.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20)

    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.setAutomaticMinValue(False)
    vertical_axis.setMinValue(-5)
    vertical_axis.setAutomaticMaxValue(False)
    vertical_axis.setMaxValue(10)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nastavení velikosti písma jednotlivé položky legendy**

Aspose.Slides for Python via Java umožňuje nastavit velikost písma jednotlivých položek legendy. Postupujte podle těchto kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
1. Vytvořte výchozí graf.
1. Získejte přístup k položce legendy.
1. Nastavte velikost písma.
1. Uložte prezentaci na disk.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# Vytvořte prázdnou prezentaci.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    text_format = chart.getLegend().getEntries().get_Item(1).getTextFormat()
    portion_format = text_format.getPortionFormat()

    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)
    portion_format.setFontItalic(NullableBool.True_)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Mohu povolit legendu tak, aby graf automaticky vyčlenil pro ni místo místo překrytí?**

Ano. Použijte [setOverlay](https://reference.aspose.com/slides/cs/python-java/aspose.slides/legend/#setOverlay) s hodnotou `False` pro povolení režimu bez překrytí; v tomto případě se oblast grafu zmenší, aby uvolnila místo pro legendu.

**Mohu vytvořit víceřádkové popisky legendy?**

Ano. Dlouhé popisky se automaticky zalamují, pokud není dostatek místa; nucené zalomení řádku je podporováno pomocí znaků nového řádku v názvu série.

**Jak zajistit, aby legenda následovala barevné schéma motivu prezentace?**

Nenastavujte explicitní barvy, výplně ani písma pro legendu nebo její text. Pak budou dědit motiv a při změně designu se správně aktualizují.