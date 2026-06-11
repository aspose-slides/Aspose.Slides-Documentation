---
title: Skapa eller uppdatera PowerPoint-presentationdiagram i C++
linktitle: Skapa eller uppdatera diagram
type: docs
weight: 10
url: /sv/cpp/create-chart/
keywords:
- lägg till diagram
- skapa diagram
- redigera diagram
- ändra diagram
- uppdatera diagram
- spritt diagram
- cirkeldiagram
- linjediagram
- trädkartsdiagram
- börsdiagram
- box-and-whisker-diagram
- trattdiagram
- solstrålediagram
- histogramdiagram
- radardiagram
- multikategori-diagram
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Skapa och anpassa diagram i PowerPoint-presentationer med Aspose.Slides för C++. Lägg till, formatera och redigera diagram med praktiska kodexempel i C++."
---
## **Översikt**

Det här artikeln ger en omfattande guide för hur du skapar och anpassar diagram med Aspose.Slides. Du kommer att lära dig hur du programatiskt lägger till ett diagram på en bild, fyller det med data och tillämpar olika formateringsalternativ för att matcha dina specifika designkrav. Genom hela artikeln illustreras varje steg med detaljerade kodexempel, från initialisering av presentationen och diagramobjektet till konfiguration av serier, axlar och förklaringar. Genom att följa den här guiden får du en solid förståelse för hur du integrerar dynamisk diagramgenerering i dina applikationer, vilket förenklar processen att skapa datadrivna presentationer.

## **Skapa ett diagram**

Diagram hjälper personer att snabbt visualisera data och få insikter, vilket kanske inte är omedelbart uppenbart från en tabell eller ett kalkylblad. 

**Varför skapa diagram?**

Genom att använda diagram kan du

* aggregatera, komprimera eller sammanfatta stora mängder data på ett enda bild i en presentation
* avslöja mönster och trender i data
* fastställa riktning och momentum för data över tid eller i förhållande till en specifik mätenhet 
* identifiera avvikande värden, avvikelser, fel, nonsensisk data etc. 
* kommunicera eller presentera komplex data

I PowerPoint kan du skapa diagram via infogningsfunktionen, som tillhandahåller mallar för att designa många typer av diagram. Med Aspose.Slides kan du skapa vanliga diagram (baserade på populära diagramtyper) och anpassade diagram. 

{{% alert color="primary" %}} 

För att låta dig skapa diagram tillhandahåller Aspose.Slides enum‑klassen [ChartType](https://reference.aspose.com/slides/sv/cpp/namespace/aspose.slides.charts#a23ba9ea390f5be4c8f5ab18baf4f8c05) under namnutrymmet [Aspose::Slides::Charts](https://reference.aspose.com/slides/sv/cpp/namespace/aspose.slides.charts/). Värdena i denna enum‑klass motsvarar olika diagramtyper. 

{{% /alert %}} 

### **Skapa vanliga diagram**
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation).
1. Hämta en bilds referens via dess index.
1. Lägg till ett diagram med lite data och ange din föredragna diagramtyp. 
1. Lägg till en titel för diagrammet. 
1. Få åtkomst till diagrammets dataarbetsblad.
1. Rensa alla standardserier och kategorier.
1. Lägg till nya serier och kategorier.
1. Lägg till ny diagramdata för diagramserien.
1. Lägg till en fyllnadsfärg för diagramserierna.
1. Lägg till etiketter för diagramserierna. 
1. Skriv den modifierade presentationen som en PPTX‑fil.

Detta C++‑kodexempel visar hur du skapar ett vanligt diagram:

```c++
// Sökvägen till dokumentkatalogen.
	const String outPath = u"../out/NormalCharts_out.pptx";

	//Skapar en presentation-klass som representerar en PPTX-fil
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	//Hämtar den första bilden
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Lägger till ett diagram med standarddata
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);


	// Ställer in index för diagramdatabladet
	int defaultWorksheetIndex = 0;

	// Hämtar diagramdatabladet
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

	// Ställer in diagramtiteln
	chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sample Title");
	chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText ( NullableBool::True);
	chart->get_ChartTitle()->set_Height(20);
	chart->set_HasTitle( true);

	// Tar bort de defaultgenererade serierna och kategorierna
	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();
	int s = chart->get_ChartData()->get_Series()->get_Count();
	s = chart->get_ChartData()->get_Categories()->get_Count();


	// Lägger till en ny serie
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Series 2")), chart->get_Type());

	// Lägger till kategorier
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 1, 0, ObjectExt::Box<System::String>(u"Caetegoty 1")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 2, 0, ObjectExt::Box<System::String>(u"Caetegoty 2")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 3, 0, ObjectExt::Box<System::String>(u"Caetegoty 3")));

	
	// Hämtar den första diagramserien
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

	// Fyller på seriedata
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(20)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(30)));

	// Ställer in fyllnadsfärgen för serien
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());


	// Hämtar den andra diagramserien
	 series = chart->get_ChartData()->get_Series()->idx_get(1);

	// Fyller på seriedata
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(30)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(10)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(60)));

	// Ställer in fyllnadsfärgen för serien
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Green());


	// Första etiketten sätts att visa kategorinamn
	SharedPtr<IDataLabel> lbl = series->get_DataPoints()->idx_get(0)->get_Label();
	lbl->get_DataLabelFormat()->set_ShowCategoryName(true);

	lbl = series->get_DataPoints()->idx_get(1)->get_Label();
	lbl->get_DataLabelFormat()->set_ShowSeriesName (true);

	// Visar värdet för tredje etiketten
	lbl = series->get_DataPoints()->idx_get(2)->get_Label();
	lbl->get_DataLabelFormat()->set_ShowValue (true);
	lbl->get_DataLabelFormat()->set_ShowSeriesName(true);
	lbl->get_DataLabelFormat()->set_Separator (u"/");

	// Sparar presentationen
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Skapa spridda diagram**
Spridda diagram (även kända som spridda plotter eller x‑y‑diagram) används ofta för att kontrollera mönster eller visa korrelationer mellan två variabler. 

Du kan vilja använda ett spritt diagram när 

* du har parade numeriska data
* du har 2 variabler som passar bra ihop
* du vill avgöra om 2 variabler är relaterade
* du har en oberoende variabel som har flera värden för en beroende variabel

Detta C++‑kodexempel visar hur du skapar ett spritt diagram med olika serie‑markörer: 

```c++
// Sökvägen till dokumentkatalogen.
	const String outPath = u"../out/ScatteredChart_out.pptx";

	//Instansierar en presentation-klass som representerar en PPTX-fil
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	//Hämtar den första bilden
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Lägger till ett diagram med standarddata
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ScatterWithSmoothLines, 0, 0, 500, 500);

	// Ställer in diagramtiteln
	chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sample Title");
	chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText(NullableBool::True);
	chart->get_ChartTitle()->set_Height(20);
	chart->set_HasTitle(true);

	// Tar bort de standardgenererade serierna 
	chart->get_ChartData()->get_Series()->Clear();
	
	// Ställer in  indexet för diagramdatabladet
	int defaultWorksheetIndex = 0;

	// Hämtar diagramdatabladet
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// Lägger till en ny serie
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 3, ObjectExt::Box<System::String>(u"Series 2")), chart->get_Type());

	// Hämtar den första diagramserien
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

	// Lägger till en ny punkt (1:3)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(1)), fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(3)));

	// Lägger till en ny punkt (2:10)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(2)), fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(10)));

	// Redigerar serietypen
	series->set_Type (ChartType::ScatterWithStraightLinesAndMarkers);

	// Ändrar diagramseriens markör
	series->get_Marker()->set_Size  (10);
	series->get_Marker()->set_Symbol(MarkerStyleType::Star);



	// Hämtar den andra diagramserien
	series  = chart->get_ChartData()->get_Series()->idx_get(1);

	// Lägger till en ny punkt (5:2)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 2, 3, ObjectExt::Box<double>(5)), fact->GetCell(defaultWorksheetIndex, 2, 4, ObjectExt::Box<double>(2)));

	// Lägger till en ny punkt (3:1)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 3, 3, ObjectExt::Box<double>(3)), fact->GetCell(defaultWorksheetIndex, 3, 4, ObjectExt::Box<double>(1)));

	// Lägger till en ny punkt (2:2)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 4, 3, ObjectExt::Box<double>(2)), fact->GetCell(defaultWorksheetIndex, 4, 4, ObjectExt::Box<double>(2)));

	// Lägger till en ny punkt (5:1)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 5, 3, ObjectExt::Box<double>(5)), fact->GetCell(defaultWorksheetIndex, 5, 4, ObjectExt::Box<double>(1)));

	// Ändrar diagramseriens markör
	series->get_Marker()->set_Size ( 10);
	series->get_Marker()->set_Symbol(MarkerStyleType::Circle);



	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_IsColorVaried(true);

	SharedPtr<IChartDataPoint> point = series->get_DataPoints()->idx_get(0);
	point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Cyan());
	// Ställer in sektorns kant
	point->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Gray());
	point->get_Format()->get_Line()->set_Width ( 3.0);
	point->get_Format()->get_Line()->set_Style(LineStyle::ThinThick);
	point->get_Format()->get_Line()->set_DashStyle(LineDashStyle::DashDot);

	SharedPtr<IChartDataPoint> point1 = series->get_DataPoints()->idx_get(1);
	point1->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Brown());

	// Ställer in sektorns kant
	point1->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());
	point1->get_Format()->get_Line()->set_Width (3.0);
	point1->get_Format()->get_Line()->set_Style(LineStyle::Single);
	point1->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDot);


	SharedPtr<IChartDataPoint> point2 = series->get_DataPoints()->idx_get(2);
	point2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Coral());

	// Ställer in sektorns kant
	point2->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
	point2->get_Format()->get_Line()->set_Width ( 2.0);
	point2->get_Format()->get_Line()->set_Style(LineStyle::ThickThin);
	point2->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDotDot);


	// Skapar anpassade etiketter för varje kategori i den nya serien
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

	// Visar ledarlinjer för diagrammet
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLeaderLines(true);

	// Ställer in rotationsvinkeln för sektorer i cirkeldiagram
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_FirstSliceAngle(180);


	// Sparar presentationen
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Skapa cirkeldiagram**
Cirkeldiagram används bäst för att visa förhållandet del‑till‑helhet i data, särskilt när data innehåller kategoriska etiketter med numeriska värden. Om dina data innehåller många delar eller etiketter kan du dock överväga att använda ett stapeldiagram istället. 

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation).
1. Hämta en bilds referens via dess index.
1. Lägg till ett diagram med standarddata samt önskad typ (i detta fall `ChartType.Pie`).
1. Få åtkomst till diagramdatat IChartDataWorkbook.
1. Rensa standardserier och kategorier.
1. Lägg till nya serier och kategorier.
1. Lägg till ny diagramdata för diagramserien.
1. Lägg till nya punkter för diagrammen och lägg till anpassade färger för sectorerna i cirkeldiagrammet.
1. Ställ in etiketter för serierna.
1. Ställ in ledarlinjer för serieetiketter.
1. Ställ in rotationsvinkeln för cirkeldiagramsbilder.
1. Skriv den modifierade presentationen till en PPTX‑fil

