---
title: Tillämpa diagramkalkylbladsformler i presentationer i .NET
linktitle: Kalkylbladsformler
type: docs
weight: 70
url: /sv/net/chart-worksheet-formulas/
keywords:
- diagramkalkylblad
- diagramarbetsblad
- diagramformel
- kalkylbladsformel
- kalkylbladsformel
- diagramdataarbetsbok
- formelberäkning
- logisk konstant
- numerisk konstant
- strängkonstant
- felkonstant
- aritmetisk operator
- jämförelseoperator
- A1‑stil
- R1C1‑stil
- fördefinierad funktion
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Tillämpa Excel‑liknande formler i Aspose.Slides för .NET diagramkalkylblad, beräkna om värden och använd resultaten i PowerPoint‑diagram."
---
## **Översikt**

PowerPoint-diagram lagrar vanligtvis sina källdata i ett inbäddat kalkylblad. I Aspose.Slides för .NET kan du komma åt det kalkylbladet via diagrammets dataarbetsbok, skriva in värden, tilldela formler till celler, beräkna stödda formler och använda de beräknade cellerna som diagramdata.

Denna artikel förklarar hela formelarbetsflödet: skapa ett diagram, fyll i dess kalkylblad, tilldela A1‑stil‑ eller R1C1‑stil‑formler, beräkna dem på nytt, läs de beräknade värdena, anslut dessa celler till en diagramserie och spara presentationen. Den beskriver också den stödda formelsyntaxen, den inbyggda funktionsuppsättningen, cachade värden, osuppporterade formler och kalkylblads‑specifika fel.

## **Diagram‑kalkylblad och formler**

Ett diagram‑kalkylblad innehåller kategorier, serienamn och värden som används av ett diagram. I PowerPoint kan du inspektera kalkylbladet genom att öppna diagrammets dataredigerare:

![PowerPoint-diagram med sitt inbäddade kalkylblad öppet, som visar kategori‑ och seriedata](chart-worksheet-formulas_1.png)

I Aspose.Slides exponeras kalkylbladet via [diagram‑databoken](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdataworkbook/). Använd egenskapen [Formula](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatacell/formula/) för A1‑stil‑formler och egenskapen [R1C1Formula](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatacell/r1c1formula/) för R1C1‑stil‑formler. Efter att du har ändrat indatavärden eller formler, anropa [CalculateFormulas](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) för att beräkna stödda formler och uppdatera motsvarande cellvärden.

En beräknad cell exponerar fortfarande sitt resultat via egenskapen [Value](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatacell/value/). Detta är viktigt när du behöver inspektera ett formelresultat i kod eller använda cellen som ett diagramdatapunkt.

## **Skapa ett diagram och beräkna kalkylblads‑formler**

Följande exempel demonstrerar ett end‑to‑end‑arbetsflöde. Det skapar ett stapeldiagram i kluster, rensar exempeldata, skriver kvartalsvisa intäkts‑ och kostnadsvärden, beräknar vinst med formler, läser resultaten, använder de beräknade cellerna som diagramvärden och sparar presentationen.

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
| Område | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Relativa referenser kan förändras när en formel flyttas eller kopieras av ett kalkylbladsprogram. Absoluta referenser håller båda koordinaterna fasta, medan blandade referenser fixerar endast en rad eller en kolumn.

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
| Område | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Till exempel, i cellen `D2` betyder `RC[-2]` cellen i samma rad två kolumner åt vänster (`B2`).

## **Formelkonstanter och operatorer**

Den inbyggda formelutvärderaren stöder logiska värden, numeriska litteraler, strängar, kalkylblads‑felvärden, aritmetiska operatorer och jämförelseoperatorer.

### **Konstanter och litteraler**

| Typ | Exempel | Anmärkning |
|---|---|---|
| Logisk | `TRUE`, `FALSE` | Kan användas direkt i logiska uttryck såsom `A2=TRUE`. |
| Numerisk | `1`, `0.5`, `.3`, `1E-2` | Vanlig och vetenskaplig notation stöds. |
| Sträng | `"abc"`, `"2/3/2020 12:00"` | Textlitteraler omsluts av dubbla citationstecken i formeln. |
| Felresultat | `#DIV/0!`, `#N/A`, `#REF!` | En giltig formel kan utvärderas till ett kalkylbladsfelvärde istället för ett normalt resultat. |

Detta exempel använder flera konstanttyper:

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
| `+` | Addition eller unärt plustecken | `2+3` |
| `-` | Subtraktion eller negation | `2-3`, `-3` |
| `*` | Multiplikation | `2*3` |
| `/` | Division | `2/3` |
| `%` | Procent | `30%` |
| `^` | Potens | `2^3` |

