---
title: Java에서 프레젠테이션의 그리기 가이드 관리
linktitle: 그리기 가이드
type: docs
weight: 85
url: /ko/java/drawing-guides/
keywords:
- 그리기 가이드
- 수평 가이드
- 수직 가이드
- 정렬 가이드
- 슬라이드 보기
- 마스터 슬라이드
- 레이아웃 슬라이드
- 노트 마스터
- 유인물 마스터
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 PowerPoint 프레젠테이션에서 수평 및 수직 그리기 가이드를 추가, 액세스 및 삭제합니다."
---
## **개요**

그리기 가이드는 조정 가능한 수평 및 수직선으로, PowerPoint에서 프레젠테이션을 편집하는 동안 사용자가 도형을 일관되게 정렬하도록 도와줍니다. 특히 애플리케이션이 프레젠테이션을 생성하고 나중에 수동으로 다듬을 때 유용합니다. 애플리케이션은 작성자가 내용 추가 또는 이동 시 따라야 할 동일한 정렬 도구를 저장할 수 있습니다.

그리기 가이드는 편집 보조 도구이며 슬라이드 콘텐츠가 아닙니다. 슬라이드 쇼나 렌더링된 출력에 표시되지 않습니다. Aspose.Slides for Java는 이를 [IDrawingGuidesCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/idrawingguidescollection/) 인터페이스를 통해 노출합니다. 가이드는 [IDrawingGuide](https://reference.aspose.com/slides/ko/java/com.aspose.slides/idrawingguide/) 로 표현되며 방향, 위치 및 색상을 가집니다.

위치는 해당 슬라이드 또는 마스터의 좌상단 모서리에서 포인트 단위로 측정됩니다. 수직 가이드는 일반적으로 0에서 슬라이드 너비 사이의 수평 좌표를 사용합니다. 수평 가이드는 일반적으로 0에서 슬라이드 높이 사이의 수직 좌표를 사용합니다.

## **슬라이드 보기에서 가이드 추가**

일반 슬라이드를 편집하는 동안 표시되는 가이드를 관리하려면 [ICommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/ko/java/com.aspose.slides/icommonslideviewproperties/#getDrawingGuides--)를 사용합니다. [Orientation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/orientation/) 값과 포인트 단위 위치를 사용하여 [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/ko/java/com.aspose.slides/idrawingguidescollection/#add-byte-float-)를 호출합니다.

다음 예제는 슬라이드 중앙 오른쪽에 수직 가이드 하나와 그 아래에 수평 가이드 하나를 추가합니다:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(Orientation.Vertical, (float) (slideSize.getWidth() / 2 + 12.5));
    guides.add(Orientation.Horizontal, (float) (slideSize.getHeight() / 2 + 12.5));

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **그리기 가이드에 액세스**

[IDrawingGuidesCollection.getCount](https://reference.aspose.com/slides/ko/java/com.aspose.slides/idrawingguidescollection/#getCount--) 및 [IDrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/ko/java/com.aspose.slides/idrawingguidescollection/#get_Item-int-) 메서드는 기존 가이드에 대한 액세스를 제공합니다. [IDrawingGuide.getOrientation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/idrawingguide/#getOrientation--), [IDrawingGuide.getPosition](https://reference.aspose.com/slides/ko/java/com.aspose.slides/idrawingguide/#getPosition--), 및 [IDrawingGuide.getColor](https://reference.aspose.com/slides/ko/java/com.aspose.slides/idrawingguide/#getColor--) 메서드는 해당 값을 반환하며, 해당 setter 메서드를 통해 변경할 수도 있습니다.

다음 예제는 위에서 만든 프레젠테이션의 슬라이드 보기 가이드를 읽습니다:

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

슬라이드 마스터와 각 레이아웃 슬라이드마다 자체 그리기 가이드 컬렉션을 가질 수 있습니다. 마스터 슬라이드의 경우 [IMasterSlide.getDrawingGuides](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imasterslide/#getDrawingGuides--)를 사용하고, 레이아웃 슬라이드의 경우 [ILayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ilayoutslide/#getDrawingGuides--)를 사용합니다.

다음 예제는 첫 번째 마스터 슬라이드에 수직 가이드 하나와 첫 번째 레이아웃 슬라이드에 수평 가이드 하나를 추가합니다:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    IDrawingGuidesCollection layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(Orientation.Vertical, (float) (slideSize.getWidth() / 2 - 20));
    layoutGuides.add(Orientation.Horizontal, (float) (slideSize.getHeight() / 2 + 20));

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **노트 및 유인물 마스터에 가이드 추가**

노트 마스터와 유인물 마스터도 그리기 가이드를 지원합니다. 해당 컬렉션에 접근하려면 [IMasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imasternotesslide/#getDrawingGuides--) 및 [IMasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imasterhandoutslide/#getDrawingGuides--)를 사용합니다. 프레젠테이션에 이러한 마스터 중 하나가 포함되어 있지 않은 경우, [IMasterNotesSlideManager.setDefaultMasterNotesSlide](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imasternotesslidemanager/#setDefaultMasterNotesSlide--) 또는 [IMasterHandoutSlideManager.setDefaultMasterHandoutSlide](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--)가 기본 마스터를 생성하고 반환합니다.

다음 예제는 노트 마스터에 수평 가이드 하나와 유인물 마스터에 수직 가이드 하나를 추가합니다:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D notesSize = presentation.getNotesSize().getSize();
    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(Orientation.Horizontal, (float) (notesSize.getHeight() / 2 + 50));
    handoutMaster.getDrawingGuides().add(Orientation.Vertical, (float) (notesSize.getWidth() / 2 - 50));

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **그리기 가이드 삭제**

[IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/ko/java/com.aspose.slides/idrawingguidescollection/#clear--)를 호출하면 특정 컬렉션의 모든 가이드를 제거합니다. 하나의 컬렉션을 삭제해도 다른 범위에 저장된 가이드에는 영향을 주지 않습니다.

다음 예제는 누락된 마스터를 생성하지 않고 슬라이드 보기 가이드와 슬라이드 마스터, 레이아웃 슬라이드, 노트 마스터 및 유인물 마스터에 있는 모든 가이드를 삭제합니다:

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

## **자주 묻는 질문**

**그리기 가이드는 슬라이드 쇼나 내보낸 이미지에 표시됩니까?**

아니오. 그리기 가이드는 편집을 위한 정렬 보조 도구이며 프레젠테이션 콘텐츠로 렌더링되지 않습니다.

**그리기 가이드를 개별 일반 슬라이드에 직접 추가할 수 있나요?**

일반 슬라이드 편집 가이는 프레젠테이션의 슬라이드 보기 속성에 저장됩니다. 슬라이드 마스터, 레이아웃 슬라이드, 노트 마스터 및 유인물 마스터에 대한 별도의 가이드 컬렉션이 제공됩니다.

**가이드 위치에 사용되는 단위는 무엇인가요?**

위치는 포인트 단위로 지정되며, 72 포인트는 1인치에 해당합니다. 수직 위치는 왼쪽 가장자리에서 측정되고, 수평 위치는 위쪽 가장자리에서 측정됩니다.

**그리기 가이드를 삭제하면 도형이 제거되거나 슬라이드 내용이 변경됩니까?**

아니오. [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/ko/java/com.aspose.slides/idrawingguidescollection/#clear--) 메서드는 선택한 컬렉션의 가이드만 삭제합니다. 도형 및 기타 슬라이드 콘텐츠는 변경되지 않은 채로 유지됩니다.