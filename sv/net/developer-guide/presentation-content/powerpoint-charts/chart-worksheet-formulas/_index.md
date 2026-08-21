---
title: Använd diagram‑kalkylbladsformler i presentationer i .NET
linktitle: Kalkylbladsformler
type: docs
weight: 70
url: /sv/net/chart-worksheet-formulas/
keywords:
- diagramkalkylblad
- diagramkalkylblad
- diagramformel
- kalkylbladsformel
- kalkylbladsformel
- diagramdatabok
- formelberäkning
- föredragen kultur
- kulturspecifik formel
- DBCS
- logisk konstant
- numerisk konstant
- strängkonstant
- felkonstant
- aritmetisk operator
- jämförelsesoperator
- A1‑stil
- R1C1‑stil
- fördefinierad funktion
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Använd Excel‑liknande formler i Aspose.Slides för .NET‑diagramkalkylblad, beräkna om värden och använd resultaten i PowerPoint‑diagram."
---
## **Översikt**

PowerPoint‑diagram lagrar vanligtvis sina källdata i ett inbäddat kalkylblad. I Aspose.Slides för .NET kan du komma åt det kalkylbladet via diagramdataboken, skriva inmatningsvärden, tilldela formler till celler, beräkna stödjade formler och använda de beräknade cellerna som diagramdata.

Den här artikeln förklarar hela formler‑arbetsflödet: skapa ett diagram, fyll i kalkylbladet, tilldela A1‑ eller R1C1‑formler, beräkna dem på nytt, läs de beräknade värdena, anslut cellerna till en diagramserie och spara presentationen. Den beskriver också den stödjade formelsyntaxen, den inbyggda funktionsuppsättningen, cachade värden, osupporterade formler och kalkylblads‑specifika fel.

## **Diagram‑kalkylblad och formler**

Ett diagram‑kalkylblad innehåller kategorier, serienamn och värden som används av ett diagram. I PowerPoint kan du inspektera kalkylbladet genom att öppna diagramdataredigeraren:

![PowerPoint‑diagram med sitt inbäddade kalkylblad öppet, visar kategori‑ och seriedata](chart-worksheet-formulas_1.png)

I Aspose.Slides exponeras kalkylbladet via [arbetsboken för diagramdata](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdataworkbook/). Använd egenskapen [Formula](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatacell/formula/) för A1‑formler och egenskapen [R1C1Formula](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatacell/r1c1formula/) för R1C1‑formler. Efter att du ändrat inmatningsceller eller formler, anropa [CalculateFormulas](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) för att beräkna stödjade formler och uppdatera motsvarande cellvärden.

En beräknad cell exponerar fortfarande sitt resultat via egenskapen [Value](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatacell/value/). Detta är viktigt när du behöver inspektera ett formelresultat i kod eller använda cellen som ett diagramdatapunkt.

## **Skapa ett diagram och beräkna kalkylbladsformler**

Följande exempel demonstrerar ett end‑to‑end‑arbetsflöde. Det skapar ett staplat kolumndiagram, rensar exempeldata, skriver in kvartalsvisa intäkter och kostnader, beräknar vinst med formler, läser resultaten, använder de beräknade cellerna som diagramvärden och sparar presentationen.

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

Diagramdatapunkterna refererar till `D2:D4`, så diagrammet använder de beräknade vinstvärdena. Det finns inget separat diagram‑uppdateringsanrop i detta arbetsflöde: beräkna arbetsboken först, använd eller spara sedan diagramdata som pekar på de beräknade cellerna.

## **Använd A1‑stil‑formler**

A1‑notation identifierar kolumner med bokstäver och rader med siffror. Tilldela A1‑stil‑uttryck via [IChartDataCell.Formula](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatacell/formula/).

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

Vanliga A1‑referensformer är:

| Referens | Relativ | Absolut | Blandet |
|---|---|---|---|
| Cell | `A2` | `$A$2` | `A$2`, `$A2` |
| Rad | `2:2` | `$2:$2` | — |
| Kolumn | `A:A` | `$A:$A` | — |
| Intervall | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Relativa referenser kan ändras när en formel flyttas eller kopieras i ett kalkylprogram. Absoluta referenser håller båda koordinaterna fasta, medan blandade referenser fixerar endast en rad eller en kolumn.

## **Använd R1C1‑stil‑formler**

