---
title: Diagram munkalap képletek alkalmazása prezentációkban C++-ban
linktitle: Munkalap képletek
type: docs
weight: 70
url: /hu/cpp/chart-worksheet-formulas/
keywords:
- diagram táblázat
- diagram munkalap
- diagram képlet
- munkalap képlet
- táblázat képlet
- diagramadat munkafüzet
- képlet számítás
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
- C++
- Aspose.Slides
description: "Alkalmazzon Excel-stílusú képleteket az Aspose.Slides for C++ diagram munkalapokon, számítsa újra az értékeket, és használja fel az eredményeket a PowerPoint diagramokban."
---
## **Áttekintés**

A PowerPoint-diagramok általában beágyazott munkalapban tárolják a forrásadataikat. Az Aspose.Slides for C++‑ban a diagram adatkönyvtáron keresztül érheti el azt a munkalapot, írhat be bemeneti értékeket, rendelhet képleteket a cellákhoz, számíthatja ki a támogatott képleteket, és felhasználhatja a kiszámított cellákat diagramadatként.

Ez a cikk bemutatja a teljes képlet‑munkafolyamatot: diagram létrehozása, a munkalap feltöltése, A1‑ vagy R1C1‑stílusú képletek hozzárendelése, újraszámításuk, a kiszámított értékek kiolvasása, a cellák csatlakoztatása egy diagram sorozathoz, és a prezentáció mentése. Leírja a támogatott képletszintaxist, a beépített függvények részhalmazát, a gyorsítótárazott értékeket, a nem támogatott képleteket és a táblázat‑specifikus hibákat.

## **Diagram munkalapok és képletek**

Egy diagram munkalapja tartalmazza a kategóriákat, sorozatneveket és értékeket, amelyeket egy diagram használ. PowerPointban megtekintheti a munkalapot a diagram adat szerkesztőjének megnyitásával:

![PowerPoint diagram a beágyazott munkalappal nyitva, a kategória‑ és sorozatadatokat mutatja](chart-worksheet-formulas_1.png)

Az Aspose.Slides‑ben a munkalap a [IChartDataWorkbook](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdataworkbook/) interfészen keresztül érhető el. Használja a [IChartDataCell::set_Formula](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatacell/set_formula/) metódust A1‑stílusú képletekhez és a [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) metódust R1C1‑stílusú képletekhez. A bemeneti cellák vagy képletek módosítása után hívja a [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) metódust a támogatott képletek újraszámításához és a megfelelő cellaértékek frissítéséhez.

Egy kiszámított cella továbbra is a [IChartDataCell::get_Value](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatacell/get_value/) metódussal adja vissza az eredményt. Ez akkor fontos, amikor kódból kell ellenőrizni egy képlet eredményét vagy a cellát diagramadat‑pontként használni.

## **Diagram létrehozása és a munkalap képleteinek számítása**

Az alábbi példa egy teljes munkafolyamatot mutat be. Létrehoz egy csoportosított oszlopdiagramot, törli a mintaadatokat, beírja a negyedéves bevétel‑ és költségértékeket, a képletekkel kiszámítja a profitot, kiolvassa az eredményeket, a kiszámított cellákat diagramértékekként használja, és elmenti a prezentációt.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 350.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();
const int32_t worksheetIndex = 0;

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();
workbook->Clear(worksheetIndex);

auto category1 = workbook->GetCell(worksheetIndex, u"A2", ObjectExt::Box<String>(u"Q1"));
auto category2 = workbook->GetCell(worksheetIndex, u"A3", ObjectExt::Box<String>(u"Q2"));
auto category3 = workbook->GetCell(worksheetIndex, u"A4", ObjectExt::Box<String>(u"Q3"));

workbook->GetCell(worksheetIndex, u"B1", ObjectExt::Box<String>(u"Revenue"));
workbook->GetCell(worksheetIndex, u"C1", ObjectExt::Box<String>(u"Expenses"));
workbook->GetCell(worksheetIndex, u"D1", ObjectExt::Box<String>(u"Profit"));

