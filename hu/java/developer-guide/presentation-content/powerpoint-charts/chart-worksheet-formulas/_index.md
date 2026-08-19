---
title: "Diagrammunkalap képletek alkalmazása prezentációkban Java-val"
linktitle: "Munkalap képletek"
type: docs
weight: 70
url: /hu/java/chart-worksheet-formulas/
keywords:
- "diagram táblázat"
- "diagram munkalap"
- "diagram képlet"
- "munkalap képlet"
- "táblázat képlet"
- "diagram adat munkafüzet"
- "képlet számítás"
- "logikai állandó"
- "numerikus állandó"
- "karakterlánc állandó"
- "hiba állandó"
- "aritmetikai operátor"
- "összehasonlító operátor"
- "A1 stílus"
- "R1C1 stílus"
- "előre definiált függvény"
- "PowerPoint"
- "prezentáció"
- "Java"
- "Aspose.Slides"
description: "Alkalmazza az Excel-stílusú képleteket az Aspose.Slides for Java diagrammunkalapokon, számolja újra az értékeket, és használja az eredményeket a PowerPoint diagramokon."
---
## **Áttekintés**

A PowerPoint-diagramok általában a forrásadatokat egy beágyazott munkalapban tárolják. Az Aspose.Slides for Java‑ban a diagramadat‑munkafüzeten keresztül érheti el ezt a munkalapot, írhat beviteli értékeket, rendelhet képleteket a cellákhoz, számíthatja ki a támogatott képleteket, és a számított cellákat diagramadatként használhatja.

Ez a cikk bemutatja a teljes képletszemléltetést: diagram létrehozása, munkalap feltöltése, A1‑ vagy R1C1‑stílusú képletek hozzárendelése, újraszámolásuk, a számított értékek beolvasása, ezeknek a celláknak a diagramsorozathoz csatolása, és a prezentáció mentése. Emellett ismerteti a támogatott képlet‑szintaxist, a beépített függvények részhalmazát, a gyorsítótárazott értékeket, a nem támogatott képleteket és a táblázat‑specifikus hibákat.

## **Diagram‑munkalapok és képletek**

Egy diagram‑munkalap tartalmazza a kategóriákat, sorozatneveket és értékeket, amelyeket egy diagram használ. PowerPointban a munkalapot a diagramadat‑szerkesztő megnyitásával tekintheti meg:

![PowerPoint-diagram a beágyazott munkalappal nyitva, kategória‑ és sorozatadatok megjelenítése](chart-worksheet-formulas_1.png)

Az Aspose.Slidesben a munkalap a [IChartDataWorkbook](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdataworkbook/) felületen keresztül érhető el. A1‑stílusú képletekhez használja a [IChartDataCell.setFormula](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) metódust, a R1C1‑stílusú képletekhez a [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) metódust. Bemeneti cellák vagy képletek módosítása után hívja meg a [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) metódust a támogatott képletek újraszámolásához és a megfelelő cellaértékek frissítéséhez.

