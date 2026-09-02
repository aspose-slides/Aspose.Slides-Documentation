---
title: Diagram munkafüzeteinek kezelése prezentációkban .NET-ben
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
description: "Fedezze fel az Aspose.Slides for .NET-et: könnyedén kezelje a diagram munkafüzeteit PowerPoint és OpenDocument formátumokban, hogy egyszerűsítse prezentációjának adatait."
---
## **Áttekintés**

Ez a cikk azt mutatja be, hogyan dolgozzunk diagrammunnekkönyvekkel az Aspose.Slides-ben. Bemutatja, hogyan olvassuk és írjuk a diagram adatokat munkafüzet-áramlatokon keresztül, hogyan használjuk a munkafüzet cellákat diagramadat-címkeként, hogyan érjük el a munkalap-gyűjteményeket, és hogyan adjuk meg az adatforrás típusát a diagram értékekhez.

Továbbá lefedi a külső munkafüzetek diagramadat-forrásként való használatát. A példák bemutatják, hogyan hozzunk létre és rendeljünk hozzá egy külső munkafüzetet, hogyan szerezzük meg egy diagramhoz kapcsolódó külső munkafüzet útvonalát, és hogyan szerkesszük a diagram adatokat, ha a munkafüzet elérhető.

## **Diagramadatok olvasása és írása munkafüzettel**

Aspose.Slides biztosítja a [ReadWorkbookStream](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdata/readworkbookstream/) és [WriteWorkbookStream](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdata/writeworkbookstream/) metódusokat, amelyek lehetővé teszik a diagram adatmunkafüzetek (amelyek Aspose.Cells segítségével szerkesztett diagramadatokat tartalmaznak) olvasását és írását. **Megjegyzés** hogy a diagram adatainak ugyanúgy vagy hasonló szerkezetűen kell legyenek szervezve, mint a forrás.

Ez a C# kód egy mintaműveletet mutat be:

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

## **Munkafüzet cella beállítása diagramadat-címkeként**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.  
1. Szerezze be egy dia hivatkozását az indexe alapján.  
1. Adjon hozzá egy buborékdiagramot némi adattal.  
1. Érje el a diagram sorozatát.  
1. Állítsa be a munkafüzet cellát adatcímkeként.  
1. Mentse a prezentációt.

Ez a C# kód megmutatja, hogyan állítsuk be a munkafüzet cellát diagramadat-címkeként:

```c#
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

Ez a C# kód egy olyan műveletet mutat be, ahol az [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) tulajdonságot használják a munkalap-gyűjtemény eléréséhez:

``` csharp
using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
   IChartDataWorkbook wb =  chart.ChartData.ChartDataWorkbook;
   for (int i = 0; i < wb.Worksheets.Count; i++)
      Console.WriteLine(wb.Worksheets[i].Name);
}
```

## **Adatforrás típusának megadása**

Ez a C# kód megmutatja, hogyan adjon meg egy típust egy adatforráshoz:

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

Az Aspose.Slides nem támogatja a néhány diagramba beágyazható Excel bináris munkafüzet (.xlsb) formátumot. A `EmbeddedWorkbookType` tulajdonságot az [IChartData](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdata/) és a [WorkbookType](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/workbooktype/) felsorolással együtt használhatja a nem támogatott formátumok felismerésére és az ilyen diagramok kihagyására.

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
            // A beágyazott munkafüzet .xlsb formátumban van, amelyet nem támogatunk.
            continue;
        }

        // Itt olvassa vagy módosítsa a diagram munkafüzete adatát.
    }
}
```

## **Külső munkafüzet**

