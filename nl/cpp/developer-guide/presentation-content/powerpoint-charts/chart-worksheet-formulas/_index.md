---
title: Grafiekwerkbladformules toepassen in presentaties met C++
linktitle: Werkbladformules
type: docs
weight: 70
url: /nl/cpp/chart-worksheet-formulas/
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
- stringconstante
- foutconstante
- rekenkundige operator
- vergelijkingsoperator
- A1-stijl
- R1C1-stijl
- vooraf gedefinieerde functie
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Pas Excel‑stijlformules toe in Aspose.Slides voor C++‑grafiekwerkbladen, bereken waarden opnieuw en gebruik de resultaten in PowerPoint‑grafieken."
---
## **Overzicht**

PowerPoint-diagrammen slaan hun brongegevens meestal op in een ingebed werkblad. In Aspose.Slides voor C++ kun je dat werkblad benaderen via het diagramgegevens‑werkboek, invoerwaarden schrijven, formules toewijzen aan cellen, ondersteunde formules berekenen en de berekende cellen gebruiken als diagramgegevens.

Dit artikel legt de volledige formule‑workflow uit: een diagram maken, het werkblad vullen, A1‑ of R1C1‑formules toewijzen, ze opnieuw berekenen, de berekende waarden lezen, die cellen koppelen aan een diagramserie en de presentatie opslaan. Het beschrijft tevens de ondersteunde formule‑syntaxis, de ingebouwde functiebasis, gecachte waarden, niet‑ondersteunde formules en spreadsheet‑specifieke fouten.

## **Diagramwerkbladen en Formules**

Een diagramwerkblad bevat de categorieën, serienaam­en en waarden die een diagram gebruikt. In PowerPoint kun je het werkblad inspecteren door de diagramgegevens‑editor te openen:

![PowerPoint-diagram met geopend ingebed werkblad, toont categorie‑ en seriedata](chart-worksheet-formulas_1.png)

In Aspose.Slides wordt het werkblad blootgesteld via de [IChartDataWorkbook](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdataworkbook/)‑interface. Gebruik [IChartDataCell::set_Formula](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatacell/set_formula/) voor A1‑stijlfomules en [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) voor R1C1‑stijlfomules. Na het wijzigen van invoercellen of formules, roep [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) aan om ondersteunde formules opnieuw te berekenen en de bijbehorende celwaarden bij te werken.

Een berekende cel geeft nog steeds zijn resultaat weer via [IChartDataCell::get_Value](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatacell/get_value/). Dit is belangrijk wanneer je een formuleresultaat in code moet inspecteren of de cel wilt gebruiken als diagramdatapunt.

## **Maak een Diagram en Bereken Werkbladformules**

Het volgende voorbeeld toont een end‑to‑end‑workflow. Het maakt een gegroepeerd kolomdiagram, wist de voorbeeldgegevens, schrijft kwartaalomzet‑ en kostenwaarden, berekent winst met formules, leest de resultaten, gebruikt de berekende cellen als diagramwaarden en slaat de presentatie op.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 350.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();
const int32_t worksheetIndex = 0;

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();
workbook->Clear(worksheetIndex);

auto category1 = workbook->GetCell(worksheetIndex, u"A2", ObjectExt::Box<String>(u"Q1"));
auto category2 = workbook->GetCell(worksheetIndex, u"A3", ObjectExt::Box<String>(u"Q2"));
auto category3 = workbook->GetCell(worksheetIndex, u"A4", ObjectExt::Box<String>(u"Q3"));

workbook->GetCell(worksheetIndex, u"B1", ObjectExt::Box<String>(u"Revenue"));
workbook->GetCell(worksheetIndex, u"C1", ObjectExt::Box<String>(u"Expenses"));
workbook->GetCell(worksheetIndex, u"D1", ObjectExt::Box<String>(u"Profit"));

workbook->GetCell(worksheetIndex, u"B2")->set_Value(ObjectExt::Box<double>(120.0));
workbook->GetCell(worksheetIndex, u"C2")->set_Value(ObjectExt::Box<double>(80.0));
workbook->GetCell(worksheetIndex, u"B3")->set_Value(ObjectExt::Box<double>(150.0));
workbook->GetCell(worksheetIndex, u"C3")->set_Value(ObjectExt::Box<double>(95.0));
workbook->GetCell(worksheetIndex, u"B4")->set_Value(ObjectExt::Box<double>(135.0));
workbook->GetCell(worksheetIndex, u"C4")->set_Value(ObjectExt::Box<double>(110.0));

