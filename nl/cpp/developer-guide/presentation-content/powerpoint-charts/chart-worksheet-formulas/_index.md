---
title: Grafiek-werkbladformules toepassen in presentaties met C++
linktitle: Werkbladformules
type: docs
weight: 70
url: /nl/cpp/chart-worksheet-formulas/
keywords:
- grafiek-spreadsheet
- grafiek-werkblad
- grafiekformule
- werkbladformule
- spreadsheet-formule
- grafiek-data-werkboek
- formule-berekening
- voorkeurscultuur
- cultuurspecifieke formule
- DBCS
- logische constante
- numerieke constante
- tekenreeks-constante
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
description: "Excel-stijl formules toepassen in Aspose.Slides voor C++-grafiekwerkbladen, waarden opnieuw berekenen en de resultaten gebruiken in PowerPoint-grafieken."
---
## **Overzicht**

PowerPoint‑grafieken slaan hun brongegevens doorgaans op in een ingebed werkblad. In Aspose.Slides for C++ kun je dat werkblad benaderen via de chart‑data‑workbook, invoerwaarden schrijven, formules toewijzen aan cellen, ondersteunde formules berekenen en de berekende cellen gebruiken als grafiekgegevens.

Dit artikel legt de volledige formule‑workflow uit: een grafiek maken, het werkblad vullen, A1‑ of R1C1‑formules toewijzen, ze opnieuw berekenen, de berekende waarden uitlezen, die cellen koppelen aan een grafiekserie en de presentatie opslaan. Tevens wordt de ondersteunde formule‑syntaxis, de ingebouwde functieverzameling, gecachete waarden, niet‑ondersteunde formules en spreadsheet‑specifieke fouten beschreven.

## **Grafiek‑werkbladen en Formules**

Een grafiek‑werkblad bevat de categorieën, serienaam­en en waarden die door een grafiek worden gebruikt. In PowerPoint kun je het werkblad inspecteren door de grafiek‑data‑editor te openen:

![PowerPoint‑grafiek met geopend ingebed werkblad, toont categorie‑ en seriedata](chart-worksheet-formulas_1.png)

In Aspose.Slides wordt het werkblad blootgesteld via de [IChartDataWorkbook](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdataworkbook/)‑interface. Gebruik [IChartDataCell::set_Formula](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatacell/set_formula/) voor A1‑style formules en [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) voor R1C1‑style formules. Na het wijzigen van invoercellen of formules, roep [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) aan om ondersteunde formules opnieuw te berekenen en de bijbehorende celwaarden bij te werken.

Een berekende cel geeft nog steeds haar resultaat bloot via [IChartDataCell::get_Value](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatacell/get_value/). Dit is belangrijk wanneer je een formule‑resultaat in code moet inspecteren of de cel als grafiekdatumpunt wilt gebruiken.

## **Een Grafiek Maken en Werkbladformules Berekenen**

Het volgende voorbeeld demonstreert een end‑to‑end workflow. Het maakt een gegroepeerde kolomgrafiek, wist de voorbeeldgegevens, schrijft kwartaal‑omzet‑ en uitgavenwaarden, berekent winst met formules, leest de resultaten, gebruikt de berekende cellen als grafiekwaarden en slaat de presentatie op.

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

De grafiekdatapunten verwijzen naar `D2:D4`, zodat de grafiek de berekende winstwaarden gebruikt. Er is geen aparte grafiek‑verversingsaanroep in deze workflow: bereken eerst het werkblad, gebruik daarna of sla de grafiekgegevens op die naar de berekende cellen wijzen.

## **A1‑Style Formules Gebruiken**

A1‑notatie identificeert kolommen met letters en rijen met cijfers. Wijs A1‑style expressies toe via [IChartDataCell::set_Formula](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatacell/set_formula/).

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

Veelvoorkomende A1‑referentievormen zijn:

| Referentie | Relatief | Absoluut | Gemengd |
|---|---|---|---|
| Cel | `A2` | `$A$2` | `A$2`, `$A2` |
| Rij | `2:2` | `$2:$2` | — |
| Kolom | `A:A` | `$A:$A` | — |
| Bereik | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Relatieve referenties kunnen veranderen wanneer een formule wordt verplaatst of gekopieerd door een spreadsheet‑applicatie. Absolute referenties houden beide coördinaten vast, terwijl gemengde referenties alleen een rij of een kolom fixeren.

## **R1C1‑Style Formules Gebruiken**

R1C1‑notatie identificeert zowel rijen als kolommen numeriek. Relatieve referenties gebruiken offsets tussen vierkante haken. Wijs deze syntaxis toe via [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/).

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

