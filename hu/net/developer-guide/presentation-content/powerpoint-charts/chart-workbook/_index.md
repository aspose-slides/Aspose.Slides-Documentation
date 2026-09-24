---
title: Diagram munkafüzetek kezelése prezentációkban .NET-ben
linktitle: Diagram munkafüzet
type: docs
weight: 70
url: /hu/net/chart-workbook/
keywords:
- diagram munkafüzet
- diagram adat
- munkafüzet cella
- adatcímke
- munkalap
- adatforrás
- külső munkafüzet
- külső adat
- diagram gyorsítótár
- munkafüzet helyreállítás
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for .NET-et: könnyedén kezelje a diagram munkafüzeteket PowerPoint és OpenDocument formátumokban, hogy egyszerűsítse prezentációi adatait."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan lehet dolgozni diagram munkafüzetekkel az Aspose.Slides-ban. Bemutatja, hogyan lehet olvasni és írni diagram adatokat munkafüzet áramokon keresztül, munkafüzet cellákat használni diagramadat‑címkeként, hozzáférni munkalapgyűjteményekhez, és megadni az adatforrás típusát a diagram értékekhez.

Szintén tárgyalja a külső munkafüzetek diagramadat‑forrásként való használatát. A példák bemutatják, hogyan lehet létrehozni és hozzárendelni egy külső munkafüzetet, lekérni egy diagramhoz kapcsolt külső munkafüzet útvonalát, és szerkeszteni a diagramadatokat, amikor a munkafüzet elérhető.

A hiányzó adatot jelző munkafüzet cellákhoz lásd a [Control the Display of Empty Cells](/slides/hu/net/chart-series/) cikket, amely az üres cella és a nulla közti különbséget, valamint a rendelkezésre álló megjelenítési módok vonaldiagram összehasonlítását mutatja be.

## **Diagramadatok olvasása és írása munkafüzetről**

Az Aspose.Slides a [ReadWorkbookStream](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdata/readworkbookstream/) és a [WriteWorkbookStream](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdata/writeworkbookstream/) metódusokat kínálja, amelyek lehetővé teszik diagramadat‑munkafüzetek (Aspose.Cells‑szel szerkesztett diagramadatokat tartalmazó) olvasását és írását. **Megjegyzés** hogy a diagramadatoknak ugyanúgy kell felépülniük, vagy hasonló szerkezettel kell rendelkezniük, mint a forrás.

Ez a C# kód bemutat egy példaműveletet:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

using (Presentation pres = new Presentation("chart.pptx"))
{
    Chart chart = (Chart) pres.Slides[0].Shapes[0];
    IChartData data = chart.ChartData;

    MemoryStream stream = data.ReadWorkbookStream();

    data.Series.Clear();
    data.Categories.Clear();

    stream.Position = 0;
    data.WriteWorkbookStream(stream);
}
```

### **Diagramelrendezés ellenőrzése munkafüzet módosítása után**

Amikor egy beágyazott munkafüzetet egy módosítottal helyettesít, a diagram megtartja az eredeti sorozat‑ és kategória‑gyűjteményeit. Ez a nem egyezés a [IChart.ValidateChartLayout](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichart/validatechartlayout/) hibához vezethet index‑hatókörön kívül álló hibaüzenettel. Írja ki a meglévő sorozatokat és kategóriákat, mielőtt az frissített munkafüzetet visszaírná a diagramba.

```csharp
// A munkafüzet áram módosítása után (például az Aspose.Cells használatával)
using var updatedWorkbook = chartData.ReadWorkbookStream();

// Törölje a meglévő adat hivatkozásokat.
chartData.Series.Clear();
chartData.Categories.Clear();

updatedWorkbook.Position = 0;
chartData.WriteWorkbookStream(updatedWorkbook);

chart.ValidateChartLayout();
```

A gyűjtemények törlése biztosítja, hogy a diagramadat struktúra összhangban legyen az új munkafüzettel, lehetővé téve a `ValidateChartLayout` hibamentes befejezését.

## **Munkafüzetcellát beállítani diagramadatcímkének**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.  
1. Szerezze be egy dia referenciaját az indexe alapján.  
1. Adjon hozzá egy buborékdiagramot némi adattal.  
1. Hozzon hozzá a diagram sorozatához.  
1. Állítsa be a munkafüzetcellát adatcímkének.  
1. Mentse a prezentációt.

Ez a C# kód bemutatja, hogyan állítson be egy munkafüzetcellát diagramadatcímkének:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// Példányosít egy prezentáció osztályt, amely egy prezentáció fájlt képvisel

using (Presentation pres = new Presentation("chart2.pptx"))
{
    ISlide slide = pres.Slides[0];


    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);

    IChartSeriesCollection series = chart.ChartData.Series;

    series[0].Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;

    IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

    series[0].Labels[0].ValueFromCell = wb.GetCell(0, "A10", lbl0);
    series[0].Labels[1].ValueFromCell = wb.GetCell(0, "A11", lbl1);
    series[0].Labels[2].ValueFromCell = wb.GetCell(0, "A12", lbl2);

    pres.Save("resultchart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Munkalapok kezelése**

Ez a C# kód bemutat egy műveletet, ahol az [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) tulajdonságot használják munkalapgyűjtemény eléréséhez:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
   IChartDataWorkbook wb =  chart.ChartData.ChartDataWorkbook;
   for (int i = 0; i < wb.Worksheets.Count; i++)
      Console.WriteLine(wb.Worksheets[i].Name);
}
```