Använd parenteser för att göra utvärderingsordningen explicit, till exempel `(A2+B2)*C2`.

### **Jämförelseoperatorer**

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

Aspose.Slides inkluderar en inbyggd formelutvärderare för diagram‑kalkylblad, men den är inte en komplett Excel‑beräkningsmotor. Den dokumenterade funktionsuppsättningen är begränsad till funktionerna nedan. Anta inte att en godtycklig Excel‑funktion kan beräknas av [CalculateFormulas](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/).

| Funktion | Syfte eller stödform | Exempel |
|---|---|---|
| `ABS` | Absolutvärde | `ABS(A2)` |
| `AVERAGE` | Aritmetiskt medelvärde | `AVERAGE(B2:B5)` |
| `CEILING` | Runda upp till närmaste multipel | `CEILING(A2,5)` |
| `CHOOSE` | Välj ett värde efter index | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Sammanfoga textvärden | `CONCAT(A2,B2)` |
| `CONCATENATE` | Sammanfoga textvärden | `CONCATENATE(A2," ",B2)` |
| `DATE` | Skapa ett datumvärde med 1900‑datumssystemet | `DATE(2026,8,19)` |
| `DAYS` | Returnera antalet dagar mellan datum | `DAYS(B2,A2)` |
| `FIND` | Hitta en textsträng i en annan | `FIND("-",A2)` |
| `FINDB` | Byte‑orienterad textsökning | `FINDB("a",A2)` |
| `IF` | Villkorligt resultat | `IF(A2>0,A2,0)` |
| `INDEX` | Referensform | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektorform | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektorform | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maxvärde | `MAX(B2:B5)` |
| `SUM` | Summera värden | `SUM(B2:B5)` |
| `VLOOKUP` | Vertikal uppslagning | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Begränsningarna i tabellen är betydelsefulla: `INDEX` är dokumenterad i referensform, medan `LOOKUP` och `MATCH` är dokumenterade i sina vektorformer. `DATE` använder 1900‑datumssystemet. Funktioner och funktioner som inte listas här bör betraktas som osupporterade av Aspose.Slides‑formelutvärderaren om de inte är specifikt dokumenterade.

## **Omberäkning och cachade värden**

Kalkylbladsfiler lagrar ofta både en formel och dess senast beräknade värde. Aspose.Slides kan därför läsa ett cachat värde från [IChartDataCell.Value](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatacell/value/) när en presentation laddas och relevant diagramdata inte har ändrats.

Efter att du har ändrat indataceller eller formler, förlita dig inte på ett gammalt cachat resultat. Anropa [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) innan du läser beräknade värden eller sparar diagramdata som beror på dem.

