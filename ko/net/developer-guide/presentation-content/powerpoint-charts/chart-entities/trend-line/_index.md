---
title: .NET에서 프레젠테이션 차트에 추세선 추가
linktitle: 추세선
type: docs
url: /ko/net/trend-line/
keywords:
- 차트
- 추세선
- 지수 추세선
- 선형 추세선
- 로그 추세선
- 이동 평균 추세선
- 다항식 추세선
- 거듭제곱 추세선
- 사용자 정의 추세선
- 파워포인트
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET를 사용하여 PowerPoint 차트에 추세선을 빠르게 추가하고 사용자 지정하세요 — 청중을 사로잡는 실용적인 가이드."
---
## **개요**

이 문서는 Aspose.Slides를 사용하여 프레젠테이션 차트에 추세선을 추가하는 방법을 설명합니다. 차트를 만드는 방법, 차트 시리즈에 추세선을 추가하는 방법 및 지수, 선형, 로그, 이동 평균, 다항식 및 거듭제곱을 포함한 다양한 추세선 유형을 다루는 방법을 보여줍니다.

또한 라인 도형을 삽입하여 차트에 사용자 정의 선을 추가하는 방법을 설명하고, 추세선의 앞쪽 및 뒤쪽 투영 값과 PDF 또는 SVG로 내보내거나 차트를 이미지로 렌더링할 때 추세선이 보존되는지에 대한 짧은 FAQ를 포함합니다.

## **추세선 추가**
Aspose.Slides for .NET은 다양한 차트 추세선을 관리하기 위한 간단한 API를 제공합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.
3. 원하는 유형 중 하나(이 예제에서는 ChartType.ClusteredColumn 사용)와 기본 데이터를 사용하여 차트를 추가합니다.
4. 차트 시리즈 1에 지수 추세선을 추가합니다.
5. 차트 시리즈 1에 선형 추세선을 추가합니다.
6. 차트 시리즈 2에 로그 추세선을 추가합니다.
7. 차트 시리즈 2에 이동 평균 추세선을 추가합니다.
8. 차트 시리즈 3에 다항식 추세선을 추가합니다.
9. 차트 시리즈 3에 거듭제곱 추세선을 추가합니다.
10. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 코드는 추세선이 포함된 차트를 만드는 데 사용됩니다.

```c#
// 빈 프레젠테이션 만들기
Presentation pres = new Presentation();

// 클러스터형 열 차트 만들기
IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

// 차트 시리즈 1에 지수 추세선 추가
ITrendline tredLinep = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Exponential);
tredLinep.DisplayEquation = false;
tredLinep.DisplayRSquaredValue = false;

// 차트 시리즈 1에 선형 추세선 추가
ITrendline tredLineLin = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Linear);
tredLineLin.TrendlineType = TrendlineType.Linear;
tredLineLin.Format.Line.FillFormat.FillType = FillType.Solid;
tredLineLin.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;


// 차트 시리즈 2에 로그 추세선 추가
ITrendline tredLineLog = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Logarithmic);
tredLineLog.TrendlineType = TrendlineType.Logarithmic;
tredLineLog.AddTextFrameForOverriding("New log trend line");

// 차트 시리즈 2에 이동 평균 추세선 추가
ITrendline tredLineMovAvg = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.MovingAverage);
tredLineMovAvg.TrendlineType = TrendlineType.MovingAverage;
tredLineMovAvg.Period = 3;
tredLineMovAvg.TrendlineName = "New TrendLine Name";

// 차트 시리즈 3에 다항식 추세선 추가
ITrendline tredLinePol = chart.ChartData.Series[2].TrendLines.Add(TrendlineType.Polynomial);
tredLinePol.TrendlineType = TrendlineType.Polynomial;
tredLinePol.Forward = 1;
tredLinePol.Order = 3;

// 차트 시리즈 3에 거듭제곱 추세선 추가
ITrendline tredLinePower = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Power);
tredLinePower.TrendlineType = TrendlineType.Power;
tredLinePower.Backward = 1;

// 프레젠테이션 저장
pres.Save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
```

## **사용자 정의 선 추가**
Aspose.Slides for .NET은 차트에 사용자 정의 선을 추가하기 위한 간단한 API를 제공합니다. 프레젠테이션의 선택된 슬라이드에 간단한 일반 선을 추가하려면 아래 단계를 따르세요:

- Presentation 클래스의 인스턴스를 생성합니다.
- 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.
- Shapes 개체가 제공하는 AddChart 메서드를 사용하여 새 차트를 생성합니다.
- Shapes 개체가 제공하는 AddAutoShape 메서드를 사용하여 선 유형의 AutoShape을 추가합니다.
- 도형 선의 색상을 설정합니다.
- 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 코드는 사용자 정의 선이 포함된 차트를 만드는 데 사용됩니다.

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    IAutoShape shape = chart.UserShapes.Shapes.AddAutoShape(ShapeType.Line, 0, chart.Height / 2, chart.Width, 0);
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
    pres.Save("AddCustomLines.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**추세선에서 'forward'와 'backward'는 무엇을 의미합니까?**

이는 추세선을 앞으로/뒤로 투영한 길이를 의미합니다. 산점도(XY) 차트에서는 축 단위로, 비산점도 차트에서는 카테고리 수로 표시됩니다. 0 이상의 값만 허용됩니다.

**프레젠테이션을 PDF 또는 SVG로 내보내거나 슬라이드를 이미지로 렌더링할 때 추세선이 보존됩니까?**

예. Aspose.Slides는 프레젠테이션을 [PDF](/slides/ko/net/convert-powerpoint-to-pdf/)/[SVG](/slides/ko/net/render-a-slide-as-an-svg-image/) 로 변환하고 차트를 이미지로 렌더링합니다. 차트의 일부인 추세선은 이러한 작업 중에 보존됩니다. 차트 자체의 이미지를 [내보내는](/slides/ko/net/create-shape-thumbnails/) 메서드도 제공됩니다.