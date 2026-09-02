---
title: Použít vzorce listu grafu v prezentacích na Androidu
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
- preferovaná kultura
- vzorec specifický pro kulturu
- DBCS
- logická konstanta
- číselná konstanta
- řetězcová konstanta
- konstanta chyby
- aritmetický operátor
- relační operátor
- styl A1
- styl R1C1
- předdefinovaná funkce
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Použít vzorce ve stylu Excel v Aspose.Slides pro Android pomocí Java listů grafu, přepočítat hodnoty a použít výsledky v grafech PowerPointu."
---
## **Přehled**

Grafy v PowerPointu obvykle ukládají svá zdrojová data do vloženého listu. V Aspose.Slides pro Android via Java můžete k tomuto listu přistupovat přes sešit dat grafu, zapisovat vstupní hodnoty, přiřazovat buňkám vzorce, vypočítávat podporované vzorce a použít vypočtené buňky jako data grafu.

Tento článek vysvětluje kompletní workflow vzorce: vytvoření grafu, naplnění jeho listu, přiřazení vzorců ve stylu A1 nebo R1C1, jejich přepočet, čtení vypočtených hodnot, propojení těchto buněk s řadou grafu a uložení prezentace. Také popisuje podporovanou syntaxi vzorců, podmnožinu vestavěných funkcí, kešované hodnoty, nepodporované vzorce a chyby specifické pro tabulkové procesory.

## **Listy grafu a vzorce**

List grafu obsahuje kategorie, názvy řad a hodnoty použité v grafu. V PowerPointu můžete list prohlédnout otevřením editoru dat grafu:

![Graf PowerPointu s otevřeným vloženým listem, zobrazující data kategorií a řad](chart-worksheet-formulas_1.png)

V Aspose.Slides je list vystaven prostřednictvím rozhraní [IChartDataWorkbook](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdataworkbook/). Použijte [IChartDataCell.setFormula](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) pro vzorce ve stylu A1 a [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) pro vzorce ve stylu R1C1. Po změně vstupních buněk nebo vzorců zavolejte [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) pro přepočet podporovaných vzorců a aktualizaci odpovídajících hodnot buněk.

