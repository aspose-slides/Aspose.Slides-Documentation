---
title: Použití vzorců listu grafu v prezentacích v PHP
linktitle: Vzorce listu
type: docs
weight: 70
url: /cs/php-java/chart-worksheet-formulas/
keywords:
- grafová tabulka
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
- chybová konstanta
- aritmetický operátor
- srovnávací operátor
- styl A1
- styl R1C1
- předdefinovaná funkce
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Použijte vzorce ve stylu Excel v Aspose.Slides pro PHP přes Java na listech grafu, přepočítejte hodnoty a použijte výsledky v grafech PowerPointu."
---
## **Přehled**

Grafy v PowerPointu obvykle ukládají svá zdrojová data do vloženého listu. V Aspose.Slides pro PHP přes Java můžete k tomuto listu přistupovat prostřednictvím sešitu dat grafu, zapisovat vstupní hodnoty, přiřazovat buňkám vzorce, vypočítávat podporované vzorce a použít vypočítané buňky jako data grafu.

Tento článek vysvětluje kompletní postup práce s vzorci: vytvořit graf, naplnit jeho list, přiřadit vzorce ve stylu A1 nebo R1C1, přepočítat je, přečíst vypočítané hodnoty, propojit tyto buňky s řadou grafu a uložit prezentaci. Také popisuje podporovanou syntaxi vzorců, vestavěnou podmnožinu funkcí, kešované hodnoty, nepodporované vzorce a chyby specifické pro tabulky.

## **Listy grafu a vzorce**

List grafu obsahuje kategorie, názvy sérií a hodnoty používané grafem. V PowerPointu můžete list prohlédnout otevřením editoru dat grafu:

![Graf PowerPoint s otevřeným vloženým listem, zobrazující data kategorií a sérií](chart-worksheet-formulas_1.png)

