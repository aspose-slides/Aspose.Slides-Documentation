---
title: 텍스트 상자
type: docs
weight: 40
url: /ko/net/examples/elements/text-box/
keywords:
- 텍스트 상자
- 텍스트 상자 추가
- 텍스트 상자 액세스
- 텍스트 상자 제거
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: ".NET용 Aspose.Slides에서 텍스트 상자를 사용합니다: C#를 사용하여 PPT, PPTX 및 ODP 프레젠테이션의 텍스트를 추가, 서식 지정, 정렬, 줄 바꿈, 자동 맞춤 및 스타일링합니다."
---
Aspose.Slides에서 **텍스트 상자**는 `AutoShape`으로 표현됩니다. 거의 모든 도형은 텍스트를 포함할 수 있지만, 일반적인 텍스트 상자는 채우기나 테두리가 없으며 텍스트만 표시합니다.

이 가이드에서는 텍스트 상자를 프로그래밍 방식으로 추가, 액세스 및 제거하는 방법을 설명합니다.

## **텍스트 상자 추가**

텍스트 상자는 단순히 채우기와 테두리가 없고 서식이 적용된 텍스트가 포함된 `AutoShape`입니다. 다음은 텍스트 상자를 만드는 방법입니다:

```csharp
public static void AddTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // 직사각형 도형을 생성합니다(기본값은 테두리와 채우기가 있으며 텍스트가 없습니다).
    var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 50, y: 75, width: 150, height: 100);

    // 채우기와 테두리를 제거하여 일반 텍스트 상자처럼 보이게 합니다.
    textBox.FillFormat.FillType = FillType.NoFill;
    textBox.LineFormat.FillFormat.FillType = FillType.NoFill;

    // 텍스트 서식을 설정합니다.
    var paragraph = textBox.TextFrame.Paragraphs[0];
    var textFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
    textFormat.FillFormat.FillType = FillType.Solid;
    textFormat.FillFormat.SolidFillColor.Color = Color.Black;

    // 실제 텍스트 내용을 할당합니다.
    textBox.TextFrame.Text = "Some text...";
}
```

> 💡 **참고:** 비어 있지 않은 `TextFrame`을 포함하는 `AutoShape`은 텍스트 상자로 사용할 수 있습니다.

## **내용으로 텍스트 상자 액세스**

특정 키워드(예: "Slide")를 포함하는 모든 텍스트 상자를 찾으려면 도형을 반복하면서 텍스트를 확인합니다:

```csharp
public static void AccessTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    foreach (var shape in slide.Shapes)
    {
        // AutoShape만 편집 가능한 텍스트를 포함할 수 있습니다.
        if (shape is AutoShape autoShape)
        {
            if (autoShape.TextFrame.Text.Contains("Slide"))
            {
                // 일치하는 텍스트 상자에 대해 작업을 수행합니다.
            }
        }
    }
}
```

## **내용으로 텍스트 상자 제거**

이 예제는 첫 번째 슬라이드에서 특정 키워드를 포함하는 모든 텍스트 상자를 찾아 삭제합니다:

```csharp
public static void RemoveTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shapesToRemove = slide.Shapes
        .Where(s => s is AutoShape autoShape && autoShape.TextFrame.Text.Contains("Slide"))
        .ToList();

    shapesToRemove.ForEach(shape => slide.Shapes.Remove(shape));
}
```

> 💡 **팁:** 반복 중에 컬렉션을 수정할 때 컬렉션 수정 오류를 방지하려면 항상 도형 컬렉션의 복사본을 만든 후 수정하세요.