Vypočítaná buňka stále poskytuje svůj výsledek přes [IChartDataCell.getValue](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatacell/#getValue--). To je důležité, když potřebujete v kódu zkontrolovat výsledek vzorce nebo použít buňku jako datový bod grafu.

## **Vytvoření grafu a výpočet vzorců v listu**

Následující příklad demonstruje celý workflow. Vytvoří sloupcový seskupený graf, vyprázdní ukázková data, zapíše čtvrtletní příjmy a výdaje, vypočítá zisk pomocí vzorců, načte výsledky, použije vypočtené buňky jako hodnoty grafu a uloží prezentaci.

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

Datové body grafu odkazují na `D2:D4`, takže graf používá vypočtené hodnoty zisku. V tomto workflow neexistuje samostatné volání pro obnovení grafu: nejprve přepočtěte sešit a poté použijte nebo uložte grafová data, která ukazují na vypočtené buňky.

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

Běžné formy odkazů A1 jsou:

| Odkaz | Relativní | Absolutní | Smíšený |
|---|---|---|---|
| Buňka | `A2` | `$A$2` | `A$2`, `$A2` |
| Řádek | `2:2` | `$2:$2` | — |
| Sloupec | `A:A` | `$A:$A` | — |
| Rozsah | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Relativní odkazy se mohou změnit, když je vzorec přesunut nebo zkopírován tabulkovým procesorem. Absolutní odkazy mají oba souřadnice pevně dané, zatímco smíšené odkazy fixují jen řádek nebo sloupec.

## **Použití vzorců ve stylu R1C1**

Notace R1C1 identifikuje řádky i sloupce číselně. Relativní odkazy používají posuny v hranatých závorkách. Přiřaďte tuto syntaxi pomocí [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-).

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

Například v buňce `D2` znamená `RC[-2]` buňku ve stejném řádku dva sloupce vlevo (`B2`).

## **Konstanty a operátory ve vzorcích**

Vestavěný evaluátor vzorců podporuje logické hodnoty, číselné literály, řetězce, chybové hodnoty tabulkového procesoru, aritmetické operátory a relační operátory.

### **Konstanty a literály**

| Typ | Příklady | Poznámky |
|---|---|---|
| Logická | `TRUE`, `FALSE` | Lze použít přímo v logických výrazech, např. `A2=TRUE`. |
| Číselná | `1`, `0.5`, `.3`, `1E-2` | Podporována běžná i vědecká notace. |
| Řetězec | `"abc"`, `"2/3/2020 12:00"` | Textové literály jsou ve vzorci uzavřeny v dvojitých uvozovkách. |
| Chybový výsledek | `#DIV/0!`, `#N/A`, `#REF!` | Platný vzorec může vyhodnotit na chybu tabulkového procesoru místo normálního výsledku. |

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

Používejte závorky pro explicitní určení pořadí vyhodnocení, např. `(A2+B2)*C2`.

### **Relační operátory**

Relační výrazy vrací logické hodnoty.

| Operátor | Význam | Příklad |
|---|---|---|
| `=` | Rovná se | `A2=3` |
| `<>` | Nerovná se | `A2<>3` |
| `>` | Větší než | `A2>3` |
| `>=` | Větší nebo rovno | `A2>=3` |
| `<` | Menší než | `A2<3` |
| `<=` | Menší nebo rovno | `A2<=3` |

## **Podporované předdefinované funkce**

Aspose.Slides obsahuje vestavěný evaluátor vzorců pro listy grafu, ale nejedná se o kompletní výpočetní engine Excelu. Dokumentovaný soubor funkcí je omezen na níže uvedené funkce. Nepředpokládejte, že libovolná funkce Excelu může být přepočítána pomocí [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--).

| Funkce | Účel nebo podpora | Příklad |
|---|---|---|
| `ABS` | Absolutní hodnota | `ABS(A2)` |
| `AVERAGE` | Aritmetický průměr | `AVERAGE(B2:B5)` |
| `CEILING` | Zaokrouhlení čísla nahoru na násobek | `CEILING(A2,5)` |
| `CHOOSE` | Výběr hodnoty podle indexu | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Spojení textových hodnot | `CONCAT(A2,B2)` |
| `CONCATENATE` | Spojení textových hodnot | `CONCATENATE(A2," ",B2)` |
| `DATE` | Vytvoření datové hodnoty pomocí systému dat 1900 | `DATE(2026,8,19)` |
| `DAYS` | Počet dnů mezi daty | `DAYS(B2,A2)` |
| `FIND` | Najde jeden text v jiném | `FIND("-",A2)` |
| `FINDB` | Vyhledávání textu po bajtech | `FINDB("a",A2)` |
| `IF` | Podmíněný výsledek | `IF(A2>0,A2,0)` |
| `INDEX` | Forma odkazu | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektorová forma | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektorová forma | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximální hodnota | `MAX(B2:B5)` |
| `SUM` | Součet hodnot | `SUM(B2:B5)` |
| `VLOOKUP` | Vertikální vyhledávání | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Omezení v tabulce jsou podstatná: `INDEX` je dokumentován ve formě odkazu, zatímco `LOOKUP` a `MATCH` jsou dokumentovány ve svých vektorových formách. `DATE` používá systém dat 1900. Funkce, které zde nejsou uvedeny, by měly být považovány za nepodporované vestavěným evaluátorem Aspose.Slides, pokud nejsou zdokumentovány samostatně.

## **Vypočítat vzorce s preferovanou kulturou**

Některé funkce sešitu interpretují text podle kulturně specifických pravidel. To je obzvláště důležité pro funkce určené pro jazyky používající dvojbajtové znakové sady (DBCS). Pro správný výpočet takových vzorců vytvořte [LoadOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/loadoptions/), nastavte preferovanou kulturu pomocí [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/spreadsheetoptions/#setPreferredCulture-java.util.Locale-), přiřaďte možnosti sešitu přes [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), a poté načtěte prezentaci.

Následující příklad vybere japonskou kulturu, otevře prezentaci s nakonfigurovanými možnostmi načítání a zavolá [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) pro každý sešit grafu:

```java
import com.aspose.slides.*;
import java.util.Locale;

Locale japaneseCulture = Locale.forLanguageTag("ja-JP");

ISpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setPreferredCulture(japaneseCulture);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                IChart chart = (IChart) shape;
                chart.getChartData().getChartDataWorkbook().calculateFormulas();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Preferovaná kultura je součástí konfigurace načítání prezentace, takže ji nastavte před vytvořením instance [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/). Použijte kulturu, kterou očekávají vzorce sešitu; např. `ja-JP` pro vzorce, které mají dodržovat japonská DBCS pravidla výpočtu.

## **Přepočet a uložené hodnoty**

Tabulkové soubory často ukládají jak vzorec, tak jeho naposledy vypočtenou hodnotu. Aspose.Slides může proto při načtení prezentace přečíst uloženou hodnotu z [IChartDataCell.getValue](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatacell/#getValue--) pokud se data grafu mezitím nezměnila.

Po změně vstupních buněk nebo vzorců nespoléhejte na starý uložený výsledek. Zavolejte [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) před čtením vypočtených hodnot nebo před uložením grafových dat, která na nich závisí.

U vzorců mimo podporovanou podmnožinu může Aspose.Slides nedokázat vzorec parsovat nebo zjistit jeho závislosti. Pokud byl sešit změněn, předchozí uložená hodnota již nemusí být spolehlivá. V takové situaci může čtení hodnoty buňky s nepodporovanými daty vyvolat [CellUnsupportedDataException](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/cellunsupporteddataexception/).

Pokud váš graf závisí na Excelových funkcích, které Aspose.Slides nevyhodnocuje, vypočítejte tyto vzorce pomocí tabulkového engine, který je podporuje, a zapište získané hodnoty zpět do sešitu grafu. Nepřepisujte nepodporované vzorce odhadovanými hodnotami.

## **Zpracování chyb ve vzorcích**

Existují dva odlišné typy problémů.

Vzorec může být platný, ale vyprodukovat výsledek chyby tabulkového procesoru, např. `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` nebo `#VALUE!`. V takovém případě je chybový token výsledkem buňky a lze jej získat přes [IChartDataCell.getValue](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatacell/#getValue--).

Vzorec může také selhat při parsování, odkazování, závislostech nebo na úrovni podporovaných dat. Aspose.Slides poskytuje pro tyto případy tabulkově specifické výjimky: [CellInvalidFormulaException](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/cellcircularreferenceexception/) a [CellUnsupportedDataException](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/cellunsupporteddataexception/).

Když vzorce pocházejí ze šablon nebo uživatelského vstupu, obalte tato volání výjimečným ošetřením při přepočtu a přístupu k hodnotám:

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

Podpora vzorců v listech grafu je určena pro definovanou podmnožinu tabulkových výpočtů, nikoli pro plnou kompatibilitu s Excelem. Mějte tato omezení na paměti při navrhování pracovního postupu reportování:

- Používejte jen dokumentované konstanty, operátory, odkazy a funkce, pokud chcete, aby Aspose.Slides přepočítal vzorce.
- Přepočtěte po změně buněk, na nichž výsledky vzorců závisí.
- Považujte uložené hodnoty z načtených prezentací za snapshoty, ne za náhradu přepočtu po úpravách.
- Otestujte vzorce z existujících šablon před spoleháním se na jejich vypočtené hodnoty, zejména pokud používají funkce mimo dokumentovaný seznam.
- Pro vzorce, které vyžadují kompletní tabulkový výpočetní engine, je vypočítejte externě a poté aktualizujte sešit grafu získanými hodnotami.

## **Často kladené otázky**

**Jaký je rozdíl mezi [IChartDataCell.setFormula](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) a [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-)?**

[IChartDataCell.setFormula](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) ukládá výraz ve stylu A1, např. `B2-C2`. [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) ukládá výraz ve stylu R1C1, např. `RC[-2]-RC[-1]`. Použijte notaci, která nejlépe odpovídá tomu, jak vzorce generujete nebo kopírujete.

**Musím po výpočtu číst samotnou buňku nebo její hodnotu?**

[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-java.lang.String-) vrací [IChartDataCell](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatacell/). Pro získání vypočteného výsledku zavolejte metodu [IChartDataCell.getValue](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdatacell/#getValue--) na tuto buňku po přepočtu.

**Kdy mám volat [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--)?**

Zavolejte [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) po změně vstupních hodnot nebo vzorců a před tím, než budete spoléhat na vypočtené výsledky. Tím se aktualizují hodnoty vzorců, které vestavěný evaluátor podporuje.

**Podporuje Aspose.Slides každou Excelovou funkci?**

Ne. Vestavěný evaluátor podporuje pouze dokumentovanou podmnožinu funkcí. Funkce mimo tuto podmnožinu by neměly být považovány za správně přepočítatelné. Pokud potřebujete plnou kompatibilitu s Excelovými vzorci, proveďte výpočet pomocí vhodného tabulkového engine a zapište konečné hodnoty do sešitu grafu.

**Co se stane, když načtená prezentace obsahuje nepodporovaný vzorec?**

Pokud data grafu nebyla změněna, sešit může stále obsahovat dříve vypočtenou uloženou hodnotu. Po změně souvisejících dat tato uložená hodnota může být neplatná. Přístup k buňce, jejíž vzorec nelze zpracovat, může vyvolat [CellUnsupportedDataException](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/cellunsupporteddataexception/).

**Jsou hodnoty chyb ve vzorcích stejné jako výjimky v Javě?**

Ne. Výsledek jako `#DIV/0!` je hodnota tabulkového procesoru vytvořená platným výpočtem. Výjimky jako [CellInvalidFormulaException](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/cellinvalidformulaexception/) nebo [CellCircularReferenceException](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/cellcircularreferenceexception/) signalizují, že vzorec nelze normálně zpracovat.

**Aktualizuje se graf automaticky, když se změní buňka s vzorcem?**

Řada grafu může odkazovat na buňky sešitu. Nejprve přepočtěte sešit a poté uložte nebo renderujte prezentaci. Pokud datové body grafu odkazují na vypočtené buňky, graf použije tyto aktualizované hodnoty; není potřeba samostatná metoda pro obnovení grafu.

**Mohou grafy používat externí Excelový sešit?**

Ano, data grafu lze nakonfigurovat tak, aby používala externí sešit prostřednictvím API dat grafu. Nicméně workflow výpočtu vzorců popsaný v tomto článku se týká sešitu dat grafu a podmnožiny vzorců vyhodnocovaných Aspose.Slides. Nepředpokládejte, že [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) poskytuje úplný přepočet libovolných vzorců v externím souboru XLSX.

**Mohu použít vzorce, které odkazují na jiný list nebo sešit?**

Odkazy ve stylu Excelu se mohou v sešitech grafů vyskytovat, ale vyhodnocování vzorců je omezeno podporovaným parserem a sadou funkcí. Pokud je křížový odkaz nezbytný, ověřte konkrétní vzorec s cílovou verzí Aspose.Slides. Pro workflow vyžadující širokou kompatibilitu odkazů Excelu vypočítejte sešit externě a zapište vyřešené hodnoty zpět do dat grafu.

**Měly by řetězce vzorců začínat znakem `=`?**

Příklady v API Aspose.Slides přiřazují výrazy jako `B2-C2` nebo `SUM(B2:B5)` bez úvodního `=`. Použití této podoby zachovává generované vzorce konzistentní s dokumentovanými příklady API.