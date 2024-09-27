---
title: Метка данных диаграммы
type: docs
url: /ru/cpp/chart-data-label/
keywords: "Метка данных диаграммы, расстояние метки, C++, CPP, Aspose.Slides для C++"
description: "Установить метку данных диаграммы PowerPoint и расстояние в C++"
---

Метки данных на диаграмме показывают детали о серии данных диаграммы или отдельных точках данных. Они позволяют читателям быстро идентифицировать серии данных и делают диаграммы более понятными.

## **Установить точность данных в метке данных диаграммы**

Этот код на C++ демонстрирует, как установить точность данных в метке данных диаграммы:

```c++
	// Путь к каталогу документов
	const String outPath = u"../out/SettingPrecisionOfDataLabel_out.pptx";

	// Создает экземпляр класса Presentation, который представляет файл PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Получает первый слайд
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Добавляет диаграмму с данными по умолчанию
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Line, 0, 0, 500, 500);

	// Устанавливает формат номеров серии
	chart->set_HasDataTable(true);
	chart->get_ChartData()->get_Series()->idx_get(0)->set_NumberFormatOfValues(u"#,##0.00");

	// Записывает файл презентации на диск
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Отображать процент как метки**
Aspose.Slides для C++ позволяет устанавливать процентные метки на отображаемых диаграммах. Этот код на C++ демонстрирует операцию:

```c++
	// Путь к каталогу документов
	const String outPath = u"../out/DisplayPercentageAsLabels_out.pptx";

	// Создает экземпляр класса Presentation
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

	// Сохраняет презентацию с диаграммой
	presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Установить знак процента для метки данных диаграммы**
Этот код на C++ показывает, как установить знак процента для метки данных диаграммы:

```c++
	// Путь к каталогу документов.
	const String outPath = u"../out/DataLabelsPercentageSign_out.pptx";

	// Создает экземпляр класса Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Получает ссылку на слайд по его индексу
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Создает диаграмму PercentsStackedColumn на слайде
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::PercentsStackedColumn, 0, 0, 500, 500);

	// Устанавливает формат числа, связанный с источником, на false
	chart->get_Axes()->get_VerticalAxis()->set_IsNumberFormatLinkedToSource(false);
	chart->get_Axes()->get_VerticalAxis()->set_NumberFormat(u"0.00%");


	// Устанавливает индекс листа данных диаграммы
	int defaultWorksheetIndex = 0;

	// Получает рабочий лист данных диаграммы
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// Удаляет сгенерированные по умолчанию серии 
	chart->get_ChartData()->get_Series()->Clear();
	

	// Добавляет новую серию
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Series 2")), chart->get_Type());


	// Берет первую серию диаграммы
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Красный")), chart->get_Type());
	// Заполняет данные серии
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(0.80)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 1, ObjectExt::Box<double>(0.65)));

	// Устанавливает цвет заливки для серии
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

	// Устанавливает свойства LabelFormat
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource(false);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat(u"0.0%");
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight(10);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// Берет вторую серию диаграммы
	SharedPtr<IChartSeries> series2 = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Синие")), chart->get_Type());
	// Заполняет данные серии
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(0.70)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(0.50)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(0.20)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 2, ObjectExt::Box<double>(0.35)));

	// Устанавливает цвет заливки для серии
	series2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

	// Устанавливает свойства LabelFormat
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource(false);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat(u"0.0%");
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight(10);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// Записывает файл презентации на диск
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Установить расстояние метки от оси**
Этот код на C++ показывает, как установить расстояние метки от оси категорий, когда вы имеете дело с диаграммой, построенной по осям:

```c++
	// Путь к каталогу документов
	const String outPath = u"../out/CategoryAxisLabelDistance_out.pptx";

	// Создает экземпляр класса Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Получает ссылку на слайд
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Создает диаграмму на слайде
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);


	// Получает коллекцию серий диаграммы
	SharedPtr<IChartSeriesCollection> seriesCollection = chart->get_ChartData()->get_Series();

	// Устанавливает расстояние метки от оси
	chart->get_Axes()->get_HorizontalAxis()->set_LabelOffset(500);

	// Записывает файл презентации на диск
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Регулировка местоположения метки**

Когда вы создаете диаграмму, которая не зависит от каких-либо осей, например, круговую диаграмму, метки данных диаграммы могут оказаться слишком близко к ее краю. В таком случае вы должны отрегулировать местоположение метки данных так, чтобы линии указателей отображались четко.

Этот код на C++ показывает, как отрегулировать местоположение метки на круговой диаграмме:

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

![пирог-диаграмма-отрегулированная-метка](pie-chart-adjusted-label.png)