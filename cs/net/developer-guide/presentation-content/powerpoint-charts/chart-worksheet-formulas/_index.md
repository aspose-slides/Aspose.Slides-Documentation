---
title: Použít vzorce listu grafu v prezentacích v .NET
linktitle: Vzorce listu
type: docs
weight: 70
url: /cs/net/chart-worksheet-formulas/
keywords:
- graf tabulka
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
- .NET
- C#
- Aspose.Slides
description: "Použijte Excelové vzorce v listech grafů v Aspose.Slides pro .NET, přepočítejte hodnoty a použijte výsledky v grafech PowerPointu."
---
## **Přehled**

PowerPoint grafy obvykle ukládají svá zdrojová data do vloženého listu. V Aspose.Slides pro .NET můžete k tomuto listu přistupovat prostřednictvím sešitu s daty grafu, zapisovat vstupní hodnoty, přiřazovat buňkám vzorce, vypočítávat podporované vzorce a používat vypočítané buňky jako data grafu.

Tento článek vysvětluje kompletní workflow vzorců: vytvořit graf, naplnit jeho list, přiřadit vzorce ve stylu A1 nebo R1C1, přepočítat je, přečíst vypočítané hodnoty, propojit tyto buňky s řadou grafu a uložit prezentaci. Také popisuje podporovanou syntaxi vzorců, podmnožinu vestavěných funkcí, cachované hodnoty, nepodporované vzorce a chyby specifické pro tabulky.

## **Listy grafů a vzorce**

List grafu obsahuje kategorie, názvy řad a hodnoty používané grafem. V PowerPointu můžete list zkontrolovat otevřením editoru dat grafu:

![PowerPoint graf s otevřeným vloženým listem, zobrazující data kategorií a řad](chart-worksheet-formulas_1.png)

V Aspose.Slides je list vystaven prostřednictvím [sešitu s daty grafu](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdataworkbook/). Použijte vlastnost [Formula](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatacell/formula/) pro vzorce ve stylu A1 a vlastnost [R1C1Formula](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatacell/r1c1formula/) pro vzorce ve stylu R1C1. Po změně vstupních buněk nebo vzorců zavolejte [CalculateFormulas](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) pro přepočet podporovaných vzorců a aktualizaci odpovídajících hodnot buněk.

Vypočítaná buňka stále vystavuje svůj výsledek prostřednictvím vlastnosti [Value](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatacell/value/). To je důležité, když potřebujete v kódu zkontrolovat výsledek vzorce nebo použít buňku jako datový bod grafu.

## **Vytvoření grafu a výpočet vzorců v listu**

Následující příklad ukazuje end-to-end workflow. Vytvoří sloupcový seskupený graf, vymaže ukázková data, zapíše čtvrtletní příjmy a výdaje, vypočítá profit pomocí vzorců, přečte výsledky, použije vypočítané buňky jako hodnoty grafu a uloží prezentaci.

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

Datové body grafu odkazují na `D2:D4`, takže graf používá vypočítané hodnoty profitu. V tomto workflow není potřeba samostatné volání pro obnovení grafu: nejprve přepočítejte sešit, pak použijte nebo uložte data grafu, která odkazují na vypočítané buňky.

## **Použití vzorců ve stylu A1**

Notace A1 identifikuje sloupce písmeny a řádky čísly. Přiřaďte výrazy ve stylu A1 pomocí [IChartDataCell.Formula](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatacell/formula/).

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

Obvyklé formy odkazů A1 jsou:

| Reference | Relativní | Absolutní | Smíšené |
|---|---|---|---|
| Buňka | `A2` | `$A$2` | `A$2`, `$A2` |
| Řádek | `2:2` | `$2:$2` | — |
| Sloupec | `A:A` | `$A:$A` | — |
| Rozsah | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Relativní odkazy se mohou změnit, když je vzorec přesunut nebo zkopírován tabulkovým aplikací. Absolutní odkazy fixují oba souřadnice, zatímco smíšené odkazy fixují jen řádek nebo jen sloupec.

