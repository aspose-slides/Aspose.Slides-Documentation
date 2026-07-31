---
title: C++를 사용하여 프레젠테이션에서 차트 데이터 마커 관리
linktitle: 데이터 마커
type: docs
url: /ko/cpp/chart-data-marker/
keywords:
- 차트
- 데이터 포인트
- 마커
- 마커 옵션
- 마커 크기
- 채우기 유형
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++에서 차트 데이터 마커를 맞춤 설정하는 방법을 배우고, 명확한 C++ 코드 예제를 통해 PPT 및 PPTX 형식의 프레젠테이션 효과를 향상시키세요."
---
## **개요**

이 문서에서는 Aspose.Slides에서 차트 데이터 마커를 사용하는 방법을 설명합니다. 차트를 생성하고, 시리즈와 해당 데이터 포인트에 접근하며, 데이터 포인트 수준에서 마커에 사진 채우기를 적용하고, 마커 크기를 조정하고, 업데이트된 프레젠테이션을 저장하는 방법을 보여줍니다. 또한 표준 마커 모양이 `MarkerStyleType` 열거형을 통해 제공되며, 차트를 래스터 형식이나 SVG로 내보낼 때 마커 모양이 유지된다는 점도 언급합니다.

## **차트 마커 설정**
Aspose.Slides for C++는 차트 시리즈 마커를 자동으로 설정하기 위한 간단한 API를 제공합니다. 다음 예제에서는 모든 차트 시리즈가 자동으로 서로 다른 기본 마커 기호를 부여받습니다.

아래 코드 예제는 차트 시리즈 마커를 자동으로 설정하는 방법을 보여줍니다.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-DefaultMarkersInChart-DefaultMarkersInChart.cpp" >}}

## **차트 마커 옵션 설정**
특정 시리즈 내의 차트 데이터 포인트에 마커를 설정할 수 있습니다. 차트 마커 옵션을 설정하려면 아래 단계를 따라 주세요:

- Instantiate [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스.
- 기본 차트를 생성합니다.
- 그림을 설정합니다.
- 첫 번째 차트 시리즈를 가져옵니다.
- 새 데이터 포인트를 추가합니다.
- 프레젠테이션을 디스크에 저장합니다.

아래 예제에서는 데이터 포인트 수준에서 차트 마커 옵션을 설정했습니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetMarkerOptions-SetMarkerOptions.cpp" >}}

## **시리즈 데이터 포인트 수준에서 차트 마커 설정**
이제 특정 시리즈 내의 차트 데이터 포인트에 마커를 설정할 수 있습니다. 차트 마커 옵션을 설정하려면 아래 단계를 따라 주세요:

- Presentation 클래스를 인스턴스화합니다.
- 기본 차트를 생성합니다.
- 그림을 설정합니다.
- 첫 번째 차트 시리즈를 가져옵니다.
- 새 데이터 포인트를 추가합니다.
- 프레젠테이션을 디스크에 저장합니다.

아래 예제에서는 데이터 포인트 수준에서 차트 마커 옵션을 설정했습니다.

```cpp
const String outPath = u"../out/SetMarkerOptionsonSeries_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";
const String ImagePath2 = u"../templates/aspose - logo.jpg";

//PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
SharedPtr<Presentation> pres = MakeObject<Presentation>();

//첫 번째 슬라이드에 접근합니다
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// 기본 데이터가 있는 차트를 추가합니다
SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::LineWithMarkers, 0, 0, 500, 500);

// 차트 데이터 시트의 인덱스를 설정합니다
int defaultWorksheetIndex = 0;

// 차트 데이터 워크시트를 가져옵니다
SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

// 기본 생성된 시리즈와 카테고리를 삭제합니다
chart->get_ChartData()->get_Series()->Clear();

// 이제 새 시리즈를 추가합니다
SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());

// 그림을 가져옵니다
SharedPtr<IImage> image = Images::FromFile(ImagePath);
SharedPtr<IImage> image2 = Images::FromFile(ImagePath2);

// 프레젠테이션 이미지 컬렉션에 이미지를 추가합니다
SharedPtr<IPPImage> imgx1 = pres->get_Images()->AddImage(image);
SharedPtr<IPPImage> imgx2 = pres->get_Images()->AddImage(image2);

image->Dispose();
image2->Dispose();

// 그곳에 새 포인트 (1:3)를 추가합니다.
SharedPtr<IChartDataPoint> point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(4.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx1);

point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(2.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx2);

point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(3.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx1);

point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 4, 1, ObjectExt::Box<double>(4.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx2);

// Changing the chart series marker
series->get_Marker()->set_Size(15);

// Write the presentation file to disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
pres->Dispose();
```

## **데이터 포인트에 색 적용**
Aspose.Slides for C++를 사용하여 차트의 데이터 포인트에 색을 적용할 수 있습니다. [**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/)와 **[IChartDataPointLevel](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/ichartdatapointlevel/)** 클래스가 추가되어 데이터 포인트 레벨의 속성에 접근할 수 있습니다. 이 문서에서는 차트에서 데이터 포인트에 색을 접근하고 적용하는 방법을 설명합니다.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColorToDataPoints-AddColorToDataPoints.cpp" >}}

## **FAQ**

**기본 제공되는 마커 모양은 무엇입니까?**

표준 모양(원, 정사각형, 다이아몬드, 삼각형 등)이 제공되며, 목록은 [MarkerStyleType](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/markerstyletype/) 열거형으로 정의됩니다. 비표준 모양이 필요하면 사진 채우기가 있는 마커를 사용하여 사용자 지정 시각 효과를 흉내낼 수 있습니다.

**차트를 이미지나 SVG로 내보낼 때 마커가 보존됩니까?**

예. 차트를 [래스터 형식](/slides/ko/cpp/convert-powerpoint-to-png/)으로 렌더링하거나 [SVG로 저장](/slides/ko/cpp/render-a-slide-as-an-svg-image/)할 때 마커는 크기, 채우기, 외곽선 등을 포함한 모양과 설정을 유지합니다.