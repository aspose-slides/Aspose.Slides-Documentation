---
title: Foutenbalken aanpassen in presentatiegrafieken met JavaScript
linktitle: Foutenbalk
type: docs
url: /nl/nodejs-java/error-bar/
keywords:
- foutenbalk
- aangepaste waarde
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe u foutenbalken kunt toevoegen en aanpassen in grafieken met JavaScript en Aspose.Slides voor Node.js via Java - optimaliseer datavisualisaties in PowerPoint-presentaties."
---
## **Overzicht**

Dit artikel legt uit hoe je foutenbalken in presentatiegrafieken kunt gebruiken met Aspose.Slides. Het toont hoe je foutenbalken toevoegt aan een grafiekserie, de X‑ en Y‑foutenbalkinstellingen configureert en verschillende waardetypen toepast, zoals vaste, percentage‑ en aangepaste waarden.

Het laat ook zien hoe je aangepaste foutenbalkwaarden toewijst aan individuele datapunten in een serie via de bijbehorende datapunten‑verzameling. Bovendien bevat het artikel korte notities over hoe foutenbalken zich gedragen tijdens export, hun compatibiliteit met markers en datalabels, en waar je de gerelateerde API‑referentieklassen en enums kunt vinden.

## **Foutenbalk toevoegen**

Aspose.Slides for Node.js via Java biedt een eenvoudige API voor het beheren van foutenbalkwaarden. De voorbeeldcode is van toepassing bij gebruik van een aangepast waardetype. Om een waarde op te geven, gebruik je de **ErrorBarCustomValues**‑eigenschap van een specifiek datapunt in de [**DataPoints**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartSeriesCollection)‑verzameling van een serie:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasse.
1. Voeg een bubbelgrafiek toe op de gewenste dia.
1. Toegang tot de eerste grafiekserie en stel het X‑formaat van de foutenbalk in.
1. Toegang tot de eerste grafiekserie en stel het Y‑formaat van de foutenbalk in.
1. Bepaal de waarden en het format van de balken.
1. Schrijf de gewijzigde presentatie naar een PPTX‑bestand.

```javascript
// Maak een instantie van de Presentation-klasse
var pres = new aspose.slides.Presentation();
try {
    // Een bubbelgrafiek maken
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    // Foutenbalken toevoegen en het formaat instellen
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
    // Presentatie opslaan
    pres.save("ErrorBars.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Aangepaste foutenbalkwaarde toevoegen**

Aspose.Slides for Node.js via Java biedt een eenvoudige API voor het beheren van aangepaste foutenbalkwaarden. De voorbeeldcode is van toepassing wanneer de eigenschap [**ErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ErrorBarsFormat#getValue--) gelijk is aan **Custom**. Om een waarde op te geven, gebruik je de **ErrorBarCustomValues**‑eigenschap van een specifiek datapunt in de [**DataPoints**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ChartSeriesCollection)‑verzameling van een serie:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasse.
1. Voeg een bubbelgrafiek toe op de gewenste dia.
1. Toegang tot de eerste grafiekserie en stel het X‑formaat van de foutenbalk in.
1. Toegang tot de eerste grafiekserie en stel het Y‑formaat van de foutenbalk in.
1. Toegang tot de individuele datapunten van de grafiekserie en stel de foutenbalkwaarden in voor elk datapunt.
1. Bepaal de waarden en het format van de balken.
1. Schrijf de gewijzigde presentatie naar een PPTX‑bestand.

```javascript
// Maak een instantie van de Presentation-klasse
var pres = new aspose.slides.Presentation();
try {
    // Een bubbelgrafiek maken
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    // Aangepaste foutenbalken toevoegen en het formaat instellen
    var series = chart.getChartData().getSeries().get_Item(0);
    var errBarX = series.getErrorBarsXFormat();
    var errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType(aspose.slides.ErrorBarValueType.Custom);
    errBarY.setValueType(aspose.slides.ErrorBarValueType.Custom);
    // Toegang tot het datapunten van de grafiekserie en foutenbalkwaarden instellen voor
    // elk afzonderlijk punt
    var points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
    // Foutenbalken instellen voor datapunten van de grafiekserie
    for (var i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }
    // Presentatie opslaan
    pres.save("ErrorBarsCustomValues.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Wat gebeurt er met foutenbalken bij het exporteren van een presentatie naar PDF of afbeeldingen?**

Ze worden gerenderd als onderdeel van de grafiek en blijven behouden tijdens de conversie, samen met de rest van de grafiekopmaak, mits er een compatibele versie of renderer wordt gebruikt.

**Kunnen foutenbalken worden gecombineerd met markers en datalabels?**

Ja. Foutenbalken zijn een afzonderlijk element en zijn compatibel met markers en datalabels; overlappen de elementen, dan moet je mogelijk de opmaak aanpassen.

**Waar kan ik de lijst met eigenschappen en enums voor het werken met foutenbalken in de API vinden?**

In de API‑referentie: de [ErrorBarsFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/errorbarsformat/)‑klasse en de gerelateerde enums [ErrorBarType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/errorbartype/) en [ErrorBarValueType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/errorbarvaluetype/).