## **Použití vzorců ve stylu R1C1**

Notace R1C1 identifikuje jak řádky, tak sloupce číselně. Relativní odkazy používají offsety v hranatých závorkách. Přiřaďte tuto syntaxi pomocí [IChartDataCell.R1C1Formula](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatacell/r1c1formula/).

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

Obvyklé formy odkazů R1C1 jsou:

| Reference | Relativní | Absolutní | Smíšené |
|---|---|---|---|
| Buňka | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Řádek | `R[2]` | `R2` | — |
| Sloupec | `C[3]` | `C3` | — |
| Rozsah | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Například v buňce `D2` znamená `RC[-2]` buňku ve stejném řádku o dva sloupce vlevo (`B2`).

## **Konstanty vzorců a operátory**

Vestavěný evaluátor vzorců podporuje logické hodnoty, číselné literály, řetězce, hodnoty chyb tabulky, aritmetické operátory a porovnávací operátory.

### **Konstanty a literály**

| Typ | Příklady | Poznámky |
|---|---|---|
| Logické | `TRUE`, `FALSE` | Lze použít přímo v logických výrazech, například `A2=TRUE`. |
| Číselné | `1`, `0.5`, `.3`, `1E-2` | Jsou podporovány běžné i vědecké zápisy. |
| Řetězec | `"abc"`, `"2/3/2020 12:00"` | Textové literály jsou ve vzorci uzavřeny v dvojitých uvozovkách. |
| Výsledek chyby | `#DIV/0!`, `#N/A`, `#REF!` | Platný vzorec může vyhodnotit hodnotu chyby tabulky místo normálního výsledku. |

Tento příklad používá několik typů konstant:

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

