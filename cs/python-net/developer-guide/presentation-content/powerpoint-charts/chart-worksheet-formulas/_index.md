---
title: Použití vzorců listu grafu v prezentacích pomocí Pythonu
linktitle: Vzorce listu
type: docs
weight: 70
url: /cs/python-net/chart-worksheet-formulas/
keywords:
- graf tabulky
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
- chybná konstanta
- aritmetický operátor
- operátor porovnání
- styl A1
- styl R1C1
- předdefinovaná funkce
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Použijte vzorce ve stylu Excel v Aspose.Slides pro Python prostřednictvím .NET listů grafů, přepočítejte hodnoty a použijte výsledky v grafech PowerPointu."
---
## **Přehled**

Grafy v PowerPointu obvykle ukládají svá zdrojová data do vloženého listu. V Aspose.Slides pro Python prostřednictvím .NET můžete k tomuto listu přistupovat přes sešit dat grafu, zapisovat vstupní hodnoty, přiřazovat buňkám vzorce, vypočítávat podporované vzorce a používat vypočítané buňky jako data grafu.

Tento článek popisuje kompletní workflow vzorců: vytvoření grafu, naplnění jeho listu, přiřazení vzorců ve stylu A1 nebo R1C1, jejich přepočet, čtení vypočítaných hodnot, propojení těchto buněk s řadou grafu a uložení prezentace. Také popisuje podporovanou syntaxi vzorců, podmnožinu vestavěných funkcí, uložené hodnoty, nepodporované vzorce a chyby specifické pro tabulky.

## **Listy grafů a vzorce**

List grafu obsahuje kategorie, názvy řad a hodnoty použité v grafu. V PowerPointu můžete list prohlédnout otevřením editoru dat grafu:

![Graf PowerPointu s otevřeným vloženým listem, zobrazující data kategorií a řad](chart-worksheet-formulas_1.png)

V Aspose.Slides je list vystaven přes [sešit dat grafu](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/ichartdataworkbook/). Pro vzorce ve stylu A1 použijte vlastnost [formula](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/ichartdatacell/formula/) a pro vzorce ve stylu R1C1 vlastnost [r1c1_formula](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/). Po změně vstupních buněk nebo vzorců zavolejte [calculate_formulas](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) pro přepočet podporovaných vzorců a aktualizaci odpovídajících hodnot buněk.

Vypočítaná buňka stále poskytuje svůj výsledek přes vlastnost [value](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/ichartdatacell/value/). To je důležité, když potřebujete v kódu zkontrolovat výsledek vzorce nebo použít buňku jako bod dat grafu.

## **Vytvoření grafu a výpočet vzorců v listu**

Následující příklad ukazuje kompletní workflow. Vytvoří sloupcový seskupený graf, vymaže ukázková data, zapíše čtvrtletní příjmy a výdaje, vypočítá zisk pomocí vzorců, přečte výsledky, použije vypočítané buňky jako hodnoty grafu a uloží prezentaci.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 350)
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    workbook.clear(worksheet_index)

    category1 = workbook.get_cell(worksheet_index, "A2", "Q1")
    category2 = workbook.get_cell(worksheet_index, "A3", "Q2")
    category3 = workbook.get_cell(worksheet_index, "A4", "Q3")

    workbook.get_cell(worksheet_index, "B1", "Revenue")
    workbook.get_cell(worksheet_index, "C1", "Expenses")
    workbook.get_cell(worksheet_index, "D1", "Profit")

    workbook.get_cell(worksheet_index, "B2").value = 120.0
    workbook.get_cell(worksheet_index, "C2").value = 80.0
    workbook.get_cell(worksheet_index, "B3").value = 150.0
    workbook.get_cell(worksheet_index, "C3").value = 95.0
    workbook.get_cell(worksheet_index, "B4").value = 135.0
    workbook.get_cell(worksheet_index, "C4").value = 110.0

    profit1 = workbook.get_cell(worksheet_index, "D2")
    profit2 = workbook.get_cell(worksheet_index, "D3")
    profit3 = workbook.get_cell(worksheet_index, "D4")

    profit1.formula = "B2-C2"
    profit2.formula = "B3-C3"
    profit3.formula = "B4-C4"

    workbook.calculate_formulas()

    q1_profit = profit1.value  # 40
    q2_profit = profit2.value  # 55
    q3_profit = profit3.value  # 25

    print(f"Q1 profit: {q1_profit}")
    print(f"Q2 profit: {q2_profit}")
    print(f"Q3 profit: {q3_profit}")

    chart.chart_data.categories.add(category1)
    chart.chart_data.categories.add(category2)
    chart.chart_data.categories.add(category3)

    profit_series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, "D1"), chart.type)
    profit_series.data_points.add_data_point_for_bar_series(profit1)
    profit_series.data_points.add_data_point_for_bar_series(profit2)
    profit_series.data_points.add_data_point_for_bar_series(profit3)
    profit_series.labels.default_data_label_format.show_value = True

    presentation.save("chart-formulas.pptx", slides.export.SaveFormat.PPTX)
