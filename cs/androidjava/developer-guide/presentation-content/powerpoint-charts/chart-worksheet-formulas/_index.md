---
title: Použití vzorců listu grafu v prezentacích na Androidu
linktitle: Vzorce listu
type: docs
weight: 70
url: /cs/androidjava/chart-worksheet-formulas/
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
- Android
- Java
- Aspose.Slides
description: "Použijte vzorce ve stylu Excel v Aspose.Slides pro Android pomocí Java listů grafu, přepočítejte hodnoty a použijte výsledky v grafech PowerPointu."
---
## **Přehled**

Grafy v PowerPointu obvykle ukládají svá zdrojová data do vloženého listu. V Aspose.Slides pro Android prostřednictvím Javy můžete k tomuto listu přistupovat prostřednictvím sešitu dat grafu, zapisovat vstupní hodnoty, přiřazovat buňkám vzorce, vypočítávat podporované vzorce a použít vypočítané buňky jako data grafu.

Článek popisuje kompletní workflow pro vzorce: vytvořit graf, naplnit jeho list, přiřadit vzorce ve stylu A1 nebo R1C1, přepočítat je, přečíst vypočítané hodnoty, připojit tyto buňky k sérii grafu a uložit prezentaci. Také popisuje podporovanou syntax vzorců, vestavěnou podmnožinu funkcí, cachované hodnoty, nepodporované vzorce a chyby specifické pro tabulky.

## **Listy grafů a vzorce**

List grafu obsahuje kategorie, názvy sérií a hodnoty použité v grafu. V PowerPointu můžete list prohlédnout otevřením editoru dat grafu:

![Graf PowerPointu s otevřeným vloženým listem, zobrazující data kategorií a sérií](chart-worksheet-formulas_1.png)

V Aspose.Slides je list vystaven prostřednictvím rozhraní [IChartDataWorkbook](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdataworkbook/). Použijte [IChartDataCell.setFormula](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) pro vzorce ve stylu A1 a [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) pro vzorce ve stylu R1C1. Po změně vstupních buněk nebo vzorců zavolejte [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) pro přepočítání podporovaných vzorců a aktualizaci odpovídajících hodnot buněk.

Vypočítaná buňka stále poskytuje svůj výsledek prostřednictvím [IChartDataCell.getValue](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatacell/#getValue--). To je důležité, když potřebujete v kódu zkontrolovat výsledek vzorce nebo použít buňku jako datový bod grafu.

## **Vytvoření grafu a výpočet vzorců v listu**

Následující příklad demonstruje kompletní workflow. Vytvoří sloupcový seskupený graf, vymaže ukázková data, zapíše čtvrtletní příjmy a výdaje, vypočítá zisk pomocí vzorců, přečte výsledky, použije vypočítané buňky jako hodnoty grafu a uloží prezentaci.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    workbook.clear(worksheetIndex);

    IChartDataCell category1 = workbook.getCell(worksheetIndex, "A2", "Q1");
    IChartDataCell category2 = workbook.getCell(worksheetIndex, "A3", "Q2");
    IChartDataCell category3 = workbook.getCell(worksheetIndex, "A4", "Q3");

    workbook.getCell(worksheetIndex, "B1", "Revenue");
    workbook.getCell(worksheetIndex, "C1", "Expenses");
    workbook.getCell(worksheetIndex, "D1", "Profit");

    workbook.getCell(worksheetIndex, "B2").setValue(120.0);
    workbook.getCell(worksheetIndex, "C2").setValue(80.0);
    workbook.getCell(worksheetIndex, "B3").setValue(150.0);
    workbook.getCell(worksheetIndex, "C3").setValue(95.0);
    workbook.getCell(worksheetIndex, "B4").setValue(135.0);
    workbook.getCell(worksheetIndex, "C4").setValue(110.0);

    IChartDataCell profit1 = workbook.getCell(worksheetIndex, "D2");
    IChartDataCell profit2 = workbook.getCell(worksheetIndex, "D3");
    IChartDataCell profit3 = workbook.getCell(worksheetIndex, "D4");

    profit1.setFormula("B2-C2");
    profit2.setFormula("B3-C3");
    profit3.setFormula("B4-C4");

    workbook.calculateFormulas();

    double q1Profit = ((Number) profit1.getValue()).doubleValue(); // 40
    double q2Profit = ((Number) profit2.getValue()).doubleValue(); // 55
    double q3Profit = ((Number) profit3.getValue()).doubleValue(); // 25

    System.out.println("Q1 profit: " + q1Profit);
    System.out.println("Q2 profit: " + q2Profit);
    System.out.println("Q3 profit: " + q3Profit);

    chart.getChartData().getCategories().add(category1);
    chart.getChartData().getCategories().add(category2);
    chart.getChartData().getCategories().add(category3);

    IChartSeries profitSeries = chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, "D1"), chart.getType());
    profitSeries.getDataPoints().addDataPointForBarSeries(profit1);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit2);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit3);
    profitSeries.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("chart-formulas.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Datové body grafu odkazují na `D2:D4`, takže graf používá vypočítané hodnoty zisku. V tomto workflow není volání samostatného obnovení grafu: nejprve přepočítejte sešit, poté použijte nebo uložte data grafu, která odkazují na vypočítané buňky.

## **Použití vzorců ve stylu A1**

Notace A1 identifikuje sloupce písmeny a řádky čísly. Přiřaďte výrazy ve stylu A1 pomocí [IChartDataCell.setFormula](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "C3").setValue(10);
    workbook.getCell(0, "F2").setValue(2);
    workbook.getCell(0, "G2").setValue(3);
    workbook.getCell(0, "H2").setValue(4);

    IChartDataCell cell = workbook.getCell(0, "A2");
    cell.setFormula("C3+SUM(F2:H2)");

    workbook.calculateFormulas();

    Object value = cell.getValue(); // 19
} finally {
    presentation.dispose();
}
```

Obvyklé formy referencí A1 jsou:

| Reference | Relativní | Absolutní | Smíšené |
|---|---|---|---|
| Buňka | `A2` | `$A$2` | `A$2`, `$A2` |
| Řádek | `2:2` | `$2:$2` | — |
| Sloupec | `A:A` | `$A:$A` | — |
| Rozsah | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Relativní odkazy se mohou změnit, když je vzorec v tabulkovém procesoru přesunut nebo zkopírován. Absolutní odkazy udržují obě souřadnice pevně, zatímco smíšené odkazy fixují jen řádek nebo sloupec.

## **Použití vzorců ve stylu R1C1**

Notace R1C1 identifikuje řádky i sloupce numericky. Relativní odkazy používají posuny ve hranatých závorkách. Tuto syntaxi přiřaďte pomocí [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "B2").setValue(12);
    workbook.getCell(0, "C2").setValue(5);

    IChartDataCell cell = workbook.getCell(0, "D2");
    cell.setR1C1Formula("RC[-2]-RC[-1]");

    workbook.calculateFormulas();

    Object value = cell.getValue(); // 7
} finally {
    presentation.dispose();
}
```

