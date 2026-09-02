---
title: Diagram munkalap képletek alkalmazása prezentációkban JavaScript segítségével
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
- diagram adat munkafüzet
- képlet számítás
- logikai konstans
- numerikus konstans
- karakterlánc konstans
- hiba konstans
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
description: "Alkalmazzon Excel-stílusú képleteket az Aspose.Slides for Node.js Java diagram munkalapokon, újraszámolja az értékeket, és használja az eredményeket a PowerPoint diagramokban."
---
## **Áttekintés**

A PowerPoint-diagramok általában a forrásadataikat egy beágyazott munkalapon tárolják. Az Aspose.Slides for Node.js via Java segítségével elérhetjük ezt a munkalapot a diagramadatok munkafüzete (ChartDataWorkbook) révén, beírhatunk bemeneti értékeket, képleteket adhatunk celláknak, kiszámíthatjuk a támogatott képleteket, és a kiszámított cellákat diagramadatként használhatjuk.

Ez a cikk részletesen bemutatja a képlet-munkafolyamatot: diagram létrehozása, a munkalap feltöltése, A1- vagy R1C1-stílusú képletek hozzárendelése, azok újraszámítása, a kiszámított értékek olvasása, a cellák diagram sorozathoz kapcsolása, és a prezentáció mentése. Emellett leírja a támogatott képletszintaxist, a beépített függvényrészhalmazt, a gyorsítótárazott értékeket, a nem támogatott képleteket és a táblázat-specifikus hibákat.

## **Diagram munkalapok és képletek**

Egy diagram munkalap tartalmazza a kategóriákat, sorozatneveket és értékeket, amelyeket a diagram használ. PowerPointban megtekinthetjük a munkalapot a diagramadat-szerkesztő megnyitásával:

![PowerPoint-diagram, amelynek beágyazott munkalapja nyitva van, a kategória- és sorozatadatokat mutatja](chart-worksheet-formulas_1.png)

Az Aspose.Slides-ban a munkalap a [ChartDataWorkbook](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdataworkbook/) osztályon keresztül érhető el. A1-stílusú képletekhez a [ChartDataCell.setFormula](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) metódust, R1C1-stílusú képletekhez a [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) metódust használjuk. A bemeneti cellák vagy képletek módosítása után hívja meg a [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) metódust a támogatott képletek újbóli számításához és a megfelelő cellaértékek frissítéséhez.

