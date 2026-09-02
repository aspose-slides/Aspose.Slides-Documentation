---
title: Použití vzorců listu grafu v prezentacích pomocí C++
linktitle: Vzorce listu
type: docs
weight: 70
url: /cs/cpp/chart-worksheet-formulas/
keywords:
- grafová tabulka
- list grafu
- vzorec grafu
- vzorec listu
- vzorec tabulky
- sešit dat grafu
- výpočet vzorce
- logická konstanta
- číselná konstanta
- řetězcová konstanta
- konstanta chyby
- aritmetický operátor
- porovnávací operátor
- styl A1
- styl R1C1
- předdefinovaná funkce
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Použijte vzorce ve stylu Excel v Aspose.Slides pro C++ listy grafů, přepočítejte hodnoty a použijte výsledky v grafech PowerPointu."
---
## **Přehled**

Grafy v PowerPointu obvykle ukládají svá zdrojová data do vloženého listu. V Aspose.Slides pro C++ můžete k tomuto listu přistupovat prostřednictvím sešitu dat grafu, zapisovat vstupní hodnoty, přiřazovat buňkám vzorce, vypočítávat podporované vzorce a použít vypočítané buňky jako data grafu.

Tento článek vysvětluje kompletní tok práce s vzorci: vytvořit graf, naplnit jeho list, přiřadit vzorce ve stylu A1 nebo R1C1, přepočítat je, načíst vypočítané hodnoty, propojit tyto buňky s řadou grafu a uložit prezentaci. Také popisuje podporovanou syntaxi vzorců, vestavěnou podmnožinu funkcí, kešované hodnoty, nepodporované vzorce a chyby specifické pro tabulky.

## **Listy grafu a vzorce**

List grafu obsahuje kategorie, názvy sérií a hodnoty použité v grafu. V PowerPointu můžete list prohlédnout otevřením editoru dat grafu:

![PowerPoint graf s otevřeným vloženým listem, zobrazující data kategorií a sérií](chart-worksheet-formulas_1.png)

V Aspose.Slides je list vystaven prostřednictvím rozhraní[IChartDataWorkbook](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdataworkbook/) . Použijte[IChartDataCell::set_Formula](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatacell/set_formula/) pro vzorce ve stylu A1 a[IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) pro vzorce ve stylu R1C1. Po změně vstupních buněk nebo vzorců zavolejte[IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) pro přepočet podporovaných vzorců a aktualizaci odpovídajících hodnot buněk.

Vypočítaná buňka stále zpřístupňuje svůj výsledek prostřednictvím[IChartDataCell::get_Value](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatacell/get_value/). To je důležité, když potřebujete v kódu zkontrolovat výsledek vzorce nebo použít buňku jako datový bod grafu.

## **Vytvoření grafu a výpočet vzorců v listu**

Následující příklad demonstruje kompletní tok práce. Vytvoří seskupený sloupcový graf, vymaže ukázková data, zapíše čtvrtletní příjmy a výdaje, vypočítá zisk pomocí vzorců, načte výsledky, použije vypočítané buňky jako hodnoty grafu a uloží prezentaci.

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

Datové body grafu odkazují na `D2:D4`, takže graf používá vypočítané hodnoty zisku. V tomto postupu neexistuje samostatné volání pro obnovení grafu: nejprve přepočítejte sešit, poté použijte nebo uložte grafová data, která ukazují na vypočítané buňky.

## **Použití vzorců ve stylu A1**

Notace A1 identifikuje sloupce písmeny a řádky čísly. Přiřaďte výrazy ve stylu A1 pomocí[IChartDataCell::set_Formula](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatacell/set_formula/) .

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

Běžné formy odkazů A1 jsou:

