---
title: Python via Java에서 PowerPoint 텍스트 단락 관리
linktitle: 단락 관리
type: docs
weight: 40
url: /ko/python-java/manage-paragraph/
aliases:
  - /python-java/paragraph/
  - /python-java/portion/
keywords:
- 텍스트 추가
- 단락 추가
- 텍스트 관리
- 단락 관리
- 글머리 기호 관리
- 단락 들여쓰기
- 행걸이 들여쓰기
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 단락, 구역, 글머리 기호, 번호 매기기 목록, 들여쓰기, HTML 콘텐츠 및 단락 이미지를 생성하고 서식 지정하는 방법을 배웁니다."
---
## **개요**

Aspose.Slides for Python via Java는 텍스트를 텍스트 프레임, 단락 및 구역의 계층 구조로 나타냅니다:

* [TextFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframe/)은 도형 내 텍스트 컨테이너이며, 해당 단락 컬렉션에 대한 액세스를 제공합니다.
* [Paragraph](https://reference.aspose.com/slides/ko/python-java/aspose.slides/paragraph/)은 텍스트 프레임 내의 하나의 단락을 나타내며, 구역 및 단락 수준 서식에 대한 액세스를 제공합니다.
* [Portion](https://reference.aspose.com/slides/ko/python-java/aspose.slides/portion/)은 단락 내 텍스트 실행을 나타냅니다. 각 구역은 자체 텍스트와 문자 수준 서식을 가질 수 있습니다.

따라서 단락은 여러 구역을 사용하여 서로 다른 글꼴, 색상, 크기 및 기타 서식의 텍스트를 포함할 수 있습니다.

## **단락 만들기 및 서식 지정**

### **여러 구역을 사용한 단락 만들기**

다음 단계는 각각 세 개의 구역을 포함하는 세 개의 단락을 가진 텍스트 프레임을 생성합니다:

1. Presentation 클래스의 인스턴스를 생성합니다.
2. 인덱스를 사용하여 해당 슬라이드에 접근합니다.
3. 슬라이드에 사각형 AutoShape을 추가합니다.
4. 도형의 TextFrame에 접근합니다.
5. 기본 단락을 사용하고 텍스트 프레임에 두 개의 Paragraph 객체를 추가합니다.
6. 각 단락에 세 개의 구역을 포함하도록 충분한 Portion 객체를 추가합니다. 기본 단락에는 이미 하나의 빈 구역이 들어 있습니다.
7. 각 구역의 텍스트를 설정합니다.
8. Portion.getPortionFormat을 통해 문자 수준 서식을 적용합니다.
9. 수정된 프레젠테이션을 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150)
    text_frame = shape.getTextFrame()
    first_paragraph = text_frame.getParagraphs().get_Item(0)
    first_paragraph.getPortions().add(Portion())
    first_paragraph.getPortions().add(Portion())
    second_paragraph = Paragraph()
    second_paragraph.getPortions().add(Portion())
    second_paragraph.getPortions().add(Portion())
    second_paragraph.getPortions().add(Portion())
    text_frame.getParagraphs().add(second_paragraph)
    third_paragraph = Paragraph()
    third_paragraph.getPortions().add(Portion())
    third_paragraph.getPortions().add(Portion())
    third_paragraph.getPortions().add(Portion())
    text_frame.getParagraphs().add(third_paragraph)
    paragraph_count = text_frame.getParagraphs().getCount()
    for paragraph_index in range(paragraph_count):
        paragraph = text_frame.getParagraphs().get_Item(paragraph_index)
        portion_count = paragraph.getPortions().getCount()
        for portion_index in range(portion_count):
            portion = paragraph.getPortions().get_Item(portion_index)
            portion.setText(f"Portion {paragraph_index + 1}.{portion_index + 1}")
            if portion_index == 0:
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)
                portion.getPortionFormat().setFontBold(NullableBool.True_)
                portion.getPortionFormat().setFontHeight(15)
            elif portion_index == 1:
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
                portion.getPortionFormat().setFontItalic(NullableBool.True_)
                portion.getPortionFormat().setFontHeight(18)
    presentation.save("paragraphs_with_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **글머리 기호 및 번호 매기기 목록 만들기**

### **글머리 기호 또는 번호 매기기 목록 만들기**

글머리 기호와 번호 매기기는 관련 항목을 더 쉽게 스캔할 수 있게 합니다. Aspose.Slides에서는 목록 설정을 BulletFormat을 통해 정의합니다.

1. Presentation 클래스의 인스턴스를 생성합니다.
2. 인덱스를 사용하여 해당 슬라이드에 접근합니다.
3. 선택된 슬라이드에 AutoShape을 추가합니다.
4. 도형의 TextFrame에 접근합니다.
5. 텍스트 프레임에서 기본 단락을 제거합니다.
6. 기호 글머리 기호용 Paragraph를 생성합니다.
7. BulletFormat.setType을 BulletType.Symbol으로 설정하고 글머리 기호 문자를 지정합니다.
8. 단락 텍스트, 들여쓰기, 글머리 기호 색상 및 글머리 기호 높이를 설정합니다.
9. 단락을 텍스트 프레임에 추가합니다.
10. 두 번째 단락을 생성하고 BulletFormat.setType을 BulletType.Numbered로 설정합니다.
11. 번호 매기기 글머리 기호 스타일을 구성하고 단락을 텍스트 프레임에 추가합니다.
12. 프레젠테이션을 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, ColorType, NullableBool, NumberedBulletStyle, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    symbol_paragraph = Paragraph()
    symbol_paragraph.setText("Welcome to Aspose.Slides")
    symbol_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    symbol_paragraph.getParagraphFormat().getBullet().setChar("•")
    symbol_paragraph.getParagraphFormat().setIndent(25)
    symbol_paragraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB)
    symbol_paragraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK)
    symbol_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    symbol_paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(symbol_paragraph)
    numbered_paragraph = Paragraph()
    numbered_paragraph.setText("This is a numbered item")
    numbered_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    numbered_paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain)
    numbered_paragraph.getParagraphFormat().setIndent(25)
    numbered_paragraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB)
    numbered_paragraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK)
    numbered_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    numbered_paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(numbered_paragraph)
    presentation.save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **그림 글머리 기호 사용**

