---
title: Python을 사용하여 프레젠테이션에서 텍스트 상자 관리
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
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET을 사용하면 PowerPoint 및 OpenDocument 파일에서 텍스트 상자를 쉽게 만들고, 편집하고, 복제할 수 있어 프레젠테이션 자동화를 향상시킵니다."
---
## **소개**

슬라이드의 텍스트는 일반적으로 텍스트 상자나 도형에 존재합니다. 따라서 슬라이드에 텍스트를 추가하려면 텍스트 상자를 추가한 다음 텍스트 상자 안에 텍스트를 넣어야 합니다. Aspose.Slides for Python은 텍스트를 포함하는 도형을 추가할 수 있는 [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/) 클래스를 제공합니다.

{{% alert title="Info" color="info" %}}
Aspose.Slides는 또한 [Shape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/) 클래스를 제공합니다. 그러나 모든 도형이 텍스트를 보유할 수 있는 것은 아닙니다.
{{% /alert %}}

{{% alert title="Note" color="warning" %}}
따라서 텍스트를 추가하려는 도형을 다룰 때는 해당 도형이 [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/) 클래스로 캐스팅되었는지 확인하고 확인하고 싶을 수 있습니다. 그래야만 [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/) 아래의 속성인 [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/)을 사용할 수 있습니다. 이 페이지의 [Update Text](/slides/ko/python-net/manage-textbox/#update-text) 섹션을 확인하세요.
{{% /alert %}}

## **슬라이드에 텍스트 상자 만들기**

슬라이드에 텍스트 상자를 만들려면:

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 첫 번째 슬라이드에 대한 참조를 가져옵니다.
3. 원하는 위치에 `ShapeType.RECTANGLE` 를 사용하여 [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/)을 추가합니다.
4. 도형의 [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/)에 텍스트를 설정합니다.
5. 프레젠테이션을 PPTX 파일로 저장합니다.

다음 Python 예제가 이러한 단계를 구현합니다:

```py
import aspose.slides as slides

# 프레젠테이션 클래스를 인스턴스화합니다.
with slides.Presentation() as presentation:

    # 프레젠테이션의 첫 번째 슬라이드를 가져옵니다.
    slide = presentation.slides[0]

    # 유형이 RECTANGLE인 AutoShape를 추가합니다.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    shape.text_frame.text = "Aspose TextBox"

    # 프레젠테이션을 디스크에 저장합니다.
    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

## **도형이 텍스트 상자인지 확인하기**

Aspose.Slides는 [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/) 클래스에 [is_text_box](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/is_text_box/) 속성을 제공하며, 이를 통해 도형이 텍스트 상자인지 여부를 판단할 수 있습니다.

![텍스트 상자와 도형](istextbox.png)

다음 Python 예제는 도형이 텍스트 상자로 생성되었는지 확인하는 방법을 보여줍니다:

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("shape is a text box" if shape.is_text_box else "shape is not a text box")
```

참고로 [ShapeCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shapecollection/) 클래스를 사용하여 [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/)을 추가하면 해당 도형의 `is_text_box` 속성은 `False`를 반환합니다. 그러나 `add_text_frame` 메서드로 텍스트를 추가하거나 `text` 속성을 설정하면 `is_text_box`는 `True`를 반환합니다.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    # shape1.is_text_box는 false
    shape1.add_text_frame("shape 1")
    # shape1.is_text_box는 true

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 110, 100, 40)
    # shape2.is_text_box는 false
    shape2.text_frame.text = "shape 2"
    # shape2.is_text_box는 true

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 210, 100, 40)
    # shape3.is_text_box는 false
    shape3.add_text_frame("")
    # shape3.is_text_box는 false

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 100, 40)
    # shape4.is_text_box는 false
    shape4.text_frame.text = ""
    # shape4.is_text_box는 false
