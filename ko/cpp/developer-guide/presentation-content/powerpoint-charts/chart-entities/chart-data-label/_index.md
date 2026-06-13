---
title: 프레젠테이션에서 С++를 사용하여 차트 데이터 레이블 관리
linktitle: 데이터 레이블
type: docs
url: /ko/cpp/chart-data-label/
keywords:
- 차트
- 데이터 레이블
- 데이터 정밀도
- 백분율
- 레이블 거리
- 레이블 위치
- PowerPoint
- 프레젠테이션
- С++
- Aspose.Slides
description: "Aspose.Slides for С++를 사용하여 PowerPoint 프레젠테이션에 차트 데이터 레이블을 추가하고 형식화하는 방법을 배워 더욱 매력적인 슬라이드를 만들 수 있습니다."
---
## **소개**

차트의 데이터 레이블은 차트 데이터 시리즈 또는 개별 데이터 포인트에 대한 자세한 정보를 표시합니다. 이를 통해 독자는 데이터 시리즈를 빠르게 식별할 수 있으며 차트를 보다 쉽게 이해할 수 있습니다.

## **차트 데이터 레이블의 데이터 정밀도 설정**

이 C++ 코드는 차트 데이터 레이블의 데이터 정밀도를 설정하는 방법을 보여줍니다:

```c++
	// 문서 디렉터리 경로
	const String outPath = u"../out/SettingPrecisionOfDataLabel_out.pptx";

	// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 첫 번째 슬라이드를 가져옵니다
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 기본 데이터로 차트를 추가합니다
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Line, 0, 0, 500, 500);

	// 시리즈 번호 형식을 설정합니다
	chart->set_HasDataTable( true);
	chart->get_ChartData()->get_Series()->idx_get(0)->set_NumberFormatOfValues (u"#,##0.00");

	// 프레젠테이션 파일을 디스크에 저장합니다
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **백분율을 레이블로 표시**

Aspose.Slides for C++를 사용하면 표시된 차트에 백분율 레이블을 설정할 수 있습니다. 이 C++ 코드는 해당 작업을 시연합니다:

```c++
	// 문서 디렉터리 경로
	const String outPath = u"../out/DisplayPercentageAsLabels_out.pptx";

	// Presentation 클래스의 인스턴스를 생성합니다
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

	// 차트를 포함하는 프레젠테이션을 저장합니다
	presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **차트 데이터 레이블에 백분율 기호 설정**

이 C++ 코드는 차트 데이터 레이블에 백분율 기호를 설정하는 방법을 보여줍니다:

```c++
	// 문서 디렉터리 경로.
	const String outPath = u"../out/DataLabelsPercentageSign_out.pptx";

	// Presentation 클래스의 인스턴스를 생성합니다
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 인덱스를 통해 슬라이드 참조를 가져옵니다
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 슬라이드에 PercentsStackedColumn 차트를 생성합니다
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::PercentsStackedColumn, 0, 0, 500, 500);

	// NumberFormatLinkedToSource를 false로 설정합니다
	chart->get_Axes()->get_VerticalAxis()->set_IsNumberFormatLinkedToSource ( false);
	chart->get_Axes()->get_VerticalAxis()->set_NumberFormat(u"0.00%");


	// 차트 데이터 시트의 인덱스를 설정합니다
	int defaultWorksheetIndex = 0;

	// 차트 데이터 워크시트를 가져옵니다
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// 기본 생성된 시리즈를 삭제합니다 
	chart->get_ChartData()->get_Series()->Clear();
	

	// 새 시리즈를 추가합니다
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Series 2")), chart->get_Type());


	// 첫 번째 차트 시리즈를 가져옵니다
	SharedPtr<IChartSeries> series=chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Red")), chart->get_Type());
	// 시리즈 데이터를 채웁니다
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(0.80)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 1, ObjectExt::Box<double>(0.65)));

	// 시리즈의 채우기 색상을 설정합니다
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

	// LabelFormat 속성을 설정합니다
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource ( false);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat (u"0.0%");
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight ( 10);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// 두 번째 차트 시리즈를 가져옵니다
	SharedPtr<IChartSeries> series2 = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Blues")), chart->get_Type());
	// 시리즈 데이터를 채웁니다
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(0.70)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(0.50)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(0.20)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 2, ObjectExt::Box<double>(0.35)));

	// 시리즈의 채우기 색상을 설정합니다
	series2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

	// LabelFormat 속성을 설정합니다
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource(false);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat(u"0.0%");
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight(10);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// 프레젠테이션 파일을 디스크에 저장합니다
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **축으로부터 레이블 거리 설정**

이 C++ 코드는 축에서 플롯된 차트를 다룰 때 범주 축으로부터 레이블 거리을 설정하는 방법을 보여줍니다:

```c++
	// 문서 디렉터리 경로
	const String outPath = u"../out/CategoryAxisLabelDistance_out.pptx";

	// Presentation 클래스의 인스턴스를 생성합니다
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 슬라이드 참조를 가져옵니다
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 슬라이드에 차트를 생성합니다
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);


	// 차트 시리즈 컬렉션을 가져옵니다
	SharedPtr<IChartSeriesCollection> seriesCollection = chart->get_ChartData()->get_Series();

	// 축으로부터 레이블 간격을 설정합니다
	chart->get_Axes()->get_HorizontalAxis()->set_LabelOffset ( 500);

	// 프레젠테이션 파일을 디스크에 저장합니다
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **레이블 위치 조정**

파이 차트와 같이 축에 의존하지 않는 차트를 만들 경우, 차트의 데이터 레이블이 가장자리에 너무 가깝게 배치될 수 있습니다. 이 경우, 데이터 레이블의 위치를 조정하여 리더 라인이 명확하게 표시되도록 해야 합니다.

이 C++ 코드는 파이 차트에서 레이블 위치를 조정하는 방법을 보여줍니다:

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

## **FAQ**

**빽빽한 차트에서 데이터 레이블이 겹치는 것을 어떻게 방지할 수 있나요?**

자동 레이블 배치, 리더 라인, 그리고 글꼴 크기 축소를 결합합니다; 필요하다면 일부 필드(예: 범주)를 숨기거나 극단/핵심 포인트에만 레이블을 표시합니다.

**값이 0이거나 음수이거나 비어 있는 경우에만 레이블을 비활성화하려면 어떻게 해야 하나요?**

레이블을 활성화하기 전에 데이터 포인트를 필터링하고, 정의된 규칙에 따라 0값, 음수값 또는 누락된 값에 대한 표시를 끕니다.

**PDF/이미지로 내보낼 때 일관된 레이블 스타일을 보장하려면 어떻게 해야 하나요?**

글꼴(패밀리, 크기)을 명시적으로 설정하고, 렌더링 측에서 해당 글꼴이 사용 가능하도록 확인하여 대체 글꼴이 적용되지 않도록 합니다.