| Odkaz | Relativní | Absolutní | Smíšený |
|---|---|---|---|
| Buňka | `A2` | `$A$2` | `A$2`, `$A2` |
| Řádek | `2:2` | `$2:$2` | — |
| Sloupec | `A:A` | `$A:$A` | — |
| Oblast | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Relativní odkazy se mohou změnit, když je vzorec přesunut nebo zkopírován tabulkovým procesorem. Absolutní odkazy udržují obě souřadnice pevné, zatímco smíšené odkazy fixují pouze řádek nebo sloupec.

## **Použití vzorců ve stylu R1C1**

Notace R1C1 identifikuje jak řádky, tak sloupce číselně. Relativní odkazy používají offsety v hranatých závorkách. Tuto syntaxi přiřaďte pomocí[IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) .

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

Běžné formy odkazů R1C1 jsou:

| Odkaz | Relativní | Absolutní | Smíšený |
|---|---|---|---|
| Buňka | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Řádek | `R[2]` | `R2` | — |
| Sloupec | `C[3]` | `C3` | — |
| Oblast | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Například v buňce `D2` znamená `RC[-2]` buňku ve stejném řádku o dva sloupce vlevo (`B2`).

## **Konstanty a operátory ve vzorcích**

Vestavěný vyhodnocovač vzorců podporuje logické hodnoty, číselné literály, řetězce, chybové hodnoty tabulky, aritmetické operátory a porovnávací operátory.

### **Konstanty a literály**

| Typ | Příklady | Poznámky |
|---|---|---|
| Logické | `TRUE`, `FALSE` | Lze použít přímo v logických výrazech, např. `A2=TRUE`. |
| Číselné | `1`, `0.5`, `.3`, `1E-2` | Podporována běžná i vědecká notace. |
| Řetězec | `"abc"`, `"2/3/2020 12:00"` | Textové literály jsou ve vzorci uzavřeny v dvojitých uvozovkách. |
| Výsledek chyby | `#DIV/0!`, `#N/A`, `#REF!` | Platný vzorec může vyhodnotit chybovou hodnotu tabulky místo normálního výsledku. |

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
| `^` | Exponenciace | `2^3` |

Používejte závorky pro explicitní určení pořadí vyhodnocování, například `(A2+B2)*C2`.

### **Porovnávací operátory**

Porovnávací výrazy vracejí logické hodnoty.

| Operátor | Význam | Příklad |
|---|---|---|
| `=` | Rovná se | `A2=3` |
| `<>` | Nerovná se | `A2<>3` |
| `>` | Větší než | `A2>3` |
| `>=` | Větší nebo rovno | `A2>=3` |
| `<` | Menší než | `A2<3` |
| `<=` | Menší nebo rovno | `A2<=3` |

## **Podporované předdefinované funkce**

Aspose.Slides obsahuje vestavěný vyhodnocovač vzorců pro listy grafů, ale není to kompletní výpočetní engine Excelu. Dokumentovaná sada funkcí je omezena na níže uvedené funkce. Nepředpokládejte, že libovolná Excelová funkce může být přepočítána pomocí[IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) .

| Funkce | Účel nebo podporovaná forma | Příklad |
|---|---|---|
| `ABS` | Absolutní hodnota | `ABS(A2)` |
| `AVERAGE` | Aritmetický průměr | `AVERAGE(B2:B5)` |
| `CEILING` | Zaokrouhlení čísla nahoru na násobek | `CEILING(A2,5)` |
| `CHOOSE` | Výběr hodnoty podle indexu | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Spojení textových hodnot | `CONCAT(A2,B2)` |
| `CONCATENATE` | Spojení textových hodnot | `CONCATENATE(A2," ",B2)` |
| `DATE` | Vytvoření datové hodnoty pomocí systému 1900 | `DATE(2026,8,19)` |
| `DAYS` | Vrací počet dnů mezi daty | `DAYS(B2,A2)` |
| `FIND` | Vyhledá text v jiném textu | `FIND("-",A2)` |
| `FINDB` | Vyhledávání textu po bajtech | `FINDB("a",A2)` |
| `IF` | Podmíněný výsledek | `IF(A2>0,A2,0)` |
| `INDEX` | Referenční forma | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektorová forma | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektorová forma | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximální hodnota | `MAX(B2:B5)` |
| `SUM` | Součet hodnot | `SUM(B2:B5)` |
| `VLOOKUP` | Vertikální vyhledávání | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Omezení uvedená v tabulce jsou podstatná: `INDEX` je dokumentován ve formě reference, zatímco `LOOKUP` a `MATCH` jsou dokumentovány ve svých vektorových formách. `DATE` používá systém 1900. Funkce a vlastnosti, které zde nejsou uvedeny, by měly být považovány za nepodporované vestavěným vyhodnocovačem Aspose.Slides, pokud nejsou zdokumentovány zvlášť.

