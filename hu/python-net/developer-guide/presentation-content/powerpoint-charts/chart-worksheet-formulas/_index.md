---
title: "Diagram munkalap képletek alkalmazása prezentációkban Python használatával"
linktitle: "Munkalap képletek"
type: docs
weight: 70
url: /hu/python-net/chart-worksheet-formulas/
keywords:
- diagram táblázat
- diagram munkalap
- diagram képlet
- munkalap képlet
- táblázat képlet
- diagram adatkönyv
- képlet számítás
- preferált kultúra
- kultúrára szabott képlet
- DBCS
- logikai állandó
- numerikus állandó
- szöveges állandó
- hiba állandó
- aritmetikai operátor
- összehasonlító operátor
- A1 stílus
- R1C1 stílus
- előre definiált függvény
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Alkalmazza az Excel-stílusú képleteket az Aspose.Slides for Python via .NET diagram munkalapokon, számolja újra az értékeket, és használja az eredményeket a PowerPoint diagramokban."
---
## **Áttekintés**

A PowerPoint diagramok általában beágyazott munkalapon tárolják a forrásadataikat. Az Aspose.Slides for Python via .NET segítségével elérheti ezt a munkalapot a diagram adatkönyvön keresztül, beírhat bemeneti értékeket, képleteket rendelhet cellákhoz, kiszámíthatja a támogatott képleteket, és a kiszámított cellákat diagram adatként használhatja.

Ez a cikk részletesen bemutatja a képlet-összes folyamatot: diagram létrehozása, a munkalap feltöltése, A1‑stílusú vagy R1C1‑stílusú képletek hozzárendelése, újraszámításuk, a kiszámított értékek olvasása, ezen cellák összekapcsolása diagram sorozattal, majd a prezentáció mentése. Emellett ismerteti a támogatott képletszintaxist, a beépített függvények részhalmazát, a gyorsítótárazott értékeket, a nem támogatott képleteket és a táblázatkezelő-specifikus hibákat.

## **Diagram munkalapok és képletek**

A diagram munkalap tartalmazza a diagram által használt kategóriákat, sorozatneveket és értékeket. PowerPointban a munkalapot a diagram adat szerkesztőjének megnyitásával vizsgálhatja meg:

![PowerPoint diagram beágyazott munkalappal megnyitva, a kategória és sorozat adataival](chart-worksheet-formulas_1.png)

Az Aspose.Slidesben a munkalap a [chart data workbook](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/ichartdataworkbook/) révén érhető el. Az A1‑stílusú képletekhez használja a [formula](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/ichartdatacell/formula/) tulajdonságot, a R1C1‑stílusú képletekhez a [r1c1_formula](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) tulajdonságot. A bemeneti cellák vagy képletek módosítása után hívja a [calculate_formulas](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) metódust a támogatott képletek újraszámításához és a megfelelő cellaértékek frissítéséhez.

Egy kiszámított cella továbbra is a [value](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/ichartdatacell/value/) tulajdonságán keresztül adja vissza az eredményt. Ez fontos, ha a kódban szeretné ellenőrizni a képlet eredményét vagy a cellát diagram adatpontként használni.

## **Diagram létrehozása és munkalapi képletek számítása**

Az alábbi példa egy vég‑től‑végig munkafolyamatot mutat be. Létrehoz egy csoportos oszlopdiagramot, törli a minta adatokat, beírja a negyedéves bevétel és kiadás értékeket, képletekkel számítja a profitot, kiolvassa az eredményeket, a kiszámított cellákat diagramértékekként használja, és elmenti a prezentációt.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 350)
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    workbook.clear(worksheet_index)

    category1 = workbook.get_cell(worksheet_index, "A2", "Q1")
    category2 = workbook.get_cell(worksheet_index, "A3", "Q2")
    category3 = workbook.get_cell(worksheet_index, "A4", "Q3")

    workbook.get_cell(worksheet_index, "B1", "Revenue")
    workbook.get_cell(worksheet_index, "C1", "Expenses")
    workbook.get_cell(worksheet_index, "D1", "Profit")

    workbook.get_cell(worksheet_index, "B2").value = 120.0
    workbook.get_cell(worksheet_index, "C2").value = 80.0
    workbook.get_cell(worksheet_index, "B3").value = 150.0
    workbook.get_cell(worksheet_index, "C3").value = 95.0
    workbook.get_cell(worksheet_index, "B4").value = 135.0
    workbook.get_cell(worksheet_index, "C4").value = 110.0

    profit1 = workbook.get_cell(worksheet_index, "D2")
    profit2 = workbook.get_cell(worksheet_index, "D3")
    profit3 = workbook.get_cell(worksheet_index, "D4")

    profit1.formula = "B2-C2"
    profit2.formula = "B3-C3"
    profit3.formula = "B4-C4"

    workbook.calculate_formulas()

    q1_profit = profit1.value  # 40
    q2_profit = profit2.value  # 55
    q3_profit = profit3.value  # 25

    print(f"Q1 profit: {q1_profit}")
    print(f"Q2 profit: {q2_profit}")
    print(f"Q3 profit: {q3_profit}")

    chart.chart_data.categories.add(category1)
    chart.chart_data.categories.add(category2)
    chart.chart_data.categories.add(category3)

    profit_series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, "D1"), chart.type)
    profit_series.data_points.add_data_point_for_bar_series(profit1)
    profit_series.data_points.add_data_point_for_bar_series(profit2)
    profit_series.data_points.add_data_point_for_bar_series(profit3)
    profit_series.labels.default_data_label_format.show_value = True

    presentation.save("chart-formulas.pptx", slides.export.SaveFormat.PPTX)
