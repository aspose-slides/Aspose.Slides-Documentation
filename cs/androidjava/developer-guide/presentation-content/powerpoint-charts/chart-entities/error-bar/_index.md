---
title: Přizpůsobení chybových úseček v grafických prezentacích na Androidu
linktitle: Chybová úsečka
type: docs
url: /cs/androidjava/error-bar/
keywords:
- chybová úsečka
- vlastní hodnota
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Naučte se, jak přidávat a přizpůsobovat chybové úsečky v grafech pomocí Aspose.Slides pro Android prostřednictvím Javy—optimalizujte vizualizaci dat v prezentacích PowerPoint."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s chybovými úsečkami v grafických prezentacích pomocí Aspose.Slides. Ukazuje, jak přidat chybové úsečky do řady grafu, nakonfigurovat nastavení chybových úseček X a Y a použít různé typy hodnot, jako jsou pevné, procentuální a vlastní hodnoty.

Také ukazuje, jak přiřadit vlastní hodnoty chybových úseček pro jednotlivé datové body v řadě pomocí odpovídající kolekce datových bodů. Navíc článek obsahuje stručné poznámky o tom, jak se chybové úsečky chovají během exportu, jejich kompatibilitě s značkami a popisky dat a kde najít související třídy a výčty v referenční API.

## **Přidání chybových úseček**
Aspose.Slides pro Android prostřednictvím Java poskytuje jednoduché API pro správu hodnot chybových úseček. Ukázkový kód se použije při používání vlastního typu hodnoty. Pro určení hodnoty použijte vlastnost **ErrorBarCustomValues** konkrétního datového bodu v kolekci [**DataPoints**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartSeriesCollection) řady:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
1. Přidejte bublinový graf na požadovaný snímek.
1. Získejte první řadu grafu a nastavte formát chybové úsečky X.
1. Získejte první řadu grafu a nastavte formát chybové úsečky Y.
1. Nastavení hodnot úseček a formátu.
1. Zapište upravenou prezentaci do souboru PPTX.

```java
// Vytvořte instanci třídy Presentation
Presentation pres = new Presentation();
try {
    // Vytvoření bublinového grafu
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Přidání chybových úseček a nastavení jejich formátu
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

    // Ukládání prezentace
    pres.save("ErrorBars.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Přidání vlastních hodnot chybových úseček**
Aspose.Slides pro Android prostřednictvím Java poskytuje jednoduché API pro správu vlastních hodnot chybových úseček. Ukázkový kód se použije, když je vlastnost [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IErrorBarsFormat#getValue--) rovna **Custom**. Pro určení hodnoty použijte vlastnost **ErrorBarCustomValues** konkrétního datového bodu v kolekci [**DataPoints**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartSeriesCollection) řady:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
1. Přidejte bublinový graf na požadovaný snímek.
1. Získejte první řadu grafu a nastavte formát chybové úsečky X.
1. Získejte první řadu grafu a nastavte formát chybové úsečky Y.
1. Získejte jednotlivé datové body řady grafu a nastavte hodnoty chybové úsečky pro jednotlivý datový bod řady.
1. Nastavení hodnot úseček a formátu.
1. Zapište upravenou prezentaci do souboru PPTX.

```java
// Vytvořte instanci třídy Presentation
Presentation pres = new Presentation();
try {
    // Vytvoření bublinového grafu
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Přidání vlastních chybových úseček a nastavení jejich formátu
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IErrorBarsFormat errBarX = series.getErrorBarsXFormat();
    IErrorBarsFormat errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Custom);
    errBarY.setValueType((byte) ErrorBarValueType.Custom);

    // Přístup k datovému bodu řady grafu a nastavení hodnot chybových úseček pro
    // jednotlivý bod
    IChartDataPointCollection points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues((byte) DataSourceType.DoubleLiterals);

    // Nastavení chybových úseček pro body řady grafu
    for (int i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }

    // Ukládání prezentace
    pres.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Často kladené otázky**

**Co se stane s chybovými úsečkami při exportu prezentace do PDF nebo obrázků?**

Jsou vykresleny jako součást grafu a během konverze zachovány spolu se zbytkem formátování grafu, za předpokladu kompatibilní verze nebo renderu.

**Mohou být chybové úsečky kombinovány se značkami a popisky dat?**

Ano. Chybové úsečky jsou samostatný prvek a jsou kompatibilní se značkami a popisky dat; pokud se prvky překrývají, může být nutné upravit formátování.

**Kde najdu seznam vlastností a tříd pro práci s chybovými úsečkami v API?**

V referenční dokumentaci API: třída [ErrorBarsFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/errorbarsformat/) a související třídy [ErrorBarType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/errorbartype/) a [ErrorBarValueType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/errorbarvaluetype/).