Egy számított cella eredményét továbbra is a [IChartDataCell.getValue](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatacell/#getValue--) metódus adja vissza. Ez akkor fontos, amikor kódban kell a képlet eredményét megvizsgálni vagy a cellát diagramadat‑pontként használni.

## **Diagram létrehozása és a munkalap‑képletek számítása**

Az alábbi példa egy teljes munkafolyamatot mutat be. Létrehoz egy összevont oszlopdiagramot, törli a mintaadatokat, beírja a negyedéves bevételi és költségértékeket, képletekkel számítja ki a profitot, beolvassa az eredményeket, a számított cellákat diagramértékekként használja, és menti a prezentációt.

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

A diagram adatpontjai a `D2:D4` tartományra hivatkoznak, így a diagram a számított profitértékeket használja. Ebben a munkafolyamatban nincs külön diagram‑frissítési hívás: először számolja újra a munkafüzetet, majd használja vagy mentse a számított cellákra mutató diagramadatokat.

## **A1‑stílusú képletek használata**

Az A1 jelölés a oszlopokat betűkkel, a sorokat számokkal azonosítja. A A1‑stílusú kifejezéseket a [IChartDataCell.setFormula](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) metódussal adhatja meg.

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

A leggyakoribb A1 hivatkozási formák:

| Hivatkozás | Relatív | Abszolút | Vegyes |
|---|---|---|---|
| Cell | `A2` | `$A$2` | `A$2`, `$A2` |
| Sor | `2:2` | `$2:$2` | — |
| Oszlop | `A:A` | `$A:$A` | — |
| Tartomány | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

A relatív hivatkozások módosulhatnak, ha egy képletet egy táblázatkezelő áthelyez vagy másol. Az abszolút hivatkozások mindkét koordinátát rögzítik, míg a vegyes hivatkozások csak egy sort vagy egy oszlopot rögzítenek.

## **R1C1‑stílusú képletek használata**

Az R1C1 jelölés mind a sorokat, mind az oszlopokat numerikusan azonosítja. A relatív hivatkozások négyzetes zárójelben lévő eltolásokat használnak. A szintaxist a [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) metódussal adhatja meg.

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

A leggyakoribb R1C1 hivatkozási formák:

| Hivatkozás | Relatív | Abszolút | Vegyes |
|---|---|---|---|
| Cell | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Sor | `R[2]` | `R2` | — |
| Oszlop | `C[3]` | `C3` | — |
| Tartomány | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Például a `D2` cellában az `RC[-2]` a sorban ugyanazon sorban két oszloppal balra lévő cellát jelöli (`B2`).

## **Képlet‑állandók és operátorok**

A beépített képletelemző logikai értékeket, numerikus literálokat, karakterláncokat, táblázathibákat, aritmetikai operátorokat és összehasonlító operátorokat támogat.

### **Állandók és literálok**

| Típus | Példák | Megjegyzés |
|---|---|---|
| Logikai | `TRUE`, `FALSE` | Közvetlenül használható logikai kifejezésekben, például `A2=TRUE`. |
| Numerikus | `1`, `0.5`, `.3`, `1E-2` | A közönséges és tudományos jelölés is támogatott. |
| Karakterlánc | `"abc"`, `"2/3/2020 12:00"` | A szöveges literálokat dupla idézőjelek közé kell tenni a képletben. |
| Hiba‑eredmény | `#DIV/0!`, `#N/A`, `#REF!` | Egy érvényes képlet visszatérhet táblázathibával a normál eredmény helyett. |

Ez a példa több állandótípust használ:

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

    Object logicalValue = workbook.getCell(0, "B2").getValue(); // false
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
| `+` | Összeadás vagy egyjegyű plusz | `2+3` |
| `-` | Kivonás vagy negatív előjel | `2-3`, `-3` |
| `*` | Szorzás | `2*3` |
| `/` | Osztás | `2/3` |
| `%` | Százalék | `30%` |
| `^` | Hatványozás | `2^3` |

A zárójelek használatával kifejezheti a kívánt kiértékelési sorrendet, például `(A2+B2)*C2`.

### **Összehasonlító operátorok**

Az összehasonlító kifejezések logikai értékeket adnak vissza.

| Operátor | Jelentés | Példa |
|---|---|---|
| `=` | Egyenlő | `A2=3` |
| `<>` | Nem egyenlő | `A2<>3` |
| `>` | Nagyobb | `A2>3` |
| `>=` | Nagyobb vagy egyenlő | `A2>=3` |
| `<` | Kisebb | `A2<3` |
| `<=` | Kisebb vagy egyenlő | `A2<=3` |

## **Támogatott beépített függvények**

Az Aspose.Slides beépített képletelemzője a diagram‑munkalapokhoz tartozik, de nem egy teljes Excel‑számítási motor. A dokumentált függvénykészlet a következőkre korlátozódik. Ne feltételezze, hogy tetszőleges Excel‑függvény újraszámolható a [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) metódussal.

| Függvény | Cél vagy támogatott forma | Példa |
|---|---|---|
| `ABS` | Abszolút érték | `ABS(A2)` |
| `AVERAGE` | Aritmetikai közép | `AVERAGE(B2:B5)` |
| `CEILING` | Felfelé kerekítés többszörösre | `CEILING(A2,5)` |
| `CHOOSE` | Érték kiválasztása index szerint | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Szövegek egyesítése | `CONCAT(A2,B2)` |
| `CONCATENATE` | Szövegek egyesítése | `CONCATENATE(A2," ",B2)` |
| `DATE` | Dátumérték létrehozása a 1900‑as dátumrendszerrel | `DATE(2026,8,19)` |
| `DAYS` | Két dátum közötti napok száma | `DAYS(B2,A2)` |
| `FIND` | Szövegrész keresése egy másikban | `FIND("-",A2)` |
| `FINDB` | Bájt‑orientált szövegre keresés | `FINDB("a",A2)` |
| `IF` | Feltételes eredmény | `IF(A2>0,A2,0)` |
| `INDEX` | Referenciaforma | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektorfelület | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektorfelület | `MATCH(A2,B2:B5,0)` |
| `MAX` | Legnagyobb érték | `MAX(B2:B5)` |
| `SUM` | Összeg | `SUM(B2:B5)` |
| `VLOOKUP` | Függőleges keresés | `VLOOKUP(A2,B2:D10,3,FALSE)` |

A táblázatban szereplő korlátozások jelentősek: az `INDEX` referenciaformában van dokumentálva, míg a `LOOKUP` és a `MATCH` vektorformában. A `DATE` a 1900‑as dátumrendszert használja. A nem felsorolt funkciók a Aspose.Slides képletelemzője által nem támogatottak, hacsak külön nem kerülnek dokumentálásra.

## **Újraszámolás és gyorsítótárazott értékek**

A táblázatfájlok gyakran tárolják a képletet és az utolsó számított értékét is. Az Aspose.Slides ezért a [IChartDataCell.getValue](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatacell/#getValue--) metódussal beolvashat egy gyorsítótárazott értéket, amikor a prezentáció betöltődik, és a vonatkozó diagramadatok nem változtak.

Bemeneti cellák vagy képletek módosítása után ne támaszkodjon egy régi gyorsítótárazott eredményre. Hívja meg a [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) metódust a számított értékek beolvasása vagy a diagramadatok mentése előtt, ha azok a képletektől függnek.

A nem támogatott képletkészletben lévő képletek esetén az Aspose.Slides előfordulhat, hogy nem tudja elemezni a képletet vagy annak függőségeit. Ha a munkafüzet módosult, az előző gyorsítótárazott érték már nem tekinthető megbízhatónak. Ilyen esetben egy nem támogatott adatú cella értékének olvasása [CellUnsupportedDataException](https://reference.aspose.com/slides/hu/java/com.aspose.slides/cellunsupporteddataexception/) kivételt eredményezhet.

Ha a diagram olyan Excel‑függvényeket használ, amelyeket az Aspose.Slides nem értékel ki, számítsa ki ezeket a képleteket egy olyan táblázatmotorral, amely támogatja őket, majd írja vissza a kapott értékeket a diagram munkafüzetébe. Ne helyettesítse a nem támogatott képleteket becsült értékekkel.

## **Képhibák kezelése**

Kétféle problémát kell megkülönböztetni.

Egy képlet lehet érvényes, de táblázathiba‑eredményt ad, például `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` vagy `#VALUE!`. Ebben az esetben a hiba‑token egy cella‑eredmény, és a [IChartDataCell.getValue](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatacell/#getValue--) metódussal adható vissza.

Egy képlet hibát is dobhat a feldolgozás, hivatkozás, függőség vagy a támogatott adatok szintjén. Az Aspose.Slides ezekre az esetekre táblázat‑specifikus kivételeket biztosít: [CellInvalidFormulaException](https://reference.aspose.com/slides/hu/java/com.aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/hu/java/com.aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/hu/java/com.aspose.slides/cellcircularreferenceexception/) és [CellUnsupportedDataException](https://reference.aspose.com/slides/hu/java/com.aspose.slides/cellunsupporteddataexception/).

Amikor a képletek sablonokból vagy felhasználói bemenetből származnak, kezelje ezeket a kivételeket az újraszámolás és az értékhozzáférés körül:

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

A diagram‑munkalapok képlet‑támogatása meghatározott részhalmazra korlátozódik, nem a teljes Excel‑kompatibilitásra. Tartsa szem előtt ezeket a korlátokat a jelentéskészítési munkafolyamat tervezésekor:

- Csak a dokumentált állandókat, operátorokat, hivatkozásokat és függvényeket használja, ha azt akarja, hogy az Aspose.Slides újraszámolja a képleteket.
- Számolja újra a munkafüzetet a cellák módosítása után, amelyek a képlet eredményét befolyásolják.
- A betöltött prezentációkból származó gyorsítótárazott értékeket pillanatfelvételekként kezelje, nem pedig a szerkesztés utáni újraszámolás helyettesítőjeként.
- Tesztelje a meglévő sablonok képleteit, mielőtt a számított értékekre támaszkodna, különösen, ha azok a dokumentált listán kívüli függvényeket használnak.
- Azoknál a képleteknél, amelyek teljes táblázatszámítási motort igényelnek, számítsa ki őket külsőleg, majd frissítse a diagram munkafüzetét a kapott értékekkel.

## **GYIK**

**Mi a különbség a [IChartDataCell.setFormula](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) és a [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) között?**

[IChartDataCell.setFormula](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) A1‑stílusú kifejezést tárol, például `B2-C2`. [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) R1C1‑stílusú kifejezést tárol, például `RC[-2]-RC[-1]`. Válassza azt a jelölést, amelyik leginkább illeszkedik a képletek generálásához vagy másolásához.

**A számítás után a cellát kell olvasnom, vagy csak az értékét?**

[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdataworkbook/#getCell-int-java.lang.String-) egy [IChartDataCell](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatacell/) objektumot ad vissza. A számított eredményhez hívja meg ennek a cellának a [IChartDataCell.getValue](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatacell/#getValue--) metódusát az újraszámolás után.

**Mikor kell meghívni a [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) metódust?**

Hívja meg a [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) metódust a bemeneti értékek vagy képletek módosítása után, és mielőtt a számított eredményektől függne. Ez frissíti a beépített értékelő által támogatott képletek értékeit.

**Az Aspose.Slides minden Excel‑függvényt támogat?**

Nem. A beépített értékelő egy dokumentált függvény‑részhalmazt támogat. A részhalmazon kívüli függvényekre ne számítson helyes újraszámolásra. Ha teljes Excel‑képlet‑kompatibilitásra van szükség, végezze el a számítást egy megfelelő táblázat‑motorral, majd írja az eredményeket a diagram munkafüzetébe.

**Mi történik, ha egy betöltött prezentáció nem támogatott képletet tartalmaz?**

Ha a diagramadatok nem változtak, a munkafüzet még tartalmazhat egy korábban számított gyorsítótárazott értéket. A kapcsolódó adatok módosítása után ez a gyorsítótárazott érték már nem biztos, hogy érvényes. Egy olyan cella, amelynek képlete nem kezelhető, [CellUnsupportedDataException](https://reference.aspose.com/slides/hu/java/com.aspose.slides/cellunsupporteddataexception/) kivételt vált ki.

**A képhiba‑értékek megegyeznek a Java‑kivételekkel?**

Nem. A `#DIV/0!`‑hez hasonló eredmény egy táblázat‑érték, amely egy érvényes számításból származik. A [CellInvalidFormulaException](https://reference.aspose.com/slides/hu/java/com.aspose.slides/cellinvalidformulaexception/) vagy [CellCircularReferenceException](https://reference.aspose.com/slides/hu/java/com.aspose.slides/cellcircularreferenceexception/) kivételek azt jelzik, hogy a képletet nem lehet normál módon feldolgozni.

**A diagram automatikusan frissül, ha egy képlet‑cellát megváltoztatnak?**

Egy diagram‑sorozat hivatkozhat a munkafüzet celláira. Először számolja újra a munkafüzetet, majd mentse vagy jelenítse meg a prezentációt. Ha a diagram adatpontjai a számított cellákra mutatnak, a diagram az aktualizált cella‑értékeket használja; külön diagram‑frissítési metódusra nincs szükség ebben a munkafolyamatban.

**Használhatók a diagramok külső Excel‑munkafüzetekkel?**

Igen, a diagramadatok konfigurálhatók külső munkafüzet használatára a diagram‑adat‑API‑n keresztül. Azonban ebben a cikkben leírt képletszámítási munkafolyamat a diagram munkafüzetére és az Aspose.Slides által kiértékelt képlet‑részhalmazra vonatkozik. Ne tételezze, hogy a [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) teljesen újraszámolja a tetszőleges képleteket egy külső XLSX‑fájlban.

**Használhatók a képletek, amelyek másik munkalapra vagy munkafüzetre hivatkoznak?**

Az Excel‑stílusú hivatkozások előfordulhatnak a diagram munkafüzetekben, de a képlet‑értékelés a támogatott elemző és függvénykészlet által korlátozott. Ha egy kereszt‑lap vagy külső hivatkozás elengedhetetlen, ellenőrizze a pontos képletet a használt Aspose.Slides‑verzióval. Az olyan munkafolyamatokhoz, amelyek széleskörű Excel‑hivatkozási kompatibilitást igényelnek, számítsa ki a munkafüzetet külsőleg, majd írja vissza a feloldott értékeket a diagram‑adatokba.

**Képlet‑karakterláncoknak kell `=`‑vel kezdődniük?**

Az Aspose.Slides API‑példák a `B2-C2` vagy `SUM(B2:B5)` kifejezéseket `=` nélkül adják meg. Ennek a formának a használata konzisztens a dokumentált API‑példákkal.