---
title: Diagram munkalap képletek alkalmazása .NET prezentációkban
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
- logikai konstans
- numerikus konstans
- karakterlánc konstans
- hiba konstans
- aritmetikai operátor
- összehasonlító operátor
- A1-stílus
- R1C1-stílus
- előre definiált függvény
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Alkalmazza az Excel-stílusú képleteket az Aspose.Slides for .NET diagram munkalapokon, újraszámolja az értékeket, és használja az eredményeket a PowerPoint diagramokban."
---
## **Áttekintés**

A PowerPoint diagramok általában a forrásadataikat egy beágyazott munkalapon tárolják. Az Aspose.Slides for .NET segítségével a diagram adatkönyvtárán keresztül érheti el azt a munkalapot, írhat be bemeneti értékeket, képleteket rendelhet cellákhoz, kiszámíthatja a támogatott képleteket, és a kiszámított cellákat diagramadatként használhatja.

Ez a cikk bemutatja a teljes képlet‑munkafolyamatot: diagram létrehozása, a munkalap feltöltése, A1‑stílusú vagy R1C1‑stílusú képletek hozzárendelése, újraszámítása, a kiszámított értékek beolvasása, a cellák egy diagram sorozathoz kapcsolása, és a prezentáció mentése. Emellett ismerteti a támogatott képletszintaxist, a beépített függvény‑részhalmazt, a gyorsítótárazott értékeket, a nem támogatott képleteket és a táblázat‑specifikus hibákat.

## **Diagram munkalapok és képletek**

Egy diagram munkalapja tartalmazza a diagram által használt kategóriákat, sorozatneveket és értékeket. PowerPointban a munkalapot megtekintheti a diagram adat-szerkesztő megnyitásával:

![PowerPoint diagram a beágyazott munkalappal nyitva, kategória- és sorozatadatokat mutat](chart-worksheet-formulas_1.png)

Az Aspose.Slidesben a munkalapot a [chart data workbook](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdataworkbook/) teszi elérhetővé. A1‑stílusú képletekhez a [Formula](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatacell/formula/) tulajdonságot, R1C1‑stílusú képletekhez a [R1C1Formula](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatacell/r1c1formula/) tulajdonságot használja. A bemeneti cellák vagy képletek módosítása után hívja a [CalculateFormulas](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) metódust a támogatott képletek újraszámításához és a megfelelő cellaértékek frissítéséhez.

Egy kiszámított cella továbbra is a [Value](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatacell/value/) tulajdonságon keresztül adja vissza az eredményt. Ez akkor fontos, ha a kódban a képlet eredményét kell megvizsgálnia, vagy a cellát diagramadat‑pontként szeretné használni.

## **Diagram létrehozása és a munkalap képleteinek kiszámítása**

Az alábbi példa egy teljes munkafolyamatot mutat be. Létrehoz egy klaszter oszlopdiagramot, törli a mintaadatokat, beírja a negyedéves bevétel‑ és kiadás‑értékeket, képletekkel kiszámítja a profitot, beolvassa az eredményeket, a kiszámított cellákat diagramértékként használja, és menti a prezentációt.

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

A diagram adatpontjai a `D2:D4` tartományra hivatkoznak, így a diagram a kiszámított profitértékeket használja. Ebben a munkafolyamatban nincs külön diagram‑frissítési hívás: előbb számolja újra a munkafüzetet, majd használja vagy mentse a kiszámított cellákra mutató diagramadatokat.

## **A1‑stílusú képletek használata**

Az A1 jelölés a oszlopokat betűvel, a sorokat számmal azonosítja. A [IChartDataCell.Formula](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatacell/formula/) segítségével adjon meg A1‑stílusú kifejezéseket.

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

Az általános A1 referenciaformák:

| Referencia | Relatív | Abszolút | Vegyes |
|---|---|---|---|
| Cella | `A2` | `$A$2` | `A$2`, `$A2` |
| Sor | `2:2` | `$2:$2` | — |
| Oszlop | `A:A` | `$A:$A` | — |
| Tartomány | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

A relatív hivatkozások a képlet egy táblázatalkalmazásban történő áthelyezésekor vagy másolásakor módosulhatnak. Az abszolút hivatkozások mindkét koordinátát rögzítik, míg a vegyes hivatkozások csak egy sort vagy egy oszlopot rögzítenek.