Obvyklé formy referencí R1C1 jsou:

| Reference | Relativní | Absolutní | Smíšené |
|---|---|---|---|
| Buňka | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Řádek | `R[2]` | `R2` | — |
| Sloupec | `C[3]` | `C3` | — |
| Rozsah | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Například v buňce `D2` znamená `RC[-2]` buňku v tomtéž řádku o dva sloupce vlevo (`B2`).

## **Konstanty a operátory ve vzorcích**

Vestavěný vyhodnocovač vzorců podporuje logické hodnoty, číselné literály, řetězce, chybové hodnoty tabulky, aritmetické operátory a porovnávací operátory.

### **Konstanty a literály**

| Typ | Příklady | Poznámky |
|---|---|---|
| Logická | `TRUE`, `FALSE` | Lze použít přímo v logických výrazích, např. `A2=TRUE`. |
| Číselná | `1`, `0.5`, `.3`, `1E-2` | Je podporována běžná i vědecká notace. |
| Řetězec | `"abc"`, `"2/3/2020 12:00"` | Textové literály jsou ve vzorci uzavřeny do dvojitých uvozovek. |
| Výsledek chyby | `#DIV/0!`, `#N/A`, `#REF!` | Platný vzorec může vyhodnotit chybovou hodnotu tabulky místo normálního výsledku. |

Tento příklad používá několik typů konstant:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "A2").setValue(false);
    workbook.getCell(0, "B2").setFormula("A2=TRUE");
    workbook.getCell(0, "C2").setFormula("1+0.5");
    workbook.getCell(0, "D2").setFormula(".3*1E-2");
    workbook.getCell(0, "E2").setFormula("\"abc\"");
    workbook.getCell(0, "F2").setFormula("2/0");

    workbook.calculateFormulas();

    Object logicalValue = workbook.getCell(0, "B2").getValue(); // nepravda
    Object numericValue = workbook.getCell(0, "C2").getValue(); // 1.5
    Object scientificValue = workbook.getCell(0, "D2").getValue(); // 0.003
    Object stringValue = workbook.getCell(0, "E2").getValue(); // abc
    Object errorValue = workbook.getCell(0, "F2").getValue(); // #DIV/0!
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

Použijte závorky pro explicitní určení pořadí vyhodnocení, např. `(A2+B2)*C2`.

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

Aspose.Slides obsahuje vestavěný vyhodnocovač vzorců pro listy grafů, ale nejedná se o kompletní výpočetní engine Excelu. Dokumentovaná množina funkcí je omezena na níže uvedené funkce. Nepředpokládejte, že libovolná Excel funkce může být přepočítána pomocí [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--).