V Aspose.Slides je list vystaven prostřednictvím třídy [ChartDataWorkbook](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdataworkbook/). Použijte [ChartDataCell::setFormula](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatacell/#setFormula) pro vzorce ve stylu A1 a [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatacell/#setR1C1Formula) pro vzorce ve stylu R1C1. Po změně vstupních buněk nebo vzorců zavolejte [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) pro přepočítání podporovaných vzorců a aktualizaci odpovídajících hodnot buněk.

Vypočítaná buňka stále poskytuje svůj výsledek prostřednictvím [ChartDataCell::getValue](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatacell/#getValue). To je důležité, když potřebujete v kódu zkontrolovat výsledek vzorce nebo použít buňku jako datový bod grafu.

## **Vytvoření grafu a výpočet vzorců v listu**

Níže uvedený příklad demonstruje kompletní postup. Vytvoří seskupený sloupcový graf, vymaže ukázková data, zapíše čtvrtletní příjmy a výdaje, vypočítá zisk pomocí vzorců, přečte výsledky, použije vypočítané buňky jako hodnoty grafu a uloží prezentaci.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 350);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $workbook->clear($worksheetIndex);

    $category1 = $workbook->getCell($worksheetIndex, "A2", "Q1");
    $category2 = $workbook->getCell($worksheetIndex, "A3", "Q2");
    $category3 = $workbook->getCell($worksheetIndex, "A4", "Q3");

    $workbook->getCell($worksheetIndex, "B1", "Revenue");
    $workbook->getCell($worksheetIndex, "C1", "Expenses");
    $workbook->getCell($worksheetIndex, "D1", "Profit");

    $workbook->getCell($worksheetIndex, "B2")->setValue(120.0);
    $workbook->getCell($worksheetIndex, "C2")->setValue(80.0);
    $workbook->getCell($worksheetIndex, "B3")->setValue(150.0);
    $workbook->getCell($worksheetIndex, "C3")->setValue(95.0);
    $workbook->getCell($worksheetIndex, "B4")->setValue(135.0);
    $workbook->getCell($worksheetIndex, "C4")->setValue(110.0);

    $profit1 = $workbook->getCell($worksheetIndex, "D2");
    $profit2 = $workbook->getCell($worksheetIndex, "D3");
    $profit3 = $workbook->getCell($worksheetIndex, "D4");

    $profit1->setFormula("B2-C2");
    $profit2->setFormula("B3-C3");
    $profit3->setFormula("B4-C4");

    $workbook->calculateFormulas();

    $q1Profit = java_values($profit1->getValue()); // 40
    $q2Profit = java_values($profit2->getValue()); // 55
    $q3Profit = java_values($profit3->getValue()); // 25

    echo "Q1 profit: " . $q1Profit . PHP_EOL;
    echo "Q2 profit: " . $q2Profit . PHP_EOL;
    echo "Q3 profit: " . $q3Profit . PHP_EOL;

    $chart->getChartData()->getCategories()->add($category1);
    $chart->getChartData()->getCategories()->add($category2);
    $chart->getChartData()->getCategories()->add($category3);

    $profitSeries = $chart->getChartData()->getSeries()->add($workbook->getCell($worksheetIndex, "D1"), $chart->getType());
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit1);
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit2);
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit3);
    $profitSeries->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $presentation->save("chart-formulas.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Datové body grafu odkazují na `D2:D4`, takže graf používá vypočítané hodnoty zisku. V tomto postupu neexistuje samostatné volání pro obnovení grafu: nejprve přepočítejte sešit, poté použijte nebo uložte data grafu, která odkazují na vypočítané buňky.

## **Použití vzorců ve stylu A1**

Notace A1 identifikuje sloupce písmeny a řádky čísly. Přiřaďte výrazy ve stylu A1 prostřednictvím [ChartDataCell::setFormula](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatacell/#setFormula).

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "C3")->setValue(10);
    $workbook->getCell(0, "F2")->setValue(2);
    $workbook->getCell(0, "G2")->setValue(3);
    $workbook->getCell(0, "H2")->setValue(4);

    $cell = $workbook->getCell(0, "A2");
    $cell->setFormula("C3+SUM(F2:H2)");

    $workbook->calculateFormulas();

    $value = java_values($cell->getValue()); // 19
} finally {
    $presentation->dispose();
}
```

Běžné formy odkazů ve stylu A1 jsou:

| Odkaz | Relativní | Absolutní | Smíšený |
|---|---|---|---|
| Buňka | `A2` | `$A$2` | `A$2`, `$A2` |
| Řádek | `2:2` | `$2:$2` | — |
| Sloupec | `A:A` | `$A:$A` | — |
| Rozsah | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Relativní odkazy se mohou změnit, když je vzorec přesunut nebo zkopírován v tabulkovém editoru. Absolutní odkazy udržují oba souřadnice pevně, zatímco smíšené odkazy fixují pouze řádek nebo sloupec.

## **Použití vzorců ve stylu R1C1**

Notace R1C1 identifikuje řádky i sloupce číselně. Relativní odkazy používají posuny v hranatých závorkách. Tento syntax přiřaďte prostřednictvím [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatacell/#setR1C1Formula).

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "B2")->setValue(12);
    $workbook->getCell(0, "C2")->setValue(5);

    $cell = $workbook->getCell(0, "D2");
    $cell->setR1C1Formula("RC[-2]-RC[-1]");

    $workbook->calculateFormulas();

    $value = java_values($cell->getValue()); // 7
} finally {
    $presentation->dispose();
}
```

Běžné formy odkazů ve stylu R1C1 jsou:

| Odkaz | Relativní | Absolutní | Smíšený |
|---|---|---|---|
| Buňka | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Řádek | `R[2]` | `R2` | — |
| Sloupec | `C[3]` | `C3` | — |
| Rozsah | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Například v buňce `D2` výraz `RC[-2]` znamená buňku ve stejném řádku o dva sloupce vlevo (`B2`).

## **Konstanty a operátory ve vzorcích**

Vestavěný vyhodnocovač vzorců podporuje logické hodnoty, číselné literály, řetězce, chybové hodnoty tabulky, aritmetické operátory a relační operátory.

### **Konstanty a literály**

| Typ | Příklady | Poznámky |
|---|---|---|
| Logická | `TRUE`, `FALSE` | Lze použít přímo v logických výrazech, jako je `A2=TRUE`. |
| Číselná | `1`, `0.5`, `.3`, `1E-2` | Podporována je běžná i vědecká notace. |
| Řetězcová | `"abc"`, `"2/3/2020 12:00"` | Textové literály jsou ve vzorci uzavřeny v dvojitých uvozovkách. |
| Chybový výsledek | `#DIV/0!`, `#N/A`, `#REF!` | Platný vzorec může vyhodnotit chybovou hodnotu tabulky místo normálního výsledku. |

