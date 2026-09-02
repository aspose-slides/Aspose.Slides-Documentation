---
title: Formules voor diagramwerkbladen toepassen in presentaties in .NET
linktitle: Werkbladformules
type: docs
weight: 70
url: /nl/net/chart-worksheet-formulas/
keywords:
- grafiek spreadsheet
- grafiek werkblad
- grafiekformule
- werkbladformule
- spreadsheetformule
- grafiek-gegevenswerkboek
- formuleberekening
- voorkeurscultuur
- cultuurspecifieke formule
- DBCS
- logische constante
- numerieke constante
- stringconstante
- foutconstante
- rekenkundige operator
- vergelijkingsoperator
- A1-stijl
- R1C1-stijl
- voorgedefinieerde functie
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Pas Excel-achtige formules toe in Aspose.Slides voor .NET diagramwerkbladen, bereken waarden opnieuw en gebruik de resultaten in PowerPoint-diagrammen."
---
## **Overzicht**

PowerPoint-diagrammen slaan hun brongegevens meestal op in een ingesloten werkblad. In Aspose.Slides voor .NET kun je dat werkblad benaderen via het chart‑data‑workbook, invoergegevens schrijven, formules toewijzen aan cellen, ondersteunde formules berekenen en de berekende cellen gebruiken als diagramgegevens.

Dit artikel legt de volledige formule‑workflow uit: maak een diagram, vul het werkblad, ken A1‑stijl‑ of R1C1‑stijl‑formules toe, reken ze opnieuw uit, lees de berekende waarden, koppel die cellen aan een diagramserie en sla de presentatie op. Het beschrijft ook de ondersteunde formule‑syntaxis, de ingebouwde functie‑subset, gecachede waarden, niet‑ondersteunde formules en spreadsheet‑specifieke fouten.

## **Werkbladen en formules van diagrammen**

Een werkblad van een diagram bevat de categorieën, serienamen en waarden die door een diagram worden gebruikt. In PowerPoint kun je het werkblad inspecteren door de diagram‑gegevenseditor te openen:

![PowerPoint-diagram met het ingesloten werkblad geopend, waarop categorie‑ en seriesgegevens worden getoond](chart-worksheet-formulas_1.png)

In Aspose.Slides wordt het werkblad blootgesteld via het [chart data workbook](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdataworkbook/). Gebruik de [Formula](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatacell/formula/)‑eigenschap voor A1‑stijl‑formules en de [R1C1Formula](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatacell/r1c1formula/)‑eigenschap voor R1C1‑stijl‑formules. Na het wijzigen van invoercellen of formules, roep [CalculateFormulas](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) aan om ondersteunde formules opnieuw te berekenen en de bijbehorende celwaarden bij te werken.

Een berekende cel exposeert nog steeds haar resultaat via de [Value](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatacell/value/)‑eigenschap. Dit is belangrijk wanneer je een formule‑resultaat in code moet inspecteren of de cel als diagramdatapunt wilt gebruiken.

## **Maak een diagram en bereken werkblad‑formules**

Het volgende voorbeeld toont een end‑to‑end workflow. Het maakt een gegroepeerd kolomdiagram, wist de voorbeeldgegevens, schrijft kwartaalomzet‑ en -kostwaarden, berekent de winst met formules, leest de resultaten, gebruikt de berekende cellen als diagramwaarden en slaat de presentatie op.

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

De diagramdatapunten verwijzen naar `D2:D4`, dus het diagram gebruikt de berekende winstwaarden. Er is geen aparte diagram‑verversingsaanroep in deze workflow: reken eerst het workbook opnieuw uit, gebruik of sla daarna de diagramgegevens op die naar de berekende cellen wijzen.

## **Gebruik A1‑stijl‑formules**

A1‑notatie identificeert kolommen met letters en rijen met cijfers. Ken A1‑stijl‑expressies toe via [IChartDataCell.Formula](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatacell/formula/).

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

Veelvoorkomende A1‑referentie‑vormen zijn:

| Referentie | Relatief | Absoluut | Gemengd |
|---|---|---|---|
| Cel | `A2` | `$A$2` | `A$2`, `$A2` |
| Rij | `2:2` | `$2:$2` | — |
| Kolom | `A:A` | `$A:$A` | — |
| Bereik | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Relatieve verwijzingen kunnen veranderen wanneer een formule door een spreadsheet‑applicatie wordt verplaatst of gekopieerd. Absolute verwijzingen houden beide coördinaten vast, terwijl gemengde verwijzingen alleen een rij of een kolom fixeren.

## **Gebruik R1C1‑stijl‑formules**

R1C1‑notatie identificeert zowel rijen als kolommen numeriek. Relatieve verwijzingen gebruiken offsets tussen vierkante haken. Ken deze syntaxis toe via [IChartDataCell.R1C1Formula](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatacell/r1c1formula/).

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

