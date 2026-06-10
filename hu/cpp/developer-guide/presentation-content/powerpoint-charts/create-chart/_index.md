---
title: PowerPoint prezentáció diagramok létrehozása vagy frissítése С++-ban
linktitle: Diagramok létrehozása vagy frissítése
type: docs
weight: 10
url: /hu/cpp/create-chart/
keywords:
- diagram hozzáadása
- diagram létrehozása
- diagram szerkesztése
- diagram módosítása
- diagram frissítése
- szórt diagram
- kördiagram
- vonaldiagram
- fa térkép diagram
- részvény diagram
- doboz‑szárny diagram
- tölcsér diagram
- napfény diagram
- hisztogram diagram
- radar diagram
- többkategóriás diagram
- PowerPoint
- prezentáció
- С++
- Aspose.Slides
description: "Diagramok létrehozása és testreszabása PowerPoint prezentációkban az Aspose.Slides for С++ használatával. Diagramok hozzáadása, formázása és szerkesztése gyakorlati C++ kódpéldákkal."
---
## **Áttekintés**

Ez a cikk átfogó útmutatót nyújt a diagramok létrehozásához és testreszabásához az Aspose.Slides segítségével. Megtanulja, hogyan adhat programozottan diagramot egy diára, hogyan töltheti fel adatokka­l, és hogyan alkalmazhat különféle formázási lehetőségeket a specifikus tervezési igényeknek megfelelően. A cikk során részletes kódpéldák szemléltetik az egyes lépéseket, az előadás és a diagramobjektum inicializálásától a sorok, tengelyek és jelmagyarázatok konfigurálásáig. Az útmutató követésével szilárd megértést szerez a dinamikus diagramgenerálás alkalmazásokba való integrálásához, megkönnyítve az adat‑vezérelt prezentációk létrehozását.

## **Diagram létrehozása**

A diagramok segítenek gyorsan megjeleníteni az adatokat és felismerni az összefüggéseket, amelyek egy táblázatból vagy számolótáblázatból nem feltétlenül nyilvánvalóak.

**Miért hozunk létre diagramokat?**

Diagramok használatával:

* nagy adatmennyiségeket összegyűjthet, sűríthet vagy összefoglalhat egyetlen dián belül
* mintákat és trendeket mutathat be az adatokban
* meghatározhatja az adatok időbeli vagy egy adott mérési egységhez viszonyított irányát és lendületét
* kiemelheti az outliereket, rendellenességeket, eltéréseket, hibákat, értelmetlen adatokat stb.
* komplex adatokat kommunikálhat vagy prezentálhat

PowerPointban a beszúrás funkcióval hozhat létre diagramokat, amely sablonokat kínál a különböző diagramtípusok tervezéséhez. Az Aspose.Slides segítségével szabványos diagramokat (népszerű diagramtípusok alapján) és egyedi diagramokat is létrehozhat.

{{% alert color="primary" %}} 

