---
title: Formules toepassen op grafiek-werkbladen in presentaties in .NET
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
- grafiekdataboek
- formuleberekening
- logische constante
- numerieke constante
- string constante
- foutconstante
- rekenkundige operator
- vergelijkingsoperator
- A1‑stijl
- R1C1‑stijl
- voorgedefinieerde functie
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Pas Excel‑achtige formules toe in Aspose.Slides voor .NET grafiekwerkbladen, herbereken waarden en gebruik de resultaten in PowerPoint‑grafieken."
---
## **Overzicht**

PowerPoint-grafieken slaan hun brongegevens meestal op in een ingesloten werkblad. In Aspose.Slides for .NET kun je dat werkblad benaderen via de chart‑data‑workbook, invoerwaarden schrijven, formules aan cellen toewijzen, ondersteunde formules berekenen en de berekende cellen gebruiken als grafiekgegevens.

Dit artikel legt de volledige formule‑workflow uit: een grafiek maken, het werkblad vullen, A1‑ of R1C1‑formules toewijzen, ze opnieuw berekenen, de berekende waarden lezen, die cellen koppelen aan een grafiekserie en de presentatie opslaan. Het beschrijft bovendien de ondersteunde formulesyntax, de ingebouwde functiebasis, gecachete waarden, niet‑ondersteunde formules en spreadsheet‑specifieke fouten.

## **Grafiek‑Werkbladen en Formules**

Een grafiek‑werkblad bevat de categorieën, serienaam‑en waarden die een grafiek gebruikt. In PowerPoint kun je het werkblad inspecteren door de grafiek‑data‑editor te openen:

![PowerPoint‑grafiek met zijn ingesloten werkblad geopend, toont categorie‑ en serienummers](chart-worksheet-formulas_1.png)

In Aspose.Slides wordt het werkblad blootgesteld via de [chart data workbook](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdataworkbook/). Gebruik de [Formula](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatacell/formula/)‑eigenschap voor A1‑formules en de [R1C1Formula](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatacell/r1c1formula/)‑eigenschap voor R1C1‑formules. Nadat je invoercellen of formules hebt gewijzigd, roep je [CalculateFormulas](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) aan om ondersteunde formules opnieuw te berekenen en de bijbehorende celwaarden bij te werken.

Een berekende cel geeft nog steeds haar resultaat weer via de [Value](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatacell/value/)‑eigenschap. Dit is belangrijk wanneer je een formule‑resultaat in code moet inspecteren of de cel als grafiek‑datapunt wilt gebruiken.

## **Maak een Grafiek en Bereken Werkblad‑Formules**

Het volgende voorbeeld toont een end‑to‑end workflow. Het maakt een gegroepeerde kolomgrafiek, wist de voorbeeldgegevens, schrijft kwartaal‑omzet‑ en kostwaarden, berekent winst met formules, leest de resultaten, gebruikt de berekende cellen als grafiekwaarden en slaat de presentatie op.

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

De grafiek‑datapunten refereren `D2:D4`, dus de grafiek gebruikt de berekende winstwaarden. Er is geen aparte grafiek‑verversingsaanroep in deze workflow: bereken eerst de workbook, gebruik vervolgens of sla de grafiekgegevens op die naar de berekende cellen wijzen.

## **Gebruik A1‑Stijl Formules**

A1‑notatie identificeert kolommen met letters en rijen met cijfers. Wijs A1‑expressies toe via [IChartDataCell.Formula](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatacell/formula/).

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

Algemene A1‑referentie‑vormen zijn:

| Referentie | Relatief | Absoluut | Gemengd |
|---|---|---|---|
| Cel | `A2` | `$A$2` | `A$2`, `$A2` |
| Rij | `2:2` | `$2:$2` | — |
| Kolom | `A:A` | `$A:$A` | — |
| Bereik | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Relatieve referenties kunnen wijzigen wanneer een formule wordt verplaatst of gekopieerd door een spreadsheet‑applicatie. Absolute referenties houden beide coördinaten vast, terwijl gemengde referenties alleen een rij of een kolom vastzetten.

