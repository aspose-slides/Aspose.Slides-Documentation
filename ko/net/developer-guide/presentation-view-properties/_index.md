---
title: .NET에서 프레젠테이션 뷰 속성 검색 및 업데이트
linktitle: 뷰 속성
type: docs
weight: 80
url: /ko/net/presentation-view-properties/
keywords:
- 뷰 속성
- 일반 보기
- 개요 콘텐츠
- 개요 아이콘
- 수직 분할기 스냅
- 단일 보기
- 바 상태
- 차원 크기
- 자동 조정
- 기본 확대/축소
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET의 뷰 속성을 활용하여 PPT, PPTX 및 ODP 슬라이드 형식을 사용자 정의하고, 레이아웃, 확대/축소 수준 및 표시 설정을 조정하십시오."
---
## **소개**

일반 보기(normal view)는 슬라이드 자체, 측면 콘텐츠 영역, 하단 콘텐츠 영역의 세 개 영역으로 구성됩니다. 각 콘텐츠 영역의 위치와 관련된 속성입니다. 이 정보를 통해 애플리케이션은 뷰 상태를 파일에 저장할 수 있으며, 파일을 다시 열면 프레젠테이션이 마지막으로 저장된 상태와 동일한 뷰가 표시됩니다.

Property [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/ko/net/aspose.slides/iviewproperties/properties/normalviewproperties) 가 추가되어 프레젠테이션의 일반 뷰 속성에 접근할 수 있습니다.

