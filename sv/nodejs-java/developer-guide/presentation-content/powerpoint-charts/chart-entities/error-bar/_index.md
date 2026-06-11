---
title: Anpassa felstaplar i presentationsdiagram med JavaScript
linktitle: Felstapel
type: docs
url: /sv/nodejs-java/error-bar/
keywords:
- felstapel
- anpassat värde
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Lär dig hur du lägger till och anpassar felstaplar i diagram med JavaScript och Aspose.Slides för Node.js via Java—optimera datapresentationer i PowerPoint-presentationer."
---
## **Översikt**

Den här artikeln förklarar hur man arbetar med felstaplar i presentationsdiagram med hjälp av Aspose.Slides. Den visar hur man lägger till felstaplar i en diagramserie, konfigurerar X‑ och Y‑felstaplar och använder olika värdetyper såsom fasta, procentuella och anpassade värden.

Den demonstrerar också hur man tilldelar anpassade felstaplar för enskilda datapunkter i en serie genom att använda den motsvarande datapunktssamlingen. Dessutom innehåller artikeln korta noteringar om hur felstaplar beter sig vid export, deras kompatibilitet med markörer och datalabels samt var man hittar de relaterade API‑referensklasserna och uppräkningsvärdena.

## **Lägg till felstapel**

Aspose.Slides for Node.js via Java tillhandahåller ett enkelt API för att hantera felstaplar. Exempelkoden gäller när du använder en anpassad värdetyp. För att ange ett värde, använd **ErrorBarCustomValues**‑egenskapen för en specifik datapunkt i [**DataPoints**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartSeriesCollection)‑samlingen av serier:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
1. Lägg till ett bubbeldiagram på önskad bild.
1. Hämta den första diagramserien och ställ in felstapelformat för X.
1. Hämta den första diagramserien och ställ in felstapelformat för Y.
1. Ställ in staplarnas värden och format.
1. Skriv den modifierade presentationen till en PPTX‑fil.

```javascript
// Skapa en instans av Presentation-klassen
var pres = new aspose.slides.Presentation();
try {
    // Skapa ett bubbeldiagram
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    // Lägger till felstaplar och ställer in formatet
    var errBarX = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat();
    var errBarY = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType(aspose.slides.ErrorBarValueType.Fixed);
    errBarX.setValue(0.1);
    errBarY.setValueType(aspose.slides.ErrorBarValueType.Percentage);
    errBarY.setValue(5);
    errBarX.setType(aspose.slides.ErrorBarType.Plus);
    errBarY.getFormat().getLine().setWidth(2.0);
    errBarX.hasEndCap();
    // Sparar presentationen
    pres.save("ErrorBars.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Lägg till anpassat felstapelförvärde**

Aspose.Slides for Node.js via Java tillhandahåller ett enkelt API för att hantera anpassade felstaplar. Exempelkoden gäller när egenskapen [**ErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ErrorBarsFormat#getValue--) är lika med **Custom**. För att ange ett värde, använd **ErrorBarCustomValues**‑egenskapen för en specifik datapunkt i [**DataPoints**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartSeriesCollection)‑samlingen av serier:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
1. Lägg till ett bubbeldiagram på önskad bild.
1. Hämta den första diagramserien och ställ in felstapelformat för X.
1. Hämta den första diagramserien och ställ in felstapelformat för Y.
1. Hämta diagramseriens enskilda datapunkter och ställ in felstaplarna för varje datapunkt i serien.
1. Ställ in staplarnas värden och format.
1. Skriv den modifierade presentationen till en PPTX‑fil.

```javascript
// Skapa en instans av Presentation-klassen
var pres = new aspose.slides.Presentation();
try {
    // Skapa ett bubbeldiagram
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    // Lägger till anpassade felstaplar och ställer in dess format
    var series = chart.getChartData().getSeries().get_Item(0);
    var errBarX = series.getErrorBarsXFormat();
    var errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType(aspose.slides.ErrorBarValueType.Custom);
    errBarY.setValueType(aspose.slides.ErrorBarValueType.Custom);
    // Åtkomst till diagramseriens datapunkt och ställer in felstaplarvärden för
    // individuell punkt
    var points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
    // Ställer in felstaplar för diagramseriens punkter
    for (var i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }
    // Sparar presentationen
    pres.save("ErrorBarsCustomValues.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Vad händer med felstaplar när en presentation exporteras till PDF eller bilder?**

De renderas som en del av diagrammet och bevaras vid konverteringen tillsammans med resten av diagramformatet, förutsatt att en kompatibel version eller renderare används.

**Kan felstaplar kombineras med markörer och datalabels?**

Ja. Felstaplar är ett separat element och är kompatibla med markörer och datalabels; om elementen överlappar kan du behöva justera formateringen.

**Var kan jag hitta listan över egenskaper och uppräkningsvärden för att arbeta med felstaplar i API:et?**

I API‑referensen: klassen [ErrorBarsFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/errorbarsformat/) och de relaterade uppräkningsvärdena [ErrorBarType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/errorbartype/) och [ErrorBarValueType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/errorbarvaluetype/).