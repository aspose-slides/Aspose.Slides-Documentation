---
title: Přizpůsobení 3D grafů v prezentacích v .NET
linktitle: 3D graf
type: docs
url: /cs/net/3d-chart/
keywords:
- 3D graf
- rotace
- hloubka
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se vytvářet a přizpůsobovat 3-D grafy v Aspose.Slides pro .NET s podporou souborů PPT a PPTX - vylepšete své prezentace ještě dnes."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit 3D graf v Aspose.Slides konfigurací nastavení `Rotation3D`, jako jsou `RotationX`, `RotationY`, `DepthPercents` a `RightAngleAxes`. Prochází vytvořením prezentace, přidáním 3D grafu s výchozími daty, aplikací požadovaných nastavení 3D zobrazení a uložením upravené prezentace jako souboru PPTX.

## **Nastavení vlastností RotationX, RotationY a DepthPercents 3D grafu**
Aspose.Slides pro .NET poskytuje jednoduché API pro nastavení těchto vlastností. Tento následující článek vám pomůže, jak nastavit různé vlastnosti, jako je X, Y rotace, **DepthPercents** atd. Vzorový kód použije nastavení výše uvedených vlastností.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
2. Získejte první snímek.
3. Přidejte graf s výchozími daty.
4. Nastavte vlastnosti Rotation3D.
5. Zapište upravenou prezentaci do souboru PPTX.

```c#
// Vytvořte instanci třídy Presentation
Presentation presentation = new Presentation();
           
// Získejte první snímek
ISlide slide = presentation.Slides[0];

// Přidejte graf s výchozími daty
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

// Nastavení indexu listu s daty grafu
int defaultWorksheetIndex = 0;

// Získání pracovního listu s daty grafu
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Přidat sérii
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

// Přidat kategorie
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

// Nastavit vlastnosti Rotation3D
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 270;
chart.Rotation3D.DepthPercents = 150;

// Získat druhou sérii grafu
IChartSeries series = chart.ChartData.Series[1];

// Nyní se vyplňují data série
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// Nastavit hodnotu Overlap
series.ParentSeriesGroup.Overlap = 100;         

// Uložit prezentaci na disk
presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```

## **Často kladené otázky**

**Které typy grafů podporují režim 3D v Aspose.Slides?**

Aspose.Slides podporuje 3D varianty sloupcových grafů, včetně Column 3D, Clustered Column 3D, Stacked Column 3D a 100 % Stacked Column 3D, spolu s souvisejícími 3D typy zpřístupněnými prostřednictvím výčtu [ChartType](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/charttype/). Pro přesný a aktuální seznam zkontrolujte členy [ChartType](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/charttype/) v referenční dokumentaci API ve vaší nainstalované verzi.

**Mohu získat rastrový obrázek 3D grafu pro zprávu nebo web?**

Ano. Můžete exportovat graf jako obrázek pomocí [chart API](https://reference.aspose.com/slides/cs/net/aspose.slides/shape/getimage/) nebo [vyrenderovat celý snímek](/slides/cs/net/convert-powerpoint-to-png/) do formátů jako PNG nebo JPEG. To je užitečné, když potřebujete dokonalý náhled pixel po pixelu nebo chcete graf vložit do dokumentů, dashboardů či webových stránek bez potřeby PowerPointu.

**Jak výkonná je tvorba a vykreslování velkých 3D grafů?**

Výkon závisí na objemu dat a vizuální složitosti. Pro dosažení nejlepších výsledků udržujte 3D efekty na minimu, vyhněte se těžkým texturám na stěnách a ploše grafu, omezte počet datových bodů na sérii, pokud je to možné, a vykreslete výstup v odpovídající velikosti (rozlišení a rozměry), aby vyhovoval cílovému displeji nebo tisku.