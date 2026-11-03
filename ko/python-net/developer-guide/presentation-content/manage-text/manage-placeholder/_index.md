---
title: Python에서 프레젠테이션 자리 표시자 관리
linktitle: 자리 표시자 관리
type: docs
weight: 10
url: /ko/python-net/manage-placeholder/
keywords:
- 자리 표시자
- 텍스트 자리 표시자
- 이미지 자리 표시자
- 차트 자리 표시자
- 콘텐츠 자리 표시자
- 프롬프트 텍스트
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 텍스트, 그림, 차트 및 콘텐츠 자리 표시자를 검사하고 편집하며 자리 표시자 상속을 이해하는 방법을 배웁니다."
---
## **개요**

자리 표시자는 프레젠테이션 템플릿에서 특정 종류의 콘텐츠 위치를 예약하는 도형입니다. 일반적인 예로는 제목, 본문, 그림, 차트 및 일반용 콘텐츠 자리 표시자가 있습니다. 일반 도형과 달리 자리 표시자는 레이아웃 슬라이드 또는 마스터 슬라이드로부터 위치, 크기, 서식 및 기타 설정을 상속받을 수 있습니다.

Aspose.Slides는 [Shape.placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/) 속성을 통해 자리 표시자 정보를 노출합니다. 이 속성은 일반 도형에 대해 `None`을 반환하거나 [Placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/) 객체를 반환합니다. 자리 표시자가 포함하도록 설계된 콘텐츠 유형을 확인하려면 [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/)를 사용하십시오.

자리 표시자 유형을 알게 된 후에도 도형 클래스는 여전히 중요합니다:

- 텍스트, 그림, 차트 또는 콘텐츠가 비어 있는 자리 표시자는 일반적으로 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)으로 표현됩니다.
- 채워진 그림 자리 표시자는 [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/)으로 표현될 수 있습니다.
- 채워진 차트 자리 표시자는 [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/)으로 표현될 수 있습니다.
- 콘텐츠 자리 표시자는 여러 종류의 콘텐츠를 포함할 수 있습니다. 모든 자리 표시자가 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)라고 가정하지 말고 [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/)와 런타임 도형 클래스를 모두 확인하십시오.

{{% alert color="warning" title="Warning" %}}
[Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/)은 자리 표시자의 역할을 설명하지만, 도형의 런타임 클래스를 보장하지는 않습니다. 텍스트, 그림, 차트, 표 또는 미디어 전용 멤버에 접근하기 전에 항상 형식 검사를 수행하십시오.
{{% /alert %}}

## **자리 표시자 상속 이해**

자리 표시자는 계층 구조를 형성합니다:

1. 마스터 슬라이드는 재사용 가능한 스타일을 정의하고 경우에 따라 마스터 수준 자리 표시자를 정의합니다.
2. 레이아웃 슬라이드는 하나 이상의 일반 슬라이드에서 사용되는 배치를 정의하고 마스터로부터 상속받을 수 있습니다.
3. 일반 슬라이드는 해당 슬라이드의 자리 표시자를 포함하며 레이아웃으로부터 상속받을 수 있습니다.

[Shape.get_base_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_base_placeholder/)을 호출하면 이 계층 구조에서 한 단계 위로 이동합니다. 슬라이드 자리 표시자는 일반적으로 레이아웃 자리 표시자를 반환하고, 레이아웃 자리 표시자는 마스터 자리 표시자를 반환할 수 있습니다. 도형에 기본 자리 표시자가 없으면 이 메서드는 `None`을 반환합니다.

다음 예제는 첫 번째 슬라이드의 자리 표시자를 나열하고 해당 기본 자리 표시자를 표시합니다:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type
        type_name = type(shape).__name__
        print(f"Slide placeholder: {placeholder_type}; shape class: {type_name}")

        layout_placeholder = shape.get_base_placeholder()
        if layout_placeholder is not None:
            layout_placeholder_type = layout_placeholder.placeholder.type if layout_placeholder.placeholder is not None else None
            print(f"  Layout placeholder: {layout_placeholder_type}")

            master_placeholder = layout_placeholder.get_base_placeholder()
            if master_placeholder is not None:
                master_placeholder_type = master_placeholder.placeholder.type if master_placeholder.placeholder is not None else None
                print(f"  Master placeholder: {master_placeholder_type}")
