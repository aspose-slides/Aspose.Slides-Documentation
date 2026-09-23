---
title: Android에서 프레젠테이션 보기 속성 검색 및 업데이트
linktitle: 보기 속성
type: docs
weight: 80
url: /ko/androidjava/presentation-view-properties/
keywords:
- 보기 속성
- 보통 보기
- 개요 콘텐츠
- 개요 아이콘
- 수직 스플리터 스냅
- 단일 보기
- 바 상태
- 차원 크기
- 자동 조정
- 기본 줌
- PowerPoint
- OpenDocument
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java의 보기 속성을 활용하여 PPT, PPTX 및 ODP 슬라이드 형식을 맞춤 설정하고, 레이아웃, 줌 레벨 및 표시 설정을 조정하세요."
---
## **소개**

보통 보기에는 세 개의 콘텐츠 영역이 있습니다: 슬라이드 자체, 측면 콘텐츠 영역, 그리고 하단 콘텐츠 영역. 다양한 콘텐츠 영역의 위치와 관련된 속성입니다. 이 정보는 애플리케이션이 보기 상태를 파일에 저장하도록 하며, 파일을 다시 열면 프레젠테이션이 마지막으로 저장된 상태와 동일한 보기 상태가 됩니다.

Method [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--)가 추가되어 프레젠테이션의 보통 보기 속성에 접근할 수 있게 되었습니다.

[INormalViewProperties](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/INormalViewRestoredProperties) 인터페이스와 그 파생형, [SplitterBarStateType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/SplitterBarStateType) 열거형이 추가되었습니다.

## **INormalViewProperties에 대하여**

보통 보기 속성을 나타냅니다.

Method [getShowOutlineIcons](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--)와 [setShowOutlineIcons](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-)은 보통 보기 모드의 콘텐츠 영역 중 어느 곳에서든 개요 콘텐츠를 표시할 때 아이콘을 표시할지 여부를 지정합니다.

Method [getSnapVerticalSplitter](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--)와 [setSnapVerticalSplitter](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-)은 측면 영역이 충분히 작아질 경우 수직 스플리터가 최소화 상태로 스냅될지 여부를 지정합니다.

Property [getPreferSingleView](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--)와 [setPreferSingleView](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-)은 사용자가 세 개의 콘텐츠 영역이 있는 일반 보기 대신 전체 창에 단일 콘텐츠 영역을 표시하기를 선호하는지 여부를 지정합니다. 이 옵션이 활성화되면 애플리케이션은 하나의 콘텐츠 영역을 전체 창에 표시하도록 선택할 수 있습니다.