[INormalViewProperties](https://reference.aspose.com/slides/ko/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/ko/net/aspose.slides/inormalviewrestoredproperties) 인터페이스와 그 파생형인 [SplitterBarStateType](https://reference.aspose.com/slides/ko/net/aspose.slides/splitterbarstatetype) 열거형이 추가되었습니다.

## **INormalViewProperties에 대하여**

일반 뷰 속성을 나타냅니다.

Property **ShowOutlineIcons** 은 일반 보기 모드에서 개요 콘텐츠를 어떤 콘텐츠 영역에 표시하든 아이콘을 표시할지 여부를 지정합니다.

Property **SnapVerticalSplitter** 은 측면 영역이 충분히 작아질 때 수직 분할기가 최소화 상태로 스냅될지 여부를 지정합니다.

Property **PreferSingleView** 은 사용자가 세 개의 콘텐츠 영역이 있는 표준 일반 보기 대신 전체 창에서 단일 콘텐츠 영역을 보기를 선호하는지 여부를 지정합니다. 이 옵션이 활성화되면 애플리케이션은 하나의 콘텐츠 영역을 전체 창에 표시하도록 선택할 수 있습니다.

Property **VerticalBarState** 와 **HorizontalBarState** 은 각각 수직 또는 수평 분할 막대가 표시될 상태를 지정합니다. 수평 분할 막대는 슬라이드와 슬라이드 아래의 콘텐츠 영역을 구분하고, 수직 분할 막대는 슬라이드와 측면 콘텐츠 영역을 구분합니다. 가능한 값은 **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized**, **SplitterBarStateType.Restored** 입니다.

Property **RestoredLeft** 와 **RestoredTop** 은 **VerticalBarState** 와 **HorizontalBarState** 에 **SplitterBarStateType.Restored** 값이 적용될 때 일반 보기의 상단 또는 측면 슬라이드 영역 크기를 지정합니다.

## **INormalViewProperties 복원에 대하여**

일반 보기에서 영역이 가변적인 복원 크기(최소화되지도 않고 최대화되지도 않음)인 경우 슬라이드 영역(복원 상단의 자식이면 너비, 복원 좌측의 자식이면 높이)의 크기를 지정합니다.

Property **DimensionSize** 은 슬라이드 영역의 크기(복원 상단의 자식이면 너비, 복원 좌측의 자식이면 높이)를 지정합니다.

Property **AutoAdjust** 은 창 크기를 조정할 때 측면 콘텐츠 영역의 크기가 새로운 크기에 맞게 보정되어야 하는지를 지정합니다.

아래 예제는 프레젠테이션에 대한 **ViewProperties.NormalViewProperties** 속성에 어떻게 접근하는지 보여줍니다.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    // 프레젠테이션의 뷰 속성을 복원합니다
    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```

## **기본 확대/축소 값 설정**

Aspose.Slides for .NET 은 프레젠테이션을 열 때 이미 확대/축소가 설정된 기본 확대/축소 값을 지정하는 기능을 지원합니다. 이는 프레젠테이션의 [ViewProperties](https://reference.aspose.com/slides/ko/net/aspose.slides/viewproperties) 을 설정함으로써 수행할 수 있습니다. 슬라이드 뷰 속성뿐만 아니라 [NotesViewProperties](https://reference.aspose.com/slides/ko/net/aspose.slides/viewproperties/properties/notesviewproperties) 도 프로그래밍 방식으로 설정할 수 있습니다. 이 문서에서는 Aspose.Slides에서 프레젠테이션의 뷰 속성을 설정하는 방법을 예제로 살펴봅니다.

뷰 속성을 설정하려면 아래 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다
2. 프레젠테이션의 뷰 [Properties](https://reference.aspose.com/slides/ko/net/aspose.slides/viewproperties) 를 설정합니다
3. 프레젠테이션을 PPTX 파일로 저장합니다

아래 예제에서는 슬라이드 뷰와 노트 뷰의 확대/축소 값을 설정했습니다.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    // 프레젠테이션의 뷰 속성을 설정합니다
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // 슬라이드 보기의 확대 비율(백분율)
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // 노트 보기의 확대 비율(백분율)

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **그리드 간격 설정**

[Presentation.ViewProperties](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/viewproperties/) 를 사용하여 프레젠테이션 전체에 적용되는 뷰 설정에 접근합니다. [IViewProperties.GridSpacing](https://reference.aspose.com/slides/ko/net/aspose.slides/iviewproperties/gridspacing/) 속성은 기본 편집 그리드의 간격을 읽거나 변경합니다. 이 설정은 개별 슬라이드가 아니라 전체 프레젠테이션에 적용됩니다. 그리드 간격은 포인트 단위이며, 72 포인트가 1인치에 해당합니다. API 문서에서 요구하는 대로 양수 값을 사용하세요.

다음 예제는 기존 `demo.pptx` 파일을 열어 현재 그리드 간격을 출력하고, 1/4인치 간격으로 설정한 뒤 결과를 저장합니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");
var gridSpacing = presentation.ViewProperties.GridSpacing;
Console.WriteLine($"Current grid spacing: {gridSpacing} points");

presentation.ViewProperties.GridSpacing = 18f;
presentation.Save("grid-spacing.pptx", SaveFormat.Pptx);
```

그리드는 [drawing guides](/slides/ko/net/drawing-guides/)와 다릅니다. 그리드 간격은 규칙적인 간격을 제어하고, 드로잉 가이드는 개별적으로 배치되는 수평 또는 수직 정렬선입니다. 가이드를 추가·이동·삭제해도 그리드 간격은 변경되지 않습니다.

그리드와 드로잉 가이드는 모두 편집 보조 도구이며 PDF, 이미지, SVG 또는 슬라이드 쇼에 슬라이드 콘텐츠로 렌더링되지 않습니다. 그리드 간격을 저장한다고 해서 편집기가 반드시 그리드를 표시한다는 보장은 없습니다. 표시 여부는 뷰어나 편집기의 설정에 따라 달라집니다.

## **FAQ**

**프레젠테이션을 다시 열었을 때 그리드가 보이지 않는 이유는 무엇인가요?**

파일에 그리드 간격이 저장되지만, 편집기가 그리드를 표시할지는 편집기 설정에 따릅니다. 편집기의 그리드 표시 설정을 확인하세요.

**드로잉 가이드를 삭제하면 그리드 간격이 바뀝니까?**

아니요. 드로잉 가이드와 그리드 간격은 독립적인 설정입니다. 가이드를 삭제해도 저장된 그리드 간격은 그대로 유지됩니다.

**프레젠테이션의 서로 다른 섹션마다 다른 뷰 설정을 지정할 수 있나요?**

[View settings](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/viewproperties/) 은 프레젠테이션 수준([Normal View](https://reference.aspose.com/slides/ko/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/ko/net/aspose.slides/viewproperties/slideviewproperties/))에서 정의되며 섹션별로는 적용되지 않으므로 문서가 열릴 때 전체 문서에 동일한 파라미터가 적용됩니다.

**다른 사용자마다 다른 뷰 상태를 미리 정의할 수 있나요?**

아니요. 설정은 파일에 저장되며 공유됩니다. 뷰어 애플리케이션이 사용자 기본 설정을 따를 수는 있지만 파일 자체에는 하나의 뷰 속성 집합만 포함됩니다.

**새 프레젠테이션이 동일한 방식으로 열리도록 미리 정의된 View Properties가 포함된 템플릿을 만들 수 있나요?**

예. [view properties](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/viewproperties/) 가 프레젠테이션 수준에 저장되므로 템플릿에 포함시켜 두면 새 문서를 만들 때 동일한 초기 뷰 구성이 적용됩니다.