```

A diagram adatpontjai a `D2:D4` tartományra hivatkoznak, így a diagram a kiszámított profit értékeket használja. Ebben a munkafolyamatban nincs külön diagram‑frissítő hívás: először számolja újra a munkakönyvet, majd használja vagy mentse a diagram adatot, amely a kiszámított cellákra mutat.

## **A1‑stílusú képletek használata**

Az A1 jelölés oszlopokat betűkkel, sorokat számokkal azonosít. A A1‑stílusú kifejezéseket a [IChartDataCell.formula](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/ichartdatacell/formula/) segítségével adhatja meg.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "C3").value = 10
    workbook.get_cell(0, "F2").value = 2
    workbook.get_cell(0, "G2").value = 3
    workbook.get_cell(0, "H2").value = 4

    cell = workbook.get_cell(0, "A2")
    cell.formula = "C3+SUM(F2:H2)"

    workbook.calculate_formulas()

    value = cell.value  # 19
```

A gyakori A1 hivatkozási formák:

| Hivatkozás | Relatív | Abszolút | Vegyes |
|---|---|---|---|
| Cell | `A2` | `$A$2` | `A$2`, `$A2` |
| Row | `2:2` | `$2:$2` | — |
| Column | `A:A` | `$A:$A` | — |
| Range | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

A relatív hivatkozások a képlet mozgatásakor vagy másolásakor változhatnak. Az abszolút hivatkozások mindkét koordinátát rögzítik, míg a vegyes hivatkozások csak egy sort vagy egy oszlopot rögzítenek.

## **R1C1‑stílusú képletek használata**

Az R1C1 jelölés a sorokat és oszlopokat számmal azonosítja. A relatív hivatkozások szögletes zárójelben lévő eltolásokat használnak. Ezt a szintaxist a [IChartDataCell.r1c1_formula](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) segítségével adhatja meg.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "B2").value = 12
    workbook.get_cell(0, "C2").value = 5

    cell = workbook.get_cell(0, "D2")
    cell.r1c1_formula = "RC[-2]-RC[-1]"

    workbook.calculate_formulas()

    value = cell.value  # 7
```

A gyakori R1C1 hivatkozási formák:

| Hivatkozás | Relatív | Abszolút | Vegyes |
|---|---|---|---|
| Cell | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Row | `R[2]` | `R2` | — |
| Column | `C[3]` | `C3` | — |
| Range | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Például a `D2` cellában az `RC[-2]` azt jelenti, hogy ugyanabban a sorban két oszloppal balra lévő cella (`B2`).

## **Képlet állandók és operátorok**

A beépített képletértékelő támogatja a logikai értékeket, numerikus literálokat, szövegeket, táblázatkezelő hibákat, aritmetikai operátorokat és összehasonlító operátorokat.

### **Állandók és literálok**

| Típus | Példák | Megjegyzés |
|---|---|---|
| Logikai | `TRUE`, `FALSE` | Közvetlenül használható logikai kifejezésekben, például `A2=TRUE`. |
| Numerikus | `1`, `0.5`, `.3`, `1E-2` | A közönséges és a tudományos jelölés egyaránt támogatott. |
| Szöveg | `"abc"`, `"2/3/2020 12:00"` | A szövegliterálok dupla idézőjelesek a képleten belül. |
| Hiba eredmény | `#DIV/0!`, `#N/A`, `#REF!` | Egy érvényes képlet kiértékelhető táblázatkezelő hibaértékre a normál eredmény helyett. |

