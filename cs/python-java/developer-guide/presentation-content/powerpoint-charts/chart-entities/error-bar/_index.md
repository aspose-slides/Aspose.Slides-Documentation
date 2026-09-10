---
title: Přizpůsobení chybových pruhů v grafech prezentací pomocí Pythonu
linktitle: Chybový pruh
type: docs
url: /cs/python-java/error-bar/
keywords:
- chybový pruh
- vlastní hodnota
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Naučte se, jak přidat a přizpůsobit chybové pruhy v grafech pomocí Aspose.Slides pro Python přes Java — optimalizujte vizualizaci dat v PowerPoint prezentacích."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s chybovými pruhy v grafických prezentacích pomocí Aspose.Slides. Ukazuje, jak přidat chybové pruhy do série grafu, nakonfigurovat nastavení chybových pruhů X a Y a použít různé typy hodnot, jako jsou pevné, procentuální a vlastní hodnoty.

Také ukazuje, jak přiřadit vlastní hodnoty chybových pruhů pro jednotlivé datové body v sérii pomocí odpovídající kolekce datových bodů. Kromě toho článek obsahuje stručné poznámky o tom, jak se chybové pruhy chovají během exportu, jejich kompatibilitě s značkami a popisky dat a kde najít související třídy a výčty v referenci API.

## **Přidat chybové pruhy**

Aspose.Slides pro Python přes Java poskytuje jednoduché API pro správu hodnot chybových pruhů. Následující ukázkový kód používá typy hodnot pevné a procentuální.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) .
1. Přidejte bublinový graf na požadovaný snímek.
1. Získejte první sérii grafu a nastavte formát chybového pruhu X.
1. Získejte první sérii grafu a nastavte formát chybového pruhu Y.
1. Nastavte hodnoty a formátování chybových pruhů.
1. Uložte upravenou prezentaci do souboru PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

# Vytvořte instanci třídy Presentation.
presentation = Presentation()
try:
    # Vytvořte bublinový graf.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # Přidejte chybové pruhy a nastavte jejich formátování.
    series = chart.getChartData().getSeries().get_Item(0)
    error_bar_x = series.getErrorBarsXFormat()
    error_bar_y = series.getErrorBarsYFormat()

    error_bar_x.setVisible(True)
    error_bar_y.setVisible(True)
    error_bar_x.setValueType(ErrorBarValueType.Fixed)
    error_bar_x.setValue(0.1)
    error_bar_y.setValueType(ErrorBarValueType.Percentage)
    error_bar_y.setValue(5)
    error_bar_x.setType(ErrorBarType.Plus)
    error_bar_y.getFormat().getLine().setWidth(2.0)
    error_bar_x.setEndCap(True)

    # Uložte prezentaci.
    presentation.save("ErrorBars.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Přidat vlastní hodnoty chybových pruhů**

Aspose.Slides pro Python přes Java poskytuje jednoduché API pro správu vlastních hodnot chybových pruhů. Následující ukázkový kód platí, když [getValueType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/errorbarsformat/#getValueType) vrátí [ErrorBarValueType.Custom](https://reference.aspose.com/slides/cs/python-java/aspose.slides/errorbarvaluetype/#Custom). Pro zadání hodnoty použijte [getErrorBarsCustomValues](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdatapoint/#getErrorBarsCustomValues) pro konkrétní datový bod v kolekci vrácené metodou série [getDataPoints](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartseries/#getDataPoints).

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) .
1. Přidejte bublinový graf na požadovaný snímek.
1. Získejte první sérii grafu a nastavte formát chybového pruhu X.
1. Získejte první sérii grafu a nastavte formát chybového pruhu Y.
1. Získejte jednotlivé datové body v sérii grafu a nastavte jejich hodnoty chybových pruhů.
1. Nastavte hodnoty a formátování chybových pruhů.
1. Uložte upravenou prezentaci do souboru PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

# Vytvořte instanci třídy Presentation.
presentation = Presentation()
try:
    # Vytvořte bublinový graf.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # Přidejte vlastní chybové pruhy a nastavte jejich formátování.
    series = chart.getChartData().getSeries().get_Item(0)
    error_bar_x = series.getErrorBarsXFormat()
    error_bar_y = series.getErrorBarsYFormat()
    error_bar_x.setVisible(True)
    error_bar_y.setVisible(True)
    error_bar_x.setValueType(ErrorBarValueType.Custom)
    error_bar_y.setValueType(ErrorBarValueType.Custom)

    # Získejte datové body série grafu a nastavte jejich zdroje hodnot chybových pruhů.
    points = series.getDataPoints()
    data_source = points.getDataSourceTypeForErrorBarsCustomValues()
    data_source.setDataSourceTypeForXPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForXMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))

    # Nastavte hodnoty chybových pruhů pro datové body série grafu.
    for i in range(points.size()):
        custom_values = points.get_Item(i).getErrorBarsCustomValues()
        custom_values.getXMinus().setAsLiteralDouble(i + 1)
        custom_values.getXPlus().setAsLiteralDouble(i + 1)
        custom_values.getYMinus().setAsLiteralDouble(i + 1)
        custom_values.getYPlus().setAsLiteralDouble(i + 1)

    # Uložte prezentaci.
    presentation.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Co se stane s chybovými pruhy při exportu prezentace do PDF nebo obrázků?**

Jsou vykresleny jako součást grafu a během konverze zachovány spolu se zbytkem formátování grafu, pokud je použita kompatibilní verze nebo renderer.

**Lze chybové pruhy kombinovat se značkami a popisky dat?**

Ano. Chybové pruhy jsou samostatným prvkem a jsou kompatibilní se značkami a popisky dat; pokud se prvky překrývají, může být potřeba upravit formátování.

**Kde mohu najít seznam vlastností a tříd pro práci s chybovými pruhy v API?**

V referenci API: třída [ErrorBarsFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/errorbarsformat/) a související třídy [ErrorBarType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/errorbartype/) a [ErrorBarValueType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/errorbarvaluetype/).