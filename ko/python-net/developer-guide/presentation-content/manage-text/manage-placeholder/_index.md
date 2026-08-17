---
title: Python에서 프레젠테이션 플레이스홀더 관리
linktitle: 플레이스홀더 관리
type: docs
weight: 10
url: /ko/python-net/manage-placeholder/
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
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 텍스트, 그림, 차트 및 콘텐츠 플레이스홀더를 검사하고 편집하는 방법과 플레이스홀더 상속을 이해하는 방법을 배웁니다."
---
## **개요**

플레이스홀더는 프레젠테이션 템플릿에서 특정 유형의 콘텐츠가 차지할 위치를 예약하는 도형입니다. 일반적인 예로는 제목, 본문, 그림, 차트 및 일반 용도 콘텐츠 플레이스홀더가 있습니다. 일반 도형과 달리 플레이스홀더는 레이아웃 슬라이드 또는 마스터 슬라이드로부터 위치, 크기, 서식 및 기타 설정을 상속받을 수 있습니다.

Aspose.Slides는 [Shape.placeholder](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/placeholder/) 속성을 통해 플레이스홀더 정보를 노출합니다. 이 속성은 일반 도형에 대해 `None`이거나 [Placeholder](https://reference.aspose.com/slides/ko/python-net/aspose.slides/placeholder/) 객체를 반환합니다. 플레이스홀더가 어떤 내용을 담도록 설계되었는지 확인하려면 [Placeholder.type](https://reference.aspose.com/slides/ko/python-net/aspose.slides/placeholder/type/)을 사용합니다.

플레이스홀더 유형을 알게 된 후에도 도형 클래스는 중요합니다:

- 빈 텍스트, 그림, 차트 또는 콘텐츠 플레이스홀더는 일반적으로 [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/)으로 나타냅니다.
- 내용이 채워진 그림 플레이스홀더는 [PictureFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pictureframe/)으로 나타낼 수 있습니다.
- 내용이 채워진 차트 플레이스홀더는 [Chart](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chart/)으로 나타낼 수 있습니다.
- 콘텐츠 플레이스홀더는 여러 종류의 콘텐츠를 포함할 수 있습니다. 모든 플레이스홀더가 [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/)이라고 가정하지 말고 [Placeholder.type](https://reference.aspose.com/slides/ko/python-net/aspose.slides/placeholder/type/)과 런타임 도형 클래스를 모두 확인하세요.

{{% alert color="warning" title="Warning" %}}
[Placeholder.type](https://reference.aspose.com/slides/ko/python-net/aspose.slides/placeholder/type/)은(는) 플레이스홀더의 역할을 설명하지만, 도형의 런타임 클래스를 보장하지는 않습니다. 텍스트, 그림, 차트, 표 또는 미디어 전용 멤버에 접근하기 전에 항상 유형 검사를 수행하십시오.
{{% /alert %}}

## **플레이스홀더 상속 이해**

플레이스홀더는 계층 구조를 형성합니다:

1. 마스터 슬라이드는 재사용 가능한 스타일을 정의하고 경우에 따라 마스터 수준의 플레이스홀더를 정의합니다.
2. 레이아웃 슬라이드는 하나 이상의 일반 슬라이드가 사용하는 배치를 정의하며 마스터로부터 상속받을 수 있습니다.
3. 일반 슬라이드는 해당 슬라이드의 플레이스홀더를 포함하고 레이아웃으로부터 상속받을 수 있습니다.

[Shape.get_base_placeholder](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/get_base_placeholder/)을 호출하면 이 계층 구조에서 한 단계 위로 이동합니다. 슬라이드 플레이스홀더는 일반적으로 레이아웃 플레이스홀더를 반환하고, 레이아웃 플레이스홀더는 마스터 플레이스홀더를 반환할 수 있습니다. 도형에 기본 플레이스홀더가 없으면 메서드는 `None`을 반환합니다.

다음 예제는 첫 번째 슬라이드의 플레이스홀더를 나열하고 해당 기본 플레이스홀더를 보고합니다:

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

일반 슬라이드에서 플레이스홀더를 편집하면 해당 슬라이드에 대한 로컬 오버라이드가 생성되거나 변경됩니다. 관련 레이아웃이나 마스터를 편집하면 해당 설정을 상속받는 모든 슬라이드에 영향을 줄 수 있습니다. 로컬 일반 도형은 기본 플레이스홀더가 없으며 동일한 좌표에 위치한다고 해서 상속을 시작하지 않습니다.

## **플레이스홀더 텍스트 변경**

제목, 중앙 제목, 부제목, 본문 및 텍스트 플레이스홀더는 일반적으로 텍스트를 지원합니다. 해당 도형의 [text_frame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/text_frame/) 속성을 사용하기 전에 [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/)인지 확인하세요.

다음 예제는 첫 번째 슬라이드의 첫 번째 제목 플레이스홀더를 업데이트하고 결과를 저장합니다:

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

이 패턴은 그림, 차트, 표 또는 미디어 플레이스홀더를 [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/) 객체로 취급하는 것을 방지합니다. 또한 불안정한 도형 인덱스에 의존하지 않고 목적에 따라 플레이스홀더를 식별합니다.

## **레이아웃에 프롬프트 텍스트 설정**

프롬프트 텍스트는 빈 플레이스홀더에 표시되는 디자인‑타임 지시문으로, 예를 들어 *제목을 추가하려면 클릭*과 같습니다. 일반 슬라이드의 도형 컬렉션을 통해 접근하려 하지 말고 레이아웃 플레이스홀더에 사용자 지정 프롬프트 텍스트를 설정하세요. 레이아웃은 [Slide.layout_slide](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slide/layout_slide/)을 통해 접근하고 [LayoutSlide.shapes](https://reference.aspose.com/slides/ko/python-net/aspose.slides/baseslide/shapes/)를 순회합니다.

다음 예제는 첫 번째 슬라이드가 사용하는 레이아웃의 제목 및 부제목 프롬프트를 변경합니다:

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

프롬프트 텍스트는 일반 슬라이드 콘텐츠가 아닙니다. PowerPoint와 같은 편집 애플리케이션에서 빈 플레이스홀더에 표시하도록 설계되었습니다. 사용자가 실제 콘텐츠를 제공하면 프롬프트는 더 이상 표시되지 않습니다. 프롬프트를 변경해도 해당 레이아웃을 사용하는 슬라이드의 기존 텍스트가 교체되지 않습니다.

## **그림 플레이스홀더 업데이트**

다음 두 경우를 처리해야 합니다:

- 그림 플레이스홀더가 이미 채워져 있고 [PictureFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pictureframe/)으로 표시되는 경우, [PictureFillFormat.picture](https://reference.aspose.com/slides/ko/python-net/aspose.slides/picturefillformat/picture/) 및 [Picture.image](https://reference.aspose.com/slides/ko/python-net/aspose.slides/picture/image/)을 통해 이미지를 교체합니다.
- 아직 빈 플레이스홀더인 경우, [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapecollection/add_picture_frame/)을 사용해 플레이스홀더 좌표에 그림 프레임을 추가하고 빈 플레이스홀더를 제거합니다.

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

빈 플레이스홀더에 대해 만든 교체물은 새로운 플레이스홀더가 아니라 로컬 그림 프레임이며, 이는 [Shape.placeholder](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/placeholder/)이 읽기 전용이기 때문입니다. 예약된 위치는 유지하지만 플레이스홀더 고유 동작을 더 이상 상속하지 않습니다. 플레이스홀더 관계를 유지해야 한다면 먼저 PowerPoint에서 플레이스홀더를 준비하고 채운 다음, Aspose.Slides로 결과 [PictureFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pictureframe/)을 업데이트하십시오.

이미지 투명도, 자르기 및 기타 그림 전용 효과에 대해서는 [Manage Picture Frames](/slides/ko/python-net/picture-frame/)를 참조하십시오. 이러한 작업은 플레이스홀더 메타데이터가 아니라 그림 프레임 또는 그림 채우기에 적용됩니다.

## **차트 및 콘텐츠 플레이스홀더 작업**

채워진 차트 플레이스홀더는 [Chart](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chart/)으로 나타낼 수 있습니다. 이 예제는 플레이스홀더 유형과 런타임 클래스를 모두 확인하여 차트를 찾고, 제목을 변경한 뒤 파일을 저장합니다:

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

일반 콘텐츠 플레이스홀더는 보통 [PlaceholderType.OBJECT](https://reference.aspose.com/slides/ko/python-net/aspose.slides/placeholdertype/)를 가집니다. PowerPoint에서는 차트, 표, 다이어그램, 그림 및 미디어 등 여러 콘텐츠 유형을 시작하는 역할을 합니다. 채워진 후에는 실제 도형 클래스를 검사하여 포함된 내용을 확인하십시오. 특수 레이아웃에서는 [PlaceholderType.CHART](https://reference.aspose.com/slides/ko/python-net/aspose.slides/placeholdertype/), [PlaceholderType.TABLE](https://reference.aspose.com/slides/ko/python-net/aspose.slides/placeholdertype/), [PlaceholderType.PICTURE](https://reference.aspose.com/slides/ko/python-net/aspose.slides/placeholdertype/), [PlaceholderType.MEDIA](https://reference.aspose.com/slides/ko/python-net/aspose.slides/placeholdertype/), 또는 [PlaceholderType.DIAGRAM](https://reference.aspose.com/slides/ko/python-net/aspose.slides/placeholdertype/)을 노출할 수 있습니다.

Aspose.Slides는 [Placeholder.type](https://reference.aspose.com/slides/ko/python-net/aspose.slides/placeholder/type/)을 변경한다는 이유만으로 빈 [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/) 플레이스홀더를 [Chart](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chart/)로 변환하지 않습니다; 유형은 읽기 전용입니다. 빈 차트나 콘텐츠 영역을 프로그래밍 방식으로 채우려면 플레이스홀더 좌표에 필요한 객체를 추가한 뒤 빈 플레이스홀더를 제거하십시오. 다음 예제는 차트에 대해 이를 수행합니다:

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

추가된 차트는 일반 로컬 차트이며, 플레이스홀더 영역을 차지하지만 레이아웃 플레이스홀더를 상속하지 않습니다. 차트의 범주, 시리즈 또는 워크북 데이터를 교체해야 할 경우 전용 [chart management articles](/slides/ko/python-net/powerpoint-charts/)를 사용하십시오.

## **전체 예제: 텍스트 또는 이미지 콘텐츠 업데이트**

다음 전체 예제는 템플릿을 열고 첫 번째 슬라이드에서 제목 또는 그림 플레이스홀더를 검색한 뒤, 플레이스홀더와 도형 유형을 확인하고 적절한 콘텐츠를 업데이트한 뒤 결과를 저장합니다. 이 예제는 도형 인덱스를 가정하거나 모든 플레이스홀더를 동일한 도형 클래스로 취급하지 않도록 의도적으로 작성되었습니다.

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

**기본 플레이스홀더란 무엇입니까?**

기본 플레이스홀더는 다른 플레이스홀더가 상속받는 레이아웃 또는 마스터상의 해당 도형을 말합니다. 이를 가져오려면 [Shape.get_base_placeholder](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/get_base_placeholder/)을 사용하십시오. 일반 로컬 도형은 플레이스홀더 계층 구조에 포함되지 않으므로 `None`을 반환합니다.

**레이아웃 플레이스홀더를 편집하여 모든 슬라이드 제목을 변경할 수 있습니까?**

레이아웃을 통해 상속된 서식이나 프롬프트 텍스트는 변경할 수 있지만, 기존 제목 내용은 일반 슬라이드에 저장됩니다. 프레젠테이션 전체의 실제 제목 텍스트를 교체하려면 슬라이드를 순회하면서 각 제목 플레이스홀더를 업데이트하십시오.

**날짜, 슬라이드 번호, 헤더 및 푸터 플레이스홀더를 어떻게 관리합니까?**

해당 슬라이드, 레이아웃, 마스터, 노트 또는 유인물 범위에서 헤더 및 푸터 관리자를 사용하십시오. 전체 예시는 [Manage Presentation Header and Footer](/slides/ko/python-net/presentation-header-and-footer/)를 참조하세요.