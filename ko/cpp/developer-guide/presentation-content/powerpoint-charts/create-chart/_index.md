---
title: C++에서 PowerPoint 프레젠테이션 차트 만들기 및 업데이트
linktitle: 차트 만들기 및 업데이트
type: docs
weight: 10
url: /ko/cpp/create-chart/
keywords:
- 차트 추가
- 차트 만들기
- 차트 편집
- 차트 변경
- 차트 업데이트
- 산점도 차트
- 원형 차트
- 꺾은선 차트
- 트리맵 차트
- 주식 차트
- 박스·수염 차트
- 펀넬 차트
- 선버스트 차트
- 히스토그램 차트
- 레이더 차트
- 다중 카테고리 차트
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 프레젠테이션의 차트를 만들고 사용자 지정합니다. 실용적인 C++ 코드 예제로 차트를 추가, 서식 지정 및 편집합니다."
---
## **개요**

이 문서는 Aspose.Slides를 사용하여 차트를 만들고 사용자 지정하는 방법에 대한 포괄적인 가이드를 제공합니다. 슬라이드에 차트를 프로그래밍 방식으로 추가하고, 데이터를 채우며, 특정 디자인 요구 사항에 맞게 다양한 서식 옵션을 적용하는 방법을 배웁니다. 문서 전체에 걸쳐 상세한 코드 예제가 초기 프레젠테이션 및 차트 객체 생성부터 시리즈, 축, 범례 구성까지 각 단계를 설명합니다. 이 가이드를 따라 하면 동적 차트 생성을 애플리케이션에 통합하는 방법을 확실히 이해하게 되어 데이터 기반 프레젠테이션을 손쉽게 만들 수 있습니다.

## **차트 만들기**

차트는 데이터를 빠르게 시각화하고 표나 스프레드시트에서는 즉시 파악하기 어려운 인사이트를 제공하는 데 도움이 됩니다.

**왜 차트를 만들어야 할까요?**

차트를 사용하면

* 대량의 데이터를 하나의 슬라이드에 집계, 압축, 요약할 수 있습니다
* 데이터의 패턴과 추세를 드러낼 수 있습니다
* 시간 경과에 따른 데이터의 방향과 모멘텀을 특정 측정 단위와 관계져 파악할 수 있습니다
* 이상치, 편차, 오류, 비논리적인 데이터를 식별할 수 있습니다
* 복잡한 데이터를 전달하거나 프레젠테이션할 수 있습니다

PowerPoint에서는 삽입 기능을 통해 다양한 차트 템플릿을 사용해 차트를 만들 수 있습니다. Aspose.Slides를 사용하면 일반 차트(대중적인 차트 유형 기반)와 사용자 정의 차트를 모두 만들 수 있습니다.

{{% alert color="primary" %}} 

