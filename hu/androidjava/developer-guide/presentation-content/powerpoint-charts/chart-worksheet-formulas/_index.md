---
title: "Diagram munkalap képletek alkalmazása Androidon bemutatókban"
linktitle: "Munkalap képletek"
type: docs
weight: 70
url: /hu/androidjava/chart-worksheet-formulas/
keywords:
- diagram táblázat
- diagram munkalap
- diagram képlet
- munkalap képlet
- táblázat képlet
- diagram adat munkafüzet
- képlet számítás
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
- Android
- Java
- Aspose.Slides
description: "Excel-stílusú képletek alkalmazása Aspose.Slides for Android via Java diagram munkalapokon, újraszámolja az értékeket, és felhasználja az eredményeket PowerPoint diagramokban."
---
## **Áttekintés**

A PowerPoint-diagramok általában a forrásadataikat egy beágyazott munkalapon tárolják. Az Aspose.Slides for Android via Java segítségével a diagram adatkönyvtárán keresztül elérheti ezt a munkalapot, írhat bemeneti értékeket, hozzárendelhet képleteket a cellákhoz, kiszámíthatja a támogatott képleteket, és felhasználhatja a kiszámított cellákat diagramadatként.

Ez a cikk a teljes képletszemléltetési munkafolyamatot mutatja be: diagram létrehozása, a munkalap feltöltése, A1‑stílusú vagy R1C1‑stílusú képletek hozzárendelése, újraszámítása, a kiszámított értékek olvasása, a cellák csatlakoztatása diagramsorozathoz, és a bemutató mentése. Leírja a támogatott képletszintaxist, a beépített függvények részhalmazát, a gyorsítótárazott értékeket, a nem támogatott képleteket és a táblázat-specifikus hibákat.

## **Diagram munkalapok és képletek**

Egy diagram munkalapja tartalmazza a diagram által használt kategóriákat, sorozatneveket és értékeket. PowerPointban megtekintheti a munkalapot a diagram adat szerkesztő megnyitásával:

![PowerPoint-diagram az beágyazott munkalappal nyitva, a kategória- és sorozatadatok megjelenítése](chart-worksheet-formulas_1.png)

Az Aspose.Slidesben a munkalap a [IChartDataWorkbook](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdataworkbook/) felületen keresztül érhető el. Használja a [IChartDataCell.setFormula](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) metódust A1‑stílusú képletekhez és a [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) metódust R1C1‑stílusú képletekhez. A bemeneti cellák vagy képletek módosítása után hívja meg a [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) metódust a támogatott képletek újraszámításához és a megfelelő cellaértékek frissítéséhez.

