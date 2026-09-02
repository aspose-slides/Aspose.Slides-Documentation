---
title: "Kezelje a diagram munkafüzeteket bemutatókban C++-szal"
linktitle: "Diagram munkafüzet"
type: docs
weight: 70
url: /hu/cpp/chart-workbook/
keywords:
- diagram munkafüzet
- diagram adatok
- munkafüzet cella
- adatcímke
- munkalap
- adatforrás
- külső munkafüzet
- külső adat
- diagram gyorsítótár
- munkafüzet helyreállítás
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for C++-t: könnyedén kezelje a diagram munkafüzeteket PowerPoint és OpenDocument formátumokban, hogy egyszerűsítse bemutató adatait."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhatunk diagramm munkafüzetekkel az Aspose.Slides‑ben. Megmutatja, hogyan kell beolvasni és írni a diagram adatait munkafüzet‑adatfolyamok segítségével, a munkafüzet‑cellákat diagramcímkeként használni, a munkalap‑gyűjteményekhez hozzáférni, valamint megadni az adatforrás típusát a diagram értékeihez.

Továbbá tárgyalja a külső munkafüzetek diagramadat‑forrásként való használatát. A példák bemutatják, hogyan hozhatunk létre és rendeljünk hozzá egy külső munkafüzetet, hogyan kérhetjük le egy diagramhoz kapcsolt külső munkafüzet útvonalát, valamint hogyan szerkeszthetjük a diagram adatokat, ha a munkafüzet rendelkezésre áll.

## **Diagramadatok beolvasása és írása munkafüzetből**

Az Aspose.Slides a [ReadWorkbookStream](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) és a [WriteWorkbookStream](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) metódusokat biztosítja, amelyek lehetővé teszik diagramadat‑munkafüzetek (amelyek Aspose.Cells‑szel szerkesztett diagramadatokat tartalmaznak) beolvasását és írását. **Megjegyzés:** a diagramadatoknak ugyanúgy kell felépülniük, vagy struktúrájuknak hasonlónak kell lennie a forráshoz.

``` cpp
auto pres = System::MakeObject<Presentation>(u"chart.pptx");

auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto data = chart->get_ChartData();

System::SharedPtr<System::IO::MemoryStream> stream = data->ReadWorkbookStream();
data->get_Series()->Clear();
data->get_Categories()->Clear();

stream->set_Position(0);
data->WriteWorkbookStream(stream);
```

Ez a C++ kód bemutatja a diagramadat‑munkafüzet beállításának műveletét:

``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(Charts::ChartType::Pie, 50.0f, 50.0f, 500.0f, 400.0f);
chart->get_ChartData()->get_ChartDataWorkbook()->Clear(0);

intrusive_ptr<Aspose::Cells::IWorkbook> workbook;
try
{
    workbook = Aspose::Cells::Factory::CreateIWorkbook(new String("a1.xlsx"));
}
catch (Aspose::Cells::Systems::Exception& ex)
{
    System::Console::Write(System::String::FromWCS(ex.GetMessageExp()->value()));
}

intrusive_ptr<MemoryStream> cellsOutputStream = new Aspose::Cells::Systems::IO::MemoryStream();
workbook->Save(cellsOutputStream, Aspose::Cells::SaveFormat_Xlsx);

cellsOutputStream->SetPosition(0);
System::SharedPtr<System::IO::MemoryStream> msout = ToSlidesMemoryStream(cellsOutputStream);

chart->get_ChartData()->WriteWorkbookStream(msout);

chart->get_ChartData()->SetRange(u"Sheet1!$A$1:$B$9");
auto series = chart->get_ChartData()->get_Series()->idx_get(0);
series->get_ParentSeriesGroup()->set_IsColorVaried(true);
pres->Save(u"response2.pptx", Export::SaveFormat::Pptx);
```

## **Munkafüzetcellát beállítása diagramadat‑címkének**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2. Szerezze meg egy dia hivatkozását az indexe alapján.
3. Adjon hozzá egy Bubbla diagramot némi adattal.
4. Hozzáférjen a diagram sorozatához.
5. Állítsa be a munkafüzetcellát adatcímkének.
6. Mentse el a prezentációt.

Ez a C++ kód megmutatja, hogyan állíthat be egy munkafüzetcellát diagramadat‑címkének:

``` cpp
System::String lbl0 = u"Label 0 cell value";
System::String lbl1 = u"Label 1 cell value";
System::String lbl2 = u"Label 2 cell value";