차트 작성을 지원하기 위해 Aspose.Slides는 [Aspose::Slides::Charts](https://reference.aspose.com/slides/ko/cpp/namespace/aspose.slides.charts/) 네임스페이스 아래에 있는 [ChartType](https://reference.aspose.com/slides/ko/cpp/namespace/aspose.slides.charts#a23ba9ea390f5be4c8f5ab18baf4f8c05) 열거형 클래스를 제공합니다. 이 열거형에 정의된 값들은 서로 다른 차트 유형에 해당합니다. 

{{% /alert %}} 

### **일반 차트 만들기**
1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스를 인스턴스화합니다.  
1. 인덱스를 통해 슬라이드 참조를 가져옵니다.  
1. 데이터를 포함한 차트를 추가하고 원하는 차트 유형을 지정합니다.  
1. 차트에 제목을 추가합니다.  
1. 차트 데이터 워크시트에 접근합니다.  
1. 기본 시리즈와 카테고리를 모두 삭제합니다.  
1. 새 시리즈와 카테고리를 추가합니다.  
1. 차트 시리즈에 새로운 데이터 포인트를 추가합니다.  
1. 차트 시리즈에 채우기 색을 지정합니다.  
1. 차트 시리즈에 레이블을 추가합니다.  
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.  

다음 C++ 코드는 일반 차트를 만드는 방법을 보여줍니다:

```c++
// 문서 디렉터리 경로.
	const String outPath = u"../out/NormalCharts_out.pptx";

	//PPTX 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	//첫 번째 슬라이드에 접근합니다
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 기본 데이터로 차트를 추가합니다
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);


	// 차트 데이터 시트의 인덱스를 설정합니다
	int defaultWorksheetIndex = 0;

	// 차트 데이터 워크시트을 가져옵니다
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

	// 차트 제목을 설정합니다
	chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sample Title");
	chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText ( NullableBool::True);
	chart->get_ChartTitle()->set_Height(20);
	chart->set_HasTitle( true);

	// 기본 생성된 시리즈와 카테고리를 삭제합니다
	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();
	int s = chart->get_ChartData()->get_Series()->get_Count();
	s = chart->get_ChartData()->get_Categories()->get_Count();


	// 새 시리즈를 추가합니다
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Series 2")), chart->get_Type());

	// 카테고리를 추가합니다
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 1, 0, ObjectExt::Box<System::String>(u"Caetegoty 1")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 2, 0, ObjectExt::Box<System::String>(u"Caetegoty 2")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 3, 0, ObjectExt::Box<System::String>(u"Caetegoty 3")));

	
	// 첫 번째 차트 시리즈를 가져옵니다
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

	// 시리즈 데이터를 채웁니다
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(20)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(30)));

	// 시리즈의 채우기 색을 설정합니다
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());


	// 두 번째 차트 시리즈를 가져옵니다
	 series = chart->get_ChartData()->get_Series()->idx_get(1);

	// 시리즈 데이터를 채웁니다
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(30)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(10)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(60)));

	// 시리즈의 채우기 색을 설정합니다
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Green());


	// 첫 번째 레이블은 카테고리 이름을 표시하도록 설정됩니다
	SharedPtr<IDataLabel> lbl = series->get_DataPoints()->idx_get(0)->get_Label();
	lbl->get_DataLabelFormat()->set_ShowCategoryName(true);

	lbl = series->get_DataPoints()->idx_get(1)->get_Label();
	lbl->get_DataLabelFormat()->set_ShowSeriesName (true);

	// 세 번째 레이블에 값을 표시합니다
	lbl = series->get_DataPoints()->idx_get(2)->get_Label();
	lbl->get_DataLabelFormat()->set_ShowValue (true);
	lbl->get_DataLabelFormat()->set_ShowSeriesName(true);
	lbl->get_DataLabelFormat()->set_Separator (u"/");

	// 프레젠테이션을 저장합니다
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **산점도 차트 만들기**
산점도 차트(또는 X‑Y 그래프)는 두 변수 간의 패턴을 확인하거나 상관 관계를 입증할 때 자주 사용됩니다.

다음 상황에서 산점도 차트를 사용할 수 있습니다

* 쌍을 이루는 수치 데이터가 있을 때
* 두 변수가 서로 잘 맞을 때
* 두 변수가 관련이 있는지 판단하고 싶을 때
* 종속 변수에 대해 여러 값을 갖는 독립 변수가 있을 때

다음 C++ 코드는 서로 다른 마커 시리즈를 사용한 산점도 차트를 만드는 방법을 보여줍니다:

```c++
// 문서 디렉터리 경로.
	const String outPath = u"../out/ScatteredChart_out.pptx";

	//PPTX 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	//첫 번째 슬라이드에 접근합니다
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 기본 데이터로 차트를 추가합니다
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ScatterWithSmoothLines, 0, 0, 500, 500);

	// 차트 제목을 설정합니다
	chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sample Title");
	chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText(NullableBool::True);
	chart->get_ChartTitle()->set_Height(20);
	chart->set_HasTitle(true);

	// 기본 생성된 시리즈를 삭제합니다
	chart->get_ChartData()->get_Series()->Clear();
	
	// 차트 데이터 시트의 인덱스를 설정합니다
	int defaultWorksheetIndex = 0;

	// 차트 데이터 워크시트를 가져옵니다
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// 새 시리즈를 추가합니다
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 3, ObjectExt::Box<System::String>(u"Series 2")), chart->get_Type());

	// 첫 번째 차트 시리즈를 가져옵니다
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

	// 새 포인트 (1:3)를 추가합니다
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(1)), fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(3)));

	// 새 포인트 (2:10)를 추가합니다
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(2)), fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(10)));

	// 시리즈 유형을 편집합니다
	series->set_Type (ChartType::ScatterWithStraightLinesAndMarkers);

	// 차트 시리즈 마커를 변경합니다
	series->get_Marker()->set_Size  (10);
	series->get_Marker()->set_Symbol(MarkerStyleType::Star);



	// 두 번째 차트 시리즈를 가져옵니다
	series  = chart->get_ChartData()->get_Series()->idx_get(1);

	// 새 포인트 (5:2)를 추가합니다
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 2, 3, ObjectExt::Box<double>(5)), fact->GetCell(defaultWorksheetIndex, 2, 4, ObjectExt::Box<double>(2)));

	// 새 포인트 (3:1)를 추가합니다
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 3, 3, ObjectExt::Box<double>(3)), fact->GetCell(defaultWorksheetIndex, 3, 4, ObjectExt::Box<double>(1)));

	// 새 포인트 (2:2)를 추가합니다
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 4, 3, ObjectExt::Box<double>(2)), fact->GetCell(defaultWorksheetIndex, 4, 4, ObjectExt::Box<double>(2)));

	// 새 포인트 (5:1)를 추가합니다
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 5, 3, ObjectExt::Box<double>(5)), fact->GetCell(defaultWorksheetIndex, 5, 4, ObjectExt::Box<double>(1)));

	// 차트 시리즈 마커를 변경합니다
	series->get_Marker()->set_Size ( 10);
	series->get_Marker()->set_Symbol(MarkerStyleType::Circle);



	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_IsColorVaried(true);

	SharedPtr<IChartDataPoint> point = series->get_DataPoints()->idx_get(0);
	point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Cyan());
	// 섹터 테두리를 설정합니다
	point->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Gray());
	point->get_Format()->get_Line()->set_Width ( 3.0);
	point->get_Format()->get_Line()->set_Style(LineStyle::ThinThick);
	point->get_Format()->get_Line()->set_DashStyle(LineDashStyle::DashDot);

	SharedPtr<IChartDataPoint> point1 = series->get_DataPoints()->idx_get(1);
	point1->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Brown());

	// 섹터 테두리를 설정합니다
	point1->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());
	point1->get_Format()->get_Line()->set_Width (3.0);
	point1->get_Format()->get_Line()->set_Style(LineStyle::Single);
	point1->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDot);


	SharedPtr<IChartDataPoint> point2 = series->get_DataPoints()->idx_get(2);
	point2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Coral());

	// 섹터 테두리를 설정합니다
	point2->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
	point2->get_Format()->get_Line()->set_Width ( 2.0);
	point2->get_Format()->get_Line()->set_Style(LineStyle::ThickThin);
	point2->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDotDot);


	// 새 시리즈의 각 카테고리에 대한 사용자 지정 레이블을 생성합니다
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

	// 차트에 대한 리더 라인을 표시합니다
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLeaderLines(true);

	// 파이 차트 섹터의 회전 각도를 설정합니다
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_FirstSliceAngle(180);


	// 프레젠테이션을 저장합니다
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **원형 차트 만들기**
원형 차트는 특히 카테고리 레이블에 숫자 값이 포함된 경우, 전체 대비 부분 관계를 나타내기에 적합합니다. 그러나 레이블이 많거나 파트가 많은 경우에는 막대 차트를 고려하는 것이 좋습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스를 인스턴스화합니다.  
1. 인덱스를 통해 슬라이드 참조를 가져옵니다.  
1. 기본 데이터를 사용하고 원하는 유형(`ChartType.Pie`)을 지정하여 차트를 추가합니다.  
1. 차트 데이터 `IChartDataWorkbook`에 접근합니다.  
1. 기본 시리즈와 카테고리를 삭제합니다.  
1. 새 시리즈와 카테고리를 추가합니다.  
1. 차트 시리즈에 새로운 데이터 포인트를 추가합니다.  
1. 파이 차트 섹터에 사용자 정의 색을 추가합니다.  
1. 시리즈에 레이블을 설정합니다.  
1. 시리즈 레이블에 리더 라인을 설정합니다.  
1. 파이 차트 슬라이드의 회전 각도를 지정합니다.  
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.  