## **Adatforrás típusának megadása**

Ez a C# kód megmutatja, hogyan adjon meg egy típust egy adatforrásnak:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue val = chart.ChartData.Series[0].Name;
    
    val.DataSourceType = DataSourceType.StringLiterals;
    val.Data = "LiteralString";

    val = chart.ChartData.Series[1].Name;
    val.Data = chart.ChartData.ChartDataWorkbook.GetCell(0, "B1", "NewCell");

    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Nem támogatott beágyazott munkafüzet formátumok észlelése**

Az Aspose.Slides nem támogatja az Excel bináris munkafüzet (.xlsb) formátumot, amely néhány diagramba beágyazható. Használhatja a `EmbeddedWorkbookType` tulajdonságot az [IChartData](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdata/) osztályon, valamint a [WorkbookType](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/workbooktype/) felsorolást, hogy észlelje a nem támogatott formátumokat és kihagyja azokat a diagramokat.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using (var presentation = new Presentation("sample.pptx"))
{
    var slide = presentation.Slides[0];

    foreach (var shape in slide.Shapes)
    {
        if (shape is not IChart chart) continue;

        var chartData = chart.ChartData;

        if (chartData.DataSourceType == ChartDataSourceType.InternalWorkbook &&
            chartData.EmbeddedWorkbookType == WorkbookType.WorkbookBinaryMacro)
        {
            // Beágyazott munkafüzet .xlsb formátumú, amely nem támogatott.
            continue;
        }

        // Olvassa vagy módosítsa a diagram munkafüzet adatait itt.
    }
}
```

## **Külső munkafüzet**

Az Aspose.Slides támogatja a külső munkafüzetek diagramadat‑forrásként való használatát.

### **Külső munkafüzet létrehozása**

A **`ReadWorkbookStream`** és **`SetExternalWorkbook`** metódusok használatával létrehozhat egy külső munkafüzetet a semmiből, vagy egy belső munkafüzetet külsővé tehet.

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    const string workbookPath = "externalWorkbook1.xlsx";

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600);
    using (FileStream fileStream = new FileStream(workbookPath, FileMode.Create))
    {
        byte[] workbookData = chart.ChartData.ReadWorkbookStream().ToArray();
        fileStream.Write(workbookData, 0, workbookData.Length);
    }
    
    chart.ChartData.SetExternalWorkbook(Path.GetFullPath(workbookPath));

    pres.Save("externalWorkbook.pptx", SaveFormat.Pptx);
}
```

### **Külső munkafüzet beállítása**

A **`SetExternalWorkbook`** metódussal egy külső munkafüzetet rendelhet egy diagram adatforrásaként. Ez a metódus használható a külső munkafüzet útvonalának frissítésére is (ha az utóbbiból áthelyezték).

Bár a távoli helyeken vagy erőforrásokban tárolt munkafüzetek adatait nem szerkesztheti, továbbra is használhatja őket külső adatforrásként. Ha relatív útvonalat ad meg egy külső munkafüzettel, az automatikusan teljes útvonalra konvertálódik.

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// A dokumentumok könyvtárának az útvonala.
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, false);
    IChartData chartData = chart.ChartData;
                    
    chartData.SetExternalWorkbook(Path.GetFullPath("externalWorkbook.xlsx"));
              

    chartData.Series.Add(chartData.ChartDataWorkbook.GetCell(0, "B1"), ChartType.Pie);
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B2"));
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B3"));
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B4"));

    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A2"));
    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A3"));
    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A4"));
    pres.Save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
}
```

A `ChartData` paraméter (a `SetExternalWorkbook` metódus alatt) azt határozza meg, hogy egy Excel munkafüzet be lesz-e töltve vagy sem.

* Ha a `ChartData` értéke `false`, csak a munkafüzet útvonala frissül – a diagramadatok nem lesznek betöltve vagy frissítve a célmunka füzetből. Ezt a beállítást akkor érdemes használni, ha a cél munkafüzet nem létezik vagy nem érhető el.  
* Ha a `ChartData` értéke `true`, a diagramadatok a cél munkafüzetről frissülnek.

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **Külső adatforrás munkafüzet útvonalának lekérése egy diagramhoz**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.  
1. Szerezze be egy dia referenciaját az indexe alapján.  
1. Hozzon létre egy objektumot a diagram alakzat számára.  
1. Hozzon létre egy objektumot a forrás (`ChartDataSourceType`) típusához, amely a diagram adatforrását képviseli.  
1. Adja meg a releváns feltételt, amely a forrás típusát a külső munkafüzet adatforrás típusával egyezik.

Ez a C# kód bemutatja a műveletet:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    ISlide slide = pres.Slides[1];
    IChart chart = (IChart)slide.Shapes[0];
    ChartDataSourceType sourceType = chart.ChartData.DataSourceType;
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        string path = chart.ChartData.ExternalWorkbookPath;
    }
    
    // Mentés a prezentáció
    pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

### **Diagramadat szerkesztése**

Külső munkafüzetek adatait ugyanúgy szerkesztheti, mint a belső munkafüzetek tartalmát. Ha egy külső munkafüzetet nem lehet betölteni, kivétel lesz dobva.

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```

