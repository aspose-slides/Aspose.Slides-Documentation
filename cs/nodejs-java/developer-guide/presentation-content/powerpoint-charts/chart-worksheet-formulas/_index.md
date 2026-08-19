---
title: Použít vzorce listu grafu v prezentacích pomocí JavaScriptu
linktitle: Vzorce listu
type: docs
weight: 70
url: /cs/nodejs-java/chart-worksheet-formulas/
keywords:
- graf tabulkový list
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Použít vzorce ve stylu Excel v Aspose.Slides pro Node.js přes Java listy grafu, přepočítat hodnoty a použít výsledky v grafech PowerPointu."
---
## **Přehled**

Grafy v PowerPointu obvykle ukládají svá zdrojová data do vloženého listu. V Aspose.Slides pro Node.js přes Java můžete k tomuto listu přistupovat prostřednictvím sešitu s daty grafu, zapisovat vstupní hodnoty, přiřazovat buňkám vzorce, vypočítávat podporované vzorce a použít vypočítané buňky jako data grafu.

Tento článek vysvětluje kompletní workflow vzorců: vytvořit graf, naplnit jeho list, přiřadit vzorce ve stylu A1 nebo R1C1, přepočítat je, přečíst vypočítané hodnoty, propojit tyto buňky s řadou grafu a uložit prezentaci. Dále popisuje podporovanou syntaxi vzorců, vestavěnou podmnožinu funkcí, kešované hodnoty, nepodporované vzorce a chyby specifické pro tabulkové procesory.

## **Listy grafu a vzorce**

List grafu obsahuje kategorie, názvy sérií a hodnoty použité v grafu. v PowerPointu můžete list prohlížet otevřením editoru dat grafu:

![Graf PowerPointu s otevřeným vloženým listem, zobrazující data kategorií a sérií](chart-worksheet-formulas_1.png)

V Aspose.Slides je list zpřístupněn přes třídu [ChartDataWorkbook](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdataworkbook/). Použijte [ChartDataCell.setFormula](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) pro vzorce ve stylu A1 a [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) pro vzorce ve stylu R1C1. Po změně vstupních buněk nebo vzorců zavolejte [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) pro přepočet podporovaných vzorců a aktualizaci odpovídajících hodnot buněk.

Vypočítaná buňka stále vystavuje svůj výsledek přes [ChartDataCell.getValue](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdatacell/#getValue--). To je důležité, když potřebujete v kódu zkontrolovat výsledek vzorce nebo použít buňku jako datový bod grafu.

## **Vytvoření grafu a výpočet vzorců v listu**

Následující příklad demonstruje kompletní workflow. Vytvoří seskupený sloupcový graf, vymaže ukázková data, zapíše čtvrtletní příjmy a výdaje, vypočítá zisk pomocí vzorců, přečte výsledky, použije vypočítané buňky jako hodnoty grafu a uloží prezentaci.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 350);
    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    workbook.clear(worksheetIndex);

    const category1 = workbook.getCell(worksheetIndex, "A2", "Q1");
    const category2 = workbook.getCell(worksheetIndex, "A3", "Q2");
    const category3 = workbook.getCell(worksheetIndex, "A4", "Q3");

    workbook.getCell(worksheetIndex, "B1", "Revenue");
    workbook.getCell(worksheetIndex, "C1", "Expenses");
    workbook.getCell(worksheetIndex, "D1", "Profit");

    workbook.getCell(worksheetIndex, "B2").setValue(120.0);
    workbook.getCell(worksheetIndex, "C2").setValue(80.0);
    workbook.getCell(worksheetIndex, "B3").setValue(150.0);
    workbook.getCell(worksheetIndex, "C3").setValue(95.0);
    workbook.getCell(worksheetIndex, "B4").setValue(135.0);
    workbook.getCell(worksheetIndex, "C4").setValue(110.0);

    const profit1 = workbook.getCell(worksheetIndex, "D2");
    const profit2 = workbook.getCell(worksheetIndex, "D3");
    const profit3 = workbook.getCell(worksheetIndex, "D4");

    profit1.setFormula("B2-C2");
    profit2.setFormula("B3-C3");
    profit3.setFormula("B4-C4");

    workbook.calculateFormulas();

    const q1Profit = profit1.getValue(); // 40
    const q2Profit = profit2.getValue(); // 55
    const q3Profit = profit3.getValue(); // 25

    console.log("Q1 profit: " + q1Profit);
    console.log("Q2 profit: " + q2Profit);
    console.log("Q3 profit: " + q3Profit);

    chart.getChartData().getCategories().add(category1);
    chart.getChartData().getCategories().add(category2);
    chart.getChartData().getCategories().add(category3);

    const profitSeries = chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, "D1"), chart.getType());
    profitSeries.getDataPoints().addDataPointForBarSeries(profit1);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit2);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit3);
    profitSeries.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("chart-formulas.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Datové body grafu odkazují na `D2:D4`, takže graf používá vypočítané hodnoty zisku. V tomto workflow není potřeba samostatné volání pro obnovení grafu: nejprve přepočítejte sešit, pak použijte nebo uložte data grafu, která ukazují na vypočítané buňky.

## **Použití vzorců ve stylu A1**

A1 zápis identifikuje sloupce písmeny a řádky čísly. Přiřaďte výrazy ve stylu A1 prostřednictvím [ChartDataCell.setFormula](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-).

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "C3").setValue(10);
    workbook.getCell(0, "F2").setValue(2);
    workbook.getCell(0, "G2").setValue(3);
    workbook.getCell(0, "H2").setValue(4);

    const cell = workbook.getCell(0, "A2");
    cell.setFormula("C3+SUM(F2:H2)");

    workbook.calculateFormulas();

    const value = cell.getValue(); // 19
} finally {
    presentation.dispose();
}
```

Běžné formy odkazů A1 jsou:

| Odkaz | Relativní | Absolutní | Smíšený |
|---|---|---|---|
| Buňka | `A2` | `$A$2` | `A$2`, `$A2` |
| Řádek | `2:2` | `$2:$2` | — |
| Sloupec | `A:A` | `$A:$A` | — |
| Rozsah | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Relativní odkazy se mohou změnit, když je vzorec v tabulkovém procesoru přesunut nebo zkopírován. Absolutní odkazy udržují obě souřadnice pevně, zatímco smíšené odkazy fixují pouze řádek nebo sloupec.

## **Použití vzorců ve stylu R1C1**

R1C1 zápis identifikuje řádky i sloupce číselně. Relativní odkazy používají posuny v hranatých závorkách. Tento zápis přiřaďte prostřednictvím [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-).

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "B2").setValue(12);
    workbook.getCell(0, "C2").setValue(5);

    const cell = workbook.getCell(0, "D2");
    cell.setR1C1Formula("RC[-2]-RC[-1]");

    workbook.calculateFormulas();

    const value = cell.getValue(); // 7
} finally {
    presentation.dispose();
}
```

