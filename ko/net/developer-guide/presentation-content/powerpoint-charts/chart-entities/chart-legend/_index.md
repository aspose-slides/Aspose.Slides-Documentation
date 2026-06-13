---
title: .NET에서 프레젠테이션의 차트 범례 맞춤 설정
linktitle: 차트 범례
type: docs
url: /ko/net/chart-legend/
keywords:
- 차트 범례
- 범례 위치
- 글꼴 크기
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET를 사용하여 차트 범례를 맞춤 설정하고, 맞춤형 범례 서식으로 PowerPoint 프레젠테이션을 최적화합니다."
---
## **개요**

Aspose.Slides는 PowerPoint 프레젠테이션에서 차트 범례를 사용자 지정할 수 있는 옵션을 제공합니다. 이 문서에서는 범례의 위치와 크기를 설정하고, 전체 범례의 글꼴 크기를 지정하며, 개별 범례 항목에 서식을 적용하는 방법을 보여줍니다.

또한 FAQ에서 관련 동작들을 다룹니다. 여기에는 범례가 차지할 공간을 확보하기 위해 오버레이가 아닌 모드를 사용하는 것, 긴 범례 레이블을 자동으로 줄 바꿈하거나 줄 바꿈 문자를 사용할 수 있게 하는 것, 명시적인 텍스트 및 채우기 설정을 적용하지 않을 경우 범례 서식이 프레젠테이션 테마를 상속하도록 하는 내용이 포함됩니다.

## **범례 위치 지정**
In order to set the legend properties. Please follow the steps below:

- [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
- 슬라이드에 대한 참조를 가져옵니다.
- 슬라이드에 차트를 추가합니다.
- 범례 속성을 설정합니다.
- 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제에서는 차트 범례의 위치와 크기를 설정했습니다.

```c#
// Presentation 클래스의 인스턴스를 생성합니다
Presentation presentation = new Presentation();

// 슬라이드에 대한 참조를 가져옵니다
ISlide slide = presentation.Slides[0];

// 슬라이드에 클러스터형 열 차트를 추가합니다
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// 범례 속성을 설정합니다
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

// 프레젠테이션을 디스크에 저장합니다
presentation.Save("Legend_out.pptx", SaveFormat.Pptx);
```

## **범례 글꼴 크기 설정**
Aspose.Slides for .NET은 개발자가 범례의 글꼴 크기를 설정하도록 지원합니다. 아래 단계를 따르세요:

- `Presentation` 클래스를 인스턴스화합니다.
- 기본 차트를 생성합니다.
- 글꼴 크기를 설정합니다.
- 최소 축 값을 설정합니다.
- 최대 축 값을 설정합니다.
- 프레젠테이션을 디스크에 저장합니다.

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.Legend.TextFormat.PortionFormat.FontHeight = 20;
	chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
	chart.Axes.VerticalAxis.MinValue = -5;
	chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
	chart.Axes.VerticalAxis.MaxValue = 10;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **개별 범례 글꼴 크기 설정**
Aspose.Slides for .NET은 개발자가 개별 범례 항목의 글꼴 크기를 설정하도록 지원합니다. 아래 단계를 따르세요:

- `Presentation` 클래스를 인스턴스화합니다.
- 기본 차트를 생성합니다.
- 범례 항목에 접근합니다.
- 글꼴 크기를 설정합니다.
- 최소 축 값을 설정합니다.
- 최대 축 값을 설정합니다.
- 프레젠테이션을 디스크에 저장합니다.

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
	IChartTextFormat tf = chart.Legend.Entries[1].TextFormat;

	tf.PortionFormat.FontBold = NullableBool.True;
	tf.PortionFormat.FontHeight = 20;
	tf.PortionFormat.FontItalic = NullableBool.True;
	tf.PortionFormat.FillFormat.FillType = FillType.Solid; ;
	tf.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**차트가 범례를 오버레이하지 않고 자동으로 공간을 할당하도록 범례를 활성화할 수 있나요?**

예. 비오버레이 모드([Overlay](https://reference.aspose.com/slides/ko/net/aspose.slides.charts/legend/overlay/) = `false`)를 사용합니다; 이 경우 플롯 영역이 축소되어 범례를 수용합니다.

**다중 행 범례 레이블을 만들 수 있나요?**

예. 공간이 충분하지 않을 경우 긴 레이블이 자동으로 줄 바꿈됩니다; 강제 줄 바꿈은 시리즈 이름에 개행 문자를 넣어 지원됩니다.

**범례가 프레젠테이션 테마의 색 구성표를 따르도록 하려면 어떻게 해야 하나요?**

범례나 그 텍스트에 명시적인 색상/채우기/글꼴을 설정하지 마세요. 이렇게 하면 테마를 상속받아 디자인이 변경될 때 올바르게 업데이트됩니다.