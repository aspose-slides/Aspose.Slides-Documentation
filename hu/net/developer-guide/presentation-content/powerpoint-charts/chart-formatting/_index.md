---
title: PowerPoint-diagramok formázása .NET-ben
linktitle: Diagram formázása
type: docs
weight: 60
url: /hu/net/chart-formatting/
keywords:
- diagram formázása
- diagram formázás
- diagram entitás
- diagram tulajdonságok
- diagram beállítások
- diagram opciók
- betűtípus tulajdonságok
- lekerekített szegély
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg a diagramok formázását az Aspose.Slides for .NET-ben, és emelje prezentációját professzionális, figyelemfelkeltő stílusokkal."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan formázhatók a diagramok PowerPoint‑prezentációkban az Aspose.Slides segítségével. Megmutatja, hogyan testreszabhatók a diagram kulcsfontosságú elemei, mint például a tengelyek, a rácsvonalak, a címek, a jelmagyarázatok, a diagramterület és a falak kitöltései, a diagram adatainak megjelenését és olvashatóságát javítva.

Emellett bemutatja, hogyan állíthatók be a diagram szövegének betűtípus‑tulajdonságai, hogyan alkalmazhatók előre definiált és egyéni numerikus formátumok a diagram adataira, valamint hogyan engedélyezhetők lekerekített sarkok a diagram területén. Ezek a példák együtt azt mutatják, hogyan szabályozhatók a diagramok vizuális stílusa és adatmegjelenítése egy prezentációban.

## **Diagram Entitások Formázása**
Az Aspose.Slides for .NET lehetővé teszi a fejlesztők számára, hogy saját diagramokat adjanak a diákhoz a semmiből. Ez a cikk elmagyarázza, hogyan formázhatók a különböző diagram entitások, többek között a diagram kategória‑ és értéktengelye.

Az Aspose.Slides for .NET egyszerű API‑t biztosít a különböző diagram entitások kezeléséhez és egyéni értékekkel való formázásukhoz:

1. Hozzon létre egy **Presentation** osztálypéldányt.
1. Szerezze meg a dia hivatkozását az indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal a kívánt típusú diagrammal (ebben a példában a **ChartType.LineWithMarkers** típust használjuk).
1. Hozzáférés a diagram **Value Axis**‑hez, és állítsa be a következő tulajdonságokat:
   1. **Line format** beállítása az Value Axis fő rácslínáihoz
   1. **Line format** beállítása az Value Axis segéd rácslínáihoz
   1. **Number Format** beállítása az Value Axis‑hez
   1. **Min, Max, Major and Minor units** beállítása az Value Axis‑hez
   1. **Text Properties** beállítása az Value Axis adatainak
   1. **Title** beállítása az Value Axis‑hez
   1. **Line Format** beállítása az Value Axis‑hez
1. Hozzáférés a diagram **Category Axis**‑hez, és állítsa be a következő tulajdonságokat:
   1. **Line format** beállítása a Category Axis fő rácslínáihoz
   1. **Line format** beállítása a Category Axis segéd rácslínáihoz
   1. **Text Properties** beállítása a Category Axis adatainak
   1. **Title** beállítása a Category Axis‑hez
   1. **Label Positioning** beállítása a Category Axis‑hez
   1. **Rotation Angle** beállítása a Category Axis címkéihez
1. Hozzáférés a diagram **Legend**‑hez, és állítsa be a **Text Properties**‑t számára
1. Állítsa be a diagram jelmagyarázatok megjelenítését úgy, hogy ne fedjék egymást
1. Hozzáférés a diagram **Secondary Value Axis**‑hez, és állítsa be a következő tulajdonságokat:
   1. Engedélyezze a **Secondary Value Axis**‑t
   1. **Line Format** beállítása a Secondary Value Axis‑hez
   1. **Number Format** beállítása a Secondary Value Axis‑hez
   1. **Min, Max, Major and Minor units** beállítása a Secondary Value Axis‑hez
