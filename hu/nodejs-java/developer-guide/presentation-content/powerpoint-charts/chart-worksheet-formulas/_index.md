---
title: Diagrammunkalap képletek alkalmazása prezentációkban JavaScript használatával
linktitle: Munkalap képletek
type: docs
weight: 70
url: /hu/nodejs-java/chart-worksheet-formulas/
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
- hibaállandó
- aritmetikai operátor
- összehasonlító operátor
- A1 stílus
- R1C1 stílus
- előre definiált függvény
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Alkalmazzon Excel-stílusú képleteket az Aspose.Slides for Node.js via Java diagram munkalapokon, számolja újra az értékeket, és használja fel az eredményeket PowerPoint diagramokban."
---
## **Áttekintés**

A PowerPoint-diagramok általában beágyazott munkalapon tárolják a forrásadatokat. Az Aspose.Slides for Node.js via Java használatával hozzáférhet a munkalaphoz a diagram adatkönyvtárán keresztül, beírhat bemeneti értékeket, képleteket rendelhet cellákhoz, kiszámíthatja a támogatott képleteket, és a kiszámított cellákat diagramadatként használhatja.

Ez a cikk bemutatja a teljes képletmunkafolyamatot: diagram létrehozása, a munkalap feltöltése, A1‑stílusú vagy R1C1‑stílusú képletek hozzárendelése, azok újraszámítása, a kiszámított értékek kiolvasása, a cellák összekapcsolása egy diagram sorozattal, és a prezentáció mentése. Leírja továbbá a támogatott képlet szintaxist, a beépített függvények részhalmazát, a gyorsítótárazott értékeket, a nem támogatott képleteket és a táblázatspecifikus hibákat.

## **Diagram munkalapok és képletek**

Egy diagram munkalapja tartalmazza a kategóriákat, a sorozatneveket és az értékeket, amelyeket a diagram használ. PowerPointban a munkalapot a diagram adat-szerkesztő megnyitásával ellenőrizheti:

![PowerPoint-diagram beágyazott munkalappal, kategória- és sorozatadatok megjelenítése](chart-worksheet-formulas_1.png)

Az Aspose.Slides-ben a munkalapot a [ChartDataWorkbook](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdataworkbook/) osztály exponálja. A1‑stílusú képletekhez használja a [ChartDataCell.setFormula](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) metódust, R1C1‑stílusú képletekhez a [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) metódust. Bemeneti cellák vagy képletek módosítása után hívja meg a [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) metódust a támogatott képletek újraszámításához és a cellaértékek frissítéséhez.