Veelvoorkomende R1C1‑referentievormen zijn:

| Referentie | Relatief | Absoluut | Gemengd |
|---|---|---|---|
| Cel | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Rij | `R[2]` | `R2` | — |
| Kolom | `C[3]` | `C3` | — |
| Bereik | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Bijvoorbeeld, in cel `D2` betekent `RC[-2]` de cel in dezelfde rij twee kolommen naar links (`B2`).

## **Formule‑Constanten en Operators**

De ingebouwde formule‑evaluator ondersteunt logische waarden, numerieke literals, strings, spreadsheet‑foutwaarden, rekenkundige operators en vergelijkingsoperators.

### **Constanten en Literals**

| Type | Voorbeelden | Opmerkingen |
|---|---|---|
| Logisch | `TRUE`, `FALSE` | Kan direct gebruikt worden in logische expressies zoals `A2=TRUE`. |
| Numeriek | `1`, `0.5`, `.3`, `1E-2` | Veelgebruikte en wetenschappelijke notatie worden ondersteund. |
| String | `"abc"`, `"2/3/2020 12:00"` | Tekst‑literals staan tussen dubbele aanhalingstekens binnen de formule. |
| Foutresultaat | `#DIV/0!`, `#N/A`, `#REF!` | Een geldige formule kan evalueren naar een spreadsheet‑foutwaarde in plaats van een normaal resultaat. |

Dit voorbeeld gebruikt verschillende constante‑types:

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

### **Rekenkundige Operators**

| Operator | Betekenis | Voorbeeld |
|---|---|---|
| `+` | Optelling of unair plus | `2+3` |
| `-` | Aftrekking of negatie | `2-3`, `-3` |
| `*` | Vermenigvuldiging | `2*3` |
| `/` | Deling | `2/3` |
| `%` | Percentage | `30%` |
| `^` | Exponentiation | `2^3` |

Gebruik haakjes om de evaluatie‑volgorde expliciet te maken, bijvoorbeeld `(A2+B2)*C2`.

### **Vergelijkingsoperators**

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

Aspose.Slides bevat een ingebouwde formule‑evaluator voor grafiek‑werkbladen, maar het is geen volledige Excel‑berekeningsengine. De gedocumenteerde functie‑set is beperkt tot de functies hieronder. Ga er niet van uit dat een willekeurige Excel‑functie opnieuw kan worden berekend door [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/).

| Functie | Doel of ondersteunde vorm | Voorbeeld |
|---|---|---|
| `ABS` | Absoluut waarde | `ABS(A2)` |
| `AVERAGE` | Gemiddelde | `AVERAGE(B2:B5)` |
| `CEILING` | Afronden naar boven naar een veelvoud | `CEILING(A2,5)` |
| `CHOOSE` | Een waarde selecteren op index | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Tekstwaarden samenvoegen | `CONCAT(A2,B2)` |
| `CONCATENATE` | Tekstwaarden samenvoegen | `CONCATENATE(A2," ",B2)` |
| `DATE` | Een datumwaarde maken met het 1900‑datumsysteem | `DATE(2026,8,19)` |
| `DAYS` | Aantal dagen tussen data retourneren | `DAYS(B2,A2)` |
| `FIND` | Een tekstwaarde in een andere zoeken | `FIND("-",A2)` |
| `FINDB` | Byte‑georiënteerd tekst zoeken | `FINDB("a",A2)` |
| `IF` | Conditionele uitkomst | `IF(A2>0,A2,0)` |
| `INDEX` | Referentie‑vorm | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vector‑vorm | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vector‑vorm | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximumwaarde | `MAX(B2:B5)` |
| `SUM` | Som van waarden | `SUM(B2:B5)` |
| `VLOOKUP` | Verticaal zoeken | `VLOOKUP(A2,B2:D10,3,FALSE)` |

De beperkingen in de tabel zijn significant: `INDEX` is gedocumenteerd in referentie‑vorm, terwijl `LOOKUP` en `MATCH` in hun vector‑vormen staan. `DATE` gebruikt het 1900‑datumsysteem. Functies die hier niet vermeld staan, moeten als niet‑ondersteund worden beschouwd door de Aspose.Slides‑formule‑evaluator, tenzij ze apart gedocumenteerd zijn.

## **Formules Berekenen met een Voorkeur‑Cultuur**

Sommige workbook‑functies interpreteren tekst volgens cultuur‑specifieke regels. Dit is vooral belangrijk voor functies bedoeld voor talen die double‑byte‑character‑sets (DBCS) gebruiken. Om dergelijke formules correct te berekenen, maak een [LoadOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/), configureer [ISpreadsheetOptions::set_PreferredCulture](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ispreadsheetoptions/set_preferredculture/) via [LoadOptions::set_SpreadsheetOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/), en laad vervolgens de presentatie.

