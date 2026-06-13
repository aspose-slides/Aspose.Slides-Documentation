---
title: .NET에서 프레젠테이션에 타원 추가
linktitle: 타원
type: docs
weight: 30
url: /ko/net/ellipse/
keywords:
- 타원
- 도형
- 타원 추가
- 타원 만들기
- 타원 그리기
- 서식이 지정된 타원
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET를 사용하여 PPT 및 PPTX 프레젠테이션에서 타원 도형을 만들고, 서식 지정하고, 조작하는 방법을 학습하세요—C# 코드 예제가 포함됩니다."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 PowerPoint 슬라이드에 타원 도형을 추가하는 방법을 보여줍니다. 간단한 타원 만들기, 서식이 지정된 타원 만들기, 그리고 업데이트된 프레젠테이션을 PPTX 파일로 저장하는 과정을 다룹니다. 또한 타원의 위치와 크기 작업, 쌓기 순서 제어, 애니메이션 효과 적용과 같은 관련 질문도 간략히 설명합니다.

## **타원 만들기**
프레젠테이션의 선택된 슬라이드에 간단한 타원을 추가하려면 아래 단계를 따라 주세요:

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다
1. 슬라이드의 인덱스를 사용하여 슬라이드 참조를 가져옵니다
1. IShapes 개체가 제공하는 AddAutoShape 메서드를 사용하여 Ellipse 유형의 AutoShape을 추가합니다
1. 수정된 프레젠테이션을 PPTX 파일로 작성합니다

아래 예제에서는 첫 번째 슬라이드에 타원을 추가했습니다.

```c#
 // PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다
using (Presentation pres = new Presentation())
{

    // 첫 번째 슬라이드를 가져옵니다
    ISlide sld = pres.Slides[0];

    // 타원 유형의 자동 도형을 추가합니다
    sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    //PPTX 파일을 디스크에 저장합니다
    pres.Save("EllipseShp1_out.pptx", SaveFormat.Pptx);
}
```

## **서식이 지정된 타원 만들기**
슬라이드에 보다 서식이 지정된 타원을 추가하려면 아래 단계를 따라 주세요:

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. 슬라이드의 인덱스를 사용하여 슬라이드 참조를 가져옵니다.
1. IShapes 개체가 제공하는 AddAutoShape 메서드를 사용하여 Ellipse 유형의 AutoShape을 추가합니다.
1. 타원의 채우기 유형을 Solid로 설정합니다.
1. IShape 개체와 연결된 FillFormat 개체가 노출하는 SolidFillColor.Color 속성을 사용하여 타원의 색을 설정합니다.
1. 타원의 선 색상을 설정합니다.
1. 타원의 선 두께를 설정합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 작성합니다.

아래 예제에서는 프레젠테이션의 첫 번째 슬라이드에 서식이 지정된 타원을 추가했습니다.

```c#
 // PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다
using (Presentation pres = new Presentation())
{

    // 첫 번째 슬라이드를 가져옵니다
    ISlide sld = pres.Slides[0];

    // 타원 유형의 자동 도형을 추가합니다
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // 타원 도형에 일부 서식을 적용합니다
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // 타원 선에 일부 서식을 적용합니다
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    //PPTX 파일을 디스크에 저장합니다
    pres.Save("EllipseShp2_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**슬라이드 단위에 대해 타원의 정확한 위치와 크기를 어떻게 설정합니까?**

좌표와 크기는 일반적으로 **포인트** 단위로 지정됩니다. 예측 가능한 결과를 얻으려면 슬라이드 크기를 기준으로 계산하고, 필요한 밀리미터 또는 인치를 포인트로 변환한 후 값을 할당하세요.

**타원을 다른 객체 위나 아래에 배치하려면 어떻게 합니까(쌓기 순서 제어)?**

객체의 그리기 순서를 앞으로 가져오거나 뒤로 보내서 조정합니다. 이렇게 하면 타원이 다른 객체와 겹치거나 그 뒤에 있는 객체를 드러낼 수 있습니다.

**타원의 나타남이나 강조에 애니메이션을 적용하려면 어떻게 합니까?**

[적용](/slides/ko/net/shape-animation/) 입장, 강조 또는 퇴장 효과를 도형에 적용하고, 트리거와 타이밍을 설정하여 애니메이션 재생 시점과 방식을 조정합니다.