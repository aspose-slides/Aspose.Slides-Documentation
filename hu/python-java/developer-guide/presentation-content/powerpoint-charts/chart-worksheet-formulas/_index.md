---
title: "Munkalap képletek alkalmazása diagramokhoz prezentációkban Python via Java"
linktitle: "Munkalap képletek"
type: docs
weight: 70
url: /hu/python-java/chart-worksheet-formulas/
keywords:
- diagram táblázat
- diagram munkalap
- diagram képlet
- munkalap képlet
- táblázati képlet
- diagram adatkönyvtár
- képlet számítás
- preferált kultúra
- kultúraspecifikus képlet
- DBCS
- logikai állandó
- numerikus állandó
- szöveg állandó
- hiba állandó
- aritmetikai operátor
- összehasonlító operátor
- A1 stílus
- R1C1 stílus
- előre definiált függvény
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Alkalmazzon Excel-stílusú képleteket az Aspose.Slides for Python via Java diagram munkalapokon, számolja újra az értékeket, és használja az eredményeket a PowerPoint diagramokban."
---
## **Áttekintés**

A PowerPoint-diagramok általában a forrásadataikat egy beágyazott munkalapon tárolják. Az Aspose.Slides for Python via Java segítségével elérhető ez a munkalap a diagram adatkönyvtárán keresztül, beírhatja a bemeneti értékeket, képleteket adhat cellákhoz, számíthatja a támogatott képleteket, és a kiszámított cellákat diagramadatként használhatja.

Ez a cikk bemutatja a teljes képlet-munkafolyamatot: diagram létrehozása, annak munkalapjának feltöltése, A1‑stílusú vagy R1C1‑stílusú képletek hozzárendelése, újraszámítása, a kiszámított értékek kiolvasása, a cellák diagram‐sorozathoz kapcsolása, és a prezentáció mentése. Továbbá ismerteti a támogatott képletszintaxist, a beépített függvényrészletet, a gyorsítótárazott értékeket, a nem támogatott képleteket és a táblázat‑specifikus hibákat.

## **Diagrammunkalapok és képletek**

Egy diagrammunkalap tartalmazza a kategóriákat, sorozatneveket és értékeket, amelyeket a diagram használ. PowerPointban a munkalapot a diagram adatkezelő szerkesztőjének megnyitásával vizsgálhatja meg:

![PowerPoint diagram a beágyazott munkalappal nyitva, kategória‑ és sorozatadatok mutatva](chart-worksheet-formulas_1.png)