var logicalValue = workbook.GetCell(0, "B2").Value; // Nepravda
var numericValue = workbook.GetCell(0, "C2").Value; // 1.5
var scientificValue = workbook.GetCell(0, "D2").Value; // 0.003
var stringValue = workbook.GetCell(0, "E2").Value; // abc
var errorValue = workbook.GetCell(0, "F2").Value; // #DIV/0!
```

### **Aritmetické operátory**

| Operátor | Význam | Příklad |
|---|---|---|
| `+` | Sčítání nebo unární plus | `2+3` |
| `-` | Odečítání nebo negace | `2-3`, `-3` |
| `*` | Násobení | `2*3` |
| `/` | Dělení | `2/3` |
| `%` | Procento | `30%` |
| `^` | Umocnění | `2^3` |

Používejte závorky pro explicitní určení pořadí vyhodnocení, například `(A2+B2)*C2`.

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

Aspose.Slides obsahuje vestavěný evaluátor vzorců pro listy grafů, ale nejedná se o kompletní výpočetní engine Excelu. Dokumentovaná sada funkcí je omezena na níže uvedené funkce. Nepředpokládejte, že libovolná Excel funkce může být přepočtena pomocí [CalculateFormulas](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/).

| Funkce | Účel nebo podporovaná forma | Příklad |
|---|---|---|
| `ABS` | Absolutní hodnota | `ABS(A2)` |
| `AVERAGE` | Aritmetický průměr | `AVERAGE(B2:B5)` |
| `CEILING` | Zaokrouhlit číslo nahoru na násobek | `CEILING(A2,5)` |
| `CHOOSE` | Vybrat hodnotu podle indexu | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Spojit textové hodnoty | `CONCAT(A2,B2)` |
| `CONCATENATE` | Spojit textové hodnoty | `CONCATENATE(A2," ",B2)` |
| `DATE` | Vytvořit datum pomocí systému 1900 | `DATE(2026,8,19)` |
| `DAYS` | Vrátit počet dnů mezi daty | `DAYS(B2,A2)` |
| `FIND` | Najít jeden text uvnitř druhého | `FIND("-",A2)` |
| `FINDB` | Vyhledávání orientované na bajty | `FINDB("a",A2)` |
| `IF` | Podmíněný výsledek | `IF(A2>0,A2,0)` |
| `INDEX` | Referenční forma | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektorová forma | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektorová forma | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximální hodnota | `MAX(B2:B5)` |
| `SUM` | Součet hodnot | `SUM(B2:B5)` |
| `VLOOKUP` | Vertikální vyhledávání | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Omezení uvedená v tabulce jsou podstatná: `INDEX` je zdokumentován v referenční formě, zatímco `LOOKUP` a `MATCH` jsou zdokumentovány ve svých vektorových formách. `DATE` používá systém dat 1900. Funkce a vlastnosti, které zde nejsou uvedeny, by měly být považovány za nepodporované vestavěným evaluátorem Aspose.Slides, pokud nejsou samostatně zdokumentovány.

## **Přepočet a cachované hodnoty**

Soubory tabulek často ukládají jak vzorec, tak jeho naposledy vypočtenou hodnotu. Aspose.Slides může proto při načtení prezentace a pokud se data grafu nezměnila, přečíst cachovanou hodnotu z [IChartDataCell.Value](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatacell/value/).

Po změně vstupních buněk nebo vzorců nespoléhejte na starý cachovaný výsledek. Zavolejte [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) před čtením vypočítaných hodnot nebo uložením dat grafu, která na nich závisí.

Pro vzorce mimo podporovanou podmnožinu může Aspose.Slides nedokázat vzorec parsovat nebo zjistit jeho závislosti. Pokud byl sešit upraven, předchozí cachovaná hodnota již není spolehlivá. V takové situaci může čtení hodnoty buňky s nepodporovanými daty vyvolat [CellUnsupportedDataException](https://reference.aspose.com/slides/cs/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Pokud váš graf závisí na Excel funkcích, které Aspose.Slides nevyhodnocuje, vypočítejte tyto vzorce pomocí tabulkového enginu, který je podporuje, a zapište výsledné hodnoty zpět do sešitu grafu. Nepřepisujte nepodporované vzorce odhadovanými hodnotami.

## **Zpracování chyb vzorců**

Existují dva různé typy problémů, které je třeba rozlišovat.

Vzorec může být platný, ale vrátit výsledek chyby tabulky, například `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` nebo `#VALUE!`. V tomto případě je token chyby výsledkem buňky a může být vrácen přes `Value`.

