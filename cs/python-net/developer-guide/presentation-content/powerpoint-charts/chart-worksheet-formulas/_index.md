---
title: Použití vzorců pracovního listu grafu v prezentacích s Pythonem
linktitle: Vzorce pracovního listu
type: docs
weight: 70
url: /cs/python-net/chart-worksheet-formulas/
keywords:
- graf tabulkový list
- graf pracovní list
- vzorec grafu
- vzorec pracovního listu
- vzorec tabulky
- sešit dat grafu
- výpočet vzorce
- logická konstanta
- číselná konstanta
- řetězcová konstanta
- chybná konstanta
- aritmetický operátor
- porovnávací operátor
- styl A1
- styl R1C1
- předdefinovaná funkce
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Použijte vzorce ve stylu Excel v Aspose.Slides pro Python pomocí .NET pracovních listů grafů, přepočítejte hodnoty a použijte výsledky v grafech PowerPointu."
---
## **Přehled**

Grafy v PowerPointu obvykle ukládají svá zdrojová data do vloženého pracovního listu. V Aspose.Slides for Python via .NET můžete k tomuto pracovnímu listu přistupovat pomocí sešitu dat grafu, zapisovat vstupní hodnoty, přiřazovat buňkám vzorce, vypočítávat podporované vzorce a používat vypočítané buňky jako data grafu.

Tento článek vysvětluje kompletní postup práce s vzorci: vytvořit graf, naplnit jeho pracovní list, přiřadit vzorce ve stylu A1 nebo R1C1, přepočítat je, přečíst vypočítané hodnoty, připojit tyto buňky k řadě grafu a uložit prezentaci. Také popisuje podporovanou syntaxi vzorců, podmnožinu vestavěných funkcí, uložené hodnoty, nepodporované vzorce a specifické chyby tabulkových procesorů.

## **Pracovní listy grafu a vzorce**

Pracovní list grafu obsahuje kategorie, názvy řad a hodnoty použité v grafu. V PowerPointu můžete pracovní list prohlédnout otevřením editoru dat grafu:

![Graf PowerPointu s otevřeným vloženým pracovním listem, zobrazující kategorie a data řad](chart-worksheet-formulas_1.png)

V Aspose.Slides je pracovní list zpřístupněn prostřednictvím [sešitu dat grafu](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/ichartdataworkbook/). Použijte vlastnost [formula](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/ichartdatacell/formula/) pro vzorce ve stylu A1 a vlastnost [r1c1_formula](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) pro vzorce ve stylu R1C1. Po změně vstupních buněk nebo vzorců zavolejte [calculate_formulas](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/), aby se přepočítaly podporované vzorce a aktualizovaly odpovídající hodnoty buněk.

Vypočítaná buňka stále poskytuje svůj výsledek prostřednictvím vlastnosti [value](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/ichartdatacell/value/). To je důležité, když potřebujete v kódu zkontrolovat výsledek vzorce nebo použít buňku jako datový bod grafu.

## **Vytvoření grafu a výpočet vzorců v pracovním listu**

Následující příklad ukazuje kompletní workflow. Vytváří seskupený sloupcový graf, vymaže ukázková data, zapíše čtvrtletní příjmy a výdaje, vypočítá zisk pomocí vzorců, přečte výsledky, použije vypočítané buňky jako hodnoty grafu a uloží prezentaci.

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

Datové body grafu odkazují na `D2:D4`, takže graf používá vypočítané hodnoty zisku. V tomto workflow není samostatné volání pro obnovu grafu: nejprve přepočtěte sešit, pak použijte nebo uložte data grafu, která ukazují na vypočítané buňky.

## **Použití vzorců v A1 stylu**

A1 zápis identifikuje sloupce písmeny a řádky čísly. Přiřaďte výrazy ve stylu A1 pomocí [IChartDataCell.formula](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/ichartdatacell/formula/).

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

Běžné formy odkazů v A1:

