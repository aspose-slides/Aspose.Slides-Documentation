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
- 걸이 들여쓰기
- 단락 글머리표
- 번호 매기기 목록
- 글머리표 목록
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
description: "Aspose.Slides for Python via .NET를 사용하여 단락, 구문, 글머리표, 번호 매기기 목록, 들여쓰기, HTML 콘텐츠 및 단락 이미지를 만들고 서식 지정하는 방법을 배웁니다."
---
## **개요**

Aspose.Slides for Python via .NET은 텍스트를 텍스트 프레임, 단락 및 구문(Portion)의 계층 구조로 표현합니다:

* [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)은 도형 내의 텍스트 컨테이너를 나타내며 단락 컬렉션에 대한 액세스를 제공합니다.
* [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/)은 텍스트 프레임 내의 하나의 단락을 나타내며 그 구문과 단락 수준 서식에 대한 액세스를 제공합니다.
* [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/)은 단락 내의 텍스트 실행을 나타냅니다. 각 구문은 고유한 텍스트와 문자 수준 서식을 가질 수 있습니다.

따라서 단락은 여러 구문을 사용하여 다양한 글꼴, 색상, 크기 및 기타 서식을 적용한 텍스트를 포함할 수 있습니다.

## **단락 만들기 및 서식 지정**

도형의 텍스트 프레임에 단락을 만들고 구문을 사용하여 개별 텍스트 실행을 서식 지정합니다. 이 섹션에서는 각 단락에 여러 구문을 결합하고 서로 다른 색상, 글꼴 크기 및 스타일을 적용하는 방법을 보여줍니다.

### **여러 구문으로 단락 만들기**

다음 Python 예제는 세 개의 단락을 만들고, 각 단락의 [Paragraph.portions](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/portions/) 컬렉션에 세 개의 텍스트 실행을 포함합니다. 기본 단락과 빈 구문을 재사용한 뒤, 나머지 단락과 구문을 추가합니다. 서식은 [Portion.portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/portion/portion_format/)을 통해 적용합니다: 각 단락의 첫 번째 구문은 빨간색, 굵게, 15pt이며, 두 번째는 파란색, 기울임, 18pt입니다. 세 번째 구문은 기본 서식을 유지합니다:

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

단락 텍스트를 기호, 숫자 또는 사용자 정의 이미지가 있는 목록으로 구성합니다. 이 섹션의 예제는 글머리표 서식, 다단계 목록 및 사용자 정의 시작 번호를 다룹니다.

### **글머리표 또는 번호 매기기 목록 만들기**

글머리표와 번호 매기기를 사용하면 관련 항목을 더 쉽게 스캔할 수 있습니다. Aspose.Slides에서는 [BulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/)을 통해 목록 설정을 정의합니다.

다음 Python 예제는 동일한 텍스트 프레임에 기호 글머리표와 번호 매기기 항목을 추가합니다. [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/)은 글머리표 유형을 선택하고, [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/)은 기호를 제공하며, [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_style/)은 번호 매기기 스타일을 선택합니다. 두 항목 모두 높이가 100%이고 단락 들여쓰기가 25pt인 검은색 글머리표를 사용합니다:

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

그림 글머리표를 사용하면 기호나 숫자 대신 사용자 정의 이미지를 사용할 수 있습니다.

예제는 작업 디렉터리에 `bullets.png` 파일이 있어야 합니다. 이 Python 예제는 프레젠테이션의 이미지 컬렉션에 [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/)를 추가하고 이를 단락 글머리표로 사용합니다. [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/)을 그림 글머리표로 설정하고, 이미지는 [BulletFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/picture/)를 통해 할당합니다. [BulletFormat.height](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/height/)를 100%로 설정하여 글머리표를 단락 텍스트에 상대적으로 크기 지정합니다:

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

### **다단계 목록 만들기**

[ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/)를 설정하여 목록의 서로 다른 수준에 단락을 배치합니다. 최상위 수준은 깊이 `0`입니다.

