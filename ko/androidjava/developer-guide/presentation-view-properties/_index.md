---
title: Android에서 프레젠테이션 보기 속성을 검색하고 업데이트하기
linktitle: 보기 속성
type: docs
weight: 80
url: /ko/androidjava/presentation-view-properties/
keywords:
- 보기 속성
- 일반 보기
- 개요 콘텐츠
- 개요 아이콘
- 세로 분할기 스냅
- 단일 보기
- 바 상태
- 차원 크기
- 자동 조정
- 기본 확대/축소
- PowerPoint
- OpenDocument
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java의 보기 속성을 활용하여 PPT, PPTX 및 ODP 슬라이드 형식을 맞춤 설정하고, 레이아웃, 확대/축소 수준 및 표시 설정을 조정하세요."
---
## **소개**

일반 보기에는 슬라이드 자체, 측면 콘텐츠 영역, 하단 콘텐츠 영역의 세 가지 콘텐츠 영역이 포함됩니다. 서로 다른 콘텐츠 영역의 위치와 관련된 속성입니다. 이 정보는 애플리케이션이 보기 상태를 파일에 저장하도록 하여, 다시 열었을 때 보기 상태가 마지막으로 저장된 프레젠테이션과 동일하게 유지됩니다.

Method [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) 메서드가 추가되어 프레젠테이션의 일반 보기 속성에 접근할 수 있게 되었습니다.

[INormalViewProperties](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/INormalViewRestoredProperties) 인터페이스와 그 파생 인터페이스, [SplitterBarStateType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/SplitterBarStateType) 열거형이 추가되었습니다.

## **INormalViewProperties에 대하여**

일반 보기 속성을 나타냅니다.

[getShowOutlineIcons] 메서드와 [setShowOutlineIcons] 메서드는 일반 보기 모드에서 개요 콘텐츠를 표시할 경우 애플리케이션이 아이콘을 표시할지 여부를 지정합니다.

[getSnapVerticalSplitter] 메서드와 [setSnapVerticalSplitter] 메서드는 측면 영역이 충분히 작을 때 세로 분할기가 최소화된 상태로 스냅될지 여부를 지정합니다.

[getPreferSingleView] 속성 및 [setPreferSingleView] 속성은 사용자가 세 개의 콘텐츠 영역을 가진 일반 보기 대신 전체 창 단일 콘텐츠 영역을 선호하는지 여부를 지정합니다. 활성화된 경우, 애플리케이션은 하나의 콘텐츠 영역을 전체 창에 표시하도록 선택할 수 있습니다.

[getVerticalBarState] 메서드와 [getHorizontalBarState] 메서드는 수평 또는 수직 분할 막대가 표시될 상태를 지정합니다. 수평 분할 막대는 슬라이드와 슬라이드 아래의 콘텐츠 영역을 구분하고, 수직 분할 막대는 슬라이드와 측면 콘텐츠 영역을 구분합니다. 가능한 값은 [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) 및 [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/SplitterBarStateType#Restored)입니다.

[getRestoredLeft] 메서드와 [getRestoredTop] 메서드는 일반 보기에서 [SplitterBarStateType.Restored] 값이 [getVerticalBarState](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--)와 [getHorizontalBarState](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--)에 각각 적용될 때 상단 또는 측면 슬라이드 영역의 크기를 지정합니다.

## **INormalViewProperties 복원에 대하여**

슬라이드 영역( [getRestoredTop]의 하위인 경우 너비, [getRestoredLeft]의 하위인 경우 높이)의 크기를 지정합니다. 이 영역이 가변 복원 크기(최소화되지도 최대화되지도 않은)일 때 일반 보기에서 적용됩니다.

[getDimensionSize] 메서드는 슬라이드 영역의 크기( restoredTop의 하위인 경우 너비, restoredLeft의 하위인 경우 높이)를 지정합니다.

[getAutoAdjust] 메서드는 애플리케이션 내에서 보기가 포함된 창 크기를 조정할 때 측면 콘텐츠 영역의 크기가 새로운 크기에 맞게 보정될지 여부를 지정합니다.

아래 예시는 프레젠테이션에 대해 [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) 속성에 어떻게 접근할 수 있는지 보여줍니다.

```java
Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // 프레젠테이션의 보기 속성을 복원합니다
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **기본 확대/축소 값 설정**

{{% alert color="primary" %}} 

Aspose.Slides for Android via Java는 이제 프레젠테이션을 열 때 확대/축소 비율이 이미 설정된 기본 확대/축소 값을 지정할 수 있습니다. 이는 프레젠테이션의 [ViewProperties](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ViewProperties)를 설정함으로써 수행할 수 있습니다. [getSlideViewProperties](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--)와 [getNotesViewProperties](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--)를 프로그래밍 방식으로 설정할 수 있습니다. 이 섹션에서는 [Aspose.Slides](/slides/ko/)에서 [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation)의 [View Properties](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ViewProperties)를 설정하는 방법을 예제로 살펴보겠습니다.

{{% /alert %}} 

보기 속성을 설정하려면 아래 단계에 따라 주세요:

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation)의 [View Properties](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ViewProperties)를 설정합니다.
1. 프레젠테이션을 [PPTX](https://docs.fileformat.com/presentation/pptx/) 파일로 저장합니다.
   아래 예시에서는 슬라이드 보기와 노트 보기 모두에 확대/축소 값을 설정했습니다.

```java
Presentation presentation = new Presentation();
try {
    // 프레젠테이션의 보기 속성을 설정합니다
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // 슬라이드 보기의 확대/축소 값(백분율)
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // 노트 보기의 확대/축소 값(백분율) 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**프레젠테이션의 다른 섹션에 대해 서로 다른 보기 설정을 지정할 수 있나요?**

[View settings](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#getViewProperties--)은 프레젠테이션 수준(일반 보기/슬라이드 보기)에서 정의되며 섹션별이 아니므로, 하나의 매개변수 집합이 열릴 때 전체 문서에 적용됩니다.

**다른 사용자에 대해 서로 다른 보기 상태를 미리 정의할 수 있나요?**

아니요. 설정은 파일에 저장되어 공유됩니다. 뷰어 애플리케이션은 사용자 선호를 반영할 수 있지만 파일 자체에는 하나의 보기 속성 집합만 포함됩니다.

**미리 정의된 View Properties가 포함된 템플릿을 준비하여 새로운 프레젠테이션을 동일하게 열 수 있나요?**

예. [view properties](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#getViewProperties--)는 프레젠테이션 수준에 저장되므로 템플릿에 포함시켜 새 문서를 만들면 동일한 초기 보기 구성을 사용할 수 있습니다.