---
title: Python에서 프레젠테이션 플레이스홀더 관리
linktitle: 플레이스홀더 관리
type: docs
weight: 10
url: /ko/python-java/manage-placeholder/
keywords:
- 플레이스홀더
- 텍스트 플레이스홀더
- 이미지 플레이스홀더
- 차트 플레이스홀더
- 콘텐츠 플레이스홀더
- 프롬프트 텍스트
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 텍스트, 그림, 차트 및 콘텐츠 플레이스홀더를 검사하고 편집하는 방법과 플레이스홀더 상속을 이해하는 방법을 배웁니다."
---
## **개요**

플레이스홀더는 프레젠테이션 템플릿에서 특정 유형의 콘텐츠가 들어갈 위치를 예약하는 도형입니다. 일반적인 예로는 제목, 본문, 그림, 차트 및 범용 콘텐츠 플레이스홀더가 있습니다. 일반 도형과 달리 플레이스홀더는 레이아웃 슬라이드 또는 마스터 슬라이드로부터 위치, 크기, 서식 및 기타 설정을 상속받을 수 있습니다.

Aspose.Slides는 플레이스홀더 정보를 [Shape.getPlaceholder](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getPlaceholder) 메서드를 통해 노출합니다. 이 메서드는 일반 도형의 경우 `None`을 반환하고, [Placeholder](https://reference.aspose.com/slides/ko/python-java/aspose.slides/placeholder/) 객체를 반환합니다. 플레이스홀더가 어떤 콘텐츠를 담도록 설계되었는지는 [Placeholder.getType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/placeholder/#getType)으로 확인하십시오.

플레이스홀더 유형을 알게 된 후에도 도형 유형은 여전히 중요합니다:

- 빈 텍스트, 그림, 차트 또는 콘텐츠 플레이스홀더는 일반적으로 [AutoShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/autoshape/) 로 표시됩니다.
- 내용이 채워진 그림 플레이스홀더는 [PictureFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pictureframe/) 로 표시될 수 있습니다.
- 내용이 채워진 차트 플레이스홀더는 [Chart](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chart/) 로 표시될 수 있습니다.
- 콘텐츠 플레이스홀더는 여러 종류의 콘텐츠를 포함할 수 있습니다. 모든 플레이스홀더가 [AutoShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/autoshape/) 라고 가정하지 말고 [Placeholder.getType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/placeholder/#getType)과 런타임 도형 유형을 모두 확인하십시오.

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/placeholder/#getType) 은 플레이스홀더의 역할을 설명하지만, 도형의 런타임 유형을 보장하지는 않습니다. 텍스트, 그림, 차트, 표 또는 미디어와 관련된 멤버에 접근하기 전에 항상 유형 검사를 수행하십시오.
{{% /alert %}}

## **플레이스홀더 상속 이해**

플레이스홀더는 계층 구조를 가집니다:

1. 마스터 슬라이드는 재사용 가능한 스타일을 정의하고 경우에 따라 마스터 수준의 플레이스홀더를 포함합니다.
2. 레이아웃 슬라이드는 하나 이상의 일반 슬라이드가 사용하는 배치를 정의하며 마스터로부터 상속받을 수 있습니다.
3. 일반 슬라이드는 해당 슬라이드의 플레이스홀더를 포함하고 레이아웃으로부터 상속받을 수 있습니다.

[Shape.getBasePlaceholder](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getBasePlaceholder) 메서드를 호출하면 이 계층 구조에서 한 단계 위로 이동합니다. 슬라이드 플레이스홀더는 일반적으로 레이아웃 플레이스홀더를 반환하고, 레이아웃 플레이스홀더는 마스터 플레이스홀더를 반환합니다. 도형에 기본 플레이스홀더가 없으면 메서드는 `None`을 반환합니다.

다음 예제는 첫 번째 슬라이드의 플레이스홀더를 나열하고 해당 기본 플레이스홀더를 보고합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        type_name = shape.getClass().getSimpleName()
        print(f"Slide placeholder: {placeholder_type}; shape type: {type_name}")

        layout_placeholder = shape.getBasePlaceholder()
        if layout_placeholder is not None:
            layout_placeholder_info = layout_placeholder.getPlaceholder()
            layout_placeholder_type = None if layout_placeholder_info is None else layout_placeholder_info.getType()
            print(f"  Layout placeholder: {layout_placeholder_type}")

            master_placeholder = layout_placeholder.getBasePlaceholder()
            if master_placeholder is not None:
                master_placeholder_info = master_placeholder.getPlaceholder()
                master_placeholder_type = None if master_placeholder_info is None else master_placeholder_info.getType()
                print(f"  Master placeholder: {master_placeholder_type}")
finally:
    presentation.dispose()
```

일반 슬라이드에서 플레이스홀더를 편집하면 해당 슬라이드에 대한 로컬 오버라이드가 생성되거나 변경됩니다. 관련 레이아웃이나 마스터를 편집하면 해당 설정을 아직 상속받고 있는 모든 슬라이드에 영향을 줄 수 있습니다. 로컬 일반 도형은 기본 플레이스홀더가 없으며 동일한 좌표에 있더라도 상속을 시작하지 않습니다.

## **플레이스홀더 텍스트 변경**

제목, 중앙제목, 부제목, 본문 및 텍스트 플레이스홀더는 일반적으로 텍스트를 지원합니다. [AutoShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/autoshape/) 인지 확인한 뒤 [getTextFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/autoshape/#getTextFrame) 메서드를 사용하십시오.

다음 예제는 첫 번째 슬라이드의 첫 번째 제목 플레이스홀더를 업데이트하고 결과를 저장합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PlaceholderType, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    title_shape = None

    for shape in slide.getShapes():
        if not isinstance(shape, AutoShape):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle):
            title_shape = shape
            break

    if title_shape is None:
        print("The first slide does not contain a title placeholder.")
    else:
        title_shape.getTextFrame().setText("Quarterly Business Review")
        presentation.save("title-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

이 패턴은 그림, 차트, 표 또는 미디어 플레이스홀더를 [AutoShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/autoshape/) 로 취급하지 않도록 방지합니다. 또한 깨지기 쉬운 도형 인덱스에 의존하지 않고 목적에 따라 플레이스홀더를 식별합니다.

## **레이아웃에 프롬프트 텍스트 설정**

프롬프트 텍스트는 빈 플레이스홀더에 표시되는 디자인 타임 지시문으로, 예를 들어 *Click to add title* 과 같습니다. 일반 슬라이드의 도형 컬렉션을 통해 접근하려고 시도하기보다 레이아웃 플레이스홀더에 사용자 정의 프롬프트 텍스트를 설정하십시오. [Slide.getLayoutSlide](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slide/#getLayoutSlide) 로 레이아웃에 접근하고, [BaseSlide.getShapes](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseslide/#getShapes) 로 반환된 컬렉션을 순회하십시오.

다음 예제는 첫 번째 슬라이드가 사용하는 레이아웃의 제목 및 부제목 프롬프트를 변경합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PlaceholderType, SaveFormat

presentation = Presentation("template.pptx")
try:
    layout_slide = presentation.getSlides().get_Item(0).getLayoutSlide()

    for shape in layout_slide.getShapes():
        if not isinstance(shape, AutoShape):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle):
            shape.getTextFrame().setText("Enter a concise slide title")
        elif placeholder_type == PlaceholderType.Subtitle:
            shape.getTextFrame().setText("Enter a subtitle or reporting period")

    presentation.save("custom-placeholder-prompts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

프롬프트 텍스트는 일반 슬라이드 콘텐츠가 아닙니다. PowerPoint와 같은 편집 애플리케이션에서 빈 플레이스홀더에만 표시됩니다. 사용자가 실제 콘텐츠를 제공하면 프롬프트는 더 이상 표시되지 않으며, 프롬프트를 변경해도 해당 레이아웃을 사용하는 슬라이드의 기존 텍스트를 대체하지 않습니다.

## **그림 플레이스홀더 업데이트**

다음 두 경우를 처리해야 합니다:

- 그림 플레이스홀더가 이미 채워져 있고 [PictureFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pictureframe/) 로 표시되는 경우, [PictureFillFormat.getPicture](https://reference.aspose.com/slides/ko/python-java/aspose.slides/picturefillformat/#getPicture) 와 [Picture.setImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/picture/#setImage) 로 이미지를 교체합니다.
- 아직 빈 플레이스홀더인 경우, [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/#addPictureFrame) 으로 플레이스홀더 좌표에 그림 프레임을 추가하고 빈 플레이스홀더를 제거합니다.

다음 예제는 두 경우 모두를 지원하고 프레젠테이션을 저장합니다:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PictureFrame, PlaceholderType, ShapeType, SaveFormat

presentation = Presentation("picture-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_placeholder = None

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is not None and placeholder.getType() == PlaceholderType.Picture:
            picture_placeholder = shape
            break

    if picture_placeholder is None:
        print("The first slide does not contain a picture placeholder.")
    else:
        image_bytes = Path("replacement.png").read_bytes()
        java_image_bytes = jpype.JArray(jpype.JByte)(image_bytes)
        image = presentation.getImages().addImage(java_image_bytes)

        if isinstance(picture_placeholder, PictureFrame):
            picture_placeholder.getPictureFormat().getPicture().setImage(image)
        else:
            slide.getShapes().addPictureFrame(ShapeType.Rectangle, picture_placeholder.getX(), picture_placeholder.getY(), picture_placeholder.getWidth(), picture_placeholder.getHeight(), image)
            slide.getShapes().remove(picture_placeholder)

        presentation.save("picture-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

빈 플레이스홀더에 대해 생성된 교체물은 새로운 플레이스홀더가 아닌 로컬 그림 프레임이며, [Shape.getPlaceholder](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getPlaceholder) 에는 setter가 없기 때문에 자리만 예약하고 플레이스홀더 전용 동작은 상속되지 않습니다. 플레이스홀더 관계를 유지해야 한다면 먼저 PowerPoint에서 플레이스홀더를 준비해 채운 뒤 Aspose.Slides 로 결과 [PictureFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pictureframe/) 을 업데이트하십시오.

이미지 투명도, 크롭 및 기타 그림 전용 효과에 대해서는 [Manage Picture Frames](/slides/ko/python-java/picture-frame/) 를 참조하십시오. 이러한 작업은 그림 프레임 또는 그림 채우기에 해당하며, 플레이스홀더 메타데이터와는 별개입니다.

## **차트 및 콘텐츠 플레이스홀더 작업**

채워진 차트 플레이스홀더는 [Chart](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chart/) 로 표시될 수 있습니다. 이 예제는 플레이스홀더 유형과 런타임 유형을 모두 확인하여 차트를 찾고, 제목을 변경한 뒤 파일을 저장합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Chart, PlaceholderType, SaveFormat

presentation = Presentation("chart-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    placeholder_chart = None

    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is not None and placeholder.getType() == PlaceholderType.Chart:
            placeholder_chart = shape
            break

    if placeholder_chart is None:
        print("The first slide does not contain a populated chart placeholder.")
    else:
        placeholder_chart.setTitle(True)
        placeholder_chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue")
        presentation.save("chart-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

일반 콘텐츠 플레이스홀더는 보통 [PlaceholderType.Object](https://reference.aspose.com/slides/ko/python-java/aspose.slides/placeholdertype/#Object) 를 갖습니다. PowerPoint에서 이 플레이스홀더는 차트, 표, 다이어그램, 그림 및 미디어 등 여러 콘텐츠 유형을 시작하는 런처 역할을 합니다. 채워진 후에는 실제 도형 유형을 검사하여 어떤 것이 들어있는지 확인하십시오. 특수 레이아웃은 또한 [PlaceholderType.Chart](https://reference.aspose.com/slides/ko/python-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/ko/python-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/ko/python-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/ko/python-java/aspose.slides/placeholdertype/#Media) 또는 [PlaceholderType.Diagram](https://reference.aspose.com/slides/ko/python-java/aspose.slides/placeholdertype/#Diagram) 을 노출할 수 있습니다.

Aspose.Slides는 [Placeholder.getType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/placeholder/#getType) 을 변경한다고 해서 빈 [AutoShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/autoshape/) 플레이스홀더가 자동으로 [Chart](https://reference.aspose.com/slides/ko/python-java/aspose.slides/chart/) 로 변환되지 않으며, API를 통해 유형을 변경할 수 없습니다. 빈 차트나 콘텐츠 영역을 프로그래밍 방식으로 채우려면 해당 플레이스홀더 좌표에 필요한 객체를 추가하고 빈 플레이스홀더를 제거하십시오. 다음 예제는 차트에 대해 이를 수행합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PlaceholderType, ChartType, SaveFormat

presentation = Presentation("content-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    target_placeholder = None

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Chart, PlaceholderType.Object):
            target_placeholder = shape
            break

    if target_placeholder is None:
        print("The first slide does not contain a chart or content placeholder.")
    else:
        chart = slide.getShapes().addChart(ChartType.ClusteredColumn, target_placeholder.getX(), target_placeholder.getY(), target_placeholder.getWidth(), target_placeholder.getHeight())
        chart.setTitle(True)
        chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue")
        slide.getShapes().remove(target_placeholder)
        presentation.save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

추가된 차트는 일반 로컬 차트이며, 플레이스홀더 영역을 차지하지만 레이아웃 플레이스홀더를 상속하지 않습니다. 범주, 시리즈 또는 워크북 데이터를 교체해야 할 경우 전용 [chart management articles](/slides/ko/python-java/powerpoint-charts/) 를 사용하십시오.

## **전체 예제: 텍스트 또는 이미지 콘텐츠 업데이트**

다음 End‑to‑End 예제는 템플릿을 열고, 첫 번째 슬라이드에서 제목 또는 그림 플레이스홀더를 검색한 뒤, 플레이스홀더와 도형 유형을 확인하고, 적절한 콘텐츠를 업데이트한 뒤 결과를 저장합니다. 이 예제는 도형 인덱스를 가정하거나 모든 플레이스홀더를 동일한 유형으로 취급하지 않도록 설계되었습니다.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PictureFrame, PlaceholderType, ShapeType, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    updated = False

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle) and isinstance(shape, AutoShape):
            shape.getTextFrame().setText("Quarterly Business Review")
            updated = True
            break

        if placeholder_type == PlaceholderType.Picture:
            image_bytes = Path("replacement.png").read_bytes()
            java_image_bytes = jpype.JArray(jpype.JByte)(image_bytes)
            image = presentation.getImages().addImage(java_image_bytes)

            if isinstance(shape, PictureFrame):
                shape.getPictureFormat().getPicture().setImage(image)
            else:
                slide.getShapes().addPictureFrame(ShapeType.Rectangle, shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), image)
                slide.getShapes().remove(shape)

            updated = True
            break

    if updated:
        presentation.save("placeholder-content-updated.pptx", SaveFormat.Pptx)
    else:
        print("No supported title or picture placeholder was found on the first slide.")
finally:
    presentation.dispose()
```

## **FAQ**

**기본 플레이스홀더란 무엇입니까?**

기본 플레이스홀더는 레이아웃이나 마스터에 있는 해당 도형으로, 다른 플레이스홀더가 이를 상속받습니다. [Shape.getBasePlaceholder](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getBasePlaceholder) 로 가져올 수 있습니다. 일반 로컬 도형은 플레이스홀더 계층 구조에 속하지 않으므로 `None`을 반환합니다.

**레이아웃 플레이스홀더를 편집하여 모든 슬라이드 제목을 변경할 수 있나요?**

레이아웃을 통해 상속된 서식이나 프롬프트 텍스트는 변경할 수 있지만, 기존 제목 내용은 일반 슬라이드에 저장됩니다. 프레젠테이션 전체의 실제 제목 텍스트를 교체하려면 슬라이드를 순회하면서 각 제목 플레이스홀더를 업데이트해야 합니다.

**날짜, 슬라이드 번호, 헤더 및 푸터 플레이스홀더는 어떻게 관리합니까?**

해당 슬라이드, 레이아웃, 마스터, 노트 또는 유인물 범위에서 헤더 및 푸터 관리자를 사용하십시오. 전체 예제는 [Manage Presentation Header and Footer](/slides/ko/python-java/presentation-header-and-footer/) 를 참조하십시오.