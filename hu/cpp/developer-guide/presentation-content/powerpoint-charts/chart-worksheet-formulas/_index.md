---
title: Diagram munkalap képletek alkalmazása prezentációkban C++ használatával
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
- diagram adat munkafüzet
- képlet számítás
- preferált kultúra
- kultúra-specifikus képlet
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
- C++
- Aspose.Slides
description: "Excel-szerű képletek alkalmazása az Aspose.Slides for C++ diagrammunkalapokon, értékek újraszámítása, és az eredmények használata PowerPoint-diagramokban."
---
## **Áttekintés**

A PowerPoint-diagramok általában a forrásadataikat egy beágyazott munkalapon tárolják. Az Aspose.Slides for C++-ban hozzáférhet ehhez a munkalaphoz a diagram adat‑munkafüzeten keresztül, beírhat bemeneti értékeket, képleteket rendelhet a cellákhoz, kiszámíthatja a támogatott képleteket, és a kiszámított cellákat diagramadatként használhatja.

Ez a cikk bemutatja a teljes képletszintetikus munkafolyamatot: diagram létrehozása, a munkalap feltöltése, A1‑stílusú vagy R1C1‑stílusú képletek hozzárendelése, azok újraszámítása, a kiszámított értékek kiolvasása, a cellák diagram‑sorozatra kapcsolása, és a prezentáció mentése. Emellett leírja a támogatott képletszintaxist, a beépített függvény‑részhalmazt, a gyorsítótárazott értékeket, a nem támogatott képleteket és a táblázat‑specifikus hibákat.

## **Diagram munkalapok és képletek**

Egy diagram munkalapja tartalmazza a diagram által használt kategóriákat, sorozatneveket és értékeket. PowerPoint‑ban a munkalapot a diagram adat‑szerkesztő megnyitásával ellenőrizheti:

![PowerPoint-diagram a beágyazott munkalapjával megnyitva, a kategória- és sorozatadatok megjelenítése](chart-worksheet-formulas_1.png)

Az Aspose.Slides‑ben a munkalap a [IChartDataWorkbook](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdataworkbook/) interfészen keresztül érhető el. A1‑stílusú képletekhez használja a [IChartDataCell::set_Formula](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatacell/set_formula/) metódust, R1C1‑stílusú képletekhez a [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) metódust. A bemeneti cellák vagy képletek módosítása után hívja a [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) metódust a támogatott képletek újraszámításához és a megfelelő cellaértékek frissítéséhez.

Egy kiszámított cella továbbra is az eredményét a [IChartDataCell::get_Value](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatacell/get_value/) metódussal adja vissza. Ez akkor fontos, ha a kódban kell ellenőriznie a képlet eredményét, vagy a cellát diagramadat‑ponthoz szeretné használni.

## **Diagram létrehozása és a munkalap képleteinek kiszámítása**

Az alábbi példa egy vég‑től‑végéig folyamatot mutat be. Létrehoz egy klaszter‑oszlop diagramot, törli a mintaadatokat, beírja a negyedéves bevételi és kiadási értékeket, képletekkel számolja ki a profitot, kiolvassa az eredményeket, a kiszámított cellákat diagramértékként használja, és menti a prezentációt.

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

A diagram adatpontjai a `D2:D4` tartományra hivatkoznak, így a diagram a kiszámított profitértékeket használja. Ebben a munkafolyamatban nincs külön diagram‑frissítő hívás: először számolja újra a munkafüzetet, majd használja vagy mentse a kiszámított cellákra mutató diagramadatokat.

## **A1‑stílusú képletek használata**

Az A1 jelölés betűkkel azonosítja az oszlopokat, számokkal a sorokat. A‑1‑stílusú kifejezéseket a [IChartDataCell::set_Formula](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatacell/set_formula/) metódussal rendelje hozzá.

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

| Hivatkozás | Relatív | Abszolút | Vegyes |
|---|---|---|---|
| Cella | `A2` | `$A$2` | `A$2`, `$A2` |
| Sor | `2:2` | `$2:$2` | — |
| Oszlop | `A:A` | `$A:$A` | — |
| Tartomány | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

A relatív hivatkozások megváltozhatnak, ha egy képletet egy táblázatkezelő alkalmazás átmozgat vagy másol. Az abszolút hivatkozások mindkét koordinátát rögzítik, míg a vegyes hivatkozások csak egy sort vagy egy oszlopot rögzítenek.

## **R1C1‑stílusú képletek használata**