Egy kiszámított cella továbbra is az eredményét a [IChartDataCell.getValue](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatacell/#getValue--) metódussal adja vissza. Ez fontos, ha kódban kell ellenőriznie egy képlet eredményét vagy a cellát diagramadatpontként szeretné használni.

## **Diagram létrehozása és a munkalap képleteinek kiszámítása**

Az alábbi példa egy végponttól végpontig tartó munkafolyamatot mutat be. Létrehoz egy klaszterelt oszlopdiagramot, törli a mintaadatokat, beírja a negyedéves bevétel és kiadás értékeket, képletekkel számolja ki a profitot, beolvassa az eredményeket, a kiszámított cellákat diagramértékekként használja, és menti a bemutatót.

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

A diagram adatpontjai a `D2:D4` tartományra hivatkoznak, így a diagram a kiszámított profitértékeket használja. Ebben a munkafolyamatban nincs külön diagramfrissítő hívás: először számolja újra a munkafüzetet, majd használja vagy mentse a diagramadatokat, amelyek a kiszámított cellákra mutatnak.

## **A1‑stílusú képletek használata**

Az A1 jelölés a oszlopokat betűkkel, a sorokat számokkal azonosítja. A A1‑stílusú kifejezéseket a [IChartDataCell.setFormula](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) metódussal rendelheti hozzá.

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

A gyakori A1 hivatkozási formák a következők:

| Hivatkozás | Relatív | Abszolút | Vegyes |
|---|---|---|---|
| Cell | `A2` | `$A$2` | `A$2`, `$A2` |
| Row | `2:2` | `$2:$2` | — |
| Column | `A:A` | `$A:$A` | — |
| Range | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

A relatív hivatkozások megváltozhatnak, amikor egy képletet egy táblázatkezelő alkalmazás mozgat vagy másol. Az abszolút hivatkozások mindkét koordinátát rögzítik, míg a vegyes hivatkozások csak egy sort vagy egy oszlopot rögzítenek.

## **R1C1‑stílusú képletek használata**

Az R1C1 jelölés a sorokat és oszlopokat számokkal azonosítja. A relatív hivatkozások négyzetes zárójelekben megadott eltolásokat használnak. Ezt a szintaxist a [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) metódussal adhatja meg.

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

A gyakori R1C1 hivatkozási formák a következők:

| Hivatkozás | Relatív | Abszolút | Vegyes |
|---|---|---|---|
| Cell | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Row | `R[2]` | `R2` | — |
| Column | `C[3]` | `C3` | — |
| Range | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Például a `D2` cellában az `RC[-2]` a ugyanabban a sorban két oszloppal balra lévő cellát jelenti (`B2`).

## **Képletsz constantok és operátorok**

A beépített képletértékelő logikai értékeket, numerikus literálokat, karakterláncokat, táblázat-hibákat, aritmetikai operátorokat és összehasonlító operátorokat támogat.

### **Constantok és literálok**

| Típus | Példák | Megjegyzés |
|---|---|---|
| Logical | `TRUE`, `FALSE` | Közvetlenül használható logikai kifejezésekben, például `A2=TRUE`. |
| Numeric | `1`, `0.5`, `.3`, `1E-2` | A közönséges és a tudományos jelölés is támogatott. |
| String | `"abc"`, `"2/3/2020 12:00"` | A szövegliterálok a képleten belül dupla idézőjelek közé kerülnek. |
| Error result | `#DIV/0!`, `#N/A`, `#REF!` | Egy érvényes képlet kiértékelése táblázat-hibaértékkel is végezhető a normál eredmény helyett. |

Ez a példa több constant típust is használ:

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

    Object logicalValue = workbook.getCell(0, "B2").getValue(); // hamis
    Object numericValue = workbook.getCell(0, "C2").getValue(); // 1.5
    Object scientificValue = workbook.getCell(0, "D2").getValue(); // 0.003
    Object stringValue = workbook.getCell(0, "E2").getValue(); // abc
    Object errorValue = workbook.getCell(0, "F2").getValue(); // #DIV/0!
} finally {
    presentation.dispose();
}
```

### **Aritmetikai operátorok**

| Operátor | Jelentés | Példa |
|---|---|---|
| `+` | Összeadás vagy egyéb pozitív előjel | `2+3` |
| `-` | Kivonás vagy negáció | `2-3`, `-3` |
| `*` | Szorzás | `2*3` |
| `/` | Osztás | `2/3` |
| `%` | Százalék | `30%` |
| `^` | Hatványozás | `2^3` |

A kiértékelési sorrend egyértelművé tételéhez használjon zárójeleket, például `(A2+B2)*C2`.

### **Összehasonlító operátorok**

Az összehasonlító kifejezések logikai értéket adnak vissza.

| Operátor | Jelentés | Példa |
|---|---|---|
| `=` | Egyenlő | `A2=3` |
| `<>` | Nem egyenlő | `A2<>3` |
| `>` | Nagyobb mint | `A2>3` |
| `>=` | Nagyobb vagy egyenlő | `A2>=3` |
| `<` | Kisebb mint | `A2<3` |
| `<=` | Kisebb vagy egyenlő | `A2<=3` |

## **Támogatott előre definiált függvények**

Az Aspose.Slides beépített képletértékelővel rendelkezik diagrammunkalapokhoz, de nem egy teljes Excel számítási motor. A dokumentált függvénykészlet a lenti függvényekre korlátozódik. Ne feltételezze, hogy bármely Excel‑függvény újraszámítható a [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) metódussal.

| Függvény | Cél vagy támogatott forma | Példa |
|---|---|---|
| `ABS` | Abszolút érték | `ABS(A2)` |
| `AVERAGE` | Számított átlag | `AVERAGE(B2:B5)` |
| `CEILING` | Felfelé kerekítés többszörösre | `CEILING(A2,5)` |
| `CHOOSE` | Érték kiválasztása index alapján | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Szövegek összefűzése | `CONCAT(A2,B2)` |
| `CONCATENATE` | Szövegek összefűzése | `CONCATENATE(A2," ",B2)` |
| `DATE` | Dátum érték létrehozása a 1900-as dátumrendszerrel | `DATE(2026,8,19)` |
| `DAYS` | Napok számának visszaadása dátumok között | `DAYS(B2,A2)` |
| `FIND` | Szövegrész keresése egy másikban | `FIND("-",A2)` |
| `FINDB` | Byte‑orientált szövegkeresés | `FINDB("a",A2)` |
| `IF` | Feltételes eredmény | `IF(A2>0,A2,0)` |
| `INDEX` | Referencia forma | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektor forma | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektor forma | `MATCH(A2,B2:B5,0)` |
| `MAX` | Legnagyobb érték | `MAX(B2:B5)` |
| `SUM` | Értékek összeadása | `SUM(B2:B5)` |
| `VLOOKUP` | Függőleges keresés | `VLOOKUP(A2,B2:D10,3,FALSE)` |

A táblázatban feltüntetett korlátozások jelentősek: az `INDEX` referencia formában van dokumentálva, míg a `LOOKUP` és a `MATCH` vektor formában. A `DATE` a 1900‑as dátumrendszert használja. A itt nem felsorolt funkciók és jellemzők az Aspose.Slides képletértékelő számára nem támogatottak, hacsak külön nincsenek dokumentálva.

## **Újraszámítás és gyorsítótárazott értékek**

A táblázatfájlok gyakran tárolják a képletet és az utolsó kiszámított értékét is. Az Aspose.Slides ezért képes a [IChartDataCell.getValue](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatacell/#getValue--) metódussal a gyorsítótárazott értéket kiolvasni, amikor egy bemutatót betöltenek, és a megfelelő diagramadatok nem változtak.

A bemeneti cellák vagy képletek módosítása után ne támaszkodjon a régi gyorsítótárazott eredményre. Hívja meg a [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) metódust a kiszámított értékek olvasása vagy a diagramadatok mentése előtt, amelyek ezekre támaszkodnak.

A támogatott részhalmazon kívüli képletek esetén az Aspose.Slides előfordulhat, hogy nem tudja értelmezni a képletet vagy annak függőségeit. Ha a munkafüzet módosult, a korábbi gyorsítótárazott érték már nem tekinthető megbízhatónak. Ilyen helyzetben egy nem támogatott adatokkal rendelkező cella értékének olvasása [CellUnsupportedDataException](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/cellunsupporteddataexception/) kivételt dobhat.

Ha diagramja olyan Excel‑függvényeket használ, amelyeket az Aspose.Slides nem értékel, számítsa ki ezeket a képleteket egy olyan táblázatmotorral, amely támogatja őket, majd írja vissza az eredményeket a diagram munkafüzetébe. Ne helyettesítse a nem támogatott képleteket tippelt értékekkel.

## **Képlet hibák kezelése**

Két különböző problématípust kell megkülönböztetni.

Egy képlet érvényes lehet, de táblázat‑hibát eredményezhet, például `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` vagy `#VALUE!`. Ilyenkor a hiba‑token egy cella eredménye, és a [IChartDataCell.getValue](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatacell/#getValue--) metóduson keresztül adható vissza.

