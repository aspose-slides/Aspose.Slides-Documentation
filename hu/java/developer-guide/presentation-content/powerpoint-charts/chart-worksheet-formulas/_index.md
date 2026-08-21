---
title: "Diagrammunkalap képletek alkalmazása bemutatókban Java-ban"
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
- "diagram adatkönyvtár"
- "képlet számítás"
- "preferált kultúra"
- "kultúra-specifikus képlet"
- DBCS
- "logikai állandó"
- "numerikus állandó"
- "szöveges állandó"
- "hibaállandó"
- "aritmetikai operátor"
- "összehasonlító operátor"
- "A1 stílus"
- "R1C1 stílus"
- "előre definiált függvény"
- PowerPoint
- "bemutató"
- Java
- Aspose.Slides
description: "Alkalmazzon Excel-szerű képleteket az Aspose.Slides for Java diagrammunkalapokon, számítsa újra az értékeket, és használja az eredményeket a PowerPoint diagramokban."
---
## **Áttekintés**

A PowerPoint diagrammok általában beágyazott munkalapon tárolják a forrásadataikat. Az Aspose.Slides for Java-ban a diagram adatkönyvtárán keresztül férhet hozzá a munkalaphoz, beírhatja a bemeneti értékeket, hozzárendelhet képleteket a cellákhoz, kiszámíthatja a támogatott képleteket, és a kiszámított cellákat diagramadatként használhatja.

Ez a cikk a teljes képletmunkaáramlást írja le: diagram létrehozása, a munkalap feltöltése, A1‑ vagy R1C1‑stílusú képletek hozzárendelése, újbóli kiszámításuk, a kiszámított értékek olvasása, a cellák diagramsorozathoz kapcsolása és a bemutató mentése. Emellett bemutatja a támogatott képlet szintaxist, a beépített függvények részhalmazát, a gyorsítótárazott értékeket, a nem támogatott képleteket és a táblázatokra jellemző hibákat.

## **Diagram munkalapok és képletek**

Egy diagram munkalapja tartalmazza a kategóriákat, a sorozatneveket és a diagram által használt értékeket. PowerPointban a munkalapot a diagram adat szerkesztőjének megnyitásával ellenőrizheti:

![PowerPoint diagram a beágyazott munkalappal nyitva, amely a kategória és sorozat adatokat mutatja](chart-worksheet-formulas_1.png)

Az Aspose.Slides-ben a munkalap a [IChartDataWorkbook](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdataworkbook/) interfészen keresztül érhető el. A1‑stílusú képletekhez használja az [IChartDataCell.setFormula](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) metódust, R1C1‑stílusú képletekhez pedig az [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) metódust. Bemeneti cellák vagy képletek módosítása után hívja az [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) metódust a támogatott képletek újraszámításához és a megfelelő cellaértékek frissítéséhez.

