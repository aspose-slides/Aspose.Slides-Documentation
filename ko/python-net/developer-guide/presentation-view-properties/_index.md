---
title: Python에서 프레젠테이션 보기 속성 검색 및 업데이트
linktitle: 보기 속성
type: docs
weight: 80
url: /ko/python-net/presentation-view-properties/
keywords: 
- 보기 속성
- 일반 보기
- 개요 내용
- 개요 아이콘
- 수직 분할선 스냅
- 단일 보기
- 막대 상태
- 차원 크기
- 자동 조정
- 기본 확대/축소
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 프레젠테이션의 일반 보기 레이아웃, 슬라이드 및 노트 확대/축소, 그리드 간격 및 주석 표시 여부를 구성합니다."
---
## **소개**

PowerPoint의 일반 보기에서는 슬라이드가 썸네일 또는 개요용 측면 창과 아래쪽 노트 창 사이에 표시됩니다. Aspose.Slides for Python via .NET은 [Presentation.view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/)를 통해 프레젠테이션에 저장된 편집 환경 설정을 노출합니다. 여기에는 창 레이아웃, 확대/축소 수준, 그리드 간격 및 주석 표시 여부가 포함됩니다.

## **NormalViewProperties에 대하여**

[normal_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/normal_view_properties/)를 사용하여 [NormalViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/) 객체에 접근합니다. [show_outline_icons](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/show_outline_icons/)는 개요에서 슬라이드 제목 옆에 아이콘이 표시될지를 제어합니다. [snap_vertical_splitter](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/snap_vertical_splitter/)는 사용자가 측면 창을 좁게 할 때 창이 최소화 상태로 스냅하도록 합니다. [prefer_single_view](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/prefer_single_view/)는 전체 창에서 하나의 창만 표시하려는 기본 설정을 나타냅니다.