Az R1C1 jelölés számszerűen azonosítja a sorokat és oszlopokat. A relatív hivatkozások szögletes zárójelekben adandó eltolást tartalmaznak. Ezt a szintaxist a [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) metódussal adja meg.

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

| Hivatkozás | Relatív | Abszolút | Vegyes |
|---|---|---|---|
| Cella | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Sor | `R[2]` | `R2` | — |
| Oszlop | `C[3]` | `C3` | — |
| Tartomány | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Például a `D2` cellában az `RC[-2]` a ugyanabban sorban két oszloppal balra lévő cellát jelenti (`B2`).

## **Képletállandók és operátorok**

A beépített képletelemző támogatja a logikai értékeket, numerikus literálokat, szövegeket, táblázat‑hibákat, aritmetikai operátorokat és összehasonlító operátorokat.

### **Állandók és literálok**

| Típus | Példák | Megjegyzések |
|---|---|---|
| Logikai | `TRUE`, `FALSE` | Közvetlenül használható logikai kifejezésekben, például `A2=TRUE`. |
| Szám | `1`, `0.5`, `.3`, `1E-2` | A közönséges és a tudományos jelölés egyaránt támogatott. |
| Szöveg | `"abc"`, `"2/3/2020 12:00"` | A szöveg‑literálok dupla idézőjelben szerepelnek a képleten belül. |
| Hibás eredmény | `#DIV/0!`, `#N/A`, `#REF!` | Egy érvényes képlet visszaadhat táblázat‑hibát a normál eredmény helyett. |

Ez a példa több állandótípust is bemutat:

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
| `+` | Összeadás vagy egyelőjeles plusz | `2+3` |
| `-` | Kivonás vagy negáció | `2-3`, `-3` |
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

Az Aspose.Slides beépített képletelemzője diagram‑munkalapokhoz készült, de nem egy teljes Excel‑számítási motor. A dokumentált függvénykészlet a lenti függvényekre korlátozódik. Ne tételezze, hogy egy tetszőleges Excel‑függvény újraszámítható a [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) metódussal.

| Függvény | Cél vagy támogatott forma | Példa |
|---|---|---|
| `ABS` | Abszolút érték | `ABS(A2)` |
| `AVERAGE` | Aritmetikai közép | `AVERAGE(B2:B5)` |
| `CEILING` | Szám felfelé kerekítése többszörösre | `CEILING(A2,5)` |
| `CHOOSE` | Érték kiválasztása index szerint | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Szövegelemek összefűzése | `CONCAT(A2,B2)` |
| `CONCATENATE` | Szövegelemek összefűzése | `CONCATENATE(A2," ",B2)` |
| `DATE` | Dátumérték létrehozása a 1900‑as dátumrendszerrel | `DATE(2026,8,19)` |
| `DAYS` | Napok száma két dátum között | `DAYS(B2,A2)` |
| `FIND` | Szöveg keresése egy másik szövegben | `FIND("-",A2)` |
| `FINDB` | Byte‑orientált szövegre keresés | `FINDB("a",A2)` |
| `IF` | Feltételes eredmény | `IF(A2>0,A2,0)` |
| `INDEX` | Referencia forma | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektor forma | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektor forma | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maximális érték | `MAX(B2:B5)` |
| `SUM` | Értékek összeadása | `SUM(B2:B5)` |
| `VLOOKUP` | Vertikális keresés | `VLOOKUP(A2,B2:D10,3,FALSE)` |

A táblázatban feltüntetett korlátozások jelentősek: az `INDEX` referencia‑formában dokumentált, míg a `LOOKUP` és a `MATCH` vektor‑formában. A `DATE` a 1900‑as dátumrendszert használja. A felsoroltakon kívül szereplő funkciókat az Aspose.Slides képletelemzője nem támogatja, hacsak külön nincsenek dokumentálva.

## **Képletek számítása preferált kultúrával**

Egyes diagram‑munkafüzet függvények a szöveget kultúraspecifikus szabályok szerint értelmezik. Ez különösen fontos a dupla‑bájtos karakterkészleteket (DBCS) használó nyelvekhez készült függvényeknél. Az ilyen képletek helyes számításához hozza létre a [LoadOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/) objektumot, állítsa be a [ISpreadsheetOptions::set_PreferredCulture](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ispreadsheetoptions/set_preferredculture/) beállítást a [LoadOptions::set_SpreadsheetOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/) segítségével, majd töltse be a prezentációt.

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/SpreadsheetOptions.h>
#include <system/globalization/culture_info.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;
using namespace System::Globalization;

auto japaneseCulture = CultureInfo::GetCultureInfo(u"ja-JP");

