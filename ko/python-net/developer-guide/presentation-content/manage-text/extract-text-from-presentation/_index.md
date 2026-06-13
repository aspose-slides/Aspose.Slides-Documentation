---
title: Python에서 프레젠테이션 고급 텍스트 추출
linktitle: 텍스트 추출
type: docs
weight: 90
url: /ko/python-net/extract-text-from-presentation/
keywords:
- 텍스트 추출
- 슬라이드에서 텍스트 추출
- 프레젠테이션에서 텍스트 추출
- PowerPoint에서 텍스트 추출
- OpenDocument에서 텍스트 추출
- PPT에서 텍스트 추출
- PPTX에서 텍스트 추출
- ODP에서 텍스트 추출
- 텍스트 가져오기
- 슬라이드에서 텍스트 가져오기
- 프레젠테이션에서 텍스트 가져오기
- PowerPoint에서 텍스트 가져오기
- OpenDocument에서 텍스트 가져오기
- PPT에서 텍스트 가져오기
- PPTX에서 텍스트 가져오기
- ODP에서 텍스트 가져오기
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 텍스트를 빠르게 추출합니다. 간단하고 단계별 가이드를 따라 시간을 절약하세요."
---
## **개요**

프레젠테이션에서 텍스트를 추출하는 것은 슬라이드 콘텐츠를 다루는 개발자에게 흔하면서도 필수적인 작업입니다. Microsoft PowerPoint 파일(PPT 또는 PPTX 형식)이나 OpenDocument 프레젠테이션(ODP)을 다루든, 텍스트 데이터를 접근하고 검색하는 것은 분석, 자동화, 색인 작성 또는 콘텐츠 마이그레이션에 중요한 역할을 할 수 있습니다.

이 문서는 Aspose.Slides for Python via .NET을 사용하여 PPT, PPTX 및 ODP 등 다양한 프레젠테이션 형식에서 텍스트를 효율적으로 추출하는 방법에 대한 포괄적인 가이드를 제공합니다. 프레젠테이션 요소를 체계적으로 순회하여 필요한 텍스트 콘텐츠를 정확히 가져오는 방법을 배울 수 있습니다.

## **슬라이드에서 텍스트 추출**