// Egy Presentation osztály példányosítása, amely egy prezentációs fájlt képvisel 
auto pres = System::MakeObject<Presentation>(u"chart2.pptx");

auto slide = pres->get_Slides()->idx_get(0);

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Bubble, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto series = chart->get_ChartData()->get_Series();

series->idx_get(0)->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLabelValueFromCell(true);

auto wb = chart->get_ChartData()->get_ChartDataWorkbook();

series->idx_get(0)->get_Labels()->idx_get(0)->set_ValueFromCell(wb->GetCell(0, u"A10", System::ObjectExt::Box<System::String>(lbl0)));
series->idx_get(0)->get_Labels()->idx_get(1)->set_ValueFromCell(wb->GetCell(0, u"A11", System::ObjectExt::Box<System::String>(lbl1)));
series->idx_get(0)->get_Labels()->idx_get(2)->set_ValueFromCell(wb->GetCell(0, u"A12", System::ObjectExt::Box<System::String>(lbl2)));

pres->Save(u"resultchart.pptx", SaveFormat::Pptx);
```

## **Munkalapok kezelése**

Ez a C++ kód bemutat egy műveletet, ahol a [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) metódust használják a munkalap‑gyűjtemény eléréséhez:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 500.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheets = workbook->get_Worksheets();

for (auto ws : System::IterateOver(worksheets))
    System::Console::WriteLine(ws->get_Name());
```

## **Adatforrás típusának megadása**

Ez a C++ kód megmutatja, hogyan adhatunk meg egy típust egy adatforráshoz:

```c++
auto pres = System::MakeObject<Presentation>();

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto chartData = chart->get_ChartData();
auto val = chart->get_ChartData()->get_Series()->idx_get(0)->get_Name();

val->set_DataSourceType(DataSourceType::StringLiterals);
val->set_Data(System::ObjectExt::Box<System::String>(u"LiteralString"));
val = chartData->get_Series()->idx_get(1)->get_Name();
val->set_Data(chartData->get_ChartDataWorkbook()->GetCell(0, u"B1", System::ObjectExt::Box<System::String>(u"NewCell")));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Nem támogatott beágyazott munkafüzet‑formátumok felismerése**

Az Aspose.Slides nem támogatja a néhány diagramban beágyazható Excel bináris munkafüzet (.xlsb) formátumot. A `get_EmbeddedWorkbookType` metódust az [IChartData](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdata/) felületén a [WorkbookType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/workbooktype/) felsorolással együtt használhatja a nem támogatott formátumok felismerésére és az érintett diagramok kihagyására.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (!System::ObjectExt::Is<IChart>(shape))
    {
        continue;
    }

    auto chart = System::ExplicitCast<IChart>(shape);
    auto chartData = chart->get_ChartData();

    if (chartData->get_DataSourceType() == ChartDataSourceType::InternalWorkbook &&
        chartData->get_EmbeddedWorkbookType() == WorkbookType::WorkbookBinaryMacro)
    {
        // Beágyazott munkafüzet .xlsb formátumú, amely nem támogatott.
        continue;
    }

    // Olvassa vagy módosítsa itt a diagram munkafüzet adatait.
}
```

## **Külső munkafüzet**

