---
title: Python으로 PowerPoint 텍스트 단락 관리
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
  - 글머리 기호 관리
  - 단락 들여쓰기
  - 매달린 들여쓰기
  - 단락 글머리 기호
  - 번호 매기기 목록
  - 글머리 기호 목록
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
description: "Aspose.Slides for Python via .NET를 사용하여 단락 서식을 마스터하고, PowerPoint 및 OpenDocument 프레젠테이션에서 정렬, 간격 및 스타일을 최적화하여 Python으로 시청자를 사로잡으세요."
---
## **소개**

Aspose.Slides는 Python에서 PowerPoint 텍스트를 작업하는 데 필요한 클래스를 제공합니다.

* Aspose.Slides는 텍스트 프레임 객체를 만들기 위한 [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/) 클래스를 제공합니다. `TextFrame` 객체는 하나 이상의 단락을 포함할 수 있으며(각 단락은 캐리지 리턴으로 구분됩니다).
* Aspose.Slides는 단락 객체를 만들기 위한 [Paragraph](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraph/) 클래스를 제공합니다. `Paragraph` 객체는 하나 이상의 텍스트 부분을 포함할 수 있습니다.
* Aspose.Slides는 텍스트 부분 객체를 만들고 해당 서식 속성을 지정하기 위한 [Portion](https://reference.aspose.com/slides/ko/python-net/aspose.slides/portion/) 클래스를 제공합니다.

`Paragraph` 객체는 기본 `Portion` 객체를 통해 다양한 서식 속성을 가진 텍스트를 처리할 수 있습니다.

## **다중 Portion을 포함하는 여러 단락 추가**

다음 단계에서는 세 개의 단락을 포함하고 각 단락마다 세 개의 Portion이 있는 텍스트 프레임을 추가하는 방법을 보여줍니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 사용하여 대상 슬라이드에 대한 참조를 가져옵니다.
3. 슬라이드에 직사각형 [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/)을 추가합니다.
4. [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/)와 연결된 [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/)을 가져옵니다.
5. 두 개의 [Paragraph](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraph/) 객체를 만들고 이를 [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/)의 단락 컬렉션에 추가합니다(기본 단락과 함께 세 개의 단락이 됩니다).
6. 각 단락마다 세 개의 [Portion](https://reference.aspose.com/slides/ko/python-net/aspose.slides/portion/) 객체를 만들어 해당 단락의 Portion 컬렉션에 추가합니다.
7. 각 Portion에 텍스트를 설정합니다.
8. [Portion](https://reference.aspose.com/slides/ko/python-net/aspose.slides/portion/)이 제공하는 속성을 사용하여 각 텍스트 Portion에 원하는 서식을 적용합니다.
9. 수정된 프레젠테이션을 저장합니다.

다음 Python 코드가 이러한 단계를 구현합니다:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Presentation 클래스를 인스턴스화하여 새 PPTX 파일을 생성합니다.
with slides.Presentation() as presentation:

    # 첫 번째 슬라이드에 접근합니다.
    slide = presentation.slides[0]

    # 직사각형 AutoShape을 추가합니다.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)

    # AutoShape의 TextFrame에 접근합니다.
    text_frame = shape.text_frame

    # 단락과 Portion을 생성합니다; 아래에서 서식을 적용합니다.
    paragraph0 = text_frame.paragraphs[0]
    portion01 = slides.Portion()
    portion02 = slides.Portion()
    paragraph0.portions.add(portion01)
    paragraph0.portions.add(portion02)

    paragraph1 = slides.Paragraph()
    text_frame.paragraphs.add(paragraph1)
    portion10 = slides.Portion()
    portion11 = slides.Portion()
    portion12 = slides.Portion()
    paragraph1.portions.add(portion10)
    paragraph1.portions.add(portion11)
    paragraph1.portions.add(portion12)

    paragraph2 = slides.Paragraph()
    text_frame.paragraphs.add(paragraph2)
    portion20 = slides.Portion()
    portion21 = slides.Portion()
    portion22 = slides.Portion()
    paragraph2.portions.add(portion20)
    paragraph2.portions.add(portion21)
    paragraph2.portions.add(portion22)

    for i in range(3):
        for j in range(3):
            text_frame.paragraphs[i].portions[j].text = "Portion0" + str(j)
            if j == 0:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.red
                text_frame.paragraphs[i].portions[j].portion_format.font_bold = 1
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 15
            elif j == 1:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                text_frame.paragraphs[i].portions[j].portion_format.font_italic = 1
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 18

    # PPTX를 디스크에 저장합니다.
    presentation.save("paragraphs_and_portions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **단락 글머리 기호 관리**

글머리 기호 목록은 정보를 빠르고 효율적으로 구성하고 제시하는 데 도움이 됩니다. 글머리 기호가 있는 단락은 흔히 읽고 이해하기가 더 쉽습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 사용하여 대상 슬라이드에 접근합니다.
3. 슬라이드에 [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/)를 추가합니다.
4. 해당 도형의 [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/)에 접근합니다.
5. [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/)의 기본 단락을 제거합니다.
6. [Paragraph](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraph/) 클래스를 사용해 첫 번째 단락을 생성합니다.
7. 단락의 글머리 기호 유형을 `SYMBOL`로 설정하고 글머리 기호 문자를 지정합니다.
8. 단락의 텍스트를 설정합니다.
9. 단락의 글머리 기호 들여쓰기를 설정합니다.
10. 글머리 기호 색상을 설정합니다.
11. 글머리 기호 크기(높이)를 설정합니다.
12. 단락을 [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/)의 단락 컬렉션에 추가합니다.
13. 두 번째 단락을 추가하고 단계 7~12를 반복합니다.
14. 프레젠테이션을 저장합니다.

다음 Python 코드는 글머리 기호가 있는 단락을 추가하는 방법을 보여줍니다:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 프레젠테이션 인스턴스를 생성합니다.
with slides.Presentation() as presentation:

    # 첫 번째 슬라이드에 접근합니다.
    slide = presentation.slides[0]

    # AutoShape을 추가하고 접근합니다.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # 생성된 AutoShape의 텍스트 프레임에 접근합니다.
    text_frame = shape.text_frame

    # 기본 단락을 제거합니다.
    text_frame.paragraphs.remove_at(0)

    # 단락을 생성합니다.
    paragraph = slides.Paragraph()

    # 단락의 글머리 기호 스타일과 기호를 설정합니다.
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = chr(8226)

    # 단락 텍스트를 설정합니다.
    paragraph.text = "Welcome to Aspose.Slides"

    # 글머리 들여쓰기를 설정합니다.
    paragraph.paragraph_format.indent = 25

    # 글머리 색상을 설정합니다.
    paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph.paragraph_format.bullet.color.color = draw.Color.black
    paragraph.paragraph_format.bullet.is_bullet_hard_color = 1 

    # 글머리 높이를 설정합니다.
    paragraph.paragraph_format.bullet.height = 100

    # 단락을 텍스트 프레임에 추가합니다.
    text_frame.paragraphs.add(paragraph)

    # 두 번째 단락을 생성합니다.
    paragraph2 = slides.Paragraph()

    # 단락의 글머리 유형과 스타일을 설정합니다.
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WDBLACK_PLAIN

    # 단락 텍스트를 설정합니다.
    paragraph2.text = "This is numbered bullet"

    # 글머리 들여쓰기를 설정합니다.
    paragraph2.paragraph_format.indent = 25

    # 글머리 색상을 설정합니다.
    paragraph2.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph2.paragraph_format.bullet.color.color = draw.Color.black
    paragraph2.paragraph_format.bullet.is_bullet_hard_color = 1

    # 글머리 높이를 설정합니다.
    paragraph2.paragraph_format.bullet.height = 100

    # 단락을 텍스트 프레임에 추가합니다.
    text_frame.paragraphs.add(paragraph2)

    # 프레젠테이션을 PPTX 파일로 저장합니다.
    presentation.save("bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **그림 글머리 기호 관리**

글머리 기호 목록은 정보를 빠르고 효율적으로 구성하고 제시하는 데 도움이 됩니다. 그림 글머리 기호는 읽고 이해하기 쉽습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 사용하여 대상 슬라이드에 접근합니다.
3. 슬라이드에 [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/)를 추가합니다.
4. 해당 도형의 [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/)에 접근합니다.
5. [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/)의 기본 단락을 제거합니다.
6. [Paragraph](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraph/) 클래스를 사용해 첫 번째 단락을 생성합니다.
7. 이미지를 [PPImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ppimage/)에 로드합니다.
8. 글머리 기호 유형을 [PPImage](https://reference.aspose.com/slides/ko/python-net/aspose.slides/ppimage/)으로 설정하고 이미지를 할당합니다.
9. 단락 텍스트를 설정합니다.
10. 글머리 기호에 대한 단락 들여쓰기를 설정합니다.
11. 글머리 기호 색상을 설정합니다.
12. 글머리 기호 높이를 설정합니다.
13. 새 단락을 [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/)의 단락 컬렉션에 추가합니다.
14. 두 번째 단락을 추가하고 단계 8~12를 반복합니다.
15. 프레젠테이션을 저장합니다.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:

    # 첫 번째 슬라이드에 접근합니다.
    slide = presentation.slides[0]

    # 글머리 이미지 로드합니다.
    image = draw.Bitmap("bullets.png")
    pp_image = presentation.images.add_image(image)

    # AutoShape을 추가하고 접근합니다.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # 생성된 AutoShape의 TextFrame에 접근합니다.
    text_frame = auto_shape.text_frame

    # 기본 단락을 제거합니다.
    text_frame.paragraphs.remove_at(0)

    # 새로운 단락을 생성합니다.
    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"

    # 단락의 글머리 기호 유형을 그림으로 설정하고 이미지를 할당합니다.
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = pp_image

    # 글머리 높이를 설정합니다.
    paragraph.paragraph_format.bullet.height = 100

    # 단락을 텍스트 프레임에 추가합니다.
    text_frame.paragraphs.add(paragraph)

    # 프레젠테이션을 PPTX 파일로 저장합니다.
    presentation.save("picture_bullets_out.pptx", slides.export.SaveFormat.PPTX)
    # 프레젠테이션을 PPT 파일로 저장합니다.
    presentation.save("picture_bullets_out.ppt", slides.export.SaveFormat.PPT)
```

## **다단계 글머리 기호 관리**

글머리 기호 목록은 정보를 빠르고 효율적으로 구성하고 제시하는 데 도움이 됩니다. 다단계 글머리 기호는 읽고 이해하기 쉽습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 사용하여 대상 슬라이드에 접근합니다.
3. 슬라이드에 [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/)를 추가합니다.
4. [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/)의 [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/)에 접근합니다.
5. [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/)의 기본 단락을 제거합니다.
6. [Paragraph](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraph/) 클래스를 사용해 첫 번째 단락을 만들고 깊이를 0으로 설정합니다.
7. 두 번째 단락을 만들고 깊이를 1로 설정합니다.
8. 세 번째 단락을 만들고 깊이를 2로 설정합니다.
9. 네 번째 단락을 만들고 깊이를 3으로 설정합니다.
10. 새 단락들을 [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/)의 단락 컬렉션에 추가합니다.
11. 프레젠테이션을 저장합니다.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# 프레젠테이션 인스턴스를 생성합니다.
with slides.Presentation() as presentation:

    # 첫 번째 슬라이드에 접근합니다.
    slide = presentation.slides[0]
    
    # AutoShape을 추가합니다.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # 생성된 AutoShape의 TextFrame에 접근합니다.
    text_frame = auto_shape.text_frame
    
    # 기본 단락을 제거합니다.
    text_frame.paragraphs.clear()

    # 첫 번째 단락을 추가합니다.
    paragraph1 = slides.Paragraph()
    paragraph1.text = "Content"
    paragraph1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph1.paragraph_format.bullet.char = chr(8226)
    paragraph1.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph1.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # 글머리 수준을 설정합니다.
    paragraph1.paragraph_format.depth = 0

    # 두 번째 단락을 추가합니다.
    paragraph2 = slides.Paragraph()
    paragraph2.text = "Second Level"
    paragraph2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph2.paragraph_format.bullet.char = '-'
    paragraph2.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph2.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # 글머리 수준을 설정합니다.
    paragraph2.paragraph_format.depth = 1

    # 세 번째 단락을 추가합니다.
    paragraph3 = slides.Paragraph()
    paragraph3.text = "Third Level"
    paragraph3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph3.paragraph_format.bullet.char = chr(8226)
    paragraph3.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph3.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # 글머리 수준을 설정합니다.
    paragraph3.paragraph_format.depth = 2

    # 네 번째 단락을 추가합니다.
    paragraph4 = slides.Paragraph()
    paragraph4.text = "Fourth Level"
    paragraph4.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph4.paragraph_format.bullet.char = '-'
    paragraph4.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph4.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # 글머리 수준을 설정합니다.
    paragraph4.paragraph_format.depth = 3

    # 단락들을 컬렉션에 추가합니다.
    text_frame.paragraphs.add(paragraph1)
    text_frame.paragraphs.add(paragraph2)
    text_frame.paragraphs.add(paragraph3)
    text_frame.paragraphs.add(paragraph4)

    # 프레젠테이션을 PPTX 파일로 저장합니다.
    presentation.save("multilevel_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **사용자 지정 번호 매기기 목록이 있는 단락 관리**

[BulletFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides/bulletformat/) 클래스는 `numbered_bullet_start_with` 속성(및 기타 속성)을 제공하여 단락에 대한 사용자 지정 번호 매기기 및 서식을 제어합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 단락을 포함할 슬라이드에 접근합니다.
3. 슬라이드에 [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/)를 추가합니다.
4. 도형의 [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/)에 접근합니다.
5. [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/)의 기본 단락을 제거합니다.
6. 첫 번째 [Paragraph](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraph/)을 만들고 `numbered_bullet_start_with`를 2로 설정합니다.
7. 두 번째 [Paragraph](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraph/)을 만들고 `numbered_bullet_start_with`를 3으로 설정합니다.
8. 세 번째 [Paragraph](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraph/)을 만들고 `numbered_bullet_start_with`를 7로 설정합니다.
9. 단락들을 [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/)의 컬렉션에 추가합니다.
10. 프레젠테이션을 저장합니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # AutoShape을 추가하고 접근합니다.
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # 생성된 AutoShape의 TextFrame에 접근합니다.
    text_frame = shape.text_frame

    # 기존 기본 단락을 제거합니다.
    text_frame.paragraphs.remove_at(0)

    # 첫 번째 번호 매긴 항목을 생성합니다 (시작 2, 깊이 수준 4).
    paragraph1 = slides.Paragraph()
    paragraph1.text = "bullet 2"
    paragraph1.paragraph_format.depth = 4 
    paragraph1.paragraph_format.bullet.numbered_bullet_start_with = 2
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph1)

    # 두 번째 번호 매긴 항목을 생성합니다 (시작 3, 깊이 수준 4).
    paragraph2 = slides.Paragraph()
    paragraph2.text = "bullet 3"
    paragraph2.paragraph_format.depth = 4
    paragraph2.paragraph_format.bullet.numbered_bullet_start_with = 3 
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED  
    text_frame.paragraphs.add(paragraph2)

    # 세 번째 번호 매긴 항목을 생성합니다 (시작 7, 깊이 수준 4).
    paragraph5 = slides.Paragraph()
    paragraph5.text = "bullet 7"
    paragraph5.paragraph_format.depth = 4
    paragraph5.paragraph_format.bullet.numbered_bullet_start_with = 7
    paragraph5.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph5)

    presentation.save("custom_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **단락의 첫 줄 들여쓰기 설정**

[ParagraphFormat.indent](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraphformat/indent/) 속성을 사용하여 단락의 첫 줄 들여쓰기를 제어합니다. 이 속성은 단락의 왼쪽 여백에 대해 첫 번째 줄만 이동시킵니다. 양수 값은 첫 줄을 오른쪽으로 이동시키고, 나머지 줄은 단락 본문에 맞춰 정렬됩니다.

전체 단락을 이동시켜야 할 경우 [ParagraphFormat.margin_left](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraphformat/margin_left/)을 사용합니다. 첫 줄만 이동시켜야 할 경우 [ParagraphFormat.indent](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraphformat/indent/)을 사용합니다.

아래 예제는 여러 단락을 생성하고 서로 다른 `indent` 값을 적용하여 첫 줄 들여쓰기가 단락 레이아웃에 어떻게 영향을 미치는지 보여줍니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 대상 슬라이드에 접근합니다.
3. 슬라이드에 직사각형 [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/)를 추가합니다.
4. 도형에 빈 [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/)을 추가하고 기본 단락을 제거합니다.
5. 여러 단락을 만들고 각각에 다른 [indent](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraphformat/indent/) 값을 설정합니다.
6. 단락들을 텍스트 프레임에 추가합니다.
7. 수정된 프레젠테이션을 저장합니다.

다음 코드는 단락 들여쓰기를 설정하는 방법을 보여줍니다:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    rectangle.fill_format.fill_type = slides.FillType.NO_FILL
    rectangle.line_format.fill_format.fill_type = slides.FillType.SOLID
    rectangle.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = rectangle.add_text_frame("")
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.remove_at(0)

    first_paragraph = slides.Paragraph()
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.text = "No first-line indent. Wrapped lines start at the same position as the first line."
    first_paragraph.paragraph_format.margin_left = 20.0
    first_paragraph.paragraph_format.indent = 0.0

    second_paragraph = slides.Paragraph()
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body."
    second_paragraph.paragraph_format.margin_left = 20.0
    second_paragraph.paragraph_format.indent = 20.0

    third_paragraph = slides.Paragraph()
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see."
    third_paragraph.paragraph_format.margin_left = 20.0
    third_paragraph.paragraph_format.indent = 40.0

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("paragraph_indent.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![단락의 첫 줄 들여쓰기](first_line_indent.png)

## **단락의 매달린 들여쓰기 설정**

매달린 들여쓰기는 첫 번째 줄이 나머지 줄보다 왼쪽에서 시작하는 단락 레이아웃입니다. Aspose.Slides에서는 [ParagraphFormat.indent](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraphformat/indent/) 속성을 사용하여 이 효과를 만들 수 있습니다. `indent`를 음수 값으로 설정하면 첫 번째 줄이 단락 본문에 대해 왼쪽으로 이동합니다.

실제로 [ParagraphFormat.margin_left](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraphformat/margin_left/)은 단락 본문의 왼쪽 위치를 정의하고, [ParagraphFormat.indent](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraphformat/indent/)는 해당 여백에 대한 첫 번째 줄의 위치를 정의합니다. 매달린 들여쓰기를 만들려면 양의 `margin_left` 값과 음의 `indent` 값을 설정합니다.

이 서식은 참고 문헌, 인용구, 용어 설명 및 줄 바꿈된 줄이 첫 번째 줄의 첫 문자 아래가 아니라 단락 본문 아래에 정렬되어야 하는 기타 단락에 유용합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 대상 슬라이드에 접근합니다.
3. 슬라이드에 직사각형 [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/)를 추가합니다.
4. 도형에 빈 [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/)을 추가하고 기본 단락을 제거합니다.
5. 각 단락에 대해 양의 [margin_left](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraphformat/margin_left/) 값을 설정합니다.
6. 매달린 들여쓰기 효과를 만들기 위해 음의 [indent](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraphformat/indent/) 값을 설정합니다.
7. 단락들을 텍스트 프레임에 추가합니다.
8. 수정된 프레젠테이션을 저장합니다.

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    rectangle.fill_format.fill_type = slides.FillType.NO_FILL
    rectangle.line_format.fill_format.fill_type = slides.FillType.SOLID
    rectangle.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = rectangle.add_text_frame("")
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.remove_at(0)

    first_paragraph = slides.Paragraph()
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body."
    first_paragraph.paragraph_format.margin_left = 40.0
    first_paragraph.paragraph_format.indent = -20.0

    second_paragraph = slides.Paragraph()
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare."
    second_paragraph.paragraph_format.margin_left = 60.0
    second_paragraph.paragraph_format.indent = -30.0

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("hanging_indent.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![단락의 매달린 들여쓰기](hanging_indent.png)

## **단락 끝 Portion 서식 관리**

단락의 '끝' 스타일링(마지막 텍스트 Portion 뒤에 적용되는 서식)을 제어해야 할 때는 `end_paragraph_portion_format` 속성을 사용합니다. 아래 예제는 두 번째 단락의 끝에 더 큰 Times New Roman 폰트를 적용합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 파일을 생성하거나 엽니다.
2. 인덱스로 대상 슬라이드를 가져옵니다.
3. 슬라이드에 사각형 [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/)을 추가합니다.
4. 도형의 [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/)을 사용하고 두 개의 단락을 만듭니다.
5. 48pt Times New Roman으로 설정된 [PortionFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides/portionformat/)을 생성하고 이를 단락의 end_paragraph_portion_format으로 적용합니다.
6. 이를 단락의 `end_paragraph_portion_format`에 할당합니다(두 번째 단락의 끝에 적용).
7. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
	shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)

	paragraph1 = slides.Paragraph()
	paragraph1.portions.add(slides.Portion("Sample text"))

	end_paragraph_portion_format = slides.PortionFormat()
	end_paragraph_portion_format.font_height = 48
	end_paragraph_portion_format.latin_font = slides.FontData("Times New Roman")

	paragraph2 = slides.Paragraph()
	paragraph2.portions.add(slides.Portion("Sample text 2"))
	paragraph2.end_paragraph_portion_format = end_paragraph_portion_format

	shape.text_frame.paragraphs.add(paragraph1)
	shape.text_frame.paragraphs.add(paragraph2)

	presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **HTML 텍스트를 단락으로 가져오기**

Aspose.Slides는 HTML 텍스트를 단락으로 가져오는 향상된 지원을 제공합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 사용하여 대상 슬라이드에 접근합니다.
3. 슬라이드에 [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/)를 추가합니다.
4. [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/)의 [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/)에 접근합니다.
5. [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/)의 기본 단락을 제거합니다.
6. 원본 HTML 파일을 읽습니다.
7. [Paragraph](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraph/) 클래스를 사용해 첫 번째 단락을 생성합니다.
8. HTML 콘텐츠를 [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/)의 단락 컬렉션에 추가합니다.
9. 수정된 프레젠테이션을 저장합니다.

```python
import aspose.slides as slides

# 빈 프레젠테이션 인스턴스를 생성합니다.
with slides.Presentation() as presentation:

    # 프레젠테이션의 첫 번째 슬라이드에 접근합니다.
    slide = presentation.slides[0]

    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    # HTML 콘텐츠를 포함하도록 AutoShape을 추가합니다.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, slide_width - 20, slide_height - 10)

    # 추가된 텍스트 프레임의 모든 단락을 삭제합니다.
    shape.text_frame.paragraphs.clear()

    # HTML 파일을 로드합니다.
    with open("file.html", "rt") as html_stream:
        # HTML 파일의 텍스트를 텍스트 프레임에 추가합니다.
        shape.text_frame.paragraphs.add_from_html(html_stream.read())

    # 프레젠테이션을 저장합니다.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **단락 텍스트를 HTML로 내보내기**

Aspose.Slides는 텍스트를 HTML로 내보내는 향상된 지원을 제공합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성하고 대상 프레젠테이션을 로드합니다.
2. 인덱스로 원하는 슬라이드에 접근합니다.
3. 내보낼 텍스트가 포함된 도형을 선택합니다.
4. 도형의 [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/)에 접근합니다.
5. HTML 출력을 쓰기 위해 파일 스트림을 엽니다.
6. 시작 인덱스를 지정하고 필요한 단락을 내보냅니다.

```python
import aspose.slides as slides

# 프레젠테이션 파일을 로드합니다.
with slides.Presentation("exporting_HTML_text.pptx") as presentation:
    # 프레젠테이션의 첫 번째 슬라이드에 접근합니다.
    slide = presentation.slides[0]

    # 대상 도형 인덱스.
    index = 0

    # 인덱스로 도형에 접근합니다.
    shape = slide.shapes[index]

    with open("output.html", "w") as html_stream:
        # 시작 단락 인덱스와 내보낼 전체 단락 수를 지정하여 단락 데이터를 HTML로 씁니다.
        html_stream.write(shape.text_frame.paragraphs.export_to_html(0, shape.text_frame.paragraphs.count, None))
```

## **단락을 이미지로 저장**

이 섹션에서는 [Paragraph](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraph/) 클래스로 표현된 텍스트 단락을 이미지로 저장하는 방법을 보여주는 두 가지 예제를 살펴봅니다. 두 예제 모두 [Shape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/) 클래스의 `get_image` 메서드를 사용하여 단락이 포함된 도형의 이미지를 가져오고, 도형 내 단락의 경계를 계산한 뒤 비트맵 이미지로 내보냅니다. 이러한 접근 방식은 PowerPoint 프레젠테이션에서 텍스트의 특정 부분을 추출하여 별도의 이미지로 저장할 수 있게 하며, 다양한 시나리오에서 유용하게 사용할 수 있습니다.

sample.pptx라는 프레젠테이션 파일에 슬라이드가 하나 있고, 첫 번째 도형이 세 개의 단락을 포함한 텍스트 상자라고 가정해 보겠습니다.

![세 개의 단락이 있는 텍스트 상자](paragraph_to_image_input.png)

**예제 1**

이 예제에서는 두 번째 단락을 이미지로 가져옵니다. 이를 위해 프레젠테이션의 첫 번째 슬라이드에서 도형의 이미지를 추출하고, 해당 도형의 텍스트 프레임에서 두 번째 단락의 경계를 계산합니다. 그런 다음 단락을 새 비트맵 이미지에 다시 그려 PNG 형식으로 저장합니다. 이 방법은 텍스트의 정확한 크기와 서식을 유지하면서 특정 단락을 별도의 이미지로 저장해야 할 때 특히 유용합니다.

```py
import aspose.slides as slides
import math
import io
from PIL import Image

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # 모양을 메모리에 비트맵으로 저장합니다.
    with first_shape.get_image() as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # 메모리에서 모양 비트맵을 생성합니다.
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # 두 번째 단락의 경계를 계산합니다.
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()

    # 출력 이미지의 좌표와 크기를 계산합니다 (최소 크기 - 1x1 픽셀).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # 모양 비트맵을 잘라서 단락 비트맵만 얻습니다.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

결과:

![단락 이미지](paragraph_to_image_output.png)

**예제 2**

이 예제에서는 이전 접근 방식에 단락 이미지에 스케일링 팩터를 추가하여 확장합니다. 도형을 프레젠테이션에서 추출하고 스케일 팩터 `2`로 이미지를 저장합니다. 이렇게 하면 단락을 내보낼 때 더 높은 해상도의 출력이 가능합니다. 그런 다음 스케일을 고려하여 단락 경계를 계산합니다. 스케일링은 예를 들어 고품질 인쇄물에 사용되는 보다 자세한 이미지가 필요할 때 특히 유용합니다.

```py
import aspose.slides as slides
import math
import io
from PIL import Image

image_scale_x = 2
image_scale_y = image_scale_x

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # 모양을 메모리에 비트맵으로 저장합니다.
    with first_shape.get_image(slides.ShapeThumbnailBounds.SHAPE, image_scale_x, image_scale_y) as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # 메모리에서 모양 비트맵을 생성합니다.
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # 두 번째 단락의 경계를 계산합니다.
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()
    paragraph_rectangle.x *= image_scale_x
    paragraph_rectangle.y *= image_scale_y
    paragraph_rectangle.width *= image_scale_x
    paragraph_rectangle.height *= image_scale_y

    # 출력 이미지의 좌표와 크기를 계산합니다 (최소 크기 - 1x1 픽셀).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # 모양 비트맵을 잘라서 단락 비트맵만 얻습니다.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

## **FAQ**

**텍스트 프레임 내부에서 줄 바꿈을 완전히 비활성화할 수 있나요?**

예. 텍스트 프레임의 줄 바꿈 설정([wrap_text](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframeformat/wrap_text/))을 사용해 줄 바꿈을 끄면 프레임 가장자리에서 줄이 끊기지 않습니다.

**특정 단락의 슬라이드 내 정확한 경계를 어떻게 얻을 수 있나요?**

단락(및 단일 Portion)의 경계 사각형을 가져와 슬라이드에서 정확한 위치와 크기를 알 수 있습니다.

**단락 정렬(좌/우/가운데/양쪽 맞춤)은 어디에서 제어됩니까?**

[Alignment](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraphformat/alignment/)은 [ParagraphFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides/paragraphformat/)의 단락 수준 설정이며, 개별 Portion 서식과 무관하게 전체 단락에 적용됩니다.

**단락의 일부분(예: 한 단어)만 맞춤법 검사 언어를 설정할 수 있나요?**

예. 언어는 Portion 수준([PortionFormat.language_id](https://reference.aspose.com/slides/ko/python-net/aspose.slides/portionformat/language_id/))에서 설정되므로 하나의 단락 내에 여러 언어를 동시에 사용할 수 있습니다.