Egy képlet a feldolgozás, hivatkozás, függőség vagy a támogatott‑adat szintjén is hibát okozhat. Az Aspose.Slides ezekhez a helyzetekhez táblázat‑specifikus kivételeket biztosít: [CellInvalidFormulaException](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/cellcircularreferenceexception/), és [CellUnsupportedDataException](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/cellunsupporteddataexception/).

Amikor a képletek sablonokból vagy felhasználói bemenetből származnak, kezelje ezeket a kivételeket az újraszámítás és az értéklekérés körül:

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

## **Gyakorlati korlátozások**

A diagram munkalapok képlet‑támogatása egy meghatározott, a teljes Excel‑kompatibilitáson túlmutató részhalmazra épül. Tartsa szem előtt ezeket a korlátokat a jelentéskészítési munkafolyamat tervezésekor:

- Csak a dokumentált constantokat, operátorokat, hivatkozásokat és függvényeket használja, ha azt szeretné, hogy az Aspose.Slides újraszámolja a képleteket.
- Újraszámítás a képlet‑eredményekre ható cellák módosítása után.
- A betöltött bemutatókból származó gyorsítótárazott értékek pillanatfelvételt jelentenek, nem helyettesítik az újraszámítást szerkesztés után.
- Tesztelje a meglévő sablonokból származó képleteket, mielőtt a kiszámított értékekre támaszkodna, különösen, ha azok a dokumentált listán kívüli függvényeket használnak.
- A teljes táblázat‑számítási motorra szoruló képleteket számítsa ki külsőleg, majd frissítse a diagram munkafüzetét a kapott értékekkel.