Ahhoz, hogy diagramokat hozzon létre, az Aspose.Slides a [ChartType](https://reference.aspose.com/slides/hu/cpp/namespace/aspose.slides.charts#a23ba9ea390f5be4c8f5ab18baf4f8c05) enum osztályt biztosítja az [Aspose::Slides::Charts](https://reference.aspose.com/slides/hu/cpp/namespace/aspose.slides.charts/) névtérben. Az enum osztály értékei a különböző diagramtípusoknak felelnek meg. 

{{% /alert %}} 

### **Normál diagramok létrehozása**
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.
1. Szerezze meg a dia referenciáját az indexe alapján.
1. Adjon hozzá egy diagramot némi adattal, és adja meg a kívánt diagramtípust. 
1. Adjon címet a diagramhoz. 
1. Érje el a diagram adatmunkalapját. 
1. Törölje az összes alapértelmezett sorozatot és kategóriát. 
1. Adjon hozzá új sorozatokat és kategóriákat. 
1. Adjon hozzá új diagramadatokat a sorozathoz. 
1. Állítson be kitöltőszínt a diagram sorozathoz. 
1. Adjon címkéket a diagram sorozathoz. 
1. Írja a módosított prezentációt PPTX fájlként.

Ez a C++ kód megmutatja, hogyan hozhat létre egy normál diagramot:

```c++
// A dokumentumok könyvtárának útvonala.
	const String outPath = u"../out/NormalCharts_out.pptx";

	// Létrehozza a PPTX fájlt reprezentáló prezentáció osztályt
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Első dia elérése
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Diagram hozzáadása alapértelmezett adatokkal
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);


	// Beállítja a diagram adatlap indexét
	int defaultWorksheetIndex = 0;

	// Lekéri a diagram adat munkalapot
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

	// Beállítja a diagram címet
	chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sample Title");
	chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText ( NullableBool::True);
	chart->get_ChartTitle()->set_Height(20);
	chart->set_HasTitle( true);

	// Törli az alapértelmezett generált sorozatokat és kategóriákat
	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();
	int s = chart->get_ChartData()->get_Series()->get_Count();
	s = chart->get_ChartData()->get_Categories()->get_Count();


	// Új sorozat hozzáadása
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Series 2")), chart->get_Type());

	// Kategóriák hozzáadása
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 1, 0, ObjectExt::Box<System::String>(u"Caetegoty 1")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 2, 0, ObjectExt::Box<System::String>(u"Caetegoty 2")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 3, 0, ObjectExt::Box<System::String>(u"Caetegoty 3")));

	
	// Az első diagram sorozatát veszi
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

	// Feltölti a sorozat adataival
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(20)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(30)));

	// Beállítja a sorozat kitöltőszínét
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());


	// A második diagram sorozatát veszi
	 series = chart->get_ChartData()->get_Series()->idx_get(1);

	// Feltölti a sorozat adataival
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(30)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(10)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(60)));

	// Beállítja a sorozat kitöltőszínét
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Green());


	// Az első címke a kategórianév megjelenítésére van beállítva
	SharedPtr<IDataLabel> lbl = series->get_DataPoints()->idx_get(0)->get_Label();
	lbl->get_DataLabelFormat()->set_ShowCategoryName(true);

	lbl = series->get_DataPoints()->idx_get(1)->get_Label();
	lbl->get_DataLabelFormat()->set_ShowSeriesName (true);

	// Megjeleníti az értéket a harmadik címkén
	lbl = series->get_DataPoints()->idx_get(2)->get_Label();
	lbl->get_DataLabelFormat()->set_ShowValue (true);
	lbl->get_DataLabelFormat()->set_ShowSeriesName(true);
	lbl->get_DataLabelFormat()->set_Separator (u"/");

	// Mentés a prezentációt
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

### **Szórt diagramok létrehozása**
A szórt diagramok (más néven szórt ábrák vagy x‑y grafikonok) gyakran használatosak minták keresésére vagy két változó közötti korrelációk bemutatására. 

Szórt diagramra akkor lehet szükség, ha:

* párosított numerikus adatokkal rendelkezik
* két változó jól párosítható egymással
* meg szeretné állapítani, hogy a két változó összefügg-e
* egy független változó több értéket vehet fel egy függő változóhoz

Ez a C++ kód megmutatja, hogyan hozhat létre szórt diagramot különböző jelölőkkel:

```c++
// A dokumentumok könyvtárának útvonala.
	const String outPath = u"../out/ScatteredChart_out.pptx";

	//PPTX fájlt reprezentáló prezentáció osztály példányosítása
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	//Első dia elérése
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Diagram hozzáadása alapértelmezett adatokkal
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ScatterWithSmoothLines, 0, 0, 500, 500);

	// Beállítja a diagram címet
	chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sample Title");
	chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText(NullableBool::True);
	chart->get_ChartTitle()->set_Height(20);
	chart->set_HasTitle(true);

	// Törli az alapértelmezett generált sorozatot 
	chart->get_ChartData()->get_Series()->Clear();
	
	// Beállítja a diagram adatlap indexét
	int defaultWorksheetIndex = 0;

	// Lekéri a diagram adat munkalapot
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// Új sorozat hozzáadása
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 3, ObjectExt::Box<System::String>(u"Series 2")), chart->get_Type());

	// Az első diagram sorozatát veszi
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

	// Új pont hozzáadása (1:3)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(1)), fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(3)));

	// Új pont hozzáadása (2:10)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(2)), fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(10)));

	// Sorozattípus szerkesztése
	series->set_Type (ChartType::ScatterWithStraightLinesAndMarkers);

	// Diagram sorozat jelölő módosítása
	series->get_Marker()->set_Size  (10);
	series->get_Marker()->set_Symbol(MarkerStyleType::Star);



	// A második diagram sorozatát veszi
	series  = chart->get_ChartData()->get_Series()->idx_get(1);

	// Új pont hozzáadása (5:2)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 2, 3, ObjectExt::Box<double>(5)), fact->GetCell(defaultWorksheetIndex, 2, 4, ObjectExt::Box<double>(2)));

	// Új pont hozzáadása (3:1)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 3, 3, ObjectExt::Box<double>(3)), fact->GetCell(defaultWorksheetIndex, 3, 4, ObjectExt::Box<double>(1)));

	// Új pont hozzáadása (2:2)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 4, 3, ObjectExt::Box<double>(2)), fact->GetCell(defaultWorksheetIndex, 4, 4, ObjectExt::Box<double>(2)));

	// Új pont hozzáadása (5:1)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 5, 3, ObjectExt::Box<double>(5)), fact->GetCell(defaultWorksheetIndex, 5, 4, ObjectExt::Box<double>(1)));

	// Diagram sorozat jelölő módosítása
	series->get_Marker()->set_Size ( 10);
	series->get_Marker()->set_Symbol(MarkerStyleType::Circle);



	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_IsColorVaried(true);

	SharedPtr<IChartDataPoint> point = series->get_DataPoints()->idx_get(0);
	point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Cyan());
	// Beállítja a szektor szegélyét
	point->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Gray());
	point->get_Format()->get_Line()->set_Width ( 3.0);
	point->get_Format()->get_Line()->set_Style(LineStyle::ThinThick);
	point->get_Format()->get_Line()->set_DashStyle(LineDashStyle::DashDot);

	SharedPtr<IChartDataPoint> point1 = series->get_DataPoints()->idx_get(1);
	point1->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Brown());

	// Beállítja a szektor szegélyét
	point1->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());
	point1->get_Format()->get_Line()->set_Width (3.0);
	point1->get_Format()->get_Line()->set_Style(LineStyle::Single);
	point1->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDot);


	SharedPtr<IChartDataPoint> point2 = series->get_DataPoints()->idx_get(2);
	point2->get_Format()->set_Fill()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Coral());

	// Beállítja a szektor szegélyét
	point2->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
	point2->get_Format()->get_Line()->set_Width ( 2.0);
	point2->get_Format()->get_Line()->set_Style(LineStyle::ThickThin);
	point2->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDotDot);


	// Egyedi címkék létrehozása az új sorozat minden kategóriájához
	SharedPtr<IDataLabel> lbl1 = series->get_DataPoints()->idx_get(0)->get_Label();

	// lbl.ShowCategoryName = true;
	lbl1->get_DataLabelFormat()->set_ShowValue(true);


	SharedPtr<IDataLabel> lbl2 = series->get_DataPoints()->idx_get(1)->get_Label();
	lbl2->get_DataLabelFormat()->set_ShowValue(true);
	lbl2->get_DataLabelFormat()->set_ShowLegendKey(true);
	lbl2->get_DataLabelFormat()->set_ShowPercentage(true);

	SharedPtr<IDataLabel> lbl3 = series->get_DataPoints()->idx_get(2)->get_Label();

	lbl3->get_DataLabelFormat()->set_ShowSeriesName(true);
	lbl3->get_DataLabelFormat()->set_ShowPercentage(true);

	// Megjeleníti a vezérlővonalakat a diagramon
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLeaderLines(true);

	// Beállítja a kördiagram szektorainak forgásszögét
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_FirstSliceAngle(180);


	// Mentés a prezentációt
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Kördiagramok létrehozása**
A kördiagramok leginkább a rész‑a‑teljes kapcsolat ábrázolására alkalmasak, különösen ha a adatok kategóriákat és numerikus értékeket tartalmaznak. Ha azonban sok rész vagy címke van, érdemes lehet oszlopdiagramot használni. 

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.
1. Szerezze meg a dia referenciáját az indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal a kívánt típussal (ebben az esetben `ChartType.Pie`).
1. Érje el a diagram adat‑IChartDataWorkbook objektumát.
1. Törölje az alapértelmezett sorozatokat és kategóriákat.
1. Adjon hozzá új sorozatokat és kategóriákat.
1. Adjon hozzá új diagramadatokat a sorozathoz.
1. Adjon hozzá új pontokat a diagramhoz, és állítson be egyedi színeket a kördiagram szeleteihez.
1. Állítson be címkéket a sorozathoz.
1. Állítson be vezetővonalakat a sorozatcímkékhez.
1. Állítsa be a forgásszöget a kördiagram diákhoz.
1. Írja a módosított prezentációt PPTX fájlként.

