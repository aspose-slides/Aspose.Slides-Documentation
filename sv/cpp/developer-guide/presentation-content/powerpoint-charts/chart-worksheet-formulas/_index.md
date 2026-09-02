---
title: Applicera diagramarbetsbladsformler i presentationer med C++
linktitle: Arbetsbladsformler
type: docs
weight: 70
url: /sv/cpp/chart-worksheet-formulas/
keywords:
- diagram kalkylblad
- diagram arbetsblad
- diagramformel
- arbetsbladsformel
- kalkylbladsformel
- diagramdatabok
- formelberäkning
- logisk konstant
- numerisk konstant
- strängkonstant
- felkonstant
- aritmetisk operator
- jämförelsoperator
- A1 stil
- R1C1 stil
- fördefinierad funktion
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Applicera Excel-liknande formler i Aspose.Slides för C++-diagramarbetsblad, beräkna om värden och använd resultaten i PowerPoint-diagram."
---
## **Översikt**

PowerPoint‑diagram lagrar vanligtvis sina källdata i ett inbäddat kalkylblad. I Aspose.Slides för C++ kan du komma åt det kalkylbladet via diagrammets datarbok, skriva invärden, tilldela formler till celler, beräkna stödjade formler och använda de beräknade cellerna som diagramdata.

Denna artikel förklarar hela formelarbetsflödet: skapa ett diagram, fyll i dess kalkylblad, tilldela A1‑ eller R1C1‑stil‑formler, beräkna dem på nytt, läs de beräknade värdena, anslut dessa celler till en diagramserie och spara presentationen. Den beskriver också den stödjade formulasyntaxen, den inbyggda funktionsuppsättningen, cachade värden, icke‑stödjade formler och kalkylblads‑specifika fel.

## **Diagram‑kalkylblad och formler**

Ett diagram‑kalkylblad innehåller kategorier, serienamn och värden som används av ett diagram. I PowerPoint kan du inspektera kalkylbladet genom att öppna diagramdata‑redigeraren:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

I Aspose.Slides exponeras kalkylbladet via gränssnittet [IChartDataWorkbook](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartdataworkbook/). Använd [IChartDataCell::set_Formula](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartdatacell/set_formula/) för A1‑stil‑formler och [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) för R1C1‑stil‑formler. Efter att du ändrat inmatningsceller eller formler, anropa [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) för att beräkna stödjade formler och uppdatera motsvarande cellvärden.

En beräknad cell exponerar fortfarande sitt resultat via [IChartDataCell::get_Value](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartdatacell/get_value/). Detta är viktigt när du behöver inspektera ett formelresultat i kod eller använda cellen som ett diagramdatapunkt.

## **Skapa ett diagram och beräkna kalkylblads‑formler**

Följande exempel demonstrerar ett end‑to‑end‑arbetsflöde. Det skapar ett grupperat stapeldiagram, rensar exempeldata, skriver kvartalsvisa intäkts‑ och kostnadsvärden, beräknar vinst med formler, läser resultaten, använder de beräknade cellerna som diagramvärden och sparar presentationen.

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

Diagramdatapunkterna refererar till `D2:D4`, så diagrammet använder de beräknade vinstvärdena. Det finns inget separat diagram‑uppdateringsanrop i detta arbetsflöde: beräkna arbetsboken först, använd eller spara sedan diagramdata som pekar på de beräknade cellerna.

## **Använd A1‑stil‑formler**

A1‑notation identifierar kolumner med bokstäver och rader med siffror. Tilldela A1‑stil‑uttryck via [IChartDataCell::set_Formula](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartdatacell/set_formula/).

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

Vanliga A1‑referensformer är:

| Referens | Relativ | Absolut | Blandad |
|---|---|---|---|
| Cell | `A2` | `$A$2` | `A$2`, `$A2` |
| Rad | `2:2` | `$2:$2` | — |
| Kolumn | `A:A` | `$A:$A` | — |
| Område | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Relativa referenser kan ändras när en formel flyttas eller kopieras av ett kalkylbladsprogram. Absoluta referenser håller båda koordinaterna fasta, medan blandade referenser fixerar endast en rad eller en kolumn.

