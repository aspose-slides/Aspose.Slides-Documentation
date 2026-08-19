---
title: "Diagram munkalap képletek alkalmazása prezentációkban Python-nal"
linktitle: "Munkalap képletek"
type: docs
weight: 70
url: /hu/python-net/chart-worksheet-formulas/
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
- "szöveg állandó"
- "hiba állandó"
- "aritmetikai operátor"
- "összehasonlító operátor"
- "A1 stílus"
- "R1C1 stílus"
- "előre definiált függvény"
- "PowerPoint"
- "prezentáció"
- "Python"
- "Aspose.Slides"
description: "Alkalmazzon Excel stílusú képleteket az Aspose.Slides for Python via .NET diagram munkalapokon, számolja újra az értékeket, és használja az eredményeket PowerPoint diagramokban."
---
## **Áttekintés**

A PowerPoint diagramok általában beágyazott munkalapon tárolják a forrásadataikat. Az Aspose.Slides for Python via .NET használatával a diagramadatok munkafüzetén keresztül érheti el ezt a munkalapot, írhat beviteli értékeket, rendelhet képleteket a cellákhoz, kiszámíthatja a támogatott képleteket, és a kiszámított cellákat diagramadatként használhatja.

Ez a cikk részletesen bemutatja a képlet-munkafolyamatot: diagram létrehozása, a munkalap feltöltése, A1-stílusú vagy R1C1-stílusú képletek hozzárendelése, azok újraszámítása, a kiszámított értékek olvasása, a cellák diagram sorozathoz kapcsolása és a bemutató mentése. Emellett leírja a támogatott képletszintaxist, a beépített függvényrészhalmazt, a gyorsítótárazott értékeket, a nem támogatott képleteket és a táblázatkezelő-specifikus hibákat.

## **Diagram munkalapok és képletek**

A diagram munkalap a diagram által használt kategóriákat, sorozatneveket és értékeket tartalmazza. PowerPointban a munkalapot megtekintheti a diagram adat szerkesztőjének megnyitásával:

![PowerPoint diagram beágyazott munkalappal nyitva, kategória és sorozat adatok megjelenítve](chart-worksheet-formulas_1.png)

Aspose.Slidesben a munkalap a [chart data workbook](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/ichartdataworkbook/) révén érhető el. Az A1-stílusú képletekhez használd a [formula](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/ichartdatacell/formula/) tulajdonságot, a R1C1-stílusú képletekhez a [r1c1_formula](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) tulajdonságot. A bemeneti cellák vagy képletek módosítása után hívd meg a [calculate_formulas](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) metódust a támogatott képletek újraszámításához és a megfelelő cellaértékek frissítéséhez.

A kiszámított cella továbbra is a [value](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/ichartdatacell/value/) tulajdonságon keresztül adja vissza az eredményt. Ez fontos, ha a kódban ki kell vizsgálnod egy képlet eredményét vagy a cellát diagramadat-pontként szeretnéd használni.

## **Diagram létrehozása és munkalap képletek számítása**

A következő példa egy végponttól végpontig tartó munkafolyamatot mutat be. Létrehoz egy klaszterezett oszlopdiagramot, törli a mintaadatokat, beírja a negyedéves bevétel és kiadás értékeket, képletekkel kiszámítja a profitot, elolvassa az eredményeket, a kiszámított cellákat diagramértékekként használja, és elmenti a bemutatót.

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

A diagram adatpontjai a `D2:D4` tartományra hivatkoznak, így a diagram a kiszámított profit értékeket használja. Ebben a munkafolyamatban nincs külön diagramfrissítő hívás: először számold újra a munkafüzetet, majd használd vagy mentse a diagramadatokat, amelyek a kiszámított cellákra mutatnak.

## **A1-stílusú képletek használata**

Az A1 jelölés betűkkel azonosítja az oszlopokat és számokkal a sorokat. Az A1-stílusú kifejezéseket a [IChartDataCell.formula](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/ichartdatacell/formula/) segítségével adhatod meg.

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

Common A1 reference forms are:

| Referencia | Relatív | Abszolút | Vegyes |
|---|---|---|---|
| Cell | `A2` | `$A$2` | `A$2`, `$A2` |
| Row | `2:2` | `$2:$2` | — |
| Column | `A:A` | `$A:$A` | — |
| Range | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