auto spreadsheetOptions = MakeObject<SpreadsheetOptions>();
spreadsheetOptions->set_PreferredCulture(japaneseCulture);

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_SpreadsheetOptions(spreadsheetOptions);

auto presentation = MakeObject<Presentation>(u"presentation.pptx", loadOptions);

for (int32_t slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count(); slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);

    for (int32_t shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto shape = slide->get_Shape(shapeIndex);
        if (ObjectExt::Is<IChart>(shape))
        {
            auto chart = ExplicitCast<IChart>(shape);
            chart->get_ChartData()->get_ChartDataWorkbook()->CalculateFormulas();
        }
    }
}
```

A preferált kultúra a prezentáció betöltésének konfigurációjának része, ezért a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) példány létrehozása előtt adja meg. Használja a munkafüzet képletek által elvárt kultúrát; például a japán szabályokhoz a `ja-JP` értéket alkalmazza.

## **Újraszámítás és gyorsítótárazott értékek**

A táblázatfájlok gyakran tárolják a képletet és annak legutóbbi kiszámított értékét is. Az Aspose.Slides ezért a [IChartDataCell::get_Value](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatacell/get_value/) metódussal tudja kiolvasni a gyorsítótárazott értéket, amikor a prezentáció betöltődik, és a diagram adatát nem módosították.

A bemeneti cellák vagy képletek módosítása után ne támaszkodjon a régi gyorsítótárazott eredményre. Hívja a [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) metódust a kiszámított értékek kiolvasása vagy a diagramadatok mentése előtt, ha azok függnek tőlük.

A támogatott részhalmazon kívül eső képletek esetén az Aspose.Slides előfordulhat, hogy nem tudja értelmezni a képletet vagy annak függőségeit. Ha a munkafüzetet módosították, a korábbi gyorsítótárazott érték már nem tekinthető megbízhatónak. Ilyen esetben egy nem támogatott adatokkal rendelkező cella értékének kiolvasása [CellUnsupportedDataException](https://reference.aspose.com/slides/hu/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/) kivételt dobhat.

Ha a diagram olyan Excel‑függvényektől függ, amelyet az Aspose.Slides nem értékel ki, számolja ki ezeket a képleteket egy olyan táblázatkezelő motorral, amely támogatja őket, és írja vissza a kapott értékeket a diagram‑munkafüzetbe. Ne helyettesítse a nem támogatott képleteket becsült értékekkel.

## **Képlethibák kezelése**

Két különböző problématípust kell megkülönböztetni.

Egy képlet lehet érvényes, de táblázat‑hibát eredményezhet, például `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` vagy `#VALUE!`. Ebben az esetben a hiba‑token egy cella‑eredmény, és a [IChartDataCell::get_Value](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatacell/get_value/) segítségével visszakérhető.