auto profit1 = workbook->GetCell(worksheetIndex, u"D2");
auto profit2 = workbook->GetCell(worksheetIndex, u"D3");
auto profit3 = workbook->GetCell(worksheetIndex, u"D4");

profit1->set_Formula(u"B2-C2");
profit2->set_Formula(u"B3-C3");
profit3->set_Formula(u"B4-C4");

workbook->CalculateFormulas();

auto q1Profit = profit1->get_Value(); // 40
auto q2Profit = profit2->get_Value(); // 55
auto q3Profit = profit3->get_Value(); // 25

chartData->get_Categories()->Add(category1);
chartData->get_Categories()->Add(category2);
chartData->get_Categories()->Add(category3);

auto profitSeries = chartData->get_Series()->Add(workbook->GetCell(worksheetIndex, u"D1"), chart->get_Type());
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit1);
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit2);
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit3);
profitSeries->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

presentation->Save(u"chart-formulas.pptx", SaveFormat::Pptx);
```

De diagramdatapunten verwijzen naar `D2:D4`, zodat het diagram de berekende winstwaarden gebruikt. Er is geen afzonderlijke diagram‑refresh‑aanroep in deze workflow: bereken eerst het werkboek, gebruik of sla daarna de diagramgegevens op die naar de berekende cellen wijzen.

## **Gebruik A1‑Stijl Formules**

A1‑notatie identificeert kolommen met letters en rijen met cijfers. Wijs A1‑stijl‑expressies toe via [IChartDataCell::set_Formula](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatacell/set_formula/).

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"C3")->set_Value(ObjectExt::Box<int32_t>(10));
workbook->GetCell(0, u"F2")->set_Value(ObjectExt::Box<int32_t>(2));
workbook->GetCell(0, u"G2")->set_Value(ObjectExt::Box<int32_t>(3));
workbook->GetCell(0, u"H2")->set_Value(ObjectExt::Box<int32_t>(4));

auto cell = workbook->GetCell(0, u"A2");
cell->set_Formula(u"C3+SUM(F2:H2)");

workbook->CalculateFormulas();

auto value = cell->get_Value(); // 19
```

Veelvoorkomende A1‑referentie‑vormen zijn:

| Referentie | Relatief | Absoluut | Gemengd |
|---|---|---|---|
| Cel | `A2` | `$A$2` | `A$2`, `$A2` |
| Rij | `2:2` | `$2:$2` | — |
| Kolom | `A:A` | `$A:$A` | — |
| Bereik | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Relatieve verwijzingen kunnen wijzigen wanneer een formule wordt verplaatst of gekopieerd door een spreadsheet‑toepassing. Absolute verwijzingen houden beide coördinaten vast, terwijl gemengde verwijzingen alleen een rij of een kolom fixeren.

## **Gebruik R1C1‑Stijl Formules**

R1C1‑notatie identificeert zowel rijen als kolommen numeriek. Relatieve verwijzingen gebruiken offsets tussen vierkante haken. Wijs deze syntaxis toe via [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/).

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"B2")->set_Value(ObjectExt::Box<int32_t>(12));
workbook->GetCell(0, u"C2")->set_Value(ObjectExt::Box<int32_t>(5));

auto cell = workbook->GetCell(0, u"D2");
cell->set_R1C1Formula(u"RC[-2]-RC[-1]");

workbook->CalculateFormulas();

auto value = cell->get_Value(); // 7
```

Veelvoorkomende R1C1‑referentie‑vormen zijn:

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
| Logisch | `TRUE`, `FALSE` | Kan direct worden gebruikt in logische expressies zoals `A2=TRUE`. |
| Numeriek | `1`, `0.5`, `.3`, `1E-2` | Gewone en wetenschappelijke notatie worden ondersteund. |
| String | `"abc"`, `"2/3/2020 12:00"` | Tekst‑literals staan tussen dubbele aanhalingstekens binnen de formule. |
| Foutresultaat | `#DIV/0!`, `#N/A`, `#REF!` | Een geldige formule kan resulteren in een spreadsheet‑foutwaarde in plaats van een normaal resultaat. |