Egy kiszámított cella továbbra is a [ChartDataCell.getValue](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatacell/#getValue--) metódussal adja vissza az eredményét. Ez akkor fontos, amikor a kódban kell megvizsgálni egy képlet eredményét, vagy a cellát diagramadat-pontként használni.

## **Diagram létrehozása és a munkalap képleteinek kiszámítása**

A következő példa egy teljes munkafolyamatot mutat be. Létrehoz egy csoportosított oszlopdiagramot, törli a mintaadatokat, beírja a negyedéves bevétel és költség értékeket, képletekkel számolja ki a profitot, olvassa az eredményeket, a kiszámított cellákat diagramértékekként használja, és menti a prezentációt.

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

A diagram adatpontjai a `D2:D4` tartományra hivatkoznak, ezért a diagram a kiszámított profit értékeket használja. Ebben a munkafolyamatban nincs külön chart-refresh hívás: először újraszámolja a munkafüzetet, majd használja vagy menti a diagram adatokat, amelyek a kiszámított cellákra mutatnak.

## **A1-stílusú képletek használata**

Az A1 jelölés oszlopokat betűkkel, sorokat számokkal azonosít. A1-stílusú kifejezéseket a [ChartDataCell.setFormula](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) metódussal rendelhetjük.

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

A relatív hivatkozások megváltozhatnak, ha egy képletet egy táblázatkezelő mozgat vagy másol. Az abszolút hivatkozások mindkét koordinátát rögzítik, míg a vegyes hivatkozások csak sorra vagy oszlopra rögzítenek.

## **R1C1-stílusú képletek használata**

Az R1C1 jelölés sorokat és oszlopokat számmal azonosít. A relatív hivatkozások négyzetes zárójelben lévő eltolásokat használnak. Ezt a szintaxist a [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) metódussal adhatjuk meg.

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

Például a `D2` cellában a `RC[-2]` azt jelenti, hogy az ugyanabban a sorban két oszloppal balra lévő cella (`B2`).

## **Képletkonstansok és operátorok**

A beépített képletelemző támogatja a logikai értékeket, numerikus literálokat, karakterláncokat, táblázat-hibákat, aritmetikai operátorokat és összehasonlító operátorokat.

### **Konstansok és literálok**

| Típus | Példák | Megjegyzés |
|---|---|---|
| Logikai | `TRUE`, `FALSE` | Logikai kifejezésekben használható közvetlenül, például `A2=TRUE`. |
| Numerikus | `1`, `0.5`, `.3`, `1E-2` | A közönséges és tudományos jelölés támogatott. |
| Sztring | `"abc"`, `"2/3/2020 12:00"` | A szövegliterálok dupla idézőjelben szerepelnek a képleten belül. |
| Hiba eredmény | `#DIV/0!`, `#N/A`, `#REF!` | Egy érvényes képlet ki is értékelhet táblázat-hiba értéket a normál eredmény helyett. |

Ez a példa több konstans típust használ:

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
| `+` | Összeadás vagy unáris plusz | `2+3` |
| `-` | Kivonás vagy negáció | `2-3`, `-3` |
| `*` | Szorzás | `2*3` |
| `/` | Osztás | `2/3` |
| `%` | Százalék | `30%` |
| `^` | Hatványozás | `2^3` |

Zárójeleket használjon a kiértékelési sorrend egyértelművé tételéhez, például `(A2+B2)*C2`.

### **Összehasonlító operátorok**

| Operátor | Jelentés | Példa |
|---|---|---|
| `=` | Egyenlő | `A2=3` |
| `<>` | Nem egyenlő | `A2<>3` |
| `>` | Nagyobb mint | `A2>3` |
| `>=` | Nagyobb vagy egyenlő | `A2>=3` |
| `<` | Kisebb mint | `A2<3` |
| `<=` | Kisebb vagy egyenlő | `A2<=3` |

## **Támogatott előre definiált függvények**

Az Aspose.Slides beépített képletelemzőt tartalmaz a diagram munkalapokhoz, de nem egy teljes Excel számítási motor. A dokumentált függvénykészlet csak az alábbi függvényekre korlátozódik. Ne feltételezzük, hogy egy tetszőleges Excel függvény újraszámolható a [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) metódussal.

| Függvény | Cél vagy támogatott forma | Példa |
|---|---|---|
| `ABS` | Abszolút érték | `ABS(A2)` |
| `AVERAGE` | Aritmetikai átlag | `AVERAGE(B2:B5)` |
| `CEILING` | Kerekít felfelé egy többszörösre | `CEILING(A2,5)` |
| `CHOOSE` | Érték kiválasztása index szerint | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Szöveges értékek összefűzése | `CONCAT(A2,B2)` |
| `CONCATENATE` | Szöveges értékek összefűzése | `CONCATENATE(A2," ",B2)` |
| `DATE` | Dátumérték létrehozása a 1900-as dátumrendszerrel | `DATE(2026,8,19)` |
| `DAYS` | Két dátum közti napok száma visszaadása | `DAYS(B2,A2)` |
| `FIND` | Szöveg keresése egy másik szövegben | `FIND("-",A2)` |
| `FINDB` | Byte-orientált szöveg keresés | `FINDB("a",A2)` |
| `IF` | Feltételes eredmény | `IF(A2>0,A2,0)` |
| `INDEX` | Referencias forma | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektor forma | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektor forma | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximum érték | `MAX(B2:B5)` |
| `SUM` | Összeg | `SUM(B2:B5)` |
| `VLOOKUP` | Vertikális keresés | `VLOOKUP(A2,B2:D10,3,FALSE)` |

A táblázatban szereplő korlátozások jelentősek: az `INDEX` referencia formában van dokumentálva, míg a `LOOKUP` és `MATCH` vektor formában. A `DATE` a 1900-as dátumrendszert használja. Az itt nem felsorolt funkciók és jellemzők az Aspose.Slides képletelemző által nem támogatottak, hacsak nincsenek külön dokumentálva.

## **Újraszámítás és gyorsítótárazott értékek**

A táblázatfájlok általában tárolják a képletet és az utolsó kiszámított értéket is. Az Aspose.Slides ezért a [ChartDataCell.getValue](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatacell/#getValue--) metódussal gyorsítótárazott értéket olvashat be, amikor a prezentáció betöltődik, és a releváns diagramadatok nem változtak.

A bemeneti cellák vagy képletek módosítása után ne támaszkodjon a régi gyorsítótárazott eredményre. Hívja meg a [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) metódust a kiszámított értékek olvasása vagy a diagramadat mentése előtt, amely ezekre támaszkodik.

A támogatott részhalmazon kívül eső képletek esetén az Aspose.Slides nem képes lehet a képlet értelmezésére vagy a függőségek felállítására. Ha a munkafüzet módosult, a korábbi gyorsítótárazott érték már nem tekinthető megbízhatónak. Ilyen helyzetben egy nem támogatott adatú cella értékének olvasása [CellUnsupportedDataException](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/cellunsupporteddataexception/) kivételt okozhat.

Ha a diagram olyan Excel függvényektől függ, amelyeket az Aspose.Slides nem értékel, számítsa ki ezeket a képleteket egy olyan táblázatmotorral, amely támogatja őket, és írja vissza az eredményeket a diagram munkafüzetébe. Ne helyettesítse a nem támogatott képleteket tippelt értékekkel.

## **Képlet hibák kezelése**

Kétféle problémát kell megkülönböztetni.

Egy képlet lehet érvényes, de táblázat hibát eredményezhet, például `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` vagy `#VALUE!`. Ebben az esetben a hiba token cellaeredmény, és a [ChartDataCell.getValue](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatacell/#getValue--) metóduson keresztül visszakapható.

Egy képlet a feldolgozás, hivatkozás, függőség vagy a támogatott adat szintjén is hibát okozhat. Az Aspose.Slides ezekhez a helyzetekhez táblázat-specifikus kivételeket biztosít: [CellInvalidFormulaException](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/cellcircularreferenceexception/), és [CellUnsupportedDataException](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/cellunsupporteddataexception/).

Amikor a képletek sablonokból vagy felhasználói bemenetből származnak, a újraszámítás és az értéklekérés körül kezelje a hibákat. A hiba részletei az alapos táblázati problémát azonosítják:

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

## **Gyakorlati korlátozások**

A diagram munkalapok képlet-támogatása egy meghatározott részhalmazra vonatkozik a táblázatszámításokban, nem pedig teljes Excel kompatibilitásra. Tartsa észben ezeket a korlátokat jelentéskészítési munkafolyamat tervezésekor:

- Használjon csak a dokumentált konstansokat, operátorokat, hivatkozásokat és függvényeket, ha az Aspose.Slides-nak kell újraszámolnia a képleteket.
- Újraszámolás a képletek eredményeire ható cellák módosítása után.
- A betöltött prezentációk gyorsítótárazott értékeit pillanatfelvételként kezelje, nem pedig szerkesztés utáni újraszámolás helyettesítőjeként.
- Tesztelje a meglévő sablonok képleteit, mielőtt a kiszámított értékekre támaszkodna, különösen ha olyan függvényeket használnak, amelyek kívül esnek a dokumentált listán.
- Teljes táblázat számítási motorhoz szükséges képletek esetén számítsa ki őket külsőleg, majd frissítse a diagram munkafüzetet a kapott értékekkel.

## **GYIK**

**Mi a különbség a [ChartDataCell.setFormula] és a [ChartDataCell.setR1C1Formula] között?**

A [ChartDataCell.setFormula] A1-stílusú kifejezést tárol, például `B2-C2`. A [ChartDataCell.setR1C1Formula] R1C1-stílusú kifejezést tárol, például `RC[-2]-RC[-1]`. Használja azt a jelölést, amely legjobban illeszkedik a képletek generálásához vagy másolásához.

**Kell-e a cellát magát vagy az értékét olvasni a számítás után?**

A [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdataworkbook/#getCell-int-java.lang.String-) egy [ChartDataCell](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatacell/) objektumot ad vissza. A kiszámított eredményhez a cella [ChartDataCell.getValue](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatacell/#getValue--) metódusát kell meghívni a újraszámítás után.

**Mikor kell meghívni a [ChartDataWorkbook.calculateFormulas] metódust?**

Hívja meg a [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) metódust a bemeneti értékek vagy képletek módosítása után, és még az eredményekre való támaszkodás előtt. Ez frissíti a beépített értékelő által támogatott képletek értékeit.

**Támogatja az Aspose.Slides minden Excel függvényt?**

Nem. A beépített értékelő csak egy dokumentált részhalmaz függvényét támogatja. A részhalmazon kívüli függvényekről nem szabad azt feltételezni, hogy helyesen újraszámolhatók. Ha teljes Excel képletek kompatibilitása szükséges, végezze el a számítást egy megfelelő táblázatmotorral, és írja az eredményeket a diagram munkafüzetbe.

**Mi történik, ha egy betöltött prezentáció nem támogatott képletet tartalmaz?**

Ha a diagram adatai nem változtak, a munkafüzetben még lehet egy korábban kiszámított gyorsítótárazott érték. A kapcsolódó adatok módosítása után ez az érték már nem lehet érvényes. Egy olyan cella elérése, amelynek képlete nem kezelhető, [CellUnsupportedDataException](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/cellunsupporteddataexception/) kivételt eredményezhet.

**Ugyanazok a képlet-hiba értékek, mint a kivételek?**

Nem. A `#DIV/0!`-hez hasonló eredmény egy táblázati érték, amely egy érvényes számítás eredménye. Az olyan kivételek, mint a [CellInvalidFormulaException](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/cellinvalidformulaexception/) vagy a [CellCircularReferenceException](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/cellcircularreferenceexception/) azt jelzik, hogy a képletet nem lehet normál módon feldolgozni.

**Frissül a diagram automatikusan, ha egy képletcellát módosítanak?**

Egy diagram sorozat hivatkozhat a munkafüzet celláira. Először számítsa újra a munkafüzetet, majd mentse vagy renderelje a prezentációt. Ha a diagram adatpontjai a kiszámított cellákra hivatkoznak, a diagram ezeket a frissített cellaértékeket használja; a munkafolyamatban nincs szükség külön chart-refresh metódusra.

**Használhatnak a diagramok külső Excel munkafüzetet?**

Igen, a diagram adatokat be lehet állítani, hogy külső munkafüzetet használjanak a diagram adat API-n keresztül. Azonban ebben a cikkben leírt képletszámítási munkafolyamat a diagram adat munkafüzetre és az Aspose.Slides által kiértékelt képlet-részhalmazra vonatkozik. Ne feltételezzük, hogy a [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) teljes újraszámítást biztosít tetszőleges képletekre egy külső XLSX fájlban.

**Használhatok olyan képleteket, amelyek másik munkalapra vagy munkafüzetre hivatkoznak?**

Excel-stílusú hivatkozások előfordulhatnak a diagram munkafüzetekben, de a képlet kiértékelése a támogatott elemző és függvénykészlet miatt korlátozott. Ha egy kereszt-munkalap vagy külső hivatkozás elengedhetetlen, ellenőrizze az adott képletet a cél Aspose.Slides verzióval. Azokban a munkafolyamatokban, amelyek széleskörű Excel hivatkozási kompatibilitást igényelnek, számítsa ki a munkafüzetet külsőleg, és írja vissza a feloldott értékeket a diagram adatba.

**Kezdeni kell a képletsorokat `=` karakterrel?**

Az Aspose.Slides API példák kifejezéseket adnak meg, például `B2-C2` vagy `SUM(B2:B5)`, előzetes `=` karakter nélkül. Ennek a formának használata biztosítja, hogy a generált képletek egyeznek a dokumentált API példákkal.