## **Gebruik R1C1‑Stijl Formules**

R1C1‑notatie identificeert zowel rijen als kolommen numeriek. Relatieve referenties gebruiken offsets in vierkante haken. Wijs deze syntax toe via [IChartDataCell.R1C1Formula](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatacell/r1c1formula/).

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

Algemene R1C1‑referentie‑vormen zijn:

| Referentie | Relatief | Absoluut | Gemengd |
|---|---|---|---|
| Cel | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Rij | `R[2]` | `R2` | — |
| Kolom | `C[3]` | `C3` | — |
| Bereik | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Bijvoorbeeld, in cel `D2` betekent `RC[-2]` de cel in dezelfde rij twee kolommen naar links (`B2`).

## **Formule‑Constanten en Operatoren**

De ingebouwde formule‑evaluator ondersteunt logische waarden, numerieke literals, strings, spreadsheet‑foutwaarden, rekenkundige operatoren en vergelijkingsoperatoren.

### **Constanten en Literalen**

| Type | Voorbeelden | Opmerkingen |
|---|---|---|
| Logisch | `TRUE`, `FALSE` | Kan direct worden gebruikt in logische uitdrukkingen zoals `A2=TRUE`. |
| Numeriek | `1`, `0.5`, `.3`, `1E-2` | Gewone en wetenschappelijke notatie worden ondersteund. |
| String | `"abc"`, `"2/3/2020 12:00"` | Tekst‑literals staan tussen dubbele aanhalingstekens binnen de formule. |
| Foutresultaat | `#DIV/0!`, `#N/A`, `#REF!` | Een geldige formule kan evalueren tot een spreadsheet‑foutwaarde in plaats van een normaal resultaat. |

Dit voorbeeld gebruikt verschillende constante‑types:

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

### **Rekenkundige Operatoren**

| Operator | Betekenis | Voorbeeld |
|---|---|---|
| `+` | Optelling of unair plus | `2+3` |
| `-` | Aftrek of negatie | `2-3`, `-3` |
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

## **Ondersteunde Vooraf Gedefinieerde Functies**

Aspose.Slides bevat een ingebouwde formule‑evaluator voor grafiek‑werkbladen, maar het is geen volledige Excel‑rekenmachine. De gedocumenteerde functieset is beperkt tot de functies hieronder. Neem niet aan dat een willekeurige Excel‑functie kan worden herberekend door [CalculateFormulas](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/).

| Functie | Doel of ondersteunde vorm | Voorbeeld |
|---|---|---|
| `ABS` | Absolute waarde | `ABS(A2)` |
| `AVERAGE` | Aritmetisch gemiddelde | `AVERAGE(B2:B5)` |
| `CEILING` | Rond een getal naar boven af op een veelvoud | `CEILING(A2,5)` |
| `CHOOSE` | Selecteer een waarde op index | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Voeg tekstwaarden samen | `CONCAT(A2,B2)` |
| `CONCATENATE` | Voeg tekstwaarden samen | `CONCATENATE(A2," ",B2)` |
| `DATE` | Maak een datumwaarde met het 1900‑datumsysteem | `DATE(2026,8,19)` |
| `DAYS` | Geef het aantal dagen tussen data terug | `DAYS(B2,A2)` |
| `FIND` | Zoek een tekstwaarde binnen een andere | `FIND("-",A2)` |
| `FINDB` | Byte‑gerichte zoekopdracht | `FINDB("a",A2)` |
| `IF` | Conditioneel resultaat | `IF(A2>0,A2,0)` |
| `INDEX` | Referentie‑vorm | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vector‑vorm | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vector‑vorm | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximumwaarde | `MAX(B2:B5)` |
| `SUM` | Som van waarden | `SUM(B2:B5)` |
| `VLOOKUP` | Verticaal zoeken | `VLOOKUP(A2,B2:D10,3,FALSE)` |

