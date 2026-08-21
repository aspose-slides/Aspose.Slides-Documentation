---
title: Použití vzorců listu grafu v prezentacích v .NET
linktitle: Vzorce listu
type: docs
weight: 70
url: /cs/net/chart-worksheet-formulas/
keywords:
- graf tabulkový procesor
- list grafu
- vzorec grafu
- vzorec listu
- vzorec tabulky
- sešit dat grafu
- výpočet vzorce
- preferovaná kultura
- vzorec specifický pro kulturu
- DBCS
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
description: "Použijte vzorce ve stylu Excel v Aspose.Slides pro .NET listy grafů, přepočítejte hodnoty a použijte výsledky v grafech PowerPointu."
---
## **Přehled**

Grafy v PowerPointu obvykle ukládají svá zdrojová data do vloženého listu. V Aspose.Slides pro .NET můžete k tomuto listu přistupovat prostřednictvím sešitu dat grafu, zapisovat vstupní hodnoty, přiřazovat buňkám vzorce, vypočítávat podporované vzorce a používat vypočítané buňky jako data grafu.

Tento článek popisuje kompletní workflow s vzorci: vytvořit graf, naplnit jeho list, přiřadit vzorce ve stylu A1 nebo R1C1, přepočítat je, načíst vypočítané hodnoty, propojit tyto buňky s řadou grafu a uložit prezentaci. Také popisuje podporovanou syntaxi vzorců, vestavěnou podmnožinu funkcí, uložené hodnoty, nepodporované vzorce a chyby specifické pro tabulkové procesory.

## **Listy grafu a vzorce**

List grafu obsahuje kategorie, názvy řad a hodnoty používané v grafu. V PowerPointu můžete list zkontrolovat otevřením editoru dat grafu:

![Graf PowerPointu s otevřeným vloženým listem, zobrazující data kategorií a řad](chart-worksheet-formulas_1.png)

V Aspose.Slides je list dostupný přes [sešit dat grafu](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdataworkbook/). Pro vzorce ve stylu A1 použijte vlastnost [Formula](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatacell/formula/) a pro vzorce ve stylu R1C1 vlastnost [R1C1Formula](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatacell/r1c1formula/). Po změně vstupních buněk nebo vzorců zavolejte [CalculateFormulas](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) pro přepočet podporovaných vzorců a aktualizaci odpovídajících hodnot buněk.

Vypočítaná buňka stále vystavuje svůj výsledek přes vlastnost [Value](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatacell/value/). To je důležité, když potřebujete v kódu zkontrolovat výsledek vzorce nebo použít buňku jako datový bod grafu.

## **Vytvoření grafu a výpočet vzorců v listu**

Následující příklad ukazuje celý workflow. Vytvoří sloupcový graf s klastrem, vymaže ukázková data, zapíše čtvrtletní tržby a výdaje, vypočítá zisk pomocí vzorců, načte výsledky, použije vypočítané buňky jako hodnoty grafu a uloží prezentaci.

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

Datové body grafu odkazují na `D2:D4`, takže graf používá vypočítané hodnoty zisku. V tomto workflow není potřeba žádné samostatné volání pro obnovu grafu: nejprve přepočtěte sešit a poté použijte nebo uložte data grafu, která ukazují na vypočítané buňky.

## **Použití A1‑stylu vzorců**

Notace A1 identifikuje sloupce písmeny a řádky čísly. Přidávejte A1‑stylové výrazy pomocí [IChartDataCell.Formula](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatacell/formula/).

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

Běžné formy A1 referencí jsou:

| Reference | Relativní | Absolutní | Smíšený |
|---|---|---|---|
| Buňka | `A2` | `$A$2` | `A$2`, `$A2` |
| Řádek | `2:2` | `$2:$2` | — |
| Sloupec | `A:A` | `$A:$A` | — |
| Rozsah | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Relativní odkazy se mohou změnit, když je vzorec v tabulkovém procesoru přesunut nebo zkopírován. Absolutní odkazy udržují oba souřadnice fixní, zatímco smíšené odkazy fixují jen řádek nebo jen sloupec.

## **Použití R1C1‑stylu vzorců**