1. Ábrázolja az első diagram sorozatot a Secondary Value Axis‑en
1. Állítsa be a diagram hátfal kitöltőszínét
1. Állítsa be a diagram diagramterület kitöltőszínét
1. Írja a módosított prezentációt PPTX fájlba

```c#
// Prezentáció példányosítása// Prezentáció példányosítása
Presentation pres = new Presentation();

// Az első dia elérése
ISlide slide = pres.Slides[0];

// Minta diagram hozzáadása
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

// Diagram címének beállítása
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
IPortion chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "Sample Chart";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

// Az értéktengely fő rácsvonalainak formátumának beállítása
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

// Az értéktengely segéd rácsvonalainak formátumának beállítása
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

// Az értéktengely számformátumának beállítása
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

// Diagram maximum és minimum értékeinek beállítása
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

// Az értéktengely szöveg tulajdonságainak beállítása
IChartPortionFormat txtVal = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
txtVal.FontBold = NullableBool.True;
txtVal.FontHeight = 16;
txtVal.FontItalic = NullableBool.True;
txtVal.FillFormat.FillType = FillType.Solid; ;
txtVal.FillFormat.SolidFillColor.Color = Color.DarkGreen;
txtVal.LatinFont = new FontData("Times New Roman");

// Az értéktengely címének beállítása
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
IPortion valtitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valtitle.Text = "Primary Axis";
valtitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valtitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valtitle.PortionFormat.FontHeight = 20;
valtitle.PortionFormat.FontBold = NullableBool.True;
valtitle.PortionFormat.FontItalic = NullableBool.True;

// Az értéktengely vonalformátum beállítása: már elavult
// chart.Axes.VerticalAxis.aVerticalAxis.l.AxisLine.Width = 10;
// chart.Axes.VerticalAxis.AxisLine.FillFormat.FillType = FillType.Solid;
// Chart.Axes.VerticalAxis.AxisLine.FillFormat.SolidFillColor.Color = Color.Red;

// A kategória tengely fő rácsvonalainak formátumának beállítása
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

// A kategória tengely segéd rácsvonalainak formátumának beállítása
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

// A kategória tengely szöveg tulajdonságainak beállítása
IChartPortionFormat txtCat = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
txtCat.FontBold = NullableBool.True;
txtCat.FontHeight = 16;
txtCat.FontItalic = NullableBool.True;
txtCat.FillFormat.FillType = FillType.Solid; ;
txtCat.FillFormat.SolidFillColor.Color = Color.Blue;
txtCat.LatinFont = new FontData("Arial");

// A kategória címének beállítása
chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

IPortion catTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
catTitle.Text = "Sample Category";
catTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
catTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
catTitle.PortionFormat.FontHeight = 20;
catTitle.PortionFormat.FontBold = NullableBool.True;
catTitle.PortionFormat.FontItalic = NullableBool.True;

// A kategória tengely címke pozíciójának beállítása
chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;

// A kategória tengely címke forgatási szögének beállítása
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

// A jelmagyarázat szöveg tulajdonságainak beállítása
IChartPortionFormat txtleg = chart.Legend.TextFormat.PortionFormat;
txtleg.FontBold = NullableBool.True;
txtleg.FontHeight = 16;
txtleg.FontItalic = NullableBool.True;
txtleg.FillFormat.FillType = FillType.Solid; ;
txtleg.FillFormat.SolidFillColor.Color = Color.DarkRed;

// A diagram jelmagyarázatának megjelenítése átfedés nélkül

chart.Legend.Overlay = true;
            
// Az első sorozat ábrázolása a másodlagos értéktengelyen
// Chart.ChartData.Series[0].PlotOnSecondAxis = true;

// A diagram hátfal színének beállítása
chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;
// A diagram ábrázolási terület színének beállítása
chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

// Prezentáció mentése
pres.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```



## **Betűtípus‑tulajdonságok Beállítása Diagramhoz**
Az Aspose.Slides for .NET támogatja a diagram betűtípushoz kapcsolódó tulajdonságok beállítását. Kövesse az alábbi lépéseket a diagram betűtípus‑tulajdonságainak beállításához.

