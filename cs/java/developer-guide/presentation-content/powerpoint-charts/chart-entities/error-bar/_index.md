---
title: Přizpůsobení chybových pruhů v grafech prezentací pomocí Javy
linktitle: Chybový pruh
type: docs
url: /cs/java/error-bar/
keywords:
- chybový pruh
- vlastní hodnota
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Naučte se, jak přidávat a přizpůsobovat chybové pruhy v grafech pomocí Aspose.Slides pro Javu—optimalizujte vizuály dat v prezentacích PowerPoint."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s chybovými pruhy v grafické prezentaci pomocí Aspose.Slides. Ukazuje, jak přidat chybové pruhy do řady grafu, nakonfigurovat nastavení chybových pruhů na osách X a Y a použít různé typy hodnot, jako jsou pevné, procentuální a vlastní hodnoty.

Také ukazuje, jak přiřadit vlastní hodnoty chybových pruhů k jednotlivým datovým bodům v řadě pomocí odpovídající kolekce datových bodů. Kromě toho článek obsahuje stručné poznámky o tom, jak se chybové pruhy chovají při exportu, jejich kompatibilitě s značkami a popisky dat a kde najdete související třídy a výčty v referenci API.

## **Přidat chybové pruhy**
Aspose.Slides pro Java poskytuje jednoduché rozhraní API pro správu hodnot chybových pruhů. Vzorový kód se použije při použití vlastního typu hodnoty. Pro určení hodnoty použijte vlastnost **ErrorBarCustomValues** konkrétního datového bodu ve sbírce [**DataPoints**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IChartSeriesCollection) řady:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
1. Přidejte bublinový graf na požadovaném snímku.
1. Získejte první řadu grafu a nastavte formát chybového pruhu pro osu X.
1. Získejte první řadu grafu a nastavte formát chybového pruhu pro osu Y.
1. Nastavte hodnoty pruhů a formát.
1. Uložte upravenou prezentaci do souboru PPTX.

```java
// Vytvořte instanci třídy Presentation
Presentation pres = new Presentation();
try {
    // Vytvoření bublinového grafu
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Přidání chybových pruhů a nastavení jejich formátu
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

    // Uložení prezentace
    pres.save("ErrorBars.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Přidat vlastní hodnoty chybových pruhů**
Aspose.Slides pro Java poskytuje jednoduché rozhraní API pro správu vlastních hodnot chybových pruhů. Vzorový kód se použije, když je vlastnost [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IErrorBarsFormat#getValue--) rovna **Custom**. Pro určení hodnoty použijte vlastnost **ErrorBarCustomValues** konkrétního datového bodu ve sbírce [**DataPoints**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IChartSeriesCollection) řady:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
1. Přidejte bublinový graf na požadovaném snímku.
1. Získejte první řadu grafu a nastavte formát chybového pruhu pro osu X.
1. Získejte první řadu grafu a nastavte formát chybového pruhu pro osu Y.
1. Získejte jednotlivé datové body řady grafu a nastavte hodnoty chybových pruhů pro jednotlivé datové body řady.
1. Nastavte hodnoty pruhů a formát.
1. Uložte upravenou prezentaci do souboru PPTX.

```java
// Vytvořte instanci třídy Presentation
Presentation pres = new Presentation();
try {
    // Vytvoření bublinového grafu
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Přidání vlastních chybových pruhů a nastavení jejich formátu
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IErrorBarsFormat errBarX = series.getErrorBarsXFormat();
    IErrorBarsFormat errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Custom);
    errBarY.setValueType((byte) ErrorBarValueType.Custom);

    // Přístup k datovému bodu řady grafu a nastavení hodnot chybových pruhů pro
    // jednotlivý bod
    IChartDataPointCollection points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues((byte) DataSourceType.DoubleLiterals);

    // Nastavení chybových pruhů pro body řady grafu
    for (int i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }

    // Uložení prezentace
    pres.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Často kladené otázky**

**Co se stane s chybovými pruhy při exportu prezentace do PDF nebo obrázků?**

Jsou vykresleny jako součást grafu a při konverzi zachovány spolu se zbytkem formátování grafu, pokud je použita kompatibilní verze nebo renderér.

**Lze chybové pruhy kombinovat se značkami a popisky dat?**

Ano. Chybové pruhy jsou samostatný prvek a jsou kompatibilní se značkami a popisky dat; pokud se prvky překrývají, může být nutné upravit formátování.

**Kde mohu najít seznam vlastností a tříd pro práci s chybovými pruhy v API?**

V referenci API: třída [ErrorBarsFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/errorbarsformat/) a související třídy [ErrorBarType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/errorbartype/) a [ErrorBarValueType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/errorbarvaluetype/).