Ez a C++ kód megmutatja, hogyan hozhat létre egy kördiagramot:

```c++
	// A dokumentumok könyvtárának útvonala.
	const String outPath = u"../out/PieChart_out.pptx";

	//PPTX fájlt reprezentáló Presentation osztály példányosítása
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	//Első dia elérése
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Diagram hozzáadása alapértelmezett adatokkal
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Pie, 0, 0, 500, 500);

	// Beállítja a diagram címét
	chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sample Title");
	chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText(NullableBool::True);
	chart->get_ChartTitle()->set_Height(20);
	chart->set_HasTitle(true);

	// Törli az alapértelmezett generált sorozatot és kategóriákat
	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();

	// Beállítja a diagram adatlap indexét
	int defaultWorksheetIndex = 0;

	// Lekéri a diagram adat munkalapot
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

	// Kategóriák hozzáadása
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 1, 0, ObjectExt::Box<System::String>(u"First Qtr")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 2, 0, ObjectExt::Box<System::String>(u"2nd Qtr")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 3, 0, ObjectExt::Box<System::String>(u"3ed Qtr")));

	// Új sorozat hozzáadása
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());
	
	// Az első diagram sorozatát veszi
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

	// Feltölti a sorozat adataival
	series->get_DataPoints()->AddDataPointForPieSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(20)));
	series->get_DataPoints()->AddDataPointForPieSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(50)));
	series->get_DataPoints()->AddDataPointForPieSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(30)));

	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_IsColorVaried(true);

	SharedPtr<IChartDataPoint> point = series->get_DataPoints()->idx_get(0);
	point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Cyan());
	// Beállítja a szektor szegélyét
	point->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Gray());
	point->get_Format()->get_Line()->set_Width ( 3.0);
	point->get_Format()->get_Line()->set_Style( LineStyle::ThinThick);
	point->get_Format()->get_Line()->set_DashStyle ( LineDashStyle::DashDot);

	SharedPtr<IChartDataPoint> point1 = series->get_DataPoints()->idx_get(1);
	point1->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Brown());

	// Beállítja a szektor szegélyét
	point1->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());
	point1->get_Format()->get_Line()->set_Width (3.0);
	point1->get_Format()->get_Line()->set_Style(LineStyle::Single);
	point1->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDot);


	SharedPtr<IChartDataPoint> point2 = series->get_DataPoints()->idx_get(2);
	point2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Coral());

	// Beállítja a szektor szegélyét
	point2->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
	point2->get_Format()->get_Line()->set_Width (2.0);
	point2->get_Format()->get_Line()->set_Style(LineStyle::ThickThin);
	point2->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDotDot);


	// Egyedi címkék létrehozása az új sorozat minden kategóriájához
	SharedPtr<IDataLabel> lbl1 = series->get_DataPoints()->idx_get(0)->get_Label();

	// lbl.ShowCategoryName = true;
	lbl1->get_DataLabelFormat()->set_ShowValue(true);


	SharedPtr<IDataLabel> lbl2 = series->get_DataPoints()->idx_get(1)->get_Label();
	lbl2->get_DataLabelFormat()->set_ShowValue(true);
	lbl2->get_DataLabelFormat()->set_ShowLegendKey(true);
	lbl2->get_DataLabelFormat()->set_ShowPercentage(true);

	SharedPtr<IDataLabel> lbl3 = series->get_DataPoints()->idx_get(2)->get_Label();

	lbl3->get_DataLabelFormat()->set_ShowSeriesName(true);
	lbl3->get_DataLabelFormat()->set_ShowPercentage(true);

	// Beállítja, hogy a sorozat mutassa a vezérlővonalakat a diagramon
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLeaderLines ( true);

	// Beállítja a kördiagram szektorainak forgásszögét
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_FirstSliceAngle ( 180);


	// Mentés a prezentációt
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Vonaldiagramok létrehozása**

A vonaldiagramok (más néven vonalgrafikonok) leginkább olyan helyzetekben használhatók, ahol az értékek időbeli változását szeretné ábrázolni. Egy vonaldiagram segítségével egyszerre sok adatot hasonlíthat össze, nyomon követheti az időbeli változásokat és trendeket, kiemelheti a sorozatok anomáliáit stb.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.
1. Szerezze meg a dia referenciáját az indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal a kívánt típussal (ebben az esetben `ChartType::Line`).
1. Érje el a diagram adat‑IChartDataWorkbook objektumát.
1. Törölje az alapértelmezett sorozatokat és kategóriákat.
1. Adjon hozzá új sorozatokat és kategóriákat.
1. Adjon hozzá új diagramadatokat a sorozathoz.
1. Írja a módosított prezentációt PPTX fájlként.

Ez a C++ kód megmutatja, hogyan hozhat létre egy vonaldiagramot:

```c++
auto pres = System::MakeObject<Presentation>();

