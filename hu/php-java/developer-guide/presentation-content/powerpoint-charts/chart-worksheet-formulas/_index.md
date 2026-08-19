---
title: Diagram munkalap képletek alkalmazása prezentációkban PHP‑ben
linktitle: Munkalap képletek
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
- képlet számítás
- logikai állandó
- számállandó
- szövegállandó
- hibállandó
- aritmetikai operátor
- összehasonlító operátor
- A1 stílus
- R1C1 stílus
- előre definiált függvény
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Alkalmazza az Excel‑stílusú képleteket az Aspose.Slides for PHP via Java diagrammunkalapokon, számítsa újra az értékeket, és használja fel az eredményeket a PowerPoint diagramokban."
---
## **Áttekintés**

A PowerPoint-diagramok általában a forrásadatokat egy beágyazott munkalapon tárolják. Az Aspose.Slides for PHP via Java segítségével elérhető ez a munkalap a diagram adatkönyvtárán (chart data workbook) keresztül, beviteli értékeket írhat be, képleteket rendelhet cellákhoz, kiszámíthatja a támogatott képleteket, és a kiszámított cellákat diagramadatként használhatja.

Ez a cikk bemutatja a teljes képlet-munkafolyamatot: diagram létrehozása, a munkalap feltöltése, A1‑stílusú vagy R1C1‑stílusú képletek hozzárendelése, azok újraszámítása, a kiszámított értékek olvasása, a cellák diagram sorozathoz kapcsolása, és a prezentáció mentése. Emellett ismerteti a támogatott képletszintaxist, a beépített függvények részhalmazát, a gyorsítótárazott értékeket, a nem támogatott képleteket és a táblázat-specifikus hibákat.

## **Diagram munkalapok és képletek**

Egy diagram munkalapja tartalmazza a diagram által használt kategóriákat, sorozatneveket és értékeket. PowerPointban a munkalapot a diagram adat szerkesztőjének megnyitásával tekintheti meg:

![PowerPoint diagram beágyazott munkalappal megnyitva, a kategória és sorozat adatot mutatja](chart-worksheet-formulas_1.png)