## **Přepočet a kešované hodnoty**

Tabulkové soubory obvykle ukládají jak vzorec, tak jeho naposledy vypočítanou hodnotu. Aspose.Slides tak může při načtení prezentace a pokud data grafu nebyla změněna, přečíst kešovanou hodnotu z[IChartDataCell::get_Value](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatacell/get_value/) .

Po změně vstupních buněk nebo vzorců nespoléhejte na starý kešovaný výsledek. Před načtením vypočítaných hodnot nebo uložením grafových dat, která na nich závisí, zavolejte[IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) .

Pro vzorce mimo podporovanou podmnožinu může Aspose.Slides být neschopen rozparsovat vzorec nebo stanovit jeho závislosti. Pokud byl sešit modifikován, předchozí kešovaná hodnota už není považována za spolehlivou. V takové situaci může čtení hodnoty buňky s nepodporovanými daty vyvolat[CellUnsupportedDataException](https://reference.aspose.com/slides/cs/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/) .

Pokud váš graf závisí na Excelových funkcích, které Aspose.Slides nevyhodnocuje, vypočítejte tyto vzorce pomocí tabulkového engine, který je podporuje, a zapište získané hodnoty zpět do sešitu grafu. Nepřepisujte nepodporované vzorce odhadovanými hodnotami.

## **Zpracování chyb ve vzorcích**

Existují dva různé typy problémů, které je třeba rozlišovat.

Vzorec může být platný, ale může vrátit chybový výsledek tabulky, například `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` nebo `#VALUE!`. V tomto případě je chybový token výsledkem buňky a může být vrácen prostřednictvím[IChartDataCell::get_Value](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatacell/get_value/) .

Vzorec může také selhat při parsování, referenci, závislostech nebo na úrovni podporovaných dat. Aspose.Slides poskytuje pro tyto případy tabulkově specifické výjimky: [CellInvalidFormulaException](https://reference.aspose.com/slides/cs/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/cs/cpp/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/cs/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/) a [CellUnsupportedDataException](https://reference.aspose.com/slides/cs/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/) .

Když vzorce pocházejí ze šablon nebo vstupu uživatele, ošetřete tyto výjimky kolem přepočtu a přístupu k hodnotám:

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

Podpora vzorců v listech grafů je určena pro definovanou podmnožinu výpočtů tabulek, nikoli pro úplnou kompatibilitu s Excelem. Mějte tyto omezení na paměti při navrhování workflow reportingu:

- Používejte pouze dokumentované konstanty, operátory, odkazy a funkce, pokud chcete, aby Aspose.Slides přepočítal vzorce.
- Přepočítejte po změně buněk, na nichž výsledky vzorců závisí.
- Považujte kešované hodnoty z načtených prezentací za snímky, ne za náhradu přepočtu po úpravách.
- Otestujte vzorce z existujících šablon před spoleháním se na jejich vypočítané hodnoty, zejména pokud používají funkce mimo dokumentovaný seznam.
- Pro vzorce, které vyžadují kompletní výpočetní engine tabulek, je vypočítejte externě a poté aktualizujte list grafu získanými hodnotami.

## **Často kladené otázky**

**Jaký je rozdíl mezi `set_Formula` a `set_R1C1Formula`?**

[IChartDataCell::set_Formula](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatacell/set_formula/) ukládá výraz ve stylu A1, například `B2-C2`. [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) ukládá výraz ve stylu R1C1, například `RC[-2]-RC[-1]`. Použijte notaci, která nejlépe odpovídá tomu, jak vzorce generujete nebo kopírujete.

**Musím po výpočtu číst samotnou buňku nebo její hodnotu?**

[IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) vrací `IChartDataCell`. Pro získání vypočítaného výsledku přečtěte hodnotu této buňky pomocí[IChartDataCell::get_Value](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatacell/get_value/) po přepočtu.

**Kdy mám zavolat `CalculateFormulas`?**

Zavolejte[IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) po změně vstupních hodnot nebo vzorců a před tím, než budete záviset na vypočítaných výsledcích. Tím se aktualizují hodnoty vzorců, které vestavěný vyhodnocovač podporuje.

**Podporuje Aspose.Slides každou Excelovou funkci?**

Ne. Vestavěný vyhodnocovač podporuje dokumentovanou podmnožinu funkcí. Funkce mimo tuto podmnožinu by neměly být považovány za správně přepočítatelné. Pokud je požadována plná kompatibilita s Excelovými vzorci, proveďte výpočet pomocí vhodného tabulkového engine a zapište finální hodnoty do listu grafu.

**Co se stane, když načtená prezentace obsahuje nepodporovaný vzorec?**

Pokud data grafu nebyla změněna, sešit může stále obsahovat dříve vypočítanou kešovanou hodnotu. Po úpravě souvisejících dat tato kešovaná hodnota může přestat být platná. Přístup k buňce, jejíž vzorec není možné zpracovat, může vyvolat[CellUnsupportedDataException](https://reference.aspose.com/slides/cs/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/) .

**Jsou hodnoty chyb ve vzorci stejné jako výjimky v C++?**

Ne. Výsledek jako `#DIV/0!` je hodnota tabulky vytvořená platným výpočtem. Výjimky jako [CellInvalidFormulaException](https://reference.aspose.com/slides/cs/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/) nebo [CellCircularReferenceException](https://reference.aspose.com/slides/cs/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/) signalizují, že vzorec nelze normálně zpracovat.

**Aktualizuje se graf automaticky, když se změní buňka s vzorcem?**

Řada grafu může odkazovat na buňky sešitu. Nejprve přepočítejte sešit, poté uložte nebo vykreslete prezentaci. Pokud datové body grafu odkazují na vypočítané buňky, graf použije tyto aktualizované hodnoty; samostatná metoda pro obnovení grafu není v tomto postupu vyžadována.

**Mohou grafy používat externí Excelový sešit?**

Ano, data grafu lze nakonfigurovat tak, aby používala externí sešit prostřednictvím API dat grafu. Nicméně workflow výpočtu vzorců popsané v tomto článku se týká sešitu dat grafu a podmnožiny vzorců vyhodnocovaných Aspose.Slides. Nepředpokládejte, že[IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) poskytuje úplný přepočet libovolných vzorců v externím souboru XLSX.

**Mohu použít vzorce, které odkazují na jiný list nebo sešit?**

Odkazy ve stylu Excelu mohou v listech grafů existovat, ale vyhodnocování vzorců je omezené podporovaným parserem a sadou funkcí. Pokud je nezbytný odkaz napříč listy nebo na externí sešit, ověřte přesný vzorec s verzí Aspose.Slides, kterou používáte. Pro workflow vyžadující širokou kompatibilitu odkazů Excelu vypočítejte sešit externě a přepište vyřešené hodnoty zpět do dat grafu.

**Mají řetězce vzorců začínat znakem `=`?**

Příklady v API Aspose.Slides přiřazují výrazy jako `B2-C2` nebo `SUM(B2:B5)` bez úvodního `=`. Použití tohoto tvaru udržuje generované vzorce konzistentní s dokumentovanými příklady API.