```

Body dat grafu odkazují na `D2:D4`, takže graf používá vypočítané hodnoty zisku. V tomto workflow není samostatné volání pro obnovení grafu: nejprve přepočtěte sešit, poté použijte nebo uložte data grafu odkazující na vypočítané buňky.

## **Použití vzorců ve stylu A1**

Notace A1 identifikuje sloupce písmeny a řádky čísly. Přiřaďte výrazy ve stylu A1 pomocí [IChartDataCell.formula](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/ichartdatacell/formula/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "C3").value = 10
    workbook.get_cell(0, "F2").value = 2
    workbook.get_cell(0, "G2").value = 3
    workbook.get_cell(0, "H2").value = 4

    cell = workbook.get_cell(0, "A2")
    cell.formula = "C3+SUM(F2:H2)"

    workbook.calculate_formulas()

    value = cell.value  # 19
```

Běžné formy odkazů A1 jsou:

| Odkaz | Relativní | Absolutní | Smíšený |
|---|---|---|---|
| Buňka | `A2` | `$A$2` | `A$2`, `$A2` |
| Řádek | `2:2` | `$2:$2` | — |
| Sloupec | `A:A` | `$A:$A` | — |
| Rozsah | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Relativní odkazy se mohou změnit, když je vzorec přesunut nebo zkopírován tabulkovým programem. Absolutní odkazy fixují oba souřadnice, zatímco smíšené odkazy fixují pouze řádek nebo sloupec.

## **Použití vzorců ve stylu R1C1**

Notace R1C1 identifikuje jak řádky, tak sloupce číselně. Relativní odkazy používají posuny v hranatých závorkách. Tuto syntaxi přiřaďte pomocí [IChartDataCell.r1c1_formula](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "B2").value = 12
    workbook.get_cell(0, "C2").value = 5

    cell = workbook.get_cell(0, "D2")
    cell.r1c1_formula = "RC[-2]-RC[-1]"

    workbook.calculate_formulas()

    value = cell.value  # 7
```

Běžné formy odkazů R1C1 jsou:

| Odkaz | Relativní | Absolutní | Smíšený |
|---|---|---|---|
| Buňka | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Řádek | `R[2]` | `R2` | — |
| Sloupec | `C[3]` | `C3` | — |
| Rozsah | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Například v buňce `D2` znamená `RC[-2]` buňku ve stejném řádku dvě sloupce vlevo (`B2`).

## **Konstanty a operátory ve vzorcích**

Vestavěný vyhodnocovač vzorců podporuje logické hodnoty, číselné literály, řetězce, chybové hodnoty tabulek, aritmetické operátory a operátory porovnání.

### **Konstanty a literály**

| Typ | Příklady | Poznámky |
|---|---|---|
| Logický | `TRUE`, `FALSE` | Lze použít přímo v logických výrazech, např. `A2=TRUE`. |
| Číselný | `1`, `0.5`, `.3`, `1E-2` | Jsou podporovány běžná i vědecká zápisy. |
| Řetězec | `"abc"`, `"2/3/2020 12:00"` | Textové literály jsou ve vzorci uzavřeny do dvojitých uvozovek. |
| Chyba | `#DIV/0!`, `#N/A`, `#REF!` | Platný vzorec může vyhodnotit chybu tabulky místo normálního výsledku. |

