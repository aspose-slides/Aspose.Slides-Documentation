---
title: Anpassa felstaplar i presentationsdiagram i .NET
linktitle: Felstapel
type: docs
url: /sv/net/error-bar/
keywords:
- felstapel
- anpassat värde
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du lägger till och anpassar felstaplar i diagram med Aspose.Slides för .NET — optimera datavisualiseringar i PowerPoint-presentationer."
---
## **Översikt**

Den här artikeln förklarar hur du arbetar med felstaplar i presentationsdiagram med hjälp av Aspose.Slides. Den visar hur du lägger till felstaplar i en diagramserie, konfigurerar X‑ och Y‑felstaplarnas inställningar samt tillämpar olika värdetyper såsom fasta, procentuella och anpassade värden.

Den demonstrerar också hur du tilldelar anpassade felstaplervärden för individuella datapunkter i en serie genom att använda den motsvarande datapoängssamlingen. Dessutom innehåller artikeln korta anteckningar om hur felstaplar beter sig vid export, deras kompatibilitet med markörer och dataetiketter samt var du hittar de relaterade API‑referensklasserna och enumen.

## **Lägg till felstaplar**
Aspose.Slides for .NET tillhandahåller ett enkelt API för att hantera felstaplervärden. Exempelkoden gäller när du använder en anpassad värdetyp. För att ange ett värde, använd egenskapen **ErrorBarCustomValues** för en specifik datapunkt i **DataPoints**‑samlingen för serien:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
1. Lägg till ett bubbeldiagram på önskad bild.
1. Åtkom den första diagramserien och ställ in X‑formatet för felstaplar.
1. Åtkom den första diagramserien och ställ in Y‑formatet för felstaplar.
1. Ställ in staplarnas värden och format.
1. Skriv den modifierade presentationen till en PPTX‑fil.

```c#
    // Skapar tom presentation
    using (Presentation presentation = new Presentation())
    {
        // Skapar ett bubbeldiagram
        IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

        // Lägger till felstaplar och anger deras format
        IErrorBarsFormat errBarX = chart.ChartData.Series[0].ErrorBarsXFormat;
        IErrorBarsFormat errBarY = chart.ChartData.Series[0].ErrorBarsYFormat;
        errBarX.IsVisible = true;
        errBarY.IsVisible = true;
        errBarX.ValueType = ErrorBarValueType.Fixed;
        errBarX.Value = 0.1f;
        errBarY.ValueType = ErrorBarValueType.Percentage;
        errBarY.Value = 5;
        errBarX.Type = ErrorBarType.Plus;
        errBarY.Format.Line.Width = 2;
        errBarX.HasEndCap = true;

        // Sparar presentationen
        presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
    }
```

## **Lägg till anpassade felstaplervärden**
Aspose.Slides for .NET tillhandahåller ett enkelt API för att hantera anpassade felstaplervärden. Exempelkoden gäller när **IErrorBarsFormat.ValueType**‑egenskapen är lika med **Custom**. För att ange ett värde, använd egenskapen **ErrorBarCustomValues** för en specifik datapunkt i **DataPoints**‑samlingen för serien:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
1. Lägg till ett bubbeldiagram på önskad bild.
1. Åtkom den första diagramserien och ställ in X‑formatet för felstaplar.
1. Åtkom den första diagramserien och ställ in Y‑formatet för felstaplar.
1. Åtkom de enskilda datapoängerna i diagramserien och ange Error Bar values för varje datapunkt i serien.
1. Ställ in staplarnas värden och format.
1. Skriv den modifierade presentationen till en PPTX‑fil.

```c#
    // Skapar tom presentation
    using (Presentation presentation = new Presentation())
    {
        // Skapar ett bubbeldiagram
        IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

        // Lägger till anpassade felstaplar och anger deras format
        IChartSeries series = chart.ChartData.Series[0];
        IErrorBarsFormat errBarX = series.ErrorBarsXFormat;
        IErrorBarsFormat errBarY = series.ErrorBarsYFormat;
        errBarX.IsVisible = true;
        errBarY.IsVisible = true;
        errBarX.ValueType = ErrorBarValueType.Custom;
        errBarY.ValueType = ErrorBarValueType.Custom;

        // Åtkommer diagramseriens datapunkt och anger felstaplar för individuell punkt
        IChartDataPointCollection points = series.DataPoints;
        points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = DataSourceType.DoubleLiterals;
        points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = DataSourceType.DoubleLiterals;
        points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = DataSourceType.DoubleLiterals;
        points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = DataSourceType.DoubleLiterals;

        // Anger felstaplar för diagramseriens punkter
        for (int i = 0; i < points.Count; i++)
        {
            points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 1;
            points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 1;
            points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 1;
            points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 1;
        }

        // Sparar presentationen
        presentation.Save("ErrorBarsCustomValues_out.pptx", SaveFormat.Pptx);
    }
```

## **FAQ**

**Vad händer med felstaplar när en presentation exporteras till PDF eller bilder?**

De renderas som en del av diagrammet och bevaras vid konverteringen tillsammans med resten av diagramformatet, förutsatt att en kompatibel version eller renderare används.

**Kan felstaplar kombineras med markörer och dataetiketter?**

Ja. Felstaplar är ett separat element och är kompatibla med markörer och dataetiketter; om element överlappar kan du behöva justera formatet.

**Var kan jag hitta listan över egenskaper och enum för att arbeta med felstaplar i API:t?**

I API-referensen: klassen [ErrorBarsFormat](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/errorbarsformat/) och de relaterade enumen [ErrorBarType](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/errorbartype/) samt [ErrorBarValueType](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/errorbarvaluetype/).