## **GYIK**

**Mi a különbség a [IChartDataCell.setFormula](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) és a [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) között?**

[IChartDataCell.setFormula](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) A1‑stílusú kifejezést tárol, például `B2-C2`. [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) R1C1‑stílusú kifejezést tárol, például `RC[-2]-RC[-1]`. Válassza azt a jelölést, amelyik a legjobban illik a képletek generálásához vagy másolásához.

**Olvasnom kell a cellát vagy az értékét a számítás után?**

[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-java.lang.String-) egy [IChartDataCell](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatacell/) objektumot ad vissza. A kiszámított eredmény eléréséhez a cella [IChartDataCell.getValue](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatacell/#getValue--) metódusát kell meghívni az újraszámítás után.

**Mikor kell meghívni a [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) metódust?**

Hívja meg a [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) metódust a bemeneti értékek vagy képletek módosítása után, és még az előtt, hogy a kiszámított eredményekre támaszkodna. Ez frissíti a beépített értékelő által támogatott képletek értékeit.

**Támogatja az Aspose.Slides minden Excel‑függvényt?**

Nem. A beépített értékelő egy dokumentált részhalmazt támogat. A részhalmazon kívüli függvények nem számíthatók újra. Ha teljes Excel‑képlet‑kompatibilitásra van szükség, végezze el a számítást egy megfelelő táblázatmotorral, és írja a végső értékeket a diagram munkafüzetébe.

**Mi történik, ha egy betöltött bemutató nem támogatott képletet tartalmaz?**

Ha a diagram adat nem változott, a munkafüzetben továbbra is lehet egy korábban kiszámított gyorsítótárazott érték. A kapcsolódó adatok módosítása után ez az érték már nem biztos, hogy érvényes. Egy olyan cella elérése, amelynek képletét nem tudja kezelni a rendszer, [CellUnsupportedDataException](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/cellunsupporteddataexception/) kivételt okozhat.

**Ugyanazok a képlet‑hibák, mint a Java‑kivétel?**

Nem. A `#DIV/0!`‑hez hasonló eredmény egy táblázat‑érték, amely egy érvényes számításból származik. A [CellInvalidFormulaException](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/cellinvalidformulaexception/) vagy a [CellCircularReferenceException](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/cellcircularreferenceexception/) kivételek azt jelzik, hogy a képletet nem lehet normál módon feldolgozni.

**A diagram automatikusan frissül, ha egy képlet‑cellát módosítanak?**

A diagram sorozata hivatkozhat a munkafüzet celláira. Először számolja újra a munkafüzetet, majd mentse vagy renderelje a bemutatót. Ha a diagram adatpontjai a kiszámított cellákra hivatkoznak, a diagram a frissített értékeket használja; nincs szükség külön diagram‑frissítő metódusra ebben a munkafolyamatban.

**A diagram használhat külső Excel‑munkafüzetet?**

Igen, a diagram adat konfigurálható külső munkafüzet használatára a diagram adat‑API‑n keresztül. Azonban a jelen cikkben leírt képletszámítási munkafolyamat a diagram adat‑munkafüzetére és az Aspose.Slides által kiértékelt képlet‑részhalmazra vonatkozik. Ne feltételezze, hogy a [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) teljes újraszámítást biztosít tetszőleges képletekre egy külső XLSX‑fájlban.

**Használhatok képleteket, amelyek más munkalapra vagy munkafüzetre hivatkoznak?**

Az Excel‑stílusú hivatkozások előfordulhatnak a diagram munkafüzetekben, de a képlet‑értékelés korlátozott a támogatott elemző és függvénykészlet által. Ha egy kereszt‑lap vagy külső hivatkozás elengedhetetlen, ellenőrizze a pontos képletet a használt Aspose.Slides verzióval. Széles körű Excel‑hivatkozási kompatibilitást igénylő munkafolyamatokhoz számítsa ki a munkafüzetet külsőleg, és írja vissza a feloldott értékeket a diagram adatba.

**A képlet‑sztringeknek kell `=` jellel kezdődniük?**

Az Aspose.Slides API példái úgy adják meg a kifejezéseket, mint `B2-C2` vagy `SUM(B2:B5)` vezető `=` jel nélkül. Ezzel a formával a generált képletek összhangban vannak a dokumentált API‑példákkal.