그림 글머리 기호를 사용하면 기호나 숫자 대신 사용자 정의 이미지를 사용할 수 있습니다.

1. Presentation 클래스의 인스턴스를 생성합니다.
2. 인덱스를 사용하여 해당 슬라이드에 접근합니다.
3. AutoShape을 추가하고 해당 TextFrame에 접근합니다.
4. 텍스트 프레임에서 기본 단락을 제거합니다.
5. 글머리 기호 이미지를 로드하고 프레젠테이션의 이미지 컬렉션에 PPImage로 추가합니다.
6. Paragraph를 생성하고 텍스트를 설정합니다.
7. BulletFormat.setType을 BulletType.Picture으로 설정합니다.
8. BulletFormat.getPicture를 통해 이미지를 할당하고 글머리 기호 높이를 설정합니다.
9. 단락을 텍스트 프레임에 추가합니다.
10. 수정된 프레젠테이션을 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Images, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    bullet_image = Images.fromFile("bullets.png")
    try:
        presentation_image = presentation.getImages().addImage(bullet_image)
    finally:
        bullet_image.dispose()
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    paragraph = Paragraph()
    paragraph.setText("Welcome to Aspose.Slides")
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentation_image)
    paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(paragraph)
    presentation.save("picture_bullet.pptx", SaveFormat.Pptx)
    presentation.save("picture_bullet.ppt", SaveFormat.Ppt)
finally:
    presentation.dispose()