다음 Python 예제는 네 개의 단락에 대해 [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) 값을 0부터 3까지 지정하여 하나의 텍스트 프레임 내에 계층 구조를 생성합니다. 각 단락은 기호 글머리표를 사용하며, [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/)가 원형 글머리표와 하이픈 사이에서 교체되어 인접한 수준을 구분합니다:

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

### **사용자 정의 시작 값으로 번호 매기기 목록 항목 시작하기**

[BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/)을 사용하여 번호 매기기 단락에 표시되는 초기 번호를 설정합니다.

다음 Python 예제는 세 개의 단락에 대해 번호 매기기를 사용하도록 [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/)을 설정하고, [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) 값을 각각 2, 3, 7로 지정합니다. 시작 값은 각 단락마다 별도로 구성되어 표시되는 번호가 건너뛰게 됩니다:

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

## **단락 레이아웃 및 끝 속성 제어**

단락 여백과 들여쓰기를 조정하여 첫 줄과 래핑된 줄의 위치를 제어합니다. 또한 눈에 보이는 텍스트 구문과 별도로 단락 끝 마크를 서식 지정할 수 있습니다.

### **첫 줄 들여쓰기 설정**

[ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) 속성을 사용하여 단락의 첫 줄 들여쓰기를 제어합니다. 이 속성은 단락 왼쪽 여백에 상대적으로 첫 줄만 이동시킵니다. 양수 값은 첫 줄을 오른쪽으로 이동시키고, 나머지 줄은 단락 본문에 맞춰 정렬됩니다.

전체 단락을 이동해야 할 때는 [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/)를 사용하고, 첫 줄만 이동하려면 [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/)를 사용합니다.

다음 예제는 세 개의 단락에 동일한 [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) 20pt와 [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) 값을 각각 0, 20, 40pt로 지정합니다. 첫 줄은 점점 큰 오프셋에서 시작하고, 래핑된 줄은 동일한 왼쪽 여백을 유지합니다:

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

![문단의 첫 줄 들여쓰기](first_line_indent.png)

### **걸이 들여쓰기 설정**

걸이 들여쓰기는 첫 줄이 나머지 줄보다 왼쪽에 시작되는 단락 레이아웃입니다. Aspose.Slides에서는 [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) 속성을 사용하여 이 효과를 만듭니다. `indent`를 음수 값으로 설정하면 첫 줄이 단락 본문에 비해 왼쪽으로 이동합니다.

실제로는 [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/)가 단락 본문의 왼쪽 위치를 정의하고, [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/)가 해당 여백에 대한 첫 줄 위치를 정의합니다. 걸이 들여쓰기를 만들려면 양수 `margin_left` 값을 지정하고 `indent` 값을 음수로 설정합니다.

이 서식은 참고 문헌, 인용, 용어집 항목 등 래핑된 줄이 첫 줄의 첫 문자 아래가 아니라 단락 본문 아래에 정렬되어야 할 때 유용합니다.

다음 Python 예제는 [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) 값을 40pt와 60pt로 지정하고, [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) 값을 각각 -20pt와 -30pt로 지정합니다. 각 단락에서 첫 줄은 래핑된 줄보다 왼쪽에서 시작하며, 두 번째 단락은 더 깊은 걸이 들여쓰기를 가집니다:

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

![문단의 걸이 들여쓰기](hanging_indent.png)

### **단락 끝 실행 속성 설정**

[Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) 속성은 단락 끝 마크의 서식을 제어합니다. 예제는 최소 하나의 슬라이드가 포함된 `Test.pptx`를 로드하고, [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/)을 생성한 뒤, [PortionFormat.font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/)을 48pt, [PortionFormat.latin_font](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/latin_font/)을 Times New Roman으로 설정합니다. 이 서식을 두 번째 단락의 끝 마크에 할당하여 표시되는 텍스트 구문은 변경되지 않게 합니다:

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

## **렌더링된 줄 수 계산**

