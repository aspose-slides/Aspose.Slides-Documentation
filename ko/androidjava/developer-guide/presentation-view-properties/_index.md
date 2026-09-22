---
title: Android에서 프레젠테이션 보기 속성 검색 및 업데이트
linktitle: 보기 속성
type: docs
weight: 80
url: /ko/androidjava/presentation-view-properties/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java의 보기 속성을 활용하여 PPT, PPTX 및 ODP 슬라이드 형식을 사용자 정의하고, 레이아웃, 확대/축소 수준 및 표시 설정을 조정하십시오."
---
## **Introduction**

일반 보기에는 세 개의 콘텐츠 영역이 있습니다: 슬라이드 자체, 측면 콘텐츠 영역, 그리고 하단 콘텐츠 영역. 서로 다른 콘텐츠 영역의 위치와 관련된 속성입니다. 이 정보는 애플리케이션이 보기 상태를 파일에 저장하도록 하여, 파일을 다시 열었을 때 프레젠테이션이 마지막으로 저장된 시점과 동일한 상태로 보이게 합니다.

Method [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) 가 추가되어 프레젠테이션의 일반 보기 속성에 접근할 수 있게 되었습니다. 

[INormalViewProperties](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/INormalViewRestoredProperties) 인터페이스와 그 파생형, [SplitterBarStateType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/SplitterBarStateType) 열거형이 추가되었습니다.

## **About INormalViewProperties**

일반 보기 속성을 나타냅니다.

Methods [getShowOutlineIcons](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) and [setShowOutlineIcons](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) 은 일반 보기 모드의 어느 콘텐츠 영역에서든 개요 콘텐츠를 표시할 때 아이콘을 보여줄지 여부를 지정합니다.

Methods [getSnapVerticalSplitter](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) and [setSnapVerticalSplitter](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) 은 측면 영역이 충분히 작아졌을 때 수직 스플리터가 최소화 상태에 스냅될지 여부를 지정합니다.

Property [getPreferSingleView](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) and [setPreferSingleView](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) 은 사용자가 세 개의 콘텐츠 영역이 있는 표준 일반 보기보다 전체 창 단일 콘텐츠 영역을 선호하는지 여부를 지정합니다. 이 옵션이 활성화되면 애플리케이션은 하나의 콘텐츠 영역을 전체 창에 표시하도록 선택할 수 있습니다.