A relatív hivatkozások megváltozhatnak, amikor egy képletet egy táblázatkezelő alkalmazás mozgat vagy másol. Az abszolút hivatkozások mindkét koordinátát rögzítik, míg a vegyes hivatkozások csak egy sort vagy egy oszlopot rögzítenek.

## **R1C1-stílusú képletek használata**

Az R1C1 jelölés számokkal azonosítja a sorokat és oszlopokat. A relatív hivatkozások szögletes zárójelekben definiált eltolásokat használnak. A szintaxist a [IChartDataCell.r1c1_formula](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) segítségével adhatod meg.

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

Common R1C1 reference forms are:

| Referencia | Relatív | Abszolút | Vegyes |
|---|---|---|---|
| Cell | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Row | `R[2]` | `R2` | — |
| Column | `C[3]` | `C3` | — |
| Range | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Például a `D2` cellában a `RC[-2]` azt jelenti, hogy a sorban két oszloppal balra lévő cella (`B2`).

## **Képlet állandók és operátorok**

A beépített képletértékelő támogatja a logikai értékeket, numerikus literálokat, karakterláncokat, táblázathibák értékét, aritmetikai operátorokat és összehasonlító operátorokat.

### **Állandók és literálok**

| Típus | Példák | Megjegyzés |
|---|---|---|
| Logikai | `TRUE`, `FALSE` | Közvetlenül használható logikai kifejezésekben, például `A2=TRUE`. |
| Numerikus | `1`, `0.5`, `.3`, `1E-2` | A közös és a tudományos jelölés támogatott. |
| Karakterlánc | `"abc"`, `"2/3/2020 12:00"` | A szöveges literálok dupla idézőjelek között szerepelnek a képleten belül. |
| Hiba eredmény | `#DIV/0!`, `#N/A`, `#REF!` | Egy érvényes képlet táblázathiba értékre is kiértékelhető a normál eredmény helyett. |

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

    logical_value = workbook.get_cell(0, "B2").value  # False
    numeric_value = workbook.get_cell(0, "C2").value  # 1.5
    scientific_value = workbook.get_cell(0, "D2").value  # 0.003
    string_value = workbook.get_cell(0, "E2").value  # abc
    error_value = workbook.get_cell(0, "F2").value  # #DIV/0!
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

Zárójelek használatával teheted egyértelművé az értékelés sorrendjét, például `(A2+B2)*C2`.

### **Összehasonlító operátorok**

Az összehasonlító kifejezések logikai értéket adnak vissza.

| Operátor | Jelentés | Példa |
|---|---|---|
| `=` | Egyenlő | `A2=3` |
| `<>` | Nem egyenlő | `A2<>3` |
| `>` | Nagyobb, mint | `A2>3` |
| `>=` | Nagyobb vagy egyenlő | `A2>=3` |
| `<` | Kisebb, mint | `A2<3` |
| `<=` | Kisebb vagy egyenlő | `A2<=3` |

## **Támogatott előre definiált függvények**

Aspose.Slides beépített képletértékelőt tartalmaz a diagram munkalapokhoz, de nem egy teljes Excel számítási motor. A dokumentált függvénykészlet csak az alábbi függvényekre korlátozódik. Ne feltételezd, hogy egy tetszőleges Excel függvény újraszámítható a [calculate_formulas](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) segítségével.

| Függvény | Cél vagy támogatott forma | Példa |
|---|---|---|
| `ABS` | Abszolút érték | `ABS(A2)` |
| `AVERAGE` | Aritmetikai közép | `AVERAGE(B2:B5)` |
| `CEILING` | Szám kerekítése felfelé egy többszörösre | `CEILING(A2,5)` |
| `CHOOSE` | Érték kiválasztása index alapján | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Szöveges értékek összefűzése | `CONCAT(A2,B2)` |
| `CONCATENATE` | Szöveges értékek összefűzése | `CONCATENATE(A2," ",B2)` |
| `DATE` | Dátumérték létrehozása a 1900-as dátumrendszerrel | `DATE(2026,8,19)` |
| `DAYS` | A dátumok közötti napok számának visszaadása | `DAYS(B2,A2)` |
| `FIND` | Szövegrész keresése egy másikban | `FIND("-",A2)` |
| `FINDB` | Byte-orientált szövegkeresés | `FINDB("a",A2)` |
| `IF` | Feltételes eredmény | `IF(A2>0,A2,0)` |
| `INDEX` | Referencia forma | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektorlés forma | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektorlés forma | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximum érték | `MAX(B2:B5)` |
| `SUM` | Értékek összege | `SUM(B2:B5)` |
| `VLOOKUP` | Függőleges keresés | `VLOOKUP(A2,B2:D10,3,FALSE)` |