Veelvoorkomende R1C1‑referentie‑vormen zijn:

| Referentie | Relatief | Absoluut | Gemengd |
|---|---|---|---|
| Cel | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Rij | `R[2]` | `R2` | — |
| Kolom | `C[3]` | `C3` | — |
| Bereik | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Bijvoorbeeld, in cel `D2` betekent `RC[-2]` de cel in dezelfde rij twee kolommen naar links (`B2`).

## **Formule‑constanten en -operatoren**

De ingebouwde formule‑evaluator ondersteunt logische waarden, numerieke literals, strings, spreadsheet‑foutwaarden, rekenkundige operatoren en vergelijkingsoperatoren.

### **Constanten en literals**

| Type | Voorbeelden | Opmerkingen |
|---|---|---|
| Logisch | `TRUE`, `FALSE` | Kan direct gebruikt worden in logische uitdrukkingen zoals `A2=TRUE`. |
| Numeriek | `1`, `0.5`, `.3`, `1E-2` | Komma‑ en wetenschappelijke notatie worden ondersteund. |
| String | `"abc"`, `"2/3/2020 12:00"` | Tekst‑literals staan tussen dubbele aanhalingstekens binnen de formule. |
| Foutresultaat | `#DIV/0!`, `#N/A`, `#REF!` | Een geldige formule kan evalueren tot een spreadsheet‑foutwaarde in plaats van een normaal resultaat. |

Dit voorbeeld gebruikt verschillende constant‑types:

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