```

일반 슬라이드에서 자리 표시자를 편집하면 해당 슬라이드에 대한 로컬 오버라이드가 생성되거나 변경됩니다. 관련 레이아웃이나 마스터를 편집하면 여전히 해당 설정을 상속하는 모든 슬라이드에 영향을 줄 수 있습니다. 로컬 일반 도형은 기본 자리 표시자가 없으며 동일한 좌표를 차지한다고 해서 상속이 시작되는 것은 아닙니다.

## **자리 표시자 상태 제거**

템플릿을 수정할 때 [Shape.remove_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/remove_placeholder/)을 사용하면 기존 개체를 일반 도형으로 유지할 수 있습니다. 해당 도형의 [placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/) 속성은 `None`이 되지만 도형은 슬라이드 컬렉션에 남아 있습니다. 반면에 [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/)는 해당 컬렉션에서 도형을 삭제합니다.

다음 예제는 최소 하나의 슬라이드와 첫 번째 슬라이드에 비어 있지 않은 텍스트 자리 표시자가 포함된 `template.pptx`가 필요합니다. 레이아웃 또는 마스터에서 상속된 서식이 있는 자리 표시자를 사용하면 해당 관계를 제거했을 때의 효과를 확인할 수 있습니다. 예제는 동일한 도형이 남아 있는지 확인하고, 이제 일반 도형이 된 상태에서 메서드를 다시 호출한 뒤 결과를 저장합니다:

{{% alert color="warning" title="Warning" %}}
자리 표시자 상태를 제거한다고 해서 상속된 표시 설정이 자동으로 보존되는 것은 아닙니다. 아래 예제는 의도적으로 이러한 설정을 변경하지 않으며, 따라서 출력이 다르게 보일 수 있습니다. 위치와 크기가 완전히 상속된 도형은 호출 후 좌표와 크기가 0이 되어 컬렉션에 남아 있어도 보이지 않을 수 있습니다.
{{% /alert %}}

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    found = False

    for index in range(len(slide.shapes)):
        shape = slide.shapes[index]
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue
        if shape.text_frame is None or not shape.text_frame.text:
            continue

        shape_count = len(slide.shapes)
        shape.remove_placeholder()

        print(f"Placeholder removed: {shape.placeholder is None}")
        print(f"Same shape retained: {slide.shapes[index] == shape}")
        print(f"Shape count unchanged: {len(slide.shapes) == shape_count}")

        # 일반 도형에 메서드를 호출해도 효과가 없습니다.
        shape.remove_placeholder()
        found = True
        break

    if found:
        presentation.save("placeholder-status-removed.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("No nonempty text placeholder was found on the first slide.")
```

일치하는 자리 표시자에 대해 세 가지 검사 모두 `True`를 출력합니다. 텍스트는 유지되지만, 상속된 위치, 크기, 회전, 글꼴, 단락 정렬, 텍스트 프레임 여백, 수직 정렬, 채우기 및 선 설정은 자리 표시자 관계가 제거될 때 변경될 수 있습니다. 예를 들어 상속된 제목 서식이 일반 텍스트 서식으로 돌아갈 수 있습니다. 레이아웃에 대한 자세한 내용은 [Slide Layout](/slides/ko/python-net/slide-layout/)를 참조하십시오.

원래의 표시 모양을 유지하려면 호출 전에 해결된 위치, 크기 및 회전을 캡처하고 필요한 유효 서식 값을 별도 변수에 복사하십시오. 이러한 값은 [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/), [ParagraphFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/get_effective/), [TextFrameFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/get_effective/), [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/), [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/)을 통해 가져와야 합니다. 관계가 제거된 후 텍스트 서식 값이 변경될 수 있으므로 유효‑서식 객체만 보존하려고 하지 마십시오. 캡처한 값을 이후에 일반 도형에 명시적으로 적용하십시오(글꼴 패밀리, 크기, 스타일, 색상, 단락 설정, 텍스트 프레임 설정, 채우기 및 선 포함).

상속된 도형 기하학도 [GeometryShape.shape_type](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/shape_type/)을 통해 명시적으로 지정해야 할 수 있습니다. 사각형 텍스트 자리 표시자의 경우 [ShapeType.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/)을 지정해야 합니다; 채우기와 선만 복원해도 보이는 사각형이 복원되지 않을 수 있습니다. 추가 효과나 복잡한 서식이 적용된 템플릿은 해당 설정을 별도로 처리해야 합니다.

## **자리 표시자 텍스트 변경**

제목, 가운데‑제목, 부제목, 본문 및 텍스트 자리 표시자는 일반적으로 텍스트를 지원합니다. 해당 도형의 [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/) 속성을 사용하기 전에 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)인지 확인하십시오.

다음 예제는 첫 번째 슬라이드의 첫 번째 제목 자리 표시자를 업데이트하고 결과를 저장합니다:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    title_shape = None

    for shape in slide.shapes:
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type
        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE):
            title_shape = shape
            break

    if title_shape is None:
        raise RuntimeError("The first slide does not contain a title placeholder.")

    title_shape.text_frame.text = "Quarterly Business Review"
    presentation.save("title-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

이 패턴은 그림, 차트, 표 또는 미디어 자리 표시자를 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) 객체로 취급하는 것을 방지합니다. 또한 형태가 불안정한 인덱스에 의존하지 않고 용도별로 자리 표시자를 식별합니다.

