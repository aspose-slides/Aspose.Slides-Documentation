---
title: Diagrammunkafüzetek kezelése prezentációkban .NET-ben
linktitle: Diagrammunkafüzet
type: docs
weight: 70
url: /hu/net/chart-workbook/
keywords:
- diagrammunkafüzet
- diagramadat
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
description: "Fedezze fel az Aspose.Slides for .NET-et: egyszerűen kezelje a diagrammunkafüzeteket PowerPoint és OpenDocument formátumokban, hogy hatékonyabbá tegye a prezentáció adatait."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhat a diagrammunkafüzetekkel az Aspose.Slides-ben. Megmutatja, hogyan olvashat és írhat diagramadatokat munkafüzet‑stream‑eken keresztül, hogyan használhatja a munkafüzetcellákat diagramadatcímkéként, hogyan férhet hozzá a munkalap‑gyűjteményekhez, és hogyan adhatja meg az adatforrás típusát a diagramértékekhez.

Emellett kitér a külső munkafüzetek diagramadat‑forrásként való használatára is. A példák bemutatják, hogyan hozhat létre és rendelhet egy külső munkafüzetet, hogyan kérdezheti le egy diagramhoz kapcsolt külső munkafüzet útvonalát, illetve hogyan szerkesztheti a diagramadatokat, ha a munkafüzet elérhető.

## **Diagramadatok olvasása és írása munkafüzetből**
Aspose.Slides biztosítja a [ReadWorkbookStream](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdata/readworkbookstream/) és a [WriteWorkbookStream](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdata/writeworkbookstream/) metódusokat, amelyek lehetővé teszik a diagramadat‑munkafüzetek (az Aspose.Cells‑szel szerkesztett diagramadatot tartalmazó) olvasását és írását. **Megjegyzés**: a diagramadatnak ugyanúgy kell felépítve lennie, vagy hasonló struktúrával kell rendelkeznie, mint a forrás.

Ez a C# kód egy mintaműveletet mutat be:

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

## **Munkafüzetcellát állítsa be diagramadatcímkeként**
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.  
1. Szerezze meg a dia hivatkozását az indexe segítségével.  
1. Adjon hozzá egy Buborék diagramot néhány adattal.  
1. Hozzáférés a diagram sorozataihoz.  
1. Állítsa be a munkafüzetcellát adatcímkeként.  
1. Mentse a prezentációt.

Ez a C# kód megmutatja, hogyan állíthat be egy munkafüzetcellát diagramadatcímkeként:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// Példányosít egy prezentáció osztályt, amely egy prezentációfájlt képvisel

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
Ez a C# kód egy olyan műveletet mutat be, amelyben a [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) tulajdonságot használják a munkalap‑gyűjtemény eléréséhez:

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

## **Adatforrás típusának meghatározása**
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

