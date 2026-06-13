---
title: .NET에서 프레젠테이션에 선 모양 추가
linktitle: 선
type: docs
weight: 50
url: /ko/net/Line/
keywords:
- 선
- 선 만들기
- 선 추가
- 일반 선
- 선 구성
- 선 사용자 지정
- 대시 스타일
- 화살표 머리
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 PowerPoint 프레젠테이션에서 선 서식을 조작하는 방법을 배웁니다. 속성, 메서드 및 예제를 확인하세요."
---
## **개요**

Aspose.Slides를 사용하면 프로그래밍 방식으로 PowerPoint 슬라이드에 선 모양을 추가할 수 있습니다. 이 문서에서는 간단한 선을 만들고 선을 화살표처럼 보이도록 사용자 정의하는 방법을 보여줍니다.

슬라이드에 선 모양을 추가하고 시각적 모양을 조정한 다음 업데이트된 프레젠테이션을 저장하는 방법을 배웁니다. 예제에서는 스타일, 두께, 대시 패턴, 화살촉 옵션 및 채우기 색상과 같은 실용적인 선 서식 설정에 중점을 둡니다.

## **일반 선 만들기**
프레젠테이션의 선택한 슬라이드에 간단한 일반 선을 추가하려면 아래 단계를 따르세요.

- [Presentation ](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
- 인덱스를 사용하여 슬라이드 참조를 가져옵니다.
- Shapes 객체가 제공하는 [AddAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection/methods/addautoshape/index) 메서드를 사용하여 Line 유형의 AutoShape를 추가합니다.
- 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제에서는 프레젠테이션의 첫 번째 슬라이드에 선을 추가했습니다.

```c#
// PPTX 파일을 나타내는 PresentationEx 클래스를 인스턴스화합니다
using (Presentation pres = new Presentation())
{
    // 첫 번째 슬라이드를 가져옵니다
    ISlide sld = pres.Slides[0];

    // 라인 유형의 자동 도형을 추가합니다
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    //PPTX를 디스크에 저장합니다
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```

## **화살표 모양 선 만들기**
Aspose.Slides for .NET은 개발자가 선의 속성을 구성하여 보다 매력적으로 보이게 할 수 있도록 지원합니다. 선을 화살표처럼 보이게 몇 가지 속성을 구성해 보겠습니다. 아래 단계를 따르세요.

- [Presentation ](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/ko/aspose.slides/)[](http://www.aspose.com/api/net/slides/ko/aspose.slides/)의 인스턴스를 생성합니다.
- 인덱스를 사용하여 슬라이드 참조를 가져옵니다.
- Shapes 객체가 제공하는 AddAutoShape 메서드를 사용하여 Line 유형의 AutoShape를 추가합니다.
- Aspose.Slides for .NET에서 제공하는 스타일 중 하나로 Line Style을 설정합니다.
- 선의 Width를 설정합니다.
- [Dash Style](https://reference.aspose.com/slides/ko/net/aspose.slides/linedashstyle) 을 Aspose.Slides for .NET에서 제공하는 스타일 중 하나로 설정합니다.
- [Arrow Head Style](https://reference.aspose.com/slides/ko/net/aspose.slides/linearrowheadstyle) 및 선 시작점의 Length를 설정합니다.
- 선 끝점의 Arrow Head Style 및 Length를 설정합니다.
- 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```c#
// PPTX 파일을 나타내는 PresentationEx 클래스를 인스턴스화합니다
using (Presentation pres = new Presentation())
{

    // 첫 번째 슬라이드를 가져옵니다
    ISlide sld = pres.Slides[0];

    // 라인 유형의 자동 도형을 추가합니다
    IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // 선에 일부 서식을 적용합니다
    shp.LineFormat.Style = LineStyle.ThickBetweenThin;
    shp.LineFormat.Width = 10;

    shp.LineFormat.DashStyle = LineDashStyle.DashDot;

    shp.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
    shp.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Oval;

    shp.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
    shp.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;

    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Maroon;

    //PPTX를 디스크에 저장합니다
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**일반 선을 커넥터로 변환하여 도형에 “스냅”되도록 할 수 있나요?**

아니요. 일반 선은 ([AutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/autoshape/) 중 [Line](https://reference.aspose.com/slides/ko/net/aspose.slides/shapetype/) 유형)이며 자동으로 커넥터가 되지 않습니다. 도형에 스냅되게 하려면 전용 [Connector](https://reference.aspose.com/slides/ko/net/aspose.slides/connector/) 유형과 연결을 위한 [corresponding APIs](/slides/ko/net/connector/)를 사용하세요.

**선의 속성이 테마에서 상속되어 최종 값을 파악하기 어려운 경우 어떻게 해야 하나요?**

[ILineFormatEffectiveData](https://reference.aspose.com/slides/ko/net/aspose.slides/ilineformateffectivedata/) / [ILineFillFormatEffectiveData](https://reference.aspose.com/slides/ko/net/aspose.slides/ilinefillformateffectivedata/) 인터페이스를 통해 [효과적인 속성](/slides/ko/net/shape-effective-properties/)을 읽으세요—이 인터페이스들은 이미 상속 및 테마 스타일을 반영합니다.

**선을 편집(이동, 크기 변경)으로부터 잠글 수 있나요?**

예. Shapes는 [lock objects](https://reference.aspose.com/slides/ko/net/aspose.slides/autoshape/autoshapelock/) 를 제공하며, 이를 통해 [편집 작업을 금지](/slides/ko/net/applying-protection-to-presentation/)할 수 있습니다.