{{% alert color="primary" %}} 
Az [Aspose.Slides](https://releases.aspose.com/slides/hu/cpp/release-notes/2019/aspose-slides-for-cpp-19-4-release-notes/) 19.4‑es verziójában bevezettük a külső munkafüzetek diagramadat‑forrásként való támogatását.
{{% /alert %}} 

### **Külső munkafüzet létrehozása**

A **`ReadWorkbookStream`** és a **`SetExternalWorkbook`** metódusok használatával akár új külső munkafüzetet hozhatunk létre, akár egy meglévő belső munkafüzetet tehetünk külsővé.

Ez a C++ kód bemutatja a külső munkafüzet létrehozásának folyamatát:

```c++
auto pres = System::MakeObject<Presentation>();

const System::String workbookPath = u"externalWorkbook1.xlsx";

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f);
auto chartData = chart->get_ChartData();

{
    System::SharedPtr<System::IO::FileStream> fileStream = System::MakeObject<System::IO::FileStream>(workbookPath, System::IO::FileMode::Create);

    System::ArrayPtr<uint8_t> workbookData = chartData->ReadWorkbookStream()->ToArray();
    fileStream->Write(workbookData, 0, workbookData->get_Length());
}

chartData->SetExternalWorkbook(System::IO::Path::GetFullPath(workbookPath));

pres->Save(u"externalWorkbook.pptx", SaveFormat::Pptx);
```

### **Külső munkafüzet beállítása**

Az **`IChartData::SetExternalWorkbook`** metódus segítségével egy külső munkafüzetet rendelhetünk egy diagram adatforrásához. Ez a metódus használható a külső munkafüzet útvonalának frissítésére is (ha a fájl helye megváltozott).

Bár a távoli helyeken vagy erőforrásokban tárolt munkafüzetek adatait nem lehet közvetlenül szerkeszteni, továbbra is használhatók külső adatforrásként. Ha relatív útvonalat ad meg egy külső munkafüzethez, az automatikusan teljes (abszolút) útvonallá konvertálódik.

Ez a C++ kód megmutatja, hogyan állíthat be egy külső munkafüzetet:

```c++
auto pres = System::MakeObject<Presentation>();

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, false);
auto chartData = chart->get_ChartData();

chartData->SetExternalWorkbook(System::IO::Path::GetFullPath(u"externalWorkbook.xlsx"));

chartData->get_Series()->Add(chartData->get_ChartDataWorkbook()->GetCell(0, u"B1"), ChartType::Pie);
auto dataPoints = chartData->get_Series()->idx_get(0)->get_DataPoints();
auto workbook = chartData->get_ChartDataWorkbook();
dataPoints->AddDataPointForPieSeries(workbook->GetCell(0, u"B2"));
dataPoints->AddDataPointForPieSeries(workbook->GetCell(0, u"B3"));
dataPoints->AddDataPointForPieSeries(workbook->GetCell(0, u"B4"));

auto categories = chartData->get_Categories();
categories->Add(workbook->GetCell(0, u"A2"));
categories->Add(workbook->GetCell(0, u"A3"));
categories->Add(workbook->GetCell(0, u"A4"));
pres->Save(u"Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
```

Az `updateChartData` paraméter (a `SetExternalWorkbook` metódus alatt) határozza meg, hogy egy Excel munkafüzet be lesz‑töltve vagy sem.

* Ha az `updateChartData` értéke **false**, csak a munkafüzet útvonala frissül — a diagram adat nem töltődik be vagy frissül a cél‑munkafüzetből. Ezt a beállítást akkor érdemes használni, ha a cél‑munkafüzet nem létezik vagy nem érhető el.
* Ha az `updateChartData` értéke **true**, a diagram adatai a cél‑munkafüzettel frissülnek.

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, true);
System::SharedPtr<IChartData> chartData = chart->get_ChartData();

System::SharedPtr<ChartData> concreteChartData = System::AsCast<ChartData>(chartData);
concreteChartData->SetExternalWorkbook(u"http://path/doesnt/exists", false);

pres->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
```

### **A diagram külső adatforrás‑munkafüzetei útvonalának lekérése**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2. Szerezze meg egy dia hivatkozását az indexe alapján.
3. Hozzon létre egy objektumot a diagram alakzatra.
4. Hozzon létre egy objektumot a forrás (`ChartDataSourceType`) típusához, amely a diagram adatforrását képviseli.
5. Adja meg a megfelelő feltételt attól függően, hogy a forrástípus megegyezik‑e a külső munkafüzet adatforrástípusával.

Ez a C++ kód bemutatja a műveletet:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

auto slide = pres->get_Slides()->idx_get(1);
auto chart = System::ExplicitCast<IChart>(slide->get_Shapes()->idx_get(0));
ChartDataSourceType sourceType = chart->get_ChartData()->get_DataSourceType();
if (sourceType == ChartDataSourceType::ExternalWorkbook)
{
    System::String path = chart->get_ChartData()->get_ExternalWorkbookPath();
}

// A prezentáció mentése
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

### **Diagramadatok szerkesztése**

A külső munkafüzetek adatait ugyanúgy szerkesztheti, mint a belső munkafüzetek tartalmát. Ha egy külső munkafüzet beolvasása sikertelen, kivétel keletkezik.

Ez a C++ kód a leírt folyamat megvalósítását mutatja:

```c++
const String templatePath = u"../templates/presentation.pptx";
	const String outPath = u"../out/presentation-out.pptx";
	

	System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<Aspose::Slides::Charts::IChart> chart = System::AsCast<Aspose::Slides::Charts::IChart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
	System::SharedPtr<Aspose::Slides::Charts::ChartData> chartData = System::ExplicitCast<Aspose::Slides::Charts::ChartData>(chart->get_ChartData());
	

	chartData->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell()->set_Value(System::ObjectExt::Box<int32_t>(100));
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Munkafüzet helyreállítása a diagram gyorsítótárából**