## **R1C1‑stílusú képletek használata**

Az R1C1 jelölés mind a sorokat, mind az oszlopokat számszerűen határozza meg. A relatív hivatkozások a szögletes zárójelben megadott eltolások. A [IChartDataCell.R1C1Formula](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatacell/r1c1formula/) segítségével adja meg ezt a szintaxist.

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

Az általános R1C1 referenciaformák:

| Referencia | Relatív | Abszolút | Vegyes |
|---|---|---|---|
| Cella | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Sor | `R[2]` | `R2` | — |
| Oszlop | `C[3]` | `C3` | — |
| Tartomány | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Például a `D2` cellában az `RC[-2]` azt jelenti, hogy ugyanabban a sorban két oszloppal balra lévő cella (`B2`).

## **Képletkonstansok és operátorok**

A beépített képletszámoló támogatja a logikai értékeket, numerikus literálokat, karakterláncokat, táblázat‑hibákat, aritmetikai operátorokat és összehasonlító operátorokat.

### **Konstansok és literálok**

| Típus | Példák | Megjegyzés |
|---|---|---|
| Logikai | `TRUE`, `FALSE` | Közvetlenül használható logikai kifejezésekben, pl. `A2=TRUE`. |
| Numerikus | `1`, `0.5`, `.3`, `1E-2` | A közönséges és a tudományos jelölés is támogatott. |
| Karakterlánc | `"abc"`, `"2/3/2020 12:00"` | A szövegliterálokat dupla idézőjelbe kell tenni a képleten belül. |
| Hiba eredmény | `#DIV/0!`, `#N/A`, `#REF!` | Érvényes képlet a táblázathiba‑értékkel is értékelhető a normál eredmény helyett. |

Ez a példa több konstans típust használ:

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
| `+` | Összeadás vagy egyes (+) | `2+3` |
| `-` | Kivonás vagy negatív | `2-3`, `-3` |
| `*` | Szorzás | `2*3` |
| `/` | Osztás | `2/3` |
| `%` | Százalék | `30%` |
| `^` | Hatványozás | `2^3` |

Használjon zárójeleket a kiértékelési sorrend egyértelművé tételéhez, pl. `(A2+B2)*C2`.

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

Az Aspose.Slides beépített képletszámítója diagrammunkalapokra van optimalizálva, de nem egy teljes Excel‑számítómotor. Az itt dokumentált függvénykészlet az alább felsorolt függvényekre korlátozódik. Ne feltételezze, hogy egy tetszőleges Excel‑függvény újraszámítható a [CalculateFormulas](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) metódussal.

| Függvény | Cél vagy támogatott forma | Példa |
|---|---|---|
| `ABS` | Abszolút érték | `ABS(A2)` |
| `AVERAGE` | Mértani átlag | `AVERAGE(B2:B5)` |
| `CEILING` | Szám felfelé kerekítése többszörösre | `CEILING(A2,5)` |
| `CHOOSE` | Érték kiválasztása index szerint | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Szövegek összefűzése | `CONCAT(A2,B2)` |
| `CONCATENATE` | Szövegek összefűzése | `CONCATENATE(A2," ",B2)` |
| `DATE` | Dátumérték létrehozása 1900‑as dátumrendszerrel | `DATE(2026,8,19)` |
| `DAYS` | Napok számának visszaadása dátumok között | `DAYS(B2,A2)` |
| `FIND` | Szövegrész keresése egy másikban | `FIND("-",A2)` |
| `FINDB` | Bájtorientált szövegkeresés | `FINDB("a",A2)` |
| `IF` | Feltételes eredmény | `IF(A2>0,A2,0)` |
| `INDEX` | Referencia forma | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektor forma | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektor forma | `MATCH(A2,B2:B5,0)` |
| `MAX` | Legnagyobb érték | `MAX(B2:B5)` |
| `SUM` | Értékek összege | `SUM(B2:B5)` |
| `VLOOKUP` | Függőleges keresés | `VLOOKUP(A2,B2:D10,3,FALSE)` |

