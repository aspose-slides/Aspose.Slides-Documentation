---
title: 커넥터
type: docs
weight: 190
url: /ko/net/examples/elements/connector/
keywords:
- 커넥터
- 커넥터 추가
- 커넥터 접근
- 커넥터 삭제
- 도형 재연결
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET를 사용하여 도형 사이에 커넥터를 추가하고, 라우팅하며, 스타일링하는 방법을 배우고, PPT, PPTX 및 ODP 프레젠테이션에 대한 C# 예제를 확인하세요."
---
이 문서에서는 **Aspose.Slides for .NET**을 사용하여 도형을 커넥터로 연결하고 대상을 변경하는 방법을 보여줍니다.

## **커넥터 추가**
슬라이드의 두 지점 사이에 커넥터 도형을 삽입합니다.

```csharp
static void AddConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);
}
```

## **커넥터 접근**
슬라이드에 추가된 첫 번째 커넥터 도형을 가져옵니다.

```csharp
static void AccessConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    var connector = slide.Shapes.OfType<IConnector>().First();
}
```

## **커넥터 삭제**
슬라이드에서 커넥터를 삭제합니다.

```csharp
static void RemoveConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    slide.Shapes.Remove(connector);
}
```

## **도형 재연결**
시작 및 끝 대상을 할당하여 커넥터를 두 도형에 연결합니다.

```csharp
static void ReconnectShapes()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
    var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 50, 50);
    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    connector.StartShapeConnectedTo = shape1;
    connector.EndShapeConnectedTo = shape2;
}
```