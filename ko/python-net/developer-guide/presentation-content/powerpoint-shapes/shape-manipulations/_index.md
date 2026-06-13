---
title: Python을 사용하여 프레젠테이션에서 도형 관리
linktitle: 도형 조작
type: docs
weight: 40
url: /ko/python-net/shape-manipulations/
keywords:
- PowerPoint 도형
- 프레젠테이션 도형
- 슬라이드의 도형
- 도형 찾기
- 도형 복제
- 도형 삭제
- 도형 숨기기
- 도형 순서 변경
- Interop 도형 ID 가져오기
- 도형 대체 텍스트
- 도형 레이아웃 서식
- SVG 형식 도형
- 도형을 SVG로 변환
- 도형 정렬
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python을 .NET을 통해 사용하여 도형을 만들고, 편집하며 최적화하는 방법을 배우고, 고성능 PowerPoint 및 OpenDocument 프레젠테이션을 제공합니다."
---
## **개요**

이 가이드는 .NET을 통한 Python용 Aspose.Slides의 도형 조작을 소개합니다. 대체 텍스트를 이용한 도형 찾기, 복제, 삭제 또는 숨기기, 순서 재배열, 정렬 및 뒤집기, ID 읽기와 레이아웃 기반 서식 지정, 그리고 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 및 [Shape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/) API를 사용한 개별 도형을 SVG로 내보내는 실용적인 패턴을 배웁니다.

## **슬라이드에서 도형 찾기**

PowerPoint는 도형을 내부 ID로만 식별합니다. PowerPoint에서 대상 도형에 고유한 대체 텍스트를 지정한 후, Aspose.Slides for Python으로 프레젠테이션을 열고 슬라이드 도형을 반복하면서 대체 텍스트가 일치하는 도형을 선택합니다. `find_shape` 메서드가 이 접근 방식을 구현하며 일치하는 도형을 반환합니다.

```py
import aspose.slides as slides

# 슬라이드에서 대체 텍스트로 도형을 찾습니다.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Alt Text "Shape1"인 도형을 찾습니다.
    shape = find_shape(slide, "Shape1")
    if shape is not None:
        print("Shape name:", shape.name)
```

## **도형 복제**

Aspose.Slides에서 원본 슬라이드의 도형을 새 슬라이드로 복제하려면 다음 단계에 따라 진행하십시오:

1. 원본 파일에서 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/)을 생성합니다.
1. 인덱스로 원본 슬라이드를 가져오고 해당 슬라이드의 도형 컬렉션을 가져옵니다.
1. 마스터 슬라이드에서 빈 레이아웃을 검색합니다.
1. 해당 레이아웃을 사용하여 빈 슬라이드를 추가하고 그 슬라이드의 도형을 가져옵니다.
1. 도형을 대상 슬라이드로 복제합니다.
1. 프레젠테이션을 PPTX 형식으로 저장합니다.

다음 코드 예제는 한 슬라이드에서 다른 슬라이드로 도형을 복제합니다.

```py
import aspose.slides as slides

# Presentation 클래스를 인스턴스화합니다.
with slides.Presentation("sample.pptx") as presentation:
    source_shapes = presentation.slides[0].shapes
    blank_layout = presentation.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    target_slide = presentation.slides.add_empty_slide(blank_layout)
    target_shapes = target_slide.shapes
	
    target_shapes.add_clone(source_shapes[1], 50, 150 + source_shapes[0].height)
    target_shapes.add_clone(source_shapes[2])
    target_shapes.insert_clone(0, source_shapes[0], 50, 150)

    # 프레젠테이션을 디스크에 저장합니다.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **도형 삭제**

Aspose.Slides를 사용하면 슬라이드에서 任意의 도형을 삭제할 수 있습니다. 예를 들어 첫 번째 슬라이드에서 대체 텍스트를 사용해 도형을 삭제하려면 다음 단계에 따라 진행하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 인스턴스를 생성하고 파일을 로드합니다.
1. 슬라이드 컬렉션에서 첫 번째 슬라이드에 접근합니다.
1. 대체 텍스트 값으로 도형을 찾습니다.
1. 슬라이드의 도형 컬렉션에서 해당 도형을 제거합니다.
1. 프레젠테이션을 PPTX 형식으로 디스크에 저장합니다.

```py
import aspose.slides as slides

# 슬라이드에서 대체 텍스트로 도형을 찾습니다.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Alt Text "User Defined"인 도형을 찾습니다.
    shape = find_shape(slide, "User Defined")
    # 도형을 삭제합니다.
    slide.shapes.remove(shape)
    # 프레젠테이션을 디스크에 저장합니다.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **도형 숨기기**

