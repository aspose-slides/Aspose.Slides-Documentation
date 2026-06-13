---
title: .NET에서 프레젠테이션 차트의 오류 막대 사용자 지정
linktitle: 오류 막대
type: docs
url: /ko/net/error-bar/
keywords:
- 오류 막대
- 사용자 지정 값
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET를 사용하여 차트에 오류 막대를 추가하고 사용자 지정하는 방법을 배우고, PowerPoint 프레젠테이션에서 데이터 시각화를 최적화하십시오."
---
## **개요**

이 문서는 Aspose.Slides를 사용하여 프레젠테이션 차트에서 오류 막대를 사용하는 방법을 설명합니다. 차트 시리즈에 오류 막대를 추가하고, X 및 Y 오류 막대 설정을 구성하며, 고정값, 백분율 및 사용자 지정 값과 같은 다양한 값 유형을 적용하는 방법을 보여줍니다.

또한 해당 데이터 포인트 컬렉션을 사용하여 시리즈의 개별 데이터 포인트에 사용자 지정 오류 막대 값을 할당하는 방법을 시연합니다. 추가로, 오류 막대가 내보내기 중에 어떻게 동작하는지, 마커 및 데이터 레이블과의 호환성, 관련 API 참조 클래스와 열거형을 찾을 수 있는 위치에 대한 간략한 참고 사항도 포함됩니다.

## **오류 막대 추가**
Aspose.Slides for .NET은 오류 막대 값을 관리하기 위한 간단한 API를 제공합니다. 샘플 코드는 사용자 지정 값 유형을 사용할 때 적용됩니다. 값을 지정하려면 시리즈의 **DataPoints** 컬렉션에 있는 특정 데이터 포인트의 **ErrorBarCustomValues** 속성을 사용합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. 원하는 슬라이드에 버블 차트를 추가합니다.
1. 첫 번째 차트 시리즈에 접근하여 오류 막대 X 형식을 설정합니다.
1. 첫 번째 차트 시리즈에 접근하여 오류 막대 Y 형식을 설정합니다.
1. 막대값 및 형식을 설정합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```c#
 // 빈 프레젠테이션 생성
 using (Presentation presentation = new Presentation())
 {
     // 버블 차트 생성
     IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

     // 오류 막대를 추가하고 형식 설정
     IErrorBarsFormat errBarX = chart.ChartData.Series[0].ErrorBarsXFormat;
     IErrorBarsFormat errBarY = chart.ChartData.Series[0].ErrorBarsYFormat;
     errBarX.IsVisible = true;
     errBarY.IsVisible = true;
     errBarX.ValueType = ErrorBarValueType.Fixed;
     errBarX.Value = 0.1f;
     errBarY.ValueType = ErrorBarValueType.Percentage;
     errBarY.Value = 5;
     errBarX.Type = ErrorBarType.Plus;
     errBarY.Format.Line.Width = 2;
     errBarX.HasEndCap = true;

     // 프레젠테이션 저장
     presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
 }
```

## **사용자 지정 오류 막대 값 추가**
Aspose.Slides for .NET은 사용자 지정 오류 막대 값을 관리하기 위한 간단한 API를 제공합니다. 샘플 코드는 **IErrorBarsFormat.ValueType** 속성이 **Custom**인 경우에 적용됩니다. 값을 지정하려면 시리즈의 **DataPoints** 컬렉션에 있는 특정 데이터 포인트의 **ErrorBarCustomValues** 속성을 사용합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. 원하는 슬라이드에 버블 차트를 추가합니다.
1. 첫 번째 차트 시리즈에 접근하여 오류 막대 X 형식을 설정합니다.
1. 첫 번째 차트 시리즈에 접근하여 오류 막대 Y 형식을 설정합니다.
1. 차트 시리즈의 개별 데이터 포인트에 접근하여 해당 데이터 포인트에 대한 오류 막대 값을 설정합니다.
1. 막대값 및 형식을 설정합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```c#
 // 빈 프레젠테이션 생성
using (Presentation presentation = new Presentation())
{
    // 버블 차트 생성
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // 사용자 지정 오류 막대를 추가하고 형식 설정
    IChartSeries series = chart.ChartData.Series[0];
    IErrorBarsFormat errBarX = series.ErrorBarsXFormat;
    IErrorBarsFormat errBarY = series.ErrorBarsYFormat;
    errBarX.IsVisible = true;
    errBarY.IsVisible = true;
    errBarX.ValueType = ErrorBarValueType.Custom;
    errBarY.ValueType = ErrorBarValueType.Custom;

    // 차트 시리즈 데이터 포인트에 접근하고 개별 포인트에 대한 오류 막대 값을 설정
    IChartDataPointCollection points = series.DataPoints;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = DataSourceType.DoubleLiterals;

    // 차트 시리즈 포인트에 대한 오류 막대 설정
    for (int i = 0; i < points.Count; i++)
    {
        points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 1;
    }

    // 프레젠테이션 저장
    presentation.Save("ErrorBarsCustomValues_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**프레젠테이션을 PDF 또는 이미지로 내보낼 때 오류 막대는 어떻게 되나요?**

오류 막대는 차트의 일부로 렌더링되어 호환되는 버전이나 렌더러가 있는 경우 차트 형식과 함께 변환 중에도 보존됩니다.

**오류 막대를 마커 및 데이터 레이블과 함께 사용할 수 있나요?**

예. 오류 막대는 별도의 요소이며 마커와 데이터 레이블과 호환됩니다. 요소가 겹치는 경우 형식을 조정해야 할 수 있습니다.

**API에서 오류 막대를 다루기 위한 속성 및 열거형 목록은 어디서 찾을 수 있나요?**

API 참조에서 [ErrorBarsFormat](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/errorbarsformat/) 클래스와 관련 열거형인 [ErrorBarType](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/errorbartype/) 및 [ErrorBarValueType](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/errorbarvaluetype/)을 확인하십시오.