| Funkce | Účel nebo podpořený tvar | Příklad |
|---|---|---|
| `ABS` | Absolutní hodnota | `ABS(A2)` |
| `AVERAGE` | Aritmetický průměr | `AVERAGE(B2:B5)` |
| `CEILING` | Zaokrouhlí číslo nahoru na násobek | `CEILING(A2,5)` |
| `CHOOSE` | Vybere hodnotu podle indexu | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Spojí textové hodnoty | `CONCAT(A2,B2)` |
| `CONCATENATE` | Spojí textové hodnoty | `CONCATENATE(A2," ",B2)` |
| `DATE` | Vytvoří datumovou hodnotu pomocí systému dat 1900 | `DATE(2026,8,19)` |
| `DAYS` | Vrátí počet dní mezi daty | `DAYS(B2,A2)` |
| `FIND` | Najde jeden textový řetězec v jiném | `FIND("-",A2)` |
| `FINDB` | Vyhledávání textu orientované na bajty | `FINDB("a",A2)` |
| `IF` | Podmíněný výsledek | `IF(A2>0,A2,0)` |
| `INDEX` | Referenční forma | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektorová forma | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektorová forma | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximální hodnota | `MAX(B2:B5)` |
| `SUM` | Součet hodnot | `SUM(B2:B5)` |
| `VLOOKUP` | Vertikální vyhledávání | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Uvedená omezení v tabulce jsou podstatná: `INDEX` je dokumentován ve formě reference, zatímco `LOOKUP` a `MATCH` jsou dokumentovány ve svých vektorových formách. `DATE` používá systém dat 1900. Funkce a vlastnosti, které zde nejsou uvedeny, by měly být považovány za nepodporované vyhodnocovačem vzorců Aspose.Slides, pokud nejsou dokumentovány samostatně.

## **Přepočet a cachované hodnoty**

