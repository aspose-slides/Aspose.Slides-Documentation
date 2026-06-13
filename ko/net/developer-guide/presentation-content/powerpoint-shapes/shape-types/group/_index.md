---
title: .NET에서 그룹 프레젠테이션 도형
linktitle: 도형 그룹
type: docs
weight: 40
url: /ko/net/group/
keywords:
- 그룹 도형
- 도형 그룹
- 그룹 추가
- 대체 텍스트
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET를 사용하여 PowerPoint 프레젠테이션에서 도형을 그룹화 및 그룹 해제하는 방법을 배우세요—빠르고 단계별 가이드와 무료 C# 코드 제공."
---
## **개요**

이 문서는 Aspose.Slides에서 그룹 도형을 사용하는 방법을 설명합니다. 슬라이드에 그룹 도형을 추가하고 그 안에 도형을 배치한 뒤 업데이트된 프레젠테이션을 저장하는 방법을 보여줍니다. 또한 그룹 내부에 저장된 도형에 접근하고 해당 도형의 `AlternativeText` 값을 읽는 방법을 시연합니다. 추가로 중첩 그룹, z‑order, 잠금 옵션과 같은 관련 그룹 도형 기능도 간략히 다룹니다.

## **그룹 도형 추가**
Aspose.Slides는 슬라이드에서 그룹 도형을 작업하는 것을 지원합니다. 이 기능은 개발자가 보다 풍부한 프레젠테이션을 구현하도록 돕습니다. Aspose.Slides for .NET은 그룹 도형을 추가하거나 접근하는 것을 지원합니다. 추가된 그룹 도형에 도형을 넣어 채우거나 그룹 도형의 모든 속성에 접근할 수 있습니다. Aspose.Slides for .NET을 사용하여 슬라이드에 그룹 도형을 추가하려면:

1. Presentation 클래스의 인스턴스를 생성합니다.[Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation)
2. 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.
3. 슬라이드에 그룹 도형을 추가합니다.
4. 추가된 그룹 도형에 도형을 추가합니다.
5. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제는 슬라이드에 그룹 도형을 추가합니다.

```c#
// Presentation 클래스 인스턴스화 
using (Presentation pres = new Presentation())
{
    // 첫 번째 슬라이드 가져오기 
    ISlide sld = pres.Slides[0];

    // 슬라이드의 도형 컬렉션에 접근 
    IShapeCollection slideShapes = sld.Shapes;

    // 슬라이드에 그룹 도형 추가 
    IGroupShape groupShape = slideShapes.AddGroupShape();

    // 추가된 그룹 도형 내부에 도형 추가 
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // 그룹 도형 프레임 추가 
    groupShape.Frame = new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0);

    // PPTX 파일을 디스크에 저장 
    pres.Save("GroupShape_out.pptx", SaveFormat.Pptx);
}
```

## **AltText 속성 접근**
이 항목에서는 그룹 도형을 추가하고 슬라이드에 있는 그룹 도형의 AltText 속성에 접근하는 단계와 코드 예제를 제공합니다. Aspose.Slides for .NET을 사용하여 슬라이드의 그룹 도형에 대한 AltText에 접근하려면:

1. `Presentation` 클래스를 인스턴스화하여 PPTX 파일을 나타냅니다.
2. 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.
3. 슬라이드의 도형 컬렉션에 접근합니다.
4. 그룹 도형에 접근합니다.
5. AltText 속성에 접근합니다.

아래 예제는 그룹 도형의 대체 텍스트에 접근합니다.

```c#
// PPTX 파일을 나타내는 Presentation 클래스 인스턴스화
Presentation pres = new Presentation("AltText.pptx");

// 첫 번째 슬라이드 가져오기
ISlide sld = pres.Slides[0];

for (int i = 0; i < sld.Shapes.Count; i++)
{
    // 슬라이드의 도형 컬렉션에 접근
    IShape shape = sld.Shapes[i];

    if (shape is GroupShape)
    {
        // 그룹 도형에 접근합니다.
        IGroupShape grphShape = (IGroupShape)shape;
        for (int j = 0; j < grphShape.Shapes.Count; j++)
        {
            IShape shape2 = grphShape.Shapes[j];
            // AltText 속성에 접근
            Console.WriteLine(shape2.AlternativeText);
        }
    }
}
```

## **FAQ**

**중첩 그룹화(그룹 안에 그룹)가 지원됩니까?**

예. [GroupShape](https://reference.aspose.com/slides/ko/net/aspose.slides/groupshape/)에는 [ParentGroup](https://reference.aspose.com/slides/ko/net/aspose.slides/shape/parentgroup/) 속성이 있어 계층 구조 지원을 직접 나타냅니다(그룹은 다른 그룹의 하위 그룹이 될 수 있습니다).

**슬라이드의 다른 객체에 대한 그룹의 z‑order를 어떻게 제어합니까?**

[GroupShape](https://reference.aspose.com/slides/ko/net/aspose.slides/groupshape/)의 [ZOrderPosition](https://reference.aspose.com/slides/ko/net/aspose.slides/shape/zorderposition/) 속성을 사용하여 디스플레이 스택에서의 위치를 확인합니다.

**그룹 이동/편집/언그룹을 방지할 수 있나요?**

예. 그룹의 잠금 섹션은 [GroupShapeLock](https://reference.aspose.com/slides/ko/net/aspose.slides/groupshape/groupshapelock/)을 통해 제공되며, 이를 통해 객체에 대한 작업을 제한할 수 있습니다.