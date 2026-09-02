---
title: Použít vzorce listu grafu v prezentacích v Java
linktitle: Vzorce listu
type: docs
weight: 70
url: /cs/java/chart-worksheet-formulas/
keywords:
- graf tabulky
- list grafu
- vzorec grafu
- vzorec listu
- vzorec tabulky
- sešit dat grafu
- výpočet vzorce
- preferovaná kultura
- kulturálně specifický vzorec
- DBCS
- logická konstanta
- číselná konstanta
- řetězcová konstanta
- chybová konstanta
- aritmetický operátor
- porovnávací operátor
- styl A1
- styl R1C1
- předdefinovaná funkce
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Použijte Excelové vzorce v listu grafu Aspose.Slides pro Java, přepočítejte hodnoty a použijte výsledky v grafech PowerPointu."
---
## **Přehled**

Grafy PowerPointu obvykle ukládají svá zdrojová data do vloženého listu. V Aspose.Slides pro Java můžete přistupovat k tomuto listu prostřednictvím sešitu s daty grafu, zapisovat vstupní hodnoty, přiřazovat buňkám vzorce, vypočítávat podporované vzorce a používat vypočítané buňky jako data grafu.

Tento článek vysvětluje kompletní postup práce s vzorci: vytvořit graf, naplnit jeho list, přiřadit vzorce ve stylu A1 nebo R1C1, přepočítat je, přečíst vypočítané hodnoty, propojit tyto buňky s řadou grafu a uložit prezentaci. Dále popisuje podporovanou syntaxi vzorců, vestavěný podmnožinu funkcí, kešované hodnoty, nepodporované vzorce a chyby specifické pro tabulkový procesor.

## **Listy grafů a vzorce**

List grafu obsahuje kategorie, názvy sérií a hodnoty použité v grafu. V PowerPointu můžete list zkontrolovat otevřením editoru dat grafu:

![Graf PowerPointu s otevřeným vloženým listem, zobrazující data kategorií a sérií](chart-worksheet-formulas_1.png)

V Aspose.Slides je list exponován prostřednictvím rozhraní [IChartDataWorkbook](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdataworkbook/). Pro vzorce ve stylu A1 použijte [IChartDataCell.setFormula](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) a pro vzorce ve stylu R1C1 [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-). Po změně vstupních buněk nebo vzorců zavolejte [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) k přepočtení podporovaných vzorců a aktualizaci odpovídajících hodnot buněk.