{{% alert color="primary" %}} 
Az [Aspose.Slides 19.4](https://docs.aspose.com/slides/hu/net/aspose-slides-for-net-19-4-release-notes/) verzióban bevezettük a külső munkafüzetek diagramok adatforrásaként való támogatását.
{{% /alert %}} 

### **Külső munkafüzet létrehozása**

A **`ReadWorkbookStream`** és **`SetExternalWorkbook`** metódusok használatával létrehozhat egy külső munkafüzetet a semmiből, vagy egy belső munkafüzetet külsővé tehet.

Ez a C# kód bemutatja a külső munkafüzet létrehozási folyamatát:

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

A **`SetExternalWorkbook`** metódus használatával egy külső munkafüzetet adhat a diagramhez adatforrásként. Ez a metódus használható a külső munkafüzet elérési útjának frissítésére is (ha az áthelyezésre került).

Bár a távoli helyeken vagy erőforrásokban tárolt munkafüzetek adatait nem lehet szerkeszteni, továbbra is használhatók külső adatforrásként. Ha egy relatív útvonalat adunk meg egy külső munkafüzethez, azt a rendszer automatikusan teljes útvonallá alakítja.

Ez a C# kód megmutatja, hogyan állítsunk be egy külső munkafüzetet:

```c#
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

* Ha a `ChartData` értéke `false`, csak a munkafüzet útvonala frissül – a diagram adatai nem töltődnek be, és nem frissülnek a célmunkafüzetről. Ezt a beállítást akkor használhatja, ha a célmunkafüzet nem létezik vagy nem érhető el.  
* Ha a `ChartData` értéke `true`, a diagram adatai a célmunkafüzetről frissülnek.

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **Diagram külső adatforrás munkafüzetének útvonalának lekérése**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.  
1. Szerezze be egy dia hivatkozását az indexe alapján.  
1. Hozzon létre egy objektumot a diagram alakzatához.  
1. Hozzon létre egy objektumot a forrás (`ChartDataSourceType`) típushoz, amely a diagram adatforrását jelöli.  
1. Adja meg a megfelelő feltételt a forrástípus alapján, amely megegyezik a külső munkafüzet adatforrás típusával.

Ez a C# kód bemutatja a műveletet:

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
    
    // A prezentáció mentése
    pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

### **Diagram adatainak szerkesztése**

Az adatokat külső munkafüzetekben ugyanúgy szerkesztheti, ahogy a belső munkafüzetek tartalmát módosítja. Ha egy külső munkafüzetet nem lehet betölteni, kivétel keletkezik.

Ez a C# kód a leírt folyamat megvalósítása:

```c#
using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```

### **Munkafüzet helyreállítása a diagram gyorsítótárából**

Ha egy diagram egy hiányzó vagy nem elérhető külső munkafüzetet használ, az Aspose.Slides képes rekonstruálni a diagram munkafüzetet a prezentációban tárolt gyorsítótárazott adatokból. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/) objektumot, konfigurálja annak [SpreadsheetOptions](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/spreadsheetoptions/) beállításait, és állítsa a [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hu/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) értékét `true`-ra a prezentáció megnyitása előtt.

A következő C# példa megnyit egy olyan prezentációt, amelynek diagramja egy nem elérhető külső munkafüzetre hivatkozik, és a helyreállított adatokat a [IChart.ChartData](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichart/chartdata/) és [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdata/chartdataworkbook/) segítségével érheti el:

```csharp
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

Ha a külső munkafüzet nem elérhető és a helyreállítás le van tiltva, az Aspose.Slides `InvalidOperationException` kivételt dob. Engedélyezze a helyreállítást csak akkor, ha a gyorsítótárazott diagram adatok használata elfogadható tartalék, mivel a gyorsítótár nem feltétlenül tartalmazza a prezentáció legutóbbi frissítése után a külső munkafüzetben végzett módosításokat.

## **GYIK**

**Meg tudom határozni, hogy egy adott diagram külső vagy beágyazott munkafüzethez van-e csatolva?**

Igen. A diagram rendelkezik [adatforrás típussal](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/chartdata/datasourcetype/) és egy [úttal a külső munkafüzethez](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/chartdata/externalworkbookpath/); ha a forrás egy külső munkafüzet, akkor kiolvashatja a teljes útvonalat, hogy megbizonyosodjon, egy külső fájl van-e használatban.

**Támogatottak a relatív útvonalak a külső munkafüzetekhez, és hogyan tárolódnak?**

Igen. Ha relatív útvonalat ad meg, azt a rendszer automatikusan abszolút útvonallá konvertálja. Ez a projekt hordozhatóságát megkönnyíti; azonban vegye figyelembe, hogy a prezentáció az abszolút útvonalat tárolja a PPTX fájlban.

**Használhatok hálózati erőforrásokon/megosztott helyeken lévő munkafüzeteket?**

Igen, az ilyen munkafüzetek használhatók külső adatforrásként. Azonban a távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides-ből nem támogatott – csak forrásként használhatók.

**Felülírja-e az Aspose.Slides a külső XLSX fájlt a prezentáció mentésekor?**

Nem. A prezentáció egy [hivatkozást tárol a külső fájlra](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/chartdata/externalworkbookpath/) és azt használja az adatok olvasásához. A külső fájl maga nem módosul a prezentáció mentésekor.

**Mit tegyek, ha a külső fájl jelszóval védett?**

Az Aspose.Slides nem fogad el jelszót a csatoláskor. Egy gyakori megoldás, hogy előzetesen eltávolítja a védelmet, vagy egy dekódolt másolatot készít (például az [Aspose.Cells](/cells/net/) használatával), és arra a másolatra hivatkozik.

**Több diagram hivatkozhat ugyanarra a külső munkafüzetre?**

Igen. Minden diagram saját hivatkozást tárol. Ha mindegyik ugyanarra a fájlra mutat, a fájl frissítése a következő adatbetöltéskor minden diagramon megjelenik.