Aspose.Slides를 사용하면 슬라이드에서 任意의 도형을 숨길 수 있습니다. 예를 들어 첫 번째 슬라이드에서 대체 텍스트를 사용해 도형을 숨기려면 다음 단계에 따라 진행하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 인스턴스를 생성하고 파일을 로드합니다.
1. 슬라이드 컬렉션에서 첫 번째 슬라이드에 접근합니다.
1. 대체 텍스트 값으로 도형을 찾습니다.
1. 도형을 숨깁니다.
1. 프레젠테이션을 PPTX 형식으로 디스크에 저장합니다.

```py
# 슬라이드에서 대체 텍스트로 도형을 찾습니다.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Alt Text "User Defined"인 도형을 찾습니다.
    shape = find_shape(slide, "User Defined")
    # 도형을 숨깁니다.
    shape.hidden = True
    # 프레젠테이션을 디스크에 저장합니다.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **도형 순서 변경**

Aspose.Slides는 개발자가 도형의 Z-순서를 재배열할 수 있게 합니다. 재배열은 어느 도형이 앞에, 뒤에 표시될지를 결정합니다. 예를 들어 첫 번째 슬라이드에서 두 개의 도형 순서를 바꾸려면 다음 단계를 따르십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 첫 번째 슬라이드에 접근합니다.
1. 첫 번째 도형(예: 사각형)을 추가합니다.
1. 두 번째 도형(예: 삼각형)을 추가합니다.
1. 컬렉션에서 두 번째 도형을 첫 번째 위치로 이동시켜 순서를 재배열합니다.
1. 프레젠테이션을 디스크에 저장합니다.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # 슬라이드에 두 개의 도형을 추가합니다.
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 150)
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 20, 200, 200, 150)
    # 두 번째 도형을 첫 번째 위치로 이동합니다.
    slide.shapes.reorder(0, shape2)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Interop 도형 ID 가져오기**

Aspose.Slides를 사용하면 슬라이드 범위에서 도형의 고유 식별자를 얻을 수 있습니다. 전체 프레젠테이션에서 고유한 `unique_id` 속성과 달리, `office_interop_shape_id` 속성은 [Shape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/) 클래스에 제공됩니다. 이 값은 `Microsoft.Office.Interop.PowerPoint.Shape` 객체의 `Id`와 대응합니다. 아래에 샘플 코드 조각이 표시됩니다.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # 슬라이드 내에서 도형의 고유 식별자를 가져옵니다.
    officeInteropShapeId = presentation.slides[0].shapes[0].office_interop_shape_id
```

## **도형의 대체 텍스트 설정**

Aspose.Slides를 사용하면 任意의 도형에 대체 텍스트를 설정할 수 있습니다. 대체 텍스트를 이용해 프레젠테이션 내 도형을 식별하고 찾아낼 수 있습니다. 이 속성은 Aspose.Slides와 Microsoft PowerPoint 모두에서 읽고 쓸 수 있습니다. 도형에 이 속성을 태깅하면 나중에 슬라이드에서 해당 도형을 삭제, 숨기기 또는 순서 변경할 수 있습니다.

대체 텍스트를 설정하려면 다음 단계를 따르십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 첫 번째 슬라이드에 접근합니다.
1. 슬라이드에 도형을 추가합니다.
1. 대체 텍스트를 설정합니다.
1. 프레젠테이션을 디스크에 저장합니다.

```py
import aspose.slides as slides

# PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    # 도형을 추가합니다.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 40, 150, 50)
    # 도형의 대체 텍스트를 설정합니다.
    shape.alternative_text = "User Defined"
    # 프레젠테이션을 디스크에 저장합니다.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **도형의 레이아웃 서식 접근**

Aspose.Slides는 도형의 레이아웃 서식에 접근하기 위한 간단한 API를 제공합니다. 이 섹션에서는 레이아웃 서식에 접근하는 방법을 시연합니다.

```py
import aspose.slides as slides

