---
title: 그룹 도형
type: docs
weight: 170
url: /ko/net/examples/elements/group-shape/
keywords:
- 그룹
- 그룹 도형 추가
- 그룹 도형 접근
- 그룹 도형 제거
- 그룹 해제 도형
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET에서 그룹화된 도형을 관리합니다: PPT, PPTX 및 ODP 프레젠테이션에서 C# 예제를 사용하여 그룹 도형을 만들고, 중첩하고, 정렬하고, 순서를 변경하며, 스타일을 적용합니다."
---
**Aspose.Slides for .NET**를 사용하여 도형 그룹을 만들고, 접근하고, 그룹 해제 및 제거하는 예제입니다.

## **그룹 도형 추가**

두 개의 기본 도형을 포함하는 그룹을 생성합니다.

```csharp
static void AddGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
    group.Shapes.AddAutoShape(ShapeType.Ellipse, 60, 0, 50, 50);
}
```

## **그룹 도형 접근**

슬라이드에서 첫 번째 그룹 도형을 가져옵니다.

```csharp
static void AccessGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    var firstGroup = slide.Shapes.OfType<IGroupShape>().First();
}
```

## **그룹 도형 제거**

슬라이드에서 그룹 도형을 삭제합니다.

```csharp
static void RemoveGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();

    slide.Shapes.Remove(group);
}
```

## **그룹 해제 도형**

그룹 컨테이너에서 도형을 꺼냅니다.

```csharp
static void UngroupShapes()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    var rect = group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    // 그룹 밖으로 도형을 이동합니다.
    slide.Shapes.AddClone(rect);
    group.Shapes.Remove(rect);
}
```