---
title: Diagram munkalap képletek alkalmazása prezentációkban .NET-ben
linktitle: Munkalap képletek
type: docs
weight: 70
url: /hu/net/chart-worksheet-formulas/
keywords:
- diagram táblázat
- diagram munkalap
- diagram képlet
- munkalap képlet
- táblázat képlet
- diagram adat munkafüzet
- képlet számítás
- preferált kultúra
- kultúra-specifikus képlet
- DBCS
- logikai állandó
- numerikus állandó
- karakterlánc állandó
- hiba állandó
- aritmetikai operátor
- összehasonlító operátor
- A1 stílus
- R1C1 stílus
- előre definiált függvény
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Excel‑stílusú képletek alkalmazása az Aspose.Slides for .NET diagram munkalapokon, értékek újraszámítása és az eredmények használata PowerPoint diagramokban."
---
## **Áttekintés**

A PowerPoint diagramok általában a forrásadataikat egy beágyazott munkalapon tárolják. Az Aspose.Slides for .NET‑ben a diagramadatok munkafüzetén keresztül érheti el ezt a munkalapot, írhat be bemeneti értékeket, hozzárendelhet képleteket a cellákhoz, kiszámíthatja a támogatott képleteket, és a kiszámított cellákat diagramadatként használhatja.

Ez a cikk bemutatja a teljes képlet‑munkafolyamatot: diagram létrehozása, a munkalap feltöltése, A1‑ vagy R1C1‑stílusú képletek hozzárendelése, újraszámításuk, a kiszámított értékek beolvasása, ezeknek a celláknak a csatlakoztatása egy diagram sorozathoz, és a prezentáció mentése. Emellett ismerteti a támogatott képletszintaxist, a beépített függvények részhalmazát, a gyorsítótárazott értékeket, a nem támogatott képleteket és a táblázat‑specifikus hibákat.

## **Diagram munkalapok és képletek**

A diagram munkalapja tartalmazza a kategóriákat, sorozatneveket és az értékeket, amelyeket a diagram használ. PowerPoint‑ban a munkalapot a diagramadat‑szerkesztő megnyitásával tekintheti meg:

![PowerPoint diagram a beágyazott munkalappal nyitva, a kategória‑ és sorozatadatokat mutatva](chart-worksheet-formulas_1.png)

Az Aspose.Slides‑ben a munkalap a [diagram adatainak munkafüzete](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdataworkbook/) révén érhető el. A1‑stílusú képletekhez használja a [Formula](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatacell/formula/) tulajdonságot, R1C1‑stílusú képletekhez a [R1C1Formula](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatacell/r1c1formula/) tulajdonságot. A bemeneti cellák vagy képletek módosítása után hívja a [CalculateFormulas](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) metódust a támogatott képletek újraszámításához és a megfelelő cellaértékek frissítéséhez.

Egy kiszámított cella továbbra is a [Value](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatacell/value/) tulajdonságon keresztül adja vissza az eredményt. Ez fontos, ha a kódban meg kell vizsgálnia egy képlet eredményét, vagy a cellát diagram adatpontként kívánja használni.

## **Diagram létrehozása és a munkalap képleteinek kiszámítása**

Az alábbi példa egy teljes munkafolyamatot mutat be. Létrehoz egy csoportosított oszlopdiagramot, törli a mintaadatokat, beírja a negyedéves bevétel‑ és kiadási értékeket, képletekkel számolja ki a profitot, kiolvassa az eredményeket, a kiszámított cellákat diagramértékekként használja, és elmenti a prezentációt.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
workbook.Clear(worksheetIndex);

var category1 = workbook.GetCell(worksheetIndex, "A2", "Q1");
var category2 = workbook.GetCell(worksheetIndex, "A3", "Q2");
var category3 = workbook.GetCell(worksheetIndex, "A4", "Q3");

workbook.GetCell(worksheetIndex, "B1", "Revenue");
workbook.GetCell(worksheetIndex, "C1", "Expenses");
workbook.GetCell(worksheetIndex, "D1", "Profit");