A táblázatban szereplő korlátozások jelentősek: az `INDEX` referencia formában van dokumentálva, míg a `LOOKUP` és `MATCH` vektoros formában. A `DATE` a 1900-as dátumrendszert használja. Az itt nem felsorolt funkciókat és jellemzőket az Aspose.Slides képletértékelő nem támogatja, hacsak külön nem dokumentáltak.

## **Újraszámítás és gyorsítótárazott értékek**

A táblázatfájlok általában a képletet és annak legutóbbi kiszámított értékét is tárolják. Az Aspose.Slides ezért képes a [IChartDataCell.value] gyorsítótárazott értékét beolvasni, amikor a bemutató betöltődik és a vonatkozó diagramadatok nem változtak.

A bemeneti cellák vagy képletek módosítása után ne bízz a régi gyorsítótárazott eredményben. Hívd meg a [ChartDataWorkbook.calculate_formulas] metódust, mielőtt a kiszámított értékeket olvasnád vagy a rájuk támaszkodó diagramadatokat mentenéd.

A támogatott részhalmazon kívül eső képletek esetén az Aspose.Slides előfordulhat, hogy nem tudja értelmezni a képletet vagy a függőségeket. Ha a munkafüzetet módosították, a korábbi gyorsítótárazott érték már nem tekinthető megbízhatónak. Ebben az esetben egy nem támogatott adatú cella értékének olvasása [CellUnsupportedDataException] kivételt válthat ki.

Ha a diagramod olyan Excel függvényekre támaszkodik, amelyeket az Aspose.Slides nem értékel, számold ki ezeket a képleteket egy olyan táblázatkezelő motorral, amely támogatja őket, és írd vissza a kapott értékeket a diagram munkafüzetébe. Ne cseréld le a nem támogatott képleteket tippelt értékekkel.

## **Képlet hibák kezelése**

Két különböző problématípust kell megkülönböztetni.

Egy képlet érvényes lehet, de táblázathiba eredményt adhat, például `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` vagy `#VALUE!`. Ebben az esetben a hiba token cellaeredmény, és a `value` segítségével visszaadható.

Egy képlet a feldolgozás, hivatkozás, függőség vagy támogatott adat szintjén is hibát okozhat. Az Aspose.Slides ezekre az esetekre táblázatkezelő-specifikus kivételeket biztosít: [CellInvalidFormulaException], [CellInvalidReferenceException], [CellCircularReferenceException] és [CellUnsupportedDataException].

Amikor a képletek sablonokból vagy felhasználói bemenetből származnak, kezeld ezeket a kivételeket az újraszámítás és az értéklekérés körül:

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

## **Gyakorlati korlátok**

A diagram munkalapok képlet-támogatása egy meghatározott részhalmazú táblázatszámításra szánt, nem a teljes Excel kompatibilitásra. Tartsd szem előtt ezeket a korlátokat jelentéskészítő munkafolyamatok tervezésekor:

- Használd csak a dokumentált állandókat, operátorokat, hivatkozásokat és függvényeket, amikor az Aspose.Slidesnek kell újraszámítania a képleteket.
- Újraszámítás a képletek eredményeit befolyásoló cellák módosítása után.
- A betöltött bemutatók gyorsítótárazott értékeit tekintsd pillanatképeknek, nem a módosítások utáni újraszámítás helyettesítőjének.
- Teszteld a meglévő sablonok képleteit, mielőtt a kiszámított értékekre támaszkodnál, különösen ha úgy dokumentált listán kívüli függvényeket használnak.
- A teljes táblázatkezelő motorra igénylő képleteket számold ki külsőleg, majd a diagram munkafüzetét frissítsd a kapott értékekkel.