Vzorec může také selhat při parsování, odkazování, závislostech nebo na úrovni podporovaných dat. Aspose.Slides poskytuje pro tyto případy tabulkové výjimky: [CellInvalidFormulaException](https://reference.aspose.com/slides/cs/net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/cs/net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/cs/net/aspose.slides.spreadsheet/cellcircularreferenceexception/), a [CellUnsupportedDataException](https://reference.aspose.com/slides/cs/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Když vzorce pocházejí ze šablon nebo vstupu uživatele, obalte tyto výjimky kolem přepočtu a přístupu k hodnotám:

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

## **Praktická omezení**

Podpora vzorců v listech grafů je určena pro definovanou podmnožinu výpočtů tabulek, nikoli pro úplnou kompatibilitu s Excelem. Mějte tyto omezení na paměti při navrhování workflow reportování:

- Používejte pouze dokumentované konstanty, operátory, reference a funkce, pokud chcete, aby Aspose.Slides přepočítal vzorce.
- Přepočítejte po změně buněk, na nichž výsledek vzorce závisí.
- Považujte cachované hodnoty z načtených prezentací za snímky, ne za náhradu přepočtu po úpravách.
- Otestujte vzorce z existujících šablon před tím, než se spolehnete na jejich vypočítané hodnoty, zejména pokud používají funkce mimo dokumentovaný seznam.
- Pro vzorce, které vyžadují plný výpočetní engine tabulek, je vypočítejte externě a poté aktualizujte sešit grafu s výslednými hodnotami.

## **FAQ**

**Jaký je rozdíl mezi `Formula` a `R1C1Formula`?**

[Formula](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatacell/formula/) ukládá výraz ve stylu A1, například `B2-C2`. [R1C1Formula](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatacell/r1c1formula/) ukládá výraz ve stylu R1C1, například `RC[-2]-RC[-1]`. Použijte notaci, která nejlépe odpovídá tomu, jak vzorce generujete nebo kopírujete.

**Musím po výpočtu číst buňku samotnou nebo její hodnotu?**

[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdataworkbook/getcell/) vrací `IChartDataCell`. Pro získání vypočítaného výsledku přečtěte vlastnost [Value](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatacell/value/) té buňky po přepočtu.

**Kdy mám volat `CalculateFormulas`?**

Zavolejte [CalculateFormulas](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) po změně vstupních hodnot nebo vzorců a před tím, než budete záviset na vypočítaných výsledcích. Tím aktualizujete hodnoty vzorců, které vestavěný evaluátor podporuje.

**Podporuje Aspose.Slides každou Excel funkci?**

Ne. Vestavěný evaluátor podporuje dokumentovanou podmnožinu funkcí. Funkce mimo tuto podmnožinu by neměly být předpokládány jako správně přepočtené. Pokud je vyžadována plná kompatibilita s Excel vzorci, proveďte výpočet pomocí vhodného tabulkového enginu a zapište konečné hodnoty do sešitu grafu.

**Co se stane, pokud načtená prezentace obsahuje nepodporovaný vzorec?**

Pokud se data grafu nezměnila, může sešit stále obsahovat dříve vypočítanou cachovanou hodnotu. Po úpravě souvisejících dat tato cachovaná hodnota může přestat být platná. Přístup k buňce, jejíž vzorec nelze zpracovat, může vyvolat [CellUnsupportedDataException](https://reference.aspose.com/slides/cs/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**Jsou hodnoty chyb vzorců stejné jako výjimky .NET?**

Ne. Výsledek jako `#DIV/0!` je hodnota tabulky vytvořená platným výpočtem. Výjimky jako [CellInvalidFormulaException](https://reference.aspose.com/slides/cs/net/aspose.slides.spreadsheet/cellinvalidformulaexception/) nebo [CellCircularReferenceException](https://reference.aspose.com/slides/cs/net/aspose.slides.spreadsheet/cellcircularreferenceexception/) značí, že vzorec nelze běžně zpracovat.

**Aktualizuje se graf automaticky, když se změní buňka vzorce?**

Řada grafu může odkazovat na buňky sešitu. Přepočítejte sešit nejdříve, pak uložte nebo renderujte prezentaci. Pokud datové body grafu odkazují na vypočítané buňky, graf používá tyto aktualizované hodnoty; není potřeba samostatná metoda pro obnovu grafu v tomto workflow.

**Mohou grafy používat externí Excel sešit?**

Ano, data grafu lze nakonfigurovat tak, aby používala externí sešit pomocí API grafu. Nicméně workflow výpočtu vzorců popsaný v tomto článku se týká sešitu dat grafu a podmnožiny vzorců vyhodnocovaných Aspose.Slides. Nepředpokládejte, že [CalculateFormulas](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) poskytuje úplný přepočet libovolných vzorců v externím souboru XLSX.

**Mohu použít vzorce, které odkazují na jiný list nebo sešit?**

Odkazy ve stylu Excelu mohou existovat v sešitech grafů, ale vyhodnocení vzorce je omezené podporovaným parserem a sadou funkcí. Pokud je nezbytný odkaz napříč listy nebo externí odkaz, ověřte přesně tento vzorec s verzí Aspose.Slides, kterou používáte. Pro workflow, které vyžadují širokou kompatibilitu odkazů Excelu, vypočítejte sešit externě a zapište vyřešené hodnoty zpět do dat grafu.

**Měly by řetězce vzorců začínat `=`?**

API příklady Aspose.Slides přiřazují výrazy jako `B2-C2` nebo `SUM(B2:B5)` bez úvodního `=`. Použití této formy udržuje generované vzorce konzistentní s dokumentovanými ukázkami API.