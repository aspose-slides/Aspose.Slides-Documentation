---
title: Android에서 프레젠테이션의 그리기 가이드 관리
linktitle: 그리기 가이드
type: docs
weight: 85
url: /ko/androidjava/drawing-guides/
keywords:
- 그리기 가이드
- 가로 가이드
- 세로 가이드
- 정렬 가이드
- 슬라이드 보기
- 마스터 슬라이드
- 레이아웃 슬라이드
- 노트 마스터
- 유인물 마스터
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java를 사용하여 PowerPoint 프레젠테이션에서 가로 및 세로 그리기 가이드를 추가, 액세스 및 제거합니다."
---
## **개요**

그리기 가이드는 PowerPoint에서 프레젠테이션을 편집하는 동안 사용자가 도형을 일관되게 정렬할 수 있도록 도와주는 조절 가능한 가로 및 세로 선입니다. 이러한 가이드는 애플리케이션이 프레젠테이션을 생성하고 나중에 수동으로 다듬을 때 특히 유용합니다. 애플리케이션은 저자가 콘텐츠를 추가하거나 이동할 때 따라야 하는 동일한 정렬 보조 도구를 저장할 수 있습니다.

그리기 가이드는 편집 보조 도구이며 슬라이드 콘텐츠가 아닙니다. 슬라이드 쇼나 렌더링된 출력에 나타나지 않습니다. Aspose.Slides for Android via Java는 이를 [IDrawingGuidesCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/idrawingguidescollection/) 인터페이스를 통해 노출합니다. 가이드는 [IDrawingGuide](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/idrawingguide/) 로 표현되며 방향, 위치 및 색상을 가집니다.

위치는 해당 슬라이드 또는 마스터의 왼쪽 위 모서리에서부터 포인트 단위로 측정됩니다. 세로 가이드는 가로 좌표를 사용하며 일반적으로 0과 슬라이드 너비 사이에 위치합니다. 가로 가이드는 세로 좌표를 사용하며 일반적으로 0과 슬라이드 높이 사이에 위치합니다.

## **슬라이드 보기에서 가이드 추가**