## **Använd R1C1‑stil‑formler**

R1C1‑notation identifierar både rader och kolumner numeriskt. Relativa referenser använder avstånd inom hakparenteser. Tilldela denna syntax via [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/).

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

Vanliga R1C1‑referensformer är:

| Referens | Relativ | Absolut | Blandad |
|---|---|---|---|
| Cell | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Rad | `R[2]` | `R2` | — |
| Kolumn | `C[3]` | `C3` | — |
| Område | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Till exempel, i cell `D2` betyder `RC[-2]` cellen i samma rad två kolumner åt vänster (`B2`).

## **Formelkonstanter och operatorer**

Den inbyggda formelutvärderaren stödjer logiska värden, numeriska literaler, strängar, kalkylbladsfelvärden, aritmetiska operatorer och jämförelseoperatorer.

### **Konstanter och literaler**

| Typ | Exempel | Anteckningar |
|---|---|---|
| Logisk | `TRUE`, `FALSE` | Kan användas direkt i logiska uttryck som `A2=TRUE`. |
| Numerisk | `1`, `0.5`, `.3`, `1E-2` | Vanlig och vetenskaplig notation stödjs. |
| Sträng | `"abc"`, `"2/3/2020 12:00"` | Textliteraler omges av dubbla citationstecken i formeln. |
| Felresultat | `#DIV/0!`, `#N/A`, `#REF!` | En giltig formula kan utvärderas till ett kalkylbladsfelvärde istället för ett normalt resultat. |

Detta exempel använder flera konstanttyper:

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