Methods [getVerticalBarState](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) and [getHorizontalBarState](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) 은 수평 또는 수직 스플리터 바가 표시될 상태를 지정합니다. 수평 스플리터 바는 슬라이드를 슬라이드 아래의 콘텐츠 영역과 구분하고, 수직 스플리터 바는 슬라이드를 측면 콘텐츠 영역과 구분합니다. 가능한 값은 [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) 및 [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/SplitterBarStateType#Restored) 입니다.

Methods [getRestoredLeft](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) and [getRestoredTop](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) 은 [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/SplitterBarStateType#Restored) 값이 [getVerticalBarState](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) 및 [getHorizontalBarState](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) 에 적용될 때 일반 보기의 상단 또는 측면 슬라이드 영역 크기를 지정합니다.

## **About Restoring INormalViewProperties**

일반 보기에서 영역이 가변적인 복원 크기(최소화도 아니고 최대화도 아님)일 때 슬라이드 영역의 크기(복원된 상단의 자식이면 너비, 복원된 좌측의 자식이면 높이)를 지정합니다.

Method [getDimensionSize](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) 은 슬라이드 영역의 크기(복원된 Top의 자식이면 너비, 복원된 Left의 자식이면 높이)를 지정합니다.

Method [getAutoAdjust](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) 은 창 크기를 조정할 때 측면 콘텐츠 영역의 크기가 새 창 크기에 맞게 보상되어야 하는지를 지정합니다.

아래 예제는 프레젠테이션에 대해 [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) 속성에 어떻게 접근할 수 있는지 보여 줍니다.

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

## **Set the Default Zoom Value**

{{% alert color="info" %}} 

Aspose.Slides for Android via Java 는 이제 프레젠테이션을 열 때 기본 확대/축소 값을 미리 설정할 수 있습니다. 이는 프레젠테이션의 [ViewProperties] 를 설정함으로써 수행할 수 있습니다. [getSlideViewProperties] 와 [getNotesViewProperties] 도 프로그래밍 방식으로 설정할 수 있습니다. 이 문서에서는 Aspose.Slides에서 [Presentation] 의 [View Properties] 를 설정하는 방법을 예제로 보여 줍니다.

{{% /alert %}} 

뷰 속성을 설정하려면 아래 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation) 의 [View Properties](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ViewProperties) 를 설정합니다.
1. 프레젠테이션을 [PPTX](https://docs.fileformat.com/presentation/pptx/) 파일로 저장합니다.  
   아래 예제에서는 슬라이드 뷰와 노트 뷰 모두에 대한 확대/축소 값을 설정했습니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // 프레젠테이션의 보기 속성을 설정합니다
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // 슬라이드 보기의 확대/축소 값을 백분율로 지정
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // 노트 보기의 확대/축소 값을 백분율로 지정 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Set the Grid Spacing**

[Presentation.getViewProperties](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#getViewProperties--) 를 사용하여 프레젠테이션 전체에 적용되는 보기 설정에 접근합니다. [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iviewproperties/#getGridSpacing--) 와 [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) 메서드는 기본 편집 격자의 간격을 읽거나 변경합니다. 이 설정은 개별 슬라이드가 아니라 전체 프레젠테이션에 적용됩니다. 격자 간격은 포인트 단위이며, 72 포인트가 1인치에 해당합니다. API 문서에서 요구하는 대로 양수 값을 사용하십시오.

다음 예제는 기존 `demo.pptx` 파일을 열어 현재 격자 간격을 출력하고, 1/4인치 간격으로 설정한 뒤 결과를 저장합니다.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("demo.pptx");
try {
    float gridSpacing = presentation.getViewProperties().getGridSpacing();
    System.out.println("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18f);
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

격자는 [drawing guides](/slides/ko/androidjava/drawing-guides/) 와 다릅니다. 격자 간격은 규칙적인 간격을 제어하고, 그리기 가이드는 개별적으로 위치가 지정된 수평 또는 수직 정렬선입니다. 그리기 가이드를 추가, 이동 또는 제거해도 격자 간격은 변하지 않습니다.

격자와 그리기 가이드는 모두 편집 보조 도구이며 PDF, 이미지, SVG 또는 슬라이드 쇼에 슬라이드 콘텐츠로 렌더링되지 않습니다. 격자 간격을 저장한다고 해서 모든 편집기가 격자를 표시한다는 보장은 없으며, 격자 표시 여부는 뷰어나 편집기의 설정에 따라 달라집니다.

## **FAQ**

**프레젠테이션을 다시 열었을 때 격자가 보이지 않는 이유는?**

파일에 격자 간격이 저장되지만, 격자를 표시할지는 편집기가 제어합니다. 편집기의 격자 표시 설정을 확인하십시오.

**그리기 가이드를 제거하면 격자 간격이 바뀌나요?**

아니요. 그리기 가이드와 격자 간격은 독립적인 설정입니다. 가이드를 제거해도 저장된 격자 간격은 그대로 유지됩니다.

**프레젠테이션의 서로 다른 섹션마다 다른 보기 설정을 지정할 수 있나요?**

[View settings](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#getViewProperties--) 은 프레젠테이션 수준(일반 보기/슬라이드 보기)에서 정의되며 섹션별로는 정의되지 않으므로, 문서가 열릴 때 전체 문서에 동일한 파라미터 집합이 적용됩니다.

**다른 사용자마다 미리 정의된 다른 보기 상태를 지정할 수 있나요?**

아니요. 설정은 파일에 하나의 보기 속성 집합만 저장되며 공유됩니다. 뷰어 애플리케이션이 사용자 환경 설정을 따를 수는 있지만 파일 자체에는 하나의 보기 속성만 포함됩니다.

**템플릿에 미리 정의된 View Properties 를 포함시켜 새 프레젠테이션이 동일한 방식으로 열리게 할 수 있나요?**

예. [view properties](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#getViewProperties--) 가 프레젠테이션 수준에 저장되므로 템플릿에 포함시키면 해당 템플릿을 기반으로 만든 새 문서도 동일한 초기 보기 구성을 갖게 됩니다.