Method [getVerticalBarState](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--)와 [getHorizontalBarState](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--)은 수평 또는 수직 스플리터 바가 표시되어야 할 상태를 지정합니다. 수평 스플리터 바는 슬라이드와 슬라이드 아래의 콘텐츠 영역을 구분하고, 수직 스플리터 바는 슬라이드와 측면 콘텐츠 영역을 구분합니다. 가능한 값은 [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) 및 [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/SplitterBarStateType#Restored)입니다.

Method [getRestoredLeft](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)와 [getRestoredTop](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--)은 [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/SplitterBarStateType#Restored)값이 [getVerticalBarState](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--)와 [getHorizontalBarState](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--)에 각각 적용될 때 보통 보기의 측면 또는 상단 슬라이드 영역의 크기를 지정합니다.

## **INormalViewProperties 복원에 대하여**

변수 복원 크기(최소화도 최대화도 아님)인 영역에 대해 보통 보기의 슬라이드 영역(‘getRestoredTop’의 자식이면 너비, ‘getRestoredLeft’의 자식이면 높이)의 크기를 지정합니다.

Method [getDimensionSize](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--)은 복원된 상단 또는 복원된 좌측 영역의 슬라이드 영역 크기(너비 또는 높이)를 지정합니다.

Method [getAutoAdjust](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--)은 창 크기를 조정할 때 측면 콘텐츠 영역의 크기가 새로운 크기에 맞게 보정될지 여부를 지정합니다.

아래 예제는 프레젠테이션에 대해 [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) 속성에 접근하는 방법을 보여줍니다.

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

## **기본 줌 값 설정**

{{% alert color="info" %}} 

Aspose.Slides for Android via Java는 프레젠테이션을 열 때 이미 줌이 설정된 기본 줌 값을 지원합니다. 이는 프레젠테이션의 [ViewProperties](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ViewProperties)를 설정함으로써 수행할 수 있습니다. [getSlideViewProperties](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--)와 [getNotesViewProperties](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--)를 프로그래밍 방식으로 설정할 수 있습니다. 이 항목에서는 Aspose.Slides에서 [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation)의 [View Properties](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ViewProperties)를 설정하는 예제를 보여줍니다.

{{% /alert %}} 

보기 속성을 설정하려면 아래 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation)의 [View Properties](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ViewProperties)를 설정합니다.
1. 프레젠테이션을 [PPTX](https://docs.fileformat.com/presentation/pptx/) 파일로 저장합니다.
   아래 예제에서는 슬라이드 보기와 노트 보기 모두에 줌 값을 설정했습니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // 프레젠테이션의 보기 속성을 설정합니다
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // 슬라이드 보기의 줌 값을 퍼센트 단위로 설정
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // 노트 보기의 줌 값을 퍼센트 단위로 설정

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **그리드 간격 설정**

[Presentation.getViewProperties](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#getViewProperties--)를 사용하여 프레젠테이션 전체의 보기 설정에 접근합니다. [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iviewproperties/#getGridSpacing--)와 [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) 메서드는 기본 편집 그리드의 간격을 읽거나 변경합니다. 이 설정은 개별 슬라이드가 아니라 전체 프레젠테이션에 적용됩니다. 그리드 간격은 포인트 단위이며, 72포인트는 1인치에 해당합니다. API 문서에서 요구하는대로 양수 값을 사용하십시오.

다음 예제는 기존 `demo.pptx`를 열어 현재 그리드 간격을 출력하고, 1/4인치 간격을 설정한 뒤 결과를 저장합니다.

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

그리드는 [drawing guides](/slides/ko/androidjava/drawing-guides/)와 다릅니다. 그리드 간격은 규칙적인 간격을 제어하고, 드로잉 가이드는 개별적으로 배치된 수평 또는 수직 정렬선입니다. 드로잉 가이드를 추가, 이동 또는 삭제해도 그리드 간격은 변경되지 않습니다.

그리드와 드로잉 가이드는 모두 편집 보조 도구이며 PDF, 이미지, SVG 또는 슬라이드 쇼에 슬라이드 콘텐츠로 렌더링되지 않습니다. 그리드 간격을 저장한다고 해서 편집기가 반드시 그리드를 표시한다는 보장은 없으며, 표시 여부는 뷰어나 편집기의 설정에 따라 달라집니다.

## **프레젠테이션을 열 때 주석 표시 여부**

[Presentation.getViewProperties](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#getViewProperties--)를 사용하여 프레젠테이션 전체의 보기 설정에 접근합니다. [IViewProperties.getShowComments](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iviewproperties/#getShowComments--)와 [IViewProperties.setShowComments](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iviewproperties/#setShowComments-byte-)를 사용해 PowerPoint 또는 호환 편집기에서 프레젠테이션을 열 때 주석을 표시할지 여부에 대한 저장된 기본 설정을 읽거나 변경합니다.

이 설정은 저장된 보기 기본 설정만 제어합니다. 주석을 추가, 제거, 편집 또는 해결하지는 않습니다. 주석을 숨겨도 내용, 작성자, 위치, 답글 및 상태는 보존됩니다. 주석 자체를 변경하는 작업은 [Presentation Comments](/slides/ko/androidjava/presentation-comments/)를 참고하십시오.

아래 예제는 주석이 포함된 기존 `comments.pptx` 파일을 대상으로 현재 가시성 설정을 출력하고, 주석을 숨기도록 요청한 뒤 주석을 제거하지 않은 새 PPTX를 저장합니다. 또한 [IViewProperties.setLastView](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iviewproperties/#setLastView-int-)와 [ViewType.SlideView](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/viewtype/#SlideView)를 사용해 초기 편집 보기와 주석 가시성을 함께 구성합니다.

```java
import com.aspose.slides.NullableBool;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ViewType;

Presentation presentation = new Presentation("comments.pptx");
try {
    byte showComments = presentation.getViewProperties().getShowComments();
    System.out.println("Current comment visibility: " + showComments);

    presentation.getViewProperties().setShowComments(NullableBool.False);
    presentation.getViewProperties().setLastView(ViewType.SlideView);
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

이 설정은 PDF, HTML, 이미지, 노트 또는 유인물 내보내기에 주석이 포함되는지를 결정하지 않습니다. 해당 내보내기별 옵션을 별도로 구성하십시오.

## **FAQ**

**프레젠테이션을 다시 열었을 때 그리드가 보이지 않는 이유는?**

파일에 그리드 간격이 저장되지만, 편집기가 그리드 표시 여부를 제어합니다. 편집기의 그리드 가시성 설정을 확인하십시오.

**드로잉 가이드를 삭제하면 그리드 간격이 변경됩니까?**

아니요. 드로잉 가이드와 그리드 간격은 독립적인 설정이며, 가이드를 삭제해도 저장된 그리드 간격은 그대로 유지됩니다.

**프레젠테이션의 섹션별로 다른 보기 설정을 할 수 있나요?**

[View settings](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#getViewProperties--)은 프레젠테이션 수준에서 정의되며([Normal View](/slides/ko/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](/slides/ko/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)), 섹션별이 아니라 전체 문서에 하나의 파라미터 세트가 적용됩니다.

**다른 사용자별로 미리 정의된 보기 상태를 설정할 수 있나요?**

아니요. 설정은 파일에 저장되며 공유됩니다. 뷰어 애플리케이션이 사용자 환경설정을 적용할 수는 있지만 파일 자체에는 하나의 보기 속성 집합만 포함됩니다.

**새 프레젠테이션이 같은 방식으로 열리도록 미리 정의된 View Properties가 포함된 템플릿을 만들 수 있나요?**

예. [view properties](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#getViewProperties--)가 프레젠테이션 수준에 저장되므로 템플릿에 포함시켜 새 문서를 만들 때 동일한 초기 보기 구성을 사용할 수 있습니다.