Az Aspose.Slides-ben a munkalap a [ChartDataWorkbook](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdataworkbook/) osztályon keresztül érhető el. Használja a [ChartDataCell::setFormula](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatacell/#setFormula) metódust A1‑stílusú képletekhez, illetve a [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatacell/#setR1C1Formula) metódust R1C1‑stílusú képletekhez. A bemeneti cellák vagy képletek módosítása után hívja meg a [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) metódust a támogatott képletek újraszámításához és a megfelelő cellaértékek frissítéséhez.

Egy kiszámított cella továbbra is az eredményét a [ChartDataCell::getValue](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatacell/#getValue) metódussal adja vissza. Ez fontos, ha a kódban ellenőrizni kell egy képlet eredményét vagy a cellát diagramadat-pontként szeretné használni.

## **Diagram létrehozása és a munkalap képleteinek kiszámítása**

Az alábbi példa egy teljes végponttól végpontig tartó munkafolyamatot mutat be. Létrehoz egy klaszterezett oszlopdiagramot, törli a minta adatokat, beírja a negyedéves bevételi és költségértékeket, képletekkel kiszámítja a profitot, kiolvassa az eredményeket, a kiszámított cellákat diagramértékekként használja, és elmenti a prezentációt.

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

A diagram adatpontjai a `D2:D4` tartományra hivatkoznak, ezért a diagram a kiszámított profitértékeket használja. Ebben a munkafolyamatban nincs külön diagram‑frissítési hívás: először számolja újra a munkafüzetet, majd használja vagy mentse a diagramadatokat, amelyek a kiszámított cellákra mutatnak.

## **A1‑stílusú képletek használata**

Az A1 jelölés az oszlopokat betűkkel, a sorokat számokkal azonosítja. A [ChartDataCell::setFormula](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatacell/#setFormula) segítségével adhat meg A1‑stílusú kifejezéseket.

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

| Hivatkozás | Relatív | Abszolút | Vegyes |
|---|---|---|---|
| Cell | `A2` | `$A$2` | `A$2`, `$A2` |
| Sor | `2:2` | `$2:$2` | — |
| Oszlop | `A:A` | `$A:$A` | — |
| Tartomány | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

A relatív hivatkozások megváltozhatnak, ha egy képletet egy táblázatkezelő áthelyez vagy másol. Az abszolút hivatkozások mindkét koordinátát rögzítik, míg a vegyes hivatkozások csak egy sort vagy oszlopot rögzítenek.

## **R1C1‑stílusú képletek használata**

Az R1C1 jelölés a sorokat és oszlopokat is numerikusan azonosítja. A relatív hivatkozások szögletes zárójelekben lévő eltolásokat használnak. Ezt a szintaxist a [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatacell/#setR1C1Formula) metódussal adhatja meg.

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

| Hivatkozás | Relatív | Abszolút | Vegyes |
|---|---|---|---|
| Cell | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Sor | `R[2]` | `R2` | — |
| Oszlop | `C[3]` | `C3` | — |
| Tartomány | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Például a `D2` cellában az `RC[-2]` azt jelenti, hogy ugyanabban a sorban két oszloppal balra lévő cella (`B2`).

## **Képletállandók és operátorok**

A beépített képletértékelő logikai értékeket, numerikus literálokat, sztringeket, táblázat hibákat, aritmetikai operátorokat és összehasonlító operátorokat támogat.

### **Állandók és literálok**

| Típus | Példák | Megjegyzés |
|---|---|---|
| Logikai | `TRUE`, `FALSE` | Közvetlenül használható logikai kifejezésekben, például `A2=TRUE`. |
| Numerikus | `1`, `0.5`, `.3`, `1E-2` | A közönséges és a tudományos jelölés egyaránt támogatott. |
| Sztring | `"abc"`, `"2/3/2020 12:00"` | A szöveges literálok dupla idézőjel között szerepelnek a képletben. |
| Hiba eredmény | `#DIV/0!`, `#N/A`, `#REF!` | Egy érvényes képlet eredménye lehet táblázat hibaérték is a normál eredmény helyett. |

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
| `+` | Összeadás vagy unáris plusz | `2+3` |
| `-` | Kivonás vagy negáció | `2-3`, `-3` |
| `*` | Szorzás | `2*3` |
| `/` | Osztás | `2/3` |
| `%` | Százalék | `30%` |
| `^` | Hatványozás | `2^3` |

Használjon zárójeleket a kiértékelési sorrend egyértelművé tételéhez, például `(A2+B2)*C2`.

### **Összehasonlító operátorok**

Az összehasonlító kifejezések logikai értéket adnak vissza.

| Operátor | Jelentés | Példa |
|---|---|---|
| `=` | Egyenlő | `A2=3` |
| `<>` | Nem egyenlő | `A2<>3` |
| `>` | Nagyobb | `A2>3` |
| `>=` | Nagyobb vagy egyenlő | `A2>=3` |
| `<` | Kisebb | `A2<3` |
| `<=` | Kisebb vagy egyenlő | `A2<=3` |

## **Támogatott beépített függvények**

Az Aspose.Slides beépített képletértékelővel rendelkezik diagram munkalapokhoz, de nem egy teljes Excel számítási motor. A dokumentált függvényhalmaz a lenti függvényekre korlátozódik. Ne feltételezze, hogy bármely Excel függvény újraszámítható a [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) segítségével.

| Függvény | Cél vagy támogatott forma | Példa |
|---|---|---|
| `ABS` | Abszolút érték | `ABS(A2)` |
| `AVERAGE` | Aritmetikai középérték | `AVERAGE(B2:B5)` |
| `CEILING` | Felfelé kerekítés egy többszörösre | `CEILING(A2,5)` |
| `CHOOSE` | Érték kiválasztása index alapján | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Szövegértékek összefűzése | `CONCAT(A2,B2)` |
| `CONCATENATE` | Szövegértékek összefűzése | `CONCATENATE(A2," ",B2)` |
| `DATE` | Dátumérték létrehozása 1900-as dátumrendszerrel | `DATE(2026,8,19)` |
| `DAYS` | Napok számának visszaadása két dátum között | `DAYS(B2,A2)` |
| `FIND` | Szöveg keresése egy másik szövegben | `FIND("-",A2)` |
| `FINDB` | Byte‑orientált szövegkeresés | `FINDB("a",A2)` |
| `IF` | Feltételes eredmény | `IF(A2>0,A2,0)` |
| `INDEX` | Hivatkozási forma | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektor forma | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektor forma | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximum érték | `MAX(B2:B5)` |
| `SUM` | Összeg | `SUM(B2:B5)` |
| `VLOOKUP` | Vertikális keresés | `VLOOKUP(A2,B2:D10,3,FALSE)` |

A táblázatban szereplő korlátozások jelentősek: az `INDEX` hivatkozási formában van dokumentálva, míg a `LOOKUP` és `MATCH` vektorformában. A `DATE` a 1900‑as dátumrendszert használja. A nem felsorolt funkciókat tekintse Nem támogatottnak az Aspose.Slides képletértékelőben, hacsak nincs külön dokumentálva.

## **Újraszámítás és gyorsítótárazott értékek**

A táblázatfájlok gyakran tárolják a képletet és az utolsó kiszámított értéket is. Az Aspose.Slides ezért a [ChartDataCell::getValue](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatacell/#getValue) metódussal egy gyorsítótárazott értéket is olvashat, amikor a prezentáció betöltődik és a vonatkozó diagramadat nem változott.

A bemeneti cellák vagy képletek módosítása után ne alapozzon a régi gyorsítótárazott eredményre. Hívja meg a [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) metódust a kiszámított értékek olvasása vagy a diagramadatok mentése előtt, amelyek ezekre a cellákra támaszkodnak.

A támogatott részhalmazon kívüli képletek esetén az Aspose.Slides előfordulhat, hogy nem tudja értelmezni a képletet vagy annak függőségeit. Ha a munkafüzet módosult, a korábban gyorsítótárazott érték már nem tekinthető megbízhatónak. Ilyen helyzetben egy nem támogatott adatú cella értékének olvasása [CellUnsupportedDataException](https://reference.aspose.com/slides/hu/php-java/aspose.slides/cellunsupporteddataexception/) kivételt dobhat.

Ha diagramja olyan Excel‑függvényeket használ, amelyeket az Aspose.Slides nem értékel, számítsa ki ezeket egy olyan táblázatmotorral, amely támogatja őket, majd írja vissza az eredményeket a diagram munkafüzetébe. Ne helyettesítse a nem támogatott képleteket tippelt értékekkel.

## **Képlet hibák kezelése**

Kétféle problémát kell megkülönböztetni.

Egy képlet lehet érvényes, de táblázat hibát eredményez, például `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` vagy `#VALUE!`. Ebben az esetben a hiba token egy cella eredménye, és a [ChartDataCell::getValue](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatacell/#getValue) segítségével visszakapható.

Egy képlet a feldolgozás, hivatkozás, függőségek vagy a támogatott adatok szintjén is hibát okozhat. Az Aspose.Slides ezekhez a helyzetekhez táblázat‑specifikus kivételeket biztosít: [CellInvalidFormulaException](https://reference.aspose.com/slides/hu/php-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/hu/php-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/hu/php-java/aspose.slides/cellcircularreferenceexception/) és [CellUnsupportedDataException](https://reference.aspose.com/slides/hu/php-java/aspose.slides/cellunsupporteddataexception/).

PHP‑ban Java‑ként a Java kivételek a `JavaException`‑on keresztül érhetők el. Ha a képletek sablonokból vagy felhasználói bemenetből származnak, kezelje őket az újraszámítás és az értéklekérés körül. A stack trace‑ben megjelenő Java kivétel pontosan azonosítja a táblázati hibát:

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

## **Gyakorlati korlátozások**

A diagram munkalapok képlet‑támogatása egy meghatározott részhalmazra épül, nem nyújt teljes Excel kompatibilitást. Tartsa szem előtt ezeket a korlátokat jelentéskészítési munkafolyamat tervezésekor:

- Csak a dokumentált állandókat, operátorokat, hivatkozásokat és függvényeket használja, ha azt szeretné, hogy az Aspose.Slides újraszámolja a képleteket.
- Újraszámítás a képlet eredményét befolyásoló cellák módosítása után.
- A betöltött prezentációk gyorsítótárazott értékeit tekintse pillanatfelvételeknek, ne helyettesítsék az újraszámítást a módosítások után.
- Tesztelje a meglévő sablonok képleteit, mielőtt a kiszámított értékeikre hagyatkozik, különösen, ha azok a dokumentált listán kívüli függvényeket tartalmaznak.
- Olyan képletek esetén, amelyek teljes táblázatszámítási motort igényelnek, számítsa ki őket külsőleg, majd frissítse a diagram munkafüzetét a kapott értékekkel.

## **GYIK**

**Mi a különbség a [ChartDataCell::setFormula](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatacell/#setFormula) és a [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatacell/#setR1C1Formula) között?**

[ChartDataCell::setFormula](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatacell/#setFormula) A1‑stílusú kifejezést tárol, például `B2-C2`. [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatacell/#setR1C1Formula) R1C1‑stílusú kifejezést tárol, például `RC[-2]-RC[-1]`. Használja azt a jelölést, amelyik a legjobban illik a képletek generálásához vagy másolásához.

**Olvasnom kell a cellát vagy annak értékét a számítás után?**

[ChartDataWorkbook::getCell](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdataworkbook/#getCell) egy [ChartDataCell](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatacell/) objektumot ad vissza. A kiszámított eredményhez hívja meg ennek a cellának a [ChartDataCell::getValue](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatacell/#getValue) metódusát az újraszámítás után.

**Mikor kell meghívni a [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) metódust?**

Hívja meg a [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) metódust a bemeneti értékek vagy képletek módosítása után, és mielőtt a kiszámított eredményeket felhasználná. Ez frissíti a beépített értékelő által támogatott képletek értékeit.

**Támogatja-e az Aspose.Slides minden Excel‑függvényt?**

Nem. A beépített értékelő a dokumentált függvény‑részhalmazt támogatja. A részhalmazon kívüli függvényekre ne számítson arra, hogy helyesen újraszámolódnak. Ha teljes Excel‑képletszintű kompatibilitásra van szükség, végezze a számítást egy megfelelő táblázatmotorral, majd írja az eredményeket a diagram munkafüzetébe.

**Mi történik, ha egy betöltött prezentáció nem támogatott képletet tartalmaz?**

Ha a diagramadat nem változott, a munkafüzet még tartalmazhat egy korábban kiszámított gyorsítótárazott értéket. A kapcsolódó adatok módosítása után ez az érték már nem biztos, hogy érvényes. Egy olyan cella elérése, amelynek képletét nem lehet kezelni, [CellUnsupportedDataException](https://reference.aspose.com/slides/hu/php-java/aspose.slides/cellunsupporteddataexception/) kivételt vált ki.

**Ugyanazok a képlet hibák, mint a PHP‑kivételek?**

Nem. A `#DIV/0!`‑hoz hasonló eredmény egy táblázat‑érték, amely egy érvényes számításból származik. A táblázat‑feldolgozási hibák, mint a [CellInvalidFormulaException](https://reference.aspose.com/slides/hu/php-java/aspose.slides/cellinvalidformulaexception/) vagy a [CellCircularReferenceException](https://reference.aspose.com/slides/hu/php-java/aspose.slides/cellcircularreferenceexception/), Java‑kivételek, amelyeket a `JavaException`‑on keresztül ér el PHP‑ban.

**Frissül automatikusan a diagram, ha egy képlet‑cellát módosítanak?**

Egy diagram sorozat hivatkozhat munkafüzet‑cellákra. Először számolja újra a munkafüzetet, majd mentse vagy renderelje a prezentációt. Ha a diagram adatpontjai a kiszámított cellákra mutatnak, a diagram a frissített cellaértékeket használja; nincs szükség külön diagram‑frissítési metódusra ebben a munkafolyamatban.

**Használhat-e a diagram külső Excel‑munkafüzetet?**

Igen, a diagram adat beállítható külső munkafüzet használatára a diagram adat‑API‑val. Azonban ebben a cikkben leírt képletszámítási munkafolyamat a diagram adat‑munkafüzetre és az Aspose.Slides által kiértékelt képlet‑részhalmazra vonatkozik. Ne feltételezze, hogy a [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) teljes újraszámítást végez egy külső XLSX‑fájlban lévő tetszőleges képletekre.

**Használhatok‑e olyan képleteket, amelyek más munkalapra vagy munkafüzetre hivatkoznak?**

Az Excel‑stílusú hivatkozások előfordulhatnak a diagram munkafüzetekben, de a képlet‑értékelés a támogatott elemző és függvény‑készlet által korlátozott. Ha egy kereszt‑lap vagy külső hivatkozás elengedhetetlen, ellenőrizze a pontos képletet a használt Aspose.Slides verzióval. Széles körű Excel‑hivatkozási kompatibilitást igénylő munkafolyamatok esetén számítsa ki a munkafüzetet külsőleg, és írja vissza a feloldott értékeket a diagram adatba.

**Kell‑e a képletsztring `=` jellel kezdődjön?**

Az Aspose.Slides API‑példák kifejezéseket, például `B2-C2` vagy `SUM(B2:B5)`, egyenlőségjel nélkül adnak meg. Ennek a formátumnak a használata összhangban van a dokumentált API‑példákkal.