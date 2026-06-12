---
title: Přizpůsobení chybových úseček v grafech prezentací pomocí Pythonu
linktitle: Chybová úsečka
type: docs
url: /cs/python-net/error-bar/
keywords:
- chybová úsečka
- vlastní hodnota
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Zjistěte, jak přidat a přizpůsobit chybové úsečky v grafech pomocí Aspose.Slides pro Python via .NET—optimalizujte vizualizaci dat v prezentacích PowerPoint a OpenDocument."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s chybovými úsečkami v grafických prezentacích pomocí Aspose.Slides. Ukazuje, jak přidat chybové úsečky k sérii grafu, nastavit nastavení chybových úseček X a Y a použít různé typy hodnot, jako jsou pevné, procentuální a vlastní hodnoty.

Také demonstruje, jak přiřadit vlastní hodnoty chybových úseček pro jednotlivé datové body v sérii pomocí odpovídající kolekce datových bodů. Navíc článek obsahuje stručné poznámky o tom, jak se chybové úsečky chovají během exportu, jejich kompatibilitu s značkami a popisky dat a kde najít související třídy a výčty v dokumentaci API.

## **Přidat chybovou úsečku**
Aspose.Slides for Python via .NET poskytuje jednoduché API pro správu hodnot chybových úseček. Ukázkový kód se používá při použití vlastního typu hodnoty. Pro určení hodnoty použijte vlastnost **ErrorBarCustomValues** konkrétního datového bodu v kolekci **DataPoints** série:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
1. Přidejte bublinový graf na požadovaný snímek.
1. Získejte první sérii grafu a nastavte formát chybové úsečky X.
1. Získejte první sérii grafu a nastavte formát chybové úsečky Y.
1. Nastavení hodnot úseček a formátu.
1. Uložte upravenou prezentaci do souboru PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Vytvoření prázdné prezentace
with slides.Presentation() as presentation:
    # Vytvoření bublinového grafu
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # Přidání chybových úseček a nastavení jejich formátu
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

    # Uložení prezentace
    presentation.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Přidat vlastní hodnotu chybové úsečky**
Aspose.Slides for Python via .NET poskytuje jednoduché API pro správu vlastních hodnot chybových úseček. Ukázkový kód se používá, když je vlastnost **IErrorBarsFormat.ValueType** nastavena na **Custom**. Pro určení hodnoty použijte vlastnost **ErrorBarCustomValues** konkrétního datového bodu v kolekci **DataPoints** série:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
1. Přidejte bublinový graf na požadovaný snímek.
1. Získejte první sérii grafu a nastavte formát chybové úsečky X.
1. Získejte první sérii grafu a nastavte formát chybové úsečky Y.
1. Získejte jednotlivé datové body série grafu a nastavte hodnoty chybových úseček pro jednotlivý datový bod.
1. Nastavení hodnot úseček a formátu.
1. Uložte upravenou prezentaci do souboru PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Vytvoření prázdné prezentace
with slides.Presentation() as presentation:
    # Vytvoření bublinového grafu
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # Přidání vlastních chybových úseček a nastavení jejich formátu
    series = chart.chart_data.series[0]
    errBarX = series.error_bars_x_format
    errBarY = series.error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.CUSTOM
    errBarY.value_type = charts.ErrorBarValueType.CUSTOM

    # Přístup k datovému bodu série grafu a nastavení hodnot chybových úseček pro jednotlivý bod
    points = series.data_points
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_minus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_minus_values = charts.DataSourceType.DOUBLE_LITERALS

    # Nastavení chybových úseček pro body série grafu
    for i in range(len(points)):
        points[i].error_bars_custom_values.x_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.x_plus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_plus.as_literal_double = i + 1

    # Uložení prezentace
    presentation.save("ErrorBarsCustomValues_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Často kladené dotazy**

**Co se stane s chybovými úsečkami při exportu prezentace do PDF nebo obrázků?**

Jsou vykresleny jako součást grafu a během konverze zachovány spolu se zbytkem formátování grafu, pokud je použita kompatibilní verze nebo vykreslovací nástroj.

**Lze chybové úsečky kombinovat se značkami a popisky dat?**

Ano. Chybové úsečky jsou samostatný prvek a jsou kompatibilní se značkami a popisky dat; pokud se prvky překrývají, může být nutné upravit formátování.

**Kde najdu seznam vlastností a výčtů pro práci s chybovými úsečkami v API?**

V referenci API: třídu [ErrorBarsFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/errorbarsformat/) a související výčty [ErrorBarType](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/errorbartype/) a [ErrorBarValueType](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/errorbarvaluetype/).