System::SharedPtr<IChart> lineChart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Line, 10.0f, 50.0f, 600.0f, 350.0f);
pres->Save(u"lineChart.pptx", SaveFormat::Pptx);
```

Alapértelmezés szerint a vonaldiagram pontjai egyenes, folytonos vonallal vannak összekötve. Ha szeretné, hogy a pontok pontvonalak helyett szaggatott vonallal legyenek összekötve, a kívánt szaggatott típust a következő módon adhatja meg:

```c++
System::SharedPtr<IChart> lineChart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Line, 10.0f, 50.0f, 600.0f, 350.0f);
for (auto&& series : lineChart->get_ChartData()->get_Series())
{
    series->get_Format()->get_Line()->set_DashStyle(LineDashStyle::Dash);
}
```

### **Fa térkép diagramok létrehozása**

A fa térkép diagramok leginkább értékesítési adatok esetén használandók, amikor a kategóriák relatív méretét és egyben gyorsan fel akarja hívni a figyelmet a nagyobb hozzájárulású elemekre.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.
1. Szerezze meg a dia referenciáját az indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal a kívánt típussal (ebben az esetben `ChartType.TreeMap`).
1. Érje el a diagram adat‑IChartDataWorkbook objektumát.
1. Törölje az alapértelmezett sorozatokat és kategóriákat.
1. Adjon hozzá új sorozatokat és kategóriákat.
1. Adjon hozzá új diagramadatokat a sorozathoz.
1. Írja a módosított prezentációt PPTX fájlként.

Ez a C++ kód megmutatja, hogyan hozhat létre egy fa térkép diagramot:

```c++
	// A dokumentumok könyvtárának útvonala.
	const String outPath = u"../out/TreemapChart_out.pptx";

	//PPTX fájlt reprezentáló Presentation osztály példányosítása
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Első dia elérése
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Treemap, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	// 1. ág
	System::SharedPtr<IChartCategory> leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C1", System::ObjectExt::Box<System::String>(u"Leaf1")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem1"));
	leaf->get_GroupingLevels()->SetGroupingItem(2, System::ObjectExt::Box<System::String>(u"Branch1"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C2", System::ObjectExt::Box<System::String>(u"Leaf2")));

	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C3", System::ObjectExt::Box<System::String>(u"Leaf3")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem2"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C4", System::ObjectExt::Box<System::String>(u"Leaf4")));


	// 2. ág
	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C5", System::ObjectExt::Box<System::String>(u"Leaf5")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem3"));
	leaf->get_GroupingLevels()->SetGroupingItem(2, System::ObjectExt::Box<System::String>(u"Branch2"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C6", System::ObjectExt::Box<System::String>(u"Leaf6")));

	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C7", System::ObjectExt::Box<System::String>(u"Leaf7")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem4"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C8", System::ObjectExt::Box<System::String>(u"Leaf8")));

	System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(Aspose::Slides::Charts::ChartType::Treemap);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowCategoryName(true);
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D1", System::ObjectExt::Box<int32_t>(4)));
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D2", System::ObjectExt::Box<int32_t>(5)));
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D3", System::ObjectExt::Box<int32_t>(3)));
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D4", System::ObjectExt::Box<int32_t>(6)));
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D5", System::ObjectExt::Box<int32_t>(9)));
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D6", System::ObjectExt::Box<int32_t>(9)));
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D7", System::ObjectExt::Box<int32_t>(4)));
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D8", System::ObjectExt::Box<int32_t>(3)));

	series->set_ParentLabelLayout(Aspose::Slides::Charts::ParentLabelLayoutType::Overlapping);

	// Mentés a prezentációt
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Részvény diagramok létrehozása**
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.
1. Szerezze meg a dia referenciáját az indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal a kívánt típussal (`ChartType.OpenHighLowClose`).
1. Érje el a diagram adat‑IChartDataWorkbook objektumát.
1. Törölje az alapértelmezett sorozatokat és kategóriákat.
1. Adjon hozzá új sorozatokat és kategóriákat.
1. Adjon hozzá új diagramadatokat a sorozathoz.
1. Adja meg a HiLowLines formátumot.
1. Írja a módosított prezentációt PPTX fájlként

Példa C++ kód a részvény diagram létrehozásához:

```c++
	// A dokumentumok könyvtárának útvonala.
	const String outPath = u"../out/AddStockChart_out.pptx";

	// PPTX fájlt reprezentáló Presentation osztály példányosítása
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Az első dia elérése
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Diagram hozzáadása alapértelmezett adatokkal
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::OpenHighLowClose, 0, 0, 500, 500);


	// Beállítja a diagram adatlap indexét
	int defaultWorksheetIndex = 0;

	// Lekéri a diagram adat munkalapot
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// Törli az alapértelmezett generált sorozatot és kategóriákat
	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();

	// Kategóriák hozzáadása
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 1, 0, ObjectExt::Box<System::String>(u"A")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 2, 0, ObjectExt::Box<System::String>(u"B")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 3, 0, ObjectExt::Box<System::String>(u"C")));

	// Új sorozat hozzáadása
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Open")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"High")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 3, ObjectExt::Box<System::String>(u"Low")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 4, ObjectExt::Box<System::String>(u"Close")), chart->get_Type());


	// Az első diagram sorozatát veszi
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);
	// Feltölti az első sorozat adataival
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(72)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(25)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(38)));


	series = chart->get_ChartData()->get_Series()->idx_get(1);
	// Feltölti a második sorozat adataival
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(172)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(57)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(57)));

	series = chart->get_ChartData()->get_Series()->idx_get(2);
	// Feltölti a második sorozat adataival
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 3, ObjectExt::Box<double>(12)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 3, ObjectExt::Box<double>(12)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 3, ObjectExt::Box<double>(13)));


	series = chart->get_ChartData()->get_Series()->idx_get(3);
	// Feltölti a második sorozat adataival
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 4, ObjectExt::Box<double>(25)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 4, ObjectExt::Box<double>(38)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 4, ObjectExt::Box<double>(50)));

	// Beállítja a sorozatcsoportot
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->get_UpDownBars()->set_HasUpDownBars (true);
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->get_HiLowLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);


	for(int i=0;i<chart->get_ChartData()->get_Series()->get_Count();i++)
	{
		series = chart->get_ChartData()->get_Series()->idx_get(i);
		series->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);
	}

	// Mentés a prezentációt
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Box‑and‑Whisker diagramok létrehozása**
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.
1. Szerezze meg a dia referenciáját az indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal a kívánt típussal (`ChartType.BoxAndWhisker`).
1. Érje el a diagram adat‑IChartDataWorkbook objektumát.
1. Törölje az alapértelmezett sorozatokat és kategóriákat.
1. Adjon hozzá új sorozatokat és kategóriákat.
1. Adjon hozzá új diagramadatokat a sorozathoz.
1. Írja a módosított prezentációt PPTX fájlként

Ez a C++ kód megmutatja, hogyan hozhat létre egy box‑and‑whisker diagramot:

```c++
	// A dokumentumok könyvtárának útvonala.
	const String outPath = u"../out/BoxAndWhisker_out.pptx";

	// PPTX fájlt reprezentáló Presentation osztály példányosítása
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Az első dia elérése
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::BoxAndWhisker, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A1", System::ObjectExt::Box<System::String>(u"Category 1")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A2", System::ObjectExt::Box<System::String>(u"Category 1")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A3", System::ObjectExt::Box<System::String>(u"Category 1")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A4", System::ObjectExt::Box<System::String>(u"Category 1")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A5", System::ObjectExt::Box<System::String>(u"Category 1")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A6", System::ObjectExt::Box<System::String>(u"Category 1")));

	System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(Aspose::Slides::Charts::ChartType::BoxAndWhisker);

	series->set_QuartileMethod(Aspose::Slides::Charts::QuartileMethodType::Exclusive);
	series->set_ShowMeanLine(true);
	series->set_ShowMeanMarkers(true);
	series->set_ShowInnerPoints(true);
	series->set_ShowOutlierPoints(true);

	series->get_DataPoints()->AddDataPointForBoxAndWhiskerSeries(wb->GetCell(0, u"B1", System::ObjectExt::Box<int32_t>(15)));
	series->get_DataPoints()->AddDataPointForBoxAndWhiskerSeries(wb->GetCell(0, u"B2", System::ObjectExt::Box<int32_t>(41)));
	series->get_DataPoints()->AddDataPointForBoxAndWhiskerSeries(wb->GetCell(0, u"B3", System::ObjectExt::Box<int32_t>(16)));
	series->get_DataPoints()->AddDataPointForBoxAndWhiskerSeries(wb->GetCell(0, u"B4", System::ObjectExt::Box<int32_t>(10)));
	series->get_DataPoints()->AddDataPointForBoxAndWhiskerSeries(wb->GetCell(0, u"B5", System::ObjectExt::Box<int32_t>(23)));
	series->get_DataPoints()->AddDataPointForBoxAndWhiskerSeries(wb->GetCell(0, u"B6", System::ObjectExt::Box<int32_t>(16)));


	// Mentés a prezentációt
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Tölcsér diagramok létrehozása**
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.
1. Szerezze meg a dia referenciáját az indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal a kívánt típussal (`ChartType.Funnel`).
1. Írja a módosított prezentációt PPTX fájlként