줄 끝에서 자동 래핑 및 구두점에 영향을 주는 단락 규칙은 [Control Line Breaking](/slides/ko/python-net/text-formatting/#control-line-breaking) 및 [Control Hanging Punctuation](/slides/ko/python-net/text-formatting/#control-hanging-punctuation) 을 참조하십시오.

[Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/)을 사용하여 텍스트 레이아웃 후 단락이 차지하는 줄 수를 계산할 수 있습니다. 이는 프레젠테이션 템플릿에서 텍스트 길이와 레이아웃을 확인할 때 유용합니다.

단락은 [TextFrame.paragraphs](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/paragraphs/)의 항목이며, 여러 렌더링된 줄을 차지할 수 있습니다. 명시적인 줄 바꿈은 새로운 줄을 강제하지만 새로운 단락을 만들지는 않습니다. 자동 래핑은 텍스트에 명시적인 줄 바꿈을 삽입하지 않고 가용 너비에 따라 줄을 생성합니다. 따라서 단락 수 또는 줄 바꿈 문자 수를 세는 것으로는 렌더링된 줄 수를 알 수 없습니다.

다음 예제는 텍스트 모양을 만들고, 줄 수를 계산한 뒤, 모양을 좁히고, 텍스트를 짧은 문자열로 교체합니다. 예제는 [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/)을 활성화하고 [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/)을 비활성화하여 모양 너비가 자동으로 텍스트를 축소하거나 모양을 재조정하지 않고 래핑을 제어하도록 합니다. 각 측정은 [Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/)을 사용합니다. 모양 크기는 포인트 단위입니다. 마지막으로 예제는 또 다른 단락을 추가하고 텍스트 프레임 전체의 줄 수를 합산합니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 400, 200)
    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE

    paragraph = text_frame.paragraphs[0]
    paragraph.paragraph_format.default_portion_format.font_height = 20
    paragraph.text = "This text demonstrates how automatic wrapping changes the number of rendered lines."
    print(f"Original width: {paragraph.get_lines_count()}")

    shape.width = 150
    print(f"Narrower shape: {paragraph.get_lines_count()}")

    paragraph.text = "Short text."
    print(f"Shorter text: {paragraph.get_lines_count()}")

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Another paragraph."
    second_paragraph.paragraph_format.default_portion_format.font_height = 20
    text_frame.paragraphs.add(second_paragraph)

    total_line_count = 0
    for current_paragraph in text_frame.paragraphs:
        total_line_count += current_paragraph.get_lines_count()
    print(f"Total lines in the text frame: {total_line_count}")
