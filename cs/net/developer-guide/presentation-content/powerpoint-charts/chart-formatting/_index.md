---
title: Formátování grafů v prezentacích v .NET
linktitle: Formátování grafu
type: docs
weight: 60
url: /cs/net/chart-formatting/
keywords:
- formát grafu
- formátování grafu
- entita grafu
- vlastnosti grafu
- nastavení grafu
- volby grafu
- vlastnosti písma
- zaoblený okraj
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se formátování grafů v Aspose.Slides pro .NET a vylepšete svou PowerPoint prezentaci profesionálním a poutavým stylem."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Aspose.Slides formátovat grafy v prezentacích PowerPoint. Ukazuje, jak přizpůsobit klíčové prvky grafu, jako jsou osy, mřížkové čáry, názvy, legendy, oblast vykreslení a výplně stěn, aby se zlepšil vzhled a čitelnost dat v grafu.

Také ukazuje, jak nastavit vlastnosti písma pro text v grafu, použít předdefinované a vlastní číselné formáty na data grafu a povolit zaoblené rohy pro oblast grafu. Společně tyto příklady ukazují, jak ovládat jak vizuální styl, tak prezentaci dat v grafech v prezentaci.

## **Formátování entit grafu**
Aspose.Slides pro .NET umožňuje vývojářům přidávat vlastní grafy do snímků od nuly. Tento článek vysvětluje, jak formátovat různé entity grafu, včetně kategoriové a hodnotové osy grafu.

Aspose.Slides pro .NET poskytuje jednoduché API pro správu různých entit grafu a jejich formátování pomocí vlastních hodnot:

1. Vytvořte instanci třídy **Presentation**.
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte graf s výchozími daty a libovolným požadovaným typem (v tomto příkladu použijeme ChartType.LineWithMarkers).
4. Získejte přístup k ose Hodnot (Value Axis) grafu a nastavte následující vlastnosti:
   1. Nastavení **Line format** pro hlavní mřížkové čáry osy Hodnot
   2. Nastavení **Line format** pro vedlejší mřížkové čáry osy Hodnot
   3. Nastavení **Number Format** pro osu Hodnot
   4. Nastavení **Min, Max, Major and Minor units** pro osu Hodnot
   5. Nastavení **Text Properties** pro data osy Hodnot
   6. Nastavení **Title** pro osu Hodnot
   7. Nastavení **Line Format** pro osu Hodnot
5. Získejte přístup k ose Kategorie grafu a nastavte následující vlastnosti:
   1. Nastavení **Line format** pro hlavní mřížkové čáry osy Kategorie
   2. Nastavení **Line format** pro vedlejší mřížkové čáry osy Kategorie
   3. Nastavení **Text Properties** pro data osy Kategorie
   4. Nastavení **Title** pro osu Kategorie
   5. Nastavení **Label Positioning** pro osu Kategorie
   6. Nastavení **Rotation Angle** pro popisky osy Kategorie
6. Získejte přístup k legendě grafu a nastavte **Text Properties** pro ni.
7. Nastavte zobrazení legend grafu bez překrývání grafu.
8. Získejte přístup k **Secondary Value Axis** grafu a nastavte následující vlastnosti:
   1. Povolit sekundární **Value Axis**
   2. Nastavení **Line Format** pro sekundární osu Hodnot
   3. Nastavení **Number Format** pro sekundární osu Hodnot
   4. Nastavení **Min, Max, Major and Minor units** pro sekundární osu Hodnot
9. Nyní vykreslete první sérii grafu na sekundární osu Hodnot.
10. Nastavte barvu výplně zadní stěny grafu.
11. Nastavte barvu výplně oblasti vykreslení grafu.
12. Uložte upravenou prezentaci do souboru PPTX.

```c#
// Instancování prezentace// Instancování prezentace
Presentation pres = new Presentation();

// Accessing the first slide
ISlide slide = pres.Slides[0];

// Adding the sample chart
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

// Nastavení názvu grafu
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
IPortion chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "Sample Chart";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

// Nastavení formátu hlavních mřížkových čar pro osu hodnot
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

// Nastavení formátu vedlejších mřížkových čar pro osu hodnot
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

// Nastavení číselného formátu osy hodnot
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

// Nastavení maximálních a minimálních hodnot grafu
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

// Nastavení textových vlastností osy hodnot
IChartPortionFormat txtVal = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
txtVal.FontBold = NullableBool.True;
txtVal.FontHeight = 16;
txtVal.FontItalic = NullableBool.True;
txtVal.FillFormat.FillType = FillType.Solid; ;
txtVal.FillFormat.SolidFillColor.Color = Color.DarkGreen;
txtVal.LatinFont = new FontData("Times New Roman");

// Nastavení názvu osy hodnot
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
IPortion valtitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valtitle.Text = "Primary Axis";
valtitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valtitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valtitle.PortionFormat.FontHeight = 20;
valtitle.PortionFormat.FontBold = NullableBool.True;
valtitle.PortionFormat.FontItalic = NullableBool.True;

// Nastavení formátu čáry osy hodnot : nyní zastaralé
// chart.Axes.VerticalAxis.aVerticalAxis.l.AxisLine.Width = 10;
// chart.Axes.VerticalAxis.AxisLine.FillFormat.FillType = FillType.Solid;
// Chart.Axes.VerticalAxis.AxisLine.FillFormat.SolidFillColor.Color = Color.Red;

// Nastavení formátu hlavních mřížkových čar pro osu kategorií
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

// Nastavení formátu vedlejších mřížkových čar pro osu kategorií
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

// Nastavení textových vlastností osy kategorií
IChartPortionFormat txtCat = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
txtCat.FontBold = NullableBool.True;
txtCat.FontHeight = 16;
txtCat.FontItalic = NullableBool.True;
txtCat.FillFormat.FillType = FillType.Solid; ;
txtCat.FillFormat.SolidFillColor.Color = Color.Blue;
txtCat.LatinFont = new FontData("Arial");

// Nastavení názvu kategorie
chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

IPortion catTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
catTitle.Text = "Sample Category";
catTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
catTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
catTitle.PortionFormat.FontHeight = 20;
catTitle.PortionFormat.FontBold = NullableBool.True;
catTitle.PortionFormat.FontItalic = NullableBool.True;

// Nastavení pozice popisků osy kategorií
chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;

// Nastavení úhlu otočení popisků osy kategorií
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

// Nastavení textových vlastností legendy
IChartPortionFormat txtleg = chart.Legend.TextFormat.PortionFormat;
txtleg.FontBold = NullableBool.True;
txtleg.FontHeight = 16;
txtleg.FontItalic = NullableBool.True;
txtleg.FillFormat.FillType = FillType.Solid; ;
txtleg.FillFormat.SolidFillColor.Color = Color.DarkRed;

// Nastavit zobrazení legend grafu bez překrývání grafu

chart.Legend.Overlay = true;
            
// Vykreslení první řady na sekundární osu hodnot
// Chart.ChartData.Series[0].PlotOnSecondAxis = true;

// Nastavení barvy zadní zdi grafu
chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;
// Nastavení barvy oblasti vykreslení
chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

// Save Presentation
pres.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```

