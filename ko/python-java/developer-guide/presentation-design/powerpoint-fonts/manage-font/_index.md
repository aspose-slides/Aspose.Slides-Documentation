---
title: Python via Java를 사용한 프레젠테이션 글꼴 관리
linktitle: 글꼴 관리
type: docs
weight: 10
url: /ko/python-java/manage-fonts/
keywords:
- 글꼴 관리
- 글꼴 속성
- 단락
- 텍스트 서식 지정
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides를 사용한 Python via Java에서 글꼴을 제어합니다: 임베드, 대체 및 사용자 정의 글꼴을 로드하여 PPT, PPTX 및 ODP 프레젠테이션을 명확하고 브랜드 안전하며 일관되게 유지합니다."
---
## **개요**

Aspose.Slides를 사용하면 코드에서 프레젠테이션 텍스트의 글꼴 속성을 직접 관리할 수 있습니다. 슬라이드의 텍스트에 도형, 텍스트 프레임, 단락 및 구간을 통해 접근한 후 선택한 텍스트에 서식을 적용할 수 있습니다.

이 문서에서는 글꼴 패밀리, 굵게 및 기울임 스타일, 단락 정렬, 글꼴 색상 등을 포함한 기존 프레젠테이션 텍스트의 글꼴 관련 속성을 구성하는 방법을 설명합니다. 또한 텍스트 상자를 생성하고 텍스트를 추가한 뒤, 글꼴 패밀리, 굵게, 기울임, 밑줄, 글꼴 크기 및 색상과 같은 글꼴 속성을 설정하고 결과를 PPTX 파일로 저장하는 방법을 보여줍니다.

## **글꼴 관련 속성 관리**
{{% alert color="info" title="참고" %}} 

프레젠테이션에는 일반적으로 텍스트와 이미지가 모두 포함됩니다. 텍스트는 특정 섹션이나 단어를 강조하거나 기업 스타일에 맞추기 위해 다양한 방식으로 서식이 지정될 수 있습니다. 텍스트 서식 지정은 사용자가 프레젠테이션 내용의 모양과 느낌을 다양화하는 데 도움이 됩니다. 이 문서에서는 Aspose.Slides for Python via Java를 사용하여 슬라이드의 텍스트 단락에 대한 글꼴 속성을 구성하는 방법을 보여줍니다.

{{% /alert %}} 