Běžné formy odkazů R1C1 jsou:

| Odkaz | Relativní | Absolutní | Smíšený |
|---|---|---|---|
| Buňka | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Řádek | `R[2]` | `R2` | — |
| Sloupec | `C[3]` | `C3` | — |
| Rozsah | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Například v buňce `D2` znamená `RC[-2]` buňku ve stejném řádku o dva sloupce vlevo (`B2`).

## **Konstanty a operátory ve vzorcích**

Vestavěný vyhodnocovač vzorců podporuje logické hodnoty, číselné literály, řetězce, hodnoty chyb tabulkového procesoru, aritmetické operátory a porovnávací operátory.

### **Konstanty a literály**

| Typ | Příklady | Poznámky |
|---|---|---|
| Logická | `TRUE`, `FALSE` | Lze použít přímo v logických výrazech, např. `A2=TRUE`. |
| Číselná | `1`, `0.5`, `.3`, `1E-2` | Podporována běžná i vědecká notace. |
| Řetězec | `"abc"`, `"2/3/2020 12:00"` | Textové literály jsou ve vzorci uzavřeny v dvojitých uvozovkách. |
| Výsledek chyby | `#DIV/0!`, `#N/A`, `#REF!` | Platný vzorec může vyhodnotit hodnotu chyby místo běžného výsledku. |

Tento příklad používá několik typů konstant:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "A2").setValue(false);
    workbook.getCell(0, "B2").setFormula("A2=TRUE");
    workbook.getCell(0, "C2").setFormula("1+0.5");
    workbook.getCell(0, "D2").setFormula(".3*1E-2");
    workbook.getCell(0, "E2").setFormula("\"abc\"");
    workbook.getCell(0, "F2").setFormula("2/0");

    workbook.calculateFormulas();

    const logicalValue = workbook.getCell(0, "B2").getValue(); // nepravda
    const numericValue = workbook.getCell(0, "C2").getValue(); // 1.5
    const scientificValue = workbook.getCell(0, "D2").getValue(); // 0.003
    const stringValue = workbook.getCell(0, "E2").getValue(); // abc
    const errorValue = workbook.getCell(0, "F2").getValue(); // #DIV/0!
} finally {
    presentation.dispose();
}
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

Použijte závorky pro explicitní určení pořadí vyhodnocování, např. `(A2+B2)*C2`.

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

