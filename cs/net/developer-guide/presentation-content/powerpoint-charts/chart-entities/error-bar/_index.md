---
title: Přizpůsobení chybových pruhů v prezentačních grafech v .NET
linktitle: Chybový pruh
type: docs
url: /cs/net/error-bar/
keywords:
- chybový pruh
- vlastní hodnota
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se, jak přidat a přizpůsobit chybové pruhy v grafech pomocí Aspose.Slides pro .NET—optimalizujte vizualizaci dat v prezentacích PowerPoint."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s chybovými pruhy v prezentačních grafech pomocí Aspose.Slides. Ukazuje, jak přidat chybové pruhy do série grafu, nastavit nastavení chybových pruhů X a Y a použít různé typy hodnot, jako jsou pevné, procentuální a vlastní hodnoty.

Také demonstruje, jak přiřadit vlastní hodnoty chybových pruhů pro jednotlivé datové body v sérii pomocí odpovídající kolekce datových bodů. Navíc článek obsahuje stručné poznámky o tom, jak se chybové pruhy chovají během exportu, jejich kompatibilitu se značkami a popisky dat a kde najít související třídy a výčtové typy v referenci API.

## **Přidat chybové pruhy**
Aspose.Slides pro .NET poskytuje jednoduché API pro správu hodnot chybových pruhů. Vzorový kód se používá při použití typu vlastní hodnoty. Pro zadání hodnoty použijte vlastnost **ErrorBarCustomValues** konkrétního datového bodu v kolekci **DataPoints** série:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
1. Přidejte bublinový graf na požadovaný snímek.
1. Získejte první sérii grafu a nastavte formát chybového pruhu X.
1. Získejte první sérii grafu a nastavte formát chybového pruhu Y.
1. Nastavení hodnot a formátu pruhů.
1. Uložte upravenou prezentaci do souboru PPTX.

```c#
// Vytvoření prázdné prezentace
using (Presentation presentation = new Presentation())
{
    // Vytvoření bublinového grafu
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Přidání chybových pruhů a nastavení jejich formátu
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

    // Uložení prezentace
    presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```



## **Přidat vlastní hodnoty chybových pruhů**
Aspose.Slides pro .NET poskytuje jednoduché API pro správu vlastních hodnot chybových pruhů. Vzorový kód se používá, když je vlastnost **IErrorBarsFormat.ValueType** rovna **Custom**. Pro zadání hodnoty použijte vlastnost **ErrorBarCustomValues** konkrétního datového bodu v kolekci **DataPoints** série:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
1. Přidejte bublinový graf na požadovaný snímek.
1. Získejte první sérii grafu a nastavte formát chybového pruhu X.
1. Získejte první sérii grafu a nastavte formát chybového pruhu Y.
1. Přistupte k jednotlivým datovým bodům série a nastavte hodnoty chybového pruhu pro jednotlivý datový bod série.
1. Nastavení hodnot a formátu pruhů.
1. Uložte upravenou prezentaci do souboru PPTX.

```c#
// Vytvoření prázdné prezentace
using (Presentation presentation = new Presentation())
{
    // Vytvoření bublinového grafu
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Přidání vlastních chybových pruhů a nastavení jejich formátu
    IChartSeries series = chart.ChartData.Series[0];
    IErrorBarsFormat errBarX = series.ErrorBarsXFormat;
    IErrorBarsFormat errBarY = series.ErrorBarsYFormat;
    errBarX.IsVisible = true;
    errBarY.IsVisible = true;
    errBarX.ValueType = ErrorBarValueType.Custom;
    errBarY.ValueType = ErrorBarValueType.Custom;

    // Přístup k datovému bodu série grafu a nastavení hodnot chybových pruhů pro jednotlivý bod
    IChartDataPointCollection points = series.DataPoints;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = DataSourceType.DoubleLiterals;

    // Nastavení chybových pruhů pro body série grafu
    for (int i = 0; i < points.Count; i++)
    {
        points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 1;
    }

    // Uložení prezentace
    presentation.Save("ErrorBarsCustomValues_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Co se stane s chybovými pruhy při exportu prezentace do PDF nebo obrázků?**

Jsou vykresleny jako součást grafu a během konverze zachovány spolu se zbytkem formátování grafu, za předpokladu kompatibilní verze nebo rendereru.

**Lze chybové pruhy kombinovat s značkami a popisky dat?**

Ano. Chybové pruhy jsou samostatným prvkem a jsou kompatibilní se značkami a popisky dat; pokud se prvky překrývají, může být nutné upravit formátování.

**Kde mohu najít seznam vlastností a výčtových typů pro práci s chybovými pruhy v API?**

V referenci API: třída [ErrorBarsFormat](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/errorbarsformat/) a související výčtové typy [ErrorBarType](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/errorbartype/) a [ErrorBarValueType](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/errorbarvaluetype/).