## **Nastavení vlastností písma pro graf**
Aspose.Slides pro .NET poskytuje podporu pro nastavení vlastností souvisejících s písmem pro graf. Postupujte podle následujících kroků pro nastavení vlastností písma v grafu.

- Instancujte objekt třídy Presentation.
- Přidejte graf na snímek.
- Nastavte výšku písma.
- Uložte upravenou prezentaci.

```c#
using (Presentation pres = new Presentation())
{               
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.TextFormat.PortionFormat.FontHeight = 20;
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
    pres.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
}
```

## **Nastavení číselného formátu**
Aspose.Slides pro .NET poskytuje jednoduché API pro správu formátu dat v grafu:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte graf s výchozími daty a libovolným požadovaným typem (v tomto příkladu se používá **ChartType.ClusteredColumn**).
4. Nastavte předdefinovaný číselný formát z možných předdefinovaných hodnot.
5. Projděte buňky dat grafu v každé sérii grafu a nastavte číselný formát dat grafu.
6. Uložte prezentaci.
7. Nastavte vlastní číselný formát.
8. Projděte buňky dat grafu v každé sérii grafu a nastavte jiný číselný formát dat grafu.
9. Uložte prezentaci.

```c#
// Instancování prezentace// Instancování prezentace
Presentation pres = new Presentation();

// Přístup k prvnímu snímku prezentace
ISlide slide = pres.Slides[0];

// Přidání výchozího seskupeného sloupcového grafu
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

// Získání kolekce řad grafu
IChartSeriesCollection series = chart.ChartData.Series;

// Nastavení předdefinovaného číselného formátu
// Procházení všech řad grafu
foreach (ChartSeries ser in series)
{
    // Procházení všech datových buněk v řadě
    foreach (IChartDataPoint cell in ser.DataPoints)
    {
        // Nastavení číselného formátu
        cell.Value.AsCell.PresetNumberFormat = 10; //0.00%
    }
}

// Ukládání prezentace
pres.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```

Možné předdefinované hodnoty číselného formátu spolu s jejich indexy, které lze použít, jsou uvedeny níže:

|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Nastavení zaoblených hran oblasti grafu**
Aspose.Slides pro .NET poskytuje podporu pro nastavení oblasti grafu. V Aspose.Slides byly přidány vlastnosti **IChart.HasRoundedCorners** a **Chart.HasRoundedCorners**.

1. Instancujte objekt třídy `Presentation`.
2. Přidejte graf na snímek.
3. Nastavte typ výplně a barvu výplně grafu
4. Nastavte vlastnost zaoblení rohů na True.
5. Uložte upravenou prezentaci.

```c#
using (Presentation presentation = new Presentation())
{
	ISlide slide = presentation.Slides[0];
	IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
	chart.LineFormat.FillFormat.FillType = FillType.Solid;
	chart.LineFormat.Style = LineStyle.Single;
	chart.HasRoundedCorners = true;

	presentation.Save("out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Často kladené otázky**

**Mohu nastavit poloprůhledné výplně pro sloupce/oblasti a zároveň zachovat okraj neprůhledný?**

Ano. Průhlednost výplně a obrys jsou konfigurovány samostatně. To je užitečné pro zlepšení čitelnosti mřížky a dat v hustých vizualizacích.

**Jak mohu řešit popisky dat, když se překrývají?**

Snižte velikost písma, zakažte nepodstatné komponenty popisků (například kategorie), nastavte odsazení/pozici popisku, zobrazujte popisky pouze pro vybrané body, pokud je to nutné, nebo změňte formát na "hodnota + legenda".

**Mohu použít gradientní nebo vzorové výplně na série?**

Ano. Obě solidní i gradientní/vzorové výplně jsou obvykle k dispozici. V praxi používejte gradienty střídmě a vyhněte se kombinacím, které snižují kontrast s mřížkou a textem.