var logicalValue = workbook.GetCell(0, "B2").Value; // Onwaar
var numericValue = workbook.GetCell(0, "C2").Value; // 1.5
var scientificValue = workbook.GetCell(0, "D2").Value; // 0.003
var stringValue = workbook.GetCell(0, "E2").Value; // abc
var errorValue = workbook.GetCell(0, "F2").Value; // #DIV/0!
```

### **Rekenkundige operatoren**

| Operator | Betekenis | Voorbeeld |
|---|---|---|
| `+` | Optelling of eenvoudig plus | `2+3` |
| `-` | Aftrekking of negatie | `2-3`, `-3` |
| `*` | Vermenigvuldiging | `2*3` |
| `/` | Deling | `2/3` |
| `%` | Percentage | `30%` |
| `^` | Exponentiële macht | `2^3` |

Gebruik haakjes om de evaluatievolgorde expliciet te maken, bijvoorbeeld `(A2+B2)*C2`.

### **Vergelijkingsoperatoren**

Vergelijkingsuitdrukkingen geven logische waarden terug.

| Operator | Betekenis | Voorbeeld |
|---|---|---|
| `=` | Gelijk aan | `A2=3` |
| `<>` | Niet gelijk aan | `A2<>3` |
| `>` | Groter dan | `A2>3` |
| `>=` | Groter dan of gelijk aan | `A2>=3` |
| `<` | Kleiner dan | `A2<3` |
| `<=` | Kleiner dan of gelijk aan | `A2<=3` |

## **Ondersteunde voorgedefinieerde functies**

Aspose.Slides bevat een ingebouwde formule‑evaluator voor diagram‑werkbladen, maar het is geen volledige Excel‑rekenmachine. De gedocumenteerde functie‑set is beperkt tot de onderstaande functies. Ga er niet van uit dat een willekeurige Excel‑functie kan worden herberekend met [CalculateFormulas](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/).

| Functie | Doel of ondersteunde vorm | Voorbeeld |
|---|---|---|
| `ABS` | Absolute waarde | `ABS(A2)` |
| `AVERAGE` | Rekenkundig gemiddelde | `AVERAGE(B2:B5)` |
| `CEILING` | Een getal afronden naar boven tot een veelvoud | `CEILING(A2,5)` |
| `CHOOSE` | Selecteer een waarde op index | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Tekstwaarden samenvoegen | `CONCAT(A2,B2)` |
| `CONCATENATE` | Tekstwaarden samenvoegen | `CONCATENATE(A2," ",B2)` |
| `DATE` | Een datumwaarde creëren met het 1900‑datumstelsel | `DATE(2026,8,19)` |
| `DAYS` | Aantal dagen tussen datums retourneren | `DAYS(B2,A2)` |
| `FIND` | Een tekstwaarde in een andere zoeken | `FIND("-",A2)` |
| `FINDB` | Byte‑georiënteerd zoeken in tekst | `FINDB("a",A2)` |
| `IF` | Conditioneel resultaat | `IF(A2>0,A2,0)` |
| `INDEX` | Referentie‑vorm | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vector‑vorm | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vector‑vorm | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximumwaarde | `MAX(B2:B5)` |
| `SUM` | Som van waarden | `SUM(B2:B5)` |
| `VLOOKUP` | Verticaal zoeken | `VLOOKUP(A2,B2:D10,3,FALSE)` |

De beperkingen in de tabel zijn significant: `INDEX` wordt gedocumenteerd in referentie‑vorm, terwijl `LOOKUP` en `MATCH` in hun vector‑vormen staan. `DATE` gebruikt het 1900‑datumstelsel. Functies die hier niet zijn vermeld, moeten als niet‑ondersteund worden beschouwd door de Aspose.Slides‑formule‑evaluator, tenzij ze apart worden gedocumenteerd.

## **Formules berekenen met een voorkeurs‑culture**

Sommige functies van het diagram‑workbook interpreteren tekst volgens cultuur‑specifieke regels. Dit is vooral belangrijk voor functies die bedoeld zijn voor talen die double‑byte‑karaktersets (DBCS) gebruiken. Om zulke formules correct te berekenen, maak een [LoadOptions](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/), stel [ISpreadsheetOptions.PreferredCulture](https://reference.aspose.com/slides/nl/net/aspose.slides/ispreadsheetoptions/preferredculture/) in via [LoadOptions.SpreadsheetOptions](https://reference.aspose.com/slides/nl/net/aspose.slides/loadoptions/spreadsheetoptions/), en laad daarna de presentatie.

Het volgende voorbeeld kiest de Japanse cultuur, opent een presentatie met de geconfigureerde laad‑opties en roept [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) aan voor elk diagram‑workbook:

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

De voorkeurs‑culture maakt deel uit van de laad‑configuratie van de presentatie, dus specificeer deze vóór het aanmaken van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑instantie. Gebruik de cultuur die de workbook‑formules verwachten; bijvoorbeeld `ja-JP` voor formules die Japans DBCS‑rekenregels moeten volgen.

## **Herberekening en gecachede waarden**

Spreadsheet‑bestanden slaan doorgaans zowel een formule als de laatst berekende waarde op. Aspose.Slides kan daarom een gecachede waarde lezen via [IChartDataCell.Value](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatacell/value/) wanneer een presentatie wordt geladen en de relevante diagramgegevens niet zijn gewijzigd.

Na het wijzigen van invoercellen of formules, vertrouw niet op een oude gecachede uitkomst. Roep [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) aan voordat je berekende waarden leest of diagramgegevens opslaat die daarvan afhankelijk zijn.

Voor formules buiten de ondersteunde subset kan Aspose.Slides de formule mogelijk niet parseren of de afhankelijkheden niet vaststellen. Als het workbook is aangepast, kan de vorige gecachede waarde niet langer als betrouwbaar worden beschouwd. In dat geval kan het lezen van de waarde van een cel met niet‑ondersteunde gegevens een [CellUnsupportedDataException](https://reference.aspose.com/slides/nl/net/aspose.slides.spreadsheet/cellunsupporteddataexception/) veroorzaken.

Als je diagram afhankelijk is van Excel‑functies die Aspose.Slides niet evalueert, bereken die formules met een spreadsheet‑engine die ze wel ondersteunt en schrijf de resulterende waarden terug naar het diagram‑workbook. Vervang niet‑ondersteunde formules door geraden waarden.

## **Formule‑fouten afhandelen**

Er zijn twee verschillende soorten problemen te onderscheiden.

Een formule kan geldig zijn maar een spreadsheet‑foutresultaat opleveren, zoals `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` of `#VALUE!`. In dat geval is het fout‑token een celresultaat en kan het via `Value` worden geretourneerd.

