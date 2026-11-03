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

플레이스홀더는 프레젠테이션 템플릿에서 특정 종류의 콘텐츠가 들어갈 위치를 예약하는 도형입니다. 일반적인 예로는 제목, 본문, 그림, 차트 및 일반용 콘텐츠 플레이스홀더가 있습니다. 일반 도형과 달리, 플레이스홀더는 레이아웃 슬라이드나 마스터 슬라이드로부터 위치, 크기, 서식 및 기타 설정을 상속받을 수 있습니다.

Aspose.Slides는 플레이스홀더 정보를 [Shape.getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder) 메서드를 통해 노출합니다. 이 메서드는 일반 도형의 경우 `None`을 반환하고, [Placeholder](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/) 객체를 반환합니다. 플레이스홀더에 어떤 내용이 들어갈지 확인하려면 [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) 을 사용하세요.

플레이스홀더 유형을 알게 된 후에도 도형 유형은 여전히 중요합니다:

- 빈 텍스트, 그림, 차트 또는 콘텐츠 플레이스홀더는 일반적으로 [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) 로 표시됩니다.
- 채워진 그림 플레이스홀더는 [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) 로 표시될 수 있습니다.
- 채워진 차트 플레이스홀더는 [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) 로 표시될 수 있습니다.
- 콘텐츠 플레이스홀더는 여러 종류의 콘텐츠를 포함할 수 있습니다. 모든 플레이스홀더가 [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) 라고 가정하지 말고, [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) 과 런타임 도형 유형을 모두 확인하세요.

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) 은 플레이스홀더의 역할을 설명하지만, 도형의 런타임 유형을 보장하지는 않습니다. 텍스트, 그림, 차트, 표 또는 미디어 전용 멤버에 접근하기 전에 항상 유형 검사를 수행하세요.
{{% /alert %}}

## **플레이스홀더 상속 이해**

플레이스홀더는 계층 구조를 형성합니다:

1. 마스터 슬라이드는 재사용 가능한 스타일을 정의하고, 경우에 따라 마스터 수준의 플레이스홀더를 정의합니다.
2. 레이아웃 슬라이드는 하나 이상의 일반 슬라이드가 사용할 배열을 정의하며 마스터로부터 상속받을 수 있습니다.
3. 일반 슬라이드는 해당 슬라이드의 플레이스홀더를 포함하고 레이아웃으로부터 상속받을 수 있습니다.

[Shape.getBasePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getBasePlaceholder) 을 호출하면 이 계층 구조에서 한 단계 위로 올라갑니다. 슬라이드 플레이스홀더는 일반적으로 레이아웃 플레이스홀더를 반환하고, 레이아웃 플레이스홀더는 마스터 플레이스홀더를 반환할 수 있습니다. 해당 도형에 기본 플레이스홀더가 없으면 메서드는 `None`을 반환합니다.

다음 예제는 첫 번째 슬라이드에 있는 플레이스홀더를 나열하고 해당 기본 플레이스홀더를 보고합니다:

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

일반 슬라이드에서 플레이스홀더를 편집하면 해당 슬라이드에 대한 로컬 재정의가 생성되거나 변경됩니다. 관련 레이아웃이나 마스터를 편집하면 여전히 해당 설정을 상속하는 모든 슬라이드에 영향을 줄 수 있습니다. 로컬 일반 도형은 기본 플레이스홀더가 없으며 동일한 좌표에 위치한다고 해서 상속이 시작되는 것은 아닙니다.

## **플레이스홀더 상태 제거**