Egy kiszámított cella továbbra is a [ChartDataCell.getValue](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatacell/#getValue--) metódussal adja vissza az eredményt. Ez akkor fontos, amikor a kódban meg kell vizsgálnia a képlet eredményét, vagy a cellát diagramadatként akarja használni.

## **Diagram létrehozása és munkalap képletek kiszámítása**

Az alábbi példa egy végponttól‑végpontig tartó munkafolyamatot mutat be. Létrehoz egy csoportos oszlopdiagramot, törli a mintaadatokat, beírja a negyedéves bevétel‑ és költségértékeket, képletekkel számítja ki a profitot, kiolvassa az eredményeket, a kiszámított cellákat diagramértékekként használja, és menti a prezentációt.

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

A diagram adatpontjai a `D2:D4` tartományra hivatkoznak, így a diagram a kiszámított profitértékeket használja. Ebben a munkafolyamatban nincs külön diagram‑frissítési hívás: először számolja újra a munkafüzetet, majd használja vagy mentse a számított cellákra mutató diagramadatokat.

## **A1‑stílusú képletek használata**

Az A1‑notáció betűkkel jelöli az oszlopokat, számokkal a sorokat. A [ChartDataCell.setFormula](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) metódussal adhat meg A1‑stílusú kifejezéseket.

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

Az általános A1 hivatkozási formák:

| Hivatkozás | Relatív | Abszolút | Vegyes |
|---|---|---|---|
| Cell | `A2` | `$A$2` | `A$2`, `$A2` |
| Row | `2:2` | `$2:$2` | — |
| Column | `A:A` | `$A:$A` | — |
| Range | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

A relatív hivatkozások megváltozhatnak, ha a képletet egy táblázatkezelő áthelyezi vagy másolja. Az abszolút hivatkozások mindkét koordinátát rögzítik, a vegyes hivatkozások csak egy sor vagy egy oszlop rögzítését végzik.

## **R1C1‑stílusú képletek használata**

Az R1C1 notáció mind a sorokat, mind az oszlopokat numerikusan jelöli. Relatív hivatkozások a szögletes zárójelekben megadott eltolásokat használják. Ezt a szintaxist a [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) metódussal adhatja meg.

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

Az általános R1C1 hivatkozási formák:

| Hivatkozás | Relatív | Abszolút | Vegyes |
|---|---|---|---|
| Cell | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Row | `R[2]` | `R2` | — |
| Column | `C[3]` | `C3` | — |
| Range | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Például a `D2` cellában a `RC[-2]` a sorban két oszloppal balra lévő cellát jelenti (`B2`).

## **Képletállandók és operátorok**

A beépített képletértékelő logikai értékeket, numerikus literálokat, szövegeket, táblázathibákat, aritmetikai operátorokat és összehasonlító operátorokat támogat.

### **Állandók és literálok**

| Típus | Példák | Megjegyzés |
|---|---|---|
| Logikai | `TRUE`, `FALSE` | Közvetlenül használható logikai kifejezésekben, például `A2=TRUE`. |
| Numerikus | `1`, `0.5`, `.3`, `1E-2` | A közös és tudományos jelölés is támogatott. |
| Szöveg | `"abc"`, `"2/3/2020 12:00"` | A szövegliterálokat dupla idézőjelek közé kell tenni a képletben. |
| Hiba eredmény | `#DIV/0!`, `#N/A`, `#REF!` | Egy érvényes képlet a táblázat hibaértékére is kiértékelődhet a normál eredmény helyett. |

Ez a példa több állandó típust használ:

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

    const logicalValue = workbook.getCell(0, "B2").getValue(); // hamis
    const numericValue = workbook.getCell(0, "C2").getValue(); // 1.5
    const scientificValue = workbook.getCell(0, "D2").getValue(); // 0.003
    const stringValue = workbook.getCell(0, "E2").getValue(); // abc
    const errorValue = workbook.getCell(0, "F2").getValue(); // #DIV/0!
} finally {
    presentation.dispose();
}
```

### **Aritmetikai operátorok**

| Operátor | Jelentés | Példa |
|---|---|---|
| `+` | Összeadás vagy egyelőleg pozitív előjel | `2+3` |
| `-` | Kivonás vagy negatív előjel | `2-3`, `-3` |
| `*` | Szorzás | `2*3` |
| `/` | Osztás | `2/3` |
| `%` | Százalék | `30%` |
| `^` | Hatványozás | `2^3` |

Használjon zárójeleket a kiértékelési sorrend egyértelműsítéséhez, például `(A2+B2)*C2`.

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

## **Támogatott előre definiált függvények**

Az Aspose.Slides beépített képletértékelőt biztosít a diagram munkalapokhoz, de nem egy teljes Excel számítási motor. A dokumentált függvénykészlet csak az alábbiakra korlátozódik. Ne feltételezze, hogy tetszőleges Excel‑függvényt újraszámol a [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) metódus.

| Függvény | Cél vagy támogatott forma | Példa |
|---|---|---|
| `ABS` | Abszolút érték | `ABS(A2)` |
| `AVERAGE` | Aritmetikai közép | `AVERAGE(B2:B5)` |
| `CEILING` | Felfelé kerekítés egy többszörösre | `CEILING(A2,5)` |
| `CHOOSE` | Érték kiválasztása index alapján | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Szövegek összefűzése | `CONCAT(A2,B2)` |
| `CONCATENATE` | Szövegek összefűzése | `CONCATENATE(A2," ",B2)` |
| `DATE` | Dátumérték létrehozása a 1900-as dátumrendszerrel | `DATE(2026,8,19)` |
| `DAYS` | Napok száma két dátum között | `DAYS(B2,A2)` |
| `FIND` | Szövegrész keresése egy másikban | `FIND("-",A2)` |
| `FINDB` | Byte‑orientált szövegkeresés | `FINDB("a",A2)` |
| `IF` | Feltételes eredmény | `IF(A2>0,A2,0)` |
| `INDEX` | Referencia forma | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektor forma | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektor forma | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximális érték | `MAX(B2:B5)` |
| `SUM` | Összeg | `SUM(B2:B5)` |
| `VLOOKUP` | Függőleges keresés | `VLOOKUP(A2,B2:D10,3,FALSE)` |

A táblázatban szereplő korlátozások jelentősek: az `INDEX` referencia formában van dokumentálva, míg a `LOOKUP` és `MATCH` vektor formában. A `DATE` a 1900-as dátumrendszert használja. A nem felsorolt funkciókat az Aspose.Slides képletértékelője nem támogatja, kivéve ha külön dokumentálva vannak.

## **Képletek számítása preferált kultúrával**

Egyes munkafüzet‑függvények a szöveget kultúraspecifikus szabályok szerint értelmezik. Ez különösen fontos a kétsávos karakterkészletet (DBCS) használó nyelvek esetén. Az ilyen képletek helyes számításához hozza létre a [LoadOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/) objektumot, állítsa be a preferált kultúrát a [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/spreadsheetoptions/#setPreferredCulture) metódussal, adja át a táblázat‑opciókat a [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/#setSpreadsheetOptions) metódussal, majd töltse be a prezentációt.

Az alábbi példa japán kultúrát választ, megnyit egy prezentációt a konfigurált betöltési opciókkal, és minden diagram munkafüzethez meghívja a [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) metódust:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const japaneseCulture = java.newInstanceSync("java.util.Locale", "ja", "JP");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setPreferredCulture(japaneseCulture);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        const shapes = slides.get_Item(slideIndex).getShapes();
        for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
            const shape = shapes.get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
                shape.getChartData().getChartDataWorkbook().calculateFormulas();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

A preferált kultúra a prezentáció betöltési konfigurációjának része, ezért a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) példány létrehozása előtt adja meg. A munkafüzet‑képletek által elvárt kultúrát használja; például a japán DBCS számítási szabályokat követő képletekhez a `ja-JP` kultúrát adja meg.

## **Újraszámítás és gyorsítótárazott értékek**

A táblázatfájlok gyakran tárolják a képletet és annak legutóbb számított értékét is. Az Aspose.Slides ezért a [ChartDataCell.getValue](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatacell/#getValue--) metódussal is ki tud olvasni egy gyorsítótárazott értéket, amikor a prezentáció betöltődik, és a diagramadatok nem változtak.

Bemeneti cellák vagy képletek módosítása után ne bízzon egy régi gyorsítótárazott eredményben. Hívja meg a [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) metódust, mielőtt a kiszámított értékeket olvasná vagy olyan diagramadatot mentene, amely ezekre támaszkodik.

A nem támogatott képletek esetén az Aspose.Slides előfordulhat, hogy nem tudja értelmezni a képletet vagy annak függőségeit. Ha a munkafüzet módosult, a korábbi gyorsítótárazott érték már nem tekinthető megbízhatónak. Ilyen helyzetben egy nem támogatott adattal rendelkező cella kiolvasása a [CellUnsupportedDataException](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/cellunsupporteddataexception/) kivételt válthatja ki.

Ha diagramja olyan Excel‑függvényeket használ, amelyeket az Aspose.Slides nem számol ki, számolja ki ezeket a képleteket egy olyan táblázatmotorral, amely támogatja őket, majd írja vissza a kapott értékeket a diagram munkafüzetébe. Ne helyettesítse a nem támogatott képleteket tippelt értékekkel.

## **Képlethibák kezelése**

Két különböző problémafajtát kell megkülönböztetni.

Egy képlet lehet érvényes, de táblázathiba eredményt ad, például `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` vagy `#VALUE!`. Ebben az esetben a hibajelent a cella eredménye, és a [ChartDataCell.getValue](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatacell/#getValue--) metódussal adható vissza.