Aspose.Slides obsahuje vestavěný vyhodnocovač vzorců pro listy grafů, ale není to kompletní výpočetní engine Excelu. Dokumentovaná sada funkcí je omezená na níže uvedené funkce. Nepředpokládejte, že libovolná Excel funkce bude přepočítána pomocí [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--).

| Funkce | Účel nebo podpora forma | Příklad |
|---|---|---|
| `ABS` | Absolutní hodnota | `ABS(A2)` |
| `AVERAGE` | Aritmetický průměr | `AVERAGE(B2:B5)` |
| `CEILING` | Zaokrouhlit číslo nahoru na násobek | `CEILING(A2,5)` |
| `CHOOSE` | Vybrat hodnotu podle indexu | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Spojit textové hodnoty | `CONCAT(A2,B2)` |
| `CONCATENATE` | Spojit textové hodnoty | `CONCATENATE(A2," ",B2)` |
| `DATE` | Vytvořit datum pomocí systému 1900 | `DATE(2026,8,19)` |
| `DAYS` | Vrátit počet dní mezi daty | `DAYS(B2,A2)` |
| `FIND` | Najít jeden text v druhém | `FIND("-",A2)` |
| `FINDB` | Hledání textu po bajtech | `FINDB("a",A2)` |
| `IF` | Podmíněný výsledek | `IF(A2>0,A2,0)` |
| `INDEX` | Reference forma | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektorová forma | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektorová forma | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximální hodnota | `MAX(B2:B5)` |
| `SUM` | Součet hodnot | `SUM(B2:B5)` |
| `VLOOKUP` | Vertikální vyhledávání | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Omezení uvedená v tabulce jsou podstatná: `INDEX` je dokumentován ve formě reference, zatímco `LOOKUP` a `MATCH` jsou dokumentovány ve svých vektorových formách. `DATE` používá systém 1900. Funkce a vlastnosti, které zde nejsou uvedeny, by měly být považovány za nepodporované vestavěným vyhodnocovačem Aspose.Slides, pokud nejsou samostatně dokumentovány.

## **Přepočet a kešované hodnoty**