```

## **텍스트 상자에 열 추가**

Aspose.Slides는 텍스트 상자에 열을 추가하기 위해 [TextFrameFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframeformat/) 클래스에 [column_count](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframeformat/column_count/)와 [column_spacing](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframeformat/column_spacing/) 속성을 제공합니다. 열의 수를 지정하고 열 사이의 간격을 포인트 단위로 설정할 수 있습니다.

다음 Python 코드가 이 작업을 시연합니다:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

	# 프레젠테이션의 첫 번째 슬라이드를 가져옵니다.
	slide = presentation.slides[0]

	# 유형이 RECTANGLE인 AutoShape를 추가합니다.
	shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

	# 사각형에 TextFrame을 추가합니다.
	shape.add_text_frame("All of these columns are confined to a single text container—" +
	"you can add or delete text, and any new or remaining text automatically reflows " +
	"within the container. You cannot have text flow from one container to another, " +
	"though—PowerPoint’s column options for text are limited!")

	# TextFrame의 텍스트 형식을 가져옵니다.
	format = shape.text_frame.text_frame_format

	# TextFrame의 열 수를 지정합니다.
	format.column_count = 3

	# 열 사이의 간격을 지정합니다.
	format.column_spacing = 10

	# 프레젠테이션을 저장합니다.
	presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```

## **텍스트 업데이트**

Aspose.Slides를 사용하면 단일 텍스트 상자 또는 전체 프레젠테이션의 텍스트를 업데이트할 수 있습니다.

다음 Python 예제는 프레젠테이션의 모든 텍스트를 업데이트하는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                for paragraph in shape.text_frame.paragraphs:
                    for portion in paragraph.portions:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = 1
  
    # 수정된 프레젠테이션을 저장합니다.
    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

## **하이퍼링크가 있는 텍스트 상자 추가**

텍스트 상자에 링크를 삽입할 수 있습니다. 텍스트 상자를 클릭하면 링크가 열립니다.

하이퍼링크가 포함된 텍스트 상자를 추가하려면 다음 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 첫 번째 슬라이드에 대한 참조를 가져옵니다.
3. 원하는 위치에 `ShapeType.RECTANGLE` 를 사용하여 [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/)을 추가합니다.
4. 도형의 [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/)에 텍스트를 설정합니다.
5. [HyperlinkManager](https://reference.aspose.com/slides/ko/python-net/aspose.slides/hyperlinkmanager/)에 대한 참조를 얻습니다.
6. `hyperlink_manager` 속성을 사용하여 외부 클릭 하이퍼링크를 설정합니다.
7. 프레젠테이션을 PPTX 파일로 저장합니다.

다음 Python 예제는 슬라이드에 하이퍼링크가 있는 텍스트 상자를 추가하는 방법을 보여줍니다:

```py
import aspose.slides as slides

# Presentation 클래스를 인스턴스화합니다.
with slides.Presentation() as presentation:

    # 프레젠테이션의 첫 번째 슬라이드를 가져옵니다.
    slide = presentation.slides[0]

    # 유형이 RECTANGLE인 AutoShape를 추가합니다.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    text_portion = shape.text_frame.paragraphs[0].portions[0]

    # 프레임에 텍스트를 추가합니다.
    text_portion.text = "Aspose.Slides"

    # 해당 텍스트 부분에 하이퍼링크를 설정합니다.
    hyperlink_manager = text_portion.portion_format.hyperlink_manager
    hyperlink_manager.set_external_hyperlink_click("http://www.aspose.com")

    # 프레젠테이션을 PPTX 파일로 저장합니다.
    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **자주 묻는 질문**

**마스터 슬라이드를 사용할 때 텍스트 상자와 텍스트 자리표시자(placeholder)의 차이점은 무엇인가요?**

[placeholder](/slides/ko/python-net/manage-placeholder/)는 [master](https://reference.aspose.com/slides/ko/python-net/aspose.slides/masterslide/)에서 스타일/위치를 상속받으며 [layouts](https://reference.aspose.com/slides/ko/python-net/aspose.slides/layoutslide/)에서 재정의할 수 있는 반면, 일반 텍스트 상자는 특정 슬라이드에 독립적인 객체로 레이아웃을 전환해도 변경되지 않습니다.

**차트, 표, SmartArt 내부의 텍스트는 건드리지 않고 프레젠테이션 전체에서 대량 텍스트 교체를 수행하려면 어떻게 해야 하나요?**

텍스트 프레임을 가진 자동 도형만 반복하고, 포함된 객체인 ([charts](https://reference.aspose.com/slides/ko/python-net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/ko/python-net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/ko/python-net/aspose.slides.smartart/smartart/))는 별도로 컬렉션을 탐색하거나 해당 객체 유형을 건너뛰어 제외하십시오.