Ez a C++ kód megmutatja, hogyan hozhat létre egy tölcsér diagramot:

```c++
	// A dokumentumok könyvtárának útvonala.
	const String outPath = u"../out/FunnelChart_out.pptx";

	// PPTX fájlt reprezentáló Presentation osztály példányosítása
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Az első dia elérése
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Funnel, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A1", System::ObjectExt::Box<System::String>(u"Category 1")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A2", System::ObjectExt::Box<System::String>(u"Category 2")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A3", System::ObjectExt::Box<System::String>(u"Category 3")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A4", System::ObjectExt::Box<System::String>(u"Category 4")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A5", System::ObjectExt::Box<System::String>(u"Category 5")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A6", System::ObjectExt::Box<System::String>(u"Category 6")));

	System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(Aspose::Slides::Charts::ChartType::Funnel);

	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B1", System::ObjectExt::Box<int32_t>(50)));
	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B2", System::ObjectExt::Box<int32_t>(100)));
	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B3", System::ObjectExt::Box<int32_t>(200)));
	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B4", System::ObjectExt::Box<int32_t>(300)));
	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B5", System::ObjectExt::Box<int32_t>(400)));
	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B6", System::ObjectExt::Box<int32_t>(500)));


	// Mentés a prezentációt
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Sunburst diagramok létrehozása**
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.
1. Szerezze meg a dia referenciáját az indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal a kívánt típussal (ebben az esetben `ChartType.sunburst`).
1. Írja a módosított prezentációt PPTX fájlként

Ez a C++ kód megmutatja, hogyan hozhat létre egy sunburst diagramot:

```c++
	// A dokumentumok könyvtárának útvonala.
	const String outPath = u"../out/SunburstChart_out.pptx";

	// PPTX fájlt reprezentáló Presentation osztály példányosítása
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Az első dia elérése
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart=slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Sunburst, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	// 1. ág
	System::SharedPtr<IChartCategory> leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C1", System::ObjectExt::Box<System::String>(u"Leaf1")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem1"));
	leaf->get_GroupingLevels()->SetGroupingItem(2, System::ObjectExt::Box<System::String>(u"Branch1"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C2", System::ObjectExt::Box<System::String>(u"Leaf2")));

	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C3", System::ObjectExt::Box<System::String>(u"Leaf3")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem2"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C4", System::ObjectExt::Box<System::String>(u"Leaf4")));

	// 2. ág
	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C5", System::ObjectExt::Box<System::String>(u"Leaf5")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem3"));
	leaf->get_GroupingLevels()->SetGroupingItem(2, System::ObjectExt::Box<System::String>(u"Branch2"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C6", System::ObjectExt::Box<System::String>(u"Leaf6")));

	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C7", System::ObjectExt::Box<System::String>(u"Leaf7")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem4"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C8", System::ObjectExt::Box<System::String>(u"Leaf8")));

	System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(Aspose::Slides::Charts::ChartType::Sunburst);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowCategoryName(true);
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D1", System::ObjectExt::Box<int32_t>(4)));
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D2", System::ObjectExt::Box<int32_t>(5)));
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D3", System::ObjectExt::Box<int32_t>(3)));
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D4", System::ObjectExt::Box<int32_t>(6)));
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D5", System::ObjectExt::Box<int32_t>(9)));
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D6", System::ObjectExt::Box<int32_t>(9)));
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D7", System::ObjectExt::Box<int32_t>(4)));
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D8", System::ObjectExt::Box<int32_t>(3)));

	// A prezentációt lemezre menti
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Hisztogram diagramok létrehozása**
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.
1. Szerezze meg a dia referenciáját az indexe alapján. 
1. Adjon hozzá egy diagramot némi adattal, és adja meg a kívánt diagramtípust (`ChartType.Histogram` ebben az esetben).
1. Érje el a diagram adat‑`IChartDataWorkbook` objektumát.
1. Törölje az alapértelmezett sorozatokat és kategóriákat.
1. Adjon hozzá új sorozatokat és kategóriákat.
1. Írja a módosított prezentációt PPTX fájlként.

Ez a C++ kód megmutatja, hogyan hozhat létre egy hisztogram diagramot:

```c++
	// A dokumentumok könyvtárának útvonala.
	const String outPath = u"../out/HistogramChart_out.pptx";

	// PPTX fájlt reprezentáló Presentation osztály példányosítása
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Az első dia elérése
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Histogram, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(Aspose::Slides::Charts::ChartType::Histogram);
	series->get_DataPoints()->AddDataPointForHistogramSeries(wb->GetCell(0, u"A1", System::ObjectExt::Box<int32_t>(15)));
	series->get_DataPoints()->AddDataPointForHistogramSeries(wb->GetCell(0, u"A2", System::ObjectExt::Box<int32_t>(-41)));
	series->get_DataPoints()->AddDataPointForHistogramSeries(wb->GetCell(0, u"A3", System::ObjectExt::Box<int32_t>(16)));
	series->get_DataPoints()->AddDataPointForHistogramSeries(wb->GetCell(0, u"A4", System::ObjectExt::Box<int32_t>(10)));
	series->get_DataPoints()->AddDataPointForHistogramSeries(wb->GetCell(0, u"A5", System::ObjectExt::Box<int32_t>(-23)));
	series->get_DataPoints()->AddDataPointForHistogramSeries(wb->GetCell(0, u"A6", System::ObjectExt::Box<int32_t>(16)));

	chart->get_Axes()->get_HorizontalAxis()->set_AggregationType(Aspose::Slides::Charts::AxisAggregationType::Automatic);

	// Mentés a prezentációt
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Radar diagramok létrehozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.
1. Szerezze meg a dia referenciáját az indexe alapján. 
1. Adjon hozzá egy diagramot némi adattal, és adja meg a kívánt diagramtípust (`ChartType.Radar` ebben az esetben).
1. Írja a módosított prezentációt PPTX fájlként

Ez a C++ kód megmutatja, hogyan hozhat létre egy radar diagramot:

```c++
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Radar, 20.0f, 20.0f, 400.0f, 300.0f);
presentation->Save(u"Radar-chart.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Többkategóriás diagramok létrehozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.
1. Szerezze meg a dia referenciáját az indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal a kívánt típussal (`ChartType.ClusteredColumn`).
1. Érje el a diagram adat‑IChartDataWorkbook objektumát.
1. Törölje az alapértelmezett sorozatokat és kategóriákat.
1. Adjon hozzá új sorozatokat és kategóriákat.
1. Adjon hozzá új diagramadatokat a sorozathoz.
1. Írja a módosított prezentációt PPTX fájlként.

Ez a C++ kód megmutatja, hogyan hozhat létre egy többkategóriás diagramot:

```c++
	// A dokumentumok könyvtárának útvonala.
	const String outPath = u"../out/MultiCategoryChart_out.pptx";

	//PPTX fájlt reprezentáló Presentation osztály példányosítása
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	//Az első dia elérése
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Diagram hozzáadása alapértelmezett adatokkal
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);

	// Beállítja a diagram adatlap indexét
	int defaultWorksheetIndex = 0;

	// Lekéri a diagram adat munkalapot
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

	// Törli a munkafüzetet
	fact->Clear(defaultWorksheetIndex);

	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();


	// Kategóriák hozzáadása
	SharedPtr<IChartCategory> category = chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c2", ObjectExt::Box<System::String>(u"A")));
	category->get_GroupingLevels()->SetGroupingItem(1, ObjectExt::Box<System::String>(u"Group1"));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c3", ObjectExt::Box<System::String>(u"B")));
	
	category = chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c4", ObjectExt::Box<System::String>(u"C")));
	category->get_GroupingLevels()->SetGroupingItem(1, ObjectExt::Box<System::String>(u"Group2"));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c5", ObjectExt::Box<System::String>(u"D")));

	category = chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c6", ObjectExt::Box<System::String>(u"E")));
	category->get_GroupingLevels()->SetGroupingItem(1, ObjectExt::Box<System::String>(u"Group3"));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c7", ObjectExt::Box<System::String>(u"F")));


	category = chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c8", ObjectExt::Box<System::String>(u"G")));
	category->get_GroupingLevels()->SetGroupingItem(1, ObjectExt::Box<System::String>(u"Group4"));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c9", ObjectExt::Box<System::String>(u"H")));

	// Új sorozat hozzáadása
	SharedPtr<IChartSeries>  series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(0, u"D1", ObjectExt::Box<System::String>(u"Series 1")),
		ChartType::ClusteredColumn);

	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D2", ObjectExt::Box<double>(10)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D3", ObjectExt::Box<double>(20)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D4", ObjectExt::Box<double>(30)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D5", ObjectExt::Box<double>(40)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D6", ObjectExt::Box<double>(50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D7", ObjectExt::Box<double>(60)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D8", ObjectExt::Box<double>(70)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D9", ObjectExt::Box<double>(80)));

	// Mentés a prezentációt
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Térképi diagramok létrehozása**

A térképi diagram egy olyan terület vizualizációja, amely adatokat tartalmaz. Térképi diagramok leginkább adat- vagy érték-összehasonlításra használhatók földrajzi régiók között.

Ez a C++ kód megmutatja, hogyan hozhat létre egy térképi diagramot:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Map, 50.0f, 50.0f, 500.0f, 400.0f);
pres->Save(u"mapChart.pptx", SaveFormat::Pptx);
```

### **Kombinációs diagramok létrehozása**

A kombinációs diagram (vagy combo diagram) több diagramtípust egyesít egyetlen ábrában. Ez a diagram lehetővé teszi, hogy kiemelje, összehasonlítsa vagy megvizsgálja két vagy több adatkészlet közti különbségeket, segítve a kapcsolatuk azonosítását.

![A kombinációs diagram](combination_chart.png)

Az alábbi C++ kód megmutatja, hogyan hozható létre a fenti kombinációs diagram PowerPoint prezentációban:

```cpp
static SharedPtr<IChart> CreateChartWithFirstSeries(SharedPtr<ISlide> slide)
{
    auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    // Állítsa be a diagram címét.
    chart->set_HasTitle(true);
    chart->get_ChartTitle()->AddTextFrameForOverriding(u"Chart Title");
    chart->get_ChartTitle()->set_Overlay(false);
    auto titleParagraph = chart->get_ChartTitle()->get_TextFrameForOverriding()->get_Paragraph(0);
    auto titleFormat = titleParagraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    titleFormat->set_FontBold(NullableBool::False);
    titleFormat->set_FontHeight(18.0);

    // Állítsa be a diagram jelmagyarázatát.
    chart->get_Legend()->set_Position(LegendPositionType::Bottom);
    chart->get_Legend()->get_TextFormat()->get_PortionFormat()->set_FontHeight(12.0);

    // Törli az alapértelmezett generált sorozatokat és kategóriákat.
    chart->get_ChartData()->get_Series()->Clear();
    chart->get_ChartData()->get_Categories()->Clear();

    const int worksheetIndex = 0;
    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

    // Új kategóriák hozzáadása.
    chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"Category 1")));
    chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Category 2")));
    chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Category 3")));
    chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 4, 0, ObjectExt::Box<String>(u"Category 4")));

    // Az első sorozat hozzáadása.
    auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Series 1"));
    auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, chart->get_Type());

    series->get_ParentSeriesGroup()->set_Overlap(-25);
    series->get_ParentSeriesGroup()->set_GapWidth(220);

    series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box<double>(4.3)));
    series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box<double>(2.5)));
    series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box<double>(3.5)));
    series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 4, 1, ObjectExt::Box<double>(4.5)));

    return chart;
}

static void AddSecondSeriesToChart(SharedPtr<IChart> chart)
{
    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
    const int worksheetIndex = 0;

    auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 2, ObjectExt::Box<String>(u"Series 2"));
    auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, ChartType::ClusteredColumn);

    series->get_ParentSeriesGroup()->set_Overlap(-25);
    series->get_ParentSeriesGroup()->set_GapWidth(220);

    series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 2, ObjectExt::Box<double>(2.4)));
    series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 2, ObjectExt::Box<double>(4.4)));
    series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 2, ObjectExt::Box<double>(1.8)));
    series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 4, 2, ObjectExt::Box<double>(2.8)));
}

static void AddThirdSeriesToChart(SharedPtr<IChart> chart)
{
    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
    const int worksheetIndex = 0;

    auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 3, ObjectExt::Box<String>(u"Series 3"));
    auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, ChartType::Line);

    series->get_DataPoints()->AddDataPointForLineSeries(workbook->GetCell(worksheetIndex, 1, 3, ObjectExt::Box<double>(2.0)));
    series->get_DataPoints()->AddDataPointForLineSeries(workbook->GetCell(worksheetIndex, 2, 3, ObjectExt::Box<double>(2.0)));
    series->get_DataPoints()->AddDataPointForLineSeries(workbook->GetCell(worksheetIndex, 3, 3, ObjectExt::Box<double>(3.0)));
    series->get_DataPoints()->AddDataPointForLineSeries(workbook->GetCell(worksheetIndex, 4, 3, ObjectExt::Box<double>(5.0)));

    series->set_PlotOnSecondAxis(true);
}

static void SetAxisTitle(SharedPtr<IAxis> axis, String axisTitle)
{
    axis->set_HasTitle(true);
    axis->get_Title()->set_Overlay(false);
    auto titleParagraph = axis->get_Title()->AddTextFrameForOverriding(axisTitle)->get_Paragraph(0);
    auto titleFormat = titleParagraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    titleFormat->set_FontBold(NullableBool::False);
    titleFormat->set_FontHeight(12.0);
}

static void SetPrimaryAxesFormat(SharedPtr<IChart> chart)
{
    // A vízszintes tengely beállítása.
    auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();
    horizontalAxis->get_TextFormat()->get_PortionFormat()->set_FontHeight(12.0);
    horizontalAxis->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);

    SetAxisTitle(horizontalAxis, u"X Axis");

    // A függőleges tengely beállítása.
    auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
    verticalAxis->get_TextFormat()->get_PortionFormat()->set_FontHeight(12.0);
    verticalAxis->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);

    SetAxisTitle(verticalAxis, u"Y Axis 1");

    // A függőleges fő rácsvonalak színének beállítása.
    auto majorGridLinesFormat = verticalAxis->get_MajorGridLinesFormat()->get_Line()->get_FillFormat();
    majorGridLinesFormat->set_FillType(FillType::Solid);
    majorGridLinesFormat->get_SolidFillColor()->set_Color(Color::FromArgb(217, 217, 217));
}

static void SetSecondaryAxesFormat(SharedPtr<IChart> chart)
{
    // A másodlagos vízszintes tengely beállítása.
    auto secondaryHorizontalAxis = chart->get_Axes()->get_SecondaryHorizontalAxis();
    secondaryHorizontalAxis->set_Position(AxisPositionType::Bottom);
    secondaryHorizontalAxis->set_CrossType(CrossesType::Maximum);
    secondaryHorizontalAxis->set_IsVisible(false);
    secondaryHorizontalAxis->get_MajorGridLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);
    secondaryHorizontalAxis->get_MinorGridLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);

    // A másodlagos függőleges tengely beállítása.
    auto secondaryVerticalAxis = chart->get_Axes()->get_SecondaryVerticalAxis();
    secondaryVerticalAxis->set_Position(AxisPositionType::Right);
    secondaryVerticalAxis->get_TextFormat()->get_PortionFormat()->set_FontHeight(12.0);
    secondaryVerticalAxis->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);
    secondaryVerticalAxis->get_MajorGridLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);
    secondaryVerticalAxis->get_MinorGridLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);

    SetAxisTitle(secondaryVerticalAxis, u"Y Axis 2");
}

static void CreateComboChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = CreateChartWithFirstSeries(slide);

    AddSecondSeriesToChart(chart);
    AddThirdSeriesToChart(chart);

    SetPrimaryAxesFormat(chart);
    SetSecondaryAxesFormat(chart);

    presentation->Save(u"combo-chart.pptx", SaveFormat::Pptx);
    presentation->Dispose();
}
```

## **Diagramok frissítése**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból, amely a diagramot tartalmazó prezentációt képviseli.
2. Szerezze meg a dia referenciáját az indexe alapján.
3. Járja be az összes alakzatot a kívánt diagram megtalálásához.
4. Érje el a diagram adatmunkalapját.
5. Módosítsa a diagram sorozatadatokat a sorozatértékek megváltoztatásával.
6. Adjon hozzá egy új sorozatot, és töltse fel adatokkal.
7. Írja a módosított prezentációt PPTX fájlként.

Ez a C++ kód megmutatja, hogyan frissíthet egy diagramot:

```c++
// Létrehozza a PPTX fájlt reprezentáló Presentation osztályt
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"ExistingChart.pptx");

// Az első dia elérése
System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Diagram hozzáadása alapértelmezett adatokkal
System::SharedPtr<IChart> chart = System::ExplicitCast<Aspose::Slides::Charts::IChart>(sld->get_Shapes()->idx_get(0));

// Beállítja a diagram adatlap indexét
int32_t defaultWorksheetIndex = 0;

// Lekéri a diagram adat munkalapot
System::SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


// Módosítja a diagram kategória nevét
fact->GetCell(defaultWorksheetIndex, 1, 0, System::ObjectExt::Box<System::String>(u"Modified Category 1"));
fact->GetCell(defaultWorksheetIndex, 2, 0, System::ObjectExt::Box<System::String>(u"Modified Category 2"));

// Az első diagram sorozatát veszi
System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

// Frissíti a sorozat adatait
fact->GetCell(defaultWorksheetIndex, 0, 1, System::ObjectExt::Box<System::String>(u"New_Series1"));
// Sorozat nevét módosítja
series->get_DataPoints()->idx_get(0)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(90));
series->get_DataPoints()->idx_get(1)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(123));
series->get_DataPoints()->idx_get(2)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(44));

// A második diagram sorozatát veszi
series = chart->get_ChartData()->get_Series()->idx_get(1);

// Most frissíti a sorozat adatait
fact->GetCell(defaultWorksheetIndex, 0, 2, System::ObjectExt::Box<System::String>(u"New_Series2"));
// Sorozat nevét módosítja
series->get_DataPoints()->idx_get(0)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(23));
series->get_DataPoints()->idx_get(1)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(67));
series->get_DataPoints()->idx_get(2)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(99));


// Most új sorozatot ad hozzá
chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 3, System::ObjectExt::Box<System::String>(u"Series 3")), chart->get_Type());

// A harmadik diagram sorozatát veszi
series = chart->get_ChartData()->get_Series()->idx_get(2);

// Most feltölti a sorozat adataival
series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 3, System::ObjectExt::Box<int32_t>(20)));
series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 3, System::ObjectExt::Box<int32_t>(50)));
series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 3, System::ObjectExt::Box<int32_t>(30)));

chart->set_Type(Aspose::Slides::Charts::ChartType::ClusteredCylinder);

// Mentés a diagrammal együtt
pres->Save(u"AsposeChartModified_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Adattartomány beállítása diagramokhoz**

1. Nyisson meg egy [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) példányt, amely a diagramot tartalmazza.
2. Szerezze meg a dia referenciáját az indexe alapján.
3. Járja be az összes alakzatot a kívánt diagram megtalálásához.
4. Érje el a diagram adatokat, és állítsa be a tartományt.
5. Mentse el a módosított prezentációt PPTX fájlként.

Ez a C++ kód megmutatja, hogyan állítható be egy diagram adattartománya:

```cpp
// A dokumentumok könyvtárának útvonala.
String dataDir = GetDataPath();

// PPTX fájlt reprezentáló Presentation osztály példányosítása
auto presentation = System::MakeObject<Presentation>(dataDir + u"ExistingChart.pptx");

// Az első slideMarker elérése és diagram hozzáadása alapértelmezett adatokkal
auto slide = presentation->get_Slides()->idx_get(0);
auto chart = System::ExplicitCast<IChart>(slide->get_Shapes()->idx_get(0));
chart->get_ChartData()->SetRange(u"Sheet1!A1:B4");
presentation->Save(dataDir + u"SetDataRange_out.pptx", SaveFormat::Pptx);
```

## **Alapértelmezett jelölők használata diagramokban**
Alapértelmezett jelölő használatakor a diagram minden sorozata automatikusan más‑más alapértelmezett jelölőszimbólumot kap.

Ez a C++ kód megmutatja, hogyan állíthat be automatikusan egy diagram sorozat jelölőt:

```cpp
	// A dokumentumok könyvtárának útvonala.
	String dataDir = GetDataPath();

	auto pres = System::MakeObject<Presentation>();

	auto slide = pres->get_Slides()->idx_get(0);
	auto chart = slide->get_Shapes()->AddChart(ChartType::LineWithMarkers, 10.0f, 10.0f, 400.0f, 400.0f);

	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();

	auto wb = chart->get_ChartData()->get_ChartDataWorkbook();
	chart->get_ChartData()->get_Series()->Add(wb->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
	auto series = chart->get_ChartData()->get_Series()->idx_get(0);

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, 1, 0, ObjectExt::Box<String>(u"C1")));
	series->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 1, 1, ObjectExt::Box<int32_t>(24)));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, 2, 0, ObjectExt::Box<String>(u"C2")));
	series->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 2, 1, ObjectExt::Box<int32_t>(23)));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, 3, 0, ObjectExt::Box<String>(u"C3")));
	series->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 3, 1, ObjectExt::Box<int32_t>(-10)));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, 4, 0, ObjectExt::Box<String>(u"C4")));
	series->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 4, 1, nullptr));

	chart->get_ChartData()->get_Series()->Add(wb->GetCell(0, 0, 2, ObjectExt::Box<String>(u"Series 2")), chart->get_Type());

	// A második diagram sorozatát veszi
	auto series2 = chart->get_ChartData()->get_Series()->idx_get(1);

	// Feltölti a sorozat adataival
	series2->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 1, 2, ObjectExt::Box<int32_t>(30)));
	series2->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 2, 2, ObjectExt::Box<int32_t>(10)));
	series2->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 3, 2, ObjectExt::Box<int32_t>(60)));
	series2->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 4, 2, ObjectExt::Box<int32_t>(40)));

	chart->set_HasLegend(true);
	chart->get_Legend()->set_Overlay(false);

	pres->Save(dataDir + u"DefaultMarkersInChart.pptx", SaveFormat::Pptx);