R1C1‑notation identifierar både rader och kolumner numeriskt. Relativa referenser använder avstånd i hakparenteser. Tilldela denna syntax via [IChartDataCell.R1C1Formula](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatacell/r1c1formula/).

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

Vanliga R1C1‑referensformer är:

| Referens | Relativ | Absolut | Blandet |
|---|---|---|---|
| Cell | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Rad | `R[2]` | `R2` | — |
| Kolumn | `C[3]` | `C3` | — |
| Intervall | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Till exempel, i cell `D2` betyder `RC[-2]` cellen i samma rad två kolumner åt vänster (`B2`).

## **Formel‑konstanter och operatorer**

Den inbyggda formel‑evaluatören stöder logiska värden, numeriska litteraler, strängar, kalkylbladsfelvärden, aritmetiska operatörer och jämförelsesoperatorer.

### **Konstanter och litteraler**

| Typ | Exempel | Anmärkning |
|---|---|---|
| Logisk | `TRUE`, `FALSE` | Kan användas direkt i logiska uttryck såsom `A2=TRUE`. |
| Numerisk | `1`, `0.5`, `.3`, `1E-2` | Vanlig och vetenskaplig notation stöds. |
| Sträng | `"abc"`, `"2/3/2020 12:00"` | Textlitteraler omges av dubbla citationstecken i formeln. |
| Felresultat | `#DIV/0!`, `#N/A`, `#REF!` | En giltig formel kan utvärderas till ett kalkylbladsfelvärde istället för ett normalt resultat. |

Detta exempel använder flera konstanstyper:

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