workbook->GetCell(worksheetIndex, u"B2")->set_Value(ObjectExt::Box<double>(120.0));
workbook->GetCell(worksheetIndex, u"C2")->set_Value(ObjectExt::Box<double>(80.0));
workbook->GetCell(worksheetIndex, u"B3")->set_Value(ObjectExt::Box<double>(150.0));
workbook->GetCell(worksheetIndex, u"C3")->set_Value(ObjectExt::Box<double>(95.0));
workbook->GetCell(worksheetIndex, u"B4")->set_Value(ObjectExt::Box<double>(135.0));
workbook->GetCell(worksheetIndex, u"C4")->set_Value(ObjectExt::Box<double>(110.0));

auto profit1 = workbook->GetCell(worksheetIndex, u"D2");
auto profit2 = workbook->GetCell(worksheetIndex, u"D3");
auto profit3 = workbook->GetCell(worksheetIndex, u"D4");

profit1->set_Formula(u"B2-C2");
profit2->set_Formula(u"B3-C3");
profit3->set_Formula(u"B4-C4");

workbook->CalculateFormulas();

auto q1Profit = profit1->get_Value(); // 40
auto q2Profit = profit2->get_Value(); // 55
auto q3Profit = profit3->get_Value(); // 25

chartData->get_Categories()->Add(category1);
chartData->get_Categories()->Add(category2);
chartData->get_Categories()->Add(category3);

auto profitSeries = chartData->get_Series()->Add(workbook->GetCell(worksheetIndex, u"D1"), chart->get_Type());
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit1);
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit2);
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit3);
profitSeries->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

presentation->Save(u"chart-formulas.pptx", SaveFormat::Pptx);
```

A diagram adatpontjai a `D2:D4` tartományra hivatkoznak, így a diagram a kiszámított profitértékeket használja. Ebben a munkafolyamatban nincs külön diagram‑frissítési hívás: először számolja újra a munkafüzetet, majd használja vagy mentse a képletekkel már kiszámított diagramadatokat.

## **A1‑stílusú képletek használata**

Az A1‑jelölés a oszlopokat betűkkel, a sorokat számokkal azonosítja. A [IChartDataCell::set_Formula](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatacell/set_formula/) metódussal adja meg az A1‑stílusú kifejezéseket.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"C3")->set_Value(ObjectExt::Box<int32_t>(10));
workbook->GetCell(0, u"F2")->set_Value(ObjectExt::Box<int32_t>(2));
workbook->GetCell(0, u"G2")->set_Value(ObjectExt::Box<int32_t>(3));
workbook->GetCell(0, u"H2")->set_Value(ObjectExt::Box<int32_t>(4));

auto cell = workbook->GetCell(0, u"A2");
cell->set_Formula(u"C3+SUM(F2:H2)");

workbook->CalculateFormulas();

auto value = cell->get_Value(); // 19
```

A gyakori A1‑hivatkozási formák:

| Referencia | Relatív | Abszolút | Vegyes |
|---|---|---|---|
| Cell | `A2` | `$A$2` | `A$2`, `$A2` |
| Row | `2:2` | `$2:$2` | — |
| Column | `A:A` | `$A:$A` | — |
| Range | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

A relatív hivatkozások a képlet áthelyezésekor vagy másolásakor megváltozhatnak egy táblázatkezelő alkalmazásban. Az abszolút hivatkozások mindkét koordinátát rögzítik, míg a vegyes hivatkozások csak egy sort vagy egy oszlopot fixálnak.

## **R1C1‑stílusú képletek használata**

Az R1C1‑jelölés a sorokat és oszlopokat numerikus módon azonosítja. A relatív hivatkozások szögletes zárójelek közti eltolásokat használnak. Ezt a szintaxist a [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) metódussal adhatja meg.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"B2")->set_Value(ObjectExt::Box<int32_t>(12));
workbook->GetCell(0, u"C2")->set_Value(ObjectExt::Box<int32_t>(5));

auto cell = workbook->GetCell(0, u"D2");
cell->set_R1C1Formula(u"RC[-2]-RC[-1]");

workbook->CalculateFormulas();

