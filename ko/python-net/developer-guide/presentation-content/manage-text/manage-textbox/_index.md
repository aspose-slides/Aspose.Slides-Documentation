---
title: Python으로 프레젠테이션 텍스트 상자 관리
linktitle: 텍스트 상자 관리
type: docs
weight: 20
url: /ko/python-net/manage-textbox/
keywords:
- 텍스트 상자
- 텍스트 프레임
- 텍스트 추가
- 텍스트 업데이트
- 텍스트 상자 만들기
- 텍스트 상자 확인
- 텍스트 열 추가
- 하이퍼링크 추가
- 파워포인트
- 프레젠테이션
- 파이썬
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션의 텍스트 상자를 생성하고, 식별하며, 서식 지정하고, 업데이트합니다."
---
## **소개**

Aspose.Slides for Python via .NET에서 슬라이드 텍스트는 도형에 속하는 텍스트 프레임에 저장됩니다. [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/) 클래스는 가장 일반적인 텍스트가 포함된 도형을 나타내며, 해당 텍스트를 [AutoShape.text_frame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/text_frame/) 속성을 통해 노출합니다.

{{% alert color="info" title="Note" %}}
모든 자동 도형은 [Shape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/)을 상속하지만, 모든 도형이 자동 도형이거나 텍스트 프레임을 지원하는 것은 아닙니다. 기존 프레젠테이션을 처리할 때는 텍스트에 접근하기 전에 `isinstance(shape, slides.AutoShape)`를 사용하여 도형 유형을 확인하십시오.
{{% /alert %}}

## **슬라이드에 텍스트 상자 만들기**

텍스트 상자를 만들려면 슬라이드에 자동 도형을 추가하고, 해당 텍스트 프레임에 텍스트를 추가한 뒤 프레젠테이션을 저장합니다. 다음 예제는 사각형 텍스트 상자를 생성합니다:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 300, 50)
    text_box.add_text_frame("Aspose TextBox")

    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

[ShapeCollection.add_auto_shape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapecollection/add_auto_shape/)에 전달되는 좌표와 크기는 포인트 단위로 측정됩니다. [AutoShape.add_text_frame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/add_text_frame/)은 제공된 텍스트로 텍스트 프레임을 초기화합니다.

## **텍스트 상자 도형 확인**

[AutoShape.is_text_box](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/is_text_box/) 속성을 사용하여 자동 도형이 텍스트 상자로 간주되는지 확인합니다. 프레젠테이션에 텍스트가 포함된 자동 도형과 순수 그래픽 자동 도형이 모두 포함된 경우에 유용합니다.

![텍스트 상자와 도형](istextbox.png)

다음 예제는 프레젠테이션의 모든 자동 도형을 검사합니다:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 120, 40)
    text_box.add_text_frame("Text box")
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 10, 40, 40)

    for current_slide in presentation.slides:
        for shape in current_slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("The shape is a text box." if shape.is_text_box else "The shape is not a text box.")
```

새로 추가된 자동 도형은 비어 있지 않은 텍스트를 포함하기 전까지는 텍스트 상자로 간주되지 않습니다. 해당 텍스트는 [AutoShape.add_text_frame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/add_text_frame/) 또는 [TextFrame.text](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/text/)을 통해 제공할 수 있습니다. 빈 문자열을 추가하거나 할당하면 [is_text_box](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/is_text_box/)이 `False`로 설정됩니다:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    shape1.add_text_frame("Shape 1")
    print(shape1.is_text_box)

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 100, 40)
    shape2.text_frame.text = "Shape 2"
    print(shape2.is_text_box)

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 100, 40)
    shape3.add_text_frame("")
    print(shape3.is_text_box)

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 100, 40)
    shape4.text_frame.text = ""
    print(shape4.is_text_box)
```

첫 번째와 두 번째 호출은 `True`를 출력하고, 마지막 두 호출은 `False`를 출력합니다.

## **텍스트 프레임을 소유하는 도형 찾기**

일반 텍스트 처리 코드는 해당 텍스트 프레임을 포함하는 프레젠테이션 객체를 알지 못한 채 [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/)을 받을 수 있습니다. 읽기 전용 [TextFrame.parent_shape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/parent_shape/) 속성을 사용하여 해당 프레임을 소유한 [Shape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/)으로 되돌아갈 수 있습니다.

자동 도형이나 다른 텍스트가 포함된 도형이 소유한 텍스트 프레임의 경우, [parent_shape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/parent_shape/)에 소유자가 들어 있고 [TextFrame.parent_cell](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/parent_cell/)은 `None`입니다. 접근하기 전에 반환 값을 확인하십시오. 도형 및 테이블 셀 소유자를 모두 식별하려면, SmartArt 노드와 연결된 도형을 포함하여, [Search and Replace Text](/slides/ko/python-net/search-and-replace-text/)를 참조하십시오.

## **텍스트 상자에 열 추가**

[TextFrameFormat.column_count](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframeformat/column_count/) 속성은 텍스트 프레임을 여러 열로 나누고, [TextFrameFormat.column_spacing](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframeformat/column_spacing/) 속성은 열 사이의 간격을 포인트 단위로 설정합니다. 두 설정은 [TextFrameFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframeformat/)에 속하며 기존 텍스트 상자의 텍스트 프레임을 통해 변경할 수 있습니다. 텍스트는 동일한 도형 내에서 열 사이에 재배치되며, 다른 도형으로 이어지지는 않습니다.