var logicalValue = workbook.GetCell(0, "B2").Value; // Falskt
var numericValue = workbook.GetCell(0, "C2").Value; // 1.5
var scientificValue = workbook.GetCell(0, "D2").Value; // 0.003
var stringValue = workbook.GetCell(0, "E2").Value; // abc
var errorValue = workbook.GetCell(0, "F2").Value; // #DIV/0!
```

### **Aritmetiska operatorer**

| Operator | Betydelse | Exempel |
|---|---|---|
| `+` | Addition eller unärt plus | `2+3` |
| `-` | Subtraktion eller negation | `2-3`, `-3` |
| `*` | Multiplikation | `2*3` |
| `/` | Division | `2/3` |
| `%` | Procent | `30%` |
| `^` | Upphöjning | `2^3` |

Använd parenteser för att göra utvärderingsordningen explicit, exempelvis `(A2+B2)*C2`.

### **Jämförelsesoperatorer**

Jämförelseuttryck returnerar logiska värden.

| Operator | Betydelse | Exempel |
|---|---|---|
| `=` | Lika med | `A2=3` |
| `<>` | Inte lika med | `A2<>3` |
| `>` | Större än | `A2>3` |
| `>=` | Större än eller lika med | `A2>=3` |
| `<` | Mindre än | `A2<3` |
| `<=` | Mindre än eller lika med | `A2<=3` |

## **Stödda fördefinierade funktioner**

Aspose.Slides innehåller en inbyggd formel‑evaluatör för diagram‑kalkylblad, men den är inte en komplett Excel‑beräkningsmotor. Den dokumenterade funktionsuppsättningen är begränsad till funktionerna nedan. Anta inte att en godtycklig Excel‑funktion kan beräknas med [CalculateFormulas](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/).

| Funktion | Syfte eller stödjad form | Exempel |
|---|---|---|
| `ABS` | Absolutvärde | `ABS(A2)` |
| `AVERAGE` | Medelvärde | `AVERAGE(B2:B5)` |
| `CEILING` | Avrunda uppåt till närmaste multipel | `CEILING(A2,5)` |
| `CHOOSE` | Välj värde efter index | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Sammanfoga textvärden | `CONCAT(A2,B2)` |
| `CONCATENATE` | Sammanfoga textvärden | `CONCATENATE(A2," ",B2)` |
| `DATE` | Skapa datumvärde med 1900‑datumsystemet | `DATE(2026,8,19)` |
| `DAYS` | Returnera antal dagar mellan datum | `DAYS(B2,A2)` |
| `FIND` | Hitta en textsträng i en annan | `FIND("-",A2)` |
| `FINDB` | Byte‑orienterad textsökning | `FINDB("a",A2)` |
| `IF` | Villkorligt resultat | `IF(A2>0,A2,0)` |
| `INDEX` | Referensform | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektorform | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektorform | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximalt värde | `MAX(B2:B5)` |
| `SUM` | Summan av värden | `SUM(B2:B5)` |
| `VLOOKUP` | Vertikal sökning | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Begränsningarna i tabellen är viktiga: `INDEX` är dokumenterad i referensform, medan `LOOKUP` och `MATCH` är dokumenterade i deras vektorformer. `DATE` använder 1900‑datumsystemet. Funktioner som inte listas bör betraktas som osupporterade av Aspose.Slides‑formel‑evaluatören om de inte är dokumenterade separat.

## **Beräkna formler med föredragen kultur**

Vissa arbetsboksfunktioner tolkar text enligt kultur‑specifika regler. Detta är särskilt viktigt för funktioner avsedda för språk som använder dubbelbyte‑teckenuppsättningar (DBCS). För att beräkna sådana formler korrekt, skapa ett [LoadOptions](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/)-objekt, ange [ISpreadsheetOptions.PreferredCulture](https://reference.aspose.com/slides/sv/net/aspose.slides/ispreadsheetoptions/preferredculture/) via [LoadOptions.SpreadsheetOptions](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/spreadsheetoptions/), och ladda sedan presentationen.

Följande exempel väljer den japanska kulturen, öppnar en presentation med de konfigurerade laddningsalternativen och anropar [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) för varje diagram‑arbetsbok:

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

Den föredragna kulturen är en del av presentations‑laddningskonfigurationen, så ange den innan du skapar ett [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/)-objekt. Använd den kultur som formlerna förväntar sig; exempelvis `ja-JP` för formler som ska följa japanska DBCS‑beräkningsregler.

## **Omberäkning och cachade värden**

Kalkylbladsfiler lagrar vanligtvis både en formel och dess senast beräknade värde. Aspose.Slides kan därför läsa ett cache‑värde från [IChartDataCell.Value](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatacell/value/) när en presentation laddas och den relevanta diagramdata inte har förändrats.

Efter att du ändrat inmatningsceller eller formler, förlita dig inte på ett gammalt cache‑resultat. Anropa [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) innan du läser beräknade värden eller sparar diagramdata som beror på dem.

För formler utanför den stödjade delmängden kan Aspose.Slides misslyckas med att tolka formeln eller fastställa dess beroenden. Om arbetsboken har ändrats kan det tidigare cache‑värdet inte längre betraktas som pålitligt. I sådana fall kan läsning av en cell med osupporterad data leda till ett [CellUnsupportedDataException](https://reference.aspose.com/slides/sv/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Om ditt diagram är beroende av Excel‑funktioner som Aspose.Slides inte utvärderar, beräkna dessa formler med en kalkylblads‑motor som stöder dem och skriv tillbaka de resulterande värdena till diagram‑arbetsboken. Ersätt inte osupporterade formler med gissade värden.

## **Hantera formelfel**

Det finns två olika typer av problem att skilja på.

En formel kan vara giltig men producera ett kalkylbladsfelresultat såsom `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` eller `#VALUE!`. I så fall är fel‑tokenen ett cellresultat och kan returneras via `Value`.

