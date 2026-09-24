---
title: Přizpůsobení datových tabulek grafů v prezentacích v .NET
linktitle: Datová tabulka
type: docs
url: /cs/net/chart-data-table/
keywords:
- data grafu
- datová tabulka
- vlastnosti písma
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Přizpůsobte písma, okraje a klíče legendy datových tabulek grafů v prezentacích PowerPoint pomocí Aspose.Slides pro .NET a C#."
---
## **Přehled**

Aspose.Slides pro .NET vám umožňuje zobrazit datovou tabulku grafu a přizpůsobit její formátování textu, okraje a klíče legendy. Tento článek vysvětluje, jak zapnout tabulku, naformátovat její text, ovládat každý typ okraje a zobrazit nebo skrýt klíče legendy. Příklady ukládají nakonfigurované grafy do souborů PPTX.

## **Nastavení vlastností písma**

Chcete-li zobrazit datovou tabulku grafu, nastavte [HasDataTable](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/chart/hasdatatable/) na `true`. Pomocí [ChartDataTable](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/chart/chartdatatable/) získáte přístup k tabulce a nakonfigurujete formátování jejího textu.

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
1. Přidejte seskupený sloupcový graf na první snímek.
1. Povolte datovou tabulku grafu.
1. Povolte tučný text pomocí [FontBold](https://reference.aspose.com/slides/cs/net/aspose.slides/baseportionformat/fontbold/) a nastavte [FontHeight](https://reference.aspose.com/slides/cs/net/aspose.slides/baseportionformat/fontheight/) na `20` pro 20‑bodový text.
1. Uložte upravenou prezentaci.

Následující příklad vyžaduje soubor `test.pptx` v pracovním adresáři s alespoň jedním snímkem. Přidá graf s výchozími daty na pozici (50, 50) o šířce 600 bodů a výšce 400 bodů. Uložený soubor `output.pptx` obsahuje graf s povolenou datovou tabulkou a aplikovaným nastavením písma.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("test.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;

var portionFormat = chart.ChartDataTable.TextFormat.PortionFormat;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontHeight = 20;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Přizpůsobení okrajů datové tabulky**

Tabulku povolte pomocí [IChart.HasDataTable](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichart/hasdatatable/) a získáte k ní přístup přes [IChart.ChartDataTable](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichart/chartdatatable/). Můžete nezávisle ovládat tři typy okrajů:

- [HasBorderHorizontal](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/idatatable/hasborderhorizontal/) řídí vodorovné okraje buněk.
- [HasBorderVertical](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/idatatable/hasbordervertical/) řídí svislé okraje buněk.
- [HasBorderOutline](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/idatatable/hasborderoutline/) řídí vnější okraj tabulky.

Nastavte každou vlastnost na `true`, chcete‑li zobrazit její okraje, nebo na `false`, chcete‑li je skrýt. Následující příklad vytvoří seskupený sloupcový graf s výchozími daty, zobrazí vodorovné okraje a vnější okraj a skryje svislé okraje. Nevyžaduje žádný vstupní soubor. Pozice a velikost grafu jsou uvedeny v bodech.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;

var dataTable = chart.ChartDataTable;
dataTable.HasBorderHorizontal = true;
dataTable.HasBorderVertical = false;
dataTable.HasBorderOutline = true;

presentation.Save("data-table-borders.pptx", SaveFormat.Pptx);
```

Níže uvedené srovnání používá ve všech čtyřech případech stejná data grafu a nastavení klíčů legendy. Začíná se se všemi povolenými okraji, každý další variant vypíná právě jednu vlastnost okraje. Varianta v levém dolním rohu odpovídá nastavení okrajů v příkladu.

![Datové tabulky grafu se všemi okraji povoleny, bez vodorovných okrajů, bez svislých okrajů a bez vnějšího okraje](data-table-borders.png)

## **Zobrazit nebo skrýt klíče legendy**

Klíče legendy jsou malé barevné značky vedle názvů sérií v datové tabulce. Pomáhají čtenářům přiřadit každý řádek tabulky ke konkrétní sérii grafu. Nastavte [ShowLegendKey](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/idatatable/showlegendkey/) na `true`, chcete‑li zobrazit tyto značky, nebo na `false`, chcete‑li je skrýt.

Samostatná legenda grafu je řízena pomocí [IChart.HasLegend](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichart/haslegend/). Tato nastavení jsou nezávislá: skrytí samostatné legendy neovlivní klíče v datové tabulce a skrytí klíčů v tabulce neovlivní samostatnou legendu.

Následující příklad vytvoří graf s výchozími daty, povolí jeho datovou tabulku a zobrazí klíče legendy uvnitř ní, zatímco skrývá samostatnou legendu. Všechny okraje tabulky jsou výslovně povoleny. Vstupní prezentace není vyžadována. Chcete‑li skrýt pouze klíče v tabulce, změňte `dataTable.ShowLegendKey` na `false`.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;
chart.HasLegend = false;

var dataTable = chart.ChartDataTable;
dataTable.HasBorderHorizontal = true;
dataTable.HasBorderVertical = true;
dataTable.HasBorderOutline = true;
dataTable.ShowLegendKey = true;

presentation.Save("data-table-legend-keys.pptx", SaveFormat.Pptx);
```

Níže uvedené srovnání ukazuje stejnou tabulku s povolenými a zakázanými klíči legendy. Všechny okraje zůstávají povoleny a samostatná legenda grafu je v obou případech skryta.

![Datové tabulky grafu s klíči legendy zobrazenými vlevo a skrytými vpravo](data-table-legend-keys.png)

## **Často kladené otázky**

**Mohu zobrazit klíče legendy v datové tabulce grafu?**

Ano. Nastavte [ShowLegendKey](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/datatable/showlegendkey/) na `true` pro zobrazení klíčů legendy nebo na `false` pro jejich skrytí.

**Zůstane datová tabulka zachována při exportu prezentace do PDF, HTML nebo obrázků?**

Ano. Aspose.Slides vykreslí graf a jeho zobrazovanou datovou tabulku jako součást snímku při exportu do [PDF](/slides/cs/net/convert-powerpoint-to-pdf/), [HTML](/slides/cs/net/convert-powerpoint-to-html/) nebo [obrázků](/slides/cs/net/convert-powerpoint-to-png/).

**Mohu pracovat s datovými tabulkami v grafech načtených ze šablony?**

Ano. U grafu načteného z existující prezentace nebo šablony použijte [HasDataTable](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/chart/hasdatatable/) k ověření či změně, zda je jeho datová tabulka zobrazena.

**Jak mohu najít grafy s povolenou datovou tabulkou?**

Procházejte tvary na každém snímku, identifikujte grafy a zkontrolujte jejich vlastnost [HasDataTable](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/chart/hasdatatable/). Hodnota `true` znamená, že je datová tabulka povolena.