단락의 글꼴 속성을 관리하려면 Aspose.Slides for Python via Java를 사용하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 사용하여 슬라이드의 레퍼런스를 가져옵니다.
3. 슬라이드에서 [Placeholder](https://reference.aspose.com/slides/ko/python-java/aspose.slides/placeholder/) 도형에 [AutoShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/autoshape/) 형태로 접근합니다.
4. [AutoShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/autoshape/)가 노출하는 [TextFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframe/)에서 [Paragraph](https://reference.aspose.com/slides/ko/python-java/aspose.slides/paragraph/)를 가져옵니다.
5. 단락을 양쪽 맞춤합니다.
6. [Paragraph](https://reference.aspose.com/slides/ko/python-java/aspose.slides/paragraph/)의 텍스트 [Portion](https://reference.aspose.com/slides/ko/python-java/aspose.slides/portion/)에 접근합니다.
7. [FontData](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fontdata/)를 사용하여 글꼴을 정의하고 텍스트 [Portion](https://reference.aspose.com/slides/ko/python-java/aspose.slides/portion/)의 **Font**를 설정합니다.
   1. 글꼴을 굵게 설정합니다.
   1. 글꼴을 기울임으로 설정합니다.
8. [Portion](https://reference.aspose.com/slides/ko/python-java/aspose.slides/portion/) 객체가 노출하는 [FillFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/fillformat/)을 사용하여 글꼴 색상을 설정합니다.
9. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

위 단계의 구현 예제가 아래에 나와 있습니다. 이 예제는 꾸밈없는 프레젠테이션을 가져와 하나의 슬라이드에 대한 글꼴을 포맷합니다. 다음 스크린샷은 입력 파일과 코드 스니펫이 적용된 결과를 보여줍니다. 코드는 글꼴, 색상 및 글꼴 스타일을 변경합니다.

|![Text in the input presentation](https://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**그림: 입력 파일의 텍스트**|

|![Text with updated font formatting](https://i.imgur.com/rY27Lt9.png)|
| :- |
|**그림: 동일한 텍스트에 업데이트된 서식 적용**|

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, TextAlignment
from java.awt import Color

# 프레젠테이션을 로드합니다.
presentation = Presentation("FontProperties.pptx")
try:
    # 첫 번째 슬라이드와 첫 두 개 자리표시자의 텍스트 프레임에 접근합니다.
    slide = presentation.getSlides().get_Item(0)
    title_text_frame = slide.getShapes().get_Item(0).getTextFrame()
    body_text_frame = slide.getShapes().get_Item(1).getTextFrame()

    # 각 텍스트 프레임의 첫 번째 단락에 접근합니다.
    title_paragraph = title_text_frame.getParagraphs().get_Item(0)
    body_paragraph = body_text_frame.getParagraphs().get_Item(0)
    body_paragraph.getParagraphFormat().setAlignment(TextAlignment.JustifyLow)

    # 각 단락의 첫 번째 구간에 접근합니다.
    title_portion = title_paragraph.getPortions().get_Item(0)
    body_portion = body_paragraph.getPortions().get_Item(0)

    # 새 글꼴을 정의하고 할당합니다.
    title_font = FontData("Elephant")
    body_font = FontData("Castellar")
    title_portion.getPortionFormat().setLatinFont(title_font)
    body_portion.getPortionFormat().setLatinFont(body_font)

    # 글꼴을 굵게와 기울임으로 설정합니다.
    title_portion.getPortionFormat().setFontBold(NullableBool.True_)
    body_portion.getPortionFormat().setFontBold(NullableBool.True_)
    title_portion.getPortionFormat().setFontItalic(NullableBool.True_)
    body_portion.getPortionFormat().setFontItalic(NullableBool.True_)

    # 글꼴 색상을 설정합니다.
    title_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    title_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    body_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    body_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN)

    # 프레젠테이션을 저장합니다.
    presentation.save("WelcomeFont.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **텍스트 글꼴 속성 설정**
{{% alert color="info" title="참고" %}} 

**글꼴 관련 속성 관리**에서 언급했듯이, [Portion](https://reference.aspose.com/slides/ko/python-java/aspose.slides/portion/)은 단락 내에서 비슷한 서식 스타일을 가진 텍스트를 보관하는 데 사용됩니다. 이 문서에서는 Aspose.Slides for Python via Java를 사용하여 텍스트 상자를 만들고 텍스트를 추가한 뒤 특정 글꼴 및 다양한 글꼴 속성을 정의하는 방법을 보여줍니다.

{{% /alert %}} 

텍스트 상자를 만들고 해당 텍스트의 글꼴 속성을 설정하려면:

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 사용하여 슬라이드의 레퍼런스를 가져옵니다.
3. 슬라이드에 **Rectangle** 유형의 [AutoShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/autoshape/)을 추가합니다.
4. [AutoShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/autoshape/)에 연결된 채우기 스타일을 제거합니다.
5. [AutoShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/autoshape/)의 [TextFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframe/)에 접근합니다.
6. [TextFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframe/)에 텍스트를 추가합니다.
7. [TextFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframe/)와 연결된 [Portion](https://reference.aspose.com/slides/ko/python-java/aspose.slides/portion/) 객체에 접근합니다.
8. [Portion](https://reference.aspose.com/slides/ko/python-java/aspose.slides/portion/)에 사용할 글꼴을 정의합니다.
9. [Portion](https://reference.aspose.com/slides/ko/python-java/aspose.slides/portion/) 객체가 노출하는 관련 속성을 사용하여 굵게, 기울임, 밑줄, 색상 및 높이와 같은 기타 글꼴 속성을 설정합니다.
10. 수정된 프레젠테이션을 PPTX 파일로 씁니다.

위 단계의 구현 예제가 아래에 나와 있습니다.

|![Text with font properties applied](https://i.imgur.com/n5r12dS.jpg)|
| :- |
|**그림: Aspose.Slides for Python via Java가 설정한 일부 글꼴 속성 적용 텍스트**|

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextUnderlineType
from java.awt import Color

presentation = Presentation()
try:
    # 첫 번째 슬라이드를 가져오고 직사각형을 추가합니다.
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50)

    # 도형 채우기를 제거합니다.
    shape.getFillFormat().setFillType(FillType.NoFill)

    # 도형의 텍스트 프레임에 텍스트를 추가합니다.
    text_frame = shape.getTextFrame()
    text_frame.setText("Aspose TextBox")
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)

    # 글꼴 패밀리를 설정합니다.
    font = FontData("Times New Roman")
    portion.getPortionFormat().setLatinFont(font)

    # 굵게, 기울임, 밑줄 및 글꼴 크기를 설정합니다.
    portion.getPortionFormat().setFontBold(NullableBool.True_)
    portion.getPortionFormat().setFontItalic(NullableBool.True_)
    portion.getPortionFormat().setFontUnderline(TextUnderlineType.Single)
    portion.getPortionFormat().setFontHeight(25)

    # 글꼴 색상을 설정합니다.
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # 프레젠테이션을 저장합니다.
    presentation.save("pptxFont.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```