En formel kan också misslyckas vid parsning, referens, beroende eller på den stödjade datanivån. Aspose.Slides tillhandahåller kalkylblads‑specifika undantag för dessa fall: [CellInvalidFormulaException](https://reference.aspose.com/slides/sv/net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/sv/net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/sv/net/aspose.slides.spreadsheet/cellcircularreferenceexception/) och [CellUnsupportedDataException](https://reference.aspose.com/slides/sv/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

När formler kommer från mallar eller användarinmatning, omge omberäkning och värdeåtkomst med hantering av dessa undantag:

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

## **Praktiska begränsningar**

Formelstödet i diagram‑kalkylblad är avsett för en definierad delmängd av kalkylbladsberäkningar, inte för full Excel‑kompatibilitet. Tänk på dessa begränsningar när du designar ett rapporterings‑arbetsflöde:

- Använd endast de dokumenterade konstanterna, operatörerna, referenserna och funktionerna när du vill att Aspose.Slides ska beräkna formler.
- Beräkna om efter att du ändrat celler som formelresultat beror på.
- Betrakta cachade värden från inlästa presentationer som snapshots, inte som ersättning för omberäkning efter redigering.
- Testa formler från befintliga mallar innan du förlitar dig på deras beräknade värden, särskilt om de använder funktioner utanför den dokumenterade listan.
- För formler som kräver en fullständig kalkylblads‑beräkningsmotor, beräkna dem externt och uppdatera sedan diagram‑arbetsboken med de resulterande värdena.

## **FAQ**

**Vad är skillnaden mellan `Formula` och `R1C1Formula`?**

[Formula](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatacell/formula/) lagrar ett A1‑stil‑uttryck såsom `B2-C2`. [R1C1Formula](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatacell/r1c1formula/) lagrar ett R1C1‑stil‑uttryck såsom `RC[-2]-RC[-1]`. Använd den notation som bäst matchar hur du genererar eller kopierar formler.

**Behöver jag läsa själva cellen eller dess värde efter beräkning?**

[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdataworkbook/getcell/) returnerar ett `IChartDataCell`. För att få det beräknade resultatet, läs den cellens [Value](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatacell/value/)‑egenskap efter omberäkning.

**När ska jag anropa `CalculateFormulas`?**

Anropa [CalculateFormulas](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) efter att du ändrat inmatningsvärden eller formler och innan du är beroende av de beräknade resultaten. Detta uppdaterar värdena för formler som den inbyggda evaluatören stödjer.

**Stöder Aspose.Slides varje Excel‑funktion?**

Nej. Den inbyggda evaluatören stödjer en dokumenterad delmängd av funktioner. Funktioner utanför den delmängden bör inte antas beräknas korrekt. Om full Excel‑formelkompatibilitet krävs, utför beräkningen med en lämplig kalkylblads‑motor och skriv de slutgiltiga värdena till diagram‑arbetsboken.

**Vad händer om en inläst presentation innehåller en osupporterad formel?**

Om diagramdata inte har ändrats kan arbetsboken fortfarande innehålla ett tidigare beräknat cache‑värde. Efter att relaterad data har modifierats kan detta cache‑värde vara ogiltigt. Att komma åt en cell vars formel inte kan hanteras kan leda till ett [CellUnsupportedDataException](https://reference.aspose.com/slides/sv/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**Är formelfelvärden samma sak som .NET‑undantag?**

Nej. Ett resultat som `#DIV/0!` är ett kalkylbladsvärde som produceras av en giltig beräkning. Undantag såsom [CellInvalidFormulaException](https://reference.aspose.com/slides/sv/net/aspose.slides.spreadsheet/cellinvalidformulaexception/) eller [CellCircularReferenceException](https://reference.aspose.com/slides/sv/net/aspose.slides.spreadsheet/cellcircularreferenceexception/) indikerar att formeln inte kan bearbetas normalt.

**Uppdateras ett diagram automatiskt när en formelcell förändras?**

En diagramserie kan referera arbetsboks­celler. Beräkna arbetsboken först, spara eller rendera sedan presentationen. Om diagramdatapunkterna refererar de beräknade cellerna använder diagrammet de uppdaterade värdena; inget separat diagram‑uppdateringsmetod krävs för detta arbetsflöde.

**Kan diagram använda ett externt Excel‑arbetsbok?**

Ja, diagramdata kan konfigureras att använda ett externt arbetsbok via diagram‑data‑API:t. Dock rör sig det formel‑beräkningsarbetsflöde som beskrivs i den här artikeln endast om diagram‑arbetsboken och den formel­delmängd som Aspose.Slides utvärderar. Anta inte att [CalculateFormulas](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) ger fullständig omberäkning av godtyckliga formler i en extern XLSX‑fil.

**Kan jag använda formler som refererar ett annat kalkylblad eller arbetsbok?**

Excel‑stil‑referenser kan finnas i diagram‑arbetsböcker, men formelutvärderingen är begränsad av den stödjade parsern och funktionsuppsättningen. Om ett kors‑blad‑ eller externt referens är avgörande, verifiera att exakt formel fungerar med din mål‑version av Aspose.Slides. För arbetsflöden som kräver bred Excel‑referens‑kompatibilitet, beräkna arbetsboken externt och skriv tillbaka de lösta värdena till diagram‑data.

**Ska formelsträngar börja med `=`?**

Aspose.Slides‑API‑exempel tilldelar uttryck såsom `B2-C2` eller `SUM(B2:B5)` utan ett inledande `=`. Att använda den formen håller genererade formler i linje med de dokumenterade API‑exemplen.