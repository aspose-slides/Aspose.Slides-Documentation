---
title: Java에서 프레젠테이션 보기 속성 검색 및 업데이트
linktitle: 보기 속성
type: docs
weight: 80
url: /ko/java/presentation-view-properties/
keywords:
- 보기 속성
- 일반 보기
- 개요 콘텐츠
- 개요 아이콘
- 수직 스플리터 스냅
- 단일 보기
- 막대 상태
- 차원 크기
- 자동 조정
- 기본 확대/축소
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java 보기 속성을 활용하여 PPT, PPTX 및 ODP 슬라이드 형식을 맞춤 설정합니다—레이아웃, 확대/축소 수준 및 표시 설정을 조정하십시오."
---
## **소개**

일반 보기에는 슬라이드 자체, 사이드 콘텐츠 영역, 하단 콘텐츠 영역의 세 가지 콘텐츠 영역이 포함됩니다. 다양한 콘텐츠 영역의 위치에 관한 속성입니다. 이 정보는 애플리케이션이 보기 상태를 파일에 저장하도록 하며, 재열기 시 프레젠테이션이 마지막으로 저장된 시점과 동일한 상태로 보기가 표시됩니다.

메서드 [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IViewProperties#getNormalViewProperties--)이 프레젠테이션의 일반 보기 속성에 접근하기 위해 추가되었습니다.

[INormalViewProperties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewRestoredProperties) 인터페이스와 해당 파생형, [SplitterBarStateType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/SplitterBarStateType) 열거형이 추가되었습니다.

## **INormalViewProperties에 대하여**

일반 보기 속성을 나타냅니다.

[getShowOutlineIcons](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) 및 [setShowOutlineIcons](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) 메서드는 일반 보기 모드의 콘텐츠 영역 중 하나에 개요 콘텐츠를 표시할 때 애플리케이션이 아이콘을 표시할지 여부를 지정합니다.

[getSnapVerticalSplitter](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) 및 [setSnapVerticalSplitter](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) 메서드는 사이드 영역이 충분히 작아질 때 수직 분할기가 최소화 상태로 스냅되는지 여부를 지정합니다.

[getPreferSingleView](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) 및 [setPreferSingleView](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) 속성은 사용자가 세 개의 콘텐츠 영역이 있는 표준 일반 보기보다 전체 창 단일 콘텐츠 영역을 표시하기를 선호하는지 여부를 지정합니다. 활성화되면 애플리케이션은 전체 창에 하나의 콘텐츠 영역을 표시하도록 선택할 수 있습니다.

[getVerticalBarState](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) 및 [getHorizontalBarState](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) 메서드는 가로 또는 세로 분할 막대가 표시될 상태를 지정합니다. 가로 분할 막대는 슬라이드를 슬라이드 아래의 콘텐츠 영역과 구분하고, 세로 분할 막대는 슬라이드를 사이드 콘텐츠 영역과 구분합니다. 가능한 값은 [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/ko/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/ko/java/com.aspose.slides/SplitterBarStateType#Maximized) 및 [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ko/java/com.aspose.slides/SplitterBarStateType#Restored) 입니다.

[getRestoredLeft](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) 및 [getRestoredTop](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) 메서드는 일반 보기에서 상단 또는 사이드 슬라이드 영역의 크기를 지정합니다. 이는 [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ko/java/com.aspose.slides/SplitterBarStateType#Restored) 값이 [getVerticalBarState](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) 및 [getHorizontalBarState](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--)에 적용될 때 사용됩니다.

## **INormalViewProperties 복원에 대하여**

일반 보기에서 슬라이드 영역의 크기( [getRestoredTop](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) 의 자식인 경우 너비, [getRestoredLeft](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) 의 자식인 경우 높이)를 지정합니다. 해당 영역이 가변 복원 크기(최소화되지도 않고 최대화되지도 않음)일 때 적용됩니다.

[getDimensionSize](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) 메서드는 슬라이드 영역의 크기( restoredTop의 자식이면 너비, restoredLeft의 자식이면 높이)를 지정합니다.

[getAutoAdjust](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) 메서드는 애플리케이션 내에서 보기를 포함하는 창을 크기 조정할 때 사이드 콘텐츠 영역의 크기가 새로운 크기에 맞게 보정되어야 하는지 여부를 지정합니다.

아래 예제에서는 프레젠테이션에 대한 [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) 속성에 어떻게 접근하는지 보여줍니다.

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

Aspose.Slides for Java는 이제 프레젠테이션이 열릴 때 확대/축소가 이미 설정된 기본 확대/축소 값을 지정할 수 있습니다. 이는 프레젠테이션의 [ViewProperties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ViewProperties)를 설정하여 수행할 수 있습니다. [getSlideViewProperties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) 및 [getNotesViewProperties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ViewProperties#getNotesViewProperties--)도 프로그래밍 방식으로 설정할 수 있습니다. 이 항목에서는 예제를 통해 [Aspose.Slides](/slides/ko/)에서 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation)의 [View Properties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ViewProperties)를 설정하는 방법을 살펴봅니다.

{{% /alert %}} 

보기 속성을 설정하려면 아래 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation)의 [View Properties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ViewProperties)를 설정합니다.
1. 프레젠테이션을 [PPTX](https://docs.fileformat.com/presentation/pptx/) 파일로 저장합니다.
   아래 예제에서는 슬라이드 보기와 노트 보기 모두에 대해 확대/축소 값을 설정했습니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // 프레젠테이션의 보기 속성을 설정합니다
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // 슬라이드 보기용 백분율 줌 값
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // 노트 보기용 백분율 줌 값 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

### 프레젠테이션의 서로 다른 섹션에 대해 다른 보기 설정을 지정할 수 있나요?

[View settings](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#getViewProperties--)은 프레젠테이션 수준([Normal View](https://reference.aspose.com/slides/ko/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/ko/java/com.aspose.slides/viewproperties/#getSlideViewProperties--))에서 정의되며 섹션별로는 정의되지 않으므로, 열릴 때 전체 문서에 하나의 파라미터 집합이 적용됩니다.

### 서로 다른 사용자에 대해 다른 보기 상태를 미리 정의할 수 있나요?

아니요. 설정은 파일에 저장되어 공유됩니다. 뷰어 애플리케이션이 사용자의 선호도를 반영할 수는 있지만, 파일 자체에는 하나의 보기 속성 집합만 포함됩니다.

### 미리 정의된 View Properties가 포함된 템플릿을 만들어 새 프레젠테이션이 동일하게 열리도록 할 수 있나요?

예. [view properties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#getViewProperties--)가 프레젠테이션 수준에 저장되므로 템플릿에 포함시켜 동일한 초기 보기 구성으로 새 문서를 만들 수 있습니다.