다음 C++ 코드는 원형 차트를 만드는 방법을 보여줍니다:

```c++
	// 문서 디렉터리 경로.
	const String outPath = u"../out/PieChart_out.pptx";

	// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 첫 번째 슬라이드에 접근합니다
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 기본 데이터로 차트를 추가합니다
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Pie, 0, 0, 500, 500);

	// 차트 제목을 설정합니다
	chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sample Title");
	chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText(NullableBool::True);
	chart->get_ChartTitle()->set_Height(20);
	chart->set_HasTitle(true);

	// 기본 생성된 시리즈와 카테고리를 삭제합니다
	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();

	// 차트 데이터 시트의 인덱스를 설정합니다
	int defaultWorksheetIndex = 0;

	// 차트 데이터 워크시트를 가져옵니다
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

	// 카테고리를 추가합니다
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 1, 0, ObjectExt::Box<System::String>(u"First Qtr")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 2, 0, ObjectExt::Box<System::String>(u"2nd Qtr")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 3, 0, ObjectExt::Box<System::String>(u"3ed Qtr")));

	// 새 시리즈를 추가합니다
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());
	
	// 첫 번째 차트 시리즈를 가져옵니다
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

	// 시리즈 데이터를 채웁니다
	series->get_DataPoints()->AddDataPointForPieSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(20)));
	series->get_DataPoints()->AddDataPointForPieSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(50)));
	series->get_DataPoints()->AddDataPointForPieSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(30)));

	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_IsColorVaried(true);

	SharedPtr<IChartDataPoint> point = series->get_DataPoints()->idx_get(0);
	point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Cyan());
	// 섹터 테두리를 설정합니다
	point->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Gray());
	point->get_Format()->get_Line()->set_Width ( 3.0);
	point->get_Format()->get_Line()->set_Style( LineStyle::ThinThick);
	point->get_Format()->get_Line()->set_DashStyle ( LineDashStyle::DashDot);

	SharedPtr<IChartDataPoint> point1 = series->get_DataPoints()->idx_get(1);
	point1->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Brown());

	// 섹터 테두리를 설정합니다
	point1->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());
	point1->get_Format()->get_Line()->set_Width (3.0);
	point1->get_Format()->get_Line()->set_Style(LineStyle::Single);
	point1->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDot);


	SharedPtr<IChartDataPoint> point2 = series->get_DataPoints()->idx_get(2);
	point2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Coral());

	// 섹터 테두리를 설정합니다
	point2->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
	point2->get_Format()->get_Line()->set_Width (2.0);
	point2->get_Format()->get_Line()->set_Style(LineStyle::ThickThin);
	point2->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDotDot);


	// 새 시리즈의 각 카테고리에 대한 사용자 지정 레이블을 생성합니다
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

	// 차트에 대한 리더 라인을 표시하도록 시리즈를 설정합니다
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLeaderLines ( true);

	// 파이 차트 섹터의 회전 각도를 설정합니다
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_FirstSliceAngle ( 180);


	// 프레젠테이션을 저장합니다
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **꺾은선 차트 만들기**

꺾은선 차트(라인 그래프)는 시간에 따른 값 변화를 보여줄 때 가장 적합합니다. 꺾은선 차트를 사용하면 다량의 데이터를 한 번에 비교하고, 시간 흐름에 따른 변동과 추세를 추적하며, 데이터 시리즈의 이상값을 강조하는 등 다양한 작업을 수행할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스를 인스턴스화합니다.  
1. 인덱스를 통해 슬라이드 참조를 가져옵니다.  
1. 기본 데이터를 사용하고 원하는 유형(`ChartType::Line`)을 지정하여 차트를 추가합니다.  
1. 차트 데이터 `IChartDataWorkbook`에 접근합니다.  
1. 기본 시리즈와 카테고리를 삭제합니다.  
1. 새 시리즈와 카테고리를 추가합니다.  
1. 차트 시리즈에 새로운 데이터 포인트를 추가합니다.  
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.  

다음 C++ 코드는 꺾은선 차트를 만드는 방법을 보여줍니다:

```c++
auto pres = System::MakeObject<Presentation>();