Detta C++‑kodexempel visar hur du skapar ett cirkeldiagram:

```c++
	// Sökvägen till dokumentkatalogen.
	const String outPath = u"../out/PieChart_out.pptx";

	// Instansierar en Presentation-klass som representerar en PPTX-fil
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Hämtar den första bilden
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Lägger till ett diagram med standarddata
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Pie, 0, 0, 500, 500);

	// Ställer in diagramtiteln
	chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sample Title");
	chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText(NullableBool::True);
	chart->get_ChartTitle()->set_Height(20);
	chart->set_HasTitle(true);

	// Tar bort de standardgenererade serierna och kategorierna
	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();

	// Ställer in indexet för diagramdatabladet
	int defaultWorksheetIndex = 0;

	// Hämtar diagramdatabladet
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

	// Lägger till kategorier
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 1, 0, ObjectExt::Box<System::String>(u"First Qtr")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 2, 0, ObjectExt::Box<System::String>(u"2nd Qtr")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 3, 0, ObjectExt::Box<System::String>(u"3ed Qtr")));

	// Lägger till en ny serie
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());
	
	// Hämtar den första diagramserien
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

	// Fyller på seriedata
	series->get_DataPoints()->AddDataPointForPieSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(20)));
	series->get_DataPoints()->AddDataPointForPieSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(50)));
	series->get_DataPoints()->AddDataPointForPieSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(30)));

	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_IsColorVaried(true);

	SharedPtr<IChartDataPoint> point = series->get_DataPoints()->idx_get(0);
	point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Cyan());
	// Ställer in sektorns kant
	point->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Gray());
	point->get_Format()->get_Line()->set_Width ( 3.0);
	point->get_Format()->get_Line()->set_Style( LineStyle::ThinThick);
	point->get_Format()->get_Line()->set_DashStyle ( LineDashStyle::DashDot);

	SharedPtr<IChartDataPoint> point1 = series->get_DataPoints()->idx_get(1);
	point1->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Brown());

	// Ställer in sektorns kant
	point1->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());
	point1->get_Format()->get_Line()->set_Width (3.0);
	point1->get_Format()->get_Line()->set_Style(LineStyle::Single);
	point1->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDot);


	SharedPtr<IChartDataPoint> point2 = series->get_DataPoints()->idx_get(2);
	point2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Coral());

	// Ställer in sektorns kant
	point2->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
	point2->get_Format()->get_Line()->set_Width (2.0);
	point2->get_Format()->get_Line()->set_Style(LineStyle::ThickThin);
	point2->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDotDot);


	// Skapar anpassade etiketter för varje kategori i den nya serien
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

	// Ställer in serien för att visa ledarlinjer för diagrammet
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLeaderLines ( true);

	// Ställer in rotationsvinkeln för cirkeldiagrammets sektorer
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_FirstSliceAngle ( 180);


	// Sparar presentationen
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Skapa linjediagram**

Linjediagram (även kallade linjediagram) används bäst i situationer där du vill demonstrera förändringar i värde över tid. Med ett linjediagram kan du jämföra mycket data på en gång, spåra förändringar och trender över tid, markera avvikelser i dataserier osv.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation).
1. Hämta en bilds referens via dess index.
1. Lägg till ett diagram med standarddata samt önskad typ (i detta fall `ChartType::Line`).
1. Få åtkomst till diagramdatat IChartDataWorkbook.
1. Rensa standardserier och kategorier.
1. Lägg till nya serier och kategorier.
1. Lägg till ny diagramdata för diagramserien.
1. Skriv den modifierade presentationen till en PPTX‑fil

Detta C++‑kodexempel visar hur du skapar ett linjediagram:

```c++
auto pres = System::MakeObject<Presentation>();

