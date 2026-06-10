---
title: Diagram adat sorozatok kezelése prezentációkban .NET-ben
linktitle: Adatsorozat
type: docs
url: /hu/net/chart-series/
keywords:
- diagram sorozat
- sorozat átfedés
- sorozat szín
- kategória szín
- sorozat név
- adatpont
- sorozat hézag
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan kezelje a diagram sorozatokat C#‑ban PowerPoint (PPT/PPTX) számára gyakorlati kódpéldákkal és legjobb gyakorlatokkal, hogy adatprezentációit fejlessze."
---
## **Áttekintés**

Ez a cikk leírja a [ChartSeries](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/chartseries/) szerepét az Aspose.Slides for .NET-ben, a prezentációkban az adatok szerkezetének és megjelenítésének fókuszálásával. Ezek az objektumok adják a alapvető elemeket, amelyek meghatározzák az egyes adatpontok, kategóriák és megjelenítési paraméterek halmazát egy diagramon. A [ChartSeries](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/chartseries/) használatával a fejlesztők zökkenőmentesen integrálhatják az alaprendszer adatforrásait, és teljes ellenőrzést gyakorolhatnak az információ megjelenítése felett, így dinamikus, adatvezérelt prezentációkat hozhatnak létre, amelyek egyértelműen közvetítik az eredményeket és elemzéseket.

Egy sor egy sor vagy oszlop számsor, amely egy diagramon megjelenik.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Állítsa be a diagram sorok átfedését**

Az [IChartSeriesOverlap](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseries/properties/overlap) tulajdonság szabályozza, hogyan fednek egymásra az oszlopok és sávok egy 2D diagramon, -100 és 100 közötti értékkel. Mivel ez a tulajdonság a sorcsoporthoz tartozik, nem írható a sor szintjén. Az átfedési értékek beállításához használja a `ParentSeriesGroup.Overlap` olvasható/írható tulajdonságot, amely a megadott átfedést az adott csoport összes sorára alkalmazza.

Az alábbi C# példa bemutatja, hogyan hozhat létre egy prezentációt, adjon hozzá egy halmozott oszlopdiagramot, érje el az első diagram sorozatot, konfigurálja az átfedés beállítást, majd mentse el az eredményt PPTX fájlként:

```cs
sbyte overlap = 30;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Adj hozzá egy halmozott oszlopdiagramot alapértelmezett adatokkal.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.ChartData.Series[0];
    if (series.Overlap == 0)
    {
        // Állítsd be a sorozat átfedését.
        series.ParentSeriesGroup.Overlap = overlap;
    }

    // Mentsd el a prezentáció fájlt lemezre.
    presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A sor átfedése](series_overlap.png)

## **A sor kitöltőszínének módosítása**

Az Aspose.Slides egyszerűvé teszi a diagram sorok kitöltőszíneinek testreszabását, lehetővé téve bizonyos adatpontok kiemelését és a vizuálisan vonzó diagramok létrehozását. Erre az [IFormat](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/iformat/) objektum szolgál, amely különféle kitöltéstípusokat, színbeállításokat és egyéb fejlett stíluslehetőségeket támogat. Miután a diagramot hozzáadta egy diahoz, és elérte a kívánt sorozatot, egyszerűen kapja meg a sorozatot és alkalmazza a megfelelő kitöltőszínt. Az egyszínű kitöltéseken túl használhat átmenetes vagy mintás kitöltéseket is a tervezési rugalmasság növeléséhez. Miután a színeket a követelményeknek megfelelően beállította, mentse el a prezentációt a frissített megjelenés véglegesítéséhez.

Az alábbi C# kódrészlet bemutatja, hogyan változtatható meg az első sorozat színe:

```cs
Color seriesColor = Color.Blue;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Adj hozzá egy halmozott oszlopdiagramot alapértelmezett adatokkal.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Állítsd be az első sorozat színét.
    IChartSeries series = chart.ChartData.Series[0];
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;

    // Mentsd el a prezentáció fájlt lemezre.
    presentation.Save("series_color.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A sor színe](series_color.png)

## **A sor nevének módosítása**

Az Aspose.Slides egyszerű módot kínál a diagram sorok nevének módosítására, megkönnyítve az adatok egyértelmű és értelmes címkézését. A diagram adatainak megfelelő munkalap cellájának elérésével a fejlesztők testre szabhatják, hogyan jelennek meg az adatok. Ez a módosítás különösen hasznos, ha a sorok nevét a kontextus alapján kell frissíteni vagy tisztázni. A sor átnevezése után a prezentáció mentése rögzíti a változásokat.

Az alábbi C# kódrészlet bemutatja ezt a folyamatot.

```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Adj hozzá egy halmozott oszlopdiagramot alapértelmezett adatokkal.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Állítsd be az első sorozat nevét.
    IChartDataCell seriesCell = chart.ChartData.ChartDataWorkbook.GetCell(0, 0, 1);
    seriesCell.Value = seriesName;

    // Mentsd el a prezentáció fájlt lemezre.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```

A következő C# kód egy alternatív módot mutat a sor név változtatására:

```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Adj hozzá egy halmozott oszlopdiagramot alapértelmezett adatokkal.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Állítsd be az első sorozat nevét.
    IChartSeries series = chart.ChartData.Series[0];
    series.Name.AsCells[0].Value = seriesName;

    // Mentsd el a prezentáció fájlt lemezre.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A sor neve](series_name.png)

## **Az automatikus sor kitöltőszín lekérése**

Az Aspose.Slides for .NET lehetővé teszi, hogy lekérje a diagram sorok automatikus kitöltőszínét egy ábrázoló területen belül. Egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) példány létrehozása után referenciát szerezhet a kívánt diára index alapján, majd hozzáadhat egy diagramot a preferált típussal (például `ChartType.ClusteredColumn`). A diagram sorainak elérése után lekérhető az automatikus kitöltőszín.

Az alábbi C# kód részletesen bemutatja ezt a folyamatot.

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Adj hozzá egy halmozott oszlopdiagramot alapértelmezett adatokkal.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        // Szerezd meg a sorozat kitöltőszínét.
        Color color = chart.ChartData.Series[i].GetAutomaticSeriesColor();
        Console.WriteLine($"Series {i} color: {color.Name}");
    }
}
```

Kimenet:
```text
Series 0 color: ff4f81bd
Series 1 color: ffc0504d
Series 2 color: ff9bbb59
```

## **Inverz kitöltőszín beállítása diagram sorhoz**

Ha egy adat sorozat pozitív és negatív értékeket egyaránt tartalmaz, minden oszlop vagy sáv azonos színnel való színezése nehezen olvashatóvá teheti a diagramot. Az Aspose.Slides for .NET lehetővé teszi, hogy egy invertált kitöltőszínt rendeljünk hozzá – egy külön kitöltést, amely automatikusan a nullánál alacsonyabb adatpontokra alkalmazódik –, így a negatív értékek azonnal kiemelkednek. Ebben a szakaszban megtanulja, hogyan engedélyezheti ezt a beállítást, válasszon megfelelő színt, és mentse el a frissített prezentációt.

Az alábbi kódrészlet bemutatja a műveletet:

```cs
Color inverColor = Color.Red;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartDataWorkbook workBook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Új kategóriák hozzáadása.
    chart.ChartData.Categories.Add(workBook.GetCell(0, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 3, 0, "Category 3"));

    // Új sorozat hozzáadása.
    IChartSeries series = chart.ChartData.Series.Add(workBook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // A sorozat adatok feltöltése.
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 1, 1, -20));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 3, 1, -30));

    // Színbeállítások meghatározása a sorozathoz.
    var seriesColor = series.GetAutomaticSeriesColor();
    series.InvertIfNegative = true;
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;
    series.InvertedSolidFillColor.Color = inverColor;

    presentation.Save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![Az invertált egyszínű kitöltőszín](inverted_solid_fill_color.png)

Invertált kitöltőszínt beállíthat egyetlen adatpontra is, nem csak az egész sorra. Egyszerűen érje el a kívánt `IChartDataPoint` elemet, és állítsa be az `InvertIfNegative` tulajdonságot `true` értékre.

Az alábbi kódrészlet mutatja, hogyan hajtható végre ez:

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200, true);

    chart.ChartData.Series.Clear();
    IChartSeries series = chart.ChartData.Series.Add(chart.ChartData.ChartDataWorkbook.GetCell(0, "B1"), chart.Type);

    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B2", -5));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B3", 3));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B4", -3));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B5", 1));

    // Invertáld a színt, ha a 2. indexű adatpont negatív.
    series.InvertIfNegative = false;
    series.DataPoints[2].InvertIfNegative = true;
                
    presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
}
```

## **Speciális adatpont értékek törlése**

Néha egy diagram tesztértékeket, kiugró adatokat vagy elavult bejegyzéseket tartalmaz, amelyeket újra kell építeni a teljes sorozat helyett. Az Aspose.Slides for .NET lehetővé teszi, hogy bármely adatpontot index szerint célba vegyen, törölje annak tartalmát, és azonnal frissítse a diagramot, így a maradék pontok eltolódnak, és a tengelyek automatikusan újraméreteződnek.

Az alábbi kódrészlet bemutatja a műveletet:

```cs
using (Presentation presentation = new Presentation("test_chart.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = (IChart)slide.Shapes[0];
    IChartSeries series = chart.ChartData.Series[0];

    foreach (IChartDataPoint dataPoint in series.DataPoints)
    {
        dataPoint.XValue.AsCell.Value = null;
        dataPoint.YValue.AsCell.Value = null;
    }

    series.DataPoints.Clear();

    presentation.Save("clear_data_points.pptx", SaveFormat.Pptx);
}
```

## **A sor hézagszélességének beállítása**

A hézagszélesség szabályozza az egymás mellett elhelyezkedő oszlopok vagy sávok közötti üres tér mértékét – a szélesebb hézagok hangsúlyozzák az egyes kategóriákat, míg a szűkebb hézagok sűrűbb, kompaktabb megjelenést eredményeznek. Az Aspose.Slides for .NET segítségével finoman hangolhatja ezt a paramétert egy teljes sorozatra, így pontosan azt a vizuális egyensúlyt érheti el, amelyet a prezentáció igényel, anélkül, hogy az alapprobléma adatait módosítaná.

Az alábbi kódrészlet bemutatja, hogyan állítható be a sor hézagszélessége:

```cs
ushort gapWidth = 30;

// Üres prezentáció létrehozása.
using (Presentation presentation = new Presentation())
{
    // Az első dia elérése.
    ISlide slide = presentation.Slides[0];

    // Diagram hozzáadása alapértelmezett adatokkal.
    IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

    // A prezentáció mentése lemezre.
    presentation.Save("default_gap_width.pptx", SaveFormat.Pptx);

    // A GapWidth érték beállítása.
    IChartSeries series = chart.ChartData.Series[0];
    series.ParentSeriesGroup.GapWidth = gapWidth;

    // A prezentáció mentése lemezre.
    presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A hézag szélessége](gap_width.png)

## **GYIK**

**Van korlát arra, hogy egy diagram hány sorozatot tartalmazhat?**

Az Aspose.Slides nem határoz meg fix felső határt a sorozatok számát illetően. A gyakorlati korlátot a diagram olvashatósága és az alkalmazás rendelkezésére álló memória határozza meg.

**Mi van, ha a klaszterben lévő oszlopok túl közel vagy túl távol vannak egymástól?**

Állítsa be a `GapWidth` értékét az adott sorozatra (vagy annak szülő sorcsoportjára). Az érték növelése szélesíti az oszlopok közti távolságot, míg a csökkentése közelebb hozza őket egymáshoz.