Ez a példa több állandó típust használ:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "A2").value = False
    workbook.get_cell(0, "B2").formula = "A2=TRUE"
    workbook.get_cell(0, "C2").formula = "1+0.5"
    workbook.get_cell(0, "D2").formula = ".3*1E-2"
    workbook.get_cell(0, "E2").formula = "\"abc\""
    workbook.get_cell(0, "F2").formula = "2/0"

    workbook.calculate_formulas()

    logical_value = workbook.get_cell(0, "B2").value  # Hamis
    numeric_value = workbook.get_cell(0, "C2").value  # 1.5
    scientific_value = workbook.get_cell(0, "D2").value  # 0.003
    string_value = workbook.get_cell(0, "E2").value  # abc
    error_value = workbook.get_cell(0, "F2").value  # #DIV/0!
```

### **Aritmetikai operátorok**

| Operátor | Jelentés | Példa |
|---|---|---|
| `+` | Összeadás vagy unáris plusz | `2+3` |
| `-` | Kivonás vagy negatív | `2-3`, `-3` |
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

## **Támogatott előre definiált függvények**

Az Aspose.Slides beépített képletértékelővel rendelkezik diagram munkalapokhoz, de nem egy teljes Excel számítási motor. A dokumentált függvénykészlet a következőkre korlátozódik. Ne feltételezze, hogy tetszőleges Excel függvényt újra tud számolni a [calculate_formulas](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) metódus.

| Függvény | Leírás vagy támogatott forma | Példa |
|---|---|---|
| `ABS` | Abszolút érték | `ABS(A2)` |
| `AVERAGE` | Aritmetikai közép | `AVERAGE(B2:B5)` |
| `CEILING` | Felfelé kerekítés egy többszörösre | `CEILING(A2,5)` |
| `CHOOSE` | Érték kiválasztása index alapján | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Szövegek összefűzése | `CONCAT(A2,B2)` |
| `CONCATENATE` | Szövegek összefűzése | `CONCATENATE(A2," ",B2)` |
| `DATE` | Dátum érték létrehozása a 1900-as dátumrendszerrel | `DATE(2026,8,19)` |
| `DAYS` | Napok száma két dátum között | `DAYS(B2,A2)` |
| `FIND` | Egy szövegrészlet keresése egy másikban | `FIND("-",A2)` |
| `FINDB` | Byte‑orientált szövegkeresés | `FINDB("a",A2)` |
| `IF` | Feltételes eredmény | `IF(A2>0,A2,0)` |
| `INDEX` | Referencia forma | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektor forma | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektor forma | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximum érték | `MAX(B2:B5)` |
| `SUM` | Összeg | `SUM(B2:B5)` |
| `VLOOKUP` | Függőleges keresés | `VLOOKUP(A2,B2:D10,3,FALSE)` |

A táblázatban feltüntetett korlátozások lényegesek: az `INDEX` referencia formában van dokumentálva, míg a `LOOKUP` és a `MATCH` vektor formában. A `DATE` a 1900‑as dátumrendszert használja. A listán kívüli funkciók és jellemzők a Aspose.Slides képletértékelő által nem támogatottként kezelendők, hacsak nincs külön dokumentációjuk.

## **Képletek számítása preferált kultúrával**

Néhány munkakönyvi funkció a szöveget kultúra‑specifikus szabályok szerint értelmezi. Ez különösen fontos a dupla‑bájtos karakterkészletet (DBCS) használó nyelvek esetén. Az ilyen képletek helyes számításához hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides/loadoptions/) objektumot, állítsa be a [SpreadsheetOptions.preferred_culture](https://reference.aspose.com/slides/hu/python-net/aspose.slides/spreadsheetoptions/) értékét a [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/hu/python-net/aspose.slides/loadoptions/spreadsheet_options/) segítségével, majd töltse be a prezentációt.

Az alábbi példa a japán kultúrát választja, a konfigurált betöltési beállításokkal megnyit egy prezentációt, és a [ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) metódust hívja minden diagram munkakönyvre:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

load_options = slides.LoadOptions()
load_options.spreadsheet_options.preferred_culture = "ja-JP"

with slides.Presentation("presentation.pptx", load_options) as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, charts.Chart):
                shape.chart_data.chart_data_workbook.calculate_formulas()
```