auto logicalValue = workbook->GetCell(0, u"B2")->get_Value(); // Falskt
auto numericValue = workbook->GetCell(0, u"C2")->get_Value(); // 1.5
auto scientificValue = workbook->GetCell(0, u"D2")->get_Value(); // 0.003
auto stringValue = workbook->GetCell(0, u"E2")->get_Value(); // abc
auto errorValue = workbook->GetCell(0, u"F2")->get_Value(); // #DIV/0!
```

### **Aritmetiska operatorer**

| Operator | Betydelse | Exempel |
|---|---|---|
| `+` | Addition eller unärt plus | `2+3` |
| `-` | Subtraktion eller negation | `2-3`, `-3` |
| `*` | Multiplikation | `2*3` |
| `/` | Division | `2/3` |
| `%` | Procent | `30%` |
| `^` | Exponentiering | `2^3` |

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

Aspose.Slides innehåller en inbyggd formelutvärderare för diagram‑kalkylblad, men den är inte en fullständig Excel‑beräkningsmotor. Den dokumenterade funktionsuppsättningen är begränsad till funktionerna nedan. Anta inte att en godtycklig Excel‑funktion kan beräknas av [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/).

| Funktion | Syfte eller stödjad form | Exempel |
|---|---|---|
| `ABS` | Absolutvärde | `ABS(A2)` |
| `AVERAGE` | Aritmetiskt medelvärde | `AVERAGE(B2:B5)` |
| `CEILING` | Runda upp ett tal till en multipel | `CEILING(A2,5)` |
| `CHOOSE` | Välj ett värde med index | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Sammanfoga textvärden | `CONCAT(A2,B2)` |
| `CONCATENATE` | Sammanfoga textvärden | `CONCATENATE(A2," ",B2)` |
| `DATE` | Skapa ett datumvärde med 1900‑datumsystemet | `DATE(2026,8,19)` |
| `DAYS` | Returnera antal dagar mellan datum | `DAYS(B2,A2)` |
| `FIND` | Hitta en textsträng i en annan | `FIND("-",A2)` |
| `FINDB` | Byte‑orienterad text­sökning | `FINDB("a",A2)` |
| `IF` | Villkorligt resultat | `IF(A2>0,A2,0)` |
| `INDEX` | Referensform | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektorform | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektorform | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximumvärde | `MAX(B2:B5)` |
| `SUM` | Summan av värden | `SUM(B2:B5)` |
| `VLOOKUP` | Vertikal sökning | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Begränsningarna i tabellen är betydelsefulla: `INDEX` är dokumenterad i referensform, medan `LOOKUP` och `MATCH` är dokumenterade i sina vektorformer. `DATE` använder 1900‑datumsystemet. Funktioner och egenskaper som inte finns med här bör betraktas som icke‑stödjade av Aspose.Slides formelutvärderare om de inte är dokumenterade separat.

## **Omberegning och cachade värden**

Kalkylbladsfiler lagrar ofta både en formel och dess senast beräknade värde. Aspose.Slides kan därför läsa ett cachat värde från [IChartDataCell::get_Value](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartdatacell/get_value/) när en presentation laddas och den relevanta diagramdatan inte har ändrats.

Efter att du ändrat inmatningsceller eller formler, förlita dig inte på ett gammalt cache‑resultat. Anropa [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) innan du läser beräknade värden eller sparar diagramdata som beror på dem.

För formler utanför den stödjade delmängden kan Aspose.Slides misslyckas med att tolka formeln eller fastställa dess beroenden. Om arbetsboken har modifierats kan det tidigare cachade värdet inte längre anses pålitligt. I en sådan situation kan läsning av en cells värde med otillåten data kasta [CellUnsupportedDataException](https://reference.aspose.com/slides/sv/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Om ditt diagram beror på Excel‑funktioner som Aspose.Slides inte utvärderar, beräkna dessa formler med en kalkylblads­motor som stödjer dem och skriv tillbaka de resulterande värdena till diagram‑arbetsboken. Ersätt inte otillåtna formler med gissade värden.

## **Hantera formelfel**

Det finns två olika typer av problem att skilja på.

En formel kan vara giltig men producera ett kalkylbladsfelresultat såsom `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` eller `#VALUE!`. I så fall är fel‑tokenen ett cellresultat och kan returneras via [IChartDataCell::get_Value](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartdatacell/get_value/).