## **레이아웃에 프롬프트 텍스트 설정**

프롬프트 텍스트는 *Click to add title*과 같이 비어 있는 자리 표시자에 표시되는 디자인‑타임 안내문입니다. 일반 슬라이드의 도형 컬렉션을 통해 접근하려고 시도하기보다 레이아웃 자리 표시자에 사용자 정의 프롬프트 텍스트를 설정하십시오. 레이아웃은 [Slide.layout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/layout_slide/)을 통해 접근하고 [LayoutSlide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/)를 순회합니다.

다음 예제는 첫 번째 슬라이드에서 사용되는 레이아웃의 제목 및 부제목 프롬프트를 변경합니다:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    layout_slide = presentation.slides[0].layout_slide

    for shape in layout_slide.shapes:
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type

        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE):
            shape.text_frame.text = "Enter a concise slide title"
        elif placeholder_type == slides.PlaceholderType.SUBTITLE:
            shape.text_frame.text = "Enter a subtitle or reporting period"

    presentation.save("custom-placeholder-prompts.pptx", slides.export.SaveFormat.PPTX)
```

프롬프트 텍스트는 일반 슬라이드 콘텐츠가 아닙니다. PowerPoint와 같은 편집 응용 프로그램에서 비어 있는 자리 표시자를 위한 지시문으로 사용됩니다. 사용자가 실제 콘텐츠를 제공하면 프롬프트는 더 이상 표시되지 않습니다. 프롬프트를 변경해도 해당 레이아웃을 사용하는 슬라이드의 기존 텍스트가 교체되지는 않습니다.

## **그림 자리 표시자 업데이트**

다음 두 경우를 처리해야 합니다:

- 그림 자리 표시자가 이미 채워져 있고 [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/)으로 표시되는 경우, [PictureFillFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture/)와 [Picture.image](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image/)을 사용해 이미지를 교체합니다.
- 아직 비어 있는 경우, [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/)을 사용해 자리 표시자 좌표에 그림 프레임을 추가하고 비어 있는 자리 표시자를 제거합니다.

다음 예제는 두 경우를 모두 지원하고 프레젠테이션을 저장합니다:

```python
import aspose.slides as slides

with slides.Presentation("picture-template.pptx") as presentation:
    slide = presentation.slides[0]
    picture_placeholder = None

    for shape in slide.shapes:
        if shape.placeholder is not None and shape.placeholder.type == slides.PlaceholderType.PICTURE:
            picture_placeholder = shape
            break

    if picture_placeholder is None:
        raise RuntimeError("The first slide does not contain a picture placeholder.")

    with open("replacement.png", "rb") as image_stream:
        image_bytes = image_stream.read()

    image = presentation.images.add_image(image_bytes)

    if isinstance(picture_placeholder, slides.PictureFrame):
        picture_placeholder.picture_format.picture.image = image
    else:
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, picture_placeholder.x, picture_placeholder.y, picture_placeholder.width, picture_placeholder.height, image)
        slide.shapes.remove(picture_placeholder)

    presentation.save("picture-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

비어 있는 자리 표시자를 위해 만든 교체물은 새로운 자리 표시자가 아니라 로컬 그림 프레임이며, [Shape.placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/)이 읽기 전용이기 때문에 자리 표시자 자체는 아니게 됩니다. 예약된 위치는 유지하지만 더 이상 자리 표시자 전용 동작을 상속하지 않습니다. 자리 표시자 관계를 유지하는 것이 필수인 경우 먼저 PowerPoint에서 해당 자리 표시자를 준비하고 채운 뒤 Aspose.Slides로 결과 [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/)을 업데이트하십시오.

이미지 투명도, 자르기 및 기타 그림 전용 효과에 대해서는 [Manage Picture Frames](/slides/ko/python-net/picture-frame/)를 참조하십시오. 이러한 작업은 그림 프레임 또는 그림 채우기에 적용되며 자리 표시자 메타데이터와는 관련이 없습니다.

## **차트 및 콘텐츠 자리 표시자 작업**

채워진 차트 자리 표시자는 [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/)으로 표현될 수 있습니다. 이 예제는 자리 표시자 유형과 런타임 클래스를 모두 확인하여 차트를 찾아 제목을 변경하고 파일을 저장합니다:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart-template.pptx") as presentation:
    slide = presentation.slides[0]
    placeholder_chart = None

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.placeholder is not None and shape.placeholder.type == slides.PlaceholderType.CHART:
            placeholder_chart = shape
            break

    if placeholder_chart is None:
        raise RuntimeError("The first slide does not contain a populated chart placeholder.")

    placeholder_chart.has_title = True
    placeholder_chart.chart_title.add_text_frame_for_overriding("Quarterly Revenue")
    presentation.save("chart-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

일반 콘텐츠 자리 표시자는 보통 [PlaceholderType.OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/)를 가집니다. PowerPoint에서는 차트, 표, 다이어그램, 그림 및 미디어 등 여러 콘텐츠 유형을 시작하는 런처 역할을 합니다. 채워진 후에는 실제 도형 클래스를 검사해 어떤 콘텐츠가 포함되어 있는지 확인해야 합니다. 특수 레이아웃은 [PlaceholderType.CHART](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.TABLE](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.PICTURE](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.MEDIA](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.DIAGRAM](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/)을 노출할 수 있습니다.

Aspose.Slides는 [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/)을 변경한다고 해서 빈 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) 자리 표시자를 [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/)로 변환하지 않습니다; 유형은 읽기 전용입니다. 빈 차트 또는 콘텐츠 영역을 프로그래밍 방식으로 채우려면 해당 좌표에 필요한 객체를 추가하고 빈 자리 표시자를 제거하십시오. 다음 예제는 차트에 대해 이를 수행합니다:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("content-template.pptx") as presentation:
    slide = presentation.slides[0]
    target_placeholder = None

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        if shape.placeholder.type in (slides.PlaceholderType.CHART, slides.PlaceholderType.OBJECT):
            target_placeholder = shape
            break

    if target_placeholder is None:
        raise RuntimeError("The first slide does not contain a chart or content placeholder.")

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, target_placeholder.x, target_placeholder.y, target_placeholder.width, target_placeholder.height)
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Quarterly Revenue")
    slide.shapes.remove(target_placeholder)
    presentation.save("content-placeholder-replaced-with-chart.pptx", slides.export.SaveFormat.PPTX)
