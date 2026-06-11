---
title: Anpassa felstaplar i presentationsdiagram med Java
linktitle: Felstapel
type: docs
url: /sv/java/error-bar/
keywords:
- felstapel
- anpassat värde
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Lär dig hur du lägger till och anpassar felstaplar i diagram med Aspose.Slides för Java—optimera datavisualiseringar i PowerPoint-presentationer."
---
## **Översikt**

Den här artikeln förklarar hur du arbetar med felstaplar i presentationsdiagram med Aspose.Slides. Den visar hur du lägger till felstaplar i en diagramserie, konfigurerar X‑ och Y‑inställningar för felstaplar samt använder olika värdetyper såsom fast, procentuell och anpassade värden.

Den visar också hur du tilldelar anpassade felstaplarvärden för enskilda datapunkter i en serie genom att använda motsvarande datapunktssamling. Dessutom innehåller artikeln korta noteringar om hur felstaplar beter sig vid export, deras kompatibilitet med markörer och datapetiketter, samt var du hittar de relaterade API‑referensklasserna och enum‑typerna.

## **Lägg till felstaplar**
Aspose.Slides for Java tillhandahåller ett enkelt API för att hantera felstaplarvärden. Exempelkoden gäller när du använder en anpassad värdetyp. För att ange ett värde, använd egenskapen **ErrorBarCustomValues** för en specifik datapunkt i samlingen [**DataPoints**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IChartSeriesCollection) för serien:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
1. Lägg till ett bubbeldiagram på önskad bild.
1. Åtkomst till den första diagramserien och ange felstaplar X‑format.
1. Åtkomst till den första diagramserien och ange felstaplar Y‑format.
1. Ställ in staplarnas värden och format.
1. Skriv den ändrade presentationen till en PPTX‑fil.

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

    // Sparar presentationen
    pres.save("ErrorBars.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Lägg till anpassade felstaplarvärden**
Aspose.Slides for Java tillhandahåller ett enkelt API för att hantera anpassade felstaplarvärden. Exempelkoden gäller när egenskapen [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IErrorBarsFormat#getValue--) är lika med **Custom**. För att ange ett värde, använd egenskapen **ErrorBarCustomValues** för en specifik datapunkt i samlingen [**DataPoints**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IChartSeriesCollection) för serien:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
1. Lägg till ett bubbeldiagram på önskad bild.
1. Åtkomst till den första diagramserien och ange felstaplar X‑format.
1. Åtkomst till den första diagramserien och ange felstaplar Y‑format.
1. Åtkomst till de enskilda datapunkterna i diagramserien och ange felstaplarvärden för varje datapunkt i serien.
1. Ställ in staplarnas värden och format.
1. Skriv den ändrade presentationen till en PPTX‑fil.

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

    // Åtkomst till diagramseriens datapunkt och anger felstaplarvärden för
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

    // Sparar presentationen
    pres.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Vanliga frågor**

**Vad händer med felstaplarna när en presentation exporteras till PDF eller bilder?**

De renderas som en del av diagrammet och bevaras vid konvertering tillsammans med resten av diagrammets formatering, förutsatt att en kompatibel version eller renderare används.

**Kan felstaplar kombineras med markörer och datapetiketter?**

Ja. Felstaplar är ett separat element och är kompatibla med markörer och datapetiketter; om element överlappar kan du behöva justera formateringen.

**Var kan jag hitta listan över egenskaper och klasser för att arbeta med felstaplar i API:et?**

I API‑referensen: klassen [ErrorBarsFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/errorbarsformat/) samt de relaterade klasserna [ErrorBarType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/errorbartype/) och [ErrorBarValueType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/errorbarvaluetype/).