System::SharedPtr<IChart> lineChart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Line, 10.0f, 50.0f, 600.0f, 350.0f);
pres->Save(u"lineChart.pptx", SaveFormat::Pptx);
```

기본적으로 꺾은선 차트의 포인트는 직선으로 연결됩니다. 점을 대시 형태로 연결하려면 다음과 같이 원하는 대시 유형을 지정하면 됩니다:

```c++
System::SharedPtr<IChart> lineChart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Line, 10.0f, 50.0f, 600.0f, 350.0f);
for (auto&& series : lineChart->get_ChartData()->get_Series())
{
    series->get_Format()->get_Line()->set_DashStyle(LineDashStyle::Dash);
}
```

### **트리맵 차트 만들기**

트리맵 차트는 판매 데이터 등에서 데이터 카테고리별 상대 크기를 보여주고, 동시에 각 카테고리 내 큰 기여 항목을 빠르게 강조하고 싶을 때 유용합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스를 인스턴스화합니다.  
1. 인덱스를 통해 슬라이드 참조를 가져옵니다.  
1. 기본 데이터를 사용하고 원하는 유형(`ChartType.TreeMap`)을 지정하여 차트를 추가합니다.  
1. 차트 데이터 `IChartDataWorkbook`에 접근합니다.  
1. 기본 시리즈와 카테고리를 삭제합니다.  
1. 새 시리즈와 카테고리를 추가합니다.  
1. 차트 시리즈에 새로운 데이터 포인트를 추가합니다.  
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.  

다음 C++ 코드는 트리맵 차트를 만드는 방법을 보여줍니다:

```c++
// 문서 디렉터리 경로.
	const String outPath = u"../out/TreemapChart_out.pptx";

	//PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 첫 번째 슬라이드에 접근합니다
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Treemap, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	// 브랜치 1
	System::SharedPtr<IChartCategory> leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C1", System::ObjectExt::Box<System::String>(u"Leaf1")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem1"));
	leaf->get_GroupingLevels()->SetGroupingItem(2, System::ObjectExt::Box<System::String>(u"Branch1"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C2", System::ObjectExt::Box<System::String>(u"Leaf2")));

	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C3", System::ObjectExt::Box<System::String>(u"Leaf3")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem2"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C4", System::ObjectExt::Box<System::String>(u"Leaf4")));


	// 브랜치 2
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

	// 프레젠테이션을 저장합니다
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **주식 차트 만들기**
1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스를 인스턴스화합니다.  
1. 인덱스를 통해 슬라이드 참조를 가져옵니다.  
1. 기본 데이터를 사용하고 원하는 유형(`ChartType.OpenHighLowClose`)을 지정하여 차트를 추가합니다.  
1. 차트 데이터 `IChartDataWorkbook`에 접근합니다.  
1. 기본 시리즈와 카테고리를 삭제합니다.  
1. 새 시리즈와 카테고리를 추가합니다.  
1. 차트 시리즈에 새로운 데이터 포인트를 추가합니다.  
1. HiLowLines 형식을 지정합니다.  
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.  

주식 차트를 만드는 샘플 C++ 코드:

```c++
	// 문서 디렉터리 경로.
	const String outPath = u"../out/AddStockChart_out.pptx";

	// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 첫 번째 슬라이드에 접근합니다
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 기본 데이터로 차트를 추가합니다
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::OpenHighLowClose, 0, 0, 500, 500);


	// 차트 데이터 시트의 인덱스를 설정합니다
	int defaultWorksheetIndex = 0;

	// 차트 데이터 워크시트를 가져옵니다
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// 기본 생성된 시리즈와 카테고리를 삭제합니다
	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();

	// 카테고리를 추가합니다
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 1, 0, ObjectExt::Box<System::String>(u"A")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 2, 0, ObjectExt::Box<System::String>(u"B")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 3, 0, ObjectExt::Box<System::String>(u"C")));

	// 새 시리즈를 추가합니다
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Open")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"High")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 3, ObjectExt::Box<System::String>(u"Low")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 4, ObjectExt::Box<System::String>(u"Close")), chart->get_Type());


	// 첫 번째 차트 시리즈를 가져옵니다
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);
	// 첫 번째 시리즈 데이터를 채웁니다
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(72)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(25)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(38)));


	series = chart->get_ChartData()->get_Series()->idx_get(1);
	// 두 번째 시리즈 데이터를 채웁니다
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(172)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(57)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(57)));

	series = chart->get_ChartData()->get_Series()->idx_get(2);
	// 두 번째 시리즈 데이터를 채웁니다
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 3, ObjectExt::Box<double>(12)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 3, ObjectExt::Box<double>(12)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 3, ObjectExt::Box<double>(13)));


	series = chart->get_ChartData()->get_Series()->idx_get(3);
	// 두 번째 시리즈 데이터를 채웁니다
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 4, ObjectExt::Box<double>(25)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 4, ObjectExt::Box<double>(38)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 4, ObjectExt::Box<double>(50)));

	// 시리즈 그룹을 설정합니다
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->get_UpDownBars()->set_HasUpDownBars (true);
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->get_HiLowLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);


	for(int i=0;i<chart->get_ChartData()->get_Series()->get_Count();i++)
	{
		series = chart->get_ChartData()->get_Series()->idx_get(i);
		series->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);
	}

	// 프레젠테이션을 저장합니다
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **박스·수염 차트 만들기**
1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스를 인스턴스화합니다.  
1. 인덱스를 통해 슬라이드 참조를 가져옵니다.  
1. 기본 데이터를 사용하고 원하는 유형(`ChartType.BoxAndWhisker`)을 지정하여 차트를 추가합니다.  
1. 차트 데이터 `IChartDataWorkbook`에 접근합니다.  
1. 기본 시리즈와 카테고리를 삭제합니다.  
1. 새 시리즈와 카테고리를 추가합니다.  
1. 차트 시리즈에 새로운 데이터 포인트를 추가합니다.  
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.  

다음 C++ 코드는 박스·수염 차트를 만드는 방법을 보여줍니다:

```c++
	// 문서 디렉터리 경로.
	const String outPath = u"../out/BoxAndWhisker_out.pptx";

	// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 첫 번째 슬라이드에 접근합니다
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


	// 프레젠테이션을 저장합니다
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **펀넬 차트 만들기**
1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스를 인스턴스화합니다.  
1. 인덱스를 통해 슬라이드 참조를 가져옵니다.  
1. 기본 데이터를 사용하고 원하는 유형(`ChartType.Funnel`)을 지정하여 차트를 추가합니다.  
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.  

다음 C++ 코드는 펀넬 차트를 만드는 방법을 보여줍니다:

```c++
	// 문서 디렉터리 경로.
	const String outPath = u"../out/FunnelChart_out.pptx";

	// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 첫 번째 슬라이드에 접근합니다
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


	// 프레젠테이션을 저장합니다
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **선버스트 차트 만들기**
1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스를 인스턴스화합니다.  
1. 인덱스를 통해 슬라이드 참조를 가져옵니다.  
1. 기본 데이터를 사용하고 원하는 유형(`ChartType.sunburst`)을 지정하여 차트를 추가합니다.  
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.  

다음 C++ 코드는 선버스트 차트를 만드는 방법을 보여줍니다:

```c++
	// 문서 디렉터리 경로.
	const String outPath = u"../out/SunburstChart_out.pptx";

	// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 첫 번째 슬라이드에 접근합니다
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart=slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Sunburst, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	// 브랜치 1
	System::SharedPtr<IChartCategory> leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C1", System::ObjectExt::Box<System::String>(u"Leaf1")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem1"));
	leaf->get_GroupingLevels()->SetGroupingItem(2, System::ObjectExt::Box<System::String>(u"Branch1"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C2", System::ObjectExt::Box<System::String>(u"Leaf2")));

	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C3", System::ObjectExt::Box<System::String>(u"Leaf3")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem2"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C4", System::ObjectExt::Box<System::String>(u"Leaf4")));

	// 브랜치 2
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

	// 프레젠테이션 파일을 디스크에 저장합니다
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **히스토그램 차트 만들기**
1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스를 인스턴스화합니다.  
1. 인덱스를 통해 슬라이드 참조를 가져옵니다.  
1. 데이터를 포함하고 차트 유형(`ChartType.Histogram`)을 지정하여 차트를 추가합니다.  
1. 차트 데이터 `IChartDataWorkbook`에 접근합니다.  
1. 기본 시리즈와 카테고리를 삭제합니다.  
1. 새 시리즈와 카테고리를 추가합니다.  
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.  

다음 C++ 코드는 히스토그램 차트를 만드는 방법을 보여줍니다:

```c++
	// 문서 디렉터리 경로.
	const String outPath = u"../out/HistogramChart_out.pptx";

	// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// 첫 번째 슬라이드에 접근합니다
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

	// 프레젠테이션을 저장합니다
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **레이더 차트 만들기**

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스를 인스턴스화합니다.  
1. 인덱스를 통해 슬라이드 참조를 가져옵니다.  
1. 데이터를 포함하고 차트 유형(`ChartType.Radar`)을 지정하여 차트를 추가합니다.  
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.  

다음 C++ 코드는 레이더 차트를 만드는 방법을 보여줍니다:

```c++
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Radar, 20.0f, 20.0f, 400.0f, 300.0f);
presentation->Save(u"Radar-chart.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

### **다중 카테고리 차트 만들기**

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스를 인스턴스화합니다.  
1. 인덱스를 통해 슬라이드 참조를 가져옵니다.  
1. 기본 데이터를 사용하고 원하는 유형(`ChartType.ClusteredColumn`)을 지정하여 차트를 추가합니다.  
1. 차트 데이터 `IChartDataWorkbook`에 접근합니다.  
1. 기본 시리즈와 카테고리를 삭제합니다.  
1. 새 시리즈와 카테고리를 추가합니다.  
1. 차트 시리즈에 새로운 데이터 포인트를 추가합니다.  
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.  

다음 C++ 코드는 다중 카테고리 차트를 만드는 방법을 보여줍니다:

```c++
	// 문서 디렉터리 경로.
	const String outPath = u"../out/MultiCategoryChart_out.pptx";

	//PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	//첫 번째 슬라이드에 접근합니다
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 기본 데이터로 차트를 추가합니다
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);

	// 차트 데이터 시트의 인덱스를 설정합니다
	int defaultWorksheetIndex = 0;

	// 차트 데이터 워크시트를 가져옵니다
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

	// 워크북을 초기화합니다
	fact->Clear(defaultWorksheetIndex);

	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();


	// 카테고리를 추가합니다
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

	// 새 시리즈를 추가합니다
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

	// 프레젠테이션을 저장합니다
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **맵 차트 만들기**

맵 차트는 데이터가 포함된 영역을 시각화하는 도구이며, 지리적 구역별 데이터나 값을 비교할 때 가장 효과적입니다.

다음 C++ 코드는 맵 차트를 만드는 방법을 보여줍니다:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Map, 50.0f, 50.0f, 500.0f, 400.0f);
pres->Save(u"mapChart.pptx", SaveFormat::Pptx);
```

### **조합 차트 만들기**

조합 차트(또는 콤보 차트)는 하나의 그래프에 두 개 이상의 차트 유형을 결합합니다. 이 차트를 사용하면 여러 데이터 세트 간의 차이를 강조·비교·분석하여 관계를 파악할 수 있습니다.

![조합 차트](combination_chart.png)

다음 C++ 코드는 위에 표시된 조합 차트를 PowerPoint 프레젠테이션에 만드는 방법을 보여줍니다:

```cpp
static SharedPtr<IChart> CreateChartWithFirstSeries(SharedPtr<ISlide> slide)
{
    auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    // 차트 제목을 설정합니다.
    chart->set_HasTitle(true);
    chart->get_ChartTitle()->AddTextFrameForOverriding(u"Chart Title");
    chart->get_ChartTitle()->set_Overlay(false);
    auto titleParagraph = chart->get_ChartTitle()->get_TextFrameForOverriding()->get_Paragraph(0);
    auto titleFormat = titleParagraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    titleFormat->set_FontBold(NullableBool::False);
    titleFormat->set_FontHeight(18.0);

    // 차트 범례를 설정합니다.
    chart->get_Legend()->set_Position(LegendPositionType::Bottom);
    chart->get_Legend()->get_TextFormat()->get_PortionFormat()->set_FontHeight(12.0);

    // 기본 생성된 시리즈와 카테고리를 삭제합니다.
    chart->get_ChartData()->get_Series()->Clear();
    chart->get_ChartData()->get_Categories()->Clear();

    const int worksheetIndex = 0;
    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

    // 새 카테고리를 추가합니다.
    chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"Category 1")));
    chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Category 2")));
    chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Category 3")));
    chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 4, 0, ObjectExt::Box<String>(u"Category 4")));

    // 첫 번째 시리즈를 추가합니다.
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
    // 가로 축을 설정합니다.
    auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();
    horizontalAxis->get_TextFormat()->get_PortionFormat()->set_FontHeight(12.0);
    horizontalAxis->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);

    SetAxisTitle(horizontalAxis, u"X Axis");

    // 세로 축을 설정합니다.
    auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
    verticalAxis->get_TextFormat()->get_PortionFormat()->set_FontHeight(12.0);
    verticalAxis->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);

    SetAxisTitle(verticalAxis, u"Y Axis 1");

    // 세로 주요 격자선 색상을 설정합니다.
    auto majorGridLinesFormat = verticalAxis->get_MajorGridLinesFormat()->get_Line()->get_FillFormat();
    majorGridLinesFormat->set_FillType(FillType::Solid);
    majorGridLinesFormat->get_SolidFillColor()->set_Color(Color::FromArgb(217, 217, 217));
}

static void SetSecondaryAxesFormat(SharedPtr<IChart> chart)
{
    // 보조 가로 축을 설정합니다.
    auto secondaryHorizontalAxis = chart->get_Axes()->get_SecondaryHorizontalAxis();
    secondaryHorizontalAxis->set_Position(AxisPositionType::Bottom);
    secondaryHorizontalAxis->set_CrossType(CrossesType::Maximum);
    secondaryHorizontalAxis->set_IsVisible(false);
    secondaryHorizontalAxis->get_MajorGridLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);
    secondaryHorizontalAxis->get_MinorGridLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);

    // 보조 세로 축을 설정합니다.
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

## **차트 업데이트**

1. 차트가 포함된 프레젠테이션을 나타내는 [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 객체를 인스턴스화합니다.  
2. 인덱스를 통해 슬라이드 참조를 가져옵니다.  
3. 모든 도형을 순회하여 원하는 차트를 찾습니다.  
4. 차트 데이터 워크시트에 접근합니다.  
5. 시리즈 값을 변경하여 차트 데이터 시리즈를 수정합니다.  
6. 새 시리즈를 추가하고 데이터를 채웁니다.  
7. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.  

다음 C++ 코드는 차트를 업데이트하는 방법을 보여줍니다:

```c++
// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"ExistingChart.pptx");

// 첫 번째 슬라이드 마커에 접근합니다
System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// 기본 데이터로 차트를 추가합니다
System::SharedPtr<IChart> chart = System::ExplicitCast<Aspose::Slides::Charts::IChart>(sld->get_Shapes()->idx_get(0));

// 차트 데이터 시트의 인덱스를 설정합니다
int32_t defaultWorksheetIndex = 0;

// 차트 데이터 워크시트를 가져옵니다
System::SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


// 차트 카테고리 이름을 변경합니다
fact->GetCell(defaultWorksheetIndex, 1, 0, System::ObjectExt::Box<System::String>(u"Modified Category 1"));
fact->GetCell(defaultWorksheetIndex, 2, 0, System::ObjectExt::Box<System::String>(u"Modified Category 2"));

// 첫 번째 차트 시리즈를 가져옵니다
System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

// 시리즈 데이터를 업데이트합니다
fact->GetCell(defaultWorksheetIndex, 0, 1, System::ObjectExt::Box<System::String>(u"New_Series1"));
// 시리즈 이름을 수정합니다
series->get_DataPoints()->idx_get(0)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(90));
series->get_DataPoints()->idx_get(1)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(123));
series->get_DataPoints()->idx_get(2)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(44));

