---
title: Python을 사용한 프레젠테이션 현지화 자동화
linktitle: 프레젠테이션 현지화
type: docs
weight: 100
url: /ko/python-net/presentation-localization/
keywords:
- 언어 변경
- 맞춤법 검사
- 언어 ID
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Python과 Aspose.Slides를 사용하여 PowerPoint 및 OpenDocument 슬라이드 현지화를 자동화하고, 실용적인 코드 샘플과 빠른 글로벌 배포를 위한 팁을 제공합니다."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 프레젠테이션의 텍스트에 `language_id`를 설정하는 방법을 설명합니다. 프레젠테이션을 열고, 텍스트가 있는 도형을 추가하고, 텍스트 부분에 언어 식별자를 지정한 다음, 결과를 PPTX 파일로 저장하는 과정을 보여줍니다.

## **프레젠테이션 및 도형 텍스트의 언어 변경**
- [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
- 슬라이드의 인덱스를 사용하여 해당 슬라이드의 참조를 가져옵니다.
- 슬라이드에 사각형 유형의 AutoShape를 추가합니다.
- TextFrame에 텍스트를 추가합니다.
- 텍스트에 Language Id를 설정합니다.
- 프레젠테이션을 PPTX 파일로 저장합니다.

위 단계들의 구현 예제가 아래 예시로 보여집니다.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)
    shape.add_text_frame("Text to apply spellcheck language")
    shape.text_frame.paragraphs[0].portions[0].portion_format.language_id = "en-EN"

    pres.save("test1.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**언어 ID가 자동 텍스트 번역을 트리거합니까?**

아니요. [language_id](https://reference.aspose.com/slides/ko/python-net/aspose.slides/portionformat/language_id/) 은 Aspose.Slides에서 맞춤법 검사 및 문법 교정을 위해 언어를 저장하지만 텍스트 내용을 번역하거나 변경하지 않습니다. 이는 PowerPoint이 교정을 위해 이해하는 메타데이터입니다.

**언어 ID가 렌더링 시 하이픈 삽입 및 줄 바꿈에 영향을 줍니까?**

Aspose.Slides에서 [language_id](https://reference.aspose.com/slides/ko/python-net/aspose.slides/portionformat/language_id/) 는 교정을 위한 것입니다. 하이픈 삽입 품질과 줄 바꿈은 주로 적절한 글꼴의 가용성과 해당 쓰기 시스템의 레이아웃/줄 바꿈 설정에 따라 달라집니다. 올바른 렌더링을 보장하려면 필요한 글꼴을 사용 가능하게 하고, [font substitution rules](/slides/ko/python-net/font-substitution/) 를 구성하거나, 프레젠테이션에 [embed fonts](/slides/ko/python-net/embedded-font/) 를 포함하십시오.

**단일 문단 내에서 다른 언어를 설정할 수 있나요?**

예. [language_id](https://reference.aspose.com/slides/ko/python-net/aspose.slides/portionformat/language_id/) 는 텍스트 부분 수준에서 적용되므로, 단일 문단에서도 서로 다른 언어와 개별 교정 설정을 섞어 사용할 수 있습니다.