---
title: Kezelje a diagram munkafüzeteket a bemutatókban .NET környezetben
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
- PowerPoint
- bemutató
- .NET
- C#
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for .NET-et: egyszerűen kezelje a diagram munkafüzeteket PowerPoint és OpenDocument formátumokban, hogy hatékonyabbá tegye a bemutató adatait."
---
## **Áttekintés**

Ez a cikk leírja, hogyan lehet a diagram munkafüzetekkel dolgozni az Aspose.Slides-ban. Bemutatja, hogyan lehet a diagramadatokat munkafüzet‑stream‑eken keresztül olvasni és írni, a munkafüzet cellákat diagramadat‑címkeként használni, a munkalap‑gyűjteményekhez hozzáférni, és hogyan lehet megadni az adatforrás típusát a diagramértékekhez.  

Továbbá tárgyalja a külső munkafüzetek diagramadat‑forrásként való használatát. A példák bemutatják, hogyan lehet külső munkafüzetet létrehozni és hozzárendelni, a diagramhoz kapcsolt külső munkafüzet útvonalát lekérni, valamint a diagramadatokat szerkeszteni, ha a munkafüzet elérhető.

## **Diagramadatok olvasása és írása egy munkafüzetből**
Az Aspose.Slides a [ReadWorkbookStream](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdata/readworkbookstream/) és a [WriteWorkbookStream](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdata/writeworkbookstream/) metódusokat kínálja, amelyek lehetővé teszik a diagramadat‑munkafüzetek (az Aspose.Cells‑szel szerkesztett diagramadatokat tartalmazó) olvasását és írását. **Megjegyzés**: a diagramadatoknak ugyanúgy kell felépülniük, vagy hasonló struktúrával kell rendelkezniük, mint a forrás.

```c#
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

## **Munkafüzetcellát beállítása diagramadat‑címkeként**
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.  
1. Szerezze meg egy dia referenciáját az indexe alapján.  
1. Adjon hozzá egy buborékdiagramot néhány adattal.  
1. Érje el a diagram sorozatát.  
1. Állítsa be a munkafüzet cellát adatcímkeként.  
1. Mentse a bemutatót.

```c#
string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// Létrehozza a prezentációt reprezentáló osztály egy példányát, amely egy prezentációs fájlt képvisel 

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
Ez a C# kód bemutat egy műveletet, amelyben az [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) tulajdonságot használják a munkalap‑gyűjtemény eléréséhez:

``` csharp
using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
   IChartDataWorkbook wb =  chart.ChartData.ChartDataWorkbook;
   for (int i = 0; i < wb.Worksheets.Count; i++)
      Console.WriteLine(wb.Worksheets[i].Name);
}
```

## **Az adatforrás típusának megadása**
Ez a C# kód megmutatja, hogyan lehet egy típusú adatforrást megadni:

```c#
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

## **Nem támogatott beágyazott munkafüzet formátumok felismerése**
Az Aspose.Slides nem támogatja azt az Excel bináris munkafüzet (.xlsb) formátumot, amely egyes diagramokba beágyazható. Használhatja az `EmbeddedWorkbookType` tulajdonságot az [IChartData](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdata/) mellett, valamint a [WorkbookType](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/workbooktype/) felsorolást a nem támogatott formátumok felismeréséhez és az ilyen diagramok kihagyásához.

```csharp
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
            // A beágyazott munkafüzet .xlsb formátumban van, ami nem támogatott.
            continue;
        }

        // Itt olvashatja vagy módosíthatja a diagram munkafüzet adatokat.
    }
}
```

## **Külső munkafüzet**

{{% alert color="primary" %}} 
Az [Aspose.Slides 19.4](https://docs.aspose.com/slides/hu/net/aspose-slides-for-net-19-4-release-notes/) verzióban bevezettük a külső munkafüzetek diagramadat‑forrásként való támogatását.  
{{% /alert %}} 

### **Külső munkafüzet létrehozása**
A **`ReadWorkbookStream`** és a **`SetExternalWorkbook`** metódusok használatával vagy egy külső munkafüzetet hozhat létre az elejétől, vagy egy belső munkafüzetet tehet külsővé.

```c#
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
A **`SetExternalWorkbook`** metódus segítségével egy külső munkafüzetet rendelhet egy diagramhoz adatforrásként. Ezzel a metódussal a külső munkafüzet elérési útját is frissítheti (ha az később át lett helyezve).