De beperkingen in de tabel zijn belangrijk: `INDEX` wordt gedocumenteerd in referentie‑vorm, terwijl `LOOKUP` en `MATCH` in hun vector‑vormen staan. `DATE` gebruikt het 1900‑systeem. Functies die hier niet worden opgesomd, moeten worden beschouwd als niet‑ondersteund door de Aspose.Slides‑formule‑evaluator, tenzij ze apart zijn gedocumenteerd.

## **Herberekening en Gecachete Waarden**

Spreadsheet‑bestanden bewaren doorgaans zowel een formule als de laatst berekende waarde. Aspose.Slides kan daarom een gecachete waarde lezen via [IChartDataCell.Value](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatacell/value/) wanneer een presentatie wordt geladen en de betreffende grafiek‑data niet is gewijzigd.

Na het wijzigen van invoercellen of formules, baseer je je niet op een oude gecachete uitkomst. Roep [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) aan vóór het lezen van berekende waarden of het opslaan van grafiek‑data die ervan afhankelijk is.

Voor formules buiten de ondersteunde subset kan Aspose.Slides de formule mogelijk niet parseren of de afhankelijkheden niet bepalen. Als de workbook is aangepast, is de vorige gecachete waarde niet langer betrouwbaar. In dat geval kan het lezen van de waarde van een cel met niet‑ondersteunde data een [CellUnsupportedDataException](https://reference.aspose.com/slides/nl/net/aspose.slides.spreadsheet/cellunsupporteddataexception/) veroorzaken.

Als jouw grafiek afhankelijk is van Excel‑functies die Aspose.Slides niet evalueert, bereken die formules dan met een spreadsheet‑engine die ze ondersteunt en schrijf de resulterende waarden terug naar de grafiek‑workbook. Vervang niet‑ondersteunde formules door geraden waarden.

## **Afhandelen van Formule‑Fouten**

Er zijn twee verschillende soorten problemen om van te onderscheiden.

Een formule kan geldig zijn maar een spreadsheet‑foutresultaat opleveren, zoals `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` of `#VALUE!`. In dat geval is de fout‑token een celresultaat en kan via `Value` worden geretourneerd.

Een formule kan ook falen tijdens het parseren, bij referenties, afhankelijkheden of ondersteunde‑data‑niveau. Aspose.Slides biedt spreadsheet‑specifieke excepties voor deze gevallen: [CellInvalidFormulaException](https://reference.aspose.com/slides/nl/net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/nl/net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/nl/net/aspose.slides.spreadsheet/cellcircularreferenceexception/) en [CellUnsupportedDataException](https://reference.aspose.com/slides/nl/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Wanneer formules afkomstig zijn uit sjablonen of gebruikersinvoer, handel deze excepties af rond herberekening en waardetoegang:

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

## **Praktische Beperkingen**

De formule‑ondersteuning in grafiek‑werkbladen is bedoeld voor een gedefinieerde subset van spreadsheet‑berekeningen, niet voor volledige Excel‑compatibiliteit. Houd deze beperkingen in gedachten bij het ontwerpen van een rapportage‑workflow:

- Gebruik alleen de gedocumenteerde constanten, operatoren, referenties en functies wanneer je wilt dat Aspose.Slides formules herberekent.
- Herbereken na het wijzigen van cellen waarop formule‑resultaten steunen.
- Beschouw gecachete waarden van geladen presentaties als snapshots, niet als vervanging voor herberekening na bewerkingen.
- Test formules uit bestaande sjablonen voordat je vertrouwt op hun berekende waarden, vooral wanneer ze functies buiten de gedocumenteerde lijst gebruiken.
- Voor formules die een volledige spreadsheet‑rekenmachine vereisen, bereken ze extern en update vervolgens de grafiek‑workbook met de resulterende waarden.

## **FAQ**

**Wat is het verschil tussen `Formula` en `R1C1Formula`?**

[Formula](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatacell/formula/) slaat een A1‑stijl expressie op, bijvoorbeeld `B2-C2`. [R1C1Formula](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatacell/r1c1formula/) slaat een R1C1‑stijl expressie op, bijvoorbeeld `RC[-2]-RC[-1]`. Gebruik de notatie die het beste past bij hoe je formules genereert of kopieert.

**Moet ik na de berekening de cel zelf of de waarde lezen?**

[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdataworkbook/getcell/) retourneert een `IChartDataCell`. Om het berekende resultaat te verkrijgen, lees je de [Value](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatacell/value/)‑eigenschap van die cel na herberekening.

**Wanneer moet ik `CalculateFormulas` aanroepen?**

Roep [CalculateFormulas](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) aan nadat je invoerwaarden of formules hebt gewijzigd en voordat je vertrouwt op de berekende resultaten. Dit werkt de waarden bij van formules die de ingebouwde evaluator ondersteunt.

**Ondersteunt Aspose.Slides elke Excel‑functie?**

Nee. De ingebouwde evaluator ondersteunt alleen een gedocumenteerde subset van functies. Functies buiten die subset mogen niet als correct herberekend worden beschouwd. Wanneer volledige Excel‑formules compatibiliteit vereist is, voer je de berekening uit met een geschikte spreadsheet‑engine en schrijf je de uiteindelijke waarden naar de grafiek‑workbook.

**Wat gebeurt er als een geladen presentatie een niet‑ondersteunde formule bevat?**

Als de grafiek‑data niet is gewijzigd, kan de workbook nog steeds een eerder berekende gecachete waarde bevatten. Na het aanpassen van gerelateerde data kan die gecachete waarde ongeldig worden. Het benaderen van een cel waarvan de formule niet kan worden verwerkt, kan een [CellUnsupportedDataException](https://reference.aspose.com/slides/nl/net/aspose.slides.spreadsheet/cellunsupporteddataexception/) veroorzaken.

**Zijn formule‑foutwaarden hetzelfde als .NET‑exceptions?**

Nee. Een resultaat zoals `#DIV/0!` is een spreadsheet‑waarde die voortkomt uit een geldige berekening. Exceptions zoals [CellInvalidFormulaException](https://reference.aspose.com/slides/nl/net/aspose.slides.spreadsheet/cellinvalidformulaexception/) of [CellCircularReferenceException](https://reference.aspose.com/slides/nl/net/aspose.slides.spreadsheet/cellcircularreferenceexception/) geven aan dat de formule niet normaal kan worden verwerkt.

**Werkt een grafiek automatisch bij wanneer een formulecel wijzigt?**

Een grafiek‑serie kan naar workbook‑cellen verwijzen. Bereken eerst de workbook, sla vervolgens de presentatie op of render deze. Als de grafiek‑datapunten naar de berekende cellen verwijzen, gebruikt de grafiek die bijgewerkte celwaarden; een aparte grafiek‑verversingsmethode is niet nodig voor deze workflow.

**Kunnen grafieken een extern Excel‑bestand gebruiken?**

Ja, grafiek‑data kan worden geconfigureerd om een extern workbook te gebruiken via de grafiek‑data‑API. De in dit artikel beschreven formule‑berekeningsworkflow heeft echter betrekking op de grafiek‑data‑workbook en de formule‑subset die door Aspose.Slides wordt geëvalueerd. Neem niet aan dat [CalculateFormulas](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) volledige herberekening van willekeurige formules in een extern XLSX‑bestand biedt.

**Kan ik formules gebruiken die naar een ander werkblad of workbook verwijzen?**

Excel‑stijl verwijzingen kunnen bestaan in grafiek‑workbooks, maar de formule‑evaluatie is beperkt door de ondersteunde parser en functieset. Als een cross‑sheet‑ of externe verwijzing essentieel is, controleer dan die exacte formule met jouw specifieke Aspose.Slides‑versie. Voor workflows die brede Excel‑verwijzingscompatibiliteit vereisen, bereken de workbook extern en schrijf de opgeloste waarden terug naar de grafiek‑data.

**Moeten formule‑strings beginnen met `=`?**

De Aspose.Slides‑API‑voorbeelden wijzen expressies toe zoals `B2-C2` of `SUM(B2:B5)` zonder een leidende `=`. Het gebruik van die vorm houdt gegenereerde formules consistent met de gedocumenteerde API‑voorbeelden.