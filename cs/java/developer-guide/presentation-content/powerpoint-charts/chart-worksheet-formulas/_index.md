---
title: Použití vzorců listu grafu v prezentacích v Javě
linktitle: Vzorce listu
type: docs
weight: 70
url: /cs/java/chart-worksheet-formulas/
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
- chybná konstanta
- aritmetický operátor
- porovnávací operátor
- styl A1
- styl R1C1
- předdefinovaná funkce
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Použijte vzorce ve stylu Excel v listech grafů Aspose.Slides pro Javu, přepočítejte hodnoty a použijte výsledky v grafech PowerPointu."
---
## **Přehled**

Grafy v PowerPointu obvykle ukládají svá zdrojová data do vloženého listu. V Aspose.Slides pro Java můžete k tomuto listu přistupovat prostřednictvím sešitu s daty grafu, zapisovat vstupní hodnoty, přiřazovat buňkám vzorce, vypočítávat podporované vzorce a použít vypočítané buňky jako data grafu.

Tento článek popisuje kompletní workflow s vzorci: vytvořit graf, naplnit jeho list, přiřadit vzorce ve stylu A1 nebo R1C1, přepočítat je, přečíst vypočítané hodnoty, propojit tyto buňky s řadou grafu a uložit prezentaci. Také popisuje podporovanou syntaxi vzorců, podmnožinu vestavěných funkcí, kešované hodnoty, nepodporované vzorce a chyby specifické pro tabulky.

## **Listy grafu a vzorce**

List grafu obsahuje kategorie, názvy řad a hodnoty použité v grafu. V PowerPointu můžete list prohlédnout otevřením editoru dat grafu:

![Graf PowerPointu s otevřeným vloženým listem, zobrazující data kategorií a řad](chart-worksheet-formulas_1.png)

V Aspose.Slides je list vystaven prostřednictvím rozhraní [IChartDataWorkbook](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdataworkbook/) . Použijte [IChartDataCell.setFormula](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) pro vzorce ve stylu A1 a [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) pro vzorce ve stylu R1C1. Po změně vstupních buněk nebo vzorců zavolejte [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) pro přepočítání podporovaných vzorců a aktualizaci odpovídajících hodnot buněk.

