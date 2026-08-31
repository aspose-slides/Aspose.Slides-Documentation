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
description: "Fedezze fel az Aspose.Slides for .NET-et: könnyedén kezelje a diagram munkafüzeteit PowerPoint és OpenDocument formátumokban, hogy egyszerűsítse a prezentáció adatokat."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhatunk diagrammunkafüzetekkel az Aspose.Slides-ban. Megmutatja, hogyan olvashatunk és írhatunk diagramadatokat munkafüzet adatfolyamokon keresztül, hogyan használhatjuk a munkafüzet cellákat diagram adatcímkeként, hogyan érhetjük el a munkalapgyűjteményeket, és hogyan adhatjuk meg az adatforrás típusát a diagramértékekhez.

A cikk továbbá foglalkozik külső munkafüzetek diagram adatforrásként való használatával. A példák bemutatják, hogyan hozhatunk létre és rendeljünk hozzá egy külső munkafüzetet, hogyan lekérhetjük egy diagramhoz kapcsolt külső munkafüzet útvonalát, és hogyan szerkeszthetjük a diagramadatokat, ha a munkafüzet elérhető.

## **Diagram adatok olvasása és írása munkafüzetből**
Aspose.Slides a [ReadWorkbookStream](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdata/readworkbookstream/) és a [WriteWorkbookStream](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdata/writeworkbookstream/) metódusokat biztosítja, amelyek lehetővé teszik a diagramadat‑munkafüzetek (Az Aspose.Cells‑sel szerkesztett diagramadatokat tartalmazó munkafüzetek) olvasását és írását. **Megjegyzés**: a diagramadatoknak ugyanúgy kell felépülniük, vagy hasonló szerkezettel kell rendelkezniük, mint a forrásnak.

Ez a C# kód bemutat egy mintaműveletet:

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

### **Diagram elrendezésének ellenőrzése a munkafüzet módosítása után**

Amikor egy beágyazott munkafüzetet lecserélünk egy módosítottra, a diagram megtartja az eredeti sorozat‑ és kategóriagyűjteményeit. Ez az eltérés az [IChart.ValidateChartLayout](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichart/validatechartlayout/) metódusban index‑hatókör‑hiba keletkezéséhez vezethet. Írja be az frissített munkafüzetet a diagramba, mielőtt kiüríti a meglévő sorozat‑ és kategóriaelemeket.

```csharp
// A munkafüzet adatfolyam módosítása után (pl. az Aspose.Cells használatával)
using var updatedWorkbook = chartData.ReadWorkbookStream();

// A meglévő adat hivatkozások törlése.
chartData.Series.Clear();
chartData.Categories.Clear();

updatedWorkbook.Position = 0;
chartData.WriteWorkbookStream(updatedWorkbook);

chart.ValidateChartLayout();
```

A gyűjtemények kiürítése biztosítja, hogy a diagram adatstruktúrája egyezzen az új munkafüzettel, így a `ValidateChartLayout` hibamentesen lefuthat.

## **Munkafüzet cella beállítása diagram adatcímkének**
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.  
1. Szerezze meg egy diára való hivatkozást az indexe alapján.  
1. Adjon hozzá egy buborékdiagramot némi adattal.  
1. Érje el a diagram sorozatát.  
1. Állítsa be a munkafüzet cellát adatcímkének.  
1. Mentse a prezentációt.

Ez a C# kód megmutatja, hogyan állíthat be egy munkafüzet cellát diagram adatcímkének:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// Példányosít egy prezentációs osztályt, amely egy prezentációs fájlt képvisel 

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

Ez a C# kód bemutat egy műveletet, ahol a [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) tulajdonságot használják a munkalapgyűjtemény elérésére:

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

Ez a C# kód megmutatja, hogyan adhat meg egy típust egy adatforráshoz:

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