Notace R1C1 identifikuje jak řádky, tak sloupce číselně. Relativní odkazy používají posuny v hranatých závorkách. Tento syntaktický styl přiřaďte pomocí [IChartDataCell.R1C1Formula](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatacell/r1c1formula/).

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

Běžné formy R1C1 referencí jsou:

| Reference | Relativní | Absolutní | Smíšený |
|---|---|---|---|
| Buňka | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Řádek | `R[2]` | `R2` | — |
| Sloupec | `C[3]` | `C3` | — |
| Rozsah | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Například v buňce `D2` výraz `RC[-2]` znamená buňku ve stejném řádku o dva sloupce vlevo (`B2`).

## **Konstanty a operátory vzorců**

Vestavěný evaluátor vzorců podporuje logické hodnoty, číselné literály, řetězce, hodnoty chyb tabulkových procesorů, aritmetické operátory i operátory srovnání.

### **Konstanty a literály**

| Typ | Příklady | Poznámky |
|---|---|---|
| Logická | `TRUE`, `FALSE` | Lze použít přímo v logických výrazech, např. `A2=TRUE`. |
| Číselná | `1`, `0.5`, `.3`, `1E-2` | Podporována je běžná i vědecká notace. |
| Řetězec | `"abc"`, `"2/3/2020 12:00"` | Literály textu jsou ve vzorci uzavřeny do dvojitých uvozovek. |
| Výsledek chyby | `#DIV/0!`, `#N/A`, `#REF!` | Platný vzorec může vyhodnotit chybu místo normálního výsledku. |

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
| `-` | Odčítání nebo záporná hodnota | `2-3`, `-3` |
| `*` | Násobení | `2*3` |
| `/` | Dělení | `2/3` |
| `%` | Procento | `30%` |
| `^` | Umocnění | `2^3` |

Používejte závorky pro explicitní určení pořadí výpočtu, např. `(A2+B2)*C2`.

### **Porovnávací operátory**

Porovnávací výrazy vrací logické hodnoty.

| Operátor | Význam | Příklad |
|---|---|---|
| `=` | Rovná se | `A2=3` |
| `<>` | Nerovná se | `A2<>3` |
| `>` | Větší než | `A2>3` |
| `>=` | Větší nebo rovno | `A2>=3` |
| `<` | Menší než | `A2<3` |
| `<=` | Menší nebo rovno | `A2<=3` |

## **Podporované předdefinované funkce**

Aspose.Slides obsahuje vestavěný evaluátor vzorců pro listy grafů, ale nejedná se o kompletní výpočetní engine Excelu. Dokumentovaná množina funkcí je omezena na níže uvedené. Nepředpokládejte, že libovolná Excel funkce může být přepočtena pomocí [CalculateFormulas](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/).

| Funkce | Účel nebo podpora formy | Příklad |
|---|---|---|
| `ABS` | Absolutní hodnota | `ABS(A2)` |
| `AVERAGE` | Aritmetický průměr | `AVERAGE(B2:B5)` |
| `CEILING` | Zaokrouhlení čísla nahoru na násobek | `CEILING(A2,5)` |
| `CHOOSE` | Výběr hodnoty podle indexu | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Spojení textových hodnot | `CONCAT(A2,B2)` |
| `CONCATENATE` | Spojení textových hodnot | `CONCATENATE(A2," ",B2)` |
| `DATE` | Vytvoření datumové hodnoty pomocí systému 1900 | `DATE(2026,8,19)` |
| `DAYS` | Počet dní mezi daty | `DAYS(B2,A2)` |
| `FIND` | Vyhledání textu v rámci jiného textu | `FIND("-",A2)` |
| `FINDB` | Vyhledávání orientované na bajty | `FINDB("a",A2)` |
| `IF` | Podmíněný výsledek | `IF(A2>0,A2,0)` |
| `INDEX` | Referenční forma | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektorová forma | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektorová forma | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximální hodnota | `MAX(B2:B5)` |
| `SUM` | Součet hodnot | `SUM(B2:B5)` |
| `VLOOKUP` | Vertikální vyhledávání | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Omezení uvedená v tabulce jsou podstatná: `INDEX` je dokumentován v referenční formě, zatímco `LOOKUP` a `MATCH` jsou dokumentovány ve svých vektorových formách. `DATE` používá systém 1900. Funkce a vlastnosti, které zde nejsou uvedeny, by měly být považovány za nepodporované vestavěným evaluátorem Aspose.Slides, pokud nejsou dokumentovány zvlášť.

