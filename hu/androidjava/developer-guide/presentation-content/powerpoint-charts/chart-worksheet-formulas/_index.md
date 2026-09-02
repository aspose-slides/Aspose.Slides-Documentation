---
title: Diagram munkalap képletek alkalmazása Androidos prezentációkban
linktitle: Munkalap képletek
type: docs
weight: 70
url: /hu/androidjava/chart-worksheet-formulas/
keywords:
- diagram táblázat
- diagram munkalap
- diagram képlet
- munkalap képlet
- táblázat képlet
- diagram adatkönyvtár
- képlet számítás
- preferált kultúra
- kultúraspecifikus képlet
- DBCS
- logikai állandó
- numerikus állandó
- szövegállandó
- hibaállandó
- aritmetikai operátor
- összehasonlító operátor
- A1 stílus
- R1C1 stílus
- előre definiált függvény
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Excel‑stílusú képletek alkalmazása az Aspose.Slides for Android Java diagram munkalapokon, az értékek újraszámítása, és az eredmények használata PowerPoint diagramokban."
---
## **Áttekintés**

A PowerPoint-diagramok általában a forrásadataikat beágyazott munkalapon tárolják. Az Aspose.Slides for Android via Java segítségével hozzáférhet a munkalaphoz a diagram adatkönyvtárán keresztül, beírhat bemeneti értékeket, képleteket rendelhet a cellákhoz, kiszámíthatja a támogatott képleteket, és a kiszámított cellákat diagram adatokként használhatja.

Ez a cikk bemutatja a teljes képletmunkafolyamatot: diagram létrehozása, a munkalap feltöltése, A1‑ vagy R1C1‑stílusú képletek hozzárendelése, újraszámításuk, a számított értékek beolvasása, ezeknek a celláknak a diagram sorozathoz kapcsolása, és a prezentáció mentése. Emellett ismerteti a támogatott képlet szintaxist, a beépített függvény részhalmazt, a gyorsítótárazott értékeket, a nem támogatott képleteket és a táblázatspecifikus hibákat.

## **Diagram munkalapok és képletek**

Egy diagram munkalapja tartalmazza a kategóriákat, sorozatneveket és a diagram által használt értékeket. PowerPointban a munkalapot a diagram adateditor megnyitásával ellenőrizheti:

![PowerPoint diagram beágyazott munkalappal nyitva, kategória‑ és sorozatadatok megjelenítése](chart-worksheet-formulas_1.png)

Az Aspose.Slidesben a munkalap a [IChartDataWorkbook](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdataworkbook/) felületen keresztül érhető el. Használja a [IChartDataCell.setFormula](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) metódust A1‑stílusú képletekhez, valamint a [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) metódust R1C1‑stílusú képletekhez. Bemeneti cellák vagy képletek módosítása után hívja meg a [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) metódust a támogatott képletek újraszámításához és a megfelelő cellaértékek frissítéséhez.