Vypočítaná buňka stále poskytuje svůj výsledek přes [IChartDataCell.getValue](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatacell/#getValue--) . To je důležité, když potřebujete v kódu zkontrolovat výsledek vzorce nebo použít buňku jako datový bod grafu.

## **Vytvoření grafu a výpočet vzorců v listu**

Následující příklad ukazuje end-to-end workflow. Vytváří sloupcový seskupený graf, vyčistí ukázková data, zapíše čtvrtletní příjmy a výdaje, vypočítá zisk pomocí vzorců, přečte výsledky, použije vypočítané buňky jako hodnoty grafu a uloží prezentaci.

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

Datové body grafu odkazují na `D2:D4`, takže graf používá vypočítané hodnoty zisku. Neexistuje samostatné volání pro obnovení grafu v tomto workflow: nejprve přepočítejte sešit, potom použijte nebo uložte datové body grafu, které odkazují na vypočítané buňky.

## **Použití vzorců ve stylu A1**

Zápis A1 identifikuje sloupce písmeny a řádky čísly. Přiřaďte výrazy ve stylu A1 přes [IChartDataCell.setFormula](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-).

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

Běžné formy odkazů A1 jsou:

| Odkaz | Relativní | Absolutní | Smíšený |
|---|---|---|---|
| Buňka | `A2` | `$A$2` | `A$2`, `$A2` |
| Řádek | `2:2` | `$2:$2` | — |
| Sloupec | `A:A` | `$A:$A` | — |
| Rozsah | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Relativní odkazy se mohou změnit, když je vzorec přesunut nebo zkopírován tabulkovou aplikací. Absolutní odkazy udržují oba souřadnice pevně, zatímco smíšené odkazy fixují jen řádek nebo sloupec.

## **Použití vzorců ve stylu R1C1**

Zápis R1C1 identifikuje řádky i sloupce číselně. Relativní odkazy používají posuny v hranatých závorkách. Přiřaďte tuto syntaxi pomocí [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-).

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

Běžné formy odkazů R1C1 jsou:

| Odkaz | Relativní | Absolutní | Smíšený |
|---|---|---|---|
| Buňka | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Řádek | `R[2]` | `R2` | — |
| Sloupec | `C[3]` | `C3` | — |
| Rozsah | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Například v buňce `D2` znamená `RC[-2]` buňku ve stejném řádku o dva sloupce vlevo (`B2`).

## **Konstanty a operátory ve vzorcích**

Vestavěný evaluátor vzorců podporuje logické hodnoty, číselné literály, řetězce, chybové hodnoty tabulky, aritmetické operátory a porovnávací operátory.

### **Konstanty a literály**

| Typ | Příklady | Poznámky |
|---|---|---|
| Logická | `TRUE`, `FALSE` | Lze použít přímo v logických výrazech jako `A2=TRUE`. |
| Numerická | `1`, `0.5`, `.3`, `1E-2` | Podporovány jsou běžná a vědecká notace. |
| Řetězec | `"abc"`, `"2/3/2020 12:00"` | Literály textu jsou ve vzorci uzavřeny v dvojitých uvozovkách. |
| Chybný výsledek | `#DIV/0!`, `#N/A`, `#REF!` | Platný vzorec může vyhodnotit chybovou hodnotu tabulky místo normálního výsledku. |

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
| `-` | Odečtení nebo záporné | `2-3`, `-3` |
| `*` | Násobení | `2*3` |
| `/` | Dělení | `2/3` |
| `%` | Procento | `30%` |
| `^` | Exponenciace | `2^3` |

Používejte závorky pro explicitní určení pořadí vyhodnocení, například `(A2+B2)*C2`.

### **Porovnávací operátory**

Porovnávací výrazy vrací logické hodnoty.

| Operátor | Význam | Příklad |
|---|---|---|
| `=` | Rovná se | `A2=3` |
| `<>` | Není rovno | `A2<>3` |
| `>` | Větší než | `A2>3` |
| `>=` | Větší nebo rovno | `A2>=3` |
| `<` | Menší než | `A2<3` |
| `<=` | Menší nebo rovno | `A2<=3` |

## **Podporované předdefinované funkce**

Aspose.Slides obsahuje vestavěný evaluátor vzorců pro listy grafu, ale není to kompletní výpočetní engine Excelu. Dokumentovaný soubor funkcí je omezen na níže uvedené funkce. Nepředpokládejte, že libovolná funkce Excelu může být přepočítána pomocí [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--).

| Funkce | Účel nebo podporovaná forma | Příklad |
|---|---|---|
| `ABS` | Absolutní hodnota | `ABS(A2)` |
| `AVERAGE` | Aritmetický průměr | `AVERAGE(B2:B5)` |
| `CEILING` | Zaokrouhlit číslo směrem nahoru na násobek | `CEILING(A2,5)` |
| `CHOOSE` | Vybrat hodnotu podle indexu | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Join text values | `CONCAT(A2,B2)` |
| `CONCATENATE` | Join text values | `CONCATENATE(A2," ",B2)` |
| `DATE` | Create a date value using the 1900 date system | `DATE(2026,8,19)` |
| `DAYS` | Return the number of days between dates | `DAYS(B2,A2)` |
| `FIND` | Find one text value inside another | `FIND("-",A2)` |
| `FINDB` | Byte-oriented text search | `FINDB("a",A2)` |
| `IF` | Conditional result | `IF(A2>0,A2,0)` |
| `INDEX` | Reference form | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vector form | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vector form | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximum value | `MAX(B2:B5)` |
| `SUM` | Sum values | `SUM(B2:B5)` |
| `VLOOKUP` | Vertical lookup | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Omezení uvedená v tabulce jsou významná: `INDEX` je dokumentován jako odkazová forma, zatímco `LOOKUP` a `MATCH` jsou dokumentovány ve své vektorové formě. `DATE` používá systém dat 1900. Funkce a vlastnosti, které zde nejsou uvedeny, by měly být považovány za nepodporované vestavěným evaluátorem Aspose.Slides, pokud nejsou dokumentovány zvlášť.

## **Přepočet a kešované hodnoty**

Soubory tabulek obvykle ukládají jak vzorec, tak jeho poslední vypočítanou hodnotu. Aspose.Slides tak může číst kešovanou hodnotu z [IChartDataCell.getValue](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatacell/#getValue--) , když je prezentace načtena a příslušná data grafu nebyla změněna.

Po změně vstupních buněk nebo vzorců nespoléhejte na starý kešovaný výsledek. Zavolejte [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) před čtením vypočítaných hodnot nebo uložením dat grafu, která na nich závisejí.

Pro vzorce mimo podporovaný podmnožinu může Aspose.Slides nemusí být schopen analyzovat vzorec nebo určit jeho závislosti. Pokud byl sešit upraven, předchozí kešovaná hodnota už není spolehlivá. V takové situaci může čtení hodnoty buňky s nepodporovanými daty vyvolat [CellUnsupportedDataException](https://reference.aspose.com/slides/cs/java/com.aspose.slides/cellunsupporteddataexception/).

Pokud váš graf závisí na Excelových funkcích, které Aspose.Slides nevyhodnocuje, vypočítejte tyto vzorce pomocí tabulkového engine, který je podporuje, a zapište výsledné hodnoty zpět do sešitu grafu. Nepřepisujte nepodporované vzorce odhadovanými hodnotami.

## **Zpracování chyb ve vzorcích**

Existují dva odlišné typy problémů, které je potřeba rozlišovat.

Vzorec může být platný, ale vrátit chybový výsledek tabulky jako `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` nebo `#VALUE!`. V tomto případě je chybový token výsledkem buňky a může být vrácen přes [IChartDataCell.getValue](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatacell/#getValue--).

Vzorec může také selhat při parsování, odkazování, závislostech nebo úrovni podporovaných dat. Aspose.Slides poskytuje tabulkové specifické výjimky pro tyto případy: [CellInvalidFormulaException](https://reference.aspose.com/slides/cs/java/com.aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/cs/java/com.aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/cs/java/com.aspose.slides/cellcircularreferenceexception/) a [CellUnsupportedDataException](https://reference.aspose.com/slides/cs/java/com.aspose.slides/cellunsupporteddataexception/).

Když vzorce pocházejí ze šablon nebo uživatelského vstupu, obalte tyto výjimky při přepočítání a přístupu k hodnotě:

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

Podpora vzorců v listech grafů je zamýšlena pro definovanou podmnožinu výpočtů tabulek, ne pro úplnou kompatibilitu s Excelem. Mějte tyto omezení na paměti při navrhování workflow reportování:

- Používejte pouze dokumentované konstanty, operátory, odkazy a funkce, pokud chcete, aby Aspose.Slides přepočítával vzorce.
- Přepočítejte po změně buněk, na kterých závisí výsledky vzorců.
- Považujte kešované hodnoty z načtených prezentací za okamžité snímky, ne jako náhradu přepočtu po úpravách.
- Testujte vzorce z existujících šablon před spoleháním na jejich vypočítané hodnoty, zejména pokud používají funkce mimo dokumentovaný seznam.
- Pro vzorce, které vyžadují plnohodnotný výpočetní engine tabulek, vypočítejte je externě a poté aktualizujte sešit grafu s výslednými hodnotami.

## **Často kladené otázky**

**Jaký je rozdíl mezi [IChartDataCell.setFormula](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) a [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-)?**

[IChartDataCell.setFormula] ukládá výraz ve stylu A1, např. `B2-C2`. [IChartDataCell.setR1C1Formula] ukládá výraz ve stylu R1C1, např. `RC[-2]-RC[-1]`. Použijte zápis, který nejlépe odpovídá tomu, jak vytváříte nebo kopírujete vzorce.

**Musím po výpočtu číst samotnou buňku nebo její hodnotu?**

[IChartDataWorkbook.getCell] vrací [IChartDataCell]. Pro získání vypočítaného výsledku zavolejte metodu [IChartDataCell.getValue] této buňky po přepočítání.

**Kdy bych měl zavolat [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--)?**

Zavolejte jej po změně vstupních hodnot nebo vzorců a před tím, než budete záviset na vypočítaných výsledcích. To aktualizuje hodnoty vzorců, které podporuje vestavěný evaluátor.

**Podporuje Aspose.Slides všechny funkce Excelu?**

Ne. Vestavěný evaluátor podporuje dokumentovanou podmnožinu funkcí. Funkce mimo tuto podmnožinu by neměly být považovány za správně přepočítatelné. Pokud je vyžadována úplná kompatibilita s Excelovými vzorci, proveďte výpočet vhodným tabulkovým engine a zapište konečné hodnoty do sešitu grafu.

**Co se stane, pokud načtená prezentace obsahuje nepodporovaný vzorec?**

Pokud data grafu nebyla změněna, může sešit stále obsahovat dříve vypočítanou kešovanou hodnotu. Po změně souvisejících dat však tato kešovaná hodnota může být neplatná. Přístup k buňce, jejíž vzorec nelze zpracovat, může vyvolat [CellUnsupportedDataException](https://reference.aspose.com/slides/cs/java/com.aspose.slides/cellunsupporteddataexception/).

**Jsou hodnoty chyb ve vzorcích stejné jako výjimky Java?**

Ne. Výsledek jako `#DIV/0!` je hodnota tabulky vytvořená platným výpočtem. Výjimky jako [CellInvalidFormulaException](https://reference.aspose.com/slides/cs/java/com.aspose.slides/cellinvalidformulaexception/) nebo [CellCircularReferenceException](https://reference.aspose.com/slides/cs/java/com.aspose.slides/cellcircularreferenceexception/) naznačují, že vzorec nelze normálně zpracovat.

**Aktualizuje se graf automaticky, když se změní buňka se vzorcem?**

Řada grafu může odkazovat na buňky sešitu. Nejprve přepočítejte sešit, poté uložte nebo vykreslete prezentaci. Pokud datové body grafu odkazují na vypočítané buňky, graf použije tyto aktualizované hodnoty; pro tento workflow není vyžadována žádná samostatná metoda pro obnovení grafu.

**Mohou grafy používat externí sešit Excel?**

Ano, data grafu lze nastavit tak, aby používala externí sešit přes API dat grafu. Nicméně workflow výpočtu vzorců popsaný v tomto článku se týká sešitu dat grafu a podmnožiny vzorců vyhodnocovaných Aspose.Slides. Nepředpokládejte, že [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) poskytuje úplný přepočet libovolných vzorců v externím souboru XLSX.

**Mohu použít vzorce, které odkazují na jiný list nebo sešit?**

Reference ve stylu Excel mohou v sešitech grafů existovat, ale vyhodnocení vzorců je omezeno podporovaným parserem a množinou funkcí. Pokud je křížový odkaz na list nebo externí sešit nezbytný, ověřte konkrétní vzorec s vaší cílovou verzí Aspose.Slides. Pro workflow, které vyžadují širokou kompatibilitu s odkazy Excelu, vypočítejte sešit externě a zapište vyřešené hodnoty zpět do dat grafu.

**Měly by řetězce vzorců začínat `=`?**

Příklady API Aspose.Slides přiřazují výrazy jako `B2-C2` nebo `SUM(B2:B5)` bez úvodního `=`. Použití této formy udržuje generované vzorce v souladu s dokumentovanými příklady API.