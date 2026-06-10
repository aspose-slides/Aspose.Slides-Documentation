---
title: Diagram munkafüzetek kezelése prezentációkban C++-al
linktitle: Diagram munkafüzet
type: docs
weight: 70
url: /hu/cpp/chart-workbook/
keywords:
- diagram munkafüzet
- diagram adat
- munkafüzet cella
- adatcímke
- munkalap
- adatforrás
- külső munkafüzet
- külső adat
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for C++-t: egyszerűen kezelje a diagram munkafüzeteket PowerPoint és OpenDocument formátumokban, hogy egyszerűsítse a prezentáció adatait."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhat a diagram munkafüzetekkel az Aspose.Slides-ban. Bemutatja, hogyan olvashat és írhat diagram adatokat munkafüzet áramokon keresztül, hogyan használhatja a munkafüzet cellákat diagram adatcímkeként, hogyan érheti el a munkalap-gyűjteményeket, és hogyan adhatja meg az adatforrás típusát a diagramértékekhez.

Továbbá lefedi a külső munkafüzetek diagram adatforrásként történő használatát. A példák bemutatják, hogyan hozhat létre és rendelhet hozzá egy külső munkafüzetet, hogyan kérdezheti le egy diagramhoz kapcsolt külső munkafüzet elérési útját, és hogyan szerkesztheti a diagram adatokat, ha a munkafüzet elérhető.

## **Diagramadatok olvasása és írása munkafüzetből**

Az Aspose.Slides a [ReadWorkbookStream](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) és a [WriteWorkbookStream](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) metódusokat biztosítja, amelyek lehetővé teszik a diagramadatok munkafüzetek (az Aspose.Cells‑szel szerkesztett diagramadatokat tartalmazó) olvasását és írását. **Megjegyzés** hogy a diagram adatait ugyanúgy kell szervezni, vagy hasonló szerkezettel kell rendelkezniük, mint a forrás.

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

Ez a C++ kód bemutatja a műveletet, amely beállítja a diagram adat munkafüzetet:

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

## **Munkafüzetcellát beállítása diagram adatcímkeként**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.  
2. Szerezze meg egy dia referenciáját az indexe alapján.  
3. Adjon hozzá egy Bubbla diagramot némi adattal.  
4. Hozzon hozzá a diagram sorozatához.  
5. Állítsa be a munkafüzet cellát adatcímkeként.  
6. Mentse a prezentációt.  

Ez a C++ kód megmutatja, hogyan állíthat be egy munkafüzetcellát diagram adatcímkeként:

``` cpp
System::String lbl0 = u"Label 0 cell value";
System::String lbl1 = u"Label 1 cell value";
System::String lbl2 = u"Label 2 cell value";

// Létrehozza a Presentation osztály példányát, amely egy prezentációs fájlt képvisel 
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

Ez a C++ kód bemutatja egy olyan műveletet, ahol a [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) metódust használják a munkalap-gyűjtemény eléréséhez:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 500.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheets = workbook->get_Worksheets();

for (auto ws : System::IterateOver(worksheets))
    System::Console::WriteLine(ws->get_Name());
```

## **Az adatforrás típusának meghatározása**

Ez a C++ kód megmutatja, hogyan adhat meg egy típust az adatforrás számára:

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

## **Nem támogatott beágyazott munkafüzet formátumok felismerése**