A táblázatban szereplő korlátozások jelentősek: az `INDEX` referencia formában dokumentált, míg a `LOOKUP` és a `MATCH` vektor formában szerepel. A `DATE` a 1900‑as dátumrendszert használja. Az itt nem felsorolt funkciókat és szolgáltatásokat az Aspose.Slides képletszámítója nem támogatja, hacsak külön nincsenek dokumentálva.

## **Újraszámítás és gyorsítótárazott értékek**

A táblázatfájlok gyakran tárolják egyszerre a képletet és az utolsó kiszámított értéket. Az Aspose.Slides ezért képes a [IChartDataCell.Value](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatacell/value/) gyorsítótárazott értékét beolvasni, amikor egy prezentációt betöltenek, és a kapcsolódó diagramadatok nem változtak.

A bemeneti cellák vagy képletek módosítása után ne támaszkodjon egy elavult gyorsítótárazott eredményre. Hívja a [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) metódust a kiszámított értékek beolvasása vagy a diagramadatok mentése előtt, ha azok a képletektől függenek.

A támogatott halmazon kívüli képletek esetén az Aspose.Slides esetleg nem képes a képlet elemzésére vagy függőségeinek meghatározására. Ha a munkafüzet módosult, az előző gyorsítótárazott érték már nem tekinthető megbízhatónak. Ilyen helyzetben egy nem támogatott adatú cella értékének beolvasása [CellUnsupportedDataException](https://reference.aspose.com/slides/hu/net/aspose.slides.spreadsheet/cellunsupporteddataexception/)-t vált ki.

Ha diagramja olyan Excel‑függvényeket használ, amelyeket az Aspose.Slides nem képes kiértékelni, számolja újra ezeket a képleteket egy olyan táblázat‑motorral, amely támogatja őket, majd írja vissza az eredményeket a diagram munkafüzetébe. Ne helyettesítse a nem támogatott képleteket kitalált értékekkel.

## **Képlethibák kezelése**

Kétféle problémát kell megkülönböztetni.

Egy képlet érvényes lehet, de táblázat‑hibát eredményez, például `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` vagy `#VALUE!`. Ilyenkor a hiba token a cella eredménye, és a `Value`‑on keresztül visszaadható.

Egy képlet a feldolgozás, referencia, függőség vagy a támogatott adat‑szint szintjén is hibát jelezhet. Az Aspose.Slides erre a forgatókönyvre táblázat‑specifikus kivételeket biztosít: [CellInvalidFormulaException](https://reference.aspose.com/slides/hu/net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/hu/net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/hu/net/aspose.slides.spreadsheet/cellcircularreferenceexception/) és [CellUnsupportedDataException](https://reference.aspose.com/slides/hu/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Ha a képletek sablonokból vagy felhasználói bemenetből származnak, kezelje ezeket a kivételeket az újraszámítás és az értékelérés körül:

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

## **Gyakorlati korlátok**

A diagram munkalapok képlet‑támogatása egy meghatározott, a teljes Excel‑kompatibilitást nem meghaladó számítási részhalmazra épül. Tartsa szem előtt ezeket a korlátozásokat a jelentéskészítési folyamat tervezésekor:

- Használja csak a dokumentált konstansokat, operátorokat, hivatkozásokat és függvényeket, ha azt szeretné, hogy az Aspose.Slides újraszámolja a képleteket.
- Számolja újra a képleteket a cellák módosítása után, amelyektől a képlet eredménye függ.
- Tekintse a betöltött prezentációkból származó gyorsítótárazott értékeket pillanatfelvételeknek, ne helyettesítőnek a szerkesztés utáni újraszámításra.
- Tesztelje a meglévő sablonok képleteit, mielőtt a kiszámított értékekre támaszkodna, különösen, ha a dokumentált listán kívüli függvényeket tartalmaznak.
- A teljes táblázat‑számítási motorra igénylő képletek esetén számolja ki őket külsőleg, majd frissítse a diagram munkafüzetét a kapott értékekkel.

## **GYIK**

**Mi a különbség a `Formula` és az `R1C1Formula` között?**

[Formula](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatacell/formula/) egy A1‑stílusú kifejezést tárol, például `B2-C2`. [R1C1Formula](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatacell/r1c1formula/) egy R1C1‑stílusú kifejezést tárol, például `RC[-2]-RC[-1]`. Használja azt a jelölést, amelyik a legjobban illeszkedik a képletek generálásához vagy másolásához.

**A számítás után a cellát vagy a cella értékét kell beolvasnom?**

[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdataworkbook/getcell/) egy `IChartDataCell`‑et ad vissza. A kiszámított eredményhez a cella [Value](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatacell/value/) tulajdonságát kell beolvasni az újraszámítás után.

**Mikor kell meghívni a `CalculateFormulas`‑t?**

Hívja a [CalculateFormulas](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) metódust a bemeneti értékek vagy képletek módosítása után, és még az előtt, hogy a kiszámított eredményeket felhasználná. Ez frissíti a beépített kiértékelő által támogatott képletek értékeit.

**Támogatja az Aspose.Slides az összes Excel‑függvényt?**

Nem. A beépített kiértékelő csak egy dokumentált függvény‑részhalmazt támogat. A dokumentált halmazon kívüli függvényeket ne feltételezzék, hogy helyesen újraszámíthatók. Ha teljes Excel‑képlet‑kompatibilitásra van szükség, végezze el a számítást egy megfelelő táblázat‑motorral, és írja vissza a végső értékeket a diagram munkafüzetébe.

**Mi történik, ha egy betöltött prezentáció nem támogatott képletet tartalmaz?**

Ha a diagram adatai nem változtak, a munkafüzet még tartalmazhat egy korábban kiszámított gyorsítótárazott értéket. A kapcsolódó adatok módosítása után ez az érték már nem lehet érvényes. Egy olyan cella elérése, amelynek képletét nem lehet kezelni, [CellUnsupportedDataException](https://reference.aspose.com/slides/hu/net/aspose.slides.spreadsheet/cellunsupporteddataexception/)-t vált ki.

**Ugyanazok-e a képlethiba‑értékek és a .NET‑kivétel?**

Nem. Az olyan eredmény, mint a `#DIV/0!`, egy táblázat‑érték, amely egy érvényes számításból származik. A [CellInvalidFormulaException](https://reference.aspose.com/slides/hu/net/aspose.slides.spreadsheet/cellinvalidformulaexception/) vagy a [CellCircularReferenceException](https://reference.aspose.com/slides/hu/net/aspose.slides.spreadsheet/cellcircularreferenceexception/) kivételek azt jelzik, hogy a képletet nem lehet normálisan feldolgozni.

**A diagram automatikusan frissül, ha egy képlet‑cellát módosítanak?**

Egy diagram sorozata hivatkozhat a munkafüzet celláira. Előbb számolja újra a munkafüzetet, majd mentse vagy renderelje a prezentációt. Ha a diagram adatpontjai a kiszámított cellákra mutatnak, a diagram a frissített cellaértékeket használja; nincs külön diagram‑frissítési metódus ebben a munkafolyamatban.

**Használhatók külső Excel‑munkafüzetek a diagramokhoz?**

Igen, a diagram adatokat konfigurálhatja úgy, hogy külső munkafüzetet használjon a diagram adat‑API‑val. Azonban ebben a cikkben leírt képlet‑számítási munkafolyamat a diagram adat‑munkafüzetre és az Aspose.Slides által kiértékelt képlet‑részhalmazra vonatkozik. Ne feltételezze, hogy a [CalculateFormulas](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) teljes újraszámítást biztosít egy tetszőleges képletre egy külső XLSX fájlban.

**Használhatok olyan képleteket, amelyek másik munkalapra vagy munkafüzetre hivatkoznak?**

Az Excel‑stílusú hivatkozások létezhetnek a diagram munkafüzetekben, de a képlet‑kiértékelés a támogatott elemző és függvény‑készlet által korlátozott. Ha egy kereszt‑lap vagy külső hivatkozás nélkülözhetetlen, ellenőrizze a pontos képletet a cél Aspose.Slides verzióval. Olyan munkafolyamatoknál, amelyek széles körű Excel‑referencia‑kompatibilitást igényelnek, számolja ki a munkafüzetet külsőleg, majd írja vissza a feloldott értékeket a diagram adatokba.

**Kell-e a képletszöveg `=`-vel kezdődjön?**

Az Aspose.Slides API példák a `B2-C2` vagy `SUM(B2:B5)` kifejezéseket a vezető `=` nélkül adják meg. Ennek a formának a használata konzisztens a dokumentált API‑példákkal.