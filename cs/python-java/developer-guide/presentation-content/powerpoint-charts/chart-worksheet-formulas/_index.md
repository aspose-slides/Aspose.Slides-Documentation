---
title: Použití vzorců listu grafu v prezentacích v Pythonu přes Java
linktitle: Vzorce listu
type: docs
weight: 70
url: /cs/python-java/chart-worksheet-formulas/
keywords:
- graf tabulky
- list grafu
- vzorec grafu
- vzorec listu
- vzorec tabulky
- sešit dat grafu
- výpočet vzorců
- preferovaná kultura
- vzorec specifický pro kulturu
- DBCS
- logická konstanta
- číselná konstanta
- řetězcová konstanta
- chybová konstanta
- aritmetický operátor
- relační operátor
- styl A1
- styl R1C1
- předdefinovaná funkce
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Použít vzorce ve stylu Excel v Aspose.Slides pro Python přes Java na listech grafu, přepočítat hodnoty a použít výsledky v grafech PowerPointu."
---
## **Přehled**

Grafy v PowerPointu obvykle ukládají svá zdrojová data do vloženého listu. V Aspose.Slides pro Python přes Java můžete k tomuto listu přistupovat přes sešit dat grafu, zapisovat vstupní hodnoty, přiřazovat buňkám vzorce, vypočítávat podporované vzorce a použít vypočítané buňky jako data grafu.

Tento článek vysvětluje kompletní postup práce s vzorci: vytvořit graf, naplnit jeho list, přiřadit vzorce ve stylu A1 nebo R1C1, přepočítat je, přečíst vypočítané hodnoty, propojit tyto buňky s řadou grafu a uložit prezentaci. Také popisuje podporovanou syntaxi vzorců, vestavěnou podmnožinu funkcí, kešované hodnoty, nepodporované vzorce a chyby specifické pro tabulkové procesory.

## **Listy grafu a vzorce**

List grafu obsahuje kategorie, názvy sérií a hodnoty používané grafem. V PowerPointu můžete list zkontrolovat otevřením editoru dat grafu:

![Graf PowerPointu s otevřeným vloženým listem, zobrazující data kategorií a sérií](chart-worksheet-formulas_1.png)