Tento příklad používá několik typů konstant:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "A2")->setValue(false);
    $workbook->getCell(0, "B2")->setFormula("A2=TRUE");
    $workbook->getCell(0, "C2")->setFormula("1+0.5");
    $workbook->getCell(0, "D2")->setFormula(".3*1E-2");
    $workbook->getCell(0, "E2")->setFormula("\"abc\"");
    $workbook->getCell(0, "F2")->setFormula("2/0");

    $workbook->calculateFormulas();

    $logicalValue = java_values($workbook->getCell(0, "B2")->getValue()); // false
    $numericValue = java_values($workbook->getCell(0, "C2")->getValue()); // 1.5
    $scientificValue = java_values($workbook->getCell(0, "D2")->getValue()); // 0.003
    $stringValue = java_values($workbook->getCell(0, "E2")->getValue()); // abc
    $errorValue = java_values($workbook->getCell(0, "F2")->getValue()); // #DIV/0!
} finally {
    $presentation->dispose();
}
```

### **Aritmetické operátory**

| Operátor | Význam | Příklad |
|---|---|---|
| `+` | Sčítání nebo unární plus | `2+3` |
| `-` | Odečítání nebo záporné | `2-3`, `-3` |
| `*` | Násobení | `2*3` |
| `/` | Dělení | `2/3` |
| `%` | Procento | `30%` |
| `^` | Mocnina | `2^3` |

Použijte závorky pro explicitní určení pořadí výpočtu, například `(A2+B2)*C2`.

### **Relační operátory**

| Operátor | Význam | Příklad |
|---|---|---|
| `=` | Rovná se | `A2=3` |
| `<>` | Není rovno | `A2<>3` |
| `>` | Větší než | `A2>3` |
| `>=` | Větší nebo rovno | `A2>=3` |
| `<` | Menší než | `A2<3` |
| `<=` | Menší nebo rovno | `A2<=3` |

## **Podporované předdefinované funkce**

Aspose.Slides obsahuje vestavěný vyhodnocovač vzorců pro listy grafů, ale nejedná se o kompletní výpočetní engine Excelu. Dokumentovaná sada funkcí je omezena na funkce níže. Nepředpokládejte, že libovolnou Excel funkci lze přepočítat pomocí [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdataworkbook/#calculateFormulas).

| Funkce | Účel nebo podpořený tvar | Příklad |
|---|---|---|
| `ABS` | Absolutní hodnota | `ABS(A2)` |
| `AVERAGE` | Aritmetický průměr | `AVERAGE(B2:B5)` |
| `CEILING` | Zaokrouhlení čísla nahoru na násobek | `CEILING(A2,5)` |
| `CHOOSE` | Výběr hodnoty podle indexu | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Spojení textových hodnot | `CONCAT(A2,B2)` |
| `CONCATENATE` | Spojení textových hodnot | `CONCATENATE(A2," ",B2)` |
| `DATE` | Vytvoření hodnoty data pomocí systému dat 1900 | `DATE(2026,8,19)` |
| `DAYS` | Vrátí počet dní mezi daty | `DAYS(B2,A2)` |
| `FIND` | Najde jeden textový řetězec uvnitř druhého | `FIND("-",A2)` |
| `FINDB` | Vyhledávání textu po bajtech | `FINDB("a",A2)` |
| `IF` | Podmíněný výsledek | `IF(A2>0,A2,0)` |
| `INDEX` | Forma odkazu | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektorová forma | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektorová forma | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximální hodnota | `MAX(B2:B5)` |
| `SUM` | Součet hodnot | `SUM(B2:B5)` |
| `VLOOKUP` | Vertikální hledání | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Omezení uvedená v tabulce jsou významná: `INDEX` je dokumentována ve formě odkazu, zatímco `LOOKUP` a `MATCH` jsou dokumentovány ve své vektorové formě. `DATE` používá systém datum 1900. Funkce a vlastnosti, které zde nejsou uvedeny, by měly být považovány za nepodporované vyhodnocovačem vzorců Aspose.Slides, pokud nejsou dokumentovány zvlášť.

## **Výpočet vzorců s preferovanou kulturou**

Některé funkce sešitu grafu interpretují text podle pravidel specifických pro kulturu. To je zvláště důležité pro funkce určené pro jazyky používající dvojbajtové znakové sady (DBCS). Pro správný výpočet takových vzorců vytvořte [LoadOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/loadoptions/), nastavte preferovanou kulturu pomocí [SpreadsheetOptions::setPreferredCulture](https://reference.aspose.com/slides/cs/php-java/aspose.slides/spreadsheetoptions/#setPreferredCulture), přiřaďte možnosti tabulky přes [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/loadoptions/#setSpreadsheetOptions), a potom načtěte prezentaci.

Následující příklad vybírá japonskou kulturu, otevře prezentaci s nakonfigurovanými možnostmi načítání a zavolá [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) pro každý sešit grafu:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SpreadsheetOptions;

$japaneseCulture = new Java("java.util.Locale", "ja", "JP");

$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setPreferredCulture($japaneseCulture);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$chartClass = new JavaClass("com.aspose.slides.IChart");
$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, $chartClass)) {
                $shape->getChartData()->getChartDataWorkbook()->calculateFormulas();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Preferovaná kultura je součástí konfigurace načítání prezentace, takže ji nastavte před vytvořením instance [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/). Použijte kulturu očekávanou vzorci v sešitu; například použijte `ja-JP` pro vzorce, které mají následovat japonská pravidla výpočtu DBCS.

## **Přepočítání a kešované hodnoty**

Tabulkové soubory obvykle ukládají jak vzorec, tak jeho naposledy vypočítanou hodnotu. Aspose.Slides tak může číst kešovanou hodnotu z [ChartDataCell::getValue](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatacell/#getValue), když je prezentace načtena a příslušná data grafu nebyla změněna.

Po změně vstupních buněk nebo vzorců se nespoléhejte na starý kešovaný výsledek. Před čtením vypočítaných hodnot nebo uložením dat grafu, které na nich závisí, zavolejte [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdataworkbook/#calculateFormulas).

U vzorců mimo podporovanou podmnožinu může Aspose.Slides nedokázat vzorec parsovat nebo stanovit jeho závislosti. Pokud byl sešit upraven, předchozí kešovaná hodnota již nemůže být považována za spolehlivou. V takové situaci může čtení hodnoty buňky s nepodporovanými daty vyvolat [CellUnsupportedDataException](https://reference.aspose.com/slides/cs/php-java/aspose.slides/cellunsupporteddataexception/).

Pokud váš graf závisí na Excel funkcích, které Aspose.Slides nevyhodnocuje, vypočítejte tyto vzorce pomocí tabulkového enginu, který je podporuje, a zapište výsledné hodnoty zpět do sešitu grafu. Nepřepisujte nepodporované vzorce odhadovanými hodnotami.

## **Zpracování chyb ve vzorcích**

Existují dva různá typy problémů, které je třeba rozlišovat.

Vzorec může být platný, ale vyprodukovat chybový výsledek tabulky, jako je `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` nebo `#VALUE!`. V takovém případě je chybový token výsledkem buňky a může být vrácen prostřednictvím [ChartDataCell::getValue](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatacell/#getValue).

