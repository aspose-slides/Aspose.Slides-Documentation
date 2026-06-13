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
  - 바 상태
  - 차원 크기
  - 자동 조정
  - 기본 확대/축소
  - PowerPoint
  - OpenDocument
  - 프레젠테이션
  - Java
  - Aspose.Slides
description: "Aspose.Slides for Java의 보기 속성을 활용하여 PPT, PPTX 및 ODP 슬라이드 형식을 사용자 정의하고 레이아웃, 확대/축소 수준 및 표시 설정을 조정하세요."
---
## **소개**

일반 보기에는 세 개의 콘텐츠 영역이 있습니다: 슬라이드 자체, 측면 콘텐츠 영역, 그리고 하단 콘텐츠 영역. 다양한 콘텐츠 영역의 위치와 관련된 속성입니다. 이 정보를 통해 애플리케이션은 보기 상태를 파일에 저장할 수 있어, 파일을 다시 열 때 뷰가 마지막으로 저장된 상태와 동일하게 유지됩니다.

Method [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) 메서드가 추가되어 프레젠테이션의 일반 보기 속성에 접근할 수 있게 되었습니다.  

[INormalViewProperties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewRestoredProperties) 인터페이스와 그 하위 인터페이스, [SplitterBarStateType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/SplitterBarStateType) 열거형이 추가되었습니다.

## **INormalViewProperties에 대하여**

일반 보기 속성을 나타냅니다.

Methods [getShowOutlineIcons](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) 및 [setShowOutlineIcons](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-)은 일반 보기 모드에서 윤곽선 콘텐츠를 표시할 때 아이콘을 표시할지 여부를 지정합니다.

Methods [getSnapVerticalSplitter](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) 및 [setSnapVerticalSplitter](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-)은 측면 영역이 충분히 작아질 경우 수직 분할기가 최소화된 상태로 스냅될지 여부를 지정합니다.

Property [getPreferSingleView](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) 및 [setPreferSingleView](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-)은 사용자가 표준 일반 보기(세 개의 콘텐츠 영역) 대신 전체 창에서 단일 콘텐츠 영역을 선호하는지 여부를 지정합니다. 활성화되면 애플리케이션은 하나의 콘텐츠 영역을 전체 창에 표시할 수 있습니다.

Methods [getVerticalBarState](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) 및 [getHorizontalBarState](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--)은 수평 또는 수직 분할 막대가 표시될 상태를 지정합니다. 수평 분할 바는 슬라이드와 슬라이드 아래의 콘텐츠 영역을 구분하고, 수직 분할 바는 슬라이드와 측면 콘텐츠 영역을 구분합니다. 가능한 값은 [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/ko/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/ko/java/com.aspose.slides/SplitterBarStateType#Maximized) 및 [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ko/java/com.aspose.slides/SplitterBarStateType#Restored)입니다.

Methods [getRestoredLeft](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) 및 [getRestoredTop](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewProperties#getRestoredTop--)은 [getVerticalBarState](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) 및 [getHorizontalBarState](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--)에 [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ko/java/com.aspose.slides/SplitterBarStateType#Restored) 값이 적용될 때 일반 보기의 상단 또는 측면 슬라이드 영역 크기를 지정합니다.

## **INormalViewProperties 복원에 대하여**

일반 보기에서 영역이 가변 복원 크기(최소화도 최대화도 아닌)일 때 슬라이드 영역(복원된 상단의 자식일 경우 너비, 복원된 왼쪽의 자식일 경우 높이)의 크기를 지정합니다.

Method [getDimensionSize](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--)은 슬라이드 영역의 크기(복원된 상단의 자식이면 너비, 복원된 왼쪽의 자식이면 높이)를 지정합니다.

Method [getAutoAdjust](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--)은 창 크기를 조정할 때 측면 콘텐츠 영역의 크기가 새 창 크기에 맞게 보정되어야 하는지를 지정합니다.

아래 예제는 프레젠테이션에 대한 [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) 속성에 어떻게 접근할 수 있는지를 보여줍니다.

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

Aspose.Slides for Java는 이제 프레젠테이션을 열 때 이미 확대/축소 비율이 설정된 기본 확대/축소 값을 지원합니다. 이는 프레젠테이션의 [ViewProperties]를 설정함으로써 수행할 수 있습니다. [getSlideViewProperties]와 [getNotesViewProperties]를 프로그래밍 방식으로 설정할 수 있습니다. 이 항목에서는 [Aspose.Slides](/slides/ko/)에서 [Presentation]의 [View Properties]를 설정하는 방법을 예제와 함께 살펴봅니다.

{{% /alert %}} 

보기 속성을 설정하려면 아래 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation)의 [View Properties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ViewProperties)를 설정합니다.
1. 프레젠테이션을 [PPTX](https://docs.fileformat.com/presentation/pptx/) 파일로 저장합니다.  
   아래 예제에서는 슬라이드 보기와 노트 보기 모두에 대해 확대/축소 값을 설정했습니다.

```java
Presentation presentation = new Presentation();
try {
    // 프레젠테이션의 보기 속성을 설정합니다
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // 슬라이드 보기의 확대 비율(퍼센트) 값
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // 노트 보기의 확대 비율(퍼센트) 값 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**프레젠테이션의 서로 다른 섹션에 대해 다른 보기 설정을 지정할 수 있나요?**  

[View settings](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#getViewProperties--)는 프레젠테이션 수준([Normal View](https://reference.aspose.com/slides/ko/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/ko/java/com.aspose.slides/viewproperties/#getSlideViewProperties--))에서 정의되며 섹션별로 지정되지 않으므로 문서를 열 때 전체 문서에 단일 매개변수 집합이 적용됩니다.

**다른 사용자에게 서로 다른 보기 상태를 미리 정의할 수 있나요?**  

아니요. 설정은 파일에 저장되며 공유됩니다. 뷰어 애플리케이션은 사용자 환경 설정을 따를 수 있지만 파일 자체에는 하나의 보기 속성 집합만 포함됩니다.

**새 프레젠테이션이 동일한 방식으로 열리도록 미리 정의된 View Properties가 포함된 템플릿을 만들 수 있나요?**  

예. [view properties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#getViewProperties--)가 프레젠테이션 수준에 저장되므로 템플릿에 포함시켜 새 문서를 만들 때 동일한 초기 보기 구성을 사용할 수 있습니다.