일반 슬라이드를 편집하는 동안 표시되는 가이드를 관리하려면 [ICommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/icommonslideviewproperties/#getDrawingGuides--) 를 사용합니다. Orientation 값과 포인트 단위 위치를 지정하여 [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/idrawingguidescollection/#add-byte-float-) 를 호출합니다.

다음 예제는 슬라이드 중심 오른쪽에 세로 가이드 하나와 그 아래에 가로 가이드 하나를 추가합니다:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(Orientation.Vertical, slideSize.getWidth() / 2 + 12.5f);
    guides.add(Orientation.Horizontal, slideSize.getHeight() / 2 + 12.5f);

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **그리기 가이드 액세스**

[IDrawingGuidesCollection.getCount](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/idrawingguidescollection/#getCount--) 및 [IDrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/idrawingguidescollection/#get_Item-int-) 메서드는 기존 가이드에 대한 접근을 제공합니다. [IDrawingGuide.getOrientation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/idrawingguide/#getOrientation--), [IDrawingGuide.getPosition](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/idrawingguide/#getPosition--), 및 [IDrawingGuide.getColor](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/idrawingguide/#getColor--) 메서드는 값을 반환하며 해당 setter 메서드를 통해 변경할 수 있습니다.

다음 예제는 위에서 만든 프레젠테이션에서 슬라이드‑뷰 가이드를 읽어옵니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("drawing-guides.pptx");
try {
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    for (int index = 0; index < guides.getCount(); index++) {
        IDrawingGuide guide = guides.get_Item(index);
        System.out.println("Guide " + index + ": orientation = " + guide.getOrientation() + ", position = " + guide.getPosition() + ", color = " + guide.getColor());
    }
} finally {
    presentation.dispose();
}
```

## **마스터 및 레이아웃 슬라이드에 가이드 추가**

슬라이드 마스터와 각 레이아웃 슬라이드는 자체 그리기‑가이드 컬렉션을 가질 수 있습니다. 마스터 슬라이드에는 [IMasterSlide.getDrawingGuides](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imasterslide/#getDrawingGuides--) 를, 레이아웃 슬라이드에는 [ILayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ilayoutslide/#getDrawingGuides--) 를 사용합니다.

다음 예제는 첫 번째 마스터 슬라이드에 세로 가이드 하나와 첫 번째 레이아웃 슬라이드에 가로 가이드 하나를 추가합니다:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    IDrawingGuidesCollection layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(Orientation.Vertical, slideSize.getWidth() / 2 - 20);
    layoutGuides.add(Orientation.Horizontal, slideSize.getHeight() / 2 + 20);

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **노트 및 유인물 마스터에 가이드 추가**

노트 마스터와 유인물 마스터 역시 그리기 가이드를 지원합니다. [IMasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imasternotesslide/#getDrawingGuides--) 및 [IMasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imasterhandoutslide/#getDrawingGuides--) 를 사용하여 해당 컬렉션에 접근합니다. 프레젠테이션에 이러한 마스터가 포함돼 있지 않다면 [IMasterNotesSlideManager.setDefaultMasterNotesSlide](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imasternotesslidemanager/#setDefaultMasterNotesSlide--) 또는 [IMasterHandoutSlideManager.setDefaultMasterHandoutSlide](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) 가 기본 마스터를 생성하고 반환합니다.

다음 예제는 노트 마스터에 가로 가이드 하나와 유인물 마스터에 세로 가이드 하나를 추가합니다:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF notesSize = presentation.getNotesSize().getSize();
    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(Orientation.Horizontal, notesSize.getHeight() / 2 + 50);
    handoutMaster.getDrawingGuides().add(Orientation.Vertical, notesSize.getWidth() / 2 - 50);

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **그리기 가이드 제거**

특정 컬렉션의 모든 가이드를 제거하려면 [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/idrawingguidescollection/#clear--) 를 호출합니다. 하나의 컬렉션을 비우는 것이 다른 범위에 저장된 가이드에 영향을 주지는 않습니다.

다음 예제는 슬라이드‑뷰 가이드와 슬라이드 마스터, 레이아웃 슬라이드, 노트 마스터, 유인물 마스터에 있는 모든 가이드를 누락된 마스터를 생성하지 않고 제거합니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation-with-guides.pptx");
try {
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear();

    for (IMasterSlide masterSlide : presentation.getMasters()) {
        masterSlide.getDrawingGuides().clear();
    }

    for (ILayoutSlide layoutSlide : presentation.getLayoutSlides()) {
        layoutSlide.getDrawingGuides().clear();
    }

    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        notesMaster.getDrawingGuides().clear();
    }

    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();
    if (handoutMaster != null) {
        handoutMaster.getDrawingGuides().clear();
    }

    presentation.save("presentation-without-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**그리기 가이드는 슬라이드 쇼나 내보낸 이미지에 나타나요?**

아니요. 그리기 가이드는 편집용 정렬 보조 도구이며 프레젠테이션 콘텐츠로 렌더링되지 않습니다.

**그리기 가이드를 개별 일반 슬라이드에 직접 추가할 수 있나요?**

일반 슬라이드 편집 가이드는 프레젠테이션의 슬라이드‑뷰 속성에 저장됩니다. 슬라이드 마스터, 레이아웃 슬라이드, 노트 마스터 및 유인물 마스터용 별도의 가이드 컬렉션이 제공됩니다.

**가이드 위치에 어떤 단위가 사용되나요?**

위치는 포인트 단위로 지정되며, 72 포인트가 1인치에 해당합니다. 세로 위치는 왼쪽 가장자리에서, 가로 위치는 위쪽 가장자리에서 측정됩니다.

**그리기 가이드를 제거하면 도형이 사라지거나 슬라이드 내용이 바뀌나요?**

아니요. [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/idrawingguidescollection/#clear--) 메서드는 선택된 컬렉션의 가이드만 제거합니다. 도형 및 기타 슬라이드 콘텐츠는 변경되지 않습니다.