workbook.GetCell(worksheetIndex, "B2").Value = 120.0;
workbook.GetCell(worksheetIndex, "C2").Value = 80.0;
workbook.GetCell(worksheetIndex, "B3").Value = 150.0;
workbook.GetCell(worksheetIndex, "C3").Value = 95.0;
workbook.GetCell(worksheetIndex, "B4").Value = 135.0;
workbook.GetCell(worksheetIndex, "C4").Value = 110.0;

var profit1 = workbook.GetCell(worksheetIndex, "D2");
var profit2 = workbook.GetCell(worksheetIndex, "D3");
var profit3 = workbook.GetCell(worksheetIndex, "D4");

profit1.Formula = "B2-C2";
profit2.Formula = "B3-C3";
profit3.Formula = "B4-C4";

workbook.CalculateFormulas();

var q1Profit = Convert.ToDouble(profit1.Value); // 40
var q2Profit = Convert.ToDouble(profit2.Value); // 55
var q3Profit = Convert.ToDouble(profit3.Value); // 25

Console.WriteLine($"Q1 profit: {q1Profit}");
Console.WriteLine($"Q2 profit: {q2Profit}");
Console.WriteLine($"Q3 profit: {q3Profit}");

chart.ChartData.Categories.Add(category1);
chart.ChartData.Categories.Add(category2);
chart.ChartData.Categories.Add(category3);

var profitSeries = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, "D1"), chart.Type);
profitSeries.DataPoints.AddDataPointForBarSeries(profit1);
profitSeries.DataPoints.AddDataPointForBarSeries(profit2);
profitSeries.DataPoints.AddDataPointForBarSeries(profit3);
profitSeries.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("chart-formulas.pptx", SaveFormat.Pptx);
```

A diagram adatpontjai a `D2:D4` tartományra hivatkoznak, így a diagram a kiszámított profitértékeket használja. Ebben a munkafolyamatban nincs külön diagram‑frissítési hívás: először számolja újra a munkafüzetet, majd használja vagy mentse a diagramadatokat, amelyek a kiszámított cellákra mutatnak.

## **A1‑stílusú képletek használata**

Az A1 jelölés betűkkel azonosítja az oszlopokat, számokkal a sorokat. A1‑stílusú kifejezéseket a [IChartDataCell.Formula](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatacell/formula/) segítségével adhatja meg.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "C3").Value = 10;
workbook.GetCell(0, "F2").Value = 2;
workbook.GetCell(0, "G2").Value = 3;
workbook.GetCell(0, "H2").Value = 4;

var cell = workbook.GetCell(0, "A2");
cell.Formula = "C3+SUM(F2:H2)";

workbook.CalculateFormulas();

var value = cell.Value; // 19
```

A leggyakoribb A1‑hivatkozási formák:

| Hivatkozás | Relatív | Abszolút | Vegyes |
|---|---|---|---|
| Cella | `A2` | `$A$2` | `A$2`, `$A2` |
| Sor | `2:2` | `$2:$2` | — |
| Oszlop | `A:A` | `$A:$A` | — |
| Tartomány | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

A relatív hivatkozások megváltozhatnak, ha egy képletet mozgat vagy másol egy táblázatkezelő alkalmazásban. Az abszolút hivatkozások mindkét koordinátát rögzítik, míg a vegyes hivatkozások csak egy sort vagy egy oszlopot rögzítenek.

## **R1C1‑stílusú képletek használata**

Az R1C1 jelölés numerikusan azonosítja a sorokat és oszlopokat. A relatív hivatkozások négyzetes zárójelben megadott eltolásokat használnak. Ezt a szintaxist a [IChartDataCell.R1C1Formula](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatacell/r1c1formula/) segítségével adhatja meg.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "B2").Value = 12;
workbook.GetCell(0, "C2").Value = 5;

var cell = workbook.GetCell(0, "D2");
cell.R1C1Formula = "RC[-2]-RC[-1]";

workbook.CalculateFormulas();