A preferált kultúra a prezentáció betöltési konfiguráció része, ezért a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) példány létrehozása előtt állítsa be. Használja azt a kultúrát, amelyet a munkakönyvi képletek elvárnak; például a japán DBCS szabályokhoz a `ja-JP` értéket kell megadni.

## **Újraszámítás és gyorsítótárazott értékek**

A táblázatfájlok gyakran tárolják a képletet és az utolsó számított értékét is. Az Aspose.Slides ezért a [IChartDataCell.value](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/ichartdatacell/value/) tulajdonságból olvas gyorsítótárazott értéket, ha a prezentáció betöltésekor a vonatkozó diagram adat nem változott.

A bemeneti cellák vagy képletek módosítása után ne bízzon meg egy régi gyorsítótárazott eredményben. Hívja a [ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) metódust a kiszámított értékek olvasása vagy a diagram adat mentése előtt, amely ezekre a cellákra támaszkodik.

A támogatott halmazon kívüli képletek esetén az Aspose.Slides előfordulhat, hogy nem tudja értelmezni a képletet vagy annak függőségeit. Ha a munkakönyv módosult, a korábbi gyorsítótárazott érték már nem tekinthető megbízhatónak. Ilyen helyzetben egy nem támogatott adatú cella értékének olvasása a [CellUnsupportedDataException](https://reference.aspose.com/slides/hu/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/) kivételt váltja ki.

Ha diagramja olyan Excel‑függvényeket használ, amelyeket az Aspose.Slides nem értékel ki, számolja ki ezeket a képleteket egy olyan táblázatkezelő motorral, amely támogatja őket, és írja vissza a kapott értékeket a diagram munkakönyvébe. Ne helyettesítse a nem támogatott képleteket találgatott értékekkel.

## **Képlet hibáinak kezelése**

Két különböző problématípust kell megkülönböztetni.

Egy képlet lehet érvényes, de táblázatkezelő hibát eredményez, például `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` vagy `#VALUE!`. Ebben az esetben a hiba token a cella eredménye, és a `value`‑on keresztül visszakapcsolható.

Egy képlet a feldolgozás, hivatkozás, függőség vagy támogatott adat szintjén is hibát jelezhet. Az Aspose.Slides ezekre az esetekre táblázatkezelő‑specifikus kivételeket biztosít: [CellInvalidFormulaException](https://reference.aspose.com/slides/hu/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/hu/python-net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/hu/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/) és [CellUnsupportedDataException](https://reference.aspose.com/slides/hu/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Ha a képletek sablonokból vagy felhasználói bemenetből származnak, kezelje ezeket a kivételeket az újraszámítás és az érték elérése körül:

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.slides.spreadsheet as spreadsheet

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook
    cell = workbook.get_cell(0, "A2")
    cell.formula = "SUM(B2:B5)"

    try:
        workbook.calculate_formulas()
        print(cell.value)
    except spreadsheet.CellInvalidFormulaException as ex:
        print(f"Invalid formula: {ex}")
    except spreadsheet.CellInvalidReferenceException as ex:
        print(f"Invalid cell reference: {ex}")
    except spreadsheet.CellCircularReferenceException as ex:
        print(f"Circular reference: {ex}")
    except spreadsheet.CellUnsupportedDataException as ex:
        print(f"Unsupported spreadsheet data: {ex}")
```

## **Gyakorlati korlátozások**

A diagram munkalapok képletsupportja egy meghatározott részhalmazra vonatkozik, nem pedig a teljes Excel kompatibilitásra. Tartsa szem előtt ezeket a korlátokat a jelentéskészítési munkafolyamat tervezésekor:

- Csak a dokumentált állandókat, operátorokat, hivatkozásokat és függvényeket használja, ha azt szeretné, hogy az Aspose.Slides újraszámolja a képleteket.
- Újraszámítás a cellák módosítása után, amelyeken a képlet eredménye függ.
- Tekintse a betöltött prezentációkból származó gyorsítótárazott értékeket pillanatfelvételeknek, ne pedig újraszámítás helyettesítőinek módosítások után.
- Tesztelje a sablonokból származó képleteket, mielőtt a kiszámított értékekre támaszkodna, különösen, ha a dokumentált listán kívüli függvényeket tartalmaznak.
- Azoknál a képleteknél, amelyek teljes táblázatkezelő számítási motorra támaszkodnak, számolja ki őket külsőleg, majd frissítse a diagram munkakönyvét a kapott értékekkel.

## **GYIK**

**Mi a különbség a `formula` és az `r1c1_formula` között?**

[formula](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/ichartdatacell/formula/) A1‑stílusú kifejezést, például `B2-C2` tárol. [r1c1_formula](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) R1C1‑stílusú kifejezést, például `RC[-2]-RC[-1]` tárol. A címzésnek leginkább azt válassza, amelyik a képletek generálásához vagy másolásához illeszkedik.

**A számítás után a cellát vagy annak értékét kell olvasnom?**

[ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) egy `IChartDataCell`‑et ad vissza. A kiszámított eredményhez olvassa el ennek a cellának a [value](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/ichartdatacell/value/) tulajdonságát az újraszámítás után.

**Mikor kell meghívni a `calculate_formulas`‑t?**

Hívja a [calculate_formulas](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) metódust a bemeneti értékek vagy képletek módosítása után, és még az előtt, hogy a kiszámított eredményeket felhasználná. Ez frissíti a beépített értékelő által támogatott képletek értékeit.

**Támogatja az Aspose.Slides minden Excel‑függvényt?**

Nem. A beépített értékelő csak egy dokumentált részhalmazt támogat. A részhalmazon kívüli függvények nem számolhatók újra. Ha teljes Excel képlet kompatibilitásra van szükség, végezze el a számítást egy megfelelő táblázatkezelő motorral, és írja be a végső értékeket a diagram munkakönyvébe.

**Mi történik, ha egy betöltött prezentáció nem támogatott képletet tartalmaz?**

Ha a diagram adat nem változott, a munkakönyv még mindig tartalmazhatja a korábban kiszámított gyorsítótárazott értéket. A kapcsolódó adatok módosítása után ez az érték már nem lehet érvényes. Egy olyan cella elérése, amelynek képlete nem kezelhető, a [CellUnsupportedDataException](https://reference.aspose.com/slides/hu/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/) kivételt váltja ki.

**Ugyanazok-e a képlet hibák és a Python kivételek?**

Nem. A `#DIV/0!`‑hoz hasonló eredmény egy táblázatkezelő érték, amely egy érvényes számításból származik. A [CellInvalidFormulaException](https://reference.aspose.com/slides/hu/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/) vagy [CellCircularReferenceException](https://reference.aspose.com/slides/hu/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/) kivételek arra utalnak, hogy a képletet nem lehet normál módon feldolgozni.

**Frissül automatikusan a diagram, ha egy képlet cella megváltozik?**

Egy diagram sorozat hivatkozhat munkakönyvi cellákra. Először számolja újra a munkakönyvet, majd mentse vagy renderelje a prezentációt. Ha a diagram adatpontjai a kiszámított cellákra mutatnak, a diagram az új cellaértékekkel frissül; nincs szükség külön diagram‑frissítő metódusra ebben a munkafolyamatban.

**Használhatók külső Excel munkakönyvek diagramokhoz?**

Igen, a diagram adat konfigurálható külső munkakönyv használatára a diagram adat API‑val. Azonban ebben a cikkben leírt képletszámítási munkafolyamat csak a diagram adatkönyvre és az Aspose.Slides által értékelt képletszegmensre vonatkozik. Ne feltételezze, hogy a [calculate_formulas](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) teljes újraszámítást végez tetszőleges képleteken egy külső XLSX fájlban.

**Használhatók olyan képletek, amelyek másik munkalapra vagy munkakönyvre hivatkoznak?**

Excel‑stílusú hivatkozások létezhetnek a diagram munkakönyvekben, de a képletértékelés korlátozott a támogatott elemző és függvénykészlet által. Ha egy kereszt‑lap vagy külső hivatkozás elengedhetetlen, ellenőrizze a képletet a saját Aspose.Slides verziójával. Azoknál a munkafolyamatoknál, amelyek széles Excel hivatkozási kompatibilitást igényelnek, számolja ki a munkakönyvet külsőleg, és írja vissza a feloldott értékeket a diagram adatba.

**Kell-e `=`‑vel kezdeni a képlet karakterláncát?**

Az Aspose.Slides API példák a `B2-C2` vagy `SUM(B2:B5)` kifejezéseket egyenlőségjel nélkül adják meg. Az ilyen forma használata biztosítja, hogy a generált képletek összhangban legyenek a dokumentált API példákkal.