Dit voorbeeld gebruikt verschillende constanttypen:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"A2")->set_Value(ObjectExt::Box<bool>(false));
workbook->GetCell(0, u"B2")->set_Formula(u"A2=TRUE");
workbook->GetCell(0, u"C2")->set_Formula(u"1+0.5");
workbook->GetCell(0, u"D2")->set_Formula(u".3*1E-2");
workbook->GetCell(0, u"E2")->set_Formula(u"\"abc\"");
workbook->GetCell(0, u"F2")->set_Formula(u"2/0");

workbook->CalculateFormulas();

auto logicalValue = workbook->GetCell(0, u"B2")->get_Value(); // Onwaar
auto numericValue = workbook->GetCell(0, u"C2")->get_Value(); // 1.5
auto scientificValue = workbook->GetCell(0, u"D2")->get_Value(); // 0.003
auto stringValue = workbook->GetCell(0, u"E2")->get_Value(); // abc
auto errorValue = workbook->GetCell(0, u"F2")->get_Value(); // #DIV/0!
```

### **Rekenkundige Operatoren**

| Operator | Betekenis | Voorbeeld |
|---|---|---|
| `+` | Optelling of eenzijdig plus | `2+3` |
| `-` | Aftrekking of negatie | `2-3`, `-3` |
| `*` | Vermenigvuldiging | `2*3` |
| `/` | Deling | `2/3` |
| `%` | Procent | `30%` |
| `^` | Exponentiation | `2^3` |

Gebruik haakjes om de evaluatievolgorde expliciet te maken, bijvoorbeeld `(A2+B2)*C2`.

### **Vergelijkingsoperatoren**

Vergelijkingsexpressies geven logische waarden terug.

| Operator | Betekenis | Voorbeeld |
|---|---|---|
| `=` | Gelijk aan | `A2=3` |
| `<>` | Niet gelijk aan | `A2<>3` |
| `>` | Groter dan | `A2>3` |
| `>=` | Groter dan of gelijk aan | `A2>=3` |
| `<` | Kleiner dan | `A2<3` |
| `<=` | Kleiner dan of gelijk aan | `A2<=3` |

## **Ondersteunde Vooraf Gedefinieerde Functies**

Aspose.Slides bevat een ingebouwde formule‑evaluator voor diagramwerkbladen, maar het is geen volledige Excel‑rekenmachine. De gedocumenteerde functieverzameling is beperkt tot de functies hieronder. Ga er niet van uit dat een willekeurige Excel‑functie opnieuw kan worden berekend door [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/).

| Functie | Doel of ondersteunde vorm | Voorbeeld |
|---|---|---|
| `ABS` | Absolute waarde | `ABS(A2)` |
| `AVERAGE` | Gemiddelde | `AVERAGE(B2:B5)` |
| `CEILING` | Rond een getal omhoog af op een veelvoud | `CEILING(A2,5)` |
| `CHOOSE` | Selecteer een waarde op index | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Voeg tekstwaarden samen | `CONCAT(A2,B2)` |
| `CONCATENATE` | Voeg tekstwaarden samen | `CONCATENATE(A2," ",B2)` |
| `DATE` | Maak een datumwaarde met het 1900‑datumsysteem | `DATE(2026,8,19)` |
| `DAYS` | Retourneer het aantal dagen tussen datums | `DAYS(B2,A2)` |
| `FIND` | Zoek een tekstwaarde in een andere | `FIND("-",A2)` |
| `FINDB` | Byte‑georiënteerd zoeken | `FINDB("a",A2)` |
| `IF` | Voorwaardelijk resultaat | `IF(A2>0,A2,0)` |
| `INDEX` | Referentievorm | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vectorvorm | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vectorvorm | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximumwaarde | `MAX(B2:B5)` |
| `SUM` | Som van waarden | `SUM(B2:B5)` |
| `VLOOKUP` | Verticaal zoeken | `VLOOKUP(A2,B2:D10,3,FALSE)` |

De beperkingen in de tabel zijn belangrijk: `INDEX` wordt gedocumenteerd in referentievorm, terwijl `LOOKUP` en `MATCH` in hun vectorvormen staan. `DATE` gebruikt het 1900‑datumsysteem. Functies die hier niet vermeld staan, moeten worden beschouwd als niet‑ondersteund door de Aspose.Slides‑formule‑evaluator, tenzij ze apart worden gedocumenteerd.

## **Herberekening en Gecachte Waarden**

Spreadsheet‑bestanden slaan doorgaans zowel een formule als de laatst berekende waarde op. Aspose.Slides kan daarom een gecachte waarde lezen via [IChartDataCell::get_Value](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatacell/get_value/) wanneer een presentatie wordt geladen en de relevante diagramgegevens niet zijn gewijzigd.

Na het wijzigen van invoercellen of formules, moet je niet vertrouwen op een oude gecachte uitkomst. Roep [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) aan voordat je berekende waarden leest of diagramgegevens opslaat die ervan afhankelijk zijn.

Voor formules buiten de ondersteunde subset kan Aspose.Slides de formule mogelijk niet parseren of de afhankelijkheden niet vaststellen. Als het werkboek is gewijzigd, kan de eerdere gecachte waarde niet langer als betrouwbaar worden beschouwd. In dat geval kan het lezen van een cel met niet‑ondersteunde data een [CellUnsupportedDataException](https://reference.aspose.com/slides/nl/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/) veroorzaken.

Als je diagram afhankelijk is van Excel‑functies die Aspose.Slides niet evalueert, bereken die formules dan met een spreadsheet‑engine die ze ondersteunt en schrijf de resulterende waarden terug naar het diagram‑werkboek. Vervang niet‑ondersteunde formules niet door geraden waarden.

## **Formulefouten Verwerken**

Er zijn twee verschillende soorten problemen te onderscheiden.

Een formule kan geldig zijn maar een spreadsheet‑foutresultaat opleveren, zoals `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` of `#VALUE!`. In dat geval is het fout‑token een celresultaat en kan het worden geretourneerd via [IChartDataCell::get_Value](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatacell/get_value/).