```

### **다단계 목록 만들기**

ParagraphFormat.setDepth를 설정하여 목록의 서로 다른 수준에 단락을 배치합니다. 최상위 수준은 깊이가 `0`입니다.

1. Presentation을 생성하고 슬라이드에 접근합니다.
2. AutoShape을 추가하고 해당 텍스트 프레임에서 기본 단락을 제거합니다.
3. 네 개의 단락을 만들고 글머리 기호 기호를 구성합니다.
4. 각각의 ParagraphFormat.setDepth 값을 `0`, `1`, `2`, `3`으로 설정합니다.
5. 단락을 텍스트 프레임에 추가하고 프레젠테이션을 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, FillType, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("Content")
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    first_paragraph.getParagraphFormat().getBullet().setChar("•")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setDepth(0)
    second_paragraph = Paragraph()
    second_paragraph.setText("Second level")
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    second_paragraph.getParagraphFormat().getBullet().setChar('-')
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setDepth(1)
    third_paragraph = Paragraph()
    third_paragraph.setText("Third level")
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    third_paragraph.getParagraphFormat().getBullet().setChar("•")
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    third_paragraph.getParagraphFormat().setDepth(2)
    fourth_paragraph = Paragraph()
    fourth_paragraph.setText("Fourth level")
    fourth_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    fourth_paragraph.getParagraphFormat().getBullet().setChar('-')
    fourth_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    fourth_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    fourth_paragraph.getParagraphFormat().setDepth(3)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    text_frame.getParagraphs().add(third_paragraph)
    text_frame.getParagraphs().add(fourth_paragraph)
    presentation.save("multilevel_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **번호 매기기 목록 항목을 사용자 정의 값으로 시작하기**

BulletFormat.setNumberedBulletStartWith을 사용하여 번호 매기기 단락의 초기 번호를 지정합니다.

1. Presentation을 생성하고 슬라이드에 AutoShape을 추가합니다.
2. 도형의 텍스트 프레임에서 기본 단락을 제거합니다.
3. 세 개의 번호 매기기 단락을 생성합니다.
4. 각각의 단락에 대해 BulletFormat.setNumberedBulletStartWith을 `2`, `3`, `7`로 설정합니다.
5. 단락을 텍스트 프레임에 추가하고 프레젠테이션을 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("Start at 2")
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    first_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(2)
    text_frame.getParagraphs().add(first_paragraph)
    second_paragraph = Paragraph()
    second_paragraph.setText("Start at 3")
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    second_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(3)
    text_frame.getParagraphs().add(second_paragraph)
    third_paragraph = Paragraph()
    third_paragraph.setText("Start at 7")
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    third_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(7)
    text_frame.getParagraphs().add(third_paragraph)
    presentation.save("custom_numbered_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **단락 레이아웃 및 끝 속성 제어**

### **첫 줄 들여쓰기 설정**

ParagraphFormat.setIndent를 사용하여 단락의 첫 줄 들여쓰기를 제어합니다. 이 메서드는 첫 줄만 단락 왼쪽 여백에 대해 이동시킵니다. 양수 값은 첫 줄을 오른쪽으로 이동시키고, 나머지 줄은 단락 본문에 맞춥니다.

전체 단락을 이동하려면 ParagraphFormat.setMarginLeft를 사용하고, 첫 줄만 이동하려면 ParagraphFormat.setIndent를 사용합니다.

아래 예제는 여러 단락을 만들고 서로 다른 ParagraphFormat.setIndent 값을 적용하여 첫 줄 들여쓰기가 단락 레이아웃에 미치는 영향을 보여줍니다.

1. Presentation 클래스의 인스턴스를 생성합니다.
2. 대상 슬라이드에 접근합니다.
3. 슬라이드에 사각형 AutoShape을 추가합니다.
4. 도형의 TextFrame에 접근하고 기본 단락을 제거합니다.
5. 여러 단락을 만들고 각각 다른 ParagraphFormat.setIndent 값을 설정합니다.
6. 단락을 텍스트 프레임에 추가합니다.
7. 수정된 프레젠테이션을 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Presentation, SaveFormat, ShapeType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape)
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setMarginLeft(20.0)
    first_paragraph.getParagraphFormat().setIndent(0.0)
    second_paragraph = Paragraph()
    second_paragraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setMarginLeft(20.0)
    second_paragraph.getParagraphFormat().setIndent(20.0)
    third_paragraph = Paragraph()
    third_paragraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.")
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    third_paragraph.getParagraphFormat().setMarginLeft(20.0)
    third_paragraph.getParagraphFormat().setIndent(40.0)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    text_frame.getParagraphs().add(third_paragraph)
    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

결과:

![단락들의 첫 줄 들여쓰기](first_line_indent.png)

### **행걸이 들여쓰기 설정**

행걸이 들여쓰기는 첫 줄이 나머지 줄보다 왼쪽에 시작되는 레이아웃입니다. Aspose.Slides에서는 ParagraphFormat.setIndent에 음수 값을 전달하여 이 효과를 구현합니다.

실제로 ParagraphFormat.setMarginLeft는 단락 본문의 왼쪽 위치를 정의하고, ParagraphFormat.setIndent는 그 여백에 대한 첫 줄 위치를 정의합니다. 행걸이 들여쓰기를 만들려면 ParagraphFormat.setMarginLeft에 양수 값을, ParagraphFormat.setIndent에 음수 값을 전달합니다.

이 서식은 참고문헌, 인용, 용어 설명 등 줄이 단락 본문 아래에 맞추어야 할 경우에 유용합니다.

1. Presentation 클래스의 인스턴스를 생성합니다.
2. 대상 슬라이드에 접근합니다.
3. 슬라이드에 사각형 AutoShape을 추가합니다.
4. 도형의 TextFrame에 접근하고 기본 단락을 제거합니다.
5. 각 단락에 대해 ParagraphFormat.setMarginLeft에 양수 값을 설정합니다.
6. ParagraphFormat.setIndent에 음수 값을 전달하여 행걸이 들여쓰기 효과를 만듭니다.
7. 단락을 텍스트 프레임에 추가합니다.
8. 수정된 프레젠테이션을 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Presentation, SaveFormat, ShapeType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape)
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setMarginLeft(40.0)
    first_paragraph.getParagraphFormat().setIndent(-20.0)
    second_paragraph = Paragraph()
    second_paragraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setMarginLeft(60.0)
    second_paragraph.getParagraphFormat().setIndent(-30.0)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    presentation.save("hanging_indent.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

결과:

![단락들의 행걸이 들여쓰기](hanging_indent.png)

### **끝 단락 실행 속성 설정**

Paragraph.setEndParagraphPortionFormat은 단락 끝 표시의 서식을 제어합니다. 다음 예제는 두 번째 단락 끝 표시에 폰트 크기와 라틴 폰트를 지정합니다:

1. Presentation을 로드하고 슬라이드에 접근합니다.
2. AutoShape을 추가하고 기본 단락을 제거합니다.
3. 두 개의 단락을 만들고 텍스트 구역을 추가합니다.
4. 두 번째 단락 끝 표시용 PortionFormat을 생성합니다.
5. BasePortionFormat.setFontHeight와 BasePortionFormat.setLatinFont를 설정합니다.
6. Paragraph.setEndParagraphPortionFormat으로 서식을 지정하고 프레젠테이션을 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Paragraph, Portion, PortionFormat, Presentation, SaveFormat, ShapeType

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_portion = Portion("Sample text")
    first_paragraph.getPortions().add(first_portion)
    second_paragraph = Paragraph()
    second_portion = Portion("Sample text 2")
    second_paragraph.getPortions().add(second_portion)
    end_paragraph_format = PortionFormat()
    end_paragraph_format.setFontHeight(48)
    latin_font = FontData("Times New Roman")
    end_paragraph_format.setLatinFont(latin_font)
    second_paragraph.setEndParagraphPortionFormat(end_paragraph_format)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    presentation.save("end_paragraph_format.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **단락 내용 가져오기 및 내보내기**

### **HTML 텍스트를 단락으로 가져오기**

ParagraphCollection.addFromHtml을 사용하면 HTML 마크업을 텍스트 프레임의 단락 및 구역으로 변환할 수 있습니다.

1. Presentation 클래스의 인스턴스를 생성합니다.
2. 슬라이드에 AutoShape을 추가합니다.
3. 도형의 TextFrame에 접근하고 기본 단락을 제거합니다.
4. 소스 HTML 파일을 읽습니다.
5. HTML 문자열을 ParagraphCollection.addFromHtml에 전달합니다.
6. 수정된 프레젠테이션을 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape_width = presentation.getSlideSize().getSize().getWidth() - 20
    shape_height = presentation.getSlideSize().getSize().getHeight() - 20
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, shape_width, shape_height)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().getParagraphs().clear()
    try:
        html = Path("file.html").read_text(encoding="utf-8")
        shape.getTextFrame().getParagraphs().addFromHtml(html)
        presentation.save("html_text.pptx", SaveFormat.Pptx)
    except OSError as exception:
        print("The HTML file could not be read: " + str(exception))
finally:
    presentation.dispose()
```