System::SharedPtr<IChart> lineChart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Line, 10.0f, 50.0f, 600.0f, 350.0f);
pres->Save(u"lineChart.pptx", SaveFormat::Pptx);
```

Som standard sammanfogas punkterna i ett linjediagram med raka kontinuerliga linjer. Om du vill att punkterna ska sammanfogas med streck istället kan du ange din föredragna strecktyp på följande sätt:

```c++
System::SharedPtr<IChart> lineChart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Line, 10.0f, 50.0f, 600.0f, 350.0f);
for (auto&& series : lineChart->get_ChartData()->get_Series())
{
    series->get_Format()->get_Line()->set_DashStyle(LineDashStyle::Dash);
}
```

### **Skapa trädkartsdiagram**

Trädkartsdiagram används bäst för försäljningsdata när du vill visa den relativa storleken på datakategorier och (samtidigt) snabbt rikta uppmärksamheten på objekt som är stora bidragsgivare till varje kategori. 

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation).
1. Hämta en bilds referens via dess index.
1. Lägg till ett diagram med standarddata samt önskad typ (i detta fall `ChartType.TreeMap`).
1. Få åtkomst till diagramdatat IChartDataWorkbook.
1. Rensa standardserier och kategorier.
1. Lägg till nya serier och kategorier.
1. Lägg till ny diagramdata för diagramserien.
1. Skriv den modifierade presentationen till en PPTX‑fil

Detta C++‑kodexempel visar hur du skapar ett trädkartsdiagram:

```c++
// Sökvägen till dokumentkatalogen.
	const String outPath = u"../out/TreemapChart_out.pptx";

	//Instansierar en Presentation-klass som representerar en PPTX-fil
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Hämtar den första bilden
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Treemap, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	// Gren 1
	System::SharedPtr<IChartCategory> leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C1", System::ObjectExt::Box<System::String>(u"Leaf1")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem1"));
	leaf->get_GroupingLevels()->SetGroupingItem(2, System::ObjectExt::Box<System::String>(u"Branch1"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C2", System::ObjectExt::Box<System::String>(u"Leaf2")));

	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C3", System::ObjectExt::Box<System::String>(u"Leaf3")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem2"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C4", System::ObjectExt::Box<System::String>(u"Leaf4")));


	// Gren 2
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

	// Sparar presentationen
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Skapa börsdiagram**
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation).
1. Hämta en bilds referens via dess index.
1. Lägg till ett diagram med standarddata samt önskad typ (ChartType.OpenHighLowClose).
1. Få åtkomst till diagramdatat IChartDataWorkbook.
1. Rensa standardserier och kategorier.
1. Lägg till nya serier och kategorier.
1. Lägg till ny diagramdata för diagramserien.
1. Specificera HiLowLines‑format.
1. Skriv den modifierade presentationen till en PPTX‑fil

Exempel på C++‑kod som används för att skapa ett börsdiagram:

```c++
	// Sökvägen till dokumentkatalogen.
	const String outPath = u"../out/AddStockChart_out.pptx";

	//Instansierar en Presentation-klass som representerar en PPTX-fil
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	//Hämtar den första bilden
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Lägger till ett diagram med standarddata
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::OpenHighLowClose, 0, 0, 500, 500);


	// Ställer in indexet för diagramdatabladet
	int defaultWorksheetIndex = 0;

	// Hämtar diagramdataarbetsbladet
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// Tar bort de standardgenererade serierna och kategorierna
	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();

	// Lägger till kategorier
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 1, 0, ObjectExt::Box<System::String>(u"A")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 2, 0, ObjectExt::Box<System::String>(u"B")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 3, 0, ObjectExt::Box<System::String>(u"C")));

	// Lägger till en ny serie
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Open")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"High")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 3, ObjectExt::Box<System::String>(u"Low")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 4, ObjectExt::Box<System::String>(u"Close")), chart->get_Type());


	// Hämtar den första diagramserien
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);
	// Fyller på data för den första serien
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(72)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(25)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(38)));


	series = chart->get_ChartData()->get_Series()->idx_get(1);
	// Fyller på data för den andra serien
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(172)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(57)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(57)));

	series = chart->get_ChartData()->get_Series()->idx_get(2);
	// Fyller på data för den andra serien
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 3, ObjectExt::Box<double>(12)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 3, ObjectExt::Box<double>(12)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 3, ObjectExt::Box<double>(13)));


	series = chart->get_ChartData()->get_Series()->idx_get(3);
	// Fyller på data för den andra serien
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 4, ObjectExt::Box<double>(25)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 4, ObjectExt::Box<double>(38)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 4, ObjectExt::Box<double>(50)));

	// Ställer in seriegruppen
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->get_UpDownBars()->set_HasUpDownBars (true);
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->get_HiLowLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);


	for(int i=0;i<chart->get_ChartData()->get_Series()->get_Count();i++)
	{
		series = chart->get_ChartData()->get_Series()->idx_get(i);
		series->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);
	}

	// Sparar presentationen
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Skapa låd- och whisker‑diagram**
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation).
1. Hämta en bilds referens via dess index.
1. Lägg till ett diagram med standarddata samt önskad typ (ChartType.BoxAndWhisker).
1. Få åtkomst till diagramdatat IChartDataWorkbook.
1. Rensa standardserier och kategorier.
1. Lägg till nya serier och kategorier.
1. Lägg till ny diagramdata för diagramserien.
1. Skriv den modifierade presentationen till en PPTX‑fil

Detta C++‑kodexempel visar hur du skapar ett låd- och whisker‑diagram:

```c++
	// Sökvägen till dokumentkatalogen.
	const String outPath = u"../out/BoxAndWhisker_out.pptx";

	// Instansierar en Presentation-klass som representerar en PPTX-fil
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Hämtar den första bilden
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


	// Sparar presentationen
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Skapa tratt‑diagram**
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation).
1. Hämta en bilds referens via dess index.
1. Lägg till ett diagram med standarddata samt önskad typ (ChartType.Funnel).
1. Skriv den modifierade presentationen till en PPTX‑fil