Het volgende voorbeeld selecteert de Japanse cultuur, opent een presentatie met de geconfigureerde load‑options, en roept [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) aan voor elk grafiek‑workbook:

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/SpreadsheetOptions.h>
#include <system/globalization/culture_info.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;
using namespace System::Globalization;

auto japaneseCulture = CultureInfo::GetCultureInfo(u"ja-JP");

auto spreadsheetOptions = MakeObject<SpreadsheetOptions>();
spreadsheetOptions->set_PreferredCulture(japaneseCulture);

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_SpreadsheetOptions(spreadsheetOptions);

auto presentation = MakeObject<Presentation>(u"presentation.pptx", loadOptions);

for (int32_t slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count(); slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);

    for (int32_t shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto shape = slide->get_Shape(shapeIndex);
        if (ObjectExt::Is<IChart>(shape))
        {
            auto chart = ExplicitCast<IChart>(shape);
            chart->get_ChartData()->get_ChartDataWorkbook()->CalculateFormulas();
        }
    }
}
```

De voorkeurscultuur maakt deel uit van de presentatie‑laadconfiguratie, dus specificeer deze vóór het maken van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑instantie. Gebruik de cultuur die overeenkomt met de workbook‑formules; bijvoorbeeld `ja-JP` voor formules die de Japanse DBCS‑berekeningsregels moeten volgen.

## **Herberekening en Gecachede Waarden**

Spreadsheet‑bestanden slaan doorgaans zowel een formule als de laatst berekende waarde op. Aspose.Slides kan daarom een gecachede waarde lezen via [IChartDataCell::get_Value](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatacell/get_value/) wanneer een presentatie wordt geladen en de relevante grafiekgegevens niet zijn gewijzigd.

Na het wijzigen van invoercellen of formules, moet je niet vertrouwen op een oude gecachede uitkomst. Roep [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) aan vóór het uitlezen van berekende waarden of het opslaan van grafiek‑data die ervan afhankelijk zijn.

Voor formules buiten de ondersteunde subset kan Aspose.Slides de formule mogelijk niet parseren of de afhankelijkheden niet vaststellen. Als het workbook is aangepast, kan de vorige gecachede waarde niet langer als betrouwbaar worden beschouwd. In dat geval kan het uitlezen van een cel met niet‑ondersteunde data een [CellUnsupportedDataException](https://reference.aspose.com/slides/nl/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/) veroorzaken.

Als je grafiek afhankelijk is van Excel‑functies die Aspose.Slides niet evalueert, bereken die formules met een spreadsheet‑engine die ze wel ondersteunt en schrijf de resulterende waarden terug naar het grafiek‑workbook. Vervang niet‑ondersteunde formules door geraden waarden.

## **Formule‑Fouten Afhandelen**

Er zijn twee verschillende soorten problemen te onderscheiden.

Een formule kan geldig zijn maar een spreadsheet‑foutresultaat opleveren, zoals `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` of `#VALUE!`. In dat geval is het fout‑token een celresultaat en kan het worden geretourneerd via [IChartDataCell::get_Value](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatacell/get_value/).

