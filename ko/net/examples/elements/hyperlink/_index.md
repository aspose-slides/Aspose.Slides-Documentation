---
title: 하이퍼링크
type: docs
weight: 130
url: /ko/net/examples/elements/hyperlink/
keywords:
- 하이퍼링크
- 하이퍼링크 추가
- 하이퍼링크 액세스
- 하이퍼링크 제거
- 하이퍼링크 업데이트
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET에서 하이퍼링크를 추가하고 관리합니다: 텍스트, 도형 및 이미지에 링크를 걸고, PPT, PPTX 및 ODP에 대한 대상과 동작을 설정하며 C# 예제를 제공합니다."
---
이 문서에서는 **Aspose.Slides for .NET**을 사용하여 도형에 대한 하이퍼링크를 추가, 액세스, 제거 및 업데이트하는 방법을 보여줍니다.

## **하이퍼링크 추가**

외부 웹사이트를 가리키는 하이퍼링크가 포함된 사각형 도형을 만듭니다.

```csharp
static void AddHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");
}
```

## **하이퍼링크 액세스**

도형의 텍스트 부분에서 하이퍼링크 정보를 읽어옵니다.

```csharp
static void AccessHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    var hyperlink = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick;
}
```

## **하이퍼링크 제거**

도형 텍스트에서 하이퍼링크를 지웁니다.

```csharp
static void RemoveHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    textPortion.PortionFormat.HyperlinkClick = null;
}
```

## **하이퍼링크 업데이트**

기존 하이퍼링크의 대상을 변경합니다. `HyperlinkManager`를 사용하여 이미 하이퍼링크가 포함된 텍스트를 수정하면 PowerPoint가 하이퍼링크를 안전하게 업데이트하는 방식을 모방합니다.

```csharp
static void UpdateHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://old.example.com");

    // 기존 텍스트 내의 하이퍼링크를 변경하려면
    // 직접 속성을 설정하는 대신 HyperlinkManager를 사용해야 합니다.
    // 이는 PowerPoint가 하이퍼링크를 안전하게 업데이트하는 방식을 모방합니다.
    textPortion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://new.example.com");
}
```