with slides.Presentation(folder_path + "sample.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        fill_formats = list(map(lambda shape: shape.fill_format, layout_slide.shapes))
        line_formats = list(map(lambda shape: shape.line_format, layout_slide.shapes))
```

## **도형을 SVG로 렌더링**

Aspose.Slides는 도형을 SVG 형식으로 렌더링하는 기능을 지원합니다. [Shape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/) 클래스의 `write_as_svg` 메서드(및 오버로드)를 사용하면 도형의 내용을 SVG 이미지로 저장할 수 있습니다. 아래 코드 조각은 도형을 SVG 파일로 내보내는 예시를 보여줍니다.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    with open("output.svg", "wb") as image_stream:
        # 첫 번째 슬라이드의 첫 번째 도형을 가져옵니다.
        shape = presentation.slides[0].shapes[0]
        shape.write_as_svg(image_stream)
```

## **도형 정렬**

[SlidesUtil](https://reference.aspose.com/slides/ko/python-net/aspose.slides.util/slideutil/) 클래스의 `align_shape` 메서드를 사용하면 다음을 수행할 수 있습니다:

* 슬라이드 여백을 기준으로 도형을 정렬합니다(예제 1 참조).
* 도형 간의 상대적인 정렬을 수행합니다(예제 2 참조).

[ShapesAlignmentType](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapesalignmenttype/) 열거형은 사용 가능한 정렬 옵션을 정의합니다.

**예제 1**

다음 Python 코드는 인덱스 1, 2, 4인 도형을 슬라이드 상단 가장자리와 정렬합니다:

```py
import aspose.slides as slides

align_type = slides.ShapesAlignmentType.ALIGN_TOP
slide_indices = [1, 2, 4]

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    slides.util.SlideUtil.align_shapes(align_type, True, slide, slide_indices)
```

**예제 2**

다음 Python 예제는 컬렉션에 포함된 모든 도형을 해당 컬렉션에서 가장 아래쪽에 있는 도형을 기준으로 정렬합니다:

```py
import aspose.slides as slides

align_type = slides.ShapesAlignmentType.ALIGN_BOTTOM

with slides.Presentation("sample.pptx") as presentation:
    slides.util.SlideUtil.align_shapes(align_type, False, presentation.slides[0])
```

## **뒤집기 속성**

Aspose.Slides에서 [ShapeFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapeframe/) 클래스는 `flip_h`와 `flip_v` 속성을 통해 도형의 수평 및 수직 미러링을 제어합니다. 두 속성 모두 [NullableBool](https://reference.aspose.com/slides/ko/python-net/aspose.slides/nullablebool/) 유형이며 `TRUE`는 뒤집힘, `FALSE`는 미뒤집힘, `NOT_DEFINED`는 기본 동작을 의미합니다. 이러한 값은 도형의 [Frame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/frame/)에서 접근할 수 있습니다.

뒤집기 설정을 수정하려면 도형의 현재 위치와 크기, 원하는 `flip_h`·`flip_v` 값 및 회전 각도를 사용해 새로운 [ShapeFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapeframe/) 인스턴스를 구성합니다. 이 인스턴스를 도형의 [Frame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/frame/)에 할당하고 프레젠테이션을 저장하면 미러 변환이 적용되어 출력 파일에 반영됩니다.

예를 들어, 첫 번째 슬라이드에 기본 뒤집기 설정을 가진 단일 도형이 포함된 sample.pptx 파일이 있다고 가정합니다.

![플립될 도형](shape_to_be_flipped.png)

다음 코드 예제는 도형의 현재 뒤집기 속성을 가져와 수평 및 수직으로 모두 뒤집습니다.

```py
with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    # 도형의 수평 플립 속성을 가져옵니다.
    horizontal_flip = shape.frame.flip_h
    print("Horizontal flip:", horizontal_flip)

    # 도형의 수직 플립 속성을 가져옵니다.
    vertical_flip = shape.frame.flip_v
    print("Vertical flip:", vertical_flip)

    x, y = shape.frame.x, shape.frame.y
    width, height = shape.frame.width, shape.frame.height
    flip_h, flip_v = slides.NullableBool.TRUE, slides.NullableBool.TRUE  # 수평 및 수직으로 플립합니다.
    rotation = shape.frame.rotation

    shape.frame = slides.ShapeFrame(x, y, width, height, flip_h, flip_v, rotation)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![플립된 도형](flipped_shape.png)

## **FAQ**

**슬라이드에서 도형을 결합(합집합/교집합/차집합)할 수 있나요?**  
내장된 Boolean 연산 API는 제공되지 않습니다. 원하는 윤곽선을 직접 구성하여 근사화할 수 있습니다—예를 들어 [GeometryPath](https://reference.aspose.com/slides/ko/python-net/aspose.slides/geometrypath/)를 사용해 결과 기하형을 계산하고 해당 외곽선으로 새 도형을 만든 뒤 원본을 선택적으로 삭제합니다.

**도형이 항상 “맨 위”에 있도록 스택 순서(z-order)를 제어하려면 어떻게 해야 하나요?**  
슬라이드의 [shapes](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slide/shapes/) 컬렉션 내 삽입/이동 순서를 변경합니다. 예측 가능한 결과를 위해 다른 슬라이드 수정 작업을 모두 마친 후 z-order를 최종 확정하십시오.

**PowerPoint에서 사용자가 도형을 편집하지 못하도록 “잠금”할 수 있나요?**  
예. [shape-level protection flags](/slides/ko/python-net/applying-protection-to-presentation/)를 설정하면 선택, 이동, 크기 조정, 텍스트 편집 등을 잠글 수 있습니다. 필요에 따라 마스터나 레이아웃에 제한을 적용할 수도 있습니다. 이는 UI 수준의 보호이며 보안 기능은 아닙니다; 보다 강력한 보호를 위해 [읽기 전용 권장 사항이나 비밀번호](/slides/ko/python-net/password-protected-presentation/)와 같은 파일 수준 제한과 결합하십시오.