auto value = cell->get_Value(); // 7
```

A gyakori R1C1‑hivatkozási formák:

| Referencia | Relatív | Abszolút | Vegyes |
|---|---|---|---|
| Cell | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Row | `R[2]` | `R2` | — |
| Column | `C[3]` | `C3` | — |
| Range | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Például a `D2` cellában az `RC[-2]` azt jelenti, hogy ugyanabban a sorban, két oszloppal balra lévő cella (`B2`).

## **Képletállandók és operátorok**

A beépített képletkiértékelő logikai értékeket, numerikus literálokat, sztringeket, táblázat‑hibákat, aritmetikai operátorokat és összehasonlító operátorokat támogat.

### **Állandók és literálok**

| Típus | Példák | Megjegyzések |
|---|---|---|
| Logical | `TRUE`, `FALSE` | Közvetlenül felhasználható logikai kifejezésekben, például `A2=TRUE`. |
| Numeric | `1`, `0.5`, `.3`, `1E-2` | A közönséges és tudományos jelölés is támogatott. |
| String | `"abc"`, `"2/3/2020 12:00"` | A szöveges literálok dupla idézőjellel vannak körülvéve a képletben. |
| Error result | `#DIV/0!`, `#N/A`, `#REF!` | Egy érvényes képlet kiértékelhető táblázat‑hibáértékként a normál eredmény helyett. |

Ez a példa több állandótípust is használ:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"A2")->set_Value(ObjectExt::Box<bool>(false));
workbook->GetCell(0, u"B2")->set_Formula(u"A2=TRUE");
workbook->GetCell(0, u"C2")->set_Formula(u"1+0.5");
workbook->GetCell(0, u"D2")->set_Formula(u".3*1E-2");
workbook->GetCell(0, u"E2")->set_Formula(u"\"abc\"");
workbook->GetCell(0, u"F2")->set_Formula(u"2/0");

workbook->CalculateFormulas();

auto logicalValue = workbook->GetCell(0, u"B2")->get_Value(); // Hamis
auto numericValue = workbook->GetCell(0, u"C2")->get_Value(); // 1.5
auto scientificValue = workbook->GetCell(0, u"D2")->get_Value(); // 0.003
auto stringValue = workbook->GetCell(0, u"E2")->get_Value(); // abc
auto errorValue = workbook->GetCell(0, u"F2")->get_Value(); // #DIV/0!
```

### **Aritmetikai operátorok**

| Operátor | Jelentés | Példa |
|---|---|---|
| `+` | Összeadás vagy egyjegyű plusz | `2+3` |
| `-` | Kivonás vagy negálás | `2-3`, `-3` |
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

Az Aspose.Slides beépített képletkiértékelővel rendelkezik a diagram munkalapokhoz, de nem egy teljes Excel‑számítási motor. A dokumentált függvénykészlet a következőkre korlátozódik. Ne feltételezze, hogy egy tetszőleges Excel‑függvényt újra tud számolni a [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) metódus.

| Függvény | Cél vagy támogatott forma | Példa |
|---|---|---|
| `ABS` | Absolút érték | `ABS(A2)` |
| `AVERAGE` | Aritmetikai közép | `AVERAGE(B2:B5)` |
| `CEILING` | Felfelé kerekítés egy többszörösre | `CEILING(A2,5)` |
| `CHOOSE` | Érték kiválasztása index alapján | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Szövegértékek összefűzése | `CONCAT(A2,B2)` |
| `CONCATENATE` | Szövegértékek összefűzése | `CONCATENATE(A2," ",B2)` |
| `DATE` | Dátumérték létrehozása a 1900‑as dátumrendszerrel | `DATE(2026,8,19)` |
| `DAYS` | Napok számának visszaadása két dátum között | `DAYS(B2,A2)` |
| `FIND` | Egy szöveg keresése egy másikban | `FIND("-",A2)` |
| `FINDB` | Byte‑orientált szövegre keresés | `FINDB("a",A2)` |
| `IF` | Feltételes eredmény | `IF(A2>0,A2,0)` |
| `INDEX` | Referencia forma | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektor forma | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektor forma | `MATCH(A2,B2:B5,0)` |
| `MAX` | Legnagyobb érték | `MAX(B2:B5)` |
| `SUM` | Összeg | `SUM(B2:B5)` |
| `VLOOKUP` | Függőleges keresés | `VLOOKUP(A2,B2:D10,3,FALSE)` |

A táblázatban feltüntetett korlátozások jelentősek: az `INDEX` referenciaként, míg a `LOOKUP` és `MATCH` vektor‑formában dokumentált. A `DATE` a 1900‑as dátumrendszert használja. A nem felsorolt funkciókat az Aspose.Slides képletkiértékelő nem támogatja, hacsak külön nem dokumentáltak.

## **Újraszámítás és gyorsítótárazott értékek**

A táblázatfájlok gyakran tárolják a képletet és az utolsó kiszámított értéket is. Az Aspose.Slides ezért a [IChartDataCell::get_Value](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatacell/get_value/) metódussal kiolvashat egy gyorsítótárazott értéket, amikor egy prezentáció betöltődik, és a kapcsolódó diagramadatok nem változtak.

A bemeneti cellák vagy képletek módosítása után ne bízzon egy régi gyorsítótárazott eredményben. Hívja a [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) metódust a kiszámított értékek kiolvasása vagy a diagramadatok mentése előtt, ha azok függnek tőlük.

A támogatott halmazon kívüli képletek esetén az Aspose.Slides előfordulhat, hogy nem tudja értelmezni a képletet vagy annak függőségeit. Ha a munkafüzet módosult, a korábban gyorsítótárazott érték már nem megbízható. Ilyen helyzetben egy nem támogatott adattal rendelkező cella kiolvasása [CellUnsupportedDataException](https://reference.aspose.com/slides/hu/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/)-t dobhat.

Ha diagramja olyan Excel‑függvényeket használ, amelyeket az Aspose.Slides nem értékel ki, számolja ki ezeket a képleteket egy olyan táblázat‑motorral, amely támogatja őket, majd írja vissza a kapott értékeket a diagram munkafüzetébe. Ne cserélje le a nem támogatott képleteket tippelt értékekre.

## **Képletek hibáinak kezelése**

Kétféle problémát kell megkülönböztetni.

Egy képlet érvényes lehet, de táblázat‑hibát eredményez, például `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` vagy `#VALUE!`. Ebben az esetben a hibajelzet a cella eredménye, és a [IChartDataCell::get_Value](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatacell/get_value/) metódussal adható vissza.

