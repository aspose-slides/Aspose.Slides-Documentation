---
title: Použít vzorce pracovního listu grafu v prezentacích pomocí C++
linktitle: Vzorce pracovního listu
type: docs
weight: 70
url: /cs/cpp/chart-worksheet-formulas/
keywords:
  - graf tabulkový procesor
  - graf pracovní list
  - graf vzorec
  - pracovní list vzorec
  - tabulkový procesor vzorec
  - graf data sešit
  - výpočet vzorce
  - preferovaná kultura
  - kulturně specifický vzorec
  - DBCS
  - logická konstanta
  - číselná konstanta
  - řetězcová konstanta
  - chybová konstanta
  - aritmetický operátor
  - porovnávací operátor
  - styl A1
  - styl R1C1
  - předdefinovaná funkce
  - PowerPoint
  - prezentace
  - C++
  - Aspose.Slides
description: "Použijte vzorce ve stylu Excel v Aspose.Slides pro C++ pracovní listy grafů, přepočtěte hodnoty a použijte výsledky v grafech PowerPointu."
---
## **Přehled**

Grafy PowerPointu obvykle ukládají svá zdrojová data do vloženého listu. V Aspose.Slides pro C++ můžete k tomuto listu přistupovat prostřednictvím sešitu s daty grafu, zapisovat vstupní hodnoty, přiřazovat buňkám vzorce, vypočítávat podporované vzorce a používat vypočítané buňky jako data grafu.

Tento článek vysvětluje kompletní postup práce s vzorci: vytvořit graf, naplnit jeho list, přiřadit vzorce ve stylu A1 nebo R1C1, přepočítat je, načíst vypočítané hodnoty, propojit tyto buňky se sérií grafu a uložit prezentaci. Dále popisuje podporovanou syntaxi vzorců, vestavěný podmnožinu funkcí, uložené hodnoty, nepodporované vzorce a specifické chyby tabulkových procesorů.

## **Tabulky grafů a vzorce**

Sešit grafu obsahuje kategorie, názvy sérií a hodnoty používané grafem. V PowerPointu můžete sešit prohlédnout otevřením editoru dat grafu:

![Graf PowerPointu s otevřeným vloženým listem, zobrazuje data kategorií a sérií](chart-worksheet-formulas_1.png)

V Aspose.Slides je sešit vystaven prostřednictvím rozhraní [IChartDataWorkbook](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdataworkbook/) . Použijte [IChartDataCell::set_Formula](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatacell/set_formula/) pro vzorce ve stylu A1 a [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) pro vzorce ve stylu R1C1. Po změně vstupních buněk nebo vzorců zavolejte [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) , aby se přepočítaly podporované vzorce a aktualizovaly odpovídající hodnoty buněk.

Vypočítaná buňka stále poskytuje svůj výsledek prostřednictvím [IChartDataCell::get_Value](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatacell/get_value/) . To je důležité, když potřebujete v kódu zkontrolovat výsledek vzorce nebo použít buňku jako datový bod grafu.

## **Vytvoření grafu a výpočet vzorců v listu**

Následující příklad ukazuje kompletní postup od začátku do konce. Vytvoří seskupený sloupcový graf, vymaže ukázková data, zapíše čtvrtletní příjmy a výdaje, vypočítá zisk pomocí vzorců, načte výsledky, použije vypočítané buňky jako hodnoty grafu a uloží prezentaci.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/DataLabelCollection.h>
#include <DOM/DataLabelFormat.h>
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

Datové body grafu odkazují na `D2:D4`, takže graf používá vypočítané hodnoty zisku. V tomto postupu není potřeba samostatné volání pro obnovení grafu: nejprve přepočítejte sešit, poté použijte nebo uložte data grafu, která odkazují na vypočítané buňky.

## **Použití vzorců ve stylu A1**

Notace A1 označuje sloupce písmeny a řádky čísly. Přiřaďte výrazy ve stylu A1 pomocí [IChartDataCell::set_Formula](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatacell/set_formula/) .

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

Běžné formy odkazů ve stylu A1 jsou:

| Reference | Relativní | Absolutní | Smíšený |
|---|---|---|---|
| Cell | `A2` | `$A$2` | `A$2`, `$A2` |
| Row | `2:2` | `$2:$2` | — |
| Column | `A:A` | `$A:$A` | — |
| Range | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Relativní odkazy se mohou změnit, když je vzorec v tabulkovém procesoru přesunut nebo zkopírován. Absolutní odkazy udržují obě souřadnice pevné, zatímco smíšené odkazy fixují jen řádek nebo sloupec.

