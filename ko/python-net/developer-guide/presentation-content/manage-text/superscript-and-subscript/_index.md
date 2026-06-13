---
title: Python에서 위첨자 및 아래첨자 관리
linktitle: 위첨자 및 아래첨자
type: docs
weight: 80
url: /ko/python-net/superscript-and-subscript/
keywords:
- 위첨자
- 아래첨자
- 위첨자 추가
- 아래첨자 추가
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python을 .NET을 통해 마스터하고, 전문적인 텍스트 서식으로 프레젠테이션을 한층 강화하여 최대 효과를 얻으세요."
---
## **개요**

Aspose.Slides는 PowerPoint(PPT, PPTX) 및 OpenDocument(ODP) 프레젠테이션에 위 첨자와 아래 첨자 텍스트를 통합하는 기능을 제공합니다. 화학식, 수학 방정식을 강조하거나 각주로 내용을 표시해야 할 경우, 이러한 특수 서식 옵션은 명확성과 정확성을 유지하는 데 도움이 됩니다. 이 문서에서는 위 첨자와 아래 첨자 스타일을 손쉽게 적용하고 모든 슬라이드에서 전문가 수준의 결과를 보장하는 방법을 배웁니다.

## **위 첨자 및 아래 첨자 텍스트 추가**

어떤 단락 부분에도 위 첨자와 아래 첨자 텍스트를 추가할 수 있습니다. Aspose.Slides에서는 이 제어를 위해 [PortionFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides/portionformat/) 클래스의 `escapement` 속성을 사용합니다.

`escapement`는 **-100%부터 100%**까지의 백분율입니다:

- **> 0** → 위 첨자 (예: 25% = 약간 상승; 100% = 완전 위 첨자)
- **0** → 기준선 (위/아래 첨자 없음)
- **< 0** → 아래 첨자 (예: -25% = 약간 하강; -100% = 완전 아래 첨자)

단계:

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/)을 생성하고 슬라이드를 가져옵니다.
2. 직사각형 [AutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/autoshape/)을 추가하고 해당 [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/)에 접근합니다.
3. 기존 단락을 지웁니다.
4. 위 첨자를 위해: 단락과 부분을 생성하고 `portion.portion_format.escapement`를 **0에서 100** 사이의 값으로 설정하고 텍스트를 지정한 뒤 부분을 추가합니다.
5. 아래 첨자를 위해: 다른 단락과 부분을 생성하고 `escapement`를 **-100에서 0** 사이의 값으로 설정하고 텍스트를 지정한 뒤 부분을 추가합니다.
6. 프레젠테이션을 PPTX 형식으로 저장합니다.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    # 슬라이드를 가져옵니다.
    slide = presentation.slides[0]

    # 텍스트 상자를 만듭니다.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    shape.text_frame.paragraphs.clear()

    # 위첨자 텍스트용 단락을 생성합니다.
    superscript_paragraph = slides.Paragraph()

    # 일반 텍스트가 포함된 텍스트 부분을 생성합니다.
    portion1 = slides.Portion()
    portion1.text = "SlideTitle"
    superscript_paragraph.portions.add(portion1)

    # 위첨자 텍스트가 포함된 텍스트 부분을 생성합니다.
    superscript_portion = slides.Portion()
    superscript_portion.portion_format.escapement = 30
    superscript_portion.text = "TM"
    superscript_paragraph.portions.add(superscript_portion)

    # 아래첨자 텍스트용 단락을 생성합니다.
    subscript_paragraph = slides.Paragraph()

    # 일반 텍스트가 포함된 텍스트 부분을 생성합니다.
    portion2 = slides.Portion()
    portion2.text = "a"
    subscript_paragraph.portions.add(portion2)

    # 아래첨자 텍스트가 포함된 텍스트 부분을 생성합니다.
    subscript_portion = slides.Portion()
    subscript_portion.portion_format.escapement = -25
    subscript_portion.text = "i"
    subscript_paragraph.portions.add(subscript_portion)

    # 텍스트 상자에 단락을 추가합니다.
    shape.text_frame.paragraphs.add(superscript_paragraph)
    shape.text_frame.paragraphs.add(subscript_paragraph)

    presentation.save("TestOut.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**표 및 기타 컨테이너에서도 일반 텍스트 상자뿐 아니라 위 첨자/아래 첨자를 적용할 수 있나요?**  
예. [TextFrame]을 노출하는 모든 객체(표 셀 포함) 안에서 텍스트를 위 첨자 또는 아래 첨자 형태로 지정할 수 있습니다. 서식은 해당 프레임 내 텍스트 부분에 적용됩니다.

**PDF, HTML 또는 이미지로 내보낼 때 위 첨자/아래 첨자가 유지됩니까?**  
예. Aspose.Slides는 렌더링 파이프라인이 텍스트 부분 수준의 서식을 존중하기 때문에 [PDF](/slides/ko/python-net/convert-powerpoint-to-pdf/), [HTML](/slides/ko/python-net/convert-powerpoint-to-html/), [raster images](/slides/ko/python-net/convert-powerpoint-to-png/)와 같은 일반 형식으로 내보낼 때 위 첨자/아래 첨자 서식을 보존합니다.

**같은 텍스트 조각에서 위 첨자/아래 첨자와 하이퍼링크를 함께 사용할 수 있나요?**  
예. [Hyperlinks](/slides/ko/python-net/manage-hyperlinks/)은 부분(조각) 수준에서 할당되므로, 하나의 부분이 동시에 하이퍼링크와 위 첨자 또는 아래 첨자 서식을 가질 수 있습니다.