Aspose.Slides for Python via .NET은 [aspose.slides.util](https://reference.aspose.com/slides/ko/python-net/aspose.slides.util/) 네임스페이스를 제공하며, 여기에는 [SlideUtil](https://reference.aspose.com/slides/ko/python-net/aspose.slides.util/slideutil/) 클래스가 포함됩니다. 이 클래스는 프레젠테이션이나 슬라이드에서 모든 텍스트를 추출하기 위한 여러 오버로드된 정적 메서드를 노출합니다. 프레젠테이션의 슬라이드에서 텍스트를 추출하려면 [get_all_text_boxes](https://reference.aspose.com/slides/ko/python-net/aspose.slides.util/slideutil/get_all_text_boxes/) 메서드를 사용합니다. 이 메서드는 [BaseSlide](https://reference.aspose.com/slides/ko/python-net/aspose.slides/baseslide/) 유형의 객체를 매개변수로 받습니다. 실행 시 메서드는 전체 슬라이드를 스캔하여 텍스트를 찾아 [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/) 유형의 객체 배열을 반환하며, 텍스트 서식도 보존합니다.

다음 코드 스니펫은 프레젠테이션 첫 번째 슬라이드의 모든 텍스트를 추출합니다:

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[slide_index]

    text_frames = slides.util.SlideUtil.get_all_text_boxes(slide)

    for text_frame in text_frames:
        for paragraph in text_frame.paragraphs:
            for portion in paragraph.portions:
                portion_text = portion.text
                print(portion_text)

                portion_format = portion.portion_format
                font_height = portion_format.font_height
                print(font_height)

                latin_font = portion_format.latin_font
                if latin_font is not None:
                    font_name = latin_font.font_name
                    print(font_name)
```

## **프레젠테이션에서 텍스트 추출**

전체 프레젠테이션의 텍스트를 스캔하려면 [SlideUtil](https://reference.aspose.com/slides/ko/python-net/aspose.slides.util/slideutil/) 클래스가 제공하는 [get_all_text_frames](https://reference.aspose.com/slides/ko/python-net/aspose.slides.util/slideutil/get_all_text_frames/) 정적 메서드를 사용합니다. 이 메서드는 두 개의 매개변수를 받습니다.

1. 첫 번째는 텍스트를 추출할 PowerPoint 또는 OpenDocument 프레젠테이션을 나타내는 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 객체.
2. 두 번째는 프레젠테이션에서 텍스트를 스캔할 때 마스터 슬라이드를 포함할지 여부를 나타내는 `Boolean` 값.

메서드는 [TextFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textframe/) 유형 객체 배열을 반환하며, 텍스트 서식 정보도 포함합니다. 아래 코드는 마스터 슬라이드를 포함하여 프레젠테이션의 텍스트와 서식 세부 정보를 스캔합니다.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    include_master_slides = True
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, include_master_slides)

    for text_frame in text_frames:
        for paragraph in text_frame.paragraphs:
            for portion in paragraph.portions:
                portion_text = portion.text
                print(portion_text)

                portion_format = portion.portion_format
                font_height = portion_format.font_height
                print(font_height)

                latin_font = portion_format.latin_font
                if latin_font is not None:
                    font_name = latin_font.font_name
                    print(font_name)
```

## **분류된 및 빠른 텍스트 추출**

[PresentationFactory](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentationfactory/) 클래스 또한 프레젠테이션에서 모든 텍스트를 추출하는 메서드를 제공합니다:

```py
PresentationFactory.get_presentation_text(file, mode)
PresentationFactory.get_presentation_text(stream, mode)
PresentationFactory.get_presentation_text(stream, mode, options)
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/ko/python-net/aspose.slides/textextractionarrangingmode/) 열거형 인수는 텍스트 추출 결과를 정리하는 방식을 지정하며 다음 값으로 설정할 수 있습니다.
- `UNARRANGED` - 슬라이드 위치와 관계없이 원시 텍스트.
- `ARRANGED` - 슬라이드상의 순서와 동일하게 정리된 텍스트.

속도가 중요한 경우 `UNARRANGED` 모드를 사용할 수 있으며, `ARRANGED` 모드보다 빠릅니다.

[PresentationText](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentationtext/) 은 프레젠테이션에서 추출된 원시 텍스트를 나타냅니다. its `slides_text` 속성은 슬라이드 텍스트 객체 배열을 반환합니다. 각 객체는 해당 슬라이드의 텍스트를 나타내며 다음 속성을 가집니다:

- `text` - 슬라이드 도형 내의 텍스트.
- `master_text` - 해당 슬라이드와 연결된 마스터 슬라이드 도형 내의 텍스트.
- `layout_text` - 해당 슬라이드와 연결된 레이아웃 슬라이드 도형 내의 텍스트.
- `notes_text` - 해당 슬라이드와 연결된 노트 슬라이드 도형 내의 텍스트.
- `comments_text` - 해당 슬라이드와 연결된 주석 내의 텍스트.

```py
import aspose.slides as slides

presentation_path = "presentation.ppt"
arranging_mode = slides.TextExtractionArrangingMode.UNARRANGED
presentation_text = slides.PresentationFactory.instance.get_presentation_text(presentation_path, arranging_mode)
first_slide_text = presentation_text.slides_text[0]

print(first_slide_text.text)
print(first_slide_text.layout_text)
print(first_slide_text.master_text)
print(first_slide_text.notes_text)
print(first_slide_text.comments_text)
```

## **FAQ**

**Aspose.Slides가 대형 프레젠테이션을 텍스트 추출할 때 얼마나 빠른가요?**

Aspose.Slides는 높은 성능을 위해 최적화되어 있으며, [대형 프레젠테이션](/slides/ko/python-net/open-presentation/)도 처리할 수 있어 실시간 또는 대량 처리 시나리오에 적합합니다.

**Aspose.Slides가 프레젠테이션 내 테이블 및 차트에서 텍스트를 추출할 수 있나요?**

예. Aspose.Slides는 테이블 및 차트와 같은 다양한 슬라이드 요소에서 텍스트를 추출할 수 있으므로 일반적인 프레젠테이션 구조에서 텍스트 콘텐츠에 접근하고 분석할 수 있습니다.

**프레젠테이션에서 텍스트를 추출하려면 특별한 Aspose.Slides 라이선스가 필요합니까?**

무료 평가판 버전으로도 텍스트를 추출할 수 있지만, [certain limitations](/slides/ko/python-net/licensing/)이 있어 슬라이드 수가 제한됩니다. 제한 없이 사용하고 더 큰 프레젠테이션을 처리하려면 정식 라이선스를 구매하는 것이 권장됩니다.