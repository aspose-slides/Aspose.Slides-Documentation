---
title: Python에서 프레젠테이션의 글머리표 및 번호 매기기 목록 관리
linktitle: 목록 관리
type: docs
weight: 70
url: /ko/python-net/manage-lists/
aliases:
  - /python-net/manage-bullet-and-numbered-lists/
keywords:
- 글머리표
- 글머리표 목록
- 번호 매기기 목록
- 기호 글머리표
- 그림 글머리표
- 사용자 정의 글머리표
- 다단계 목록
- 글머리표 만들기
- 글머리표 추가
- 목록 추가
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 글머리표, 그림, 다단계 및 번호 매기기 목록을 만들고 서식 지정하는 방법을 배웁니다."
---
## **개요**

Aspose.Slides for Python via .NET를 사용하면 PowerPoint 및 OpenDocument 프레젠테이션에서 글머리표 및 번호 매기기 목록을 만들고 서식 지정할 수 있습니다. 목록 항목은 글머리표 설정이 해당 단락 형식을 통해 제어되는 단락입니다.

단락 수준 목록 설정에 접근하려면 [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/) 속성을 사용하십시오. 주요 진입점은 [ParagraphFormat.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/bullet/)이며, 이는 [BulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/) 객체를 반환합니다. 이 객체를 사용하여 글머리표 유형, 기호, 그림, 색상, 크기, 번호 매기기 스타일 및 시작 번호를 설정할 수 있습니다.

이 문서에서는 다음과 같은 방법을 보여줍니다:
- 사용자 정의 기호로 글머리표 목록 만들기
- 그림 글머리표 만들기
- 단락 깊이를 설정하여 다단계 목록 만들기
- 번호 매기기 목록 만들기
- 기존 프레젠테이션에서 목록 서식을 검사하고 변경하기
- 단락 텍스트와 함께 실제 목록 마커 및 번호 읽기

## **글머리표 목록 만들기**

글머리표 목록을 만들려면 [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) 객체를 [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)에 추가하고 [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/)을 [BulletType.SYMBOL](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/)으로 설정합니다. 그런 다음 [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/), [BulletFormat.color](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/color/), 및 [BulletFormat.height](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/height/)를 설정하여 글머리표 모양을 제어할 수 있습니다.

다음 Python 코드는 슬라이드에서 글머리표 목록을 만드는 방법을 보여줍니다:

```py
import aspose.slides as slides

def create_paragraph(text):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = '*'
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    paragraph.paragraph_format.bullet.color.color = slides.Color.indian_red
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = text
    return paragraph


with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 50)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = create_paragraph("The first paragraph")
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = create_paragraph("The second paragraph")
    text_frame.paragraphs.add(paragraph2)

    presentation.save("symbol_bullets.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![기호 글머리표](symbol_bullets.png)

## **번호 매기기 목록 만들기**

항목 순서가 중요한 경우 번호 매기기 목록을 사용합니다. [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/)을 [BulletType.NUMBERED](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/)로 설정합니다. 또한 [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_style/)으로 번호 매기기 형식을 선택하거나, 목록을 1이 아닌 값에서 시작하도록 해야 할 경우 [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/)을 설정할 수 있습니다.

다음 Python 코드는 슬라이드에서 번호 매기기 목록을 만드는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 90, 80)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = slides.Paragraph()
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph1.text = "Apple"
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.text = "Orange"
    text_frame.paragraphs.add(paragraph2)

    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph3.text = "Banana"
    text_frame.paragraphs.add(paragraph3)

    presentation.save("numbered_bullets.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![번호 매기기 글머리표](numbered_bullets.png)

## **그림 글머리표 만들기**

Aspose.Slides를 사용하면 일반 글머리표 기호를 이미지로 교체할 수 있습니다. 그림 글머리표는 아이콘이나 작은 투명 PNG 파일과 같이 작은 크기에서도 읽기 쉬운 단순한 이미지와 가장 잘 작동합니다.

{{% alert color="info" title="Note" %}}
가능하면 일반 글머리표 기호를 이미지로 교체하려는 경우 투명 배경이 있는 단순한 그래픽을 선택하는 것이 가장 좋습니다. 이러한 이미지는 사용자 정의 글머리표 기호로 잘 활용됩니다.

이미지는 매우 작은 크기로 축소된다는 점을 기억하십시오. 따라서 목록의 글머리표로 사용할 때도 선명하고 시각적으로 효과적인 이미지를 선택하는 것을 강력히 권장합니다.
{{% /alert %}}

그림 글머리표를 만들려면 [Presentation.images](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/images/)에 이미지를 추가하고 반환된 이미지 객체를 [BulletFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/picture/)에 할당합니다. 이미지를 할당하기 전에 [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/)을 [BulletType.PICTURE](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/)으로 설정하십시오.

예를 들어 "image.png" 파일이 있다고 가정해 보겠습니다:

![글머리표용 이미지](picture_for_bullets.png)

다음 Python 코드는 슬라이드에서 그림 글머리표를 만드는 방법을 보여줍니다:

```py
import aspose.slides as slides

