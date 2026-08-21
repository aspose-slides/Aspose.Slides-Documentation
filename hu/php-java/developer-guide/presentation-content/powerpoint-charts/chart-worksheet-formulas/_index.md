---
title: Apply Chart Worksheet Formulas in Presentations in PHP
linktitle: Worksheet Formulas
type: docs
weight: 70
url: /hu/php-java/chart-worksheet-formulas/
keywords:
- diagram táblázat
- diagram munkalap
- diagram képlet
- munkalap képlet
- táblázat képlet
- diagram adatkönyvtár
- képletszámítás
- preferált kultúra
- kultúraspecifikus képlet
- DBCS
- logikai állandó
- numerikus állandó
- karakterlánc állandó
- hiba állandó
- aritmetikai operátor
- összehasonlító operátor
- A1 stílus
- R1C1 stílus
- előre definiált függvény
- PowerPoint
- bemutató
- PHP
- Aspose.Slides
description: "Alkalmazzon Excel-stílusú képleteket az Aspose.Slides for PHP via Java diagram munkalapokon, számítsa újra az értékeket, és használja fel az eredményeket PowerPoint diagramokban."
---
## **Áttekintés**

A PowerPoint diagramok általában a forrásadataikat beágyazott munkalapon tárolják. Az Aspose.Slides for PHP via Java segítségével hozzáférhet ehhez a munkalaphoz a diagram adatkönyvtárán keresztül, beírhat bemeneti értékeket, képleteket rendelhet a cellákhoz, kiszámíthatja a támogatott képleteket, és a kiszámított cellákat diagramadatként használhatja.

Ez a cikk bemutatja a teljes képlet munkafolyamatot: diagram létrehozása, a munkalap feltöltése, A1‑ vagy R1C1‑stílusú képletek hozzárendelése, újraszámítása, a kiszámított értékek olvasása, ezeknek a celláknak a diagram sorozathoz kapcsolása, és a bemutató mentése. Emellett ismerteti a támogatott képletszintaxist, a beépített függvények részhalmazát, a gyorsítótárazott értékeket, a nem támogatott képleteket és a táblázat-specifikus hibákat.

## **Diagram munkalapok és képletek**

Egy diagram munkalapja tartalmazza a kategóriákat, sorozatneveket és az értékeket, amelyeket a diagram használ. PowerPointban a munkalapot a diagram adat szerkesztőjének megnyitásával ellenőrizheti:

![PowerPoint diagram a beágyazott munkalappal nyitva, a kategória‑ és sorozatadatok láthatók](chart-worksheet-formulas_1.png)