// 두 번째 차트 시리즈를 가져옵니다
series = chart->get_ChartData()->get_Series()->idx_get(1);

// 이제 시리즈 데이터를 업데이트합니다
fact->GetCell(defaultWorksheetIndex, 0, 2, System::ObjectExt::Box<System::String>(u"New_Series2"));
// 시리즈 이름을 수정합니다
series->get_DataPoints()->idx_get(0)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(23));
series->get_DataPoints()->idx_get(1)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(67));
series->get_DataPoints()->idx_get(2)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(99));


// 이제 새 시리즈를 추가합니다
chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 3, System::ObjectExt::Box<System::String>(u"Series 3")), chart->get_Type());

// 세 번째 차트 시리즈를 가져옵니다
series = chart->get_ChartData()->get_Series()->idx_get(2);

// 이제 시리즈 데이터를 채웁니다
series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 3, System::ObjectExt::Box<int32_t>(20)));
series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 3, System::ObjectExt::Box<int32_t>(50)));
series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 3, System::ObjectExt::Box<int32_t>(30)));

chart->set_Type(Aspose::Slides::Charts::ChartType::ClusteredCylinder);

// 차트를 포함한 프레젠테이션을 저장합니다
pres->Save(u"AsposeChartModified_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **차트 데이터 범위 설정**

1. 차트가 포함된 [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 인스턴스를 엽니다.  
2. 인덱스를 통해 슬라이드 참조를 가져옵니다.  
3. 모든 도형을 순회하여 원하는 차트를 찾습니다.  
4. 차트 데이터를 접근하고 범위를 설정합니다.  
5. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.  

다음 C++ 코드는 차트의 데이터 범위를 설정하는 방법을 보여줍니다:

```cpp
// 문서 디렉터리 경로.
String dataDir = GetDataPath();

// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
auto presentation = System::MakeObject<Presentation>(dataDir + u"ExistingChart.pptx");

// 첫 번째 슬라이드 마커에 접근하고 기본 데이터로 차트를 추가합니다
auto slide = presentation->get_Slides()->idx_get(0);
auto chart = System::ExplicitCast<IChart>(slide->get_Shapes()->idx_get(0));
chart->get_ChartData()->SetRange(u"Sheet1!A1:B4");
presentation->Save(dataDir + u"SetDataRange_out.pptx", SaveFormat::Pptx);
```

## **차트에 기본 마커 사용하기**
차트에 기본 마커를 사용하면 각 차트 시리즈에 자동으로 서로 다른 기본 마커 기호가 적용됩니다.

다음 C++ 코드는 차트 시리즈 마커를 자동으로 설정하는 방법을 보여줍니다:

```cpp
	// 문서 디렉터리 경로.
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

	// 두 번째 차트 시리즈를 가져옵니다
	auto series2 = chart->get_ChartData()->get_Series()->idx_get(1);

	// 시리즈 데이터를 채웁니다
	series2->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 1, 2, ObjectExt::Box<int32_t>(30)));
	series2->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 2, 2, ObjectExt::Box<int32_t>(10)));
	series2->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 3, 2, ObjectExt::Box<int32_t>(60)));
	series2->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 4, 2, ObjectExt::Box<int32_t>(40)));

	chart->set_HasLegend(true);
	chart->get_Legend()->set_Overlay(false);

	pres->Save(dataDir + u"DefaultMarkersInChart.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Aspose.Slides가 지원하는 차트 유형은 무엇인가요?**

Aspose.Slides는 막대, 꺾은선, 원형, 영역, 산점도, 히스토그램, 레이더 등 다양한 차트 유형을 지원합니다. 이를 통해 데이터 시각화 요구에 맞는 가장 적합한 차트 유형을 선택할 수 있습니다.

**슬라이드에 새 차트를 추가하려면 어떻게 해야 하나요?**

새 차트를 추가하려면 먼저 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스를 인스턴스화하고, 인덱스로 원하는 슬라이드를 가져온 다음, 차트 유형과 초기 데이터를 지정하여 차트를 추가하는 메서드를 호출하면 됩니다. 이 과정으로 차트가 프레젠테이션에 직접 삽입됩니다.

**차트에 표시되는 데이터를 어떻게 업데이트하나요?**

차트의 데이터 워크북([IChartDataWorkbook](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdataworkbook/))에 접근해 기본 시리즈와 카테고리를 삭제하고, 사용자 정의 데이터를 추가하면 차트 데이터를 프로그래밍 방식으로 최신 상태로 갱신할 수 있습니다.

**차트 모양을 사용자 지정할 수 있나요?**

예, Aspose.Slides는 풍부한 사용자 지정 옵션을 제공합니다. 색상, 글꼴, 레이블, 범례 및 기타 서식 요소를 수정하여 차트를 원하는 디자인 요구 사항에 맞게 조정할 수 있습니다.