템플릿을 수정할 때 [Shape.removePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#removePlaceholder) 을 사용하면 기존 객체를 일반 도형으로 유지할 수 있습니다. 해당 도형의 [getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder) 메서드는 `None`을 반환하지만, 도형은 슬라이드 컬렉션에 남아 있습니다. 반대로 [ShapeCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#remove) 은 컬렉션에서 도형을 삭제합니다.

다음 예제는 최소 하나의 슬라이드와 첫 번째 슬라이드에 비어 있지 않은 텍스트 플레이스홀더가 있는 `template.pptx` 파일이 필요합니다. 레이아웃 또는 마스터에서 상속된 서식을 가진 플레이스홀더를 사용하여 관계 제거 효과를 확인하세요. 예제는 동일한 도형이 남아 있는지 확인하고, 이제 일반 도형이 된 후 다시 메서드를 호출한 뒤 결과를 저장합니다:

{{% alert color="warning" title="Warning" %}}
플레이스홀더 상태를 제거한다고 해서 상속된 외관 설정이 자동으로 보존되는 것은 아닙니다. 아래 예제는 이러한 설정을 그대로 두도록 의도했으므로 출력이 다르게 보일 수 있습니다. 위치와 크기가 완전히 상속된 도형은 호출 이후 좌표와 크기가 0이 되어 컬렉션에 남아 있어도 보이지 않을 수 있습니다.
{{% /alert %}}

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    found = False

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if not isinstance(shape, AutoShape):
            continue

        text_frame = shape.getTextFrame()
        if shape.getPlaceholder() is None or text_frame is None:
            continue
        text = text_frame.getText()
        if text is None or len(text) == 0:
            continue

        shape_count = slide.getShapes().size()
        shape.removePlaceholder()

        print(f"Placeholder removed: {shape.getPlaceholder() is None}")
        print(f"Same shape retained: {slide.getShapes().get_Item(index) == shape}")
        print(f"Shape count unchanged: {slide.getShapes().size() == shape_count}")

        # 일반 도형에 메서드를 호출해도 효과가 없습니다.
        shape.removePlaceholder()
        found = True
        break

    if found:
        presentation.save("placeholder-status-removed.pptx", SaveFormat.Pptx)
    else:
        print("No nonempty text placeholder was found on the first slide.")
finally:
    presentation.dispose()
```

일치하는 플레이스홀더에 대해 세 가지 검사 모두 `True` 를 출력합니다. 텍스트는 유지되지만, 상속된 위치, 크기, 회전, 글꼴, 단락 정렬, 텍스트 프레임 여백, 수직 정렬, 채우기 및 선 설정은 플레이스홀더 관계가 제거될 때 변경될 수 있습니다. 예를 들어, 상속된 제목 서식이 일반 텍스트 서식으로 되돌아갈 수 있습니다. 레이아웃에 대한 자세한 내용은 [슬라이드 레이아웃](/slides/ko/python-java/slide-layout/)을 참조하세요.

원하는 외관을 유지하려면 호출 전에 해석된 위치, 크기 및 회전을 캡처하고 필요한 유효 서식 값을 별도 변수에 복사하세요. 이러한 값은 [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective), [ParagraphFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getEffective), [TextFrameFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getEffective), [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective), [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective) 를 통해 가져옵니다. 관계가 제거된 후 텍스트 서식 값이 변경될 수 있기 때문에 유효 서식 객체만 보존하는 데 의존하지 마세요. 캡처한 값을 이후에 일반 도형에 명시적으로 적용하고, 글꼴 패밀리, 크기, 스타일, 색상, 단락 설정, 텍스트 프레임 설정, 채우기 및 라인을 템플릿에 맞게 적용하세요.

상속된 도형 기하학도 [GeometryShape.setShapeType](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setShapeType) 으로 명시적으로 지정해야 할 수 있습니다. 사각형 텍스트 플레이스홀더의 경우 [ShapeType.Rectangle](https://reference.aspose.com/slides/python-java/aspose.slides/shapetype/#Rectangle) 을 할당해야 하며, 채우기와 선만 복원한다고 가시적인 사각형이 복구되지 않을 수 있습니다. 추가 효과나 복잡한 서식이 있는 템플릿은 이러한 설정도 별도로 처리해야 합니다.

## **플레이스홀더의 텍스트 변경**

제목, 가운데 제목, 부제목, 본문 및 텍스트 플레이스홀더는 일반적으로 텍스트를 지원합니다. 해당 도형의 [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#getTextFrame) 메서드를 사용하기 전에 [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) 인지 확인하세요.

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

이 패턴은 그림, 차트, 표 또는 미디어 플레이스홀더를 [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) 로 취급하지 않도록 방지합니다. 또한 도형 인덱스에 의존하지 않고 목적에 따라 플레이스홀더를 식별합니다.

## **레이아웃에 프롬프트 텍스트 설정**

프롬프트 텍스트는 빈 플레이스홀더에 표시되는 디자인 시점 안내문으로, 예를 들어 *Click to add title* 와 같습니다. 일반 슬라이드의 도형 컬렉션을 통해 접근하려고 하지 말고 레이아웃 플레이스홀더에 사용자 지정 프롬프트 텍스트를 설정하세요. 레이아웃은 [Slide.getLayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getLayoutSlide) 로 접근하고, [BaseSlide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes) 로 반환된 컬렉션을 순회합니다.

다음 예제는 첫 번째 슬라이드에 사용된 레이아웃의 제목과 부제목 프롬프트를 변경합니다:

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

프롬프트 텍스트는 일반 슬라이드 콘텐츠가 아닙니다. PowerPoint와 같은 편집 응용 프로그램에서 빈 플레이스홀더에 대한 안내용이며, 사용자가 실제 콘텐츠를 입력하면 더 이상 표시되지 않습니다. 프롬프트를 변경해도 레이아웃을 사용하는 슬라이드의 기존 텍스트가 교체되지는 않습니다.

## **그림 플레이스홀더 업데이트**

다음 두 경우를 처리해야 합니다:

- 그림 플레이스홀더가 이미 채워져 있고 [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) 로 표시되는 경우, [PictureFillFormat.getPicture](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#getPicture) 와 [Picture.setImage](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#setImage) 로 이미지를 교체합니다.
- 아직 빈 플레이스홀더인 경우, [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addPictureFrame) 을 사용해 플레이스홀더 좌표에 그림 프레임을 추가하고 빈 플레이스홀더를 삭제합니다.

다음 예제는 두 경우를 모두 지원하고 프레젠테이션을 저장합니다:

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

빈 플레이스홀더에 대해 생성된 교체물은 새 플레이스홀더가 아닌 로컬 그림 프레임입니다. [Shape.getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder) 에는 설정자가 없기 때문입니다. 예약된 위치는 유지되지만 더 이상 플레이스홀더 전용 동작을 상속하지 않습니다. 플레이스홀더 관계를 유지해야 하는 경우, 먼저 PowerPoint에서 플레이스홀더를 준비·채우고 나서 Aspose.Slides 로 해당 [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) 을 업데이트하세요.

이미지 투명도, 자르기 및 기타 그림 전용 효과에 대해서는 [그림 프레임 관리](/slides/ko/python-java/picture-frame/) 를 참조하세요. 이러한 작업은 그림 프레임 또는 그림 채우기와 관련이 있으며, 플레이스홀더 메타데이터와는 무관합니다.

## **차트 및 콘텐츠 플레이스홀더 작업**

채워진 차트 플레이스홀더는 [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) 로 표시될 수 있습니다. 다음 예제는 플레이스홀더 유형과 런타임 유형을 모두 확인해 해당 차트를 찾아 제목을 변경하고 파일을 저장합니다:

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

일반 콘텐츠 플레이스홀더는 보통 [PlaceholderType.Object](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Object) 를 가집니다. PowerPoint에서는 차트, 표, 다이어그램, 그림 및 미디어 등 여러 콘텐츠 유형을 시작할 수 있는 런처 역할을 합니다. 채워진 후에는 실제 도형 유형을 검사해 무엇이 포함되어 있는지 확인하세요. 특수 레이아웃은 [PlaceholderType.Chart](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Media), [PlaceholderType.Diagram](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Diagram) 을 노출하기도 합니다.

Aspose.Slides는 [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) 을 변경한다고 해서 빈 [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) 플레이스홀더가 [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) 로 변환되지 않습니다; API를 통해 유형을 변경할 수 없습니다. 빈 차트나 콘텐츠 영역을 프로그래밍 방식으로 채우려면 해당 좌표에 필요한 객체를 추가하고 빈 플레이스홀더를 삭제하세요. 다음 예제는 차트에 대해 이를 수행합니다:

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

추가된 차트는 일반 로컬 차트이며, 플레이스홀더 영역을 차지하지만 레이아웃 플레이스홀더를 상속하지 않습니다. 카테고리, 시리즈 또는 워크북 데이터를 교체해야 할 때는 전용 [차트 관리 문서](/slides/ko/python-java/powerpoint-charts/) 를 사용하세요.

## **완전한 예제: 텍스트 또는 이미지 콘텐츠 업데이트**

다음 엔드‑투‑엔드 예제는 템플릿을 열고, 첫 번째 슬라이드에서 제목 또는 그림 플레이스홀더를 검색한 뒤, 플레이스홀더와 도형 유형을 확인하고 적절한 콘텐츠를 업데이트한 뒤 결과를 저장합니다. 예제는 도형 인덱스를 가정하거나 모든 플레이스홀더를 동일한 유형으로 처리하는 것을 의도적으로 피합니다:

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

**베이스 플레이스홀더란 무엇인가요?**

베이스 플레이스홀더는 다른 플레이스홀더가 상속받는 레이아웃 또는 마스터상의 해당 도형입니다. 이를 검색하려면 [Shape.getBasePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getBasePlaceholder) 을 사용하세요. 일반 로컬 도형은 플레이스홀더 계층 구조의 일부가 아니므로 `None`을 반환합니다.

**레이아웃 플레이스홀더를 편집하여 모든 슬라이드 제목을 변경할 수 있나요?**

레이아웃을 통해 상속된 서식이나 프롬프트 텍스트는 변경할 수 있지만, 실제 제목 내용은 일반 슬라이드에 저장됩니다. 프레젠테이션 전체의 제목 텍스트를 교체하려면 슬라이드를 순회하며 각 제목 플레이스홀더를 업데이트해야 합니다.

**날짜, 슬라이드 번호, 머리글 및 바닥글 플레이스홀더를 어떻게 관리하나요?**

해당 슬라이드, 레이아웃, 마스터, 노트 또는 유인물 범위의 헤더 및 풋터 관리자를 사용하세요. 자세한 예제는 [프레젠테이션 머리글 및 바닥글 관리](/slides/ko/python-java/presentation-header-and-footer/) 를 참고하세요.