```

## **GYIK**

**Milyen diagramtípusokat támogat az Aspose.Slides?**

Az Aspose.Slides széles körű diagramtípusokat támogat, többek között oszlop, vonal, kör, terület, szórt, hisztogram, radar és még sok más. Ez a rugalmasság lehetővé teszi, hogy az adatvizualizációs igényeinek leginkább megfelelőt válassza.

**Hogyan adhatok új diagramot egy diára?**

Diagram hozzáadásához először hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) példányt, szerezze meg a kívánt diát az indexe alapján, majd hívja meg a diagram hozzáadására szolgáló metódust, megadva a diagram típust és a kezdeti adatokat. Ez a folyamat közvetlenül a diagramot integrálja a prezentációba.

**Hogyan frissíthetem a diagramon megjelenített adatokat?**

A diagram adatait a [IChartDataWorkbook](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdataworkbook/) elérésével, az alapértelmezett sorozatok és kategóriák törlésével, majd saját adatainak hozzáadásával frissítheti. Ez lehetővé teszi a diagram programozott frissítését a legújabb adatok megjelenítésére.

**Testreszabható-e a diagram megjelenése?**

Igen, az Aspose.Slides kiterjedt testreszabási lehetőségeket kínál. Módosíthat színeket, betűtípusokat, címkéket, jelmagyarázatokat és egyéb formázási elemeket, hogy a diagram megjelenése megfeleljen a konkrét tervezési követelményeknek.