Tabulkové soubory často ukládají jak vzorec, tak jeho naposledy vypočítanou hodnotu. Aspose.Slides tak může při načtení prezentace a pokud data grafu nebyla změněna, přečíst kešovanou hodnotu z [ChartDataCell.getValue](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdatacell/#getValue--).

Po změně vstupních buněk nebo vzorců se nespoléhejte na starý kešovaný výsledek. Zavolejte [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) před čtením vypočítaných hodnot nebo před uložením grafu, který na nich závisí.

U vzorců mimo podporovaný podmnožinu může Aspose.Slides nedokázat vzorec rozparsovat nebo zjistit jeho závislosti. Pokud byl sešit modifikován, předchozí kešovaná hodnota již nemusí být spolehlivá. V takové situaci může čtení buňky s nepodporovanými daty vyvolat [CellUnsupportedDataException](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/cellunsupporteddataexception/).

Pokud váš graf závisí na Excel funkcích, které Aspose.Slides nevyhodnocuje, vypočítejte tyto vzorce pomocí tabulkového enginu, který je podporuje, a zapište získané hodnoty zpět do sešitu grafu. Nepřepisujte nepodporované vzorce odhadovanými hodnotami.

## **Zpracování chyb ve vzorcích**

Existují dva různé typy problémů, které je třeba rozlišovat.

Vzorec může být platný, ale vrátit výsledek chyby tabulkového procesoru, jako je `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` nebo `#VALUE!`. V tomto případě je token chyby výsledkem buňky a může být vrácen přes [ChartDataCell.getValue](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdatacell/#getValue--).

Vzorec může také selhat při parsování, odkazování, závislostech nebo na úrovni podporovaných dat. Aspose.Slides poskytuje pro tyto případy specifické výjimky tabulkových procesorů: [CellInvalidFormulaException](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/cellcircularreferenceexception/), a [CellUnsupportedDataException](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/cellunsupporteddataexception/).

Když vzorce pocházejí ze šablon nebo uživatelského vstupu, zachytávejte chyby při přepočtu a přístupu k hodnotám. Podrobnosti o chybě identifikují podkladový problém tabulkového procesoru:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();
    const cell = workbook.getCell(0, "A2");
    cell.setFormula("SUM(B2:B5)");

    try {
        workbook.calculateFormulas();
        console.log(cell.getValue());
    } catch (error) {
        console.error("Formula processing error: " + error.message);
    }
} finally {
    presentation.dispose();
}
```

## **Praktická omezení**

Podpora vzorců v listech grafů je určena pro definovaný podmnožinu výpočtů tabulkových procesorů, nikoli pro plnou kompatibilitu s Excelem. Mějte tyto omezení na paměti při návrhu pracovního postupu reportování:

- Používejte pouze dokumentované konstanty, operátory, odkazy a funkce, pokud chcete, aby Aspose.Slides přepočítával vzorce.
- Přepočítejte po změně buněk, na jejichž výsledcích jsou vzorce závislé.
- Považujte kešované hodnoty z načtených prezentací za okamžité snímky, ne za náhradu přepočtu po úpravách.
- Otestujte vzorce z existujících šablon před spoleháním se na jejich vypočítané hodnoty, zejména pokud používají funkce mimo dokumentovaný seznam.
- Pro vzorce, které vyžadují plnohodnotný výpočetní engine tabulkového procesoru, je vypočítejte externě a poté aktualizujte sešit grafu získanými hodnotami.

## **Často kladené otázky**

**Jaký je rozdíl mezi [ChartDataCell.setFormula](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) a [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-)?**

[ChartDataCell.setFormula](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) ukládá výraz ve stylu A1, například `B2-C2`. [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) ukládá výraz ve stylu R1C1, například `RC[-2]-RC[-1]`. Použijte zápis, který nejlépe odpovídá tomu, jak vzorce generujete nebo kopírujete.

**Musím po výpočtu číst samotnou buňku nebo její hodnotu?**

[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdataworkbook/#getCell-int-java.lang.String-) vrací objekt [ChartDataCell](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdatacell/). Pro získání vypočítaného výsledku zavolejte metodu [ChartDataCell.getValue](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdatacell/#getValue--) té buňky po přepočtu.

**Kdy mám zavolat [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--)?**

Zavolejte [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) po změně vstupních hodnot nebo vzorců a před tím, než budete spoléhat na vypočítané výsledky. Tím se aktualizují hodnoty vzorců, které podporuje vestavěný vyhodnocovač.

**Podporuje Aspose.Slides všechny Excel funkce?**

Ne. Vestavěný vyhodnocovač podporuje jen dokumentovanou podmnožinu funkcí. Funkce mimo tuto podmnožinu by neměly být považovány za správně přepočítatelné. Pokud je vyžadována úplná kompatibilita s Excel vzorci, proveďte výpočet pomocí vhodného tabulkového enginu a výsledné hodnoty zapište do sešitu grafu.

**Co se stane, pokud načtená prezentace obsahuje nepodporovaný vzorec?**

Pokud data grafu nebyla změněna, sešit může stále obsahovat dříve vypočítanou kešovanou hodnotu. Po úpravě souvisejících dat tato kešovaná hodnota již nemusí být platná. Přístup k buňce, jejíž vzorec nelze zpracovat, může vyvolat [CellUnsupportedDataException](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/cellunsupporteddataexception/).

**Jsou hodnoty chyb ve vzorcích stejné jako výjimky?**

Ne. Výsledek jako `#DIV/0!` je hodnota tabulky vytvořená platným výpočtem. Výjimky jako [CellInvalidFormulaException](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/cellinvalidformulaexception/) nebo [CellCircularReferenceException](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/cellcircularreferenceexception/) indikují, že vzorec nelze normálně zpracovat.

**Aktualizuje se graf automaticky, když se změní buňka s vzorcem?**

Série grafu může odkazovat na buňky sešitu. Nejprve přepočítejte sešit, poté prezentaci uložte nebo vykreslete. Pokud datové body grafu odkazují na vypočítané buňky, graf použije aktualizované hodnoty buněk; není potřeba žádná samostatná metoda pro obnovení grafu v tomto workflow.

**Mohou grafy používat externí Excel sešit?**

Ano, data grafu lze nakonfigurovat tak, aby používala externí sešit prostřednictvím API pro data grafu. Nicméně workflow výpočtu vzorců popsané v tomto článku se týká sešitu dat grafu a podmnožiny vzorců vyhodnocovaných Aspose.Slides. Nepředpokládejte, že [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) poskytuje úplný přepočet libovolných vzorců v externím XLSX souboru.

**Mohu použít vzorce, které odkazují na jiný list nebo sešit?**

Odkazy ve stylu Excelu mohou v sekcích grafů existovat, ale vyhodnocování vzorců je omezeno podporovaným parserem a sadou funkcí. Pokud je nezbytný odkaz napříč listy nebo externí odkaz, ověřte si přesný vzorec s vaší cílovou verzí Aspose.Slides. Pro workflow, které vyžadují širokou kompatibilitu Excel odkazů, vypočítejte sešit externě a zapište vyřešené hodnoty zpět do dat grafu.

**Měly by řetězce vzorců začínat znakem `=`?**

Příklady v API Aspose.Slides přiřazují výrazy jako `B2-C2` nebo `SUM(B2:B5)` bez úvodního `=`. Použití tohoto tvaru udržuje generované vzorce v souladu s dokumentovanými příklady API.