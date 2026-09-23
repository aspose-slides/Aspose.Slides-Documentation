---
title: Java에서 프레젠테이션 보기 속성 검색 및 업데이트
linktitle: 보기 속성
type: docs
weight: 80
url: /ko/java/presentation-view-properties/
keywords:
- 보기 속성
- 일반 보기
- 개요 내용
- 개요 아이콘
- 수직 스냅 분할기
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
description: "Aspose.Slides for Java의 보기 속성을 활용해 PPT, PPTX 및 ODP 슬라이드 형식을 사용자 지정하고—레이아웃, 확대/축소 수준 및 표시 설정을 조정하세요."
---
## **소개**

일반 보기(normal view)는 슬라이드 자체, 측면 콘텐츠 영역, 하단 콘텐츠 영역의 세 개 영역으로 구성됩니다. 다양한 콘텐츠 영역의 위치와 관련된 속성입니다. 이 정보는 애플리케이션이 보기 상태를 파일에 저장하도록 하여, 다시 열었을 때 프레젠테이션이 마지막으로 저장된 시점과 동일한 상태로 표시됩니다.

Method [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) 가 추가되어 프레젠테이션의 일반 보기 속성에 접근할 수 있게 되었습니다.  

[INormalViewProperties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewRestoredProperties) 인터페이스와 해당 하위 항목, [SplitterBarStateType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/SplitterBarStateType) 열거형이 추가되었습니다.

## **INormalViewProperties에 대하여**

일반 보기 속성을 나타냅니다.

Methods [getShowOutlineIcons](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--)와 [setShowOutlineIcons](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) 은 일반 보기 모드에서 개요 콘텐츠를 표시할 때 아이콘을 표시할지 여부를 지정합니다.

Methods [getSnapVerticalSplitter](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--)와 [setSnapVerticalSplitter](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) 은 측면 영역이 충분히 작아질 때 수직 분할기가 최소화된 상태로 고정될지 여부를 지정합니다.

Property [getPreferSingleView](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--)와 [setPreferSingleView](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) 은 사용자가 세 개 영역이 있는 기본 일반 보기보다 전체 창에 단일 콘텐츠 영역을 표시하는 것을 선호하는지 여부를 지정합니다. 활성화된 경우 애플리케이션은 하나의 콘텐츠 영역을 전체 창에 표시할 수 있습니다.

