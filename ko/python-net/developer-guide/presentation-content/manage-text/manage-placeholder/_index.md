---
title: Python으로 프레젠테이션에서 플레이스홀더 관리
linktitle: 플레이스홀더 관리
type: docs
weight: 10
url: /ko/python-net/manage-placeholder/
keywords:
- 플레이스홀더
- 텍스트 플레이스홀더
- 이미지 플레이스홀더
- 차트 플레이스홀더
- 프롬프트 텍스트
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: ".NET을 통해 Python용 Aspose.Slides에서 플레이스홀더를 손쉽게 관리하십시오: 텍스트 교체, 프롬프트 사용자 지정 및 PowerPoint와 OpenDocument에서 이미지 투명도 설정."
---
## **개요**

Aspose.Slides를 사용하면 프레젠테이션 플레이스홀더를 프로그래밍 방식으로 관리할 수 있습니다. 이 문서에서는 슬라이드에서 플레이스홀더를 찾고 텍스트를 변경하는 방법, 플레이스홀더 레이아웃에 사용자 지정 프롬프트 텍스트를 설정하는 방법, 플레이스홀더 배경으로 사용되는 이미지의 투명도를 조정하는 방법을 설명합니다. 또한 기본 플레이스홀더와 로컬 도형의 차이점을 명확히 하고, 레이아웃이나 마스터를 통해 플레이스홀더 변경을 적용하는 방법, 헤더 및 푸터 플레이스홀더 관리에 대한 짧은 FAQ도 포함합니다.

## **플레이스홀더 텍스트 변경**

Aspose.Slides for Python을 사용하면 프레젠테이션 슬라이드에서 플레이스홀더를 찾고 수정할 수 있습니다. Aspose.Slides를 사용하면 플레이스홀더의 텍스트를 수정할 수 있습니다.

**Prerequisite:** 플레이스홀더가 포함된 프레젠테이션이 필요합니다. 이러한 프레젠테이션은 Microsoft PowerPoint에서 만들 수 있습니다.

플레이스홀더의 텍스트를 교체하는 방법은 다음과 같습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스를 인스턴스화하고 프레젠테이션을 인수로 전달합니다.
1. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. 도형을 반복하여 플레이스홀더를 찾습니다.
1. [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/)와 연결된 [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/)을 사용해 텍스트를 변경합니다.
1. 수정된 프레젠테이션을 저장합니다.

```python
import aspose.slides as slides

# Presentation 클래스를 인스턴스화합니다.
with slides.Presentation("ReplacingText.pptx") as presentation:
    # 첫 번째 슬라이드에 접근합니다.
    slide = presentation.slides[0]

    # 도형을 반복하여 플레이스홀더를 찾습니다.
    for shape in slide.shapes:
        if shape.placeholder is not None:
            # 각 플레이스홀더의 텍스트를 변경합니다.
            shape.text_frame.text = "This is Placeholder"

    # 프레젠테이션을 디스크에 저장합니다.
    presentation.save("ReplacingText_out.pptx", slides.export.SaveFormat.PPTX)
```

## **플레이스홀더에 프롬프트 텍스트 설정**

표준 및 미리 만든 레이아웃에는 **Click to add a title** 또는 **Click to add a subtitle**과 같은 플레이스홀더 프롬프트 텍스트가 포함됩니다. Aspose.Slides를 사용하면 이러한 프롬프트를 플레이스홀더 레이아웃에서 원하는 텍스트로 교체할 수 있습니다.

다음 Python 예제는 플레이스홀더에 프롬프트 텍스트를 설정하는 방법을 보여줍니다:

```python
import aspose.slides as slides

with slides.Presentation("PromptText.pptx") as presentation:
    slide = presentation.slides[0]

    # 도형을 반복하여 플레이스홀더를 찾습니다.
    for shape in slide.slide.shapes:
        if shape.placeholder is not None and type(shape) is slides.AutoShape:
            if shape.placeholder.type == slides.PlaceholderType.CENTERED_TITLE:
                text = "Add Title"
            elif shape.placeholder.type == slides.PlaceholderType.SUBTITLE:
                text = "Add Subtitle"

            shape.text_frame.text = text
            print(f"Placeholder with text: {text}")

    presentation.save("PromptText_out.pptx", slides.export.SaveFormat.PPTX)
```

## **플레이스홀더에서 이미지 투명도 설정**

Aspose.Slides를 사용하면 텍스트 플레이스홀더의 배경 이미지 투명도를 설정할 수 있습니다. 해당 프레임에서 이미지 투명도를 조정하면 색상에 따라 텍스트 또는 이미지가 돋보이게 할 수 있습니다.

다음 Python 예제는 도형 내부의 이미지 배경 투명도를 설정하는 방법을 보여줍니다:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    auto_shape.fill_format.fill_type = slides.FillType.PICTURE

    with open("image.png", "rb") as image_stream:
        auto_shape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(image_stream)
        auto_shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        auto_shape.fill_format.picture_fill_format.picture.image_transform.add_alpha_modulate_fixed_effect(75)
```

## **FAQ**

**베이스 플레이스홀더란 무엇이며 슬라이드의 로컬 도형과 어떻게 다른가요?**

베이스 플레이스홀더는 레이아웃 또는 마스터에 있는 원본 도형으로, 슬라이드의 도형이 유형, 위치 및 일부 서식을 상속받습니다. 로컬 도형은 독립적이며, 베이스 플레이스홀더가 없으면 상속이 적용되지 않습니다.

**프레젠테이션 전체의 모든 제목이나 캡션을 모든 슬라이드를 반복하지 않고 어떻게 업데이트할 수 있나요?**

레이아웃이나 마스터에 해당 플레이스홀더를 편집합니다. 해당 레이아웃/마스터를 기반으로 한 슬라이드가 자동으로 변경 사항을 상속합니다.

**표준 헤더/푸터 플레이스홀더(날짜 및 시간, 슬라이드 번호, 푸터 텍스트)를 어떻게 제어하나요?**

적절한 범위(일반 슬라이드, 레이아웃, 마스터, 노트/핸드아웃)에서 HeaderFooter 관리자를 사용하여 해당 플레이스홀더를 켜거나 끄고 내용을 설정합니다.