## **Použití vzorců ve stylu R1C1**

Notace R1C1 identifikuje řádky i sloupce číselně. Relativní odkazy používají posuny ve hranatých závorkách. Tento zápis přiřaďte pomocí [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) .

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

Běžné formy odkazů ve stylu R1C1 jsou:

| Reference | Relativní | Absolutní | Smíšený |
|---|---|---|---|
| Cell | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Row | `R[2]` | `R2` | — |
| Column | `C[3]` | `C3` | — |
| Range | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Například v buňce `D2` znamená `RC[-2]` buňku ve stejném řádku o dva sloupce vlevo (`B2`).

## **Konstanty a operátory ve vzorcích**

Vestavěný vyhodnocovač vzorců podporuje logické hodnoty, číselné literály, řetězce, chybové hodnoty tabulkového procesoru, aritmetické operátory a operátory porovnání.

### **Konstanty a literály**

| Typ | Příklady | Poznámky |
|---|---|---|
| Logical | `TRUE`, `FALSE` | Lze použít přímo v logických výrazech, např. `A2=TRUE`. |
| Numeric | `1`, `0.5`, `.3`, `1E-2` | Podporována běžná i vědecká notace. |
| String | `"abc"`, `"2/3/2020 12:00"` | Textové literály jsou ve vzorci uzavřeny v dvojitých uvozovkách. |
| Error result | `#DIV/0!`, `#N/A`, `#REF!` | Platný vzorec může vyhodnotit chybovou hodnotu tabulky místo normálního výsledku. |

Tento příklad používá několik typů konstant:

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