Az Aspose.Slides-ben a munkalap a [ChartDataWorkbook](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdataworkbook/) osztályon keresztül érhető el. A‑1‑stílusú képletekhez használja a [ChartDataCell::setFormula](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatacell/#setFormula) metódust, az R1C1‑stílusú képletekhez a [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatacell/#setR1C1Formula) metódust. Bemeneti cellák vagy képletek módosítása után hívja a [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) metódust a támogatott képletek újraszámításához és a megfelelő cellaértékek frissítéséhez.

Egy kiszámított cella továbbra is a [ChartDataCell::getValue](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatacell/#getValue) metóduson keresztül adja vissza az eredményt. Ez fontos, ha a kódban meg szeretné vizsgálni a képlet eredményét, vagy a cellát diagram adatpontként akarja használni.

## **Diagram létrehozása és a munkalap képleteinek számítása**

Az alábbi példa egy vég‑el‑vég munkafolyamatot mutat be. Létrehoz egy csoportosított oszlopdiagramot, törli a mintaadatokat, beírja a negyedéves bevétel‑ és kiadásértékeket, képletekkel számolja a profitot, kiolvassa az eredményeket, a kiszámított cellákat diagramértékeként használja, és menti a bemutatót.

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

A diagram adatpontjai a `D2:D4` tartományra hivatkoznak, így a diagram a kiszámított profitértékeket használja. Ebben a munkafolyamatban nincs külön diagram‑frissítési hívás: először számolja újra a munkafüzetet, majd használja vagy mentse a diagram adatokat, amelyek a kiszámított cellákra mutatnak.

## **A1‑stílusú képletek használata**

Az A1 jelölés a oszlopokat betűkkel, a sorokat számokkal azonosítja. A‑1‑stílusú kifejezéseket a [ChartDataCell::setFormula](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatacell/#setFormula) metódussal rendelheti.

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

A gyakori A1 hivatkozási formák:

| Referencia | Relatív | Abszolút | Vegyes |
|---|---|---|---|
| Cell | `A2` | `$A$2` | `A$2`, `$A2` |
| Row | `2:2` | `$2:$2` | — |
| Column | `A:A` | `$A:$A` | — |
| Range | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

A relatív hivatkozások megváltozhatnak, ha egy képletet egy táblázatkezelő alkalmazás áthelyez vagy másol. Az abszolút hivatkozások mindkét koordinátát rögzítik, míg a vegyes hivatkozások csak egy sort vagy egy oszlopot rögzítenek.

## **R1C1‑stílusú képletek használata**

Az R1C1 jelölés a sorokat és oszlopokat egyaránt számmal azonosítja. A relatív hivatkozások négyzetes zárójelekben lévő eltolásokat használnak. Ezt a szintaxist a [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatacell/#setR1C1Formula) metódussal adhatja meg.

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

A gyakori R1C1 hivatkozási formák:

| Referencia | Relatív | Abszolút | Vegyes |
|---|---|---|---|
| Cell | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Row | `R[2]` | `R2` | — |
| Column | `C[3]` | `C3` | — |
| Range | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Például a `D2` cellában az `RC[-2]` azt jelenti, hogy ugyanazon sorban két oszloppal balra lévő cella (`B2`).

## **Képlet állandók és operátorok**

A beépített képletértékelő támogatja a logikai értékeket, numerikus literálokat, karakterláncokat, táblázat‑hibákat, aritmetikai operátorokat és összehasonlító operátorokat.

### **Állandók és literálok**

| Típus | Példák | Megjegyzés |
|---|---|---|
| Logikai | `TRUE`, `FALSE` | Közvetlenül használható logikai kifejezésekben, például `A2=TRUE`. |
| Numerikus | `1`, `0.5`, `.3`, `1E-2` | A közönséges és a tudományos jelölés egyaránt támogatott. |
| Karakterlánc | `"abc"`, `"2/3/2020 12:00"` | A képleten belüli szövegliterálokat dupla idézőjelek közé kell tenni. |
| Hiba eredmény | `#DIV/0!`, `#N/A`, `#REF!` | Egy érvényes képlet a táblázat‑hibaértékek egyikére is kiértékelődhet a normál eredmény helyett. |

Ez a példa több állandótípust használ:

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

    $logicalValue = java_values($workbook->getCell(0, "B2")->getValue()); // hamis
    $numericValue = java_values($workbook->getCell(0, "C2")->getValue()); // 1.5
    $scientificValue = java_values($workbook->getCell(0, "D2")->getValue()); // 0.003
    $stringValue = java_values($workbook->getCell(0, "E2")->getValue()); // abc
    $errorValue = java_values($workbook->getCell(0, "F2")->getValue()); // #DIV/0!
} finally {
    $presentation->dispose();
}
```

### **Aritmetikai operátorok**

| Operátor | Jelentés | Példa |
|---|---|---|
| `+` | Összeadás vagy egyes jel | `2+3` |
| `-` | Kivonás vagy negatív jel | `2-3`, `-3` |
| `*` | Szorzás | `2*3` |
| `/` | Osztás | `2/3` |
| `%` | Százalék | `30%` |
| `^` | Hatványozás | `2^3` |

A kiértékelés sorrendjének egyértelművé tételéhez használjon zárójeleket, például `(A2+B2)*C2`.

### **Összehasonlító operátorok**

Az összehasonlítási kifejezések logikai értékeket adnak vissza.

| Operátor | Jelentés | Példa |
|---|---|---|
| `=` | Egyenlő | `A2=3` |
| `<>` | Nem egyenlő | `A2<>3` |
| `>` | Nagyobb | `A2>3` |
| `>=` | Nagyobb vagy egyenlő | `A2>=3` |
| `<` | Kisebb | `A2<3` |
| `<=` | Kisebb vagy egyenlő | `A2<=3` |

## **Támogatott előre definiált függvények**

Az Aspose.Slides tartalmaz egy beépített képletértékelőt diagram munkalapokhoz, de nem egy teljes Excel számítási motor. A dokumentált függvénykészlet az alábbiakra korlátozódik. Ne feltételezze, hogy egy tetszőleges Excel‑függvényt újra ki tud számítani a [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) metódus.

| Függvény | Cél vagy támogatott forma | Példa |
|---|---|---|
| `ABS` | Abszolút érték | `ABS(A2)` |
| `AVERAGE` | Aritmetikai átlag | `AVERAGE(B2:B5)` |
| `CEILING` | Szám felfelé kerekítése egy többszörösre | `CEILING(A2,5)` |
| `CHOOSE` | Érték kiválasztása index alapján | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Szöveges értékek összefűzése | `CONCAT(A2,B2)` |
| `CONCATENATE` | Szöveges értékek összefűzése | `CONCATENATE(A2," ",B2)` |
| `DATE` | Dátumérték létrehozása a 1900‑as dátumrendszerrel | `DATE(2026,8,19)` |
| `DAYS` | Napok száma két dátum között | `DAYS(B2,A2)` |
| `FIND` | Egy szöveges érték keresése egy másikban | `FIND("-",A2)` |
| `FINDB` | Byte‑orientált szövegkeresés | `FINDB("a",A2)` |
| `IF` | Feltételes eredmény | `IF(A2>0,A2,0)` |
| `INDEX` | Referencia forma | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektor forma | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektor forma | `MATCH(A2,B2:B5,0)` |
| `MAX` | Legnagyobb érték | `MAX(B2:B5)` |
| `SUM` | Összeg | `SUM(B2:B5)` |
| `VLOOKUP` | Vertikális keresés | `VLOOKUP(A2,B2:D10,3,FALSE)` |

A táblázatban szereplő korlátozások jelentősek: az `INDEX` referencia formában, míg a `LOOKUP` és a `MATCH` vektor formában van dokumentálva. A `DATE` a 1900‑as dátumrendszert használja. Az itt nem felsorolt funkciók és jellemzők azt jelentik, hogy az Aspose.Slides képletértékelőjük nem támogatja őket, hacsak másképp nincsenek dokumentálva.

## **Képletek számítása preferált kultúrával**

Néhány diagram‑munkafüzet‑függvény a szöveget kultúra‑specifikus szabályok szerint interpretuálja. Ez különösen fontos azoknál a függvényeknél, amelyek a dupla‑bájtos karakterkészleteket (DBCS) használó nyelvekhez készültek. Az ilyen képletek helyes számításához hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/loadoptions/) objektumot, állítsa be a preferált kultúrát a [SpreadsheetOptions::setPreferredCulture](https://reference.aspose.com/slides/hu/php-java/aspose.slides/spreadsheetoptions/#setPreferredCulture) metódussal, adja át a táblázat‑opciókat a [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/loadoptions/#setSpreadsheetOptions) metódussal, majd töltse be a bemutatót.

Az alábbi példa a japán kultúrát választja, megnyit egy bemutatót a beállított betöltési opciókkal, és meghívja a [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) metódust minden diagram‑munkafüzethez:

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

A preferált kultúra a bemutató betöltési konfigurációjának része, ezért a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) példány létrehozása előtt kell beállítani. Használja a munkafüzet képletei által elvárt kultúrát; például a japán DBCS számítási szabályokhoz a `ja-JP` értéket kell megadni.

## **Újraszámítás és gyorsítótárazott értékek**

A táblázat‑fájlok gyakran tárolják a képletet és az utolsó kiszámított értékét is. Az Aspose.Slides ezért képes egy gyorsítótárazott értéket beolvasni a [ChartDataCell::getValue](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatacell/#getValue) metóduson keresztül, amikor a bemutatót betöltik, és a kapcsolódó diagram‑adatok nem változtak.

A bemeneti cellák vagy képletek módosítása után ne támaszkodjon egy régi gyorsítótárazott eredményre. Hívja a [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) metódust a kiszámított értékek olvasása vagy a diagram‑adatok mentése előtt, amelyek rájuk támaszkodnak.

A támogatott részhalmazon kívül eső képletek esetén az Aspose.Slides előfordulhat, hogy nem képes a képletet elemezni vagy a függőségeket meghatározni. Ha a munkafüzet módosult, a korábbi gyorsítótárazott érték már nem tekinthető megbízhatónak. Ebben a helyzetben egy nem támogatott adatú cella értékének olvasása [CellUnsupportedDataException](https://reference.aspose.com/slides/hu/php-java/aspose.slides/cellunsupporteddataexception/) kivételt vált ki.

Ha diagramja olyan Excel‑függvényeket használ, amelyeket az Aspose.Slides nem értékel ki, számítsa ki ezeket a képleteket egy olyan táblázat‑motorral, amely támogatja őket, és írja vissza a kapott értékeket a diagram‑munkafüzetbe. Ne helyettesítse a nem támogatott képleteket kitalált értékekkel.

## **Képlet hibák kezelése**

Kétféle problémát kell elkülöníteni.

Egy képlet lehet érvényes, de táblázat‑hibát eredményez, például `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` vagy `#VALUE!`. Ebben az esetben a hiba‑token egy cella‑eredmény, és a [ChartDataCell::getValue](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatacell/#getValue) metódussal visszaadható.

Egy képlet hibát is jelezhet a feldolgozás, hivatkozás, függőség vagy támogatott adat szintjén. Az Aspose.Slides ezekre az esetekre táblázat‑specifikus kivételeket biztosít: [CellInvalidFormulaException](https://reference.aspose.com/slides/hu/php-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/hu/php-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/hu/php-java/aspose.slides/cellcircularreferenceexception/) és [CellUnsupportedDataException](https://reference.aspose.com/slides/hu/php-java/aspose.slides/cellunsupporteddataexception/).

PHP‑ban Java‑ként a Java‑kivétel a `JavaException` objektumon keresztül érhető el. Amikor a képletek sablonokból vagy felhasználói bemenetből származnak, kezelje őket az újraszámítás és az értéklekérdezés körül. A Java‑kivételt a stack‑trace tartalmazza, amely megmutatja a konkrét táblázati hibát:

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

## **Gyakorlati korlátok**

A diagram‑munkalapok képlet‑támogatása egy meghatározott részhalmazra épül, nem teljes Excel‑kompatibilitásra. Tartsa szem előtt ezeket a korlátokat a jelentéskészítési munkafolyamat tervezésekor:

- Használja csak a dokumentált állandókat, operátorokat, hivatkozásokat és függvényeket, ha azt szeretné, hogy az Aspose.Slides újraszámolja a képleteket.
- Számítsa újra a cellákat, amelyektől a képlet‑eredmények függenek.
- Tekintse a betöltött bemutatókból származó gyorsítótárazott értékeket pillanatképként, nem pedig az szerkesztés után történő újraszámítás helyettesítőjeként.
- Tesztelje a létező sablonokból származó képleteket, mielőtt a kiszámított értékekre támaszkodna, különösen, ha olyan függvényeket tartalmaznak, amelyek nincsenek a dokumentált listán.
- A teljes táblázat‑számítási motorozást igénylő képleteket számítsa ki külsőleg, majd frissítse a diagram‑munkafüzetet a kapott értékekkel.

## **GYIK**

**Mi a különbség a [ChartDataCell::setFormula](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatacell/#setFormula) és a [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatacell/#setR1C1Formula) között?**

A [ChartDataCell::setFormula](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatacell/#setFormula) A1‑stílusú kifejezést tárol, például `B2-C2`. A [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatacell/#setR1C1Formula) R1C1‑stílusú kifejezést tárol, például `RC[-2]-RC[-1]`. A használni kívánt jelölés attól függ, hogy hogyan generál vagy másol képleteket.

**A számítás után a cellát vagy annak értékét kell olvasnom?**

A [ChartDataWorkbook::getCell](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdataworkbook/#getCell) egy [ChartDataCell](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatacell/) objektumot ad vissza. A kiszámított eredményhez a cella [ChartDataCell::getValue](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatacell/#getValue) metódusát kell meghívni az újraszámítás után.

**Mikor kell meghívni a [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) metódust?**

Hívja a [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) metódust a bemeneti értékek vagy képletek módosítása után, és még az előtt, hogy a kiszámított eredményeket felhasználná. Ez frissíti a beépített értékelő által támogatott képletek értékeit.

**Támogatja-e az Aspose.Slides az összes Excel‑függvényt?**

Nem. A beépített értékelő egy dokumentált függvény‑részhalmazt támogat. A részhalmazon kívül eső függvényekre nem szabad számítani, hogy helyesen újra lesznek számolva. Ha teljes Excel‑képlet kompatibilitásra van szükség, végezze el a számítást egy megfelelő táblázat‑motorral, és írja az eredményt a diagram‑munkafüzetbe.

**Mi történik, ha egy betöltött bemutató nem támogatott képletet tartalmaz?**

Ha a diagram‑adatok nem változtak, a munkafüzet a korábban kiszámított gyorsítótárazott értéket tartalmazhatja. A kapcsolódó adatok módosítása után ez a gyorsítótárazott érték már nem érvényes. Egy olyan cella elérése, amelynek képletét nem tudja kezelni, [CellUnsupportedDataException](https://reference.aspose.com/slides/hu/php-java/aspose.slides/cellunsupporteddataexception/) kivételt vált ki.

**Ugyanazok a képlet‑hibák, mint a PHP‑kivételek?**

Nem. A `#DIV/0!`‑hoz hasonló eredmény egy táblázat‑érték, amely egy érvényes számításból származik. A táblázat‑feldolgozási hibákat, mint a [CellInvalidFormulaException](https://reference.aspose.com/slides/hu/php-java/aspose.slides/cellinvalidformulaexception/) vagy a [CellCircularReferenceException](https://reference.aspose.com/slides/hu/php-java/aspose.slides/cellcircularreferenceexception/), Java‑kivételek jelzik, és a PHP‑ban a `JavaException` objektumon keresztül érhetők el.

**Frissül automatikusan a diagram, ha egy képlet‑cellát módosítanak?**

A diagram‑sorozat hivatkozhat munkafüzet‑cellákra. Először számítsa újra a munkafüzetet, majd mentse vagy renderelje a bemutatót. Ha a diagram adatpontjai a kiszámított cellákra mutatnak, a diagram a frissített értékeket használja; külön diagram‑frissítési metódusra nincs szükség ebben a munkafolyamatban.

**Használhatók külső Excel‑munkafüzetek a diagramokhoz?**

Igen, a diagram‑adatok konfigurálhatók úgy, hogy külső munkafüzetet használjanak a diagram‑adat‑API‑val. Azonban ebben a cikkben leírt képlet‑számítási munkafolyamat kizárólag a diagram‑adat‑munkafüzetre és az Aspose.Slides által értékelt képlet‑részhalmazra vonatkozik. Ne tételezze fel, hogy a [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) teljes újraszámítást végez tetszőleges képletekkel egy külső XLSX fájlban.

**Használhatók képletek, amelyek más munkalapra vagy munkafüzetre hivatkoznak?**

Az Excel‑stílusú hivatkozások előfordulhatnak a diagram‑munkafüzetekben, de a képlet‑értékelés a támogatott elemző és függvény‑készlet által korlátozott. Ha kereszt‑lap vagy külső hivatkozás elengedhetetlen, ellenőrizze a konkrét képletet a használt Aspose.Slides verzióval. Szélesebb Excel‑hivatkozási kompatibilitást igénylő munkafolyamatok esetén számítsa ki a munkafüzetet külsőleg, és írja vissza a feloldott értékeket a diagram‑adatokba.

**Kell-e a képletszöveg `=` karakterrel kezdődjön?**

Az Aspose.Slides API példák a `B2-C2` vagy `SUM(B2:B5)` formát használják, azaz vezető `=` nélkül. Ennek a formátumnak a használata összhangban van a dokumentált API‑példákkal.