Een formule kan ook falen tijdens het parsen, bij een verwijzing, bij afhankelijks‑analyse, of omdat de data niet ondersteund wordt. Aspose.Slides biedt spreadsheet‑specifieke uitzonderingen voor deze gevallen: [CellInvalidFormulaException](https://reference.aspose.com/slides/nl/net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/nl/net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/nl/net/aspose.slides.spreadsheet/cellcircularreferenceexception/), en [CellUnsupportedDataException](https://reference.aspose.com/slides/nl/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Wanneer formules afkomstig zijn van sjablonen of invoer van gebruikers, behandel deze uitzonderingen rondom herberekening en waardetoegang:

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

## **Praktische beperkingen**

De formule‑ondersteuning in diagram‑werkbladen is bedoeld voor een gedefinieerde subset van spreadsheet‑berekeningen, niet voor volledige Excel‑compatibiliteit. Houd deze beperkingen in gedachten bij het ontwerpen van een rapportage‑workflow:

- Gebruik alleen de gedocumenteerde constanten, operatoren, verwijzingen en functies wanneer je wilt dat Aspose.Slides formules herberekent.
- Herbereken na het wijzigen van cellen waarop formule‑resultaten afhankelijk zijn.
- Beschouw gecachede waarden uit geladen presentaties als snapshots, niet als vervanging voor herberekening na bewerkingen.
- Test formules uit bestaande sjablonen voordat je vertrouwt op hun berekende waarden, vooral als ze functies buiten de gedocumenteerde lijst gebruiken.
- Voor formules die een volledige spreadsheet‑rekenmachine vereisen, bereken ze extern en werk vervolgens het diagram‑workbook bij met de resulterende waarden.

## **FAQ**

**Wat is het verschil tussen `Formula` en `R1C1Formula`?**

[Formula](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatacell/formula/) slaat een A1‑stijl‑expressie op, zoals `B2-C2`. [R1C1Formula](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatacell/r1c1formula/) slaat een R1C1‑stijl‑expressie op, zoals `RC[-2]-RC[-1]`. Gebruik de notatie die het beste past bij hoe je formules genereert of kopieert.

**Moet ik na de berekening de cel zelf of alleen de waarde lezen?**

[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdataworkbook/getcell/) retourneert een `IChartDataCell`. Om het berekende resultaat te verkrijgen, lees je de [Value](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatacell/value/)‑eigenschap van die cel na herberekening.

**Wanneer moet ik `CalculateFormulas` aanroepen?**

Roep [CalculateFormulas](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) aan nadat je invoerwaarden of formules hebt gewijzigd en voordat je afhankelijk bent van de berekende resultaten. Dit werkt de waarden van formules bij die de ingebouwde evaluator ondersteunt.

**Ondersteunt Aspose.Slides elke Excel‑functie?**

Nee. De ingebouwde evaluator ondersteunt alleen een gedocumenteerde subset van functies. Functies buiten die subset moeten niet worden verondersteld correct te herberekenen. Als volledige Excel‑formule‑compatibiliteit vereist is, voer dan de berekening uit met een geschikte spreadsheet‑engine en schrijf de uiteindelijke waarden naar het diagram‑workbook.

**Wat gebeurt er als een geladen presentatie een niet‑ondersteunde formule bevat?**

Als de diagramgegevens niet zijn gewijzigd, kan het workbook nog een eerder berekende gecachede waarde bevatten. Nadat gerelateerde data is aangepast, kan die gecachede waarde ongeldig zijn. Het benaderen van een cel waarvan de formule niet kan worden verwerkt, kan een [CellUnsupportedDataException](https://reference.aspose.com/slides/nl/net/aspose.slides.spreadsheet/cellunsupporteddataexception/) veroorzaken.

**Zijn formule‑foutwaarden hetzelfde als .NET‑exceptions?**

Nee. Een resultaat zoals `#DIV/0!` is een spreadsheet‑waarde die door een geldige berekening is geproduceerd. Exceptions zoals [CellInvalidFormulaException](https://reference.aspose.com/slides/nl/net/aspose.slides.spreadsheet/cellinvalidformulaexception/) of [CellCircularReferenceException](https://reference.aspose.com/slides/nl/net/aspose.slides.spreadsheet/cellcircularreferenceexception/) geven aan dat de formule niet normaal kan worden verwerkt.

**Werkt een diagram automatisch bij wanneer een formulecel wijzigt?**

Een diagramserie kan verwijzen naar workbook‑cellen. Herbereken eerst het workbook, sla vervolgens de presentatie op of render deze. Als de diagramdatapunten naar de berekende cellen verwijzen, gebruikt het diagram die bijgewerkte celwaarden; een aparte diagram‑verversingsmethode is niet nodig voor deze workflow.

**Kunnen diagrammen een extern Excel‑workbook gebruiken?**

Ja, diagramgegevens kunnen worden geconfigureerd om een extern workbook te gebruiken via de diagram‑data‑API. De hier beschreven formule‑berekeningsworkflow heeft echter betrekking op het diagram‑data‑workbook en de formule‑subset die door Aspose.Slides wordt geëvalueerd. Ga er niet van uit dat [CalculateFormulas](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) volledige herberekening van willekeurige formules in een extern XLSX‑bestand biedt.

**Kan ik formules gebruiken die naar een ander werkblad of workbook verwijzen?**

Excel‑stijlen verwijzingen kunnen in diagram‑workbooks bestaan, maar formule‑evaluatie is beperkt tot de ondersteunde parser en functieset. Als een cross‑sheet‑ of externe verwijzing essentieel is, controleer dan die exacte formule met de versie van Aspose.Slides die je gebruikt. Voor workflows die brede Excel‑referentie‑compatibiliteit vereisen, bereken het workbook extern en schrijf de opgeloste waarden terug naar de diagramgegevens.

**Moeten formule‑strings beginnen met `=`?**

De Aspose.Slides‑API‑voorbeelden wijzen uitdrukkingen toe zoals `B2-C2` of `SUM(B2:B5)` zonder een leidende `=`. Het gebruik van die vorm houdt gegenereerde formules consistent met de gedocumenteerde API‑voorbeelden.