[vertical_bar_state](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/vertical_bar_state/)는 측면 창과 슬라이드 사이의 구분자를 제어합니다. [horizontal_bar_state](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/horizontal_bar_state/)는 노트 창 위의 구분자를 제어합니다. 두 속성 모두 `MINIMIZED`, `MAXIMIZED`, `RESTORED` 중 하나의 [SplitterBarStateType](https://reference.aspose.com/slides/python-net/aspose.slides/splitterbarstatetype/) 값을 허용합니다.

<!-- visual-explanation:presentation-view-properties:start -->
[![컨셉 편집기가 측면 패널, 슬라이드 영역 및 하단 영역을 라벨이 붙은 수직 및 수평 분할선으로 구분합니다.](visual-presentation-view-properties-40ae1765a743.svg)](visual-presentation-view-properties-40ae1765a743.svg)

*일반 보기에서 수직 구분자는 측면 창의 너비를 제어하고, 수평 구분자는 노트 창 위의 공간을 제어합니다.*
<!-- visual-explanation:presentation-view-properties:end -->

## **NormalViewProperties 복원에 대하여**

구분자가 복원될 때, [restored_left](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_left/)는 측면 창의 저장된 크기를 제공하고 [restored_top](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_top/)는 상단 슬라이드 영역의 저장된 크기를 제공합니다. 두 속성 모두 [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/)를 노출합니다. 그 중 [dimension_size](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/dimension_size/) 속성은 0에서 100까지의 백분율을 허용하며, [auto_adjust](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/auto_adjust/)는 창 크기가 조정될 때 편집기가 크기를 자동으로 조정할지 여부를 제어합니다.

이 예제는 기존 프레젠테이션을 업데이트합니다. 수평 구분자를 복원하고, [restored_top](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_top/)을 자동 조정이 활성화된 80%로 설정하며, 수직 구분자를 최대화합니다. 또한 개요 보기에서 [show_outline_icons](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/show_outline_icons/)를 활성화합니다.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    normal_view = presentation.view_properties.normal_view_properties
    normal_view.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    normal_view.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED
    normal_view.restored_top.auto_adjust = True
    normal_view.restored_top.dimension_size = 80
    normal_view.show_outline_icons = True

    presentation.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **기본 확대/축소 값 설정**

[slide_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/slide_view_properties/)와 [notes_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/notes_view_properties/)는 편집기용 독립적인 확대/축소 설정을 저장합니다. 이러한 설정은 슬라이드 크기, 슬라이드쇼 재생 또는 이미지 내보내기 해상도에 영향을 미치지 않습니다.

이 예제는 기존 프레젠테이션을 열고 [variable_scale](https://reference.aspose.com/slides/python-net/aspose.slides/commonslideviewproperties/variable_scale/)을 활성화하여 슬라이드를 편집 창에 맞춥니다. 노트 페이지에서는 자동 스케일을 비활성화하고 [scale](https://reference.aspose.com/slides/python-net/aspose.slides/commonslideviewproperties/scale/)을 고정된 80% 확대/축소로 설정합니다.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    view_properties = presentation.view_properties
    view_properties.slide_view_properties.variable_scale = True
    view_properties.notes_view_properties.variable_scale = False
    view_properties.notes_view_properties.scale = 80

    presentation.save("zoom.pptx", slides.export.SaveFormat.PPTX)
```

## **그리드 간격 설정**

[grid_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/grid_spacing/)은 프레젠테이션 전체의 편집 그리드 라인 사이 간격을 설정합니다. 인치당 72포인트인 양의 값을 사용합니다. 이 예제는 기존 프레젠테이션에서 현재 간격을 출력하고, 간격을 18포인트(¼인치)로 설정하여 저장합니다.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    view_properties = presentation.view_properties
    print(f"Current grid spacing: {view_properties.grid_spacing} points")

    view_properties.grid_spacing = 18.0

    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

그리드는 일정 간격으로 반복됩니다. [Drawing guides](/slides/ko/python-net/drawing-guides/)는 개별 수평 또는 수직 위치를 표시합니다. 두 기능 모두 편집 보조 도구이며 이를 표시하는 편집기에서만 나타납니다. 슬라이드 쇼 및 PDF, 이미지, SVG로 내보낼 때는 포함되지 않습니다.

## **프레젠테이션 열 때 주석 보이기 또는 숨기기**

[show_comments](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/show_comments/)는 호환 가능한 편집기가 프레젠테이션을 열 때 사용할 기본 설정을 저장합니다. 주석이 포함된 기존 프레젠테이션에 대해 이 예제는 현재 설정을 출력하고 주석이 숨겨진 사본을 저장합니다. 또한 [last_view](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/last_view/)를 [ViewType.SLIDE_VIEW](https://reference.aspose.com/slides/python-net/aspose.slides/viewtype/)로 설정하여 사본이 슬라이드 보기로 열리도록 합니다.

```py
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    view_properties = presentation.view_properties
    print(f"Current comment visibility: {view_properties.show_comments}")

    view_properties.show_comments = slides.NullableBool.FALSE
    view_properties.last_view = slides.ViewType.SLIDE_VIEW
    
    presentation.save("comments-hidden.pptx", slides.export.SaveFormat.PPTX)
```

주석을 숨겨도 텍스트, 작성자, 위치, 답글 및 상태는 보존됩니다. 주석 자체를 변경하려면 [Presentation Comments](/slides/ko/python-net/presentation-comments/)를 참고하십시오. 내보내기 설정은 PDF, HTML, 이미지, 노트 또는 유인물에 주석을 표시할지를 제어합니다.

## **FAQ**

**프레젠테이션을 다시 열었을 때 그리드가 숨겨지는 이유는 무엇인가요?**  
프레젠테이션은 그리드 간격을 저장합니다. 그리드를 보려면 편집기에서 그리드 표시를 활성화하십시오.

**그리기 가이드를 삭제해도 그리드 간격이 변경되나요?**  
아니오. 가이드를 추가, 이동 또는 삭제해도 그리드 간격은 변하지 않습니다.

**프레젠테이션의 다른 섹션마다 다른 보기 설정을 가질 수 있나요?**  
아니오. [Presentation.view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/)는 전체 프레젠테이션에 적용됩니다.

**사용자마다 다른 보기 설정을 저장할 수 있나요?**  
파일은 모든 사용자를 위한 하나의 보기 속성 집합만을 저장합니다. 편집기는 사용자의 로컬 기본 설정을 별도로 적용할 수 있습니다.

**템플릿에 보기 설정을 저장할 수 있나요?**  
예. 템플릿에서 만든 프레젠테이션은 해당 템플릿에 저장된 보기 설정을 상속합니다.