Egy képlet a parse‑, hivatkozási-, függőségi- vagy támogatott‑adat szintjén is hibát okozhat. Az Aspose.Slides ezekhez a helyzetekhez táblázat‑specifikus kivételeket biztosít: [CellInvalidFormulaException](https://reference.aspose.com/slides/hu/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/hu/cpp/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/hu/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/) és [CellUnsupportedDataException](https://reference.aspose.com/slides/hu/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Ha a képletek sablonokból vagy felhasználói bemenetből származnak, ezeket a kivételeket kezelje a újraszámítás és az érték‑hozzáférés körül:

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
    // Nem támogatott táblázat adat kezelése.
}
```

## **Gyakorlati korlátok**

A diagram‑munkalapok képlet‑támogatása egy meghatározott részhalmazra vonatkozik, nem teljes Excel‑kompatibilitásra. Tartsa szem előtt ezeket a korlátozásokat a jelentéskészítési munkafolyamat megtervezésekor:

- Használja csak a dokumentált állandókat, operátorokat, hivatkozásokat és függvényeket, amikor az Aspose.Slides‑nek kell újraszámítania a képleteket.
- Számolja újra a munkafüzetet a képlet‑eredmények függő cellái módosítása után.
- Tekintse a betöltött prezentációkból származó gyorsítótárazott értékeket pillanatfelvételekként, ne helyettesítőként a szerkesztés utáni újraszámításra.
- Tesztelje a meglévő sablonok képleteit, mielőtt a kiszámított értékekre támaszkodna, különösen, ha a dokumentált listán kívüli függvényeket használ.
- Olyan képletek esetén, amelyek teljes táblázatszámítási motorra van szükségük, számolja ki őket külsőleg, majd frissítse a diagram‑munkafüzetet a kapott értékekkel.

## **GYIK**

**Mi a különbség a `set_Formula` és a `set_R1C1Formula` között?**  
[IChartDataCell::set_Formula](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatacell/set_formula/) A1‑stílusú kifejezést tárol, például `B2-C2`. [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) R1C1‑stílusú kifejezést tárol, például `RC[-2]-RC[-1]`. Használja azt a jelölést, amely legjobban illik a képletek előállítási vagy másolási módjához.

**Kell-e a cellát vagy annak értékét kiolvasni a számítás után?**  
[IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) egy `IChartDataCell`‑et ad vissza. A kiszámított eredményhez olvassa el ennek a cellának a [IChartDataCell::get_Value](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatacell/get_value/) értékét a újraszámítás után.

**Mikor kell meghívni a `CalculateFormulas`‑t?**  
Hívja a [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) metódust a bemeneti értékek vagy képletek módosítása után, és mielőtt a kiszámított eredményekre támaszkodna. Ez frissíti a beépített értékelő által támogatott képletek értékeit.

**Támogatja-e az Aspose.Slides minden Excel‑függvényt?**  
Nem. A beépített értékelő egy dokumentált függvény‑részhalmazt támogat. A részhalmazon kívüli függvények nem számíthatók újraszámításra. Ha teljes Excel‑képletszámításra van szükség, végezze el a számítást egy megfelelő táblázatkezelő motorral, és írja az eredményértékeket a diagram‑munkafüzetbe.

**Mi történik, ha egy betöltött prezentáció nem támogatott képletet tartalmaz?**  
Ha a diagram‑adatok nem változtak, a munkafüzetben maradhat egy korábban kiszámított gyorsítótárazott érték. Az érintett adatok módosítása után ez az érték már nem biztos, hogy érvényes. Egy olyan cella elérése, amelynek képlete nem kezelhető, [CellUnsupportedDataException](https://reference.aspose.com/slides/hu/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/) kivételt eredményezhet.

**Ugyanazok‑e a képlethibák értékei, mint a C++ kivételek?**  
Nem. A `#DIV/0!`‑hoz hasonló eredmény egy táblázat‑érték, amely egy érvényes számítás során jön létre. A [CellInvalidFormulaException](https://reference.aspose.com/slides/hu/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/) vagy a [CellCircularReferenceException](https://reference.aspose.com/slides/hu/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/) típusú kivételek azt jelzik, hogy a képletet nem lehet normál módon feldolgozni.

**Frissül‑e automatikusan a diagram, ha egy képletcella megváltozik?**  
A diagram‑sorozat hivatkozhat munkafüzet‑cellákra. Először számolja újra a munkafüzetet, majd mentse vagy renderelje a prezentációt. Ha a diagram adatpontjai a kiszámított cellákra mutatnak, a diagram a frissített cella‑értékeket használja; a munkafolyamathoz nincs szükség külön diagram‑frissítő módszerre.

**Használhatnak a diagramok külső Excel munkafüzetet?**  
Igen, a diagram‑adatok konfigurálhatók úgy, hogy külső munkafüzetet használjanak a diagram‑adat‑API‑n keresztül. Azonban ebben a cikkben leírt képletszámítási munkafolyamat a diagram‑munkafüzetre és az Aspose.Slides által kiértékelt képlet‑részhalmazra vonatkozik. Ne tételezze, hogy a [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) teljes újraszámítást biztosít egy külső XLSX fájl tetszőleges képleteire.

**Használhatok‑e képleteket, amelyek más munkalapra vagy munkafüzetre hivatkoznak?**  
Excel‑stílusú hivatkozások előfordulhatnak a diagram‑munkafüzetekben, de a képlet‑értékelés a támogatott elemző és függvénykészlet által korlátozott. Ha kereszt‑lap vagy külső hivatkozás elengedhetetlen, ellenőrizze a pontos képletet a cél Aspose.Slides verzióval. Olyan munkafolyamatok esetén, amelyek széleskörű Excel‑hivatkozási kompatibilitást igényelnek, számolja ki a munkafüzetet külsőleg, és írja vissza a feloldott értékeket a diagram‑adatokba.

**Kell‑e az egyenlőségjellel (`=`) kezdeni a képletkarakterláncokat?**  
Az Aspose.Slides API példák a `B2-C2` vagy `SUM(B2:B5)` kifejezéseket egyenlőségjel nélkül adják meg. Ennek a formának a használata biztosítja, hogy a generált képletek összhangban legyenek a dokumentált API‑példákkal.