---
title: Přizpůsobení chybových pruhů v prezentačních grafech pomocí JavaScriptu
linktitle: Chybový pruh
type: docs
url: /cs/nodejs-java/error-bar/
keywords:
- chybový pruh
- vlastní hodnota
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Naučte se, jak přidat a přizpůsobit chybové pruhy v grafech pomocí JavaScriptu a Aspose.Slides pro Node.js via Java—optimalizujte vizualizaci dat v PowerPoint prezentacích."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s chybovými pruhy v prezentačních grafech pomocí Aspose.Slides. Ukazuje, jak přidat chybové pruhy do řady grafu, nakonfigurovat nastavení chybových pruhů pro osu X a Y a použít různé typy hodnot, jako jsou pevné, procentuální a vlastní hodnoty.

Také demonstruje, jak přiřadit vlastní hodnoty chybových pruhů pro jednotlivé datové body v řadě pomocí odpovídající kolekce datových bodů. Kromě toho článek obsahuje stručné poznámky o tom, jak se chybové pruhy chovají při exportu, jejich kompatibilitě se značkami a popisky dat a kde najít související třídy a výčty v referenční dokumentaci API.

## **Přidat chybový pruh**

Aspose.Slides for Node.js via Java poskytuje jednoduché rozhraní API pro správu hodnot chybových pruhů. Vzorek kódu platí při použití vlastního typu hodnoty. Pro zadání hodnoty použijte vlastnost **ErrorBarCustomValues** konkrétního datového bodu v kolekci [**DataPoints**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartSeriesCollection) řady:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
1. Přidejte bublinový graf na požadovaný snímek.
1. Získejte první řadu grafu a nastavte formát chybového pruhu X.
1. Získejte první řadu grafu a nastavte formát chybového pruhu Y.
1. Nastavte hodnoty a formát pruhů.
1. Zapište upravenou prezentaci do souboru PPTX.

```javascript
// Vytvořte instanci třídy Presentation
var pres = new aspose.slides.Presentation();
try {
    // Vytvoření bublinového grafu
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    // Přidání chybových pruhů a nastavení jejich formátu
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
    // Uložení prezentace
    pres.save("ErrorBars.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Přidat vlastní hodnotu chybového pruhu**

Aspose.Slides for Node.js via Java poskytuje jednoduché rozhraní API pro správu vlastních hodnot chybových pruhů. Vzorek kódu platí, když je vlastnost [**ErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ErrorBarsFormat#getValue--) rovna **Custom**. Pro zadání hodnoty použijte vlastnost **ErrorBarCustomValues** konkrétního datového bodu v kolekci [**DataPoints**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartSeriesCollection) řady:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
1. Přidejte bublinový graf na požadovaný snímek.
1. Získejte první řadu grafu a nastavte formát chybového pruhu X.
1. Získejte první řadu grafu a nastavte formát chybového pruhu Y.
1. Přistupte k jednotlivým datovým bodům řady a nastavte hodnoty chybového pruhu pro jednotlivý datový bod řady.
1. Nastavte hodnoty a formát pruhů.
1. Zapište upravenou prezentaci do souboru PPTX.

```javascript
// Vytvořte instanci třídy Presentation
var pres = new aspose.slides.Presentation();
try {
    // Vytvoření bublinového grafu
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    // Přidání vlastních chybových pruhů a nastavení jejich formátu
    var series = chart.getChartData().getSeries().get_Item(0);
    var errBarX = series.getErrorBarsXFormat();
    var errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType(aspose.slides.ErrorBarValueType.Custom);
    errBarY.setValueType(aspose.slides.ErrorBarValueType.Custom);
    // Přístup k datovému bodu řady grafu a nastavení hodnot chybových pruhů pro
    // jednotlivý bod
    var points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
    // Nastavení chybových pruhů pro body řady grafu
    for (var i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }
    // Uložení prezentace
    pres.save("ErrorBarsCustomValues.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Často kladené otázky**

**Co se stane s chybovými pruhy při exportu prezentace do PDF nebo obrázků?**

Vykreslí se jako součást grafu a během konverze se zachovají spolu se zbytkem formátování grafu, za předpokladu kompatibilní verze nebo vykreslovače.

**Lze chybové pruhy kombinovat se značkami a popisky dat?**

Ano. Chybové pruhy jsou samostatným prvkem a jsou kompatibilní se značkami a popisky dat; pokud se prvky překrývají, může být nutné upravit formátování.

**Kde najdu seznam vlastností a výčtů pro práci s chybovými pruhy v API?**

V referenci API: třídu [ErrorBarsFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/errorbarsformat/) a související výčty [ErrorBarType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/errorbartype/) a [ErrorBarValueType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/errorbarvaluetype/).