var value = cell.Value; // 7
```

A leggyakoribb R1C1‑hivatkozási formák:

| Hivatkozás | Relatív | Abszolút | Vegyes |
|---|---|---|---|
| Cella | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Sor | `R[2]` | `R2` | — |
| Oszlop | `C[3]` | `C3` | — |
| Tartomány | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Például a `D2` cellában az `RC[-2]` azt jelenti, hogy a ugyanabban a sorban két oszloppal balra lévő cellára (`B2`) hivatkozik.

## **Képlet‑állandók és operátorok**

A beépített képletelemző logikai értékeket, numerikus literálokat, karakterláncokat, táblázat‑hibákat, aritmetikai operátorokat és összehasonlító operátorokat támogat.

### **Állandók és literálok**

| Típus | Példák | Megjegyzés |
|---|---|---|
| Logikai | `TRUE`, `FALSE` | Közvetlenül használható logikai kifejezésekben, például `A2=TRUE`. |
| Numerikus | `1`, `0.5`, `.3`, `1E-2` | A közönséges és a tudományos jelölés egyaránt támogatott. |
| Karakterlánc | `"abc"`, `"2/3/2020 12:00"` | A szöveges literálokat dupla idézőjelek közé kell tenni a képletben. |
| Hiba‑eredmény | `#DIV/0!`, `#N/A`, `#REF!` | Egy érvényes képlet visszaadhat táblázat‑hibát a normál eredmény helyett. |

Ez a példa több állandótípust használ:

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "A2").Value = false;
workbook.GetCell(0, "B2").Formula = "A2=TRUE";
workbook.GetCell(0, "C2").Formula = "1+0.5";
workbook.GetCell(0, "D2").Formula = ".3*1E-2";
workbook.GetCell(0, "E2").Formula = "\"abc\"";
workbook.GetCell(0, "F2").Formula = "2/0";

workbook.CalculateFormulas();