```

추가된 차트는 일반 로컬 차트이며, 자리 표시자 영역을 차지하지만 레이아웃 자리 표시자를 상속하지 않습니다. 카테고리, 시리즈 또는 워크북 데이터 교체가 필요할 때는 전용 [chart management articles](/slides/ko/python-net/powerpoint-charts/)를 참고하십시오.

## **완전한 예제: 텍스트 또는 이미지 콘텐츠 업데이트**

다음 엔드‑투‑엔드 예제는 템플릿을 열고, 첫 번째 슬라이드에서 제목 또는 그림 자리 표시자를 검색한 뒤, 자리 표시자와 도형 유형을 확인하고 적절한 콘텐츠를 업데이트한 뒤 결과를 저장합니다. 예제는 도형 인덱스를 가정하거나 모든 자리 표시자를 동일한 도형 클래스로 취급하지 않도록 의도적으로 설계되었습니다.

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    updated = False

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type

        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE) and isinstance(shape, slides.AutoShape):
            shape.text_frame.text = "Quarterly Business Review"
            updated = True
            break

        if placeholder_type == slides.PlaceholderType.PICTURE:
            with open("replacement.png", "rb") as image_stream:
                image_bytes = image_stream.read()

            image = presentation.images.add_image(image_bytes)

            if isinstance(shape, slides.PictureFrame):
                shape.picture_format.picture.image = image
            else:
                slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, shape.x, shape.y, shape.width, shape.height, image)
                slide.shapes.remove(shape)

            updated = True
            break

    if not updated:
        raise RuntimeError("No supported title or picture placeholder was found on the first slide.")

    presentation.save("placeholder-content-updated.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**베이스 자리 표시자란 무엇인가요?**

베이스 자리 표시자는 레이아웃이나 마스터에 있는 해당 도형으로, 다른 자리 표시자가 이를 상속받습니다. 이를 가져오려면 [Shape.get_base_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_base_placeholder/)를 사용하십시오. 일반 로컬 도형은 자리 표시자 계층에 포함되지 않기 때문에 `None`을 반환합니다.

**레이아웃 자리 표시자를 편집해서 모든 슬라이드 제목을 바꿀 수 있나요?**

레이아웃을 통해 상속된 서식이나 프롬프트 텍스트는 변경할 수 있지만, 실제 제목 내용은 일반 슬라이드에 저장됩니다. 프레젠테이션 전체의 제목 텍스트를 교체하려면 슬라이드를 순회하면서 각 제목 자리 표시자를 업데이트해야 합니다.

**날짜, 슬라이드 번호, 머리글 및 바닥글 자리 표시자는 어떻게 관리하나요?**

해당 슬라이드, 레이아웃, 마스터, 노트 또는 유인물 범위에서 헤더 및 풋터 관리자를 사용하십시오. 자세한 예제는 [Manage Presentation Header and Footer](/slides/ko/python-net/presentation-header-and-footer/)를 참고하십시오.