Tento příklad používá několik typů konstant:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "A2").value = False
    workbook.get_cell(0, "B2").formula = "A2=TRUE"
    workbook.get_cell(0, "C2").formula = "1+0.5"
    workbook.get_cell(0, "D2").formula = ".3*1E-2"
    workbook.get_cell(0, "E2").formula = "\"abc\""
    workbook.get_cell(0, "F2").formula = "2/0"

    workbook.calculate_formulas()

    logical_value = workbook.get_cell(0, "B2").value  # False
    numeric_value = workbook.get_cell(0, "C2").value  # 1.5
    scientific_value = workbook.get_cell(0, "D2").value  # 0.003
    string_value = workbook.get_cell(0, "E2").value  # abc
    error_value = workbook.get_cell(0, "F2").value  # #DIV/0!
```

### **Aritmetické operátory**

| Operátor | Význam | Příklad |
|---|---|---|
| `+` | Sčítání nebo unární plus | `2+3` |
| `-` | Odečtení nebo negace | `2-3`, `-3` |
| `*` | Násobení | `2*3` |
| `/` | Dělení | `2/3` |
| `%` | Procento | `30%` |
| `^` | Umocnění | `2^3` |

Použijte závorky pro explicitní určení pořadí výpočtu, např. `(A2+B2)*C2`.

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

Aspose.Slides obsahuje vestavěný vyhodnocovač vzorců pro listy grafů, ale není to úplný výpočetní engine Excelu. Dokumentovaný soubor funkcí je omezen na funkce uvedené níže. Nepředpokládejte, že libovolná funkce Excelu může být přepočítána metodou [calculate_formulas](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/).

| Funkce | Účel nebo podpora | Příklad |
|---|---|---|
| `ABS` | Absolutní hodnota | `ABS(A2)` |
| `AVERAGE` | Aritmetický průměr | `AVERAGE(B2:B5)` |
| `CEILING` | Zaokrouhlení čísla nahoru na násobek | `CEILING(A2,5)` |
| `CHOOSE` | Výběr hodnoty podle indexu | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Spojení textových hodnot | `CONCAT(A2,B2)` |
| `CONCATENATE` | Spojení textových hodnot | `CONCATENATE(A2," ",B2)` |
| `DATE` | Vytvoření datumové hodnoty pomocí systému 1900 | `DATE(2026,8,19)` |
| `DAYS` | Počet dní mezi daty | `DAYS(B2,A2)` |
| `FIND` | Najde jeden text uvnitř jiného | `FIND("-",A2)` |
| `FINDB` | Hledání bajtově orientované | `FINDB("a",A2)` |
| `IF` | Podmíněný výsledek | `IF(A2>0,A2,0)` |
| `INDEX` | Referenční forma | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektorová forma | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektorová forma | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximální hodnota | `MAX(B2:B5)` |
| `SUM` | Součet hodnot | `SUM(B2:B5)` |
| `VLOOKUP` | Vertikální vyhledávání | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Omezení uvedená v tabulce jsou podstatná: `INDEX` je dokumentován v referenční formě, zatímco `LOOKUP` a `MATCH` v jejich vektorových formách. `DATE` používá systém 1900. Funkce a vlastnosti, které zde nejsou uvedeny, by měly být považovány za nepodporované vestavěným vyhodnocovačem Aspose.Slides, pokud nejsou dokumentovány zvlášť.

## **Výpočet vzorců s preferovanou kulturou**

Některé funkce sešitu interpretují text podle kulturně specifických pravidel. To je zvláště důležité pro funkce určené pro jazyky používající dvojbajtové znaky (DBCS). Pro správný výpočet takových vzorců vytvořte [LoadOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides/loadoptions/), nastavte [SpreadsheetOptions.preferred_culture](https://reference.aspose.com/slides/cs/python-net/aspose.slides/spreadsheetoptions/) přes [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/cs/python-net/aspose.slides/loadoptions/spreadsheet_options/) a poté načtěte prezentaci.

Následující příklad vybírá japonskou kulturu, otevírá prezentaci s nastavenými možnostmi načtení a volá [ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) pro každý sešit grafu:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

load_options = slides.LoadOptions()
load_options.spreadsheet_options.preferred_culture = "ja-JP"

with slides.Presentation("presentation.pptx", load_options) as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, charts.Chart):
                shape.chart_data.chart_data_workbook.calculate_formulas()
```