var logicalValue = workbook.GetCell(0, "B2").Value; // Hamis
var numericValue = workbook.GetCell(0, "C2").Value; // 1.5
var scientificValue = workbook.GetCell(0, "D2").Value; // 0.003
var stringValue = workbook.GetCell(0, "E2").Value; // abc
var errorValue = workbook.GetCell(0, "F2").Value; // #DIV/0!
```

### **Aritmetikai operátorok**

| Operátor | Jelentés | Példa |
|---|---|---|
| `+` | Összeadás vagy egyjegyű plusz | `2+3` |
| `-` | Kivonás vagy negáció | `2-3`, `-3` |
| `*` | Szorzás | `2*3` |
| `/` | Osztás | `2/3` |
| `%` | Százalék | `30%` |
| `^` | Hatványozás | `2^3` |

Használjon zárójeleket a kiértékelési sorrend egyértelművé tételéhez, például `(A2+B2)*C2`.

### **Összehasonlító operátorok**

Az összehasonlító kifejezések logikai értéket adnak vissza.

| Operátor | Jelentés | Példa |
|---|---|---|
| `=` | Egyenlő | `A2=3` |
| `<>` | Nem egyenlő | `A2<>3` |
| `>` | Nagyobb mint | `A2>3` |
| `>=` | Nagyobb vagy egyenlő | `A2>=3` |
| `<` | Kisebb mint | `A2<3` |
| `<=` | Kisebb vagy egyenlő | `A2<=3` |

## **Támogatott előre definiált függvények**

Az Aspose.Slides beépített képletelemzője diagrammunkalapokhoz készült, de nem egy teljes Excel‑számítási motor. A dokumentált függvénykészlet a következőkre korlátozódik. Ne feltételezze, hogy tetszőleges Excel‑függvény újraszámítható a [CalculateFormulas](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) metódussal.

| Függvény | Cél vagy támogatott forma | Példa |
|---|---|---|
| `ABS` | Abszolút érték | `ABS(A2)` |
| `AVERAGE` | Aritmetikai közép | `AVERAGE(B2:B5)` |
| `CEILING` | Felső kerekítés egy többszörösre | `CEILING(A2,5)` |
| `CHOOSE` | Érték kiválasztása index alapján | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Szövegek összefűzése | `CONCAT(A2,B2)` |
| `CONCATENATE` | Szövegek összefűzése | `CONCATENATE(A2," ",B2)` |
| `DATE` | Dátumérték létrehozása a 1900‑as dátumrendszerrel | `DATE(2026,8,19)` |
| `DAYS` | Napok száma két dátum között | `DAYS(B2,A2)` |
| `FIND` | Egy szövegérték keresése egy másikban | `FIND("-",A2)` |
| `FINDB` | Byte‑orientált szöveges keresés | `FINDB("a",A2)` |
| `IF` | Feltételes eredmény | `IF(A2>0,A2,0)` |
| `INDEX` | Hivatkozási forma | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektoralapú forma | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektoralapú forma | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximum érték | `MAX(B2:B5)` |
| `SUM` | Összeg | `SUM(B2:B5)` |
| `VLOOKUP` | Függőleges keresés | `VLOOKUP(A2,B2:D10,3,FALSE)` |

A táblázatban szereplő korlátozások jelentősek: az `INDEX` dokumentált hivatkozási forma, míg a `LOOKUP` és `MATCH` vektoralapú formában szerepel. A `DATE` a 1900‑as dátumrendszert használja. A felsoroltakon kívül szereplő funkciókat tekintse az Aspose.Slides képletelemzője által nem támogatottnak, hacsak külön nincsenek dokumentálva.

## **Képletek számítása preferált kultúrával**

Bizonyos munkafüzet‑függvények a szöveget kultúra‑specifikus szabályok szerint értelmezik. Ez különösen fontos a kettős‑bájtos karakterkészletet (DBCS) használó nyelvekhez készült függvényeknél. Az ilyen képletek helyes számításához hozza létre a [LoadOptions](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/) objektumot, állítsa be a [ISpreadsheetOptions.PreferredCulture](https://reference.aspose.com/slides/hu/net/aspose.slides/ispreadsheetoptions/preferredculture/) értékét a [LoadOptions.SpreadsheetOptions](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/spreadsheetoptions/) segítségével, majd töltse be a prezentációt.

Az alábbi példa a japán kultúrát választja, a konfigurált betöltési opciókkal megnyit egy prezentációt, és minden diagram munkafüzetre meghívja a [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) metódust:

```csharp
using System.Globalization;
using Aspose.Slides;
using Aspose.Slides.Charts;

var loadOptions = new LoadOptions
{
    SpreadsheetOptions = new SpreadsheetOptions
    {
        PreferredCulture = CultureInfo.GetCultureInfo("ja-JP")
    }
};

using var presentation = new Presentation("presentation.pptx", loadOptions);

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IChart chart)
        {
            chart.ChartData.ChartDataWorkbook.CalculateFormulas();
        }
    }
}
```

A preferált kultúra a prezentáció betöltési konfigurációjának része, ezért a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) példány létrehozása előtt adja meg. A munkafüzet képletei által elvárt kultúrát használja; például a japán DBCS számítási szabályoknak megfelelő képletekhez `ja-JP` legyen a beállítás.

## **Újraszámítás és gyorsítótárazott értékek**

A táblázatfájlok általában tárolják a képletet és az utolsó kiszámított értékét is. Az Aspose.Slides ezért a [IChartDataCell.Value](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatacell/value/) tulajdonságból kiolvashat egy gyorsítótárazott értéket, ha a prezentáció betöltését követően a releváns diagramadatok nem változtak.

A bemeneti cellák vagy képletek módosítása után ne támaszkodjon egy régi gyorsítótárazott eredményre. Hívja a [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) metódust a kiszámított értékek kiolvasása vagy a diagramadatok mentése előtt, ha azok függnek ezektől.

A támogatott halmazon kívüli képletek esetén az Aspose.Slides előfordulhat, hogy nem tudja elemezni a képletet vagy annak függőségeit. Ha a munkafüzetet módosították, az előző gyorsítótárazott érték már nem tekinthető megbízhatónak. Ilyenkor egy nem támogatott adatú cella értékének olvasása a [CellUnsupportedDataException](https://reference.aspose.com/slides/hu/net/aspose.slides.spreadsheet/cellunsupporteddataexception/) kivételt váltja ki.

Ha diagramja olyan Excel‑függvényeket használ, amelyeket az Aspose.Slides nem értékel ki, számítsa ki a képleteket egy olyan táblázat‑motorral, amely támogatja őket, majd írja vissza a kapott értékeket a diagram munkafüzetébe. Ne helyettesítse a nem támogatott képleteket tippelt értékekkel.

## **Képlet hibáinak kezelése**

Két különböző problématípust kell megkülönböztetni.

Egy képlet lehet érvényes, de táblázat‑hibát eredményez, például `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` vagy `#VALUE!`. Ebben az esetben a hiba‑token egy cella‑eredmény, és a `Value`‑on keresztül érhető vissza.