Detta C++‑kodexempel visar hur du skapar ett tratt‑diagram:

```c++
	// Sökvägen till dokumentkatalogen.
	const String outPath = u"../out/FunnelChart_out.pptx";

	// Instansierar en Presentation-klass som representerar en PPTX-fil
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Hämtar den första bilden
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


	// Sparar presentationen
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Skapa solstråle‑diagram**
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation).
1. Hämta en bilds referens via dess index.
1. Lägg till ett diagram med standarddata samt önskad typ (i detta fall `ChartType.sunburst`).
1. Skriv den modifierade presentationen till en PPTX‑file

Detta C++‑kodexempel visar hur du skapar ett solstråle‑diagram:

```c++
	// Sökvägen till dokumentkatalogen.
	const String outPath = u"../out/SunburstChart_out.pptx";

	// Instansierar en Presentation-klass som representerar en PPTX-fil
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Hämtar den första bilden
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart=slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Sunburst, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	// Gren 1
	System::SharedPtr<IChartCategory> leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C1", System::ObjectExt::Box<System::String>(u"Leaf1")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem1"));
	leaf->get_GroupingLevels()->SetGroupingItem(2, System::ObjectExt::Box<System::String>(u"Branch1"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C2", System::ObjectExt::Box<System::String>(u"Leaf2")));

	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C3", System::ObjectExt::Box<System::String>(u"Leaf3")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem2"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C4", System::ObjectExt::Box<System::String>(u"Leaf4")));

	// Gren 2
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

	// Skriver presentationsfilen till disk
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Skapa histogram‑diagram**
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation).
1. Hämta en bilds referens via dess index. 
1. Lägg till ett diagram med viss data och ange din föredragna diagramtyp (`ChartType.Histogram` i detta fall).
1. Få åtkomst till diagramdatat `IChartDataWorkbook`.
1. Rensa standardserier och kategorier.
1. Lägg till nya serier och kategorier.
1. Skriv den modifierade presentationen till en PPTX‑fil.

Detta C++‑kodexempel visar hur du skapar ett histogram‑diagram:

```c++
	// Sökvägen till dokumentkatalogen.
	const String outPath = u"../out/HistogramChart_out.pptx";

	// Instansierar en Presentation-klass som representerar en PPTX-fil
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Hämtar den första bilden
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

	// Sparar presentationen
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Skapa radardiagram**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation).
1. Hämta en bilds referens via dess index. 
1. Lägg till ett diagram med viss data och ange din föredragna diagramtyp (`ChartType.Radar` i detta fall).
1. Skriv den modifierade presentationen till en PPTX‑fil

Detta C++‑kodexempel visar hur du skapar ett radardiagram:

```c++
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Radar, 20.0f, 20.0f, 400.0f, 300.0f);
presentation->Save(u"Radar-chart.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Skapa multikategori‑diagram**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation).
1. Hämta en bilds referens via dess index.
1. Lägg till ett diagram med standarddata samt önskad typ (ChartType.ClusteredColumn).
1. Få åtkomst till diagramdatat IChartDataWorkbook.
1. Rensa standardserier och kategorier.
1. Lägg till nya serier och kategorier.
1. Lägg till ny diagramdata för diagramserien.
1. Skriv den modifierade presentationen till en PPTX‑fil.

Detta C++‑kodexempel visar hur du skapar ett multikategori‑diagram:

```c++
	// Sökvägen till dokumentkatalogen.
	const String outPath = u"../out/MultiCategoryChart_out.pptx";

	//Instansierar en Presentation-klass som representerar en PPTX-fil
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	//Hämtar den första bilden
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Lägger till ett diagram med standarddata
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);

	// Ställer in indexet för diagramdatabladet
	int defaultWorksheetIndex = 0;

	// Hämtar diagramdatabladet
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

	// Rensar arbetsboken
	fact->Clear(defaultWorksheetIndex);

	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();


	// Lägger till kategorier
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

	// Lägger till en ny serie
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

	// Sparar presentationen
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Skapa kartdiagram**

Ett kartdiagram är en visualisering av ett område som innehåller data. Kartdiagram används bäst för att jämföra data eller värden över geografiska regioner.

Detta C++‑kodexempel visar hur du skapar ett kartdiagram:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Map, 50.0f, 50.0f, 500.0f, 400.0f);
pres->Save(u"mapChart.pptx", SaveFormat::Pptx);
```

### **Skapa kombinationsdiagram**

Ett kombinationsdiagram (eller kombodiagram) kombinerar två eller fler diagramtyper i ett enda diagram. Detta diagram låter dig markera, jämföra eller undersöka skillnader mellan två eller fler dataset, vilket hjälper dig att identifiera relationer mellan dem.

![Kombinationsdiagrammet](combination_chart.png)

Följande C++‑kod visar hur du skapar kombinationsdiagrammet som visas ovan i en PowerPoint‑presentation:

```cpp
static SharedPtr<IChart> CreateChartWithFirstSeries(SharedPtr<ISlide> slide)
{
    auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    // Ställ in diagramtiteln.
    chart->set_HasTitle(true);
    chart->get_ChartTitle()->AddTextFrameForOverriding(u"Chart Title");
    chart->get_ChartTitle()->set_Overlay(false);
    auto titleParagraph = chart->get_ChartTitle()->get_TextFrameForOverriding()->get_Paragraph(0);
    auto titleFormat = titleParagraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    titleFormat->set_FontBold(NullableBool::False);
    titleFormat->set_FontHeight(18.0);

    // Ställ in diagramförklaringen.
    chart->get_Legend()->set_Position(LegendPositionType::Bottom);
    chart->get_Legend()->get_TextFormat()->get_PortionFormat()->set_FontHeight(12.0);

    // Ta bort de standardgenererade serierna och kategorierna.
    chart->get_ChartData()->get_Series()->Clear();
    chart->get_ChartData()->get_Categories()->Clear();

    const int worksheetIndex = 0;
    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

    // Lägg till nya kategorier.
    chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"Category 1")));
    chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Category 2")));
    chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Category 3")));
    chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 4, 0, ObjectExt::Box<String>(u"Category 4")));

    // Lägg till den första serien.
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
    // Ställ in den horisontella axeln.
    auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();
    horizontalAxis->get_TextFormat()->get_PortionFormat()->set_FontHeight(12.0);
    horizontalAxis->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);

    SetAxisTitle(horizontalAxis, u"X Axis");

    // Ställ in den vertikala axeln.
    auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
    verticalAxis->get_TextFormat()->get_PortionFormat()->set_FontHeight(12.0);
    verticalAxis->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);

    SetAxisTitle(verticalAxis, u"Y Axis 1");

    // Ställ in färgen på de vertikala huvudnätlinjerna.
    auto majorGridLinesFormat = verticalAxis->get_MajorGridLinesFormat()->get_Line()->get_FillFormat();
    majorGridLinesFormat->set_FillType(FillType::Solid);
    majorGridLinesFormat->get_SolidFillColor()->set_Color(Color::FromArgb(217, 217, 217));
}

static void SetSecondaryAxesFormat(SharedPtr<IChart> chart)
{
    // Ställ in den sekundära horisontella axeln.
    auto secondaryHorizontalAxis = chart->get_Axes()->get_SecondaryHorizontalAxis();
    secondaryHorizontalAxis->set_Position(AxisPositionType::Bottom);
    secondaryHorizontalAxis->set_CrossType(CrossesType::Maximum);
    secondaryHorizontalAxis->set_IsVisible(false);
    secondaryHorizontalAxis->get_MajorGridLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);
    secondaryHorizontalAxis->get_MinorGridLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);

    // Ställ in den sekundära vertikala axeln.
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

## **Uppdatera diagram**

1. Instansiera en [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation)‑klass som representerar presentationen som innehåller diagrammet.
2. Hämta en bilds referens via dess index.
3. Gå igenom alla former för att hitta önskat diagram.
4. Få åtkomst till diagrammets dataarbetsblad.
5. Ändra diagramseriens data genom att ändra serievärden.
6. Lägg till en ny serie och fyll i data i den.
7. Skriv den modifierade presentationen som en PPTX‑fil.

Detta C++‑kodexempel visar hur du uppdaterar ett diagram:

```c++
// Instansierar en Presentation-klass som representerar en PPTX-fil
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"ExistingChart.pptx");