Ha egy diagram egy hiányzó vagy nem elérhető külső munkafüzetet használ, az Aspose.Slides helyreállíthatja a diagram munkafüzetét a prezentációban tárolt gyorsítótárazott adatokból. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/) objektumot, állítsa be a [set_SpreadsheetOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/) segítségével, és hívja meg az [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) metódust **true** értékkel a prezentáció megnyitása előtt.

Az alábbi C++ példa egy olyan prezentációt nyit meg, amelynek diagramja egy nem elérhető külső munkafüzetre hivatkozik, és a helyreállított adatokat a [IChart::get_ChartData](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichart/get_chartdata/) és a [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) segítségével érheti el:

```cpp
auto spreadsheetOptions = MakeObject<SpreadsheetOptions>();
spreadsheetOptions->set_RecoverWorkbookFromChartCache(true);

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_SpreadsheetOptions(spreadsheetOptions);

auto presentation = MakeObject<Presentation>(u"presentation.pptx", loadOptions);

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto chart = System::ExplicitCast<IChart>(shape);

auto recoveredWorkbook = chart->get_ChartData()->get_ChartDataWorkbook();

// Olvassa vagy módosítsa itt a helyreállított munkafüzet adatait.

presentation->Dispose();
```

Ha a külső munkafüzet nem elérhető, és a helyreállítás le van tiltva, az Aspose.Slides `System::InvalidOperationException`‑t dob. A helyreállítás csak akkor engedélyezendő, ha a gyorsítótárazott diagramadatok használata elfogadható tartalékmegoldás, mivel a gyorsítótár nem feltétlenül tartalmazza a külső munkafüzeten a prezentáció legutóbbi frissítése óta végzett változtatásokat.

## **GYIK**

**Meg tudom határozni, hogy egy adott diagram külső vagy beágyazott munkafüzethez van-e kapcsolva?**

Igen. A diagram rendelkezik egy [data source type](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) és egy [path to an external workbook](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) tulajdonsággal; ha a forrás egy külső munkafüzet, leolvashatja a teljes útvonalat, hogy megbizonyosodjon róla, hogy egy külső fájlt használ.

**Támogatottak a relatív útvonalak a külső munkafüzetekhez, és hogyan tárolódnak?**

Igen. Ha relatív útvonalat ad meg, azt a rendszer automatikusan abszolút útvonalra konvertálja. Ez kényelmes a projekt hordozhatósága szempontjából; azonban a prezentáció az abszolút útvonalat tárolja a PPTX fájlban.

**Használhatók a hálózati erőforrásokon/megosztott meghajtókon lévő munkafüzetek?**

Igen, az ilyen munkafüzetek használhatók külső adatforrásként. A távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑ből azonban nem támogatott — csak forrásként használhatók.

**Az Aspose.Slides felülírja a külső XLSX‑et a prezentáció mentésekor?**

Nem. A prezentáció egy [link to the external file](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) tárol, és ezt használja az adatok beolvasásához. A külső fájl maga nem módosul a prezentáció mentésekor.

**Mit kell tennem, ha a külső fájl jelszóval védett?**

Az Aspose.Slides nem fogad el jelszót a linkeléskor. Egy gyakori megoldás a védelem előzetes eltávolítása vagy egy dekódolt másolat (például a [Aspose.Cells](/cells/cpp/) segítségével) előkészítése, majd annak a másolatnak a linkelése.

**Több diagram is hivatkozhat ugyanarra a külső munkafüzetre?**

Igen. Minden diagram a saját linkjét tárolja. Ha mindegyik ugyanarra a fájlra mutat, a fájl frissítése a következő adatbetöltéskor minden diagramra kihat.