Een formule kan ook falen tijdens het parsen, bij referenties, afhankelijkheden of omdat de data niet wordt ondersteund. Aspose.Slides biedt spreadsheet‑specifieke uitzonderingen voor deze gevallen: [CellInvalidFormulaException](https://reference.aspose.com/slides/nl/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/nl/cpp/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/nl/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/), en [CellUnsupportedDataException](https://reference.aspose.com/slides/nl/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Wanneer formules uit sjablonen of gebruikersinvoer komen, handel deze uitzonderingen af rond herberekening en waarde‑toegang:

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
    // Verwerk een circulaire verwijzing.
}
catch (CellUnsupportedDataException&)
{
    // Verwerk niet-ondersteunde spreadsheet-data.
}
```

## **Praktische Beperkingen**

De formule‑ondersteuning in grafiek‑werkbladen is bedoeld voor een gedefinieerde subset van spreadsheet‑berekeningen, niet voor volledige Excel‑compatibiliteit. Houd deze beperkingen in gedachten bij het ontwerpen van een rapportage‑workflow:

- Gebruik alleen de gedocumenteerde constanten, operators, referenties en functies wanneer je wilt dat Aspose.Slides formules herberekent.
- Herbereken na het wijzigen van cellen waar formule‑resultaten van afhangen.
- Beschouw gecachede waarden uit geladen presentaties als momentopnamen, niet als vervanging voor herberekening na bewerkingen.
- Test formules uit bestaande sjablonen voordat je vertrouwt op hun berekende waarden, vooral wanneer ze functies buiten de gedocumenteerde lijst gebruiken.
- Voor formules die een volledige spreadsheet‑berekeningsengine vereisen, bereken ze extern en werk vervolgens het grafiek‑workbook bij met de resulterende waarden.

## **FAQ**

**Wat is het verschil tussen `set_Formula` en `set_R1C1Formula`?**

[IChartDataCell::set_Formula](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatacell/set_formula/) slaat een A1‑style expressie op, bijvoorbeeld `B2-C2`. [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) slaat een R1C1‑style expressie op, bijvoorbeeld `RC[-2]-RC[-1]`. Gebruik de notatie die het beste past bij hoe je formules genereert of kopieert.

**Moet ik de cel zelf lezen of de waarde erna na berekening?**

[IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) geeft een `IChartDataCell` terug. Om het berekende resultaat te verkrijgen, lees je die cel’s [IChartDataCell::get_Value](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatacell/get_value/) na herberekening.

**Wanneer moet ik `CalculateFormulas` aanroepen?**

Roep [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) aan na het wijzigen van invoerwaarden of formules en vóórdat je afhankelijk bent van de berekende resultaten. Dit werkt de waarden van formules die de ingebouwde evaluator ondersteunt bij.

**Ondersteunt Aspose.Slides elke Excel‑functie?**

Nee. De ingebouwde evaluator ondersteunt alleen een gedocumenteerde subset van functies. Functies buiten die subset moeten niet worden verondersteld correct te worden herberekend. Als volledige Excel‑formule‑compatibiliteit vereist is, voer de berekening uit met een geschikte spreadsheet‑engine en schrijf de eindwaarden naar het grafiek‑workbook.

**Wat gebeurt er als een geladen presentatie een niet‑ondersteunde formule bevat?**

Als de grafiek‑data niet is gewijzigd, kan het workbook nog steeds een eerder berekende gecachede waarde bevatten. Nadat gerelateerde data is aangepast, kan die gecachede waarde niet langer geldig zijn. Toegang tot een cel waarvan de formule niet kan worden afgehandeld kan een [CellUnsupportedDataException](https://reference.aspose.com/slides/nl/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/) veroorzaken.

**Zijn formule‑foutwaarden hetzelfde als C++‑exceptions?**

Nee. Een resultaat zoals `#DIV/0!` is een spreadsheet‑waarde die voortkomt uit een geldige berekening. Exceptions zoals [CellInvalidFormulaException](https://reference.aspose.com/slides/nl/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/) of [CellCircularReferenceException](https://reference.aspose.com/slides/nl/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/) geven aan dat de formule niet normaal verwerkt kan worden.

**Werkt een grafiek automatisch bij wanneer een formulecel verandert?**

Een grafiek‑serie kan verwijzen naar workbook‑cellen. Bereken eerst het workbook, sla daarna de presentatie op of render deze. Als de grafiekdatapunten naar de berekende cellen verwijzen, gebruikt de grafiek de bijgewerkte celwaarden; een aparte grafiek‑verversingsmethode is niet nodig voor deze workflow.

**Kunnen grafieken een extern Excel‑workbook gebruiken?**

Ja, grafiek‑data kan worden geconfigureerd om een extern workbook te gebruiken via de grafiek‑data‑API. De hier beschreven formule‑berekeningsworkflow betreft echter het grafiek‑data‑workbook en de formule‑subset die door Aspose.Slides wordt geëvalueerd. Ga er niet van uit dat [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) volledige herberekening van willekeurige formules in een extern XLSX‑bestand biedt.

**Kan ik formules gebruiken die naar een ander werkblad of workbook verwijzen?**

Excel‑style verwijzingen kunnen voorkomen in grafiek‑workbooks, maar formule‑evaluatie is beperkt tot de ondersteunde parser en functieverzameling. Als een cross‑sheet of externe verwijzing essentieel is, verifieer dan de exacte formule met de Aspose.Slides‑versie die je gebruikt. Voor workflows die brede Excel‑referentie‑compatibiliteit vereisen, bereken het workbook extern en schrijf de opgeloste waarden terug naar de grafiek‑data.

**Moeten formule‑strings beginnen met `=`?**

De Aspose.Slides‑API‑voorbeelden wijzen expressies toe zoals `B2-C2` of `SUM(B2:B5)` zonder een leidende `=`. Het gebruik van die vorm houdt gegenereerde formules consistent met de gedocumenteerde API‑voorbeelden.