// Hämtar den första bildens markör
System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Lägger till ett diagram med standarddata
System::SharedPtr<IChart> chart = System::ExplicitCast<Aspose::Slides::Charts::IChart>(sld->get_Shapes()->idx_get(0));

// Ställer in indexet för diagramdatabladet
int32_t defaultWorksheetIndex = 0;

// Hämtar diagramdatabladet
System::SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


// Ändrar diagrammets kategorinamn
fact->GetCell(defaultWorksheetIndex, 1, 0, System::ObjectExt::Box<System::String>(u"Modified Category 1"));
fact->GetCell(defaultWorksheetIndex, 2, 0, System::ObjectExt::Box<System::String>(u"Modified Category 2"));

// Hämtar den första diagramserien
System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

// Uppdaterar seriedata
fact->GetCell(defaultWorksheetIndex, 0, 1, System::ObjectExt::Box<System::String>(u"New_Series1"));
// Modifierar serienamn
series->get_DataPoints()->idx_get(0)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(90));
series->get_DataPoints()->idx_get(1)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(123));
series->get_DataPoints()->idx_get(2)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(44));

// Hämtar den andra diagramserien
series = chart->get_ChartData()->get_Series()->idx_get(1);

// Uppdaterar nu seriedata
fact->GetCell(defaultWorksheetIndex, 0, 2, System::ObjectExt::Box<System::String>(u"New_Series2"));
// Modifierar serienamn
series->get_DataPoints()->idx_get(0)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(23));
series->get_DataPoints()->idx_get(1)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(67));
series->get_DataPoints()->idx_get(2)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(99));


