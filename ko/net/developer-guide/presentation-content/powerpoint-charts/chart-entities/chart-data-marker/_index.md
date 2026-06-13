---
title: .NET에서 프레젠테이션의 차트 데이터 마커 관리
linktitle: 데이터 마커
type: docs
url: /ko/net/chart-data-marker/
keywords:
- 차트
- 데이터 포인트
- 마커
- 마커 옵션
- 마커 크기
- 채우기 유형
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET에서 차트 데이터 마커를 맞춤 설정하는 방법을 배우고, 명확한 C# 코드 예제로 PPT 및 PPTX 형식의 프레젠테이션 효과를 높입니다."
---
## **개요**

이 문서는 Aspose.Slides에서 차트 데이터 마커를 사용하는 방법을 설명합니다. 차트를 생성하고, 시리즈와 해당 데이터 포인트에 접근하며, 데이터 포인트 수준에서 마커에 그림 채우기를 적용하고, 마커 크기를 조정하고, 업데이트된 프레젠테이션을 저장하는 방법을 보여줍니다. 또한 표준 마커 모양이 `MarkerStyleType` 열거형을 통해 제공되며, 차트를 래스터 형식이나 SVG로 내보낼 때 마커 외관이 유지된다는 점을 언급합니다.

## **차트 마커 옵션 설정**
마커는 특정 시리즈의 차트 데이터 포인트에 설정할 수 있습니다. 차트 마커 옵션을 설정하려면 아래 단계를 따르세요:

- Presentation 클래스([Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation))를 인스턴스화합니다.
- 기본 차트를 생성합니다.
- 그림을 설정합니다.
- 첫 번째 차트 시리즈를 가져옵니다.
- 새 데이터 포인트를 추가합니다.
- 프레젠테이션을 디스크에 저장합니다.

아래 예제에서는 데이터 포인트 수준에서 차트 마커 옵션을 설정했습니다.

```c#
// Presentation 클래스의 인스턴스를 생성합니다
using Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];

// 기본 차트를 생성합니다
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 0, 0, 400, 400);

// Getting the default chart data worksheet index
int defaultWorksheetIndex = 0;

// 차트 데이터 워크시트를 가져옵니다
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// 데모 시리즈 삭제
chart.ChartData.Series.Clear();

// 새 시리즈 추가
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);

// 그림 설정
using IImage image1 = Images.FromFile("aspose-logo.jpg");
IPPImage imgx1 = presentation.Images.AddImage(image1);

// 그림 설정
using IImage image2 = Images.FromFile("Tulips.jpg");
IPPImage imgx2 = presentation.Images.AddImage(image2);

// 첫 번째 차트 시리즈 가져오기
IChartSeries series = chart.ChartData.Series[0];

// 새 포인트 (1:3)를 추가합니다.
IChartDataPoint point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, (double)4.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, (double)2.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, (double)3.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 4, 1, (double)4.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

// 차트 시리즈 마커 변경
series.Marker.Size = 15;

// 프레젠테이션을 디스크에 저장
presentation.Save("MarkOptions_out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**기본적으로 제공되는 마커 모양은 무엇입니까?**

표준 모양(원, 사각형, 다이아몬드, 삼각형 등)이 제공됩니다; 목록은 [MarkerStyleType](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/markerstyletype/) 열거형에 정의되어 있습니다. 비표준 모양이 필요한 경우, 그림 채우기가 적용된 마커를 사용하여 사용자 지정 시각 효과를 흉내낼 수 있습니다.

**차트를 이미지나 SVG로 내보낼 때 마커가 유지됩니까?**

예. 차트를 [래스터 형식](/slides/ko/net/convert-powerpoint-to-png/)으로 렌더링하거나 [SVG로 저장](/slides/ko/net/render-a-slide-as-an-svg-image/)할 때 마커는 크기, 채우기 및 윤곽선을 포함한 외관과 설정을 유지합니다.