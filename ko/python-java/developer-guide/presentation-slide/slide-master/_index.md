---
title: Python via Java에서 프레젠테이션 슬라이드 마스터 관리
linktitle: 슬라이드 마스터
type: docs
weight: 70
url: /ko/python-java/slide-master/
keywords:
- 슬라이드 마스터
- 마스터 슬라이드
- PPT 마스터 슬라이드
- 다중 마스터 슬라이드
- 마스터 슬라이드 비교
- 배경
- 플레이스홀더
- 마스터 슬라이드 복제
- 마스터 슬라이드 복사
- 마스터 슬라이드 중복
- 사용되지 않는 마스터 슬라이드
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java에서 슬라이드 마스터를 관리합니다: PowerPoint 및 OpenDocument 프레젠테이션의 마스터 슬라이드를 접근, 편집, 복제, 비교 및 제거합니다."
---
## **개요**

**슬라이드 마스터**는 슬라이드 그룹에 대한 공통 디자인 설정을 정의합니다. 여기에는 일반적인 도형, 로고, 배경, 텍스트 스타일, 테마 설정 및 바닥글 설정이 포함될 수 있습니다. PowerPoint에서 슬라이드 마스터를 편집하는 것이 프레젠테이션의 일관성을 유지하고 각 슬라이드마다 동일한 형식을 반복하지 않는 일반적인 방법입니다.

Aspose.Slides for Python via Java도 동일한 모델을 지원합니다. 프레젠테이션에는 하나 이상의 마스터 슬라이드가 포함될 수 있으며, 각 마스터 슬라이드에는 여러 레이아웃 슬라이드가 포함될 수 있습니다. 일반 슬라이드는 직접 마스터 슬라이드를 참조하지 않습니다. 대신 일반 슬라이드는 레이아웃 슬라이드를 사용하고, 해당 레이아웃 슬라이드는 마스터 슬라이드에 속합니다.

계층 구조는 다음과 같습니다:

1. **슬라이드 마스터** – 공유 디자인 및 테마를 정의합니다.  
2. **레이아웃 슬라이드** – 플레이스홀더와 레이아웃 수준 서식을 특정 방식으로 배치합니다.  
3. **일반 슬라이드** – 실제 프레젠테이션 내용을 포함하고 하나의 레이아웃 슬라이드를 사용합니다.

![마스터 슬라이드, 레이아웃 슬라이드 및 일반 슬라이드의 계층 구조](slide-master_2.jpg)