### **단락 텍스트를 HTML로 내보내기**

ParagraphCollection.exportToHtml을 사용하면 선택한 단락 범위를 HTML로 내보낼 수 있습니다.

1. Presentation을 인스턴스화하고 원하는 프레젠테이션을 로드합니다.
2. 슬라이드에 접근하고 텍스트를 포함하는 AutoShape을 찾습니다.
3. 도형의 TextFrame에 접근합니다.
4. 시작 단락 인덱스와 내보낼 단락 수를 지정하여 ParagraphCollection.exportToHtml을 호출합니다.
5. 반환된 HTML 문자열을 파일에 씁니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation
from pathlib import Path

presentation = Presentation("ExportingHTMLText.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, AutoShape):
        text_shape = shape
        text_frame = text_shape.getTextFrame()
        if text_frame is not None:
            paragraphs = text_frame.getParagraphs()
            html = paragraphs.exportToHtml(0, paragraphs.getCount(), None)
            try:
                Path("paragraphs.html").write_text(str(html), encoding="utf-8")
            except OSError as exception:
                print("The HTML file could not be written: " + str(exception))
        else:
            print("The first shape does not contain a text frame.")
    else:
        print("The first shape is not a text shape.")
finally:
    presentation.dispose()
```

### **단락을 이미지로 렌더링**

Paragraph.getImage는 개별 단락을 직접 렌더링하고 이미지 객체를 반환합니다. 반환된 이미지의 `save` 메서드로 파일이나 스트림에 저장할 수 있습니다. 포함된 도형을 렌더링하거나 비트맵을 수동으로 자를 필요가 없습니다.

Paragraph.getImage는 단락을 찾을 수 없거나 유효한 렌더링 경계가 없을 경우 `None`을 반환할 수 있습니다. 저장하기 전에 결과를 확인하고 사용 후에 반환된 이미지를 해제하십시오.

#### **기본 축척으로 단락 렌더링**

sample.pptx 파일에 슬라이드가 하나 있고, 첫 번째 도형은 세 개의 단락을 포함하는 텍스트 상자라고 가정합니다.

![세 개의 단락이 있는 텍스트 상자](paragraph_to_image_input.png)

다음 예제는 두 번째 단락을 기본 축척으로 렌더링하고 PNG 형식으로 저장합니다. `finally` 블록은 이미지가 올바르게 해제되도록 합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ImageFormat, Presentation

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, AutoShape):
        text_shape = shape
        text_frame = text_shape.getTextFrame()
        if text_frame is not None and text_frame.getParagraphs().getCount() > 1:
            paragraph = text_frame.getParagraphs().get_Item(1)
            paragraph_image = paragraph.getImage()
            if paragraph_image is not None:
                try:
                    paragraph_image.save("paragraph.png", ImageFormat.Png)
                finally:
                    paragraph_image.dispose()
            else:
                print("The paragraph could not be rendered.")
        else:
            print("The expected paragraph was not found.")
    else:
        print("The first shape is not a text shape.")
finally:
    presentation.dispose()
```

결과:

![단락 이미지](paragraph_to_image_output.png)

#### **테이블 셀에서 스케일링으로 단락 렌더링**

`scale_x`와 `scale_y` 매개변수를 받아 가로·세로 배율을 설정하는 Paragraph.getImage 오버로드를 사용합니다. 다음 예제는 테이블을 만든 뒤 첫 번째 셀에서 단락을 기본 너비·높이의 두 배로 렌더링하고 PNG 이미지로 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

scale_x = 2.0
scale_y = 2.0
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().addTable(50, 50, [300.0], [80.0])
    paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0)
    paragraph.setText("Text in a table cell")
    paragraph_image = paragraph.getImage(scale_x, scale_y)
    if paragraph_image is not None:
        try:
            paragraph_image.save("table_paragraph.png", ImageFormat.Png)
        finally:
            paragraph_image.dispose()
    else:
        print("The paragraph could not be rendered.")