다음 예제는 열 사이에 10포인트 간격을 두고 3열 텍스트 상자를 생성한 뒤 프레젠테이션을 저장하고, 출력 파일에서 저장된 설정을 다시 읽어옵니다:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 200)
    text_box.add_text_frame("This text is distributed automatically across all columns in the text box.")

    text_frame_format = text_box.text_frame.text_frame_format
    text_frame_format.column_count = 3
    text_frame_format.column_spacing = 10

    presentation.save("TextBoxColumns.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("TextBoxColumns.pptx") as saved_presentation:
    saved_text_box = saved_presentation.slides[0].shapes[0]
    if isinstance(saved_text_box, slides.AutoShape):
        saved_format = saved_text_box.text_frame.text_frame_format
        print(f"Columns: {saved_format.column_count}; spacing: {saved_format.column_spacing} points")
```

## **개별 열에서 텍스트 추출**

기존 텍스트 프레임에서 각 시각적 열에 할당된 텍스트를 가져오려면 [TextFrame.split_text_by_columns](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/split_text_by_columns/)을 사용합니다. 이 메서드는 열 기반 읽기 순서대로 각 열에 대해 문자열 하나를 반환합니다. 단일 열 텍스트 프레임은 하나의 요소가 있는 리스트를 생성하고, 빈 열은 빈 문자열로 표시됩니다. 반환된 문자열은 일반 텍스트만 포함하며, 부분 수준 서식은 보존되지 않습니다.

다음과 같은 경우에 유용합니다:
- 열 기반 읽기 순서를 유지하면서 텍스트 추출.
- 다중 열 슬라이드의 내용을 인덱싱하거나 비교.
- 각 열을 별도의 파일, 데이터베이스 필드 또는 다른 대상에 내보내기.
- 폰트, 텍스트 프레임 크기 또는 [TextFrameFormat.column_count](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframeformat/column_count/), [TextFrameFormat.column_spacing](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframeformat/column_spacing/)을 변경한 후 텍스트가 어떻게 재배치되는지 확인.

이 메서드는 현재 [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/) 내에 배분된 텍스트를 보고하며, 별도의 도형이나 텍스트 상자 사이에 텍스트를 자동으로 흐르게 하지 않습니다. 열 배분은 사용 가능한 폰트 및 기타 텍스트 레이아웃 설정에 따라 달라질 수 있으므로, 일관된 결과가 필요할 때는 필요한 폰트가 제공되는지 확인하십시오.

다음 예제는 프레젠테이션을 로드하고, 텍스트 프레임이 있는 첫 번째 다중 열 자동 도형을 찾아 구성된 열 수를 읽은 뒤 각 열의 텍스트를 별도의 파일에 기록합니다. 텍스트 프레임을 제공하지 않는 도형은 건너뜁니다.

```python
import aspose.slides as slides

with slides.Presentation("MultiColumnText.pptx") as presentation:
    text_box = None
    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
            column_count = shape.text_frame.text_frame_format.column_count
            if column_count > 1:
                text_box = shape
                break

    if text_box is None:
        print("No multi-column text frame was found.")
    else:
        text_frame = text_box.text_frame
        configured_column_count = text_frame.text_frame_format.column_count
        column_texts = text_frame.split_text_by_columns()

        print(f"Configured columns: {configured_column_count}")

        for column_number, column_text in enumerate(column_texts, start=1):
            print(f"Column {column_number}: {column_text}")
            with open(f"Column-{column_number}.txt", "w", encoding="utf-8") as column_file:
                column_file.write(column_text)
```

## **텍스트 업데이트**

프레젠테이션 전체의 텍스트를 업데이트하려면 슬라이드와 도형을 반복하고, 자동 도형을 선택한 후 텍스트 부분을 편집합니다. 부분 수준에서 작업하면 텍스트와 문자 서식을 모두 변경할 수 있습니다.

다음 예제는 자동 도형 텍스트에서 `years`를 모두 `months`로 교체하고, 영향을 받은 각 부분을 굵게 만듭니다:

```python
import aspose.slides as slides

with slides.Presentation("Text.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    if "years" in portion.text:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

이 순회는 자동 도형의 텍스트만 업데이트합니다. 표, 차트, SmartArt 또는 그룹화된 도형에 저장된 텍스트는 해당 객체의 컬렉션을 순회해야 합니다.

## **하이퍼링크가 포함된 텍스트 상자 추가**

하이퍼링크는 특정 텍스트 부분에 할당할 수 있으므로 해당 텍스트만 클릭 가능한 링크가 됩니다. [HyperlinkManager.set_external_hyperlink_click](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/)을 사용하여 해당 부분을 외부 URL과 연결합니다.

다음 예제는 연결된 텍스트를 생성하고 프레젠테이션에 저장합니다:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 200, 50)
    text_box.add_text_frame("Aspose.Slides")

    text_portion = text_box.text_frame.paragraphs[0].portions[0]
    text_portion.portion_format.hyperlink_manager.set_external_hyperlink_click("https://www.aspose.com/")

    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**텍스트 상자와 마스터 또는 레이아웃 슬라이드의 텍스트 플레이스홀더의 차이점은 무엇인가요?**

[placeholder](/slides/ko/python-net/manage-placeholder/)는 [master slide](https://reference.aspose.com/slides/ko/python-net/aspose.slides/masterslide/) 또는 [layout slide](https://reference.aspose.com/slides/ko/python-net/aspose.slides/layoutslide/)로부터 위치와 서식을 상속받을 수 있습니다. 일반 텍스트 상자는 생성된 슬라이드에 독립적인 도형이며, 레이아웃이 변경될 때 플레이스홀더 동작을 취득하지 않습니다.

**차트, 표 또는 SmartArt의 텍스트를 변경하지 않고 텍스트를 교체하려면 어떻게 해야 하나요?**

Update Text 예제와 같이 순회를 [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/) 인스턴스로 제한하십시오. 차트, 표 및 SmartArt는 자체 객체 모델에 텍스트를 저장하므로 해당 루프에 의해 수정되지 않습니다.