V Aspose.Slides je list zpřístupněn přes třídu [ChartDataWorkbook](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdataworkbook/). Použijte [ChartDataCell.setFormula](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdatacell/#setFormula) pro vzorce ve stylu A1 a [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdatacell/#setR1C1Formula) pro vzorce ve stylu R1C1. Po změně vstupních buněk nebo vzorců zavolejte [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) pro přepočet podporovaných vzorců a aktualizaci odpovídajících hodnot buněk.

Vypočítaná buňka stále poskytuje svůj výsledek pomocí [ChartDataCell.getValue](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdatacell/#getValue). To je důležité, když potřebujete ve kódu zkontrolovat výsledek vzorce nebo použít buňku jako datový bod grafu.

## **Vytvoření grafu a výpočet vzorců v listu**

Následující příklad ukazuje kompletní postup. Vytvoří seskupený sloupcový graf, vymaže ukázková data, zapíše čtvrtletní příjmy a výdaje, vypočítá zisk pomocí vzorců, přečte výsledky, použije vypočítané buňky jako hodnoty grafu a uloží prezentaci.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 350)
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    workbook.clear(worksheet_index)

    category1 = workbook.getCell(worksheet_index, "A2", "Q1")
    category2 = workbook.getCell(worksheet_index, "A3", "Q2")
    category3 = workbook.getCell(worksheet_index, "A4", "Q3")

    workbook.getCell(worksheet_index, "B1", "Revenue")
    workbook.getCell(worksheet_index, "C1", "Expenses")
    workbook.getCell(worksheet_index, "D1", "Profit")

    workbook.getCell(worksheet_index, "B2").setValue(120.0)
    workbook.getCell(worksheet_index, "C2").setValue(80.0)
    workbook.getCell(worksheet_index, "B3").setValue(150.0)
    workbook.getCell(worksheet_index, "C3").setValue(95.0)
    workbook.getCell(worksheet_index, "B4").setValue(135.0)
    workbook.getCell(worksheet_index, "C4").setValue(110.0)

    profit1 = workbook.getCell(worksheet_index, "D2")
    profit2 = workbook.getCell(worksheet_index, "D3")
    profit3 = workbook.getCell(worksheet_index, "D4")

    profit1.setFormula("B2-C2")
    profit2.setFormula("B3-C3")
    profit3.setFormula("B4-C4")

    workbook.calculateFormulas()

    q1_profit = float(profit1.getValue()) # 40
    q2_profit = float(profit2.getValue()) # 55
    q3_profit = float(profit3.getValue()) # 25

    print("Q1 profit: ", q1_profit)
    print("Q2 profit: ", q2_profit)
    print("Q3 profit: ", q3_profit)

    chart.getChartData().getCategories().add(category1)
    chart.getChartData().getCategories().add(category2)
    chart.getChartData().getCategories().add(category3)

    profit_series = chart.getChartData().getSeries().add(workbook.getCell(worksheet_index, "D1"), chart.getType())
    profit_series.getDataPoints().addDataPointForBarSeries(profit1)
    profit_series.getDataPoints().addDataPointForBarSeries(profit2)
    profit_series.getDataPoints().addDataPointForBarSeries(profit3)
    profit_series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("chart-formulas.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Datové body grafu odkazují na `D2:D4`, takže graf používá vypočítané hodnoty zisku. V tomto postupu není potřeba samostatné volání pro obnovení grafu: nejprve přepočítejte sešit, poté použijte nebo uložte data grafu, která odkazují na vypočítané buňky.

## **Používání vzorců ve stylu A1**

Zápis A1 identifikuje sloupce písmeny a řádky čísly. Přiřaďte výrazy ve stylu A1 pomocí [ChartDataCell.setFormula](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdatacell/#setFormula).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "C3").setValue(10)
    workbook.getCell(0, "F2").setValue(2)
    workbook.getCell(0, "G2").setValue(3)
    workbook.getCell(0, "H2").setValue(4)

    cell = workbook.getCell(0, "A2")
    cell.setFormula("C3+SUM(F2:H2)")

    workbook.calculateFormulas()

    value = cell.getValue() # 19
finally:
    presentation.dispose()
```

Běžné formy odkazů A1 jsou:

| Odkaz | Relativní | Absolutní | Smíšený |
|---|---|---|---|
| Buňka | `A2` | `$A$2` | `A$2`, `$A2` |
| Řádek | `2:2` | `$2:$2` | — |
| Sloupec | `A:A` | `$A:$A` | — |
| Rozsah | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Relativní odkazy se mohou změnit, když je vzorec v tabulkovém procesoru přesunut nebo zkopírován. Absolutní odkazy mají pevně dané oba souřadnice, zatímco smíšené odkazy fixují pouze řádek nebo sloupec.

## **Používání vzorců ve stylu R1C1**

Zápis R1C1 číselně identifikuje řádky i sloupce. Relativní odkazy používají posuny ve hranatých závorkách. Tento syntaktický zápis přiřaďte pomocí [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdatacell/#setR1C1Formula).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "B2").setValue(12)
    workbook.getCell(0, "C2").setValue(5)

    cell = workbook.getCell(0, "D2")
    cell.setR1C1Formula("RC[-2]-RC[-1]")

    workbook.calculateFormulas()

    value = cell.getValue() # 7
finally:
    presentation.dispose()
```

Běžné formy odkazů R1C1 jsou:

| Odkaz | Relativní | Absolutní | Smíšený |
|---|---|---|---|
| Buňka | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Řádek | `R[2]` | `R2` | — |
| Sloupec | `C[3]` | `C3` | — |
| Rozsah | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Například v buňce `D2` výraz `RC[-2]` znamená buňku ve stejném řádku o dva sloupce vlevo (`B2`).

## **Konstanty a operátory ve vzorcích**

Vestavěný vyhodnocovač vzorců podporuje logické hodnoty, číselné literály, řetězce, chybové hodnoty tabulkových procesorů, aritmetické operátory a relační operátory.

### **Konstanty a literály**

| Typ | Příklady | Poznámky |
|---|---|---|
| Logická | `TRUE`, `FALSE` | Může být použita přímo v logických výrazech, např. `A2=TRUE`. |
| Číselná | `1`, `0.5`, `.3`, `1E-2` | Je podporována běžná i vědecká notace. |
| Řetězec | `"abc"`, `"2/3/2020 12:00"` | Textové literály jsou ve vzorci uzavřeny do dvojitých uvozovek. |
| Chybný výsledek | `#DIV/0!`, `#N/A`, `#REF!` | Platný vzorec může vyhodnotit chybovou hodnotu tabulky místo normálního výsledku. |

Tento příklad používá několik typů konstant:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "A2").setValue(False)
    workbook.getCell(0, "B2").setFormula("A2=TRUE")
    workbook.getCell(0, "C2").setFormula("1+0.5")
    workbook.getCell(0, "D2").setFormula(".3*1E-2")
    workbook.getCell(0, "E2").setFormula("\"abc\"")
    workbook.getCell(0, "F2").setFormula("2/0")

    workbook.calculateFormulas()

    logical_value = workbook.getCell(0, "B2").getValue() # False
    numeric_value = workbook.getCell(0, "C2").getValue() # 1.5
    scientific_value = workbook.getCell(0, "D2").getValue() # 0.003
    string_value = workbook.getCell(0, "E2").getValue() # abc
    error_value = workbook.getCell(0, "F2").getValue() # #DIV/0!
finally:
    presentation.dispose()
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

### **Relační operátory**

| Operátor | Význam | Příklad |
|---|---|---|
| `=` | Rovná se | `A2=3` |
| `<>` | Nerovná se | `A2<>3` |
| `>` | Větší než | `A2>3` |
| `>=` | Větší nebo rovno | `A2>=3` |
| `<` | Menší než | `A2<3` |
| `<=` | Menší nebo rovno | `A2<=3` |

## **Podporované předdefinované funkce**

Aspose.Slides obsahuje vestavěný vyhodnocovač vzorců pro listy grafů, ale není to kompletní výpočetní engine Excelu. Dokumentovaná sada funkcí je omezena na níže uvedené funkce. Nepředpokládejte, že libovolná Excelová funkce může být přepočítána metodou [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdataworkbook/#calculateFormulas).

| Funkce | Účel nebo podporovaný tvar | Příklad |
|---|---|---|
| `ABS` | Absolutní hodnota | `ABS(A2)` |
| `AVERAGE` | Aritmetický průměr | `AVERAGE(B2:B5)` |
| `CEILING` | Zaokrouhlí číslo směrem nahoru na násobek | `CEILING(A2,5)` |
| `CHOOSE` | Vybere hodnotu podle indexu | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Spojí textové hodnoty | `CONCAT(A2,B2)` |
| `CONCATENATE` | Spojí textové hodnoty | `CONCATENATE(A2," ",B2)` |
| `DATE` | Vytvoří datumovou hodnotu pomocí systému datumů 1900 | `DATE(2026,8,19)` |
| `DAYS` | Vrátí počet dní mezi daty | `DAYS(B2,A2)` |
| `FIND` | Najde jeden text uvnitř jiného | `FIND("-",A2)` |
| `FINDB` | Vyhledávání textu na bázi bajtů | `FINDB("a",A2)` |
| `IF` | Podmíněný výsledek | `IF(A2>0,A2,0)` |
| `INDEX` | Reference | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektorový tvar | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektorový tvar | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximální hodnota | `MAX(B2:B5)` |
| `SUM` | Součet hodnot | `SUM(B2:B5)` |
| `VLOOKUP` | Vertikální vyhledávání | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Omezení uvedená v tabulce jsou podstatná: `INDEX` je dokumentován ve formě reference, zatímco `LOOKUP` a `MATCH` jsou dokumentovány ve svých vektorových formách. `DATE` používá systém datumů 1900. Funkce a vlastnosti, které zde nejsou uvedeny, by měly být považovány za nepodporované vyhodnocovačem vzorců Aspose.Slides, pokud nejsou samostatně zdokumentovány.

## **Výpočet vzorců s preferovanou kulturou**

Některé funkce sešitu grafu interpretují text podle pravidel specifických pro kulturu. To je zvláště důležité pro funkce určené pro jazyky používající dvojbajtové znakové sady (DBCS). Pro správný výpočet takových vzorců vytvořte [LoadOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/loadoptions/), nastavte preferovanou kulturu pomocí [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/cs/python-java/aspose.slides/spreadsheetoptions/#setPreferredCulture), přiřaďte možnosti tabulky přes [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions), a poté načtěte prezentaci.

Následující příklad vybere japonskou kulturu, otevře prezentaci s nakonfigurovanými možnostmi načtení a zavolá [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) pro každý sešit grafu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, LoadOptions, Presentation, SpreadsheetOptions
from java.util import Locale

japanese_culture = Locale.forLanguageTag("ja-JP")

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setPreferredCulture(japanese_culture)

load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, Chart):
                shape.getChartData().getChartDataWorkbook().calculateFormulas()
finally:
    presentation.dispose()
```

Preferovaná kultura je součástí konfigurace načítání prezentace, takže ji nastavte před vytvořením instance [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/). Použijte kulturu očekávanou vzorci v sešitu; například použijte `ja-JP` pro vzorce, které mají sledovat japonská pravidla DBCS výpočtu.

## **Přepočet a kešované hodnoty**

Tabulkové soubory obvykle ukládají jak vzorec, tak jeho poslední vypočítanou hodnotu. Aspose.Slides tak může přečíst kešovanou hodnotu pomocí [ChartDataCell.getValue](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdatacell/#getValue), když je prezentace načtena a příslušná data grafu nebyla změněna.

Po změně vstupních buněk nebo vzorců se nespoléhejte na starý kešovaný výsledek. Zavolejte [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) před čtením vypočítaných hodnot nebo ukládáním dat grafu, která na nich závisí.

Pro vzorce mimo podporovanou podmnožinu může Aspose.Slides být ne schopno vzorec analyzovat nebo určit jeho závislosti. Pokud byl sešit upraven, předchozí kešovaná hodnota už není spolehlivá. V takové situaci může čtení hodnoty buňky s nepodporovanými daty vyvolat [CellUnsupportedDataException](https://reference.aspose.com/slides/cs/python-java/aspose.slides/cellunsupporteddataexception/).

Pokud váš graf závisí na Excelových funkcích, které Aspose.Slides nevyhodnocuje, vypočítejte tyto vzorce pomocí tabulkového enginu, který je podporuje, a zapište získané hodnoty zpět do sešitu grafu. Nepřepisujte nepodporované vzorce odhadovanými hodnotami.

## **Zpracování chyb ve vzorcích**

Existují dva různé typy problémů, které je nutné rozlišit.

Vzorec může být platný, ale vyprodukovat chybový výsledek tabulkového procesoru, například `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` nebo `#VALUE!`. V takovém případě je chybový token výsledkem buňky a může být vrácen pomocí [ChartDataCell.getValue](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdatacell/#getValue).

Vzorec může také selhat při parsování, v odkazech, závislostech nebo na úrovni podporovaných dat. Aspose.Slides poskytuje specifické výjimky pro tabulkové procesory: [CellInvalidFormulaException](https://reference.aspose.com/slides/cs/python-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/cs/python-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/cs/python-java/aspose.slides/cellcircularreferenceexception/), a [CellUnsupportedDataException](https://reference.aspose.com/slides/cs/python-java/aspose.slides/cellunsupporteddataexception/).

Když vzorce pocházejí ze šablon nebo uživatelského vstupu, ošetřete tyto výjimky při přepočítávání a přístupu k hodnotám:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CellCircularReferenceException, CellInvalidFormulaException, CellInvalidReferenceException, CellUnsupportedDataException, ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()
    cell = workbook.getCell(0, "A2")
    cell.setFormula("SUM(B2:B5)")

    try:
        workbook.calculateFormulas()
        print(cell.getValue())
    except CellInvalidFormulaException as ex:
        print("Invalid formula: " + str(ex.getMessage()))
    except CellInvalidReferenceException as ex:
        print("Invalid cell reference: " + str(ex.getMessage()))
    except CellCircularReferenceException as ex:
        print("Circular reference: " + str(ex.getMessage()))
    except CellUnsupportedDataException as ex:
        print("Unsupported spreadsheet data: " + str(ex.getMessage()))
finally:
    presentation.dispose()
```

## **Praktická omezení**

Podpora vzorců v listech grafů je určena pro definovanou podmnožinu výpočtů tabulkových procesorů, ne pro plnou kompatibilitu s Excelem. Mějte na paměti tato omezení při navrhování pracovního postupu reportování:

- Používejte pouze dokumentované konstanty, operátory, odkazy a funkce, pokud chcete, aby Aspose.Slides přepočítal vzorce.
- Přepočítejte po změně buněk, na kterých závisejí výsledky vzorců.
- Považujte kešované hodnoty z načtených prezentací za okamžitý snímek, nikoli za náhradu přepočítání po úpravách.
- Otestujte vzorce z existujících šablon, než se spolehnete na jejich vypočítané hodnoty, zejména pokud používají funkce mimo dokumentovaný seznam.
- Pro vzorce, které vyžadují kompletní výpočetní engine tabulkového procesoru, je vypočítejte externě a poté aktualizujte sešit grafu získanými hodnotami.

## **Často kladené otázky**

**Jaký je rozdíl mezi [ChartDataCell.setFormula](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdatacell/#setFormula) a [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdatacell/#setR1C1Formula)?**

[ChartDataCell.setFormula] ukládá výraz ve stylu A1, např. `B2-C2`. [ChartDataCell.setR1C1Formula] ukládá výraz ve stylu R1C1, např. `RC[-2]-RC[-1]`. Používejte zápis, který nejlépe odpovídá tomu, jak vzorce generujete nebo kopírujete.

**Potřebuji po výpočtu číst samotnou buňku nebo její hodnotu?**

[ChartDataWorkbook.getCell] vrací [ChartDataCell]. Pro získání vypočítaného výsledku zavolejte metodou [ChartDataCell.getValue] této buňky po přepočítání.

**Kdy bych měl zavolat [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdataworkbook/#calculateFormulas)?**

Zavolejte [ChartDataWorkbook.calculateFormulas] po změně vstupních hodnot nebo vzorců a před tím, než se spolehnete na vypočítané výsledky. Tím se aktualizují hodnoty vzorců, které podporuje vestavěný vyhodnocovač.

**Podporuje Aspose.Slides všechny Excel funkce?**

Ne. Vestavěný vyhodnocovač podporuje dokumentovanou podmnožinu funkcí. Funkce mimo tuto podmnožinu by neměly být považovány za správně přepočítatelné. Pokud je vyžadována plná kompatibilita s Excelovými vzorci, proveďte výpočet pomocí vhodného tabulkového enginu a zapíšete konečné hodnoty do sešitu grafu.

**Co se stane, pokud načtená prezentace obsahuje nepodporovaný vzorec?**

Pokud se data grafu nezměnila, sešit může stále obsahovat dříve vypočítanou kešovanou hodnotu. Po úpravě souvisejících dat tato kešovaná hodnota může přestat být platná. Přístup k buňce, jejíž vzorec nelze zpracovat, může vyvolat [CellUnsupportedDataException](https://reference.aspose.com/slides/cs/python-java/aspose.slides/cellunsupporteddataexception/).

**Jsou chybové hodnoty vzorců stejné jako výjimky?**

Ne. Výsledek jako `#DIV/0!` je chybová hodnota tabulky vzniklá při platném výpočtu. Výjimky jako [CellInvalidFormulaException](https://reference.aspose.com/slides/cs/python-java/aspose.slides/cellinvalidformulaexception/) nebo [CellCircularReferenceException](https://reference.aspose.com/slides/cs/python-java/aspose.slides/cellcircularreferenceexception/) naznačují, že vzorec nelze normálně zpracovat.

**Aktualizuje se graf automaticky, když se změní buňka vzorce?**

Série grafu může odkazovat na buňky sešitu. Nejprve přepočítejte sešit, poté uložte nebo vykreslete prezentaci. Pokud datové body grafu odkazují na vypočítané buňky, graf použije tyto aktualizované hodnoty; pro tento postup není vyžadována samostatná metoda pro obnovení grafu.

**Mohou grafy používat externí sešit Excel?**

Ano, data grafu lze nastavit tak, aby používala externí sešit pomocí API dat grafu. Přesto se postup výpočtu vzorců popsaný v tomto článku týká sešitu dat grafu a podmnožiny vzorců vyhodnocovaných Aspose.Slides. Nepředpokládejte, že [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) poskytuje úplný přepočet libovolných vzorců v externím souboru XLSX.

**Mohu používat vzorce, které odkazují na jiný list nebo sešit?**

Odkazy ve stylu Excelu mohou v sešitech grafů existovat, ale vyhodnocování vzorců je omezeno podporovaným parserem a sadou funkcí. Pokud je křížový odkaz na list či externí sešit nezbytný, ověřte tento konkrétní vzorec s verzí Aspose.Slides, kterou používáte. Pro pracovní postupy, které vyžadují širokou kompatibilitu odkazů Excelu, vypočítejte sešit externě a zapíšete získané hodnoty zpět do dat grafu.

**Měly by řetězce vzorců začínat znakem `=`?**

Příklady v API Aspose.Slides přiřazují výrazy jako `B2-C2` nebo `SUM(B2:B5)` bez úvodního `=`. Používání tohoto tvaru udržuje generované vzorce v souladu s dokumentovanými ukázkami API.