| Odkaz | Relativní | Absolutní | Smíšený |
|---|---|---|---|
| Buňka | `A2` | `$A$2` | `A$2`, `$A2` |
| Řádek | `2:2` | `$2:$2` | — |
| Sloupec | `A:A` | `$A:$A` | — |
| Rozsah | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Relativní odkazy se mohou změnit, když je vzorec v tabulkovém procesoru přesunut nebo zkopírován. Absolutní odkazy zachovávají obě souřadnice pevně, zatímco smíšené odkazy fixují pouze řádek nebo sloupec.

## **Použití vzorců ve stylu R1C1**

R1C1 zápis identifikuje řádky i sloupce číselně. Relativní odkazy používají posuny v hranatých závorkách. Přiřaďte tuto syntaxi pomocí [IChartDataCell.r1c1_formula](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/).

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

Běžné formy odkazů v R1C1:

| Odkaz | Relativní | Absolutní | Smíšený |
|---|---|---|---|
| Buňka | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Řádek | `R[2]` | `R2` | — |
| Sloupec | `C[3]` | `C3` | — |
| Rozsah | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Například v buňce `D2` znamená `RC[-2]` buňku ve stejném řádku dvě sloupce vlevo (`B2`).

## **Konstanty a operátory ve vzorcích**

Vestavěný vyhodnocovač vzorců podporuje logické hodnoty, číselné literály, řetězce, hodnoty chyb tabulkového procesoru, aritmetické operátory a porovnávací operátory.

### **Konstanty a literály**

| Typ | Příklady | Poznámky |
|---|---|---|
| Logická | `TRUE`, `FALSE` | Lze použít přímo v logických výrazech, např. `A2=TRUE`. |
| Číselná | `1`, `0.5`, `.3`, `1E-2` | Jsou podporovány obvyklé i vědecké zápisy. |
| Řetězec | `"abc"`, `"2/3/2020 12:00"` | Literály textu jsou ve vzorci uzavřeny do dvojitých uvozovek. |
| Výsledek chyby | `#DIV/0!`, `#N/A`, `#REF!` | Platný vzorec může vyhodnotit chybu tabulky místo běžného výsledku. |

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
| `+` | Sčítání nebo jednorázové plus | `2+3` |
| `-` | Odčítání nebo záporný | `2-3`, `-3` |
| `*` | Násobení | `2*3` |
| `/` | Dělení | `2/3` |
| `%` | Procento | `30%` |
| `^` | Mocnina | `2^3` |

Používejte závorky pro explicitní určení pořadí vyhodnocení, např. `(A2+B2)*C2`.

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

Aspose.Slides obsahuje vestavěný vyhodnocovač vzorců pro pracovní listy grafů, ale není to kompletní výpočetní engine Excelu. Dokumentovaná sada funkcí je omezena na níže uvedené funkce. Nepředpokládejte, že libovolná funkce Excelu bude přepočítána pomocí [calculate_formulas](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/).

| Funkce | Účel nebo podpořená forma | Příklad |
|---|---|---|
| `ABS` | Absolutní hodnota | `ABS(A2)` |
| `AVERAGE` | Aritmetický průměr | `AVERAGE(B2:B5)` |
| `CEILING` | Zaokrouhlení čísla nahoru na násobek | `CEILING(A2,5)` |
| `CHOOSE` | Výběr hodnoty podle indexu | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Spojení textových hodnot | `CONCAT(A2,B2)` |
| `CONCATENATE` | Spojení textových hodnot | `CONCATENATE(A2," ",B2)` |
| `DATE` | Vytvoření hodnoty data pomocí datového systému 1900 | `DATE(2026,8,19)` |
| `DAYS` | Vrací počet dní mezi daty | `DAYS(B2,A2)` |
| `FIND` | Vyhledá text uvnitř jiného textu | `FIND("-",A2)` |
| `FINDB` | Vyhledávání textu po bajtech | `FINDB("a",A2)` |
| `IF` | Podmíněný výsledek | `IF(A2>0,A2,0)` |
| `INDEX` | Referenční forma | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektorová forma | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektorová forma | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximální hodnota | `MAX(B2:B5)` |
| `SUM` | Součet hodnot | `SUM(B2:B5)` |
| `VLOOKUP` | Vertikální vyhledávání | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Ukázané omezení v tabulce jsou podstatná: `INDEX` je dokumentován ve formě reference, zatímco `LOOKUP` a `MATCH` jsou v vektorové formě. `DATE` používá systém dat 1900. Funkce a vlastnosti, které zde nejsou uvedeny, by měly být považovány za nepodporované vestavěným vyhodnocovačem Aspose.Slides, pokud nejsou dokumentovány zvlášť.