Methods [getVerticalBarState](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--)와 [getHorizontalBarState](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) 은 수평 또는 수직 분할 막대가 어떤 상태로 표시되어야 하는지를 지정합니다. 수평 분할 막대는 슬라이드와 슬라이드 아래 콘텐츠 영역을 구분하고, 수직 분할 막대는 슬라이드와 측면 콘텐츠 영역을 구분합니다. 가능한 값은 [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/ko/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/ko/java/com.aspose.slides/SplitterBarStateType#Maximized) 및 [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ko/java/com.aspose.slides/SplitterBarStateType#Restored) 입니다.

Methods [getRestoredLeft](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)와 [getRestoredTop](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) 은 [SplitterBarStateType.Restored](https://reference.aspose.com/slides/ko/java/com.aspose.slides/SplitterBarStateType#Restored) 값이 각각 [getVerticalBarState](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--)와 [getHorizontalBarState](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) 에 적용될 때 일반 보기의 상단 또는 측면 슬라이드 영역의 크기를 지정합니다.

## **INormalViewProperties 복원에 대하여**

변수 복원 크기(최소화도, 최대화도 아님)인 영역에 대해 일반 보기의 슬라이드 영역(복원된 상단의 경우 너비, 복원된 좌측의 경우 높이) 크기를 지정합니다.

Method [getDimensionSize](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) 은 복원된 상단의 자식인 경우 너비, 복원된 좌측의 자식인 경우 높이로 슬라이드 영역 크기를 지정합니다.

Method [getAutoAdjust](https://reference.aspose.com/slides/ko/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) 은 창 크기가 조정될 때 측면 콘텐츠 영역의 크기가 새로운 크기에 맞게 보정되어야 하는지 여부를 지정합니다.

아래 예제는 프레젠테이션에 대한 [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) 속성에 어떻게 접근할 수 있는지를 보여줍니다.

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

Aspose.Slides for Java는 이제 프레젠테이션을 열면 확대/축소가 이미 설정된 상태가 되도록 기본 확대/축소 값을 지정하는 것을 지원합니다. 이는 프레젠테이션의 [ViewProperties]를 설정함으로써 수행할 수 있습니다. [getSlideViewProperties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ViewProperties#getSlideViewProperties--)와 [getNotesViewProperties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ViewProperties#getNotesViewProperties--)도 프로그래밍 방식으로 설정할 수 있습니다. 이 항목에서는 Aspose.Slides에서 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation)의 [View Properties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ViewProperties)를 설정하는 방법을 예제로 살펴봅니다.

{{% /alert %}} 

보기 속성을 설정하려면 아래 단계를 따르세요.

1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation)의 View Properties를 설정합니다.
1. 프레젠테이션을 [PPTX](https://docs.fileformat.com/presentation/pptx/) 파일로 저장합니다.
   아래 예제에서는 슬라이드 보기와 노트 보기 모두에 확대/축소 값을 설정했습니다.

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

## **그리드 간격 설정**

[Presentation.getViewProperties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#getViewProperties--) 를 사용하여 프레젠테이션 전체의 보기 설정에 접근합니다. [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iviewproperties/#getGridSpacing--) 및 [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) 메서드는 기본 편집 그리드의 간격을 읽거나 변경합니다. 이 설정은 개별 슬라이드가 아니라 전체 프레젠테이션에 적용됩니다. 그리드 간격은 포인트 단위이며, 72포인트가 1인치에 해당합니다. API 문서에 명시된 대로 양수 값을 사용하세요.

다음 예제는 기존 `demo.pptx` 파일을 열어 현재 그리드 간격을 출력하고, 1/4인치 간격으로 설정한 뒤 결과를 저장합니다.

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

그리드는 [drawing guides](/slides/ko/java/drawing-guides/)와 다릅니다. 그리드 간격은 규칙적인 간격을 제어하고, drawing guides는 개별적으로 배치된 수평 또는 수직 정렬선입니다. drawing guides를 추가, 이동 또는 삭제해도 그리드 간격은 변경되지 않습니다.

그리드와 drawing guides 모두 편집 보조 도구이며 PDF, 이미지, SVG 또는 슬라이드 쇼에 슬라이드 콘텐츠로 렌더링되지 않습니다. 그리드 간격을 저장한다고 해서 편집기가 반드시 그리드를 표시한다는 보장은 없으며, 표시 여부는 뷰어 또는 편집기의 설정에 따라 달라집니다.

## **프레젠테이션 열 때 의견 표시 또는 숨기기**

[Presentation.getViewProperties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#getViewProperties--) 를 사용하여 프레젠테이션 전체의 보기 설정에 접근합니다. [IViewProperties.getShowComments](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iviewproperties/#getShowComments--) 및 [IViewProperties.setShowComments](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iviewproperties/#setShowComments-byte-) 를 사용해 프레젠테이션이 PowerPoint 또는 호환 편집기에서 열릴 때 의견을 표시할지 여부에 대한 저장된 기본 설정을 읽거나 변경합니다.

이 설정은 저장된 보기 기본 설정만 제어합니다. 의견을 추가, 제거, 편집 또는 해결하지는 않습니다. 의견을 숨겨도 내용, 작성자, 위치, 답글 및 상태는 유지됩니다. 의견 자체를 변경하는 작업은 [Presentation Comments](/slides/ko/java/presentation-comments/)를 참고하세요.

다음 예제는 의견이 포함된 기존 `comments.pptx` 파일이 필요합니다. 현재 가시성 설정을 출력하고, 의견을 숨기도록 요청한 뒤 의견을 제거하지 않은 새로운 PPTX 파일을 저장합니다. 또한 [IViewProperties.setLastView](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iviewproperties/#setLastView-int-) 와 [ViewType.SlideView](https://reference.aspose.com/slides/ko/java/com.aspose.slides/viewtype/#SlideView) 를 사용해 의견 가시성과 함께 초기 편집 보기를 구성합니다.

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

이 설정은 PDF, HTML, 이미지, 노트 또는 유인물 내보내기 시 의견이 포함되는지를 결정하지 않습니다. 해당 내보내기 옵션을 별도로 구성하세요.

## **FAQ**

**그리드를 다시 열었을 때 보이지 않는 이유는 무엇입니까?**  
파일에 그리드 간격이 저장되지만, 편집기가 그리드 표시 여부를 제어합니다. 편집기의 그리드 표시 설정을 확인하세요.

**drawing guides를 삭제하면 그리드 간격이 바뀝니까?**  
아니요. drawing guides와 그리드 간격은 독립적인 설정이며, guides를 삭제해도 저장된 그리드 간격은 변경되지 않습니다.

**프레젠테이션의 다른 섹션에 대해 다른 보기 설정을 지정할 수 있습니까?**  
[View settings](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#getViewProperties--) 은 프레젠테이션 수준([Normal View](https://reference.aspose.com/slides/ko/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/ko/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)) 에 정의되며 섹션별이 아닙니다. 따라서 파일이 열릴 때 전체 문서에 동일한 매개변수가 적용됩니다.

**다른 사용자마다 다른 보기 상태를 미리 정의할 수 있습니까?**  
아니요. 설정은 파일에 저장되며 공유됩니다. 뷰어 애플리케이션이 사용자 선호를 반영할 수는 있지만 파일 자체에는 하나의 보기 속성 집합만 포함됩니다.

**템플릿에 미리 정의된 View Properties를 포함시켜 새 프레젠테이션이 동일한 방식으로 열리게 할 수 있습니까?**  
예. [view properties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#getViewProperties--) 가 프레젠테이션 수준에 저장되므로 템플릿에 포함시켜 새 문서를 만들 때 동일한 초기 보기 구성을 사용할 수 있습니다.