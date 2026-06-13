---
title: .NET에서 프레젠테이션 잉크 개체 관리
linktitle: 잉크 관리
type: docs
weight: 95
url: /ko/net/manage-ink/
keywords:
- 잉크
- 잉크 개체
- 잉크 트레이스
- 잉크 관리
- 잉크 그리기
- 그리기
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "PowerPoint 잉크 개체를 관리합니다—Aspose.Slides for .NET으로 디지털 잉크를 만들고, 편집하고, 스타일을 적용합니다. 트레이스, 브러시 색상 및 크기에 대한 코드 샘플을 제공합니다."
---
## **소개**

PowerPoint는 비표준 도형을 그릴 수 있는 잉크 기능을 제공하며, 이를 사용해 다른 개체를 강조하고, 연결 및 프로세스를 표시하며, 슬라이드의 특정 항목에 주의를 끌 수 있습니다.  

Aspose.Slides는 잉크 개체를 생성하고 관리하는 데 필요한 타입을 포함하는 [Aspose.Slides.Ink](https://reference.aspose.com/slides/ko/net/aspose.slides.ink/) 인터페이스를 제공합니다.  

## **일반 개체와 잉크 개체의 차이점**

PowerPoint 슬라이드의 개체는 일반적으로 도형 개체로 표현됩니다. 도형 개체는 가장 간단하게는 개체 자체의 영역(프레임)과 해당 속성을 정의하는 컨테이너입니다. 여기에는 컨테이너 영역 크기, 컨테이너의 모양, 컨테이너 배경 등이 포함됩니다. 자세한 내용은 [Shape Layout Format](https://docs.aspose.com/slides/ko/net/shape-manipulations/#access-layout-formats-for-shape)를 참조하십시오.  

하지만 PowerPoint가 잉크 개체를 처리할 때는 크기를 제외한 개체 프레임(컨테이너)의 모든 속성을 무시합니다. 컨테이너 영역의 크기는 표준 `width` 및 `height` 값으로 결정됩니다:  

![ink_powerpoint1](ink_powerpoint1.png)

## **잉크 도형 트레이스**

트레이스는 사용자가 디지털 잉크를 쓸 때 펜의 궤적을 기록하는 기본 요소 또는 표준입니다. 트레이스는 연결된 점들의 순서를 설명하는 기록입니다.  

가장 간단한 인코딩 형태는 각 샘플 점의 X 및 Y 좌표를 지정합니다. 모든 연결된 점이 렌더링되면 다음과 같은 이미지가 생성됩니다:  

![ink_powerpoint2](ink_powerpoint2.png)

## **그리기용 브러시 속성**

브러시를 사용하여 트레이스 요소의 점들을 연결하는 선을 그릴 수 있습니다. 브러시에는 `Brush.Color` 및 `Brush.Size` 속성에 해당하는 고유 색상과 크기가 있습니다.  

### **잉크 브러시 색상 설정**

다음 C# 코드에서는 브러시의 색상을 설정하는 방법을 보여줍니다:  

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    IInk ink = (IInk)pres.Slides[0].Shapes[0];
    IInkTrace[] traces = ink.Traces;
    IInkBrush brush = traces[0].Brush;
    Color brushColor = brush.Color;
    brush.Color = Color.Red;
}
```

### **잉크 브러시 크기 설정** 

다음 C# 코드에서는 브러시의 크기를 설정하는 방법을 보여줍니다:  

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    IInk ink = (IInk)pres.Slides[0].Shapes[0];
    IInkTrace[] traces = ink.Traces;
    IInkBrush brush = traces[0].Brush;
    SizeF brushSize = brush.Size;
    brush.Size = new SizeF(5f, 10f);
}
```

일반적으로 브러시의 너비와 높이는 일치하지 않으므로 PowerPoint는 브러시 크기를 표시하지 않습니다(데이터 섹션이 회색으로 표시됨). 그러나 브러시의 너비와 높이가 일치하면 PowerPoint는 다음과 같이 크기를 표시합니다:  

![ink_powerpoint3](ink_powerpoint3.png)

명확히 하기 위해, 잉크 개체의 높이를 늘리고 중요한 차원을 검토해 보겠습니다:  

![ink_powerpoint4](ink_powerpoint4.png)

컨테이너(프레임)는 브러시의 크기를 고려하지 않으며, 항상 선 두께가 0이라고 가정합니다(마지막 이미지를 참조하십시오).  

따라서 전체 잉크 개체의 보이는 영역을 결정하려면 트레이스 개체의 브러시 크기를 고려해야 합니다. 여기서는 대상 개체(손글씨 텍스트 트레이스 개체)가 컨테이너(프레임) 크기에 맞게 스케일링되었습니다. 컨테이너(프레임)의 크기가 변경될 때 브러시 크기는 일정하게 유지되고, 그 반대도 마찬가지입니다.  

![ink_powerpoint5](ink_powerpoint5.png)

텍스트를 다룰 때도 PowerPoint는 동일한 동작을 보입니다:  

![ink_powerpoint6](ink_powerpoint6.png)

**추가 읽기**

* 일반적인 도형에 대해 읽으려면 [PowerPoint Shapes](https://docs.aspose.com/slides/ko/net/powerpoint-shapes/) 섹션을 참조하십시오.  
* 유효값에 대한 자세한 내용은 [Shape Effective Properties](https://docs.aspose.com/slides/ko/net/shape-effective-properties/#get-effective-font-height-value)를 참조하십시오.