## **Přepočet a uložené hodnoty**

Soubory tabulek běžně ukládají jak vzorec, tak jeho naposledy vypočítanou hodnotu. Aspose.Slides může při načtení prezentace přečíst uloženou hodnotu z [IChartDataCell.value](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/ichartdatacell/value/), pokud se data grafu mezitím nezměnila.

Po změně vstupních buněk nebo vzorců nespoléhejte na starý uložený výsledek. Před čtením vypočítaných hodnot nebo uložením grafu, který na nich závisí, zavolejte [ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/).

U vzorců mimo podporovanou podmnožinu může Aspose.Slides být neschopen vzorec parsovat nebo zjistit jeho závislosti. Pokud byl sešit modifikován, předchozí uložená hodnota už není spolehlivá. V takové situaci může čtení hodnoty buňky s nepodporovanými daty vyvolat [CellUnsupportedDataException](https://reference.aspose.com/slides/cs/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Pokud váš graf závisí na Excelových funkcích, které Aspose.Slides nevyhodnocuje, vypočítejte tyto vzorce externím enginem a zapište získané hodnoty zpět do sešitu grafu. Nepřepisujte nepodporované vzorce odhadovanými hodnotami.

## **Zpracování chyb vzorců**

Existují dva různé typy problémů, které je třeba rozlišovat.

Vzorec může být platný, ale vrátit výsledek chyby tabulky, například `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` nebo `#VALUE!`. V tomto případě je chybový token výsledkem buňky a může být vrácen přes `value`.

Vzorec může také selhat při parsování, referencování, závislostech nebo na úrovni podporovaných dat. Aspose.Slides poskytuje pro tyto případy specifické výjimky tabulkového procesoru: [CellInvalidFormulaException](https://reference.aspose.com/slides/cs/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/cs/python-net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/cs/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/) a [CellUnsupportedDataException](https://reference.aspose.com/slides/cs/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Když vzorce pocházejí ze šablon nebo uživatelského vstupu, ošetřete tyto výjimky kolem přepočtu a přístupu k hodnotě:

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

Podpora vzorců v pracovních listech grafů je určena pro definovanou podmnožinu tabulkových výpočtů, nikoli pro úplnou kompatibilitu s Excelem. Mějte tato omezení na paměti při navrhování workflow reportování:

- Používejte pouze dokumentované konstanty, operátory, odkazy a funkce, pokud chcete, aby Aspose.Slides přepočítal vzorce.
- Přepočítejte po změně buněk, na nichž výsledek vzorce závisí.
- Považujte uložené hodnoty z načtených prezentací za snímky, ne za náhradu přepočtu po úpravách.
- Otestujte vzorce ze stávajících šablon před spolehnutím se na jejich vypočítané hodnoty, zejména pokud používají funkce mimo dokumentovaný seznam.
- Pro vzorce, které vyžadují kompletní výpočetní engine tabulek, je vypočítejte externě a poté aktualizujte sešit grafu s výslednými hodnotami.

## **FAQ**

**Jaký je rozdíl mezi `formula` a `r1c1_formula`?**

[formula](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/ichartdatacell/formula/) ukládá výraz ve stylu A1, např. `B2-C2`. [r1c1_formula](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) ukládá výraz ve stylu R1C1, např. `RC[-2]-RC[-1]`. Použijte zápis, který nejlépe odpovídá tomu, jak vzorce generujete nebo kopírujete.

**Musím po přepočtu číst buňku samotnou nebo jen její hodnotu?**

[ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) vrací objekt `IChartDataCell`. Pro získání vypočítaného výsledku přečtěte jeho vlastnost [value](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/ichartdatacell/value/) po přepočtu.

**Kdy bych měl zavolat `calculate_formulas`?**

Zavolejte [calculate_formulas](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) po změně vstupních hodnot nebo vzorců a před tím, než budete záviset na vypočítaných výsledcích. Tím se aktualizují hodnoty vzorců, které vestavěný vyhodnocovač podporuje.

**Podporuje Aspose.Slides každou funkci Excelu?**

Ne. Vestavěný vyhodnocovač podporuje jen dokumentovanou podmnožinu funkcí. Funkce mimo tuto podmnožinu by neměly být považovány za správně přepočítatelné. Pokud je vyžadována plná kompatibilita s Excelovými vzorci, proveďte výpočet vhodným tabulkovým enginem a výsledek zapište do sešitu grafu.

**Co se stane, když načtená prezentace obsahuje nepodporovaný vzorec?**

Pokud se data grafu nezměnila, může sešit stále obsahovat dříve vypočítanou uloženou hodnotu. Po úpravě souvisejících dat tato uložená hodnota může být neplatná. Přístup k buňce, jejíž vzorec nelze zpracovat, může vyvolat [CellUnsupportedDataException](https://reference.aspose.com/slides/cs/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

**Jsou hodnoty chyb vzorců stejné jako výjimky v Pythonu?**

Ne. Výsledek jako `#DIV/0!` je hodnota tabulky vzniklá platným výpočtem. Výjimky jako [CellInvalidFormulaException](https://reference.aspose.com/slides/cs/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/) nebo [CellCircularReferenceException](https://reference.aspose.com/slides/cs/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/) signalizují, že vzorec nelze normálně zpracovat.

**Aktualizuje se graf automaticky, když se změní buňka s vzorcem?**

Řada grafu může odkazovat na buňky sešitu. Nejprve přepočtěte sešit, potom uložte nebo vykreslete prezentaci. Pokud datové body grafu odkazují na vypočítané buňky, graf použije tyto aktualizované hodnoty; samostatná metoda pro obnovu grafu není v tomto workflow vyžadována.

**Mohou grafy využívat externí sešit Excel?**

Ano, data grafu lze nastavit tak, aby používala externí sešit prostřednictvím API grafu. Nicméně workflow výpočtu vzorců popsané v tomto článku se týká sešitu dat grafu a podmnožiny vzorců vyhodnocovaných Aspose.Slides. Nepředpokládejte, že [calculate_formulas](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) poskytuje úplný přepočet libovolných vzorců v externím souboru XLSX.

**Mohu používat vzorce, které odkazují na jiný pracovní list nebo sešit?**

Odkazy ve stylu Excel mohou v sešitech grafů existovat, ale vyhodnocování vzorců je omezeno podporovaným parserem a sadou funkcí. Pokud je nezbytný odkaz napříč listy nebo externí odkaz, ověřte, že konkrétní vzorec funguje s vaší verzí Aspose.Slides. Pro workflow, které vyžadují širokou kompatibilitu odkazů Excelu, vypočítejte sešit externě a zapište vyřešené hodnoty zpět do dat grafu.

**Měly by řetězce vzorců začínat `=`?**

Příklady v API Aspose.Slides přiřazují výrazy jako `B2-C2` nebo `SUM(B2:B5)` bez úvodní `=`. Použití tohoto tvaru udržuje generované vzorce v souladu s dokumentovanými příklady API.