Egy képlet a feldolgozás, hivatkozás, függőség vagy támogatott adat szintjén is hibát eredményezhet. Az Aspose.Slides ezekre a helyzetekre táblázatspecifikus kivételeket biztosít: [CellInvalidFormulaException](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/cellcircularreferenceexception/) és [CellUnsupportedDataException](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/cellunsupporteddataexception/).

Sablonokból vagy felhasználói bemenetből származó képletek esetén fogjon hibákat az újraszámítás és az értékelérés körül. A hiba részletei az alapszakasz táblázati problémáját azonosítják:

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

## **Gyakorlati korlátok**

A diagram munkalapokban nyújtott képlet‑támogatás egy meghatározott részhalmazra van tervezve, és nem biztosít teljes Excel‑kompatibilitást. Tartsa szem előtt ezeket a korlátozásokat a jelentéskészítési munkafolyamatok tervezésekor:

- Csak a dokumentált állandókat, operátorokat, hivatkozásokat és függvényeket használja, ha azt szeretné, hogy az Aspose.Slides újraszámolja a képleteket.
- Számolja újra a munkafüzetet a képlet‑eredményektől függő cellák módosítása után.
- Tekintse a betöltött prezentációkból származó gyorsítótárazott értékeket pillanatfelvételeknek, ne pedig az utólagos szerkesztés utáni újraszámítás helyettesítőjének.
- Tesztelje a meglévő sablonokból származó képleteket, mielőtt a kiszámított értékekre támaszkodna, különösen akkor, ha olyan függvényeket használnak, amelyek nincsenek a dokumentált listában.
- Azokhoz a képletekhez, amelyek teljes táblázat‑számítási motorra van szükségük, végezze el a számítást külsőleg, majd frissítse a diagram munkafüzetet a kapott értékekkel.