Az Aspose.Slides nem támogatja az Excel bináris munkafüzet (.xlsb) formátumot, amely egyes diagramokban beágyazható. A `get_EmbeddedWorkbookType` metódust az [IChartData](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdata/) felületén, a [WorkbookType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/workbooktype/) felsorolással együtt használhatja a nem támogatott formátumok felismerésére és a diagramok kihagyására.

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
        // A beágyazott munkafüzet .xlsb formátumban van, amely nem támogatott.
        continue;
    }

    // Itt olvashatja vagy módosíthatja a diagram munkafüzet adatait.
}
```

## **Külső munkafüzet**

{{% alert color="primary" %}} 
A [Aspose.Slides](https://releases.aspose.com/slides/hu/cpp/release-notes/2019/aspose-slides-for-cpp-19-4-release-notes/) 19.4 verzióban bevezettük a külső munkafüzetek támogatását diagramok adatforrásaként.
{{% /alert %}} 

### **Külső munkafüzet létrehozása**

A **`ReadWorkbookStream`** és a **`SetExternalWorkbook`** metódusok használatával vagy egy külső munkafüzetet hozhat létre az alapoktól, vagy egy belső munkafüzetet tehet külsővé.

Ez a C++ kód bemutatja a külső munkafüzet létrehozási folyamatát:

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

Az **`IChartData::SetExternalWorkbook`** metódus segítségével hozzárendelhet egy külső munkafüzetet egy diagramhoz adatforrásként. Ezzel a metódussal frissíthető a külső munkafüzet útvonala is (ha az át lett helyezve).

Bár a távoli helyeken vagy erőforrásokban tárolt munkafüzetek adatait nem szerkesztheti közvetlenül, ilyen munkafüzeteket továbbra is használhat külső adatforrásként. Ha relatív útvonalat ad meg egy külső munkafüzethez, az automatikusan teljes útvonalra konvertálódik.

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

Az `updateChartData` paraméter (a `SetExternalWorkbook` metódus alatt) azt határozza meg, hogy egy Excel munkafüzet betöltődjön‑e vagy sem. 

* Amikor az `updateChartData` értéke `false`, csak a munkafüzet útvonala frissül — a diagram adat nem töltődik be, és nem frissül a célmunkafüzetből. Ezt a beállítást akkor érdemes használni, ha a célmunkafüzet nem létezik vagy nem érhető el.  
* Amikor az `updateChartData` értéke `true`, a diagram adatai frissülnek a célmunkafüzetből.  

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, true);
System::SharedPtr<IChartData> chartData = chart->get_ChartData();

System::SharedPtr<ChartData> concreteChartData = System::AsCast<ChartData>(chartData);
concreteChartData->SetExternalWorkbook(u"http://path/doesnt/exists", false);

pres->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
```

### **A diagram külső adatforrás munkafüzet útvonalának lekérése**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.  
2. Szerezze meg egy dia referenciáját az indexe alapján.  
3. Hozzon létre egy objektumot a diagram alakzat számára.  
4. Hozzon létre egy objektumot a forrás (`ChartDataSourceType`) típusához, amely a diagram adatforrását képviseli.  
5. Adja meg a releváns feltételt a forrástípus alapján, amely megegyezik a külső munkafüzet adatforrástípusával.  

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

### **Diagram adatok szerkesztése**

A külső munkafüzetek adatait ugyanúgy szerkesztheti, ahogyan a belső munkafüzetek tartalmát módosítaná. Ha egy külső munkafüzetet nem lehet betölteni, kivétel keletkezik.

Ez a C++ kód a leírt folyamat megvalósítását mutatja be:

```c++
const String templatePath = u"../templates/presentation.pptx";
	const String outPath = u"../out/presentation-out.pptx";
	

	System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<Aspose::Slides::Charts::IChart> chart = System::AsCast<Aspose::Slides::Charts::IChart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
	System::SharedPtr<Aspose::Slides::Charts::ChartData> chartData = System::ExplicitCast<Aspose::Slides::Charts::ChartData>(chart->get_ChartData());
	

	chartData->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell()->set_Value(System::ObjectExt::Box<int32_t>(100));
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **GYIK**

**Meg tudom határozni, hogy egy adott diagram külső vagy beágyazott munkafüzethez van-e kapcsolva?**

Igen. A diagram rendelkezik egy [adatforrás típusával](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) és egy [külső munkafüzet elérési úttal](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/); ha a forrás egy külső munkafüzet, akkor a teljes útvonalat leolvashatja, hogy biztosan külső fájlt használ.

**Támogatottak a relatív útvonalak külső munkafüzetekhez, és hogyan tárolódnak?**

Igen. Ha relatív útvonalat ad meg, az automatikusan átalakul abszolút útvonallá. Ez a projekt hordozhatóságát segíti, de vegye figyelembe, hogy a prezentáció az abszolút útvonalat tárolja a PPTX fájlban.

**Használhatok munkafüzeteket hálózati erőforrásokon / megosztásokon?**

Igen, az ilyen munkafüzetek használhatók külső adatforrásként. Azonban a távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑ból nem támogatott — csak forrásként használhatók.

**Az Aspose.Slides felülírja a külső XLSX‑et a prezentáció mentésekor?**

Nem. A prezentáció egy [linket tárol a külső fájlra](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/), és ezt az adatolvasáshoz használja. A külső fájl maga nem módosul a prezentáció mentésekor.

**Mi a teendő, ha a külső fájl jelszóval védett?**

Az Aspose.Slides nem fogad jelszót a kapcsolódáskor. Egy gyakori megoldás előre eltávolítani a védelmet, vagy létrehozni egy dekódolt másolatot (például a [Aspose.Cells](/cells/cpp/) segítségével), és arra hivatkozni.

**Több diagram is hivatkozhat ugyanarra a külső munkafüzetre?**

Igen. Minden diagram a saját linkjét tárolja. Ha mind ugyanarra a fájlra mutatnak, a fájl frissítése a következő adatbetöltéskor minden diagramon megjelenik.