Vzorec může také selhat na úrovni parsování, odkazu, závislosti nebo podporovaných dat. Aspose.Slides poskytuje pro tyto případy výjimky specifické pro tabulky: [CellInvalidFormulaException](https://reference.aspose.com/slides/cs/php-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/cs/php-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/cs/php-java/aspose.slides/cellcircularreferenceexception/), a [CellUnsupportedDataException](https://reference.aspose.com/slides/cs/php-java/aspose.slides/cellunsupporteddataexception/).

V PHP přes Java jsou výjimky Java předkládány prostřednictvím `JavaException`. Když vzorce pocházejí ze šablon nebo uživatelského vstupu, ošetřete je kolem přepočítání a přístupu k hodnotám. Java výjimka uvedená ve stack trace identifikuje konkrétní selhání tabulky:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $cell = $workbook->getCell(0, "A2");
    $cell->setFormula("SUM(B2:B5)");

    try {
        $workbook->calculateFormulas();
        echo java_values($cell->getValue()) . PHP_EOL;
    } catch (JavaException $ex) {
        $ex->printStackTrace();
    }
} finally {
    $presentation->dispose();
}
```

## **Praktická omezení**

Podpora vzorců v listech grafů je určena pro definovanou podmnožinu výpočtů v tabulkách, nikoli pro úplnou kompatibilitu s Excelem. Mějte tyto omezení na paměti při navrhování pracovního postupu reportování:

- Používejte pouze dokumentované konstanty, operátory, odkazy a funkce, pokud potřebujete, aby Aspose.Slides přepočítával vzorce.
- Přepočítejte po změně buněk, na nichž výsledky vzorců závisí.
- Považujte kešované hodnoty z načtených prezentací za snímky, nikoli za náhradu přepočítání po úpravách.
- Otestujte vzorce z existujících šablon, než se spolehnete na jejich vypočítané hodnoty, zejména pokud používají funkce mimo dokumentovaný seznam.
- U vzorců, které vyžadují kompletní výpočetní engine tabulek, je vypočítejte externě a poté aktualizujte sešit grafu výslednými hodnotami.

## **FAQ**

**Jaký je rozdíl mezi [ChartDataCell::setFormula](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatacell/#setFormula) a [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatacell/#setR1C1Formula)?**

[ChartDataCell::setFormula](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatacell/#setFormula) ukládá výraz ve stylu A1, např. `B2-C2`. [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatacell/#setR1C1Formula) ukládá výraz ve stylu R1C1, např. `RC[-2]-RC[-1]`. Použijte notaci, která nejlépe odpovídá tomu, jak vzorce generujete nebo kopírujete.

**Potřebuji po výpočtu číst samotnou buňku nebo její hodnotu?**

[ChartDataWorkbook::getCell](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdataworkbook/#getCell) vrací [ChartDataCell](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatacell/). Pro získání vypočítaného výsledku zavolejte metodou [ChartDataCell::getValue](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatacell/#getValue) této buňky po přepočítání.

**Kdy bych měl zavolat [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdataworkbook/#calculateFormulas)?**

Zavolejte [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) po změně vstupních hodnot nebo vzorců a před tím, než budete záviset na vypočítaných výsledcích. Tím se aktualizují hodnoty vzorců, které podporuje vestavěný evaluátor.

**Podporuje Aspose.Slides každou funkci Excelu?**

Ne. Vestavěný evaluátor podporuje dokumentovanou podmnožinu funkcí. Funkce mimo tuto podmnožinu by neměly být považovány za správně přepočítatelné. Pokud je vyžadována úplná kompatibilita s Excelovými vzorci, proveďte výpočet pomocí vhodného tabulkového enginu a zapište finální hodnoty do sešitu grafu.

**Co se stane, pokud načtená prezentace obsahuje nepodporovaný vzorec?**

Pokud data grafu nebyla změněna, může sešit stále obsahovat dříve vypočítanou kešovanou hodnotu. Po úpravě souvisejících dat tato kešovaná hodnota může být neplatná. Přístup k buňce, jejíž vzorec nelze zpracovat, může vyvolat [CellUnsupportedDataException](https://reference.aspose.com/slides/cs/php-java/aspose.slides/cellunsupporteddataexception/).

**Jsou hodnoty chyb ve vzorcích stejné jako PHP výjimky?**

Ne. Výsledek jako `#DIV/0!` je hodnota tabulky vytvořená platným výpočtem. Selhání zpracování tabulky, jako jsou [CellInvalidFormulaException](https://reference.aspose.com/slides/cs/php-java/aspose.slides/cellinvalidformulaexception/) nebo [CellCircularReferenceException](https://reference.aspose.com/slides/cs/php-java/aspose.slides/cellcircularreferenceexception/), jsou Java výjimky předkládány PHP přes `JavaException`.