Egy számított cella eredményét továbbra is a [IChartDataCell.getValue](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatacell/#getValue--) metódussal érheti el. Ez akkor fontos, amikor a kódban képleteredményt kell ellenőriznie vagy a cellát diagram adatpontként szeretné használni.

## **Diagram létrehozása és a munkalap képleteinek kiszámítása**

Az alábbi példa egy végponttól végpontig tartó munkafolyamatot mutat be. Létrehoz egy csoportosított oszlopdiagramot, törli a mintákat, beírja a negyedéves bevétel‑ és költségértékeket, képletekkel számítja ki a profitot, beolvassa az eredményeket, a számított cellákat diagramértékként használja, és menti a prezentációt.

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

A diagram adatpontjai a `D2:D4` tartományra hivatkoznak, így a diagram a számított profitértékeket használja. Ebben a munkafolyamatban nincs külön diagram‑frissítő hívás: először számolja újra a munkafüzetet, majd használja vagy mentse a számított cellákra mutató diagramadatokat.

## **A1‑stílusú képletek használata**

Az A1 jelölés oszlopokat betűkkel, sorokat számokkal azonosít. A A1‑stílusú kifejezéseket a [IChartDataCell.setFormula](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) metódussal adhatja meg.

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

A gyakori A1 referenciaformák:

| Referencia | Relatív | Abszolút | Vegyes |
|---|---|---|---|
| Cella | `A2` | `$A$2` | `A$2`, `$A2` |
| Sor | `2:2` | `$2:$2` | — |
| Oszlop | `A:A` | `$A:$A` | — |
| Tartomány | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

A relatív hivatkozások a képlet mozgatásakor vagy másolásakor megváltozhatnak egy táblázatkezelőben. Az abszolút hivatkozások mindkét koordinátát rögzítik, míg a vegyes hivatkozások csak egy sort vagy egy oszlopot rögzítenek.

## **R1C1‑stílusú képletek használata**

Az R1C1 jelölés mind a sorokat, mind az oszlopokat numerikusan azonosítja. A relatív hivatkozások négyzetes zárójelekben lévő eltolásokat használnak. Ezt a szintaxist a [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) metódussal adhatja meg.

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

A gyakori R1C1 referenciaformák:

| Referencia | Relatív | Abszolút | Vegyes |
|---|---|---|---|
| Cella | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Sor | `R[2]` | `R2` | — |
| Oszlop | `C[3]` | `C3` | — |
| Tartomány | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Például a `D2` cellában az `RC[-2]` a ugyanabban a sorban két oszloppal balra lévő cellát jelenti (`B2`).

## **Képletállandók és operátorok**

A beépített képletelemző logikai értékek, numerikus literálok, sztringek, táblázathibák, aritmetikai operátorok és összehasonlító operátorok támogatását biztosítja.

### **Állandók és literálok**

| Típus | Példák | Megjegyzés |
|---|---|---|
| Logikai | `TRUE`, `FALSE` | Közvetlenül használható logikai kifejezésekben, pl. `A2=TRUE`. |
| Numerikus | `1`, `0.5`, `.3`, `1E-2` | A közös és a tudományos jelölés egyaránt támogatott. |
| Sztring | `"abc"`, `"2/3/2020 12:00"` | Szövegliterálok dupla idézőjelek közé vannak helyezve a képletben. |
| Hibaeredmény | `#DIV/0!`, `#N/A`, `#REF!` | Egy érvényes képlet normál eredmény helyett táblázathiba‑értékkel is visszatérhet. |

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
| `+` | Összeadás vagy unáris plusz | `2+3` |
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

## **Támogatott beépített függvények**

Az Aspose.Slides beépített képletelemzővel rendelkezik diagram munkalapokhoz, de nem egy teljes Excel‑számítási motor. A dokumentált függvénykészlet az alábbiakra korlátozódik. Ne feltételezze, hogy bármely Excel‑függvényt újra tud számolni a [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) metódus.

| Függvény | Cél vagy támogatott forma | Példa |
|---|---|---|
| `ABS` | Abszolút érték | `ABS(A2)` |
| `AVERAGE` | Mértani közép | `AVERAGE(B2:B5)` |
| `CEILING` | Felfelé kerekítés egy többszörösre | `CEILING(A2,5)` |
| `CHOOSE` | Index alapján választ értéket | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Szövegek összefűzése | `CONCAT(A2,B2)` |
| `CONCATENATE` | Szövegek összefűzése | `CONCATENATE(A2," ",B2)` |
| `DATE` | Dátumérték létrehozása a 1900‑es dátumrendszerrel | `DATE(2026,8,19)` |
| `DAYS` | Napok száma két dátum között | `DAYS(B2,A2)` |
| `FIND` | Szövegrész keresése egy másikban | `FIND("-",A2)` |
| `FINDB` | Bájt‑orientált szövegre keresés | `FINDB("a",A2)` |
| `IF` | Feltételes eredmény | `IF(A2>0,A2,0)` |
| `INDEX` | Referenciaforma | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektorf forma | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektorf forma | `MATCH(A2,B2:B5,0)` |
| `MAX` | Legnagyobb érték | `MAX(B2:B5)` |
| `SUM` | Összeg | `SUM(B2:B5)` |
| `VLOOKUP` | Függőleges keresés | `VLOOKUP(A2,B2:D10,3,FALSE)` |

A táblázatban szereplő korlátozások jelentősek: az `INDEX` referenciaformában, míg a `LOOKUP` és `MATCH` vektorf formában van dokumentálva. A `DATE` a 1900‑as dátumrendszert használja. Az itt felsoroltakon kívül szereplő funkciók a beépített képletelemző számára nem támogatottak, hacsak külön nincsenek dokumentálva.

## **Képletek számítása preferált kultúrával**

Bizonyos munkafüzet‑függvények a szöveget kultúrafüggő szabályok szerint értelmezik. Ez különösen fontos azoknál a függvényeknél, amelyek kettős bájtos karakterkészletet (DBCS) használó nyelvekre lettek tervezve. Az ilyen képletek helyes számításához hozza létre a [LoadOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/loadoptions/) objektumot, állítsa be a preferált kultúrát a [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/spreadsheetoptions/#setPreferredCulture-java.util.Locale-) metódussal, adja át a táblázat‑beállításokat a [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) metódussal, majd töltse be a prezentációt.

Az alábbi példa japán kultúrát választ, megnyit egy prezentációt a beállított betöltési opciókkal, és minden diagram munkafüzetre meghívja a [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) metódust:

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

A preferált kultúra a prezentáció betöltési konfiguráció része, ezért a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) példány létrehozása előtt adja meg. Használja a képletek által elvárt kultúrát; például a japán DBCS szabályokhoz a `ja-JP` értéket adja meg.

## **Újraszámítás és gyorsítótárazott értékek**

A táblázatfájlok gyakran tárolják a képletet és az utoljára számított értéket is. Az Aspose.Slides ezért a [IChartDataCell.getValue](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatacell/#getValue--) metódussal a gyorsítótárazott értéket is kiolvashatja, amikor a prezentáció betöltődik, és a vonatkozó diagramadatok nem változtak.

Bemeneti cellák vagy képletek módosítása után ne támaszkodjon egy régi gyorsítótárazott eredményre. Hívja meg a [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) metódust a számított értékek beolvasása vagy a függő diagramadatok mentése előtt.

A támogatott részhalmazon kívül eső képletek esetén az Aspose.Slides előfordulhat, hogy nem tudja értelmezni a képletet vagy annak függőségeit. Ha a munkafüzet módosult, a korábbi gyorsítótárazott érték már nem tekinthető megbízhatónak. Ilyenkor egy nem támogatott adatot tartalmazó cella olvasása [CellUnsupportedDataException](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/cellunsupporteddataexception/) kivételt eredményezhet.

Ha diagramja olyan Excel‑függvényeket használ, amelyeket az Aspose.Slides nem értékel ki, számolja ki ezeket a képleteket egy olyan táblázat‑motorral, amely támogatja őket, és írja vissza a kapott értékeket a diagram munkafüzetbe. Ne helyettesítse a nem támogatott képleteket tippelt értékekkel.

## **Képlethibák kezelése**

Két különböző problématípust kell megkülönböztetni.

Egy képlet lehet érvényes, de táblázathiba‑eredményt adhat, például `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` vagy `#VALUE!`. Ebben az esetben a hibatoken egy cellaeredmény, és a [IChartDataCell.getValue](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatacell/#getValue--) metódussal adható vissza.

Egy képlet a feldolgozás, referencia, függőség vagy támogatott adat szintjén is hibát okozhat. Az Aspose.Slides ilyen esetekre táblázatspecifikus kivételeket biztosít: [CellInvalidFormulaException](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/cellcircularreferenceexception/) és [CellUnsupportedDataException](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/cellunsupporteddataexception/).

Ha képletek sablonokból vagy felhasználói bemenetből érkeznek, kezelje ezeket a kivételeket az újraszámítás és az értékelérés körül:

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

A diagram munkalapok képlet‑támogatása egy meghatározott részhalmazra vonatkozik, nem a teljes Excel‑kompatibilitásra. Tartsa szem előtt ezeket a korlátokat a jelentéskészítési munkafolyamat tervezésekor:

- Csak a dokumentált állandókat, operátorokat, hivatkozásokat és függvényeket használja, ha azt szeretné, hogy az Aspose.Slides újraszámolja a képleteket.
- Újraszámítás a képlet‑eredményekhez kapcsolódó cellák módosítása után.
- A betöltött prezentációkból származó gyorsítótárazott értékeket pillanatfelvételekként kezelje, nem helyettesítőként a módosítások utáni újraszámításra.
- Tesztelje a meglévő sablonok képleteit, mielőtt a kiszámított értékekre támaszkodna, különösen, ha a dokumentált listán kívüli függvényeket tartalmaznak.
- Olyan képletek esetén, amelyek teljes táblázat‑számítási engine‑t igényelnek, számolja ki azokat külsőleg, majd frissítse a diagram munkafüzetet a kapott értékekkel.

## **GYIK**

**Mi a különbség a [IChartDataCell.setFormula](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) és a [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) között?**

[IChartDataCell.setFormula](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) A1‑stílusú kifejezést tárol, például `B2-C2`. [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) R1C1‑stílusú kifejezést tárol, például `RC[-2]-RC[-1]`. Használja azt a jelölést, amelyik leginkább megfelel a képletek generálásának vagy másolásának.

**Kell-e a cellát vagy annak értékét olvasni a számítás után?**

[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-java.lang.String-) egy [IChartDataCell](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatacell/) objektumot ad vissza. A számított eredményhez hívja meg ennek a cellának a [IChartDataCell.getValue](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatacell/#getValue--) metódusát a újraszámítás után.

**Mikor kell meghívni a [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--)?**

Hívja meg a [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) metódust a bemeneti értékek vagy képletek módosítása után, és még az előtt, hogy a számított eredményektől függő műveleteket végezne. Ez frissíti a beépített értékelő által támogatott képletek értékeit.

**Támogatja-e az Aspose.Slides minden Excel‑függvényt?**

Nem. A beépített értékelő csak egy dokumentált részhalmazt támogat. A részhalmazon kívüli függvényeknek nem szabad számolásra számítani. Ha teljes Excel‑képlet kompatibilitásra van szükség, végezze el a számítást egy megfelelő táblázat‑motorral, majd írja a végső értékeket a diagram munkafüzetbe.

**Mi történik, ha egy betöltött prezentáció nem támogatott képletet tartalmaz?**

Ha a diagram adatai nem változtak, a munkafüzetben előfordulhat, hogy egy korábban számított gyorsítótárazott érték maradt. A kapcsolódó adatok módosítása után ez a gyorsítótárazott érték már nem lehet érvényes. Egy nem kezelhető képlettel rendelkező cella olvasása [CellUnsupportedDataException](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/cellunsupporteddataexception/) kivételt vált ki.

**Ugyanazok a képlethiba‑értékek, mint a Java‑kivételek?**

Nem. A `#DIV/0!`‑hez hasonló eredmény egy táblázat‑érték, amely egy érvényes számításból származik. A [CellInvalidFormulaException](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/cellinvalidformulaexception/) vagy [CellCircularReferenceException](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/cellcircularreferenceexception/) kivételek azt jelzik, hogy a képlet nem dolgozható fel normál módon.

**Frissül automatikusan a diagram, ha egy képlet‑cella változik?**

A diagram sorozatok hivatkozhatnak a munkafüzet celláira. Először számolja újra a munkafüzetet, majd mentse vagy jelenítse meg a prezentációt. Ha a diagram adatpontjai a számított cellákra mutatnak, a diagram az azok által frissített értékeket használja; nincs szükség külön diagram‑frissítő metódusra ebben a munkafolyamatban.

**Használhatók külső Excel‑munkafüzetek diagramokban?**

Igen, a diagram adatokat konfigurálhatja úgy, hogy külső munkafüzetet használjanak a diagram adat‑API‑n keresztül. Azonban ebben a cikkben leírt képletszámítási munkafolyamat a diagram adatkönyvtárra és az Aspose.Slides által értékelt képlet‑részhalmazra vonatkozik. Ne feltételezze, hogy a [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) teljes képletek újraszámítását biztosítja egy külső XLSX‑fájlban.

**Használhatók képletek, amelyek más munkalapra vagy munkafüzetre hivatkoznak?**

Az Excel‑stílusú hivatkozások előfordulhatnak diagram munkafüzetekben, de a képlet‑értékelés a támogatott elemző és függvénykészlet által korlátozott. Ha egy kereszt‑lap vagy külső hivatkozás elengedhetetlen, ellenőrizze a pontos képletet a használt Aspose.Slides verzióval. Széles körű Excel‑hivatkozási kompatibilitást igénylő munkafolyamatok esetén számolja ki a munkafüzetet külsőleg, és írja vissza a feloldott értékeket a diagram adatba.

**Kell‑e a képletszöveg `=` jellel kezdődjön?**

Az Aspose.Slides API‑példák a `B2-C2` vagy `SUM(B2:B5)` kifejezéseket `=` nélkül adják meg. Ennek a formának a használata egységes képleteket biztosít a dokumentált API‑példákhoz képest.