---
title: 마스터 슬라이드
type: docs
weight: 30
url: /ko/net/examples/elements/master-slide/
keywords:
- 마스터 슬라이드
- 마스터 슬라이드 추가
- 마스터 슬라이드 액세스
- 마스터 슬라이드 제거
- 사용되지 않은 마스터 슬라이드
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET 마스터 슬라이드 예제를 탐색하세요: PPT, PPTX 및 ODP에서 마스터, 플레이스홀더 및 테마를 만들고, 편집하고, 스타일을 지정하는 방법을 명확한 C# 코드와 함께 제공합니다."
---
마스터 슬라이드는 PowerPoint에서 슬라이드 상속 계층의 최상위 레벨을 형성합니다. A **master slide** defines common design elements such as backgrounds, logos, and text formatting. **Layout slides** inherit from master slides, and **normal slides** inherit from layout slides.

이 문서에서는 Aspose.Slides for .NET을 사용하여 마스터 슬라이드를 만들고, 수정하고, 관리하는 방법을 보여줍니다.

## **마스터 슬라이드 추가**

이 예제는 기본 마스터 슬라이드를 복제하여 새 마스터 슬라이드를 만드는 방법을 보여줍니다. 그런 다음 레이아웃 상속을 통해 모든 슬라이드에 회사 이름 배너를 추가합니다.

```csharp
static void AddMasterSlide()
{
    using var presentation = new Presentation();

    // 기본 마스터 슬라이드를 복제합니다.
    var defaultMasterSlide = presentation.Masters[0];
    var newMasterSlide = presentation.Masters.AddClone(defaultMasterSlide);

    // 마스터 슬라이드 상단에 회사 이름 배너를 추가합니다.
    var textBox = newMasterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 0, y: 0, width: 720, height: 25);
    textBox.TextFrame.Text = "Company Name";
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    textBox.FillFormat.FillType = FillType.NoFill;

    // 새 마스터 슬라이드를 레이아웃 슬라이드에 할당합니다.
    var layoutSlide = presentation.LayoutSlides[0];
    layoutSlide.MasterSlide = newMasterSlide;

    // 프레젠테이션의 첫 번째 슬라이드에 레이아웃 슬라이드를 할당합니다.
    presentation.Slides[0].LayoutSlide = layoutSlide;
}
```

> 💡 **Note 1:** 마스터 슬라이드는 모든 슬라이드에 일관된 브랜드 또는 공통 디자인 요소를 적용하는 방법을 제공합니다. 마스터에 적용된 모든 변경 사항은 자동으로 종속된 레이아웃 및 일반 슬라이드에 반영됩니다.

> 💡 **Note 2:** 마스터 슬라이드에 추가된 모든 도형이나 서식은 레이아웃 슬라이드에 상속되고, 그 레이아웃을 사용하는 모든 일반 슬라이드에도 상속됩니다.
> 아래 이미지는 마스터 슬라이드에 추가된 텍스트 상자가 최종 슬라이드에 자동으로 렌더링되는 방식을 보여줍니다.

![마스터 상속 예시](master-slide-banner.png)

## **마스터 슬라이드 액세스**

`Presentation.Masters` 컬렉션을 사용하여 마스터 슬라이드에 액세스할 수 있습니다. 다음은 마스터 슬라이드를 검색하고 작업하는 방법입니다:

```csharp
static void AccessMasterSlide()
{
    using var presentation = new Presentation();

    // 첫 번째 마스터 슬라이드에 액세스합니다.
    var firstMasterSlide = presentation.Masters[0];

    // 배경 유형을 변경합니다.
    firstMasterSlide.Background.Type = BackgroundType.OwnBackground;
}
```

## **마스터 슬라이드 제거**

마스터 슬라이드는 인덱스나 참조를 사용하여 제거할 수 있습니다.

```csharp
static void RemoveMasterSlide()
{
    using var presentation = new Presentation("sample.pptx");

    // 인덱스로 마스터 슬라이드를 제거합니다.
    presentation.Masters.RemoveAt(0);

    // 참조로 마스터 슬라이드를 제거합니다.
    var firstMasterSlide = presentation.Masters[0];
    presentation.Masters.Remove(firstMasterSlide);
}
```

## **사용되지 않는 마스터 슬라이드 제거**

일부 프레젠테이션에는 사용되지 않는 마스터 슬라이드가 포함되어 있습니다. 이러한 슬라이드를 제거하면 파일 크기를 줄이는 데 도움이 됩니다.

```csharp
static void RemoveUnusedMasterSlide()
{
    using var presentation = new Presentation();

    // 사용되지 않는 모든 마스터 슬라이드를 제거합니다 (보존으로 표시된 슬라이드도 포함).
    presentation.Masters.RemoveUnused(ignorePreserveField: true);
}
```