---
title: Android에서 프레젠테이션 보기 속성 검색 및 업데이트
linktitle: 보기 속성
type: docs
weight: 80
url: /ko/androidjava/presentation-view-properties/
keywords:
- 보기 속성
- 일반 보기
- 개요 내용
- 개요 아이콘
- 세로 스플리터 스냅
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
description: "Aspose.Slides for Android via Java를 사용하여 PowerPoint 프레젠테이션에서 일반 보기 레이아웃, 슬라이드 및 노트 확대/축소, 격자 간격 및 주석 표시 여부를 구성합니다."
---
## **소개**

PowerPoint의 일반 보기에서는 슬라이드가 썸네일 또는 개요용 사이드 창과 아래의 노트 창 사이에 표시됩니다. Aspose.Slides for Android via Java는 프레젠테이션에 저장된 편집 기본 설정을 [Presentation.getViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--)을 통해 노출합니다. 여기에는 창 레이아웃, 확대/축소 수준, 격자 간격 및 주석 표시 여부가 포함됩니다.

## **INormalViewProperties에 대하여**

[getNormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getNormalViewProperties--)를 사용하여 [INormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/) 인터페이스에 접근합니다. [setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-)은 개요에서 슬라이드 제목 옆에 아이콘을 표시할지 여부를 제어합니다. [setSnapVerticalSplitter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setSnapVerticalSplitter-boolean-)은 사용자가 사이드 창을 좁힐 때 해당 창이 최소화 상태로 스냅되도록 합니다. [setPreferSingleView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setPreferSingleView-boolean-)은 전체 창에서 하나의 창만 표시하려는 기본 설정을 나타냅니다.

[setVerticalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setVerticalBarState-int-)은 사이드 창과 슬라이드 사이의 구분자를 제어합니다. [setHorizontalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setHorizontalBarState-int-)은 노트 창 위의 구분자를 제어합니다. 두 메서드 모두 `Minimized`, `Maximized`, `Restored` 값 중 하나를 갖는 [SplitterBarStateType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/splitterbarstatetype/)을 사용합니다.

## **INormalViewProperties 복원에 대하여**

구분자가 복원될 때, [getRestoredLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredLeft--)은 사이드 창의 저장된 크기를 제공하고, [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredTop--)은 상단 슬라이드 영역의 저장된 크기를 제공합니다. 두 메서드는 모두 [INormalViewRestoredProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/)를 노출합니다. 해당 인터페이스의 [setDimensionSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/#setDimensionSize-float-) 메서드는 0에서 100까지의 백분율을 받아들이며, [setAutoAdjust](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/#setAutoAdjust-boolean-)은 창 크기가 조정될 때 편집기가 크기를 자동으로 조정할지 여부를 제어합니다.

이 예제는 기존 프레젠테이션을 업데이트합니다. 가로 구분자를 복원하고, [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredTop--)이 반환하는 크기를 80%로 설정하며 자동 조정을 활성화하고, 세로 구분자를 최대로 확대합니다. 또한 [setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-)을 호출하여 개요 보기에서 아이콘을 표시합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    INormalViewProperties normalView = presentation.getViewProperties().getNormalViewProperties();
    normalView.setHorizontalBarState(SplitterBarStateType.Restored);
    normalView.setVerticalBarState(SplitterBarStateType.Maximized);
    normalView.getRestoredTop().setAutoAdjust(true);
    normalView.getRestoredTop().setDimensionSize(80);
    normalView.setShowOutlineIcons(true);

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **기본 확대/축소 값 설정**

[getSlideViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getSlideViewProperties--)와 [getNotesViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getNotesViewProperties--)는 편집기별 독립적인 확대/축소 설정을 저장합니다. 이러한 설정은 슬라이드 크기, 슬라이드 쇼 재생 또는 이미지 내보내기 해상도에 영향을 주지 않습니다.

이 예제는 기존 프레젠테이션을 열고 [setVariableScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommonslideviewproperties/#setVariableScale-boolean-)을 호출하여 슬라이드를 편집 창에 맞춥니다. 노트 페이지에 대해서는 자동 스케일링을 비활성화하고 [setScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommonslideviewproperties/#setScale-int-)을 호출하여 고정 80% 확대/축소를 설정합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    viewProperties.getSlideViewProperties().setVariableScale(true);
    viewProperties.getNotesViewProperties().setVariableScale(false);
    viewProperties.getNotesViewProperties().setScale(80);

    presentation.save("zoom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **격자 간격 설정**

[setGridSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-)은 프레젠테이션 전체에서 편집 격자선 사이의 거리를 설정합니다. 이 메서드는 인치당 72포인트인 양의 포인트 값을 받습니다. 이 예제는 기존 프레젠테이션에서 현재 간격을 출력하고, 간격을 18포인트(¼인치)로 설정하여 ¼인치 격자를 저장합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    System.out.println("Current grid spacing: " + viewProperties.getGridSpacing() + " points");

    viewProperties.setGridSpacing(18f);

    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

격자는 고정된 간격으로 반복됩니다. [Drawing guides](/slides/ko/androidjava/drawing-guides/)는 개별 가로 또는 세로 위치를 표시합니다. 두 기능 모두 편집 보조 도구이며 해당 기능을 표시하는 편집기에서만 나타납니다. 슬라이드 쇼와 PDF, 이미지, SVG와 같은 내보내기에는 포함되지 않습니다.

## **프레젠테이션 열 때 주석 표시/숨기기**

[setShowComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setShowComments-byte-)은 호환 편집기가 프레젠테이션을 열 때 사용할 기본 설정을 저장합니다. 주석이 포함된 기존 프레젠테이션에 대해 이 예제는 현재 설정을 출력하고 주석이 숨겨진 사본을 저장합니다. 또한 [setLastView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setLastView-int-)을 [ViewType.SlideView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewtype/#SlideView)와 함께 호출하여 사본이 슬라이드 보기로 열리도록 합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("comments.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    System.out.println("Current comment visibility: " + viewProperties.getShowComments());

    viewProperties.setShowComments(NullableBool.False);
    viewProperties.setLastView(ViewType.SlideView);

    presentation.save("comments-hidden.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

주석을 숨겨도 텍스트, 작성자, 위치, 답글 및 상태는 유지됩니다. 주석 자체를 변경하려면 [Presentation Comments](/slides/ko/androidjava/presentation-comments/)를 참고하십시오. 내보내기 설정은 PDF, HTML, 이미지, 노트 또는 유인물에 주석이 표시되는지를 제어합니다.

## **FAQ**

**프레젠테이션을 다시 열었을 때 격자가 숨겨지는 이유는?**

프레젠테이션은 격자 간격을 저장합니다. 격자를 보려면 편집기에서 격자 표시를 활성화하십시오.

**그리기 가이드를 삭제하면 격자 간격이 변경되나요?**

아니오. 가이드를 추가, 이동 또는 삭제해도 격자 간격은 변하지 않습니다.

**프레젠테이션의 서로 다른 섹션에 서로 다른 보기 설정을 적용할 수 있나요?**

아니오. [Presentation.getViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--)는 전체 프레젠테이션에 적용됩니다.

**다른 사용자별로 다른 보기 설정을 저장할 수 있나요?**

파일에는 모든 사용자를 위한 하나의 보기 속성 집합만 저장됩니다. 편집기는 사용자의 로컬 기본 설정을 추가로 적용할 수 있습니다.

**템플릿에 보기 설정을 저장할 수 있나요?**

네. 템플릿에서 만든 프레젠테이션은 해당 템플릿에 저장된 보기 설정을 상속합니다.