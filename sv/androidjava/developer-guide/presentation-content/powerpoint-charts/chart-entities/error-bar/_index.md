---
title: Anpassa felstaplar i presentationsdiagram på Android
linktitle: Felstapel
type: docs
url: /sv/androidjava/error-bar/
keywords:
- felstapel
- anpassat värde
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Lär dig hur du lägger till och anpassar felstaplar i diagram med Aspose.Slides för Android via Java – optimera datavisualisering i PowerPoint-presentationer."
---
## **Översikt**

Denna artikel förklarar hur du arbetar med felstaplar i presentationsdiagram med Aspose.Slides. Den visar hur du lägger till felstaplar i en diagramserie, konfigurerar X‑ och Y‑felstaplar, och använder olika värdetyper som fast, procentuell och anpassade värden.

Den visar också hur du tilldelar anpassade felstaplar för enskilda datapunkter i en serie genom att använda motsvarande datapunktssamling. Dessutom innehåller artikeln korta noteringar om hur felstaplar beter sig vid export, deras kompatibilitet med markörer och datamärkningar samt var du hittar de relaterade API‑referensklasserna och uppräkningsvärdena.

## **Lägg till felstaplar**
Aspose.Slides för Android via Java tillhandahåller ett enkelt API för att hantera felstaplar. Exempelkoden gäller när en anpassad värdetyp används. För att ange ett värde, använd egenskapen **ErrorBarCustomValues** för en specifik datapunkt i [**DataPoints**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IChartSeriesCollection)-samlingen för en serie:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation).
1. Lägg till ett bubbeldiagram på önskad bild.
1. Öppna den första diagramserien och ange X‑formatet för felstapeln.
1. Öppna den första diagramserien och ange Y‑formatet för felstapeln.
1. Ställ in staplarnas värden och format.
1. Skriv den modifierade presentationen till en PPTX‑fil.

```java
// Skapa en instans av Presentation-klassen
Presentation pres = new Presentation();
try {
    // Skapar ett bubbeldiagram
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Lägger till felstaplar och anger deras format
    IErrorBarsFormat errBarX = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat();
    IErrorBarsFormat errBarY = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat();

    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Fixed);
    errBarX.setValue(0.1f);
    errBarY.setValueType((byte) ErrorBarValueType.Percentage);
    errBarY.setValue(5);
    errBarX.setType((byte) ErrorBarType.Plus);
    errBarY.getFormat().getLine().setWidth(2.0f);
    errBarX.hasEndCap();

    // Sparar presentation
    pres.save("ErrorBars.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Lägg till anpassade felstaplarvärden**
Aspose.Slides för Android via Java tillhandahåller ett enkelt API för att hantera anpassade felstaplar. Exempelkoden gäller när egenskapen [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IErrorBarsFormat#getValue--) är lika med **Custom**. För att ange ett värde, använd egenskapen **ErrorBarCustomValues** för en specifik datapunkt i [**DataPoints**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IChartSeriesCollection)-samlingen för en serie:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation).
1. Lägg till ett bubbeldiagram på önskad bild.
1. Öppna den första diagramserien och ange X‑formatet för felstapeln.
1. Öppna den första diagramserien och ange Y‑formatet för felstapeln.
1. Öppna individuella datapunkter i diagramserien och ange felstapelsvärden för varje datapunkt i serien.
1. Ställ in staplarnas värden och format.
1. Skriv den modifierade presentationen till en PPTX‑fil.

```java
// Skapa en instans av Presentation-klassen
Presentation pres = new Presentation();
try {
    // Skapar ett bubbeldiagram
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Lägger till anpassade felstaplar och anger deras format
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IErrorBarsFormat errBarX = series.getErrorBarsXFormat();
    IErrorBarsFormat errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Custom);
    errBarY.setValueType((byte) ErrorBarValueType.Custom);

    // Kommer åt diagramseriens datapunkt och anger felstaplarvärden för
    // enskild punkt
    IChartDataPointCollection points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues((byte) DataSourceType.DoubleLiterals);

    // Anger felstaplar för diagramseriens punkter
    for (int i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }

    // Sparar presentation
    pres.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Vanliga frågor**

**Vad händer med felstaplar när en presentation exporteras till PDF eller bilder?**

De renderas som en del av diagrammet och bevaras vid konvertering tillsammans med resten av diagrammets formatering, förutsatt att en kompatibel version eller renderare används.

**Kan felstaplar kombineras med markörer och datamärkningar?**

Ja. Felstaplar är ett separat element och är kompatibla med markörer och datamärkningar; om elementen överlappar kan du behöva justera formateringen.

**Var kan jag hitta listan över egenskaper och klasser för att arbeta med felstaplar i API:t?**

I API‑referensen: klassen [ErrorBarsFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/errorbarsformat/) och de relaterade klasserna [ErrorBarType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/errorbartype/) och [ErrorBarValueType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/errorbarvaluetype/).