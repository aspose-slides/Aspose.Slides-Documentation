---
title: Přidání čar trendu do diagramů v prezentacích v .NET
linktitle: Čára trendu
type: docs
url: /cs/net/trend-line/
keywords:
- diagram
- čára trendu
- exponenciální čára trendu
- lineární čára trendu
- logaritmická čára trendu
- čára trendu s klouzavým průměrem
- polynomiální čára trendu
- mocninná čára trendu
- vlastní čára trendu
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Rychle přidejte a přizpůsobte čáry trendu v diagramech PowerPointu pomocí Aspose.Slides pro .NET — praktický průvodce, jak zaujmout své publikum."
---
## **Přehled**

Tento článek popisuje, jak pomocí Aspose.Slides přidat do diagramů prezentace čáry trendu. Ukazuje, jak vytvořit diagram, přidat čáry trendu do sérií diagramu a pracovat s několika typy čar trendu, včetně exponenciální, lineární, logaritmické, klouzavého průměru, polynomiální a mocninné.

Také popisuje, jak přidat vlastní čáru do diagramu vložením tvaru čáry, a obsahuje krátké FAQ o hodnotách projekce čáry trendu dopředu a dozadu a o tom, zda jsou čáry trendu zachovány při exportu do PDF nebo SVG a při vykreslování diagramů jako obrázků.

## **Přidání čáry trendu**
Aspose.Slides for .NET poskytuje jednoduché rozhraní API pro správu různých čar trendu v diagramech:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte diagram s výchozími daty a požadovaným typem (v tomto příkladu se používá ChartType.ClusteredColumn).
1. Přidejte exponenciální čáru trendu pro sérii diagramu 1.
1. Přidejte lineární čáru trendu pro sérii diagramu 1.
1. Přidejte logaritmickou čáru trendu pro sérii diagramu 2.
1. Přidejte čáru trendu s klouzavým průměrem pro sérii diagramu 2.
1. Přidejte polynomiální čáru trendu pro sérii diagramu 3.
1. Přidejte mocninnou čáru trendu pro sérii diagramu 3.
1. Zapište upravenou prezentaci do souboru PPTX.

Následující kód slouží k vytvoření diagramu s čarami trendu.

```c#
// Vytvoření prázdné prezentace
Presentation pres = new Presentation();

// Vytvoření sloupcového seskupeného diagramu
IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

// Přidání exponenciální čáry trendu pro sérii diagramu 1
ITrendline tredLinep = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Exponential);
tredLinep.DisplayEquation = false;
tredLinep.DisplayRSquaredValue = false;

// Přidání lineární čáry trendu pro sérii diagramu 1
ITrendline tredLineLin = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Linear);
tredLineLin.TrendlineType = TrendlineType.Linear;
tredLineLin.Format.Line.FillFormat.FillType = FillType.Solid;
tredLineLin.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;


// Přidání logaritmické čáry trendu pro sérii diagramu 2
ITrendline tredLineLog = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Logarithmic);
tredLineLog.TrendlineType = TrendlineType.Logarithmic;
tredLineLog.AddTextFrameForOverriding("New log trend line");

// Přidání čáry trendu s klouzavým průměrem pro sérii diagramu 2
ITrendline tredLineMovAvg = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.MovingAverage);
tredLineMovAvg.TrendlineType = TrendlineType.MovingAverage;
tredLineMovAvg.Period = 3;
tredLineMovAvg.TrendlineName = "New TrendLine Name";

// Přidání polynomiální čáry trendu pro sérii diagramu 3
ITrendline tredLinePol = chart.ChartData.Series[2].TrendLines.Add(TrendlineType.Polynomial);
tredLinePol.TrendlineType = TrendlineType.Polynomial;
tredLinePol.Forward = 1;
tredLinePol.Order = 3;

// Přidání mocninné čáry trendu pro sérii diagramu 3
ITrendline tredLinePower = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Power);
tredLinePower.TrendlineType = TrendlineType.Power;
tredLinePower.Backward = 1;

// Ukládání prezentace
pres.Save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
```



## **Přidání vlastní čáry**
Aspose.Slides for .NET poskytuje jednoduché rozhraní API pro přidání vlastních čar v diagramu. Pro přidání jednoduché rovné čáry na vybraný snímek prezentace postupujte podle následujících kroků:

- Vytvořte instanci třídy Presentation
- Získejte odkaz na snímek pomocí jeho indexu
- Vytvořte nový diagram pomocí metody AddChart, která je součástí objektu Shapes
- Přidejte AutoShape typu Line pomocí metody AddAutoShape, která je součástí objektu Shapes
- Nastavte barvu čar tvaru.
- Zapište upravenou prezentaci jako soubor PPTX

Následující kód slouží k vytvoření diagramu s vlastními čarami.

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    IAutoShape shape = chart.UserShapes.Shapes.AddAutoShape(ShapeType.Line, 0, chart.Height / 2, chart.Width, 0);
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
    pres.Save("AddCustomLines.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Co znamenají pojmy „dopředu“ a „dozadu“ u čáry trendu?**

Jedná se o délky čáry trendu projekované dopředu nebo dozadu: u rozptylových (XY) diagramů v jednotkách osy; u ostatních diagramů v počtu kategorií. Povolené jsou pouze nezáporné hodnoty.

**Zůstane čára trendu zachována při exportu prezentace do PDF nebo SVG, nebo při vykreslování snímku jako obrázku?**

Ano. Aspose.Slides převádí prezentace na [PDF](/slides/cs/net/convert-powerpoint-to-pdf/)/[SVG](/slides/cs/net/render-a-slide-as-an-svg-image/) a vykresluje diagramy do obrázků; čáry trendu jako součást diagramu jsou při těchto operacích zachovány. K dispozici je také metoda pro [export obrázku samotného diagramu](/slides/cs/net/create-shape-thumbnails/).