- Hozzon létre egy **Presentation** osztálypéldányt.
- Adjon hozzá egy diagramot a diára.
- Állítsa be a betűméretet.
- Mentse el a módosított prezentációt.

Az alábbi példa bemutatja a folyamatot.

```c#
using (Presentation pres = new Presentation())
{               
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.TextFormat.PortionFormat.FontHeight = 20;
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
    pres.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
}
```




## **Numerikus Formátum Beállítása**
Az Aspose.Slides for .NET egyszerű API‑t kínál a diagram adatformátum kezelésére:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
1. Szerezze meg a dia hivatkozását az indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal a kívánt típusú diagrammal (ez a példa a **ChartType.ClusteredColumn** típust használja).
1. Állítsa be az előre definiált számformátumot a lehetséges előre definiált értékek közül.
1. Járja be a diagram adatcelláit minden diagram sorozatban, és állítsa be a diagram adat számformátumát.
1. Mentse el a prezentációt.
1. Állítsa be az egyéni számformátumot.
1. Járja be a diagram adatcelláit minden diagram sorozatban, és állítson be különböző diagram adat számformátumot.
1. Mentse el a prezentációt.

```c#
// Prezentáció példányosítása// Prezentáció példányosítása
Presentation pres = new Presentation();

// Az első prezentációs dia elérése
ISlide slide = pres.Slides[0];

// Alapértelmezett csoportosított oszlop diagram hozzáadása
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

// A diagram sorozatgyűjteményének elérése
IChartSeriesCollection series = chart.ChartData.Series;

// Az előre definiált számformátum beállítása
// Végigjárás minden diagram sorozaton
foreach (ChartSeries ser in series)
{
    // Végigjárás minden adatcellán a sorozatban
    foreach (IChartDataPoint cell in ser.DataPoints)
    {
        // A számformátum beállítása
        cell.Value.AsCell.PresetNumberFormat = 10; //0.00%
    }
}

// Prezentáció mentése
pres.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```

Az alábbiakban megtalálhatók a lehetséges előre definiált számformátum‑értékek a megfelelő indexszámukkal:

|**0**|Általános|
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

## **Diagramterület Lekerekített Szegélyeinek Beállítása**
Az Aspose.Slides for .NET támogatja a diagramterület beállítását. Az **IChart.HasRoundedCorners** és a **Chart.HasRoundedCorners** tulajdonságok bekerültek az Aspose.Slides‑be.

1. Hozzon létre egy `Presentation` osztálypéldányt.
1. Adjon hozzá egy diagramot a diára.
1. Állítsa be a kitöltés típusát és színét a diagramhoz.
1. Állítsa a lekerekített sarok tulajdonságot **True**‑ra.
1. Mentse el a módosított prezentációt.

Az alábbi példa demonstrálja a folyamatot.

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

## **GYIK**

**Beállíthatok félig átlátszó kitöltést oszlopokhoz/területekhez, miközben a szegély átlátszatlan marad?**

Igen. A kitöltés átlátszósága és a körvonal külön-külön konfigurálható. Ez hasznos a rács és az adatok olvashatóságának javítása érdekében sűrű vizualizációk esetén.

**Hogyan kezeljem a címkéket, ha átfedik egymást?**

Csökkentse a betűméretet, kapcsolja ki a nem lényeges címkeelemeket (például a kategóriákat), állítsa be a címke eltolását/pozícióját, szükség esetén csak a kiválasztott pontok címkéit jelenítse meg, vagy váltsa a formátumot „érték + jelmagyarázat” módra.

**Alkalmazhatok‑e gradient vagy mintázott kitöltést sorozatokra?**

Igen. Mind a szilárd, mind a gradient/mintázott kitöltés általában elérhető. Gyakorlatban használjon gradienteket mértékkel, és kerülje az olyan kombinációkat, amelyek csökkentik a kontrasztot a rács és a szöveg között.