```

이 텍스트와 차원으로 모양을 좁히면 줄 수가 증가하고, 짧은 문자열로 교체하면 줄 수가 감소합니다. 정확한 개수는 사용 가능한 글꼴, 대체, 글꼴 크기, 여백, 들여쓰기, 래핑 및 자동 맞춤 설정에 따라 달라질 수 있습니다. 템플릿을 확인할 때는 대상 환경에서 사용할 글꼴 및 레이아웃 설정을 사용하십시오.

줄 수 자체만으로 텍스트가 컨테이너를 초과했는지 판단할 수 없습니다. 사용 가능한 높이, 줄 높이, 단락 및 줄 간격, 자동 맞춤 동작도 중요합니다; 래핑이 비활성화된 경우 단일 줄이라도 가용 너비를 초과할 수 있습니다.

## **단락 내용 가져오기 및 내보내기**

HTML을 사용하여 텍스트를 프레젠테이션에 가져오거나 기존 단락을 외부에서 사용할 수 있도록 내보냅니다. 이 섹션에서는 테이블 셀의 단락을 포함한 개별 단락을 이미지로 렌더링하는 방법도 보여줍니다.

### **HTML 텍스트를 단락으로 가져오기**

[ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/)을 사용하여 HTML 마크업을 텍스트 프레임의 단락 및 구문으로 변환합니다.

다음 Python 예제는 작업 디렉터리의 `file.html`에서 HTML을 읽고, 마크업을 [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/)에 전달합니다. 텍스트 프레임의 기본 단락을 지워 프레임에 가져온 내용만 포함하도록 합니다. 사각형 모양은 슬라이드 각 면에 10pt 여백을 남깁니다:

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

[ParagraphCollection.export_to_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/export_to_html/)을 사용하여 선택된 단락 범위를 HTML로 내보냅니다. 프레젠테이션 텍스트를 웹사이트에 재사용할 때, 프레젠테이션의 글꼴, 크기 또는 텍스트 상자 스타일을 포함하지 않고 로컬 강조만 유지하고 싶을 수 있습니다. [TextToHtmlConversionOptions.text_inheritance_limit](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/text_inheritance_limit/)을 설정하여 내보내기가 서식 상속을 얼마나 따라갈지 제어합니다.

[샘플 프레젠테이션](text-inheritance.pptx)을 다운로드하고 애플리케이션 작업 디렉터리에 배치합니다. 첫 번째 슬라이드에는 텍스트 "Inherited text; explicit red 18pt"가 포함된 텍스트 모양이 하나 있습니다. 입력은 여러 서식 수준을 의도적으로 사용합니다:

- 프레젠테이션의 기본 텍스트 스타일은 Calibri와 28pt 크기를 제공합니다.
- 텍스트 프레임의 1단계 텍스트 스타일은 파란색 텍스트와 기울임을 제공합니다.
- 단락은 굵은 텍스트를 명시적으로 설정합니다.
- 두 번째 구문인 "explicit red 18pt"는 빨간색 텍스트와 18pt 크기를 명시적으로 설정합니다.

다음 전체 예제는 동일한 단락을 세 번 내보냅니다. [TextToHtmlConversionOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/)을 내보내기 메서드에 전달하고 각 결과를 별도의 UTF-8 HTML 파일로 저장합니다:

```python
import aspose.slides as slides

with slides.Presentation("text-inheritance.pptx") as presentation:
    text_shape = presentation.slides[0].shapes[0]
    paragraphs = text_shape.text_frame.paragraphs
    
    modes = {
        "All": slides.export.TextInheritanceLimit.ALL,
        "TextBox": slides.export.TextInheritanceLimit.TEXT_BOX,
        "ParagraphOnly": slides.export.TextInheritanceLimit.PARAGRAPH_ONLY,
    }

    for name, mode in modes.items():
        options = slides.export.TextToHtmlConversionOptions()
        options.text_inheritance_limit = mode

        html = paragraphs.export_to_html(0, paragraphs.count, options)
        with open(f"{name}.html", "w", encoding="utf-8") as html_stream:
            html_stream.write(html)
```

생성된 HTML에는 첫 번째 구문 "Inherited text; "에 대한 다음 CSS가 포함됩니다. 표는 관련 선언을 나열하고, 다른 생성 속성은 명확성을 위해 생략되었습니다.

| 출력 | 첫 번째 구문에 대한 관련 CSS | 외관 |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Calibri가 사용 가능하면 28pt, 파란색, 굵게, 기울임 텍스트 |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | 파란색, 굵게, 기울임 텍스트; 주변 페이지 또는 브라우저가 글꼴 패밀리와 크기를 제공 |
| `ParagraphOnly.html` | `font-weight:bold` | 굵게 텍스트; 주변 페이지 또는 브라우저가 글꼴 패밀리, 크기, 색상 및 기울임 스타일을 제공 |

두 번째 구문은 세 출력 모두에서 `color:#ff0000`, `font-size:18pt`, `font-weight:bold`를 유지합니다. 또한 `ALL`과 `TEXT_BOX`에서는 기울임을 유지하지만 `PARAGRAPH_ONLY`에서는 유지되지 않습니다. 상속을 제한하면 단락이나 구문에 명시적으로 지정된 서식이 제거되지 않음을 보여줍니다.

동일한 브라우저에서 파일을 열어 비교하십시오. 두 제한 모드에서 생략된 CSS 속성은 대상 페이지 스타일이나 브라우저 기본값에 의해 해결되므로 최종 외관은 HTML이 사용되는 위치에 따라 달라집니다.

