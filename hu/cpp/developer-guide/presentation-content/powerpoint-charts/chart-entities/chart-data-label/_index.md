---
title: Diagram adatcímkék kezelése prezentációkban C++ használatával
linktitle: Adatcímke
type: docs
url: /hu/cpp/chart-data-label/
keywords:
- diagram
- adatcímke
- adat pontosság
- százalék
- címke távolság
- címke hely
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan adhat hozzá és formázhat diagram adatcímkéket PowerPoint prezentációkban az Aspose.Slides for C++ használatával, hogy vonzóbb diák legyenek."
---
## **Bevezetés**

Az adatcímkék a diagramon a diagram adat sorozatairól vagy egyes adatpontokról nyújtanak részleteket. Segítséget nyújtanak az olvasóknak az adat sorozatok gyors azonosításához, és megkönnyítik a diagramok megértését.

## **Az adatpontok pontosságának beállítása a diagram adatcímkéiben**

Ez a C++ kód bemutatja, hogyan lehet beállítani az adatpontok pontosságát egy diagram adatcímkéjében:

```c++
	// A dokumentumok könyvtárának elérési útja
	const String outPath = u"../out/SettingPrecisionOfDataLabel_out.pptx";

	// Létrehozza a Presentation osztályt, amely egy PPTX fájlt képvisel
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Lekéri az első diát
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Alapértelmezett adatokkal hozzáad egy diagramot
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Line, 0, 0, 500, 500);

	// Beállítja a sorozat száformátumát
	chart->set_HasDataTable( true);
	chart->get_ChartData()->get_Series()->idx_get(0)->set_NumberFormatOfValues (u"#,##0.00");

	// A prezentáció fájlt leírja a lemezre
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Százalékok megjelenítése címkékként**
Aspose.Slides for C++ lehetővé teszi százalékcímkék beállítását a megjelenített diagramokon. Ez a C++ kód bemutatja a működést:

```c++
	// A dokumentumok könyvtárának elérési útja
	const String outPath = u"../out/DisplayPercentageAsLabels_out.pptx";

	// Létrehoz egy példányt a Presentation osztályból
	System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

	System::SharedPtr<ISlide> slide = presentation->get_Slides()->idx_get(0);
	System::SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::StackedColumn, 20, 20, 400, 400);
	System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);
	System::SharedPtr<IChartCategory> cat;
	System::ArrayPtr<double> total_for_Cat = System::MakeObject<System::Array<double>>(chart->get_ChartData()->get_Categories()->get_Count(), 0);
	for (int32_t k = 0; k < chart->get_ChartData()->get_Categories()->get_Count(); k++)
	{
		cat = chart->get_ChartData()->get_Categories()->idx_get(k);

		for (int32_t i = 0; i < chart->get_ChartData()->get_Series()->get_Count(); i++)
		{
			total_for_Cat[k] = total_for_Cat[k] + System::Convert::ToDouble(chart->get_ChartData()->get_Series()->idx_get(i)->get_DataPoints()->idx_get(k)->get_Value()->get_Data());
		}
	}

	double dataPontPercent = 0.f;

	for (int32_t x = 0; x < chart->get_ChartData()->get_Series()->get_Count(); x++)
	{
		series = chart->get_ChartData()->get_Series()->idx_get(x);
		series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLegendKey(false);

		for (int32_t j = 0; j < series->get_DataPoints()->get_Count(); j++)
		{
			System::SharedPtr<IDataLabel> lbl = series->get_DataPoints()->idx_get(j)->get_Label();
			dataPontPercent = (System::Convert::ToDouble(series->get_DataPoints()->idx_get(j)->get_Value()->get_Data()) / total_for_Cat[j]) * 100;

			System::SharedPtr<IPortion> port = System::MakeObject<Portion>();
			port->set_Text(System::String::Format(u"{0:F2} %", dataPontPercent));
			port->get_PortionFormat()->set_FontHeight(8.f);
			lbl->get_TextFrameForOverriding()->set_Text(u"");
			System::SharedPtr<IParagraph> para = lbl->get_TextFrameForOverriding()->get_Paragraphs()->idx_get(0);
			para->get_Portions()->Add(port);

			lbl->get_DataLabelFormat()->set_ShowSeriesName(false);
			lbl->get_DataLabelFormat()->set_ShowPercentage(false);
			lbl->get_DataLabelFormat()->set_ShowLegendKey(false);
			lbl->get_DataLabelFormat()->set_ShowCategoryName(false);
			lbl->get_DataLabelFormat()->set_ShowBubbleSize(false);
		}
	}

	// Mentésre kerül a diagramot tartalmazó prezentáció
	presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **A százalékjel beállítása diagram adatcímkékkel**
Ez a C++ kód megmutatja, hogyan állítható be a százalékjel egy diagram adatcímkére:

```c++
	// A dokumentumok könyvtárának elérési útja.
	const String outPath = u"../out/DataLabelsPercentageSign_out.pptx";

	// Létrehoz egy példányt a Presentation osztályból
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Lekéri egy dia referenciáját az indexe alapján
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Létrehozza a PercentsStackedColumn diagramot egy dián
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::PercentsStackedColumn, 0, 0, 500, 500);

	// A NumberFormatLinkedToSource beállítása false értékre
	chart->get_Axes()->get_VerticalAxis()->set_IsNumberFormatLinkedToSource ( false);
	chart->get_Axes()->get_VerticalAxis()->set_NumberFormat(u"0.00%");


	// Beállítja a diagram adatlap indexét
	int defaultWorksheetIndex = 0;

	// Lekéri a diagram adatlapot
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// Törli az alapértelmezett generált sorozatot 
	chart->get_ChartData()->get_Series()->Clear();
	

	// Új sorozatot ad hozzá
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Series 2")), chart->get_Type());


	// Az első diagram sorozatot veszi
	SharedPtr<IChartSeries> series=chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Red")), chart->get_Type());
	// Kitölti a sorozat adataival
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(0.80)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 1, ObjectExt::Box<double>(0.65)));

	// Beállítja a sorozat kitöltő színét
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

	// Beállítja a LabelFormat tulajdonságait
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource ( false);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat (u"0.0%");
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight ( 10);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// A második diagram sorozatot veszi
	SharedPtr<IChartSeries> series2 = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Blues")), chart->get_Type());
	// Kitölti a sorozat adataival
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(0.70)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(0.50)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(0.20)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 2, ObjectExt::Box<double>(0.35)));

	// Beállítja a sorozat kitöltő színét
	series2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

	// Beállítja a LabelFormat tulajdonságait
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource(false);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat(u"0.0%");
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight(10);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// A prezentáció fájlt leírja a lemezre
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Címke távolságának beállítása a tengelytől**
Ez a C++ kód bemutatja, hogyan állítható be a címke távolsága egy kategória tengelytől, ha olyan diagramról van szó, amely a tengelyek alapján van ábrázolva:

```c++
	// A dokumentumok könyvtárának elérési útja
	const String outPath = u"../out/CategoryAxisLabelDistance_out.pptx";

	// Létrehoz egy példányt a Presentation osztályból
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Lekéri egy dia referenciáját
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Létrehoz egy diagramot a dián
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);


	// Lekéri a diagram sorozatgyűjteményét
	SharedPtr<IChartSeriesCollection> seriesCollection = chart->get_ChartData()->get_Series();

	// Beállítja a címke távolságát egy tengelytől
	chart->get_Axes()->get_HorizontalAxis()->set_LabelOffset ( 500);

	// A prezentáció fájlt leírja a lemezre
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Címke helyének módosítása**

Amikor olyan diagramot hozunk létre, amely nem támaszkodik semmilyen tengelyre, például kördiagramra, a diagram adatcímkéi túl közel kerülhetnek a szélhez. Ilyen esetben módosítani kell a címke helyét, hogy a vezető vonalak jól láthatók legyenek. Ez a C++ kód megmutatja, hogyan állítható be a címke helye egy kördiagramon:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<IChart> chart = pres->get_Slide(0)->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 200.0f, 200.0f);

System::SharedPtr<IChartSeriesCollection> series = chart->get_ChartData()->get_Series();
System::SharedPtr<IDataLabel> label = series->idx_get(0)->get_Label(0);
System::SharedPtr<IDataLabelFormat> dataLabelFormat = label->get_DataLabelFormat();

dataLabelFormat->set_ShowValue(true);
dataLabelFormat->set_Position(LegendDataLabelPosition::OutsideEnd);
label->set_X(0.71f);
label->set_Y(0.04f);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **GYIK**

**Hogyan lehet megakadályozni az adatcímkék átfedését zsúfolt diagramokon?**

Kombinálja az automatikus címkeelhelyezést, a vezető vonalakat és a csökkentett betűméretet; szükség esetén rejtsen el néhány mezőt (például a kategóriát), vagy csak a szélső/kulcsfontosságú pontokhoz jelenítsen meg címkéket.

**Hogyan lehet letiltani a címkéket csak a nulla, negatív vagy üres értékeknél?**

Szűrje a adatpontokat a címkék engedélyezése előtt, és kapcsolja ki a megjelenítést a 0, a negatív vagy a hiányzó értékek esetén egy meghatározott szabály alapján.

**Hogyan biztosítható a konzisztens címkestílus PDF/képek exportálásakor?**

Explicit módon állítsa be a betűtípusokat (család, méret), és ellenőrizze, hogy a betűtípus elérhető legyen a renderelő oldalon, hogy elkerülje a visszaesést.