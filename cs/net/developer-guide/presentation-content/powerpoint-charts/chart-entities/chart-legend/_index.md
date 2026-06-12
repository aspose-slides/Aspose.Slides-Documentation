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
description: "Přizpůsobte legendy grafů pomocí Aspose.Slides pro .NET a optimalizujte prezentace PowerPoint s přizpůsobeným formátováním legend."
---
## **Přehled**

Aspose.Slides poskytuje možnosti přizpůsobení legend grafů v prezentacích PowerPoint. Tento článek ukazuje, jak umístit a změnit velikost legendy, nastavit velikost písma pro celou legendu a aplikovat formátování na jednotlivý záznam legendy.

Také se v sekci FAQ probírají související chování, včetně použití režimu bez překrytí, aby oblast grafu uvolnila místo pro legendu, povolení zalamování dlouhých popisků legend nebo použití konců řádků a umožnění, aby formátování legendy dědilo motiv prezentace, pokud nejsou nastaveny explicitní textové a výplňové hodnoty.

## **Umístění legendy**
Pro nastavení vlastností legendy postupujte podle následujících kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) .
- Získejte referenci na snímek.
- Přidejte graf na snímek.
- Nastavte vlastnosti legendy.
- Uložte prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme nastavili pozici a velikost legendy grafu.

```c#
// Vytvořte instanci třídy Presentation
Presentation presentation = new Presentation();

// Získejte referenci na snímek
ISlide slide = presentation.Slides[0];

// Přidejte seskupený sloupcový graf na snímek
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// Nastavte vlastnosti legendy
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

// Uložte prezentaci na disk
presentation.Save("Legend_out.pptx", SaveFormat.Pptx);
```

## **Nastavení velikosti písma legendy**
Aspose.Slides pro .NET umožňuje vývojářům nastavit velikost písma legendy. Postupujte podle následujících kroků:

- Instancujte třídu `Presentation` .
- Vytvořte výchozí graf.
- Nastavte velikost písma.
- Nastavte minimální hodnotu osy.
- Nastavte maximální hodnotu osy.
- Uložte prezentaci na disk.

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.Legend.TextFormat.PortionFormat.FontHeight = 20;
	chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
	chart.Axes.VerticalAxis.MinValue = -5;
	chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
	chart.Axes.VerticalAxis.MaxValue = 10;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Nastavení velikosti písma jednotlivé legendy**
Aspose.Slides pro .NET umožňuje vývojářům nastavit velikost písma jednotlivých položek legendy. Postupujte podle následujících kroků:

- Instancujte třídu `Presentation` .
- Vytvořte výchozí graf.
- Přístup k položce legendy.
- Nastavte velikost písma.
- Nastavte minimální hodnotu osy.
- Nastavte maximální hodnotu osy.
- Uložte prezentaci na disk.

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
	IChartTextFormat tf = chart.Legend.Entries[1].TextFormat;

	tf.PortionFormat.FontBold = NullableBool.True;
	tf.PortionFormat.FontHeight = 20;
	tf.PortionFormat.FontItalic = NullableBool.True;
	tf.PortionFormat.FillFormat.FillType = FillType.Solid; ;
	tf.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Mohu povolit legendu tak, aby graf automaticky vyčlenil místo pro ni místo překrytí?**

Ano. Použijte režim bez překrytí ([Overlay](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/legend/overlay/) = `false`); v tomto případě se oblast grafu zmenší, aby uvolnila místo pro legendu.

**Mohu vytvořit vícero řádkové popisky legendy?**

Ano. Dlouhé popisky se automaticky zalamují, pokud není dostatek místa; vynucené konce řádků jsou podporovány pomocí znaků nového řádku v názvu řady.

**Jak zajistím, aby legenda následovala barevné schéma motivu prezentace?**

Nenastavujte explicitní barvy/výplně/písma pro legendu nebo její text. Ty pak zdědí nastavení z motivu a správně se aktualizují při změně návrhu.