def create_paragraph(text, image):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = image
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = text
    return paragraph


with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 50)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    with open("image.png", "rb") as image_stream:
        bullet_image = presentation.images.add_image(image_stream)

    paragraph1 = create_paragraph("The first paragraph", bullet_image)
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = create_paragraph("The second paragraph", bullet_image)
    text_frame.paragraphs.add(paragraph2)

    presentation.save("picture_bullets.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![그림 글머리표](picture_bullets.png)

## **다단계 목록 만들기**

[ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/)를 사용하여 목록 항목을 다른 수준에 배치합니다. 레벨 0은 최상위 수준이며, 레벨 1은 그 아래에 중첩됩니다. 깊이는 들여쓰기만 제어합니다; 레벨에 글머리표도 포함되어야 할 경우 각 단락에서 [ParagraphFormat.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/bullet/)를 설정하십시오.

다음 Python 코드는 다단계 목록을 만드는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 260, 110)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = slides.Paragraph()
    paragraph1.paragraph_format.depth = 0
    paragraph1.text = "My text - Depth 0"
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.depth = 1
    paragraph2.text = "My text - Depth 1"
    text_frame.paragraphs.add(paragraph2)

    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.depth = 2
    paragraph3.text = "My text - Depth 2"
    text_frame.paragraphs.add(paragraph3)

    paragraph4 = slides.Paragraph()
    paragraph4.paragraph_format.depth = 3
    paragraph4.text = "My text - Depth 3"
    text_frame.paragraphs.add(paragraph4)

    presentation.save("multilevel_bullets.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![다단계 목록](multilevel_list.png)

## **기존 목록 변경하기**

기존 프레젠테이션에서 목록 서식을 변경하려면 대상 단락에 접근하여 해당 [ParagraphFormat.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/bullet/) 설정을 업데이트합니다. 목록을 만들 때 사용한 동일한 속성을 사용하여 PPT, PPTX 또는 ODP 파일에서 로드된 목록을 검사하거나 수정할 수 있습니다.

다음 Python 코드는 텍스트 프레임의 첫 번째 단락을 번호 매기기 목록 스타일로 변경합니다:

```py
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_ROMAN_UC_PERIOD
    paragraph.paragraph_format.bullet.numbered_bullet_start_with = 1
    paragraph.paragraph_format.margin_left = 30
    paragraph.paragraph_format.indent = -20

    presentation.save("updated_list.pptx", slides.export.SaveFormat.PPTX)
```

## **실제 글머리표 값 읽기**

프레젠테이션 콘텐츠를 추출할 때 목록 마커를 단락 텍스트와 함께 유지합니다. [ParagraphFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/get_effective/)를 호출하고 [IParagraphFormatEffectiveData.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraphformateffectivedata/bullet/)에 접근하여 실제 적용된 글머리표 형식을 가져옵니다. [actual_bullet_value](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/actual_bullet_value/)를 읽기 전에 해당 [type](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/type/)을 확인하십시오.

번호 매기기 목록의 경우 다음 세 값을 구분합니다:
- [numbered_bullet_style](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/numbered_bullet_style/)는 형식을 결정합니다. 예를 들어 점(.) 뒤에 오는 아라비아 숫자 또는 소문자 알파벳 등이 있습니다.
- [numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/numbered_bullet_start_with/)은 번호 매기기 단락 그룹의 시작 번호를 지정합니다.
- [actual_bullet_value](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/actual_bullet_value/)은 특정 단락에 대한 형식화된 마커를 반환합니다. 예를 들어, 5에서 시작하는 목록의 두 번째 항목은 `6.`을 반환합니다.

각 단락에 [depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/)를 보존하여 중첩 수준을 유지하십시오. 실제 마커는 전체 계층 구조를 인코딩하지 않습니다; 중첩된 항목은 `6.c.`와 같은 결합 라벨 대신 `c.`를 반환할 수 있습니다.

다음 독립 실행형 예제는 목록을 생성하고 프레젠테이션에 저장한 뒤 프레젠테이션을 다시 로드하여 각 단락의 텍스트, 깊이, 글머리표 유형 및 실제 값을 보고합니다. 작은 파란색 그림 마커는 인라인 SVG에서 생성됩니다.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 440, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 20, 660, 400)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    # 외부 이미지 파일 없이 그림 마커를 생성합니다.
    svg = slides.SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>")
    bullet_image = presentation.images.add_image(svg)

    def add_paragraph(text, depth, bullet_type, start=1, style=slides.NumberedBulletStyle.BULLET_ARABIC_PERIOD):
        paragraph = slides.Paragraph()
        paragraph.text = text

        paragraph_format = paragraph.paragraph_format
        paragraph_format.depth = depth
        paragraph_format.margin_left = 30 + depth * 40
        paragraph_format.indent = -28
        paragraph_format.space_after = 8
        paragraph_format.default_portion_format.font_height = 22
        paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph_format.default_portion_format.fill_format.solid_fill_color.color = slides.Color.black
        paragraph_format.bullet.type = bullet_type
        paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
        paragraph_format.bullet.color.color = slides.Color.black
        if bullet_type == slides.BulletType.NUMBERED:
            paragraph_format.bullet.numbered_bullet_style = style
            paragraph_format.bullet.numbered_bullet_start_with = start
        elif bullet_type == slides.BulletType.SYMBOL:
            paragraph_format.bullet.char = "\u2022"
        elif bullet_type == slides.BulletType.PICTURE:
            paragraph_format.bullet.picture.image = bullet_image

        text_frame.paragraphs.add(paragraph)

    add_paragraph("First item", 0, slides.BulletType.NUMBERED, 5)
    add_paragraph("Second item", 0, slides.BulletType.NUMBERED, 5)
    add_paragraph("Nested item", 1, slides.BulletType.NUMBERED, 3, slides.NumberedBulletStyle.BULLET_ALPHA_LC_PERIOD)
    add_paragraph("Next nested item", 1, slides.BulletType.NUMBERED, 3, slides.NumberedBulletStyle.BULLET_ALPHA_LC_PERIOD)
    add_paragraph("Deep item", 2, slides.BulletType.NUMBERED, 4, slides.NumberedBulletStyle.BULLET_ROMAN_LC_PERIOD)
    add_paragraph("Back to top level", 0, slides.BulletType.NUMBERED, 5)
    add_paragraph("Symbol marker", 0, slides.BulletType.SYMBOL)
    add_paragraph("No bullet", 0, slides.BulletType.NONE)
    add_paragraph("Picture marker", 0, slides.BulletType.PICTURE)
    presentation.save("actual_bullet_values.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("actual_bullet_values.pptx") as loaded_presentation:
    loaded_shape = loaded_presentation.slides[0].shapes[0]
    bullet_type_names = {slides.BulletType.NUMBERED: "NUMBERED", slides.BulletType.SYMBOL: "SYMBOL", slides.BulletType.NONE: "NONE", slides.BulletType.PICTURE: "PICTURE"}
    print("Text | Depth | Type | Actual value")
    for paragraph in loaded_shape.text_frame.paragraphs:
        bullet = paragraph.paragraph_format.get_effective().bullet
        if bullet.type in (slides.BulletType.NUMBERED, slides.BulletType.SYMBOL):
            marker = bullet.actual_bullet_value
        elif bullet.type == slides.BulletType.NONE:
            marker = f"{bullet.actual_bullet_value} (no bullet)"
        elif bullet.type == slides.BulletType.PICTURE:
            marker = f"{bullet.actual_bullet_value} (image required)"
        else:
            marker = "unsupported bullet type"
        bullet_type_name = bullet_type_names.get(bullet.type, "UNKNOWN")
        print(f"{paragraph.text} | {paragraph.paragraph_format.depth} | {bullet_type_name} | {marker}")
```

아래에 소스 목록이 표시됩니다.

![5부터 시작하는 목록, 중첩된 문자 및 로마 번호 항목, 기호 마커, 글머리표 없는 단락, 파란색 그림 마커](actual_bullet_values.png)

보고서는 PowerPoint에 표시된 마커와 일치합니다:

```text
Text | Depth | Type | Actual value
First item | 0 | NUMBERED | 5.
Second item | 0 | NUMBERED | 6.
Nested item | 1 | NUMBERED | c.
Next nested item | 1 | NUMBERED | d.
Deep item | 2 | NUMBERED | iv.
Back to top level | 0 | NUMBERED | 7.
Symbol marker | 0 | SYMBOL | •
No bullet | 0 | NONE | None (no bullet)
Picture marker | 0 | PICTURE | None (image required)
```

[BulletType.NONE 및 BulletType.PICTURE](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/)의 경우, [actual_bullet_value](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/actual_bullet_value/)은 빈 문자열이 아니라 `None`을 반환합니다. 이러한 유형을 별도로 처리하십시오: 전자는 마커가 없으며, 후자는 글머리표 이미지를 별도로 추출해야 합니다. 그림 글머리표는 텍스트 마커만 추출하여 재현할 수 없습니다.

## **FAQ**

**글머리표 및 번호 매기기 목록을 PDF나 이미지로 내보낼 수 있나요?**

예. Aspose.Slides는 대상 형식이 해당 텍스트 레이아웃 및 글머리표 기능을 지원하는 경우 목록 서식을 보존합니다.

**기존 프레젠테이션에서 목록을 편집할 수 있나요?**

예. 프레젠테이션을 로드하고 대상 단락에 접근하여 해당 [ParagraphFormat.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/bullet/) 설정을 검사하거나 업데이트한 후 프레젠테이션을 저장하면 됩니다.

**목록에 비라틴 문자 텍스트를 포함할 수 있나요?**

예. 목록 항목 텍스트는 유니코드 문자를 포함할 수 있으므로 다국어 프레젠테이션에서 목록을 만들 수 있습니다. 프레젠테이션에 사용된 글꼴이 필요한 문자를 지원하는지 확인하십시오.