auto logicalValue = workbook->GetCell(0, u"B2")->get_Value(); // Nepravda
auto numericValue = workbook->GetCell(0, u"C2")->get_Value(); // 1.5
auto scientificValue = workbook->GetCell(0, u"D2")->get_Value(); // 0.003
auto stringValue = workbook->GetCell(0, u"E2")->get_Value(); // abc
auto errorValue = workbook->GetCell(0, u"F2")->get_Value(); // #DIV/0!
```

### **Aritmetické operátory**

| Operátor | Význam | Příklad |
|---|---|---|
| `+` | Sčítání nebo unární plus | `2+3` |
| `-` | Odčítání nebo negace | `2-3`, `-3` |
| `*` | Násobení | `2*3` |
| `/` | Dělení | `2/3` |
| `%` | Procento | `30%` |
| `^` | Umocnění | `2^3` |

Použijte závorky pro explicitní určení pořadí vyhodnocení, například `(A2+B2)*C2`.

### **Operátory porovnání**

Výrazy porovnání vracejí logické hodnoty.

| Operátor | Význam | Příklad |
|---|---|---|
| `=` | Rovná se | `A2=3` |
| `<>` | Nerovná se | `A2<>3` |
| `>` | Větší než | `A2>3` |
| `>=` | Větší nebo rovno | `A2>=3` |
| `<` | Menší než | `A2<3` |
| `<=` | Menší nebo rovno | `A2<=3` |

## **Podporované předdefinované funkce**

Aspose.Slides obsahuje vestavěný vyhodnocovač vzorců pro listy grafů, ale nejedná se o kompletní výpočetní engine Excelu. Dokumentovaná množina funkcí je omezena na funkce uvedené níže. Nepředpokládejte, že libovolná Excelová funkce může být přepočítána pomocí [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) .

| Funkce | Účel nebo podporovaná forma | Příklad |
|---|---|---|
| `ABS` | Absolutní hodnota | `ABS(A2)` |
| `AVERAGE` | Aritmetický průměr | `AVERAGE(B2:B5)` |
| `CEILING` | Zaokrouhlí číslo nahoru na násobek | `CEILING(A2,5)` |
| `CHOOSE` | Vybere hodnotu podle indexu | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Spojí textové hodnoty | `CONCAT(A2,B2)` |
| `CONCATENATE` | Spojí textové hodnoty | `CONCATENATE(A2," ",B2)` |
| `DATE` | Vytvoří datum pomocí systému 1900 | `DATE(2026,8,19)` |
| `DAYS` | Vrátí počet dnů mezi daty | `DAYS(B2,A2)` |
| `FIND` | Najde jeden text v jiném | `FIND("-",A2)` |
| `FINDB` | Vyhledávání textu orientované na bajty | `FINDB("a",A2)` |
| `IF` | Podmíněný výsledek | `IF(A2>0,A2,0)` |
| `INDEX` | Referenční forma | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektorová forma | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektorová forma | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximální hodnota | `MAX(B2:B5)` |
| `SUM` | Součet hodnot | `SUM(B2:B5)` |
| `VLOOKUP` | Vertikální vyhledávání | `VLOOKUP(A2,B2:D10,3,FALSE)` |

## **Výpočet vzorců s preferovanou kulturou**

Některé funkce sešitu grafu interpretují text podle kulturně specifických pravidel. To je zvláště důležité pro funkce určené jazykům používajícím dvojbajtové znakové sady (DBCS). Pro správný výpočet takových vzorců vytvořte [LoadOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides/loadoptions/), nakonfigurujte [ISpreadsheetOptions::set_PreferredCulture](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ispreadsheetoptions/set_preferredculture/) přes [LoadOptions::set_SpreadsheetOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/), a poté načtěte prezentaci.

Následující příklad vybere japonskou kulturu, otevře prezentaci s nakonfigurovanými možnostmi načítání a zavolá [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) pro každý sešit grafu:

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

Preferovaná kultura je součástí konfigurace načítání prezentace, takže ji zadejte před vytvořením instance [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) . Použijte kulturu očekávanou vzorci v sešitu; například použijte `ja-JP` pro vzorce, které mají následovat japonská pravidla DBCS výpočtu.

## **Přepočítání a uložené hodnoty**

Tabulkové soubory běžně ukládají jak vzorec, tak jeho poslední vypočítanou hodnotu. Aspose.Slides tak může načíst uloženou hodnotu z [IChartDataCell::get_Value](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatacell/get_value/) , když je prezentace načtena a odpovídající data grafu nebyla změněna.

Po změně vstupních buněk nebo vzorců se nespoléhejte na starý uložený výsledek. Zavolejte [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) před načtením vypočítaných hodnot nebo uložením dat grafu, která na nich závisí.

U vzorců mimo podporovanou podmnožinu může Aspose.Slides být schopno vzorec rozebrat nebo určit jeho závislosti. Pokud byl sešit změněn, předchozí uložená hodnota již nemůže být považována za spolehlivou. V takovém případě může čtení hodnoty buňky s nepodporovanými daty vyvolat [CellUnsupportedDataException](https://reference.aspose.com/slides/cs/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/) .

Pokud váš graf závisí na Excelových funkcích, které Aspose.Slides nevyhodnocuje, vypočítejte tyto vzorce pomocí tabulkového enginu, který je podporuje, a zapište výsledné hodnoty zpět do sešitu grafu. Nepřepisujte nepodporované vzorce odhadovanými hodnotami.

## **Zpracování chyb ve vzorcích**

Existují dva různé typy problémů, které je třeba rozlišit.

Vzorec může být platný, ale produkovat chybový výsledek tabulky, jako je `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` nebo `#VALUE!`. V takovém případě je chybový token výsledkem buňky a může být vrácen přes [IChartDataCell::get_Value](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatacell/get_value/) .

