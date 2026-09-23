---
title: .NET에서 프레젠테이션 보기 속성 검색 및 업데이트
linktitle: 보기 속성
type: docs
weight: 80
url: /ko/net/presentation-view-properties/
keywords:
- 보기 속성
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
description: "Aspose.Slides for .NET의 보기 속성을 활용하여 PPT, PPTX 및 ODP 슬라이드 형식을 커스터마이즈하고 레이아웃, 확대/축소 수준 및 표시 설정을 조정하세요."
---
## **소개**

일반 보기에는 슬라이드 자체, 측면 콘텐츠 영역, 하단 콘텐츠 영역의 세 가지 콘텐츠 영역이 포함됩니다. 다양한 콘텐츠 영역의 위치와 관련된 속성입니다. 이 정보는 애플리케이션이 보기 상태를 파일에 저장하도록 하여, 다시 열 때 프레젠테이션이 마지막으로 저장된 시점과 동일한 상태로 보기를 복원할 수 있게 합니다.

프레젠테이션의 일반 보기 속성에 접근하기 위해 [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/ko/net/aspose.slides/iviewproperties/properties/normalviewproperties) 속성이 추가되었습니다.

[INormalViewProperties](https://reference.aspose.com/slides/ko/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/ko/net/aspose.slides/inormalviewrestoredproperties) 인터페이스와 해당 파생형, [SplitterBarStateType](https://reference.aspose.com/slides/ko/net/aspose.slides/splitterbarstatetype) 열거형이 추가되었습니다.

## **INormalViewProperties에 대하여**

일반 보기 속성을 나타냅니다.

속성 **ShowOutlineIcons**는 일반 보기 모드의 콘텐츠 영역 중 어느 영역에서든 개요 콘텐츠를 표시할 경우 애플리케이션이 아이콘을 표시할지 여부를 지정합니다.

속성 **SnapVerticalSplitter**는 측면 영역이 충분히 작아질 때 수직 분할기가 최소화 상태로 스냅될지 여부를 지정합니다.

속성 **PreferSingleView**는 사용자가 세 개의 콘텐츠 영역이 있는 표준 일반 보기보다 전체 창을 차지하는 단일 콘텐츠 영역을 선호하는지 여부를 지정합니다. 이 옵션이 활성화되면 애플리케이션은 하나의 콘텐츠 영역을 전체 창에 표시하도록 선택할 수 있습니다.

속성 **VerticalBarState**와 **HorizontalBarState**는 수평 또는 수직 분할 막대가 표시될 상태를 지정합니다. 수평 분할 막대는 슬라이드와 슬라이드 아래의 콘텐츠 영역을 구분하고, 수직 분할 막대는 슬라이드와 측면 콘텐츠 영역을 구분합니다. 가능한 값은 **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized**, **SplitterBarStateType.Restored**입니다.

속성 **RestoredLeft**와 **RestoredTop**은 **VerticalBarState**와 **HorizontalBarState**에 **SplitterBarStateType.Restored** 값이 적용될 때 일반 보기의 상단 또는 측면 슬라이드 영역의 크기를 지정합니다.

## **INormalViewProperties 복원에 대하여**

일반 보기에서 영역이 가변 복원 크기(최소화되지도, 최대화되지도 않음)일 때 슬라이드 영역( RestoredTop의 자식이면 너비, RestoredLeft의 자식이면 높이)의 크기를 지정합니다.

속성 **DimensionSize**는 슬라이드 영역의 크기( restoredTop의 자식이면 너비, restoredLeft의 자식이면 높이)를 지정합니다.

속성 **AutoAdjust**는 애플리케이션 내에서 보기를 포함하는 창의 크기를 조정할 때 측면 콘텐츠 영역의 크기가 새로운 크기에 맞게 보정될지 여부를 지정합니다.

아래 예시에서는 프레젠테이션에 대해 **ViewProperties.NormalViewProperties** 속성에 접근하는 방법을 보여줍니다.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    // 프레젠테이션의 보기 속성을 복원합니다
    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```

## **기본 확대/축소 값 설정**

Aspose.Slides for .NET은 이제 프레젠테이션을 열 때 이미 확대/축소가 설정된 상태가 되도록 기본 확대/축소 값을 지정할 수 있습니다. 이는 프레젠테이션의 [ViewProperties](https://reference.aspose.com/slides/ko/net/aspose.slides/viewproperties)를 설정함으로써 수행할 수 있습니다. 슬라이드 보기 속성 및 [NotesViewProperties](https://reference.aspose.com/slides/ko/net/aspose.slides/viewproperties/properties/notesviewproperties)도 프로그래밍 방식으로 설정할 수 있습니다. 이 항목에서는 Aspose.Slides에서 프레젠테이션의 보기 속성을 설정하는 예제를 보여줍니다.

보기 속성을 설정하려면 아래 단계를 따르세요:

1. 프레젠테이션 클래스인 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation)의 인스턴스를 생성합니다.
1. 프레젠테이션의 보기 [Properties](https://reference.aspose.com/slides/ko/net/aspose.slides/viewproperties)를 설정합니다.
1. 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예시에서는 슬라이드 보기와 노트 보기 모두에 확대/축소 값을 설정했습니다.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    // 프레젠테이션의 보기 속성을 설정합니다
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // 슬라이드 보기의 확대/축소 값(백분율)
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // 노트 보기의 확대/축소 값(백분율) 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **그리드 간격 설정**

[Presentation.ViewProperties](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/viewproperties/)를 사용하여 프레젠테이션 전체에 대한 보기 설정에 접근합니다. [IViewProperties.GridSpacing](https://reference.aspose.com/slides/ko/net/aspose.slides/iviewproperties/gridspacing/) 속성은 기본 편집 그리드의 간격을 읽거나 변경합니다. 이 설정은 개별 슬라이드가 아니라 전체 프레젠테이션에 적용됩니다. 그리드 간격은 포인트 단위이며, 72포인트는 1인치와 같습니다. API 문서에서 요구하는 대로 양수 값을 사용하십시오.

다음 예제는 기존 `demo.pptx` 파일을 열어 현재 그리드 간격을 출력하고, 1/4인치 간격으로 설정한 후 결과를 저장합니다.

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

그리드는 [drawing guides](/slides/ko/net/drawing-guides/)와 다릅니다. 그리드 간격은 규칙적인 간격을 제어하는 반면, 드로잉 가이드는 개별적으로 배치된 수평 또는 수직 정렬선입니다. 드로잉 가이드를 추가, 이동 또는 제거해도 그리드 간격은 변하지 않습니다.

그리드와 드로잉 가이드는 모두 편집 보조 도구이며 PDF, 이미지, SVG 또는 슬라이드 쇼에 슬라이드 콘텐츠로 렌더링되지 않습니다. 그리드 간격을 저장한다고 해서 편집기가 그리드를 표시한다는 보장은 없으며, 표시 여부는 뷰어 또는 편집기의 설정에 따라 달라집니다.

## **프레젠테이션 열 때 주석 표시 또는 숨기기**

[Presentation.ViewProperties](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/viewproperties/)를 사용하여 프레젠테이션 전체에 대한 보기 설정에 접근합니다. [IViewProperties.ShowComments](https://reference.aspose.com/slides/ko/net/aspose.slides/iviewproperties/showcomments/)를 읽거나 변경하여 PowerPoint 또는 기타 호환 편집기에서 프레젠테이션을 열 때 주석을 표시할지 여부에 대한 기본 설정을 저장합니다.

이 설정은 저장된 보기 기본 설정만 제어합니다. 주석을 추가, 제거, 편집 또는 해결하지는 않으며, 주석을 숨겨도 내용, 작성자, 위치, 답글 및 상태는 보존됩니다. 주석 자체를 변경하는 작업은 [Presentation Comments](/slides/ko/net/presentation-comments/)를 참고하십시오.

다음 예제는 주석이 포함된 기존 `comments.pptx` 파일이 필요합니다. 현재 가시성 설정을 출력하고 주석을 숨기도록 요청한 뒤 주석을 제거하지 않은 채 새로운 PPTX 파일로 저장합니다. 또한 [IViewProperties.LastView](https://reference.aspose.com/slides/ko/net/aspose.slides/iviewproperties/lastview/)를 [ViewType.SlideView](https://reference.aspose.com/slides/ko/net/aspose.slides/viewtype/)로 설정하여 주석 가시성과 함께 초기 편집 보기를 구성합니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("comments.pptx");
var showComments = presentation.ViewProperties.ShowComments;
Console.WriteLine($"Current comment visibility: {showComments}");

presentation.ViewProperties.ShowComments = NullableBool.False;
presentation.ViewProperties.LastView = ViewType.SlideView;
presentation.Save("comments-hidden.pptx", SaveFormat.Pptx);
```

이 설정은 PDF, HTML, 이미지, 노트 또는 유인물 내보내기에 주석이 포함되는지를 결정하지 않습니다. 관련 내보내기별 옵션을 별도로 구성하십시오.

## **FAQ**

**프레젠테이션을 다시 열었을 때 그리드가 보이지 않는 이유는 무엇인가요?**  
파일에는 그리드 간격이 저장되지만, 그리드가 표시되는지는 편집기가 제어합니다. 편집기의 그리드 가시성 설정을 확인하십시오.

**드로잉 가이드를 삭제하면 그리드 간격이 변경됩니까?**  
아니요. 드로잉 가이드와 그리드 간격은 독립적인 설정이며, 가이드를 삭제해도 저장된 그리드 간격은 변경되지 않습니다.

**프레젠테이션의 서로 다른 섹션마다 다른 보기 설정을 지정할 수 있나요?**  
[View settings](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/viewproperties/)은 섹션별이 아니라 프레젠테이션 수준([Normal View](https://reference.aspose.com/slides/ko/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/ko/net/aspose.slides/viewproperties/slideviewproperties/))에서 정의되므로, 프레젠테이션이 열릴 때 전체 문서에 단일 파라미터 집합이 적용됩니다.

**다른 사용자마다 다른 보기 상태를 미리 정의할 수 있나요?**  
아니요. 설정은 파일에 저장되어 공유되며, 뷰어 애플리케이션이 사용자 선호도를 반영할 수는 있지만 파일 자체에는 하나의 보기 속성 집합만 포함됩니다.

**미리 정의된 보기 속성을 가진 템플릿을 만들어 새 프레젠테이션이 동일하게 열리게 할 수 있나요?**  
예. [view properties](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/viewproperties/)가 프레젠테이션 수준에 저장되므로 템플릿에 포함시켜 새 문서를 만들면 동일한 초기 보기 구성을 갖게 할 수 있습니다.