## **Výpočet vzorců s preferovaným jazykem**

Některé funkce sešitu interpretují text podle jazykově specifických pravidel. To je zvláště důležité pro funkce určené pro jazyky používající dvojbajtové znakové sady (DBCS). Pro správný výpočet takových vzorců vytvořte [LoadOptions](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/), nastavte [ISpreadsheetOptions.PreferredCulture](https://reference.aspose.com/slides/cs/net/aspose.slides/ispreadsheetoptions/preferredculture/) přes [LoadOptions.SpreadsheetOptions](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/spreadsheetoptions/), a poté načtěte prezentaci.

Následující příklad vybírá japonskou kulturu, otevře prezentaci s nastavenými možnostmi načítání a zavolá [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) pro každý sešit grafu:

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

Preferovaná kultura je součástí konfigurace načítání prezentace, proto ji nastavte před vytvořením instance [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/). Použijte kulturu, kterou očekávají vzorce sešitu; např. `ja-JP` pro vzorce, které mají dodržovat japonská DBCS pravidla.

## **Přepočet a uložené hodnoty**

Soubory tabulek často ukládají jak vzorec, tak jeho poslední vypočítanou hodnotu. Aspose.Slides může proto číst uloženou hodnotu z [IChartDataCell.Value](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdatacell/value/), když je prezentace načtena a odpovídající data grafu nebyla změněna.

Po změně vstupních buněk nebo vzorců nespoléhejte na starý uložený výsledek. Před čtením vypočítaných hodnot nebo uložením grafu, který na nich závisí, zavolejte [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/).

U vzorců mimo podporovanou podmnožinu nemusí Aspose.Slides být schopen vzorec parsovat nebo určit jeho závislosti. Pokud byl sešit upraven, nelze předchozí uloženou hodnotu považovat za spolehlivou. V takovém případě může čtení hodnoty buňky s nepodporovanými daty vyvolat [CellUnsupportedDataException](https://reference.aspose.com/slides/cs/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Pokud váš graf závisí na Excelových funkcích, které Aspose.Slides nevyhodnocuje, vypočítejte tyto vzorce pomocí tabulkového engine, který je podporuje, a zapište výsledné hodnoty zpět do sešitu grafu. Nepřepisujte nepodporované vzorce odhadovanými hodnotami.

## **Zpracování chyb vzorců**

Je potřeba rozlišovat dva typy problémů.

Vzorec může být platný, ale může vrátit výsledek chyby tabulkového procesoru, např. `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` nebo `#VALUE!`. V takovém případě je token chyby výsledkem buňky a lze jej získat přes `Value`.

Vzorec může také selhat během parsování, při odkazování, při určování závislostí nebo na úrovni podporovaných dat. Aspose.Slides poskytuje pro tyto případy specifické výjimky: [CellInvalidFormulaException](https://reference.aspose.com/slides/cs/net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/cs/net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/cs/net/aspose.slides.spreadsheet/cellcircularreferenceexception/) a [CellUnsupportedDataException](https://reference.aspose.com/slides/cs/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Když vzorce pocházejí ze šablon nebo od uživatele, obalte přepočet a přístup k hodnotám těmito výjimkami:

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

## **Praktické omezení**

Podpora vzorců v listech grafů je určena pro definovanou podmnožinu výpočtů tabulkových procesorů, ne pro plnou kompatibilitu s Excelem. Mějte tato omezení na paměti při navrhování workflow reportování:

- Používejte pouze dokumentované konstanty, operátory, reference a funkce, pokud chcete, aby Aspose.Slides přepočítával vzorce.
- Po změně buněk, na nichž výsledek vzorce závisí, provádějte přepočet.
- Považujte uložené hodnoty z načtených prezentací za snímek aktuálního stavu, ne jako náhradu přepočtu po úpravách.
- Otestujte vzorce z existujících šablon před spolehnutím se na jejich vypočítané hodnoty, zejména pokud používají funkce mimo dokumentovaný seznam.
- Pro vzorce, které vyžadují kompletní výpočetní engine tabulek, je vypočítejte externě a poté aktualizujte sešit grafu výslednými hodnotami.

## **Často kladené otázky**

**Jaký je rozdíl mezi `Formula` a `R1C1Formula`?**

`Formula` ukládá A1‑stylový výraz, např. `B2-C2`. `R1C1Formula` ukládá R1C1‑stylový výraz, např. `RC[-2]-RC[-1]`. Použijte notaci, která nejlépe odpovídá tomu, jak vzorce generujete nebo kopírujete.

**Musím po výpočtu číst buňku samotnou nebo její hodnotu?**

`IChartDataWorkbook.GetCell` vrací `IChartDataCell`. Pro získání vypočítaného výsledku přečtěte vlastnost `Value` této buňky po přepočtu.

**Kdy mám zavolat `CalculateFormulas`?**

Zavolejte `CalculateFormulas` po změně vstupních hodnot nebo vzorců a před tím, než budete záviset na vypočítaných výsledcích. Tím se aktualizují hodnoty vzorců, které vestavěný evaluátor podporuje.

**Podporuje Aspose.Slides každou Excel funkci?**

Ne. Vestavěný evaluátor podporuje jen dokumentovanou podmnožinu funkcí. Funkce mimo tuto podmnožinu by neměly být považovány za správně přepočitatelné. Pokud potřebujete plnou kompatibilitu s Excel vzorci, proveďte výpočet pomocí vhodného tabulkového engine a zapíšete finální hodnoty do sešitu grafu.

**Co se stane, když načtená prezentace obsahuje nepodporovaný vzorec?**

Pokud data grafu nebyla změněna, může sešit stále obsahovat dříve vypočítanou uloženou hodnotu. Po změně souvisejících dat však může tato uložená hodnota přestat být platná. Přístup k buňce, jejíž vzorec nelze zpracovat, může vyvolat `CellUnsupportedDataException`.

**Jsou hodnoty chyb vzorců stejné jako .NET výjimky?**

Ne. Výsledek jako `#DIV/0!` je hodnota tabulkového procesoru vytvořená platnou kalkulací. Výjimky jako `CellInvalidFormulaException` nebo `CellCircularReferenceException` signalizují, že vzorec nelze normálně zpracovat.

**Aktualizuje se graf automaticky, když se změní buňka se vzorcem?**

Řada grafu může odkazovat na buňky sešitu. Nejprve přepočtěte sešit a poté uložte nebo vykreslete prezentaci. Pokud datové body grafu odkazují na vypočítané buňky, graf použije tyto aktualizované hodnoty; není potřeba samostatná metoda pro obnovu grafu.

**Mohou grafy používat externí Excel sešit?**

Ano, data grafu lze nakonfigurovat tak, aby používala externí sešit přes API dat grafu. Avšak workflow výpočtu vzorců popsaný v tomto článku se týká sešitu dat grafu a podmnožiny vzorců vyhodnocovaných Aspose.Slides. Nepředpokládejte, že `CalculateFormulas` poskytuje úplný přepočet libovolných vzorců v externím souboru XLSX.

**Mohu použít vzorce, které odkazují na jiný list nebo sešit?**

Odkazy ve stylu Excel mohou v sešitech grafů existovat, ale vyhodnocení vzorců je omezeno podporovaným parserem a množinou funkcí. Pokud je nezbytný odkaz napříč listy nebo na externí sešit, ověřte přesně tento vzorec s verzí Aspose.Slides, kterou používáte. Pro workflow vyžadující širokou kompatibilitu odkazů Excelu počítejte sešit externě a výsledek zapište zpět do dat grafu.

**Měly by řetězce vzorců začínat znakem `=`?**

Ukázky API Aspose.Slides přiřazují výrazy jako `B2-C2` nebo `SUM(B2:B5)` bez úvodního `=`. Použití této podoby udržuje generované vzorce v souladu s dokumentovanými příklady API.