finally:
    presentation.dispose()
```

배율 `1`은 해당 축을 기본 픽셀 크기로 유지합니다. 예를 들어 두 축에 `2`를 지정하면 너비와 높이가 대략 두 배가 되어 픽셀 수는 네 배가 됩니다. 큰 배율은 확대하거나 고해상도 출력 시 텍스트를 더 선명하게 만들지만 메모리 사용량과 파일 크기도 증가합니다. `1`보다 작은 배율은 세부 정보가 적은 작은 이미지를 생성합니다. 비율을 동일하게 유지하면 단락의 종횡비가 보존되고, 서로 다른 가로·세로 배율은 출력을 독립적으로 늘립니다.

전체 도형을 렌더링하려면 Shape.getImage를 사용합니다. 단락만 이미지로 만들 경우 Paragraph.getImage를 사용하십시오.

## **FAQ**

**텍스트 프레임 내에서 줄 바꿈을 완전히 비활성화할 수 있나요?**

네. TextFrameFormat.setWrapText를 설정하여 텍스트 프레임 가장자리에서 줄이 끊기지 않도록 래핑을 비활성화합니다.

**특정 단락의 슬라이드 상 정확한 경계 값을 어떻게 얻나요?**

Paragraph.getRect를 사용하면 단락의 경계 사각형을 가져올 수 있습니다. Portion.getRect는 개별 구역의 경계를 제공합니다.

**단락 정렬(왼쪽, 오른쪽, 가운데, 양쪽 정렬)은 어디에서 제어되나요?**

ParagraphFormat.setAlignment는 단락 수준 설정이며, 개별 구역 서식과 무관하게 전체 단락에 적용됩니다.

**단락의 일부에 교정 언어를 설정할 수 있나요?**

네. 개별 구역에 BasePortionFormat.setLanguageId를 설정하면 하나의 단락에 여러 언어 텍스트를 포함할 수 있습니다.