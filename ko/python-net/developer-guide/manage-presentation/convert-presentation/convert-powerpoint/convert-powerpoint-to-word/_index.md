---
title: Python에서 PowerPoint 프레젠테이션을 Word 문서로 변환
linktitle: PowerPoint를 Word로
type: docs
weight: 110
url: /ko/python-net/convert-powerpoint-to-word/
keywords:
- PowerPoint를 DOCX로
- OpenDocument를 DOCX로
- 프레젠테이션을 DOCX로
- 슬라이드를 DOCX로
- PPT를 DOCX로
- PPTX를 DOCX로
- ODP를 DOCX로
- PowerPoint를 DOC로
- OpenDocument를 DOC로
- 프레젠테이션을 DOC로
- 슬라이드를 DOC로
- PPT를 DOC로
- PPTX를 DOC로
- ODP를 DOC로
- PowerPoint를 Word로
- OpenDocument를 Word로
- 프레젠테이션을 Word로
- 슬라이드를 Word로
- PPT를 Word로
- PPTX를 Word로
- ODP를 Word로
- PowerPoint 변환
- OpenDocument 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- ODP 변환
- 파이썬
- Aspose.Slides
description: Aspose.Slides for Python via .NET를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션을 Word 문서로 손쉽게 변환하는 방법을 배웁니다. 샘플 Python 코드와 함께 제공되는 단계별 가이드는 문서 작업 흐름을 간소화하려는 개발자를 위한 솔루션을 제공합니다.
---
## **개요**

이 문서는 Aspose.Slides for Python via .NET와 Aspose.Words for Python via .NET를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션을 Word 문서로 변환하는 솔루션을 개발자에게 제공합니다. 단계별 가이드를 통해 변환 과정의 모든 단계를 안내합니다.

## **프레젠테이션을 Word 문서로 변환**

PowerPoint 또는 OpenDocument 프레젠테이션을 Word 문서로 변환하려면 아래 지침을 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스를 인스턴스화하고 프레젠테이션 파일을 로드합니다.
2. [Document](https://reference.aspose.com/words/python-net/aspose.words/document/) 및 [DocumentBuilder](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/) 클래스를 인스턴스화하여 Word 문서를 생성합니다.
3. [DocumentBuilder.page_setup](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/page_setup/) 속성을 사용하여 Word 문서의 페이지 크기를 프레젠테이션과 일치하도록 설정합니다.
4. [DocumentBuilder.page_setup](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/page_setup/) 속성을 사용하여 Word 문서의 여백을 설정합니다.
5. [Presentation.slides](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/slides/ko/) 속성을 통해 모든 프레젠테이션 슬라이드를 순회합니다.
    - [Slide](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slide/) 클래스의 `get_image` 메서드를 사용하여 슬라이드 이미지를 생성하고 메모리 스트림에 저장합니다.
    - [DocumentBuilder](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/) 클래스의 `insert_image` 메서드로 슬라이드 이미지를 Word 문서에 추가합니다.
6. Word 문서를 파일에 저장합니다.

예를 들어 "sample.pptx"라는 프레젠테이션이 다음과 같다고 가정해 보겠습니다:

![PowerPoint presentation](PowerPoint.png)

다음 Python 코드 예제는 PowerPoint 프레젠테이션을 Word 문서로 변환하는 방법을 보여줍니다:

```py
import aspose.slides as slides
import aspose.words as words

# 프레젠테이션 파일을 로드합니다.
with slides.Presentation("sample.pptx") as presentation:

    # Document와 DocumentBuilder 객체를 생성합니다.
    document = words.Document()
    builder = words.DocumentBuilder(document)

    # Word 문서의 페이지 크기를 설정합니다.
    slide_size = presentation.slide_size.size
    builder.page_setup.page_width = slide_size.width
    builder.page_setup.page_height = slide_size.height

    # Word 문서의 여백을 설정합니다.
    builder.page_setup.left_margin = 0
    builder.page_setup.right_margin = 0
    builder.page_setup.top_margin = 0
    builder.page_setup.bottom_margin = 0

    scale_x = 2
    scale_y = 2

    # 모든 프레젠테이션 슬라이드를 순회합니다.
    for slide in presentation.slides:

        # 슬라이드 이미지를 생성하고 메모리 스트림에 저장합니다.
        with slide.get_image(scale_x, scale_y) as image:
            image_stream = BytesIO()
            image.save(image_stream, slides.ImageFormat.PNG)

        # 슬라이드 이미지를 Word 문서에 추가합니다.
        image_stream.seek(0)
        image_width = builder.page_setup.page_width
        image_height = builder.page_setup.page_height
        builder.insert_image(image_stream.read(), image_width, image_height)

        builder.insert_break(words.BreakType.PAGE_BREAK)

    # Word 문서를 파일에 저장합니다.
    document.save("output.docx")
```

결과:

![Word document](Word.png)

{{% alert color="primary" %}} 

PowerPoint 및 OpenDocument 프레젠테이션을 Word 문서로 변환하여 얻을 수 있는 이점을 확인하려면 [**Online PPT to Word Converter**](https://products.aspose.app/slides/ko/conversion/ppt-to-word)를 사용해 보세요. 

{{% /alert %}}

## **FAQ**

**PowerPoint 및 OpenDocument 프레젠테이션을 Word 문서로 변환하려면 어떤 구성 요소를 설치해야 합니까?**

Python 프로젝트에 [Aspose.Slides for Python via .NET](https://pypi.org/project/Aspose.Slides/)와 [Aspose.Words for Python .NET](https://pypi.org/project/aspose-words/) 패키지만 추가하면 됩니다. 두 패키지는 독립형 API로 동작하므로 Microsoft Office를 설치할 필요가 없습니다.

**모든 PowerPoint 및 OpenDocument 프레젠테이션 형식을 지원합니까?**

Aspose.Slides for Python .NET은 PPT, PPTX, ODP 및 기타 일반 파일 형식을 포함한 모든 프레젠테이션 형식을 [지원합니다](/slides/ko/python-net/supported-file-formats/). 이를 통해 다양한 버전의 Microsoft PowerPoint에서 만든 프레젠테이션을 작업할 수 있습니다.