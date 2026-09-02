---
title: Python에서 PowerPoint 텍스트 단락 관리
linktitle: 단락 관리
type: docs
weight: 40
url: /ko/python-net/manage-paragraph/
aliases:
  - /python-net/paragraph/
  - /python-net/portion/
keywords:
- 텍스트 추가
- 단락 추가
- 텍스트 관리
- 단락 관리
- 글머리표 관리
- 단락 들여쓰기
- 매달린 들여쓰기
- 단락 글머리표
- 번호 매기기 목록
- 글머리 목록
- 단락 속성
- HTML 가져오기
- 텍스트를 HTML로
- 단락을 HTML로
- 단락을 이미지로
- 텍스트를 이미지로
- 단락 내보내기
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 단락, 구역, 글머리표, 번호 매기기 목록, 들여쓰기, HTML 콘텐츠 및 단락 이미지를 생성하고 서식 지정하는 방법을 배웁니다."
---
## **개요**

Aspose.Slides for Python via .NET는 텍스트를 텍스트 프레임, 단락, 그리고 구역의 계층 구조로 나타냅니다:

* [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/) 은(는) 도형 내의 텍스트 컨테이너를 나타내며 해당 도형의 단락 컬렉션에 대한 액세스를 제공합니다.
* [Paragraph](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraph/) 은(는) 텍스트 프레임 내의 하나의 단락을 나타내며, 그 구역 및 단락 수준 서식에 대한 액세스를 제공합니다.
* [Portion](https://reference.aspose.com/slides/ko/python-net/aspose.slides/portion/) 은(는) 단락 내의 텍스트 실행을 나타냅니다. 각 구역은 자체 텍스트와 문자 수준 서식을 가질 수 있습니다.

따라서 단락은 여러 구역을 사용하여 서로 다른 글꼴, 색상, 크기 및 기타 서식을 가진 텍스트를 포함할 수 있습니다.

## **단락 만들기 및 서식 지정**

### **여러 구역이 있는 단락 만들기**

다음 단계는 세 개의 단락을 가진 텍스트 프레임을 만들고, 각 단락에 세 개의 구역을 포함합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 해당 슬라이드에 접근합니다.
3. 슬라이드에 직사각형 [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/) 을 추가합니다.
4. 도형의 [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/) 에 접근합니다.
5. 기본 단락을 사용하고 텍스트 프레임에 두 개의 추가 [Paragraph](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraph/) 객체를 추가합니다.
6. 각 단락에 세 개의 구역을 포함하도록 충분한 [Portion](https://reference.aspose.com/slides/ko/python-net/aspose.slides/portion/) 객체를 추가합니다. 기본 단락에는 이미 빈 구역 하나가 포함되어 있습니다.
7. 각 구역의 텍스트를 설정합니다.
8. [Portion.portion_format](https://reference.aspose.com/slides/ko/python-net/aspose.slides/portion/portion_format/) 을 통해 문자 수준 서식을 적용합니다.
9. 수정된 프레젠테이션을 저장합니다.

이 Python 예제는 위 단계를 구현합니다:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)
    text_frame = shape.text_frame

    first_paragraph = text_frame.paragraphs[0]
    first_paragraph.portions.add(slides.Portion())
    first_paragraph.portions.add(slides.Portion())

    second_paragraph = slides.Paragraph()
    second_paragraph.portions.add(slides.Portion())
    second_paragraph.portions.add(slides.Portion())
    second_paragraph.portions.add(slides.Portion())
    text_frame.paragraphs.add(second_paragraph)

    third_paragraph = slides.Paragraph()
    third_paragraph.portions.add(slides.Portion())
    third_paragraph.portions.add(slides.Portion())
    third_paragraph.portions.add(slides.Portion())
    text_frame.paragraphs.add(third_paragraph)

    for paragraph_index in range(text_frame.paragraphs.count):
        paragraph = text_frame.paragraphs[paragraph_index]
        for portion_index in range(paragraph.portions.count):
            portion = paragraph.portions[portion_index]
            portion.text = f"Portion {paragraph_index + 1}.{portion_index + 1}"

            if portion_index == 0:
                portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
                portion.portion_format.fill_format.solid_fill_color.color = draw.Color.red
                portion.portion_format.font_bold = slides.NullableBool.TRUE
                portion.portion_format.font_height = 15
            elif portion_index == 1:
                portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
                portion.portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                portion.portion_format.font_italic = slides.NullableBool.TRUE
                portion.portion_format.font_height = 18

    presentation.save("paragraphs_with_portions.pptx", slides.export.SaveFormat.PPTX)
```

## **글머리표 및 번호 매기기 목록 만들기**

### **글머리표 또는 번호 매기기 목록 만들기**

글머리표와 번호 매기기는 관련 항목을 더 쉽게 스캔할 수 있게 해 줍니다. Aspose.Slides에서는 [BulletFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides/bulletformat/) 을 통해 목록 설정이 정의됩니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 해당 슬라이드에 접근합니다.
3. 선택한 슬라이드에 [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/) 을 추가합니다.
4. 도형의 [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/) 에 접근합니다.
5. 텍스트 프레임에서 기본 단락을 제거합니다.
6. 기호 글머리표용 [Paragraph](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraph/) 를 생성합니다.
7. [BulletFormat.type](https://reference.aspose.com/slides/ko/python-net/aspose.slides/bulletformat/type/) 을 [BulletType.SYMBOL](https://reference.aspose.com/slides/ko/python-net/aspose.slides/bullettype/) 로 설정하고 글머리 기호 문자를 지정합니다.
8. 단락 텍스트, 들여쓰기, 글머리 색상 및 글머리 높이를 설정합니다.
9. 단락을 텍스트 프레임에 추가합니다.
10. 두 번째 단락을 만들고 [BulletFormat.type](https://reference.aspose.com/slides/ko/python-net/aspose.slides/bulletformat/type/) 을 [BulletType.NUMBERED](https://reference.aspose.com/slides/ko/python-net/aspose.slides/bullettype/) 로 설정합니다.
11. 번호 매기기 글머리 스타일을 구성하고 단락을 텍스트 프레임에 추가합니다.
12. 프레젠테이션을 저장합니다.

이 Python 예제는 기호 글머리와 번호 매기기 글머리를 생성합니다:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    symbol_paragraph = slides.Paragraph()
    symbol_paragraph.text = "Welcome to Aspose.Slides"
    symbol_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    symbol_paragraph.paragraph_format.bullet.char = chr(0x2022)
    symbol_paragraph.paragraph_format.indent = 25
    symbol_paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    symbol_paragraph.paragraph_format.bullet.color.color = draw.Color.black
    symbol_paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    symbol_paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(symbol_paragraph)

    numbered_paragraph = slides.Paragraph()
    numbered_paragraph.text = "This is a numbered item"
    numbered_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    numbered_paragraph.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WD_BLACK_PLAIN
    numbered_paragraph.paragraph_format.indent = 25
    numbered_paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    numbered_paragraph.paragraph_format.bullet.color.color = draw.Color.black
    numbered_paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    numbered_paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(numbered_paragraph)

    presentation.save("bulleted_and_numbered_list.pptx", slides.export.SaveFormat.PPTX)
```

### **그림 글머리표 사용**

그림 글머리표를 사용하면 기호나 번호 대신 사용자 지정 이미지를 사용할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 해당 슬라이드에 접근합니다.
3. [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/) 을 추가하고 그 [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/) 에 접근합니다.
4. 텍스트 프레임에서 기본 단락을 제거합니다.
5. 글머리 이미지를 로드하고 프레젠테이션의 이미지 컬렉션에 [PPImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ppimage/) 로 추가합니다.
6. [Paragraph](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraph/) 을 생성하고 텍스트를 설정합니다.
7. [BulletFormat.type](https://reference.aspose.com/slides/ko/python-net/aspose.slides/bulletformat/type/) 을 [BulletType.PICTURE](https://reference.aspose.com/slides/ko/python-net/aspose.slides/bullettype/) 로 설정합니다.
8. [BulletFormat.picture](https://reference.aspose.com/slides/ko/python-net/aspose.slides/bulletformat/picture/) 로 이미지를 지정하고 글머리 높이를 설정합니다.
9. 단락을 텍스트 프레임에 추가합니다.
10. 수정된 프레젠테이션을 저장합니다.

이 Python 예제는 그림 글머리표를 생성합니다:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("bullets.png") as bullet_image:
        presentation_image = presentation.images.add_image(bullet_image)

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = presentation_image
    paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(paragraph)

    presentation.save("picture_bullet.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("picture_bullet.ppt", slides.export.SaveFormat.PPT)
```

### **다중 수준 목록 만들기**

[ParagraphFormat.depth](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraphformat/depth/) 를 설정하여 단락을 목록의 서로 다른 수준에 배치합니다. 최상위 수준의 깊이는 `0` 입니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 을 생성하고 슬라이드에 접근합니다.
2. [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/) 을 추가하고 해당 텍스트 프레임에서 기본 단락을 제거합니다.
3. 네 개의 단락을 만들고 글머리 기호를 구성합니다.
4. 각 단락의 [ParagraphFormat.depth](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraphformat/depth/) 값을 `0`, `1`, `2`, `3` 으로 설정합니다.
5. 단락을 텍스트 프레임에 추가하고 프레젠테이션을 저장합니다.

이 Python 예제는 4단계 글머리 목록을 생성합니다:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "Content"
    first_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    first_paragraph.paragraph_format.bullet.char = chr(0x2022)
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.depth = 0

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Second level"
    second_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    second_paragraph.paragraph_format.bullet.char = "-"
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.depth = 1

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "Third level"
    third_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    third_paragraph.paragraph_format.bullet.char = chr(0x2022)
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.paragraph_format.depth = 2

    fourth_paragraph = slides.Paragraph()
    fourth_paragraph.text = "Fourth level"
    fourth_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    fourth_paragraph.paragraph_format.bullet.char = "-"
    fourth_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    fourth_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    fourth_paragraph.paragraph_format.depth = 3

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)
    text_frame.paragraphs.add(fourth_paragraph)

    presentation.save("multilevel_list.pptx", slides.export.SaveFormat.PPTX)
```

### **번호 매기기 항목을 사용자 지정 값으로 시작하기**

[BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/ko/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) 를 사용하여 번호 매기기 단락의 초기 번호를 설정합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 을 생성하고 슬라이드에 [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/) 를 추가합니다.
2. 도형의 텍스트 프레임에서 기본 단락을 제거합니다.
3. 세 개의 번호 매기기 단락을 생성합니다.
4. 각 단락에 대해 [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/ko/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) 를 `2`, `3`, `7` 로 설정합니다.
5. 단락을 텍스트 프레임에 추가하고 프레젠테이션을 저장합니다.

이 Python 예제는 각 단락에 사용자 지정 시작 번호를 할당합니다:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "Start at 2"
    first_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    first_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 2
    text_frame.paragraphs.add(first_paragraph)

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Start at 3"
    second_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    second_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 3
    text_frame.paragraphs.add(second_paragraph)

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "Start at 7"
    third_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    third_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 7
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("custom_numbered_list.pptx", slides.export.SaveFormat.PPTX)
```

## **단락 레이아웃 및 종료 속성 제어**

### **첫 줄 들여쓰기 설정**

[ParagraphFormat.indent](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraphformat/indent/) 속성을 사용하여 단락의 첫 줄 들여쓰기를 제어합니다. 이 속성은 단락의 왼쪽 여백에 상대적으로 첫 줄만 이동시킵니다. 양수 값은 첫 줄을 오른쪽으로 이동시키고, 나머지 줄은 단락 본문에 정렬된 상태를 유지합니다.

전체 단락을 이동하려면 [ParagraphFormat.margin_left](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraphformat/margin_left/) 를 사용하고, 첫 줄만 이동하려면 [ParagraphFormat.indent](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraphformat/indent/) 를 사용합니다.

아래 예제는 여러 단락을 만들고 서로 다른 [ParagraphFormat.indent](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraphformat/indent/) 값을 적용하여 첫 줄 들여쓰기가 단락 레이아웃에 미치는 영향을 보여줍니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 대상 슬라이드에 접근합니다.
3. 슬라이드에 직사각형 [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/) 을 추가합니다.
4. 도형의 [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/) 에 접근하고 기본 단락을 제거합니다.
5. 여러 단락을 만들고 각각에 다른 [ParagraphFormat.indent](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraphformat/indent/) 값을 설정합니다.
6. 단락을 텍스트 프레임에 추가합니다.
7. 수정된 프레젠테이션을 저장합니다.

이 코드는 단락 들여쓰기를 설정하는 방법을 보여줍니다:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = shape.text_frame
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "No first-line indent. Wrapped lines start at the same position as the first line."
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.margin_left = 20
    first_paragraph.paragraph_format.indent = 0

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body."
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.margin_left = 20
    second_paragraph.paragraph_format.indent = 20

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see."
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.paragraph_format.margin_left = 20
    third_paragraph.paragraph_format.indent = 40

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("paragraph_indent.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![The first-line indent of the paragraphs](first_line_indent.png)

### **매달린 들여쓰기 설정**

매달린 들여쓰기는 첫 줄이 나머지 줄보다 왼쪽에 시작되는 단락 레이아웃입니다. Aspose.Slides에서는 [ParagraphFormat.indent](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraphformat/indent/) 속성을 사용하여 이 효과를 만들 수 있습니다. `indent` 값을 음수로 설정하면 첫 줄이 단락 본문에 비해 왼쪽으로 이동합니다.

실제로는 [ParagraphFormat.margin_left](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraphformat/margin_left/) 이 단락 본문의 왼쪽 위치를 정의하고, [ParagraphFormat.indent](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraphformat/indent/) 이 해당 여백에 대한 첫 줄의 위치를 정의합니다. 매달린 들여쓰기를 만들려면 양의 `margin_left` 값과 음의 `indent` 값을 설정하십시오.

이 서식은 참고문헌, 인용구, 용어집 항목 및 줄 바꿈 라인이 첫 줄 첫 문자 아래가 아니라 본문 아래에 정렬되어야 하는 기타 단락에 유용합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 대상 슬라이드에 접근합니다.
3. 슬라이드에 직사각형 [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/) 을 추가합니다.
4. 도형의 [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/) 에 접근하고 기본 단락을 제거합니다.
5. 각 단락에 양의 [ParagraphFormat.margin_left](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraphformat/margin_left/) 값을 설정합니다.
6. 매달린 들여쓰기 효과를 만들기 위해 음의 [ParagraphFormat.indent](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraphformat/indent/) 값을 설정합니다.
7. 단락을 텍스트 프레임에 추가합니다.
8. 수정된 프레젠테이션을 저장합니다.

이 코드는 단락에 매달린 들여쓰기를 설정하는 방법을 보여줍니다:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = shape.text_frame
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body."
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.margin_left = 40
    first_paragraph.paragraph_format.indent = -20

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare."
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.margin_left = 60
    second_paragraph.paragraph_format.indent = -30

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("hanging_indent.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![The hanging indent of the paragraphs](hanging_indent.png)

### **단락 종료 구역 속성 설정**

[Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) 속성은 단락 종료 표시문의 서식을 제어합니다. 다음 예제는 두 번째 단락의 종료 표시에 글꼴 크기와 라틴 글꼴을 할당합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 을 로드하고 슬라이드에 접근합니다.
2. [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/) 을 추가하고 기본 단락을 삭제합니다.
3. 두 개의 단락을 만들고 텍스트 구역을 추가합니다.
4. 두 번째 단락의 종료 표시를 위한 [PortionFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides/portionformat/) 을 생성합니다.
5. [PortionFormat.font_height](https://reference.aspose.com/slides/ko/python-net/aspose.slides/portionformat/font_height/) 와 [PortionFormat.latin_font](https://reference.aspose.com/slides/ko/python-net/aspose.slides/portionformat/latin_font/) 를 설정합니다.
6. 형식을 [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) 에 할당하고 프레젠테이션을 저장합니다.

```python
import aspose.slides as slides

with slides.Presentation("Test.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.portions.add(slides.Portion("Sample text"))

    second_paragraph = slides.Paragraph()
    second_paragraph.portions.add(slides.Portion("Sample text 2"))

    end_paragraph_format = slides.PortionFormat()
    end_paragraph_format.font_height = 48
    end_paragraph_format.latin_font = slides.FontData("Times New Roman")
    second_paragraph.end_paragraph_portion_format = end_paragraph_format

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("end_paragraph_format.pptx", slides.export.SaveFormat.PPTX)
```

## **단락 콘텐츠 가져오기 및 내보내기**

### **HTML 텍스트를 단락으로 가져오기**

[ParagraphCollection.add_from_html](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraphcollection/add_from_html/) 을 사용하여 HTML 마크업을 텍스트 프레임의 단락 및 구역으로 변환합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 슬라이드에 접근하고 [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/) 을 추가합니다.
3. 도형의 [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/) 에 접근하고 기본 단락을 삭제합니다.
4. 원본 HTML 파일을 읽습니다.
5. HTML 문자열을 [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraphcollection/add_from_html/) 에 전달합니다.
6. 수정된 프레젠테이션을 저장합니다.

이 Python 예제는 HTML을 텍스트 프레임으로 가져옵니다:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape_width = presentation.slide_size.size.width - 20
    shape_height = presentation.slide_size.size.height - 20
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, shape_width, shape_height)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.paragraphs.clear()

    with open("file.html", "r", encoding="utf-8") as html_stream:
        html = html_stream.read()

    shape.text_frame.paragraphs.add_from_html(html)
    presentation.save("html_text.pptx", slides.export.SaveFormat.PPTX)
```

### **단락 텍스트를 HTML로 내보내기**

[ParagraphCollection.export_to_html](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraphcollection/export_to_html/) 을 사용하여 선택된 단락 범위를 HTML로 내보냅니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 인스턴스를 생성하고 원하는 프레젠테이션을 로드합니다.
2. 슬라이드에 접근하고 텍스트를 포함하는 [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/) 을 찾습니다.
3. 도형의 [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/) 에 접근합니다.
4. 시작 단락 인덱스와 내보낼 단락 수를 지정하여 [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraphcollection/export_to_html/) 를 호출합니다.
5. 반환된 HTML 문자열을 파일에 씁니다.

이 Python 예제는 첫 번째 텍스트 도형의 모든 단락을 내보냅니다:

```python
import aspose.slides as slides

with slides.Presentation("ExportingHTMLText.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
        paragraphs = shape.text_frame.paragraphs
        html = paragraphs.export_to_html(0, paragraphs.count, None)
        with open("paragraphs.html", "w", encoding="utf-8") as html_stream:
            html_stream.write(html)
    else:
        print("The first shape is not a text shape.")
```

### **단락을 이미지로 렌더링**

[Paragraph](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraph/) 은 개별 단락을 직접 렌더링하기 위한 `get_image` 메서드를 제공합니다. 이 메서드는 [IImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iimage/) 를 반환하며, 이를 [IImage.save](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iimage/save/) 로 파일이나 스트림에 저장할 수 있습니다. 포함 도형을 렌더링하거나 비트를 수동으로 잘라낼 필요가 없습니다.

`get_image` 메서드는 단락을 상위 컬렉션에서 찾을 수 없거나 유효한 렌더링 경계가 없거나 렌더링할 수 없는 경우 `None` 을 반환할 수 있습니다. 저장하기 전에 결과를 확인하고, 반환된 이미지를 컨텍스트 매니저로 사용하여 리소스를 해제하십시오.

#### **기본 배율로 단락 렌더링**

sample.pptx 라는 프레젠테이션 파일에 하나의 슬라이드가 있으며, 첫 번째 도형은 세 개의 단락을 포함하는 텍스트 상자라고 가정합니다.

![The text box with three paragraphs](paragraph_to_image_input.png)

다음 예제는 기본 배율로 일반 텍스트 도형의 두 번째 단락을 렌더링하고 PNG 형식으로 저장합니다:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    if isinstance(shape, slides.AutoShape) and shape.text_frame is not None and shape.text_frame.paragraphs.count > 1:
        paragraph = shape.text_frame.paragraphs[1]
        paragraph_image = paragraph.get_image()

        if paragraph_image is not None:
            with paragraph_image:
                paragraph_image.save("paragraph.png", slides.ImageFormat.PNG)
        else:
            print("The paragraph could not be rendered.")
    else:
        print("The expected text shape or paragraph was not found.")
```

결과:

![The paragraph image](paragraph_to_image_output.png)

#### **테이블 셀에서 스케일링으로 단락 렌더링**

수평 및 수직 배율 인자를 `get_image` 에 전달하여 렌더링된 단락의 크기를 제어합니다. 다음 예제는 표를 만들고, 첫 번째 셀의 단락을 기본 너비와 높이의 두 배로 렌더링한 뒤 PNG 이미지로 저장합니다:

```python
import aspose.slides as slides

scale_x = 2
scale_y = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(50, 50, [300], [80])
    paragraph = table.rows[0][0].text_frame.paragraphs[0]
    paragraph.text = "Text in a table cell"

    paragraph_image = paragraph.get_image(scale_x, scale_y)
    if paragraph_image is not None:
        with paragraph_image:
            paragraph_image.save("table_paragraph.png", slides.ImageFormat.PNG)
    else:
        print("The paragraph could not be rendered.")
```

배율 인자 `1` 은 해당 축을 기본 픽셀 크기로 유지합니다. 예를 들어 두 배(`2`)를 지정하면 너비와 높이가 대략 두 배가 되어 픽셀 수가 네 배가 됩니다. 큰 배율은 확대하거나 고해상도 출력 시 텍스트를 더 선명하게 만들지만 메모리 사용량과 파일 크기가 증가합니다. `1` 이하의 배율은 더 작은 이미지와 적은 디테일을 제공합니다. 비율을 유지하려면 가로와 세로 배율을 동일하게 사용하고, 서로 다르게 지정하면 출력이 개별 축에 따라 늘어나거나 줄어듭니다.

도형 전체를 렌더링하려면 [Shape.get_image](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/get_image/) 를 사용하십시오. 이것은 도형의 채우기, 테두리 또는 기타 시각적 컨텍스트를 포함해야 할 때 유용합니다. 단락만 이미지로 만들고 싶다면 `Paragraph.get_image` 를 사용하십시오.

## **FAQ**

**텍스트 프레임 내부에서 줄 바꿈을 완전히 비활성화할 수 있나요?**

예. [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframeformat/wrap_text/) 을 `False` 로 설정하면 텍스트 프레임 가장자리에서 줄이 끊기지 않도록 할 수 있습니다.

**특정 단락의 슬라이드 상 정확한 경계값을 어떻게 얻나요?**

[Paragraph.get_rect](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraph/get_rect/) 를 사용하여 단락의 경계 사각형을 가져올 수 있습니다. 개별 구역의 경계는 [Portion.get_rect](https://reference.aspose.com/slides/ko/python-net/aspose.slides/portion/get_rect/) 로 확인하십시오.

**단락 정렬(왼쪽, 오른쪽, 가운데, 양쪽 맞춤)은 어디서 제어하나요?**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraphformat/alignment/) 은 단락 수준 설정이며 개별 구역 서식과 무관하게 전체 단락에 적용됩니다.

**단락의 일부에 교정 언어를 설정할 수 있나요?**

예. 개별 구역에 대해 [PortionFormat.language_id](https://reference.aspose.com/slides/ko/python-net/aspose.slides/portionformat/language_id/) 를 설정하면 하나의 단락에 여러 언어를 포함시킬 수 있습니다.