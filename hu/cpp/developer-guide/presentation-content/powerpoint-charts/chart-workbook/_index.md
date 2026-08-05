---
title: Diagram munkafüzetek kezelése prezentációkban C++-ban
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
description: "Fedezze fel az Aspose.Slides for C++-t: könnyedén kezelje a diagram munkafüzeteket PowerPoint és OpenDocument formátumokban, hogy egyszerűsítse a prezentáció adatait."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan lehet a diagram munkafüzetekkel dolgozni az Aspose.Slides-ben. Bemutatja, hogyan lehet a diagram adatokat munkafüzet adatfolyamok segítségével be- és kiolvasni, a munkafüzet cellákat diagram adatcímkeként használni, a munkalap gyűjteményeket elérni, és a diagram értékek adatforrás típusát meghatározni.

Emellett lefedi a külső munkafüzetekkel való munkát adatforrásként a diagramokhoz. A példák bemutatják, hogyan hozhatunk létre és adhatunk hozzá egy külső munkafüzetet, hogyan kérhetjük le egy diagramhoz kapcsolt külső munkafüzet útvonalát, és hogyan szerkeszthetjük a diagram adatokat, ha a munkafüzet elérhető.

## **Diagramadatok beolvasása és írása munkafüzetből**

Aspose.Slides a [ReadWorkbookStream](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) és a [WriteWorkbookStream](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) metódusokat biztosítja, amelyek lehetővé teszik a diagram adatok munkafüzeteinek (az Aspose.Cells-szel szerkesztett diagram adatokkal) be- és kiolvasását. **Megjegyzés**: a diagram adatokat ugyanúgy kell szervezni, vagy hasonló felépítésűnek kell lenniük, mint a forrás.

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

Ez a C++ kód bemutatja a műveletet, amely egy diagram adat munkafüzetet állít be:

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

## **Munkafüzet cella beállítása diagram adatcímkeként**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.  
2. Szerezze meg egy dia referenciajét az indexe alapján.  
3. Adjon hozzá egy Buborék diagramot némi adattal.  
4. Érje el a diagram sorozatait.  
5. Állítsa be a munkafüzet cellát adatcímkeként.  
6. Mentse el a prezentációt.

Ez a C++ kód megmutatja, hogyan állítható be egy munkafüzet cella diagram adatcímkeként:

``` cpp
System::String lbl0 = u"Label 0 cell value";
System::String lbl1 = u"Label 1 cell value";
System::String lbl2 = u"Label 2 cell value";

// Létrehozza a Presentation osztályt, amely egy prezentációfájlt reprezentál
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

Ez a C++ kód bemutat egy műveletet, ahol a [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) metódust használják a munkalap gyűjtemény eléréséhez:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 500.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheets = workbook->get_Worksheets();

for (auto ws : System::IterateOver(worksheets))
    System::Console::WriteLine(ws->get_Name());
```

## **Adatforrás típusának meghatározása**

Ez a C++ kód megmutatja, hogyan lehet meghatározni egy típusát az adatforrásnak:

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

## **Nem támogatott beágyazott munkafüzet formátumok észlelése**

