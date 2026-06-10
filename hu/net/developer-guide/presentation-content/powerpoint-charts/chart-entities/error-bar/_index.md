---
title: Hibaoszlopok testreszabása a bemutató diagramokban .NET-ben
linktitle: Hibaoszlop
type: docs
url: /hu/net/error-bar/
keywords:
- hibaoszlop
- egyéni érték
- PowerPoint
- bemutató
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan adhat hozzá és testreszabhat hibaoszlopokat a diagramokhoz az Aspose.Slides for .NET segítségével—optimalizálja az adatvizualizációkat a PowerPoint bemutatókban."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet hibaoszlopokkal dolgozni a bemutatók diagramjaiban az Aspose.Slides segítségével. Megmutatja, hogyan adhat hibaoszlopokat egy diagram sorozathoz, hogyan konfigurálhatja az X és Y hibaoszlop beállításokat, és hogyan alkalmazhat különböző értéktípusokat, például fix, százalékos és egyéni értékeket.

Az is bemutatja, hogyan lehet egyedi hibaoszlop értékeket hozzárendelni egy sorozat egyes adatpontjaihoz a megfelelő adatpontgyűjtemény használatával. Emellett a cikk rövid megjegyzéseket tartalmaz arról, hogyan viselkednek a hibaoszlopok az exportálás során, kompatibilitásukról a jelölőkkel és adatcímkékkel, valamint arról, hol találhatók a kapcsolódó API hivatkozási osztályok és felsorolások.

## **Hibaoszlopok hozzáadása**
Az Aspose.Slides for .NET egyszerű API-t biztosít a hibaoszlop értékek kezeléséhez. A példakód akkor alkalmazható, ha egy egyéni értéktípust használ. Egy érték megadásához használja a **ErrorBarCustomValues** tulajdonságot a sorozat **DataPoints** gyűjteményében lévő egy adott adatpontra:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
1. Adjon hozzá egy buborékdiagramot a kívánt diára.
1. Hozzáférés az első diagram sorozathoz, és állítsa be a hibaoszlop X formátumát.
1. Hozzáférés az első diagram sorozathoz, és állítsa be a hibaoszlop Y formátumát.
1. Az oszlopok értékeinek és formátumának beállítása.
1. Írja a módosított prezentációt egy PPTX fájlba.

```c#
 // Üres prezentáció létrehozása
using (Presentation presentation = new Presentation())
{
    // Buborékdiagram létrehozása
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Hibaoszlopok hozzáadása és formátumuk beállítása
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

    // Prezentáció mentése
    presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```



## **Egyéni hibaoszlop értékek hozzáadása**
Az Aspose.Slides for .NET egyszerű API-t biztosít az egyéni hibaoszlop értékek kezeléséhez. A példakód akkor alkalmazható, amikor a **IErrorBarsFormat.ValueType** tulajdonság **Custom** értékre van állítva. Egy érték megadásához használja a **ErrorBarCustomValues** tulajdonságot a sorozat **DataPoints** gyűjteményében lévő egy adott adatpontra:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
1. Adjon hozzá egy buborékdiagramot a kívánt diára.
1. Hozzáférés az első diagram sorozathoz, és állítsa be a hibaoszlop X formátumát.
1. Hozzáférés az első diagram sorozathhoz, és állítsa be a hibaoszlop Y formátumát.
1. Hozzáférés a diagram sorozat egyes adatpontjaihoz, és az egyéni sorozat adatpontra vonatkozó hibaoszlop értékek beállítása.
1. Az oszlopok értékeinek és formátumának beállítása.
1. Írja a módosított prezentációt egy PPTX fájlba.

```c#
// Üres prezentáció létrehozása
using (Presentation presentation = new Presentation())
{
    // Buborékdiagram létrehozása
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Egyéni hibaoszlopok hozzáadása és formátumuk beállítása
    IChartSeries series = chart.ChartData.Series[0];
    IErrorBarsFormat errBarX = series.ErrorBarsXFormat;
    IErrorBarsFormat errBarY = series.ErrorBarsYFormat;
    errBarX.IsVisible = true;
    errBarY.IsVisible = true;
    errBarX.ValueType = ErrorBarValueType.Custom;
    errBarY.ValueType = ErrorBarValueType.Custom;

    // Diagram sorozat adatpontjának elérése és hibaoszlop értékek beállítása egyedi ponthoz
    IChartDataPointCollection points = series.DataPoints;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = DataSourceType.DoubleLiterals;

    // Hibaoszlopok beállítása a diagram sorozat pontjaihoz
    for (int i = 0; i < points.Count; i++)
    {
        points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 1;
    }

    // Prezentáció mentése
    presentation.Save("ErrorBarsCustomValues_out.pptx", SaveFormat.Pptx);
}
```

## **GYIK**

**Mi történik a hibaoszlopokkal, amikor egy prezentációt PDF‑re vagy képekre exportálunk?**

A diagram részeként kerülnek megjelenítésre, és a konverzió során megmaradnak a diagram többi formázásával együtt, feltéve hogy kompatibilis verzió vagy renderelő áll rendelkezésre.

**Kombinálhatók a hibaoszlopok a jelölőkkel és adatcímkékkel?**

Igen. A hibaoszlopok különálló elemek, és kompatibilisek a jelölőkkel és adatcímkékkel; ha az elemek átfedik egymást, előfordulhat, hogy a formázást módosítani kell.

**Hol található a hibaoszlopokkal való munkához szükséges tulajdonságok és felsorolások listája az API‑ban?**

Az API hivatkozásban: a [ErrorBarsFormat](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/errorbarsformat/) osztály és a kapcsolódó felsorolások [ErrorBarType](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/errorbartype/) és [ErrorBarValueType](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/errorbarvaluetype/).