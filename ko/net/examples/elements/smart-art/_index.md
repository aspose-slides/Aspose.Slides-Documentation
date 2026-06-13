---
title: SmartArt
type: docs
weight: 140
url: /ko/net/examples/elements/smart-art/
keywords:
- SmartArt
- SmartArt 추가
- SmartArt 액세스
- SmartArt 제거
- SmartArt 레이아웃
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET에서 SmartArt를 작업합니다: PowerPoint 및 OpenDocument 프레젠테이션을 위한 C#로 다이어그램을 만들고, 편집하고, 변환하고, 스타일을 적용합니다."
---
이 문서는 **Aspose.Slides for .NET**을 사용하여 SmartArt 그래픽을 추가하고, 액세스하고, 제거하며, 레이아웃을 변경하는 방법을 보여줍니다.

## **SmartArt 추가**

내장된 레이아웃 중 하나를 사용하여 SmartArt 그래픽을 삽입합니다.

```csharp
static void AddSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);
}
```

## **SmartArt 액세스**

슬라이드에서 첫 번째 SmartArt 객체를 가져옵니다.

```csharp
static void AccessSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    var firstSmartArt = slide.Shapes.OfType<ISmartArt>().First();
}
```

## **SmartArt 제거**

슬라이드에서 SmartArt 도형을 삭제합니다.

```csharp
static void RemoveSmartArt()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

    slide.Shapes.Remove(smartArt);
}
```

## **SmartArt 레이아웃 변경**

기존 SmartArt 그래픽의 레이아웃 유형을 업데이트합니다.

```csharp
static void ChangeSmartArtLayout()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.Layout = SmartArtLayoutType.VerticalPictureList;
}
```