Egy képlet a feldolgozás, hivatkozás, függőség vagy a támogatott‑adat szintjén is hibára fut. Az Aspose.Slides erre a helyzetre táblázat‑specifikus kivételeket biztosít: [CellInvalidFormulaException](https://reference.aspose.com/slides/hu/net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/hu/net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/hu/net/aspose.slides.spreadsheet/cellcircularreferenceexception/) és [CellUnsupportedDataException](https://reference.aspose.com/slides/hu/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Ha a képletek sablonokból vagy felhasználói bemenetből származnak, kezelje ezeket a kivételeket az újraszámítás és az értékhozzáférés körül:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Spreadsheet;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;
var cell = workbook.GetCell(0, "A2");
cell.Formula = "SUM(B2:B5)";

try
{
    workbook.CalculateFormulas();
    Console.WriteLine(cell.Value);
}
catch (CellInvalidFormulaException ex)
{
    Console.Error.WriteLine($"Invalid formula: {ex.Message}");
}
catch (CellInvalidReferenceException ex)
{
    Console.Error.WriteLine($"Invalid cell reference: {ex.Message}");
}
catch (CellCircularReferenceException ex)
{
    Console.Error.WriteLine($"Circular reference: {ex.Message}");
}
catch (CellUnsupportedDataException ex)
{
    Console.Error.WriteLine($"Unsupported spreadsheet data: {ex.Message}");
}
```

## **Gyakorlati korlátozások**

A diagram munkalapok képlet‑támogatása egy meghatározott részhalmazra vonatkozik, nem a teljes Excel kompatibilitásra. Tartsa szem előtt ezeket a korlátozásokat a jelentéskészítési munkafolyamat tervezésekor:

- Csak a dokumentált állandókat, operátorokat, hivatkozásokat és függvényeket használja, ha az Aspose.Slides‑nek kell újraszámítania a képleteket.
- Újraszámítás után módosítsa azokat a cellákat, amelyektől a képlet eredménye függ.
- A betöltött prezentációkból származó gyorsítótárazott értékeket tekintse pillanatfelvételnek, nem pedig az szerkesztés utáni újraszámítás helyettesítésének.
- Tesztelje a meglévő sablonok képleteit, mielőtt a kiszámított értékekre támaszkodna, különösen, ha olyan függvényeket tartalmaznak, amelyek nincsenek a dokumentált listán.
- A teljes táblázat‑számítási motorhoz szükséges képleteket végezze el külsőleg, majd frissítse a diagram munkafüzetét a kapott értékekkel.

## **GYIK**

**Mi a különbség a `Formula` és az `R1C1Formula` között?**

A [Formula](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatacell/formula/) A1‑stílusú kifejezést tárol, például `B2-C2`. Az [R1C1Formula](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatacell/r1c1formula/) R1C1‑stílusú kifejezést tárol, például `RC[-2]-RC[-1]`. A legmegfelelőbb jelölést használja attól függően, hogyan generál vagy másol képleteket.

**A számítás után a cellát vagy annak értékét kell beolvasnom?**

Az [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdataworkbook/getcell/) egy `IChartDataCell`‑et ad vissza. A kiszámított eredményhez a cella [Value](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatacell/value/) tulajdonságát kell kiolvasni az újraszámítás után.

**Mikor kell meghívni a `CalculateFormulas`‑t?**

Hívja a [CalculateFormulas](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) metódust a bemeneti értékek vagy képletek módosítása után, mielőtt a kiszámított eredményektől függne. Ez frissíti a beépített értékelő által támogatott képletek értékeit.

**Az Aspose.Slides minden Excel‑függvényt támogat?**

Nem. A beépített értékelő egy dokumentált függvényrészhalmazt támogat. A részhalmazon kívüli függvények nem számíthatók újra helyesen. Ha teljes Excel‑képlet kompatibilitásra van szükség, végezze a számítást egy megfelelő táblázat‑motorral, majd írja a végső értékeket a diagram munkafüzetébe.

**Mi történik, ha egy betöltött prezentáció nem támogatott képletet tartalmaz?**

Ha a diagram adatai nem változtak, a munkafüzet továbbra is tartalmazhat egy korábban kiszámított gyorsítótárazott értéket. A kapcsolódó adatok módosítása után ez a gyorsítótárazott érték már nem lehet érvényes. Egy olyan cella elérése, amelynek képletét nem tudja kezelni a rendszer, a [CellUnsupportedDataException](https://reference.aspose.com/slides/hu/net/aspose.slides.spreadsheet/cellunsupporteddataexception/) kivételt váltja ki.

**Ugyanazok a képlet‑hibák, mint a .NET‑kivétel?**

Nem. A `#DIV/0!` típusú eredmény egy táblázat‑érték, amely egy érvényes számításból származik. Az olyan kivételek, mint a [CellInvalidFormulaException](https://reference.aspose.com/slides/hu/net/aspose.slides.spreadsheet/cellinvalidformulaexception/) vagy a [CellCircularReferenceException](https://reference.aspose.com/slides/hu/net/aspose.slides.spreadsheet/cellcircularreferenceexception/) azt jelzik, hogy a képletet nem lehet normál módon feldolgozni.

**Frissül automatikusan a diagram, ha egy képlet‑cellát módosítanak?**

Egy diagram sorozata hivatkozhat munkafüzet‑cellákra. Először számolja újra a munkafüzetet, majd mentse vagy renderelje a prezentációt. Ha a diagram adatpontjai a kiszámított cellákra mutatnak, a diagram a frissített cellaértékeket használja; ehhez nincs külön diagram‑frissítési metódus szükséges.

**Használhatók külső Excel‑munkafüzetek a diagramoknál?**

Igen, a diagramadatok konfigurálhatók külső munkafüzettel a diagramadat‑API‑n keresztül. Azonban ebben a cikkben leírt képlet‑számítási munkafolyamat a diagram munkafüzetére és az Aspose.Slides által kiértékelt képlet‑részhalmazra vonatkozik. Ne feltételezze, hogy a [CalculateFormulas](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) teljes újraszámítást biztosít egy tetszőleges képletre egy külső XLSX‑fájlban.

**Használhatók olyan képletek, amelyek más munkalapra vagy munkafüzetre hivatkoznak?**

Az Excel‑stílusú hivatkozások előfordulhatnak a diagram munkafüzetben, de a képletelemzés korlátozott a támogatott elemző és függvénykészlet által. Ha egy kereszt‑lap vagy külső hivatkozás elengedhetetlen, ellenőrizze a pontos képletet a használt Aspose.Slides‑verzióval. Széles Excel‑hivatkozási kompatibilitást igénylő munkafolyamatok esetén számítsa ki a munkafüzetet külsőleg, majd írja vissza a feloldott értékeket a diagram adataiba.

**A képletsoroknak kell-e `=` jellel kezdődniük?**

Az Aspose.Slides API példák a `B2-C2` vagy `SUM(B2:B5)` kifejezéseket a vezető `=` nélkül adják meg. Ezzel a formával a generált képletek összhangban maradnak a dokumentált API‑példákkal.