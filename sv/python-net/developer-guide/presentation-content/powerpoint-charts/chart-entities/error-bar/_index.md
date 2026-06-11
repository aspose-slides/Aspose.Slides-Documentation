---
title: Anpassa felstaplar i presentationsdiagram med Python
linktitle: Felstapel
type: docs
url: /sv/python-net/error-bar/
keywords:
- felstapel
- anpassat värde
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Lär dig hur du lägger till och anpassar felstaplar i diagram med Aspose.Slides för Python via .NET—optimera datavisualiseringar i PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

Denna artikel förklarar hur man arbetar med felstaplar i presentationsdiagram med hjälp av Aspose.Slides. Den visar hur man lägger till felstaplar i en diagramserie, konfigurerar X- och Y-felstaplar och använder olika värdetyper såsom fasta, procentuella och anpassade värden.

Den demonstrerar också hur man tilldelar anpassade felstaplar för enskilda datapunkter i en serie genom att använda den motsvarande datapunktssamlingen. Dessutom innehåller artikeln korta anteckningar om hur felstaplar beter sig under export, deras kompatibilitet med markörer och datalabeler samt var man hittar de relaterade API‑referensklasserna och enum.

## **Lägg till felstapel**
Aspose.Slides for Python via .NET tillhandahåller ett enkelt API för att hantera felstapelsvärden. Exempelkoden gäller när man använder en anpassad värdetyp. För att ange ett värde, använd egenskapen **ErrorBarCustomValues** för en specifik datapunkt i **DataPoints**‑samlingen för serien:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Lägg till ett bubbeldiagram på önskad bild.
1. Hämta den första diagramserien och ställ in X-formatet för felstapeln.
1. Hämta den första diagramserien och ställ in Y-formatet för felstapeln.
1. Ställ in staplarnas värden och format.
1. Skriv den ändrade presentationen till en PPTX-fil.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Skapar tom presentation
with slides.Presentation() as presentation:
    # Skapar ett bubbeldiagram
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # Lägger till felstaplar och ställer in deras format
    errBarX = chart.chart_data.series[0].error_bars_x_format
    errBarY = chart.chart_data.series[0].error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.FIXED
    errBarX.value = 0.1
    errBarY.value_type = charts.ErrorBarValueType.PERCENTAGE
    errBarY.value = 5
    errBarX.type = charts.ErrorBarType.PLUS
    errBarY.format.line.width = 2
    errBarX.has_end_cap = True

    # Sparar presentation
    presentation.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Lägg till anpassat felstapelsvärde**
Aspose.Slides for Python via .NET tillhandahåller ett enkelt API för att hantera anpassade felstapelsvärden. Exempelkoden gäller när egenskapen **IErrorBarsFormat.ValueType** är lika med **Custom**. För att ange ett värde, använd egenskapen **ErrorBarCustomValues** för en specifik datapunkt i **DataPoints**‑samlingen för serien:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Lägg till ett bubbeldiagram på önskad bild.
1. Hämta den första diagramserien och ställ in X-formatet för felstapeln.
1. Hämta den första diagramserien och ställ in Y-formatet för felstapeln.
1. Hämta de enskilda datapunkterna i diagramserien och ange felstapelförvärden för varje datapunkt i serien.
1. Ställ in staplarnas värden och format.
1. Skriv den ändrade presentationen till en PPTX-fil.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Skapar tom presentation
with slides.Presentation() as presentation:
    # Skapar ett bubbeldiagram
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # Lägger till anpassade felstaplar och ställer in deras format
    series = chart.chart_data.series[0]
    errBarX = series.error_bars_x_format
    errBarY = series.error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.CUSTOM
    errBarY.value_type = charts.ErrorBarValueType.CUSTOM

    # Åtkomst till diagramseriens datapunkt och ställer in felstaplar för enskild punkt
    points = series.data_points
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_minus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_minus_values = charts.DataSourceType.DOUBLE_LITERALS

    # Ställer in felstaplar för diagramseriens punkter
    for i in range(len(points)):
        points[i].error_bars_custom_values.x_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.x_plus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_plus.as_literal_double = i + 1

    # Sparar presentation
    presentation.save("ErrorBarsCustomValues_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Vad händer med felstaplar när man exporterar en presentation till PDF eller bilder?**

De renderas som en del av diagrammet och bevaras under konverteringen tillsammans med resten av diagramformatet, förutsatt att en kompatibel version eller renderare används.

**Kan felstaplar kombineras med markörer och datalabeler?**

Ja. Felstaplar är ett separat element och är kompatibla med markörer och datalabeler; om elementen överlappar kan du behöva justera formateringen.

**Var kan jag hitta listan över egenskaper och enum för att arbeta med felstaplar i API:et?**

I API‑referensen: klassen [ErrorBarsFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/errorbarsformat/) och de relaterade enum‑typerna [ErrorBarType](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/errorbartype/) och [ErrorBarValueType](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/errorbarvaluetype/).