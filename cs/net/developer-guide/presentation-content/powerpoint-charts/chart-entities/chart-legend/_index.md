---
title: Přizpůsobení legend grafů v prezentacích v .NET
linktitle: Legenda grafu
type: docs
url: /cs/net/chart-legend/
keywords:
- legenda grafu
- pozice legendy
- velikost písma
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Přizpůsobte legendy grafů pomocí Aspose.Slides pro .NET a optimalizujte prezentace PowerPoint s upraveným formátováním legend."
---
## **Přehled**

Aspose.Slides for .NET poskytuje možnosti přizpůsobení legendy grafu v prezentacích PowerPoint. Tento článek ukazuje, jak umístit a změnit velikost legendy, nastavit velikost písma pro celou legendu, formátovat jednotlivý záznam legendy a skrýt nebo obnovit vybrané záznamy.

FAQ pokrývá související chování, včetně vyhrazení místa pro legendu, zobrazování víceřádkových popisků a dědění formátování z motivu prezentace.

## **Umístění legendy**

Použijte vlastnosti legendy [X](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/x/), [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/y/), [Width](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/width/) a [Height](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/height/) k určení jejího umístění a velikosti jako zlomků rozměrů grafu.

Tento příklad vytvoří prezentaci a přidá do první snímku seskupený sloupcový graf s výchozími daty. Rozdělením požadovaných posunů a rozměrů legendy šířkou a výškou grafu získáte relativní hodnoty: legenda je posunuta o 50 bodů od levého horního rohu grafu a má velikost 100 × 100 bodů.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// Vyjádřete pozici a velikost legendy relativně k grafu.
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

presentation.Save("legend_position.pptx", SaveFormat.Pptx);
```

## **Nastavení velikosti písma legendy**

Použijte legendu [TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/textformat/) pro přístup k formátování textu a nastavte [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) v bodech.

Tento příklad vytvoří graf s výchozími daty a nastaví text legendy na 20 bodů. Také zakáže automatické ohraničení svislé osy a nastaví její rozsah od -5 do 10.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

chart.Legend.TextFormat.PortionFormat.FontHeight = 20;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
chart.Axes.VerticalAxis.MinValue = -5;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 10;

presentation.Save("legend_font_size.pptx", SaveFormat.Pptx);
```

## **Nastavení velikosti písma jednotlivého záznamu legendy**

Použijte kolekci legendy [Entries](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/entries/) pro přístup k formátování konkrétního záznamu. Indexy záznamů jsou nulové, takže index `1` odkazuje na druhý záznam.

Tento příklad vytvoří seskupený sloupcový graf, jehož výchozí data obsahují alespoň dvě řady. Formátuje druhý záznam legendy tučným, kurzívním a modrým textem o velikosti 20 bodů.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
var textFormat = chart.Legend.Entries[1].TextFormat;

textFormat.PortionFormat.FontBold = NullableBool.True;
textFormat.PortionFormat.FontHeight = 20;
textFormat.PortionFormat.FontItalic = NullableBool.True;
textFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
textFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

presentation.Save("legend_entry_format.pptx", SaveFormat.Pptx);
```

## **Skrytí jednotlivých záznamů legendy**

Chcete‑li vyloučit pomocnou řadu z legendy a přitom zachovat její data viditelná, nastavte [ILegendEntryProperties.Hide](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegendentryproperties/hide/) na `true` přes [IChartSeries.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/relatedlegendentry/). Tím se skryje pouze vybraný záznam legendy; řada ani její datové body se neodstraní. Naopak nastavení [IChart.HasLegend](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/haslegend/) na `false` skryje celou legendu.

Níže uvedený příklad vytvoří seskupený sloupcový graf s více řadami pomocí výchozích dat. Skryje záznam legendy druhé řady (index `1`) a uloží prezentaci. Poté záznam obnoví nastavením `Hide` na `false` a uloží druhou kopii. Sloupce zůstanou v obou souborech viditelné.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 200);
chart.HasLegend = true;

var legendEntry = chart.ChartData.Series[1].RelatedLegendEntry;

legendEntry.Hide = true;
presentation.Save("hidden_legend_entry.pptx", SaveFormat.Pptx);

// Obnovte stejný záznam bez změny dat grafu.
legendEntry.Hide = false;
presentation.Save("restored_legend_entry.pptx", SaveFormat.Pptx);
```

Níže uvedené srovnání ukazuje stejný graf se všemi viditelnými záznamy legendy a se skrytým řadou 2 v legendě; všechny sloupce zůstávají viditelné.

![Porovnání grafu se všemi viditelnými záznamy legendy a se skrytým řadou 2 v legendě; všechny sloupce zůstávají viditelné.](hide-legend-entry.png)

V sloupcových, pruhových a čárových grafech záznamy legendy identifikují řady. U výsečových grafů identifikují jednotlivé datové body (výseče), proto použijte [IChartDataPoint.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/relatedlegendentry/) na vybranou výseč. API dokumentuje tuto vlastnost datového bodu pro typy grafů `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` a `BarOfPie`. Nepřepokládejte, že se vztahuje i na prstencové grafy, které v tomto seznamu nejsou.

## **Často kladené otázky**

**Mohu nechat graf vyčlenit místo pro legendu místo překrývání?**

Ano. Nastavte [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/overlay/) na `false`, aby se vyčlenilo místo pro legendu místo povolení překrytí oblasti grafu.

**Mohu vytvořit vícřádkové popisky legendy?**

Ano. Dlouhé popisky se zalomí, pokud není k dispozici dostatečná šířka. Můžete také použít znaky nového řádku ve jménech řad k vynucení zalomení.

**Jak zajistit, aby legenda následovala barevné schéma motivu prezentace?**

Nechte barvy, výplně a písma legendy nenastavené, aby mohla zdědit formátování motivu. Výslovné formátování přepíše odpovídající nastavení motivu.