Aspose.Slides에서 슬라이드 마스터는 [MasterSlide](https://reference.aspose.com/slides/ko/python-java/aspose.slides/masterslide/) 클래스로 나타냅니다. 프레젠테이션의 모든 마스터 슬라이드는 [Presentation.getMasters](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getMasters) 컬렉션을 통해 사용할 수 있으며, 이는 [MasterSlideCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/masterslidecollection/)으로 표현됩니다.

{{% alert color="info" title="Inheritance" %}}
동일한 속성이 둘 이상의 수준에서 정의된 경우, 더 구체적인 수준이 우선합니다. 예를 들어, 마스터 슬라이드와 레이아웃 슬라이드가 모두 배경을 정의한 경우, 해당 레이아웃을 기반으로 하는 슬라이드는 레이아웃 배경을 사용합니다. 레이아웃 슬라이드에 대한 자세한 내용은 [Apply or Change Slide Layouts](/slides/ko/python-java/slide-layout/)를 참조하십시오.
{{% /alert %}}

## **슬라이드 마스터 액세스**

PowerPoint에서는 **View** > **Slide Master**에서 슬라이드 마스터 보기를 열 수 있습니다.

![PowerPoint 보기 탭의 슬라이드 마스터 명령](slide-master_3.jpg)

Aspose.Slides에서는 [Presentation.getMasters](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getMasters) 컬렉션을 사용하여 마스터 슬라이드에 접근합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    first_master_slide = presentation.getMasters().get_Item(0)
    master_slide_count = presentation.getMasters().size()
    first_master_layout_slide_count = first_master_slide.getLayoutSlides().size()

    print(f"Master slides: {master_slide_count}")
    print(f"Layouts in the first master: {first_master_layout_slide_count}")
finally:
    presentation.dispose()
```

또한 일반 슬라이드의 레이아웃을 통해 해당 슬라이드가 사용하고 있는 마스터 슬라이드를 얻을 수 있습니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    layout_slide = slide.getLayoutSlide()
    master_slide = layout_slide.getMasterSlide()
    master_slide_name = master_slide.getName()

    print(master_slide_name)
finally:
    presentation.dispose()
```

## **슬라이드 마스터에 포함된 내용**

마스터 슬라이드는 슬라이드와 유사한 객체입니다. [BaseSlide](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseslide/)을 상속받아 일반 슬라이드와 레이아웃 슬라이드에서 사용되는 많은 슬라이드 속성을 제공합니다. 마스터 전용 멤버는 [MasterSlide](https://reference.aspose.com/slides/ko/python-java/aspose.slides/masterslide/) API 페이지에 나열되어 있습니다.

주요 마스터 슬라이드 멤버는 다음과 같습니다:

| 멤버 | 목적 |
| --- | --- |
| [getBackground](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseslide/#getBackground) | 마스터 수준 슬라이드 배경을 설정합니다. |
| [getShapes](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseslide/#getShapes) | 로고, 사진 프레임 및 공유 텍스트와 같이 마스터에 배치된 도형을 저장합니다. |
| [getLayoutSlides](https://reference.aspose.com/slides/ko/python-java/aspose.slides/masterslide/#getLayoutSlides) | 마스터에 속하는 레이아웃 슬라이드를 저장합니다. |
| [getThemeManager](https://reference.aspose.com/slides/ko/python-java/aspose.slides/masterslide/#getThemeManager) | 마스터 테마 API에 대한 접근을 제공합니다. |
| [getHeaderFooterManager](https://reference.aspose.com/slides/ko/python-java/aspose.slides/masterslide/#getHeaderFooterManager) | 마스터와 그 하위 레이아웃의 머리글, 바닥글, 날짜 및 슬라이드 번호를 제어합니다. |
| [getDependingSlides](https://reference.aspose.com/slides/ko/python-java/aspose.slides/masterslide/#getDependingSlides) | 레이아웃을 통해 마스터에 종속된 일반 슬라이드를 반환합니다. |

## **슬라이드 마스터에 이미지 추가**

마스터 슬라이드에 이미지를 추가하면 해당 마스터의 레이아웃을 사용하는 모든 슬라이드에 표시됩니다. 로고, 워터마크, 장식 밴드 및 기타 반복되는 시각 요소에 유용합니다.

다음 예제는 첫 번째 마스터 슬라이드에 로고를 추가합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    logo = Images.fromFile("logo.png")
    try:
        logo_image = presentation.getImages().addImage(logo)
        master_slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 80, 80, logo_image)
    finally:
        logo.dispose()

    presentation.save("presentation-with-logo.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

사진 프레임에 대한 자세한 내용은 [Picture Frame](/slides/ko/python-java/picture-frame/)를 참조하십시오.

## **플레이스홀더 작업**

플레이스홀더는 일반적으로 레이아웃 슬라이드에 정의됩니다. 마스터 슬라이드는 해당 레이아웃이 상속받는 공유 스타일과 테마를 제공하고, 각 레이아웃은 어떤 플레이스홀더를 사용할지와 그 위치를 결정합니다.

PowerPoint에서는 슬라이드 마스터 보기에서 플레이스홀더 명령을 사용할 수 있습니다.

![PowerPoint 슬라이드 마스터 보기의 플레이스홀더 삽입 명령](slide-master_5.png)

Aspose.Slides에서 새 플레이스홀더를 추가하려면, 해당 마스터에 속하는 레이아웃 슬라이드와 작업하십시오:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    blank_layout_slide = master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if blank_layout_slide is None:
        blank_layout_slide = master_slide.getLayoutSlides().add(SlideLayoutType.Blank, "Blank")

    blank_layout_slide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80)

    presentation.getSlides().addEmptySlide(blank_layout_slide)
    presentation.save("presentation-with-placeholder.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

이미 마스터 슬라이드에 존재하는 플레이스홀더 도형을 서식 지정할 수도 있습니다. 다음 예제는 제목 플레이스홀더를 찾아 선형 그라디언트 채우기를 적용합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, FillType, GradientShape, PlaceholderType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    title_placeholder = None

    for shape in master_slide.getShapes():
        if isinstance(shape, AutoShape):
            if shape.getPlaceholder() is not None and shape.getPlaceholder().getType() == PlaceholderType.Title:
                title_placeholder = shape
                break

    if title_placeholder is not None:
        red_gradient_color = Color(255, 0, 0)
        purple_gradient_color = Color(128, 0, 128)

        title_placeholder.getFillFormat().setFillType(FillType.Gradient)
        title_placeholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)
        title_placeholder.getFillFormat().getGradientFormat().getGradientStops().add(jpype.JFloat(0.0), red_gradient_color)
        title_placeholder.getFillFormat().getGradientFormat().getGradientStops().add(jpype.JFloat(1.0), purple_gradient_color)

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![일반 슬라이드에 상속된 서식이 적용된 제목 플레이스홀더](slide-master_8.png)

플레이스홀더 및 텍스트 서식 옵션에 대한 자세한 내용은 [Set Prompt Text in Placeholder](/slides/ko/python-java/manage-placeholder/)와 [Text Formatting](/slides/ko/python-java/text-formatting/)를 참조하십시오.

## **슬라이드 마스터 배경 변경**

마스터 배경은 레이아웃 및 해당 배경을 재정의하지 않은 슬라이드에 상속됩니다. 다음 예제는 첫 번째 마스터 슬라이드에 단색 배경 색을 설정합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    master_background_color = Color.GREEN

    master_slide.getBackground().setType(BackgroundType.OwnBackground)
    master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(master_background_color)

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

관련 주제는 [Presentation Background](/slides/ko/python-java/presentation-background/)와 [Presentation Theme](/slides/ko/python-java/presentation-theme/)를 참조하십시오.

## **슬라이드 마스터를 다른 프레젠테이션에 복제**

[MasterSlideCollection.addClone](https://reference.aspose.com/slides/ko/python-java/aspose.slides/masterslidecollection/#addClone) 메서드를 사용하여 마스터 슬라이드를 다른 프레젠테이션에 복사할 수 있습니다. 복사된 마스터는 대상 프레젠테이션의 레이아웃 및 슬라이드에서 사용할 수 있습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source_presentation = Presentation("source.pptx")
destination_presentation = Presentation("destination.pptx")
try:
    source_master_slide = source_presentation.getMasters().get_Item(0)
    cloned_master_slide = destination_presentation.getMasters().addClone(source_master_slide)

    destination_presentation.save("destination-with-master.pptx", SaveFormat.Pptx)
finally:
    source_presentation.dispose()
    destination_presentation.dispose()
```

마스터와 함께 일반 슬라이드를 복제해야 하는 경우에는 [Clone Slides](/slides/ko/python-java/clone-slides/)를 참조하십시오.

## **여러 슬라이드 마스터 추가**

프레젠테이션에는 여러 마스터 슬라이드가 포함될 수 있습니다. 이는 섹션마다 다른 브랜딩, 페이지 구조 또는 테마 설정이 필요할 때 유용합니다.

![마스터 슬라이드 삽입 및 관리용 PowerPoint 명령](slide-master_9.jpg)

다음 예제는 기본 마스터를 복제하고, 복제본에 다른 배경을 지정한 뒤, 해당 복제 마스터 아래에 레이아웃을 만들고, 그 레이아웃을 기반으로 새 슬라이드를 추가합니다:

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, SlideLayoutType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    section_master_slide = presentation.getMasters().addClone(default_master_slide)
    section_master_background_color = Color.LIGHT_GRAY

    section_master_slide.getBackground().setType(BackgroundType.OwnBackground)
    section_master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    section_master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(section_master_background_color)

    source_blank_layout = default_master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)
    if source_blank_layout is None:
        source_blank_layout = default_master_slide.getLayoutSlides().get_Item(0)

    section_blank_layout = section_master_slide.getLayoutSlides().addClone(source_blank_layout)

    presentation.getSlides().addEmptySlide(section_blank_layout)
    presentation.save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **슬라이드 마스터 비교**

마스터 슬라이드는 [BaseSlide](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseslide/)에서 상속된 [equals](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseslide/#equals) 메서드를 사용하여 비교할 수 있습니다. 비교는 도형, 텍스트, 서식, 애니메이션 및 기타 슬라이드 설정과 같은 구조와 정적 콘텐츠를 확인합니다. 슬라이드 ID와 같은 고유 식별자나 현재 날짜와 같은 동적 플레이스홀더 값은 비교되지 않습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

first_presentation = Presentation("first.pptx")
second_presentation = Presentation("second.pptx")
try:
    first_presentation_master_count = first_presentation.getMasters().size()
    second_presentation_master_count = second_presentation.getMasters().size()

    for first_master_index in range(first_presentation_master_count):
        for second_master_index in range(second_presentation_master_count):
            first_master_slide = first_presentation.getMasters().get_Item(first_master_index)
            second_master_slide = second_presentation.getMasters().get_Item(second_master_index)
            are_master_slides_equal = first_master_slide.equals(second_master_slide)

            if are_master_slides_equal:
                print(f"first.pptx master #{first_master_index} equals second.pptx master #{second_master_index}")
finally:
    first_presentation.dispose()
    second_presentation.dispose()
```

자세한 내용은 [Compare Presentation Slides](/slides/ko/python-java/compare-slides/)를 확인하십시오.

## **슬라이드 마스터 보기를 기본 보기로 설정**

[ViewProperties](https://reference.aspose.com/slides/ko/python-java/aspose.slides/viewproperties/)의 [setLastView](https://reference.aspose.com/slides/ko/python-java/aspose.slides/viewproperties/#setLastView) 메서드를 사용하여 PowerPoint가 처음 열 때 표시할 보기를 제어할 수 있습니다. 다음 예제는 프레젠테이션을 슬라이드 마스터 보기로 엽니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ViewType

presentation = Presentation("presentation.pptx")
try:
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView)
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

다른 보기 설정에 대한 내용은 [Save Presentation](/slides/ko/python-java/save-presentation/)를 참조하십시오.

## **사용되지 않는 마스터 슬라이드 제거**

프레젠테이션에 더 이상 일반 슬라이드에서 사용되지 않는 마스터 슬라이드가 포함될 수 있습니다. 사용되지 않는 마스터를 제거하면 파일 크기를 줄이고 템플릿 유지 관리가 간소화됩니다.

[Presentation.getMasters](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getMasters) 컬렉션에서 [removeUnused](https://reference.aspose.com/slides/ko/python-java/aspose.slides/masterslidecollection/#removeUnused) 메서드를 사용하여 사용되지 않는 마스터를 제거합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.getMasters().removeUnused(True)
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

또한 저코드 [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/ko/python-java/aspose.slides/compress/#removeUnusedMasterSlides) 메서드를 사용할 수 있습니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    Compress.removeUnusedMasterSlides(presentation)
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**슬라이드 마스터와 레이아웃 슬라이드의 차이점은 무엇인가요?**  
슬라이드 마스터는 테마, 배경, 공통 도형 및 텍스트 스타일과 같은 공유 디자인 설정을 정의합니다. 레이아웃 슬라이드는 마스터 슬라이드에 속하며 플레이스홀더의 구체적인 배치를 정의합니다. 일반 슬라이드는 레이아웃 슬라이드를 사용하므로 레이아웃과 마스터 모두로부터 상속받습니다.

**하나의 프레젠테이션에 여러 슬라이드 마스터를 포함할 수 있나요?**  
예. 프레젠테이션에 여러 슬라이드 마스터를 포함할 수 있습니다. 섹션마다 다른 시각적 시스템이나 브랜딩이 필요할 때 여러 마스터를 사용하십시오.

**플레이스홀더는 마스터 슬라이드에 추가해야 하나요, 레이아웃 슬라이드에 추가해야 하나요?**  
대부분의 경우 레이아웃 슬라이드에 플레이스홀더를 추가합니다. 공유 시각 요소와 공통 서식은 마스터 슬라이드에 두고, 실제 콘텐츠 플레이스홀더는 일반 슬라이드가 사용할 레이아웃에 배치합니다.

**사용 중인 마스터 슬라이드를 삭제할 수 있나요?**  
아니요. 종속 슬라이드가 있는 마스터 슬라이드는 직접 삭제할 수 없습니다. 먼저 해당 슬라이드를 다른 마스터의 레이아웃으로 이동하거나, 사용되지 않은 마스터만 제거하는 정리 방법을 사용하십시오.