Tabulkové soubory běžně ukládají jak vzorec, tak jeho naposledy vypočítanou hodnotu. Aspose.Slides tak může načíst cachovanou hodnotu z [IChartDataCell.getValue](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatacell/#getValue--) když je prezentace načtena a příslušná data grafu nebyla změněna.

Po změně vstupních buněk nebo vzorců nespoléhejte na starý cachovaný výsledek. Zavolejte [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) před čtením vypočítaných hodnot nebo uložením dat grafu, na které závisí.

U vzorců mimo podporovanou podmnožinu může Aspose.Slides selhat při parsování vzorce nebo určení jeho závislostí. Pokud byl sešit upraven, předchozí cachovaná hodnota již nemůže být považována za spolehlivou. V takové situaci může čtení hodnoty buňky s nepodporovanými daty vyvolat [CellUnsupportedDataException](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/cellunsupporteddataexception/).

Pokud váš graf závisí na Excel funkcích, které Aspose.Slides nevyhodnocuje, vypočítejte tyto vzorce pomocí tabulkového enginu, který je podporuje, a zapište získané hodnoty zpět do sešitu grafu. Nepřepisujte nepodporované vzorce odhadovanými hodnotami.

## **Zpracování chyb ve vzorcích**

Existují dva různé typy problémů, které je třeba rozlišit.

Vzorec může být platný, ale vrátit chybový výsledek tabulky, jako je `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` nebo `#VALUE!`. V tomto případě je token chyby výsledkem buňky a může být vrácen prostřednictvím [IChartDataCell.getValue](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatacell/#getValue--).

Vzorec může také selhat na úrovni parsování, odkazu, závislosti nebo podporovaných dat. Aspose.Slides poskytuje pro tyto případy specifické výjimky tabulky: [CellInvalidFormulaException](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/cellcircularreferenceexception/), a [CellUnsupportedDataException](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/cellunsupporteddataexception/).

Když vzorce pocházejí ze šablon nebo uživatelského vstupu, ošetřete tyto výjimky při přepočítávání a přístupu k hodnotě:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell cell = workbook.getCell(0, "A2");
    cell.setFormula("SUM(B2:B5)");

    try {
        workbook.calculateFormulas();
        System.out.println(cell.getValue());
    } catch (CellInvalidFormulaException ex) {
        System.err.println("Invalid formula: " + ex.getMessage());
    } catch (CellInvalidReferenceException ex) {
        System.err.println("Invalid cell reference: " + ex.getMessage());
    } catch (CellCircularReferenceException ex) {
        System.err.println("Circular reference: " + ex.getMessage());
    } catch (CellUnsupportedDataException ex) {
        System.err.println("Unsupported spreadsheet data: " + ex.getMessage());
    }
} finally {
    presentation.dispose();
}
```

## **Praktická omezení**

Podpora vzorců v listech grafů je určena pro definovanou podmnožinu tabulkových výpočtů, nikoli pro kompletní kompatibilitu s Excelem. Mějte tyto omezení na paměti při navrhování workflow pro reporting:

- Používejte pouze dokumentované konstanty, operátory, odkazy a funkce, pokud potřebujete, aby Aspose.Slides přepočítal vzorce.
- Přepočítejte po změně buněk, na nichž výsledky vzorců závisí.
- Považujte cachované hodnoty z načtených prezentací za snímky, ne za náhradu přepočítání po úpravách.
- Otestujte vzorce z existujících šablon před tím, než se spolehnete na jejich vypočítané hodnoty, zejména pokud používají funkce mimo dokumentovaný seznam.
- U vzorců, které vyžadují plnohodnotný výpočetní engine tabulek, je vypočítejte externě a poté aktualizujte sešit grafu získanými hodnotami.

## **FAQ**

**Jaký je rozdíl mezi [IChartDataCell.setFormula](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) a [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-)?**

[IChartDataCell.setFormula](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) ukládá výraz ve stylu A1, například `B2-C2`. [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) ukládá výraz ve stylu R1C1, například `RC[-2]-RC[-1]`. Použijte notaci, která nejlépe odpovídá tomu, jak vzorce generujete nebo kopírujete.

**Musím po výpočtu číst samotnou buňku nebo její hodnotu?**

[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-java.lang.String-) vrací objekt [IChartDataCell](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatacell/). Pro získání vypočítaného výsledku zavolejte metodu [IChartDataCell.getValue](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatacell/#getValue--) této buňky po přepočítání.

**Kdy mám zavolat [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--)?**

Zavolejte [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) po změně vstupních hodnot nebo vzorců a před tím, než se spolehnete na vypočítané výsledky. Tím se aktualizují hodnoty vzorců, které podporuje vestavěný vyhodnocovač.

**Podporuje Aspose.Slides každou Excel funkci?**

Není. Vestavěný vyhodnocovač podporuje dokumentovanou podmnožinu funkcí. Funkce mimo tuto podmnožinu by neměly být považovány za správně přepočítatelné. Pokud je vyžadována úplná kompatibilita s Excel vzorci, proveďte výpočet pomocí vhodného tabulkového enginu a zapíšete konečné hodnoty do sešitu grafu.

**Co se stane, pokud načtená prezentace obsahuje nepodporovaný vzorec?**

Pokud data grafu nebyla změněna, může sešit stále obsahovat dříve vypočítanou cachovanou hodnotu. Po úpravě souvisejících dat tato cachovaná hodnota může přestat být platná. Přístup k buňce, jejíž vzorec nelze zpracovat, může vyvolat [CellUnsupportedDataException](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/cellunsupporteddataexception/).

**Jsou hodnoty chyb ve vzorcích stejné jako Java výjimky?**

Není. Výsledek jako `#DIV/0!` je hodnotou tabulky vzniklou při platném výpočtu. Výjimky jako [CellInvalidFormulaException](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/cellinvalidformulaexception/) nebo [CellCircularReferenceException](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/cellcircularreferenceexception/) naznačují, že vzorec nelze normálně zpracovat.

**Aktualizuje se graf automaticky, když se změní buňka vzorce?**

Série grafu může odkazovat na buňky sešitu. Nejprve přepočítejte sešit, poté uložte nebo vykreslete prezentaci. Pokud datové body grafu odkazují na vypočítané buňky, graf použije tyto aktualizované hodnoty buněk; pro tento workflow není vyžadována samostatná metoda obnovení grafu.

**Mohou grafy používat externí Excel sešit?**

Ano, data grafu lze nakonfigurovat tak, aby používala externí sešit prostřednictvím API dat grafu. Nicméně workflow výpočtu vzorců popsaný v tomto článku se týká sešitu dat grafu a podmnožiny vzorců vyhodnocovaných Aspose.Slides. Nepředpokládejte, že [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) poskytuje úplný přepočet libovolných vzorců v externím souboru XLSX.

**Mohu použít vzorce, které odkazují na jiný list nebo sešit?**

Odkazy ve stylu Excelu mohou v sešitech grafů existovat, ale vyhodnocování vzorců je omezeno podporovaným parserem a sadou funkcí. Pokud je křížový odkaz na list nebo externí odkaz nezbytný, ověřte konkrétní vzorec s vaší cílovou verzí Aspose.Slides. Pro workflow, které vyžadují širokou kompatibilitu odkazů Excelu, vypočítejte sešit externě a zapisujte vyřešené hodnoty zpět do dat grafu.

**Měly by řetězce vzorců začínat znakem `=`?**

Příklady v API Aspose.Slides přiřazují výrazy jako `B2-C2` nebo `SUM(B2:B5)` bez úvodního `=`. Používání této podoby zachovává generované vzorce v souladu s dokumentovanými příklady API.