### **Munkafüzet helyreállítása a diagram gyorsítótárából**

Ha egy diagram egy hiányzó vagy nem elérhető külső munkafüzetet használ, az Aspose.Slides képes rekonstruálni a diagram munkafüzetét a prezentációban tárolt gyorsítótárazott adatokból. Hozzon létre [LoadOptions](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/), állítsa be a [SpreadsheetOptions](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/spreadsheetoptions/) beállításait, és a [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hu/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) értéket `true`‑ra, mielőtt megnyitná a prezentációt.

A következő C# példa megnyit egy prezentációt, amelynek diagramja egy nem elérhető külső munkafüzetre hivatkozik, és a helyreállított adatokat a [IChart.ChartData](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichart/chartdata/) és a [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdata/chartdataworkbook/) segítségével éri el:

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

var loadOptions = new LoadOptions
{
    SpreadsheetOptions = new SpreadsheetOptions
    {
        RecoverWorkbookFromChartCache = true
    }
};

using var presentation = new Presentation("presentation.pptx", loadOptions);

var chart = (IChart)presentation.Slides[0].Shapes[0];
var recoveredWorkbook = chart.ChartData.ChartDataWorkbook;

// Read or modify the recovered workbook data here.
```

Ha a külső munkafüzet nem elérhető és a helyreállítás le van tiltva, az Aspose.Slides egy `InvalidOperationException`‑t dob. Engedélyezze a helyreállítást csak akkor, ha a gyorsítótárazott diagramadatok használata elfogadható visszalépés, mivel a gyorsítótár nem feltétlenül tartalmazza a külső munkafüzetben a prezentáció legutóbbi frissítése után történt módosításokat.

## **GYIK**

**Meg tudom határozni, hogy egy adott diagram egy külső vagy beágyazott munkafüzethez van‑e kapcsolva?**  
Igen. A diagramnek van egy [data source type](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/chartdata/datasourcetype/) és egy [path to an external workbook](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/chartdata/externalworkbookpath/); ha a forrás egy külső munkafüzet, kiolvashatja a teljes útvonalat, hogy biztos legyen abban, hogy külső fájlt használnak.

**Támogatottak a relatív útvonalak a külső munkafüzetekhez, és hogyan tárolódnak?**  
Igen. Ha relatív útvonalat ad meg, az automatikusan átalakul abszolút útvonallá. Ez kényelmes a projekt hordozhatósága szempontjából; azonban vegye figyelembe, hogy a prezentáció az abszolút útvonalat tárolja a PPTX fájlban.

**Használhatok munkafüzeteket hálózati erőforrásokon/megosztásokon?**  
Igen, ilyen munkafüzetek használhatók külső adatforrásként. Azonban a távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑ből nem támogatott – csak forrásként használhatók.

**Felülírja az Aspose.Slides a külső XLSX‑et a prezentáció mentésekor?**  
Nem. A prezentáció egy [link to the external file](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/chartdata/externalworkbookpath/) tárol, amelyet az adatok olvasásához használ. A külső fájl maga nem módosul a prezentáció mentésekor.

**Mit kell tennem, ha a külső fájl jelszóval védett?**  
Az Aspose.Slides nem fogad el jelszót a kapcsolódáskor. Egy gyakori megoldás, hogy előre eltávolítja a védelmet, vagy egy feloldott másolatot (például az [Aspose.Cells](/cells/net/) használatával) készít, és arra a másolatra hivatkozik.

**Több diagram hivatkozhat ugyanarra a külső munkafüzetre?**  
Igen. Minden diagram saját hivatkozást tárol. Ha mindegyik ugyanarra a fájlra mutat, a fájl frissítése minden diagramnál megjelenik a következő adatbetöltéskor.