A képlet hibát is dobhat a szintaxis, a hivatkozás, a függőség vagy a támogatott‑adat szintjén. Az Aspose.Slides ezekhez a helyzetekhez táblázat‑specifikus kivételeket biztosít: [CellInvalidFormulaException](https://reference.aspose.com/slides/hu/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/hu/cpp/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/hu/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/) és [CellUnsupportedDataException](https://reference.aspose.com/slides/hu/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Ha a képletek sablonokból vagy felhasználói bevitelből származnak, kezelje ezeket a kivételeket az újraszámítás és az értékelérés körül:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Spreadsheet/CellCircularReferenceException.h>
#include <Spreadsheet/CellInvalidFormulaException.h>
#include <Spreadsheet/CellInvalidReferenceException.h>
#include <Spreadsheet/CellUnsupportedDataException.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Spreadsheet;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto cell = workbook->GetCell(0, u"A2");
cell->set_Formula(u"SUM(B2:B5)");

try
{
    workbook->CalculateFormulas();
    auto value = cell->get_Value();
}
catch (CellInvalidFormulaException&)
{
    // Érvénytelen képlet kezelése.
}
catch (CellInvalidReferenceException&)
{
    // Érvénytelen cellahivatkozás kezelése.
}
catch (CellCircularReferenceException&)
{
    // Körkörös hivatkozás kezelése.
}
catch (CellUnsupportedDataException&)
{
    // Nem támogatott táblázatadat kezelése.
}
```

## **Gyakorlati korlátozások**

A diagram munkalapok képlet‑támogatása egy meghatározott táblázat‑számítási részhalmazra van szánva, nem teljes Excel‑kompatibilitásra. Tartsa szem előtt ezeket a korlátokat a jelentéskészítési munkafolyamat tervezésekor:

- Csak a dokumentált állandókat, operátorokat, hivatkozásokat és függvényeket használja, ha azt szeretné, hogy az Aspose.Slides újraszámolja a képleteket.
- Újraszámítás a cellák módosítása után, amelyektől a képlet eredményei függnek.
- A betöltött prezentációkból származó gyorsítótárazott értékeket pillanatfelvételnek tekintse, nem pedig a szerkesztés utáni újraszámítás helyettesítésének.
- Tesztelje a meglévő sablonok képleteit, mielőtt a kiszámított értékekre támaszkodna, különösen, ha azok a dokumentált listán kívül álló függvényeket használnak.
- A teljes táblázat‑számítási motorhoz szükséges képleteket számolja ki külsőleg, majd frissítse a diagram munkafüzetét a kapott értékekkel.

## **GYIK**

**Mi a különbség a `set_Formula` és a `set_R1C1Formula` között?**

[IChartDataCell::set_Formula](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatacell/set_formula/) A1‑stílusú kifejezést (például `B2-C2`) tárol. [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) R1C1‑stílusú kifejezést (például `RC[-2]-RC[-1]`) tárol. A legjobban annak a jelölésnek a használata ajánlott, amelyik leginkább illeszkedik a képletek generálásához vagy másolásához.

**A számítás után a cellát vagy annak értékét kell olvasnom?**

[IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) egy `IChartDataCell`‑et ad vissza. A kiszámított eredményhez a cella [IChartDataCell::get_Value](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatacell/get_value/) értékét kell kiolvasni újraszámítás után.

**Mikor kell meghívnom a `CalculateFormulas`‑t?**

Hívja a [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) metódust a bemeneti értékek vagy képletek módosítása után, és mielőtt a kiszámított eredményektől függne. Ez frissíti a beépített kiértékelő által támogatott képletek értékeit.

**Az Aspose.Slides minden Excel‑függvényt támogat?**

Nem. A beépített kiértékelő egy dokumentált függvény‑részhalmazt támogat. A részhalmazon kívüli függvényeket nem szabad úgy feltételezni, hogy helyesen újraszámolhatóak. Ha teljes Excel‑képletkompatibilitásra van szükség, végezze el a számítást egy megfelelő táblázat‑motorral, és írja a végleges értékeket a diagram munkafüzetébe.

**Mi történik, ha egy betöltött prezentáció nem támogatott képletet tartalmaz?**

Ha a diagram adatai nem változtak, a munkafüzet még tartalmazhat egy korábban kiszámított gyorsítótárazott értéket. A kapcsolódó adatok módosítása után ez a gyorsítótárazott érték már érvénytelen lehet. Egy olyan cella elérése, amelynek képlete nem kezelhető, a [CellUnsupportedDataException](https://reference.aspose.com/slides/hu/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/)-t válthatja ki.

**Ugyanazok-e a képlet‑hibák és a C++‑kivételek?**

Nem. A `#DIV/0!`‑hoz hasonló eredmény egy táblázat‑érték, amely egy érvényes számításból származik. A [CellInvalidFormulaException](https://reference.aspose.com/slides/hu/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/) vagy a [CellCircularReferenceException](https://reference.aspose.com/slides/hu/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/) típusú kivételek azt jelzik, hogy a képletet nem lehet normál módon feldolgozni.

**Frissül automatikusan a diagram, ha egy képlet‑cellát módosítok?**

Egy diagram sorozata hivatkozhat a munkafüzet celláira. Először számolja újra a munkafüzetet, majd mentse vagy renderelje a prezentációt. Ha a diagram adatpontjai a kiszámított cellákra mutatnak, a diagram a frissített cellaértékeket használja; nincs szükség külön diagram‑frissítési metódusra ebben a munkafolyamatban.

**A diagramok használhatnak külső Excel‑munkafüzetet?**

Igen, a diagram adatokat konfigurálhatja úgy, hogy külső munkafüzetet használjon a diagram adat‑API‑n keresztül. Azonban a jelen cikkben leírt képlet‑számítási munkafolyamat a diagram adat‑munkafüzetre és az Aspose.Slides által kiértékelt képlet‑részhalmazra vonatkozik. Ne feltételezze, hogy a [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) teljes újraszámítást végez egy tetszőleges képlettel egy külső XLSX‑fájlban.

**Használhatok képleteket, amelyek másik munkalapra vagy munkafüzetre hivatkoznak?**

Az Excel‑stílusú hivatkozások előfordulhatnak a diagram munkafüzetben, de a képletkiértékelés a támogatott elemző és függvénykészlet által korlátozott. Ha egy kereszt‑lap vagy külső hivatkozás elengedhetetlen, ellenőrizze a pontos képletet a használt Aspose.Slides verzióval. Széles körű Excel‑hivatkozási kompatibilitást igénylő munkafolyamatok esetén számolja ki a munkafüzetet külsőleg, és írja vissza a feloldott értékeket a diagram adatba.