Vzorec může také selhat při parsování, odkazování, závislostech nebo na úrovni podporovaných dat. Aspose.Slides poskytuje specifické výjimky tabulkového procesoru pro tyto případy: [CellInvalidFormulaException](https://reference.aspose.com/slides/cs/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/cs/cpp/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/cs/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/), a [CellUnsupportedDataException](https://reference.aspose.com/slides/cs/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/) .

Když vzorce přicházejí ze šablon nebo uživatelského vstupu, zacházejte s těmito výjimkami okolo přepočítání a přístupu k hodnotě:

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
    // Zpracovat neplatný vzorec.
}
catch (CellInvalidReferenceException&)
{
    // Zpracovat neplatný odkaz na buňku.
}
catch (CellCircularReferenceException&)
{
    // Zpracovat kruhový odkaz.
}
catch (CellUnsupportedDataException&)
{
    // Zpracovat nepodporovaná data tabulky.
}
```

## **Praktická omezení**

Podpora vzorců v listech grafů je určena pro definovanou podmnožinu výpočtů tabulek, nikoli pro úplnou kompatibilitu s Excelem. Mějte tyto omezení na paměti při navrhování pracovních postupů reportování:

- Používejte pouze dokumentované konstanty, operátory, odkazy a funkce, pokud potřebujete, aby Aspose.Slides přepočítalo vzorce.
- Přepočítejte po změně buněk, na nichž výsledky vzorců závisí.
- Ukládané hodnoty z načtených prezentací považujte za snímky, nikoli za náhradu přepočítání po úpravách.
- Otestujte vzorce z existujících šablon, než se spolehnete na jejich vypočítané hodnoty, zejména pokud používají funkce mimo dokumentovaný seznam.
- U vzorců, které vyžadují kompletní výpočetní engine tabulek, je vypočítejte externě a poté aktualizujte sešit grafu výslednými hodnotami.

## **Často kladené otázky**

**Jaký je rozdíl mezi `set_Formula` a `set_R1C1Formula`?**

[IChartDataCell::set_Formula](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatacell/set_formula/) ukládá výraz ve stylu A1, například `B2-C2`. [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) ukládá výraz ve stylu R1C1, například `RC[-2]-RC[-1]`. Použijte notaci, která nejlépe odpovídá tomu, jak vytváříte nebo kopírujete vzorce.

**Musím po výpočtu číst samotnou buňku nebo její hodnotu?**

[IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) vrací `IChartDataCell`. Pro získání vypočítaného výsledku přečtěte hodnotu této buňky pomocí [IChartDataCell::get_Value](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatacell/get_value/) po přepočítání.

**Kdy bych měl zavolat `CalculateFormulas`?**

Zavolejte [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) po změně vstupních hodnot nebo vzorců a před tím, než se spolehnete na vypočítané výsledky. Tím se aktualizují hodnoty vzorců, které podporuje vestavěný vyhodnocovač.

**Podporuje Aspose.Slides všechny Excel funkce?**

Ne. Vestavěný vyhodnocovač podporuje dokumentovanou podmnožinu funkcí. Funkce mimo tuto podmnožinu nelze předpokládat, že se přepočítají správně. Pokud je vyžadována úplná kompatibilita s Excelovými vzorci, proveďte výpočet pomocí vhodného tabulkového enginu a zapíšete konečné hodnoty do sešitu grafu.

**Co se stane, pokud načtená prezentace obsahuje nepodporovaný vzorec?**

Pokud data grafu nebyla změněna, sešit může stále obsahovat dříve vypočítanou uloženou hodnotu. Po změně souvisejících dat již tato uložená hodnota nemusí být platná. Přístup k buňce, jejíž vzorec nelze zpracovat, může vyvolat [CellUnsupportedDataException](https://reference.aspose.com/slides/cs/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/) .

**Jsou hodnoty chyb ve vzorcích stejné jako výjimky C++?**

Ne. Výsledek jako `#DIV/0!` je hodnota tabulky vytvořená platným výpočtem. Výjimky jako [CellInvalidFormulaException](https://reference.aspose.com/slides/cs/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/) nebo [CellCircularReferenceException](https://reference.aspose.com/slides/cs/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/) naznačují, že vzorec nelze normálně zpracovat.

**Aktualizuje se graf automaticky, když se změní buňka s vzorcem?**

Série grafu může odkazovat na buňky sešitu. Nejprve přepočítejte sešit, poté uložte nebo vykreslete prezentaci. Pokud datové body grafu odkazují na vypočítané buňky, graf použije tyto aktualizované hodnoty; samostatná metoda pro obnovení grafu není v tomto postupu potřeba.

**Mohou grafy používat externí Excel sešit?**

Ano, data grafu lze nakonfigurovat tak, aby používala externí sešit přes API dat grafu. Avšak postup výpočtu vzorců popsaný v tomto článku se týká sešitu dat grafu a podmnožiny vzorců, kterou vyhodnocuje Aspose.Slides. Nepředpokládejte, že [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) poskytuje úplné přepočítání libovolných vzorců v externím souboru XLSX.

**Mohu použít vzorce, které odkazují na jiný list nebo sešit?**

Odkazy ve stylu Excel mohou v sešitech grafů existovat, ale vyhodnocování vzorců je omezeno podporovaným parserem a množinou funkcí. Pokud je křížový odkaz na list nebo externí sešit zásadní, ověřte tento konkrétní vzorec s vaší cílovou verzí Aspose.Slides. Pro pracovní postupy, které vyžadují širokou kompatibilitu odkazů Excelu, vypočítejte sešit externě a zapište vyřešené hodnoty zpět do dat grafu.

**Měly by řetězce vzorců začínat znakem `=`?**

Příklady v API Aspose.Slides přiřazují výrazy jako `B2-C2` nebo `SUM(B2:B5)` bez úvodního `=`. Použití tohoto tvaru zachovává generované vzorce v souladu s dokumentovanými příklady API.