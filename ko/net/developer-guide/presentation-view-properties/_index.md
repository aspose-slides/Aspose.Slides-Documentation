---
title: .NET에서 프레젠테이션 보기 속성 검색 및 업데이트
linktitle: 보기 속성
type: docs
weight: 80
url: /ko/net/presentation-view-properties/
keywords:
- 보기 속성
- 일반 보기
- 윤곽선 콘텐츠
- 윤곽선 아이콘
- 수직 스플리터 고정
- 단일 보기
- 바 상태
- 차원 크기
- 자동 조정
- 기본 줌
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET 보기 속성을 활용하여 PPT, PPTX 및 ODP 슬라이드 형식을 사용자 정의하고, 레이아웃, 줌 수준 및 표시 설정을 조정합니다."
---
## **소개**

Normal view는 슬라이드 자체, 측면 콘텐츠 영역, 하단 콘텐츠 영역의 세 개 영역으로 구성됩니다. 각 영역의 위치와 관련된 속성은 애플리케이션이 뷰 상태를 파일에 저장하도록 하며, 파일을 다시 열면 마지막 저장 시점과 동일한 상태로 뷰가 복원됩니다.

Property [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/ko/net/aspose.slides/iviewproperties/properties/normalviewproperties) 가 추가되어 프레젠테이션의 normal view 속성에 접근할 수 있게 되었습니다.

[INormalViewProperties](https://reference.aspose.com/slides/ko/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/ko/net/aspose.slides/inormalviewrestoredproperties) 인터페이스와 그 파생형, [SplitterBarStateType](https://reference.aspose.com/slides/ko/net/aspose.slides/splitterbarstatetype) 열거형이 추가되었습니다.

## **INormalViewProperties에 대하여**

정상 보기 속성을 나타냅니다.

Property **ShowOutlineIcons** 은 normal view 모드의 어느 콘텐츠 영역에서든 윤곽선 콘텐츠를 표시할 때 아이콘을 표시할지 여부를 지정합니다.

Property **SnapVerticalSplitter** 은 측면 영역이 충분히 작아졌을 때 수직 스플리터를 최소화된 상태로 고정할지 여부를 지정합니다.

Property **PreferSingleView** 은 사용자가 세 개의 콘텐츠 영역이 있는 표준 normal view 대신 전체 창에 단일 콘텐츠 영역을 표시하는 것을 선호하는지를 지정합니다. 활성화된 경우 애플리케이션은 하나의 콘텐츠 영역을 전체 창에 표시하도록 선택할 수 있습니다.

Property **VerticalBarState** 와 **HorizontalBarState** 는 각각 수직 및 수평 스플리터 바가 보여야 할 상태를 지정합니다. 수평 스플리터 바는 슬라이드와 슬라이드 아래의 콘텐츠 영역을 구분하고, 수직 스플리터 바는 슬라이드와 측면 콘텐츠 영역을 구분합니다. 가능한 값은 **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized**, **SplitterBarStateType.Restored** 입니다.

Property **RestoredLeft** 와 **RestoredTop** 은 **VerticalBarState** 와 **HorizontalBarState** 에 **SplitterBarStateType.Restored** 값이 적용될 때 normal view의 측면 또는 상단 슬라이드 영역의 크기를 지정합니다.

## **INormalViewProperties 복원에 대하여**

정상 view에서 슬라이드 영역( RestoredTop의 자식이면 너비, RestoredLeft의 자식이면 높이)의 크기를 지정합니다. 해당 영역이 가변 복원 크기( 최소화도 아니고 최대화도 아님)일 때 적용됩니다.

Property **DimensionSize** 는 슬라이드 영역의 크기( restoredTop의 자식이면 너비, restoredLeft의 자식이면 높이)를 지정합니다.

Property **AutoAdjust** 는 창 크기를 조정할 때 측면 콘텐츠 영역의 크기가 새 크기에 맞게 보정될지 여부를 지정합니다.

아래 예제는 프레젠테이션에 대해 **ViewProperties.NormalViewProperties** 속성에 접근하는 방법을 보여 줍니다.

```c#
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

## **기본 줌 값 설정**

Aspose.Slides for .NET 은 프레젠테이션이 열릴 때 이미 줌이 설정된 기본 줌 값을 지정하는 기능을 지원합니다. 이는 프레젠테이션의 [ViewProperties](https://reference.aspose.com/slides/ko/net/aspose.slides/viewproperties)를 설정함으로써 수행할 수 있습니다. 슬라이드 보기 속성과 [NotesViewProperties](https://reference.aspose.com/slides/ko/net/aspose.slides/viewproperties/properties/notesviewproperties) 도 프로그래밍 방식으로 설정할 수 있습니다. 이 문서에서는 Aspose.Slides에서 프레젠테이션의 View Properties를 설정하는 방법을 예제로 보여 줍니다.

뷰 속성을 설정하려면 아래 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다
1. 프레젠테이션의 View [Properties](https://reference.aspose.com/slides/ko/net/aspose.slides/viewproperties) 를 설정합니다
1. 프레젠테이션을 PPTX 파일로 저장합니다

아래 예제에서는 슬라이드 뷰와 노트 뷰 모두에 대해 줌 값을 설정했습니다.

```c#
using (Presentation presentation = new Presentation("demo.pptx"))
{
    // 프레젠테이션의 보기 속성을 설정합니다
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // 슬라이드 뷰의 줌 값(백분율)
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // 노트 뷰의 줌 값(백분율) 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**프레젠테이션의 다른 섹션에 대해 다른 보기 설정을 지정할 수 있나요?**

[View settings](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/viewproperties/) 은 프레젠테이션 수준([Normal View](https://reference.aspose.com/slides/ko/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/ko/net/aspose.slides/viewproperties/slideviewproperties/)) 에 정의되며 섹션별로 정의되지 않으므로 문서를 열 때 전체 문서에 동일한 매개변수가 적용됩니다.

**다른 사용자에 대해 미리 정의된 보기 상태를 설정할 수 있나요?**

아닙니다. 설정은 파일에 저장되며 공유됩니다. 뷰어 애플리케이션이 사용자 환경 설정을 존중할 수는 있지만 파일 자체에는 하나의 보기 속성 집합만 포함됩니다.

**새 프레젠테이션이 동일한 방식으로 열리도록 미리 정의된 View Properties가 포함된 템플릿을 만들 수 있나요?**

예 가능합니다. [view properties](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/viewproperties/) 가 프레젠테이션 수준에 저장되므로 템플릿에 포함시켜 새 문서를 만들 때 동일한 초기 보기 구성을 사용할 수 있습니다.