**Aktualizuje se graf automaticky, když se změní buňka se vzorcem?**

Řada grafu může odkazovat na buňky sešitu. Nejprve přepočítejte sešit, poté uložte nebo vykreslete prezentaci. Pokud datové body grafu odkazují na vypočítané buňky, graf použije tyto aktualizované hodnoty; pro tento postup není vyžadována samostatná metoda obnovy grafu.

**Mohou grafy používat externí sešit Excel?**

Ano, data grafu lze nakonfigurovat tak, aby používala externí sešit přes API dat grafu. Nicméně workflow výpočtu vzorců popsaný v tomto článku se týká sešitu dat grafu a podmnožiny vzorců vyhodnocovaných Aspose.Slides. Nepředpokládejte, že [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) poskytuje kompletní přepočet libovolných vzorců v externím souboru XLSX.

**Mohu použít vzorce, které odkazují na jiný list nebo sešit?**

Odkazy ve stylu Excelu mohou v sešitech grafů existovat, ale vyhodnocování vzorců je omezeno podporovaným parserem a množinou funkcí. Pokud je křížový odkaz na list nebo externí sešit nezbytný, ověřte přesný vzorec s vaší cílovou verzí Aspose.Slides. Pro workflow, který vyžaduje širokou kompatibilitu s Excel odkazy, vypočítejte sešit externě a zpětně zapište získané hodnoty do dat grafu.

**Měly by řetězce vzorců začínat znakem `=`?**

Příklady API Aspose.Slides přiřazují výrazy jako `B2-C2` nebo `SUM(B2:B5)` bez úvodního `=`. Použití této podoby udržuje generované vzorce v souladu s dokumentovanými příklady API.