Az Aspose.Slides-ban a munkalap a [ChartDataWorkbook](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdataworkbook/) osztályon keresztül érhető el. A‑1‑stílusú képletekhez használja a [ChartDataCell.setFormula](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatacell/#setFormula) metódust, a R1C1‑stílusúakhoz a [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatacell/#setR1C1Formula) metódust. A bemeneti cellák vagy képletek módosítása után hívja a [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) metódust a támogatott képletek újraszámításához és a megfelelő cellaértékek frissítéséhez.

Egy kiszámított cella az eredményét továbbra is a [ChartDataCell.getValue](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatacell/#getValue) metódussal adja vissza. Ez fontos, ha a kódon belül képlet‑eredményt kell ellenőrizni vagy a cellát diagramadat‑pontként használni.

## **Diagram létrehozása és a munkalap képleteinek számítása**

Az alábbi példa egy végponttól‑végpontig tartó munkafolyamatot mutat be. Létrehoz egy csoportosított oszlopdiagramot, törli a mintaadatokat, beírja a negyedéves bevétel‑ és kiadásértékeket, képletekkel kiszámolja a profitot, kiolvassa az eredményeket, a kiszámított cellákat diagramértékként használja, és menti a prezentációt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 350)
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    workbook.clear(worksheet_index)

    category1 = workbook.getCell(worksheet_index, "A2", "Q1")
    category2 = workbook.getCell(worksheet_index, "A3", "Q2")
    category3 = workbook.getCell(worksheet_index, "A4", "Q3")

    workbook.getCell(worksheet_index, "B1", "Revenue")
    workbook.getCell(worksheet_index, "C1", "Expenses")
    workbook.getCell(worksheet_index, "D1", "Profit")

    workbook.getCell(worksheet_index, "B2").setValue(120.0)
    workbook.getCell(worksheet_index, "C2").setValue(80.0)
    workbook.getCell(worksheet_index, "B3").setValue(150.0)
    workbook.getCell(worksheet_index, "C3").setValue(95.0)
    workbook.getCell(worksheet_index, "B4").setValue(135.0)
    workbook.getCell(worksheet_index, "C4").setValue(110.0)

    profit1 = workbook.getCell(worksheet_index, "D2")
    profit2 = workbook.getCell(worksheet_index, "D3")
    profit3 = workbook.getCell(worksheet_index, "D4")

    profit1.setFormula("B2-C2")
    profit2.setFormula("B3-C3")
    profit3.setFormula("B4-C4")

    workbook.calculateFormulas()

    q1_profit = float(profit1.getValue()) # 40
    q2_profit = float(profit2.getValue()) # 55
    q3_profit = float(profit3.getValue()) # 25

    print("Q1 profit: ", q1_profit)
    print("Q2 profit: ", q2_profit)
    print("Q3 profit: ", q3_profit)

    chart.getChartData().getCategories().add(category1)
    chart.getChartData().getCategories().add(category2)
    chart.getChartData().getCategories().add(category3)

    profit_series = chart.getChartData().getSeries().add(workbook.getCell(worksheet_index, "D1"), chart.getType())
    profit_series.getDataPoints().addDataPointForBarSeries(profit1)
    profit_series.getDataPoints().addDataPointForBarSeries(profit2)
    profit_series.getDataPoints().addDataPointForBarSeries(profit3)
    profit_series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("chart-formulas.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A diagram adatpontjai a `D2:D4` tartományra hivatkoznak, így a diagram a kiszámított profitértékeket használja. Ebben a munkafolyamatban nincs külön diagram‑frissítési hívás: először számolja újra a munkafüzetet, majd használja vagy mentse a számított cellákra mutató diagramadatokat.

## **A1‑stílusú képletek használata**

Az A1‑notáció a oszlopokat betűkkel, a sorokat számokkal jelöli. A‑1‑stílusú kifejezéseket a [ChartDataCell.setFormula](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatacell/#setFormula) metódus segítségével adhatja meg.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "C3").setValue(10)
    workbook.getCell(0, "F2").setValue(2)
    workbook.getCell(0, "G2").setValue(3)
    workbook.getCell(0, "H2").setValue(4)

    cell = workbook.getCell(0, "A2")
    cell.setFormula("C3+SUM(F2:H2)")

    workbook.calculateFormulas()

    value = cell.getValue() # 19
finally:
    presentation.dispose()
```

Gyakori A1 hivatkozási formák:

| Hivatkozás | Relatív | Abszolút | Vegyes |
|---|---|---|---|
| Cella | `A2` | `$A$2` | `A$2`, `$A2` |
| Sor | `2:2` | `$2:$2` | — |
| Oszlop | `A:A` | `$A:$A` | — |
| Tartomány | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

A relatív hivatkozások megváltozhatnak, ha egy képletet egy táblázatkezelő alkalmazás áthelyez vagy másol. Az abszolút hivatkozások mindkét koordinátát rögzítik, míg a vegyes hivatkozások csak egy sort vagy egy oszlopot rögzítenek.

## **R1C1‑stílusú képletek használata**

Az R1C1‑notáció sorokat és oszlopokat is számmal jelöli. A relatív hivatkozások négyzetes zárójelekben lévő eltolásokat használnak. Ezt a szintaxist a [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatacell/#setR1C1Formula) metódussal adhatja meg.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "B2").setValue(12)
    workbook.getCell(0, "C2").setValue(5)

    cell = workbook.getCell(0, "D2")
    cell.setR1C1Formula("RC[-2]-RC[-1]")

    workbook.calculateFormulas()

    value = cell.getValue() # 7
finally:
    presentation.dispose()
```

Gyakori R1C1 hivatkozási formák:

| Hivatkozás | Relatív | Abszolút | Vegyes |
|---|---|---|---|
| Cella | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Sor | `R[2]` | `R2` | — |
| Oszlop | `C[3]` | `C3` | — |
| Tartomány | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Például a `D2` cellában az `RC[-2]` azt jelenti, hogy a ugyanabban a sorban két oszloppal balra lévő cella (`B2`).

## **Képlet‑állandók és operátorok**

A beépített képlet‑értékelő logikai értékeket, numerikus literálokat, szövegeket, táblázat‑hibákat, aritmetikai operátorokat és összehasonlító operátorokat támogat.

### **Állandók és literálok**

| Típus | Példák | Megjegyzés |
|---|---|---|
| Logikai | `TRUE`, `FALSE` | Közvetlenül használható logikai kifejezésekben, pl. `A2=TRUE`. |
| Numerikus | `1`, `0.5`, `.3`, `1E-2` | A közönséges és tudományos jelölés egyaránt támogatott. |
| Szöveg | `"abc"`, `"2/3/2020 12:00"` | Szövegliterálok dupla idézőjelek között szerepelnek a képleten belül. |
| Hibás eredmény | `#DIV/0!`, `#N/A`, `#REF!` | Egy érvényes képlet visszaadhat táblázat‑hibát a normál eredmény helyett. |

Ez a példa több állandótípust használ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "A2").setValue(False)
    workbook.getCell(0, "B2").setFormula("A2=TRUE")
    workbook.getCell(0, "C2").setFormula("1+0.5")
    workbook.getCell(0, "D2").setFormula(".3*1E-2")
    workbook.getCell(0, "E2").setFormula("\"abc\"")
    workbook.getCell(0, "F2").setFormula("2/0")

    workbook.calculateFormulas()

    logical_value = workbook.getCell(0, "B2").getValue() # Hamis
    numeric_value = workbook.getCell(0, "C2").getValue() # 1.5
    scientific_value = workbook.getCell(0, "D2").getValue() # 0.003
    string_value = workbook.getCell(0, "E2").getValue() # abc
    error_value = workbook.getCell(0, "F2").getValue() # #DIV/0!
finally:
    presentation.dispose()
```

### **Aritmetikai operátorok**

| Operátor | Jelentés | Példa |
|---|---|---|
| `+` | Összeadás vagy egyértelmű plusz | `2+3` |
| `-` | Kivonás vagy negáció | `2-3`, `-3` |
| `*` | Szorzás | `2*3` |
| `/` | Osztás | `2/3` |
| `%` | Százalék | `30%` |
| `^` | Hatványozás | `2^3` |

A kiértékelési sorrend egyértelművé tételéhez használjon zárójeleket, pl. `(A2+B2)*C2`.

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

Az Aspose.Slides beépített képlet‑értékelője diagrammunkalapokra vonatkozik, de nem egy teljes Excel‑számítási motor. A dokumentált függvénykészlet az alábbiakra korlátozódik. Ne tételezze, hogy bármely Excel‑függvény újraszámítható a [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) metódussal.

| Függvény | Célt vagy támogatott forma | Példa |
|---|---|---|
| `ABS` | Abszolút érték | `ABS(A2)` |
| `AVERAGE` | Aritmetikai közép | `AVERAGE(B2:B5)` |
| `CEILING` | Felfelé kerekítés egy többszörösre | `CEILING(A2,5)` |
| `CHOOSE` | Érték kiválasztása index alapján | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Szövegek összefűzése | `CONCAT(A2,B2)` |
| `CONCATENATE` | Szövegek összefűzése | `CONCATENATE(A2," ",B2)` |
| `DATE` | Dátumérték létrehozása 1900‑as dátumrendszerrel | `DATE(2026,8,19)` |
| `DAYS` | Napok száma két dátum között | `DAYS(B2,A2)` |
| `FIND` | Szöveg keresése egy másikban | `FIND("-",A2)` |
| `FINDB` | Byte‑orientált szövegkeresés | `FINDB("a",A2)` |
| `IF` | Feltételes eredmény | `IF(A2>0,A2,0)` |
| `INDEX` | Hivatkozási forma | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektoralapú forma | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektoralapú forma | `MATCH(A2,B2:B5,0)` |
| `MAX` | Legnagyobb érték | `MAX(B2:B5)` |
| `SUM` | Összeg | `SUM(B2:B5)` |
| `VLOOKUP` | Függőleges keresés | `VLOOKUP(A2,B2:D10,3,FALSE)` |

A táblázatban szereplő korlátozások jelentősek: az `INDEX` referencia‑formában, míg a `LOOKUP` és `MATCH` vektoralapú formában van dokumentálva. A `DATE` a 1900‑as dátumrendszert használja. Az itt felsorolatlan funkciók és jellemzők a beépített értékelő számára nem támogatottak, hacsak másként nincsenek dokumentálva.

## **Képletek számítása előnyben részesített kultúrával**

Bizonyos munkafüzet‑függvények a szöveget a kultúra‑specifikus szabályok szerint értelmezik. Ez különösen fontos a kétsoros karakterkészleteket (DBCS) használó nyelvek esetén. Az ilyen képletek helyes számlálásához hozza létre a [LoadOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadoptions/) objektumot, állítsa be a preferált kultúrát a [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/hu/python-java/aspose.slides/spreadsheetoptions/#setPreferredCulture) metódussal, adja át a táblázati beállításokat a [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions) metódussal, majd töltse be a prezentációt.

Az alábbi példa a japán kultúrát választja, megnyit egy prezentációt a konfigurált betöltési beállításokkal, és minden diagrammunkafüzeten meghívja a [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) metódust:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, LoadOptions, Presentation, SpreadsheetOptions
from java.util import Locale

japanese_culture = Locale.forLanguageTag("ja-JP")

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setPreferredCulture(japanese_culture)

load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, Chart):
                shape.getChartData().getChartDataWorkbook().calculateFormulas()
finally:
    presentation.dispose()
```

A preferált kultúra a prezentáció betöltési konfigurációjának része, ezért a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példány létrehozása előtt kell megadni. Használja azt a kultúrát, amelyet a munkafüzet‑képletek elvárnak; például a japán DBCS szabályokhoz a `ja-JP` kódot kell megadni.

## **Újraszámítás és gyorsítótárazott értékek**

A táblázatfájlok gyakran tárolják a képletet és az utolsó kiszámított értéket is. Az Aspose.Slides ezért képes a [ChartDataCell.getValue](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatacell/#getValue) metódussal egy gyorsítótárazott értéket beolvasni, amikor a prezentáció betöltődik, és a vonatkozó diagramadatok nem változtak.

A bemeneti cellák vagy képletek módosítása után ne támaszkodjon egy régi gyorsítótárazott eredményre. Hívja a [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) metódust a kiszámított értékek kiolvasása vagy a diagramadatok mentése előtt, amelyek ezekre támaszkodnak.

A támogatott halmazon kívüli képletek esetén az Aspose.Slides előfordulhat, hogy nem tudja értelmezni a képletet vagy annak függőségeit. Ha a munkafüzet módosult, a korábbi gyorsítótárazott érték már nem tekinthető megbízhatónak. Ilyen helyzetben a nem támogatott adatokkal rendelkező cella kiolvasása a [CellUnsupportedDataException](https://reference.aspose.com/slides/hu/python-java/aspose.slides/cellunsupporteddataexception/) kivételt váltja ki.

Ha a diagram olyan Excel‑függvényeket használ, amelyeket az Aspose.Slides nem képes kiértékelni, számítsa ki ezeket a képleteket egy, a szükséges függvényeket támogató táblázat‑motorral, majd írja vissza a kapott értékeket a diagram munkafüzetébe. Ne helyettesítse a nem támogatott képleteket tippelt értékekkel.

## **Képlethibák kezelése**

Kétféle problémát kell megkülönböztetni.

Egy képlet érvényes lehet, de táblázat‑hibát eredményezhet, például `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` vagy `#VALUE!`. Ebben az esetben a hibajelzés a cella eredménye, és a [ChartDataCell.getValue](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatacell/#getValue) metódussal adható vissza.

Egy képlet a feldolgozás, hivatkozás, függőség vagy a támogatott‑adat szintjén is hibát okozhat. Az Aspose.Slides ezekhez a helyzetekhez táblázat‑specifikus kivételeket biztosít: [CellInvalidFormulaException](https://reference.aspose.com/slides/hu/python-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/hu/python-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/hu/python-java/aspose.slides/cellcircularreferenceexception/) és [CellUnsupportedDataException](https://reference.aspose.com/slides/hu/python-java/aspose.slides/cellunsupporteddataexception/).

Ha a képletek sablonokból vagy felhasználói bemenetből származnak, kezelje ezeket a kivételeket az újraszámítás és az érték hozzáférés körül:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CellCircularReferenceException, CellInvalidFormulaException, CellInvalidReferenceException, CellUnsupportedDataException, ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()
    cell = workbook.getCell(0, "A2")
    cell.setFormula("SUM(B2:B5)")

    try:
        workbook.calculateFormulas()
        print(cell.getValue())
    except CellInvalidFormulaException as ex:
        print("Invalid formula: " + str(ex.getMessage()))
    except CellInvalidReferenceException as ex:
        print("Invalid cell reference: " + str(ex.getMessage()))
    except CellCircularReferenceException as ex:
        print("Circular reference: " + str(ex.getMessage()))
    except CellUnsupportedDataException as ex:
        print("Unsupported spreadsheet data: " + str(ex.getMessage()))
finally:
    presentation.dispose()
```

## **Gyakorlati korlátok**

A diagrammunkalapok képlet‑támogatása egy meghatározott táblázatszámítási részhalmazra van tervezve, nem pedig teljes Excel‑kompatibilitásra. Tartsa szem előtt ezeket a korlátozásokat a jelentéskészítési munkafolyamat tervezésekor:

- Csak a dokumentált állandókat, operátorokat, hivatkozásokat és függvényeket használja, ha az Aspose.Slides-nak kell újraszámítania a képleteket.
- Újraszámítás a cellák módosítása után, amelyektől a képlet‑eredmények függenek.
- A betöltött prezentációkból származó gyorsítótárazott értékek pillanatképek, nem helyettesítik a szerkesztés utáni újraszámítást.
- Tesztelje a meglévő sablonokból származó képleteket, mielőtt a kiszámított értékekre támaszkodna, különösen, ha a dokumentált listán kívüli függvényeket használnak.
- A teljes táblázatszámítási motorra igénylő képletek esetén számítsa ki őket külsőleg, majd frissítse a diagram munkafüzetét a kapott értékekkel.

## **GYIK**

**Mi a különbség a [ChartDataCell.setFormula](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatacell/#setFormula) és a [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatacell/#setR1C1Formula) között?**

A [ChartDataCell.setFormula](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatacell/#setFormula) A1‑stílusú kifejezést tárol, például `B2-C2`. A [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatacell/#setR1C1Formula) R1C1‑stílusú kifejezést tárol, például `RC[-2]-RC[-1]`. Használja azt a jelölést, amely legjobban illik a képletek generálásához vagy másolásához.

**Olvasnom kell a cellát magát vagy az értékét a számítás után?**

A [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdataworkbook/#getCell) egy [ChartDataCell](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatacell/) objektumot ad vissza. A kiszámított eredményhez hívja meg ennek a cellának a [ChartDataCell.getValue](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatacell/#getValue) metódusát újraszámítás után.

**Mikor kell meghívni a [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) metódust?**

Hívja a [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) metódust a bemeneti értékek vagy képletek módosítása után, és mielőtt a kiszámított eredményektől függne. Ez frissíti a beépített értékelő által támogatott képletek értékeit.

**Az Aspose.Slides támogat minden Excel‑függvényt?**

Nem. A beépített értékelő egy dokumentált függvény‑részhalmazt támogat. A részhalmazon kívüli függvények nem számíthatók újra helyesen. Ha teljes Excel‑képlet‑kompatibilitásra van szükség, végezze a számítást egy megfelelő táblázat‑motorral, és írja a végső értékeket a diagram munkafüzetébe.

**Mi történik, ha egy betöltött prezentáció nem támogatott képletet tartalmaz?**

Ha a diagram adat nem változott, a munkafüzet még tartalmazhat egy korábban kiszámított gyorsítótárazott értéket. A kapcsolódó adatok módosítása után ez a gyorsítótárazott érték már nem biztos, hogy érvényes. Egy nem kezelhető képlettel rendelkező cella elérése a [CellUnsupportedDataException](https://reference.aspose.com/slides/hu/python-java/aspose.slides/cellunsupporteddataexception/) kivételt váltja ki.

**Ugyanazok-e a képlet‑hibák és a kivételek?**

Nem. Az `#DIV/0!`‑hez hasonló eredmény egy táblázat‑érték, amely egy érvényes számításból származik. A [CellInvalidFormulaException](https://reference.aspose.com/slides/hu/python-java/aspose.slides/cellinvalidformulaexception/) vagy [CellCircularReferenceException](https://reference.aspose.com/slides/hu/python-java/aspose.slides/cellcircularreferenceexception/) kivételek azt jelzik, hogy a képletet nem lehet normálisan feldolgozni.

**A diagram automatikusan frissül, ha egy képlet‑cellát módosítanak?**

Egy diagram sorozat hivatkozhat a munkafüzet celláira. Először számolja újra a munkafüzetet, majd mentse vagy renderelje a prezentációt. Ha a diagram adatpontjai a kiszámított cellákra mutatnak, a diagram a frissített cellaértékeket használja; ehhez nincs külön diagram‑frissítési metódus szükséges.

**Használhatók külső Excel‑munkafüzetek a diagramokban?**

Igen, a diagramadatok konfigurálhatók külső munkafüzet használatára a diagram adat‑API‑val. Azonban ebben a cikkben leírt képletszámítási munkafolyamat a diagram adatkönyvtárra és az Aspose.Slides által kiértékelt képlet‑részhalmazra vonatkozik. Ne feltételezze, hogy a [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) teljes újraszámítást biztosít egy tetszőleges külső XLSX fájlra.

**Használhatók képletek, amelyek egy másik munkalapra vagy munkafüzetre hivatkoznak?**

Excel‑stílusú hivatkozások előfordulhatnak a diagram munkafüzeteiben, de a képlet‑értékelés a támogatott elemző és függvénykészlet által korlátozott. Ha egy kereszt‑lap vagy külső hivatkozás elengedhetetlen, ellenőrizze a pontos képletet a használt Aspose.Slides verzióval. Olyan munkafolyamatok esetén, amelyek széles Excel‑hivatkozási kompatibilitást igényelnek, számítsa ki a munkafüzetet külsőleg, majd írja vissza a feloldott értékeket a diagram adatainak.

**A képletsorozatoknak kell `=` jellel kezdődniük?**

Az Aspose.Slides API példák a kifejezéseket `B2-C2` vagy `SUM(B2:B5)` formában adják meg, vezető `=` nélkül. Ennek a formának a használata konzisztens a dokumentált API‑példákkal.