A kiszámított cella továbbra is az [IChartDataCell.getValue](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatacell/#getValue--) metódussal adja vissza az eredményt. Ez akkor fontos, amikor a kódban kell ellenőrizni egy képlet eredményét vagy a cellát diagramadatként kell felhasználni.

## **Diagram létrehozása és a munkalap képleteinek kiszámítása**

Az alábbi példa egy teljes folyamatot mutat be. Létrehoz egy csoportos oszlopdiagramot, törli a mintaadatokat, beírja a negyedéves bevétel‑ és költségértékeket, képletekkel számolja ki a profitot, kiolvassa az eredményeket, a kiszámított cellákat diagramértékekként használja, és menti a bemutatót.

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

A diagram adatpontjai a `D2:D4` tartományra hivatkoznak, ezért a diagram a kiszámított profitértékeket használja. Ebben a munkafolyamatban nincs külön diagram‑frissítési hívás: először számítsa újra a munkafüzetet, majd használja vagy mentse a kiszámított cellákra mutató diagramadatokat.

## **A1‑stílusú képletek használata**

Az A1‑notáció a oszlopokat betűkkel, a sorokat számokkal azonosítja. A [IChartDataCell.setFormula](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) metódussal adhat meg A1‑stílusú kifejezéseket.

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

A gyakori A1 hivatkozási formák:

| Hivatkozás | Relatív | Abszolút | Vegyes |
|---|---|---|---|
| Cella | `A2` | `$A$2` | `A$2`, `$A2` |
| Sor | `2:2` | `$2:$2` | — |
| Oszlop | `A:A` | `$A:$A` | — |
| Tartomány | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

A relatív hivatkozások a képlet áthelyezésekor vagy másolásakor változhatnak. Az abszolút hivatkozások mindkét koordinátát rögzítik, a vegyes hivatkozások csak egy sort vagy egy oszlopot rögzítenek.

## **R1C1‑stílusú képletek használata**

Az R1C1‑notáció a sorokat és oszlopokat számszerűen azonosítja. A relatív hivatkozások négyzetes zárójelekben lévő eltolásokat használnak. A [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) metódussal adhat meg ilyen szintaxist.

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

A gyakori R1C1 hivatkozási formák:

| Hivatkozás | Relatív | Abszolút | Vegyes |
|---|---|---|---|
| Cella | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Sor | `R[2]` | `R2` | — |
| Oszlop | `C[3]` | `C3` | — |
| Tartomány | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Például a `D2` cellában az `RC[-2]` a sorban ugyanott lévő, két oszloppal balra lévő cellát jelöli (`B2`).

## **Képletállandók és operátorok**

A beépített képletértékelő logikai értékeket, numerikus literálokat, szövegeket, táblázathibákat, aritmetikai operátorokat és összehasonlító operátorokat támogat.

### **Állandók és literálok**

| Típus | Példák | Megjegyzés |
|---|---|---|
| Logikai | `TRUE`, `FALSE` | Közvetlenül használható logikai kifejezésekben, például `A2=TRUE`. |
| Numerikus | `1`, `0.5`, `.3`, `1E-2` | A közönséges és tudományos jelölés egyaránt támogatott. |
| Szöveg | `"abc"`, `"2/3/2020 12:00"` | Szövegliterálok dupla idézőjelbe vannak ágyazva a képleten belül. |
| Hibaérték | `#DIV/0!`, `#N/A`, `#REF!` | Egy érvényes képlet kiértékelhető táblázathibára is, a normál eredmény helyett. |

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
| `+` | Összeadás vagy egyelőleges plusz | `2+3` |
| `-` | Kivonás vagy negatív előjeles | `2-3`, `-3` |
| `*` | Szorzás | `2*3` |
| `/` | Osztás | `2/3` |
| `%` | Százalék | `30%` |
| `^` | Hatványozás | `2^3` |

A zárójelek használatával teheti egyértelművé a kiértékelési sorrendet, például `(A2+B2)*C2`.

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

Az Aspose.Slides saját képletértékelővel rendelkezik a diagrammunkalapokhoz, de nem egy teljes Excel számítási motor. A dokumentált függvénykészlet csak az alábbiakat tartalmazza. Ne feltételezze, hogy tetszőleges Excel‑függvényt újra tud számolni az [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) metódus.

| Függvény | Cél vagy támogatott forma | Példa |
|---|---|---|
| `ABS` | Abszolút érték | `ABS(A2)` |
| `AVERAGE` | Aritmetikai közép | `AVERAGE(B2:B5)` |
| `CEILING` | Felfelé kerekítés egy többszörösre | `CEILING(A2,5)` |
| `CHOOSE` | Érték kiválasztása index alapján | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Szövegértékek összefűzése | `CONCAT(A2,B2)` |
| `CONCATENATE` | Szövegértékek összefűzése | `CONCATENATE(A2," ",B2)` |
| `DATE` | Dátumérték létrehozása a 1900‑as dátumrendszerrel | `DATE(2026,8,19)` |
| `DAYS` | Napok számának visszaadása két dátum között | `DAYS(B2,A2)` |
| `FIND` | Egy szövegérték keresése egy másikban | `FIND("-",A2)` |
| `FINDB` | Byte‑orientált szöveges keresés | `FINDB("a",A2)` |
| `IF` | Feltételes eredmény | `IF(A2>0,A2,0)` |
| `INDEX` | Hivatkozási forma | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektoros forma | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektoros forma | `MATCH(A2,B2:B5,0)` |
| `MAX` | Legnagyobb érték | `MAX(B2:B5)` |
| `SUM` | Összeg | `SUM(B2:B5)` |
| `VLOOKUP` | Vertikális keresés | `VLOOKUP(A2,B2:D10,3,FALSE)` |

A táblázatban szereplő korlátozások jelentősek: az `INDEX` referencia‑formában, míg a `LOOKUP` és `MATCH` vektoros formában van dokumentálva. A `DATE` a 1900‑as dátumrendszert használja. A felsoroltakon kívül szereplő funkciók nem támogatottak az Aspose.Slides képletértékelőben, hacsak külön nincsenek dokumentálva.

## **Képletek számítása a kívánt kultúrával**

Néhány diagram munkafüzet‑függvény a szöveget kultúrától függő szabályok szerint értelmezi. Ez különösen fontos a dupla‑bájtos karakterkészleteket (DBCS) használó nyelvek esetén. Az ilyen képletek helyes számításához hozza létre a [LoadOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/loadoptions/) objektumot, állítsa be a kívánt kultúrát a [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/hu/java/com.aspose.slides/spreadsheetoptions/#setPreferredCulture-java.util.Locale-) metódussal, adja át a táblázatbeállításokat a [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) metódussal, majd töltse be a bemutatót.

Az alábbi példa a japán kultúrát választja, megnyit egy bemutatót a beállított betöltési opciókkal, és minden diagram munkafüzetre meghívja az [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) metódust:

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

A kívánt kultúra a bemutató betöltési konfiguráció része, ezért a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) példány létrehozása előtt adja meg. Használja a képletek által elvárt kultúrát; például a japán DBCS számítási szabályokhoz a `ja-JP` értéket kell megadni.

## **Újraszámítás és gyorsítótárazott értékek**

A táblázatfájlok gyakran tárolják a képletet és az utolsó kiszámított értékét is. Az Aspose.Slides ezért a [IChartDataCell.getValue](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatacell/#getValue--) metódussal képes egy gyorsítótárazott értéket beolvasni, ha a bemutató betöltésekor a diagramadatok nem változtak.

Bemeneti cellák vagy képletek módosítása után ne támaszkodjon a régi gyorsítótárazott eredményre. Hívja az [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) metódust a kiszámított értékek olvasása vagy a diagramadatok mentése előtt, ha azok függnek a képletektől.

A támogatott részhalmazon kívül eső képletek esetén az Aspose.Slides előfordulhat, hogy nem tudja elemezni a képletet vagy annak függőségeit. Ha a munkafüzetet módosították, a korábban gyorsítótárazott érték már nem tekinthető megbízhatónak. Ilyen esetben egy nem támogatott adatú cella olvasása a [CellUnsupportedDataException](https://reference.aspose.com/slides/hu/java/com.aspose.slides/cellunsupporteddataexception/) kivételt váltja ki.

Ha diagramja olyan Excel‑függvényeket használ, amelyeket az Aspose.Slides nem értékel ki, számítsa ki ezeket a képleteket egy megfelelő táblázatmotorral, és írja vissza az eredményeket a diagram munkafüzetébe. Ne helyettesítse a nem támogatott képleteket kitalált értékekkel.

## **Képlethibák kezelése**

Két különböző problématípust kell megkülönböztetni.

Egy képlet érvényes lehet, de táblázathibát eredményezhet, például `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` vagy `#VALUE!`. Ebben az esetben a hibajet a cella eredménye, és a [IChartDataCell.getValue](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatacell/#getValue--) metódussal adható vissza.

A képlet a feldolgozás, a hivatkozás, a függőség vagy a támogatott adat szintjén is meghibásodhat. Az Aspose.Slides ezekhez az esetekhez táblázatspecifikus kivételeket biztosít: [CellInvalidFormulaException](https://reference.aspose.com/slides/hu/java/com.aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/hu/java/com.aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/hu/java/com.aspose.slides/cellcircularreferenceexception/) és [CellUnsupportedDataException](https://reference.aspose.com/slides/hu/java/com.aspose.slides/cellunsupporteddataexception/).

Ha a képletek sablonokból vagy felhasználói bevitelből származnak, kezelje ezeket a kivételeket a újraszámítás és az értékelérés körül:

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

A diagram munkalapok képlet‑támogatása egy meghatározott részhalmazra vonatkozik, nem pedig a teljes Excel‑kompatibilitásra. Tartsa szem előtt ezeket a korlátokat a jelentéskészítési munkafolyamat tervezésekor:

- Csak a dokumentált állandókat, operátorokat, hivatkozásokat és függvényeket használja, ha azt szeretné, hogy az Aspose.Slides újraszámolja a képleteket.
- Újraszámítás a cellák módosítása után, amelyek befolyásolják a képlet eredményét.
- A betöltött bemutatókból származó gyorsítótárazott értékeket tekintse pillanatfelvételeknek, ne helyettesítőnek az editálás utáni újraszámításra.
- Tesztelje a meglévő sablonok képleteit, mielőtt a kiszámított értékekre támaszkodna, különösen, ha olyan függvényeket használnak, amelyek nincsenek a dokumentált listán.
- Olyan képletekhez, amelyek teljes táblázatmotor számítását igénylik, végezze el a számítást kívül, majd frissítse a diagram munkafüzetet a kapott értékekkel.

## **GYIK**

**Mi a különbség az [IChartDataCell.setFormula](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) és az [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) között?**

Az [IChartDataCell.setFormula](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) A1‑stílusú kifejezést tárol, például `B2-C2`. Az [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) R1C1‑stílusú kifejezést tárol, például `RC[-2]-RC[-1]`. Használja azt a notációt, amelyik legjobban illeszkedik a képletek generálásához vagy másolásához.

**A számítás után a cellát vagy annak értékét kell olvasnom?**

Az [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdataworkbook/#getCell-int-java.lang.String-) egy [IChartDataCell](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatacell/) objektumot ad vissza. A kiszámított eredményhez a cella [IChartDataCell.getValue](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatacell/#getValue--) metódusát kell meghívni az újraszámítás után.

**Mikor kell meghívni az [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) metódust?**

Hívja az [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) metódust a bemeneti értékek vagy képletek módosítása után, és mielőtt a kiszámított eredményeket felhasználná. Ez frissíti a beépített értékelő által támogatott képletek értékeit.

**Az Aspose.Slides támogat minden Excel‑függvényt?**

Nem. A beépített értékelő a dokumentált függvényrészhalmazt támogatja. A részhalmazon kívüli függvényeket ne tekintse úgy, hogy helyesen újraszámolhatók. Ha teljes Excel‑képletkompatibilitásra van szükség, végezze el a számítást egy megfelelő táblázatmotorral, és írja az eredményeket a diagram munkafüzetbe.

**Mi történik, ha egy betöltött bemutató nem támogatott képletet tartalmaz?**

Ha a diagram adatai nem változtak, a munkafüzet még tartalmazhat egy korábban kiszámított gyorsítótárazott értéket. A kapcsolódó adatok módosítása után ez a gyorsítótárazott érték már nem lehet érvényes. Egy olyan cella, amelynek képletét nem képes kezelni, a [CellUnsupportedDataException](https://reference.aspose.com/slides/hu/java/com.aspose.slides/cellunsupporteddataexception/) kivételt váltja ki.

**Ugyanazok a hibajelentések, mint a Java‑kivétel?**

Nem. A `#DIV/0!`‑hoz hasonló eredmény egy táblázatérték, amely egy érvényes számításból származik. A [CellInvalidFormulaException](https://reference.aspose.com/slides/hu/java/com.aspose.slides/cellinvalidformulaexception/) vagy a [CellCircularReferenceException](https://reference.aspose.com/slides/hu/java/com.aspose.slides/cellcircularreferenceexception/) kivételek azt jelzik, hogy a képletet nem lehet normál módon feldolgozni.

**A diagram automatikusan frissül, ha egy képletcella változik?**

Egy diagram sorozat hivatkozhat munkafüzet‑cellákra. Először újra kell számolni a munkafüzetet, majd menteni vagy megjeleníteni a bemutatót. Ha a diagram adatpontjai a kiszámított cellákra mutatnak, a diagram ezeket a frissített értékeket használja; ehhez nincs szükség külön diagram‑frissítési metódusra.

**Használhatók külső Excel‑munkafüzetek diagramokhoz?**

Igen, a diagramadatok konfigurálhatók úgy, hogy külső munkafüzetet használjanak a diagram adat‑API‑ja segítségével. Azonban a jelen cikkben ismertetett képletszámítási munkafolyamat a diagram adatkönyvtárára és az Aspose.Slides által értékelt képlet‑részhalmazra vonatkozik. Ne feltételezze, hogy az [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) teljes újraszámítást végez tetszőleges képleteken egy külső XLSX‑fájlban.

**Használhatok olyan képleteket, amelyek másik munkalapra vagy munkafüzetre hivatkoznak?**

Az Excel‑stílusú hivatkozások előfordulhatnak diagram munkafüzetekben, de a képlet‑értékelés korlátozott a támogatott elemző és függvénykészlet miatt. Ha egy kereszt‑lap vagy külső hivatkozás létfontosságú, ellenőrizze, hogy a pontos képlet működik‑e az adott Aspose.Slides verzióval. Olyan munkafolyamatoknál, amelyek széles körű Excel‑hivatkozás‑kompatibilitást igényelnek, számítsa ki a munkafüzetet kívül, majd írja vissza a feloldott értékeket a diagramadatba.

**Kell a képlet‑szöveg `=` jellel kezdődjön?**

Az Aspose.Slides API példák a `B2-C2` vagy `SUM(B2:B5)` kifejezéseket nincs előtte `=` jel. Ezt a formát használva a generált képletek egyeznek a dokumentált API‑példákkal.