Een formule kan bovendien falen tijdens het parseren, bij referenties, afhankelijkheden of on‑ondersteunde data. Aspose.Slides biedt spreadsheet‑specifieke uitzonderingen voor deze gevallen: [CellInvalidFormulaException](https://reference.aspose.com/slides/nl/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/nl/cpp/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/nl/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/) en [CellUnsupportedDataException](https://reference.aspose.com/slides/nl/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Wanneer formules afkomstig zijn van sjablonen of gebruikersinvoer, behandel deze uitzonderingen rond herberekening en waardetoegang:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Spreadsheet/CellCircularReferenceException.h>
#include <Spreadsheet/CellInvalidFormulaException.h>
#include <Spreadsheet/CellInvalidReferenceException.h>
#include <Spreadsheet/CellUnsupportedDataException.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Spreadsheet;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto cell = workbook->GetCell(0, u"A2");
cell->set_Formula(u"SUM(B2:B5)");

try
{
    workbook->CalculateFormulas();
    auto value = cell->get_Value();
}
catch (CellInvalidFormulaException&)
{
    // Verwerk een ongeldige formule.
}
catch (CellInvalidReferenceException&)
{
    // Verwerk een ongeldige celreferentie.
}
catch (CellCircularReferenceException&)
{
    // Verwerk een cirkelreferentie.
}
catch (CellUnsupportedDataException&)
{
    // Verwerk niet‑ondersteunde spreadsheet‑gegevens.
}
```

## **Praktische Beperkingen**

De formule‑ondersteuning in diagramwerkbladen is bedoeld voor een gedefinieerde subset van spreadsheet‑berekeningen, niet voor volledige Excel‑compatibiliteit. Houd deze beperkingen in gedachten bij het ontwerpen van een rapportage‑workflow:

- Gebruik alleen de gedocumenteerde constanten, operatoren, referenties en functies wanneer je wilt dat Aspose.Slides formules opnieuw berekent.
- Herbereken na het wijzigen van cellen waar formule‑resultaten van afhankelijk zijn.
- Beschouw gecachte waarden uit geladen presentaties als momentopnames, niet als vervanging voor herberekening na bewerkingen.
- Test formules uit bestaande sjablonen voordat je vertrouwt op hun berekende waarden, vooral wanneer ze functies buiten de gedocumenteerde lijst gebruiken.
- Voor formules die een volledige spreadsheet‑rekenmachine vereisen, bereken ze extern en werk vervolgens het diagram‑werkboek bij met de resulterende waarden.

## **FAQ**

**Wat is het verschil tussen `set_Formula` en `set_R1C1Formula`?**

[IChartDataCell::set_Formula](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatacell/set_formula/) slaat een A1‑stijl‑expressie op, bijvoorbeeld `B2-C2`. [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) slaat een R1C1‑stijl‑expressie op, bijvoorbeeld `RC[-2]-RC[-1]`. Gebruik de notatie die het beste past bij hoe je formules genereert of kopieert.

**Moet ik de cel zelf of de waarde ervan lezen na berekening?**

[IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) retourneert een `IChartDataCell`. Om het berekende resultaat te verkrijgen, lees je de [IChartDataCell::get_Value](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatacell/get_value/)‑waarde nadat je hebt herberekend.

**Wanneer moet ik `CalculateFormulas` aanroepen?**

Roep [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) aan nadat je invoerwaarden of formules hebt gewijzigd en voordat je vertrouwt op de berekende resultaten. Dit werkt de waarden van formules bij die de ingebouwde evaluator ondersteunt.

**Ondersteunt Aspose.Slides elke Excel‑functie?**

Nee. De ingebouwde evaluator ondersteunt alleen een gedocumenteerde subset van functies. Functies buiten die subset moeten niet worden verondersteld correct te worden herberekend. Als volledige Excel‑formule‑compatibiliteit vereist is, voer de berekening dan uit met een geschikte spreadsheet‑engine en schrijf de eindwaarden naar het diagram‑werkboek.

**Wat gebeurt er als een geladen presentatie een niet‑ondersteunde formule bevat?**

Als de diagramgegevens niet zijn gewijzigd, kan het werkboek nog steeds een eerder berekende gecachte waarde bevatten. Nadat gerelateerde data is aangepast, is die gecachte waarde mogelijk niet meer geldig. Het benaderen van een cel waarvan de formule niet kan worden verwerkt, kan een [CellUnsupportedDataException](https://reference.aspose.com/slides/nl/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/) veroorzaken.

**Zijn formule‑foutwaarden hetzelfde als C++‑exceptions?**

Nee. Een resultaat zoals `#DIV/0!` is een spreadsheet‑waarde die voortkomt uit een geldige berekening. Exceptions zoals [CellInvalidFormulaException](https://reference.aspose.com/slides/nl/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/) of [CellCircularReferenceException](https://reference.aspose.com/slides/nl/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/) geven aan dat de formule niet normaal kan worden verwerkt.

**Werkt een diagram automatisch bij wanneer een formulecel verandert?**

Een diagramserie kan verwijzen naar werkboekcellen. Bereken eerst het werkboek, sla daarna de presentatie op of render deze. Als de diagramdatapunten naar de berekende cellen verwijzen, gebruikt het diagram die bijgewerkte waarden; een aparte diagram‑refresh‑methode is niet vereist voor deze workflow.

**Kunnen diagrammen een extern Excel‑werkboek gebruiken?**

Ja, diagramgegevens kunnen worden geconfigureerd om een extern werkboek te gebruiken via de diagram‑data‑API. De hier beschreven formule‑berekeningsworkflow betreft echter het diagram‑werkboek en de formule‑subset die door Aspose.Slides wordt geëvalueerd. Ga er niet van uit dat [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) volledige herberekening van willekeurige formules in een extern XLSX‑bestand biedt.

**Kan ik formules gebruiken die naar een ander werkblad of werkboek verwijzen?**

Excel‑stijl verwijzingen kunnen bestaan in diagram‑werkboeken, maar formule‑evaluatie wordt beperkt door de ondersteunde parser en functieverzameling. Als een kruis‑sheet‑ of externe verwijzing essentieel is, valideer dan die exacte formule met jouw doel‑Aspose.Slides‑versie. Voor workflows die brede Excel‑referentie‑compatibiliteit vereisen, bereken het werkboek extern en schrijf de opgeloste waarden terug naar de diagramgegevens.

**Moeten formule‑strings beginnen met `=`?**

De Aspose.Slides‑API‑voorbeelden wijzen expressies toe zoals `B2-C2` of `SUM(B2:B5)` zonder een leidende `=`. Het gebruik van die vorm houdt gegenereerde formules consistent met de gedocumenteerde API‑voorbeelden.