För formler utanför den stödda delmängden kan Aspose.Slides misslyckas med att tolka formeln eller fastställa dess beroenden. Om arbetsboken har modifierats kan det tidigare cachade värdet inte längre anses pålitligt. I sådana situationer kan läsning av en cell med osupporterad data kasta [CellUnsupportedDataException](https://reference.aspose.com/slides/sv/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Om ditt diagram är beroende av Excel‑funktioner som Aspose.Slides inte utvärderar, beräkna dessa formler med en kalkylblads‑motor som stödjer dem och skriv de resulterande värdena tillbaka till diagramarbetsboken. Ersätt inte osupporterade formler med gissade värden.

## **Hantera formelfel**

Det finns två olika typer av problem att särskilja.

En formel kan vara giltig men producera ett kalkylbladsfelresultat såsom `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` eller `#VALUE!`. I så fall är fel‑tokenen ett cellresultat och kan returneras via `Value`.

En formel kan också misslyckas vid parsning, referens, beroende eller på stöddata‑nivå. Aspose.Slides tillhandahåller kalkylblads‑specifika undantag för dessa fall: [CellInvalidFormulaException](https://reference.aspose.com/slides/sv/net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/sv/net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/sv/net/aspose.slides.spreadsheet/cellcircularreferenceexception/) och [CellUnsupportedDataException](https://reference.aspose.com/slides/sv/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

När formler kommer från mallar eller användarinmatning, hantera dessa undantag kring omberäkning och värdeåtkomst:

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

Formelstödet i diagram‑kalkylblad är avsett för en definierad delmängd av kalkylbladsberäkningar, inte för full Excel‑kompatibilitet. Ha dessa begränsningar i åtanke när du designar ett rapporteringsarbetsflöde:

- Använd endast de dokumenterade konstanterna, operatorerna, referenserna och funktionerna när du vill att Aspose.Slides ska omberäkna formler.
- Omberäkna efter att du har ändrat celler som formelresultaten beror på.
- Betrakta cachade värden från inlästa presentationer som ögonblicksbilder, inte som en ersättning för omberäkning efter redigeringar.
- Testa formler från befintliga mallar innan du förlitar dig på deras beräknade värden, särskilt när de använder funktioner som inte finns med i den dokumenterade listan.
- För formler som kräver en fullständig kalkylblads‑beräkningsmotor, beräkna dem externt och uppdatera sedan diagramarboken med de resulterande värdena.

## **FAQ**

**Vad är skillnaden mellan `Formula` och `R1C1Formula`?**

[Formula](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatacell/formula/) lagrar ett A1‑stil‑uttryck såsom `B2-C2`. [R1C1Formula](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatacell/r1c1formula/) lagrar ett R1C1‑stil‑uttryck såsom `RC[-2]-RC[-1]`. Använd den notation som bäst matchar hur du genererar eller kopierar formler.

**Behöver jag läsa själva cellen eller dess värde efter beräkning?**

[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdataworkbook/getcell/) returnerar ett `IChartDataCell`. För att få det beräknade resultatet, läs den cellens [Value](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatacell/value/)‑egenskap efter omberäkning.

**När ska jag anropa `CalculateFormulas`?**

Anropa [CalculateFormulas](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) efter att du har ändrat indatavärden eller formler och innan du är beroende av de beräknade resultaten. Detta uppdaterar värdena för de formler som den inbyggda utvärderaren stöder.

**Stöder Aspose.Slides varje Excel‑funktion?**

Nej. Den inbyggda utvärderaren stöder en dokumenterad delmängd av funktioner. Funktioner utanför den delmängden bör inte antas beräknas korrekt. Om full Excel‑formelkompatibilitet krävs, utför beräkningen med en lämplig kalkylblads‑motor och skriv de slutliga värdena till diagramarboken.

**Vad händer om en inläst presentation innehåller en osupporterad formel?**

Om diagramdata inte har ändrats kan arbetsboken fortfarande innehålla ett tidigare beräknat cachat värde. Efter att relaterad data har modifierats kan det cachade värdet vara ogiltigt. Åtkomst till en cell vars formel inte kan hanteras kan kasta [CellUnsupportedDataException](https://reference.aspose.com/slides/sv/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**Är formelfelvärden samma sak som .NET‑undantag?**

Nej. Ett resultat som `#DIV/0!` är ett kalkylbladsvärde som produceras av en giltig beräkning. Undantag såsom [CellInvalidFormulaException](https://reference.aspose.com/slides/sv/net/aspose.slides.spreadsheet/cellinvalidformulaexception/) eller [CellCircularReferenceException](https://reference.aspose.com/slides/sv/net/aspose.slides.spreadsheet/cellcircularreferenceexception/) indikerar att formeln inte kan bearbetas normalt.

**Uppdateras ett diagram automatiskt när en formelcell ändras?**

En diagramserie kan referera till arbetsbokens celler. Omberäkna arbetsboken först, spara eller rendera sedan presentationen. Om diagramdatapunkterna refererar till de beräknade cellerna använder diagrammet de uppdaterade cellvärdena; ingen separat diagram‑uppdateringsmetod krävs för detta arbetsflöde.

**Kan diagram använda ett externt Excel‑arbetsbok?**

Ja, diagramdata kan konfigureras att använda en extern arbetsbok via diagram‑data‑API‑et. Dock avser arbetsflödet för formelberäkning som beskrivs i denna artikel diagramarboken och den formeldelmängd som utvärderas av Aspose.Slides. Anta inte att [CalculateFormulas](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) ger full omberäkning av godtyckliga formler i en extern XLSX‑fil.

**Kan jag använda formler som refererar till ett annat kalkylblad eller arbetsbok?**

Excel‑liknande referenser kan finnas i diagramarböcker, men formelutvärderingen är begränsad av den stödjande parsern och funktionsuppsättningen. Om en kors‑blad‑ eller extern referens är avgörande, verifiera exakt formel med den Aspose.Slides‑version du använder. För arbetsflöden som kräver bred Excel‑referenskompatibilitet, beräkna arbetsboken externt och skriv de lösta värdena tillbaka till diagramdata.

**Ska formelsträngar börja med `=`?**

Aspose.Slides‑API‑exempel tilldelar uttryck såsom `B2-C2` eller `SUM(B2:B5)` utan inledande `=`. Att använda den formen håller genererade formler konsekventa med de dokumenterade API‑exemplen.