En formel kan också misslyckas vid parsning, referens, beroende eller på stödda‑data‑nivån. Aspose.Slides tillhandahåller kalkylblads‑specifika undantag för dessa fall: [CellInvalidFormulaException](https://reference.aspose.com/slides/sv/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/sv/cpp/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/sv/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/) och [CellUnsupportedDataException](https://reference.aspose.com/slides/sv/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

När formler kommer från mallar eller användarinmatning, hantera dessa undantag runt omberäkning och värdeåtkomst:

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
    // Hantera en ogiltig formel.
}
catch (CellInvalidReferenceException&)
{
    // Hantera en ogiltig cellreferens.
}
catch (CellCircularReferenceException&)
{
    // Hantera en cirkulär referens.
}
catch (CellUnsupportedDataException&)
{
    // Hantera ej stödd kalkylbladsdata.
}
```

## **Praktiska begränsningar**

Formelstödet i diagram‑kalkylblad är avsett för en definierad delmängd av kalkylbladsberäkningar, inte för full Excel‑kompatibilitet. Ha dessa begränsningar i åtanke när du designar ett rapporteringsarbetsflöde:

- Använd endast de dokumenterade konstanterna, operatorerna, referenserna och funktionerna när du vill att Aspose.Slides ska beräkna formler.
- Beräkna om efter att du ändrat celler som formelresultaten beror på.
- Betrakta cachade värden från inlästa presentationer som ögonblicksbilder, inte som ett substitut för omberäkning efter redigering.
- Testa formler från befintliga mallar innan du förlitar dig på deras beräknade värden, särskilt när de använder funktioner utanför den dokumenterade listan.
- För formler som kräver en fullständig kalkylblads­beräkningsmotor, beräkna dem externt och uppdatera sedan diagram‑arbetsboken med de resulterande värdena.

## **FAQ**

**Vad är skillnaden mellan `set_Formula` och `set_R1C1Formula`?**

[IChartDataCell::set_Formula](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartdatacell/set_formula/) lagrar ett A1‑stil‑uttryck såsom `B2-C2`. [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) lagrar ett R1C1‑stil‑uttryck såsom `RC[-2]-RC[-1]`. Använd den notation som bäst matchar hur du genererar eller kopierar formler.

**Behöver jag läsa själva cellen eller dess värde efter beräkning?**

[IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) returnerar ett `IChartDataCell`. För att få det beräknade resultatet, läs den cellens [IChartDataCell::get_Value](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartdatacell/get_value/) efter omberäkning.

**När bör jag anropa `CalculateFormulas`?**

Anropa [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) efter att du ändrat inmatningsvärden eller formler och innan du förlitar dig på de beräknade resultaten. Detta uppdaterar värdena för formler som den inbyggda utvärderaren stödjer.

**Stöder Aspose.Slides varje Excel‑funktion?**

Nej. Den inbyggda utvärderaren stödjer en dokumenterad delmängd av funktioner. Funktioner utanför den delmängden bör inte antas beräknas korrekt. Om full Excel‑formelkompatibilitet krävs, utför beräkningen med en lämplig kalkylblads­motor och skriv de slutgiltiga värdena till diagram‑arbetsboken.

**Vad händer om en inläst presentation innehåller en otillåten formel?**

Om diagramdata inte har ändrats kan arbetsboken fortfarande innehålla ett tidigare beräknat cachat värde. Efter att relaterad data ändras kan detta cachade värde vara ogiltigt. Att komma åt en cell vars formel inte kan hanteras kan kasta [CellUnsupportedDataException](https://reference.aspose.com/slides/sv/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**Är formelfelvärden samma sak som C++‑undantag?**

Nej. Ett resultat som `#DIV/0!` är ett kalkylbladsvärde skapat av en giltig beräkning. Undantag såsom [CellInvalidFormulaException](https://reference.aspose.com/slides/sv/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/) eller [CellCircularReferenceException](https://reference.aspose.com/slides/sv/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/) indikerar att formeln inte kan bearbetas normalt.

**Uppdateras ett diagram automatiskt när en formelcell ändras?**

En diagramserie kan referera till arbetsboks‑celler. Beräkna arbetsboken först, spara eller rendera sedan presentationen. Om diagramdatapunkterna refererar till de beräknade cellerna använder diagrammet de uppdaterade cellvärdena; inget separat diagram‑uppdateringsmetod behövs för detta arbetsflöde.

**Kan diagram använda en extern Excel‑arbetsbok?**

Ja, diagramdata kan konfigureras att använda en extern arbetsbok via diagram‑data‑API:t. Dock avser arbetsflödet som beskrivs i den här artikeln diagram‑arbetsboken och den formeldelmängd som utvärderas av Aspose.Slides. Anta inte att [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) ger full omberäkning av godtyckliga formler i en extern XLSX‑fil.

**Kan jag använda formler som refererar till ett annat kalkylblad eller en annan arbetsbok?**

Excel‑stil‑referenser kan finnas i diagram‑arbetsböcker, men formelutvärderingen är begränsad av den stödjade parsern och funktionsuppsättningen. Om en tvär‑blad‑ eller extern referens är väsentlig, verifiera att exakt formel fungerar med din mål‑version av Aspose.Slides. För arbetsflöden som kräver bred Excel‑referens‑kompatibilitet, beräkna arbetsboken externt och skriv de lösta värdena tillbaka till diagramdata.

**Ska formelsträngar börja med `=`?**

Aspose.Slides‑API‑exemplen tilldelar uttryck såsom `B2-C2` eller `SUM(B2:B5)` utan inledande `=`. Att använda den formen håller genererade formler i linje med de dokumenterade API‑exemplen.