## **Nem támogatott beágyazott munkafüzetformátumok észlelése**
Az Aspose.Slides nem támogatja a néhány diagramba beágyazható Excel bináris munkafüzet (.xlsb) formátumot. A [IChartData](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdata/) `EmbeddedWorkbookType` tulajdonságát a [WorkbookType](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/workbooktype/) felsorolással együtt használhatja a nem támogatott formátumok észlelésére, és átugorhatja az ilyen diagramokat.

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
            // A beágyazott munkafüzet .xlsb formátumú, amely nem támogatott.
            continue;
        }

        // Olvassa vagy módosítsa itt a diagram munkafüzet adatait.
    }
}
```

## **Külső munkafüzet**

{{% alert color="info" %}} 
Az [Aspose.Slides 19.4](https://docs.aspose.com/slides/hu/net/aspose-slides-for-net-19-4-release-notes/)‑ben bevezettük a külső munkafüzetek diagramok adatforrásaként való támogatását. 
{{% /alert %}} 

### **Külső munkafüzet létrehozása**
A **`ReadWorkbookStream`** és a **`SetExternalWorkbook`** metódusok segítségével akár egy külső munkafüzetet hozhat létre a semmiből, akár belső munkafüzetet tehet külsővé.

Ez a C# kód bemutatja a külső munkafüzet létrehozásának folyamatát:

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
A **`SetExternalWorkbook`** metódus segítségével egy külső munkafüzetet rendelhet egy diagramhoz, mint adatforrást. Ezzel a metódussal frissítheti a külső munkafüzet útvonalát is (ha az áthelyezésre került).

Bár a távoli helyeken vagy erőforrásokon tárolt munkafüzetek adatait nem szerkesztheti közvetlenül, ilyen munkafüzetek továbbra is használhatók külső adatforrásként. Ha relatív útvonalat ad meg egy külső munkafüzethez, az automatikusan teljes úttá konvertálódik.

Ez a C# kód megmutatja, hogyan állíthat be egy külső munkafüzetet:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// A dokumentumok könyvtárának az elérési útja.
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

A `ChartData` paraméter (a `SetExternalWorkbook` metódus alatt) azt határozza meg, hogy egy Excel‑munkafüzet be lesz-e töltve vagy sem.

* Ha a `ChartData` értéke **false**, csak a munkafüzet útvonala frissül – a diagramadatok nem lesznek betöltve vagy frissítve a célmunkafüzetből. Ezt a beállítást akkor érdemes használni, ha a célmunkafüzet nem létezik vagy nem érhető el.  
* Ha a `ChartData` értéke **true**, a diagramadatok a célmunkafüzetből frissülnek.

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
1. Szerezze meg a dia hivatkozását az indexe segítségével.  
1. Hozzon létre egy objektumot a diagram alakzathoz.  
1. Hozzon létre egy objektumot a forrás (`ChartDataSourceType`) típusához, amely a diagram adatforrását képviseli.  
1. Adja meg a megfelelő feltételt a forrástípus és a külső munkafüzet adatforrás típusa közötti egyezés alapján.

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

### **Diagramadatok szerkesztése**
Külső munkafüzetek adatait ugyanúgy szerkesztheti, ahogy a belső munkafüzetek tartalmát módosítaná. Ha egy külső munkafüzet nem tölthető be, kivétel keletkezik.

Ez a C# kód a leírt folyamat megvalósítását mutatja be:

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
Ha egy diagram olyan külső munkafüzetet használ, amely hiányzik vagy nem érhető el, az Aspose.Slides a prezentációban gyorsítótárazott adatokból rekonstruálhatja a diagram munkafüzetét. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/) objektumot, konfigurálja a [SpreadsheetOptions](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/spreadsheetoptions/) beállításait, és állítsa a [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hu/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) értékét **true**‑ra, mielőtt megnyitná a prezentációt.

Az alábbi C# példával megnyitható egy olyan prezentáció, amelynek diagramja egy nem elérhető külső munkafüzetre hivatkozik, és a helyreállított adatokat a [IChart.ChartData](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichart/chartdata/) és a [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdata/chartdataworkbook/) segítségével érheti el:

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

Ha a külső munkafüzet nem érhető el, és a helyreállítás le van tiltva, az Aspose.Slides **InvalidOperationException** kivételt dob. Engedélyezze a helyreállítást csak akkor, ha a gyorsítótár‑adatok használata elfogadható visszalépés, mivel a gyorsítótár nem feltétlenül tartalmazza a külső munkafüzetben a prezentáció legutóbbi frissítése óta végzett módosításokat.

## **GYIK**

**Meg tudom határozni, hogy egy adott diagram külső vagy beágyazott munkafüzethez kapcsolódik?**

Igen. A diagram rendelkezik egy [data source type](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/chartdata/datasourcetype/) és egy [path to an external workbook](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/chartdata/externalworkbookpath/) tulajdonsággal; ha a forrás egy külső munkafüzet, leolvashatja a teljes útvonalat, hogy megbizonyosodjon arról, külső fájlt használ-e.

**Támogatottak a relatív útvonalak a külső munkafüzetekhez, és hogyan tárolódnak?**

Igen. Ha relatív útvonalat ad meg, az automatikusan átalakul abszolút úttá. Ez kényelmes a projekt hordozhatósága szempontjából; azonban vegye figyelembe, hogy a prezentáció az abszolút útvonalat tárolja a PPTX fájlban.

**Használhatok munkafüzeteket hálózati erőforrásokon/megosztott meghajtókon?**

Igen, az ilyen munkafüzetek használhatók külső adatforrásként. A távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑ből azonban nem támogatott – csak forrásként használhatók.

**Az Aspose.Slides felülírja a külső XLSX‑et a prezentáció mentésekor?**

Nem. A prezentáció egy [linket a külső fájlhoz](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/chartdata/externalworkbookpath/) tárol, és ezt használja az adatok olvasásához. A külső fájl maga nem módosul a prezentáció mentésekor.

**Mit kell tennem, ha a külső fájl jelszóval védett?**

Az Aspose.Slides nem fogad el jelszót a hivatkozáskor. Általános megoldás, hogy előre eltávolítja a védelmet, vagy egy dekódolt másolatot készít (például a [Aspose.Cells](/cells/net/) segítségével), majd arra hivatkozik.

**Több diagram hivatkozhat ugyanarra a külső munkafüzetre?**

Igen. Minden diagram a saját linkjét tárolja. Ha mindegyik ugyanarra a fájlra mutat, a fájl frissítése minden diagramnál megjelenik a következő adatbetöltéskor.