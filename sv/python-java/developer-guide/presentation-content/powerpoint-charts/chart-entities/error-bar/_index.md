---
title: Anpassa felstaplar i presentationsdiagram med Python
linktitle: Felstapel
type: docs
url: /sv/python-java/error-bar/
keywords:
- felstapel
- anpassat värde
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Lär dig hur du lägger till och anpassar felstaplar i diagram med Aspose.Slides för Python via Java—optimera datavisualiseringar i PowerPoint-presentationer."
---
## **Översikt**

Denna artikel förklarar hur man arbetar med felstaplar i presentationsdiagram med hjälp av Aspose.Slides. Den visar hur man lägger till felstaplar i en diagramserie, konfigurerar X- och Y-felstaplar, och använder olika värdetyper såsom fast, procentuell och anpassade värden.

Den visar också hur man tilldelar anpassade felstaplarsvärden för enskilda datapunkter i en serie genom att använda motsvarande datapunktssamling. Dessutom innehåller artikeln korta anteckningar om hur felstaplar beter sig vid export, deras kompatibilitet med markörer och datatetiketter, samt var man hittar de relaterade API‑referensklasserna och enumen.

## **Lägg till felstaplar**

Aspose.Slides for Python via Java erbjuder ett enkelt API för att hantera felstaplarsvärden. Följande exempelprogram använder fasta och procentuella värdetyper.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
1. Lägg till ett bubbeldiagram på den önskade bilden.
1. Åtkomst till den första diagramserien och ange felstapelformatet för X.
1. Åtkomst till den första diagramserien och ange felstapelformatet för Y.
1. Ange felstaplarnas värden och formatering.
1. Skriv den ändrade presentationen till en PPTX‑fil.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

# Skapa en instans av Presentation-klassen.
presentation = Presentation()
try:
    # Skapa ett bubbeldiagram.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # Lägg till felstaplar och ange deras formatering.
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

    # Spara presentationen.
    presentation.save("ErrorBars.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Lägg till anpassade felstaplarsvärden**

Aspose.Slides for Python via Java erbjuder ett enkelt API för att hantera anpassade felstaplarsvärden. Följande exempelprogram gäller när [getValueType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/errorbarsformat/#getValueType) returnerar [ErrorBarValueType.Custom](https://reference.aspose.com/slides/sv/python-java/aspose.slides/errorbarvaluetype/#Custom). För att ange ett värde, använd [getErrorBarsCustomValues](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartdatapoint/#getErrorBarsCustomValues) för en specifik datapunkt i samlingen som returneras av serie‑metoden [getDataPoints](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartseries/#getDataPoints).

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
1. Lägg till ett bubbeldiagram på den önskade bilden.
1. Åtkomst till den första diagramserien och ange felstapelformatet för X.
1. Åtkomst till den första diagramserien och ange felstapelformatet för Y.
1. Åtkomst till de enskilda datapunkterna i diagramserien och ange deras felstaplarsvärden.
1. Ange felstaplarnas värden och formatering.
1. Skriv den ändrade presentationen till en PPTX‑fil.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

# Skapa en instans av Presentation-klassen.
presentation = Presentation()
try:
    # Skapa ett bubbeldiagram.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # Lägg till anpassade felstaplar och ange deras formatering.
    series = chart.getChartData().getSeries().get_Item(0)
    error_bar_x = series.getErrorBarsXFormat()
    error_bar_y = series.getErrorBarsYFormat()
    error_bar_x.setVisible(True)
    error_bar_y.setVisible(True)
    error_bar_x.setValueType(ErrorBarValueType.Custom)
    error_bar_y.setValueType(ErrorBarValueType.Custom)

    # Åtkomst till diagramseriens datapunkter och konfigurera deras felstaplars värde‑källor.
    points = series.getDataPoints()
    data_source = points.getDataSourceTypeForErrorBarsCustomValues()
    data_source.setDataSourceTypeForXPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForXMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))

    # Ange felstaplarsvärden för diagramseriens datapunkter.
    for i in range(points.size()):
        custom_values = points.get_Item(i).getErrorBarsCustomValues()
        custom_values.getXMinus().setAsLiteralDouble(i + 1)
        custom_values.getXPlus().setAsLiteralDouble(i + 1)
        custom_values.getYMinus().setAsLiteralDouble(i + 1)
        custom_values.getYPlus().setAsLiteralDouble(i + 1)

    # Spara presentationen.
    presentation.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Vad händer med felstaplar när man exporterar en presentation till PDF eller bilder?**

De renderas som en del av diagrammet och bevaras vid konverteringen tillsammans med resten av diagramformateringen, förutsatt att en kompatibel version eller renderare används.

**Kan felstaplar kombineras med markörer och datatetiketter?**

Ja. Felstaplar är ett separat element och är kompatibla med markörer och datatetiketter; om elementen överlappar kan du behöva justera formateringen.

**Var kan jag hitta listan över egenskaper och klasser för att arbeta med felstaplar i API:et?**

I API‑referensen: klassen [ErrorBarsFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/errorbarsformat/) och de relaterade klasserna [ErrorBarType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/errorbartype/) och [ErrorBarValueType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/errorbarvaluetype/).