Vypočítaná buňka stále poskytuje svůj výsledek prostřednictvím [IChartDataCell.getValue](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatacell/#getValue--). To je důležité, když potřebujete v kódu zkontrolovat výsledek vzorce nebo použít buňku jako bod dat grafu.

## **Vytvoření grafu a výpočet vzorců v listu**

Níže uvedený příklad ukazuje kompletní workflow. Vytvoří sloupcový seskupený graf, vymaže ukázková data, zapíše čtvrtletní příjmy a výdaje, vypočítá zisk pomocí vzorců, přečte výsledky, použije vypočítané buňky jako hodnoty grafu a uloží prezentaci.

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

Datové body grafu odkazují na `D2:D4`, takže graf používá vypočítané hodnoty zisku. V tomto workflow není potřeba samostatné volání pro obnovení grafu: nejprve přepočítejte sešit, poté použijte nebo uložte data grafu, která ukazují na vypočítané buňky.

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

Relativní odkazy se mohou změnit, když je vzorec přesunut nebo zkopírován tabulkovým procesorem. Absolutní odkazy udržují obě souřadnice pevně, zatímco smíšené odkazy fixují jen řádek nebo sloupec.

## **Použití vzorců ve stylu R1C1**

Zápis R1C1 identifikuje řádky i sloupce číselně. Relativní odkazy používají posuny ve hranatých závorkách. Tento zápis přiřaďte přes [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-).

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

Například v buňce `D2` znamená `RC[-2]` buňku ve stejném řádku o dvě sloupce vlevo (`B2`).

## **Konstanty a operátory ve vzorcích**

Vestavěný vyhodnocovač vzorců podporuje logické hodnoty, číselné literály, řetězce, chybové hodnoty tabulkového procesoru, aritmetické operátory a porovnávací operátory.

### **Konstanty a literály**

| Typ | Příklady | Poznámky |
|---|---|---|
| Logická | `TRUE`, `FALSE` | Lze použít přímo v logických výrazech, např. `A2=TRUE`. |
| Číselná | `1`, `0.5`, `.3`, `1E-2` | Jsou podporovány běžná i vědecká zápisy. |
| Řetězec | `"abc"`, `"2/3/2020 12:00"` | Textové literály jsou ve vzorci uzavřeny v dvojitých uvozovkách. |
| Výsledek chyby | `#DIV/0!`, `#N/A`, `#REF!` | Platný vzorec může vyhodnotit chybovou hodnotu místo normálního výsledku. |

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
| `^` | mocnina | `2^3` |

Používejte závorky, aby byl pořadí výpočtů explicitní, např. `(A2+B2)*C2`.

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

Aspose.Slides obsahuje vestavěný vyhodnocovač vzorců pro listy grafů, ale nejde o úplný výpočetní engine Excelu. Dokumentovaná sada funkcí je omezena na následující funkce. Nepředpokládejte, že libovolná funkce Excelu může být přepočtena pomocí [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--).

| Funkce | Účel nebo podpořená forma | Příklad |
|---|---|---|
| `ABS` | Absolutní hodnota | `ABS(A2)` |
| `AVERAGE` | Aritmetický průměr | `AVERAGE(B2:B5)` |
| `CEILING` | Zaokrouhlí číslo nahoru na násobek | `CEILING(A2,5)` |
| `CHOOSE` | Vybere hodnotu podle indexu | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Spojí textové hodnoty | `CONCAT(A2,B2)` |
| `CONCATENATE` | Spojí textové hodnoty | `CONCATENATE(A2," ",B2)` |
| `DATE` | Vytvoří datum pomocí systému 1900 | `DATE(2026,8,19)` |
| `DAYS` | Vrátí počet dní mezi daty | `DAYS(B2,A2)` |
| `FIND` | Najde jeden text v jiném textu | `FIND("-",A2)` |
| `FINDB` | Hledání orientované na bajty | `FINDB("a",A2)` |
| `IF` | Podmíněný výsledek | `IF(A2>0,A2,0)` |
| `INDEX` | Referenční forma | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektorová forma | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektorová forma | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximální hodnota | `MAX(B2:B5)` |
| `SUM` | Součet hodnot | `SUM(B2:B5)` |
| `VLOOKUP` | Vertikální vyhledání | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Omezení uvedená v tabulce jsou podstatná: `INDEX` je dokumentován v referenční formě, zatímco `LOOKUP` a `MATCH` jsou dokumentovány ve svých vektorových formách. `DATE` používá datový systém 1900. Funkce a vlastnosti, které zde nejsou uvedeny, by měly být považovány za nepodporované vestavěným vyhodnocovačem Aspose.Slides, pokud nejsou dokumentovány zvlášť.

## **Výpočet vzorců s preferovanou kulturou**

Některé funkce pracovního sešitu interpretují text podle pravidel specifických pro kulturu. To je zvláště důležité pro funkce určené pro jazyky používající dvojbajtové znakové sady (DBCS). Pro správný výpočet takových vzorců vytvořte [LoadOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/loadoptions/), nastavte preferovanou kulturu pomocí [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/cs/java/com.aspose.slides/spreadsheetoptions/#setPreferredCulture-java.util.Locale-), přiřaďte možnosti sešitu přes [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), a pak načtěte prezentaci.

Následující příklad vybírá japonskou kulturu, otevírá prezentaci s nastavenými možnostmi načítání a volá [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) pro každý sešit grafu:

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

Preferovaná kultura je součástí konfigurace načítání prezentace, takže ji nastavte před vytvořením instance [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/). Použijte kulturu, kterou očekávají vzorce sešitu; například `ja-JP` pro vzorce, které mají dodržovat japonská DBCS pravidla výpočtu.

## **Přepočet a kešované hodnoty**

Soubory tabulkových procesorů často ukládají jak vzorec, tak jeho naposledy vypočítanou hodnotu. Aspose.Slides proto může při načtení prezentace a pokud se příslušná data grafu nezměnila, přečíst kešovanou hodnotu z [IChartDataCell.getValue](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatacell/#getValue--).

Po změně vstupních buněk nebo vzorců se nespoléhejte na starý kešovaný výsledek. Zavolejte [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) před čtením vypočítaných hodnot nebo uložením dat grafu, která na nich závisí.

Pro vzorce mimo podporovanou podmnožinu nemusí Aspose.Slides být schopen vzorec parsovat nebo zjistit jeho závislosti. Pokud byl sešit upraven, předchozí kešovaná hodnota již nemůže být považována za spolehlivou. V takové situaci může čtení buňky s nepodporovanými daty vyvolat [CellUnsupportedDataException](https://reference.aspose.com/slides/cs/java/com.aspose.slides/cellunsupporteddataexception/).

Pokud váš graf závisí na funkcích Excelu, které Aspose.Slides nevyhodnocuje, vypočítejte tyto vzorce pomocí tabulkového enginu, který je podporuje, a zapište výsledné hodnoty zpět do sešitu grafu. Nepřepisujte nepodporované vzorce odhadovanými hodnotami.

## **Zpracování chyb ve vzorcích**

Existují dva různé typy problémů, které je třeba rozlišovat.

Vzorec může být platný, ale vyprodukovat chybový výsledek tabulkového procesoru, například `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` nebo `#VALUE!`. V tomto případě je chybový token výsledkem buňky a může být vrácen přes [IChartDataCell.getValue](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatacell/#getValue--).

Vzorec může také selhat při parsování, při odkazování, při řešení závislostí nebo na úrovni podporovaných dat. Aspose.Slides poskytuje pro tyto případy tabulkově specifické výjimky: [CellInvalidFormulaException](https://reference.aspose.com/slides/cs/java/com.aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/cs/java/com.aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/cs/java/com.aspose.slides/cellcircularreferenceexception/) a [CellUnsupportedDataException](https://reference.aspose.com/slides/cs/java/com.aspose.slides/cellunsupporteddataexception/).

Když vzorce pocházejí ze šablon nebo uživatelského vstupu, obalte přepočet a přístup k hodnotám těmito výjimkami:

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

Podpora vzorců v listech grafů je určena pro definovanou podmnožinu výpočtů tabulkových procesorů, nikoli pro plnou kompatibilitu s Excel. Mějte tato omezení na paměti při navrhování workflow pro reportování:

- Používejte pouze dokumentované konstanty, operátory, odkazy a funkce, když chcete, aby Aspose.Slides přepočítával vzorce.
- Přepočítejte po změně buněk, na jejichž výsledcích vzorce závisejí.
- Považujte kešované hodnoty z načtených prezentací za snímky, ne za náhradu přepočtu po úpravách.
- Otestujte vzorce z existujících šablon před spoleháním se na jejich vypočítané hodnoty, zejména pokud používají funkce mimo dokumentovaný seznam.
- Pro vzorce, které vyžadují plnohodnotný výpočetní engine tabulkového procesoru, vypočítejte je externě a pak aktualizujte sešit grafu s výslednými hodnotami.

## **Často kladené dotazy**

**Jaký je rozdíl mezi [IChartDataCell.setFormula](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) a [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-)?**

[IChartDataCell.setFormula](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) ukládá výraz ve stylu A1, například `B2-C2`. [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) ukládá výraz ve stylu R1C1, například `RC[-2]-RC[-1]`. Použijte zápis, který nejlépe odpovídá tomu, jak generujete nebo kopírujete vzorce.

**Musím po výpočtu číst samotnou buňku nebo její hodnotu?**

[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdataworkbook/#getCell-int-java.lang.String-) vrací [IChartDataCell](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatacell/). Pro získání vypočítaného výsledku zavolejte metodu [IChartDataCell.getValue](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatacell/#getValue--) po přepočtu.

**Kdy mám volat [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--)?**

Zavolejte [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) po změně vstupních hodnot nebo vzorců a předtím, než budete záviset na vypočítaných výsledcích. Tím se aktualizují hodnoty vzorců, které vestavěný vyhodnocovač podporuje.

**Podporuje Aspose.Slides každou funkci Excelu?**

Ne. Vestavěný vyhodnocovač podporuje pouze dokumentovanou podmnožinu funkcí. Funkce mimo tuto podmnožinu by neměly být považovány za správně přepočítatelné. Pokud je vyžadována úplná kompatibilita s Excel, proveďte výpočet pomocí vhodného tabulkového enginu a zapište finální hodnoty do sešitu grafu.

**Co se stane, pokud načtená prezentace obsahuje nepodporovaný vzorec?**

Pokud data grafu nebyla změněna, může sešit stále obsahovat dříve vypočítanou kešovanou hodnotu. Po úpravě souvisejících dat již tato kešovaná hodnota nemusí být platná. Přístup k buňce, jejíž vzorec nelze zpracovat, může vyvolat [CellUnsupportedDataException](https://reference.aspose.com/slides/cs/java/com.aspose.slides/cellunsupporteddataexception/).

**Jsou hodnoty chyb ve vzorcích stejné jako výjimky v Javě?**

Ne. Výsledek jako `#DIV/0!` je hodnota tabulkového procesoru vzniklá platným výpočtem. Výjimky jako [CellInvalidFormulaException](https://reference.aspose.com/slides/cs/java/com.aspose.slides/cellinvalidformulaexception/) nebo [CellCircularReferenceException](https://reference.aspose.com/slides/cs/java/com.aspose.slides/cellcircularreferenceexception/) naznačují, že vzorec nelze normálně zpracovat.

**Aktualizuje se graf automaticky, když se změní buňka s vzorcem?**

Série grafu může odkazovat na buňky sešitu. Nejprve přepočítejte sešit, poté uložte nebo vykreslete prezentaci. Pokud datové body grafu odkazují na vypočítané buňky, graf použije tyto aktualizované hodnoty; není vyžadována žádná samostatná metoda pro obnovení grafu.

**Mohou grafy používat externí sešit Excel?**

Ano, data grafu lze nakonfigurovat tak, aby používala externí sešit prostřednictvím API dat grafu. Avšak workflow výpočtu vzorců popsané v této příručce se týká sešitu dat grafu a podmnožiny vzorců vyhodnocovaných Aspose.Slides. Nepředpokládejte, že [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) poskytuje úplný přepočet libovolných vzorců v externím souboru XLSX.

**Mohu používat vzorce, které odkazují na jiný list nebo sešit?**

Odkazy ve stylu Excel mohou v sešitech grafů existovat, ale vyhodnocování vzorců je omezeno podporovaným parserem a sadou funkcí. Pokud je nezbytný odkaz napříč listy nebo externí odkaz, ověřte si, že konkrétní vzorec funguje s vaší verzí Aspose.Slides. Pro workflow, které vyžadují širokou kompatibilitu s Excel odkazy, vypočítejte sešit externě a pak zapište vyřešené hodnoty zpět do dat grafu.

**Měly by řetězce vzorců začínat znakem `=`?**

Příklady v API Aspose.Slides přiřazují výrazy jako `B2-C2` nebo `SUM(B2:B5)` bez úvodního `=`. Použití takové podoby udržuje generované vzorce v souladu s dokumentovanými příklady API.