// Lägger nu till en ny serie
chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 3, System::ObjectExt::Box<System::String>(u"Series 3")), chart->get_Type());

// Hämtar den tredje diagramserien
series = chart->get_ChartData()->get_Series()->idx_get(2);

// Fyller nu på seriedata
series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 3, System::ObjectExt::Box<int32_t>(20)));
series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 3, System::ObjectExt::Box<int32_t>(50)));
series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 3, System::ObjectExt::Box<int32_t>(30)));

chart->set_Type(Aspose::Slides::Charts::ChartType::ClusteredCylinder);

// Spara presentationen med diagrammet
pres->Save(u"AsposeChartModified_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Ställ in dataintervall för diagram**

1. Öppna en instans av [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation)‑klassen som innehåller diagrammet.
2. Hämta en bilds referens via dess index.
3. Gå igenom alla former för att hitta önskat diagram.
4. Få åtkomst till diagramdata och ställ in intervallet.
5. Spara den modifierade presentationen som en PPTX‑fil.

Detta C++‑kodexempel visar hur du ställer in dataintervall för ett diagram:

``` cpp
// Sökvägen till dokumentkatalogen.
String dataDir = GetDataPath();

// Instansierar en Presentation-klass som representerar en PPTX-fil
auto presentation = System::MakeObject<Presentation>(dataDir + u"ExistingChart.pptx");

// Hämtar den första bildens markör och lägger till ett diagram med standarddata
auto slide = presentation->get_Slides()->idx_get(0);
auto chart = System::ExplicitCast<IChart>(slide->get_Shapes()->idx_get(0));
chart->get_ChartData()->SetRange(u"Sheet1!A1:B4");
presentation->Save(dataDir + u"SetDataRange_out.pptx", SaveFormat::Pptx);
```


## **Använd standardmarkörer i diagram**
När du använder en standardmarkör i diagram får varje diagramserie automatiskt olika standardmarkörsymboler.

Detta C++‑kodexempel visar hur du automatiskt sätter en diagramserie‑markör:

``` cpp
	// Sökvägen till dokumentkatalogen.
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

	// Hämtar den andra diagramserien
	auto series2 = chart->get_ChartData()->get_Series()->idx_get(1);

	// Fyller på seriedata
	series2->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 1, 2, ObjectExt::Box<int32_t>(30)));
	series2->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 2, 2, ObjectExt::Box<int32_t>(10)));
	series2->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 3, 2, ObjectExt::Box<int32_t>(60)));
	series2->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 4, 2, ObjectExt::Box<int32_t>(40)));

	chart->set_HasLegend(true);
	chart->get_Legend()->set_Overlay(false);

	pres->Save(dataDir + u"DefaultMarkersInChart.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Vilka diagramtyper stöds av Aspose.Slides?**

Aspose.Slides stöder ett brett spektrum av diagramtyper, inklusive stapel, linje, cirkel, område, spridd, histogram, radar och många fler. Denna flexibilitet låter dig välja den mest lämpliga diagramtypen för dina datavisualiseringsbehov.

**Hur lägger jag till ett nytt diagram på en bild?**

För att lägga till ett diagram skapar du först en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) , hämtar önskad bild med dess index och anropar sedan metoden för att lägga till ett diagram, där du specificerar diagramtyp och initial data. Denna process integrerar diagrammet direkt i din presentation.

**Hur kan jag uppdatera data som visas i ett diagram?**

Du kan uppdatera ett diagrams data genom att komma åt dess dataarbetsbok ([IChartDataWorkbook](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichartdataworkbook/)), rensa eventuella standardserier och kategorier samt sedan lägga till din egen data. Detta gör att du programatiskt kan uppdatera diagrammet så att det visar de senaste data.

**Är det möjligt att anpassa diagrammets utseende?**

Ja, Aspose.Slides erbjuder omfattande anpassningsalternativ. Du kan ändra färger, teckensnitt, etiketter, förklaringar och andra formateringselement för att skräddarsy diagrammets utseende efter dina specifika designkrav.