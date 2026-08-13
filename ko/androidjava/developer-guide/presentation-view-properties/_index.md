---
title: Android에서 프레젠테이션 보기 속성 검색 및 업데이트
linktitle: 보기 속성
type: docs
weight: 80
url: /ko/androidjava/presentation-view-properties/
keywords:
- 보기 속성
- 일반 보기
- 윤곽선 콘텐츠
- 윤곽선 아이콘
- 수직 분할기 스냅
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
description: "Aspose.Slides for Android via Java의 보기 속성을 활용하여 PPT, PPTX 및 ODP 슬라이드 형식을 사용자 지정하고—레이아웃, 확대/축소 수준 및 표시 설정을 조정하세요."
---
## **소개**

일반 보기에는 슬라이드 자체, 측면 콘텐츠 영역, 하단 콘텐츠 영역의 세 가지 콘텐츠 영역으로 구성됩니다. 다양한 콘텐츠 영역의 위치에 관한 속성들입니다. 이 정보는 애플리케이션이 뷰 상태를 파일에 저장하도록 하여, 다시 열었을 때 뷰가 프레젠테이션이 마지막으로 저장된 시점과 동일한 상태가 되도록 합니다.

프레젠테이션의 일반 보기 속성에 액세스할 수 있도록 [IViewProperties.getNormalViewProperties 메서드](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--)가 추가되었습니다.

[INormalViewProperties] 인터페이스와 [INormalViewRestoredProperties] 인터페이스 및 그 파생 인터페이스, [SplitterBarStateType] 열거형이 추가되었습니다.

## **INormalViewProperties에 대하여**

일반 보기 속성을 나타냅니다.

메서드 [getShowOutlineIcons]와 [setShowOutlineIcons]는 일반 보기 모드의 콘텐츠 영역 중 어느 곳에서든 윤곽선 콘텐츠를 표시할 때 아이콘을 표시할지 여부를 지정합니다.

메서드 [getSnapVerticalSplitter]와 [setSnapVerticalSplitter]는 측면 영역이 충분히 작아졌을 때 수직 분할기가 최소화 상태로 스냅될지 여부를 지정합니다.

속성 [getPreferSingleView]와 [setPreferSingleView]는 사용자가 세 개의 콘텐츠 영역이 있는 일반 보기 대신 전체 창에 단일 콘텐츠 영역을 보기를 원하는지 여부를 지정합니다. 활성화된 경우, 애플리케이션은 하나의 콘텐츠 영역을 전체 창에 표시하도록 선택할 수 있습니다.

메서드 [getVerticalBarState]와 [getHorizontalBarState]는 수평 또는 수직 분할 막대가 표시되어야 할 상태를 지정합니다. 수평 분할 막대는 슬라이드를 슬라이드 아래의 콘텐츠 영역과 구분하고, 수직 분할 막대는 슬라이드를 측면 콘텐츠 영역과 구분합니다. 가능한 값은 [SplitterBarStateType.Minimized], [SplitterBarStateType.Maximized] 및 [SplitterBarStateType.Restored]입니다.

메서드 [getRestoredLeft]와 [getRestoredTop]은 [SplitterBarStateType.Restored] 값이 각각 [getVerticalBarState]와 [getHorizontalBarState]에 적용될 때 일반 보기의 상단 또는 측면 슬라이드 영역의 크기를 지정합니다.

## **INormalViewProperties 복원에 대하여**

일반 보기에서 영역이 가변 복원 크기(최소화되지도 않고 최대화되지도 않음)일 때 슬라이드 영역의 크기(복원된 상단의 자식인 경우 너비, 복원된 왼쪽의 자식인 경우 높이)를 지정합니다.

메서드 [getDimensionSize]는 복원된 상단의 자식인 경우 너비, 복원된 왼쪽의 자식인 경우 높이를 지정합니다.

메서드 [getAutoAdjust]는 창 크기를 조정할 때 측면 콘텐츠 영역의 크기가 새로운 크기에 맞게 보정되어야 하는지 여부를 지정합니다.

아래 예제는 프레젠테이션에 대해 [ViewProperties.getNormalViewProperties] 속성에 액세스하는 방법을 보여줍니다.

```java
import com.aspose.slides.*;

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

{{% alert color="info" %}} 

Aspose.Slides for Android via Java는 이제 프레젠테이션을 열 때 확대/축소 비율이 이미 설정된 상태가 되도록 기본 확대/축소 값을 설정하는 기능을 지원합니다. 이는 프레젠테이션의 [ViewProperties]를 설정하여 수행할 수 있습니다. [getSlideViewProperties]와 [getNotesViewProperties]를 프로그래밍 방식으로 설정할 수 있습니다. 이 항목에서는 [Aspose.Slides](/slides/ko/)에서 [Presentation]의 [View Properties]를 설정하는 방법을 예제로 살펴봅니다.

{{% /alert %}} 

뷰 속성을 설정하려면 아래 단계를 따르세요:

1. [Presentation] 클래스의 인스턴스를 생성합니다.
1. [Presentation]의 [View Properties]를 설정합니다.
1. 프레젠테이션을 [PPTX] 파일로 저장합니다. 아래 예제에서는 슬라이드 뷰와 노트 뷰 모두에 대해 확대/축소 값을 설정했습니다.

```java
import com.aspose.slides.*;

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

### 프레젠테이션의 서로 다른 섹션에 대해 다른 뷰 설정을 지정할 수 있나요?

[View settings]는 프레젠테이션 수준([Normal View]/[Slide View])에서 정의되며 섹션별이 아니라 전체 문서에 하나의 매개변수 집합이 적용됩니다.

### 서로 다른 사용자를 위해 다른 뷰 상태를 사전 정의할 수 있나요?

아니요. 설정은 파일에 저장되며 공유됩니다. 뷰어 애플리케이션이 사용자 환경설정을 따를 수는 있지만 파일 자체는 하나의 뷰 속성 집합만 포함합니다.

### 새 프레젠테이션이 동일한 방식으로 열리도록 미리 정의된 View Properties가 포함된 템플릿을 만들 수 있나요?

예. [view properties]가 프레젠테이션 수준에 저장되므로 템플릿에 포함시켜 해당 템플릿으로 새 문서를 만들면 동일한 초기 뷰 구성으로 열 수 있습니다.