Az Aspose.Slides nem támogatja az Excel bináris munkafüzet (.xlsb) formátumát, amelyet egyes diagramokba beágyazhatnak. A `EmbeddedWorkbookType` tulajdonságot az [IChartData](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdata/) mellett a [WorkbookType](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/workbooktype/) felsorolással használhatja a nem támogatott formátumok észleléséhez, és kihagyhatja az ilyen diagramokat.

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
            // A beágyazott munkafüzet .xlsb formátumban van, ami nem támogatott.
            continue;
        }

        // Olvassa vagy módosítsa a diagram munkafüzet adatait itt.
    }
}
```

## **Külső munkafüzet**

{{% alert color="info" %}} 
Az [Aspose.Slides 19.4](https://docs.aspose.com/slides/hu/net/aspose-slides-for-net-19-4-release-notes/) verzióban bevezettük a külső munkafüzetek diagramok adatforrásaként való támogatását.
{{% /alert %}} 

### **Külső munkafüzet létrehozása**
A **`ReadWorkbookStream`** és a **`SetExternalWorkbook`** metódusok segítségével létrehozhat egy külső munkafüzetet a semmiből, vagy egy belső munkafüzetet külsővé tehet.

Ez a C# kód bemutatja a külső munkafüzet létrehozási folyamatát:

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
A **`SetExternalWorkbook`** metódus segítségével hozzárendelhet egy külső munkafüzetet egy diagramhoz adatforrásként. Ezzel a módszerrel frissíthető a külső munkafüzet elérési útja is (ha a fájl áthelyezésre került).

Bár a távoli helyeken vagy erőforrásokban tárolt munkafüzetek adatait nem szerkesztheti, ezeket a munkafüzeteket továbbra is használhatja külső adatforrásként. Ha relatív útvonalat ad meg egy külső munkafüzethez, az automatikusan teljes útvonallá konvertálódik.

Ez a C# kód megmutatja, hogyan állíthat be egy külső munkafüzetet:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

A `ChartData` paraméter (a `SetExternalWorkbook` metódus alatt) azt jelzi, hogy egy Excel‑munkafüzet be lesz‑töltve vagy sem.

* Ha a `ChartData` értéke **false**, csak a munkafüzet útvonala frissül — a diagram adat nem lesz be‑ vagy frissítve a célmunkafüzettel. Ez a beállítás akkor hasznos, ha a célmunkafüzet nem létezik vagy nem érhető el.  
* Ha a `ChartData` értéke **true**, a diagram adatai frissülnek a célmunkafüzettel.

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

### **A diagram külső adatforrás munkafüzet útvonalának lekérése**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.  
1. Szerezze meg egy diára való hivatkozást az indexe alapján.  
1. Hozzon létre egy objektumot a diagram alakzathoz.  
1. Hozzon létre egy objektumot a forrást (`ChartDataSourceType`) reprezentáló típushoz, amely a diagram adatforrását jelöli.  
1. Adja meg a megfelelő feltételt a forrástípus alapján, amely megegyezik a külső munkafüzet adatforrás típussal.

Ez a C# kód demonstrálja a műveletet:

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
    
    // A prezentáció mentése
    pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

### **Diagram adatainak szerkesztése**

Külső munkafüzetek adatait ugyanúgy szerkesztheti, mint a belső munkafüzetekét. Ha egy külső munkafüzetet nem lehet betölteni, kivétel keletkezik.

Ez a C# kód a leírt folyamat megvalósítását mutatja:

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

Ha egy diagram külső, hiányzó vagy elérhetetlen munkafüzetet használ, az Aspose.Slides rekonstruálhatja a diagram munkafüzetet a prezentációban tárolt gyorsítótárazott adatokból. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/) példányt, konfigurálja a [SpreadsheetOptions](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/spreadsheetoptions/)‑t, és állítsa a [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hu/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) értékét **true**‑ra, mielőtt megnyitná a prezentációt.

Az alábbi C# példa megnyit egy olyan prezentációt, amelynek diagramja hiányzó külső munkafüzetre hivatkozik, és a helyreállított adatokat az [IChart.ChartData](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichart/chartdata/) és az [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdata/chartdataworkbook/) segítségével éri el:

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

Ha a külső munkafüzet elérhetetlen, és a helyreállítás ki van kapcsolva, az Aspose.Slides `InvalidOperationException`‑t dob. Csak akkor engedélyezze a helyreállítást, ha a gyorsítótárazott diagramadatok használata elfogadható tartalékmegoldás, mivel a gyorsítótár nem tartalmazhatja a külső munkafüzetben a prezentáció legutóbbi frissítése után végzett módosításokat.

## **GYIK**

**Meg tudom állapítani, hogy egy adott diagram egy külső vagy beágyazott munkafüzethez kapcsolódik?**  
Igen. A diagram rendelkezik egy [data source type](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/chartdata/datasourcetype/) és egy [path to an external workbook](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/chartdata/externalworkbookpath/) attribútummal; ha a forrás egy külső munkafüzet, kiolvashatja a teljes útvonalat, hogy megbizonyosodjon a külső fájl használatáról.

**Támogatottak-e relatív útvonalak a külső munkafüzetekhez, és hogyan tárolódnak?**  
Igen. Ha relatív útvonalat ad meg, az automatikusan abszolút útvonallá konvertálódik. Ez kényelmes a projekt hordozhatósága szempontjából; azonban a prezentáció az abszolút útvonalat tárolja a PPTX fájlban.

**Használhatók-e hálózati erőforrásokon/megosztott helyeken lévő munkafüzetek?**  
Igen, az ilyen munkafüzetek használhatók külső adatforrásként. Azonban a távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑ból nem támogatott – csak forrásként alkalmazhatók.

**Az Aspose.Slides felülírja-e a külső XLSX‑et a prezentáció mentésekor?**  
Nem. A prezentáció egy [link to the external file](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/chartdata/externalworkbookpath/) tárol, és ezt használja az adatok olvasásához. A külső fájl maga nem módosul a prezentáció mentésekor.

**Mit tegyek, ha a külső fájl jelszóval védett?**  
Az Aspose.Slides nem fogad jelszót a hivatkozáskor. Általános megoldás, hogy előre eltávolítja a védelmet, vagy egy visszafejtett másolatot készít (például az [Aspose.Cells](/cells/net/) segítségével), és ahhoz a másolathoz hivatkozik.

**Több diagram hivatkozhat-e ugyanarra a külső munkafüzetre?**  
Igen. Minden diagram saját hivatkozást tárol. Ha mind ugyanarra a fájlra mutatnak, a fájl frissítése minden diagram esetében megjelenik a következő adatbetöltéskor.