## **GYIK**

**Mi a különbség a `formula` és az `r1c1_formula` között?**

`formula` A1-stílusú kifejezést tárol, például `B2-C2`. `r1c1_formula` R1C1-stílusú kifejezést tárol, például `RC[-2]-RC[-1]`. Használd azt a jelölést, amely leginkább megfelel a képletek generálásához vagy másolásához.

**Olvasnom kell a cellát magát vagy az értékét a számítás után?**

`ChartDataWorkbook.get_cell` egy `IChartDataCell` objektumot ad vissza. A kiszámított eredményhez a cella `value` tulajdonságát kell elolvasni az újraszámítás után.

**Mikor kell meghívni a `calculate_formulas` metódust?**

Hívd meg a `calculate_formulas` metódust a bemeneti értékek vagy képletek módosítása után, és mielőtt a kiszámított eredményektől függnél. Ez frissíti a beépített értékelő által támogatott képletek értékeit.

**Az Aspose.Slides minden Excel függvényt támogat?**

Nem. A beépített értékelő csak egy dokumentált függvényrészhalmazt támogat. A részhalmazon kívüli függvények helyes újraszámítását nem szabad feltételezni. Ha teljes Excel képlet kompatibilitásra van szükség, végezd el a számítást egy megfelelő táblázatkezelő motorral, és írd vissza a végső értékeket a diagram munkafüzetébe.

**Mi történik, ha egy betöltött bemutató nem támogatott képletet tartalmaz?**

Ha a diagramadatok nem változtak, a munkafüzet tartalmazhatja a korábban kiszámított gyorsítótárazott értéket. A kapcsolódó adatok módosítása után ez a gyorsítótárazott érték már nem lehet érvényes. Egy olyan cellához való hozzáférés, amelynek képletét a rendszer nem tudja kezelni, [CellUnsupportedDataException] kivételt válthat ki.

**Ugyanazok-e a képlet hibaértékek és a Python kivételek?**

Nem. A `#DIV/0!`-hoz hasonló eredmény egy táblázatkezelő érték, amely egy érvényes számításból származik. A [CellInvalidFormulaException] vagy [CellCircularReferenceException] típusú kivételek azt jelzik, hogy a képletet nem lehet normál módon feldolgozni.

**Frissül automatikusan a diagram, ha egy képletcellát módosítanak?**

Egy diagram sorozat hivatkozhat a munkafüzet celláira. Először számold újra a munkafüzetet, majd mentsd vagy rendereld a bemutatót. Ha a diagram adatpontjai a kiszámított cellákra mutatnak, a diagram azokat a frissített cellaértékeket használja; ehhez a munkafolyamathoz nem szükséges külön diagram-frissítő metódus.

**Használhatnak a diagramok külső Excel munkafüzetet?**

Igen, a diagramadatok konfigurálhatók úgy, hogy külső munkafüzetet használjanak a diagram adat API-n keresztül. Azonban ebben a cikkben leírt képletszámítási munkafolyamat a diagram adat munkafüzetre és az Aspose.Slides által értékelt képletszámhalmazra vonatkozik. Ne feltételezd, hogy a [calculate_formulas] teljes újraszámítást biztosít tetszőleges képletekre egy külső XLSX fájlban.

**Használhatok képleteket, amelyek másik munkalapra vagy munkafüzetre hivatkoznak?**

Excel-stílusú hivatkozások előfordulhatnak a diagram munkafüzetekben, de a képletértékelés a támogatott elemző és függvénykészlet által korlátozott. Ha egy keresztlapon vagy külső hivatkozás elengedhetetlen, ellenőrizd az adott képletet a cél Aspose.Slides verzióval. Azokra a munkafolyamatokra, amelyek széles körű Excel hivatkozás-kompatibilitást igényelnek, a munkafüzetet külsőleg számold ki, és írd vissza a megoldott értékeket a diagram adatokba.

**Kell-e a képletsztringeknek `=` jellel kezdődniük?**

Az Aspose.Slides API példák kifejezéseket adnak meg, például `B2-C2` vagy `SUM(B2:B5)`, anélkül, hogy a `=` előjel lenne elöl. Ennek a formának a használata biztosítja, hogy a generált képletek egyezzenek a dokumentált API példákkal.