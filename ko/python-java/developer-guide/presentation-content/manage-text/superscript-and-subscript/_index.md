---
title: Python을 통한 Java에서 프레젠테이션의 위첨자와 아래첨자 관리
linktitle: 위첨자와 아래첨자
type: docs
weight: 80
url: /ko/python-java/superscript-and-subscript/
keywords:
- 위첨자
- 아래첨자
- 위첨자 추가
- 아래첨자 추가
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Python을 통한 Java에서 Aspose.Slides의 위첨자와 아래첨자를 마스터하고 전문적인 텍스트 서식으로 프레젠테이션을 향상시켜 최대 효과를 얻으세요."
---
## **개요**

Aspose.Slides는 PowerPoint(PPT, PPTX) 및 OpenDocument(ODP) 프레젠테이션에 위첨자와 아래첨자 텍스트를 삽입하는 기능을 제공합니다. 화학식, 수학 방정식을 강조하거나 각주로 내용을 주석 달아야 할 때, 이러한 특수 서식 옵션을 사용하면 명확성과 정확성을 유지할 수 있습니다. 이 문서에서는 위첨자와 아래첨자 스타일을 손쉽게 적용하고 모든 슬라이드에서 전문가 수준의 결과를 얻는 방법을 배웁니다.

## **위첨자 및 아래첨자 텍스트 관리**

단락의 任意 부분에 위첨자와 아래첨자 텍스트를 추가할 수 있습니다. Aspose.Slides 텍스트 프레임에서 이 서식을 적용하려면 [PortionFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/portionformat/) 클래스의 [setEscapement](https://reference.aspose.com/slides/ko/python-java/aspose.slides/portionformat/#setEscapement) 메서드를 사용하십시오.

escapement 값은 -100%(아래첨자)에서 100%(위첨자)까지 범위가 있습니다. 예를 들어:

- [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
- 인덱스로 슬라이드를 가져옵니다.
- 슬라이드에 [ShapeType.Rectangle](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapetype/#Rectangle) 유형의 [AutoShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/autoshape/)을 추가합니다.
- 해당 [AutoShape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/autoshape/)와 연결된 [TextFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframe/)에 접근합니다.
- 기존 단락을 모두 삭제합니다.
- 위첨자 텍스트를 보관할 단락을 만들고 텍스트 프레임의 [paragraph collection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframe/#getParagraphs)에 추가합니다.
- Portion을 생성합니다.
- 위첨자를 위해 0에서 100 사이의 값을 설정하려면 [setEscapement](https://reference.aspose.com/slides/ko/python-java/aspose.slides/portionformat/#setEscapement)를 사용합니다(0은 위첨자 없음).
- [Portion](https://reference.aspose.com/slides/ko/python-java/aspose.slides/portion/)의 텍스트를 설정하고 단락의 portion collection에 추가합니다.
- 아래첨자 텍스트를 보관할 단락을 만들고 텍스트 프레임의 [paragraph collection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframe/#getParagraphs)에 추가합니다.
- Portion을 생성합니다.
- 아래첨자를 위해 -100에서 0 사이의 값을 설정하려면 [setEscapement](https://reference.aspose.com/slides/ko/python-java/aspose.slides/portionformat/#setEscapement)를 사용합니다(0은 아래첨자 없음).
- [Portion](https://reference.aspose.com/slides/ko/python-java/aspose.slides/portion/)의 텍스트를 설정하고 단락의 portion collection에 추가합니다.
- 프레젠테이션을 PPTX 파일로 저장합니다.

다음 예제는 이러한 단계를 구현합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Paragraph, Portion, Presentation, SaveFormat, ShapeType

# 프레젠테이션을 생성합니다.
presentation = Presentation()
try:
    # 슬라이드를 가져옵니다.
    slide = presentation.getSlides().get_Item(0)

    # 텍스트 상자를 생성합니다.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    # 위첨자 텍스트용 단락을 생성합니다.
    superscript_paragraph = Paragraph()

    # 일반 텍스트가 포함된 Portion을 생성합니다.
    title_portion = Portion()
    title_portion.setText("SlideTitle")
    superscript_paragraph.getPortions().add(title_portion)

    # 위첨자 텍스트가 포함된 Portion을 생성합니다.
    superscript_portion = Portion()
    superscript_portion.getPortionFormat().setEscapement(30)
    superscript_portion.setText("TM")
    superscript_paragraph.getPortions().add(superscript_portion)

    # 아래첨자 텍스트용 단락을 생성합니다.
    subscript_paragraph = Paragraph()

    # 일반 텍스트가 포함된 Portion을 생성합니다.
    base_portion = Portion()
    base_portion.setText("a")
    subscript_paragraph.getPortions().add(base_portion)

    # 아래첨자 텍스트가 포함된 Portion을 생성합니다.
    subscript_portion = Portion()
    subscript_portion.getPortionFormat().setEscapement(-25)
    subscript_portion.setText("i")
    subscript_paragraph.getPortions().add(subscript_portion)

    # 텍스트 상자에 단락을 추가합니다.
    text_frame.getParagraphs().add(superscript_paragraph)
    text_frame.getParagraphs().add(subscript_paragraph)

    presentation.save("formatText.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**PDF 또는 기타 형식으로 내보낼 때 위첨자와 아래첨자가 유지되나요?**

네, Aspose.Slides는 프레젠테이션을 PDF, PPT/PPTX, 이미지 및 기타 지원되는 형식으로 내보낼 때 위첨자와 아래첨자 서식을 올바르게 유지합니다. 특수 서식이 모든 출력 파일에 그대로 보존됩니다.

**위첨자와 아래첨자를 굵게, 기울임꼴 등 다른 서식과 함께 사용할 수 있나요?**

네, Aspose.Slides는 단일 Portion 내에서 다양한 텍스트 스타일을 혼합할 수 있습니다. 굵게, 기울임꼴, 밑줄을 적용하면서 동시에 [PortionFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/portionformat/)의 해당 속성을 설정하여 위첨자 또는 아래첨자를 적용할 수 있습니다.

**표, 차트 또는 SmartArt 내부 텍스트에도 위첨자와 아래첨자를 적용할 수 있나요?**

네, Aspose.Slides는 표와 차트 요소를 포함한 대부분의 개체 내 서식을 지원합니다. SmartArt를 사용할 경우 해당 요소(예: [SmartArtNode](https://reference.aspose.com/slides/ko/python-java/aspose.slides/smartartnode/))와 텍스트 컨테이너에 접근한 뒤, [PortionFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/portionformat/) 속성을 유사하게 설정하면 됩니다.