Preferovaná kultura je součástí konfigurace načítání prezentace, takže ji specifikujte před vytvořením instance [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/). Použijte kulturu očekávanou ve vzorcích sešitu; např. `ja-JP` pro vzorce, které mají sledovat japonská DBCS pravidla.

## **Přepočet a uložené hodnoty**

Soubory tabulek obvykle ukládají jak vzorec, tak jeho naposledy vypočítanou hodnotu. Aspose.Slides může takto přečíst uloženou hodnotu z [IChartDataCell.value](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/ichartdatacell/value/), když je prezentace načtena a relevantní data grafu nebyla změněna.

Po změně vstupních buněk nebo vzorců se nespoléhejte na starý uložený výsledek. Zavolejte [ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) před čtením vypočítaných hodnot nebo uložením dat grafu, která na nich závisejí.

U vzorců mimo podporovanou podmnožinu může Aspose.Slides nedokázat vzorec rozparsovat nebo zjistit jeho závislosti. Pokud byl sešit upraven, předchozí uložená hodnota již není spolehlivá. V takové situaci může čtení hodnoty buňky s nepodporovanými daty vyvolat [CellUnsupportedDataException](https://reference.aspose.com/slides/cs/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Pokud váš graf závisí na Excelových funkcích, které Aspose.Slides nevyhodnocuje, vypočítejte tyto vzorce pomocí tabulkového engine, který je podporuje, a zapište výsledné hodnoty zpět do sešitu grafu. Nepřidělujte nepodporovaným vzorcům hádané hodnoty.

## **Zpracování chyb vzorců**

Rozlišujeme dva různé typy problémů.

Vzorec může být platný, ale vrátit chybu tabulky, např. `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` nebo `#VALUE!`. V tomto případě je chybový token výsledkem buňky a lze jej získat přes `value`.

Vzorec může také selhat při parsování, při odkazování, při zjišťování závislostí nebo pokud používá nepodporovaná data. Aspose.Slides poskytuje pro tyto případy tabulkově specifické výjimky: [CellInvalidFormulaException](https://reference.aspose.com/slides/cs/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/cs/python-net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/cs/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/) a [CellUnsupportedDataException](https://reference.aspose.com/slides/cs/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Když vzorce pocházejí ze šablon nebo vstupu uživatele, obalte přepočet a přístup k hodnotě těmito výjimkami:

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.slides.spreadsheet as spreadsheet

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook
    cell = workbook.get_cell(0, "A2")
    cell.formula = "SUM(B2:B5)"

    try:
        workbook.calculate_formulas()
        print(cell.value)
    except spreadsheet.CellInvalidFormulaException as ex:
        print(f"Invalid formula: {ex}")
    except spreadsheet.CellInvalidReferenceException as ex:
        print(f"Invalid cell reference: {ex}")
    except spreadsheet.CellCircularReferenceException as ex:
        print(f"Circular reference: {ex}")
    except spreadsheet.CellUnsupportedDataException as ex:
        print(f"Unsupported spreadsheet data: {ex}")
```

## **Praktická omezení**

Podpora vzorců v listech grafů je určena pro definovanou podmnožinu výpočtů tabulek, nikoli pro plnou kompatibilitu s Excelem. Mějte tyto omezení na paměti při navrhování workflow reportování:

- Používejte pouze dokumentované konstanty, operátory, odkazy a funkce, pokud požadujete, aby Aspose.Slides přepočítával vzorce.
- Přepočtěte po změně buněk, na nichž výsledek vzorce závisí.
- Považujte uložené hodnoty z načtených prezentací za snímky, ne za náhradu přepočtu po úpravách.
- Otestujte vzorce z existujících šablon před tím, než se spolehnete na jejich vypočítané hodnoty, zejména pokud používají funkce mimo dokumentovaný seznam.
- Pro vzorce, které vyžadují plný výpočetní engine tabulek, je vypočítejte externě a poté aktualizujte sešit grafu výslednými hodnotami.

## **Často kladené otázky**

**Jaký je rozdíl mezi `formula` a `r1c1_formula`?**

[formula](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/ichartdatacell/formula/) ukládá výraz ve stylu A1, např. `B2-C2`. [r1c1_formula](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) ukládá výraz ve stylu R1C1, např. `RC[-2]-RC[-1]`. Použijte notaci, která nejlépe odpovídá tomu, jak vzorce generujete nebo kopírujete.

**Musím po výpočtu číst buňku samotnou nebo její hodnotu?**

[ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) vrací `IChartDataCell`. Pro získání vypočítaného výsledku přečtěte vlastnost [value](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/ichartdatacell/value/) té buňky po přepočtu.

**Kdy mám volat `calculate_formulas`?**

Zavolejte [calculate_formulas](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) po změně vstupních hodnot nebo vzorců a před tím, než budete potřebovat vypočítané výsledky. Tím se aktualizují hodnoty vzorců, které vestavěný vyhodnocovač podporuje.

**Podporuje Aspose.Slides všechny Excel funkce?**

Ne. Vestavěný vyhodnocovač podporuje pouze dokumentovanou podmnožinu funkcí. Funkce mimo tuto podmnožinu by neměly být považovány za správně přepočítané. Pokud je vyžadována úplná kompatibilita s Excelovými vzorci, proveďte výpočet pomocí vhodného tabulkového engine a zapište finální hodnoty do sešitu grafu.

**Co se stane, pokud načtená prezentace obsahuje nepodporovaný vzorec?**

Pokud se data grafu nezměnila, sešit může stále obsahovat dříve vypočítanou uloženou hodnotu. Po úpravě souvisejících dat může tato uložená hodnota být neplatná. Přístup k buňce, jejíž vzorec nelze zpracovat, může vyvolat [CellUnsupportedDataException](https://reference.aspose.com/slides/cs/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**Jsou hodnoty chyb ve vzorcích stejné jako výjimky v Pythonu?**

Ne. Výsledek jako `#DIV/0!` je hodnota tabulky vzniklá platným výpočtem. Výjimky jako [CellInvalidFormulaException](https://reference.aspose.com/slides/cs/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/) nebo [CellCircularReferenceException](https://reference.aspose.com/slides/cs/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/) signalizují, že vzorec nelze normálně zpracovat.

**Aktualizuje se graf automaticky, když se změní buňka vzorce?**

Řada grafu může odkazovat na buňky sešitu. Nejprve přepočtěte sešit, poté uložte nebo vykreslete prezentaci. Pokud data grafu odkazují na vypočítané buňky, graf použije aktualizované hodnoty; není potřeba žádná samostatná metoda pro obnovení grafu.

**Mohou grafy používat externí sešit Excel?**

Ano, data grafu lze nakonfigurovat tak, aby používala externí sešit přes API dat grafu. Nicméně workflow výpočtu vzorců popsané v tomto článku se týká sešitu dat grafu a podmnožiny vzorců vyhodnocovaných Aspose.Slides. Nepředpokládejte, že [calculate_formulas](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) poskytuje úplný přepočet libovolných vzorců v externím souboru XLSX.

**Mohu používat vzorce, které odkazují na jiný list nebo sešit?**

Reference ve stylu Excel mohou v sešitech grafů existovat, ale vyhodnocení vzorců je omezeno podporovaným parserem a sadou funkcí. Pokud je pro vás nezbytný odkaz napříč listy nebo na externí sešit, ověřte si přesný vzorec s vaší cílovou verzí Aspose.Slides. Pro workflow vyžadující širokou kompatibilitu odkazů Excelu vypočítejte sešit externě a výsledné hodnoty vraťte do dat grafu.

**Měly by řetězce vzorců začínat znakem `=`?**

Příklady API Aspose.Slides přiřazují výrazy jako `B2-C2` nebo `SUM(B2:B5)` bez úvodního `=`. Používání této podoby udržuje generované vzorce v souladu s dokumentovanými příklady API.