## **GYIK**

**Mi a különbség a [ChartDataCell.setFormula](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) és a [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) között?**

[ChartDataCell.setFormula](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) A1‑stílusú kifejezést, például `B2-C2` tárol. [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) R1C1‑stílusú kifejezést, például `RC[-2]-RC[-1]` tárol. Használja azt a jelölést, amelyik jobban illeszkedik a képletek létrehozásához vagy másolásához.

**A számítás után olvasnom kell a cellát vagy az értékét?**

[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdataworkbook/#getCell-int-java.lang.String-) egy [ChartDataCell](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatacell/) objektumot ad vissza. A kiszámított eredményhez hívja meg ennek a cellának a [ChartDataCell.getValue](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatacell/#getValue--) metódusát újraszámítás után.

**Mikor kell meghívni a [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) metódust?**

Hívja meg a [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) metódust a bemeneti értékek vagy képletek módosítása után, és mielőtt a kiszámított eredményeket felhasználná. Ez frissíti a beépített értékelő által támogatott képletek értékeit.

**Az Aspose.Slides támogat minden Excel‑függvényt?**

Nem. A beépített értékelő csak egy dokumentált függvény‑részhalmazt támogat. A részhalmazon kívül eső függvényekre ne számítson, hogy helyesen újraszámolódnak. Ha teljes Excel‑képlet‑kompatibilitásra van szükség, végezze el a számítást egy megfelelő táblázat‑motorral, és írja a végső értékeket a diagram munkafüzetbe.

**Mi történik, ha egy betöltött prezentáció nem támogatott képletet tartalmaz?**

Ha a diagramadatok nem változtak, a munkafüzet még tartalmazhat egy korábban kiszámolt gyorsítótárazott értéket. A kapcsolódó adatok módosítása után ez a gyorsítótárazott érték már nem lehet érvényes. Egy olyan cella elérése, amelynek képletét nem tudja kezelni, a [CellUnsupportedDataException](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/cellunsupporteddataexception/) kivételt váltja ki.

**Ugyanazok-e a képlet‑hibaértékek és a kivételek?**

Nem. A `#DIV/0!`‑hez hasonló eredmény egy táblázatérték, amely egy érvényes számításból származik. A [CellInvalidFormulaException](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/cellinvalidformulaexception/) vagy [CellCircularReferenceException](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/cellcircularreferenceexception/) kivételek azt jelzik, hogy a képletet nem lehet normál módon feldolgozni.

**A diagram automatikusan frissül, ha egy képlet‑cellát módosítanak?**

Egy diagram sorozata hivatkozhat munkafüzet‑cellákra. Először számolja újra a munkafüzetet, majd mentse vagy renderelje a prezentációt. Ha a diagram adatpontjai a kiszámított cellákra hivatkoznak, a diagram az ezekkel frissített értékeket használja; nincs szükség külön diagram‑frissítési metódusra ebben a munkafolyamatban.

**Használhatók külső Excel‑munkafüzetek diagramokhoz?**

Igen, a diagramadatok konfigurálhatók úgy, hogy egy külső munkafüzetet használjanak a diagramadat‑API‑n keresztül. Azonban a jelen cikkben leírt képlet‑számítási munkafolyamat a diagram adat‑munkafüzetre és az Aspose.Slides által kiértékelt képlet‑részhalmazra vonatkozik. Ne feltételezze, hogy a [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) teljes újraszámítást végez tetszőleges képleteken egy külső XLSX fájlban.

**Használhatók olyan képletek, amelyek más munkalapra vagy munkafüzetre hivatkoznak?**

Excel‑stílusú hivatkozások előfordulhatnak diagram munkafüzetekben, de a képletszámítás a támogatott elemző és függvénykészlet által korlátozott. Ha egy kereszt‑lap vagy külső hivatkozás elengedhetetlen, ellenőrizze, hogy a pontos képlet működik‑e a cél Aspose.Slides verziójával. Széles körű Excel‑hivatkozási kompatibilitást igénylő munkafolyamatokhoz számolja ki a munkafüzetet külsőleg, és írja vissza a feloldott értékeket a diagram adatba.

**Kell‑e egy képletszövegnek `=` jellel kezdődnie?**

Az Aspose.Slides API‑példák a `B2-C2` vagy `SUM(B2:B5)` kifejezéseket vezeték‑karakter nélkül adják meg. Ilyen formát használva a generált képletek összhangban lesznek a dokumentált API‑példákkal.