Az Aspose.Slides nem támogatja az Excel bináris munkafüzet (.xlsb) formátumot, amely néhány diagramba beágyazható. Használhatja a `get_EmbeddedWorkbookType` metódust a [IChartData](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdata/) felületén a [WorkbookType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/workbooktype/) felsorolással együtt, hogy észlelje a nem támogatott formátumokat és kihagyja az ilyen diagramokat.

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
        // A beágyazott munkafüzet .xlsb formátumban van, ami nem támogatott.
        continue;
    }

    // Itt olvassa vagy módosítsa a diagram munkafüzet adatait.
}
```

## **Külső munkafüzet**

{{% alert color="primary" %}} 
Az [Aspose.Slides](https://releases.aspose.com/slides/hu/cpp/release-notes/2019/aspose-slides-for-cpp-19-4-release-notes/) 19.4‑es verzióban bevezettük a külső munkafüzetek támogatását adatforrásként a diagramokhoz.
{{% /alert %}} 

### **Külső munkafüzet létrehozása**

A **`ReadWorkbookStream`** és **`SetExternalWorkbook`** metódusok használatával vagy egy külső munkafüzetet hozhat létre a semmiből, vagy egy belső munkafüzetet tehet külsővé.

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

A **`IChartData::SetExternalWorkbook`** metódus használatával külső munkafüzetet rendelhet egy diagramhoz adatforrásként. Ez a metódus arra is használható, hogy frissítse a külső munkafüzet útvonalát (ha az át lett helyezve).

Bár a távoli helyeken vagy erőforrásokban tárolt munkafüzetek adatait nem lehet szerkeszteni, ezeket a munkafüzeteket továbbra is használhatja külső adatforrásként. Ha egy külső munkafüzet relatív útvonalát adja meg, az automatikusan teljes útvonallá alakul.

Ez a C++ kód megmutatja, hogyan kell beállítani egy külső munkafüzetet:

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

Az `updateChartData` paraméter (a `SetExternalWorkbook` metódus alatt) azt határozza meg, hogy egy Excel munkafüzet betöltődjön-e vagy sem. 

* Ha az `updateChartData` értéke `false`, csak a munkafüzet útvonala frissül – a diagram adat nem lesz betöltve vagy frissítve a célmunkafüzetről. Ezt a beállítást akkor célszerű használni, amikor a célmunkafüzet nem létezik vagy nem érhető el.  
* Ha az `updateChartData` értéke `true`, a diagram adatok a célmunkafüzetről frissülnek.

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, true);
System::SharedPtr<IChartData> chartData = chart->get_ChartData();

System::SharedPtr<ChartData> concreteChartData = System::AsCast<ChartData>(chartData);
concreteChartData->SetExternalWorkbook(u"http://path/doesnt/exists", false);

pres->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
```

### **Diagram külső adatforrás munkafüzetének útvonalának lekérése**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.  
2. Szerezze meg egy dia referenciajét az indexe alapján.  
3. Hozzon létre egy objektumot a diagram alakzat számára.  
4. Hozzon létre egy objektumot a forrás (`ChartDataSourceType`) típushoz, amely a diagram adatforrását képviseli.  
5. Adja meg a megfelelő feltételt a forrás típusának a külső munkafüzet adatforrás típusával egyező módon.

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

### **Diagram adatainak szerkesztése**

A külső munkafüzetek adatait ugyanúgy szerkesztheti, ahogyan a belső munkafüzetek tartalmát módosítja. Ha egy külső munkafüzetet nem lehet betölteni, kivétel keletkezik.

Ez a C++ kód a leírt folyamat megvalósítása:

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

**Meg tudom határozni, hogy egy adott diagram külső vagy beágyazott munkafüzettel van-e összekapcsolva?**

Igen. A diagram rendelkezik egy [adatforrás típussal](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) és egy [úttal egy külső munkafüzethez](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/); ha a forrás egy külső munkafüzet, akkor kiolvashatja a teljes útvonalat, hogy megbizonyosodjon arról, hogy egy külső fájl van használatban.

**Támogatottak a relatív útvonalak a külső munkafüzetekhez, és hogyan tárolódnak?**

Igen. Ha relatív útvonalat ad meg, az automatikusan abszolút úttá lesz konvertálva. Ez projektportabilitás szempontjából kényelmes; azonban vegye figyelembe, hogy a prezentáció az abszolút útvonalat tárolja a PPTX fájlban.

**Használhatok munkafüzeteket hálózati erőforrásokban/megosztásokban?**

Igen, ilyen munkafüzeteket használhat külső adatforrásként. Azonban a távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑ből nem támogatott – csak forrásként használhatók.

**Felülírja az Aspose.Slides a külső XLSX fájlt a prezentáció mentésekor?**

Nem. A prezentáció egy [hivatkozást tárol a külső fájlra](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/), és ezt használja az adatok beolvasásához. A külső fájl maga nem módosul a prezentáció mentésekor.

**Mit tegyek, ha a külső fájl jelszóval védett?**

Az Aspose.Slides nem fogad el jelszót a hivatkozáskor. Egy gyakori megoldás, hogy előzetesen eltávolítja a védelmet, vagy egy visszafejtett másolatot készít (például a [Aspose.Cells](/cells/cpp/) használatával), és arra a másolatra hivatkozik.

**Több diagram hivatkozhat ugyanarra a külső munkafüzetre?**

Igen. Minden diagram a saját hivatkozását tárolja. Ha mindegyik ugyanarra a fájlra mutat, a fájl frissítése a következő adatbetöltéskor minden diagramnál megjelenik.