### **단락을 이미지로 렌더링**

[Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/)은 개별 단락을 직접 렌더링하고 [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/)를 반환합니다. 결과를 [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/)를 사용해 파일이나 스트림에 저장합니다. 포함된 모양을 렌더링하거나 비트맵을 수동으로 자를 필요가 없습니다.

[Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/)은 단락을 상위 컬렉션에서 찾을 수 없거나 유효한 렌더링 경계가 없거나 렌더링할 수 없는 경우 `None`을 반환할 수 있습니다. 저장하기 전에 결과를 확인하고 사용 후 반환된 이미지를 해제하십시오.

#### **기본 배율로 단락 렌더링**

예제는 `sample.pptx`를 사용합니다. 이 프레젠테이션에는 첫 번째 모양이 세 개의 단락을 포함한 텍스트 상자입니다.

![세 개의 단락이 있는 텍스트 상자](paragraph_to_image_input.png)

다음 예제는 인덱스 1의 두 번째 단락을 선택하고 배율 매개 변수를 지정하지 않고 [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/)을 호출합니다. 모양에 필요한 단락이 포함되어 있는지 확인하고 렌더링이 이미지 반환을 확인한 뒤 [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/)으로 PNG 형식으로 저장합니다. 컨텍스트 매니저가 사용 후 이미지 리소스를 해제합니다.

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

![단락 이미지](paragraph_to_image_output.png)

#### **테이블 셀에서 스케일링으로 단락 렌더링**

`scale_x`와 `scale_y` 매개 변수를 받아 가로 및 세로 스케일 팩터를 설정하는 [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) 오버로드를 사용합니다. 다음 예제는 표를 만들고, 첫 번째 셀의 단락을 기본 너비와 높이의 두 배로 렌더링한 뒤 PNG 이미지로 저장합니다.

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

스케일 팩터 `1`은 해당 축을 기본 픽셀 크기로 유지합니다. 예를 들어 두 축 모두 `2`이면 이미지의 너비와 높이가 대략 두 배가 되어 픽셀이 네 배가 됩니다. 큰 팩터는 확대 또는 고해상도 출력에 더 선명한 텍스트를 제공하지만 메모리 사용량과 파일 크기도 증가합니다. `1` 이하의 팩터는 세부 정보가 적은 작은 이미지를 생성합니다. 가로와 세로 팩터를 동일하게 설정하면 단락의 종횡비를 유지합니다; 서로 다른 팩터는 출력을 독립적으로 늘립니다.

전체 모양을 [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/)으로 렌더링하는 것이 모양의 채우기, 테두리 또는 기타 시각적 컨텍스트를 포함해야 할 때 유용합니다. 단락 전용 이미지에는 [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/)을 사용하십시오.

## **FAQ**

**텍스트 프레임 내부에서 줄 바꿈을 완전히 비활성화할 수 있나요?**

예. [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/)을 비활성화하면 줄이 텍스트 프레임 가장자리를 넘어 깨지지 않도록 합니다.

**특정 단락의 정확한 슬라이드 내 경계를 어떻게 얻나요?**

[Paragraph.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_rect/)을 사용하여 단락의 경계 사각형을 가져옵니다. [Portion.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/portion/get_rect/)은 개별 구문의 경계를 제공합니다.

**단락 정렬(왼쪽, 오른쪽, 가운데 또는 양쪽 맞춤)은 어디에서 제어되나요?**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/)은 단락 수준 설정이며 개별 구문 서식과 무관하게 전체 단락에 적용됩니다.

각 줄의 다른 글꼴 크기를 가진 구문을 수직 정렬하려면 [Align Fonts Within a Line](/slides/ko/python-net/text-formatting/#align-fonts-within-a-line)를 참조하십시오.

**단락의 일부에 교정 언어를 설정할 수 있나요?**

예. [PortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/)를 개별 구문에 설정하면 하나의 단락에 여러 언어 텍스트를 포함시킬 수 있습니다.