Bár a távoli helyeken vagy erőforrásokban tárolt munkafüzetek adatait nem szerkesztheti közvetlenül, továbbra is használhatja ezeket a munkafüzeteket külső adatforrásként. Ha relatív útvonalat ad meg egy külső munkafüzethez, az automatikusan teljes úttá konvertálódik.

```c#
// A dokumentumok könyvtárának elérési útja.
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

A `ChartData` paraméter (a `SetExternalWorkbook` metódus alatt) azt határozza meg, hogy egy Excel munkafüzet be lesz‑töltve‑e vagy sem.

* Ha a `ChartData` értéke **false**, csak a munkafüzet útvonala frissül — a diagramadat nem töltődik be, és nem frissül a célmunkafüzetből. Ezt a beállítást akkor érdemes használni, ha a célmunkafüzet nem létezik vagy nem érhető el.  
* Ha a `ChartData` értéke **true**, a diagramadat a célmunkafüzettől frissül.

```c#
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
1. Szerezze meg egy dia referenciáját az indexe alapján.  
1. Hozzon létre egy objektumot a diagram alakzatához.  
1. Hozzon létre egy objektumot a forrás (`ChartDataSourceType`) típusához, amely a diagram adatforrását jelöli.  
1. Adja meg a megfelelő feltételt a forrás típusa alapján, ha az megegyezik a külső munkafüzet adatforrás típusával.

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ISlide slide = pres.Slides[1];
    IChart chart = (IChart)slide.Shapes[0];
    ChartDataSourceType sourceType = chart.ChartData.DataSourceType;
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        string path = chart.ChartData.ExternalWorkbookPath;
    }
    
    // Elmenti a prezentációt
    pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

### **Diagramadatok szerkesztése**

Külső munkafüzetek adatait ugyanúgy szerkesztheti, ahogy a belső munkafüzetek tartalmát módosítaná. Ha egy külső munkafüzetet nem lehet betölteni, kivétel keletkezik.

```c#
using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```

## **GYIK**

**Meg tudom határozni, hogy egy adott diagram külső vagy beágyazott munkafüzethez van‑e kapcsolva?**  

Igen. A diagram rendelkezik [adatforrás típusával](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/chartdata/datasourcetype/) és egy [úttal egy külső munkafüzethez](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/chartdata/externalworkbookpath/); ha a forrás egy külső munkafüzet, akkor a teljes útvonal kiolvasható, így ellenőrizhető, hogy külső fájlt használ‑e.

**Támogatottak-e a relatív útvonalak a külső munkafüzetekhez, és hogyan tárolódnak?**  

Igen. Ha relatív útvonalat ad meg, az automatikusan átalakul abszolút útvonallá. Ez kényelmes a projekt hordozhatósága szempontjából; azonban a prezentáció az abszolút útvonalat tárolja a PPTX fájlban.

**Használhatók‑e hálózati erőforrásokon/megosztásokon lévő munkafüzetek?**  

Igen, ilyen munkafüzetek használhatók külső adatforrásként. A távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑ból nem támogatott — csak forrásként használhatók.

**Az Aspose.Slides felülírja‑e a külső XLSX‑et a prezentáció mentésekor?**  

Nem. A prezentáció egy [hivatkozást tárol a külső fájlra](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/chartdata/externalworkbookpath/), és ezt használja az adatok olvasásához. A külső fájl maga nem módosul a prezentáció mentésekor.

**Mi a teendő, ha a külső fájl jelszóval védett?**  

Az Aspose.Slides nem fogad jelszót a kapcsolódáskor. Általános megoldás, hogy előre eltávolítja a védelmet, vagy egy dekódolt másolatot készít (például a [Aspose.Cells](/cells/net/) segítségével), majd arra hivatkozik.

**Több diagram hivatkozhat‑e ugyanarra a külső munkafüzetre?**  

Igen. Minden diagram saját hivatkozást tárol. Ha mind ugyanarra a fájlra mutatnak, akkor a fájl frissítése minden diagram esetében megjelenik a következő adatbetöltéskor.